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
    public partial class frmSkill : Form
    {
        #region Constructors   
        
        public frmSkill()
        {
            InitializeComponent();
            //LoadClbSubSkill();
        }

        public frmSkill(int EquipmentID)
        {
            InitializeComponent();
            FillFormWithSkill(EquipmentID);
        }
        #endregion

        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        private bool isDirty = false;
        public static int intSearchID = 0;

        #region Form Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form searchForm = new frmSearch(Common.searchType.Skill , this);

            //intSearchID = 0;
            DialogResult result = new DialogResult();
            result = searchForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (intSearchID != 0)
                {
                    FillFormWithSkill(intSearchID);
                    this.btnSave.Enabled = true;
                    //this.clbSubSkills.Enabled = true;
                    isDirty = true;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Skill skill = new Skill();
            SetForm(skill, true);
            this.btnSave.Enabled = true;
            //this.clbSubSkills.Enabled = true;
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            isDirty = true;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Skill skill = FillObjectWithForm();
            if (skill.Validate())
            {
                try
                {
                    skill.SaveSkill();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    MessageBox.Show("The Skill was saved Successfully", "Saved Successfully", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(skill.ValidationMessage, "Skill is not valid!", MessageBoxButtons.OK);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
            this.btnSave.Enabled = false;
            //this.clbSubSkills.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = false;
        }

        private void txtSkillName_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            //this.clbSubSkills.Enabled = true;
            isDirty = true;
        }

        private void txtSkillDescription_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            //this.clbSubSkills.Enabled = true;
            isDirty = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            //this.clbSubSkills.Enabled = true;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = false;
        }

        private void btnAddSubSkill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do something here.");
        }
        #endregion

        #region Methods
        public void FillFormWithSkill(int SkillID)
        {
            Skill skill = new Skill();

            skill.GetSkill (SkillID);

            if (skill.SkillID  != 0)
            {
                SetForm(skill, false);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }

            //
            foreach (SubSkill objSubSkill in skill.SubSkills )
            {
                //foreach (clbSubSkills.Item clbItem in clbSubSkills.Items)
                //{
                //    CheckedListBox.CheckedItemCollection 
                //}
            }

            this.btnSave.Enabled = false;
            this.btnAddSubSkill.Enabled = true;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
        }

        private Skill FillObjectWithForm()
        {
            Skill skill = new Skill();
            int skillD = 0;
            //decimal skillWeight = 0;

            int.TryParse(this.txtFeatID.Text, out skillD);
            

            skill.SkillID  = skillD;
            skill.SkillName  = this.txtSkillName.Text;
            skill.SkillDescription = this.txtSkillDescription.Text; ;
            //skill.EquipmentDescription = this.txtEquipmentDescription.Text;

            return skill;
        }

        private void SetForm(Skill skill, bool clearForm)
        {
            try
            {
                if (clearForm)
                {
                    this.txtFeatID.Text = "";
                    this.txtSkillDescription.Text = "";
                    this.txtSkillName.Text = "";

                }
                else
                {
                    this.txtFeatID.Text = skill.SkillID.ToString();
                    this.txtSkillDescription.Text = skill.SkillDescription.ToString();
                    this.txtSkillName.Text = skill.SkillName.ToString();
                    LoadClbSubSkill(" SkillID=" + skill.SkillID.ToString());
                }
            }
            catch
            {
                Exception e = new Exception();
                throw e;
            }
        }

        private void LoadClbSubSkill(string strWhere)
        {
            SubSkill subSkill = new SubSkill();
            //List<SubSkill> subSkills  = new List<SubSkill>();
            List<SubSkill> activeSubSkills = new List<SubSkill>();

            //subSkills = subSkill.GetSubSkills("", " SubSkillName ");
            activeSubSkills = subSkill.GetSubSkills(strWhere, " SubSkillName ");

            this.lvSubSkills.Columns.Add("ID");
            this.lvSubSkills.Columns.Add("Skill Name");
            this.lvSubSkills.Columns.Add("Skill Description");
            foreach (SubSkill objSubSkill in activeSubSkills)
            {
                //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                ListViewItem lvItem = Common.CreateListViewItem(objSubSkill.SkillID, objSubSkill.SubSkillName,objSubSkill.SubSkillDescription , true);
                this.lvSubSkills.Items.Add(lvItem);
            }
            Common.FormatListViewControlColumns(lvSubSkills);

            //foreach (SubSkill objSubSkill in subSkills)
            //{
            //    clbSubSkills.Items.Add(objSubSkill.SubSkillName );
            //}
            //CheckedListBox.CheckedItemCollection cilsubSkills;  // = CheckedListBox.CheckedItemCollection();

            //foreach (SubSkill objActiveSubSkills in activeSubSkills)
            //{
            //    //for (int i = 0; i < lvSearchResults.Columns.Count; i++)
            //    for (int i = 0; i < clbSubSkills.Items.Count ; i++)
            //    {
            //        if (clbSubSkills.Items[i].ToString() == objActiveSubSkills.SubSkillName )
            //        {
            //            clbSubSkills.SelectedValue = objActiveSubSkills.SubSkillName;
            //            //clbSubSkills. = clbSubSkills.Items[i].ToString();
                        
            //        }
            //    }
            //}

            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }
        #endregion


    }
}
