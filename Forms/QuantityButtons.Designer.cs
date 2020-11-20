namespace Solum
{
    partial class QuantityButtons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantityButtons));
            this.dataSetCategoriesLookup = new Solum.DataSetCategoriesLookup();
            this.CategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonFont = new System.Windows.Forms.Button();
            this.WorkStationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetWorkStationsLookup = new Solum.DataSetWorkStationsLookup();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.sol_WorkStationsTableAdapter = new Solum.DataSetWorkStationsLookupTableAdapters.sol_WorkStationsTableAdapter();
            this.comboBoxWorkStation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.groupBoxQuantityButtonsDef = new System.Windows.Forms.GroupBox();
            this.panelQuantityButtons = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAddButton = new System.Windows.Forms.Button();
            this.Sol_CategoriesTableAdapter = new Solum.DataSetCategoriesLookupTableAdapters.Sol_CategoriesTableAdapter();
            this.textBoxDefaultQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCategoriesLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkStationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetWorkStationsLookup)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBoxQuantityButtonsDef.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSetCategoriesLookup
            // 
            this.dataSetCategoriesLookup.DataSetName = "DataSetCategoriesLookup";
            this.dataSetCategoriesLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CategoriesBindingSource
            // 
            this.CategoriesBindingSource.DataMember = "Sol_Categories";
            this.CategoriesBindingSource.DataSource = this.dataSetCategoriesLookup;
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(112, 148);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(53, 30);
            this.buttonFont.TabIndex = 18;
            this.buttonFont.Text = "...";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // WorkStationsBindingSource
            // 
            this.WorkStationsBindingSource.DataMember = "sol_WorkStations";
            this.WorkStationsBindingSource.DataSource = this.dataSetWorkStationsLookup;
            // 
            // dataSetWorkStationsLookup
            // 
            this.dataSetWorkStationsLookup.DataSetName = "DataSetWorkStationsLookup";
            this.dataSetWorkStationsLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "WorkStation:";
            // 
            // sol_WorkStationsTableAdapter
            // 
            this.sol_WorkStationsTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxWorkStation
            // 
            this.comboBoxWorkStation.DataSource = this.WorkStationsBindingSource;
            this.comboBoxWorkStation.DisplayMember = "Name";
            this.comboBoxWorkStation.FormattingEnabled = true;
            this.comboBoxWorkStation.Location = new System.Drawing.Point(112, 18);
            this.comboBoxWorkStation.Name = "comboBoxWorkStation";
            this.comboBoxWorkStation.Size = new System.Drawing.Size(166, 21);
            this.comboBoxWorkStation.TabIndex = 7;
            this.comboBoxWorkStation.ValueMember = "WorkStationID";
            this.comboBoxWorkStation.SelectedIndexChanged += new System.EventHandler(this.comboBoxWorkStation_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "&Font:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.comboBoxWorkStation);
            this.groupBox6.Location = new System.Drawing.Point(14, 66);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(325, 60);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(288, 24);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(101, 69);
            this.buttonDefault.TabIndex = 8;
            this.buttonDefault.Text = "&Default values";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // groupBoxQuantityButtonsDef
            // 
            this.groupBoxQuantityButtonsDef.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxQuantityButtonsDef.Controls.Add(this.panelQuantityButtons);
            this.groupBoxQuantityButtonsDef.Location = new System.Drawing.Point(573, 66);
            this.groupBoxQuantityButtonsDef.Name = "groupBoxQuantityButtonsDef";
            this.groupBoxQuantityButtonsDef.Size = new System.Drawing.Size(146, 503);
            this.groupBoxQuantityButtonsDef.TabIndex = 25;
            this.groupBoxQuantityButtonsDef.TabStop = false;
            // 
            // panelQuantityButtons
            // 
            this.panelQuantityButtons.AutoScroll = true;
            this.panelQuantityButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuantityButtons.Location = new System.Drawing.Point(3, 16);
            this.panelQuantityButtons.Name = "panelQuantityButtons";
            this.panelQuantityButtons.Size = new System.Drawing.Size(140, 484);
            this.panelQuantityButtons.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDefault);
            this.groupBox3.Controls.Add(this.Cancel);
            this.groupBox3.Controls.Add(this.buttonSave);
            this.groupBox3.Controls.Add(this.buttonDelete);
            this.groupBox3.Location = new System.Drawing.Point(345, 603);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(532, 113);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(406, 23);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(101, 69);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "&Exit";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(154, 24);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(101, 69);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(27, 22);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(101, 69);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAddButton);
            this.groupBox2.Location = new System.Drawing.Point(14, 603);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 113);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // buttonAddButton
            // 
            this.buttonAddButton.Location = new System.Drawing.Point(112, 22);
            this.buttonAddButton.Name = "buttonAddButton";
            this.buttonAddButton.Size = new System.Drawing.Size(101, 69);
            this.buttonAddButton.TabIndex = 4;
            this.buttonAddButton.Text = "Add &Button";
            this.buttonAddButton.UseVisualStyleBackColor = true;
            this.buttonAddButton.Click += new System.EventHandler(this.buttonAddButton_Click);
            // 
            // Sol_CategoriesTableAdapter
            // 
            this.Sol_CategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxDefaultQuantity
            // 
            this.textBoxDefaultQuantity.Location = new System.Drawing.Point(112, 108);
            this.textBoxDefaultQuantity.Name = "textBoxDefaultQuantity";
            this.textBoxDefaultQuantity.Size = new System.Drawing.Size(100, 20);
            this.textBoxDefaultQuantity.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Quantity:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonFont);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxDefaultQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 472);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(112, 64);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(187, 20);
            this.textBoxDescription.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVirtualKb,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(891, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonVirtualKb
            // 
            this.toolStripButtonVirtualKb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonVirtualKb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVirtualKb.Image = global::Solum.Properties.Resources.kxkb;
            this.toolStripButtonVirtualKb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVirtualKb.Name = "toolStripButtonVirtualKb";
            this.toolStripButtonVirtualKb.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonVirtualKb.Text = "Virtual Keyboard";
            this.toolStripButtonVirtualKb.Visible = false;
            this.toolStripButtonVirtualKb.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(262, 22);
            this.toolStripLabel1.Text = "Retail Purchase Quantity Buttons";
            // 
            // QuantityButtons
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(891, 723);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBoxQuantityButtonsDef);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuantityButtons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QuantityButtons";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuantityButtons_FormClosing);
            this.Load += new System.EventHandler(this.QuantityButtons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCategoriesLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkStationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetWorkStationsLookup)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBoxQuantityButtonsDef.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetCategoriesLookup dataSetCategoriesLookup;
        private System.Windows.Forms.BindingSource CategoriesBindingSource;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.BindingSource WorkStationsBindingSource;
        private DataSetWorkStationsLookup dataSetWorkStationsLookup;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label1;
        private Solum.DataSetWorkStationsLookupTableAdapters.sol_WorkStationsTableAdapter sol_WorkStationsTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxWorkStation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.GroupBox groupBoxQuantityButtonsDef;
        private System.Windows.Forms.Panel panelQuantityButtons;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAddButton;
        private Solum.DataSetCategoriesLookupTableAdapters.Sol_CategoriesTableAdapter Sol_CategoriesTableAdapter;
        private System.Windows.Forms.TextBox textBoxDefaultQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}