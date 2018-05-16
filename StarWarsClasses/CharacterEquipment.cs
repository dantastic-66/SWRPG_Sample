using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class CharacterEquipment : BaseValidation
    {


        public int CharacterEquipmentID { get; set; }
        public int CharacterID { get; set; }
        public int EquipmentID { get; set; }
        public string Notes { get; set; }
        public int Quantity { get; set; }

        public Equipment objEquipment { get; set; }
        public List<Modification> lstModifications { get; set; }

        #region Constructors
        public CharacterEquipment()
        {
            SetBaseConstructorOptions();
        }
                
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterArmor"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="EquipmentID">The Equipment identifier.</param>
        public CharacterEquipment(int CharacterID, int EquipmentID)
        {
            SetBaseConstructorOptions();
            GetCharacterEquipment(CharacterID, EquipmentID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterEquipment"/> class.
        /// </summary>
        /// <param name="CharacterEquipmentID">The CharacterEquipment identifier.</param>
        public CharacterEquipment(int CharacterEquipmentID)
        {
            SetBaseConstructorOptions();
            GetCharacterEquipment(CharacterEquipmentID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public CharacterEquipment GetCharacterEquipment(int CharacterEquipmentID)
        {
            return GetSingleCharacterEquipment("Select_CharacterEquipment", " CharacterEquipmentID = " + CharacterEquipmentID.ToString(), "");
        }

        public CharacterEquipment GetCharacterEquipment(int CharacterID, int EquipmentID)
        {
            return GetSingleCharacterEquipment("Select_CharacterEquipment", " CharacterID=" + CharacterID.ToString() + " AND EquipmentID=" + EquipmentID.ToString(), "");
        }

        public List<CharacterEquipment> GetCharacterEquipmentList(string strWhere, string strOrderBy)
        {
            return GetCharacterEquipmentList("Select_CharacterEquipment", strWhere, strOrderBy);
        }

        public List<CharacterEquipment> GetCharacterEquipmentListByType(int CharacterID, int EquipmentTypeID)
        {
            return GetCharacterEquipmentList("Select_CharacterEquipmentByEquipmentType", "CharacterID=" + CharacterID + " AND lstEquipmentType.EquipmentTypeID=" + EquipmentTypeID.ToString(), "lstEquipment.EquipmentName");
        }

        public CharacterEquipment SaveCharacterEquipment()
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
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterEquipmentID", SqlDbType.Int, CharacterEquipmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EquipmentID", SqlDbType.Int, EquipmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Notes", SqlDbType.VarChar, Notes, 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Quantity", SqlDbType.Int, Quantity.ToString(), 0));
                
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

        public CharacterEquipment CreateCharacterEquipment(Character objChar, Equipment objEquipment, int Quantity)
        {
            this.CharacterEquipmentID = 0;
            this.CharacterID = objChar.CharacterID;
            this.EquipmentID = objEquipment.EquipmentID;
            this.Notes = "";
            this.Quantity = Quantity;
            this.objEquipment = objEquipment;
            lstModifications = new List<Modification>();

            return this;
        }

        public bool DeleteCharacterEquipmentModification(int CharacterEquipmentID, int ModificationID)
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
                command.CommandText = "Delete_ChracterEquipmentModification";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterEquipmentID", SqlDbType.Int, CharacterEquipmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationID", SqlDbType.Int, ModificationID.ToString(), 0));
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
        /// Delete the CharacterEquipment.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterEquipment()
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
                command.CommandText = "Delete_CharacterEquipment";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterEquipmentID", SqlDbType.Int, CharacterEquipmentID.ToString(), 0));
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
        /// Determines whether [is Equipment in list] [the specified object Equipment].
        /// </summary>
        /// <param name="objEquipment">The object Equipment.</param>
        /// <param name="lstCharEquipment">The LST Equipment.</param>
        /// <returns></returns>
        static public bool IsEquipmentInCharacterEquipmentList(Equipment objEquipment, List<CharacterEquipment> lstCharEquipment)
        {
            bool blnEquipmentFound = false;

            foreach (CharacterEquipment lstObjCharEquipment in lstCharEquipment)
            {
                if (objEquipment.EquipmentID == lstObjCharEquipment.objEquipment.EquipmentID)
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
        /// <param name="lstCharEquipment">The LST Equipments.</param>
        /// <returns></returns>
        static public bool IsEquipmentInCharacterEquipmentList(List<Equipment> lstNeedEquipment, List<CharacterEquipment> lstCharEquipment)
        {
            bool blnAllEquipmentsFound = true;
            bool blnEquipmentFound = false;

            foreach (Equipment objNeededEquipment in lstNeedEquipment)
            {
                blnEquipmentFound = false;

                foreach (CharacterEquipment objCharEquipment in lstCharEquipment)
                {

                    if (objNeededEquipment.EquipmentID == objCharEquipment.objEquipment.EquipmentID)
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
        /// Clones the specified object CharacterEquipmen.
        /// </summary>
        /// <param name="objCharacterEquipment">The object CharacterEquipmen.</param>
        /// <returns>CharacterEquipmen</returns>
        static public CharacterEquipment Clone(CharacterEquipment objCharacterEquipment)
        {
            CharacterEquipment objCEquip = new CharacterEquipment();
            objCEquip.CharacterEquipmentID = objCharacterEquipment.CharacterEquipmentID;
            objCEquip.CharacterID = objCharacterEquipment.CharacterID;
            objCEquip.EquipmentID = objCharacterEquipment.EquipmentID;
            objCEquip.Notes = objCharacterEquipment.Notes;

            return objCEquip;
        }

        /// <summary>
        /// Clones the specified LST CharacterEquipment.
        /// </summary>
        /// <param name="lstCharacterEquipment">The LST CharacterEquipment.</param>
        /// <returns>List<CharacterEquipment></returns>
        static public List<CharacterEquipment> Clone(List<CharacterEquipment> lstCharacterEquipment)
        {
            List<CharacterEquipment> lstCEquip = new List<CharacterEquipment>();

            foreach (CharacterEquipment objCharEquip in lstCharacterEquipment)
            {
                lstCEquip.Add(CharacterEquipment.Clone(objCharEquip));
            }

            return lstCEquip;
        }

        #endregion
        #endregion

        #region Private Methods
        private CharacterEquipment GetSingleCharacterEquipment(string sprocName, string strWhere, string strOrderBy)
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

        private List<CharacterEquipment> GetCharacterEquipmentList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterEquipment> CharacterEquipments = new List<CharacterEquipment>();

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
                    CharacterEquipment objCharacterEquipment = new CharacterEquipment();
                    SetReaderToObject(ref objCharacterEquipment, ref result);
                    CharacterEquipments.Add(objCharacterEquipment);
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
            return CharacterEquipments;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.CharacterEquipmentID = (int)result.GetValue(result.GetOrdinal("CharacterEquipmentID"));
                this.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                this.EquipmentID = (int)result.GetValue(result.GetOrdinal("EquipmentID"));
                this.Notes = result.GetValue(result.GetOrdinal("Notes")).ToString();
                this.Quantity = (int)result.GetValue(result.GetOrdinal("Quantity"));

                this.objEquipment = new Equipment(this.EquipmentID);

                Modification objModification = new Modification();
                this.lstModifications = objModification.GetCharacterEquipmentModifications(this.CharacterEquipmentID);
            }
        }

        private void SetReaderToObject(ref CharacterEquipment objCharacterEquipment, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objCharacterEquipment.CharacterEquipmentID = (int)result.GetValue(result.GetOrdinal("CharacterEquipmentID"));
                objCharacterEquipment.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                objCharacterEquipment.EquipmentID = (int)result.GetValue(result.GetOrdinal("EquipmentID"));
                objCharacterEquipment.Notes = result.GetValue(result.GetOrdinal("Notes")).ToString();
                objCharacterEquipment.Quantity = (int)result.GetValue(result.GetOrdinal("Quantity"));

                objCharacterEquipment.objEquipment = new Equipment(objCharacterEquipment.EquipmentID);

                Modification objModification = new Modification();
                objCharacterEquipment.lstModifications = objModification.GetCharacterEquipmentModifications(objCharacterEquipment.CharacterEquipmentID);
            }
        }

        #endregion
        #endregion
    }
}
