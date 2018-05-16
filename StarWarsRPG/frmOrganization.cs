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
    public partial class frmOrganization : Form
    {

        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();
        public int intCharOrganizationID = 0;
        public int intCharForceTraditionID = 0;
        public static List<Organization> lstCharOrgs;


        private bool blnCancelAfterSelectEvent = false;

        int intOrganizationLimit = Common.GetAppSettingsID("OrganizationLimit");
        int intCurrenOrgCount = 0;
        
        public frmOrganization()
        {
            InitializeComponent();
            LoadTreeView();
            LoadCharOrgsTreeView();
            //LoadOrganizationDropDown();
            lblMaxOrgs.Text = lblMaxOrgs.Text + " " + intOrganizationLimit.ToString ();
            if (intCurrenOrgCount >= 1 && intCurrenOrgCount < intOrganizationLimit) SetOrgSelectButtons(false, false, true); else SetOrgSelectButtons(false, false, false);
        }

        #region Methods
        /// <summary>
        /// Loads the organization drop down.
        /// </summary>
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

        /// <summary>
        /// Sets the select orgs button.
        /// </summary>
        private void SetSelectOrgsButton()
        {
            //if (intCurrentlangCount == intOrganizationLimit) btnSetOrganizations.Enabled = true; else btnSetOrganizations.Enabled = false;
            btnSetOrganizations.Enabled = true;
        }

        /// <summary>
        /// Sets enable property of the ForcePower select buttons between the two Tree Views (List of Force Powers and Force Powers Selected).
        /// </summary>
        /// <param name="AddButton">if set to <c>true</c> [btnAddFP] enabled, <c>false</c> it is disabled.</param>
        /// <param name="RemoveButton">if set to <c>true</c> [btnRemoveFP], <c>false</c> it is disabled.</param>
        /// <param name="RemoveAllButton">if set to <c>true</c> [btnRemoveAllFP], <c>false</c> it is disabled.</param>
        public void SetOrgSelectButtons(bool AddButton, bool RemoveButton, bool RemoveAllButton)
        {
            if (intOrganizationLimit == this.tvSelectedOrganizations.Nodes.Count)
            {
                this.btnAddFP.Enabled = false;
                this.btnRemoveFP.Enabled = RemoveButton;
                this.btnRemoveAllFP.Enabled = true;
            }
            else
            {
                this.btnAddFP.Enabled = AddButton;
                this.btnRemoveFP.Enabled = RemoveButton;
                this.btnRemoveAllFP.Enabled = RemoveAllButton;
            }
        }

        /// <summary>
        /// Orders the TreeView.
        /// </summary>
        /// <param name="objTV">The object tv.</param>
        private void OrderTreeView(TreeView objTV)
        {
            List<TreeNode> lstTreeNodes = new List<TreeNode>();

            foreach (TreeNode objTN in objTV.Nodes)
            {
                lstTreeNodes.Add(objTN);
            }

            lstTreeNodes = lstTreeNodes.OrderBy(n => n.Text).ToList<TreeNode>();


            objTV.Nodes.Clear();

            objTV.Nodes.AddRange(lstTreeNodes.ToArray());

        }

        /// <summary>
        /// Sets the form fields.
        /// </summary>
        /// <param name="strOrgID">The string org identifier.</param>
        public void SetFormFields(string strOrgID)
        {
            int intOrgID = 0;

            if (strOrgID != "")
            {
                int.TryParse(strOrgID, out intOrgID);
                Organization objOrg = new Organization(intOrgID);
                this.txtOrganizationAllies.Text = objOrg.OrganizationAllies;
                this.txtOrganizationDescription.Text = objOrg.OrganizationDescription;
                this.txtOrganizationEnemies.Text = objOrg.OrganizationEnemies;
                this.txtOrganizationScale.Text = objOrg.objOrganizationScale.OrganizationScaleName;
                this.txtOrganizationType.Text = objOrg.objOrganizationType.OrganizationTypeName;
                if (objOrg.ForceTraditionID == 0)
                {
                    //this.ckbAssociateForceTradition.Visible = false;
                    this.lblForceTradition.Visible = false;
                    this.txtForceTradition.Visible = false;
                }
                else
                {
                    //this.ckbAssociateForceTradition.Visible = true;
                    this.lblForceTradition.Visible = true;
                    this.txtForceTradition.Visible = true;
                    this.txtForceTradition.Text = objOrg.objForceTradition.ForceTraditionName;
                }
            }
            else
            {
                this.txtOrganizationAllies.Text = "";
                this.txtOrganizationDescription.Text = "";
                this.txtOrganizationEnemies.Text = "";
                this.txtOrganizationScale.Text = "";
                this.txtOrganizationType.Text = "";
                this.txtForceTradition.Text = "";
            }

        }

        /// <summary>
        /// Loads the TreeView tvOrganizationList.
        /// </summary>
        public void LoadTreeView()
        {
            tvOrganizationList.Nodes.Clear();

            List<Organization> lstOrgs = new List<Organization>();
            Organization objOrg = new Organization();

            lstOrgs = objOrg.GetOrganizations("", "OrganizationName");

            foreach (Organization objListOrg in lstOrgs)
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objListOrg.OrganizationName;
                objTN.Tag = objListOrg.OrganizationID;
                tvOrganizationList.Nodes.Add(objTN);
            }
        }

        /// <summary>
        /// Loads the character orgs TreeView.
        /// </summary>
        public void LoadCharOrgsTreeView()
        {
            if (lstCharOrgs != null)
            {
                foreach (Organization objOrg in lstCharOrgs)
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objOrg.OrganizationName;
                    objTN.Tag = objOrg.OrganizationID;
                    tvSelectedOrganizations.Nodes.Add(objTN);

                    //Now remove these nodes from the tvOrganizationList TreeView
                    TreeNode objRemoveTN = new TreeNode();
                    foreach (TreeNode objTreeNode in tvOrganizationList.Nodes)
                    {
                        if (objTreeNode.Tag.Equals(objTN.Tag)) objRemoveTN = objTreeNode;
                    }
                    objRemoveTN.Remove();
                }

                intCurrenOrgCount = lstCharOrgs.Count;
            }
        }

        /// <summary>
        /// Sets the labels.
        /// </summary>
        /// <param name="objTreeNode">The object tree node.</param>
        /// <param name="blnBlankOut">if set to <c>true</c> [BLN blank out].</param>
        private void SetLabels(TreeNode objTreeNode, bool blnBlankOut)
        {
            if (blnBlankOut) SetFormFields(""); else SetFormFields(objTreeNode.Tag.ToString());


        }
        #endregion

        #region Form Events
        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbOrganization control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Setup the form
            //Organization objOrg = new Organization();

                //objOrg = this.cmbRace.SelectedItem.ToString().Substring(0, this.cmbRace.SelectedItem.ToString().IndexOf(" - "));
                //strSex = this.cmbRace.SelectedItem.ToString().Substring(this.cmbRace.SelectedItem.ToString().IndexOf(" - ") + 3);
                //strRace.Trim();
                //strSex.Trim();
                //charRace.GetRace(strRace, strSex);
                //this.txtSex.Text = strSex;
                //this.txtSex.Enabled = false;
            
        }

        /// <summary>
        /// Handles the Click event of the btnAddFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnAddOrg_Click(object sender, EventArgs e)
        {
            TreeNode objTreeN = new TreeNode();
            objTreeN = tvOrganizationList.SelectedNode;

            //Fires the After Select event so that the first time we select a node the After Select event doesnot fire.
            blnCancelAfterSelectEvent = true;
            tvOrganizationList.Nodes.Remove(objTreeN);
            tvSelectedOrganizations.Nodes.Add(objTreeN);
            OrderTreeView(tvSelectedOrganizations);
            blnCancelAfterSelectEvent = false;

            bool blnAllButton, blnRemoveOne;
            if (this.tvSelectedOrganizations.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            if (this.intCurrenOrgCount >=1) blnRemoveOne = true; else blnRemoveOne = false;
            SetOrgSelectButtons(false, blnRemoveOne, blnAllButton);

            
            //Organization objOrganization = new Organization();
            SetLabels(objTreeN , true);
            intCurrenOrgCount++;

            SetSelectOrgsButton();
            
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRemoveOrg_Click(object sender, EventArgs e)
        {
            TreeNode objTreeN = new TreeNode();
            objTreeN = tvSelectedOrganizations.SelectedNode;

            blnCancelAfterSelectEvent = true;
            tvSelectedOrganizations.Nodes.Remove(tvSelectedOrganizations.SelectedNode);
            tvOrganizationList.Nodes.Add(objTreeN);
            OrderTreeView(tvOrganizationList);
            blnCancelAfterSelectEvent = false;

            bool blnAllButton;
            if (this.tvOrganizationList.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetOrgSelectButtons(false, false, blnAllButton);


            SetLabels(objTreeN, true);
            intCurrenOrgCount--;

            SetSelectOrgsButton();
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAllFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRemoveAllOrg_Click(object sender, EventArgs e)
        {
            blnCancelAfterSelectEvent = true;
            List<TreeNode> lstTN = new List<TreeNode>();

            foreach (TreeNode objTN in tvSelectedOrganizations.Nodes)
            {
                lstTN.Add(objTN);
            }

            //Can't remove if while looping through it
            foreach (TreeNode objTN in lstTN)
            {
                tvSelectedOrganizations.Nodes.Remove(objTN);
                tvOrganizationList.Nodes.Add(objTN);
            }

            blnCancelAfterSelectEvent = false;

            OrderTreeView(tvOrganizationList);

            SetOrgSelectButtons(false, false, false);

            TreeNode objTreeNode = new TreeNode();
            SetLabels(objTreeNode, true);
            intCurrenOrgCount = 0;

            SetSelectOrgsButton();

        }

        /// <summary>
        /// Handles the AfterSelect event of the tvOrganizationList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvOrganizationList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (blnCancelAfterSelectEvent) return;
            SetFormFields(tvOrganizationList.SelectedNode.Tag.ToString());

            bool blnAllButton;
            if (this.tvSelectedOrganizations.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetOrgSelectButtons(true, false, blnAllButton);
        }

        /// <summary>
        /// Handles the AfterSelect event of the tvSelectedOrganizations control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvSelectedOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (blnCancelAfterSelectEvent) return;
            SetFormFields(tvSelectedOrganizations.SelectedNode.Tag.ToString());
            SetOrgSelectButtons(false, true, true);
        }

        /// <summary>
        /// Handles the Click event of the btnSetOrganizations control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSetOrganizations_Click(object sender, EventArgs e)
        {
            List<Organization> lstNewOrgs = new List<Organization>();

            foreach (TreeNode objTN in tvSelectedOrganizations.Nodes  )
            {
                int intOrgID = 0;
                int.TryParse(objTN.Tag.ToString(), out intOrgID);
                if (intOrgID != 0)
                {
                    Organization objOrg = new Organization(intOrgID);
                    lstNewOrgs.Add(objOrg);
                }
            }
            frmMain.objCurrentChar.lstCharacterOrganizations = lstNewOrgs;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion







    }
}

