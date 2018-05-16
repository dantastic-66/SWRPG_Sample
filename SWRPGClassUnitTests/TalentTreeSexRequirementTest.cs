using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the TalentTreeSexRequirement Class
    /// </summary>
    [TestClass]
    public class TalentTreeSexRequirementTest
    {
        TalentTreeSexRequirement objNewTalentTreeSexRequirement = new TalentTreeSexRequirement();
        public TalentTreeSexRequirementTest()
        {
            objNewTalentTreeSexRequirement.TalentTreeID = 1;
            objNewTalentTreeSexRequirement.Sex = "F";
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
        /// Tests the GetTalentTreeSexRequirement by TalentTreeSexRequirementID method.
        ///</summary>
        #region GetTalentTreeSexRequirement(int TalentTreeSexRequirementID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeSexRequirement(int TalentTreeSexRequirementID) Method, Good Outcome")]
        public void Test_GetTalentTreeSexRequirement_ByID_GoodResult()
        {
            int intTalentTreetID = 63;
            TalentTreeSexRequirement objTalentTreeSexRequirement = new TalentTreeSexRequirement();

            objTalentTreeSexRequirement.GetTalentTreeSexRequirement(intTalentTreetID);

            Assert.AreEqual(intTalentTreetID, objTalentTreeSexRequirement.TalentTreeID );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeSexRequirement(int TalentTreeSexRequirementID) Method, Bad Outcome")]
        public void Test_GetTalentTreeSexRequirement_ByID_BadResult()
        {
            int intTalentTreetID = 0;
            TalentTreeSexRequirement objTalentTreeSexRequirement = new TalentTreeSexRequirement();

            objTalentTreeSexRequirement.GetTalentTreeSexRequirement(intTalentTreetID);

            Assert.IsNull(objTalentTreeSexRequirement.Sex);
        }
        #endregion

        /// <summary>
        /// Tests the GetTalentTreeSexRequirements by strWhere, strOrderBy method.
        ///</summary>
        #region GetTalentTreeSexRequirements(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeSexRequirements(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalentTreeSexRequirements_WithOrderBy_GoodResult()
        {
            string strWhere = "Sex Like '%F%'";
            string strOrderBy = "TalentTreeID,Sex";

            TalentTreeSexRequirement objTalentTreeSexRequirement = new TalentTreeSexRequirement();
            List<TalentTreeSexRequirement> lstTalentTreeSexRequirements = new List<TalentTreeSexRequirement>();

            lstTalentTreeSexRequirements = objTalentTreeSexRequirement.GetTalentTreeSexRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeSexRequirements.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeSexRequirements(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalentTreeSexRequirements_WithOutOrderBy_GoodResult()
        {
            string strWhere = "Sex Like '%F%'";
            string strOrderBy = "";

            TalentTreeSexRequirement objTalentTreeSexRequirement = new TalentTreeSexRequirement();
            List<TalentTreeSexRequirement> lstTalentTreeSexRequirements = new List<TalentTreeSexRequirement>();

            lstTalentTreeSexRequirements = objTalentTreeSexRequirement.GetTalentTreeSexRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeSexRequirements.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeSexRequirements(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalentTreeSexRequirements_WithOrderBy_NoResult()
        {
            string strWhere = "Sex Like '%T%'";
            string strOrderBy = "TalentTreeID,Sex";

            TalentTreeSexRequirement objTalentTreeSexRequirement = new TalentTreeSexRequirement();
            List<TalentTreeSexRequirement> lstTalentTreeSexRequirements = new List<TalentTreeSexRequirement>();

            lstTalentTreeSexRequirements = objTalentTreeSexRequirement.GetTalentTreeSexRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeSexRequirements.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeSexRequirements(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalentTreeSexRequirements_WithOutOrderBy_NoResult()
        {
            string strWhere = "Sex Like '%T%'";
            string strOrderBy = "";

            TalentTreeSexRequirement objTalentTreeSexRequirement = new TalentTreeSexRequirement();
            List<TalentTreeSexRequirement> lstTalentTreeSexRequirements = new List<TalentTreeSexRequirement>();

            lstTalentTreeSexRequirements = objTalentTreeSexRequirement.GetTalentTreeSexRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeSexRequirements.Count == 0);
        }

        #endregion

        #region SaveAndDeleteTalentTreeSexRequirement()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveTalentTreeSexRequirement and DeleteTalentTreeSexRequirement Methods)")]
        public void Test_SaveAndDeleteTalentTreeSexRequirement()
        {
            bool returnVal;

            objNewTalentTreeSexRequirement.SaveTalentTreeSexRequirement();

            TalentTreeSexRequirement objTTSR = new TalentTreeSexRequirement();
            objTTSR.GetTalentTreeSexRequirement(objNewTalentTreeSexRequirement.TalentTreeID);

            Assert.IsTrue(objNewTalentTreeSexRequirement.TalentTreeID == objTTSR.TalentTreeID );

            returnVal = objNewTalentTreeSexRequirement.DeleteTalentTreeSexRequirement();

            Assert.IsTrue(returnVal && objNewTalentTreeSexRequirement.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewTalentTreeSexRequirement.Validate();
            Assert.IsTrue(objNewTalentTreeSexRequirement.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewTalentTreeSexRequirement.Sex = "";
            objNewTalentTreeSexRequirement.Validate();
            Assert.IsTrue(!objNewTalentTreeSexRequirement.Validated && (objNewTalentTreeSexRequirement.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
