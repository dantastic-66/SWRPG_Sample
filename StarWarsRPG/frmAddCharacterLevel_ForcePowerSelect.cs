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

namespace StarWarsRPG
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class frmAddCharacterLevel_ForcePowerSelect : Form
    {
        /// <summary>
        /// The Database Connection Object
        /// </summary>
        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();
        /// <summary>
        /// The integer class level the character is going to.
        /// </summary>
        public static int ClassLevel;
        /// <summary>
        /// The Class of the new Character Level
        /// </summary>
        public static Class objSelectedClass = new Class();

        //New Container object
        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();

        /// <summary>
        /// The number of ForcePowers the Character can select this level.
        /// </summary>
        public static int ForcePowerCount;


        #region Form Events
        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddCharacterLevel_ForcePowerSelect"/> class.
        /// </summary>
        public frmAddCharacterLevel_ForcePowerSelect()
        {
            InitializeComponent();
            LoadTreeView();
            this.lblForcePowerCount.Text = lblForcePowerCount.Text + ForcePowerCount.ToString();

            //Set Current Char Force Powers
            string strCharFP = "";
            foreach (ForcePower objCharFP in objCALC.objCharacter.lstForcePowers)
            {
                strCharFP = strCharFP + objCharFP.ForcePowerName + ", ";
            }
            if (strCharFP.Length > 2) txtCurrentCharacterForcePowers.Text = strCharFP.Substring(0, strCharFP.Length - 2); else txtCurrentCharacterForcePowers.Text =""; 

            //If the lstNewForcePowers list has objects then set the Selected Tree View and Buttons
            if (objCALC.lstNewForcePowers.Count > 0)
            {
                //We have a list so pre select them.
                foreach (ForcePower objFP in objCALC.lstNewForcePowers)
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objFP.ForcePowerName;
                    objTN.Tag = objFP.ForcePowerID;
                    this.tvSelectedForcePowers.Nodes.Add(objTN);
                }

                //Set the buttons
                bool blnAllButton;
                if (this.tvSelectedForcePowers.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
                SetFPSelectButtons(false, false, blnAllButton);
            }

            //Clear out the Force Power object
            objCALC.lstNewForcePowers = new List<ForcePower>();
        }

        /// <summary>
        /// Handles the Click event of the btnSelectForcePower control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectForcePower_Click(object sender, EventArgs e)
        {
            string strTag = "";
            int intTag =0;

            foreach (TreeNode objTN in tvSelectedForcePowers.Nodes )
            {
                strTag =objTN.Tag.ToString() ;
                int.TryParse(strTag, out intTag);
                ForcePower objForcePower = new ForcePower();
                objForcePower.GetForcePower(intTag);
                objCALC.lstNewForcePowers.Add(objForcePower);
            }

            this.Close();

        }

        /// <summary>
        /// Handles the FormClosed event of the frmAddCharacterLevel_ForcePowerSelect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void frmAddCharacterLevel_ForcePowerSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }

        /// <summary>
        /// Handles the AfterSelect event of the tvForcePowerList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvForcePowerList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetForcePowerFields(tvForcePowerList.SelectedNode.Tag.ToString());
            //this.btnSelectForcePower.Enabled = true;
            //if (tvSelectedForcePowers.Nodes.Count != ForcePowerCount) SetFPSelectButtons(true, true, true);  // this.btnAddFP.Enabled = true;
            bool blnAllButton;
            if (this.tvSelectedForcePowers.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetFPSelectButtons(true, false, blnAllButton);
        }

        /// <summary>
        /// Handles the AfterSelect event of the tvSelectedForcePowers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvSelectedForcePowers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetForcePowerFields(tvSelectedForcePowers.SelectedNode.Tag.ToString());
            SetFPSelectButtons(false, true, true);
        }

        /// <summary>
        /// Handles the Click event of the btnAddFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddFP_Click(object sender, EventArgs e)
        {
            string strTag = tvForcePowerList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                ForcePower objForcePower = new ForcePower();
                objForcePower.GetForcePower(intTag);

                //add it to the force power selected tree view
                TreeNode objTN = new TreeNode();
                objTN.Text = objForcePower.ForcePowerName;
                objTN.Tag = objForcePower.ForcePowerID;
                tvSelectedForcePowers.Nodes.Add(objTN);

                bool blnAllButton;
                if (this.tvSelectedForcePowers.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
                SetFPSelectButtons(false, false, blnAllButton);
                //this.btnAddFP.Enabled = false;
                SetForcePowerFields("");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveFP_Click(object sender, EventArgs e)
        {
            tvSelectedForcePowers.Nodes.Remove(tvSelectedForcePowers.SelectedNode);
            this.btnRemoveFP.Enabled = false;
            //if (tvSelectedForcePowers.Nodes.Count == 0) this.btnRemoveAllFP.Enabled = false; else btnRemoveAllFP.Enabled = true;
            bool blnAllButton;
            if (this.tvSelectedForcePowers.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetFPSelectButtons(false, false, blnAllButton);
            SetForcePowerFields("");
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAllFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveAllFP_Click(object sender, EventArgs e)
        {
            tvSelectedForcePowers.Nodes.Clear();
            btnRemoveAllFP.Enabled = false;
            btnRemoveFP.Enabled = false;

            bool blnAllButton;
            if (this.tvSelectedForcePowers.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetFPSelectButtons(false, false, blnAllButton);
            SetForcePowerFields("");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the TreeView tvForcePowerList.
        /// </summary>
        public void LoadTreeView()
        {
            tvForcePowerList.Nodes.Clear();

            List<ForcePower> lstForcePowers = new List<ForcePower>();
            ForcePower objForcePower = new ForcePower();

            lstForcePowers = objForcePower.GetForcePowers("", "");

            foreach (ForcePower objListForcePower in lstForcePowers)
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objListForcePower.ForcePowerName;
                objTN.Tag = objListForcePower.ForcePowerID;
                tvForcePowerList.Nodes.Add(objTN);
            }
        }

        /// <summary>
        /// Sets enable property of the ForcePower select buttons between the two Tree Views (List of Force Powers and Force Powers Selected).
        /// </summary>
        /// <param name="AddButton">if set to <c>true</c> [btnAddFP] enabled, <c>false</c> it is disabled.</param>
        /// <param name="RemoveButton">if set to <c>true</c> [btnRemoveFP], <c>false</c> it is disabled.</param>
        /// <param name="RemoveAllButton">if set to <c>true</c> [btnRemoveAllFP], <c>false</c> it is disabled.</param>
        public void SetFPSelectButtons(bool AddButton, bool RemoveButton, bool RemoveAllButton)
        {
            if (ForcePowerCount == this.tvSelectedForcePowers.Nodes.Count)
            {
                this.btnAddFP.Enabled = false;
                this.btnRemoveFP.Enabled = RemoveButton;
                this.btnRemoveAllFP.Enabled = true;

                this.btnSelectForcePower.Enabled = true;
            }
            else
            {
                this.btnAddFP.Enabled = AddButton;
                this.btnRemoveFP.Enabled = RemoveButton;
                this.btnRemoveAllFP.Enabled = RemoveAllButton;

                this.btnSelectForcePower.Enabled = false;
            }
        }

        /// <summary>
        /// Sets the force power fields describing the selected ForcePower (from either tree).
        /// </summary>
        /// <param name="strTag">The Tag (string) from the selected ForcePower TreeNode object from either TreeView Control.</param>
        public void SetForcePowerFields(string strTag)
        {
            //string strTag = tvForcePowerList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                ForcePower objForcePower = new ForcePower();
                objForcePower.GetForcePower(intTag);

                this.txtForcePowerName.Text = objForcePower.ForcePowerName;
                this.txtForcePowerDescription.Text = objForcePower.ForcePowerDescription;
                this.txtForcePowerSpecial.Text = objForcePower.ForcePowerSpecial;
                this.txtForcePowerTarget.Text = objForcePower.ForcePowerTarget;
                this.txtTurnSegment.Text = objForcePower.objTurnSegment.TurnSegmentName;

                this.tvForcePowerDescriptor.Nodes.Clear();
                if (objForcePower.objForcePowerDescriptors != null)
                {
                    foreach (ForcePowerDescriptor objFPD in objForcePower.objForcePowerDescriptors )
                    {
                        TreeNode objTN = new TreeNode();
                        objTN.Text = objFPD.ForcePowerDescriptorName ;
                        objTN.Tag = objFPD.ForcePowerDescriptorID;
                        tvForcePowerDescriptor.Nodes.Add(objTN);
                    }
                }
            }
            else
            {
                this.txtForcePowerName.Text = "";
                this.txtForcePowerDescription.Text = "";
                this.txtForcePowerSpecial.Text = "";
                this.txtForcePowerTarget.Text = "";
                this.txtTurnSegment.Text = "";

                this.tvForcePowerDescriptor.Nodes.Clear();
            }
        }
        #endregion


    }
}
