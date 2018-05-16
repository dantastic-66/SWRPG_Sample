using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using StarWarsClasses;

namespace StarWarsRPG
{
    public class Common
    {
        public enum Ablilities { Strength, Intelligence, Wisdom, Dexterity, Constitution, Charisma }

        public enum strClassLevelInfoProps { Talent, BonusFeat, ForceSecret, ForceTechnique}

        public enum SkillFocusFeats { 
            SkillFocus_Acrobatics, 
            SkillFocus_Climb,
            SkillFocus_Deception, 
            SkillFocus_Endurance, 
            SkillFocus_GatherInformation, 
            SkillFocus_Initiative, 
            SkillFocus_Jump, 
            SkillFocus_Knowledge_Bureaucracy, 
            SkillFocus_Knowledge_GalacticLore, 
            SkillFocus_Knowledge_LifeSciences, 
            SkillFocus_Knowledge_PhysicalSciences, 
            SkillFocus_Knowledge_SocialSciences, 
            SkillFocus_Knowledge_Tactics, 
            SkillFocus_Knowledge_Technology, 
            SkillFocus_Mechanics, 
            SkillFocus_Perception, 
            SkillFocus_Persuation, 
            SkillFocus_Pilot, 
            SkillFocus_Ride, 
            SkillFocus_Stealth, 
            SkillFocus_Survival, 
            SkillFocus_Swim, 
            SkillFocus_TreatInjury,
            SkillFocus_UseComputer,
            SkillFocus_UsetheForce }

        public enum SkillTrainingFeats { 
            SkillTraining_Acrobatics, 
            SkillTraining_Climb, 
            SkillTraining_Deception, 
            SkillTraining_Endurance, 
            SkillTraining_GatherInformation, 
            SkillTraining_Initiative, 
            SkillTraining_Jump, 
            SkillTraining_Knowledge_Bureaucracy, 
            SkillTraining_Knowledge_GalacticLore, 
            SkillTraining_Knowledge_LifeSciences, 
            SkillTraining_Knowledge_PhysicalSciences, 
            SkillTraining_Knowledge_SocialSciences, 
            SkillTraining_Knowledge_Tactics, 
            SkillTraining_Knowledge_Technology,
            SkillTraining_Mechanics, 
            SkillTraining_Perception, 
            SkillTraining_Persuation, 
            SkillTraining_Pilot, 
            SkillTraining_Ride, 
            SkillTraining_Stealth, 
            SkillTraining_Survival, 
            SkillTraining_Swim, 
            SkillTraining_TreatInjury, 
            SkillTraining_UseComputer, 
            SkillTraining_UsetheForce}

        public enum searchType
        {
            Armor,
            Feat,
            ForcePower,
            Character,
            Equipment,
            Skill,
            SubSkill,
            Talent,
            Weapon
        }

        public enum FeatType
        {
            BonusFeat,
            LevelFeat,
            StartingFeat,
            RaceFeat
        }

        public enum DefenseType
        {
            Fortitude,
            Reflex,
            Will
        }

        public enum ModificationType
        {
            Armor,
            Equipment,
            Weapon
        }

        public enum ContainerObjectResetLevel
        {
            Abilities,
            Talents,
            Class,
            Character,
            BonusFeat,
            RaceFeat,
            LevelFeat,
            StartingFeat,
            ForcePowers,
            Skills,
            ForceSecret,
            ForceTechnique,
            Languages,
            ButtonsNeeded,
            All,
            AllButCharacter
        }

        public static void NumericValuesOnly (KeyPressEventArgs e, bool blnAllowNeg)
        {
            // NEG ("-") is 45
            char emptyChar;
            char.TryParse(string.Empty, out emptyChar);


            if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 8)
            {
                e.KeyChar = (Microsoft.VisualBasic.Strings.Chr(8));
            }
            else if (blnAllowNeg)
            { 
                if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 45)
                {
                    e.KeyChar = (Microsoft.VisualBasic.Strings.Chr(45));
                }
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = emptyChar;
            }

        }

        public static void NumericValuesOnly(KeyPressEventArgs e)
        {
            char emptyChar;
            char.TryParse(string.Empty, out emptyChar);


            if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar ) == 8)
            {
                e.KeyChar = (Microsoft.VisualBasic.Strings.Chr(8));
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = emptyChar;
            }
        }
        
        public static void LoadDictionaryWithDamageThresholdIncreases(out Dictionary<int,int> objDic,bool blnFeat)
        {
            objDic = new Dictionary<int,int>();
            if (blnFeat )
            {
                objDic.Add(1, Common.GetAppSettingsID("ImprovedDamageThresholdFeatID"));
            }
            //else
            //{
            //    //Nothing right now so don't add anything, empty dictioinary
            //}
        }

        public static void FormatListViewControlColumns(ListView lvControl)
        {
            for (int i = 0; i < lvControl.Columns.Count; i++)
            {
                lvControl.Columns[i].Width = -2;
            }
        }

        public static ListViewItem CreateListViewItem(int ID, string Description, bool WithSubItem)
        {
            ListViewItem lvReturnItem = new ListViewItem(ID.ToString());
            lvReturnItem.Tag = (int)ID;
            if (WithSubItem)
            {
                lvReturnItem.SubItems.Add(Description);
            }
            else
            {
                lvReturnItem.Text = Description;
            }

            return lvReturnItem;
        }

        public static ListViewItem CreateListViewItemHiddenID(int ID, string Col1, string Col2, bool WithSubItem)
        {
            ListViewItem lvReturnItem = new ListViewItem(Col1);
            lvReturnItem.Tag = (int)ID;
            if (WithSubItem)
            {
                lvReturnItem.SubItems.Add(Col2);
            }

            return lvReturnItem;
        }

        public static ListViewItem CreateListViewItem(int ID, string Name, string Description, bool WithSubItem)
        {
            ListViewItem lvReturnItem = new ListViewItem(ID.ToString());
            lvReturnItem.Tag = (int)ID;
            if (WithSubItem)
            {
                lvReturnItem.SubItems.Add(Name);
                lvReturnItem.SubItems.Add(Description);
            }
            else
            {
                lvReturnItem.Text = Name;
            }

            return lvReturnItem;
        }

        public static void CloseFormAndReturnToControlList(CharacterAddLevelContainer objCALC)
        {
            frmAddCharacterLevel_ControlList.objCALC = objCALC;
            frmAddCharacterLevel_ControlList frmControl = new frmAddCharacterLevel_ControlList();
            frmControl.Show();
        }


        //public static void CloseFormAndReturnToControlList(
        //    ref Class objSelectedClass,
        //    ref Character objCharacter,
        //    ref Character objOriginalCharacter,
        //    ref CharacterLevel objNewCharLevel,
        //    Talent objSelectedTalent,
        //    Ability objAbility1Modified,
        //    Ability objAbility2Modified,
        //    List<ForcePower> lstNewForcePowers,
        //    List<CharacterSkill> lstNewSkills,
        //    ForceSecret objForceSecret,
        //    ForceTechnique objForceTechnique,
        //    List<Language> lstLanguages,
        //    Feat objBonusFeat,
        //    Feat objCharLevelFeat,
        //    List<CharUpgradeButtonOptions> lstButtonsNeeded)
        //{
        //    frmAddCharacterLevel_ControlList.objSelectedClass = objSelectedClass;
        //    frmAddCharacterLevel_ControlList.objCharacter = objCharacter;
        //    frmAddCharacterLevel_ControlList.objNewCharLevel = objNewCharLevel;
        //    frmAddCharacterLevel_ControlList.objOriginalCharacter = objOriginalCharacter;
        //    //Change Skill MOdified to Ability Class
        //    frmAddCharacterLevel_ControlList.objSelectedTalent = objSelectedTalent;
        //    frmAddCharacterLevel_ControlList.objAbility1Modified = objAbility1Modified;
        //    frmAddCharacterLevel_ControlList.objAbility2Modified = objAbility2Modified;
        //    frmAddCharacterLevel_ControlList.lstNewForcePowers = lstNewForcePowers;
        //    frmAddCharacterLevel_ControlList.lstNewSkills = lstNewSkills;
        //    frmAddCharacterLevel_ControlList.objForceSecret = objForceSecret;
        //    frmAddCharacterLevel_ControlList.objForceTechnique = objForceTechnique;
        //    frmAddCharacterLevel_ControlList.lstLanguages = lstLanguages;
        //    frmAddCharacterLevel_ControlList.objSelectedTalent = objSelectedTalent;
        //    frmAddCharacterLevel_ControlList.objBonusFeat = objBonusFeat;
        //    frmAddCharacterLevel_ControlList.objCharLevelFeat = objCharLevelFeat;
        //    frmAddCharacterLevel_ControlList.lstButtonsNeeded = lstButtonsNeeded;
        //    frmAddCharacterLevel_ControlList frmControl = new frmAddCharacterLevel_ControlList();
        //    frmControl.Show();

        //    objSelectedClass = new Class();
        //    objCharacter = new Character();
        //    objOriginalCharacter = new Character();
        //    objNewCharLevel = new CharacterLevel();
        //}

        public static int GetCharSkillAbilityMod(Character objChar, Skill objSkill)
        {
            int retVal = 0;

            foreach (CharacterAbility objCharAbility in objChar.lstCharacterAbilities)
            {
                if (objCharAbility.AbilityID == objSkill.AbilityID)
                {
                    retVal = objCharAbility.ScoreMod;
                }
            }

            //switch (objSkill.objAbility.AbilityName.ToLower())
            //{
            //    case "strength":
            //        retVal = objChar.StrengthMod;
            //        break;
            //    case "intelligence":
            //        retVal = objChar.IntelligenceMod ;
            //        break;
            //    case "wisdom":
            //        retVal = objChar.WisdomMod ;
            //        break;
            //    case "dexterity":
            //        retVal = objChar.DexterityMod ;
            //        break;
            //    case "constitution":
            //        retVal = objChar.ConstitutionMod ;
            //        break;
            //    case "charisma":
            //        retVal = objChar.CharismaMod ;
            //        break;
            //    default:
            //       retVal = objChar.StrengthMod ;
            //        break;
            //}

            return retVal;
        }

        public static int GetAppSettingsID (string strKey)
        {
            AppSettingsReader asr = new System.Configuration.AppSettingsReader();
            string strTempVal = "";
            int intRetVal = 0;

            strTempVal = (string)asr.GetValue(strKey, typeof(string));

            int.TryParse(strTempVal , out intRetVal );
            return intRetVal;
        }

        public static int GetAppSettingsSkillFocusID( SkillFocusFeats sff)
        {
            int intRetVal = 0;

            AppSettingsReader asr = new System.Configuration.AppSettingsReader();
            string strTempVal = "";

            switch (sff)
            {
                case SkillFocusFeats.SkillFocus_Acrobatics:
                    strTempVal = (string)asr.GetValue("Skill Focus (Acrobatics)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Climb:
                    strTempVal = (string)asr.GetValue("Skill Focus (Climb)", typeof(string));
                  break;
                case SkillFocusFeats.SkillFocus_Deception:
                  strTempVal = (string)asr.GetValue("Skill Focus (Deception)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Endurance:
                    strTempVal = (string)asr.GetValue("Skill Focus (Endurance)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_GatherInformation:
                    strTempVal = (string)asr.GetValue("Skill Focus (Gather Information)", typeof(string));
                   break;
                case SkillFocusFeats.SkillFocus_Initiative:
                   strTempVal = (string)asr.GetValue("Skill Focus (Initiative)", typeof(string));
                  break;
                case SkillFocusFeats.SkillFocus_Jump:
                  strTempVal = (string)asr.GetValue("Skill Focus (Jump)", typeof(string));
                  break;
                case SkillFocusFeats.SkillFocus_Knowledge_Bureaucracy:
                  strTempVal = (string)asr.GetValue("Skill Focus (Knowledge - Bureaucracy)", typeof(string));
                 break;
                case SkillFocusFeats.SkillFocus_Knowledge_GalacticLore:
                 strTempVal = (string)asr.GetValue("Skill Focus (Knowledge - Galactic Lore)", typeof(string));
                  break;
                case SkillFocusFeats.SkillFocus_Knowledge_LifeSciences:
                  strTempVal = (string)asr.GetValue("Skill Focus (Knowledge - Life Sciences)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Knowledge_PhysicalSciences:
                    strTempVal = (string)asr.GetValue("Skill Focus (Knowledge - Physical Sciences)", typeof(string));
                   break;
                case SkillFocusFeats.SkillFocus_Knowledge_SocialSciences:
                   strTempVal = (string)asr.GetValue("Skill Focus (Knowledge - Social Sciences)", typeof(string));
                   break;
                case SkillFocusFeats.SkillFocus_Knowledge_Tactics:
                   strTempVal = (string)asr.GetValue("Skill Focus (Knowledge - Tactics)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Knowledge_Technology:
                    strTempVal = (string)asr.GetValue("Skill Focus (Knowledge - Technology)", typeof(string));
                  break;
                case SkillFocusFeats.SkillFocus_Mechanics:
                  strTempVal = (string)asr.GetValue("Skill Focus (Mechanics)", typeof(string));
                   break;
                case SkillFocusFeats.SkillFocus_Perception:
                   strTempVal = (string)asr.GetValue("Skill Focus (Perception)", typeof(string));
                   break;
                case SkillFocusFeats.SkillFocus_Persuation:
                   strTempVal = (string)asr.GetValue("Skill Focus (Persuation)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Pilot:
                    strTempVal = (string)asr.GetValue("Skill Focus (Pilot)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Ride:
                    strTempVal = (string)asr.GetValue("Skill Focus (Ride)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Stealth:
                    strTempVal = (string)asr.GetValue("Skill Focus (Stealth)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Survival:
                    strTempVal = (string)asr.GetValue("Skill Focus (Survival)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_Swim:
                    strTempVal = (string)asr.GetValue("Skill Focus (Swim)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_TreatInjury:
                    strTempVal = (string)asr.GetValue("Skill Focus (Treat Injury)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_UseComputer :
                    strTempVal = (string)asr.GetValue("Skill Focus (Use Computer)", typeof(string));
                    break;
                case SkillFocusFeats.SkillFocus_UsetheForce:
                    strTempVal = (string)asr.GetValue("Skill Focus (Use the Force)", typeof(string));
                    break;
                default:
                    strTempVal = (string)asr.GetValue("Skill Focus (Use the Force)", typeof(string));
                    break;
            }

            int.TryParse(strTempVal, out intRetVal);
            return intRetVal;
        }

        public static int GetAppSettingsSkillTrainingID(SkillTrainingFeats stf)
        {
            int intRetVal = 0;

            AppSettingsReader asr = new System.Configuration.AppSettingsReader();
            string strTempVal = "";

            switch (stf)
            {
                case SkillTrainingFeats.SkillTraining_Acrobatics :
                    strTempVal = (string)asr.GetValue("Skill Training (Acrobatics)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Climb:
                    strTempVal = (string)asr.GetValue("Skill Training (Climb)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Deception:
                    strTempVal = (string)asr.GetValue("Skill Training (Deception)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Endurance:
                    strTempVal = (string)asr.GetValue("Skill Training (Endurance)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_GatherInformation:
                    strTempVal = (string)asr.GetValue("Skill Training (Gather Information)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Initiative:
                    strTempVal = (string)asr.GetValue("Skill Training (Initiative)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Jump:
                    strTempVal = (string)asr.GetValue("Skill Training (Jump)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Knowledge_Bureaucracy:
                    strTempVal = (string)asr.GetValue("Skill Training (Knowledge - Bureaucracy)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Knowledge_GalacticLore:
                    strTempVal = (string)asr.GetValue("Skill Training (Knowledge - Galactic Lore)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Knowledge_LifeSciences:
                    strTempVal = (string)asr.GetValue("Skill Training (Knowledge - Life Sciences)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Knowledge_PhysicalSciences:
                    strTempVal = (string)asr.GetValue("Skill Training (Knowledge - Physical Sciences)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Knowledge_SocialSciences:
                    strTempVal = (string)asr.GetValue("Skill Training (Knowledge - Social Sciences)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Knowledge_Tactics:
                    strTempVal = (string)asr.GetValue("Skill Training (Knowledge - Tactics)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Knowledge_Technology:
                    strTempVal = (string)asr.GetValue("Skill Training (Knowledge - Technology)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Mechanics:
                    strTempVal = (string)asr.GetValue("Skill Training (Mechanics)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Perception:
                    strTempVal = (string)asr.GetValue("Skill Training (Perception)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Persuation:
                    strTempVal = (string)asr.GetValue("Skill Training (Persuation)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Pilot:
                    strTempVal = (string)asr.GetValue("Skill Training (Pilot)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Ride:
                    strTempVal = (string)asr.GetValue("Skill Training (Ride)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Stealth:
                    strTempVal = (string)asr.GetValue("Skill Training (Stealth)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Survival:
                    strTempVal = (string)asr.GetValue("Skill Training (Survival)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_Swim:
                    strTempVal = (string)asr.GetValue("Skill Training (Swim)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_TreatInjury:
                    strTempVal = (string)asr.GetValue("Skill Training (Treat Injury)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_UseComputer:
                    strTempVal = (string)asr.GetValue("Skill Training (Use Computer)", typeof(string));
                    break;
                case SkillTrainingFeats.SkillTraining_UsetheForce:
                    strTempVal = (string)asr.GetValue("Skill Training (Use the Force)", typeof(string));
                    break;
                default:
                    strTempVal = (string)asr.GetValue("Skill Training (Use the Force)", typeof(string));
                    break;
            }

            int.TryParse(strTempVal, out intRetVal);
            return intRetVal;
        }

        //public static Dictionary<int,string>GetDictionaryForComboBox<T> (ref List<T> lstGeneric)
        //{
            
        //    Dictionary<int, string> objDic = new Dictionary<int, string>();

        //    foreach (T objGeneric  in lstGeneric )
        //    {
                
        //    }
        //    return objDic;
        //}
    //        Private Sub NumericValuesOnly(ByRef e As KeyPressEventArgs)
    //    If Asc(e.KeyChar) = 8 Then
    //        e.KeyChar = Chr(8)
    //    ElseIf (Not IsNumeric(e.KeyChar)) Then
    //        e.KeyChar = ""
    //    Else
    //    End If
    //End Sub

        public static string PascalNoteString (string strTempString)
        {
            string strRetVar = "";

            strRetVar = strTempString.Substring(0, 1).ToUpper();
            strRetVar = strRetVar + strTempString.Substring(1, strTempString.Length).ToLower();

            return strRetVar;

        }
    }
}
