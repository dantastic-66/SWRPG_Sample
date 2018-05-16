using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Ability Class
    /// </summary>
    [TestClass]
    public class AbilityTest
    {
        Ability objNewAbility = new Ability();
        public AbilityTest()
        {
            objNewAbility.AbilityID = 0;
            objNewAbility.AbilityName  = "Test Ability";
            objNewAbility.SortOrder  =0;
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
        /// Tests the GetAbility by AbilityID method, Good Result
        ///</summary>
        #region GetAbility(int AbilityID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbility(int AbilityID) Method, Good Outcome")]
        public void Test_GetAbility_ByID_GoodResult()
        {
            int intAbilityID = 1;
            Ability objAbility = new Ability();

            objAbility.GetAbility(intAbilityID);

            Assert.AreEqual(intAbilityID, objAbility.AbilityID);
        }

        /// <summary>
        /// Tests the GetAbility by AbilityID method, Bad Result
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbility(int AbilityID) Method, Bad Outcome")]
        public void Test_GetAbility_ByID_BadResult()
        {
            int intAbilityID = 0;
            Ability objAbility = new Ability();

            objAbility.GetAbility(intAbilityID);

            Assert.IsNull(objAbility.AbilityName);
        }
        #endregion

        /// <summary>
        /// Tests the GetAbility by AbilityName method, Good Outcome
        ///</summary>
        #region GetAbility(string strAbilityName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbility(string AbilityName) Method, Good Outcome")]
        public void Test_GetAbility_ByName_GoodResult()
        {
            string strAbilityName = "Wisdom";
            Ability objAbility = new Ability();

            objAbility.GetAbility(strAbilityName);

            Assert.AreEqual(strAbilityName, objAbility.AbilityName);
        }

        /// <summary>
        /// Tests the GetAbility by AbilityName method, Bad Outcome
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbility(string AbilityName) Method, Bad Outcome")]
        public void Test_GetAbility_ByName_BadResult()
        {
            string strAbilityName = "blah blah";
            Ability objAbility = new Ability();

            objAbility.GetAbility(strAbilityName);

            Assert.IsNull(objAbility.AbilityName);
        }
        #endregion

        /// <summary>
        /// Tests the GetAbilitys by strWhere, strOrderBy method, Good outcome, with OrderBy
        ///</summary>
        #region GetAbilitys(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbilitys(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetAbilitys_WithOrderBy_GoodResult()
        {
            string strWhere = "AbilityName Like '%C%'";
            string strOrderBy = "AbilityName";

            Ability objAbility = new Ability();
            List<Ability> lstAbilitys = new List<Ability>();

            lstAbilitys = objAbility.GetAbilites (strWhere, strOrderBy);

            Assert.IsTrue(lstAbilitys.Count > 0);
        }

        /// <summary>
        /// Tests the GetAbilitys by strWhere, strOrderBy method, Good outcome, without OrderBy
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbilitys(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetAbilitys_WithOutOrderBy_GoodResult()
        {
            string strWhere = "AbilityName Like '%C%'";
            string strOrderBy = "";

            Ability objAbility = new Ability();
            List<Ability> lstAbilitys = new List<Ability>();

            lstAbilitys = objAbility.GetAbilites(strWhere, strOrderBy);

            Assert.IsTrue(lstAbilitys.Count > 0);
        }

        /// <summary>
        /// Tests the GetAbilitys by strWhere, strOrderBy method, no outcome, with OrderBy
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbilitys(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetAbilitys_WithOrderBy_NoResult()
        {
            string strWhere = "AbilityName Like '%Toad%'";
            string strOrderBy = "AbilityName";

            Ability objAbility = new Ability();
            List<Ability> lstAbilitys = new List<Ability>();

            lstAbilitys = objAbility.GetAbilites(strWhere, strOrderBy);

            Assert.IsTrue(lstAbilitys.Count == 0);
        }

        /// <summary>
        /// Tests the GetAbilitys by strWhere, strOrderBy method, no outcome, without OrderBy
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbilitys(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetAbilitys_WithOutOrderBy_NoResult()
        {
            string strWhere = "AbilityName Like '%Toad%'";
            string strOrderBy = "";

            Ability objAbility = new Ability();
            List<Ability> lstAbilitys = new List<Ability>();

            lstAbilitys = objAbility.GetAbilites (strWhere, strOrderBy);

            Assert.IsTrue(lstAbilitys.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the Save and Delete Ability methods
        ///</summary>
        #region SaveAndDeleteAbility()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveAbility and DeleteAbility Methods)")]
        public void Test_SaveAndDeleteAbility()
        {
            bool returnVal;

            objNewAbility.SaveAbility();

            Assert.IsTrue(objNewAbility.AbilityID != 0);

            returnVal = objNewAbility.DeleteAbility();

            Assert.IsTrue(returnVal && objNewAbility.DeleteOK);
        }
        #endregion

        /// <summary>
        /// Tests the Validate Ability methods, true outcome
        ///</summary>
        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewAbility.Validate();
            Assert.IsTrue(objNewAbility.Validated);
        }

        /// <summary>
        /// Tests the Validate Ability methods, False outcome
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewAbility.AbilityName = "";
            objNewAbility.Validate();
            Assert.IsTrue(!objNewAbility.Validated && (objNewAbility.ValidationMessage.Length > 0));
        }
        #endregion

        /// <summary>
        /// Tests the AblityRequirementMet method, true outcome
        ///</summary>
        #region AblityRequirementMet (int AbilityID, int AbilityMin, Character objChar) returns boolean
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the AblityRequirementMet() Method, True Outcome")]
        public void AblityRequirementMet_TrueResult()
        {
            Character objChar = new Character(1);
            Ability objAbil = new Ability(3); //Wisdom

            bool blnReturnVal = Ability.AblityRequirementMet (objAbil.AbilityID,10 ,objChar);
            Assert.IsTrue(blnReturnVal);
        }

        /// <summary>
        /// Tests the AblityRequirementMet method, false outcome
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the AblityRequirementMet() Method, False Outcome")]
        public void AblityRequirementMet_FalseResult()
        {
            Character objChar = new Character(1);
            Ability objAbil = new Ability(1); //Strength

            bool blnReturnVal = Ability.AblityRequirementMet(objAbil.AbilityID, 12, objChar);
            Assert.IsFalse(blnReturnVal);
        }
        #endregion

        /// <summary>
        /// Tests the IncreaseCharacterAbility method, true outcome
        ///</summary>
        #region IncreaseCharacterAbility (int AbilityID, int IncreaseAmount, ref Character objChar) returns void
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IncreaseCharacterAbility() Method, True Outcome")]
        public void IncreaseCharacterAbility_TrueResult()
        {
            Character objChar = new Character(1);
            Ability objAbil = new Ability(3); //Wisdom
            int intWisScore = objChar.GetCharacterAbilityScore(objAbil);

            Ability.IncreaseCharacterAbility(objAbil.AbilityID, 2, ref objChar);
            Assert.IsTrue(intWisScore < objChar.GetCharacterAbilityScore(objAbil));

        }
       #endregion

        /// <summary>
        /// Tests the GetAbilityMod method, Good Result
        ///</summary>
        #region GetAbilityMod (int AbilityID, Character objChar) returns int
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAbilityMod() Method, Good Outcome")]
        public void GetAbilityMod_GoodResult()
        {
            Character objChar = new Character(1);
            Ability objAbil = new Ability(3); //Wisdom
            int intWisMod = Ability.GetAbilityMod(objAbil.AbilityID, objChar);

            Assert.IsTrue(intWisMod ==4);

        }
        #endregion
        
        /// <summary>
        /// Tests the  Clone(Ability objAbility) method, Good Result
        ///</summary>
        #region Clone(Ability objAbility) returns Abililty
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Clone(Ability objAbility) Method, Good Outcome")]
        public void CloneObject_GoodResult()
        {
            Ability objAbil = new Ability(3); //Wisdom
            Ability objClone = new Ability();

            objClone = Ability.Clone(objAbil);
            Assert.IsTrue((objAbil != objClone) && (objClone.AbilityID == objAbil.AbilityID));
        }
        #endregion

        /// <summary>
        /// Tests the  Clone(List [Ability] lstAbility) method, Good Result
        ///</summary>
        #region Clone(List<Ability> lstAbility) returns List<Ability>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Clone(List<Ability> lstAbility) Method, Good Outcome")]
        public void CloneList_GoodResult()
        {
            Ability objAbil = new Ability(3); //Wisdom
            Ability objAbil2 = new Ability(1); //Strength
            List<Ability> lstAbility = new List<Ability>();
            lstAbility.Add(objAbil);
            lstAbility.Add(objAbil2);
            List<Ability> lstClone = new List<Ability>();

            lstClone = Ability.Clone(lstAbility);
            Assert.IsTrue(lstClone.Count == 2);
        }
        #endregion
    }
}
