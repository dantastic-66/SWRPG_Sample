using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ClassDefenseType Class
    /// </summary>
    [TestClass]
    public class ClassDefenseTypeTest
    {
        ClassDefenseType objNewClassDefenseType = new ClassDefenseType();
        public ClassDefenseTypeTest()
        {
            objNewClassDefenseType.ClassID = 6;
            objNewClassDefenseType.DefenseTypeID = 1;
            objNewClassDefenseType.ModifierID = 2;
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
        /// Tests the GetClassDefenseType by ClassDefenseTypeID method.
        ///</summary>
        #region GetClassDefenseType(int ClassDefenseTypeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassDefenseType(int ClassDefenseTypeID) Method, Good Outcome")]
        public void Test_GetClassDefenseType_ByID_GoodResult()
        {
            int ClassID = 1;
            int DefenseTypeID = 1;
            ClassDefenseType objClassDefenseType = new ClassDefenseType();

            objClassDefenseType.GetClassDefenseType(ClassID, DefenseTypeID);

            Assert.IsTrue (objClassDefenseType.ModifierID > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassDefenseType(int ClassDefenseTypeID) Method, Bad Outcome")]
        public void Test_GetClassDefenseType_ByID_BadResult()
        {
            int ClassID = 0;
            int DefenseTypeID = 1;
            ClassDefenseType objClassDefenseType = new ClassDefenseType();

            objClassDefenseType.GetClassDefenseType(ClassID, DefenseTypeID);

            Assert.IsTrue(objClassDefenseType.ModifierID == 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetClassDefenseTypes by strWhere, strOrderBy method.
        ///</summary>
        #region GetClassDefenseTypes(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassDefenseTypes(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetClassDefenseTypes_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "DefenseTypeID";

            ClassDefenseType objClassDefenseType = new ClassDefenseType();
            List<ClassDefenseType> lstClassDefenseTypes = new List<ClassDefenseType>();

            lstClassDefenseTypes = objClassDefenseType.GetClassDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstClassDefenseTypes.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassDefenseTypes(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetClassDefenseTypes_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "";

            ClassDefenseType objClassDefenseType = new ClassDefenseType();
            List<ClassDefenseType> lstClassDefenseTypes = new List<ClassDefenseType>();

            lstClassDefenseTypes = objClassDefenseType.GetClassDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstClassDefenseTypes.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassDefenseTypes(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetClassDefenseTypes_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=0";
            string strOrderBy = "DefenseTypeID";

            ClassDefenseType objClassDefenseType = new ClassDefenseType();
            List<ClassDefenseType> lstClassDefenseTypes = new List<ClassDefenseType>();

            lstClassDefenseTypes = objClassDefenseType.GetClassDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstClassDefenseTypes.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetClassDefenseTypes(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetClassDefenseTypes_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=0";
            string strOrderBy = "";

            ClassDefenseType objClassDefenseType = new ClassDefenseType();
            List<ClassDefenseType> lstClassDefenseTypes = new List<ClassDefenseType>();

            lstClassDefenseTypes = objClassDefenseType.GetClassDefenseTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstClassDefenseTypes.Count == 0);
        }

        #endregion

        #region SaveAndDeleteClassDefenseType()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveClassDefenseType and DeleteClassDefenseType Methods)")]
        public void Test_SaveAndDeleteClassDefenseType()
        {
            bool returnVal;

            objNewClassDefenseType.SaveClassDefenseType();

            ClassDefenseType objTestCDT = new ClassDefenseType();
            objTestCDT.GetClassDefenseType(objNewClassDefenseType.ClassID, objNewClassDefenseType.DefenseTypeID);

            Assert.IsTrue(objTestCDT.ModifierID == objNewClassDefenseType.ModifierID);

            returnVal = objNewClassDefenseType.DeleteClassDefenseType();

            Assert.IsTrue(returnVal && objNewClassDefenseType.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewClassDefenseType.Validate();
            Assert.IsTrue(objNewClassDefenseType.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewClassDefenseType.ModifierID = 0;
            objNewClassDefenseType.Validate();
            Assert.IsTrue(!objNewClassDefenseType.Validated && (objNewClassDefenseType.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
