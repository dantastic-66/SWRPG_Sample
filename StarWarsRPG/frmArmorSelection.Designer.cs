namespace StarWarsRPG
{
    partial class frmArmorSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpArmors = new System.Windows.Forms.GroupBox();
            this.ckbHideNonProficientArmors = new System.Windows.Forms.CheckBox();
            this.lblMisc = new System.Windows.Forms.Label();
            this.tvArmorList = new System.Windows.Forms.TreeView();
            this.lblAbilityMod = new System.Windows.Forms.Label();
            this.grpArmorDetail = new System.Windows.Forms.GroupBox();
            this.txtAvailability = new System.Windows.Forms.TextBox();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.txtEmplacementPoints = new System.Windows.Forms.TextBox();
            this.lblEmplacementPoints = new System.Windows.Forms.Label();
            this.txtFortAdj = new System.Windows.Forms.TextBox();
            this.lblFortAdj = new System.Windows.Forms.Label();
            this.txtReflexAdj = new System.Windows.Forms.TextBox();
            this.lblReflexAdj = new System.Windows.Forms.Label();
            this.btnSelectArmor = new System.Windows.Forms.Button();
            this.grpCharacterStats = new System.Windows.Forms.GroupBox();
            this.lblFortDef = new System.Windows.Forms.Label();
            this.txtFortWithArmor = new System.Windows.Forms.TextBox();
            this.lblReflexDef = new System.Windows.Forms.Label();
            this.txtFortCurrent = new System.Windows.Forms.TextBox();
            this.txtReflexWithArmor = new System.Windows.Forms.TextBox();
            this.lbFortCurrent = new System.Windows.Forms.Label();
            this.lblFortWithArmor = new System.Windows.Forms.Label();
            this.txtReflexCurrent = new System.Windows.Forms.TextBox();
            this.lbReflexCurrent = new System.Windows.Forms.Label();
            this.lblReflexWithArmor = new System.Windows.Forms.Label();
            this.txtArmorDescription = new System.Windows.Forms.TextBox();
            this.lblArmorDescription = new System.Windows.Forms.Label();
            this.txtArmorProficiencyFeat = new System.Windows.Forms.TextBox();
            this.lblProficiencyFeat = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtArmorCost = new System.Windows.Forms.TextBox();
            this.lblArmorCost = new System.Windows.Forms.Label();
            this.txtMaxDefBonus = new System.Windows.Forms.TextBox();
            this.lblMaxDefBonus = new System.Windows.Forms.Label();
            this.txtArmorType = new System.Windows.Forms.TextBox();
            this.lblArmorType = new System.Windows.Forms.Label();
            this.txtArmorName = new System.Windows.Forms.TextBox();
            this.lblArmorName = new System.Windows.Forms.Label();
            this.grpSkills = new System.Windows.Forms.GroupBox();
            this.lblFeatTalentValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSkillFocus = new System.Windows.Forms.Label();
            this.lblSkillTrained = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSkillHalfLevel = new System.Windows.Forms.Label();
            this.lblSkillTotal = new System.Windows.Forms.Label();
            this.lblSkillName = new System.Windows.Forms.Label();
            this.csc7 = new SWRPG_Custom_Windows_Controls.CharacterSkillControl();
            this.csc6 = new SWRPG_Custom_Windows_Controls.CharacterSkillControl();
            this.csc5 = new SWRPG_Custom_Windows_Controls.CharacterSkillControl();
            this.csc4 = new SWRPG_Custom_Windows_Controls.CharacterSkillControl();
            this.csc3 = new SWRPG_Custom_Windows_Controls.CharacterSkillControl();
            this.csc2 = new SWRPG_Custom_Windows_Controls.CharacterSkillControl();
            this.csc1 = new SWRPG_Custom_Windows_Controls.CharacterSkillControl();
            this.gpArmors.SuspendLayout();
            this.grpArmorDetail.SuspendLayout();
            this.grpCharacterStats.SuspendLayout();
            this.grpSkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpArmors
            // 
            this.gpArmors.Controls.Add(this.ckbHideNonProficientArmors);
            this.gpArmors.Controls.Add(this.lblMisc);
            this.gpArmors.Controls.Add(this.tvArmorList);
            this.gpArmors.Controls.Add(this.lblAbilityMod);
            this.gpArmors.Location = new System.Drawing.Point(0, 0);
            this.gpArmors.Name = "gpArmors";
            this.gpArmors.Size = new System.Drawing.Size(327, 596);
            this.gpArmors.TabIndex = 2;
            this.gpArmors.TabStop = false;
            this.gpArmors.Text = "Select Armor";
            // 
            // ckbHideNonProficientArmors
            // 
            this.ckbHideNonProficientArmors.AutoSize = true;
            this.ckbHideNonProficientArmors.Location = new System.Drawing.Point(14, 23);
            this.ckbHideNonProficientArmors.Name = "ckbHideNonProficientArmors";
            this.ckbHideNonProficientArmors.Size = new System.Drawing.Size(175, 19);
            this.ckbHideNonProficientArmors.TabIndex = 1;
            this.ckbHideNonProficientArmors.Text = "Hide Non-Proficient Armors";
            this.ckbHideNonProficientArmors.UseVisualStyleBackColor = true;
            this.ckbHideNonProficientArmors.CheckedChanged += new System.EventHandler(this.ckbHideNonProficientArmors_CheckedChanged);
            // 
            // lblMisc
            // 
            this.lblMisc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisc.Location = new System.Drawing.Point(780, 372);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Size = new System.Drawing.Size(64, 16);
            this.lblMisc.TabIndex = 85;
            this.lblMisc.Text = "Misc";
            this.lblMisc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tvArmorList
            // 
            this.tvArmorList.Location = new System.Drawing.Point(9, 55);
            this.tvArmorList.Name = "tvArmorList";
            this.tvArmorList.Size = new System.Drawing.Size(312, 537);
            this.tvArmorList.TabIndex = 0;
            this.tvArmorList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvArmorList_AfterSelect);
            // 
            // lblAbilityMod
            // 
            this.lblAbilityMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbilityMod.Location = new System.Drawing.Point(464, 372);
            this.lblAbilityMod.Name = "lblAbilityMod";
            this.lblAbilityMod.Size = new System.Drawing.Size(72, 16);
            this.lblAbilityMod.TabIndex = 82;
            this.lblAbilityMod.Text = "Ability Mod";
            // 
            // grpArmorDetail
            // 
            this.grpArmorDetail.Controls.Add(this.txtAvailability);
            this.grpArmorDetail.Controls.Add(this.lblAvailability);
            this.grpArmorDetail.Controls.Add(this.txtEmplacementPoints);
            this.grpArmorDetail.Controls.Add(this.lblEmplacementPoints);
            this.grpArmorDetail.Controls.Add(this.txtFortAdj);
            this.grpArmorDetail.Controls.Add(this.lblFortAdj);
            this.grpArmorDetail.Controls.Add(this.txtReflexAdj);
            this.grpArmorDetail.Controls.Add(this.lblReflexAdj);
            this.grpArmorDetail.Controls.Add(this.btnSelectArmor);
            this.grpArmorDetail.Controls.Add(this.grpCharacterStats);
            this.grpArmorDetail.Controls.Add(this.txtArmorDescription);
            this.grpArmorDetail.Controls.Add(this.lblArmorDescription);
            this.grpArmorDetail.Controls.Add(this.txtArmorProficiencyFeat);
            this.grpArmorDetail.Controls.Add(this.lblProficiencyFeat);
            this.grpArmorDetail.Controls.Add(this.txtBookName);
            this.grpArmorDetail.Controls.Add(this.lblBook);
            this.grpArmorDetail.Controls.Add(this.txtWeight);
            this.grpArmorDetail.Controls.Add(this.lblWeight);
            this.grpArmorDetail.Controls.Add(this.txtArmorCost);
            this.grpArmorDetail.Controls.Add(this.lblArmorCost);
            this.grpArmorDetail.Controls.Add(this.txtMaxDefBonus);
            this.grpArmorDetail.Controls.Add(this.lblMaxDefBonus);
            this.grpArmorDetail.Controls.Add(this.txtArmorType);
            this.grpArmorDetail.Controls.Add(this.lblArmorType);
            this.grpArmorDetail.Controls.Add(this.txtArmorName);
            this.grpArmorDetail.Controls.Add(this.lblArmorName);
            this.grpArmorDetail.Location = new System.Drawing.Point(332, 0);
            this.grpArmorDetail.Name = "grpArmorDetail";
            this.grpArmorDetail.Size = new System.Drawing.Size(558, 596);
            this.grpArmorDetail.TabIndex = 3;
            this.grpArmorDetail.TabStop = false;
            this.grpArmorDetail.Text = "Armor";
            // 
            // txtAvailability
            // 
            this.txtAvailability.Location = new System.Drawing.Point(84, 104);
            this.txtAvailability.Name = "txtAvailability";
            this.txtAvailability.ReadOnly = true;
            this.txtAvailability.Size = new System.Drawing.Size(160, 23);
            this.txtAvailability.TabIndex = 77;
            // 
            // lblAvailability
            // 
            this.lblAvailability.AutoSize = true;
            this.lblAvailability.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailability.Location = new System.Drawing.Point(4, 108);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(72, 17);
            this.lblAvailability.TabIndex = 76;
            this.lblAvailability.Text = "Availability:";
            // 
            // txtEmplacementPoints
            // 
            this.txtEmplacementPoints.Location = new System.Drawing.Point(280, 52);
            this.txtEmplacementPoints.Name = "txtEmplacementPoints";
            this.txtEmplacementPoints.ReadOnly = true;
            this.txtEmplacementPoints.Size = new System.Drawing.Size(36, 23);
            this.txtEmplacementPoints.TabIndex = 75;
            // 
            // lblEmplacementPoints
            // 
            this.lblEmplacementPoints.AutoSize = true;
            this.lblEmplacementPoints.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmplacementPoints.Location = new System.Drawing.Point(148, 52);
            this.lblEmplacementPoints.Name = "lblEmplacementPoints";
            this.lblEmplacementPoints.Size = new System.Drawing.Size(128, 17);
            this.lblEmplacementPoints.TabIndex = 74;
            this.lblEmplacementPoints.Text = "Emplacement Points:";
            // 
            // txtFortAdj
            // 
            this.txtFortAdj.Location = new System.Drawing.Point(504, 52);
            this.txtFortAdj.Name = "txtFortAdj";
            this.txtFortAdj.ReadOnly = true;
            this.txtFortAdj.Size = new System.Drawing.Size(36, 23);
            this.txtFortAdj.TabIndex = 73;
            // 
            // lblFortAdj
            // 
            this.lblFortAdj.AutoSize = true;
            this.lblFortAdj.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFortAdj.Location = new System.Drawing.Point(440, 52);
            this.lblFortAdj.Name = "lblFortAdj";
            this.lblFortAdj.Size = new System.Drawing.Size(57, 17);
            this.lblFortAdj.TabIndex = 72;
            this.lblFortAdj.Text = "Fort Adj:";
            // 
            // txtReflexAdj
            // 
            this.txtReflexAdj.Location = new System.Drawing.Point(400, 52);
            this.txtReflexAdj.Name = "txtReflexAdj";
            this.txtReflexAdj.ReadOnly = true;
            this.txtReflexAdj.Size = new System.Drawing.Size(36, 23);
            this.txtReflexAdj.TabIndex = 71;
            // 
            // lblReflexAdj
            // 
            this.lblReflexAdj.AutoSize = true;
            this.lblReflexAdj.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReflexAdj.Location = new System.Drawing.Point(324, 52);
            this.lblReflexAdj.Name = "lblReflexAdj";
            this.lblReflexAdj.Size = new System.Drawing.Size(69, 17);
            this.lblReflexAdj.TabIndex = 70;
            this.lblReflexAdj.Text = "Reflex Adj:";
            // 
            // btnSelectArmor
            // 
            this.btnSelectArmor.Enabled = false;
            this.btnSelectArmor.Location = new System.Drawing.Point(392, 24);
            this.btnSelectArmor.Name = "btnSelectArmor";
            this.btnSelectArmor.Size = new System.Drawing.Size(152, 23);
            this.btnSelectArmor.TabIndex = 69;
            this.btnSelectArmor.Text = "Select Armor";
            this.btnSelectArmor.UseVisualStyleBackColor = true;
            this.btnSelectArmor.Click += new System.EventHandler(this.btnSelectArmor_Click);
            // 
            // grpCharacterStats
            // 
            this.grpCharacterStats.Controls.Add(this.lblFortDef);
            this.grpCharacterStats.Controls.Add(this.txtFortWithArmor);
            this.grpCharacterStats.Controls.Add(this.lblReflexDef);
            this.grpCharacterStats.Controls.Add(this.txtFortCurrent);
            this.grpCharacterStats.Controls.Add(this.txtReflexWithArmor);
            this.grpCharacterStats.Controls.Add(this.lbFortCurrent);
            this.grpCharacterStats.Controls.Add(this.lblFortWithArmor);
            this.grpCharacterStats.Controls.Add(this.txtReflexCurrent);
            this.grpCharacterStats.Controls.Add(this.lbReflexCurrent);
            this.grpCharacterStats.Controls.Add(this.lblReflexWithArmor);
            this.grpCharacterStats.Location = new System.Drawing.Point(248, 76);
            this.grpCharacterStats.Name = "grpCharacterStats";
            this.grpCharacterStats.Size = new System.Drawing.Size(296, 76);
            this.grpCharacterStats.TabIndex = 68;
            this.grpCharacterStats.TabStop = false;
            this.grpCharacterStats.Text = "Character Stats";
            // 
            // lblFortDef
            // 
            this.lblFortDef.AutoSize = true;
            this.lblFortDef.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFortDef.Location = new System.Drawing.Point(8, 48);
            this.lblFortDef.Name = "lblFortDef";
            this.lblFortDef.Size = new System.Drawing.Size(52, 15);
            this.lblFortDef.TabIndex = 70;
            this.lblFortDef.Text = "Fort Def:";
            // 
            // txtFortWithArmor
            // 
            this.txtFortWithArmor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFortWithArmor.Location = new System.Drawing.Point(244, 44);
            this.txtFortWithArmor.Name = "txtFortWithArmor";
            this.txtFortWithArmor.ReadOnly = true;
            this.txtFortWithArmor.Size = new System.Drawing.Size(44, 23);
            this.txtFortWithArmor.TabIndex = 1;
            // 
            // lblReflexDef
            // 
            this.lblReflexDef.AutoSize = true;
            this.lblReflexDef.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReflexDef.Location = new System.Drawing.Point(8, 24);
            this.lblReflexDef.Name = "lblReflexDef";
            this.lblReflexDef.Size = new System.Drawing.Size(62, 15);
            this.lblReflexDef.TabIndex = 69;
            this.lblReflexDef.Text = "Reflex Def:";
            // 
            // txtFortCurrent
            // 
            this.txtFortCurrent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFortCurrent.Location = new System.Drawing.Point(128, 44);
            this.txtFortCurrent.Name = "txtFortCurrent";
            this.txtFortCurrent.ReadOnly = true;
            this.txtFortCurrent.Size = new System.Drawing.Size(44, 23);
            this.txtFortCurrent.TabIndex = 0;
            // 
            // txtReflexWithArmor
            // 
            this.txtReflexWithArmor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReflexWithArmor.Location = new System.Drawing.Point(244, 20);
            this.txtReflexWithArmor.Name = "txtReflexWithArmor";
            this.txtReflexWithArmor.ReadOnly = true;
            this.txtReflexWithArmor.Size = new System.Drawing.Size(44, 23);
            this.txtReflexWithArmor.TabIndex = 1;
            // 
            // lbFortCurrent
            // 
            this.lbFortCurrent.AutoSize = true;
            this.lbFortCurrent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFortCurrent.Location = new System.Drawing.Point(76, 48);
            this.lbFortCurrent.Name = "lbFortCurrent";
            this.lbFortCurrent.Size = new System.Drawing.Size(47, 15);
            this.lbFortCurrent.TabIndex = 2;
            this.lbFortCurrent.Text = "Current";
            // 
            // lblFortWithArmor
            // 
            this.lblFortWithArmor.AutoSize = true;
            this.lblFortWithArmor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFortWithArmor.Location = new System.Drawing.Point(176, 48);
            this.lblFortWithArmor.Name = "lblFortWithArmor";
            this.lblFortWithArmor.Size = new System.Drawing.Size(61, 15);
            this.lblFortWithArmor.TabIndex = 3;
            this.lblFortWithArmor.Text = "w/ Armor:";
            // 
            // txtReflexCurrent
            // 
            this.txtReflexCurrent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReflexCurrent.Location = new System.Drawing.Point(128, 20);
            this.txtReflexCurrent.Name = "txtReflexCurrent";
            this.txtReflexCurrent.ReadOnly = true;
            this.txtReflexCurrent.Size = new System.Drawing.Size(44, 23);
            this.txtReflexCurrent.TabIndex = 0;
            // 
            // lbReflexCurrent
            // 
            this.lbReflexCurrent.AutoSize = true;
            this.lbReflexCurrent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReflexCurrent.Location = new System.Drawing.Point(76, 24);
            this.lbReflexCurrent.Name = "lbReflexCurrent";
            this.lbReflexCurrent.Size = new System.Drawing.Size(47, 15);
            this.lbReflexCurrent.TabIndex = 2;
            this.lbReflexCurrent.Text = "Current";
            // 
            // lblReflexWithArmor
            // 
            this.lblReflexWithArmor.AutoSize = true;
            this.lblReflexWithArmor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReflexWithArmor.Location = new System.Drawing.Point(176, 24);
            this.lblReflexWithArmor.Name = "lblReflexWithArmor";
            this.lblReflexWithArmor.Size = new System.Drawing.Size(61, 15);
            this.lblReflexWithArmor.TabIndex = 3;
            this.lblReflexWithArmor.Text = "w/ Armor:";
            // 
            // txtArmorDescription
            // 
            this.txtArmorDescription.Location = new System.Drawing.Point(4, 208);
            this.txtArmorDescription.Multiline = true;
            this.txtArmorDescription.Name = "txtArmorDescription";
            this.txtArmorDescription.ReadOnly = true;
            this.txtArmorDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtArmorDescription.Size = new System.Drawing.Size(544, 384);
            this.txtArmorDescription.TabIndex = 67;
            // 
            // lblArmorDescription
            // 
            this.lblArmorDescription.AutoSize = true;
            this.lblArmorDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmorDescription.Location = new System.Drawing.Point(4, 184);
            this.lblArmorDescription.Name = "lblArmorDescription";
            this.lblArmorDescription.Size = new System.Drawing.Size(118, 17);
            this.lblArmorDescription.TabIndex = 66;
            this.lblArmorDescription.Text = "Armor Description:";
            // 
            // txtArmorProficiencyFeat
            // 
            this.txtArmorProficiencyFeat.Location = new System.Drawing.Point(384, 156);
            this.txtArmorProficiencyFeat.Name = "txtArmorProficiencyFeat";
            this.txtArmorProficiencyFeat.ReadOnly = true;
            this.txtArmorProficiencyFeat.Size = new System.Drawing.Size(168, 23);
            this.txtArmorProficiencyFeat.TabIndex = 18;
            // 
            // lblProficiencyFeat
            // 
            this.lblProficiencyFeat.AutoSize = true;
            this.lblProficiencyFeat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProficiencyFeat.Location = new System.Drawing.Point(276, 156);
            this.lblProficiencyFeat.Name = "lblProficiencyFeat";
            this.lblProficiencyFeat.Size = new System.Drawing.Size(101, 17);
            this.lblProficiencyFeat.TabIndex = 17;
            this.lblProficiencyFeat.Text = "Proficiency Feat:";
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(48, 156);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.ReadOnly = true;
            this.txtBookName.Size = new System.Drawing.Size(224, 23);
            this.txtBookName.TabIndex = 16;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBook.Location = new System.Drawing.Point(4, 156);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(40, 17);
            this.lblBook.TabIndex = 15;
            this.lblBook.Text = "Book:";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(184, 132);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(60, 23);
            this.txtWeight.TabIndex = 9;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(125, 132);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(52, 17);
            this.lblWeight.TabIndex = 8;
            this.lblWeight.Text = "Weight:";
            // 
            // txtArmorCost
            // 
            this.txtArmorCost.Location = new System.Drawing.Point(48, 132);
            this.txtArmorCost.Name = "txtArmorCost";
            this.txtArmorCost.ReadOnly = true;
            this.txtArmorCost.Size = new System.Drawing.Size(68, 23);
            this.txtArmorCost.TabIndex = 7;
            // 
            // lblArmorCost
            // 
            this.lblArmorCost.AutoSize = true;
            this.lblArmorCost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmorCost.Location = new System.Drawing.Point(4, 132);
            this.lblArmorCost.Name = "lblArmorCost";
            this.lblArmorCost.Size = new System.Drawing.Size(37, 17);
            this.lblArmorCost.TabIndex = 6;
            this.lblArmorCost.Text = "Cost:";
            // 
            // txtMaxDefBonus
            // 
            this.txtMaxDefBonus.Location = new System.Drawing.Point(104, 52);
            this.txtMaxDefBonus.Name = "txtMaxDefBonus";
            this.txtMaxDefBonus.ReadOnly = true;
            this.txtMaxDefBonus.Size = new System.Drawing.Size(36, 23);
            this.txtMaxDefBonus.TabIndex = 5;
            // 
            // lblMaxDefBonus
            // 
            this.lblMaxDefBonus.AutoSize = true;
            this.lblMaxDefBonus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDefBonus.Location = new System.Drawing.Point(4, 52);
            this.lblMaxDefBonus.Name = "lblMaxDefBonus";
            this.lblMaxDefBonus.Size = new System.Drawing.Size(99, 17);
            this.lblMaxDefBonus.TabIndex = 4;
            this.lblMaxDefBonus.Text = "Max Def Bonus:";
            // 
            // txtArmorType
            // 
            this.txtArmorType.Location = new System.Drawing.Point(60, 76);
            this.txtArmorType.Name = "txtArmorType";
            this.txtArmorType.ReadOnly = true;
            this.txtArmorType.Size = new System.Drawing.Size(184, 23);
            this.txtArmorType.TabIndex = 3;
            // 
            // lblArmorType
            // 
            this.lblArmorType.AutoSize = true;
            this.lblArmorType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmorType.Location = new System.Drawing.Point(4, 80);
            this.lblArmorType.Name = "lblArmorType";
            this.lblArmorType.Size = new System.Drawing.Size(39, 17);
            this.lblArmorType.TabIndex = 2;
            this.lblArmorType.Text = "Type:";
            // 
            // txtArmorName
            // 
            this.txtArmorName.Location = new System.Drawing.Point(56, 24);
            this.txtArmorName.Name = "txtArmorName";
            this.txtArmorName.ReadOnly = true;
            this.txtArmorName.Size = new System.Drawing.Size(320, 23);
            this.txtArmorName.TabIndex = 1;
            // 
            // lblArmorName
            // 
            this.lblArmorName.AutoSize = true;
            this.lblArmorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmorName.Location = new System.Drawing.Point(4, 28);
            this.lblArmorName.Name = "lblArmorName";
            this.lblArmorName.Size = new System.Drawing.Size(46, 17);
            this.lblArmorName.TabIndex = 0;
            this.lblArmorName.Text = "Name:";
            // 
            // grpSkills
            // 
            this.grpSkills.Controls.Add(this.csc7);
            this.grpSkills.Controls.Add(this.csc6);
            this.grpSkills.Controls.Add(this.csc5);
            this.grpSkills.Controls.Add(this.csc4);
            this.grpSkills.Controls.Add(this.csc3);
            this.grpSkills.Controls.Add(this.csc2);
            this.grpSkills.Controls.Add(this.csc1);
            this.grpSkills.Controls.Add(this.lblFeatTalentValue);
            this.grpSkills.Controls.Add(this.label1);
            this.grpSkills.Controls.Add(this.lblSkillFocus);
            this.grpSkills.Controls.Add(this.lblSkillTrained);
            this.grpSkills.Controls.Add(this.label2);
            this.grpSkills.Controls.Add(this.lblSkillHalfLevel);
            this.grpSkills.Controls.Add(this.lblSkillTotal);
            this.grpSkills.Controls.Add(this.lblSkillName);
            this.grpSkills.Location = new System.Drawing.Point(8, 372);
            this.grpSkills.Name = "grpSkills";
            this.grpSkills.Size = new System.Drawing.Size(720, 228);
            this.grpSkills.TabIndex = 4;
            this.grpSkills.TabStop = false;
            this.grpSkills.Text = "Skills Altered:";
            // 
            // lblFeatTalentValue
            // 
            this.lblFeatTalentValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeatTalentValue.Location = new System.Drawing.Point(560, 20);
            this.lblFeatTalentValue.Name = "lblFeatTalentValue";
            this.lblFeatTalentValue.Size = new System.Drawing.Size(80, 16);
            this.lblFeatTalentValue.TabIndex = 35;
            this.lblFeatTalentValue.Text = "Feat / Talent";
            this.lblFeatTalentValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(644, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Misc";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSkillFocus
            // 
            this.lblSkillFocus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillFocus.Location = new System.Drawing.Point(488, 20);
            this.lblSkillFocus.Name = "lblSkillFocus";
            this.lblSkillFocus.Size = new System.Drawing.Size(64, 16);
            this.lblSkillFocus.TabIndex = 33;
            this.lblSkillFocus.Text = "Skill Focus";
            // 
            // lblSkillTrained
            // 
            this.lblSkillTrained.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillTrained.Location = new System.Drawing.Point(412, 20);
            this.lblSkillTrained.Name = "lblSkillTrained";
            this.lblSkillTrained.Size = new System.Drawing.Size(64, 16);
            this.lblSkillTrained.TabIndex = 32;
            this.lblSkillTrained.Text = "Trained";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Ability Mod";
            // 
            // lblSkillHalfLevel
            // 
            this.lblSkillHalfLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillHalfLevel.Location = new System.Drawing.Point(252, 20);
            this.lblSkillHalfLevel.Name = "lblSkillHalfLevel";
            this.lblSkillHalfLevel.Size = new System.Drawing.Size(60, 16);
            this.lblSkillHalfLevel.TabIndex = 30;
            this.lblSkillHalfLevel.Text = "1/2 Level";
            // 
            // lblSkillTotal
            // 
            this.lblSkillTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillTotal.Location = new System.Drawing.Point(176, 20);
            this.lblSkillTotal.Name = "lblSkillTotal";
            this.lblSkillTotal.Size = new System.Drawing.Size(40, 16);
            this.lblSkillTotal.TabIndex = 29;
            this.lblSkillTotal.Text = "Total";
            // 
            // lblSkillName
            // 
            this.lblSkillName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillName.Location = new System.Drawing.Point(4, 20);
            this.lblSkillName.Name = "lblSkillName";
            this.lblSkillName.Size = new System.Drawing.Size(168, 16);
            this.lblSkillName.TabIndex = 28;
            this.lblSkillName.Text = "Skill Name";
            // 
            // csc7
            // 
            this.csc7.AutoSize = true;
            this.csc7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csc7.Location = new System.Drawing.Point(4, 192);
            this.csc7.Name = "csc7";
            this.csc7.Size = new System.Drawing.Size(711, 26);
            this.csc7.SkillAbilityModValue = 0;
            this.csc7.SkillFeatTalentValue = 0;
            this.csc7.SkillFocusValue = 0;
            this.csc7.SkillHalfLevelValue = 0;
            this.csc7.SkillMiscellaneousValue = 0;
            this.csc7.SkillName = "";
            this.csc7.SkillTrainedValue = 0;
            this.csc7.TabIndex = 42;
            // 
            // csc6
            // 
            this.csc6.AutoSize = true;
            this.csc6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csc6.Location = new System.Drawing.Point(4, 166);
            this.csc6.Name = "csc6";
            this.csc6.Size = new System.Drawing.Size(711, 26);
            this.csc6.SkillAbilityModValue = 0;
            this.csc6.SkillFeatTalentValue = 0;
            this.csc6.SkillFocusValue = 0;
            this.csc6.SkillHalfLevelValue = 0;
            this.csc6.SkillMiscellaneousValue = 0;
            this.csc6.SkillName = "";
            this.csc6.SkillTrainedValue = 0;
            this.csc6.TabIndex = 41;
            // 
            // csc5
            // 
            this.csc5.AutoSize = true;
            this.csc5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csc5.Location = new System.Drawing.Point(4, 140);
            this.csc5.Name = "csc5";
            this.csc5.Size = new System.Drawing.Size(711, 26);
            this.csc5.SkillAbilityModValue = 0;
            this.csc5.SkillFeatTalentValue = 0;
            this.csc5.SkillFocusValue = 0;
            this.csc5.SkillHalfLevelValue = 0;
            this.csc5.SkillMiscellaneousValue = 0;
            this.csc5.SkillName = "";
            this.csc5.SkillTrainedValue = 0;
            this.csc5.TabIndex = 40;
            // 
            // csc4
            // 
            this.csc4.AutoSize = true;
            this.csc4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csc4.Location = new System.Drawing.Point(4, 114);
            this.csc4.Name = "csc4";
            this.csc4.Size = new System.Drawing.Size(711, 26);
            this.csc4.SkillAbilityModValue = 0;
            this.csc4.SkillFeatTalentValue = 0;
            this.csc4.SkillFocusValue = 0;
            this.csc4.SkillHalfLevelValue = 0;
            this.csc4.SkillMiscellaneousValue = 0;
            this.csc4.SkillName = "";
            this.csc4.SkillTrainedValue = 0;
            this.csc4.TabIndex = 39;
            // 
            // csc3
            // 
            this.csc3.AutoSize = true;
            this.csc3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csc3.Location = new System.Drawing.Point(4, 88);
            this.csc3.Name = "csc3";
            this.csc3.Size = new System.Drawing.Size(711, 26);
            this.csc3.SkillAbilityModValue = 0;
            this.csc3.SkillFeatTalentValue = 0;
            this.csc3.SkillFocusValue = 0;
            this.csc3.SkillHalfLevelValue = 0;
            this.csc3.SkillMiscellaneousValue = 0;
            this.csc3.SkillName = "";
            this.csc3.SkillTrainedValue = 0;
            this.csc3.TabIndex = 38;
            // 
            // csc2
            // 
            this.csc2.AutoSize = true;
            this.csc2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csc2.Location = new System.Drawing.Point(4, 62);
            this.csc2.Name = "csc2";
            this.csc2.Size = new System.Drawing.Size(711, 26);
            this.csc2.SkillAbilityModValue = 0;
            this.csc2.SkillFeatTalentValue = 0;
            this.csc2.SkillFocusValue = 0;
            this.csc2.SkillHalfLevelValue = 0;
            this.csc2.SkillMiscellaneousValue = 0;
            this.csc2.SkillName = "";
            this.csc2.SkillTrainedValue = 0;
            this.csc2.TabIndex = 37;
            // 
            // csc1
            // 
            this.csc1.AutoSize = true;
            this.csc1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csc1.Location = new System.Drawing.Point(4, 36);
            this.csc1.Name = "csc1";
            this.csc1.Size = new System.Drawing.Size(711, 26);
            this.csc1.SkillAbilityModValue = 0;
            this.csc1.SkillFeatTalentValue = 0;
            this.csc1.SkillFocusValue = 0;
            this.csc1.SkillHalfLevelValue = 0;
            this.csc1.SkillMiscellaneousValue = 0;
            this.csc1.SkillName = "";
            this.csc1.SkillTrainedValue = 0;
            this.csc1.TabIndex = 36;
            // 
            // frmArmorSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 600);
            this.Controls.Add(this.grpArmorDetail);
            this.Controls.Add(this.gpArmors);
            this.Controls.Add(this.grpSkills);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArmorSelection";
            this.Text = "Select Armor";
            this.gpArmors.ResumeLayout(false);
            this.gpArmors.PerformLayout();
            this.grpArmorDetail.ResumeLayout(false);
            this.grpArmorDetail.PerformLayout();
            this.grpCharacterStats.ResumeLayout(false);
            this.grpCharacterStats.PerformLayout();
            this.grpSkills.ResumeLayout(false);
            this.grpSkills.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpArmors;
        private System.Windows.Forms.CheckBox ckbHideNonProficientArmors;
        private System.Windows.Forms.TreeView tvArmorList;
        private System.Windows.Forms.GroupBox grpArmorDetail;
        private System.Windows.Forms.Button btnSelectArmor;
        private System.Windows.Forms.GroupBox grpCharacterStats;
        private System.Windows.Forms.Label lblFortDef;
        private System.Windows.Forms.TextBox txtFortWithArmor;
        private System.Windows.Forms.Label lblReflexDef;
        private System.Windows.Forms.TextBox txtFortCurrent;
        private System.Windows.Forms.TextBox txtReflexWithArmor;
        private System.Windows.Forms.Label lbFortCurrent;
        private System.Windows.Forms.Label lblFortWithArmor;
        private System.Windows.Forms.TextBox txtReflexCurrent;
        private System.Windows.Forms.Label lbReflexCurrent;
        private System.Windows.Forms.Label lblReflexWithArmor;
        private System.Windows.Forms.TextBox txtArmorDescription;
        private System.Windows.Forms.Label lblArmorDescription;
        private System.Windows.Forms.TextBox txtArmorProficiencyFeat;
        private System.Windows.Forms.Label lblProficiencyFeat;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtArmorCost;
        private System.Windows.Forms.Label lblArmorCost;
        private System.Windows.Forms.TextBox txtMaxDefBonus;
        private System.Windows.Forms.Label lblMaxDefBonus;
        private System.Windows.Forms.TextBox txtArmorType;
        private System.Windows.Forms.Label lblArmorType;
        private System.Windows.Forms.TextBox txtArmorName;
        private System.Windows.Forms.Label lblArmorName;
        private System.Windows.Forms.TextBox txtFortAdj;
        private System.Windows.Forms.Label lblFortAdj;
        private System.Windows.Forms.TextBox txtReflexAdj;
        private System.Windows.Forms.Label lblReflexAdj;
        private System.Windows.Forms.TextBox txtEmplacementPoints;
        private System.Windows.Forms.Label lblEmplacementPoints;
        private System.Windows.Forms.TextBox txtAvailability;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.Label lblMisc;
        private System.Windows.Forms.Label lblAbilityMod;
        private System.Windows.Forms.GroupBox grpSkills;
        private System.Windows.Forms.Label lblFeatTalentValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSkillFocus;
        private System.Windows.Forms.Label lblSkillTrained;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSkillHalfLevel;
        private System.Windows.Forms.Label lblSkillTotal;
        private System.Windows.Forms.Label lblSkillName;
        private SWRPG_Custom_Windows_Controls.CharacterSkillControl csc7;
        private SWRPG_Custom_Windows_Controls.CharacterSkillControl csc6;
        private SWRPG_Custom_Windows_Controls.CharacterSkillControl csc5;
        private SWRPG_Custom_Windows_Controls.CharacterSkillControl csc4;
        private SWRPG_Custom_Windows_Controls.CharacterSkillControl csc3;
        private SWRPG_Custom_Windows_Controls.CharacterSkillControl csc2;
        private SWRPG_Custom_Windows_Controls.CharacterSkillControl csc1;
    }
}