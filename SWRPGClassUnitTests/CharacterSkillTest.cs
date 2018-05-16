using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the CharacterSkill Class
    /// </summary>
    [TestClass]
    public class CharacterSkillTest
    {
        CharacterSkill objNewCharacterSkill = new CharacterSkill();
        public CharacterSkillTest()
        {
            objNewCharacterSkill.SkillID = 4;
            objNewCharacterSkill.AbilityMod = 1;
            objNewCharacterSkill.CharacterID = 1;
            objNewCharacterSkill.HalfLevel = 4;
            objNewCharacterSkill.Miscellaneous = 1;
            objNewCharacterSkill.SkillFocus = 5;
            objNewCharacterSkill.Trained = 5;

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
        /// Tests the GetCharacterSkill by CharacterID, SkillID method.
        ///</summary>
        #region GetCharacterSkill(int CharacterID, int SkillID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterSkill(int CharacterID, int SkillID) Method, Good Outcome")]
        public void Test_GetCharacterSkill_ByIDs_GoodResult()
        {
            int intCharacterID = 1;
            int intSkillID = 5;
            CharacterSkill objCharacterSkill = new CharacterSkill();

            objCharacterSkill.GetCharacterSkill(intCharacterID, intSkillID );

            Assert.IsTrue ( objCharacterSkill.HalfLevel > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterSkill(int CharacterSkillID) Method, Bad Outcome")]
        public void Test_GetCharacterSkill_ByID_BadResult()
        {
            int intCharacterID = 0;
            int intSkillID = 0;
            CharacterSkill objCharacterSkill = new CharacterSkill();

            objCharacterSkill.GetCharacterSkill(intCharacterID, intSkillID);

            Assert.IsNull(objCharacterSkill.objSkill  );
        }
        #endregion

        /// <summary>
        /// Tests the GetCharacterSkill by CharacterSkillName method.
        ///</summary>
        #region GetCharacterSkill(int intCharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterSkill(int intCharacterID) Method, Good Outcome")]
        public void Test_GetCharacterSkill_ByCharacterIDOnly_GoodResult()
        {
            int intCharacterID = 1;
            List<CharacterSkill> lstCharacterSkill = new List<CharacterSkill>();
            CharacterSkill objCharacterSkill = new CharacterSkill();

            lstCharacterSkill = objCharacterSkill.GetCharacterSkills(intCharacterID);

            Assert.IsTrue(lstCharacterSkill.Count > 0 );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterSkill(int intCharacterID) Method, Bad Outcome")]
        public void Test_GetCharacterSkill_ByCharacterIDOnly_BadResult()
        {
            int intCharacterID = 0;
            List<CharacterSkill> lstCharacterSkill = new List<CharacterSkill>();
            CharacterSkill objCharacterSkill = new CharacterSkill();

            lstCharacterSkill = objCharacterSkill.GetCharacterSkills(intCharacterID);

            Assert.IsTrue(lstCharacterSkill.Count == 0);
        }
        #endregion

        /// <summary>
        /// Tests the IsSkillInList(Skill objSkill, List<CharacterSkill> lstCharSkill) method.
        ///</summary>
        #region IsSkillInList(Skill objSkill, List<CharacterSkill> lstCharSkill)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsSkillInList(Skill objSkill, List<CharacterSkill> lstCharSkill) Method, Good Outcome")]
        public void Test_IsSkillInList_SkillObjParam_GoodResult()
        {
            Skill objSkill = new Skill();
            objSkill.GetSkill(5);

            bool blnFunctionResult;
            int intCharacterID = 1;

            CharacterSkill objCharacterSkill = new CharacterSkill();
            List<CharacterSkill> lstCharacterSkills = new List<CharacterSkill>();

            lstCharacterSkills = objCharacterSkill.GetCharacterSkills(intCharacterID);
            blnFunctionResult = CharacterSkill.IsSkillInList(objSkill, lstCharacterSkills);

            Assert.IsTrue(blnFunctionResult);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsSkillInList(Skill objSkill, List<CharacterSkill> lstCharSkill)  Method, Bad Outcome ")]
        public void Test_IsSkillInList_SkillObjParam_BadResult()
        {
            Skill objSkill = new Skill();
            objSkill.GetSkill(3);

            bool blnFunctionResult;
            int intCharacterID = 1;

            CharacterSkill objCharacterSkill = new CharacterSkill();
            List<CharacterSkill> lstCharacterSkills = new List<CharacterSkill>();

            lstCharacterSkills = objCharacterSkill.GetCharacterSkills(intCharacterID);
            blnFunctionResult = CharacterSkill.IsSkillInList(objSkill, lstCharacterSkills);

            Assert.IsFalse (blnFunctionResult);
        }

   

        #endregion


        /// <summary>
        /// Tests the IsSkillInList(List<Skill> lstSkill, List<CharacterSkill> lstCharSkill) method.
        ///</summary>
        #region IsSkillInList(List<Skill> lstSkill, List<CharacterSkill> lstCharSkill)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsSkillInList(List<Skill> lstSkill, List<CharacterSkill> lstCharSkill) Method, Good Outcome")]
        public void Test_IsSkillInList_SkillListParam_GoodResult()
        {
            Skill objSkill = new Skill();
            objSkill.GetSkill(5);

            Skill objSkill2 = new Skill();
            objSkill2.GetSkill(17);

            List<Skill> lstSkills = new List<Skill>();
            lstSkills.Add(objSkill);
            lstSkills.Add(objSkill2);

            bool blnFunctionResult;
            int intCharacterID = 1;

            CharacterSkill objCharacterSkill = new CharacterSkill();
            List<CharacterSkill> lstCharacterSkills = new List<CharacterSkill>();

            lstCharacterSkills = objCharacterSkill.GetCharacterSkills(intCharacterID);
            blnFunctionResult = CharacterSkill.IsSkillInList(lstSkills, lstCharacterSkills);

            Assert.IsTrue(blnFunctionResult);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsSkillInList(List<Skill> lstSkill, List<CharacterSkill> lstCharSkill)  Method, Bad Outcome ")]
        public void Test_IsSkillInList_SkillListParam_BadResult()
        {
            Skill objSkill = new Skill();
            objSkill.GetSkill(3);

            Skill objSkill2 = new Skill();
            objSkill2.GetSkill(4);

            List<Skill> lstSkills = new List<Skill>();
            lstSkills.Add(objSkill);
            lstSkills.Add(objSkill2);

            bool blnFunctionResult;
            int intCharacterID = 1;

            CharacterSkill objCharacterSkill = new CharacterSkill();
            List<CharacterSkill> lstCharacterSkills = new List<CharacterSkill>();

            lstCharacterSkills = objCharacterSkill.GetCharacterSkills(intCharacterID);
            blnFunctionResult = CharacterSkill.IsSkillInList(lstSkills, lstCharacterSkills);

            Assert.IsFalse(blnFunctionResult);
        }
        #endregion

        #region SaveAndDeleteCharacterSkill()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveCharacterSkill and DeleteCharacterSkill Methods)")]
        public void Test_SaveAndDeleteCharacterSkill()
        {
            bool returnVal;

            objNewCharacterSkill.SaveCharacterSkill();

            CharacterSkill objTestCharSkill = new CharacterSkill();
            objTestCharSkill.GetCharacterSkill(objNewCharacterSkill.CharacterID, objNewCharacterSkill.SkillID);

            Assert.IsNotNull(objNewCharacterSkill.objSkill  );

            returnVal = objNewCharacterSkill.DeleteCharacterSkill();

            Assert.IsTrue(returnVal && objNewCharacterSkill.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewCharacterSkill.Validate();
            Assert.IsTrue(objNewCharacterSkill.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewCharacterSkill.AbilityMod = 0;
            objNewCharacterSkill.CharacterID = 0;
            objNewCharacterSkill.HalfLevel = 0;
            objNewCharacterSkill.Miscellaneous = 0;
            objNewCharacterSkill.SkillFocus = 0;
            objNewCharacterSkill.Trained = 0;
            objNewCharacterSkill.Validate();
            Assert.IsTrue(!objNewCharacterSkill.Validated && (objNewCharacterSkill.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
