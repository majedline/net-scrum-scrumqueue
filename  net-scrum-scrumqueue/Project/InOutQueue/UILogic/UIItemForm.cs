using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InOutQueue.UILogic
{
    public partial class UIItemForm : Form
    {
        public UIItemForm()
        {
            InitializeComponent();
            this.init(-1, -1);
        }

        public UIItemForm(int XLocation, int YLocation)
        {
            InitializeComponent();
            this.init(XLocation, YLocation);
        }

        private void init(int XLocation, int YLocation)
        {

            //// Default X & Y
            //int defaultX = 800/ 2;
            //int defaultY = 600 / 2;


            //// if location specified then set those; otherwise user the default.
            //if (XLocation >= 0 && YLocation >= 0)
            //    this.Location = new Point(XLocation, YLocation);
            //else if (XLocation >= 0)
            //    this.Location = new Point(XLocation, defaultY);
            //else if (YLocation >= 0)
            //    this.Location = new Point(defaultX, XLocation);
            //else
            //    this.Location = new Point(defaultX, defaultY);
            //this.Refresh();

        }

    }
}