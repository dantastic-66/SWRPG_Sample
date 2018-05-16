using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ExtraClassItem Class
    /// </summary>
    [TestClass]
    public class ExtraClassItemTest
    {
        /// <summary>
        /// The object new extra class item
        /// </summary>
        ExtraClassItem objNewExtraClassItem = new ExtraClassItem();
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraClassItemTest"/> class.
        /// </summary>
        public ExtraClassItemTest()
        {
            objNewExtraClassItem.ExtraClassLevelItemID = 0;
            objNewExtraClassItem.ExtraClassLevelItemName = "Test Extra Class Level Item Name";
            objNewExtraClassItem.ExtraClassLevelItemDescription = "Test Extra Class Level Item Description";
        }

        /// <summary>
        /// The test context instance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Tests the GetExtraClassItem by ExtraClassItemID method.
        /// </summary>
        #region GetExtraClassItem(int ExtraClassItemID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItem(int ExtraClassItemID) Method, Good Outcome")]
        public void Test_GetExtraClassItem_ByID_GoodResult()
        {
            int intExtraClassItemID = 1;
            ExtraClassItem objExtraClassItem = new ExtraClassItem();

            objExtraClassItem.GetExtraClassItem(intExtraClassItemID);

            Assert.AreEqual(intExtraClassItemID, objExtraClassItem.ExtraClassLevelItemID);
        }

        /// <summary>
        /// Test_s the get extra class item_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItem(int ExtraClassItemID) Method, Bad Outcome")]
        public void Test_GetExtraClassItem_ByID_BadResult()
        {
            int intExtraClassItemID = 0;
            ExtraClassItem objExtraClassItem = new ExtraClassItem();

            objExtraClassItem.GetExtraClassItem(intExtraClassItemID);

            Assert.IsNull(objExtraClassItem.ExtraClassLevelItemName);
        }
        #endregion

        /// <summary>
        /// Tests the GetExtraClassItem by ExtraClassLevelItemName method.
        /// </summary>
        #region GetExtraClassItem(string strExtraClassLevelItemName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItem(string ExtraClassLevelItemName) Method, Good Outcome")]
        public void Test_GetExtraClassItem_ByName_GoodResult()
        {
            string strExtraClassLevelItemName = "LightSaber";
            ExtraClassItem objExtraClassItem = new ExtraClassItem();

            objExtraClassItem.GetExtraClassItem(strExtraClassLevelItemName);

            Assert.AreEqual(strExtraClassLevelItemName, objExtraClassItem.ExtraClassLevelItemName);
        }

        /// <summary>
        /// Test_s the get extra class item_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItem(string ExtraClassLevelItemName) Method, Bad Outcome")]
        public void Test_GetExtraClassItem_ByName_BadResult()
        {
            string strExtraClassLevelItemName = "blah blah";
            ExtraClassItem objExtraClassItem = new ExtraClassItem();

            objExtraClassItem.GetExtraClassItem(strExtraClassLevelItemName);

            Assert.IsNull(objExtraClassItem.ExtraClassLevelItemName);
        }
        #endregion

        /// <summary>
        /// Tests the GetExtraClassItems by strWhere, strOrderBy method.
        /// </summary>
        #region GetExtraClassItems(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItems(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetExtraClassItems_WithOrderBy_GoodResult()
        {
            string strWhere = "ExtraClassLevelItemName Like '%LightSaber%'";
            string strOrderBy = "ExtraClassLevelItemName";

            ExtraClassItem objExtraClassItem = new ExtraClassItem();
            List<ExtraClassItem> lstExtraClassItems = new List<ExtraClassItem>();

            lstExtraClassItems = objExtraClassItem.GetExtraClassItems(strWhere, strOrderBy);

            Assert.IsTrue(lstExtraClassItems.Count > 0);
        }

        /// <summary>
        /// Test_s the get extra class items_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItems(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetExtraClassItems_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ExtraClassLevelItemName Like '%LightSaber%'";
            string strOrderBy = "";

            ExtraClassItem objExtraClassItem = new ExtraClassItem();
            List<ExtraClassItem> lstExtraClassItems = new List<ExtraClassItem>();

            lstExtraClassItems = objExtraClassItem.GetExtraClassItems(strWhere, strOrderBy);

            Assert.IsTrue(lstExtraClassItems.Count > 0);
        }

        /// <summary>
        /// Test_s the get extra class items_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItems(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetExtraClassItems_WithOrderBy_NoResult()
        {
            string strWhere = "ExtraClassLevelItemName Like '%Toad%'";
            string strOrderBy = "ExtraClassLevelItemName";

            ExtraClassItem objExtraClassItem = new ExtraClassItem();
            List<ExtraClassItem> lstExtraClassItems = new List<ExtraClassItem>();

            lstExtraClassItems = objExtraClassItem.GetExtraClassItems (strWhere, strOrderBy);

            Assert.IsTrue(lstExtraClassItems.Count == 0);
        }

        /// <summary>
        /// Test_s the get extra class items_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetExtraClassItems(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetExtraClassItems_WithOutOrderBy_NoResult()
        {
            string strWhere = "ExtraClassLevelItemName Like '%Toad%'";
            string strOrderBy = "";

            ExtraClassItem objExtraClassItem = new ExtraClassItem();
            List<ExtraClassItem> lstExtraClassItems = new List<ExtraClassItem>();

            lstExtraClassItems = objExtraClassItem.GetExtraClassItems (strWhere, strOrderBy);

            Assert.IsTrue(lstExtraClassItems.Count == 0);
        }

        #endregion

        #region SaveAndDeleteExtraClassItem()
        /// <summary>
        /// Test_s the save and delete extra class item.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveExtraClassItem and DeleteExtraClassItem Methods)")]
        public void Test_SaveAndDeleteExtraClassItem()
        {
            bool returnVal;

            objNewExtraClassItem.SaveExtraClassItem();

            Assert.IsTrue(objNewExtraClassItem.ExtraClassLevelItemID != 0);

            returnVal = objNewExtraClassItem.DeleteExtraClassItem();

            Assert.IsTrue(returnVal && objNewExtraClassItem.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        /// <summary>
        /// Validate_s the true result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewExtraClassItem.Validate();
            Assert.IsTrue(objNewExtraClassItem.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewExtraClassItem.ExtraClassLevelItemName = "";
            objNewExtraClassItem.Validate();
            Assert.IsTrue(!objNewExtraClassItem.Validated && (objNewExtraClassItem.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
