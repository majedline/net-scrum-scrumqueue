namespace ScrumQueue.UILogic
{
    partial class UIProjectSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIProjectSearch));
            this.listBox_ProjectList = new System.Windows.Forms.ListBox();
            this.button_OpenProject = new System.Windows.Forms.Button();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_WarningMessage = new System.Windows.Forms.Label();
            this.checkBox_RememberMe = new System.Windows.Forms.CheckBox();
            this.textBox_display = new System.Windows.Forms.TextBox();
            this.linkLabelGNU = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // listBox_ProjectList
            // 
            this.listBox_ProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_ProjectList.BackColor = System.Drawing.Color.AliceBlue;
            this.listBox_ProjectList.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listBox_ProjectList.FormattingEnabled = true;
            this.listBox_ProjectList.Location = new System.Drawing.Point(12, 12);
            this.listBox_ProjectList.Name = "listBox_ProjectList";
            this.listBox_ProjectList.Size = new System.Drawing.Size(322, 225);
            this.listBox_ProjectList.TabIndex = 0;
            this.listBox_ProjectList.Click += new System.EventHandler(this.listBox_ProjectList_Click);
            this.listBox_ProjectList.DoubleClick += new System.EventHandler(this.listBox_ProjectList_DoubleClick);
            this.listBox_ProjectList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox_ProjectList_KeyPress);
            // 
            // button_OpenProject
            // 
            this.button_OpenProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_OpenProject.Location = new System.Drawing.Point(111, 391);
            this.button_OpenProject.Name = "button_OpenProject";
            this.button_OpenProject.Size = new System.Drawing.Size(139, 23);
            this.button_OpenProject.TabIndex = 1;
            this.button_OpenProject.Text = "Login && Open";
            this.button_OpenProject.UseVisualStyleBackColor = true;
            this.button_OpenProject.Click += new System.EventHandler(this.button_OpenProject_Click);
            // 
            // textBox_Username
            // 
            this.textBox_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Username.Location = new System.Drawing.Point(9, 302);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(330, 20);
            this.textBox_Username.TabIndex = 2;
            this.textBox_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Username_KeyDown);
            // 
            // label_username
            // 
            this.label_username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_username.AutoSize = true;
            this.label_username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_username.Location = new System.Drawing.Point(9, 286);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(55, 13);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username";
            // 
            // label_Password
            // 
            this.label_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Password.AutoSize = true;
            this.label_Password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_Password.Location = new System.Drawing.Point(9, 325);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Password.Location = new System.Drawing.Point(9, 341);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(330, 20);
            this.textBox_Password.TabIndex = 4;
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Password_KeyDown);
            // 
            // label_WarningMessage
            // 
            this.label_WarningMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_WarningMessage.AutoSize = true;
            this.label_WarningMessage.ForeColor = System.Drawing.Color.Red;
            this.label_WarningMessage.Location = new System.Drawing.Point(75, 418);
            this.label_WarningMessage.Name = "label_WarningMessage";
            this.label_WarningMessage.Size = new System.Drawing.Size(87, 13);
            this.label_WarningMessage.TabIndex = 6;
            this.label_WarningMessage.Text = "warningMessage";
            // 
            // checkBox_RememberMe
            // 
            this.checkBox_RememberMe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_RememberMe.AutoSize = true;
            this.checkBox_RememberMe.Checked = true;
            this.checkBox_RememberMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RememberMe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_RememberMe.Location = new System.Drawing.Point(111, 369);
            this.checkBox_RememberMe.Name = "checkBox_RememberMe";
            this.checkBox_RememberMe.Size = new System.Drawing.Size(139, 17);
            this.checkBox_RememberMe.TabIndex = 7;
            this.checkBox_RememberMe.Text = "Remember me next time";
            this.checkBox_RememberMe.UseVisualStyleBackColor = true;
            // 
            // textBox_display
            // 
            this.textBox_display.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_display.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_display.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_display.ForeColor = System.Drawing.Color.DarkGreen;
            this.textBox_display.Location = new System.Drawing.Point(12, 255);
            this.textBox_display.Multiline = true;
            this.textBox_display.Name = "textBox_display";
            this.textBox_display.Size = new System.Drawing.Size(335, 28);
            this.textBox_display.TabIndex = 8;
            // 
            // linkLabelGNU
            // 
            this.linkLabelGNU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelGNU.AutoSize = true;
            this.linkLabelGNU.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelGNU.Location = new System.Drawing.Point(165, 435);
            this.linkLabelGNU.Name = "linkLabelGNU";
            this.linkLabelGNU.Size = new System.Drawing.Size(23, 9);
            this.linkLabelGNU.TabIndex = 9;
            this.linkLabelGNU.TabStop = true;
            this.linkLabelGNU.Text = "GNU";
            this.linkLabelGNU.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGNU_LinkClicked);
            // 
            // UIProjectSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(346, 450);
            this.Controls.Add(this.linkLabelGNU);
            this.Controls.Add(this.textBox_display);
            this.Controls.Add(this.checkBox_RememberMe);
            this.Controls.Add(this.label_WarningMessage);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.button_OpenProject);
            this.Controls.Add(this.listBox_ProjectList);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIProjectSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScrumQueue© - Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_ProjectList;
        private System.Windows.Forms.Button button_OpenProject;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_WarningMessage;
        private System.Windows.Forms.CheckBox checkBox_RememberMe;
        private System.Windows.Forms.TextBox textBox_display;
        private System.Windows.Forms.LinkLabel linkLabelGNU;
    }
}