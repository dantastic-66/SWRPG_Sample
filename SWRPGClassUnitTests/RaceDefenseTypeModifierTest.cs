using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the RaceDefenseTypeModifier Class
    /// </summary>
    [TestClass]
    public class RaceDefenseTypeModifierTest
    {
        RaceDefenseTypeModifier objNewRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
        public RaceDefenseTypeModifierTest()
        {
            objNewRaceDefenseTypeModifier.RaceID = 1;
            objNewRaceDefenseTypeModifier.DefenseTypeID  = 2;
            objNewRaceDefenseTypeModifier.ModifierID = 1;
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

        #region GetRaceDefenseTypeModifiersByRace(int RaceID, string strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiersByRace(int RaceID, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetRaceDefenseTypeModifiersByRace_WithOrderBy_GoodResult()
        {
            int RaceID = 2;
            string strOrderBy = "DefenseTypeID";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiersByRace(RaceID, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiersByRace(int RaceID, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetRaceDefenseTypeModifiersByRace_WithOutOrderBy_GoodResult()
        {
            int RaceID = 2;
            string strOrderBy = "";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiersByRace(RaceID, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiersByRace(int RaceID, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetRaceDefenseTypeModifiersByRace_WithOrderBy_NoResult()
        {
            int RaceID = 0;
            string strOrderBy = "DefenseTypeID";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiersByRace(RaceID, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiersByRace(int RaceID, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetRaceDefenseTypeModifiersByRace_WithOutOrderBy_NoResult()
        {
            int RaceID =0;
            string strOrderBy = "";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiersByRace(RaceID, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetRaceDefenseTypeModifier by RaceID, DefenseTypeID method.
        ///</summary>
        #region GetRaceDefenseTypeModifier(int RaceID, int DefenseTypeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifier(int RaceID, int DefenseTypeID) Method, Good Outcome")]
        public void Test_GetRaceDefenseTypeModifier_ByRaceIDDefenseTypeID_GoodResult()
        {
            int RaceID = 2;
            int DefenseTypeID = 1;

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();

            objRaceDefenseTypeModifier.GetRaceDefenseTypeModifier(RaceID, DefenseTypeID);

            Assert.IsTrue(RaceID == objRaceDefenseTypeModifier.RaceID && DefenseTypeID == objRaceDefenseTypeModifier.DefenseTypeID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifier(int RaceID, int DefenseTypeID) Method, Bad Outcome")]
        public void Test_GetRaceDefenseTypeModifier_ByRaceIDDefenseTypeID_BadResult()
        {
            int RaceID = 1;
            int DefenseTypeID = 1;
            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();

            objRaceDefenseTypeModifier.GetRaceDefenseTypeModifier(RaceID, DefenseTypeID);

            Assert.IsTrue(objRaceDefenseTypeModifier.RaceID == 0 && objRaceDefenseTypeModifier.ModifierID == 0 && objRaceDefenseTypeModifier.DefenseTypeID ==0);
        }
        #endregion

        /// <summary>
        /// Tests the GetRaceDefenseTypeModifiers by strWhere, strOrderBy method.
        ///</summary>
        #region GetRaceDefenseTypeModifiers(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiers(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetRaceDefenseTypeModifiers_WithOrderBy_GoodResult()
        {
            string strWhere = "RaceID=2";
            string strOrderBy = "DefenseTypeID";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiers(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetRaceDefenseTypeModifiers_WithOutOrderBy_GoodResult()
        {
            string strWhere = "RaceID=2";
            string strOrderBy = "";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiers(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetRaceDefenseTypeModifiers_WithOrderBy_NoResult()
        {
            string strWhere = "RaceID=0";
            string strOrderBy = "DefenseTypeID";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceDefenseTypeModifiers(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetRaceDefenseTypeModifiers_WithOutOrderBy_NoResult()
        {
            string strWhere = "RaceID=0";
            string strOrderBy = "";

            RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
            List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

            lstRaceDefenseTypeModifiers = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstRaceDefenseTypeModifiers.Count == 0);
        }

        #endregion

        #region SaveAndDeleteRaceDefenseTypeModifier()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveRaceDefenseTypeModifier and DeleteRaceDefenseTypeModifier Methods)")]
        public void Test_SaveAndDeleteRaceDefenseTypeModifier()
        {
            bool returnVal;

            objNewRaceDefenseTypeModifier.SaveRaceDefenseTypeModifier();

            RaceDefenseTypeModifier objTestRDM = new RaceDefenseTypeModifier();
            objTestRDM.GetRaceDefenseTypeModifier(objNewRaceDefenseTypeModifier.RaceID, objNewRaceDefenseTypeModifier.DefenseTypeID);
            Assert.IsTrue(objTestRDM.ModifierID == objNewRaceDefenseTypeModifier.ModifierID );

            returnVal = objNewRaceDefenseTypeModifier.DeleteRaceDefenseTypeModifier();

            Assert.IsTrue(returnVal && objNewRaceDefenseTypeModifier.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewRaceDefenseTypeModifier.Validate();
            Assert.IsTrue(objNewRaceDefenseTypeModifier.Validated);
        }


        /// <summary>
        /// Validate_s the false result_ race identifier.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome RaceID")]
        public void Validate_FalseResult_RaceID()
        {
            objNewRaceDefenseTypeModifier.RaceID = 0;
            objNewRaceDefenseTypeModifier.Validate();
            Assert.IsTrue(!objNewRaceDefenseTypeModifier.Validated && (objNewRaceDefenseTypeModifier.ValidationMessage.Length > 0));
        }

        /// <summary>
        /// Validate_s the false result_ ability identifier.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome DefenseTypeID")]
        public void Validate_FalseResult_DefenseTypeID()
        {
            objNewRaceDefenseTypeModifier.DefenseTypeID  = 0;
            objNewRaceDefenseTypeModifier.Validate();
            Assert.IsTrue(!objNewRaceDefenseTypeModifier.Validated && (objNewRaceDefenseTypeModifier.ValidationMessage.Length > 0));
        }

        /// <summary>
        /// Validate_s the false result_ modifier identifier.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome ModifierID")]
        public void Validate_FalseResult_ModifierID()
        {
            objNewRaceDefenseTypeModifier.ModifierID = 0;
            objNewRaceDefenseTypeModifier.Validate();
            Assert.IsTrue(!objNewRaceDefenseTypeModifier.Validated && (objNewRaceDefenseTypeModifier.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
