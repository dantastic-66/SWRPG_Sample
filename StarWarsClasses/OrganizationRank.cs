using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class OrganizationRank : BaseValidation
    {


        public int OrganizationRankID { get; set; }
        public int OrganizationID { get; set; }
        public int OrganizationRankLevel { get; set; }
        public int ScoreMin { get; set; }
        public int ScoreMax { get; set; }
        public string Title { get; set; }
        public string Benefits { get; set; }
        public string Duties { get; set; }

        public Organization objOrganization { get; set; }

        #region Constructors
        public OrganizationRank()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationRankLevel"/> class.
        /// </summary>
        /// <param name="OrganizationRankName">Name of the OrganizationRank.</param>
        public OrganizationRank(string OrganizationRankName)
        {
            SetBaseConstructorOptions();
            GetOrganizationRank(OrganizationRankName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationRankLevel"/> class.
        /// </summary>
        /// <param name="OrganizationRankID">The OrganizationRank identifier.</param>
        public OrganizationRank(int OrganizationRankID)
        {
            SetBaseConstructorOptions();
            GetOrganizationRank(OrganizationRankID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public OrganizationRank GetOrganizationRank(int OrganizationRankID)
        {
            return GetSingleOrganizationRank("Select_OrganizationRank", " OrganizationRankID = " + OrganizationRankID.ToString(), "");
        }

        public OrganizationRank GetOrganizationRank(string OrganizationRankName)
        {
            return GetSingleOrganizationRank("Select_OrganizationRank", " OrganizationRankName='" + OrganizationRankID.ToString() + "'", "");
        }

        public List<OrganizationRank> GetOrganizationRanks(string strWhere, string strOrderBy)
        {
            return GetOrganizationRankList("Select_OrganizationRank", strWhere, strOrderBy);
        }

        public OrganizationRank SaveOrganizationRank()
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
                command.CommandText = "InsertUpdate_OrganizationRank";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationRankID", SqlDbType.Int, OrganizationRankID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationID", SqlDbType.Int, OrganizationID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationRankLevel", SqlDbType.Int, OrganizationRankLevel.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ScoreMin", SqlDbType.Int, ScoreMin.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ScoreMax", SqlDbType.Int, ScoreMax.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Title", SqlDbType.VarChar, Title, 400));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Benefits", SqlDbType.VarChar , Benefits, 4000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Duties", SqlDbType.Int, Duties, 4000));
                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK  = false;
                this._insertUpdateMessage .Append(e.Message.ToString());
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
        /// Delete the OrganizationRank.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteOrganizationRank()
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
                command.CommandText = "Delete_OrganizationRank";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationRankID", SqlDbType.Int, OrganizationRankID.ToString(), 0));
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
        /// Clones the specified object OrganizationRank.
        /// </summary>
        /// <param name="objOrganizationRank">The object OrganizationRank.</param>
        /// <returns>OrganizationRank</returns>
        static public OrganizationRank Clone(OrganizationRank objOrganizationRank)
        {
            OrganizationRank objCOrganizationRank = new OrganizationRank(objOrganizationRank.OrganizationRankID);
            return objCOrganizationRank;
        }

        /// <summary>
        /// Clones the specified LST OrganizationRank.
        /// </summary>
        /// <param name="lstOrganizationRank">The LST OrganizationRank.</param>
        /// <returns>List<OrganizationRank></returns>
        static public List<OrganizationRank> Clone(List<OrganizationRank> lstOrganizationRank)
        {
            List<OrganizationRank> lstCOrganizationRank = new List<OrganizationRank>();

            foreach (OrganizationRank objOrganizationRank in lstOrganizationRank)
            {
                lstCOrganizationRank.Add(OrganizationRank.Clone(objOrganizationRank));
            }

            return lstCOrganizationRank;
        }
        #endregion

        #region Private Methods
        private OrganizationRank GetSingleOrganizationRank(string sprocName, string strWhere, string strOrderBy)
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

        private List<OrganizationRank> GetOrganizationRankList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<OrganizationRank> OrganizationRanks = new List<OrganizationRank>();

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
                    OrganizationRank objOrganizationRank = new OrganizationRank();
                    SetReaderToObject(ref objOrganizationRank, ref result);
                    OrganizationRanks.Add(objOrganizationRank);
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
            return OrganizationRanks;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.OrganizationRankID = (int)result.GetValue(result.GetOrdinal("OrganizationRankID"));
                this.OrganizationID = (int)result.GetValue(result.GetOrdinal("OrganizationID"));
                this.OrganizationRankLevel = (int)result.GetValue(result.GetOrdinal("OrganizationRankLevel"));
                this.ScoreMin = (int)result.GetValue(result.GetOrdinal("ScoreMin"));
                this.Title = result.GetValue(result.GetOrdinal("Title")).ToString();
                this.Benefits = result.GetValue(result.GetOrdinal("Benefits")).ToString();
                this.Duties = result.GetValue(result.GetOrdinal("Duties")).ToString();

                Organization objOrg = new Organization(this.OrganizationID);
                this.objOrganization = objOrg;
            }
        }

        private void SetReaderToObject(ref OrganizationRank objOrganizationRank, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objOrganizationRank.OrganizationRankID = (int)result.GetValue(result.GetOrdinal("OrganizationRankID"));
                objOrganizationRank.OrganizationID = (int)result.GetValue(result.GetOrdinal("OrganizationID"));
                objOrganizationRank.OrganizationRankLevel = (int)result.GetValue(result.GetOrdinal("OrganizationRankLevel"));
                objOrganizationRank.ScoreMin = (int)result.GetValue(result.GetOrdinal("ScoreMin"));
                objOrganizationRank.Title = result.GetValue(result.GetOrdinal("Title")).ToString();
                objOrganizationRank.Benefits = result.GetValue(result.GetOrdinal("Benefits")).ToString();
                objOrganizationRank.Duties = result.GetValue(result.GetOrdinal("Duties")).ToString();

                Organization objOrg = new Organization(this.OrganizationID);
                objOrganizationRank.objOrganization = objOrg;
            }
        }

        #endregion
        #endregion
    }
}
