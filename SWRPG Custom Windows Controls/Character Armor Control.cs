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
    public partial class Character_Armor_Control : UserControl
    {
        int _intCharacterArmorID;
        int _OriginalCharArmorID;
        int _intCharacterID;
        int _intArmorID;

        CharacterArmor _cwObjCA;

        #region Properties
        public CharacterArmor objCharArmor
        {
            get { return _cwObjCA; }
        }

        public int CharacterArmorID
        {
            get { return _intCharacterArmorID; }
        }

        public int CharacterID
        {
            get { return _intCharacterID; }
        }

        public int ArmorID
        {
            get { return _intArmorID; }
        }

        public string ArmorName
        {
            get { return grpCharacterArmor.Text; }
        }

        public string ArmorType
        {
            get { return txtArmorType.Text; }
        }

        public string CharacterArmorNotes
        {
            get { return txtCharacterArmorNotes.Text; }
        }

        public int ArmorReflexAdjustment
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtReflexAdjustment.Text, out intRetVal);
                return intRetVal; 
            }
        }

        public int ArmorFortAdjustment
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtFortitudeAdjustment.Text, out intRetVal);
                return intRetVal; 
            }
        }

        public int ArmorEmplacementPoints
        {
            get {
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
                int.TryParse(txtWeight.Text, out intRetVal);
                return intRetVal;
            }
        }

        public int ArmorCheckPenalty
         {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtArmorChkPenalty.Text, out intRetVal);
                return intRetVal;
            }
        }

        public int ArmorSpeed8
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtSpeed8.Text, out intRetVal);
                return intRetVal;
            }
        }
        
        public int ArmorSpeed6
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtSpeed6.Text, out intRetVal);
                return intRetVal;
            }
        }
                
        public int ArmorSpeed4
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtSpeed4.Text, out intRetVal);
                return intRetVal;
            }
        }

        public int ArmorMaxDefensiveBonus
        {
            get
            {
                int intRetVal = 0;
                int.TryParse(txtMaxDefBonus.Text, out intRetVal);
                return intRetVal;
            }
        }

        public string ArmorAvailability
        {
            get { return txtArmorAvailability.Text; }
        }

        public string BookName
        {
            get { return txtBook.Text; }
        }

        public int ControlNumber { get; set; }
        #endregion

        public Character_Armor_Control()
        {
            InitializeComponent();
            btnAddModification.Click += new EventHandler(btnAddEmplacementPoint_Click);
        }
        #region Events
        
        public event EventHandler AddEmplacementPoint_Click;
        //public event EventHandler RemoveEmplacementPoint_Click;
        #endregion

        #region Methods
        #region Public Methods
        public void AddModifications(List<Modification> lstMods)
        {
            _cwObjCA.lstModifications = lstMods;
            LoadModificationListView();
        }

        public void SetControlWithCharacterArmor(Character objCharacter, CharacterArmor objCA)
        {
            _intCharacterID = objCA.CharacterID;
            _intArmorID = objCA.ArmorID;
            _cwObjCA = objCA;
            string strArmorAvail = "";
            if ((_OriginalCharArmorID == 0) && (objCA.CharacterArmorID != 0)) _OriginalCharArmorID = objCA.CharacterArmorID;

            //Move to Character the Attack and Damage Bonuses
            grpCharacterArmor.Text = objCA.objArmor.ArmorName ;
            txtArmorDescription.Text = objCA.objArmor.ArmorDescription ;
            txtCharacterArmorNotes.Text = objCA.Notes ;
            txtReflexAdjustment.Text = objCA.objArmor.ReflexAdjustment.ToString();
            txtFortitudeAdjustment.Text = objCA.objArmor.FortitudeAdjustment.ToString();
            txtCost.Text = objCA.objArmor.Cost.ToString();
            txtArmorChkPenalty.Text = objCA.objArmor.objArmorType.ArmorCheckPenalty .ToString();
            txtMaxDefBonus.Text = objCA.objArmor.MaxDefBonus.ToString();
            txtWeight.Text = objCA.objArmor.Weight.ToString();
            txtBook.Text = objCA.objArmor.objBook.BookName;
            txtEmplacementPoints.Text = objCA.objArmor.EmplacementPoints.ToString();

            if (objCA.objArmor.lstArmorAvailability.Count > 0)
            {
                foreach (ItemAvailabilityType objIAT in objCA.objArmor.lstArmorAvailability)
                {
                    strArmorAvail = strArmorAvail + objIAT.ItemAvailabilityTypeName + ", ";
                }
                strArmorAvail = strArmorAvail.Substring(0, strArmorAvail.Length - 2);
            }
            txtArmorAvailability.Text = strArmorAvail;

            txtArmorType.Text = objCA.objArmor.objArmorType.ArmorTypeName;
            txtSpeed6.Text = objCA.objArmor.objArmorType.Speed_6.ToString();
            txtSpeed4.Text = objCA.objArmor.objArmorType.Speed_4.ToString();
            txtSpeed8.Text = objCA.objArmor.objArmorType.Speed_8.ToString();
            txtModificationDescription.Text = "";

            LoadModificationListView();
            //SetButtons();


        }

        public void ResetControl()
        {
            _intCharacterID = 0;
            _intArmorID = 0;
            _intCharacterArmorID = 0;
            _OriginalCharArmorID = 0;
            _cwObjCA = new CharacterArmor();

        }
        #endregion

        #region Private Methods
        //private void SetButtons()
        //{
        //    //This no longer needed since we are using an single "Edit" button not an Add button and Remove button (two buttons)
        //    //if (tvModifications.Nodes.Count < _cwObjCA.objArmor.EmplacementPoints) btnAddModification.Enabled = true; else btnAddModification.Enabled = false;
        //    ////if (tvModifications.Nodes.Count > 0) btnRemoveModification.Enabled = true; else btnRemoveModification.Enabled = false;
        //    //if (tvModifications.Nodes.Count > 0) btnRemoveModification.Enabled = false;
        //}

        private void LoadModificationListView()
        {
            tvModifications.Nodes.Clear();
            if (_cwObjCA.lstModifications.Count > 0 )
            {
                foreach (Modification objMod in _cwObjCA.lstModifications)
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objMod.ModificationName  ;
                    objTN.Tag = objMod.ModificationID   ;
                    tvModifications.Nodes.Add(objTN);
                }
            }
        }
        #endregion

        #region Control Events
        private void btnAddEmplacementPoint_Click(object sender, EventArgs e)
        {
            //SetButtons();
            AddEmplacementPoint_Click(sender, e);
        }
        
        private void btnRemoveModification_Click(object sender, EventArgs e)
        {   
            //RemoveEmplacementPoint_Click(sender, e);
            TreeNode objTN = tvModifications.SelectedNode;
            Modification objModification = new Modification((int)objTN.Tag);
            _cwObjCA.lstModifications = Modification.RemoveListObject(_cwObjCA.lstModifications, objModification);
            LoadModificationListView();
            //SetButtons();
            
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
            
            btnRemoveModification.Enabled = true;
        }
        #endregion


        #endregion

    }
}
 