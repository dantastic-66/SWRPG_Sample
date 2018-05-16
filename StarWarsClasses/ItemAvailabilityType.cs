using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class ItemAvailabilityType : BaseValidation
    {


        public int ItemAvailabilityTypeID { get; set; }
        public string ItemAvailabilityTypeName { get; set; }
        public string ItemAvailabilityTypeDescription { get; set; }
        public bool ArmorType { get; set; }
        public bool EquipmentType { get; set; }
        public bool WeaponType { get; set; }

        #region Constructors
        public ItemAvailabilityType()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAvailabilityType"/> class.
        /// </summary>
        /// <param name="ItemAvailabilityTypeName">Name of the ItemAvailabilityType.</param>
        public ItemAvailabilityType(string ItemAvailabilityTypeName)
        {
            SetBaseConstructorOptions();
            GetItemAvailabilityType(ItemAvailabilityTypeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAvailabilityType"/> class.
        /// </summary>
        /// <param name="ItemAvailabilityTypeID">The ItemAvailabilityType identifier.</param>
        public ItemAvailabilityType(int ItemAvailabilityTypeID)
        {
            SetBaseConstructorOptions();
            GetItemAvailabilityType(ItemAvailabilityTypeID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public ItemAvailabilityType GetItemAvailabilityType(int ItemAvailabilityTypeID)
        {
            return GetSingleItemAvailabilityType("Select_ItemAvailabilityType", " ItemAvailabilityTypeID = " + ItemAvailabilityTypeID.ToString(), "");
        }

        public ItemAvailabilityType GetItemAvailabilityType(string ItemAvailabilityTypeName)
        {
            return GetSingleItemAvailabilityType("Select_ItemAvailabilityType", " ItemAvailabilityTypeName='" + ItemAvailabilityTypeID.ToString() + "'", "");
        }

        public List<ItemAvailabilityType> GetItemAvailabilityTypes(string strWhere, string strOrderBy)
        {
            return GetItemAvailabilityTypeList("Select_ItemAvailabilityType", strWhere, strOrderBy);
        }
        
        public List<ItemAvailabilityType> GetArmorAvailabilityTypes()
        {
            return GetItemAvailabilityTypeList("Select_ItemAvailabilityType", "ArmorType=1","ItemAvailabilityTypeName");
        }

        public List<ItemAvailabilityType> GetArmorAvailabilityTypes(int ArmorID)
        {
            return GetItemAvailabilityTypeList("Select_ArmorItemAvailabilityType", "ArmorID=" + ArmorID.ToString(), "ItemAvailabilityTypeName");
        }

        public List<ItemAvailabilityType> GetEquipmentAvailabilityTypes()
        {
            return GetItemAvailabilityTypeList("Select_ItemAvailabilityType", "EquipmentType=1", "ItemAvailabilityTypeName");
        }

        public List<ItemAvailabilityType> GetEquipmentAvailabilityTypes(int EquipmentID)
        {
            return GetItemAvailabilityTypeList("Select_EquipmentItemAvailabilityType", "EquipmentID=" + EquipmentID.ToString(), "ItemAvailabilityTypeName");
        }

        public List<ItemAvailabilityType> GetWeaponAvailabilityTypes()
        {
            return GetItemAvailabilityTypeList("Select_ItemAvailabilityType", "WeaponType=1", "ItemAvailabilityTypeName");
        }

        public List<ItemAvailabilityType> GetWeaponAvailabilityTypes(int WeaponID)
        {
            return GetItemAvailabilityTypeList("Select_WeaponItemAvailabilityType", "WeaponID=" + WeaponID.ToString(), "ItemAvailabilityTypeName");
        }

        public ItemAvailabilityType SaveItemAvailabilityType()
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
                command.CommandText = "InsertUpdate_ItemAvailabilityType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ItemAvailabilityTypeID", SqlDbType.Int, ItemAvailabilityTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ItemAvailabilityTypeName", SqlDbType.VarChar, ItemAvailabilityTypeName, 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ItemAvailabilityTypeDescription", SqlDbType.VarChar, ItemAvailabilityTypeDescription, 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorType", SqlDbType.Bit , ArmorType.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentType", SqlDbType.Bit, EquipmentType.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponType", SqlDbType.Bit, WeaponType.ToString(), 0));

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
        /// Delete the ItemAvailabilityType.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteItemAvailabilityType()
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
                command.CommandText = "Delete_ItemAvailabilityType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ItemAvailabilityTypeID", SqlDbType.Int, ItemAvailabilityTypeID.ToString(), 0));
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
        static public ItemAvailabilityType Clone(ItemAvailabilityType objItemAvailabilityType)
        {
            ItemAvailabilityType objCItemAvailabilityType = new ItemAvailabilityType();

            if (objItemAvailabilityType.ItemAvailabilityTypeID != 0) objCItemAvailabilityType.GetItemAvailabilityType(objItemAvailabilityType.ItemAvailabilityTypeID);
            else
            {
                objCItemAvailabilityType.ItemAvailabilityTypeID = 0;
                objCItemAvailabilityType.ItemAvailabilityTypeName = objItemAvailabilityType.ItemAvailabilityTypeName;
                objCItemAvailabilityType.ItemAvailabilityTypeDescription = objItemAvailabilityType.ItemAvailabilityTypeDescription;
                objCItemAvailabilityType.ArmorType = objItemAvailabilityType.ArmorType;
                objCItemAvailabilityType.EquipmentType = objItemAvailabilityType.EquipmentType;
                objCItemAvailabilityType.WeaponType = objItemAvailabilityType.WeaponType;

            }
            return objCItemAvailabilityType;
        }

        /// <summary>
        /// Clones the specified List of ItemAvailabilityType objects.
        /// </summary>
        /// <param name="lstItemAvailabilityType">The list of ItemAvailabilityType.</param>
        /// <returns>List of ItemAvailabilityType objects</returns>
        static public List<ItemAvailabilityType> Clone(List<ItemAvailabilityType> lstItemAvailabilityType)
        {
            List<ItemAvailabilityType> lstCItemAvailabilityType = new List<ItemAvailabilityType>();

            foreach (ItemAvailabilityType objItemAvailabilityType in lstItemAvailabilityType)
            {
                lstCItemAvailabilityType.Add(ItemAvailabilityType.Clone(objItemAvailabilityType));
            }

            return lstCItemAvailabilityType;
        }
        #endregion

        #region Private Methods
        private ItemAvailabilityType GetSingleItemAvailabilityType(string sprocName, string strWhere, string strOrderBy)
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

        private List<ItemAvailabilityType> GetItemAvailabilityTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ItemAvailabilityType> ItemAvailabilityTypes = new List<ItemAvailabilityType>();

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
                    ItemAvailabilityType objItemAvailabilityType = new ItemAvailabilityType();
                    SetReaderToObject(ref objItemAvailabilityType, ref result);
                    ItemAvailabilityTypes.Add(objItemAvailabilityType);
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
            return ItemAvailabilityTypes;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ItemAvailabilityTypeID = (int)result.GetValue(result.GetOrdinal("ItemAvailabilityTypeID"));
                this.ItemAvailabilityTypeName = result.GetValue(result.GetOrdinal("ItemAvailabilityTypeName")).ToString();
                this.ItemAvailabilityTypeDescription = result.GetValue(result.GetOrdinal("ItemAvailabilityTypeDescription")).ToString();
                this.ArmorType = (bool)result.GetValue(result.GetOrdinal("ArmorType"));
                this.EquipmentType = (bool)result.GetValue(result.GetOrdinal("EquipmentType"));
                this.WeaponType = (bool)result.GetValue(result.GetOrdinal("WeaponType"));
            }
        }

        private void SetReaderToObject(ref ItemAvailabilityType objItemAvailabilityType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objItemAvailabilityType.ItemAvailabilityTypeID = (int)result.GetValue(result.GetOrdinal("ItemAvailabilityTypeID"));
                objItemAvailabilityType.ItemAvailabilityTypeName = result.GetValue(result.GetOrdinal("ItemAvailabilityTypeName")).ToString();
                objItemAvailabilityType.ItemAvailabilityTypeDescription = result.GetValue(result.GetOrdinal("ItemAvailabilityTypeDescription")).ToString();
                objItemAvailabilityType.ArmorType = (bool)result.GetValue(result.GetOrdinal("ArmorType"));
                objItemAvailabilityType.EquipmentType = (bool)result.GetValue(result.GetOrdinal("EquipmentType"));
                objItemAvailabilityType.WeaponType = (bool)result.GetValue(result.GetOrdinal("WeaponType"));
            }
        }

        #endregion
        #endregion
        #endregion
    }
}
