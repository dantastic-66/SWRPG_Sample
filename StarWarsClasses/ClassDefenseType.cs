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
    public class ClassDefenseType : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>
        /// The class identifier.
        /// </value>
        public int ClassID { get; set; }
        /// <summary>
        /// Gets or sets the defense type identifier.
        /// </summary>
        /// <value>
        /// The defense type identifier.
        /// </value>
        public int DefenseTypeID { get; set; }
        /// <summary>
        /// Gets or sets the modifier identifier.
        /// </summary>
        /// <value>
        /// The modifier identifier.
        /// </value>
        public int ModifierID { get; set; }

        /// <summary>
        /// Gets or sets the type of the object defense.
        /// </summary>
        /// <value>
        /// The type of the object defense.
        /// </value>
        public DefenseType objDefenseType { get; set; }

        /// <summary>
        /// Gets or sets the object modifier.
        /// </summary>
        /// <value>
        /// The object modifier.
        /// </value>
        public Modifier objModifier { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassDefenseType"/> class.
        /// </summary>
        public ClassDefenseType()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassDefenseType"/> class.
        /// </summary>
        /// <param name="ClassID">The Class identifier.</param>
        /// <param name="DefenseTypeID">The DefenseType identifier.</param>
        public ClassDefenseType(int ClassID, int DefenseTypeID)
        {
            SetBaseConstructorOptions();
            GetClassDefenseType(ClassID, DefenseTypeID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the type of the class defense.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <param name="DefenseTypeID">The defense type identifier.</param>
        /// <returns>ClassDefenseType Object</returns>
        public ClassDefenseType GetClassDefenseType(int ClassID, int DefenseTypeID)
        {
            return GetSingleClassDefenseType("Select_ClassDefenseType", " ClassID=" + ClassID.ToString() + " AND DefenseTypeID=" + DefenseTypeID.ToString(), "");
        }

        /// <summary>
        /// Gets the class defense types.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ClassDefenseType Objects</returns>
        public List<ClassDefenseType> GetClassDefenseTypes(string strWhere, string strOrderBy)
        {
            return GetClassDefenseTypeList("Select_ClassDefenseType", strWhere, strOrderBy);
        }
        
        /// <summary>
        /// Saves the ClassDefenseType.
        /// </summary>
        /// <returns>ClassDefenseType Object</returns>
        public ClassDefenseType SaveClassDefenseType()
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
                command.CommandText = "InsertUpdate_ClassDefenseType";

                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, ClassID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ModifierID", SqlDbType.Int, ModifierID.ToString(), 0));

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
        /// Delete the ClassDefenseType.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteClassDefenseType()
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
                command.CommandText = "Delete_ClassDefenseType";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, ClassID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DefenseTypeID", SqlDbType.Int, DefenseTypeID.ToString(), 0));
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
            if ((this.ModifierID == 0))
            {
                this._validated = false;
                this._validationMessage.Append("The Modifier ID cannot be 0.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object ClassDefenseType.
        /// </summary>
        /// <param name="objClassDefenseType">The object ClassDefenseType.</param>
        /// <returns>ClassDefenseType</returns>
        static public ClassDefenseType Clone(ClassDefenseType objClassDefenseType)
        {
            ClassDefenseType objCClassDefenseType = new ClassDefenseType(objClassDefenseType.ClassID,objClassDefenseType.DefenseTypeID );
            return objCClassDefenseType;
        }

        /// <summary>
        /// Clones the specified LST ClassDefenseType.
        /// </summary>
        /// <param name="lstClassDefenseType">The LST ClassDefenseType.</param>
        /// <returns>List<ClassDefenseType></returns>
        static public List<ClassDefenseType> Clone(List<ClassDefenseType> lstClassDefenseType)
        {
            List<ClassDefenseType> lstCClassDefenseType = new List<ClassDefenseType>();

            foreach (ClassDefenseType objClassDefenseType in lstClassDefenseType)
            {
                lstCClassDefenseType.Add(ClassDefenseType.Clone(objClassDefenseType));
            }

            return lstCClassDefenseType;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the type of the single class defense.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>ClassDefenseType Object</returns>
        private ClassDefenseType GetSingleClassDefenseType(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the class defense type list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ClassDefenseType Objects</returns>
        private List<ClassDefenseType> GetClassDefenseTypeList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ClassDefenseType> classDefenseTypes = new List<ClassDefenseType>();

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
                    ClassDefenseType objClassDefenseType = new ClassDefenseType();
                    SetReaderToObject(ref objClassDefenseType, ref result);
                    classDefenseTypes.Add(objClassDefenseType);
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
            return classDefenseTypes;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));
                this.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                this.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));

                Modifier objModifier = new Modifier();
                if (!(this.ModifierID == 0))
                {
                    objModifier.GetModifier(this.ModifierID);
                }
                this.objModifier = objModifier;

                DefenseType objDefenseType = new DefenseType();
                if (!(this.DefenseTypeID == 0))
                {
                    objDefenseType.GetDefenseType(this.DefenseTypeID);
                }
                this.objDefenseType = objDefenseType;

                //Class objClass = new Class();
                //if (!(this.ClassID == 0))
                //{
                //    objClass.GetClass(this.ClassID);
                //}
                //this.objClass = objClass;
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objClassDefenseType">Type of the object class defense.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref ClassDefenseType objClassDefenseType, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objClassDefenseType.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));
                objClassDefenseType.DefenseTypeID = (int)result.GetValue(result.GetOrdinal("DefenseTypeID"));
                objClassDefenseType.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));

                Modifier objModifier = new Modifier();
                if (!(objClassDefenseType.ModifierID == 0))
                {
                    objModifier.GetModifier(objClassDefenseType.ModifierID);
                }
                objClassDefenseType.objModifier = objModifier;

                DefenseType objDefenseType = new DefenseType();
                if (!(objClassDefenseType.DefenseTypeID == 0))
                {
                    objDefenseType.GetDefenseType (objClassDefenseType.DefenseTypeID );
                }
                objClassDefenseType.objDefenseType  = objDefenseType;

                //Class objClass = new Class();
                //if (!(objClassDefenseType.ClassID == 0))
                //{
                //    objClass.GetClass (objClassDefenseType.ClassID );
                //}
                //objClassDefenseType.objClass = objClass;
            }
        }
        #endregion
        #endregion
    }
}
