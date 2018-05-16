namespace StarWarsRPG
{
    partial class frmSkill
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFeatID = new System.Windows.Forms.TextBox();
            this.lblSkillID = new System.Windows.Forms.Label();
            this.lblSkillDescription = new System.Windows.Forms.Label();
            this.txtSkillDescription = new System.Windows.Forms.TextBox();
            this.lblSkillName = new System.Windows.Forms.Label();
            this.txtSkillName = new System.Windows.Forms.TextBox();
            this.lvSubSkills = new System.Windows.Forms.ListView();
            this.btnAddSubSkill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.Location = new System.Drawing.Point(376, 56);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 32);
            this.btnEdit.TabIndex = 41;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(376, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 32);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNew.Location = new System.Drawing.Point(376, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 32);
            this.btnNew.TabIndex = 39;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.Location = new System.Drawing.Point(184, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 32);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFeatID
            // 
            this.txtFeatID.Location = new System.Drawing.Point(128, 8);
            this.txtFeatID.MaxLength = 100;
            this.txtFeatID.Name = "txtFeatID";
            this.txtFeatID.ReadOnly = true;
            this.txtFeatID.Size = new System.Drawing.Size(32, 20);
            this.txtFeatID.TabIndex = 37;
            // 
            // lblSkillID
            // 
            this.lblSkillID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSkillID.Location = new System.Drawing.Point(8, 8);
            this.lblSkillID.Name = "lblSkillID";
            this.lblSkillID.Size = new System.Drawing.Size(112, 24);
            this.lblSkillID.TabIndex = 36;
            this.lblSkillID.Text = "Skill ID:";
            this.lblSkillID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSkillDescription
            // 
            this.lblSkillDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSkillDescription.Location = new System.Drawing.Point(8, 80);
            this.lblSkillDescription.Name = "lblSkillDescription";
            this.lblSkillDescription.Size = new System.Drawing.Size(96, 40);
            this.lblSkillDescription.TabIndex = 35;
            this.lblSkillDescription.Text = "Skill Description:";
            this.lblSkillDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSkillDescription
            // 
            this.txtSkillDescription.Location = new System.Drawing.Point(112, 72);
            this.txtSkillDescription.MaxLength = 1000;
            this.txtSkillDescription.Multiline = true;
            this.txtSkillDescription.Name = "txtSkillDescription";
            this.txtSkillDescription.Size = new System.Drawing.Size(256, 88);
            this.txtSkillDescription.TabIndex = 34;
            this.txtSkillDescription.TextChanged += new System.EventHandler(this.txtSkillDescription_TextChanged);
            // 
            // lblSkillName
            // 
            this.lblSkillName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSkillName.Location = new System.Drawing.Point(8, 48);
            this.lblSkillName.Name = "lblSkillName";
            this.lblSkillName.Size = new System.Drawing.Size(96, 24);
            this.lblSkillName.TabIndex = 33;
            this.lblSkillName.Text = "Skill Name:";
            this.lblSkillName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSkillName
            // 
            this.txtSkillName.Location = new System.Drawing.Point(112, 48);
            this.txtSkillName.MaxLength = 100;
            this.txtSkillName.Name = "txtSkillName";
            this.txtSkillName.Size = new System.Drawing.Size(152, 20);
            this.txtSkillName.TabIndex = 32;
            this.txtSkillName.TextChanged += new System.EventHandler(this.txtSkillName_TextChanged);
            // 
            // lvSubSkills
            // 
            this.lvSubSkills.Location = new System.Drawing.Point(8, 168);
            this.lvSubSkills.Name = "lvSubSkills";
            this.lvSubSkills.Size = new System.Drawing.Size(536, 80);
            this.lvSubSkills.TabIndex = 43;
            this.lvSubSkills.UseCompatibleStateImageBehavior = false;
            this.lvSubSkills.View = System.Windows.Forms.View.Details;
            // 
            // btnAddSubSkill
            // 
            this.btnAddSubSkill.Enabled = false;
            this.btnAddSubSkill.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddSubSkill.Location = new System.Drawing.Point(480, 88);
            this.btnAddSubSkill.Name = "btnAddSubSkill";
            this.btnAddSubSkill.Size = new System.Drawing.Size(64, 72);
            this.btnAddSubSkill.TabIndex = 44;
            this.btnAddSubSkill.Text = "&Add Sub Skill";
            this.btnAddSubSkill.UseVisualStyleBackColor = true;
            this.btnAddSubSkill.Click += new System.EventHandler(this.btnAddSubSkill_Click);
            // 
            // frmSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 258);
            this.Controls.Add(this.btnAddSubSkill);
            this.Controls.Add(this.lvSubSkills);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFeatID);
            this.Controls.Add(this.lblSkillID);
            this.Controls.Add(this.lblSkillDescription);
            this.Controls.Add(this.txtSkillDescription);
            this.Controls.Add(this.lblSkillName);
            this.Controls.Add(this.txtSkillName);
            this.Name = "frmSkill";
            this.Text = "Skill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFeatID;
        private System.Windows.Forms.Label lblSkillID;
        private System.Windows.Forms.Label lblSkillDescription;
        private System.Windows.Forms.TextBox txtSkillDescription;
        private System.Windows.Forms.Label lblSkillName;
        private System.Windows.Forms.TextBox txtSkillName;
        private System.Windows.Forms.ListView lvSubSkills;
        private System.Windows.Forms.Button btnAddSubSkill;
    }
}