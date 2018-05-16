using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the WeaponType Class
    /// </summary>
    [TestClass]
    public class WeaponTypeTest
    {
        WeaponType objNewWeaponType = new WeaponType();
        public WeaponTypeTest()
        {
            objNewWeaponType.WeaponTypeID = 0;
            objNewWeaponType.WeaponTypeDescription = "Weapon Type Test";
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
        /// Tests the GetWeaponType by WeaponTypeID method.
        ///</summary>
        #region GetWeaponType(int WeaponTypeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponType(int WeaponTypeID) Method, Good Outcome")]
        public void Test_GetWeaponType_ByID_GoodResult()
        {
            int intWeaponTypeID = 1;
            WeaponType objWeaponType = new WeaponType();

            objWeaponType.GetWeaponType(intWeaponTypeID);

            Assert.AreEqual(intWeaponTypeID, objWeaponType.WeaponTypeID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponType(int WeaponTypeID) Method, Bad Outcome")]
        public void Test_GetWeaponType_ByID_BadResult()
        {
            int intWeaponTypeID = 0;
            WeaponType objWeaponType = new WeaponType();

            objWeaponType.GetWeaponType(intWeaponTypeID);

            Assert.IsNull(objWeaponType.WeaponTypeDescription );
        }
        #endregion

        /// <summary>
        /// Tests the GetWeaponType by WeaponTypeName method.
        ///</summary>
        #region GetWeaponType(string strWeaponTypeName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponType(string WeaponTypeName) Method, Good Outcome")]
        public void Test_GetWeaponType_ByName_GoodResult()
        {
            string strWeaponTypeName = "Simple";
            WeaponType objWeaponType = new WeaponType();

            objWeaponType.GetWeaponType(strWeaponTypeName);

            Assert.AreEqual(strWeaponTypeName, objWeaponType.WeaponTypeDescription );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponType(string WeaponTypeName) Method, Bad Outcome")]
        public void Test_GetWeaponType_ByName_BadResult()
        {
            string strWeaponTypeName = "blah blah";
            WeaponType objWeaponType = new WeaponType();

            objWeaponType.GetWeaponType(strWeaponTypeName);

            Assert.IsNull(objWeaponType.WeaponTypeDescription);
        }
        #endregion

        /// <summary>
        /// Tests the GetWeaponTypes by strWhere, strOrderBy method.
        ///</summary>
        #region GetWeaponTypes(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponTypes(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetWeaponTypes_WithOrderBy_GoodResult()
        {
            string strWhere = "WeaponTypeDescription Like '%s%'";
            string strOrderBy = "WeaponTypeDescription";

            WeaponType objWeaponType = new WeaponType();
            List<WeaponType> lstWeaponTypes = new List<WeaponType>();

            lstWeaponTypes = objWeaponType.GetWeaponTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstWeaponTypes.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponTypes(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetWeaponTypes_WithOutOrderBy_GoodResult()
        {
            string strWhere = "WeaponTypeDescription Like '%s%'";
            string strOrderBy = "";

            WeaponType objWeaponType = new WeaponType();
            List<WeaponType> lstWeaponTypes = new List<WeaponType>();

            lstWeaponTypes = objWeaponType.GetWeaponTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstWeaponTypes.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponTypes(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetWeaponTypes_WithOrderBy_NoResult()
        {
            string strWhere = "WeaponTypeDescription Like '%Toad%'";
            string strOrderBy = "WeaponTypeDescription";

            WeaponType objWeaponType = new WeaponType();
            List<WeaponType> lstWeaponTypes = new List<WeaponType>();

            lstWeaponTypes = objWeaponType.GetWeaponTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstWeaponTypes.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeaponTypes(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetWeaponTypes_WithOutOrderBy_NoResult()
        {
            string strWhere = "WeaponTypeDescription Like '%Toad%'";
            string strOrderBy = "";

            WeaponType objWeaponType = new WeaponType();
            List<WeaponType> lstWeaponTypes = new List<WeaponType>();

            lstWeaponTypes = objWeaponType.GetWeaponTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstWeaponTypes.Count == 0);
        }

        #endregion

        #region SaveAndDeleteWeaponType()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveWeaponType and DeleteWeaponType Methods)")]
        public void Test_SaveAndDeleteWeaponType()
        {
            bool returnVal;

            objNewWeaponType.SaveWeaponType();

            Assert.IsTrue(objNewWeaponType.WeaponTypeID != 0);

            returnVal = objNewWeaponType.DeleteWeaponType();

            Assert.IsTrue(returnVal && objNewWeaponType.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewWeaponType.Validate();
            Assert.IsTrue(objNewWeaponType.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewWeaponType.WeaponTypeDescription = "";
            objNewWeaponType.Validate();
            Assert.IsTrue(!objNewWeaponType.Validated && (objNewWeaponType.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
