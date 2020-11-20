namespace Solum
{
    partial class CustomerOrdersPayNow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerOrdersPayNow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotalSelectedOrders = new System.Windows.Forms.Label();
            this.panelOrders = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.radioButtonCashTray = new System.Windows.Forms.RadioButton();
            this.radioButtonCheckNumber = new System.Windows.Forms.RadioButton();
            this.textBoxReference = new System.Windows.Forms.TextBox();
            this.comboBoxCashTray = new System.Windows.Forms.ComboBox();
            this.solCashTraysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetCashTraysLookup = new Solum.DataSetCashTraysLookup();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonReOpenDrawer = new System.Windows.Forms.Button();
            this.buttonRePrint = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.sol_CashTraysTableAdapter = new Solum.DataSetCashTraysLookupTableAdapters.sol_CashTraysTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solCashTraysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTraysLookup)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.02883F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.97117F));
            this.tableLayoutPanel1.Controls.Add(this.labelTotalSelectedOrders, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelOrders, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 485);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelTotalSelectedOrders
            // 
            this.labelTotalSelectedOrders.BackColor = System.Drawing.Color.Black;
            this.labelTotalSelectedOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalSelectedOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalSelectedOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSelectedOrders.ForeColor = System.Drawing.Color.Lime;
            this.labelTotalSelectedOrders.Location = new System.Drawing.Point(360, 371);
            this.labelTotalSelectedOrders.Name = "labelTotalSelectedOrders";
            this.labelTotalSelectedOrders.Size = new System.Drawing.Size(238, 111);
            this.labelTotalSelectedOrders.TabIndex = 5;
            this.labelTotalSelectedOrders.Text = "Amount:";
            // 
            // panelOrders
            // 
            this.panelOrders.Controls.Add(this.label1);
            this.panelOrders.Controls.Add(this.listView1);
            this.panelOrders.Controls.Add(this.radioButtonCashTray);
            this.panelOrders.Controls.Add(this.radioButtonCheckNumber);
            this.panelOrders.Controls.Add(this.textBoxReference);
            this.panelOrders.Controls.Add(this.comboBoxCashTray);
            this.panelOrders.Controls.Add(this.textBoxCheckNumber);
            this.panelOrders.Controls.Add(this.label2);
            this.panelOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrders.Location = new System.Drawing.Point(6, 6);
            this.panelOrders.Name = "panelOrders";
            this.tableLayoutPanel1.SetRowSpan(this.panelOrders, 2);
            this.panelOrders.Size = new System.Drawing.Size(345, 473);
            this.panelOrders.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Orders to pay:";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 294);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(333, 176);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // radioButtonCashTray
            // 
            this.radioButtonCashTray.AutoSize = true;
            this.radioButtonCashTray.Location = new System.Drawing.Point(34, 120);
            this.radioButtonCashTray.Name = "radioButtonCashTray";
            this.radioButtonCashTray.Size = new System.Drawing.Size(76, 17);
            this.radioButtonCashTray.TabIndex = 7;
            this.radioButtonCashTray.TabStop = true;
            this.radioButtonCashTray.Text = "&Cash Tray:";
            this.radioButtonCashTray.UseVisualStyleBackColor = true;
            this.radioButtonCashTray.CheckedChanged += new System.EventHandler(this.radioButtonCheckNumber_CheckedChanged);
            // 
            // radioButtonCheckNumber
            // 
            this.radioButtonCheckNumber.AutoSize = true;
            this.radioButtonCheckNumber.Location = new System.Drawing.Point(34, 22);
            this.radioButtonCheckNumber.Name = "radioButtonCheckNumber";
            this.radioButtonCheckNumber.Size = new System.Drawing.Size(99, 17);
            this.radioButtonCheckNumber.TabIndex = 6;
            this.radioButtonCheckNumber.TabStop = true;
            this.radioButtonCheckNumber.Text = "&Check Number:";
            this.radioButtonCheckNumber.UseVisualStyleBackColor = true;
            this.radioButtonCheckNumber.CheckedChanged += new System.EventHandler(this.radioButtonCheckNumber_CheckedChanged);
            // 
            // textBoxReference
            // 
            this.textBoxReference.Location = new System.Drawing.Point(57, 227);
            this.textBoxReference.Name = "textBoxReference";
            this.textBoxReference.Size = new System.Drawing.Size(224, 20);
            this.textBoxReference.TabIndex = 5;
            // 
            // comboBoxCashTray
            // 
            this.comboBoxCashTray.DataSource = this.solCashTraysBindingSource;
            this.comboBoxCashTray.DisplayMember = "Description";
            this.comboBoxCashTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCashTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCashTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCashTray.FormattingEnabled = true;
            this.comboBoxCashTray.Location = new System.Drawing.Point(57, 158);
            this.comboBoxCashTray.Name = "comboBoxCashTray";
            this.comboBoxCashTray.Size = new System.Drawing.Size(224, 21);
            this.comboBoxCashTray.TabIndex = 4;
            this.comboBoxCashTray.ValueMember = "CashTrayID";
            // 
            // solCashTraysBindingSource
            // 
            this.solCashTraysBindingSource.DataMember = "sol_CashTrays";
            this.solCashTraysBindingSource.DataSource = this.dataSetCashTraysLookup;
            // 
            // dataSetCashTraysLookup
            // 
            this.dataSetCashTraysLookup.DataSetName = "DataSetCashTraysLookup";
            this.dataSetCashTraysLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCheckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCheckNumber.Location = new System.Drawing.Point(57, 60);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(224, 19);
            this.textBoxCheckNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Reference:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonContinue);
            this.panelButtons.Controls.Add(this.buttonReOpenDrawer);
            this.panelButtons.Controls.Add(this.buttonRePrint);
            this.panelButtons.Controls.Add(this.Cancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(360, 6);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(238, 359);
            this.panelButtons.TabIndex = 0;
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(55, 26);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(121, 61);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "&Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonReOpenDrawer
            // 
            this.buttonReOpenDrawer.Enabled = false;
            this.buttonReOpenDrawer.Location = new System.Drawing.Point(55, 184);
            this.buttonReOpenDrawer.Name = "buttonReOpenDrawer";
            this.buttonReOpenDrawer.Size = new System.Drawing.Size(121, 61);
            this.buttonReOpenDrawer.TabIndex = 2;
            this.buttonReOpenDrawer.Text = "&ReOpen Drawer";
            this.buttonReOpenDrawer.UseVisualStyleBackColor = true;
            this.buttonReOpenDrawer.Click += new System.EventHandler(this.buttonReOpenDrawer_Click);
            // 
            // buttonRePrint
            // 
            this.buttonRePrint.Enabled = false;
            this.buttonRePrint.Location = new System.Drawing.Point(55, 105);
            this.buttonRePrint.Name = "buttonRePrint";
            this.buttonRePrint.Size = new System.Drawing.Size(121, 61);
            this.buttonRePrint.TabIndex = 1;
            this.buttonRePrint.Text = "&Print Receipt";
            this.buttonRePrint.UseVisualStyleBackColor = true;
            this.buttonRePrint.Click += new System.EventHandler(this.buttonRePrint_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(55, 269);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(121, 61);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "&Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(604, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // toolStripButtonVirtualKb
            // 
            this.toolStripButtonVirtualKb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonVirtualKb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVirtualKb.Image = global::Solum.Properties.Resources.kxkb;
            this.toolStripButtonVirtualKb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVirtualKb.Name = "toolStripButtonVirtualKb";
            this.toolStripButtonVirtualKb.Size = new System.Drawing.Size(68, 68);
            this.toolStripButtonVirtualKb.Text = "Virtual Keyboard";
            this.toolStripButtonVirtualKb.Visible = false;
            this.toolStripButtonVirtualKb.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // sol_CashTraysTableAdapter
            // 
            this.sol_CashTraysTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerOrdersPayNow
            // 
            this.AcceptButton = this.buttonContinue;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(604, 541);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerOrdersPayNow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pay Now";
            this.Load += new System.EventHandler(this.CustomerOrdersPayNow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelOrders.ResumeLayout(false);
            this.panelOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solCashTraysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTraysLookup)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTotalSelectedOrders;
        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonReOpenDrawer;
        private System.Windows.Forms.Button buttonRePrint;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxReference;
        private System.Windows.Forms.ComboBox comboBoxCashTray;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.RadioButton radioButtonCashTray;
        private System.Windows.Forms.RadioButton radioButtonCheckNumber;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DataSetCashTraysLookup dataSetCashTraysLookup;
        private System.Windows.Forms.BindingSource solCashTraysBindingSource;
        private DataSetCashTraysLookupTableAdapters.sol_CashTraysTableAdapter sol_CashTraysTableAdapter;
    }
}