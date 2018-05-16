using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class CharacterAbility : BaseValidation
    {


        public int CharacterID { get; set; }
        public int AbilityID { get; set; }
        public int Score { get; set; }
        public int ScoreMod { get; set; }

        public Ability objAbility = new Ability();

        #region Constructors
        public CharacterAbility()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterAbility"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="AbilityID">The Ability identifier.</param>
        public CharacterAbility(int CharacterID, int AbilityID)
        {
            SetBaseConstructorOptions();
            GetCharacterAbility(CharacterID, AbilityID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterAbility"/> class.
        /// </summary>
        /// <param name="AbilityID">The Ability identifier.</param>
        public CharacterAbility(int AbilityID)
        {
            SetBaseConstructorOptions();
            Ability objAbility = new Ability(AbilityID);
            this.objAbility = objAbility;
            this.AbilityID = AbilityID;
            this.CharacterID = 0;
            this.Score = 0;
            this.ScoreMod = 0;
        }
        #endregion


        #region Methods
        #region Public Methods
        public CharacterAbility GetCharacterAbility(int CharacterID, int AbilityID)
        {
            return GetSingleCharacterAbility("Select_CharacterAbility", " CharacterID = " + CharacterID.ToString() + " AND AbilityID=" + AbilityID.ToString(), "");
        }

        //public CharacterAbility GetCharacterAbility(string CharacterAbilityName)
        //{
        //    return GetSingleCharacterAbility("Select_CharacterAbility", " CharacterAbilityID = " + CharacterAbilityID.ToString(), "");
        //}

        public List<CharacterAbility> GetCharacterAbilities(string strWhere, string strOrderBy)
        {
            return GetCharacterAbilityList("Select_CharacterAbility", strWhere, strOrderBy);
        }

        public CharacterAbility SaveCharacterAbility()
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
                command.CommandText = "InsertUpdate_CharacterAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Score", SqlDbType.Int, Score.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ScoreMod", SqlDbType.Int, ScoreMod.ToString(), 0));
                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK  = false;
                this._insertUpdateMessage.Append(e.Message.ToString());
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this;
        }

        public void SaveCharacterAbilities(List<CharacterAbility> lstCharAbilities, int intCharcterID)
        {
            //Character Abilites can be updated but not added or deleted as a whole, so we do not need to clear out and reset them
            //CharacterAbility objDelCharAbility = new CharacterAbility();
            //objDelCharAbility.DeleteCharacterAbility(intCharcterID);

            foreach (CharacterAbility objCharAbility in lstCharAbilities)
            {
                objCharAbility.SaveCharacterAbility();
            }
        }

        /// <summary>
        /// Deletes the character equipment.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterAbility(int CharacterID)
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
                command.CommandText = "Delete_CharacterAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, "CharacterID=" + CharacterID.ToString(), 2000));
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

        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (this.AbilityID==0)
            {
                this._validated = false;
                this._validationMessage.Append("The Ability cannot be blank or null.");
            }
            if (this.CharacterID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Character cannot be blank or null.");
            }
            if (this.Score == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Score cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object CharacterAbility.
        /// </summary>
        /// <param name="objCharacterAbility">The object CharacterAbility.</param>
        /// <returns>CharacterAbility</returns>
        static public CharacterAbility Clone(CharacterAbility objCharacterAbility, bool blnFromDatabase = false)
        {
            //Get the data from the database(?) then match it with what is passed in, we want to clone what is passed in for Character Items, not List Items
            CharacterAbility objCCharacterAbility = new CharacterAbility();
            if (blnFromDatabase) objCCharacterAbility.GetCharacterAbility(objCharacterAbility.CharacterID, objCharacterAbility.AbilityID);
            else
            {
                objCCharacterAbility.AbilityID = objCharacterAbility.AbilityID;
                objCCharacterAbility.CharacterID = objCharacterAbility.CharacterID;
                objCCharacterAbility.objAbility = objCharacterAbility.objAbility;
                objCCharacterAbility.Score = objCharacterAbility.Score;
                objCCharacterAbility.ScoreMod = objCharacterAbility.ScoreMod;
            }
            return objCCharacterAbility;
        }

        /// <summary>
        /// Clones the specified LST CharacterAbility.
        /// </summary>
        /// <param name="lstCharacterAbility">The LST CharacterAbility.</param>
        /// <returns>List<CharacterAbility></returns>
        static public List<CharacterAbility> Clone(List<CharacterAbility> lstCharacterAbility)
        {
            List<CharacterAbility> lstCCharacterAbility = new List<CharacterAbility>();

            foreach (CharacterAbility objCharacterAbility in lstCharacterAbility)
            {
                lstCCharacterAbility.Add(CharacterAbility.Clone(objCharacterAbility));
            }

            return lstCCharacterAbility;
        }

        ///// <summary>
        ///// Deletes the character equipment.
        ///// </summary>
        ///// <param name="CharacterID">The character identifier.</param>
        ///// <param name="AbilityID">The Ability identifier.</param>
        ///// <returns>Boolean</returns>
        //static public bool DeleteCharacterAbility(int CharacterID, int AbilityID)
        //{
        //    string strWhere = "";

        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);
        //    strWhere = "CharacterID=" + CharacterID.ToString() + " AND EquipmentID=" + AbilityID.ToString();
        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Delete_CharacterAbility";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
        //        result = command.ExecuteReader();

        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        this._deleteOK = false;
        //        this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);

        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return this.DeleteOK;
        //}
        #endregion

        #region Private Methods
        private CharacterAbility GetSingleCharacterAbility(string sprocName, string strWhere, string strOrderBy)
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

        private List<CharacterAbility> GetCharacterAbilityList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterAbility> CharacterAbilitys = new List<CharacterAbility>();

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
                    CharacterAbility objCharacterAbility = new CharacterAbility();
                    SetReaderToObject(ref objCharacterAbility, ref result);
                    CharacterAbilitys.Add(objCharacterAbility);
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
            return CharacterAbilitys;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.Score = (int)result.GetValue(result.GetOrdinal("Score"));
                this.ScoreMod = (int)result.GetValue(result.GetOrdinal("ScoreMod"));
                
                Ability objAbil = new Ability();
                this.objAbility = objAbil.GetAbility(this.AbilityID);
            }
        }

        private void SetReaderToObject(ref CharacterAbility objCharacterAbility, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objCharacterAbility.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                objCharacterAbility.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objCharacterAbility.Score = (int)result.GetValue(result.GetOrdinal("Score"));
                objCharacterAbility.ScoreMod = (int)result.GetValue(result.GetOrdinal("ScoreMod"));

                Ability objAbil = new Ability();
                objCharacterAbility.objAbility = objAbil.GetAbility(objCharacterAbility.AbilityID);
            }
        }
        #endregion

        #endregion
    }
}
