using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Net.Sockets;
using System.Net;

namespace personremainer
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
             
           
            if (false == show_PerFor)
                show_PerFor = true;
            else if(true == show_PerFor)
                show_PerFor = false;
            
            if (true == show_PerFor)
            {
                splitContainer1.SplitterDistance = 150;
            }
            else if(false == show_PerFor)
                splitContainer1.SplitterDistance = 0;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Show();
            
   
        }


        private void 導入數據ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

 
        //持倉
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (false == show_TakSto)
                show_TakSto = true;
            else if(true == show_TakSto)
                show_TakSto = false;

            if (true == show_TakSto)
            {

                Display(panel1);
            }
            else if (false == show_TakSto)
                NotDisplay();
              
        }
 
        //股票資訊
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            if (false == show_StoInf)
                show_StoInf = true;
            else if(true == show_StoInf)
                show_StoInf = false;

            if (true == show_StoInf)
            {
                Display(panel2);
                show_stock_data("601398");
                show_take_sto("601398");
            }
            else if (false == show_StoInf)
                NotDisplay();
        }

        private void 股票收益ToolStripMenuItem_Click(object sender, EventArgs e)
        {
              if (false == show_StoGra)
                show_StoGra = true;
            else if (true == show_StoGra)
                show_StoGra = false;

            if (true == show_StoGra)
            {
                show_sto_gra("601398");
                Display(panel3);
            }
            else if (false == show_StoGra)
                NotDisplay();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //test
        
        }
        //搜索
        private void button1_Click(object sender, EventArgs e)
        {
            /*string StockNum = textBox1.Text;
            
            // show graph code
         GetNetStockData LoadGraph = new GetNetStockData();
         KLineGraph.ImageLocation = @LoadGraph.GetNetGraph(StockNum,0);*/
            //查找數據庫返回顯然資料
            
            //跳轉到股票資訊界面
           show_StoInf = true;
            Display(panel2);

            //test
         DataBase test = new DataBase();
            GetNetStockData ND =new GetNetStockData();
            test.CreateTable();
            DataSet aa;

            string s = ND.GetNetData("601398");
           string[] D = ND.TreatmentString(s);

           test.AddStockData(D, "601398");
            
     //  DataSet DS =  test.ReadDB("StockInf","id","id","2");   
     //  MessageBox.Show( DS.Tables[0].Rows[0][0].ToString());
            

        }
          







    
        //搜索TEXT
        private void textBox1_TextChanged(object sender, EventArgs e)
        {      
 
        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            personremainer.create_form.create_changeOpData();   
        }

        private void change_data_Load(object sender, EventArgs e)
        {

        }
        //導入EXECL
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            personremainer.commo_data.filename = openFileDialog1.FileName;

            //導入文件代碼
            OptExcel optExcel = new OptExcel();
            optExcel.Open_Excel(personremainer.commo_data.filename);

            OptrecordNode recordnode = new OptrecordNode();
            OptrecordNode recordnode_hand = recordnode;
            //找总行数
            int ROW = 1;
            while (true)
            {
                if (optExcel.Read_ExData(ROW, 0) == "" && optExcel.Read_ExData(ROW + 1, 0) == "")
                {
                    break;
                }
                else
                {
                    ROW++;
                }
            }
            for (int rowi = 0; rowi < ROW; rowi++)
            {
                if (optExcel.Read_ExData(rowi, 1) != "")
                {
                    recordnode.stockname = optExcel.Read_ExData(rowi, 0);
                    recordnode.stockcode = optExcel.Read_ExData(rowi, 1);
                    recordnode.optdate = optExcel.Read_ExData(rowi, 2);
                    recordnode.opttype = optExcel.Read_ExData(rowi, 3);
                    recordnode.stockprice = optExcel.Read_ExData(rowi, 4);
                    recordnode.stocknumber = optExcel.Read_ExData(rowi, 5);
                    recordnode.rate = optExcel.Read_ExData(rowi, 6);
                    recordnode.commission = optExcel.Read_ExData(rowi, 7);
                    //recordnode.next = new OptrecordNode();
                    // recordnode = recordnode.next;
                    if (recordnode != null)
                    {
                        recordnode.next = new OptrecordNode();
                        recordnode = recordnode.next;
                    }
                }
            }

            DataBase opdata = new DataBase();
            DataSet DS = new DataSet();
            GetNetStockData GNS =new GetNetStockData();
            opdata.CreateTable();
            opdata.AddUserOp(recordnode_hand);
            DS = opdata.ReadDB("UserOp", "id");


            ROW = int.Parse( DS.Tables[0].Rows.Count.ToString());
            for (int row =0; row<ROW;row++ )
            {
                string getstocaode = DS.Tables[0].Rows[row][0].ToString();

                //新增股票記錄
                    string stockdata = GNS.GetNetData(getstocaode);
                    string[] temp = GNS.TreatmentString(stockdata);
                    opdata.AddStockData(temp, getstocaode);
                
                

            }
            
 


        }


        

            
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            personremainer.create_form.create_cash();

            label1.Text = "本金:" + personremainer.commo_data.cash;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }



        //股票信息
        public void show_stock_data(string stockcode)
        {
            DataBase DB = new DataBase();
            GetNetStockData GNSD = new GetNetStockData();
            DataSet DS =new DataSet();
            DS = DB.ReadDB("UserOp","*","id",stockcode);

            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
            for (int row = 0; row < ROWS; row++)
            {
                stockdataView.Rows.Add(DS.Tables[0].Rows[row][2].ToString(), DS.Tables[0].Rows[row][3].ToString(), DS.Tables[0].Rows[row][4].ToString(), DS.Tables[0].Rows[row][5].ToString(), DS.Tables[0].Rows[row][6].ToString(), DS.Tables[0].Rows[row][7].ToString());
            }
        }


        //持倉信息  
        public void show_take_sto(string stockcode)
        {
            //提取數據
            DataBase DB = new DataBase();
            GetNetStockData GNSD = new GetNetStockData();
            DataSet DS = new DataSet();
            int bs;
            float bsp= 0;//買賣
            int sc = 0 ;//做空 補倉         买入      卖出      补仓      卖空 
            float scp = 0;

            int bstquantity = 0,sctquantity = 0;//交易量
            float tax = 0, comm =  0, tcost = 0,cost = 0;
            string ttax, tcomm;
            DS = DB.ReadDB("UserOp", "*", "id", stockcode);


            int row = int.Parse(DS.Tables[0].Rows.Count.ToString());
        //因為要計算持倉成本所以 由舊的記錄算起
            for (row= row-1;row>0;row--)
            {
              
                if (DS.Tables[0].Rows[row][3].ToString().Substring(0,2) == "买入")
                {
                    //买入
                    ttax =   DS.Tables[0].Rows[row][6].ToString();    
                    tcomm =  DS.Tables[0].Rows[row][7].ToString();
                
                    tax = float.Parse(ttax.Substring(0, ttax.Length - 1)) / 100;
                    comm = float.Parse(tcomm.Substring(0,tcomm.Length-1)) / 100;

                    bs = int.Parse( DS.Tables[0].Rows[row][5].ToString());
                    bsp = float.Parse(DS.Tables[0].Rows[row][4].ToString());
                    

                    tcost = ( bstquantity * cost + ( bs *bsp *(1+tax)*(1+comm) ) ) / ( bstquantity + bs );               
                    bstquantity = bstquantity + bs;
                    cost = tcost;
                    if (bstquantity == 0)
                    {
                        cost = 0;
                    }
                          
                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出")
                {
                   //卖出
                    bs = int.Parse( DS.Tables[0].Rows[row][5].ToString());
                    bsp = float.Parse(DS.Tables[0].Rows[row][4].ToString());
                    tcost = (bstquantity * cost - (bs * bsp * (1 + tax) * (1 + comm))) / (bstquantity - bs);
                    bstquantity = bstquantity - bs;
                    cost = tcost;

                    if (bstquantity == 0)
                    {
                        cost = 0;
                    }
                }

            
               else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓")
               {
                    //补仓
                    sc = int.Parse( DS.Tables[0].Rows[row][5].ToString());
                    scp = float.Parse(DS.Tables[0].Rows[row][4].ToString());
                    sctquantity = sctquantity + sc;
                  

                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空 ")
                {
                    //卖空 
                    sc = int.Parse( DS.Tables[0].Rows[row][5].ToString());
                    scp = float.Parse(DS.Tables[0].Rows[row][4].ToString());
                    sctquantity = sctquantity - sc;
                  
                 
                }
            }
            if (bstquantity > 0)
            {
                
  //當前價上网現抓 第6個返回值

               string d = GNSD.GetNetData(stockcode);
               string[] price = GNSD.TreatmentString(d);
              TaStodataView.Rows.Add(DS.Tables[0].Rows[row][0].ToString(),price[6],cost,"不會算","不會算");
            
            }

        }
        //持倉信息 文本框內容
        public void show_take_sto_textbox(string stockcode)
        {


        }


        //收益信息
        public void show_sto_gra(string stockcode)
        {
                     //提取數據
            DataBase DB = new DataBase();
            GetNetStockData GNSD = new GetNetStockData();
            DataSet DS = new DataSet();
            int bs;
            float bsp= 0;//買賣
            int sc = 0 ;//做空 補倉         买入      卖出      补仓      卖空 
            float scp = 0;
            int quantity =0;
            
            int bstquantity = 0,sctquantity = 0;//交易量
            float tax = 0, comm =  0, tcost = 0,cost = 0;
            string ttax, tcomm;
           
            DS = DB.ReadDB("UserOp", "*", "id", stockcode);


            int row = int.Parse(DS.Tables[0].Rows.Count.ToString());
       
            for (row = row - 1; row > 0; row--)
            {

                if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "买入")
                {
                    //买入
                    ttax = DS.Tables[0].Rows[row][6].ToString();
                    tcomm = DS.Tables[0].Rows[row][7].ToString();

                    tax = float.Parse(ttax.Substring(0, ttax.Length - 1)) / 100;
                    comm = float.Parse(tcomm.Substring(0, tcomm.Length - 1)) / 100;

                    bs = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                    bsp = float.Parse(DS.Tables[0].Rows[row][4].ToString());


                   
                    tcost = (bstquantity * cost + (bs * bsp * (1 + tax) * (1 + comm))) / (bstquantity + bs);
                    bstquantity = bstquantity + bs;
                    cost = tcost;
                    if (bstquantity == 0)
                    {
                        cost = 0;
                    }
              
                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出")
                {
                    //卖出
                    bs = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                    bsp = float.Parse(DS.Tables[0].Rows[row][4].ToString());
                    tcost = (bstquantity * cost - (bs * bsp * (1 + tax) * (1 + comm))) / (bstquantity - bs);
                    bstquantity = bstquantity - bs;
                    cost = tcost;

                    if (bstquantity == 0)
                    {
                        cost = 0;
                    }
                }
            }

                row = int.Parse(DS.Tables[0].Rows.Count.ToString())-1;         
                float costprice = float.Parse((DS.Tables[0].Rows[row][4].ToString()));
                quantity = bstquantity + sctquantity;

                string d = GNSD.GetNetData(stockcode);
                string[] price = GNSD.TreatmentString(d);

                float nowprice = float.Parse(price[6]);
                float totallprice = nowprice * quantity;
  
                float increase = ((nowprice -costprice) / costprice) /100;
               StoGradataView.Rows[0].SetValues(quantity, totallprice.ToString(), increase.ToString());
            




        }





    }

}
