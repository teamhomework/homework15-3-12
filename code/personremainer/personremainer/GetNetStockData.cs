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


namespace personremainer
{
    class GetNetStockData
    { 
        WebClient client;
        string UrlList = "http://hq.sinajs.cn/list={0}";
        string GraphUrlList= "http://image.sinajs.cn/newchart/{0}";
        string GraphUrlEnd = ".gif";
        
        public string GetNetData(string StockNum)//輸入股票編號 訪問新浪API接口 返回字股票信息(符串數據)
        {
            if (null == client)
            {
                client = new WebClient();
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
           /* else if("00" == StockNum.Substring(0,2))
            {
                string tip = "請在編號前增加 sh 或 sz 或 sz";
                MessageBox.Show(tip);
                return "";
            }*/

            string url = string.Format(UrlList,StockNum);
            string StockData = client.DownloadString(url);

            return StockData;        
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
        public string GetNetGraph(int n,string StockNum)
        {
            if (null == client)
            {
                client = new WebClient();
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

      
    }
}
