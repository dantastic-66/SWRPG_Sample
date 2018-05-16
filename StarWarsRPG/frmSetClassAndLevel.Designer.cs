namespace StarWarsRPG
{
    partial class frmSetClassAndLevel
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
            this.clbClasses = new System.Windows.Forms.CheckedListBox();
            this.lblClass1 = new System.Windows.Forms.Label();
            this.txtClass1 = new System.Windows.Forms.TextBox();
            this.txtClassLevel1 = new System.Windows.Forms.TextBox();
            this.lblClass2 = new System.Windows.Forms.Label();
            this.txtClass2 = new System.Windows.Forms.TextBox();
            this.txtClassLevel2 = new System.Windows.Forms.TextBox();
            this.lblClass3 = new System.Windows.Forms.Label();
            this.txtClass3 = new System.Windows.Forms.TextBox();
            this.txtClassLevel3 = new System.Windows.Forms.TextBox();
            this.lblClass4 = new System.Windows.Forms.Label();
            this.txtClass4 = new System.Windows.Forms.TextBox();
            this.txtClassLevel4 = new System.Windows.Forms.TextBox();
            this.lblClass5 = new System.Windows.Forms.Label();
            this.txtClass5 = new System.Windows.Forms.TextBox();
            this.txtClassLevel5 = new System.Windows.Forms.TextBox();
            this.lblClass6 = new System.Windows.Forms.Label();
            this.txtClass6 = new System.Windows.Forms.TextBox();
            this.txtClassLevel6 = new System.Windows.Forms.TextBox();
            this.lblClass7 = new System.Windows.Forms.Label();
            this.txtClass7 = new System.Windows.Forms.TextBox();
            this.txtClassLevel7 = new System.Windows.Forms.TextBox();
            this.lblClass8 = new System.Windows.Forms.Label();
            this.txtClass8 = new System.Windows.Forms.TextBox();
            this.txtClassLevel8 = new System.Windows.Forms.TextBox();
            this.lblClass9 = new System.Windows.Forms.Label();
            this.txtClass9 = new System.Windows.Forms.TextBox();
            this.txtClassLevel9 = new System.Windows.Forms.TextBox();
            this.grpClassLevel = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearChecked = new System.Windows.Forms.Button();
            this.cmbPrestigeClasses = new System.Windows.Forms.ComboBox();
            this.grpPrestigeReq = new System.Windows.Forms.GroupBox();
            this.lvFeatTalentSkill = new System.Windows.Forms.ListView();
            this.tbcPrestigeRequirements = new System.Windows.Forms.TabControl();
            this.tabpDescription = new System.Windows.Forms.TabPage();
            this.tabpFeats = new System.Windows.Forms.TabPage();
            this.tabpSkills = new System.Windows.Forms.TabPage();
            this.tabpTalents = new System.Windows.Forms.TabPage();
            this.txtPrestigeRequirements = new System.Windows.Forms.TextBox();
            this.grpClassLevel.SuspendLayout();
            this.grpPrestigeReq.SuspendLayout();
            this.tbcPrestigeRequirements.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbClasses
            // 
            this.clbClasses.CheckOnClick = true;
            this.clbClasses.FormattingEnabled = true;
            this.clbClasses.Location = new System.Drawing.Point(16, 16);
            this.clbClasses.MultiColumn = true;
            this.clbClasses.Name = "clbClasses";
            this.clbClasses.Size = new System.Drawing.Size(176, 274);
            this.clbClasses.TabIndex = 0;
            this.clbClasses.ThreeDCheckBoxes = true;
            this.clbClasses.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbClasses_ItemCheck);
            // 
            // lblClass1
            // 
            this.lblClass1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass1.Location = new System.Drawing.Point(200, 24);
            this.lblClass1.Name = "lblClass1";
            this.lblClass1.Size = new System.Drawing.Size(40, 24);
            this.lblClass1.TabIndex = 17;
            this.lblClass1.Text = "Class";
            // 
            // txtClass1
            // 
            this.txtClass1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass1.Location = new System.Drawing.Point(248, 24);
            this.txtClass1.Name = "txtClass1";
            this.txtClass1.ReadOnly = true;
            this.txtClass1.Size = new System.Drawing.Size(80, 25);
            this.txtClass1.TabIndex = 18;
            // 
            // txtClassLevel1
            // 
            this.txtClassLevel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel1.Location = new System.Drawing.Point(336, 24);
            this.txtClassLevel1.Name = "txtClassLevel1";
            this.txtClassLevel1.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel1.TabIndex = 19;
            this.txtClassLevel1.TextChanged += new System.EventHandler(this.txtClassLevel1_TextChanged);
            this.txtClassLevel1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel1_KeyPress);
            // 
            // lblClass2
            // 
            this.lblClass2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass2.Location = new System.Drawing.Point(200, 54);
            this.lblClass2.Name = "lblClass2";
            this.lblClass2.Size = new System.Drawing.Size(40, 24);
            this.lblClass2.TabIndex = 20;
            this.lblClass2.Text = "Class";
            this.lblClass2.Visible = false;
            // 
            // txtClass2
            // 
            this.txtClass2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass2.Location = new System.Drawing.Point(248, 54);
            this.txtClass2.Name = "txtClass2";
            this.txtClass2.ReadOnly = true;
            this.txtClass2.Size = new System.Drawing.Size(80, 25);
            this.txtClass2.TabIndex = 21;
            this.txtClass2.Visible = false;
            // 
            // txtClassLevel2
            // 
            this.txtClassLevel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel2.Location = new System.Drawing.Point(336, 54);
            this.txtClassLevel2.Name = "txtClassLevel2";
            this.txtClassLevel2.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel2.TabIndex = 22;
            this.txtClassLevel2.Visible = false;
            this.txtClassLevel2.TextChanged += new System.EventHandler(this.txtClassLevel2_TextChanged);
            this.txtClassLevel2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel2_KeyPress);
            // 
            // lblClass3
            // 
            this.lblClass3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass3.Location = new System.Drawing.Point(200, 84);
            this.lblClass3.Name = "lblClass3";
            this.lblClass3.Size = new System.Drawing.Size(40, 24);
            this.lblClass3.TabIndex = 23;
            this.lblClass3.Text = "Class";
            this.lblClass3.Visible = false;
            // 
            // txtClass3
            // 
            this.txtClass3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass3.Location = new System.Drawing.Point(248, 84);
            this.txtClass3.Name = "txtClass3";
            this.txtClass3.ReadOnly = true;
            this.txtClass3.Size = new System.Drawing.Size(80, 25);
            this.txtClass3.TabIndex = 24;
            this.txtClass3.Visible = false;
            // 
            // txtClassLevel3
            // 
            this.txtClassLevel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel3.Location = new System.Drawing.Point(336, 84);
            this.txtClassLevel3.Name = "txtClassLevel3";
            this.txtClassLevel3.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel3.TabIndex = 25;
            this.txtClassLevel3.Visible = false;
            this.txtClassLevel3.TextChanged += new System.EventHandler(this.txtClassLevel3_TextChanged);
            this.txtClassLevel3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel3_KeyPress);
            // 
            // lblClass4
            // 
            this.lblClass4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass4.Location = new System.Drawing.Point(200, 114);
            this.lblClass4.Name = "lblClass4";
            this.lblClass4.Size = new System.Drawing.Size(40, 24);
            this.lblClass4.TabIndex = 26;
            this.lblClass4.Text = "Class";
            this.lblClass4.Visible = false;
            // 
            // txtClass4
            // 
            this.txtClass4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass4.Location = new System.Drawing.Point(248, 114);
            this.txtClass4.Name = "txtClass4";
            this.txtClass4.ReadOnly = true;
            this.txtClass4.Size = new System.Drawing.Size(80, 25);
            this.txtClass4.TabIndex = 27;
            this.txtClass4.Visible = false;
            // 
            // txtClassLevel4
            // 
            this.txtClassLevel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel4.Location = new System.Drawing.Point(336, 114);
            this.txtClassLevel4.Name = "txtClassLevel4";
            this.txtClassLevel4.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel4.TabIndex = 28;
            this.txtClassLevel4.Visible = false;
            this.txtClassLevel4.TextChanged += new System.EventHandler(this.txtClassLevel4_TextChanged);
            this.txtClassLevel4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel4_KeyPress);
            // 
            // lblClass5
            // 
            this.lblClass5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass5.Location = new System.Drawing.Point(200, 144);
            this.lblClass5.Name = "lblClass5";
            this.lblClass5.Size = new System.Drawing.Size(40, 24);
            this.lblClass5.TabIndex = 29;
            this.lblClass5.Text = "Class";
            this.lblClass5.Visible = false;
            // 
            // txtClass5
            // 
            this.txtClass5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass5.Location = new System.Drawing.Point(248, 144);
            this.txtClass5.Name = "txtClass5";
            this.txtClass5.ReadOnly = true;
            this.txtClass5.Size = new System.Drawing.Size(80, 25);
            this.txtClass5.TabIndex = 30;
            this.txtClass5.Visible = false;
            // 
            // txtClassLevel5
            // 
            this.txtClassLevel5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel5.Location = new System.Drawing.Point(336, 144);
            this.txtClassLevel5.Name = "txtClassLevel5";
            this.txtClassLevel5.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel5.TabIndex = 31;
            this.txtClassLevel5.Visible = false;
            this.txtClassLevel5.TextChanged += new System.EventHandler(this.txtClassLevel5_TextChanged);
            this.txtClassLevel5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel5_KeyPress);
            // 
            // lblClass6
            // 
            this.lblClass6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass6.Location = new System.Drawing.Point(200, 174);
            this.lblClass6.Name = "lblClass6";
            this.lblClass6.Size = new System.Drawing.Size(40, 24);
            this.lblClass6.TabIndex = 32;
            this.lblClass6.Text = "Class";
            this.lblClass6.Visible = false;
            // 
            // txtClass6
            // 
            this.txtClass6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass6.Location = new System.Drawing.Point(248, 174);
            this.txtClass6.Name = "txtClass6";
            this.txtClass6.ReadOnly = true;
            this.txtClass6.Size = new System.Drawing.Size(80, 25);
            this.txtClass6.TabIndex = 33;
            this.txtClass6.Visible = false;
            // 
            // txtClassLevel6
            // 
            this.txtClassLevel6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel6.Location = new System.Drawing.Point(336, 174);
            this.txtClassLevel6.Name = "txtClassLevel6";
            this.txtClassLevel6.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel6.TabIndex = 34;
            this.txtClassLevel6.Visible = false;
            this.txtClassLevel6.TextChanged += new System.EventHandler(this.txtClassLevel6_TextChanged);
            this.txtClassLevel6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel6_KeyPress);
            // 
            // lblClass7
            // 
            this.lblClass7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass7.Location = new System.Drawing.Point(200, 204);
            this.lblClass7.Name = "lblClass7";
            this.lblClass7.Size = new System.Drawing.Size(40, 24);
            this.lblClass7.TabIndex = 35;
            this.lblClass7.Text = "Class";
            this.lblClass7.Visible = false;
            // 
            // txtClass7
            // 
            this.txtClass7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass7.Location = new System.Drawing.Point(248, 204);
            this.txtClass7.Name = "txtClass7";
            this.txtClass7.ReadOnly = true;
            this.txtClass7.Size = new System.Drawing.Size(80, 25);
            this.txtClass7.TabIndex = 36;
            this.txtClass7.Visible = false;
            // 
            // txtClassLevel7
            // 
            this.txtClassLevel7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel7.Location = new System.Drawing.Point(336, 204);
            this.txtClassLevel7.Name = "txtClassLevel7";
            this.txtClassLevel7.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel7.TabIndex = 37;
            this.txtClassLevel7.Visible = false;
            this.txtClassLevel7.TextChanged += new System.EventHandler(this.txtClassLevel7_TextChanged);
            this.txtClassLevel7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel7_KeyPress);
            // 
            // lblClass8
            // 
            this.lblClass8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass8.Location = new System.Drawing.Point(200, 234);
            this.lblClass8.Name = "lblClass8";
            this.lblClass8.Size = new System.Drawing.Size(40, 24);
            this.lblClass8.TabIndex = 38;
            this.lblClass8.Text = "Class";
            this.lblClass8.Visible = false;
            // 
            // txtClass8
            // 
            this.txtClass8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass8.Location = new System.Drawing.Point(248, 234);
            this.txtClass8.Name = "txtClass8";
            this.txtClass8.ReadOnly = true;
            this.txtClass8.Size = new System.Drawing.Size(80, 25);
            this.txtClass8.TabIndex = 39;
            this.txtClass8.Visible = false;
            // 
            // txtClassLevel8
            // 
            this.txtClassLevel8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel8.Location = new System.Drawing.Point(336, 234);
            this.txtClassLevel8.Name = "txtClassLevel8";
            this.txtClassLevel8.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel8.TabIndex = 40;
            this.txtClassLevel8.Visible = false;
            this.txtClassLevel8.TextChanged += new System.EventHandler(this.txtClassLevel8_TextChanged);
            this.txtClassLevel8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel8_KeyPress);
            // 
            // lblClass9
            // 
            this.lblClass9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClass9.Location = new System.Drawing.Point(200, 264);
            this.lblClass9.Name = "lblClass9";
            this.lblClass9.Size = new System.Drawing.Size(40, 24);
            this.lblClass9.TabIndex = 41;
            this.lblClass9.Text = "Class";
            this.lblClass9.Visible = false;
            // 
            // txtClass9
            // 
            this.txtClass9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClass9.Location = new System.Drawing.Point(248, 264);
            this.txtClass9.Name = "txtClass9";
            this.txtClass9.ReadOnly = true;
            this.txtClass9.Size = new System.Drawing.Size(80, 25);
            this.txtClass9.TabIndex = 42;
            this.txtClass9.Visible = false;
            // 
            // txtClassLevel9
            // 
            this.txtClassLevel9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassLevel9.Location = new System.Drawing.Point(336, 264);
            this.txtClassLevel9.Name = "txtClassLevel9";
            this.txtClassLevel9.Size = new System.Drawing.Size(32, 25);
            this.txtClassLevel9.TabIndex = 43;
            this.txtClassLevel9.Visible = false;
            this.txtClassLevel9.TextChanged += new System.EventHandler(this.txtClassLevel9_TextChanged);
            this.txtClassLevel9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassLevel9_KeyPress);
            // 
            // grpClassLevel
            // 
            this.grpClassLevel.Controls.Add(this.clbClasses);
            this.grpClassLevel.Controls.Add(this.lblClass9);
            this.grpClassLevel.Controls.Add(this.txtClassLevel1);
            this.grpClassLevel.Controls.Add(this.txtClass9);
            this.grpClassLevel.Controls.Add(this.txtClass1);
            this.grpClassLevel.Controls.Add(this.txtClassLevel9);
            this.grpClassLevel.Controls.Add(this.lblClass1);
            this.grpClassLevel.Controls.Add(this.lblClass8);
            this.grpClassLevel.Controls.Add(this.txtClassLevel2);
            this.grpClassLevel.Controls.Add(this.txtClass8);
            this.grpClassLevel.Controls.Add(this.txtClass2);
            this.grpClassLevel.Controls.Add(this.txtClassLevel8);
            this.grpClassLevel.Controls.Add(this.lblClass2);
            this.grpClassLevel.Controls.Add(this.lblClass7);
            this.grpClassLevel.Controls.Add(this.txtClassLevel3);
            this.grpClassLevel.Controls.Add(this.txtClass7);
            this.grpClassLevel.Controls.Add(this.txtClass3);
            this.grpClassLevel.Controls.Add(this.txtClassLevel7);
            this.grpClassLevel.Controls.Add(this.lblClass3);
            this.grpClassLevel.Controls.Add(this.lblClass6);
            this.grpClassLevel.Controls.Add(this.txtClassLevel4);
            this.grpClassLevel.Controls.Add(this.txtClass6);
            this.grpClassLevel.Controls.Add(this.txtClass4);
            this.grpClassLevel.Controls.Add(this.txtClassLevel6);
            this.grpClassLevel.Controls.Add(this.lblClass4);
            this.grpClassLevel.Controls.Add(this.lblClass5);
            this.grpClassLevel.Controls.Add(this.txtClassLevel5);
            this.grpClassLevel.Controls.Add(this.txtClass5);
            this.grpClassLevel.Location = new System.Drawing.Point(8, 8);
            this.grpClassLevel.Name = "grpClassLevel";
            this.grpClassLevel.Size = new System.Drawing.Size(376, 296);
            this.grpClassLevel.TabIndex = 44;
            this.grpClassLevel.TabStop = false;
            this.grpClassLevel.Text = "Classes and Levels";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(400, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 32);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearChecked
            // 
            this.btnClearChecked.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClearChecked.Location = new System.Drawing.Point(400, 16);
            this.btnClearChecked.Name = "btnClearChecked";
            this.btnClearChecked.Size = new System.Drawing.Size(48, 32);
            this.btnClearChecked.TabIndex = 50;
            this.btnClearChecked.Text = "Clear";
            this.btnClearChecked.UseVisualStyleBackColor = true;
            this.btnClearChecked.Click += new System.EventHandler(this.btnClearChecked_Click);
            // 
            // cmbPrestigeClasses
            // 
            this.cmbPrestigeClasses.FormattingEnabled = true;
            this.cmbPrestigeClasses.Location = new System.Drawing.Point(8, 24);
            this.cmbPrestigeClasses.Name = "cmbPrestigeClasses";
            this.cmbPrestigeClasses.Size = new System.Drawing.Size(280, 25);
            this.cmbPrestigeClasses.TabIndex = 51;
            this.cmbPrestigeClasses.SelectedIndexChanged += new System.EventHandler(this.cmbPrestigeClasses_SelectedIndexChanged);
            // 
            // grpPrestigeReq
            // 
            this.grpPrestigeReq.Controls.Add(this.lvFeatTalentSkill);
            this.grpPrestigeReq.Controls.Add(this.tbcPrestigeRequirements);
            this.grpPrestigeReq.Controls.Add(this.txtPrestigeRequirements);
            this.grpPrestigeReq.Controls.Add(this.cmbPrestigeClasses);
            this.grpPrestigeReq.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpPrestigeReq.Location = new System.Drawing.Point(472, 16);
            this.grpPrestigeReq.Name = "grpPrestigeReq";
            this.grpPrestigeReq.Size = new System.Drawing.Size(296, 312);
            this.grpPrestigeReq.TabIndex = 52;
            this.grpPrestigeReq.TabStop = false;
            this.grpPrestigeReq.Text = "Prestige Requirements";
            // 
            // lvFeatTalentSkill
            // 
            this.lvFeatTalentSkill.Location = new System.Drawing.Point(8, 224);
            this.lvFeatTalentSkill.Name = "lvFeatTalentSkill";
            this.lvFeatTalentSkill.Size = new System.Drawing.Size(272, 80);
            this.lvFeatTalentSkill.TabIndex = 54;
            this.lvFeatTalentSkill.UseCompatibleStateImageBehavior = false;
            this.lvFeatTalentSkill.View = System.Windows.Forms.View.Details;
            // 
            // tbcPrestigeRequirements
            // 
            this.tbcPrestigeRequirements.Controls.Add(this.tabpDescription);
            this.tbcPrestigeRequirements.Controls.Add(this.tabpFeats);
            this.tbcPrestigeRequirements.Controls.Add(this.tabpSkills);
            this.tbcPrestigeRequirements.Controls.Add(this.tabpTalents);
            this.tbcPrestigeRequirements.Location = new System.Drawing.Point(8, 48);
            this.tbcPrestigeRequirements.Name = "tbcPrestigeRequirements";
            this.tbcPrestigeRequirements.SelectedIndex = 0;
            this.tbcPrestigeRequirements.Size = new System.Drawing.Size(280, 24);
            this.tbcPrestigeRequirements.TabIndex = 53;
            this.tbcPrestigeRequirements.Click += new System.EventHandler(this.tbcPrestigeRequirements_Click);
            // 
            // tabpDescription
            // 
            this.tabpDescription.Location = new System.Drawing.Point(4, 26);
            this.tabpDescription.Name = "tabpDescription";
            this.tabpDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabpDescription.Size = new System.Drawing.Size(272, 0);
            this.tabpDescription.TabIndex = 0;
            this.tabpDescription.Text = "Description";
            this.tabpDescription.UseVisualStyleBackColor = true;
            this.tabpDescription.Click += new System.EventHandler(this.tabpDescription_Click);
            // 
            // tabpFeats
            // 
            this.tabpFeats.Location = new System.Drawing.Point(4, 26);
            this.tabpFeats.Name = "tabpFeats";
            this.tabpFeats.Padding = new System.Windows.Forms.Padding(3);
            this.tabpFeats.Size = new System.Drawing.Size(272, 0);
            this.tabpFeats.TabIndex = 1;
            this.tabpFeats.Text = "Feats";
            this.tabpFeats.UseVisualStyleBackColor = true;
            // 
            // tabpSkills
            // 
            this.tabpSkills.Location = new System.Drawing.Point(4, 26);
            this.tabpSkills.Name = "tabpSkills";
            this.tabpSkills.Size = new System.Drawing.Size(272, 0);
            this.tabpSkills.TabIndex = 2;
            this.tabpSkills.Text = "Skills";
            this.tabpSkills.UseVisualStyleBackColor = true;
            // 
            // tabpTalents
            // 
            this.tabpTalents.Location = new System.Drawing.Point(4, 26);
            this.tabpTalents.Name = "tabpTalents";
            this.tabpTalents.Size = new System.Drawing.Size(272, 0);
            this.tabpTalents.TabIndex = 3;
            this.tabpTalents.Text = "Talents";
            this.tabpTalents.UseVisualStyleBackColor = true;
            // 
            // txtPrestigeRequirements
            // 
            this.txtPrestigeRequirements.Location = new System.Drawing.Point(8, 80);
            this.txtPrestigeRequirements.Multiline = true;
            this.txtPrestigeRequirements.Name = "txtPrestigeRequirements";
            this.txtPrestigeRequirements.Size = new System.Drawing.Size(280, 216);
            this.txtPrestigeRequirements.TabIndex = 52;
            // 
            // frmSetClassAndLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 334);
            this.Controls.Add(this.grpPrestigeReq);
            this.Controls.Add(this.btnClearChecked);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpClassLevel);
            this.Name = "frmSetClassAndLevel";
            this.Text = "Set Class And Level";
            this.grpClassLevel.ResumeLayout(false);
            this.grpClassLevel.PerformLayout();
            this.grpPrestigeReq.ResumeLayout(false);
            this.grpPrestigeReq.PerformLayout();
            this.tbcPrestigeRequirements.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbClasses;
        private System.Windows.Forms.Label lblClass1;
        private System.Windows.Forms.TextBox txtClass1;
        private System.Windows.Forms.TextBox txtClassLevel1;
        private System.Windows.Forms.Label lblClass2;
        private System.Windows.Forms.TextBox txtClass2;
        private System.Windows.Forms.TextBox txtClassLevel2;
        private System.Windows.Forms.Label lblClass3;
        private System.Windows.Forms.TextBox txtClass3;
        private System.Windows.Forms.TextBox txtClassLevel3;
        private System.Windows.Forms.Label lblClass4;
        private System.Windows.Forms.TextBox txtClass4;
        private System.Windows.Forms.TextBox txtClassLevel4;
        private System.Windows.Forms.Label lblClass5;
        private System.Windows.Forms.TextBox txtClass5;
        private System.Windows.Forms.TextBox txtClassLevel5;
        private System.Windows.Forms.Label lblClass6;
        private System.Windows.Forms.TextBox txtClass6;
        private System.Windows.Forms.TextBox txtClassLevel6;
        private System.Windows.Forms.Label lblClass7;
        private System.Windows.Forms.TextBox txtClass7;
        private System.Windows.Forms.TextBox txtClassLevel7;
        private System.Windows.Forms.Label lblClass8;
        private System.Windows.Forms.TextBox txtClass8;
        private System.Windows.Forms.TextBox txtClassLevel8;
        private System.Windows.Forms.Label lblClass9;
        private System.Windows.Forms.TextBox txtClass9;
        private System.Windows.Forms.TextBox txtClassLevel9;
        private System.Windows.Forms.GroupBox grpClassLevel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearChecked;
        private System.Windows.Forms.ComboBox cmbPrestigeClasses;
        private System.Windows.Forms.GroupBox grpPrestigeReq;
        private System.Windows.Forms.TextBox txtPrestigeRequirements;
        private System.Windows.Forms.TabControl tbcPrestigeRequirements;
        private System.Windows.Forms.TabPage tabpDescription;
        private System.Windows.Forms.TabPage tabpFeats;
        private System.Windows.Forms.TabPage tabpSkills;
        private System.Windows.Forms.TabPage tabpTalents;
        private System.Windows.Forms.ListView lvFeatTalentSkill;
    }
}