using PSLauncher.Properties;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace PSLauncher
{
    public enum EHashingAlgoType
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }

    static class Program
    {
        public static string launcherVersion;
        public static string launcherHash;
        public static EHashingAlgoType hashingAlgoType = EHashingAlgoType.SHA1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // prepare launcher info
            {
                var assemblyLocation = Assembly.GetExecutingAssembly().Location;
                launcherVersion = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
                launcherHash = Util.CalculateFileHash(assemblyLocation);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Settings.Default.PropertyChanged += Default_PropertyChanged;

            Application.Run(new LauncherForm());

            // check if the launcher was called from the URI psf://
            if (args.Length == 2 && args[0] == "--")
            {

                MessageBox.Show(args[1], args[0]);

            }
        }

        static void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
