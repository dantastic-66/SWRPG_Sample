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
    public class ConditionTrack : BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the condition track identifier.
        /// </summary>
        /// <value>
        /// The condition track identifier.
        /// </value>
        public int ConditionTrackID { get; set; }
        /// <summary>
        /// Gets or sets the modifier.
        /// </summary>
        /// <value>
        /// The modifier.
        /// </value>
        public int Modifier { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionTrack"/> class.
        /// </summary>
        public ConditionTrack()
        {
            SetBaseConstructorOptions();
        }
         
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionTrack"/> class.
        /// </summary>
        /// <param name="ConditionTrackName">Name of the ConditionTrack.</param>
        public ConditionTrack(string ConditionTrackName)
        {
            SetBaseConstructorOptions();
            GetConditionTrack(ConditionTrackName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionTrack"/> class.
        /// </summary>
        /// <param name="ConditionTrackID">The ConditionTrack identifier.</param>
        public ConditionTrack(int ConditionTrackID)
        {
            SetBaseConstructorOptions();
            GetConditionTrack(ConditionTrackID);
        }

        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the condition track.
        /// </summary>
        /// <param name="ConditionTrackID">The condition track identifier.</param>
        /// <returns>ConditionTrack Object</returns>
        public ConditionTrack GetConditionTrack(int ConditionTrackID)
        {
            return GetSingleConditionTrack("Select_ConditionTrack", "  ConditionTrackID=" + ConditionTrackID.ToString(), "");
        }

        /// <summary>
        /// Gets the condition track.
        /// </summary>
        /// <param name="ConditionTrackName">Name of the condition track.</param>
        /// <returns>ConditionTrack Object</returns>
        public ConditionTrack GetConditionTrack(string ConditionTrackName)
        {
            return GetSingleConditionTrack("Select_ConditionTrack", "  Description='" + ConditionTrackName + "'", "");
        }

        /// <summary>
        /// Gets the condition tracks.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ConditionTrack Objects</returns>
        public List<ConditionTrack> GetConditionTracks(string strWhere, string strOrderBy)
        {
            return GetConditionTrackList("Select_ConditionTrack", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the ConditionTrack.
        /// </summary>
        /// <returns>ConditionTrack Object</returns>
        public ConditionTrack SaveConditionTrack()
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
                command.CommandText = "InsertUpdate_ConditionTrack";

                command.Parameters.Add(dbconn.GenerateParameterObj("@ConditionTrackID", SqlDbType.Int, ConditionTrackID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Modifier", SqlDbType.Int, Modifier.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Description", SqlDbType.VarChar , Description.ToString(), 200));
                
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
        /// Delete the ConditionTrack.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteConditionTrack()
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
                command.CommandText = "Delete_ConditionTrack";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ConditionTrackID", SqlDbType.Int, ConditionTrackID.ToString(), 0));
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
            if (string.IsNullOrEmpty(this.Description))
            {
                this._validated = false;
                this._validationMessage.Append("The Condition Track Description cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object ConditionTrack.
        /// </summary>
        /// <param name="objConditionTrack">The object ConditionTrack.</param>
        /// <returns>ConditionTrack</returns>
        static public ConditionTrack Clone(ConditionTrack objConditionTrack)
        {
            ConditionTrack objCConditionTrack = new ConditionTrack(objConditionTrack.ConditionTrackID);
            return objCConditionTrack;
        }

        /// <summary>
        /// Clones the specified LST ConditionTrack.
        /// </summary>
        /// <param name="lstConditionTrack">The LST ConditionTrack.</param>
        /// <returns>List<ConditionTrack></returns>
        static public List<ConditionTrack> Clone(List<ConditionTrack> lstConditionTrack)
        {
            List<ConditionTrack> lstCConditionTrack = new List<ConditionTrack>();

            foreach (ConditionTrack objConditionTrack in lstConditionTrack)
            {
                lstCConditionTrack.Add(ConditionTrack.Clone(objConditionTrack));
            }

            return lstCConditionTrack;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single condition track.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>ConditionTrack Object</returns>
        private ConditionTrack GetSingleConditionTrack(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the condition track list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ConditionTrack Objects</returns>
        private List<ConditionTrack> GetConditionTrackList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ConditionTrack> conditionTracks = new List<ConditionTrack>();

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
                    ConditionTrack objConditionTrack = new ConditionTrack();
                    SetReaderToObject(ref objConditionTrack, ref result);
                    conditionTracks.Add(objConditionTrack);
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
            return conditionTracks;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ConditionTrackID = (int)result.GetValue(result.GetOrdinal("ConditionTrackID"));
                this.Modifier = (int)result.GetValue(result.GetOrdinal("Modifier"));
                this.Description = result.GetValue(result.GetOrdinal("Description")).ToString();

                this._objComboBoxData.Add(this.ConditionTrackID, this.Description);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objConditionTrack">The object condition track.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref ConditionTrack objConditionTrack, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objConditionTrack.ConditionTrackID = (int)result.GetValue(result.GetOrdinal("ConditionTrackID"));
                objConditionTrack.Modifier = (int)result.GetValue(result.GetOrdinal("Modifier"));
                objConditionTrack.Description = result.GetValue(result.GetOrdinal("Description")).ToString();

                objConditionTrack._objComboBoxData.Add(objConditionTrack.ConditionTrackID, objConditionTrack.Description);
            }
        }
        #endregion
        #endregion
    }
}
