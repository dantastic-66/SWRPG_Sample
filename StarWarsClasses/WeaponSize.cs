using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class WeaponSize : BaseValidation
    {


        public int WeaponSizeID { get; set; }
        public string WeaponSizeName { get; set; }
        public string WeaponSizeDescription { get; set; }


        #region Constructors
        public WeaponSize()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponSize"/> class.
        /// </summary>
        /// <param name="WeaponSizeName">Name of the WeaponSize.</param>
        public WeaponSize(string WeaponSizeName)
        {
            SetBaseConstructorOptions();
            GetWeaponSize(WeaponSizeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponSize"/> class.
        /// </summary>
        /// <param name="WeaponSizeID">The WeaponSize identifier.</param>
        public WeaponSize(int WeaponSizeID)
        {
            SetBaseConstructorOptions();
            GetWeaponSize(WeaponSizeID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public WeaponSize GetWeaponSize(int WeaponSizeID)
        {
            return GetSingleWeaponSize("Select_WeaponSize", " WeaponSizeID = " + WeaponSizeID.ToString(), "");
        }

        public WeaponSize GetWeaponSize(string WeaponSizeName)
        {
            return GetSingleWeaponSize("Select_WeaponSize", " WeaponSizeName='" + WeaponSizeID.ToString() + "'", "");
        }

        public List<WeaponSize> GetWeaponSizes(string strWhere, string strOrderBy)
        {
            return GetWeaponSizeList("Select_WeaponSize", strWhere, strOrderBy);
        }

        public WeaponSize SaveWeaponSize()
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
                command.CommandText = "InsertUpdate_WeaponSize";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponSizeID", SqlDbType.Int, WeaponSizeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponSizeName", SqlDbType.VarChar , WeaponSizeName, 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponSizeDescription", SqlDbType.VarChar, WeaponSizeDescription, 100));


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
        /// Delete the WeaponSize.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteWeaponSize()
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
                command.CommandText = "Delete_WeaponSize";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponSizeID", SqlDbType.Int, WeaponSizeID.ToString(), 0));
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
        private WeaponSize GetSingleWeaponSize(string sprocName, string strWhere, string strOrderBy)
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

        private List<WeaponSize> GetWeaponSizeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<WeaponSize> WeaponSizes = new List<WeaponSize>();

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
                    WeaponSize objWeaponSize = new WeaponSize();
                    SetReaderToObject(ref objWeaponSize, ref result);
                    WeaponSizes.Add(objWeaponSize);
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
            return WeaponSizes;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.WeaponSizeID = (int)result.GetValue(result.GetOrdinal("WeaponSizeID"));
                this.WeaponSizeName = result.GetValue(result.GetOrdinal("WeaponSizeName")).ToString();
                this.WeaponSizeDescription = result.GetValue(result.GetOrdinal("WeaponSizeDescription")).ToString();
            }
        }

        private void SetReaderToObject(ref WeaponSize objWeaponSize, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objWeaponSize.WeaponSizeID = (int)result.GetValue(result.GetOrdinal("WeaponSizeID"));
                objWeaponSize.WeaponSizeName = result.GetValue(result.GetOrdinal("WeaponSizeName")).ToString();
                objWeaponSize.WeaponSizeDescription = result.GetValue(result.GetOrdinal("WeaponSizeDescription")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
