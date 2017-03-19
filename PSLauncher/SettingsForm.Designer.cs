namespace PSLauncher
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.selectDirectory = new System.Windows.Forms.Button();
            this.planetsidePathTextField = new System.Windows.Forms.TextBox();
            this.launchArgs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.planetsideVersion = new System.Windows.Forms.Label();
            this.findPTRDirDialogue = new System.Windows.Forms.FolderBrowserDialog();
            this.clearOnLaunch = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.coreCombat = new System.Windows.Forms.CheckBox();
            this.editServerList = new System.Windows.Forms.Button();
            this.generateClientIni = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PlanetSide Folder";
            // 
            // selectDirectory
            // 
            this.selectDirectory.Location = new System.Drawing.Point(12, 59);
            this.selectDirectory.Name = "selectDirectory";
            this.selectDirectory.Size = new System.Drawing.Size(75, 23);
            this.selectDirectory.TabIndex = 2;
            this.selectDirectory.Text = "Choose";
            this.selectDirectory.UseVisualStyleBackColor = true;
            this.selectDirectory.Click += new System.EventHandler(this.button1_Click);
            // 
            // planetsidePathTextField
            // 
            this.planetsidePathTextField.Location = new System.Drawing.Point(12, 33);
            this.planetsidePathTextField.Name = "planetsidePathTextField";
            this.planetsidePathTextField.ReadOnly = true;
            this.planetsidePathTextField.Size = new System.Drawing.Size(222, 20);
            this.planetsidePathTextField.TabIndex = 1;
            this.planetsidePathTextField.Text = "Path to PlanetSide folder";
            // 
            // launchArgs
            // 
            this.launchArgs.Location = new System.Drawing.Point(12, 195);
            this.launchArgs.Name = "launchArgs";
            this.launchArgs.Size = new System.Drawing.Size(222, 20);
            this.launchArgs.TabIndex = 9;
            this.launchArgs.TextChanged += new System.EventHandler(this.launchArgs_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Additional command line options";
            // 
            // planetsideVersion
            // 
            this.planetsideVersion.Location = new System.Drawing.Point(102, 59);
            this.planetsideVersion.Name = "planetsideVersion";
            this.planetsideVersion.Size = new System.Drawing.Size(132, 21);
            this.planetsideVersion.TabIndex = 3;
            this.planetsideVersion.Text = "Version";
            this.planetsideVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clearOnLaunch
            // 
            this.clearOnLaunch.AutoSize = true;
            this.clearOnLaunch.Location = new System.Drawing.Point(12, 123);
            this.clearOnLaunch.Name = "clearOnLaunch";
            this.clearOnLaunch.Size = new System.Drawing.Size(133, 17);
            this.clearOnLaunch.TabIndex = 5;
            this.clearOnLaunch.Text = "Clear output on launch";
            this.clearOnLaunch.UseVisualStyleBackColor = true;
            this.clearOnLaunch.CheckedChanged += new System.EventHandler(this.clearOnLaunch_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(91, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // coreCombat
            // 
            this.coreCombat.AutoSize = true;
            this.coreCombat.Location = new System.Drawing.Point(12, 98);
            this.coreCombat.Name = "coreCombat";
            this.coreCombat.Size = new System.Drawing.Size(87, 17);
            this.coreCombat.TabIndex = 4;
            this.coreCombat.Text = "Core Combat";
            this.coreCombat.UseVisualStyleBackColor = true;
            this.coreCombat.CheckedChanged += new System.EventHandler(this.coreCombat_CheckedChanged);
            // 
            // editServerList
            // 
            this.editServerList.Location = new System.Drawing.Point(134, 94);
            this.editServerList.Name = "editServerList";
            this.editServerList.Size = new System.Drawing.Size(100, 23);
            this.editServerList.TabIndex = 7;
            this.editServerList.Text = "Edit Server List...";
            this.editServerList.UseVisualStyleBackColor = true;
            this.editServerList.Click += new System.EventHandler(this.editServerList_Click);
            // 
            // generateClientIni
            // 
            this.generateClientIni.AutoSize = true;
            this.generateClientIni.Location = new System.Drawing.Point(12, 146);
            this.generateClientIni.Name = "generateClientIni";
            this.generateClientIni.Size = new System.Drawing.Size(111, 17);
            this.generateClientIni.TabIndex = 6;
            this.generateClientIni.Text = "Generate client.ini";
            this.generateClientIni.UseVisualStyleBackColor = true;
            this.generateClientIni.CheckedChanged += new System.EventHandler(this.generateClientIni_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 251);
            this.Controls.Add(this.generateClientIni);
            this.Controls.Add(this.editServerList);
            this.Controls.Add(this.coreCombat);
            this.Controls.Add(this.planetsideVersion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clearOnLaunch);
            this.Controls.Add(this.launchArgs);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectDirectory);
            this.Controls.Add(this.planetsidePathTextField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 290);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(260, 290);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectDirectory;
        private System.Windows.Forms.TextBox planetsidePathTextField;
        private System.Windows.Forms.TextBox launchArgs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label planetsideVersion;
        private System.Windows.Forms.FolderBrowserDialog findPTRDirDialogue;
        private System.Windows.Forms.CheckBox clearOnLaunch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox coreCombat;
        private System.Windows.Forms.Button editServerList;
        private System.Windows.Forms.CheckBox generateClientIni;
    }
}