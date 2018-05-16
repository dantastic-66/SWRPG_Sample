using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class Equipment : BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the equipment identifier.
        /// </summary>
        /// <value>
        /// The equipment identifier.
        /// </value>
        public int EquipmentID { get; set; }
        /// <summary>
        /// Gets or sets the name of the equipment.
        /// </summary>
        /// <value>
        /// The name of the equipment.
        /// </value>
        public string EquipmentName { get; set; }
        /// <summary>
        /// Gets or sets the equipment description.
        /// </summary>
        /// <value>
        /// The equipment description.
        /// </value>
        public string EquipmentDescription { get; set; }

        public int EquipmentTypeID { get; set; }

        /// <summary>
        /// Gets or sets the equipment weight.
        /// </summary>
        /// <value>
        /// The equipment weight.
        /// </value>
        public decimal EquipmentWeight { get; set; }

        public int EmplacementPoints { get; set; }

        public int EquipmentCost { get; set; }

        public int BookID { get; set; }

        public bool Upgradable { get; set; }

        public Book objBook { get; set; }

        public EquipmentType objEquipmentType { get; set; }

        public List<ItemAvailabilityType> lstEquipmentAvailability { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        public Equipment()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="EquipmentName">Name of the Equipment.</param>
        public Equipment(string EquipmentName)
        {
            SetBaseConstructorOptions();
            GetEquipment(EquipmentName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="EquipmentID">The Equipment identifier.</param>
        public Equipment(int EquipmentID)
        {
            SetBaseConstructorOptions();
            GetEquipment(EquipmentID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the equipment.
        /// </summary>
        /// <param name="EquipmentID">The equipment identifier.</param>
        /// <returns>Equipment Object</returns>
        public Equipment GetEquipment(int EquipmentID)
        {
             return GetSingleEquipment("Select_Equipment", "  EquipmentID=" + EquipmentID.ToString(), "");
        }

        /// <summary>
        /// Gets the equipment.
        /// </summary>
        /// <param name="EquipmentName">Name of the equipment.</param>
        /// <returns>Equipment Object</returns>
        public Equipment GetEquipment(string EquipmentName)
        {
             return GetSingleEquipment("Select_Equipment", "  EquipmentName='" + EquipmentName + "'", "");
        }

        /// <summary>
        /// Gets the equipment.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Equipment Objects</returns>
        public List<Equipment> GetEquipment(string strWhere, string strOrderBy)
        {
            return GetEquipmentList("Select_Equipment", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the character equipment.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>List of Equipment Objects</returns>
        public List<Equipment> GetCharacterEquipment(int CharacterID)
        {
            return GetEquipmentList("Select_CharacterEquipment", "CharacterID=" + CharacterID.ToString(), "EquipmentName");
        }

        public List<Equipment> GetEquipmentByEquipmentTypeID (int EquipmentTypeID)
        {
            return GetEquipmentList("Select_Equipment", "EquipmentTypeID=" + EquipmentTypeID.ToString(), "EquipmentName");
        }

        /// <summary>
        /// Saves the equipment.
        /// </summary>
        /// <returns>Equipment Object</returns>
        public Equipment SaveEquipment()
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
                command.CommandText = "InsertUpdate_Equipment";
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentID", SqlDbType.Int, EquipmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentName", SqlDbType.VarChar, EquipmentName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentDescription", SqlDbType.VarChar, EquipmentDescription.ToString(), 400));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentTypeID", SqlDbType.Int, EquipmentTypeID.ToString(), 0));
             
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentWeight", SqlDbType.Decimal , EquipmentWeight.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentCost", SqlDbType.Int, EquipmentCost.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookID", SqlDbType.Int, BookID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Upgradable", SqlDbType.Bit , Upgradable.ToString(), 0));
                    
                result = command.ExecuteReader();

                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK = false;
                this._insertUpdateMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
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
        /// Deletes the equipment.
        /// </summary>
        /// <returns>bool</returns>
        public bool DeleteEquipment()
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
                command.CommandText = "Delete_Equipment";
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentID", SqlDbType.Int, EquipmentID.ToString(), 0));
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
        /// Saves the Character equipment.
        /// </summary>
        /// <returns>Equipment Object</returns>
        public Equipment SaveCharacterEquipment(int CharacterID, int EquipmentID)
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
                command.CommandText = "InsertUpdate_CharacterEquipment";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentID", SqlDbType.Int, EquipmentID.ToString(), 0));
                result = command.ExecuteReader();
                result.Read();
                SetReaderToObject(ref result);

            }
            catch
            {
                Exception e = new Exception();
                this._insertUpdateOK = false;
                this._insertUpdateMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
                throw e;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this;
        }

        public void SaveCharacterEquipment(List<Equipment> lstCharEquipment, int intCharacterID)
        {
            //The equipment list can change in its entirety, so the whole then needs to be dropped and readded.
            Equipment objDelCharEquipment  = new Equipment();
            objDelCharEquipment.DeleteCharacterEquipment(intCharacterID, 0);

            foreach (Equipment objCharEquipment in lstCharEquipment)
            {
                objCharEquipment.SaveCharacterEquipment(intCharacterID, objCharEquipment.EquipmentID);
            }
        }

        /// <summary>
        /// Deletes the character equipment.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="EquipmentID">The equipment identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterEquipment(int CharacterID, int EquipmentID)
        {
            string strWhere = "";

            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);
            strWhere = "CharacterID=" + CharacterID.ToString() + " AND EquipmentID=" + EquipmentID.ToString();
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_CharacterEquipment";
                command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 2000));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);

            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
            return this.DeleteOK;
        }
        
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.EquipmentName))
            {
                this._validated = false;
                this._validationMessage.Append("The Equipment Name cannot be blank or null.");
            }
            return this.Validated;
        }

        #region Static Methods
        /// <summary>
        /// Determines whether [is Equipment in list] [the specified object Equipment].
        /// </summary>
        /// <param name="objEquipment">The object Equipment.</param>
        /// <param name="lstEquipment">The LST Equipment.</param>
        /// <returns></returns>
        static public bool IsEquipmentInList(Equipment objEquipment, List<Equipment> lstEquipment)
        {
            bool blnEquipmentFound = false;

            foreach (Equipment lstObjEquipment in lstEquipment)
            {
                if (objEquipment.EquipmentID == lstObjEquipment.EquipmentID)
                {
                    blnEquipmentFound = true;
                }
            }

            return blnEquipmentFound;
        }

        /// <summary>
        /// Determines whether [is Equipment in list] [the specified LST need Equipments].
        /// </summary>
        /// <param name="lstNeedEquipment">The LST need Equipments.</param>
        /// <param name="lstEquipment">The LST Equipments.</param>
        /// <returns></returns>
        static public bool IsEquipmentInList(List<Equipment> lstNeedEquipment, List<Equipment> lstEquipment)
        {
            bool blnAllEquipmentsFound = true;
            bool blnEquipmentFound = false;

            foreach (Equipment objNeededEquipment in lstNeedEquipment)
            {
                blnEquipmentFound = false;

                foreach (Equipment objEquipment in lstEquipment)
                {
                    if (objNeededEquipment.EquipmentID == objEquipment.EquipmentID)
                    {
                        blnEquipmentFound = true;
                    }
                }

                if (blnAllEquipmentsFound)
                {
                    if (!blnEquipmentFound) blnAllEquipmentsFound = blnEquipmentFound;
                }
            }


            return blnAllEquipmentsFound;
        }

        /// <summary>
        /// Clones the specified object Equipment.
        /// </summary>
        /// <param name="objEquipment">The object Equipment.</param>
        /// <returns>Equipment</returns>
        static public Equipment Clone(Equipment objEquipment)
        {
            Equipment objCEquipment = new Equipment(objEquipment.EquipmentID);
            return objCEquipment;
        }

        /// <summary>
        /// Clones the specified LST Equipment.
        /// </summary>
        /// <param name="lstEquipment">The LST Equipment.</param>
        /// <returns>List<Equipment></returns>
        static public List<Equipment> Clone(List<Equipment> lstEquipment)
        {
            List<Equipment> lstCEquipment = new List<Equipment>();

            foreach (Equipment objEquipment in lstEquipment)
            {
                lstCEquipment.Add(Equipment.Clone(objEquipment));
            }

            return lstCEquipment;
        }

        /// <summary>
        /// Deletes the character equipment.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>Boolean</returns>
        //static public bool DeleteCharacterEquipment(int CharacterID)
        //{
        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Delete_CharacterEquipment";
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, "CharacterID=" + CharacterID.ToString(), 2000));
        //        result = command.ExecuteReader();

        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        this._deleteOK = false;
        //        this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);

        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return this.DeleteOK;
        //}

        //static public void SaveCharacterEquipment(List<Equipment> lstEquipment, int intCharID)
        //{
        //    DeleteCharacterEquipment(intCharID);

        //    foreach (Equipment objCharEquipment in lstEquipment)
        //    {
        //        objCharEquipment.SaveCharacterEquipment(intCharID, objCharEquipment.EquipmentID);
        //    }
        //}

        #endregion
        /// <summary>
        /// Saves the character equipment.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <param name="EquipmentID">The equipment identifier.</param>
        /// <returns></returns>
        //public Equipment SaveCharacterEquipment(int CharacterID, int EquipmentID)
        //{
        //    SqlDataReader result;
        //    DatabaseConnection dbconn = new DatabaseConnection();
        //    SqlCommand command = new SqlCommand();
        //    SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

        //    try
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "InsertUpdate_CharacterEquipment";

        //        command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
        //        command.Parameters.Add(dbconn.GenerateParameterObj("@LanguageID", SqlDbType.Int, EquipmentID.ToString(), 0));
        //        result = command.ExecuteReader();

        //    }
        //    catch
        //    {
        //        Exception e = new Exception();
        //        this._validated = false;
        //        this._validationMessage.Append(e.Message.ToString());
        //        throw e;
        //    }
        //    finally
        //    {
        //        command.Dispose();
        //        connection.Close();
        //    }
        //    return GetEquipment (EquipmentID);

        //}
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single equipment.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Equipment Object</returns>
        private Equipment GetSingleEquipment(string sprocName, string strWhere, string strOrderBy)
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

        /// <summary>
        /// Gets the equipment list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Equipment Objects</returns>
        private List<Equipment> GetEquipmentList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Equipment> equipment = new List<Equipment>();

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
                    Equipment objEquipment = new Equipment();
                    SetReaderToObject(ref objEquipment, ref result);
                    equipment.Add(objEquipment);
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
            return equipment;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.EquipmentID = (int)result.GetValue(result.GetOrdinal("EquipmentID"));
                this.EquipmentName = result.GetValue(result.GetOrdinal("EquipmentName")).ToString();
                this.EquipmentDescription = result.GetValue(result.GetOrdinal("EquipmentDescription")).ToString();
                this.EquipmentWeight = (decimal) result.GetValue(result.GetOrdinal("EquipmentWeight"));
                this.EmplacementPoints = (int)result.GetValue(result.GetOrdinal("EmplacementPoints"));
                this.EquipmentCost = (int)result.GetValue(result.GetOrdinal("EquipmentCost"));
                this.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                this.Upgradable = (bool)result.GetValue(result.GetOrdinal("Upgradable"));

                this._objComboBoxData.Add(this.EquipmentID, this.EquipmentName);

                this.objBook = new Book(this.BookID);

                this.objEquipmentType = new EquipmentType(this.EquipmentTypeID);

                ItemAvailabilityType objIAT = new ItemAvailabilityType();
                this.lstEquipmentAvailability = objIAT.GetEquipmentAvailabilityTypes(this.EquipmentID);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objEquipment">The object equipment.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Equipment objEquipment, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objEquipment.EquipmentID = (int)result.GetValue(result.GetOrdinal("EquipmentId"));
                objEquipment.EquipmentName = result.GetValue(result.GetOrdinal("EquipmentName")).ToString();
                objEquipment.EquipmentDescription = result.GetValue(result.GetOrdinal("EquipmentDescription")).ToString();
                objEquipment.EquipmentWeight = (decimal)result.GetValue(result.GetOrdinal("EquipmentWeight"));
                objEquipment.EmplacementPoints = (int)result.GetValue(result.GetOrdinal("EmplacementPoints"));
                objEquipment.EquipmentCost = (int)result.GetValue(result.GetOrdinal("EquipmentCost"));
                objEquipment.Upgradable = (bool)result.GetValue(result.GetOrdinal("Upgradable"));
                objEquipment.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));

                objEquipment._objComboBoxData.Add(objEquipment.EquipmentID, objEquipment.EquipmentName);

                objEquipment.objBook = new Book(objEquipment.BookID);

                objEquipment.objEquipmentType = new EquipmentType(objEquipment.EquipmentTypeID);

                ItemAvailabilityType objIAT = new ItemAvailabilityType();
                objEquipment.lstEquipmentAvailability = objIAT.GetEquipmentAvailabilityTypes(objEquipment.EquipmentID);
            }
        }
        #endregion
        #endregion
    
    }
}
