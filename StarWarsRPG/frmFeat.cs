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
    public partial class frmFeat : Form
    {
         #region Constructors   
        
        public frmFeat()
        {
            InitializeComponent();
        }

        public frmFeat(int FeatID)
        {
            InitializeComponent();
            FillFormWithFeat(FeatID);
        }

        #endregion

        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        private bool isDirty = false;
        public static int intSearchID = 0;

        #region Form Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form searchForm = new frmSearch(Common.searchType.Armor, this);

            DialogResult result = new DialogResult();
            result = searchForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (intSearchID != 0)
                {
                    FillFormWithFeat(intSearchID);
                    this.btnSave.Enabled = true;
                    isDirty = true;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Feat feat = new Feat();
            SetForm(feat, true);
            this.btnSave.Enabled = true;
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            isDirty = true;
        }

        private void txtFeatDescription_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Feat feat = FillObjectWithForm();

            if (feat.Validate())
            {
                try
                {
                    feat.SaveFeat();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    MessageBox.Show("The Feat was saved Successfully", "Saved Successfully", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(feat.ValidationMessage, "Feat is not valid!", MessageBoxButtons.OK);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
            this.btnSave.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = false;
        }

        private void txtFeatName_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }
        #endregion

        #region Methods
        public void FillFormWithFeat(int FeatID)
        {
            Feat feat = new Feat();

            feat.GetFeat (FeatID);

            if (feat.FeatID != 0)
            {
                SetForm(feat, false);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
            this.btnSave.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
        }

        private Feat FillObjectWithForm()
        {
            Feat feat = new Feat();
            int featID = 0;

            int.TryParse(this.txtFeatID.Text, out featID);

            feat.FeatID = featID;
            feat.FeatName = this.txtFeatName.Text;
            feat.FeatDescription = this.txtFeatDescription.Text;

            return feat;
        }

        private void SetForm(Feat feat, bool clearForm)
        {
            try
            {
                if (clearForm)
                {
                    this.txtFeatID.Text = "";
                    this.txtFeatDescription.Text = "";
                    this.txtFeatName.Text = "";
                    //this.txtFortitudeAdj.Text = "";
                    //this.txtRefelxAdj.Text = "";
                    //this.cmbArmorType.SelectedItem = "";
                }
                else
                {
                    this.txtFeatID.Text = feat.FeatID.ToString();
                    this.txtFeatDescription.Text = feat.FeatDescription.ToString();
                    this.txtFeatName.Text = feat.FeatName.ToString();
                    //this.txtFortitudeAdj.Text = feat.FortitudeAdjustment.ToString();
                    //this.txtRefelxAdj.Text = feat.ReflexAdjustment.ToString();
                    //this.cmbArmorType.SelectedItem = feat.objArmorType.ArmorTypeName.ToString();
                    //this.cmbGenreMaint.SelectedItem = genre.GenreDescription;
                }
            }
            catch
            {
                Exception e = new Exception();
                throw e;
            }
        }
        #endregion


     }
}
