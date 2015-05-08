using personremainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace GNSDTestProject
{
    
    
    /// <summary>
    ///这是 DataBaseTest 的测试类，旨在
    ///包含所有 DataBaseTest 单元测试
    ///</summary>
    [TestClass()]
    public class DataBaseTest
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
        ///DataBase 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void DataBaseConstructorTest()
        {
            DataBase target = new DataBase();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///AddStockData 的测试
        ///</summary>
        [TestMethod()]
        public void AddStockDataTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string[] StockInf = null; // TODO: 初始化为适当的值
            string Stockcode = string.Empty; // TODO: 初始化为适当的值
            target.AddStockData(StockInf, Stockcode);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///AddUserOp 的测试
        ///</summary>
        [TestMethod()]
        public void AddUserOpTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            OptrecordNode UserOp_hand = null; // TODO: 初始化为适当的值
            target.AddUserOp(UserOp_hand);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///CreateTable 的测试
        ///</summary>
        [TestMethod()]
        public void CreateTableTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            target.CreateTable();
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string tablename = string.Empty; // TODO: 初始化为适当的值
            string search = string.Empty; // TODO: 初始化为适当的值
            DataSet expected = null; // TODO: 初始化为适当的值
            DataSet actual;
            actual = target.ReadDB(tablename, search);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest1()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string tablename = string.Empty; // TODO: 初始化为适当的值
            string search = string.Empty; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            DataSet expected = null; // TODO: 初始化为适当的值
            DataSet actual;
            actual = target.ReadDB(tablename, search, i);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest2()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string tablename = string.Empty; // TODO: 初始化为适当的值
            string search = string.Empty; // TODO: 初始化为适当的值
            string condition = string.Empty; // TODO: 初始化为适当的值
            string vaule = string.Empty; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            DataSet expected = null; // TODO: 初始化为适当的值
            DataSet actual;
            actual = target.ReadDB(tablename, search, condition, vaule, i);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///changeDB 的测试
        ///</summary>
        [TestMethod()]
        public void changeDBTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            int op = 0; // TODO: 初始化为适当的值
            string[] search = null; // TODO: 初始化为适当的值
            string[] value = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.changeDB(op, search, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
