using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the SizeDefenseModifier Class
    /// </summary>
    [TestClass]
    public class SizeDefenseModifierTest
    {
        SizeDefenseModifier objNewSizeDefenseModifier = new SizeDefenseModifier();
        public SizeDefenseModifierTest()
        {
            objNewSizeDefenseModifier.SizeID = 1;
            objNewSizeDefenseModifier.ModifierID = 1;
            objNewSizeDefenseModifier.DefenseTypeID = 3;
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
        /// Tests the GetSizeDefenseModifier by SizeDefenseModifierID method.
        ///</summary>
        #region GetSizeDefenseModifier(int SizeDefenseModifierID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizeDefenseModifier(int SizeID) Method, Good Outcome")]
        public void Test_GetSizeDefenseModifier_BySizeID_GoodResult()
        {
            int SizeID = 2;
            SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();

            objSizeDefenseModifier.GetSizeDefenseModifier(SizeID);

            Assert.AreEqual(SizeID, objSizeDefenseModifier.SizeID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizeDefenseModifier(int SizeID) Method, Bad Outcome")]
        public void Test_GetSizeDefenseModifier_BySizeID_BadResult()
        {
            int SizeID = 0;
            SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();

            objSizeDefenseModifier.GetSizeDefenseModifier(SizeID);

            Assert.IsTrue(objSizeDefenseModifier.SizeID == 0 && objSizeDefenseModifier.ModifierID == 0 && objSizeDefenseModifier.DefenseTypeID  == 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetSizeDefenseModifiers by strWhere, strOrderBy method.
        ///</summary>
        #region GetSizeDefenseModifiers(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizeDefenseModifiers(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetSizeDefenseModifiers_WithOrderBy_GoodResult()
        {
            string strWhere = "SizeID IN (1,2)";
            string strOrderBy = "SizeID";

            SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();
            List<SizeDefenseModifier> lstSizeDefenseModifiers = new List<SizeDefenseModifier>();

            lstSizeDefenseModifiers = objSizeDefenseModifier.GetSizeDefenseModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstSizeDefenseModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizeDefenseModifiers(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetSizeDefenseModifiers_WithOutOrderBy_GoodResult()
        {
            string strWhere = "SizeID IN (1,2)";
            string strOrderBy = "";

            SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();
            List<SizeDefenseModifier> lstSizeDefenseModifiers = new List<SizeDefenseModifier>();

            lstSizeDefenseModifiers = objSizeDefenseModifier.GetSizeDefenseModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstSizeDefenseModifiers.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizeDefenseModifiers(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetSizeDefenseModifiers_WithOrderBy_NoResult()
        {
            string strWhere = "SizeID=4";
            string strOrderBy = "SizeID";

            SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();
            List<SizeDefenseModifier> lstSizeDefenseModifiers = new List<SizeDefenseModifier>();

            lstSizeDefenseModifiers = objSizeDefenseModifier.GetSizeDefenseModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstSizeDefenseModifiers.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetSizeDefenseModifiers(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetSizeDefenseModifiers_WithOutOrderBy_NoResult()
        {
            string strWhere = "SizeID=4";
            string strOrderBy = "";

            SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();
            List<SizeDefenseModifier> lstSizeDefenseModifiers = new List<SizeDefenseModifier>();

            lstSizeDefenseModifiers = objSizeDefenseModifier.GetSizeDefenseModifiers(strWhere, strOrderBy);

            Assert.IsTrue(lstSizeDefenseModifiers.Count == 0);
        }

        #endregion

        #region SaveAndDeleteSizeDefenseModifier()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveSizeDefenseModifier and DeleteSizeDefenseModifier Methods)")]
        public void Test_SaveAndDeleteSizeDefenseModifier()
        {
            bool returnVal;

            objNewSizeDefenseModifier.SaveSizeDefenseModifier();

            SizeDefenseModifier objSDM = new SizeDefenseModifier();
            objSDM.GetSizeDefenseModifier(objNewSizeDefenseModifier.SizeID );

            Assert.IsTrue(objNewSizeDefenseModifier.ModifierID  == objSDM.ModifierID );

            returnVal = objNewSizeDefenseModifier.DeleteSizeDefenseModifier();

            Assert.IsTrue(returnVal && objNewSizeDefenseModifier.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewSizeDefenseModifier.Validate();
            Assert.IsTrue(objNewSizeDefenseModifier.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewSizeDefenseModifier.ModifierID = 0;
            objNewSizeDefenseModifier.Validate();
            Assert.IsTrue(!objNewSizeDefenseModifier.Validated && (objNewSizeDefenseModifier.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
