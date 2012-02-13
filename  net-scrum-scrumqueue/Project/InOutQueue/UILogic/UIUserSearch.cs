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
    public partial class UIUserSearch : Form
    {
        public UIUserSearch()
        {
            InitializeComponent();

            this.LoadData();
        }

        private void LoadData()
        {
            ScrumQueueLoading lg = new ScrumQueueLoading();
            lg.Show();
            this.listBox_Users.DataSource = BussinessLogic.Users.GetAllUsers();
            lg.Close();
        }

        private void OpenUser()
        {
            UIUser u = new UIUser((BussinessLogic.Users)this.listBox_Users.SelectedItem);
            u.Show();
            this.Close();
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            this.OpenUser();
        }

        private void listBox_Users_DoubleClick(object sender, EventArgs e)
        {
            this.OpenUser();
        }
    }
}
