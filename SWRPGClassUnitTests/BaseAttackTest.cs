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
    public class BaseAttackTest
    {
        BaseAttack objNewBaseAttack = new BaseAttack();
        public BaseAttackTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        #region GetBaseAttack(int BaseAttackID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBaseAttack(int BaseAttackID) Method, Good Outcome")]
        public void Test_GetBaseAttack_ByID_GoodResult()
        {
            int intBaseAttackID = 1;
            BaseAttack objBaseAttack = new BaseAttack();

            objBaseAttack.GetBaseAttack(intBaseAttackID);

            Assert.AreEqual(intBaseAttackID, objBaseAttack.BaseAttackID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBaseAttack(int BaseAttackID) Method, Good Outcome")]
        public void Test_GetBaseAttack_ByID_BadResult()
        {
            int intBaseAttackID = 0;
            BaseAttack objBaseAttack = new BaseAttack();

            objBaseAttack.GetBaseAttack(intBaseAttackID);

            Assert.IsTrue (objBaseAttack.BaseAttackNumber ==0 && objBaseAttack.BaseAttackID ==0);
        }
        #endregion

        /// <summary>
        /// Tests the GetFeatPrequisiteBaseAttackBonus by FeatID method.
        ///</summary>
        #region GetFeatPrequisiteBaseAttackBonus(int BaseAttackID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrequisiteBaseAttackBonus(int FeatID) Method, Good Outcome")]
        public void Test_GetFeatPrequisiteBaseAttackBonus_ByFeatID_GoodResult()
        {
            int intFeatID = 1177;
            BaseAttack objBaseAttack = new BaseAttack();

            objBaseAttack.GetFeatPrequisiteBaseAttackBonus(intFeatID);

            Assert.AreEqual(11, objBaseAttack.BaseAttackNumber);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrequisiteBaseAttackBonus(int FeatID) Method, Good Outcome")]
        public void Test_GetFeatPrequisiteBaseAttackBonus_ByFeatID_BadResult()
        {
            int intFeatID = 0;
            BaseAttack objBaseAttack = new BaseAttack();

            objBaseAttack.GetFeatPrequisiteBaseAttackBonus(intFeatID);

            Assert.IsTrue(objBaseAttack.BaseAttackNumber == 0 && objBaseAttack.BaseAttackID == 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetFeatPrequisiteBaseAttackBonus by FeatID method.
        ///</summary>
        #region GetTalentPrequisiteBaseAttackBonus(int BaseAttackID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrequisiteBaseAttackBonus(int TalentID) Method, Good Outcome")]
        public void Test_GetTalentPrequisiteBaseAttackBonus_ByTalentID_GoodResult()
        {
            int intTalentID = 113;
            BaseAttack objBaseAttack = new BaseAttack();

            objBaseAttack.GetTalentPrequisiteBaseAttackBonus(intTalentID);

            Assert.AreEqual(5, objBaseAttack.BaseAttackNumber);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrequisiteBaseAttackBonus(int TalentID) Method, Good Outcome")]
        public void Test_GetTalentPrequisiteBaseAttackBonus_ByTalentID_BadResult()
        {
            int intTalentID = 0;
            BaseAttack objBaseAttack = new BaseAttack();

            objBaseAttack.GetTalentPrequisiteBaseAttackBonus(intTalentID);

            Assert.IsTrue(objBaseAttack.BaseAttackNumber == 0 && objBaseAttack.BaseAttackID == 0);
        }
        #endregion
        
        /// <summary>
        /// Tests the GetBaseAttacks by strWhere, strOrderBy method.
        ///</summary>
        #region GetBaseAttacks(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBaseAttacks(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetBaseAttacks_WithOrderBy_GoodResult()
        {
            string strWhere = "BaseAttackID in (1,2,3)";
            string strOrderBy = "BaseAttackNumber";

            BaseAttack objBaseAttack = new BaseAttack();
            List<BaseAttack> lstBaseAttacks = new List<BaseAttack>();

            lstBaseAttacks = objBaseAttack.GetBaseAttacks(strWhere, strOrderBy);

            Assert.IsTrue(lstBaseAttacks.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBaseAttacks(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetBaseAttacks_WithOutOrderBy_GoodResult()
        {
            string strWhere = "BaseAttackID in (1,2,3)";
            string strOrderBy = "";

            BaseAttack objBaseAttack = new BaseAttack();
            List<BaseAttack> lstBaseAttacks = new List<BaseAttack>();

            lstBaseAttacks = objBaseAttack.GetBaseAttacks(strWhere, strOrderBy);

            Assert.IsTrue(lstBaseAttacks.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBaseAttacks(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetBaseAttacks_WithOrderBy_NoResult()
        {
            string strWhere = "BaseAttackID = 1000";
            string strOrderBy = "";

            BaseAttack objBaseAttack = new BaseAttack();
            List<BaseAttack> lstBaseAttacks = new List<BaseAttack>();

            lstBaseAttacks = objBaseAttack.GetBaseAttacks(strWhere, strOrderBy);

            Assert.IsTrue(objBaseAttack.BaseAttackNumber ==0 && objBaseAttack.BaseAttackID ==0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBaseAttacks(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetBaseAttacks_WithOutOrderBy_NoResult()
        {
            string strWhere = "BaseAttackID = 1000";
            string strOrderBy = "";

            BaseAttack objBaseAttack = new BaseAttack();
            List<BaseAttack> lstBaseAttacks = new List<BaseAttack>();

            lstBaseAttacks = objBaseAttack.GetBaseAttacks(strWhere, strOrderBy);

            Assert.IsTrue(lstBaseAttacks.Count == 0);
        }

        #endregion

        #region SaveAndDeleteBaseAttack()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveBaseAttack and DeleteBaseAttack Methods)")]
        public void Test_SaveAndDeleteBaseAttack()
        {
            bool returnVal;

            objNewBaseAttack.SaveBaseAttack();

            Assert.IsTrue(objNewBaseAttack.BaseAttackID != 0);

            returnVal = objNewBaseAttack.DeleteBaseAttack();

            Assert.IsTrue(returnVal && objNewBaseAttack.DeleteOK);
        }
        #endregion

    }
}
