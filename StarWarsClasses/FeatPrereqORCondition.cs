using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class FeatPrereqORCondition : BaseValidation
    {


        public int FeatPrereqORConditionID { get; set; }
        public int FeatID { get; set; }
        public int TalentID { get; set; }
        public int FeatRequirementID { get; set; }
        public int RaceID { get; set; }
        public int TalentTreeID { get; set; }
        public int TalentTreeTalentQuantity { get; set; }
        public int AbilityID { get; set; }
        public int AbilityMinimum { get; set; }
        public int SkillID { get; set; }


        public Talent objTalent { get; set; }
        public Feat objFeatRequirement { get; set; }
        public Race objRace { get; set; }
        public TalentTree objTalentTree { get; set; }
        public Ability objAbility { get; set; }
        public Skill objSkill { get; set; }

        #region Constructors
        public FeatPrereqORCondition()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatPrereqORCondition"/> class.
        /// </summary>
        /// <param name="FeatPrereqORConditionID">The FeatPrereqORCondition identifier.</param>
        public FeatPrereqORCondition(int FeatPrereqORConditionID)
        {
            SetBaseConstructorOptions();
            GetFeatPrereqORCondition(FeatPrereqORConditionID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public FeatPrereqORCondition GetFeatPrereqORCondition(int FeatPrereqORConditionID)
        {
            return GetSingleFeatPrereqORCondition("Select_FeatPrereqORCondition", " FeatPrereqORConditionID = " + FeatPrereqORConditionID.ToString(), "");
        }

        public List<FeatPrereqORCondition> GetFeatPrereqORConditions(string strWhere, string strOrderBy)
        {
            return GetFeatPrereqORConditionList("Select_FeatPrereqORCondition", strWhere, strOrderBy);
        }

        public List<FeatPrereqORCondition> GetFeatPrereqORConditions(int  FeatID)
        {
            return GetFeatPrereqORConditionList("Select_FeatPrereqORCondition", " FeatID = " +FeatID.ToString() ,"");
        }

        public FeatPrereqORCondition SaveFeatPrereqORCondition()
        {
            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "InsertUpdate_FeatPrereqORCondition";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@FeatPrereqORConditionID", SqlDbType.Int, FeatPrereqORConditionID.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterLevelArmor", SqlDbType.Int, CharacterLevelArmor.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMod", SqlDbType.Int, AbilityMod.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@ClassMod", SqlDbType.Int, ClassMod.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@RaceMod", SqlDbType.Int, RaceMod.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@FeatTalentMod", SqlDbType.Int, FeatTalentMod.ToString(), 0));
            //    //    command.Parameters.Add(dbconn.GenerateParameterObj("@MiscellaneousMod", SqlDbType.Int, MiscellaneousMod.ToString(), 0));

            //    result = command.ExecuteReader();

            //    result.Read();
            //    SetReaderToObject(ref result);

            //}
            //catch
            //{
            //    Exception e = new Exception();
            //    this._insertUpdateOK = false;
            //    this._insertUpdateMessage.Append(e.Message.ToString());
            //    throw e;
            //}
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
            return this;
        }

        /// <summary>
        /// Delete the FeatPrereqORCondition.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteFeatPrereqORCondition()
        {
            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "Delete_FeatPrereqORCondition";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@FeatPrereqORConditionID", SqlDbType.Int, FeatPrereqORConditionID.ToString(), 0));
            //    result = command.ExecuteReader();
            //}
            //catch
            //{
            //    Exception e = new Exception();
            //    this._deleteOK = false;
            //    this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
            //    throw e;
            //}
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
            return this.DeleteOK;
        }

        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            //if (string.IsNullOrEmpty(this.WeaponName))
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Weapon Name cannot be blank or null.");
            //}
            return this.Validated;
        }
        #endregion

        #region Private Methods
        private FeatPrereqORCondition GetSingleFeatPrereqORCondition(string sprocName, string strWhere, string strOrderBy)
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

        private List<FeatPrereqORCondition> GetFeatPrereqORConditionList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<FeatPrereqORCondition> FeatPrereqORConditions = new List<FeatPrereqORCondition>();

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
                    FeatPrereqORCondition objFeatPrereqORCondition = new FeatPrereqORCondition();
                    SetReaderToObject(ref objFeatPrereqORCondition, ref result);
                    FeatPrereqORConditions.Add(objFeatPrereqORCondition);
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
            return FeatPrereqORConditions;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.FeatPrereqORConditionID = (int)result.GetValue(result.GetOrdinal("FeatPrereqORConditionID"));
                this.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                this.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                this.FeatRequirementID = (int)result.GetValue(result.GetOrdinal("FeatRequirementID"));
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                this.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                this.TalentTreeTalentQuantity = (int)result.GetValue(result.GetOrdinal("TalentTreeTalentQuantity"));
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));
                this.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));

                Talent objT = new Talent(this.TalentID);
                this.objTalent = objT;

                Feat objF = new Feat(this.FeatRequirementID );
                this.objFeatRequirement = objF;

                Race objR = new Race(this.RaceID);
                this.objRace = objR;

                TalentTree objTT = new TalentTree(this.TalentTreeID);
                this.objTalentTree = objTT;

                Ability objA = new Ability(this.AbilityID);
                this.objAbility = objA;

                Skill objS = new Skill(this.SkillID);
                this.objSkill = objS; 

            }
        }

        private void SetReaderToObject(ref FeatPrereqORCondition objFeatPrereqORCondition, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objFeatPrereqORCondition.FeatPrereqORConditionID = (int)result.GetValue(result.GetOrdinal("FeatPrereqORConditionID"));
                objFeatPrereqORCondition.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                objFeatPrereqORCondition.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                objFeatPrereqORCondition.FeatRequirementID = (int)result.GetValue(result.GetOrdinal("FeatRequirementID"));
                objFeatPrereqORCondition.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                objFeatPrereqORCondition.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                objFeatPrereqORCondition.TalentTreeTalentQuantity = (int)result.GetValue(result.GetOrdinal("TalentTreeTalentQuantity"));
                objFeatPrereqORCondition.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objFeatPrereqORCondition.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));
                objFeatPrereqORCondition.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));

                Talent objT = new Talent(objFeatPrereqORCondition.TalentID);
                objFeatPrereqORCondition.objTalent = objT;

                Feat objF = new Feat(objFeatPrereqORCondition.FeatRequirementID);
                objFeatPrereqORCondition.objFeatRequirement = objF;

                Race objR = new Race(objFeatPrereqORCondition.RaceID);
                objFeatPrereqORCondition.objRace = objR;

                TalentTree objTT = new TalentTree(objFeatPrereqORCondition.TalentTreeID);
                objFeatPrereqORCondition.objTalentTree = objTT;

                Ability objA = new Ability(objFeatPrereqORCondition.AbilityID);
                objFeatPrereqORCondition.objAbility = objA;

                Skill objS = new Skill(objFeatPrereqORCondition.SkillID);
                objFeatPrereqORCondition.objSkill = objS;
            }
        }

        #endregion
        #endregion
    }
}
