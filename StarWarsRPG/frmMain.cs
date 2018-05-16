using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenericCharacterGenerator;
using StarWarsClasses;
using CharacterGenerator;
using SWRPG_Custom_Windows_Controls;

namespace StarWarsRPG
{
    public partial class frmMain : Form
    {
        public static int intSearchID = 0;
        public static List<CharacterScores> lstCharacterScore = new List<CharacterScores>();
        public static Character objCurrentChar = new Character();
        public static int intNewCharacterWeaponWeaponID = 0;
        public static int intNewCharacterArmorArmorID = 0;
        public static int intNewCharacterEquipmentEquipmentID = 0;
        public static int intNewCharacterEquipmentQuantity = 1;

        public static bool blnUseCredits = false;
        public static bool blnAllowCreditOnDeleteExchange = false;
        //public static int intUpdatedCreditsFromMods = 0;

        public static List<Modification> lstModficationsSelected = new List<Modification>();
        private List<CharacterScores> lstOriginalCharacterScores = new List<CharacterScores>();
        private List<Class> lstCharacterClasses = new List<Class>();

        public bool blnOriginalLoadOfCharacter = false;

        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();
        private Dictionary<string, int> dicObjClassLevel = new Dictionary<string, int>();


        private Color clrForeColor;
        private Color clrBackColor;

        public frmMain()
        {
            InitializeComponent();
            LoadConditionTrack();
            LoadAbilityFields();
            LoadDropDowns();


            CEC1.AddEquipmentEP_Click += new EventHandler(AddEquipmentEmplacementPoint_Click);
            //cac1.AddEmplacementPoint_Click += new EventHandler(btnArmorAddEmplacementPoint_Click);
            //Original Back Colors 
            clrBackColor = this.txtCredits.BackColor;
            clrForeColor = this.txtCredits.ForeColor;      
        }

        #region Form Events
        #region Tab Strip Form Events
        private void tspiGenerateCharacter_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            Form frmCharGen = new frmGenericCharacterGenerator();

            result = frmCharGen.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lstCharacterScore = frmGenericCharacterGenerator.lstCharScores;
                lstOriginalCharacterScores = lstCharacterScore;
                objCurrentChar = new Character();

                frmCharGen.Close();
                if (lstCharacterScore.Count > 0)
                {
                    ResetMainForm();
                    FillCharacterScoresOut();
                    SetFormDefaults(false);
                }
            }
            //We are creating a character from scratch but not a 1st level one Turn on certain fields
            this.cmbRace.Enabled = true;
            //Level Char Level alone, make the user add levels on at a time and via the button to control race adjustments and correctly adding levels           
            CheckStatusForAddCharacterLevelButton();
        }

        private void GenerateFirstLevelCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            Form frmCharGen = new frmGenericCharacterGenerator();
            
            result = frmCharGen.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ResetMainForm();
                lstCharacterScore = frmGenericCharacterGenerator.lstCharScores ;
                lstOriginalCharacterScores = lstCharacterScore;
                
                frmCharGen.Close();
                if (lstCharacterScore.Count > 0)
                {
                    //Clear the form and set everything to "" including the character
                    FillCharacterScoresOut();
                    SetFormDefaults(true);
                }
            }
            CheckStatusForAddCharacterLevelButton();
        }

        private void armorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSearch = new frmSearch();
            frmSearch.ShowDialog();
        }

        private void byFeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSearch = new frmSearch(Common.searchType.Feat, this);
            frmSearch.ShowDialog();

            if (intSearchID != 0)
            {
                Form frmFeat = new frmFeat(intSearchID);
                frmFeat.Show();
            }
        }

        private void byForcePowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSearch = new frmSearch(Common.searchType.ForcePower, this);
            frmSearch.ShowDialog();

            if (intSearchID != 0)
            {
                Form frmForcePower = new frmForcePower(intSearchID);
                frmForcePower.Show();
            }
        }

        private void byCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSearch = new frmSearch(Common.searchType.Character, this);
            DialogResult result = new DialogResult(); 
            result = frmSearch.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ResetMainForm();
                LoadCurrentCharacter();
            }

        }

        private void byEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSearch = new frmSearch(Common.searchType.Equipment, this);
            frmSearch.ShowDialog();

            if (intSearchID != 0)
            {
                Form frmEquipment = new frmEquipment(intSearchID);
                frmEquipment.Show();
            }
      
        }

        private void bySkillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSearch = new frmSearch(Common.searchType.Skill, this);
            frmSearch.ShowDialog();
            if (intSearchID != 0)
            {
                Form frmSkill = new frmSkill(intSearchID);
                frmSkill.Show();
            }
        }

        private void ByArmorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmSearch = new frmSearch(Common.searchType.Armor, this);
            frmSearch.ShowDialog();

            if (intSearchID != 0)
            {
                Form frmArmor = new frmArmor(intSearchID);
                frmArmor.Show();
            }
        }

        private void tsmiUseCredits_Click(object sender, EventArgs e)
        {
            if (this.tsmiUseCredits.Checked) blnUseCredits = true; else blnUseCredits = false;
            if (!tsmiUseCredits.Checked) tsmiAllowCreditOnDeleteExchange.Checked = false;
            this.tsmiAllowCreditOnDeleteExchange.Enabled = blnUseCredits;
        }

        private void tsmiAllowCreditOnDeleteExchange_Click(object sender, EventArgs e)
        {
            if (this.tsmiAllowCreditOnDeleteExchange.Checked) blnAllowCreditOnDeleteExchange = true; else blnAllowCreditOnDeleteExchange = false;
        }
        #endregion

        #region Character View Tab
        private void txtLevel_KeyDown(object sender, KeyEventArgs e)
        {
           //NumericValuesOnly(e)
            
        }

        private void txtLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtLevel_TextChanged(object sender, EventArgs e)
        {
            txtReflexLevelArmor.Text = this.txtLevel.Text;
            txtFortLevelArmor.Text = this.txtLevel.Text;
            txtWillLevelArmor.Text = this.txtLevel.Text;
        }

        private void txtReflexLevelArmor_TextChanged(object sender, EventArgs e)
        {
            GetReflexTotal();
        }

        private void txtReflexAbility_TextChanged(object sender, EventArgs e)
        {
            GetReflexTotal();
        }

        private void txtReflexClass_TextChanged(object sender, EventArgs e)
        {
            GetReflexTotal();
        }

        private void txtReflexRace_TextChanged(object sender, EventArgs e)
        {
            GetReflexTotal();
        }

        private void txtReflexFeat_TextChanged(object sender, EventArgs e)
        {
            GetReflexTotal();
        }

        private void txtReflexMisc_TextChanged(object sender, EventArgs e)
        {
            GetReflexTotal();
        }

        private void txtWillLevelArmor_TextChanged(object sender, EventArgs e)
        {
            GetWillTotal();
        }

        private void txtWillAbility_TextChanged(object sender, EventArgs e)
        {
            GetWillTotal();
        }

        private void txtWillClass_TextChanged(object sender, EventArgs e)
        {
            GetWillTotal();
        }

        private void txtWillRace_TextChanged(object sender, EventArgs e)
        {
            GetWillTotal();
        }

        private void txtWillFeat_TextChanged(object sender, EventArgs e)
        {
            GetWillTotal();
        }

        private void txtWillMisc_TextChanged(object sender, EventArgs e)
        {
            GetWillTotal();
        }

        private void txtFortLevelArmor_TextChanged(object sender, EventArgs e)
        {
            GetFortTotal();
        }

        private void txtFortAbility_TextChanged(object sender, EventArgs e)
        {
            GetFortTotal();
        }

        private void txtFortClass_TextChanged(object sender, EventArgs e)
        {
            GetFortTotal();
        }

        private void txtFortRace_TextChanged(object sender, EventArgs e)
        {
            GetFortTotal();
        }

        private void txtFortFeat_TextChanged(object sender, EventArgs e)
        {
            GetFortTotal();
        }

        private void txtFortMisc_TextChanged(object sender, EventArgs e)
        {
            GetFortTotal();
        }

        private void txtAbility1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility1_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility1.Text, out intScore);
            UpdateModValue(txtAbility1Mod, intScore);
        }

        private void txtAbility2_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility2.Text, out intScore);
            UpdateModValue(txtAbility2Mod, intScore);
        }

        private void txtAbility3_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility3.Text, out intScore);
            UpdateModValue(txtAbility3Mod, intScore);
        }

        private void txtAbility4_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility4.Text, out intScore);
            UpdateModValue(txtAbility4Mod, intScore);
        }

        private void txtAbility5_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility5.Text, out intScore);
            UpdateModValue(txtAbility5Mod, intScore);
        }

        private void txtAbility6_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility6.Text, out intScore);
            UpdateModValue(txtAbility6Mod, intScore);
        }

        private void btnAddCharacterLevel_Click(object sender, EventArgs e)
        {
            if (objCurrentChar.RaceID == 0 || objCurrentChar.lstCharacterAbilities == null)
            {
                MessageBox.Show("Please select the character race and generate scores before proceeding, this will effect the selection of feats and talents.");
                return;
            }
            DialogResult result = new DialogResult();
            Form frmAddCharLevel = new frmAddCharacterLevel(Character.Clone(objCurrentChar));

            result = frmAddCharLevel.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //string strClasses = "";
                ////string strClassLevel = "";
                //int intCharacterLevel = 0;

                //strClasses = frmSetClassAndLevel.AllClasses;
                ////strClassLevel = frmSetClassAndLevel.AllLevels;
                //intCharacterLevel = frmSetClassAndLevel.CharacterLevel;

                //txtClass.Text = strClasses;
                ////txtLevelByClass.Text = strClassLevel;
                //txtLevel.Text = intCharacterLevel.ToString();

                //lstCharacterClasses = frmSetClassAndLevel.lstClasses;

                //UpdateDefenseScores();
            }

        }

        private void txtAbility1Mod_TextChanged(object sender, EventArgs e)
        {
            UpdateAbilityModForDefense(txtAbility1Mod, lblAbility1.Text);
            //if (this.ckbEnableAbility.Checked) Update
        }

        private void txtAbility2Mod_TextChanged(object sender, EventArgs e)
        {
            UpdateAbilityModForDefense(txtAbility2Mod, lblAbility2.Text);
        }

        private void txtAbility3Mod_TextChanged(object sender, EventArgs e)
        {
            UpdateAbilityModForDefense(txtAbility3Mod, lblAbility3.Text);
        }

        private void txtAbility4Mod_TextChanged(object sender, EventArgs e)
        {
            UpdateAbilityModForDefense(txtAbility4Mod, lblAbility4.Text);
        }

        private void txtAbility5Mod_TextChanged(object sender, EventArgs e)
        {
            UpdateAbilityModForDefense(txtAbility5Mod, lblAbility5.Text);
        }

        private void txtAbility6Mod_TextChanged(object sender, EventArgs e)
        {
            UpdateAbilityModForDefense(txtAbility6Mod, lblAbility6.Text);
        }

        private void cmbRace_SelectedValueChanged(object sender, EventArgs e)
        {
            if (objCurrentChar.CharacterLevelID == 0)
            {
                SetRaceComboBoxChangedData();
            }
            CheckStatusForAddCharacterLevelButton();
            this.btnViewRaceInfo.Enabled = true;
        }
       
        private void btnSetClassAndLevel_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            Form frmSetCAndL = new frmSetClassAndLevel();

            if (this.txtClass.Text != "")
            {
                frmSetClassAndLevel.AllClasses = this.txtClass.Text;
            }

            result = frmSetCAndL.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string strClasses = "";
                //string strClassLevel = "";
                int intCharacterLevel = 0;

                strClasses = frmSetClassAndLevel.AllClasses;
                //strClassLevel = frmSetClassAndLevel.AllLevels;
                intCharacterLevel = frmSetClassAndLevel.CharacterLevel;

                txtClass.Text  = strClasses;
                //txtLevelByClass.Text = strClassLevel;
                txtLevel.Text = intCharacterLevel.ToString();

                lstCharacterClasses = frmSetClassAndLevel.lstClasses;

                UpdateDefenseScores();
            }
        }

        private void createCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            Form frmCharGen = new frmCharCreate1GenerateScores();
            ResetMainForm();
            result = frmCharGen.ShowDialog(this);

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportViewer ReportView = new frmReportViewer();
            ReportView.Show();
        }

        private void tspiOrganization_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();

            frmOrganization.lstCharOrgs = objCurrentChar.lstCharacterOrganizations;
            frmOrganization frmOrg = new frmOrganization();
            result = frmOrg.ShowDialog();


            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //we didn't cancel out so load what was added to the current character organizations
                LoadOrganizationListView(objCurrentChar.lstCharacterOrganizations);
            }
        }

        private void btnViewRaceInfo_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            Race objComboRace = new Race();

            if (this.cmbRace.SelectedItem.ToString() != "") objComboRace = GetComboRaceObject();
            
            if (objComboRace.RaceName != "") frmCharCreate2GetRace.objUserSelectedRace = objComboRace;

            Form frmStep2GetRace = new frmCharCreate2GetRace();
            result = frmStep2GetRace.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Race objNewRace = frmCharCreate2GetRace.objUserSelectedRace;
                if (objNewRace != null)
                {
                    this.cmbRace.SelectedItem = objNewRace.RaceName;
                    this.cmbRace.SelectedText = objNewRace.RaceName;
                }
            }

        }

        private void tvEquipment_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvEquipment.SelectedNode.Nodes.Count ==0 )
            {
                string strTag = tvEquipment.SelectedNode.Tag.ToString();
                int intTag;

                int.TryParse(strTag, out intTag);

                if (intTag != 0)
                {
                    CharacterEquipment objCE = new CharacterEquipment(intTag);
                    FillOutCEC(objCE);
                }
            }
            else CEC1.ResetControl();
            this.btnRemoveEquipment.Enabled = true;
        }
        #endregion

        #region Weapon Tab
        private void btnExhcangeWeap3_Click(object sender, EventArgs e)
        {
            ExchangeWeapon(cwc3.objCharWeapon.CharacterWeaponID, cwc3);
        }

        private void btnExhcangeWeap1_Click(object sender, EventArgs e)
        {
            ExchangeWeapon(cwc1.objCharWeapon.CharacterWeaponID, cwc1);
        }

        private void btnExhcangeWeap2_Click(object sender, EventArgs e)
        {
            ExchangeWeapon(cwc2.objCharWeapon.CharacterWeaponID, cwc2);
        }

        private void btnExhcangeWeap4_Click(object sender, EventArgs e)
        {
            ExchangeWeapon(cwc4.objCharWeapon.CharacterWeaponID, cwc4);
        }

        private void btnAddCharWeapon_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            //int intMainFormCredits = 0;

            //frmOrganization.lstCharOrgs = objCurrentChar.objCharacterOrganizations;
            frmWeaponSelection.objCharacter = objCurrentChar;
            frmWeaponSelection frmWS = new frmWeaponSelection();
            result = frmWS.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                CharacterWeapon objCW = new CharacterWeapon(objCurrentChar.CharacterID, intNewCharacterWeaponWeaponID);
                Weapon objWeapon = new Weapon(intNewCharacterWeaponWeaponID);
                objCW = objCW.CreateCharacterWeapon(objCurrentChar, objWeapon);
                
                if (DeductCreditsFromCharacter(objWeapon.Cost))
                {
                    UpdateCharacterWeaponControl(objCW, false);
                    //if (blnUseCredits) this.txtCredits.Text = objCurrentChar.Credits.ToString();
                }
                //if (blnUseCredits)
                //{
                //    int.TryParse(this.txtCredits.Text , out intMainFormCredits );
                //    if (objCurrentChar.DeductCreditsFromCharacter(intMainFormCredits, objWeapon.Cost))
                //    {
                //        UpdateCharacterWeaponControl(objCW, false);
                //        this.txtCredits.Text = objCurrentChar.Credits.ToString();
                //    }
                //}
                //else UpdateCharacterWeaponControl(objCW, false);


            }
        }

        private void UpdateCharacterWeaponControl(CharacterWeapon objCW, bool blnExchangeWeapon, Character_Weapon_Control objCWC = null)
        {
            objCurrentChar.lstCharacterWeapons.Add(objCW);
            objCurrentChar.UpdateCharacterWeaponStats(Common.GetAppSettingsID("Weapon_Finese_SimpleWeapons"), Common.GetAppSettingsID("Weapon_Finese_Lightsabers"));
            if (blnExchangeWeapon)
            {
                //objCurrentChar.lstCharacterWeapons.Add(objCW);
                //objCurrentChar.UpdateCharacterWeaponStats(Common.GetAppSettingsID("Weapon_Finese_SimpleWeapons"), Common.GetAppSettingsID("Weapon_Finese_Lightsabers"));
                //Add newly Created CharacterWeapon object to Control
                objCWC.SetControlWithCharacterWeapon(objCurrentChar, objCW);
            }
            else
            {
                //Add newly Created CharacterWeapon object to Control
                ResetCharacterWeaponControls();
                FillOutCharacterWeapons();
            }
        }

        private void CreditItemCostOnDelete(int ItemCost, Common.ModificationType enumModType)
        {
            int intBuyBackPercentage = 0;
            
            if (blnAllowCreditOnDeleteExchange)
            {
                switch (enumModType)
                {
                    case Common.ModificationType.Armor:
                        intBuyBackPercentage = Common.GetAppSettingsID("ArmorExchangeBuybackRate");
                        break;
                    case Common.ModificationType.Equipment:
                        intBuyBackPercentage = Common.GetAppSettingsID("EquipmentExchangeBuybackRate");
                        break;
                    case Common.ModificationType.Weapon:
                        intBuyBackPercentage = Common.GetAppSettingsID("WeaponExchangeBuybackRate");
                        break;
                    default:
                        break;
                }
                objCurrentChar.CreditCreditsForCharacter(intBuyBackPercentage, ItemCost);
                this.txtCredits.Text = objCurrentChar.Credits.ToString();
            }
        }



        //private void CreditArmorCostOnDelete(Character_Armor_Control cac)
        //{
        //    if (blnAllowCreditOnDeleteExchange)
        //    {
        //        int ArmorBuyBackPercentage = Common.GetAppSettingsID("ArmorExchangeBuybackRate");
        //        objCurrentChar.CreditCreditsForCharacter(ArmorBuyBackPercentage, cac.objCharArmor.objArmor.Cost );
        //        this.txtCredits.Text = objCurrentChar.Credits.ToString();
        //    }
        //}

        //private void CreditWeaponCostOnDelete(Character_Weapon_Control cwc)
        //{
        //    if (blnAllowCreditOnDeleteExchange)
        //    {
        //        int WeaponBuyBackPercentage = Common.GetAppSettingsID("WeaponExchangeBuybackRate");
        //        objCurrentChar.CreditCreditsForCharacter(WeaponBuyBackPercentage, cwc.objCharWeapon.objWeapon.Cost);
        //        this.txtCredits.Text = objCurrentChar.Credits.ToString();
        //    }
        //}

        //private void CreditEquipmentCostOnDelete (CharacterEquipment objCharEqup)
        //{
        //    if (blnAllowCreditOnDeleteExchange)
        //    {
        //        int WeaponBuyBackPercentage = Common.GetAppSettingsID("WeaponExchangeBuybackRate");
        //        objCurrentChar.CreditCreditsForCharacter(WeaponBuyBackPercentage, objCharEqup.objEquipment.EquipmentCost);
        //        this.txtCredits.Text = objCurrentChar.Credits.ToString();
        //    }
        //}

        private void btnDeleteWeapon1_Click(object sender, EventArgs e)
        {
            //CreditWeaponCostOnDelete(cwc1);
            CreditItemCostOnDelete(cwc1.objCharWeapon.objWeapon.Cost, Common.ModificationType.Weapon);
            DeleteWeapon(cwc1.objCharWeapon.CharacterWeaponID, cwc1);
        }

        private void btnDeleteWeapon2_Click(object sender, EventArgs e)
        {
            //CreditWeaponCostOnDelete(cwc2);
            CreditItemCostOnDelete(cwc2.objCharWeapon.objWeapon.Cost, Common.ModificationType.Weapon);
            DeleteWeapon(cwc2.objCharWeapon.CharacterWeaponID, cwc2);
        }

        private void btnDeleteWeapon3_Click(object sender, EventArgs e)
        {
            //CreditWeaponCostOnDelete(cwc3);
            CreditItemCostOnDelete(cwc3.objCharWeapon.objWeapon.Cost, Common.ModificationType.Weapon);
            DeleteWeapon(cwc3.objCharWeapon.CharacterWeaponID, cwc3);
        }

        private void btnDeleteWeapon4_Click(object sender, EventArgs e)
        {
            //CreditWeaponCostOnDelete(cwc4);
            CreditItemCostOnDelete(cwc4.objCharWeapon.objWeapon.Cost, Common.ModificationType.Weapon);
            DeleteWeapon(cwc4.objCharWeapon.CharacterWeaponID, cwc4);
        }

        private void btnWeaponAddEmplacementPoint1_Click(object sender, EventArgs e)
        {
            AddRemoveWeaponMods(cwc1);
        }

        private void btnWeaponAddEmplacementPoint2_Click(object sender, EventArgs e)
        {
            AddRemoveWeaponMods(cwc2);
        }

        private void btnWeaponAddEmplacementPoint3_Click(object sender, EventArgs e)
        {
            AddRemoveWeaponMods(cwc3);
        }

        private void btnWeaponAddEmplacementPoint4_Click(object sender, EventArgs e)
        {
            AddRemoveWeaponMods(cwc4);
        }
        #endregion

        #region Armor Tab
        private void AddEquipmentEmplacementPoint_Click (object sender, EventArgs e)
        {
            CharacterEquipment objCharEquip = new CharacterEquipment();
            string strTag = "";
            int intTag;

            try
            {
                strTag = tvEquipment.SelectedNode.Tag.ToString();
            }
            catch
            {
                return;
            }
                
            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                objCharEquip.GetCharacterEquipment(intTag);
            }
            DialogResult result = new DialogResult();
            lstModficationsSelected = new List<Modification>();

            frmModification frmMod = new frmModification(objCharEquip.objEquipment, objCharEquip.CharacterEquipmentID, objCurrentChar, blnUseCredits, blnAllowCreditOnDeleteExchange,Common.GetAppSettingsID("ModificationExchangeBuybackRate"));
            result = frmMod.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) 
            {
                ////Remove all the mods becuase they can be removed from the Edit Mod screen
                //foreach (Modification objRemMod in objCharEquip.lstModifications)
                //{
                //    if (!Modification.IsModificationInList (objRemMod,lstModficationsSelected))
                //    {
                //        objCharEquip.DeleteCharacterEquipmentModification(objCharEquip.CharacterEquipmentID, objRemMod.ModificationID);
                //    }
                //}

                //foreach (Modification objMod in lstModficationsSelected)
                //{
                //    objMod.SaveCharacterEquipmentModification(objCharEquip.CharacterEquipmentID, objMod.ModificationID);
                //}
                //Reload the CharacterEquipment
                objCharEquip = new CharacterEquipment(objCharEquip.CharacterEquipmentID);
                //Reload the control with new mods
                if (blnUseCredits) this.txtCredits.Text = objCurrentChar.Credits.ToString();
                CEC1.ResetControl();
                CEC1.SetControlWithCharacterEquipment(objCurrentChar, objCharEquip);
            }
        }

        private void btnArmorAddEmplacementPoint1_Click(object sender, EventArgs e)
        {
            AddRemoveArmorMods(cac1);
        }

        private void btnArmorAddEmplacementPoint2_Click(object sender, EventArgs e)
        {
            AddRemoveArmorMods(cac2);
        }

        //private void btnSaveCharacterArmor(object sender, EventArgs e)
        //{
        //    CharacterEquipment objCharEquip = new CharacterEquipment(CEC1.objCharEquip.CharacterEquipmentID);
        //    objCharEquip.Quantity = CEC1.Quantity;
        //    objCharEquip.SaveCharacterEquipment();
        //}
        
        private void btnArmorRemoveEmplacementPoint1_Click(object sender, EventArgs e)
        {
            AddRemoveArmorMods(cac1);
        }

        private void btnArmorRemoveEmplacementPoint2_Click(object sender, EventArgs e)
        {
            AddRemoveArmorMods(cac2);
        }

        private void ckbArmorWorn1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbArmorWorn1.Checked) ckbArmorWorn2.Checked = false;
        }

        private void ckbArmorWorn2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbArmorWorn2.Checked) ckbArmorWorn1.Checked = false;
        }

        private void btnSwitchArmor1_Click(object sender, EventArgs e)
        {
            ExchangeArmor(cac1.objCharArmor.CharacterArmorID, cac1);
        }

        private void btnSwitchArmor2_Click(object sender, EventArgs e)
        {
            ExchangeArmor(cac2.objCharArmor.CharacterArmorID, cac2);
        }

        private void btnAddArmor_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            //int intMainFormCredits = 0;

            frmArmorSelection.objCharacter = objCurrentChar;
            frmArmorSelection frmAS = new frmArmorSelection();
            result = frmAS.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                CharacterArmor objCW = new CharacterArmor(objCurrentChar.CharacterID, intNewCharacterArmorArmorID);
                Armor objArmor = new Armor(intNewCharacterArmorArmorID);
                objCW = objCW.CreateCharacterArmor(objCurrentChar, objArmor);


                if (DeductCreditsFromCharacter(objArmor.Cost))
                {
                    objCurrentChar.lstCharacterArmors.Add(objCW);
                    ResetCharacterArmorControls();
                    FillOutCharacterArmors();
                    //if (blnUseCredits) this.txtCredits.Text = objCurrentChar.Credits.ToString();
                }

                //if (blnUseCredits)
                //{
                //    int.TryParse(this.txtCredits.Text, out intMainFormCredits);
                //    if (objCurrentChar.DeductCreditsFromCharacter(intMainFormCredits, objArmor.Cost))
                //    {
                //        objCurrentChar.lstCharacterArmors.Add(objCW);
                //        ResetCharacterArmorControls();
                //        FillOutCharacterArmors();
                //        this.txtCredits.Text = objCurrentChar.Credits.ToString();
                //    }
                //}
            }
        }

        private void btnDeleteArmor1_Click(object sender, EventArgs e)
        {
            //CreditArmorCostOnDelete(cac1);
            CreditItemCostOnDelete(cac1.objCharArmor.objArmor.Cost , Common.ModificationType.Armor);
            DeleteArmor(cac1.objCharArmor.CharacterArmorID, cac1);
        }

        private void btnDeleteArmor2_Click(object sender, EventArgs e)
        {
            CreditItemCostOnDelete(cac2.objCharArmor.objArmor.Cost, Common.ModificationType.Armor);
            DeleteArmor(cac2.objCharArmor.CharacterArmorID, cac2);

        }

        private void txtCredits_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e, true);
        }

        private void txtCredits_TextChanged(object sender, EventArgs e)
        {
            // if its Negative, change the backcolor 
            int intFormCredits = 0;

            int.TryParse(this.txtCredits.Text, out intFormCredits);

            if (intFormCredits < 0)
            {
                this.txtCredits.BackColor = Color.Maroon;
                this.txtCredits.ForeColor = Color.White;
            }
            else
            {
                this.txtCredits.BackColor = clrBackColor;
                this.txtCredits.ForeColor = clrForeColor;
            }

        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {

            DialogResult result = new DialogResult();
            //int intMainFormCredits = 0;

            //frmOrganization.lstCharOrgs = objCurrentChar.objCharacterOrganizations;
            frmEquipmentSelection.objCharacter = objCurrentChar;
            frmEquipmentSelection frmES = new frmEquipmentSelection();
            result = frmES.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                CharacterEquipment objCE = new CharacterEquipment(objCurrentChar.CharacterID, intNewCharacterEquipmentEquipmentID);
                Equipment objEquipment = new Equipment(intNewCharacterEquipmentEquipmentID);
                objCE = objCE.CreateCharacterEquipment(objCurrentChar, objEquipment, intNewCharacterEquipmentQuantity);

                if (DeductCreditsFromCharacter(objEquipment.EquipmentCost * intNewCharacterEquipmentQuantity))
                {
                    //if (blnUseCredits) this.txtCredits.Text = objCurrentChar.Credits.ToString();
                    objCE.SaveCharacterEquipment();
                    LoadEquipmentList();
                }

                //if (blnUseCredits)
                //{
                //    int.TryParse(this.txtCredits.Text, out intMainFormCredits);
                //    //If its not upgradable, it can have a quantity so we will have to 
                //    if (objCurrentChar.DeductCreditsFromCharacter(intMainFormCredits, objEquipment.EquipmentCost * intNewCharacterEquipmentQuantity))
                //    {
                //        this.txtCredits.Text = objCurrentChar.Credits.ToString();
                //    }
                //}
                ////else UpdateCharacterWeaponControl(objCE, false);
                //objCE.SaveCharacterEquipment();
                //LoadEquipmentList();
            }

        }

        private void tvEquipment_Leave(object sender, EventArgs e)
        {
            try
            {
                string strTag = tvEquipment.SelectedNode.Tag.ToString();
                int intTag;

                int.TryParse(strTag, out intTag);

                if (intTag == 0) this.btnRemoveEquipment.Enabled = false;
                //{
                //    CharacterEquipment objCE = new CharacterEquipment(intTag);
                //    objCE.DeleteCharacterEquipment();
                //    LoadEquipmentList();
                //}
            }
            catch
            { this.btnRemoveEquipment.Enabled = false; }
            
        }

        private void btnRemoveEquipment_Click(object sender, EventArgs e)
        {
            string strTag = "";
            int intTag;

            try
            {
                strTag = tvEquipment.SelectedNode.Tag.ToString();
            }
            catch
            {
                this.btnRemoveEquipment.Enabled = false;
                return;
            }

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                //Make sure it isn't a parent node 
                if (tvEquipment.SelectedNode.Nodes.Count > 0)
                {
                    this.btnRemoveEquipment.Enabled = false;
                    return;
                }
                CharacterEquipment objCE = new CharacterEquipment(intTag);

                //if (blnAllowCreditOnDeleteExchange)
                //{
                //    //int EquipmentBuyBackPercentage = Common.GetAppSettingsID("EquipmentExchangeBuybackRate");
                //    //objCurrentChar.CreditCreditsForCharacter(EquipmentBuyBackPercentage, objCE.objEquipment.EquipmentCost);
                //    CreditItemCostOnDelete(objCE.objEquipment.EquipmentCost , Common.ModificationType.Equipment);
                //    //this.txtCredits.Text = objCurrentChar.Credits.ToString();
                //}
                
                CreditItemCostOnDelete(objCE.objEquipment.EquipmentCost, Common.ModificationType.Equipment);
                objCE.DeleteCharacterEquipment();
                LoadEquipmentList();
            }
        }
        #endregion
        #endregion

        #region Methods
        private bool DeductCreditsFromCharacter(int objItemCost)
        {
            bool blnReturnVal = false;
            int intMainFormCredits = 0;
            int.TryParse(this.txtCredits.Text, out intMainFormCredits);

            if (blnUseCredits)
            {
                if (objCurrentChar.DeductCreditsFromCharacter(intMainFormCredits, objItemCost))
                {
                    blnReturnVal = true;
                    this.txtCredits.Text = objCurrentChar.Credits.ToString();
                }
            }
            else blnReturnVal = true;
            return blnReturnVal;
        }


        private void AddRemoveArmorMods(Character_Armor_Control cac)
        {
            DialogResult result = new DialogResult();
            lstModficationsSelected = new List<Modification>();

            frmModification frmMod = new frmModification(cac.objCharArmor.objArmor, cac.objCharArmor.CharacterArmorID, objCurrentChar, blnUseCredits, blnAllowCreditOnDeleteExchange, Common.GetAppSettingsID("ModificationExchangeBuybackRate"));
            result = frmMod.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) cac.AddModifications(lstModficationsSelected);
        }

        private void AddRemoveWeaponMods(Character_Weapon_Control cwc)
        {
            DialogResult result = new DialogResult();
            lstModficationsSelected = new List<Modification>();

            frmModification frmMod = new frmModification(cwc.objCharWeapon.objWeapon, cwc.objCharWeapon.CharacterWeaponID, objCurrentChar, blnUseCredits, blnAllowCreditOnDeleteExchange, Common.GetAppSettingsID("ModificationExchangeBuybackRate"));
            result = frmMod.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) cwc.AddModifications(lstModficationsSelected);
        }

        private void ResetMainForm()
        {
           
            this.txtName.Text = "";
            blnOriginalLoadOfCharacter = true;
            this.cmbRace.SelectedIndex = 0;
            this.cmbRace.SelectedText = "";
            this.cmbRace.SelectedValue = "";
            blnOriginalLoadOfCharacter = false;
            this.txtSex.Text = "";
            this.txtXP.Text = "";
            this.txtDestinyPoints.Text = "";
            this.lblDestinyMax.Text = "Max: ";  
            this.txtForcePoints.Text = "";
            this.lblMaxForcePoints.Text = "Max: ";
            this.txtLevel.Text ="";
            this.txtClass.Text = "";
            this.txtHitPoints.Text = "";
            this.txtDarkSidePoints.Text ="";
            this.lblDarkSideMax.Text =  "Max: ";
            this.txtDamageThreshold.Text = "";
            this.txtBaseAttack.Text = "";
            this.txtAbility1.Text = "0";
            this.txtAbility2.Text = "0";
            this.txtAbility3.Text = "0";
            this.txtAbility4.Text = "0";
            this.txtAbility5.Text = "0";
            this.txtAbility6.Text = "0";
            this.txtReflexLevelArmor.Text = "";
            this.txtReflexAbility.Text = "";
            this.txtReflexClass.Text = "";
            this.txtReflexFeat.Text = "";
            this.txtReflexMisc.Text = "";
            this.txtWillLevelArmor.Text = "";
            this.txtWillAbility.Text = "";
            this.txtWillClass.Text = "";
            this.txtWillFeat.Text = "";
            this.txtWillMisc.Text = "";
            this.txtFortLevelArmor.Text = "";
            this.txtFortAbility.Text = "";
            this.txtFortClass.Text = "";
            this.txtFortFeat.Text = "";
            this.txtFortMisc.Text = "";
            this.lvCharSpeeds.Items.Clear();
            this.lvOrganizations.Items.Clear();
        }

        private void SetFormDefaults(bool blnFirstLevelCharacter)
        {
            if (blnFirstLevelCharacter)
            {
                this.txtXP.Text = "0";
                this.txtDestinyPoints.Text = "1";
                this.txtDarkSidePoints.Text = "0";
                this.txtLevel.Text = "1";
                this.txtReflexLevelArmor.Text = "1";
                this.txtWillLevelArmor.Text = "1";
                this.txtFortLevelArmor.Text = "1";
            }
            SetFormTextBoxesUsability(!blnFirstLevelCharacter);
            ResetCharacterSkillControls();
        }

        private void SetFormTextBoxesUsability(bool blnEnabled)
        {
            this.txtXP.Enabled = blnEnabled;
            this.txtDestinyPoints.Enabled = blnEnabled;
            this.txtDarkSidePoints.Enabled = blnEnabled;
            this.txtLevel.Enabled = blnEnabled;
        }

        private void UpdateCharacterAbilitiesObjWithTextBox()
        {
            int intScore = 0;
            foreach (CharacterAbility objCharAbil in objCurrentChar.lstCharacterAbilities)
            {
                if (lblAbility1.Text.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                {
                    int.TryParse(txtAbility1.Text, out intScore);
                    objCharAbil.Score = intScore;
                    objCharAbil.ScoreMod = GetCharAbilityScoreModFromCharScore(objCharAbil.objAbility.AbilityID);
                }
                if (lblAbility2.Text.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                {
                    int.TryParse(txtAbility2.Text, out intScore);
                    objCharAbil.Score = intScore;
                    objCharAbil.ScoreMod = GetCharAbilityScoreModFromCharScore(objCharAbil.objAbility.AbilityID);
                }
                if (lblAbility3.Text.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                {
                    int.TryParse(txtAbility3.Text, out intScore);
                    objCharAbil.Score = intScore;
                    objCharAbil.ScoreMod = GetCharAbilityScoreModFromCharScore(objCharAbil.objAbility.AbilityID);
                }
                if (lblAbility4.Text.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                {
                    int.TryParse(txtAbility4.Text, out intScore);
                    objCharAbil.Score = intScore;
                    objCharAbil.ScoreMod = GetCharAbilityScoreModFromCharScore(objCharAbil.objAbility.AbilityID);
                }
                if (lblAbility5.Text.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                {
                    int.TryParse(txtAbility5.Text, out intScore);
                    objCharAbil.Score = intScore;
                    objCharAbil.ScoreMod = GetCharAbilityScoreModFromCharScore(objCharAbil.objAbility.AbilityID);
                }
                if (lblAbility6.Text.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                {
                    int.TryParse(txtAbility6.Text, out intScore);
                    objCharAbil.Score = intScore;
                    objCharAbil.ScoreMod = GetCharAbilityScoreModFromCharScore(objCharAbil.objAbility.AbilityID);
                }
            }
        }

        private void CheckStatusForAddCharacterLevelButton()
        {
            if ((objCurrentChar.RaceID != 0) && (objCurrentChar.lstCharacterAbilities.Count > 0)) btnAddCharacterLevel.Enabled = true; else btnAddCharacterLevel.Enabled = false;
        }

        private Race GetComboRaceObject()
        {
            Race charRace = new Race();
            string strRace = "";
            string strSex = "";

            if (this.cmbRace.SelectedItem.ToString().Contains(" - "))
            {
                strRace = this.cmbRace.SelectedItem.ToString().Substring(0, this.cmbRace.SelectedItem.ToString().IndexOf(" - "));
                strSex = this.cmbRace.SelectedItem.ToString().Substring(this.cmbRace.SelectedItem.ToString().IndexOf(" - ") + 3);
                strRace.Trim();
                strSex.Trim();
                charRace.GetRace(strRace, strSex);
                this.txtSex.Text = strSex;
                this.txtSex.Enabled = false;
            }
            else
            {
                charRace.GetRace(this.cmbRace.SelectedItem.ToString());
                this.txtSex.Enabled = true;
                this.txtSex.Text = "";
            }
            return charRace;
        }

        private void SetRaceComboBoxChangedData()
        {
            if (!blnOriginalLoadOfCharacter)
            {
                ResetCharacterScoresToOriginal();

                Race charRace = new Race();
                charRace = GetComboRaceObject();
                //string strRace = "";
                //string strSex = "";

                //if (this.cmbRace.SelectedItem.ToString().Contains(" - "))
                //{
                //    strRace = this.cmbRace.SelectedItem.ToString().Substring(0, this.cmbRace.SelectedItem.ToString().IndexOf(" - "));
                //    strSex = this.cmbRace.SelectedItem.ToString().Substring(this.cmbRace.SelectedItem.ToString().IndexOf(" - ") + 3);
                //    strRace.Trim();
                //    strSex.Trim();
                //    charRace.GetRace(strRace, strSex);
                //    this.txtSex.Text = strSex;
                //    this.txtSex.Enabled = false;
                //}
                //else
                //{
                //    charRace.GetRace(this.cmbRace.SelectedItem.ToString());
                //    this.txtSex.Enabled = true;
                //    this.txtSex.Text = "";
                //}

                objCurrentChar.RaceID = charRace.RaceID;
                objCurrentChar.objRace = charRace;

                if (objCurrentChar.objRace.objRaceAbilityModifiers.Count > 0)
                {
                    foreach (RaceAbilityModifier objRAM in objCurrentChar.objRace.objRaceAbilityModifiers)
                    {
                        UpdateAbilityWithRAM(objRAM);
                    }
                }
                FillCharacterScoresOut();
                UpdateCharacterAbilitiesObjWithTextBox();
                SetPhysicalDescriptionGroup();
                //TODO: Update the defense for race also, if any
                UpdateRaceDefenseScores(charRace);
                UpdateCharacterMovementListBox(charRace);
            }
        }
        
        private void UpdateCharacterMovementListBox(Race objRace)
        {
            lvCharSpeeds.Items.Clear();

            foreach (Speed objSpeed in objRace.objSpeeds)
            {
                ListViewItem objLVI = Common.CreateListViewItem(objSpeed.SpeedID, objSpeed.SpeedName, objSpeed.SpeedRate.ToString(), true);
                lvCharSpeeds.Items.Add(objLVI);
            }
        }

        private void UpdateAbilityModForDefense(TextBox txtMod, string strAbility)
        {
            switch (strAbility.ToLower())
            {
                case "constitution":
                    this.txtFortAbility.Text = txtMod.Text;
                    break;
                case "wisdom":
                    this.txtWillAbility.Text = txtMod.Text;
                    break;
                case "dexterity":
                    this.txtReflexAbility.Text = txtMod.Text;
                    break;
                default:
                    break;
            }
        }

        private void GetFortTotal()
        {
            int intLevelArmor = 0;
            int intAbility = 0;
            int intClass = 0;
            int intRace = 0;
            int intFeat = 0;
            int intMisc = 0;

            int.TryParse(this.txtFortLevelArmor.Text, out intLevelArmor);
            int.TryParse(this.txtFortAbility.Text, out intAbility);
            int.TryParse(this.txtFortClass.Text, out intClass);
            int.TryParse(this.txtFortRace.Text, out intRace);
            int.TryParse(this.txtFortFeat.Text, out intFeat);
            int.TryParse(this.txtFortMisc.Text, out intMisc);

            this.txtFortitudeTotal.Text = (10 + intLevelArmor + intAbility + intClass + intRace + intFeat + intMisc).ToString();
        }

        private void GetReflexTotal()
        {
            int intLevelArmor = 0;
            int intAbility = 0;
            int intClass = 0;
            int intRace = 0;
            int intFeat = 0;
            int intMisc = 0;

            int.TryParse(this.txtReflexLevelArmor.Text, out intLevelArmor);
            int.TryParse(this.txtReflexAbility.Text, out intAbility);
            int.TryParse(this.txtReflexClass.Text, out intClass);
            int.TryParse(this.txtReflexRace.Text, out intRace);
            int.TryParse(this.txtReflexFeat.Text, out intFeat);
            int.TryParse(this.txtReflexMisc.Text, out intMisc);

            this.txtReflexTotal.Text = (10 + intLevelArmor + intAbility + intClass + intRace + intFeat + intMisc).ToString();
        }

        private void GetWillTotal()
        {
            int intLevelArmor = 0;
            int intAbility = 0;
            int intClass = 0;
            int intRace = 0;
            int intFeat = 0;
            int intMisc = 0;

            int.TryParse(this.txtWillLevelArmor.Text, out intLevelArmor);
            int.TryParse(this.txtWillAbility.Text, out intAbility);
            int.TryParse(this.txtWillClass.Text, out intClass);
            int.TryParse(this.txtWillRace.Text, out intRace);
            int.TryParse(this.txtWillFeat.Text, out intFeat);
            int.TryParse(this.txtWillMisc.Text, out intMisc);

            this.txtWillTotal.Text = (10 + intLevelArmor + intAbility + intClass + intRace + intFeat + intMisc).ToString();
        }

        private void UpdateModValue(TextBox txtMod, int intScore)
        {
            txtMod.Text = ((intScore-(10))/(2)).ToString();
        }

        private void LoadConditionTrack()
        {
            ConditionTrack conditionTrack = new ConditionTrack();
            //List<SubSkill> subSkills  = new List<SubSkill>();
            List<ConditionTrack> conditionTracks = new List<ConditionTrack>();

            //subSkills = subSkill.GetSubSkills("", " SubSkillName ");
            conditionTracks = conditionTrack.GetConditionTracks("", " ConditionTrackID ");

            this.lvConditionTrack.Columns.Add("Modifier");
            //this.lvConditionTrack.Columns.Add("Skill Name");
            this.lvConditionTrack.Columns.Add("Description");
            foreach (ConditionTrack objConditionTrack in conditionTracks)
            {
                //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                ListViewItem lvItem = Common.CreateListViewItem(objConditionTrack.Modifier, objConditionTrack.Description, true);
                this.lvConditionTrack.Items.Add(lvItem);
            }
            Common.FormatListViewControlColumns(lvConditionTrack);
        }

        private void LoadEquipmentList()
        {
            tvEquipment.Nodes.Clear();
            List<EquipmentType> lstEquipmentTypes = new List<EquipmentType>();
            EquipmentType objET = new EquipmentType();
            lstEquipmentTypes = objET.GetEquipmentTypesByCharacterID(objCurrentChar.CharacterID);

            List<CharacterEquipment> lstCharEquip = new List<CharacterEquipment>();         

            foreach (EquipmentType objEquipType in lstEquipmentTypes)
            {
                TreeNode objETTN = new TreeNode();
                objETTN.Text = objEquipType.EquipmentTypeName ;
                objETTN.Tag = objEquipType.EquipmentTypeID;

                CharacterEquipment objCharEquip = new CharacterEquipment();
                lstCharEquip = objCharEquip.GetCharacterEquipmentListByType(objCurrentChar.CharacterID, objEquipType.EquipmentTypeID);

                foreach (CharacterEquipment objListCharEquip in lstCharEquip )
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objListCharEquip.objEquipment.EquipmentName;
                    objTN.Tag = objListCharEquip.CharacterEquipmentID;
                    objETTN.Nodes.Add(objTN);
                }
                tvEquipment.Nodes.Add(objETTN);
            }

        }

        private void LoadAbilityFields()
        {
            Ability ability = new Ability();
            //List<SubSkill> subSkills  = new List<SubSkill>();
            List<Ability> abilities = new List<Ability>();
            int AbilityBoxIDNum = 1;

            //subSkills = subSkill.GetSubSkills("", " SubSkillName ");
            abilities = ability.GetAbilites("", " SortOrder ASC ");

            foreach (Ability objAbility in abilities)
            {
                switch (AbilityBoxIDNum)
                {
                    case 1:
                        //FirstBox 
                        lblAbility1.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 2:
                        lblAbility2.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 3:
                        lblAbility3.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 4:
                        lblAbility4.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 5:
                        lblAbility5.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 6:
                        lblAbility6.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    default:
                        lblAbility1.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                }
            }

        }

        private int GetCharAbilityScoreFromCharScore(int AbilityID)
        {
            int retVal = 0;
            foreach (CharacterScores objCharScore in lstCharacterScore)
            {
                if (AbilityID ==objCharScore.AbilityID )
                {
                    retVal = objCharScore.Score;
                }
            }
            return retVal;
        }

        private int GetCharAbilityScoreModFromCharScore(int AbilityID)
        {
            int retVal = 0;
            foreach (CharacterScores objCharScore in lstCharacterScore)
            {
                if (AbilityID == objCharScore.AbilityID)
                {
                    retVal = objCharScore.ScoreMod;
                }
            }
            return retVal;
        }

        private void FillCharacterScoresOut()
        {
            FillOutAbilityField(lblAbility1, txtAbility1, txtAbility1Mod, false);
            FillOutAbilityField(lblAbility2, txtAbility2, txtAbility2Mod, false);
            FillOutAbilityField(lblAbility3, txtAbility3, txtAbility3Mod, false);
            FillOutAbilityField(lblAbility4, txtAbility4, txtAbility4Mod, false);
            FillOutAbilityField(lblAbility5, txtAbility5, txtAbility5Mod, false);
            FillOutAbilityField(lblAbility6, txtAbility6, txtAbility6Mod, false);

            //The objCharAbilities are empty, new character so wee need to create the list objects
            if ((objCurrentChar.lstCharacterAbilities == null) || (objCurrentChar.lstCharacterAbilities.Count == 0))
            {
                Ability objAbility = new Ability();
                List<Ability> lstAbility = new List<Ability>();
                lstAbility = objAbility.GetAbilites("", "");
                objCurrentChar.lstCharacterAbilities = new List<CharacterAbility>();
                foreach (Ability objAbil in lstAbility)
                {
                    CharacterAbility objCharAbility = new CharacterAbility(objAbil.AbilityID);
                    objCharAbility.Score = GetCharAbilityScoreFromCharScore(objAbil.AbilityID);
                    objCharAbility.ScoreMod = GetCharAbilityScoreModFromCharScore(objAbil.AbilityID);
                    objCurrentChar.lstCharacterAbilities.Add(objCharAbility);
                }
            }

                //Fill out the objCharacter 
            FillCharObjectWithScores(lblAbility1, txtAbility1, txtAbility1Mod);
            FillCharObjectWithScores(lblAbility2, txtAbility2, txtAbility2Mod);
            FillCharObjectWithScores(lblAbility3, txtAbility3, txtAbility3Mod);
            FillCharObjectWithScores(lblAbility4, txtAbility4, txtAbility4Mod);
            FillCharObjectWithScores(lblAbility5, txtAbility5, txtAbility5Mod);
            FillCharObjectWithScores(lblAbility6, txtAbility6, txtAbility6Mod);
            //}
        }

        private void ResetCharacterScoresToOriginal()
        {

            FillOutAbilityField(lblAbility1, txtAbility1, txtAbility1Mod, true);
            FillOutAbilityField(lblAbility2, txtAbility2, txtAbility2Mod, true);
            FillOutAbilityField(lblAbility3, txtAbility3, txtAbility3Mod, true);
            FillOutAbilityField(lblAbility4, txtAbility4, txtAbility4Mod, true);
            FillOutAbilityField(lblAbility5, txtAbility5, txtAbility5Mod, true);
            FillOutAbilityField(lblAbility6, txtAbility6, txtAbility6Mod, true);
        }

        private void FillCharObjectWithScores(Label lblAbility, TextBox txtAbility, TextBox txtAbilityMod)
        {
            int intScore = 0;
            int intMod = 0;

            int.TryParse(txtAbility.Text, out intScore);
            int.TryParse(txtAbilityMod.Text, out intMod);



            if (objCurrentChar.lstCharacterAbilities.Count > 0)
            {
                foreach (CharacterAbility objCharAbil in objCurrentChar.lstCharacterAbilities)
                {
                    if (lblAbility.Text.ToLower() == objCharAbil.objAbility.AbilityName.ToLower())
                    {
                        objCharAbil.Score = intScore;
                        objCharAbil.ScoreMod = intMod;
                    }
                }
            }
            else
            {
                //Blank array.
                CharacterAbility objNewCharAbil = new CharacterAbility();
                Ability objAbil = new Ability();
                
                objNewCharAbil.Score = intScore;
                objNewCharAbil.ScoreMod = intMod;
                objNewCharAbil.objAbility = objAbil.GetAbility(lblAbility.Text);
                objNewCharAbil.AbilityID = objAbil.AbilityID;
                objNewCharAbil.CharacterID = objCurrentChar.CharacterID;

            }

            //switch (lblAbility.Text.ToLower())
            //{
            //    case "strength":
            //        objCurrentChar.Strength = intScore;
            //        objCurrentChar.StrengthMod = intMod;
            //        break;
            //    case "intelligence":
            //        objCurrentChar.Intelligence = intScore;
            //        objCurrentChar.IntelligenceMod = intMod;
            //        break;
            //    case "wisdom":
            //        objCurrentChar.Wisdom = intScore;
            //        objCurrentChar.WisdomMod = intMod;
            //        break;
            //    case "dexterity":
            //        objCurrentChar.Dexterity = intScore;
            //        objCurrentChar.DexterityMod = intMod;
            //        break;
            //    case "constitution":
            //         objCurrentChar.Constitution  = intScore;
            //         objCurrentChar.ConstitutionMod = intMod;
            //        break;
            //    case "charisma":
            //         objCurrentChar.Charisma  = intScore;
            //         objCurrentChar.CharismaMod = intMod;
            //         break; 
            //}
        }

        private void FillOutAbilityField(Label lblAbility, TextBox txtAbility, TextBox txtAbilityMod, bool UseOriginalCharScores)
        {
            bool blnUseRace = false;
            int intScore;

            List<CharacterScores> lstCharScores = new List<CharacterScores>();

            if ((objCurrentChar.RaceID != 0) && (objCurrentChar.CharacterLevelID ==0))
            {
                blnUseRace = true;
            }

            if (UseOriginalCharScores)
            {
                lstCharScores = lstOriginalCharacterScores;
            }
            else
            {
                lstCharScores = lstCharacterScore;
            }

            foreach (CharacterScores objCharScore in lstCharScores)
            {
                if (objCharScore.AbilityName == lblAbility.Text)
                {
                    if (blnUseRace)
                    {
                        //Add the Race Modification
                        intScore = CalculateScoreWithRaceModifier(objCharScore, objCurrentChar.objRace);
                        txtAbility.Text = intScore.ToString();
                        UpdateModValue(txtAbilityMod, intScore); 
                    }
                    else
                    {
                        //Just Put the original Score in the text box
                        txtAbility.Text = objCharScore.Score.ToString();
                        UpdateModValue(txtAbilityMod, objCharScore.Score); 
                    }
                }
            }
      
            //else
            //{
            //     foreach (CharacterScores objCharScore in lstCharacterScore)
            //     {
            //           if (objCharScore.AbilityName == lblAbility.Text)
            //            {
            //                if (blnUseRace)
            //                {
            //                    //Add the Race Modification
            //                    intScore = CalculateScoreWithRaceModifier(objCharScore, objRace);
            //                    txtAbility.Text = intScore.ToString();
            //                    UpdateModValue(txtAbilityMod, intScore); 
            //                }
            //                else
            //                {
            //                    //Just Put the original Score in the text box
            //                    txtAbility.Text = objCharScore.Score.ToString();
            //                    UpdateModValue(txtAbilityMod, objCharScore.Score); 
            //                }
            //            }
            //     }
            //}
        }

        private int CalculateScoreWithRaceModifier(CharacterScores objCharScore, Race objRace)
        {
            int ReturnVal = 0;
            bool blnFound = false;

            foreach ( RaceAbilityModifier objRAM in objRace.objRaceAbilityModifiers )
            {
                if (objCharScore.AbilityID == objRAM.AbilityID )
                {
                    blnFound = true;
                    if (objRAM.objModifier.ModifierPositive) ReturnVal = objCharScore.Score + objRAM.objModifier.ModifierNumber; else ReturnVal =objCharScore.Score - objRAM.objModifier.ModifierNumber;
                }
            }

            if (!blnFound) ReturnVal = objCharScore.Score;
            return ReturnVal;
        }

        private void LoadDropDowns()
        {
            LoadRaceDropDown();
            LoadOrganizationDropDown();
            LoadForceTradition();
        }

        private void LoadForceTradition()
        {
            cmbForceTradition.Items.Clear();

            ForceTradition  objForceTradition = new ForceTradition();
            List<ForceTradition> objForceTraditions = new List<ForceTradition>();

            objForceTraditions = objForceTradition.GetForceTraditions("", " ForceTraditionName");
            cmbForceTradition.Items.Add("");
            foreach (ForceTradition lstForceTradition in objForceTraditions)
            {
                cmbForceTradition.Items.Add(lstForceTradition.ForceTraditionName);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        private void LoadOrganizationDropDown()
        {
            cmbOrganization.Items.Clear();

            Organization objOrganization = new Organization();
            List<Organization> objOrganizations = new List<Organization>();


            objOrganizations = objOrganization.GetOrganizations("", " OrganizationName");
            cmbOrganization.Items.Add("");
            foreach (Organization lstOrganization in objOrganizations)
            {
                cmbOrganization.Items.Add(lstOrganization.OrganizationName);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }
        
        private void LoadRaceDropDown()
        {
            cmbRace.Items.Clear();

            Race objRace = new Race();
            List<Race> objRaces = new List<Race>();


            objRaces = objRace.GetRaces("", " RaceName");
            cmbRace.Items.Add("");
            foreach (Race lstRace in objRaces)
            {
                if (lstRace.Sex.ToUpper() != "B")
                {
                    cmbRace.Items.Add(lstRace.RaceName + " - " + lstRace.Sex);
                }
                else
                {
                    cmbRace.Items.Add(lstRace.RaceName);
                }
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        private void LoadCharacterLanguages()
        {
            this.lvLanguages.Items.Clear();

            foreach (Language objLang in objCurrentChar.lstLanguages )
            {
                ListViewItem objLVI = Common.CreateListViewItem(objLang.LanguageID , objLang.LanguageName ,  false);
                lvLanguages.Items.Add(objLVI);
            }

            //Common.FormatListViewControlColumns(lvLanguages);  //195    220
            if (lvLanguages.Items.Count > 7) lvLanguages.Columns[0].Width = 199; else lvLanguages.Columns[0].Width = 215;
        }

        private void UpdateAbilityWithRAM(RaceAbilityModifier objRam)
        {
            int intAblityScore = 0;

            if (this.lblAbility1.Text.ToLower() == objRam.objAbility.AbilityName.ToLower())
            {
                int.TryParse(txtAbility1.Text, out intAblityScore);
                if (objRam.objModifier.ModifierPositive) this.txtAbility1.Text = (intAblityScore + objRam.objModifier.ModifierNumber).ToString(); else this.txtAbility1.Text = (intAblityScore - objRam.objModifier.ModifierNumber).ToString();
            }
            else if (this.lblAbility2.Text.ToLower() == objRam.objAbility.AbilityName.ToLower())
            {
                int.TryParse(txtAbility2.Text, out intAblityScore);
                if (objRam.objModifier.ModifierPositive) this.txtAbility2.Text = (intAblityScore + objRam.objModifier.ModifierNumber).ToString(); else this.txtAbility2.Text = (intAblityScore - objRam.objModifier.ModifierNumber).ToString();
            }
            else if (this.lblAbility3.Text.ToLower() == objRam.objAbility.AbilityName.ToLower())
            {
                int.TryParse(txtAbility3.Text, out intAblityScore);
                if (objRam.objModifier.ModifierPositive) this.txtAbility3.Text = (intAblityScore + objRam.objModifier.ModifierNumber).ToString(); else this.txtAbility3.Text = (intAblityScore - objRam.objModifier.ModifierNumber).ToString();
            }
            else if (this.lblAbility4.Text.ToLower() == objRam.objAbility.AbilityName.ToLower())
            {
                int.TryParse(txtAbility4.Text, out intAblityScore);
                if (objRam.objModifier.ModifierPositive) this.txtAbility4.Text = (intAblityScore + objRam.objModifier.ModifierNumber).ToString(); else this.txtAbility4.Text = (intAblityScore - objRam.objModifier.ModifierNumber).ToString();
            }
            else if (this.lblAbility5.Text.ToLower() == objRam.objAbility.AbilityName.ToLower())
            {
                int.TryParse(txtAbility5.Text, out intAblityScore);
                if (objRam.objModifier.ModifierPositive) this.txtAbility5.Text = (intAblityScore + objRam.objModifier.ModifierNumber).ToString(); else this.txtAbility5.Text = (intAblityScore - objRam.objModifier.ModifierNumber).ToString();
            }
            else if (this.lblAbility6.Text.ToLower() == objRam.objAbility.AbilityName.ToLower())
            {
                int.TryParse(txtAbility6.Text, out intAblityScore);
                if (objRam.objModifier.ModifierPositive) this.txtAbility6.Text = (intAblityScore + objRam.objModifier.ModifierNumber).ToString(); else this.txtAbility6.Text = (intAblityScore - objRam.objModifier.ModifierNumber).ToString();
            }


        }
       
        private void UpdateRaceDefenseScores(Race objRace)
        {
            //Get all the RaceDefense Updates, can have at most three, one for each defense.
            //We have the race 

            List<RaceDefenseTypeModifier> objRDTMs = new List<RaceDefenseTypeModifier>();
            RaceDefenseTypeModifier objRDTM = new RaceDefenseTypeModifier();

            objRDTMs = objRDTM.GetRaceDefenseTypeModifiersByRace(objRace.RaceID, "");

            foreach (RaceDefenseTypeModifier lstRDTM in objRDTMs)
            {
                switch (lstRDTM.objDefenseType.DefenseTypeDescription.ToLower())
                {
                    case "reflex":
                        //if its relfex apply the defenses
                        if (lstRDTM.objModifier.ModifierPositive) txtReflexRace.Text = lstRDTM.objModifier.ModifierNumber.ToString(); else txtReflexRace.Text = (-1 * lstRDTM.objModifier.ModifierNumber).ToString();
                        break;

                    case "fortitude":
                        //if its fortitude apply the defenses
                        if (lstRDTM.objModifier.ModifierPositive) txtFortRace.Text = lstRDTM.objModifier.ModifierNumber.ToString(); else txtFortRace.Text = (-1 * lstRDTM.objModifier.ModifierNumber).ToString();
                        break;

                    case "will":
                        //if its will apply the defenses
                        if (lstRDTM.objModifier.ModifierPositive) txtWillRace.Text = lstRDTM.objModifier.ModifierNumber.ToString(); else txtWillRace.Text = (-1 * lstRDTM.objModifier.ModifierNumber).ToString();
                        break;

                    default:
                        break;
                }
            }
        }

        private void UpdateDefenseScores()
        {
            //Reset the scores
            txtReflexClass.Text = Class.GetMaximumDefenseValuesForClassList(lstCharacterClasses, "reflex").ToString();
            txtFortClass.Text = Class.GetMaximumDefenseValuesForClassList(lstCharacterClasses, "fortitude").ToString();
            txtWillClass.Text = Class.GetMaximumDefenseValuesForClassList(lstCharacterClasses, "will").ToString();

        }

        public List<CharacterScores> SetOriginalScores()
        {
            CharacterScores objCharScore;
            List<CharacterScores> lstCharScore = new List<CharacterScores>();
            foreach (CharacterAbility objCharAbility in objCurrentChar.lstCharacterAbilities)
            {
                objCharScore = new CharacterScores();
                objCharScore.AbilityID = objCharAbility.AbilityID;
                objCharScore.AbilityName = objCharAbility.objAbility.AbilityName;
                objCharScore.Score = objCharAbility.Score;
                objCharScore.ScoreMod = objCharAbility.ScoreMod;
                lstCharScore.Add(objCharScore);
            }

            return lstCharScore;
        }

        public void SetFormWithCurrentCharacter()
        {
            this.txtName.Text = objCurrentChar.CharacterName;
            this.txtXP.Text = objCurrentChar.ExperiencePoints.ToString();
            this.txtDestinyPoints.Text = objCurrentChar.DestintyPoints.ToString();
            this.txtForcePoints.Text = objCurrentChar.ForcePoints.ToString();
            this.txtLevel.Text = objCurrentChar.CharacterLevelID.ToString();    //CharacterLevelID is also the Character Level
            //this.txtSpeed.Text = objCurrentChar.Movement.ToString();
            this.txtHitPoints.Text = objCurrentChar.HitPoints.ToString();
            this.txtDarkSidePoints.Text = objCurrentChar.DarkSidePoints.ToString();
            this.txtDamageThreshold.Text = objCurrentChar.DamageThreshold.ToString();
            this.txtBaseAttack.Text = objCurrentChar.CalculateBaseAttack().ToString(); //objCurrentChar.BaseAttack.ToString();
            this.txtSex.Text = objCurrentChar.Sex;
            this.txtCredits.Text = objCurrentChar.Credits.ToString();

            this.lblDestinyMax.Text = "Max: " + objCurrentChar.CharacterLevelID; //CharacterLevelID is also the max Destiny Points Value
            this.lblMaxForcePoints.Text = "Max: " + objCurrentChar.CalculateMaxForcePoints().ToString();
            Ability objWisAbil = new Ability("Wisdom");
            this.lblDarkSideMax.Text = "Max: " + objCurrentChar.GetCharacterAbilityScore(objWisAbil).ToString();
           

            blnOriginalLoadOfCharacter = true;
            this.cmbRace.SelectedItem = objCurrentChar.objRace.RaceName;
            blnOriginalLoadOfCharacter = false;

            LoadDefenseScores();

            LoadOrganizationListView(objCurrentChar.lstCharacterOrganizations);

            LoadCharacterClassText(objCurrentChar.lstCharacterClassLevels);

            FillCharacterScoresOut();

            FillOutCharacterSkills();

            FillOutCharacterWeapons();

            FillOutCharacterArmors();

            LoadEquipmentList();

            LoadCharacterSpeedListView();

            LoadCharacterLanguages();

            SetPhysicalDescriptionGroup();

            EnableCharacterRelatedButtons(true);

            Dictionary<int, int> dicFeatDefIncs = new Dictionary<int,int>();
            Dictionary<int, int> dicTalentDefIncs = new Dictionary<int,int>();

            Common.LoadDictionaryWithDamageThresholdIncreases(out dicFeatDefIncs, true);
            Common.LoadDictionaryWithDamageThresholdIncreases(out dicTalentDefIncs, false);

            this.txtDamageThreshold.Text = objCurrentChar.CalculateDamageThreshold(Common.GetAppSettingsID("FightThroughPainFeatID"), dicFeatDefIncs, dicTalentDefIncs).ToString();
            CheckStatusForRaceCombo();
        }
        
        private void EnableCharacterRelatedButtons(bool blnButtonStatus)
        {
            this.btnAddEquipment.Enabled = blnButtonStatus;
            this.btnAddArmor.Enabled = true;
            this.btnAddCharWeapon.Enabled = true;
        }

        private void SetAddCharacterWeaponButtonStatus()
        {
            if (objCurrentChar.lstCharacterWeapons.Count < 4) this.btnAddCharWeapon.Enabled = true; else this.btnAddCharWeapon.Enabled = false;
        }

        private void SetAddCharacterArmorButtonStatus()
        {
            if (objCurrentChar.lstCharacterArmors.Count < 2) this.btnAddArmor.Enabled = true; else this.btnAddArmor.Enabled = false;
        }

        private void FillOutCharacterWeapons()
        {
            int counter = 1;
            int max = 4;
            //Get the first 4 weapons and display them

            objCurrentChar.UpdateCharacterWeaponStats(Common.GetAppSettingsID("Weapon_Finese_SimpleWeapons"), Common.GetAppSettingsID("Weapon_Finese_Lightsabers"));

            foreach (CharacterWeapon objCW in objCurrentChar.lstCharacterWeapons)
            {
                if (counter <= max)
                {
                    FillOutCWC(objCW);
                    counter++;
                }
            }
            SetAddCharacterWeaponButtonStatus();
        }

        private void FillOutCharacterArmors()
        {
            int counter = 1;
            int max = 2;
            //Get the first 2 Armors and display them

            //objCurrentChar.UpdateCharacterWeaponStats(Common.GetAppSettingsID("Weapon_Finese_SimpleWeapons"), Common.GetAppSettingsID("Weapon_Finese_Lightsabers"));

            foreach (CharacterArmor objCA in objCurrentChar.lstCharacterArmors )
            {
                if (counter <= max)
                {
                    FillOutCAC(objCA);
                    counter++;
                }
            }
            SetAddCharacterArmorButtonStatus();
        }

        private void ResetCharacterWeaponControls()
        {
            grpCharWeapon1.Visible = false;
            cwc1.ResetControl();
            grpCharWeapon2.Visible = false;
            cwc2.ResetControl();
            grpCharWeapon3.Visible = false;
            cwc3.ResetControl();
            grpCharWeapon4.Visible = false;
            cwc4.ResetControl();

        }

        private void ResetCharacterArmorControls()
        {
            this.grpArmor1.Visible = false;
            cac1.ResetControl();
            this.grpArmor2.Visible = false;
            cac2.ResetControl();
        }

        private void FillOutCWC(CharacterWeapon objCW)
        {
            if (cwc1.CharacterID ==0 )
            {
                grpCharWeapon1.Visible = true;
                cwc1.ControlNumber = 1;
                cwc1.SetControlWithCharacterWeapon(objCurrentChar, objCW);
                cwc1.EditModifications_Click += new EventHandler(btnWeaponAddEmplacementPoint1_Click);
            }
            else if (cwc2.CharacterID == 0)
            {
                grpCharWeapon2.Visible = true;
                cwc2.ControlNumber = 2;
                cwc2.SetControlWithCharacterWeapon(objCurrentChar, objCW);
                cwc2.EditModifications_Click += new EventHandler(btnWeaponAddEmplacementPoint2_Click);

            }
            else if (cwc3.CharacterID == 0)
            {
                grpCharWeapon3.Visible = true;
                cwc3.ControlNumber = 3;
                cwc3.SetControlWithCharacterWeapon(objCurrentChar, objCW);
                cwc3.EditModifications_Click += new EventHandler(btnWeaponAddEmplacementPoint3_Click);

            }
            else if (cwc4.CharacterID == 0)
            {
                grpCharWeapon4.Visible = true;
                cwc4.ControlNumber = 4;
                cwc4.SetControlWithCharacterWeapon(objCurrentChar, objCW);
                cwc4.EditModifications_Click += new EventHandler(btnWeaponAddEmplacementPoint4_Click);

            }
        }

        private void FillOutCAC(CharacterArmor objCA)
        {
            if (cac1.CharacterID ==0 )
            {
                this.grpArmor1.Visible = true;
                cac1.ControlNumber = 1;
                cac1.SetControlWithCharacterArmor(objCurrentChar, objCA);
                cac1.AddEmplacementPoint_Click += new EventHandler(btnArmorAddEmplacementPoint1_Click);
                //cac1.RemoveEmplacementPoint_Click += new EventHandler(btnArmorRemoveEmplacementPoint1_Click);
            }
            else if (cac2.CharacterID == 0)
            {
                this.grpArmor2.Visible = true;
                cac2.ControlNumber = 2;
                cac2.SetControlWithCharacterArmor(objCurrentChar, objCA);
                cac2.AddEmplacementPoint_Click += new EventHandler(btnArmorAddEmplacementPoint2_Click);
                //cac2.RemoveEmplacementPoint_Click += new EventHandler(btnArmorRemoveEmplacementPoint2_Click);
            }
        }

        private void FillOutCEC(CharacterEquipment objCE)
        {
            CEC1.ResetControl();
            CEC1.SetControlWithCharacterEquipment(objCurrentChar, objCE);
        }

        private void ExchangeArmor (int OriginailCharacterArmorID, Character_Armor_Control objCAC)
        {
            DialogResult result = new DialogResult();
            //int intMainFormCredits = 0;
            //frmOrganization.lstCharOrgs = objCurrentChar.objCharacterOrganizations;
            frmArmorSelection.objCharacter = objCurrentChar;
            frmArmorSelection frmAS = new frmArmorSelection(objCAC.ArmorID);
            result = frmAS.ShowDialog();


            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //Remove the original WeaponID from the Database 
                if (blnAllowCreditOnDeleteExchange) CreditItemCostOnDelete(objCAC.objCharArmor.objArmor.Cost, Common.ModificationType.Armor);
                DeleteWeaponFromDatabase(OriginailCharacterArmorID);

                //Create a New CharacterWeapon object and add it to the Characters List
                objCurrentChar.lstCharacterArmors = CharacterArmor.RemoveCharacterArmorFromList(OriginailCharacterArmorID, objCurrentChar.lstCharacterArmors);

                CharacterArmor objCA = new CharacterArmor(objCurrentChar.CharacterID, intNewCharacterArmorArmorID);
                Armor objArmor = new Armor(intNewCharacterArmorArmorID);
                objCA = objCA.CreateCharacterArmor(objCurrentChar, objArmor);

                if (DeductCreditsFromCharacter(objArmor.Cost))
                {
                    //if (blnUseCredits) this.txtCredits.Text = objCurrentChar.Credits.ToString();
                    objCurrentChar.lstCharacterArmors.Add(objCA);
                    objCAC.SetControlWithCharacterArmor(objCurrentChar, objCA);
                }

                //if (blnUseCredits)
                //{
                //    if (DeductCreditsFromCharacter(objArmor.Cost))
                //    {
                //        fred
                //    }
                //    //int.TryParse(this.txtCredits.Text, out intMainFormCredits);
                //    if (objCurrentChar.DeductCreditsFromCharacter(intMainFormCredits, objArmor.Cost))
                //    {
                //        objCurrentChar.lstCharacterArmors.Add(objCA);
                //        objCAC.SetControlWithCharacterArmor(objCurrentChar, objCA);
                //    }
                //}
                //else
                //{
                //    //Not using credits just do it.
                //    objCurrentChar.lstCharacterArmors.Add(objCA);
                //    objCAC.SetControlWithCharacterArmor(objCurrentChar, objCA);
                //}

            }
        }

        private void ExchangeWeapon(int OriginalCharacterWeaponID, Character_Weapon_Control objCWC)
        {
            DialogResult result = new DialogResult();
            //int intMainFormCredits = 0;

           frmWeaponSelection.objCharacter = objCurrentChar;
           frmWeaponSelection frmWS = new frmWeaponSelection();
            result = frmWS.ShowDialog();


            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //Remove the original WeaponID from the Database 
                if (blnAllowCreditOnDeleteExchange) CreditItemCostOnDelete(objCWC.objCharWeapon.objWeapon.Cost, Common.ModificationType.Weapon); 
                DeleteWeaponFromDatabase(OriginalCharacterWeaponID);

                //Create a New CharacterWeapon object and add it to the Characters List
                objCurrentChar.lstCharacterWeapons = CharacterWeapon.RemoveCharacterWeaponFromList(OriginalCharacterWeaponID, objCurrentChar.lstCharacterWeapons);

                CharacterWeapon objCW = new CharacterWeapon(objCurrentChar.CharacterID, intNewCharacterWeaponWeaponID);
                Weapon objWeapon = new Weapon(intNewCharacterWeaponWeaponID);
                objCW = objCW.CreateCharacterWeapon(objCurrentChar, objWeapon);

                if (DeductCreditsFromCharacter(objWeapon.Cost)) UpdateCharacterWeaponControl(objCW, true, objCWC);
                //if (blnUseCredits) this.txtCredits.Text = objCurrentChar.Credits.ToString();

                //if (blnUseCredits)
                //{
                //    int.TryParse(this.txtCredits.Text, out intMainFormCredits);
                //    if (objCurrentChar.DeductCreditsFromCharacter(intMainFormCredits, objWeapon.Cost)) UpdateCharacterWeaponControl(objCW, true, objCWC);
                //}
                //else UpdateCharacterWeaponControl(objCW, true, objCWC);
            }
        }

        private void DeleteArmor(int OriginalCharacterArmorID, Character_Armor_Control objCAC)
        {
            int counter = 1;
            DeleteArmorFromDatabase(OriginalCharacterArmorID);

            List<CharacterArmor> lstNewCharArmorList = new List<CharacterArmor>();

            //Remove object from the lst
            foreach (CharacterArmor objCA in objCurrentChar.lstCharacterArmors)
            {
                if (counter != objCAC.ControlNumber) lstNewCharArmorList.Add(objCA);  // objCurrentChar.objCharacterWeapons.Remove(objCW); 
                counter++;
            }

            objCurrentChar.lstCharacterArmors = lstNewCharArmorList;

            ResetCharacterArmorControls();
            FillOutCharacterArmors();

        }

        private void DeleteWeapon(int OriginalCharacterWeaponID, Character_Weapon_Control objCWC)
        {
            int counter = 1;
            DeleteWeaponFromDatabase(OriginalCharacterWeaponID);

            List<CharacterWeapon> lstNewCharWeaponList = new List<CharacterWeapon>();

            //Remove object from the lst
            foreach (CharacterWeapon objCW in objCurrentChar.lstCharacterWeapons)
            {
                if (counter != objCWC.ControlNumber) lstNewCharWeaponList.Add(objCW);  // objCurrentChar.objCharacterWeapons.Remove(objCW); 
                counter++;
            }
            
            objCurrentChar.lstCharacterWeapons = lstNewCharWeaponList;

            ResetCharacterWeaponControls();
            FillOutCharacterWeapons();

        }

        private void DeleteWeaponFromDatabase(int OriginalCharacterWeaponID)
        {
            CharacterWeapon objDelCW = new CharacterWeapon(OriginalCharacterWeaponID);
            //TODO REMOVE THE COMMENT BELOW
            //objDelCW.DeleteCharacterWeapon();
        }

        private void DeleteArmorFromDatabase(int OriginalCharacterArmorID)
        {
            CharacterArmor objDelCA = new CharacterArmor(OriginalCharacterArmorID);
            //TODO REMOVE THE COMMENT BELOW
            //objDelCA.DeleteCharacterArmor();
        }

        private void FillOutCharacterSkills()
        {
            Skill objSkill = new Skill();
            List<Skill> lstAllSkills = new List<Skill>();
            lstAllSkills = objSkill.GetSkills("", "SkillName");
            
            Talent objEducatedTalent = new Talent(Common.GetAppSettingsID("Educated"));

            CharacterSkill objCharSkill = new CharacterSkill();
            foreach (Skill objLSkill in lstAllSkills)
            {
                Ability objAbility = new Ability(objLSkill.AbilityID);
                //Check to see if there is a characterskill for this skill
                if (CharacterSkill.IsSkillInList (objLSkill,objCurrentChar.lstCharacterSkills ))
                {
                    //get the charSkill and call FillOutCharacterSkillControls
                    FillOutCharacterSkillControls(CharacterSkill.GetCharacterSkillFromListBySkill(objLSkill, objCurrentChar.lstCharacterSkills));
                }
                else
                {
                    objCharSkill = new CharacterSkill();
                    //If its trained only fill in blanks else fill in the stats that the char has
                    objCharSkill.CharacterID = objCurrentChar.CharacterID;
                    objCharSkill.FeatTalentMod = 0;
                    objCharSkill.Miscellaneous = 0;
                    objCharSkill.objSkill = objLSkill;
                    objCharSkill.SkillID = objLSkill.SkillID;
                    objCharSkill.Trained = 0;
                    objCharSkill.SkillFocus = 0;

                    if (objLSkill.TrainedSkill)
                    {
                        if ((objLSkill.SkillName.ToLower().Contains("knowledge")) && (Talent.IsTalentInList(objEducatedTalent,objCurrentChar.lstTalents )))
                        {
                                objCharSkill.AbilityMod = objCurrentChar.GetCharacterAbilityModifier(objAbility);
                                objCharSkill.HalfLevel = objCurrentChar.CharacterLevelID / 2;
                        }
                        else
                        {
                            objCharSkill.AbilityMod = 0;
                            objCharSkill.HalfLevel = 0;
                        }
                    }
                    else
                    {
                        objCharSkill.AbilityMod = objCurrentChar.GetCharacterAbilityModifier(objAbility);
                        objCharSkill.HalfLevel = objCurrentChar.CharacterLevelID / 2;
                    }

                    FillOutCharacterSkillControls(objCharSkill);
                }
            }
        }

        private void FillOutCharacterSkillControls(CharacterSkill objCharSkill)
        {
            if (csc1.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc1);
            else if (csc2.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc2);
            else if (csc3.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc3);
            else if (csc4.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc4);
            else if (csc5.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc5);
            else if (csc6.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc6);
            else if (csc7.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc7);
            else if (csc8.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc8);
            else if (csc9.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc9);
            else if (csc10.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc10);
            else if (csc11.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc11);
            else if (csc12.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc12);
            else if (csc13.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc13);
            else if (csc14.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc14);
            else if (csc15.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc15);
            else if (csc16.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc16);
            else if (csc17.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc17);
            else if (csc18.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc18);
            else if (csc19.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc19);
            else if (csc20.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc20);
            else if (csc21.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc21);
            else if (csc22.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc22);
            else if (csc23.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc23);
            else if (csc24.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc24);
            else if (csc25.SkillName == "") FillOutCharacterSkillControl(objCharSkill, csc25);
        }

        private void FillOutCharacterSkillControl(CharacterSkill objCharSkill, CharacterSkillControl cscTemp)
        {
            cscTemp.SkillName = objCharSkill.objSkill.SkillName;
            cscTemp.SkillAbilityModValue  = objCharSkill.AbilityMod;
            cscTemp.SkillFeatTalentValue = objCharSkill.FeatTalentMod;
            cscTemp.SkillFocusValue = objCharSkill.SkillFocus;
            cscTemp.SkillTrainedValue = objCharSkill.Trained;
            cscTemp.SkillHalfLevelValue = objCharSkill.HalfLevel;
            cscTemp.SkillMiscellaneousValue = objCharSkill.Miscellaneous;

        }

        private void ResetCharacterSkillControls()
        {
            ResetCharacterSkillControl( csc1);
            ResetCharacterSkillControl( csc2);
            ResetCharacterSkillControl( csc3);
            ResetCharacterSkillControl( csc4);
            ResetCharacterSkillControl( csc5);
            ResetCharacterSkillControl( csc6);
            ResetCharacterSkillControl( csc7);
            ResetCharacterSkillControl( csc8);
            ResetCharacterSkillControl( csc9);
            ResetCharacterSkillControl( csc10);
            ResetCharacterSkillControl( csc11);
            ResetCharacterSkillControl( csc12);
            ResetCharacterSkillControl( csc13);
            ResetCharacterSkillControl( csc14);
            ResetCharacterSkillControl( csc15);
            ResetCharacterSkillControl( csc16);
            ResetCharacterSkillControl( csc17);
            ResetCharacterSkillControl( csc18);
            ResetCharacterSkillControl( csc19);
            ResetCharacterSkillControl( csc20);
            ResetCharacterSkillControl( csc21);
            ResetCharacterSkillControl( csc22);
            ResetCharacterSkillControl( csc23);
            ResetCharacterSkillControl( csc24);
            ResetCharacterSkillControl( csc25);
        }
        
        private void ResetCharacterSkillControl(CharacterSkillControl cscTemp)
        {
            cscTemp.SkillName = "";
            cscTemp.SkillAbilityModValue = 0;
            cscTemp.SkillFeatTalentValue = 0;
            cscTemp.SkillFocusValue = 0;
            cscTemp.SkillTrainedValue = 0;
            cscTemp.SkillHalfLevelValue = 0;
            cscTemp.SkillMiscellaneousValue = 0;
        }

        private void LoadCharacterClassText(List<CharacterClassLevel> lstCharClassLevel)
        {
            //lstSelTN.OrderBy(n => n.Text).ToList<TreeNode>();

            lstCharClassLevel = lstCharClassLevel.OrderBy(n => n.objCharacterClass.IsPrestige).ThenBy(n => n.objCharacterClass.ClassName).ToList<CharacterClassLevel>();
            //lstCharClassLevel = lstCharClassLevel.OrderBy(n => n.objCharacterClass.IsPrestige).ToList<CharacterClassLevel>();
            //lstCharClassLevel = lstCharClassLevel.OrderBy(n => n.objCharacterClass.ClassName).ToList<CharacterClassLevel>();

            txtClass.Text = "";
            StringBuilder sbClassLevelList = new StringBuilder();

            foreach (CharacterClassLevel objCCL in lstCharClassLevel )
            {
                sbClassLevelList.Append(objCCL.objCharacterClass.ClassName + ": " + objCCL.ClassLevel + ", ");
            }
            sbClassLevelList.Remove(sbClassLevelList.Length - 2, 2);

            txtClass.Text = sbClassLevelList.ToString();
        }

        private void LoadOrganizationListView(List<Organization> lstCharOrgs)
        {
            lvOrganizations.Columns.Clear();
            lvOrganizations.Items.Clear();

            lvOrganizations.Columns.Add("Organization Name");
            foreach (Organization objOrg in lstCharOrgs)
            {
                ListViewItem objLVI = Common.CreateListViewItem(objOrg.OrganizationID, objOrg.OrganizationName, false);
                lvOrganizations.Items.Add(objLVI);
            }
            Common.FormatListViewControlColumns(lvOrganizations);

        }

        private void LoadCharacterSpeedListView()
        {
            //lvCharSpeeds.Columns.Clear();
            lvCharSpeeds.Items.Clear();

            //lvCharSpeeds.Columns.Add("Speed Type");
            //lvCharSpeeds.Columns.Add("Speed Rate");
            foreach (Speed objSpeed in objCurrentChar.lstCharacterSpeeds)
            {
                ListViewItem objLVI = new ListViewItem();  //Common.CreateListViewItem(objSpeed.SpeedName, objSpeed.SpeedRate.ToString() , false);
                objLVI.Tag = objSpeed.SpeedID;
                //objLVI.Text = objSpeed.SpeedName;
                objLVI.SubItems.Add(objSpeed.SpeedName);
                objLVI.SubItems.Add(objSpeed.SpeedRate.ToString() );
                lvCharSpeeds.Items.Add(objLVI);
            }
            //Common.FormatListViewControlColumns(lvOrganizations);

        }

        private void LoadDefenseScores()
        {
            //Set the Reflex items first.
            CharacterDefense objRefDef = new CharacterDefense();
            CharacterDefense objFortDef = new CharacterDefense();
            CharacterDefense objWillDef = new CharacterDefense();

            foreach (CharacterDefense objDef in objCurrentChar.lstDefenses)
            {
                switch (objDef.DefenseType.DefenseTypeDescription.ToString().ToLower())
                {
                    case "reflex":
                        objRefDef = objDef;
                        break;
                    case "fortitude":
                        objFortDef = objDef;
                        break;
                    case "will":
                        objWillDef = objDef;
                        break;
                }
            }

            //Set this reflex defense:
            txtReflexLevelArmor.Text = objRefDef.CharacterLevelArmor.ToString();
            txtReflexAbility.Text = objRefDef.AbilityMod.ToString();
            txtReflexClass.Text = objRefDef.ClassMod.ToString();
            txtReflexRace.Text = objRefDef.RaceMod.ToString();
            txtReflexFeat.Text = objRefDef.FeatTalentMod.ToString();
            txtReflexMisc.Text = objRefDef.MiscellaneousMod.ToString();

            //Fort Def
            txtFortLevelArmor.Text = objFortDef.CharacterLevelArmor.ToString();
            txtFortAbility.Text = objFortDef.AbilityMod.ToString();
            txtFortClass.Text = objFortDef.ClassMod.ToString();
            txtFortRace.Text = objFortDef.RaceMod.ToString();
            txtFortFeat.Text = objFortDef.FeatTalentMod.ToString();
            txtFortMisc.Text = objFortDef.MiscellaneousMod.ToString();

            //WIll Def
            txtWillLevelArmor.Text = objWillDef.CharacterLevelArmor.ToString();
            txtWillAbility.Text = objWillDef.AbilityMod.ToString();
            txtWillClass.Text = objWillDef.ClassMod.ToString();
            txtWillRace.Text = objWillDef.RaceMod.ToString();
            txtWillFeat.Text = objWillDef.FeatTalentMod.ToString();
            txtWillMisc.Text = objWillDef.MiscellaneousMod.ToString();
        }

        public void LoadCurrentCharacter()
        {
            lstOriginalCharacterScores = SetOriginalScores();
            lstCharacterScore = SetOriginalScores();
            ResetMainForm();
            SetFormWithCurrentCharacter();
            CheckStatusForAddCharacterLevelButton();
            
        }

        public void CheckStatusForRaceCombo()
        {
            if (objCurrentChar.CharacterLevelID == 0) this.cmbRace.Enabled = true; else this.cmbRace.Enabled = false;
        }

        public void SetPhysicalDescriptionGroup()
        {
            if (objCurrentChar.objRace.RaceID != 0)
            {
                grpPhsyicalInfo.Visible = true;
                if (objCurrentChar.Height + "" != "") this.txtHeight.Text = objCurrentChar.Height.ToString();
                if (objCurrentChar.Weight + "" != "") this.txtWeight.Text = objCurrentChar.Weight.ToString();
                this.txtAverageHeight.Text = objCurrentChar.objRace.AverageHeight.ToString();
                this.txtAverageWeight.Text = objCurrentChar.objRace.AverageWeight.ToString();
                if (objCurrentChar.objRace.Sex.ToUpper() != "B") this.txtSex.Text = objCurrentChar.objRace.Sex;
                if (objCurrentChar.CharacterAge != null) this.txtAge.Text = objCurrentChar.CharacterAge.ToString();
            }
            else
            {
                grpPhsyicalInfo.Visible = false;
                this.txtHeight.Text = "";
                this.txtWeight.Text = "";
                this.txtAverageHeight.Text = "";
                this.txtAverageWeight.Text = "";
                this.txtSex.Text = "";
                this.txtAge.Text = "";
            }
        }

        #endregion

        //private void SaveCharacterWeapon(Character_Weapon_Control cwc)
        //{
        //    cwc.objCharWeapon.Notes = cwc.CharacterWeaponNotes;
        //    cwc.objCharWeapon.SaveCharacterWeapon();
        //}        
        
        private void SaveCharacterArmor(Character_Armor_Control cac, bool blnWorn)
        {
            cac.objCharArmor.Notes = cac.CharacterArmorNotes;
            cac.objCharArmor.Worn = blnWorn;
            cac.objCharArmor.SaveCharacterArmor();
        }

        //private void btnSaveWeapon1_Click(object sender, EventArgs e)
        //{
        //    SaveCharacterWeapon(cwc1);
        //}
        
        //private void btnSaveWeapon2_Click(object sender, EventArgs e)
        //{
        //    SaveCharacterWeapon(cwc2);
        //}

        //private void btnSaveWeapon3_Click(object sender, EventArgs e)
        //{
        //    SaveCharacterWeapon(cwc3);
        //}

        //private void btnSaveWeapon4_Click(object sender, EventArgs e)
        //{
        //    SaveCharacterWeapon(cwc4);
        //}

        private void btnSaveArmor1_Click(object sender, EventArgs e)
        {
            SaveCharacterArmor(cac1, this.ckbArmorWorn1.Checked);
        }

        private void btnSaveArmor2_Click(object sender, EventArgs e)
        {
            SaveCharacterArmor(cac2, this.ckbArmorWorn2.Checked);
        }


        

        






   




    }
}
