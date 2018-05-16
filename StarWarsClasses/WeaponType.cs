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
    public class WeaponType:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the weapon type identifier.
        /// </summary>
        /// <value>
        /// The weapon type identifier.
        /// </value>
        public int WeaponTypeID { get; set; }
        /// <summary>
        /// Gets or sets the weapon type Name.
        /// </summary>
        /// <value>
        /// The weapon type Name.
        /// </value>
        public string WeaponTypeName { get; set; }
        /// <summary>
        /// Gets or sets the weapon type description.
        /// </summary>
        /// <value>
        /// The weapon type description.
        /// </value>
        public string WeaponTypeDescription { get; set; }

        public bool Universal { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponType"/> class.
        /// </summary>
        public WeaponType()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponType"/> class.
        /// </summary>
        /// <param name="WeaponTypeName">Name of the WeaponType.</param>
        public WeaponType(string WeaponTypeName)
        {
            SetBaseConstructorOptions();
            GetWeaponType(WeaponTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponType"/> class.
        /// </summary>
        /// <param name="WeaponTypeID">The WeaponType identifier.</param>
        public WeaponType(int WeaponTypeID)
        {
            SetBaseConstructorOptions();
            GetWeaponType(WeaponTypeID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the type of the weapon.
        /// </summary>
        /// <param name="WeaponTypeID">The weapon type identifier.</param>
        /// <returns>WeaponType object</returns>
        public WeaponType GetWeaponType(int WeaponTypeID)
        {
            return GetSingleWeaponType("Select_WeaponType", "  WeaponTypeID=" + WeaponTypeID.ToString(), "");
        }

        /// <summary>
        /// Gets the type of the weapon.
        /// </summary>
        /// <param name="WeaponTypeName">Name of the weapon type.</param>
        /// <returns>WeaponType object</returns>
        public WeaponType GetWeaponType(string WeaponTypeName)
        {
            return GetSingleWeaponType("Select_WeaponType", "  WeaponTypeDescription='" + WeaponTypeName + "'", "");
        }

        /// <summary>
        /// Gets the weapon types.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of WeaponType objects</returns>
        public List<WeaponType> GetWeaponTypes(string strWhere, string strOrderBy)
        {
            return GetWeaponTypeList("Select_WeaponType", strWhere, strOrderBy);
        }


        public List<WeaponType> GetCharacterProficientWeaponTypes(int CharacterID)
        {
            return GetWeaponTypeList("Select_CharacterProfecientWeaponType", CharacterID.ToString(), "WeaponTypeName");
            
        }
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.WeaponTypeDescription))
            {
                this._validated = false;
                this._validationMessage.Append("The Weapon Type Description cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Saves the type of the weapon.
        /// </summary>
        /// <returns>WeaponType objects</returns>
        public WeaponType SaveWeaponType()
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
                command.CommandText = "InsertUpdate_WeaponType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponTypeID", SqlDbType.Int, WeaponTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponTypeName", SqlDbType.VarChar, WeaponTypeName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponTypeDescription", SqlDbType.VarChar, WeaponTypeDescription.ToString(), 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Universal", SqlDbType.Bit, Universal.ToString(), 0));
                 
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
        /// Deletes the type of the weapon.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteWeaponType()
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
                command.CommandText = "Delete_WeaponType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponTypeID", SqlDbType.Int, WeaponTypeID.ToString(), 0));
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
        /// Clones the specified object WeaponType.
        /// </summary>
        /// <param name="objWeaponType">The object WeaponType.</param>
        /// <returns>WeaponType</returns>
        static public WeaponType Clone(WeaponType objWeaponType)
        {
            WeaponType objCWeaponType = new WeaponType(objWeaponType.WeaponTypeID);
            return objCWeaponType;
        }

        /// <summary>
        /// Clones the specified LST WeaponType.
        /// </summary>
        /// <param name="lstWeaponType">The LST WeaponType.</param>
        /// <returns>List<WeaponType></returns>
        static public List<WeaponType> Clone(List<WeaponType> lstWeaponType)
        {
            List<WeaponType> lstCWeaponType = new List<WeaponType>();

            foreach (WeaponType objWeaponType in lstWeaponType)
            {
                lstCWeaponType.Add(WeaponType.Clone(objWeaponType));
            }

            return lstCWeaponType;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the type of the single weapon.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>WeaponType object</returns>
        private WeaponType GetSingleWeaponType(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the weapon type list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of WeaponType objects</returns>
        private List<WeaponType> GetWeaponTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<WeaponType> weaponTypes = new List<WeaponType>();

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
                    WeaponType objWeaponType = new WeaponType();
                    SetReaderToObject(ref objWeaponType, ref result);
                    weaponTypes.Add(objWeaponType);
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
            return weaponTypes;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.WeaponTypeID = (int)result.GetValue(result.GetOrdinal("WeaponTypeID"));
                this.WeaponTypeName = result.GetValue(result.GetOrdinal("WeaponTypeName")).ToString();
                this.WeaponTypeDescription = result.GetValue(result.GetOrdinal("WeaponTypeDescription")).ToString();
                this.Universal = (bool) result.GetValue(result.GetOrdinal("Universal"));
                this._objComboBoxData.Add(this.WeaponTypeID, this.WeaponTypeDescription);

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objWeaponType">Type of the object weapon.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref WeaponType objWeaponType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objWeaponType.WeaponTypeID = (int)result.GetValue(result.GetOrdinal("WeaponTypeID"));
                objWeaponType.WeaponTypeName = result.GetValue(result.GetOrdinal("WeaponTypeName")).ToString();
                objWeaponType.WeaponTypeDescription = result.GetValue(result.GetOrdinal("WeaponTypeDescription")).ToString();
                objWeaponType.Universal = (bool)result.GetValue(result.GetOrdinal("Universal"));
                objWeaponType._objComboBoxData.Add(objWeaponType.WeaponTypeID, objWeaponType.WeaponTypeDescription);

            }
        }
        #endregion
        #endregion
    }
}
