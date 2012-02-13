namespace ScrumQueue.UILogic
{
    partial class UISystemStatusSearch
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
            this.button_Select = new System.Windows.Forms.Button();
            this.listBox_StatusList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_Select
            // 
            this.button_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Select.Location = new System.Drawing.Point(402, 334);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(75, 23);
            this.button_Select.TabIndex = 3;
            this.button_Select.Text = "Select";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // listBox_StatusList
            // 
            this.listBox_StatusList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_StatusList.FormattingEnabled = true;
            this.listBox_StatusList.Location = new System.Drawing.Point(12, 12);
            this.listBox_StatusList.Name = "listBox_StatusList";
            this.listBox_StatusList.Size = new System.Drawing.Size(465, 316);
            this.listBox_StatusList.TabIndex = 2;
            this.listBox_StatusList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_StatusList_MouseDoubleClick);
            // 
            // UISystemStatusSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(489, 363);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.listBox_StatusList);
            this.Name = "UISystemStatusSearch";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScrumQueue© - System Status Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.ListBox listBox_StatusList;
    }
}