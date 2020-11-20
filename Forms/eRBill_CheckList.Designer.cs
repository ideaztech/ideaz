namespace Solum
{
    partial class eRBill_CheckList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eRBill_CheckList));
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonTransmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRBillNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTrailerNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxProBillNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerShippedDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSealNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLoadReference = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxPlant = new System.Windows.Forms.ComboBox();
            this.sol_WS_PlantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPlantsLookup = new Solum.DataSetPlantsLookup();
            this.comboBoxCarrier = new System.Windows.Forms.ComboBox();
            this.sol_WS_CarriersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetCarriersLookup = new Solum.DataSetCarriersLookup();
            this.sol_WS_CarriersTableAdapter = new Solum.DataSetCarriersLookupTableAdapters.Sol_WS_CarriersTableAdapter();
            this.sol_WS_PlantsTableAdapter = new Solum.DataSetPlantsLookupTableAdapters.Sol_WS_PlantsTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxViewERBill = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WS_PlantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPlantsLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WS_CarriersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCarriersLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(86, 594);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(129, 50);
            this.OK.TabIndex = 1;
            this.OK.Text = "&Apply";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(424, 594);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(129, 50);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "&Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // buttonTransmit
            // 
            this.buttonTransmit.Location = new System.Drawing.Point(255, 594);
            this.buttonTransmit.Name = "buttonTransmit";
            this.buttonTransmit.Size = new System.Drawing.Size(129, 50);
            this.buttonTransmit.TabIndex = 2;
            this.buttonTransmit.Text = "&Transmit";
            this.buttonTransmit.UseVisualStyleBackColor = true;
            this.buttonTransmit.Click += new System.EventHandler(this.buttonTransmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&BOL #:";
            // 
            // textBoxRBillNumber
            // 
            this.textBoxRBillNumber.Location = new System.Drawing.Point(179, 33);
            this.textBoxRBillNumber.MaxLength = 10;
            this.textBoxRBillNumber.Name = "textBoxRBillNumber";
            this.textBoxRBillNumber.ReadOnly = true;
            this.textBoxRBillNumber.Size = new System.Drawing.Size(92, 21);
            this.textBoxRBillNumber.TabIndex = 1;
            this.textBoxRBillNumber.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Carrier:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Plant:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Trailer Number:";
            // 
            // textBoxTrailerNumber
            // 
            this.textBoxTrailerNumber.Location = new System.Drawing.Point(179, 185);
            this.textBoxTrailerNumber.MaxLength = 15;
            this.textBoxTrailerNumber.Name = "textBoxTrailerNumber";
            this.textBoxTrailerNumber.Size = new System.Drawing.Size(125, 21);
            this.textBoxTrailerNumber.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "&Pro Bill Number:";
            // 
            // textBoxProBillNumber
            // 
            this.textBoxProBillNumber.Location = new System.Drawing.Point(179, 285);
            this.textBoxProBillNumber.MaxLength = 20;
            this.textBoxProBillNumber.Name = "textBoxProBillNumber";
            this.textBoxProBillNumber.Size = new System.Drawing.Size(162, 21);
            this.textBoxProBillNumber.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "&Shipped Date:";
            // 
            // dateTimePickerShippedDate
            // 
            this.dateTimePickerShippedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerShippedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerShippedDate.Location = new System.Drawing.Point(179, 380);
            this.dateTimePickerShippedDate.Name = "dateTimePickerShippedDate";
            this.dateTimePickerShippedDate.Size = new System.Drawing.Size(115, 24);
            this.dateTimePickerShippedDate.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "&Seal Number:";
            // 
            // textBoxSealNumber
            // 
            this.textBoxSealNumber.Location = new System.Drawing.Point(179, 235);
            this.textBoxSealNumber.MaxLength = 10;
            this.textBoxSealNumber.Name = "textBoxSealNumber";
            this.textBoxSealNumber.Size = new System.Drawing.Size(92, 21);
            this.textBoxSealNumber.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "&Load Reference:";
            // 
            // textBoxLoadReference
            // 
            this.textBoxLoadReference.Location = new System.Drawing.Point(179, 333);
            this.textBoxLoadReference.MaxLength = 10;
            this.textBoxLoadReference.Name = "textBoxLoadReference";
            this.textBoxLoadReference.Size = new System.Drawing.Size(92, 21);
            this.textBoxLoadReference.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(217)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBoxPlant);
            this.panel1.Controls.Add(this.dateTimePickerShippedDate);
            this.panel1.Controls.Add(this.comboBoxCarrier);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxRBillNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxLoadReference);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxSealNumber);
            this.panel1.Controls.Add(this.textBoxTrailerNumber);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxProBillNumber);
            this.panel1.Location = new System.Drawing.Point(65, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 438);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(302, 385);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "*";
            // 
            // comboBoxPlant
            // 
            this.comboBoxPlant.DataSource = this.sol_WS_PlantsBindingSource;
            this.comboBoxPlant.DisplayMember = "Plant";
            this.comboBoxPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlant.FormattingEnabled = true;
            this.comboBoxPlant.Location = new System.Drawing.Point(179, 135);
            this.comboBoxPlant.Name = "comboBoxPlant";
            this.comboBoxPlant.Size = new System.Drawing.Size(258, 23);
            this.comboBoxPlant.TabIndex = 5;
            this.comboBoxPlant.ValueMember = "PlantID";
            // 
            // sol_WS_PlantsBindingSource
            // 
            this.sol_WS_PlantsBindingSource.DataMember = "Sol_WS_Plants";
            this.sol_WS_PlantsBindingSource.DataSource = this.dataSetPlantsLookup;
            // 
            // dataSetPlantsLookup
            // 
            this.dataSetPlantsLookup.DataSetName = "DataSetPlantsLookup";
            this.dataSetPlantsLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxCarrier
            // 
            this.comboBoxCarrier.DataSource = this.sol_WS_CarriersBindingSource;
            this.comboBoxCarrier.DisplayMember = "Carrier";
            this.comboBoxCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCarrier.FormattingEnabled = true;
            this.comboBoxCarrier.Location = new System.Drawing.Point(179, 83);
            this.comboBoxCarrier.Name = "comboBoxCarrier";
            this.comboBoxCarrier.Size = new System.Drawing.Size(258, 23);
            this.comboBoxCarrier.TabIndex = 3;
            this.comboBoxCarrier.ValueMember = "CarrierID";
            // 
            // sol_WS_CarriersBindingSource
            // 
            this.sol_WS_CarriersBindingSource.DataMember = "Sol_WS_Carriers";
            this.sol_WS_CarriersBindingSource.DataSource = this.dataSetCarriersLookup;
            // 
            // dataSetCarriersLookup
            // 
            this.dataSetCarriersLookup.DataSetName = "DataSetCarriersLookup";
            this.dataSetCarriersLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_WS_CarriersTableAdapter
            // 
            this.sol_WS_CarriersTableAdapter.ClearBeforeFill = true;
            // 
            // sol_WS_PlantsTableAdapter
            // 
            this.sol_WS_PlantsTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(177, 488);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 64);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxViewERBill
            // 
            this.checkBoxViewERBill.AutoSize = true;
            this.checkBoxViewERBill.Location = new System.Drawing.Point(222, 562);
            this.checkBoxViewERBill.Name = "checkBoxViewERBill";
            this.checkBoxViewERBill.Size = new System.Drawing.Size(141, 19);
            this.checkBoxViewERBill.TabIndex = 7;
            this.checkBoxViewERBill.Text = "View BOL Containers";
            this.checkBoxViewERBill.UseVisualStyleBackColor = true;
            // 
            // eRBill_CheckList
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(651, 657);
            this.Controls.Add(this.checkBoxViewERBill);
            this.Controls.Add(this.buttonTransmit);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "eRBill_CheckList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload BOL";
            this.Load += new System.EventHandler(this.eRBill_CheckList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WS_PlantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPlantsLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WS_CarriersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCarriersLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonTransmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRBillNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTrailerNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxProBillNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerShippedDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSealNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLoadReference;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource sol_WS_CarriersBindingSource;
        private DataSetCarriersLookup dataSetCarriersLookup;
        private DataSetCarriersLookupTableAdapters.Sol_WS_CarriersTableAdapter sol_WS_CarriersTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxCarrier;
        private DataSetPlantsLookup dataSetPlantsLookup;
        private System.Windows.Forms.BindingSource sol_WS_PlantsBindingSource;
        private DataSetPlantsLookupTableAdapters.Sol_WS_PlantsTableAdapter sol_WS_PlantsTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxPlant;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxViewERBill;
    }
}