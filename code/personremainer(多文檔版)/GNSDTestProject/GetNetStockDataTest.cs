using personremainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GNSDTestProject
{
    
    
    /// <summary>
    ///这是 GetNetStockDataTest 的测试类，旨在
    ///包含所有 GetNetStockDataTest 单元测试
    ///</summary>
    [TestClass()]
    public class GetNetStockDataTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///GetNetStockData 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void GetNetStockDataConstructorTest()
        {
            GetNetStockData target = new GetNetStockData();
        }

        /// <summary>
        ///GetNetData 的测试
        ///</summary>
        [TestMethod()]
        public void GetNetDataTest()
        {
            GetNetStockData target = new GetNetStockData(); // TODO: 初始化为适当的值
            string StockNum = "601001"; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetNetData(StockNum);
            Assert.IsNotNull(actual);

        }

        /// <summary>
        ///GetNetGraph 的测试
        ///</summary>
        [TestMethod()]
        public void GetNetGraphTest_right()
        {
            GetNetStockData target = new GetNetStockData(); // TODO: 初始化为适当的值
            string StockNum = "601001"; // TODO: 初始化为适当的值
            int n = 0; // TODO: 初始化为适当的值
            string expected = "http://image.sinajs.cn/newchart/min/n/sh601001.gif"; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetNetGraph(StockNum, n);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetNetGraphTest_wong()
        {
            GetNetStockData target = new GetNetStockData(); // TODO: 初始化为适当的值
            string StockNum = ""; // TODO: 初始化为适当的值
            int n = 0; // TODO: 初始化为适当的值
            string expected = "http://image.sinajs.cn/newchart/min/n/sz00.gif"; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetNetGraph(StockNum, n);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///TreatmentString 的测试
        ///</summary>
        [TestMethod()]
        public void TreatmentStringTest()
        {
            GetNetStockData target = new GetNetStockData(); // TODO: 初始化为适当的值
            string RawData = "var hq_str_sh600066=\"宇通客车,31.47,31.15,30.62,31.52,30.50,30.62,30.64,17286457,531475091,13000,30.62,3783,30.61,15100,30.60,2800,30.59,20300,30.58,2400,30.64,28700,30.65,22600,30.66,71800,30.67,2800,30.68,2015-04-30,15:03:02,00\""; // TODO: 初始化为适当的值
            string[] expected = new string[1]; // TODO: 初始化为适当的值
            string[] actual = new string[34];
            expected[0] = "宇通客车";
            actual = target.TreatmentString(RawData);
            Assert.AreEqual(expected[0], actual[0]);
        }
    }
}
