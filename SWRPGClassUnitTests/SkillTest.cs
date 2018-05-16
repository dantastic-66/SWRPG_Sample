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
    public class SkillTest
    {
        Skill objNewSkill = new Skill();
        public SkillTest()
        {
            objNewSkill.SkillID=0;
            objNewSkill.SkillName = "Test Skill";
            objNewSkill.SkillDescription ="Test Description";
            objNewSkill.AbilityID = 1;

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
        #region GetSkill(int SkillID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkill(int SkillID) Method, Good Outcome")]
        public void Test_GetSkill_ByID_GoodResult()
        {
            int intSkillID = 1;
            Skill objSkill = new Skill();

            objSkill.GetSkill(intSkillID);

            Assert.AreEqual(intSkillID, objSkill.SkillID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkill(int SkillID) Method, Good Outcome")]
        public void Test_GetSkill_ByID_BadResult()
        {
            int intSkillID = 0;
            Skill objSkill = new Skill();

            objSkill.GetSkill(intSkillID);

            Assert.IsNull(objSkill.SkillName);
        }
        #endregion

        /// <summary>
        /// Tests the GetSkill by SkillName method.
        ///</summary>
        #region GetSkill(string strSkillName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkill(string SkillName) Method, Good Outcome")]
        public void Test_GetSkill_ByName_GoodResult()
        {
            string strSkillName = "Acrobatics";
            Skill objSkill = new Skill();

            objSkill.GetSkill(strSkillName);

            Assert.AreEqual(strSkillName, objSkill.SkillName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkill(string SkillName) Method, Bad Outcome")]
        public void Test_GetSkill_ByName_BadResult()
        {
            string strSkillName = "blah blah";
            Skill objSkill = new Skill();

            objSkill.GetSkill(strSkillName);

            Assert.IsNull(objSkill.SkillName);
        }
        #endregion
        
        /// <summary>
        /// Tests the GetFeatPrerequisiteSkil by FeatID method.
        ///</summary>
        #region GetFeatPrerequisiteSkil(int FeatID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteSkill(int FeatID) Method, Good Outcome")]
        public void Test_GetFeatPrerequisiteSkill_ByID_GoodResult()
        {
            int FeatID = 801;
            Skill objSkill = new Skill();
           
            objSkill.GetFeatPrerequisiteSkill(FeatID);

            Assert.IsNotNull (objSkill.objAbility );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteSkill(int FeatID) Method, Good Outcome")]
        public void Test_GetFeatPrerequisiteSkill_ByID_BadResult()
        {
            int FeatID = 1;
            Skill objSkill = new Skill();

            objSkill.GetFeatPrerequisiteSkill(FeatID);

            Assert.IsNull(objSkill.SkillName);
        }
        #endregion

        /// <summary>
        /// Tests the GetSkills by string strWhere, string strOrderBy method.
        ///</summary>
        #region GetSkills(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkills(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetSkills_WithOrderBy_GoodResult()
        {
            string strWhere = "SkillName Like '%Knowledge%'";
            string strOrderBy = "SkillName";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkills(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetSkills_WithOutOrderBy_GoodResult()
        {
            string strWhere = "SkillName Like '%Knowledge%'";
            string strOrderBy = "";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkills(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetSkills_WithOrderBy_NoResult()
        {
            string strWhere = "SkillName Like '%Toad%'";
            string strOrderBy = "SkillName";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkills(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetSkills_WithOutOrderBy_NoResult()
        {
            string strWhere = "SkillName Like '%Toad%'";
            string strOrderBy = "";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count == 0);
        }

        #endregion

         /// <summary>
        /// Tests the GetCharacterSkills by int CharacterID method.
        ///</summary>
        #region GetCharacterSkills(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterSkills(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterSkills_GoodResult()
        {
            int CharacterID = 1;
            
            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetCharacterSkills(CharacterID);

            Assert.IsTrue(lstSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterSkills(string strWhere, strOrderBy) Method, Good Outcome")]
        public void Test_GetCharacterSkills_BadResult()
        {
            int CharacterID = 0;

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetCharacterSkills(CharacterID);

            Assert.IsTrue(lstSkills.Count == 0);
        }
        #endregion
        
        /// <summary>
        /// Tests the GetSkillsForRace by string strWhere, string strOrderBy method.
        ///</summary>
        #region GetSkillsForRace(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkillsForRace(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetSkillsForRace_WithOrderBy_GoodResult()
        {
            string strWhere = "RaceID=58";
            string strOrderBy = "SkillName";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkillsForRace(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkillsForRace(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetSkillsForRace_WithOutOrderBy_GoodResult()
        {
            string strWhere = "RaceID=58";
            string strOrderBy = "";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkillsForRace(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkillsForRace(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetSkillsForRace_WithOrderBy_NoResult()
        {
            string strWhere = "RaceID=1";
            string strOrderBy = "SkillName";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkillsForRace(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSkillsForRace(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetSkillsForRace_WithOutOrderBy_NoResult()
        {
            string strWhere = "RaceID=1";
            string strOrderBy = "";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetSkillsForRace(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetPrestigeRequiredSkills by string strWhere, string strOrderBy method.
        ///</summary>
        #region GetPrestigeRequiredSkills(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredSkills(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredSkills_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=6";
            string strOrderBy = "SkillName";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetPrestigeRequiredSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredSkills(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredSkills_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=6";
            string strOrderBy = "";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetPrestigeRequiredSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredSkills(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredSkills_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "SkillName";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetPrestigeRequiredSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredSkills(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredSkills_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "";

            Skill objSkill = new Skill();
            List<Skill> lstSkills = new List<Skill>();

            lstSkills = objSkill.GetPrestigeRequiredSkills(strWhere, strOrderBy);

            Assert.IsTrue(lstSkills.Count == 0);
        }

        #endregion


        #region SaveAndDeleteSkill()
        /// <summary>
        /// Test_s the save and delete Skill.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveSkill and DeleteSkill Methods)")]
        public void Test_SaveAndDeleteSkill()
        {
            bool returnVal;

            objNewSkill.SaveSkill();

            Assert.IsTrue(objNewSkill.SkillID != 0);

            returnVal = objNewSkill.DeleteSkill();

            Assert.IsTrue(returnVal && objNewSkill.DeleteOK);
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
            objNewSkill.Validate();
            Assert.IsTrue(objNewSkill.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewSkill.SkillName = "";
            objNewSkill.Validate();
            Assert.IsTrue(!objNewSkill.Validated && (objNewSkill.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
