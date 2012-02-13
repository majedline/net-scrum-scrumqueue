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
namespace ScrumQueue.IOLogic
{
    public class FileAccess : IOLogic
    {
        public static bool WriteToFile(string fileName, string fileContent)
        {
            fileName = fileName + ("_"+DateTime.Today.Day+DateTime.Today.Month+DateTime.Today.Year) + ".txt";
            
            System.IO.TextWriter tw;
            try
            {
                tw = new System.IO.StreamWriter(fileName, true);
                tw.WriteLine(fileContent);
                tw.Close();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public static string ReadFromFile(string fileName)
        {
            string ret = "";
            System.IO.StreamReader sr;

            try
            {
                sr = new System.IO.StreamReader(fileName);
                ret = sr.ReadToEnd();
                sr.Close();
                return ret;
            }
            catch
            {
                return null;
            }

        }
    }
}
