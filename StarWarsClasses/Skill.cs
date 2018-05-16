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
    public class Skill:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        public int SkillID { get; set; }
        /// <summary>
        /// Gets or sets the name of the skill.
        /// </summary>
        /// <value>
        /// The name of the skill.
        /// </value>
        public string SkillName { get; set; }
        /// <summary>
        /// Gets or sets the skill description.
        /// </summary>
        /// <value>
        /// The skill description.
        /// </value>
        public string SkillDescription { get; set; }
        /// <summary>
        /// Gets or sets the ability identifier.
        /// </summary>
        /// <value>
        /// The ability identifier.
        /// </value>
        public int AbilityID { get; set; }

        public bool TrainedSkill { get; set; }

        /// <summary>
        /// Gets or sets the SkillTrainingFeat identifier.
        /// </summary>
        /// <value>
        /// The SkillTrainingFeat identifier.
        /// </value>
        public int SkillTrainingFeatID { get; set; }

        public bool AmorProfAffected { get; set; }
        
        /// <summary>
        /// Gets or sets the sub skills.
        /// </summary>
        /// <value>
        /// The sub skills.
        /// </value>
        public List<SubSkill> SubSkills { get; set; }
        /// <summary>
        /// Gets or sets the object ability.
        /// </summary>
        /// <value>
        /// The object ability.
        /// </value>
        public Ability objAbility { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        public Skill()
        {
            SetBaseConstructorOptions();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        /// <param name="SkillName">Name of the Skill.</param>
        public Skill(string SkillName)
        {
            SetBaseConstructorOptions();
            GetSkill(SkillName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        /// <param name="SkillID">The Skill identifier.</param>
        public Skill(int SkillID)
        {
            SetBaseConstructorOptions();
            GetSkill(SkillID);
        }

        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the skill.
        /// </summary>
        /// <param name="SkillID">The skill identifier.</param>
        /// <returns>Skill object</returns>
        public Skill GetSkill(int SkillID)
        {
            return GetSingleSkill("Select_Skill", "  SkillID=" + SkillID.ToString(), ""); 
        }

        /// <summary>
        /// Gets the skill.
        /// </summary>
        /// <param name="SkillName">Name of the skill.</param>
        /// <returns>Skill object</returns>
        public Skill GetSkill(string SkillName)
        {
            return GetSingleSkill("Select_Skill", "  SkillName='" + SkillName + "'", ""); 
        }

        /// <summary>
        /// Gets the skill by the skill training ID.
        /// </summary>
        /// <param name="SkillTrainingFeatID">The Skill Training Feat Identifier for the associated Skill</param>
        /// <returns>Skill object</returns>
        public Skill GetSkillBySkillTrainingFeatID(int SkillTrainingFeatID)
        {
            return GetSingleSkill("Select_Skill", "  SkillTrainingFeatID=" + SkillTrainingFeatID.ToString(), "");
        }

        /// <summary>
        /// Gets the feat prerequisite skill.
        /// </summary>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns>Skill object</returns>
        public Skill GetFeatPrerequisiteSkill(int FeatID)
        {
            return GetSingleSkill("Select_FeatPrerequisiteSkill", "  FeatID=" + FeatID.ToString(), "");
        }

        /// <summary>
        /// Gets the skills.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Skill objects</returns>
        public List<Skill> GetSkills(string strWhere, string strOrderBy)
        {
            return GetSkillList("Select_Skill", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the character skills.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of Skill objects</returns>
        public List<Skill> GetCharacterSkills(int CharacterID)
        {
            return GetSkillList("Select_SkillCharacterSkill", "CharacterID=" + CharacterID.ToString(), "SkillName");
        }

        //TODO: TestCase for GetRaceSkill(int RaceID)
        public  List<Skill> GetRaceSkill(int RaceID)
        {
            return GetSkillList("Select_SkillRaceSkills", "RaceID=" + RaceID.ToString(), "SkillName");
        }

        ///// <summary>
        ///// Gets multiple languages by Race.
        ///// </summary>
        ///// <param name="intRaceID">The int RaceID.</param>
        ///// <param name="strOrderBy">The string order by.</param>
        ///// <returns>List of Languages</returns>
        //public List<Skill> GetRaceSkills(int intRaceID, string strOrderBy)
        //{
        //    return GetSkillList("Select_RaceSkill", " RaceID=" + intRaceID.ToString(), strOrderBy);
        //}

        //TODO: TestCase for GetCharacterSelectableSkillList(Character objChar, Class objAddedClass)
        public List<Skill> GetCharacterSelectableSkillList(Character objChar, Class objAddedClass)
        {
            //Get RaceSkills if any
            List<Skill> lstRaceSkills = new List<Skill>();
            lstRaceSkills = GetRaceSkill(objChar.RaceID);


            //Get Skills available by  Class
            string strClassIDs = objChar.CharacterClassIDs() ;
            if (objAddedClass.ClassName != null)
            {
                if (strClassIDs =="")
                {
                    strClassIDs = objAddedClass.ClassID.ToString();
                }
                else if (!strClassIDs.Contains (objAddedClass.ClassID.ToString()))
                {
                    strClassIDs = strClassIDs + "," + objAddedClass.ClassID.ToString();
                }
            }

            List<Skill> lstClassSkills = new List<Skill>();
            lstClassSkills = GetSkillList("Select_SkillByClass", "ClassID IN (" + strClassIDs + ")", "SkillName");

            if (lstRaceSkills.Count > 0)
            {
                return MergeSkillLists(lstRaceSkills, lstClassSkills, "SkillName");
            }
            else
            {
                return lstClassSkills;
            }
        }

        /// <summary>
        /// Gets the skills for race.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<Skill> GetSkillsForRace(string strWhere, string strOrderBy)
        {
            return GetSkillList("Select_SkillByRace", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the prestige required skills.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Skill objects</returns>
        public List<Skill> GetPrestigeRequiredSkills(string strWhere, string strOrderBy)
        {
            return GetSkillList("Select_PrestigeRequiredSkills", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the talent required skills.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Skill objects</returns>
        public List<Skill> GetTalentRequiredSkills(string strWhere, string strOrderBy)
        {
            return GetSkillList("Select_TalentPrerequisteSkill", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the Skills That are effected by lack of Armor Poficiency.
        /// </summary>
        /// <returns>List of Skill objects</returns>
        public List<Skill> GetArmorProfSkills()
        {
            return GetSkillList("Select_Skill", "AmorProfAffected=1", "SkillName");
        }

        /// <summary>
        /// Saves the skill.
        /// </summary>
        /// <returns>Skill object</returns>
        public Skill SaveSkill()
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
                command.CommandText = "InsertUpdate_Skill";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillID", SqlDbType.Int, SkillID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillName", SqlDbType.VarChar, SkillName.ToString(), 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillDescription", SqlDbType.VarChar, SkillDescription.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TrainedSkill", SqlDbType.Bit , TrainedSkill.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillTrainingFeatID", SqlDbType.Int, SkillTrainingFeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AmorProfAffected", SqlDbType.Bit, AmorProfAffected.ToString(), 0));


                
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
        /// Deletes the Skill item.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteSkill()
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
                command.CommandText = "Delete_Skill";
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
        /// Validates this instance.
        /// </summary>
        /// <returns>boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.SkillName))
            {
                this._validated = false;
                this._validationMessage.Append("The Skill Name cannot be blank or null.");
            }
            return this.Validated;
        }
        #endregion

        #region Static_Methods
        /// <summary>
        /// Determines whether [is skill in list] [the specified object skill].
        /// </summary>
        /// <param name="objSkill">The object skill.</param>
        /// <param name="lstSkill">The LST skill.</param>
        /// <returns>boolean</returns>
        static public bool IsSkillInList(Skill objSkill, List<Skill> lstSkill)
        {
            bool blnSkillFound = false;

            foreach (Skill lstObjSkill in lstSkill)
            {
                if (objSkill.SkillID == lstObjSkill.SkillID)
                {
                    blnSkillFound = true;
                }
            }

            return blnSkillFound;
        }

        /// <summary>
        /// Determines whether [is skill in list] [the specified LST need skills].
        /// </summary>
        /// <param name="lstNeedSkills">The LST need skills.</param>
        /// <param name="lstSkills">The LST skills.</param>
        /// <returns>boolean</returns>
        static public bool IsSkillInList(List<Skill> lstNeedSkills, List<Skill> lstSkills)
        {
            bool blnAllSkillsFound = true;
            bool blnSkillFound = false;

            foreach (Skill objNeededSkill in lstNeedSkills)
            {
                foreach (Skill objSkill in lstSkills)
                {
                    if (objNeededSkill.SkillID == objSkill.SkillID)
                    {
                        blnSkillFound = true;
                    }
                }
                if (blnAllSkillsFound)
                {
                    blnAllSkillsFound = blnSkillFound;
                }
            }

            return blnAllSkillsFound;
        }

        //TODO: TestCase for MergeSkillLists(List<Skill> lstSkillList1, List<Skill> lstSkillList2, string strSortOrder)
        static public List<Skill> MergeSkillLists(List<Skill> lstSkillList1, List<Skill> lstSkillList2, string strSortOrder)
        {
            List<Skill> lstReturnSkillList = new List<Skill>();
            lstReturnSkillList = lstSkillList1;
            foreach (Skill objSkill in lstSkillList2)
            {
                if (!IsSkillInList(objSkill, lstSkillList1))
                {
                    lstReturnSkillList.Add(objSkill);
                }
            }

            //Do order by here somehow...
            if (!String.IsNullOrEmpty(strSortOrder))
            {

                switch (strSortOrder.ToLower())
                {
                    case "skillname":
                        lstReturnSkillList = lstReturnSkillList.OrderBy(n => n.SkillName).ToList<Skill>();
                        break;
                    case "skillid":
                        lstReturnSkillList = lstReturnSkillList.OrderBy(n => n.SkillID).ToList<Skill>();
                        break;
                    case "skilldescription":
                        lstReturnSkillList = lstReturnSkillList.OrderBy(n => n.SkillDescription ).ToList<Skill>();
                        break;
                    case "abilityid":
                        lstReturnSkillList = lstReturnSkillList.OrderBy(n => n.AbilityID ).ToList<Skill>();
                        break;
                    default:
                        lstReturnSkillList = lstReturnSkillList.OrderBy(n => n.SkillName).ToList<Skill>();
                        break;
                }

            }
            return lstReturnSkillList;
        }

        /// <summary>
        /// Clones the specified object Skill.
        /// </summary>
        /// <param name="objSkill">The object Skill.</param>
        /// <returns>Skill</returns>
        static public Skill Clone(Skill objSkill)
        {
            Skill objCSkill = new Skill(objSkill.SkillID);
            return objCSkill;
        }

        /// <summary>
        /// Clones the specified LST Skill.
        /// </summary>
        /// <param name="lstSkill">The LST Skill.</param>
        /// <returns>List<Skill></returns>
        static public List<Skill> Clone(List<Skill> lstSkill)
        {
            List<Skill> lstCSkill = new List<Skill>();

            foreach (Skill objSkill in lstSkill)
            {
                lstCSkill.Add(Skill.Clone(objSkill));
            }

            return lstCSkill;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the single skill.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Skill object</returns>
        private Skill GetSingleSkill(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the skill list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Skill objects</returns>
        private List<Skill> GetSkillList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Skill> skills = new List<Skill>();

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
                    Skill objSkill = new Skill();
                    SetReaderToObject(ref objSkill, ref result);
                    skills.Add(objSkill);
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
            return skills;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                this.SkillName = result.GetValue(result.GetOrdinal("SkillName")).ToString();
                this.SkillDescription = result.GetValue(result.GetOrdinal("SkillDescription")).ToString();
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.TrainedSkill = (bool)result.GetValue(result.GetOrdinal("TrainedSkill"));
                this.SkillTrainingFeatID = (int)result.GetValue(result.GetOrdinal("SkillTrainingFeatID"));
                this.AmorProfAffected = (bool)result.GetValue(result.GetOrdinal("AmorProfAffected"));

                
                List<SubSkill> subSkills = new List<SubSkill>();
                SubSkill objSubKill = new SubSkill();
                                
                if (!(this.SkillID == 0))
                {
                    subSkills = objSubKill.GetSubSkills("SkillID="+this.SkillID.ToString(),""); 
                }
                this.SubSkills = subSkills;

                Ability objAbility = new Ability();
                if (!(this.AbilityID == 0 ))
                {
                    objAbility.GetAbility(this.AbilityID);
                }
                this.objAbility = objAbility;

                this._objComboBoxData.Add(this.SkillID, this.SkillName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objSkill">The object skill.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Skill objSkill, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objSkill.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                objSkill.SkillName = result.GetValue(result.GetOrdinal("SkillName")).ToString();
                objSkill.SkillDescription = result.GetValue(result.GetOrdinal("SkillDescription")).ToString();
                objSkill.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objSkill.TrainedSkill = (bool)result.GetValue(result.GetOrdinal("TrainedSkill"));
                objSkill.SkillTrainingFeatID = (int)result.GetValue(result.GetOrdinal("SkillTrainingFeatID"));
                objSkill.AmorProfAffected = (bool)result.GetValue(result.GetOrdinal("AmorProfAffected"));

                List<SubSkill> subSkills = new List<SubSkill>();
                SubSkill objSubKill = new SubSkill();
                
                if (!(objSkill.SkillID == 0))
                {
                    subSkills = objSubKill.GetSubSkills("SkillID=" + objSkill.SkillID.ToString(), "");
                }
                objSkill.SubSkills = subSkills;

                Ability objAbility = new Ability();
                if (!(objSkill.AbilityID == 0))
                {
                    objAbility.GetAbility(objSkill.AbilityID);
                }
                objSkill.objAbility = objAbility;

                objSkill._objComboBoxData.Add(objSkill.SkillID, objSkill.SkillName);
            }
        }
        #endregion


        #endregion
    }
}
