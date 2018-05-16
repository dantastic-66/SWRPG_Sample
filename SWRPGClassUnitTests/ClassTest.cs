using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Class Class
    /// </summary>
    [TestClass]
    public class ClassTest
    {
        Class objNewClass = new Class();
        public ClassTest()
        {
            objNewClass.ClassID = 0;
            objNewClass.ClassName = "Test Class";
            objNewClass.HitDieType = 8;
            objNewClass.IsPrestige = true ;
            objNewClass.PrestigeRequiredBaseAttack = 7;
            objNewClass.PrestigeRequiredDarkside = false;
            objNewClass.PrestigeRequiredFeats = 0;
            objNewClass.PrestigeRequiredForceTech = true;
            objNewClass.PrestigeRequiredLevel = 7;
            objNewClass.PrestigeRequiredTalents = 0;
            objNewClass.StartCreditDie = 4;
            objNewClass.StartCreditDieModifier = 250;
            objNewClass.StartCreditDieNumber = 4;
            objNewClass.StartingSkillNumber = 3;
            objNewClass.StartingSkills = 3;
            
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
        /// Tests the GetClass by ClassID method.
        ///</summary>
        #region GetClass(int ClassID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClass(int ClassID) Method, Good Outcome")]
        public void Test_GetClass_ByID_GoodResult()
        {
            int intClassID = 1;
            Class objClass = new Class();

            objClass.GetClass(intClassID);

            Assert.AreEqual(intClassID, objClass.ClassID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClass(int ClassID) Method, Bad Outcome")]
        public void Test_GetClass_ByID_BadResult()
        {
            int intClassID = 0;
            Class objClass = new Class();

            objClass.GetClass(intClassID);

            Assert.IsNull(objClass.ClassName);
        }
        #endregion

        /// <summary>
        /// Tests the GetClass by ClassName method.
        ///</summary>
        #region GetClass(string strClassName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClass(string ClassName) Method, Good Outcome")]
        public void Test_GetClass_ByName_GoodResult()
        {
            string strClassName = "Jedi";
            Class objClass = new Class();

            objClass.GetClass(strClassName);

            Assert.AreEqual(strClassName, objClass.ClassName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClass(string ClassName) Method, Bad Outcome")]
        public void Test_GetClass_ByName_BadResult()
        {
            string strClassName = "blah blah";
            Class objClass = new Class();

            objClass.GetClass(strClassName);

            Assert.IsNull(objClass.ClassName);
        }
        #endregion

        #region GetFeatPrerequisiteClass(int FeatID)
        /// <summary>
        /// Test_s the get feat prerequisite class_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteClass(int FeatID) Method, Good Outcome")]
        public void Test_GetFeatPrerequisiteClass_GoodResult()
        {
            //TODO: Create Test For this, currently no Feats are Class specific
            //int intFeatID = 809;
            //int intClassID = 1;
            //string strClassName = "Jedi";
            //Class objClass = new Class();

            //objClass.GetClass(strClassName);

            //Assert.AreEqual(strClassName, objClass.ClassName);
            Assert.IsTrue(true);
        }
        /// <summary>
        /// Test_s the get feat prerequisite class_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteClass(int FeatID) Method, Bad Outcome")]
        public void Test_GetFeatPrerequisiteClass_BadResult()
        {
            //TODO: Create Test For this, currently no Feats are Class specific
            //int intFeatID = 809;
            //int intClassID = 1;
            //string strClassName = "Jedi";
            //Class objClass = new Class();

            //objClass.GetClass(strClassName);

            //Assert.AreEqual(strClassName, objClass.ClassName);
            Assert.IsFalse(false);
        }
        #endregion

        /// <summary>
        /// Tests the GetClasss by strWhere, strOrderBy method.
        ///</summary>
        #region GetClasss(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClasses(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetClasses_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassName Like '%Jedi%'";
            string strOrderBy = "ClassName";

            Class objClass = new Class();
            List<Class> lstClasss = new List<Class>();

            lstClasss = objClass.GetClasses(strWhere, strOrderBy);

            Assert.IsTrue(lstClasss.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClasses(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetClasses_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassName Like '%Jedi%'";
            string strOrderBy = "";

            Class objClass = new Class();
            List<Class> lstClasss = new List<Class>();

            lstClasss = objClass.GetClasses(strWhere, strOrderBy);

            Assert.IsTrue(lstClasss.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClasses(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetClasses_WithOrderBy_NoResult()
        {
            string strWhere = "ClassName Like '%Toad%'";
            string strOrderBy = "ClassName";

            Class objClass = new Class();
            List<Class> lstClasses = new List<Class>();

            lstClasses = objClass.GetClasses(strWhere, strOrderBy);

            Assert.IsTrue(lstClasses.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClasses(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetClasses_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassName Like '%Toad%'";
            string strOrderBy = "";

            Class objClass = new Class();
            List<Class> lstClasses = new List<Class>();

            lstClasses = objClass.GetClasses(strWhere, strOrderBy);

            Assert.IsTrue(lstClasses.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the IsClassInList by Class, List<Class> method.
        ///</summary>
        #region IsClassInList(Class, List<Class>)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(Class, List<Class>) Method, Good Outcome")]
        public void Test_GetClass_GoodResult()
        {
            bool blnIsInList = false;
            Class objClass = new Class();
            List<Class> lstClass = new List<Class>();
            objClass.GetClass(1);
            lstClass.Add(objClass);

            blnIsInList = Class.IsClassInList(objClass, lstClass);

            Assert.IsTrue(blnIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(Class, List<Class>) Method, Bad Outcome")]
        public void Test_GetClass_BadResult()
        {
            bool blnIsInList;
            List<Class> lstClass = new List<Class>();
            Class objClass = new Class();

            lstClass.Add( objClass.GetClass(1));

            blnIsInList = Class.IsClassInList(objNewClass, lstClass);

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
            //Class objClass2 = new Class();

            List<Class> lstClass = new List<Class>();
            //List<Class> lstClass2 = new List<Class>();

            objClass.GetClass(1);
            //objClass2.GetClass(2);

            lstClass.Add(objClass);
            //lstClass.Add(objClass2);

            //lstClass2.Add(objClass);
            //lstClass2.Add(objClass2);

            blnIsInList = Class.IsClassInList(objClass, lstClass);
            
            Assert.IsTrue(blnIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(Class objClass, List<CharacterClassLevel>) Method, Bad Outcome")]
        public void Test_IsClassInList_SingleClassParam_BadResult()
        {
            bool blnIsInList = false;
            Class objClass = new Class();
            Class objClass2 = new Class();

            List<Class> lstClass = new List<Class>();

            objClass.GetClass(1);
            objClass2.GetClass(2);

            lstClass.Add(objClass);
            blnIsInList = Class.IsClassInList(objClass2, lstClass);

            Assert.IsFalse(blnIsInList);
        }

        /// <summary>
        /// Test_s the is class in list_ list class param_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(List<Class> lstClass, List<Class>) Method, Good Outcome")]
        public void Test_IsClassInList_ListClassParam_GoodResult()
        {
            bool blnIsInList = false;
            Class objClass = new Class();
            Class objClass2 = new Class();

            List<Class> lstClass = new List<Class>();
            List<Class> lstClass2 = new List<Class>();

            objClass.GetClass(1);
            objClass2.GetClass(2);

            lstClass.Add(objClass);
            lstClass.Add(objClass2);

            lstClass2.Add(objClass);
            lstClass2.Add(objClass2);

            blnIsInList = Class.IsClassInList(lstClass, lstClass2);
            

            Assert.IsTrue(blnIsInList);
        }

        /// <summary>
        /// Test_s the is class in list_ list class param_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(List<Class> lstClasss, List<Class>) Method, Bad Outcome")]
        public void Test_IsClassInList_ListClassParam_BadResult()
        {
            bool blnIsInList = false;
            Class objClass = new Class();
            Class objClass2 = new Class();

            Class objClass3 = new Class();
            Class objClass4 = new Class();

            List<Class> lstClass = new List<Class>();
            List<Class> lstClass2 = new List<Class>();

            objClass.GetClass(1);
            objClass2.GetClass(2);

            objClass3.GetClass(3);
            objClass4.GetClass(4);

            lstClass.Add(objClass);
            lstClass.Add(objClass2);

            lstClass2.Add(objClass3);
            lstClass2.Add(objClass4);

            blnIsInList = Class.IsClassInList(lstClass, lstClass2);

            Assert.IsFalse(blnIsInList);
        }
        #endregion

         /// <summary>
        /// Test_s the save and delete class.
        /// </summary>
        /// TODO Edit XML Comment Template for Test_SaveAndDeleteClass
        #region SaveAndDeleteClass()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveClass and DeleteClass Methods)")]
        public void Test_SaveAndDeleteClass()
        {
            bool returnVal;

            objNewClass.SaveClass();

            Assert.IsTrue(objNewClass.ClassID != 0);

            returnVal = objNewClass.DeleteClass();

            Assert.IsTrue(returnVal && objNewClass.DeleteOK);
        }
        #endregion

        /// <summary>
        /// Validate_s the true result.
        /// </summary>
        /// TODO Edit XML Comment Template for Validate_TrueResult
        #region Validate() returns bool

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewClass.Validate();
            Assert.IsTrue(objNewClass.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        /// TODO Edit XML Comment Template for Validate_FalseResult
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewClass.ClassName = "";
            objNewClass.Validate();
            Assert.IsTrue(!objNewClass.Validated && (objNewClass.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
