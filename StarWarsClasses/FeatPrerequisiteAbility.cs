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
    public class FeatPrerequisiteAbility : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the feat identifier.
        /// </summary>
        /// <value>
        /// The feat identifier.
        /// </value>
        public int FeatID { get; set; }
        /// <summary>
        /// Gets or sets the ability identifier.
        /// </summary>
        /// <value>
        /// The ability identifier.
        /// </value>
        public int AbilityID { get; set; }
        /// <summary>
        /// Gets or sets the ability minimum.
        /// </summary>
        /// <value>
        /// The ability minimum.
        /// </value>
        public int AbilityMinimum { get; set; }

        /// <summary>
        /// Gets or sets the object ability.
        /// </summary>
        /// <value>
        /// The object ability.
        /// </value>
        public Ability objAbility { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatPrerequisiteAbility"/> class.
        /// </summary>
        public FeatPrerequisiteAbility()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatPrerequisiteAbility"/> class.
        /// </summary>
        /// <param name="FeatID">The Feat identifier.</param>
        /// <param name="AbilityID">The Ability identifier.</param>
        public FeatPrerequisiteAbility(int FeatID, int AbilityID)
        {
            SetBaseConstructorOptions();
            GetFeatPrerequisiteAbility(FeatID, AbilityID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the feat prerequisite ability.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public FeatPrerequisiteAbility GetFeatPrerequisiteAbility(string strWhere, string strOrderBy)
        {
            return GetSingleFeatPrerequisiteAbility("Select_FeatPrerequisiteAbility",strWhere,strOrderBy );
        }

        public FeatPrerequisiteAbility GetFeatPrerequisiteAbility(int intFeatID, int intAbilityID)
        {
            return GetSingleFeatPrerequisiteAbility("Select_FeatPrerequisiteAbility", "FeatID=" + intFeatID.ToString() + " AND AbilityID=" + intAbilityID.ToString(), "");
        }

        //public Feat GetFeat(string FeatName)
        //{
        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Select_Feat";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, "  FeatName=" + FeatName, 1000));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, " FeatDescription ", 1000));
        //        result = command.ExecuteReader();
        //        if (result.HasRows)
        //        {
        //            result.Read();
        //            SetReaderToObject(ref result);
        //        }
        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        throw e;
        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return this;

        //}

        /// <summary>
        /// Gets the feat prerequisite abilites.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<FeatPrerequisiteAbility> GetFeatPrerequisiteAbilites(string strWhere, string strOrderBy)
        {
             return GetFeatPrerequisiteAbilityList("Select_FeatPrerequisiteAbility",strWhere,strOrderBy );
        }

        //public List<Feat> GetPrestigeRequiredFeats(string strWhere, string strOrderBy)
        //{
        //    List<Feat> feats = new List<Feat>();

        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Select_PrestigeRequiredFeats";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
        //        result = command.ExecuteReader();

        //        while (result.Read())
        //        {
        //            Feat feat = new Feat();
        //            SetReaderToObject(ref feat, ref result);
        //            feats.Add(feat);
        //        }
        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        throw e;
        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return feats;
        //}

        //public List<Feat> GetPrestigeRequiredFeatGroups(string strWhere, string strOrderBy)
        //{
        //    List<Feat> feats = new List<Feat>();

        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Select_PrestigeRequiredFeatGroups";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
        //        result = command.ExecuteReader();

        //        while (result.Read())
        //        {
        //            Feat feat = new Feat();
        //            SetReaderToObject(ref feat, ref result);
        //            feats.Add(feat);
        //        }
        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        throw e;
        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return feats;
        //}

        //public List<Feat> GetFeats(string strWhere, string strOrderby)
        //{
        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

        //    List<Feat> Feats = new List<Feat>();
        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Select_Feat";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderby, 1000));
        //        result = command.ExecuteReader();

        //        while (result.Read())
        //        {
        //            Feat feat = new Feat();
        //            SetReaderToObject(ref feat, ref result);
        //            Feats.Add(feat);
        //        }
        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        throw e;
        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return Feats;

        //}

        //public Feat SaveFeat()
        //{

        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "InsertUpdate_Feat";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@FeatName", SqlDbType.VarChar, FeatName.ToString(), 50));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@FeatDescription", SqlDbType.VarChar, FeatDescription.ToString(), 400));
        //        result = command.ExecuteReader();

        //        result.Read();
        //        SetReaderToObject(ref result);

        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        this._validated = false;
        //        this._validationMessage.Append(e.Message.ToString());
        //        throw e;
        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return this;
        //}

        /// <summary>
        /// Saves the extra class item.
        /// </summary>
        /// <returns></returns>
        public FeatPrerequisiteAbility SaveFeatPrerequisiteAbility()
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
                command.CommandText = "InsertUpdate_FeatPrequisiteAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMinimum", SqlDbType.Int, AbilityMinimum.ToString(), 0));
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
        public bool DeleteFeatPrerequisiteAbility()
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
                command.CommandText = "Delete_FeatPrequisiteAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
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
            if (this.AbilityMinimum == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Ability Minimum cannot be zero (0).");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object FeatPrerequisiteAbility.
        /// </summary>
        /// <param name="objFeatPrerequisiteAbility">The object FeatPrerequisiteAbility.</param>
        /// <returns>FeatPrerequisiteAbility</returns>
        static public FeatPrerequisiteAbility Clone(FeatPrerequisiteAbility objFeatPrerequisiteAbility)
        {
            FeatPrerequisiteAbility objCFeatPrerequisiteAbility = new FeatPrerequisiteAbility(objFeatPrerequisiteAbility.FeatID,objFeatPrerequisiteAbility.AbilityID );
            return objCFeatPrerequisiteAbility;
        }

        /// <summary>
        /// Clones the specified LST FeatPrerequisiteAbility.
        /// </summary>
        /// <param name="lstFeatPrerequisiteAbility">The LST FeatPrerequisiteAbility.</param>
        /// <returns>List<FeatPrerequisiteAbility></returns>
        static public List<FeatPrerequisiteAbility> Clone(List<FeatPrerequisiteAbility> lstFeatPrerequisiteAbility)
        {
            List<FeatPrerequisiteAbility> lstCFeatPrerequisiteAbility = new List<FeatPrerequisiteAbility>();

            foreach (FeatPrerequisiteAbility objFeatPrerequisiteAbility in lstFeatPrerequisiteAbility)
            {
                lstCFeatPrerequisiteAbility.Add(FeatPrerequisiteAbility.Clone(objFeatPrerequisiteAbility));
            }

            return lstCFeatPrerequisiteAbility;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single feat prerequisite ability.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private FeatPrerequisiteAbility GetSingleFeatPrerequisiteAbility(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the feat prerequisite ability list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private List<FeatPrerequisiteAbility> GetFeatPrerequisiteAbilityList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<FeatPrerequisiteAbility> featPrerequisiteAbilitys = new List<FeatPrerequisiteAbility>();

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
                    FeatPrerequisiteAbility objFeatPrerequisiteAbility = new FeatPrerequisiteAbility();
                    SetReaderToObject(ref objFeatPrerequisiteAbility, ref result);
                    featPrerequisiteAbilitys.Add(objFeatPrerequisiteAbility);
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
            return featPrerequisiteAbilitys;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));

                Ability objAbility = new Ability();

                objAbility.GetAbility(this.AbilityID);
                this.objAbility = objAbility;

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objFeatPrerequisiteAbility">The object feat prerequisite ability.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref FeatPrerequisiteAbility objFeatPrerequisiteAbility, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objFeatPrerequisiteAbility.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                objFeatPrerequisiteAbility.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objFeatPrerequisiteAbility.AbilityMinimum = (int)result.GetValue(result.GetOrdinal("AbilityMinimum"));

                Ability objAbility = new Ability();

                objAbility.GetAbility(objFeatPrerequisiteAbility.AbilityID);
                objFeatPrerequisiteAbility.objAbility = objAbility;
            }
        }
        #endregion
        #endregion
    }
}
