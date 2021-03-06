﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;


//SELECT     name, id, date, type, price, quantity, taxrate, commissionFROM         UserOpWHERE     (name = '伊利股份 ')ORDER BY date

namespace personremainer
{
    class DataBase
    {
        string consqlser = "server = .\\SQLEXPRESS;integrated security=SSPI;database=test";
        
        //創表
        public void CreateTable()
        {
            SqlConnection conn = new SqlConnection(consqlser);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.DATABASE, "打开数据库成功");
            }
            string droptable = "DROP TABLE UserOp";
            try
            {
                SqlCommand droptablecomm =new SqlCommand(droptable,conn);
                droptablecomm.ExecuteNonQuery();
                Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.DATABASE, "删除表UserOp成功");
            }
            catch(Exception err)
            {
                Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.DATABASE, "删除表UserOp出错");
            }

            string createuseroptabble = "CREATE TABLE UserOp" + "(name CHAR(10),id INT, date datetime, type  CHAR(10),price float,quantity int,taxrate varchar(10),commission varchar(10))";
            string createstotable = "CREATE TABLE StockInf" + "( name char(10)," + "id int CONSTRAINT PKeyid PRIMARY KEY,"  +  "openingpriceT float,closepriceY float,maxprice float,minprice float,increase varchar(max) )";
            
            SqlCommand comsql = new SqlCommand(createuseroptabble, conn);
            SqlCommand comsql2 = new SqlCommand(createstotable,conn);
            Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.DATABASE, "创建表用戶操作表股票資料表");
            try
            {
                comsql.ExecuteNonQuery();
                
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message.ToString());
            }
            try
            {
                comsql2.ExecuteNonQuery();
            }
            catch (Exception err)
            {
            }

            conn.Close();
        }
        //向用戶操作表增加數據
        public void AddUserOp(OptrecordNode UserOp_hand)
        {
            OptrecordNode UserOp = UserOp_hand;
            SqlConnection conn = new SqlConnection(consqlser);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            while (UserOp != null && UserOp.stockcode !=null)
            {
                string insertsql = "INSERT INTO UserOP(name,id, date, type ,price ,quantity ,taxrate ,commission)" + "VALUES ( " + "'" + UserOp.stockname + "','" + UserOp.stockcode + "','" + UserOp.optdate + "','" + UserOp.opttype + "','" + UserOp.stockprice + "','" + UserOp.stocknumber + "','" + UserOp.rate + "','" + UserOp.commission + "'" + ")";

                SqlCommand sqlcomm = new SqlCommand(insertsql, conn);
                try
                {
                    sqlcomm.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message.ToString());
                    
                }
                UserOp = UserOp.next;
            }
            Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.DATABASE, "向用户操作表中添加操作信息");
            conn.Close();

        }




        //向股票資料表增加數據
        public void AddStockData(string[] StockInf,string Stockcode)
        {


            SqlConnection conn = new SqlConnection(consqlser);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            char[] test = Stockcode.ToArray();
            if (test.LongLength < 6)
            {
                Stockcode = "00" + Stockcode;
            }
            string T = StockInf[1];
            string N = StockInf[3];
            float Increase,priceT,priceN;
            priceT =float.Parse( T);
            priceN = float.Parse(N);
            Increase = priceN - priceT;
     
      

            string commsql =null;
            //檢查股票是否已存 如果是則更新 否則 插入新記錄
            DataSet ds = ReadDB("StockInf", "id", "id", Stockcode,0);
           
            if (ds.Tables[0].Rows.Count.ToString() == "0")
            {
                commsql = "INSERT INTO StockInf(name , id ,openingpriceT,closepriceY ,maxprice ,minprice ,increase  )" + "VALUES ( " + "'" + StockInf[0] + "','" + Stockcode + "','" + StockInf[1] + "','" + StockInf[2] + "','" + StockInf[4] + "','" + StockInf[5] + "','" + Increase + "'" + ")";
            }
            else
            {
             //  commsql = "update StockInf set " + " name = " + "'" + StockInf[0]+ "'," + " id = " + "'" + StockInf +"'," + " openingpriceT = " + "'" + StockInf[1] + "'," + "closepriceY = " + "'" + StockInf[2] + "'," + "maxprice = " + "'" + StockInf[4] + "'," + "minprice = " + "'" + StockInf[5] + "'," + "increase = " + "'" +int.Parse(Stockcode) + "'" + "where " + "( id = " + "'" +int.Parse(Stockcode) + "'" + ")";          
                commsql = "update StockInf set " + " name = " + "'" + StockInf[0] + "'," + " id = " + "'" + Stockcode + "'," + " openingpriceT = " + "'" + StockInf[1] + "'," + "closepriceY = " + "'" + StockInf[2] + "'," + "maxprice = " + "'" + StockInf[4] + "'," + "minprice = " + "'" + StockInf[5] + "'," + "increase = " + "'" + Increase+ "'" + "where " + "( id = " + "'" + Stockcode + "'" + ")";          
          
            
            
            }  

                SqlCommand sqlcomm = new SqlCommand(commsql, conn);
                try
                {
                    sqlcomm.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message.ToString());
                }
                //Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.DATABASE, "添加股票信息");
                conn.Close();
        }
        


        //讀數據庫
        public DataSet ReadDB(string tablename, string search)
        {
            SqlConnection conn = new SqlConnection(consqlser);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {
                string searchsql;
                if (search != "*")
                {
                    searchsql = " select" + "\"" + search + "\"" + "from" + "\"" + tablename + "\"" +" ORDER BY date ";
                }
                else
                {
                    searchsql = " select * from" + "\"" + tablename + "\"" + " ORDER BY date ";
                }
                SqlCommand comm = new SqlCommand(searchsql, conn);
                SqlDataAdapter sda = new SqlDataAdapter();

                sda.SelectCommand = comm;
                DataSet DS = new DataSet();

                sda.Fill(DS);
                conn.Close();
                Log.WriteLog(LOGLEVEL.DEBUG, LOGTYPE.DATABASE, "读取数据库信息");
                return DS;
            }
            catch (Exception err)
            {
                return null;
            }
           

        }
        //重載 讀數據字函數
        public DataSet ReadDB(string tablename, string search, string condition,string vaule,int i)
        {
            SqlConnection conn = new SqlConnection(consqlser);
            conn.Close();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string searchsql = null;
            try
            {
                if (search != "*"&&i==1)
                {
                    searchsql = " select" + "\"" + search + "\"" + "from" + "\"" + tablename + "\"" + "where" + "(\"" + condition + "\"" + "=" + "'" + vaule + "'" + ")" + " ORDER BY date ";
                    
                }
                else if (search == "*" && i == 1)
                {
                    searchsql = " select * from" + "\"" + tablename + "\"" + "where" + "(\"" + condition + "\"" + "=" + "'" + vaule + "'" + ")" +" ORDER BY date ";
                    
      
                }

                if (search != "*" && i == 0)
                {
                    searchsql = " select" + "\"" + search + "\"" + "from" + "\"" + tablename + "\"" + "where" + "(\"" + condition + "\"" + "=" + "'" + vaule + "'" + ")";
                    
                }
                else if (search == "*" && i == 0)
                {
                    searchsql = " select * from" + "\"" + tablename + "\"" + "where" + "(\"" + condition + "\"" + "=" + "'" + vaule + "'" + ")" ;
                    

                }
                SqlCommand comm = new SqlCommand(searchsql, conn);
                SqlDataAdapter sda = new SqlDataAdapter();

                sda.SelectCommand = comm;
                DataSet DS = new DataSet();

                sda.Fill(DS);
                conn.Close();
                return DS;
            }
            catch (Exception err)
            {
                return null;
            }
          
        }

        //重載 讀數據庫 
        public DataSet ReadDB(string tablename, string search,int i)
        {
            SqlConnection conn = new SqlConnection(consqlser);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {
                string searchsql;

                if (search != "*")
                {
                    searchsql = " select distinct " + "\"" + search + "\"" + "from" + "\"" + tablename + "\"";
                }
                else
                {
                    searchsql = " select * from" + "\"" + tablename + "\"" ;
                }
                SqlCommand comm = new SqlCommand(searchsql, conn);
                SqlDataAdapter sda = new SqlDataAdapter();

                sda.SelectCommand = comm;
                DataSet DS = new DataSet();

                sda.Fill(DS);
                conn.Close();
                return DS;
            }
            catch (Exception err)
            {
                return null;
            }


        }


        //插入記錄
        //"INSERT INTO StockInf(name , id ,openingpriceT,closepriceY ,maxprice ,minprice ,increase  )" + "VALUES ( " + "'" + StockInf[0] + "','" + Stockcode + "','" + StockInf[1] + "','" + StockInf[2] + "','" + StockInf[4] + "','" + StockInf[5] + "','" + Increase + "'" + ")";
            


        //修改記錄
        //UPDATE    UserOpSET              id = 3 WHERE     (id = 601398)

        //刪除記錄
     //   DELETE FROM UserOp WHERE     (id = 3)
        // op=0 插,op=1 刪,op=2 改
        public bool changeDB(int op, string[] search, string[] value)
        {

            SqlConnection conn = new SqlConnection(consqlser);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {
                string commsql = null;
                if (0 == op)
                {

                    //已完成
                    commsql = "INSERT INTO userop(name , id ,date ,type ,price ,quantity ,taxrate , commission  )" + "VALUES ( " + "'" + value[0] + "','" + value[1] + "','" + value[2] + "','" + value[3] + "','" + value[4] + "','" + value[5] + "','" + value[6] + "','" + value[7]  + "'"+")";


                }

                            //刪除記錄
                //   DELETE FROM UserOp WHERE     (id = 3) DATA
                else if (1 == op)
                {//已完成 
                    //DELETE FROM UserOp WHERE     (id = '601169') AND (type = '买入') AND (price = '10.69')
                    commsql = "DELETE FROM UserOp WHERE (" + "\"" + search[0] + "\"" + "=" + "'" + value[0] + "'" + ") AND (" + "\"" + search[1] + "\"" + "=" + "'" + value[1] + "'" + ") AND (" + "\"" + search[2] + "\"" + "=" + "'" + value[2] + "'" + ") AND (" + "\"" + search[3] + "\"" + "=" + "'" + value[3] + "'" + ") ";
                 
                }
                else if (2 == op)
                {
                    //已完成
                    commsql = "UPDATE UserOp SET name =" + "'" + value[4] + "',"  + " id =" + "'" + value[5] + "'," + " date =" + "'" + value[6] + "'," + " type = " + "'" + value[7] + "'," + " price =" + "'" + value[8] + "'," + " quantity =" + "'" + value[9] + "'," + " taxrate =" + "'" + value[10] + "'," + " commission =" + "'" + value[11] +"'" + "WHERE (" +  search[0] +  "=" + "'" + value[0] + "'" + ") AND ("  + search[1] + "=" + "'" + value[1] + "'" + ") AND ("  + search[2]  + "=" + "'" + value[2] + "'" + ") AND (" + search[3]  + "=" + "'" + value[3] + "'" + ") ";
                   

                }

                SqlCommand sqlcomm = new SqlCommand(commsql, conn);
                sqlcomm.ExecuteNonQuery();

                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }





    }
}
