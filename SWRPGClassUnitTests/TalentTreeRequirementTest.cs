using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the TalentTreeRequirement Class
    /// </summary>
    [TestClass]
    public class TalentTreeRequirementTest
    {
        TalentTreeRequirement objNewTalentTreeRequirement = new TalentTreeRequirement();
        public TalentTreeRequirementTest()
        {
            objNewTalentTreeRequirement.TalentTreeRequirementID = 0;
            objNewTalentTreeRequirement.TalentTreeRequirementDescription = "New Talent Tree Requirment Desc.";
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
        /// Tests the GetTalentTreeRequirement by TalentTreeRequirementID method.
        ///</summary>
        #region GetTalentTreeRequirement(int TalentTreeRequirementID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeRequirement(int TalentTreeRequirementID) Method, Good Outcome")]
        public void Test_GetTalentTreeRequirement_ByID_GoodResult()
        {
            int intTalentTreeRequirementID = 1;
            TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();

            objTalentTreeRequirement.GetTalentTreeRequirement(intTalentTreeRequirementID);

            Assert.AreEqual(intTalentTreeRequirementID, objTalentTreeRequirement.TalentTreeRequirementID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeRequirement(int TalentTreeRequirementID) Method, Bad Outcome")]
        public void Test_GetTalentTreeRequirement_ByID_BadResult()
        {
            int intTalentTreeRequirementID = 0;
            TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();

            objTalentTreeRequirement.GetTalentTreeRequirement(intTalentTreeRequirementID);

            Assert.IsNull(objTalentTreeRequirement.TalentTreeRequirementDescription);
        }
        #endregion


        /// <summary>
        /// Tests the GetTalentTreeRequirements by strWhere, strOrderBy method.
        ///</summary>
        #region GetTalentTreeRequirements(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeRequirements(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalentTreeRequirements_WithOrderBy_GoodResult()
        {
            string strWhere = "TalentTreeRequirementDescription Like '%Dark Side%'";
            string strOrderBy = "TalentTreeRequirementDescription";

            TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();
            List<TalentTreeRequirement> lstTalentTreeRequirements = new List<TalentTreeRequirement>();

            lstTalentTreeRequirements = objTalentTreeRequirement.GetTalentTreeRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeRequirements.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeRequirements(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalentTreeRequirements_WithOutOrderBy_GoodResult()
        {
            string strWhere = "TalentTreeRequirementDescription Like '%Dark Side%'";
            string strOrderBy = "";

            TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();
            List<TalentTreeRequirement> lstTalentTreeRequirements = new List<TalentTreeRequirement>();

            lstTalentTreeRequirements = objTalentTreeRequirement.GetTalentTreeRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeRequirements.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeRequirements(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalentTreeRequirements_WithOrderBy_NoResult()
        {
            string strWhere = "TalentTreeRequirementDescription Like '%Toad%'";
            string strOrderBy = "TalentTreeRequirementDescription";

            TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();
            List<TalentTreeRequirement> lstTalentTreeRequirements = new List<TalentTreeRequirement>();

            lstTalentTreeRequirements = objTalentTreeRequirement.GetTalentTreeRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeRequirements.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentTreeRequirements(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalentTreeRequirements_WithOutOrderBy_NoResult()
        {
            string strWhere = "TalentTreeRequirementDescription Like '%Toad%'";
            string strOrderBy = "";

            TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();
            List<TalentTreeRequirement> lstTalentTreeRequirements = new List<TalentTreeRequirement>();

            lstTalentTreeRequirements = objTalentTreeRequirement.GetTalentTreeRequirements(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentTreeRequirements.Count == 0);
        }

        #endregion

        #region SaveAndDeleteTalentTreeRequirement()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveTalentTreeRequirement and DeleteTalentTreeRequirement Methods)")]
        public void Test_SaveAndDeleteTalentTreeRequirement()
        {
            bool returnVal;

            objNewTalentTreeRequirement.SaveTalentTreeRequirement();

            Assert.IsTrue(objNewTalentTreeRequirement.TalentTreeRequirementID != 0);

            returnVal = objNewTalentTreeRequirement.DeleteTalentTreeRequirement ();

            Assert.IsTrue(returnVal && objNewTalentTreeRequirement.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewTalentTreeRequirement.Validate();
            Assert.IsTrue(objNewTalentTreeRequirement.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewTalentTreeRequirement.TalentTreeRequirementDescription = "";
            objNewTalentTreeRequirement.Validate();
            Assert.IsTrue(!objNewTalentTreeRequirement.Validated && (objNewTalentTreeRequirement.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
