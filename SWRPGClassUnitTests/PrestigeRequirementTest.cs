using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the PrestigeRequirement Class
    /// </summary>
    [TestClass]
    public class PrestigeRequirementTest
    {
        PrestigeRequirement objNewPrestigeRequirement = new PrestigeRequirement();
        public PrestigeRequirementTest()
        {
            objNewPrestigeRequirement.PrestigeRequirementID = 0;
            objNewPrestigeRequirement.PrestigeRequirementDescription = "Test Prestige Requirement Description";
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
        /// Tests the GetPrestigeRequirement by PrestigeRequirementID method.
        ///</summary>
        #region GetPrestigeRequirement(int PrestigeRequirementID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequirement(int PrestigeRequirementID) Method, Good Outcome")]
        public void Test_GetPrestigeRequirement_ByID_GoodResult()
        {
            int intPrestigeRequirementID = 2;
            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();

            objPrestigeRequirement.GetPrestigeRequirement(intPrestigeRequirementID);

            Assert.AreEqual(intPrestigeRequirementID, objPrestigeRequirement.PrestigeRequirementID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequirement(int PrestigeRequirementID) Method, Bad Outcome")]
        public void Test_GetPrestigeRequirement_ByID_BadResult()
        {
            int intPrestigeRequirementID = 1;
            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();

            objPrestigeRequirement.GetPrestigeRequirement(intPrestigeRequirementID);

            Assert.IsNull(objPrestigeRequirement.PrestigeRequirementDescription);
        }
        #endregion

        /// <summary>
        /// Tests the GetPrestigeRequirementPrestigeClass by strWhere, strOrderBy method.
        /// </summary>
        #region GetPrestigeRequirementPrestigeClass(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequirementPrestigeClass(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPrestigeRequirementPrestigeClass_WithOrderBy_GoodResult()
        {
            string strWhere = " ClassID=20";
            string strOrderBy = "PrestigeRequirementDescription";

            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
            List<PrestigeRequirement> lstPrestigeRequirements = new List<PrestigeRequirement>();

            lstPrestigeRequirements = objPrestigeRequirement.GetPrestigeRequirementPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstPrestigeRequirements.Count > 0);
        }

        /// <summary>
        /// Tests the GetPrestigeRequirementPrestigeClass with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequirementPrestigeClass(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPrestigeRequirementPrestigeClass_WithOutOrderBy_GoodResult()
        {
            string strWhere = " ClassID=20";
            string strOrderBy = "";

            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
            List<PrestigeRequirement> lstPrestigeRequirements = new List<PrestigeRequirement>();

            lstPrestigeRequirements = objPrestigeRequirement.GetPrestigeRequirementPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstPrestigeRequirements.Count > 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequirementPrestigeClass(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPrestigeRequirementPrestigeClass_WithOrderBy_NoResult()
        {
            string strWhere = " ClassID=1";
            string strOrderBy = "PrestigeRequirementDescription";

            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
            List<PrestigeRequirement> lstPrestigeRequirements = new List<PrestigeRequirement>();

            lstPrestigeRequirements = objPrestigeRequirement.GetPrestigeRequirementPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstPrestigeRequirements.Count == 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequirementPrestigeClass(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPrestigeRequirementPrestigeClass_WithOutOrderBy_NoResult()
        {
            string strWhere = " ClassID=1";
            string strOrderBy = "";

            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
            List<PrestigeRequirement> lstPrestigeRequirements = new List<PrestigeRequirement>();

            lstPrestigeRequirements = objPrestigeRequirement.GetPrestigeRequirementPrestigeClass(strWhere, strOrderBy);

            Assert.IsTrue(lstPrestigeRequirements.Count == 0);
        }

        #endregion


        #region GetCharacterPrestigeRequirement(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterPrestigeRequirement(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterPrestigeRequirement_ByCharacterID_GoodResult()
        {
            int CharacterID =1;
            bool returnVal = false;
            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
            List<PrestigeRequirement> lstPR = new List<PrestigeRequirement>();

            PrestigeRequirement objPR = new PrestigeRequirement();

            //Have to add a prestige requirement to the table for testing
            objPR.GetPrestigeRequirement(2);

            PrestigeRequirement objPR2 = new PrestigeRequirement();
            objPR2.SaveCharacterPrestigeRequirement(objPR.PrestigeRequirementID, CharacterID);

            //Now retrive it
            lstPR = objPrestigeRequirement.GetCharacterPrestigeRequirement(CharacterID);

            //Delete the test requirement
            returnVal = objNewPrestigeRequirement.DeleteCharacterPrestigeRequirement(objPR2.PrestigeRequirementID, CharacterID);

            //Test the Asserts
            Assert.IsTrue(lstPR.Count > 0 && returnVal == true);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterPrestigeRequirement(int CharacterID) Method, Bad Outcome")]
        public void Test_GetCharacterPrestigeRequirement_ByCharacterID_BadResult()
        {
            int CharacterID = 1;
            PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
            List<PrestigeRequirement> lstPR = new List<PrestigeRequirement>();
            lstPR = objPrestigeRequirement.GetCharacterPrestigeRequirement(CharacterID);

            Assert.IsTrue(lstPR.Count == 0);
        }
        #endregion

        #region SaveAndDeletePrestigeRequirement()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SavePrestigeRequirement and DeletePrestigeRequirement Methods)")]
        public void Test_SaveAndDeletePrestigeRequirement()
        {
            bool returnVal;

            objNewPrestigeRequirement.SavePrestigeRequirement();

            Assert.IsTrue(objNewPrestigeRequirement.PrestigeRequirementID != 0);

            returnVal = objNewPrestigeRequirement.DeletePrestigeRequirement();

            Assert.IsTrue(returnVal && objNewPrestigeRequirement.DeleteOK);
        }
        #endregion



        #region SaveAndDeleteCharacterPrestigeRequirement()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SavePrestigeRequirement and DeletePrestigeRequirement Methods)")]
        public void Test_SaveAndDeleteCharacterPrestigeRequirement()
        {
            bool returnVal;
            int characterID = 1;
            PrestigeRequirement objPR = new PrestigeRequirement();
            PrestigeRequirement objPR2 = new PrestigeRequirement();
            objPR.GetPrestigeRequirement(2);

            objPR2.SaveCharacterPrestigeRequirement(objPR.PrestigeRequirementID, characterID);

            List<PrestigeRequirement> lstPR = new List<PrestigeRequirement>();
            lstPR = objPR.GetCharacterPrestigeRequirement(1);

            Assert.IsTrue(lstPR.Count > 0);

            returnVal = objNewPrestigeRequirement.DeleteCharacterPrestigeRequirement(objPR2.PrestigeRequirementID, characterID);

            Assert.IsTrue(returnVal && objNewPrestigeRequirement.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewPrestigeRequirement.Validate();
            Assert.IsTrue(objNewPrestigeRequirement.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewPrestigeRequirement.PrestigeRequirementDescription = "";
            objNewPrestigeRequirement.Validate();
            Assert.IsTrue(!objNewPrestigeRequirement.Validated && (objNewPrestigeRequirement.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
