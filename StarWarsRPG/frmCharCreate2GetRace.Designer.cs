namespace StarWarsRPG
{
    partial class frmCharCreate2GetRace
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
            this.lsbRace = new System.Windows.Forms.ListBox();
            this.lblRace = new System.Windows.Forms.Label();
            this.lblRaceName = new System.Windows.Forms.Label();
            this.txtRaceName = new System.Windows.Forms.TextBox();
            this.txtRaceDescription = new System.Windows.Forms.TextBox();
            this.lblRaceDescription = new System.Windows.Forms.Label();
            this.txtOtherDescription = new System.Windows.Forms.TextBox();
            this.lblOtherDescription = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.txtAvgHeight = new System.Windows.Forms.TextBox();
            this.lblAvgHeight = new System.Windows.Forms.Label();
            this.txtAvgWeight = new System.Windows.Forms.TextBox();
            this.lblAvgWeight = new System.Windows.Forms.Label();
            this.ckbRage = new System.Windows.Forms.CheckBox();
            this.ckbShapeShift = new System.Windows.Forms.CheckBox();
            this.lsbAbilityMods = new System.Windows.Forms.ListBox();
            this.lblAbilityMods = new System.Windows.Forms.Label();
            this.lblRaceSkills = new System.Windows.Forms.Label();
            this.lsbRaceSkills = new System.Windows.Forms.ListBox();
            this.lblBonusFeats = new System.Windows.Forms.Label();
            this.lsbBonusFeats = new System.Windows.Forms.ListBox();
            this.btnSelectRace = new System.Windows.Forms.Button();
            this.lblSpeeds = new System.Windows.Forms.Label();
            this.lsbSpeeds = new System.Windows.Forms.ListBox();
            this.clbPrimitive = new System.Windows.Forms.CheckBox();
            this.ckbBonusLevelFeat = new System.Windows.Forms.CheckBox();
            this.ckbBonusSkill = new System.Windows.Forms.CheckBox();
            this.lblDefenseModifier = new System.Windows.Forms.Label();
            this.lsbDefenseModifiers = new System.Windows.Forms.ListBox();
            this.lblRaceLanguages = new System.Windows.Forms.Label();
            this.lsbRaceLanguages = new System.Windows.Forms.ListBox();
            this.lblConditionalFeats = new System.Windows.Forms.Label();
            this.lsbConditionalFeats = new System.Windows.Forms.ListBox();
            this.lblSpecialAbilities = new System.Windows.Forms.Label();
            this.lvRaceSpcialAbilities = new System.Windows.Forms.ListView();
            this.chAbilityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtRaceSpecialAbilityDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lsbRace
            // 
            this.lsbRace.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbRace.FormattingEnabled = true;
            this.lsbRace.ItemHeight = 20;
            this.lsbRace.Location = new System.Drawing.Point(19, 31);
            this.lsbRace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbRace.Name = "lsbRace";
            this.lsbRace.Size = new System.Drawing.Size(205, 684);
            this.lsbRace.TabIndex = 0;
            this.lsbRace.Click += new System.EventHandler(this.lsbRace_Click);
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRace.Location = new System.Drawing.Point(19, 0);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(91, 21);
            this.lblRace.TabIndex = 1;
            this.lblRace.Text = "Select Race:";
            // 
            // lblRaceName
            // 
            this.lblRaceName.AutoSize = true;
            this.lblRaceName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceName.Location = new System.Drawing.Point(232, 42);
            this.lblRaceName.Name = "lblRaceName";
            this.lblRaceName.Size = new System.Drawing.Size(75, 17);
            this.lblRaceName.TabIndex = 2;
            this.lblRaceName.Text = "Race Name";
            // 
            // txtRaceName
            // 
            this.txtRaceName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaceName.Location = new System.Drawing.Point(312, 42);
            this.txtRaceName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRaceName.Name = "txtRaceName";
            this.txtRaceName.ReadOnly = true;
            this.txtRaceName.Size = new System.Drawing.Size(260, 25);
            this.txtRaceName.TabIndex = 3;
            // 
            // txtRaceDescription
            // 
            this.txtRaceDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaceDescription.Location = new System.Drawing.Point(375, 84);
            this.txtRaceDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRaceDescription.Multiline = true;
            this.txtRaceDescription.Name = "txtRaceDescription";
            this.txtRaceDescription.ReadOnly = true;
            this.txtRaceDescription.Size = new System.Drawing.Size(541, 56);
            this.txtRaceDescription.TabIndex = 5;
            // 
            // lblRaceDescription
            // 
            this.lblRaceDescription.AutoSize = true;
            this.lblRaceDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceDescription.Location = new System.Drawing.Point(244, 84);
            this.lblRaceDescription.Name = "lblRaceDescription";
            this.lblRaceDescription.Size = new System.Drawing.Size(106, 17);
            this.lblRaceDescription.TabIndex = 4;
            this.lblRaceDescription.Text = "Race Description";
            // 
            // txtOtherDescription
            // 
            this.txtOtherDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherDescription.Location = new System.Drawing.Point(375, 148);
            this.txtOtherDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOtherDescription.Multiline = true;
            this.txtOtherDescription.Name = "txtOtherDescription";
            this.txtOtherDescription.ReadOnly = true;
            this.txtOtherDescription.Size = new System.Drawing.Size(541, 56);
            this.txtOtherDescription.TabIndex = 7;
            // 
            // lblOtherDescription
            // 
            this.lblOtherDescription.AutoSize = true;
            this.lblOtherDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherDescription.Location = new System.Drawing.Point(244, 148);
            this.lblOtherDescription.Name = "lblOtherDescription";
            this.lblOtherDescription.Size = new System.Drawing.Size(111, 17);
            this.lblOtherDescription.TabIndex = 6;
            this.lblOtherDescription.Text = "Other Description";
            // 
            // txtSex
            // 
            this.txtSex.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSex.Location = new System.Drawing.Point(300, 212);
            this.txtSex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(46, 25);
            this.txtSex.TabIndex = 9;
            // 
            // lblSex
            // 
            this.lblSex.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Location = new System.Drawing.Point(253, 212);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(37, 25);
            this.lblSex.TabIndex = 8;
            this.lblSex.Text = "Sex";
            // 
            // txtAvgHeight
            // 
            this.txtAvgHeight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgHeight.Location = new System.Drawing.Point(449, 212);
            this.txtAvgHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAvgHeight.Name = "txtAvgHeight";
            this.txtAvgHeight.ReadOnly = true;
            this.txtAvgHeight.Size = new System.Drawing.Size(46, 25);
            this.txtAvgHeight.TabIndex = 11;
            // 
            // lblAvgHeight
            // 
            this.lblAvgHeight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgHeight.Location = new System.Drawing.Point(356, 212);
            this.lblAvgHeight.Name = "lblAvgHeight";
            this.lblAvgHeight.Size = new System.Drawing.Size(84, 21);
            this.lblAvgHeight.TabIndex = 10;
            this.lblAvgHeight.Text = "Avg Height";
            // 
            // txtAvgWeight
            // 
            this.txtAvgWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgWeight.Location = new System.Drawing.Point(449, 244);
            this.txtAvgWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAvgWeight.Name = "txtAvgWeight";
            this.txtAvgWeight.ReadOnly = true;
            this.txtAvgWeight.Size = new System.Drawing.Size(46, 25);
            this.txtAvgWeight.TabIndex = 13;
            // 
            // lblAvgWeight
            // 
            this.lblAvgWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgWeight.Location = new System.Drawing.Point(356, 244);
            this.lblAvgWeight.Name = "lblAvgWeight";
            this.lblAvgWeight.Size = new System.Drawing.Size(84, 21);
            this.lblAvgWeight.TabIndex = 12;
            this.lblAvgWeight.Text = "Avg Weight";
            // 
            // ckbRage
            // 
            this.ckbRage.AutoSize = true;
            this.ckbRage.Enabled = false;
            this.ckbRage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbRage.Location = new System.Drawing.Point(508, 212);
            this.ckbRage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckbRage.Name = "ckbRage";
            this.ckbRage.Size = new System.Drawing.Size(96, 21);
            this.ckbRage.TabIndex = 14;
            this.ckbRage.Text = "Rage Ability";
            this.ckbRage.UseVisualStyleBackColor = true;
            // 
            // ckbShapeShift
            // 
            this.ckbShapeShift.AutoSize = true;
            this.ckbShapeShift.Enabled = false;
            this.ckbShapeShift.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbShapeShift.Location = new System.Drawing.Point(608, 212);
            this.ckbShapeShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckbShapeShift.Name = "ckbShapeShift";
            this.ckbShapeShift.Size = new System.Drawing.Size(92, 21);
            this.ckbShapeShift.TabIndex = 15;
            this.ckbShapeShift.Text = "Shape Shift";
            this.ckbShapeShift.UseVisualStyleBackColor = true;
            // 
            // lsbAbilityMods
            // 
            this.lsbAbilityMods.FormattingEnabled = true;
            this.lsbAbilityMods.ItemHeight = 17;
            this.lsbAbilityMods.Location = new System.Drawing.Point(232, 308);
            this.lsbAbilityMods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbAbilityMods.Name = "lsbAbilityMods";
            this.lsbAbilityMods.Size = new System.Drawing.Size(223, 89);
            this.lsbAbilityMods.TabIndex = 16;
            this.lsbAbilityMods.DoubleClick += new System.EventHandler(this.lsbAbilityMods_DoubleClick);
            // 
            // lblAbilityMods
            // 
            this.lblAbilityMods.AutoSize = true;
            this.lblAbilityMods.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbilityMods.Location = new System.Drawing.Point(232, 282);
            this.lblAbilityMods.Name = "lblAbilityMods";
            this.lblAbilityMods.Size = new System.Drawing.Size(99, 19);
            this.lblAbilityMods.TabIndex = 17;
            this.lblAbilityMods.Text = "Ability Modifer";
            // 
            // lblRaceSkills
            // 
            this.lblRaceSkills.AutoSize = true;
            this.lblRaceSkills.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceSkills.Location = new System.Drawing.Point(464, 282);
            this.lblRaceSkills.Name = "lblRaceSkills";
            this.lblRaceSkills.Size = new System.Drawing.Size(70, 19);
            this.lblRaceSkills.TabIndex = 19;
            this.lblRaceSkills.Text = "Race Skills";
            // 
            // lsbRaceSkills
            // 
            this.lsbRaceSkills.FormattingEnabled = true;
            this.lsbRaceSkills.ItemHeight = 17;
            this.lsbRaceSkills.Location = new System.Drawing.Point(464, 308);
            this.lsbRaceSkills.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbRaceSkills.Name = "lsbRaceSkills";
            this.lsbRaceSkills.Size = new System.Drawing.Size(223, 89);
            this.lsbRaceSkills.TabIndex = 18;
            // 
            // lblBonusFeats
            // 
            this.lblBonusFeats.AutoSize = true;
            this.lblBonusFeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonusFeats.Location = new System.Drawing.Point(696, 282);
            this.lblBonusFeats.Name = "lblBonusFeats";
            this.lblBonusFeats.Size = new System.Drawing.Size(83, 19);
            this.lblBonusFeats.TabIndex = 21;
            this.lblBonusFeats.Text = "Bonus Feats";
            // 
            // lsbBonusFeats
            // 
            this.lsbBonusFeats.FormattingEnabled = true;
            this.lsbBonusFeats.ItemHeight = 17;
            this.lsbBonusFeats.Location = new System.Drawing.Point(696, 308);
            this.lsbBonusFeats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbBonusFeats.Name = "lsbBonusFeats";
            this.lsbBonusFeats.Size = new System.Drawing.Size(223, 89);
            this.lsbBonusFeats.TabIndex = 20;
            // 
            // btnSelectRace
            // 
            this.btnSelectRace.Location = new System.Drawing.Point(576, 40);
            this.btnSelectRace.Name = "btnSelectRace";
            this.btnSelectRace.Size = new System.Drawing.Size(116, 32);
            this.btnSelectRace.TabIndex = 22;
            this.btnSelectRace.Text = "Select Race";
            this.btnSelectRace.UseVisualStyleBackColor = true;
            this.btnSelectRace.Click += new System.EventHandler(this.btnSelectRace_Click);
            // 
            // lblSpeeds
            // 
            this.lblSpeeds.AutoSize = true;
            this.lblSpeeds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeeds.Location = new System.Drawing.Point(696, 398);
            this.lblSpeeds.Name = "lblSpeeds";
            this.lblSpeeds.Size = new System.Drawing.Size(123, 19);
            this.lblSpeeds.TabIndex = 24;
            this.lblSpeeds.Text = "Movement Speeds";
            // 
            // lsbSpeeds
            // 
            this.lsbSpeeds.FormattingEnabled = true;
            this.lsbSpeeds.ItemHeight = 17;
            this.lsbSpeeds.Location = new System.Drawing.Point(696, 424);
            this.lsbSpeeds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbSpeeds.Name = "lsbSpeeds";
            this.lsbSpeeds.Size = new System.Drawing.Size(223, 72);
            this.lsbSpeeds.TabIndex = 23;
            // 
            // clbPrimitive
            // 
            this.clbPrimitive.AutoSize = true;
            this.clbPrimitive.Enabled = false;
            this.clbPrimitive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbPrimitive.Location = new System.Drawing.Point(704, 212);
            this.clbPrimitive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clbPrimitive.Name = "clbPrimitive";
            this.clbPrimitive.Size = new System.Drawing.Size(76, 21);
            this.clbPrimitive.TabIndex = 25;
            this.clbPrimitive.Text = "Primitive";
            this.clbPrimitive.UseVisualStyleBackColor = true;
            // 
            // ckbBonusLevelFeat
            // 
            this.ckbBonusLevelFeat.AutoSize = true;
            this.ckbBonusLevelFeat.Enabled = false;
            this.ckbBonusLevelFeat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbBonusLevelFeat.Location = new System.Drawing.Point(784, 212);
            this.ckbBonusLevelFeat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckbBonusLevelFeat.Name = "ckbBonusLevelFeat";
            this.ckbBonusLevelFeat.Size = new System.Drawing.Size(123, 21);
            this.ckbBonusLevelFeat.TabIndex = 26;
            this.ckbBonusLevelFeat.Text = "Bonus Level Feat";
            this.ckbBonusLevelFeat.UseVisualStyleBackColor = true;
            // 
            // ckbBonusSkill
            // 
            this.ckbBonusSkill.AutoSize = true;
            this.ckbBonusSkill.Enabled = false;
            this.ckbBonusSkill.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbBonusSkill.Location = new System.Drawing.Point(784, 244);
            this.ckbBonusSkill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckbBonusSkill.Name = "ckbBonusSkill";
            this.ckbBonusSkill.Size = new System.Drawing.Size(88, 21);
            this.ckbBonusSkill.TabIndex = 27;
            this.ckbBonusSkill.Text = "Bonus Skill";
            this.ckbBonusSkill.UseVisualStyleBackColor = true;
            // 
            // lblDefenseModifier
            // 
            this.lblDefenseModifier.AutoSize = true;
            this.lblDefenseModifier.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefenseModifier.Location = new System.Drawing.Point(232, 398);
            this.lblDefenseModifier.Name = "lblDefenseModifier";
            this.lblDefenseModifier.Size = new System.Drawing.Size(113, 19);
            this.lblDefenseModifier.TabIndex = 29;
            this.lblDefenseModifier.Text = "Defense Modifier";
            // 
            // lsbDefenseModifiers
            // 
            this.lsbDefenseModifiers.FormattingEnabled = true;
            this.lsbDefenseModifiers.ItemHeight = 17;
            this.lsbDefenseModifiers.Location = new System.Drawing.Point(232, 424);
            this.lsbDefenseModifiers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbDefenseModifiers.Name = "lsbDefenseModifiers";
            this.lsbDefenseModifiers.Size = new System.Drawing.Size(223, 72);
            this.lsbDefenseModifiers.TabIndex = 28;
            // 
            // lblRaceLanguages
            // 
            this.lblRaceLanguages.AutoSize = true;
            this.lblRaceLanguages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceLanguages.Location = new System.Drawing.Point(464, 398);
            this.lblRaceLanguages.Name = "lblRaceLanguages";
            this.lblRaceLanguages.Size = new System.Drawing.Size(107, 19);
            this.lblRaceLanguages.TabIndex = 31;
            this.lblRaceLanguages.Text = "Race Languages";
            // 
            // lsbRaceLanguages
            // 
            this.lsbRaceLanguages.FormattingEnabled = true;
            this.lsbRaceLanguages.ItemHeight = 17;
            this.lsbRaceLanguages.Location = new System.Drawing.Point(464, 424);
            this.lsbRaceLanguages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbRaceLanguages.Name = "lsbRaceLanguages";
            this.lsbRaceLanguages.Size = new System.Drawing.Size(223, 72);
            this.lsbRaceLanguages.TabIndex = 30;
            // 
            // lblConditionalFeats
            // 
            this.lblConditionalFeats.AutoSize = true;
            this.lblConditionalFeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConditionalFeats.Location = new System.Drawing.Point(232, 496);
            this.lblConditionalFeats.Name = "lblConditionalFeats";
            this.lblConditionalFeats.Size = new System.Drawing.Size(115, 19);
            this.lblConditionalFeats.TabIndex = 33;
            this.lblConditionalFeats.Text = "Conditional Feats";
            // 
            // lsbConditionalFeats
            // 
            this.lsbConditionalFeats.FormattingEnabled = true;
            this.lsbConditionalFeats.ItemHeight = 17;
            this.lsbConditionalFeats.Location = new System.Drawing.Point(232, 522);
            this.lsbConditionalFeats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbConditionalFeats.Name = "lsbConditionalFeats";
            this.lsbConditionalFeats.Size = new System.Drawing.Size(684, 72);
            this.lsbConditionalFeats.TabIndex = 32;
            // 
            // lblSpecialAbilities
            // 
            this.lblSpecialAbilities.AutoSize = true;
            this.lblSpecialAbilities.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialAbilities.Location = new System.Drawing.Point(232, 596);
            this.lblSpecialAbilities.Name = "lblSpecialAbilities";
            this.lblSpecialAbilities.Size = new System.Drawing.Size(101, 19);
            this.lblSpecialAbilities.TabIndex = 35;
            this.lblSpecialAbilities.Text = "Special Abilities";
            // 
            // lvRaceSpcialAbilities
            // 
            this.lvRaceSpcialAbilities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAbilityName});
            this.lvRaceSpcialAbilities.FullRowSelect = true;
            this.lvRaceSpcialAbilities.Location = new System.Drawing.Point(232, 620);
            this.lvRaceSpcialAbilities.MultiSelect = false;
            this.lvRaceSpcialAbilities.Name = "lvRaceSpcialAbilities";
            this.lvRaceSpcialAbilities.Scrollable = false;
            this.lvRaceSpcialAbilities.Size = new System.Drawing.Size(328, 96);
            this.lvRaceSpcialAbilities.TabIndex = 36;
            this.lvRaceSpcialAbilities.UseCompatibleStateImageBehavior = false;
            this.lvRaceSpcialAbilities.View = System.Windows.Forms.View.Details;
            this.lvRaceSpcialAbilities.Click += new System.EventHandler(this.lvRaceSpcialAbilities_Click);
            // 
            // chAbilityName
            // 
            this.chAbilityName.Text = "Name";
            this.chAbilityName.Width = 101;
            // 
            // txtRaceSpecialAbilityDescription
            // 
            this.txtRaceSpecialAbilityDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaceSpecialAbilityDescription.Location = new System.Drawing.Point(564, 620);
            this.txtRaceSpecialAbilityDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRaceSpecialAbilityDescription.Multiline = true;
            this.txtRaceSpecialAbilityDescription.Name = "txtRaceSpecialAbilityDescription";
            this.txtRaceSpecialAbilityDescription.ReadOnly = true;
            this.txtRaceSpecialAbilityDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRaceSpecialAbilityDescription.Size = new System.Drawing.Size(356, 96);
            this.txtRaceSpecialAbilityDescription.TabIndex = 37;
            // 
            // frmCharCreate2GetRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 720);
            this.Controls.Add(this.txtRaceSpecialAbilityDescription);
            this.Controls.Add(this.lvRaceSpcialAbilities);
            this.Controls.Add(this.lblSpecialAbilities);
            this.Controls.Add(this.lblConditionalFeats);
            this.Controls.Add(this.lsbConditionalFeats);
            this.Controls.Add(this.lblRaceLanguages);
            this.Controls.Add(this.lsbRaceLanguages);
            this.Controls.Add(this.lblDefenseModifier);
            this.Controls.Add(this.lsbDefenseModifiers);
            this.Controls.Add(this.ckbBonusSkill);
            this.Controls.Add(this.ckbBonusLevelFeat);
            this.Controls.Add(this.clbPrimitive);
            this.Controls.Add(this.lblSpeeds);
            this.Controls.Add(this.lsbSpeeds);
            this.Controls.Add(this.btnSelectRace);
            this.Controls.Add(this.lblBonusFeats);
            this.Controls.Add(this.lsbBonusFeats);
            this.Controls.Add(this.lblRaceSkills);
            this.Controls.Add(this.lsbRaceSkills);
            this.Controls.Add(this.lblAbilityMods);
            this.Controls.Add(this.lsbAbilityMods);
            this.Controls.Add(this.ckbShapeShift);
            this.Controls.Add(this.ckbRage);
            this.Controls.Add(this.txtAvgWeight);
            this.Controls.Add(this.lblAvgWeight);
            this.Controls.Add(this.txtAvgHeight);
            this.Controls.Add(this.lblAvgHeight);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.txtOtherDescription);
            this.Controls.Add(this.lblOtherDescription);
            this.Controls.Add(this.txtRaceDescription);
            this.Controls.Add(this.lblRaceDescription);
            this.Controls.Add(this.txtRaceName);
            this.Controls.Add(this.lblRaceName);
            this.Controls.Add(this.lblRace);
            this.Controls.Add(this.lsbRace);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmCharCreate2GetRace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Race";
            this.Load += new System.EventHandler(this.frmCharCreate2GetRace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbRace;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.Label lblRaceName;
        private System.Windows.Forms.TextBox txtRaceName;
        private System.Windows.Forms.TextBox txtRaceDescription;
        private System.Windows.Forms.Label lblRaceDescription;
        private System.Windows.Forms.TextBox txtOtherDescription;
        private System.Windows.Forms.Label lblOtherDescription;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.TextBox txtAvgHeight;
        private System.Windows.Forms.Label lblAvgHeight;
        private System.Windows.Forms.TextBox txtAvgWeight;
        private System.Windows.Forms.Label lblAvgWeight;
        private System.Windows.Forms.CheckBox ckbRage;
        private System.Windows.Forms.CheckBox ckbShapeShift;
        private System.Windows.Forms.ListBox lsbAbilityMods;
        private System.Windows.Forms.Label lblAbilityMods;
        private System.Windows.Forms.Label lblRaceSkills;
        private System.Windows.Forms.ListBox lsbRaceSkills;
        private System.Windows.Forms.Label lblBonusFeats;
        private System.Windows.Forms.ListBox lsbBonusFeats;
        private System.Windows.Forms.Button btnSelectRace;
        private System.Windows.Forms.Label lblSpeeds;
        private System.Windows.Forms.ListBox lsbSpeeds;
        private System.Windows.Forms.CheckBox clbPrimitive;
        private System.Windows.Forms.CheckBox ckbBonusLevelFeat;
        private System.Windows.Forms.CheckBox ckbBonusSkill;
        private System.Windows.Forms.Label lblDefenseModifier;
        private System.Windows.Forms.ListBox lsbDefenseModifiers;
        private System.Windows.Forms.Label lblRaceLanguages;
        private System.Windows.Forms.ListBox lsbRaceLanguages;
        private System.Windows.Forms.Label lblConditionalFeats;
        private System.Windows.Forms.ListBox lsbConditionalFeats;
        private System.Windows.Forms.Label lblSpecialAbilities;
        private System.Windows.Forms.ListView lvRaceSpcialAbilities;
        private System.Windows.Forms.ColumnHeader chAbilityName;
        private System.Windows.Forms.TextBox txtRaceSpecialAbilityDescription;
    }
}