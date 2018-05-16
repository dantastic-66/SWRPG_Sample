using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Defense Class
    /// </summary>
    [TestClass]
    public class DefenseTest
    {
        CharacterDefense objNewDefense = new CharacterDefense();
        public DefenseTest()
        {
            //objNewDefense.DefenseID = 4;
            objNewDefense.CharacterID = 1;
            objNewDefense.DefenseTypeID = 1;
            objNewDefense.CharacterLevelArmor = 4;
            objNewDefense.AbilityMod = 4;
            objNewDefense.ClassMod = 1;
            objNewDefense.RaceMod = 4;
            objNewDefense.FeatTalentMod = 4;
            objNewDefense.MiscellaneousMod = 0;
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
        /// Tests the GetDefense by DefenseID method.
        ///</summary>
        #region GetDefense(int DefenseID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefense(int DefenseID) Method, Good Outcome")]
        public void Test_GetDefense_ByCharacterIDDefenseTypeID_GoodResult()
        {
            int intCharacterID = 1;
            int intDefenseTypeID = 1;
            CharacterDefense objDefense = new CharacterDefense();

            objDefense.GetDefense(intCharacterID, intDefenseTypeID);

            Assert.AreEqual(intCharacterID, objDefense.CharacterID );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefense(int DefenseID) Method, Bad Outcome")]
        public void Test_GetDefense_ByCharacterIDDefenseTypeID_BadResult()
        {
            int intCharacterID = 0;
            int intDefenseTypeID = 1;
            CharacterDefense objDefense = new CharacterDefense();

            objDefense.GetDefense(intCharacterID, intDefenseTypeID);

            Assert.IsNull(objDefense.DefenseType );
        }
        #endregion

        /// <summary>
        /// Tests the GetCharacterDefense by CharacterID method.
        ///</summary>
        #region GetCharacterDefense(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterDefense(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterDefense_ByCharacterID_GoodResult()
        {
            int intCharacterID = 1;
            CharacterDefense objDefense = new CharacterDefense();
            List<CharacterDefense> lstDefenses = new List<CharacterDefense>();

            lstDefenses= objDefense.GetCharacterDefenses(intCharacterID);

            Assert.IsTrue(lstDefenses.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterDefense(int CharacterID) Method, Bad Outcome")]
        public void Test_GetCharacterDefense_ByCharacterID_BadResult()
        {
            int intCharacterID = 0;
            CharacterDefense objDefense = new CharacterDefense();
            List<CharacterDefense> lstDefenses = new List<CharacterDefense>();

            lstDefenses = objDefense.GetCharacterDefenses(intCharacterID);

            Assert.IsTrue(lstDefenses.Count == 0);
        }
        #endregion

        ///// <summary>
        ///// Tests the GetDefense by DefenseName method.
        /////</summary>
        //#region GetDefense(string strDefenseName)
        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetDefense(string DefenseName) Method, Good Outcome")]
        //public void Test_GetDefense_ByName_GoodResult()
        //{
        //    string strDefenseName = "Impel Ally I";
        //    Defense objDefense = new Defense();

        //    objDefense.GetDefense(strDefenseName);

        //    Assert.AreEqual(strDefenseName, objDefense.DefenseName);
        //}

        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetDefense(string DefenseName) Method, Bad Outcome")]
        //public void Test_GetDefense_ByName_BadResult()
        //{
        //    string strDefenseName = "blah blah";
        //    Defense objDefense = new Defense();

        //    objDefense.GetDefense(strDefenseName);

        //    Assert.IsNull(objDefense.DefenseName);
        //}
        //#endregion

        /// <summary>
        /// Tests the GetDefenses by strWhere, strOrderBy method.
        ///</summary>
        #region GetDefenses(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenses(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetDefenses_WithOrderBy_GoodResult()
        {
            string strWhere = "CharacterID=1 AND DefenseTypeID IN (1,2)";
            string strOrderBy = "DefenseTypeID";

            CharacterDefense objDefense = new CharacterDefense();
            List<CharacterDefense> lstDefenses = new List<CharacterDefense>();

            lstDefenses = objDefense.GetDefenses(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenses.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenses(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetDefenses_WithOutOrderBy_GoodResult()
        {
            string strWhere = "CharacterID=1 AND DefenseTypeID IN (1,2)";
            string strOrderBy = "";

            CharacterDefense objDefense = new CharacterDefense();
            List<CharacterDefense> lstDefenses = new List<CharacterDefense>();

            lstDefenses = objDefense.GetDefenses(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenses.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenses(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetDefenses_WithOrderBy_NoResult()
        {
            string strWhere = "CharacterID=0 AND DefenseTypeID IN (1,2)";
            string strOrderBy = "DefenseTypeID";

            CharacterDefense objDefense = new CharacterDefense();
            List<CharacterDefense> lstDefenses = new List<CharacterDefense>();

            lstDefenses = objDefense.GetDefenses(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenses.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenses(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetDefenses_WithOutOrderBy_NoResult()
        {
            string strWhere = "CharacterID=0 AND DefenseTypeID IN (1,2)";
            string strOrderBy = "";

            CharacterDefense objDefense = new CharacterDefense();
            List<CharacterDefense> lstDefenses = new List<CharacterDefense>();

            lstDefenses = objDefense.GetDefenses(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenses.Count == 0);
        }

        #endregion

        #region SaveAndDeleteDefense()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveDefense and DeleteDefense Methods)")]
        public void Test_SaveAndDeleteDefense()
        {
            bool returnVal;

            objNewDefense.SaveDefense();

            Assert.IsTrue(objNewDefense.InsertUpdateOK);

            returnVal = objNewDefense.DeleteDefense();

            Assert.IsTrue(returnVal && objNewDefense.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewDefense.Validate();
            Assert.IsTrue(objNewDefense.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewDefense.CharacterID = 0;
            objNewDefense.Validate();
            Assert.IsTrue(!objNewDefense.Validated && (objNewDefense.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
