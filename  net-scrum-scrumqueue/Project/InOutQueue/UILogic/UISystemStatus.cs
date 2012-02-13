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
    public partial class UISystemStatus : Form
    {
        public UISystemStatus()
        {
            InitializeComponent();
        }

        public BussinessLogic.StatusType OriginalStatus = new BussinessLogic.StatusType();
        public BussinessLogic.StatusType statusType = new BussinessLogic.StatusType();

        public UISystemStatus(BussinessLogic.StatusType stType)
        {
            this.InitializeComponent();
            this.OriginalStatus = stType;
            this.statusType = stType;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            
            this.statusType.StatusName = this.textBox_StatusName.Text.Trim();
            this.statusType.StatusDescription = this.textBox_StatusDescription.Text.Trim();
            
            this.statusType.StatusID = BussinessLogic.StatusType.SaveStatusType(this.statusType);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UISystemStatus_Load(object sender, EventArgs e)
        {
            if (this.statusType != null)
            {
                this.textBox_StatusName.Text = this.statusType.StatusName;
                this.textBox_StatusDescription.Text = this.statusType.StatusDescription;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("need to implement");
        }

            

    }
}
