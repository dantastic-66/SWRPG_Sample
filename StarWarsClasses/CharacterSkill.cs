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
    public class CharacterSkill : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        public int CharacterID { get; set; }
        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        public int SkillID{ get; set; }
        /// <summary>
        /// Gets or sets the half level.
        /// </summary>
        /// <value>
        /// The half level.
        /// </value>
        public int HalfLevel { get; set; }
        /// <summary>
        /// Gets or sets the ability mod.
        /// </summary>
        /// <value>
        /// The ability mod.
        /// </value>
        public int AbilityMod { get; set; }
        /// <summary>
        /// Gets or sets the trained.
        /// </summary>
        /// <value>
        /// The trained.
        /// </value>
        public int Trained { get; set; }
        /// <summary>
        /// Gets or sets the skill focus.
        /// </summary>
        /// <value>
        /// The skill focus.
        /// </value>
        public int SkillFocus { get; set; }
        /// <summary>
        /// Gets or sets the miscellaneous.
        /// </summary>
        /// <value>
        /// The miscellaneous.
        /// </value>       
        public int FeatTalentMod { get; set; }
        /// <summary>
        /// Gets or sets the Feat/Talent Mod.
        /// </summary>
        /// <value>
        /// The miscellaneous.
        /// </value>
        public int Miscellaneous { get; set; }

        /// <summary>
        /// Gets or sets the object skill.
        /// </summary>
        /// <value>
        /// The object skill.
        /// </value>
        public Skill objSkill { get; set; }
        #endregion 

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterSkill"/> class.
        /// </summary>
        public CharacterSkill()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterSkill"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="SkillID">The Skill identifier.</param>
        public CharacterSkill(int CharacterID, int SkillID)
        {
            SetBaseConstructorOptions();
            GetCharacterSkill(CharacterID, SkillID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the character skill.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="SkillID">The skill identifier.</param>
        /// <returns>CharacterSkill Object</returns>
        public CharacterSkill GetCharacterSkill (int CharacterID, int SkillID)
        {
            return GetSingleCharacterSkill("Select_CharacterSkill", " CharacterID=" + CharacterID.ToString() + " AND SkillID=" + SkillID.ToString(), "");
        }

        /// <summary>
        /// Gets the character skills.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of CharacterSkill Objects</returns>
        public List<CharacterSkill> GetCharacterSkills(int CharacterID)
        {
            return GetCharacterSkillList("Select_CharacterSkill", " CharacterID=" + CharacterID.ToString(), "");
        }

        /// <summary>
        /// Saves the character class level.
        /// </summary>
        /// <returns>CharacterSkill Object</returns>
        public CharacterSkill SaveCharacterSkill()
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
                command.CommandText = "InsertUpdate_CharacterSkill";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillID", SqlDbType.Int, SkillID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@HalfLevel", SqlDbType.Int, HalfLevel.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMod", SqlDbType.Int, AbilityMod.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Trained", SqlDbType.Int, Trained.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillFocus", SqlDbType.Int, SkillFocus.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Miscellaneous", SqlDbType.Int, Miscellaneous.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatTalentMod", SqlDbType.Int, FeatTalentMod.ToString(), 0));
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
        /// Delete the CharacterSkill.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterSkill()
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
                command.CommandText = "Delete_CharacterSkill";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillID", SqlDbType.Int, SkillID.ToString(), 0));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this.DeleteOK;
        }

        /// <summary>
        /// Delete the CharacterSkill.
        /// </summary>
        /// <param name="intCharacterID">The character identifier.</param>
        /// <param name="intSkillID">The skill identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterSkill(int intCharacterID, int intSkillID)
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
                command.CommandText = "Delete_CharacterSkill";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, intCharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillID", SqlDbType.Int, intSkillID.ToString(), 0));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this.DeleteOK;
        }

        /// <summary>
        /// Saves a List of Feats to a Character.
        /// </summary>
        /// <param name="lstCharFeat">A <List> of Feats .</param>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <returns></returns>
        public void SaveCharacterSkills(List<CharacterSkill> lstCharacterSkill, int intCharacterID)
        {
            //Character skills can be updated or added but not removed
            //CharacterSkill objDelCharacterSkill = new CharacterSkill();
            //objDelCharacterSkill.DeleteCharacterSkill(intCharacterID, 0);

            foreach (CharacterSkill objCharSkill in lstCharacterSkill)
            {
                objCharSkill.SaveCharacterSkill();
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;
            //All attributes cannot be zero
            if (this.SkillID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Skill ID cannot be 0.");
            }

            if ((this.AbilityMod == 0) && (this.HalfLevel == 0) && (this.Miscellaneous == 0) && (this.SkillFocus == 0) && (this.Trained == 0))
            {
                this._validated = false;
                this._validationMessage.Append("The Ability, Half Level, Miscellaneous, Skill Focus and Trained Modifiers cannot all be 0.");
            }


            return this.Validated;
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Determines whether [is skill in list] [the specified LST skill].
        /// </summary>
        /// <param name="lstSkill">The LST skill.</param>
        /// <param name="lstCharSkill">The LST character skill.</param>
        /// <returns>Boolean</returns>
        static public bool IsSkillInList(List<Skill> lstSkill, List<CharacterSkill> lstCharSkill)
        {
            bool blnSkillFound = true;
            bool blnFoundIndividual = false;
            foreach (Skill lstObjSkill in lstSkill)
            {
                blnFoundIndividual = false;
                foreach (CharacterSkill objCharSkill in lstCharSkill )
                {
                    if (lstObjSkill.SkillID == objCharSkill.SkillID )
                    {
                        blnFoundIndividual = true;
                    }
                }
                if ( blnFoundIndividual == false)
                {
                    blnSkillFound = false;
                }
            }

            return blnSkillFound;
        }

        /// <summary>
        /// Determines whether [is skill in list] [the specified object skill].
        /// </summary>
        /// <param name="objSkill">The object skill.</param>
        /// <param name="lstCharSkill">The LST character skill.</param>
        /// <returns>Boolean</returns>
        static public bool IsSkillInList(Skill objSkill, List<CharacterSkill> lstCharSkill)
        {
            bool blnSkillFound = false;
            if (objSkill.SkillID == 0)
            {
                blnSkillFound = true;
            }
            else
            {
                foreach (CharacterSkill objCharSkill in lstCharSkill)
                {
                    if (objSkill.SkillID == objCharSkill.SkillID)
                    {
                        blnSkillFound = true;
                    }
                }
            }
            return blnSkillFound;
        }

        //TODO: Unit Test
        static public bool DoesCharacterHaveSkillFocusForSkill(int SkillID, Character objChar)
        {
            bool returnVal = false;

            Skill objSkill = new Skill();
            objSkill.GetSkill(SkillID);

            foreach (Feat objFeat in objChar.lstFeats )
            {
                if (objFeat.FeatName == "Skill Focus(" + objSkill.SkillName + ")") returnVal = true; 
            }
            return returnVal;
        }

        //TODO: Unit Test
        static public bool DoesCharacterHaveSkillTrainingForSkill(int SkillID, Character objChar)
        {
            bool returnVal = false;

            Skill objSkill = new Skill();
            objSkill.GetSkill(SkillID);

            foreach (Feat objFeat in objChar.lstFeats)
            {
                if (objFeat.FeatName == "Skill Training(" + objSkill.SkillName + ")") returnVal = true;
            }
            return returnVal;
        }

        //TODO: Unit Test
        static public CharacterSkill GetCharacterSkillFromListBySkill(Skill objSkill, List<CharacterSkill> lstCharSkill)
        {
            CharacterSkill objReturnCharSkill = new CharacterSkill() ;
            foreach (CharacterSkill objCharSkill in lstCharSkill)
            {
                if (objSkill.SkillID == objCharSkill.objSkill.SkillID) objReturnCharSkill =  objCharSkill;
            }
            return objReturnCharSkill;
        }

        /// <summary>
        /// Clones the specified object CharacterSkill.
        /// </summary>
        /// <param name="objCharacterSkill">The object CharacterSkill.</param>
        /// <returns>CharacterSkill</returns>
        static public CharacterSkill Clone(CharacterSkill objCharacterSkill)
        {
            CharacterSkill objCCharacterSkill = new CharacterSkill(objCharacterSkill.CharacterID , objCharacterSkill.SkillID );
            return objCCharacterSkill;
        }

        /// <summary>
        /// Clones the specified LST CharacterSkill.
        /// </summary>
        /// <param name="lstCharacterSkill">The LST CharacterSkill.</param>
        /// <returns>List<CharacterSkill></returns>
        static public List<CharacterSkill> Clone(List<CharacterSkill> lstCharacterSkill)
        {
            List<CharacterSkill> lstCCharacterSkill = new List<CharacterSkill>();

            foreach (CharacterSkill objCharacterSkill in lstCharacterSkill)
            {
                lstCCharacterSkill.Add(CharacterSkill.Clone(objCharacterSkill));
            }

            return lstCCharacterSkill;
        }
        #endregion
 
        #region Pivate Methods
        /// <summary>
        /// Gets the single character skill.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>CharacterSkill Object</returns>
        private CharacterSkill GetSingleCharacterSkill(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the character skill list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of CharacterSkill Objects</returns>
        private List<CharacterSkill> GetCharacterSkillList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterSkill> characterSkills = new List<CharacterSkill>();

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
                    CharacterSkill objCharacterSkill = new CharacterSkill();
                    SetReaderToObject(ref objCharacterSkill, ref result);
                    characterSkills.Add(objCharacterSkill);
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
            return characterSkills;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {

            if (result.HasRows)
            {
                this.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                this.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                this.HalfLevel = (int)result.GetValue(result.GetOrdinal("HalfLevel"));
                this.AbilityMod = (int)result.GetValue(result.GetOrdinal("AbilityMod"));
                this.Trained = (int)result.GetValue(result.GetOrdinal("Trained"));
                this.SkillFocus = (int)result.GetValue(result.GetOrdinal("SkillFocus"));
                this.Miscellaneous = (int)result.GetValue(result.GetOrdinal("Miscellaneous"));
                this.FeatTalentMod = (int)result.GetValue(result.GetOrdinal("FeatTalentMod"));


                Skill objSkill = new Skill();
                this.objSkill = objSkill.GetSkill(this.SkillID);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objCharacterSkill">The object character skill.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref CharacterSkill objCharacterSkill, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objCharacterSkill.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                objCharacterSkill.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                objCharacterSkill.HalfLevel = (int)result.GetValue(result.GetOrdinal("HalfLevel"));
                objCharacterSkill.AbilityMod = (int)result.GetValue(result.GetOrdinal("AbilityMod"));
                objCharacterSkill.Trained = (int)result.GetValue(result.GetOrdinal("Trained"));
                objCharacterSkill.SkillFocus = (int)result.GetValue(result.GetOrdinal("SkillFocus"));
                objCharacterSkill.Miscellaneous = (int)result.GetValue(result.GetOrdinal("Miscellaneous"));
                objCharacterSkill.FeatTalentMod = (int)result.GetValue(result.GetOrdinal("FeatTalentMod"));

                Skill objSkill = new Skill();
                objCharacterSkill.objSkill = objSkill.GetSkill(objCharacterSkill.SkillID);
            }
        }
        #endregion
        #endregion

    }
}
