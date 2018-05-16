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
    public class CharacterDefense : BaseValidation
    {

        #region Properties
        ///// <summary>
        ///// Gets or sets the defense identifier.
        ///// </summary>
        ///// <value>
        ///// The defense identifier.
        ///// </value>
        //public int DefenseID { get; set; }
        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        public int CharacterID { get; set; }
        /// <summary>
        /// Gets or sets the defense type identifier.
        /// </summary>
        /// <value>
        /// The defense type identifier.
        /// </value>
        public int DefenseTypeID { get; set; }
        /// <summary>
        /// Gets or sets the character level armor.
        /// </summary>
        /// <value>
        /// The character level armor.
        /// </value>
        public int CharacterLevelArmor { get; set; }
        /// <summary>
        /// Gets or sets the ability mod.
        /// </summary>
        /// <value>
        /// The ability mod.
        /// </value>
        public int AbilityMod { get; set; }
        /// <summary>
        /// Gets or sets the class mod.
        /// </summary>
        /// <value>
        /// The class mod.
        /// </value>
        public int ClassMod { get; set; }
        /// <summary>
        /// Gets or sets the race mod.
        /// </summary>
        /// <value>
        /// The race mod.
        /// </value>
        public int RaceMod { get; set; }
        /// <summary>
        /// Gets or sets the feat talent mod.
        /// </summary>
        /// <value>
        /// The feat talent mod.
        /// </value>
        public int FeatTalentMod { get; set; }
        /// <summary>
        /// Gets or sets the miscellaneous mod.
        /// </summary>
        /// <value>
        /// The miscellaneous mod.
        /// </value>
        public int MiscellaneousMod { get; set; }

        /// <summary>
        /// Gets or sets the type of the defense.
        /// </summary>
        /// <value>
        /// The type of the defense.
        /// </value>
        public DefenseType DefenseType { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterDefense"/> class.
        /// </summary>
        public CharacterDefense()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterDefense"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="DefenseTypeID">The DefenseType identifier.</param>
        public CharacterDefense(int CharacterID, int DefenseTypeID)
        {
            SetBaseConstructorOptions();
            GetDefense(CharacterID, DefenseTypeID);
        }
        #endregion
        
        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the type of the character defense by.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="DefenseTypeID">The defense type identifier.</param>
        /// <returns>Defense Object</returns>
        public CharacterDefense GetCharacterDefenseByType(int CharacterID, int DefenseTypeID)
        {
            return GetSingleDefense("Select_CharacterDefense", " CharacterID=" + CharacterID.ToString() + " AND DefenseTypeID=" + DefenseTypeID.ToString(), "");
        }

        /// <summary>
        /// Gets the defense.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="DefenseTypeID">The DefenseType identifier.</param>
        /// <returns>Defense Object</returns>
        public CharacterDefense GetDefense(int CharacterID, int DefenseTypeID)
        {
            return GetSingleDefense("Select_CharacterDefense", "  CharacterID=" + CharacterID.ToString() + " AND DefenseTypeID=" + DefenseTypeID.ToString(), "");
        }

        /// <summary>
        /// Gets the character defenses.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of Defense Objects</returns>
        public List<CharacterDefense> GetCharacterDefenses(int CharacterID)
        {
            return GetDefenseList("Select_CharacterDefense", "  CharacterID=" + CharacterID.ToString(), "");
        }

        /// <summary>
        /// Gets the defenses.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Defense Objects</returns>
        public List<CharacterDefense> GetDefenses(string strWhere, string strOrderBy)
        {
            return GetDefenseList("Select_CharacterDefense", strWhere, strOrderBy);
        }

        /// <summary>
        /// Delete the Defense.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteDefense()
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
                command.CommandText = "Delete_CharacterDefense";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
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
        /// Delete the Defense.
        /// </summary>
        /// <param name="intCharID">The Character ID.</param>
        /// <returns>Boolean</returns>
        public bool DeleteDefenses(int intCharID, int intDefenseType)
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
                command.CommandText = "Delete_CharacterDefense";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, intCharID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, intDefenseType.ToString(), 0));
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
        /// Saves the defense.
        /// </summary>
        /// <returns>Defense Object</returns>
        public CharacterDefense SaveDefense ()
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
                command.CommandText = "InsertUpdate_CharacterDefense";
                //command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseID", SqlDbType.Int, DefenseID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterLevelArmor", SqlDbType.Int, CharacterLevelArmor.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMod", SqlDbType.Int, AbilityMod.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassMod", SqlDbType.Int, ClassMod.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceMod", SqlDbType.Int, RaceMod.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatTalentMod", SqlDbType.Int, FeatTalentMod.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@MiscellaneousMod", SqlDbType.Int, MiscellaneousMod.ToString(), 0));
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
        /// Saves a List of Defenses to a Character.
        /// </summary>
        /// <param name="lstCharDefense">A <List> of Defenses .</param>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <returns></returns>
        public void SaveCharacterDefenses(List<CharacterDefense> lstCharDefense, int intCharacterID)
        {
            //Different one here.  Currently Characters should have three defences (Will, Fort and Reflex) but they are
            //updated every time a level is added.  The Defense table has a Defense ID as a PK and not a DefenseTypeID and
            //CharacterID so we are going to delete the Defense records by Character and then readd them.
            CharacterDefense objDelDefense = new CharacterDefense();
            objDelDefense.DeleteDefenses (intCharacterID,0);

            foreach (CharacterDefense objCharDefense in lstCharDefense)
            {
                objCharDefense.SaveDefense();
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (this.CharacterID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Character ID cannot be blank or null.");
            }

            if (this.DefenseTypeID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Defense Type ID cannot be blank or null.");
            }

            return this.Validated;
        }

        /// <summary>
        /// Returns the Defense total for the CharacterDefense
        /// </summary>
        /// <returns>Integer</returns>
        public int GetDefenseTotal()
        {
            int intDefTotal = 0;
            intDefTotal = CharacterLevelArmor + AbilityMod + ClassMod + RaceMod + FeatTalentMod + MiscellaneousMod;
            return intDefTotal;
        }

        /// <summary>
        /// Returns the Defense total for a new CharacterDefense with a new Armor / Level & miscellaneous value 
        /// </summary>
        /// <param name="intArmorMod">The Armor Modification Value.</param>
        /// <param name="intMiscellaneous">The Character object.</param>
        /// <returns>Integer</returns>
        public int GetDefenseTotal(int intArmorMod, int intMiscellaneous)
        {
            int intDefTotal = 0;
            intDefTotal = intArmorMod + AbilityMod + ClassMod + RaceMod + FeatTalentMod + intMiscellaneous;
            return intDefTotal;
        }

        #region Static Methods
        /// <summary>
        /// Returns the Fortitude Defense of a Character
        /// </summary>
        /// <param name="objChar">The Character object.</param>
        /// <returns>CharacterDefense</returns>
        static public CharacterDefense GetFortitudeDefense(Character objChar)
        {
            CharacterDefense objCDefense = new CharacterDefense();

            foreach(CharacterDefense objCharDef in objChar.lstDefenses)
            {
                if (objCharDef.DefenseTypeID == 1) objCDefense = objCharDef;
            }

            return objCDefense;
        }

        /// <summary>
        /// Returns the Reflex Defense of a Character
        /// </summary>
        /// <param name="objChar">The Character object.</param>
        /// <returns>CharacterDefense</returns>
        static public CharacterDefense GetReflexDefense(Character objChar)
        {
            CharacterDefense objCDefense = new CharacterDefense();

            foreach (CharacterDefense objCharDef in objChar.lstDefenses)
            {
                if (objCharDef.DefenseTypeID == 2) objCDefense = objCharDef;
            }

            return objCDefense;
        }

        /// <summary>
        /// Returns the Will Defense of a Character
        /// </summary>
        /// <param name="objChar">The Character object.</param>
        /// <returns>CharacterDefense</returns>
        static public CharacterDefense GetWillDefense(Character objChar)
        {
            CharacterDefense objCDefense = new CharacterDefense();

            foreach (CharacterDefense objCharDef in objChar.lstDefenses)
            {
                if (objCharDef.DefenseTypeID == 3) objCDefense = objCharDef;
            }

            return objCDefense;
        }
        /// <summary>
        /// Clones the specified object Defense.
        /// </summary>
        /// <param name="objDefense">The object Defense.</param>
        /// <returns>Defense</returns>
        static public CharacterDefense Clone(CharacterDefense objDefense, bool blnFromDatabase = false)
        {
            //Get the data from the database(?) then match it with what is passed in, we want to clone what is passed in for Character Items, not List Items
            CharacterDefense objCDefense = new CharacterDefense();
            if (blnFromDatabase) objCDefense.GetDefense(objDefense.CharacterID, objDefense.DefenseTypeID);
            else
            {
                objCDefense.AbilityMod = objDefense.AbilityMod;
                objCDefense.CharacterID = objDefense.CharacterID;
                objCDefense.CharacterLevelArmor = objDefense.CharacterLevelArmor;
                objCDefense.ClassMod = objDefense.ClassMod;
                objCDefense.DefenseType = objDefense.DefenseType;
                objCDefense.DefenseTypeID = objDefense.DefenseTypeID;
                objCDefense.FeatTalentMod = objDefense.FeatTalentMod;
                objCDefense.MiscellaneousMod = objDefense.MiscellaneousMod;
                objCDefense.RaceMod = objDefense.RaceMod;
            }
            return objCDefense;
        }

        /// <summary>
        /// Clones the specified LST Defense.
        /// </summary>
        /// <param name="lstDefense">The LST Defense.</param>
        /// <returns>List<Defense></returns>
        static public List<CharacterDefense> Clone(List<CharacterDefense> lstDefense)
        {
            List<CharacterDefense> lstCDefense = new List<CharacterDefense>();

            foreach (CharacterDefense objDefense in lstDefense)
            {
                lstCDefense.Add(CharacterDefense.Clone(objDefense));
            }

            return lstCDefense;
        }
        #endregion
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single defense.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Defense Object</returns>
        private CharacterDefense GetSingleDefense(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the defense list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Defense Objects</returns>
        private List<CharacterDefense> GetDefenseList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterDefense> defenses = new List<CharacterDefense>();

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
                    CharacterDefense objDefense = new CharacterDefense();
                    SetReaderToObject(ref objDefense, ref result);
                    defenses.Add(objDefense);
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
            return defenses;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                //this.DefenseID = (int)result.GetValue(result.GetOrdinal("DefenseID"));
                this.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                this.CharacterLevelArmor = (int)result.GetValue(result.GetOrdinal("CharacterLevelArmor"));
                this.AbilityMod = (int)result.GetValue(result.GetOrdinal("AbilityMod"));
                this.ClassMod = (int)result.GetValue(result.GetOrdinal("ClassMod"));
                this.RaceMod = (int)result.GetValue(result.GetOrdinal("RaceMod"));
                this.FeatTalentMod = (int)result.GetValue(result.GetOrdinal("FeatTalentMod"));
                this.MiscellaneousMod = (int)result.GetValue(result.GetOrdinal("MiscellaneousMod"));

                   DefenseType obDefenseType = new DefenseType();
                if (!(this.DefenseTypeID == 0))
                {
                    obDefenseType.GetDefenseType (this.DefenseTypeID);
                }
                this.DefenseType = obDefenseType;
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objDefense">The object defense.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref CharacterDefense objDefense, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                //objDefense.DefenseID = (int)result.GetValue(result.GetOrdinal("DefenseID"));
                objDefense.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                objDefense.CharacterLevelArmor = (int)result.GetValue(result.GetOrdinal("CharacterLevelArmor"));
                objDefense.AbilityMod = (int)result.GetValue(result.GetOrdinal("AbilityMod"));
                objDefense.ClassMod = (int)result.GetValue(result.GetOrdinal("ClassMod"));
                objDefense.RaceMod = (int)result.GetValue(result.GetOrdinal("RaceMod"));
                objDefense.FeatTalentMod = (int)result.GetValue(result.GetOrdinal("FeatTalentMod"));
                objDefense.MiscellaneousMod = (int)result.GetValue(result.GetOrdinal("MiscellaneousMod"));

                DefenseType obDefenseType = new DefenseType();
                if (!(objDefense.DefenseTypeID == 0))
                {
                    obDefenseType.GetDefenseType(objDefense.DefenseTypeID);
                }
                objDefense.DefenseType = obDefenseType;
            }
        }
        #endregion
        #endregion
    }
}
