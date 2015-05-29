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
            if (true == CanChange(personremainer.commo_data.stockcode,Convert.ToDateTime(personremainer.commo_data.DATE),personremainer.commo_data.opt,personremainer.commo_data.qty))
            {
                DB.changeDB(2, search, value);
                Application.OpenForms[1].Close();
                Application.OpenForms[1].Dispose();
            }
            else
            {
                MessageBox.Show("非法輸入 請重新輸入");
            }


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
            for (int row = 0; row < ROWS; row++)
            {
                quantity = int.Parse(DS.Tables[0].Rows[row][5].ToString());

            if (Date == (DateTime)DS.Tables[0].Rows[row][2])
                {

                    if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "买入")
                    {
                        //买入
                        holdquan += quan;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出")
                    {
                        //卖出
                        holdquan = holdquan - quan;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓")
                    {
                        //补仓
                        holdquan = holdquan + quan;
                    }
                    else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空")
                    {
                        //卖空 
                        holdquan = holdquan - quan;
                    }
                    
                }
                else if (Date != (DateTime)DS.Tables[0].Rows[row][2])
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
            string Data = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            string price = GNDS.hispri(personremainer.commo_data.stockcode, Data);
            textBox2.Text = price;
        }

    }
}
