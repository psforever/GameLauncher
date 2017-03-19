namespace PSLauncher
{
    partial class ServerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerList));
            this.serverDisplay = new System.Windows.Forms.ListBox();
            this.moveUp = new System.Windows.Forms.Button();
            this.moveDown = new System.Windows.Forms.Button();
            this.hostnameInput = new System.Windows.Forms.TextBox();
            this.portInput = new System.Windows.Forms.TextBox();
            this.deleteItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.serverNameInput = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverDisplay
            // 
            this.serverDisplay.FormattingEnabled = true;
            this.serverDisplay.Location = new System.Drawing.Point(13, 13);
            this.serverDisplay.Name = "serverDisplay";
            this.serverDisplay.Size = new System.Drawing.Size(272, 108);
            this.serverDisplay.TabIndex = 0;
            this.serverDisplay.SelectedIndexChanged += new System.EventHandler(this.serverDisplay_SelectedIndexChanged);
            // 
            // moveUp
            // 
            this.moveUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.moveUp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moveUp.Enabled = false;
            this.moveUp.Image = ((System.Drawing.Image)(resources.GetObject("moveUp.Image")));
            this.moveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.moveUp.Location = new System.Drawing.Point(291, 13);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(24, 26);
            this.moveUp.TabIndex = 1;
            this.moveUp.UseVisualStyleBackColor = false;
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.moveDown.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moveDown.Enabled = false;
            this.moveDown.Image = ((System.Drawing.Image)(resources.GetObject("moveDown.Image")));
            this.moveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.moveDown.Location = new System.Drawing.Point(291, 44);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(24, 26);
            this.moveDown.TabIndex = 2;
            this.moveDown.UseVisualStyleBackColor = false;
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // hostnameInput
            // 
            this.hostnameInput.Location = new System.Drawing.Point(11, 207);
            this.hostnameInput.Name = "hostnameInput";
            this.hostnameInput.Size = new System.Drawing.Size(144, 20);
            this.hostnameInput.TabIndex = 3;
            this.hostnameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInput_KeyPress);
            // 
            // portInput
            // 
            this.portInput.Location = new System.Drawing.Point(168, 207);
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(50, 20);
            this.portInput.TabIndex = 4;
            this.portInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portInput_KeyPress);
            // 
            // deleteItem
            // 
            this.deleteItem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.deleteItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteItem.Enabled = false;
            this.deleteItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteItem.Image")));
            this.deleteItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteItem.Location = new System.Drawing.Point(291, 95);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(24, 26);
            this.deleteItem.TabIndex = 5;
            this.deleteItem.UseVisualStyleBackColor = false;
            this.deleteItem.Click += new System.EventHandler(this.deleteItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hostname/IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(230, 205);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(42, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ":";
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.Location = new System.Drawing.Point(93, 239);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(62, 23);
            this.okButton.TabIndex = 28;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Server Name";
            // 
            // serverNameInput
            // 
            this.serverNameInput.Location = new System.Drawing.Point(12, 153);
            this.serverNameInput.Name = "serverNameInput";
            this.serverNameInput.Size = new System.Drawing.Size(206, 20);
            this.serverNameInput.TabIndex = 29;
            this.serverNameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInput_KeyPress);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.Location = new System.Drawing.Point(173, 239);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(62, 23);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ServerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 274);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverNameInput);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteItem);
            this.Controls.Add(this.portInput);
            this.Controls.Add(this.hostnameInput);
            this.Controls.Add(this.moveDown);
            this.Controls.Add(this.moveUp);
            this.Controls.Add(this.serverDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerList";
            this.Text = "Server List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox serverDisplay;
        private System.Windows.Forms.Button moveUp;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.TextBox hostnameInput;
        private System.Windows.Forms.TextBox portInput;
        private System.Windows.Forms.Button deleteItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverNameInput;
        private System.Windows.Forms.Button cancelButton;
    }
}