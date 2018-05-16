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
    /// Basic Armor Object that a Character can wear.  Each individual Armor matches to a record in the lstArmor table.
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class Armor : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the armor identifier.
        /// </summary>
        /// <value>
        /// The armor identifier.
        /// </value>
        public int ArmorID { get; set; }
        /// <summary>
        /// Gets or sets the armor type identifier.
        /// </summary>
        /// <value>
        /// The armor type identifier.
        /// </value>
        public int ArmorTypeID { get; set; }
        /// <summary>
        /// Gets or sets the name of the armor.
        /// </summary>
        /// <value>
        /// The name of the armor.
        /// </value>
        public string ArmorName { get; set; }
        /// <summary>
        /// Gets or sets the armor description.
        /// </summary>
        /// <value>
        /// The armor description.
        /// </value>
        public string ArmorDescription { get; set; }
        /// <summary>
        /// Gets or sets the reflex adjustment.
        /// </summary>
        /// <value>
        /// The reflex adjustment.
        /// </value>
        public int ReflexAdjustment { get; set; }
        /// <summary>
        /// Gets or sets the fortitude adjustment.
        /// </summary>
        /// <value>
        /// The fortitude adjustment.
        /// </value>
        public int FortitudeAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the emplacement points.
        /// </summary>
        /// <value>
        /// The emplacement points.
        /// </value>
        public int EmplacementPoints { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the armor proficiency feat identifier.
        /// </summary>
        /// <value>
        /// The armor proficiency feat identifier.
        /// </value>
        public int ArmorProficiencyFeatID { get; set; }

        /// <summary>
        /// Gets or sets the maximum Defense bonus.
        /// </summary>
        /// <value>
        /// The maximum Defense bonus.
        /// </value>
        public int MaxDefBonus { get; set; }

        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public int BookID { get; set; }

        /// <summary>
        /// Gets or sets the type of the object armor (ArmorType).
        /// </summary>
        /// <value>
        /// The type of the object armor.
        /// </value>
        public ArmorType objArmorType { get; set; }

        /// <summary>
        /// Gets or sets the List of armor availability.
        /// </summary>
        /// <value>
        /// The List of ItemAvailabilityType objects.
        /// </value>
        public List<ItemAvailabilityType>  lstArmorAvailability { get; set; }

        /// <summary>
        /// Gets or sets the book object.
        /// </summary>
        /// <value>
        /// The object book.
        /// </value>
        public Book objBook { get; set; }

        /// <summary>
        /// Gets or sets the armor proficiency feat object.
        /// </summary>
        /// <value>
        /// The armor proficiency feat object.
        /// </value>
        public Feat objArmorProfFeat { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Armor"/> class.
        /// </summary>
        public Armor()
        {
            SetBaseConstructorOptions();
            lstArmorAvailability = new List<ItemAvailabilityType>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Armor"/> class.
        /// </summary>
        /// <param name="ArmorName">Name of the Armor.</param>
        public Armor(string ArmorName)
        {
            SetBaseConstructorOptions();
            lstArmorAvailability = new List<ItemAvailabilityType>();
            GetArmor(ArmorName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Armor"/> class.
        /// </summary>
        /// <param name="ArmorID">The Armor identifier.</param>
        public Armor(int ArmorID)
        {
            SetBaseConstructorOptions();
             lstArmorAvailability = new List<ItemAvailabilityType>();
            GetArmor(ArmorID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the armor by the ID of the Armor.
        /// </summary>
        /// <param name="ArmorID">The armor identifier.</param>
        /// <returns>Armor Object</returns>
        public Armor GetArmor(int ArmorID)
        {
            return GetSingleArmor("Select_Armor", "  ArmorID=" + ArmorID.ToString(), "");
        }

        /// <summary>
        /// Gets the armor object by the Name of the Armor.
        /// </summary>
        /// <param name="ArmorName">Name of the armor.</param>
        /// <returns>Armor Object</returns>
        public Armor GetArmor(string ArmorName)
        {
            return GetSingleArmor("Select_Armor", "  ArmorName='" + ArmorName + "'", "");

        }

        /// <summary>
        /// Gets a List of Armors based on the strWhere and strOrderBy parameters.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Armor Objects</returns>
        public List<Armor> GetArmors(string strWhere, string strOrderBy)
        {
            return GetArmorList("Select_Armor", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the Character Proficient Armors.
        /// </summary>
        /// <param name="strWhere">The Character ID in string format.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Armor Objects usable by the character</returns>
        public List<Armor> GetCharacterProficientArmors(int intCharacterID)
        {
            return GetArmorList("Select_CharacterProfecientArmor", intCharacterID.ToString(), "lstArmor.ArmorName");
        }

        /// <summary>
        /// Saves the armor.
        /// </summary>
        /// <returns>Armor Object</returns>
        public Armor SaveArmor()
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
                command.CommandText = "InsertUpdate_Armor";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorID", SqlDbType.Int, ArmorID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorTypeID", SqlDbType.Int, ArmorTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorName", SqlDbType.VarChar, ArmorName.ToString(), 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorDescription", SqlDbType.VarChar, ArmorDescription.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ReflexAdjustment", SqlDbType.Int, ReflexAdjustment.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@FortitudeAdjustment", SqlDbType.Int, FortitudeAdjustment.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorProficiencyFeatID", SqlDbType.Int, ArmorProficiencyFeatID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EmplacementPoints", SqlDbType.Int, EmplacementPoints.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Cost", SqlDbType.Int, Cost.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Weight", SqlDbType.Decimal, Weight.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@MaxDefBonus", SqlDbType.Int, MaxDefBonus.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BookID", SqlDbType.Int, BookID.ToString(), 0));
                
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
        /// Deletes the armor.
        /// </summary>
        /// <returns>
        /// bool, true if good, false if failure
        /// </returns>
        public bool DeleteArmor()
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
                command.CommandText = "Delete_Armor";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorID", SqlDbType.Int, ArmorID.ToString(), 0));
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
        /// Validates this instance of the Armor object.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            if (string.IsNullOrEmpty(this.ArmorName))
            {
                this._validated = false;
                this._validationMessage.Append("The Armor Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object Armor.
        /// </summary>
        /// <param name="objArmor">The object Armor.</param>
        /// <returns>Armor</returns>
        static public Armor Clone(Armor objArmor)
        {
            Armor objCArmor = new Armor();

            if (objArmor.ArmorID != 0) objCArmor.GetArmor(objArmor.ArmorID);
            else
            {
                objCArmor.ArmorID = 0;
                objCArmor.ArmorDescription = objArmor.ArmorDescription;
                objCArmor.ArmorName = objArmor.ArmorName;
                objCArmor.ArmorProficiencyFeatID = objArmor.ArmorProficiencyFeatID;
                objCArmor.ArmorTypeID = objArmor.ArmorTypeID;
                objCArmor.BookID = objArmor.BookID;
                objCArmor.Cost = objArmor.Cost;
                objCArmor.EmplacementPoints = objArmor.EmplacementPoints;
                objCArmor.FortitudeAdjustment = objArmor.FortitudeAdjustment;
                objCArmor.MaxDefBonus = objArmor.MaxDefBonus;
                objCArmor.ReflexAdjustment = objArmor.ReflexAdjustment;
                objCArmor.Weight = objArmor.Weight;

                objCArmor.lstArmorAvailability = ItemAvailabilityType.Clone(objArmor.lstArmorAvailability);
                Feat objFeat = new Feat(objArmor.objArmorProfFeat.FeatID );
                objCArmor.objArmorProfFeat = objFeat;

                ArmorType objArmorType = new ArmorType(objArmor.objArmorType.ArmorTypeID);
                objCArmor.objArmorType = objArmorType;

                Book objBook = new Book(objArmor.objBook.BookID);
                objCArmor.objBook = objBook;

            }
            return objCArmor;
        }

        /// <summary>
        /// Clones the specified LST Armor.
        /// </summary>
        /// <param name="lstArmor">The LST Armor.</param>
        /// <returns>List of Armor object</returns>
        static public List<Armor> Clone(List<Armor> lstArmor)
        {
            List<Armor> lstCArmor = new List<Armor>();

            foreach (Armor objArmor in lstArmor)
            {
                lstCArmor.Add(Armor.Clone(objArmor));
            }

            return lstCArmor;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single Armor from the Database.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Armor Object</returns>
        private Armor GetSingleArmor(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets a List of Armors from the Database.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Armor Objects</returns>
        private List<Armor> GetArmorList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Armor> armors = new List<Armor>();

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
                    Armor objArmor = new Armor();
                    SetReaderToObject(ref objArmor, ref result);
                    armors.Add(objArmor);
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
            return armors;
        }

        /// <summary>
        /// Sets the reader to this instance of the object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ArmorID = (int)result.GetValue(result.GetOrdinal("ArmorID"));
                this.ArmorTypeID = (int)result.GetValue(result.GetOrdinal("ArmorTypeID"));
                this.ArmorName = result.GetValue(result.GetOrdinal("ArmorName")).ToString();
                this.ArmorDescription = result.GetValue(result.GetOrdinal("ArmorDescription")).ToString();
                this.ReflexAdjustment = (int)result.GetValue(result.GetOrdinal("ReflexAdjustment"));
                this.FortitudeAdjustment = (int)result.GetValue(result.GetOrdinal("FortitudeAdjustment"));
                this.EmplacementPoints = (int)result.GetValue(result.GetOrdinal("EmplacementPoints"));
                this.Cost = (int)result.GetValue(result.GetOrdinal("Cost"));
                this.Weight = (decimal)result.GetValue(result.GetOrdinal("Weight"));
                this.MaxDefBonus = (int)result.GetValue(result.GetOrdinal("MaxDefBonus"));
                this.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                this.ArmorProficiencyFeatID = (int)result.GetValue(result.GetOrdinal("ArmorProficiencyFeatID"));

                ArmorType objArmorType = new ArmorType();
                if (!(this.ArmorTypeID == 0))
                {
                    objArmorType.GetArmorType(this.ArmorTypeID);
                }
                this.objArmorType = objArmorType;

                ItemAvailabilityType objAA = new ItemAvailabilityType();
                this.lstArmorAvailability = objAA.GetArmorAvailabilityTypes(this.ArmorID);

                this.objArmorProfFeat = new Feat(this.ArmorProficiencyFeatID);

                this.objBook = new Book(this.BookID);

                this._objComboBoxData.Add(this.ArmorID, this.ArmorName);
            }
        }

        /// <summary>
        /// Sets the reader to the Paramter Ability object .
        /// </summary>
        /// <param name="objArmor">The object armor.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Armor objArmor, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objArmor.ArmorID = (int)result.GetValue(result.GetOrdinal("ArmorID"));
                objArmor.ArmorTypeID  = (int)result.GetValue(result.GetOrdinal("ArmorTypeID"));
                objArmor.ArmorName = result.GetValue(result.GetOrdinal("ArmorName")).ToString();
                objArmor.ArmorDescription = result.GetValue(result.GetOrdinal("ArmorDescription")).ToString();
                objArmor.ReflexAdjustment  = (int)result.GetValue(result.GetOrdinal("ReflexAdjustment"));
                objArmor.FortitudeAdjustment  = (int)result.GetValue(result.GetOrdinal("FortitudeAdjustment"));
                objArmor.EmplacementPoints = (int)result.GetValue(result.GetOrdinal("EmplacementPoints"));
                objArmor.Cost = (int)result.GetValue(result.GetOrdinal("Cost"));
                objArmor.Weight = (decimal)result.GetValue(result.GetOrdinal("Weight"));
                objArmor.MaxDefBonus = (int)result.GetValue(result.GetOrdinal("MaxDefBonus"));
                objArmor.BookID = (int)result.GetValue(result.GetOrdinal("BookID"));
                objArmor.ArmorProficiencyFeatID = (int)result.GetValue(result.GetOrdinal("ArmorProficiencyFeatID"));

                ArmorType objArmorType = new ArmorType();
                if (!(objArmor.ArmorTypeID == 0))
                {
                    objArmorType.GetArmorType(objArmor.ArmorTypeID);
                }
                objArmor.objArmorType = objArmorType;

                ItemAvailabilityType objAA = new ItemAvailabilityType();
                objArmor.lstArmorAvailability = objAA.GetArmorAvailabilityTypes(objArmor.ArmorID);

                objArmor.objArmorProfFeat = new Feat(objArmor.ArmorProficiencyFeatID);


                objArmor.objBook = new Book(objArmor.BookID);

                objArmor._objComboBoxData.Add(objArmor.ArmorID, objArmor.ArmorName);
            }
        }

        #endregion
        #endregion
    }
}
