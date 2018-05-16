using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the RaceAbilityModifier Class
    /// </summary>
    [TestClass]
    public class RaceAbilityModifierTest
    {
        RaceAbilityModifier objNewRaceAbilityModifier = new RaceAbilityModifier();
        public RaceAbilityModifierTest()
        {
            objNewRaceAbilityModifier.RaceID = 1;
            objNewRaceAbilityModifier.AbilityID = 2;
            objNewRaceAbilityModifier.ModifierID = 1;
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
        /// Tests the GetRaceAbilityModifier by RaceAbilityModifierID method.
        ///</summary>
        #region GetRaceAbilityModifier(int RaceID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceAbilityModifier(int RaceID) Method, Good Outcome")]
        public void Test_GetRaceAbilityModifier_ByID_GoodResult()
        {
            int RaceID = 2;
            RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();

            objRaceAbilityModifier.GetRaceAbilityModifier(RaceID);

            Assert.AreEqual(RaceID, objRaceAbilityModifier.RaceID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceAbilityModifier(int RaceID) Method, Bad Outcome")]
        public void Test_GetRaceAbilityModifier_ByID_BadResult()
        {
            int RaceID = 0;
            RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();

            objRaceAbilityModifier.GetRaceAbilityModifier(RaceID);

            Assert.IsTrue(objRaceAbilityModifier.RaceID == 0 && objRaceAbilityModifier.AbilityID == 0 && objRaceAbilityModifier.ModifierID ==0);
        }
        #endregion

        /// <summary>
        /// Tests the GetRaceAbilityModifier by RaceAbilityModifierName method.
        ///</summary>
        //#region GetRaceAbilityModifier(string strRaceAbilityModifierName)
        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetRaceAbilityModifier(string RaceAbilityModifierName) Method, Good Outcome")]
        //public void Test_GetRaceAbilityModifier_ByName_GoodResult()
        //{
        //    string strRaceAbilityModifierName = "Impel Ally I";
        //    RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();

        //    objRaceAbilityModifier.GetRaceAbilityModifier(strRaceAbilityModifierName);

        //    Assert.AreEqual(strRaceAbilityModifierName, objRaceAbilityModifier.RaceAbilityModifierName);
        //}

        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetRaceAbilityModifier(string RaceAbilityModifierName) Method, Bad Outcome")]
        //public void Test_GetRaceAbilityModifier_ByName_BadResult()
        //{
        //    string strRaceAbilityModifierName = "blah blah";
        //    RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();

        //    objRaceAbilityModifier.GetRaceAbilityModifier(strRaceAbilityModifierName);

        //    Assert.IsNull(objRaceAbilityModifier.RaceAbilityModifierName);
        //}
        //#endregion

        /// <summary>
        /// Tests the GetRaceAbilityModifiers by strWhere, strOrderBy method.
        ///</summary>
        #region GetRaceAbilityModifiers(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceAbilityModifiers(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetRaceAbilityModifiers_WithOrderBy_GoodResult()
        {
            string strWhere = "RaceID=2";
            string strOrderBy = "AbilityID";

            RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();
            List<RaceAbilityModifier> lstRaceAbilityModifiers = new List<RaceAbilityModifier>();

            lstRaceAbilityModifiers = objRaceAbilityModifier.GetRaceAbilityModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceAbilityModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceAbilityModifiers(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetRaceAbilityModifiers_WithOutOrderBy_GoodResult()
        {
            string strWhere = "RaceID=2";
            string strOrderBy = "";

            RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();
            List<RaceAbilityModifier> lstRaceAbilityModifiers = new List<RaceAbilityModifier>();

            lstRaceAbilityModifiers = objRaceAbilityModifier.GetRaceAbilityModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceAbilityModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceAbilityModifiers(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetRaceAbilityModifiers_WithOrderBy_NoResult()
        {
            string strWhere = "RaceID=1";
            string strOrderBy = "AbilityID";

            RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();
            List<RaceAbilityModifier> lstRaceAbilityModifiers = new List<RaceAbilityModifier>();

            lstRaceAbilityModifiers = objRaceAbilityModifier.GetRaceAbilityModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceAbilityModifiers.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceAbilityModifiers(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetRaceAbilityModifiers_WithOutOrderBy_NoResult()
        {
            string strWhere = "RaceID=1";
            string strOrderBy = "";

            RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();
            List<RaceAbilityModifier> lstRaceAbilityModifiers = new List<RaceAbilityModifier>();

            lstRaceAbilityModifiers = objRaceAbilityModifier.GetRaceAbilityModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceAbilityModifiers.Count == 0);
        }

        #endregion

        #region SaveAndDeleteRaceAbilityModifier()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveRaceAbilityModifier and DeleteRaceAbilityModifier Methods)")]
        public void Test_SaveAndDeleteRaceAbilityModifier()
        {
            bool returnVal;

            objNewRaceAbilityModifier.SaveRaceAbilityModifier();

            Assert.IsTrue(objNewRaceAbilityModifier.RaceID != 0 && objNewRaceAbilityModifier.AbilityID != 0 && objNewRaceAbilityModifier.ModifierID  !=0);

            returnVal = objNewRaceAbilityModifier.DeleteRaceAbilityModifier();

            Assert.IsTrue(returnVal && objNewRaceAbilityModifier.DeleteOK);
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
            objNewRaceAbilityModifier.Validate();
            Assert.IsTrue(objNewRaceAbilityModifier.Validated);
        }

        /// <summary>
        /// Validate_s the false result_ race identifier.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome RaceID")]
        public void Validate_FalseResult_RaceID()
        {
            objNewRaceAbilityModifier.RaceID = 0;
            objNewRaceAbilityModifier.Validate();
            Assert.IsTrue(!objNewRaceAbilityModifier.Validated && (objNewRaceAbilityModifier.ValidationMessage.Length > 0));
        }

        /// <summary>
        /// Validate_s the false result_ ability identifier.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome AbilityID")]
        public void Validate_FalseResult_AbilityID()
        {
            objNewRaceAbilityModifier.AbilityID  = 0;
            objNewRaceAbilityModifier.Validate();
            Assert.IsTrue(!objNewRaceAbilityModifier.Validated && (objNewRaceAbilityModifier.ValidationMessage.Length > 0));
        }

        /// <summary>
        /// Validate_s the false result_ modifier identifier.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome ModifierID")]
        public void Validate_FalseResult_ModifierID()
        {
            objNewRaceAbilityModifier.ModifierID  = 0;
            objNewRaceAbilityModifier.Validate();
            Assert.IsTrue(!objNewRaceAbilityModifier.Validated && (objNewRaceAbilityModifier.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
