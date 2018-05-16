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
    /// The Ability object the individual abilites of the character.  Sample abilities are Strength, Intelligence, Wisdom, Dexterity, Constitution and Charasima.  
    /// Optional other abilites are Phsyical Strength, Mental Strength, etc.  but the addtion of any extra abilities to the database might require code changes.
    /// Matches to the lstAbility table in the database.
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class Ability : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ability identifier.
        /// </summary>
        /// <value>
        /// The ability identifier.
        /// </value>
        public int AbilityID { get; set; }
        /// <summary>
        /// Gets or sets the name of the ability.
        /// </summary>
        /// <value>
        /// The name of the ability.
        /// </value>
        public string AbilityName { get; set; }
        /// <summary>
        /// Gets or sets the sort order of the ability.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new blank instance of the <see cref="Ability"/> class.
        /// </summary>
        public Ability()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class by the ability name.
        /// </summary>
        /// <param name="AbilityName">Name of the ability.</param>
        public Ability(string AbilityName)
        {
            SetBaseConstructorOptions();
            GetAbility(AbilityName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class by the ability name.
        /// </summary>
        /// <param name="AbilityID">The ability identifier.</param>
        public Ability(int AbilityID)
        {
            SetBaseConstructorOptions();
            GetAbility(AbilityID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the ability object by the Ability ID.
        /// </summary>
        /// <param name="AbilityID">The ability identifier.</param>
        /// <returns>Ability Object</returns>
        public Ability GetAbility(int AbilityID)
        {
            return GetSingleAbility("Select_Ability", "  AbilityID=" + AbilityID.ToString(), "");
        }

        /// <summary>
        /// Gets the ability object by the Ability Name.
        /// </summary>
        /// <param name="AbilityName">Name of the ability.</param>
        /// <returns>Ability Object</returns>
        public Ability GetAbility(string AbilityName)
        {
            return GetSingleAbility("Select_Ability", "  AbilityName='" + AbilityName + "'", "");
        }

        /// <summary>
        /// Gets a list of Ability objects by the strWhere parameter (may be blank) and strOrderBy clause (maybe blank).
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Ability Objects</returns>
        public List<Ability> GetAbilites(string strWhere, string strOrderBy)
        {

            return GetAbilityList("Select_Ability", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the Ability object.
        /// </summary>
        /// <returns>Ability Object</returns>
        public Ability SaveAbility()
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
                command.CommandText = "InsertUpdate_Ability";
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityName", SqlDbType.VarChar, AbilityName.ToString(), 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SortOrder", SqlDbType.Int, SortOrder.ToString(), 0));
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
        /// Deletes the Ability object.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteAbility()
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
                command.CommandText = "Delete_Ability";
                command.Parameters.Add(dbconn.GenerateParameterObj("@AbilityID", SqlDbType.Int, AbilityID.ToString(), 0));
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
        /// Validates this instance of the Abililty object.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.AbilityName))
            {
                this._validated = false;
                this._validationMessage.Append("The Ability Name cannot be blank or null.");
            }
            return this.Validated;
        }

        #region Static Methods

        /// <summary>
        /// Does the parameter Character meet the specified Ability requirement.
        /// </summary>
        /// <param name="AbilityID">The ability identifier.</param>
        /// <param name="AbilityMin">The ability minimum.</param>
        /// <param name="objChar">The object character.</param>
        /// <returns>bool</returns>
        public static bool AblityRequirementMet (int AbilityID, int AbilityMin, Character objChar)
        {
            bool returnVal = false;

            foreach (CharacterAbility objCharAbility in objChar.lstCharacterAbilities)
            {
                if (objCharAbility.AbilityID == AbilityID)
                {
                   if (objCharAbility.Score >= AbilityMin) returnVal = true;
                }
            }

            return returnVal;
        }

        /// <summary>
        /// Increases the Character Ability by the specified amount.
        /// </summary>
        /// <param name="AbilityID">The ability identifier.</param>
        /// <param name="IncreaseAmount">The amount to increase the ability.</param>
        /// <param name="objChar">The object character.</param>
        public static void IncreaseCharacterAbility(int AbilityID, int IncreaseAmount, ref Character objChar)
        {

            foreach (CharacterAbility objCharAbility in objChar.lstCharacterAbilities )
            {
                if (objCharAbility.AbilityID == AbilityID)
                {
                    objCharAbility.Score = objCharAbility.Score + IncreaseAmount;
                    objCharAbility.ScoreMod = ((objCharAbility.Score + IncreaseAmount) - 10) / 2;
                }
            }
        }

        /// <summary>
        /// Gets the Ability modifier from the Character paramter for the specificed Ability.
        /// </summary>
        /// <param name="AbilityID">The ability identifier.</param>
        /// <param name="objChar">The object character.</param>
        /// <returns>int</returns>
        public static int GetAbilityMod(int AbilityID, Character objChar)
        {
            int returnVal = 0;

            foreach (CharacterAbility objCharAbility in objChar.lstCharacterAbilities)
            {
                if (objCharAbility.AbilityID == AbilityID)
                {
                    returnVal = objCharAbility.ScoreMod;
                }
            }

            //switch (AbilityID)
            //{
            //    case 1:         //1	Strength
            //        returnVal = objChar.StrengthMod;
            //        break;
            //    case 2:         //2	Intelligence
            //        returnVal =  objChar.IntelligenceMod;
            //        break;
            //    case 3:         //3	Wisdom
            //        returnVal = objChar.WisdomMod;
            //        break;
            //    case 4:         //4	Dexterity
            //        returnVal = objChar.DexterityMod;
            //        break;
            //    case 5:         //1	Constitution
            //        returnVal = objChar.ConstitutionMod;
            //        break;
            //    case 6:         //6	Charisma
            //        returnVal = objChar.CharismaMod;
            //        break;
            //    default:
            //        break;
            //}
            return returnVal;
        }

        /// <summary>
        /// Clones the specified object Ability.
        /// </summary>
        /// <param name="objAbility">The object Ability.</param>
        /// <returns>Ability</returns>
        static public Ability Clone(Ability objAbility)
        {
            Ability objCAbility = new Ability();

            if (objAbility.AbilityID != 0) objCAbility.GetAbility (objAbility.AbilityID); else
            {
                objCAbility.AbilityID = 0;
                objCAbility.AbilityName = objAbility.AbilityName;
                objCAbility.SortOrder = objAbility.SortOrder;
            }
            return objCAbility;
        }

        /// <summary>
        /// Clones the specified List of Ability objects.
        /// </summary>
        /// <param name="lstAbility">The LIST of Ability objects.</param>
        /// <returns>List of Ability objects</returns>
        static public List<Ability> Clone(List<Ability> lstAbility)
        {
            List<Ability> lstCAbility = new List<Ability>();

            foreach (Ability objAbility in lstAbility)
            {
                lstCAbility.Add(Ability.Clone(objAbility));
            }

            return lstCAbility;
        }
        #endregion
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single ability from the Database.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Ability Object</returns>
        private Ability GetSingleAbility(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets a List of Abilites from the Database.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Ability objects</returns>
        private List<Ability> GetAbilityList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Ability> abilities = new List<Ability>();

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
                    Ability objAbility = new Ability();
                    SetReaderToObject(ref objAbility, ref result);
                    abilities.Add(objAbility);
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
            return abilities;
        }

        /// <summary>
        /// Sets the reader to this instance of the object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                this.AbilityName = result.GetValue(result.GetOrdinal("AbilityName")).ToString();
                this.SortOrder = (int)result.GetValue(result.GetOrdinal("SortOrder"));
            }
        }

        /// <summary>
        /// Sets the reader to the Paramter Ability object.
        /// </summary>
        /// <param name="objAbility">The object ability.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Ability objAbility, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objAbility.AbilityID = (int)result.GetValue(result.GetOrdinal("AbilityID"));
                objAbility.AbilityName = result.GetValue(result.GetOrdinal("AbilityName")).ToString();
                objAbility.SortOrder = (int)result.GetValue(result.GetOrdinal("SortOrder"));
            }
        }

        #endregion

        #endregion
    }
}
