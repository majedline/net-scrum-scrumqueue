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
    
    public class Attachment : BussinessLogicBase
    {

        private int attachmentID;
        public int AttachmentID
        {
            get { return attachmentID; }
            set { attachmentID = value; }
        }

        private int itemId;
        public int ItemID
        {
            get { return itemId; }
            set { itemId = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime createdOn;
        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string fileType;
        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        // the size of the attachment
        private long size;
        public long Size
        {
            get { return size; }
            set { size = value; }
        }

        // the original source locations of the file to be attached
        private string originalLocation;
        public string OriginalLocation
        {
            get { return originalLocation; }
            set { originalLocation = value; }
        }

        // The information to be saved
        private byte[] data;
        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }

        // Original Attachment to find if something is changed when saving.
        private Attachment originalAttachment;
        public Attachment OriginalAttachment
        {
            get { return originalAttachment; }
            set { originalAttachment = value; }
        }

        public Attachment(int attachmentIDIn, int itemIDIn, string nameIn, string fileNameIn, 
                            string fileTypeIn, long sizeIn, string originalLocationIn, byte[] dataIn)
        {
            this.attachmentID = attachmentIDIn;
            this.itemId = itemIDIn;
            this.name = nameIn;
            this.fileName = fileNameIn;
            this.fileType = fileTypeIn;
            this.size = sizeIn;
            this.originalLocation = originalLocationIn;
            this.data = dataIn;
        }

        public Attachment(int attachementIDin, int itemIDIn, System.IO.FileInfo file, byte[] data)
        {
            this.attachmentID = attachementIDin;
            this.itemId  = itemIDIn;
            this.name = file.Name;
            this.fileName = file.FullName;
            this.fileType = file.Extension;
            this.size = file.Length;
            this.OriginalLocation = file.DirectoryName;
            this.data = data;
        }

        public override string ToString()
        {
            return this.AttachmentID + ": " + this.Name;
        }

        /// <summary>
        /// This will get the list of all attachments based on the attachement id
        /// </summary>
        /// <param name="inItemID"></param>
        /// <returns></returns>
        public static List<Attachment> GetAttachments(int inItemID)
        {

            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetAllAttachmentsBasedOnItemID",
                                                                new string[] { "@ItemID" }, new int[] { inItemID });

            List<Attachment> listOfItems = new List<Attachment>();
            while (reader.Read())
            {
                // [AttachmentID],[ItemID],[Name],[CreateDate],[FileName],[FileType],[FileSize],[FileOriginalLocation],[FileData]
                int id = int.Parse(reader["AttachmentID"].ToString());// ok
                int iid = int.Parse(reader["ItemID"].ToString());
                string name = reader["Name"].ToString();// ok
                DateTime createdOn = DateTime.Parse(reader["CreateDate"].ToString());//ok
                string fileName = reader["FileName"].ToString();
                string fileType = reader["FileType"].ToString();
                int fileSize = int.Parse(reader["FileSize"].ToString());//ok
                string fileOriginalLocation = reader["FileOriginalLocation"].ToString();

                byte[] buffer = (byte[])reader["FileData"];

                Attachment a = new Attachment(id, iid, name, fileName, fileType, fileSize, fileOriginalLocation, buffer);
                listOfItems.Add(a);
            }
            dba.CloseConn();
            return listOfItems;
        }

        public static void SaveAttachments(List<Attachment> attachments)
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            List<Attachment> itemsout = new List<Attachment>(attachments.Count);

            foreach (Attachment a in attachments)
            {    
                // insert the item
                if (a.ItemID != -1)
                {


                    System.Data.SqlClient.SqlDataReader reader = dba.execSP("InsertAttachment",
                                                new string[] { "@ItemID", "@Name", "@CreateDate", "@FileName", "@FileType", "@fileSize", "@FileOriginalLocation", "@data" },
                                                new System.Data.SqlDbType[] { System.Data.SqlDbType.Int, System.Data.SqlDbType.VarChar, System.Data.SqlDbType.DateTime,
                                                System.Data.SqlDbType.VarChar,System.Data.SqlDbType.VarChar,System.Data.SqlDbType.Int, System.Data.SqlDbType.VarChar,
                                                System.Data.SqlDbType.VarBinary},
                                                new object[] { a.ItemID.ToString(), a.Name, DateTime.Now.ToString(), a.FileName, a.FileType, a.size.ToString(), a.OriginalLocation.ToString(), a.data });

                    if (reader.Read())
                    {
                        int iid = int.Parse(reader["ItemID"].ToString());
                        a.AttachmentID = iid;
                        itemsout.Add(a);
                    }

                   // History.Insert(a, 1);
                }


                dba.CloseConn();
            }
        }

        public static void DeleteAttachments(Attachment attachment)
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();

            // insert the item
            if (attachment.ItemID != -1)
            {

                System.Data.SqlClient.SqlDataReader reader = dba.execSP("DeleteAttachment",
                                            new string[] { "@AttachmentID" },
                                            new System.Data.SqlDbType[] { System.Data.SqlDbType.Int },
                                            new object[] { attachment.AttachmentID });

                reader.Read();
                // History.Insert(a, 1);
            }
            dba.CloseConn();
        }

        public void OpenAttachmentInDefaultApplicationType()
        {

            string path = System.IO.Path.GetTempPath();
            string file = ((this.Name + "_" + DateTime.Now.ToUniversalTime().ToString()).Replace('/', '-')).Replace(':', '-');
            string fullFileName = path + file + this.FileType;

            CommonLogic.Common.OpenFileWithDefaultApplication(fullFileName, this.data);
        }

    }
}
