using Newtonsoft.Json;
using PSLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSLauncher
{

    public enum LaunchDomain
    {
        Live,
        PSForever,
        Dev,
        DevSSL
    }

    public enum GameState
    {
        Stopped,
        Authenticating,
        Validating,
        Launching,
        Running,
        Stopping
    }

    public partial class LauncherForm : Form
    {
        private HttpClient httpClient;
        private Process psProcess;

        bool bGameRunning = false;
        int DEFAULT_WEB_TIMEOUT = 5;
        GameState gameState = GameState.Stopped;
        LaunchDomain domain = LaunchDomain.PSForever;

        System.Drawing.Size oldSize = new System.Drawing.Size(0, 0);

        Dictionary<LaunchDomain, string> domains = new Dictionary<LaunchDomain, string>()
        {
            { LaunchDomain.Live, "https://lpj.daybreakgames.com/ps/live/" },
            { LaunchDomain.PSForever, "https://login.psforever.net/psf/live/" },
            { LaunchDomain.Dev, "http://localhost:9001/psf/live/" },
            { LaunchDomain.DevSSL, "http://localhost:9001/psf/live/" }
        };

        Dictionary<LaunchDomain, string> userAgents = new Dictionary<LaunchDomain, string>()
        {
            { LaunchDomain.Live, "Mozilla/5.0 (Windows NT 6.1; rv:31.0) Gecko/20100101 Firefox/31.0" },
            { LaunchDomain.PSForever, string.Format("PSF Launcher v{0}", Program.launcherVersion) },
            { LaunchDomain.Dev, string.Format("PSF Launcher v{0}", Program.launcherVersion) },
            { LaunchDomain.DevSSL, string.Format("PSF Launcher v{0}", Program.launcherVersion) }
        };

        public LauncherForm()
        {
            //
            // init form components
            //
            InitializeComponent();

            //
            // init http client
            //
            httpClient = new HttpClient(
                new HttpClientHandler()
                {
                    AllowAutoRedirect = false,
                    SslProtocols = System.Security.Authentication.SslProtocols.Tls13,
                }
            )
            {
                BaseAddress = new Uri(domains[domain]),
                Timeout = TimeSpan.FromSeconds(DEFAULT_WEB_TIMEOUT)
            };

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgents[domain]);
            httpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            //
            // set form icon
            //
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

#if DEBUG
            //Settings.Default.Reset();
            Console.SetOut(new Util.ControlWriter(this.ps_consoleOutput));
#endif
            skipLauncher.Checked = Settings.Default.SkipLauncher;

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
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bGameRunning && Settings.Default.OutputShown)
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

        private void startAuthenticating()
        {
            setButtonState(GameState.Authenticating);
            progressShown(true);

            gameState = GameState.Authenticating;
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
                    case GameState.Stopped:
                        this.launchGame.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                        this.launchGame.Enabled = true;
                        this.launchGame.Text = "Launch";

                        // allow modification if launcher is not skipped
                        if (!skipLauncher.Checked)
                        {
                            this.username.Enabled = true;
                            this.password.Enabled = true;
                        }
                        
                        break;

                    case GameState.Authenticating:
                        this.launchGame.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
                        this.launchGame.Enabled = false;
                        this.launchGame.Text = "Authenticating";

                        // disallow modification because we are launching
                        this.username.Enabled = false;
                        this.password.Enabled = false;

                        break;

                    case GameState.Validating:
                        this.launchGame.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
                        this.launchGame.Enabled = false;
                        this.launchGame.Text = "Validating";
                        break;

                    case GameState.Launching:
                        this.launchGame.Enabled = false;
                        this.launchGame.Text = "Launching";
                        break;

                    case GameState.Running:
                        this.launchGame.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        this.launchGame.Enabled = true;
                        this.launchGame.Text = "Kill";
                        break;

                    case GameState.Stopping:
                        this.launchGame.Enabled = false;
                        this.launchGame.Text = "Killing...";
                        break;
                }
            });
        }

        private void setButtonValidationState(int counter, int fileCount)
        {
            this.SafeInvoke(a =>
            {
                this.launchGame.Text = string.Format("Validating {0}/{1}", counter, fileCount);
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

        private void launchGame_Click(object sender, EventArgs e)
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

            if (Settings.Default.CoreCombat)
                arguments.Add("/CC");

            if (Settings.Default.ExtraArgs != "")
                arguments.Add(Settings.Default.ExtraArgs);

            WriteClientINI();

            if (skipLauncher.Checked)
            {
                arguments.Add("/K:StagingTest");

                LaunchStaging();
            }   
            else
            {
                Launch();
            }

            return;

            //
            // functions used only in this function
            //

            void WriteClientINI()
            {
                // Rewrite client.ini if selected
                if (!Settings.Default.GenerateClientINI) return;
                    
                string inipath = Path.Combine(Path.GetDirectoryName(psExe), "client.ini");
                ClientINI ini = new ClientINI(inipath);

                try
                {
                    ini.writeEntries(Util.LoadServerList(), serverSelection.SelectedIndex);
                }
                catch (IOException exp)
                {
                    setErrorMessage("Failed to write INI file");
                    addLine(String.Format("ClientINI: error - '{0}' ({1})", exp.Message, inipath));
                    return;
                }
            }

            void LaunchStaging()
            {
                // magic string to login to planetside from the actual game
                if (!startPlanetSide(psExe, Path.GetDirectoryName(psExe), String.Join(" ", arguments)))
                {
                    gameStopped();
                }
                else
                {
                    gameRunning();
                }
            }

            void Launch()
            {
                startLaunching();

                Task.Factory.StartNew(() =>
                {
                    // check file integrity
                });

                Task.Factory.StartNew(() =>
                {
                    if (!this.doLogin())
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

        class DefaultResponse
        {
            public int Status { get; set; }
        };

        class ErrorResponse : DefaultResponse
        {
            //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public string ErrorText { get; set; }
        }

        class VersionResponse : DefaultResponse
        {
            public Int64 ReleaseDate { get; set; }
            public string VersionString { get; set; }
        }

        class TokenResponse : DefaultResponse
        {
            public string Token { get; set; }
        }

        class ValidationResponse : DefaultResponse
        {
            public string[] Files { get; set; }
        }

        class GameTokenResponse : DefaultResponse
        {
            public string GameToken { get; set; }
        }

        class LoginRequestBody
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Launcher { get; set; }
            public int Mode { get; set; }
        }

        class ValidateRequestBody
        {
            public string Launcher { get; set; }
            public string Files { get; set; }
        }

        void handleErrorResponse(ref string _errorBody)
        {
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(_errorBody);
            string errorMessage;
            addLine("=====");
            addLine("The launcher received an error:");

            switch(errorResponse.Status)
            {
                case 100:
                    errorMessage = "Launcher Update required.";
                    break;

                case 101:
                    errorMessage = "Launcher is corrupted, please download the latest PSF Launcher.";
                    break;

                case 102:
                    errorMessage = "Launcher token expired, please retry.";
                    break;

                case 103:
                    errorMessage = "Gamefiles are corrupted, please replace them.";
                    break;

                case 104:
                    errorMessage = "Launcher is no longer supported, please download the latest PSF Launcher.";
                    break;

                case 200:
                    errorMessage = "This account does not yet support Launcher login, please sign in via \"Skip Launcher\" once.";
                    break;

                case 201:
                    errorMessage = "Wrong Username or Password.";
                    break;

                case 202:
                    errorMessage = "This account is inactive, please contact the PSF Support on Discord.";
                    break;

                case 300:
                    errorMessage = "There has been a database error, please try again later.";
                    break;

                default:
                    errorMessage = "Please report to this error to the PSF Support on Discord\nError: " + errorResponse.Status;
                    break;
            }

            // print the launcher message
            addLine(errorMessage);

            // print the message from the error response
            if ( errorResponse.ErrorText.Length != 0 )
            {
                addLine(errorResponse.ErrorText);
            }

            addLine("=====");
        }

        void checkLauncherVersion()
        {
            addLine("Checking for new PSF Launcher version...");

            HttpResponseMessage respVersion;
            try
            {
                respVersion = httpClient.GetAsync("version").Result;
            }
            catch
            {
                addLine("Error: Version GET did not return");
                return;
            }

            if (!respVersion.IsSuccessStatusCode)
            {
                addLine("Error: Version GET status " + respVersion.StatusCode);
                return;
            }

            var result = respVersion.Content.ReadAsStringAsync().Result;
            var versionResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<VersionResponse>(result);

            if (versionResponse.Status != 0)
            {
                handleErrorResponse(ref result);

                return;
            }

            var newestVersion = new List<string>(versionResponse.VersionString.Split('.'));
            var localVersion = new List<string>(Program.launcherVersion.Split('.'));

            if ( newestVersion.Count != localVersion.Count )
            {
                addLine("=====");
                addLine("Could not compare launcher versions. Launching may fail.");
                addLine(string.Format("Local version: {0} - latest version: {1}", localVersion, newestVersion));
                addLine("Please update if there is a newer PSF Launcher version.");
                addLine("=====");

                return;
            }

            bool newerVersionAvailable = false;
            for (int i = 0; i < newestVersion.Count; i++)
            {
                var nv = int.Parse(newestVersion[i]);
                var lv = int.Parse(localVersion[i]);

                if (lv < nv)
                {
                    newerVersionAvailable = true;
                    break;
                }
            }

            if ( newerVersionAvailable )
            {
                DateTime parsedTime = Util.UnixTimestampToDateTime(versionResponse.ReleaseDate);

                addLine("There is a newer version of the PSF Launcher. Launching may fail.");

                addLine(
                    string.Format(
                        "Version information: v{0} released {1}",
                        versionResponse.VersionString,
                        parsedTime.ToLocalTime().ToLongDateString()
                    )
                );

                addLine("=====");
            }
            else
            {
                addLine("PSF Launcher is on the latest version.");
            }

            addLine("");

            return;
        }

        bool sendLoginData()
        {
            var username = this.username.Text;
            var password = this.password.Text;
            var passwordHash = Util.CalculateStringHash(EHashingAlgoType.SHA256, username + password);

            var loginRequestBody = new LoginRequestBody
            {
                Username = this.username.Text,
                Password = passwordHash,
                Launcher = Program.launcherHash,
                Mode = 0
            };

            HttpResponseMessage respLogin;
            try
            {
                respLogin = httpClient.PostAsJsonAsync("login", loginRequestBody).Result;
            }
            catch (Exception e)
            {
                addLine("Error: Login POST did not return");
                addLine(e.InnerException.Message);
                return false;
            }

            if (!respLogin.IsSuccessStatusCode)
            {
                addLine("Error: Login GET status " + respLogin.StatusCode);
                return false;
            }

            var result = respLogin.Content.ReadAsStringAsync().Result;
            var loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(result);

            if (loginResponse.Status != 0)
            {
                handleErrorResponse(ref result);

                return false;
            }

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResponse.Token);

            return true;
        }

        bool getFilesToValidate(ref List<string> _filesToValidate)
        {
            HttpResponseMessage respValidateGet;
            try
            {
                respValidateGet = httpClient.GetAsync("validate").Result;
            }
            catch (Exception e)
            {
                addLine("Error: Validate GET did not return");
                addLine(e.Message);
                return false;
            }

            if (!respValidateGet.IsSuccessStatusCode)
            {
                addLine("Error: Validate GET status " + respValidateGet.StatusCode);
                return false;
            }

            var result = respValidateGet.Content.ReadAsStringAsync().Result;
            var validateGetResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ValidationResponse>(result);

            if (validateGetResponse.Status != 0)
            {
                handleErrorResponse(ref result);

                return false;
            }

            _filesToValidate.AddRange(validateGetResponse.Files);

            return true;
        }

        bool validateFiles(List<string>_filesToValidate, ref string _fileHashResult)
        {
            string basePath = Settings.Default.PSPath;
            List<string> fileHashes = new List<string>();

            for (int index = 0; index < _filesToValidate.Count; index++)
            {
                setButtonValidationState(index + 1, _filesToValidate.Count);

                string filePath = _filesToValidate[index];

                // get absolute path
                var absPath = Path.GetFullPath(Path.Combine(basePath, filePath));

                // make sure path is within planetside directory
                if (!absPath.StartsWith(basePath))
                {
                    addLine("Error: Filepath for validation is outside of planetside directory");
                    return false;
                }

                FileStream fileHandle;
                try
                {
                    fileHandle = File.OpenRead(absPath);
                }
                catch
                {
                    addLine("Error: Required file not found: " + filePath);
                    return false;
                }

                fileHashes.Add(Util.CalculateFileHash(fileHandle));

                fileHandle.Close();
            }

            _fileHashResult = Util.CalculateStringHash(string.Join("", fileHashes));

            return true;
        }

        bool sendValidationResult(string _hashResult)
        {
            var validateResponseBody = new ValidateRequestBody
            {
                Launcher = Program.launcherHash,
                Files = _hashResult
            };

            HttpResponseMessage respValidatePost;
            try
            {
                respValidatePost = httpClient.PostAsJsonAsync("validate", validateResponseBody).Result;
            }
            catch
            {
                addLine("Error: Validate POST did not return");
                return false;
            }

            if (!respValidatePost.IsSuccessStatusCode)
            {
                addLine("Error: Validate POST status " + respValidatePost.StatusCode);
                return false;
            }

            var result = respValidatePost.Content.ReadAsStringAsync().Result;
            var validatePostResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(result);

            if (validatePostResponse.Status != 0)
            {
                handleErrorResponse(ref result);

                return false;
            }

            // update to validated token
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", validatePostResponse.Token);

            return true;
        }

        bool getGameToken(ref string _gameToken)
        {
            HttpResponseMessage respGameToken;
            try
            {
                respGameToken = httpClient.GetAsync("gametoken").Result;
            }
            catch
            {
                addLine("Error: GameToken GET did not return");
                return false;
            }

            if (!respGameToken.IsSuccessStatusCode)
            {
                addLine("Error: GameToken GET status " + respGameToken.StatusCode);
                return false;
            }

            var result = respGameToken.Content.ReadAsStringAsync().Result;
            var gameTokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GameTokenResponse>(result);

            if (gameTokenResponse.Status != 0)
            {
                handleErrorResponse(ref result);

                return false;
            }

            _gameToken = gameTokenResponse.GameToken;

            return true;
        }

        bool doLogin()
        {
            string path = Settings.Default.PSPath;
            string psExe = Path.GetFullPath(Path.Combine(path, SettingsForm.PS_EXE_NAME));

            // clear previous login token
            httpClient.DefaultRequestHeaders.Authorization = null;

            if ( !psExe.StartsWith(path) )
            {
                addLine("Error: planetside.exe outside of planetside directory: " + psExe);
                return false;
            }

            addLine("");
            addLine("Start launching");
            addLine("");

            // start authentication
            setButtonState(GameState.Authenticating);

            //
            // get current launcher version
            //
            checkLauncherVersion();

            //
            // send login data
            //
            if ( !sendLoginData() )
            {
                return false;
            }

            //
            // get file validation info
            //
            List<string> filesToValidate = new List<string>();
            if ( !getFilesToValidate(ref filesToValidate) )
            {
                return false;
            }

            //
            // validate files
            //
            setButtonState(GameState.Validating);

            string hashResult = "";
            if ( !validateFiles(filesToValidate, ref hashResult) )
            {
                return false;
            }

            //
            // send validtation result
            //
            if ( !sendValidationResult(hashResult) )
            {
                return false;
            }

            // finished validating
            setButtonState(GameState.Launching);

            //
            // get game token
            //
            string gameToken = "";
            if ( !getGameToken(ref gameToken) )
            {
                return false;
            }

            string launch_args = "/K:" + gameToken;
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

            addLine(String.Format("ProcessStart: \"{0}\" {1}", exe, args));

            addLine("");
            addLine("LAUNCHING");
            addLine("");

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
                }
                else
                {
                    this.spinner.Visible = false;
                    this.spinner.Enabled = false;
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
