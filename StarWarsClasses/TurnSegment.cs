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
    public class TurnSegment:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the turn segment identifier.
        /// </summary>
        /// <value>
        /// The turn segment identifier.
        /// </value>
        public int TurnSegmentID { get; set; }
        /// <summary>
        /// Gets or sets the name of the turn segment.
        /// </summary>
        /// <value>
        /// The name of the turn segment.
        /// </value>
        public string TurnSegmentName { get; set; }
        /// <summary>
        /// Gets or sets the turn segment description.
        /// </summary>
        /// <value>
        /// The turn segment description.
        /// </value>
        public string TurnSegmentDescription { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TurnSegment"/> class.
        /// </summary>
        public TurnSegment()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnSegment"/> class.
        /// </summary>
        /// <param name="TurnSegmentName">Name of the TurnSegment.</param>
        public TurnSegment(string TurnSegmentName)
        {
            SetBaseConstructorOptions();
            GetTurnSegment(TurnSegmentName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnSegment"/> class.
        /// </summary>
        /// <param name="TurnSegmentID">The TurnSegment identifier.</param>
        public TurnSegment(int TurnSegmentID)
        {
            SetBaseConstructorOptions();
            GetTurnSegment(TurnSegmentID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the turn segment.
        /// </summary>
        /// <param name="TurnSegmentID">The turn segment identifier.</param>
        /// <returns>TurnSegment object</returns>
        public TurnSegment GetTurnSegment(int TurnSegmentID)
        {
            return GetSingleTurnSegment("Select_TurnSegment", "  TurnSegmentID=" + TurnSegmentID.ToString(), "");
         }

        /// <summary>
        /// Gets the turn segment.
        /// </summary>
        /// <param name="TurnSegmentName">Name of the turn segment.</param>
        /// <returns>TurnSegment object</returns>
        public TurnSegment GetTurnSegment(string TurnSegmentName)
        {
            return GetSingleTurnSegment("Select_TurnSegment", "  TurnSegmentName='" + TurnSegmentName +"'", "");
        }

        /// <summary>
        /// Gets the turn segments.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TurnSegment objects</returns>
        public List<TurnSegment> GetTurnSegments(string strWhere, string strOrderBy)
        {
            return GetTurnSegmentList("Select_TurnSegment", strWhere, strOrderBy);
            //List<TurnSegment> TurnSegments = new List<TurnSegment>();

            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "Select_TurnSegment";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
            //    result = command.ExecuteReader();

            //    while (result.Read())
            //    {
            //        TurnSegment objTurnSegment = new TurnSegment();
            //        SetReaderToObject(ref objTurnSegment, ref result);
            //        TurnSegments.Add(objTurnSegment);
            //    }
            //}
            //catch
            //{
            //    Exception e = new Exception();
            //    throw e;
            //}
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
            //return TurnSegments;
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.TurnSegmentName))
            {
                this._validated = false;
                this._validationMessage.Append("The Turn Segment Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Saves the turn segment.
        /// </summary>
        /// <returns>TurnSegment object</returns>
        public TurnSegment SaveTurnSegment()
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
                command.CommandText = "InsertUpdate_TurnSegment";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TurnSegmentID", SqlDbType.Int, TurnSegmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TurnSegmentName", SqlDbType.VarChar, TurnSegmentName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TurnSegmentDescription", SqlDbType.VarChar, TurnSegmentDescription.ToString(), 100));
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
        /// Deletes the turn segment.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteTurnSegment()
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
                command.CommandText = "Delete_TurnSegment";
                command.Parameters.Add(dbconn.GenerateParameterObj("@TurnSegmentID", SqlDbType.Int, TurnSegmentID.ToString(), 0));
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
        /// Clones the specified object TurnSegment.
        /// </summary>
        /// <param name="objTurnSegment">The object TurnSegment.</param>
        /// <returns>TurnSegment</returns>
        static public TurnSegment Clone(TurnSegment objTurnSegment)
        {
            TurnSegment objCTurnSegment = new TurnSegment(objTurnSegment.TurnSegmentID);
            return objCTurnSegment;
        }

        /// <summary>
        /// Clones the specified LST TurnSegment.
        /// </summary>
        /// <param name="lstTurnSegment">The LST TurnSegment.</param>
        /// <returns>List<TurnSegment></returns>
        static public List<TurnSegment> Clone(List<TurnSegment> lstTurnSegment)
        {
            List<TurnSegment> lstCTurnSegment = new List<TurnSegment>();

            foreach (TurnSegment objTurnSegment in lstTurnSegment)
            {
                lstCTurnSegment.Add(TurnSegment.Clone(objTurnSegment));
            }

            return lstCTurnSegment;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single turn segment.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>TurnSegment object</returns>
        private TurnSegment GetSingleTurnSegment(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the turn segment list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of TurnSegment objects</returns>
        private List<TurnSegment> GetTurnSegmentList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<TurnSegment> turnSegments = new List<TurnSegment>();

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
                    TurnSegment objTurnSegment = new TurnSegment();
                    SetReaderToObject(ref objTurnSegment, ref result);
                    turnSegments.Add(objTurnSegment);
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
            return turnSegments;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.TurnSegmentID = (int)result.GetValue(result.GetOrdinal("TurnSegmentID"));
                this.TurnSegmentName = result.GetValue(result.GetOrdinal("TurnSegmentName")).ToString();
                this.TurnSegmentDescription = result.GetValue(result.GetOrdinal("TurnSegmentDescription")).ToString();

                this._objComboBoxData.Add(this.TurnSegmentID, this.TurnSegmentName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objTurnSegment">The object turn segment.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref TurnSegment objTurnSegment, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objTurnSegment.TurnSegmentID = (int)result.GetValue(result.GetOrdinal("TurnSegmentID"));
                objTurnSegment.TurnSegmentName = result.GetValue(result.GetOrdinal("TurnSegmentName")).ToString();
                objTurnSegment.TurnSegmentDescription = result.GetValue(result.GetOrdinal("TurnSegmentDescription")).ToString();

                objTurnSegment._objComboBoxData.Add(objTurnSegment.TurnSegmentID, objTurnSegment.TurnSegmentName);

            }
        }
        #endregion
        #endregion
    }
}
