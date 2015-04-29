using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;



namespace personremainer
{
    class DataBase
    {
        //可以用這句換掉現有的連接字身符串
        //  string consqlser = "server = .;integrated security=SSPI;database=master";
        string consqlser = "server = .\\SQLEXPRESS;integrated security=SSPI;database=test";

        //測試用
    /*    public string ConectDB()
        {
            // string connectionString = "server=.\\SQLEXPRESS;uid=数据库用户名;pwd=数据库密码;database=数据库名称";
            string ConnectionString = "server = .\\SQLEXPRESS;uid =chanmen;pwd=123456;database=test";
 
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlComm =new SqlCommand();
            conn.Open();
            sqlComm.Connection = conn;
         sqlComm.CommandText  = "select * from test2";
         sqlComm.CommandType = CommandType.Text;
         SqlDataReader sdr = sqlComm.ExecuteReader();
        //    string a= sdr[0].ToString();
      //   MessageBox.Show(a);
         sdr.Read();
             string a= sdr[0].ToString();
            MessageBox.Show(a);
         return "1";


        }*/
        // 有點權限問題不好搞  所以不另行新創數據庫
   /*     public void CreateDB()
        {
            //連接數據庫SQLEXPRESS  "server=.;database=master;integrated security=SSPI"; 
            string consqlser = "server = .\\SQLEXPRESS;integrated security=SSPI;database=test";
            SqlConnection conn = new SqlConnection(consqlser);
            //SqlCommand sqlComm =new SqlCommand();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string createtablesql = "CREATE DATABASE MyDB ON PRIMARY" + "(name=UserOpTable, filename =  'C:\\Users\\user\\Desktop\\ss\\UserOpTable.mdf', size=3," + "maxsize=5, filegrowth=10%)log on" + "(name=mydbb_log, filename='C:\\Users\\user\\Desktop\\ss\\UserOpTable_log.ldf',size=3," + "maxsize=20,filegrowth=1)";
            SqlCommand comsql = new SqlCommand(createtablesql, conn);
            try
            {
                comsql.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }*/




        //創表
        public void CreateTable()
        {
            //連接數據庫SQLEXPRESS  "server=.;database=master;integrated security=SSPI"; 
            SqlConnection conn = new SqlConnection(consqlser);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string createuseroptabble = "CREATE TABLE UserOp"+  "(name CHAR(10),id INT, date CHAR(20), type  CHAR(10),price float,quantity int,taxrate varchar(10),commission varchar(10))";
            string createstotable = "CREATE TABLE StockInf" + "( name char(10)," + "id int CONSTRAINT PKeyid PRIMARY KEY,"  +  "openingpriceT float,closepriceY float,maxprice float,minprice float,increase varchar(max) )";
            
            SqlCommand comsql = new SqlCommand(createuseroptabble, conn);
            SqlCommand comsql2 = new SqlCommand(createstotable,conn);

            try
            {
                comsql.ExecuteNonQuery();
                comsql2.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message.ToString());
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

            conn.Close();

        }




        //向股票資料表增加數據
        public void AddStockData(string[] StockInf,string Stockcode)
        {

           // string consqlser = "server = .\\SQLEXPRESS;integrated security=SSPI;database=test";
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
            DataSet ds = ReadDB("StockInf", "id", "id", Stockcode);
           
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
                    searchsql = " select" + "\"" + search + "\"" + "from" + "\"" + tablename + "\"";
                }
                else
                {
                    searchsql = " select * from" + "\"" + tablename + "\"";
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
        //重載 讀數據字函數
        public DataSet ReadDB(string tablename, string search, string condition,string vaule)
        {
            SqlConnection conn = new SqlConnection(consqlser);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string searchsql = null;
            try
            {
                if (search != "*")
                {
                    searchsql = " select" + "\"" + search + "\"" + "from" + "\"" + tablename + "\"" + "where" + "(\"" + condition + "\"" + "=" + "'" + vaule + "'" + ")";
                }
                else
                {
                    searchsql = " select * from" + "\"" + tablename + "\"" + "where" + "(\"" + condition + "\"" + "=" + "'" + vaule + "'" + ")";
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
                    searchsql = " select * from" + "\"" + tablename + "\"";
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
                if(0 == op)
                {
                    //待測
                    commsql = "INSERT INTO StockInf(name , id ,date,type ,price,quantity ,taxrate , commission  )" + "VALUES ( " + "'" + value[0] + "','" + value[1] + "','" + value[2] + "','" + value[3] + "','" + value[4] + "','" + value[5] + "','" + value[6] + "'" + "','" + value[7] + "','" + ")";
                    

                }

                            //刪除記錄
                //   DELETE FROM UserOp WHERE     (id = 3) DATA
                else if(1 == op)
                {//待測
                    commsql = "DELETE FROM UserOp WHERE ("+ "\""+search[0]+"\""+"="+"'"+ value[0]+"'" +")";
                }
                else if(2 == op)
                {
                    //UPDATE    UserOpSET              id = 3 WHERE     (id = 601398)
                    //SET              name = 1, id = 1, date = 0, type = 0, price = 0, quantity = 0, taxrate = 0, commission = 0
                    //要改 日 操 價 量 稅 傭
                    //待測
                    commsql = "UPDATE    UserOp SET name =" +"'"+value[1]+"',"+"\""+" id ="+"'"+value[2]+"',"+" date ="+"'"+value[3]+"',"+" type = "+"'"+value[4]+"',"+" price ="+"'"+value[5]+"',"+" quantity ="+"'"+value[6]+"',"+" taxrate ="+"'"+value[7]+"',"+" commission ="+"'"+value[8]+"',"+"where("+"\""+search[0]+"\""+"="+"'"+value[0]+"'"+")";

                }

                SqlCommand sqlcomm = new SqlCommand(commsql, conn);
                sqlcomm.ExecuteNonQuery();

                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }





    }
}
