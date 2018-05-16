using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class WeaponAmmo : BaseValidation
    {


        public int WeaponAmmoID { get; set; }
        public string WeaponAmmoName { get; set; }
        public string WeaponAmmoDescription { get; set; }

        public int Cost { get; set; }
        public string RateOfFire {get; set;}
        public int DamageDieNumber { get; set; }
        public int DamageDieType { get; set; }
        public int ExtraDamage { get; set; }
        public int StunDieNumber { get; set; }
        public int StunDieType { get; set; }
        public int ExtraStunDamage { get; set; }
        public bool Stun { get; set; }
        public decimal Weight { get; set; }
        public int BookID { get; set; }

        #region Constructors
        public WeaponAmmo()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponAmmo"/> class.
        /// </summary>
        /// <param name="WeaponAmmoName">Name of the WeaponAmmo.</param>
        public WeaponAmmo(string WeaponAmmoName)
        {
            SetBaseConstructorOptions();
            GetWeaponAmmo(WeaponAmmoName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponAmmo"/> class.
        /// </summary>
        /// <param name="WeaponAmmoID">The WeaponAmmo identifier.</param>
        public WeaponAmmo(int WeaponAmmoID)
        {
            SetBaseConstructorOptions();
            GetWeaponAmmo(WeaponAmmoID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public WeaponAmmo GetWeaponAmmo(int WeaponAmmoID)
        {
            return GetSingleWeaponAmmo("Select_WeaponAmmo", " WeaponAmmoID = " + WeaponAmmoID.ToString(), "");
        }

        public WeaponAmmo GetWeaponAmmo(string WeaponAmmoName)
        {
            return GetSingleWeaponAmmo("Select_WeaponAmmo", " WeaponAmmoName='" + WeaponAmmoID.ToString() + "'", "");
        }

        public List<WeaponAmmo> GetWeaponAmmos(string strWhere, string strOrderBy)
        {
            return GetWeaponAmmoList("Select_WeaponAmmo", strWhere, strOrderBy);
        }

        public List<WeaponAmmo> GetWeaponAmmoByWeapon(int WeaponID)
        {
            return GetWeaponAmmoList("Select_WeaponWeaponAmmo", " WeaponAmmoName='" + WeaponAmmoID.ToString() + "'", "WeaponAmmoName");
        }

        public WeaponAmmo SaveWeaponAmmo()
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
                command.CommandText = "InsertUpdate_WeaponAmmo";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponAmmoID", SqlDbType.Int, WeaponAmmoID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponAmmoName", SqlDbType.VarChar, WeaponAmmoName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Cost", SqlDbType.Int, Cost.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RateOfFire", SqlDbType.VarChar, RateOfFire.ToString(), 3));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DamageDieNumber", SqlDbType.Int, DamageDieNumber.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DamageDieType", SqlDbType.Int, DamageDieType.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Stun", SqlDbType.Bit, Stun.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StunDieNumber", SqlDbType.Int, DamageDieNumber.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StunDieType", SqlDbType.Int, DamageDieType.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponAmmoDescription", SqlDbType.Text, WeaponAmmoDescription.ToString(), 4000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Weight", SqlDbType.Decimal, Weight.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookID", SqlDbType.Int, BookID.ToString(), 0));
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

        /// <summary>
        /// Delete the WeaponAmmo.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteWeaponAmmo()
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
                command.CommandText = "Delete_WeaponAmmo";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponAmmoID", SqlDbType.Int, WeaponAmmoID.ToString(), 0));
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

        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            //if (string.IsNullOrEmpty(this.WeaponName))
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Weapon Name cannot be blank or null.");
            //}
            return this.Validated;
        }
        #endregion

        #region Private Methods
        private WeaponAmmo GetSingleWeaponAmmo(string sprocName, string strWhere, string strOrderBy)
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

        private List<WeaponAmmo> GetWeaponAmmoList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<WeaponAmmo> WeaponAmmos = new List<WeaponAmmo>();

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
                    WeaponAmmo objWeaponAmmo = new WeaponAmmo();
                    SetReaderToObject(ref objWeaponAmmo, ref result);
                    WeaponAmmos.Add(objWeaponAmmo);
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
            return WeaponAmmos;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.WeaponAmmoID = (int)result.GetValue(result.GetOrdinal("WeaponAmmoID"));
                this.WeaponAmmoName = result.GetValue(result.GetOrdinal("WeaponAmmoName")).ToString();
                this.WeaponAmmoDescription = result.GetValue(result.GetOrdinal("WeaponAmmoDescription")).ToString();

                this.DamageDieNumber = (int)result.GetValue(result.GetOrdinal("DamageDieNumber"));
                this.DamageDieType = (int)result.GetValue(result.GetOrdinal("DamageDieType"));
                this.Cost = (int)result.GetValue(result.GetOrdinal("Cost"));
                this.RateOfFire = result.GetValue(result.GetOrdinal("RateOfFire")).ToString();

                this.Stun = (bool)result.GetValue(result.GetOrdinal("Stun"));
                this.StunDieNumber = (int)result.GetValue(result.GetOrdinal("StunDieNumber"));
                this.StunDieType = (int)result.GetValue(result.GetOrdinal("StunDieType"));
                this.WeaponAmmoDescription = result.GetValue(result.GetOrdinal("WeaponAmmoDescription")).ToString();
                this.Weight = (decimal)result.GetValue(result.GetOrdinal("Weight"));
                this.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                this.ExtraDamage = (int)result.GetValue(result.GetOrdinal("ExtraDamage"));
                this.ExtraStunDamage = (int)result.GetValue(result.GetOrdinal("ExtraStunDamage"));

            }
        }

        private void SetReaderToObject(ref WeaponAmmo objWeaponAmmo, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objWeaponAmmo.WeaponAmmoID = (int)result.GetValue(result.GetOrdinal("WeaponAmmoID"));
                objWeaponAmmo.WeaponAmmoName = result.GetValue(result.GetOrdinal("WeaponAmmoName")).ToString();
                objWeaponAmmo.WeaponAmmoDescription = result.GetValue(result.GetOrdinal("WeaponAmmoDescription")).ToString();

                objWeaponAmmo.DamageDieNumber = (int)result.GetValue(result.GetOrdinal("DamageDieNumber"));
                objWeaponAmmo.DamageDieType = (int)result.GetValue(result.GetOrdinal("DamageDieType"));
                objWeaponAmmo.Cost = (int)result.GetValue(result.GetOrdinal("Cost"));
                objWeaponAmmo.RateOfFire = result.GetValue(result.GetOrdinal("RateOfFire")).ToString();

                objWeaponAmmo.Stun = (bool)result.GetValue(result.GetOrdinal("Stun"));
                objWeaponAmmo.StunDieNumber = (int)result.GetValue(result.GetOrdinal("StunDieNumber"));
                objWeaponAmmo.StunDieType = (int)result.GetValue(result.GetOrdinal("StunDieType"));
                objWeaponAmmo.WeaponAmmoDescription = result.GetValue(result.GetOrdinal("WeaponAmmoDescription")).ToString();
                objWeaponAmmo.Weight = (decimal)result.GetValue(result.GetOrdinal("Weight"));
                objWeaponAmmo.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                objWeaponAmmo.ExtraDamage = (int)result.GetValue(result.GetOrdinal("ExtraDamage"));
                objWeaponAmmo.ExtraStunDamage = (int)result.GetValue(result.GetOrdinal("ExtraStunDamage"));

            }
        }

        #endregion
        #endregion
    }
}
