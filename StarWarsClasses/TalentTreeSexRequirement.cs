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
    public class TalentTreeSexRequirement:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the talent tree identifier.
        /// </summary>
        /// <value>
        /// The talent tree identifier.
        /// </value>
        public int TalentTreeID { get; set; }
        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public string Sex { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTreeSexRequirement"/> class.
        /// </summary>
        public TalentTreeSexRequirement()
        {
            SetBaseConstructorOptions();
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="TalentTreeSexRequirement"/> class.
        /// </summary>
        /// <param name="TalentTreeSexRequirementID">The TalentTreeSexRequirement identifier.</param>
        public TalentTreeSexRequirement(int TalentTreeID)
        {
            SetBaseConstructorOptions();
            GetTalentTreeSexRequirement(TalentTreeID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the talent tree sex requirement.
        /// </summary>
        /// <param name="TalentTreeID">The talent tree identifier.</param>
        /// <returns>TalentTreeSexRequirement Object</returns>
        public TalentTreeSexRequirement GetTalentTreeSexRequirement(int TalentTreeID)
        {
            return GetSingleTalentTreeSexRequirement("Select_TalentTreeSexRequirement", "  TalentTreeID=" + TalentTreeID.ToString(), "");
        }

        /// <summary>
        /// Gets the talent tree sex requirements.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderby">The string orderby.</param>
        /// <returns>List of TalentTreeSexRequirement Objects</returns>
        public List<TalentTreeSexRequirement> GetTalentTreeSexRequirements(string strWhere, string strOrderby)
        {
            return GetTalentTreeSexRequirementList("Select_TalentTreeSexRequirement", strWhere, strOrderby);
        }

        /// <summary>
        /// Saves the talent tree sex requirement.
        /// </summary>
        /// <returns>TalentTreeSexRequirement Object</returns>
        public TalentTreeSexRequirement SaveTalentTreeSexRequirement()
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
                command.CommandText = "InsertUpdate_TalentTreeSexRequirement";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeID", SqlDbType.Int, TalentTreeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Sex", SqlDbType.Char , Sex.ToString(), 1));
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
        /// Deletes the talent tree sex requirement.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteTalentTreeSexRequirement()
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
                command.CommandText = "Delete_TalentTreeSexRequirement";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TalentTreeID", SqlDbType.Int, TalentTreeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Sex", SqlDbType.Char, Sex.ToString(), 1));

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
            if (string.IsNullOrEmpty(this.Sex))
            {
                this._validated = false;
                this._validationMessage.Append("The Talent Tree Sex Requirement  cannot be blank.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object TalentTreeSexRequirement.
        /// </summary>
        /// <param name="objTalentTreeSexRequirement">The object TalentTreeSexRequirement.</param>
        /// <returns>TalentTreeSexRequirement</returns>
        static public TalentTreeSexRequirement Clone(TalentTreeSexRequirement objTalentTreeSexRequirement)
        {
            TalentTreeSexRequirement objCTalentTreeSexRequirement = new TalentTreeSexRequirement(objTalentTreeSexRequirement.TalentTreeID);
            return objCTalentTreeSexRequirement;
        }

        /// <summary>
        /// Clones the specified LST TalentTreeSexRequirement.
        /// </summary>
        /// <param name="lstTalentTreeSexRequirement">The LST TalentTreeSexRequirement.</param>
        /// <returns>List<TalentTreeSexRequirement></returns>
        static public List<TalentTreeSexRequirement> Clone(List<TalentTreeSexRequirement> lstTalentTreeSexRequirement)
        {
            List<TalentTreeSexRequirement> lstCTalentTreeSexRequirement = new List<TalentTreeSexRequirement>();

            foreach (TalentTreeSexRequirement objTalentTreeSexRequirement in lstTalentTreeSexRequirement)
            {
                lstCTalentTreeSexRequirement.Add(TalentTreeSexRequirement.Clone(objTalentTreeSexRequirement));
            }

            return lstCTalentTreeSexRequirement;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single talent tree sex requirement.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>TalentTreeSexRequirement Object</returns>
        private TalentTreeSexRequirement GetSingleTalentTreeSexRequirement(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the talent tree sex requirement list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TalentTreeSexRequirement Objects</returns>
        private List<TalentTreeSexRequirement> GetTalentTreeSexRequirementList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<TalentTreeSexRequirement> talentTreeSexRequirements = new List<TalentTreeSexRequirement>();

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
                    TalentTreeSexRequirement objTalentTreeSexRequirement = new TalentTreeSexRequirement();
                    SetReaderToObject(ref objTalentTreeSexRequirement, ref result);
                    talentTreeSexRequirements.Add(objTalentTreeSexRequirement);
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
            return talentTreeSexRequirements;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                this.Sex = result.GetValue(result.GetOrdinal("Sex")).ToString();
                

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objTalentTreeSexRequirement">The object talent tree sex requirement.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref TalentTreeSexRequirement objTalentTreeSexRequirement, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objTalentTreeSexRequirement.TalentTreeID = (int)result.GetValue(result.GetOrdinal("TalentTreeID"));
                objTalentTreeSexRequirement.Sex = result.GetValue(result.GetOrdinal("Sex")).ToString();
            }
        }
        #endregion
        #endregion

    }
}
