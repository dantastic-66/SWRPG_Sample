using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Range Class
    /// </summary>
    [TestClass]
    public class RangeTest
    {
        /// <summary>
        /// The object new range
        /// </summary>
        Range objNewRange = new Range();
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeTest"/> class.
        /// </summary>
        public RangeTest()
        {
            objNewRange.RangeID = 0;
            objNewRange.RangeName = "Test Range";
            objNewRange.BeginSquare = 100;
            objNewRange.EndSquare = 200;
            objNewRange.ModifierID = -15;
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
        /// Tests the GetRange by RangeID method.
        /// </summary>
        #region GetRange(int RangeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRange(int RangeID) Method, Good Outcome")]
        public void Test_GetRange_ByID_GoodResult()
        {
            int intRangeID = 1;
            Range objRange = new Range();

            objRange.GetRange(intRangeID);

            Assert.AreEqual(intRangeID, objRange.RangeID);
        }

        /// <summary>
        /// Test_s the get range_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRange(int RangeID) Method, Bad Outcome")]
        public void Test_GetRange_ByID_BadResult()
        {
            int intRangeID = 0;
            Range objRange = new Range();

            objRange.GetRange(intRangeID);

            Assert.IsNull(objRange.RangeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetRange by RangeName method.
        /// </summary>
        #region GetRange(string strRangeName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRange(string RangeName) Method, Good Outcome")]
        public void Test_GetRange_ByName_GoodResult()
        {
            string strRangeName = "Melee";
            Range objRange = new Range();

            objRange.GetRange(strRangeName);

            Assert.AreEqual(strRangeName, objRange.RangeName);
        }

        /// <summary>
        /// Test_s the get range_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRange(string RangeName) Method, Bad Outcome")]
        public void Test_GetRange_ByName_BadResult()
        {
            string strRangeName = "blah blah";
            Range objRange = new Range();

            objRange.GetRange(strRangeName);

            Assert.IsNull(objRange.RangeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetRanges by strWhere, strOrderBy method.
        /// </summary>
        #region GetRanges(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRanges(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetRanges_WithOrderBy_GoodResult()
        {
            string strWhere = "RangeName Like '%Pistol%'";
            string strOrderBy = "RangeName";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count > 0);
        }

        /// <summary>
        /// Test_s the get ranges_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRanges(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetRanges_WithOutOrderBy_GoodResult()
        {
            string strWhere = "RangeName Like '%Pistol%'";
            string strOrderBy = "";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count > 0);
        }

        /// <summary>
        /// Test_s the get ranges_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRanges(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetRanges_WithOrderBy_NoResult()
        {
            string strWhere = "RangeName Like '%Toad%'";
            string strOrderBy = "RangeName";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count == 0);
        }

        /// <summary>
        /// Test_s the get ranges_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRanges(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetRanges_WithOutOrderBy_NoResult()
        {
            string strWhere = "RangeName Like '%Toad%'";
            string strOrderBy = "";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetWeaponRanges by strWhere, strOrderBy method.
        /// </summary>
        #region GetWeaponRanges(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponRanges(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetWeaponRanges_WithOrderBy_GoodResult()
        {
            string strWhere = "WeaponID=1";
            string strOrderBy = "RangeName";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetWeaponRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count > 0);
        }

        /// <summary>
        /// Test_s the get weapon ranges_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponRanges(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetWeaponRanges_WithOutOrderBy_GoodResult()
        {
            string strWhere = "WeaponID=1";
            string strOrderBy = "";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetWeaponRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count > 0);
        }

        /// <summary>
        /// Test_s the get weapon ranges_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponRanges(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetWeaponRanges_WithOrderBy_NoResult()
        {
            string strWhere = "WeaponID=2";
            string strOrderBy = "RangeName";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetWeaponRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count == 0);
        }

        /// <summary>
        /// Test_s the get weapon ranges_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponRanges(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetWeaponRanges_WithOutOrderBy_NoResult()
        {
            string strWhere = "WeaponID=2";
            string strOrderBy = "";

            Range objRange = new Range();
            List<Range> lstRanges = new List<Range>();

            lstRanges = objRange.GetWeaponRanges(strWhere, strOrderBy);

            Assert.IsTrue(lstRanges.Count == 0);
        }

        #endregion

        #region SaveAndDeleteRange()
        /// <summary>
        /// Test_s the save and delete range.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveRange and DeleteRange Methods)")]
        public void Test_SaveAndDeleteRange()
        {
            bool returnVal;

            objNewRange.SaveRange();

            Assert.IsTrue(objNewRange.RangeID != 0);

            returnVal = objNewRange.DeleteRange();

            Assert.IsTrue(returnVal && objNewRange.DeleteOK);
        }
        #endregion

        #region SaveAndDeleteWeaponRange()
        /// <summary>
        /// Test_s the save and delete weapon range.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveWeaponRange and DeleteWeaponRange Methods)")]
        public void Test_SaveAndDeleteWeaponRange()
        {
            bool returnVal;
            int weaponID = 1;
            Range objRange = new Range();

            objRange.GetRange(1);
            objRange.SaveWeaponRange(weaponID);

            Assert.IsTrue(objRange.RangeID != 0);

            returnVal = objRange.DeleteWeaponRange(weaponID);

            Assert.IsTrue(returnVal && objRange.DeleteOK);
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
            objNewRange.Validate();
            Assert.IsTrue(objNewRange.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewRange.RangeName = "";
            objNewRange.Validate();
            Assert.IsTrue(!objNewRange.Validated && (objNewRange.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
