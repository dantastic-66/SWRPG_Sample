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
    public partial class frmAbilityDisplay : Form
    {
        public frmAbilityDisplay()
        {
            InitializeComponent();
        }
        public frmAbilityDisplay(Ability objAbility)
        {
            InitializeComponent();
            LoadForm(objAbility);
        }

        public void LoadForm(Ability objAbility)
        {
            this.txtName.Text = objAbility.AbilityName;
            //this.txtDescription.Text = objAbility.
            this.txtSortOrder.Text = Common.PascalNoteString(objAbility.SortOrder.ToString());
            
        }
    }
}
