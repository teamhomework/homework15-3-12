using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace personremainer
{
    //用作保存窗口間交互數據
    public  class commo_data
    {
        
        //對應EXECL表數據
        public static string data;//日期
        public static float StoPrice;//股價
        public static string OP;//操作
        public static string StoName;//股票名
        public static int StoNum;//數量
        public static float Tax;//稅率
        //其他數據
        public static string capital = "0";//本金
        public static float marketprice = 0;//市價
        public static float cash = 0;//現金
        public static float acctocash = 0;//帳戶總資產
        public static float chagra = 0;//浮動盈虧
        public static float grain = 0;
        public static float dailygrain = 0;
        //搜索關鍵字
        public static string find_key_word;//股票號或股票名 用作搜索
        public static string filename;//EXECL文件名
        public static string stockcode = null;//股票編號

        //記錄增刪改
        public static int qty;//數量
        public static string opt;//操作
        public static float price;//價格
        public static string DATE;//日期

    }

    public class create_form
    {
        public static Form2 frm2;
        public static Form3 cash;

        public static void create_changeOpData()
        {
            frm2 = new Form2();
            frm2.ShowDialog();
        }
        public static void create_cash()
        {
            cash = new Form3();
            cash.ShowDialog();
        }


    }

}
