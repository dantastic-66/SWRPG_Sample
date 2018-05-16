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
    public class SubSkill:BaseValidation
    {

        #region Properties
        /// <summary>
        /// Gets or sets the sub skill identifier.
        /// </summary>
        /// <value>
        /// The sub skill identifier.
        /// </value>
        public int SubSkillID { get; set; }
        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        public int SkillID { get; set; }
        /// <summary>
        /// Gets or sets the name of the sub skill.
        /// </summary>
        /// <value>
        /// The name of the sub skill.
        /// </value>
        public string SubSkillName { get; set; }
        /// <summary>
        /// Gets or sets the sub skill description.
        /// </summary>
        /// <value>
        /// The sub skill description.
        /// </value>
        public string SubSkillDescription { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SubSkill"/> is trained.
        /// </summary>
        /// <value>
        ///   <c>true</c> if trained; otherwise, <c>false</c>.
        /// </value>
        public bool Trained { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SubSkill"/> class.
        /// </summary>
        public SubSkill()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubSkill"/> class.
        /// </summary>
        /// <param name="SubSkillName">Name of the SubSkill.</param>
        public SubSkill(string SubSkillName)
        {
            SetBaseConstructorOptions();
            GetSubSkill(SubSkillName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubSkill"/> class.
        /// </summary>
        /// <param name="SubSkillID">The SubSkill identifier.</param>
        public SubSkill(int SubSkillID)
        {
            SetBaseConstructorOptions();
            GetSubSkill(SubSkillID);
        }
        #endregion

        #region Methods
        #region Public_Methods
        /// <summary>
        /// Gets the sub skill.
        /// </summary>
        /// <param name="SubSkillID">The sub skill identifier.</param>
        /// <returns>SubSkill object</returns>
        public SubSkill GetSubSkill(int SubSkillID)
        {
            return GetSingleSubSkill("Select_SubSkill", "  SubSkillID=" + SubSkillID.ToString(), "");
        }

        /// <summary>
        /// Gets the sub skill.
        /// </summary>
        /// <param name="SubSkillName">Name of the sub skill.</param>
        /// <returns>SubSkill object</returns>
        public SubSkill GetSubSkill(string SubSkillName)
        {
            return GetSingleSubSkill("Select_SubSkill", "  SubSkillName='" + SubSkillName + "'", "");
        }

        /// <summary>
        /// Gets the sub skills.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of SubSkill objects</returns>
        public List<SubSkill> GetSubSkills(string strWhere, string strOrderBy)
        {
            return GetSubSkillList("Select_SubSkill", strWhere, strOrderBy);
            //List<SubSkill> subSkills = new List<SubSkill>();

            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "Select_SubSkill";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
            //    result = command.ExecuteReader();

            //    while (result.Read())
            //    {
            //        SubSkill objSubSkill = new SubSkill();
            //        SetReaderToObject(ref objSubSkill, ref result);
            //        subSkills.Add(objSubSkill);
            //    }
            //}
            //catch
            //{
            //    Exception e = new Exception();
            //    throw e;
            //}
            //finally
            //{
            //    command.Dispose();
            //    connection.Close();
            //}
            //return subSkills;
        }

        /// <summary>
        /// Saves the sub skill.
        /// </summary>
        /// <returns>SubSkill object</returns>
        public SubSkill SaveSubSkill()
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
                command.CommandText = "InsertUpdate_SubSkill";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SubSkillID", SqlDbType.Int, SubSkillID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SkillID", SqlDbType.Int, SkillID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SubSkillName", SqlDbType.VarChar, SubSkillName.ToString(), 100));
                command.Parameters.Add(dbconn.GenerateParameterObj("@SubSkillDescription", SqlDbType.VarChar, SubSkillDescription.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Trained", SqlDbType.Bit , Trained.ToString(), 0));
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
        /// Deletes the sub skill.
        /// </summary>
        /// <returns>boolean</returns>
        public bool DeleteSubSkill()
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
                command.CommandText = "Delete_SubSkill";
                command.Parameters.Add(dbconn.GenerateParameterObj("@SubSkillID", SqlDbType.Int , SubSkillID.ToString(), 0));
                result = command.ExecuteReader();

            }
            catch
            {
                Exception e = new Exception();
                this._deleteOK = false;
                this._deletionMessage.Append(e.Message + "                     Inner Exception= " + e.InnerException);
                //throw e;
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
            if (string.IsNullOrEmpty(this.SubSkillName ))
            {
                this._validated = false;
                this._validationMessage.Append("The SubSkill Name cannot be blank or null.");
            }
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object SubSkill.
        /// </summary>
        /// <param name="objSubSkill">The object SubSkill.</param>
        /// <returns>SubSkill</returns>
        static public SubSkill Clone(SubSkill objSubSkill)
        {
            SubSkill objCSubSkill = new SubSkill(objSubSkill.SubSkillID);
            return objCSubSkill;
        }

        /// <summary>
        /// Clones the specified LST SubSkill.
        /// </summary>
        /// <param name="lstSubSkill">The LST SubSkill.</param>
        /// <returns>List<SubSkill></returns>
        static public List<SubSkill> Clone(List<SubSkill> lstSubSkill)
        {
            List<SubSkill> lstCSubSkill = new List<SubSkill>();

            foreach (SubSkill objSubSkill in lstSubSkill)
            {
                lstCSubSkill.Add(SubSkill.Clone(objSubSkill));
            }

            return lstCSubSkill;
        }
        #endregion

        #region Private_Methods
        /// <summary>
        /// Gets the single sub skill.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>SubSkill object</returns>
        private SubSkill GetSingleSubSkill(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the sub skill list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of SubSkill objects</returns>
        private List<SubSkill> GetSubSkillList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<SubSkill> subSkills = new List<SubSkill>();

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
                    SubSkill objSubSkill = new SubSkill();
                    SetReaderToObject(ref objSubSkill, ref result);
                    subSkills.Add(objSubSkill);
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
            return subSkills;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.SubSkillID = (int)result.GetValue(result.GetOrdinal("SubSkillID"));
                this.SubSkillName = result.GetValue(result.GetOrdinal("SubSkillName")).ToString();
                this.SubSkillDescription = result.GetValue(result.GetOrdinal("SubSkillDescription")).ToString();
                this.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                this.Trained = (bool)result.GetValue(result.GetOrdinal("Trained"));

                this._objComboBoxData.Add(this.SubSkillID, this.SubSkillName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objSubSkill">The object sub skill.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SubSkill objSubSkill, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objSubSkill.SubSkillID = (int)result.GetValue(result.GetOrdinal("SubSkillID"));
                objSubSkill.SubSkillName = result.GetValue(result.GetOrdinal("SubSkillName")).ToString();
                objSubSkill.SubSkillDescription = result.GetValue(result.GetOrdinal("SubSkillDescription")).ToString();
                objSubSkill.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                objSubSkill.Trained = (bool)result.GetValue(result.GetOrdinal("Trained"));

                objSubSkill._objComboBoxData.Add(objSubSkill.SubSkillID, objSubSkill.SubSkillName);
            }
        }
        #endregion
        #endregion


    }
}
