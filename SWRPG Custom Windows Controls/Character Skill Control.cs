using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWRPG_Custom_Windows_Controls
{
    public partial class CharacterSkillControl: UserControl
    {
        #region Public Member
        /// <summary>
        /// Here i have create two property for geting  value of selected item of comboBox
        /// and geting text of selected item of comboBox.
        /// cmbState is a name of combobox.
        /// its neccesary property its used when you use this control 
        /// in your form.
        /// </summary>
        /// 
        public string SkillName
        {
            get { return lblSkillName.Text; }
            set { lblSkillName.Text = value; }

        }

        public string SkillTotal
        {
            get { return lblSkillTotal.Text; }
        }

        public int SkillHalfLevelValue
        {
            get {
                int intRetVal = 0;
                int.TryParse(txtHalfLevel.Text, out intRetVal);
                return intRetVal; 
            }
            set { txtHalfLevel.Text = value.ToString(); }
        }

        public int SkillAbilityModValue
        {
            get {
                int intRetVal = 0;
                int.TryParse(txtAbilityMod.Text, out intRetVal);
                return intRetVal; }
            set { txtAbilityMod.Text = value.ToString(); }
        }

        public int SkillTrainedValue
        {
            get {
                int intRetVal = 0;
                int.TryParse(txtTrained.Text, out intRetVal);
                return intRetVal;
            }
            set { txtTrained.Text = value.ToString(); }
        }

        public int SkillFocusValue
        {
            get {
                int intRetVal = 0;
                int.TryParse(txtSkillFocus.Text, out intRetVal);
                return intRetVal; }
            set { txtSkillFocus.Text = value.ToString(); }
        }

        public int SkillMiscellaneousValue
        {
            get {
                int intRetVal = 0;
                int.TryParse(txtMiscellaneous.Text, out intRetVal);
                return intRetVal;
            }
            set { txtMiscellaneous.Text = value.ToString(); }
        }

        public int SkillFeatTalentValue
        {
            get {
                int intRetVal = 0;
                int.TryParse(txtSkillFeatTalentBonus.Text, out intRetVal);
                return intRetVal;
            }
            set { txtSkillFeatTalentBonus.Text = value.ToString(); }
        }
        #endregion


        #region Constuctors
        public CharacterSkillControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(CharacterSkillControl_Load);
            //this.cmbState.SelectedIndexChanged += new EventHandler(cmbState_SelectedIndexChanged);

        }
        #endregion



        #region User Control Event

        private void CharacterSkillControl_Load(object sender, EventArgs e)
        {
            //TODO anything needed here
        }

        #endregion

        #region Public Methods
        public void ResetControl()
        {
            this.lblSkillName.Text = "";
            this.lblSkillTotal.Text = "0";
            this.txtTrained.Text = "0";
            this.txtHalfLevel.Text = "0";
            this.txtAbilityMod.Text = "0";
            this.txtTrained.Text = "0";
            this.txtSkillFocus.Text = "0";
            this.txtMiscellaneous.Text = "0";
            this.txtSkillFeatTalentBonus.Text = "0";
        }
        #endregion

        #region Private Methods

        private void UpdateTotal()
        {
            int intSkillTotal = 0;
            int SkillHalfLevelValue = 0;
            int SkillAbilityModValue = 0;
            int SkillTrainedValue = 0;
            int SkillFocusValue = 0;
            int SkillMiscellaneousValue = 0;
            int SkillFeatTalentValue = 0;

            int.TryParse(this.txtHalfLevel.Text, out SkillHalfLevelValue);
            int.TryParse(this.txtAbilityMod.Text, out SkillAbilityModValue);
            int.TryParse(this.txtTrained.Text, out SkillTrainedValue);
            int.TryParse(this.txtSkillFocus.Text, out SkillFocusValue);
            int.TryParse(this.txtMiscellaneous.Text, out SkillMiscellaneousValue);
            int.TryParse(this.txtSkillFeatTalentBonus.Text, out SkillFeatTalentValue);

            intSkillTotal = SkillHalfLevelValue + SkillAbilityModValue + SkillTrainedValue + SkillFocusValue + SkillMiscellaneousValue + SkillFeatTalentValue;
            lblSkillTotal.Text = intSkillTotal.ToString();
        }
        #endregion

        #region Private Control Events
        private void txtMiscellaneous_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void txtSkillFocus_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void txtTrained_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void txtAbilityMod_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void txtHalfLevel_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void txtSkillFeatTalentBonus_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void NumericValuesOnly(KeyPressEventArgs e)
        {
            char emptyChar;
            char.TryParse(string.Empty, out emptyChar);


            if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 8)
            {
                e.KeyChar = (Microsoft.VisualBasic.Strings.Chr(8));
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = emptyChar;
            }
        }
        #endregion

        private void txtMiscellaneous_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumericValuesOnly(e);
        }
    }
}
