namespace SWRPG_Custom_Windows_Controls
{
    partial class Character_Equipment_Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEquipmentName = new System.Windows.Forms.Label();
            this.txtEquipmentName = new System.Windows.Forms.TextBox();
            this.txtEquipmentDescription = new System.Windows.Forms.TextBox();
            this.lblEquipmentDescription = new System.Windows.Forms.Label();
            this.txtEquipmentCost = new System.Windows.Forms.TextBox();
            this.lblEquipmentCost = new System.Windows.Forms.Label();
            this.txtEmplacementPoints = new System.Windows.Forms.TextBox();
            this.lblEmplacementPoints = new System.Windows.Forms.Label();
            this.txtCharacterEquipmentNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.grpEquipmentControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtModificationDescription = new System.Windows.Forms.TextBox();
            this.txtEquipmentWeight = new System.Windows.Forms.TextBox();
            this.lblEquiipmentWeight = new System.Windows.Forms.Label();
            this.lblBook = new System.Windows.Forms.Label();
            this.txtBook = new System.Windows.Forms.TextBox();
            this.tvModifications = new System.Windows.Forms.TreeView();
            this.btnAddEquipmentModification = new System.Windows.Forms.Button();
            this.grpEquipmentControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEquipmentName
            // 
            this.lblEquipmentName.AutoSize = true;
            this.lblEquipmentName.Location = new System.Drawing.Point(8, 24);
            this.lblEquipmentName.Name = "lblEquipmentName";
            this.lblEquipmentName.Size = new System.Drawing.Size(42, 15);
            this.lblEquipmentName.TabIndex = 0;
            this.lblEquipmentName.Text = "Name:";
            // 
            // txtEquipmentName
            // 
            this.txtEquipmentName.Location = new System.Drawing.Point(84, 20);
            this.txtEquipmentName.Name = "txtEquipmentName";
            this.txtEquipmentName.ReadOnly = true;
            this.txtEquipmentName.Size = new System.Drawing.Size(228, 23);
            this.txtEquipmentName.TabIndex = 1;
            // 
            // txtEquipmentDescription
            // 
            this.txtEquipmentDescription.Location = new System.Drawing.Point(84, 76);
            this.txtEquipmentDescription.Multiline = true;
            this.txtEquipmentDescription.Name = "txtEquipmentDescription";
            this.txtEquipmentDescription.ReadOnly = true;
            this.txtEquipmentDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEquipmentDescription.Size = new System.Drawing.Size(436, 60);
            this.txtEquipmentDescription.TabIndex = 3;
            // 
            // lblEquipmentDescription
            // 
            this.lblEquipmentDescription.AutoSize = true;
            this.lblEquipmentDescription.Location = new System.Drawing.Point(8, 80);
            this.lblEquipmentDescription.Name = "lblEquipmentDescription";
            this.lblEquipmentDescription.Size = new System.Drawing.Size(70, 15);
            this.lblEquipmentDescription.TabIndex = 2;
            this.lblEquipmentDescription.Text = "Description:";
            // 
            // txtEquipmentCost
            // 
            this.txtEquipmentCost.Location = new System.Drawing.Point(356, 20);
            this.txtEquipmentCost.Name = "txtEquipmentCost";
            this.txtEquipmentCost.ReadOnly = true;
            this.txtEquipmentCost.Size = new System.Drawing.Size(48, 23);
            this.txtEquipmentCost.TabIndex = 5;
            // 
            // lblEquipmentCost
            // 
            this.lblEquipmentCost.AutoSize = true;
            this.lblEquipmentCost.Location = new System.Drawing.Point(318, 23);
            this.lblEquipmentCost.Name = "lblEquipmentCost";
            this.lblEquipmentCost.Size = new System.Drawing.Size(34, 15);
            this.lblEquipmentCost.TabIndex = 4;
            this.lblEquipmentCost.Text = "Cost:";
            // 
            // txtEmplacementPoints
            // 
            this.txtEmplacementPoints.Location = new System.Drawing.Point(434, 49);
            this.txtEmplacementPoints.Name = "txtEmplacementPoints";
            this.txtEmplacementPoints.ReadOnly = true;
            this.txtEmplacementPoints.Size = new System.Drawing.Size(28, 23);
            this.txtEmplacementPoints.TabIndex = 7;
            // 
            // lblEmplacementPoints
            // 
            this.lblEmplacementPoints.AutoSize = true;
            this.lblEmplacementPoints.Location = new System.Drawing.Point(324, 52);
            this.lblEmplacementPoints.Name = "lblEmplacementPoints";
            this.lblEmplacementPoints.Size = new System.Drawing.Size(102, 15);
            this.lblEmplacementPoints.TabIndex = 6;
            this.lblEmplacementPoints.Text = "Emplacement Pts:";
            // 
            // txtCharacterEquipmentNotes
            // 
            this.txtCharacterEquipmentNotes.Location = new System.Drawing.Point(84, 140);
            this.txtCharacterEquipmentNotes.MaxLength = 100;
            this.txtCharacterEquipmentNotes.Multiline = true;
            this.txtCharacterEquipmentNotes.Name = "txtCharacterEquipmentNotes";
            this.txtCharacterEquipmentNotes.Size = new System.Drawing.Size(436, 48);
            this.txtCharacterEquipmentNotes.TabIndex = 9;
            this.txtCharacterEquipmentNotes.TextChanged += new System.EventHandler(this.txtCharacterEquipmentNotes_TextChanged);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 144);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(41, 15);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Notes:";
            // 
            // grpEquipmentControl
            // 
            this.grpEquipmentControl.Controls.Add(this.btnSave);
            this.grpEquipmentControl.Controls.Add(this.txtModificationDescription);
            this.grpEquipmentControl.Controls.Add(this.txtEquipmentWeight);
            this.grpEquipmentControl.Controls.Add(this.lblEquiipmentWeight);
            this.grpEquipmentControl.Controls.Add(this.lblBook);
            this.grpEquipmentControl.Controls.Add(this.txtBook);
            this.grpEquipmentControl.Controls.Add(this.tvModifications);
            this.grpEquipmentControl.Controls.Add(this.btnAddEquipmentModification);
            this.grpEquipmentControl.Controls.Add(this.lblNotes);
            this.grpEquipmentControl.Controls.Add(this.txtCharacterEquipmentNotes);
            this.grpEquipmentControl.Controls.Add(this.lblEquipmentName);
            this.grpEquipmentControl.Controls.Add(this.txtEquipmentName);
            this.grpEquipmentControl.Controls.Add(this.txtEmplacementPoints);
            this.grpEquipmentControl.Controls.Add(this.lblEquipmentDescription);
            this.grpEquipmentControl.Controls.Add(this.lblEmplacementPoints);
            this.grpEquipmentControl.Controls.Add(this.txtEquipmentDescription);
            this.grpEquipmentControl.Controls.Add(this.txtEquipmentCost);
            this.grpEquipmentControl.Controls.Add(this.lblEquipmentCost);
            this.grpEquipmentControl.Location = new System.Drawing.Point(0, 0);
            this.grpEquipmentControl.Name = "grpEquipmentControl";
            this.grpEquipmentControl.Size = new System.Drawing.Size(712, 196);
            this.grpEquipmentControl.TabIndex = 10;
            this.grpEquipmentControl.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(472, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 24);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtModificationDescription
            // 
            this.txtModificationDescription.Location = new System.Drawing.Point(524, 124);
            this.txtModificationDescription.Multiline = true;
            this.txtModificationDescription.Name = "txtModificationDescription";
            this.txtModificationDescription.ReadOnly = true;
            this.txtModificationDescription.Size = new System.Drawing.Size(184, 64);
            this.txtModificationDescription.TabIndex = 101;
            // 
            // txtEquipmentWeight
            // 
            this.txtEquipmentWeight.Location = new System.Drawing.Point(462, 21);
            this.txtEquipmentWeight.Name = "txtEquipmentWeight";
            this.txtEquipmentWeight.ReadOnly = true;
            this.txtEquipmentWeight.Size = new System.Drawing.Size(48, 23);
            this.txtEquipmentWeight.TabIndex = 100;
            // 
            // lblEquiipmentWeight
            // 
            this.lblEquiipmentWeight.AutoSize = true;
            this.lblEquiipmentWeight.Location = new System.Drawing.Point(412, 24);
            this.lblEquiipmentWeight.Name = "lblEquiipmentWeight";
            this.lblEquiipmentWeight.Size = new System.Drawing.Size(48, 15);
            this.lblEquiipmentWeight.TabIndex = 99;
            this.lblEquiipmentWeight.Text = "Weight:";
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(12, 52);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(37, 15);
            this.lblBook.TabIndex = 97;
            this.lblBook.Text = "Book:";
            // 
            // txtBook
            // 
            this.txtBook.Location = new System.Drawing.Point(84, 48);
            this.txtBook.Name = "txtBook";
            this.txtBook.ReadOnly = true;
            this.txtBook.Size = new System.Drawing.Size(232, 23);
            this.txtBook.TabIndex = 98;
            // 
            // tvModifications
            // 
            this.tvModifications.Location = new System.Drawing.Point(524, 44);
            this.tvModifications.Name = "tvModifications";
            this.tvModifications.Size = new System.Drawing.Size(184, 76);
            this.tvModifications.TabIndex = 96;
            // 
            // btnAddEquipmentModification
            // 
            this.btnAddEquipmentModification.Enabled = false;
            this.btnAddEquipmentModification.Location = new System.Drawing.Point(540, 16);
            this.btnAddEquipmentModification.Name = "btnAddEquipmentModification";
            this.btnAddEquipmentModification.Size = new System.Drawing.Size(156, 20);
            this.btnAddEquipmentModification.TabIndex = 95;
            this.btnAddEquipmentModification.Text = "Edit Modification";
            this.btnAddEquipmentModification.UseVisualStyleBackColor = true;
            // 
            // Character_Equipment_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpEquipmentControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Character_Equipment_Control";
            this.Size = new System.Drawing.Size(715, 199);
            this.grpEquipmentControl.ResumeLayout(false);
            this.grpEquipmentControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEquipmentName;
        private System.Windows.Forms.TextBox txtEquipmentName;
        private System.Windows.Forms.TextBox txtEquipmentDescription;
        private System.Windows.Forms.Label lblEquipmentDescription;
        private System.Windows.Forms.TextBox txtEquipmentCost;
        private System.Windows.Forms.Label lblEquipmentCost;
        private System.Windows.Forms.TextBox txtEmplacementPoints;
        private System.Windows.Forms.Label lblEmplacementPoints;
        private System.Windows.Forms.TextBox txtCharacterEquipmentNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.GroupBox grpEquipmentControl;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.TextBox txtBook;
        private System.Windows.Forms.TreeView tvModifications;
        private System.Windows.Forms.Button btnAddEquipmentModification;
        private System.Windows.Forms.TextBox txtEquipmentWeight;
        private System.Windows.Forms.Label lblEquiipmentWeight;
        private System.Windows.Forms.TextBox txtModificationDescription;
        private System.Windows.Forms.Button btnSave;
    }
}
