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
    public class StatusType : BussinessLogicBase
    {
        private int statusID;

        public int StatusID
        {
            get { return statusID; }
            set { this.statusID = value; }
        }

        private string statusName;

        public string StatusName
        {
            get { return statusName; }
            set { this.statusName = value; }
        }

        private string statusDescription;

        public string StatusDescription
        {
            get { return statusDescription; }
            set { this.statusDescription = value; }
        }

        public StatusType()
        {
            this.statusID = -1;
            this.statusName = "";
            this.statusDescription = "";
        }

        public StatusType(int id, string statusName, string statusDescription)
        {
            this.statusID = id;
            this.statusName = statusName;
            this.statusDescription = statusDescription;
        }

        public static List<StatusType> GetAllStatusTypes()
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetAllStatusTypes");

            List<StatusType> listOfStatus = new List<StatusType>(4);// Default to save perfomance
            while (reader.Read())
            {
                int id = int.Parse(reader["StatusID"].ToString());
                string nm = reader["Name"].ToString();
                string desc = reader["Description"].ToString();
                listOfStatus.Add(new StatusType(id,nm , desc));
            }
            dba.CloseConn();
            return listOfStatus;
        }

        public static int SaveStatusType(StatusType st)
        {
            int id = st.StatusID;

            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = null;

            if (st.StatusID == -1)
            {
                reader = dba.execSP("InsertStatusType",
                                            new string[] { "@Name", "@Description" },
                                            new System.Data.SqlDbType[] { System.Data.SqlDbType.VarChar, System.Data.SqlDbType.VarChar },
                                            new object[] { st.StatusName, st.StatusDescription });

                if (reader.Read())
                    id = int.Parse(reader["StatusID"].ToString());                
            }
            else
            {
                reader = dba.execSP("UpdateStatusType",
                                            new string[] { "@ID", "@Name", "@Description" },
                                            new System.Data.SqlDbType[] { System.Data.SqlDbType.Int, System.Data.SqlDbType.VarChar, System.Data.SqlDbType.VarChar },
                                            new object[] { st.StatusID, st.StatusName, st.StatusDescription });

                if (reader.Read())
                    id = int.Parse(reader["StatusID"].ToString());
            }

            dba.CloseConn();
            return id;
        }

        public override string ToString()
        {
            return this.StatusName;
        }
	

    }
}
