using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using PSLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSLauncher
{

    public enum LaunchDomain
    {
        Live,
        PSForever
    }

    public enum GameState
    {
        Stopped,
        Launching,
        Running,
        Stopping
    }

    public partial class LauncherForm : Form
    {
        Process psProcess;
        string USER_AGENT = "Mozilla/5.0 (Windows NT 6.1; rv:31.0) Gecko/20100101 Firefox/31.0";

        int DEFAULT_WEB_TIMEOUT = 5000;
        bool bGameRunning = false;
        GameState gameState = GameState.Stopped;
        System.Drawing.Size oldSize = new System.Drawing.Size(0, 0);

        LaunchDomain domain = LaunchDomain.Live;

        Dictionary<LaunchDomain, string> domains = new Dictionary<LaunchDomain, string>()
        {
            { LaunchDomain.Live, "https://lpj.daybreakgames.com/ps/live" },
            { LaunchDomain.PSForever, "https://login.psforever.net/psf/live/login" }
        };

        public LauncherForm()
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

#if DEBUG
            Settings.Default.Reset();
            Console.SetOut(new Util.ControlWriter(this.ps_consoleOutput));
#endif

            // Load server 
            loadServerSelection();

            // Make sure selection is valid
            if(Settings.Default.ServerSelection >= -1 && Settings.Default.ServerSelection < serverSelection.Items.Count)
                serverSelection.SelectedIndex = Settings.Default.ServerSelection;

            string psDefault = Util.getDefaultPlanetSideDirectory();
            
            // first run with no settings or invalid starting path
            if (Settings.Default.PSPath == "" || !Util.checkDirForPlanetSide(Settings.Default.PSPath))
            {
                Settings.Default.PSPath = psDefault;
            }

            setConsoleWindowState(Settings.Default.OutputShown);
            skipLauncher.Checked = Settings.Default.SkipLauncher;
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bGameRunning)
            {
                DialogResult res = MessageBox.Show( "Are you sure you want to exit while managing PlanetSide PID " + psProcess.Id + "?" +
                    Environment.NewLine + "You won't see any debugging output if you do.", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void stopLaunching()
        {
            setButtonState(GameState.Stopped);
            progressShown(false);

            gameState = GameState.Stopped;
        }

        private void startLaunching()
        {
            setButtonState(GameState.Launching);
            progressShown(true);

            gameState = GameState.Launching;
        }

        private void setButtonState(GameState state)
        {
            this.SafeInvoke(a =>
            {
                switch (state)
                {
                    case GameState.Launching:
                        this.launchGame.Enabled = false;
                        this.launchGame.Text = "Launching...";
                        break;
                    case GameState.Running:
                        this.launchGame.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        this.launchGame.Enabled = true;
                        this.launchGame.Text = "Kill";
                        break;
                    case GameState.Stopped:
                        this.launchGame.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                        this.launchGame.Enabled = true;
                        this.launchGame.Text = "Launch";
                        break;
                    case GameState.Stopping:
                        this.launchGame.Enabled = false;
                        this.launchGame.Text = "Killing...";
                        break;
                }
            });
        }

        private void setErrorMessage(string error)
        {
            this.SafeInvoke(a =>
            {
                if (error == "")
                {
                    this.launchMessage.Visible = false;
                    return;
                }

                this.launchMessage.Visible = true;
                this.launchMessage.Text = error;
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(gameState == GameState.Running) // kill command
            {
                psProcess.Kill();
                return;
            }

            setErrorMessage("");

            if (Settings.Default.ClearOutputOnLaunch)
            {
                this.ps_consoleOutput.Clear();
            }

            string path = Settings.Default.PSPath;
            string psExe = Path.Combine(path, SettingsForm.PS_EXE_NAME);

            if (!skipLauncher.Checked && (username.Text == String.Empty || password.Text == String.Empty))
            {
                setErrorMessage("Username or password blank");
                return;
            }

            if (!Util.checkDirForPlanetSide(path))
            {
                setErrorMessage("Invalid " + SettingsForm.PS_EXE_NAME);
                return;
            }

            // Build arguments
            List<string> arguments = new List<string>();

            if (skipLauncher.Checked)
                arguments.Add("/K:StagingTest");

            if (Settings.Default.CoreCombat)
                arguments.Add("/CC");

            if (Settings.Default.ExtraArgs != "")
                arguments.Add(Settings.Default.ExtraArgs);

            // Rewrite client.ini if selected
            if(Settings.Default.GenerateClientINI)
            {
                string inipath = Path.Combine(Path.GetDirectoryName(psExe), "client.ini");
                ClientINI ini = new ClientINI(inipath);

                try
                {
                    ini.writeEntries(Util.LoadServerList(), serverSelection.SelectedIndex);
                }
                catch(IOException exp)
                {
                    setErrorMessage("Failed to write INI file");
                    addLine(String.Format("ClientINI: error - '{0}' ({1})", exp.Message, inipath));
                    return;
                }
            }

            if (skipLauncher.Checked)
            {
                // magic string to login to planetside from the actual game
                if(!startPlanetSide(psExe, Path.GetDirectoryName(psExe), String.Join(" ", arguments)))
                {
                    gameStopped();
                }
                else
                {
                    gameRunning();
                }
            }   
            else
            {
                startLaunching();

                Task.Factory.StartNew(() =>
                {
                    if(!this.doLogin())
                    {
                        gameStopped();
                    }
                    else
                    {
                        gameRunning();
                    }
                });
            }
        }

        HttpWebResponse netGetSession(string endpoint, CookieContainer cookies)
        {
            string hostname = domains[domain];
            HttpWebRequest req = WebRequest.Create(hostname + endpoint) as HttpWebRequest;
            req.CookieContainer = cookies;
            req.CookieContainer.MaxCookieSize = 4000;
            req.Method = "GET";
            req.UserAgent = USER_AGENT;
            req.Timeout = DEFAULT_WEB_TIMEOUT;

            return req.GetResponse() as HttpWebResponse;
        }

        bool doLogin()
        {
            long ts = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            string path = Settings.Default.PSPath;
            string psExe = Path.Combine(path, SettingsForm.PS_EXE_NAME);

            /////////////////////////////////////////////////////////////////
            // Step 1: Establish Session ID
            /////////////////////////////////////////////////////////////////

            String endpoint = domains[domain];
            CookieContainer reqCookies = new CookieContainer();
            HttpWebRequest req;
            HttpWebResponse r;

            try
            {
                r = netGetSession("/?t=43323", reqCookies);
            }
            catch (WebException x)
            {
                if (x.Status != WebExceptionStatus.TrustFailure)
                {
                    addLine("Failed to gather initial session: " + x.Message);
                    return false;
                }

                DialogResult res = MessageBox.Show("DBG's HTTPS certificate has failed to verify. This means that their certificate has expired " +
                    "or you may be getting Man-in-the-middled (attacked). If you are under attack, your credentials could be lost. Continue regardless?",
                    "Certificate error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res != DialogResult.Yes)
                {
                    return false;
                }

                // WARNING: once we hit yes, all further SSL errors will be ignored
                // https://stackoverflow.com/questions/2675133/c-sharp-ignore-certificate-errors
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;

                try
                {
                    r = netGetSession("/?t=43323", reqCookies);
                }
                catch (WebException x2)
                {
                    addLine("Failed to gather initial session: " + x2.Message);
                    return false;
                }
            }

            // Note: we must manually add secure cookies and CookieContainer is crap
            // See http://thomaskrehbiel.com/post/1690-cookiecontainer_httpwebrequest_and_secure_cookies/

            reqCookies.Add(new Uri(endpoint), r.Cookies);

            addLine("PSWeb: session started");
            r.Close();

            /////////////////////////////////////////////////////////////////
            // Step 2: Try logging in
            /////////////////////////////////////////////////////////////////

            req = WebRequest.Create(endpoint + "/login?t=43323") as HttpWebRequest;
            req.CookieContainer = reqCookies;
            req.Method = "POST";
            req.UserAgent = USER_AGENT;
            req.Timeout = DEFAULT_WEB_TIMEOUT;
            req.Headers.Add("X-Requested-With", "XMLHttpRequest");
            req.Headers.Add("Origin", "https://lp.soe.com");

            req.ContentType = "application/x-www-form-urlencoded";
            req.Referer = endpoint + "/?t=43323";

            NameValueCollection query = new NameValueCollection();
            query.Add("username", username.Text);
            query.Add("password", password.Text);
            query.Add("rememberPassword", "false");
            query.Add("ts", ts.ToString());

            var postdata = Encoding.ASCII.GetBytes(query.ToQueryString());
            //addLine(query.ToQueryString());

            req.ContentLength = postdata.Length;

            using (var stream = req.GetRequestStream())
            {
                stream.Write(postdata, 0, postdata.Length);
            }

            try
            {
                r = req.GetResponse() as HttpWebResponse;
            }
            catch (WebException x)
            {
                string txt;

                using (HttpWebResponse respExcept = (HttpWebResponse)x.Response)
                { 
                    if (respExcept != null && respExcept.GetResponseStream().CanRead)
                    {
                        StreamReader r2 = new StreamReader(respExcept.GetResponseStream());
                        txt = r2.ReadToEnd();
                        respExcept.Close();
                    }
                    else
                    {
                        txt = "";
                        addLine("Login failed: " + x.Message);
                        return false;
                    }
                }

                string errorDetail = "";

                try
                {
                    JObject obj2 = JObject.Parse(txt);
                    errorDetail = (string)obj2["error"];
                }
                catch (Newtonsoft.Json.JsonException x2)
                {
                    errorDetail = "Json parse error: " + x2.Message;
                }

                if (errorDetail == "INVALID_ACCOUNT_ID") // not sure if we still get this...
                {
                    setErrorMessage("Unknown username");
                }
                else if (errorDetail == "NEED_PASSWORD_RESET")
                {
                    setErrorMessage("Your account needs a password reset");
                }
                else if (errorDetail == "BAD_LOGIN")
                {
                    setErrorMessage("Bad password or username");
                }
                else // unrecognized!
                {
                    setErrorMessage("Unknown error - see output window");
                    addLine("Login failure: " + x.Status);
                    addLine("Error: " + errorDetail);
                    addLine(txt);
                }
                
                return false;
            }

            if (!r.GetResponseStream().CanRead)
            {
                setErrorMessage("Unknown error - see output window");
                addLine("No login response received");
                addLine("Status: " + r.StatusCode);

                return false;
            }

            StreamReader reader = new StreamReader(r.GetResponseStream());
            string text = reader.ReadToEnd();

            //addLine(r.Headers["Set-Cookie"]);
            reqCookies.Add(new Uri(endpoint), r.Cookies);

            string result = "";
            r.Close();
            addLine("PSWeb: logged in");

            try
            {
                JObject obj = JObject.Parse(text);
                result = (string)obj["result"];
            }
            catch (Newtonsoft.Json.JsonException x2)
            {
                result = "Json parse error: " + x2.Message;
            }

            if (result != "SUCCESS")
            {
                setErrorMessage("Unknown error - see output window");
                addLine("Bad login response: " + result);
                addLine("Status: " + r.StatusCode);
                addLine(text);

                return false;
            }
            

            /////////////////////////////////////////////////////////////////
            // Step 3: Fetch the login token
            /////////////////////////////////////////////////////////////////

            req = WebRequest.Create(endpoint + "/get_play_session?t=43323") as HttpWebRequest;
            req.CookieContainer = reqCookies;
            req.Method = "GET";
            req.UserAgent = USER_AGENT;
            req.Timeout = DEFAULT_WEB_TIMEOUT;
            req.Headers.Add("Origin", "https://lp.soe.com");
            req.Referer = endpoint + "/login?t=43323";
            req.Headers.Add("X-Requested-With", "XMLHttpRequest");
            req.Accept = "*/*";

            try
            {
                r = req.GetResponse() as HttpWebResponse;
            }
            catch (WebException x)
            {
                string txt;

                using (HttpWebResponse respExcept = (HttpWebResponse)x.Response)
                {
                    if (respExcept != null && respExcept.GetResponseStream().CanRead)
                    {
                        StreamReader r2 = new StreamReader(respExcept.GetResponseStream());
                        txt = r2.ReadToEnd();
                    }
                    else
                    {
                        txt = "";
                    }
                }

                string errorDetail = "";

                try
                {
                    JObject obj2 = JObject.Parse(txt);
                    errorDetail = (string)obj2["result"];
                }
                catch (Newtonsoft.Json.JsonException x2)
                {
                    errorDetail = "Json parse error: " + x2.Message;
                }

                if (errorDetail == "RE_LOGIN")
                {
                    setErrorMessage("Failed to fetch token: bad login");
                }
                else // unrecognized!
                {
                    setErrorMessage("Unknown error - see output window");
                }

                addLine("Get token failure: " + x.Status);
                addLine("Error: " + errorDetail);
                addLine(txt);

                return false;
            }

            if (!r.GetResponseStream().CanRead)
            {
                setErrorMessage("Unknown error - see output window");
                addLine("No login response received");
                addLine("Status: " + r.StatusCode);

                return false;
            }

            reader = new StreamReader(r.GetResponseStream());
            text = reader.ReadToEnd();

            result = "";
            r.Close();

            string token = "";

            try
            {
                JObject obj = JObject.Parse(text);
                result = (string)obj["result"];
                token = (string)obj["launchArgs"];
                //addLine(text);
            }
            catch (Newtonsoft.Json.JsonException x2)
            {
                result = "Json parse error: " + x2.Message;
                token = "";
            }

            if (result != "SUCCESS")
            {
                setErrorMessage("Failed to get token");
                addLine("Bad token response: " + result);
                addLine("Status: " + r.StatusCode);
                addLine(text);

                return false;
            }

            addLine("PSWeb: got launch args " + token);

            string launch_args = token;
            string ExtraLaunchArgs = Settings.Default.ExtraArgs;

            if (ExtraLaunchArgs != String.Empty)
                launch_args += " " + ExtraLaunchArgs;
            
            return startPlanetSide(psExe, path, launch_args);
        }

        bool startPlanetSide(string exe, string workingDir, string args)
        {
            psProcess = new Process();

            psProcess.StartInfo.WorkingDirectory = workingDir; // TODO: should this be where the launcher is for logging?
            psProcess.StartInfo.FileName = exe;
            psProcess.StartInfo.Arguments = args;
            psProcess.StartInfo.RedirectStandardOutput = true;
            psProcess.StartInfo.RedirectStandardError = true;
            psProcess.StartInfo.UseShellExecute = false;
            psProcess.Exited += new EventHandler(ps_Exited);
            psProcess.OutputDataReceived += new DataReceivedEventHandler(ps_OutputDataReceived);
            psProcess.EnableRaisingEvents = true;

            addLine("ProcessStart: \"" + exe + "\" " + args);

            if (!psProcess.Start())
            {
                addLine("ProcessStart: failed to start the planetside process! Make sure your planetside folder path is correct.");
                return false;
            }

            addLine(String.Format("ProcessStart: planetside running as PID {0}", psProcess.Id));

            psProcess.BeginErrorReadLine();
            psProcess.BeginOutputReadLine();

            return true;
        }

        void ps_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(e != null)
            {
                addLine(e.Data);
            }
        }

        void addLine(String line)
        {
            this.SafeInvoke(a =>
            {
                ps_consoleOutput.AppendText(line + Environment.NewLine);
            });
        }

        void gameRunning()
        {
            setButtonState(GameState.Running);
            progressShown(false);

            bGameRunning = true;
            gameState = GameState.Running;
        }

        void gameStopped()
        {
            this.stopLaunching();
            bGameRunning = false;
        }

        void ps_Exited(object sender, EventArgs e)
        {
            addLine(String.Format("ProcessEnd: exit code 0x{0}", psProcess.ExitCode.ToString("X8")));

            gameStopped();
        }

        private void progressShown(bool shown)
        {
            this.SafeInvoke(a =>
            {
                if (shown)
                {
                    this.spinner.Visible = true;
                    this.spinner.Enabled = true;
                    this.launchGame.Visible = false;
                }
                else
                {
                    this.spinner.Visible = false;
                    this.spinner.Enabled = false;
                    this.launchGame.Visible = true;
                }
            });
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.StartPosition = FormStartPosition.CenterParent;
            a.ShowDialog(this);
        }

        private void loginFormChangedUpdate()
        {
            if (gameState == GameState.Stopped)
            {
                if ((username.Text.Length > 0 && password.Text.Length > 0 || skipLauncher.Checked) &&
                    serverSelection.SelectedIndex != -1)
                    launchGame.Enabled = true;
                else
                    launchGame.Enabled = false;
            }

            if (skipLauncher.Checked)
            {
                Settings.Default.SkipLauncher = true;
                username.Enabled = false;
                password.Enabled = false;
            }
            else
            {
                Settings.Default.SkipLauncher = false;
                username.Enabled = true;
                password.Enabled = true;
            }
        }

        private void loginFormChanged(object sender, EventArgs e)
        {
            loginFormChangedUpdate();
        }

        private void setConsoleWindowState(bool open)
        {
            if (!open)
            {
                oldSize = this.Size;

                this.hideShowOutput.Text = "vv Show vv";
                this.MinimumSize = this.MaximumSize = new System.Drawing.Size(460, 160);
                
                this.Size = new System.Drawing.Size(460, 160);

                this.WindowState = FormWindowState.Normal;
                this.MaximizeBox = false;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            else
            {
                this.hideShowOutput.Text = "^^ Hide ^^";
                this.MinimumSize = new System.Drawing.Size(460, 350);
                this.MaximumSize = new System.Drawing.Size(0, 0);

                if (oldSize.IsEmpty)
                    this.Size = new System.Drawing.Size(600, 500); // default size to expand to
                else
                    this.Size = oldSize;

                this.MaximizeBox = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }

            splitContainer1.Panel2Collapsed = !open;
        }

        private void LauncherForm_ResizeBegin(object sender, EventArgs e)
        {
            splitContainer1.Panel2.SuspendLayout();
        }

        private void LauncherForm_ResizeEnd(object sender, EventArgs e)
        {
            Win32.SuspendPainting(splitContainer1.Panel2.Handle);
            splitContainer1.Panel2.ResumeLayout();
            Win32.ResumePainting(splitContainer1.Panel2.Handle);
            this.Refresh();
        }

        private void hideShowOutput_Click_1(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {
                Settings.Default.OutputShown = true;
                setConsoleWindowState(true);
            }
            else
            {
                Settings.Default.OutputShown = false;
                setConsoleWindowState(false);
            }
        }

        private void loadServerSelection()
        {
            int index = serverSelection.SelectedIndex;

            List<ServerEntry> entries = Util.LoadServerList();
            serverSelection.Items.Clear();

            foreach (ServerEntry entry in entries)
            {
                serverSelection.Items.Add(entry.name);
            }

            if (entries.Count > 0 && index != -1)
            {
                if (index + 1 >= entries.Count)
                {
                    serverSelection.SelectedIndex = entries.Count - 1;
                }
                else
                {
                    serverSelection.SelectedIndex = index;
                }
            }

            loginFormChangedUpdate();

            // Dont let us select a server without any servers!
            serverSelection.Enabled = entries.Count != 0;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm a = new SettingsForm();
            a.StartPosition = FormStartPosition.CenterParent;
            a.ShowDialog(this);

            loadServerSelection();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            this.ps_consoleOutput.Focus();
            this.ps_consoleOutput.SelectAll();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            this.ps_consoleOutput.Copy();
        }

        private void saveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "";
            saveFile.Filter = "Output file (*.txt) | *.txt";
            saveFile.AddExtension = true;
            saveFile.DefaultExt = ".txt";

            DialogResult result = saveFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream f = File.OpenWrite(saveFile.FileName);

                var encoder = new ASCIIEncoding();
                var header = encoder.GetBytes(String.Format("{0} log output {1}" + Environment.NewLine, this.Text, DateTime.Now.ToString()));
                var data = new ASCIIEncoding().GetBytes(this.ps_consoleOutput.Text);

                f.Write(header, 0, header.Length);
                f.Write(data, 0, data.Length);
                f.Close();
            }
        }

        private void serverSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.ServerSelection = serverSelection.SelectedIndex;

            // Update the login form as well
            loginFormChangedUpdate();
        }
    }
}
