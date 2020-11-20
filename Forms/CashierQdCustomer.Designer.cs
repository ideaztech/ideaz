namespace Solum
{
    partial class CashierQdCustomer
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
            System.Windows.Forms.Label phoneNumberLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label address2Label;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierQdCustomer));
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.postalCodeTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.address2TextBox = new System.Windows.Forms.TextBox();
            this.address1TextBox = new System.Windows.Forms.TextBox();
            this.fieldNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            phoneNumberLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            address2Label = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            phoneNumberLabel.ForeColor = System.Drawing.SystemColors.Control;
            phoneNumberLabel.Location = new System.Drawing.Point(388, 151);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new System.Drawing.Size(65, 19);
            phoneNumberLabel.TabIndex = 36;
            phoneNumberLabel.Text = "Phone:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            postalCodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            postalCodeLabel.Location = new System.Drawing.Point(38, 187);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(108, 19);
            postalCodeLabel.TabIndex = 34;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cityLabel.ForeColor = System.Drawing.SystemColors.Control;
            cityLabel.Location = new System.Drawing.Point(38, 153);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(45, 19);
            cityLabel.TabIndex = 32;
            cityLabel.Text = "City:";
            // 
            // address2Label
            // 
            address2Label.AutoSize = true;
            address2Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            address2Label.ForeColor = System.Drawing.SystemColors.Control;
            address2Label.Location = new System.Drawing.Point(38, 116);
            address2Label.Name = "address2Label";
            address2Label.Size = new System.Drawing.Size(88, 19);
            address2Label.TabIndex = 30;
            address2Label.Text = "Address2:";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            address1Label.ForeColor = System.Drawing.SystemColors.Control;
            address1Label.Location = new System.Drawing.Point(38, 79);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(88, 19);
            address1Label.TabIndex = 28;
            address1Label.Text = "Address1:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.ForeColor = System.Drawing.SystemColors.Control;
            nameLabel.Location = new System.Drawing.Point(38, 37);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(59, 19);
            nameLabel.TabIndex = 26;
            nameLabel.Text = "Name:";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneNumberTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumberTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.phoneNumberTextBox.Location = new System.Drawing.Point(456, 151);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.ReadOnly = true;
            this.phoneNumberTextBox.Size = new System.Drawing.Size(100, 19);
            this.phoneNumberTextBox.TabIndex = 37;
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.postalCodeTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalCodeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.postalCodeTextBox.Location = new System.Drawing.Point(167, 187);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.ReadOnly = true;
            this.postalCodeTextBox.Size = new System.Drawing.Size(100, 19);
            this.postalCodeTextBox.TabIndex = 35;
            // 
            // cityTextBox
            // 
            this.cityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cityTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.cityTextBox.Location = new System.Drawing.Point(167, 150);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.ReadOnly = true;
            this.cityTextBox.Size = new System.Drawing.Size(201, 19);
            this.cityTextBox.TabIndex = 33;
            // 
            // address2TextBox
            // 
            this.address2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.address2TextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.address2TextBox.Location = new System.Drawing.Point(167, 113);
            this.address2TextBox.Name = "address2TextBox";
            this.address2TextBox.ReadOnly = true;
            this.address2TextBox.Size = new System.Drawing.Size(390, 19);
            this.address2TextBox.TabIndex = 31;
            // 
            // address1TextBox
            // 
            this.address1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.address1TextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.address1TextBox.Location = new System.Drawing.Point(167, 76);
            this.address1TextBox.Name = "address1TextBox";
            this.address1TextBox.ReadOnly = true;
            this.address1TextBox.Size = new System.Drawing.Size(390, 19);
            this.address1TextBox.TabIndex = 29;
            // 
            // fieldNameTextBox
            // 
            this.fieldNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldNameTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.fieldNameTextBox.Location = new System.Drawing.Point(167, 39);
            this.fieldNameTextBox.Name = "fieldNameTextBox";
            this.fieldNameTextBox.ReadOnly = true;
            this.fieldNameTextBox.Size = new System.Drawing.Size(390, 19);
            this.fieldNameTextBox.TabIndex = 27;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(149)))), ((int)(((byte)(173)))));
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.FlatAppearance.BorderSize = 0;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirm.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonConfirm.Location = new System.Drawing.Point(175, 279);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(121, 61);
            this.buttonConfirm.TabIndex = 38;
            this.buttonConfirm.Text = "&Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.Location = new System.Drawing.Point(320, 279);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 61);
            this.buttonCancel.TabIndex = 39;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(nameLabel);
            this.panel1.Controls.Add(this.buttonConfirm);
            this.panel1.Controls.Add(this.fieldNameTextBox);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.address1TextBox);
            this.panel1.Controls.Add(phoneNumberLabel);
            this.panel1.Controls.Add(address1Label);
            this.panel1.Controls.Add(this.phoneNumberTextBox);
            this.panel1.Controls.Add(this.address2TextBox);
            this.panel1.Controls.Add(postalCodeLabel);
            this.panel1.Controls.Add(address2Label);
            this.panel1.Controls.Add(this.postalCodeTextBox);
            this.panel1.Controls.Add(this.cityTextBox);
            this.panel1.Controls.Add(cityLabel);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 396);
            this.panel1.TabIndex = 40;
            // 
            // CashierQdCustomer
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(186)))), ((int)(((byte)(190)))));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(616, 409);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashierQdCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CashierQdCustomer";
            this.Load += new System.EventHandler(this.CashierQdCustomer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.TextBox postalCodeTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox address2TextBox;
        private System.Windows.Forms.TextBox address1TextBox;
        private System.Windows.Forms.TextBox fieldNameTextBox;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
    }
}