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
    public partial class frmAddCharacterLevel_AbilityIncrease : Form
    {
        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();
        public static string ClassName;
        public static int ClassLevel;

        private Point ptLocationPoint = new Point(8, 8);
        private int intAbilityIncreaseCount = 0;
        private System.Drawing.Size frmSize = new System.Drawing.Size(425, 359);

        private int intMaxAbilityIncrease = 2;

        //New Object that contains all the above items
        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();


        public frmAddCharacterLevel_AbilityIncrease()
        {
            InitializeComponent();
            
        }

        private void frmAddCharacterLevel_AbilityIncrease_Shown(object sender, EventArgs e)
        {
            //objOriginalCharacter = objCharacter;
            this.Size = frmSize;
            AddCharacterLevelObject();
        }      
        
        #region Methods
        public void AddCharacterLevelObject()
        {
            //Show the Ability Increase Screen (this form)
            SetupAbilityIncreaseForm();
            LoadAbilityFields();
            FillCharacterScoresOut();
        }

        private void LoadAbilityFields()
        {
            Ability ability = new Ability();
            List<Ability> abilities = new List<Ability>();
            int AbilityBoxIDNum = 1;

            abilities = ability.GetAbilites("", " SortOrder ASC ");

            foreach (Ability objAbility in abilities)
            {
                switch (AbilityBoxIDNum)
                {
                    case 1:
                        //FirstBox 
                        lblAbility1.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 2:
                        lblAbility2.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 3:
                        lblAbility3.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 4:
                        lblAbility4.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 5:
                        lblAbility5.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    case 6:
                        lblAbility6.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                    default:
                        lblAbility1.Text = objAbility.AbilityName;
                        AbilityBoxIDNum++;
                        break;
                }
            }

        }

        private void FillCharacterScoresOut()
        {
            FillOutAbilityField(lblAbility1, txtAbility1, txtAbility1Mod);
            FillOutAbilityField(lblAbility2, txtAbility2, txtAbility2Mod);
            FillOutAbilityField(lblAbility3, txtAbility3, txtAbility3Mod);
            FillOutAbilityField(lblAbility4, txtAbility4, txtAbility4Mod);
            FillOutAbilityField(lblAbility5, txtAbility5, txtAbility5Mod);
            FillOutAbilityField(lblAbility6, txtAbility6, txtAbility6Mod);

         }

        private void FillOutAbilityField(Label lblAbility, TextBox txtAbility, TextBox txtAbilityMod)
        {
            foreach (CharacterAbility objCharAbility in objCALC.objCharacter.lstCharacterAbilities)
            {
                if (lblAbility.Text.ToLower() == objCharAbility.objAbility.AbilityName.ToLower())
                {
                    txtAbility.Text = objCharAbility.Score.ToString();
                    txtAbilityMod.Text = objCharAbility.ScoreMod.ToString();
                }
            }
        }

        public void IncreaseStat(Label lblAbility, TextBox txtAbility, TextBox txtAbilityMod, Button btnAbility)
        {
            int intAbilityScore = 0;
            int.TryParse(txtAbility.Text, out intAbilityScore);
            intAbilityScore++;
            txtAbility.Text = intAbilityScore.ToString();
            txtAbilityMod.Text = ((intAbilityScore - 10) / 2).ToString();
            btnAbility.Enabled = false;
            
            Ability objAbility = new Ability();
            
            if (intAbilityIncreaseCount ==0)
            {
                objCALC.objAbility1Modified = objAbility.GetAbility(lblAbility.Text);
            }
            else
            {
                objCALC.objAbility2Modified = objAbility.GetAbility(lblAbility.Text);
            }
         }

        private void UpdateModValue(TextBox txtMod, int intScore)
        {
            txtMod.Text = ((intScore - (10)) / (2)).ToString();
        }

        public int GetValue(string LabelName, bool blnModValue)
        {
            int returnVal = 0;

            if (lblAbility1.Text.ToLower() == LabelName.ToLower())
            {
                if (blnModValue) int.TryParse(txtAbility1.Text, out returnVal); else int.TryParse(txtAbility1Mod.Text, out returnVal);
            }
            else if (lblAbility2.Text.ToLower() == LabelName.ToLower())
            {
                if (blnModValue) int.TryParse(txtAbility2.Text, out returnVal); else int.TryParse(txtAbility2Mod.Text, out returnVal);
            }
            else if (lblAbility3.Text.ToLower() == LabelName.ToLower())
            {
                if (blnModValue) int.TryParse(txtAbility3.Text, out returnVal); else int.TryParse(txtAbility3Mod.Text, out returnVal);
            }
            else if (lblAbility4.Text.ToLower() == LabelName.ToLower())
            {
                if (blnModValue) int.TryParse(txtAbility4.Text, out returnVal); else int.TryParse(txtAbility4Mod.Text, out returnVal);
            }
            if (lblAbility5.Text.ToLower() == LabelName.ToLower())
            {
                if (blnModValue) int.TryParse(txtAbility5.Text, out returnVal); else int.TryParse(txtAbility5Mod.Text, out returnVal);
            }
            if (lblAbility6.Text.ToLower() == LabelName.ToLower())
            {
                if (blnModValue) int.TryParse(txtAbility6.Text, out returnVal); else int.TryParse(txtAbility6Mod.Text, out returnVal);
            }

            return returnVal;
        }

        private void CheckAbilityIncreaseCount()
        {
            if (intAbilityIncreaseCount == intMaxAbilityIncrease)
            {
                //Disable the buttons
                ButtonEnableStatus(false);
            }
        }

        private void ButtonEnableStatus (bool blnEnabled)
        {
            btnAbility1.Enabled = blnEnabled;
            btnAbility2.Enabled = blnEnabled;
            btnAbility3.Enabled = blnEnabled;
            btnAbility4.Enabled = blnEnabled;
            btnAbility5.Enabled = blnEnabled;
            btnAbility6.Enabled = blnEnabled;
        }

        private void SetupAbilityIncreaseForm()
        {
            System.Drawing.Size size = new System.Drawing.Size();
            size.Height = 380;
            size.Width = 344;



            gpAbilities.Visible = true;
            gpAbilities.Location = this.ptLocationPoint;
            gpAbilities.Size = size;
            this.Text = "Add Characeter Level - Ability Score Increases";

        }
        #endregion        
        
        #region Ability Increase Events
        private void txtAbility1_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility1.Text, out intScore);
            UpdateModValue(txtAbility1Mod, intScore);
        }

        private void txtAbility2_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility2.Text, out intScore);
            UpdateModValue(txtAbility2Mod, intScore);
        }

        private void txtAbility3_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility3.Text, out intScore);
            UpdateModValue(txtAbility3Mod, intScore);
        }

        private void txtAbility4_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility4.Text, out intScore);
            UpdateModValue(txtAbility4Mod, intScore);
        }

        private void txtAbility5_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility5.Text, out intScore);
            UpdateModValue(txtAbility5Mod, intScore);
        }

        private void txtAbility6_TextChanged(object sender, EventArgs e)
        {
            int intScore = 0;
            int.TryParse(txtAbility6.Text, out intScore);
            UpdateModValue(txtAbility6Mod, intScore);
        }

        private void btnAbility1_Click(object sender, EventArgs e)
        {
            //Get the ability and add one to the txtAbilityMod value
            IncreaseStat(lblAbility1, txtAbility1, txtAbility1Mod, btnAbility1);
            intAbilityIncreaseCount++;
            CheckAbilityIncreaseCount();
        }
        
        private void btnAbility2_Click(object sender, EventArgs e)
        {
            IncreaseStat(lblAbility2, txtAbility2, txtAbility2Mod, btnAbility2);
            intAbilityIncreaseCount++;
            CheckAbilityIncreaseCount();
        }

        private void btnAbility3_Click(object sender, EventArgs e)
        {
            IncreaseStat(lblAbility3, txtAbility3, txtAbility3Mod, btnAbility3);
            intAbilityIncreaseCount++;
            CheckAbilityIncreaseCount();
        }

        private void btnAbility4_Click(object sender, EventArgs e)
        {
            IncreaseStat(lblAbility4, txtAbility4, txtAbility4Mod, btnAbility4);
            intAbilityIncreaseCount++;
            CheckAbilityIncreaseCount();
        }

        private void btnAbility5_Click(object sender, EventArgs e)
        {
            IncreaseStat(lblAbility5, txtAbility5, txtAbility5Mod, btnAbility5);
            intAbilityIncreaseCount++;
            CheckAbilityIncreaseCount();
        }

        private void btnAbility6_Click(object sender, EventArgs e)
        {
            IncreaseStat(lblAbility6, txtAbility6, txtAbility6Mod, btnAbility6);
            intAbilityIncreaseCount++;
            CheckAbilityIncreaseCount();
        }

        private void btnAbilityIncreaseReset_Click(object sender, EventArgs e)
        {
            FillCharacterScoresOut();
            ButtonEnableStatus(true);
            intAbilityIncreaseCount = 0;
        }

        private void btnAbilityIncreaseCommit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddCharacterLevel_AbilityIncrease_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }
        #endregion
        
    }
}
