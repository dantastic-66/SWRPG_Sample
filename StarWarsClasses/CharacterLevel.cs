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
    public class CharacterLevel : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the character level identifier.
        /// </summary>
        /// <value>
        /// The character level identifier.
        /// </value>
        public int CharacterLevelID { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [feat available].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [feat available]; otherwise, <c>false</c>.
        /// </value>
        public bool FeatAvailable { get; set; }
        /// <summary>
        /// Gets or sets the minimum experience.
        /// </summary>
        /// <value>
        /// The minimum experience.
        /// </value>
        public int MinimumExperience { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [ability increase].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [ability increase]; otherwise, <c>false</c>.
        /// </value>
        public bool AbilityIncrease { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterLevel"/> class.
        /// </summary>
        public CharacterLevel()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterLevel"/> class.
        /// </summary>
        /// <param name="CharacterLevelID">The CharacterLevel identifier.</param>
        public CharacterLevel(int CharacterLevelID)
        {
            SetBaseConstructorOptions();
            GetCharacterLevel(CharacterLevelID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the character level.
        /// </summary>
        /// <param name="CharacterLevelID">The character level identifier.</param>
        /// <returns>CharacterLevel Object</returns>
        public CharacterLevel GetCharacterLevel(int CharacterLevelID)
        {
            return GetSingleCharacterLevel("Select_CharacterLevel", "  CharacterLevelID=" + CharacterLevelID.ToString(), "");
        }

        /// <summary>
        /// Gets the character levels.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of CharacterLevel Objects</returns>
        public List<CharacterLevel> GetCharacterLevels(string strWhere, string strOrderBy)
        {
            return GetCharacterLevelList("Select_CharacterLevel", strWhere, strOrderBy);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if ((this.MinimumExperience == 0))
            {
                this._validated = false;
                this._validationMessage.Append("The Minimum Experience cannot be 0.");
            }
            return this.Validated;
        }
    
        /// <summary>
        /// Clones the specified object CharacterLevel.
        /// </summary>
        /// <param name="objCharacterLevel">The object CharacterLevel.</param>
        /// <returns>CharacterLevel</returns>
        static public CharacterLevel Clone(CharacterLevel objCharacterLevel)
        {
            CharacterLevel objCCharacterLevel = new CharacterLevel(objCharacterLevel.CharacterLevelID);
            return objCCharacterLevel;
        }

        /// <summary>
        /// Clones the specified LST CharacterLevel.
        /// </summary>
        /// <param name="lstCharacterLevel">The LST CharacterLevel.</param>
        /// <returns>List<CharacterLevel></returns>
        static public List<CharacterLevel> Clone(List<CharacterLevel> lstCharacterLevel)
        {
            List<CharacterLevel> lstCCharacterLevel = new List<CharacterLevel>();

            foreach (CharacterLevel objCharacterLevel in lstCharacterLevel)
            {
                lstCCharacterLevel.Add(CharacterLevel.Clone(objCharacterLevel));
            }

            return lstCCharacterLevel;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single character level.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>CharacterLevel Object</returns>
        private CharacterLevel GetSingleCharacterLevel(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the character level list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of CharacterLevel Objects</returns>
        private List<CharacterLevel> GetCharacterLevelList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterLevel> characterClassLevels = new List<CharacterLevel>();

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
                    CharacterLevel obCharacterLevel = new CharacterLevel();
                    SetReaderToObject(ref obCharacterLevel, ref result);
                    characterClassLevels.Add(obCharacterLevel);
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
            return characterClassLevels;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.CharacterLevelID = (int)result.GetValue(result.GetOrdinal("CharacterLevelID"));
                this.FeatAvailable = (bool)result.GetValue(result.GetOrdinal("FeatAvailable"));
                this.MinimumExperience = (int)result.GetValue(result.GetOrdinal("MinimumExperience"));
                this.AbilityIncrease = (bool)result.GetValue(result.GetOrdinal("AbilityIncrease"));
                
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objCharacterLevel">The object character level.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref CharacterLevel objCharacterLevel, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objCharacterLevel.CharacterLevelID = (int)result.GetValue(result.GetOrdinal("CharacterLevelID"));
                objCharacterLevel.FeatAvailable = (bool)result.GetValue(result.GetOrdinal("FeatAvailable"));
                objCharacterLevel.MinimumExperience = (int)result.GetValue(result.GetOrdinal("MinimumExperience"));
                objCharacterLevel.AbilityIncrease = (bool)result.GetValue(result.GetOrdinal("AbilityIncrease"));
            }
        }
        #endregion
        #endregion
    }
}
