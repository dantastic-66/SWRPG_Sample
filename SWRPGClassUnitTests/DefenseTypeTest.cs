using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the DefenseType Class
    /// </summary>
    [TestClass]
    public class DefenseTypeTest
    {
        DefenseType objNewDefenseType = new DefenseType();
        public DefenseTypeTest()
        {
            objNewDefenseType.DefenseTypeID = 0;
            objNewDefenseType.DefenseTypeDescription = "Test";
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
        /// Tests the GetDefenseType by DefenseTypeID method.
        ///</summary>
        #region GetDefenseType(int DefenseTypeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseType(int DefenseTypeID) Method, Good Outcome")]
        public void Test_GetDefenseType_ByID_GoodResult()
        {
            int intDefenseTypeID = 1;
            DefenseType objDefenseType = new DefenseType();

            objDefenseType.GetDefenseType(intDefenseTypeID);

            Assert.AreEqual(intDefenseTypeID, objDefenseType.DefenseTypeID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseType(int DefenseTypeID) Method, Bad Outcome")]
        public void Test_GetDefenseType_ByID_BadResult()
        {
            int intDefenseTypeID = 0;
            DefenseType objDefenseType = new DefenseType();

            objDefenseType.GetDefenseType(intDefenseTypeID);

            Assert.IsNull(objDefenseType.DefenseTypeDescription);
        }
        #endregion

        /// <summary>
        /// Tests the GetDefenseType by DefenseTypeName method.
        ///</summary>
        #region GetDefenseType(string strDefenseTypeName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseType(string DefenseTypeName) Method, Good Outcome")]
        public void Test_GetDefenseType_ByName_GoodResult()
        {
            string strDefenseTypeName = "Will";
            DefenseType objDefenseType = new DefenseType();

            objDefenseType.GetDefenseType(strDefenseTypeName);

            Assert.AreEqual(strDefenseTypeName, objDefenseType.DefenseTypeDescription );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseType(string DefenseTypeName) Method, Bad Outcome")]
        public void Test_GetDefenseType_ByName_BadResult()
        {
            string strDefenseTypeName = "blah blah";
            DefenseType objDefenseType = new DefenseType();

            objDefenseType.GetDefenseType(strDefenseTypeName);

            Assert.IsNull(objDefenseType.DefenseTypeDescription);
        }
        #endregion

        /// <summary>
        /// Tests the GetDefenseTypes by strWhere, strOrderBy method.
        ///</summary>
        #region GetDefenseTypes(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseTypes(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetDefenseTypes_WithOrderBy_GoodResult()
        {
            string strWhere = "DefenseTypeDescription Like '%f%'";
            string strOrderBy = "DefenseTypeDescription";

            DefenseType objDefenseType = new DefenseType();
            List<DefenseType> lstDefenseTypes = new List<DefenseType>();

            lstDefenseTypes = objDefenseType.GetDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenseTypes.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseTypes(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetDefenseTypes_WithOutOrderBy_GoodResult()
        {
            string strWhere = "DefenseTypeDescription Like '%f%'";
            string strOrderBy = "";

            DefenseType objDefenseType = new DefenseType();
            List<DefenseType> lstDefenseTypes = new List<DefenseType>();

            lstDefenseTypes = objDefenseType.GetDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenseTypes.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseTypes(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetDefenseTypes_WithOrderBy_NoResult()
        {
            string strWhere = "DefenseTypeDescription Like '%Toad%'";
            string strOrderBy = "DefenseTypeDescription";

            DefenseType objDefenseType = new DefenseType();
            List<DefenseType> lstDefenseTypes = new List<DefenseType>();

            lstDefenseTypes = objDefenseType.GetDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenseTypes.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetDefenseTypes(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetDefenseTypes_WithOutOrderBy_NoResult()
        {
            string strWhere = "DefenseTypeDescription Like '%Toad%'";
            string strOrderBy = "";

            DefenseType objDefenseType = new DefenseType();
            List<DefenseType> lstDefenseTypes = new List<DefenseType>();

            lstDefenseTypes = objDefenseType.GetDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstDefenseTypes.Count == 0);
        }

        #endregion

        #region SaveAndDeleteDefenseType()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveDefenseType and DeleteDefenseType Methods)")]
        public void Test_SaveAndDeleteDefenseType()
        {
            bool returnVal;

            objNewDefenseType.SaveDefenseType();

            Assert.IsTrue(objNewDefenseType.DefenseTypeID != 0);

            returnVal = objNewDefenseType.DeleteDefenseType();

            Assert.IsTrue(returnVal && objNewDefenseType.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewDefenseType.Validate();
            Assert.IsTrue(objNewDefenseType.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewDefenseType.DefenseTypeDescription = "";
            objNewDefenseType.Validate();
            Assert.IsTrue(!objNewDefenseType.Validated && (objNewDefenseType.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
