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
        
            frm2.ShowDialog();
          
        }

        private void change_data_Load(object sender, EventArgs e)
        {

        }

    }
}
