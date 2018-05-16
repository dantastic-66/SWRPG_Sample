using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class RaceSpecialAbility : BaseValidation
    {


        public int RaceSpecialAbilityID { get; set; }
        public string RaceSpecialAbilityName { get; set; }
        public string RaceSpecialAbilityDescription { get; set; }


        #region Constructors
        public RaceSpecialAbility()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceSpecialAbility"/> class.
        /// </summary>
        /// <param name="RaceSpecialAbilityName">Name of the RaceSpecialAbility.</param>
        public RaceSpecialAbility(string RaceSpecialAbilityName)
        {
            SetBaseConstructorOptions();
            GetRaceSpecialAbility(RaceSpecialAbilityName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceSpecialAbility"/> class.
        /// </summary>
        /// <param name="RaceSpecialAbilityID">The RaceSpecialAbility identifier.</param>
        public RaceSpecialAbility(int RaceSpecialAbilityID)
        {
            SetBaseConstructorOptions();
            GetRaceSpecialAbility(RaceSpecialAbilityID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public RaceSpecialAbility GetRaceSpecialAbility(int RaceSpecialAbilityID)
        {
            return GetSingleRaceSpecialAbility("Select_RaceSpecialAbility", " RaceSpecialAbilityID = " + RaceSpecialAbilityID.ToString(), "");
        }

        public RaceSpecialAbility GetRaceSpecialAbility(string RaceSpecialAbilityName)
        {
            return GetSingleRaceSpecialAbility("Select_RaceSpecialAbility", " RaceSpecialAbilityName='" + RaceSpecialAbilityID.ToString() + "'", "");
        }

        public List<RaceSpecialAbility> GetRaceSpecialAbilitys(string strWhere, string strOrderBy)
        {
            return GetRaceSpecialAbilityList("Select_RaceSpecialAbility", strWhere, strOrderBy);
        }

        public List<RaceSpecialAbility> GetRaceSpecialAbilitysByRace(int intRaceID)
        {
            return GetRaceSpecialAbilityList("Select_RaceRaceSpecialAbility", " RaceID=" + intRaceID.ToString(), "RaceSpecialAbilityName");
        }

        public RaceSpecialAbility SaveRaceSpecialAbility()
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
                command.CommandText = "InsertUpdate_RaceSpecialAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceSpecialAbilityID", SqlDbType.Int, RaceSpecialAbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceSpecialAbilityName", SqlDbType.VarChar , RaceSpecialAbilityName, 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceSpecialAbilityDescription", SqlDbType.VarChar, RaceSpecialAbilityDescription, 1000));

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
        /// Delete the RaceSpecialAbility.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteRaceSpecialAbility()
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
                command.CommandText = "Delete_RaceSpecialAbility";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceSpecialAbilityID", SqlDbType.Int, RaceSpecialAbilityID.ToString(), 0));
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

        /// <summary>
        /// Clones the specified object RaceSpecialAbility.
        /// </summary>
        /// <param name="objRaceSpecialAbility">The object RaceSpecialAbility.</param>
        /// <returns>RaceSpecialAbility</returns>
        static public RaceSpecialAbility Clone(RaceSpecialAbility objRaceSpecialAbility)
        {
            RaceSpecialAbility objCRaceSpecialAbility = new RaceSpecialAbility(objRaceSpecialAbility.RaceSpecialAbilityID);
            return objCRaceSpecialAbility;
        }

        /// <summary>
        /// Clones the specified LST RaceSpecialAbility.
        /// </summary>
        /// <param name="lstRaceSpecialAbility">The LST RaceSpecialAbility.</param>
        /// <returns>List<RaceSpecialAbility></returns>
        static public List<RaceSpecialAbility> Clone(List<RaceSpecialAbility> lstRaceSpecialAbility)
        {
            List<RaceSpecialAbility> lstCRaceSpecialAbility = new List<RaceSpecialAbility>();

            foreach (RaceSpecialAbility objRaceSpecialAbility in lstRaceSpecialAbility)
            {
                lstCRaceSpecialAbility.Add(RaceSpecialAbility.Clone(objRaceSpecialAbility));
            }

            return lstCRaceSpecialAbility;
        }
        #endregion

        #region Private Methods
        private RaceSpecialAbility GetSingleRaceSpecialAbility(string sprocName, string strWhere, string strOrderBy)
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

        private List<RaceSpecialAbility> GetRaceSpecialAbilityList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<RaceSpecialAbility> RaceSpecialAbilitys = new List<RaceSpecialAbility>();

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
                    RaceSpecialAbility objRaceSpecialAbility = new RaceSpecialAbility();
                    SetReaderToObject(ref objRaceSpecialAbility, ref result);
                    RaceSpecialAbilitys.Add(objRaceSpecialAbility);
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
            return RaceSpecialAbilitys;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.RaceSpecialAbilityID = (int)result.GetValue(result.GetOrdinal("RaceSpecialAbilityID"));
                this.RaceSpecialAbilityName = result.GetValue(result.GetOrdinal("RaceSpecialAbilityName")).ToString();
                this.RaceSpecialAbilityDescription = result.GetValue(result.GetOrdinal("RaceSpecialAbilityDescription")).ToString();
            }
        }

        private void SetReaderToObject(ref RaceSpecialAbility objRaceSpecialAbility, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objRaceSpecialAbility.RaceSpecialAbilityID = (int)result.GetValue(result.GetOrdinal("RaceSpecialAbilityID"));
                objRaceSpecialAbility.RaceSpecialAbilityName = result.GetValue(result.GetOrdinal("RaceSpecialAbilityName")).ToString();
                objRaceSpecialAbility.RaceSpecialAbilityDescription = result.GetValue(result.GetOrdinal("RaceSpecialAbilityDescription")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
