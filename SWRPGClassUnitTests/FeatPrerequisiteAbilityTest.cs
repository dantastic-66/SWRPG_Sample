using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the FeatPrerequisiteAbility Class
    /// </summary>
    [TestClass]
    public class FeatPrerequisiteAbilityTest
    {
        /// <summary>
        /// The object new feat prerequisite ability
        /// </summary>
        FeatPrerequisiteAbility objNewFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatPrerequisiteAbilityTest"/> class.
        /// </summary>
        public FeatPrerequisiteAbilityTest()
        {
            objNewFeatPrerequisiteAbility.AbilityID = 1;
            objNewFeatPrerequisiteAbility.FeatID = 1;
            objNewFeatPrerequisiteAbility.AbilityMinimum = 14;
        }

        /// <summary>
        /// The test context instance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
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
        /// Tests the GetFeatPrerequisiteAbility by FeatPrerequisiteAbilityID method.
        /// </summary>
        #region GetFeatPrerequisiteAbility(int FeatID, int AbilityID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteAbility(int FeatID, int AbilityID) Method, Good Outcome")]
        public void Test_GetFeatPrerequisiteAbility_ByID_GoodResult()
        {
            int intFeatID = 16;
            int intAbilityID = 5;
            FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();

            objFeatPrerequisiteAbility.GetFeatPrerequisiteAbility(intFeatID, intAbilityID);

            Assert.AreEqual(intFeatID, objFeatPrerequisiteAbility.FeatID );
        }

        /// <summary>
        /// Test_s the get feat prerequisite ability_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteAbility(int FeatID, int AbilityID) Method, Bad Outcome")]
        public void Test_GetFeatPrerequisiteAbility_ByID_BadResult()
        {
            int intFeatID = 0;
            int intAbilityID = 5;
            FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();

            objFeatPrerequisiteAbility.GetFeatPrerequisiteAbility(intFeatID, intAbilityID);

            Assert.IsTrue (objFeatPrerequisiteAbility.AbilityMinimum == 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetFeatPrerequisiteAbility by FeatPrerequisiteAbilityName method.
        /// </summary>
        #region GetFeatPrerequisiteAbilitys(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteAbilites(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetFeatPrerequisiteAbilites_WithOrderBy_GoodResult()
        {
            string strWhere = "FeatID=797";
            string strOrderBy = "AbilityID";

            FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
            List<FeatPrerequisiteAbility> lstFeatPrerequisiteAbilitys = new List<FeatPrerequisiteAbility>();

            lstFeatPrerequisiteAbilitys = objFeatPrerequisiteAbility.GetFeatPrerequisiteAbilites(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteAbilitys.Count > 0);
        }

        /// <summary>
        /// Test_s the get feat prerequisite abilites_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteAbilitess(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetFeatPrerequisiteAbilites_WithOutOrderBy_GoodResult()
        {
            string strWhere = "FeatID=797";
            string strOrderBy = "";

            FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
            List<FeatPrerequisiteAbility> lstFeatPrerequisiteAbilitys = new List<FeatPrerequisiteAbility>();

            lstFeatPrerequisiteAbilitys = objFeatPrerequisiteAbility.GetFeatPrerequisiteAbilites(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteAbilitys.Count > 0);
        }

        /// <summary>
        /// Test_s the get feat prerequisite abilites_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteAbilites(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetFeatPrerequisiteAbilites_WithOrderBy_NoResult()
        {
            string strWhere = "FeatID=2";
            string strOrderBy = "AbilityID";

            FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
            List<FeatPrerequisiteAbility> lstFeatPrerequisiteAbilitys = new List<FeatPrerequisiteAbility>();

            lstFeatPrerequisiteAbilitys = objFeatPrerequisiteAbility.GetFeatPrerequisiteAbilites(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteAbilitys.Count == 0);
        }

        /// <summary>
        /// Test_s the get feat prerequisite abilites_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteAbilites(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetFeatPrerequisiteAbilites_WithOutOrderBy_NoResult()
        {
            string strWhere = "FeatID=2";
            string strOrderBy = "";

            FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
            List<FeatPrerequisiteAbility> lstFeatPrerequisiteAbilitys = new List<FeatPrerequisiteAbility>();

            lstFeatPrerequisiteAbilitys = objFeatPrerequisiteAbility.GetFeatPrerequisiteAbilites(strWhere, strOrderBy);

            Assert.IsTrue(lstFeatPrerequisiteAbilitys.Count == 0);
        }

        #endregion

        #region SaveAndDeleteFeatPrerequisiteAbility()
        /// <summary>
        /// Test_s the save and delete feat prerequisite ability.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveFeatPrerequisiteAbility and DeleteFeatPrerequisiteAbility Methods)")]
        public void Test_SaveAndDeleteFeatPrerequisiteAbility()
        {
            bool returnVal;

            objNewFeatPrerequisiteAbility.SaveFeatPrerequisiteAbility();
            
            FeatPrerequisiteAbility objFPA = new FeatPrerequisiteAbility();
            objFPA.GetFeatPrerequisiteAbility(objNewFeatPrerequisiteAbility.FeatID, objNewFeatPrerequisiteAbility.AbilityID);

            Assert.IsTrue(objNewFeatPrerequisiteAbility.AbilityMinimum  != 0);

            returnVal = objNewFeatPrerequisiteAbility.DeleteFeatPrerequisiteAbility();

            Assert.IsTrue(returnVal && objNewFeatPrerequisiteAbility.DeleteOK);
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
            objNewFeatPrerequisiteAbility.Validate();
            Assert.IsTrue(objNewFeatPrerequisiteAbility.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewFeatPrerequisiteAbility.AbilityMinimum = 0;
            objNewFeatPrerequisiteAbility.Validate();
            Assert.IsTrue(!objNewFeatPrerequisiteAbility.Validated && (objNewFeatPrerequisiteAbility.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
