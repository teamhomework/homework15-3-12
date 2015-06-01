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
    public partial class AccountName : Form
    {
        public AccountName()
        {
            InitializeComponent();
           
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            personremainer.commo_data.AccountName = textBox1.Text;
            Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
