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
    public partial class UIHistory : Form
    {
        public UIHistory()
        {
            InitializeComponent();
            this.HistoryRecord = new BussinessLogic.History();
            this.init();
            this.QueuePos = 0;
        }

        public UIHistory(ScrumQueue.BussinessLogic.History h)
        {
            InitializeComponent();
            this.HistoryRecord = h;
            this.init();
            this.QueuePos = 0;
        }

        public UIHistory(ScrumQueue.BussinessLogic.History h, List<BussinessLogic.History> HistoryItemsQueue, int PositionOfItem)
        {
            InitializeComponent();
            this.HistoryRecord = h;
            this.QueuePos = PositionOfItem;
            this.init();
            this.HistoryItems = HistoryItemsQueue;
            
        }

        private void init()
        {
            this.Text = "History Record # "+this.QueuePos+" with History ID " + this.HistoryRecord.HistoryID.ToString() + " for Item # " + this.HistoryRecord.ItemID.ToString();
            this.textBox_Title.Text = this.HistoryRecord.Title;
            this.textBox_Notes.Text = this.HistoryRecord.Note;
            this.textBox_status.Text = this.HistoryRecord.Status;
            this.textBox_dates.Text = "Edited by " + this.HistoryRecord.Editedby + " on " + this.HistoryRecord.EditDate.ToString();
        }

        private int QueuePos;

        public ScrumQueue.BussinessLogic.History HistoryRecord { get; set; }

        public List<BussinessLogic.History> HistoryItems { get; set; }

        private void button_Next_Click(object sender, EventArgs e)
        {

            this.GoNext();
        }

        private void UIHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                this.GoNext();
        }

        private void button_Next_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                this.GoNext();
        }

        private void GoNext()
        {
            this.QueuePos++;

            if (this.QueuePos % this.HistoryItems.Count == 0 && this.QueuePos != 0)
                this.QueuePos = 0;

            if (this.HistoryItems == null)
                return;
            if (this.HistoryItems.Count <= 1)
                return;

            this.HistoryRecord = this.HistoryItems[this.QueuePos];
            this.init();
            this.Refresh();
        }

        private void textBox_Title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                this.GoNext();
        }
    }
}
