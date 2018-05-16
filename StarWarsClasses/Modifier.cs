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
    public class Modifier : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the modifier identifier.
        /// </summary>
        /// <value>
        /// The modifier identifier.
        /// </value>
        public int ModifierID { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [modifier positive].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [modifier positive]; otherwise, <c>false</c>.
        /// </value>
        public bool ModifierPositive { get; set; }
        /// <summary>
        /// Gets or sets the modifier number.
        /// </summary>
        /// <value>
        /// The modifier number.
        /// </value>
        public int ModifierNumber { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Modifier"/> class.
        /// </summary>
        public Modifier()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Modifier"/> class.
        /// </summary>
        /// <param name="ModifierID">The Modifier identifier.</param>
        public Modifier(int ModifierID)
        {
            SetBaseConstructorOptions();
            GetModifier(ModifierID);
        }
        #endregion
        
        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the modifier.
        /// </summary>
        /// <param name="ModifierID">The modifier identifier.</param>
        /// <returns>Modifier object</returns>
        public Modifier GetModifier(int ModifierID)
        {
            return GetSingleModifier("Select_Modifier", "  ModifierID=" + ModifierID.ToString(), ""); 
        }

        /// <summary>
        /// Gets the modifiers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderby">The string orderby.</param>
        /// <returns>List of Modifier</returns>
        public List<Modifier> GetModifiers(string strWhere, string strOrderby)
        {
            return GetModifierList("Select_Modifier", strWhere, strOrderby);
        }
        
        /// <summary>
        /// Saves the Modifier.
        /// </summary>
        /// <returns>Modifier object</returns>
        public Modifier SaveModifier()
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
                command.CommandText = "InsertUpdate_Modifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierID", SqlDbType.Int, ModifierID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierPositive", SqlDbType.Bit, ModifierPositive.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierNumber", SqlDbType.VarChar, ModifierNumber.ToString().ToString(), 0));
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
        /// Deletes the Modifier.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteModifier()
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
                command.CommandText = "Delete_Modifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierID", SqlDbType.Int, ModifierID.ToString(), 0));
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

            ////Put Validation checks here
            if (this.ModifierNumber == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Modifier Number cannot be zero (0).");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object Modifier.
        /// </summary>
        /// <param name="objModifier">The object Modifier.</param>
        /// <returns>Modifier</returns>
        static public Modifier Clone(Modifier objModifier)
        {
            Modifier objCModifier = new Modifier(objModifier.ModifierID);
            return objCModifier;
        }

        /// <summary>
        /// Clones the specified LST Modifier.
        /// </summary>
        /// <param name="lstModifier">The LST Modifier.</param>
        /// <returns>List<Modifier></returns>
        static public List<Modifier> Clone(List<Modifier> lstModifier)
        {
            List<Modifier> lstCModifier = new List<Modifier>();

            foreach (Modifier objModifier in lstModifier)
            {
                lstCModifier.Add(Modifier.Clone(objModifier));
            }

            return lstCModifier;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single modifier.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Modifier objecct</returns>
        private Modifier GetSingleModifier(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the modifier list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Modifier</returns>
        private List<Modifier> GetModifierList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Modifier> modifiers = new List<Modifier>();

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
                    Modifier objModifier = new Modifier();
                    SetReaderToObject(ref objModifier, ref result);
                    modifiers.Add(objModifier);
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
            return modifiers;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));
                this.ModifierPositive = (bool) result.GetValue(result.GetOrdinal("ModifierPositive"));
                this.ModifierNumber = (int)result.GetValue(result.GetOrdinal("ModifierNumber"));
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objModifier">The object modifier.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Modifier objModifier, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objModifier.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));
                objModifier.ModifierPositive = (bool) result.GetValue(result.GetOrdinal("ModifierPositive"));
                objModifier.ModifierNumber = (int)result.GetValue(result.GetOrdinal("ModifierNumber"));
            }
        }
        #endregion
        #endregion
    }
}
