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
using GenericCharacterGenerator;
using CharacterGenerator;

namespace StarWarsRPG
{
    public partial class frmCharCreate1GenerateScores : Form
    {
        //public static Dictionary<int, string> dicAbilities = new Dictionary<int, string>();
        bool Set1 = true;
        bool Set2 = true;
        bool Set3 = true;
        bool Set4 = true;
        bool ReRoll1s = false;

        #region Constructor
        public frmCharCreate1GenerateScores()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events
        private void frmCharCreate1GenerateScores_Load(object sender, EventArgs e)
        {
            //dicAbilities.Add(1, "Strength");
            //dicAbilities.Add(2, "Intelligence");
            //dicAbilities.Add(3, "Wisdom");
            //dicAbilities.Add(4, "Dexterity");
            //dicAbilities.Add(5, "Constitution");
            //dicAbilities.Add(6, "Charisma");
            this.Width = 508;
        }

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
            txtValue1.Text = "";
            txtValue2.Text = "";
            txtValue3.Text = "";
            txtValue4.Text = "";
            txtTotalValue.Text = "";
            btnSaveNReset.Enabled  = false;
            btnGenerateValues.Enabled = true;
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
            Set1 = true;
            Set2 = true;
            Set3 = true;
            Set4 = true;

            tmrDieDelay.Enabled = true;
        }

        private void btnSaveNReset_Click(object sender, EventArgs e)
        {
            //Saves scrore to open box
            if (txtAbility1.Text == "")
            {
                txtAbility1.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
            }
            else if (txtAbility2.Text == "")
            {
                txtAbility2.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
            }
            else if (txtAbility3.Text == "")
            {
                txtAbility3.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
            }
            else if (txtAbility4.Text == "")
            {
                txtAbility4.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
            }
            else if (txtAbility5.Text == "")
            {
                txtAbility5.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
            }
            else if (txtAbility6.Text == "")
            {
                txtAbility6.Text = txtTotalValue.Text;
                ClearRollsAndTotal();
            }

            this.btnGenerateValues.Enabled = true;
            this.btnSaveNReset.Enabled = false;
            if ((txtAbility1.Text != "") && (txtAbility2.Text != "") && (txtAbility3.Text != "") && (txtAbility4.Text != "") && (txtAbility5.Text != "") && (txtAbility6.Text != ""))
            {
                this.btnGenerateValues.Enabled = false;
                btnAssignAbilities.Enabled = true;
            }
            DisableReRollButtons();

        }

        private void manuallyEnterScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manuallyEnterScoreToolStripMenuItem.Checked = !manuallyEnterScoreToolStripMenuItem.Checked;
            if (manuallyEnterScoreToolStripMenuItem.Checked)
            {
                EnableTextBoxesForManualInput(true, true);
                this.btnGenerateValues.Enabled = false;
                this.btnSaveNReset.Enabled = false;
                this.btnAssignAbilities.Enabled = true;

            }
            else
            {
                EnableTextBoxesForManualInput(false, true);
                this.btnGenerateValues.Enabled = true;
                this.btnSaveNReset.Enabled = false;
                this.btnAssignAbilities.Enabled = false;
            }
        }

        private void txtAbility1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtAbility6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void btnAssignAbilities_Click(object sender, EventArgs e)
        {
            this.Width = 775;

        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            bool blnNextStep = true;
            string strErrorMessage = "";

            if (txtAbility1.Text == "")
            {
                blnNextStep = false;
                strErrorMessage = strErrorMessage + "Ability 1 cannot be blank!\r\n";
            }
            if (txtAbility2.Text == "")
            {
                blnNextStep = false;
                strErrorMessage = strErrorMessage + "Ability 2 cannot be blank!\r\n";
            }
            if (txtAbility3.Text == "")
            {
                blnNextStep = false;
                strErrorMessage = strErrorMessage + "Ability 3 cannot be blank!\r\n";
            }
            if (txtAbility4.Text == "")
            {
                blnNextStep = false;
                strErrorMessage = strErrorMessage + "Ability 4 cannot be blank!\r\n";
            }
            if (txtAbility5.Text == "")
            {
                blnNextStep = false;
                strErrorMessage = strErrorMessage + "Ability 5 cannot be blank!\r\n";
            }
            if (txtAbility6.Text == "")
            {
                blnNextStep = false;
                strErrorMessage = strErrorMessage + "Ability 6 cannot be blank!\r\n";
            }

            if (!blnNextStep)
            {
                MessageBox.Show(strErrorMessage, "Ability Score Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Dictionary<int, string> dicAbilities = new Dictionary<int, string>();
                dicAbilities.Add(1, txtAbility1.Text);
                dicAbilities.Add(2, txtAbility2.Text);
                dicAbilities.Add(3, txtAbility3.Text);
                dicAbilities.Add(4, txtAbility4.Text);
                dicAbilities.Add(5, txtAbility5.Text);
                dicAbilities.Add(6, txtAbility6.Text);
                Form frmStep2GetRace = new frmCharCreate2GetRace();
                frmCharCreate2GetRace.dicAbilities = dicAbilities;
                frmStep2GetRace.ShowDialog();
                this.Close();

            }
        }     
        #endregion

        #region Methods
        public void EnableTextBoxesForManualInput(bool blnEnabled, bool blnAndClear)
        {
            //SystemColors clrTextBackColor = System.Drawing.SystemColors.ControlLight;

            if (!blnEnabled )
            {
                txtAbility1.BackColor = System.Drawing.SystemColors.Control;
                txtAbility2.BackColor = System.Drawing.SystemColors.Control;
                txtAbility3.BackColor = System.Drawing.SystemColors.Control;
                txtAbility4.BackColor = System.Drawing.SystemColors.Control;
                txtAbility5.BackColor = System.Drawing.SystemColors.Control;
                txtAbility6.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                txtAbility1.BackColor = System.Drawing.Color.White ;
                txtAbility2.BackColor = System.Drawing.Color.White;
                txtAbility3.BackColor = System.Drawing.Color.White;
                txtAbility4.BackColor = System.Drawing.Color.White;
                txtAbility5.BackColor = System.Drawing.Color.White;
                txtAbility6.BackColor = System.Drawing.Color.White;
            }

            txtAbility1.Enabled = blnEnabled;
            txtAbility2.Enabled = blnEnabled;
            txtAbility3.Enabled = blnEnabled;
            txtAbility4.Enabled = blnEnabled;
            txtAbility5.Enabled = blnEnabled;
            txtAbility6.Enabled = blnEnabled;

            txtAbility1.ReadOnly  = !blnEnabled;
            txtAbility2.ReadOnly = !blnEnabled;
            txtAbility3.ReadOnly = !blnEnabled;
            txtAbility4.ReadOnly = !blnEnabled;
            txtAbility5.ReadOnly = !blnEnabled;
            txtAbility6.ReadOnly = !blnEnabled;

            if (blnAndClear)
            {
                txtAbility1.Text = "";
                txtAbility2.Text = "";
                txtAbility3.Text = "";
                txtAbility4.Text = "";
                txtAbility5.Text = "";
                txtAbility6.Text = "";
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

        private int GetRandomDie(int size)
        {
            Die Die1 = new Die(6);
            int intReturnVal = Die1.GenerateRandomNumber();
            Die1.Dispose(true);
            Die1 = null;
            return intReturnVal;
        }
        #endregion



    }
}
