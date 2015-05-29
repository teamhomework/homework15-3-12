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
    class OptExcel
    {

        string[] SheetName=new string[10];
        DataTable MyTable = new DataTable();
        DataSet MySet = new DataSet();//表
        //導入部份代碼測試
        // <param name="ExcelStr">文件的全路径</param>
        // <param name="SheetName">Excel文档里的表名称</param>
        public bool Open_Excel(string ExcelStr)
        {  
                OleDbConnection MyConn_E = new OleDbConnection();//連接
                OleDbCommand MyComm_E = new OleDbCommand();
                OleDbDataAdapter MyAdap = new OleDbDataAdapter();
               
                
            int TableNum=0;
             try   
             {
            //連接EXCEL  IMEX = 1 readonly; = 0 writer only; = 2  read+writer   
                string Conn_Str = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + ExcelStr + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                MyConn_E.ConnectionString = Conn_Str;
            //打開EXCEL
                MyConn_E.Open();
                MyTable = MyConn_E.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //獲取表名 
                foreach (DataRow row in MyTable.Rows)
                {

                    //遍历各Sheet的名称
                SheetName[TableNum] =(string) row["TABLE_NAME"];
              //  MessageBox.Show(SheetName[TableNum]);
                TableNum++;
                }
        
                MyComm_E.Connection = MyConn_E;
                MyComm_E.CommandText = "select * from ["+SheetName[0]+"]" ;
               // MessageBox.Show(MyComm_E.CommandText);//測試用
                MyAdap.SelectCommand = MyComm_E;

                MyAdap.Fill(MySet);
                MyConn_E.Close();

                return true;
        }
                       catch (Exception err)
            {
                MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }


        public string Read_ExData(int row, int col)
        {
            try
            {

                //string ss = MySet.Tables[0].Rows[row][col].ToString();//測試用
                //MessageBox.Show(ss);//測試用
                return MySet.Tables[0].Rows[row][col].ToString();
            }
            catch (Exception err)
            {
                return "";
            }

        }
    
    
    }
}
