using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class RaceLanguage : BaseValidation
    {

        public int RaceID { get; set; }
        public int LanguageID { get; set; }
        public bool UnderstandOnly { get; set; }
        public bool SpeakOnly { get; set; }

        public Language objLanguage { get; set; }

        #region Constructors
        public RaceLanguage()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceLanguage"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        /// <param name="LanguageID">The Language identifier.</param>
        public RaceLanguage(int RaceID, int LanguageID)
        {
            SetBaseConstructorOptions();
            GetRaceLanguage(RaceID, LanguageID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public RaceLanguage GetRaceLanguage(int RaceID, int LanguageID)
        {
            return GetSingleRaceLanguage("Select_RaceLanguage", " RaceID=" + RaceID.ToString() + " AND LanguageID=" + LanguageID.ToString(), "");
        }

        public List<RaceLanguage> GetRaceLanguages(int RaceID, int LanguageID)
        {
            return GetRaceLanguageList("Select_RaceLanguage", " RaceID=" + RaceID.ToString() + " AND LanguageID=" + LanguageID.ToString(), "");
        }

        public List<RaceLanguage> GetRaceLanguages(string strWhere, string strOrderBy)
        {
            return GetRaceLanguageList("Select_RaceLanguage", strWhere, strOrderBy);
        }

        
        public RaceLanguage SaveRaceLanguage()
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
                command.CommandText = "InsertUpdate_RaceLanguage";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@LanguageID", SqlDbType.Int, LanguageID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@UnderstandOnly", SqlDbType.Bit , UnderstandOnly.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SpeakOnly", SqlDbType.Bit, SpeakOnly.ToString(), 0));

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
        /// Delete the RaceLanguage.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteRaceLanguage()
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
                command.CommandText = "Delete_RaceLanguage";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
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
        /// Clones the specified object RaceLanguage.
        /// </summary>
        /// <param name="objRaceLanguage">The object RaceLanguage.</param>
        /// <returns>RaceLanguage</returns>
        static public RaceLanguage Clone(RaceLanguage objRaceLanguage)
        {
            RaceLanguage objCRaceLanguage = new RaceLanguage(objRaceLanguage.RaceID, objRaceLanguage.LanguageID );
            return objCRaceLanguage;
        }

        /// <summary>
        /// Clones the specified LST RaceLanguage.
        /// </summary>
        /// <param name="lstRaceLanguage">The LST RaceLanguage.</param>
        /// <returns>List<RaceLanguage></returns>
        static public List<RaceLanguage> Clone(List<RaceLanguage> lstRaceLanguage)
        {
            List<RaceLanguage> lstCRaceLanguage = new List<RaceLanguage>();

            foreach (RaceLanguage objRaceLanguage in lstRaceLanguage)
            {
                lstCRaceLanguage.Add(RaceLanguage.Clone(objRaceLanguage));
            }

            return lstCRaceLanguage;
        }
        #endregion

        #region Private Methods
        private RaceLanguage GetSingleRaceLanguage(string sprocName, string strWhere, string strOrderBy)
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

        private List<RaceLanguage> GetRaceLanguageList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<RaceLanguage> RaceLanguages = new List<RaceLanguage>();

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
                    RaceLanguage objRaceLanguage = new RaceLanguage();
                    SetReaderToObject(ref objRaceLanguage, ref result);
                    RaceLanguages.Add(objRaceLanguage);
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
            return RaceLanguages;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            
            if (result.HasRows)
            {
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                this.LanguageID = (int)result.GetValue(result.GetOrdinal("LanguageID"));
                this.UnderstandOnly = (bool)result.GetValue(result.GetOrdinal("UnderstandOnly"));
                this.SpeakOnly = (bool)result.GetValue(result.GetOrdinal("SpeakOnly"));

                Language objLang = new Language(this.LanguageID);
                this.objLanguage = objLang;
            }
        }

        private void SetReaderToObject(ref RaceLanguage objRaceLanguage, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objRaceLanguage.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                objRaceLanguage.LanguageID = (int)result.GetValue(result.GetOrdinal("LanguageID"));
                objRaceLanguage.UnderstandOnly = (bool)result.GetValue(result.GetOrdinal("UnderstandOnly"));
                objRaceLanguage.SpeakOnly = (bool)result.GetValue(result.GetOrdinal("SpeakOnly"));

                Language objLang = new Language(objRaceLanguage.LanguageID);
                objRaceLanguage.objLanguage = objLang;
            }
        }

        #endregion
        #endregion
    }
}
