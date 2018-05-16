using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using StarWarsClasses;
using System.Configuration;
using System.Data.SqlClient;

namespace StarWarsRPG
{
    public partial class frmReportViewer : Form
    {
        
        public frmReportViewer()
        {
           
            InitializeComponent();
            ShowReport();
        }

        private void ShowReport()
        { 
            //TO become paramters for method
            string strReportDataBase = ConfigurationManager.ConnectionStrings["StarWarsRPGDB"].ConnectionString;
            string strSprocName = "Select_Feat";
            string strWhere = "FeatID IN (1,2)";
            string strOrderBy = "FeatName";
            //End of parameters

            ReportDataSource objRDS = new ReportDataSource(strReportDataBase);
            objRDS.Name = "rptDataSet";
            objRDS.Value = DatabaseConnection.LoadDataAdapters(strReportDataBase, "EXEC " + strSprocName + "  '" + strWhere + "' , '" + strOrderBy +"'" );

            rvReportViewer.ProcessingMode = ProcessingMode.Local;

            rvReportViewer.LocalReport.DisplayName = "Sample Feat Report";
            rvReportViewer.LocalReport.ReportPath = "Reports\\FeatReport.rdl";


            rvReportViewer.LocalReport.DataSources.Add(objRDS);

            ReportParameter rpReportParam1 = new ReportParameter();
            ReportParameter rpReportParam2 = new ReportParameter();

           
            rpReportParam1.Name = "strWhere";
            rpReportParam1.Values.Add(strWhere);
            
            rpReportParam2.Name = "strOrderBy";
            rpReportParam2.Values.Add(strOrderBy); 

            ReportParameter[] arrParams = { rpReportParam1, rpReportParam2 };
            rvReportViewer.LocalReport.SetParameters(arrParams);
            rvReportViewer.Refresh();
            
        }

        private DataTable SetCharToDataTable(Character objChar)
        {
            DataTable retVal = new DataTable();
            retVal.Columns.Add("CharacterID");
            retVal.Columns.Add("CharacterName");
            retVal.Columns.Add("Strength");
            retVal.Columns.Add("StrengthMod");
            retVal.Columns.Add("Intelligence");
            retVal.Columns.Add("IntelligenceMod");
            retVal.Columns.Add("Wisdom");
            retVal.Columns.Add("WisdomMod");
            retVal.Columns.Add("Dexterity");
            retVal.Columns.Add("DexterityMod");
            retVal.Columns.Add("Constitution");
            retVal.Columns.Add("ConstitutionMod");
            retVal.Columns.Add("Charisma");
            retVal.Columns.Add("CharismaMod");
            retVal.Columns.Add("FortitudeDefenseID");
            retVal.Columns.Add("ReflexDefenseID");
            retVal.Columns.Add("WillDefenseID");
            retVal.Columns.Add("CharacterLevelID");
            retVal.Columns.Add("RaceID");
            retVal.Columns.Add("ExperiencePoints");
            retVal.Columns.Add("HitPoints");
            retVal.Columns.Add("Movement");
            retVal.Columns.Add("ForcePoints");
            retVal.Columns.Add("DestintyPoints");
            retVal.Columns.Add("DarkSidePoints");
            retVal.Columns.Add("BaseAttack");
            retVal.Columns.Add("Grapple");
            retVal.Columns.Add("DamageThreshold");
            retVal.Columns.Add("Encumberance");
            retVal.Columns.Add("ConditionTrackID");
            retVal.Columns.Add("CharacterAge");
            retVal.Columns.Add("ArmorID");
            retVal.Columns.Add("Sex");
            retVal.Columns.Add("ForceTradtionID");
            retVal.Columns.Add("ForceSensitive");

            string[] charArray = new string[35];
            charArray[0] = objChar.CharacterID.ToString();
            charArray[1] = objChar.CharacterName.ToString();
            //charArray[2] = objChar.Strength.ToString();
            //charArray[3] = objChar.StrengthMod.ToString();
            //charArray[4] = objChar.Intelligence.ToString();
            //charArray[5] = objChar.IntelligenceMod.ToString();
            //charArray[6] = objChar.Wisdom.ToString();
            //charArray[7] = objChar.WisdomMod.ToString();
            //charArray[8] = objChar.Dexterity.ToString();
            //charArray[9] = objChar.DexterityMod.ToString();
            //charArray[10] = objChar.Constitution.ToString();
            //charArray[11] = objChar.ConstitutionMod.ToString();
            //charArray[12] = objChar.Charisma.ToString();
            //charArray[13] = objChar.CharismaMod.ToString();
            //charArray[14] = objChar.FortitudeDefenseID.ToString();
            //charArray[15] = objChar.ReflexDefenseID.ToString();
            //charArray[16] = objChar.WillDefenseID.ToString();
            charArray[17] = objChar.CharacterLevelID.ToString();
            charArray[18] = objChar.RaceID.ToString();
            charArray[19] = objChar.ExperiencePoints.ToString();
            //charArray[20] = objChar.Movement.ToString();
            charArray[21] = objChar.ForcePoints.ToString();
            charArray[22] = objChar.DestintyPoints.ToString();
            charArray[23] = objChar.DarkSidePoints.ToString();
            charArray[24] = objChar.BaseAttack.ToString();
            charArray[25] = objChar.Grapple.ToString();
            charArray[26] = objChar.DamageThreshold.ToString();
            charArray[27] = objChar.Encumberance.ToString();
            charArray[28] = objChar.ConditionTrackID.ToString();
            charArray[29] = objChar.CharacterAge.ToString();
            charArray[30] = objChar.ArmorID.ToString();
            //charArray[31] = objChar.ConstitutionMod.ToString();
            charArray[32] = objChar.Sex.ToString();
            charArray[33] = objChar.ForceTraditionID.ToString();
            charArray[34] = objChar.ForceSensitive.ToString();

             retVal.Rows.Add(charArray);
             return retVal;
        }
    
        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            this.rvReportViewer.RefreshReport();
        }
    }
}
