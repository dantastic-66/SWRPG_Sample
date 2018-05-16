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
    public class DefenseType : BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the defense type identifier.
        /// </summary>
        /// <value>
        /// The defense type identifier.
        /// </value>
        public int DefenseTypeID { get; set; }
        /// <summary>
        /// Gets or sets the defense type description.
        /// </summary>
        /// <value>
        /// The defense type description.
        /// </value>
        public string DefenseTypeDescription { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenseType"/> class.
        /// </summary>
        public DefenseType()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefenseType"/> class.
        /// </summary>
        /// <param name="DefenseTypeName">Name of the DefenseType.</param>
        public DefenseType(string DefenseTypeName)
        {
            SetBaseConstructorOptions();
            GetDefenseType(DefenseTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefenseType"/> class.
        /// </summary>
        /// <param name="DefenseTypeID">The DefenseType identifier.</param>
        public DefenseType(int DefenseTypeID)
        {
            SetBaseConstructorOptions();
            GetDefenseType(DefenseTypeID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the type of the defense.
        /// </summary>
        /// <param name="DefenseTypeID">The defense type identifier.</param>
        /// <returns>DefenseType Object</returns>
        public DefenseType GetDefenseType(int DefenseTypeID)
        {
            return GetSingleDefenseType("Select_DefenseType", "  DefenseTypeID=" + DefenseTypeID.ToString(), "");
        }

        /// <summary>
        /// Gets the type of the defense.
        /// </summary>
        /// <param name="DefenseTypeName">Name of the defense type.</param>
        /// <returns>DefenseType Object</returns>
        public DefenseType GetDefenseType(string DefenseTypeName)
        {
            return GetSingleDefenseType("Select_DefenseType", "  DefenseTypeDescription='" + DefenseTypeName + "'", "");
          }

        /// <summary>
        /// Gets the defense types.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of DefenseType Objects</returns>
        public List<DefenseType> GetDefenseTypes(string strWhere, string strOrderBy)
        {
            return GetDefenseTypeList("Select_DefenseType", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the type of the race defense.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>DefenseType Object</returns>
        public DefenseType GetRaceDefenseType(string strWhere, string strOrderBy)
        {
            return GetSingleDefenseType("Select_RaceDefenseType", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the race defense types.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of DefenseType Objects</returns>
        public List<DefenseType> GetRaceDefenseTypes(string strWhere, string strOrderBy)
        {
            return GetDefenseTypeList("Select_RaceDefenseType", strWhere, strOrderBy);
        }


        /// <summary>
        /// Delete the DefenseType.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteDefenseType()
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
                command.CommandText = "Delete_DefenseType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
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
        /// Saves the defense.
        /// </summary>
        /// <returns>DefenseType Object</returns>
        public DefenseType SaveDefenseType()
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
                command.CommandText = "InsertUpdate_DefenseType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeDescription", SqlDbType.Int, DefenseTypeDescription.ToString(), 50));
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
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.DefenseTypeDescription))
            {
                this._validated = false;
                this._validationMessage.Append("The Defense Type Description cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object DefenseType.
        /// </summary>
        /// <param name="objDefenseType">The object DefenseType.</param>
        /// <returns>DefenseType</returns>
        static public DefenseType Clone(DefenseType objDefenseType)
        {
            DefenseType objCDefenseType = new DefenseType(objDefenseType.DefenseTypeID);
            return objCDefenseType;
        }

        /// <summary>
        /// Clones the specified LST DefenseType.
        /// </summary>
        /// <param name="lstDefenseType">The LST DefenseType.</param>
        /// <returns>List<DefenseType></returns>
        static public List<DefenseType> Clone(List<DefenseType> lstDefenseType)
        {
            List<DefenseType> lstCDefenseType = new List<DefenseType>();

            foreach (DefenseType objDefenseType in lstDefenseType)
            {
                lstCDefenseType.Add(DefenseType.Clone(objDefenseType));
            }

            return lstCDefenseType;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the type of the single defense.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>DefenseType Object</returns>
        private DefenseType GetSingleDefenseType(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the defense type list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of DefenseType Objects</returns>
        private List<DefenseType> GetDefenseTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<DefenseType> defenseTypes = new List<DefenseType>();

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
                    DefenseType objDefenseType = new DefenseType();
                    SetReaderToObject(ref objDefenseType, ref result);
                    defenseTypes.Add(objDefenseType);
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
            return defenseTypes;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                this.DefenseTypeDescription = result.GetValue(result.GetOrdinal("DefenseTypeDescription")).ToString();

                this._objComboBoxData.Add(this.DefenseTypeID, this.DefenseTypeDescription);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objDefenseType">Type of the object defense.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref DefenseType objDefenseType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objDefenseType.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                objDefenseType.DefenseTypeDescription = result.GetValue(result.GetOrdinal("DefenseTypeDescription")).ToString();

                objDefenseType._objComboBoxData.Add(objDefenseType.DefenseTypeID, objDefenseType.DefenseTypeDescription);
            }
        }
        #endregion
        #endregion
    }
}
