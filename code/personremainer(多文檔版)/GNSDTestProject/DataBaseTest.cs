using personremainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
namespace GNSDTestProject
{
    
    
    /// <summary>
    ///这是 DataBaseTest 的测试类，旨在
    ///包含所有 DataBaseTest 单元测试
    ///</summary>
    [TestClass()]
    public class DataBaseTest
    {
        string OwnName = "ForTest";

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
        }
        /*
        /// <summary>
        ///AddStockData 的测试
        ///</summary>
        [TestMethod()]
        public void AddStockDataTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            try
            {
                string[] StockInf = new string[7]; // TODO: 初始化为适当的值
                StockInf[0] ="复星医";
                StockInf[1] ="600197";
                StockInf[2] ="27.98";
                StockInf[3] ="27.98";
                StockInf[4] ="27.98";
                StockInf[5] = "27.98";
                StockInf[6] = "-0.9300003";
                string Stockcode = "600196"; // TODO: 初始化为适当的值
                target.AddStockData(StockInf, Stockcode);
                Assert.IsTrue(true);
            }
            catch (Exception err)
            {
                Assert.IsTrue(false);
            }
      
        }*/

        /// <summary>
        ///AddUserOp 的测试
        ///</summary>
        [TestMethod()]
        public void AddUserOpTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            OptrecordNode recordnode = new OptrecordNode();
            recordnode.stockname = "伊利股份";
            recordnode.stockcode = "600887";
            recordnode.optdate = "2015/3/11";
            recordnode.opttype = "卖出";
            recordnode.stockprice = "4.5";
            recordnode.stocknumber = "500";
            recordnode.rate = "0.1";
            recordnode.commission = "0.03";
            OptrecordNode UserOp_hand = recordnode; // TODO: 初始化为适当的值
            try
            {
                target.AddUserOp(OwnName, UserOp_hand);
                Assert.IsTrue(true);
            }
            catch (Exception err)
            {
                Assert.IsTrue(false);
            }
        }

        /// <summary>
        ///CreateTable 的测试
        ///</summary>
        [TestMethod()]
        public void CreateTableTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            try
            {
                target.CreateTable(OwnName);
                Assert.IsTrue(true);

            }
            catch (Exception err)
            {
                Assert.IsTrue(false);
            }
        }

        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string tablename = "userop"; // TODO: 初始化为适当的值
            string search = "id"; // TODO: 初始化为适当的值
            DataSet actual = null;
            actual = target.ReadDB(tablename, search);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest1()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string tablename = "userop"; // TODO: 初始化为适当的值
            string search = "id"; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            DataSet actual =null;
            actual = target.ReadDB(tablename, search, i);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest1_wong()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string tablename = string.Empty; // TODO: 初始化为适当的值
            string search = string.Empty; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            DataSet expected = null; // TODO: 初始化为适当的值
            DataSet actual;
            actual = target.ReadDB(tablename, search,i);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest2()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            string tablename = "userop"; // TODO: 初始化为适当的值
            string search = "id"; // TODO: 初始化为适当的值
            string condition = "id"; // TODO: 初始化为适当的值
            string vaule = "601398"; // TODO: 初始化为适当的值
            int i = 0; // TODO: 初始化为适当的值
            DataSet actual = null;
            actual = target.ReadDB(tablename, search, condition, vaule, i);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///ReadDB 的测试
        ///</summary>
        [TestMethod()]
        public void ReadDBTest2_wong()
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
        }

        /// <summary>
        ///changeDB 的测试
        ///</summary>
        ///
        [TestMethod()]
        public void changeDBTest()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            int op = 0; // TODO: 初始化为适当的值

            string[] value = new string[8]; // TODO: 初始化为适当的值
            value[0] = "复星医";
            value[1] = "600197";
            value[2] = "2015/3/7";
            value[3] = "買入";
            value[4] = "2";
            value[5] = "1";
            value[6] = "1";
            value[7] = "0.3";
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = target.changeDB(op, value, value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void changeDBTest_wong()
        {
            DataBase target = new DataBase(); // TODO: 初始化为适当的值
            int op = 0; // TODO: 初始化为适当的值
            string[] search = null; // TODO: 初始化为适当的值
            string[] value = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.changeDB(op, search, value);
            Assert.AreEqual(expected, actual);
        }
    }
}
