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


namespace StarWarsRPG
{
    public partial class frmWeaponSelection : Form
    {
        public static Character objCharacter;
        private int intWeaponSelectedID = 0;

        public frmWeaponSelection()
        {
            InitializeComponent();
            LoadTreeView();
            CheckCharacterWeaponProficiencyCheckBoxStatus();
        }

        #region Methods
        private void LoadTreeView()
        {
            tvWeaponList.Nodes.Clear();

            List<WeaponType> lstWeaponType = new List<WeaponType>();
            WeaponType objWeaponType = new WeaponType();

            List<Weapon> lstWeapons = new List<Weapon>();
            Weapon objWeapon = new Weapon();

            if (!ckbHideNonProficientWeapons.Enabled) lstWeaponType = objWeaponType.GetWeaponTypes ("", "WeaponTypeName");
            else if (ckbHideNonProficientWeapons.Checked )
            {
                //Hide Non Proficent Weapons
                lstWeaponType = objWeaponType.GetCharacterProficientWeaponTypes(objCharacter.CharacterID);
            }
            else
            {
                //Show All Weapons
                lstWeaponType = objWeaponType.GetWeaponTypes("", "WeaponTypeName");
            }

            foreach (WeaponType objListWeaponType in lstWeaponType )
            {
                lstWeapons = objWeapon.GetWeaponsByWeaponTypeID(objListWeaponType.WeaponTypeID);
                TreeNode objWTTN = new TreeNode();
                objWTTN.Text = objListWeaponType.WeaponTypeName;
                objWTTN.Tag = objListWeaponType.WeaponTypeID;
               
                foreach (Weapon objListWeapon in lstWeapons)
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objListWeapon.WeaponName;
                    objTN.Tag = objListWeapon.WeaponID;
                    objWTTN.Nodes.Add(objTN);
                }

                tvWeaponList.Nodes.Add(objWTTN);
            }
        }

        private void CheckCharacterWeaponProficiencyCheckBoxStatus()
        {
            if (objCharacter.CharacterID == 0) this.ckbHideNonProficientWeapons.Enabled = false; else this.ckbHideNonProficientWeapons.Enabled = true;
        }

        private void SetWeaponFields(Weapon objWeapon)
        {
            intWeaponSelectedID = objWeapon.WeaponID;
            this.txtWeaponCost.Text = objWeapon.Cost.ToString();
            this.txtBookName.Text = objWeapon.objBook.BookName;
            this.txtRateOfFire.Text = objWeapon.RateOfFire;
            this.txtWeaponDamage.Text = objWeapon.DamageDieNumber.ToString() + "d" + objWeapon.DamageDieType.ToString();
            if (objWeapon.ExtraDamage > 0) txtWeaponDamage.Text = txtWeaponDamage.Text + "+" + objWeapon.ExtraDamage.ToString(); 
            this.txtWeaponName.Text = objWeapon.WeaponName;
            this.ckbStunDamage.Checked = objWeapon.Stun;
            this.txtWeaponNotes.Text = objWeapon.WeaponDescription;
            this.txtWeaponProficiencyFeat.Text = objWeapon.objWeaponProficiencyFeat.FeatName;
            this.txtWeaponSize.Text = objWeapon.objWeaponSize.WeaponSizeName;
            this.txtWeaponStunDamage.Text = objWeapon.StunDieNumber.ToString() + "d" + objWeapon.StunDieType.ToString();
            if (objWeapon.ExtraStunDamage > 0) txtWeaponStunDamage.Text = txtWeaponStunDamage.Text + "+" + objWeapon.ExtraStunDamage.ToString(); 
            this.txtWeaponType.Text = objWeapon.objWeaponType.WeaponTypeName;

            this.ckbAccurate.Checked = objWeapon.Accurate;
            this.ckbAreaOfAttack.Checked = objWeapon.AreaOfAttack;
            this.ckbDoubleWeapon.Checked = objWeapon.DoubleWeapon;
            this.ckbInaccurate.Checked = objWeapon.Inaccurate;
            this.ckbRequiresOrdiance.Checked = objWeapon.RequiresSeperateAmmo;
            this.ckbSlugThrower.Checked = objWeapon.Slugthrower;


            //Set Ranges
            lvRanges.Items.Clear();
            if (objWeapon.objRanges.Count > 1)
            {
                foreach (Range objRange1 in objWeapon.objRanges)
                {
                    if (objWeapon.Inaccurate)
                    {
                        if (!objRange1.RangeName.ToString().ToLower().Contains("long"))
                        {
                            lvRanges.Items.Add(SetRangeListViewItem(objRange1, objWeapon));
                        }
                    }
                    else lvRanges.Items.Add(SetRangeListViewItem(objRange1, objWeapon));
                }
            }
            else
            {
                foreach (Range objRange in objWeapon.objRanges)
                {
                    lvRanges.Items.Add(SetRangeListViewItem(objRange, objWeapon ));
                }
            }


            for (int i = 0; i < lvRanges.Columns.Count; i++)
            {
                lvRanges.Columns[i].Width = -2;
            }

            //Set Character Specific Data
            if (objCharacter.CharacterID == 0) ShowCharacterCheckData(false);
            else
            {
                txtMeleeAttackBonus.Text = objCharacter.CalculateMeleeToHit(objWeapon, Common.GetAppSettingsID("Weapon_Finese_SimpleWeapons"), Common.GetAppSettingsID("Weapon_Finese_Lightsabers")).ToString();
                txtMeleeDamageBonus.Text = objCharacter.CalculateMeleeBonusDamage().ToString();
                if (objWeapon.ExtraDamage > 0) txtMeleeDamageBonus.Text = txtMeleeDamageBonus.Text + "+" + objWeapon.ExtraDamage.ToString(); 
                txtRangeAttackBonus.Text = objCharacter.CalculateRangeToHit(objWeapon).ToString();
                txtRangeDamageBonus.Text = objCharacter.CalculateRangeBonusDamage().ToString();
                SetAttackAndDamageBonusesVisibility(objWeapon);
                ShowCharacterCheckData(true);
            }

            this.btnSelectWeapon.Enabled = true;
        }

        private void BlankMeleeFields()
        {
            txtMeleeAttackBonus.Text = "";
            txtMeleeDamageBonus.Text = "";
        }

        private void BlankRangeFields()
        {
            txtRangeAttackBonus.Text = "";
            txtRangeDamageBonus.Text = "";
        }

        private void SetAttackAndDamageBonusesVisibility(Weapon objWeapon)
        {
            //If the Range has Melee Data in it display Melee Data
            if (!Range.RangeTypeInRangeList("Melee", objWeapon.objRanges)) BlankMeleeFields();
            //if the Range has Ranged Data in it display the Range Data
            if (!Range.RangeTypeInRangeList("Short", objWeapon.objRanges)) BlankRangeFields();
        }

        private void ShowCharacterCheckData(bool blnVisible)
        {
            grpCharacterStats.Visible = blnVisible;
        }

        private ListViewItem SetRangeListViewItem(Range objRange1, Weapon objWeapon)
        {
            ListViewItem objLVI = new ListViewItem(objRange1.RangeName);
            objLVI.Tag = (int)objRange1.RangeID;
            objLVI.SubItems.Add(objRange1.BeginSquare.ToString());
            objLVI.SubItems.Add(objRange1.EndSquare.ToString());
            if (objWeapon.Accurate)
            {
                if (objRange1.RangeName.ToString().ToLower().Contains("short")) objLVI.SubItems.Add("0");
                else objLVI.SubItems.Add(objRange1.objModifier.ModifierNumber.ToString());
            }
            else if (objRange1.objModifier.ModifierPositive) objLVI.SubItems.Add(objRange1.objModifier.ModifierNumber.ToString()); else objLVI.SubItems.Add("-" + objRange1.objModifier.ModifierNumber.ToString());

            return objLVI;
        }
        #endregion

        #region Form Methods
        private void tvWeaponList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvWeaponList.SelectedNode.Nodes.Count > 0) return;

            string strTag = tvWeaponList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Weapon objWeapon = new Weapon(intTag);
                SetWeaponFields(objWeapon);               


            }
        }

        private void ckbHideNonProficientWeapons_CheckedChanged(object sender, EventArgs e)
        {
            LoadTreeView();
        }

        private void btnSelectWeapon_Click(object sender, EventArgs e)
        {
            frmMain.intNewCharacterWeaponWeaponID = intWeaponSelectedID;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion



    }
}
