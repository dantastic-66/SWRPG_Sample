using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class TalentPrereqORCondition : BaseValidation
    {


        public int TalentPrereqORConditionID { get; set; }
        public int TalentID { get; set; }
        public int TalentRequirementID { get; set; }
        public int FeatID { get; set; }
        public int RaceID { get; set; }
        public int TalentTreeID { get; set; }
        public int TalentTreeTalentQuantity { get; set; }
        public int AbilityID { get; set; }
        public int AbilityMinimum { get; set; }
        public int SkillID { get; set; }

        public Talent objTalent { get; set; }
        public Talent objTalentRequirement { get; set; }
        public Feat objFeat { get; set; }
        public Race objRace { get; set; }
        public TalentTree objTalentTree { get; set; }
        public TalentPrerequisteAbility objTalentPrerequisteAbility { get; set; }
        public Skill objSkill { get; set; }

        #region Constructors
        public TalentPrereqORCondition()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TalentPrereqORCondition"/> class.
        /// </summary>
        /// <param name="TalentID">The Talent identifier.</param>
        public TalentPrereqORCondition(int TalentID)
        {
            SetBaseConstructorOptions();
            GetTalentPrereqORCondition(TalentID);
        }
   
        #endregion


        #region Methods
        public TalentPrereqORCondition GetTalentPrereqORCondition(int TalentID)
        {
            return GetSingleTalentPrereqORCondition("Select_TalentPrereqORCondition", " TalentID = " + TalentID.ToString(), "");
        }

        //public TalentPrereqORCondition GetotmTalentPrereqORCondition(string otmTalentPrereqORConditionName)
        //{
        //    return GetSingleotmTalentPrereqORCondition("Select_otmTalentPrereqORCondition", " otmTalentPrereqORConditionID = " + otmTalentPrereqORConditionID.ToString(), "");
        //}

        public List<TalentPrereqORCondition> GetTalentPrereqORConditions(string strWhere, string strOrderBy)
        {
            return GetTalentPrereqORConditionList("Select_TalentPrereqORCondition", strWhere, strOrderBy);
        }

        public List<TalentPrereqORCondition> GetTalentPrereqORConditions(int TalentID)
        {
            return GetTalentPrereqORConditionList("Select_TalentPrereqORCondition", " TalentID=" + TalentID.ToString(), "");
        }

        public TalentPrereqORCondition SaveTalentPrereqORCondition()
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
            //    command.CommandText = "InsertUpdate_Defense";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseID", SqlDbType.Int, DefenseID.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterLevelArmor", SqlDbType.Int, CharacterLevelArmor.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMod", SqlDbType.Int, AbilityMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@ClassMod", SqlDbType.Int, ClassMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@RaceMod", SqlDbType.Int, RaceMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@FeatTalentMod", SqlDbType.Int, FeatTalentMod.ToString(), 0));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@MiscellaneousMod", SqlDbType.Int, MiscellaneousMod.ToString(), 0));
            //    result = command.ExecuteReader();

            //    result.Read();
            //    SetReaderToObject(ref result);

            //}
            //catch
            //{
            //    Exception e = new Exception();
            //    this._validated = false;
            //    this._validationMessage.Append(e.Message.ToString());
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
        /// Clones the specified object TalentPrereqORCondition.
        /// </summary>
        /// <param name="objTalentPrereqORCondition">The object TalentPrereqORCondition.</param>
        /// <returns>TalentPrereqORCondition</returns>
        static public TalentPrereqORCondition Clone(TalentPrereqORCondition objTalentPrereqORCondition)
        {
            TalentPrereqORCondition objCTalentPrereqORCondition = new TalentPrereqORCondition(objTalentPrereqORCondition.TalentID);
            return objCTalentPrereqORCondition;
        }

        /// <summary>
        /// Clones the specified LST TalentPrereqORCondition.
        /// </summary>
        /// <param name="lstTalentPrereqORCondition">The LST TalentPrereqORCondition.</param>
        /// <returns>List<TalentPrereqORCondition></returns>
        static public List<TalentPrereqORCondition> Clone(List<TalentPrereqORCondition> lstTalentPrereqORCondition)
        {
            List<TalentPrereqORCondition> lstCTalentPrereqORCondition = new List<TalentPrereqORCondition>();

            foreach (TalentPrereqORCondition objTalentPrereqORCondition in lstTalentPrereqORCondition)
            {
                lstCTalentPrereqORCondition.Add(TalentPrereqORCondition.Clone(objTalentPrereqORCondition));
            }

            return lstCTalentPrereqORCondition;
        }


        private TalentPrereqORCondition GetSingleTalentPrereqORCondition(string sprocName, string strWhere, string strOrderBy)
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

        private List<TalentPrereqORCondition> GetTalentPrereqORConditionList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<TalentPrereqORCondition> otmTalentPrereqORConditions = new List<TalentPrereqORCondition>();

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
                    TalentPrereqORCondition objotmTalentPrereqORCondition = new TalentPrereqORCondition();
                    SetReaderToObject(ref objotmTalentPrereqORCondition, ref result);
                    otmTalentPrereqORConditions.Add(objotmTalentPrereqORCondition);
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
            return otmTalentPrereqORConditions;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.TalentPrereqORConditionID = (int)result.GetValue(result.GetOrdinal("TalentPrereqORConditionID"));
                this.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                this.TalentRequirementID = (int)result.GetValue(result.GetOrdinal("TalentRequirementID"));
                this.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                this.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                this.TalentTreeTalentQuantity = (int)result.GetValue(result.GetOrdinal("TalentTreeTalentQuantity"));
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));
                this.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));

                if (this.TalentID != 0)
                {
                    Talent objTalent = new Talent();
                    this.objTalent = objTalent.GetTalent(this.TalentID);
                }

                if (this.TalentRequirementID != 0)
                {
                    Talent objTalentRequirement = new Talent();
                    this.objTalentRequirement = objTalent.GetTalent(this.TalentID);
                }

                if (this.FeatID != 0)
                {
                    Feat objFeat = new Feat();
                    this.objFeat = objFeat.GetFeat (this.FeatID);
                }

                if (this.RaceID != 0)
                {
                    Race objRace = new Race();
                    this.objRace = objRace.GetRace(this.FeatID);
                }

                if (this.TalentTreeID != 0)
                {
                    TalentTree objTalentTree = new TalentTree();
                    this.objTalentTree = objTalentTree.GetTalentTree(this.TalentTreeID);
                }

                if (this.AbilityID != 0)
                {
                    TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
                    this.objTalentPrerequisteAbility = objTalentPrerequisteAbility.GetTalentPrerequisteAbility(this.TalentID ,this.AbilityID);
                }

                if (this.SkillID != 0)
                {
                    Skill objSkill = new Skill();
                    this.objSkill = objSkill.GetSkill(this.SkillID);
                }
            }
        }

        private void SetReaderToObject(ref TalentPrereqORCondition objTalentPrereqORCondition, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objTalentPrereqORCondition.TalentPrereqORConditionID = (int)result.GetValue(result.GetOrdinal("TalentPrereqORConditionID"));
                objTalentPrereqORCondition.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                objTalentPrereqORCondition.TalentRequirementID = (int)result.GetValue(result.GetOrdinal("TalentRequirementID"));
                objTalentPrereqORCondition.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                objTalentPrereqORCondition.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                objTalentPrereqORCondition.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                objTalentPrereqORCondition.TalentTreeTalentQuantity = (int)result.GetValue(result.GetOrdinal("TalentTreeTalentQuantity"));
                objTalentPrereqORCondition.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objTalentPrereqORCondition.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));
                objTalentPrereqORCondition.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));

                if (objTalentPrereqORCondition.TalentID != 0)
                {
                    Talent objTalent = new Talent();
                    objTalentPrereqORCondition.objTalent = objTalent.GetTalent(objTalentPrereqORCondition.TalentID);
                }

                if (objTalentPrereqORCondition.TalentRequirementID != 0)
                {
                    Talent objTalentRequirement = new Talent();
                    objTalentPrereqORCondition.objTalentRequirement = objTalent.GetTalent(objTalentPrereqORCondition.TalentID);
                }

                if (objTalentPrereqORCondition.FeatID != 0)
                {
                    Feat objFeat = new Feat();
                    objTalentPrereqORCondition.objFeat = objFeat.GetFeat(objTalentPrereqORCondition.FeatID);
                }

                if (objTalentPrereqORCondition.RaceID != 0)
                {
                    Race objRace = new Race();
                    objTalentPrereqORCondition.objRace = objRace.GetRace(objTalentPrereqORCondition.FeatID);
                }

                if (objTalentPrereqORCondition.TalentTreeID != 0)
                {
                    TalentTree objTalentTree = new TalentTree();
                    objTalentPrereqORCondition.objTalentTree = objTalentTree.GetTalentTree(objTalentPrereqORCondition.TalentTreeID);
                }

                if (objTalentPrereqORCondition.AbilityID != 0)
                {
                    TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
                    objTalentPrereqORCondition.objTalentPrerequisteAbility = objTalentPrerequisteAbility.GetTalentPrerequisteAbility(this.TalentID, this.AbilityID);
                }

                if (objTalentPrereqORCondition.SkillID != 0)
                {
                    Skill objSkill = new Skill();
                    objTalentPrereqORCondition.objSkill = objSkill.GetSkill(objTalentPrereqORCondition.SkillID);
                }
            }
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
    }
}
