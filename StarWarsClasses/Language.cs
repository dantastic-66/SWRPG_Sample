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
    public class Language : BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the language identifier.
        /// </summary>
        /// <value>
        /// The language identifier.
        /// </value>
        public int LanguageID { get; set; }
        /// <summary>
        /// Gets or sets the name of the language.
        /// </summary>
        /// <value>
        /// The name of the language.
        /// </value>
        public string LanguageName { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        public Language()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        /// <param name="LanguageName">Name of the Language.</param>
        public Language(string LanguageName)
        {
            SetBaseConstructorOptions();
            GetLanguage(LanguageName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        /// <param name="LanguageID">The Language identifier.</param>
        public Language(int LanguageID)
        {
            SetBaseConstructorOptions();
            GetLanguage(LanguageID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <param name="LanguageID">The language identifier.</param>
        /// <returns></returns>
        public Language GetLanguage(int LanguageID)
        {
            return GetSingleLanguage("Select_Language", "  LanguageID=" + LanguageID.ToString(), "");
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <param name="LanguageName">Name of the language.</param>
        /// <returns>Language object</returns>
        public Language GetLanguage(string LanguageName)
        {
            return GetSingleLanguage("Select_Language", "  LanguageName='" + LanguageName + "'", "");
        }

        /// <summary>
        /// Saves the Language.
        /// </summary>
        /// <returns>Language object</returns>
        public Language SaveLanguage()
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
                command.CommandText = "InsertUpdate_Language";
                command.Parameters.Add(dbconn.GenerateParameterObj("@LanguageID", SqlDbType.Int, LanguageID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@LanguageName", SqlDbType.VarChar, LanguageName.ToString(), 50));
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
        /// Deletes the Language.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteLanguage()
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
                command.CommandText = "Delete_Language";
                command.Parameters.Add(dbconn.GenerateParameterObj("@LanguageID", SqlDbType.Int, LanguageID.ToString(), 0));
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
        /// Gets multiple languages.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Languages</returns>
        public List<Language> GetLanguages(string strWhere, string strOrderBy)
        {
            return GetLanguageList("Select_Language", strWhere, strOrderBy);
        }


        /// <summary>
        /// Gets multiple languages by Race.
        /// </summary>
        /// <param name="intRaceID">The int RaceID.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Languages</returns>
        public List<Language> GetRaceLanguages(int intRaceID, string strOrderBy)
        {
            return GetLanguageList("Select_LanguageByRace", " RaceID=" + intRaceID.ToString() , strOrderBy);
        }

        /// <summary>
        /// Gets the character languages.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of Languages</returns>
        public List<Language> GetCharacterLanguages(int CharacterID)
        {
            return GetLanguageList("Select_CharacterLanguages", " CharacterID=" + CharacterID.ToString(), "");
        }

        /// <summary>
        /// Deletes the character languages.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="LanguageID">The language identifier.</param>
        /// <returns>boolean</returns>
        public bool DeleteCharacterLanguage (int CharacterID, int LanguageID)
        {
            //bool blnDeleteOK = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            string strWhere = "";
            if (LanguageID ==0)
            {
                strWhere = "CharacterID=" + CharacterID.ToString();
            }
            else
            {
                strWhere = "CharacterID=" + CharacterID.ToString() + " AND LanguageID=" + LanguageID.ToString();
            }

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_CharacterLanguage";
                command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar ,strWhere , 2000));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this.DeleteOK;
        }

        /// <summary>
        /// Saves the character languages.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="LanguageID">The language identifier.</param>
        /// <returns>Language Object</returns>
        public Language SaveCharacterLanguage(int CharacterID, int LanguageID)
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
                command.CommandText = "InsertUpdate_CharacterLanguage";

                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@LanguageID", SqlDbType.Int, LanguageID.ToString(), 0));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._validated = false;
                this._validationMessage.Append(e.Message.ToString());
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return GetLanguage(LanguageID);

        }

        public void SaveCharacterLanguages(List<Language> lstCharLanguages, int intCharID)
        {
            //Once a Language is added it cannot be removed, or updated, just add the new ones
            //Language objDelLanguage = new Language();
            //objDelLanguage.DeleteCharacterLanguage(intCharID, 0);

            foreach (Language objCharLanguage in lstCharLanguages)
            {
                objCharLanguage.SaveCharacterLanguage(intCharID, objCharLanguage.LanguageID);
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.LanguageName))
            {
                this._validated = false;
                this._validationMessage.Append("The Language Name cannot be blank or null.");
            }
            return this.Validated;
        }

        #region Public Static Methods
        /// <summary>
        /// Clones the specified object Language.
        /// </summary>
        /// <param name="objLanguage">The object Language.</param>
        /// <returns>Language</returns>
        static public Language Clone(Language objLanguage)
        {
            Language objCLanguage = new Language(objLanguage.LanguageID);
            return objCLanguage;
        }

        /// <summary>
        /// Clones the specified LST Language.
        /// </summary>
        /// <param name="lstLanguage">The LST Language.</param>
        /// <returns>List<Language></returns>
        static public List<Language> Clone(List<Language> lstLanguage)
        {
            List<Language> lstCLanguage = new List<Language>();

            foreach (Language objLanguage in lstLanguage)
            {
                lstCLanguage.Add(Language.Clone(objLanguage));
            }

            return lstCLanguage;
        }
        #endregion
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets a single language.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Language Object</returns>
        private Language GetSingleLanguage (string sprocName, string strWhere,string strOrderBy)
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
        /// Gets a language list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Languages</returns>
        private List<Language> GetLanguageList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Language> languages = new List<Language>();

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
                    Language objLanguage = new Language();
                    SetReaderToObject(ref objLanguage, ref result);
                    languages.Add(objLanguage);
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
            return languages;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private  void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.LanguageID = (int)result.GetValue(result.GetOrdinal("LanguageID"));
                this.LanguageName = result.GetValue(result.GetOrdinal("LanguageName")).ToString();

                this._objComboBoxData.Add(this.LanguageID, this.LanguageName);

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objLanguage">The object language.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Language objLanguage, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objLanguage.LanguageID = (int)result.GetValue(result.GetOrdinal("LanguageID"));
                objLanguage.LanguageName = result.GetValue(result.GetOrdinal("LanguageName")).ToString();

                objLanguage._objComboBoxData.Add(objLanguage.LanguageID, objLanguage.LanguageName);
            }
        }
        #endregion
        #endregion
    }
}
