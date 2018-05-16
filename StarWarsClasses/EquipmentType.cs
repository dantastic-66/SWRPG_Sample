using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class EquipmentType : BaseValidation
    {


        public int EquipmentTypeID { get; set; }
        public string EquipmentTypeName { get; set; }
        public string EquipmentTypeDescription { get; set; }


        #region Constructors
        public EquipmentType()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentType"/> class.
        /// </summary>
        /// <param name="EquipmentTypeName">Name of the EquipmentType.</param>
        public EquipmentType(string EquipmentTypeName)
        {
            SetBaseConstructorOptions();
            GetEquipmentType(EquipmentTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentType"/> class.
        /// </summary>
        /// <param name="EquipmentTypeID">The EquipmentType identifier.</param>
        public EquipmentType(int EquipmentTypeID)
        {
            SetBaseConstructorOptions();
            GetEquipmentType(EquipmentTypeID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public EquipmentType GetEquipmentType(int EquipmentTypeID)
        {
            return GetSingleEquipmentType("Select_EquipmentType", " EquipmentTypeID = " + EquipmentTypeID.ToString(), "");
        }

        public EquipmentType GetEquipmentType(string EquipmentTypeName)
        {
            return GetSingleEquipmentType("Select_EquipmentType", " EquipmentTypeName='" + EquipmentTypeID.ToString() + "'", "");
        }

        public List<EquipmentType> GetEquipmentTypes(string strWhere, string strOrderBy)
        {
            return GetEquipmentTypeList("Select_EquipmentType", strWhere, strOrderBy);
        }

        public List<EquipmentType>  GetEquipmentTypesByCharacterID (int CharacterID)
        {
            return GetEquipmentTypeList("Select_EquipmentTypeByCharacterID", "CharacterID=" + CharacterID.ToString(), "EquipmentTypeName");
        }

        public EquipmentType SaveEquipmentType()
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
                command.CommandText = "InsertUpdate_EquipmentType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentTypeID", SqlDbType.Int, EquipmentTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentTypeName", SqlDbType.VarChar , EquipmentTypeName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentTypeDescription", SqlDbType.Int, EquipmentTypeDescription.ToString(), 100));
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
        /// Delete the EquipmentType.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteEquipmentType()
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
                command.CommandText = "Delete_EquipmentType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentTypeID", SqlDbType.Int, EquipmentTypeID.ToString(), 0));
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
        private EquipmentType GetSingleEquipmentType(string sprocName, string strWhere, string strOrderBy)
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

        private List<EquipmentType> GetEquipmentTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<EquipmentType> EquipmentTypes = new List<EquipmentType>();

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
                    EquipmentType objEquipmentType = new EquipmentType();
                    SetReaderToObject(ref objEquipmentType, ref result);
                    EquipmentTypes.Add(objEquipmentType);
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
            return EquipmentTypes;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.EquipmentTypeID = (int)result.GetValue(result.GetOrdinal("EquipmentTypeID"));
                this.EquipmentTypeName = result.GetValue(result.GetOrdinal("EquipmentTypeName")).ToString();
                this.EquipmentTypeDescription = result.GetValue(result.GetOrdinal("EquipmentTypeDescription")).ToString();
            }
        }

        private void SetReaderToObject(ref EquipmentType objEquipmentType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objEquipmentType.EquipmentTypeID = (int)result.GetValue(result.GetOrdinal("EquipmentTypeID"));
                objEquipmentType.EquipmentTypeName = result.GetValue(result.GetOrdinal("EquipmentTypeName")).ToString();
                objEquipmentType.EquipmentTypeDescription = result.GetValue(result.GetOrdinal("EquipmentTypeDescription")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
