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
    public class ForcePowerDescriptor :BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the force power descriptor identifier.
        /// </summary>
        /// <value>
        /// The force power descriptor identifier.
        /// </value>
        public int ForcePowerDescriptorID { get; set; }
        /// <summary>
        /// Gets or sets the name of the force power descriptor.
        /// </summary>
        /// <value>
        /// The name of the force power descriptor.
        /// </value>
        public string ForcePowerDescriptorName { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePowerDescriptor"/> class.
        /// </summary>
        public ForcePowerDescriptor()
		{
            SetBaseConstructorOptions();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePowerDescriptor"/> class.
        /// </summary>
        /// <param name="ForcePowerDescriptorName">Name of the ForcePowerDescriptor.</param>
        public ForcePowerDescriptor(string ForcePowerDescriptorName)
        {
            SetBaseConstructorOptions();
            GetForcePowerDescriptor(ForcePowerDescriptorName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForcePowerDescriptor"/> class.
        /// </summary>
        /// <param name="ForcePowerDescriptorID">The ForcePowerDescriptor identifier.</param>
        public ForcePowerDescriptor(int ForcePowerDescriptorID)
        {
            SetBaseConstructorOptions();
            GetForcePowerDescriptor(ForcePowerDescriptorID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the force power descriptor.
        /// </summary>
        /// <param name="ForcePowerDescriptorID">The force power descriptor identifier.</param>
        /// <returns></returns>
        public ForcePowerDescriptor GetForcePowerDescriptor(int ForcePowerDescriptorID)
        {
            return GetSingleForcePowerDescriptor("Select_ForcePowerDescriptor", "  ForcePowerDescriptorID=" + ForcePowerDescriptorID.ToString (), "");
        }

        /// <summary>
        /// Gets the force power descriptor.
        /// </summary>
        /// <param name="ForcePowerDescriptorName">Name of the force power descriptor.</param>
        /// <returns></returns>
        public ForcePowerDescriptor GetForcePowerDescriptor(string ForcePowerDescriptorName)
        {
            return GetSingleForcePowerDescriptor("Select_ForcePowerDescriptor", "  ForcePowerDescriptorName='" + ForcePowerDescriptorName + "'", "");
        }

        /// <summary>
        /// Gets the force power descriptors.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<ForcePowerDescriptor> GetForcePowerDescriptors(string strWhere, string strOrderBy)
        {
            return GetForcePowerDescriptorList("Select_ForcePowerDescriptor", strWhere, strOrderBy);
        }

        /// <summary>
        /// Gets the force power force power descriptors.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        public List<ForcePowerDescriptor> GetForcePowerForcePowerDescriptors(string strWhere, string strOrderBy)
        {
            return GetForcePowerDescriptorList("Select_ForcePowerForcePowerDescriptor", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the force power descriptor.
        /// </summary>
        /// <returns></returns>
        public ForcePowerDescriptor SaveForcePowerDescriptor()
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
                command.CommandText = "InsertUpdate_ForcePowerDescriptor";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerDescriptorID", SqlDbType.Int, ForcePowerDescriptorID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerDescriptorName", SqlDbType.VarChar, ForcePowerDescriptorName.ToString(), 50));
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
        /// <returns></returns>
        public bool DeleteForcePowerDescriptor()
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
                command.CommandText = "Delete_ForcePowerDescriptor";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePowerDescriptorID", SqlDbType.Int, ForcePowerDescriptorID.ToString(), 0));
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
        /// <returns></returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.ForcePowerDescriptorName))
            {
                this._validated = false;
                this._validationMessage.Append("The Force Power Descriptor Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object ForcePowerDescriptor.
        /// </summary>
        /// <param name="objForcePowerDescriptor">The object ForcePowerDescriptor.</param>
        /// <returns>ForcePowerDescriptor</returns>
        static public ForcePowerDescriptor Clone(ForcePowerDescriptor objForcePowerDescriptor)
        {
            ForcePowerDescriptor objCForcePowerDescriptor = new ForcePowerDescriptor(objForcePowerDescriptor.ForcePowerDescriptorID);
            return objCForcePowerDescriptor;
        }

        /// <summary>
        /// Clones the specified LST ForcePowerDescriptor.
        /// </summary>
        /// <param name="lstForcePowerDescriptor">The LST ForcePowerDescriptor.</param>
        /// <returns>List<ForcePowerDescriptor></returns>
        static public List<ForcePowerDescriptor> Clone(List<ForcePowerDescriptor> lstForcePowerDescriptor)
        {
            List<ForcePowerDescriptor> lstCForcePowerDescriptor = new List<ForcePowerDescriptor>();

            foreach (ForcePowerDescriptor objForcePowerDescriptor in lstForcePowerDescriptor)
            {
                lstCForcePowerDescriptor.Add(ForcePowerDescriptor.Clone(objForcePowerDescriptor));
            }

            return lstCForcePowerDescriptor;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single force power descriptor.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private ForcePowerDescriptor GetSingleForcePowerDescriptor(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the force power descriptor list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns></returns>
        private List<ForcePowerDescriptor> GetForcePowerDescriptorList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ForcePowerDescriptor> forcePowerDescriptors = new List<ForcePowerDescriptor>();

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
                    ForcePowerDescriptor objForcePowerDescriptor = new ForcePowerDescriptor();
                    SetReaderToObject(ref objForcePowerDescriptor, ref result);
                    forcePowerDescriptors.Add(objForcePowerDescriptor);
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
            return forcePowerDescriptors;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ForcePowerDescriptorID = (int)result.GetValue(result.GetOrdinal("ForcePowerDescriptorID"));
                this.ForcePowerDescriptorName = result.GetValue(result.GetOrdinal("ForcePowerDescriptorName")).ToString();

                this._objComboBoxData.Add(this.ForcePowerDescriptorID, this.ForcePowerDescriptorName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objForcePowerDescriptor">The object force power descriptor.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref ForcePowerDescriptor objForcePowerDescriptor, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objForcePowerDescriptor.ForcePowerDescriptorID = (int)result.GetValue(result.GetOrdinal("ForcePowerDescriptorID"));
                objForcePowerDescriptor.ForcePowerDescriptorName = result.GetValue(result.GetOrdinal("ForcePowerDescriptorName")).ToString();

                objForcePowerDescriptor._objComboBoxData.Add(objForcePowerDescriptor.ForcePowerDescriptorID, objForcePowerDescriptor.ForcePowerDescriptorName);

            }
        }
        #endregion
        #endregion
    }
}
