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

using System.Data.SqlClient;

namespace StarWarsRPG
{
    public partial class frmAddCharacterLevel_SkillSelection : Form
    {
        //New Object that contains all the above items
        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();

        public static int MaxSkillCount;
        public int intCurrentSkillCount = 0;

        private bool blnCancelAfterSelectEvent = false;

        public frmAddCharacterLevel_SkillSelection()
        {
            InitializeComponent();
            LoadTreeView();
            lblSkillCount.Text = lblSkillCount.Text + " " + MaxSkillCount.ToString();
            LoadCharacterSkills();

            if (objCALC.lstNewSkills.Count > 0)
            {
                //Set the form.

                List<TreeNode> lstTN = new List<TreeNode>();
                List<TreeNode> lstSelTN = new List<TreeNode>();
                foreach (TreeNode objTN in tvSkillList.Nodes)
                {
                    lstTN.Add(objTN);
                }


                foreach (CharacterSkill objCS in objCALC.lstNewSkills)
                {
                    TreeNode objTN = new TreeNode();
                    foreach (TreeNode objLstTN in lstTN )
                    {
                        if (objLstTN.Text == objCS.objSkill.SkillName )
                        {
                            tvSkillList.Nodes.Remove(objLstTN);
                            lstSelTN.Add(objLstTN);
                        }

                    }
                }

                lstSelTN.OrderBy(n => n.Text).ToList<TreeNode>();

                foreach(TreeNode objSelTreeNode in lstSelTN)
                {
                    tvSelectedSkills.Nodes.Add(objSelTreeNode);
                }
                this.btnRemoveAllSkill.Enabled = true;
                this.btnSelectSkills.Enabled = true;

                objCALC.lstNewSkills.Clear();
            }
        }

        #region Form Events
        private void tvSkillList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (blnCancelAfterSelectEvent) return;
            string strPreTag = tvSkillList.SelectedNode.Tag.ToString().Substring(0, 2);
            string strTag = tvSkillList.SelectedNode.Tag.ToString().Substring(2, tvSkillList.SelectedNode.Tag.ToString().Length - 2);
            int intTag = 0;

            int.TryParse(strTag, out intTag);
            SubSkill objSS = new SubSkill();
            Skill objS = new Skill();

            if (strPreTag == "SK")
            {
                //Skill
                objSS = new SubSkill();
                objS.GetSkill(intTag);
                if (intCurrentSkillCount == MaxSkillCount) SetAddRemoveButtons(false, false, false); else SetAddRemoveButtons(true, false, false);

            }
            else
            {
                //SubSkill
                objS = new Skill();
                objSS.GetSubSkill(intTag);
                SetAddRemoveButtons(false, false, false);

            }

            SetLabels(objS, objSS, false);
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            string strPreTag = tvSkillList.SelectedNode.Tag.ToString().Substring(0, 2);
            string strTag = tvSkillList.SelectedNode.Tag.ToString().Substring(2, tvSkillList.SelectedNode.Tag.ToString().Length - 2);
            int intTag;

            int.TryParse(strTag, out intTag);

            TreeNode objTreeN = new TreeNode();
            objTreeN = tvSkillList.SelectedNode;

            //Fires the After Select event so that the first time we select a node the After Select event doesnot fire.
            blnCancelAfterSelectEvent = true;
            tvSkillList.Nodes.Remove(objTreeN);
            tvSelectedSkills.Nodes.Add(objTreeN);
            OrderTreeView(tvSelectedSkills);
            blnCancelAfterSelectEvent = false;

            bool blnAllButton;
            if (this.tvSelectedSkills.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetAddRemoveButtons(false, false, blnAllButton);

            SubSkill objSS = new SubSkill();
            Skill objS = new Skill();
            SetLabels(objS, objSS, false);
            intCurrentSkillCount++;

            SetSelectSkillsButton();
        }

        private void btnRemoveSkill_Click(object sender, EventArgs e)
        {
            TreeNode objTreeN = new TreeNode();
            objTreeN = tvSelectedSkills.SelectedNode;

            blnCancelAfterSelectEvent = true;
            tvSelectedSkills.Nodes.Remove(tvSelectedSkills.SelectedNode);
            tvSkillList.Nodes.Add(objTreeN);
            OrderTreeView(tvSkillList);
            blnCancelAfterSelectEvent = false;

            bool blnAllButton;
            if (this.tvSkillList.Nodes.Count > 0) blnAllButton = true; else blnAllButton = false;
            SetAddRemoveButtons(false, false, blnAllButton);

            SubSkill objSS = new SubSkill();
            Skill objS = new Skill();
            SetLabels(objS, objSS, false);
            intCurrentSkillCount--;

            SetSelectSkillsButton();
        }

        private void btnRemoveAllSkill_Click(object sender, EventArgs e)
        {

            blnCancelAfterSelectEvent = true;
            List<TreeNode> lstTN = new List<TreeNode>();

            foreach (TreeNode objTN in tvSelectedSkills.Nodes)
            {
                lstTN.Add(objTN);
            }

            //Can't remove if while looping through it
            foreach (TreeNode objTN in lstTN)
            {
                tvSelectedSkills.Nodes.Remove(objTN);
                tvSkillList.Nodes.Add(objTN);
            }

            blnCancelAfterSelectEvent = false;

            OrderTreeView(tvSkillList);

            SetAddRemoveButtons(false, false, false);

            SubSkill objSS = new SubSkill();
            Skill objS = new Skill();
            SetLabels(objS, objSS, false);
            intCurrentSkillCount = 0;

            SetSelectSkillsButton();

        }

        private void tvSelectedSkills_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (blnCancelAfterSelectEvent) return;

            string strPreTag = tvSelectedSkills.SelectedNode.Tag.ToString().Substring(0, 2);
            string strTag = tvSelectedSkills.SelectedNode.Tag.ToString().Substring(2, tvSelectedSkills.SelectedNode.Tag.ToString().Length - 2);
            int intTag = 0;

            int.TryParse(strTag, out intTag);
            SubSkill objSS = new SubSkill();
            Skill objS = new Skill();

            if (strPreTag == "SK")
            {
                //Skill
                objSS = new SubSkill();
                objS.GetSkill(intTag);
                SetAddRemoveButtons(false, true, true);
            }
            else
            {
                //SubSkill
                objS = new Skill();
                objSS.GetSubSkill(intTag);
                SetAddRemoveButtons(false, false, false);
            }
            //SetAddRemoveButtons(false, true, true);
            SetLabels(objS, objSS, false);

        }

        private void btnSelectSkills_Click(object sender, EventArgs e)
        {
            string strTag = "";
            string strPreTag = "";
            int intTag = 0;

            foreach (TreeNode objTN in tvSelectedSkills.Nodes)
            {
                strPreTag = objTN.Tag.ToString().Substring(0, 2);
                strTag = objTN.Tag.ToString().Substring(2, objTN.Tag.ToString().Length - 2);
                int.TryParse(strTag, out intTag);
                CharacterSkill objCharSkill = new CharacterSkill();
                Skill objSkill = new Skill();
                objSkill.GetSkill(intTag);

                objCharSkill.SkillID = objSkill.SkillID;
                objCharSkill.HalfLevel = objCALC.objNewCharLevel.CharacterLevelID / 2;      //Get the 1/2 level
                objCharSkill.AbilityMod = Common.GetCharSkillAbilityMod(objCALC.objCharacter, objSkill);
                objCharSkill.Trained = 5;                                                                  //Char will be trained in this skill.
                objCharSkill.SkillFocus = 0;                                                              //no skill focus yet, have to select the Feat First.
                objCharSkill.Miscellaneous = 0;
                objCharSkill.objSkill = objSkill;

                objCALC.lstNewSkills.Add(objCharSkill);
                objCALC.objCharacter.lstCharacterSkills.Add(objCharSkill);
            }

            
            this.Close();
        }

        private void frmAddCharacterLevel_SkillSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }
        #endregion

        #region Methods
        private void LoadTreeView()
        {
            List<Skill> lstSkills = new List<Skill>();
            Skill objSkill = new Skill();

            lstSkills = objSkill.GetCharacterSelectableSkillList(objCALC.objCharacter, objCALC.objSelectedClass);


            foreach (Skill objClassSkill in lstSkills)
            {
                List<SubSkill> lstSubSkills = new List<SubSkill>();
                SubSkill objSubSkill = new SubSkill();

                lstSubSkills = objSubSkill.GetSubSkills("SkillID=" + objClassSkill.SkillID.ToString(), "SubSkillName");

                List<TreeNode> SubSkillListForSkill = new List<TreeNode>();
                foreach (SubSkill objSSList in lstSubSkills )
                {
                    TreeNode objTN = new TreeNode();
                    objTN.Text = objSSList.SubSkillName ;
                    objTN.Tag = "SS" + objSSList.SubSkillID ;
                    SubSkillListForSkill.Add(objTN);
                }

                if (SubSkillListForSkill.Count > 0)
                {
                    TreeNode[] SkillNodes = new TreeNode[SubSkillListForSkill.Count];
                    SkillNodes = SubSkillListForSkill.ToArray();

                    TreeNode objSkillTN = new TreeNode(objClassSkill.SkillName, SkillNodes);                                                                            
                    objSkillTN.Tag = "SK" + objClassSkill.SkillID;
                    tvSkillList.Nodes.Add(objSkillTN);
                }
            }
        }

        private void LoadCharacterSkills()
        {
            //Set Current Char Skills
            string strCharSkill = "";
            foreach (CharacterSkill objCharSkill in objCALC.objCharacter.lstCharacterSkills)
            {
                strCharSkill = strCharSkill + objCharSkill.objSkill.SkillName  + ", ";
            }

            if (strCharSkill.Length > 2) txtCurrentCharacterSkills.Text = strCharSkill.Substring(0, strCharSkill.Length - 2); else txtCurrentCharacterSkills.Text = "";
        }

        private void  SetAddRemoveButtons(bool blnAddButton, bool blnRemoveButton,bool blnRemoveAllButton)
        {
            this.btnAddSkill.Enabled = blnAddButton;
            this.btnRemoveSkill.Enabled = blnRemoveButton;
            this.btnRemoveAllSkill.Enabled = blnRemoveAllButton;
        }

        private void SetLabels(Skill objSkill, SubSkill objSubSkill, bool blnBlankOut)
        {
            if (blnBlankOut)
            {
                gbSkillInfo.Text = "Skill Info";
                lblSkillName.Text = "Skill Name:";
                txtSkillName.Text = "";
                lblSkillDescription.Text = "Skill Description:";
                txtSkillDescription.Text = "";

                lblAbilityName.Visible = true;
                txtAbilityName.Visible = true;
                txtAbilityName.Text = "";

                ckbTrained.Visible = false;
                ckbTrained.Checked = false;
            }
            else
            {
                if (objSkill.SkillName != null)
                {
                    gbSkillInfo.Text = "Skill Info";
                    lblSkillName.Text = "Skill Name:";
                    txtSkillName.Text = objSkill.SkillName;

                    lblSkillDescription.Text = "Skill Description:";
                    txtSkillDescription.Text = objSkill.SkillDescription;
                    
                    lblAbilityName.Visible = true;
                    txtAbilityName.Visible = true;
                    txtAbilityName.Text = objSkill.objAbility.AbilityName;

                    ckbTrained.Visible = false;
                    ckbTrained.Checked = false;
                }
                else
                {
                    gbSkillInfo.Text = "SubSkill Info";
                    lblSkillName.Text = "SubSkill Name:";
                    txtSkillName.Text = objSubSkill.SubSkillName;

                    lblSkillDescription.Text = "SubSkill Description:";
                    txtSkillDescription.Text = objSubSkill.SubSkillDescription;

                    lblAbilityName.Visible = false;
                    txtAbilityName.Visible = false;
                    txtAbilityName.Text = "";

                    ckbTrained.Visible = true;
                    ckbTrained.Checked = objSubSkill.Trained;
                }
            }
        }

        private void OrderTreeView(TreeView objTV)
        {
            List<TreeNode> lstTreeNodes = new List<TreeNode>();

            foreach (TreeNode objTN in objTV.Nodes )
            {
                lstTreeNodes.Add(objTN);
            }

            lstTreeNodes = lstTreeNodes.OrderBy(n => n.Text).ToList<TreeNode>();

  
            objTV.Nodes.Clear();

            objTV.Nodes.AddRange(lstTreeNodes.ToArray());
        
        }
        
        private void SetSelectSkillsButton()
        {
            if (intCurrentSkillCount == MaxSkillCount) btnSelectSkills.Enabled = true; else btnSelectSkills.Enabled = false;
        }        
        #endregion






    }
}
