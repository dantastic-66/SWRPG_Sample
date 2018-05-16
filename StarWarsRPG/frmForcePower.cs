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
    public partial class frmForcePower : Form
    {

        #region Constructors   
        public frmForcePower()
        {
            InitializeComponent();
            FillDropDownLists();
        }

        public frmForcePower(int ForcePowerID)
        {
            InitializeComponent();
            FillDropDownLists();
            FillFormWithForcePower(ForcePowerID);
        }
        #endregion
        List<ForcePowerDescriptor> forcePowerDescriptor = new List<ForcePowerDescriptor>();
        List<TurnSegment> turnSegment = new List<TurnSegment>();
        
        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        private bool isDirty = false;
        public static int intSearchID = 0;

        #region Form Events
        private void cmbForcePowerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void cmbTurnSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            Form searchForm = new frmSearch(Common.searchType.ForcePower, this);

            DialogResult result = new DialogResult();
            result = searchForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (intSearchID != 0)
                {
                    FillFormWithForcePower(intSearchID);
                    this.btnSave.Enabled = true;
                    isDirty = true;
                }
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ForcePower ForcePower = new ForcePower();
            SetForm(ForcePower, true);
            this.btnSave.Enabled = true;
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            isDirty = true;
        }

        private void txtForcePowerDescription_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void txtForcePowerName_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            ForcePower ForcePower = FillObjectWithForm();
            if (ForcePower.Validate())
            {
                try
                {
                    ForcePower.SaveForcePower();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    MessageBox.Show("Reload does not work.  ");  //TODO: Mulitple descriptors now, this needs to be looked at.
                    //MessageBox.Show("The ForcePower was saved Successfully", "Saved Successfully", MessageBoxButtons.OK);
                    //FillDropDownLists();
                    //this.cmbForcePowerDescriptorType.SelectedItem = ForcePower.objForcePowerDescriptor.ForcePowerDescriptorName;
                    
                    
                }
            }
            else
            {
                MessageBox.Show(ForcePower.ValidationMessage, "ForcePower is not valid!", MessageBoxButtons.OK);
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
        #endregion

        #region Methods
        public void FillDropDownLists()
        {
            cmbForcePowerDescriptorType.Items.Clear();

            ForcePowerDescriptor FPD = new ForcePowerDescriptor();

            forcePowerDescriptor = FPD.GetForcePowerDescriptors("", "ForcePowerDescriptorName");
            cmbForcePowerDescriptorType.Items.Add("");
            foreach (ForcePowerDescriptor lstFPD in forcePowerDescriptor)
            {
                //cmbForcePowerDescriptorType.ValueMember = "'ForcePowerDescriptorID";
                //cmbForcePowerDescriptorType.DisplayMember = "ForcePowerDescriptorName";
                //cmbForcePowerDescriptorType.DataSource = forcePowerDescriptor;
                cmbForcePowerDescriptorType.Items.Add(lstFPD.ForcePowerDescriptorName);

            }
           
            this.cmbTurnSegment.Items.Clear();

            TurnSegment turnSeg = new TurnSegment();

            turnSegment = turnSeg.GetTurnSegments ("", "TurnSegmentDescription");
            cmbTurnSegment.Items.Add("");
            foreach (TurnSegment lstTurnSegment in turnSegment)
            {
                cmbTurnSegment.Items.Add(lstTurnSegment.TurnSegmentDescription );
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        public void FillFormWithForcePower(int ForcePowerID)
        {
            ForcePower ForcePower = new ForcePower();

            ForcePower.GetForcePower(ForcePowerID);

            if (ForcePower.ForcePowerID != 0)
            {
                SetForm(ForcePower, false);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
            this.btnSave.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
        }

        private ForcePower FillObjectWithForm()
        {
            ForcePower ForcePower = new ForcePower();
            int ForcePowerID = 0;
            int ForcePowerDescriptorID = 0;
            int TurnSegmentID = 0;
           

            int.TryParse(this.txtForcePowerID.Text, out ForcePowerID);
            //int.TryParse(this.cmbForcePowerDescriptorType.SelectedIndex.ToString(), out ForcePowerDescriptorID);
            if (cmbForcePowerDescriptorType.SelectedText != "")
            {
                ForcePowerDescriptor fpd = new ForcePowerDescriptor();
                fpd.GetForcePowerDescriptor(cmbForcePowerDescriptorType.SelectedText);
                ForcePowerDescriptorID = fpd.ForcePowerDescriptorID;

            }

            //int.TryParse(this.cmbTurnSegment.SelectedIndex.ToString(), out TurnSegment);
            if (cmbTurnSegment.SelectedText != "")
            {
                TurnSegment ts = new TurnSegment();
                ts.GetTurnSegment(cmbTurnSegment.SelectedText);
                TurnSegmentID = ts.TurnSegmentID;

            }

            ForcePower.ForcePowerID = ForcePowerID;
            ForcePower.ForcePowerDescription = this.txtForcePowerDescription.Text;
            ForcePower.ForcePowerName = this.txtForcePowerName.Text;
            ForcePower.TurnSegmentID = TurnSegmentID;
            //ForcePower.ForcePowerDescriptorID = ForcePowerDescriptorID; 

            return ForcePower;
        }

        private void SetForm(ForcePower ForcePower, bool clearForm)
        {
            try
            {
                if (clearForm)
                {
                    this.txtForcePowerID.Text = "";
                    this.txtForcePowerDescription.Text = "";
                    this.txtForcePowerName.Text = "";
                    this.cmbTurnSegment.SelectedItem = "";
                    this.cmbForcePowerDescriptorType.SelectedItem = "";
                }
                else
                {
                    this.txtForcePowerID.Text = ForcePower.ForcePowerID.ToString();
                    this.txtForcePowerDescription.Text = ForcePower.ForcePowerDescription.ToString();
                    this.txtForcePowerName.Text = ForcePower.ForcePowerName.ToString();
                    
                    if (!(ForcePower.TurnSegmentID  == 0))
                    {
                        this.cmbTurnSegment.SelectedItem = ForcePower.objTurnSegment.TurnSegmentDescription;
                    }
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
