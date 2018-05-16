using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dice;
using CharacterGenerator;

namespace StarWarsRPG
{
    public partial class frmCharacterGeneratorLOCAL : Form
    {
        Dictionary<int, string> dicAbilities = new Dictionary<int, string>();
        bool Set1 = true;
        bool Set2 = true;
        bool Set3 = true;
        bool Set4 = true;
        bool ReRoll1s = false;

        #region Constructors
        public frmCharacterGeneratorLOCAL()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events
        private void frmCharacterGenerator_Load(object sender, EventArgs e)
        {
            dicAbilities.Add(1, "Strength");
            dicAbilities.Add(2, "Intelligence");
            dicAbilities.Add(3, "Wisdom");
            dicAbilities.Add(4, "Dexterity");
            dicAbilities.Add(5, "Constitution");
            dicAbilities.Add(6, "Charisma");

            FillComboBoxes(ref cmbAbility1, "", false);
            FillComboBoxes(ref cmbAbility2, "", false);
            FillComboBoxes(ref cmbAbility3, "", false);
            FillComboBoxes(ref cmbAbility4, "", false);
            FillComboBoxes(ref cmbAbility5, "", false);
            FillComboBoxes(ref cmbAbility6, "", false);

        }

        private void btnReroll1_Click(object sender, EventArgs e)
        {
            Die DieTemp = new Die(6);
            this.txtValue1.Text = DieTemp.GenerateRandomNumber().ToString();
            DisableReRollButtons();
            CalculateTotal();
        }

        private void btnReroll2_Click(object sender, EventArgs e)
        {
            Die DieTemp = new Die(6);
            this.txtValue2.Text = DieTemp.GenerateRandomNumber().ToString();
            DisableReRollButtons();
            CalculateTotal();
        }

        private void btnReroll3_Click(object sender, EventArgs e)
        {
            Die DieTemp = new Die(6);
            this.txtValue3.Text = DieTemp.GenerateRandomNumber().ToString();
            DisableReRollButtons();
            CalculateTotal();
        }

        private void btnReroll4_Click(object sender, EventArgs e)
        {
            Die DieTemp = new Die(6);
            this.txtValue4.Text = DieTemp.GenerateRandomNumber().ToString();
            DisableReRollButtons();
            CalculateTotal();
        }

        private void btnGenerateValues_Click(object sender, EventArgs e)
        {
            //Die Die1 = new Die(6);
            //this.txtValue1.Text = Die1.GenerateRandomNumber().ToString();
            //Die1.Dispose(true);
            //Die1 = null;
            Set1 = true;
            Set2 = true;
            Set3 = true;
            Set4 = true;
           
            tmrDieDelay.Enabled = true;

            //this.txtValue1.Text = GetRandomDie(6).ToString();
            //btnGenerateValue1_Click(sender, e);


            //Die Die2 = new Die( );
            //Die2.DieType = 6;
            //this.txtValue2.Text = Die2.GenerateRandomNumber().ToString();
            //Die2.Dispose(true);
            //Die2 = null;
            //this.txtValue2.Text = GetRandomDie(6).ToString();
            //btnGenerateValue2_Click(sender, e);

            //Die Die3 = new Die(6);
            //this.txtValue3.Text = Die3.GenerateRandomNumber().ToString();
            //Die3.Dispose(true);
            //Die3 = null;
            //this.txtValue3.Text = GetRandomDie(6).ToString();
            //btnGenerateValue3_Click(sender, e);

            //Die Die4 = new Die();
            //Die4.DieType = 6;
            //this.txtValue4.Text = Die4.GenerateRandomNumber().ToString();
            //Die4.Dispose(true);
            //Die4 = null;
            //this.txtValue4.Text = GetRandomDie(6).ToString();
            //btnGenerateValue4_Click(sender, e);

            //CalculateTotal();
            //EnableRerollButtons();
            //this.btnGenerateValues.Enabled = false;
            //this.btnSaveNReset.Enabled = true;

        }

        private void btnSaveNReset_Click(object sender, EventArgs e)
        {
            //Saves scrore to open box
            if (txtAbility1.Text == "")
            {
                txtAbility1.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
                //txtTotalValue.Text = "";
                //this.btnGenerateValues.Enabled = true;
            }
            else if (txtAbility2.Text == "")
            {
                txtAbility2.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
                //txtTotalValue.Text = "";
                //this.btnGenerateValues.Enabled = true;
            }
            else if (txtAbility3.Text == "")
            {
                txtAbility3.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
                //txtTotalValue.Text = "";
                //this.btnGenerateValues.Enabled = true;
            }
            else if (txtAbility4.Text == "")
            {
                txtAbility4.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
                //txtTotalValue.Text = "";
                //this.btnGenerateValues.Enabled = true;
            }
            else if (txtAbility5.Text == "")
            {
                txtAbility5.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
                //txtTotalValue.Text = "";
                //this.btnGenerateValues.Enabled = true;
            }
            else if (txtAbility6.Text == "")
            {
                txtAbility6.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
                //txtTotalValue.Text = "";
                //this.btnGenerateValues.Enabled = true;
            }
            this.btnGenerateValues.Enabled = true;
            this.btnSaveNReset.Enabled = false;

            if ((txtAbility1.Text != "") && (txtAbility2.Text != "") && (txtAbility3.Text != "") && (txtAbility4.Text != "") && (txtAbility5.Text != "") && (txtAbility6.Text != ""))
            {
                this.btnGenerateValues.Enabled = false;
                this.btnViewStats.Enabled = true;
                this.btnCommitStats.Enabled = true;
                EnableAbilityCombos(true);
            }

            DisableReRollButtons();
        }

        private void cmbAbility1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected index of the first  combo box
            //removed the ability selected in box 1 from the next combo box
            //if the selected index of cmb 2 doesn't equall the selected index of 1 then set it.
            string strSelectedAbility1;

            if (cmbAbility1.SelectedItem == null)
            {
                strSelectedAbility1 = "";
            }
            else
            {
                strSelectedAbility1 = cmbAbility1.SelectedItem.ToString();
            }


            if (strSelectedAbility1 == "")
            {
                //FillComboBoxes(ref cmbAbility1, Common.Ablilities.Charisma, false);
                FillComboBoxes(ref cmbAbility2, "", false);
                FillComboBoxes(ref cmbAbility3, "", false);
                FillComboBoxes(ref cmbAbility4, "", false);
                FillComboBoxes(ref cmbAbility5, "", false);
                FillComboBoxes(ref cmbAbility6, "", false);
            }
            else
            {
                ResetComboBox(ref cmbAbility2, strSelectedAbility1, true);

                ResetComboBox(ref cmbAbility3, strSelectedAbility1, true);

                ResetComboBox(ref cmbAbility4, strSelectedAbility1, true);

                ResetComboBox(ref cmbAbility5, strSelectedAbility1, true);

                ResetComboBox(ref cmbAbility6, strSelectedAbility1, true);

                RemovePreviousComboBoxStats(cmbAbility2, true, true, true, true);
                RemovePreviousComboBoxStats(cmbAbility3, false, true, true, true);
                RemovePreviousComboBoxStats(cmbAbility4, false, false, true, true);
                RemovePreviousComboBoxStats(cmbAbility5, false, false, false, true);

                //Check to see if the other fields are selected and remove the selectied Items from the next drop downs
                //string strSelectedAbility2;
                //if (cmbAbility2.SelectedItem == null)
                //{
                //    strSelectedAbility2 = "";
                //}
                //else
                //{
                //    strSelectedAbility2 = cmbAbility2.SelectedItem.ToString();
                //}
                
                //if (strSelectedAbility2 != "")
                //{
                //    cmbAbility3.Items.Remove(strSelectedAbility2);
                //    cmbAbility4.Items.Remove(strSelectedAbility2);
                //    cmbAbility5.Items.Remove(strSelectedAbility2);
                //    cmbAbility6.Items.Remove(strSelectedAbility2);
                //}
            }

        }

        private void cmbAbility2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelectedAbility1;
            string strSelectedAbility2;

            if (cmbAbility1.SelectedItem == null)
            {
                strSelectedAbility1 = "";
            }
            else
            {
                strSelectedAbility1 = cmbAbility1.SelectedItem.ToString();
            }

            if (cmbAbility2.SelectedItem == null)
            {
                strSelectedAbility2 = "";
            }
            else
            {
                strSelectedAbility2 = cmbAbility2.SelectedItem.ToString();
            }

            if (strSelectedAbility2 == "")
            {
                FillComboBoxes(ref cmbAbility3, "", false);
                FillComboBoxes(ref cmbAbility4, "", false);
                FillComboBoxes(ref cmbAbility5, "", false);
                FillComboBoxes(ref cmbAbility6, "", false);
            }
            else
            {
                ResetComboBox(ref cmbAbility3, strSelectedAbility2, true);
                RemoveComboBoxEntry(ref cmbAbility3, strSelectedAbility1);

                ResetComboBox(ref cmbAbility4, strSelectedAbility2, true);
                RemoveComboBoxEntry(ref cmbAbility4, strSelectedAbility1);

                ResetComboBox(ref cmbAbility5, strSelectedAbility2, true);
                RemoveComboBoxEntry(ref cmbAbility5, strSelectedAbility1);

                ResetComboBox(ref cmbAbility6, strSelectedAbility2, true);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility1);

                //RemovePreviousComboBoxStats(cmbAbility2, true, true, true, true);
                RemovePreviousComboBoxStats(cmbAbility3, false, true, true, true);
                RemovePreviousComboBoxStats(cmbAbility4, false, false, true, true);
                RemovePreviousComboBoxStats(cmbAbility5, false, false, false, true);
            }
        }

        private void cmbAbility3_SelectedIndexChanged(object sender, EventArgs e)
        {

            string strSelectedAbility1;
            string strSelectedAbility2;
            string strSelectedAbility3;

            if (cmbAbility1.SelectedItem == null)
            {
                strSelectedAbility1 = "";
            }
            else
            {
                strSelectedAbility1 = cmbAbility1.SelectedItem.ToString();
            }

            if (cmbAbility2.SelectedItem == null)
            {
                strSelectedAbility2 = "";
            }
            else
            {
                strSelectedAbility2 = cmbAbility2.SelectedItem.ToString();
            }

            if (cmbAbility3.SelectedItem == null)
            {
                strSelectedAbility3 = "";
            }
            else
            {
                strSelectedAbility3 = cmbAbility3.SelectedItem.ToString();
            }


            if (strSelectedAbility3 == "")
            {
                FillComboBoxes(ref cmbAbility4, "", false);
                FillComboBoxes(ref cmbAbility5, "", false);
                FillComboBoxes(ref cmbAbility6, "", false);
            }
            else
            {
                ResetComboBox(ref cmbAbility4, strSelectedAbility3, true);
                RemoveComboBoxEntry(ref cmbAbility4, strSelectedAbility1);
                RemoveComboBoxEntry(ref cmbAbility4, strSelectedAbility2);

                ResetComboBox(ref cmbAbility5, strSelectedAbility3, true);
                RemoveComboBoxEntry(ref cmbAbility5, strSelectedAbility1);
                RemoveComboBoxEntry(ref cmbAbility5, strSelectedAbility2);

                ResetComboBox(ref cmbAbility6, strSelectedAbility3, true);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility1);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility2);

                //RemovePreviousComboBoxStats(cmbAbility2, true, true, true, true);
                //RemovePreviousComboBoxStats(cmbAbility3, false, true, true, true);
                RemovePreviousComboBoxStats(cmbAbility4, false, false, true, true);
                RemovePreviousComboBoxStats(cmbAbility5, false, false, false, true);
            }
        }

        private void cmbAbility4_SelectedIndexChanged(object sender, EventArgs e)
        {

            string strSelectedAbility1;
            string strSelectedAbility2;
            string strSelectedAbility3;
            string strSelectedAbility4;

            if (cmbAbility1.SelectedItem == null)
            {
                strSelectedAbility1 = "";
            }
            else
            {
                strSelectedAbility1 = cmbAbility1.SelectedItem.ToString();
            }

            if (cmbAbility2.SelectedItem == null)
            {
                strSelectedAbility2 = "";
            }
            else
            {
                strSelectedAbility2 = cmbAbility2.SelectedItem.ToString();
            }

            if (cmbAbility3.SelectedItem == null)
            {
                strSelectedAbility3 = "";
            }
            else
            {
                strSelectedAbility3 = cmbAbility3.SelectedItem.ToString();
            }

            if (cmbAbility4.SelectedItem == null)
            {
                strSelectedAbility4 = "";
            }
            else
            {
                strSelectedAbility4 = cmbAbility4.SelectedItem.ToString();
            }


            if (strSelectedAbility4 == "")
            {
                FillComboBoxes(ref cmbAbility5, "", false);
                FillComboBoxes(ref cmbAbility6, "", false);
            }
            else
            {
                ResetComboBox(ref cmbAbility5, strSelectedAbility4, true);
                RemoveComboBoxEntry(ref cmbAbility5, strSelectedAbility1);
                RemoveComboBoxEntry(ref cmbAbility5, strSelectedAbility2);
                RemoveComboBoxEntry(ref cmbAbility5, strSelectedAbility3);

                ResetComboBox(ref cmbAbility6, strSelectedAbility4, true);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility1);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility2);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility3);

                //RemovePreviousComboBoxStats(cmbAbility2, true, true, true, true);
                //RemovePreviousComboBoxStats(cmbAbility3, false, true, true, true);
                //RemovePreviousComboBoxStats(cmbAbility4, false, false, true, true);
                RemovePreviousComboBoxStats(cmbAbility5, false, false, false, true);
            }
        }

        private void cmbAbility5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelectedAbility1;
            string strSelectedAbility2;
            string strSelectedAbility3;
            string strSelectedAbility4;
            string strSelectedAbility5;

            if (cmbAbility1.SelectedItem == null)
            {
                strSelectedAbility1 = "";
            }
            else
            {
                strSelectedAbility1 = cmbAbility1.SelectedItem.ToString();
            }

            if (cmbAbility2.SelectedItem == null)
            {
                strSelectedAbility2 = "";
            }
            else
            {
                strSelectedAbility2 = cmbAbility2.SelectedItem.ToString();
            }

            if (cmbAbility3.SelectedItem == null)
            {
                strSelectedAbility3 = "";
            }
            else
            {
                strSelectedAbility3 = cmbAbility3.SelectedItem.ToString();
            }

            if (cmbAbility4.SelectedItem == null)
            {
                strSelectedAbility4 = "";
            }
            else
            {
                strSelectedAbility4 = cmbAbility4.SelectedItem.ToString();
            }

            if (cmbAbility5.SelectedItem == null)
            {
                strSelectedAbility5 = "";
            }
            else
            {
                strSelectedAbility5 = cmbAbility5.SelectedItem.ToString();
            }

            if (strSelectedAbility5 == "")
            {
                FillComboBoxes(ref cmbAbility6, "", false);
            }
            else
            {
                ResetComboBox(ref cmbAbility6, strSelectedAbility5, true);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility1);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility2);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility3);
                RemoveComboBoxEntry(ref cmbAbility6, strSelectedAbility4);

                //RemovePreviousComboBoxStats(cmbAbility2, true, true, true, true);
                //RemovePreviousComboBoxStats(cmbAbility3, false, true, true, true);
                //RemovePreviousComboBoxStats(cmbAbility4, false, false, true, true);
                //RemovePreviousComboBoxStats(cmbAbility5, false, false, false, true);
            }
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            if ((cmbAbility1.SelectedItem != null) && (cmbAbility2.SelectedItem != null) && (cmbAbility3.SelectedItem != null) && (cmbAbility4.SelectedItem != null) && (cmbAbility5.SelectedItem != null) && (cmbAbility6.SelectedItem != null))
            {
                string strSelectedAbility1 = cmbAbility1.SelectedItem.ToString();
                string strSelectedAbility2 = cmbAbility2.SelectedItem.ToString();
                string strSelectedAbility3 = cmbAbility3.SelectedItem.ToString();
                string strSelectedAbility4 = cmbAbility4.SelectedItem.ToString();
                string strSelectedAbility5 = cmbAbility5.SelectedItem.ToString();
                string strSelectedAbility6 = cmbAbility6.SelectedItem.ToString();

                if ((strSelectedAbility1 != "") && (strSelectedAbility2 != "") && (strSelectedAbility3 != "") && (strSelectedAbility4 != "") && (strSelectedAbility5 != "") && (strSelectedAbility6 != ""))
                {
                    //Good to 
                    //lblStrengthValue 
                    AssignStatToTextBox(strSelectedAbility1, txtAbility1.Text);
                    AssignStatToTextBox(strSelectedAbility2, txtAbility2.Text);
                    AssignStatToTextBox(strSelectedAbility3, txtAbility3.Text);
                    AssignStatToTextBox(strSelectedAbility4, txtAbility4.Text);
                    AssignStatToTextBox(strSelectedAbility5, txtAbility5.Text);
                    AssignStatToTextBox(strSelectedAbility6, txtAbility6.Text);

                }
            }
        }

        private void btnCommitStats_Click(object sender, EventArgs e)
        {
            if ((cmbAbility1.SelectedItem != null) && (cmbAbility2.SelectedItem != null) && (cmbAbility3.SelectedItem != null) && (cmbAbility4.SelectedItem != null) && (cmbAbility5.SelectedItem != null) && (cmbAbility6.SelectedItem != null))
            {
                string strSelectedAbility1 = cmbAbility1.SelectedItem.ToString();
                string strSelectedAbility2 = cmbAbility2.SelectedItem.ToString();
                string strSelectedAbility3 = cmbAbility3.SelectedItem.ToString();
                string strSelectedAbility4 = cmbAbility4.SelectedItem.ToString();
                string strSelectedAbility5 = cmbAbility5.SelectedItem.ToString();
                string strSelectedAbility6 = cmbAbility6.SelectedItem.ToString();

                if ((strSelectedAbility1 != "") && (strSelectedAbility2 != "") && (strSelectedAbility3 != "") && (strSelectedAbility4 != "") && (strSelectedAbility5 != "") && (strSelectedAbility6 != ""))
                {
                    AssignStatToTextBox(strSelectedAbility1, txtAbility1.Text);
                    AssignStatToTextBox(strSelectedAbility2, txtAbility2.Text);
                    AssignStatToTextBox(strSelectedAbility3, txtAbility3.Text);
                    AssignStatToTextBox(strSelectedAbility4, txtAbility4.Text);
                    AssignStatToTextBox(strSelectedAbility5, txtAbility5.Text);
                    AssignStatToTextBox(strSelectedAbility6, txtAbility6.Text);
                    
                    CharacterScores newCharScores = new CharacterScores();
                    //newCharScores.Strength = lblStrengthValue.Text;
                    //newCharScores.Intelligence = lblIntelligenceValue.Text;
                    //newCharScores.Wisdom = lblWisdomValue.Text;
                    //newCharScores.Dexterity = lblDexterityValue.Text;
                    //newCharScores.Constitution = lblConstitutionValue.Text;
                    //newCharScores.Charisma = lblCharismaValue.Text;
                }
                btnViewStats.Enabled = false;
                btnCommitStats.Enabled = false;
                EnableAbilityCombos(false);
            }
        }

        private void lblStrengthValue_TextChanged(object sender, EventArgs e)
        {
            int intStrValue = 0;
            int.TryParse(lblStrengthValue.Text, out intStrValue);
            lblStrengthMod.Text = ((intStrValue - 10) / 2).ToString();
        }

        private void lblIntelligenceValue_TextChanged(object sender, EventArgs e)
        {
            int intIntValue = 0;
            int.TryParse(lblIntelligenceValue.Text, out intIntValue);
            lblIntelligenceMod.Text = ((intIntValue - 10) / 2).ToString();
        }

        private void lblWisdomValue_TextChanged(object sender, EventArgs e)
        {
            int intWisValue = 0;
            int.TryParse(lblWisdomValue.Text, out intWisValue);
            lblWisdomMod.Text = ((intWisValue - 10) / 2).ToString();
        }

        private void lblConstitutionValue_TextChanged(object sender, EventArgs e)
        {
            int intConValue = 0;
            int.TryParse(lblConstitutionValue.Text, out intConValue);
            lblConstitutionMod.Text = ((intConValue - 10) / 2).ToString();
        }

        private void lblDexterityValue_TextChanged(object sender, EventArgs e)
        {
            int intDexValue = 0;
            int.TryParse(lblDexterityValue.Text, out intDexValue);
            lblDexterityMod.Text = ((intDexValue - 10) / 2).ToString();
        }

        private void lblCharismaValue_TextChanged(object sender, EventArgs e)
        {
            int intChaValue = 0;
            int.TryParse(lblCharismaValue.Text, out intChaValue);
            lblCharismaMod.Text = ((intChaValue - 10) / 2).ToString();
        }

        private void btnGenerateValue1_Click(object sender, EventArgs e)
        {
            this.txtValue1.Text = GetRandomDie(6).ToString();
            Set1 = false;
            Set2 = true;
            Set3 = true;
            Set4 = true;
        }

        private void btnGenerateValue2_Click(object sender, EventArgs e)
        {
            this.txtValue2.Text = GetRandomDie(6).ToString();
            Set1 = false;
            Set2 = false;
            Set3 = true;
            Set4 = true;
        }

        private void btnGenerateValue3_Click(object sender, EventArgs e)
        {
            this.txtValue3.Text = GetRandomDie(6).ToString();
            Set1 = false;
            Set2 = false;
            Set3 = false;
            Set4 = true;
        }

        private void btnGenerateValue4_Click(object sender, EventArgs e)
        {
            this.txtValue4.Text = GetRandomDie(6).ToString();
            Set1 = false;
            Set2 = false;
            Set3 = false;
            Set4 = false;
        }

        private void tmrDieDelay_Tick(object sender, EventArgs e)
        {

            if (Set1)
            {
                btnGenerateValue1_Click(sender, e);
            }
            else if (Set2)
            {
                btnGenerateValue2_Click(sender, e);
            }
            else if (Set3)
            {
                btnGenerateValue3_Click(sender, e);
            }
            else if (Set4)
            {
                btnGenerateValue4_Click(sender, e);
            }
            else
            {
                CalculateTotal();
                EnableRerollButtons();
                this.btnGenerateValues.Enabled = false;
                this.btnSaveNReset.Enabled = true;
                tmrDieDelay.Enabled = false;
            }
        }
        #endregion

        #region Methods
        private void RemovePreviousComboBoxStats(ComboBox cmbAbility, bool blnRemove3, bool blnRemove4, bool blnRemove5, bool blnRemove6)
        {
            string strSelectedAbility;
            if (cmbAbility.SelectedItem == null)
            {
                strSelectedAbility = "";
            }
            else
            {
                strSelectedAbility = cmbAbility.SelectedItem.ToString();
            }

            if (strSelectedAbility != "")
            {
                if (blnRemove3) cmbAbility3.Items.Remove(strSelectedAbility);
                if (blnRemove4) cmbAbility4.Items.Remove(strSelectedAbility);
                if (blnRemove5) cmbAbility5.Items.Remove(strSelectedAbility);
                if (blnRemove6) cmbAbility6.Items.Remove(strSelectedAbility);
            }
        }
        
        private void ClearRollsAndTotal()
        {
            txtValue1.Text = "";
            txtValue2.Text = "";
            txtValue3.Text = "";
            txtValue4.Text = "";
            //txtValue5.Text = "";
            //txtValue6.Text = "";
            txtTotalValue.Text = "";
        }

        private int GetRandomDie(int size)
        {
            Die Die1 = new Die(6);
            int intReturnVal = Die1.GenerateRandomNumber();
            Die1.Dispose(true);
            Die1 = null;
            return intReturnVal;
        }

        private void EnableRerollButtons()
        {
            if (ReRoll1s)
            {
                if (this.txtValue1.Text == "1")
                {
                    this.btnReroll1.Enabled = true;
                }
                else
                {
                    this.btnReroll1.Enabled = false;
                }

                if (this.txtValue2.Text == "1")
                {
                    this.btnReroll2.Enabled = true;
                }
                else
                {
                    this.btnReroll2.Enabled = false;
                }

                if (this.txtValue3.Text == "1")
                {
                    this.btnReroll3.Enabled = true;
                }
                else
                {
                    this.btnReroll3.Enabled = false;
                }

                if (this.txtValue4.Text == "1")
                {
                    this.btnReroll4.Enabled = true;
                }
                else
                {
                    this.btnReroll4.Enabled = false;
                }
            }
        }

        private void EnableAbilityCombos(bool blnEnabledValue)
        {
            this.cmbAbility1.Enabled = blnEnabledValue;
            this.cmbAbility2.Enabled = blnEnabledValue;
            this.cmbAbility3.Enabled = blnEnabledValue;
            this.cmbAbility4.Enabled = blnEnabledValue;
            this.cmbAbility5.Enabled = blnEnabledValue;
            this.cmbAbility6.Enabled = blnEnabledValue;
        }

        private void DisableReRollButtons()
        {
            this.btnReroll1.Enabled = false;
            this.btnReroll2.Enabled = false;
            this.btnReroll3.Enabled = false;
            this.btnReroll4.Enabled = false;
        }

        private void CalculateTotal()
        {
            int Value1 = 0;
            int Value2 = 0;
            int Value3 = 0;
            int Value4 = 0;

            int.TryParse(this.txtValue1.Text, out Value1);
            int.TryParse(this.txtValue2.Text, out Value2);
            int.TryParse(this.txtValue3.Text, out Value3);
            int.TryParse(this.txtValue4.Text, out Value4);

            //char[] vowels = new char[5];
            int[] arryValues = new int[4];
            arryValues[0] = Value1;
            arryValues[1] = Value2;
            arryValues[2] = Value3;
            arryValues[3] = Value4;

            Array.Sort(arryValues);

            this.txtTotalValue.Text = (arryValues[1] + arryValues[2] + arryValues[3]).ToString();

        }

        private void FillComboBoxes(ref ComboBox cmbAbility, string strAbilityToRemove, bool blnRemove)
        {
            cmbAbility.Items.Clear();

            cmbAbility.Items.Add("");
            string strValue;
            for (int i = 1; i <= 6; i++)
            {
                if (blnRemove)
                {
                    dicAbilities.TryGetValue(i, out strValue);
                    if (strValue != strAbilityToRemove)
                    { 
                        //dicAbilities.TryGetValue (i , out strValue);
                        cmbAbility.Items.Add(strValue);
                    }
                }
                else
                {
                    dicAbilities.TryGetValue (i , out strValue);
                    cmbAbility.Items.Add(strValue);
                }
            }

        }

        private void ResetComboBox(ref ComboBox cmbAbility, string strAbilityToRemove, bool blnRemove)
        {
            string strSelectedAbility = "";
            if (cmbAbility.SelectedItem != null)
            {
                strSelectedAbility = cmbAbility.SelectedItem.ToString();
            }

            FillComboBoxes(ref cmbAbility, strAbilityToRemove, true);
            if (strSelectedAbility != strAbilityToRemove)
            {
                cmbAbility.SelectedItem = strSelectedAbility;
            }
        }

        private void RemoveComboBoxEntry (ref ComboBox cmbAbility, string strAbilityToRemove)
        {
            string strSelectedAbility = "";
            if (cmbAbility.SelectedItem != null)
            {
                strSelectedAbility = cmbAbility.SelectedItem.ToString();
            }

            cmbAbility.Items.Remove(strAbilityToRemove);
            if (strSelectedAbility == strAbilityToRemove )
            {
                cmbAbility.SelectedItem = "";
            }
            else
            {
                cmbAbility.SelectedItem = strSelectedAbility;
            }
        }

        private void AssignStatToTextBox(string strAbility, string strStat)
        {
            switch (strAbility)
            {
                case "Strength":
                    lblStrengthValue.Text = strStat;
                    break;
                case "Intelligence":
                    lblIntelligenceValue.Text = strStat;
                    break;
                case "Dexterity":
                    lblDexterityValue.Text = strStat;
                    break;
                case "Wisdom":
                    lblWisdomValue.Text = strStat;
                    break;
                case "Constitution":
                    lblConstitutionValue.Text = strStat;
                    break;
                case "Charisma":
                    lblCharismaValue.Text = strStat;
                    break;
            }
        }
        #endregion

        private void enableRerollOfOne1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableRerollOfOne1ToolStripMenuItem.Checked = !enableRerollOfOne1ToolStripMenuItem.Checked;
            ReRoll1s = enableRerollOfOne1ToolStripMenuItem.Checked;
        }

        private void resetCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtAbility1.Text = "";
            txtAbility2.Text = "";
            txtAbility3.Text = "";
            txtAbility4.Text = "";
            txtAbility5.Text = "";
            txtAbility6.Text = "";
            btnGenerateValues.Enabled = true;
            this.btnViewStats.Enabled = false;
            this.btnCommitStats.Enabled = false;
            EnableAbilityCombos(false);
        }









    }
}