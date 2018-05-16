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
    public class SizeSkillModifier:BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the size identifier.
        /// </summary>
        /// <value>
        /// The size identifier.
        /// </value>
        public int SizeID { get; set; }
        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        public int SkillID { get; set; }
        /// <summary>
        /// Gets or sets the modifier identifier.
        /// </summary>
        /// <value>
        /// The modifier identifier.
        /// </value>
        public int ModifierID { get; set; }

        /// <summary>
        /// Gets or sets the object skill.
        /// </summary>
        /// <value>
        /// The object skill.
        /// </value>
        Skill objSkill { get; set; }
        /// <summary>
        /// Gets or sets the object modifier.
        /// </summary>
        /// <value>
        /// The object modifier.
        /// </value>
        Modifier objModifier { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SizeSkillModifier"/> class.
        /// </summary>
        public SizeSkillModifier()
        {
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizeSkillModifier"/> class.
        /// </summary>
        /// <param name="SizeID">The SizeSkillModifier identifier.</param>
        public SizeSkillModifier(int SizeID)
        {
            SetBaseConstructorOptions();
            GetSizeSkillModifier(SizeID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizeSkillModifier"/> class.
        /// </summary>
        /// <param name="SizeID">The Size identifier.</param>
        /// <param name="SkillID">The Skill identifier.</param>
        /// <param name="ModifierID">The Modifier identifier.</param>
        public SizeSkillModifier(int SizeID, int SkillID, int ModifierID)
        {
            SetBaseConstructorOptions();
            GetSizeSkillModifier(SizeID,SkillID, ModifierID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the size skill modifier.
        /// </summary>
        /// <param name="SizeID">The size identifier.</param>
        /// <returns>SizeSkillModifier object</returns>
        public SizeSkillModifier GetSizeSkillModifier(int SizeID)
        {
            return GetSingleSizeSkillModifier("Select_SizeSkillModifier", " SizeID=" + SizeID.ToString(), "");
            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "Select_SizeSkillModifier";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, " SizeID=" + SizeID.ToString(), 1000));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, "", 1000));
            //    result = command.ExecuteReader();
            //    if (result.HasRows)
            //    {
            //        result.Read();
            //        SetReaderToObject(ref result);
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
            //return this;

        }

        /// <summary>
        /// Gets the size skill modifier.
        /// </summary>
        /// <param name="SizeID">The size identifier.</param>
        /// <returns>SizeSkillModifier object</returns>
        public SizeSkillModifier GetSizeSkillModifier(int SizeID, int SkillID, int ModifierID)
        {
            return GetSingleSizeSkillModifier("Select_SizeSkillModifier", " SizeID=" + SizeID.ToString() + " AND SkillID=" + SkillID.ToString() + " AND ModifierID=" + ModifierID.ToString(), "");
        }

        /// <summary>
        /// Gets the size skill modifiers.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of SizeSkillModifier objects</returns>
        public List<SizeSkillModifier> GetSizeSkillModifiers(string strWhere, string strOrderBy)
        {
            return GetSizeSkillModifierList("Select_SizeSkillModifier", strWhere, strOrderBy);
            //List<SizeSkillModifier> SizeSkillModifiers = new List<SizeSkillModifier>();

            //SqlDataReader result;
            //DatabaseConnection dbconn = new DatabaseConnection();
            //SqlCommand command = new SqlCommand();
            //SqlConnection connection = new SqlConnection(dbconn.SQLSEVERConnString);

            //try
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.CommandText = "Select_SizeSkillModifier";
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strWhere", SqlDbType.VarChar, strWhere, 1000));
            //    command.Parameters.Add(dbconn.GenerateParameterObj("@strOrderBy", SqlDbType.VarChar, strOrderBy, 1000));
            //    result = command.ExecuteReader();

            //    while (result.Read())
            //    {
            //        SizeSkillModifier objSizeSkillModifier = new SizeSkillModifier();
            //        SetReaderToObject(ref objSizeSkillModifier, ref result);
            //        SizeSkillModifiers.Add(objSizeSkillModifier);
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
            //return SizeSkillModifiers;
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            //if (string.IsNullOrEmpty(this.FeatName))
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Feat Name cannot be blank or null.");
            //}
            return this.Validated;
        }

        /// <summary>
        /// Clones the specified object SizeSkillModifier.
        /// </summary>
        /// <param name="objSizeSkillModifier">The object SizeSkillModifier.</param>
        /// <returns>SizeSkillModifier</returns>
        static public SizeSkillModifier Clone(SizeSkillModifier objSizeSkillModifier)
        {
            SizeSkillModifier objCSizeSkillModifier = new SizeSkillModifier(objSizeSkillModifier.SizeID, objSizeSkillModifier.SkillID, objSizeSkillModifier.ModifierID );
            return objCSizeSkillModifier;
        }

        /// <summary>
        /// Clones the specified LST SizeSkillModifier.
        /// </summary>
        /// <param name="lstSizeSkillModifier">The LST SizeSkillModifier.</param>
        /// <returns>List<SizeSkillModifier></returns>
        static public List<SizeSkillModifier> Clone(List<SizeSkillModifier> lstSizeSkillModifier)
        {
            List<SizeSkillModifier> lstCSizeSkillModifier = new List<SizeSkillModifier>();

            foreach (SizeSkillModifier objSizeSkillModifier in lstSizeSkillModifier)
            {
                lstCSizeSkillModifier.Add(SizeSkillModifier.Clone(objSizeSkillModifier));
            }

            return lstCSizeSkillModifier;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single size skill modifier.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>SizeSkillModifier object</returns>
        private SizeSkillModifier GetSingleSizeSkillModifier(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the size skill modifier list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of SizeSkillModifier objects</returns>
        private List<SizeSkillModifier> GetSizeSkillModifierList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<SizeSkillModifier> sizeSkillModifiers = new List<SizeSkillModifier>();

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
                    SizeSkillModifier objSizeSkillModifier = new SizeSkillModifier();
                    SetReaderToObject(ref objSizeSkillModifier, ref result);
                    sizeSkillModifiers.Add(objSizeSkillModifier);
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
            return sizeSkillModifiers;
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
                this.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                this.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));

                Skill objSkill = new Skill();
                Modifier objModifier = new Modifier();

                this.objSkill = objSkill.GetSkill(this.SkillID );
                this.objModifier = objModifier.GetModifier(this.ModifierID);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objSizeSkillModifier">The object size skill modifier.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SizeSkillModifier objSizeSkillModifier, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objSizeSkillModifier.SizeID = (int)result.GetValue(result.GetOrdinal("SizeID"));
                objSizeSkillModifier.SkillID = (int)result.GetValue(result.GetOrdinal("SkillID"));
                objSizeSkillModifier.ModifierID = (int)result.GetValue(result.GetOrdinal("ModifierID"));

                Skill objSkill = new Skill();
                Modifier objModifier = new Modifier();

                objSizeSkillModifier.objSkill = objSkill.GetSkill(objSizeSkillModifier.SkillID);
                objSizeSkillModifier.objModifier = objModifier.GetModifier(objSizeSkillModifier.ModifierID);

            }
        }
        #endregion
        #endregion
    }
}
