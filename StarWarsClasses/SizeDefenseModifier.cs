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
    public class SizeDefenseModifier:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the size identifier.
        /// </summary>
        /// <value>
        /// The size identifier.
        /// </value>
        public int SizeID { get; set; }
        /// <summary>
        /// Gets or sets the defense identifier.
        /// </summary>
        /// <value>
        /// The defense identifier.
        /// </value>
        public int DefenseTypeID { get; set; }
        /// <summary>
        /// Gets or sets the modifier identifier.
        /// </summary>
        /// <value>
        /// The modifier identifier.
        /// </value>
        public int ModifierID { get; set; }

        /// <summary>
        /// Gets or sets the object defense.
        /// </summary>
        /// <value>
        /// The object defense.
        /// </value>
        DefenseType objDefenseType { get; set; }
        /// <summary>
        /// Gets or sets the object modifier.
        /// </summary>
        /// <value>
        /// The object modifier.
        /// </value>
        Modifier objModifier { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SizeDefenseModifier"/> class.
        /// </summary>
        public SizeDefenseModifier()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizeDefenseModifier"/> class.
        /// </summary>
        /// <param name="SizeID">The Size identifier.</param>
        public SizeDefenseModifier(int SizeID)
        {
            SetBaseConstructorOptions();
            GetSizeDefenseModifier(SizeID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizeDefenseModifier"/> class.
        /// </summary>
        /// <param name="SizeID">The Size identifier.</param>
        /// <param name="DefenseID">The Defense identifier.</param>
        /// <param name="ModifierID">The Modifier identifier.</param>
        public SizeDefenseModifier(int SizeID, int DefenseID, int ModifierID)
        {
            SetBaseConstructorOptions();
            GetSizeDefenseModifier(SizeID, DefenseID, ModifierID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the size defense modifier.
        /// </summary>
        /// <param name="SizeID">The size identifier.</param>
        /// <returns>SizeDefenseModifier object</returns>
        public SizeDefenseModifier GetSizeDefenseModifier(int SizeID)
        {
            return GetSingleSizeDefenseModifier("Select_SizeDefenseModifier", " SizeID=" + SizeID.ToString(), "");
        }

        /// <summary>
        /// Gets the size defense modifier.
        /// </summary>
        /// <param name="SizeID">The size identifier.</param>
        /// <param name="DefenseID">The Defense identifier.</param>
        /// <param name="ModifierID">The Modifier identifier.</param>
        /// <returns>SizeDefenseModifier object</returns>
        public SizeDefenseModifier GetSizeDefenseModifier(int SizeID, int DefenseID, int ModifierID)
        {
            return GetSingleSizeDefenseModifier("Select_SizeDefenseModifier", " SizeID=" + SizeID.ToString() + " AND DefenseID=" + DefenseID.ToString() + " AND ModifierID=" + ModifierID.ToString(), "");
        }

        /// <summary>
        /// Gets the size defense modifiers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of SizeDefenseModifier objects</returns>
        public List<SizeDefenseModifier> GetSizeDefenseModifiers(string strWhere, string strOrderBy)
        {
            return GetSizeDefenseModifierList("Select_SizeDefenseModifier", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the size defense modifier.
        /// </summary>
        /// <returns>SizeDefenseModifier object</returns>
        public SizeDefenseModifier SaveSizeDefenseModifier()
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
                command.CommandText = "InsertUpdate_SizeDefenseModifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SizeID", SqlDbType.Int, SizeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierID", SqlDbType.Int, ModifierID.ToString(), 0));
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
        /// Deletes the size defense modifier.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteSizeDefenseModifier()
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
                command.CommandText = "Delete_SizeDefenseModifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SizeID", SqlDbType.Int, SizeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
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
        /// <returns>Boolean</returns>
        public override  bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (this.DefenseTypeID ==0)
            {
                this._validated = false;
                this._validationMessage.Append("The Defense ID cannot be blank or null.");
            }
            if (this.ModifierID  == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Modifier ID cannot be blank or null.");
            }
            if (this.SizeID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Size ID cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object SizeDefenseModifier.
        /// </summary>
        /// <param name="objSizeDefenseModifier">The object SizeDefenseModifier.</param>
        /// <returns>SizeDefenseModifier</returns>
        static public SizeDefenseModifier Clone(SizeDefenseModifier objSizeDefenseModifier)
        {
            SizeDefenseModifier objCSizeDefenseModifier = new SizeDefenseModifier(objSizeDefenseModifier.SizeID, objSizeDefenseModifier.DefenseTypeID, objSizeDefenseModifier.ModifierID );
            return objCSizeDefenseModifier;
        }

        /// <summary>
        /// Clones the specified LST SizeDefenseModifier.
        /// </summary>
        /// <param name="lstSizeDefenseModifier">The LST SizeDefenseModifier.</param>
        /// <returns>List<SizeDefenseModifier></returns>
        static public List<SizeDefenseModifier> Clone(List<SizeDefenseModifier> lstSizeDefenseModifier)
        {
            List<SizeDefenseModifier> lstCSizeDefenseModifier = new List<SizeDefenseModifier>();

            foreach (SizeDefenseModifier objSizeDefenseModifier in lstSizeDefenseModifier)
            {
                lstCSizeDefenseModifier.Add(SizeDefenseModifier.Clone(objSizeDefenseModifier));
            }

            return lstCSizeDefenseModifier;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the single size defense modifier.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>SizeDefenseModifier object</returns>
        private SizeDefenseModifier GetSingleSizeDefenseModifier(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the size defense modifier list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of SizeDefenseModifier objects</returns>
        private List<SizeDefenseModifier> GetSizeDefenseModifierList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<SizeDefenseModifier> sizeDefenseModifiers = new List<SizeDefenseModifier>();

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
                    SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();
                    SetReaderToObject(ref objSizeDefenseModifier, ref result);
                    sizeDefenseModifiers.Add(objSizeDefenseModifier);
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
            return sizeDefenseModifiers;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.SizeID = (int)result.GetValue(result.GetOrdinal("SizeID"));
                this.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseID"));
                this.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));

                DefenseType objDefenseType = new DefenseType();
                Modifier objModifier = new Modifier();

                this.objDefenseType = objDefenseType.GetDefenseType (this.DefenseTypeID);
                this.objModifier = objModifier.GetModifier(this.ModifierID);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objSizeDefenseModifier">The object size defense modifier.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SizeDefenseModifier objSizeDefenseModifier, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objSizeDefenseModifier.SizeID = (int)result.GetValue(result.GetOrdinal("SizeID"));
                objSizeDefenseModifier.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseID"));
                objSizeDefenseModifier.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));

                DefenseType objDefenseType = new DefenseType();
                Modifier objModifier = new Modifier();

                objSizeDefenseModifier.objDefenseType = objDefenseType.GetDefenseType(objSizeDefenseModifier.DefenseTypeID);
                objSizeDefenseModifier.objModifier = objModifier.GetModifier(objSizeDefenseModifier.ModifierID);

            }
        }
        #endregion
        #endregion
    }
}
