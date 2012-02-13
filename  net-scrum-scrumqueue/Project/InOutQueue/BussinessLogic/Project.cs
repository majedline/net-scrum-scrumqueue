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
    public class Project : BussinessLogicBase
    {

        private int projectID;

        public int ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }

        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        private string prjectDescription;

        public string ProjectDescription
        {
            get { return prjectDescription; }
            set { prjectDescription = value; }
        }

        public Project(int id, string name, string description)
        {
            this.projectID = id;
            this.projectName = name;
            this.prjectDescription = description;
        }

        public static int SaveProject(Project p)
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("SaveProject", 
                                        new string[] { "@ProjectID", "@ProjectName", "@ProjectDescription" },
                                        new System.Data.SqlDbType[]{ System.Data.SqlDbType.Int, System.Data.SqlDbType.VarChar, System.Data.SqlDbType.VarChar},
                                        new object[] { p.ProjectID.ToString(), p.ProjectName, p.ProjectDescription });

            int id = -1;
            if (reader.Read())
            {
                id = int.Parse(reader["projectID"].ToString());
            }
            dba.CloseConn();
            return id;
            
        }
    
        public override string ToString()
        {
            return "["+this.ProjectID+"] "+this.ProjectName + "  (" + this.ProjectDescription+")";
        }

        public static void ShutDownProject(Project p)
        {
            throw new NotImplementedException();
        }

        public static void OpenProject(Project p)
        {
            throw new NotImplementedException();
        }

        public static List<Project> GetAllProjects()
        {
            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();
            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetAllProjects");
            List<Project> projectList = new List<Project>();

            while (reader.Read())
            {
                //[ProjectID],[ProjectName],[ProjectDescription]
                int id = int.Parse(reader["ProjectID"].ToString());
                string projectName = reader["ProjectName"].ToString();
                string projectDesc = reader["ProjectDescription"].ToString();
                projectList.Add(new Project(id, projectName, projectDesc));
            }
            dba.CloseConn();
            return projectList;
            
        }
	
    }
}
