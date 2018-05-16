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
    public partial class frmEquipmentSelection : Form
    {
        private int intEquipmentSelectedID = 0;

        Equipment objSelectedEquipment = new Equipment();
        public static Character objCharacter;

        public frmEquipmentSelection()
        {
            InitializeComponent();
            LoadTreeView();
        }

        #region Methods
        #region Private Methods
        private TreeNode CreateEquipmentNode(Equipment objEquip)
        {
            TreeNode objTN = new TreeNode();
            objTN.Text = objEquip.EquipmentName;
            objTN.Tag = objEquip.EquipmentID;
            return objTN;
        }

        private void LoadTreeView()
        {
            tvEquipmentList.Nodes.Clear();

            List<EquipmentType> lstEquipmentType = new List<EquipmentType>();
            EquipmentType objEquipmentType = new EquipmentType();

            List<Equipment> lstEquipment = new List<Equipment>();
            Equipment objEquipment = new Equipment();

            lstEquipmentType = objEquipmentType.GetEquipmentTypes("", "EquipmentTypeName");
            

            foreach (EquipmentType objListEquipmentType in lstEquipmentType)
            {
                lstEquipment = objEquipment.GetEquipmentByEquipmentTypeID(objListEquipmentType.EquipmentTypeID);
                TreeNode objWTTN = new TreeNode();
                objWTTN.Text = objListEquipmentType.EquipmentTypeName;
                objWTTN.Tag = objListEquipmentType.EquipmentTypeID;

                foreach (Equipment objListEquipment in lstEquipment)
                {
                    if (!objListEquipment.Upgradable)
                    {
                        if (!CharacterEquipment.IsEquipmentInCharacterEquipmentList(objListEquipment, objCharacter.lstEquipmentList)) objWTTN.Nodes.Add(CreateEquipmentNode(objListEquipment));
                        //if its notupgradable, 
                        //check to see if the character already has it  (if so don't add (they change quantity)
                        //else Add it
                    }
                    else objWTTN.Nodes.Add(CreateEquipmentNode(objListEquipment));
                    
                }
                tvEquipmentList.Nodes.Add(objWTTN);
            }
        }

        private void SetEquipmentFields(Equipment objEquipment)
        {
            intEquipmentSelectedID = objEquipment.EquipmentID;
            this.txtCost.Text = objEquipment.EquipmentCost.ToString();
            this.txtBookName.Text = objEquipment.objBook.BookName;
            this.txtEmplacementPoints.Text = objEquipment.EmplacementPoints.ToString();
            this.txtEquipmentName.Text = objEquipment.EquipmentName;
            this.txtEquipmentDescription.Text = objEquipment.EquipmentDescription;
            this.txtEquipmentType.Text = objEquipment.objEquipmentType.EquipmentTypeName;
            this.txtEquipmentWeight.Text = objEquipment.EquipmentWeight.ToString();
            this.ckbUpgradeable.Checked = objEquipment.Upgradable;
            objSelectedEquipment = objEquipment;

            SetQuantityFields(!objEquipment.Upgradable);
            
            this.btnSelectEquipment.Enabled = true;
        }

        private void SetQuantityFields (bool blnVisible)
        {
            this.txtQuantity.Visible = blnVisible;
            this.lblQuantity.Visible = blnVisible;
            this.txtQuantity.ReadOnly = false;
            this.txtQuantity.Text = "1";
        }

        #endregion
        #endregion

        #region Form Events
        private void tvEquipmentList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvEquipmentList.SelectedNode.Nodes.Count > 0) return;

            string strTag = tvEquipmentList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Equipment objEquipment = new Equipment(intTag);
                SetEquipmentFields(objEquipment);
            }
        }

        private void btnSelectEquipment_Click(object sender, EventArgs e)
        {
            int intEquipQuantity = 0;
            int.TryParse(this.txtQuantity.Text, out intEquipQuantity);

            frmMain.intNewCharacterEquipmentEquipmentID = intEquipmentSelectedID;
            if (objSelectedEquipment.Upgradable) frmMain.intNewCharacterEquipmentQuantity = 0; else frmMain.intNewCharacterEquipmentQuantity = intEquipQuantity;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }
        #endregion


    }
}
