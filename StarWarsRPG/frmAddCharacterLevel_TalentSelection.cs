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
    public partial class frmAddCharacterLevel_TalentSelection : Form
    {
        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();

        #region Form Events
        public frmAddCharacterLevel_TalentSelection()
        {
            InitializeComponent();
            LoadTreeView();
        }

        private void tvTalentTreeTalents_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetTalentTreeTalentFields();
        }

        private void frmAddCharacterLevel_TalentSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }

        private void btnSelectTalent_Click(object sender, EventArgs e)
        {
            string strPreTag = tvTalentTreeTalents.SelectedNode.Tag.ToString().Substring(0, 2);
            string strTag = tvTalentTreeTalents.SelectedNode.Tag.ToString().Substring(2);
            int intTag;

            int.TryParse(strTag, out intTag);

            objCALC.objSelectedTalent.GetTalent(intTag);

            this.Close();
        }
        #endregion

        #region Methods
        private void LoadTreeView()
        {
            List<TalentTree> lstTalentTrees = new List<TalentTree>();
            TalentTree objTalentTree = new TalentTree();

            lstTalentTrees = objTalentTree.GetCharactersAllowableTalentTreesByAddedClass(objCALC.objCharacter, objCALC.objSelectedClass);
            foreach (TalentTree objTT in lstTalentTrees )
            {
               
                List<Talent> lstTalents = new List<Talent>();
                Talent objTalent = new Talent();
                lstTalents = objTalent.GetTalents("TalentTreeID=" + objTT.TalentTreeID, "TalentName");

                List<TreeNode> AllowableTalents = new List<TreeNode>();

                foreach (Talent objTal in lstTalents )
                {
                    TreeNode objTN = new TreeNode();
                    if (Talent.TalentAllowableByTalentList(objTal, objCALC.objCharacter.lstTalents))
                    {
                        if (objCALC.objCharacter.QualifiedForTalent(objTal))
                        {
                            objTN.Text = objTal.TalentName;
                            objTN.Tag = "TA" + objTal.TalentID;
                            AllowableTalents.Add(objTN);
                        }
                    }

                }
                if (AllowableTalents.Count() > 0)
                {
                    TreeNode[] TalTreeTalents = new TreeNode[AllowableTalents.Count];
                    TalTreeTalents = AllowableTalents.ToArray();

                    TreeNode objTalentTreeTN = new TreeNode(objTT.TalentTreeName, TalTreeTalents);
                    objTalentTreeTN.Tag = "TT" + objTT.TalentTreeID;
                    tvTalentTreeTalents.Nodes.Add(objTalentTreeTN);
                }
            }
        }

        private void SetTalentTreeTalentFields()
        {
            string strPreTag = tvTalentTreeTalents.SelectedNode.Tag.ToString().Substring(0, 2);
            string strTag = tvTalentTreeTalents.SelectedNode.Tag.ToString().Substring(2);
            int intTag;

            int.TryParse(strTag, out intTag);

            if (strPreTag == "TT")
            {
                //Talent Tree
                TalentTree objTalentTree = new TalentTree();
                objTalentTree.GetTalentTree(intTag);
                ckbForceTalentTree.Checked = objTalentTree.ForceTalent;
                this.gbTalent.Visible = false;

                this.btnSelectTalent.Enabled = false;
            }
            else
            {
                //Talent
                Talent objTalent = new Talent();
                objTalent.GetTalent(intTag);

                this.lblTalentName.Text = objTalent.TalentName;
                this.txtTalentSpecial.Text = objTalent.TalentSpecial;
                this.lblTurnSegment.Text = objTalent.objTurnSegment.TurnSegmentName;
                this.txtTalentDescription.Text = objTalent.TalentDescription;

                lstFeatsReq.Items.Clear();
                lstTalentsReq.Items.Clear();
                lstSkillsReq.Items.Clear();
                lstAbilitiesReq.Items.Clear();
                lstForcePowerReq.Items.Clear();
                txtBaseAttackReq.Text = "";

                TalentTree objTT = new TalentTree();
                objTT.GetTalentTree(objTalent.TalentTreeID);
                ckbForceTalentTree.Checked = objTT.ForceTalent;

                this.gbTalent.Visible = true;
                bool blnShowPrereqs = false;
                //Fill out the prereqs
                if (objTalent.objTalentPrerequsiteFeat.Count > 0)
                {
                    foreach (Feat objFeat in objTalent.objTalentPrerequsiteFeat)
                    {
                        lstFeatsReq.Items.Add(objFeat.FeatName);
                    }
                    this.lblFeatPrereq.Visible = true;
                    this.lstFeatsReq.Visible = true;
                    blnShowPrereqs = true;
                }
                else
                {
                    this.lblFeatPrereq.Visible = false;
                    this.lstFeatsReq.Visible = false;
                }

                if (objTalent.objPrerequsiteTalent.Count > 0)
                {
                    foreach (Talent objPrereqT in objTalent.objPrerequsiteTalent)
                    {
                        lstTalentsReq.Items.Add(objPrereqT.TalentName);
                    }
                    this.lblTalentRequired.Visible = true;
                    this.lstTalentsReq.Visible = true;
                    blnShowPrereqs = true;
                }
                else
                {
                    this.lblTalentRequired.Visible = false;
                    this.lstTalentsReq.Visible = false;
                }

                if (objTalent.objTalentPrerequsiteSkill.Count > 0)
                {
                    foreach (Skill objSkill in objTalent.objTalentPrerequsiteSkill)
                    {
                        lstSkillsReq.Items.Add(objSkill.SkillName);
                    }
                    this.lblSkillReq.Visible = true;
                    this.lstSkillsReq.Visible = true;
                    blnShowPrereqs = true;
                }
                else
                {
                    this.lblSkillReq.Visible = false;
                    this.lstSkillsReq.Visible = false;
                }

                if (objTalent.objTalentPrerequisteAbility.Count > 0)
                {
                    foreach (TalentPrerequisteAbility objTPA in objTalent.objTalentPrerequisteAbility)
                    {
                        lstAbilitiesReq.Items.Add(objTPA.objAbility.AbilityName + " - " + objTPA.AbilityMinimum);
                    }
                    this.lblAbilitiesReq.Visible = true;
                    this.lstAbilitiesReq.Visible = true;
                    blnShowPrereqs = true;

                }
                else
                {
                    this.lblAbilitiesReq.Visible = false;
                    this.lstAbilitiesReq.Visible = false;
                }

                if (objTalent.objTalentPrerequisteForcePower.Count > 0)
                {
                    foreach (ForcePower objFP in objTalent.objTalentPrerequisteForcePower)
                    {
                        this.lstForcePowerReq.Items.Add(objFP.ForcePowerName);
                    }
                    this.lblForcePowerReq.Visible = true;
                    this.lstForcePowerReq.Visible = true;
                    blnShowPrereqs = true;

                }
                else
                {
                    this.lblForcePowerReq.Visible = false;
                    this.lstForcePowerReq.Visible = false;
                }

                if (objTalent.objBaseAttackPrerequisite.BaseAttackID != 0)
                {
                    this.txtBaseAttackReq.Text = objTalent.objBaseAttackPrerequisite.BaseAttackNumber.ToString();
                    this.lblBaseAttackPrereq.Visible = true;
                    this.txtBaseAttackReq.Visible = true;
                    blnShowPrereqs = true;
                }
                else
                {
                    this.lblBaseAttackPrereq.Visible = false;
                    this.txtBaseAttackReq.Visible = false;
                }

                System.Drawing.Size szTDesc = new System.Drawing.Size(316, 268);
                System.Drawing.Size szTSpec = new System.Drawing.Size(316, 160);
                int intWidth = 504;

                this.gpTalentPrereqs.Visible = blnShowPrereqs;
                if (!blnShowPrereqs)
                {
                    szTDesc.Width = intWidth;
                    szTSpec.Width = intWidth;
                }

                txtTalentDescription.Size = szTDesc;
                txtTalentSpecial.Size = szTSpec;

                btnSelectTalent.Enabled = true;
            }
        }
        #endregion

      


    }
}
