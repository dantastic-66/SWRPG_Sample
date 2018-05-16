using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Language Class
    /// </summary>
    [TestClass]
    public class LanguageTest
    {
        /// <summary>
        /// The object new language
        /// </summary>
        Language objNewLanguage = new Language();
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageTest"/> class.
        /// </summary>
        public LanguageTest()
        {
            objNewLanguage.LanguageID = 0;
            objNewLanguage.LanguageName = "Test Language";
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
        /// Tests the GetLanguage by LanguageID method.
        /// </summary>
        #region GetLanguage(int LanguageID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguage(int LanguageID) Method, Good Outcome")]
        public void Test_GetLanguage_ByID_GoodResult()
        {
            int intLanguageID = 1;
            Language objLanguage = new Language();

            objLanguage.GetLanguage(intLanguageID);

            Assert.AreEqual(intLanguageID, objLanguage.LanguageID);
        }

        /// <summary>
        /// Test_s the get language_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguage(int LanguageID) Method, Bad Outcome")]
        public void Test_GetLanguage_ByID_BadResult()
        {
            int intLanguageID = 0;
            Language objLanguage = new Language();

            objLanguage.GetLanguage(intLanguageID);

            Assert.IsNull(objLanguage.LanguageName);
        }
        #endregion

        /// <summary>
        /// Tests the GetLanguage by LanguageName method.
        /// </summary>
        #region GetLanguage(string strLanguageName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguage(string LanguageName) Method, Good Outcome")]
        public void Test_GetLanguage_ByName_GoodResult()
        {
            string strLanguageName = "Basic";
            Language objLanguage = new Language();

            objLanguage.GetLanguage(strLanguageName);

            Assert.AreEqual(strLanguageName, objLanguage.LanguageName);
        }

        /// <summary>
        /// Test_s the get language_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguage(string LanguageName) Method, Bad Outcome")]
        public void Test_GetLanguage_ByName_BadResult()
        {
            string strLanguageName = "blah blah";
            Language objLanguage = new Language();

            objLanguage.GetLanguage(strLanguageName);

            Assert.IsNull(objLanguage.LanguageName);
        }
        #endregion

        /// <summary>
        /// Tests the GetLanguages by strWhere, strOrderBy method.
        /// </summary>
        #region GetLanguages(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguages(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetLanguages_WithOrderBy_GoodResult()
        {
            string strWhere = "LanguageName Like '%Jawa%'";
            string strOrderBy = "LanguageName";

            Language objLanguage = new Language();
            List<Language> lstLanguages = new List<Language>();

            lstLanguages = objLanguage.GetLanguages(strWhere, strOrderBy);

            Assert.IsTrue(lstLanguages.Count > 0);
        }

        /// <summary>
        /// Test_s the get languages_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguages(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetLanguages_WithOutOrderBy_GoodResult()
        {
            string strWhere = "LanguageName Like '%Jawa%'";
            string strOrderBy = "";

            Language objLanguage = new Language();
            List<Language> lstLanguages = new List<Language>();

            lstLanguages = objLanguage.GetLanguages(strWhere, strOrderBy);

            Assert.IsTrue(lstLanguages.Count > 0);
        }

        /// <summary>
        /// Test_s the get languages_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguages(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetLanguages_WithOrderBy_NoResult()
        {
            string strWhere = "LanguageName Like '%Toad%'";
            string strOrderBy = "LanguageName";

            Language objLanguage = new Language();
            List<Language> lstLanguages = new List<Language>();

            lstLanguages = objLanguage.GetLanguages(strWhere, strOrderBy);

            Assert.IsTrue(lstLanguages.Count == 0);
        }

        /// <summary>
        /// Test_s the get languages_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguages(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetLanguages_WithOutOrderBy_NoResult()
        {
            string strWhere = "LanguageName Like '%Toad%'";
            string strOrderBy = "";

            Language objLanguage = new Language();
            List<Language> lstLanguages = new List<Language>();

            lstLanguages = objLanguage.GetLanguages(strWhere, strOrderBy);

            Assert.IsTrue(lstLanguages.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetCharacterLanguages by CharacterID method.
        /// </summary>
        #region GetCharacterLanguages(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetLanguage(int CharacterID) Method, Good Outcome")]
        public void Test_GetLanguage_ByCharacterID_GoodResult()
        {
            int CharacterID = 1;
            Language objLanguage = new Language();
            List<Language> lstLangs = new List<Language>();

            lstLangs = objLanguage.GetCharacterLanguages(CharacterID);

            Assert.IsTrue(lstLangs.Count > 0);
        }

        /// <summary>
        /// Test_s the get character languages_ by character i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterLanguages(int CharacterID) Method, Bad Outcome")]
        public void Test_GetCharacterLanguages_ByCharacterID_BadResult()
        {
            int intLanguageID = 0;
            Language objLanguage = new Language();

            List<Language> lstLangs = new List<Language>();

            lstLangs = objLanguage.GetCharacterLanguages(intLanguageID);

            Assert.IsTrue(lstLangs.Count == 0);
        }
        #endregion
       
        #region SaveAndDeleteLanguage()
        /// <summary>
        /// Test_s the save and delete language.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveLanguage and DeleteLanguage Methods)")]
        public void Test_SaveAndDeleteLanguage()
        {
            bool returnVal;

            objNewLanguage.SaveLanguage();

            Assert.IsTrue(objNewLanguage.LanguageID != 0);

            returnVal = objNewLanguage.DeleteLanguage();

            Assert.IsTrue(returnVal && objNewLanguage.DeleteOK);
        }
        #endregion

        #region SaveAndDeleteCharacterLanguage()
        /// <summary>
        /// Test_s the save and delete character language.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveCharacterLanguage and DeleteCharacterLanguage Methods)")]
        public void Test_SaveAndDeleteCharacterLanguage()
        {
            bool returnVal;
            int CharacterID = 1;
            int LanguageID = 1086;
            Language objLang = new Language();
            objLang = objNewLanguage.SaveCharacterLanguage(CharacterID, LanguageID);

            Assert.IsTrue(objLang.LanguageID != 0);

            returnVal = objNewLanguage.DeleteCharacterLanguage(CharacterID, LanguageID);

            Assert.IsTrue(returnVal && objNewLanguage.DeleteOK);
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
            objNewLanguage.Validate();
            Assert.IsTrue(objNewLanguage.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewLanguage.LanguageName = "";
            objNewLanguage.Validate();
            Assert.IsTrue(!objNewLanguage.Validated && (objNewLanguage.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
