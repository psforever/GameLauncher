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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.serverSelection = new System.Windows.Forms.ComboBox();
            this.hideShowOutput = new System.Windows.Forms.Button();
            this.skipLauncher = new System.Windows.Forms.CheckBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.launchGame = new System.Windows.Forms.Button();
            this.launchMessage = new System.Windows.Forms.Label();
            this.spinner = new System.Windows.Forms.PictureBox();
            this.ps_consoleOutput = new System.Windows.Forms.TextBox();
            this.outputRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.copy = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinner)).BeginInit();
            this.outputRightClick.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.serverSelection);
            this.splitContainer1.Panel1.Controls.Add(this.hideShowOutput);
            this.splitContainer1.Panel1.Controls.Add(this.skipLauncher);
            this.splitContainer1.Panel1.Controls.Add(this.passwordLabel);
            this.splitContainer1.Panel1.Controls.Add(this.usernameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.password);
            this.splitContainer1.Panel1.Controls.Add(this.username);
            this.splitContainer1.Panel1.Controls.Add(this.launchGame);
            this.splitContainer1.Panel1.Controls.Add(this.launchMessage);
            this.splitContainer1.Panel1.Controls.Add(this.spinner);
            this.splitContainer1.Panel1MinSize = 95;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ps_consoleOutput);
            this.splitContainer1.Size = new System.Drawing.Size(444, 287);
            this.splitContainer1.SplitterDistance = this.splitContainer1.Panel1MinSize;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Server";
            // 
            // serverSelection
            // 
            this.serverSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverSelection.FormattingEnabled = true;
            this.serverSelection.Location = new System.Drawing.Point(246, 10);
            this.serverSelection.Name = "serverSelection";
            this.serverSelection.Size = new System.Drawing.Size(195, 21);
            this.serverSelection.TabIndex = 3;
            this.serverSelection.SelectedIndexChanged += new System.EventHandler(this.serverSelection_SelectedIndexChanged);
            // 
            // hideShowOutput
            // 
            this.hideShowOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hideShowOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideShowOutput.Location = new System.Drawing.Point(357, 69);
            this.hideShowOutput.Name = "hideShowOutput";
            this.hideShowOutput.Size = new System.Drawing.Size(84, 21);
            this.hideShowOutput.TabIndex = 5;
            this.hideShowOutput.Text = "vv Show vv";
            this.hideShowOutput.UseVisualStyleBackColor = true;
            this.hideShowOutput.Click += new System.EventHandler(this.hideShowOutput_Click_1);
            // 
            // skipLauncher
            // 
            this.skipLauncher.AutoSize = true;
            this.skipLauncher.Location = new System.Drawing.Point(205, 71);
            this.skipLauncher.Name = "skipLauncher";
            this.skipLauncher.Size = new System.Drawing.Size(95, 17);
            this.skipLauncher.TabIndex = 4;
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
            this.launchGame.Click += new System.EventHandler(this.launchGame_Click);
            // 
            // launchMessage
            // 
            this.launchMessage.ForeColor = System.Drawing.Color.Red;
            this.launchMessage.Location = new System.Drawing.Point(202, 37);
            this.launchMessage.Name = "launchMessage";
            this.launchMessage.Size = new System.Drawing.Size(197, 27);
            this.launchMessage.TabIndex = 22;
            this.launchMessage.Text = "Error message";
            this.launchMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launchMessage.Visible = false;
            // 
            // spinner
            // 
            this.spinner.Enabled = false;
            this.spinner.Image = ((System.Drawing.Image)(resources.GetObject("spinner.Image")));
            this.spinner.Location = new System.Drawing.Point(22, 66);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(26, 24);
            this.spinner.TabIndex = 24;
            this.spinner.TabStop = false;
            this.spinner.Visible = false;
            // 
            // ps_consoleOutput
            // 
            this.ps_consoleOutput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ps_consoleOutput.ContextMenuStrip = this.outputRightClick;
            this.ps_consoleOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ps_consoleOutput.Location = new System.Drawing.Point(0, 0);
            this.ps_consoleOutput.Multiline = true;
            this.ps_consoleOutput.Name = "ps_consoleOutput";
            this.ps_consoleOutput.ReadOnly = true;
            this.ps_consoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ps_consoleOutput.Size = new System.Drawing.Size(444, 188);
            this.ps_consoleOutput.TabIndex = 0;
            this.ps_consoleOutput.WordWrap = false;
            // 
            // outputRightClick
            // 
            this.outputRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAll,
            this.copy,
            this.saveToFile});
            this.outputRightClick.Name = "outputRightClick";
            this.outputRightClick.Size = new System.Drawing.Size(167, 70);
            // 
            // selectAll
            // 
            this.selectAll.Name = "selectAll";
            this.selectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAll.Size = new System.Drawing.Size(166, 22);
            this.selectAll.Text = "Select All";
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // copy
            // 
            this.copy.Name = "copy";
            this.copy.ShortcutKeyDisplayString = "";
            this.copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copy.Size = new System.Drawing.Size(166, 22);
            this.copy.Text = "Copy";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // saveToFile
            // 
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(166, 22);
            this.saveToFile.Text = "Save to file ...";
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
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
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(444, 287);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(444, 311);
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
            this.ClientSize = new System.Drawing.Size(444, 311);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(420, 350);
            this.Name = "LauncherForm";
            this.Text = "PSForever Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LauncherForm_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.LauncherForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.LauncherForm_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinner)).EndInit();
            this.outputRightClick.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button launchGame;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox ps_consoleOutput;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label launchMessage;
        private System.Windows.Forms.CheckBox skipLauncher;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button hideShowOutput;
        private System.Windows.Forms.PictureBox spinner;
        private System.Windows.Forms.ContextMenuStrip outputRightClick;
        private System.Windows.Forms.ToolStripMenuItem selectAll;
        private System.Windows.Forms.ToolStripMenuItem copy;
        private System.Windows.Forms.ToolStripMenuItem saveToFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serverSelection;
    }
}

