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
    public class PrestigeRequirement:BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the prestige requirement identifier.
        /// </summary>
        /// <value>
        /// The prestige requirement identifier.
        /// </value>
        public int PrestigeRequirementID { get; set; }
        /// <summary>
        /// Gets or sets the prestige requirement description.
        /// </summary>
        /// <value>
        /// The prestige requirement description.
        /// </value>
        public string PrestigeRequirementDescription { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PrestigeRequirement"/> class.
        /// </summary>
        public PrestigeRequirement()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrestigeRequirement"/> class.
        /// </summary>
        /// <param name="PrestigeRequirementID">The PrestigeRequirement identifier.</param>
        public PrestigeRequirement(int PrestigeRequirementID)
        {
            SetBaseConstructorOptions();
            GetPrestigeRequirement(PrestigeRequirementID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the prestige requirement prestige class.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of PrestigeRequirement objects</returns>
        public List<PrestigeRequirement> GetPrestigeRequirementPrestigeClass(string strWhere, string strOrderBy)
        {
            return GetPrestigeRequirementList("Select_PrestigeRequirementClass", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the prestige requirement.
        /// </summary>
        /// <param name="PrestigeRequirementID">The prestige requirement identifier.</param>
        /// <returns>LPrestigeRequirement object</returns>
        public PrestigeRequirement GetPrestigeRequirement(int PrestigeRequirementID)
        {
            return GetSinglePrestigeRequirement("Select_PrestigeRequirement", "  PrestigeRequirementID=" + PrestigeRequirementID.ToString(), "");
        }

        /// <summary>
        /// Gets the character prestige requirement.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of PrestigeRequirement objects</returns>
        public List<PrestigeRequirement> GetCharacterPrestigeRequirement(int CharacterID)
        {
            return GetPrestigeRequirementList("Select_CharacterPrestigeRequirement", " CharacterID=" + CharacterID.ToString(),"");
        }

        /// <summary>
        /// Gets the character prestige requirement.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of PrestigeRequirement objects</returns>
        public List<PrestigeRequirement> GetCharacterPrestigeRequirement(string strWhere, string strOrderBy)
        {
            return GetPrestigeRequirementList("Select_CharacterPrestigeRequirement", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves thePrestige Requirement.
        /// </summary>
        /// <returns></returns>
        public PrestigeRequirement SavePrestigeRequirement()
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
                command.CommandText = "InsertUpdate_PrestigeRequirement";
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequirementID", SqlDbType.Int, PrestigeRequirementID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequirementDescription", SqlDbType.VarChar, PrestigeRequirementDescription.ToString(), 50));
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
        /// Deletes the PrestigeRequirement.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeletePrestigeRequirement()
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
                command.CommandText = "Delete_PrestigeRequirement";
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequirementID", SqlDbType.Int, PrestigeRequirementID.ToString(), 0));
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
        /// Saves thePrestige Requirement.
        /// </summary>
        /// <param name="PrestigeRequirementID">The prestige requirement identifier.</param>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>PrestigeRequirement object</returns>
        public PrestigeRequirement SaveCharacterPrestigeRequirement(int PrestigeRequirementID, int CharacterID)
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
                command.CommandText = "InsertUpdate_CharacterPrestigeRequirement";
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequirementID", SqlDbType.Int, PrestigeRequirementID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
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
            return GetPrestigeRequirement(PrestigeRequirementID);
        }


        /// <summary>
        /// Delete the CharacterWeapon.
        /// </summary>
        /// <param name="intCharacterID">The character identifier.</param>
        /// <param name="intWeaponID">The Weapon identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterWeapon(int intCharacterID, int intWeaponID)
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
                command.CommandText = "Delete_CharacterWeapon";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, intCharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, intWeaponID.ToString(), 0));
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
        public void SaveCharacterPrestigeRequirements(List<PrestigeRequirement> lstCharactePrestigeRequirement, int intCharacterID)
        {
            //Once a PrestigeRequirement is added it can be removed, added or updated, so reset the list
            PrestigeRequirement objDelPrestigeRequirement = new PrestigeRequirement();
            objDelPrestigeRequirement.DeleteCharacterPrestigeRequirement( 0,intCharacterID);

            foreach (PrestigeRequirement objCharPrestigeRequirement in lstCharactePrestigeRequirement)
            {
                objCharPrestigeRequirement.SaveCharacterPrestigeRequirement(objCharPrestigeRequirement.PrestigeRequirementID, intCharacterID);
            }
        }

        /// <summary>
        /// Deletes the extra class item.
        /// </summary>
        /// <param name="PrestigeRequirementID">The prestige requirement identifier.</param>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterPrestigeRequirement(int PrestigeRequirementID, int CharacterID)
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
                command.CommandText = "Delete_CharacterPrestigeRequirement";
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequirementID", SqlDbType.Int, PrestigeRequirementID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
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
            if (string.IsNullOrEmpty(this.PrestigeRequirementDescription))
            {
                this._validated = false;
                this._validationMessage.Append("The Prestige Requirement Description Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object PrestigeRequirement.
        /// </summary>
        /// <param name="objPrestigeRequirement">The object PrestigeRequirement.</param>
        /// <returns>PrestigeRequirement</returns>
        static public PrestigeRequirement Clone(PrestigeRequirement objPrestigeRequirement)
        {
            PrestigeRequirement objCPrestigeRequirement = new PrestigeRequirement(objPrestigeRequirement.PrestigeRequirementID);
            return objCPrestigeRequirement;
        }

        /// <summary>
        /// Clones the specified LST PrestigeRequirement.
        /// </summary>
        /// <param name="lstPrestigeRequirement">The LST PrestigeRequirement.</param>
        /// <returns>List<PrestigeRequirement></returns>
        static public List<PrestigeRequirement> Clone(List<PrestigeRequirement> lstPrestigeRequirement)
        {
            List<PrestigeRequirement> lstCPrestigeRequirement = new List<PrestigeRequirement>();

            foreach (PrestigeRequirement objPrestigeRequirement in lstPrestigeRequirement)
            {
                lstCPrestigeRequirement.Add(PrestigeRequirement.Clone(objPrestigeRequirement));
            }

            return lstCPrestigeRequirement;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single prestige requirement.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>PrestigeRequirement object</returns>
        private PrestigeRequirement GetSinglePrestigeRequirement(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the prestige requirement list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of PrestigeRequirement objects</returns>
        private List<PrestigeRequirement> GetPrestigeRequirementList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<PrestigeRequirement> PrestigeRequirements = new List<PrestigeRequirement>();

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
                    PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
                    SetReaderToObject(ref objPrestigeRequirement, ref result);
                    PrestigeRequirements.Add(objPrestigeRequirement);
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
            return PrestigeRequirements;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.PrestigeRequirementID = (int)result.GetValue(result.GetOrdinal("PrestigeRequirementID"));
                this.PrestigeRequirementDescription = result.GetValue(result.GetOrdinal("PrestigeRequirementDescription")).ToString();

                this._objComboBoxData.Add(this.PrestigeRequirementID, this.PrestigeRequirementDescription);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objPrestigeRequirement">The object prestige requirement.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref PrestigeRequirement objPrestigeRequirement, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objPrestigeRequirement.PrestigeRequirementID = (int)result.GetValue(result.GetOrdinal("PrestigeRequirementID"));
                objPrestigeRequirement.PrestigeRequirementDescription = result.GetValue(result.GetOrdinal("PrestigeRequirementDescription")).ToString();

                objPrestigeRequirement._objComboBoxData.Add(objPrestigeRequirement.PrestigeRequirementID, objPrestigeRequirement.PrestigeRequirementDescription);
            }
        }
        #endregion
        #endregion
    }
}
