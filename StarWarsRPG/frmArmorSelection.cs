using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarWarsClasses;
using SWRPG_Custom_Windows_Controls;

namespace StarWarsRPG
{
    public partial class frmArmorSelection : Form
    {
        public static Character objCharacter;
        private int intArmorSelectedID = 0;


        public frmArmorSelection()
        {
            InitializeComponent();
            LoadTreeView();
            CheckCharacterArmorProficiencyCheckBoxStatus();
        }

        public frmArmorSelection(int ArmorID)
        {
            InitializeComponent();
            LoadTreeView();
            CheckCharacterArmorProficiencyCheckBoxStatus();

            Armor objArmor = new Armor(ArmorID);
            SetArmorFields(objArmor);

            foreach (TreeNode objTN in tvArmorList.Nodes)
            {
                Armor objTreeArmor = new Armor((int)objTN.Tag);
                if (objTreeArmor.ArmorID == ArmorID) tvArmorList.SelectedNode = objTN;
            }
        }

        #region Methods
        private void LoadTreeView()
        {
            tvArmorList.Nodes.Clear();

            List<Armor> lstArmors = new List<Armor>();
            Armor objArmor = new Armor();

            if (!ckbHideNonProficientArmors.Enabled) lstArmors = objArmor.GetArmors("", "ArmorName");
            else if (ckbHideNonProficientArmors.Checked)
            {
                //Hide Non Proficent Weapons
                lstArmors = objArmor.GetCharacterProficientArmors(objCharacter.CharacterID);
            }
            else
            {
                //Show All Weapons
                lstArmors = objArmor.GetArmors("", "ArmorName");
            }

            foreach (Armor objListArmor in lstArmors)
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objListArmor.ArmorName;
                objTN.Tag = objListArmor.ArmorID;
                tvArmorList.Nodes.Add(objTN);
            }


        }

        private void CheckCharacterArmorProficiencyCheckBoxStatus()
        {
            if (objCharacter.CharacterID == 0) this.ckbHideNonProficientArmors.Enabled = false; else this.ckbHideNonProficientArmors.Enabled = true;
        }

        private void SetArmorFields(Armor objArmor)
        {
            string strArmorAvail = "";
            bool blnCharacterProfWithArmor = false;

            intArmorSelectedID = objArmor.ArmorID;
            this.txtArmorName.Text = objArmor.ArmorName;
            this.txtMaxDefBonus.Text = objArmor.MaxDefBonus.ToString();
            this.txtEmplacementPoints.Text = objArmor.EmplacementPoints.ToString();
            this.txtReflexAdj.Text = objArmor.ReflexAdjustment.ToString();
            this.txtFortAdj.Text = objArmor.FortitudeAdjustment.ToString();
            this.txtArmorType.Text  = objArmor.objArmorType.ArmorTypeName;
            this.txtArmorCost.Text = objArmor.Cost.ToString();
            this.txtWeight.Text = objArmor.Weight.ToString();
            this.txtBookName.Text = objArmor.objBook.BookName;
            this.txtArmorProficiencyFeat.Text = objArmor.objArmorProfFeat.FeatName;
            this.txtArmorDescription.Text = objArmor.ArmorDescription;

            if (objArmor.lstArmorAvailability.Count > 0)
            {
                foreach (ItemAvailabilityType objIAT in objArmor.lstArmorAvailability)
                {
                    strArmorAvail = strArmorAvail + objIAT.ItemAvailabilityTypeName + ", ";
                }
                strArmorAvail = strArmorAvail.Substring(0, strArmorAvail.Length - 2);
            }
            txtAvailability.Text = strArmorAvail;

            //Character Specific Data
            this.txtReflexCurrent.Text = CharacterDefense.GetReflexDefense(objCharacter).GetDefenseTotal().ToString();
            this.txtFortCurrent.Text = CharacterDefense.GetFortitudeDefense(objCharacter).GetDefenseTotal().ToString();

            blnCharacterProfWithArmor = Feat.IsFeatInList(objArmor.objArmorProfFeat, objCharacter.lstFeats);

            if (blnCharacterProfWithArmor)
            {
                this.txtReflexWithArmor.Text = CharacterDefense.GetReflexDefense(objCharacter).GetDefenseTotal(objArmor.ReflexAdjustment, 0).ToString();
                this.txtFortCurrent.Text = CharacterDefense.GetFortitudeDefense(objCharacter).GetDefenseTotal(objArmor.FortitudeAdjustment, 0).ToString();
            }
            else
            {
                this.txtReflexWithArmor.Text = CharacterDefense.GetReflexDefense(objCharacter).GetDefenseTotal(objArmor.ReflexAdjustment, objArmor.objArmorType.ArmorCheckPenalty ).ToString();
                this.txtFortCurrent.Text = CharacterDefense.GetFortitudeDefense(objCharacter).GetDefenseTotal(0, 0).ToString();
            }

            if (!blnCharacterProfWithArmor) SetCharacterSkillsGrid(objArmor); else DisplaySkillsGrid(false);

            this.btnSelectArmor.Enabled = true;
        }

        private void DisplaySkillsGrid(bool blnDisplayGrid)
        {
            if (blnDisplayGrid)
            {
                //Short Display
                this.grpArmorDetail.Height = 364;
                this.txtArmorDescription.Height = 	152;
                this.tvArmorList.Height = 		309;
                this.gpArmors.Height = 372;
            }
            else
            {
                //Long Display
                this.grpArmorDetail.Height = 596;
                this.txtArmorDescription.Height = 384;
                this.tvArmorList.Height = 537;
                this.gpArmors.Height = 596;
            }
            this.grpSkills.Visible = blnDisplayGrid;
        }

        private void SetCharacterSkillsGrid(Armor objArmor)
        {
            csc1.ResetControl();
            csc2.ResetControl();
            csc3.ResetControl();
            csc4.ResetControl();
            csc5.ResetControl();
            csc6.ResetControl();
            csc7.ResetControl();
            
            DisplaySkillsGrid(true);
            Skill objDummySkill = new Skill();
            List<Skill> lstArmorProSkills = new List<Skill>();
            lstArmorProSkills = objDummySkill.GetArmorProfSkills();

            foreach (Skill objSkill in lstArmorProSkills)
            {
                Ability objAbility = new Ability(objSkill.AbilityID);
                if (CharacterSkill.IsSkillInList(objSkill, objCharacter.lstCharacterSkills)) FillOutCharacterSkillControls(CharacterSkill.GetCharacterSkillFromListBySkill(objSkill, objCharacter.lstCharacterSkills), objArmor.objArmorType.ArmorCheckPenalty);
                else
                {
                    CharacterSkill objCharSkill = new CharacterSkill();
                    //If its trained only fill in blanks else fill in the stats that the char has
                    objCharSkill.CharacterID = objCharacter.CharacterID;
                    objCharSkill.FeatTalentMod = 0;
                    objCharSkill.Miscellaneous = objArmor.objArmorType.ArmorCheckPenalty ;
                    objCharSkill.objSkill = objSkill;
                    objCharSkill.SkillID = objSkill.SkillID;
                    objCharSkill.Trained = 0;
                    objCharSkill.SkillFocus = 0;

                    if (objSkill.TrainedSkill)
                    {
                            objCharSkill.AbilityMod = 0;
                            objCharSkill.HalfLevel = 0;
                    }
                    else
                    {
                        objCharSkill.AbilityMod = objCharacter.GetCharacterAbilityModifier(objAbility);
                        objCharSkill.HalfLevel = objCharacter.CharacterLevelID / 2;
                    }
                    FillOutCharacterSkillControls(objCharSkill, 0);
                }
            }

        }

        private void FillOutCharacterSkillControls(CharacterSkill objCharSkill, int intArmorProfPenalty)
        {
            if (csc1.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc1, intArmorProfPenalty);
            else if (csc2.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc2, intArmorProfPenalty);
            else if (csc3.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc3, intArmorProfPenalty);
            else if (csc4.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc4, intArmorProfPenalty);
            else if (csc5.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc5, intArmorProfPenalty);
            else if (csc6.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc6, intArmorProfPenalty);
            else if (csc7.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc7, intArmorProfPenalty);

        }

        private void FillOutCharacterSkillControl(CharacterSkill objCharSkill, CharacterSkillControl cscTemp, int ArmorProfPenalty)
        {
            cscTemp.SkillName = objCharSkill.objSkill.SkillName;
            cscTemp.SkillAbilityModValue = objCharSkill.AbilityMod;
            cscTemp.SkillFeatTalentValue = objCharSkill.FeatTalentMod;
            cscTemp.SkillFocusValue = objCharSkill.SkillFocus;
            cscTemp.SkillTrainedValue = objCharSkill.Trained;
            cscTemp.SkillHalfLevelValue = objCharSkill.HalfLevel;
            cscTemp.SkillMiscellaneousValue = objCharSkill.Miscellaneous + ArmorProfPenalty;

        }
        #endregion

        #region Form Events
        private void ckbHideNonProficientArmors_CheckedChanged(object sender, EventArgs e)
        {
            LoadTreeView();
        }

        private void tvArmorList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strTag = tvArmorList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Armor objArmor = new Armor(intTag);
                SetArmorFields(objArmor);


            }
        }

        private void btnSelectArmor_Click(object sender, EventArgs e)
        {
            frmMain.intNewCharacterArmorArmorID = intArmorSelectedID;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion





    }
}
