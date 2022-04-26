﻿using PSLauncher.Properties;
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

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            planetsidePathTextField.Text = Settings.Default.PSPath;
            launchArgs.Text = Settings.Default.ExtraArgs;
            clearOnLaunch.Checked = Settings.Default.ClearOutputOnLaunch;
            coreCombat.Checked = Settings.Default.CoreCombat;
            generateClientIni.Checked = Settings.Default.GenerateClientINI;

            checkPath(Path.Combine(planetsidePathTextField.Text, PS_EXE_NAME), false);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // set the starting path for the dialog
            if (planetsidePathTextField.Text != "")
                findPTRDirDialogue.SelectedPath = planetsidePathTextField.Text;
            
            DialogResult r = findPTRDirDialogue.ShowDialog(this);
            if (r == DialogResult.OK)
            {
                // combine the folder name with the standard PS.exe name
                string psPath = Path.Combine(findPTRDirDialogue.SelectedPath, PS_EXE_NAME);

                planetsidePathTextField.Text = findPTRDirDialogue.SelectedPath;

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

            var vi = FileVersionInfo.GetVersionInfo(path);

            if (vi.FileVersion != "")
            {
                // TODO: add advanced version handling
                int[] iParts = new int[4] { vi.FileMajorPart, vi.FileMinorPart, vi.FileBuildPart, vi.FilePrivatePart };
                string[] parts = new string[4];

                for(var i = 0; i < 4; i++)
                {
                    parts[i] = iParts[i].ToString();
                }

                planetsideVersion.Text = "Version " + string.Join(".", parts);
                planetsideVersion.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                planetsideVersion.Text = "Missing version";
                planetsideVersion.ForeColor = System.Drawing.Color.Red;
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

        private void coreCombat_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.CoreCombat = this.coreCombat.Checked;
        }

        private void editServerList_Click(object sender, EventArgs e)
        {
            ServerList a = new ServerList();
            a.StartPosition = FormStartPosition.CenterParent;
            a.ShowDialog(this);
        }

        private void generateClientIni_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.GenerateClientINI = generateClientIni.Checked;
        }
    }
}
