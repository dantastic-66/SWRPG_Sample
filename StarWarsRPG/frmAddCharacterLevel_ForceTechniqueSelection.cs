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
    public partial class frmAddCharacterLevel_ForceTechniqueSelection : Form
    {
        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();

        #region Form Events
        public frmAddCharacterLevel_ForceTechniqueSelection()
        {
            InitializeComponent();
            LoadTreeView();
        }

        private void tvForceTechnique_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetForcePowerFields(tvForceTechnique.SelectedNode.Tag.ToString());
        }

        private void btnSelectForceTechnique_Click(object sender, EventArgs e)
        {
            string strTag = "";
            int intTag = 0;

            strTag = tvForceTechnique.SelectedNode.Tag.ToString();
            int.TryParse(strTag, out intTag);
            objCALC.objForceTechnique.GetForceTechnique(intTag);

            this.Close();
        }

        private void frmAddCharacterLevel_ForceTechniqueSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }
        #endregion

        #region Methods
        private void LoadTreeView()
        {
            this.tvForceTechnique.Nodes.Clear();

            List<ForceTechnique> lstForceTechniques = new List<ForceTechnique>();
            ForceTechnique objFS = new ForceTechnique();

            lstForceTechniques = objFS.GetForceTechniques ("", "");

            foreach (ForceTechnique objListForceTechnique in lstForceTechniques)
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objListForceTechnique.ForceTechniqueName;
                objTN.Tag = objListForceTechnique.ForceTechniqueID;
                tvForceTechnique.Nodes.Add(objTN);
            }
        }

        public void SetForcePowerFields(string strTag)
        {
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                ForceTechnique objFS = new ForceTechnique();
                objFS.GetForceTechnique (intTag);

                this.txtForceTechniqueName.Text = objFS.ForceTechniqueName ;
                this.txtForceTechniqueDescription.Text = objFS.ForceTechniqueDescription;
            }
           
        }
        #endregion
    }
}
