using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarWarsClasses;


namespace StarWarsRPG
{
    class clsContainerObjects
    {
    }

    public partial class CharUpgradeButtonOptions
    {
        public int SetID { get; set; }
        public Button objButton { get; set; }
        public Label objLabel { get; set; }
    }

    public partial class  CharacterAddLevelContainer
    {
        public  int ClassLevel;
        public bool blnStartingFeatsAdded = false;

        public  Character objOriginalCharacter = new Character();
        public  CharacterLevel objNewCharLevel = new CharacterLevel();
        public  Class objSelectedClass = new Class();
        public  Character objCharacter = new Character();

        public Talent objSelectedTalent = new Talent();
        public Ability objAbility1Modified = new Ability();
        public Ability objAbility2Modified = new Ability();
        public Feat objBonusFeat = new Feat();
        public Feat objRaceFeat = new Feat();
        public Feat objCharLevelFeat = new Feat();
        public List<Feat> lstStartingFeat = new List<Feat>();
        public List<ForcePower> lstNewForcePowers = new List<ForcePower>();
        public List<CharacterSkill> lstNewSkills = new List<CharacterSkill>();
        public ForceSecret objForceSecret = new ForceSecret();
        public ForceTechnique objForceTechnique = new ForceTechnique();
        public List<Language> lstLanguages = new List<Language>();

        public  List<CharUpgradeButtonOptions> lstButtonsNeeded = new List<CharUpgradeButtonOptions>();

        #region Methods
        public List<CharUpgradeButtonOptions> RemoveCharUpgradeButtonFromList(Button CUBORemoveButton)
        {
            List<CharUpgradeButtonOptions> lstCUBO = new List<CharUpgradeButtonOptions>();

            foreach (CharUpgradeButtonOptions objCUBO in this.lstButtonsNeeded)
            {
                if (objCUBO.objButton.Text != CUBORemoveButton.Text)
                {
                    lstCUBO.Add(objCUBO);
                }
            }
            return lstCUBO;
        }

        public bool CharUpgradeButtonOptionsListContainsButton(Button CUBOSeekingButton)
        {
            bool retVal = false;

            foreach (CharUpgradeButtonOptions objCUBO in this.lstButtonsNeeded)
            {
                if (objCUBO.objButton.Text  == CUBOSeekingButton.Text  )
                {
                    retVal = true;
                }
            }
            return retVal;
        }

        public int lstButtonsNeededMaxSetID()
        {
            int retVal = 0;

            foreach (CharUpgradeButtonOptions objCUBO in this.lstButtonsNeeded)
            {
                if (objCUBO.SetID >= retVal)
                {
                    retVal = objCUBO.SetID;
                }
            }
            return retVal;
        }

        public int DetermineNumberOfLanguagesGained()
        {
            int intReturnVal = 0;
            int intFeatIDLangNum = 0;
            int intAbilityIncreaseLangNum = 0;

            Ability objAbility = new Ability("Intelligence");
            //Languages can be gained by Taking "Linguist" as a Feat (Bonus or Level)
            //Increasing Intelligence to gain a Int Mod point 
            //Or both

            //Linguist FeatID = 33// now in AppSettings
            if (objCharLevelFeat.FeatID == Common.GetAppSettingsID("LinguistFeatID"))
            {
                //The user has increase their Intelligence this level so we need to check the mod for this instance of Force Training
                if (objAbility1Modified.AbilityID == 2 || objAbility2Modified.AbilityID == 2)
                {
                    if ((((objCharacter.GetCharacterAbilityScore(objAbility) + 1) - 10) / 2) != objCharacter.GetCharacterAbilityModifier(objAbility))
                    {
                        intFeatIDLangNum = intFeatIDLangNum + objCharacter.GetCharacterAbilityModifier(objAbility) + 1;
                    }
                }
                else
                {
                    intFeatIDLangNum = intFeatIDLangNum + objCharacter.GetCharacterAbilityModifier(objAbility) + 1;
                }
            }

            //Has intelligence increased
            //The user has increase their Intelligence this level so we need to check the mod for this instance of Force Training
            if (objAbility1Modified.AbilityID == 2 || objAbility2Modified.AbilityID == 2)
            {
                if ((((objCharacter.GetCharacterAbilityScore(objAbility) + 1) - 10) / 2) != objCharacter.GetCharacterAbilityModifier(objAbility))
                {
                    intAbilityIncreaseLangNum = intAbilityIncreaseLangNum + 1;
                }
            }

            intReturnVal = intFeatIDLangNum + intAbilityIncreaseLangNum;
            return intReturnVal;
        }

        public int DetermineNumberOfSkillsGained()
        {
            int intReturnVal = 0;
            Ability objAbility = new Ability("Intelligence");

            //Skills can be added two ways.  Either by increasing Intelligence (and the Int Mod)
            //Or by Taking a skill training feat.

            //Skill Training Feats are handled as a feat and not here
            if (objAbility1Modified.AbilityID == 2 || objAbility2Modified.AbilityID == 2)
            {
                if ((((objCharacter.GetCharacterAbilityScore(objAbility) + 1) - 10) / 2) != objCharacter.GetCharacterAbilityModifier(objAbility))
                {
                    intReturnVal = (((objCharacter.GetCharacterAbilityScore(objAbility) + 1) - 10) / 2) - objCharacter.GetCharacterAbilityModifier(objAbility);
                }
            }

            //Is Character 1st level
            if (objCharacter.CharacterLevelID == 0)
            {
                intReturnVal = intReturnVal + objSelectedClass.StartingSkills + objCharacter.GetCharacterAbilityModifier(objAbility);
            }

            if ((objCharacter.CharacterLevelID == 0) && (objCharacter.objRace.BonusSkill)) intReturnVal = intReturnVal + 1;
            return intReturnVal;
        }

        public  int DetermineNumberOfForcePowersGained()
        {
            int intReturnVal = 0;
            int intFeatIDFPNum = 0;
            int intAbilityIncreaseFPNum = 0;
            //FP Can be gained by taking Force Training Feat (check the objCharLevelFeat object) (Wisdom Mod + 1)
            //FP Can be gained by increasing Wisdom, if modifier goes up then Character gets 1 FP per instance of  Force Training Feat
            //Or BOTH
            Ability objAbility = new Ability("Wisdom");

            //Force Training FeatID = 116
            if (objCharLevelFeat.FeatID == Common.GetAppSettingsID("ForceTrainingFeatID"))
            {
                if ((((objCharacter.GetCharacterAbilityScore(objAbility) + 1) - 10) / 2) != objCharacter.GetCharacterAbilityModifier(objAbility)) intFeatIDFPNum = intFeatIDFPNum + 1;

                //Its Wisdom Mod + 1 for the Feat
                intFeatIDFPNum = intFeatIDFPNum + objCharacter.GetCharacterAbilityModifier(objAbility) + 1;
            }

            if (objRaceFeat.FeatID == Common.GetAppSettingsID("ForceTrainingFeatID"))
            {
                if ((((objCharacter.GetCharacterAbilityScore(objAbility) + 1) - 10) / 2) != objCharacter.GetCharacterAbilityModifier(objAbility)) intFeatIDFPNum = intFeatIDFPNum + 1;

                //Its Wisdom Mod + 1 for the Feat
                intFeatIDFPNum = intFeatIDFPNum + objCharacter.GetCharacterAbilityModifier(objAbility) + 1;
            }

            //Has Wisdom incresed?
            if (objAbility1Modified.AbilityID == 3 || objAbility2Modified.AbilityID == 3)
            {
                //(([Strength]-(10))/(2))
                if ((((objCharacter.GetCharacterAbilityScore(objAbility) + 1) - 10) / 2) != objCharacter.GetCharacterAbilityModifier(objAbility))
                {
                    foreach (Feat objFeat in objCharacter.lstFeats)
                    {
                        if (objFeat.FeatID == 116) intAbilityIncreaseFPNum++;
                    }
                }
            }
            intReturnVal = intFeatIDFPNum + intAbilityIncreaseFPNum;
            return intReturnVal;
        }

        public bool ClassLevelInfoAvailable(Common.strClassLevelInfoProps parCLI)
        {
            ClassLevelInfo objCLI = new ClassLevelInfo();
            objCLI.GetClassLevel(objSelectedClass.ClassID, ClassLevel);

            bool returnVal = false;
            switch (parCLI)
            {
                case Common.strClassLevelInfoProps.Talent:
                    if (objCLI.Talent == 1) returnVal = true; else returnVal = false;
                    break;
                case Common.strClassLevelInfoProps.BonusFeat:
                    if (objCLI.BonusFeat == 1) returnVal = true; else returnVal = false;
                    break;
                case Common.strClassLevelInfoProps.ForceSecret:
                    if (objCLI.ForceSecret == 1) returnVal = true; else returnVal = false;
                    break;
                case Common.strClassLevelInfoProps.ForceTechnique:
                    if (objCLI.ForceTechnique == 1) returnVal = true; else returnVal = false;
                    break;
                default:
                    break;
            }

            return returnVal;
        }

        //public void AddCharacterStartingFeats(Class objClass)
        //{
        //    Feat objStartFeats = new Feat();
        //    List<Feat> lstStartFeats = new List<Feat>();
        //    lstStartFeats = objStartFeats.GetStartingFeats(objClass.ClassID);
        //    foreach (Feat objSF in lstStartFeats)
        //    {
        //        this.lstStartingFeat.Add(objSF);
        //    }
        //}

        //public void SetOrginalCharacter()
        //{
        //    //objOriginalCharacter = (Character) objCharacter.Clone() ;

        //    objOriginalCharacter = (Character) objCharacter.Clone();
        //}

        public void ResetContainerObjectByLevel(Common.ContainerObjectResetLevel objCORL)
        {
            switch (objCORL)
            {
                case Common.ContainerObjectResetLevel.Abilities:
                    this.objAbility1Modified = new Ability();
                    this.objAbility2Modified = new Ability();
                    break;
                case Common.ContainerObjectResetLevel.Talents:
                    this.objSelectedTalent = new Talent();
                    break;
                case Common.ContainerObjectResetLevel.Class:
                    this.objSelectedClass = new Class();
                    //Check if they are first level, if so remove feats (Starting Feats)
                    if (this.objCharacter.CharacterLevelID == 0)
                    {
                        this.blnStartingFeatsAdded = false;
                        this.objCharacter.lstFeats = new List<Feat>();
                    }
                    break;
                case Common.ContainerObjectResetLevel.Character:
                    this.objCharacter = Character.Clone(this.objOriginalCharacter );
                    break;
                case Common.ContainerObjectResetLevel.BonusFeat:
                    this.objBonusFeat = new Feat();
                    break;
                case Common.ContainerObjectResetLevel.RaceFeat:
                    this.objRaceFeat  = new Feat();
                    break;
                case Common.ContainerObjectResetLevel.LevelFeat:
                    this.objCharLevelFeat  = new Feat();
                    break;
                case Common.ContainerObjectResetLevel.StartingFeat:
                    this.lstStartingFeat = new List<Feat>();
                    break;
                case Common.ContainerObjectResetLevel.ForcePowers:
                    this.lstNewForcePowers = new List<ForcePower>();
                    break;
                case Common.ContainerObjectResetLevel.Skills:
                    this.lstNewSkills = new List<CharacterSkill>();
                    break;
                case Common.ContainerObjectResetLevel.ForceSecret:
                    this.objForceSecret = new ForceSecret();
                    break;
                case Common.ContainerObjectResetLevel.ForceTechnique:
                    this.objForceTechnique = new ForceTechnique();
                    break;
                case Common.ContainerObjectResetLevel.Languages:
                    this.lstLanguages = new List<Language>();
                    break;
                case Common.ContainerObjectResetLevel.ButtonsNeeded:
                    this.lstButtonsNeeded = new List<CharUpgradeButtonOptions>();
                    break;
                case Common.ContainerObjectResetLevel.All:
                    this.objAbility1Modified = new Ability();
                    this.objAbility2Modified = new Ability();
                    this.objSelectedTalent = new Talent();
                    this.objSelectedClass = new Class();
                    this.blnStartingFeatsAdded = false;
                    this.objCharacter = Character.Clone(objOriginalCharacter);
                    this.objBonusFeat = new Feat();
                    this.objRaceFeat = new Feat();
                    this.objCharLevelFeat = new Feat();
                    this.lstStartingFeat = new List<Feat>();
                    this.lstNewForcePowers = new List<ForcePower>();
                    this.lstNewSkills = new List<CharacterSkill>();
                    this.objForceSecret = new ForceSecret();
                    this.objForceTechnique = new ForceTechnique();
                    this.lstLanguages = new List<Language>();
                    this.lstButtonsNeeded = new List<CharUpgradeButtonOptions>();
                    break;
                case Common.ContainerObjectResetLevel.AllButCharacter :
                    this.objAbility1Modified = new Ability();
                    this.objAbility2Modified = new Ability();
                    this.objSelectedTalent = new Talent();
                    this.objSelectedClass = new Class();
                    this.blnStartingFeatsAdded = false;
                    this.objBonusFeat = new Feat();
                    this.objRaceFeat = new Feat();
                    this.objCharLevelFeat = new Feat();
                    this.lstStartingFeat = new List<Feat>();
                    this.lstNewForcePowers = new List<ForcePower>();
                    this.lstNewSkills = new List<CharacterSkill>();
                    this.objForceSecret = new ForceSecret();
                    this.objForceTechnique = new ForceTechnique();
                    this.lstLanguages = new List<Language>();
                    this.lstButtonsNeeded = new List<CharUpgradeButtonOptions>();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }



}
