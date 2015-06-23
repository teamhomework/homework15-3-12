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


        //計算個人信息 數據
        string capital = "0";//本金
        float marketprice = 0;//市價
        float cash = 0;//現金
        float acctocash = 0;//帳戶總資產
        float chagra = 0;//浮動盈虧
        float grain = 0;
        float dailygrain = 0;



        //窗口狀態
        bool show_PerFor = false;//個人資信
        bool show_TakSto = false;//持倉情況
        bool show_StoInf = false;//股票資訊
        bool show_StoGra = false;//股票收益

        void Display(System.Windows.Forms.Panel target)
        {

            button1.Visible = true;
            textBox1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            target.Visible = true;
        }
        void NotDisplay()
        {
            button1.Visible = false;
            textBox1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            show_PerFor = false;
            show_StoGra = false;
            show_StoInf = false;
            show_TakSto = false;

        }





        string OwnName = null;
        string TableName = null;
        public Form1(string Input)
        {
          
            InitializeComponent();
            OwnName = Input;
            Not_Show_PerInf();
            AutoSize(this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            

            if (false == show_PerFor)
                show_PerFor = true;
            else if (true == show_PerFor)
                show_PerFor = false;

            if (true == show_PerFor)
            {
                splitContainer1.SplitterDistance = 200;
                CalPerData();
                Show_PerInf();
                
            }
            else if (false == show_PerFor)
            {
                Not_Show_PerInf();
                splitContainer1.SplitterDistance = 0;
            }
        }

        public void Show_PerInf()
        {
            label1.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
        }

        public void Not_Show_PerInf()
        {
            label1.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
        }
        



        private void 導入數據ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


        //持倉
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            NotDisplay();


            if (false == show_TakSto)
                show_TakSto = true;
            else if (true == show_TakSto)
                show_TakSto = false;
            if (true == show_TakSto)
            {
                //清掉舊記錄的顯示
                while (TaStodataView.Rows.Count != 0)
                {
                    TaStodataView.Rows.Clear();
                }
                if (TaStochart.Series.Count != 0)
                {
                    TaStochart.Series.Clear();
                }
                DataSet DS = new DataSet();
                DataBase DB = new DataBase();
                DS = DB.ReadDB(OwnName, "id", 0);
                int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
                for (int row = 0; row < ROWS; row++)
                {
                    show_take_sto(DS.Tables[0].Rows[row][0].ToString(), 1);
                    Draw_takchart(DS.Tables[0].Rows[row][0].ToString());
                }
                //顯示準備完後 顯示
                Display(panel1);
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
            if (false == show_StoInf)
                show_StoInf = true;
            else if (true == show_StoInf)
                show_StoInf = false;
            if (true == show_StoInf)
            {
                Display(panel2);
                if (personremainer.commo_data.stockcode != null)
                {
                    show_stock_data(personremainer.commo_data.stockcode);
                    show_take_sto_textbox(personremainer.commo_data.stockcode);
                    show_take_kgraph(personremainer.commo_data.stockcode);
                }
            }
            else if (false == show_StoInf)
                NotDisplay();
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {

            if (StoGrachart.Series.Count != 0)
            {
                StoGrachart.Series.Clear();
            }
            //        DateTime start = new DateTime(2015,3,1);
            //      int ConDay = 10;

            NotDisplay();

            if (false == show_StoGra)
                show_StoGra = true;
            else if (true == show_StoGra)
                show_StoGra = false;
            if (true == show_StoGra)
            {
                /*
                                DataSet DS1 = new DataSet();
                                DataSet DS2 = new DataSet();
                                DataSet DS3 = new DataSet();
                                DateTime Start = Convert.ToDateTime("2015-3-1");
                                DateTime End = Convert.ToDateTime("2015-3-31");
                                DS1 = CalGraPer(start,ConDay);
                                MessageBox.Show("1OK");
                                DS2 = CalMon(DS1,start,End);
                                DS3 = MixDS(DS2);
                                int R = DS3.Tables[0].Rows.Count;
                                addstogrser();
                                for (int row = 0; row < R; row++)
                                {
                                    //計算收益率
                                    //補全 沒交易日子的收益率
                                    //整合所有股票的合益率
                                    //排序
                                    DateTime Date = Convert.ToDateTime(DS3.Tables["GrainPer"].Rows[row][0].ToString());
                                    float GrainPer = float.Parse( DS3.Tables["GrainPer"].Rows[row][1].ToString());
                                    StoGrachart.Series[0].Points.AddXY(Date, GrainPer);
                                }
                                */
                Display(panel3);

            }
            else if (false == show_StoInf)
                NotDisplay();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //test

        }
        //搜索
        private void button1_Click(object sender, EventArgs e)
        {
            StoInc.Clear();
            StockDataInf.Clear();
            stockdataView.Rows.Clear();
            string StockNum = textBox1.Text;
            personremainer.commo_data.stockcode = textBox1.Text;
            try
            {
                personremainer.commo_data.stockcode = personremainer.commo_data.stockcode.Substring(0, 6);
                StockNum = personremainer.commo_data.stockcode;
            }
            catch
            {
            }
            //跳轉到股票資訊界面
            NotDisplay();
            show_StoInf = true;
            Display(panel2);
            show_stock_data(StockNum);
            show_take_sto_textbox(StockNum);
            show_take_kgraph(StockNum);
        }


        //搜索TEXT
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //增加交易記錄後
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(OwnName);
            frm2.label1.Text = personremainer.commo_data.StoName;
            frm2.ShowDialog();
            show_stock_data(personremainer.commo_data.stockcode);
            // personremainer.create_form.create_changeOpData();   
            //重算個人信息
            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            ClearPerData();
            DS = DB.ReadDB(OwnName, "id", 0);
            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
            for (int row = 0; row < ROWS; row++)
            {
                show_take_sto(DS.Tables[0].Rows[row][0].ToString(), 0);
            }
            CalPerData();
           
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
            if (true == optExcel.Open_Excel(personremainer.commo_data.filename))
            {

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
                GetNetStockData GNS = new GetNetStockData();
                opdata.CreateTable(OwnName);
                opdata.AddUserOp(OwnName,recordnode_hand);
                /*  DS = opdata.ReadDB("UserOp", "id");


                  ROW = int.Parse(DS.Tables[0].Rows.Count.ToString());
                  for (int row = 0; row < ROW; row++)
                  {
                      string getstocaode = DS.Tables[0].Rows[row][0].ToString();

                      //新增股票記錄
                      string stockdata = GNS.GetNetData(getstocaode);
                      string[] temp = GNS.TreatmentString(stockdata);
                      opdata.AddStockData(temp, getstocaode);
                  }
                  */
                toolStripMenuItem3.Enabled = true;
                toolStripMenuItem4.Enabled = true;
                toolStripMenuItem5.Enabled = true;
                ToolStripMenuItem6.Enabled = true;

                //顯示默認介面
                show_take_inf();

            }
        }

        public void show_take_inf()
        {
            while (TaStodataView.Rows.Count != 0)
            {
                TaStodataView.Rows.Clear();
            }
            if (TaStochart.Series.Count != 0)
            {
                TaStochart.Series.Clear();
            }

            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            DS = DB.ReadDB(OwnName, "id", 0);
            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
            for (int row = 0; row < ROWS; row++)
            {
                show_take_sto(DS.Tables[0].Rows[row][0].ToString(), 1);
                Draw_takchart(DS.Tables[0].Rows[row][0].ToString());
            }
            Display(panel1);
            
        }





        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (stockdataView[e.ColumnIndex, e.RowIndex].Value == "修改")
            {
                Form4 frm4 = new Form4(OwnName);


                //先傳數據給STATIC 再傳給文本
                personremainer.commo_data.opt = stockdataView[1, e.RowIndex].Value.ToString();
                personremainer.commo_data.qty = int.Parse(stockdataView[3, e.RowIndex].Value.ToString());
                personremainer.commo_data.DATE = stockdataView[0, e.RowIndex].Value.ToString();
                personremainer.commo_data.price = float.Parse(stockdataView[2, e.RowIndex].Value.ToString());

                frm4.textBox1.Text = personremainer.commo_data.qty.ToString();
                frm4.comboBox1.Text = personremainer.commo_data.opt;
                frm4.monthCalendar1.SelectionStart = Convert.ToDateTime(personremainer.commo_data.DATE);
                frm4.monthCalendar1.SelectionEnd = Convert.ToDateTime(personremainer.commo_data.DATE);
                frm4.textBox2.Text = personremainer.commo_data.price.ToString();
                
                frm4.ShowDialog();
               
                show_stock_data(personremainer.commo_data.stockcode);
            
                //重算個人信息
                DataBase DB = new DataBase();
                DataSet DS = new DataSet();
                ClearPerData();
                DS = DB.ReadDB(OwnName, "id", 0);
                int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
                
                for (int row = 0; row < ROWS; row++)
                {
                    show_take_sto(DS.Tables[0].Rows[row][0].ToString(), 0);
                }

                CalPerData();

            }
            else if (stockdataView[e.ColumnIndex, e.RowIndex].Value == "刪除")
            {

                if (MessageBox.Show("你希望刪除此條記錄嗎", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    DataBase DB = new DataBase();
                    string[] Date = new string[4];
                    string[] Type = new string[4];
                    Type[0] = "date";
                    Type[1] = "type";
                    Type[2] = "quantity";
                    Type[3] = "name";
                    Date[0] = stockdataView[0, e.RowIndex].Value.ToString();
                    Date[1] = stockdataView[1, e.RowIndex].Value.ToString();
                    Date[2] = stockdataView[3, e.RowIndex].Value.ToString();
                    //待改
                    if (true == CanChange(personremainer.commo_data.stockcode, Convert.ToDateTime(Date[0]), Date[0].ToString(), int.Parse(Date[2])))
                    {
                        Date[3] = personremainer.commo_data.StoName;
                        DB.changeDB(OwnName, 1, Type, Date);
                        show_stock_data(personremainer.commo_data.stockcode);
                        //重算個人信息
                        DataSet DS = new DataSet();
                        ClearPerData();
                        DS = DB.ReadDB(OwnName, "id", 0);
                        int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
                        for (int row = 0; row < ROWS; row++)
                        {
                            show_take_sto(DS.Tables[0].Rows[row][0].ToString(), 0);
                        }
                        CalPerData();
                    }
                    else
                    {
                        MessageBox.Show("非法操作");
                    }
                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            //personremainer.create_form.create_cash();
            Form3 fm3 = new Form3();
            fm3.ShowDialog();
            if (fm3.button1.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
               capital =fm3.textBox1.Text;
               fm3.Dispose();
               fm3.Close();
                DataBase DB = new DataBase();
                DataSet DS = new DataSet();
                ClearPerData();
                DS = DB.ReadDB(OwnName, "id", 0);
                int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
                for (int row = 0; row < ROWS; row++)
                {
                    show_take_sto(DS.Tables[0].Rows[row][0].ToString(), 0);
                }
                CalPerData();
            }
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
            DataSet DS = new DataSet();
            DS = DB.ReadDB(OwnName, "*", "id", stockcode, 1);
            if (DS.Tables[0].Rows.Count != 0)
            {
                personremainer.commo_data.StoName = DS.Tables[0].Rows[0][0].ToString();
            }
            if (stockdataView.Rows.Count != 0)
            {
                stockdataView.Rows.Clear();
            }
            //加列 日期 操作 價格 數量 稅率 傭金  修改 刪除 

            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
            for (int row = 0; row < ROWS; row++)
            {
                
                stockdataView.Rows.Add(DS.Tables[0].Rows[row][2].ToString(), DS.Tables[0].Rows[row][3].ToString(), DS.Tables[0].Rows[row][4].ToString(), DS.Tables[0].Rows[row][5].ToString(), DS.Tables[0].Rows[row][6].ToString(), DS.Tables[0].Rows[row][7].ToString());
              //  MessageBox.Show(stockdataView.Columns.Count.ToString());
            }
           
            if (DS.Tables[0].Rows.Count != 0)
            {
                personremainer.commo_data.StoName = DS.Tables[0].Rows[0][0].ToString();
            }
        }

        //股票信息 文本框內容
        public void show_take_sto_textbox(string stockcode)
        {
            if (stockcode.Length > 5)
                stockcode = stockcode.Substring(0, 6);
            GetNetStockData GNSD = new GetNetStockData();
            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            try
            {
                string d = GNSD.GetNetData(stockcode);
                string[] stoinf = GNSD.TreatmentString(d);

                if (stoinf[0].Length < 2)
                {
                    MessageBox.Show("查無此股");

                }
                else
                {

                    string T = stoinf[1];
                    string N = stoinf[3];
                    float Increase, priceT, priceN;
                    priceT = float.Parse(T);
                    priceN = float.Parse(N);
                    Increase = priceN - priceT;
                    StoDataName.Text = stoinf[0].ToString();
                    StoInc.Text = stoinf[3].ToString();
                    StockDataInf.Text = "股票名:" + stoinf[0] + "\r\n" + "股票編號:" + stockcode + "\r\n" + "今日開盤價:" + stoinf[1] + "\r\n" + "昨日收盤價:" + stoinf[2] + "\r\n" + "今日最高價:" + stoinf[4] + "\r\n" + "今日最低價:" + stoinf[5] + "\r\n" + "漲幅:" + Math.Round(Increase, 2) + "元";
                }

                //設數據
                personremainer.commo_data.StoName = stoinf[0];
                personremainer.commo_data.stockcode = stockcode;
            }
            catch (Exception err)
            {
                MessageBox.Show("連网失敗");
            }

        }

        //持倉信息 K圖
        public void show_take_kgraph(string stockcode)
        {
            GetNetStockData LoadGraph = new GetNetStockData();
            KLineGraph.ImageLocation = @LoadGraph.GetNetGraph(stockcode, 0);
        }

        //收益信息  需重新實現
        public void show_sto_gra(string stockcode)
        {

        }

        public void addtastoser(string name)
        {

            //设置图案颜色

            TaStochart.Series.Add(name);
            TaStochart.Series[name].BorderWidth = 3;
          //  TaStochart.Series[name].ChartType = SeriesChartType.StackedArea;
            TaStochart.Series[name].ChartType = SeriesChartType.Line;
            TaStochart.Series[name].IsValueShownAsLabel = false;//是否顯示點的值
            TaStochart.Series[name].XValueType = ChartValueType.Date;
        }

        public void addstogrser()
        {

            //设置图案颜色
            StoGrachart.Series.Add("總收益率");
            StoGrachart.Series["總收益率"].BorderWidth = 3;
            StoGrachart.Series["總收益率"].ChartType = SeriesChartType.Line;
            StoGrachart.Series["總收益率"].IsValueShownAsLabel = false;//是否顯示點的值
            StoGrachart.Series["總收益率"].XValueType = ChartValueType.Date;
        }




        private void TaStochart_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
           
        }






        //持倉信息  
        public void show_take_sto(string stockcode, int i)
        {
            //提取數據
            DataBase DB = new DataBase();
            GetNetStockData GNSD = new GetNetStockData();
            DataSet DS = new DataSet();

            float price = 0;
            int quantity = 0, holdquan = 0;
            //浮動盈虧 盈虧
            float chagra = 0, totgra = 0;
            float tax = 0, comm = 0, tcost = 0, cost = 0;
            float temgra = 0;
            string ttax, tcomm;

            DS = DB.ReadDB(OwnName, "*", "id", stockcode, 1);
            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
            //因為要計算持倉成本所以 由舊的記錄算起
            for (int row = 0; row < ROWS; row++)
            {
                ttax = DS.Tables[0].Rows[row][6].ToString();
                tcomm = DS.Tables[0].Rows[row][7].ToString();
                tax = float.Parse(ttax.Substring(0, ttax.Length - 1)) / 100;
                comm = float.Parse(tcomm.Substring(0, tcomm.Length - 1)) / 100;
                quantity = int.Parse(DS.Tables[0].Rows[row][5].ToString());
                price = float.Parse(DS.Tables[0].Rows[row][4].ToString());

                if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "买入")
                {
                    //买入
                    tcost = (holdquan * cost + (quantity * price * (1 + tax) * (1 + comm))) / (quantity + holdquan);
                    temgra = temgra - (quantity * price * (1 + tax) * (1 + comm));
                    holdquan += quantity;
                    cost = tcost;
                    if (holdquan == 0)
                    {
                        cost = 0;
                    }
                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖出")
                {
                    //卖出
                    tcost = (holdquan * cost - (quantity * price * (1 - tax) * (1 - comm))) / (quantity - holdquan);
                    temgra = temgra + (quantity * price * (1 - tax) * (1 - comm));
                    holdquan = holdquan - quantity;
                    cost = tcost;
                    if (holdquan == 0)
                    {
                        cost = 0;
                    }
                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "补仓")
                {
                    //补仓
                    tcost = (holdquan * cost - (quantity * price * (1 + tax) * (1 + comm))) / (quantity + holdquan);
                    temgra = temgra - (quantity * price * (1 + tax) * (1 + comm));

                    holdquan = holdquan + quantity;
                    cost = tcost;
                    if (holdquan == 0)
                    {
                        cost = 0;
                    }
                }
                else if (DS.Tables[0].Rows[row][3].ToString().Substring(0, 2) == "卖空")
                {
                    //卖空 
                    tcost = (holdquan * cost + (quantity * price * (1 - tax) * (1 - comm))) / (quantity - holdquan);
                    temgra = temgra + (quantity * price * (1 - tax) * (1 - comm));
                    holdquan = holdquan - quantity;
                    cost = tcost;
                    if (holdquan == 0)
                    {
                        cost = 0;
                    }
                }
            }

            float markprice = 0;
            try
            {
                string d = GNSD.GetNetData(stockcode);
                string[] nowprice = GNSD.TreatmentString(d);
                if (holdquan > 0)
                {
                    markprice = float.Parse(nowprice[6]) * holdquan;
                    chagra = (float.Parse(nowprice[6]) - cost) / cost;
                    totgra = chagra * holdquan;
                }
                else if (holdquan < 0)
                {
                    markprice = float.Parse(nowprice[6]) * holdquan;
                    chagra = -(float.Parse(nowprice[6]) - cost) / cost;
                    totgra = chagra * holdquan;
                }
                else if (holdquan == 0)
                {
                    markprice = 0;
                    chagra = 0;
                    totgra = temgra;
                }
                marketprice += markprice;
                chagra += chagra;
                grain += totgra;
                dailygrain += holdquan * (float.Parse(nowprice[6]) - float.Parse(nowprice[2]));
                if (1 == i)
                    TaStodataView.Rows.Add(DS.Tables[0].Rows[0][0].ToString(), nowprice[6], cost, holdquan, markprice, totgra, chagra);
            }
            catch (Exception err)
            {
                MessageBox.Show("連网失敗");
            }
        }

/*
        //畫持倉圖
        //因為要做出堆積圖 考慮改成用DATASET實現
        public void Draw_takchart()
        {
            //重做思路 
            //儲到DATASET 每個股票一個表
            //再新創一個DATASET 整合所有 股票數量 排序
            //畫圖

            //提取數據
            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            DataSet StockDS = new DataSet();
            DataSet EachStock = new DataSet();
            DataSet AllStock = new DataSet();
            //上2DS ADD列
            DS = DB.ReadDB("UserOp", "id", 0);//返回股票編號
            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());

            for (int StockIndex = 0; StockIndex < ROWS; StockIndex++)
            {
                string StockCode =DS.Tables[0].Rows[StockIndex][0].ToString();
                StockDS = DB.ReadDB("UserOp", "*", "id", StockCode, 1);
                string StockName = StockDS.Tables[0].Rows[0][0].ToString();
                int row =  StockDS.Tables[0].Rows.Count ;
                for(int i = 0; i < row;i++)
                {
                    //計量 入DS


                }


            }


            string StrDate;
            int holdquan = 0, quantity = 0;
            //因為要順序畫圖 所以由舊記錄畫起
            for (int row = 0; row < ROWS; row++)
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
                //畫持倉圖

                 StrDate = DS.Tables[0].Rows[row][2].ToString();
                 DateTime Date = Convert.ToDateTime(StrDate);
            }
        }*/




        //畫持倉圖
        //因為要做出堆積圖 考慮改成用DATASET實現
        public void Draw_takchart(string stockcode)
        {
            //提取數據
            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            DataSet TempDS = new DataSet();
            DS = DB.ReadDB(OwnName, "*", "id", stockcode, 1);
            string StrDate;
            string stoname = null;
            int holdquan = 0, quantity = 0;
            //畫圖
           // if (DS.Tables[0].Rows.Count != 0)
        //    {
                stoname = DS.Tables[0].Rows[0][0].ToString();
                addtastoser(stoname);
                TempDS.Tables.Add(stoname);
                TempDS.Tables[stoname].Columns.Add("DATA",typeof(DateTime));
                TempDS.Tables[stoname].Columns.Add("quantity");
                DataRow tempRow = TempDS.Tables[stoname].NewRow();
                tempRow["DATA"] = Convert.ToDateTime("2015-3-1");
                tempRow["quantity"] = 0;
                TempDS.Tables[stoname].Rows.Add(tempRow);
     //       }
            int ROWS = int.Parse(DS.Tables[0].Rows.Count.ToString());
            //因為要順序畫圖 所以由舊記錄畫起
            for (int row = 0; row < ROWS; row++)
            {
                DataRow dr = TempDS.Tables[stoname].NewRow();
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

                //檢查
                bool IsExist = false;
                int SameRow = 0;
                int MaxRow =TempDS.Tables[stoname].Rows.Count;
                StrDate = DS.Tables[0].Rows[row][2].ToString();
                DateTime CheckDate = Convert.ToDateTime(StrDate);
                for (int CheckRow = 0; CheckRow < MaxRow; CheckRow++)
                {

                    if( CheckDate ==  Convert.ToDateTime(TempDS.Tables[stoname].Rows[CheckRow][0].ToString()))
                    {
                        IsExist =true;
                        SameRow = CheckRow;
              
                    }
                }

                    if (IsExist == true)
                    {
                        TempDS.Tables[stoname].Rows[SameRow][0] = TempDS.Tables[stoname].Rows[SameRow][0];
                        TempDS.Tables[stoname].Rows[SameRow][1] = holdquan;
                        IsExist = false;
                    }
                    else if(IsExist ==false)
                    {
                        dr["DATA"] = Convert.ToDateTime(StrDate);
                        dr["quantity"] = holdquan;
                        TempDS.Tables[stoname].Rows.Add(dr);
                    }
            }
            //畫持倉圖
            int TempIndex = TempDS.Tables[stoname].Rows.Count;
            for (int Trow = 0; Trow < TempIndex; Trow++)
            {
                StrDate = TempDS.Tables[stoname].Rows[Trow][0].ToString();
                int HoldQuan = int.Parse(TempDS.Tables[stoname].Rows[Trow][1].ToString());
                StrDate = StrDate.Replace("/","-");
                DateTime Date = Convert.ToDateTime(StrDate);
                TaStochart.Series[stoname].Points.AddXY(Date, HoldQuan);

            }
            
        }




        public void CalPerData()
        {


            acctocash = float.Parse(capital) + grain;
            cash = acctocash - marketprice;
            label1.Text = "本金:" + Math.Round(float.Parse(capital), 2);
            label7.Text = "現金:" + Math.Round(cash, 2);
            label3.Text = "浮動盈虧(%):" + Math.Round(chagra, 2);
            label4.Text = "盈虧:" + Math.Round(grain, 2);
            label5.Text = "帳戶總資產" + Math.Round(acctocash, 2);
            label6.Text = "市值:" + Math.Round(marketprice, 2);
            label2.Text = "日盈虧:" + Math.Round(dailygrain, 2);
        }

        public void ClearPerData()
        {
            chagra = 0;
            marketprice = 0;
            grain = 0;
            dailygrain = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetNetStockData GNDS = new GetNetStockData();
            KLineGraph.ImageLocation = @GNDS.GetNetGraph(personremainer.commo_data.stockcode, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetNetStockData GNDS = new GetNetStockData();
            if (personremainer.commo_data.stockcode != null)
                KLineGraph.ImageLocation = @GNDS.GetNetGraph(personremainer.commo_data.stockcode, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GetNetStockData GNDS = new GetNetStockData();
            if (personremainer.commo_data.stockcode != null)
                KLineGraph.ImageLocation = @GNDS.GetNetGraph(personremainer.commo_data.stockcode, 2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetNetStockData GNDS = new GetNetStockData();
            if (personremainer.commo_data.stockcode != null)
                KLineGraph.ImageLocation = @GNDS.GetNetGraph(personremainer.commo_data.stockcode, 3);
        }



        private void TaStodataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = TaStodataView.CurrentRow.Index;
            string stockname = TaStodataView[0, row].Value.ToString();
            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            DS = DB.ReadDB(OwnName, "id", "name", stockname, 1);
            if (DS.Tables[0].Rows.Count != 0)
            {
                personremainer.commo_data.stockcode = DS.Tables[0].Rows[0][0].ToString();
            }
            NotDisplay();
            show_StoInf = true;
            Display(panel2);
            show_stock_data(personremainer.commo_data.stockcode);
            show_take_sto_textbox(personremainer.commo_data.stockcode);
            show_take_kgraph(personremainer.commo_data.stockcode);
        }

        private void StoGralistBox_SelectedIndexChanged(object sender, EventArgs e)
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
            DS = DB.ReadDB(OwnName, "*", "id", stockcode, 1);
            int ROWS = DS.Tables[0].Rows.Count;
            for (int row = 0; row < ROWS; row++)
            {
                quantity = int.Parse(DS.Tables[0].Rows[row][5].ToString());

                if (Date == (DateTime)DS.Tables[0].Rows[row][2])
                {
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

        private void StockDataInf_TextChanged(object sender, EventArgs e)
        {

        }


        //計算收益率
        //股票收益率= 收益额 /原始投资额　其中：收益额=收回投资额+全部股利-(原始投资额+全部佣金+税款)
        // 收益率=(當前價-買價)% 
        //計法  (收盤 -成本)/成本
        public DataSet CalGraPer(DateTime start, int ConDay)
        {
            //讀記錄
            //計算每天收益
            //維護 DATASET  /  DATATABLE 集合
            DataBase DB = new DataBase();
            DataSet DS = new DataSet();
            DataSet DBS = new DataSet();
            DataSet GrainGraph = new DataSet("my");
            GetNetStockData GNDS = new GetNetStockData();

            bool IsExist = false;
            bool IsExistTabke = false;
            int DSrow = 0;

            DBS = DB.ReadDB(OwnName, "id", 0);

            int ROWS = int.Parse(DBS.Tables[0].Rows.Count.ToString());
            for (int row = 0; row < ROWS; row++)
            {
                int holdquan = 0, quantity = 0;
                float GrainPer = 0, Grain = 0, InPut = 0, hisprice = 0, endprice = 0;

                DS = DB.ReadDB(OwnName, "*", "id", DBS.Tables[0].Rows[row][0].ToString(), 1);
                int RCrow = DS.Tables[0].Rows.Count;
                string stockcode = DBS.Tables[0].Rows[row][0].ToString();
                int Rows = int.Parse(DS.Tables[0].Rows.Count.ToString());
                for (int R = 0; R < RCrow; R++)
                {
                    string DATA = DS.Tables[0].Rows[R][2].ToString();
                    DATA = DATA.Replace("/", "-");
                    quantity = int.Parse(DS.Tables[0].Rows[R][5].ToString());
                    hisprice = float.Parse(DS.Tables[0].Rows[R][4].ToString());
                    //未考慮休息日
                    endprice = float.Parse(GNDS.hispri(stockcode, DATA));
                    if (DS.Tables[0].Rows[R][3].ToString().Substring(0, 2) == "买入")
                    {
                        //买入
                        InPut += quantity * hisprice;
                        holdquan += quantity;

                    }
                    else if (DS.Tables[0].Rows[R][3].ToString().Substring(0, 2) == "卖出")
                    {
                        //卖出
                        Grain = quantity * hisprice;
                        InPut -= Grain;
                        holdquan -= quantity;

                    }

                    if (holdquan != 0)
                    {
                        GrainPer = ((holdquan * endprice - InPut) / InPut) * 100;
                    }
                    else
                    {
                        GrainPer = 0;
                    }
                    //維護DS
                    int ROW2 = GrainGraph.Tables.Count;
                    for (int i = 0; i < ROW2; i++)
                    {
                        string compstockcode = GrainGraph.Tables[i].ToString();
                        compstockcode = compstockcode.Replace(" ", "");
                        if (stockcode == compstockcode)
                        {
                            IsExistTabke = true;
                        }
                    }

                    if (IsExistTabke == false)
                    {
                        GrainGraph.Tables.Add(stockcode);
                        GrainGraph.Tables[stockcode].Columns.Add("DATA", typeof(DateTime));
                        GrainGraph.Tables[stockcode].Columns.Add("Percent");
                        GrainGraph.Tables[stockcode].Columns.Add("hold");
                        GrainGraph.Tables[stockcode].Columns.Add("cost");

                    }
                    DataRow dr = GrainGraph.Tables[stockcode].NewRow();
                    //賦值
                    int GGrow = GrainGraph.Tables[stockcode].Rows.Count;

                    for (int ROW = 0; ROW < GGrow; ROW++)
                    {

                        if (DATA == GrainGraph.Tables[stockcode].Rows[ROW][0])
                        {
                            IsExist = true;
                            DSrow = ROW;
                        }
                    }
                    if (IsExist == false)
                    {
                        dr["data"] = DATA;
                        dr["percent"] = GrainPer;
                        dr["hold"] = holdquan;
                        dr["cost"] = InPut;
                        GrainGraph.Tables[stockcode].Rows.Add(dr);
                    }
                    else//維護
                    {
                        GrainGraph.Tables[stockcode].Rows[DSrow][1] = GrainPer + float.Parse(GrainGraph.Tables[stockcode].Rows[DSrow][1].ToString());
                        GrainGraph.Tables[stockcode].Rows[DSrow][2] = holdquan;
                        GrainGraph.Tables[stockcode].Rows[DSrow][3] = InPut;
                    }
                    IsExist = false;
                }
                IsExistTabke = false;
            }
            return GrainGraph;
        }
        //未測試
        public DataSet MixDS(DataSet Input)
        {
            DataSet DS = Input;
            DataSet Relut = new DataSet();
            bool IsExist = false;
            Relut.Tables.Add("GrainPer");
            Relut.Tables["GrainPer"].Columns.Add("DATA", typeof(DateTime));
            Relut.Tables["GrainPer"].Columns.Add("Percent");
            Relut.Tables["GrainPer"].Columns.Add("hold");
            Relut.Tables["GrainPer"].Columns.Add("cost");
            //++cot
            int TableIndex = DS.Tables.Count;
            for (int i = 0; i < TableIndex; i++)
            {

                int ROWS = DS.Tables[i].Rows.Count;
                for (int row = 0; row < ROWS; row++)
                {
                    DataRow dr = DS.Tables[i].NewRow();
                    //找到同DATA +PER
                    int NowRow = Relut.Tables["GrainPer"].Rows.Count;
                    for (int ROW = 0; ROW < NowRow; ROW++)
                    {
                        if (Relut.Tables["GrainPer"].Rows[ROW][0].ToString() == DS.Tables[i].Rows[row][0].ToString())
                        {
                            Relut.Tables["GrainPer"].Rows[ROW][1] = float.Parse(Relut.Tables["GrainPer"].Rows[ROW][1].ToString()) + float.Parse(DS.Tables[i].Rows[row][1].ToString());
                            IsExist = true;
                        }
                    }

                    if (IsExist == false)
                    {

                        dr["DATA"] = DS.Tables[i].Rows[row][0];
                        dr["Percent"] = DS.Tables[i].Rows[row][1];
                        dr["hold"] = DS.Tables[i].Rows[row][2];
                        //   dr["cost"] = //MIX 等下計;
                        Relut.Tables["GrainPer"].Rows.Add(dr.ItemArray);
                    }
                    IsExist = false;
                }
            }
            //排序
            DataRow[] rows = Relut.Tables["GrainPer"].Select("", "DATA Asc");
            DataTable table = Relut.Tables["GrainPer"].Clone();
            for (int irow = 0; irow < rows.Length; irow++)
            {
                DataRow DRow = table.NewRow();
                DRow.ItemArray = rows[irow].ItemArray;
                table.Rows.Add(DRow);
            }
            Relut.Tables.Remove("GrainPer");
            Relut.Tables.Add(table);



            return Relut;
        }

        public DataSet CalMon(DataSet DS, DateTime Start, DateTime End)
        {
            DataSet relut = new DataSet();
            GetNetStockData GNDS = new GetNetStockData();
            //讀表 
            //計到3月底
            //順便排序?
            //返回DATASET
            int TableIndex = DS.Tables.Count;
            for (int i = 0; i < TableIndex; i++)
            {

                string TableName = DS.Tables[i].ToString();
                int UpperRow = DS.Tables[i].Rows.Count;
                //排序 升序
                DataRow[] rows = DS.Tables[TableName].Select("", "DATA Asc");
                DataTable table = DS.Tables[TableName].Clone();
                for (int irow = 0; irow < rows.Length; irow++)
                {
                    DataRow DRow = table.NewRow();
                    DRow.ItemArray = rows[irow].ItemArray;
                    table.Rows.Add(DRow);
                }
                DS.Tables.Remove(TableName);
                DS.Tables.Add(table);

                //補全非交易日
                //日期在上下限內
                //(數量*現收盤價 - 成本) /成本 *100%
                int Trow = 0;
                DateTime DT = Start;
                int TUpper = DS.Tables[TableName].Rows.Count;
                while (DT <= End)
                {
                    if (Convert.ToDateTime(DS.Tables[TableName].Rows[Trow][0].ToString()) > DT)
                    {
                        DataRow DR = DS.Tables[TableName].NewRow();
                        DR["DATA"] = DT;
                        DR["Percent"] = "0";
                        DR["hold"] = "0";
                        DR["cost"] = "0";
                        DS.Tables[TableName].Rows.Add(DR.ItemArray);
                        //TempDS.Tables[0].Rows.Add(DR.ItemArray);

                    }
                    else if (Convert.ToDateTime(DS.Tables[TableName].Rows[Trow][0].ToString()) != DT)
                    {
                        DataRow DR = DS.Tables[TableName].NewRow();
                        DR["DATA"] = DT;
                        float price = float.Parse(GNDS.hispri(TableName, DT.ToString()));
                        string str = price.ToString().Substring(0, 1);

                        if (int.Parse(str) == 0 || int.Parse(DS.Tables[TableName].Rows[Trow][2].ToString()) <= 0)
                        {
                        }
                        else
                        {
                            //成本 =DS.Tables[TableName].Rows[Trow][3]
                            DR["Percent"] = (price * int.Parse(DS.Tables[TableName].Rows[Trow][2].ToString()) - float.Parse(DS.Tables[TableName].Rows[Trow][2].ToString())) / float.Parse(DS.Tables[TableName].Rows[Trow][2].ToString()) * 100;
                            DR["hold"] = DS.Tables[TableName].Rows[Trow][2];

                            DS.Tables[TableName].Rows.Add(DR.ItemArray);
                            //  TempDS.Tables[0].Rows.Add(DR.ItemArray);
                        }
                    }
                    else if (Convert.ToDateTime(DS.Tables[TableName].Rows[Trow][0].ToString()) == DT)
                    {
                        DataRow DR = DS.Tables[TableName].NewRow();
                        DR["DATA"] = DT;
                        DR["Percent"] = DS.Tables[TableName].Rows[Trow][1];
                        DR["hold"] = DS.Tables[TableName].Rows[Trow][2];
                        DR["cost"] = DS.Tables[TableName].Rows[Trow][3];
                        DS.Tables[TableName].Rows.Add(DR.ItemArray);
                        if (Trow < TUpper - 1)
                        {
                            Trow++;
                        }
                    }
                    DT = DT.AddDays(1);

                }
                //再排序
                DataRow[] Rows = DS.Tables[TableName].Select("", "DATA Asc");
                DataTable Table = DS.Tables[TableName].Clone();
                for (int irow = 0; irow < Rows.Length; irow++)
                {
                    DataRow DRow = Table.NewRow();
                    DRow.ItemArray = Rows[irow].ItemArray;
                    Table.Rows.Add(DRow);
                }
                DS.Tables.Remove(TableName);
                DS.Tables.Add(Table);

            }
            return DS;
        }

        private void DrawGrainChart_Click(object sender, EventArgs e)
        {
            if (StoGrachart.Series.Count != 0)
            {
                StoGrachart.Series.Clear();
            }

            DataSet DS1 = new DataSet();
            DataSet DS2 = new DataSet();
            DataSet DS3 = new DataSet();
            string startdate = StartDate.Text;
            string enddate = EndDate.Text;
            if (Convert.ToDateTime(enddate) > Convert.ToDateTime(startdate))
            {
                startdate = startdate.Replace("/", "-");
                enddate = enddate.Replace("/", "-");
                DateTime Start = Convert.ToDateTime(startdate);
                DateTime End = Convert.ToDateTime(Convert.ToDateTime(EndDate.Text));
                int ConDay = int.Parse((End - Start).TotalDays.ToString());
                DS1 = CalGraPer(Start, ConDay);
                DS2 = CalMon(DS1, Start, End);
                DS3 = MixDS(DS2);
                int R = DS3.Tables[0].Rows.Count;
                addstogrser();
                for (int row = 0; row < R; row++)
                {
                    //計算收益率
                    //補全 沒交易日子的收益率
                    //整合所有股票的合益率
                    //排序
                    DateTime Date = Convert.ToDateTime(DS3.Tables["GrainPer"].Rows[row][0].ToString());
                    float GrainPer = float.Parse(DS3.Tables["GrainPer"].Rows[row][1].ToString());
                    StoGrachart.Series[0].Points.AddXY(Date, GrainPer);
                }
            }
            else
            {
                MessageBox.Show("結束日期大於開始日期");
            }
        }


        //重寫方法 點關閉  不釋放 只隱藏
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }



        public void AutoSize(Form frm)
        {
            frm.Tag = frm.Width.ToString() + "," + frm.Height.ToString();
            frm.SizeChanged += new EventHandler(frm_SizeChanged);

        }
        void frm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                string[] tmp = ((Form)sender).Tag.ToString().Split(',');
                float width = (float)((Form)sender).Width / (float)Convert.ToInt16(tmp[0]);
                float heigth = (float)((Form)sender).Height / (float)Convert.ToInt16(tmp[1]);

                ((Form)sender).Tag = ((Form)sender).Width.ToString() + "," + ((Form)sender).Height;

                foreach (Control control in ((Form)sender).Controls)
                {
                    control.Scale(new SizeF(width, heigth));

                }
            }
            catch (Exception err)
            {
            }
        }










    }
}



