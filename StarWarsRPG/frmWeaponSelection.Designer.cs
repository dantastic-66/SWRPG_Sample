namespace StarWarsRPG
{
    partial class frmWeaponSelection
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
            this.gpWeapons = new System.Windows.Forms.GroupBox();
            this.ckbHideNonProficientWeapons = new System.Windows.Forms.CheckBox();
            this.tvWeaponList = new System.Windows.Forms.TreeView();
            this.grpWeaponDetail = new System.Windows.Forms.GroupBox();
            this.btnSelectWeapon = new System.Windows.Forms.Button();
            this.grpCharacterStats = new System.Windows.Forms.GroupBox();
            this.lblRangeStats = new System.Windows.Forms.Label();
            this.txtRangeDamageBonus = new System.Windows.Forms.TextBox();
            this.lblMelee = new System.Windows.Forms.Label();
            this.txtRangeAttackBonus = new System.Windows.Forms.TextBox();
            this.txtMeleeDamageBonus = new System.Windows.Forms.TextBox();
            this.lblRangeAttackBonus = new System.Windows.Forms.Label();
            this.lblRangeDamageBonus = new System.Windows.Forms.Label();
            this.txtMeleeAttackBonus = new System.Windows.Forms.TextBox();
            this.lblMeleeAttackBonus = new System.Windows.Forms.Label();
            this.lblMeleeDamageBonus = new System.Windows.Forms.Label();
            this.txtWeaponNotes = new System.Windows.Forms.TextBox();
            this.lblWeaponDescription = new System.Windows.Forms.Label();
            this.lblWeaponRanges = new System.Windows.Forms.Label();
            this.lvRanges = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBegin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chModifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtWeaponProficiencyFeat = new System.Windows.Forms.TextBox();
            this.lblProficiencyFeat = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.ckbStunDamage = new System.Windows.Forms.CheckBox();
            this.txtWeaponStunDamage = new System.Windows.Forms.TextBox();
            this.lblWeaponStunDamage = new System.Windows.Forms.Label();
            this.txtWeaponDamage = new System.Windows.Forms.TextBox();
            this.lblWeaponDamage = new System.Windows.Forms.Label();
            this.txtRateOfFire = new System.Windows.Forms.TextBox();
            this.lblRateOfFire = new System.Windows.Forms.Label();
            this.txtWeaponCost = new System.Windows.Forms.TextBox();
            this.lblWeaponCost = new System.Windows.Forms.Label();
            this.txtWeaponSize = new System.Windows.Forms.TextBox();
            this.lblWeaponSize = new System.Windows.Forms.Label();
            this.txtWeaponType = new System.Windows.Forms.TextBox();
            this.lblWeaponType = new System.Windows.Forms.Label();
            this.txtWeaponName = new System.Windows.Forms.TextBox();
            this.lblWeaponName = new System.Windows.Forms.Label();
            this.gpWeaponProperties = new System.Windows.Forms.GroupBox();
            this.ckbRequiresOrdiance = new System.Windows.Forms.CheckBox();
            this.ckbSlugThrower = new System.Windows.Forms.CheckBox();
            this.ckbInaccurate = new System.Windows.Forms.CheckBox();
            this.ckbAccurate = new System.Windows.Forms.CheckBox();
            this.ckbAreaOfAttack = new System.Windows.Forms.CheckBox();
            this.ckbDoubleWeapon = new System.Windows.Forms.CheckBox();
            this.gpWeapons.SuspendLayout();
            this.grpWeaponDetail.SuspendLayout();
            this.grpCharacterStats.SuspendLayout();
            this.gpWeaponProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpWeapons
            // 
            this.gpWeapons.Controls.Add(this.ckbHideNonProficientWeapons);
            this.gpWeapons.Controls.Add(this.tvWeaponList);
            this.gpWeapons.Location = new System.Drawing.Point(9, 5);
            this.gpWeapons.Name = "gpWeapons";
            this.gpWeapons.Size = new System.Drawing.Size(327, 547);
            this.gpWeapons.TabIndex = 1;
            this.gpWeapons.TabStop = false;
            this.gpWeapons.Text = "Select Weapon";
            // 
            // ckbHideNonProficientWeapons
            // 
            this.ckbHideNonProficientWeapons.AutoSize = true;
            this.ckbHideNonProficientWeapons.Location = new System.Drawing.Point(14, 23);
            this.ckbHideNonProficientWeapons.Name = "ckbHideNonProficientWeapons";
            this.ckbHideNonProficientWeapons.Size = new System.Drawing.Size(185, 19);
            this.ckbHideNonProficientWeapons.TabIndex = 1;
            this.ckbHideNonProficientWeapons.Text = "Hide Non-Proficient Weapons";
            this.ckbHideNonProficientWeapons.UseVisualStyleBackColor = true;
            this.ckbHideNonProficientWeapons.CheckedChanged += new System.EventHandler(this.ckbHideNonProficientWeapons_CheckedChanged);
            // 
            // tvWeaponList
            // 
            this.tvWeaponList.Location = new System.Drawing.Point(9, 55);
            this.tvWeaponList.Name = "tvWeaponList";
            this.tvWeaponList.Size = new System.Drawing.Size(312, 489);
            this.tvWeaponList.TabIndex = 0;
            this.tvWeaponList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWeaponList_AfterSelect);
            // 
            // grpWeaponDetail
            // 
            this.grpWeaponDetail.Controls.Add(this.gpWeaponProperties);
            this.grpWeaponDetail.Controls.Add(this.btnSelectWeapon);
            this.grpWeaponDetail.Controls.Add(this.grpCharacterStats);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponNotes);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponDescription);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponRanges);
            this.grpWeaponDetail.Controls.Add(this.lvRanges);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponProficiencyFeat);
            this.grpWeaponDetail.Controls.Add(this.lblProficiencyFeat);
            this.grpWeaponDetail.Controls.Add(this.txtBookName);
            this.grpWeaponDetail.Controls.Add(this.lblBook);
            this.grpWeaponDetail.Controls.Add(this.ckbStunDamage);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponStunDamage);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponStunDamage);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponDamage);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponDamage);
            this.grpWeaponDetail.Controls.Add(this.txtRateOfFire);
            this.grpWeaponDetail.Controls.Add(this.lblRateOfFire);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponCost);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponCost);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponSize);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponSize);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponType);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponType);
            this.grpWeaponDetail.Controls.Add(this.txtWeaponName);
            this.grpWeaponDetail.Controls.Add(this.lblWeaponName);
            this.grpWeaponDetail.Location = new System.Drawing.Point(344, 5);
            this.grpWeaponDetail.Name = "grpWeaponDetail";
            this.grpWeaponDetail.Size = new System.Drawing.Size(558, 547);
            this.grpWeaponDetail.TabIndex = 2;
            this.grpWeaponDetail.TabStop = false;
            this.grpWeaponDetail.Text = "Weapon";
            // 
            // btnSelectWeapon
            // 
            this.btnSelectWeapon.Enabled = false;
            this.btnSelectWeapon.Location = new System.Drawing.Point(392, 24);
            this.btnSelectWeapon.Name = "btnSelectWeapon";
            this.btnSelectWeapon.Size = new System.Drawing.Size(152, 23);
            this.btnSelectWeapon.TabIndex = 69;
            this.btnSelectWeapon.Text = "Select Weapon";
            this.btnSelectWeapon.UseVisualStyleBackColor = true;
            this.btnSelectWeapon.Click += new System.EventHandler(this.btnSelectWeapon_Click);
            // 
            // grpCharacterStats
            // 
            this.grpCharacterStats.Controls.Add(this.lblRangeStats);
            this.grpCharacterStats.Controls.Add(this.txtRangeDamageBonus);
            this.grpCharacterStats.Controls.Add(this.lblMelee);
            this.grpCharacterStats.Controls.Add(this.txtRangeAttackBonus);
            this.grpCharacterStats.Controls.Add(this.txtMeleeDamageBonus);
            this.grpCharacterStats.Controls.Add(this.lblRangeAttackBonus);
            this.grpCharacterStats.Controls.Add(this.lblRangeDamageBonus);
            this.grpCharacterStats.Controls.Add(this.txtMeleeAttackBonus);
            this.grpCharacterStats.Controls.Add(this.lblMeleeAttackBonus);
            this.grpCharacterStats.Controls.Add(this.lblMeleeDamageBonus);
            this.grpCharacterStats.Location = new System.Drawing.Point(4, 188);
            this.grpCharacterStats.Name = "grpCharacterStats";
            this.grpCharacterStats.Size = new System.Drawing.Size(268, 76);
            this.grpCharacterStats.TabIndex = 68;
            this.grpCharacterStats.TabStop = false;
            this.grpCharacterStats.Text = "Character Stats";
            // 
            // lblRangeStats
            // 
            this.lblRangeStats.AutoSize = true;
            this.lblRangeStats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRangeStats.Location = new System.Drawing.Point(8, 48);
            this.lblRangeStats.Name = "lblRangeStats";
            this.lblRangeStats.Size = new System.Drawing.Size(71, 15);
            this.lblRangeStats.TabIndex = 70;
            this.lblRangeStats.Text = "Range Stats:";
            // 
            // txtRangeDamageBonus
            // 
            this.txtRangeDamageBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRangeDamageBonus.Location = new System.Drawing.Point(216, 44);
            this.txtRangeDamageBonus.Name = "txtRangeDamageBonus";
            this.txtRangeDamageBonus.ReadOnly = true;
            this.txtRangeDamageBonus.Size = new System.Drawing.Size(44, 23);
            this.txtRangeDamageBonus.TabIndex = 1;
            // 
            // lblMelee
            // 
            this.lblMelee.AutoSize = true;
            this.lblMelee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMelee.Location = new System.Drawing.Point(8, 24);
            this.lblMelee.Name = "lblMelee";
            this.lblMelee.Size = new System.Drawing.Size(70, 15);
            this.lblMelee.TabIndex = 69;
            this.lblMelee.Text = "Melee Stats:";
            // 
            // txtRangeAttackBonus
            // 
            this.txtRangeAttackBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRangeAttackBonus.Location = new System.Drawing.Point(124, 44);
            this.txtRangeAttackBonus.Name = "txtRangeAttackBonus";
            this.txtRangeAttackBonus.ReadOnly = true;
            this.txtRangeAttackBonus.Size = new System.Drawing.Size(44, 23);
            this.txtRangeAttackBonus.TabIndex = 0;
            // 
            // txtMeleeDamageBonus
            // 
            this.txtMeleeDamageBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeleeDamageBonus.Location = new System.Drawing.Point(216, 20);
            this.txtMeleeDamageBonus.Name = "txtMeleeDamageBonus";
            this.txtMeleeDamageBonus.ReadOnly = true;
            this.txtMeleeDamageBonus.Size = new System.Drawing.Size(44, 23);
            this.txtMeleeDamageBonus.TabIndex = 1;
            // 
            // lblRangeAttackBonus
            // 
            this.lblRangeAttackBonus.AutoSize = true;
            this.lblRangeAttackBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangeAttackBonus.Location = new System.Drawing.Point(84, 48);
            this.lblRangeAttackBonus.Name = "lblRangeAttackBonus";
            this.lblRangeAttackBonus.Size = new System.Drawing.Size(34, 15);
            this.lblRangeAttackBonus.TabIndex = 2;
            this.lblRangeAttackBonus.Text = "+ Att";
            // 
            // lblRangeDamageBonus
            // 
            this.lblRangeDamageBonus.AutoSize = true;
            this.lblRangeDamageBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangeDamageBonus.Location = new System.Drawing.Point(168, 48);
            this.lblRangeDamageBonus.Name = "lblRangeDamageBonus";
            this.lblRangeDamageBonus.Size = new System.Drawing.Size(43, 15);
            this.lblRangeDamageBonus.TabIndex = 3;
            this.lblRangeDamageBonus.Text = "+ Dam";
            // 
            // txtMeleeAttackBonus
            // 
            this.txtMeleeAttackBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeleeAttackBonus.Location = new System.Drawing.Point(124, 20);
            this.txtMeleeAttackBonus.Name = "txtMeleeAttackBonus";
            this.txtMeleeAttackBonus.ReadOnly = true;
            this.txtMeleeAttackBonus.Size = new System.Drawing.Size(44, 23);
            this.txtMeleeAttackBonus.TabIndex = 0;
            // 
            // lblMeleeAttackBonus
            // 
            this.lblMeleeAttackBonus.AutoSize = true;
            this.lblMeleeAttackBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeleeAttackBonus.Location = new System.Drawing.Point(84, 24);
            this.lblMeleeAttackBonus.Name = "lblMeleeAttackBonus";
            this.lblMeleeAttackBonus.Size = new System.Drawing.Size(34, 15);
            this.lblMeleeAttackBonus.TabIndex = 2;
            this.lblMeleeAttackBonus.Text = "+ Att";
            // 
            // lblMeleeDamageBonus
            // 
            this.lblMeleeDamageBonus.AutoSize = true;
            this.lblMeleeDamageBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeleeDamageBonus.Location = new System.Drawing.Point(172, 24);
            this.lblMeleeDamageBonus.Name = "lblMeleeDamageBonus";
            this.lblMeleeDamageBonus.Size = new System.Drawing.Size(43, 15);
            this.lblMeleeDamageBonus.TabIndex = 3;
            this.lblMeleeDamageBonus.Text = "+ Dam";
            // 
            // txtWeaponNotes
            // 
            this.txtWeaponNotes.Location = new System.Drawing.Point(4, 296);
            this.txtWeaponNotes.Multiline = true;
            this.txtWeaponNotes.Name = "txtWeaponNotes";
            this.txtWeaponNotes.ReadOnly = true;
            this.txtWeaponNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWeaponNotes.Size = new System.Drawing.Size(548, 188);
            this.txtWeaponNotes.TabIndex = 67;
            // 
            // lblWeaponDescription
            // 
            this.lblWeaponDescription.AutoSize = true;
            this.lblWeaponDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponDescription.Location = new System.Drawing.Point(12, 272);
            this.lblWeaponDescription.Name = "lblWeaponDescription";
            this.lblWeaponDescription.Size = new System.Drawing.Size(130, 17);
            this.lblWeaponDescription.TabIndex = 66;
            this.lblWeaponDescription.Text = "Weapon Description:";
            // 
            // lblWeaponRanges
            // 
            this.lblWeaponRanges.AutoSize = true;
            this.lblWeaponRanges.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponRanges.Location = new System.Drawing.Point(280, 140);
            this.lblWeaponRanges.Name = "lblWeaponRanges";
            this.lblWeaponRanges.Size = new System.Drawing.Size(54, 17);
            this.lblWeaponRanges.TabIndex = 65;
            this.lblWeaponRanges.Text = "Ranges:";
            // 
            // lvRanges
            // 
            this.lvRanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chBegin,
            this.chEnd,
            this.chModifier});
            this.lvRanges.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRanges.GridLines = true;
            this.lvRanges.Location = new System.Drawing.Point(276, 164);
            this.lvRanges.Name = "lvRanges";
            this.lvRanges.Size = new System.Drawing.Size(276, 128);
            this.lvRanges.TabIndex = 64;
            this.lvRanges.UseCompatibleStateImageBehavior = false;
            this.lvRanges.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 79;
            // 
            // chBegin
            // 
            this.chBegin.Text = "Begin";
            this.chBegin.Width = 45;
            // 
            // chEnd
            // 
            this.chEnd.Text = "End";
            this.chEnd.Width = 32;
            // 
            // chModifier
            // 
            this.chModifier.Text = "Modifier";
            // 
            // txtWeaponProficiencyFeat
            // 
            this.txtWeaponProficiencyFeat.Location = new System.Drawing.Point(4, 160);
            this.txtWeaponProficiencyFeat.Name = "txtWeaponProficiencyFeat";
            this.txtWeaponProficiencyFeat.ReadOnly = true;
            this.txtWeaponProficiencyFeat.Size = new System.Drawing.Size(240, 23);
            this.txtWeaponProficiencyFeat.TabIndex = 18;
            // 
            // lblProficiencyFeat
            // 
            this.lblProficiencyFeat.AutoSize = true;
            this.lblProficiencyFeat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProficiencyFeat.Location = new System.Drawing.Point(4, 140);
            this.lblProficiencyFeat.Name = "lblProficiencyFeat";
            this.lblProficiencyFeat.Size = new System.Drawing.Size(101, 17);
            this.lblProficiencyFeat.TabIndex = 17;
            this.lblProficiencyFeat.Text = "Proficiency Feat:";
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(212, 80);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.ReadOnly = true;
            this.txtBookName.Size = new System.Drawing.Size(180, 23);
            this.txtBookName.TabIndex = 16;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBook.Location = new System.Drawing.Point(168, 80);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(40, 17);
            this.lblBook.TabIndex = 15;
            this.lblBook.Text = "Book:";
            // 
            // ckbStunDamage
            // 
            this.ckbStunDamage.AutoSize = true;
            this.ckbStunDamage.Enabled = false;
            this.ckbStunDamage.Location = new System.Drawing.Point(236, 112);
            this.ckbStunDamage.Name = "ckbStunDamage";
            this.ckbStunDamage.Size = new System.Drawing.Size(50, 19);
            this.ckbStunDamage.TabIndex = 14;
            this.ckbStunDamage.Text = "Stun";
            this.ckbStunDamage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbStunDamage.UseVisualStyleBackColor = true;
            // 
            // txtWeaponStunDamage
            // 
            this.txtWeaponStunDamage.Location = new System.Drawing.Point(392, 112);
            this.txtWeaponStunDamage.Name = "txtWeaponStunDamage";
            this.txtWeaponStunDamage.ReadOnly = true;
            this.txtWeaponStunDamage.Size = new System.Drawing.Size(148, 23);
            this.txtWeaponStunDamage.TabIndex = 13;
            // 
            // lblWeaponStunDamage
            // 
            this.lblWeaponStunDamage.AutoSize = true;
            this.lblWeaponStunDamage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponStunDamage.Location = new System.Drawing.Point(296, 112);
            this.lblWeaponStunDamage.Name = "lblWeaponStunDamage";
            this.lblWeaponStunDamage.Size = new System.Drawing.Size(89, 17);
            this.lblWeaponStunDamage.TabIndex = 12;
            this.lblWeaponStunDamage.Text = "Stun Damage:";
            // 
            // txtWeaponDamage
            // 
            this.txtWeaponDamage.Location = new System.Drawing.Point(68, 112);
            this.txtWeaponDamage.Name = "txtWeaponDamage";
            this.txtWeaponDamage.ReadOnly = true;
            this.txtWeaponDamage.Size = new System.Drawing.Size(160, 23);
            this.txtWeaponDamage.TabIndex = 11;
            // 
            // lblWeaponDamage
            // 
            this.lblWeaponDamage.AutoSize = true;
            this.lblWeaponDamage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponDamage.Location = new System.Drawing.Point(4, 112);
            this.lblWeaponDamage.Name = "lblWeaponDamage";
            this.lblWeaponDamage.Size = new System.Drawing.Size(60, 17);
            this.lblWeaponDamage.TabIndex = 10;
            this.lblWeaponDamage.Text = "Damage:";
            // 
            // txtRateOfFire
            // 
            this.txtRateOfFire.Location = new System.Drawing.Point(480, 80);
            this.txtRateOfFire.Name = "txtRateOfFire";
            this.txtRateOfFire.ReadOnly = true;
            this.txtRateOfFire.Size = new System.Drawing.Size(60, 23);
            this.txtRateOfFire.TabIndex = 9;
            // 
            // lblRateOfFire
            // 
            this.lblRateOfFire.AutoSize = true;
            this.lblRateOfFire.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateOfFire.Location = new System.Drawing.Point(396, 80);
            this.lblRateOfFire.Name = "lblRateOfFire";
            this.lblRateOfFire.Size = new System.Drawing.Size(80, 17);
            this.lblRateOfFire.TabIndex = 8;
            this.lblRateOfFire.Text = "Rate Of Fire:";
            // 
            // txtWeaponCost
            // 
            this.txtWeaponCost.Location = new System.Drawing.Point(480, 52);
            this.txtWeaponCost.Name = "txtWeaponCost";
            this.txtWeaponCost.ReadOnly = true;
            this.txtWeaponCost.Size = new System.Drawing.Size(60, 23);
            this.txtWeaponCost.TabIndex = 7;
            // 
            // lblWeaponCost
            // 
            this.lblWeaponCost.AutoSize = true;
            this.lblWeaponCost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponCost.Location = new System.Drawing.Point(436, 56);
            this.lblWeaponCost.Name = "lblWeaponCost";
            this.lblWeaponCost.Size = new System.Drawing.Size(37, 17);
            this.lblWeaponCost.TabIndex = 6;
            this.lblWeaponCost.Text = "Cost:";
            // 
            // txtWeaponSize
            // 
            this.txtWeaponSize.Location = new System.Drawing.Point(56, 80);
            this.txtWeaponSize.Name = "txtWeaponSize";
            this.txtWeaponSize.ReadOnly = true;
            this.txtWeaponSize.Size = new System.Drawing.Size(108, 23);
            this.txtWeaponSize.TabIndex = 5;
            // 
            // lblWeaponSize
            // 
            this.lblWeaponSize.AutoSize = true;
            this.lblWeaponSize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponSize.Location = new System.Drawing.Point(4, 80);
            this.lblWeaponSize.Name = "lblWeaponSize";
            this.lblWeaponSize.Size = new System.Drawing.Size(34, 17);
            this.lblWeaponSize.TabIndex = 4;
            this.lblWeaponSize.Text = "Size:";
            // 
            // txtWeaponType
            // 
            this.txtWeaponType.Location = new System.Drawing.Point(56, 52);
            this.txtWeaponType.Name = "txtWeaponType";
            this.txtWeaponType.ReadOnly = true;
            this.txtWeaponType.Size = new System.Drawing.Size(320, 23);
            this.txtWeaponType.TabIndex = 3;
            // 
            // lblWeaponType
            // 
            this.lblWeaponType.AutoSize = true;
            this.lblWeaponType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponType.Location = new System.Drawing.Point(4, 56);
            this.lblWeaponType.Name = "lblWeaponType";
            this.lblWeaponType.Size = new System.Drawing.Size(39, 17);
            this.lblWeaponType.TabIndex = 2;
            this.lblWeaponType.Text = "Type:";
            // 
            // txtWeaponName
            // 
            this.txtWeaponName.Location = new System.Drawing.Point(56, 24);
            this.txtWeaponName.Name = "txtWeaponName";
            this.txtWeaponName.ReadOnly = true;
            this.txtWeaponName.Size = new System.Drawing.Size(320, 23);
            this.txtWeaponName.TabIndex = 1;
            // 
            // lblWeaponName
            // 
            this.lblWeaponName.AutoSize = true;
            this.lblWeaponName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponName.Location = new System.Drawing.Point(4, 28);
            this.lblWeaponName.Name = "lblWeaponName";
            this.lblWeaponName.Size = new System.Drawing.Size(46, 17);
            this.lblWeaponName.TabIndex = 0;
            this.lblWeaponName.Text = "Name:";
            // 
            // gpWeaponProperties
            // 
            this.gpWeaponProperties.Controls.Add(this.ckbRequiresOrdiance);
            this.gpWeaponProperties.Controls.Add(this.ckbSlugThrower);
            this.gpWeaponProperties.Controls.Add(this.ckbInaccurate);
            this.gpWeaponProperties.Controls.Add(this.ckbAccurate);
            this.gpWeaponProperties.Controls.Add(this.ckbAreaOfAttack);
            this.gpWeaponProperties.Controls.Add(this.ckbDoubleWeapon);
            this.gpWeaponProperties.Location = new System.Drawing.Point(8, 487);
            this.gpWeaponProperties.Name = "gpWeaponProperties";
            this.gpWeaponProperties.Size = new System.Drawing.Size(544, 56);
            this.gpWeaponProperties.TabIndex = 97;
            this.gpWeaponProperties.TabStop = false;
            // 
            // ckbRequiresOrdiance
            // 
            this.ckbRequiresOrdiance.AutoSize = true;
            this.ckbRequiresOrdiance.Enabled = false;
            this.ckbRequiresOrdiance.Location = new System.Drawing.Point(420, 36);
            this.ckbRequiresOrdiance.Name = "ckbRequiresOrdiance";
            this.ckbRequiresOrdiance.Size = new System.Drawing.Size(122, 19);
            this.ckbRequiresOrdiance.TabIndex = 5;
            this.ckbRequiresOrdiance.Text = "Requires Ordiance";
            this.ckbRequiresOrdiance.UseVisualStyleBackColor = true;
            // 
            // ckbSlugThrower
            // 
            this.ckbSlugThrower.AutoSize = true;
            this.ckbSlugThrower.Enabled = false;
            this.ckbSlugThrower.Location = new System.Drawing.Point(442, 16);
            this.ckbSlugThrower.Name = "ckbSlugThrower";
            this.ckbSlugThrower.Size = new System.Drawing.Size(96, 19);
            this.ckbSlugThrower.TabIndex = 4;
            this.ckbSlugThrower.Text = "Slug Thrower";
            this.ckbSlugThrower.UseVisualStyleBackColor = true;
            // 
            // ckbInaccurate
            // 
            this.ckbInaccurate.AutoSize = true;
            this.ckbInaccurate.Enabled = false;
            this.ckbInaccurate.Location = new System.Drawing.Point(142, 16);
            this.ckbInaccurate.Name = "ckbInaccurate";
            this.ckbInaccurate.Size = new System.Drawing.Size(81, 19);
            this.ckbInaccurate.TabIndex = 3;
            this.ckbInaccurate.Text = "Inaccurate";
            this.ckbInaccurate.UseVisualStyleBackColor = true;
            // 
            // ckbAccurate
            // 
            this.ckbAccurate.AutoSize = true;
            this.ckbAccurate.Enabled = false;
            this.ckbAccurate.Location = new System.Drawing.Point(8, 16);
            this.ckbAccurate.Name = "ckbAccurate";
            this.ckbAccurate.Size = new System.Drawing.Size(73, 19);
            this.ckbAccurate.TabIndex = 2;
            this.ckbAccurate.Text = "Accurate";
            this.ckbAccurate.UseVisualStyleBackColor = true;
            // 
            // ckbAreaOfAttack
            // 
            this.ckbAreaOfAttack.AutoSize = true;
            this.ckbAreaOfAttack.Enabled = false;
            this.ckbAreaOfAttack.Location = new System.Drawing.Point(284, 16);
            this.ckbAreaOfAttack.Name = "ckbAreaOfAttack";
            this.ckbAreaOfAttack.Size = new System.Drawing.Size(97, 19);
            this.ckbAreaOfAttack.TabIndex = 1;
            this.ckbAreaOfAttack.Text = "Area Weapon";
            this.ckbAreaOfAttack.UseVisualStyleBackColor = true;
            // 
            // ckbDoubleWeapon
            // 
            this.ckbDoubleWeapon.AutoSize = true;
            this.ckbDoubleWeapon.Enabled = false;
            this.ckbDoubleWeapon.Location = new System.Drawing.Point(8, 36);
            this.ckbDoubleWeapon.Name = "ckbDoubleWeapon";
            this.ckbDoubleWeapon.Size = new System.Drawing.Size(111, 19);
            this.ckbDoubleWeapon.TabIndex = 0;
            this.ckbDoubleWeapon.Text = "Double Weapon";
            this.ckbDoubleWeapon.UseVisualStyleBackColor = true;
            // 
            // frmWeaponSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 557);
            this.Controls.Add(this.grpWeaponDetail);
            this.Controls.Add(this.gpWeapons);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWeaponSelection";
            this.Text = "Select Weapon";
            this.gpWeapons.ResumeLayout(false);
            this.gpWeapons.PerformLayout();
            this.grpWeaponDetail.ResumeLayout(false);
            this.grpWeaponDetail.PerformLayout();
            this.grpCharacterStats.ResumeLayout(false);
            this.grpCharacterStats.PerformLayout();
            this.gpWeaponProperties.ResumeLayout(false);
            this.gpWeaponProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpWeapons;
        private System.Windows.Forms.TreeView tvWeaponList;
        private System.Windows.Forms.CheckBox ckbHideNonProficientWeapons;
        private System.Windows.Forms.GroupBox grpWeaponDetail;
        private System.Windows.Forms.CheckBox ckbStunDamage;
        private System.Windows.Forms.TextBox txtWeaponStunDamage;
        private System.Windows.Forms.Label lblWeaponStunDamage;
        private System.Windows.Forms.TextBox txtWeaponDamage;
        private System.Windows.Forms.Label lblWeaponDamage;
        private System.Windows.Forms.TextBox txtRateOfFire;
        private System.Windows.Forms.Label lblRateOfFire;
        private System.Windows.Forms.TextBox txtWeaponCost;
        private System.Windows.Forms.Label lblWeaponCost;
        private System.Windows.Forms.TextBox txtWeaponSize;
        private System.Windows.Forms.Label lblWeaponSize;
        private System.Windows.Forms.TextBox txtWeaponType;
        private System.Windows.Forms.Label lblWeaponType;
        private System.Windows.Forms.TextBox txtWeaponName;
        private System.Windows.Forms.Label lblWeaponName;
        private System.Windows.Forms.TextBox txtWeaponProficiencyFeat;
        private System.Windows.Forms.Label lblProficiencyFeat;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.TextBox txtWeaponNotes;
        private System.Windows.Forms.Label lblWeaponDescription;
        private System.Windows.Forms.Label lblWeaponRanges;
        private System.Windows.Forms.ListView lvRanges;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chBegin;
        private System.Windows.Forms.ColumnHeader chEnd;
        private System.Windows.Forms.ColumnHeader chModifier;
        private System.Windows.Forms.GroupBox grpCharacterStats;
        private System.Windows.Forms.Label lblRangeStats;
        private System.Windows.Forms.TextBox txtRangeDamageBonus;
        private System.Windows.Forms.Label lblMelee;
        private System.Windows.Forms.TextBox txtRangeAttackBonus;
        private System.Windows.Forms.TextBox txtMeleeDamageBonus;
        private System.Windows.Forms.Label lblRangeAttackBonus;
        private System.Windows.Forms.Label lblRangeDamageBonus;
        private System.Windows.Forms.TextBox txtMeleeAttackBonus;
        private System.Windows.Forms.Label lblMeleeAttackBonus;
        private System.Windows.Forms.Label lblMeleeDamageBonus;
        private System.Windows.Forms.Button btnSelectWeapon;
        private System.Windows.Forms.GroupBox gpWeaponProperties;
        private System.Windows.Forms.CheckBox ckbRequiresOrdiance;
        private System.Windows.Forms.CheckBox ckbSlugThrower;
        private System.Windows.Forms.CheckBox ckbInaccurate;
        private System.Windows.Forms.CheckBox ckbAccurate;
        private System.Windows.Forms.CheckBox ckbAreaOfAttack;
        private System.Windows.Forms.CheckBox ckbDoubleWeapon;
    }
}