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

                Display(panel3);
            }
            else if (false == show_StoGra)
                NotDisplay();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //搜索
        private void button1_Click(object sender, EventArgs e)
        {

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
            //testsad(personremainer.commo_data.filename, "sheet1");
            //導入文件代碼
            OptExcel optExcel = new OptExcel();
            optExcel.Open(personremainer.commo_data.filename);
            try
            {
                optExcel.ReadCell(2, 5);
                label1.Text = "11111";
            }
            catch
            {
                label1.Text = "0000";
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


        //導入部份代碼測試
        // <param name="ExcelStr">文件的全路径</param>
        // <param name="SheetName">Excel文档里的表名称</param>
        /*public void testsad(string ExcelStr, string SheetName)
        {
            OleDbConnection MyConn_E = new OleDbConnection();
            OleDbCommand MyComm_E = new OleDbCommand();
            OleDbDataAdapter MyAdap = new OleDbDataAdapter();

            DataSet MyTable = new DataSet();

            string Conn_Str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelStr + ";Extended Properties='Excel 8.0;HDR=Yes;'";

            MyConn_E.ConnectionString = Conn_Str;
            MyConn_E.Open();

            MyComm_E.Connection = MyConn_E;
            MyComm_E.CommandText = "select * from [" + SheetName + "$]";


            MyAdap.SelectCommand = MyComm_E;

            MyAdap.Fill(MyTable);
        }*/


    }
}
