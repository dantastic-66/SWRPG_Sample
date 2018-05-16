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
    /// Class for a Force Secret used in SWRPG
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class ForceSecret : BaseValidation
    {


        /// <summary>
        /// Gets or sets the force secret identifier.
        /// </summary>
        /// <value>
        /// The force secret identifier.
        /// </value>
        public int ForceSecretID { get; set; }
        /// <summary>
        /// Gets or sets the name of the force secret.
        /// </summary>
        /// <value>
        /// The name of the force secret.
        /// </value>
        public string ForceSecretName { get; set; }
        /// <summary>
        /// Gets or sets the force secret description.
        /// </summary>
        /// <value>
        /// The force secret description.
        /// </value>
        public string ForceSecretDescription { get; set; }


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ForceSecret"/> class.
        /// </summary>
        public ForceSecret()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForceSecret"/> class.
        /// </summary>
        /// <param name="ForceSecretName">Name of the ForceSecret.</param>
        public ForceSecret(string ForceSecretName)
        {
            SetBaseConstructorOptions();
            GetForceSecret(ForceSecretName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForceSecret"/> class.
        /// </summary>
        /// <param name="ForceSecretID">The ForceSecret identifier.</param>
        public ForceSecret(int ForceSecretID)
        {
            SetBaseConstructorOptions();
            GetForceSecret(ForceSecretID);
        }
        #endregion


        #region Methods
        /// <summary>
        /// Gets the force secret.
        /// </summary>
        /// <param name="ForceSecretID">The force secret identifier.</param>
        /// <returns>A ForceSecret object</returns>
        public ForceSecret GetForceSecret(int ForceSecretID)
        {
            return GetSingleForceSecret("Select_ForceSecret", " ForceSecretID = " + ForceSecretID.ToString(), "");
        }

        /// <summary>
        /// Gets the force secret.
        /// </summary>
        /// <param name="ForceSecretName">Name of the force secret.</param>
        /// <returns>A ForceSecret object</returns>
        public ForceSecret GetForceSecret(string ForceSecretName)
        {
            return GetSingleForceSecret("Select_ForceSecret", " ForceSecretName= '" + ForceSecretName + "'", "");
        }

        /// <summary>
        /// Gets the force secrets.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List<ForceSecret></returns>
        public List<ForceSecret> GetForceSecrets(string strWhere, string strOrderBy)
        {
            return GetForceSecretList("Select_ForceSecret", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the force secret.
        /// </summary>
        /// <returns>A ForceSecret object</returns>
        public ForceSecret SaveForceSecret()
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
                command.CommandText = "InsertUpdate_ForceSecret";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceSecretID", SqlDbType.Int, ForceSecretID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceSecretName", SqlDbType.VarChar, ForceSecretName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceSecretDescription", SqlDbType.VarChar, ForceSecretDescription.ToString(), 500));
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

        //TODO: UNIT Test
        public void SaveCharacterForceSecret(int CharacterID)
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
                command.CommandText = "InsertUpdate_CharacterForceSecret";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceSecretID", SqlDbType.Int, ForceSecretID.ToString(), 0));
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
           
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
        }

        /// <summary>
        /// Deletes the extra class item.
        /// </summary>
        /// <returns></returns>
        public bool DeleteForceSecret()
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
                command.CommandText = "Delete_ForceSecret";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceSecretID", SqlDbType.Int, ForceSecretID.ToString(), 0));
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
        /// <returns>Bool</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.ForceSecretName ))
            {
                this._validated = false;
                this._validationMessage.Append("The Force Secret Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object ForceSecret.
        /// </summary>
        /// <param name="objForceSecret">The object ForceSecret.</param>
        /// <returns>ForceSecret</returns>
        static public ForceSecret Clone(ForceSecret objForceSecret)
        {
            ForceSecret objCForceSecret = new ForceSecret(objForceSecret.ForceSecretID);
            return objCForceSecret;
        }

        /// <summary>
        /// Clones the specified LST ForceSecret.
        /// </summary>
        /// <param name="lstForceSecret">The LST ForceSecret.</param>
        /// <returns>List<ForceSecret></returns>
        static public List<ForceSecret> Clone(List<ForceSecret> lstForceSecret)
        {
            List<ForceSecret> lstCForceSecret = new List<ForceSecret>();

            foreach (ForceSecret objForceSecret in lstForceSecret)
            {
                lstCForceSecret.Add(ForceSecret.Clone(objForceSecret));
            }

            return lstCForceSecret;
        }

        #region Private Methods
        /// <summary>
        /// Gets the single force secret.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>A ForceSecret object</returns>
        private ForceSecret GetSingleForceSecret(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the force secret list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns> List<ForceSecret></returns>
        private List<ForceSecret> GetForceSecretList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ForceSecret> ForceSecrets = new List<ForceSecret>();

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
                    ForceSecret objForceSecret = new ForceSecret();
                    SetReaderToObject(ref objForceSecret, ref result);
                    ForceSecrets.Add(objForceSecret);
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
            return ForceSecrets;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Sets the reader to the internal Force Secret object.
        /// </summary>
        /// <param name="result">SqlDataReader.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ForceSecretID = (int)result.GetValue(result.GetOrdinal("ForceSecretID"));
                this.ForceSecretName = result.GetValue(result.GetOrdinal("ForceSecretName")).ToString();
                this.ForceSecretDescription = result.GetValue(result.GetOrdinal("ForceSecretDescription")).ToString();
            }
        }

        /// <summary>
        /// Sets the reader to the parameter Force Secret object..
        /// </summary>
        /// <param name="objForceSecret">The object force secret.</param>
        /// <param name="result">SqlDataReader</param>
        private void SetReaderToObject(ref ForceSecret objForceSecret, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objForceSecret.ForceSecretID = (int)result.GetValue(result.GetOrdinal("ForceSecretID"));
                objForceSecret.ForceSecretName = result.GetValue(result.GetOrdinal("ForceSecretName")).ToString();
                objForceSecret.ForceSecretDescription = result.GetValue(result.GetOrdinal("ForceSecretDescription")).ToString();
            }
        }
        #endregion

        #endregion
    }
}
