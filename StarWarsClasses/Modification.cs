using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class Modification : BaseValidation
    {


        public int ModificationID { get; set; }
        public string ModificationName { get; set; }
        public string ModificationDescription { get; set; }
        //public int ModificationTypeID { get; set; }
        public int ModificationCost { get; set; }
        public int UpgradePoints { get; set; }

        
        public List<ModificationType> lstModificationType { get; set; }

        #region Constructors
        public Modification()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Modification"/> class.
        /// </summary>
        /// <param name="ModificationName">Name of the Modification.</param>
        public Modification(string ModificationName)
        {
            SetBaseConstructorOptions();
            GetModification(ModificationName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Modification"/> class.
        /// </summary>
        /// <param name="ModificationID">The Modification identifier.</param>
        public Modification(int ModificationID)
        {
            SetBaseConstructorOptions();
            GetModification(ModificationID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public Modification GetModification(int ModificationID)
        {
            return GetSingleModification("Select_Modification", " ModificationID = " + ModificationID.ToString(), "");
        }

        public Modification GetModification(string ModificationName)
        {
            return GetSingleModification("Select_Modification", " ModificationName='" + ModificationID.ToString() + "'", "");
        }

        public List<Modification> GetModifications(string strWhere, string strOrderBy)
        {
            return GetModificationList("Select_Modification", strWhere, strOrderBy);
        }

        public List<Modification> GetModificationsByType(string strWhere, string strOrderBy)
        {
            return GetModificationList("Select_ModificationByModificationType", strWhere, strOrderBy);
        }

        public List<Modification> GetCharacterArmorModifications(int CharacterArmorID )
        {
            return GetModificationList("Select_ModificationCharacterArmorModification", " CharacterArmorID=" + CharacterArmorID.ToString() , "ModificationName");
        }

        public List<Modification> GetCharacterWeaponModifications(int CharacterWeaponID)
        {
            return GetModificationList("Select_ModificationCharacterWeaponModification", " CharacterWeaponID=" + CharacterWeaponID.ToString(), "ModificationName");
        }

        public List<Modification> GetCharacterEquipmentModifications(int CharacterEquipmentID)
        {
            return GetModificationList("Select_ModificationCharacterEquipmentModification", " CharacterEquipmentID=" + CharacterEquipmentID.ToString(), "ModificationName");
        }

        public void SaveCharacterEquipmentModification(int CharacterEquipmentID, int ModificationID)
        {
            this._insertUpdateOK = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertUpdate_CharacterEquipmentModification";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterEquipmentID", SqlDbType.Int, CharacterEquipmentID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationID", SqlDbType.Int, ModificationID.ToString(), 0));
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
        }

        public void SaveCharacterArmorModification(int CharacterArmorID, int ModificationID)
        {
            this._insertUpdateOK = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertUpdate_CharacterArmorModification";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterArmorID", SqlDbType.Int, CharacterArmorID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationID", SqlDbType.Int, ModificationID.ToString(), 0));
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
        }

        public void SaveCharacterWeaponModification(int CharacterWeaponID, int ModificationID)
        {
            this._insertUpdateOK = true;
            SqlDataReader result;
            DatabaseConnection dbconn = new DatabaseConnection();
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertUpdate_CharacterWeaponModification";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterWeaponID", SqlDbType.Int, CharacterWeaponID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationID", SqlDbType.Int, ModificationID.ToString(), 0));
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
        }

        public Modification SaveModification()
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
                command.CommandText = "InsertUpdate_Modification";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationID", SqlDbType.Int, ModificationID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationName", SqlDbType.VarChar, ModificationName, 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationDescription", SqlDbType.VarChar , ModificationDescription, 4000));
                //command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationTypeID", SqlDbType.Int, ModificationTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationCost", SqlDbType.Int, ModificationCost.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@UpgradePoints", SqlDbType.Int, UpgradePoints.ToString(), 0));
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
        /// Delete the Modification.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteModification()
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
                command.CommandText = "Delete_Modification";
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

        #region Static Methods
        /// <summary>
        /// Clones the specified object Modification.
        /// </summary>
        /// <param name="objModification">The object Modification.</param>
        /// <returns>Modification</returns>
        static public Modification Clone(Modification objModification)
        {
            Modification objCModification = new Modification(objModification.ModificationID);

            objCModification.ModificationID = objModification.ModificationID;
            objCModification.ModificationName = objModification.ModificationName;
            objCModification.ModificationDescription = objModification.ModificationDescription;
            //objCModification.ModificationTypeID = objModification.ModificationTypeID;
            objCModification.ModificationCost = objModification.ModificationCost;
            objCModification.UpgradePoints = objModification.UpgradePoints;

            objCModification.lstModificationType = ModificationType.Clone(objModification.lstModificationType);

            return objCModification;
        }

        /// <summary>
        /// Clones the specified LST Modification.
        /// </summary>
        /// <param name="lstModification">The LST Modification.</param>
        /// <returns>List<Modification></returns>
        static public List<Modification> Clone(List<Modification> lstModification)
        {
            List<Modification> lstCModification = new List<Modification>();

            foreach (Modification objModification in lstModification)
            {
                lstCModification.Add(Modification.Clone(objModification));
            }

            return lstCModification;
        }

        /// <summary>
        /// Determines whether [is Modification in list] [the specified object Modification].
        /// </summary>
        /// <param name="objModification">The object Modification.</param>
        /// <param name="lstModification">The LST Modification.</param>
        /// <returns></returns>
        static public bool IsModificationInList(Modification objModification, List<Modification> lstModification)
        {
            bool blnModificationFound = false;

            foreach (Modification lstObjModification in lstModification)
            {
                if (objModification.ModificationID == lstObjModification.ModificationID)
                {
                    blnModificationFound = true;
                }
            }

            return blnModificationFound;
        }

        /// <summary>
        /// Determines whether [is Modification in list] [the specified LST need Modifications].
        /// </summary>
        /// <param name="lstNeedModifications">The LST need Modifications.</param>
        /// <param name="lstModifications">The LST Modifications.</param>
        /// <returns></returns>
        static public bool IsModificationInList(List<Modification> lstNeedModifications, List<Modification> lstModifications)
        {
            bool blnAllModificationsFound = true;
            bool blnModificationFound = false;

            foreach (Modification objNeededModification in lstNeedModifications)
            {
                blnModificationFound = false;

                foreach (Modification objModification in lstModifications)
                {
                    if (objNeededModification.ModificationID == objModification.ModificationID)
                    {
                        blnModificationFound = true;
                    }
                }

                if (blnAllModificationsFound)
                {
                    if (!blnModificationFound) blnAllModificationsFound = blnModificationFound;
                }
            }


            return blnAllModificationsFound;
        }

        /// <summary>
        /// Removes all occurances of a Modifaction Type from a list of Modifications
        /// </summary>
        /// <param name="lstModifications">The list of Modifications to be sorted through.</param>
        /// <param name="objModification">The Modification to be remove.</param>
        /// <returns></returns>
        static public List<Modification> RemoveListObject(List<Modification> lstModifications, Modification objModification)
        {
            List<Modification> lstMods = new List<Modification>();
            foreach (Modification objMod in lstModifications)
            {
                if (objMod.ModificationID != objModification.ModificationID) lstMods.Add(objMod);
            }
            return lstMods;
        }
        #endregion
        #endregion

        #region Private Methods
        private Modification GetSingleModification(string sprocName, string strWhere, string strOrderBy)
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

        private List<Modification> GetModificationList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Modification> Modifications = new List<Modification>();

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
                    Modification objModification = new Modification();
                    SetReaderToObject(ref objModification, ref result);
                    Modifications.Add(objModification);
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
            return Modifications;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ModificationID = (int)result.GetValue(result.GetOrdinal("ModificationID"));
                this.ModificationName = result.GetValue(result.GetOrdinal("ModificationName")).ToString();
                this.ModificationDescription = result.GetValue(result.GetOrdinal("ModificationDescription")).ToString();
                this.UpgradePoints = (int)result.GetValue(result.GetOrdinal("UpgradePoints"));
                //this.ModificationTypeID = (int)result.GetValue(result.GetOrdinal("ModificationTypeID"));
                this.ModificationCost = (int)result.GetValue(result.GetOrdinal("ModificationCost"));

                ModificationType objModType = new ModificationType();
                this.lstModificationType = objModType.GetModificationTypesByModfication(this.ModificationID);

            }
        }

        private void SetReaderToObject(ref Modification objModification, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objModification.ModificationID = (int)result.GetValue(result.GetOrdinal("ModificationID"));
                objModification.ModificationName = result.GetValue(result.GetOrdinal("ModificationName")).ToString();
                objModification.ModificationDescription = result.GetValue(result.GetOrdinal("ModificationDescription")).ToString();
                objModification.UpgradePoints = (int)result.GetValue(result.GetOrdinal("UpgradePoints"));
                //objModification.ModificationTypeID = (int)result.GetValue(result.GetOrdinal("ModificationTypeID"));
                objModification.ModificationCost = (int)result.GetValue(result.GetOrdinal("ModificationCost")); 
                
                ModificationType objModType = new ModificationType();
                objModification.lstModificationType = objModType.GetModificationTypesByModfication(objModification.ModificationID);

            }
        }

        #endregion
        #endregion
    }
}
