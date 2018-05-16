using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the TurnSegment Class
    /// </summary>
    [TestClass]
    public class TurnSegmentTest
    {
        TurnSegment objNewTurnSegment = new TurnSegment();
        public TurnSegmentTest()
        {
            objNewTurnSegment.TurnSegmentID = 0;
            objNewTurnSegment.TurnSegmentName = "Test Turn Segment";
            objNewTurnSegment.TurnSegmentDescription = "Test Turn Segment Description";
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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
        /// Tests the GetTurnSegment by TurnSegmentID method.
        ///</summary>
        #region GetTurnSegment(int TurnSegmentID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegment(int TurnSegmentID) Method, Good Outcome")]
        public void Test_GetTurnSegment_ByID_GoodResult()
        {
            int intTurnSegmentID = 1;
            TurnSegment objTurnSegment = new TurnSegment();

            objTurnSegment.GetTurnSegment(intTurnSegmentID);

            Assert.AreEqual(intTurnSegmentID, objTurnSegment.TurnSegmentID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegment(int TurnSegmentID) Method, Bad Outcome")]
        public void Test_GetTurnSegment_ByID_BadResult()
        {
            int intTurnSegmentID = 0;
            TurnSegment objTurnSegment = new TurnSegment();

            objTurnSegment.GetTurnSegment(intTurnSegmentID);

            Assert.IsNull(objTurnSegment.TurnSegmentName);
        }
        #endregion

        /// <summary>
        /// Tests the GetTurnSegment by TurnSegmentName method.
        ///</summary>
        #region GetTurnSegment(string strTurnSegmentName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegment(string TurnSegmentName) Method, Good Outcome")]
        public void Test_GetTurnSegment_ByName_GoodResult()
        {
            string strTurnSegmentName = "Swift";
            TurnSegment objTurnSegment = new TurnSegment();

            objTurnSegment.GetTurnSegment(strTurnSegmentName);

            Assert.AreEqual(strTurnSegmentName, objTurnSegment.TurnSegmentName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegment(string TurnSegmentName) Method, Bad Outcome")]
        public void Test_GetTurnSegment_ByName_BadResult()
        {
            string strTurnSegmentName = "blah blah";
            TurnSegment objTurnSegment = new TurnSegment();

            objTurnSegment.GetTurnSegment(strTurnSegmentName);

            Assert.IsNull(objTurnSegment.TurnSegmentName);
        }
        #endregion

        /// <summary>
        /// Tests the GetTurnSegments by strWhere, strOrderBy method.
        ///</summary>
        #region GetTurnSegments(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegments(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTurnSegments_WithOrderBy_GoodResult()
        {
            string strWhere = "TurnSegmentName Like '%R%'";
            string strOrderBy = "TurnSegmentName";

            TurnSegment objTurnSegment = new TurnSegment();
            List<TurnSegment> lstTurnSegments = new List<TurnSegment>();

            lstTurnSegments = objTurnSegment.GetTurnSegments(strWhere, strOrderBy);

            Assert.IsTrue(lstTurnSegments.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegments(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTurnSegments_WithOutOrderBy_GoodResult()
        {
            string strWhere = "TurnSegmentName Like '%R%'";
            string strOrderBy = "";

            TurnSegment objTurnSegment = new TurnSegment();
            List<TurnSegment> lstTurnSegments = new List<TurnSegment>();

            lstTurnSegments = objTurnSegment.GetTurnSegments(strWhere, strOrderBy);

            Assert.IsTrue(lstTurnSegments.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegments(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTurnSegments_WithOrderBy_NoResult()
        {
            string strWhere = "TurnSegmentName Like '%Toad%'";
            string strOrderBy = "TurnSegmentName";

            TurnSegment objTurnSegment = new TurnSegment();
            List<TurnSegment> lstTurnSegments = new List<TurnSegment>();

            lstTurnSegments = objTurnSegment.GetTurnSegments(strWhere, strOrderBy);

            Assert.IsTrue(lstTurnSegments.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTurnSegments(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTurnSegments_WithOutOrderBy_NoResult()
        {
            string strWhere = "TurnSegmentName Like '%Toad%'";
            string strOrderBy = "";

            TurnSegment objTurnSegment = new TurnSegment();
            List<TurnSegment> lstTurnSegments = new List<TurnSegment>();

            lstTurnSegments = objTurnSegment.GetTurnSegments(strWhere, strOrderBy);

            Assert.IsTrue(lstTurnSegments.Count == 0);
        }

        #endregion

        #region SaveAndDeleteTurnSegment()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveTurnSegment and DeleteTurnSegment Methods)")]
        public void Test_SaveAndDeleteTurnSegment()
        {
            bool returnVal;

            objNewTurnSegment.SaveTurnSegment();

            Assert.IsTrue(objNewTurnSegment.TurnSegmentID != 0);

            returnVal = objNewTurnSegment.DeleteTurnSegment();

            Assert.IsTrue(returnVal && objNewTurnSegment.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewTurnSegment.Validate();
            Assert.IsTrue(objNewTurnSegment.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewTurnSegment.TurnSegmentName = "";
            objNewTurnSegment.Validate();
            Assert.IsTrue(!objNewTurnSegment.Validated && (objNewTurnSegment.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
