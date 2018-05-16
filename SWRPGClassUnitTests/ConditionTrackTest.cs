using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ConditionTrack Class
    /// </summary>
    [TestClass]
    public class ConditionTrackTest
    {
        ConditionTrack objNewConditionTrack = new ConditionTrack();
        public ConditionTrackTest()
        {
            objNewConditionTrack.ConditionTrackID = 0;
            objNewConditionTrack.Modifier = 3;
            objNewConditionTrack.Description = "New Test Condition Track entry.";
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
        /// Tests the GetConditionTrack by ConditionTrackID method.
        ///</summary>
        #region GetConditionTrack(int ConditionTrackID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTrack(int ConditionTrackID) Method, Good Outcome")]
        public void Test_GetConditionTrack_ByID_GoodResult()
        {
            int intConditionTrackID = 1;
            ConditionTrack objConditionTrack = new ConditionTrack();

            objConditionTrack.GetConditionTrack(intConditionTrackID);

            Assert.AreEqual(intConditionTrackID, objConditionTrack.ConditionTrackID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTrack(int ConditionTrackID) Method, Bad Outcome")]
        public void Test_GetConditionTrack_ByID_BadResult()
        {
            int intConditionTrackID = 0;
            ConditionTrack objConditionTrack = new ConditionTrack();

            objConditionTrack.GetConditionTrack(intConditionTrackID);

            Assert.IsNull(objConditionTrack.Description );
        }
        #endregion

        /// <summary>
        /// Tests the GetConditionTrack by ConditionTrackName method.
        ///</summary>
        #region GetConditionTrack(string strConditionTrackName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTrack(string ConditionTrackName) Method, Good Outcome")]
        public void Test_GetConditionTrack_ByName_GoodResult()
        {
            string strConditionTrackName = "Normal";
            ConditionTrack objConditionTrack = new ConditionTrack();

            objConditionTrack.GetConditionTrack(strConditionTrackName);

            Assert.AreEqual(strConditionTrackName, objConditionTrack.Description );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTrack(string ConditionTrackName) Method, Bad Outcome")]
        public void Test_GetConditionTrack_ByName_BadResult()
        {
            string strConditionTrackName = "blah blah";
            ConditionTrack objConditionTrack = new ConditionTrack();

            objConditionTrack.GetConditionTrack(strConditionTrackName);

            Assert.IsNull(objConditionTrack.Description);
        }
        #endregion

        /// <summary>
        /// Tests the GetConditionTracks by strWhere, strOrderBy method.
        ///</summary>
        #region GetConditionTracks(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTracks(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetConditionTracks_WithOrderBy_GoodResult()
        {
            string strWhere = "Description Like '%Modifier%'";
            string strOrderBy = "Description";

            ConditionTrack objConditionTrack = new ConditionTrack();
            List<ConditionTrack> lstConditionTracks = new List<ConditionTrack>();

            lstConditionTracks = objConditionTrack.GetConditionTracks(strWhere, strOrderBy);

            Assert.IsTrue(lstConditionTracks.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTracks(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetConditionTracks_WithOutOrderBy_GoodResult()
        {
            string strWhere = "Description Like '%Modifier%'";
            string strOrderBy = "";

            ConditionTrack objConditionTrack = new ConditionTrack();
            List<ConditionTrack> lstConditionTracks = new List<ConditionTrack>();

            lstConditionTracks = objConditionTrack.GetConditionTracks(strWhere, strOrderBy);

            Assert.IsTrue(lstConditionTracks.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTracks(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetConditionTracks_WithOrderBy_NoResult()
        {
            string strWhere = "Description Like '%Toad%'";
            string strOrderBy = "Description";

            ConditionTrack objConditionTrack = new ConditionTrack();
            List<ConditionTrack> lstConditionTracks = new List<ConditionTrack>();

            lstConditionTracks = objConditionTrack.GetConditionTracks(strWhere, strOrderBy);

            Assert.IsTrue(lstConditionTracks.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetConditionTracks(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetConditionTracks_WithOutOrderBy_NoResult()
        {
            string strWhere = "Description Like '%Toad%'";
            string strOrderBy = "";

            ConditionTrack objConditionTrack = new ConditionTrack();
            List<ConditionTrack> lstConditionTracks = new List<ConditionTrack>();

            lstConditionTracks = objConditionTrack.GetConditionTracks(strWhere, strOrderBy);

            Assert.IsTrue(lstConditionTracks.Count == 0);
        }

        #endregion

        #region SaveAndDeleteConditionTrack()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveConditionTrack and DeleteConditionTrack Methods)")]
        public void Test_SaveAndDeleteConditionTrack()
        {
            bool returnVal;

            objNewConditionTrack.SaveConditionTrack();

            Assert.IsTrue(objNewConditionTrack.ConditionTrackID != 0);

            returnVal = objNewConditionTrack.DeleteConditionTrack();

            Assert.IsTrue(returnVal && objNewConditionTrack.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewConditionTrack.Validate();
            Assert.IsTrue(objNewConditionTrack.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewConditionTrack.Description = "";
            objNewConditionTrack.Validate();
            Assert.IsTrue(!objNewConditionTrack.Validated && (objNewConditionTrack.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
