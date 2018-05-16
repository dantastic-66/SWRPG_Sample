using System;
using StarWarsClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// Armor test object, used to test all the methods of the Armor object.
    /// </summary>
    [TestClass]
    public class ArmorTest
    {
        Armor objNewArmor = new Armor();
        public ArmorTest()
        {
            ItemAvailabilityType IAT1 = new ItemAvailabilityType(1);
            ItemAvailabilityType IAT2= new ItemAvailabilityType(2);
            Feat objFeat = new Feat(10);
            ArmorType objArmorType = new ArmorType(1);
            Book objBook = new Book(1);

            objNewArmor.ArmorID = 0;
            objNewArmor.ArmorName = "Test Armor";
            objNewArmor.ArmorDescription = "New Test Armor Description";
            objNewArmor.ReflexAdjustment = 1;
            objNewArmor.FortitudeAdjustment = 1;
            objNewArmor.ArmorTypeID =1;
            objNewArmor.ArmorProficiencyFeatID = 10;
            objNewArmor.BookID = 1;
            objNewArmor.Cost = 10000;
            objNewArmor.EmplacementPoints = 3;
            objNewArmor.lstArmorAvailability.Add(IAT1);
            objNewArmor.lstArmorAvailability.Add(IAT2);
            objNewArmor.MaxDefBonus = 1;
            objNewArmor.Weight = 15;

            objNewArmor.objArmorProfFeat = objFeat;
            objNewArmor.objArmorType = objArmorType;
            objNewArmor.objBook = objBook;
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
        /// Tests the GetArmor(int intArmorID) method, Good Result
        /// </summary>
        #region GetArmor(int intArmorID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmor(int ArmorID) Method, Good Outcome")]
        public void Test_GetArmor_ByID_GoodResult()
        {
            int intArmorID = 1; 
            Armor objArmor = new Armor();

            objArmor.GetArmor(intArmorID);

            Assert.AreEqual(intArmorID, objArmor.ArmorID);
        }

        /// <summary>
        /// Tests the GetArmor(int intArmorID) method, Good Result
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmor(int ArmorID) Method, Bad Outcome")]
        public void Test_GetArmor_ByID_BadResult()
        {
            int intArmorID = 0;
            Armor objArmor = new Armor();

            objArmor.GetArmor(intArmorID);

            Assert.IsNull(objArmor.ArmorName);
        }
        #endregion

        /// <summary>
        /// Tests the GetArmor(string strArmorName) method, Good Result
        ///</summary>
        #region GetArmor(string strArmorName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmor(string ArmorName) Method, Good Outcome")]
        public void Test_GetArmor_ByName_GoodResult()
        {
            string strArmorName = "Orbalisk Armor";
            Armor objArmor = new Armor();

            objArmor.GetArmor(strArmorName);

            Assert.AreEqual(strArmorName, objArmor.ArmorName);
        }

        /// <summary>
        /// Tests the GetArmor(string strArmorName) method, Bad Result
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmor(string ArmorName) Method, Bad Outcome")]
        public void Test_GetArmor_ByName_BadResult()
        {
            string strArmorName = "blah blah";
            Armor objArmor = new Armor();

            objArmor.GetArmor(strArmorName);

            Assert.IsNull(objArmor.ArmorName);
        }
        #endregion

        /// <summary>
        /// Tests the GetArmors(string strWhere, strOrderBy) method, Good Result
        ///</summary>
        #region GetArmors(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmors(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetArmors_WithOrderBy_GoodResult()
        {
            string strWhere = "ArmorName Like '%Flight%'";
            string strOrderBy = "";

            Armor objArmor = new Armor();
            List<Armor> lstArmors = new List<Armor>();

            lstArmors = objArmor.GetArmors(strWhere, strOrderBy);

            Assert.IsTrue(lstArmors.Count > 0);
        }

        /// <summary>
        /// Tests the GetArmors(string strWhere, strOrderBy) method, Good Result, With OrderBy
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmors(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetArmors_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ArmorName Like '%Flight%'";
            string strOrderBy = "ArmorName";

            Armor objArmor = new Armor();
            List<Armor> lstArmors = new List<Armor>();

            lstArmors = objArmor.GetArmors(strWhere, strOrderBy);

            Assert.IsTrue(lstArmors.Count > 0);
        }

        /// <summary>
        /// Tests the GetArmors(string strWhere, strOrderBy) method, Bad Result, With OrderBy
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmors(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetArmors_WithOrderBy_NoResult()
        {
            string strWhere = "ArmorName Like '%Toad%'";
            string strOrderBy = "";

            Armor objArmor = new Armor();
            List<Armor> lstArmors = new List<Armor>();

            lstArmors = objArmor.GetArmors(strWhere, strOrderBy);

            Assert.IsTrue(lstArmors.Count == 0);
        }

        /// <summary>
        /// Tests the GetArmors(string strWhere, strOrderBy) method, Bad Result, Without OrderBy
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetArmors(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetArmors_WithOutOrderBy_NoResult()
        {
            string strWhere = "ArmorName Like '%Toad%'";
            string strOrderBy = "ArmorName";

            Armor objArmor = new Armor();
            List<Armor> lstArmors = new List<Armor>();

            lstArmors = objArmor.GetArmors(strWhere, strOrderBy);

            Assert.IsTrue(lstArmors.Count == 0);
        }
        #endregion

        /// <summary>
        /// Tests the GetCharacterProficientArmors(int intCharacterID) method, Not Outcome
        ///</summary>
        #region GetCharacterProficientArmors(int intCharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterProficientArmors(int intCharacterID) Method, No Outcome")]
        public void Test_GetCharacterProficientArmors_NoResult()
        {
            Armor objArmor = new Armor();
            List<Armor> lstArmors = new List<Armor>();

            lstArmors = objArmor.GetCharacterProficientArmors(2);

            Assert.IsTrue(lstArmors.Count == 0);
        }

        /// <summary>
        /// Tests the GetCharacterProficientArmors(int intCharacterID) method, Expected Outcome
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterProficientArmors(int intCharacterID) Method, Expected Outcome")]
        public void Test_GetCharacterProficientArmors_ExpectedResult()
        {
            Armor objArmor = new Armor();
            List<Armor> lstArmors = new List<Armor>();

            lstArmors = objArmor.GetCharacterProficientArmors(1);

            Assert.IsTrue(lstArmors.Count > 1);
        }
        #endregion

        /// <summary>
        /// Tests the SaveAndDeleteArmor() methods
        ///</summary>
        #region SaveAndDeleteArmor()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveArmor and DeleteArmor Methods)")]
        public void Test_SaveAndDeleteArmor()
        {
            bool returnVal;

            objNewArmor.SaveArmor();

            Assert.IsTrue(objNewArmor.ArmorID != 0);

            returnVal = objNewArmor.DeleteArmor();

            Assert.IsTrue(returnVal && objNewArmor.DeleteOK );
        }
        #endregion

        /// <summary>
        /// Tests the Validate() method, True Outcome
        ///</summary>
        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            Armor objArmor = new Armor();
            objArmor.ArmorName = "New Test Armor";
            objArmor.Validate();
            Assert.IsTrue(objArmor.Validated);
        }

        /// <summary>
        /// Tests the Validate() method, False Outcome
        ///</summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            Armor objArmor = new Armor();
            objArmor.ArmorName = "";
            objArmor.Validate();
            Assert.IsTrue(!objArmor.Validated && (objArmor.ValidationMessage.Length > 0));
        }
        #endregion

        /// <summary>
        /// Tests the  Clone(Armor objArmor) method
        ///</summary>
        #region Clone(Armor objArmor) returns Abililty
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Clone(Armor objArmor) Method, Good Outcome")]
        public void CloneObject_GoodResult()
        {
            Armor objAbil = new Armor(3);  
            Armor objClone = new Armor();

            objClone = Armor.Clone(objAbil);
            Assert.IsTrue((objAbil != objClone) && (objClone.ArmorID == objAbil.ArmorID));
        }
        #endregion

        /// <summary>
        /// Tests the  Clone(List [Armor] lstArmor) method
        ///</summary>
        #region Clone(List<Armor> lstArmor) returns List<Armor>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Clone(List<Armor> lstArmor) Method, Good Outcome")]
        public void CloneList_GoodResult()
        {
            Armor objAbil = new Armor(3);  
            Armor objAbil2 = new Armor(1);  
            List<Armor> lstArmor = new List<Armor>();
            lstArmor.Add(objAbil);
            lstArmor.Add(objAbil2);
            List<Armor> lstClone = new List<Armor>();

            lstClone = Armor.Clone(lstArmor);
            Assert.IsTrue(lstClone.Count == 2);
        }
        #endregion
    }
}
