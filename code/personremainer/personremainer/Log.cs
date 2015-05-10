using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace personremainer
{
    public enum LOGLEVEL
    {
        NOLOG,   //不打印任何信息
        ERROR,   //打印错误信息
        WARNING, //打印告警信息
        INFO,    //打印过程信息
        DEBUG    //打印调试信息
    }

    public enum LOGTYPE
    {
        DATABASE,   //数据库类
        FILE,   //文件类
        USEROP, //用户操作类
        FLOW,    //过程记录
        OTHERS    //其他异常
    }
    public static class Log
    {

        //日志路径
        private static string sLogFilePath = "";
        private static string sLogFileName = "";
        //日志开关
        private static bool bLogDatabaseSW = true;
        private static bool bLogFileSW = true;
        private static bool bLogUserOpSW = true;
        private static bool bLogFlowSW = true;
        private static bool bLogOthersSW = true;

        //日志句柄
        public static StreamWriter swLogWriter;
        public static FileStream fsLogFileStream;

        //日志级别，默认全部打印
        private static LOGLEVEL iLogLevel = LOGLEVEL.DEBUG;

        //日志默认在程序目录下创建LOG文件夹保存日志
        public static void SetLogFile()
        {
            //获取当前程序所在路径
            sLogFilePath = Environment.CurrentDirectory + "\\Log";

            //获取当前的日期和时间，组成文件名
            sLogFileName = DateTime.Now.ToString("yyyy_MM_dd") + "_" + DateTime.Now.ToString("hh_mm_ss") + ".txt";
        }

        //日志启动函数，程序初始化时首先调用
        public static void StartUp()
        {
            //设置文件路径
            SetLogFile();

            //创建日志文件夹和日志文件
            if (!Directory.Exists(sLogFilePath))
            {
                Directory.CreateDirectory(sLogFilePath);
            }

            string sLogFullFileName = sLogFilePath + "\\" + sLogFileName;
            // 判断文件是否存在，不存在则创建，否则读取值显示到窗体
            if (!File.Exists(sLogFullFileName))
            {
                fsLogFileStream = new FileStream(sLogFullFileName, FileMode.Create, FileAccess.Write);//创建写入文件 
            }
            else
            {
                fsLogFileStream = new FileStream(sLogFullFileName, FileMode.Open, FileAccess.Write);
            }

            //打开文件
            swLogWriter = new StreamWriter(fsLogFileStream);


            //记录程序启动时间
            swLogWriter.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            swLogWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("hh:mm:ss") + ":程序启动");
            swLogWriter.Flush();
        }

        //日志关闭函数，程序结束时调用
        public static void LogOver()
        {
            //记录程序结束时间
            swLogWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("hh:mm:ss") + ":程序结束");
            swLogWriter.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            swLogWriter.Flush();
            swLogWriter.Close();
            fsLogFileStream.Close();
        }

        //日志写入函数
        public static void WriteLog(LOGLEVEL lvLevel, LOGTYPE ltLogType, string sLogContent)
        {
            //判断开关是否关闭日志开关
            if (lvLevel > iLogLevel)
            {
                return;
            }
            //判断类型开关是否打开
            bool LogTypeSW = false;
            string LogHead = "";
            switch (ltLogType)
            {
                case LOGTYPE.DATABASE:
                    {
                        if (bLogDatabaseSW)
                        {
                            LogTypeSW = true;
                            LogHead = "数据库日志--::";
                        }
                    }
                    break;
                case LOGTYPE.FILE:
                    {
                        if (bLogFileSW)
                        {
                            LogTypeSW = true;
                            LogHead = "文件类日志--::";
                        }
                    }
                    break;
                case LOGTYPE.FLOW:
                    {
                        if (bLogFlowSW)
                        {
                            LogTypeSW = true;
                            LogHead = "流程类日志--::";
                        }
                    }
                    break;
                case LOGTYPE.USEROP:
                    {
                        if (bLogUserOpSW)
                        {
                            LogTypeSW = true;
                            LogHead = "用户操作类日志--::";
                        }
                    }
                    break;
                case LOGTYPE.OTHERS:
                    {
                        if (bLogOthersSW)
                        {
                            LogTypeSW = true;
                            LogHead = "不知名类日志--::";
                        }
                    }
                    break;
                default:
                    break;
            }

            if (LogTypeSW)
            {
                swLogWriter.WriteLine(LogHead + sLogContent);
                swLogWriter.Flush();
            }
            return;
        }

    }
}
