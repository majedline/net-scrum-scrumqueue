namespace ScrumQueue.UILogic
{
    partial class UIItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIItem));
            this.openFileDialog_Browse = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox_Item = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_History = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_Attach = new System.Windows.Forms.ListBox();
            this.button_OpenAttach = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.linkLabel_BasicHistoryCreated = new System.Windows.Forms.LinkLabel();
            this.label_Notes = new System.Windows.Forms.Label();
            this.textBox_Notes = new System.Windows.Forms.TextBox();
            this.Button_SaveItem = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.groupBox_Item.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog_Browse
            // 
            this.openFileDialog_Browse.Multiselect = true;
            // 
            // groupBox_Item
            // 
            this.groupBox_Item.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Item.Controls.Add(this.groupBox2);
            this.groupBox_Item.Controls.Add(this.groupBox1);
            this.groupBox_Item.Controls.Add(this.label_Status);
            this.groupBox_Item.Controls.Add(this.comboBox_Status);
            this.groupBox_Item.Controls.Add(this.linkLabel_BasicHistoryCreated);
            this.groupBox_Item.Controls.Add(this.label_Notes);
            this.groupBox_Item.Controls.Add(this.textBox_Notes);
            this.groupBox_Item.Controls.Add(this.Button_SaveItem);
            this.groupBox_Item.Controls.Add(this.label_Title);
            this.groupBox_Item.Controls.Add(this.textBox_Title);
            this.groupBox_Item.Location = new System.Drawing.Point(0, -1);
            this.groupBox_Item.Name = "groupBox_Item";
            this.groupBox_Item.Size = new System.Drawing.Size(622, 313);
            this.groupBox_Item.TabIndex = 3;
            this.groupBox_Item.TabStop = false;
            this.groupBox_Item.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox_Item_PreviewKeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listBox_History);
            this.groupBox2.Location = new System.Drawing.Point(51, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 107);
            this.groupBox2.TabIndex = 307;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History";
            // 
            // listBox_History
            // 
            this.listBox_History.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_History.BackColor = System.Drawing.Color.AliceBlue;
            this.listBox_History.FormattingEnabled = true;
            this.listBox_History.Location = new System.Drawing.Point(6, 19);
            this.listBox_History.Name = "listBox_History";
            this.listBox_History.Size = new System.Drawing.Size(166, 82);
            this.listBox_History.TabIndex = 3;
            this.listBox_History.DoubleClick += new System.EventHandler(this.listBox_History_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listBox_Attach);
            this.groupBox1.Controls.Add(this.button_OpenAttach);
            this.groupBox1.Controls.Add(this.button_Add);
            this.groupBox1.Controls.Add(this.button_Remove);
            this.groupBox1.Location = new System.Drawing.Point(235, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 107);
            this.groupBox1.TabIndex = 306;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attachments";
            // 
            // listBox_Attach
            // 
            this.listBox_Attach.BackColor = System.Drawing.Color.AliceBlue;
            this.listBox_Attach.FormattingEnabled = true;
            this.listBox_Attach.Location = new System.Drawing.Point(6, 19);
            this.listBox_Attach.Name = "listBox_Attach";
            this.listBox_Attach.Size = new System.Drawing.Size(339, 82);
            this.listBox_Attach.TabIndex = 301;
            this.listBox_Attach.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Attach_MouseDoubleClick);
            // 
            // button_OpenAttach
            // 
            this.button_OpenAttach.Image = ((System.Drawing.Image)(resources.GetObject("button_OpenAttach.Image")));
            this.button_OpenAttach.Location = new System.Drawing.Point(351, 19);
            this.button_OpenAttach.Name = "button_OpenAttach";
            this.button_OpenAttach.Size = new System.Drawing.Size(24, 24);
            this.button_OpenAttach.TabIndex = 305;
            this.button_OpenAttach.UseVisualStyleBackColor = true;
            this.button_OpenAttach.Click += new System.EventHandler(this.button_OpenAttach_Click);
            // 
            // button_Add
            // 
            this.button_Add.Image = ((System.Drawing.Image)(resources.GetObject("button_Add.Image")));
            this.button_Add.Location = new System.Drawing.Point(351, 49);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(24, 24);
            this.button_Add.TabIndex = 303;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Image = ((System.Drawing.Image)(resources.GetObject("button_Remove.Image")));
            this.button_Remove.Location = new System.Drawing.Point(351, 79);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(24, 24);
            this.button_Remove.TabIndex = 304;
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // label_Status
            // 
            this.label_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(186, 287);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(37, 13);
            this.label_Status.TabIndex = 27;
            this.label_Status.Text = "Status";
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Location = new System.Drawing.Point(235, 283);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(275, 21);
            this.comboBox_Status.TabIndex = 4;
            // 
            // linkLabel_BasicHistoryCreated
            // 
            this.linkLabel_BasicHistoryCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel_BasicHistoryCreated.AutoSize = true;
            this.linkLabel_BasicHistoryCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_BasicHistoryCreated.Location = new System.Drawing.Point(48, 284);
            this.linkLabel_BasicHistoryCreated.Name = "linkLabel_BasicHistoryCreated";
            this.linkLabel_BasicHistoryCreated.Size = new System.Drawing.Size(117, 15);
            this.linkLabel_BasicHistoryCreated.TabIndex = 23;
            this.linkLabel_BasicHistoryCreated.TabStop = true;
            this.linkLabel_BasicHistoryCreated.Text = "BasicHistoryCreated";
            // 
            // label_Notes
            // 
            this.label_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Notes.AutoSize = true;
            this.label_Notes.Location = new System.Drawing.Point(6, 48);
            this.label_Notes.Name = "label_Notes";
            this.label_Notes.Size = new System.Drawing.Size(35, 13);
            this.label_Notes.TabIndex = 13;
            this.label_Notes.Text = "Notes";
            // 
            // textBox_Notes
            // 
            this.textBox_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Notes.Location = new System.Drawing.Point(51, 46);
            this.textBox_Notes.Multiline = true;
            this.textBox_Notes.Name = "textBox_Notes";
            this.textBox_Notes.Size = new System.Drawing.Size(565, 118);
            this.textBox_Notes.TabIndex = 2;
            // 
            // Button_SaveItem
            // 
            this.Button_SaveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SaveItem.Location = new System.Drawing.Point(516, 281);
            this.Button_SaveItem.Name = "Button_SaveItem";
            this.Button_SaveItem.Size = new System.Drawing.Size(100, 23);
            this.Button_SaveItem.TabIndex = 5;
            this.Button_SaveItem.Text = "Save Item";
            this.Button_SaveItem.UseVisualStyleBackColor = true;
            this.Button_SaveItem.Click += new System.EventHandler(this.Button_SaveItem_Click);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(6, 22);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(27, 13);
            this.label_Title.TabIndex = 1;
            this.label_Title.Text = "Title";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Title.Location = new System.Drawing.Point(51, 20);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(565, 20);
            this.textBox_Title.TabIndex = 0;
            // 
            // UIItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_Item);
            this.Name = "UIItem";
            this.Size = new System.Drawing.Size(622, 313);
            this.groupBox_Item.ResumeLayout(false);
            this.groupBox_Item.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_Browse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox_Item;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_History;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_Attach;
        private System.Windows.Forms.Button button_OpenAttach;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.LinkLabel linkLabel_BasicHistoryCreated;
        private System.Windows.Forms.Label label_Notes;
        private System.Windows.Forms.TextBox textBox_Notes;
        private System.Windows.Forms.Button Button_SaveItem;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_Title;
    }
}
