using PSLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PSLauncher
{
    public static class ISynchronizeInvokeExtensions
    {
        public static void SafeInvoke<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }
    }
    
    public static class QueryExtensions
    {
        public static string ToQueryString(this NameValueCollection nvc)
        {
            IEnumerable<string> segments = from key in nvc.AllKeys
                                           from value in nvc.GetValues(key)
                                           select string.Format("{0}={1}", key, value);
            return string.Join("&", segments);
        }
    }
    public static class Win32
    {

        public const int WM_SETREDRAW = 0x0b;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static void SuspendPainting(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
        }

        public static void ResumePainting(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
        }
    }

    public static class Util
    {
        public static List<ServerEntry> LoadServerList()
        {
            List<ServerEntry> entries = new List<ServerEntry>();
            StringCollection serverList = Settings.Default.ServerList;

            foreach (String entry in serverList)
            {
                String[] tokens = entry.Split(',');

                if (tokens.Length != 3)
                {
                    Console.WriteLine("LoadServerList: Failed to load server entry " + entry);
                    continue;
                }

                ServerEntry newEntry = new ServerEntry();
                newEntry.name = tokens[0];
                newEntry.hostname = tokens[1];
                newEntry.port = int.Parse(tokens[2]);

                entries.Add(newEntry);
            }

            return entries;
        }

        public static string getDefaultPlanetSideDirectory()
        {
            // paths are in order of newest (most likely to have the right planetside) to oldest
            Microsoft.Win32.RegistryKey key = null;
            string psFolder = "";
            List<string> pathsToCheck = new List<String>();

            // non-steam install
            // Known to be: C:\Users\Public\Daybreak Game Company\Installed Games\PlanetSide 2 Test\LaunchPad.exe
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths\LaunchPad.exe");

            if (key != null && key.GetValue("") != null)
            {
                String defaultDirectory;
                defaultDirectory = key.GetValue("").ToString();

                Console.WriteLine("PSDiscover: LaunchPad.exe key found {0}", defaultDirectory);

                defaultDirectory = Path.GetDirectoryName(defaultDirectory);

                // verify that we aren't mistakingly returning a PlanetSide 2 directory...
                pathsToCheck.Add(defaultDirectory);
            
                // try to go up a directory and find the PlanetSide folder
                string upOne = Directory.GetParent(defaultDirectory).FullName;
                psFolder = Path.Combine(upOne, "Planetside");

                pathsToCheck.Add(psFolder);
            }
            else
            {
                Console.WriteLine("PSDiscover: No LaunchPad.exe key found");
            }

            // HACK: Should work on Win7 and above
            psFolder = "C:\\Users\\Public\\Daybreak Game Company\\Installed Games\\Planetside";
            pathsToCheck.Add(psFolder);
            
            // HACK 2: our last attempt
            psFolder = "C:\\Users\\Public\\Sony Online Entertainment\\Installed Games\\Planetside";
            pathsToCheck.Add(psFolder);

            // worth a shot! (for windows XP or old installs)
            string programFiles = ProgramFilesx86();
            if(programFiles != null) {
                psFolder = Path.Combine(programFiles, "Sony\\PlanetSide");
                pathsToCheck.Add(psFolder);
            }

            int i = 1;
            foreach(var path in pathsToCheck)
            {
                Console.WriteLine("PSDiscover: M{0} - {1}", i, path);

                if (Directory.Exists(path) && checkDirForPlanetSide(path))
                {
                    Console.WriteLine("PSDiscover: Path found using M{0}", i);
                    return path;
                }

                i += 1;
            }

            Console.WriteLine("PSDiscover: No default planetside.exe path found!");

            // give up :'(
            return "";
        }

        public static bool checkDirForPlanetSide(string dir)
        {
            return File.Exists(Path.Combine(dir, SettingsForm.PS_EXE_NAME));
        }

        public static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        // from https://stackoverflow.com/questions/18726852/redirecting-console-writeline-to-textbox
        public class ControlWriter : TextWriter
        {
            private Control textbox;
            public ControlWriter(Control textbox)
            {
                this.textbox = textbox;
            }

            public override void Write(char value)
            {
                textbox.Text += value;
            }

            public override void Write(string value)
            {
                textbox.Text += value;
            }

            public override Encoding Encoding
            {
                get { return Encoding.ASCII; }
            }
        }
    }
}
