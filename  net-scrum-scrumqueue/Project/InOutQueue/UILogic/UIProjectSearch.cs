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

namespace ScrumQueue.UILogic
{
    public partial class UIProjectSearch : Form
    {
        public UIProjectSearch()
        {
            InitializeComponent();
            this.label_WarningMessage.Visible = false;
        }

        private BussinessLogic.Project selectedProject;
      
        public BussinessLogic.Project SelectedProject
        {
            get { return selectedProject; }
        }

        private BussinessLogic.Login userInfo;

        public BussinessLogic.Login UserInfo
        {
            get { return userInfo; }
            set { userInfo = value; }
        }
	

        private ScrumQueue.ScrumQueueView MainForm;

        public void Init(ScrumQueue.ScrumQueueView mainForm)
        {
            List<BussinessLogic.Project> projectList = BussinessLogic.Project.GetAllProjects();
            this.listBox_ProjectList.DataSource = projectList;
            this.listBox_ProjectList.Refresh();
            this.MainForm = mainForm;
            
            this.LoadRememberedUser();

            this.textBox_Username.Text = this.UserInfo.User.Username;
            this.textBox_Password.Text = this.userInfo.User.Password;

        }

        private void button_OpenProject_Click(object sender, EventArgs e)
        {
            
            OpenSelectedProject();

            if (this.checkBox_RememberMe.Checked)
            {
                this.UserInfo.User.Password = this.textBox_Password.Text;
                this.RememberUser();
            }
            else
            {
                this.UserInfo.User.ForgetMe();
            }

        }
   
        private void listBox_ProjectList_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.button_OpenProject_Click(sender, null);
        }

        private void OpenSelectedProject()
        {
            if (LoginAllowed())
            {
                this.selectedProject = ((BussinessLogic.Project)(this.listBox_ProjectList.SelectedItem));
                this.MainForm.OpenedProject = this.selectedProject;
                this.MainForm.UserInfo = this.userInfo;
                this.Close();
            }
            else
            {
                this.HandleInValidLogin();
            }
        }

        private void listBox_ProjectList_DoubleClick(object sender, EventArgs e)
        {
            this.OpenSelectedProject();
        }

        private void InitLoginSection()
        {
            this.label_WarningMessage.Visible = false;
        }
        
        private bool LoginAllowed()
        {
            if (this.textBox_Username.Text.Trim().Length == 0 || this.textBox_Password.Text.Trim().Length == 0)
            {
                return false;
            }
            else
            {
                BussinessLogic.Login login = new BussinessLogic.Login(this.textBox_Username.Text, this.textBox_Password.Text);
                bool isAllowed = login.IsAllowed();
                if (isAllowed)
                    this.userInfo = login;
                return isAllowed;
            }
        }
       
        private void HandleInValidLogin()
        {
            this.label_WarningMessage.Visible = true;
            if (this.textBox_Username.Text.Trim().Length == 0 || this.textBox_Password.Text.Trim().Length == 0)
            {
                this.label_WarningMessage.Text = IOQMessages.UsernamePasswordIsMandetory;
                return;
            }

            this.label_WarningMessage.Text = IOQMessages.UsernamePasswordIsNotValid;
            return;
        }

        private void RememberUser()
        {
            this.UserInfo.User.RememberMe();
        }
        private void LoadRememberedUser()
        {
            this.UserInfo = new BussinessLogic.Login("", "");
            this.UserInfo.User = new BussinessLogic.Users();
            this.UserInfo.User.LoadRememberMe();
        }

        private void textBox_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.button_OpenProject_Click(sender, null);
        }

        private void textBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.button_OpenProject_Click(sender, null);
        }

        private void listBox_ProjectList_Click(object sender, EventArgs e)
        {
            string x = this.listBox_ProjectList.SelectedItem.ToString();
            if (x != null)
                this.textBox_display.Text = x;
        }

        private void linkLabelGNU_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ScrumQueueDialog dg = new ScrumQueueDialog(IOQMessages.GNUTextTitle, IOQMessages.GNUText, ScrumQueueDialog.ScrumQueueDialogType.OK);
            dg.Size = new System.Drawing.Size(600, 300);
            dg.ShowDialog();
        }

    }
}