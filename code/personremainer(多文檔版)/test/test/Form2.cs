using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        int Value = 1;
        public Form2(int Input)
        {
            InitializeComponent();
           Value = sad.Value;
        }

        private void calutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = Value.ToString();
        }
    }
}
