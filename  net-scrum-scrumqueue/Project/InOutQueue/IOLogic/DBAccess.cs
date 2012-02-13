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

using System.Data;
using System.Data.SqlClient;

namespace ScrumQueue.IOLogic
{
    public class DBAccess : IOLogic
    {       
        private SqlConnection conn;

        private List<string> ErrorMessages = new List<string>();

        public DBAccess()
        {
        }

        public void InstantiateConnection(string connectionString)
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connectionString;
            }
            catch (IOAccessException ex)
            {
                ErrorMessages.Add(ex.Message);
            }
        }
        
        public void OpenConn()
        {
            try
            {
                this.conn.Open();
            }
            catch (IOAccessException ex)
            {
                ErrorMessages.Add(ex.Message);
            }
        }

        public void CloseConn()
        {
            try
            {
                this.conn.Close();
            }
            catch (IOAccessException ex)
            {
                ErrorMessages.Add(ex.Message);
            }
        }

        public bool TestConn()
        {
            try
            {
                this.conn.Open();
                this.conn.Close();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public List<string> GetErrorList()
        {
            if (ErrorMessages.Count > 0)
            {
                List<string> messages = this.ErrorMessages;
                this.ErrorMessages = new List<string>();
                return messages;
            }
            else
                return null;
        }

        public SqlDataReader execSP(string strpro)
        {
            try
            {
                SqlCommand command = new SqlCommand(strpro, this.conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (IOAccessException ex)
            {
                this.ErrorMessages.Add(ex.Message);
                return null;
            }
        }

        public SqlDataReader execSP(string strpro, string[] parameterNames, int[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(strpro, this.conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                for (int i = 0; i < parameters.Length; i++)
                {
                    string name = parameterNames[i];
                    int value = parameters[i];

                    command.Parameters.Add(name, System.Data.SqlDbType.Int);
                    command.Parameters[name].Value = value;
                }
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (IOAccessException ex)
            {
                this.ErrorMessages.Add(ex.Message);
                return null;
            }
        }

        public SqlDataReader execSP(string strpro, string[] parameterNames, string[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(strpro, this.conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                for (int i = 0; i < parameters.Length; i++)
                {
                    string name = parameterNames[i];
                    string value = parameters[i];

                    command.Parameters.Add(name, System.Data.SqlDbType.VarChar);
                    command.Parameters[name].Value = value;
                }
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (IOAccessException ex)
            {
                this.ErrorMessages.Add(ex.Message);
                return null;
            }
        }

        public SqlDataReader execSP(string strpro, string[] parameterNames, System.Data.SqlDbType[] parameterTypes, object[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(strpro, this.conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                for (int i = 0; i < parameters.Length; i++)
                {
                    string name = parameterNames[i];
                    object value = parameters[i];

                    command.Parameters.Add(name, parameterTypes[i]);
                    command.Parameters[name].Value = value;
                }
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (IOAccessException ex)
            {
                this.ErrorMessages.Add(ex.Message);
                return null;
            }
        }

        public SqlDataReader execQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, this.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (IOAccessException ex)
            {
                this.ErrorMessages.Add(ex.Message);
                return null;
            }
        }

        public SqlDataReader execQuery(string query, string[] parameterNames, int[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, this.conn);
                for (int i = 0; i < parameters.Length; i++)
                {
                    string name = parameterNames[i];
                    int value = parameters[i];

                    command.Parameters.Add(name, System.Data.SqlDbType.Int);
                    command.Parameters[name].Value = value;
                }
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (IOAccessException ex)
            {
                this.ErrorMessages.Add(ex.Message);
                return null;
            }
        }

        public SqlDataReader execQuery(string query, string[] parameterNames, string[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, this.conn);
                for (int i = 0; i < parameters.Length; i++)
                {
                    string name = parameterNames[i];
                    string value = parameters[i];

                    command.Parameters.Add(name, System.Data.SqlDbType.VarChar);
                    command.Parameters[name].Value = value;
                }
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (IOAccessException ex)
            {
                this.ErrorMessages.Add(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Create and open the connection to the database.
        /// </summary>
        /// <returns></returns>
        public static DBAccess CreateConnection()
        {

            string connectionString = Properties.Settings.Default.ConnectionString;
            DBAccess dba = new DBAccess();

            if (dba == null) return dba;

            dba.InstantiateConnection(connectionString);
            dba.OpenConn();
            return dba;

        }
    }
}
