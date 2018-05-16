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
    public partial class Character_Equipment_Control : UserControl
    {
        int _intCharacterEquipmentID;
        int _OriginalCharEquipmentID;
        int _intCharacterID;
        int _intEquipmentID;

        //int _credits = 0;
        //bool _useCredits = false;
        //bool _equipmentBuyBack = false;
        //int _buyBackPercentage = 0;

        CharacterEquipment _cwObjCE;

        //public Character_Equipment_Control(int Credits, bool UseCredits, bool EquipmentBuyBack, int BuyBackPercentage)
        //{
        //    InitializeComponent();
        //    btnAddEquipmentModification.Click += new EventHandler(btnAddEquipmentEP_Click);
        //    _credits = Credits;
        //    _useCredits = UseCredits;
        //    _equipmentBuyBack = EquipmentBuyBack;
        //    _buyBackPercentage = BuyBackPercentage;
        //}

        public Character_Equipment_Control()
        {
            InitializeComponent();
            btnAddEquipmentModification.Click += new EventHandler(btnAddEquipmentEP_Click);
        }

        #region Properties
        public CharacterEquipment objCharEquip
        {
            get { return _cwObjCE; }
        }

        public int CharacterEquipmentID
        {
            get { return _intCharacterEquipmentID; }
        }

        public int CharacterID
        {
            get { return _intCharacterID; }
        }

        public int EquipmentID
        {
            get { return _intEquipmentID; }
        }

        public string EquipmentName
        {
            get { return txtEquipmentName.Text; }
        }

        public string EquipmentDescription
        {
            get { return txtEquipmentDescription.Text; }
        }

        public string CharacterEquipmentNotes
        {
            get { return txtCharacterEquipmentNotes.Text; }
        }

        public int EquipmentEmplacementPoints
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtEmplacementPoints.Text, out intRetVal);
                return intRetVal;
            }
        }

        public int Weight
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtEquipmentWeight.Text, out intRetVal);
                return intRetVal;
            }
        }

        public int EquipmentCost
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtEquipmentCost.Text, out intRetVal);
                return intRetVal;
            }
        }

        public int Quantity
        {
            get
            {
                int intRetVal = 1;
                if (!this.objCharEquip.objEquipment.Upgradable) int.TryParse(txtEmplacementPoints.Text, out intRetVal);
                return intRetVal;
            }
        }

        public string BookName
        {
            get { return txtBook.Text; }
        }
        #endregion

        #region Events

        public event EventHandler AddEquipmentEP_Click;
        //public event EventHandler Save_Click;

        //public event EventHandler RemoveEmplacementPoint_Click;
        #endregion

        #region Methods
        #region Public Methods
        public void AddModifications(List<Modification> lstMods)
        {
            _cwObjCE.lstModifications = lstMods;
            LoadModificationListView();
        }

        public void SetControlWithCharacterEquipment(Character objCharacter, CharacterEquipment objCE)
        {
            _intCharacterID = objCE.CharacterID;
            _intEquipmentID = objCE.EquipmentID;
            _cwObjCE = objCE;
            //string strEquipmentAvail = "";
            if ((_OriginalCharEquipmentID == 0) && (objCE.CharacterEquipmentID != 0)) _OriginalCharEquipmentID = objCE.CharacterEquipmentID;

            //Move to Character the Attack and Damage Bonuses
            txtEquipmentName.Text = objCE.objEquipment.EquipmentName;
            txtEquipmentDescription.Text = objCE.objEquipment.EquipmentDescription;
            txtCharacterEquipmentNotes.Text = objCE.Notes;
            txtEquipmentCost.Text = objCE.objEquipment.EquipmentCost.ToString();
            txtEquipmentWeight.Text = objCE.objEquipment.EquipmentWeight.ToString();
            txtBook.Text = objCE.objEquipment.objBook.BookName;
            if (objCE.objEquipment.Upgradable)
            {
                txtEmplacementPoints.Text = objCE.objEquipment.EmplacementPoints.ToString();
                lblEmplacementPoints.Text = "Emplacement Pts:";
                txtEmplacementPoints.ReadOnly = true;
                btnSave.Visible = false;
                btnAddEquipmentModification.Enabled  = true;
                btnSave.Enabled = true;
            }
            else
            {
                txtEmplacementPoints.Text = objCE.Quantity.ToString();
                lblEmplacementPoints.Text = "Quantity:";
                txtEmplacementPoints.ReadOnly = false;
                btnSave.Visible = true;
                btnAddEquipmentModification.Enabled = false;
                btnSave.Enabled = false;
            }

            if (objCE.objEquipment.EmplacementPoints > 0) this.btnAddEquipmentModification.Enabled = true; else this.btnAddEquipmentModification.Enabled = false;
            LoadModificationListView();
            SetButtons();


        }

        public void ResetControl()
        {
            _intCharacterID = 0;
            _intEquipmentID = 0;
            _intCharacterEquipmentID = 0;
            _OriginalCharEquipmentID = 0;
            _cwObjCE = new CharacterEquipment();

            txtEquipmentName.Text = "";
            txtEquipmentDescription.Text = "";
            txtCharacterEquipmentNotes.Text = "";
            txtEquipmentCost.Text = "";
            txtEquipmentWeight.Text = "";
            txtBook.Text = "";
            txtEmplacementPoints.Text = "";
            btnAddEquipmentModification.Enabled = false;
            btnSave.Enabled = false;
            lblEmplacementPoints.Text = "Emplacement Pts:";
            txtEmplacementPoints.ReadOnly = true;
            btnSave.Visible = false;
            this.btnAddEquipmentModification.Enabled = false;
            this.btnSave.Enabled = false;
        }
        #endregion

        #region Private Methods
        private void SetButtons()
        {
            //This no longer needed since we are using an single "Edit" button not an Add button and Remove button (two buttons)
            //if (tvModifications.Nodes.Count < _cwObjCE.objEquipment.EmplacementPoints) btnAddModification.Enabled = true; else btnAddModification.Enabled = false;
            ////if (tvModifications.Nodes.Count > 0) btnRemoveModification.Enabled = true; else btnRemoveModification.Enabled = false;
            //if (tvModifications.Nodes.Count > 0) btnRemoveModification.Enabled = false;
        }

        private void LoadModificationListView()
        {
            tvModifications.Nodes.Clear();
            if (_cwObjCE.lstModifications.Count > 0)
            {
                foreach (Modification objMod in _cwObjCE.lstModifications)
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objMod.ModificationName;
                    objTN.Tag = objMod.ModificationID;
                    tvModifications.Nodes.Add(objTN);
                }
            }
        }
        #endregion

        #region Control Events
        private void btnSave_Click (object sender, EventArgs e)
        {
            //Saves either the quantity or the Notes, don't need to leave the control for this.
            if (!_cwObjCE.objEquipment.Upgradable) 
            {
                int intQuantity = 0;
                int.TryParse(this.txtEmplacementPoints.Text, out intQuantity);
                _cwObjCE.Quantity = intQuantity;
            }
            _cwObjCE.Notes = this.txtCharacterEquipmentNotes.Text;
            _cwObjCE.SaveCharacterEquipment();

            //Save_Click(sender, e);
        }
          

        private void btnAddEquipmentEP_Click(object sender, EventArgs e)
        {
            SetButtons();
            AddEquipmentEP_Click(sender, e);
        }

        private void btnRemoveModification_Click(object sender, EventArgs e)
        {
            //RemoveEmplacementPoint_Click(sender, e);
            TreeNode objTN = tvModifications.SelectedNode;
            Modification objModification = new Modification((int)objTN.Tag);
            _cwObjCE.lstModifications = Modification.RemoveListObject(_cwObjCE.lstModifications, objModification);
            LoadModificationListView();
            SetButtons();

        }

        private void lvModifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtModificationDescription.Text = "";
            string strTag = tvModifications.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Modification objMod = new Modification();
                objMod.GetModification(intTag);
                this.txtModificationDescription.Text = objMod.ModificationDescription;
            }
        }

        private void tvModifications_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.txtModificationDescription.Text = "";
            TreeNode objTN = tvModifications.SelectedNode;
            Modification objModification = new Modification((int)objTN.Tag);
            this.txtModificationDescription.Text = objModification.ModificationDescription;

            //btnRemoveModification.Enabled = true;
        }
        #endregion

        private void txtCharacterEquipmentNotes_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Visible = true;
            this.btnSave.Enabled = true;
        }



        #endregion
    }
}
