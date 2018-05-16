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
    public partial class frmAddCharacterLevel_LanguageSelect : Form
    {
        /// <summary>
        /// The Database Connection Object
        /// </summary>
        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();

        /// <summary>
        /// The number of ForcePowers the Character can select this level.
        /// </summary>
        public static int LanguageCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddCharacterLevel_LanguageSelect"/> class.
        /// </summary>
        public frmAddCharacterLevel_LanguageSelect()
        {
            InitializeComponent();
            LoadTreeView();
            
            this.lblLanguageCount.Text = lblLanguageCount.Text + LanguageCount.ToString();

            //Set Current Char Languages
            string strCharLang = "";
            foreach (Language objCharLang in objCALC.objCharacter.lstLanguages)
            {
                strCharLang = strCharLang + objCharLang.LanguageName + ", ";
            }
            txtCurrentCharacterLanguages.Text = strCharLang.Substring(0,strCharLang.Length-2);

            if (objCALC.lstLanguages.Count > 0)
            {
                //We have a list so pre select them.
                foreach (Language objLang in objCALC.lstLanguages)
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objLang.LanguageName;
                    objTN.Tag = objLang.LanguageID;
                    tvSelectedLanguages.Nodes.Add(objTN);
                }

                //Set the buttons
                bool blnAllButton;
                if (this.tvSelectedLanguages.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
                SetLanguageSelectButtons(false, false, blnAllButton);
            }

            //reset the Language Obj
            objCALC.lstLanguages = new List<Language>();
        }

        #region Form Events
        /// <summary>
        /// Handles the Click event of the btnSelectForcePower control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectLanguage_Click(object sender, EventArgs e)
        {
            string strTag = "";
            int intTag =0;

            foreach (TreeNode objTN in tvSelectedLanguages.Nodes )
            {
                strTag =objTN.Tag.ToString() ;
                int.TryParse(strTag, out intTag);
                Language objLang = new Language();
                objLang.GetLanguage (intTag);
                objCALC.lstLanguages.Add(objLang);
            }

            this.Close();
        }

        /// <summary>
        /// Handles the FormClosed event of the frmAddCharacterLevel_ForcePowerSelect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void frmAddCharacterLevel_LanguageSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }

        /// <summary>
        /// Handles the AfterSelect event of the tvForcePowerList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvLanguageList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool blnAllButton;
            if (this.tvSelectedLanguages.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetLanguageSelectButtons(true, false, blnAllButton);
        }

        /// <summary>
        /// Handles the AfterSelect event of the tvSelectedForcePowers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void tvSelectedLanguages_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //SetForcePowerFields(tvSelectedLanguages.SelectedNode.Tag.ToString());
            SetLanguageSelectButtons(false, true, true);
        }

        /// <summary>
        /// Handles the Click event of the btnAddFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddLang_Click(object sender, EventArgs e)
        {
            string strTag = tvLanguageList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Language objLang = new Language();
                objLang.GetLanguage (intTag);

                //add it to the force power selected tree view
                TreeNode objTN = new TreeNode();
                objTN.Text = objLang.LanguageName;
                objTN.Tag = objLang.LanguageID;
                tvSelectedLanguages.Nodes.Add(objTN);

                bool blnAllButton;
                if (this.tvSelectedLanguages.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
                SetLanguageSelectButtons(false, false, blnAllButton);
                //this.btnAddFP.Enabled = false;
                //SetForcePowerFields("");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveLang_Click(object sender, EventArgs e)
        {
            tvSelectedLanguages.Nodes.Remove(tvSelectedLanguages.SelectedNode);
            this.btnRemoveLanguage.Enabled = false;
            //if (tvSelectedForcePowers.Nodes.Count == 0) this.btnRemoveAllFP.Enabled = false; else btnRemoveAllFP.Enabled = true;
            bool blnAllButton;
            if (this.tvSelectedLanguages.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetLanguageSelectButtons(false, false, blnAllButton);
            //SetForcePowerFields("");
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAllFP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveAllLang_Click(object sender, EventArgs e)
        {
            tvSelectedLanguages.Nodes.Clear();
            btnRemoveAllLanguages.Enabled = false;
            btnRemoveLanguage.Enabled = false;

            bool blnAllButton;
            if (this.tvSelectedLanguages.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetLanguageSelectButtons(false, false, blnAllButton);
            //SetForcePowerFields("");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the TreeView tvForcePowerList.
        /// </summary>
        public void LoadTreeView()
        {
            tvLanguageList.Nodes.Clear();

            List<Language> lstLanguages = new List<Language>();
            Language objLanguage = new Language();

            lstLanguages = objLanguage.GetLanguages("", "LanguageName");

            foreach (Language objListForcePower in lstLanguages)
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objListForcePower.LanguageName;
                objTN.Tag = objListForcePower.LanguageID;
                tvLanguageList.Nodes.Add(objTN);
            }
        }

        /// <summary>
        /// Sets enable property of the ForcePower select buttons between the two Tree Views (List of Force Powers and Force Powers Selected).
        /// </summary>
        /// <param name="AddButton">if set to <c>true</c> [btnAddFP] enabled, <c>false</c> it is disabled.</param>
        /// <param name="RemoveButton">if set to <c>true</c> [btnRemoveFP], <c>false</c> it is disabled.</param>
        /// <param name="RemoveAllButton">if set to <c>true</c> [btnRemoveAllFP], <c>false</c> it is disabled.</param>
        public void SetLanguageSelectButtons(bool AddButton, bool RemoveButton, bool RemoveAllButton)
        {
            if (LanguageCount == this.tvSelectedLanguages.Nodes.Count)
            {
                this.btnAddLanguage.Enabled = false;
                this.btnRemoveLanguage.Enabled = RemoveButton;
                this.btnRemoveAllLanguages.Enabled = true;

                this.btnSelectLanguages.Enabled = true;
            }
            else
            {
                this.btnAddLanguage.Enabled = AddButton;
                this.btnRemoveLanguage.Enabled = RemoveButton;
                this.btnRemoveAllLanguages.Enabled = RemoveAllButton;

                this.btnSelectLanguages.Enabled = false;
            }
        }

       #endregion


    }
}
