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
    public partial class frmAddCharacterLevel_ForceSecretSelection : Form
    {
        //New Object that contains all the above items
        public static CharacterAddLevelContainer objCALC = new CharacterAddLevelContainer();

        #region Form Events
        public frmAddCharacterLevel_ForceSecretSelection()
        {
            InitializeComponent();
            LoadTreeView();
            //objForceSecret = new ForceSecret();
        }

        private void tvForceSecret_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetForcePowerFields(tvForceSecret.SelectedNode.Tag.ToString());
        }

        private void btnSelectForceSecret_Click(object sender, EventArgs e)
        {
            string strTag = "";
            int intTag = 0;

            strTag = tvForceSecret.SelectedNode.Tag.ToString();
            int.TryParse(strTag, out intTag);
            objCALC.objForceSecret.GetForceSecret(intTag);

            this.Close();
        }

        private void frmAddCharacterLevel_ForceSecretSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.CloseFormAndReturnToControlList(objCALC);
        }
        #endregion

        #region Methods
        private void LoadTreeView()
        {
            this.tvForceSecret.Nodes.Clear();

            List<ForceSecret> lstForceSecrets = new List<ForceSecret>();
            ForceSecret objFS = new ForceSecret();

            lstForceSecrets = objFS.GetForceSecrets ("", "");

            foreach (ForceSecret objListForceSecret in lstForceSecrets)
            {
                TreeNode objTN = new TreeNode();
                objTN.Text = objListForceSecret.ForceSecretName;
                objTN.Tag = objListForceSecret.ForceSecretID;
                tvForceSecret.Nodes.Add(objTN);
            }
        }

        public void SetForcePowerFields(string strTag)
        {
            int intTag;

            int.TryParse(strTag, out intTag);

            if (intTag != 0)
            {
                ForceSecret objFS = new ForceSecret();
                objFS.GetForceSecret (intTag);

                this.txtForceSecretName.Text = objFS.ForceSecretName ;
                this.txtForceSecretDescription.Text = objFS.ForceSecretDescription;
            }
           
        }
        #endregion

    }
}
