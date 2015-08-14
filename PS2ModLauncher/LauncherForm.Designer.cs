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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.planetsideVersion = new System.Windows.Forms.Label();
            this.launchArgs = new System.Windows.Forms.TextBox();
            this.launchProgress = new System.Windows.Forms.ProgressBar();
            this.skipLauncher = new System.Windows.Forms.CheckBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.loggingCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.launchGame = new System.Windows.Forms.Button();
            this.selectDirectory = new System.Windows.Forms.Button();
            this.planetside2PathTextField = new System.Windows.Forms.TextBox();
            this.launchMessage = new System.Windows.Forms.Label();
            this.ps_consoleOutput = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findPTRDirDialogue
            // 
            this.findPTRDirDialogue.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.planetsideVersion);
            this.splitContainer1.Panel1.Controls.Add(this.launchArgs);
            this.splitContainer1.Panel1.Controls.Add(this.launchProgress);
            this.splitContainer1.Panel1.Controls.Add(this.skipLauncher);
            this.splitContainer1.Panel1.Controls.Add(this.passwordLabel);
            this.splitContainer1.Panel1.Controls.Add(this.usernameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.password);
            this.splitContainer1.Panel1.Controls.Add(this.username);
            this.splitContainer1.Panel1.Controls.Add(this.loggingCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.launchGame);
            this.splitContainer1.Panel1.Controls.Add(this.selectDirectory);
            this.splitContainer1.Panel1.Controls.Add(this.planetside2PathTextField);
            this.splitContainer1.Panel1.Controls.Add(this.launchMessage);
            this.splitContainer1.Panel1MinSize = 125;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ps_consoleOutput);
            this.splitContainer1.Size = new System.Drawing.Size(584, 486);
            this.splitContainer1.SplitterDistance = this.splitContainer1.Panel1MinSize;
            this.splitContainer1.TabIndex = 0;
            // 
            // planetsideVersion
            // 
            this.planetsideVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.planetsideVersion.Location = new System.Drawing.Point(419, 50);
            this.planetsideVersion.Name = "planetsideVersion";
            this.planetsideVersion.Size = new System.Drawing.Size(132, 21);
            this.planetsideVersion.TabIndex = 24;
            // 
            // launchArgs
            // 
            this.launchArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.launchArgs.Location = new System.Drawing.Point(329, 96);
            this.launchArgs.Name = "launchArgs";
            this.launchArgs.Size = new System.Drawing.Size(222, 20);
            this.launchArgs.TabIndex = 6;
            // 
            // launchProgress
            // 
            this.launchProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.launchProgress.Location = new System.Drawing.Point(9, 96);
            this.launchProgress.Name = "launchProgress";
            this.launchProgress.Size = new System.Drawing.Size(246, 20);
            this.launchProgress.TabIndex = 16;
            this.launchProgress.Tag = "";
            this.launchProgress.UseWaitCursor = true;
            this.launchProgress.Visible = false;
            // 
            // skipLauncher
            // 
            this.skipLauncher.AutoSize = true;
            this.skipLauncher.Location = new System.Drawing.Point(205, 13);
            this.skipLauncher.Name = "skipLauncher";
            this.skipLauncher.Size = new System.Drawing.Size(95, 17);
            this.skipLauncher.TabIndex = 3;
            this.skipLauncher.Text = "Skip Launcher";
            this.skipLauncher.UseVisualStyleBackColor = true;
            this.skipLauncher.CheckedChanged += new System.EventHandler(this.loginFormChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(8, 45);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 21;
            this.passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(6, 14);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 20;
            this.usernameLabel.Text = "Username";
            // 
            // password
            // 
            this.password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.password.Location = new System.Drawing.Point(67, 41);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(123, 20);
            this.password.TabIndex = 1;
            this.password.UseSystemPasswordChar = true;
            this.password.TextChanged += new System.EventHandler(this.loginFormChanged);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(67, 11);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(123, 20);
            this.username.TabIndex = 0;
            this.username.TextChanged += new System.EventHandler(this.loginFormChanged);
            // 
            // loggingCheckBox
            // 
            this.loggingCheckBox.AutoSize = true;
            this.loggingCheckBox.Location = new System.Drawing.Point(205, 36);
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
            this.label10.Location = new System.Drawing.Point(326, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Additional command line options";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PlanetSide Folder";
            // 
            // launchGame
            // 
            this.launchGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.launchGame.Enabled = false;
            this.launchGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchGame.Location = new System.Drawing.Point(67, 67);
            this.launchGame.Name = "launchGame";
            this.launchGame.Size = new System.Drawing.Size(123, 23);
            this.launchGame.TabIndex = 2;
            this.launchGame.Text = "Launch";
            this.launchGame.UseVisualStyleBackColor = false;
            this.launchGame.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectDirectory
            // 
            this.selectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDirectory.Location = new System.Drawing.Point(329, 45);
            this.selectDirectory.Name = "selectDirectory";
            this.selectDirectory.Size = new System.Drawing.Size(75, 23);
            this.selectDirectory.TabIndex = 5;
            this.selectDirectory.Text = "Choose";
            this.selectDirectory.UseVisualStyleBackColor = true;
            this.selectDirectory.Click += new System.EventHandler(this.button1_Click);
            // 
            // planetside2PathTextField
            // 
            this.planetside2PathTextField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.planetside2PathTextField.Location = new System.Drawing.Point(329, 19);
            this.planetside2PathTextField.Name = "planetside2PathTextField";
            this.planetside2PathTextField.ReadOnly = true;
            this.planetside2PathTextField.Size = new System.Drawing.Size(222, 20);
            this.planetside2PathTextField.TabIndex = 4;
            this.planetside2PathTextField.Text = "Path to PlanetSide folder";
            this.planetside2PathTextField.Click += new System.EventHandler(this.button1_Click);
            // 
            // launchMessage
            // 
            this.launchMessage.ForeColor = System.Drawing.Color.Red;
            this.launchMessage.Location = new System.Drawing.Point(8, 93);
            this.launchMessage.Name = "launchMessage";
            this.launchMessage.Size = new System.Drawing.Size(247, 27);
            this.launchMessage.TabIndex = 22;
            this.launchMessage.Text = "label1";
            this.launchMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.launchMessage.Visible = false;
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
            this.ps_consoleOutput.Size = new System.Drawing.Size(584, 357);
            this.ps_consoleOutput.TabIndex = 1;
            this.ps_consoleOutput.WordWrap = false;
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
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
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
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(584, 486);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(584, 510);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // LauncherForm
            // 
            this.AcceptButton = this.launchGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 510);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "LauncherForm";
            this.Text = "Planetside 1 Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.LauncherForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.LauncherForm_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog findPTRDirDialogue;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox loggingCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox launchArgs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button launchGame;
        private System.Windows.Forms.Button selectDirectory;
        private System.Windows.Forms.TextBox planetside2PathTextField;
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
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}

