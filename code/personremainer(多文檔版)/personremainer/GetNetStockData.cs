using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
namespace personremainer
{
    class GetNetStockData
    { 
        WebClient client;
        string UrlList = "http://hq.sinajs.cn/list={0}";
        string GraphUrlList= "http://image.sinajs.cn/newchart/{0}";
        string GraphUrlEnd = ".gif";
       // string Reg = "收盘价:(?<price>[0-9]+\\.[0-9]+)";
      //  </td><td><h6><span style="color:#008000">
        string Reg = "收盘价:</td><td><h6><span style=\"color:#[A-z]*[0-9]*\">(?<price>[0-9]+\\.[0-9]+)";
        public string GetNetData(string StockNum)//輸入股票編號 訪問新浪API接口 返回字股票信息(符串數據)
        {
            if (null == client)
            {
                client = new WebClient();
            }
            char[] test = StockNum.ToArray();
            if (test.LongLength < 6)
            {
                StockNum = "00" + StockNum;
            }

            if("60" == StockNum.Substring(0,2))
            {
                StockNum = "sh" + StockNum;
            }
            else if ("00" == StockNum.Substring(0, 2))
            {
                StockNum = "sz" + StockNum;
            }
            else if ("51" == StockNum.Substring(0, 2))
            {
                StockNum = "sz" + StockNum;
            }
 

            string url = string.Format(UrlList,StockNum);
            try
            {
                string StockData = client.DownloadString(url);

                return StockData;
            }
            catch(Exception err)
            {
                
                return null;
            }
        }
        /*日K線
        http://image.sinajs.cn/newchart/daily/n/sh000001.gif
        分K线：
        http://image.sinajs.cn/newchart/min/n/sh000001.gif
        周K线：
        http://image.sinajs.cn/newchart/weekly/n/sh000001.gif
        月K线：
        http://image.sinajs.cn/newchart/monthly/n/sh000001.gif
        */
        //抓股票圖表   pictureBox1.ImageLocation = @"http://image.sinajs.cn/newchart/min/n/sh000001.gif";
        //分=0 日=1 周=2 月=3
        public string GetNetGraph(string StockNum,int n)
        {
            if (null == client)
            {
                client = new WebClient();
            }

            char[] test = StockNum.ToArray();
            if (test.LongLength < 6)
            {
                StockNum = "00" + StockNum;
            }


            if("60" == StockNum.Substring(0,2))
            {
                StockNum = "sh" + StockNum;
            }
            else if ("00" == StockNum.Substring(0, 2))
            {
                StockNum = "sz" + StockNum;
            }
            else if ("51" == StockNum.Substring(0, 2))
            {
                StockNum = "sz" + StockNum;
            }
            

            StockNum = StockNum + GraphUrlEnd;

            if (0 == n)
            {
                StockNum = "min/n/" + StockNum;
            }
           else if (1 == n)
            {
                StockNum = "daily/n/" + StockNum;
            }
           else if (2 == n)
            {
                StockNum = "weekly/n/" + StockNum;
            }
            else if (3 == n)
            {
                StockNum = "monthly/n/" + StockNum;
            }
            else
            {
                n = 0;
            }



            string StockGraphUrl =  string.Format(GraphUrlList,StockNum);
            
            return StockGraphUrl;
        }





        //可以調用  char.Parse(StockSplitData[i]) int.Parse(StockSplitData[i]) float.Parse(StockSplitData[i]) 直接轉換數據類型
        public string[] TreatmentString(string RawData)//清理字符串中無用數據并返回 已分裂好的字符串數組 
        {
           int DelCon = RawData.IndexOf("\"");
            string temp = RawData;
            temp = temp.Remove(0,DelCon);
            temp=   temp.Replace("\"","");
            temp = temp.Replace(";", "");
            string[] StockSplitData = temp.Split(',');

            return StockSplitData;
        }

        public string hispri(string stockcode,string DATA)
        {
            if (null == client)
            {
                client = new WebClient();
            }
            char[] test = stockcode.ToArray();
           
            if (test.LongLength < 6)
            {
                stockcode = "00" + stockcode;
            }


            if ("60" == stockcode.Substring(0, 2))
            {
                stockcode = "sh" + stockcode;
            }
            else if ("00" == stockcode.Substring(0, 2))
            {
                stockcode = "sz" + stockcode;
            }
            else if ("51" == stockcode.Substring(0, 2))
            {
                stockcode = "sz" + stockcode;
            }
            

            string hisURL = "http://money.finance.sina.com.cn/quotes_service/view/vMS_tradehistory.php?symbol=";
            hisURL += stockcode;
            hisURL += "&date=" + DATA;
            Regex reg = new Regex(Reg);
            try
            {
                string StockData = client.DownloadString(hisURL);
                MatchCollection MCrelust = reg.Matches(StockData);
                string relut = MCrelust[0].Groups["price"].Value.ToString();
                return relut;
            }
            catch (Exception err)
            {
                return null;
            }


        }


      
    }
}
