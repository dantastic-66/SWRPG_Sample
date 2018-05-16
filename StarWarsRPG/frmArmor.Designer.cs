namespace StarWarsRPG
{
    partial class frmArmor
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
            this.txtArmorName = new System.Windows.Forms.TextBox();
            this.lblArmorName = new System.Windows.Forms.Label();
            this.lblArmorDescription = new System.Windows.Forms.Label();
            this.txtArmorDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbArmorType = new System.Windows.Forms.ComboBox();
            this.lblReflexAdj = new System.Windows.Forms.Label();
            this.txtRefelxAdj = new System.Windows.Forms.TextBox();
            this.lblFortitudeAdj = new System.Windows.Forms.Label();
            this.txtFortitudeAdj = new System.Windows.Forms.TextBox();
            this.lblArmorID = new System.Windows.Forms.Label();
            this.txtArmorID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtArmorName
            // 
            this.txtArmorName.Location = new System.Drawing.Point(392, 8);
            this.txtArmorName.MaxLength = 100;
            this.txtArmorName.Name = "txtArmorName";
            this.txtArmorName.Size = new System.Drawing.Size(152, 20);
            this.txtArmorName.TabIndex = 0;
            this.txtArmorName.TextChanged += new System.EventHandler(this.txtArmorName_TextChanged);
            // 
            // lblArmorName
            // 
            this.lblArmorName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArmorName.Location = new System.Drawing.Point(288, 8);
            this.lblArmorName.Name = "lblArmorName";
            this.lblArmorName.Size = new System.Drawing.Size(96, 24);
            this.lblArmorName.TabIndex = 1;
            this.lblArmorName.Text = "Armor Name:";
            this.lblArmorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArmorDescription
            // 
            this.lblArmorDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArmorDescription.Location = new System.Drawing.Point(288, 40);
            this.lblArmorDescription.Name = "lblArmorDescription";
            this.lblArmorDescription.Size = new System.Drawing.Size(136, 24);
            this.lblArmorDescription.TabIndex = 3;
            this.lblArmorDescription.Text = "Armor Description:";
            this.lblArmorDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtArmorDescription
            // 
            this.txtArmorDescription.Location = new System.Drawing.Point(288, 64);
            this.txtArmorDescription.MaxLength = 1000;
            this.txtArmorDescription.Multiline = true;
            this.txtArmorDescription.Name = "txtArmorDescription";
            this.txtArmorDescription.Size = new System.Drawing.Size(256, 88);
            this.txtArmorDescription.TabIndex = 2;
            this.txtArmorDescription.TextChanged += new System.EventHandler(this.txtArmorDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Armor Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbArmorType
            // 
            this.cmbArmorType.FormattingEnabled = true;
            this.cmbArmorType.Location = new System.Drawing.Point(128, 48);
            this.cmbArmorType.Name = "cmbArmorType";
            this.cmbArmorType.Size = new System.Drawing.Size(152, 21);
            this.cmbArmorType.TabIndex = 5;
            this.cmbArmorType.SelectedIndexChanged += new System.EventHandler(this.cmbArmorType_SelectedIndexChanged);
            // 
            // lblReflexAdj
            // 
            this.lblReflexAdj.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReflexAdj.Location = new System.Drawing.Point(8, 80);
            this.lblReflexAdj.Name = "lblReflexAdj";
            this.lblReflexAdj.Size = new System.Drawing.Size(112, 24);
            this.lblReflexAdj.TabIndex = 7;
            this.lblReflexAdj.Text = "Reflex Adj:";
            this.lblReflexAdj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRefelxAdj
            // 
            this.txtRefelxAdj.Location = new System.Drawing.Point(128, 80);
            this.txtRefelxAdj.MaxLength = 100;
            this.txtRefelxAdj.Name = "txtRefelxAdj";
            this.txtRefelxAdj.Size = new System.Drawing.Size(152, 20);
            this.txtRefelxAdj.TabIndex = 6;
            this.txtRefelxAdj.TextChanged += new System.EventHandler(this.txtRefelxAdj_TextChanged);
            this.txtRefelxAdj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefelxAdj_KeyPress);
            // 
            // lblFortitudeAdj
            // 
            this.lblFortitudeAdj.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFortitudeAdj.Location = new System.Drawing.Point(8, 112);
            this.lblFortitudeAdj.Name = "lblFortitudeAdj";
            this.lblFortitudeAdj.Size = new System.Drawing.Size(112, 24);
            this.lblFortitudeAdj.TabIndex = 9;
            this.lblFortitudeAdj.Text = "Fortitude Adj:";
            this.lblFortitudeAdj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFortitudeAdj
            // 
            this.txtFortitudeAdj.Location = new System.Drawing.Point(128, 112);
            this.txtFortitudeAdj.MaxLength = 100;
            this.txtFortitudeAdj.Name = "txtFortitudeAdj";
            this.txtFortitudeAdj.Size = new System.Drawing.Size(152, 20);
            this.txtFortitudeAdj.TabIndex = 8;
            this.txtFortitudeAdj.TextChanged += new System.EventHandler(this.txtFortitudeAdj_TextChanged);
            this.txtFortitudeAdj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFortitudeAdj_KeyPress);
            // 
            // lblArmorID
            // 
            this.lblArmorID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArmorID.Location = new System.Drawing.Point(8, 8);
            this.lblArmorID.Name = "lblArmorID";
            this.lblArmorID.Size = new System.Drawing.Size(112, 24);
            this.lblArmorID.TabIndex = 10;
            this.lblArmorID.Text = "Armor ID:";
            this.lblArmorID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtArmorID
            // 
            this.txtArmorID.Location = new System.Drawing.Point(128, 8);
            this.txtArmorID.MaxLength = 100;
            this.txtArmorID.Name = "txtArmorID";
            this.txtArmorID.ReadOnly = true;
            this.txtArmorID.Size = new System.Drawing.Size(32, 20);
            this.txtArmorID.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.Location = new System.Drawing.Point(184, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 32);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNew.Location = new System.Drawing.Point(552, 24);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 32);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(552, 104);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.Location = new System.Drawing.Point(552, 64);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 32);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmArmor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 159);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtArmorID);
            this.Controls.Add(this.lblArmorID);
            this.Controls.Add(this.lblFortitudeAdj);
            this.Controls.Add(this.txtFortitudeAdj);
            this.Controls.Add(this.lblReflexAdj);
            this.Controls.Add(this.txtRefelxAdj);
            this.Controls.Add(this.cmbArmorType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblArmorDescription);
            this.Controls.Add(this.txtArmorDescription);
            this.Controls.Add(this.lblArmorName);
            this.Controls.Add(this.txtArmorName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArmor";
            this.Text = "Armor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArmorName;
        private System.Windows.Forms.Label lblArmorName;
        private System.Windows.Forms.Label lblArmorDescription;
        private System.Windows.Forms.TextBox txtArmorDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbArmorType;
        private System.Windows.Forms.Label lblReflexAdj;
        private System.Windows.Forms.TextBox txtRefelxAdj;
        private System.Windows.Forms.Label lblFortitudeAdj;
        private System.Windows.Forms.TextBox txtFortitudeAdj;
        private System.Windows.Forms.Label lblArmorID;
        private System.Windows.Forms.TextBox txtArmorID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
    }
}