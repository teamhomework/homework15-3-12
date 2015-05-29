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
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void 開戶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountName AN = new AccountName();
            
            AN.ShowDialog();
            if (personremainer.commo_data.AccountName.Length >0)
            {
                string HeaderName = personremainer.commo_data.AccountName;
                Form1 fm = new Form1(HeaderName);
                fm.MdiParent = this;
                fm.Text = HeaderName;
                fm.Show();
            }
        }
    }
}
