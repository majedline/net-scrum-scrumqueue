namespace ScrumQueue.UILogic
{
    partial class UIHistory
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
            this.label_Notes = new System.Windows.Forms.Label();
            this.textBox_Notes = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_dates = new System.Windows.Forms.TextBox();
            this.Dates = new System.Windows.Forms.Label();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.button_Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Notes
            // 
            this.label_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Notes.AutoSize = true;
            this.label_Notes.Location = new System.Drawing.Point(4, 35);
            this.label_Notes.Name = "label_Notes";
            this.label_Notes.Size = new System.Drawing.Size(35, 13);
            this.label_Notes.TabIndex = 20;
            this.label_Notes.Text = "Notes";
            // 
            // textBox_Notes
            // 
            this.textBox_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Notes.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Notes.Location = new System.Drawing.Point(43, 32);
            this.textBox_Notes.Multiline = true;
            this.textBox_Notes.Name = "textBox_Notes";
            this.textBox_Notes.ReadOnly = true;
            this.textBox_Notes.Size = new System.Drawing.Size(546, 202);
            this.textBox_Notes.TabIndex = 19;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(10, 8);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(27, 13);
            this.label_Title.TabIndex = 18;
            this.label_Title.Text = "Title";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Title.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Title.Location = new System.Drawing.Point(43, 6);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.ReadOnly = true;
            this.textBox_Title.Size = new System.Drawing.Size(413, 20);
            this.textBox_Title.TabIndex = 17;
            this.textBox_Title.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Title_KeyDown);
            // 
            // textBox_dates
            // 
            this.textBox_dates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_dates.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_dates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_dates.Location = new System.Drawing.Point(43, 240);
            this.textBox_dates.Multiline = true;
            this.textBox_dates.Name = "textBox_dates";
            this.textBox_dates.ReadOnly = true;
            this.textBox_dates.Size = new System.Drawing.Size(546, 36);
            this.textBox_dates.TabIndex = 21;
            // 
            // Dates
            // 
            this.Dates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Dates.AutoSize = true;
            this.Dates.Location = new System.Drawing.Point(2, 243);
            this.Dates.Name = "Dates";
            this.Dates.Size = new System.Drawing.Size(35, 13);
            this.Dates.TabIndex = 22;
            this.Dates.Text = "Dates";
            // 
            // textBox_status
            // 
            this.textBox_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_status.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_status.Location = new System.Drawing.Point(462, 6);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ReadOnly = true;
            this.textBox_status.Size = new System.Drawing.Size(130, 20);
            this.textBox_status.TabIndex = 23;
            // 
            // button_Next
            // 
            this.button_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Next.Location = new System.Drawing.Point(462, 282);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(130, 23);
            this.button_Next.TabIndex = 24;
            this.button_Next.Text = "Next =>";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            this.button_Next.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_Next_KeyDown);
            // 
            // UIHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(604, 317);
            this.Controls.Add(this.button_Next);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.Dates);
            this.Controls.Add(this.textBox_dates);
            this.Controls.Add(this.label_Notes);
            this.Controls.Add(this.textBox_Notes);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.textBox_Title);
            this.Name = "UIHistory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UIHistory";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIHistory_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Notes;
        private System.Windows.Forms.TextBox textBox_Notes;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox_dates;
        private System.Windows.Forms.Label Dates;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_Next;
    }
}