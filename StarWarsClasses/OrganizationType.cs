using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class OrganizationType : BaseValidation
    {


        public int OrganizationTypeID { get; set; }
        public string OrganizationTypeName { get; set; }
        public string KnowledgeSpeciality { get; set; }


        #region Constructors
        public OrganizationType()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationType"/> class.
        /// </summary>
        /// <param name="OrganizationTypeName">Name of the OrganizationType.</param>
        public OrganizationType(string OrganizationTypeName)
        {
            SetBaseConstructorOptions();
            GetOrganizationType(OrganizationTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationType"/> class.
        /// </summary>
        /// <param name="OrganizationTypeID">The OrganizationType identifier.</param>
        public OrganizationType(int OrganizationTypeID)
        {
            SetBaseConstructorOptions();
            GetOrganizationType(OrganizationTypeID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public OrganizationType GetOrganizationType(int OrganizationTypeID)
        {
            return GetSingleOrganizationType("Select_OrganizationType", " OrganizationTypeID = " + OrganizationTypeID.ToString(), "");
        }

        public OrganizationType GetOrganizationType(string OrganizationTypeName)
        {
            return GetSingleOrganizationType("Select_OrganizationType", " OrganizationTypeName='" + OrganizationTypeID.ToString() + "'", "");
        }

        public List<OrganizationType> GetOrganizationTypes(string strWhere, string strOrderBy)
        {
            return GetOrganizationTypeList("Select_OrganizationType", strWhere, strOrderBy);
        }

        public OrganizationType SaveOrganizationType()
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
                command.CommandText = "InsertUpdate_OrganizationType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationTypeID", SqlDbType.Int, OrganizationTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationTypeName", SqlDbType.VarChar, OrganizationTypeName, 200));
                command.Parameters.Add(dbconn.GenerateParameterObj("@KnowledgeSpeciality", SqlDbType.VarChar, KnowledgeSpeciality, 200));
                //    command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterLevelArmor", SqlDbType.Int, CharacterLevelArmor.ToString(), 0));
                //    command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityMod", SqlDbType.Int, AbilityMod.ToString(), 0));
                //    command.Parameters.Add(dbconn.GenerateParameterObj("@ClassMod", SqlDbType.Int, ClassMod.ToString(), 0));
                //    command.Parameters.Add(dbconn.GenerateParameterObj("@RaceMod", SqlDbType.Int, RaceMod.ToString(), 0));
                //    command.Parameters.Add(dbconn.GenerateParameterObj("@FeatTalentMod", SqlDbType.Int, FeatTalentMod.ToString(), 0));
                //    command.Parameters.Add(dbconn.GenerateParameterObj("@MiscellaneousMod", SqlDbType.Int, MiscellaneousMod.ToString(), 0));

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
        /// Delete the OrganizationType.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteOrganizationType()
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
                command.CommandText = "Delete_OrganizationType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationTypeID", SqlDbType.Int, OrganizationTypeID.ToString(), 0));
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
        /// Clones the specified object OrganizationType.
        /// </summary>
        /// <param name="objOrganizationType">The object OrganizationType.</param>
        /// <returns>OrganizationType</returns>
        static public OrganizationType Clone(OrganizationType objOrganizationType)
        {
            OrganizationType objCOrganizationType = new OrganizationType(objOrganizationType.OrganizationTypeID);
            return objCOrganizationType;
        }

        /// <summary>
        /// Clones the specified LST OrganizationType.
        /// </summary>
        /// <param name="lstOrganizationType">The LST OrganizationType.</param>
        /// <returns>List<OrganizationType></returns>
        static public List<OrganizationType> Clone(List<OrganizationType> lstOrganizationType)
        {
            List<OrganizationType> lstCOrganizationType = new List<OrganizationType>();

            foreach (OrganizationType objOrganizationType in lstOrganizationType)
            {
                lstCOrganizationType.Add(OrganizationType.Clone(objOrganizationType));
            }

            return lstCOrganizationType;
        }
        #endregion

        #region Private Methods
        private OrganizationType GetSingleOrganizationType(string sprocName, string strWhere, string strOrderBy)
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

        private List<OrganizationType> GetOrganizationTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<OrganizationType> OrganizationTypes = new List<OrganizationType>();

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
                    OrganizationType objOrganizationType = new OrganizationType();
                    SetReaderToObject(ref objOrganizationType, ref result);
                    OrganizationTypes.Add(objOrganizationType);
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
            return OrganizationTypes;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.OrganizationTypeID = (int)result.GetValue(result.GetOrdinal("OrganizationTypeID"));
                this.OrganizationTypeName = result.GetValue(result.GetOrdinal("OrganizationTypeName")).ToString();
                this.KnowledgeSpeciality = result.GetValue(result.GetOrdinal("KnowledgeSpeciality")).ToString();
            }
        }

        private void SetReaderToObject(ref OrganizationType objOrganizationType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objOrganizationType.OrganizationTypeID = (int)result.GetValue(result.GetOrdinal("OrganizationTypeID"));
                objOrganizationType.OrganizationTypeName = result.GetValue(result.GetOrdinal("OrganizationTypeName")).ToString();
                objOrganizationType.KnowledgeSpeciality = result.GetValue(result.GetOrdinal("KnowledgeSpeciality")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
