using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the SubSkill Class
    /// </summary>
    [TestClass]
    public class SubSkillTest
    {
        SubSkill objNewSubSkill = new SubSkill();
        public SubSkillTest()
        {
            objNewSubSkill.SubSkillID = 0;
            objNewSubSkill.SubSkillName = "Test SubSkill";
            objNewSubSkill.SubSkillDescription = "Test Description";
            objNewSubSkill.SkillID = 1;
            objNewSubSkill.Trained = false;
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
        /// Tests the GetSubSkill by SubSkillID method.
        ///</summary>
        #region GetSubSkill(int SubSkillID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkill(int SubSkillID) Method, Good Outcome")]
        public void Test_GetSubSkill_ByID_GoodResult()
        {
            int intSubSkillID = 1;
            SubSkill objSubSkill = new SubSkill();

            objSubSkill.GetSubSkill(intSubSkillID);

            Assert.AreEqual(intSubSkillID, objSubSkill.SubSkillID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkill(int SubSkillID) Method, Bad Outcome")]
        public void Test_GetSubSkill_ByID_BadResult()
        {
            int intSubSkillID = 0;
            SubSkill objSubSkill = new SubSkill();

            objSubSkill.GetSubSkill(intSubSkillID);

            Assert.IsNull(objSubSkill.SubSkillName);
        }
        #endregion

        /// <summary>
        /// Tests the GetSubSkill by SubSkillName method.
        ///</summary>
        #region GetSubSkill(string strSubSkillName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkill(string SubSkillName) Method, Good Outcome")]
        public void Test_GetSubSkill_ByName_GoodResult()
        {
            string strSubSkillName = "Run";
            SubSkill objSubSkill = new SubSkill();

            objSubSkill.GetSubSkill(strSubSkillName);

            Assert.AreEqual(strSubSkillName, objSubSkill.SubSkillName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkill(string SubSkillName) Method, Bad Outcome")]
        public void Test_GetSubSkill_ByName_BadResult()
        {
            string strSubSkillName = "blah blah";
            SubSkill objSubSkill = new SubSkill();

            objSubSkill.GetSubSkill(strSubSkillName);

            Assert.IsNull(objSubSkill.SubSkillName);
        }
        #endregion

        /// <summary>
        /// Tests the GetSubSkills by strWhere, strOrderBy method.
        ///</summary>
        #region GetSubSkills(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkills(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetSubSkills_WithOrderBy_GoodResult()
        {
            string strWhere = "SubSkillName Like '%Feint%'";
            string strOrderBy = "SubSkillName";

            SubSkill objSubSkill = new SubSkill();
            List<SubSkill> lstSubSkills = new List<SubSkill>();

            lstSubSkills = objSubSkill.GetSubSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSubSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkills(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetSubSkills_WithOutOrderBy_GoodResult()
        {
            string strWhere = "SubSkillName Like '%Feint%'";
            string strOrderBy = "";

            SubSkill objSubSkill = new SubSkill();
            List<SubSkill> lstSubSkills = new List<SubSkill>();

            lstSubSkills = objSubSkill.GetSubSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSubSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkills(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetSubSkills_WithOrderBy_NoResult()
        {
            string strWhere = "SubSkillName Like '%Toad%'";
            string strOrderBy = "SubSkillName";

            SubSkill objSubSkill = new SubSkill();
            List<SubSkill> lstSubSkills = new List<SubSkill>();

            lstSubSkills = objSubSkill.GetSubSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSubSkills.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSubSkills(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetSubSkills_WithOutOrderBy_NoResult()
        {
            string strWhere = "SubSkillName Like '%Toad%'";
            string strOrderBy = "";

            SubSkill objSubSkill = new SubSkill();
            List<SubSkill> lstSubSkills = new List<SubSkill>();

            lstSubSkills = objSubSkill.GetSubSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSubSkills.Count == 0);
        }

        #endregion

        #region SaveAndDeleteSubSkill()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveSubSkill and DeleteSubSkill Methods)")]
        public void Test_SaveAndDeleteSubSkill()
        {
            bool returnVal;

            objNewSubSkill.SaveSubSkill();

            Assert.IsTrue(objNewSubSkill.SubSkillID != 0);

            returnVal = objNewSubSkill.DeleteSubSkill();

            Assert.IsTrue(returnVal && objNewSubSkill.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewSubSkill.Validate();
            Assert.IsTrue(objNewSubSkill.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewSubSkill.SubSkillName = "";
            objNewSubSkill.Validate();
            Assert.IsTrue(!objNewSubSkill.Validated && (objNewSubSkill.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
