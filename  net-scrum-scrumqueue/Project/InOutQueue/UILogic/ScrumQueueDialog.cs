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
    public partial class ScrumQueueDialog : Form
    {
        public enum ScrumQueueDialogType
        {
            OK,
            YesNo,
        }

        private bool isYes;
        public bool IsYes
        {
            get { return isYes; }
            set { isYes = value; }
        }

        private ScrumQueueDialogType dialogtype;
        public ScrumQueueDialogType Dialogtype
        {
            get { return dialogtype; }
            set { dialogtype = value; }
        }

        public ScrumQueueDialog()
        {
            InitializeComponent();
            this.Dialogtype = ScrumQueueDialogType.OK;
            this.init(Dialogtype, -1, -1);
        }

        public ScrumQueueDialog(string message, string detailedMessage,ScrumQueueDialogType Dialogtype )
        {
            // UI init
            InitializeComponent();
            // set the dialog type
            this.Dialogtype = Dialogtype;
            // set the message
            this.label_LabelMessage.Text = message;
            // set the detailed message in textbpx
            this.textBox_Message.Text = detailedMessage;
            // make sure cursor is at the start
            this.textBox_Message.SelectionStart = 0;
            // contiue UI set up based on input
            this.init(Dialogtype, -1, -1);
        }

        public ScrumQueueDialog(string message, string detailedMessage, ScrumQueueDialogType Dialogtype, int XLocation, int YLocation)
        {
            // UI init
            InitializeComponent();
            // set the dialog type
            this.Dialogtype = Dialogtype;
            // set the message
            this.label_LabelMessage.Text = message;
            // set the detailed message in textbpx
            this.textBox_Message.Text = detailedMessage;
            // make sure cursor is at the start
            this.textBox_Message.SelectionStart = 0;
            // contiue UI set up based on input
            this.init(Dialogtype,  XLocation,  YLocation);
        }

        private void init(ScrumQueueDialogType Dialogtype, int XLocation, int YLocation)
        {
            // set the dialog type
            if (Dialogtype == ScrumQueueDialogType.OK)
            {
                this.button_Yes.Visible = false;
                this.button_No.Text = "OK";
                this.Size = new Size(385, 150);
            }                
        }

        private void button_Yes_Click(object sender, EventArgs e)
        {
            if (this.dialogtype == ScrumQueueDialogType.YesNo)
                this.IsYes = true;
            this.closeDialog();
        }

        private void button_No_Click(object sender, EventArgs e)
        {
            if (this.dialogtype == ScrumQueueDialogType.YesNo)
                this.IsYes = false;
            else if (this.dialogtype == ScrumQueueDialogType.OK)
                this.isYes = true;
            this.closeDialog();
        }

        private void closeDialog()
        {
            this.Close();
        }
        
	
    }
}