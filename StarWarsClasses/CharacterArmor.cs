using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class CharacterArmor : BaseValidation
    {

        #region Properties
        public int CharacterArmorID { get; set; }
        public int CharacterID { get; set; }
        public int ArmorID { get; set; }
        public bool Worn { get; set; }
        public string Notes { get; set; }

        public Armor objArmor { get; set; }
        public List<Modification> lstModifications { get; set; }

        #endregion

        #region Constructors
        public CharacterArmor()
        {
            SetBaseConstructorOptions();
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="CharacterArmor"/> class.
        ///// </summary>
        ///// <param name="CharacterArmorName">Name of the CharacterArmor.</param>
        //public CharacterArmor(int CharacterID, int ArmorID)
        //{
        //    SetBaseConstructorOptions();
        //    GetCharacterArmor(CharacterID, ArmorID);
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterArmor"/> class.
        /// </summary>
        /// <param name="CharacterArmorID">The CharacterArmor identifier.</param>
        public CharacterArmor(int CharacterArmorID)
        {
            SetBaseConstructorOptions();
            GetCharacterArmor(CharacterArmorID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterArmor"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        /// <param name="ArmorID">The Armor identifier.</param>
        public CharacterArmor(int CharacterID, int ArmorID)
        {
            SetBaseConstructorOptions();
            GetCharacterArmor(CharacterID, ArmorID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public CharacterArmor GetCharacterArmor(int CharacterArmorID)
        {
            return GetSingleCharacterArmor("Select_CharacterArmor", " CharacterArmorID = " + CharacterArmorID.ToString(), "");
        }
        
        public CharacterArmor GetCharacterArmor(string CharacterArmorName)
        {
            return GetSingleCharacterArmor("Select_CharacterArmor", " CharacterArmorName='" + CharacterArmorID.ToString() + "'", "");
        }

        public List<CharacterArmor> GetCharacterArmor(int CharacterID, int ArmorID)
        {
            return GetCharacterArmorList("Select_CharacterArmor", " CharacterID=" + CharacterID.ToString() + " AND ArmorID=" + ArmorID.ToString(), "");
        }

        public List<CharacterArmor> GetCharacterArmors(int CharacterID)
        {
            return GetCharacterArmorList("Select_CharacterArmor", " CharacterID=" + CharacterID.ToString(), "");
        }

        public CharacterArmor SaveCharacterArmor()
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
                command.CommandText = "InsertUpdate_CharacterArmor";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterArmorID", SqlDbType.Int, CharacterArmorID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorID", SqlDbType.Int, ArmorID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Worn", SqlDbType.Bit , Worn.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Notes", SqlDbType.VarChar , Notes, 100));

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
        /// Delete the CharacterArmor.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteCharacterArmor()
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
                command.CommandText = "Delete_CharacterArmor";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterArmorID", SqlDbType.Int, CharacterArmorID.ToString(), 0));
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

        public bool DeleteCharacterArmorModification(int CharacterArmorID, int ModificationID)
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
                command.CommandText = "Delete_CharacterArmorModification";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterArmorID", SqlDbType.Int, CharacterArmorID.ToString(), 0));
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

        public CharacterArmor CreateCharacterArmor(Character objChar, Armor objArmor)
        {
            this.CharacterArmorID = 0;
            this.CharacterID = objChar.CharacterID;
            this.ArmorID = objArmor.ArmorID;
            this.Worn = false;
            this.Notes = "";
            this.objArmor = objArmor;
            this.lstModifications = new List<Modification>();
            return this;
        }


        #region Static Methods
        /// <summary>
        /// Clones the specified object CharacterArmor.
        /// </summary>
        /// <param name="objCharacterArmor">The object CharacterArmor.</param>
        /// <returns>CharacterArmor</returns>
        static public CharacterArmor Clone(CharacterArmor objCharacterArmor, bool blnFromDatabase = false)
        {
            //Get the data from the database(?) then match it with what is passed in, we want to clone what is passed in for Character Items, not List Items
            CharacterArmor objCCharacterArmor = new CharacterArmor();
            if (blnFromDatabase) objCCharacterArmor.GetCharacterArmor(objCharacterArmor.CharacterID, objCharacterArmor.ArmorID);
            else 
            {
                objCCharacterArmor.CharacterArmorID = objCharacterArmor.CharacterArmorID;
                objCCharacterArmor.CharacterID = objCharacterArmor.CharacterID;
                objCCharacterArmor.ArmorID = objCharacterArmor.ArmorID;
                objCCharacterArmor.Worn = objCharacterArmor.Worn;
                objCCharacterArmor.Notes = objCharacterArmor.Notes;
                objCCharacterArmor.objArmor = Armor.Clone(objCharacterArmor.objArmor);
                objCCharacterArmor.lstModifications = Modification.Clone(objCharacterArmor.lstModifications);
            }
 
            return objCCharacterArmor;
        }

        /// <summary>
        /// Clones the specified LST CharacterArmor.
        /// </summary>
        /// <param name="lstCharacterArmor">The LST CharacterArmor.</param>
        /// <returns>List<CharacterArmor></returns>
        static public List<CharacterArmor> Clone(List<CharacterArmor> lstCharacterArmor)
        {
            List<CharacterArmor> lstCCharacterArmor = new List<CharacterArmor>();

            foreach (CharacterArmor objCharacterArmor in lstCharacterArmor)
            {
                lstCCharacterArmor.Add(CharacterArmor.Clone(objCharacterArmor));
            }

            return lstCCharacterArmor;
        }

        static public List<CharacterArmor> RemoveCharacterArmorFromList(CharacterArmor objCharacterArmor, List<CharacterArmor> lstCharArmors)
        {
            List<CharacterArmor> retList = new List<CharacterArmor>();

            foreach (CharacterArmor objCharAromr in lstCharArmors)
            {
                if (objCharacterArmor.CharacterArmorID != objCharAromr.CharacterArmorID) retList.Add(objCharAromr);
            }

            return retList;
        }

        static public List<CharacterArmor> RemoveCharacterArmorFromList(int CharacterArmorID, List<CharacterArmor> lstCharArmors)
        {
            List<CharacterArmor> retList = new List<CharacterArmor>();

            foreach (CharacterArmor objCharArmor in lstCharArmors)
            {
                if (CharacterArmorID != objCharArmor.CharacterArmorID) retList.Add(objCharArmor);
            }

            return retList;
        }

        #endregion
        #endregion

        #region Private Methods
        private CharacterArmor GetSingleCharacterArmor(string sprocName, string strWhere, string strOrderBy)
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

        private List<CharacterArmor> GetCharacterArmorList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<CharacterArmor> CharacterArmors = new List<CharacterArmor>();

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
                    CharacterArmor objCharacterArmor = new CharacterArmor();
                    SetReaderToObject(ref objCharacterArmor, ref result);
                    CharacterArmors.Add(objCharacterArmor);
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
            return CharacterArmors;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                this.CharacterArmorID = (int)result.GetValue(result.GetOrdinal("CharacterArmorID"));
                this.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                this.ArmorID = (int)result.GetValue(result.GetOrdinal("ArmorID"));
                this.Worn = (bool)result.GetValue(result.GetOrdinal("Worn"));
                this.Notes = result.GetValue(result.GetOrdinal("Notes")).ToString();

                this.objArmor = new Armor(this.ArmorID);

                Modification objModification = new Modification();
                this.lstModifications = objModification.GetCharacterArmorModifications (this.CharacterID);
            }
        }

        private void SetReaderToObject(ref CharacterArmor objCharacterArmor, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objCharacterArmor.CharacterArmorID = (int)result.GetValue(result.GetOrdinal("CharacterArmorID"));
                objCharacterArmor.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                objCharacterArmor.ArmorID = (int)result.GetValue(result.GetOrdinal("ArmorID"));
                objCharacterArmor.Worn = (bool)result.GetValue(result.GetOrdinal("Worn"));
                objCharacterArmor.Notes = result.GetValue(result.GetOrdinal("Notes")).ToString();

                objCharacterArmor.objArmor = new Armor(objCharacterArmor.ArmorID);

                Modification objModification = new Modification();
                objCharacterArmor.lstModifications = objModification.GetCharacterArmorModifications(objCharacterArmor.CharacterArmorID);
            }
        }

        #endregion
        #endregion
    }
}
