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
    public class ClassLevelInfo : BaseValidation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the class level identifier.
        /// </summary>
        /// <value>
        /// The class level identifier.
        /// </value>
        public int ClassLevelID { get; set; }
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>
        /// The class identifier.
        /// </value>
        public int ClassID { get; set; }
        /// <summary>
        /// Gets or sets the class level.
        /// </summary>
        /// <value>
        /// The class level.
        /// </value>
        public int ClassLevel { get; set; }
        /// <summary>
        /// Gets or sets the bonus feat.
        /// </summary>
        /// <value>
        /// The bonus feat.
        /// </value>
        public int BonusFeat { get; set; }
        /// <summary>
        /// Gets or sets the talent.
        /// </summary>
        /// <value>
        /// The talent.
        /// </value>
        public int Talent { get; set; }
        /// <summary>
        /// Gets or sets the base attack.
        /// </summary>
        /// <value>
        /// The base attack.
        /// </value>
        public int BaseAttack { get; set; }
        /// <summary>
        /// Gets or sets the force point base.
        /// </summary>
        /// <value>
        /// The force point base.
        /// </value>
        public int ForcePointBase { get; set; }
        /// <summary>
        /// Gets or sets the force technique.
        /// </summary>
        /// <value>
        /// The force technique.
        /// </value>
        public int ForceTechnique { get; set; }
        /// <summary>
        /// Gets or sets the force secret.
        /// </summary>
        /// <value>
        /// The force secret.
        /// </value>
        public int ForceSecret { get; set; }
        /// <summary>
        /// Gets or sets the Medical secret.
        /// </summary>
        /// <value>
        /// The Medical secret.
        /// </value>
        public int MedicalSecret { get; set; }
        //TODO: Get ExtraClassLevelItem, PrestigeClassSkill ExtraClassLevelItem after making the classes
        //PrestigeClassSkill from otmClassLevelPrestigeClassSkill
        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public Class Class{ get; set; }
        /// <summary>
        /// Gets or sets the object extra class item.
        /// </summary>
        /// <value>
        /// The object extra class item.
        /// </value>
        public ExtraClassItem objExtraClassItem { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassLevelInfo"/> class.
        /// </summary>
        public ClassLevelInfo()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassLevelInfo"/> class.
        /// </summary>
        /// <param name="ClassID">The Class identifier.</param>
        /// <param name="ClassLevelID">The ClassLevel identifier.</param>
        public ClassLevelInfo(int ClassID, int ClassLevelID)
        {
            SetBaseConstructorOptions();
            GetClassLevel(ClassID, ClassLevelID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassLevel"/> class.
        /// </summary>
        /// <param name="ClassLevelID">The ClassLevel identifier.</param>
        public ClassLevelInfo(int ClassLevelID)
        {
            SetBaseConstructorOptions();
            GetClassLevel(ClassLevelID);
        }

        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the class level.
        /// </summary>
        /// <param name="ClassLevelID">The class level identifier.</param>
        /// <returns>ClassLevelInfo Object</returns>
        public ClassLevelInfo GetClassLevel(int ClassLevelID)
        {
            return GetSingleClassLevelInfo("Select_ClassLevel", "  ClassLevelID=" + ClassLevelID, "");
        }

        /// <summary>
        /// Gets the class level.
        /// </summary>
        /// <param name="ClassID">ID of the class.</param>
        /// <param name="ClassLevel">Level of the class.</param>
        /// <returns>ClassLevelInfo Object</returns>
        public ClassLevelInfo GetClassLevel(int ClassID, int ClassLevel)
        {
            return GetSingleClassLevelInfo("Select_ClassLevel", "  ClassID=" + ClassID.ToString() + " AND ClassLevel=" + ClassLevel.ToString(), "");
        }

        /// <summary>
        /// Gets the class levels.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ClassLevelInfo Objects</returns>
        public List<ClassLevelInfo> GetClassLevels(string strWhere, string strOrderBy)
        {
            return GetClassLevelInfoList("Select_ClassLevelInfo",strWhere,strOrderBy );
        }


        /// <summary>
        /// Saves the ClassLevelInfo.
        /// </summary>
        /// <returns>ClassLevelInfo Object</returns>
        public ClassLevelInfo SaveClassLevelInfo()
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
                command.CommandText = "InsertUpdate_ClassLevel";

                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassLevelID", SqlDbType.Int, ClassLevelID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, ClassID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassLevel", SqlDbType.Int, ClassLevel.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BonusFeat", SqlDbType.Int, BonusFeat.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Talent", SqlDbType.Int, Talent.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BaseAttack", SqlDbType.Int, BaseAttack.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePointBase", SqlDbType.Int, ForcePointBase.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTechnique", SqlDbType.Int, ForceTechnique.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceSecret", SqlDbType.Int, ForceSecret.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@MedicalSecret", SqlDbType.Int, MedicalSecret.ToString(), 0));

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
        /// Delete the ClassLevelInfo.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteClassLevelInfo()
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
                command.CommandText = "Delete_ClassLevel";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassLevelID", SqlDbType.Int, ClassLevelID.ToString(), 0));
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
            if (this.ClassID == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Class ID cannot be blank/null/0.");
            }
            if (this.ClassLevel == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Class Level cannot be blank/null/0.");
            }
            return this.Validated;
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Determines whether [is class in list] [the specified object class level information].
        /// </summary>
        /// <param name="objClassLevelInfo">The object class level information.</param>
        /// <param name="lstClassLevelInfo">The LST class level information.</param>
        /// <returns>Boolean</returns>
        static public bool IsClassInList(ClassLevelInfo objClassLevelInfo, List<ClassLevelInfo> lstClassLevelInfo)
        {
            bool blnClassFound = false;

            foreach (ClassLevelInfo lstObjClassLevelInfo in lstClassLevelInfo)
            {
                if ((objClassLevelInfo.ClassID == lstObjClassLevelInfo.ClassID) && (objClassLevelInfo.ClassLevel == lstObjClassLevelInfo.ClassLevel))
                {
                    blnClassFound = true;
                }
            }

            return blnClassFound;
        }

        /// <summary>
        /// Determines whether [is class in list] [the specified LST need class level infos].
        /// </summary>
        /// <param name="lstNeedClassLevelInfos">The LST need class level infos.</param>
        /// <param name="lstClassLevelInfos">The LST class level infos.</param>
        /// <returns>Boolean</returns>
        static public bool IsClassInList(List<ClassLevelInfo> lstNeedClassLevelInfos, List<ClassLevelInfo> lstClassLevelInfos)
        {
            bool blnAllClasssFound = true;
            bool blnClassFound = false;

            foreach (ClassLevelInfo objNeedClassLevelInfo in lstNeedClassLevelInfos)
            {
                foreach (ClassLevelInfo objClassLevelInfo in lstClassLevelInfos)
                {
                    if ((objNeedClassLevelInfo.ClassID == objClassLevelInfo.ClassID) && (objNeedClassLevelInfo.ClassLevel  == objClassLevelInfo.ClassLevel ))
                    {
                        blnClassFound = true;
                    }
                }
                if (blnAllClasssFound)
                {
                    blnAllClasssFound = blnClassFound;
                }
            }

            return blnAllClasssFound;
        }

        /// <summary>
        /// Clones the specified object ClassLevelInfo.
        /// </summary>
        /// <param name="objClassLevelInfo">The object ClassLevelInfo.</param>
        /// <returns>ClassLevelInfo</returns>
        static public ClassLevelInfo Clone(ClassLevelInfo objClassLevelInfo)
        {
            ClassLevelInfo objCClassLevelInfo = new ClassLevelInfo(objClassLevelInfo.ClassID ,objClassLevelInfo.ClassLevelID );
            return objCClassLevelInfo;
        }

        /// <summary>
        /// Clones the specified LST ClassLevelInfo.
        /// </summary>
        /// <param name="lstClassLevelInfo">The LST ClassLevelInfo.</param>
        /// <returns>List<ClassLevelInfo></returns>
        static public List<ClassLevelInfo> Clone(List<ClassLevelInfo> lstClassLevelInfo)
        {
            List<ClassLevelInfo> lstCClassLevelInfo = new List<ClassLevelInfo>();

            foreach (ClassLevelInfo objClassLevelInfo in lstClassLevelInfo)
            {
                lstCClassLevelInfo.Add(ClassLevelInfo.Clone(objClassLevelInfo));
            }

            return lstCClassLevelInfo;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single class level information.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>ClassLevelInfo Object</returns>
        private ClassLevelInfo GetSingleClassLevelInfo(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the class level information list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of ClassLevelInfo Objects</returns>
        private List<ClassLevelInfo> GetClassLevelInfoList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<ClassLevelInfo> classLevelInfos = new List<ClassLevelInfo>();

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
                    ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();
                    SetReaderToObject(ref objClassLevelInfo, ref result);
                    classLevelInfos.Add(objClassLevelInfo);
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
            return classLevelInfos;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ClassLevelID = (int)result.GetValue(result.GetOrdinal("ClassLevelID"));
                this.BonusFeat = (int)result.GetValue(result.GetOrdinal("BonusFeat"));
                this.Talent = (int)result.GetValue(result.GetOrdinal("Talent"));
                this.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));
                this.BaseAttack = (int)result.GetValue(result.GetOrdinal("BaseAttack"));
                this.ClassLevel = (int)result.GetValue(result.GetOrdinal("ClassLevel"));
                this.ForcePointBase = (int)result.GetValue(result.GetOrdinal("ForcePointBase"));
                //this.ExtraClassLevelItemID = (int)result.GetValue(result.GetOrdinal("ExtraClassLevelItem"));
                //this.PrestigeClassSkillID = (int)result.GetValue(result.GetOrdinal("PrestigeClassSkillID"));
                //this.PrestigeClassSkillModifier = (int)result.GetValue(result.GetOrdinal("PrestigeClassSkillModifier"));
                this.ForceTechnique = (int)result.GetValue(result.GetOrdinal("ForceTechnique"));
                this.ForceSecret = (int)result.GetValue(result.GetOrdinal("ForceSecret"));
                this.MedicalSecret = (int)result.GetValue(result.GetOrdinal("MedicalSecret"));

                Class objClass = new Class();
                if (!(this.ClassID == 0))
                {
                    objClass.GetClass(this.ClassID);
                }
                this.Class = objClass;
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objClassLevel">The object class level.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref ClassLevelInfo objClassLevel, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objClassLevel.ClassLevelID = (int)result.GetValue(result.GetOrdinal("ClassLevelID"));
                objClassLevel.BonusFeat = (int)result.GetValue(result.GetOrdinal("BonusFeat"));
                objClassLevel.Talent = (int)result.GetValue(result.GetOrdinal("Talent"));
                objClassLevel.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));
                objClassLevel.BaseAttack = (int)result.GetValue(result.GetOrdinal("BaseAttack"));
                objClassLevel.ClassLevel = (int)result.GetValue(result.GetOrdinal("ClassLevel"));
                objClassLevel.ForcePointBase = (int)result.GetValue(result.GetOrdinal("ForcePointBase"));
                //objClassLevel.ExtraClassLevelItemID = (int)result.GetValue(result.GetOrdinal("ExtraClassLevelItem"));
                //objClassLevel.PrestigeClassSkillID = (int)result.GetValue(result.GetOrdinal("PrestigeClassSkillID"));
                //objClassLevel.PrestigeClassSkillModifier = (int)result.GetValue(result.GetOrdinal("PrestigeClassSkillModifier"));
                objClassLevel.ForceTechnique = (int)result.GetValue(result.GetOrdinal("ForceTechnique"));
                objClassLevel.ForceSecret = (int)result.GetValue(result.GetOrdinal("ForceSecret"));
                objClassLevel.MedicalSecret = (int)result.GetValue(result.GetOrdinal("MedicalSecret"));

                Class objClass = new Class();
                if (!(objClassLevel.ClassID == 0))
                {
                    objClass.GetClass(objClassLevel.ClassID);
                }
                objClassLevel.Class = objClass;
            }
        }
        #endregion
        #endregion
    }
}
