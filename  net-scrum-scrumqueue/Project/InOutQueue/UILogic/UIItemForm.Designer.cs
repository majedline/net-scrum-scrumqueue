namespace InOutQueue.UILogic
{
    partial class UIItemForm
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
            this.uiItem1 = new UIItem(this);
            this.SuspendLayout();
            // 
            // uiItem1
            // 
            this.uiItem1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiItem1.Location = new System.Drawing.Point(12, 12);
            this.uiItem1.Name = "uiItem1";
            this.uiItem1.Size = new System.Drawing.Size(563, 313);
            this.uiItem1.TabIndex = 0;
            // 
            // UIItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 338);
            this.Controls.Add(this.uiItem1);
            this.Name = "UIItemForm";
            this.Text = "InOutQueue™";
            this.ResumeLayout(false);

        }

        #endregion

        private UIItem uiItem1;
    }
}