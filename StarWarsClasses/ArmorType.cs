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
    /// Returns a Star Wars Armor Type object.  Currently a Light, Medium or heavy type of armor.
    /// Other properties include the Armor Check Penalty for not being proficient with the type of armor
    /// The movement speads for a Characer with a Walk rate of 8 squares, 6 squares or 4 Squares.
    /// Matches to the lstArmorType table in the database. 
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class ArmorType : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the armor type identifier.
        /// </summary>
        /// <value>
        /// The armor type identifier.
        /// </value>
        public int ArmorTypeID { get; set; }
        /// <summary>
        /// Gets or sets the armor type description.
        /// </summary>
        /// <value>
        /// The armor type description.
        /// </value>
        public string ArmorTypeName { get; set; }
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// The speed.
        /// </value>
        public int ArmorCheckPenalty { get; set; }
        /// <summary>
        /// Gets or sets the speed for a character that normally moves 6 squares.
        /// </summary>
        /// <value>
        /// The speed_6.
        /// </value>
        public int Speed_6 { get; set; }
        /// <summary>
        /// Gets or sets the speed for a character that normally moves 4squares.
        /// </summary>
        /// <value>
        /// The speed_4.
        /// </value>
        public int Speed_4 { get; set; }
        /// <summary>
        /// Gets or sets the speed for a character that normally moves 8 squares.
        /// </summary>
        /// <value>
        /// The speed_8.
        /// </value>
        public int Speed_8 { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorType"/> class.
        /// </summary>
        public ArmorType()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorType"/> class and Retrieves data by the ArmorTypeName
        /// </summary>
        /// <param name="ArmorTypeName">Name of the ArmorType.</param>
        public ArmorType(string ArmorTypeName)
        {
            SetBaseConstructorOptions();
            GetArmorType(ArmorTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorType"/> class and Retrieves data by the ArmorTypeID.
        /// </summary>
        /// <param name="ArmorTypeID">The ArmorType identifier.</param>
        public ArmorType(int ArmorTypeID)
        {
            SetBaseConstructorOptions();
            GetArmorType(ArmorTypeID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the armor type object by the ArmorTypeID
        /// </summary>
        /// <param name="ArmorTypeID">The armor type identifier.</param>
        /// <returns>ArmorType object</returns>
        public ArmorType GetArmorType(int ArmorTypeID)
        {
            return GetSingleArmorType("Select_ArmorType", "  ArmorTypeID=" + ArmorTypeID.ToString(), "ArmorTypeName");
        }

        /// <summary>
        /// Gets the type of the armor by the Armor Type Name
        /// </summary>
        /// <param name="ArmorTypeName">Name of the armor type.</param>
        /// <returns>ArmorType object</returns>
        public ArmorType GetArmorType(string ArmorTypeName)
        {
            return GetSingleArmorType("Select_ArmorType", "  ArmorTypeName='" + ArmorTypeName + "'", "ArmorTypeName");
        }

        /// <summary>
        /// Saves the current instance of the armor type object.
        /// </summary>
        /// <returns>ArmorType object</returns>
        public ArmorType SaveArmorType ()
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
                command.CommandText = "InsertUpdate_ArmorType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorTypeID", SqlDbType.Int, ArmorTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorTypeName", SqlDbType.VarChar, ArmorTypeName.ToString(), 1000));
                //command.Parameters.Add(dbconn.GenerateParameterObj("@Speed", SqlDbType.Int, Speed.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorCheckPenalty", SqlDbType.Int, ArmorCheckPenalty.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Speed_6", SqlDbType.Int, Speed_6.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Speed_4", SqlDbType.Int, Speed_4.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Speed_8", SqlDbType.Int, Speed_8.ToString(), 0));
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
        /// Delete the ArmorType object from the database (by ArmorTypeID)
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteArmorType()
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
                command.CommandText = "Delete_ArmorType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorTypeID", SqlDbType.Int, ArmorTypeID.ToString(), 0));
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
        /// Gets a list of ArmorType objects by the strWhere parameter and orders them by the strOrderBy parameter
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderby">The string orderby.</param>
        /// <returns>List of ArmorType objects</returns>
        public List<ArmorType> GetArmorTypes(string strWhere, string strOrderby)
        {
            return GetArmorTypeList("Select_ArmorType", strWhere, strOrderby);
        }

        /// <summary>
        /// Validates this instance of the ArmorType object.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            if (string.IsNullOrEmpty(this.ArmorTypeName))
            {
                this._validated = false;
                this._validationMessage.Append("The Armor Type Name cannot be blank or null.");
            }
            return this.Validated;
        }

        #region Static Methods
        /// <summary>
        /// Clones the specified object ArmorType.
        /// </summary>
        /// <param name="objArmorType">The object ArmorType.</param>
        /// <returns>ArmorType</returns>
        static public ArmorType Clone(ArmorType objArmorType)
        {
                       
            ArmorType objCArmorType = new ArmorType();
            if (objArmorType.ArmorTypeID != 0) objCArmorType.GetArmorType(objArmorType.ArmorTypeID);
            else
            {
                objCArmorType.ArmorTypeID = 0;
                objCArmorType.ArmorTypeName = objArmorType.ArmorTypeName;
                objCArmorType.ArmorCheckPenalty = objArmorType.ArmorCheckPenalty;
                objCArmorType.Speed_6 = objArmorType.Speed_6;
                objCArmorType.Speed_4 = objArmorType.Speed_4;
                objCArmorType.Speed_8 = objArmorType.Speed_8;
            }

            return objCArmorType;
        }

        /// <summary>
        /// Clones the specified List of ArmorType objects.
        /// </summary>
        /// <param name="lstArmorType">The LST ArmorType.</param>
        /// <returns>List of ArmorType objects</returns>
        static public List<ArmorType> Clone(List<ArmorType> lstArmorType)
        {
            List<ArmorType> lstCArmorType = new List<ArmorType>();

            foreach (ArmorType objArmorType in lstArmorType)
            {
                lstCArmorType.Add(ArmorType.Clone(objArmorType));
            }

            return lstCArmorType;
        }
        #endregion
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single ArmorType from the Database.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>ArmorType object</returns>
        private ArmorType GetSingleArmorType(string sprocName, string strWhere, string strOrderBy)
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
        ///  Gets a list of ArmorTypes from the Database.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ArmorType objects</returns>
        private List<ArmorType> GetArmorTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ArmorType> armorTypes = new List<ArmorType>();

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
                    ArmorType objArmorType = new ArmorType();
                    SetReaderToObject(ref objArmorType, ref result);
                    armorTypes.Add(objArmorType);
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
            return armorTypes;
        }

        /// <summary>
        /// Sets the reader to this instance of the object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ArmorTypeID = (int)result.GetValue(result.GetOrdinal("ArmorTypeID"));
                this.ArmorTypeName = result.GetValue(result.GetOrdinal("ArmorTypeName")).ToString();
                //this.Speed = (int)result.GetValue(result.GetOrdinal("Speed"));
                this.ArmorCheckPenalty = (int)result.GetValue(result.GetOrdinal("ArmorCheckPenalty"));
                this.Speed_6 = (int)result.GetValue(result.GetOrdinal("Speed_6"));
                this.Speed_4 = (int)result.GetValue(result.GetOrdinal("Speed_4"));
                this.Speed_8 = (int)result.GetValue(result.GetOrdinal("Speed_8"));

            }
        }

        /// <summary>
        /// Sets the reader to the Paramter ArmorType object.
        /// </summary>
        /// <param name="objArmorType">Type of the object armor.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref ArmorType objArmorType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objArmorType.ArmorTypeID = (int)result.GetValue(result.GetOrdinal("ArmorTypeID"));
                objArmorType.ArmorTypeName = result.GetValue(result.GetOrdinal("ArmorTypeName")).ToString();
                //objArmorType.Speed = (int)result.GetValue(result.GetOrdinal("Speed"));
                objArmorType.ArmorCheckPenalty = (int)result.GetValue(result.GetOrdinal("ArmorCheckPenalty"));
                objArmorType.Speed_6 = (int)result.GetValue(result.GetOrdinal("Speed_6"));
                objArmorType.Speed_4 = (int)result.GetValue(result.GetOrdinal("Speed_4"));
                objArmorType.Speed_8 = (int)result.GetValue(result.GetOrdinal("Speed_8"));
            }
        }
        #endregion
        #endregion
    }
}
