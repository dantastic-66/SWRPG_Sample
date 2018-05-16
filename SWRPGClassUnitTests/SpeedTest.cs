using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Speed Class
    /// </summary>
    [TestClass]
    public class SpeedTest
    {
        Speed objNewSpeed = new Speed();
        public SpeedTest()
        {
            objNewSpeed.SpeedID = 0;
            objNewSpeed.SpeedName = "Hover";
            objNewSpeed.SpeedRate = 1;
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
        /// Tests the GetSpeed by SpeedID method.
        ///</summary>
        #region GetSpeed(int SpeedID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSpeed(int SpeedID) Method, Good Outcome")]
        public void Test_GetSpeed_ByID_GoodResult()
        {
            int intSpeedID = 1;
            Speed objSpeed = new Speed();

            objSpeed.GetSpeed(intSpeedID);

            Assert.AreEqual(intSpeedID, objSpeed.SpeedID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSpeed(int SpeedID) Method, Bad Outcome")]
        public void Test_GetSpeed_ByID_BadResult()
        {
            int intSpeedID = 0;
            Speed objSpeed = new Speed();

            objSpeed.GetSpeed(intSpeedID);

            Assert.IsNull(objSpeed.SpeedName);
        }
        #endregion

        /// <summary>
        /// Tests the GetSpeeds by strWhere, strOrderBy method.
        ///</summary>
        #region GetSpeeds(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSpeeds(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetSpeeds_WithOrderBy_GoodResult()
        {
            string strWhere = "SpeedName Like '%Walk%'";
            string strOrderBy = "SpeedName";

            Speed objSpeed = new Speed();
            List<Speed> lstSpeeds = new List<Speed>();

            lstSpeeds = objSpeed.GetSpeeds(strWhere, strOrderBy);

            Assert.IsTrue(lstSpeeds.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSpeeds(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetSpeeds_WithOutOrderBy_GoodResult()
        {
            string strWhere = "SpeedName Like '%Walk%'";
            string strOrderBy = "";

            Speed objSpeed = new Speed();
            List<Speed> lstSpeeds = new List<Speed>();

            lstSpeeds = objSpeed.GetSpeeds(strWhere, strOrderBy);

            Assert.IsTrue(lstSpeeds.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSpeeds(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetSpeeds_WithOrderBy_NoResult()
        {
            string strWhere = "SpeedName Like '%Toad%'";
            string strOrderBy = "SpeedName";

            Speed objSpeed = new Speed();
            List<Speed> lstSpeeds = new List<Speed>();

            lstSpeeds = objSpeed.GetSpeeds(strWhere, strOrderBy);

            Assert.IsTrue(lstSpeeds.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSpeeds(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetSpeeds_WithOutOrderBy_NoResult()
        {
            string strWhere = "SpeedName Like '%Toad%'";
            string strOrderBy = "";

            Speed objSpeed = new Speed();
            List<Speed> lstSpeeds = new List<Speed>();

            lstSpeeds = objSpeed.GetSpeeds(strWhere, strOrderBy);

            Assert.IsTrue(lstSpeeds.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetRaceSpeeds by RaceID method.
        ///</summary>
        #region GetRaceSpeeds(string RaceID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceSpeeds(string RaceID) Method, Good Outcome")]
        public void Test_GetRaceSpeeds_GoodResult()
        {
            int RaceID = 40;
            
            Speed objSpeed = new Speed();
            List<Speed> lstSpeeds = new List<Speed>();

            lstSpeeds = objSpeed.GetRaceSpeeds(RaceID);

            Assert.IsTrue(lstSpeeds.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceSpeeds(string RaceID) Method, No Outcome")]
        public void Test_GetRaceSpeeds_NoResult()
        {
            int RaceID = 1;

            Speed objSpeed = new Speed();
            List<Speed> lstSpeeds = new List<Speed>();

            lstSpeeds = objSpeed.GetRaceSpeeds(RaceID);

            Assert.IsTrue(lstSpeeds.Count == 0);
        }
        #endregion

        #region SaveAndDeleteSpeed()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveSpeed and DeleteSpeed Methods)")]
        public void Test_SaveAndDeleteSpeed()
        {
            bool returnVal;

            objNewSpeed.SaveSpeed();

            Assert.IsTrue(objNewSpeed.SpeedID != 0);

            returnVal = objNewSpeed.DeleteSpeed();

            Assert.IsTrue(returnVal && objNewSpeed.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewSpeed.Validate();
            Assert.IsTrue(objNewSpeed.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewSpeed.SpeedName = "";
            objNewSpeed.Validate();
            Assert.IsTrue(!objNewSpeed.Validated && (objNewSpeed.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
