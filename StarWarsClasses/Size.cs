using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace StarWarsClasses
{
    public class Size:BaseValidation
    {

        #region Properties
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public int SizeModifier { get; set; }

        SizeSkillModifier objSizeSkillModifier { get; set; }
        SizeDefenseModifier objSizeDefenseModifier { get; set; }
        #endregion

        #region Constructors
        public Size()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="SizeName">Name of the Size.</param>
        public Size(string SizeName)
        {
            SetBaseConstructorOptions();
            GetSize(SizeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="SizeID">The Size identifier.</param>
        public Size(int SizeID)
        {
            SetBaseConstructorOptions();
            GetSize(SizeID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="SizeID">The size identifier.</param>
        /// <returns>Size object</returns>
        public Size GetSize(int SizeID)
        {
            return GetSingleSize("Select_Size", " SizeID=" + SizeID.ToString(), "");
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="SizeName">Name of the size.</param>
        /// <returns>Size object</returns>
        public Size GetSize(string SizeName)
        {
            return GetSingleSize("Select_Size", "  SizeName='" + SizeName + "'", "");
        }

        /// <summary>
        /// Gets the sizes.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Size objects</returns>
        public List<Size> GetSizes(string strWhere, string strOrderBy)
        {
            return GetSizeList("Select_Size", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the size of the feat prerequisite.
        /// </summary>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns>list of Size objects</returns>
        public List<Size> GetFeatPrerequisiteSize(int FeatID)
        {
            return GetSizeList("Select_FeatPrerequisiteSize", "  FeatID=" + FeatID.ToString(), "SizeName");
        }

        /// <summary>
        /// Saves the Size.
        /// </summary>
        /// <returns>Size object</returns>
        public Size SaveSize()
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
                command.CommandText = "InsertUpdate_Size";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SizeID", SqlDbType.Int, SizeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SizeName", SqlDbType.VarChar, SizeName.ToString(), 50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SizeModifier", SqlDbType.Int, SizeModifier.ToString(), 0));
                
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
        /// Deletes the Size item.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteSize()
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
                command.CommandText = "Delete_Size";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SizeID", SqlDbType.Int, SizeID.ToString(), 0));
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
        public override  bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.SizeName ))
            {
                this._validated = false;
                this._validationMessage.Append("The Size Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object Size.
        /// </summary>
        /// <param name="objSize">The object Size.</param>
        /// <returns>Size</returns>
        static public Size Clone(Size objSize)
        {
            Size objCSize = new Size(objSize.SizeID);
            return objCSize;
        }

        /// <summary>
        /// Clones the specified LST Size.
        /// </summary>
        /// <param name="lstSize">The LST Size.</param>
        /// <returns>List<Size></returns>
        static public List<Size> Clone(List<Size> lstSize)
        {
            List<Size> lstCSize = new List<Size>();

            foreach (Size objSize in lstSize)
            {
                lstCSize.Add(Size.Clone(objSize));
            }

            return lstCSize;
        }
        #endregion

        #region Static_Methods
        /// <summary>
        /// Determines whether [is size in list] [the specified object size].
        /// </summary>
        /// <param name="objSize">Size of the object.</param>
        /// <param name="lstSize">Size of the LST.</param>
        /// <returns>boolean</returns>
        static public bool IsSizeInList(Size objSize, List<Size> lstSize)
        {
            bool blnSizeFound = false;

            if (lstSize.Count == 0)
            {
                blnSizeFound = true;
            }
            else
            {
                foreach (Size lstObjSize in lstSize)
                {
                    if (objSize.SizeID == lstObjSize.SizeID)
                    {
                        blnSizeFound = true;
                    }
                }
            }

            return blnSizeFound;
        }

        /// <summary>
        /// Determines whether [is size in list] [the specified LST need sizes].
        /// </summary>
        /// <param name="lstNeedSizes">The LST need sizes.</param>
        /// <param name="lstSizes">The LST sizes.</param>
        /// <returns>boolean</returns>
        static public bool IsSizeInList(List<Size> lstNeedSizes, List<Size> lstSizes)
        {
            bool blnAllSizesFound = true;
            bool blnSizeFound = false;

            foreach (Size objNeededSize in lstNeedSizes)
            {
                foreach (Size objSize in lstSizes)
                {
                    if (objNeededSize.SizeID == objSize.SizeID)
                    {
                        blnSizeFound = true;
                    }
                }
                if (blnAllSizesFound)
                {
                    blnAllSizesFound = blnSizeFound;
                }
            }

            return blnAllSizesFound;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the size of the single.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Size object</returns>
        private Size GetSingleSize(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the size list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Size objects</returns>
        private List<Size> GetSizeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Size> sizes = new List<Size>();

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
                    Size objSize = new Size();
                    SetReaderToObject(ref objSize, ref result);
                    sizes.Add(objSize);
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
            return sizes;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.SizeID = (int)result.GetValue(result.GetOrdinal("SizeID"));
                this.SizeName = result.GetValue(result.GetOrdinal("SizeName")).ToString();
                this.SizeModifier = (int)result.GetValue(result.GetOrdinal("SizeModifier"));

                SizeSkillModifier objSizeSkillModifier = new SizeSkillModifier();
                SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();

                this.objSizeSkillModifier  = objSizeSkillModifier.GetSizeSkillModifier(this.SizeID);
                this.objSizeDefenseModifier = objSizeDefenseModifier.GetSizeDefenseModifier(this.SizeID);

                this._objComboBoxData.Add(this.SizeID, this.SizeName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objSize">Size of the object.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Size objSize, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objSize.SizeID = (int)result.GetValue(result.GetOrdinal("SizeID"));
                objSize.SizeName = result.GetValue(result.GetOrdinal("SizeName")).ToString();
                objSize.SizeModifier = (int)result.GetValue(result.GetOrdinal("SizeModifier"));

                SizeSkillModifier objSizeSkillModifier = new SizeSkillModifier();
                SizeDefenseModifier objSizeDefenseModifier = new SizeDefenseModifier();

                objSize.objSizeSkillModifier = objSizeSkillModifier.GetSizeSkillModifier(objSize.SizeID);
                objSize.objSizeDefenseModifier = objSizeDefenseModifier.GetSizeDefenseModifier(objSize.SizeID);

                objSize._objComboBoxData.Add(objSize.SizeID, objSize.SizeName);
            }
        }
        #endregion
        #endregion
      
    }
}
