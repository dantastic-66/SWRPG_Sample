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
    public class Character : BaseValidation   //, ICloneable 
    {
        #region Properties
        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        public int CharacterID { get; set; }
        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        /// <value>
        /// The name of the character.
        /// </value>
        public string CharacterName { get; set; }
        ///// <summary>
        ///// Gets or sets the strength.
        ///// </summary>
        ///// <value>
        ///// The strength.
        ///// </value>
        //public int Strength { get; set; }
        ///// <summary>
        ///// Gets or sets the strength mod.
        ///// </summary>
        ///// <value>
        ///// The strength mod.
        ///// </value>
        //public int StrengthMod { get; set; }
        ///// <summary>
        ///// Gets or sets the intelligence.
        ///// </summary>
        ///// <value>
        ///// The intelligence.
        ///// </value>
        //public int Intelligence { get; set; }
        ///// <summary>
        ///// Gets or sets the intelligence mod.
        ///// </summary>
        ///// <value>
        ///// The intelligence mod.
        ///// </value>
        //public int IntelligenceMod { get; set; }
        ///// <summary>
        ///// Gets or sets the wisdom.
        ///// </summary>
        ///// <value>
        ///// The wisdom.
        ///// </value>
        //public int Wisdom { get; set; }
        ///// <summary>
        ///// Gets or sets the wisdom mod.
        ///// </summary>
        ///// <value>
        ///// The wisdom mod.
        ///// </value>
        //public int WisdomMod { get; set; }
        ///// <summary>
        ///// Gets or sets the dexterity.
        ///// </summary>
        ///// <value>
        ///// The dexterity.
        ///// </value>
        //public int Dexterity { get; set; }
        ///// <summary>
        ///// Gets or sets the dexterity mod.
        ///// </summary>
        ///// <value>
        ///// The dexterity mod.
        ///// </value>
        //public int DexterityMod { get; set; }
        ///// <summary>
        ///// Gets or sets the constitution.
        ///// </summary>
        ///// <value>
        ///// The constitution.
        ///// </value>
        //public int Constitution { get; set; }
        ///// <summary>
        ///// Gets or sets the constitution mod.
        ///// </summary>
        ///// <value>
        ///// The constitution mod.
        ///// </value>
        //public int ConstitutionMod { get; set; }
        ///// <summary>
        ///// Gets or sets the charisma.
        ///// </summary>
        ///// <value>
        ///// The charisma.
        ///// </value>
        //public int Charisma { get; set; }
        ///// <summary>
        ///// Gets or sets the charisma mod.
        ///// </summary>
        ///// <value>
        ///// The charisma mod.
        ///// </value>
        //public int CharismaMod { get; set; }

        ///// <summary>
        ///// Gets or sets the fortitude defense identifier.
        ///// </summary>
        ///// <value>
        ///// The fortitude defense identifier.
        ///// </value>
        //public int FortitudeDefenseID { get; set; }
        ///// <summary>
        ///// Gets or sets the reflex defense identifier.
        ///// </summary>
        ///// <value>
        ///// The reflex defense identifier.
        ///// </value>
        //public int ReflexDefenseID { get; set; }
        ///// <summary>
        ///// Gets or sets the will defense identifier.
        ///// </summary>
        ///// <value>
        ///// The will defense identifier.
        ///// </value>
        //public int WillDefenseID { get; set; }
        /// <summary>
        /// Gets or sets the character level identifier.
        /// </summary>
        /// <value>
        /// The character level identifier.
        /// </value>
        public int CharacterLevelID { get; set; }
        /// <summary>
        /// Gets or sets the race identifier.
        /// </summary>
        /// <value>
        /// The race identifier.
        /// </value>
        public int RaceID { get; set; }

        /// <summary>
        /// Gets or sets the experience points.
        /// </summary>
        /// <value>
        /// The experience points.
        /// </value>
        public int ExperiencePoints { get; set; }
        /// <summary>
        /// Gets or sets the hit points.
        /// </summary>
        /// <value>
        /// The hit points.
        /// </value>
        public int HitPoints { get; set; }
        ///// <summary>
        ///// Gets or sets the movement.
        ///// </summary>
        ///// <value>
        ///// The movement.
        ///// </value>
        //public int Movement { get; set; }
        /// <summary>
        /// Gets or sets the force points.
        /// </summary>
        /// <value>
        /// The force points.
        /// </value>
        public int ForcePoints { get; set; }
        /// <summary>
        /// Gets or sets the destinty points.
        /// </summary>
        /// <value>
        /// The destinty points.
        /// </value>
        public int DestintyPoints { get; set; }
        /// <summary>
        /// Gets or sets the dark side points.
        /// </summary>
        /// <value>
        /// The dark side points.
        /// </value>
        public int DarkSidePoints { get; set; }
        /// <summary>
        /// Gets or sets the base attack.
        /// </summary>
        /// <value>
        /// The base attack.
        /// </value>
        public int BaseAttack { get; set; }
        /// <summary>
        /// Gets or sets the grapple.
        /// </summary>
        /// <value>
        /// The grapple.
        /// </value>
        public int Grapple { get; set; }
        /// <summary>
        /// Gets or sets the damage threshold.
        /// </summary>
        /// <value>
        /// The damage threshold.
        /// </value>
        public int DamageThreshold { get; set; }
        /// <summary>
        /// Gets or sets the encumberance.
        /// </summary>
        /// <value>
        /// The encumberance.
        /// </value>
        public int Encumberance { get; set; }
        /// <summary>
        /// Gets or sets the condition track identifier.
        /// </summary>
        /// <value>
        /// The condition track identifier.
        /// </value>
        public int ConditionTrackID { get; set; }
        /// <summary>
        /// Gets or sets the character age.
        /// </summary>
        /// <value>
        /// The character age.
        /// </value>
        public int? CharacterAge { get; set; }
        /// <summary>
        /// Gets or sets the armor identifier.
        /// </summary>
        /// <value>
        /// The armor identifier.
        /// </value>
        public int ArmorID { get; set; }
        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public string Sex { get; set; }

        public decimal Height { get; set; }

        public int Weight { get; set; }

        public int Credits {get;set;}

        public int ForceTraditionID { get; set; }

        public bool ForceSensitive
        {
            get
            {
                bool isForceSenstive = false;
                if (this.lstFeats.Count > 0)
                {
                    foreach (Feat objFeat in lstFeats)
                    {
                        if (objFeat.FeatID ==1)
                        {
                            isForceSenstive = true;
                        }
                    }
                }
                return isForceSenstive;
            }
        }

        public int LastClassLevelID { get; set; }

        public decimal? CarryingCapacity { get; set; }

        public List<CharacterAbility> lstCharacterAbilities { get; set; }
        /// <summary>
        /// Gets or sets the object equipment list.
        /// </summary>
        /// <value>
        /// The object equipment list.
        /// </value>
        public List<CharacterEquipment> lstEquipmentList { get; set; }
        /// <summary>
        /// Gets or sets the object character class levels.
        /// </summary>
        /// <value>
        /// The object character class levels.
        /// </value>
        public List<CharacterClassLevel> lstCharacterClassLevels { get; set; }
        /// <summary>
        /// Gets or sets the object feats.
        /// </summary>
        /// <value>
        /// The object feats.
        /// </value>
        public List<Feat> lstFeats { get; set; }
        /// <summary>
        /// Gets or sets the object languages.
        /// </summary>
        /// <value>
        /// The object languages.
        /// </value>
        public List<Language> lstLanguages { get; set; }
        /// <summary>
        /// Gets or sets the object character skills.
        /// </summary>
        /// <value>
        /// The object character skills.
        /// </value>
        public List<CharacterSkill> lstCharacterSkills { get; set; }
        /// <summary>
        /// Gets or sets the object talents.
        /// </summary>
        /// <value>
        /// The object talents.
        /// </value>
        public List<Talent> lstTalents { get; set; }
        /// <summary>
        /// Gets or sets the object weapons.
        /// </summary>
        /// <value>
        /// The object weapons.
        /// </value>
        public List<CharacterWeapon> lstCharacterWeapons { get; set; }
        /// <summary>
        /// Gets or sets the object prestige requirement.
        /// </summary>
        /// <value>
        /// The object prestige requirement.
        /// </value>
        public List<PrestigeRequirement> lstPrestigeRequirement { get; set; }
        /// <summary>
        /// Gets or sets the object defenses.
        /// </summary>
        /// <value>
        /// The object defenses.
        /// </value>
        public List<CharacterDefense> lstDefenses { get; set; }
        /// <summary>
        /// Gets or sets the object force powers.
        /// </summary>
        /// <value>
        /// The object force powers.
        /// </value>
        public List<ForcePower> lstForcePowers { get; set; }
        /// <summary>
        /// Gets or sets the object character levels.
        /// </summary>
        /// <value>
        /// The object character levels.
        /// </value>
        public List<CharacterLevel> lstCharacterLevels { get; set; }

        public List<Organization> lstCharacterOrganizations { get; set; }

        public List<CharacterArmor> lstCharacterArmors { get; set; }

        public List<Speed> lstCharacterSpeeds { get; set; }

        /// <summary>
        /// Gets or sets the object race.
        /// </summary>
        /// <value>
        /// The object race.
        /// </value>
        public Race objRace { get; set; }
        #endregion
        
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        public Character()
		{
            SetBaseConstructorOptions();
            lstCharacterAbilities = new List<CharacterAbility>();
            lstEquipmentList = new List<CharacterEquipment>  ();
            lstCharacterClassLevels = new  List<CharacterClassLevel>  ();
            lstFeats = new List<Feat>  ();
            lstLanguages = new List<Language>  ();
            lstCharacterSkills= new List<CharacterSkill>  ();
            lstTalents= new List<Talent>  ();
            lstCharacterWeapons= new List<CharacterWeapon>  ();
            lstPrestigeRequirement= new List<PrestigeRequirement>  ();
            lstDefenses= new List<CharacterDefense>  ();
            lstForcePowers= new List<ForcePower>  ();
            lstCharacterLevels= new List<CharacterLevel>  ();
            lstCharacterOrganizations= new List<Organization>  ();
            lstCharacterWeapons = new List<CharacterWeapon>();
            lstCharacterArmors = new List<CharacterArmor>();
            lstCharacterSpeeds = new List<Speed>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="CharacterID">The Character identifier.</param>
        public Character(int CharacterID)
        {
            SetBaseConstructorOptions();
            GetCharacter(CharacterID);
        }
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Gets the character.
        /// </summary>
        /// <param name="CharacterID">The character identifier.</param>
        /// <returns>Character Object</returns>
        public Character GetCharacter(int CharacterID)
        {
            return GetSingleCharacter("Select_Character", " CharacterID=" + CharacterID, "");
        }

        /// <summary>
        /// Gets the characters.
        /// </summary>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderby">The string orderby.</param>
        /// <returns>List of Character Objects</returns>
        public List<Character> GetCharacters(string strWhere, string strOrderby)
        {
            return GetCharacterList("Select_Character", strWhere, strOrderby);
        }

        /// <summary>
        /// Qualifieds the feat list.
        /// </summary>
        /// <param name="objFeats">The object feats.</param>
        /// <returns>List of Feat Objects Character qualified for </returns>
        public List<Feat> QualifiedFeatList(List<Feat> objFeats)
        {
            List<Feat> QualifiedFeatList = new List<Feat>();
            List<Feat> GoodFeatList = new List<Feat>();
            
            foreach (Feat objFeat in objFeats)
            {
                if (QualifiedForFeat(objFeat)) QualifiedFeatList.Add(objFeat);
            }
            return RemoveCharcterPossessedFeatsFromList(QualifiedFeatList);
        }

        /// <summary>
        /// Removes the charcter possessed feats from list.
        /// </summary>
        /// <param name="objFeatList">The object feat list.</param>
        /// <returns>List of Feat Objects</returns>
        public List<Feat > RemoveCharcterPossessedFeatsFromList(List<Feat> objFeatList)
        {
            List<Feat> GoodFeatList = new List<Feat>();
            int intFeatCount = 0;

            foreach (Feat objFeat in objFeatList)
            {
                if (objFeat.MultipleSelection == 0)
                {
                    if (!this.lstFeats.Contains(objFeat)) GoodFeatList.Add(objFeat);
                }
                else
                {
                    intFeatCount = 0;
                    foreach (Feat objCharFeat in this.lstFeats)
                    {
                        if (objFeat == objCharFeat) intFeatCount++;
                    }
                    if (intFeatCount < objFeat.MultipleSelection) GoodFeatList.Add(objFeat);

                }
            }
            return GoodFeatList;
        }

        /// <summary>
        /// Qualifieds for feat.
        /// </summary>
        /// <param name="objFeat">The object feat.</param>
        /// <returns>Boolean</returns>
        public bool QualifiedForFeat(Feat objFeat)
        {
            bool returnVal = false;
            bool blnOneClassInList = false;
            bool blnAbilitiesPassFeatCheck = true;

            //Check Skills
            if (CharacterSkill.IsSkillInList(objFeat.objSkillPrerequisite, this.lstCharacterSkills))
            {
                //Check Feats
                if (Feat.IsFeatInList (objFeat.objFeatPrerequisiteFeats ,this.lstFeats ))
                {
                    //Check Class, only one has to be in
                    if (objFeat.objFeatPrerequisiteClasses.Count != 0)
                    {
                        foreach (Class objClass in objFeat.objFeatPrerequisiteClasses)
                        {
                            if (CharacterClassLevel.IsClassInList(objClass, this.lstCharacterClassLevels))
                            {
                                blnOneClassInList = true;
                            }
                        }
                    }
                    else
                    {
                        blnOneClassInList = true;
                    }
                    if (blnOneClassInList)
                    {
                        //Check Abilities
                        foreach (FeatPrerequisiteAbility objFeatPrereqAbility in objFeat.objFeatPrerequisiteAbilities )
                        {
                            bool blnIsAbilityInList = true;

                            foreach (CharacterAbility objCharAbil in this.lstCharacterAbilities)
                            {
                                if (objCharAbil.AbilityID == objFeatPrereqAbility.AbilityID )
                                {
                                    if (objCharAbil.Score >= objFeatPrereqAbility.AbilityMinimum ) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                }
                            }
                            if (!blnIsAbilityInList)
                            {
                                blnAbilitiesPassFeatCheck = false;
                            }
                        }
                        
                    }
                    if (blnAbilitiesPassFeatCheck)
                    {
                        //Check Attack bonus
                        if (this.BaseAttack >=  objFeat.objBaseAttackPrerequisite.BaseAttackNumber )
                        {
                            //Rage
                            if (Feat.IsFeatRageRequired(objFeat, this.objRace.RageAbility ))
                            {
                                //Check darkside
                                if (Feat.IsFeatDarkSideRequired(objFeat, this))
                                {
                                    //Check Shape shift
                                    if (Feat.IsFeatShapeShiftRequired(objFeat, this.objRace.ShapeShiftAbility))
                                    {
                                        //Check Size
                                        if (Size.IsSizeInList(this.objRace.objSize, objFeat.objFeatPrerequisiteSize))
                                        {
                                            ////check Feat itself, if Skill Training Feat and already have the skill 
                                            if (Feat.IsFeatSkillTrainingFeatAndInSkillList(objFeat, this.lstCharacterSkills ))
                                            //if (CharacterClassLevel.IsClassInList(objFeat.objFeatPrerequisiteClasses, this.objCharacterClassLevels))
                                            {
                                                //If a Skill Training Feat, Does the character class have access to id 
                                                if (Feat.IsSkillTrainingFeatAndCharacterClassesHaveAccess(objFeat, this))
                                                {
                                                    //Check Feat Or Conditions
                                                    if (Feat.FeatOrConditionsMeet(this, objFeat))
                                                    {
                                                        //Check Race
                                                        if (objFeat.objRacePrerequisite.RaceID == 0) returnVal = true;
                                                        else
                                                        {
                                                            if (this.objRace.RaceID == objFeat.objRacePrerequisite.RaceID) returnVal = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Check to see if the character already has the feat, and the Feat's multiple selection policy
            if (returnVal)
            {
                if (Feat.IsFeatInList (objFeat, this.lstFeats ))
                {
                    if (objFeat.MultipleSelection == 0) returnVal = false;
                    else
                    {
                        if (!Feat.CheckFeatCount(objFeat, lstFeats)) returnVal = false;
                    }
                }
            }

            return returnVal;
        }

        /// <summary>
        /// Qualifieds for talent.
        /// </summary>
        /// <param name="objTalent">The object talent.</param>
        /// <returns>Boolean</returns>
        public bool QualifiedForTalent(Talent objTalent)
        {
            bool returnVal = false;
            bool blnAbilitiesPassTalentCheck = true;


             //Check Skills
            if (CharacterSkill.IsSkillInList(objTalent.objTalentPrerequsiteSkill , this.lstCharacterSkills))
            {
                //Talents
                if (Talent.IsTalentInList(objTalent.objPrerequsiteTalent, this.lstTalents ) )
                {
                    //feats
                    if (Feat.IsFeatInList(objTalent.objTalentPrerequsiteFeat, this.lstFeats))
                    { 
                        //Force Power
                        if (ForcePower.IsForcePowerInList (objTalent.objTalentPrerequisteForcePower,this.lstForcePowers ))
                        {
                            //Check Abilities
                            foreach (TalentPrerequisteAbility objTalentPrerequisteAbility in objTalent.objTalentPrerequisteAbility)
                            {
                                bool blnIsAbilityInList = true;

                                foreach (CharacterAbility objCharAbil in this.lstCharacterAbilities)
                                {
                                    if (objCharAbil.AbilityID == objTalentPrerequisteAbility.AbilityID)
                                    {
                                        if (objCharAbil.Score >= objTalentPrerequisteAbility.AbilityMinimum) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                    }
                                }

                                //switch (objTalentPrerequisteAbility.objAbility.AbilityName.ToLower())
                                //{
                                //    case "strength":
                                //        if (this.Strength >= objTalentPrerequisteAbility.AbilityMinimum) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                //        break;
                                //    case "intelligence":
                                //        if (this.Intelligence >= objTalentPrerequisteAbility.AbilityMinimum) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                //        break;
                                //    case "wisdom":
                                //        if (this.Wisdom >= objTalentPrerequisteAbility.AbilityMinimum) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                //        break;
                                //    case "dexterity":
                                //        if (this.Dexterity >= objTalentPrerequisteAbility.AbilityMinimum) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                //        break;
                                //    case "constitution":
                                //        if (this.Constitution >= objTalentPrerequisteAbility.AbilityMinimum) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                //        break;
                                //    case "charisma":
                                //        if (this.Charisma >= objTalentPrerequisteAbility.AbilityMinimum) blnIsAbilityInList = true; else blnIsAbilityInList = false;
                                //        break;
                                //}
                                if (!blnIsAbilityInList)
                                {
                                    blnAbilitiesPassTalentCheck = false;
                                }
                            }
                            if (blnAbilitiesPassTalentCheck)
                            {
                                 //Check Attack bonus
                                if (this.BaseAttack >=   objTalent.objBaseAttackPrerequisite.BaseAttackNumber  ) 
                                {
                                    //Last set, check any OR conditions.
                                    //THis setup will check A and {B and C and D AND }(E or F {or...})
                                    if (Talent.TalentOrConditionsMeet(this, objTalent))
                                    {
                                        returnVal = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return returnVal;
        }

        /// <summary>
        /// Character's Class ID's.
        /// </summary>
        /// <returns>string of Class ID's</returns>
        public string CharacterClassIDs()
        {
            string strTalentTreeIDs = "";
            int intCurrentClassID = 0;
            if (this.lstCharacterClassLevels != null)
            {
                if (this.lstCharacterClassLevels.Count > 0)
                {

                    foreach (CharacterClassLevel objCharacterClassLevel in this.lstCharacterClassLevels)
                    {
                        if (objCharacterClassLevel.ClassID != intCurrentClassID)
                        {
                            strTalentTreeIDs = strTalentTreeIDs + objCharacterClassLevel.ClassID.ToString() + ",";
                            intCurrentClassID = objCharacterClassLevel.ClassID;
                        }
                    }

                    strTalentTreeIDs = strTalentTreeIDs.Substring(0, strTalentTreeIDs.Length - 1);
                }
                //else
                //{
                //    strTalentTreeIDs = strTalentTreeIDs.Substring(0, strTalentTreeIDs.Length - 1);
                //}
            }
            return strTalentTreeIDs;
        }

        ///// <summary>
        ///// Saves the character feats.
        ///// </summary>
        ///// <returns>Void</returns>
        //public void SaveCharacterFeats()
        //{
        //    foreach(Feat objFeat in this.objFeats )
        //    {
        //        objFeat.SaveCharacterFeat(this.CharacterID, objFeat.FeatID);
        //    }
        //}

        public Character SaveCharacter()
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

                command.CommandText = "InsertUpdate_Character";
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterID", SqlDbType.Int, CharacterID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterName", SqlDbType.VarChar, CharacterName.ToString(), 100));
                //command.Parameters.Add(dbconn.GenerateParameterObj("@ReflexDefenseID", SqlDbType.Int, ReflexDefenseID.ToString(), 0));
                //command.Parameters.Add(dbconn.GenerateParameterObj("@FortitudeDefenseID", SqlDbType.Int, FortitudeDefenseID.ToString(), 0));
                //command.Parameters.Add(dbconn.GenerateParameterObj("@WillDefenseID", SqlDbType.Int, WillDefenseID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ExperiencePoints", SqlDbType.Int, ExperiencePoints.ToString(), 0));
                //command.Parameters.Add(dbconn.GenerateParameterObj("@Age", SqlDbType.Int, Age.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Height", SqlDbType.Decimal, Height.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Weight", SqlDbType.Int, Weight.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForcePoints", SqlDbType.Int, ForcePoints.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DestintyPoints", SqlDbType.Int, DestintyPoints.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DarkSidePoints", SqlDbType.Int, DarkSidePoints.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@BaseAttack", SqlDbType.Int, BaseAttack.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Grapple", SqlDbType.Int, Grapple.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@DamageThreshold", SqlDbType.Int, DamageThreshold.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Encumberance", SqlDbType.Int, Encumberance.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Credits", SqlDbType.Int, Credits.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ConditionTackID", SqlDbType.Int, ConditionTrackID.ToString(), 0));
                //command.Parameters.Add(dbconn.GenerateParameterObj("@ArmorID", SqlDbType.Int, ArmorID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@RaceID", SqlDbType.Int, RaceID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CharacterLevelID", SqlDbType.Int, CharacterLevelID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@HitPoints", SqlDbType.Int, HitPoints.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@Sex", SqlDbType.VarChar , Sex.ToString(), 1));
                command.Parameters.Add(dbconn.GenerateParameterObj("@ForceTraditionID", SqlDbType.Int, ForceTraditionID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@LastClassLevelID", SqlDbType.Int, LastClassLevelID.ToString(), 0));
                command.Parameters.Add(dbconn.GenerateParameterObj("@CarryingCapacity", SqlDbType.Decimal, CarryingCapacity.ToString(), 0));
                
                result = command.ExecuteReader();

                //Save objects here
                CharacterAbility objCharAbility = new CharacterAbility();
                objCharAbility.SaveCharacterAbilities(this.lstCharacterAbilities, this.CharacterID);

                //CharacterEquipment objCharEquip = new CharacterEquipment();
                //objCharEquip.SaveCharacterEquipment.SaveCharacterEquipment(this.objEquipmentList, this.CharacterID);
                foreach (CharacterEquipment objCharEquip in this.lstEquipmentList )
                {
                    objCharEquip.SaveCharacterEquipment();
                }

                CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
                objCharacterClassLevel.SaveCharacterClassLevels(this.lstCharacterClassLevels, this.CharacterID );

                Feat objFeat = new Feat();
                objFeat.SaveCharacterFeats(this.lstFeats, this.CharacterID);

                Language objLanguage = new Language();
                objLanguage.SaveCharacterLanguages(this.lstLanguages , this.CharacterID);

                CharacterSkill objCharacterSkill = new CharacterSkill();
                objCharacterSkill.SaveCharacterSkills(this.lstCharacterSkills, this.CharacterID);

                Talent objTalent = new Talent();
                objTalent.SaveCharacterTalents (this.lstTalents, this.CharacterID);

                CharacterWeapon objCharWeapon = new CharacterWeapon();
                objCharWeapon.SaveCharacterWeapons(this.lstCharacterWeapons, this.CharacterID);

                PrestigeRequirement objPR = new PrestigeRequirement();
                objPR.SaveCharacterPrestigeRequirements(this.lstPrestigeRequirement, this.CharacterID);

                CharacterDefense objCharDef = new CharacterDefense();
                objCharDef.SaveCharacterDefenses(this.lstDefenses, this.CharacterID);

                ForcePower objFP = new ForcePower();
                objFP.SaveCharacterForcePowers(this.lstForcePowers, this.CharacterID);

                //Character Levels are not saved by Character, they are added via the CharacterLevelID property
                //CharacterLevel objCharLevel = new CharacterLevel();
                //objCharLevel.SaveCharacterLevels(this.objCharacterLevels, this.CharacterID);

                Organization objOrg = new Organization();
                objOrg.SaveCharacterOrganizations(this.lstCharacterOrganizations, this.CharacterID);

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


            Character objSavedChar = new Character(this.CharacterID);
            return objSavedChar;
        }


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>Boolean</returns>
        public override bool Validate()
        {
            this._validated = true;

            //Put Validation checks here
            if (string.IsNullOrEmpty(this.CharacterName ))
            {
                this._validated = false;
                this._validationMessage.Append("The Character Name cannot be blank or null.");
            }

            //if (this.ReflexDefenseID == 0)
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Reflex Defense ID cannot be zero, the Reflex Defense must be saved.");
            //}

            //if (this.FortitudeDefenseID  == 0)
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Fortitude Defense ID cannot be zero, the Fortitude Defense must be saved.");
            //}

            //if (this.WillDefenseID  == 0)
            //{
            //    this._validated = false;
            //    this._validationMessage.Append("The Will Defense ID cannot be zero, the Will Defense must be saved.");
            //}

            if (this.ExperiencePoints == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Experience Points cannot be zero.");
            }

            if (this.ForcePoints == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Force Points cannot be zero.");
            }

            if (this.DestintyPoints == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Destinty Points cannot be zero.");
            }

            if (this.DarkSidePoints == 0)
            {
                this._validated = false;
                this._validationMessage.Append("The Dark Side Points cannot be zero.");
            }


            return this.Validated;
        }

        public bool DeductPurchaseFromCredits(int intCost)
        {
            bool returnVal = true;
            if (Credits - intCost >= 0) Credits =- intCost; else returnVal = false;
            return returnVal;
        }

        public bool ForcePowersAvailableDueToAbilityIncrease (Ability objAbility1, Ability objAbility2)
        {
            bool retVal = false;

            if ((objAbility1.AbilityName.ToLower() == "wisdom") || (objAbility2.AbilityName.ToLower() == "wisdom"))
            {
                if (objAbility1.AbilityName.ToLower() == "wisdom")
                {
                    retVal = AbilityIncreaseResultsInModifierIncrease(objAbility1);
                }
                else retVal = AbilityIncreaseResultsInModifierIncrease(objAbility2);
            }

            return retVal;
        }

        public bool ForcePowersAvailableDueToFeatSelection(int intForceTrainingID, Feat objLevelFeat)
        {
            bool retVal = false;

            if (objLevelFeat.FeatID == intForceTrainingID)
            {
                retVal = true;
            }

            return retVal;
        }

        public bool ForcePowersAvailableForSelection(int intForceTrainingID, Feat objLevelFeat, Feat objRaceFeat, Ability objAbility1, Ability objAbility2)
        {
            bool retVal = false;
            //Force power available 
            //1) if Force power feat has been selected
            //2) Wisdom has been increased

            if (!(objLevelFeat.FeatID == 0) || !(objRaceFeat.FeatID == 0))
            {
                if ((objLevelFeat.FeatID == intForceTrainingID) || (objRaceFeat.FeatID == intForceTrainingID))
                {
                    retVal = true;
                }
            }

            if (!retVal)
            {
                if (objAbility1 != null)
                {
                    retVal = AbilityIncreaseResultsInModifierIncrease(objAbility1);
                }
                //if ((objAbility1.AbilityName.ToLower() == "wisdom") || (objAbility2.AbilityName.ToLower() == "wisdom"))
                //{
                //    if (objAbility1.AbilityName.ToLower() == "wisdom")
                //    {
                //        retVal = AbilityIncreaseResultsInModifierIncrease(objAbility1);
                //    }
                //    else retVal = AbilityIncreaseResultsInModifierIncrease(objAbility2);
                //}
            }

            if (!retVal)
            {
                if (objAbility2 != null)
                {
                    retVal = AbilityIncreaseResultsInModifierIncrease(objAbility2);
                }
            }
            return retVal;
        }

        public bool ForceRegimenAvailableForSelection(int intForceRegimenMastery, Feat objLevelFeat, Feat objRaceFeat, Ability objAbility1, Ability objAbility2)
        {
            bool retVal = false;
            //Force power available 
            //1) if Force Regimen Mastery Feat has been selected
            //2) Wisdom has been increased

            //int intForceRegimenMastery = Common.GetAppSettingsID("ForceRegimenMasteryID");
            if (!(objLevelFeat.FeatID == 0) || !(objRaceFeat.FeatID == 0))
            {
                if ((objLevelFeat.FeatID == intForceRegimenMastery) || (objRaceFeat.FeatID == intForceRegimenMastery))
                {
                    retVal = true;
                }
            }

            if (!retVal)
            {
                if (objAbility1 != null)
                {
                    retVal = AbilityIncreaseResultsInModifierIncrease(objAbility1);
                }

            }

            if (!retVal)
            {
                if (objAbility2 != null)
                {
                    retVal = AbilityIncreaseResultsInModifierIncrease(objAbility2);
                }
            }
            return retVal;
        }

        public int GetCharacterAbilityModifier(Ability objAbility)
        {
            int retVal = 0;

            foreach (CharacterAbility objCharAbility in this.lstCharacterAbilities)
            {
                if (objAbility.AbilityID == objCharAbility.AbilityID) retVal = objCharAbility.ScoreMod;
            }

            return retVal;
        }

        public int GetCharacterAbilityScore(Ability objAbility)
        {
            int retVal = 0;

            foreach (CharacterAbility objCharAbility in this.lstCharacterAbilities)
            {
                if (objAbility.AbilityID == objCharAbility.AbilityID) retVal = objCharAbility.Score;
            }

            return retVal;
        }

        public void AddCharacterStartingFeats (Class objClass)
        {
            Feat objStartFeats = new Feat();
            List<Feat> lstStartFeats = new List<Feat>();
            lstStartFeats = objStartFeats.GetStartingFeats(objClass.ClassID);
            foreach (Feat objSF in lstStartFeats)
            {
                this.lstFeats.Add(objSF);
            }

        }

        public int CalculateDamageThreshold(int intCanUseWillFeatID, Dictionary<int, int> dicFeatDefenseIncreases, Dictionary<int, int> dicTalentDefenseIncreases)
        {
            int retVal = 0;
            DefenseType objFortDefenseType = new DefenseType("Fortitude");
           
            if (lstDefenses.Count > 0)
            {

                Feat objUseWillFeat = new Feat(intCanUseWillFeatID);
                if (Feat.IsFeatInList(objUseWillFeat, this.lstFeats))
                {
                    DefenseType objWillDefenseType = new DefenseType("Will");
                    retVal = CompareDefensesUseHigher(objFortDefenseType.DefenseTypeID, objWillDefenseType.DefenseTypeID);
                }
                else
                {
                    //get the Fort Defense Value
                    foreach (CharacterDefense objFortDef in lstDefenses)
                    {
                        if (objFortDef.DefenseTypeID == objFortDefenseType.DefenseTypeID) retVal = 10 + objFortDef.AbilityMod + objFortDef.CharacterLevelArmor + objFortDef.ClassMod + objFortDef.FeatTalentMod + objFortDef.MiscellaneousMod + objFortDef.RaceMod;
                    }
                }
            }

            //So far there is only one Feat that increases Damage Threshold (Improved Damage Threshold) so go ahead and just add 5 Here
            if (dicFeatDefenseIncreases.Count > 0)
            {
                for (int i = 1; i <= dicFeatDefenseIncreases.Count; i++)
               {
                    int intFeatID = 0;
                    dicFeatDefenseIncreases.TryGetValue(i, out intFeatID);
                    if (intFeatID!=0)
                    {
                        Feat objFeat = new Feat(intFeatID);
                        if (Feat.IsFeatInList(objFeat,this.lstFeats)) retVal = retVal + 5;
                    }
               }
            }

            //Any Talents or other factors that can increase or decrease Damage Threshold?  Not as of now that I know of but code it
            if (dicTalentDefenseIncreases.Count > 0)
            {
                for (int i = 1; i <= dicTalentDefenseIncreases.Count; i++)
                {
                    int intTalentID = 0;
                    dicTalentDefenseIncreases.TryGetValue(i, out intTalentID);
                    if (intTalentID != 0)
                    {
                        Talent objTalent = new Talent(intTalentID);
                        if (Talent.IsTalentInList(objTalent, this.lstTalents)) retVal = retVal + 5;
                    }
                }
            }

            return retVal;
        }

        public int CalculateMaxForcePoints()
        {
            int retVal = 0;
            if (LastClassLevelID != 0)
            {
                ClassLevelInfo objLastClassLevel = new ClassLevelInfo(this.LastClassLevelID);
                retVal = objLastClassLevel.ForcePointBase + (this.CharacterLevelID / 2);
            }
            return retVal;
        }

        public int CalculateBaseAttack()
        {
            int retVal = 0;

            retVal = lstCharacterClassLevels.Sum(d => d.objCharacterClassLevelInfo.Sum(t => t.BaseAttack));
            return retVal;
        }

        public int CalculateRangeToHit(Weapon objWeapon)
        {
            int retVal = 0;
            int intNonProfModifier = 0;

            Ability objAbility = new Ability("Dexterity");

            if (!Feat.IsFeatInList(objWeapon.objWeaponProficiencyFeat, this.lstFeats)) intNonProfModifier = -5;

            retVal = intNonProfModifier + CalculateBaseAttack() + GetCharacterAbilityModifier(objAbility);
            return retVal;
        }

        public int CalculateRangeBonusDamage()
        {
            int retVal = 0;

            retVal = (this.CharacterLevelID / 2);
            return retVal;
        }

        public int CalculateMeleeToHit(Weapon objWeapon, int intSimpleWeaponFineseFeatID, int intLightsaberWeaponFineseID )
        {
            int retVal = 0;

            int intNonProfModifier = 0;

            Ability objAbilityDex = new Ability("Dexterity");
            Ability objAbilityStr = new Ability("Strength");

            int StrToHit = 0;
            int DexToHit = 0;

            if (!Feat.IsFeatInList(objWeapon.objWeaponProficiencyFeat, this.lstFeats)) intNonProfModifier = -5;

            bool TakeBetter = false;

            Feat objFeat = new Feat();
            if (objWeapon.objWeaponType.WeaponTypeID == 2) objFeat.GetFeat(intSimpleWeaponFineseFeatID);    //Simple
            else if (objWeapon.objWeaponType.WeaponTypeID == 13) objFeat.GetFeat(intLightsaberWeaponFineseID); //LightSabers

            if (objFeat.FeatID != 0)if (Feat.IsFeatInList(objFeat, lstFeats)) TakeBetter = true;

            StrToHit = intNonProfModifier + CalculateBaseAttack() + GetCharacterAbilityModifier(objAbilityStr);
            DexToHit = intNonProfModifier + CalculateBaseAttack() + GetCharacterAbilityModifier(objAbilityDex);

            if (TakeBetter)
            {
                if (StrToHit >= DexToHit) retVal = StrToHit; else retVal = DexToHit;
            }
            else retVal = StrToHit;

            return retVal;
        }

        public int CalculateMeleeBonusDamage()
        {
            int retVal = 0;
            Ability objAbility = new Ability("Strength");

            retVal = (this.CharacterLevelID / 2) + GetCharacterAbilityModifier(objAbility);
            return retVal;
        }

        public void UpdateCharacterWeaponStats( int intSimpleWeaponFineseFeatID, int intLightsaberWeaponFineseID)
        {
            foreach (CharacterWeapon objCW in lstCharacterWeapons )
            {
                //Weapon objWeap = new Weapon(objCW.WeaponID);
                //int intNonProfPenality = 0;
                //if (Feat.IsFeatInList(objWeap.objWeaponProficiencyFeat, objFeats)) intNonProfPenality = 0; else intNonProfPenality = -5;

                objCW.MeleeAttackBonus = CalculateMeleeToHit(objCW.objWeapon, intSimpleWeaponFineseFeatID, intLightsaberWeaponFineseID);  // +intNonProfPenality;
                objCW.MeleeDamageBonus = CalculateMeleeBonusDamage();
                objCW.RangeAttackBonus = CalculateRangeToHit(objCW.objWeapon); // +intNonProfPenality;
                objCW.RangeDamageBonus = CalculateRangeBonusDamage();
            }
        }

        public bool CreditCreditsForCharacter (int intCreditRate, int intOriginalAmount)
        {
            bool blnReturnVal = true;
            this.Credits += (int)(((decimal)intCreditRate / 100) * intOriginalAmount);
            return blnReturnVal;
        }

        public bool DeductCreditsFromCharacter(int intMainFormCredits, int intCreditCost)
        {
            bool blnReturnVal = true;

            if (intMainFormCredits > this.Credits)
            {
                this.Credits = intMainFormCredits;
                this.SaveCharacter();
            }
            if (this.Credits >= intCreditCost) this.Credits -=intCreditCost; else blnReturnVal = false;
            return blnReturnVal;

        }

        #region Static Methods
        /// <summary>
        /// Clones the specified object Character.
        /// </summary>
        /// <param name="objCharacter">The object Character.</param>
        /// <returns>Character</returns>
        static public Character Copy(Character objCharacter)
        {

            Character objCopyCharacter = new Character();
            objCopyCharacter.CharacterID = objCharacter.CharacterID;
            objCopyCharacter.CharacterName = objCharacter.CharacterName;
            //objCopyCharacter.FortitudeDefenseID = objCharacter.FortitudeDefenseID;
            //objCopyCharacter.WillDefenseID = objCharacter.WillDefenseID;
            //objCopyCharacter.ReflexDefenseID = objCharacter.ReflexDefenseID;
            objCopyCharacter.RaceID = objCharacter.RaceID;
            objCopyCharacter.ExperiencePoints = objCharacter.ExperiencePoints;
            objCopyCharacter.HitPoints = objCharacter.HitPoints;
            //objCopyCharacter.Movement = objCharacter.Movement;
            objCopyCharacter.ForcePoints = objCharacter.ForcePoints;
            objCopyCharacter.DestintyPoints = objCharacter.DestintyPoints;
            objCopyCharacter.DarkSidePoints = objCharacter.DarkSidePoints;
            objCopyCharacter.BaseAttack = objCharacter.BaseAttack;
            objCopyCharacter.Grapple = objCharacter.Grapple;
            objCopyCharacter.DamageThreshold = objCharacter.DamageThreshold;
            objCopyCharacter.Encumberance = objCharacter.Encumberance;
            objCopyCharacter.ConditionTrackID = objCharacter.ConditionTrackID;
            objCopyCharacter.CharacterAge = objCharacter.CharacterAge;
            objCopyCharacter.ArmorID = objCharacter.ArmorID;
            objCopyCharacter.Sex = objCharacter.Sex;
            objCopyCharacter.ForceTraditionID = objCharacter.ForceTraditionID;
            objCopyCharacter.CarryingCapacity = objCharacter.CarryingCapacity;
            //public List<CharacterAbility> objCharacterAbilities { get; set; }
            //public List<Equipment> objEquipmentList { get; set; }
            //public List<CharacterClassLevel> objCharacterClassLevels { get; set; }
            //public List<Feat> objFeats { get; set; }
            //public List<Language> objLanguages { get; set; }
            //public List<CharacterSkill> objCharacterSkills { get; set; }
            //public List<Talent> objTalents { get; set; }
            //public List<Weapon> objWeapons { get; set; }
            //public List<PrestigeRequirement> objPrestigeRequirement { get; set; }
            //public List<Defense> objDefenses { get; set; }
            //public List<ForcePower> objForcePowers { get; set; }
            //public List<CharacterLevel> objCharacterLevels { get; set; }
            //public List<Organization> objCharacterOrganizations { get; set; }
            //public Race objRace { get; set; }
            objCopyCharacter.lstCharacterAbilities = CharacterAbility.Clone(objCharacter.lstCharacterAbilities);



            return objCopyCharacter;
        }

        /// <summary>
        /// Clones the specified object Character.
        /// </summary>
        /// <param name="objCharacter">The object Character.</param>
        /// <returns>Character</returns>
        static public Character Clone(Character objCharacter)
        {
            Character objCCharacter = new Character();
            if (objCharacter.CharacterID != 0)
            {
                objCCharacter = objCCharacter.GetCharacter (objCharacter.CharacterID);
            }
            else
            {
                //Clone the objCharacter Object that you have
                objCCharacter.CharacterID = objCharacter.CharacterID;
                objCCharacter.CharacterName = objCharacter.CharacterName;
                //objCCharacter.FortitudeDefenseID = objCharacter.FortitudeDefenseID;
                //objCCharacter.WillDefenseID = objCharacter.WillDefenseID;
                //objCCharacter.ReflexDefenseID = objCharacter.ReflexDefenseID;
                objCCharacter.CharacterLevelID = objCharacter.CharacterLevelID;
                objCCharacter.RaceID = objCharacter.RaceID;
                objCCharacter.ExperiencePoints = objCharacter.ExperiencePoints;
                objCCharacter.HitPoints = objCharacter.HitPoints;
                //objCCharacter.Movement = objCharacter.Movement;
                objCCharacter.ForcePoints = objCharacter.ForcePoints;
                objCCharacter.DestintyPoints = objCharacter.DestintyPoints;
                objCCharacter.DarkSidePoints = objCharacter.DarkSidePoints;
                objCCharacter.BaseAttack = objCharacter.BaseAttack;
                objCCharacter.Grapple = objCharacter.Grapple;
                objCCharacter.DamageThreshold = objCharacter.DamageThreshold;
                objCCharacter.Encumberance = objCharacter.Encumberance;
                objCCharacter.ConditionTrackID = objCharacter.ConditionTrackID;
                objCCharacter.CharacterAge = objCharacter.CharacterAge;
                objCCharacter.ArmorID = objCharacter.ArmorID;
                objCCharacter.Sex = objCharacter.Sex;
                objCCharacter.ForceTraditionID = objCharacter.ForceTraditionID;
                objCCharacter.CarryingCapacity = objCharacter.CarryingCapacity;
                objCCharacter.LastClassLevelID = objCharacter.LastClassLevelID;

                objCCharacter.lstCharacterAbilities = CharacterAbility.Clone(objCharacter.lstCharacterAbilities);
                //objCCharacter.objEquipmentList = Equipment.Clone(objCharacter.objEquipmentList);
                objCCharacter.lstEquipmentList = CharacterEquipment.Clone(objCharacter.lstEquipmentList);
                objCCharacter.lstFeats = Feat.Clone(objCharacter.lstFeats);
                objCCharacter.lstLanguages = Language.Clone(objCharacter.lstLanguages);
                objCCharacter.lstCharacterSkills = CharacterSkill.Clone(objCharacter.lstCharacterSkills);
                objCCharacter.lstTalents = Talent.Clone(objCharacter.lstTalents);
                objCCharacter.lstCharacterWeapons = CharacterWeapon.Clone(objCharacter.lstCharacterWeapons);
                objCCharacter.lstPrestigeRequirement = PrestigeRequirement.Clone(objCharacter.lstPrestigeRequirement);
                objCCharacter.lstForcePowers = ForcePower.Clone(objCharacter.lstForcePowers);
                objCCharacter.lstCharacterLevels = CharacterLevel.Clone(objCharacter.lstCharacterLevels);
                objCCharacter.lstCharacterOrganizations = Organization.Clone(objCharacter.lstCharacterOrganizations);
                objCCharacter.objRace = Race.Clone(objCharacter.objRace);
                objCCharacter.lstCharacterWeapons = CharacterWeapon.Clone(objCharacter.lstCharacterWeapons);
                objCCharacter.lstCharacterArmors = CharacterArmor.Clone(objCharacter.lstCharacterArmors);


            }
            return objCCharacter;
        }

        /// <summary>
        /// Clones the specified LST Character.
        /// </summary>
        /// <param name="lstCharacter">The LST Character.</param>
        /// <returns>List<Character></returns>
        static public List<Character> Clone(List<Character> lstCharacter)
        {
            List<Character> lstCCharacter = new List<Character>();

            foreach (Character objCharacter in lstCharacter)
            {
                lstCCharacter.Add(Character.Clone(objCharacter));
            }

            return lstCCharacter;
        }

        static public bool IsCharacterPrestigeClassLevelQualified(Class objClass, Character objChar)
        {
            bool blnReturnVal = true;

            if (objChar.CharacterLevelID <= objClass.PrestigeRequiredLevel)
            {
                blnReturnVal = false;
            }

            return blnReturnVal;
        }

        static public bool IsCharacterPrestigeBaseAttaclQualified(Class objClass, Character objChar)
        {
            bool blnReturnVal = true;

            if (objClass.PrestigeRequiredBaseAttack != 0)
            {
                if (objChar.BaseAttack >= objClass.PrestigeRequiredBaseAttack)
                {
                    blnReturnVal = false;
                }
            }

            return blnReturnVal;
        }

        static public bool IsCharacterPrestigeClassQualified(Class objClass, Character objChar)
        {
            bool blnReturnVal = true;
            bool blnCurrentReqFound = false;

            if (objClass.objPrestigeRequirement.Count != 0)
            {
                //loop thru each PrestigeRequirement in the class and see if the Character has it.
                foreach (PrestigeRequirement lstPrestigeRequirement in objClass.objPrestigeRequirement)
                {
                    foreach (PrestigeRequirement lstCharPrestigeRequirement in objChar.lstPrestigeRequirement)
                    {
                        if (lstPrestigeRequirement == lstCharPrestigeRequirement)
                        {
                            blnCurrentReqFound = true;
                        }
                    }
                    //If the return value is false, leave it false, one false is all it takes.
                    if (blnReturnVal == true)
                    {
                        //If the current requirement was not found on this char then set the overall requirement to false;
                        if (blnCurrentReqFound == false)
                        {
                            blnReturnVal = blnCurrentReqFound;
                        }
                    }
                }
            }
            return blnReturnVal;
        }

        static public bool IsCharacterPrestigeClassQualifiedTalentTree(Class objClass, Character objChar)
        {
            bool blnReturnVal = false;
            int intCurrentTalentTreeRequiredTotal = 0;

            if (objClass.objPrestigeRequiredTalentTree != null)
            {
                //Go thru each talent in the character 
                foreach (Talent lstCharTalent in objChar.lstTalents)
                {
                    //Now get each talent tree from the prestige class
                    foreach (TalentTree lstClassTalentTree in objClass.objPrestigeRequiredTalentTree)
                    {
                        //Now get each talent in prestige class talent tree
                        foreach (Talent lstClassTalent in lstClassTalentTree.objTalentTreeTalents)
                        {
                            if (lstCharTalent.TalentTreeID == lstClassTalent.TalentTreeID)
                            {
                                intCurrentTalentTreeRequiredTotal++;
                            }
                        }
                    }
                }

                if (intCurrentTalentTreeRequiredTotal >= objClass.PrestigeRequiredTalents)
                {
                    blnReturnVal = true;
                }
                else
                {
                    blnReturnVal = false;
                }
            }
            else
            {
                blnReturnVal = true;
            }

            return blnReturnVal;
        }

        static public bool IsCharacterPrestigeClassQualifiedFeat(Class objClass, Character objChar)
        {
            bool blnReturnVal = true;
            bool blnCurrentReqFound = false;

            if (objClass.objPrestigeRequiredFeats.Count == 0) blnCurrentReqFound = true;

            if (objClass.objPrestigeRequirement != null)
            {
                //loop thru each required feats in the class and see if the Character has it.
                foreach (Feat lstPrestigeReqFeat in objClass.objPrestigeRequiredFeats)
                {
                    foreach (Feat lstCharFeat in objChar.lstFeats)
                    {
                        if (lstPrestigeReqFeat.FeatID == lstCharFeat.FeatID)
                        {
                            blnCurrentReqFound = true;
                        }
                    }
                }
                //If the return value is false, leave it false, one false is all it takes.
                if (blnReturnVal == true)
                {
                    //If the current requirement was not found on this char then set the overall requirement to false;
                    if (blnCurrentReqFound == false)
                    {
                        blnReturnVal = blnCurrentReqFound;
                    }
                }

            }

            return blnReturnVal;
        }

        static public bool IsCharacterPrestigeClassQualifiedFeatGroup(Class objClass, Character objChar)
        {
            bool blnReturnVal = false;
            int intCurrentFeatGroupRequiredTotal = 0;

            if (objClass.objPrestigeRequiredFeatGroup.Count != 0)
            {
                //Go thru each of the talent trees required
                foreach (Feat lstClassFeat in objClass.objPrestigeRequiredFeatGroup)
                {
                    //Check each Talent in objChar to see if its one of the talent trees
                    foreach (Feat lstCharFeat in objChar.lstFeats)
                    {
                        if (lstCharFeat.FeatID == lstClassFeat.FeatID)
                        {
                            intCurrentFeatGroupRequiredTotal++;
                        }
                    }
                }

                if (intCurrentFeatGroupRequiredTotal >= objClass.PrestigeRequiredFeats)
                {
                    blnReturnVal = true;
                }
                else
                {
                    blnReturnVal = false;
                }
            }
            else
            {
                blnReturnVal = true;
            }

            return blnReturnVal;
        }

        static public bool IsCharacterPrestigeClassQualifiedTalent(Class objClass, Character objChar)
        {
            bool blnReturnVal = false;
            int intCurrentTalentsRequiredTotal = 0;

            if (objClass.objPrestigeRequiredTalents.Count != 0)
            {
                //Go thru each of the talent trees required
                foreach (Talent lstClassTalent in objClass.objPrestigeRequiredTalents)
                {
                    //Check each Talent in objChar to see if its one of the talent trees
                    foreach (Talent lstCharTalent in objChar.lstTalents)
                    {
                        if (lstCharTalent.TalentID == lstClassTalent.TalentID)
                        {
                            intCurrentTalentsRequiredTotal++;
                        }
                    }
                }

                if (intCurrentTalentsRequiredTotal >= objClass.PrestigeRequiredTalents)
                {
                    blnReturnVal = true;
                }
                else
                {
                    blnReturnVal = false;
                }
            }
            else
            {
                blnReturnVal = true;
            }

            return blnReturnVal;
        }

        static public bool IsCharacterPrestigeClassQualifiedForcePowers(Class objClass, Character objChar)
        {
            bool blnReturnVal = false;
            bool blnCurrentReqFound = true;

            if (objClass.objPrestigeRequiredForcePowers.Count != 0)
            {
                //Go thru each of the talent trees required
                foreach (ForcePower lstClassFP in objClass.objPrestigeRequiredForcePowers)
                {
                    //Check each Talent in objChar to see if its one of the talent trees
                    foreach (ForcePower lstCharFP in objChar.lstForcePowers)
                    {
                        if (lstClassFP.ForcePowerID == lstCharFP.ForcePowerID)
                        {
                            blnCurrentReqFound = true;
                        }
                    }
                }

                //If the return value is false, leave it false, one false is all it takes.
                if (blnReturnVal == true)
                {
                    //If the current requirement was not found on this char then set the overall requirement to false;
                    if (blnCurrentReqFound == false)
                    {
                        blnReturnVal = blnCurrentReqFound;
                    }
                }
            }
            else
            {
                blnReturnVal = true;
            }
            return blnReturnVal;
        }
        #endregion
        #endregion

        #region Private Methods
        private int CompareDefensesUseHigher(int DefenseTypeA, int DefenseTypeB)
        {
            int retVal = 0;
            int intDefValA = 0;
            int intDefValB = 0;

            foreach (CharacterDefense objDT in lstDefenses)
            {
                if (objDT.DefenseTypeID == DefenseTypeA) intDefValA = 10 + objDT.AbilityMod + objDT.CharacterLevelArmor + objDT.ClassMod + objDT.FeatTalentMod + objDT.MiscellaneousMod + objDT.RaceMod;
                if (objDT.DefenseTypeID == DefenseTypeB) intDefValB = 10 + objDT.AbilityMod + objDT.CharacterLevelArmor + objDT.ClassMod + objDT.FeatTalentMod + objDT.MiscellaneousMod + objDT.RaceMod;
            }

            if (intDefValA >= intDefValB) retVal = intDefValA; else retVal = intDefValB;

            return retVal;
        }

        //private Character SaveCharacter
        private bool AbilityIncreaseResultsInModifierIncrease(Ability objAbility)
        {
            bool retVal = false;
            if (objAbility.AbilityName != null)
            {
                if (ModIncreasedDueToAbilityIncrease(objAbility.AbilityName))
                {
                    retVal = true;
                }
            }
            return retVal;
        }

        private bool ModIncreasedDueToAbilityIncrease(string strAbilityName)
        {
            bool retVal = false;
            int intOriginalValue = 0;
            int intOriginalModValue = 0;
            int intNewModValue = 0;


            foreach (CharacterAbility objCharAbil in this.lstCharacterAbilities)
            {
                if (strAbilityName.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                {
                    intOriginalValue = objCharAbil.Score;
                    intOriginalModValue = objCharAbil.ScoreMod;
                }
            }

            //switch (strAbilityName.ToLower())
            //{
            //    case "strength":
            //        intOriginalValue = this.Strength;
            //        intOriginalModValue = this.StrengthMod;
            //        break;
            //    case "intelligence":
            //        intOriginalValue = this.Intelligence;
            //        intOriginalModValue = this.IntelligenceMod;
            //        break;
            //    case "wisdom":
            //        intOriginalValue = this.Wisdom;
            //        intOriginalModValue = this.WisdomMod;
            //        break;
            //    case "dexterity":
            //        intOriginalValue = this.Dexterity;
            //        intOriginalModValue = this.DexterityMod;
            //        break;
            //    case "constitution":
            //        intOriginalValue = this.Constitution;
            //        intOriginalModValue = this.ConstitutionMod;
            //        break;
            //    case "charisma":
            //        intOriginalValue = this.Charisma;
            //        intOriginalModValue = this.CharismaMod;
            //        break;
            //    default:
            //        intOriginalValue = this.Strength;
            //        intOriginalModValue = this.StrengthMod;
            //        break;
            //}

            intNewModValue = (intOriginalValue + 1 - 10) / 2;                                //(([Strength]-(10))/(2))
            if (intNewModValue > intOriginalModValue)
            {
                //We have an increase that results in a mod increase
                retVal = true;
            }
            return retVal;
        }

        /// <summary>
        /// Gets the single character.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>Character Object</returns>
        private Character GetSingleCharacter(string sprocName, string strWhere, string strOrderBy)
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
        /// Gets the character list.
        /// </summary>
        /// <param name="strSprocName">Name of the string sproc.</param>
        /// <param name="strWhere">The string where.</param>
        /// <param name="strOrderBy">The string order by.</param>
        /// <returns>List of Character Objects</returns>
        private List<Character> GetCharacterList(string strSprocName, string strWhere, string strOrderBy)
        {
            List<Character> characters = new List<Character>();

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
                    Character objCharacter = new Character();
                    SetReaderToObject(ref objCharacter, ref result);
                    characters.Add(objCharacter);
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
            return characters;
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="result">The result.</param>
        private  void SetReaderToObject(ref SqlDataReader result)
        {
            if (result.HasRows)
            {
                this.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                this.CharacterName = result.GetValue(result.GetOrdinal("CharacterName")).ToString();

                //this.FortitudeDefenseID = (int)result.GetValue(result.GetOrdinal("FortitudeDefenseID"));
                //this.ReflexDefenseID = (int)result.GetValue(result.GetOrdinal("ReflexDefenseID"));
                //this.WillDefenseID = (int)result.GetValue(result.GetOrdinal("WillDefenseID"));

                this.CharacterLevelID = (int)result.GetValue(result.GetOrdinal("CharacterLevelID"));
                this.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));

                //this.Movement = (int)result.GetValue(result.GetOrdinal("Movement"));
                this.ForcePoints = (int)result.GetValue(result.GetOrdinal("ForcePoints"));
                this.DestintyPoints = (int)result.GetValue(result.GetOrdinal("DestintyPoints"));
                this.DarkSidePoints = (int)result.GetValue(result.GetOrdinal("DarkSidePoints"));
                this.BaseAttack = (int)result.GetValue(result.GetOrdinal("BaseAttack"));
                this.Grapple = (int)result.GetValue(result.GetOrdinal("Grapple"));
                this.DamageThreshold = (int)result.GetValue(result.GetOrdinal("DamageThreshold"));
                this.Encumberance = (int)result.GetValue(result.GetOrdinal("Encumberance"));
                this.ConditionTrackID = (int)result.GetValue(result.GetOrdinal("ConditionTrackID"));
                //this.CharacterAge = (int)result.GetValue(result.GetOrdinal("CharacterAge"));
                //this.ArmorID = (int)result.GetValue(result.GetOrdinal("ArmorID"));
                this.ExperiencePoints = (int)result.GetValue(result.GetOrdinal("ExperiencePoints"));
                this.HitPoints = (int)result.GetValue(result.GetOrdinal("HitPoints"));
                this.Sex = result.GetValue(result.GetOrdinal("Sex")).ToString();
                this.ForceTraditionID = (int)result.GetValue(result.GetOrdinal("ForceTradtionID"));
                this.Height = (decimal)result.GetValue(result.GetOrdinal("Height"));
                this.Weight = (int)result.GetValue(result.GetOrdinal("Weight"));
                this.Credits = (int)result.GetValue(result.GetOrdinal("Credits"));
                this.LastClassLevelID = (int)result.GetValue(result.GetOrdinal("LastClassLevelID"));
                //this.CarryingCapacty = (int)result.GetValue(result.GetOrdinal("CarryingCapacty"));
                if (result.GetValue(result.GetOrdinal("CarryingCapacity")) + "" != "") this.CarryingCapacity = (decimal)result.GetValue(result.GetOrdinal("CarryingCapacity"));
                if (result.GetValue(result.GetOrdinal("CharacterAge")) != null) this.CharacterAge = (int)result.GetValue(result.GetOrdinal("CharacterAge"));

                
                CharacterDefense objDefObject = new CharacterDefense();
                Race objRace = new Race();
                CharacterEquipment objCharEquipList = new CharacterEquipment();
                CharacterClassLevel objCharClassLevels = new CharacterClassLevel();
                Feat objFeat = new Feat();
                Language objLang = new Language();
                CharacterSkill objCharacterSkill = new CharacterSkill();
                Talent objTalent = new Talent();
                //CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
                PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
                ForcePower objForcePower = new ForcePower();
                CharacterLevel objCharLevel = new CharacterLevel();
                ForceTradition objForceTradition = new ForceTradition();
                CharacterAbility objCharAbility = new CharacterAbility ();
                Organization objCharOrg = new Organization();
                CharacterWeapon objCharWeap = new CharacterWeapon();
                CharacterArmor objCharArmor = new CharacterArmor();
                Speed objCharSpeed = new Speed();

                this.lstCharacterAbilities = objCharAbility.GetCharacterAbilities("CharacterID=" + this.CharacterID.ToString(), "");
                if (this.RaceID == 0) this.objRace = objRace; else this.objRace = objRace.GetRace(this.RaceID);
                this.lstDefenses = objDefObject.GetCharacterDefenses(this.CharacterID);
                this.lstEquipmentList = objCharEquipList.GetCharacterEquipmentList("CharacterID=" + this.CharacterID, "");
                this.lstCharacterClassLevels = objCharClassLevels.GetCharacterClassLevel(this.CharacterID);
                this.lstFeats = objFeat.GetCharacterFeats("CharacterID=" + this.CharacterID.ToString(), "FeatName");
                this.lstLanguages = objLang.GetCharacterLanguages(this.CharacterID);
                this.lstCharacterSkills = objCharacterSkill.GetCharacterSkills (this.CharacterID);
                this.lstTalents = objTalent.GetCharacterTalents (this.CharacterID);
                //this.lstCharacterClassLevels = objCharacterClassLevel.GetCharacterClassLevel(this.CharacterID);
                
                this.lstPrestigeRequirement = objPrestigeRequirement.GetCharacterPrestigeRequirement(this.CharacterID);
                this.lstForcePowers = objForcePower.GetCharacterForcePowers(this.CharacterID );
                this.lstCharacterLevels = objCharLevel.GetCharacterLevels("CharacterLevelID=" + this.CharacterLevelID.ToString(), "");
                this.lstCharacterOrganizations = objCharOrg.GetCharacterOrganizations(this.CharacterID);
                this.lstCharacterWeapons = objCharWeap.GetCharacterWeapons(this.CharacterID);
                this.lstCharacterArmors = objCharArmor.GetCharacterArmors(this.CharacterID);
                this.lstCharacterSpeeds = objCharSpeed.GetCharacterSpeeds(this.CharacterID );


                if (this.ForceTraditionID != 0)
                {
                    objForceTradition.GetForceTradition(this.ForceTraditionID);
                }

                this.lstCharacterAbilities = this.lstCharacterAbilities.OrderBy(n => n.objAbility.SortOrder).ToList<CharacterAbility>();
                //this.lstDefenses = this.lstDefenses.OrderBy(n => n.D)
                this.lstEquipmentList = this.lstEquipmentList.OrderBy(n => n.objEquipment.EquipmentName).ToList<CharacterEquipment>();
                this.lstCharacterClassLevels = this.lstCharacterClassLevels.OrderBy(n => n.objCharacterClass.ClassName).ToList<CharacterClassLevel>();
                this.lstLanguages = this.lstLanguages.OrderBy(n => n.LanguageName).ToList<Language>();
                this.lstCharacterSkills = this.lstCharacterSkills.OrderBy(n => n.objSkill.SkillName).ToList<CharacterSkill>();
                this.lstTalents = this.lstTalents.OrderBy(n => n.TalentName).ToList<Talent>();
                this.lstPrestigeRequirement = this.lstPrestigeRequirement.OrderBy(n => n.PrestigeRequirementDescription).ToList<PrestigeRequirement>();
                this.lstForcePowers = this.lstForcePowers.OrderBy(n => n.ForcePowerName).ToList<ForcePower>();
                //this.lstCharacterLevels = this.lstCharacterLevels.OrderBy(n => n.c).ToList<ForcePower>();
                this.lstCharacterOrganizations = this.lstCharacterOrganizations.OrderBy(n => n.OrganizationName).ToList<Organization>();
                this.lstCharacterWeapons = this.lstCharacterWeapons.OrderBy(n => n.objWeapon.WeaponName).ToList<CharacterWeapon>();
                this.lstCharacterArmors = this.lstCharacterArmors.OrderBy(n => n.objArmor.ArmorName).ToList<CharacterArmor>();
                this.lstCharacterSpeeds = this.lstCharacterSpeeds.OrderBy(n => n.SpeedName).ToList<Speed>();

                

                this._objComboBoxData.Clear();
                this._objComboBoxData.Add(this.CharacterID, this.CharacterName);
            }
        }

        /// <summary>
        /// Sets the reader to object.
        /// </summary>
        /// <param name="objCharacter">The object character.</param>
        /// <param name="result">The result.</param>
        private void SetReaderToObject(ref Character objCharacter, ref SqlDataReader result)
        {
            if (result.HasRows)
            {

                objCharacter.CharacterID = (int)result.GetValue(result.GetOrdinal("CharacterID"));
                objCharacter.CharacterName = result.GetValue(result.GetOrdinal("CharacterName")).ToString();

                //objCharacter.FortitudeDefenseID = (int)result.GetValue(result.GetOrdinal("FortitudeDefenseID"));
                //objCharacter.ReflexDefenseID = (int)result.GetValue(result.GetOrdinal("ReflexDefenseID"));
                //objCharacter.WillDefenseID = (int)result.GetValue(result.GetOrdinal("WillDefenseID"));

                objCharacter.CharacterLevelID = (int)result.GetValue(result.GetOrdinal("CharacterLevelID"));
                objCharacter.RaceID = (int)result.GetValue(result.GetOrdinal("RaceID"));

                //objCharacter.Movement = (int)result.GetValue(result.GetOrdinal("Movement"));
                objCharacter.ForcePoints = (int)result.GetValue(result.GetOrdinal("ForcePoints"));
                objCharacter.DestintyPoints = (int)result.GetValue(result.GetOrdinal("DestintyPoints"));
                objCharacter.DarkSidePoints = (int)result.GetValue(result.GetOrdinal("DarkSidePoints"));
                objCharacter.BaseAttack = (int)result.GetValue(result.GetOrdinal("BaseAttack"));
                objCharacter.Grapple = (int)result.GetValue(result.GetOrdinal("Grapple"));
                objCharacter.DamageThreshold = (int)result.GetValue(result.GetOrdinal("DamageThreshold"));
                objCharacter.Encumberance = (int)result.GetValue(result.GetOrdinal("Encumberance"));
                objCharacter.ConditionTrackID = (int)result.GetValue(result.GetOrdinal("ConditionTrackID"));
                //objCharacter.CharacterAge = (int)result.GetValue(result.GetOrdinal("CharacterAge"));
                //objCharacter.ArmorID = (int)result.GetValue(result.GetOrdinal("ArmorID"));
                objCharacter.ExperiencePoints = (int)result.GetValue(result.GetOrdinal("ExperiencePoints"));
                objCharacter.HitPoints = (int)result.GetValue(result.GetOrdinal("HitPoints"));
                objCharacter.Sex = result.GetValue(result.GetOrdinal("Sex")).ToString();
                objCharacter.ForceTraditionID = (int)result.GetValue(result.GetOrdinal("ForceTradtionID"));
                objCharacter.Height = (decimal)result.GetValue(result.GetOrdinal("Height"));
                objCharacter.Weight = (int)result.GetValue(result.GetOrdinal("Weight"));
                objCharacter.Credits = (int)result.GetValue(result.GetOrdinal("Credits"));
                objCharacter.LastClassLevelID = (int)result.GetValue(result.GetOrdinal("LastClassLevelID"));
                //objCharacter.CarryingCapacty = (int)result.GetValue(result.GetOrdinal("CarryingCapacty"));
                if (result.GetValue(result.GetOrdinal("CarryingCapacity")) + "" != "") objCharacter.CarryingCapacity = (decimal)result.GetValue(result.GetOrdinal("CarryingCapacity"));
                if (result.GetValue(result.GetOrdinal("CharacterAge")) + "" != "") objCharacter.CharacterAge = (int)result.GetValue(result.GetOrdinal("CharacterAge"));

                CharacterDefense objDefObject = new CharacterDefense();
                Race objRace = new Race();
                CharacterEquipment objCharEquipList = new CharacterEquipment();
                CharacterClassLevel objCharClassLevels = new CharacterClassLevel();
                Feat objFeat = new Feat();
                Language objLang = new Language();
                CharacterSkill objCharacterSkill = new CharacterSkill();
                Talent objTalent = new Talent();
                //CharacterClassLevel objCharacterClassLevel = new CharacterClassLevel();
                PrestigeRequirement objPrestigeRequirement = new PrestigeRequirement();
                ForcePower objForcePower = new ForcePower();
                CharacterLevel objCharLevel = new CharacterLevel();
                ForceTradition objForceTradition = new ForceTradition();
                CharacterAbility objCharAbility = new CharacterAbility();
                Organization objCharOrg = new Organization();
                CharacterWeapon objCharWeap = new CharacterWeapon();
                CharacterArmor objCharArmor = new CharacterArmor();
                Speed objCharSpeed = new Speed();

                objCharacter.lstCharacterAbilities = objCharAbility.GetCharacterAbilities("CharacterID=" + objCharacter.CharacterID.ToString(), "");
                if (objCharacter.RaceID == 0) objCharacter.objRace = objRace; else objCharacter.objRace = objRace.GetRace(objCharacter.RaceID);
                objCharacter.lstDefenses = objDefObject.GetCharacterDefenses(objCharacter.CharacterID);
                objCharacter.lstEquipmentList = objCharEquipList.GetCharacterEquipmentList("CharacterID=" + objCharacter.CharacterID, "");
                objCharacter.lstCharacterClassLevels = objCharClassLevels.GetCharacterClassLevel(objCharacter.CharacterID);
                objCharacter.lstFeats = objFeat.GetCharacterFeats("CharacterID=" + objCharacter.CharacterID.ToString(), "FeatName");
                objCharacter.lstLanguages = objLang.GetCharacterLanguages(objCharacter.CharacterID);
                objCharacter.lstCharacterSkills = objCharacterSkill.GetCharacterSkills(objCharacter.CharacterID);
                objCharacter.lstTalents = objTalent.GetCharacterTalents(objCharacter.CharacterID);

                objCharacter.lstPrestigeRequirement = objPrestigeRequirement.GetCharacterPrestigeRequirement(objCharacter.CharacterID);
                objCharacter.lstForcePowers = objForcePower.GetCharacterForcePowers(objCharacter.CharacterID);
                objCharacter.lstCharacterLevels = objCharLevel.GetCharacterLevels("CharacterLevelID=" + objCharacter.CharacterLevelID.ToString(), "");
                objCharacter.lstCharacterOrganizations = objCharOrg.GetCharacterOrganizations(objCharacter.CharacterID);
                objCharacter.lstCharacterWeapons = objCharWeap.GetCharacterWeapons(objCharacter.CharacterID);
                objCharacter.lstCharacterArmors = objCharArmor.GetCharacterArmors(objCharacter.CharacterID);
                objCharacter.lstCharacterSpeeds = objCharSpeed.GetCharacterSpeeds(objCharacter.CharacterID );
                if (objCharacter.ForceTraditionID != 0) objForceTradition.GetForceTradition(objCharacter.ForceTraditionID);

                objCharacter.lstCharacterAbilities = objCharacter.lstCharacterAbilities.OrderBy(n => n.objAbility.SortOrder).ToList<CharacterAbility >();
                objCharacter.lstEquipmentList = objCharacter.lstEquipmentList.OrderBy(n => n.objEquipment.EquipmentName).ToList<CharacterEquipment>();
                objCharacter.lstCharacterClassLevels = objCharacter.lstCharacterClassLevels.OrderBy(n => n.objCharacterClass.ClassName).ToList<CharacterClassLevel>();
                objCharacter.lstLanguages = objCharacter.lstLanguages.OrderBy(n => n.LanguageName).ToList<Language>();
                objCharacter.lstCharacterSkills = objCharacter.lstCharacterSkills.OrderBy(n => n.objSkill.SkillName).ToList<CharacterSkill>();
                objCharacter.lstTalents = objCharacter.lstTalents.OrderBy(n => n.TalentName).ToList<Talent>();
                objCharacter.lstPrestigeRequirement = objCharacter.lstPrestigeRequirement.OrderBy(n => n.PrestigeRequirementDescription).ToList<PrestigeRequirement>();
                objCharacter.lstForcePowers = objCharacter.lstForcePowers.OrderBy(n => n.ForcePowerName).ToList<ForcePower>();
                objCharacter.lstCharacterOrganizations = objCharacter.lstCharacterOrganizations.OrderBy(n => n.OrganizationName).ToList<Organization>();
                objCharacter.lstCharacterWeapons = objCharacter.lstCharacterWeapons.OrderBy(n => n.objWeapon.WeaponName ).ToList<CharacterWeapon>();
                objCharacter.lstCharacterArmors = objCharacter.lstCharacterArmors.OrderBy(n => n.objArmor.ArmorName).ToList<CharacterArmor>();
                objCharacter.lstCharacterSpeeds = objCharacter.lstCharacterSpeeds.OrderBy(n => n.SpeedName).ToList<Speed>();

                
                
                objCharacter._objComboBoxData.Clear();
                objCharacter._objComboBoxData.Add(objCharacter.CharacterID, objCharacter.CharacterName);

            }
        }
        #endregion

        #endregion
    }
}
