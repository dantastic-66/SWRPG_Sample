using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the ForcePower Class
    /// </summary>
    [TestClass]
    public class ForcePowerTest
    {
        /// <summary>
        /// The object new force power
        /// </summary>
        ForcePower objNewForcePower = new ForcePower();
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePowerTest" /> class.
        /// </summary>
        public ForcePowerTest()
        {
            objNewForcePower.ForcePowerID = 0;
            objNewForcePower.ForcePowerName = "Test Force Power";
            objNewForcePower.ForcePowerDescription = "";
            objNewForcePower.TurnSegmentID = 0;
            objNewForcePower.ForcePowerTarget = "";
            objNewForcePower.ForcePowerSpecial = "";
        }

        /// <summary>
        /// The test context instance
        /// </summary>
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
        /// Tests the GetForcePower by ForcePowerID method.
        /// </summary>
        #region GetForcePower(int ForcePowerID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePower(int ForcePowerID) Method, Good Outcome")]
        public void Test_GetForcePower_ByID_GoodResult()
        {
            int intForcePowerID = 1;
            ForcePower objForcePower = new ForcePower();

            objForcePower.GetForcePower(intForcePowerID);

            Assert.AreEqual(intForcePowerID, objForcePower.ForcePowerID);
        }

        /// <summary>
        /// Test_s the get force power_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePower(int ForcePowerID) Method, Bad Outcome")]
        public void Test_GetForcePower_ByID_BadResult()
        {
            int intForcePowerID = 0;
            ForcePower objForcePower = new ForcePower();

            objForcePower.GetForcePower(intForcePowerID);

            Assert.IsNull(objForcePower.ForcePowerName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForcePower by ForcePowerName method.
        /// </summary>
        #region GetForcePower(string strForcePowerName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePower(string ForcePowerName) Method, Good Outcome")]
        public void Test_GetForcePower_ByName_GoodResult()
        {
            string strForcePowerName = "Force Grip";
            ForcePower objForcePower = new ForcePower();

            objForcePower.GetForcePower(strForcePowerName);

            Assert.AreEqual(strForcePowerName, objForcePower.ForcePowerName);
        }

        /// <summary>
        /// Test_s the get force power_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePower(string ForcePowerName) Method, Bad Outcome")]
        public void Test_GetForcePower_ByName_BadResult()
        {
            string strForcePowerName = "blah blah";
            ForcePower objForcePower = new ForcePower();

            objForcePower.GetForcePower(strForcePowerName);

            Assert.IsNull(objForcePower.ForcePowerName);
        }
        #endregion

        /// <summary>
        /// Tests the GetForcePowers by strWhere, strOrderBy method.
        /// </summary>
        #region GetForcePowers(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowers(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetForcePowers_WithOrderBy_GoodResult()
        {
            string strWhere = "ForcePowerName Like '%Force%'";
            string strOrderBy = "ForcePowerName";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count > 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowers(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetForcePowers_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ForcePowerName Like '%Force%'";
            string strOrderBy = "";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count > 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowers(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetForcePowers_WithOrderBy_NoResult()
        {
            string strWhere = "ForcePowerName Like '%Toad%'";
            string strOrderBy = "ForcePowerName";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count == 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePowers(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetForcePowers_WithOutOrderBy_NoResult()
        {
            string strWhere = "ForcePowerName Like '%Toad%'";
            string strOrderBy = "";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetPrestigeRequiredForcePowers by strWhere, strOrderBy method.
        /// </summary>
        #region GetPrestigeRequiredForcePowers(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredForcePowers(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredForcePowers_WithOrderBy_GoodResult()
        {
            string strWhere = " ClassID=23";
            string strOrderBy = "ForcePowerName";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetPrestigeRequiredForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count > 0);
        }

        /// <summary>
        /// Tests the GetPrestigeRequiredForcePowers with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredForcePowers(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredForcePowers_WithOutOrderBy_GoodResult()
        {
            string strWhere = " ClassID=23";
            string strOrderBy = "";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetPrestigeRequiredForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count > 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredForcePowers(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredForcePowers_WithOrderBy_NoResult()
        {
            string strWhere = " ClassID=24";
            string strOrderBy = "ForcePowerName";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetPrestigeRequiredForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count == 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredForcePowers(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredForcePowers_WithOutOrderBy_NoResult()
        {
            string strWhere = " ClassID=24";
            string strOrderBy = "";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetPrestigeRequiredForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetTalentPrequisteForcePowers by strWhere, strOrderBy method.
        /// </summary>
        #region GetTalentPrequisteForcePowers(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrequisteForcePowers(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalentPrequisteForcePowers_WithOrderBy_GoodResult()
        {
            string strWhere = " TalentID=13";
            string strOrderBy = "ForcePowerName";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetTalentPrequisteForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count > 0);
        }

        /// <summary>
        /// Tests the GetTalentPrequisteForcePowers with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrequisteForcePowers(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalentPrequisteForcePowers_WithOutOrderBy_GoodResult()
        {
            string strWhere = " TalentID=13";
            string strOrderBy = "";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetTalentPrequisteForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count > 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrequisteForcePowers(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalentPrequisteForcePowers_WithOrderBy_NoResult()
        {
            string strWhere = " TalentID=14";
            string strOrderBy = "ForcePowerName";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetTalentPrequisteForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count == 0);
        }

        /// <summary>
        /// Test_s the get force powers_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrequisteForcePowers(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalentPrequisteForcePowers_WithOutOrderBy_NoResult()
        {
            string strWhere = " TalentID=14";
            string strOrderBy = "";

            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePowers = new List<ForcePower>();

            lstForcePowers = objForcePower.GetTalentPrequisteForcePowers(strWhere, strOrderBy);

            Assert.IsTrue(lstForcePowers.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetCharacterForcePowers by CharacterID method.
        /// </summary>
        #region GetCharacterForcePowers(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetForcePower(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterForcePowers_ByCharacterID_GoodResult()
        {
            int CharacterID = 1;
            ForcePower objForcePower = new ForcePower();
            List<ForcePower> lstForcePwrs = new List<ForcePower>();

            lstForcePwrs = objForcePower.GetCharacterForcePowers(CharacterID);

            Assert.IsTrue(lstForcePwrs.Count > 0);
        }

        /// <summary>
        /// Test_s the GetCharacterForcePowers by CharacterID  bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterForcePowers(int CharacterID) Method, Bad Outcome")]
        public void Test_GetCharacterForcePowers_ByID_BadResult()
        {
            int CharacterID = 0;
            ForcePower objForcePower = new ForcePower();

            List<ForcePower> lstForcePwrs = new List<ForcePower>();

            lstForcePwrs = objForcePower.GetCharacterForcePowers(CharacterID);

            Assert.IsTrue(lstForcePwrs.Count == 0);
        }
        #endregion

        /// <summary>
        /// Test_s the is force power in list_ single class param_ good result.
        /// </summary>
        #region IsForcePowerInList(ForcePower objForcePower, List<ForcePower> lstForcePowers)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsForcePowerInList(ForcePower objForcePower, List<ForcePower>) Method, Good Outcome")]
        public void Test_IsForcePowerInList_SingleClassParam_GoodResult()
        {
            bool blnIsInList = false;
            ForcePower objForcePower = new ForcePower();
            ForcePower objForcePower2 = new ForcePower();
            ForcePower objForcePower3 = new ForcePower();
            List<ForcePower> lstForcePower = new List<ForcePower>();

            objForcePower.GetForcePower(1);
            objForcePower2.GetForcePower(2);
            objForcePower3.GetForcePower(7);

            lstForcePower.Add(objForcePower);
            lstForcePower.Add(objForcePower2);
            lstForcePower.Add(objForcePower3);

            blnIsInList = ForcePower.IsForcePowerInList(objForcePower, lstForcePower);

            Assert.IsTrue(blnIsInList);
        }

        /// <summary>
        /// Test_s the is class in list_ single class param_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsClassInList(Class objClass, List<CharacterClassLevel>) Method, Bad Outcome")]
        public void Test_IsClassInList_SingleClassParam_BadResult()
        {
            bool blnIsInList = false;
            ForcePower objForcePower = new ForcePower();
            ForcePower objForcePower2 = new ForcePower();
            ForcePower objForcePower3 = new ForcePower();
            ForcePower objForcePower4 = new ForcePower();
            List<ForcePower> lstForcePower = new List<ForcePower>();

            objForcePower.GetForcePower(1);
            objForcePower2.GetForcePower(2);
            objForcePower3.GetForcePower(7);
            objForcePower4.GetForcePower(8);

            lstForcePower.Add(objForcePower);
            lstForcePower.Add(objForcePower2);
            lstForcePower.Add(objForcePower3);

            blnIsInList = ForcePower.IsForcePowerInList(objForcePower4, lstForcePower);

            Assert.IsFalse (blnIsInList);
        }

        /// <summary>
        /// Test_s the is force power in list_ list force power param_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsForcePowerInList(List<CharacterForcePowerLevel> objForcePower, List<CharacterForcePowerLevel>) Method, Good Outcome")]
        public void Test_IsForcePowerInList_ListForcePowerParam_GoodResult()
        {
            bool blnIsInList = false;
            ForcePower objForcePower = new ForcePower();
            ForcePower objForcePower2 = new ForcePower();
            ForcePower objForcePower3 = new ForcePower();
            List<ForcePower> lstForcePower = new List<ForcePower>();
            List<ForcePower> lstForcePower2 = new List<ForcePower>();

            objForcePower.GetForcePower(1);
            objForcePower2.GetForcePower(2);
            objForcePower3.GetForcePower(7);

            lstForcePower.Add(objForcePower);
            lstForcePower.Add(objForcePower2);
            lstForcePower.Add(objForcePower3);

            lstForcePower2.Add(objForcePower3);
            lstForcePower2.Add(objForcePower2);


            blnIsInList = ForcePower.IsForcePowerInList(lstForcePower2, lstForcePower);


            Assert.IsTrue(blnIsInList);
        }

        /// <summary>
        /// Test_s the is force power in list_ list force power param_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsForcePowerInList(List<CharacterForcePowerLevel> objForcePower, List<CharacterForcePowerLevel>) Method, Bad Outcome")]
        public void Test_IsForcePowerInList_ListForcePowerParam_BadResult()
        {
            bool blnIsInList = false;
            ForcePower objForcePower = new ForcePower();
            ForcePower objForcePower2 = new ForcePower();
            ForcePower objForcePower3 = new ForcePower();

            ForcePower objForcePower4 = new ForcePower();
            ForcePower objForcePower5 = new ForcePower();

            List<ForcePower> lstForcePower = new List<ForcePower>();
            List<ForcePower> lstForcePower2 = new List<ForcePower>();
            objForcePower.GetForcePower(1);
            objForcePower2.GetForcePower(2);
            objForcePower3.GetForcePower(7);

            objForcePower4.GetForcePower(8);
            objForcePower5.GetForcePower(9);

            lstForcePower.Add(objForcePower);
            lstForcePower.Add(objForcePower2);
            lstForcePower.Add(objForcePower3);

            lstForcePower2.Add(objForcePower4);
            lstForcePower2.Add(objForcePower5);


            blnIsInList = ForcePower.IsForcePowerInList(lstForcePower2, lstForcePower);
            Assert.IsFalse(blnIsInList);
        }
        #endregion

        #region SaveAndDeleteCharacterForcePowers()
        /// <summary>
        /// Test_s the save and delete Character force power.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveCharacterForcePower and DeleteCharacterForcePower Methods)")]
        public void Test_SaveAndDeleteCharacterForcePower()
        {
            bool returnVal;
            int CharacterID = 1;
            int ForcePowerID = 55;
            ForcePower objFP = new ForcePower();
            objFP.GetForcePower(ForcePowerID);

            List<ForcePower> lstCharFP = new List<ForcePower>();

            ForcePower objFP2 = new ForcePower();
            objFP2.SaveCharacterForcePower(CharacterID, ForcePowerID);
            lstCharFP = objFP2.GetCharacterForcePowers(CharacterID);

            Assert.IsTrue(ForcePower.IsForcePowerInList(objFP, lstCharFP));

            returnVal = objNewForcePower.DeleteCharacterForcePower(CharacterID, ForcePowerID);

            Assert.IsTrue(returnVal && objNewForcePower.DeleteOK);
        }
        #endregion
        
        #region SaveAndDeleteForcePower()
        /// <summary>
        /// Test_s the save and delete force power.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveForcePower and DeleteForcePower Methods)")]
        public void Test_SaveAndDeleteForcePower()
        {
            bool returnVal;

            objNewForcePower.SaveForcePower();

            Assert.IsTrue(objNewForcePower.ForcePowerID != 0);

            returnVal = objNewForcePower.DeleteForcePower();

            Assert.IsTrue(returnVal && objNewForcePower.DeleteOK);
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
            objNewForcePower.Validate();
            Assert.IsTrue(objNewForcePower.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewForcePower.ForcePowerName = "";
            objNewForcePower.Validate();
            Assert.IsTrue(!objNewForcePower.Validated && (objNewForcePower.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
