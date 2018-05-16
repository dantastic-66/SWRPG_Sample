using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsClasses;

namespace SWRPGClassUnitTests
{
    /// <summary>
    /// This test will verify all the methods within the Race Class
    /// </summary>
    [TestClass]
    public class RaceTest
    {
        /// <summary>
        /// The object new race
        /// </summary>
        Race objNewRace = new Race();
        /// <summary>
        /// Initializes a new instance of the <see cref="RaceTest"/> class.
        /// </summary>
        public RaceTest()
        {
            objNewRace.RaceID = 0;
            objNewRace.RaceName = "Blorker";
            objNewRace.RaceDescription = "Blah blah, with three feet and two toes (on one foot)";
            objNewRace.OtherDescription = "Other Description";
            objNewRace.Sex = "B";
            objNewRace.RageAbility = false;
            objNewRace.ShapeShiftAbility = true;
            objNewRace.Primitive = false;
            objNewRace.BonusFeat = false;
            objNewRace.BonusSkill = false;
            objNewRace.AverageHeight = 2.3m;
            objNewRace.AverageWeight = 122.4m;
            objNewRace.SizeID = 1;
            objNewRace.SpeedID = 1;
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


        #region GetRace(int RaceID)
        /// <summary>
        /// Tests the GetRace by RaceID method.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRace(int RaceID) Method, Good Outcome")]
        public void Test_GetRace_ByID_GoodResult()
        {
            int intRaceID = 1;
            Race objRace = new Race();

            objRace.GetRace(intRaceID);

            Assert.AreEqual(intRaceID, objRace.RaceID);
        }

        /// <summary>
        /// Test_s the get race_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRace(int RaceID) Method, Bad Outcome")]
        public void Test_GetRace_ByID_BadResult()
        {
            int intRaceID = 0;
            Race objRace = new Race();

            objRace.GetRace(intRaceID);

            Assert.IsNull(objRace.RaceName);
        }
        #endregion

        #region GetRace(string strRaceName)
        /// <summary>
        /// Tests the GetRace by RaceName method.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRace(string RaceName) Method, Good Outcome")]
        public void Test_GetRace_ByName_GoodResult()
        {
            string strRaceName = "Taung";
            Race objRace = new Race();

            objRace.GetRace(strRaceName);

            Assert.AreEqual(strRaceName, objRace.RaceName);
        }

        /// <summary>
        /// Test_s the get race_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRace(string RaceName) Method, Bad Outcome")]
        public void Test_GetRace_ByName_BadResult()
        {
            string strRaceName = "blah blah";
            Race objRace = new Race();

            objRace.GetRace(strRaceName);

            Assert.IsNull(objRace.RaceName);
        }
        #endregion

        #region GetRace(string RaceName, string RaceSex)
        /// <summary>
        /// Test_s the get race_ by name sex_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRace(string RaceName, string RaceSex) Method, Good Outcome")]
        public void Test_GetRace_ByNameSex_GoodResult()
        {
            string strRaceName = "Devaronian";
            string strRaceSex = "F";
            Race objRace = new Race();

            objRace.GetRace(strRaceName, strRaceSex);

            Assert.IsTrue (strRaceName== objRace.RaceName && strRaceSex  == objRace.Sex );
        }

        /// <summary>
        /// Test_s the get race_ by name sex_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRace(string RaceName, string RaceSex) Method, Bad Outcome")]
        public void Test_GetRace_ByNameSex_BadResult()
        {
            string strRaceName = "blah blah";
            string strRaceSex = "F";
            Race objRace = new Race();

            objRace.GetRace(strRaceName, strRaceSex);

            Assert.IsNull(objRace.RaceName);
        }
        #endregion

        #region GetFeatPrerequisiteRace(int FeatID)
        /// <summary>
        /// Test_s the get feat prerequisite race_ by i d_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteRace(int FeatID) Method, Good Outcome")]
        public void Test_GetFeatPrerequisiteRace_ByID_GoodResult()
        {
            int FeatID = 826;
            int RaceID = 38;
            Race objRace = new Race();

            objRace.GetFeatPrerequisiteRace(FeatID);

            Assert.AreEqual(RaceID, objRace.RaceID);
        }

        /// <summary>
        /// Test_s the get feat prerequisite race_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteRace(int FeatID) Method, Bad Outcome")]
        public void Test_GetFeatPrerequisiteRace_ByID_BadResult()
        {
            int FeatID = 1;
            Race objRace = new Race();

            objRace.GetFeatPrerequisiteRace(FeatID);

            Assert.IsNull(objRace.RaceName);
        }
        #endregion

        #region GetRaceRequirementForTalentTree(string strWhere, strOrderBy)
        /// <summary>
        /// Test_s the get race requirement for talent tree_ with order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForTalentTree(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetRaceRequirementForTalentTree_WithOrderBy_GoodResult()
        {
            string strWhere = "TalentTreeID=58";
            string strOrderBy = "RaceID";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForTalentTree(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count > 0);
        }

        /// <summary>
        /// Test_s the get race requirement for talent tree_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForTalentTree(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetRaceRequirementForTalentTree_WithOutOrderBy_GoodResult()
        {
            string strWhere = "TalentTreeID=58";
            string strOrderBy = "";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForTalentTree(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count > 0);
        }

        /// <summary>
        /// Test_s the get race requirement for talent tree_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForTalentTree(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetRaceRequirementForTalentTree_WithOrderBy_NoResult()
        {
            string strWhere = "TalentTreeID=1";
            string strOrderBy = "RaceID";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForTalentTree(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count == 0);
        }

        /// <summary>
        /// Test_s the get race requirement for talent tree_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForTalentTree(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetRaceRequirementForTalentTree_WithOutOrderBy_NoResult()
        {
            string strWhere = "TalentTreeID=1";
            string strOrderBy = "";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForTalentTree(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count == 0);
        }

        #endregion

        #region GetRaceRequirementForClass(string strWhere, strOrderBy)
        /// <summary>
        /// Test_s the get race requirement for class_ with order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForClass(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetRaceRequirementForClass_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=29";
            string strOrderBy = "RaceID";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForClass(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count > 0);
        }

        /// <summary>
        /// Test_s the get race requirement for class_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForClass(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetRaceRequirementForClass_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=29";
            string strOrderBy = "";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForClass(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count > 0);
        }

        /// <summary>
        /// Test_s the get race requirement for class_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForClass(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetRaceRequirementForClass_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "RaceID";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForClass(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count == 0);
        }

        /// <summary>
        /// Test_s the get race requirement for class_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaceRequirementForClass(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetRaceRequirementForClass_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaceRequirementForClass(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count == 0);
        }

        #endregion

        #region IsRaceInList(Race objRace, List<Race> lstRaceList)
        /// <summary>
        /// Test_s the is race in list_ true result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsRaceInList(Race objRace, List<Race> lstRaceList) Method, True Outcome")]
        public void Test_IsRaceInList_TrueResult()
        {
            Race objRace = new Race();

            List<Race> lstRaceList = new List<Race>();
            bool blnRaceIsInList;
            objRace.GetRace(1);

            for (int i = 0; i < 3; i++)
            {
                lstRaceList.Add(objRace);
            }

            blnRaceIsInList = Race.IsRaceInList(objRace, lstRaceList);

            Assert.IsTrue(blnRaceIsInList);
        }

        /// <summary>
        /// Test_s the is race in list_ false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsRaceInList(Race objRace, List<Race> lstRaceList) Method, Flase Outcome")]
        public void Test_IsRaceInList_FalseResult()
        {
            Race objRace = new Race();
            Race objRace2 = new Race();
            List<Race> lstRaceList = new List<Race>();
            bool blnRaceIsInList;
            objRace.GetRace(1);

            for (int i = 0; i < 3; i++)
            {
                lstRaceList.Add(objRace);
            }
            objRace2.GetRace(2);
            blnRaceIsInList = Race.IsRaceInList(objRace2, lstRaceList);

            Assert.IsFalse(blnRaceIsInList);
        }
        #endregion

        #region IsRaceInList(Race objRace, List<Race> lstRaceList)
        /// <summary>
        /// Test_s the is race in list list_ true result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsRaceInList(List<Race> lstNeedList, List<Race> lstRaceList) Method, True Outcome")]
        public void Test_IsRaceInListList_TrueResult()
        {
            Race objRace = new Race();
            Race objRace2 = new Race();
            List<Race> lstRaceList = new List<Race>();
            List<Race> lstNeedList = new List<Race>();
            bool blnRaceIsInList;
            objRace.GetRace(1);

            for (int i = 0; i < 3; i++)
            {
                lstRaceList.Add(objRace);
            }
            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objRace);
            }

            blnRaceIsInList = Race.IsRaceInList(lstNeedList, lstRaceList);

            Assert.IsTrue(blnRaceIsInList);
        }

        /// <summary>
        /// Test_s the is race in list list_ false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsRaceInList(List<Race> lstNeedList, List<Race> lstRaceList) Method, Flase Outcome")]
        public void Test_IsRaceInListList_FalseResult()
        {
            Race objRace = new Race();
            Race objRace2 = new Race();
            List<Race> lstRaceList = new List<Race>();
            List<Race> lstNeedList = new List<Race>();
            bool blnRaceIsInList;
            objRace.GetRace(1);
            objRace2.GetRace(2);

            for (int i = 0; i < 3; i++)
            {
                lstRaceList.Add(objRace);
            }

            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objRace2);
            }

            blnRaceIsInList = Race.IsRaceInList(lstNeedList, lstRaceList);

            Assert.IsFalse(blnRaceIsInList);
        }
        #endregion

        #region GetRaces(string strWhere, strOrderBy)
        /// <summary>
        /// Test_s the get races_ with order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaces(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetRaces_WithOrderBy_GoodResult()
        {
            string strWhere = "RaceName Like '%Devaronian%'";
            string strOrderBy = "RaceName";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaces(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count > 0);
        }

        /// <summary>
        /// Test_s the get races_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaces(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetRaces_WithOutOrderBy_GoodResult()
        {
            string strWhere = "RaceName Like '%Devaronian%'";
            string strOrderBy = "";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaces(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count > 0);
        }

        /// <summary>
        /// Test_s the get races_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaces(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetRaces_WithOrderBy_NoResult()
        {
            string strWhere = "RaceName Like '%Toad%'";
            string strOrderBy = "RaceName";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaces(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count == 0);
        }

        /// <summary>
        /// Test_s the get races_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetRaces(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetRaces_WithOutOrderBy_NoResult()
        {
            string strWhere = "RaceName Like '%Toad%'";
            string strOrderBy = "";

            Race objRace = new Race();
            List<Race> lstRaces = new List<Race>();

            lstRaces = objRace.GetRaces(strWhere, strOrderBy);

            Assert.IsTrue(lstRaces.Count == 0);
        }

        #endregion

        #region SaveAndDeleteRace()
        /// <summary>
        /// Test_s the save and delete race.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveRace and DeleteRace Methods)")]
        public void Test_SaveAndDeleteRace()
        {
            bool returnVal;

            objNewRace.SaveRace();

            Assert.IsTrue(objNewRace.RaceID != 0);

            returnVal = objNewRace.DeleteRace();

            Assert.IsTrue(returnVal && objNewRace.DeleteOK);
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
            objNewRace.Validate();
            Assert.IsTrue(objNewRace.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewRace.RaceName = "";
            objNewRace.Validate();
            Assert.IsTrue(!objNewRace.Validated && (objNewRace.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
