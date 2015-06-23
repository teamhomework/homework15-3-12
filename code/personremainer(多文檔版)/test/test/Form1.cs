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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cREATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 1;
            Form2 fm = new Form2(i);
            fm.Text = i.ToString();
            fm.MdiParent = this;
            fm.Show();
            i++;
            Form2 fm2 = new Form2(i);
            fm2.Text = i.ToString();
            fm2.MdiParent = this;
            fm2.Show();
            i++;
            Form2 fm3 = new Form2(i);
            fm3.Text = i.ToString();
            fm3.MdiParent = this;
            fm3.Show();
            i++;
            Form2 fm4 = new Form2(i);
            fm4.Text = i.ToString();
            fm4.MdiParent = this;
            fm4.Show();
            i++;

        }
    }
}
