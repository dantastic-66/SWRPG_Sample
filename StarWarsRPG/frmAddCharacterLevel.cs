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
    public partial class frmAddCharacterLevel : Form
    {
        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();
        private List<Class> allClasses = new List<Class>();
        private bool blnPrestigeAdded = false;
        private bool blnLoadingExistingClasses = false;
        private bool blnCheckingPrestige = false;

        Dictionary<string, int> dicObjClasses = new Dictionary<string, int>();
        
        public static List<Class> lstClasses = new List<Class>();
        public static Character objCharacter = new Character();

        public static CharacterLevel objNewCharLevel = new CharacterLevel();
        public static Class objSelectedClass = new Class();

        #region Constructors
        public frmAddCharacterLevel(Character objChar)
        {
            InitializeComponent();
            objCharacter = objChar;
            txtHiddenCharLevel.Text = objChar.CharacterLevelID.ToString() ;
            if (objCharacter.CharacterID != 0)
            {
                //We have a char object, check to see what we load in the listbox
                blnLoadingExistingClasses = true;
                LoadCheckedListBox();
                blnLoadingExistingClasses = false;
            }
            else
            {
                LoadCheckedListBox(false);
            }
        }

        public frmAddCharacterLevel()
        {
            InitializeComponent();

            blnLoadingExistingClasses = true;
            //LoadPrestigeClassDropDown();


            if (objCharacter.CharacterID != 0)
            {
                //We have a char object, check to see what we load in the listbox
                LoadCheckedListBox();
                txtHiddenCharLevel.Text = objCharacter.CharacterLevelID.ToString();
            }
            else
            {
                LoadCheckedListBox(false);
            }
            blnLoadingExistingClasses = false;
        }
        #endregion

        #region Form Events
        private void btnAddLevel1_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass1.Text, this.txtClassLevel1.Text);
        }

        private void btnAddLevel2_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass2.Text, this.txtClassLevel2.Text);
        }

        private void btnAddLevel3_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass3.Text, this.txtClassLevel3.Text);
        }

        private void btnAddLevel4_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass4.Text, this.txtClassLevel4.Text);
        }

        private void btnAddLevel5_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass5.Text, this.txtClassLevel5.Text);
        }

        private void btnAddLevel6_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass6.Text, this.txtClassLevel6.Text);
        }

        private void btnAddLevel7_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass7.Text, this.txtClassLevel7.Text);
        }

        private void btnAddLevel8_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass8.Text, this.txtClassLevel8.Text);
        }

        private void btnAddLevel9_Click(object sender, EventArgs e)
        {
            AddClassLevelToChar(this.txtClass9.Text, this.txtClassLevel9.Text);
        }

        private void btnResetClassSelection_Click(object sender, EventArgs e)
        {
            string strTextToUncheck = "";
            this.btnResetClassSelection.Visible = false;
            clbClasses.Enabled = true;

            //Remove last item from Class Boxes
            if (this.txtClass9.Text != "")
            {
                strTextToUncheck = this.txtClass9.Text;
                this.txtClass9.Text = "";
                SetLevelGroupVisibility(txtClass9, lblClass9, txtClassLevel9, btnAddLevel9, false);
            }
            else if (this.txtClass8.Text != "")
            {
                strTextToUncheck = this.txtClass8.Text;
                this.txtClass8.Text = "";
                this.txtClassLevel8.Text = "";
                SetLevelGroupVisibility(txtClass8, lblClass8, txtClassLevel8, btnAddLevel8, true);
            }
            else if (this.txtClass7.Text != "")
            {
                strTextToUncheck = this.txtClass7.Text;
                this.txtClass7.Text = "";
                this.txtClassLevel7.Text = "";
                SetLevelGroupVisibility(txtClass7, lblClass7, txtClassLevel7, btnAddLevel7, true);
            }
            else if (this.txtClass6.Text != "")
            {
                strTextToUncheck = this.txtClass6.Text;
                this.txtClass6.Text = "";
                this.txtClassLevel6.Text = "";
                SetLevelGroupVisibility(txtClass6, lblClass6, txtClassLevel6, btnAddLevel6, true);
            }
            else if (this.txtClass5.Text != "")
            {
                strTextToUncheck = this.txtClass5.Text;
                this.txtClass5.Text = "";
                this.txtClassLevel5.Text = "";
                SetLevelGroupVisibility(txtClass5, lblClass5, txtClassLevel5, btnAddLevel5, true);
            }
            else if (this.txtClass4.Text != "")
            {
                strTextToUncheck = this.txtClass4.Text;
                this.txtClass4.Text = "";
                this.txtClassLevel4.Text = "";
                SetLevelGroupVisibility(txtClass4, lblClass4, txtClassLevel4, btnAddLevel4, true);

            }
            else if (this.txtClass3.Text != "")
            {
                strTextToUncheck = this.txtClass3.Text;
                this.txtClass3.Text = "";
                this.txtClassLevel3.Text = "";
                SetLevelGroupVisibility(txtClass3, lblClass3, txtClassLevel3, btnAddLevel3, true);
            }
            else if (this.txtClass2.Text != "")
            {
                strTextToUncheck = this.txtClass2.Text;
                this.txtClass2.Text = "";
                this.txtClassLevel2.Text = "";
                SetLevelGroupVisibility(txtClass2, lblClass2, txtClassLevel2, btnAddLevel2, true);
            }
            else if (this.txtClass1.Text != "")
            {
                strTextToUncheck = this.txtClass1.Text;
                this.txtClass1.Text = "";
                this.txtClassLevel1.Text = "";
                SetLevelGroupVisibility(txtClass1, lblClass1, txtClassLevel1, btnAddLevel1, true);
            }

            //Now loop thru the items in the clbClasses to find this one.
            for (int i = 0; i < clbClasses.Items.Count; i++)
            {
                if (clbClasses.Items[i].ToString() == strTextToUncheck)
                {
                    clbClasses.SetItemChecked(i, false);
                }
            }
        }
        #endregion

        #region Methods
        public void LoadCheckedListBox(bool AddPrestige)
        {
            clbClasses.Items.Clear();
            //Dictionary<string, bool> dicObjClasses = new Dictionary<string, bool>();

            Class objClass = new Class();

            allClasses = objClass.GetClasses("", " IsPrestige,ClassName");

            clbClasses.MultiColumn = true;
            foreach (Class lstClass in allClasses)
            {
                CheckedListBox objCLB = new CheckedListBox();
               

                if (!AddPrestige)
                {
                    if (lstClass.IsPrestige == false)
                    {
                        clbClasses.Items.Add(lstClass.ClassName);
                    }
                }
                else
                {
                    clbClasses.Items.Add(lstClass.ClassName);
                }
            }

            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        public void LoadCheckedListBox()
        {
            clbClasses.Items.Clear();
            //Dictionary<string, bool> dicObjClasses = new Dictionary<string, bool>();

            Class objClass = new Class();
            bool blnPrestigeClassQualify = true;

            allClasses = objClass.GetClasses("", " IsPrestige,ClassName");

            clbClasses.MultiColumn = true;

            bool blnIsCharClass = false;

            foreach (Class lstClass in allClasses)
            {
                //Add to the list box if it isn't a class for the character already
                blnIsCharClass = false;
                foreach (CharacterClassLevel objCharClassLevel in objCharacter.lstCharacterClassLevels )
                {
                    if (objCharClassLevel.objCharacterClass.ClassID == lstClass.ClassID )
                    {
                        blnIsCharClass = true;
                        clbClasses.Items.Add(lstClass.ClassName);
                    }
                }

                if (!blnIsCharClass)
                {
                    if (lstClass.IsPrestige == false)
                    {
                        clbClasses.Items.Add(lstClass.ClassName);
                    }
                    else
                    {
                        //Check if they qualify to be this prestige class
                        blnPrestigeClassQualify = Character.IsCharacterPrestigeClassQualified(lstClass, objCharacter);
                        if (blnPrestigeClassQualify)
                        {
                            blnPrestigeClassQualify = Character.IsCharacterPrestigeClassQualifiedTalentTree(lstClass, objCharacter);
                            if (blnPrestigeClassQualify)
                            {
                                blnPrestigeClassQualify = Character.IsCharacterPrestigeClassQualifiedFeat(lstClass, objCharacter);
                                if (blnPrestigeClassQualify)
                                {
                                    blnPrestigeClassQualify = Character.IsCharacterPrestigeClassQualifiedFeatGroup(lstClass, objCharacter);
                                    if (blnPrestigeClassQualify)
                                    {
                                        blnPrestigeClassQualify = Character.IsCharacterPrestigeClassQualifiedTalent(lstClass, objCharacter);
                                        if (blnPrestigeClassQualify)
                                        {
                                            blnPrestigeClassQualify = Character.IsCharacterPrestigeClassQualifiedForcePowers(lstClass, objCharacter);
                                            if (blnPrestigeClassQualify)
                                            {
                                                blnPrestigeClassQualify = Character.IsCharacterPrestigeClassLevelQualified(lstClass, objCharacter);
                                                if (blnPrestigeClassQualify)
                                                {
                                                    blnPrestigeClassQualify = Character.IsCharacterPrestigeBaseAttaclQualified(lstClass, objCharacter);
                                                    if (blnPrestigeClassQualify)
                                                    {
                                                        clbClasses.Items.Add(lstClass.ClassName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }

            //Now we have the checklistbox added to the drop down, loop thru the character classes and check them
            // Load the character boxes also.
            foreach (CharacterClassLevel objCharClassLevel in objCharacter.lstCharacterClassLevels)
            {
                //Now loop thru the items in the clbClasses to find this one.
                for (int i = 0; i < clbClasses.Items.Count ; i++)
                {
                    if (clbClasses.Items[i].ToString() == objCharClassLevel.objCharacterClass.ClassName )
                    {
                        clbClasses.SetItemChecked(i,true);
                        
                        AddSelectedItemToTextBoxes(objCharClassLevel.objCharacterClass.ClassName, objCharClassLevel.ClassLevel.ToString());
                    }
                }
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        //private bool IsCharacterPrestigeClassLevelQualified(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = true;

        //    if (objChar.CharacterLevelID <= objClass.PrestigeRequiredLevel )
        //    {
        //        blnReturnVal = false;
        //    }

        //    return blnReturnVal;
        //}

        //private bool IsCharacterPrestigeBaseAttaclQualified(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = true;

        //    if (objClass.PrestigeRequiredBaseAttack !=0)
        //    {
        //        if (objChar.BaseAttack  >= objClass.PrestigeRequiredBaseAttack )
        //        {
        //            blnReturnVal = false;
        //        }
        //    }

        //    return blnReturnVal;
        //}

        //private bool IsCharacterPrestigeClassQualified(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = true;
        //    bool blnCurrentReqFound = false;

        //    if (objClass.objPrestigeRequirement.Count != 0)
        //    {
        //        //loop thru each PrestigeRequirement in the class and see if the Character has it.
        //        foreach (PrestigeRequirement lstPrestigeRequirement in objClass.objPrestigeRequirement)
        //        {
        //            foreach (PrestigeRequirement lstCharPrestigeRequirement in objChar.objPrestigeRequirement)
        //            {
        //                if (lstPrestigeRequirement == lstCharPrestigeRequirement)
        //                {
        //                    blnCurrentReqFound = true;
        //                }
        //            }
        //            //If the return value is false, leave it false, one false is all it takes.
        //            if (blnReturnVal == true)
        //            {
        //                //If the current requirement was not found on this char then set the overall requirement to false;
        //                if (blnCurrentReqFound == false)
        //                {
        //                    blnReturnVal = blnCurrentReqFound;
        //                }
        //            }
        //        }
        //    }
        //    return blnReturnVal;
        //}

        //private bool IsCharacterPrestigeClassQualifiedTalentTree(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = false;
        //    int intCurrentTalentTreeRequiredTotal = 0;

        //    if (objClass.objPrestigeRequiredTalentTree != null)
        //    {
        //        //Go thru each talent in the character 
        //        foreach (Talent lstCharTalent in objChar.objTalents)
        //        {
        //            //Now get each talent tree from the prestige class
        //            foreach (TalentTree lstClassTalentTree in objClass.objPrestigeRequiredTalentTree)
        //            {
        //                //Now get each talent in prestige class talent tree
        //                foreach(Talent lstClassTalent in lstClassTalentTree.objTalentTreeTalents )
        //                {
        //                    if (lstCharTalent.TalentTreeID == lstClassTalent.TalentTreeID)
        //                    {
        //                        intCurrentTalentTreeRequiredTotal++;
        //                    }
        //                }
        //            }
        //        }





        //        ////Go thru each of the talent trees required
        //        //foreach (TalentTree lstClassTalentTree in objClass.objPrestigeRequiredTalentTree)
        //        //{
                    
        //        //    //Check each Talent in objChar to see if its one of the talent trees
        //        //    foreach (Talent lstCharTalent in objChar.objTalents)
        //        //    {
        //        //        if (lstCharTalent.TalentTreeID == lstClassTalentTree.TalentTreeID)
        //        //        {
        //        //            intCurrentTalentTreeRequiredTotal++;
        //        //        }
        //        //    }
        //        //}

        //        if (intCurrentTalentTreeRequiredTotal >= objClass.PrestigeRequiredTalents)
        //        {
        //            blnReturnVal = true;
        //        }
        //        else
        //        {
        //            blnReturnVal = false;
        //        }
        //    }
        //    else
        //    {
        //        blnReturnVal = true;
        //    }

        //    return blnReturnVal;
        //}

        //private bool IsCharacterPrestigeClassQualifiedFeat(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = true;
        //    bool blnCurrentReqFound = false;

        //    if (objClass.objPrestigeRequiredFeats.Count == 0) blnCurrentReqFound = true;

        //    if (objClass.objPrestigeRequirement != null)
        //    {
        //        //loop thru each required feats in the class and see if the Character has it.
        //        foreach (Feat lstPrestigeReqFeat in objClass.objPrestigeRequiredFeats )
        //        {
        //            foreach (Feat lstCharFeat in objChar.objFeats )
        //            {
        //                if (lstPrestigeReqFeat.FeatID  == lstCharFeat.FeatID )
        //                {
        //                    blnCurrentReqFound = true;
        //                }
        //            }
        //        }
        //        //If the return value is false, leave it false, one false is all it takes.
        //        if (blnReturnVal == true)
        //        {
        //            //If the current requirement was not found on this char then set the overall requirement to false;
        //            if (blnCurrentReqFound == false)
        //            {
        //                blnReturnVal = blnCurrentReqFound;
        //            }
        //        }

        //    }

        //    return blnReturnVal;
        //}

        //private bool IsCharacterPrestigeClassQualifiedFeatGroup(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = false;
        //    int intCurrentFeatGroupRequiredTotal = 0;

        //    if (objClass.objPrestigeRequiredFeatGroup.Count   != 0)
        //    {
        //        //Go thru each of the talent trees required
        //        foreach (Feat lstClassFeat in objClass.objPrestigeRequiredFeatGroup)
        //        {
        //            //Check each Talent in objChar to see if its one of the talent trees
        //            foreach (Feat lstCharFeat in objChar.objFeats)
        //            {
        //                if (lstCharFeat.FeatID  == lstClassFeat.FeatID )
        //                {
        //                    intCurrentFeatGroupRequiredTotal++;
        //                }
        //            }
        //        }

        //        if (intCurrentFeatGroupRequiredTotal >= objClass.PrestigeRequiredFeats  )
        //        {
        //            blnReturnVal = true;
        //        }
        //        else
        //        {
        //            blnReturnVal = false;
        //        }
        //    }
        //    else
        //    {
        //        blnReturnVal = true;
        //    }

        //    return blnReturnVal;
        //}

        //private bool IsCharacterPrestigeClassQualifiedTalent(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = false;
        //    int intCurrentTalentsRequiredTotal = 0;

        //    if (objClass.objPrestigeRequiredTalents.Count != 0)
        //    {
        //        //Go thru each of the talent trees required
        //        foreach (Talent lstClassTalent in objClass.objPrestigeRequiredTalents )
        //        {
        //            //Check each Talent in objChar to see if its one of the talent trees
        //            foreach (Talent lstCharTalent in objChar.objTalents )
        //            {
        //                if (lstCharTalent.TalentID == lstClassTalent.TalentID)
        //                {
        //                    intCurrentTalentsRequiredTotal++;
        //                }
        //            }
        //        }

        //        if (intCurrentTalentsRequiredTotal >= objClass.PrestigeRequiredTalents  )
        //        {
        //            blnReturnVal = true;
        //        }
        //        else
        //        {
        //            blnReturnVal = false;
        //        }
        //    }
        //    else
        //    {
        //        blnReturnVal = true;
        //    }

        //    return blnReturnVal;
        //}

        //private bool IsCharacterPrestigeClassQualifiedForcePowers(Class objClass, Character objChar)
        //{
        //    bool blnReturnVal = false;
        //    bool  blnCurrentReqFound = true; 

        //    if (objClass.objPrestigeRequiredForcePowers.Count != 0)
        //    {
        //        //Go thru each of the talent trees required
        //        foreach (ForcePower  lstClassFP in objClass.objPrestigeRequiredForcePowers)
        //        {
        //            //Check each Talent in objChar to see if its one of the talent trees
        //            foreach (ForcePower lstCharFP in objChar.objForcePowers )
        //            {
        //                if (lstClassFP.ForcePowerID == lstCharFP.ForcePowerID)
        //                {
        //                     blnCurrentReqFound = true;
        //                }
        //            }
        //        }

        //        //If the return value is false, leave it false, one false is all it takes.
        //        if (blnReturnVal == true)
        //        {
        //            //If the current requirement was not found on this char then set the overall requirement to false;
        //            if (blnCurrentReqFound == false)
        //            {
        //                blnReturnVal = blnCurrentReqFound;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        blnReturnVal = true;
        //    }
        //    return blnReturnVal;
        //}
        
        private void AddSelectedItemToTextBoxes(string selectedItem, string selectedValue)
        {
            if (this.txtClass1.Text == "")
            {
                this.txtClass1.Text = selectedItem;
                this.txtClassLevel1.Text = selectedValue;
                this.btnAddLevel1.Visible = true;
            }
            else if (this.txtClass2.Text == "")
            {
                this.txtClass2.Text = selectedItem;
                this.txtClassLevel2.Text = selectedValue;
                SetLevelGroupVisibility(txtClass2, lblClass2, txtClassLevel2, btnAddLevel2, true);
                //this.txtClass2.Visible = true;
                //this.lblClass2.Visible = true;
                //this.txtClassLevel2.Visible = true;
                //this.btnAddLevel2.Visible = true;
            }
            else if (this.txtClass3.Text == "")
            {
                this.txtClass3.Text = selectedItem;
                this.txtClassLevel3.Text = selectedValue;
                SetLevelGroupVisibility(txtClass3, lblClass3, txtClassLevel3, btnAddLevel3, true);
                //this.txtClass3.Visible = true;
                //this.lblClass3.Visible = true;
                //this.txtClassLevel3.Visible = true;
                //this.btnAddLevel3.Visible = true;
            }
            else if (this.txtClass4.Text == "")
            {
                this.txtClass4.Text = selectedItem;
                this.txtClassLevel4.Text = selectedValue;
                SetLevelGroupVisibility(txtClass4, lblClass4, txtClassLevel4, btnAddLevel4, true);
                //this.txtClass4.Visible = true;
                //this.lblClass4.Visible = true;
                //this.txtClassLevel4.Visible = true;
                //this.btnAddLevel4.Visible = true;
            }
            else if (this.txtClass5.Text == "")
            {
                this.txtClass5.Text = selectedItem;
                this.txtClassLevel5.Text = selectedValue;
                SetLevelGroupVisibility(txtClass5, lblClass5, txtClassLevel5, btnAddLevel5, true);
                //this.txtClass5.Visible = true;
                //this.lblClass5.Visible = true;
                //this.txtClassLevel5.Visible = true;
                //this.btnAddLevel5.Visible = true;
            }
            else if (this.txtClass6.Text == "")
            {
                this.txtClass6.Text = selectedItem;
                this.txtClassLevel6.Text = selectedValue;
                SetLevelGroupVisibility(txtClass6, lblClass6, txtClassLevel6, btnAddLevel6, true);
                //this.txtClass6.Visible = true;
                //this.lblClass6.Visible = true;
                //this.txtClassLevel6.Visible = true;
                //this.btnAddLevel6.Visible = true;
            }
            else if (this.txtClass7.Text == "")
            {
                this.txtClass7.Text = selectedItem;
                this.txtClassLevel7.Text = selectedValue;
                SetLevelGroupVisibility(txtClass7, lblClass7, txtClassLevel7, btnAddLevel7, true);
                //this.txtClass7.Visible = true;
                //this.lblClass7.Visible = true;
                //this.txtClassLevel7.Visible = true;
                //this.btnAddLevel7.Visible = true;
            }
            else if (this.txtClass8.Text == "")
            {
                this.txtClass8.Text = selectedItem;
                this.txtClassLevel8.Text = selectedValue;
                SetLevelGroupVisibility(txtClass8, lblClass8, txtClassLevel8, btnAddLevel8, true);
                //this.txtClass8.Visible = true;
                //this.lblClass8.Visible = true;
                //this.txtClassLevel8.Visible = true;
                //this.btnAddLevel8.Visible = true;
            }
            else if (this.txtClass9.Text == "")
            {
                this.txtClass9.Text = selectedItem;
                this.txtClassLevel9.Text = selectedValue;
                SetLevelGroupVisibility(txtClass9, lblClass9, txtClassLevel9, btnAddLevel9, true);
                //this.txtClass9.Visible = true;
                //this.lblClass9.Visible = true;
                //this.txtClassLevel9.Visible = true;
                //this.btnAddLevel9.Visible = true;
            }

            //Class objClass = new Class();
            //objClass.GetClass(selectedItem);
            //lstClasses.Add(objClass);
        }

        private void SetAddLevelButtonsVisibility(bool blnVisibility)
        {
            if (blnVisibility)
            {
                if (this.txtClassLevel1.Visible) btnAddLevel1.Visible = blnVisibility;
                if (this.txtClassLevel2.Visible) btnAddLevel2.Visible = blnVisibility;
                if (this.txtClassLevel3.Visible) btnAddLevel3.Visible = blnVisibility;
                if (this.txtClassLevel4.Visible) btnAddLevel4.Visible = blnVisibility;
                if (this.txtClassLevel5.Visible) btnAddLevel5.Visible = blnVisibility;
                if (this.txtClassLevel6.Visible) btnAddLevel6.Visible = blnVisibility;
                if (this.txtClassLevel7.Visible) btnAddLevel7.Visible = blnVisibility;
                if (this.txtClassLevel8.Visible) btnAddLevel8.Visible = blnVisibility;
                if (this.txtClassLevel9.Visible) btnAddLevel9.Visible = blnVisibility;
            }
            else
            {
                this.btnAddLevel1.Visible = blnVisibility;
                this.btnAddLevel2.Visible = blnVisibility;
                this.btnAddLevel3.Visible = blnVisibility;
                this.btnAddLevel4.Visible = blnVisibility;
                this.btnAddLevel5.Visible = blnVisibility;
                this.btnAddLevel6.Visible = blnVisibility;
                this.btnAddLevel7.Visible = blnVisibility;
                this.btnAddLevel8.Visible = blnVisibility;
                this.btnAddLevel9.Visible = blnVisibility;
            }
        }

        private void SetLevelGroupVisibility(TextBox txtC, Label lblC, TextBox txtCL, Button btnAL, bool blnVisibility)
        {
            txtC.Visible = blnVisibility;
            lblC.Visible = blnVisibility;
            txtCL.Visible = blnVisibility;
            btnAL.Visible = blnVisibility;
        }

        private void SetLevelGroupVisibility(TextBox txtC, Label lblC, TextBox txtCL,  bool blnVisibility)
        {
            txtC.Visible = blnVisibility;
            lblC.Visible = blnVisibility;
            txtCL.Visible = blnVisibility;
        }

        private void AddToSkillBoxes(KeyValuePair<string, int> objDicKeyValue)
        {
            if (this.txtClass1.Text == "")
            {
                //int.TryParse(this.txtClassLevel1.Text, out intClassLevel);
                //dicObjClasses.Add(txtClass1.Text, intClassLevel);
                this.txtClass1.Text = objDicKeyValue.Key;
                this.txtClassLevel1.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass1, lblClass1, txtClassLevel1, btnAddLevel1, true);
                return;
            }

            if (this.txtClassLevel2.Text == "")
            {
                this.txtClass2.Text = objDicKeyValue.Key;
                this.txtClassLevel2.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass2, lblClass2, txtClassLevel2, btnAddLevel2, true);
                //this.txtClass2.Visible = true;
                //this.lblClass2.Visible = true;
                //this.txtClassLevel2.Visible = true;
                return;
            }

            if (this.txtClassLevel3.Text == "")
            {
                this.txtClass3.Text = objDicKeyValue.Key;
                this.txtClassLevel3.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass3, lblClass3, txtClassLevel3, btnAddLevel3, true);
                //this.txtClass3.Visible = true;
                //this.lblClass3.Visible = true;
                //this.txtClassLevel3.Visible = true;
                return;
            }

            if (this.txtClassLevel4.Text == "")
            {
                this.txtClass4.Text = objDicKeyValue.Key;
                this.txtClassLevel4.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass4, lblClass4, txtClassLevel4, btnAddLevel4, true);
                //this.txtClass4.Visible = true;
                //this.lblClass4.Visible = true;
                //this.txtClassLevel4.Visible = true;
                return;
            }

            if (this.txtClassLevel5.Text == "")
            {
                this.txtClass5.Text = objDicKeyValue.Key;
                this.txtClassLevel5.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass5, lblClass5, txtClassLevel5, btnAddLevel5, true);
                //this.txtClass5.Visible = true;
                //this.lblClass5.Visible = true;
                //this.txtClassLevel5.Visible = true;
                return;
            }

            if (this.txtClassLevel6.Text == "")
            {
                this.txtClass6.Text = objDicKeyValue.Key;
                this.txtClassLevel6.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass6, lblClass6, txtClassLevel6, btnAddLevel6, true);
                //this.txtClass6.Visible = true;
                //this.lblClass6.Visible = true;
                //this.txtClassLevel6.Visible = true;
                return;
            }

            if (this.txtClassLevel7.Text == "")
            {
                this.txtClass7.Text = objDicKeyValue.Key;
                this.txtClassLevel7.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass7, lblClass7, txtClassLevel7, btnAddLevel7, true);
                //this.txtClass7.Visible = true;
                //this.lblClass7.Visible = true;
                //this.txtClassLevel7.Visible = true;
                return;
            }

            if (this.txtClassLevel8.Text == "")
            {
                this.txtClass8.Text = objDicKeyValue.Key;
                this.txtClassLevel8.Text = objDicKeyValue.Value.ToString();
                SetLevelGroupVisibility(txtClass8, lblClass8, txtClassLevel8, btnAddLevel8, true);
                //this.txtClass8.Visible = true;
                //this.lblClass8.Visible = true;
                //this.txtClassLevel8.Visible = true;
                return;
            }

            if (this.txtClassLevel9.Text == "")
            {
                this.txtClass9.Text = objDicKeyValue.Key;
                this.txtClassLevel9.Text = objDicKeyValue.Value.ToString();
                //this.txtClass9.Visible = true;
                //this.lblClass9.Visible = true;
                //this.txtClassLevel9.Visible = true;
                SetLevelGroupVisibility(txtClass9, lblClass9, txtClassLevel9, btnAddLevel9, true);
                return;
            }
        }

        private void ResetAndHideTextBoxes()
        {
            this.txtClass1.Text = "";
            this.txtClassLevel1.Text = "";
            this.btnAddLevel1.Visible = true;

            this.txtClass2.Text = "";
            this.txtClassLevel2.Text = "";
            SetLevelGroupVisibility(txtClass2, lblClass2, txtClassLevel2, btnAddLevel2, false);
            //this.txtClass2.Visible = false;
            //this.lblClass2.Visible = false;
            //this.txtClassLevel2.Visible = false;
            //this.btnAddLevel2.Visible = false;

            this.txtClass3.Text = "";
            this.txtClassLevel3.Text = "";
            SetLevelGroupVisibility(txtClass3, lblClass3, txtClassLevel3, btnAddLevel3, false);
            //this.txtClass3.Visible = false;
            //this.lblClass3.Visible = false;
            //this.txtClassLevel3.Visible = false;
            //this.btnAddLevel3.Visible = false;

            this.txtClass4.Text = "";
            this.txtClassLevel4.Text = "";
            SetLevelGroupVisibility(txtClass4, lblClass4, txtClassLevel4, btnAddLevel4, false);
            //this.txtClass4.Visible = false;
            //this.lblClass4.Visible = false;
            //this.txtClassLevel4.Visible = false;
            //this.btnAddLevel4.Visible = false;

            this.txtClass5.Text = "";
            this.txtClassLevel5.Text = "";
            SetLevelGroupVisibility(txtClass5, lblClass5, txtClassLevel5, btnAddLevel5, false);
            //this.txtClass5.Visible = false;
            //this.lblClass5.Visible = false;
            //this.txtClassLevel5.Visible = false;
            //this.btnAddLevel5.Visible = false;

            this.txtClass6.Text = "";
            this.txtClassLevel6.Text = "";
            SetLevelGroupVisibility(txtClass6, lblClass6, txtClassLevel6, btnAddLevel6, false);
            //this.txtClass6.Visible = false;
            //this.lblClass6.Visible = false;
            //this.txtClassLevel6.Visible = false;
            //this.btnAddLevel6.Visible = false;

            this.txtClass7.Text = "";
            this.txtClassLevel7.Text = "";
            SetLevelGroupVisibility(txtClass7, lblClass7, txtClassLevel7, btnAddLevel7, false);
            //this.txtClass7.Visible = false;
            //this.lblClass7.Visible = false;
            //this.txtClassLevel7.Visible = false;
            //this.btnAddLevel7.Visible = false;

            this.txtClass8.Text = "";
            this.txtClassLevel8.Text = "";
            SetLevelGroupVisibility(txtClass8, lblClass8, txtClassLevel8, btnAddLevel8, false);
            //this.txtClass8.Visible = false;
            //this.lblClass8.Visible = false;
            //this.txtClassLevel8.Visible = false;
            //this.btnAddLevel9.Visible = false;

            this.txtClass9.Text = "";
            this.txtClassLevel9.Text = "";
            SetLevelGroupVisibility(txtClass9, lblClass9, txtClassLevel9, btnAddLevel9, false);
            //this.txtClass9.Visible = false;
            //this.lblClass9.Visible = false;
            //this.txtClassLevel9.Visible = false;
            //this.btnAddLevel9.Visible = false;
        }

        private int SumAllLevels()
        {
            int intClassLevel = 0;
            int intTotalLevels = 0;

            int.TryParse(this.txtClassLevel1.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel2.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel3.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel4.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel5.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel6.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel7.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel8.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;
            int.TryParse(this.txtClassLevel9.Text, out intClassLevel);
            intTotalLevels = intTotalLevels + intClassLevel;

            return intTotalLevels;

        }

        private void clbClasses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!blnLoadingExistingClasses)
            {
                blnCheckingPrestige = true;

                if (e.NewValue == CheckState.Checked)
                {
                    //Add it to the list
                    SetAddLevelButtonsVisibility(false);
                    AddSelectedItemToTextBoxes(clbClasses.SelectedItem.ToString());
                    clbClasses.Enabled = false;
                    this.btnResetClassSelection.Visible = true;
                }
                else
                {
                    SetAddLevelButtonsVisibility(true); 
                    RemoveSelectedItemFromTextBoxes(clbClasses.SelectedItem.ToString());
                    clbClasses.Enabled = true;
                }
                blnCheckingPrestige = false;
            }
        }

        private void RemoveSelectedItemFromTextBoxes(string selectedItem)
        {
            dicObjClasses.Clear();
            int intClassLevel = 0;
            int intTotalClassLevel = 0;

            intTotalClassLevel = GetTotalClassLevel();

            //Go thru the text boxes, 
            //if not the selected item and not blank then add the class and level to the dictionary if they are not the selected item
            if (this.txtClass1.Text != selectedItem)
            {
                int.TryParse(this.txtClassLevel1.Text, out intClassLevel);
                dicObjClasses.Add(txtClass1.Text, intClassLevel);
            }

            if ((this.txtClass2.Text != selectedItem) && !(this.txtClass2.Text == ""))
            {
                int.TryParse(this.txtClassLevel2.Text, out intClassLevel);
                dicObjClasses.Add(txtClass2.Text, intClassLevel);
            }

            if ((this.txtClass3.Text != selectedItem) && !(this.txtClass3.Text == ""))
            {
                int.TryParse(this.txtClassLevel3.Text, out intClassLevel);
                dicObjClasses.Add(txtClass3.Text, intClassLevel);
            }

            if ((this.txtClass4.Text != selectedItem) && !(this.txtClass4.Text == ""))
            {
                int.TryParse(this.txtClassLevel4.Text, out intClassLevel);
                dicObjClasses.Add(txtClass4.Text, intClassLevel);
            }

            if ((this.txtClass5.Text != selectedItem) && !(this.txtClass5.Text == ""))
            {
                int.TryParse(this.txtClassLevel5.Text, out intClassLevel);
                dicObjClasses.Add(txtClass5.Text, intClassLevel);
            }

            if ((this.txtClass6.Text != selectedItem) && !(this.txtClass6.Text == ""))
            {
                int.TryParse(this.txtClassLevel6.Text, out intClassLevel);
                dicObjClasses.Add(txtClass6.Text, intClassLevel);
            }

            if ((this.txtClass7.Text != selectedItem) && !(this.txtClass7.Text == ""))
            {
                int.TryParse(this.txtClassLevel7.Text, out intClassLevel);
                dicObjClasses.Add(txtClass7.Text, intClassLevel);
            }

            if ((this.txtClass8.Text != selectedItem) && !(this.txtClass8.Text == ""))
            {
                int.TryParse(this.txtClassLevel8.Text, out intClassLevel);
                dicObjClasses.Add(txtClass8.Text, intClassLevel);
            }

            if ((this.txtClass9.Text != selectedItem) && !(this.txtClass9.Text == ""))
            {
                int.TryParse(this.txtClassLevel9.Text, out intClassLevel);
                dicObjClasses.Add(txtClass9.Text, intClassLevel);
            }

            ResetAndHideTextBoxes();

            foreach (KeyValuePair<string, int> dicPair in dicObjClasses)
            {
                if (dicPair.Key != selectedItem)
                {
                    AddToSkillBoxes(dicPair);
                }
            }

            blnCheckingPrestige = false;

            Class objClass = new Class();
            objClass.GetClass(selectedItem);
            lstClasses.Remove(objClass);
        }

        private void CheckForPrestigeLevels()
        {
            int intLevelSum = SumAllLevels();
            if (!blnCheckingPrestige)
            {
                //If total is > 7, we can add the prestige
                if (!blnPrestigeAdded)
                {
                    if (intLevelSum >= 7)
                    {
                        blnPrestigeAdded = true;
                        AdjustCheckBoxListWithPrestigeClasses(blnPrestigeAdded);
                    }
                }

                //if total is less than 7 we have to remove prestige
                if (blnPrestigeAdded)
                {
                    if (intLevelSum < 7)
                    {
                        blnPrestigeAdded = false;
                        AdjustCheckBoxListWithPrestigeClasses(blnPrestigeAdded);
                    }
                }
            }
        }

        private void AdjustCheckBoxListWithPrestigeClasses(bool blnAddPrestige)
        {
            foreach (Class lstClass in allClasses)
            {
                if (blnAddPrestige)
                {
                    if (lstClass.IsPrestige == blnAddPrestige)
                    {
                        clbClasses.Items.Add(lstClass.ClassName);
                    }
                }
                else
                {
                    //remove prestige
                    if (lstClass.IsPrestige == !blnAddPrestige)
                    {
                        clbClasses.Items.Remove(lstClass.ClassName);
                    }
                }
            }
        }

        private int GetTotalClassLevel()
        {

            int intClassLevel = 0;
            int intTotalClassLevel = 0;


            if (this.txtClass1.Text != "")
            {
                int.TryParse(this.txtClassLevel1.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass2.Text != "")
            {
                int.TryParse(this.txtClassLevel2.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass3.Text != "")
            {
                int.TryParse(this.txtClassLevel3.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass4.Text != "")
            {
                int.TryParse(this.txtClassLevel4.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass5.Text != "")
            {
                int.TryParse(this.txtClassLevel5.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass6.Text != "")
            {
                int.TryParse(this.txtClassLevel6.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass7.Text != "")
            {
                int.TryParse(this.txtClassLevel7.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass8.Text != "")
            {
                int.TryParse(this.txtClassLevel8.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }

            if (this.txtClass9.Text != "")
            {
                int.TryParse(this.txtClassLevel9.Text, out intClassLevel);
                intTotalClassLevel = intTotalClassLevel + intClassLevel;
            }
            return intTotalClassLevel;
        }

        private void AddSelectedItemToTextBoxes(string selectedItem)
        {
            if (this.txtClass1.Text == "")
            {
                this.txtClass1.Text = selectedItem;
                SetLevelGroupVisibility(txtClass1, lblClass1, txtClassLevel1, btnAddLevel1, true);
            }
            else if (this.txtClass2.Text == "")
            {
                this.txtClass2.Text = selectedItem;
                this.txtClassLevel2.Text = "0";
                SetLevelGroupVisibility(txtClass2, lblClass2, txtClassLevel2, btnAddLevel2, true);
            }
            else if (this.txtClass3.Text == "")
            {
                this.txtClass3.Text = selectedItem;
                this.txtClassLevel3.Text = "0";
                SetLevelGroupVisibility(txtClass3, lblClass3, txtClassLevel3, btnAddLevel3, true);
            }
            else if (this.txtClass4.Text == "")
            {
                this.txtClass4.Text = selectedItem;
                this.txtClassLevel4.Text = "0";
                SetLevelGroupVisibility(txtClass4, lblClass4, txtClassLevel4, btnAddLevel4,  true);
            }
            else if (this.txtClass5.Text == "")
            {
                this.txtClass5.Text = selectedItem;
                this.txtClassLevel5.Text = "0";
                SetLevelGroupVisibility(txtClass5, lblClass5, txtClassLevel5, btnAddLevel5, true);
            }
            else if (this.txtClass6.Text == "")
            {
                this.txtClass6.Text = selectedItem;
                this.txtClassLevel6.Text = "0";
                SetLevelGroupVisibility(txtClass6, lblClass6, txtClassLevel6, btnAddLevel6, true);
            }
            else if (this.txtClass7.Text == "")
            {
                this.txtClass7.Text = selectedItem;
                this.txtClassLevel7.Text = "0";
                SetLevelGroupVisibility(txtClass7, lblClass7, txtClassLevel7, btnAddLevel7, true);
            }
            else if (this.txtClass8.Text == "")
            {
                this.txtClass8.Text = selectedItem;
                this.txtClassLevel8.Text = "0";
                SetLevelGroupVisibility(txtClass8, lblClass8, txtClassLevel8, btnAddLevel8, true);
            }
            else if (this.txtClass9.Text == "")
            {
                this.txtClass9.Text = selectedItem;
                this.txtClassLevel9.Text = "0";
                SetLevelGroupVisibility(txtClass9, lblClass9, txtClassLevel9, btnAddLevel9, true);
            }

            Class objClass = new Class();
            objClass.GetClass(selectedItem);
            lstClasses.Add(objClass);
        }

        private void AddClassLevelToChar(string ClassName, string ClassLevel)
        {
            clbClasses.Enabled = false;
            SetAddLevelButtonsVisibility(false);
            int intClassLevel = 0;

            int intCharLevel = 0;
            int.TryParse(this.txtHiddenCharLevel.Text, out intCharLevel);
            int.TryParse(ClassLevel, out intClassLevel);
            intClassLevel++;
            intCharLevel++;
            //Show the ControlList Form here, from there the user can select which function they want to complete in what order.
            frmAddCharacterLevel_ControlList.objCALC.ClassLevel = intClassLevel;
            
            frmAddCharacterLevel_ControlList.objCALC.objOriginalCharacter = Character.Clone(objCharacter); 
            objNewCharLevel.GetCharacterLevel(intCharLevel);

           


            //frmAddCharacterLevel_ControlList.objCALC.objCharacter.objCharacterClassLevels 
            //objCharacterClassLevels
            frmAddCharacterLevel_ControlList.objCALC.objCharacter = objCharacter;
            //frmAddCharacterLevel_ControlList.objCALC.objCharacter.objCharacterLevels.Add(objNewCharLevel);
            frmAddCharacterLevel_ControlList.objCALC.objNewCharLevel = objNewCharLevel;

            objSelectedClass.GetClass(ClassName);
            frmAddCharacterLevel_ControlList.objCALC.objSelectedClass = objSelectedClass;
            
            CharacterClassLevel objNewCharClassLevel = new CharacterClassLevel();
            objNewCharClassLevel.CharacterID = objCharacter.CharacterID;
            objNewCharClassLevel.ClassID = objSelectedClass.ClassID;
            ClassLevelInfo objCLI = new ClassLevelInfo(objSelectedClass.ClassID, intClassLevel);
            objNewCharClassLevel.ClassLevel  = objCLI.ClassLevelID;

            frmAddCharacterLevel_ControlList.objCALC.objCharacter.lstCharacterClassLevels.Add(objNewCharClassLevel);

            //objCharacterClassLevels
            //Clear out the other objects
            frmAddCharacterLevel_ControlList.objCALC.objSelectedTalent = new Talent();
            frmAddCharacterLevel_ControlList.objCALC.objAbility1Modified = new Ability();
            frmAddCharacterLevel_ControlList.objCALC.objAbility2Modified = new Ability();
            frmAddCharacterLevel_ControlList.objCALC.objBonusFeat = new Feat();
            frmAddCharacterLevel_ControlList.objCALC.objCharLevelFeat = new Feat();
            frmAddCharacterLevel_ControlList.objCALC.lstNewForcePowers = new List<ForcePower>();
            frmAddCharacterLevel_ControlList.objCALC.lstNewSkills = new List<CharacterSkill>();
            frmAddCharacterLevel_ControlList.objCALC.objForceSecret = new ForceSecret();
            frmAddCharacterLevel_ControlList.objCALC.objForceTechnique = new ForceTechnique();
            frmAddCharacterLevel_ControlList.objCALC.lstLanguages = new List<Language>();
            frmAddCharacterLevel_ControlList.objCALC.lstButtonsNeeded = new List<CharUpgradeButtonOptions>();



            frmAddCharacterLevel_ControlList frmCharUpgradeControlList = new frmAddCharacterLevel_ControlList();
            this.Close();
            frmCharUpgradeControlList.Show();

       }
        #endregion
    }
}
