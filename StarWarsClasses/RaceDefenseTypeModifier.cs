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
    public class RaceDefenseTypeModifier:BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the race identifier.
        /// </summary>
        /// <value>
        /// The race identifier.
        /// </value>
        public int RaceID { get; set; }
        /// <summary>
        /// Gets or sets the defense type identifier.
        /// </summary>
        /// <value>
        /// The defense type identifier.
        /// </value>
        public int DefenseTypeID {get;set;}
        /// <summary>
        /// Gets or sets the modifier identifier.
        /// </summary>
        /// <value>
        /// The modifier identifier.
        /// </value>
        public int ModifierID {get; set; }

        /// <summary>
        /// Gets or sets the type of the object defense.
        /// </summary>
        /// <value>
        /// The type of the object defense.
        /// </value>
        public DefenseType objDefenseType { get; set; }
        /// <summary>
        /// Gets or sets the object modifier.
        /// </summary>
        /// <value>
        /// The object modifier.
        /// </value>
        public Modifier objModifier {get;set;}
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RaceDefenseTypeModifier"/> class.
        /// </summary>
        public RaceDefenseTypeModifier()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceDefenseTypeModifier"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        /// <param name="DefenseTypeID">The DefenseTypeidentifier.</param>
        public RaceDefenseTypeModifier(int RaceID, int DefenseTypeID)
        {
            SetBaseConstructorOptions();
            GetRaceDefenseTypeModifier(RaceID, DefenseTypeID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceDefenseTypeModifier"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        /// <param name="DefenseTypeID">The DefenseType identifier.</param>
        /// <param name="ModifierID">The Modifier identifier.</param>

        public RaceDefenseTypeModifier(int RaceID, int DefenseTypeID, int ModifierID)
        {
            SetBaseConstructorOptions();
            GetRaceDefenseTypeModifier(RaceID, DefenseTypeID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the race defense type modifier.
        /// </summary>
        /// <param name="RaceID">The race identifier.</param>
        /// <param name="DefenseTypeID">The defense type identifier.</param>
        /// <returns>RaceDefenseTypeModifier object</returns>
        public RaceDefenseTypeModifier GetRaceDefenseTypeModifier(int RaceID, int DefenseTypeID)
        {
            return GetSingleRaceDefenseTypeModifier("Select_RaceDefenseTypeModifier", "  RaceID=" + RaceID.ToString() + " AND DefenseTypeID=" + DefenseTypeID.ToString(), "");
         }

        /// <summary>
        /// Gets the race defense type modifier.
        /// </summary>
        /// <param name="RaceID">The race identifier.</param>
        /// <param name="DefenseTypeID">The defense type identifier.</param>
        /// <param name="ModifierID">The Modifier identifier.</param>
        /// <returns>RaceDefenseTypeModifier object</returns>
        public RaceDefenseTypeModifier GetRaceDefenseTypeModifier(int RaceID, int DefenseTypeID, int ModifierID)
        {
            return GetSingleRaceDefenseTypeModifier("Select_RaceDefenseTypeModifier", "  RaceID=" + RaceID.ToString() + " AND DefenseTypeID=" + DefenseTypeID.ToString() + " AND ModifierID= " + ModifierID.ToString(), "");
        }

        /// <summary>
        /// Gets the race defense type modifiers by race.
        /// </summary>
        /// <param name="RaceID">The race identifier.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of RaceDefenseTypeModifier objects</returns>
        public List<RaceDefenseTypeModifier> GetRaceDefenseTypeModifiersByRace (int RaceID, string strOrderBy)
        {
            //string strWhere = "";
            //strWhere = " RaceID=" + RaceID.ToString() + " AND [otmRaceDefenseTypeModifier].DefenseTypeID=" + objDefenseType.DefenseTypeID.ToString();
            //return GetRaceDefenseTypeModifierList("Select_RaceDefenseTypeModifier", strWhere, strOrderBy);
            //This one is different!!!! Have to loop through each defense type individually to get the where clause.
            List<DefenseType> objDefenseTypes = new List<DefenseType>();
            DefenseType objDefType = new DefenseType();
            objDefenseTypes = objDefType.GetRaceDefenseTypes("", "");

            string strWhere = "";
            List<RaceDefenseTypeModifier> raceDefenseTypeModifier = new List<RaceDefenseTypeModifier>();

            try
            {


                foreach (DefenseType objDefenseType in objDefenseTypes)
                {

                    SqlDataReader result;
                    DatabaseConnection dbconn = new DatabaseConnection();
                    SqlCommand command = new SqlCommand();
                    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

                    strWhere = " RaceID=" + RaceID.ToString() + " AND [otmRaceDefenseTypeModifier].DefenseTypeID=" + objDefenseType.DefenseTypeID.ToString();

                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Select_RaceDefenseTypeModifier";
                    command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
                    command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
                    result = command.ExecuteReader();

                    while (result.Read())
                    {
                        RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
                        SetReaderToObject(ref objRaceDefenseTypeModifier, ref result);
                        raceDefenseTypeModifier.Add(objRaceDefenseTypeModifier);
                    }

                    command.Dispose();
                    connection.Close();
                }
            }
            catch
            {
                Exception e = new Exception();
                throw e;
            }

            return raceDefenseTypeModifier;

        }

        /// <summary>
        /// Gets the race defense type modifiers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of RaceDefenseTypeModifier objects</returns>
        public List<RaceDefenseTypeModifier> GetRaceDefenseTypeModifiers(string strWhere, string strOrderBy)
        {
            return GetRaceDefenseTypeModifierList("Select_RaceDefenseTypeModifier", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the race defense type modifier.
        /// </summary>
        /// <returns>RaceDefenseTypeModifier object</returns>
        public RaceDefenseTypeModifier SaveRaceDefenseTypeModifier()
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
                command.CommandText = "InsertUpdate_RaceDefenseTypeModifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
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
        /// Deletes the race defense type modifier.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteRaceDefenseTypeModifier()
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
                command.CommandText = "Delete_RaceDefenseTypeModifier";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
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

            this._validated = true;

            ////Put Validation checks here
            if (this.RaceID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Race ID cannot be blank or null.");
            }

            if (this.DefenseTypeID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Defense Type ID cannot be blank or null.");
            }

            if (this.ModifierID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Modifier ID cannot be blank or null.");
            }

            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object RaceDefenseTypeModifier.
        /// </summary>
        /// <param name="objRaceDefenseTypeModifier">The object RaceDefenseTypeModifier.</param>
        /// <returns>RaceDefenseTypeModifier</returns>
        static public RaceDefenseTypeModifier Clone(RaceDefenseTypeModifier objRaceDefenseTypeModifier)
        {
            RaceDefenseTypeModifier objCRaceDefenseTypeModifier = new RaceDefenseTypeModifier(objRaceDefenseTypeModifier.RaceID , objRaceDefenseTypeModifier.DefenseTypeID, objRaceDefenseTypeModifier.ModifierID  );
            return objCRaceDefenseTypeModifier;
        }

        /// <summary>
        /// Clones the specified LST RaceDefenseTypeModifier.
        /// </summary>
        /// <param name="lstRaceDefenseTypeModifier">The LST RaceDefenseTypeModifier.</param>
        /// <returns>List<RaceDefenseTypeModifier></returns>
        static public List<RaceDefenseTypeModifier> Clone(List<RaceDefenseTypeModifier> lstRaceDefenseTypeModifier)
        {
            List<RaceDefenseTypeModifier> lstCRaceDefenseTypeModifier = new List<RaceDefenseTypeModifier>();

            foreach (RaceDefenseTypeModifier objRaceDefenseTypeModifier in lstRaceDefenseTypeModifier)
            {
                lstCRaceDefenseTypeModifier.Add(RaceDefenseTypeModifier.Clone(objRaceDefenseTypeModifier));
            }

            return lstCRaceDefenseTypeModifier;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single race defense type modifier.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>RaceDefenseTypeModifier object</returns>
        private RaceDefenseTypeModifier GetSingleRaceDefenseTypeModifier(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the race defense type modifier list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of RaceDefenseTypeModifier objects</returns>
        private List<RaceDefenseTypeModifier> GetRaceDefenseTypeModifierList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<RaceDefenseTypeModifier> raceDefenseTypeModifiers = new List<RaceDefenseTypeModifier>();

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
                    RaceDefenseTypeModifier objRaceDefenseTypeModifier = new RaceDefenseTypeModifier();
                    SetReaderToObject(ref objRaceDefenseTypeModifier, ref result);
                    raceDefenseTypeModifiers.Add(objRaceDefenseTypeModifier);
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
            return raceDefenseTypeModifiers;
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
                this.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));

                Modifier objModifier = new Modifier();
                if (!(this.ModifierID == 0))
                {
                    objModifier.GetModifier(this.ModifierID);
                }
                this.objModifier = objModifier;

                DefenseType objDefenseType = new DefenseType();
                //List<DefenseType> DefenseTypes = new List<DefenseType>();

                if (!(this.RaceID == 0))
                {
                    //DefenseTypes = 
                    objDefenseType.GetRaceDefenseTypes(" RaceID=" + this.RaceID.ToString(), "");
                }
                this.objDefenseType = objDefenseType;
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objRaceDefenseTypeModifier">The object race defense type modifier.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref RaceDefenseTypeModifier objRaceDefenseTypeModifier, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objRaceDefenseTypeModifier.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));
                objRaceDefenseTypeModifier.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                objRaceDefenseTypeModifier.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));

                Modifier objModifier = new Modifier();
                if (!(objRaceDefenseTypeModifier.ModifierID == 0))
                {
                    objModifier.GetModifier(objRaceDefenseTypeModifier.ModifierID);
                }
                objRaceDefenseTypeModifier.objModifier = objModifier;

                DefenseType objDefenseType = new DefenseType();
                //List<DefenseType> DefenseTypes = new List<DefenseType>();

                if (!(objRaceDefenseTypeModifier.RaceID == 0))
                {
                    objDefenseType.GetRaceDefenseType(" RaceID=" + objRaceDefenseTypeModifier.RaceID.ToString() + " AND [otmRaceDefenseTypeModifier].DefenseTypeID=" + objRaceDefenseTypeModifier.DefenseTypeID.ToString(), "");
                }
                objRaceDefenseTypeModifier.objDefenseType = objDefenseType;
            }
        }
        #endregion
        #endregion
    }
}
