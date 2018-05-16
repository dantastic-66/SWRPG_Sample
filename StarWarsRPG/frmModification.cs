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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class frmModification : Form
    {
        /// <summary>
        /// The StringBuilder item modified name
        /// </summary>
        private StringBuilder sbItemModifiedName = new StringBuilder ();
        /// <summary>
        /// The int item modified modification points
        /// </summary>
        private int intItemModifiedModificationPoints = 0;
        ///// <summary>
        ///// The object mod type
        ///// </summary>
        //private Common.ModificationType objModType;
        /// <summary>
        /// The int used mod points
        /// </summary>
        private int intUsedModPoints = 0;

        /// <summary>
        /// The color fore color
        /// </summary>
        private Color clrForeColor;
        /// <summary>
        /// The color back color
        /// </summary>
        private Color clrBackColor;


        Common.ModificationType enumModType;
        int intModedObjID = 0;

        Character objCurrentCharacter;
        bool _useCredits = false;
        bool _buyBack = false;
        int _buyBackPercentage = 0;

        /// <summary>
        /// The LST modifications available
        /// </summary>
        List<Modification> lstModificationsAvailable = new List<Modification>();
        /// <summary>
        /// The list<modfication> selected by the user
        /// </summary>
        List<Modification> lstModficationsSelected = new List<Modification>();
        /// <summary>
        /// The list<modfication> that the device has already when they come into the form (for use with Credits)
        /// </summary>
        List<Modification> lstOriginalModfications= new List<Modification>();

        /// <summary>
        /// Initializes a new instance of the <see cref="frmModification"/> class.
        /// </summary>
        public frmModification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmModification"/> class.
        /// </summary>
        /// <param name="objW">The object w.</param>
        /// <param name="CharWeaponID">The character weapon identifier.</param>
        public frmModification(Weapon objW, int CharWeaponID, Character objCharacter, bool UseCredits, bool BuyBack, int BuyBackPercentage)
        {
            InitializeComponent();
            Armor objA = new Armor();
            Equipment objE = new Equipment();
            objCurrentCharacter = objCharacter;
            _useCredits = UseCredits;
            _buyBack = BuyBack;
            _buyBackPercentage = BuyBackPercentage;
            SetupObjects(objW, objA, objE, CharWeaponID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmModification"/> class.
        /// </summary>
        /// <param name="objA">The object a.</param>
        /// <param name="CharArmorID">The character armor identifier.</param>
        public frmModification(Armor objA, int CharArmorID, Character objCharacter, bool UseCredits, bool BuyBack, int BuyBackPercentage)
        {
            InitializeComponent();
            Weapon objW = new Weapon();
            Equipment objE = new Equipment();
            objCurrentCharacter = objCharacter;
            _useCredits = UseCredits;
            _buyBack = BuyBack; 
            _buyBackPercentage = BuyBackPercentage; 
            SetupObjects(objW, objA, objE, CharArmorID);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmModification"/> class.
        /// </summary>
        /// <param name="objE">The object e.</param>
        /// <param name="CharEquipID">The character equip identifier.</param>
        public frmModification(Equipment objE, int CharEquipID, Character objCharacter, bool UseCredits, bool BuyBack, int BuyBackPercentage)
        {
            InitializeComponent();
            Armor objA = new Armor();
            Weapon objW = new Weapon();
            objCurrentCharacter = objCharacter;
            _useCredits = UseCredits;
            _buyBack = BuyBack; 
            _buyBackPercentage = BuyBackPercentage; 
            SetupObjects(objW, objA, objE, CharEquipID);

        }

        #region Methods
        /// <summary>
        /// Setups the objects.
        /// </summary>
        /// <param name="objWeapon">The object weapon.</param>
        /// <param name="objArmor">The object armor.</param>
        /// <param name="objEquipment">The object equipment.</param>
        /// <param name="CharItemID">The character item identifier.</param>
        private void SetupObjects(Weapon objWeapon, Armor objArmor, Equipment objEquipment, int CharItemID)
        {
            Modification objMod = new Modification();
            StringBuilder sbSelect = new StringBuilder();
            if (objWeapon.WeaponID != 0) 
            {
                sbItemModifiedName.Append (objWeapon.WeaponName);
                intItemModifiedModificationPoints = objWeapon.EmplacementPoints;
                sbSelect.Append (" ModificationTypeID = 2");
                lstModficationsSelected = objMod.GetCharacterWeaponModifications(CharItemID);
                lstOriginalModfications = objMod.GetCharacterWeaponModifications(CharItemID);
                enumModType =Common.ModificationType.Weapon;
            }
            else if (objArmor.ArmorID != 0)
            {
                sbItemModifiedName.Append (objArmor.ArmorName);
                intItemModifiedModificationPoints = objArmor.EmplacementPoints;
                sbSelect.Append(" ModificationTypeID = 1");
                lstModficationsSelected = objMod.GetCharacterArmorModifications(CharItemID);
                lstOriginalModfications = objMod.GetCharacterArmorModifications(CharItemID);
                enumModType = Common.ModificationType.Armor;
            }
            else if (objEquipment.EquipmentID != 0)
            {
                sbItemModifiedName.Append(objEquipment.EquipmentName);
                intItemModifiedModificationPoints = objEquipment.EmplacementPoints;
                sbSelect.Append(" ModificationTypeID = 3");
                lstModficationsSelected = objMod.GetCharacterEquipmentModifications(CharItemID);
                lstOriginalModfications = objMod.GetCharacterEquipmentModifications(CharItemID);
                enumModType = Common.ModificationType.Equipment;
               
            }
            intModedObjID = CharItemID;
            lstModificationsAvailable = objMod.GetModificationsByType(sbSelect.ToString(), " ModificationName");
            this.txtItemModified.Text = sbItemModifiedName.ToString();
            this.txtUpgradePointsAvailable.Text = intItemModifiedModificationPoints.ToString();

            //Original Back Colors 
            clrBackColor = this.txtUsedUpgradePoints.BackColor;
            clrForeColor = this.txtUsedUpgradePoints.ForeColor;           
            
            LoadModifications();

            //Set the buttons
            bool blnAllButton;
            if (this.tvSelectedModifications.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetModSelectButtons(false, false, blnAllButton, "");


        }

        /// <summary>
        /// Loads the modifications.
        /// </summary>
        private void LoadModifications()
        {
            tvModificationList.Nodes.Clear();
            tvSelectedModifications.Nodes.Clear();

            foreach (Modification objMod in lstModificationsAvailable)
            {
                if (!Modification.IsModificationInList(objMod, lstModficationsSelected))
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objMod.ModificationName;
                    objTN.Tag = objMod.ModificationID;
                    this.tvModificationList.Nodes.Add(objTN);
                }
            }
            intUsedModPoints = 0;
            foreach (Modification objSelMod in lstModficationsSelected )
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objSelMod.ModificationName;
                objTN.Tag = objSelMod.ModificationID;
                this.tvSelectedModifications.Nodes.Add(objTN);
                intUsedModPoints = intUsedModPoints + objSelMod.UpgradePoints;
            }
            this.txtUsedUpgradePoints.Text  = intUsedModPoints.ToString();
            CheckAvailableModPoints();
        }


        private int GetCurrentModPoints()
        {
            int ModUpdgradeVal = 0;
            int intModID = 0;
            string strModID = "";

            foreach (TreeNode objTN in this.tvSelectedModifications.Nodes)
            {
                strModID = objTN.Tag.ToString();
                int.TryParse(strModID, out intModID);

                Modification objMod = new Modification(intModID);
                ModUpdgradeVal += objMod.UpgradePoints;
            }
            return ModUpdgradeVal;
        }

        /// <summary>
        /// Upgrades the points maxed.
        /// </summary>
        /// <returns></returns>
        private bool UpgradePointsMaxed()
        {
            bool retVal = false;
            int ModUpdgradeVal = 0;
            int intModID =0;
            string strModID = "";

            foreach (TreeNode objTN in this.tvSelectedModifications.Nodes)
            {
                strModID = objTN.Tag.ToString();
                int.TryParse(strModID, out intModID);

                Modification objMod = new Modification(intModID);
                ModUpdgradeVal += objMod.UpgradePoints;
            }

            if (ModUpdgradeVal == intItemModifiedModificationPoints) retVal = true;
            return retVal;
        }

        /// <summary>
        /// Sets the modification fields.
        /// </summary>
        /// <param name="strTag">The string tag.</param>
        public void SetModificationFields(string strTag)
        {
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Modification objModification = new Modification();
                objModification.GetModification (intTag);

                this.txtModificationName.Text = objModification.ModificationName ;
                this.txtUpgradePoints.Text = objModification.UpgradePoints.ToString();
                this.txtCost.Text = objModification.ModificationCost.ToString() ;
                this.txtUpgradeDescription.Text = objModification.ModificationDescription;
            }
            else
            {
                this.txtModificationName.Text =  "";
                this.txtModificationType.Text =  "";
                this.txtUpgradePoints.Text =  "";
                this.txtCost.Text =  "";
                this.txtUpgradeDescription.Text = "";
            }
        }

        /// <summary>
        /// Sets enable property of the Modification select buttons between the two Tree Views (List of Force Powers and Force Powers Selected).
        /// </summary>
        /// <param name="AddButton">if set to <c>true</c> [btnAddMod] enabled, <c>false</c> it is disabled.</param>
        /// <param name="RemoveButton">if set to <c>true</c> [btnRemoveMod], <c>false</c> it is disabled.</param>
        /// <param name="RemoveAllButton">if set to <c>true</c> [btnRemoveAllMod], <c>false</c> it is disabled.</param>
        public void SetModSelectButtons(bool AddButton, bool RemoveButton, bool RemoveAllButton, string SelectedNodeTag)
        {
            if (UpgradePointsMaxed())
            {
                this.btnAddMod.Enabled = false;
                this.btnRemoveMod.Enabled = RemoveButton;
                this.btnRemoveAllMods.Enabled = true;

                if (SelectedNodeTag !="")
                {
                    int ModID = 0;
                    int.TryParse(SelectedNodeTag, out ModID);
                    Modification objMod = new Modification(ModID);
                    //Check the add button if the mod point cost is zero and can fit under the max
                    if (GetCurrentModPoints() + objMod.UpgradePoints <= intItemModifiedModificationPoints) this.btnAddMod.Enabled = true;
                }
            }
            else
            {
                this.btnAddMod.Enabled = AddButton;
                this.btnRemoveMod.Enabled = RemoveButton;
                this.btnRemoveAllMods.Enabled = RemoveAllButton;
            }
        }

        /// <summary>
        /// Calculates the used upgrade points.
        /// </summary>
        /// <returns></returns>
        private int CalculateUsedUpgradePoints()
        {
            int ModUpdgradeVal = 0;
            int intModID = 0;
            string strModID = "";

            foreach (TreeNode objTN in this.tvSelectedModifications.Nodes)
            {
                strModID = objTN.Tag.ToString();
                int.TryParse(strModID, out intModID);

                Modification objMod = new Modification(intModID);
                ModUpdgradeVal += objMod.UpgradePoints;
            }
            return ModUpdgradeVal;
        }

        /// <summary>
        /// Checks the available mod points.
        /// </summary>
        private void CheckAvailableModPoints()
        {
            if (intUsedModPoints == intItemModifiedModificationPoints)
            {
                this.txtUsedUpgradePoints.BackColor = Color.Maroon;
                this.txtUsedUpgradePoints.ForeColor = Color.White;
            }
            else
            {
                this.txtUsedUpgradePoints.BackColor = clrBackColor;
                this.txtUsedUpgradePoints.ForeColor = clrForeColor;
            }
        }       

        private void CreditRemovedMods()
        {
            //Credit Added Mods
            foreach (Modification objOrigMod in lstOriginalModfications)
            {
                if (!Modification.IsModificationInList(objOrigMod,lstModficationsSelected )) objCurrentCharacter.CreditCreditsForCharacter(_buyBackPercentage, objOrigMod.ModificationCost);
            }
        }

        private bool DebitAddedMods()
        {
            bool DeductionsWorked = true;
            //Deduct Added Mods
            foreach (Modification objAddedMod in lstModficationsSelected )
            {
                if (!Modification.IsModificationInList(objAddedMod, lstOriginalModfications))
                    if (!objCurrentCharacter.DeductCreditsFromCharacter(objCurrentCharacter.Credits, objAddedMod.ModificationCost)) DeductionsWorked = false;

            }
            return DeductionsWorked;
        }

        private void RemoveModsFromDevice()
        {
            CharacterEquipment objCharEquip = new CharacterEquipment();
            CharacterArmor objCharArmor = new CharacterArmor();
            CharacterWeapon objCharWeapon = new CharacterWeapon(); ;

            switch (enumModType)
            {
                case Common.ModificationType.Armor:
                    objCharArmor.GetCharacterArmor(intModedObjID);
                    break;
                case Common.ModificationType.Equipment:
                    objCharEquip.GetCharacterEquipment(intModedObjID);
                    break;
                case Common.ModificationType.Weapon:
                    objCharWeapon.GetCharacterWeapon(intModedObjID);
                    break;
            }

            //Delete the mod if its not in the selected list
            foreach (Modification objOrigMod in lstOriginalModfications)
            {
                if (!Modification.IsModificationInList(objOrigMod, lstModficationsSelected))
                {
                    switch (enumModType)
                    {
                        case Common.ModificationType.Armor:
                            objCharArmor.DeleteCharacterArmorModification(intModedObjID, objOrigMod.ModificationID );
                            break;
                        case Common.ModificationType.Equipment:
                            objCharEquip.DeleteCharacterEquipmentModification(intModedObjID, objOrigMod.ModificationID );
                            break;
                        case Common.ModificationType.Weapon:
                            objCharWeapon.DeleteCharacterWeaponModification(intModedObjID, objOrigMod.ModificationID );
                            break;
                    }
                }
            }

            //Add the mod if its not in the Original List
            foreach (Modification objSelMod in lstModficationsSelected)
            {
                if (!Modification.IsModificationInList(objSelMod, lstOriginalModfications ))
                {
                    switch (enumModType)
                    {
                        case Common.ModificationType.Armor:
                            objSelMod.SaveCharacterArmorModification(objCharArmor.CharacterArmorID, objSelMod.ModificationID);
                            break;
                        case Common.ModificationType.Equipment:
                            objSelMod.SaveCharacterEquipmentModification(objCharEquip.CharacterEquipmentID , objSelMod.ModificationID);
                            break;
                        case Common.ModificationType.Weapon:
                            objSelMod.SaveCharacterWeaponModification (objCharWeapon.CharacterWeaponID , objSelMod.ModificationID);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Form Events
        /// <summary>
        /// Handles the Click event of the btnAddMod control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnAddMod_Click(object sender, EventArgs e)
        {
            string strTag = tvModificationList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Modification objModification = new Modification();
                objModification.GetModification(intTag);


                if (objModification.UpgradePoints + intUsedModPoints <= intItemModifiedModificationPoints)
                {
                    lstModficationsSelected.Add(objModification);
                    LoadModifications();

                    bool blnAllButton;
                    if (this.tvSelectedModifications.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
                    SetModSelectButtons(false, false, blnAllButton, "");
                    SetModificationFields("");
                }
                else MessageBox.Show("Modification Cannot be added, not enought emplacment points on device.", "Unable to Modify Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveMod control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRemoveMod_Click(object sender, EventArgs e)
        {
            TreeNode objTN = tvSelectedModifications.SelectedNode;
            Modification objModification = new Modification((int)objTN.Tag);
            lstModficationsSelected = Modification.RemoveListObject(lstModficationsSelected, objModification);
            intUsedModPoints = intUsedModPoints - objModification.UpgradePoints;
            LoadModifications();

            this.btnRemoveMod.Enabled = false;
            bool blnAllButton;
            if (this.tvSelectedModifications.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetModSelectButtons(false, false, blnAllButton, "");
            SetModificationFields("");
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAllMod control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRemoveAllMod_Click(object sender, EventArgs e)
        {
            foreach (TreeNode objTN in tvSelectedModifications.Nodes)
            {
                Modification objModification = new Modification((int)objTN.Tag);
                lstModficationsSelected = Modification.RemoveListObject(lstModficationsSelected, objModification);
            }
            LoadModifications();
            
            intUsedModPoints = 0;
            btnRemoveAllMods.Enabled = false;
            btnRemoveMod.Enabled = false;

            bool blnAllButton;
            if (this.tvSelectedModifications.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetModSelectButtons(false, false, blnAllButton, "");
            SetModificationFields("");
        }

        /// <summary>
        /// Handles the Click event of the btnSubmitMods control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSubmitMods_Click(object sender, EventArgs e)
        {
            int intOriginalCredits = objCurrentCharacter.Credits;
            if (_useCredits)
            {
                //Take care of any mods removed first
                if (_buyBack) CreditRemovedMods();
                if (!DebitAddedMods())
                {
                    objCurrentCharacter.Credits = intOriginalCredits;
                    MessageBox.Show("Insufficient Credits to purchase Modifications.  Please reselect modifications.", "Insufficient Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //Take Care of removeing Mods here and Adding new ones back onto the 
            RemoveModsFromDevice();
            frmMain.lstModficationsSelected = lstModficationsSelected;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the AfterSelect event of the tvSelectedModifications control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvSelectedModifications_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetModificationFields(tvSelectedModifications.SelectedNode.Tag.ToString());
            SetModSelectButtons(false, true, true, "");
        }

        /// <summary>
        /// Handles the AfterSelect event of the tvModificationList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvModificationList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool blnAllButton;
            SetModificationFields(tvModificationList.SelectedNode.Tag.ToString());
            
            if (this.tvSelectedModifications.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetModSelectButtons(true, false, blnAllButton, tvModificationList.SelectedNode.Tag.ToString());
        }

        #endregion


    }
}
