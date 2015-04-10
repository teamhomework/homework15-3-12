using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Reflection;
using Excel=Microsoft.Office.Interop.Excel;

namespace personremainer
{
    class OptExcel
    {
        //Sheet文件
        Excel.Application xlApp;
        Excel.Workbook workbook;
        Excel.Worksheet xlsSheet;
        Excel.Range xlsRange;
        string sExPath;

        //打开文件
        public bool Open(string sExcelPath)
        {
            sExPath = sExcelPath;
            try
            {
                xlApp = new Excel.Application();
                workbook = xlApp.Workbooks.Open(sExPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, 1, 0);
                xlsSheet = (Excel.Worksheet)workbook.Sheets[1];
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return false;
            }
        }
        //读取文件
        public string ReadCell(int iRow, int iCln)
        {
            xlsRange = (Excel.Range)xlsSheet.Cells[iRow, iCln];
            object obj = (object)xlsRange.Value;
            if (obj is string)
            {
                return xlsRange.Value;
            }
            else if (null == obj)
            {
                return "";
            }
            else
            {
                return xlsRange.Value.ToString();
            }

        }

        //关闭文件
        public bool Close()
        {
            if (null != workbook)
            {
                workbook.Close();
            }
            return true;
        }
    }
}
