namespace StarWarsRPG
{
    partial class frmForcePower
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
            this.txtForcePowerID = new System.Windows.Forms.TextBox();
            this.lblForcePowerID = new System.Windows.Forms.Label();
            this.lblTurnSegment = new System.Windows.Forms.Label();
            this.cmbForcePowerDescriptorType = new System.Windows.Forms.ComboBox();
            this.lblForcePowerDescriptor = new System.Windows.Forms.Label();
            this.lblForcePowerDescription = new System.Windows.Forms.Label();
            this.txtForcePowerDescription = new System.Windows.Forms.TextBox();
            this.lblForcePowerName = new System.Windows.Forms.Label();
            this.txtForcePowerName = new System.Windows.Forms.TextBox();
            this.cmbTurnSegment = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.Location = new System.Drawing.Point(568, 64);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 32);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(568, 104);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 32);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNew.Location = new System.Drawing.Point(568, 24);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 32);
            this.btnNew.TabIndex = 29;
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
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtForcePowerID
            // 
            this.txtForcePowerID.Location = new System.Drawing.Point(128, 8);
            this.txtForcePowerID.MaxLength = 100;
            this.txtForcePowerID.Name = "txtForcePowerID";
            this.txtForcePowerID.ReadOnly = true;
            this.txtForcePowerID.Size = new System.Drawing.Size(32, 20);
            this.txtForcePowerID.TabIndex = 27;
            // 
            // lblForcePowerID
            // 
            this.lblForcePowerID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblForcePowerID.Location = new System.Drawing.Point(8, 8);
            this.lblForcePowerID.Name = "lblForcePowerID";
            this.lblForcePowerID.Size = new System.Drawing.Size(112, 24);
            this.lblForcePowerID.TabIndex = 26;
            this.lblForcePowerID.Text = "Force Power ID:";
            this.lblForcePowerID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTurnSegment
            // 
            this.lblTurnSegment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTurnSegment.Location = new System.Drawing.Point(8, 80);
            this.lblTurnSegment.Name = "lblTurnSegment";
            this.lblTurnSegment.Size = new System.Drawing.Size(112, 24);
            this.lblTurnSegment.TabIndex = 23;
            this.lblTurnSegment.Text = "Turn Segment:";
            this.lblTurnSegment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbForcePowerDescriptorType
            // 
            this.cmbForcePowerDescriptorType.FormattingEnabled = true;
            this.cmbForcePowerDescriptorType.Location = new System.Drawing.Point(128, 48);
            this.cmbForcePowerDescriptorType.Name = "cmbForcePowerDescriptorType";
            this.cmbForcePowerDescriptorType.Size = new System.Drawing.Size(152, 21);
            this.cmbForcePowerDescriptorType.TabIndex = 21;
            this.cmbForcePowerDescriptorType.SelectedIndexChanged += new System.EventHandler(this.cmbForcePowerType_SelectedIndexChanged);
            // 
            // lblForcePowerDescriptor
            // 
            this.lblForcePowerDescriptor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblForcePowerDescriptor.Location = new System.Drawing.Point(8, 48);
            this.lblForcePowerDescriptor.Name = "lblForcePowerDescriptor";
            this.lblForcePowerDescriptor.Size = new System.Drawing.Size(112, 32);
            this.lblForcePowerDescriptor.TabIndex = 20;
            this.lblForcePowerDescriptor.Text = "Descriptor:";
            this.lblForcePowerDescriptor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblForcePowerDescription
            // 
            this.lblForcePowerDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblForcePowerDescription.Location = new System.Drawing.Point(288, 40);
            this.lblForcePowerDescription.Name = "lblForcePowerDescription";
            this.lblForcePowerDescription.Size = new System.Drawing.Size(136, 24);
            this.lblForcePowerDescription.TabIndex = 19;
            this.lblForcePowerDescription.Text = "Description:";
            this.lblForcePowerDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForcePowerDescription
            // 
            this.txtForcePowerDescription.Location = new System.Drawing.Point(304, 64);
            this.txtForcePowerDescription.MaxLength = 1000;
            this.txtForcePowerDescription.Multiline = true;
            this.txtForcePowerDescription.Name = "txtForcePowerDescription";
            this.txtForcePowerDescription.Size = new System.Drawing.Size(256, 88);
            this.txtForcePowerDescription.TabIndex = 18;
            this.txtForcePowerDescription.TextAlignChanged += new System.EventHandler(this.txtForcePowerDescription_TextChanged);
            // 
            // lblForcePowerName
            // 
            this.lblForcePowerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblForcePowerName.Location = new System.Drawing.Point(288, 8);
            this.lblForcePowerName.Name = "lblForcePowerName";
            this.lblForcePowerName.Size = new System.Drawing.Size(112, 24);
            this.lblForcePowerName.TabIndex = 17;
            this.lblForcePowerName.Text = "Name:";
            this.lblForcePowerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForcePowerName
            // 
            this.txtForcePowerName.Location = new System.Drawing.Point(408, 8);
            this.txtForcePowerName.MaxLength = 100;
            this.txtForcePowerName.Name = "txtForcePowerName";
            this.txtForcePowerName.Size = new System.Drawing.Size(152, 20);
            this.txtForcePowerName.TabIndex = 16;
            this.txtForcePowerName.TextChanged += new System.EventHandler(this.txtForcePowerName_TextChanged);
            // 
            // cmbTurnSegment
            // 
            this.cmbTurnSegment.FormattingEnabled = true;
            this.cmbTurnSegment.Location = new System.Drawing.Point(128, 80);
            this.cmbTurnSegment.Name = "cmbTurnSegment";
            this.cmbTurnSegment.Size = new System.Drawing.Size(152, 21);
            this.cmbTurnSegment.TabIndex = 32;
            this.cmbTurnSegment.SelectedIndexChanged += new System.EventHandler(this.cmbTurnSegment_SelectedIndexChanged);
            // 
            // frmForcePower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 159);
            this.Controls.Add(this.cmbTurnSegment);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtForcePowerID);
            this.Controls.Add(this.lblForcePowerID);
            this.Controls.Add(this.lblTurnSegment);
            this.Controls.Add(this.cmbForcePowerDescriptorType);
            this.Controls.Add(this.lblForcePowerDescriptor);
            this.Controls.Add(this.lblForcePowerDescription);
            this.Controls.Add(this.txtForcePowerDescription);
            this.Controls.Add(this.lblForcePowerName);
            this.Controls.Add(this.txtForcePowerName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForcePower";
            this.Text = "Force Power";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtForcePowerID;
        private System.Windows.Forms.Label lblForcePowerID;
        private System.Windows.Forms.Label lblTurnSegment;
        private System.Windows.Forms.ComboBox cmbForcePowerDescriptorType;
        private System.Windows.Forms.Label lblForcePowerDescriptor;
        private System.Windows.Forms.Label lblForcePowerDescription;
        private System.Windows.Forms.TextBox txtForcePowerDescription;
        private System.Windows.Forms.Label lblForcePowerName;
        private System.Windows.Forms.TextBox txtForcePowerName;
        private System.Windows.Forms.ComboBox cmbTurnSegment;
    }
}