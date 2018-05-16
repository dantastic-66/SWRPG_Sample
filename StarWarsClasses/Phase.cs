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
    public class Phase:BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the phase identifier.
        /// </summary>
        /// <value>
        /// The phase identifier.
        /// </value>
        public int PhaseID { get; set; }
        /// <summary>
        /// Gets or sets the name of the phase.
        /// </summary>
        /// <value>
        /// The name of the phase.
        /// </value>
        public string PhaseName { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Phase"/> class.
        /// </summary>
        public Phase()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Phase"/> class.
        /// </summary>
        /// <param name="PhaseName">Name of the Phase.</param>
        public Phase(string PhaseName)
        {
            SetBaseConstructorOptions();
            GetPhase(PhaseName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Phase"/> class.
        /// </summary>
        /// <param name="PhaseID">The Phase identifier.</param>
        public Phase(int PhaseID)
        {
            SetBaseConstructorOptions();
            GetPhase(PhaseID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the phase.
        /// </summary>
        /// <param name="PhaseID">The phase identifier.</param>
        /// <returns>Phase object</returns>
        public Phase GetPhase(int PhaseID)
        {
            return GetSinglePhase("Select_Phase", "  PhaseID=" + PhaseID.ToString(), "");
        }

        /// <summary>
        /// Gets the phase.
        /// </summary>
        /// <param name="PhaseName">Name of the phase.</param>
        /// <returns>Phase  object</returns>
        public Phase GetPhase(string PhaseName)
        {
            return GetSinglePhase("Select_Phase", "  PhaseName='" + PhaseName + "'", "");
        }

        /// <summary>
        /// Gets the phases.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Phase objects</returns>
        public List<Phase> GetPhases(string strWhere, string strOrderBy)
        {
            return GetPhaseList("Select_Phase", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the Phase.
        /// </summary>
        /// <returns>Phase objects</returns>
        public Phase SavePhase()
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
                command.CommandText = "InsertUpdate_Phase";
                command.Parameters.Add(dbconn.GenerateParameterObj("@PhaseID", SqlDbType.Int, PhaseID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PhaseName", SqlDbType.VarChar, PhaseName.ToString(), 50));
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
        /// Deletes the Phase item.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeletePhase()
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
                command.CommandText = "Delete_Phase";
                command.Parameters.Add(dbconn.GenerateParameterObj("@PhaseID", SqlDbType.Int, PhaseID.ToString(), 0));
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
        /// <returns>boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.PhaseName))
            {
                this._validated = false;
                this._validationMessage.Append("The Phase Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object Phase.
        /// </summary>
        /// <param name="objPhase">The object Phase.</param>
        /// <returns>Phase</returns>
        static public Phase Clone(Phase objPhase)
        {
            Phase objCPhase = new Phase(objPhase.PhaseID);
            return objCPhase;
        }

        /// <summary>
        /// Clones the specified LST Phase.
        /// </summary>
        /// <param name="lstPhase">The LST Phase.</param>
        /// <returns>List<Phase></returns>
        static public List<Phase> Clone(List<Phase> lstPhase)
        {
            List<Phase> lstCPhase = new List<Phase>();

            foreach (Phase objPhase in lstPhase)
            {
                lstCPhase.Add(Phase.Clone(objPhase));
            }

            return lstCPhase;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single phase.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Phase object</returns>
        private Phase GetSinglePhase(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the phase list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Phase objects</returns>
        private List<Phase> GetPhaseList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Phase> phases = new List<Phase>();

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
                    Phase objPhase = new Phase();
                    SetReaderToObject(ref objPhase, ref result);
                    phases.Add(objPhase);
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
            return phases;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.PhaseID = (int)result.GetValue(result.GetOrdinal("PhaseID"));
                this.PhaseName = result.GetValue(result.GetOrdinal("PhaseName")).ToString();

                this._objComboBoxData.Add(this.PhaseID, this.PhaseName);

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objPhase">The object phase.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Phase objPhase, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objPhase.PhaseID = (int)result.GetValue(result.GetOrdinal("PhaseID"));
                objPhase.PhaseName = result.GetValue(result.GetOrdinal("PhaseName")).ToString();

                objPhase._objComboBoxData.Add(objPhase.PhaseID, objPhase.PhaseName);
            }
        }
        #endregion
        #endregion
    }
}
