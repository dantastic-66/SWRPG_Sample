using System;
using StarWarsClasses; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace SWRPGClassUnitTests
{
    [TestClass]
    public class FeatTest
    {
        #region GetFeat(int intFeatID)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeat(int FeatID) Method, Good Outcome")]
        public void Test_GetFeat_ByID_GoodResult()
        {
            int intFeatID = 828; //1;
            Feat objFeat = new Feat();

            objFeat.GetFeat(intFeatID);

            Assert.AreEqual(intFeatID, objFeat.FeatID );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeat(int FeatID) Method, Bad Outcome")]
        public void Test_GetFeat_ByID_BadResult()
        {
            int intFeatID = 0;
            Feat objFeat = new Feat();

            objFeat.GetFeat(intFeatID);

            Assert.IsNull (objFeat.FeatName);
        }
        #endregion

        #region GetFeat(string strFeatName)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeat(string FeatName) Method, Good Outcome")]
        public void Test_GetFeat_ByName_GoodResult()
        {
            string  strFeatID = "Force Sensitivity";
            Feat objFeat = new Feat();

            objFeat.GetFeat(strFeatID);

            Assert.AreEqual(strFeatID, objFeat.FeatName );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeat(string FeatName) Method, Bad Outcome")]
        public void Test_GetFeat_ByName_BadResult()
        {
            string strFeatID = "blah blah";
            Feat objFeat = new Feat();

            objFeat.GetFeat(strFeatID);

            Assert.IsNull(objFeat.FeatName);
        }
        #endregion

        #region GetStartingFeats(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetStartingFeats(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetStartingFeats_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=1";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetStartingFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetStartingFeats(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetStartingFeats_WithOutOrderBy_GoodResult()
        {
            //(" ClassID=" + objClass.ClassID.ToString(), "FeatName"
            string strWhere = "ClassID=1";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetStartingFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetStartingFeats(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetStartingFeats_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=0";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetStartingFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count==0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetStartingFeats(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetStartingFeats_WithOutOrderBy_NoResult()
        {
            //(" ClassID=" + objClass.ClassID.ToString(), "FeatName"
            string strWhere = "ClassID=0";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetStartingFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion

        #region GetCharacterFeats(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterFeats(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetCharacterFeats_WithOrderBy_GoodResult()
        {
            string strWhere = "CharacterID=1";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetCharacterFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterFeats(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetCharacterFeats_WithOutOrderBy_GoodResult()
        {
            //(" ClassID=" + objClass.ClassID.ToString(), "FeatName"
            string strWhere = "CharacterID=1";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetCharacterFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterFeats(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetCharacterFeats_WithOrderBy_NoResult()
        {
            string strWhere = "CharacterID=0";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetCharacterFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetCharacterFeats(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetCharacterFeats_WithOutOrderBy_NoResult()
        {
            //(" ClassID=" + objClass.ClassID.ToString(), "FeatName"
            string strWhere = "CharacterID=0";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetCharacterFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion

        #region GetPrestigeRequiredFeats(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeats(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredFeats_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=26";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeats(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredFeats_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=26";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeats(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredFeats_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=0";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeats(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredFeats_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=0";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion

        #region GetPrestigeRequiredFeatGroups(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeatGroups(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredFeatGroups_WithOrderBy_GoodResult()
        {
            string strWhere = "ClassID=8";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeatGroups(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeatGroups(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredFeatGroups_WithOutOrderBy_GoodResult()
        {
            string strWhere = "ClassID=8";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeatGroups(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeatGroups(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetPrestigeRequiredFeatGroups_WithOrderBy_NoResult()
        {
            string strWhere = "ClassID=0";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeatGroups(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetPrestigeRequiredFeatGroups(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetPrestigeRequiredFeatGroups_WithOutOrderBy_NoResult()
        {
            string strWhere = "ClassID=0";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetPrestigeRequiredFeatGroups(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion

        #region GetFeats(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeats(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetFeats_WithOrderBy_GoodResult()
        {
            string strWhere = "FeatName Like '%Force%'";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeats(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetFeats_WithOutOrderBy_GoodResult()
        {
            string strWhere = "FeatName Like '%Force%'";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeats(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetFeats_WithOrderBy_NoResult()
        {
            string strWhere = "FeatName Like '%Toad%'";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeats(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetFeats_WithOutOrderBy_NoResult()
        {
            string strWhere = "FeatName Like '%Toad%'";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion


        //GetBonusFeatsForClass
        #region GetBonusFeatsForClass(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBonusFeatsForClass(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetBonusFeatsForClass_GoodResult()
        {
            Class objClass = new Class();
            objClass.GetClass(1);

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetBonusFeatsForClass(objClass);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetBonusFeatsForClass(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetBonusFeatsForClass_NoResult()
        {
            Class objClass = new Class();
            objClass.GetClass(0);

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetBonusFeatsForClass(objClass);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion



        #region GetFeatPrerequisiteFeats(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteFeats(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetFeatPrerequisiteFeats_WithOrderBy_GoodResult()
        {
            string strWhere = "[otmFeatPrequisiteFeat].FeatID=4";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeatPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteFeats(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetFeatPrerequisiteFeats_WithOutOrderBy_GoodResult()
        {
            string strWhere = "[otmFeatPrequisiteFeat].FeatID=4";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeatPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteFeats(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetFeatPrerequisiteFeats_WithOrderBy_NoResult()
        {
            string strWhere = "[otmFeatPrequisiteFeat].FeatID=0";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeatPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetFeatPrerequisiteFeats(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetFeatPrerequisiteFeats_WithOutOrderBy_NoResult()
        {
            string strWhere = "[otmFeatPrequisiteFeat].FeatID=0";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetFeatPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion

        #region GetTalentPrerequisiteFeats(string strWhere, strOrderBy)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisiteFeats(string strWhere, strOrderBy) Method, Good Outcome with OrderBy")]
        public void Test_GetTalentPrerequisiteFeats_WithOrderBy_GoodResult()
        {
            string strWhere = "TalentID=111";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetTalentPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisiteFeats(string strWhere, strOrderBy) Method, Good Outcome without OrderBy")]
        public void Test_GetTalentPrerequisiteFeats_WithOutOrderBy_GoodResult()
        {
            string strWhere = "TalentID=111";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetTalentPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count > 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisiteFeats(string strWhere, strOrderBy) Method, No Outcome with OrderBy")]
        public void Test_GetTalentPrerequisiteFeats_WithOrderBy_NoResult()
        {
            string strWhere = "TalentID=0";
            string strOrderBy = "";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetTalentPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetTalentPrerequisiteFeats(string strWhere, strOrderBy) Method, No Outcome without OrderBy")]
        public void Test_GetTalentPrerequisiteFeats_WithOutOrderBy_NoResult()
        {
            string strWhere = "TalentID=0";
            string strOrderBy = "FeatName";

            Feat objFeat = new Feat();
            List<Feat> lstFeats = new List<Feat>();

            lstFeats = objFeat.GetTalentPrerequisiteFeats(strWhere, strOrderBy);

            Assert.IsTrue(lstFeats.Count == 0);
        }

        #endregion

        #region SaveAndDeleteFeat_ModifyCharaterFeats()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveCharacterFeat and Delete Character Feat Methods)")]
        public void Test_SaveAndDeleteFeat_ModifyCharaterFeats()
        {
            int intCharacterID = 1;
            int intFeatID = 3;

            bool returnVal;

            Feat objFeat = new Feat();
            Feat objCharFeat = new Feat();

            objCharFeat = objFeat.SaveCharacterFeat(intCharacterID,intFeatID );

            Assert.IsTrue(objCharFeat.FeatID == intFeatID);

            returnVal = objCharFeat.DeleteCharacterFeat(intCharacterID, intFeatID );

            Assert.IsTrue(returnVal );


        }
        #endregion

        #region SaveAndDeleteFeat_ModifyFeats()
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test SaveFeat and DeleteFeat Methods)")]
        public void Test_SaveAndDeleteFeat_ModifyFeats()
        {
            bool returnVal;

            Feat objFeat = new Feat();
            Feat objNewFeat = new Feat();
            objFeat.FeatName = "TestFeat";
            objFeat.FeatDescription = "New Feat Description";
            objNewFeat = objFeat.SaveFeat();

            Assert.IsTrue(objNewFeat.FeatID != 0);

            returnVal = objNewFeat.DeleteFeat();

            Assert.IsTrue(returnVal);
        }
        #endregion

        #region RemoveFeatListFromList(List<Feat> FeatsToRemove, List<Feat> MainList)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the RemoveFeatListFromList(List<Feat> FeatsToRemove, List<Feat> MainList) Method, Good Outcome")]
        public void Test_RemoveFeatListFromList_GoodResult()
        {
            Feat objFeat = new Feat();
            List<Feat> objRemoveFeats = new List<Feat>();
            List<Feat> objFeats = new List<Feat>();
            int intTotalFeatsCount = 0;

            objFeats = objFeat.GetFeats("FeatID IN (1,2)", "");
            intTotalFeatsCount = objFeats.Count;

            objRemoveFeats = objFeat.GetFeats("FeatID IN (1)", "");

            objFeats = Feat.RemoveFeatListFromList(objRemoveFeats,objFeats);

            Assert.AreEqual(intTotalFeatsCount, objFeats.Count + 1 );
        }
        #endregion

        #region CheckFeatCount(Feat objFeat, List<Feat> lstFeatList)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the CheckFeatCount(Feat objFeat, List<Feat> lstFeatList) Method, True Outcome")]
        public void Test_CheckFeatCount_TrueResult()
        {
            Feat objFeat = new Feat();
            
            List<Feat> lstFeatList = new List<Feat>();
            bool blnFeatCountLessThanMax;
            objFeat.GetFeat (116);

            for (int i = 0; i < objFeat.MultipleSelection -3 ; i++)
            {
                lstFeatList.Add(objFeat);
            }

            blnFeatCountLessThanMax = Feat.CheckFeatCount(objFeat,lstFeatList);

            Assert.IsTrue(blnFeatCountLessThanMax);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the CheckFeatCount(Feat objFeat, List<Feat> lstFeatList) Method, Flase Outcome")]
        public void Test_CheckFeatCount_FalseResult()
        {
            Feat objFeat = new Feat();

            List<Feat> lstFeatList = new List<Feat>();
            bool blnFeatCountLessThanMax;
            objFeat.GetFeat(116);

            for (int i = 0; i < objFeat.MultipleSelection + 3; i++)
            {
                lstFeatList.Add(objFeat);
            }

            blnFeatCountLessThanMax = Feat.CheckFeatCount(objFeat, lstFeatList);

            Assert.IsFalse (blnFeatCountLessThanMax);
        }
        #endregion

        #region GetAllFeatsCharacterQualifiedFor(Character objChar) List<Feat> )
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the GetAllFeatsCharacterQualifiedFor(Character objChar) Method ")]
        public void Test_GetAllFeatsCharacterQualifiedFor()
        {
            Character objChar = new Character();
            objChar.GetCharacter(1);

            Feat objFeat = new Feat();
            List<Feat> objFeats = new List<Feat>();
            objFeats = Feat.GetAllFeatsCharacterQualifedFor(objChar);

            Assert.IsTrue(objFeats.Count > 1);
        }
        #endregion

        #region IsFeatInList(Feat objFeat, List<Feat> lstFeatList)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatInList(Feat objFeat, List<Feat> lstFeatList) Method, True Outcome")]
        public void Test_IsFeatInList_TrueResult()
        {
            Feat objFeat = new Feat();
            
            List<Feat> lstFeatList = new List<Feat>();
            bool blnFeatIsInList;
            objFeat.GetFeat (1);

            for (int i = 0; i < 3 ; i++)
            {
                lstFeatList.Add(objFeat);
            }

            blnFeatIsInList = Feat.IsFeatInList(objFeat,lstFeatList);

            Assert.IsTrue(blnFeatIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatInList(Feat objFeat, List<Feat> lstFeatList) Method, Flase Outcome")]
        public void Test_IsFeatInList_FalseResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();
            List<Feat> lstFeatList = new List<Feat>();
            bool blnFeatIsInList;
            objFeat.GetFeat(1);

            for (int i = 0; i < 3; i++)
            {
                lstFeatList.Add(objFeat);
            }
            objFeat2.GetFeat(2);
            blnFeatIsInList = Feat.IsFeatInList(objFeat2, lstFeatList);

            Assert.IsFalse (blnFeatIsInList);
        }
        #endregion

        #region IsFeatInList(Feat objFeat, List<Feat> lstFeatList)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatInList(List<Feat> lstNeedList, List<Feat> lstFeatList) Method, True Outcome")]
        public void Test_IsFeatInListList_TrueResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();
            List<Feat> lstFeatList = new List<Feat>();
            List<Feat> lstNeedList = new List<Feat>();
            bool blnFeatIsInList;
            objFeat.GetFeat(1);

            for (int i = 0; i < 3; i++)
            {
                lstFeatList.Add(objFeat);
            }
            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objFeat);
            }

            blnFeatIsInList = Feat.IsFeatInList(lstNeedList, lstFeatList);

            Assert.IsTrue(blnFeatIsInList);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatInList(List<Feat> lstNeedList, List<Feat> lstFeatList) Method, Flase Outcome")]
        public void Test_IsFeatInListList_FalseResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();
            List<Feat> lstFeatList = new List<Feat>();
            List<Feat> lstNeedList = new List<Feat>();
            bool blnFeatIsInList;
            objFeat.GetFeat(1);
            objFeat2.GetFeat(2);

            for (int i = 0; i < 3; i++)
            {
                lstFeatList.Add(objFeat);
            }

            for (int i = 0; i < 1; i++)
            {
                lstNeedList.Add(objFeat2);
            }

            blnFeatIsInList = Feat.IsFeatInList(lstNeedList, lstFeatList);

            Assert.IsFalse(blnFeatIsInList);
        }
        #endregion

        #region IsFeatRageRequired(Feat objFeat, List<Feat> lstFeatList)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatRageRequired(Feat objFeat, bool blnCharHasRage) Method, True Outcome")]
        public void Test_IsFeatRageRequired_TrueResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();
            
            bool blnFeatIsRageRequired;
            objFeat.GetFeat(1);
            objFeat2.GetFeat(791);

            blnFeatIsRageRequired = Feat.IsFeatRageRequired (objFeat, true);
            Assert.IsTrue(blnFeatIsRageRequired);

            blnFeatIsRageRequired = Feat.IsFeatRageRequired(objFeat2, true);
            Assert.IsTrue(blnFeatIsRageRequired);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatRageRequired(Feat objFeat, bool blnCharHasRage) Method, Flase Outcome")]
        public void Test_IsFeatRageRequired_FalseResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();

            bool blnFeatIsRageRequired;
            objFeat.GetFeat(1);
            objFeat2.GetFeat(791);

            blnFeatIsRageRequired = Feat.IsFeatRageRequired(objFeat, false);
            Assert.IsTrue(blnFeatIsRageRequired);

            blnFeatIsRageRequired = Feat.IsFeatRageRequired(objFeat2, false);
            Assert.IsFalse(blnFeatIsRageRequired);
        }
        #endregion

        #region  IsFeatShapeShiftRequired(Feat objFeat, bool blnCharHasRage)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatShapeShiftRequired(Feat objFeat, bool blnCharHasRage) Method, True Outcome")]
        public void Test_IsFeatShapeShiftRequired_TrueResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();

            bool blnFeatisShapeShiftRequired;
            objFeat.GetFeat(1);
            objFeat2.GetFeat(808);

            blnFeatisShapeShiftRequired = Feat.IsFeatShapeShiftRequired(objFeat, true);
            Assert.IsTrue(blnFeatisShapeShiftRequired);

            blnFeatisShapeShiftRequired = Feat.IsFeatShapeShiftRequired(objFeat2, true);
            Assert.IsTrue(blnFeatisShapeShiftRequired);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatShapeShiftRequired(Feat objFeat, bool blnCharHasRage) Method, Flase Outcome")]
        public void Test_IsFeatShapeShiftRequired_FalseResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();

            bool blnFeatisShapeShiftRequired;
            objFeat.GetFeat(1);
            objFeat2.GetFeat(808);

            blnFeatisShapeShiftRequired = Feat.IsFeatShapeShiftRequired(objFeat, false);
            Assert.IsTrue(blnFeatisShapeShiftRequired);

            blnFeatisShapeShiftRequired = Feat.IsFeatShapeShiftRequired(objFeat2, false);
            Assert.IsFalse(blnFeatisShapeShiftRequired);
        }
        #endregion

        #region IsFeatDarkSideRequired(Feat objFeat,  bool blnCharHasRage)
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatDarkSideRequired(Feat objFeat, bool blnCharHasRage) Method, True Outcome")]
        public void Test_IsFeatDarkSideRequired_TrueResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();

            Character objChar = new Character();
            objChar.GetCharacter(1);

            bool blnFeatisDarksideRequired;
            objFeat.GetFeat(1);
            objFeat2.GetFeat(828);

            blnFeatisDarksideRequired = Feat.IsFeatDarkSideRequired(objFeat, objChar);
            Assert.IsTrue(blnFeatisDarksideRequired);

            blnFeatisDarksideRequired = Feat.IsFeatDarkSideRequired(objFeat2, objChar);
            Assert.IsTrue(blnFeatisDarksideRequired);
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the IsFeatDarkSideRequired(Feat objFeat, bool blnCharHasRage) Method, Flase Outcome")]
        public void Test_IsFeatDarkSideRequired_FalseResult()
        {
            Feat objFeat = new Feat();
            Feat objFeat2 = new Feat();

            Character objChar = new Character();
            objChar.GetCharacter(1);
            objChar.DarkSidePoints = 0;

            bool blnFeatisDarksideRequired;
            objFeat.GetFeat(1);
            objFeat2.GetFeat(828);

            blnFeatisDarksideRequired = Feat.IsFeatDarkSideRequired(objFeat, objChar);
            Assert.IsTrue(blnFeatisDarksideRequired);

            blnFeatisDarksideRequired = Feat.IsFeatDarkSideRequired(objFeat2, objChar);
            Assert.IsFalse(blnFeatisDarksideRequired);
        }
        #endregion

        #region Validate() returns bool
        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, True Outcome")]
        public void Validate_TrueResult()
        {
            Feat objFeat = new Feat();
            objFeat.FeatName = "New Test Feat";
            objFeat.Validate();
            Assert.IsTrue(objFeat.Validated );
        }

        [TestMethod]
        [Owner("Dan Cleary")]
        [Description("Test the Validate() Method, False Outcome")]
        public void Validate_FalseResult()
        {
            Feat objFeat = new Feat();
            objFeat.FeatName = "";
            objFeat.Validate();
            Assert.IsTrue  (!objFeat.Validated && (objFeat.ValidationMessage.Length > 0));
        }
        #endregion
    }

}
