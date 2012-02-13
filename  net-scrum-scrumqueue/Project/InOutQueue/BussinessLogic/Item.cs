
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
using System.Text;

namespace ScrumQueue.BussinessLogic
{
    public class Item : BussinessLogic.BussinessLogicBase
    {
        /*
            ItemID	    int	            Unchecked
            Title	    varchar(200)	Checked
            Note	    varchar(200)	Checked
            CreateDate	datetime	    Unchecked
            CreatedBy	int	            Unchecked
            EditDate	datetime	    Unchecked
            EditedBy	int	            Unchecked
            StatusID	int	            Unchecked
         */
        private int itemID;
        public int ItemID
        {
            get { return itemID; }
            set { this.itemID = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        private DateTime createdDate;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            
        }

        private int createdByID;
        public int CreatedByID
        {
            get { return this.createdByID; }
        }

        private string createdByName;
        public string CreatedByName
        {
            get { return createdByName; }   
        }

        private DateTime editedDate;
        public DateTime EditedDate
        {
            get { return editedDate; }
            
        }
        
        private int editedByID;
        public int EditedByID
        {
            get { return this.editedByID; }
            set { this.editedByID = value; }
        }

        private string  editedByName;
        public string  EditedByName
        {
            get { return editedByName; }
            
        }
        
        private int statusID;
        public int StatusID
        {
            get
            {
                return this.statusID;
            }
            set
            {
                this.statusID = value;
            }
        }

        private string statusName;
        public string StatusName
        {
            get { return statusName; }

        }

        private int projectID;
        public int ProjectID
        {
            get { return this.projectID; }
            set { this.projectID = value; }
        }

        public List<Attachment> AttachmentList { get; set; }

        //// itemID, title, note, createdDate, editedDate, createdID, createdName, EditedByID, EditedByName, statusID, statusName
        public Item(int id, string title, string note, DateTime created, DateTime edited, int editedBy, int createdBy, string editedByName, string createdByName, int statusID, string statusName, int projectIDin)
        {
            
            this.itemID = id;// ok
            this.title = title;// ok
            this.note = note;//ok
            this.createdDate = created;
            this.editedDate = edited;
            this.createdByID = createdBy;
            this.createdByName = createdByName;
            this.editedByID = editedBy;
            this.editedByName = editedByName;
            this.statusID = statusID;
            this.statusName = statusName;
            this.projectID = projectIDin;
        }

        public Item(int id, string title, string note,DateTime created, DateTime edited,int editedBy, int createdBy,string editedByName, string createdByName,int statusID, string statusName)
        {

            this.itemID = id;// ok
            this.title = title;// ok
            this.note = note;//ok
            this.createdDate = created;
            this.editedDate = edited;
            this.createdByID = createdBy;
            this.createdByName = createdByName;
            this.editedByID = editedBy;
            this.editedByName = editedByName;
            this.statusID = statusID;
            this.statusName = statusName;
        }

        public Item()
        {
            this.itemID = -1;
        }

        public override string ToString()
        {
            return (this.itemID + " " +
                    this.title + " " +
                    this.note + " " +
                    statusName);
        }

        public static List<Item> GetAllItemsBasedOnStatus(int statusIDin, int projectID)
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetAllItemsBasedOnStatusType",
                                                                new string[] { "@StatusID", "@ProjectID" }, new int[] { statusIDin, projectID });

            List<Item> listOfItems = new List<Item>();
            while (reader.Read())
            {
                // ItemID, Title, Note, CreateDate, I.CreatedBy, U1.FirstName+' '+U1.LastName 'CreatedByName', EditDate, I.EditedBy, U2.FirstName+' '+U2.LastName 'EditedByName', I.StatusID, S.Name
                int id = int.Parse(reader["ItemID"].ToString());// ok
                string title = reader["Title"].ToString();// ok
                string note = reader["Note"].ToString();// ok
                DateTime createdOn = DateTime.Parse(reader["CreateDate"].ToString());//ok
                DateTime editedOn = DateTime.Parse(reader["EditDate"].ToString());//ok
                int createdBy = int.Parse(reader["CreatedBy"].ToString());//ok
                string createdByName = reader["CreatedByName"].ToString();//ok
                int editedBy = int.Parse(reader["EditedBy"].ToString());
                string editedByName = reader["EditedByName"].ToString();
                int statusID = int.Parse(reader["StatusID"].ToString());
                string statusName = reader["Name"].ToString();
                
                listOfItems.Add(new Item(id, title, note, createdOn, editedOn, editedBy, createdBy, editedByName, createdByName, statusID, statusName));
            }
            dba.CloseConn();
            return listOfItems;

        }

        public static Item GetItemBasedOnIndex(int itemIdIn)
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetItemBasedOnItemID",
                                                                new string[] { "@ItemID" }, new int[] { itemIdIn });
            Item dbItem = null;
            if (reader.Read())
            {
                // ItemID, Title, Note, CreateDate, I.CreatedBy, U1.FirstName+' '+U1.LastName 'CreatedByName', EditDate, I.EditedBy, U2.FirstName+' '+U2.LastName 'EditedByName', I.StatusID, S.Name
                int id = int.Parse(reader["ItemID"].ToString());// ok
                string title = reader["Title"].ToString();// ok
                string note = reader["Note"].ToString();// ok
                DateTime createdOn = DateTime.Parse(reader["CreateDate"].ToString());//ok
                DateTime editedOn = DateTime.Parse(reader["EditDate"].ToString());//ok
                int createdBy = int.Parse(reader["CreatedBy"].ToString());//ok
                string createdByName = reader["CreatedByName"].ToString();//ok
                int editedBy = int.Parse(reader["EditedBy"].ToString());
                string editedByName = reader["EditedByName"].ToString();
                int statusID = int.Parse(reader["StatusID"].ToString());
                string statusName = reader["Name"].ToString();

                dbItem = new Item(id, title, note, createdOn, editedOn, editedBy, createdBy, editedByName, createdByName, statusID, statusName);

            }
            dba.CloseConn();
            return dbItem;

        }

        public static Item SaveItem(Item itemIn)
        {
            Item itemOut = itemIn;
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            if (itemIn.itemID == -1)
            {
                //	INSERT INTO [dbo].[Items] ([Title],[Note],[CreateDate],[CreatedBy],[EditDate],[EditedBy],[StatusID],[ProjectID])
                //  VALUES(@Title,@Note,getDate(),@CreatedBy ,getDate(), @EditedBy,@StatusID, @ProjectID)
                System.Data.SqlClient.SqlDataReader reader = dba.execSP("InsertItem",
                                            new string[] { "@Title", "@Note", "@CreatedBy", "@EditedBy", "@StatusID", "@ProjectID" },
                                            new string[] { itemIn.Title, itemIn.Note, itemIn.CreatedByID.ToString(), itemIn.EditedByID.ToString(), itemIn.StatusID.ToString(), itemIn.ProjectID.ToString() });
                if (reader.Read())
                {
                    int iid = int.Parse(reader["ItemID"].ToString());
                    itemOut.itemID = iid;
                }
                
                History.Insert(itemOut, 1);
            }
            else
            {
                // [dbo].[UpdateItem]
                //  @ID int, @Title varchar(200),@Note  varchar(200),@EditedBy int,@StatusID int,@ProjectID int
                System.Data.SqlClient.SqlDataReader reader = dba.execSP("UpdateItem",
                            new string[] { "@ItemID", "@Title", "@Note", "@EditedBy", "@StatusID", "@ProjectID" },
                            new string[] { itemIn.ItemID.ToString(),itemIn.Title, itemIn.Note, itemIn.EditedByID.ToString(), itemIn.StatusID.ToString(), itemIn.ProjectID.ToString() });
                reader.Read();

                History.Insert(itemOut, 2);
            }
            
            dba.CloseConn();
            return null;
        }
    }
}
