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
    public class CharacterClassLevel : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        public int CharacterID { get; set; }
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>
        /// The class identifier.
        /// </value>
        public int ClassID { get; set; }
        /// <summary>
        /// Gets or sets the class level.
        /// </summary>
        /// <value>
        /// The class level.
        /// </value>
        public int ClassLevel { get; set; }

        /// <summary>
        /// Gets or sets the object character class.
        /// </summary>
        /// <value>
        /// The object character class.
        /// </value>
        public Class objCharacterClass { get; set; }
        /// <summary>
        /// Gets or sets the object character class level information.
        /// </summary>
        /// <value>
        /// The object character class level information.
        /// </value>
        public List<ClassLevelInfo> objCharacterClassLevelInfo { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterClassLevel" /> class.
        /// </summary>
        public CharacterClassLevel()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterClassLevel"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        public CharacterClassLevel(int CharacterID)
        {
            SetBaseConstructorOptions();
            GetCharacterClassLevel(CharacterID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterClassLevel"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="ClassLevelID">The ClassLevel identifier.</param>
        public CharacterClassLevel(int CharacterID, int ClassLevelID)
        {
            SetBaseConstructorOptions();
            GetCharacterClassLevel(CharacterID, ClassLevelID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the character class level.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="ClassLevelID">The ClassLevel identifier.</param>
        /// <returns>List of CharacterClassLevel Objects</returns>
        public CharacterClassLevel GetCharacterClassLevel(int CharacterID, int ClassLevelID)
        {
            return GetSingleCharacterClassLevel("Select_CharacterClassLevel", "  CharacterID=" + CharacterID.ToString() + " AND ClassLevelID=" + ClassLevelID.ToString(), "");
        }

        /// <summary>
        /// Gets the character class level.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of CharacterClassLevel Objects</returns>
        public List<CharacterClassLevel> GetCharacterClassLevel(int CharacterID)
        {
            return GetCharacterClassLevelList("Select_CharacterClassLevel", "  CharacterID=" + CharacterID.ToString(), "");
        }

        /// <summary>
        /// Saves the character class level.
        /// </summary>
        /// <returns>CharacterClassLevel Object</returns>
        public  CharacterClassLevel SaveCharacterClassLevel()
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
                command.CommandText = "InsertUpdate_CharacterClassLevel";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, ClassID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassLevel", SqlDbType.Int, ClassLevel.ToString(), 0));
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

        public void SaveCharacterClassLevels(List<CharacterClassLevel> lstCharacterClassLevel, int intCharacterID)
        {
            //Once a CharacterClassLevel is added it cannot be removed, or updated, just add the new ones
            //CharacterClassLevel objDelCharacterClassLevel = new CharacterClassLevel();
            //objDelCharacterClassLevel.DeleteCharacterClassLevel (intCharacterID, 0);

            foreach (CharacterClassLevel objCharacterClassLevel in lstCharacterClassLevel)
            {
                objCharacterClassLevel.SaveCharacterClassLevel();
            }
        }

        /// <summary>
        /// Delete the CharacterClassLevel.
        /// </summary>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <param name="intClassID">The Class identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterClassLevel(int intCharacterID, int intClassID)
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
                command.CommandText = "Delete_CharacterClassLevel";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, intCharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, intClassID.ToString(), 0));
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
        /// Delete the CharacterClassLevel.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterClassLevel()
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
                command.CommandText = "Delete_CharacterClassLevel";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, ClassID.ToString(), 0));
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
        /// <returns>Bool</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (this.ClassLevel == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The ClassLevel cannot be 0.");
            }
            return this.Validated;
        }
        #endregion       
        
        #region Public Static Methods
        /// <summary>
        /// Determines whether [is character class level in list] [the specified object character class level].
        /// </summary>
        /// <param name="objCharacterClassLevel">The object character class level.</param>
        /// <param name="lstCharacterClassLevel">The LST character class level.</param>
        /// <returns>Boolean</returns>
        static public bool IsCharacterClassLevelInList(CharacterClassLevel objCharacterClassLevel, List<CharacterClassLevel> lstCharacterClassLevel)
        {
            bool blnCharacterClassLevelFound = false;

            foreach (CharacterClassLevel lstObjCharacterClassLevel in lstCharacterClassLevel)
            {
                if (objCharacterClassLevel.ClassID  == lstObjCharacterClassLevel.ClassID )
                {
                    blnCharacterClassLevelFound = true;
                }
            }

            return blnCharacterClassLevelFound;
        }

        /// <summary>
        /// Determines whether [is class in list] [the specified object class].
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <param name="lstCharacterClassLevel">The LST character class level.</param>
        /// <returns>Boolean</returns>
        static public bool IsClassInList(Class objClass, List<CharacterClassLevel> lstCharacterClassLevel)
        {
            bool blnCharacterClassLevelFound = false;

            foreach (CharacterClassLevel lstObjCharacterClassLevel in lstCharacterClassLevel)
            {
                if (objClass.ClassID == lstObjCharacterClassLevel.ClassID)
                {
                    blnCharacterClassLevelFound = true;
                }
            }

            return blnCharacterClassLevelFound;
        }

        /// <summary>
        /// Determines whether [is class in list] [the specified LST need class level infos].
        /// </summary>
        /// <param name="lstNeedClassLevelInfos">The LST need class level infos.</param>
        /// <param name="lstClassLevelInfos">The LST class level infos.</param>
        /// <returns>Boolean</returns>
        static public bool IsClassInList(List<Class> lstNeedClassLevelInfos, List<CharacterClassLevel> lstClassLevelInfos)
        {
            bool blnAllClasssFound = true;
            bool blnClassFound = false;

            foreach (Class objNeedClassLevelInfo in lstNeedClassLevelInfos)
            {
                foreach (CharacterClassLevel objClassLevelInfo in lstClassLevelInfos)
                {
                    if (objNeedClassLevelInfo.ClassID == objClassLevelInfo.ClassID)
                    {
                        blnClassFound = true;
                    }
                }
                if (blnAllClasssFound)
                {
                    blnAllClasssFound = blnClassFound;
                }
            }

            return blnAllClasssFound;
        }

        /// <summary>
        /// Clones the specified object CharacterClassLevel.
        /// </summary>
        /// <param name="objCharacterClassLevel">The object CharacterClassLevel.</param>
        /// <returns>CharacterClassLevel</returns>
        static public CharacterClassLevel Clone(CharacterClassLevel objCharacterClassLevel, bool blnFromDatabase = false)
        {
            //Get the data from the database(?) then match it with what is passed in, we want to clone what is passed in for Character Items, not List Items
            CharacterClassLevel objCCharacterClassLevel = new CharacterClassLevel();
            if (blnFromDatabase) objCCharacterClassLevel.GetCharacterClassLevel(objCharacterClassLevel.CharacterID, objCharacterClassLevel.ClassLevel);
            else
            {
                objCCharacterClassLevel.CharacterID = objCharacterClassLevel.CharacterID;
                objCCharacterClassLevel.ClassID = objCharacterClassLevel.ClassID;
                objCCharacterClassLevel.ClassLevel = objCharacterClassLevel.ClassLevel;
            }
            return objCCharacterClassLevel;
        }

        /// <summary>
        /// Clones the specified LST CharacterClassLevel.
        /// </summary>
        /// <param name="lstCharacterClassLevel">The LST CharacterClassLevel.</param>
        /// <returns>List<CharacterClassLevel></returns>
        static public List<CharacterClassLevel> Clone(List<CharacterClassLevel> lstCharacterClassLevel)
        {
            List<CharacterClassLevel> lstCCharacterClassLevel = new List<CharacterClassLevel>();

            foreach (CharacterClassLevel objCharacterClassLevel in lstCharacterClassLevel)
            {
                lstCCharacterClassLevel.Add(CharacterClassLevel.Clone(objCharacterClassLevel));
            }

            return lstCCharacterClassLevel;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single character class level.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>CharacterClassLevel Object</returns>
        private CharacterClassLevel GetSingleCharacterClassLevel(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the character class level list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of CharacterClassLevel Objects</returns>
        private List<CharacterClassLevel> GetCharacterClassLevelList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterClassLevel> characterClassLevels = new List<CharacterClassLevel>();

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
                    CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
                    SetReaderToObject(ref objCharacterClassLevel, ref result);
                    characterClassLevels.Add(objCharacterClassLevel);
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
                this.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                this.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));
                this.ClassLevel = (int)result.GetValue(result.GetOrdinal("ClassLevel"));

                Class objClass = new Class();
                this.objCharacterClass = objClass.GetClass(this.ClassID);

                ClassLevelInfo objClassLevel = new ClassLevelInfo();
                this.objCharacterClassLevelInfo = objClassLevel.GetClassLevels("ClassID=" + this.ClassID.ToString() + " AND ClassLevel <=" + this.ClassLevel.ToString(), "");

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="obCharacterClassLevel">The ob character class level.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref CharacterClassLevel obCharacterClassLevel, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                obCharacterClassLevel.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                obCharacterClassLevel.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));
                obCharacterClassLevel.ClassLevel = (int)result.GetValue(result.GetOrdinal("ClassLevel"));

                Class objClass = new Class();
                obCharacterClassLevel.objCharacterClass = objClass.GetClass(obCharacterClassLevel.ClassID);

                ClassLevelInfo objClassLevel = new ClassLevelInfo();
                obCharacterClassLevel.objCharacterClassLevelInfo = objClassLevel.GetClassLevels("ClassID=" + obCharacterClassLevel.ClassID.ToString() + " AND ClassLevel <=" + obCharacterClassLevel.ClassLevel.ToString(), "");

            }
        }
        #endregion


        #endregion
    }
}
