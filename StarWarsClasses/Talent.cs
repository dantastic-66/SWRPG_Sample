using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class Talent:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the talent identifier.
        /// </summary>
        /// <value>
        /// The talent identifier.
        /// </value>
        public int TalentID { get; set; }
        /// <summary>
        /// Gets or sets the name of the talent.
        /// </summary>
        /// <value>
        /// The name of the talent.
        /// </value>
        public string TalentName { get; set; }
        /// <summary>
        /// Gets or sets the talent description.
        /// </summary>
        /// <value>
        /// The talent description.
        /// </value>
        public string TalentDescription { get; set; }
        /// <summary>
        /// Gets or sets the talent special.
        /// </summary>
        /// <value>
        /// The talent special.
        /// </value>
        public string TalentSpecial { get; set; }
        /// <summary>
        /// Gets or sets the talent tree identifier.
        /// </summary>
        /// <value>
        /// The talent tree identifier.
        /// </value>
        public int TalentTreeID { get; set; }
        /// <summary>
        /// Gets or sets the turn segment identifier.
        /// </summary>
        /// <value>
        /// The turn segment identifier.
        /// </value>
        public int TurnSegmentID { get; set; }
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
        /// <summary>
        /// Gets or sets the object turn segment.
        /// </summary>
        /// <value>
        /// The object turn segment.
        /// </value>
        public TurnSegment objTurnSegment { get; set; }


        /// <summary>
        /// Gets or sets the object prerequsite talent.
        /// </summary>
        /// <value>
        /// The object prerequsite talent.
        /// </value>
        public List<Talent> objPrerequsiteTalent { get; set; }
        /// <summary>
        /// Gets or sets the object talent prerequiste ability.
        /// </summary>
        /// <value>
        /// The object talent prerequiste ability.
        /// </value>
        public List<TalentPrerequisteAbility> objTalentPrerequisteAbility { get; set; }
        /// <summary>
        /// Gets or sets the object talent prerequsite skill.
        /// </summary>
        /// <value>
        /// The object talent prerequsite skill.
        /// </value>
        public List<Skill> objTalentPrerequsiteSkill { get; set; }
        /// <summary>
        /// Gets or sets the object talent prerequsite feat.
        /// </summary>
        /// <value>
        /// The object talent prerequsite feat.
        /// </value>
        public List<Feat> objTalentPrerequsiteFeat { get; set; }
        /// <summary>
        /// Gets or sets the object talent prerequiste force power.
        /// </summary>
        /// <value>
        /// The object talent prerequiste force power.
        /// </value>
        public List<ForcePower> objTalentPrerequisteForcePower { get; set; }
        /// <summary>
        /// Gets or sets the object base attack prerequisite.
        /// </summary>
        /// <value>
        /// The object base attack prerequisite.
        /// </value>
        public BaseAttack objBaseAttackPrerequisite {get; set;} 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        public Talent()
        {
            SetBaseConstructorOptions();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        /// <param name="TalentName">Name of the Talent.</param>
        public Talent(string TalentName)
        {
            SetBaseConstructorOptions();
            GetTalent(TalentName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        /// <param name="TalentID">The Talent identifier.</param>
        public Talent(int TalentID)
        {
            SetBaseConstructorOptions();
            GetTalent(TalentID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the talent.
        /// </summary>
        /// <param name="TalentID">The talent identifier.</param>
        /// <returns>Talent object</returns>
        public Talent GetTalent(int TalentID)
        {
            return GetSingleTalent("Select_Talent", "  TalentID=" + TalentID.ToString(), "");
        }

        /// <summary>
        /// Gets the talent.
        /// </summary>
        /// <param name="TalentName">Name of the talent.</param>
        /// <returns>Talent object</returns>
        public Talent GetTalent(string TalentName)
        {
            return GetSingleTalent("Select_Talent", "  TalentName='" + TalentName +"'", "");
        }

        /// <summary>
        /// Gets the tree talents.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Talent objects</returns>
        public List<Talent> GetTreeTalents(string strWhere, string strOrderBy)
        {
            return GetTalentList("Select_TalentTreeTalent", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the talents.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Talent objects</returns>
        public List<Talent> GetTalents(string strWhere, string strOrderBy)
        {
            return GetTalentList("Select_Talent", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the prestige required talents.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Talent objects</returns>
        public List<Talent> GetPrestigeRequiredTalents(string strWhere, string strOrderBy)
        {
            return GetTalentList("Select_PrestigeRequiredTalents", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the prerequiste talents.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Talent objects</returns>
        public List<Talent> GetPrerequisteTalents(string strWhere, string strOrderBy)
        {
            return GetTalentList("Select_PrerequisteTalents", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the character talents.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns></returns>
        public List<Talent> GetCharacterTalents(int CharacterID)
        {
            return GetTalentList("Select_CharacterTalents", "CharacterID=" + CharacterID.ToString(), "TalentName");
        }


        /// <summary>
        /// Saves the talent.
        /// </summary>
        /// <returns>Talent object</returns>
        public Talent SaveTalent()
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
                command.CommandText = "InsertUpdate_Talent";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentID", SqlDbType.Int, TalentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeID", SqlDbType.Int, TalentTreeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentName", SqlDbType.VarChar, TalentName.ToString(), 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentDescription", SqlDbType.VarChar, TalentDescription.ToString(), 4000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentSpecial", SqlDbType.VarChar, TalentSpecial.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TurnSegmentID", SqlDbType.Int, TurnSegmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@MultipleSelection", SqlDbType.Int, MultipleSelection.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookID", SqlDbType.Int, BookID.ToString(), 0));
                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK = false;
                this._insertUpdateMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
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
        /// Deletes the talent.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteTalent()
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
                command.CommandText = "Delete_Talent";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentID", SqlDbType.Int, TalentID.ToString(), 0));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
                //throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this.DeleteOK;
        }

        /// <summary>
        /// Deletes the character talents.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="TalentID">The talent identifier.</param>
        /// <returns>boolean</returns>
        public bool DeleteCharacterTalent(int CharacterID, int TalentID)
        {
            //bool blnDeleteOK = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_CharacterTalent";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentID", SqlDbType.Int, TalentID.ToString(), 0));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                //blnDeleteOK = false;
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            //return blnDeleteOK;
            return this.DeleteOK;
        }

        /// <summary>
        /// Saves the character talents.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="TalentID">The talent identifier.</param>
        /// <returns></returns>
        public Talent SaveCharacterTalent(int CharacterID, int TalentID)
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
                command.CommandText = "InsertUpdate_CharacterTalent";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentID", SqlDbType.Int, TalentID.ToString(), 0));
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
            return GetCharacterTalent("CharacterID=" + CharacterID.ToString() + " AND otmCharacterTalent.TalentID=" + TalentID.ToString(), "TalentName");

        }

        /// <summary>
        /// Saves a List of Feats to a Character.
        /// </summary>
        /// <param name="lstCharFeat">A <List> of Feats .</param>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <returns></returns>
        public void SaveCharacterTalents(List<Talent> lstCharTalent, int intCharacterID)
        {
            //Once a Talent is added it cannot be removed, or updated, just add the new ones
            //Talent objDelTalent = new Talent();
            //objDelTalent.DeleteCharacterTalent(intCharacterID, 0);

            foreach (Talent objCharTalent in lstCharTalent)
            {
                objCharTalent.SaveCharacterTalent (intCharacterID, objCharTalent.TalentID);
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.TalentName))
            {
                this._validated = false;
                this._validationMessage.Append("The Talent Name cannot be blank or null.");
            }
            return this.Validated;
        }
        #endregion

        #region Static_Methods
        /// <summary>
        /// Determines whether objTalent is allowable for a List of Talents (Multi-selection).
        /// </summary>
        /// <param name="objTalent">A Talent object.</param>
        /// <param name="lstTalent">The list of Talents to be searched.</param>
        /// <returns>boolean</returns>
        static public bool TalentAllowableByTalentList(Talent objTalent, List<Talent> lstTalents)
        {
            bool blnReturn = false;
            int intTalentCount = 0;

            //If its not a multiple select talent then 
            if (objTalent.MultipleSelection == 0)
            {
                if (!Talent.IsTalentInList(objTalent, lstTalents))
                {
                    blnReturn = true;
                }
            }
            else
            {
                //Multiple selection
                intTalentCount = TalentCountInList(objTalent, lstTalents);
                if (intTalentCount < objTalent.MultipleSelection) blnReturn = true;

            }

            ////if true determine if we meet prereq for it.
            //if (blnReturn )
            //{
            //    blnReturn = objChar.QualifiedForTalent(objTalent);
            //}
            return blnReturn;
        }


        /// <summary>
        /// Determines whether objTalent is contained in lstTalent.
        /// </summary>
        /// <param name="objTalent">A Talent object.</param>
        /// <param name="lstTalent">The list of Talents to be searched.</param>
        /// <returns>boolean</returns>
        static public bool IsTalentInList(Talent objTalent, List<Talent> lstTalent)
        {
            bool blnTalentFound = false;

            foreach (Talent lstObjTalent in lstTalent)
            {
                if (objTalent.TalentID == lstObjTalent.TalentID)
                {
                    blnTalentFound = true;
                }
            }

            return blnTalentFound;
        }

        /// <summary>
        /// Clones the specified object Talent.
        /// </summary>
        /// <param name="objTalent">The object Talent.</param>
        /// <returns>Talent</returns>
        static public Talent Clone(Talent objTalent)
        {
            Talent objCTalent = new Talent(objTalent.TalentID);
            return objCTalent;
        }

        /// <summary>
        /// Clones the specified LST Talent.
        /// </summary>
        /// <param name="lstTalent">The LST Talent.</param>
        /// <returns>List<Talent></returns>
        static public List<Talent> Clone(List<Talent> lstTalent)
        {
            List<Talent> lstCTalent = new List<Talent>();

            foreach (Talent objTalent in lstTalent)
            {
                lstCTalent.Add(Talent.Clone(objTalent));
            }

            return lstCTalent;
        }

        /// <summary>
        /// Determines whether the list of needed talents lstNeedTalents is in the lstTalents parameter.
        /// </summary>
        /// <param name="lstNeedTalents">This list of required Talents</param>
        /// <param name="lstTalents">The list of Talents to be searched.</param>
        /// <returns>boolean</returns>
        static public bool IsTalentInList(List<Talent> lstNeedTalents, List<Talent> lstTalents)
        {
            bool blnAllTalentsFound = true;
            bool blnTalentFound = false;

            foreach (Talent objNeededTalent in lstNeedTalents)
            {
                blnTalentFound = false;
                foreach (Talent objTalent in lstTalents)
                {
                    if (objNeededTalent.TalentID == objTalent.TalentID)
                    {
                        blnTalentFound = true;
                    }
                }
                if (!blnTalentFound) blnAllTalentsFound = false;
                //else
                //{
                //    if (blnAllTalentsFound)
                //    {
                //        blnAllTalentsFound = blnTalentFound;
                //    }
                //}
            }

            return blnAllTalentsFound;
        }

        /// <summary>
        /// Determines the number of objTalents contained in lstTalent.
        /// </summary>
        /// <param name="objTalent">A Talent object.</param>
        /// <param name="lstTalent">The list of Talents to be searched.</param>
        /// <returns>Integer</returns>
        static public int TalentCountInList (Talent objTalent, List<Talent> lstTalents)
        {
            int returnCount = 0;

            foreach (Talent objT in lstTalents )
            {
                if (objTalent.TalentID == objT.TalentID) returnCount++;
            }

            return returnCount;
        }

        #region Public Static Methods
        static public bool TalentOrConditionsMeet(Character objChar, Talent objTalent)
        {
            bool returnVal = false;
            List<TalentPrereqORCondition> lstTPORCond = new List<TalentPrereqORCondition>();
            TalentPrereqORCondition objTPORCond = new TalentPrereqORCondition();

           
            List<Talent> lstORTalentReqs = new List<Talent> ();
            List<Feat> lstORFeats = new List<Feat>();
            List<Race> lstORRaces = new List<Race>();
            List<TalentTalentTreeRequirement> lstORTalentTrees = new List<TalentTalentTreeRequirement>();
            List<TalentAbilityRequirement> lstORAbility = new List<TalentAbilityRequirement>();
            List<Skill> lstORSkill = new List<Skill>();

            lstTPORCond = objTPORCond.GetTalentPrereqORConditions(objTalent.TalentID);

        //          public int TalentPrereqOR { get; set; }   --ID for Record Row
        //public int TalentID { get; set; }                         -- ID of talent we are dealing with
        //public int TalentRequirementID { get; set; }      --Talent as prereq for TalentID
        //public int FeatID { get; set; }
        //public int RaceID { get; set; }
        //public int TalentTreeID { get; set; }
        //public int TalentTreeTalentQuantity { get; set; }
        //public int AbilityID { get; set; }
        //public int AbilityMinimum { get; set; }
        //public int SkillID { get; set; }
            if (lstTPORCond.Count == 0) returnVal = true;
            else
            {
                foreach (TalentPrereqORCondition objOrCond in lstTPORCond)
                {
                    if (objOrCond.TalentRequirementID != 0)
                    {
                        Talent objTR = new Talent();
                        objTR.GetTalent(objOrCond.TalentRequirementID);
                        lstORTalentReqs.Add(objTR);
                    }
                    if (objOrCond.FeatID != 0)
                    {
                        Feat objFeat = new Feat();
                        objFeat.GetFeat(objOrCond.FeatID);
                        lstORFeats.Add(objFeat);
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
                foreach (Talent objSearchTalent in lstORTalentReqs)
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
                foreach (Talent objSearchTalent in lstORTalentReqs)
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
        //static public List <Talent> ReturnCharacterSelectableTalents(List<Talent> lstTalents, Character objChar)
        //{
        //    List<Talent> lstReturnTalents = new List<Talent>();
        //    bool isTalentAlreadyInCharacter = false;

        //    foreach(Talent objTalent in lstTalents )
        //    {
        //        isTalentAlreadyInCharacter = Talent.IsTalentInList(objTalent, objChar.objTalents);
        //    }

        //    return lstReturnTalents;
        //}
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the character talent.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Talent object</returns>
        private Talent GetCharacterTalent(string strWhere, string strOrderBy)
        {
            return GetSingleTalent("Select_CharacterTalents", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the single talent.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private Talent GetSingleTalent(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the talent list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>list of Talent objects</returns>
        private List<Talent> GetTalentList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Talent> talents = new List<Talent>();

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
                    Talent objTalent = new Talent();
                    SetReaderToObject(ref objTalent, ref result);
                    talents.Add(objTalent);
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
            return talents;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                this.TalentName = result.GetValue(result.GetOrdinal("TalentName")).ToString();
                this.TalentDescription = result.GetValue(result.GetOrdinal("TalentDescription")).ToString();
                this.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                this.MultipleSelection = (int)result.GetValue(result.GetOrdinal("MultipleSelection"));
                this.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                this.TalentSpecial = result.GetValue(result.GetOrdinal("TalentSpecial")).ToString();

                this._objComboBoxData.Add(this.TalentID, this.TalentName);

                TurnSegment objTurnSegment = new TurnSegment();
                if (!(this.TurnSegmentID == 0))
                {
                    objTurnSegment.GetTurnSegment(this.TurnSegmentID);
                }
                this.objTurnSegment = objTurnSegment;


                Talent objPreTalent = new Talent();
                this.objPrerequsiteTalent = objPreTalent.GetPrerequisteTalents(" otmTalentPrerequisteTalent.TalentID=" + this.TalentID.ToString(), "TalentName");
                
                //List<Ability> objPrerequisteAbility
                TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
                this.objTalentPrerequisteAbility = objTalentPrerequisteAbility.GetTalentPrerequisteAbilities("TalentID=" + this.TalentID.ToString(), "");

                Skill objSkill = new Skill();
                this.objTalentPrerequsiteSkill = objSkill.GetTalentRequiredSkills("TalentID=" + this.TalentID.ToString(), "");

                Feat objFeat = new Feat();
                this.objTalentPrerequsiteFeat = objFeat.GetTalentPrerequisiteFeats("TalentID=" + this.TalentID.ToString(), "");

                ForcePower objPreForcePower = new ForcePower();
                this.objTalentPrerequisteForcePower = objPreForcePower.GetTalentPrequisteForcePowers("TalentID=" + this.TalentID.ToString(), "");

                BaseAttack objBaseAttack = new BaseAttack();
                this.objBaseAttackPrerequisite = objBaseAttack.GetFeatPrequisiteBaseAttackBonus(this.TalentID);

              

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objTalent">The object talent.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Talent objTalent, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objTalent.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                objTalent.TalentName = result.GetValue(result.GetOrdinal("TalentName")).ToString();
                objTalent.TalentDescription = result.GetValue(result.GetOrdinal("TalentDescription")).ToString();
                objTalent.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                objTalent.MultipleSelection = (int)result.GetValue(result.GetOrdinal("MultipleSelection"));
                objTalent.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                objTalent.TalentSpecial = result.GetValue(result.GetOrdinal("TalentSpecial")).ToString();

                objTalent._objComboBoxData.Add(objTalent.TalentID, objTalent.TalentName);


                TurnSegment objTurnSegment = new TurnSegment();
                if (!(objTurnSegment.TurnSegmentID == 0))
                {
                    objTurnSegment.GetTurnSegment(this.TurnSegmentID);
                }
                objTalent.objTurnSegment = objTurnSegment;

                Talent objPreTalent = new Talent();
                objTalent.objPrerequsiteTalent = objPreTalent.GetPrerequisteTalents(" otmTalentPrerequisteTalent.TalentID=" + objTalent.TalentID.ToString(), "TalentName");

                TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
                objTalent.objTalentPrerequisteAbility = objTalentPrerequisteAbility.GetTalentPrerequisteAbilities("TalentID=" + objTalent.TalentID.ToString(), "");

                Skill objSkill = new Skill();
                objTalent.objTalentPrerequsiteSkill = objSkill.GetTalentRequiredSkills("TalentID=" + objTalent.TalentID.ToString(), "");

                Feat objFeat = new Feat();
                objTalent.objTalentPrerequsiteFeat = objFeat.GetTalentPrerequisiteFeats("TalentID=" + objTalent.TalentID.ToString(), "");

                ForcePower objPreForcePower = new ForcePower();
                objTalent.objTalentPrerequisteForcePower = objPreForcePower.GetTalentPrequisteForcePowers("TalentID=" + objTalent.TalentID.ToString(), "");

                BaseAttack objBaseAttack = new BaseAttack();
                objTalent.objBaseAttackPrerequisite = objBaseAttack.GetFeatPrequisiteBaseAttackBonus(objTalent.TalentID);
            }
        }
        #endregion
        #endregion
    }
}
public partial class TalentTalentTreeRequirement
{
    public int TalentTreeID { get; set; }
    public int TalentTreeTalentQuantity { get; set; }
}

public partial class TalentAbilityRequirement
{
    public int AbilityID { get; set; }
    public int AbilityMinium { get; set; }
}
