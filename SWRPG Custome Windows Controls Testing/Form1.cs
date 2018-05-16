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

namespace SWRPG_Custome_Windows_Controls_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            int intCharID = 1;
            Character objChar = new Character(intCharID);
            InitializeComponent();
            CharacterWeapon objCharWeap = new CharacterWeapon(intCharID, 1);
            cwc1.SetControlWithCharacterWeapon(objChar, objCharWeap);

            //cwc1.CharacterID = objCharWeap.CharacterID;
            //cwc1.WeaponID = objCharWeap.WeaponID;
            //cwc1.WeaponName = objCharWeap.objWeapon.WeaponName;
            //cwc1.StunDamage = objCharWeap.objWeapon.StunDamage;
            //cwc1.Damage = objCharWeap.objWeapon.Damage;
            //cwc1.CharacterWeaponNotes = objCharWeap.Notes;
            ////cwc1.WeaponNotes = objCharWeap.objWeapon.Notes;
            //cwc1.Weight = objCharWeap.objWeapon.Weight;
            //cwc1.BookName = objCharWeap.objWeapon.objBook.BookName;
            //cwc1.SetRanges(objCharWeap.lstWeaponRanges);


            //cwc2.CharacterID = objCharWeap.CharacterID;
            //cwc2.WeaponID = objCharWeap.WeaponID;
            //cwc2.WeaponName = objCharWeap.objWeapon.WeaponName;
            //cwc2.StunDamage = objCharWeap.objWeapon.StunDamage;
            //cwc2.Damage = objCharWeap.objWeapon.Damage;
            //cwc2.CharacterWeaponNotes = objCharWeap.Notes;
            ////cwc2.WeaponNotes = objCharWeap.objWeapon.Notes;
            //cwc2.Weight = objCharWeap.objWeapon.Weight;
            //cwc2.BookName = objCharWeap.objWeapon.objBook.BookName;

            //Melee range

            Range objRange = new Range(1);
            List<Range> lstRanges = new List<Range>();
            lstRanges.Add(objRange);
            objCharWeap.objWeapon.objRanges = lstRanges;
            //cwc2.SetRanges(lstRanges);
            cwc2.SetControlWithCharacterWeapon(objChar, objCharWeap);
        }
    }
}
