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
using StarWarsClasses;

namespace StarWarsRPG
{
    public partial class frmCharCreate2GetRace : Form
    {
        public static Dictionary<int, string> dicAbilities = new Dictionary<int, string>();
        public static Race objUserSelectedRace = new Race();

        public string Seperator = " - ";
        public frmCharCreate2GetRace()
        {
            InitializeComponent();
        }

        //public frmCharCreate2GetRace(Race objParmRace)
        //{
        //    InitializeComponent();
        //    lsbRace.SelectedItem = objParmRace.RaceName;
        //    lsbRace.SelectedValue = objParmRace.RaceName;
        //    //lsbRace.S
        //    int c = 0;
        //    foreach (object objRace in lsbRace.Items)
        //    {
        //        if (objRace.ToString() == objParmRace.RaceName) break;
        //        c++;
        //    }
        //    lsbRace.SelectedIndex = c;

        //    SetRaceData(objParmRace);
        //}

        private void frmCharCreate2GetRace_Load(object sender, EventArgs e)
        {
            LoadListBoxWithRaces();
            if (objUserSelectedRace.RaceName !="")
            {
                int c = 0;
                foreach (object objRace in lsbRace.Items)
                {
                    if (objRace.ToString() == objUserSelectedRace.RaceName) break;
                    c++;
                }
                lsbRace.SelectedIndex = c;
                SetRaceData(objUserSelectedRace);
                this.btnSelectRace.Enabled = false;
            }

        }

        private void LoadListBoxWithRaces()
        {
            List<Race> lstRaces = new List<Race>();
            Race objRace = new Race();

            lstRaces = objRace.GetRaces("", "RaceName");

            if (lstRaces.Count >0)
            {
                foreach(Race oRace in lstRaces )
                {
                    if (oRace.Sex.ToUpper() == "B") this.lsbRace.Items.Add(oRace.RaceName); else this.lsbRace.Items.Add(oRace.RaceName + Seperator + oRace.Sex.ToUpper());
//                    this.lsbRace.Items.Add(oRace.RaceName);
                }
            }
        }

        private Race GetSelectedRaceObject ()
        {
            Race objRace = new Race();
            string strRaceName = lsbRace.SelectedItem.ToString();

            string sRName = "";
            string sRSex = "";
            if (strRaceName.Contains(Seperator))
            {
                //Get the correct Race object 
                sRName = strRaceName.Substring(0, strRaceName.IndexOf(Seperator));
                sRSex = strRaceName.Substring(strRaceName.IndexOf(Seperator) + Seperator.Length, 1);
                objRace.GetRace(sRName, sRSex);
            }
            else objRace.GetRace(lsbRace.SelectedItem.ToString());
            return objRace;
        }

        private void SetRaceData (Race objRace)
        {
            this.txtRaceName.Text = objRace.RaceName;
            this.txtRaceDescription.Text = objRace.RaceDescription;
            this.txtOtherDescription.Text = objRace.OtherDescription;
            this.txtSex.Text = objRace.Sex;
            this.txtAvgHeight.Text = objRace.AverageHeight.ToString();
            this.txtAvgWeight.Text = objRace.AverageWeight.ToString();
            this.ckbRage.Checked = objRace.RageAbility;
            this.ckbShapeShift.Checked = objRace.ShapeShiftAbility;
            this.clbPrimitive.Checked = objRace.Primitive;
            this.ckbBonusLevelFeat.Checked = objRace.BonusFeat;
            this.ckbBonusSkill.Checked = objRace.BonusSkill;

            lsbRaceSkills.Items.Clear();
            if (objRace.lstRaceSkills != null)
            {
                foreach (Skill objSkill in objRace.lstRaceSkills)
                {
                    lsbRaceSkills.Items.Add(objSkill.SkillName);
                }
            }

            lsbBonusFeats.Items.Clear();
            if (objRace.lstBonusFeats != null)
            {
                foreach (Feat objBFeat in objRace.lstBonusFeats)
                {
                    lsbBonusFeats.Items.Add(objBFeat.FeatName);
                }
            }

            lsbSpeeds.Items.Clear();
            if (objRace.objSpeeds != null)
            {
                foreach (Speed objSpeed in objRace.objSpeeds)
                {
                    lsbSpeeds.Items.Add(objSpeed.SpeedName + " - " + objSpeed.SpeedRate.ToString());
                }
            }

            lsbAbilityMods.Items.Clear();
            string strModString = "";
            if (objRace.objRaceAbilityModifiers != null)
            {
                foreach (RaceAbilityModifier objRAM in objRace.objRaceAbilityModifiers)
                {
                    strModString = "";
                    if (objRAM.objModifier.ModifierPositive)
                    {
                        strModString = "+" + objRAM.objModifier.ModifierNumber.ToString();
                    }
                    else
                    {
                        strModString = "-" + objRAM.objModifier.ModifierNumber.ToString();
                    }

                    lsbAbilityMods.Items.Add(objRAM.objAbility.AbilityName + ": " + strModString);
                }
            }

            lsbDefenseModifiers.Items.Clear();
            if (objRace.lstRaceDefenseTypeModifier != null)
            {
                foreach (RaceDefenseTypeModifier objRDM in objRace.lstRaceDefenseTypeModifier)
                {
                    strModString = "";
                    if (objRDM.objModifier.ModifierPositive)
                    {
                        strModString = "+" + objRDM.objModifier.ModifierNumber.ToString();
                    }
                    else
                    {
                        strModString = "-" + objRDM.objModifier.ModifierNumber.ToString();
                    }

                    lsbDefenseModifiers.Items.Add(objRDM.objDefenseType.DefenseTypeDescription + ": " + strModString);
                }
            }

            lsbRaceLanguages.Items.Clear();
            StringBuilder sbRaceLangDesc = new StringBuilder();

            if (objRace.lstRaceLanguages != null)
            {
                foreach (RaceLanguage objRaceLang in objRace.lstRaceLanguages)
                {
                    sbRaceLangDesc.Clear();
                    if (objRaceLang.SpeakOnly) sbRaceLangDesc.Append(" Speak Only");
                    if (objRaceLang.UnderstandOnly) sbRaceLangDesc.Append(" Understand Only");
                    lsbRaceLanguages.Items.Add(objRaceLang.objLanguage.LanguageName + sbRaceLangDesc.ToString());
                }
            }
            lsbConditionalFeats.Items.Clear();

            //public List<RaceSkillConditionalFeat> lstConditionalFeatsBySkill { get; set; }

            if (objRace.lstConditionalFeatsByFeat != null)
            {
                foreach (RaceFeatConditionalFeat objRFCF in objRace.lstConditionalFeatsByFeat)
                {
                    lsbConditionalFeats.Items.Add(objRFCF.objConditionalFeat.FeatName + " Requires " + objRFCF.objFeat.FeatName + " Feat");
                }
            }

            if (objRace.lstConditionalFeatsBySkill != null)
            {
                foreach (RaceSkillConditionalFeat objSFCF in objRace.lstConditionalFeatsBySkill)
                {
                    lsbConditionalFeats.Items.Add(objSFCF.objConditionalFeat.FeatName + " Requires " + objSFCF.objSkill.SkillName + " Skill");
                }
            }

            if (objRace.lstRaceSpecialAbilities != null)
            {
                lvRaceSpcialAbilities.Items.Clear();
                foreach (RaceSpecialAbility objRSA in objRace.lstRaceSpecialAbilities)
                {
                    ListViewItem oLVI = new ListViewItem();
                    oLVI.Tag = objRSA.RaceSpecialAbilityID.ToString();
                    oLVI.Text = objRSA.RaceSpecialAbilityName;
                    //oLVI.SubItems.Add(objRSA.RaceSpecialAbilityDescription);
                    //oLVI.SubItems.Add(objRSA.RaceSpecialAbilityDescription);

                    lvRaceSpcialAbilities.Items.Add(oLVI);
                }
                //Common.FormatListViewControlColumns(lvRaceSpcialAbilities);
            }
        }

        private void lsbRace_Click(object sender, EventArgs e)
        {
            Race objRace = new Race();
            objRace = GetSelectedRaceObject();
            SetRaceData(objRace);
        
        }

        private void lsbAbilityMods_DoubleClick(object sender, EventArgs e)
        {
            string strAbility = lsbAbilityMods.SelectedItem.ToString ();
            //Take the left hand side, before the :  example string "Charisma: +2"
            strAbility = strAbility.Substring(0, strAbility.IndexOf(":"));
            Ability objAbility = new Ability(strAbility);
            Form frmAbilityDisplay = new frmAbilityDisplay(objAbility);
            frmAbilityDisplay.ShowDialog();
        }

        private void btnSelectRace_Click(object sender, EventArgs e)
        {
            Race objRace = new Race();
            objRace = GetSelectedRaceObject();
            objUserSelectedRace = objRace;
            DialogResult = DialogResult.OK;
            
        }

        private void lvRaceSpcialAbilities_Click(object sender, EventArgs e)
        {
            string strTag = lvRaceSpcialAbilities.SelectedItems[0].Tag.ToString();
            int intTag=0;

            int.TryParse(strTag, out intTag);
            if (intTag != 0)
            {
                RaceSpecialAbility objRSA = new RaceSpecialAbility(intTag);
                txtRaceSpecialAbilityDescription.Text = objRSA.RaceSpecialAbilityDescription;
            }
            else txtRaceSpecialAbilityDescription.Text = "";
        }


        //private void button1_Click(object sender, EventArgs e)
        //{

        //    Form frmStep2GetRace = new frmCharCreate2GetRace();
        //    frmCharCreate2GetRace.dicAbilities = dicAbilities;
        //    frmStep2GetRace.ShowDialog();
        //    this.Close();
        //}
    }
}
