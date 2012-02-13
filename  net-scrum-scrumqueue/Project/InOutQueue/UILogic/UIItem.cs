/* Copyright © 2011, 2012 Majed Atwi
 *
 *  The program is distributed under the terms of the GNU General Public License 
 *
 *  This file is part of ScrumQueue.

    ScrumQueue is a free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ScrumQueue is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ScrumQueue.  If not, see <http://www.gnu.org/licenses/>.
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ScrumQueue.BussinessLogic;

namespace ScrumQueue.UILogic
{
    
    public partial class UIItem : UserControl
    {
        public UIItem()
        {
            InitializeComponent();
            this.item = new Item();
            this.historyItems = new List<History>(20);
        }

        private int projectID;
        
        private int userID;

        private Item item;

        private List<History> historyItems;

        private List<Attachment> attachmentList;

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        private bool isViewNew;
     
        public bool IsViewNew
        {
            set { this.isViewNew = value; }
            get { return this.isViewNew; }
        }

        public ScrumQueueView ParentView;


        public void Init(int projectIDIn, int userIDIn, List<StatusType> statusListIn, ScrumQueueView view )
        {
            this.projectID = projectIDIn;
            this.userID = userIDIn;
            this.comboBox_Status.DataSource = statusListIn;
            this.ParentView = view;
            if (this.item != null)
                this.isViewNew = false;
            
        }

        public void populateBasic(int itemIndex)
        {
            this.item = ScrumQueue.BussinessLogic.Item.GetItemBasedOnIndex(itemIndex);
            this.historyItems = ScrumQueue.BussinessLogic.History.GetHistoryOfItem(this.item);

            if (item != null)
            {
                if (item.ItemID != -1)
                    this.groupBox_Item.Text = "Item: " + item.ItemID.ToString();

                if (item.Title != null)
                    this.textBox_Title.Text = item.Title;

                if (item.Note != null)
                    this.textBox_Notes.Text = item.Note;


                if (item.StatusID != -1)
                    this.comboBox_Status.SelectedIndex = item.StatusID - 1;
                
                this.LoadAttachement();
                
                this.updateBasicHistory();
                
                this.updateFullHistory();
            }
            else
                MessageBox.Show("The Item is null, it has not been retreived from the database correctly");

        }

        private void LoadAttachement()
        {
            this.attachmentList = Attachment.GetAttachments(this.item.ItemID);
            this.listBox_Attach.DataSource = attachmentList;
        }

        // precondition; item is not null
        private void updateBasicHistory()
        {
            this.linkLabel_BasicHistoryCreated.Text = "Created By: " + item.CreatedByName + " On " + item.CreatedDate.ToString();
        }

        private void updateFullHistory()
        {
            this.listBox_History.DataSource = this.historyItems;
        }

        public void SetViewToNew()
        {
            this.isViewNew = true;
            this.groupBox_Item.Text = "New";
            this.textBox_Title.Text = "";
            this.textBox_Notes.Text = "";
            if (this.comboBox_Status.Items.Count <= 0)
            {
                this.comboBox_Status.DataSource = StatusType.GetAllStatusTypes();
            }

            this.comboBox_Status.SelectedIndex = 0;

            this.historyItems = new List<History>();
            this.listBox_History.DataSource = this.historyItems;

            this.attachmentList = new List<Attachment>();
            this.listBox_Attach.DataSource = this.attachmentList;

            this.item = new Item();

        }

        private void Button_SaveItem_Click(object sender, EventArgs e)
        {
            this.ClickedSave();
        }

        public void ClickedSave()
        {
            Item item_;
            if (this.isViewNew)
            {
                // Get the values in the field           
                string title_ = this.textBox_Title.Text;
                string note_ = this.textBox_Notes.Text;
                StatusType status_ = ((StatusType)(this.comboBox_Status.SelectedItem));

                // Create the new items and set the values in the field
                item_ = new Item(-1, title_, note_, DateTime.Now, DateTime.Now, this.userID, this.userID, "", "", status_.StatusID, "", this.projectID);
            }
            else
            {
                this.item.Title = this.textBox_Title.Text;
                this.item.Note = this.textBox_Notes.Text;
                this.item.EditedByID = this.userID;
                this.item.ProjectID = this.projectID;
                this.item.StatusID = ((StatusType)(this.comboBox_Status.SelectedItem)).StatusID;
                item_ = this.item;
            }

            if (item_.Title.Trim().Length <= 0)
            {
                MessageBox.Show("Please enter a Title");
            }
            else
            {
                Item.SaveItem(item_);

                if (ParentView != null)
                {
                    this.ParentView.RefreshGrid(this.isViewNew);
                }
            }
        }
        
        private void listBox_FileAttachments_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void listBox_FileAttachments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void listBox_History_DoubleClick(object sender, EventArgs e)
        {
            if (this.historyItems == null)
                return;
            
            if (this.historyItems.Count <= 0)
                return;

            ScrumQueue.BussinessLogic.History h = ((ScrumQueue.BussinessLogic.History)this.listBox_History.SelectedItem);
            UIHistory uh = new UIHistory(h, this.historyItems, this.listBox_History.SelectedIndex);
            uh.ShowDialog();
        }

        private void groupBox_Item_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.ClickedSave();
        }

        private void button_OpenAttach_Click(object sender, EventArgs e)
        {

            if (this.Item.ItemID == -1)
            {
                MessageBox.Show(IOQMessages.saveFileBeforeAttachment);
                return;
            }
            if (this.attachmentList.Count > 0)
            {
                Attachment a = (Attachment)this.listBox_Attach.SelectedItem;
                a.OpenAttachmentInDefaultApplicationType();                
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (this.Item.ItemID == -1)
            {
                MessageBox.Show(IOQMessages.saveFileBeforeAttachment);
                return;
            }

            string[] fileList = CommonLogic.Common.BrowseFile(this.openFileDialog_Browse);

            if (fileList != null)
            {
                foreach (string x in fileList)
                {
                    ScrumQueueLoading dg = new ScrumQueueLoading();
                    dg.Show();

                    Attachment a = new Attachment(-1, this.item.ItemID, new System.IO.FileInfo(x), CommonLogic.Common.GetBytesFromFile(x));
                    List<Attachment> la = new List<Attachment>();
                    la.Add(a);
                    Attachment.SaveAttachments(la);
                    
                    dg.Close();
                }
            }

            this.LoadAttachement();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (this.Item.ItemID == -1)
            {
                MessageBox.Show(IOQMessages.saveFileBeforeAttachment);
                return;
            }
            
            Attachment a = (((Attachment)this.listBox_Attach.SelectedItem));

            DialogResult rs = MessageBox.Show("Are you sure you want to delete the file " + a.Name + " ?", 
                                              "Delete File?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (rs == DialogResult.Yes)
            {
                ScrumQueueLoading dg = new ScrumQueueLoading();
                dg.Show();
                Attachment.DeleteAttachments(a);
                dg.Close();
            }
            else
                return;

            this.LoadAttachement();
        }

        private void listBox_Attach_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_OpenAttach_Click(sender, e);
        }

    }
}
