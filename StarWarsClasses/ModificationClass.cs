using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StarWarsClasses
{
    public class ModificationClass : BaseValidation
    {


        public int ModificationClassID { get; set; }
        public string ModificationClassName { get; set; }
        public string ModificationClassDescription { get; set; }


        #region Constructors
        public ModificationClass()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModificationClass"/> class.
        /// </summary>
        /// <param name="ModificationClassName">Name of the ModificationClass.</param>
        public ModificationClass(string ModificationClassName)
        {
            SetBaseConstructorOptions();
            GetModificationClass(ModificationClassName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModificationClass"/> class.
        /// </summary>
        /// <param name="ModificationClassID">The ModificationClass identifier.</param>
        public ModificationClass(int ModificationClassID)
        {
            SetBaseConstructorOptions();
            GetModificationClass(ModificationClassID);
        }
        #endregion


        #region Methods
        #region Public Methods
        public ModificationClass GetModificationClass(int ModificationClassID)
        {
            return GetSingleModificationClass("Select_ModificationClass", " ModificationClassID = " + ModificationClassID.ToString(), "");
        }

        public ModificationClass GetModificationClass(string ModificationClassName)
        {
            return GetSingleModificationClass("Select_ModificationClass", " ModificationClassName='" + ModificationClassID.ToString() + "'", "");
        }

        public List<ModificationClass> GetModificationClasss(string strWhere, string strOrderBy)
        {
            return GetModificationClassList("Select_ModificationClass", strWhere, strOrderBy);
        }

        public ModificationClass SaveModificationClass()
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
                command.CommandText = "InsertUpdate_ModificationClass";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationClassID", SqlDbType.Int, ModificationClassID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationClassName", SqlDbType.VarChar , ModificationClassName,50));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.VarChar, ModificationClassDescription, 100));

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
        /// Delete the ModificationClass.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteModificationClass()
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
                command.CommandText = "Delete_ModificationClass";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModificationClassID", SqlDbType.Int, ModificationClassID.ToString(), 0));
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
        #endregion

        #region Private Methods
        private ModificationClass GetSingleModificationClass(string sprocName, string strWhere, string strOrderBy)
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

        private List<ModificationClass> GetModificationClassList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ModificationClass> ModificationClasss = new List<ModificationClass>();

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
                    ModificationClass objModificationClass = new ModificationClass();
                    SetReaderToObject(ref objModificationClass, ref result);
                    ModificationClasss.Add(objModificationClass);
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
            return ModificationClasss;
        }

        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ModificationClassID = (int)result.GetValue(result.GetOrdinal("ModificationClassID"));
                this.ModificationClassName = result.GetValue(result.GetOrdinal("ModificationClassName")).ToString();
                this.ModificationClassDescription = result.GetValue(result.GetOrdinal("ModificationClassDescription")).ToString();
            }
        }

        private void SetReaderToObject(ref ModificationClass objModificationClass, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objModificationClass.ModificationClassID = (int)result.GetValue(result.GetOrdinal("ModificationClassID"));
                objModificationClass.ModificationClassName = result.GetValue(result.GetOrdinal("ModificationClassName")).ToString();
                objModificationClass.ModificationClassDescription = result.GetValue(result.GetOrdinal("ModificationClassDescription")).ToString();
            }
        }

        #endregion
        #endregion
    }
}
