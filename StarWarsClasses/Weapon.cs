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
    public class Weapon:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the weapon identifier.
        /// </summary>
        /// <value>
        /// The weapon identifier.
        /// </value>
        public int WeaponID { get; set; }
        /// <summary>
        /// Gets or sets the name of the weapon.
        /// </summary>
        /// <value>
        /// The name of the weapon.
        /// </value>
        public string WeaponName { get; set; }
        /// <summary>
        /// Gets or sets the weapon type identifier.
        /// </summary>
        /// <value>
        /// The weapon type identifier.
        /// </value>
        public int WeaponTypeID {get; set;}
        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>
        /// The damage.
        /// </value>
        public int WeaponSizeID { get; set; }
        public int Cost { get; set; }
        public string RateOfFire { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Weapon"/> is stun.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stun; otherwise, <c>false</c>.
        /// </value>
        public bool Stun {get; set;}
        public int DamageDieNumber { get; set; }
        public int DamageDieType { get; set; }
        public int ExtraDamage { get; set; }
        /// <summary>
        /// Gets or sets the stun damage.
        /// </summary>
        /// <value>
        /// The stun damage.
        /// </value>

        public int StunDieNumber { get; set; }
        public int StunDieType { get; set; }
        public int ExtraStunDamage { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string WeaponDescription { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public decimal Weight { get; set; }
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public int BookID { get; set; }

        public int WeaponProficiencyFeatID { get; set; }

        public int EmplacementPoints { get; set; }

        public bool DoubleWeapon { get; set; }

        public bool AreaOfAttack {get;set;}

        public bool Accurate { get; set; }

        public bool Inaccurate { get; set; }

        public bool Slugthrower { get; set; }

        public bool RequiresSeperateAmmo { get; set; }

        /// <summary>
        /// Gets or sets the type of the object weapon.
        /// </summary>
        /// <value>
        /// The type of the object weapon.
        /// </value>
        public WeaponType objWeaponType { get; set; }
        /// <summary>
        /// Gets or sets the object ranges.
        /// </summary>
        /// <value>
        /// The object ranges.
        /// </value>
        public List<Range> objRanges { get; set; }

        public Book objBook  { get; set; }

        public WeaponSize objWeaponSize { get; set; }

        public Feat objWeaponProficiencyFeat { get; set; }

        public List<ItemAvailabilityType> lstWeaponAvailability { get; set; }

        public List<WeaponAmmo> lstWeaponAmmo { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        public Weapon()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="WeaponName">Name of the Weapon.</param>
        public Weapon(string WeaponName)
        {
            SetBaseConstructorOptions();
            GetWeapon(WeaponName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="WeaponID">The Weapon identifier.</param>
        public Weapon(int WeaponID)
        {
            SetBaseConstructorOptions();
            GetWeapon(WeaponID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the weapon.
        /// </summary>
        /// <param name="WeaponID">The weapon identifier.</param>
        /// <returns>Weapon Object</returns>
        public Weapon GetWeapon(int WeaponID)
        {
            return GetSingleWeapon("Select_Weapon", "  WeaponID=" + WeaponID.ToString(), "");
        }

        /// <summary>
        /// Gets the weapon.
        /// </summary>
        /// <param name="WeaponName">Name of the weapon.</param>
        /// <returns>Weapon Object</returns>
        public Weapon GetWeapon(string WeaponName)
        {
            return GetSingleWeapon("Select_Weapon", "  WeaponName='" + WeaponName + "'", "");
        }

        /// <summary>
        /// Gets the weapons.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Weapon Objects</returns>
        public List<Weapon> GetWeapons(string strWhere, string strOrderBy)
        {
            return GetWeaponList("Select_Weapon", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the Character Proficient weapons.
        /// </summary>
        /// <param name="strWhere">The Character ID in string format.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Weapon Objects usable by the character</returns>
        public List<Weapon> GetCharacterProficientWeapons (int intCharacterID)
        {
            return GetWeaponList("Select_CharacterProfecientWeapon", intCharacterID.ToString(), "lstWeapon.WeaponName");
        }

        public List<Weapon> GetWeaponsByWeaponTypeID(int intWeaponTypeID)
        {
            return GetWeaponList("Select_Weapon", "WeaponTypeID=" + intWeaponTypeID.ToString(), "WeaponName");
        }

        /// <summary>
        /// Saves the weapon.
        /// </summary>
        /// <returns>Weapon Object</returns>
        public Weapon SaveWeapon()
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
                command.CommandText = "InsertUpdate_Weapon";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, WeaponID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponName", SqlDbType.VarChar, WeaponName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponTypeID", SqlDbType.Int, WeaponTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponSizeID", SqlDbType.Int, WeaponSizeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Cost", SqlDbType.Int, Cost.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RateOfFire", SqlDbType.VarChar, RateOfFire.ToString(), 3));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DamageDieNumber", SqlDbType.Int, DamageDieNumber.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DamageDieType", SqlDbType.Int, DamageDieType.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Stun", SqlDbType.Bit, Stun.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StunDieNumber", SqlDbType.Int, DamageDieNumber.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StunDieType", SqlDbType.Int, DamageDieType.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponDescription", SqlDbType.Text, WeaponDescription.ToString(), 4000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Weight", SqlDbType.Decimal , Weight.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookID", SqlDbType.Int, BookID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponProficiencyFeatID", SqlDbType.Int, WeaponProficiencyFeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EmplacementPoints", SqlDbType.Int, EmplacementPoints.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DoubleWeapon", SqlDbType.Bit, DoubleWeapon.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AreaOfAttack", SqlDbType.Bit, AreaOfAttack.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Accurate", SqlDbType.Bit, AreaOfAttack.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Inaccurate", SqlDbType.Bit, AreaOfAttack.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Slugthrower", SqlDbType.Bit, Slugthrower.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RequiresSeperateAmmo", SqlDbType.Bit, RequiresSeperateAmmo.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ExtraDamage", SqlDbType.Bit, ExtraDamage.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ExtraStunDamage", SqlDbType.Bit, ExtraStunDamage.ToString(), 0));

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
        /// Deletes the weapon.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteWeapon()
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
                command.CommandText = "Delete_Weapon";
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
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.WeaponName))
            {
                this._validated = false;
                this._validationMessage.Append("The Weapon Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object Weapon.
        /// </summary>
        /// <param name="objWeapon">The object Weapon.</param>
        /// <returns>Weapon</returns>
        static public Weapon Clone(Weapon objWeapon)
        {
            Weapon objCWeapon = new Weapon(objWeapon.WeaponID);
            return objCWeapon;
        }

        /// <summary>
        /// Clones the specified LST Weapon.
        /// </summary>
        /// <param name="lstWeapon">The LST Weapon.</param>
        /// <returns>List<Weapon></returns>
        static public List<Weapon> Clone(List<Weapon> lstWeapon)
        {
            List<Weapon> lstCWeapon = new List<Weapon>();

            foreach (Weapon objWeapon in lstWeapon)
            {
                lstCWeapon.Add(Weapon.Clone(objWeapon));
            }

            return lstCWeapon;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single weapon.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Weapon Object</returns>
        private Weapon GetSingleWeapon(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the weapon list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Weapon Objects</returns>
        private List<Weapon> GetWeaponList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Weapon> weapons = new List<Weapon>();

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
                    Weapon objWeapon = new Weapon();
                    SetReaderToObject(ref objWeapon, ref result);
                    weapons.Add(objWeapon);
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
            return weapons;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.WeaponID = (int)result.GetValue(result.GetOrdinal("WeaponID"));
                this.WeaponName = result.GetValue(result.GetOrdinal("WeaponName")).ToString();
                this.WeaponTypeID = (int)result.GetValue(result.GetOrdinal("WeaponTypeID"));
                this.DamageDieNumber = (int)result.GetValue(result.GetOrdinal("DamageDieNumber"));
                this.DamageDieType = (int)result.GetValue(result.GetOrdinal("DamageDieType"));
                this.WeaponSizeID = (int)result.GetValue(result.GetOrdinal("WeaponSizeID"));
                this.Cost = (int)result.GetValue(result.GetOrdinal("Cost"));
                this.RateOfFire = result.GetValue(result.GetOrdinal("RateOfFire")).ToString();

                this.Stun = (bool)result.GetValue(result.GetOrdinal("Stun"));
                this.StunDieNumber = (int)result.GetValue(result.GetOrdinal("StunDieNumber"));
                this.StunDieType = (int)result.GetValue(result.GetOrdinal("StunDieType"));
                this.WeaponDescription = result.GetValue(result.GetOrdinal("WeaponDescription")).ToString();
                this.Weight = (decimal)result.GetValue(result.GetOrdinal("Weight"));
                this.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                this.WeaponProficiencyFeatID = (int)result.GetValue(result.GetOrdinal("WeaponProficiencyFeatID"));
                this.EmplacementPoints = (int)result.GetValue(result.GetOrdinal("EmplacementPoints"));
                this.DoubleWeapon = (bool)result.GetValue(result.GetOrdinal("DoubleWeapon"));
                this.AreaOfAttack = (bool)result.GetValue(result.GetOrdinal("AreaOfAttack"));
                this.Accurate = (bool)result.GetValue(result.GetOrdinal("Accurate"));
                this.Inaccurate = (bool)result.GetValue(result.GetOrdinal("Inaccurate"));
                this.Slugthrower = (bool)result.GetValue(result.GetOrdinal("Slugthrower"));
                this.RequiresSeperateAmmo = (bool)result.GetValue(result.GetOrdinal("RequiresSeperateAmmo"));
                this.ExtraDamage = (int)result.GetValue(result.GetOrdinal("ExtraDamage"));
                this.ExtraStunDamage = (int)result.GetValue(result.GetOrdinal("ExtraStunDamage"));

                WeaponType objWeaponType = new WeaponType();
                if (!(this.WeaponTypeID == 0))
                {
                     objWeaponType.GetWeaponType( this.WeaponTypeID);
                }
                this.objWeaponType = objWeaponType;

                Range objRange = new Range();
                this.objRanges = objRange.GetWeaponRanges("WeaponID=" + this.WeaponID.ToString(), "BeginSquare");

                Book objBk = new Book(this.BookID);
                this.objBook = objBk;

                WeaponSize objWS = new WeaponSize(this.WeaponSizeID);
                this.objWeaponSize = objWS;

                Feat objWPFeat = new Feat(this.WeaponProficiencyFeatID);
                this.objWeaponProficiencyFeat = objWPFeat;

                ItemAvailabilityType objIAT = new ItemAvailabilityType();
                this.lstWeaponAvailability = objIAT.GetWeaponAvailabilityTypes(this.WeaponID);

                WeaponAmmo objWA = new WeaponAmmo();
                this.lstWeaponAmmo = objWA.GetWeaponAmmoByWeapon(this.WeaponID);

                this._objComboBoxData.Add(this.WeaponID, this.WeaponName);

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objWeapon">The object weapon.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Weapon objWeapon, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objWeapon.WeaponID = (int)result.GetValue(result.GetOrdinal("WeaponID"));
                objWeapon.WeaponName = result.GetValue(result.GetOrdinal("WeaponName")).ToString();
                objWeapon.WeaponTypeID = (int)result.GetValue(result.GetOrdinal("WeaponTypeID"));
                objWeapon.DamageDieNumber = (int)result.GetValue(result.GetOrdinal("DamageDieNumber"));
                objWeapon.DamageDieType = (int)result.GetValue(result.GetOrdinal("DamageDieType"));
                objWeapon.WeaponSizeID = (int)result.GetValue(result.GetOrdinal("WeaponSizeID"));
                objWeapon.Cost = (int)result.GetValue(result.GetOrdinal("Cost"));
                objWeapon.RateOfFire = result.GetValue(result.GetOrdinal("RateOfFire")).ToString();
                objWeapon.Stun = (bool)result.GetValue(result.GetOrdinal("Stun"));
                objWeapon.StunDieNumber = (int)result.GetValue(result.GetOrdinal("StunDieNumber"));
                objWeapon.StunDieType = (int)result.GetValue(result.GetOrdinal("StunDieType"));
                objWeapon.WeaponDescription = result.GetValue(result.GetOrdinal("WeaponDescription")).ToString();
                objWeapon.Weight = (decimal)result.GetValue(result.GetOrdinal("Weight"));
                objWeapon.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                objWeapon.WeaponProficiencyFeatID = (int)result.GetValue(result.GetOrdinal("WeaponProficiencyFeatID"));
                objWeapon.EmplacementPoints = (int)result.GetValue(result.GetOrdinal("EmplacementPoints"));
                objWeapon.DoubleWeapon = (bool)result.GetValue(result.GetOrdinal("DoubleWeapon"));
                objWeapon.AreaOfAttack = (bool)result.GetValue(result.GetOrdinal("AreaOfAttack"));
                objWeapon.Accurate = (bool)result.GetValue(result.GetOrdinal("Accurate"));
                objWeapon.Inaccurate = (bool)result.GetValue(result.GetOrdinal("Inaccurate"));
                objWeapon.Slugthrower = (bool)result.GetValue(result.GetOrdinal("Slugthrower"));
                objWeapon.RequiresSeperateAmmo = (bool)result.GetValue(result.GetOrdinal("RequiresSeperateAmmo"));
                objWeapon.ExtraDamage = (int)result.GetValue(result.GetOrdinal("ExtraDamage"));
                objWeapon.ExtraStunDamage = (int)result.GetValue(result.GetOrdinal("ExtraStunDamage"));

                WeaponType objWeaponType = new WeaponType();
                if (!(objWeapon.WeaponTypeID == 0))
                {
                    objWeaponType.GetWeaponType(this.WeaponTypeID);
                }
                objWeapon.objWeaponType = objWeaponType;

                Range objRange = new Range();
                objWeapon.objRanges = objRange.GetWeaponRanges("WeaponID=" + objWeapon.WeaponID.ToString(), "BeginSquare");

                Book objBk = new Book(objWeapon.BookID);
                objWeapon.objBook = objBk;

                WeaponSize objWS = new WeaponSize(objWeapon.WeaponSizeID);
                objWeapon.objWeaponSize = objWS;

                Feat objWPFeat = new Feat(this.WeaponProficiencyFeatID);
                objWeapon.objWeaponProficiencyFeat = objWPFeat;

                ItemAvailabilityType objIAT = new ItemAvailabilityType();
                objWeapon.lstWeaponAvailability = objIAT.GetWeaponAvailabilityTypes(objWeapon.WeaponID);

                WeaponAmmo objWA = new WeaponAmmo();
                objWeapon.lstWeaponAmmo = objWA.GetWeaponAmmoByWeapon(objWeapon.WeaponID);

                objWeapon._objComboBoxData.Add(objWeapon.WeaponID, objWeapon.WeaponName);

            }
        }
        #endregion

        #endregion
    }
}
