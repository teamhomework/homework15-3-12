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
        string urllist = "http://hq.sinajs.cn/list={0}";
        
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

            string url = string.Format(urllist,StockNum);
            string StockData = client.DownloadString(url);

            return StockData;        
        }

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
