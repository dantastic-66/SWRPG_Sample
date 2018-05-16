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
    /// Returns a Base Attack object.  Currently a number that is one more than the ID, up to 20.
    /// No other properties at this time, the object was created incase other properties where needed for a Base Attack
    /// Matches to the lstBaseAttack table in the database.  
    /// </summary>
    /// <seealso cref="StarWarsClasses.BaseValidation" />
    public class BaseAttack : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the base attack identifier.
        /// </summary>
        /// <value>
        /// The base attack identifier.
        /// </value>
        public int BaseAttackID { get; set; }
        /// <summary>
        /// Gets or sets the base attack number.
        /// </summary>
        /// <value>
        /// The base attack number.
        /// </value>
        public int BaseAttackNumber { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAttack"/> class.
        /// </summary>
        public BaseAttack()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAttack"/> class.
        /// </summary>
        /// <param name="BaseAttackID">The BaseAttack identifier.</param>
        public BaseAttack(int BaseAttackID)
        {
            SetBaseConstructorOptions();
            GetBaseAttack(BaseAttackID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the BaseAttack object by the BaseAttack ID.
        /// </summary>
        /// <param name="BaseAttackID">The base attack identifier.</param>
        /// <returns>BaseAttack Object</returns>
        public BaseAttack GetBaseAttack(int BaseAttackID)
        {
            return GetSingleBaseAttack("Select_BaseAttack", " BaseAttackID=" + BaseAttackID.ToString(), "");
        }

        /// <summary>
        /// Gets the BaseAttack bonus prereuisite for the FeatID parameter
        /// </summary>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns>BaseAttack Object</returns>
        public BaseAttack GetFeatPrequisiteBaseAttackBonus(int FeatID)
        {
            return GetSingleBaseAttack("Select_FeatPrequisiteBaseAttackBonus", " FeatID=" + FeatID.ToString(), "");
        }

        /// <summary>
        ///  Gets the BaseAttack bonus prereuisite for the TalentID parameter
        /// </summary>
        /// <param name="TalentID">The Talent identifier.</param>
        /// <returns>BaseAttack Object</returns>
        public BaseAttack GetTalentPrequisiteBaseAttackBonus(int TalentID)
        {
            return GetSingleBaseAttack("Select_TalentPrequisiteBaseAttackBonus", " TalentID=" + TalentID.ToString(), "");
        }

        /// <summary>
        /// Gets a List of BaseAttack objects using the strWhere and strOrderBy parameters
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<BaseAttack> GetBaseAttacks(string strWhere, string strOrderBy)
        {
            return GetBaseAttackList("Select_BaseAttack", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the current BaseAttack object.
        /// </summary>
        /// <returns>BaseAttack Object</returns>
        public BaseAttack SaveBaseAttack()
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
                command.CommandText = "InsertUpdate_BaseAttack";
                command.Parameters.Add(dbconn.GenerateParameterObj("@BaseAttackID", SqlDbType.Int, BaseAttackID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BaseAttackNumber", SqlDbType.Int, BaseAttackNumber.ToString(), 0));
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
        /// Validates this instance of the BaseAttack object.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            ////Put Validation checks here
            //Validation is handled in this class with both values required and only allowing integers
            //if (string.IsNullOrEmpty(this.BaseAttackNumber ))
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Feat Name cannot be blank or null.");
            //}
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified BaseAttack object .
        /// </summary>
        /// <param name="objBaseAttack">The object BaseAttack.</param>
        /// <returns>BaseAttack</returns>
        static public BaseAttack Clone(BaseAttack objBaseAttack)
        {
            BaseAttack objCBaseAttack = new BaseAttack();

            if (objBaseAttack.BaseAttackID != 0) objCBaseAttack.GetBaseAttack(objBaseAttack.BaseAttackID);
            else
            {
                objCBaseAttack.BaseAttackID = 0;
                objCBaseAttack.BaseAttackNumber = objBaseAttack.BaseAttackNumber;
            }
            return objCBaseAttack;
        }

        /// <summary>
        /// Clones the specified List of BaseAttack objectds.
        /// </summary>
        /// <param name="lstBaseAttack">The LST BaseAttack.</param>
        /// <returns>List [BaseAttack]</returns>
        static public List<BaseAttack> Clone(List<BaseAttack> lstBaseAttack)
        {
            List<BaseAttack> lstCBaseAttack = new List<BaseAttack>();

            foreach (BaseAttack objBaseAttack in lstBaseAttack)
            {
                lstCBaseAttack.Add(BaseAttack.Clone(objBaseAttack));
            }

            return lstCBaseAttack;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Delete the current BaseAttack.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteBaseAttack()
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
                command.CommandText = "Delete_BaseAttack";
                command.Parameters.Add(dbconn.GenerateParameterObj("@BaseAttackID", SqlDbType.Int, BaseAttackID.ToString(), 0));
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
        ///  Gets the single BaseAttack object from the Database.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>BaseAttack Object</returns>
        private BaseAttack GetSingleBaseAttack(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets a list of BaseAttack objects from the Database.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of BaseAttack Objects</returns>
        private List<BaseAttack> GetBaseAttackList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<BaseAttack> lstBaseAttacks = new List<BaseAttack>();

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
                    BaseAttack objBaseAttack = new BaseAttack();
                    SetReaderToObject(ref objBaseAttack, ref result);
                    lstBaseAttacks.Add(objBaseAttack);
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
            return lstBaseAttacks;
        }

        /// <summary>
        /// Sets the reader to this instance of the object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.BaseAttackID = (int)result.GetValue(result.GetOrdinal("BaseAttackID"));
                this.BaseAttackNumber = (int)result.GetValue(result.GetOrdinal("BaseAttackNumber"));
            }
        }

        /// <summary>
        /// Sets the reader to the Paramter BaseAttack object.
        /// </summary>
        /// <param name="objBaseAttack">The object base attack.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref BaseAttack objBaseAttack, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objBaseAttack.BaseAttackID = (int)result.GetValue(result.GetOrdinal("BaseAttackID"));
                objBaseAttack.BaseAttackNumber = (int)result.GetValue(result.GetOrdinal("BaseAttackNumber"));
            }
        }
        #endregion
        #endregion
    }
}
