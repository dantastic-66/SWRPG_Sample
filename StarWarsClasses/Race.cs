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
    public class Race:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the race identifier.
        /// </summary>
        /// <value>
        /// The race identifier.
        /// </value>
        public int RaceID { get; set; }
        /// <summary>
        /// Gets or sets the name of the race.
        /// </summary>
        /// <value>
        /// The name of the race.
        /// </value>
        public string RaceName { get; set; }
        /// <summary>
        /// Gets or sets the race description.
        /// </summary>
        /// <value>
        /// The race description.
        /// </value>
        public string RaceDescription { get; set; }
        /// <summary>
        /// Gets or sets the other description.
        /// </summary>
        /// <value>
        /// The other description.
        /// </value>
        public string OtherDescription { get; set; }
        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public string Sex { get; set;}
        /// <summary>
        /// Gets or sets a value indicating whether [rage ability].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [rage ability]; otherwise, <c>false</c>.
        /// </value>
        public  bool RageAbility {get;set;}
        /// <summary>
        /// Gets or sets a value indicating whether [shape shift ability].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [shape shift ability]; otherwise, <c>false</c>.
        /// </value>
        public bool ShapeShiftAbility {get;set;}
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Race"/> is primitive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if primitive; otherwise, <c>false</c>.
        /// </value>
        public bool Primitive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [bonus feat].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bonus feat]; otherwise, <c>false</c>.
        /// </value>
        public bool BonusFeat { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [bonus skill].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bonus skill]; otherwise, <c>false</c>.
        /// </value>
        public bool BonusSkill { get; set; }
        /// <summary>
        /// Gets or sets the average height.
        /// </summary>
        /// <value>
        /// The average height.
        /// </value>
        public decimal  AverageHeight { get; set; }
        /// <summary>
        /// Gets or sets the average weight.
        /// </summary>
        /// <value>
        /// The average weight.
        /// </value>
        public decimal AverageWeight { get; set; }
        /// <summary>
        /// Gets or sets the size identifier.
        /// </summary>
        /// <value>
        /// The size identifier.
        /// </value>
        public int SizeID { get; set; }
        /// <summary>
        /// Gets or sets the speed identifier.
        /// </summary>
        /// <value>
        /// The speed identifier.
        /// </value>
        public int SpeedID { get; set; }

        /// <summary>
        /// Gets or sets the object race ability modifiers.
        /// </summary>
        /// <value>
        /// The object race ability modifiers.
        /// </value>
        public List<RaceAbilityModifier> objRaceAbilityModifiers { get; set; }
        ///// <summary>
        ///// Gets or sets the object beginning skills.
        ///// </summary>
        ///// <value>
        ///// The object beginning skills.
        ///// </value>
        //public List<Skill> objBeginningSkills { get; set; }
        /// <summary>
        /// Gets or sets the size of the object.
        /// </summary>
        /// <value>
        /// The size of the object.
        /// </value>
        public Size objSize { get; set; }
        /// <summary>
        /// Gets or sets the object speeds.
        /// </summary>
        /// <value>
        /// The object speeds.
        /// </value>
        public List<Speed> objSpeeds { get; set; }

        public List<Feat> lstBonusFeats { get; set; }

        public List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifier { get; set; }

        public List<RaceFeatConditionalFeat> lstConditionalFeatsByFeat { get; set; }

        public List<Language> lstLanguages { get; set; }

        public List<RaceLanguage> lstRaceLanguages { get; set; }

        public List<Skill> lstRaceSkills { get; set; }

        public List<RaceSkillConditionalFeat> lstConditionalFeatsBySkill { get; set; }

        public List<Speed> lstSpeeds { get; set; }

        public List<RaceSpecialAbility> lstRaceSpecialAbilities { get; set; }
         #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Race"/> class.
        /// </summary>
        public Race()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Race"/> class.
        /// </summary>
        /// <param name="RaceName">Name of the Race.</param>
        public Race(string RaceName)
        {
            SetBaseConstructorOptions();
            GetRace(RaceName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Race"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        public Race(int RaceID)
        {
            SetBaseConstructorOptions();
            GetRace(RaceID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the race.
        /// </summary>
        /// <param name="RaceID">The race identifier.</param>
        /// <returns>Race object</returns>
        public Race GetRace(int RaceID)
        {
            return GetSingleRace("Select_Race", "  RaceID=" + RaceID.ToString(), "");
        }

        /// <summary>
        /// Gets the race.
        /// </summary>
        /// <param name="RaceName">Name of the race.</param>
        /// <returns>Race object</returns>
        public Race GetRace(string RaceName)
        {
            return GetSingleRace("Select_Race", "  RaceName='" + RaceName +"'", "");
        }

        /// <summary>
        /// Gets the race.
        /// </summary>
        /// <param name="RaceName">Name of the race.</param>
        /// <param name="RaceSex">The race sex.</param>
        /// <returns>Race object</returns>
        public Race GetRace(string RaceName, string RaceSex)
        {
            return GetSingleRace("Select_Race", "  RaceName='" + RaceName + "' AND Sex='" + RaceSex + "'", "");
        }

        /// <summary>
        /// Gets the feat prerequisite race.
        /// </summary>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns>Race object</returns>
        public Race GetFeatPrerequisiteRace(int FeatID)
        {
            return GetSingleRace("Select_FeatPrerequisiteRace", "  FeatID=" + FeatID.ToString(), "");
        }

        /// <summary>
        /// Gets the races.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Race objects</returns>
        public List<Race> GetRaces(string strWhere, string strOrderBy)
        {
            return GetRaceList("Select_Race", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the race requirement for talent tree.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Race objects</returns>
        public List<Race> GetRaceRequirementForTalentTree(string strWhere, string strOrderBy)
        {
            return GetRaceList("Select_TalentTreeRaceRequirement", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the race requirement for class.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Race objects</returns>
        public List<Race> GetRaceRequirementForClass(string strWhere, string strOrderBy)
        {
            return GetRaceList("Select_RaceClassRequirement", strWhere, strOrderBy);
        }


        /// <summary>
        /// Saves the force power descriptor.
        /// </summary>
        /// <returns>Race Object</returns>
        public Race SaveRace()
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
                command.CommandText = "InsertUpdate_Race";

                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceName", SqlDbType.VarChar, RaceName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceDescription", SqlDbType.VarChar, RaceDescription.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OtherDescription", SqlDbType.VarChar, OtherDescription.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SizeID", SqlDbType.Int, SizeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Sex", SqlDbType.Char, Sex.ToString(), 1));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RageAbility", SqlDbType.Bit, RageAbility.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ShapeShiftAbility", SqlDbType.Bit, ShapeShiftAbility.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Primitive", SqlDbType.Bit, Primitive.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BonusSkill", SqlDbType.Bit, BonusSkill.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BonusFeat", SqlDbType.Bit, BonusFeat.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AverageHeight", SqlDbType.Decimal, AverageHeight.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AverageWeight", SqlDbType.Decimal, AverageWeight.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SpeedID", SqlDbType.Int, SpeedID.ToString(), 0));
                                
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
        /// Deletes the extra class item.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteRace()
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
                command.CommandText = "Delete_Race";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
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
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.RaceName))
            {
                this._validated = false;
                this._validationMessage.Append("The Race Name cannot be blank or null.");
            }
            return this.Validated;
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Determines whether [is race in list] [the specified object race].
        /// </summary>
        /// <param name="objRace">The object race.</param>
        /// <param name="lstRace">The LST race.</param>
        /// <returns>boolean</returns>
        static public bool IsRaceInList(Race objRace, List<Race> lstRace)
        {
            bool blnRaceFound = false;

            if (lstRace.Count == 0)
            {
                blnRaceFound = true;
            }
            else
            {
                foreach (Race lstObjRace in lstRace)
                {
                    if (objRace.RaceID == lstObjRace.RaceID)
                    {
                        blnRaceFound = true;
                    }
                }
            }

            return blnRaceFound;
        }

        /// <summary>
        /// Determines whether [is race in list] [the specified LST need races].
        /// </summary>
        /// <param name="lstNeedRaces">The LST need races.</param>
        /// <param name="lstRaces">The LST races.</param>
        /// <returns>boolean</returns>
        static public bool IsRaceInList(List<Race> lstNeedRaces, List<Race> lstRaces)
        {
            bool blnAllRacesFound = true;
            bool blnRaceFound = false;

            foreach (Race objNeededRace in lstNeedRaces)
            {
                foreach (Race objRace in lstRaces)
                {
                    if (objNeededRace.RaceID == objRace.RaceID)
                    {
                        blnRaceFound = true;
                    }
                }
                if (blnAllRacesFound)
                {
                    blnAllRacesFound = blnRaceFound;
                }
            }

            return blnAllRacesFound;
        }

        /// <summary>
        /// Clones the specified object Race.
        /// </summary>
        /// <param name="objRace">The object Race.</param>
        /// <returns>Race</returns>
        static public Race Clone(Race objRace)
        {
            Race objCRace = new Race(objRace.RaceID);
            return objCRace;
        }

        /// <summary>
        /// Clones the specified LST Race.
        /// </summary>
        /// <param name="lstRace">The LST Race.</param>
        /// <returns>List<Race></returns>
        static public List<Race> Clone(List<Race> lstRace)
        {
            List<Race> lstCRace = new List<Race>();

            foreach (Race objRace in lstRace)
            {
                lstCRace.Add(Race.Clone(objRace));
            }

            return lstCRace;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single race.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Race object</returns>
        private Race GetSingleRace(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the race list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Race objects</returns>
        private List<Race> GetRaceList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Race> races = new List<Race>();

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
                    Race objRace = new Race();
                    SetReaderToObject(ref objRace, ref result);
                    races.Add(objRace);
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
            return races;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                this.RaceName = result.GetValue(result.GetOrdinal("RaceName")).ToString();
                this.RaceDescription = result.GetValue(result.GetOrdinal("RaceDescription")).ToString();
                this.OtherDescription = result.GetValue(result.GetOrdinal("OtherDescription")).ToString();
                this.Sex = result.GetValue(result.GetOrdinal("Sex")).ToString();
                this.RageAbility = (bool)result.GetValue(result.GetOrdinal("RageAbility"));
                this.ShapeShiftAbility = (bool)result.GetValue(result.GetOrdinal("ShapeShiftAbility"));
                this.Primitive = (bool)result.GetValue(result.GetOrdinal("Primitive"));
                this.BonusFeat = (bool)result.GetValue(result.GetOrdinal("BonusFeat"));
                this.BonusSkill = (bool)result.GetValue(result.GetOrdinal("BonusSkill"));
                this.AverageHeight = (decimal)result.GetValue(result.GetOrdinal("AverageHeight"));
                this.AverageWeight = (decimal)result.GetValue(result.GetOrdinal("AverageWeight"));
                this.SizeID = (int)result.GetValue(result.GetOrdinal("SizeID"));
                this.SpeedID = (int)result.GetValue(result.GetOrdinal("SpeedID"));

                List<RaceAbilityModifier> objRaceAbilityModifiers = new List<RaceAbilityModifier>();
                RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();
                Speed objSpeed = new Speed();

                if (!(this.RaceID == 0))
                {
                    objRaceAbilityModifiers = objRaceAbilityModifier.GetRaceAbilityModifiers(" RaceID=" + this.RaceID.ToString(), "");
                }
                this.objRaceAbilityModifiers = objRaceAbilityModifiers;

                List<Skill> objRaceSkills = new List<Skill>();
                Skill objSkill = new Skill();
                if (!(this.RaceID == 0))
                {
                    objRaceSkills = objSkill.GetSkillsForRace(" RaceID=" + this.RaceID.ToString(), "");
                }
                this.lstRaceSkills = objRaceSkills;

                Size objLocalSize = new Size();
                if (!(this.RaceID == 0))
                {
                    objLocalSize = objLocalSize.GetSize(this.SizeID);
                }
                this.objSize = objLocalSize;

                List<Speed> objSpeeds = new List<Speed>();
                if (!(this.SpeedID ==0))
                {
                    objSpeeds = objSpeed.GetRaceSpeeds(this.RaceID );
                }
                this.objSpeeds = objSpeeds;

                Feat objFeat = new Feat();
                lstBonusFeats = objFeat.GetBonusFeatsForRace(this.RaceID);

                RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
                lstRaceDefenseTypeModifier = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiersByRace(this.RaceID, "");

                RaceFeatConditionalFeat objRaceFeatConditionalFeat = new RaceFeatConditionalFeat();
                lstConditionalFeatsByFeat = objRaceFeatConditionalFeat.GetRaceFeatConditionalFeatsByRaceID(this.RaceID);

                RaceSkillConditionalFeat objRaceSkillConditionalFeat = new RaceSkillConditionalFeat();
                lstConditionalFeatsBySkill = objRaceSkillConditionalFeat.GetRaceSkillConditionalFeatsByRaceID(this.RaceID);

                Language objLanguage = new Language();
                lstLanguages = objLanguage.GetRaceLanguages(this.RaceID, "LanguageName");

                RaceLanguage objRaceLang = new RaceLanguage();
                lstRaceLanguages = objRaceLang.GetRaceLanguages("RaceID=" + this.RaceID.ToString(), "");

                RaceSpecialAbility objRSA = new RaceSpecialAbility();
                lstRaceSpecialAbilities = objRSA.GetRaceSpecialAbilitysByRace(this.RaceID);

                this._objComboBoxData.Add(this.RaceID , this.RaceName );

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objRace">The object race.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Race objRace, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                try
                {
                    objRace.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                    objRace.RaceName = result.GetValue(result.GetOrdinal("RaceName")).ToString();
                    objRace.RaceDescription = result.GetValue(result.GetOrdinal("RaceDescription")).ToString();
                    objRace.OtherDescription = result.GetValue(result.GetOrdinal("OtherDescription")).ToString();
                    objRace.Sex = result.GetValue(result.GetOrdinal("Sex")).ToString();
                    objRace.RageAbility = (bool)result.GetValue(result.GetOrdinal("RageAbility"));
                    objRace.ShapeShiftAbility = (bool)result.GetValue(result.GetOrdinal("ShapeShiftAbility"));
                    objRace.Primitive = (bool)result.GetValue(result.GetOrdinal("Primitive"));
                    objRace.BonusFeat = (bool)result.GetValue(result.GetOrdinal("BonusFeat"));
                    objRace.BonusSkill = (bool)result.GetValue(result.GetOrdinal("BonusSkill"));
                    objRace.AverageHeight = (decimal)result.GetValue(result.GetOrdinal("AverageHeight"));
                    objRace.AverageWeight = (decimal)result.GetValue(result.GetOrdinal("AverageWeight"));
                    objRace.SizeID = (int)result.GetValue(result.GetOrdinal("SizeID"));
                    objRace.SpeedID = (int)result.GetValue(result.GetOrdinal("SpeedID"));

                    List<RaceAbilityModifier> objRaceAbilityModifiers = new List<RaceAbilityModifier>();
                    RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();
                    Speed objSpeed = new Speed();

                    if (!(objRace.RaceID == 0))
                    {
                        objRaceAbilityModifiers = objRaceAbilityModifier.GetRaceAbilityModifiers(" RaceID=" + objRace.RaceID.ToString(), "");
                    }
                    objRace.objRaceAbilityModifiers = objRaceAbilityModifiers;

                    List<Skill> objRaceSkills = new List<Skill>();
                    Skill objSkill = new Skill();
                    if (!(objRace.RaceID == 0))
                    {
                        objRaceSkills = objSkill.GetSkillsForRace(" RaceID=" + objRace.RaceID.ToString(), "");
                    }
                    objRace.lstRaceSkills = objRaceSkills;


                    List<Speed> objSpeeds = new List<Speed>();
                    if (!(objRace.SpeedID == 0))
                    {
                        objSpeeds = objSpeed.GetRaceSpeeds(objRace.RaceID);
                    }
                    objRace.objSpeeds = objSpeeds;


                    RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
                    lstRaceDefenseTypeModifier = objRaceDefenseTypeModifier.GetRaceDefenseTypeModifiersByRace(objRace.RaceID, "");

                    RaceFeatConditionalFeat objRaceFeatConditionalFeat = new RaceFeatConditionalFeat();
                    lstConditionalFeatsByFeat = objRaceFeatConditionalFeat.GetRaceFeatConditionalFeatsByRaceID(objRace.RaceID);

                    RaceSkillConditionalFeat objRaceSkillConditionalFeat = new RaceSkillConditionalFeat();
                    lstConditionalFeatsBySkill = objRaceSkillConditionalFeat.GetRaceSkillConditionalFeatsByRaceID(objRace.RaceID);

                    Language objLanguage = new Language();
                    lstLanguages = objLanguage.GetRaceLanguages(objRace.RaceID, "");

                    RaceLanguage objRaceLang = new RaceLanguage();
                    lstRaceLanguages = objRaceLang.GetRaceLanguages("RaceID=" + objRace.RaceID.ToString(), "");

                    RaceSpecialAbility objRSA = new RaceSpecialAbility();
                    lstRaceSpecialAbilities = objRSA.GetRaceSpecialAbilitysByRace(objRace.RaceID);

                    objRace._objComboBoxData.Add(objRace.RaceID, objRace.RaceName);
                }
                catch
                {
                    Exception e = new Exception();
                    throw e;
                } 

            }
        }
        #endregion
        #endregion
 
    }
}
