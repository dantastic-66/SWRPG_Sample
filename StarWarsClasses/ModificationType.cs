using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class ModificationType : BaseValidation
    {


        public int ModificationTypeID { get; set; }
        public string ModificationTypeName { get; set; }
        public string ModificationTypeDescription { get; set; }


        #region Constructors
        public ModificationType()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModificationType"/> class.
        /// </summary>
        /// <param name="ModificationTypeName">Name of the ModificationType.</param>
        public ModificationType(string ModificationTypeName)
        {
            SetBaseConstructorOptions();
            GetModificationType(ModificationTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModificationType"/> class.
        /// </summary>
        /// <param name="ModificationTypeID">The ModificationType identifier.</param>
        public ModificationType(int ModificationTypeID)
        {
            SetBaseConstructorOptions();
            GetModificationType(ModificationTypeID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public ModificationType GetModificationType(int ModificationTypeID)
        {
            return GetSingleModificationType("Select_ModificationType", " ModificationTypeID = " + ModificationTypeID.ToString(), "");
        }

        public ModificationType GetModificationType(string ModificationTypeName)
        {
            return GetSingleModificationType("Select_ModificationType", " ModificationTypeName='" + ModificationTypeID.ToString() + "'", "");
        }

        public List<ModificationType> GetModificationTypes(string strWhere, string strOrderBy)
        {
            return GetModificationTypeList("Select_ModificationType", strWhere, strOrderBy);
        }


        public List<ModificationType > GetModificationTypesByModfication (int ModificationID)
        {
            return GetModificationTypeList("Select_ModificationTypeByModification", "ModificationID=" + ModificationID.ToString(), "ModificationTypeName");
        }

        public ModificationType SaveModificationType()
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
                command.CommandText = "InsertUpdate_ModificationType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationTypeID", SqlDbType.Int, ModificationTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationTypeName", SqlDbType.VarChar , ModificationTypeName, 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationTypeDescription", SqlDbType.VarChar, ModificationTypeDescription, 100));


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
        /// Delete the ModificationType.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteModificationType()
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
                command.CommandText = "Delete_ModificationType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationTypeID", SqlDbType.Int, ModificationTypeID.ToString(), 0));
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

        #region Static Methods
        /// <summary>
        /// Clones the specified object ModificationType.
        /// </summary>
        /// <param name="objModificationType">The object ModificationType.</param>
        /// <returns>ModificationType</returns>
        static public ModificationType Clone(ModificationType objModificationType)
        {
            ModificationType objCModificationType = new ModificationType(objModificationType.ModificationTypeID );

            objCModificationType.ModificationTypeID = objModificationType.ModificationTypeID;
            objCModificationType.ModificationTypeName = objModificationType.ModificationTypeName;
            objCModificationType.ModificationTypeDescription = objModificationType.ModificationTypeDescription;

            return objCModificationType;
        }

        /// <summary>
        /// Clones the specified LST ModificationType.
        /// </summary>
        /// <param name="lstModificationType">The LST ModificationType.</param>
        /// <returns>List<ModificationType></returns>
        static public List<ModificationType> Clone(List<ModificationType> lstModificationType)
        {
            List<ModificationType> lstCModificationType = new List<ModificationType>();

            foreach (ModificationType objModificationType in lstModificationType)
            {
                lstCModificationType.Add(ModificationType.Clone(objModificationType));
            }

            return lstCModificationType;
        }
        #endregion
        #endregion

        #region Private Methods
        private ModificationType GetSingleModificationType(string sprocName, string strWhere, string strOrderBy)
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

        private List<ModificationType> GetModificationTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ModificationType> ModificationTypes = new List<ModificationType>();

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
                    ModificationType objModificationType = new ModificationType();
                    SetReaderToObject(ref objModificationType, ref result);
                    ModificationTypes.Add(objModificationType);
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
            return ModificationTypes;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ModificationTypeID = (int)result.GetValue(result.GetOrdinal("ModificationTypeID"));
                this.ModificationTypeName = result.GetValue(result.GetOrdinal("ModificationTypeName")).ToString();
                this.ModificationTypeDescription = result.GetValue(result.GetOrdinal("ModificationTypeDescription")).ToString();
            }
        }

        private void SetReaderToObject(ref ModificationType objModificationType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objModificationType.ModificationTypeID = (int)result.GetValue(result.GetOrdinal("ModificationTypeID"));
                objModificationType.ModificationTypeName = result.GetValue(result.GetOrdinal("ModificationTypeName")).ToString();
                objModificationType.ModificationTypeDescription = result.GetValue(result.GetOrdinal("ModificationTypeDescription")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
