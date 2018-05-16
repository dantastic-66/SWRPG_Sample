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
    public partial class frmArmor : Form
    {

        #region Constructors   
        
        public frmArmor()
        {
            InitializeComponent();
            FillDropDownLists();
        }

        public frmArmor(int ArmorID)
        {
            InitializeComponent();
            FillDropDownLists();
            FillFormWithArmor(ArmorID);
        }

        #endregion

        List<ArmorType> armorTypes = new List<ArmorType>();
        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();

        private bool isDirty = false;
        public static int intSearchID = 0;

        #region Form Events
        private void cmbArmorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            Form searchForm = new frmSearch(Common.searchType.Armor ,this );

            DialogResult result = new DialogResult();
            result = searchForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (intSearchID != 0)
                {
                    FillFormWithArmor(intSearchID);
                    this.btnSave.Enabled = true;
                    isDirty = true;
                }
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Armor armor = new Armor();
            SetForm(armor, true);
            this.btnSave.Enabled = true;
            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            isDirty = true;
        }

        private void txtArmorDescription_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void txtArmorName_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Armor armor = FillObjectWithForm();
            if (armor.Validate())
            {
                try
                {
                    armor.SaveArmor();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    MessageBox.Show("The Armor was saved Successfully", "Saved Successfully", MessageBoxButtons.OK);
                    FillDropDownLists();
                    this.cmbArmorType.SelectedItem = armor.objArmorType.ArmorTypeName;
                }
            }
            else
            {
                MessageBox.Show(armor.ValidationMessage, "Armor is not valid!", MessageBoxButtons.OK);
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

        private void txtRefelxAdj_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtFortitudeAdj_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }
        
        private void txtRefelxAdj_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }

        private void txtFortitudeAdj_TextChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
            isDirty = true;
        }        
        #endregion

        #region Methods
        public void FillDropDownLists()
        {
            cmbArmorType.Items.Clear();

            ArmorType armorType = new ArmorType();

            armorTypes = armorType.GetArmorTypes("", "ArmorTypeName");
            cmbArmorType.Items.Add("");
            foreach (ArmorType lstArmorType in armorTypes)
            {
                cmbArmorType.Items.Add(lstArmorType.ArmorTypeName );
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        public void FillFormWithArmor (int armorID)
        {
            Armor armor = new Armor();

            armor.GetArmor(armorID);
            
            if (armor.ArmorID  != 0)
            {
                SetForm(armor, false);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
            this.btnSave.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
        }

        public void FillFormWithArmor(string  armorName)
        {
            Armor armor = new Armor();

            armor.GetArmor (armorName);

            if (armor.ArmorID != 0)
            {
                SetForm(armor, false);
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        private Armor FillObjectWithForm()
        {
            Armor armor = new Armor();
            int armorID = 0;
            int armorTypeID = 0;
            int FortitudeAdj = 0;
            int ReflexAdj = 0;

            int.TryParse(this.txtArmorID.Text, out armorID);
            int.TryParse(this.txtFortitudeAdj.Text.ToString(), out FortitudeAdj);
            int.TryParse(this.txtRefelxAdj.Text.ToString(), out ReflexAdj);

            if (cmbArmorType.SelectedText != "")
            {
                ArmorType at = new ArmorType();
                at.GetArmorType (cmbArmorType.SelectedText);
                armorTypeID = at.ArmorTypeID ;

            }

            armor.ArmorID = armorID;
            armor.ArmorDescription = this.txtArmorDescription.Text;
            armor.ArmorName = this.txtArmorName.Text;
            armor.ArmorTypeID = armorTypeID;
            armor.FortitudeAdjustment = FortitudeAdj;
            armor.ReflexAdjustment  = ReflexAdj;

            return armor;
        }

        private void SetForm(Armor armor, bool clearForm)
        {
            try
            {
                if (clearForm)
                {
                    this.txtArmorID.Text = "";
                    this.txtArmorDescription.Text = "";
                    this.txtArmorName.Text = "";
                    this.txtFortitudeAdj.Text = "";
                    this.txtRefelxAdj.Text = "";
                    this.cmbArmorType.SelectedItem = "";
                }
                else
                {
                    this.txtArmorID.Text = armor.ArmorID.ToString();
                    this.txtArmorDescription.Text = armor.ArmorDescription.ToString();
                    this.txtArmorName.Text = armor.ArmorName.ToString();
                    this.txtFortitudeAdj.Text = armor.FortitudeAdjustment.ToString();
                    this.txtRefelxAdj.Text = armor.ReflexAdjustment.ToString();
                    this.cmbArmorType.SelectedItem = armor.objArmorType.ArmorTypeName.ToString();
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
