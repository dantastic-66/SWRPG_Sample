using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Size Class
    /// </summary>
    [TestClass]
    public class SizeTest
    {
        /// <summary>
        /// The object new size
        /// </summary>
        Size objNewSize = new Size();
        /// <summary>
        /// Initializes a new instance of the <see cref="SizeTest"/> class.
        /// </summary>
        public SizeTest()
        {
            objNewSize.SizeID = 0;
            objNewSize.SizeName = "Test Size";
            objNewSize.SizeModifier = 1;
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
        /// Tests the GetSize by SizeID method.
        /// </summary>
        #region GetSize(int SizeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSize(int SizeID) Method, Good Outcome")]
        public void Test_GetSize_ByID_GoodResult()
        {
            int intSizeID = 1;
            Size objSize = new Size();

            objSize.GetSize(intSizeID);

            Assert.AreEqual(intSizeID, objSize.SizeID);
        }

        /// <summary>
        /// Test_s the get size_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSize(int SizeID) Method, Bad Outcome")]
        public void Test_GetSize_ByID_BadResult()
        {
            int intSizeID = 0;
            Size objSize = new Size();

            objSize.GetSize(intSizeID);

            Assert.IsNull(objSize.SizeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetSize by SizeName method.
        /// </summary>
        #region GetSize(string strSizeName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSize(string SizeName) Method, Good Outcome")]
        public void Test_GetSize_ByName_GoodResult()
        {
            string strSizeName = "Small";
            Size objSize = new Size();

            objSize.GetSize(strSizeName);

            Assert.AreEqual(strSizeName, objSize.SizeName);
        }

        /// <summary>
        /// Test_s the get size_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSize(string SizeName) Method, Bad Outcome")]
        public void Test_GetSize_ByName_BadResult()
        {
            string strSizeName = "blah blah";
            Size objSize = new Size();

            objSize.GetSize(strSizeName);

            Assert.IsNull(objSize.SizeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetSizes by strWhere, strOrderBy method.
        /// </summary>
        #region GetSizes(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizes(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetSizes_WithOrderBy_GoodResult()
        {
            string strWhere = "SizeName Like '%m%'";
            string strOrderBy = "SizeName";

            Size objSize = new Size();
            List<Size> lstSizes = new List<Size>();

            lstSizes = objSize.GetSizes(strWhere, strOrderBy);

            Assert.IsTrue(lstSizes.Count > 0);
        }

        /// <summary>
        /// Test_s the get sizes_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizes(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetSizes_WithOutOrderBy_GoodResult()
        {
            string strWhere = "SizeName Like '%m%'";
            string strOrderBy = "";

            Size objSize = new Size();
            List<Size> lstSizes = new List<Size>();

            lstSizes = objSize.GetSizes(strWhere, strOrderBy);

            Assert.IsTrue(lstSizes.Count > 0);
        }

        /// <summary>
        /// Test_s the get sizes_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizes(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetSizes_WithOrderBy_NoResult()
        {
            string strWhere = "SizeName Like '%Toad%'";
            string strOrderBy = "SizeName";

            Size objSize = new Size();
            List<Size> lstSizes = new List<Size>();

            lstSizes = objSize.GetSizes(strWhere, strOrderBy);

            Assert.IsTrue(lstSizes.Count == 0);
        }

        /// <summary>
        /// Test_s the get sizes_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizes(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetSizes_WithOutOrderBy_NoResult()
        {
            string strWhere = "SizeName Like '%Toad%'";
            string strOrderBy = "";

            Size objSize = new Size();
            List<Size> lstSizes = new List<Size>();

            lstSizes = objSize.GetSizes(strWhere, strOrderBy);

            Assert.IsTrue(lstSizes.Count == 0);
        }

        #endregion


        #region GetFeatPrerequisiteSize(int FeatID)
        /// <summary>
        /// Tests the GetFeatPrerequisiteSize by FeatID Good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteSize(int FeatID) Method, Good Outcome")]
        public void Test_GetFeatPrerequisiteSize_ByID_GoodResult()
        {
            int FeatID = 796;
            
            Size objSize = new Size();
            List<Size> lstSize = new List<Size>();

            lstSize = objSize.GetFeatPrerequisiteSize(FeatID);

            Assert.IsTrue(lstSize.Count > 0);
        }

        /// <summary>
        /// Tests the GetFeatPrerequisiteSize by FeatID bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteSize(int FeatID) Method, Bad Outcome")]
        public void Test_GetFeatPrerequisiteSize_ByID_BadResult()
        {
            int FeatID = 1;
            Size objSize = new Size();
            List<Size> lstSize = new List<Size>();

            lstSize = objSize.GetFeatPrerequisiteSize(FeatID);

            Assert.IsTrue(lstSize.Count == 0);
        }
        #endregion

        #region SaveAndDeleteSize()
        /// <summary>
        /// Test_s the size of the save and delete.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveSize and DeleteSize Methods)")]
        public void Test_SaveAndDeleteSize()
        {
            bool returnVal;

            objNewSize.SaveSize();

            Assert.IsTrue(objNewSize.SizeID != 0);

            returnVal = objNewSize.DeleteSize();

            Assert.IsTrue(returnVal && objNewSize.DeleteOK);
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
            objNewSize.Validate();
            Assert.IsTrue(objNewSize.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewSize.SizeName = "";
            objNewSize.Validate();
            Assert.IsTrue(!objNewSize.Validated && (objNewSize.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
