using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class Organization : BaseValidation
    {


        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDescription { get; set; }
        public int ScaleID { get; set; }
        public int OrganizationTypeID { get; set; }
        public string OrganizationAllies { get; set; }
        public string OrganizationEnemies { get; set; }
        public int ForceTraditionID { get; set; }

        public OrganizationScale objOrganizationScale { get; set; }
        public OrganizationType objOrganizationType { get; set; }
        public ForceTradition objForceTradition { get; set; }

        #region Constructors
        public Organization()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Organization"/> class.
        /// </summary>
        /// <param name="OrganizationName">Name of the Organization.</param>
        public Organization(string OrganizationName)
        {
            SetBaseConstructorOptions();
            GetOrganization(OrganizationName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Organization"/> class.
        /// </summary>
        /// <param name="OrganizationID">The Organization identifier.</param>
        public Organization(int OrganizationID)
        {
            SetBaseConstructorOptions();
            GetOrganization(OrganizationID);
        }

        #endregion


        #region Methods
        #region Public Methods
        public Organization GetOrganization(int OrganizationID)
        {
            return GetSingleOrganization("Select_Organization", " OrganizationID = " + OrganizationID.ToString(), "");
        }

        public List<Organization> GetCharacterOrganizations(int CharID)
        {
            return GetOrganizationList("Select_CharacterOrganizations", " CharacterID=" + CharID.ToString(), "OrganizationName");
        }

        public Organization GetOrganization(string OrganizationName)
        {
            return GetSingleOrganization("Select_Organization", " OrganizationName ='" + OrganizationName.ToString() + "'", "");
        }

        public List<Organization> GetOrganizations(string strWhere, string strOrderBy)
        {
            return GetOrganizationList("Select_Organization", strWhere, strOrderBy);
        }

        public Organization SaveOrganization()
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
                command.CommandText = "InsertUpdate_Organization";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationID", SqlDbType.Int, OrganizationID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationName", SqlDbType.VarChar, OrganizationName, 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationDescription", SqlDbType.VarChar, OrganizationDescription, 4000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ScaleID", SqlDbType.Int, ScaleID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationTypeID", SqlDbType.Int, OrganizationTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationAllies", SqlDbType.VarChar , OrganizationAllies, 4000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationEnemies", SqlDbType.VarChar, OrganizationEnemies, 4000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTraditionID", SqlDbType.Int, ForceTraditionID.ToString(), 0));
                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK  = false;
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
        /// Deletes the character Organization.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="OrganizationID">The Organization identifier.</param>
        /// <returns></returns>
        public bool DeleteCharacterOrganization(int CharacterID, int OrganizationID)
        {
            bool retDeleteSuccessful = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_CharacterOrganization";

                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationID", SqlDbType.VarChar, OrganizationID.ToString(), 1000));
                result = command.ExecuteReader();

            }
            catch
            {
                retDeleteSuccessful = false;
                Exception e = new Exception();
                this._validated = false;
                this._validationMessage.Append(e.Message.ToString());
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return retDeleteSuccessful;
        }

        /// <summary>
        /// Saves a List of Organizations to a Character.
        /// </summary>
        /// <param name="lstCharOrganization">A <List> of Organizations .</param>
        /// <param name="intCharacterID">The Character identifier.</param>
        /// <returns></returns>
        public void SaveCharacterOrganizations(List<Organization> lstCharOrganization, int intCharacterID)
        {
            //Once a Organization is added it can be removed, added or updated, so we need to reset the whole thing
            Organization objDelOrganization = new Organization();
            objDelOrganization.DeleteCharacterOrganization(intCharacterID, 0);

            foreach (Organization objCharOrganization in lstCharOrganization)
            {
                objCharOrganization.SaveCharacterOrganization(intCharacterID, objCharOrganization.OrganizationID);
            }
        }

        /// <summary>
        /// Saves the character Organization.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="OrganizationID">The Organization identifier.</param>
        /// <returns></returns>
        public Organization SaveCharacterOrganization(int CharacterID, int OrganizationID)
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
                command.CommandText = "InsertUpdate_CharacterOrganization";

                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationID", SqlDbType.VarChar, OrganizationID.ToString(), 1000));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._validated = false;
                this._validationMessage.Append(e.Message.ToString());
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return GetOrganization(OrganizationID);

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
        /// Deletes the Organization.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteOrganization()
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
                command.CommandText = "Delete_Organization";
                command.Parameters.Add(dbconn.GenerateParameterObj("@OrganizationID", SqlDbType.Int, OrganizationID.ToString(), 0));
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
        /// Clones the specified object Organization.
        /// </summary>
        /// <param name="objOrganization">The object Organization.</param>
        /// <returns>Organization</returns>
        static public Organization Clone(Organization objOrganization)
        {
            Organization objCOrganization = new Organization(objOrganization.OrganizationID);
            return objCOrganization;
        }

        /// <summary>
        /// Clones the specified LST Organization.
        /// </summary>
        /// <param name="lstOrganization">The LST Organization.</param>
        /// <returns>List<Organization></returns>
        static public List<Organization> Clone(List<Organization> lstOrganization)
        {
            List<Organization> lstCOrganization = new List<Organization>();

            foreach (Organization objOrganization in lstOrganization)
            {
                lstCOrganization.Add(Organization.Clone(objOrganization));
            }

            return lstCOrganization;
        }
        #endregion

        #region Private Methods
        private Organization GetSingleOrganization(string sprocName, string strWhere, string strOrderBy)
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

        private List<Organization> GetOrganizationList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Organization> Organizations = new List<Organization>();

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
                    Organization objOrganization = new Organization();
                    SetReaderToObject(ref objOrganization, ref result);
                    Organizations.Add(objOrganization);
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
            return Organizations;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.OrganizationID = (int)result.GetValue(result.GetOrdinal("OrganizationID"));
                this.OrganizationName = result.GetValue(result.GetOrdinal("OrganizationName")).ToString();
                this.OrganizationDescription = result.GetValue(result.GetOrdinal("OrganizationDescription")).ToString();
                this.ScaleID = (int)result.GetValue(result.GetOrdinal("ScaleID"));
                this.OrganizationTypeID = (int)result.GetValue(result.GetOrdinal("OrganizationTypeID"));
                this.OrganizationAllies = result.GetValue(result.GetOrdinal("OrganizationAllies")).ToString();
                this.OrganizationEnemies = result.GetValue(result.GetOrdinal("OrganizationEnemies")).ToString();
                this.ForceTraditionID = (int)result.GetValue(result.GetOrdinal("ForceTraditionID"));

                if (this.ForceTraditionID != 0)
                {
                    ForceTradition objForceTrad = new ForceTradition(this.ForceTraditionID);
                    this.objForceTradition = objForceTrad;
                }

                this.objOrganizationScale = new OrganizationScale(this.ScaleID);
                this.objOrganizationType = new OrganizationType(this.OrganizationTypeID);
            }
        }

        private void SetReaderToObject(ref Organization objOrganization, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objOrganization.OrganizationID = (int)result.GetValue(result.GetOrdinal("OrganizationID"));
                objOrganization.OrganizationName = result.GetValue(result.GetOrdinal("OrganizationName")).ToString();
                objOrganization.OrganizationDescription = result.GetValue(result.GetOrdinal("OrganizationDescription")).ToString();
                objOrganization.ScaleID = (int)result.GetValue(result.GetOrdinal("ScaleID"));
                objOrganization.OrganizationTypeID = (int)result.GetValue(result.GetOrdinal("OrganizationTypeID"));
                objOrganization.OrganizationAllies = result.GetValue(result.GetOrdinal("OrganizationAllies")).ToString();
                objOrganization.OrganizationEnemies = result.GetValue(result.GetOrdinal("OrganizationEnemies")).ToString();
                objOrganization.ForceTraditionID = (int)result.GetValue(result.GetOrdinal("ForceTraditionID"));

                if (objOrganization.ForceTraditionID != 0)
                {
                    ForceTradition objForceTrad = new ForceTradition(this.ForceTraditionID);
                    objOrganization.objForceTradition = objForceTrad;
                }

                objOrganization.objOrganizationScale = new OrganizationScale(this.ScaleID);
                objOrganization.objOrganizationType = new OrganizationType(this.OrganizationTypeID);
            }
        }
        #endregion
        #endregion
    }
}
