using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarWarsClasses;

namespace SWRPG_Custom_Windows_Controls
{
    public partial class Character_Weapon_Control : UserControl
    {
        int _intCharacterID;
        int _intWeaponID;
        int _OriginalCharWeaponID = 0;

        CharacterWeapon _cwObjCW;

        #region Properties
        public CharacterWeapon objCharWeapon
        {
            get { return _cwObjCW; }
        }

        public int CharacterID
        {
            get { return _intCharacterID; }
            //set { _intCharacterID = value;}
        }

        public int WeaponID
        {
            get { return _intWeaponID; }
            //set { _intWeaponID = value; }
        }

        public int AttackBonus
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtMeleeAttackBonus.Text, out intRetVal);
                return intRetVal;
            }
            //set { txtAttackBonus.Text = value.ToString(); }
        }

        public int DamageBonus
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtMeleeDamageBonus.Text, out intRetVal);
                return intRetVal;
            }
        }

        public string WeaponName
        {
            get { return txtWeaponName.Text ; }
            //set { txtWeaponName.Text = value; }
        }

        public string CharacterWeaponNotes
        {
            get { return txtCharacterWeaponNotes.Text; }
            //set { txtCharacterWeaponNotes.Text = value; }
        }

        public string Damage
        {
            get { return txtDamage.Text; }
            //set { txtDamage.Text = value; }
        }

        public string StunDamage
        {
            get { return txtStunDamage.Text; }
            //set { txtStunDamage.Text = value; }
        }

        public decimal Weight
        {
            get
            {
                decimal intRetVal = 0;
                decimal.TryParse(txtWeight.Text, out intRetVal);
                return intRetVal;
            }
            //set { txtWeight.Text = value.ToString(); }
        }

        public string BookName
        {
            get { return txtBook.Text; }
            //set { txtBook.Text = value; }
        }

        public int ControlNumber { get; set; }
        #endregion

        #region Events
        public event EventHandler EditModifications_Click;
        //public event EventHandler RemoveEmplacementPoint_Click;
        #endregion

        public Character_Weapon_Control()
        {
            InitializeComponent();
        }

        #region Public Methods
        public void SetControlWithCharacterWeapon(Character objChar, CharacterWeapon objCW)
        {
            _intCharacterID = objCW.CharacterID;
            _intWeaponID = objCW.WeaponID;
            _cwObjCW = objCW;
            string strWeaponAvail = "";
            string DamageBonus = "";
            string StunBonus = "";
            if ((_OriginalCharWeaponID==0) && (objCW.CharacterWeaponID != 0)) _OriginalCharWeaponID = objCW.CharacterWeaponID ;
            
            //Move to Character the Attack and Damage Bonuses
            txtMeleeAttackBonus.Text = objCW.MeleeAttackBonus.ToString();
            txtMeleeDamageBonus.Text = objCW.MeleeDamageBonus.ToString();
            txtRangeAttackBonus.Text = objCW.RangeAttackBonus.ToString();
            txtRangeDamageBonus.Text = objCW.RangeDamageBonus.ToString();

            txtWeaponName.Text = objCW.objWeapon.WeaponName;
            txtCharacterWeaponNotes.Text = objCW.Notes;
            if (objCW.objWeapon.ExtraDamage != 0) DamageBonus = "+" + objCW.objWeapon.ExtraDamage; else DamageBonus = "";
            if (objCW.objWeapon.ExtraStunDamage != 0) StunBonus = "+" + objCW.objWeapon.ExtraStunDamage; else StunBonus = "";

            txtDamage.Text = objCW.objWeapon.DamageDieNumber.ToString() + "d" + objCW.objWeapon.DamageDieType.ToString() + DamageBonus;
            if (objCW.objWeapon.Stun) txtStunDamage.Text = objCW.objWeapon.StunDieNumber.ToString() + "d" + objCW.objWeapon.StunDieType.ToString() + StunBonus; else txtStunDamage.Text = "";

            txtWeight.Text = objCW.objWeapon.Weight.ToString();
            txtBook.Text = objCW.objWeapon.objBook.BookName ;
            txtWeaponType.Text = objCW.objWeapon.objWeaponType.WeaponTypeDescription;
            txtWeaponSize.Text = objCW.objWeapon.objWeaponSize.WeaponSizeName;
            txtRateOfFire.Text = objCW.objWeapon.RateOfFire;

            if ( objCW.objWeapon.lstWeaponAvailability.Count > 0)
            {
                foreach (ItemAvailabilityType objIAT in  objCW.objWeapon.lstWeaponAvailability)
                {
                    strWeaponAvail = strWeaponAvail + objIAT.ItemAvailabilityTypeName + ", ";
                }
                strWeaponAvail = strWeaponAvail.Substring(0, strWeaponAvail.Length - 2);
            }
            txtAvailability.Text = strWeaponAvail;

            this.ckbAccurate.Checked = objCW.objWeapon.Accurate;
            this.ckbAreaOfAttack.Checked = objCW.objWeapon.AreaOfAttack;
            this.ckbDoubleWeapon.Checked = objCW.objWeapon.DoubleWeapon;
            this.ckbInaccurate.Checked = objCW.objWeapon.Inaccurate;
            this.ckbRequiresOrdiance.Checked = objCW.objWeapon.RequiresSeperateAmmo;
            this.ckbSlugThrower.Checked = objCW.objWeapon.Slugthrower;

            SetRanges(objCW.objWeapon.objRanges);

            SetAttackAndDamageBonusesVisibility(objCW);

            LoadModificationListView();
        }
        
        public void ResetControl()
        {
            _intCharacterID = 0;
            _intWeaponID= 0;
            _OriginalCharWeaponID = 0;
            _cwObjCW = new CharacterWeapon();

        }
        
        public void AddModifications(List<Modification> lstMods)
        {
            _cwObjCW.lstWeaponModifications = lstMods;
            LoadModificationListView();
        }


        #endregion

        #region Private Methods
        private void LoadModificationListView()
        {
            this.tvModifications.Nodes.Clear();
            if (_cwObjCW.lstWeaponModifications.Count > 0)
            {
                foreach (Modification objMod in _cwObjCW.lstWeaponModifications)
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objMod.ModificationName;
                    objTN.Tag = objMod.ModificationID;
                    tvModifications.Nodes.Add(objTN);
                }
            }
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

        private void SetAttackAndDamageBonusesVisibility(CharacterWeapon objCW)
        {
            //If the Range has Melee Data in it display Melee Data
            if (!Range.RangeTypeInRangeList("Melee", objCW.objWeapon.objRanges)) BlankMeleeFields();
            //if the Range has Ranged Data in it display the Range Data
            if (!Range.RangeTypeInRangeList("Short", objCW.objWeapon.objRanges)) BlankRangeFields();
        }

        //private bool RangeTypeInRangeList(string strRangeType, List<Range> lstRanges)
        //{
        //    bool retVal = false;

        //    foreach (Range objRange in lstRanges)
        //    {
        //        if (objRange.RangeName.Contains(strRangeType)) retVal = true;
        //    }
        //    return retVal;
        //}

        private  void SetRanges(List<Range> lstRanges)
        {
            lvRanges.Items.Clear();
            if (lstRanges.Count > 1)
            {
                foreach (Range objRange1 in lstRanges)
                {
                    if (objCharWeapon.objWeapon.Inaccurate)
                    {
                        if (!objRange1.RangeName.ToString().ToLower().Contains("long"))
                        {
                            lvRanges.Items.Add(SetRangeListViewItem(objRange1));
                        }
                    }
                    else lvRanges.Items.Add(SetRangeListViewItem(objRange1));

                    //ListViewItem objLVI = new ListViewItem(objRange1.RangeName);
                    //objLVI.Tag = (int)objRange1.RangeID;
                    //objLVI.SubItems.Add(objRange1.BeginSquare.ToString());
                    //objLVI.SubItems.Add(objRange1.EndSquare.ToString());
                    //if (objCharWeapon.objWeapon.Accurate)
                    //{
                    //    if (objRange1.RangeName.ToString().ToLower().Contains("short")) objLVI.SubItems.Add("0"); 
                    //    else objLVI.SubItems.Add(objRange1.objModifier.ModifierNumber.ToString());
                    //}
                    //else if (objRange1.objModifier.ModifierPositive) objLVI.SubItems.Add(objRange1.objModifier.ModifierNumber.ToString()); else objLVI.SubItems.Add("-" + objRange1.objModifier.ModifierNumber.ToString());
                    //lvRanges.Items.Add(objLVI);
                }

                this.lvRanges.Visible = true;
                this.txtRange.Visible = false;

                for (int i = 0; i < lvRanges.Columns.Count; i++)
                {
                    lvRanges.Columns[i].Width = -2;
                }
            }
            else
            {
                this.lvRanges.Visible = false;
                this.txtRange.Visible = true;

                foreach (Range objRange in lstRanges)
                {
                    txtRange.Text = objRange.RangeName;
                }
            }
        }

        private ListViewItem SetRangeListViewItem(Range objRange1)
        {
            ListViewItem objLVI = new ListViewItem(objRange1.RangeName);
            objLVI.Tag = (int)objRange1.RangeID;
            objLVI.SubItems.Add(objRange1.BeginSquare.ToString());
            objLVI.SubItems.Add(objRange1.EndSquare.ToString());
            if (objCharWeapon.objWeapon.Accurate)
            {
                if (objRange1.RangeName.ToString().ToLower().Contains("short")) objLVI.SubItems.Add("0");
                else objLVI.SubItems.Add(objRange1.objModifier.ModifierNumber.ToString());
            }
            else if (objRange1.objModifier.ModifierPositive) objLVI.SubItems.Add(objRange1.objModifier.ModifierNumber.ToString()); else objLVI.SubItems.Add("-" + objRange1.objModifier.ModifierNumber.ToString());

            return objLVI;
        }
        #endregion

        #region Form Events
        private void btnEditModifications_Click(object sender, EventArgs e)
        {
            SetButtons();
            EditModifications_Click(sender, e);
        }

        private void SetButtons()
        {
            //if (tvModifications.Nodes.Count < _cwObjCW.objWeapon.EmplacementPoints) btnEditModifications.Enabled = true; else btnEditModifications.Enabled = false;
            //if (tvModifications.Nodes.Count > 0) btnEditModifications.Enabled = false;
        }

        private void tvModifications_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.txtModificationDescription.Text = "";
            TreeNode objTN = tvModifications.SelectedNode;
            Modification objModification = new Modification((int)objTN.Tag);
            this.txtModificationDescription.Text = objModification.ModificationDescription;

            //btnRemoveModification.Enabled = true;
        }       

        private void btnSave_Click(object sender, EventArgs e)
         {
             _cwObjCW.Notes = this.txtCharacterWeaponNotes.Text ;
             _cwObjCW.SaveCharacterWeapon();
         }
        #endregion







    }
}
