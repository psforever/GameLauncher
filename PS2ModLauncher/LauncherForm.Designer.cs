namespace PSLauncher
{
    partial class LauncherForm
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
            this.components = new System.ComponentModel.Container();
            this.findPTRDirDialogue = new System.Windows.Forms.FolderBrowserDialog();
            this.savePackDialogue = new System.Windows.Forms.SaveFileDialog();
            this.selectFileForPack = new System.Windows.Forms.OpenFileDialog();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.planetsideVersion = new System.Windows.Forms.Label();
            this.skipLauncher = new System.Windows.Forms.CheckBox();
            this.launchMessage = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.launchProgress = new System.Windows.Forms.ProgressBar();
            this.loggingCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.launchArgs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.launchGame = new System.Windows.Forms.Button();
            this.selectDirectory = new System.Windows.Forms.Button();
            this.planetside2PathTextField = new System.Windows.Forms.TextBox();
            this.ps_consoleOutput = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findPTRDirDialogue
            // 
            this.findPTRDirDialogue.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // savePackDialogue
            // 
            this.savePackDialogue.FileName = "Assets_256";
            this.savePackDialogue.Filter = "Pack Files (*.pack)|*.pack";
            // 
            // selectFileForPack
            // 
            this.selectFileForPack.FileName = "openFileDialog1";
            this.selectFileForPack.Multiselect = true;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Launcher";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.planetsideVersion);
            this.splitContainer1.Panel1.Controls.Add(this.skipLauncher);
            this.splitContainer1.Panel1.Controls.Add(this.launchMessage);
            this.splitContainer1.Panel1.Controls.Add(this.passwordLabel);
            this.splitContainer1.Panel1.Controls.Add(this.usernameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.password);
            this.splitContainer1.Panel1.Controls.Add(this.username);
            this.splitContainer1.Panel1.Controls.Add(this.launchProgress);
            this.splitContainer1.Panel1.Controls.Add(this.loggingCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.launchArgs);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.launchGame);
            this.splitContainer1.Panel1.Controls.Add(this.selectDirectory);
            this.splitContainer1.Panel1.Controls.Add(this.planetside2PathTextField);
            this.splitContainer1.Panel1MinSize = 130;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ps_consoleOutput);
            this.splitContainer1.Size = new System.Drawing.Size(621, 279);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // planetsideVersion
            // 
            this.planetsideVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.planetsideVersion.Location = new System.Drawing.Point(477, 54);
            this.planetsideVersion.Name = "planetsideVersion";
            this.planetsideVersion.Size = new System.Drawing.Size(132, 21);
            this.planetsideVersion.TabIndex = 24;
            // 
            // skipLauncher
            // 
            this.skipLauncher.AutoSize = true;
            this.skipLauncher.Location = new System.Drawing.Point(204, 23);
            this.skipLauncher.Name = "skipLauncher";
            this.skipLauncher.Size = new System.Drawing.Size(95, 17);
            this.skipLauncher.TabIndex = 23;
            this.skipLauncher.Text = "Skip Launcher";
            this.skipLauncher.UseVisualStyleBackColor = true;
            this.skipLauncher.CheckedChanged += new System.EventHandler(this.skipLauncher_CheckedChanged);
            // 
            // launchMessage
            // 
            this.launchMessage.ForeColor = System.Drawing.Color.Red;
            this.launchMessage.Location = new System.Drawing.Point(7, 107);
            this.launchMessage.Name = "launchMessage";
            this.launchMessage.Size = new System.Drawing.Size(247, 27);
            this.launchMessage.TabIndex = 22;
            this.launchMessage.Text = "label1";
            this.launchMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.launchMessage.Visible = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(7, 59);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 21;
            this.passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(5, 28);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 20;
            this.usernameLabel.Text = "Username";
            // 
            // password
            // 
            this.password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.password.Location = new System.Drawing.Point(66, 55);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(123, 20);
            this.password.TabIndex = 19;
            this.password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(66, 25);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(123, 20);
            this.username.TabIndex = 18;
            // 
            // launchProgress
            // 
            this.launchProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.launchProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.launchProgress.Location = new System.Drawing.Point(0, 137);
            this.launchProgress.Name = "launchProgress";
            this.launchProgress.Size = new System.Drawing.Size(621, 13);
            this.launchProgress.TabIndex = 16;
            this.launchProgress.Tag = "";
            this.launchProgress.UseWaitCursor = true;
            // 
            // loggingCheckBox
            // 
            this.loggingCheckBox.AutoSize = true;
            this.loggingCheckBox.Location = new System.Drawing.Point(204, 46);
            this.loggingCheckBox.Name = "loggingCheckBox";
            this.loggingCheckBox.Size = new System.Drawing.Size(64, 17);
            this.loggingCheckBox.TabIndex = 15;
            this.loggingCheckBox.Text = "Logging";
            this.loggingCheckBox.UseVisualStyleBackColor = true;
            this.loggingCheckBox.Visible = false;
            this.loggingCheckBox.CheckedChanged += new System.EventHandler(this.loggingCheckBox_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(384, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Additional command line options";
            // 
            // launchArgs
            // 
            this.launchArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.launchArgs.Location = new System.Drawing.Point(387, 102);
            this.launchArgs.Name = "launchArgs";
            this.launchArgs.Size = new System.Drawing.Size(222, 20);
            this.launchArgs.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PlanetSide Folder";
            // 
            // launchGame
            // 
            this.launchGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.launchGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchGame.Location = new System.Drawing.Point(66, 81);
            this.launchGame.Name = "launchGame";
            this.launchGame.Size = new System.Drawing.Size(123, 23);
            this.launchGame.TabIndex = 6;
            this.launchGame.Text = "Launch";
            this.launchGame.UseVisualStyleBackColor = false;
            this.launchGame.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectDirectory
            // 
            this.selectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDirectory.Location = new System.Drawing.Point(387, 49);
            this.selectDirectory.Name = "selectDirectory";
            this.selectDirectory.Size = new System.Drawing.Size(75, 23);
            this.selectDirectory.TabIndex = 2;
            this.selectDirectory.Text = "Choose";
            this.selectDirectory.UseVisualStyleBackColor = true;
            this.selectDirectory.Click += new System.EventHandler(this.button1_Click);
            // 
            // planetside2PathTextField
            // 
            this.planetside2PathTextField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.planetside2PathTextField.Location = new System.Drawing.Point(387, 23);
            this.planetside2PathTextField.Name = "planetside2PathTextField";
            this.planetside2PathTextField.ReadOnly = true;
            this.planetside2PathTextField.Size = new System.Drawing.Size(222, 20);
            this.planetside2PathTextField.TabIndex = 1;
            this.planetside2PathTextField.Text = "Path to PlanetSide folder";
            this.planetside2PathTextField.Click += new System.EventHandler(this.button1_Click);
            // 
            // ps_consoleOutput
            // 
            this.ps_consoleOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ps_consoleOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ps_consoleOutput.Location = new System.Drawing.Point(0, 0);
            this.ps_consoleOutput.Multiline = true;
            this.ps_consoleOutput.Name = "ps_consoleOutput";
            this.ps_consoleOutput.ReadOnly = true;
            this.ps_consoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ps_consoleOutput.Size = new System.Drawing.Size(621, 125);
            this.ps_consoleOutput.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 311);
            this.tabControl1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // LauncherForm
            // 
            this.AcceptButton = this.launchGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 311);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "LauncherForm";
            this.Text = "Planetside 1 Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog findPTRDirDialogue;
        private System.Windows.Forms.SaveFileDialog savePackDialogue;
        private System.Windows.Forms.OpenFileDialog selectFileForPack;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox loggingCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox launchArgs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button launchGame;
        private System.Windows.Forms.Button selectDirectory;
        private System.Windows.Forms.TextBox planetside2PathTextField;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.ProgressBar launchProgress;
        private System.Windows.Forms.TextBox ps_consoleOutput;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label launchMessage;
        private System.Windows.Forms.CheckBox skipLauncher;
        private System.Windows.Forms.Label planetsideVersion;
    }
}

