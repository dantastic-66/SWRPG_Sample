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
    public partial class frmSearch : Form
    {
        public Common.searchType searchType;
        private Form _frmCallingForm;

        #region Constructors
        public frmSearch()
        {
            InitializeComponent();
            this.SetBounds(this.Left, this.Top, this.Width, 123);
        }

        public frmSearch(Common.searchType  typeSearch, Form frmCallingForm)
        {
            InitializeComponent();
            this.SetBounds(this.Left, this.Top, this.Width, 123);
            searchType = typeSearch;
            _frmCallingForm = frmCallingForm;
            switch (typeSearch)
            {
                case Common.searchType.Armor:
                    this.Text = "Search Armor";
                    break;
                case Common.searchType.Feat:
                    this.Text = "Search Feat";
                    break;
                case Common.searchType.ForcePower:
                    this.Text = "Search Force Power";
                    break;
                case Common.searchType.Character:
                    this.Text = "Search Character";
                    break;
                case Common.searchType.Equipment:
                    this.Text = "Search Equipment";
                    break;
                case Common.searchType.SubSkill:
                    this.Text = "Search SubSkill";
                    break;
                case Common.searchType.Talent:
                    this.Text = "Search Talent";
                    break;
                case Common.searchType.Weapon:
                    this.Text = "Search Weapon";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Form Events
        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchOrderBy = "";
            string searchFilter = "";

            switch (searchType)
            {
                case Common.searchType.Armor:
                    searchOrderBy = "ArmorName"; 
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "ArmorName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "ArmorName = '" + txtSearch.Text + "'";
                    }
                    Armor Armor = new Armor();
                    List<Armor> Armors = new List<Armor>();
                    Armors = Armor.GetArmors (searchFilter, searchOrderBy);
                    SetFormForArmor(Armors);
                    break;
                case Common.searchType.Feat:
                    searchOrderBy = "FeatName"; 
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "FeatName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "FeatName = '" + txtSearch.Text + "'";
                    }
                    Feat objFeat = new Feat();
                    List<Feat> Feats = new List<Feat>();
                    Feats = objFeat.GetFeats(searchFilter, searchOrderBy);
                    SetFormForFeat(Feats);
                    break;
                case Common.searchType.ForcePower:
                    searchOrderBy = "ForcePowerName"; 
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "ForcePowerName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "ForcePowerName = '" + txtSearch.Text + "'";
                    }
                    ForcePower objForcePower = new ForcePower();
                    List<ForcePower> ForcePowers = new List<ForcePower>();
                    ForcePowers = objForcePower.GetForcePowers (searchFilter, searchOrderBy);
                    SetFormForForcePower(ForcePowers);
                    break;
                case Common.searchType.Character:
                    searchOrderBy = "CharacterName"; 
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "CharacterName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "CharacterName = '" + txtSearch.Text + "'";
                    }
                    Character objCharacter = new Character();
                    List<Character> Characters = new List<Character>();
                    Characters = objCharacter.GetCharacters (searchFilter, searchOrderBy);
                    SetFormForCharacter(Characters);
                    break;
                case Common.searchType.Equipment:
                    searchOrderBy = "EquipmentName"; 
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "EquipmentName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "EquipmentName = '" + txtSearch.Text + "'";
                    }
                    Equipment objEquipment = new Equipment();
                    List<Equipment> equipmentList = new List<Equipment>();
                    equipmentList = objEquipment.GetEquipment (searchFilter, searchOrderBy);
                    SetFormForEquipment(equipmentList);
                    break;
                case Common.searchType.Skill:
                    searchOrderBy = "SkillName";
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "SkillName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "SkillName = '" + txtSearch.Text + "'";
                    }
                    Skill objSkill = new Skill();
                    List<Skill> objSkills = new List<Skill>();
                    objSkills = objSkill.GetSkills(searchFilter, searchOrderBy);
                    SetFormForSkill(objSkills);
                    break;
                case Common.searchType.Talent:
                    searchOrderBy = "TalentName";
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "TalentName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "TalentName = '" + txtSearch.Text + "'";
                    }
                    Talent objTalent = new Talent();
                    List<Talent> Talents = new List<Talent>();
                    Talents = objTalent.GetTalents(searchFilter, searchOrderBy);
                    SetFormForTalent(Talents);
                    break;
                case Common.searchType.Weapon :
                    searchOrderBy = "WeaponName";
                    if (txtSearch.Text.Contains("%"))
                    {
                        searchFilter = "WeaponName LIKE '" + txtSearch.Text + "'";
                    }
                    else
                    {
                        searchFilter = "WeaponName = '" + txtSearch.Text + "'";
                    }
                    Weapon objWeapon = new Weapon();
                    List<Weapon> Weapons = new List<Weapon>();
                    Weapons = objWeapon.GetWeapons(searchFilter, searchOrderBy);
                    SetFormForWeapon(Weapons);
                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvSearchResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lvSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (searchType)
            {
                case Common.searchType.Armor:
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmArmor":
                            frmArmor.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;
                case Common.searchType.Feat:
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmFeat":
                            frmFeat.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;

                case Common.searchType.ForcePower:
                     switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmForcePower":
                            frmForcePower.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;
                case Common.searchType.Character:
                    int intCharID = 0;
                    int.TryParse(lvSearchResults.SelectedItems[0].Tag.ToString(), out intCharID);
                    Character objChar = new Character(intCharID);

                    frmMain.objCurrentChar = objChar;
                    break;
                case Common.searchType.Equipment:
                     switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmEquipment":
                            frmEquipment.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;
                case Common.searchType.Skill:
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmSkill":
                            frmEquipment.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;
                case Common.searchType.SubSkill:
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmSkill":
                            frmEquipment.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;
                case Common.searchType.Talent:
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmSkill":
                            frmEquipment.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;
                case Common.searchType.Weapon:
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                        case "frmSkill":
                            frmEquipment.intSearchID = (int)lvSearchResults.SelectedItems[0].Tag;
                            break;
                    }
                    break;
                default:
                    break;
            }
            //switch (searchType)
            //{
            //    case Common.searchType.Game:
            //        //frmMain.gameNameSearchId = (int)lvSearchResults.SelectedItems[0].Tag;
            //        break;
            //    case Common.searchType.Genre:
            //        //frmGenre.genreSearchId = (int)lvSearchResults.SelectedItems[0].Tag;
            //        break;
            //    case Common.searchType.Ownership:
            //        break;
            //    case Common.searchType.Platform:
            //        break;
            //    case Common.searchType.GuideBook:
            //        break;
            //    default:
                    
            //        break;
            //}
           
            this.Close();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the KeyDown event of the txtSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //Check to see if its the enter key, if so execute the button Click
            if (e.KeyValue.ToString() == "13")
            {
                btnSearch_Click(sender, e);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the form for armor.
        /// </summary>
        /// <param name="objArmors">The object armors.</param>
        private void SetFormForArmor(List<Armor> objArmors)
        {
            if (objArmors.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objArmors.Count == 1)
            {
                foreach (Armor objArmor in objArmors)
                {
                    //Whatever form called this we need to set the armor id there
                    //frmMain.intSearchID = objArmor.ArmorID;
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = objArmor.ArmorID;
                            break;
                        case "frmArmor":
                            frmArmor.intSearchID = objArmor.ArmorID;
                            break;
                    }
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("Armor ID");
                this.lvSearchResults.Columns.Add("Armor Name");
                foreach (Armor objArmor in objArmors)
                {
                    //frmMain.gameNameSearchId = objArmor.ArmorID;
                    ListViewItem lvItem = Common.CreateListViewItem(objArmor.ArmorID, objArmor.ArmorName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for feat.
        /// </summary>
        /// <param name="objFeats">The object feats.</param>
        private void SetFormForFeat(List<Feat> objFeats)
        {
            if (objFeats.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objFeats.Count == 1)
            {
                foreach (Feat objFeat in objFeats)
                {
                    //frmMain.gameNameSearchId = objFeat.FeatID;
                    //frmMain.intSearchID = objFeat.FeatID;
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = objFeat.FeatID;
                            break;
                        case "frmFeat":
                            frmFeat.intSearchID = objFeat.FeatID;
                            break;
                    }
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("ID");
                this.lvSearchResults.Columns.Add("Feat Name");
                foreach (Feat objFeat in objFeats)
                {
                    //frmMain.gameNameSearchId = objFeat.FeatID;
                    ListViewItem lvItem = Common.CreateListViewItem(objFeat.FeatID, objFeat.FeatName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for force power.
        /// </summary>
        /// <param name="objForcePowers">The object force powers.</param>
        private void SetFormForForcePower(List<ForcePower> objForcePowers)
        {
            if (objForcePowers.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objForcePowers.Count == 1)
            {
                foreach (ForcePower objForcePower in objForcePowers)
                {
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = objForcePower.ForcePowerID;
                            break;
                        case "frmForcePower":
                            frmFeat.intSearchID = objForcePower.ForcePowerID;
                            break;
                    }
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("ID");
                this.lvSearchResults.Columns.Add("Force Power Name");
                foreach (ForcePower objForcePower in objForcePowers)
                {
                    ListViewItem lvItem = Common.CreateListViewItem(objForcePower.ForcePowerID, objForcePower.ForcePowerName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for character.
        /// </summary>
        /// <param name="objCharacters">The object characters.</param>
        private void SetFormForCharacter(List<Character> objCharacters)
        {
            if (objCharacters.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objCharacters.Count == 1)
            {
                foreach (Character objCharacter in objCharacters)
                {
                    frmMain.objCurrentChar = objCharacter ;
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("ID");
                this.lvSearchResults.Columns.Add("Character Name");
                foreach (Character objCharacter in objCharacters)
                {
                    //frmMain.gameNameSearchId = objCharacter.CharacterID;
                    ListViewItem lvItem = Common.CreateListViewItem(objCharacter.CharacterID, objCharacter.CharacterName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for equipment.
        /// </summary>
        /// <param name="objEquipmentList">The object equipment list.</param>
        private void SetFormForEquipment(List<Equipment> objEquipmentList)
        {
            if (objEquipmentList.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objEquipmentList.Count == 1)
            {
                foreach (Equipment objEquipment in objEquipmentList)
                {
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = objEquipment.EquipmentID ;
                            break;
                        case "frmEquipment":
                            frmEquipment.intSearchID = objEquipment.EquipmentID;
                            break;
                    }
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("ID");
                this.lvSearchResults.Columns.Add("Equipment Name");
                foreach (Equipment objEquipment in objEquipmentList)
                {
                    //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                    ListViewItem lvItem = Common.CreateListViewItem(objEquipment.EquipmentID, objEquipment.EquipmentName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for skill.
        /// </summary>
        /// <param name="objSkills">The object skills.</param>
        private void SetFormForSkill(List<Skill> objSkills)
        {
            if (objSkills.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objSkills.Count == 1)
            {
                foreach (Skill objSkill in objSkills)
                {
                    switch (_frmCallingForm.Name.ToString())
                    {
                        case "frmMain":
                            frmMain.intSearchID = objSkill.SkillID;
                            break;
                        case "frmSkill":
                            frmEquipment.intSearchID = objSkill.SkillID;
                            break;
                    }
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("ID");
                this.lvSearchResults.Columns.Add("Skill Name");
                foreach (Skill objSkill in objSkills)
                {
                    //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                    ListViewItem lvItem = Common.CreateListViewItem(objSkill.SkillID, objSkill.SkillName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for talent.
        /// </summary>
        /// <param name="objTalents">The object talents.</param>
        private void SetFormForTalent(List<Talent> objTalents)
        {
            if (objTalents.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objTalents.Count == 1)
            {
                foreach (Talent objTalent in objTalents)
                {
                    //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("ID");
                this.lvSearchResults.Columns.Add("Talent Name");
                foreach (Talent objTalent in objTalents)
                {
                    //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                    ListViewItem lvItem = Common.CreateListViewItem(objTalent.TalentID, objTalent.TalentName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for weapon.
        /// </summary>
        /// <param name="objWeapons">The object weapons.</param>
        private void SetFormForWeapon(List<Weapon> objWeapons)
        {
            if (objWeapons.Count == 0)
            {
                SetFormForNoRecords(txtSearch.Text);
            }
            else if (objWeapons.Count == 1)
            {
                foreach (Weapon objWeapon in objWeapons)
                {
                    //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.lblNoResults.Visible = false;
                this.lvSearchResults.Visible = true;
                this.SetBounds(this.Left, this.Top, this.Width, 285);
                this.lvSearchResults.Columns.Add("ID");
                this.lvSearchResults.Columns.Add("Weapon Name");
                foreach (Weapon objWeapon in objWeapons)
                {
                    //frmMain.gameNameSearchId = objGuideBook.EquipmentID;
                    ListViewItem lvItem = Common.CreateListViewItem(objWeapon.WeaponID, objWeapon.WeaponName, true);
                    this.lvSearchResults.Items.Add(lvItem);
                }
                Common.FormatListViewControlColumns(lvSearchResults);
            }
        }

        /// <summary>
        /// Sets the form for no records.
        /// </summary>
        /// <param name="strSearch">The string search.</param>
        private void SetFormForNoRecords(string strSearch)
        {
            this.lvSearchResults.Visible = false;
            this.SetBounds(this.Left, this.Top, this.Width, 123);
            this.lblNoResults.Visible = true;
            this.lblNoResults.Text = "No Results found for: " + strSearch;
        }
        #endregion


    }
}
