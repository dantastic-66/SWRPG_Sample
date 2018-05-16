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
    public partial class frmSetClassAndLevel : Form
    {

        private StarWarsClasses.DatabaseConnection dbconn = new DatabaseConnection();
        private List<Class> allClasses = new List<Class>();
        private bool blnPrestigeAdded = false;
        private bool blnCheckingPrestige = false;
        private bool blnLoadingExistingClasses = false;

        public static string AllClasses = "";
        //public static string AllLevels = "";
        public static int CharacterLevel = 0;

        //public static Array[] arrClassIDs = new Array[9];
        public static List<Class> lstClasses = new List<Class>();

        Dictionary<string, int> dicObjClasses = new Dictionary<string, int>();
        List<PrestigeRequirement> gprestigeRequirement;
        Class gPrestigeClass;
        
        public frmSetClassAndLevel()
        {
            InitializeComponent();
            LoadCheckedListBox(false);
            LoadPrestigeClassDropDown();
            
            blnLoadingExistingClasses = true;

            if (AllClasses != "")
            {
                //Setup the current classes.
                char[] seperator = new char[1];
                seperator[0] = ',';

                string[] lAllClasses = AllClasses.Split(seperator,9);
                
                string OneClass = "";
                string OneLevel = "";

                foreach (string oneClassAndLevel in lAllClasses)
                {
                    string[] classAndLevel = oneClassAndLevel.Split ('-');
                    OneClass = classAndLevel[0].Trim();
                    OneLevel = classAndLevel[1].Trim();    
    
                    //Make sure the class is checked in clbClasses
                    for (int i = 0; i < clbClasses.Items.Count ; i++)
                    {
                        if (clbClasses.Items[i].ToString().Trim() == OneClass)
                        {
                            clbClasses.SetItemChecked(i, true);
                            SetClassTextBox(OneClass, OneLevel);
                        }
                    }
                }
            }
            blnLoadingExistingClasses = false;
        }

        #region Methods
        private void LoadPrestigeClassDropDown()
        {
            this.cmbPrestigeClasses.Items.Clear();

            Class objClass = new Class();
            List<Class> objClasses = new List<Class>();


            objClasses = objClass.GetClasses(" IsPrestige=1 ", " IsPrestige, ClassName");
            cmbPrestigeClasses.Items.Add("");
            foreach (Class lstClass in objClasses)
            {
                cmbPrestigeClasses.Items.Add(lstClass.ClassName );
            }
            if (dbconn.Open)
            {
                dbconn.CloseDatabaseConnection();
            }
        }

        public void LoadCheckedListBox(bool AddPrestige)
        {
            clbClasses.Items.Clear();
            //Dictionary<string, bool> dicObjClasses = new Dictionary<string, bool>();

            Class objClass = new Class();

            allClasses = objClass.GetClasses("", " IsPrestige,ClassName");

            clbClasses.MultiColumn = true;
            foreach (Class lstClass in allClasses)
            {
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

        private void ClearAndRestClasses()
        {
            clbClasses.Items.Clear();
            clbClasses.MultiColumn = true;
            foreach (Class lstClass in allClasses)
            {
                clbClasses.Items.Add(lstClass.ClassName);
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

        private void RemoveSelectedItemFromTextBoxes(string selectedItem)
        {
            //Dictionary<string, int> dicObjClasses = new Dictionary<string, int>();
            dicObjClasses.Clear();
            int intClassLevel = 0;
            int intTotalClassLevel = 0;
            //bool blnPrestigeEnabled = false;
            //bool blnPrestigeShouldBeEnabled;

            intTotalClassLevel = GetTotalClassLevel();

            //if (intTotalClassLevel >= 7) blnPrestigeEnabled = true; else blnPrestigeEnabled = false;

            //Go thru the text boxes, 
            //if not the selected item and not blank then add the class and level to the dictionary if they are not the selected item
            if (this.txtClass1.Text != selectedItem )
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

            //dicObjClasses.GetEnumerator();

            foreach (KeyValuePair <string,int> dicPair in dicObjClasses)
            {
                if (dicPair.Key != selectedItem)
                {
                    AddToSkillBoxes(dicPair);
                }
            }

            //TODO:  Put check in here to make sure visible class levels add to 7, if they do 
            //blnPrestigeShouldBeEnabled
            //int intTotalClassLevel = 0;
            //bool blnPrestigeEnabled;

            //intTotalClassLevel = GetTotalClassLevel();

            //if (intTotalClassLevel >=7 && !blnPrestigeEnabled)
            //{
            //    //Enable Prestige
            //}
            blnCheckingPrestige = false;
            CheckForPrestigeLevels();

            Class objClass = new Class();
            objClass.GetClass(selectedItem);
            lstClasses.Remove (objClass);
        }

        private void AddToSkillBoxes(KeyValuePair<string,int> objDicKeyValue)
        {
            if (this.txtClass1.Text == "" )
            {
                //int.TryParse(this.txtClassLevel1.Text, out intClassLevel);
                //dicObjClasses.Add(txtClass1.Text, intClassLevel);
                this.txtClass1.Text = objDicKeyValue.Key;
                this.txtClassLevel1.Text = objDicKeyValue.Value.ToString();
                return;
           }
            
            if (this.txtClassLevel2.Text == "")
            {
                this.txtClass2.Text = objDicKeyValue.Key;
                this.txtClassLevel2.Text = objDicKeyValue.Value.ToString();
                this.txtClass2.Visible = true;
                this.lblClass2.Visible = true;
                this.txtClassLevel2.Visible = true;
                return;
            }
            
            if (this.txtClassLevel3.Text == "")
            {
                this.txtClass3.Text = objDicKeyValue.Key;
                this.txtClassLevel3.Text = objDicKeyValue.Value.ToString();
                this.txtClass3.Visible = true;
                this.lblClass3.Visible = true;
                this.txtClassLevel3.Visible = true;
                return;
            }
            
            if (this.txtClassLevel4.Text == "")
            {
                this.txtClass4.Text = objDicKeyValue.Key;
                this.txtClassLevel4.Text = objDicKeyValue.Value.ToString();
                this.txtClass4.Visible = true;
                this.lblClass4.Visible = true;
                this.txtClassLevel4.Visible = true;
                return;
            }
            
            if (this.txtClassLevel5.Text == "")
            {
                this.txtClass5.Text = objDicKeyValue.Key;
                this.txtClassLevel5.Text = objDicKeyValue.Value.ToString();
                this.txtClass5.Visible = true;
                this.lblClass5.Visible = true;
                this.txtClassLevel5.Visible = true;
                return;
            }
            
            if (this.txtClassLevel6.Text == "")
            {
                this.txtClass6.Text = objDicKeyValue.Key;
                this.txtClassLevel6.Text = objDicKeyValue.Value.ToString();
                this.txtClass6.Visible = true;
                this.lblClass6.Visible = true;
                this.txtClassLevel6.Visible = true;
                return;
            }
            
            if (this.txtClassLevel7.Text == "")
            {
                this.txtClass7.Text = objDicKeyValue.Key;
                this.txtClassLevel7.Text = objDicKeyValue.Value.ToString();
                this.txtClass7.Visible = true;
                this.lblClass7.Visible = true;
                this.txtClassLevel7.Visible = true;
                return;
            }
            
            if (this.txtClassLevel8.Text == "")
            {
                this.txtClass8.Text = objDicKeyValue.Key;
                this.txtClassLevel8.Text = objDicKeyValue.Value.ToString();
                this.txtClass8.Visible = true;
                this.lblClass8.Visible = true;
                this.txtClassLevel8.Visible = true;
                return;
            }
            
            if (this.txtClassLevel9.Text == "")
            {
                this.txtClass9.Text = objDicKeyValue.Key;
                this.txtClassLevel9.Text = objDicKeyValue.Value.ToString();
                this.txtClass9.Visible = true;
                this.lblClass9.Visible = true;
                this.txtClassLevel9.Visible = true;
                return;
            }
        }

        private void ResetAndHideTextBoxes()
        {
            this.txtClass1.Text = "";
            this.txtClassLevel1.Text = "";

            this.txtClass2.Text = "";
            this.txtClass2.Visible = false;
            this.lblClass2.Visible = false;
            this.txtClassLevel2.Text = "";
            this.txtClassLevel2.Visible = false;

            this.txtClass3.Text = "";
            this.txtClass3.Visible = false;
            this.lblClass3.Visible = false;
            this.txtClassLevel3.Text = "";
            this.txtClassLevel3.Visible = false;

            this.txtClass4.Text = "";
            this.txtClass4.Visible = false;
            this.lblClass4.Visible = false;
            this.txtClassLevel4.Text = "";
            this.txtClassLevel4.Visible = false;

            this.txtClass5.Text = "";
            this.txtClass5.Visible = false;
            this.lblClass5.Visible = false;
            this.txtClassLevel5.Text = "";
            this.txtClassLevel5.Visible = false;

            this.txtClass6.Text = "";
            this.txtClass6.Visible = false;
            this.lblClass6.Visible = false;
            this.txtClassLevel6.Text = "";
            this.txtClassLevel6.Visible = false;

            this.txtClass7.Text = "";
            this.txtClass7.Visible = false;
            this.lblClass7.Visible = false;
            this.txtClassLevel7.Text = "";
            this.txtClassLevel7.Visible = false;

            this.txtClass8.Text = "";
            this.txtClass8.Visible = false;
            this.lblClass8.Visible = false;
            this.txtClassLevel8.Text = "";
            this.txtClassLevel8.Visible = false;

            this.txtClass9.Text = "";
            this.txtClass9.Visible = false;
            this.lblClass9.Visible = false;
            this.txtClassLevel9.Text = "";
            this.txtClassLevel9.Visible = false;

        }

        private void AddSelectedItemToTextBoxes(string selectedItem)
        {
            if (this.txtClass1.Text == "")
            {
                this.txtClass1.Text = selectedItem;
            }
            else if (this.txtClass2.Text == "")
            {
                this.txtClass2.Text = selectedItem;
                this.txtClass2.Visible = true;
                this.lblClass2.Visible = true;
                this.txtClassLevel2.Visible = true;
            }
            else if (this.txtClass3.Text == "")
            {
                this.txtClass3.Text = selectedItem;
                this.txtClass3.Visible = true;
                this.lblClass3.Visible = true;
                this.txtClassLevel3.Visible = true;
            }
            else if (this.txtClass4.Text == "")
            {
                this.txtClass4.Text = selectedItem;
                this.txtClass4.Visible = true;
                this.lblClass4.Visible = true;
                this.txtClassLevel4.Visible = true;
            }
            else if (this.txtClass5.Text == "")
            {
                this.txtClass5.Text = selectedItem;
                this.txtClass5.Visible = true;
                this.lblClass5.Visible = true;
                this.txtClassLevel5.Visible = true;
            }
            else if (this.txtClass6.Text == "")
            {
                this.txtClass6.Text = selectedItem;
                this.txtClass6.Visible = true;
                this.lblClass6.Visible = true;
                this.txtClassLevel6.Visible = true;
            }
            else if (this.txtClass7.Text == "")
            {
                this.txtClass7.Text = selectedItem;
                this.txtClass7.Visible = true;
                this.lblClass7.Visible = true;
                this.txtClassLevel7.Visible = true;
            }
            else if (this.txtClass8.Text == "")
            {
                this.txtClass8.Text = selectedItem;
                this.txtClass8.Visible = true;
                this.lblClass8.Visible = true;
                this.txtClassLevel8.Visible = true;
            }
            else if (this.txtClass9.Text == "")
            {
                this.txtClass9.Text = selectedItem;
                this.txtClass9.Visible = true;
                this.lblClass9.Visible = true;
                this.txtClassLevel9.Visible = true;
            }

            Class objClass = new Class();
            objClass.GetClass(selectedItem);
            lstClasses.Add(objClass);
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

        private void PopulateListView(string strType)
        {
            //Fill lvFeatTalentSkill with Feats
            lvFeatTalentSkill.Clear();
            this.lvFeatTalentSkill.Columns.Add("Description");


            switch (strType)
            {
                case "feats":
                    
                    //if (gprestigeRequirement.objRequiredFeats.Count > 0)
                    if (gPrestigeClass.objPrestigeRequiredFeats.Count > 0)
                    {
                        //foreach (Feat objFeat in gprestigeRequirement.objRequiredFeats)
                        foreach (Feat objFeat in gPrestigeClass.objPrestigeRequiredFeats)
                        {
                            //ListViewItem lvItem = Common.CreateListViewItem(objConditionTrack.Modifier, objConditionTrack.Description, true);
                            ListViewItem lvItem = Common.CreateListViewItem(objFeat.FeatID, objFeat.FeatName, false);
                            this.lvFeatTalentSkill.Items.Add(lvItem);
                        }
                    }
                    break;
                case "talents":
                    //if (gprestigeRequirement.objRequiredTalents.Count > 0)
                    if (gPrestigeClass.objPrestigeRequiredTalents.Count > 0)
                    {
                        //foreach (Talent objTalent in gprestigeRequirement.objRequiredTalents)
                        foreach (Talent objTalent in gPrestigeClass.objPrestigeRequiredTalents)
                        {
                            //ListViewItem lvItem = Common.CreateListViewItem(objConditionTrack.Modifier, objConditionTrack.Description, true);
                            ListViewItem lvItem = Common.CreateListViewItem(objTalent.TalentID, objTalent.TalentName, false);
                            this.lvFeatTalentSkill.Items.Add(lvItem);
                        }
                    }
                    break;
                case "skills":
                    //if (gprestigeRequirement.objRequiredSkills.Count > 0)
                    if (gPrestigeClass.objPrestigeRequiredSkills.Count > 0)
                    {
                        //foreach (Skill objSkill in gprestigeRequirement.objRequiredSkills)
                        foreach (Skill objSkill in gPrestigeClass.objPrestigeRequiredSkills)
                        {
                            //ListViewItem lvItem = Common.CreateListViewItem(objConditionTrack.Modifier, objConditionTrack.Description, true);
                            ListViewItem lvItem = Common.CreateListViewItem(objSkill.SkillID, objSkill.SkillName, false);
                            this.lvFeatTalentSkill.Items.Add(lvItem);
                        }
                    }
                    break;
                default:
                    break;
            }


            Common.FormatListViewControlColumns(lvFeatTalentSkill);
        }

        private void SaveClassList()
        {
            int totalClassLevel = 0;
            int intClassLevel = 0;

            if (this.txtClass1.Text != "")
            {
                AllClasses = this.txtClass1.Text + " - " + this.txtClassLevel1.Text;
                int.TryParse(txtClassLevel1.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass2.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass2.Text + " - " + this.txtClassLevel2.Text;
                int.TryParse(txtClassLevel2.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass3.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass3.Text + " - " + this.txtClassLevel3.Text;
                int.TryParse(txtClassLevel3.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass4.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass4.Text + " - " + this.txtClassLevel4.Text;
                int.TryParse(txtClassLevel4.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass5.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass5.Text + " - " + this.txtClassLevel5.Text;
                int.TryParse(txtClassLevel5.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass6.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass6.Text + " - " + this.txtClassLevel6.Text;
                int.TryParse(txtClassLevel6.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass7.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass7.Text + " - " + this.txtClassLevel7.Text;
                int.TryParse(txtClassLevel7.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass8.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass8.Text + " - " + this.txtClassLevel8.Text;
                int.TryParse(txtClassLevel8.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            if (this.txtClass9.Text != "")
            {
                AllClasses = AllClasses + "," + this.txtClass9.Text + " - " + this.txtClassLevel9.Text;
                int.TryParse(txtClassLevel9.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
            }

            CharacterLevel = totalClassLevel;
        }

        private bool ValidForm()
        {
            bool blnValidform = true;

            if (this.txtClass1.Text != "")
            {
                if (this.txtClassLevel1.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass2.Text != "")
            {
                if (this.txtClassLevel2.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass3.Text != "")
            {
                if (this.txtClassLevel3.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass4.Text != "")
            {
                if (this.txtClassLevel4.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass5.Text != "")
            {
                if (this.txtClassLevel5.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass6.Text != "")
            {
                if (this.txtClassLevel6.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass7.Text != "")
            {
                if (this.txtClassLevel7.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass8.Text != "")
            {
                if (this.txtClassLevel8.Text == "")
                {
                    blnValidform = false;
                }
            }

            if (this.txtClass9.Text != "")
            {
                if (this.txtClassLevel9.Text == "")
                {
                    blnValidform = false;
                }
            }

            return blnValidform;
        }

        private void SaveClassLevels()
        {
            int totalClassLevel = 0;
            int intClassLevel = 0;
            if (this.txtClassLevel1.Text != "")
            {
                int.TryParse(txtClassLevel1.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
                //AllLevels = this.txtClassLevel1.Text;
            }

            if (this.txtClassLevel2.Text != "")
            {
                int.TryParse(txtClassLevel2.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel; 
                //AllLevels = AllLevels + "," + this.txtClassLevel2.Text;
            }

            if (this.txtClassLevel3.Text != "")
            {
                int.TryParse(txtClassLevel3.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
                //AllLevels = AllLevels + "," + this.txtClassLevel3.Text;
            }

            if (this.txtClassLevel4.Text != "")
            {
                int.TryParse(txtClassLevel4.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel; 
                //AllLevels = AllLevels + "," + this.txtClassLevel4.Text;
            }

            if (this.txtClassLevel5.Text != "")
            {
                int.TryParse(txtClassLevel5.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel; 
                //AllLevels = AllLevels + "," + this.txtClassLevel5.Text;
            }

            if (this.txtClassLevel6.Text != "")
            {
                int.TryParse(txtClassLevel6.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
                //AllLevels = AllLevels + "," + this.txtClassLevel6.Text;
            }

            if (this.txtClassLevel7.Text != "")
            {
                int.TryParse(txtClassLevel7.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
                //AllLevels = AllLevels + "," + this.txtClassLevel7.Text;
            }

            if (this.txtClassLevel8.Text != "")
            {
                int.TryParse(txtClassLevel8.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
                //AllLevels = AllLevels + "," + this.txtClassLevel8.Text;
            }

            if (this.txtClassLevel9.Text != "")
            {
                int.TryParse(txtClassLevel9.Text, out intClassLevel);
                totalClassLevel = totalClassLevel + intClassLevel;
                //AllLevels = AllLevels + "," + this.txtClassLevel9.Text;
            }
            CharacterLevel = totalClassLevel;
        }

        private void  SetClassTextBox(string strClass, string strLevel)
        {
            if (this.txtClass1.Text == "")
            {
                this.txtClass1.Text = strClass;
                this.txtClassLevel1.Text = strLevel;
            }
            else if (this.txtClass2.Text == "")
            {
                this.txtClass2.Text = strClass;
                this.txtClassLevel2.Text = strLevel;
                this.txtClass2.Visible = true;
                this.txtClassLevel2.Visible = true;
                lblClass2.Visible = true;
            }
            else if (this.txtClass3.Text == "")
            {
                this.txtClass3.Text = strClass;
                this.txtClassLevel3.Text = strLevel;
                this.txtClass3.Visible = true;
                this.txtClassLevel3.Visible = true;
                lblClass3.Visible = true;
            }
            else if (this.txtClass4.Text == "")
            {
                this.txtClass4.Text = strClass;
                this.txtClassLevel4.Text = strLevel;
                this.txtClass4.Visible = true;
                this.txtClassLevel4.Visible = true;
                lblClass4.Visible = true;
            }
            else if (this.txtClass5.Text == "")
            {
                this.txtClass5.Text = strClass;
                this.txtClassLevel5.Text = strLevel;
                this.txtClass5.Visible = true;
                this.txtClassLevel5.Visible = true;
                lblClass5.Visible = true;
            }
            else if (this.txtClass6.Text == "")
            {
                this.txtClass6.Text = strClass;
                this.txtClassLevel6.Text = strLevel;
                this.txtClass6.Visible = true;
                this.txtClassLevel6.Visible = true;
                lblClass6.Visible = true;
            }
            else if (this.txtClass7.Text == "")
            {
                this.txtClass7.Text = strClass;
                this.txtClassLevel7.Text = strLevel;
                this.txtClass7.Visible = true;
                this.txtClassLevel7.Visible = true;
                lblClass7.Visible = true;
            }
            else if (this.txtClass8.Text == "")
            {
                this.txtClass8.Text = strClass;
                this.txtClassLevel8.Text = strLevel;
                this.txtClass8.Visible = true;
                this.txtClassLevel8.Visible = true;
                lblClass8.Visible = true;
            }
            else if (this.txtClass9.Text == "")
            {
                this.txtClass9.Text = strClass;
                this.txtClassLevel9.Text = strLevel;
                this.txtClass9.Visible = true;
                this.txtClassLevel2.Visible = true;
                lblClass9.Visible = true;
            }
        }
        #endregion

        #region Form Events
        private void txtClassLevel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel8_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void txtClassLevel9_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValuesOnly(e);
        }

        private void btnClearChecked_Click(object sender, EventArgs e)
        {
            blnCheckingPrestige = true;
            ClearAndRestClasses();
            ResetAndHideTextBoxes();
            blnCheckingPrestige = false;
        }

        private void clbClasses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!blnLoadingExistingClasses)
            {
                blnCheckingPrestige = true;

                if (e.NewValue == CheckState.Checked)
                {
                    //Add it to the list
                    AddSelectedItemToTextBoxes(clbClasses.SelectedItem.ToString());
                }
                else
                {
                    RemoveSelectedItemFromTextBoxes(clbClasses.SelectedItem.ToString());
                }
                blnCheckingPrestige = false;
            }
        }
       
        private void txtClassLevel1_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
           CheckForPrestigeLevels();
        }

        private void txtClassLevel2_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void txtClassLevel3_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void txtClassLevel4_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void txtClassLevel5_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void txtClassLevel6_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void txtClassLevel7_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void txtClassLevel8_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void txtClassLevel9_TextChanged(object sender, EventArgs e)
        {
            //ONLY DO THIS IF WE ARE NOT ADDING OR REMOVING CLASSES FROM THE TEXT BOXES
            CheckForPrestigeLevels();

        }

        private void cmbPrestigeClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrestigeClasses.SelectedItem.ToString() != "")
            {
                PrestigeRequirement prestigeRequirement = new PrestigeRequirement();
                Class objClass = new Class();

                objClass.GetClass(cmbPrestigeClasses.SelectedItem.ToString());

                //prestigeRequirement.GetPrestigeRequirement(objClass.ClassID);
                
                gPrestigeClass = objClass;
                gprestigeRequirement = objClass.objPrestigeRequirement;
                //gprestigeRequirement = prestigeRequirement;
                //Fill out the form with this info.  Not thought thru yet
                if (!string.IsNullOrEmpty(prestigeRequirement.PrestigeRequirementDescription))
                {
                    txtPrestigeRequirements.Text = prestigeRequirement.PrestigeRequirementDescription;
                }

                //Set the other tab like objects
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Save it here.");
            if (ValidForm())
            { 
                SaveClassList();
                //SaveClassLevels();

                this.Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("There are Classes assigned without levels assocated.  Verify that each class has a numeric level assigned to it.");
            }
        }

        private void tabpDescription_Click(object sender, EventArgs e)
        {
            //Show the Description TextBox
            txtPrestigeRequirements.Visible = true;
            lvFeatTalentSkill.Visible = false;
        }

        private void tbcPrestigeRequirements_Click(object sender, EventArgs e)
        {
            Point objPoint = new Point(8, 80);

            TabControl objTabControl = (TabControl)sender;
            //TabPage objTabPage = (TabPage)objTabControl.SelectedTab;


            this.lvFeatTalentSkill.Location = objPoint;
            this.lvFeatTalentSkill.Visible = true;
            this.txtPrestigeRequirements.Visible = false;

            switch (objTabControl.SelectedTab.Text.ToString().ToLower())
            {
                case "feats":
                    PopulateListView("feats");
                    break;
                case "skills":
                    PopulateListView("skills");
                    break;
                case "talents":
                    PopulateListView("talents");
                    break;
                case "description":
                    txtPrestigeRequirements.Text = "";
                    foreach (PrestigeRequirement objPR in gprestigeRequirement)
                    {
                        txtPrestigeRequirements.Text = txtPrestigeRequirements.Text + objPR.PrestigeRequirementDescription + "/r/n";
                    }
                    //txtPrestigeRequirements.Text = gprestigeRequirement.PrestigeRequirementDescription;
                    this.txtPrestigeRequirements.Location = objPoint;
                    this.lvFeatTalentSkill.Visible = false;
                    this.txtPrestigeRequirements.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion



    }
}
