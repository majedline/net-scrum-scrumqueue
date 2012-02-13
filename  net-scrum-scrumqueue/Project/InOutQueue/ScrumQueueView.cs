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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ScrumQueue.UILogic;

namespace ScrumQueue
{
    public partial class ScrumQueueView : Form
    {
        public ScrumQueueView()
        {
            InitializeComponent();
            init();
        
        }

        public BussinessLogic.Project OpenedProject;
       
        public BussinessLogic.Login UserInfo;
        
        public List<BussinessLogic.Item> ItemList1;

        private int CurrentSelectedIndex = 0;

        // this will initialize the UI to do 1st user action
        private void init()
        {
            try
            {

                this.OpenProject();

                if (OpenedProject != null)
                {
                    // we have a project selected, so display the item area
                    this.UIOpenProject();

                    // Get the status filter list
                    List<BussinessLogic.StatusType> statusList1 = BussinessLogic.StatusType.GetAllStatusTypes();
                    // Add the last row to the Status list; -1 = ALL
                    statusList1.Add(new ScrumQueue.BussinessLogic.StatusType(-1, "All", "Get all Items Based on Status"));
                    // Set the status list into the combobox
                    this.comboBox_Filter.DataSource = statusList1;
                    // Set the application name and show the project opened within the name
                    this.Text = IOQMessages.ApplicationName + " - " + this.OpenedProject.ProjectName;
                    // initialize the item with IDs for saving purposes
                    this.item1.Init(this.OpenedProject.ProjectID, this.UserInfo.User.UserID, BussinessLogic.StatusType.GetAllStatusTypes(), this);

                    this.dataGridView_Items.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //this.dataGridView_Items.RowsDefaultCellStyle.BackColor = Color.SeaShell;
                    this.dataGridView_Items.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;


                }
                if (this.OpenedProject == null)
                {
                    // no project is open, so display the bare minimum
                    this.UICloseProject();
                }

                this.SetAdminView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been encountered: "+ ex.ToString());
            }
        }

        private void SetAdminView()
        {
            if (this.UserInfo != null)
            {
                if (this.UserInfo.User != null)
                {
                    this.addUserToolStripMenuItem.Enabled = this.UserInfo.User.IsAdmin;
                    this.editUserToolStripMenuItem.Enabled = this.UserInfo.User.IsAdmin;
                    this.addFilterTypeToolStripMenuItem.Enabled = this.UserInfo.User.IsAdmin;
                    this.editFilterToolStripMenuItem.Enabled = this.UserInfo.User.IsAdmin;
                }
            }
            
        }

        // this will display the results based on the selections
        private void SearchItemsBasedOnStatusID()
        {

            ScrumQueueLoading dg = new ScrumQueueLoading();
            dg.Show();

            int selectedStatusID = ((BussinessLogic.StatusType)this.comboBox_Filter.SelectedItem).StatusID;
            this.ItemList1 = BussinessLogic.Item.GetAllItemsBasedOnStatus(selectedStatusID, this.OpenedProject.ProjectID);
            this.dataGridView_Items.DataSource = this.ItemList1;

            this.dataGridView_Items.Columns["ItemID"].HeaderCell.Value = "ID";
            this.dataGridView_Items.Columns["CreatedDate"].HeaderCell.Value = "Created On";
            this.dataGridView_Items.Columns["CreatedByID"].Visible = false;
            this.dataGridView_Items.Columns["CreatedByName"].HeaderCell.Value = "Created By";
            this.dataGridView_Items.Columns["EditedDate"].HeaderCell.Value = "Edited On";
            this.dataGridView_Items.Columns["EditedByID"].Visible = false;
            this.dataGridView_Items.Columns["EditedByName"].HeaderCell.Value = "Edited By";
            this.dataGridView_Items.Columns["StatusID"].Visible = false;
            this.dataGridView_Items.Columns["StatusName"].HeaderCell.Value = "Status";
            this.dataGridView_Items.Columns["ProjectID"].Visible = false;
            this.dataGridView_Items.Columns["ItemID"].Width = 50;

            dg.Close();
        }

        // this will call SearchItemsBasedOnStatusID so that the result grid is populated
        private void comboBox_Filter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.SearchItemsBasedOnStatusID();

            // if the view does not contain any item to display, then set the Item1 to "new"
            this.item1.SetViewToNew();
        }

        private void dataGridView_Items_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.DisplayGrid(-1);
            if (this.dataGridView_Items != null)
            {
                if (this.dataGridView_Items.SelectedRows != null)
                {
                    if (this.dataGridView_Items.SelectedRows.Count > 0)
                    {
                        this.CurrentSelectedIndex = this.dataGridView_Items.SelectedRows[0].Index;
                    }
                }
            }
        }

        public void DisplayGrid(int focusedLocation)
        {
            // check that we have a data grid object
            if (this.dataGridView_Items != null)
            {
                // check that we have a row object
                if (this.dataGridView_Items.Rows != null)
                {
                    // check if we have any rows
                    if (this.dataGridView_Items.Rows.Count > 0)
                    {
                        this.item1.Init(this.OpenedProject.ProjectID, this.UserInfo.User.UserID, BussinessLogic.StatusType.GetAllStatusTypes(), this);
                        if (focusedLocation != -1)
                            this.dataGridView_Items.Rows[focusedLocation].Selected = true;
                        int itemIndex = int.Parse(this.dataGridView_Items[0, this.dataGridView_Items.CurrentRow.Index].Value.ToString());
                        this.item1.populateBasic(itemIndex);
                        
                        return;
                    }
                }
            }
            // there are no items so inform the user.
            MessageBox.Show(IOQMessages.DataGridDoesNotContainAnyRows);
        }

        private void linkLabel_GoSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throw new NotImplementedException();
            MessageBox.Show("go Clicked");
        }

        private void linkLabel_Open_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throw new NotImplementedException();
            System.Windows.Forms.MessageBox.Show("Grid Open Clicked");
        }

        private void LinkLabel_ResetItemList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throw new NotImplementedException();
            System.Windows.Forms.MessageBox.Show("Grid Reset clicked");
        }
        
        private void linkLabel_New_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.item1.SetViewToNew();
        }
      
        // create new project and open it
        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UILogic.UIProject p = new UIProject();
            p.ShowDialog();
            this.init();
        }

        // open existing project
        private void OpenProject()
        {
            ScrumQueueLoading dg = new ScrumQueueLoading();
            dg.Show();
            
            UILogic.UIProjectSearch p = new UIProjectSearch();
            p.Init(this);

            dg.Close();
            p.ShowDialog();
        }

        // Menu; open exitsing project
        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.init();
        }

        // Menu; New Item
        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.item1.SetViewToNew();
        }
        // Menu; Open Item
        private void itemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.DisplayGrid(-1);
        }

        // Menu Close Project
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UICloseProject();
        }

        private void UICloseProject()
        {
            this.OpenedProject = null;
            this.dataGridView_Items.DataSource = new List<object>();
            this.comboBox_Filter.DataSource = new List<object>();
            this.comboBox_Filter.Text = "";
            this.item1.Visible = false;
            this.button_New.Enabled = false;
            
        }

        private void UIOpenProject()
        {
            this.item1.Visible = true;
            this.button_New.Enabled = true;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Menu Save
        private void saveItemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isNew = this.item1.IsViewNew;
            this.item1.ClickedSave();
            
        }

        public void RefreshGrid(bool isNewItem)
        {
            if (this.OpenedProject == null)
                return;

            int initialLocation = -1;
            if (isNewItem)
                initialLocation = this.dataGridView_Items.Rows.Count;
            else if (this.dataGridView_Items.Rows.Count > 0)
            {
                if (this.dataGridView_Items.CurrentRow != null)
                    initialLocation = this.dataGridView_Items.CurrentRow.Index;
                else
                    return;
                
            }
            // get the select status
            int selectedStatusID = ((BussinessLogic.StatusType)this.comboBox_Filter.SelectedItem).StatusID;
            
            // get the item list based on status
            this.ItemList1= BussinessLogic.Item.GetAllItemsBasedOnStatus(selectedStatusID, this.OpenedProject.ProjectID);

            // Set the grid with the list
            this.dataGridView_Items.DataSource = this.ItemList1;

            if (this.dataGridView_Items != null)
            {
                if (this.dataGridView_Items.SelectedRows != null)
                {
                    if (this.dataGridView_Items.SelectedRows.Count > 0)
                    {
                        this.dataGridView_Items[0, this.CurrentSelectedIndex].Selected = true;
                        dataGridView_Items_CellEnter(null, null);
                        this.filterResultSetBasedOnTextEntered();
                        
                    }
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            this.item1.SetViewToNew();
        }

        private void filterResultSetBasedOnTextEntered()
        {
            ScrumQueueLoading ld = new ScrumQueueLoading();
            ld.Show();
            int rcount = this.dataGridView_Items.Rows.Count;
            int ccount = this.dataGridView_Items.Columns.Count;

            for (int j = 0; j < rcount; j++)
            {
                for (int i = 0; i < ccount; i++)
                {
                    string gridString = this.dataGridView_Items[i, j].Value.ToString().ToLower();
                    string enteredString = this.textBox_KeyWords.Text.ToLower();

                    if (gridString.Contains(enteredString)
                        && enteredString.Trim().Length > 0)
                    {
                        this.dataGridView_Items.CurrentCell = null;
                        this.dataGridView_Items.Rows[j].Visible = true;
                        break;
                    }
                    else if (!(gridString.Contains(enteredString))
                        && enteredString.Trim().Length > 0)
                    {
                        this.dataGridView_Items.CurrentCell = null;
                        this.dataGridView_Items.Rows[j].Visible = false;
                    }
                    else
                    {
                        this.dataGridView_Items.CurrentCell = null;
                        this.dataGridView_Items.Rows[j].Visible = true;
                    }
                }
            }
            ld.Close();
        }

        private void yourRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScrumQueueDialog dg = new ScrumQueueDialog(IOQMessages.AboutYourRights, IOQMessages.yourRights1, ScrumQueueDialog.ScrumQueueDialogType.OK);
            dg.Size = new System.Drawing.Size(600, 300);
            dg.ShowDialog();

        }

        private void contactMeForHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(IOQMessages.emailHelp);
            }

            catch
            {
                new ScrumQueueDialog(IOQMessages.emailMeMessage, IOQMessages.YourEmailDefaultDoesNotwork, ScrumQueueDialog.ScrumQueueDialogType.OK).ShowDialog();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIUser user = new UIUser();
            user.ShowDialog();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIUserSearch us = new UIUserSearch();
            us.Show();
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            this.filterResultSetBasedOnTextEntered();
        }

        private void textBox_KeyWords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.filterResultSetBasedOnTextEntered();
            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIProjectStats st = new UIProjectStats(this.OpenedProject.ProjectID);
            st.Show();
        }

        private void gNUGENERALPUBLICLICENSEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ScrumQueueDialog dg = new ScrumQueueDialog(IOQMessages.GNUTextTitle, IOQMessages.GNUText, ScrumQueueDialog.ScrumQueueDialogType.OK);
            dg.Size = new System.Drawing.Size(600, 300);
            dg.ShowDialog();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UILogic.AboutBoxScrumQueue().ShowDialog();
        }

        private void comingSoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScrumQueueDialog dg = new ScrumQueueDialog("Coming Soon", IOQMessages.ComingSoon, ScrumQueueDialog.ScrumQueueDialogType.OK);
            dg.Size = new System.Drawing.Size(600, 300);
            dg.ShowDialog();
        }

        private void myBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(IOQMessages.blogHelp);
        }

        private void addFilterTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UISystemStatus().Show();
        }

        private void editFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UISystemStatusSearch().Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            projectToolStripMenuItem1_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            projectToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            itemToolStripMenuItem_Click(sender, e);
        }


        

    }
}