﻿using System;
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
using Microsoft.Office.Interop.Excel;
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
            // show graph code
       //  GetNetStockData LoadGraph = new GetNetStockData();
        // KLineGraph.ImageLocation = @LoadGraph.GetNetGraph(1,"000001");
            Display(panel2);
            
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
          //optExcel.Close();
          readRnode(recordnode_hand);
        }
        //读取链表
        public void readRnode(OptrecordNode o)
        {

            if (o.next != null)
            {
                readRnode(o.next);
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




    }

}
