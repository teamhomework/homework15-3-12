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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            personremainer.commo_data.qty = 0;
            personremainer.commo_data.price = 0;


            label1.Text = personremainer.commo_data.StoName;
            personremainer.commo_data.DATE = monthCalendar1.SelectionStart.ToString("yyyy/MM/dd");
            personremainer.commo_data.price = float.Parse(textBox2.Text);
            personremainer.commo_data.qty = int.Parse( textBox1.Text);
            personremainer.commo_data.opt = comboBox1.Text;

            Application.OpenForms[1].Close();
            Application.OpenForms[1].Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
