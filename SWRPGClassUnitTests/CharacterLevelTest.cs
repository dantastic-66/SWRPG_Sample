using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the CharacterLevel Class
    /// </summary>
    [TestClass]
    public class CharacterLevelTest
    {
        CharacterLevel objNewCharacterLevel = new CharacterLevel();
        public CharacterLevelTest()
        {
            objNewCharacterLevel.AbilityIncrease = true;
            objNewCharacterLevel.CharacterLevelID = 21;
            objNewCharacterLevel.FeatAvailable = true;
            objNewCharacterLevel.MinimumExperience = 1000000;
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
        /// Tests the GetCharacterLevel by CharacterLevelID method.
        ///</summary>
        #region GetCharacterLevel(int CharacterLevelID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterLevel(int CharacterLevelID) Method, Good Outcome")]
        public void Test_GetCharacterLevel_ByID_GoodResult()
        {
            int intCharacterLevelID = 1;
            CharacterLevel objCharacterLevel = new CharacterLevel();

            objCharacterLevel.GetCharacterLevel(intCharacterLevelID);

            Assert.AreEqual(intCharacterLevelID, objCharacterLevel.CharacterLevelID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterLevel(int CharacterLevelID) Method, Good Outcome")]
        public void Test_GetCharacterLevel_ByID_BadResult()
        {
            int intCharacterLevelID = 0;
            CharacterLevel objCharacterLevel = new CharacterLevel();

            objCharacterLevel.GetCharacterLevel(intCharacterLevelID);

            Assert.IsTrue (objCharacterLevel.MinimumExperience == 0 && objCharacterLevel.CharacterLevelID ==0);
        }
        #endregion

        /// <summary>
        /// Tests the GetCharacterLevels by strWhere, strOrderBy method.
        ///</summary>
        #region GetCharacterLevels(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterLevels(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetCharacterLevels_WithOrderBy_GoodResult()
        {
            string strWhere = "CharacterLevelID IN (1,2,3)";
            string strOrderBy = "CharacterLevelID";

            CharacterLevel objCharacterLevel = new CharacterLevel();
            List<CharacterLevel> lstCharacterLevels = new List<CharacterLevel>();

            lstCharacterLevels = objCharacterLevel.GetCharacterLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstCharacterLevels.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterLevels(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetCharacterLevels_WithOutOrderBy_GoodResult()
        {
            string strWhere = "CharacterLevelID IN (1,2,3)";
            string strOrderBy = "";

            CharacterLevel objCharacterLevel = new CharacterLevel();
            List<CharacterLevel> lstCharacterLevels = new List<CharacterLevel>();

            lstCharacterLevels = objCharacterLevel.GetCharacterLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstCharacterLevels.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterLevels(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetCharacterLevels_WithOrderBy_NoResult()
        {
            string strWhere = "CharacterLevelID IN (24,22,23)";
            string strOrderBy = "CharacterLevelID";

            CharacterLevel objCharacterLevel = new CharacterLevel();
            List<CharacterLevel> lstCharacterLevels = new List<CharacterLevel>();

            lstCharacterLevels = objCharacterLevel.GetCharacterLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstCharacterLevels.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterLevels(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetCharacterLevels_WithOutOrderBy_NoResult()
        {
            string strWhere = "CharacterLevelID IN (24,22,23)";
            string strOrderBy = "";

            CharacterLevel objCharacterLevel = new CharacterLevel();
            List<CharacterLevel> lstCharacterLevels = new List<CharacterLevel>();

            lstCharacterLevels = objCharacterLevel.GetCharacterLevels(strWhere, strOrderBy);

            Assert.IsTrue(lstCharacterLevels.Count == 0);
        }

        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewCharacterLevel.Validate();
            Assert.IsTrue(objNewCharacterLevel.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {

            objNewCharacterLevel.MinimumExperience = 0;
            objNewCharacterLevel.Validate();
            Assert.IsTrue(!objNewCharacterLevel.Validated && (objNewCharacterLevel.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
