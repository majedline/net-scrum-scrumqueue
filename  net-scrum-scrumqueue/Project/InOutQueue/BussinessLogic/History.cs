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
using System.Linq;
using System.Text;

namespace ScrumQueue.BussinessLogic
{
    public class History : BussinessLogicBase
    {

        public int HistoryID { get; set; }
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime EditDate { get; set; }
        public string Editedby { get; set; }
        public string Status { get; set; }
        public string HistoryType { get; set; }


        public History() { HistoryID = -1; }

        public History(int hid, int iid, string title, string note, DateTime editedDate, string editedby, string status, string historyType)
        {
            this.HistoryID = hid;
            this.ItemID = iid;
            this.Title = title;
            this.Note = note;
            this.EditDate = editedDate;
            this.Editedby = editedby;
            this.Status = status;
            this.HistoryType = historyType;
        }

        public static void Insert(Item item, int HistoryTypeID)
        {
            
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();

            System.Data.SqlClient.SqlDataReader reader = dba.execSP("InsertHistory",
                    new string[] { "@ItemID", "@HistoryTypeID" },
                    new string[] { item.ItemID.ToString(), HistoryTypeID.ToString()});
            
            reader.Read();
  
            dba.CloseConn();
        }
        public static List<History> GetHistoryOfItem(Item item)
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();


            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetHistoryBasedOnItemID",
                    new string[] { "@ItemID" },
                    new string[] { item.ItemID.ToString() });

            

            List<History> l = new List<History>(20);
            while (reader.Read())
            {
                //HistoryID, ItemID, Title, Note, CreateDate, U1.username 'CreatedBy', EditDate, U2.username 'EditedBy', ST.Name 'Status', HistoryType
                int hid = int.Parse(reader["HistoryID"].ToString());
                string title = reader["Title"].ToString();
                string note = reader["Note"].ToString();
                DateTime editDate = DateTime.Parse(reader["EditDate"].ToString());
                string editedUser = reader["EditedBy"].ToString();
                string status = reader["Status"].ToString();
                string historyType = reader["HistoryType"].ToString();

                History h = new History(hid, item.ItemID, title, note, editDate, editedUser, status, historyType);

                l.Add(h);
            }

            dba.CloseConn();
            return l;
        }

        public override string ToString()
        {
            string edates = "(Edited by " + this.Editedby + " on " + this.EditDate.ToString() + ") ";
            string body = (" "+this.HistoryType+" \""+ this.Title+ "\" with status "+this.Status+": \'" + this.Note)+"\' ";
            return body  + edates;

        }


    }
}
