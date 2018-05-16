using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class RaceFeatConditionalFeat : BaseValidation
    {


        public int RaceID { get; set; }
        public int FeatID { get; set; }
        public int ConditionalFeatID { get; set; }


        public Feat objFeat { get; set; }
        public Feat objConditionalFeat { get; set; }

        #region Constructors
        public RaceFeatConditionalFeat()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceFeatConditionalFeat"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        /// <param name="FeatID">The Feat identifier.</param>
        /// <param name="ConditionalFeatID">The ConditionalFeat identifier.</param>
        public RaceFeatConditionalFeat(int RaceID, int FeatID, int ConditionalFeatID)
        {
            SetBaseConstructorOptions();
            GetRaceFeatConditionalFeat(RaceID, FeatID, ConditionalFeatID );
        }
        #endregion


        #region Methods
        #region Public Methods
        public RaceFeatConditionalFeat GetRaceFeatConditionalFeat(int RaceID, int FeatID, int ConditionalFeatID)
        {
            return GetSingleRaceFeatConditionalFeat("Select_RaceFeatConditionalFeat", " RaceID=" + RaceID.ToString() + " AND FeatID=" +FeatID.ToString() + " AND ConditionalFeatID=" + ConditionalFeatID.ToString(), "");
        }

        public List<RaceFeatConditionalFeat> GetRaceFeatConditionalFeats(string strWhere, string strOrderBy)
        {
            return GetRaceFeatConditionalFeatList("Select_RaceFeatConditionalFeat", strWhere, strOrderBy);
        }

        public List<RaceFeatConditionalFeat> GetRaceFeatConditionalFeatsByRaceID(int RaceID)
        {
             return GetRaceFeatConditionalFeatList("Select_RaceFeatConditionalFeat", " RaceID=" + RaceID.ToString() , "");
        }

        public RaceFeatConditionalFeat SaveRaceFeatConditionalFeat()
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
                command.CommandText = "InsertUpdate_RaceFeatConditionalFeat";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ConditionalFeatID", SqlDbType.Int, ConditionalFeatID.ToString(), 0));

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
        /// Delete the RaceFeatConditionalFeat.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteRaceFeatConditionalFeat()
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
                command.CommandText = "Delete_RaceFeatConditionalFeat";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FeatID", SqlDbType.Int, FeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ConditionalFeatID", SqlDbType.Int, ConditionalFeatID.ToString(), 0));
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
        /// Clones the specified object RaceFeatConditionalFeat.
        /// </summary>
        /// <param name="objRaceFeatConditionalFeat">The object RaceFeatConditionalFeat.</param>
        /// <returns>RaceFeatConditionalFeat</returns>
        static public RaceFeatConditionalFeat Clone(RaceFeatConditionalFeat objRaceFeatConditionalFeat)
        {
            RaceFeatConditionalFeat objCRaceFeatConditionalFeat = new RaceFeatConditionalFeat(objRaceFeatConditionalFeat.RaceID, objRaceFeatConditionalFeat.FeatID, objRaceFeatConditionalFeat.ConditionalFeatID);
            return objCRaceFeatConditionalFeat;
        }

        /// <summary>
        /// Clones the specified LST RaceFeatConditionalFeat.
        /// </summary>
        /// <param name="lstRaceFeatConditionalFeat">The LST RaceFeatConditionalFeat.</param>
        /// <returns>List<RaceFeatConditionalFeat></returns>
        static public List<RaceFeatConditionalFeat> Clone(List<RaceFeatConditionalFeat> lstRaceFeatConditionalFeat)
        {
            List<RaceFeatConditionalFeat> lstCRaceFeatConditionalFeat = new List<RaceFeatConditionalFeat>();

            foreach (RaceFeatConditionalFeat objRaceFeatConditionalFeat in lstRaceFeatConditionalFeat)
            {
                lstCRaceFeatConditionalFeat.Add(RaceFeatConditionalFeat.Clone(objRaceFeatConditionalFeat));
            }

            return lstCRaceFeatConditionalFeat;
        }
        #endregion

        #region Private Methods
        private RaceFeatConditionalFeat GetSingleRaceFeatConditionalFeat(string sprocName, string strWhere, string strOrderBy)
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

        private List<RaceFeatConditionalFeat> GetRaceFeatConditionalFeatList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<RaceFeatConditionalFeat> RaceFeatConditionalFeats = new List<RaceFeatConditionalFeat>();

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
                    RaceFeatConditionalFeat objRaceFeatConditionalFeat = new RaceFeatConditionalFeat();
                    SetReaderToObject(ref objRaceFeatConditionalFeat, ref result);
                    RaceFeatConditionalFeats.Add(objRaceFeatConditionalFeat);
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
            return RaceFeatConditionalFeats;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                this.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                this.ConditionalFeatID = (int)result.GetValue(result.GetOrdinal("ConditionalFeatID"));

                Feat objFeat = new Feat(this.FeatID );
                Feat objConFeat = new Feat(this.ConditionalFeatID );
                this.objFeat = objFeat;
                this.objConditionalFeat = objConFeat;

            }
        }

        private void SetReaderToObject(ref RaceFeatConditionalFeat objRaceFeatConditionalFeat, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objRaceFeatConditionalFeat.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                objRaceFeatConditionalFeat.FeatID = (int)result.GetValue(result.GetOrdinal("FeatID"));
                objRaceFeatConditionalFeat.ConditionalFeatID = (int)result.GetValue(result.GetOrdinal("ConditionalFeatID"));

                Feat objFeat = new Feat(objRaceFeatConditionalFeat.FeatID);
                Feat objConFeat = new Feat(objRaceFeatConditionalFeat.ConditionalFeatID);
                objRaceFeatConditionalFeat.objFeat = objFeat;
                objRaceFeatConditionalFeat.objConditionalFeat = objConFeat;
            }
        }

        #endregion
        #endregion
    }
}
