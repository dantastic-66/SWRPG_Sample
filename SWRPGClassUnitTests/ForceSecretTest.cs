using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ForceSecret Class
    /// </summary>
    [TestClass]
    public class ForceSecretTest
    {
        ForceSecret objNewForceSecret = new ForceSecret();
        public ForceSecretTest()
        {
            objNewForceSecret.ForceSecretID = 0;
            objNewForceSecret.ForceSecretName = "Test Force Secret";
            objNewForceSecret.ForceSecretDescription = "";
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
        /// Tests the GetForceSecret by ForceSecretID method.
        ///</summary>
        #region GetForceSecret(int ForceSecretID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecret(int ForceSecretID) Method, Good Outcome")]
        public void Test_GetForceSecret_ByID_GoodResult()
        {
            int intForceSecretID = 1;
            ForceSecret objForceSecret = new ForceSecret();

            objForceSecret.GetForceSecret(intForceSecretID);

            Assert.AreEqual(intForceSecretID, objForceSecret.ForceSecretID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecret(int ForceSecretID) Method, Bad Outcome")]
        public void Test_GetForceSecret_ByID_BadResult()
        {
            int intForceSecretID = 0;
            ForceSecret objForceSecret = new ForceSecret();

            objForceSecret.GetForceSecret(intForceSecretID);

            Assert.IsNull(objForceSecret.ForceSecretName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForceSecret by ForceSecretName method.
        ///</summary>
        #region GetForceSecret(string strForceSecretName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecret(string ForceSecretName) Method, Good Outcome")]
        public void Test_GetForceSecret_ByName_GoodResult()
        {
            string strForceSecretName = "Swift Power";
            ForceSecret objForceSecret = new ForceSecret();

            objForceSecret.GetForceSecret(strForceSecretName);

            Assert.AreEqual(strForceSecretName, objForceSecret.ForceSecretName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecret(string ForceSecretName) Method, Bad Outcome")]
        public void Test_GetForceSecret_ByName_BadResult()
        {
            string strForceSecretName = "blah blah";
            ForceSecret objForceSecret = new ForceSecret();

            objForceSecret.GetForceSecret(strForceSecretName);

            Assert.IsNull(objForceSecret.ForceSecretName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForceSecrets by strWhere, strOrderBy method.
        ///</summary>
        #region GetForceSecrets(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecrets(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetForceSecrets_WithOrderBy_GoodResult()
        {
            string strWhere = "ForceSecretName Like '%Swift%'";
            string strOrderBy = "ForceSecretName";

            ForceSecret objForceSecret = new ForceSecret();
            List<ForceSecret> lstForceSecrets = new List<ForceSecret>();

            lstForceSecrets = objForceSecret.GetForceSecrets(strWhere, strOrderBy);

            Assert.IsTrue(lstForceSecrets.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecrets(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetForceSecrets_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ForceSecretName Like '%Swift%'";
            string strOrderBy = "";

            ForceSecret objForceSecret = new ForceSecret();
            List<ForceSecret> lstForceSecrets = new List<ForceSecret>();

            lstForceSecrets = objForceSecret.GetForceSecrets(strWhere, strOrderBy);

            Assert.IsTrue(lstForceSecrets.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecrets(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetForceSecrets_WithOrderBy_NoResult()
        {
            string strWhere = "ForceSecretName Like '%Toad%'";
            string strOrderBy = "ForceSecretName";

            ForceSecret objForceSecret = new ForceSecret();
            List<ForceSecret> lstForceSecrets = new List<ForceSecret>();

            lstForceSecrets = objForceSecret.GetForceSecrets(strWhere, strOrderBy);

            Assert.IsTrue(lstForceSecrets.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForceSecrets(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetForceSecrets_WithOutOrderBy_NoResult()
        {
            string strWhere = "ForceSecretName Like '%Toad%'";
            string strOrderBy = "";

            ForceSecret objForceSecret = new ForceSecret();
            List<ForceSecret> lstForceSecrets = new List<ForceSecret>();

            lstForceSecrets = objForceSecret.GetForceSecrets(strWhere, strOrderBy);

            Assert.IsTrue(lstForceSecrets.Count == 0);
        }

        #endregion

        #region SaveAndDeleteForceSecret()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveForceSecret and DeleteForceSecret Methods)")]
        public void Test_SaveAndDeleteForceSecret()
        {
            bool returnVal;

            objNewForceSecret.SaveForceSecret();

            Assert.IsTrue(objNewForceSecret.ForceSecretID != 0);

            returnVal = objNewForceSecret.DeleteForceSecret();

            Assert.IsTrue(returnVal && objNewForceSecret.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewForceSecret.Validate();
            Assert.IsTrue(objNewForceSecret.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewForceSecret.ForceSecretName = "";
            objNewForceSecret.Validate();
            Assert.IsTrue(!objNewForceSecret.Validated && (objNewForceSecret.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
