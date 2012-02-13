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
    public class SystemStat : BussinessLogicBase
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public double Percent { get; set; }

        public SystemStat(string title, double amount)
        {
            this.Title = title;
            this.Amount = amount;
        }

        public SystemStat(string title, int amount)
        {
            this.Title = title;
            this.Amount = (double)amount;
        }

        public static List<SystemStat> GetProjectStats(int ProjectID)
        {

            ScrumQueue.IOLogic.DBAccess dba = ScrumQueue.IOLogic.DBAccess.CreateConnection();

            System.Data.SqlClient.SqlDataReader reader = dba.execSP("GetProjectStats",
                                        new string[] { "@ProjectID" },
                                        new string[] { ProjectID.ToString() });

            List<SystemStat> li = new List<SystemStat>(20);
            while (reader.Read())
            {
                string title = reader["Title"].ToString();
                int amount = int.Parse(reader["Count"].ToString());
                li.Add(new SystemStat(title, amount));
            }

            setPercentage(li);

            return li;
        }

        private static void setPercentage(List<SystemStat> listWithoutPercentFromDB)
        {
            for (int i=0; i< listWithoutPercentFromDB.Count; i++)
            {
                listWithoutPercentFromDB[i].Percent = Math.Round(Math.Round(listWithoutPercentFromDB[i].Amount, 3) / Math.Round(listWithoutPercentFromDB[listWithoutPercentFromDB.Count - 1].Amount, 3), 3);
                listWithoutPercentFromDB[i].Percent = Math.Round(listWithoutPercentFromDB[i].Percent * 100.00, 3);

            }
        }

        public override string ToString()
        {
            return this.Title + ":\r\n" +
                "\r\t Ratio: [ " + this.Percent.ToString() + "% ] \r\n" +
                "\r\t Total Count: [ " + this.Amount.ToString() + " ]\r\n\r\n";
        }
    

    }
}
