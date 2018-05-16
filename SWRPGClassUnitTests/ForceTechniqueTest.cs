using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ForceTechnique Class
    /// </summary>
    [TestClass]
    public class ForceTechniqueTest
    {
        ForceTechnique objNewForceTechnique = new ForceTechnique();
        public ForceTechniqueTest()
        {
            objNewForceTechnique.ForceTechniqueID  = 0;
            objNewForceTechnique.ForceTechniqueName = "Test Force Technique";
            objNewForceTechnique.ForceTechniqueDescription = "";
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
        /// Tests the GetForceTechnique by ForceTechniqueID method.
        ///</summary>
        #region GetForceTechnique(int ForceTechniqueID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechnique(int ForceTechniqueID) Method, Good Outcome")]
        public void Test_GetForceTechnique_ByID_GoodResult()
        {
            int intForceTechniqueID = 1;
            ForceTechnique objForceTechnique = new ForceTechnique();

            objForceTechnique.GetForceTechnique(intForceTechniqueID);

            Assert.AreEqual(intForceTechniqueID, objForceTechnique.ForceTechniqueID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechnique(int ForceTechniqueID) Method, Bad Outcome")]
        public void Test_GetForceTechnique_ByID_BadResult()
        {
            int intForceTechniqueID = 0;
            ForceTechnique objForceTechnique = new ForceTechnique();

            objForceTechnique.GetForceTechnique(intForceTechniqueID);

            Assert.IsNull(objForceTechnique.ForceTechniqueName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForceTechnique by ForceTechniqueName method.
        ///</summary>
        #region GetForceTechnique(string strForceTechniqueName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechnique(string ForceTechniqueName) Method, Good Outcome")]
        public void Test_GetForceTechnique_ByName_GoodResult()
        {
            string strForceTechniqueName = "Force Point Recovery";
            ForceTechnique objForceTechnique = new ForceTechnique();

            objForceTechnique.GetForceTechnique(strForceTechniqueName);

            Assert.AreEqual(strForceTechniqueName, objForceTechnique.ForceTechniqueName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechnique(string ForceTechniqueName) Method, Bad Outcome")]
        public void Test_GetForceTechnique_ByName_BadResult()
        {
            string strForceTechniqueName = "blah blah";
            ForceTechnique objForceTechnique = new ForceTechnique();

            objForceTechnique.GetForceTechnique(strForceTechniqueName);

            Assert.IsNull(objForceTechnique.ForceTechniqueName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForceTechniques by strWhere, strOrderBy method.
        ///</summary>
        #region GetForceTechniques(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechniques(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetForceTechniques_WithOrderBy_GoodResult()
        {
            string strWhere = "ForceTechniqueName Like '%Force%'";
            string strOrderBy = "ForceTechniqueName";

            ForceTechnique objForceTechnique = new ForceTechnique();
            List<ForceTechnique> lstForceTechniques = new List<ForceTechnique>();

            lstForceTechniques = objForceTechnique.GetForceTechniques(strWhere, strOrderBy);

            Assert.IsTrue(lstForceTechniques.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechniques(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetForceTechniques_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ForceTechniqueName Like '%Force%'";
            string strOrderBy = "";

            ForceTechnique objForceTechnique = new ForceTechnique();
            List<ForceTechnique> lstForceTechniques = new List<ForceTechnique>();

            lstForceTechniques = objForceTechnique.GetForceTechniques(strWhere, strOrderBy);

            Assert.IsTrue(lstForceTechniques.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechniques(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetForceTechniques_WithOrderBy_NoResult()
        {
            string strWhere = "ForceTechniqueName Like '%Toad%'";
            string strOrderBy = "ForceTechniqueName";

            ForceTechnique objForceTechnique = new ForceTechnique();
            List<ForceTechnique> lstForceTechniques = new List<ForceTechnique>();

            lstForceTechniques = objForceTechnique.GetForceTechniques(strWhere, strOrderBy);

            Assert.IsTrue(lstForceTechniques.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceTechniques(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetForceTechniques_WithOutOrderBy_NoResult()
        {
            string strWhere = "ForceTechniqueName Like '%Toad%'";
            string strOrderBy = "";

            ForceTechnique objForceTechnique = new ForceTechnique();
            List<ForceTechnique> lstForceTechniques = new List<ForceTechnique>();

            lstForceTechniques = objForceTechnique.GetForceTechniques(strWhere, strOrderBy);

            Assert.IsTrue(lstForceTechniques.Count == 0);
        }

        #endregion

        #region SaveAndDeleteForceTechnique()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveForceTechnique and DeleteForceTechnique Methods)")]
        public void Test_SaveAndDeleteForceTechnique()
        {
            bool returnVal;

            objNewForceTechnique.SaveForceTechnique();

            Assert.IsTrue(objNewForceTechnique.ForceTechniqueID != 0);

            returnVal = objNewForceTechnique.DeleteForceTechnique();

            Assert.IsTrue(returnVal && objNewForceTechnique.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewForceTechnique.Validate();
            Assert.IsTrue(objNewForceTechnique.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewForceTechnique.ForceTechniqueName = "";
            objNewForceTechnique.Validate();
            Assert.IsTrue(!objNewForceTechnique.Validated && (objNewForceTechnique.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
