using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class WeaponDamageType : BaseValidation
    {


        public int WeaponDamageTypeID { get; set; }
        public string WeaponDamageTypeName { get; set; }
        public string WeaponDamageTypeDescription { get; set; }


        #region Constructors
        public WeaponDamageType()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponDamageType"/> class.
        /// </summary>
        /// <param name="WeaponDamageTypeName">Name of the WeaponDamageType.</param>
        public WeaponDamageType(string WeaponDamageTypeName)
        {
            SetBaseConstructorOptions();
            GetWeaponDamageType(WeaponDamageTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponDamageType"/> class.
        /// </summary>
        /// <param name="WeaponDamageTypeID">The WeaponDamageType identifier.</param>
        public WeaponDamageType(int WeaponDamageTypeID)
        {
            SetBaseConstructorOptions();
            GetWeaponDamageType(WeaponDamageTypeID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public WeaponDamageType GetWeaponDamageType(int WeaponDamageTypeID)
        {
            return GetSingleWeaponDamageType("Select_WeaponDamageType", " WeaponDamageTypeID = " + WeaponDamageTypeID.ToString(), "");
        }

        public WeaponDamageType GetWeaponDamageType(string WeaponDamageTypeName)
        {
            return GetSingleWeaponDamageType("Select_WeaponDamageType", " WeaponDamageTypeName='" + WeaponDamageTypeID.ToString() + "'", "");
        }

        public List<WeaponDamageType> GetWeaponDamageTypes(string strWhere, string strOrderBy)
        {
            return GetWeaponDamageTypeList("Select_WeaponDamageType", strWhere, strOrderBy);
        }

        public WeaponDamageType SaveWeaponDamageType()
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
                command.CommandText = "InsertUpdate_WeaponDamageType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponDamageTypeID", SqlDbType.Int, WeaponDamageTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponDamageTypeName", SqlDbType.VarChar, WeaponDamageTypeName, 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponDamageTypeDescription", SqlDbType.VarChar, WeaponDamageTypeDescription, 100));

                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK = false;
                this._insertUpdateMessage.Append(e.Message.ToString());
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
        /// Delete the WeaponDamageType.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteWeaponDamageType()
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
                command.CommandText = "Delete_WeaponDamageType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponDamageTypeID", SqlDbType.Int, WeaponDamageTypeID.ToString(), 0));
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

        #region Private Methods
        private WeaponDamageType GetSingleWeaponDamageType(string sprocName, string strWhere, string strOrderBy)
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

        private List<WeaponDamageType> GetWeaponDamageTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<WeaponDamageType> WeaponDamageTypes = new List<WeaponDamageType>();

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
                    WeaponDamageType objWeaponDamageType = new WeaponDamageType();
                    SetReaderToObject(ref objWeaponDamageType, ref result);
                    WeaponDamageTypes.Add(objWeaponDamageType);
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
            return WeaponDamageTypes;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.WeaponDamageTypeID = (int)result.GetValue(result.GetOrdinal("WeaponDamageTypeID"));
                this.WeaponDamageTypeName = result.GetValue(result.GetOrdinal("WeaponDamageTypeName")).ToString();
                this.WeaponDamageTypeDescription = result.GetValue(result.GetOrdinal("WeaponDamageTypeDescription")).ToString();
            }
        }

        private void SetReaderToObject(ref WeaponDamageType objWeaponDamageType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objWeaponDamageType.WeaponDamageTypeID = (int)result.GetValue(result.GetOrdinal("WeaponDamageTypeID"));
                objWeaponDamageType.WeaponDamageTypeName = result.GetValue(result.GetOrdinal("WeaponDamageTypeName")).ToString();
                objWeaponDamageType.WeaponDamageTypeDescription = result.GetValue(result.GetOrdinal("WeaponDamageTypeDescription")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
