﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace personremainer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.OpenForms[1].Close();
            Application.OpenForms[1].Dispose();
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          personremainer.commo_data.capital = textBox1.Text;
          Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.USEROP, "添加本金" + textBox1.Text);
        }
    }
}
