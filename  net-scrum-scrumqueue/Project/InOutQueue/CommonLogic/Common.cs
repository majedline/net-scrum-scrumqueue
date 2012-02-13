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
using System.Windows.Forms;

namespace ScrumQueue.CommonLogic
{
    public class Common : CommonLogicBase
    {
        public static string[] BrowseFile(System.Windows.Forms.FileDialog openFileDialog)
        {
            string[] fileNames = new string[1];
            DialogResult dlgRes = openFileDialog.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                // store the selected filename on the currentFile
                fileNames = openFileDialog.FileNames;
            }
            else
            {
                fileNames = null;
            }
            return fileNames;
        }

        public static byte[] GetBytesFromFile(string file)
        {
            try
            {

                // check if this is a file name;
                if (file == null)
                    return null;

                if (file.Trim().Length == 0)
                    return null;

                // get the size of the buffer
                int bufferSize = (int)(new System.IO.FileInfo(file).Length);

                // check if the file has anything.
                if (bufferSize == 0)
                    return null;

                // create the buffer with the proper size
                byte[] buffer = new byte[bufferSize];

                // create the stream
                System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open);

                // create the reader of the stream
                System.IO.BinaryReader reader = new System.IO.BinaryReader(fs);

                // populate the buffer
                buffer = reader.ReadBytes(bufferSize);

                // Close the stream 
                fs.Close();
                fs.Dispose();

                // close the reader
                reader.Close();
                fs.Dispose();

                return buffer;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Please Make sure that the file is valid or is not in use. Details:\r\n" + ex.Message);
                return null;
            }

        }

        public static void OpenFileWithDefaultApplication(string fullfileLocationAndName, byte[] data)
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(fullfileLocationAndName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
                fs.Write(data, 0, data.Length - 1);
                fs.Close();
                fs.Dispose();

                System.Diagnostics.Process.Start(fullfileLocationAndName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error opening the file: " + fullfileLocationAndName + 
                    "\r\n\r\n The following is the error message: " + ex.Message);
            }
        }

    }
}
