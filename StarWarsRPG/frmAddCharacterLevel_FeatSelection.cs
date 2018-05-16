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
    public partial class frmAddCharacterLevel_FeatSelection : Form
    {
        //New Object that contains all the above items
        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();
        //public static bool blnBonusFeat;
        public static Common.FeatType enmFeatType;

        #region Form Events
        public frmAddCharacterLevel_FeatSelection()
        {
            //objOriginalCharacter = objCharacter;
            InitializeComponent();
            if (enmFeatType != Common.FeatType.BonusFeat  )
            {
                this.ckbRemoveBonusFeats.Visible = true;
            }
            //this.ckbRemoveBonusFeats.Visible = !blnBonusFeat;

            switch (enmFeatType )
            {
                case Common.FeatType.BonusFeat:
                    gpFeats.Text = "Select Bonus Feat";
                    break;
                case Common.FeatType.LevelFeat:
                    gpFeats.Text = "Select Level Feat";
                    break;
                case Common.FeatType.RaceFeat :
                    gpFeats.Text = "Select Race Bonus Feat";
                    break;
                case Common.FeatType.StartingFeat:
                    gpFeats.Text = "Select Starting Feat";
                    break;
                default:
                    break;
            }
            //if (blnBonusFeat) gpFeats.Text = "Select Bonus Feat"; else gpFeats.Text = "Select Level Feat";
            LoadTreeView();
        }

        private void tvFeatList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetFeatFields();
            btnSelectFeat.Enabled = true;
        }

        private void ckbRemoveBonusFeats_CheckedChanged(object sender, EventArgs e)
        {
            LoadTreeView();
            btnSelectFeat.Enabled = false;
        }

        private void btnSelectFeat_Click(object sender, EventArgs e)
        {
            string strTag = tvFeatList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Feat objFeat = new Feat();
                objFeat.GetFeat(intTag);

                //Get the Feat and send it back to the control page

                //if (blnBonusFeat)
                //{
                //    objCALC.objBonusFeat = objFeat;
                //}
                //else
                //{
                //    objCALC.objCharLevelFeat = objFeat;
                //}

                switch (enmFeatType)
                {
                    case Common.FeatType.BonusFeat:
                        objCALC.objBonusFeat = objFeat;
                        break;
                    case Common.FeatType.LevelFeat:
                        objCALC.objCharLevelFeat = objFeat;
                        break;
                    case Common.FeatType.StartingFeat:
                        objCALC.lstStartingFeat.Add(objFeat);
                        break;
                    case Common.FeatType.RaceFeat :
                        objCALC.objRaceFeat = objFeat;
                        break;
                    default:
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a Feat.");
            }
        }

        private void frmAddCharacterLevel_FeatSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }
        #endregion

        #region Methods
        public void LoadTreeView()
        {
            tvFeatList.Nodes.Clear();

            List<Feat> lstFeats = new List<Feat>();
            Feat objFeat = new Feat();

            switch (enmFeatType)
            {
                case Common.FeatType.BonusFeat:
                    lstFeats = Feat.RemoveFeatListFromList(objCALC.objCharacter.lstFeats, objFeat.GetBonusFeatsForClass(objCALC.objSelectedClass));
                    break;
                case Common.FeatType.LevelFeat:
                    if (ckbRemoveBonusFeats.Checked ) 
                    {
                        //Remove bonus feats from list of all feats
                        lstFeats = Feat.RemoveFeatListFromList(objFeat.GetBonusFeatsForClass(objCALC.objSelectedClass), Feat.GetAllFeatsCharacterQualifedFor(objCALC.objCharacter));
                    }
                    else 
                    {
                        lstFeats = Feat.GetAllFeatsCharacterQualifedFor(objCALC.objCharacter);
                    }
                    break;
                case Common.FeatType.StartingFeat:
                    lstFeats = Feat.RemoveFeatListFromList(objCALC.objCharacter.lstFeats, objFeat.GetStartingFeats(objCALC.objSelectedClass.ClassID ));
                    break;
                case Common.FeatType.RaceFeat:
                    if (ckbRemoveBonusFeats.Checked)
                    {
                        //Remove bonus feats from list of all feats
                        lstFeats = Feat.RemoveFeatListFromList(objFeat.GetBonusFeatsForClass(objCALC.objSelectedClass), Feat.GetAllFeatsCharacterQualifedFor(objCALC.objCharacter));
                    }
                    else
                    {
                        lstFeats = Feat.GetAllFeatsCharacterQualifedFor(objCALC.objCharacter);
                    }
                    break;
                default:
                    break;
            }

            //if (enmFeatType == Common.FeatType.BonusFeat)
            //{
            //    lstFeats = Feat.RemoveFeatListFromList(objCALC.objCharacter.objFeats, objFeat.GetBonusFeatsForClass(objCALC.objSelectedClass));
            //}
            //else
            //{
            //    if (ckbRemoveBonusFeats.Checked ) 
            //    {
            //        //Remove bonus feats from list of all feats
            //        lstFeats = Feat.RemoveFeatListFromList(objFeat.GetBonusFeatsForClass(objCALC.objSelectedClass), Feat.GetAllFeatsCharacterQualifedFor(objCALC.objCharacter));
            //    }
            //    else 
            //    {
            //        lstFeats = Feat.GetAllFeatsCharacterQualifedFor(objCALC.objCharacter);
            //    }
            //}

            foreach (Feat objListFeat in lstFeats)
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objListFeat.FeatName ;
                objTN.Tag = objListFeat.FeatID  ;
                tvFeatList.Nodes.Add(objTN);
            }
        }

        public void SetFeatFields()
        {
            string strTag = tvFeatList.SelectedNode.Tag.ToString();
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                Feat objFeat = new Feat();
                objFeat.GetFeat(intTag);
                bool blnMultiple;

                this.txtFeatName.Text = objFeat.FeatName;
                this.txtFeatDescription.Text = objFeat.FeatDescription;
                this.txtFeatSpecial.Text = objFeat.FeatSpecial;

                this.ckbRageRequired.Checked = objFeat.RageRequired;
                this.ckbShapeShiftRequired.Checked = objFeat.ShapeShiftRequired;
                bool.TryParse(objFeat.MultipleSelection.ToString(), out blnMultiple);
                this.ckMultipleAllowed.Checked = blnMultiple;
            }
        }

        #endregion

    }
}
