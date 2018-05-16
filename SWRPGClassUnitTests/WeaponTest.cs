using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Weapon Class
    /// </summary>
    [TestClass]
    public class WeaponTest
    {
        Weapon objNewWeapon = new Weapon();
        public WeaponTest()
        {
            objNewWeapon.WeaponID = 0;
            objNewWeapon.WeaponName = "Test Weapon 2";
            objNewWeapon.WeaponTypeID = 1;
            objNewWeapon.DamageDieNumber = 3;
            objNewWeapon.DamageDieType  = 8;

            objNewWeapon.Stun = true;
            objNewWeapon.StunDieNumber  = 2;
            objNewWeapon.StunDieType = 8;
            objNewWeapon.WeaponDescription = "Test Weapon 2 Notes";
            objNewWeapon.Weight = 1.4M;
            objNewWeapon.BookID = 1;
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
        /// Tests the GetWeapon by WeaponID method.
        ///</summary>
        #region GetWeapon(int WeaponID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapon(int WeaponID) Method, Good Outcome")]
        public void Test_GetWeapon_ByID_GoodResult()
        {
            int intWeaponID = 1;
            Weapon objWeapon = new Weapon();

            objWeapon.GetWeapon(intWeaponID);

            Assert.AreEqual(intWeaponID, objWeapon.WeaponID);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapon(int WeaponID) Method, Bad Outcome")]
        public void Test_GetWeapon_ByID_BadResult()
        {
            int intWeaponID = 0;
            Weapon objWeapon = new Weapon();

            objWeapon.GetWeapon(intWeaponID);

            Assert.IsNull(objWeapon.WeaponName);
        }
        #endregion

        /// <summary>
        /// Tests the GetWeapon by WeaponName method.
        ///</summary>
        #region GetWeapon(string strWeaponName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapon(string WeaponName) Method, Good Outcome")]
        public void Test_GetWeapon_ByName_GoodResult()
        {
            string strWeaponName = "Knife";
            Weapon objWeapon = new Weapon();

            objWeapon.GetWeapon(strWeaponName);

            Assert.AreEqual(strWeaponName, objWeapon.WeaponName);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapon(string WeaponName) Method, Bad Outcome")]
        public void Test_GetWeapon_ByName_BadResult()
        {
            string strWeaponName = "blah blah";
            Weapon objWeapon = new Weapon();

            objWeapon.GetWeapon(strWeaponName);

            Assert.IsNull(objWeapon.WeaponName);
        }
        #endregion

        /// <summary>
        /// Tests the GetWeapons by strWhere, strOrderBy method.
        ///</summary>
        #region GetWeapons(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapons(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetWeapons_WithOrderBy_GoodResult()
        {
            string strWhere = "WeaponName Like '%Test%'";
            string strOrderBy = "WeaponName";

            Weapon objWeapon = new Weapon();
            List<Weapon> lstWeapons = new List<Weapon>();

            lstWeapons = objWeapon.GetWeapons(strWhere, strOrderBy);

            Assert.IsTrue(lstWeapons.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapons(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetWeapons_WithOutOrderBy_GoodResult()
        {
            string strWhere = "WeaponName Like '%Test%'";
            string strOrderBy = "";

            Weapon objWeapon = new Weapon();
            List<Weapon> lstWeapons = new List<Weapon>();

            lstWeapons = objWeapon.GetWeapons(strWhere, strOrderBy);

            Assert.IsTrue(lstWeapons.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapons(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetWeapons_WithOrderBy_NoResult()
        {
            string strWhere = "WeaponName Like '%Toad%'";
            string strOrderBy = "WeaponName";

            Weapon objWeapon = new Weapon();
            List<Weapon> lstWeapons = new List<Weapon>();

            lstWeapons = objWeapon.GetWeapons(strWhere, strOrderBy);

            Assert.IsTrue(lstWeapons.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetWeapons(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetWeapons_WithOutOrderBy_NoResult()
        {
            string strWhere = "WeaponName Like '%Toad%'";
            string strOrderBy = "";

            Weapon objWeapon = new Weapon();
            List<Weapon> lstWeapons = new List<Weapon>();

            lstWeapons = objWeapon.GetWeapons(strWhere, strOrderBy);

            Assert.IsTrue(lstWeapons.Count == 0);
        }

        #endregion

        #region SaveAndDeleteWeapon()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveWeapon and DeleteWeapon Methods)")]
        public void Test_SaveAndDeleteWeapon()
        {
            bool returnVal;

            objNewWeapon.SaveWeapon();

            Assert.IsTrue(objNewWeapon.WeaponID != 0);

            returnVal = objNewWeapon.DeleteWeapon();

            Assert.IsTrue(returnVal && objNewWeapon.DeleteOK);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            objNewWeapon.Validate();
            Assert.IsTrue(objNewWeapon.Validated);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewWeapon.WeaponName = "";
            objNewWeapon.Validate();
            Assert.IsTrue(!objNewWeapon.Validated && (objNewWeapon.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
