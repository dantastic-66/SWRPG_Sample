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
    public class Range:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the range identifier.
        /// </summary>
        /// <value>
        /// The range identifier.
        /// </value>
        public int RangeID { get; set; }
        /// <summary>
        /// Gets or sets the name of the range.
        /// </summary>
        /// <value>
        /// The name of the range.
        /// </value>
        public string RangeName { get; set; }
        /// <summary>
        /// Gets or sets the begin square.
        /// </summary>
        /// <value>
        /// The begin square.
        /// </value>
        public int BeginSquare { get; set; }
        /// <summary>
        /// Gets or sets the end square.
        /// </summary>
        /// <value>
        /// The end square.
        /// </value>
        public int EndSquare { get; set; }
        /// <summary>
        /// Gets or sets the modifier.
        /// </summary>
        /// <value>
        /// The modifier.
        /// </value>
        public int ModifierID { get; set; }

        public Modifier objModifier { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Range" /> class.
        /// </summary>
        public Range()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// </summary>
        /// <param name="RangeName">Name of the Range.</param>
        public Range(string RangeName)
        {
            SetBaseConstructorOptions();
            GetRange(RangeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// </summary>
        /// <param name="RangeID">The Range identifier.</param>
        public Range(int RangeID)
        {
            SetBaseConstructorOptions();
            GetRange(RangeID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <param name="RangeID">The range identifier.</param>
        /// <returns>Range object</returns>
        public Range GetRange(int RangeID)
        {
            return GetSingleRange("Select_Range", "  RangeID=" + RangeID.ToString(), "");
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <param name="RangeName">Name of the range.</param>
        /// <returns>Range object</returns>
        public Range GetRange(string RangeName)
        {
            return GetSingleRange("Select_Range", "  RangeName='" + RangeName + "'", "");
        }

        /// <summary>
        /// Gets the ranges.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Range objects</returns>
        public List<Range> GetRanges(string strWhere, string strOrderBy)
        {
            return GetRangeList("Select_Range", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the weapon ranges.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Range object</returns>
        public List<Range> GetWeaponRanges(string strWhere, string strOrderBy)
        {
            return GetRangeList("Select_WeaponRange", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the Range.
        /// </summary>
        /// <returns>Range object</returns>
        public Range SaveRange()
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
                command.CommandText = "InsertUpdate_Range";

                command.Parameters.Add(dbconn.GenerateParameterObj("@RangeID", SqlDbType.Int, RangeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RangeName", SqlDbType.VarChar, RangeName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BeginSquare", SqlDbType.Int, BeginSquare.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@EndSquare", SqlDbType.Int, EndSquare.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Modifier", SqlDbType.Int, ModifierID.ToString(), 0));
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
        /// Deletes the Range item.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteRange()
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
                command.CommandText = "Delete_Range";
                command.Parameters.Add(dbconn.GenerateParameterObj("@RangeID", SqlDbType.Int, RangeID.ToString(), 0));
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
        /// Saves the Weapon Range.
        /// </summary>
        /// <param name="WeaponID">The weapon identifier.</param>
        /// <returns>Range object</returns>
        public Range SaveWeaponRange(int WeaponID)
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
                command.CommandText = "InsertUpdate_WeaponRange";

                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, WeaponID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RangeID", SqlDbType.Int, RangeID.ToString(), 0));
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
        /// Deletes the Weapon Range item.
        /// </summary>
        /// <param name="WeaponID">The weapon identifier.</param>
        /// <returns>Boolean</returns>
        public bool DeleteWeaponRange(int WeaponID)
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
                command.CommandText = "Delete_WeaponRange";
                command.Parameters.Add(dbconn.GenerateParameterObj("@WeaponID", SqlDbType.Int, WeaponID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RangeID", SqlDbType.Int, RangeID.ToString(), 0));
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
        /// <returns>boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.RangeName))
            {
                this._validated = false;
                this._validationMessage.Append("The Range Name cannot be blank or null.");
            }
            return this.Validated;
        }

        #region Static Methods
        /// <summary>
        /// Clones the specified object Range.
        /// </summary>
        /// <param name="objRange">The object Range.</param>
        /// <returns>Range</returns>
        static public Range Clone(Range objRange)
        {
            Range objCRange = new Range(objRange.RangeID);
            return objCRange;
        }

        /// <summary>
        /// Clones the specified LST Range.
        /// </summary>
        /// <param name="lstRange">The LST Range.</param>
        /// <returns>List<Range></returns>
        static public List<Range> Clone(List<Range> lstRange)
        {
            List<Range> lstCRange = new List<Range>();

            foreach (Range objRange in lstRange)
            {
                lstCRange.Add(Range.Clone(objRange));
            }

            return lstCRange;
        }

        static public bool RangeTypeInRangeList(string strRangeType, List<Range> lstRanges)
        {
            bool retVal = false;

            foreach (Range objRange in lstRanges)
            {
                if (objRange.RangeName.Contains(strRangeType)) retVal = true;
            }
            return retVal;
        }
        #endregion
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single range.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Range object</returns>
        private Range GetSingleRange(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the range list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Range objects</returns>
        private List<Range> GetRangeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Range> ranges = new List<Range>();

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
                    Range objRange = new Range();
                    SetReaderToObject(ref objRange, ref result);
                    ranges.Add(objRange);
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
            return ranges;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.RangeID = (int)result.GetValue(result.GetOrdinal("RangeID"));
                this.RangeName = result.GetValue(result.GetOrdinal("RangeName")).ToString();
                this.BeginSquare = (int)result.GetValue(result.GetOrdinal("BeginSquare"));
                this.EndSquare = (int)result.GetValue(result.GetOrdinal("EndSquare"));
                this.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));

                Modifier objMod = new Modifier(this.ModifierID);
                this.objModifier = objMod;

                this._objComboBoxData.Add(this.RangeID, this.RangeName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objRange">The object range.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Range objRange, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objRange.RangeID = (int)result.GetValue(result.GetOrdinal("RangeID"));
                objRange.RangeName = result.GetValue(result.GetOrdinal("RangeName")).ToString();
                objRange.BeginSquare = (int)result.GetValue(result.GetOrdinal("BeginSquare"));
                objRange.EndSquare = (int)result.GetValue(result.GetOrdinal("EndSquare"));
                objRange.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));

                Modifier objMod = new Modifier(objRange.ModifierID);
                objRange.objModifier = objMod;

                objRange._objComboBoxData.Add(objRange.RangeID, objRange.RangeName);
            }
        }
        #endregion
        #endregion
    }
}
