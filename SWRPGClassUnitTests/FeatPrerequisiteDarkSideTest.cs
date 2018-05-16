using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the FeatPrerequisiteDarkSide Class
    /// </summary>
    [TestClass]
    public class FeatPrerequisiteDarkSideTest
    {
        FeatPrerequisiteDarkSide objNewFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
        public FeatPrerequisiteDarkSideTest()
        {
            objNewFeatPrerequisiteDarkSide.FeatID = 1;
            objNewFeatPrerequisiteDarkSide.DarkSideScore = 5;
            objNewFeatPrerequisiteDarkSide.TotalDarkSide = false;
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
        /// Tests the GetFeatPrerequisiteDarkSide by FeatPrerequisiteDarkSideID method.
        ///</summary>
        #region GetFeatPrerequisiteDarkSide(int FeatPrerequisiteDarkSideID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteDarkSide(int FeatPrerequisiteDarkSideID) Method, Good Outcome")]
        public void Test_GetFeatPrerequisiteDarkSide_ByID_GoodResult()
        {
            int intFeatID = 828;
            FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();

            objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSide(intFeatID);

            Assert.AreEqual(intFeatID, objFeatPrerequisiteDarkSide.FeatID );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteDarkSide(int FeatPrerequisiteDarkSideID) Method, Bad Outcome")]
        public void Test_GetFeatPrerequisiteDarkSide_ByID_BadResult()
        {
            int intFeatID = 0;
            FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();

            objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSide(intFeatID);

            Assert.IsTrue (objFeatPrerequisiteDarkSide.FeatID == 0);
        }
        #endregion

        ///// <summary>
        ///// Tests the GetFeatPrerequisiteDarkSide by FeatPrerequisiteDarkSideName method.
        /////</summary>
        //#region GetFeatPrerequisiteDarkSide(string strFeatPrerequisiteDarkSideName)
        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetFeatPrerequisiteDarkSide(string FeatPrerequisiteDarkSideName) Method, Good Outcome")]
        //public void Test_GetFeatPrerequisiteDarkSide_ByName_GoodResult()
        //{
        //    string strFeatPrerequisiteDarkSideName = "Impel Ally I";
        //    FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();

        //    objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSide(strFeatPrerequisiteDarkSideName);

        //    Assert.AreEqual(strFeatPrerequisiteDarkSideName, objFeatPrerequisiteDarkSide.FeatPrerequisiteDarkSideName);
        //}

        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetFeatPrerequisiteDarkSide(string FeatPrerequisiteDarkSideName) Method, Bad Outcome")]
        //public void Test_GetFeatPrerequisiteDarkSide_ByName_BadResult()
        //{
        //    string strFeatPrerequisiteDarkSideName = "blah blah";
        //    FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();

        //    objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSide(strFeatPrerequisiteDarkSideName);

        //    Assert.IsNull(objFeatPrerequisiteDarkSide.FeatPrerequisiteDarkSideName);
        //}
        //#endregion

        /// <summary>
        /// Tests the GetFeatPrerequisiteDarkSides by strWhere, strOrderBy method.
        ///</summary>
        #region GetFeatPrerequisiteDarkSides(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteDarkSides(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetFeatPrerequisiteDarkSides_WithOrderBy_GoodResult()
        {
            string strWhere = "DarkSideScore >= 1";
            string strOrderBy = "FeatID";

            FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
            List<FeatPrerequisiteDarkSide> lstFeatPrerequisiteDarkSides = new List<FeatPrerequisiteDarkSide>();

            lstFeatPrerequisiteDarkSides = objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSides(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteDarkSides.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteDarkSides(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetFeatPrerequisiteDarkSides_WithOutOrderBy_GoodResult()
        {
            string strWhere = "DarkSideScore >= 1";
            string strOrderBy = "";

            FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
            List<FeatPrerequisiteDarkSide> lstFeatPrerequisiteDarkSides = new List<FeatPrerequisiteDarkSide>();

            lstFeatPrerequisiteDarkSides = objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSides(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteDarkSides.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteDarkSides(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetFeatPrerequisiteDarkSides_WithOrderBy_NoResult()
        {
            string strWhere = "DarkSideScore >= 5";
            string strOrderBy = "FeatID";

            FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
            List<FeatPrerequisiteDarkSide> lstFeatPrerequisiteDarkSides = new List<FeatPrerequisiteDarkSide>();

            lstFeatPrerequisiteDarkSides = objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSides(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteDarkSides.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteDarkSides(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetFeatPrerequisiteDarkSides_WithOutOrderBy_NoResult()
        {
            string strWhere = "DarkSideScore >= 15";
            string strOrderBy = "";

            FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
            List<FeatPrerequisiteDarkSide> lstFeatPrerequisiteDarkSides = new List<FeatPrerequisiteDarkSide>();

            lstFeatPrerequisiteDarkSides = objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSides(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteDarkSides.Count == 0);
        }

        #endregion

        #region SaveAndDeleteFeatPrerequisiteDarkSide()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveFeatPrerequisiteDarkSide and DeleteFeatPrerequisiteDarkSide Methods)")]
        public void Test_SaveAndDeleteFeatPrerequisiteDarkSide()
        {
            bool returnVal;

            objNewFeatPrerequisiteDarkSide.SaveFeatPrerequisiteDarkSide();

            Assert.IsTrue(objNewFeatPrerequisiteDarkSide.FeatID != 0);

            returnVal = objNewFeatPrerequisiteDarkSide.DeleteFeatPrerequisiteDarkSide();

            Assert.IsTrue(returnVal && objNewFeatPrerequisiteDarkSide.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewFeatPrerequisiteDarkSide.Validate();
            Assert.IsTrue(objNewFeatPrerequisiteDarkSide.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewFeatPrerequisiteDarkSide.FeatID = 0;
            objNewFeatPrerequisiteDarkSide.Validate();
            Assert.IsTrue(!objNewFeatPrerequisiteDarkSide.Validated && (objNewFeatPrerequisiteDarkSide.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
