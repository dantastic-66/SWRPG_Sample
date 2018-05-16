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
    public class TalentTest
    {
        /// <summary>
        /// The object new talent
        /// </summary>
        Talent objNewTalent = new Talent();
        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTest"/> class.
        /// </summary>
        public TalentTest()
        {
            objNewTalent.TalentID = 0;
            objNewTalent.TalentName ="zzz Test Talent Name";
            objNewTalent.TalentDescription ="Test Description";
            objNewTalent.TalentSpecial = "";
            objNewTalent.TalentTreeID = 1;
            objNewTalent.TurnSegmentID = 1;
            objNewTalent.MultipleSelection = 0;
            objNewTalent.BookID =1;
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
        /// Tests the GetTalent by TalentID method.
        /// </summary>
        #region GetTalent(int TalentID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalent(int TalentID) Method, Good Outcome")]
        public void Test_GetTalent_ByID_GoodResult()
        {
            int intTalentID = 1; 
            Talent objTalent = new Talent();

            objTalent.GetTalent(intTalentID);

            Assert.AreEqual(intTalentID, objTalent.TalentID );
        }

        /// <summary>
        /// Test_s the get talent_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalent(int TalentID) Method, Bad Outcome")]
        public void Test_GetTalent_ByID_BadResult()
        {
            int intTalentID = 0;
            Talent objTalent = new Talent();

            objTalent.GetTalent(intTalentID);

            Assert.IsNull(objTalent.TalentName);
        }
        #endregion

        /// <summary>
        /// Tests the GetTalent by TalentName method.
        /// </summary>
        #region GetTalent(string strTalentName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalent(string TalentName) Method, Good Outcome")]
        public void Test_GetTalent_ByName_GoodResult()
        {
            string strTalentID = "Impel Ally I";
            Talent objTalent = new Talent();

            objTalent.GetTalent(strTalentID);

            Assert.AreEqual(strTalentID, objTalent.TalentName);
        }

        /// <summary>
        /// Test_s the get talent_ by name_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalent(string TalentName) Method, Bad Outcome")]
        public void Test_GetTalent_ByName_BadResult()
        {
            string strTalentID = "blah blah";
            Talent objTalent = new Talent();

            objTalent.GetTalent(strTalentID);

            Assert.IsNull(objTalent.TalentName);
        }
        #endregion

        /// <summary>
        /// Tests the GetCharacterTalent by strWhere, strOrderBy method.
        /// </summary>
        #region GetTreeTalents(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTreeTalents(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTreeTalents_WithOrderBy_GoodResult()
        {
            string strWhere = "otmTalentTreeTalent.TalentTreeID=1";
            string strOrderBy = "TalentName";

            Talent objTalent = new Talent();
            List<Talent> lstTreeTalents = new List<Talent>();

            lstTreeTalents = objTalent.GetTreeTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTreeTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get tree talents_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTreeTalents(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTreeTalents_WithOutOrderBy_GoodResult()
        {
            string strWhere = "otmTalentTreeTalent.TalentTreeID=1";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTreeTalents = new List<Talent>();

            lstTreeTalents = objTalent.GetTreeTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTreeTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get tree talents_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTreeTalents(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTreeTalents_WithOrderBy_NoResult()
        {
            string strWhere = "otmTalentTreeTalent.TalentTreeID=0";
            string strOrderBy = "TalentName";

            Talent objTalent = new Talent();
            List<Talent> lstTreeTalents = new List<Talent>();

            lstTreeTalents = objTalent.GetTreeTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTreeTalents.Count == 0);
        }

        /// <summary>
        /// Test_s the get tree talents_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTreeTalents(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTreeTalents_WithOutOrderBy_NoResult()
        {
            string strWhere = "otmTalentTreeTalent.TalentTreeID=0";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTreeTalents = new List<Talent>();

            lstTreeTalents = objTalent.GetTreeTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTreeTalents.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetTalents by strWhere, strOrderBy method.
        /// </summary>
        #region GetTalents(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalents(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalents_WithOrderBy_GoodResult()
        {
            string strWhere = "TalentName Like '%Savant%'";
            string strOrderBy = "TalentName";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get talents_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalents(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalents_WithOutOrderBy_GoodResult()
        {
            string strWhere = "TalentName Like '%Savant%'";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get talents_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalents(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalents_WithOrderBy_NoResult()
        {
            string strWhere = "TalentName Like '%Toad%'";
            string strOrderBy = "TalentName";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count == 0);
        }

        /// <summary>
        /// Test_s the get talents_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalents(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalents_WithOutOrderBy_NoResult()
        {
            string strWhere = "TalentName Like '%Toad%'";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetPrestigeRequiredTalents by strWhere, strOrderBy method.
        /// </summary>
        #region GetPrestigeRequiredTalents(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredTalents(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredTalents_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=15";
            string strOrderBy = "TalentID";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrestigeRequiredTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get prestige required talents_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredTalents(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredTalents_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=15";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrestigeRequiredTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get prestige required talents_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredTalents(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredTalents_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "TalentID";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrestigeRequiredTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count == 0);
        }

        /// <summary>
        /// Test_s the get prestige required talents_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredTalents(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredTalents_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrestigeRequiredTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetPrerequisteTalents by strWhere, strOrderBy method.
        /// </summary>
        #region GetPrerequisteTalents(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrerequisteTalents(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPrerequisteTalents_WithOrderBy_GoodResult()
        {
            string strWhere = "otmTalentPrerequisteTalent.TalentID=3400";
            string strOrderBy = "PrerequisteTalentID";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrerequisteTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get prerequiste talents_ with out order by_ good result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrerequisteTalents(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPrerequisteTalents_WithOutOrderBy_GoodResult()
        {
            string strWhere = "otmTalentPrerequisteTalent.TalentID=3400";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrerequisteTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get prerequiste talents_ with order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrerequisteTalents(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPrerequisteTalents_WithOrderBy_NoResult()
        {
            string strWhere = "otmTalentPrerequisteTalent.TalentID=1";
            string strOrderBy = "PrerequisteTalentID";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrerequisteTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count == 0);
        }

        /// <summary>
        /// Test_s the get prerequiste talents_ with out order by_ no result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrerequisteTalents(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPrerequisteTalents_WithOutOrderBy_NoResult()
        {
            string strWhere = "otmTalentPrerequisteTalent.TalentID=1";
            string strOrderBy = "";

            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetPrerequisteTalents(strWhere, strOrderBy);

            Assert.IsTrue(lstTalents.Count == 0);
        }

        #endregion

        /// <summary>
        /// Tests the GetCharacterTalents by CharacterID method.
        /// </summary>
        #region GetCharacterTalents(int CharacterID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterTalents(int CharacterID) Method, Good Outcome")]
        public void Test_GetCharacterTalents_ByID_GoodResult()
        {
            int CharacterID = 1;
            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetCharacterTalents(CharacterID);

            Assert.IsTrue(lstTalents.Count > 0);
        }

        /// <summary>
        /// Test_s the get character talents_ by i d_ bad result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterTalents(int CharacterID) Method, Bad Outcome")]
        public void Test_GetCharacterTalents_ByID_BadResult()
        {
            int CharacterID = 0;
            Talent objTalent = new Talent();
            List<Talent> lstTalents = new List<Talent>();

            lstTalents = objTalent.GetCharacterTalents(CharacterID);

            Assert.IsTrue(lstTalents.Count == 0);
        }
        #endregion

        #region IsTalentInList(Talent objTalent, List<Talent> lstTalentList)
        /// <summary>
        /// Test_s the is talent in list_ true result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentInList(Talent objTalent, List<Talent> lstTalentList) Method, True Outcome")]
        public void Test_IsTalentInList_TrueResult()
        {
            Talent objTalent = new Talent();

            List<Talent> lstTalentList = new List<Talent>();
            bool blnTalentIsInList;
            objTalent.GetTalent(1);

            for (int i = 0; i < 3; i++)
            {
                lstTalentList.Add(objTalent);
            }

            blnTalentIsInList = Talent.IsTalentInList(objTalent, lstTalentList);

            Assert.IsTrue(blnTalentIsInList);
        }

        /// <summary>
        /// Test_s the is talent in list_ false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentInList(Talent objTalent, List<Talent> lstTalentList) Method, Flase Outcome")]
        public void Test_IsTalentInList_FalseResult()
        {
            Talent objTalent = new Talent();
            Talent objTalent2 = new Talent();
            List<Talent> lstTalentList = new List<Talent>();
            bool blnTalentIsInList;
            objTalent.GetTalent(1);

            for (int i = 0; i < 3; i++)
            {
                lstTalentList.Add(objTalent);
            }
            objTalent2.GetTalent(2);
            blnTalentIsInList = Talent.IsTalentInList(objTalent2, lstTalentList);

            Assert.IsFalse(blnTalentIsInList);
        }
        #endregion

        #region IsTalentInList(List<Talent> lstNeedList, List<Talent> lstTalentList)
        /// <summary>
        /// Test_s the is talent in list list_ true result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentInList(List<Talent> lstNeedList, List<Talent> lstTalentList) Method, True Outcome")]
        public void Test_IsTalentInListList_TrueResult()
        {
            Talent objTalent = new Talent();
            Talent objTalent2 = new Talent();
            List<Talent> lstTalentList = new List<Talent>();
            List<Talent> lstNeedList = new List<Talent>();
            bool blnTalentIsInList;
            objTalent.GetTalent(1);

            for (int i = 0; i < 3; i++)
            {
                lstTalentList.Add(objTalent);
            }
            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objTalent);
            }

            blnTalentIsInList = Talent.IsTalentInList(lstNeedList, lstTalentList);

            Assert.IsTrue(blnTalentIsInList);
        }

        /// <summary>
        /// Test_s the is talent in list list_ false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsTalentInList(List<Talent> lstNeedList, List<Talent> lstTalentList) Method, Flase Outcome")]
        public void Test_IsTalentInListList_FalseResult()
        {
            Talent objTalent = new Talent();
            Talent objTalent2 = new Talent();
            List<Talent> lstTalentList = new List<Talent>();
            List<Talent> lstNeedList = new List<Talent>();
            bool blnTalentIsInList;
            objTalent.GetTalent(1);
            objTalent2.GetTalent(2);

            for (int i = 0; i < 3; i++)
            {
                lstTalentList.Add(objTalent);
            }

            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objTalent2);
            }

            blnTalentIsInList = Talent.IsTalentInList(lstNeedList, lstTalentList);

            Assert.IsFalse(blnTalentIsInList);
        }
        #endregion


        #region TalentAllowableForCharacterLevelingUp(Talent objTalent, Character objChar)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the TalentAllowableForCharacterLevelingUp(Talent objTalent, Character objChar) Method, True Outcome")]
        public void Test_TalentAllowableForCharacterLevelingUp_TrueResult()
        {
            Talent objTalent = new Talent();
            Character objChar = new Character();
            bool blnAllowable;
            objTalent.GetTalent(2);
            objChar.GetCharacter(1);

            blnAllowable = Talent.TalentAllowableByTalentList(objTalent, objChar.lstTalents);

            Assert.IsTrue(blnAllowable);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the TalentAllowableForCharacterLevelingUp(Talent objTalent, Character objChar) Method, False Outcome")]
        public void Test_TalentAllowableForCharacterLevelingUp_FalseResult()
        {
            Talent objTalent = new Talent();
            Character objChar = new Character();
            bool blnAllowable;
            objTalent.GetTalent(1);
            objChar.GetCharacter(1);

            blnAllowable = Talent.TalentAllowableByTalentList(objTalent, objChar.lstTalents );

            Assert.IsFalse(blnAllowable);
        }
        #endregion
        //#region IsTalentInList(List<Talent> lstNeedList, List<Talent> lstTalentList)
        ///// <summary>
        ///// Test_s the is talent in list list_ true result.
        ///// </summary>
        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test the IsTalentInList(List<Talent> lstNeedList, List<Talent> lstTalentList) Method, True Outcome")]
        //public void Test_IsTalentInListList_TrueResult()
        //{
        //    Talent objTalent = new Talent();
        //    Talent objTalent2 = new Talent();
        //    List<Talent> lstTalentList = new List<Talent>();
        //    List<Talent> lstNeedList = new List<Talent>();
        //    bool blnTalentIsInList;
        //    objTalent.GetTalent(1);

        //    for (int i = 0; i < 3; i++)
        //    {
        //        lstTalentList.Add(objTalent);
        //    }
        //    for (int i = 0; i < 1; i++)
        //    {
        //        lstNeedList.Add(objTalent);
        //    }

        //    blnTalentIsInList = Talent.IsTalentInList(lstNeedList, lstTalentList);

        //    Assert.IsTrue(blnTalentIsInList);
        //}

        ///// <summary>
        ///// Test's the TalentCountInList (Talent objTalent, List<Talent> lstTalents) fuction
        ///// </summary>
        //[TestMethod]
        //[Owner("Dan Cleary")]
        //[Description("Test theTalentCountInList (Talent objTalent, List<Talent> lstTalents) Method, 0 Outcome")]
        //public void Test_IsTalentInListList_FalseResult()
        //{
        //    Talent objTalent = new Talent();
        //    Talent objTalent2 = new Talent();
        //    List<Talent> lstTalentList = new List<Talent>();
        //    List<Talent> lstNeedList = new List<Talent>();
        //    bool blnTalentIsInList;
        //    objTalent.GetTalent(1);
        //    objTalent2.GetTalent(2);

        //    for (int i = 0; i < 3; i++)
        //    {
        //        lstTalentList.Add(objTalent);
        //    }

        //    for (int i = 0; i < 1; i++)
        //    {
        //        lstNeedList.Add(objTalent2);
        //    }

        //    blnTalentIsInList = Talent.IsTalentInList(lstNeedList, lstTalentList);

        //    Assert.IsFalse(blnTalentIsInList);
        //}
        //#endregion
        ////TalentCountInList (Talent objTalent, List<Talent> lstTalents)
                
        #region SaveAndDeleteTalent()
        /// <summary>
        /// Test_s the save and delete talent.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveTalent and DeleteTalent Methods)")]
        public void Test_SaveAndDeleteTalent()
        {
            bool returnVal;

            objNewTalent.SaveTalent();

            Assert.IsTrue(objNewTalent.TalentID != 0);

            returnVal = objNewTalent.DeleteTalent();

            Assert.IsTrue(returnVal && objNewTalent.DeleteOK);
        }
        #endregion

        #region SaveAndDeleteCharacterTalent()
        /// <summary>
        /// Test_s the save and delete character talent.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveCharacterTalent and DeleteCharacterTalent Methods)")]
        public void Test_SaveAndDeleteCharacterTalent()
        {
            bool returnVal;
            int CharacterID = 1;
            int TalentID = 50;

            Talent objTalent = new Talent();
            Talent objTalent2 = new Talent();
            objTalent.GetTalent(TalentID);
            objTalent2.SaveCharacterTalent(CharacterID, TalentID);

            List<Talent> lstTalent = new List<Talent>();
            lstTalent = objTalent.GetCharacterTalents(CharacterID);

            Assert.IsTrue(Talent.IsTalentInList(objTalent,lstTalent));

            returnVal = objTalent.DeleteCharacterTalent(CharacterID,TalentID);

            Assert.IsTrue(returnVal && objTalent.DeleteOK);
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
            objNewTalent.Validate();
            Assert.IsTrue(objNewTalent.Validated);
        }

        /// <summary>
        /// Validate_s the false result.
        /// </summary>
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            objNewTalent.TalentName = "";
            objNewTalent.Validate();
            Assert.IsTrue(!objNewTalent.Validated && (objNewTalent.ValidationMessage.Length > 0));
        }
        #endregion
    }
}
