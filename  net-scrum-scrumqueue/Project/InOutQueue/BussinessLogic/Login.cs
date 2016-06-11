
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
    public class Login : BussinessLogicBase
    {
        private bool loginStatus;
        private bool userStatus;

        public Users User = new Users();

	
        public Login(string username, string password)
        {
            if (username == null || password == null)
                return;

            if (username.Trim().Length == 0)
                return;

            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("LoginUser",
                                                                    new string[] { "@Username", "@Password" },
                                                                    new string[] { username, password });
            this.loginStatus = false;
            // THIS NEEDS TO BE COMING FROM THE DATABASE BUT WILL NOT RIGHT NOW UNTIL FIELDS IN DB ARE SET
            this.userStatus = true;


            if (reader.Read())
            {
                //UserID, Username, FirstName, LastName, DateCreated
                this.User.UserID = int.Parse(reader["UserID"].ToString());
                this.User.Username = reader["Username"].ToString();
                this.User.FirstName = reader["FirstName"].ToString();
                this.User.LastName = reader["LastName"].ToString();
                this.User.IsAdmin = bool.Parse(reader["IsAdmin"].ToString());
                this.loginStatus = true;
            }

            reader.Close();
            dba.CloseConn();
                
        }

        public bool IsAllowed()
        {
            return (this.loginStatus && this.userStatus);
        }
	

    }
}
