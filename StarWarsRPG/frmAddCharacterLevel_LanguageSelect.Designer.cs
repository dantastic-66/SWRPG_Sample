namespace StarWarsRPG
{
    partial class frmAddCharacterLevel_LanguageSelect
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
            this.gpForcePowers = new System.Windows.Forms.GroupBox();
            this.btnSelectLanguages = new System.Windows.Forms.Button();
            this.lblLanguageCount = new System.Windows.Forms.Label();
            this.btnRemoveAllLanguages = new System.Windows.Forms.Button();
            this.btnRemoveLanguage = new System.Windows.Forms.Button();
            this.btnAddLanguage = new System.Windows.Forms.Button();
            this.tvSelectedLanguages = new System.Windows.Forms.TreeView();
            this.tvLanguageList = new System.Windows.Forms.TreeView();
            this.lblCurrentLanguages = new System.Windows.Forms.Label();
            this.txtCurrentCharacterLanguages = new System.Windows.Forms.TextBox();
            this.gpForcePowers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpForcePowers
            // 
            this.gpForcePowers.Controls.Add(this.txtCurrentCharacterLanguages);
            this.gpForcePowers.Controls.Add(this.lblCurrentLanguages);
            this.gpForcePowers.Controls.Add(this.btnSelectLanguages);
            this.gpForcePowers.Controls.Add(this.lblLanguageCount);
            this.gpForcePowers.Controls.Add(this.btnRemoveAllLanguages);
            this.gpForcePowers.Controls.Add(this.btnRemoveLanguage);
            this.gpForcePowers.Controls.Add(this.btnAddLanguage);
            this.gpForcePowers.Controls.Add(this.tvSelectedLanguages);
            this.gpForcePowers.Controls.Add(this.tvLanguageList);
            this.gpForcePowers.Location = new System.Drawing.Point(12, 8);
            this.gpForcePowers.Name = "gpForcePowers";
            this.gpForcePowers.Size = new System.Drawing.Size(428, 520);
            this.gpForcePowers.TabIndex = 1;
            this.gpForcePowers.TabStop = false;
            this.gpForcePowers.Text = "Select Languages";
            // 
            // btnSelectLanguages
            // 
            this.btnSelectLanguages.Enabled = false;
            this.btnSelectLanguages.Location = new System.Drawing.Point(284, 40);
            this.btnSelectLanguages.Name = "btnSelectLanguages";
            this.btnSelectLanguages.Size = new System.Drawing.Size(100, 36);
            this.btnSelectLanguages.TabIndex = 21;
            this.btnSelectLanguages.Text = "Accept Selected Language(s)";
            this.btnSelectLanguages.UseVisualStyleBackColor = true;
            this.btnSelectLanguages.Click += new System.EventHandler(this.btnSelectLanguage_Click);
            // 
            // lblLanguageCount
            // 
            this.lblLanguageCount.Location = new System.Drawing.Point(244, 136);
            this.lblLanguageCount.Name = "lblLanguageCount";
            this.lblLanguageCount.Size = new System.Drawing.Size(100, 28);
            this.lblLanguageCount.TabIndex = 5;
            this.lblLanguageCount.Text = "Available Languages:";
            this.lblLanguageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRemoveAllLanguages
            // 
            this.btnRemoveAllLanguages.Enabled = false;
            this.btnRemoveAllLanguages.Location = new System.Drawing.Point(196, 280);
            this.btnRemoveAllLanguages.Name = "btnRemoveAllLanguages";
            this.btnRemoveAllLanguages.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveAllLanguages.TabIndex = 4;
            this.btnRemoveAllLanguages.Text = "<<";
            this.btnRemoveAllLanguages.UseVisualStyleBackColor = true;
            this.btnRemoveAllLanguages.Click += new System.EventHandler(this.btnRemoveAllLang_Click);
            // 
            // btnRemoveLanguage
            // 
            this.btnRemoveLanguage.Enabled = false;
            this.btnRemoveLanguage.Location = new System.Drawing.Point(196, 252);
            this.btnRemoveLanguage.Name = "btnRemoveLanguage";
            this.btnRemoveLanguage.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveLanguage.TabIndex = 3;
            this.btnRemoveLanguage.Text = "<";
            this.btnRemoveLanguage.UseVisualStyleBackColor = true;
            this.btnRemoveLanguage.Click += new System.EventHandler(this.btnRemoveLang_Click);
            // 
            // btnAddLanguage
            // 
            this.btnAddLanguage.Enabled = false;
            this.btnAddLanguage.Location = new System.Drawing.Point(196, 224);
            this.btnAddLanguage.Name = "btnAddLanguage";
            this.btnAddLanguage.Size = new System.Drawing.Size(36, 24);
            this.btnAddLanguage.TabIndex = 2;
            this.btnAddLanguage.Text = ">";
            this.btnAddLanguage.UseVisualStyleBackColor = true;
            this.btnAddLanguage.Click += new System.EventHandler(this.btnAddLang_Click);
            // 
            // tvSelectedLanguages
            // 
            this.tvSelectedLanguages.Location = new System.Drawing.Point(240, 168);
            this.tvSelectedLanguages.Name = "tvSelectedLanguages";
            this.tvSelectedLanguages.Size = new System.Drawing.Size(180, 224);
            this.tvSelectedLanguages.TabIndex = 1;
            this.tvSelectedLanguages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSelectedLanguages_AfterSelect);
            // 
            // tvLanguageList
            // 
            this.tvLanguageList.Location = new System.Drawing.Point(8, 24);
            this.tvLanguageList.Name = "tvLanguageList";
            this.tvLanguageList.Size = new System.Drawing.Size(180, 492);
            this.tvLanguageList.TabIndex = 0;
            this.tvLanguageList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLanguageList_AfterSelect);
            // 
            // lblCurrentLanguages
            // 
            this.lblCurrentLanguages.AutoSize = true;
            this.lblCurrentLanguages.Location = new System.Drawing.Point(220, 412);
            this.lblCurrentLanguages.Name = "lblCurrentLanguages";
            this.lblCurrentLanguages.Size = new System.Drawing.Size(160, 13);
            this.lblCurrentLanguages.TabIndex = 22;
            this.lblCurrentLanguages.Text = "Current Character Languages:";
            // 
            // txtCurrentCharacterLanguages
            // 
            this.txtCurrentCharacterLanguages.Location = new System.Drawing.Point(216, 432);
            this.txtCurrentCharacterLanguages.Multiline = true;
            this.txtCurrentCharacterLanguages.Name = "txtCurrentCharacterLanguages";
            this.txtCurrentCharacterLanguages.ReadOnly = true;
            this.txtCurrentCharacterLanguages.Size = new System.Drawing.Size(208, 68);
            this.txtCurrentCharacterLanguages.TabIndex = 23;
            // 
            // frmAddCharacterLevel_LanguageSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(444, 532);
            this.Controls.Add(this.gpForcePowers);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCharacterLevel_LanguageSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Languages";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddCharacterLevel_LanguageSelect_FormClosed);
            this.gpForcePowers.ResumeLayout(false);
            this.gpForcePowers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpForcePowers;
        private System.Windows.Forms.TreeView tvLanguageList;
        private System.Windows.Forms.Button btnSelectLanguages;
        private System.Windows.Forms.Label lblLanguageCount;
        private System.Windows.Forms.Button btnRemoveAllLanguages;
        private System.Windows.Forms.Button btnRemoveLanguage;
        private System.Windows.Forms.Button btnAddLanguage;
        private System.Windows.Forms.TreeView tvSelectedLanguages;
        private System.Windows.Forms.TextBox txtCurrentCharacterLanguages;
        private System.Windows.Forms.Label lblCurrentLanguages;
    }
}