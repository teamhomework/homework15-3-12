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
using System.Windows.Forms.DataVisualization.Charting;

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
            NotDisplay();
            if (StoGrachart.Series.Count != 0)
            {
                StoGrachart.Series.Clear();
            }

            if (TaStochart.Series.Count != 0)
            {
                TaStochart.Series.Clear();

            }

            if (false == show_TakSto)
                show_TakSto = true;
            else if(true == show_TakSto)
                show_TakSto = false;

            if (true == show_TakSto)
            {
                while (TaStodataView.Rows.Count != 0)
                {
                    TaStodataView.Rows.Clear();
                }
                Display(panel1);


                DataSet DS = new DataSet();
                DataBase DB = new DataBase();

                DS = DB.ReadDB("userop", "id", 0);
                int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
                for (int row = 0; row < ROWS; row++)
                {
                    show_take_sto(DS.Tables[0].Rows[row][0].ToString());
                }

            }
            else if (false == show_TakSto)
                NotDisplay();
              
        }
 
        //股票資訊
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            NotDisplay();
            if (StoGrachart.Series.Count != 0)
            {
                StoGrachart.Series.Clear();
            }

            if (TaStochart.Series.Count != 0)
            {
                TaStochart.Series.Clear();
            }

            if (false == show_StoInf)
                show_StoInf = true;
            else if(true == show_StoInf)
                show_StoInf = false;

            if (true == show_StoInf)
            {
                Display(panel2);
                if (personremainer.commo_data.stockcode != null)
                {
                    show_stock_data(personremainer.commo_data.stockcode);
                    show_take_sto(personremainer.commo_data.stockcode);
                    show_take_sto_textbox(personremainer.commo_data.stockcode);
                    show_take_kgraph(personremainer.commo_data.stockcode);
                }
            }
            else if (false == show_StoInf)
                NotDisplay();
        }

        private void 股票收益ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotDisplay();
            if (StoGrachart.Series.Count != 0)
            {
                StoGrachart.Series.Clear();
            }

            if (TaStochart.Series.Count != 0)
            {
                TaStochart.Series.Clear();
            }

              if (false == show_StoGra)
                show_StoGra = true;
            else if (true == show_StoGra)
                show_StoGra = false;

            if (true == show_StoGra)
            {
                show_sto_gra("601398");
                show_gra_listbox();
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
            if (StoGrachart.Series.Count != 0)
            {
                StoGrachart.Series.Clear();
            }

            if (TaStochart.Series.Count != 0)
            {
                TaStochart.Series.Clear();
           
            }
            string StockNum = textBox1.Text;
            
            //跳轉到股票資訊界面
            show_StoInf = true;
            NotDisplay();
            Display(panel2);

            show_stock_data(StockNum);
            show_take_sto(StockNum);
            show_take_sto_textbox(StockNum);
            show_take_kgraph(StockNum);

            personremainer.commo_data.stockcode = textBox1.Text;

            

            

        }
          







    
        //搜索TEXT
        private void textBox1_TextChanged(object sender, EventArgs e)
        {      
 
        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.label1.Text = personremainer.commo_data.StoName;
            frm2.ShowDialog();
            show_stock_data(personremainer.commo_data.stockcode);
           // personremainer.create_form.create_changeOpData();   
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
            if (stockdataView[e.ColumnIndex, e.RowIndex].Value == "修改")
            {
              Form4 frm4 = new Form4();
              

                //先傳數據給STATIC 再傳給文本


              personremainer.commo_data.opt = stockdataView[1, e.RowIndex].Value.ToString();
              personremainer.commo_data.qty = int.Parse( stockdataView[3, e.RowIndex].Value.ToString());
              personremainer.commo_data.DATE = stockdataView[0, e.RowIndex].Value.ToString();
                personremainer.commo_data.price = float.Parse( stockdataView[2, e.RowIndex].Value.ToString());

              frm4.textBox1.Text = personremainer.commo_data.qty.ToString();
              frm4.comboBox1.Text = personremainer.commo_data.opt;
              frm4.monthCalendar1.SelectionStart = Convert.ToDateTime(personremainer.commo_data.DATE);
              frm4.monthCalendar1.SelectionEnd =Convert.ToDateTime( personremainer.commo_data.DATE);
              frm4.textBox2.Text = personremainer.commo_data.price.ToString();
              frm4.ShowDialog();

              show_stock_data(personremainer.commo_data.stockcode);
                
                
            }
            else if (stockdataView[e.ColumnIndex, e.RowIndex].Value == "刪除")
            {
              DataBase DB = new DataBase();
                string[] Date =new string[4];
                string[] Type =new string[4];
                Type[0] = "date";
                Type[1] = "type";
                Type[2] = "quantity";
                Type[3] = "name";
                Date[0] = stockdataView[0, e.RowIndex].Value.ToString();
                Date[1] = stockdataView[1, e.RowIndex].Value.ToString();
                Date[2] = stockdataView[3, e.RowIndex].Value.ToString();
                Date[3] = personremainer.commo_data.StoName;
           
                DB.changeDB(1,Type,Date);

                show_stock_data(personremainer.commo_data.stockcode);
                
            }

           
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
            if (DS.Tables[0].Rows.Count != 0)
            {
                personremainer.commo_data.StoName = DS.Tables[0].Rows[0][0].ToString();
            }
            if (stockdataView.Rows.Count != 0)
            {
                stockdataView.Rows.Clear();
            }

            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
            for (int row = 0; row < ROWS; row++)
            {
               
                stockdataView.Rows.Add(DS.Tables[0].Rows[row][2].ToString(), DS.Tables[0].Rows[row][3].ToString(), DS.Tables[0].Rows[row][4].ToString(), DS.Tables[0].Rows[row][5].ToString(), DS.Tables[0].Rows[row][6].ToString(), DS.Tables[0].Rows[row][7].ToString());
            }
            if (DS.Tables[0].Rows.Count != 0)
            {
                personremainer.commo_data.StoName = DS.Tables[0].Rows[0][0].ToString();
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
            float bsp = 0;//買賣
            int sc = 0;//做空 補倉         买入      卖出      补仓      卖空 
            float scp = 0;
            int quantity = 0;




            int bstquantity = 0, sctquantity = 0;//交易量
            float tax = 0, comm = 0, tcost = 0, cost = 0,tcost2 =0,cost2 =0;
            string ttax, tcomm;
           
            DS = DB.ReadDB("UserOp", "*", "id", stockcode);

            string StrDate;
            string stoname = null;
            //畫圖
            if (DS.Tables[0].Rows.Count != 0)
            {
                stoname = DS.Tables[0].Rows[0][0].ToString();
              

                addtastoser(stoname);
            }


            int row = int.Parse(DS.Tables[0].Rows.Count.ToString());
        //因為要計算持倉成本所以 由舊的記錄算起
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

                     quantity =bstquantity;
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
                    tcost = (bstquantity * cost - (bs * bsp * (1 - tax) * (1 - comm))) / (bstquantity - bs);
                    bstquantity = bstquantity - bs;
                    cost = tcost;
                       quantity =bstquantity;

                    if (bstquantity == 0)
                    {
                        cost = 0;
                    }
                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓")
                {
                    //补仓
                    sc = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                    scp = float.Parse(DS.Tables[0].Rows[row][4].ToString());
                    tcost2 = (sctquantity * cost - (sc * scp * (1 + tax) * (1 + comm))) / (sctquantity - sc);
                    tcost2 = cost2;
                    sctquantity = sctquantity + sc;
                     quantity =sctquantity;
                    if (sctquantity == 0)
                    {
                        cost = 0;
                    }



                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空")
                {
                    //卖空 
                    ttax = DS.Tables[0].Rows[row][6].ToString();
                    tcomm = DS.Tables[0].Rows[row][7].ToString();

                    tax = float.Parse(ttax.Substring(0, ttax.Length - 1)) / 100;
                    comm = float.Parse(tcomm.Substring(0, tcomm.Length - 1)) / 100;

                    sc = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                    scp = float.Parse(DS.Tables[0].Rows[row][4].ToString());



                    tcost = (sctquantity * cost + (sc * scp * (1 - tax) * (1 - comm))) / (sctquantity + sc);
                    sctquantity = sctquantity - sc;
                     quantity =bstquantity;
                    cost = tcost;
                       quantity =sctquantity;
                    if (sctquantity == 0)
                    {
                        cost = 0;
                    }
                }
                
                //畫持倉圖
                if (DS.Tables[0].Rows.Count != 0)
                {
                    StrDate = DS.Tables[0].Rows[row][2].ToString();
                    DateTime Date = Convert.ToDateTime(StrDate);
                    TaStochart.Series[stoname].Points.AddXY(Date, quantity);
                }

            }
            if (bstquantity > 0)
            {
                //當前價上网現抓 第6個返回值

                

               string d = GNSD.GetNetData(stockcode);
               string[] price = GNSD.TreatmentString(d);
               TaStodataView.Rows.Add(DS.Tables[0].Rows[row][0].ToString(),price[6],cost,"不會算","不會算");
             
            }
            else if (sctquantity < 0)
            {
              
                string d = GNSD.GetNetData(stockcode);
                string[] price = GNSD.TreatmentString(d);
                TaStodataView.Rows.Add(DS.Tables[0].Rows[row][0].ToString(), price[6], cost, "不會算", "不會算");


            }
            
        }
        //持倉信息 文本框內容
        public void show_take_sto_textbox(string stockcode)
        {
            GetNetStockData GNSD =new GetNetStockData();
            DataBase DB =new DataBase();
            DataSet DS =new DataSet();

           string d = GNSD.GetNetData(stockcode);
           string[] stoinf = GNSD.TreatmentString(d);
       
            DS = DB.ReadDB("stockinf","*","id",stockcode);
            if (DS.Tables[0].Rows.Count == 0 && stoinf[0].Length>2)
            {

            string T = stoinf[1];
            string N = stoinf[3];
            float Increase,priceT,priceN;
            priceT =float.Parse( T);
            priceN = float.Parse(N);
            Increase = priceN - priceT;


                //抓數據
                StoDataName.Text = stoinf[0].ToString();
                StoInc.Text = stoinf[6].ToString();


                StockDataInf.Text = "股票名:" + stoinf[0] + "\r\n" + "股票編號:" + stockcode + "\r\n" + "今日開盤價:" + stoinf[1] + "\r\n" + "昨日收盤價:" + stoinf[2] + "\r\n" + "今日最高價:" + stoinf[4] + "\r\n" + "今日最低價:" + stoinf[5] + "\r\n" + "漲幅:" + Increase;
     
     

            }
            else
            {
                if (stoinf[0].Length < 2)
                {
                    MessageBox.Show("查無此股");
                    

                }
                else
                {

                    StoDataName.Text = stoinf[0].ToString();
                    StoInc.Text = DS.Tables[0].Rows[0][6].ToString();//股價
                    //richbox  \r\n  <<<換行符
                    StockDataInf.Text = "股票名:" + DS.Tables[0].Rows[0][0].ToString() + "\r\n" + "股票編號:" + DS.Tables[0].Rows[0][1].ToString() + "\r\n" + "今日開盤價:" + DS.Tables[0].Rows[0][2].ToString() + "\r\n" + "昨日收盤價:" + DS.Tables[0].Rows[0][3].ToString() + "\r\n" + "今日最高價:" + DS.Tables[0].Rows[0][4].ToString() + "\r\n" + "今日最低價:" + DS.Tables[0].Rows[0][5].ToString() + "\r\n" + "漲幅:" + DS.Tables[0].Rows[0][6].ToString();
                }
            }
            //設數據
            personremainer.commo_data.StoName = stoinf[0];
            personremainer.commo_data.stockcode = stockcode;

         
        }

        //持倉信息 K圖
        public void show_take_kgraph(string stockcode)
        {
            GetNetStockData LoadGraph = new GetNetStockData();
            KLineGraph.ImageLocation = @LoadGraph.GetNetGraph(stockcode, 0);
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
            float tax = 0, comm =  0, tcost = 0,cost = 0,tcost2 =0,cost2 = 0;
            string ttax, tcomm;
           
            DS = DB.ReadDB("UserOp", "*", "id", stockcode);

            //畫圖

             string stoname = null;
            string StrDate;
            if(DS.Tables[0].Rows.Count!=0)
            {
            stoname = DS.Tables[0].Rows[0][0].ToString();
            StoGrachart.Series.Clear();
         
            addstogrser(stoname);
            
            }
            
                string d = GNSD.GetNetData(stockcode);
                string[] price = GNSD.TreatmentString(d);

                float nowprice = float.Parse(price[6]);


            int row = int.Parse(DS.Tables[0].Rows.Count.ToString());
            int test = row-1;
       
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
                    tcost = (bstquantity * cost - (bs * bsp * (1 - tax) * (1 - comm))) / (bstquantity - bs);
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
                    sc = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                    scp = float.Parse(DS.Tables[0].Rows[row][4].ToString());
                    tcost2 = (sctquantity * cost - (sc * scp * (1 + tax) * (1 + comm))) / (sctquantity - sc);
                    tcost2 = cost2;
                    sctquantity = sctquantity + sc;
                    if (sctquantity == 0)
                    {
                        cost = 0;
                    }



                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空")
                {
                    //卖空 
                    ttax = DS.Tables[0].Rows[row][6].ToString();
                    tcomm = DS.Tables[0].Rows[row][7].ToString();

                    tax = float.Parse(ttax.Substring(0, ttax.Length - 1)) / 100;
                    comm = float.Parse(tcomm.Substring(0, tcomm.Length - 1)) / 100;

                    sc = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                    scp = float.Parse(DS.Tables[0].Rows[row][4].ToString());



                    tcost = (sctquantity * cost + (sc * scp * (1 - tax) * (1 - comm))) / (sctquantity + sc);
                    sctquantity = sctquantity - sc;
                    cost = tcost;
                    if (sctquantity == 0)
                    {
                        cost = 0;
                    }

                }
                quantity = bstquantity + sctquantity;

                //畫收益圖
                if (DS.Tables[0].Rows.Count != 0)
                {
                    float change = (cost / float.Parse(DS.Tables[0].Rows[test][4].ToString())) - 1;
                    if (quantity == 0)
                    {
                        change = 0;
                    }
                    StrDate = DS.Tables[0].Rows[row][2].ToString();
                    DateTime Date = Convert.ToDateTime(StrDate);
                    StoGrachart.Series[stoname].Points.AddXY(Date, change);//改成收益率

                }

            }

                row = int.Parse(DS.Tables[0].Rows.Count.ToString())-1;
                if (row > 0)
                {
                    float costprice = float.Parse((DS.Tables[0].Rows[row][4].ToString()));
                    quantity = bstquantity + sctquantity;
                    /*
                        string d = GNSD.GetNetData(stockcode);
                        string[] price = GNSD.TreatmentString(d);

                        float nowprice = float.Parse(price[6]);*/
                    float totallprice = nowprice * quantity;

                    float increase = ((nowprice - costprice) / costprice) / 100;
                    StoGradataView.Rows[0].SetValues(quantity, totallprice.ToString(), increase.ToString());
                }

        }

        public void show_gra_listbox()
        {
            DataSet DS =new DataSet();
            DataBase DB=new DataBase();
          
            DS = DB.ReadDB("userop", "name",0);
            DataTable DT = DS.Tables[0];
            StoGralistBox.DataSource = DT;
            StoGralistBox.ValueMember = "name";
            StoGralistBox.DisplayMember = "name";

            
        }


        private void StoGralistBox_DoubleClick(object sender, EventArgs e)
        {
            string stockname = StoGralistBox.SelectedValue.ToString();
            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            DS = DB.ReadDB("stockinf", "id", "name", stockname);
            if (DS.Tables[0].Rows.Count != 0)
            {
                personremainer.commo_data.stockcode = DS.Tables[0].Rows[0][0].ToString();
            }

            show_sto_gra(personremainer.commo_data.stockcode);
            
            
        }





        public void addtastoser(string name)
        {

            //设置图案颜色
            TaStochart.Series.Add(name);

            TaStochart.Series[name].BorderWidth = 3;
            TaStochart.Series[name].ChartType = SeriesChartType.Line;
            TaStochart.Series[name].IsValueShownAsLabel = false;//是否顯示點的值
            TaStochart.Series[name].XValueType = ChartValueType.Date; 
        }

        public void addstogrser(string name)
        {

            //设置图案颜色
            StoGrachart.Series.Add(name);
            StoGrachart.Series[name].BorderWidth = 3;
            StoGrachart.Series[name].ChartType = SeriesChartType.Line;
            StoGrachart.Series[name].IsValueShownAsLabel = false;//是否顯示點的值
            StoGrachart.Series[name].XValueType = ChartValueType.Date;
        }

        public void initgrachart()
        {

        }


        public void initstochart()
        {

        }

        private void TaStochart_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        





    }

}
