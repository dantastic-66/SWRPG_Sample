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
    public class CharacterClassLevelTest
    {
        CharacterClassLevel objNewCharacterClassLevel = new CharacterClassLevel();
        public CharacterClassLevelTest()
        {
            objNewCharacterClassLevel.CharacterID = 1;
            objNewCharacterClassLevel.ClassID = 4;
            objNewCharacterClassLevel.ClassLevel = 1;
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
        /// Tests the GetCharacterClassLevel by CharacterID method.
        ///</summary>
        #region GetCharacterClassLevel(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterClassLevel(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterClassLevel_ByCharacterID_GoodResult()
        {
            int CharacterID = 1;
            CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
            List<CharacterClassLevel> lstCharClassLevel = new List<CharacterClassLevel>();

            lstCharClassLevel = objCharacterClassLevel.GetCharacterClassLevel(CharacterID);

            Assert.IsTrue(lstCharClassLevel.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterClassLevel(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterClassLevel_ByCharacterID_BadResult()
        {
            int CharacterID = 0;
            CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();

            objCharacterClassLevel.GetCharacterClassLevel(CharacterID);

            Assert.IsTrue(objCharacterClassLevel.ClassLevel == 0 && objCharacterClassLevel.ClassID == 0 && objCharacterClassLevel.CharacterID ==0);
        }
        #endregion

        /// <summary>
        /// Tests the IsCharacterClassLevelInList by CharacterClassLevel, List<CharacterClassLevel> method.
        ///</summary>
        #region IsCharacterClassLevelInList(CharacterClassLevel, List<CharacterClassLevel>)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsCharacterClassLevelInList(CharacterClassLevel, List<CharacterClassLevel>) Method, Good Outcome")]
        public void Test_GetCharacterClassLevel_GoodResult()
        {
            bool blnIsInList = false;
            CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
            List<CharacterClassLevel> lstCharacterClassLevel = new List<CharacterClassLevel>();
            lstCharacterClassLevel = objNewCharacterClassLevel.GetCharacterClassLevel(1);
            objCharacterClassLevel = lstCharacterClassLevel[0];

            blnIsInList = CharacterClassLevel.IsCharacterClassLevelInList(objCharacterClassLevel, lstCharacterClassLevel);

            Assert.IsTrue(blnIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsCharacterClassLevelInList(CharacterClassLevel, List<CharacterClassLevel>) Method, Bad Outcome")]
        public void Test_GetCharacterClassLevel_BadResult()
        {
            bool blnIsInList ;
            List<CharacterClassLevel> lstCharacterClassLevel = new List<CharacterClassLevel>();
            lstCharacterClassLevel = objNewCharacterClassLevel.GetCharacterClassLevel(1);

            blnIsInList = CharacterClassLevel.IsCharacterClassLevelInList(objNewCharacterClassLevel, lstCharacterClassLevel);

            Assert.IsFalse(blnIsInList);
        }
        #endregion

        /// <summary>
        /// Tests the IsClassInList by Class objClass, List<CharacterClassLevel> method.
        ///</summary>
        #region IsClassInList(Class objClass, List<CharacterClassLevel> lstCharacterClassLevel)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(Class objClass, List<CharacterClassLevel>) Method, Good Outcome")]
        public void Test_IsClassInList_SingleClassParam_GoodResult()
        {
            bool blnIsInList = false;
            Class objClass = new Class();

            List<CharacterClassLevel> lstCharacterClassLevel = new List<CharacterClassLevel>();
            lstCharacterClassLevel = objNewCharacterClassLevel.GetCharacterClassLevel(1);
            objClass = lstCharacterClassLevel[0].objCharacterClass;

            blnIsInList = CharacterClassLevel.IsClassInList(objClass, lstCharacterClassLevel);

            Assert.IsTrue(blnIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(Class objClass, List<CharacterClassLevel>) Method, Bad Outcome")]
        public void Test_IsClassInList_SingleClassParam_BadResult()
        {
            bool blnIsInList;
            Class objClass = new Class();
            objClass.GetClass(4);

            List<CharacterClassLevel> lstCharacterClassLevel = new List<CharacterClassLevel>();
            lstCharacterClassLevel = objNewCharacterClassLevel.GetCharacterClassLevel(1);

            blnIsInList = CharacterClassLevel.IsClassInList(objClass, lstCharacterClassLevel);

            Assert.IsFalse(blnIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(List<CharacterClassLevel> objClass, List<CharacterClassLevel>) Method, Good Outcome")]
        public void Test_IsClassInList_ListClassParam_GoodResult()
        {
            bool blnIsInList = false;
            Class objClass = new Class();
            Class objClass2 = new Class();
            List<Class> lstClasses = new List<Class>();

            List<CharacterClassLevel> lstCharacterClassLevel = new List<CharacterClassLevel>();
            lstCharacterClassLevel = objNewCharacterClassLevel.GetCharacterClassLevel(1);
            objClass = lstCharacterClassLevel[0].objCharacterClass;
            objClass2 = lstCharacterClassLevel[1].objCharacterClass;
            lstClasses.Add(objClass);
            lstClasses.Add(objClass2);

            blnIsInList = CharacterClassLevel.IsClassInList(lstClasses, lstCharacterClassLevel);

            Assert.IsTrue(blnIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(List<CharacterClassLevel> objClass, List<CharacterClassLevel>) Method, Bad Outcome")]
        public void Test_IsClassInList_ListClassParam_BadResult()
        {
            bool blnIsInList = false;
            Class objClass = new Class();
            Class objClass2 = new Class();
            List<Class> lstClasses = new List<Class>();

            List<CharacterClassLevel> lstCharacterClassLevel = new List<CharacterClassLevel>();
            lstCharacterClassLevel = objNewCharacterClassLevel.GetCharacterClassLevel(1);
            objClass.GetClass(4);
            objClass2.GetClass(2);
            lstClasses.Add(objClass);
            lstClasses.Add(objClass2);

            blnIsInList = CharacterClassLevel.IsClassInList(lstClasses, lstCharacterClassLevel);

            Assert.IsFalse(blnIsInList);
        }
        #endregion

        #region SaveAndDeleteCharacterClassLevel()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveCharacterClassLevel and DeleteCharacterClassLevel Methods)")]
        public void Test_SaveAndDeleteCharacterClassLevel()
        {
            bool returnVal;
            CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
            List<CharacterClassLevel> lstCharClassLevel = new List<CharacterClassLevel>();

            objNewCharacterClassLevel.SaveCharacterClassLevel();
            lstCharClassLevel = objNewCharacterClassLevel.GetCharacterClassLevel(1);
            Assert.IsTrue(CharacterClassLevel.IsCharacterClassLevelInList(objNewCharacterClassLevel, lstCharClassLevel));

            returnVal = objNewCharacterClassLevel.DeleteCharacterClassLevel();

            Assert.IsTrue(returnVal && objNewCharacterClassLevel.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
            objCharacterClassLevel.ClassLevel  = 1;
            objCharacterClassLevel.Validate();
            Assert.IsTrue(objCharacterClassLevel.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
            objCharacterClassLevel.ClassLevel = 0;
            objCharacterClassLevel.Validate();
            Assert.IsTrue(!objCharacterClassLevel.Validated && (objCharacterClassLevel.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
