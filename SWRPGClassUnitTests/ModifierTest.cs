using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Modifier Class
    /// </summary>
    [TestClass]
    public class ModifierTest
    {
        /// <summary>
        /// The object new modifier
        /// </summary>
        Modifier objNewModifier = new Modifier();
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierTest"/> class.
        /// </summary>
        public ModifierTest()
        {
            objNewModifier.ModifierID = 0;
            objNewModifier.ModifierNumber = 5;
            objNewModifier.ModifierPositive = true;
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
        /// Tests the GetModifier by ModifierID method.
        /// </summary>
        #region GetModifier(int ModifierID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetModifier(int ModifierID) Method, Good Outcome")]
        public void Test_GetModifier_ByID_GoodResult()
        {
            int intModifierID = 1;
            Modifier objModifier = new Modifier();

            objModifier.GetModifier(intModifierID);

            Assert.AreEqual(intModifierID, objModifier.ModifierID);
        }

        /// <summary>
        /// Test_s the get modifier_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetModifier(int ModifierID) Method, Bad Outcome")]
        public void Test_GetModifier_ByID_BadResult()
        {
            int intModifierID = 0;
            Modifier objModifier = new Modifier();

            objModifier.GetModifier(intModifierID);

            Assert.IsTrue (objModifier.ModifierNumber == 0);
        }
        #endregion

        ///// <summary>
        ///// Tests the GetModifier by ModifierName method.
        /////</summary>
        //#region GetModifier(string strModifierName)
        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetModifier(string ModifierName) Method, Good Outcome")]
        //public void Test_GetModifier_ByName_GoodResult()
        //{
        //    string strModifierName = "Impel Ally I";
        //    Modifier objModifier = new Modifier();

        //    objModifier.GetModifier(strModifierName);

        //    Assert.AreEqual(strModifierName, objModifier.ModifierName);
        //}

        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the GetModifier(string ModifierName) Method, Bad Outcome")]
        //public void Test_GetModifier_ByName_BadResult()
        //{
        //    string strModifierName = "blah blah";
        //    Modifier objModifier = new Modifier();

        //    objModifier.GetModifier(strModifierName);

        //    Assert.IsNull(objModifier.ModifierName);
        //}
        //#endregion

        /// <summary>
        /// Tests the GetModifiers by strWhere, strOrderBy method.
        /// </summary>
        #region GetModifiers(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetModifiers(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetModifiers_WithOrderBy_GoodResult()
        {
            string strWhere = "ModifierPositive = 1";
            string strOrderBy = "ModifierID";

            Modifier objModifier = new Modifier();
            List<Modifier> lstModifiers = new List<Modifier>();

            lstModifiers = objModifier.GetModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstModifiers.Count > 0);
        }

        /// <summary>
        /// Test_s the get modifiers_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetModifiers(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetModifiers_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ModifierPositive = 1";
            string strOrderBy = "";

            Modifier objModifier = new Modifier();
            List<Modifier> lstModifiers = new List<Modifier>();

            lstModifiers = objModifier.GetModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstModifiers.Count > 0);
        }

        /// <summary>
        /// Test_s the get modifiers_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetModifiers(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetModifiers_WithOrderBy_NoResult()
        {
            string strWhere = "ModifierNumber = 10";
            string strOrderBy = "ModifierID";

            Modifier objModifier = new Modifier();
            List<Modifier> lstModifiers = new List<Modifier>();

            lstModifiers = objModifier.GetModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstModifiers.Count == 0);
        }

        /// <summary>
        /// Test_s the get modifiers_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetModifiers(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetModifiers_WithOutOrderBy_NoResult()
        {
            string strWhere = "ModifierNumber = 10";
            string strOrderBy = "";

            Modifier objModifier = new Modifier();
            List<Modifier> lstModifiers = new List<Modifier>();

            lstModifiers = objModifier.GetModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstModifiers.Count == 0);
        }

        #endregion

        #region SaveAndDeleteModifier()
        /// <summary>
        /// Test_s the save and delete modifier.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveModifier and DeleteModifier Methods)")]
        public void Test_SaveAndDeleteModifier()
        {
            bool returnVal;

            objNewModifier.SaveModifier();

            Assert.IsTrue(objNewModifier.ModifierID != 0);

            returnVal = objNewModifier.DeleteModifier();

            Assert.IsTrue(returnVal && objNewModifier.DeleteOK);
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
            objNewModifier.Validate();
            Assert.IsTrue(objNewModifier.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewModifier.ModifierNumber = 0;
            objNewModifier.Validate();
            Assert.IsTrue(!objNewModifier.Validated && (objNewModifier.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
