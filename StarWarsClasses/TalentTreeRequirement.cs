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
    public class TalentTreeRequirement:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the talent tree requirement identifier.
        /// </summary>
        /// <value>
        /// The talent tree requirement identifier.
        /// </value>
        public int TalentTreeRequirementID { get; set; }
        /// <summary>
        /// Gets or sets the talent tree requirement description.
        /// </summary>
        /// <value>
        /// The talent tree requirement description.
        /// </value>
        public string TalentTreeRequirementDescription { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTreeRequirement"/> class.
        /// </summary>
        public TalentTreeRequirement()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTreeRequirement"/> class.
        /// </summary>
        /// <param name="TalentTreeRequirementID">The TalentTreeRequirement identifier.</param>
        public TalentTreeRequirement(int TalentTreeRequirementID)
        {
            SetBaseConstructorOptions();
            GetTalentTreeRequirement(TalentTreeRequirementID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the talent tree requirement.
        /// </summary>
        /// <param name="TalentTreeRequirementID">The talent tree requirement identifier.</param>
        /// <returns>TalentTreeRequirement object</returns>
        public TalentTreeRequirement GetTalentTreeRequirement(int TalentTreeRequirementID)
        {
            return GetSingleTalentTreeRequirement("Select_TalentTreeRequirement", "  TalentTreeRequirementID=" + TalentTreeRequirementID.ToString(), "");
         }

        /// <summary>
        /// Gets the talent tree talent tree requirements.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderby">The string orderby.</param>
        /// <returns>List of TalentTreeRequirement objects</returns>
        public List<TalentTreeRequirement> GetTalentTreeTalentTreeRequirements(string strWhere, string strOrderby)
        {
            return GetTalentTreeRequirementList("Select_TalentTreeTalentTreeRequirement", strWhere, strOrderby);
         }

        /// <summary>
        /// Gets the talent tree requirements.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderby">The string orderby.</param>
        /// <returns>List of TalentTreeRequirement objects</returns>
        public List<TalentTreeRequirement> GetTalentTreeRequirements(string strWhere, string strOrderby)
        {
            return GetTalentTreeRequirementList("Select_TalentTreeRequirement", strWhere, strOrderby);
        }

        /// <summary>
        /// Saves the talent tree requirement.
        /// </summary>
        /// <returns>TalentTreeRequirement object</returns>
        public TalentTreeRequirement SaveTalentTreeRequirement()
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
                 command.CommandText = "InsertUpdate_TalentTreeRequirement";
                 command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeRequirementID", SqlDbType.Int, TalentTreeRequirementID.ToString(), 0));
                 command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeRequirementDescription", SqlDbType.VarChar, TalentTreeRequirementDescription.ToString(), 2000));
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
        /// Deletes the talent tree requirement.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteTalentTreeRequirement()
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
                 command.CommandText = "Delete_TalentTreeRequirement";
                 command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeRequirementID", SqlDbType.Int, TalentTreeRequirementID.ToString(), 0));
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
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.TalentTreeRequirementDescription))
            {
                this._validated = false;
                this._validationMessage.Append("The Talent Tree Requirement Description cannot be blank.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object TalentTreeRequirement.
        /// </summary>
        /// <param name="objTalentTreeRequirement">The object TalentTreeRequirement.</param>
        /// <returns>TalentTreeRequirement</returns>
        static public TalentTreeRequirement Clone(TalentTreeRequirement objTalentTreeRequirement)
        {
            TalentTreeRequirement objCTalentTreeRequirement = new TalentTreeRequirement(objTalentTreeRequirement.TalentTreeRequirementID);
            return objCTalentTreeRequirement;
        }

        /// <summary>
        /// Clones the specified LST TalentTreeRequirement.
        /// </summary>
        /// <param name="lstTalentTreeRequirement">The LST TalentTreeRequirement.</param>
        /// <returns>List<TalentTreeRequirement></returns>
        static public List<TalentTreeRequirement> Clone(List<TalentTreeRequirement> lstTalentTreeRequirement)
        {
            List<TalentTreeRequirement> lstCTalentTreeRequirement = new List<TalentTreeRequirement>();

            foreach (TalentTreeRequirement objTalentTreeRequirement in lstTalentTreeRequirement)
            {
                lstCTalentTreeRequirement.Add(TalentTreeRequirement.Clone(objTalentTreeRequirement));
            }

            return lstCTalentTreeRequirement;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the single talent tree requirement.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>TalentTreeRequirement object</returns>
        private TalentTreeRequirement GetSingleTalentTreeRequirement(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the talent tree requirement list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TalentTreeRequirement objects</returns>
        private List<TalentTreeRequirement> GetTalentTreeRequirementList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<TalentTreeRequirement> talentTreeRequirements = new List<TalentTreeRequirement>();

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
                    TalentTreeRequirement objTalentTreeRequirement = new TalentTreeRequirement();
                    SetReaderToObject(ref objTalentTreeRequirement, ref result);
                    talentTreeRequirements.Add(objTalentTreeRequirement);
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
            return talentTreeRequirements;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.TalentTreeRequirementID = (int)result.GetValue(result.GetOrdinal("TalentTreeRequirementID"));
                this.TalentTreeRequirementDescription = result.GetValue(result.GetOrdinal("TalentTreeRequirementDescription")).ToString();

                this._objComboBoxData.Add(this.TalentTreeRequirementID, this.TalentTreeRequirementDescription);

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objTalentTreeRequirement">The object talent tree requirement.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref TalentTreeRequirement objTalentTreeRequirement, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objTalentTreeRequirement.TalentTreeRequirementID = (int)result.GetValue(result.GetOrdinal("TalentTreeRequirementID"));
                objTalentTreeRequirement.TalentTreeRequirementDescription = result.GetValue(result.GetOrdinal("TalentTreeRequirementDescription")).ToString();

                objTalentTreeRequirement._objComboBoxData.Add(objTalentTreeRequirement.TalentTreeRequirementID, objTalentTreeRequirement.TalentTreeRequirementDescription);

            }
        }
        #endregion

        #endregion
    }
}
