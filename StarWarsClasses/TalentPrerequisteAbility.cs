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
    public class TalentPrerequisteAbility:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ability identifier.
        /// </summary>
        /// <value>
        /// The ability identifier.
        /// </value>
        public int AbilityID { get; set; }
        /// <summary>
        /// Gets or sets the talent identifier.
        /// </summary>
        /// <value>
        /// The talent identifier.
        /// </value>
        public int TalentID { get; set; }
        /// <summary>
        /// Gets or sets the ability minimum.
        /// </summary>
        /// <value>
        /// The ability minimum.
        /// </value>
        public int AbilityMinimum { get; set; }

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
        /// Initializes a new instance of the <see cref="TalentPrerequisteAbility"/> class.
        /// </summary>
        public TalentPrerequisteAbility()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TalentPrerequisteAbility"/> class.
        /// </summary>
        /// <param name="TalentID">The Talent identifier.</param>
        /// <param name="AbilityID">TheAbility identifier.</param>
        public TalentPrerequisteAbility(int TalentID, int AbilityID)
        {
            SetBaseConstructorOptions();
            GetTalentPrerequisteAbility(TalentID, AbilityID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the talent prerequiste ability.
        /// </summary>
        /// <param name="TalentID">The talent identifier.</param>
        /// <param name="AbilityID">The ability identifier.</param>
        /// <returns>TalentPrerequisteAbility object</returns>
        public TalentPrerequisteAbility GetTalentPrerequisteAbility(int TalentID, int AbilityID)
        {
            return GetSingleTalentPrerequisteAbility("Select_TalentPrerequisteAbility", "  TalentID=" + TalentID.ToString() + " AND AbilityID=" + AbilityID.ToString(), "");
        }

        /// <summary>
        /// Gets the talent prerequiste abilities.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TalentPrerequisteAbility objects</returns>
        public List<TalentPrerequisteAbility> GetTalentPrerequisteAbilities(string strWhere, string strOrderBy)
        {
            return GetTalentPrerequisteAbilityList("Select_TalentPrerequisteAbility", strWhere, strOrderBy);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (this.AbilityMinimum == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Ability Minimum cannot be blank or null.");
            }
          
            return this.Validated;
        }

        /// <summary>
        /// Saves the talent prerequiste ability.
        /// </summary>
        /// <returns>TalentPrerequisteAbility object</returns>
        public TalentPrerequisteAbility SaveTalentPrerequisteAbility()
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
                command.CommandText = "InsertUpdate_TalentPrerequisteAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentID", SqlDbType.Int, TalentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMinimum", SqlDbType.Int, AbilityMinimum.ToString(), 0));
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
        /// Deletes the talent prerequiste ability.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteTalentPrerequisteAbility()
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
                command.CommandText = "Delete_TalentPrerequisteAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
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
        /// Clones the specified object TalentPrerequisteAbility.
        /// </summary>
        /// <param name="objTalentPrerequisteAbility">The object TalentPrerequisteAbility.</param>
        /// <returns>TalentPrerequisteAbility</returns>
        static public TalentPrerequisteAbility Clone(TalentPrerequisteAbility objTalentPrerequisteAbility)
        {
            TalentPrerequisteAbility objCTalentPrerequisteAbility = new TalentPrerequisteAbility(objTalentPrerequisteAbility.TalentID ,objTalentPrerequisteAbility.AbilityID );
            return objCTalentPrerequisteAbility;
        }

        /// <summary>
        /// Clones the specified LST TalentPrerequisteAbility.
        /// </summary>
        /// <param name="lstTalentPrerequisteAbility">The LST TalentPrerequisteAbility.</param>
        /// <returns>List<TalentPrerequisteAbility></returns>
        static public List<TalentPrerequisteAbility> Clone(List<TalentPrerequisteAbility> lstTalentPrerequisteAbility)
        {
            List<TalentPrerequisteAbility> lstCTalentPrerequisteAbility = new List<TalentPrerequisteAbility>();

            foreach (TalentPrerequisteAbility objTalentPrerequisteAbility in lstTalentPrerequisteAbility)
            {
                lstCTalentPrerequisteAbility.Add(TalentPrerequisteAbility.Clone(objTalentPrerequisteAbility));
            }

            return lstCTalentPrerequisteAbility;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the single talent prerequiste ability.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>TalentPrerequisteAbility object</returns>
        private TalentPrerequisteAbility GetSingleTalentPrerequisteAbility(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the talent prerequiste ability list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TalentPrerequisteAbility objects</returns>
        private List<TalentPrerequisteAbility> GetTalentPrerequisteAbilityList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<TalentPrerequisteAbility> talentPrerequisteAbilities = new List<TalentPrerequisteAbility>();

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
                    TalentPrerequisteAbility objTalentPrerequisteAbility = new TalentPrerequisteAbility();
                    SetReaderToObject(ref objTalentPrerequisteAbility, ref result);
                    talentPrerequisteAbilities.Add(objTalentPrerequisteAbility);
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
            return talentPrerequisteAbilities;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                this.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));

                //Talent objTal = new Talent();
                //this.objTalent = objTal.GetTalent(this.TalentID);

                Ability objAbil = new Ability();
                this.objAbility = objAbil.GetAbility(this.AbilityID);

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objTalentPrerequisteAbility">The object talent prerequiste ability.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref TalentPrerequisteAbility objTalentPrerequisteAbility, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objTalentPrerequisteAbility.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objTalentPrerequisteAbility.TalentID = (int)result.GetValue(result.GetOrdinal("TalentID"));
                objTalentPrerequisteAbility.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));

                //Talent objTal = new Talent();
                //objTalentPrerequisteAbility.objTalent = objTal.GetTalent(objTalentPrerequisteAbility.TalentID);

                Ability objAbil = new Ability();
                objTalentPrerequisteAbility.objAbility = objAbil.GetAbility(objTalentPrerequisteAbility.AbilityID);
            }
        }
        #endregion
        #endregion

    }
}
