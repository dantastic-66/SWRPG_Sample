using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class RaceSkillConditionalFeat : BaseValidation
    {


        public int RaceID { get; set; }
        public int SkillID { get; set; }
        public int ConditionalFeatID { get; set; }


        public Skill objSkill { get; set; }
        public Feat objConditionalFeat { get; set; }



        #region Constructors
        public RaceSkillConditionalFeat()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceSkillConditionalFeat"/> class.
        /// </summary>
        /// <param name="RaceID">The Race identifier.</param>
        /// <param name="SkillID">The Skill identifier.</param>
        /// <param name="ConditionalFeatID">The ConditionalFeat identifier.</param>
        public RaceSkillConditionalFeat(int RaceID, int SkillID, int ConditionalFeatID)
        {
            SetBaseConstructorOptions();
            GetRaceSkillConditionalFeat(RaceID, SkillID, ConditionalFeatID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public RaceSkillConditionalFeat GetRaceSkillConditionalFeat(int RaceID, int SkillID, int ConditionalFeatID)
        {
            return GetSingleRaceSkillConditionalFeat("Select_RaceSkillConditionalFeat", "  RaceID=" + RaceID.ToString() + " AND SkillID=" + SkillID.ToString() + " AND ConditionalFeatID=" + ConditionalFeatID.ToString(), "");
        }

        public List<RaceSkillConditionalFeat> GetRaceSkillConditionalFeatsByRaceID(int RaceID)
        {
            return GetRaceSkillConditionalFeatList("Select_RaceSkillConditionalFeat", " RaceID=" + RaceID.ToString(), "");
        }

        public List<RaceSkillConditionalFeat> GetRaceSkillConditionalFeats(string strWhere, string strOrderBy)
        {
            return GetRaceSkillConditionalFeatList("Select_RaceSkillConditionalFeat", strWhere, strOrderBy);
        }

        public RaceSkillConditionalFeat SaveRaceSkillConditionalFeat()
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
                command.CommandText = "InsertUpdate_RaceSkillConditionalFeat";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillID", SqlDbType.Int, SkillID.ToString(), 0));
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
        /// Delete the RaceSkillConditionalFeat.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteRaceSkillConditionalFeat()
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
                command.CommandText = "Delete_RaceSkillConditionalFeat";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillID", SqlDbType.Int, SkillID.ToString(), 0));
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
        /// Clones the specified object RaceSkillConditionalFeat.
        /// </summary>
        /// <param name="objRaceSkillConditionalFeat">The object RaceSkillConditionalFeat.</param>
        /// <returns>RaceSkillConditionalFeat</returns>
        static public RaceSkillConditionalFeat Clone(RaceSkillConditionalFeat objRaceSkillConditionalFeat)
        {
            RaceSkillConditionalFeat objCRaceSkillConditionalFeat = new RaceSkillConditionalFeat(objRaceSkillConditionalFeat.RaceID,objRaceSkillConditionalFeat.SkillID,objRaceSkillConditionalFeat.ConditionalFeatID );
            return objCRaceSkillConditionalFeat;
        }

        /// <summary>
        /// Clones the specified LST RaceSkillConditionalFeat.
        /// </summary>
        /// <param name="lstRaceSkillConditionalFeat">The LST RaceSkillConditionalFeat.</param>
        /// <returns>List<RaceSkillConditionalFeat></returns>
        static public List<RaceSkillConditionalFeat> Clone(List<RaceSkillConditionalFeat> lstRaceSkillConditionalFeat)
        {
            List<RaceSkillConditionalFeat> lstCRaceSkillConditionalFeat = new List<RaceSkillConditionalFeat>();

            foreach (RaceSkillConditionalFeat objRaceSkillConditionalFeat in lstRaceSkillConditionalFeat)
            {
                lstCRaceSkillConditionalFeat.Add(RaceSkillConditionalFeat.Clone(objRaceSkillConditionalFeat));
            }

            return lstCRaceSkillConditionalFeat;
        }
        #endregion

        #region Private Methods
        private RaceSkillConditionalFeat GetSingleRaceSkillConditionalFeat(string sprocName, string strWhere, string strOrderBy)
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

        private List<RaceSkillConditionalFeat> GetRaceSkillConditionalFeatList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<RaceSkillConditionalFeat> RaceSkillConditionalFeats = new List<RaceSkillConditionalFeat>();

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
                    RaceSkillConditionalFeat objRaceSkillConditionalFeat = new RaceSkillConditionalFeat();
                    SetReaderToObject(ref objRaceSkillConditionalFeat, ref result);
                    RaceSkillConditionalFeats.Add(objRaceSkillConditionalFeat);
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
            return RaceSkillConditionalFeats;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                this.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                this.ConditionalFeatID = (int)result.GetValue(result.GetOrdinal("ConditionalFeatID"));

                Skill objSkill = new Skill(this.SkillID);
                Feat objConFeat = new Feat(this.ConditionalFeatID);
                this.objSkill = objSkill;
                this.objConditionalFeat = objConFeat;
            }
        }

        private void SetReaderToObject(ref RaceSkillConditionalFeat objRaceSkillConditionalFeat, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objRaceSkillConditionalFeat.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));
                objRaceSkillConditionalFeat.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                objRaceSkillConditionalFeat.ConditionalFeatID = (int)result.GetValue(result.GetOrdinal("ConditionalFeatID"));

                Skill objSkill = new Skill(objRaceSkillConditionalFeat.SkillID);
                Feat objConFeat = new Feat(objRaceSkillConditionalFeat.ConditionalFeatID);
                objRaceSkillConditionalFeat.objSkill = objSkill;
                objRaceSkillConditionalFeat.objConditionalFeat = objConFeat;
            }
        }

        #endregion
        #endregion
    }
}
