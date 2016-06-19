using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
        public static string getDefaultPlanetSideDirectory()
        {
            Microsoft.Win32.RegistryKey key = null;
            string psFolder = "";

            // non-steam install
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths\LaunchPad.exe");

            if (key != null && key.GetValue("") != null)
            {
                String defaultDirectory;
                defaultDirectory = key.GetValue("").ToString();
                defaultDirectory = Path.GetDirectoryName(defaultDirectory);

                // verify that we aren't mistakingly returning a PlanetSide 2 directory...
                if (Directory.Exists(defaultDirectory) && checkDirForPlanetSide(defaultDirectory))
                    return defaultDirectory;

                // try to go up a directory and find the PlanetSide folder
                string upOne = Directory.GetParent(defaultDirectory).FullName;
                psFolder = Path.Combine(upOne, "Planetside");

                if (Directory.Exists(psFolder) && checkDirForPlanetSide(psFolder))
                    return psFolder;
            }

            // worth a shot!
            psFolder = Path.Combine(ProgramFilesx86(), "Sony\\PlanetSide");

            if (Directory.Exists(psFolder) && checkDirForPlanetSide(psFolder))
                return psFolder;

            // HACK: our last attempt. Should work on Win7 and above with and updated launcher
            psFolder = "C:\\Users\\Public\\Sony Online Entertainment\\Installed Games\\Planetside";

            if (Directory.Exists(psFolder) && checkDirForPlanetSide(psFolder))
                return psFolder;

            // give up
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
    }
}
