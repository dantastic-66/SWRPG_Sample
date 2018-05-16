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
    public class ArmorTypeTest
    {
        ArmorType objNewArmorType = new ArmorType();
        public ArmorTypeTest()
        {
            objNewArmorType.ArmorTypeID  = 0;
            objNewArmorType.ArmorTypeName = "Test Armor";
            
            objNewArmorType.Speed_4 = 4;
            objNewArmorType.Speed_6 = 6;
            objNewArmorType.Speed_8 = 8;
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
        /// Tests the GetArmorType method by ArmorTypeID parameter, good result.
        ///</summary>
        #region GetArmorType(int ArmorTypeID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorType(int ArmorTypeID) Method, Good Outcome")]
        public void Test_GetArmorType_ByID_GoodResult()
        {
            int intArmorTypeID = 1;
            ArmorType objArmorType = new ArmorType();

            objArmorType.GetArmorType(intArmorTypeID);

            Assert.AreEqual(intArmorTypeID, objArmorType.ArmorTypeID);
        }

        /// <summary>
        /// Tests the GetArmorType method by ArmorTypeID parameter, Bad result.
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorType(int ArmorTypeID) Method, Bad Outcome")]
        public void Test_GetArmorType_ByID_BadResult()
        {
            int intArmorTypeID = 0;
            ArmorType objArmorType = new ArmorType();

            objArmorType.GetArmorType(intArmorTypeID);

            Assert.IsNull(objArmorType.ArmorTypeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetArmorType method by strArmorTypeName parameter, Good outcome.
        ///</summary>
        #region GetArmorType(string strArmorTypeName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorType(string ArmorTypeName) Method, Good Outcome")]
        public void Test_GetArmorType_ByName_GoodResult()
        {
            string strArmorTypeName = "Light";
            ArmorType objArmorType = new ArmorType();

            objArmorType.GetArmorType(strArmorTypeName);

            Assert.AreEqual(strArmorTypeName, objArmorType.ArmorTypeName);
        }

        /// <summary>
        /// Tests the GetArmorType method by strArmorTypeName parameter, bad outcome.
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorType(string ArmorTypeName) Method, Bad Outcome")]
        public void Test_GetArmorType_ByName_BadResult()
        {
            string strArmorTypeName = "blah blah";
            ArmorType objArmorType = new ArmorType();

            objArmorType.GetArmorType(strArmorTypeName);

            Assert.IsNull(objArmorType.ArmorTypeName);
        }
        #endregion

        /// <summary>
        /// Tests the GetArmorTypes by strWhere, strOrderBy method, good outcome with Orderby Clause
        ///</summary>
        #region GetArmors(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorTypes(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetArmorTypes_WithOrderBy_GoodResult()
        {
            string strWhere = "ArmorTypeName Like '%e%'";
            string strOrderBy = "";

            ArmorType objArmorType = new ArmorType();
            List<ArmorType> lstArmorTypes = new List<ArmorType>();

            lstArmorTypes = objArmorType.GetArmorTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstArmorTypes.Count > 0);
        }

        /// <summary>
        /// Tests the GetArmorTypes by strWhere, strOrderBy method, good outcome without Orderby Clause
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorTypes(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetArmorTypes_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ArmorTypeName Like '%e%'";
            string strOrderBy = "ArmorTypeName";

            ArmorType objArmorType = new ArmorType();
            List<ArmorType> lstArmorTypes = new List<ArmorType>();

            lstArmorTypes = objArmorType.GetArmorTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstArmorTypes.Count > 0);
        }

        /// <summary>
        /// Tests the GetArmorTypes by strWhere, strOrderBy method, no outcome with Orderby Clause
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorTypes(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetArmorTypes_WithOrderBy_NoResult()
        {
            string strWhere = "ArmorTypeName Like '%Toad%'";
            string strOrderBy = "";

            ArmorType objArmorType = new ArmorType();
            List<ArmorType> lstArmorTypes = new List<ArmorType>();

            lstArmorTypes = objArmorType.GetArmorTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstArmorTypes.Count == 0);
        }

        /// <summary>
        /// Tests the GetArmorTypes by strWhere, strOrderBy method, no outcome without Orderby Clause
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmorTypes(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetArmorTypes_WithOutOrderBy_NoResult()
        {
            string strWhere = "ArmorTypeName Like '%Toad%'";
            string strOrderBy = "ArmorTypeName";

            ArmorType objArmorType = new ArmorType();
            List<ArmorType> lstArmorTypes = new List<ArmorType>();

            lstArmorTypes = objArmorType.GetArmorTypes(strWhere, strOrderBy);

            Assert.IsTrue(lstArmorTypes.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the Save and Delete ArmorType methods
        ///</summary>
        #region SaveAndDeleteArmorType()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveArmorType and DeleteArmorType Methods)")]
        public void Test_SaveAndDeleteArmorType()
        {
            bool returnVal;

            objNewArmorType.SaveArmorType();

            Assert.IsTrue(objNewArmorType.ArmorTypeID != 0);

            returnVal = objNewArmorType.DeleteArmorType();

            Assert.IsTrue(returnVal && objNewArmorType.DeleteOK);
        }
        #endregion

        /// <summary>
        /// Tests the Validate Ability methods, true outcome
        ///</summary>
        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            ArmorType objArmorType = new ArmorType();
            objArmorType.ArmorTypeName = "New Test Armor";
            objArmorType.Validate();
            Assert.IsTrue(objArmorType.Validated);
        }

        /// <summary>
        /// Tests the Validate Ability methods, False outcome
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            ArmorType objArmorType = new ArmorType();
            objArmorType.ArmorTypeName = "";
            objArmorType.Validate();
            Assert.IsTrue(!objArmorType.Validated && (objArmorType.ValidationMessage.Length > 0));
        }
        #endregion

        /// <summary>
        /// Tests the  Clone(ArmorType objArmorType) method, Good Result
        ///</summary>
        #region Clone(ArmorType objArmorType) returns Abililty
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Clone(ArmorType objArmorType) Method, Good Outcome")]
        public void CloneObject_GoodResult()
        {
            ArmorType objAbil = new ArmorType(1); 
            ArmorType objClone = new ArmorType();

            objClone = ArmorType.Clone(objAbil);
            Assert.IsTrue((objAbil != objClone) && (objClone.ArmorTypeID == objAbil.ArmorTypeID));
        }
        #endregion

        /// <summary>
        /// Tests the  Clone(List [ArmorType] lstArmorType) method, Good Result
        ///</summary>
        #region Clone(List<ArmorType> lstArmorType) returns List<ArmorType>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Clone(List<ArmorType> lstArmorType) Method, Good Outcome")]
        public void CloneList_GoodResult()
        {
            ArmorType objAbil = new ArmorType(2); 
            ArmorType objAbil2 = new ArmorType(1); 
            List<ArmorType> lstArmorType = new List<ArmorType>();
            lstArmorType.Add(objAbil);
            lstArmorType.Add(objAbil2);
            List<ArmorType> lstClone = new List<ArmorType>();

            lstClone = ArmorType.Clone(lstArmorType);
            Assert.IsTrue(lstClone.Count == 2);
        }
        #endregion
    }
}
