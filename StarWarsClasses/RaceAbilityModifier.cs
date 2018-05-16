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
    public class RaceAbilityModifier:BaseValidation
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
        /// Gets or sets the race identifier.
        /// </summary>
        /// <value>
        /// The race identifier.
        /// </value>
        public int RaceID { get; set; }
        /// <summary>
        /// Gets or sets the modifier identifier.
        /// </summary>
        /// <value>
        /// The modifier identifier.
        /// </value>
        public int ModifierID {get; set; }

        /// <summary>
        /// Gets or sets the object ability.
        /// </summary>
        /// <value>
        /// The object ability.
        /// </value>
        public Ability objAbility{ get; set; }
        /// <summary>
        /// Gets or sets the object modifier.
        /// </summary>
        /// <value>
        /// The object modifier.
        /// </value>
        public Modifier objModifier {get;set;}
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RaceAbilityModifier"/> class.
        /// </summary>
        public RaceAbilityModifier()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceAbilityModifier"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        public RaceAbilityModifier(int RaceID)
        {
            SetBaseConstructorOptions();
            GetRaceAbilityModifier(RaceID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceAbilityModifier"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        /// <param name="AbilityID">The Ability identifier.</param>
        /// <param name="ModifierID">The Modifier identifier.</param>
        public RaceAbilityModifier(int RaceID, int AbilityID, int ModifierID)
        {
            SetBaseConstructorOptions();
            GetRaceAbilityModifier(RaceID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the race ability modifier.
        /// </summary>
        /// <param name="RaceID">The race identifier.</param>
        /// <returns>RaceAbilityModifier object</returns>
        public RaceAbilityModifier GetRaceAbilityModifier(int RaceID)
        {
            return GetSingleRaceAbilityModifier("Select_RaceAbilityModifier", "  RaceID=" + RaceID.ToString(), "");
        }

        /// <summary>
        /// Gets the race ability modifier.
        /// </summary>
        /// <param name="RaceID">The race identifier.</param>
        /// <param name="AbilityID">The Ability identifier.</param>
        /// <param name="ModifierID">The Modifier identifier.</param>
        /// <returns>RaceAbilityModifier object</returns>
        public RaceAbilityModifier GetRaceAbilityModifier(int RaceID, int AbilityID, int ModifierID)
        {
            return GetSingleRaceAbilityModifier("Select_RaceAbilityModifier", "  RaceID=" + RaceID.ToString() + "  AND AbilityID=" + AbilityID.ToString() + "  AND ModifierID=" + ModifierID.ToString(), "");
        }
        /// <summary>
        /// Gets the race ability modifiers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderby">The string orderby.</param>
        /// <returns>List of RaceAbilityModifier objects</returns>
        public List<RaceAbilityModifier> GetRaceAbilityModifiers(string strWhere, string strOrderby)
        {
            return GetRaceAbilityModifierList("Select_RaceAbilityModifier", strWhere, strOrderby);
        }

        /// <summary>
        /// Saves the race ability modifier.
        /// </summary>
        /// <returns>RaceAbilityModifier object</returns>
        public RaceAbilityModifier SaveRaceAbilityModifier()
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
                command.CommandText = "InsertUpdate_RaceAbilityModifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierID", SqlDbType.Int, ModifierID.ToString(), 0));
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
        /// Deletes the race ability modifier.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteRaceAbilityModifier()
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
                command.CommandText = "Delete_RaceAbilityModifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierID", SqlDbType.Int, ModifierID.ToString(), 0));
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

            ////Put Validation checks here
            if (this.RaceID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Race ID cannot be blank or null.");
            }

            if (this.AbilityID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Ability ID cannot be blank or null.");
            }

            if (this.ModifierID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Modifier ID cannot be blank or null.");
            }

            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object RaceAbilityModifier.
        /// </summary>
        /// <param name="objRaceAbilityModifier">The object RaceAbilityModifier.</param>
        /// <returns>RaceAbilityModifier</returns>
        static public RaceAbilityModifier Clone(RaceAbilityModifier objRaceAbilityModifier)
        {
            RaceAbilityModifier objCRaceAbilityModifier = new RaceAbilityModifier(objRaceAbilityModifier.RaceID, objRaceAbilityModifier.AbilityID, objRaceAbilityModifier.ModifierID );
            return objCRaceAbilityModifier;
        }

        /// <summary>
        /// Clones the specified LST RaceAbilityModifier.
        /// </summary>
        /// <param name="lstRaceAbilityModifier">The LST RaceAbilityModifier.</param>
        /// <returns>List<RaceAbilityModifier></returns>
        static public List<RaceAbilityModifier> Clone(List<RaceAbilityModifier> lstRaceAbilityModifier)
        {
            List<RaceAbilityModifier> lstCRaceAbilityModifier = new List<RaceAbilityModifier>();

            foreach (RaceAbilityModifier objRaceAbilityModifier in lstRaceAbilityModifier)
            {
                lstCRaceAbilityModifier.Add(RaceAbilityModifier.Clone(objRaceAbilityModifier));
            }

            return lstCRaceAbilityModifier;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single race ability modifier.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>RaceAbilityModifier object</returns>
        private RaceAbilityModifier GetSingleRaceAbilityModifier(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the race ability modifier list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of RaceAbilityModifier objects</returns>
        private List<RaceAbilityModifier> GetRaceAbilityModifierList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<RaceAbilityModifier> raceAbilityModifiers = new List<RaceAbilityModifier>();

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
                    RaceAbilityModifier objRaceAbilityModifier = new RaceAbilityModifier();
                    SetReaderToObject(ref objRaceAbilityModifier, ref result);
                    raceAbilityModifiers.Add(objRaceAbilityModifier);
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
            return raceAbilityModifiers;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));

                Modifier objModifier = new Modifier();
                if (!(this.ModifierID == 0))
                {
                    objModifier.GetModifier(this.ModifierID );
                }
                this.objModifier = objModifier;

                Ability objAbility = new Ability();
                if (!(this.AbilityID == 0))
                {
                    objAbility.GetAbility(this.AbilityID );
                }
                this.objAbility = objAbility;
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objRaceAbilityModifier">The object race ability modifier.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref RaceAbilityModifier objRaceAbilityModifier, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objRaceAbilityModifier.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));
                objRaceAbilityModifier.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objRaceAbilityModifier.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));

                Modifier objModifier = new Modifier();
                if (!(objRaceAbilityModifier.ModifierID == 0))
                {
                    objModifier.GetModifier(objRaceAbilityModifier.ModifierID);
                }
                objRaceAbilityModifier.objModifier = objModifier;

                Ability objAbility = new Ability();
                if (!(objRaceAbilityModifier.AbilityID == 0))
                {
                    objAbility.GetAbility(objRaceAbilityModifier.AbilityID);
                }
                objRaceAbilityModifier.objAbility = objAbility;
            }
        }
        #endregion

        #endregion
    }
}
