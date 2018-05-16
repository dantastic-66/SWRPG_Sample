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
    public class ExtraClassItem : BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the extra class level item identifier.
        /// </summary>
        /// <value>
        /// The extra class level item identifier.
        /// </value>
        public int ExtraClassLevelItemID { get; set; }
        /// <summary>
        /// Gets or sets the name of the extra class level item.
        /// </summary>
        /// <value>
        /// The name of the extra class level item.
        /// </value>
        public string ExtraClassLevelItemName { get; set; }
        /// <summary>
        /// Gets or sets the extra class level item description.
        /// </summary>
        /// <value>
        /// The extra class level item description.
        /// </value>
        public string ExtraClassLevelItemDescription { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraClassItem" /> class.
        /// </summary>
        public ExtraClassItem()
		{
            SetBaseConstructorOptions();
        }

         /// <summary>
        /// Initializes a new instance of the <see cref="ExtraClassItemID"/> class.
        /// </summary>
        /// <param name="ExtraClassItemName">Name of the ExtraClassItem.</param>
        public ExtraClassItem(string ExtraClassItemName)
        {
            SetBaseConstructorOptions();
            GetExtraClassItem(ExtraClassItemName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraClassItemID"/> class.
        /// </summary>
        /// <param name="ExtraClassItemIDID">The ExtraClassItemID identifier.</param>
        public ExtraClassItem(int ExtraClassItemID)
        {
            SetBaseConstructorOptions();
            GetExtraClassItem(ExtraClassItemID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the extra class item.
        /// </summary>
        /// <param name="ExtraClassItemID">The extra class item identifier.</param>
        /// <returns>ExtraClassItem Object</returns>
        public ExtraClassItem GetExtraClassItem(int ExtraClassItemID)
        {
            return GetSingleExtraClassItem("Select_ExtraClassLevelItem", "  ExtraClassLevelItemID=" + ExtraClassItemID.ToString(), "ExtraClassLevelItemName");
        }

        /// <summary>
        /// Gets the extra class item.
        /// </summary>
        /// <param name="EquipmentName">Name of the equipment.</param>
        /// <returns>ExtraClassItem Object</returns>
        public ExtraClassItem GetExtraClassItem(string EquipmentName)
        {
            return GetSingleExtraClassItem("Select_ExtraClassLevelItem", "  ExtraClassLevelItemName='" + EquipmentName + "'", "ExtraClassLevelItemName");
        }

        /// <summary>
        /// Gets the extra class item.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>ExtraClassItem Object</returns>
        public ExtraClassItem GetExtraClassItem(string strWhere, string strOrderBy)
        {
            return GetSingleExtraClassItem("Select_ExtraClassLevelItem", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the class extra class item.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ExtraClassItem Objects</returns>
        public List<ExtraClassItem> GetExtraClassItems(string strWhere, string strOrderBy)
        {
            return GetExtraClassItemList("Select_ExtraClassLevelItem", strWhere, strOrderBy);
        }

         /// <summary>
         /// Saves the extra class item.
         /// </summary>
        /// <returns>ExtraClassItem Object</returns>
        public ExtraClassItem SaveExtraClassItem()
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
                command.CommandText = "InsertUpdate_ExtraClassLevelItem";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ExtraClassLevelItemID", SqlDbType.Int, ExtraClassLevelItemID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ExtraClassLevelItemName", SqlDbType.VarChar, ExtraClassLevelItemName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ExtraClassLevelItemDescription", SqlDbType.VarChar, ExtraClassLevelItemDescription.ToString(), 400));
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
        /// Deletes the extra class item.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteExtraClassItem()
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
                command.CommandText = "Delete_ExtraClassLevelItem";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ExtraClassLevelItemID", SqlDbType.Int, ExtraClassLevelItemID.ToString(), 0));
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
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.ExtraClassLevelItemName))
            {
                this._validated = false;
                this._validationMessage.Append("The Extra Class Leve Item Name Name cannot be blank or null.");
            }

            if (string.IsNullOrEmpty(this.ExtraClassLevelItemDescription))
            {
                this._validated = false;
                this._validationMessage.Append("The Extra Class Level Description Name Name cannot be blank or null.");
            }

            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object ExtraClassItem.
        /// </summary>
        /// <param name="objExtraClassItem">The object ExtraClassItem.</param>
        /// <returns>ExtraClassItem</returns>
        static public ExtraClassItem Clone(ExtraClassItem objExtraClassItem)
        {
            ExtraClassItem objCExtraClassItem = new ExtraClassItem(objExtraClassItem.ExtraClassLevelItemID);
            return objCExtraClassItem;
        }

        /// <summary>
        /// Clones the specified LST ExtraClassItem.
        /// </summary>
        /// <param name="lstExtraClassItem">The LST ExtraClassItem.</param>
        /// <returns>List<ExtraClassItem></returns>
        static public List<ExtraClassItem> Clone(List<ExtraClassItem> lstExtraClassItem)
        {
            List<ExtraClassItem> lstCExtraClassItem = new List<ExtraClassItem>();

            foreach (ExtraClassItem objExtraClassItem in lstExtraClassItem)
            {
                lstCExtraClassItem.Add(ExtraClassItem.Clone(objExtraClassItem));
            }

            return lstCExtraClassItem;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single extra class item.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>ExtraClassItem Object</returns>
        private ExtraClassItem GetSingleExtraClassItem(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the extra class item list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ExtraClassItem Objects</returns>
        private List<ExtraClassItem> GetExtraClassItemList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ExtraClassItem> featPrerequisiteAbilitys = new List<ExtraClassItem>();

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
                    ExtraClassItem objExtraClassItem = new ExtraClassItem();
                    SetReaderToObject(ref objExtraClassItem, ref result);
                    featPrerequisiteAbilitys.Add(objExtraClassItem);
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
            return featPrerequisiteAbilitys;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ExtraClassLevelItemID = (int)result.GetValue(result.GetOrdinal("ExtraClassLevelItemID"));
                this.ExtraClassLevelItemName = result.GetValue(result.GetOrdinal("ExtraClassLevelItemName")).ToString();
                this.ExtraClassLevelItemDescription = result.GetValue(result.GetOrdinal("ExtraClassLevelItemDescription")).ToString();

                this._objComboBoxData.Add(this.ExtraClassLevelItemID, this.ExtraClassLevelItemName);

            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objExtraClassItem">The object extra class item.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref ExtraClassItem objExtraClassItem, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objExtraClassItem.ExtraClassLevelItemID = (int)result.GetValue(result.GetOrdinal("ExtraClassLevelItemID"));
                objExtraClassItem.ExtraClassLevelItemName = result.GetValue(result.GetOrdinal("ExtraClassLevelItemName")).ToString();
                objExtraClassItem.ExtraClassLevelItemDescription = result.GetValue(result.GetOrdinal("ExtraClassLevelItemDescription")).ToString();

                objExtraClassItem._objComboBoxData.Add(objExtraClassItem.ExtraClassLevelItemID, objExtraClassItem.ExtraClassLevelItemName);

            }
        }
        #endregion
        #endregion
    }
}

