using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace personremainer
{
    class CNode
    {
    }
    public class OptrecordNode
    {
        public OptrecordNode next;
        public string stockname;
        public string stockcode;
        public string optdate;
        public string opttype;
        public string stockprice;
        public string stocknumber;
        public string rate;
        public string commission;
        public void Add(OptrecordNode o)
        {
            OptrecordNode y = new OptrecordNode();
            y.stockcode = o.stockcode;
            y.stockname = o.stockname;
            y.optdate = o.optdate;
            y.opttype = o.opttype;
            y.stockprice = o.stockprice;
            y.stocknumber = o.stocknumber;
            y.rate = o.rate;
            y.commission = o.commission;
            y.next = o.next;
         //   this.next = y;
        }

    }
}
