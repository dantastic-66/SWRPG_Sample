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
    public class Speed : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the speed identifier.
        /// </summary>
        /// <value>
        /// The speed identifier.
        /// </value>
        public int SpeedID { get; set; }
        /// <summary>
        /// Gets or sets the name of the speed.
        /// </summary>
        /// <value>
        /// The name of the speed.
        /// </value>
        public string SpeedName { get; set; }
        /// <summary>
        /// Gets or sets the speed rate.
        /// </summary>
        /// <value>
        /// The speed rate.
        /// </value>
        public int SpeedRate { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Speed"/> class.
        /// </summary>
        public Speed()
        {
            SetBaseConstructorOptions();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Speed"/> class.
        /// </summary>
        /// <param name="SpeedID">The Speed identifier.</param>
        public Speed(int SpeedID)
        {
            SetBaseConstructorOptions();
            GetSpeed(SpeedID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the speed.
        /// </summary>
        /// <param name="SpeedID">The speed identifier.</param>
        /// <returns>Speed object</returns>
        public Speed GetSpeed(int SpeedID)
        {
            return GetSingleSpeed("Select_Speed", " SpeedID=" + SpeedID.ToString(), "");
        }

        /// <summary>
        /// Gets the speeds.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Speed objects</returns>
        public List<Speed> GetSpeeds(string strWhere, string strOrderBy)
        {
            return GetSpeedList("Select_Speed", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the race speeds.
        /// </summary>
        /// <param name="intRaceID">The int race identifier.</param>
        /// <returns>List of Speed objects</returns>
        public List<Speed> GetRaceSpeeds(int intRaceID)
        {
            return GetSpeedList("Select_RaceSpeed", "RaceID=" + intRaceID.ToString(), "SpeedName");
        }

        public List<Speed> GetCharacterSpeeds(int intCharacterID)
        {
            return GetSpeedList("Select_CharacterSpeed", "CharacterID=" + intCharacterID.ToString(), "SpeedName");
        }

        /// <summary>
        /// Saves the speed.
        /// </summary>
        /// <returns>Speed object</returns>
        public Speed SaveSpeed()
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
                command.CommandText = "InsertUpdate_Speed";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SpeedID", SqlDbType.Int, SpeedID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SpeedName", SqlDbType.VarChar, SpeedName.ToString(), 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SpeedRate", SqlDbType.Int, SpeedRate.ToString(), 0));
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
        /// Deletes the Speed item.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteSpeed()
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
                command.CommandText = "Delete_Speed";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SpeedID", SqlDbType.Int, SpeedID.ToString(), 0));
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
            if (string.IsNullOrEmpty(this.SpeedName))
            {
                this._validated = false;
                this._validationMessage.Append("The Speed Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object Speed.
        /// </summary>
        /// <param name="objSpeed">The object Speed.</param>
        /// <returns>Speed</returns>
        static public Speed Clone(Speed objSpeed)
        {
            Speed objCSpeed = new Speed(objSpeed.SpeedID);
            return objCSpeed;
        }

        /// <summary>
        /// Clones the specified LST Speed.
        /// </summary>
        /// <param name="lstSpeed">The LST Speed.</param>
        /// <returns>List<Speed></returns>
        static public List<Speed> Clone(List<Speed> lstSpeed)
        {
            List<Speed> lstCSpeed = new List<Speed>();

            foreach (Speed objSpeed in lstSpeed)
            {
                lstCSpeed.Add(Speed.Clone(objSpeed));
            }

            return lstCSpeed;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the single speed.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Speed object</returns>
        private Speed GetSingleSpeed(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the speed list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Speed objects</returns>
        private List<Speed> GetSpeedList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Speed> Speeds = new List<Speed>();

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
                    Speed objSpeed = new Speed();
                    SetReaderToObject(ref objSpeed, ref result);
                    Speeds.Add(objSpeed);
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
            return Speeds;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.SpeedID = (int)result.GetValue(result.GetOrdinal("SpeedID"));
                this.SpeedName = result.GetValue(result.GetOrdinal("SpeedName")).ToString();
                this.SpeedRate = (int)result.GetValue(result.GetOrdinal("SpeedRate"));

                this._objComboBoxData.Add(this.SpeedID, this.SpeedName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objSpeed">The object speed.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Speed objSpeed, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objSpeed.SpeedID = (int)result.GetValue(result.GetOrdinal("SpeedID"));
                objSpeed.SpeedName = result.GetValue(result.GetOrdinal("SpeedName")).ToString();
                objSpeed.SpeedRate = (int)result.GetValue(result.GetOrdinal("SpeedRate"));

                objSpeed._objComboBoxData.Add(objSpeed.SpeedID, objSpeed.SpeedName);
            }
        }
        #endregion
        #endregion
    }
}
