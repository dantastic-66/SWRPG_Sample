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
    public class Class : BaseValidation
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
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is prestige.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is prestige; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrestige { get; set; }
        /// <summary>
        /// Gets or sets the starting skills.
        /// </summary>
        /// <value>
        /// The starting skills.
        /// </value>
        public int StartingSkills { get; set; }
        /// <summary>
        /// Gets or sets the starting skill number.
        /// </summary>
        /// <value>
        /// The starting skill number.
        /// </value>
        public int StartingSkillNumber { get; set; }
        /// <summary>
        /// Gets or sets the type of the hit die.
        /// </summary>
        /// <value>
        /// The type of the hit die.
        /// </value>
        public int HitDieType { get; set; }
        /// <summary>
        /// Gets or sets the start credit die.
        /// </summary>
        /// <value>
        /// The start credit die.
        /// </value>
        public int StartCreditDie { get; set; }
        /// <summary>
        /// Gets or sets the start credit die number.
        /// </summary>
        /// <value>
        /// The start credit die number.
        /// </value>
        public int StartCreditDieNumber { get; set; }
        /// <summary>
        /// Gets or sets the start credit die modifier.
        /// </summary>
        /// <value>
        /// The start credit die modifier.
        /// </value>
        public int StartCreditDieModifier { get; set; }
        /// <summary>
        /// Gets or sets the prestige required talents.
        /// </summary>
        /// <value>
        /// The prestige required talents.
        /// </value>
        public int PrestigeRequiredTalents { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [prestige required force tech].
        /// </summary>
        /// <value>
        /// <c>true</c> if [prestige required force tech]; otherwise, <c>false</c>.
        /// </value>
        public bool PrestigeRequiredForceTech { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [prestige required darkside].
        /// </summary>
        /// <value>
        /// <c>true</c> if [prestige required darkside]; otherwise, <c>false</c>.
        /// </value>
        public bool PrestigeRequiredDarkside { get; set; }
        /// <summary>
        /// Gets or sets the prestige required feats.
        /// </summary>
        /// <value>
        /// The prestige required feats.
        /// </value>
        public int PrestigeRequiredFeats { get; set; }
        /// <summary>
        /// Gets or sets the prestige required base attack.
        /// </summary>
        /// <value>
        /// The prestige required base attack.
        /// </value>
        public int PrestigeRequiredBaseAttack { get; set; }
        /// <summary>
        /// Gets or sets the prestige required level.
        /// </summary>
        /// <value>
        /// The prestige required level.
        /// </value>
        public int PrestigeRequiredLevel { get; set; }

        /// <summary>
        /// Gets or sets the starting feats.
        /// </summary>
        /// <value>
        /// The starting feats.
        /// </value>
        public List<Feat> StartingFeats { get; set; }
        /// <summary>
        /// Gets or sets the object class defense types.
        /// </summary>
        /// <value>
        /// The object class defense types.
        /// </value>
        public List<ClassDefenseType> objClassDefenseTypes { get; set; }
        /// <summary>
        /// Gets or sets the object prestige requirement.
        /// </summary>
        /// <value>
        /// The object prestige requirement.
        /// </value>
        public List<PrestigeRequirement> objPrestigeRequirement { get; set; }
        /// <summary>
        /// Gets or sets the object prestige required talent tree.
        /// </summary>
        /// <value>
        /// The object prestige required talent tree.
        /// </value>
        public List<TalentTree> objPrestigeRequiredTalentTree { get; set; }
        /// <summary>
        /// Gets or sets the object prestige required feats.
        /// </summary>
        /// <value>
        /// The object prestige required feats.
        /// </value>
        public List<Feat> objPrestigeRequiredFeats { get; set; }
        /// <summary>
        /// Gets or sets the object prestige required feat group.
        /// </summary>
        /// <value>
        /// The object prestige required feat group.
        /// </value>
        public List<Feat> objPrestigeRequiredFeatGroup { get; set; }
        /// <summary>
        /// Gets or sets the object prestige required talents.
        /// </summary>
        /// <value>
        /// The object prestige required talents.
        /// </value>
        public List<Talent> objPrestigeRequiredTalents { get; set; }
        /// <summary>
        /// Gets or sets the object prestige required force powers.
        /// </summary>
        /// <value>
        /// The object prestige required force powers.
        /// </value>
        public List<ForcePower> objPrestigeRequiredForcePowers { get; set; }
        //public List<ClassLevelInfo> objClassLevelInfos { get; set; }
        /// <summary>
        /// Gets or sets the object prestige required skills.
        /// </summary>
        /// <value>
        /// The object prestige required skills.
        /// </value>
        public List<Skill> objPrestigeRequiredSkills { get; set; }
        /// <summary>
        /// Gets or sets the object prestige required races.
        /// </summary>
        /// <value>
        /// The object prestige required races.
        /// </value>
        public List<Race> objPrestigeRequiredRaces { get; set; }
        #endregion
        
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Class"/> class.
        /// </summary>
        public Class()
		{
            SetBaseConstructorOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Class"/> class.
        /// </summary>
        /// <param name="ClassName">Name of the Class.</param>
        public Class(string ClassName)
        {
            SetBaseConstructorOptions();
            GetClass(ClassName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Class"/> class.
        /// </summary>
        /// <param name="ClassID">The Class identifier.</param>
        public Class(int ClassID)
        {
            SetBaseConstructorOptions();
            GetClass(ClassID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the class.
        /// </summary>
        /// <param name="ClassID">The class identifier.</param>
        /// <returns>Class Object</returns>
        public Class GetClass(int ClassID)
        {
            return GetSingleClass("Select_Class", "  ClassID=" + ClassID.ToString(), "");
        }

        /// <summary>
        /// Gets the class.
        /// </summary>
        /// <param name="ClassName">Name of the class.</param>
        /// <returns>Class Object</returns>
        public Class GetClass(string ClassName)
        {
            return GetSingleClass("Select_Class", "  ClassName='" + ClassName + "'", "");
        }

        /// <summary>
        /// Gets the classes.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Class Objects</returns>
        public List<Class> GetClasses(string strWhere, string strOrderBy)
        {
            return GetClassList("Select_Class", strWhere, strOrderBy);
        }

        /// <summary>
        /// Saves the class.
        /// </summary>
        /// <returns>Class Object</returns>
        public Class SaveClass()
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
                command.CommandText = "InsertUpdate_Class";

                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, ClassID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassName", SqlDbType.VarChar, ClassName.ToString(), 1000));
                command.Parameters.Add(dbconn.GenerateParameterObj("@IsPrestige", SqlDbType.Bit , IsPrestige.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StartingSkills", SqlDbType.Int, StartingSkills.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@HitDieType", SqlDbType.Int, HitDieType.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StartCreditDie", SqlDbType.Int, StartCreditDie.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StartCreditDieNumber", SqlDbType.Int, StartCreditDieNumber.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StartingSkillNumber", SqlDbType.Int, StartingSkillNumber.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@StartCreditDieModifier", SqlDbType.Int, StartCreditDieModifier.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequiredTalents", SqlDbType.Int, PrestigeRequiredTalents.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequiredForceTech", SqlDbType.Int, PrestigeRequiredForceTech.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequiredDarkside", SqlDbType.Int, PrestigeRequiredDarkside.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequiredFeats", SqlDbType.Int, PrestigeRequiredFeats.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequiredBaseAttack", SqlDbType.Int, PrestigeRequiredBaseAttack.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@PrestigeRequiredLevel", SqlDbType.Int, PrestigeRequiredLevel.ToString(), 0));

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
        /// Delete the Class.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool DeleteClass()
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
                command.CommandText = "Delete_Class";
                command.Parameters.Add(dbconn.GenerateParameterObj("@ClassID", SqlDbType.Int, ClassID.ToString(), 0));
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
        /// Gets the feat prerequisite class.
        /// </summary>
        /// <param name="FeatID">The feat identifier.</param>
        /// <returns>List of Class Objects</returns>
        public List<Class> GetFeatPrerequisiteClass(int FeatID)
        {
            //otmFeatPrequisiteClass
            return GetClassList("Select_FeatPrerequisiteClass", "  FeatID=" + FeatID.ToString(), "ClassName");
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.ClassName))
            {
                this._validated = false;
                this._validationMessage.Append("The Class Name cannot be blank or null.");
            }
            return this.Validated;
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Determines whether [is class in list] [the specified object class].
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <param name="lstClass">The LST class.</param>
        /// <returns>Boolean</returns>
        static public bool IsClassInList(Class objClass, List<Class> lstClass)
        {
            bool blnClassFound = false;

            foreach (Class lstObjClass in lstClass)
            {
                if (objClass.ClassID == lstObjClass.ClassID)
                {
                    blnClassFound = true;
                }
            }

            return blnClassFound;
        }

        /// <summary>
        /// Determines whether [is class in list] [the specified LST need classs].
        /// </summary>
        /// <param name="lstNeedClasss">The LST need classs.</param>
        /// <param name="lstClasss">The LST classs.</param>
        /// <returns>Boolean</returns>
        static public bool IsClassInList(List<Class> lstNeedClasss, List<Class> lstClasss)
        {
            bool blnAllClasssFound = true;
            bool blnClassFound = false;

            foreach (Class objNeededClass in lstNeedClasss)
            {
                foreach (Class objClass in lstClasss)
                {
                    if (objNeededClass.ClassID == objClass.ClassID)
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
        /// Clones the specified object Class.
        /// </summary>
        /// <param name="objClass">The object Class.</param>
        /// <returns>Class</returns>
        static public Class Clone(Class objClass)
        {
            Class objCClass = new Class(objClass.ClassID);
            return objCClass;
        }

        /// <summary>
        /// Clones the specified LST Class.
        /// </summary>
        /// <param name="lstClass">The LST Class.</param>
        /// <returns>List<Class></returns>
        static public List<Class> Clone(List<Class> lstClass)
        {
            List<Class> lstCClass = new List<Class>();

            foreach (Class objClass in lstClass)
            {
                lstCClass.Add(Class.Clone(objClass));
            }

            return lstCClass;
        }

        static public int GetMaximumDefenseValuesForClassList(List<Class> lstClass, string strDefenseType)
        {
            int ReturnVal = 0;

            foreach (Class objClass in lstClass)
            {
                foreach (ClassDefenseType objClassDefenseType in objClass.objClassDefenseTypes)
                {
                    if (objClassDefenseType.objDefenseType.DefenseTypeDescription.ToLower() == strDefenseType.ToLower())
                    {
                        //if its positive, then check it.  Else 0 is higher
                        if (objClassDefenseType.objModifier.ModifierPositive)
                        {
                            //Check to see if the number is greater than the current adjustment
                            if (objClassDefenseType.objModifier.ModifierNumber > ReturnVal)
                            {
                                //if it is then replace it.
                                ReturnVal = objClassDefenseType.objModifier.ModifierNumber;
                            }
                        }
                    }

                }
            }
            return ReturnVal;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the single class.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Class Object</returns>
        private Class GetSingleClass(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the class list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Class Objects</returns>
        private List<Class> GetClassList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Class> classes = new List<Class>();

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
                    Class objClass = new Class();
                    SetReaderToObject(ref objClass, ref result);
                    classes.Add(objClass);
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
            return classes;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));
                this.IsPrestige = (bool)result.GetValue(result.GetOrdinal("IsPrestige"));
                this.ClassName = result.GetValue(result.GetOrdinal("ClassName")).ToString();
                this.HitDieType = (int)result.GetValue(result.GetOrdinal("HitDieType"));
                this.StartingSkillNumber = (int)result.GetValue(result.GetOrdinal("StartingSkillNumber"));
                
                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartingSkills")).ToString()))
                {
                    this.StartingSkills = (int)result.GetValue(result.GetOrdinal("StartingSkills"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartCreditDie")).ToString()))
                {
                    this.StartCreditDie = (int)result.GetValue(result.GetOrdinal("StartCreditDie"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartCreditDieNumber")).ToString()))
                {
                    this.StartCreditDieNumber = (int)result.GetValue(result.GetOrdinal("StartCreditDieNumber"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartCreditDieModifier")).ToString()))
                {
                    this.StartCreditDieModifier = (int)result.GetValue(result.GetOrdinal("StartCreditDieModifier"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredTalents")).ToString()))
                {
                    this.PrestigeRequiredTalents = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredTalents"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredForceTech")).ToString()))
                {
                    this.PrestigeRequiredForceTech = (bool)result.GetValue(result.GetOrdinal("PrestigeRequiredForceTech"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredDarkside")).ToString()))
                {
                    this.PrestigeRequiredDarkside = (bool)result.GetValue(result.GetOrdinal("PrestigeRequiredDarkside"));
                }
                
                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredFeats")).ToString()))
                {
                    this.PrestigeRequiredFeats = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredFeats"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredBaseAttack")).ToString()))
                {
                    this.PrestigeRequiredBaseAttack = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredBaseAttack"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredLevel")).ToString()))
                {
                    this.PrestigeRequiredLevel = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredLevel"));
                }
                this._objComboBoxData.Clear();
                this._objComboBoxData.Add(this.ClassID, this.ClassName);
            }

            if (this.IsPrestige)
            {
                Feat objFeat = new Feat();
                ClassDefenseType objClassDefenseTypes = new ClassDefenseType();
                PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
                TalentTree objTalentTree = new TalentTree();
                Talent objTalent = new Talent();
                ForcePower objForcePower = new ForcePower();
                Skill objSkill = new Skill();
                Race objRace = new Race();
                //ClassLevelInfo objClassLevelInfo = new ClassLevelInfo();

                this.StartingFeats = objFeat.GetStartingFeats(" ClassID=" + this.ClassID.ToString(), "FeatName");

                this.objClassDefenseTypes = objClassDefenseTypes.GetClassDefenseTypes(" ClassID=" + this.ClassID.ToString(), "");

                this.objPrestigeRequirement = objPrestigeRequirement.GetPrestigeRequirementPrestigeClass(" ClassID=" + this.ClassID.ToString(), "PrestigeRequirementDescription");

                this.objPrestigeRequiredTalentTree = objTalentTree.GetTalentTreesPrestigeClass("ClassID=" + this.ClassID.ToString(), "TalentTreeName");

                this.objPrestigeRequiredTalents = objTalent.GetPrestigeRequiredTalents("ClassID=" + this.ClassID.ToString(), "TalentName");

                this.objPrestigeRequiredFeats = objFeat.GetPrestigeRequiredFeats(" ClassID=" + this.ClassID.ToString(), "FeatName");

                this.objPrestigeRequiredFeatGroup = objFeat.GetPrestigeRequiredFeatGroups(" ClassID=" + this.ClassID.ToString(), "FeatName");

                this.objPrestigeRequiredForcePowers = objForcePower.GetPrestigeRequiredForcePowers(" ClassID=" + this.ClassID.ToString(), "ForcePowerName");

                this.objPrestigeRequiredSkills = objSkill.GetPrestigeRequiredSkills(" ClassID=" + this.ClassID.ToString(), "SkillName");

                this.objPrestigeRequiredRaces = objRace.GetRaceRequirementForClass(" mtmPrestigeRequirementClassRace.ClassID=" + this.ClassID.ToString(), "RaceName");
               
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objClass">The object class.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Class objClass, ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                objClass.ClassID = (int)result.GetValue(result.GetOrdinal("ClassID"));
                objClass.IsPrestige = (bool)result.GetValue(result.GetOrdinal("IsPrestige"));
                objClass.ClassName = result.GetValue(result.GetOrdinal("ClassName")).ToString();
                objClass.HitDieType = (int)result.GetValue(result.GetOrdinal("HitDieType"));
                objClass.StartingSkillNumber = (int)result.GetValue(result.GetOrdinal("StartingSkillNumber"));

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartingSkills")).ToString()))
                {
                    objClass.StartingSkills = (int)result.GetValue(result.GetOrdinal("StartingSkills"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartCreditDie")).ToString()))
                {
                    objClass.StartCreditDie = (int)result.GetValue(result.GetOrdinal("StartCreditDie"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartCreditDieNumber")).ToString()))
                {
                    objClass.StartCreditDieNumber = (int)result.GetValue(result.GetOrdinal("StartCreditDieNumber"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("StartCreditDieModifier")).ToString()))
                {
                    objClass.StartCreditDieModifier = (int)result.GetValue(result.GetOrdinal("StartCreditDieModifier"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredTalents")).ToString()))
                {
                    objClass.PrestigeRequiredTalents = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredTalents"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredForceTech")).ToString()))
                {
                    objClass.PrestigeRequiredForceTech = (bool)result.GetValue(result.GetOrdinal("PrestigeRequiredForceTech"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredDarkside")).ToString()))
                {
                    objClass.PrestigeRequiredDarkside = (bool)result.GetValue(result.GetOrdinal("PrestigeRequiredDarkside"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredFeats")).ToString()))
                {
                    objClass.PrestigeRequiredFeats = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredFeats"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredBaseAttack")).ToString()))
                {
                    objClass.PrestigeRequiredBaseAttack = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredBaseAttack"));
                }

                if (!string.IsNullOrEmpty(result.GetValue(result.GetOrdinal("PrestigeRequiredLevel")).ToString()))
                {
                    objClass.PrestigeRequiredLevel = (int)result.GetValue(result.GetOrdinal("PrestigeRequiredLevel"));
                }
                objClass._objComboBoxData.Clear();
                objClass._objComboBoxData.Add(objClass.ClassID, objClass.ClassName);
            }
            if (objClass.IsPrestige)
            {
                Feat objFeat = new Feat(); ;
                ClassDefenseType objClassDefenseTypes = new ClassDefenseType();
                PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
                TalentTree objTalentTree = new TalentTree();
                Talent objTalent = new Talent();
                ForcePower objForcePower = new ForcePower();
                Skill objSkill = new Skill();
                Race objRace = new Race();

                objClass.StartingFeats = objFeat.GetStartingFeats(" ClassID=" + objClass.ClassID.ToString(), "FeatName");

                objClass.objClassDefenseTypes = objClassDefenseTypes.GetClassDefenseTypes(" ClassID=" + objClass.ClassID.ToString(), "");

                objClass.objPrestigeRequirement = objPrestigeRequirement.GetPrestigeRequirementPrestigeClass(" ClassID=" + objClass.ClassID.ToString(), "PrestigeRequirementDescription");

                objClass.objPrestigeRequiredTalentTree = objTalentTree.GetTalentTreesPrestigeClass("ClassID=" + objClass.ClassID.ToString(), "TalentTreeName");

                objClass.objPrestigeRequiredTalents = objTalent.GetPrestigeRequiredTalents("ClassID=" + objClass.ClassID.ToString(), "TalentName");

                objClass.objPrestigeRequiredFeats = objFeat.GetPrestigeRequiredFeats(" ClassID=" + objClass.ClassID.ToString(), "FeatName");

                objClass.objPrestigeRequiredFeatGroup = objFeat.GetPrestigeRequiredFeatGroups(" ClassID=" + objClass.ClassID.ToString(), "FeatName");

                objClass.objPrestigeRequiredForcePowers = objForcePower.GetPrestigeRequiredForcePowers(" ClassID=" + objClass.ClassID.ToString(), "ForcePowerName");

                objClass.objPrestigeRequiredSkills = objSkill.GetPrestigeRequiredSkills(" ClassID=" + objClass.ClassID.ToString(), "SkillName");

                objClass.objPrestigeRequiredRaces = objRace.GetRaceRequirementForClass(" mtmPrestigeRequirementClassRace.ClassID=" + objClass.ClassID.ToString(), "RaceName");
            }
        }
        #endregion
        #endregion
    }
}
