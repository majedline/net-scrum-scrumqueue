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
 
    [Serializable]
    public class Users : BussinessLogicBase
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }

        public string SerializationFullPath { get { return System.IO.Path.GetTempPath(); } }
        public string SerializationFullPathFile { get { return SerializationFullPath + @"\ScrumQueue.User.IOQ"; } }
        

        public Users()
        {
            this.UserID = -1;
        }

        public Users(int id, string username, string password, string fname, string lname, bool isAdmin)
        {
            this.UserID = id;
            this.Username = username;
            this.Password = password;
            this.FirstName = fname;
            this.LastName = lname;
            this.IsAdmin = isAdmin;
        }

        public static void SaveUsers(Users u)
        {

            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            if (u.UserID == -1)
            {
                //"@Username", "@Password", "@FirstName", "@LastName", "@DateCreated"
                System.Data.SqlClient.SqlDataReader reader = dba.execSP("InsertUser",
                                            new string[] { "@Username", "@Password", "@FirstName", "@LastName", "@isAdmin" },
                                            new string[] { u.Username, u.Password, u.FirstName, u.LastName, u.IsAdmin.ToString()});
                reader.Read();
            }
            else
            {

                //"@Username", "@Password", "@FirstName", "@LastName", "@DateCreated"
                System.Data.SqlClient.SqlDataReader reader = dba.execSP("UpdateUser",
                                            new string[] { "@Username", "@Password", "@FirstName", "@LastName", "@IsAdmin" },
                                            new string[] { u.Username, u.Password, u.FirstName, u.LastName, u.IsAdmin.ToString() });
                reader.Read();
            }
        }

        /// <summary>
        /// return -1 if user does not exist
        /// return -2 if user does exist and is the same as the user passed in the parameter.
        /// return the ID if the user does.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static int isUsernameAvailable(Users u)
        {


            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();

            //"@Username"
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("CheckUserNameExist",
                                        new string[] { "@Username" },
                                        new string[] { u.Username });
            int ret = -1;
            if (reader.Read())
            {
                ret = int.Parse(reader[0].ToString().Trim());
            }

            // if the returned user is positive and is the same as the passed in user, return -2
            if (ret == u.UserID)
                return -2;

            // if the returned user is positive then return the actual user
            // if the returned user is negative(i.e. not in the database) then return -1
            return ret;

        }

        public static List<Users> GetAllUsers()
        {

            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();

            //"@Username"
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetAllUsers",
                                        new string[] { },
                                        new string[] { });

            List<Users> userlist = new List<Users>(20);
            while (reader.Read())
            {
                int id = int.Parse(reader["UserID"].ToString());
                string username = reader["Username"].ToString();
                string password = reader["Password"].ToString();
                string firstname = reader["FirstName"].ToString();
                string lastname = reader["LastName"].ToString();
                bool isAdmin = bool.Parse(reader["IsAdmin"].ToString());

                //bool isAdmin = false;
                //if (isAdminString.Trim().Equals("1"))
                //    isAdmin = true;

                Users u = new Users(id, username, password, firstname, lastname, isAdmin);
                userlist.Add(u);
            }

            return userlist;
        }

        public override string ToString()
        {
            string admins = "Admin - ";
            
            if (!IsAdmin)
                admins = "";

            return "[ " +admins+ this.UserID.ToString() + " ] " + this.Username + " - " + this.FirstName + " " + this.LastName ;
        }

        public bool RememberMe()
        {

            System.IO.FileStream fs = null;

            try
            {
                // Create the FileStream
                fs = new System.IO.FileStream(SerializationFullPathFile, System.IO.FileMode.Create);
                
                // Create the formatter
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                                                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                // Serialize
                bf.Serialize(fs, this);
                
                // Close the stream
                fs.Close();
                return true;
            }
            catch(Exception ex)
            {
                if (fs != null)
                    fs.Close();

                return false;
            }
        }

        public void LoadRememberMe()
        {

            if (!new System.IO.FileInfo(this.SerializationFullPathFile).Exists)
                return;

            System.IO.FileStream fs = null;

            try
            {
                // Create the stream
                fs = new System.IO.FileStream(SerializationFullPathFile, System.IO.FileMode.Open);

                // Create the formatter
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                                                            new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                // Create the temp user
                Users u = new Users();
                
                //deserialize
                u = (Users)bf.Deserialize(fs);
                
                // Close the stream
                fs.Close();

                this.UserID = u.UserID;
                this.Username = u.Username;
                this.Password = u.Password;
                this.FirstName = u.FirstName;
                this.LastName = u.LastName;
                this.IsAdmin = u.IsAdmin;

            }
            catch (Exception ex)
            {
                if (fs != null)
                    fs.Close();

                return;
            }   
        }

        public void ForgetMe()
        {

            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(this.SerializationFullPathFile);

                if (fi != null)
                    fi.Delete();
                
            }
            catch (Exception ex)
            {
                return;
            }
        }
    
    
    }
}
