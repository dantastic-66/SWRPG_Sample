using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StarWarsClasses
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class Feat : BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the feat identifier.
        /// </summary>
        /// <value>
        /// The feat identifier.
        /// </value>
        public int FeatID { get; set; }
        /// <summary>
        /// Gets or sets the name of the feat.
        /// </summary>
        /// <value>
        /// The name of the feat.
        /// </value>
        public string FeatName { get; set; }
        /// <summary>
        /// Gets or sets the feat description.
        /// </summary>
        /// <value>
        /// The feat description.
        /// </value>
        public string FeatDescription { get; set; }
        /// <summary>
        /// Gets or sets the feat special.
        /// </summary>
        /// <value>
        /// The feat special.
        /// </value>
        public string FeatSpecial { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [rage required].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [rage required]; otherwise, <c>false</c>.
        /// </value>
        public bool RageRequired { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [shape shift required].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [shape shift required]; otherwise, <c>false</c>.
        /// </value>
        public bool ShapeShiftRequired { get; set; }
        /// <summary>
        /// Gets or sets the multiple selection.
        /// </summary>
        /// <value>
        /// The multiple selection.
        /// </value>
        public int MultipleSelection { get; set; }
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public int BookID { get; set; }

        public bool SkillTrainingFeat { get; set; }

        public bool SkillFocusFeat { get; set; }

        public bool WeaponProficiencyID { get; set; }

        public bool ArmorProficiencyID { get; set; }

        /// <summary>
        /// Gets or sets the object base attack prerequisite.
        /// </summary>
        /// <value>
        /// The object base attack prerequisite.
        /// </value>
        public BaseAttack objBaseAttackPrerequisite { get; set; }

        /// <summary>
        /// Gets or sets the object feat prerequisite dark side.
        /// </summary>
        /// <value>
        /// The object feat prerequisite dark side.
        /// </value>
        public FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide { get; set; }

        /// <summary>
        /// Gets or sets the object skill prerequisite.
        /// </summary>
        /// <value>
        /// The object skill prerequisite.
        /// </value>
        public Skill objSkillPrerequisite { get; set; }

        /// <summary>
        /// Gets or sets the object race prerequisite.
        /// </summary>
        /// <value>
        /// The object race prerequisite.
        /// </value>
        public Race objRacePrerequisite { get; set; }

        /// <summary>
        /// Gets or sets the object feat prerequisite abilities.
        /// </summary>
        /// <value>
        /// The object feat prerequisite abilities.
        /// </value>
        public List<FeatPrerequisiteAbility> objFeatPrerequisiteAbilities { get; set; }

        /// <summary>
        /// Gets or sets the object feat prerequisite feats.
        /// </summary>
        /// <value>
        /// The object feat prerequisite feats.
        /// </value>
        public List<Feat> objFeatPrerequisiteFeats { get; set; }

        /// <summary>
        /// Gets or sets the size of the object feat prerequisite.
        /// </summary>
        /// <value>
        /// The size of the object feat prerequisite.
        /// </value>
        public List<Size> objFeatPrerequisiteSize{ get; set; }

        /// <summary>
        /// Gets or sets the object feat prerequisite classes.
        /// </summary>
        /// <value>
        /// The object feat prerequisite classes.
        /// </value>
        public List<Class> objFeatPrerequisiteClasses{ get; set; }

        public List<FeatPrereqORCondition> lstFeatPrereqORConditions { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Feat"/> class.
        /// </summary>
        public Feat()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feat"/> class.
        /// </summary>
        /// <param name="FeatName">Name of the Feat.</param>
        public Feat(string FeatName)
        {
            SetBaseConstructorOptions();
            GetFeat(FeatName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feat"/> class.
        /// </summary>
        /// <param name="FeatID">The Feat identifier.</param>
        public Feat(int FeatID)
        {
            SetBaseConstructorOptions();
            GetFeat(FeatID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the feat.
        /// </summary>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns></returns>
        public Feat GetFeat(int FeatID)
        {
            return GetSingleFeat("Select_Feat", "  FeatID=" + FeatID.ToString(), "FeatName");
         }

        /// <summary>
        /// Gets the feat.
        /// </summary>
        /// <param name="FeatName">Name of the feat.</param>
        /// <returns></returns>
        public Feat GetFeat(string FeatName)
        {
            return GetSingleFeat("Select_Feat", "  FeatName='" + FeatName + "'", "FeatName");
        }

        /// <summary>
        /// Gets the starting feats.
        /// </summary>
        /// <param name="ClassID">The Character Class</param>
        /// <param name="strOrderBy"></param>
        /// <returns>List of Feats</returns>
        public List<Feat> GetStartingFeats(int ClassID)
        {
            //TODO: Unit Test
            return GetFeatList("Select_StartingFeats", "ClassID=" + ClassID.ToString(), "FeatName");
        }

        /// <summary>
        /// Gets the starting feats.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetStartingFeats(string strWhere, string strOrderBy)
        {
            return GetFeatList("Select_StartingFeats", strWhere, strOrderBy);
         }

        /// <summary>
        /// Gets the character feats.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetCharacterFeats(string strWhere, string strOrderBy)
        {
            return GetFeatList("Select_CharacterFeats", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the Skill Training feats.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetSkillTrainingFeats()
        {
            return GetFeatList("Select_SkillTrainingFeats", "", "");
        }

        /// <summary>
        /// Gets the bonus feats for class.
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <returns> List<Feat></returns>
        public List<Feat> GetBonusFeatsForClass (Class objClass)
        {
            return GetFeatList("Select_BonusFeats", "ClassID=" + objClass.ClassID, "FeatName");
        }

        /// <summary>
        /// Gets the bonus feats for class.
        /// </summary>
        /// <param name="intRaceID">The Race identifier.</param>
        /// <returns> List<Feat></returns>
        public List<Feat> GetBonusFeatsForRace(int intRaceID)
        {
            return GetFeatList("Select_RaceBonusFeats", "RaceID=" + intRaceID.ToString(), "FeatName");
        }

        /// <summary>
        /// Gets the bonus feats for character classes.
        /// </summary>
        /// <param name="objChar">The object character.</param>
        /// <returns></returns>
        public List<Feat > GetBonusFeatsForCharacterClasses(Character objChar)
        {
            string strWhere = "";
            //string strWhereBlock = "";
            if (objChar.lstCharacterClassLevels.Count == 1) strWhere = "ClassID="; else strWhere = "ClassID IN (";

            foreach (CharacterClassLevel objCharacterClassLevels in objChar.lstCharacterClassLevels)
            {
                if(!objCharacterClassLevels.objCharacterClass.IsPrestige  )
                {
                    strWhere = strWhere + objCharacterClassLevels.ClassID.ToString() + ",";
                }
            }
            strWhere = strWhere.Substring(0, strWhere.Length - 1);
            if (objChar.lstCharacterClassLevels.Count != 1) strWhere = strWhere + ")";
            return GetFeatList("Select_BonusFeats", strWhere, "FeatName");
        }

        /// <summary>
        /// Gets the Armor Proficiency Feats
        /// </summary>
        /// <returns> List<Feat></returns>
        public List<Feat> GetArmorProficiencyFeats()
        {
            return GetFeatList("Select_ArmorProficiencyFeats", "", "");
        }
        
        /// <summary>
        /// Deletes the character feat.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns></returns>
        public bool DeleteCharacterFeat (int CharacterID, int FeatID)
        {
            bool retDeleteSuccessful = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_CharacterFeat";

                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.VarChar, FeatID.ToString(), 1000));
                result = command.ExecuteReader();

            }
            catch
            {
                retDeleteSuccessful = false;
                Exception e = new Exception();
                this._validated = false;
                this._validationMessage.Append(e.Message.ToString());
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return retDeleteSuccessful;
        }

        /// <summary>
        /// Saves a List of Feats to a Character.
        /// </summary>
        /// <param name="lstCharFeat">A <List> of Feats .</param>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <returns></returns>
        public void SaveCharacterFeats(List<Feat> lstCharFeat, int intCharacterID)
        {
            //Once a Feat is added it cannot be removed, or updated, just add the new ones
            //Feat objDelFeat = new Feat();
            //objDelFeat.DeleteCharacterFeat(intCharacterID, 0);

            foreach (Feat objCharFeat in lstCharFeat)
            {
                objCharFeat.SaveCharacterFeat(intCharacterID, objCharFeat.FeatID);
            }
        }

        /// <summary>
        /// Saves the character feat.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns></returns>
        public Feat SaveCharacterFeat(int CharacterID, int FeatID)
        {
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertUpdate_CharacterFeat";

                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.VarChar, FeatID.ToString(), 1000));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._validated = false;
                this._validationMessage.Append(e.Message.ToString());
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return GetFeat(FeatID); 

        }

        /// <summary>
        /// Gets the prestige required feats.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetPrestigeRequiredFeats(string strWhere, string strOrderBy)
        {
            return GetFeatList("Select_PrestigeRequiredFeats", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the prestige required feat groups.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetPrestigeRequiredFeatGroups(string strWhere, string strOrderBy)
        {
            return GetFeatList("Select_PrestigeRequiredFeatGroups", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the feats.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetFeats(string strWhere, string strOrderBy)
        {
            return GetFeatList("Select_Feat", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the feat prerequisite feats.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetFeatPrerequisiteFeats(string strWhere, string strOrderBy)
        {
            return GetFeatList("Select_FeatPrerequisiteFeats", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the talent prerequisite feats.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Feat> GetTalentPrerequisiteFeats(string strWhere, string strOrderBy)
        {
            return GetFeatList("Select_TalentPrerequisiteFeats", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the feat.
        /// </summary>
        /// <returns></returns>
        public Feat SaveFeat()
        {

            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertUpdate_Feat";
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatName", SqlDbType.VarChar, FeatName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatDescription", SqlDbType.VarChar, FeatDescription.ToString(),400));
                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._validated = false;
                this._validationMessage.Append(e.Message.ToString());
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this;
        }

        /// <summary>
        /// Deletes the feat.
        /// </summary>
        /// <returns></returns>
        public bool DeleteFeat()
        {
            bool retDeleteGood = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_Feat";
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK  = false;
                this._deletionMessage.Append(e.Message.ToString());
                retDeleteGood = false;
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            _deleteOK = retDeleteGood;
            return retDeleteGood;
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.FeatName))
            {
                this._validated = false;
                this._validationMessage.Append("The Feat Name cannot be blank or null.");
            }
            return this.Validated;
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Is the Feat a Skill Training Feat and in the Character Skill List if so.
        /// </summary>
        /// <param name="objFeat">The Feat to check.</param>
        /// <param name="lstCharSkill">The List of Character Skills</param>
        /// <returns>Bool</returns>
        static public bool IsFeatSkillTrainingFeatAndInSkillList(Feat objFeat, List<CharacterSkill> lstCharSkill)
        {
            bool retVal = false;

            if (!objFeat.SkillTrainingFeat) retVal = true;
            else
            {
                //We want to have the skill show up (return true) if it makes it here, if they have the skill then we don't show it
                retVal = true;
                foreach (CharacterSkill objCharSkill in lstCharSkill)
                {
                    if (objCharSkill.objSkill.SkillTrainingFeatID == objFeat.FeatID) retVal = false;
                }
            }

            return retVal;
        }

        /// <summary>
        /// Is the Feat a Skill Training Feat and in the Character able to select that Skill
        /// </summary>
        /// <param name="objFeat">The Feat to check (Could be a Skill Training Feat)</param>
        /// <param name="objChar">A Character object</param>
        /// <returns>Bool</returns>
        static public bool IsSkillTrainingFeatAndCharacterClassesHaveAccess(Feat objFeat, Character objChar)
        {
            bool retVal = false;
            Feat objDumbFeat = new Feat();
            List<Feat> lstSkillTrainingFeats = new List<Feat>();
            lstSkillTrainingFeats = objDumbFeat.GetSkillTrainingFeats();
            
            List<Skill> lstCharSelectableSkills = new List<Skill>();

            Skill objSkillTrainingSkill = new Skill();

            Class objDumbClass = new Class();

            if (!Feat.IsFeatInList(objFeat, lstSkillTrainingFeats)) retVal = true;
            else
            {
                //If it is a skill training feat then we have to check to see if the character has that skill available to them.
                lstCharSelectableSkills = objSkillTrainingSkill.GetCharacterSelectableSkillList(objChar, objDumbClass);
                objSkillTrainingSkill = objSkillTrainingSkill.GetSkillBySkillTrainingFeatID(objFeat.FeatID);
                if (Skill.IsSkillInList(objSkillTrainingSkill, lstCharSelectableSkills)) retVal = true; else retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// Removes the feat list from list.
        /// </summary>
        /// <param name="FeatsToRemove">The feats to remove.</param>
        /// <param name="MainList">The main list.</param>
        /// <returns></returns>
        static public List<Feat> RemoveFeatListFromList(List<Feat> FeatsToRemove, List<Feat> MainList)
        {
            List<Feat> FeatsToReturn = new List<Feat>();
            //FeatsToReturn = MainList;
            bool blnFeatInList = false;
            foreach (Feat objMainListFeat in MainList)
            {
                if (objMainListFeat.MultipleSelection == 0)
                {
                    //if (MainList.Contains(objFeat)) MainList.Remove(objFeat);
                    blnFeatInList = false;
                    foreach (Feat objFeat in FeatsToRemove)
                    {
                        if (objFeat.FeatID == objMainListFeat.FeatID)
                        {
                            blnFeatInList = true;
                        }
                        //FeatsToReturn.Add(objMainListFeat);
                    }
                    if (!blnFeatInList) FeatsToReturn.Add(objMainListFeat);
                }
                else FeatsToReturn.Add(objMainListFeat);
                //{
                //    // We have multiple need to count
                //    FeatsToReturn.Add(objMainListFeat);

                //}
            }

            return FeatsToReturn;
        }

        /// <summary>
        /// Checks the feat count.
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <param name="objListFeats">The object list feats.</param>
        /// <returns></returns>
        static public bool CheckFeatCount(Feat objFeat, List<Feat> objListFeats)
        {
            bool blnReturnVal = true;
            int intFeatCount = 0;

            foreach(Feat objListFeat in objListFeats )
            {
                if (objListFeat == objFeat) intFeatCount++;
            }

            if (intFeatCount + 1 <= objFeat.MultipleSelection) blnReturnVal = true; else blnReturnVal = false;

            return blnReturnVal;
        }

        /// <summary>
        /// Gets all feats character qualifed for.
        /// </summary>
        /// <param name="objChar">The object character.</param>
        /// <returns></returns>
        static public List<Feat> GetAllFeatsCharacterQualifedFor(Character objChar)
        {
            List<Feat> allFeatsCharQualifiedFor = new List<Feat>();
            List<Feat> allFeats = new List<Feat>();
            Feat objDumbFeat = new Feat();
            //allFeats = objDumbFeat.GetFeatList("Select_Feat", "FeatID IN (49,36,54) ", "FeatName");
            allFeats = objDumbFeat.GetFeatList("Select_Feat", "", "FeatName");

            foreach (Feat objFeat in allFeats)
            {
                if (objChar.QualifiedForFeat(objFeat)) allFeatsCharQualifiedFor.Add(objFeat);
            }

            return allFeatsCharQualifiedFor;
        }

        /// <summary>
        /// Determines whether [is feat in list] [the specified object feat].
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <param name="lstFeat">The LST feat.</param>
        /// <returns></returns>
        static public bool IsFeatInList(Feat objFeat, List<Feat> lstFeat)
        {
            bool blnFeatFound = false;

            foreach(Feat lstObjFeat in lstFeat)
            {
                if (objFeat.FeatID == lstObjFeat.FeatID )
                {
                    blnFeatFound = true;
                }
            }

            return blnFeatFound;
        }

        /// <summary>
        /// Determines whether [is feat in list] [the specified LST need feats].
        /// </summary>
        /// <param name="lstNeedFeats">The LST need feats.</param>
        /// <param name="lstFeats">The LST feats.</param>
        /// <returns></returns>
        static public bool IsFeatInList(List<Feat> lstNeedFeats, List<Feat> lstFeats)
        {
            bool blnAllFeatsFound = true;
            bool blnFeatFound = false;

            foreach (Feat objNeededFeat in lstNeedFeats)
            {
                blnFeatFound = false;

                foreach (Feat objFeat in lstFeats)
                {
                   if (objNeededFeat.FeatID == objFeat.FeatID)
                    {
                        blnFeatFound = true;
                    }
                }

                if (blnAllFeatsFound)
                {
                    if (!blnFeatFound) blnAllFeatsFound = blnFeatFound;
                }
            }

           
            return blnAllFeatsFound;
        }

        /// <summary>
        /// Determines whether [is feat rage required] [the specified object feat].
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <param name="blnCharHasRage">if set to <c>true</c> [BLN character has rage].</param>
        /// <returns></returns>
        static public bool IsFeatRageRequired (Feat objFeat, bool blnCharHasRage)
        {
            bool blnIsRageQualified = false;
            if (objFeat.RageRequired)
            {
                if (blnCharHasRage)
                {
                    blnIsRageQualified = true;
                }
            }
            else
            {
                blnIsRageQualified = true;
            }
            return blnIsRageQualified;
        }

        /// <summary>
        /// Determines whether [is feat shape shift required] [the specified object feat].
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <param name="blnCharHasShapeShift">if set to <c>true</c> [BLN character has shape shift].</param>
        /// <returns></returns>
        static public bool IsFeatShapeShiftRequired(Feat objFeat, bool blnCharHasShapeShift)
        {
            bool blnIsShapeShiftQualified = false;
            if (objFeat.ShapeShiftRequired)
            {
                if (blnCharHasShapeShift)
                {
                    blnIsShapeShiftQualified = true;
                }
            }
            else
            {
                blnIsShapeShiftQualified = true;
            }
            return blnIsShapeShiftQualified;
        }

        /// <summary>
        /// Determines whether [is feat dark side required] [the specified object feat].
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <param name="objChar">The object character.</param>
        /// <returns></returns>
        static public bool IsFeatDarkSideRequired(Feat objFeat, Character  objChar)
        {
            bool blnIsDarkSideQualified = false;
            if ((objFeat.objFeatPrerequisiteDarkSide.DarkSideScore > 0 ) )  //|| (objFeat.objFeatPrerequisiteDarkSide.TotalDarkSide  != null)
            {
                //Check them both one at a time
                if (objFeat.objFeatPrerequisiteDarkSide.TotalDarkSide)
                {
                    foreach (CharacterAbility objCharAbility in objChar.lstCharacterAbilities )
                    {
                        if (objCharAbility.objAbility.AbilityName.ToLower() == "wisdom")
                        {
                            if (objCharAbility.Score == objChar.DarkSidePoints) blnIsDarkSideQualified = true; else blnIsDarkSideQualified = false;
                        }
                    }
                }
                else
                {
                     if (objChar.DarkSidePoints >= objFeat.objFeatPrerequisiteDarkSide.DarkSideScore )
                     {
                         blnIsDarkSideQualified = true;
                     }
                     else
                     {
                         blnIsDarkSideQualified = false;
                     }
                }
            }
            else
            {
                blnIsDarkSideQualified = true;
            }
            return blnIsDarkSideQualified;
        }

        /// <summary>
        /// Clones the specified object feat.
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <returns>Feat</returns>
        static public Feat Clone (Feat objFeat)
        {
            Feat objCFeat = new Feat(objFeat.FeatID);
            return objCFeat;
        }

        /// <summary>
        /// Clones the specified LST feat.
        /// </summary>
        /// <param name="lstFeat">The LST feat.</param>
        /// <returns>List<Feat></returns>
        static public List<Feat> Clone(List<Feat> lstFeat)
        {
            List<Feat> lstCFeat = new List<Feat>();

            foreach (Feat objFeat in lstFeat)
            {
                lstCFeat.Add(Feat.Clone(objFeat));
            }

            return lstCFeat;
        }

        static public bool FeatOrConditionsMeet(Character objChar, Feat objFeat)
        {
            bool returnVal = false;
            List<FeatPrereqORCondition> lstFPORCond = new List<FeatPrereqORCondition>();
            FeatPrereqORCondition objFPORCond = new FeatPrereqORCondition();


            List<Talent> lstORTalents = new List<Talent>();
            List<Feat> lstORFeats = new List<Feat>();
            List<Race> lstORRaces = new List<Race>();
            List<TalentTalentTreeRequirement> lstORTalentTrees = new List<TalentTalentTreeRequirement>();
            List<TalentAbilityRequirement> lstORAbility = new List<TalentAbilityRequirement>();
            List<Skill> lstORSkill = new List<Skill>();

            lstFPORCond = objFPORCond.GetFeatPrereqORConditions(objFeat.FeatID);

            if (lstFPORCond.Count == 0) returnVal = true;
            else
            {
                foreach (FeatPrereqORCondition objOrCond in lstFPORCond)
                {
                    if (objOrCond.FeatRequirementID != 0)
                    {
                        Feat objFR = new Feat();
                        objFR.GetFeat(objOrCond.FeatRequirementID);
                        lstORFeats.Add(objFR);
                    }
                    if (objOrCond.TalentID  != 0)
                    {
                        Talent objTalent = new Talent();
                        objTalent.GetTalent(objOrCond.TalentID );
                        lstORTalents.Add(objTalent);
                    }
                    if (objOrCond.RaceID != 0)
                    {
                        Race objRace = new Race();
                        objRace.GetRace(objOrCond.RaceID);
                        lstORRaces.Add(objRace);
                    }
                    if (objOrCond.TalentTreeID != 0)
                    {
                        TalentTalentTreeRequirement objTTTR = new TalentTalentTreeRequirement();
                        objTTTR.TalentTreeID = objOrCond.TalentTreeID;
                        objTTTR.TalentTreeTalentQuantity = objOrCond.TalentTreeTalentQuantity;
                        lstORTalentTrees.Add(objTTTR);
                    }
                    if (objOrCond.AbilityID != 0)
                    {
                        TalentAbilityRequirement objTAR = new TalentAbilityRequirement();
                        objTAR.AbilityID = objOrCond.AbilityID;
                        objTAR.AbilityMinium = objOrCond.AbilityMinimum;
                        lstORAbility.Add(objTAR);
                    }
                    if (objOrCond.SkillID != 0)
                    {
                        Skill objSkill = new Skill();
                        objSkill.GetSkill(objOrCond.SkillID);
                        lstORSkill.Add(objSkill);
                    }
                }

                //Got all the lists full, have to check to see if the character has ANY of these, if they do then we jump out and are done
                //Talent
                bool blnTalentFound = false;
                foreach (Talent objSearchTalent in lstORTalents)
                {
                    if (Talent.IsTalentInList(objSearchTalent, objChar.lstTalents))
                    {
                        blnTalentFound = true;
                    }
                }

                if (blnTalentFound) return blnTalentFound;

                //Feat
                bool blnFeatFound = false;
                foreach (Feat objSearchFeat in lstORFeats)
                {
                    if (Feat.IsFeatInList(objSearchFeat, objChar.lstFeats))
                    {
                        blnFeatFound = true;
                    }
                }

                if (blnFeatFound) return blnFeatFound;

                //Race
                bool blnRaceFound = false;
                foreach (Race objSearchRace in lstORRaces)
                {
                    if (objSearchRace.RaceID == objChar.RaceID)
                    {
                        blnRaceFound = true;
                    }
                }

                if (blnRaceFound) return blnRaceFound;

                //TalentTree talents (Has x number of talents in a particular tree
                bool blnTalentTreeQuantityFound = false;
                foreach (Talent objSearchTalent in lstORTalents)
                {
                    if (Talent.IsTalentInList(objSearchTalent, objChar.lstTalents)) blnTalentTreeQuantityFound = true;
                }

                if (blnTalentTreeQuantityFound) return blnTalentTreeQuantityFound;


                //Ability
                bool blnAbilityFound = false;
                foreach (TalentAbilityRequirement objSearchAbility in lstORAbility)
                {
                    if (Ability.AblityRequirementMet(objSearchAbility.AbilityID, objSearchAbility.AbilityMinium, objChar)) blnAbilityFound = true;
                }

                if (blnTalentTreeQuantityFound) return blnAbilityFound;

                //public int SkillID { get; set; }
                //Race
                bool blnSkillFound = false;
                foreach (Skill objSearchSkill in lstORSkill)
                {
                    if (CharacterSkill.IsSkillInList(objSearchSkill, objChar.lstCharacterSkills)) blnSkillFound = true;
                }

                if (blnSkillFound) return blnSkillFound;
            }

            //went thru everything, nothing found return false;
            return returnVal;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single feat.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private Feat GetSingleFeat(string sprocName, string strWhere, string strOrderBy)
        {
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sprocName;
                command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
                result = command.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    SetReaderToObject(ref result);
                }
            }
            catch
            {
                Exception e = new Exception();
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this;
        }

        /// <summary>
        /// Gets the feat list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private List<Feat> GetFeatList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Feat> feats = new List<Feat>();

            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = strSprocName;
                command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
                result = command.ExecuteReader();

                while (result.Read())
                {
                    Feat objFeat = new Feat();
                    SetReaderToObject(ref objFeat, ref result);
                    feats.Add(objFeat);
                }
            }
            catch
            {
                Exception e = new Exception();
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return feats;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                this.FeatName = result.GetValue(result.GetOrdinal("FeatName")).ToString();
                this.FeatDescription = result.GetValue(result.GetOrdinal("FeatDescription")).ToString();
                this.FeatSpecial = result.GetValue(result.GetOrdinal("FeatSpecial")).ToString();
                this.RageRequired = (bool)result.GetValue(result.GetOrdinal("RageRequired"));
                this.ShapeShiftRequired = (bool)result.GetValue(result.GetOrdinal("ShapeShiftRequired"));
                this.MultipleSelection = (int)result.GetValue(result.GetOrdinal("MultipleSelection"));
                this.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                this.SkillTrainingFeat = (bool)result.GetValue(result.GetOrdinal("SkillTrainingFeat"));
                this.SkillFocusFeat = (bool)result.GetValue(result.GetOrdinal("SkillFocusFeat"));
                this.WeaponProficiencyID = (bool)result.GetValue(result.GetOrdinal("WeaponProficiencyID"));
                this.ArmorProficiencyID = (bool)result.GetValue(result.GetOrdinal("ArmorProficiencyID"));

                FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
                Feat objPreReqFeat = new Feat();
                BaseAttack objBaseAttack = new BaseAttack();
                Skill objSkill = new Skill();
                Race objRace = new Race();
                Class objClass = new Class();
                Size objSize = new Size();
                FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
                FeatPrereqORCondition objFeatPrereqORCondition = new FeatPrereqORCondition();

                this.objFeatPrerequisiteAbilities = objFeatPrerequisiteAbility.GetFeatPrerequisiteAbilites(" FeatID=" + this.FeatID.ToString(), "");
                this.objFeatPrerequisiteFeats = objPreReqFeat.GetFeatPrerequisiteFeats("[otmFeatPrequisiteFeat].FeatID=" + this.FeatID.ToString(), " FeatName");
                this.objBaseAttackPrerequisite = objBaseAttack.GetFeatPrequisiteBaseAttackBonus(this.FeatID);
                this.objSkillPrerequisite = objSkill.GetFeatPrerequisiteSkill(this.FeatID);
                this.objRacePrerequisite = objRace.GetFeatPrerequisiteRace(this.FeatID);
                this.objFeatPrerequisiteClasses = objClass.GetFeatPrerequisiteClass(this.FeatID);
                this.objFeatPrerequisiteSize = objSize.GetFeatPrerequisiteSize(this.FeatID);
                this.objFeatPrerequisiteDarkSide = objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSide(this.FeatID);
                this.lstFeatPrereqORConditions = objFeatPrereqORCondition.GetFeatPrereqORConditions(this.FeatID);
                this._objComboBoxData.Add(this.FeatID, this.FeatName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Feat objFeat, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objFeat.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                objFeat.FeatName = result.GetValue(result.GetOrdinal("FeatName")).ToString();
                objFeat.FeatDescription = result.GetValue(result.GetOrdinal("FeatDescription")).ToString();
                objFeat.FeatSpecial = result.GetValue(result.GetOrdinal("FeatSpecial")).ToString();
                objFeat.RageRequired = (bool)result.GetValue(result.GetOrdinal("RageRequired"));
                objFeat.ShapeShiftRequired = (bool)result.GetValue(result.GetOrdinal("ShapeShiftRequired"));
                objFeat.MultipleSelection = (int)result.GetValue(result.GetOrdinal("MultipleSelection"));
                objFeat.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                objFeat.SkillTrainingFeat = (bool)result.GetValue(result.GetOrdinal("SkillTrainingFeat"));
                objFeat.SkillFocusFeat = (bool)result.GetValue(result.GetOrdinal("SkillFocusFeat"));
                objFeat.WeaponProficiencyID = (bool)result.GetValue(result.GetOrdinal("WeaponProficiencyID"));
                objFeat.ArmorProficiencyID = (bool)result.GetValue(result.GetOrdinal("ArmorProficiencyID"));

                FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
                Feat objPreReqFeat = new Feat();
                BaseAttack objBaseAttack = new BaseAttack();
                Skill objSkill = new Skill();
                Race objRace = new Race();
                Class objClass = new Class();
                Size objSize = new Size();
                FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
                FeatPrereqORCondition objFeatPrereqORCondition = new FeatPrereqORCondition();

                objFeat.objFeatPrerequisiteAbilities = objFeatPrerequisiteAbility.GetFeatPrerequisiteAbilites(" FeatID=" + objFeat.FeatID.ToString(), "");
                objFeat.objFeatPrerequisiteFeats = objPreReqFeat.GetFeatPrerequisiteFeats(" [otmFeatPrequisiteFeat].FeatID=" + objFeat.FeatID.ToString(), " FeatName");
                objFeat.objBaseAttackPrerequisite = objBaseAttack.GetFeatPrequisiteBaseAttackBonus(objFeat.FeatID);
                objFeat.objSkillPrerequisite = objSkill.GetFeatPrerequisiteSkill(objFeat.FeatID);
                objFeat.objFeatPrerequisiteClasses = objClass.GetFeatPrerequisiteClass(objFeat.FeatID);
                objFeat.objRacePrerequisite = objRace.GetFeatPrerequisiteRace(objFeat.FeatID);
                objFeat.objFeatPrerequisiteSize = objSize.GetFeatPrerequisiteSize(objFeat.FeatID);
                objFeat.objFeatPrerequisiteDarkSide = objFeatPrerequisiteDarkSide.GetFeatPrerequisiteDarkSide(objFeat.FeatID);
                objFeat.lstFeatPrereqORConditions = objFeatPrereqORCondition.GetFeatPrereqORConditions(objFeat.FeatID);

                objFeat._objComboBoxData.Add(objFeat.FeatID, objFeat.FeatName);
            }
        }
        #endregion
        #endregion
    }
}
