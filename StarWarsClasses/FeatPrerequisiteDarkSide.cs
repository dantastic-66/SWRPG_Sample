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
    public class FeatPrerequisiteDarkSide : BaseValidation
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
        /// Gets or sets the dark side score.
        /// </summary>
        /// <value>
        /// The dark side score.
        /// </value>
        public int DarkSideScore { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [total dark side].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [total dark side]; otherwise, <c>false</c>.
        /// </value>
        public bool TotalDarkSide { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatPrerequisiteDarkSide"/> class.
        /// </summary>
        public FeatPrerequisiteDarkSide()
		{
            SetBaseConstructorOptions();
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="FeatPrerequisiteDarkSide"/> class.
        ///// </summary>
        ///// <param name="FeatPrerequisiteDarkSideName">Name of the FeatPrerequisiteDarkSide.</param>
        //public FeatPrerequisiteDarkSide(string FeatPrerequisiteDarkSideName)
        //{
        //    SetBaseConstructorOptions();
        //    GetFeatPrerequisiteDarkSide(FeatPrerequisiteDarkSideName);
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatPrerequisiteDarkSide"/> class.
        /// </summary>
        /// <param name="FeatID">The Feat identifier.</param>
        public FeatPrerequisiteDarkSide(int FeatID)
        {
            SetBaseConstructorOptions();
            GetFeatPrerequisiteDarkSide(FeatID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the feat prerequisite dark side.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public FeatPrerequisiteDarkSide GetFeatPrerequisiteDarkSide(string strWhere, string strOrderBy)
        {
            return GetSingleFeatPrerequisiteDarkSide("Select_FeatPrerequisiteDarkSide", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the feat prerequisite dark side.
        /// </summary>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns></returns>
        public FeatPrerequisiteDarkSide GetFeatPrerequisiteDarkSide(int FeatID)
        {
            return GetSingleFeatPrerequisiteDarkSide("Select_FeatPrerequisiteDarkSide", "  otmFeatPrequisiteDarkSide.FeatID=" + FeatID.ToString(), "");

        }

        /// <summary>
        /// Gets the feat prerequisite dark sides.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<FeatPrerequisiteDarkSide> GetFeatPrerequisiteDarkSides(string strWhere, string strOrderBy)
        {
            return GetFeatPrerequisiteDarkSideList("Select_FeatPrerequisiteDarkSide", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the extra class item.
        /// </summary>
        /// <returns></returns>
        public FeatPrerequisiteDarkSide SaveFeatPrerequisiteDarkSide()
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
                command.CommandText = "InsertUpdate_FeatPrerequisiteDarkSide";
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DarkSideScore", SqlDbType.Int, DarkSideScore.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TotalDarkSide", SqlDbType.Bit , TotalDarkSide.ToString(), 0));
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
        public bool DeleteFeatPrerequisiteDarkSide()
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
                command.CommandText = "Delete_FeatPrerequisiteDarkSide";
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DarkSideScore", SqlDbType.Int, DarkSideScore.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@TotalDarkSide", SqlDbType.Bit, TotalDarkSide.ToString(), 0));
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
            if (this.FeatID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Feat ID cannot be zero.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object FeatPrerequisiteDarkSide.
        /// </summary>
        /// <param name="objFeatPrerequisiteDarkSide">The object FeatPrerequisiteDarkSide.</param>
        /// <returns>FeatPrerequisiteDarkSide</returns>
        static public FeatPrerequisiteDarkSide Clone(FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide)
        {
            FeatPrerequisiteDarkSide objCFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide(objFeatPrerequisiteDarkSide.FeatID);
            return objCFeatPrerequisiteDarkSide;
        }

        /// <summary>
        /// Clones the specified LST FeatPrerequisiteDarkSide.
        /// </summary>
        /// <param name="lstFeatPrerequisiteDarkSide">The LST FeatPrerequisiteDarkSide.</param>
        /// <returns>List<FeatPrerequisiteDarkSide></returns>
        static public List<FeatPrerequisiteDarkSide> Clone(List<FeatPrerequisiteDarkSide> lstFeatPrerequisiteDarkSide)
        {
            List<FeatPrerequisiteDarkSide> lstCFeatPrerequisiteDarkSide = new List<FeatPrerequisiteDarkSide>();

            foreach (FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide in lstFeatPrerequisiteDarkSide)
            {
                lstCFeatPrerequisiteDarkSide.Add(FeatPrerequisiteDarkSide.Clone(objFeatPrerequisiteDarkSide));
            }

            return lstCFeatPrerequisiteDarkSide;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single feat prerequisite dark side.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private FeatPrerequisiteDarkSide GetSingleFeatPrerequisiteDarkSide(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the feat prerequisite dark side list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private List<FeatPrerequisiteDarkSide> GetFeatPrerequisiteDarkSideList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<FeatPrerequisiteDarkSide> featPrerequisiteAbilitys = new List<FeatPrerequisiteDarkSide>();

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
                    FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide = new FeatPrerequisiteDarkSide();
                    SetReaderToObject(ref objFeatPrerequisiteDarkSide, ref result);
                    featPrerequisiteAbilitys.Add(objFeatPrerequisiteDarkSide);
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
                this.DarkSideScore = (int)result.GetValue(result.GetOrdinal("DarkSideScore"));
                this.TotalDarkSide = (bool)result.GetValue(result.GetOrdinal("TotalDarkSide"));

                //Ability objAbility = new Ability();

                //objAbility.GetAbility(this.AbilityID);
                //this.objAbility = objAbility;

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objFeatPrerequisiteDarkSide">The object feat prerequisite dark side.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref FeatPrerequisiteDarkSide objFeatPrerequisiteDarkSide, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objFeatPrerequisiteDarkSide.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                objFeatPrerequisiteDarkSide.DarkSideScore = (int)result.GetValue(result.GetOrdinal("DarkSideScore"));
                objFeatPrerequisiteDarkSide.TotalDarkSide = (bool)result.GetValue(result.GetOrdinal("TotalDarkSide"));

                //Ability objAbility = new Ability();

                //objAbility.GetAbility(objFeatPrerequisiteDarkSide.AbilityID);
                //objFeatPrerequisiteDarkSide.objAbility = objAbility;
            }
        }
        #endregion
        #endregion
    }
}
