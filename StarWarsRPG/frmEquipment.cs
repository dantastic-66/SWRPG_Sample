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
    public partial class frmEquipment : Form
    {
        #region Constructors   
        
        public frmEquipment()
        {
            InitializeComponent();
        }

        public frmEquipment(int EquipmentID)
        {
            InitializeComponent();
            FillFormWithEquipment(EquipmentID);
        }

        #endregion

        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        private bool isDirty = false;
        public static int intSearchID = 0;

        #region Form Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form searchForm = new frmSearch(Common.searchType.Armor, this);

            //intSearchID = 0;
            DialogResult result = new DialogResult();
            result = searchForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (intSearchID != 0)
                {
                    FillFormWithEquipment(intSearchID);
                    this.btnSave.Enabled = true;
                    isDirty = true;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            
            SetForm(equipment, true);
            this.btnSave.Enabled = true;
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            isDirty = true;
        }

        //private void txtFeatDescription_TextChanged(object sender, EventArgs e)
        //{
        //    this.btnSave.Enabled = true;
        //    isDirty = true;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            Equipment equipment = FillObjectWithForm();
            if (equipment.Validate())
            {
                try
                {
                    equipment.SaveEquipment();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    MessageBox.Show("The Equipment was saved Successfully", "Saved Successfully", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(equipment.ValidationMessage, "Equipment is not valid!", MessageBoxButtons.OK);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
            this.btnSave.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = false;
        }

        private void txtEquipementWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtEquipmentName_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void txtEquipementWeight_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void txtEquipmentDescription_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }       
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = false;
        }        
        #endregion

        private void txtFeatName_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }
        #region Methods

        public void FillFormWithEquipment(int EquipmentID)
        {
            Equipment equipment = new Equipment();

            equipment.GetEquipment (EquipmentID);

            if (equipment.EquipmentID  != 0)
            {
                SetForm(equipment, false);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
            this.btnSave.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
        }

        private Equipment FillObjectWithForm()
        {
            Equipment equipment = new Equipment();
            int equipmentID = 0;
            decimal equipmentWeight = 0;

            int.TryParse(this.txtEquipmentID.Text, out equipmentID);
            decimal.TryParse(this.txtEquipementWeight.Text, out equipmentWeight);

            equipment.EquipmentID  = equipmentID;
            equipment.EquipmentName  = this.txtEquipmentName.Text;
            equipment.EquipmentWeight = equipmentWeight;
            equipment.EquipmentDescription = this.txtEquipmentDescription.Text;

            return equipment;
        }

        private void SetForm(Equipment equipment, bool clearForm)
        {
            try
            {
                if (clearForm)
                {
                    this.txtEquipmentID.Text = "";
                    this.txtEquipmentDescription.Text = "";
                    this.txtEquipmentName.Text = "";
                    this.txtEquipementWeight.Text = "";

                }
                else
                {
                    this.txtEquipmentID.Text = equipment.EquipmentID .ToString();
                    this.txtEquipmentDescription.Text = equipment.EquipmentDescription .ToString();
                    this.txtEquipmentName.Text = equipment.EquipmentName .ToString();
                    this.txtEquipementWeight.Text = equipment.EquipmentWeight.ToString();
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
