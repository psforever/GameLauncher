using PSLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSLauncher
{
    public partial class SettingsForm : Form
    {
        static public string PS_EXE_NAME = "planetside.exe";

        public SettingsForm()
        {
            InitializeComponent();

            planetside2PathTextField.Text = Settings.Default.PSPath;
            launchArgs.Text = Settings.Default.ExtraArgs;
            clearOnLaunch.Checked = Settings.Default.ClearOutputOnLaunch;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // set the starting path for the dialog
            if (planetside2PathTextField.Text != "")
                findPTRDirDialogue.SelectedPath = planetside2PathTextField.Text;

            DialogResult r = findPTRDirDialogue.ShowDialog();

            if (r == DialogResult.OK)
            {
                // combine the folder name with the standard PS.exe name
                string psPath = Path.Combine(findPTRDirDialogue.SelectedPath, PS_EXE_NAME);

                planetside2PathTextField.Text = findPTRDirDialogue.SelectedPath;

                if (checkPath(psPath))
                    Settings.Default.PSPath = findPTRDirDialogue.SelectedPath;
            }
        }

        private bool checkPath(string path, bool alert = true)
        {
            if (!File.Exists(path))
            {
                planetsideVersion.Text = "Not found";
                planetsideVersion.ForeColor = System.Drawing.Color.Red;

                if (alert)
                    MessageBox.Show("Cannot open " + PS_EXE_NAME + " (check the selected directory)",
                           "Cannot Find Executable", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            var versionInfo = FileVersionInfo.GetVersionInfo(path);

            if (versionInfo.FileVersion != "")
            {
                planetsideVersion.Text = "Version " + versionInfo.FileVersion;
                planetsideVersion.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                planetsideVersion.Text = "Unknown version";
                planetsideVersion.ForeColor = System.Drawing.Color.Yellow;
            }

            return true;
        }

        private void launchArgs_TextChanged(object sender, EventArgs e)
        {
            if (Settings.Default.ExtraArgs != launchArgs.Text)
            {
                Settings.Default.ExtraArgs = this.launchArgs.Text;
            }
        }

        private void clearOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ClearOutputOnLaunch = this.clearOnLaunch.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
