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
    public class ForcePower :BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the force power identifier.
        /// </summary>
        /// <value>
        /// The force power identifier.
        /// </value>
        public int ForcePowerID { get; set; }
        /// <summary>
        /// Gets or sets the name of the force power.
        /// </summary>
        /// <value>
        /// The name of the force power.
        /// </value>
        public string ForcePowerName { get; set; }
        /// <summary>
        /// Gets or sets the force power description.
        /// </summary>
        /// <value>
        /// The force power description.
        /// </value>
        public string ForcePowerDescription { get; set; }
        /// <summary>
        /// Gets or sets the turn segment identifier.
        /// </summary>
        /// <value>
        /// The turn segment identifier.
        /// </value>
        public int TurnSegmentID { get; set; }
        /// <summary>
        /// Gets or sets the force power target.
        /// </summary>
        /// <value>
        /// The force power target.
        /// </value>
        public string ForcePowerTarget { get; set; }
        /// <summary>
        /// Gets or sets the force power special.
        /// </summary>
        /// <value>
        /// The force power special.
        /// </value>
        public string ForcePowerSpecial { get; set; }

        /// <summary>
        /// Gets or sets the object force power descriptors.
        /// </summary>
        /// <value>
        /// The object force power descriptors.
        /// </value>
        public List<ForcePowerDescriptor> objForcePowerDescriptors { get; set; }
        /// <summary>
        /// Gets or sets the object turn segment.
        /// </summary>
        /// <value>
        /// The object turn segment.
        /// </value>
        public TurnSegment objTurnSegment { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePower"/> class.
        /// </summary>
        public ForcePower()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePower"/> class.
        /// </summary>
        /// <param name="ForcePowerName">Name of the ForcePower.</param>
        public ForcePower(string ForcePowerName)
        {
            SetBaseConstructorOptions();
            GetForcePower(ForcePowerName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePower"/> class.
        /// </summary>
        /// <param name="ForcePowerID">The ForcePower identifier.</param>
        public ForcePower(int ForcePowerID)
        {
            SetBaseConstructorOptions();
            GetForcePower(ForcePowerID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the force power.
        /// </summary>
        /// <param name="ForcePowerID">The force power identifier.</param>
        /// <returns></returns>
        public ForcePower GetForcePower(int ForcePowerID)
        {
            return GetSingleForcePower("Select_ForcePower", "  ForcePowerID=" + ForcePowerID.ToString(), "");
        }

        /// <summary>
        /// Gets the force power.
        /// </summary>
        /// <param name="ForcePowerName">Name of the force power.</param>
        /// <returns></returns>
        public ForcePower GetForcePower(string ForcePowerName)
        {
            return GetSingleForcePower("Select_ForcePower", "  ForcePowerName='" + ForcePowerName +"'", "");
         }

        /// <summary>
        /// Gets the force powers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<ForcePower> GetForcePowers(string strWhere, string strOrderBy)
        {
            return GetForcePowerList("Select_ForcePower", strWhere, strOrderBy);
          }

        /// <summary>
        /// Gets the prestige required force powers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<ForcePower> GetPrestigeRequiredForcePowers(string strWhere, string strOrderBy)
        {
            return GetForcePowerList("Select_PrestigeRequiredForcePowers", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the talent prequiste force powers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<ForcePower> GetTalentPrequisteForcePowers(string strWhere, string strOrderBy)
        {
            return GetForcePowerList("Select_TalentPrerequisteForcePower", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the character force powers.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns></returns>
        public List<ForcePower> GetCharacterForcePowers (int CharacterID)
        {
            return GetForcePowerList("Select_CharacterForcePowers", "CharacterID=" + CharacterID.ToString(), "ForcePowerName");
        }

        /// <summary>
        /// Saves the character force power.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="ForcePowerID">The force power identifier.</param>
        /// <returns></returns>
        public ForcePower SaveCharacterForcePower (int CharacterID, int ForcePowerID)
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
                command.CommandText = "InsertUpdate_CharacterForcePower";

                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerID", SqlDbType.VarChar, ForcePowerID.ToString(), 1000));
                result = command.ExecuteReader();

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
            return GetForcePower(ForcePowerID);

        }

        /// <summary>
        /// Deletes the character force power.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="ForcePowerID">The force power identifier.</param>
        /// <returns></returns>
        public bool DeleteCharacterForcePower(int CharacterID, int ForcePowerID)
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
                command.CommandText = "Delete_CharacterForcePower";

                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerID", SqlDbType.VarChar, ForcePowerID.ToString(), 1000));
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
        /// Saves a List of ForcePowers to a Character.
        /// </summary>
        /// <param name="lstCharForcePower">A <List> of ForcePowers .</param>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <returns></returns>
        public void SaveCharacterForcePowers(List<ForcePower> lstCharForcePower, int intCharacterID)
        {
            ForcePower objDelForcePower = new ForcePower();
            objDelForcePower.DeleteCharacterForcePower(intCharacterID, 0);

            foreach (ForcePower objCharForcePower in lstCharForcePower)
            {
                objCharForcePower.SaveCharacterForcePower(intCharacterID, objCharForcePower.ForcePowerID);
            }
        }

        /// <summary>
        /// Saves the force power.
        /// </summary>
        /// <returns></returns>
        public ForcePower SaveForcePower()
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
                command.CommandText = "InsertUpdate_ForcePower";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerID", SqlDbType.Int, ForcePowerID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerName", SqlDbType.VarChar, ForcePowerName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerDescription", SqlDbType.VarChar, ForcePowerDescription.ToString(), 500));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TurnSegmentID", SqlDbType.Int, TurnSegmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerTarget", SqlDbType.VarChar, ForcePowerTarget.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerSpecial", SqlDbType.VarChar, ForcePowerDescription.ToString(), 1000));
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
        /// Deletes the extra class item.
        /// </summary>
        /// <returns></returns>
        public bool DeleteForcePower()
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
                command.CommandText = "Delete_ForcePower";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerID", SqlDbType.Int, ForcePowerID.ToString(), 0));
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
        /// <returns></returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.ForcePowerName))
            {
                this._validated = false;
                this._validationMessage.Append("The Force Power Name cannot be blank or null.");
            }
            return this.Validated;
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Determines whether [is force power in list] [the specified object force power].
        /// </summary>
        /// <param name="objForcePower">The object force power.</param>
        /// <param name="lstForcePower">The LST force power.</param>
        /// <returns></returns>
        static public bool IsForcePowerInList(ForcePower objForcePower, List<ForcePower> lstForcePower)
        {
            bool blnForcePowerFound = false;

            foreach (ForcePower lstObjForcePower in lstForcePower)
            {
                if (objForcePower.ForcePowerID == lstObjForcePower.ForcePowerID)
                {
                    blnForcePowerFound = true;
                }
            }

            return blnForcePowerFound;
        }

        /// <summary>
        /// Determines whether [is force power in list] [the specified LST need force powers].
        /// </summary>
        /// <param name="lstNeedForcePowers">The LST need force powers.</param>
        /// <param name="lstForcePowers">The LST force powers.</param>
        /// <returns></returns>
        static public bool IsForcePowerInList(List<ForcePower> lstNeedForcePowers, List<ForcePower> lstForcePowers)
        {
            bool blnAllForcePowersFound = true;
            bool blnForcePowerFound = false;

            foreach (ForcePower objNeededForcePower in lstNeedForcePowers)
            {
                foreach (ForcePower objForcePower in lstForcePowers)
                {
                    if (objNeededForcePower.ForcePowerID == objForcePower.ForcePowerID)
                    {
                        blnForcePowerFound = true;
                    }
                }
                if (blnAllForcePowersFound)
                {
                    blnAllForcePowersFound = blnForcePowerFound;
                }
            }

            return blnAllForcePowersFound;
        }

        /// <summary>
        /// Clones the specified object ForcePower.
        /// </summary>
        /// <param name="objForcePower">The object ForcePower.</param>
        /// <returns>ForcePower</returns>
        static public ForcePower Clone(ForcePower objForcePower)
        {
            ForcePower objCForcePower = new ForcePower(objForcePower.ForcePowerID);
            return objCForcePower;
        }

        /// <summary>
        /// Clones the specified LST ForcePower.
        /// </summary>
        /// <param name="lstForcePower">The LST ForcePower.</param>
        /// <returns>List<ForcePower></returns>
        static public List<ForcePower> Clone(List<ForcePower> lstForcePower)
        {
            List<ForcePower> lstCForcePower = new List<ForcePower>();

            foreach (ForcePower objForcePower in lstForcePower)
            {
                lstCForcePower.Add(ForcePower.Clone(objForcePower));
            }

            return lstCForcePower;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single force power.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private ForcePower GetSingleForcePower(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the force power list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private List<ForcePower> GetForcePowerList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ForcePower> forcePowers = new List<ForcePower>();

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
                    ForcePower objForcePower = new ForcePower();
                    SetReaderToObject(ref objForcePower, ref result);
                    forcePowers.Add(objForcePower);
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
            return forcePowers;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ForcePowerID = (int)result.GetValue(result.GetOrdinal("ForcePowerID"));
                this.ForcePowerName = result.GetValue(result.GetOrdinal("ForcePowerName")).ToString();
                this.ForcePowerDescription = result.GetValue(result.GetOrdinal("ForcePowerDescription")).ToString();
                //this.ForcePowerDescriptorID = (int)result.GetValue(result.GetOrdinal("ForcePowerDescriptorID"));
                this.TurnSegmentID = (int)result.GetValue(result.GetOrdinal("TurnSegmentID"));
                this.ForcePowerTarget = result.GetValue(result.GetOrdinal("ForcePowerTarget")).ToString();
                this.ForcePowerSpecial = result.GetValue(result.GetOrdinal("ForcePowerSpecial")).ToString();

                ForcePowerDescriptor FPD = new ForcePowerDescriptor();
                this.objForcePowerDescriptors = FPD.GetForcePowerForcePowerDescriptors(" ForcePowerID=" + this.ForcePowerID.ToString(), " ForcePowerDescriptorName ");

                if (this.TurnSegmentID != 0)
                {
                    TurnSegment TS = new TurnSegment();

                    this.objTurnSegment = TS.GetTurnSegment(this.TurnSegmentID);

                }

                this._objComboBoxData.Add(this.ForcePowerID, this.ForcePowerName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objForcePower">The object force power.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref ForcePower objForcePower, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objForcePower.ForcePowerID = (int)result.GetValue(result.GetOrdinal("ForcePowerID"));
                objForcePower.ForcePowerName = result.GetValue(result.GetOrdinal("ForcePowerName")).ToString();
                objForcePower.ForcePowerDescription = result.GetValue(result.GetOrdinal("ForcePowerDescription")).ToString();
                //objForcePower.ForcePowerDescriptorID = (int)result.GetValue(result.GetOrdinal("ForcePowerDescriptorID"));
                objForcePower.TurnSegmentID = (int)result.GetValue(result.GetOrdinal("TurnSegmentID"));
                objForcePower.ForcePowerTarget = result.GetValue(result.GetOrdinal("ForcePowerTarget")).ToString();
                objForcePower.ForcePowerSpecial = result.GetValue(result.GetOrdinal("ForcePowerSpecial")).ToString();

               
                ForcePowerDescriptor FPD = new ForcePowerDescriptor();
                objForcePower.objForcePowerDescriptors = FPD.GetForcePowerForcePowerDescriptors(" ForcePowerID=" + objForcePower.ForcePowerID.ToString(), " ForcePowerDescriptorName ");

               

                if (objForcePower.TurnSegmentID != 0)
                {
                    TurnSegment TS = new TurnSegment();

                    objForcePower.objTurnSegment = TS.GetTurnSegment(objForcePower.TurnSegmentID);

                }

                objForcePower._objComboBoxData.Add(objForcePower.ForcePowerID, objForcePower.ForcePowerName);
            }
        }
        #endregion

        #endregion

 
    }
}
