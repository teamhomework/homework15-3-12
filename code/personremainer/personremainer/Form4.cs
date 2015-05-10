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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] value = new string[12];
            string[] search = new string[4];
            //id type quantity date
            search[0] = "id";
            search[1] = "type";
            search[2] = "quantity";
            search[3] = "date";

            value[0] = personremainer.commo_data.stockcode;
            value[1] = personremainer.commo_data.opt;
            value[2] = personremainer.commo_data.qty.ToString();
            value[3] = personremainer.commo_data.DATE;



            //新數據

            personremainer.commo_data.qty = 0;
            personremainer.commo_data.price = 0;
            label1.Text = personremainer.commo_data.StoName;
            personremainer.commo_data.DATE = monthCalendar1.SelectionStart.ToString("yyyy/MM/dd");
            personremainer.commo_data.price = float.Parse(textBox2.Text);
            personremainer.commo_data.qty = int.Parse( textBox1.Text);
            personremainer.commo_data.opt = comboBox1.Text;

            DataBase DB = new DataBase();


            //name , id ,date,type ,price,quantity ,taxrate , commission 
            value[4] =personremainer.commo_data.StoName;
            value[5] = personremainer.commo_data.stockcode;
            value[6] =personremainer.commo_data.DATE;
            value[7] =personremainer.commo_data.opt;
            value[8] = personremainer.commo_data.price.ToString();
            value[9] = personremainer.commo_data.qty.ToString();
            value[10] = "1%";
            value[11] = "0.3%";
            DB.changeDB(2,search,value);


            Application.OpenForms[1].Close();
            Application.OpenForms[1].Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
