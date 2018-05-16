namespace StarWarsRPG
{
    partial class frmEquipment
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
            this.txtEquipmentID = new System.Windows.Forms.TextBox();
            this.lblEquipmentID = new System.Windows.Forms.Label();
            this.lblEquipmentDescription = new System.Windows.Forms.Label();
            this.txtEquipmentDescription = new System.Windows.Forms.TextBox();
            this.lblEquipmentName = new System.Windows.Forms.Label();
            this.txtEquipmentName = new System.Windows.Forms.TextBox();
            this.lblEquipmentWeight = new System.Windows.Forms.Label();
            this.txtEquipementWeight = new System.Windows.Forms.TextBox();
            this.lblKiloGrams = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.Location = new System.Drawing.Point(384, 72);
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
            this.btnSave.Location = new System.Drawing.Point(384, 112);
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
            this.btnNew.Location = new System.Drawing.Point(384, 32);
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
            // txtEquipmentID
            // 
            this.txtEquipmentID.Location = new System.Drawing.Point(128, 8);
            this.txtEquipmentID.MaxLength = 100;
            this.txtEquipmentID.Name = "txtEquipmentID";
            this.txtEquipmentID.ReadOnly = true;
            this.txtEquipmentID.Size = new System.Drawing.Size(32, 20);
            this.txtEquipmentID.TabIndex = 37;
            // 
            // lblEquipmentID
            // 
            this.lblEquipmentID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEquipmentID.Location = new System.Drawing.Point(8, 8);
            this.lblEquipmentID.Name = "lblEquipmentID";
            this.lblEquipmentID.Size = new System.Drawing.Size(112, 24);
            this.lblEquipmentID.TabIndex = 36;
            this.lblEquipmentID.Text = "Equipment ID:";
            this.lblEquipmentID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEquipmentDescription
            // 
            this.lblEquipmentDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEquipmentDescription.Location = new System.Drawing.Point(8, 96);
            this.lblEquipmentDescription.Name = "lblEquipmentDescription";
            this.lblEquipmentDescription.Size = new System.Drawing.Size(104, 24);
            this.lblEquipmentDescription.TabIndex = 35;
            this.lblEquipmentDescription.Text = "Description:";
            this.lblEquipmentDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEquipmentDescription
            // 
            this.txtEquipmentDescription.Location = new System.Drawing.Point(120, 96);
            this.txtEquipmentDescription.MaxLength = 1000;
            this.txtEquipmentDescription.Multiline = true;
            this.txtEquipmentDescription.Name = "txtEquipmentDescription";
            this.txtEquipmentDescription.Size = new System.Drawing.Size(256, 88);
            this.txtEquipmentDescription.TabIndex = 34;
            this.txtEquipmentDescription.TextChanged += new System.EventHandler(this.txtEquipmentDescription_TextChanged);
            // 
            // lblEquipmentName
            // 
            this.lblEquipmentName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEquipmentName.Location = new System.Drawing.Point(8, 48);
            this.lblEquipmentName.Name = "lblEquipmentName";
            this.lblEquipmentName.Size = new System.Drawing.Size(104, 24);
            this.lblEquipmentName.TabIndex = 33;
            this.lblEquipmentName.Text = "Name:";
            this.lblEquipmentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEquipmentName
            // 
            this.txtEquipmentName.Location = new System.Drawing.Point(120, 48);
            this.txtEquipmentName.MaxLength = 100;
            this.txtEquipmentName.Name = "txtEquipmentName";
            this.txtEquipmentName.Size = new System.Drawing.Size(152, 20);
            this.txtEquipmentName.TabIndex = 32;
            this.txtEquipmentName.TextChanged += new System.EventHandler(this.txtEquipmentName_TextChanged);
            // 
            // lblEquipmentWeight
            // 
            this.lblEquipmentWeight.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEquipmentWeight.Location = new System.Drawing.Point(8, 72);
            this.lblEquipmentWeight.Name = "lblEquipmentWeight";
            this.lblEquipmentWeight.Size = new System.Drawing.Size(104, 24);
            this.lblEquipmentWeight.TabIndex = 43;
            this.lblEquipmentWeight.Text = "Weight:";
            this.lblEquipmentWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEquipementWeight
            // 
            this.txtEquipementWeight.Location = new System.Drawing.Point(120, 72);
            this.txtEquipementWeight.MaxLength = 100;
            this.txtEquipementWeight.Name = "txtEquipementWeight";
            this.txtEquipementWeight.Size = new System.Drawing.Size(152, 20);
            this.txtEquipementWeight.TabIndex = 42;
            this.txtEquipementWeight.TextChanged += new System.EventHandler(this.txtEquipementWeight_TextChanged);
            this.txtEquipementWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEquipementWeight_KeyPress);
            // 
            // lblKiloGrams
            // 
            this.lblKiloGrams.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKiloGrams.Location = new System.Drawing.Point(272, 72);
            this.lblKiloGrams.Name = "lblKiloGrams";
            this.lblKiloGrams.Size = new System.Drawing.Size(72, 24);
            this.lblKiloGrams.TabIndex = 44;
            this.lblKiloGrams.Text = "KiloGrams";
            this.lblKiloGrams.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 190);
            this.Controls.Add(this.lblKiloGrams);
            this.Controls.Add(this.lblEquipmentWeight);
            this.Controls.Add(this.txtEquipementWeight);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtEquipmentID);
            this.Controls.Add(this.lblEquipmentID);
            this.Controls.Add(this.lblEquipmentDescription);
            this.Controls.Add(this.txtEquipmentDescription);
            this.Controls.Add(this.lblEquipmentName);
            this.Controls.Add(this.txtEquipmentName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEquipment";
            this.Text = "Equipment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtEquipmentID;
        private System.Windows.Forms.Label lblEquipmentID;
        private System.Windows.Forms.Label lblEquipmentDescription;
        private System.Windows.Forms.TextBox txtEquipmentDescription;
        private System.Windows.Forms.Label lblEquipmentName;
        private System.Windows.Forms.TextBox txtEquipmentName;
        private System.Windows.Forms.Label lblEquipmentWeight;
        private System.Windows.Forms.TextBox txtEquipementWeight;
        private System.Windows.Forms.Label lblKiloGrams;
    }
}