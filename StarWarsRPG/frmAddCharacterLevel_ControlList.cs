using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using GenericCharacterGenerator;
using StarWarsClasses;
using CharacterGenerator;
using Dice;

namespace StarWarsRPG
{
    public partial class frmAddCharacterLevel_ControlList : Form
    {

        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        //New Object that contains all the above items
        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();

        private static int intMaxObjs = 13;
        private Point[] arryButtonLoc = new Point[intMaxObjs];
        private Point[] arryLabelLoc = new Point[intMaxObjs];
        private bool blnResetCharacter = true;

        public frmAddCharacterLevel_ControlList()
        {
            //objCALC.objOriginalCharacter = objCALC.objCharacter;
            //objCALC.SetOrginalCharacter();
            InitializeComponent();
            SetButtonLocationArray();
            SetButtonLocations();
            SetLabelsAndOptions();
            lblInfo.Text = "As a level " + objCALC.ClassLevel.ToString() + " " + objCALC.objSelectedClass.ClassName + "; Character Level " + objCALC.objNewCharLevel.CharacterLevelID.ToString() + ", you may choose the items to the left.";
        }

        #region Form Events
        private void btnTalentAddition_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_TalentSelection.objCALC = objCALC;

            frmAddCharacterLevel_TalentSelection frmAddCharLevel_Talent = new frmAddCharacterLevel_TalentSelection();
            frmAddCharLevel_Talent.Show();
            HandleFormClose();

        }

        private void btnBonusFeat_Click(object sender, EventArgs e)
        {

            frmAddCharacterLevel_FeatSelection.enmFeatType = Common.FeatType.BonusFeat ;
            frmAddCharacterLevel_FeatSelection.objCALC = objCALC;

            frmAddCharacterLevel_FeatSelection frmAddCharLevel_Feat = new frmAddCharacterLevel_FeatSelection();
            frmAddCharLevel_Feat.Show();
            HandleFormClose();

        }

        private void btnLevelFeat_Click(object sender, EventArgs e)
        {

            frmAddCharacterLevel_FeatSelection.enmFeatType = Common.FeatType.LevelFeat;

            frmAddCharacterLevel_FeatSelection.objCALC = objCALC;

            frmAddCharacterLevel_FeatSelection frmAddCharLevel_Feat = new frmAddCharacterLevel_FeatSelection();

            frmAddCharLevel_Feat.Show();
            HandleFormClose();
        }

        private void btnForcePower_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_ForcePowerSelect.ForcePowerCount = objCALC.DetermineNumberOfForcePowersGained();
            frmAddCharacterLevel_ForcePowerSelect.objCALC = objCALC;
            
            frmAddCharacterLevel_ForcePowerSelect frmAddCharLevel_Feat = new frmAddCharacterLevel_ForcePowerSelect();

            frmAddCharLevel_Feat.Show();
            HandleFormClose();
        }

        private void btnForceSecret_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_ForceSecretSelection.objCALC = objCALC;

            frmAddCharacterLevel_ForceSecretSelection frmAddCharLevel_ForceSecret = new frmAddCharacterLevel_ForceSecretSelection();

            frmAddCharLevel_ForceSecret.Show();
            HandleFormClose();
        }

        private void btnForceTechnique_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_ForceTechniqueSelection.objCALC = objCALC;

            frmAddCharacterLevel_ForceTechniqueSelection frmAddCharLevel_ForceTechique = new frmAddCharacterLevel_ForceTechniqueSelection();

            frmAddCharLevel_ForceTechique.Show();
            HandleFormClose();
        }

        private void btnLanguages_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_LanguageSelect.LanguageCount = objCALC.DetermineNumberOfLanguagesGained();
            frmAddCharacterLevel_LanguageSelect.objCALC = objCALC;

            frmAddCharacterLevel_LanguageSelect frmAddCharLevel_Feat = new frmAddCharacterLevel_LanguageSelect();

            frmAddCharLevel_Feat.Show();
            HandleFormClose();
        }

        private void btnAbilityIncrease_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_AbilityIncrease.objCALC = objCALC;

            frmAddCharacterLevel_AbilityIncrease frmAddCharLevel_AbilityIncrease = new frmAddCharacterLevel_AbilityIncrease();

            frmAddCharLevel_AbilityIncrease.Show();
            HandleFormClose();
        }

        private void btnSkills_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_SkillSelection.MaxSkillCount = objCALC.DetermineNumberOfSkillsGained();
            frmAddCharacterLevel_SkillSelection.objCALC = objCALC;

            frmAddCharacterLevel_SkillSelection frmAddCharLevel_SkillAddition = new frmAddCharacterLevel_SkillSelection();

            frmAddCharLevel_SkillAddition.Show();
            HandleFormClose();
        }

        private void btnStartingFeat_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_FeatSelection.enmFeatType = Common.FeatType.StartingFeat ;

            frmAddCharacterLevel_FeatSelection.objCALC = objCALC;

            frmAddCharacterLevel_FeatSelection frmAddCharLevel_Feat = new frmAddCharacterLevel_FeatSelection();

            frmAddCharLevel_Feat.Show();
            HandleFormClose();
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCommitChanges_Click(object sender, EventArgs e)
        {
            //Save Class Level
            CharacterClassLevel objNewCL = new CharacterClassLevel();
            objNewCL.ClassID = objCALC.objSelectedClass.ClassID;
            objNewCL.ClassLevel = objCALC.ClassLevel;
            objNewCL.CharacterID = objCALC.objCharacter.CharacterID;
            objNewCL.SaveCharacterClassLevel();

            //Update New Character Level 
            objCALC.objCharacter.CharacterLevelID = objCALC.objNewCharLevel.CharacterLevelID;

            //Add Talent
            if (objCALC.objSelectedTalent.TalentName != null)
            {
                objCALC.objSelectedTalent.SaveCharacterTalent(objCALC.objCharacter.CharacterID, objCALC.objSelectedTalent.TalentID);
            }

            //Add objAbility1Modified
            if (objCALC.objAbility1Modified.AbilityName  != null)
            {
                Ability.IncreaseCharacterAbility(objCALC.objAbility1Modified.AbilityID, 1,ref objCALC.objCharacter);
            }

            //Add objAbility2Modified
            if (objCALC.objAbility2Modified.AbilityName != null)
            {
                Ability.IncreaseCharacterAbility(objCALC.objAbility2Modified.AbilityID, 1, ref objCALC.objCharacter);
            }

            //Add Bonus Feat
            if (objCALC.objBonusFeat.FeatName != null) objCALC.objBonusFeat.SaveCharacterFeat(objCALC.objCharacter.CharacterID, objCALC.objBonusFeat.FeatID);

            //Add Level Feat
            if (objCALC.objCharLevelFeat.FeatName != null) objCALC.objCharLevelFeat.SaveCharacterFeat(objCALC.objCharacter.CharacterID, objCALC.objCharLevelFeat.FeatID);

            //Add Starting Feat
            if (objCALC.lstStartingFeat.Count > 0)
            {
                foreach (Feat objSF in objCALC.lstStartingFeat)
                {
                    objSF.SaveCharacterFeat(objCALC.objCharacter.CharacterID, objSF.FeatID);
                }
            }

            //Add Force Powers
            if (objCALC.lstNewForcePowers.Count > 0)
            {
                foreach (ForcePower objFP in objCALC.lstNewForcePowers )
                {
                    objFP.SaveCharacterForcePower(objCALC.objCharacter.CharacterID, objFP.ForcePowerID);
                }
            }

            //Add Character Skill
            if (objCALC.lstNewSkills.Count > 0)
            {
                foreach (CharacterSkill  objCS in objCALC.lstNewSkills)
                {
                    objCS.AbilityMod = Ability.GetAbilityMod(objCS.objSkill.objAbility.AbilityID, objCALC.objCharacter);
                    objCS.HalfLevel = objCALC.objCharacter.CharacterLevelID / 2;
                    if (CharacterSkill.DoesCharacterHaveSkillFocusForSkill(objCS.objSkill.SkillID, objCALC.objCharacter)) objCS.SkillFocus = 5; else objCS.SkillFocus = 0;
                    objCS.Trained = 5;   //Added a skill, don't check the skill training Feat
                    objCS.Miscellaneous = 0;
                    objCS.CharacterID = objCALC.objCharacter.CharacterID;
                    objCS.SaveCharacterSkill();
                }
            }

            if (objCALC.objForceSecret.ForceSecretName != null)
            {
                //save character force secret
                objCALC.objForceSecret.SaveCharacterForceSecret(objCALC.objCharacter.CharacterID);
            }

            if (objCALC.objForceTechnique.ForceTechniqueName != null)
            {
                //save character force secret
                objCALC.objForceTechnique.SaveCharacterForceTechnique(objCALC.objCharacter.CharacterID);
            }

            //Add Languages
            if (objCALC.lstLanguages.Count > 0)
            {
                foreach (Language objLan in objCALC.lstLanguages)
                {
                    objLan.SaveCharacterLanguage(objCALC.objCharacter.CharacterID, objLan.LanguageID );
                }
            }

            //Now that we have added a Character Level's objects, we need to update the character.
            //Hit Points

            Ability objAbility = new Ability("Constitution");
            Die objDie = new Die(objCALC.objSelectedClass.HitDieType );

            objCALC.objCharacter.HitPoints = objCALC.objCharacter.HitPoints + objDie.GenerateRandomNumber() + objCALC.objCharacter.GetCharacterAbilityModifier(objAbility);

            //Base Attack
            ClassLevelInfo objCLI = new ClassLevelInfo();
            objCLI.GetClassLevel(objCALC.objSelectedClass.ClassID , objCALC.ClassLevel );
            objCALC.objCharacter.BaseAttack = objCALC.objCharacter.BaseAttack + objCLI.BaseAttack;

            //Grapple

            //Skill Increase

            //Defense Modifications

            //Weapon To hit / Damage

            //Damage Thresold

            //Reset force points

            //Increase Destiny Points ? 
        }

        private void btnRaceFeat_Click(object sender, EventArgs e)
        {
            frmAddCharacterLevel_FeatSelection.enmFeatType = Common.FeatType.RaceFeat;

            frmAddCharacterLevel_FeatSelection.objCALC = objCALC;

            frmAddCharacterLevel_FeatSelection frmAddRaceLevel_Feat = new frmAddCharacterLevel_FeatSelection();

            frmAddRaceLevel_Feat.Show();
            HandleFormClose();
        }

        private void frmAddCharacterLevel_ControlList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (blnResetCharacter) objCALC.ResetContainerObjectByLevel(Common.ContainerObjectResetLevel.All);
        }
        #endregion

        #region Methods
        private void HandleFormClose()
        {
            blnResetCharacter = false;
            this.Close();
        }

        private void SetButtonLocations()
        {
            int currentLoc = 0;
            CharUpgradeButtonOptions objCurr = new CharUpgradeButtonOptions();

            int intForceRegimenMastery = Common.GetAppSettingsID("ForceRegimenMasteryID");
            int intForceTrainingID = Common.GetAppSettingsID("ForceTrainingFeatID");

            //Determine what buttons are needed and put them in an array
            if (objCALC.lstButtonsNeeded.Count == 0)
            {
                //Check to see whats needed - Talent
                if (objCALC.ClassLevelInfoAvailable(Common.strClassLevelInfoProps.Talent)) 
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnTalentAddition;
                    objCurr.objLabel = this.lblTalentAddition;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }
 
                // - Bonus Feat
                if (objCALC.ClassLevelInfoAvailable(Common.strClassLevelInfoProps.BonusFeat))
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnBonusFeat;
                    objCurr.objLabel = this.lblBonusFeat;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                } 

                // - Race Feat
                if ((objCALC.objCharacter.objRace.BonusFeat) && (objCALC.objCharacter.CharacterLevelID == 0))
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnRaceFeat ;
                    objCurr.objLabel = this.lblRaceFeat;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }

                // - Character Level 
                if (objCALC.objNewCharLevel.FeatAvailable)
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnLevelFeat;
                    objCurr.objLabel = this.lblLevelFeat;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }
                
                // - Force Powers
                if (objCALC.objCharacter.ForcePowersAvailableForSelection(intForceTrainingID, objCALC.objCharLevelFeat, objCALC.objRaceFeat , objCALC.objAbility1Modified, objCALC.objAbility2Modified))
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnForcePower;
                    objCurr.objLabel = this.lblForcePowers;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }
                
                //Check to see whats needed - Force Secret
                if (objCALC.ClassLevelInfoAvailable(Common.strClassLevelInfoProps.ForceSecret))
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnForceSecret;
                    objCurr.objLabel = this.lblForceSecret;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                } 
                
                // - Force Technique
                if (objCALC.ClassLevelInfoAvailable(Common.strClassLevelInfoProps.ForceTechnique)) 
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnForceTechnique;
                    objCurr.objLabel = this.lblForceTechnique;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }

                // - Languages
                if (objCALC.DetermineNumberOfLanguagesGained() > 0)
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnForceTechnique;
                    objCurr.objLabel = this.lblForceTechnique;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }

                // - Abilities Increase
                if (objCALC.objNewCharLevel.AbilityIncrease )
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnAbilityIncrease;
                    objCurr.objLabel = this.lblAbilitiesIncrease;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }

                // - Skills Increase - We can use the Number of Languages
                if (objCALC.DetermineNumberOfSkillsGained() > 0)
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnSkills;
                    objCurr.objLabel = this.lblSkills;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }

                // - Starting Feat
                if ((objCALC.ClassLevel == 1) && (objCALC.objNewCharLevel.CharacterLevelID != 1))
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnStartingFeat ;
                    objCurr.objLabel = this.lblStartingFeat ;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                }
                else
                {
                    if ((objCALC.ClassLevel == 1) && (objCALC.objCharacter.CharacterLevelID == 0))
                    {
                        //add the starting feats for this class
                        if (!objCALC.blnStartingFeatsAdded)
                        {
                            objCALC.objCharacter.AddCharacterStartingFeats(objCALC.objSelectedClass);
                            objCALC.blnStartingFeatsAdded = true;
                        }
                    }
                }

                // - Force Regimen
                if (objCALC.objCharacter.ForceRegimenAvailableForSelection(intForceRegimenMastery, objCALC.objCharLevelFeat, objCALC.objRaceFeat, objCALC.objAbility1Modified, objCALC.objAbility2Modified))
                {
                    objCurr.SetID = currentLoc;
                    objCurr.objButton = this.btnForceRegiem ;
                    objCurr.objLabel = this.lblForceRegiem ;
                    objCALC.lstButtonsNeeded.Add(objCurr);
                    objCurr = new CharUpgradeButtonOptions();
                    currentLoc++;
                } 

                currentLoc = 0;
                foreach (CharUpgradeButtonOptions objCUBO in objCALC.lstButtonsNeeded)
                {
                    objCUBO.objButton.Location = GetFormButton(objCUBO.objButton.Name).Location = arryButtonLoc[objCUBO.SetID];
                    objCUBO.objButton.Visible = true;
                    objCUBO.objLabel.Location = GetFormLabel(objCUBO.objLabel.Name).Location = arryLabelLoc[objCUBO.SetID];

                }
            }

            else
            {
                //Do we need to turn some of the buttons OFF base on a feat that was selected and now changed
                if (objCALC.CharUpgradeButtonOptionsListContainsButton(this.btnForcePower))
                {
                    //If we have them we need to see if either the abilities have increase OR the Feat (Race or Level) is a force Training, 
                    //If the ability hasn't increased and the feat is not a ForceTrainingID then we clear out the Force Powers
                    if (!objCALC.objCharacter.ForcePowersAvailableForSelection(intForceTrainingID, objCALC.objCharLevelFeat, objCALC.objRaceFeat, objCALC.objAbility1Modified, objCALC.objAbility2Modified))
                    {
                        //Remove the button and clear out the lst of ForcePowers.
                        objCALC.lstButtonsNeeded = objCALC.RemoveCharUpgradeButtonFromList(this.btnForcePower);
                        SetButtonLocationList();
                    }

                    //make sure we don't have too many force powers
                    if (objCALC.lstNewForcePowers.Count > objCALC.DetermineNumberOfForcePowersGained())
                    {
                        objCALC.lstNewForcePowers = new List<ForcePower>();
                        this.lblForcePowers.Text  = "";
                    }
  
                }
                //Do we need to Turn some of the button on based on a Feat Selection (Force Power, Force Regimen, etc)

                if (objCALC.objCharLevelFeat.FeatID == intForceTrainingID || objCALC.objRaceFeat.FeatID == intForceTrainingID )
                {
                    //The Char Level Feat Selected is one requiring a Selection of another Entity (Force Power)
                    //Check to see if the buttons already enabled.
                    if (!objCALC.CharUpgradeButtonOptionsListContainsButton(this.btnForcePower))
                    {
                        CharUpgradeButtonOptions objFPCurr = new CharUpgradeButtonOptions();
                        objFPCurr.SetID = objCALC.lstButtonsNeededMaxSetID() + 1;
                        objFPCurr.objButton = this.btnForcePower;
                        objFPCurr.objLabel = this.lblForcePowers;
                        objFPCurr.objButton.Location = GetFormButton(objFPCurr.objButton.Name).Location = arryButtonLoc[objFPCurr.SetID];
                        objFPCurr.objLabel.Location = GetFormLabel(objFPCurr.objLabel.Name).Location = arryLabelLoc[objFPCurr.SetID];
                        objCALC.lstButtonsNeeded.Add(objFPCurr);
                    }
                }
                if (objCALC.objCharLevelFeat.FeatID == intForceRegimenMastery || objCALC.objRaceFeat.FeatID == intForceRegimenMastery)
                {
                    //The Char Level Feat Selected is one requiring a Selection of another Entity (Force Power , Force Regimen, etc)
                    //Check to see if the buttons already enabled.
                    if (!objCALC.CharUpgradeButtonOptionsListContainsButton(this.btnForceRegiem))
                    {
                        CharUpgradeButtonOptions objFPCurr = new CharUpgradeButtonOptions();
                        objFPCurr.SetID = objCALC.lstButtonsNeededMaxSetID() + 1;
                        objFPCurr.objButton = this.btnForceRegiem;
                        objFPCurr.objLabel = this.lblForceRegiem;
                        objFPCurr.objButton.Location = GetFormButton(objFPCurr.objButton.Name).Location = arryButtonLoc[objFPCurr.SetID];
                        objFPCurr.objLabel.Location = GetFormLabel(objFPCurr.objLabel.Name).Location = arryLabelLoc[objFPCurr.SetID];
                        objCALC.lstButtonsNeeded.Add(objFPCurr);
                    }
                }

                //Turn the buttons back on, we are comming back into the form (maybe)
                foreach (CharUpgradeButtonOptions objCUBO in objCALC.lstButtonsNeeded)
                {
                    //objCUBO.objButton.Visible 
                    switch (objCUBO.objButton.Name)
                    {
                        case "btnTalentAddtion":
                            this.btnTalentAddition.Visible = true;
                            this.btnTalentAddition.Location = objCUBO.objButton.Location;
                            this.lblTalentAddition.Location = objCUBO.objLabel.Location;
                            break;
                        case "btnAbilityIncrease":
                            this.btnAbilityIncrease.Visible = true;
                            this.btnAbilityIncrease.Location = objCUBO.objButton.Location;
                            this.lblAbilitiesIncrease.Location = objCUBO.objLabel.Location;
                           break;
                        case "btnBonusFeat":
                            this.btnBonusFeat.Visible = true;
                            this.btnBonusFeat.Location = objCUBO.objButton.Location;
                            this.lblBonusFeat.Location = objCUBO.objLabel.Location;
                       break;
                        case "btnRaceFeat":
                           this.btnRaceFeat.Visible = true;
                           this.btnRaceFeat.Location = objCUBO.objButton.Location;
                           this.lblRaceFeat.Location = objCUBO.objLabel.Location;
                       break;
                        case "btnForcePower":
                            this.btnForcePower.Visible = true;
                            this.btnForcePower.Location = objCUBO.objButton.Location;
                            this.lblForcePowers .Location = objCUBO.objLabel.Location;
                          break;
                        case "btnForceSecret":
                            this.btnForceSecret.Visible = true;
                            this.btnForceSecret.Location = objCUBO.objButton.Location;
                            this.lblForceSecret .Location = objCUBO.objLabel.Location;
                         break;
                        case "btnForceTechnique":
                            this.btnForceTechnique.Visible = true;
                            this.btnForceTechnique.Location = objCUBO.objButton.Location;
                            this.lblForceTechnique .Location = objCUBO.objLabel.Location;
                           break;
                        case "btnLanguages":
                            this.btnLanguages.Visible = true;
                            this.btnLanguages.Location = objCUBO.objButton.Location;
                            this.lblLanguages .Location = objCUBO.objLabel.Location;
                         break;
                        case "btnLevelFeat":
                            this.btnLevelFeat.Visible = true;
                            this.btnLevelFeat.Location = objCUBO.objButton.Location;
                            this.lblLevelFeat .Location = objCUBO.objLabel.Location;
                          break;
                        case "btnSkills":
                            this.btnSkills.Visible = true;
                            this.btnSkills.Location = objCUBO.objButton.Location;
                            this.lblSkills .Location = objCUBO.objLabel.Location;
                           break;
                        case "btnStartingFeat":
                           this.btnStartingFeat.Visible = true;
                           this.btnStartingFeat.Location = objCUBO.objButton.Location;
                           this.lblStartingFeat.Location = objCUBO.objLabel.Location;
                           break;
                        case "btnForceRegiem":
                           this.btnForceRegiem.Visible = true;
                           this.btnForceRegiem.Location = objCUBO.objButton.Location;
                           this.lblForceRegiem.Location = objCUBO.objLabel.Location;
                           break;
                        default:
                            btnTalentAddition.Visible = true;
                            this.btnTalentAddition.Location = objCUBO.objButton.Location;
                            this.lblTalentAddition.Location = objCUBO.objLabel.Location;
                            break;
                    }
                }
            }
        }

        private Label GetFormLabel (string strLabelName)
        {
            switch (strLabelName)
            {
                case "lblTalentAddition":
                    return this.lblTalentAddition ;
                case "lblAbilitiesIncrease":
                    return this.lblAbilitiesIncrease ;
                case "lblBonusFeat":
                    return this.lblBonusFeat ;
                case "lblForcePowers":
                    return this.lblForcePowers ;
                case "lblForceSecret":
                    return this.lblForceSecret ;
                case "lblForceTechnique":
                    return this.lblForceTechnique ;
                case "lblLanguages":
                    return this.lblLanguages ;
                case "lblLevelFeat":
                    return this.lblLevelFeat ;
                case "lblSkills":
                    return this.lblSkills;
                case "lblStartingFeat":
                    return this.lblStartingFeat;
                case "lblRaceFeat":
                    return this.lblRaceFeat;
                default:
                    return lblTalentAddition;
            }
        }

        private Button GetFormButton(string strButtonName)
        {
            switch (strButtonName)
            {
                case "btnTalentAddtion":
                    return this.btnTalentAddition;
                case "btnAbilityIncrease":
                    return this.btnAbilityIncrease;
                case "btnBonusFeat":
                    return this.btnBonusFeat;
                case "btnForcePower":
                    return this.btnForcePower;
                case "btnForceSecret":
                    return this.btnForceSecret;
                case "btnForceTechnique":
                    return this.btnForceTechnique;
                case "btnLanguages":
                    return this.btnLanguages;
                case "btnRaceFeat":
                    return this.btnRaceFeat;
                case "btnLevelFeat":
                    return this.btnLevelFeat;
                case "btnSkills":
                    return this.btnSkills;
                case "btnStartingFeat":
                    return this.btnStartingFeat ;
                default:
                    return btnTalentAddition;
            }
        }

        private void SetButtonLocationList()
        {
            int intButtonX = 32;
            int intLabelX = 168;
            int intStartY = 28;
            int intButtonHeight = 36;

            foreach (CharUpgradeButtonOptions objCUBO in objCALC.lstButtonsNeeded)
            {
                Point ptBtn = new Point(intButtonX, intStartY);
                Point ptLbl = new Point(intLabelX, intStartY);
                objCUBO.objButton.Location = ptBtn;
                objCUBO.objLabel.Location = ptLbl;

                intStartY = intStartY + intButtonHeight;
            }
        }

        private void SetButtonLocationArray()
        {
            int intButtonX = 32;
            int intLabelX = 168;
            int intStartY = 28;
            int intButtonHeight = 36;

            for (int i = 0; i < intMaxObjs; i++)
            {
                Point ptBtn = new Point(intButtonX, intStartY);
                Point ptLbl = new Point(intLabelX, intStartY);

                arryButtonLoc[i] = ptBtn;
                arryLabelLoc[i] = ptLbl;
                intStartY = intStartY + intButtonHeight;
            }
        }

        private void SetLabelsAndOptions()
        {
            //Labels
            if (objCALC.objSelectedTalent.TalentName != null)
             {
                 lblTalentAddition.Visible = true;
                 lblTalentAddition.Text = "Talent Selected: " + objCALC.objSelectedTalent.TalentName;
             }
             if (objCALC.objBonusFeat.FeatName != null)
             {
                 lblBonusFeat.Visible = true;
                 lblBonusFeat.Text = "Bonus Feat Selected: " + objCALC.objBonusFeat.FeatName; ;
             }
            if (objCALC.objRaceFeat.FeatName != null)
            {
                lblBonusFeat.Visible = true;
                lblBonusFeat.Text = "Race Feat Selected: " + objCALC.objRaceFeat.FeatName;
            }
             if (objCALC.objCharLevelFeat.FeatName != null)
             {
                 lblLevelFeat.Visible = true;
                 lblLevelFeat.Text = "Level Feat Selected: " + objCALC.objCharLevelFeat.FeatName;
             }

             if (objCALC.lstNewForcePowers.Count > 0)
             {
                 lblForcePowers.Visible = true;
                 string strFPLabel = "";
                 foreach (ForcePower objFP in objCALC.lstNewForcePowers)
                 {
                     strFPLabel = strFPLabel + objFP.ForcePowerName + ", ";
                 }
                 lblForcePowers.Text = "Force Power(s) Selected: " + strFPLabel.Substring(0, strFPLabel.Length - 2);
             }

             if (objCALC.objForceSecret.ForceSecretName != null)
            {
                lblForceSecret.Visible = true;
                lblForceSecret.Text = "Force Secret Selected: " + objCALC.objForceSecret.ForceSecretName;
            }

             if (objCALC.objForceTechnique.ForceTechniqueName != null)
            {
                lblForceTechnique.Visible = true;
                lblForceTechnique.Text = "Force Technique Selected: " + objCALC.objForceTechnique.ForceTechniqueName;
            }

             if (objCALC.lstLanguages.Count > 0)
            {
                lblLanguages.Visible = true;
                string strLangLabel = "";
                foreach (Language objLang in objCALC.lstLanguages)
                {
                    strLangLabel = strLangLabel + objLang.LanguageName  + ", ";
                }
                lblLanguages.Text = "Language(s) Selected: " + strLangLabel.Substring(0, strLangLabel.Length - 2);
            }

             if (objCALC.objAbility1Modified.AbilityName != null || objCALC.objAbility2Modified.AbilityName != null)
            {
                lblAbilitiesIncrease.Visible = true;
                string strAbilityIncLabel = "";

                if (objCALC.objAbility1Modified.AbilityName != null)
                {
                    strAbilityIncLabel = objCALC.objAbility1Modified.AbilityName;
                }
                if (objCALC.objAbility2Modified.AbilityName != null)
                {
                    strAbilityIncLabel = strAbilityIncLabel + ", " + objCALC.objAbility2Modified.AbilityName;
                }
                lblAbilitiesIncrease.Text = "Abilities Increased: " + strAbilityIncLabel; 
            }

             if (objCALC.lstNewSkills.Count > 0)
            {
                lblSkills.Visible = true;
                string strSkillLabel = "";
                foreach (CharacterSkill objCS in objCALC.lstNewSkills)
                {
                    strSkillLabel = strSkillLabel + objCS.objSkill.SkillName + ", ";
                }
                lblSkills.Text = "Skills(s) Selected: " + strSkillLabel.Substring(0, strSkillLabel.Length - 2);
            }

             if (objCALC.lstStartingFeat.Count == 1)
             {
                 lblStartingFeat.Visible = true;
                 lblStartingFeat.Text = "Starting Feat Selected: " + objCALC.lstStartingFeat[0].FeatName;
             }

        }
        #endregion











    }


}
