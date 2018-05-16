namespace StarWarsRPG
{
    partial class frmEquipmentSelection
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
            this.gpEquipment = new System.Windows.Forms.GroupBox();
            this.tvEquipmentList = new System.Windows.Forms.TreeView();
            this.grpEquipment = new System.Windows.Forms.GroupBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnSelectEquipment = new System.Windows.Forms.Button();
            this.ckbUpgradeable = new System.Windows.Forms.CheckBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtEmplacementPoints = new System.Windows.Forms.TextBox();
            this.lblEmplacementPoints = new System.Windows.Forms.Label();
            this.txtEquipmentDescription = new System.Windows.Forms.TextBox();
            this.lblEquipmentDescription = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.txtEquipmentWeight = new System.Windows.Forms.TextBox();
            this.lblEquipmentWeight = new System.Windows.Forms.Label();
            this.txtEquipmentType = new System.Windows.Forms.TextBox();
            this.lblEquipmentType = new System.Windows.Forms.Label();
            this.txtEquipmentName = new System.Windows.Forms.TextBox();
            this.lblEquipmentName = new System.Windows.Forms.Label();
            this.gpEquipment.SuspendLayout();
            this.grpEquipment.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpEquipment
            // 
            this.gpEquipment.Controls.Add(this.tvEquipmentList);
            this.gpEquipment.Location = new System.Drawing.Point(8, 4);
            this.gpEquipment.Name = "gpEquipment";
            this.gpEquipment.Size = new System.Drawing.Size(327, 547);
            this.gpEquipment.TabIndex = 2;
            this.gpEquipment.TabStop = false;
            this.gpEquipment.Text = "Select Equipment";
            // 
            // tvEquipmentList
            // 
            this.tvEquipmentList.Location = new System.Drawing.Point(9, 20);
            this.tvEquipmentList.Name = "tvEquipmentList";
            this.tvEquipmentList.Size = new System.Drawing.Size(312, 489);
            this.tvEquipmentList.TabIndex = 0;
            this.tvEquipmentList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvEquipmentList_AfterSelect);
            // 
            // grpEquipment
            // 
            this.grpEquipment.Controls.Add(this.txtQuantity);
            this.grpEquipment.Controls.Add(this.lblQuantity);
            this.grpEquipment.Controls.Add(this.btnSelectEquipment);
            this.grpEquipment.Controls.Add(this.ckbUpgradeable);
            this.grpEquipment.Controls.Add(this.txtCost);
            this.grpEquipment.Controls.Add(this.lblCost);
            this.grpEquipment.Controls.Add(this.txtEmplacementPoints);
            this.grpEquipment.Controls.Add(this.lblEmplacementPoints);
            this.grpEquipment.Controls.Add(this.txtEquipmentDescription);
            this.grpEquipment.Controls.Add(this.lblEquipmentDescription);
            this.grpEquipment.Controls.Add(this.txtBookName);
            this.grpEquipment.Controls.Add(this.lblBook);
            this.grpEquipment.Controls.Add(this.txtEquipmentWeight);
            this.grpEquipment.Controls.Add(this.lblEquipmentWeight);
            this.grpEquipment.Controls.Add(this.txtEquipmentType);
            this.grpEquipment.Controls.Add(this.lblEquipmentType);
            this.grpEquipment.Controls.Add(this.txtEquipmentName);
            this.grpEquipment.Controls.Add(this.lblEquipmentName);
            this.grpEquipment.Location = new System.Drawing.Point(344, 4);
            this.grpEquipment.Name = "grpEquipment";
            this.grpEquipment.Size = new System.Drawing.Size(480, 512);
            this.grpEquipment.TabIndex = 3;
            this.grpEquipment.TabStop = false;
            this.grpEquipment.Text = "Equipment";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(416, 124);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(52, 20);
            this.txtQuantity.TabIndex = 76;
            this.txtQuantity.Visible = false;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(352, 124);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(59, 17);
            this.lblQuantity.TabIndex = 75;
            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.Visible = false;
            // 
            // btnSelectEquipment
            // 
            this.btnSelectEquipment.Enabled = false;
            this.btnSelectEquipment.Location = new System.Drawing.Point(396, 20);
            this.btnSelectEquipment.Name = "btnSelectEquipment";
            this.btnSelectEquipment.Size = new System.Drawing.Size(72, 43);
            this.btnSelectEquipment.TabIndex = 70;
            this.btnSelectEquipment.Text = "Select Equipment";
            this.btnSelectEquipment.UseVisualStyleBackColor = true;
            this.btnSelectEquipment.Click += new System.EventHandler(this.btnSelectEquipment_Click);
            // 
            // ckbUpgradeable
            // 
            this.ckbUpgradeable.AutoSize = true;
            this.ckbUpgradeable.Enabled = false;
            this.ckbUpgradeable.Location = new System.Drawing.Point(164, 124);
            this.ckbUpgradeable.Name = "ckbUpgradeable";
            this.ckbUpgradeable.Size = new System.Drawing.Size(132, 17);
            this.ckbUpgradeable.TabIndex = 74;
            this.ckbUpgradeable.Text = "Equpment Upgradable";
            this.ckbUpgradeable.UseVisualStyleBackColor = true;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(228, 100);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(244, 20);
            this.txtCost.TabIndex = 73;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(184, 100);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(37, 17);
            this.lblCost.TabIndex = 72;
            this.lblCost.Text = "Cost:";
            // 
            // txtEmplacementPoints
            // 
            this.txtEmplacementPoints.Location = new System.Drawing.Point(128, 100);
            this.txtEmplacementPoints.Name = "txtEmplacementPoints";
            this.txtEmplacementPoints.ReadOnly = true;
            this.txtEmplacementPoints.Size = new System.Drawing.Size(52, 20);
            this.txtEmplacementPoints.TabIndex = 71;
            // 
            // lblEmplacementPoints
            // 
            this.lblEmplacementPoints.AutoSize = true;
            this.lblEmplacementPoints.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmplacementPoints.Location = new System.Drawing.Point(12, 100);
            this.lblEmplacementPoints.Name = "lblEmplacementPoints";
            this.lblEmplacementPoints.Size = new System.Drawing.Size(110, 17);
            this.lblEmplacementPoints.TabIndex = 70;
            this.lblEmplacementPoints.Text = "Emplacement Pts:";
            // 
            // txtEquipmentDescription
            // 
            this.txtEquipmentDescription.Location = new System.Drawing.Point(12, 148);
            this.txtEquipmentDescription.Multiline = true;
            this.txtEquipmentDescription.Name = "txtEquipmentDescription";
            this.txtEquipmentDescription.ReadOnly = true;
            this.txtEquipmentDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEquipmentDescription.Size = new System.Drawing.Size(462, 356);
            this.txtEquipmentDescription.TabIndex = 69;
            // 
            // lblEquipmentDescription
            // 
            this.lblEquipmentDescription.AutoSize = true;
            this.lblEquipmentDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentDescription.Location = new System.Drawing.Point(12, 124);
            this.lblEquipmentDescription.Name = "lblEquipmentDescription";
            this.lblEquipmentDescription.Size = new System.Drawing.Size(143, 17);
            this.lblEquipmentDescription.TabIndex = 68;
            this.lblEquipmentDescription.Text = "Equipment Description:";
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(204, 76);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.ReadOnly = true;
            this.txtBookName.Size = new System.Drawing.Size(180, 20);
            this.txtBookName.TabIndex = 24;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBook.Location = new System.Drawing.Point(160, 76);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(40, 17);
            this.lblBook.TabIndex = 23;
            this.lblBook.Text = "Book:";
            // 
            // txtEquipmentWeight
            // 
            this.txtEquipmentWeight.Location = new System.Drawing.Point(64, 76);
            this.txtEquipmentWeight.Name = "txtEquipmentWeight";
            this.txtEquipmentWeight.ReadOnly = true;
            this.txtEquipmentWeight.Size = new System.Drawing.Size(88, 20);
            this.txtEquipmentWeight.TabIndex = 22;
            // 
            // lblEquipmentWeight
            // 
            this.lblEquipmentWeight.AutoSize = true;
            this.lblEquipmentWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentWeight.Location = new System.Drawing.Point(12, 76);
            this.lblEquipmentWeight.Name = "lblEquipmentWeight";
            this.lblEquipmentWeight.Size = new System.Drawing.Size(52, 17);
            this.lblEquipmentWeight.TabIndex = 21;
            this.lblEquipmentWeight.Text = "Weight:";
            // 
            // txtEquipmentType
            // 
            this.txtEquipmentType.Location = new System.Drawing.Point(64, 48);
            this.txtEquipmentType.Name = "txtEquipmentType";
            this.txtEquipmentType.ReadOnly = true;
            this.txtEquipmentType.Size = new System.Drawing.Size(320, 20);
            this.txtEquipmentType.TabIndex = 20;
            // 
            // lblEquipmentType
            // 
            this.lblEquipmentType.AutoSize = true;
            this.lblEquipmentType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentType.Location = new System.Drawing.Point(12, 52);
            this.lblEquipmentType.Name = "lblEquipmentType";
            this.lblEquipmentType.Size = new System.Drawing.Size(39, 17);
            this.lblEquipmentType.TabIndex = 19;
            this.lblEquipmentType.Text = "Type:";
            // 
            // txtEquipmentName
            // 
            this.txtEquipmentName.Location = new System.Drawing.Point(64, 20);
            this.txtEquipmentName.Name = "txtEquipmentName";
            this.txtEquipmentName.ReadOnly = true;
            this.txtEquipmentName.Size = new System.Drawing.Size(320, 20);
            this.txtEquipmentName.TabIndex = 18;
            // 
            // lblEquipmentName
            // 
            this.lblEquipmentName.AutoSize = true;
            this.lblEquipmentName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentName.Location = new System.Drawing.Point(12, 24);
            this.lblEquipmentName.Name = "lblEquipmentName";
            this.lblEquipmentName.Size = new System.Drawing.Size(46, 17);
            this.lblEquipmentName.TabIndex = 17;
            this.lblEquipmentName.Text = "Name:";
            // 
            // frmEquipmentSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 521);
            this.Controls.Add(this.grpEquipment);
            this.Controls.Add(this.gpEquipment);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEquipmentSelection";
            this.Text = "Selection Equipment";
            this.gpEquipment.ResumeLayout(false);
            this.grpEquipment.ResumeLayout(false);
            this.grpEquipment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpEquipment;
        private System.Windows.Forms.TreeView tvEquipmentList;
        private System.Windows.Forms.GroupBox grpEquipment;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.TextBox txtEquipmentWeight;
        private System.Windows.Forms.Label lblEquipmentWeight;
        private System.Windows.Forms.TextBox txtEquipmentType;
        private System.Windows.Forms.Label lblEquipmentType;
        private System.Windows.Forms.TextBox txtEquipmentName;
        private System.Windows.Forms.Label lblEquipmentName;
        private System.Windows.Forms.TextBox txtEquipmentDescription;
        private System.Windows.Forms.Label lblEquipmentDescription;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtEmplacementPoints;
        private System.Windows.Forms.Label lblEmplacementPoints;
        private System.Windows.Forms.CheckBox ckbUpgradeable;
        private System.Windows.Forms.Button btnSelectEquipment;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
    }
}