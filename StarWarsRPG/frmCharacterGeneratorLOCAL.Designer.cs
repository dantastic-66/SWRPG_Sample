namespace StarWarsRPG
{
    partial class frmCharacterGeneratorLOCAL
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
            this.components = new System.ComponentModel.Container();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblStrengthValue = new System.Windows.Forms.Label();
            this.lblIntelligenceValue = new System.Windows.Forms.Label();
            this.lblIntelligence = new System.Windows.Forms.Label();
            this.lblWisdomValue = new System.Windows.Forms.Label();
            this.lblWisdom = new System.Windows.Forms.Label();
            this.lblConstitutionValue = new System.Windows.Forms.Label();
            this.lblConstitution = new System.Windows.Forms.Label();
            this.lblDexterityValue = new System.Windows.Forms.Label();
            this.lblDexterity = new System.Windows.Forms.Label();
            this.lblCharismaValue = new System.Windows.Forms.Label();
            this.lblCharisma = new System.Windows.Forms.Label();
            this.lblValue4 = new System.Windows.Forms.Label();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.txtValue4 = new System.Windows.Forms.TextBox();
            this.btnGenerateValues = new System.Windows.Forms.Button();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.btnReroll1 = new System.Windows.Forms.Button();
            this.btnReroll2 = new System.Windows.Forms.Button();
            this.btnReroll3 = new System.Windows.Forms.Button();
            this.btnReroll4 = new System.Windows.Forms.Button();
            this.lblStrengthMod = new System.Windows.Forms.Label();
            this.lblCharismaMod = new System.Windows.Forms.Label();
            this.lblDexterityMod = new System.Windows.Forms.Label();
            this.lblConstitutionMod = new System.Windows.Forms.Label();
            this.lblWisdomMod = new System.Windows.Forms.Label();
            this.lblIntelligenceMod = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblMod = new System.Windows.Forms.Label();
            this.cmbAbility1 = new System.Windows.Forms.ComboBox();
            this.txtAbility1 = new System.Windows.Forms.TextBox();
            this.txtAbility2 = new System.Windows.Forms.TextBox();
            this.cmbAbility2 = new System.Windows.Forms.ComboBox();
            this.txtAbility3 = new System.Windows.Forms.TextBox();
            this.cmbAbility3 = new System.Windows.Forms.ComboBox();
            this.txtAbility4 = new System.Windows.Forms.TextBox();
            this.cmbAbility4 = new System.Windows.Forms.ComboBox();
            this.txtAbility5 = new System.Windows.Forms.TextBox();
            this.cmbAbility5 = new System.Windows.Forms.ComboBox();
            this.txtAbility6 = new System.Windows.Forms.TextBox();
            this.cmbAbility6 = new System.Windows.Forms.ComboBox();
            this.btnSaveNReset = new System.Windows.Forms.Button();
            this.btnViewStats = new System.Windows.Forms.Button();
            this.btnCommitStats = new System.Windows.Forms.Button();
            this.btnGenerateValue1 = new System.Windows.Forms.Button();
            this.btnGenerateValue2 = new System.Windows.Forms.Button();
            this.btnGenerateValue3 = new System.Windows.Forms.Button();
            this.btnGenerateValue4 = new System.Windows.Forms.Button();
            this.tmrDieDelay = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableRerollOfOne1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStrength
            // 
            this.lblStrength.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrength.Location = new System.Drawing.Point(16, 35);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(80, 24);
            this.lblStrength.TabIndex = 0;
            this.lblStrength.Text = "Strength:";
            // 
            // lblStrengthValue
            // 
            this.lblStrengthValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrengthValue.Location = new System.Drawing.Point(112, 35);
            this.lblStrengthValue.Name = "lblStrengthValue";
            this.lblStrengthValue.Size = new System.Drawing.Size(40, 24);
            this.lblStrengthValue.TabIndex = 1;
            this.lblStrengthValue.TextChanged += new System.EventHandler(this.lblStrengthValue_TextChanged);
            // 
            // lblIntelligenceValue
            // 
            this.lblIntelligenceValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntelligenceValue.Location = new System.Drawing.Point(112, 68);
            this.lblIntelligenceValue.Name = "lblIntelligenceValue";
            this.lblIntelligenceValue.Size = new System.Drawing.Size(40, 24);
            this.lblIntelligenceValue.TabIndex = 3;
            this.lblIntelligenceValue.TextChanged += new System.EventHandler(this.lblIntelligenceValue_TextChanged);
            // 
            // lblIntelligence
            // 
            this.lblIntelligence.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntelligence.Location = new System.Drawing.Point(16, 68);
            this.lblIntelligence.Name = "lblIntelligence";
            this.lblIntelligence.Size = new System.Drawing.Size(80, 24);
            this.lblIntelligence.TabIndex = 2;
            this.lblIntelligence.Text = "Intelligence:";
            // 
            // lblWisdomValue
            // 
            this.lblWisdomValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWisdomValue.Location = new System.Drawing.Point(112, 101);
            this.lblWisdomValue.Name = "lblWisdomValue";
            this.lblWisdomValue.Size = new System.Drawing.Size(40, 24);
            this.lblWisdomValue.TabIndex = 5;
            this.lblWisdomValue.TextChanged += new System.EventHandler(this.lblWisdomValue_TextChanged);
            // 
            // lblWisdom
            // 
            this.lblWisdom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWisdom.Location = new System.Drawing.Point(16, 101);
            this.lblWisdom.Name = "lblWisdom";
            this.lblWisdom.Size = new System.Drawing.Size(80, 24);
            this.lblWisdom.TabIndex = 4;
            this.lblWisdom.Text = "Wisdom:";
            // 
            // lblConstitutionValue
            // 
            this.lblConstitutionValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConstitutionValue.Location = new System.Drawing.Point(112, 134);
            this.lblConstitutionValue.Name = "lblConstitutionValue";
            this.lblConstitutionValue.Size = new System.Drawing.Size(40, 24);
            this.lblConstitutionValue.TabIndex = 7;
            this.lblConstitutionValue.TextChanged += new System.EventHandler(this.lblConstitutionValue_TextChanged);
            // 
            // lblConstitution
            // 
            this.lblConstitution.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConstitution.Location = new System.Drawing.Point(16, 134);
            this.lblConstitution.Name = "lblConstitution";
            this.lblConstitution.Size = new System.Drawing.Size(80, 24);
            this.lblConstitution.TabIndex = 6;
            this.lblConstitution.Text = "Constitution:";
            // 
            // lblDexterityValue
            // 
            this.lblDexterityValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDexterityValue.Location = new System.Drawing.Point(112, 167);
            this.lblDexterityValue.Name = "lblDexterityValue";
            this.lblDexterityValue.Size = new System.Drawing.Size(40, 24);
            this.lblDexterityValue.TabIndex = 9;
            this.lblDexterityValue.TextChanged += new System.EventHandler(this.lblDexterityValue_TextChanged);
            // 
            // lblDexterity
            // 
            this.lblDexterity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDexterity.Location = new System.Drawing.Point(16, 167);
            this.lblDexterity.Name = "lblDexterity";
            this.lblDexterity.Size = new System.Drawing.Size(80, 24);
            this.lblDexterity.TabIndex = 8;
            this.lblDexterity.Text = "Dexterity:";
            // 
            // lblCharismaValue
            // 
            this.lblCharismaValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharismaValue.Location = new System.Drawing.Point(112, 200);
            this.lblCharismaValue.Name = "lblCharismaValue";
            this.lblCharismaValue.Size = new System.Drawing.Size(40, 24);
            this.lblCharismaValue.TabIndex = 11;
            this.lblCharismaValue.TextChanged += new System.EventHandler(this.lblCharismaValue_TextChanged);
            // 
            // lblCharisma
            // 
            this.lblCharisma.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharisma.Location = new System.Drawing.Point(16, 200);
            this.lblCharisma.Name = "lblCharisma";
            this.lblCharisma.Size = new System.Drawing.Size(80, 24);
            this.lblCharisma.TabIndex = 10;
            this.lblCharisma.Text = "Charisma:";
            // 
            // lblValue4
            // 
            this.lblValue4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue4.Location = new System.Drawing.Point(344, 142);
            this.lblValue4.Name = "lblValue4";
            this.lblValue4.Size = new System.Drawing.Size(64, 24);
            this.lblValue4.TabIndex = 12;
            this.lblValue4.Text = "Value 4:";
            // 
            // lblValue3
            // 
            this.lblValue3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue3.Location = new System.Drawing.Point(344, 108);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(64, 24);
            this.lblValue3.TabIndex = 13;
            this.lblValue3.Text = "Value 3:";
            // 
            // lblValue2
            // 
            this.lblValue2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue2.Location = new System.Drawing.Point(344, 74);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(64, 24);
            this.lblValue2.TabIndex = 14;
            this.lblValue2.Text = "Value 2:";
            // 
            // lblValue1
            // 
            this.lblValue1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue1.Location = new System.Drawing.Point(344, 40);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(64, 24);
            this.lblValue1.TabIndex = 15;
            this.lblValue1.Text = "Value 1:";
            // 
            // txtValue1
            // 
            this.txtValue1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue1.Location = new System.Drawing.Point(416, 40);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.ReadOnly = true;
            this.txtValue1.Size = new System.Drawing.Size(64, 25);
            this.txtValue1.TabIndex = 16;
            // 
            // txtValue2
            // 
            this.txtValue2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue2.Location = new System.Drawing.Point(416, 74);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.ReadOnly = true;
            this.txtValue2.Size = new System.Drawing.Size(64, 25);
            this.txtValue2.TabIndex = 17;
            // 
            // txtValue3
            // 
            this.txtValue3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue3.Location = new System.Drawing.Point(416, 108);
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.ReadOnly = true;
            this.txtValue3.Size = new System.Drawing.Size(64, 25);
            this.txtValue3.TabIndex = 18;
            // 
            // txtValue4
            // 
            this.txtValue4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue4.Location = new System.Drawing.Point(416, 142);
            this.txtValue4.Name = "txtValue4";
            this.txtValue4.ReadOnly = true;
            this.txtValue4.Size = new System.Drawing.Size(64, 25);
            this.txtValue4.TabIndex = 19;
            // 
            // btnGenerateValues
            // 
            this.btnGenerateValues.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValues.Location = new System.Drawing.Point(256, 168);
            this.btnGenerateValues.Name = "btnGenerateValues";
            this.btnGenerateValues.Size = new System.Drawing.Size(64, 48);
            this.btnGenerateValues.TabIndex = 20;
            this.btnGenerateValues.Text = "Roll All Die";
            this.btnGenerateValues.UseVisualStyleBackColor = true;
            this.btnGenerateValues.Click += new System.EventHandler(this.btnGenerateValues_Click);
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalValue.Location = new System.Drawing.Point(416, 184);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.ReadOnly = true;
            this.txtTotalValue.Size = new System.Drawing.Size(64, 25);
            this.txtTotalValue.TabIndex = 21;
            // 
            // btnReroll1
            // 
            this.btnReroll1.Enabled = false;
            this.btnReroll1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll1.Location = new System.Drawing.Point(496, 40);
            this.btnReroll1.Name = "btnReroll1";
            this.btnReroll1.Size = new System.Drawing.Size(64, 25);
            this.btnReroll1.TabIndex = 22;
            this.btnReroll1.Text = "Reroll";
            this.btnReroll1.UseVisualStyleBackColor = true;
            this.btnReroll1.Click += new System.EventHandler(this.btnReroll1_Click);
            // 
            // btnReroll2
            // 
            this.btnReroll2.Enabled = false;
            this.btnReroll2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll2.Location = new System.Drawing.Point(496, 74);
            this.btnReroll2.Name = "btnReroll2";
            this.btnReroll2.Size = new System.Drawing.Size(64, 25);
            this.btnReroll2.TabIndex = 23;
            this.btnReroll2.Text = "Reroll";
            this.btnReroll2.UseVisualStyleBackColor = true;
            this.btnReroll2.Click += new System.EventHandler(this.btnReroll2_Click);
            // 
            // btnReroll3
            // 
            this.btnReroll3.Enabled = false;
            this.btnReroll3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll3.Location = new System.Drawing.Point(496, 108);
            this.btnReroll3.Name = "btnReroll3";
            this.btnReroll3.Size = new System.Drawing.Size(64, 25);
            this.btnReroll3.TabIndex = 24;
            this.btnReroll3.Text = "Reroll";
            this.btnReroll3.UseVisualStyleBackColor = true;
            this.btnReroll3.Click += new System.EventHandler(this.btnReroll3_Click);
            // 
            // btnReroll4
            // 
            this.btnReroll4.Enabled = false;
            this.btnReroll4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll4.Location = new System.Drawing.Point(496, 142);
            this.btnReroll4.Name = "btnReroll4";
            this.btnReroll4.Size = new System.Drawing.Size(64, 25);
            this.btnReroll4.TabIndex = 25;
            this.btnReroll4.Text = "Reroll";
            this.btnReroll4.UseVisualStyleBackColor = true;
            this.btnReroll4.Click += new System.EventHandler(this.btnReroll4_Click);
            // 
            // lblStrengthMod
            // 
            this.lblStrengthMod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrengthMod.Location = new System.Drawing.Point(168, 35);
            this.lblStrengthMod.Name = "lblStrengthMod";
            this.lblStrengthMod.Size = new System.Drawing.Size(40, 24);
            this.lblStrengthMod.TabIndex = 26;
            // 
            // lblCharismaMod
            // 
            this.lblCharismaMod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharismaMod.Location = new System.Drawing.Point(168, 200);
            this.lblCharismaMod.Name = "lblCharismaMod";
            this.lblCharismaMod.Size = new System.Drawing.Size(40, 24);
            this.lblCharismaMod.TabIndex = 31;
            // 
            // lblDexterityMod
            // 
            this.lblDexterityMod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDexterityMod.Location = new System.Drawing.Point(168, 167);
            this.lblDexterityMod.Name = "lblDexterityMod";
            this.lblDexterityMod.Size = new System.Drawing.Size(40, 24);
            this.lblDexterityMod.TabIndex = 30;
            // 
            // lblConstitutionMod
            // 
            this.lblConstitutionMod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConstitutionMod.Location = new System.Drawing.Point(168, 134);
            this.lblConstitutionMod.Name = "lblConstitutionMod";
            this.lblConstitutionMod.Size = new System.Drawing.Size(40, 24);
            this.lblConstitutionMod.TabIndex = 29;
            // 
            // lblWisdomMod
            // 
            this.lblWisdomMod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWisdomMod.Location = new System.Drawing.Point(168, 101);
            this.lblWisdomMod.Name = "lblWisdomMod";
            this.lblWisdomMod.Size = new System.Drawing.Size(40, 24);
            this.lblWisdomMod.TabIndex = 28;
            // 
            // lblIntelligenceMod
            // 
            this.lblIntelligenceMod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntelligenceMod.Location = new System.Drawing.Point(168, 68);
            this.lblIntelligenceMod.Name = "lblIntelligenceMod";
            this.lblIntelligenceMod.Size = new System.Drawing.Size(40, 24);
            this.lblIntelligenceMod.TabIndex = 27;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(112, 8);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(48, 24);
            this.lblScore.TabIndex = 32;
            this.lblScore.Text = "Score";
            // 
            // lblMod
            // 
            this.lblMod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMod.Location = new System.Drawing.Point(168, 8);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(48, 24);
            this.lblMod.TabIndex = 33;
            this.lblMod.Text = "Mod";
            // 
            // cmbAbility1
            // 
            this.cmbAbility1.Enabled = false;
            this.cmbAbility1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAbility1.FormattingEnabled = true;
            this.cmbAbility1.Location = new System.Drawing.Point(704, 32);
            this.cmbAbility1.Name = "cmbAbility1";
            this.cmbAbility1.Size = new System.Drawing.Size(128, 25);
            this.cmbAbility1.TabIndex = 34;
            this.cmbAbility1.SelectedIndexChanged += new System.EventHandler(this.cmbAbility1_SelectedIndexChanged);
            // 
            // txtAbility1
            // 
            this.txtAbility1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility1.Location = new System.Drawing.Point(648, 32);
            this.txtAbility1.Name = "txtAbility1";
            this.txtAbility1.ReadOnly = true;
            this.txtAbility1.Size = new System.Drawing.Size(40, 25);
            this.txtAbility1.TabIndex = 35;
            // 
            // txtAbility2
            // 
            this.txtAbility2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility2.Location = new System.Drawing.Point(648, 64);
            this.txtAbility2.Name = "txtAbility2";
            this.txtAbility2.ReadOnly = true;
            this.txtAbility2.Size = new System.Drawing.Size(40, 25);
            this.txtAbility2.TabIndex = 37;
            // 
            // cmbAbility2
            // 
            this.cmbAbility2.Enabled = false;
            this.cmbAbility2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAbility2.FormattingEnabled = true;
            this.cmbAbility2.Location = new System.Drawing.Point(704, 64);
            this.cmbAbility2.Name = "cmbAbility2";
            this.cmbAbility2.Size = new System.Drawing.Size(128, 25);
            this.cmbAbility2.TabIndex = 36;
            this.cmbAbility2.SelectedIndexChanged += new System.EventHandler(this.cmbAbility2_SelectedIndexChanged);
            // 
            // txtAbility3
            // 
            this.txtAbility3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility3.Location = new System.Drawing.Point(648, 96);
            this.txtAbility3.Name = "txtAbility3";
            this.txtAbility3.ReadOnly = true;
            this.txtAbility3.Size = new System.Drawing.Size(40, 25);
            this.txtAbility3.TabIndex = 39;
            // 
            // cmbAbility3
            // 
            this.cmbAbility3.Enabled = false;
            this.cmbAbility3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAbility3.FormattingEnabled = true;
            this.cmbAbility3.Location = new System.Drawing.Point(704, 96);
            this.cmbAbility3.Name = "cmbAbility3";
            this.cmbAbility3.Size = new System.Drawing.Size(128, 25);
            this.cmbAbility3.TabIndex = 38;
            this.cmbAbility3.SelectedIndexChanged += new System.EventHandler(this.cmbAbility3_SelectedIndexChanged);
            // 
            // txtAbility4
            // 
            this.txtAbility4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility4.Location = new System.Drawing.Point(648, 128);
            this.txtAbility4.Name = "txtAbility4";
            this.txtAbility4.ReadOnly = true;
            this.txtAbility4.Size = new System.Drawing.Size(40, 25);
            this.txtAbility4.TabIndex = 41;
            // 
            // cmbAbility4
            // 
            this.cmbAbility4.Enabled = false;
            this.cmbAbility4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAbility4.FormattingEnabled = true;
            this.cmbAbility4.Location = new System.Drawing.Point(704, 128);
            this.cmbAbility4.Name = "cmbAbility4";
            this.cmbAbility4.Size = new System.Drawing.Size(128, 25);
            this.cmbAbility4.TabIndex = 40;
            this.cmbAbility4.SelectedIndexChanged += new System.EventHandler(this.cmbAbility4_SelectedIndexChanged);
            // 
            // txtAbility5
            // 
            this.txtAbility5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility5.Location = new System.Drawing.Point(648, 160);
            this.txtAbility5.Name = "txtAbility5";
            this.txtAbility5.ReadOnly = true;
            this.txtAbility5.Size = new System.Drawing.Size(40, 25);
            this.txtAbility5.TabIndex = 43;
            // 
            // cmbAbility5
            // 
            this.cmbAbility5.Enabled = false;
            this.cmbAbility5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAbility5.FormattingEnabled = true;
            this.cmbAbility5.Location = new System.Drawing.Point(704, 160);
            this.cmbAbility5.Name = "cmbAbility5";
            this.cmbAbility5.Size = new System.Drawing.Size(128, 25);
            this.cmbAbility5.TabIndex = 42;
            this.cmbAbility5.SelectedIndexChanged += new System.EventHandler(this.cmbAbility5_SelectedIndexChanged);
            // 
            // txtAbility6
            // 
            this.txtAbility6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility6.Location = new System.Drawing.Point(648, 192);
            this.txtAbility6.Name = "txtAbility6";
            this.txtAbility6.ReadOnly = true;
            this.txtAbility6.Size = new System.Drawing.Size(40, 25);
            this.txtAbility6.TabIndex = 45;
            // 
            // cmbAbility6
            // 
            this.cmbAbility6.Enabled = false;
            this.cmbAbility6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAbility6.FormattingEnabled = true;
            this.cmbAbility6.Location = new System.Drawing.Point(704, 192);
            this.cmbAbility6.Name = "cmbAbility6";
            this.cmbAbility6.Size = new System.Drawing.Size(128, 25);
            this.cmbAbility6.TabIndex = 44;
            // 
            // btnSaveNReset
            // 
            this.btnSaveNReset.Enabled = false;
            this.btnSaveNReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNReset.Location = new System.Drawing.Point(568, 88);
            this.btnSaveNReset.Name = "btnSaveNReset";
            this.btnSaveNReset.Size = new System.Drawing.Size(72, 48);
            this.btnSaveNReset.TabIndex = 46;
            this.btnSaveNReset.Text = "Save Score";
            this.btnSaveNReset.UseVisualStyleBackColor = true;
            this.btnSaveNReset.Click += new System.EventHandler(this.btnSaveNReset_Click);
            // 
            // btnViewStats
            // 
            this.btnViewStats.Enabled = false;
            this.btnViewStats.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStats.Location = new System.Drawing.Point(848, 56);
            this.btnViewStats.Name = "btnViewStats";
            this.btnViewStats.Size = new System.Drawing.Size(88, 24);
            this.btnViewStats.TabIndex = 47;
            this.btnViewStats.Text = "View Stats";
            this.btnViewStats.UseVisualStyleBackColor = true;
            this.btnViewStats.Click += new System.EventHandler(this.btnViewStats_Click);
            // 
            // btnCommitStats
            // 
            this.btnCommitStats.Enabled = false;
            this.btnCommitStats.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommitStats.Location = new System.Drawing.Point(848, 112);
            this.btnCommitStats.Name = "btnCommitStats";
            this.btnCommitStats.Size = new System.Drawing.Size(88, 24);
            this.btnCommitStats.TabIndex = 48;
            this.btnCommitStats.Text = "Save Stats";
            this.btnCommitStats.UseVisualStyleBackColor = true;
            this.btnCommitStats.Click += new System.EventHandler(this.btnCommitStats_Click);
            // 
            // btnGenerateValue1
            // 
            this.btnGenerateValue1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue1.Location = new System.Drawing.Point(256, 40);
            this.btnGenerateValue1.Name = "btnGenerateValue1";
            this.btnGenerateValue1.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue1.TabIndex = 49;
            this.btnGenerateValue1.Text = "Roll 1";
            this.btnGenerateValue1.UseVisualStyleBackColor = true;
            this.btnGenerateValue1.Visible = false;
            this.btnGenerateValue1.Click += new System.EventHandler(this.btnGenerateValue1_Click);
            // 
            // btnGenerateValue2
            // 
            this.btnGenerateValue2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue2.Location = new System.Drawing.Point(256, 72);
            this.btnGenerateValue2.Name = "btnGenerateValue2";
            this.btnGenerateValue2.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue2.TabIndex = 50;
            this.btnGenerateValue2.Text = "Roll 2";
            this.btnGenerateValue2.UseVisualStyleBackColor = true;
            this.btnGenerateValue2.Visible = false;
            this.btnGenerateValue2.Click += new System.EventHandler(this.btnGenerateValue2_Click);
            // 
            // btnGenerateValue3
            // 
            this.btnGenerateValue3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue3.Location = new System.Drawing.Point(256, 104);
            this.btnGenerateValue3.Name = "btnGenerateValue3";
            this.btnGenerateValue3.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue3.TabIndex = 51;
            this.btnGenerateValue3.Text = "Roll 3";
            this.btnGenerateValue3.UseVisualStyleBackColor = true;
            this.btnGenerateValue3.Visible = false;
            this.btnGenerateValue3.Click += new System.EventHandler(this.btnGenerateValue3_Click);
            // 
            // btnGenerateValue4
            // 
            this.btnGenerateValue4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue4.Location = new System.Drawing.Point(256, 136);
            this.btnGenerateValue4.Name = "btnGenerateValue4";
            this.btnGenerateValue4.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue4.TabIndex = 52;
            this.btnGenerateValue4.Text = "Roll 4";
            this.btnGenerateValue4.UseVisualStyleBackColor = true;
            this.btnGenerateValue4.Visible = false;
            this.btnGenerateValue4.Click += new System.EventHandler(this.btnGenerateValue4_Click);
            // 
            // tmrDieDelay
            // 
            this.tmrDieDelay.Tick += new System.EventHandler(this.tmrDieDelay_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableRerollOfOne1ToolStripMenuItem,
            this.resetCharacterToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.formToolStripMenuItem.Text = "&Form";
            // 
            // enableRerollOfOne1ToolStripMenuItem
            // 
            this.enableRerollOfOne1ToolStripMenuItem.Name = "enableRerollOfOne1ToolStripMenuItem";
            this.enableRerollOfOne1ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.enableRerollOfOne1ToolStripMenuItem.Text = "Enable Reroll of one 1";
            this.enableRerollOfOne1ToolStripMenuItem.Click += new System.EventHandler(this.enableRerollOfOne1ToolStripMenuItem_Click);
            // 
            // resetCharacterToolStripMenuItem
            // 
            this.resetCharacterToolStripMenuItem.Name = "resetCharacterToolStripMenuItem";
            this.resetCharacterToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.resetCharacterToolStripMenuItem.Text = "Reset Character";
            this.resetCharacterToolStripMenuItem.Click += new System.EventHandler(this.resetCharacterToolStripMenuItem_Click);
            // 
            // frmCharacterGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 229);
            this.Controls.Add(this.btnGenerateValue4);
            this.Controls.Add(this.btnGenerateValue3);
            this.Controls.Add(this.btnGenerateValue2);
            this.Controls.Add(this.btnGenerateValue1);
            this.Controls.Add(this.btnCommitStats);
            this.Controls.Add(this.btnViewStats);
            this.Controls.Add(this.btnSaveNReset);
            this.Controls.Add(this.txtAbility6);
            this.Controls.Add(this.cmbAbility6);
            this.Controls.Add(this.txtAbility5);
            this.Controls.Add(this.cmbAbility5);
            this.Controls.Add(this.txtAbility4);
            this.Controls.Add(this.cmbAbility4);
            this.Controls.Add(this.txtAbility3);
            this.Controls.Add(this.cmbAbility3);
            this.Controls.Add(this.txtAbility2);
            this.Controls.Add(this.cmbAbility2);
            this.Controls.Add(this.txtAbility1);
            this.Controls.Add(this.cmbAbility1);
            this.Controls.Add(this.lblMod);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblCharismaMod);
            this.Controls.Add(this.lblDexterityMod);
            this.Controls.Add(this.lblConstitutionMod);
            this.Controls.Add(this.lblWisdomMod);
            this.Controls.Add(this.lblIntelligenceMod);
            this.Controls.Add(this.lblStrengthMod);
            this.Controls.Add(this.btnReroll4);
            this.Controls.Add(this.btnReroll3);
            this.Controls.Add(this.btnReroll2);
            this.Controls.Add(this.btnReroll1);
            this.Controls.Add(this.txtTotalValue);
            this.Controls.Add(this.btnGenerateValues);
            this.Controls.Add(this.txtValue4);
            this.Controls.Add(this.txtValue3);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.txtValue1);
            this.Controls.Add(this.lblValue1);
            this.Controls.Add(this.lblValue2);
            this.Controls.Add(this.lblValue3);
            this.Controls.Add(this.lblValue4);
            this.Controls.Add(this.lblCharismaValue);
            this.Controls.Add(this.lblCharisma);
            this.Controls.Add(this.lblDexterityValue);
            this.Controls.Add(this.lblDexterity);
            this.Controls.Add(this.lblConstitutionValue);
            this.Controls.Add(this.lblConstitution);
            this.Controls.Add(this.lblWisdomValue);
            this.Controls.Add(this.lblWisdom);
            this.Controls.Add(this.lblIntelligenceValue);
            this.Controls.Add(this.lblIntelligence);
            this.Controls.Add(this.lblStrengthValue);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCharacterGenerator";
            this.Text = "Character Generator";
            this.Load += new System.EventHandler(this.frmCharacterGenerator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblStrengthValue;
        private System.Windows.Forms.Label lblIntelligenceValue;
        private System.Windows.Forms.Label lblIntelligence;
        private System.Windows.Forms.Label lblWisdomValue;
        private System.Windows.Forms.Label lblWisdom;
        private System.Windows.Forms.Label lblConstitutionValue;
        private System.Windows.Forms.Label lblConstitution;
        private System.Windows.Forms.Label lblDexterityValue;
        private System.Windows.Forms.Label lblDexterity;
        private System.Windows.Forms.Label lblCharismaValue;
        private System.Windows.Forms.Label lblCharisma;
        private System.Windows.Forms.Label lblValue4;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.TextBox txtValue1;
        private System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.TextBox txtValue3;
        private System.Windows.Forms.TextBox txtValue4;
        private System.Windows.Forms.Button btnGenerateValues;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Button btnReroll1;
        private System.Windows.Forms.Button btnReroll2;
        private System.Windows.Forms.Button btnReroll3;
        private System.Windows.Forms.Button btnReroll4;
        private System.Windows.Forms.Label lblStrengthMod;
        private System.Windows.Forms.Label lblCharismaMod;
        private System.Windows.Forms.Label lblDexterityMod;
        private System.Windows.Forms.Label lblConstitutionMod;
        private System.Windows.Forms.Label lblWisdomMod;
        private System.Windows.Forms.Label lblIntelligenceMod;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.ComboBox cmbAbility1;
        private System.Windows.Forms.TextBox txtAbility1;
        private System.Windows.Forms.TextBox txtAbility2;
        private System.Windows.Forms.ComboBox cmbAbility2;
        private System.Windows.Forms.TextBox txtAbility3;
        private System.Windows.Forms.ComboBox cmbAbility3;
        private System.Windows.Forms.TextBox txtAbility4;
        private System.Windows.Forms.ComboBox cmbAbility4;
        private System.Windows.Forms.TextBox txtAbility5;
        private System.Windows.Forms.ComboBox cmbAbility5;
        private System.Windows.Forms.TextBox txtAbility6;
        private System.Windows.Forms.ComboBox cmbAbility6;
        private System.Windows.Forms.Button btnSaveNReset;
        private System.Windows.Forms.Button btnViewStats;
        private System.Windows.Forms.Button btnCommitStats;
        private System.Windows.Forms.Button btnGenerateValue1;
        private System.Windows.Forms.Button btnGenerateValue2;
        private System.Windows.Forms.Button btnGenerateValue3;
        private System.Windows.Forms.Button btnGenerateValue4;
        private System.Windows.Forms.Timer tmrDieDelay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableRerollOfOne1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCharacterToolStripMenuItem;
    }
}

