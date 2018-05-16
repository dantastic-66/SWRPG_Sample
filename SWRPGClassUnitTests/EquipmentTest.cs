using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Equipment Class
    /// </summary>
    [TestClass]
    public class EquipmentTest
    {
        Equipment objNewEquipment = new Equipment();
        public EquipmentTest()
        {
            objNewEquipment.EquipmentID = 0;
            objNewEquipment.EquipmentName = "Test Equipment";
            objNewEquipment.EquipmentDescription  = "Test Description";
            objNewEquipment.EquipmentWeight = 10.2M;
        }

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
        /// Tests the GetEquipment by EquipmentID method.
        /// </summary>
        #region GetEquipment(int EquipmentID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipment(int EquipmentID) Method, Good Outcome")]
        public void Test_GetEquipment_ByID_GoodResult()
        {
            int intEquipmentID = 1;
            Equipment objEquipment = new Equipment();

            objEquipment.GetEquipment(intEquipmentID);

            Assert.AreEqual(intEquipmentID, objEquipment.EquipmentID);
        }

        /// <summary>
        /// Test_s the get equipment_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipment(int EquipmentID) Method, Bad Outcome")]
        public void Test_GetEquipment_ByID_BadResult()
        {
            int intEquipmentID = 0;
            Equipment objEquipment = new Equipment();

            objEquipment.GetEquipment(intEquipmentID);

            Assert.IsNull(objEquipment.EquipmentName);
        }
        #endregion

        /// <summary>
        /// Tests the GetCharacterEquipment by CharacterID method.
        /// </summary>
        #region GetCharacterEquipment(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterEquipment(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterEquipment_ByICharacterD_GoodResult()
        {
            int intCharacterID = 1;
            Equipment objEquip = new Equipment();
            //objEquip = objNewEquipment;

            objNewEquipment.SaveEquipment();
            objEquip.SaveCharacterEquipment(intCharacterID, objNewEquipment.EquipmentID);
            
            Equipment objEquipment = new Equipment();
            List<Equipment> lstCharEquipment = new List<Equipment>();

            lstCharEquipment = objEquipment.GetCharacterEquipment(intCharacterID);

            Assert.IsTrue (lstCharEquipment.Count > 0);

            objEquip.DeleteCharacterEquipment(intCharacterID, objEquip.EquipmentID);
            objEquip.DeleteEquipment();
        }

        /// <summary>
        /// Test_s the get character equipment_ by character i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterEquipment(int CharacterID) Method, Bad Outcome")]
        public void Test_GetCharacterEquipment_ByCharacterID_BadResult()
        {
            int intCharacterID = 0;
            Equipment objEquipment = new Equipment();
            List<Equipment> lstCharEquipment = new List<Equipment>();

            lstCharEquipment = objEquipment.GetCharacterEquipment(intCharacterID);

            Assert.IsTrue(lstCharEquipment.Count == 0);
        }
        #endregion


        /// <summary>
        /// Tests the GetEquipment by EquipmentName method.
        /// </summary>
        #region GetEquipment(string strEquipmentName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipment(string EquipmentName) Method, Good Outcome")]
        public void Test_GetEquipment_ByName_GoodResult()
        {
            string strEquipmentName = "Test 1";
            Equipment objEquipment = new Equipment();

            objEquipment.GetEquipment(strEquipmentName);

            Assert.AreEqual(strEquipmentName, objEquipment.EquipmentName);
        }

        /// <summary>
        /// Test_s the get equipment_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipment(string EquipmentName) Method, Bad Outcome")]
        public void Test_GetEquipment_ByName_BadResult()
        {
            string strEquipmentName = "blah blah";
            Equipment objEquipment = new Equipment();

            objEquipment.GetEquipment(strEquipmentName);

            Assert.IsNull(objEquipment.EquipmentName);
        }
        #endregion

        /// <summary>
        /// Tests the GetEquipments by strWhere, strOrderBy method.
        /// </summary>
        #region GetEquipment(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipments(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetEquipment_WithOrderBy_GoodResult()
        {
            string strWhere = "EquipmentName Like '%Test%'";
            string strOrderBy = "EquipmentName";

            Equipment objEquipment = new Equipment();
            List<Equipment> lstEquipments = new List<Equipment>();

            lstEquipments = objEquipment.GetEquipment(strWhere, strOrderBy);

            Assert.IsTrue(lstEquipments.Count > 0);
        }

        /// <summary>
        /// Test_s the get equipment_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipments(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetEquipment_WithOutOrderBy_GoodResult()
        {
            string strWhere = "EquipmentName Like '%Test%'";
            string strOrderBy = "";

            Equipment objEquipment = new Equipment();
            List<Equipment> lstEquipments = new List<Equipment>();

            lstEquipments = objEquipment.GetEquipment(strWhere, strOrderBy);

            Assert.IsTrue(lstEquipments.Count > 0);
        }

        /// <summary>
        /// Test_s the get equipment_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipments(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetEquipment_WithOrderBy_NoResult()
        {
            string strWhere = "EquipmentName Like '%Toad%'";
            string strOrderBy = "EquipmentName";

            Equipment objEquipment = new Equipment();
            List<Equipment> lstEquipments = new List<Equipment>();

            lstEquipments = objEquipment.GetEquipment(strWhere, strOrderBy);

            Assert.IsTrue(lstEquipments.Count == 0);
        }

        /// <summary>
        /// Test_s the get equipment_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetEquipments(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetEquipment_WithOutOrderBy_NoResult()
        {
            string strWhere = "EquipmentName Like '%Toad%'";
            string strOrderBy = "";

            Equipment objEquipment = new Equipment();
            List<Equipment> lstEquipments = new List<Equipment>();

            lstEquipments = objEquipment.GetEquipment(strWhere, strOrderBy);

            Assert.IsTrue(lstEquipments.Count == 0);
        }

        #endregion

        #region SaveAndDeleteEquipment()
        /// <summary>
        /// Test_s the save and delete equipment.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveEquipment and DeleteEquipment Methods)")]
        public void Test_SaveAndDeleteEquipment()
        {
            bool returnVal;

            objNewEquipment.SaveEquipment();

            Assert.IsTrue(objNewEquipment.EquipmentID != 0);

            returnVal = objNewEquipment.DeleteEquipment();

            Assert.IsTrue(returnVal && objNewEquipment.DeleteOK);
        }
        #endregion

        #region SaveAndDeleteCharacterEquipment()
        /// <summary>
        /// Test_s the save and delete character equipment.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveCharacterEquipment and DeleteCharacterEquipment Methods)")]
        public void Test_SaveAndDeleteCharacterEquipment()
        {
            bool returnVal;

            int characterID = 1;
            int equipmentID = 1;

            objNewEquipment.SaveCharacterEquipment(characterID, equipmentID);

            Assert.IsTrue(objNewEquipment.EquipmentID != 0);

            returnVal = objNewEquipment.DeleteCharacterEquipment(characterID, equipmentID );

            Assert.IsTrue(returnVal && objNewEquipment.DeleteOK);

            Equipment objEquip = new Equipment();

            objEquip.SaveCharacterEquipment(characterID, equipmentID);

            returnVal = objEquip.DeleteCharacterEquipment(characterID,equipmentID );

            Assert.IsTrue(returnVal && objEquip.DeleteOK);
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
            objNewEquipment.Validate();
            Assert.IsTrue(objNewEquipment.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewEquipment.EquipmentName = "";
            objNewEquipment.Validate();
            Assert.IsTrue(!objNewEquipment.Validated && (objNewEquipment.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
