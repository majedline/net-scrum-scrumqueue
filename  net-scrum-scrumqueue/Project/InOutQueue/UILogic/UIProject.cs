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
    public partial class UIProject : Form
    {
        public UIProject()
        {
            InitializeComponent();
        }

        private BussinessLogic.Project createdProject;

        public BussinessLogic.Project CreatedProject
        {
            get { return createdProject; }
        }
	
        private void button_Save_Click(object sender, EventArgs e)
        {
            if (this.textBox_Name.Text.Equals(IOQMessages.ProjectNameIsMandetory))
                this.textBox_Name.Text = "";

            if (this.textBox_Name.Text.Trim().Length == 0)
            {
                this.textBox_Name.BackColor = Color.Red;
                this.textBox_Name.Text = IOQMessages.ProjectNameIsMandetory;
            }
            else
            {
                String name = this.textBox_Name.Text;
                String desc = this.textBox_description.Text;
                BussinessLogic.Project pp = new ScrumQueue.BussinessLogic.Project(-1, name, desc);
                int id = BussinessLogic.Project.SaveProject(pp);
                this.createdProject = new ScrumQueue.BussinessLogic.Project(id, name, desc);
                this.Close();
            }
        }

        private void textBox_Name_Enter(object sender, EventArgs e)
        {
            this.textBox_Name.Text = "";
        }
    }
}