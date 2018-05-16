using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class ForceTechnique : BaseValidation
    {
        /// <summary>
        /// Gets or sets the force technique identifier.
        /// </summary>
        /// <value>
        /// The force technique identifier.
        /// </value>
        public int ForceTechniqueID { get; set; }
        /// <summary>
        /// Gets or sets the name of the force technique.
        /// </summary>
        /// <value>
        /// The name of the force technique.
        /// </value>
        public string ForceTechniqueName { get; set; }
        /// <summary>
        /// Gets or sets the force technique description.
        /// </summary>
        /// <value>
        /// The force technique description.
        /// </value>
        public string ForceTechniqueDescription { get; set; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ForceTechnique"/> class.
        /// </summary>
        public ForceTechnique()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForceTechnique"/> class.
        /// </summary>
        /// <param name="ForceTechniqueName">Name of the ForceTechnique.</param>
        public ForceTechnique(string ForceTechniqueName)
        {
            SetBaseConstructorOptions();
            GetForceTechnique(ForceTechniqueName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForceTechnique"/> class.
        /// </summary>
        /// <param name="ForceTechniqueID">The ForceTechnique identifier.</param>
        public ForceTechnique(int ForceTechniqueID)
        {
            SetBaseConstructorOptions();
            GetForceTechnique(ForceTechniqueID);
        }
        #endregion


        #region Methods
        /// <summary>
        /// Gets the force Technique.
        /// </summary>
        /// <param name="ForceTechniqueID">The force Technique identifier.</param>
        /// <returns>A ForceTechnique object</returns>
        public ForceTechnique GetForceTechnique(int ForceTechniqueID)
        {
            return GetSingleForceTechnique("Select_ForceTechnique", " ForceTechniqueID = " + ForceTechniqueID.ToString(), "");
        }

        /// <summary>
        /// Gets the force Technique.
        /// </summary>
        /// <param name="ForceTechniqueName">Name of the force Technique.</param>
        /// <returns>A ForceTechnique object</returns>
        public ForceTechnique GetForceTechnique(string ForceTechniqueName)
        {
            return GetSingleForceTechnique("Select_ForceTechnique", " ForceTechniqueName = '" + ForceTechniqueName + "'", "");
        }

        /// <summary>
        /// Gets the force Techniques.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List<ForceTechnique></returns>
        public List<ForceTechnique> GetForceTechniques(string strWhere, string strOrderBy)
        {
            return GetForceTechniqueList("Select_ForceTechnique", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the force Technique.
        /// </summary>
        /// <returns>A ForceTechnique object</returns>
        public ForceTechnique SaveForceTechnique()
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
                command.CommandText = "InsertUpdate_ForceTechnique";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTechniqueID", SqlDbType.Int, ForceTechniqueID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTechniqueName", SqlDbType.VarChar, ForceTechniqueName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTechniqueDescription", SqlDbType.VarChar, ForceTechniqueDescription.ToString(), 500));
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
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
        }

        //TODO: UNIT Test
        public void SaveCharacterForceTechnique(int CharacterID)
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
                command.CommandText = "InsertUpdate_CharacterForceTechnique";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceSecretID", SqlDbType.Int, ForceTechniqueID.ToString(), 0));
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
        }

        /// <summary>
        /// Deletes the extra class item.
        /// </summary>
        /// <returns></returns>
        public bool DeleteForceTechnique()
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
                command.CommandText = "Delete_ForceTechnique";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTechniqueID", SqlDbType.Int, ForceTechniqueID.ToString(), 0));
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
            if (string.IsNullOrEmpty(this.ForceTechniqueName))
            {
                this._validated = false;
                this._validationMessage.Append("The Force Technique Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object ForceTechnique.
        /// </summary>
        /// <param name="objForceTechnique">The object ForceTechnique.</param>
        /// <returns>ForceTechnique</returns>
        static public ForceTechnique Clone(ForceTechnique objForceTechnique)
        {
            ForceTechnique objCForceTechnique = new ForceTechnique(objForceTechnique.ForceTechniqueID);
            return objCForceTechnique;
        }

        /// <summary>
        /// Clones the specified LST ForceTechnique.
        /// </summary>
        /// <param name="lstForceTechnique">The LST ForceTechnique.</param>
        /// <returns>List<ForceTechnique></returns>
        static public List<ForceTechnique> Clone(List<ForceTechnique> lstForceTechnique)
        {
            List<ForceTechnique> lstCForceTechnique = new List<ForceTechnique>();

            foreach (ForceTechnique objForceTechnique in lstForceTechnique)
            {
                lstCForceTechnique.Add(ForceTechnique.Clone(objForceTechnique));
            }

            return lstCForceTechnique;
        }

        #region Private Methods
        /// <summary>
        /// Gets the single force Technique.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>A ForceTechnique object</returns>
        private ForceTechnique GetSingleForceTechnique(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the force Technique list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns> List<ForceTechnique></returns>
        private List<ForceTechnique> GetForceTechniqueList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ForceTechnique> ForceTechniques = new List<ForceTechnique>();

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
                    ForceTechnique objForceTechnique = new ForceTechnique();
                    SetReaderToObject(ref objForceTechnique, ref result);
                    ForceTechniques.Add(objForceTechnique);
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
            return ForceTechniques;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Sets the reader to the internal Force Technique object.
        /// </summary>
        /// <param name="result">SqlDataReader.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ForceTechniqueID = (int)result.GetValue(result.GetOrdinal("ForceTechniqueID"));
                this.ForceTechniqueName = result.GetValue(result.GetOrdinal("ForceTechniqueName")).ToString();
                this.ForceTechniqueDescription = result.GetValue(result.GetOrdinal("ForceTechniqueDescription")).ToString();
            }
        }

        /// <summary>
        /// Sets the reader to the parameter Force Technique object..
        /// </summary>
        /// <param name="objForceTechnique">The object force Technique.</param>
        /// <param name="result">SqlDataReader</param>
        private void SetReaderToObject(ref ForceTechnique objForceTechnique, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objForceTechnique.ForceTechniqueID = (int)result.GetValue(result.GetOrdinal("ForceTechniqueID"));
                objForceTechnique.ForceTechniqueName = result.GetValue(result.GetOrdinal("ForceTechniqueName")).ToString();
                objForceTechnique.ForceTechniqueDescription = result.GetValue(result.GetOrdinal("ForceTechniqueDescription")).ToString();
            }
        }
        #endregion

        #endregion
    }
}
