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
    /// TODO: Create CharacterWeapon Section to include: tables, CRUD sprocs, Unit Tests, etc
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class CharacterWeapon : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the CharacterWeapon identifier.
        /// </summary>
        /// <value>
        /// The CharacterWeapon identifier.
        /// </value>
        public int CharacterWeaponID { get; set; }
        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        public int CharacterID { get; set; }
        /// <summary>
        /// Gets or sets the weapon identifier.
        /// </summary>
        /// <value>
        /// The weapon identifier.
        /// </value>
        public int WeaponID{ get; set; }

        /// <summary>
        /// Gets or sets the Range attack bonus.
        /// </summary>
        /// <value>
        /// The Range attack bonus.
        /// </value>
        public int RangeAttackBonus { get; set; }
        /// <summary>
        /// Gets or sets the Range Damage bonus.
        /// </summary>
        /// <value>
        /// The Range Damage bonus.
        /// </value>
        public int RangeDamageBonus { get; set; }

        /// <summary>
        /// Gets or sets the Melee attack bonus.
        /// </summary>
        /// <value>
        /// The Melee attack bonus.
        /// </value>
        public int MeleeAttackBonus { get; set; }
        /// <summary>
        /// Gets or sets the Melee Damage bonus.
        /// </summary>
        /// <value>
        /// The Melee Damage bonus.
        /// </value>
        public int MeleeDamageBonus { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes { get; set; }

        /// <summary>
        /// The object weapon
        /// </summary>
        public Weapon objWeapon = new Weapon();

        public List<Range> lstWeaponRanges = new List<Range>();

        public List<Modification> lstWeaponModifications = new List<Modification>();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterWeapon" /> class.
        /// </summary>
        public CharacterWeapon()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterWeapon"/> class.
        /// </summary>
        /// <param name="CharacterWeaponID">The CharacterWeapon identifier.</param>
        public CharacterWeapon(int CharacterWeaponID)
        {
            SetBaseConstructorOptions();
            GetCharacterWeapon(CharacterWeaponID);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterWeapon"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="WeaponID">The Weapon identifier.</param>
        public CharacterWeapon(int CharacterID, int WeaponID)
        {
            SetBaseConstructorOptions();
            GetCharacterWeapon(CharacterID, WeaponID);
        }


        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the charater weapon.
        /// </summary>
        /// <param name="CharacterWeaponID">The CharacterWeapon identifier.</param>
        /// <returns>CharacterWeapon Weapon</returns>
        public CharacterWeapon GetCharacterWeapon(int CharacterWeaponID)
        {
            return GetSingleCharacterWeapon("Select_CharacterWeapon", "  CharacterWeaponID=" + CharacterWeaponID.ToString(), "");
        }

        /// <summary>
        /// Gets the charater weapon.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="WeaponID">The weapon identifier.</param>
        /// <returns>CharacterWeapon Weapon</returns>
        public CharacterWeapon GetCharacterWeapon(int CharacterID, int WeaponID)
        {
            return GetSingleCharacterWeapon("Select_CharacterWeapon", "  CharacterID=" + CharacterID.ToString() + " AND WeaponID=" + WeaponID.ToString(), "");
        }

        /// <summary>
        /// Gets the charater weapons.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of CharacterWeapons</returns>
        public List<CharacterWeapon> GetCharacterWeapons(int CharacterID)
        {
            return GetCharacterWeaponList("Select_CharacterWeapon", "  CharacterID=" + CharacterID.ToString(), "");
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here

            return this.Validated;
        }

        /// <summary>
        /// Saves the character class level.
        /// </summary>
        /// <returns>CharacterWeapon Object</returns>
        public CharacterWeapon SaveCharacterWeapon()
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
                command.CommandText = "InsertUpdate_CharacterWeapon";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterWeaponID", SqlDbType.Int, CharacterWeaponID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, WeaponID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RangeAttackBonus", SqlDbType.Int, RangeAttackBonus.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RangeDamageBonus", SqlDbType.Int, RangeDamageBonus.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@MeleeAttackBonus", SqlDbType.Int, MeleeAttackBonus.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@MeleeDamageBonus", SqlDbType.Int, MeleeDamageBonus.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Notes", SqlDbType.VarChar, Notes.ToString(), 100));
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

        public CharacterWeapon CreateCharacterWeapon(Character objChar, Weapon objWeapon)
        {
            this.CharacterWeaponID = 0;
            this.CharacterID = objChar.CharacterID;
            this.WeaponID = objWeapon.WeaponID;
            this.RangeAttackBonus = objChar.CalculateRangeToHit(objWeapon);
            this.RangeDamageBonus = objChar.CalculateRangeBonusDamage();
            //TODO remove Hard code
            this.MeleeAttackBonus = objChar.CalculateMeleeToHit(objWeapon, 1365, 1364);
            this.MeleeDamageBonus = objChar.CalculateMeleeBonusDamage();
            this.Notes = "";
            this.objWeapon = objWeapon;
            this.lstWeaponRanges = objWeapon.objRanges;
            return this;
        }

        /// <summary>
        /// Delete the CharacterWeapon.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterWeapon()
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
                command.CommandText = "Delete_CharacterWeapon";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, WeaponID.ToString(), 0));
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
        /// Delete the CharacterWeapon.
        /// </summary>
        /// <param name="intCharacterID">The character identifier.</param>
        /// <param name="intWeaponID">The Weapon identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterWeapon(int intCharacterID, int intWeaponID)
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
                command.CommandText = "Delete_CharacterWeapon";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, intCharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, intWeaponID.ToString(), 0));
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

        public bool DeleteCharacterWeaponModification(int CharacterWeaponID, int ModificationID)
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
                command.CommandText = "Delete_ChracterWeaponModification";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterWeaponID", SqlDbType.Int, CharacterWeaponID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationID", SqlDbType.Int, ModificationID.ToString(), 0));
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
        /// Saves a List of Feats to a Character.
        /// </summary>
        /// <param name="lstCharFeat">A <List> of Feats .</param>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <returns></returns>
        public void SaveCharacterWeapons(List<CharacterWeapon> lstCharacterWeapon, int intCharacterID)
        {
            //Once a CharacterWeapon is added it can be removed or updated, so clear it out and start over 
            CharacterWeapon objDelCharacterWeapon = new CharacterWeapon();
            objDelCharacterWeapon.DeleteCharacterWeapon(intCharacterID, 0);

            foreach (CharacterWeapon objCharWeapon in lstCharacterWeapon)
            {
                objCharWeapon.SaveCharacterWeapon();
            }
        }

        #region Static Methods
        /// <summary>
        /// Clones the specified object CharacterWeapon.
        /// </summary>
        /// <param name="objCharacterWeapon">The object CharacterWeapon.</param>
        /// <returns>CharacterWeapon</returns>
        static public CharacterWeapon Clone(CharacterWeapon objCharacterWeapon)
        {
            CharacterWeapon objCCharacterWeapon = new CharacterWeapon(objCharacterWeapon.CharacterID ,objCharacterWeapon.WeaponID );


            objCCharacterWeapon.CharacterWeaponID = objCharacterWeapon.CharacterWeaponID;
            objCCharacterWeapon.CharacterID = objCharacterWeapon.CharacterID;
            objCCharacterWeapon.WeaponID = objCharacterWeapon.WeaponID;
            objCCharacterWeapon.RangeAttackBonus = objCharacterWeapon.RangeAttackBonus;
            objCCharacterWeapon.RangeDamageBonus = objCharacterWeapon.RangeDamageBonus;
            objCCharacterWeapon.MeleeAttackBonus = objCharacterWeapon.MeleeAttackBonus;
            objCCharacterWeapon.MeleeDamageBonus = objCharacterWeapon.MeleeDamageBonus;
            objCCharacterWeapon.Notes = objCharacterWeapon.Notes;

            objCCharacterWeapon.objWeapon = Weapon.Clone(objCharacterWeapon.objWeapon);
            objCCharacterWeapon.lstWeaponRanges = Range.Clone(objCharacterWeapon.lstWeaponRanges);
            objCCharacterWeapon.lstWeaponModifications = Modification.Clone(objCharacterWeapon.lstWeaponModifications);

            return objCCharacterWeapon;
        }

        /// <summary>
        /// Clones the specified LST CharacterWeapon.
        /// </summary>
        /// <param name="lstCharacterWeapon">The LST CharacterWeapon.</param>
        /// <returns>List<CharacterWeapon></returns>
        static public List<CharacterWeapon> Clone(List<CharacterWeapon> lstCharacterWeapon)
        {
            List<CharacterWeapon> lstCCharacterWeapon = new List<CharacterWeapon>();

            foreach (CharacterWeapon objCharacterWeapon in lstCharacterWeapon)
            {
                lstCCharacterWeapon.Add(CharacterWeapon.Clone(objCharacterWeapon));
            }

            return lstCCharacterWeapon;
        }

        /// <summary>
        /// Determines whether [lstCWSearching] is in the lstCharWeaponGroup list].
        /// </summary>
        /// <param name="lstCWSearching">The LST CharacterWeapon searching for.</param>
        /// <param name="lstCharWeaponGroup">The LST Character Weapon.</param>
        /// <returns>Boolean</returns>
        static public bool IsCharacterWeaponInList(List<CharacterWeapon> lstCWSearching, List<CharacterWeapon> lstCharWeaponGroup)
        {
            bool blnSkillFound = true;
            bool blnFoundIndividual = false;
            foreach (CharacterWeapon lstObjCW in lstCWSearching)
            {
                blnFoundIndividual = false;
                foreach (CharacterWeapon objCharWeaponFromList in lstCharWeaponGroup)
                {
                    if (lstObjCW.CharacterWeaponID == objCharWeaponFromList.CharacterWeaponID)
                    {
                        blnFoundIndividual = true;
                    }
                }
                if (blnFoundIndividual == false)
                {
                    blnSkillFound = false;
                }
            }

            return blnSkillFound;
        }

        /// <summary>
        /// Determines whether [is skill in list] [the specified object skill].
        /// </summary>
        /// <param name="objCharacterWeapon">The object skill.</param>
        /// <param name="lstCharWeapons">The LST character skill.</param>
        /// <returns>Boolean</returns>
        static public bool IsCharacterWeaponInList(CharacterWeapon objCharacterWeapon, List<CharacterWeapon> lstCharWeapons)
        {
            bool blnCharacterWeaponFound = false;
            if (objCharacterWeapon.CharacterWeaponID  == 0)
            {
                blnCharacterWeaponFound = true;
            }
            else
            {
                foreach (CharacterWeapon objCharWeap in lstCharWeapons)
                {
                    if (objCharacterWeapon.CharacterWeaponID == objCharWeap.CharacterWeaponID)
                    {
                        blnCharacterWeaponFound = true;
                    }
                }
            }
            return blnCharacterWeaponFound;
        }

        static public List<CharacterWeapon> RemoveCharacterWeaponFromList(CharacterWeapon objCharacterWeapon, List<CharacterWeapon> lstCharWeapons)
        {
            List<CharacterWeapon> retList = new List<CharacterWeapon>();

            foreach (CharacterWeapon objCharWeap in lstCharWeapons)
            {
                if (objCharacterWeapon.CharacterWeaponID != objCharWeap.CharacterWeaponID) retList.Add(objCharWeap);
            }

            return retList;
        }

        static public List<CharacterWeapon> RemoveCharacterWeaponFromList(int CharacterWeaponID, List<CharacterWeapon> lstCharWeapons)
        {
            List<CharacterWeapon> retList = new List<CharacterWeapon>();

            foreach (CharacterWeapon objCharWeap in lstCharWeapons)
            {
                if (CharacterWeaponID != objCharWeap.CharacterWeaponID) retList.Add(objCharWeap);
            }

            return retList;
        }
        #endregion
        #endregion

        #region Private Methods
        ///// <summary>
        ///// Saves the character weapon.
        ///// </summary>
        ///// <returns>CharacterWeapon</returns>
        //private CharacterWeapon SaveCharacterWeapon()
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
        //        command.CommandText = "InsertUpdate_CharacterWeapon";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, WeaponID.ToString(), 0));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@AttackBonus", SqlDbType.Int, AttackBonus.ToString(), 0));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@Notes", SqlDbType.VarChar, Notes.ToString(), 100));
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
        /// Gets the single character weapon.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>CharacterWeapon</returns>
        private CharacterWeapon GetSingleCharacterWeapon(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the character weapon list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of CharacterWeapons</returns>
        private List<CharacterWeapon> GetCharacterWeaponList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterWeapon> characterWeapons = new List<CharacterWeapon>();

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
                    CharacterWeapon objCharacterWeapon = new CharacterWeapon();
                    SetReaderToObject(ref objCharacterWeapon, ref result);
                    characterWeapons.Add(objCharacterWeapon);
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
            return characterWeapons;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.CharacterWeaponID = (int)result.GetValue(result.GetOrdinal("CharacterWeaponID"));
                this.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                this.WeaponID = (int)result.GetValue(result.GetOrdinal("WeaponID"));
                this.RangeAttackBonus = (int)result.GetValue(result.GetOrdinal("RangeAttackBonus"));
                this.RangeDamageBonus = (int)result.GetValue(result.GetOrdinal("RangeDamageBonus"));
                this.MeleeAttackBonus = (int)result.GetValue(result.GetOrdinal("MeleeAttackBonus"));
                this.MeleeDamageBonus = (int)result.GetValue(result.GetOrdinal("MeleeDamageBonus"));
                this.Notes = result.GetValue(result.GetOrdinal("Notes")).ToString();

                Weapon objWeapon = new Weapon();
                this.objWeapon =  objWeapon.GetWeapon(this.WeaponID);           
 
                Range objRange = new Range();
                this.lstWeaponRanges = objRange.GetWeaponRanges("WeaponID=" + this.WeaponID.ToString(), "BeginSquare");

                Modification objModification = new Modification();
                this.lstWeaponModifications = objModification.GetCharacterWeaponModifications (this.CharacterWeaponID);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objCharacterWeapon">The object character weapon.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref CharacterWeapon objCharacterWeapon, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objCharacterWeapon.CharacterWeaponID = (int)result.GetValue(result.GetOrdinal("CharacterWeaponID"));
                objCharacterWeapon.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                objCharacterWeapon.WeaponID = (int)result.GetValue(result.GetOrdinal("WeaponID"));
                objCharacterWeapon.RangeAttackBonus = (int)result.GetValue(result.GetOrdinal("RangeAttackBonus"));
                objCharacterWeapon.RangeDamageBonus = (int)result.GetValue(result.GetOrdinal("RangeDamageBonus"));
                objCharacterWeapon.MeleeAttackBonus = (int)result.GetValue(result.GetOrdinal("MeleeAttackBonus"));
                objCharacterWeapon.MeleeDamageBonus = (int)result.GetValue(result.GetOrdinal("MeleeDamageBonus"));
                objCharacterWeapon.Notes = result.GetValue(result.GetOrdinal("Notes")).ToString();

                Weapon objWeapon = new Weapon();
                objCharacterWeapon.objWeapon = objWeapon.GetWeapon(objCharacterWeapon.WeaponID);

                Range objRange = new Range();
                objCharacterWeapon.lstWeaponRanges = objRange.GetWeaponRanges("WeaponID=" + objCharacterWeapon.WeaponID.ToString(), "BeginSquare");

                Modification objModification = new Modification();
                objCharacterWeapon.lstWeaponModifications = objModification.GetCharacterWeaponModifications(objCharacterWeapon.CharacterWeaponID);
            }
        }
        #endregion
        #endregion
    }
}
