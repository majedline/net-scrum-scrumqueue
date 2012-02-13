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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScrumQueue.UILogic
{
    public partial class UIUser : Form
    {
        public UIUser()
        {
            InitializeComponent();
        }

        public UIUser(BussinessLogic.Users user)
        {
            InitializeComponent();
            this.user = user;
            this.originalUser = user;
        }

        public BussinessLogic.Users originalUser = new BussinessLogic.Users();
        public BussinessLogic.Users user = new BussinessLogic.Users();

        private void button_Save_Click(object sender, EventArgs e)
        {

            this.user.FirstName = this.textBox_firstName.Text.Trim();
            this.user.LastName = this.textBox_LastName.Text.Trim();
            this.user.Username = this.textBox_UserName.Text.Trim();
            this.user.Password = this.textBox_Password.Text.Trim();
            this.user.IsAdmin = this.checkBox_isAdmin.Checked;

            int userIDExist = BussinessLogic.Users.isUsernameAvailable(this.user);

            if (userIDExist >= 0)
            {
                ScrumQueueDialog dg = new ScrumQueueDialog("Username already exist", "The username already exists in the database. Please enter a new username", ScrumQueueDialog.ScrumQueueDialogType.OK);
                dg.ShowDialog();
                return;
            }
            else
            {
                BussinessLogic.Users.SaveUsers(this.user);
                this.Close();
            }   
        }

        private void UIUser_Load(object sender, EventArgs e)
        {
            if (this.user != null)
            {
                this.textBox_firstName.Text = this.user.FirstName;
                this.textBox_LastName.Text = this.user.LastName;
                this.textBox_UserName.Text = this.user.Username;
                this.textBox_Password.Text = this.user.Password;
                this.checkBox_isAdmin.Checked = this.user.IsAdmin;
            }                
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}
