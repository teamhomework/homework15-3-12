using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace personremainer
{
    public partial class Form7 : Form
    {
        struct FROMUI
        {
            string name;
            Form1 WindowName;
        };
        FROMUI[] Temp = new FROMUI[1000];
        public Form7()
        {
            InitializeComponent();
          //  Temp = Input;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
