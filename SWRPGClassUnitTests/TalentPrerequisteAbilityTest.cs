using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Talent Class
    /// </summary>
    [TestClass]
    public class TalentPrerequisteAbilityTest
    {
        TalentPrerequisteAbility objNewTalentPrerequisteAbility = new TalentPrerequisteAbility();
        public TalentPrerequisteAbilityTest()
        {
            objNewTalentPrerequisteAbility.AbilityID = 1;
            objNewTalentPrerequisteAbility.TalentID = 1;
            objNewTalentPrerequisteAbility.AbilityMinimum = 4;
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
        /// Tests the GetTalent by TalentID method.
        ///</summary>
        #region GetTalentPrerequisteAbility(int TalentPrerequisteAbilityID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisteAbility(int TalentPrerequisteAbilityID) Method, Good Outcome")]
        public void Test_GetTalentPrerequisteAbility_ByID_GoodResult()
        {
            int TalentID = 23;
            int AbilityID = 6;
            TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();

            objTalentPrerequisteAbility.GetTalentPrerequisteAbility(TalentID, AbilityID);

            Assert.AreEqual(TalentID, objTalentPrerequisteAbility.TalentID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisteAbility(int TalentPrerequisteAbilityID) Method, Good Outcome")]
        public void Test_GetTalentPrerequisteAbility_ByID_BadResult()
        {
            int TalentID = 0;
            int AbilityID = 6;
            TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();

            objTalentPrerequisteAbility.GetTalentPrerequisteAbility(TalentID, AbilityID);

            Assert.IsTrue (objTalentPrerequisteAbility.AbilityMinimum ==0);
        }
        #endregion

        /// <summary>
        /// Tests the GetTalentPrerequisteAbilities by strWhere, strOrderBy method.
        ///</summary>
        #region GetTalentPrerequisteAbilities(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisteAbilities(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalentPrerequisteAbilities_WithOrderBy_GoodResult()
        {
            string strWhere = "TalentID=3708";
            string strOrderBy = "AbilityID";

            TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
            List<TalentPrerequisteAbility> lstTalentPrerequisteAbilitys = new List<TalentPrerequisteAbility>();

            lstTalentPrerequisteAbilitys = objTalentPrerequisteAbility.GetTalentPrerequisteAbilities(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentPrerequisteAbilitys.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisteAbilities(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalentPrerequisteAbilities_WithOutOrderBy_GoodResult()
        {
            string strWhere = "TalentID=3708";
            string strOrderBy = "";

            TalentPrerequisteAbility obTalentPrerequisteAbility = new TalentPrerequisteAbility();
            List<TalentPrerequisteAbility> lstTalentPrerequisteAbilitys = new List<TalentPrerequisteAbility>();

            lstTalentPrerequisteAbilitys = obTalentPrerequisteAbility.GetTalentPrerequisteAbilities(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentPrerequisteAbilitys.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisteAbilitys(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalentPrerequisteAbilitys_WithOrderBy_NoResult()
        {
            string strWhere = "TalentID=1";
            string strOrderBy = "AbilityID";

            TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
            List<TalentPrerequisteAbility> lstTalentPrerequisteAbilitys = new List<TalentPrerequisteAbility>();

            lstTalentPrerequisteAbilitys = objTalentPrerequisteAbility.GetTalentPrerequisteAbilities(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentPrerequisteAbilitys.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisteAbilitys(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalentPrerequisteAbilitys_WithOutOrderBy_NoResult()
        {
            string strWhere = "TalentID=1";
            string strOrderBy = "";

            TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
            List<TalentPrerequisteAbility> lstTalentPrerequisteAbilitys = new List<TalentPrerequisteAbility>();

            lstTalentPrerequisteAbilitys = objTalentPrerequisteAbility.GetTalentPrerequisteAbilities(strWhere, strOrderBy);

            Assert.IsTrue(lstTalentPrerequisteAbilitys.Count == 0);
        }

        #endregion

        #region SaveAndDeleteTalentPrerequisteAbility()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveTalentPrerequisteAbility and DeleteTalentPrerequisteAbility Methods)")]
        public void Test_SaveAndDeleteTalentPrerequisteAbility()
        {
            bool returnVal;

            objNewTalentPrerequisteAbility.SaveTalentPrerequisteAbility();

            TalentPrerequisteAbility objTPA = new TalentPrerequisteAbility();
            objTPA.GetTalentPrerequisteAbility(objNewTalentPrerequisteAbility.TalentID, objNewTalentPrerequisteAbility.AbilityID);

            Assert.IsTrue(objNewTalentPrerequisteAbility.AbilityMinimum == objTPA.AbilityMinimum );

            returnVal = objNewTalentPrerequisteAbility.DeleteTalentPrerequisteAbility();

            Assert.IsTrue(returnVal && objNewTalentPrerequisteAbility.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewTalentPrerequisteAbility.Validate();
            Assert.IsTrue(objNewTalentPrerequisteAbility.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewTalentPrerequisteAbility.AbilityMinimum = 0;
            objNewTalentPrerequisteAbility.Validate();
            Assert.IsTrue(!objNewTalentPrerequisteAbility.Validated && (objNewTalentPrerequisteAbility.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
