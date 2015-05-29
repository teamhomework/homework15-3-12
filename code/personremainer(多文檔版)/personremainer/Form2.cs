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

            


            DataBase DB = new DataBase();
            string[] value =new string[8];
            //name , id ,date,type ,price,quantity ,taxrate , commission 
            value[0] =personremainer.commo_data.StoName;
            value[1] = personremainer.commo_data.stockcode;
            value[2] =personremainer.commo_data.DATE;
            value[3] =personremainer.commo_data.opt;
            value[4] = personremainer.commo_data.price.ToString();
            value[5] = personremainer.commo_data.qty.ToString();
            value[6] = "1%";
            value[7] = "0.3%";
            if (true == CanChange(personremainer.commo_data.stockcode, monthCalendar1.SelectionStart, personremainer.commo_data.opt, personremainer.commo_data.qty))
            {
               
                DB.changeDB(0, value, value);
            }
            else
            {
                
                MessageBox.Show("非法操作");
            }


            Application.OpenForms[1].Close();
            Application.OpenForms[1].Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        public bool CanChange(string stockcode, DateTime Date, string type, int quan)
        {
            //讀DB
            //計算修改後 股票量
            //分四種操作 進行判斷
            //分別對應返回真假

            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            int holdquan = 0, quantity = 0;
            DS = DB.ReadDB("UserOp", "*", "id", stockcode, 1);
            int ROWS = DS.Tables[0].Rows.Count;
            int test =1;
            for (int row = 0; row < ROWS; row++)
            {
                if (Date > (DateTime)DS.Tables[0].Rows[row][2])
                {
                    quantity = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                    if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "买入")
                    {
                        //买入
                        holdquan += quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出")
                    {
                        //卖出
                        holdquan = holdquan - quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓")
                    {
                        //补仓
                        holdquan = holdquan + quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空")
                    {
                        //卖空 
                        holdquan = holdquan - quantity;
                    }

                }
                else if (1 == test)
                {
                    test = 0;

                    if (type == "卖出")
                    {
                        //卖出
                        holdquan -= quan;
                    }
                    else if (type == "补仓")
                    {
                        //补仓
                        holdquan += quan;
                    }
                  
/*
                    if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "买入")
                    {
                        //买入
                        holdquan += quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出")
                    {
                        //卖出
                        holdquan = holdquan - quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓")
                    {
                        //补仓
                        holdquan = holdquan + quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空")
                    {
                        //卖空 
                        holdquan = holdquan - quantity;
                    }*/
                }
                else
                {
                    if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "买入")
                    {
                        //买入
                        holdquan += quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出")
                    {
                        //卖出
                        holdquan = holdquan - quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓")
                    {
                        //补仓
                        holdquan = holdquan + quantity;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空")
                    {
                        //卖空 
                        holdquan = holdquan - quantity;
                    }
               
                }

                if ((DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出" || DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "买入") && holdquan < 0)
                {
                    return false;
                }
                else if ((DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空" || DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓") && holdquan > 0)
                {
                    return false;
                }

            }

                return true;
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            GetNetStockData GNDS = new GetNetStockData();
           string Data= monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
          string price= GNDS.hispri(personremainer.commo_data.stockcode,Data);
          textBox2.Text = price;
        }
    }

}
