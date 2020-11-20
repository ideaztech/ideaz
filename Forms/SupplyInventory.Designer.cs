namespace Solum
{
    partial class SupplyInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyInventory));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelFooterRigth = new System.Windows.Forms.Panel();
            this.buttonReceived = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonAdjustment = new System.Windows.Forms.Button();
            this.panelUnstagedProducts = new System.Windows.Forms.Panel();
            this.listViewUnstagedProducts = new SirLib.ListViewModificada();
            this.label1 = new System.Windows.Forms.Label();
            this.panelUnstagedProductsTotals = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUnstagedTotalQuantity = new System.Windows.Forms.Label();
            this.panelFooterLeft = new System.Windows.Forms.Panel();
            this.checkBoxDates = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.checkBoxShowZeros = new System.Windows.Forms.CheckBox();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelServerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelToday = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTrainingMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonInventory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLogOff = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.dataSetSuppyInventoryByDate = new Solum.DataSetSuppyInventoryByDate();
            this.sol_SupplyInventory_ByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sol_SupplyInventory_ByDateTableAdapter = new Solum.DataSetSuppyInventoryByDateTableAdapters.sol_SupplyInventory_ByDateTableAdapter();
            this.tableAdapterManager = new Solum.DataSetSuppyInventoryByDateTableAdapters.TableAdapterManager();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFooterRigth.SuspendLayout();
            this.panelUnstagedProducts.SuspendLayout();
            this.panelUnstagedProductsTotals.SuspendLayout();
            this.panelFooterLeft.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSuppyInventoryByDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_SupplyInventory_ByDateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelFooterRigth, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelUnstagedProducts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelUnstagedProductsTotals, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelFooterLeft, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.75969F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.24031F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(867, 663);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panelFooterRigth
            // 
            this.panelFooterRigth.Controls.Add(this.buttonReceived);
            this.panelFooterRigth.Controls.Add(this.Cancel);
            this.panelFooterRigth.Controls.Add(this.buttonAdjustment);
            this.panelFooterRigth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFooterRigth.Location = new System.Drawing.Point(438, 593);
            this.panelFooterRigth.Name = "panelFooterRigth";
            this.panelFooterRigth.Size = new System.Drawing.Size(423, 64);
            this.panelFooterRigth.TabIndex = 5;
            // 
            // buttonReceived
            // 
            this.buttonReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReceived.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReceived.Location = new System.Drawing.Point(161, 7);
            this.buttonReceived.Name = "buttonReceived";
            this.buttonReceived.Size = new System.Drawing.Size(129, 50);
            this.buttonReceived.TabIndex = 6;
            this.buttonReceived.Text = "&Received";
            this.buttonReceived.UseVisualStyleBackColor = true;
            this.buttonReceived.Click += new System.EventHandler(this.buttonReceived_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.Color.Red;
            this.Cancel.Location = new System.Drawing.Point(301, 7);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(101, 50);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "E&xit";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // buttonAdjustment
            // 
            this.buttonAdjustment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdjustment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAdjustment.Location = new System.Drawing.Point(21, 7);
            this.buttonAdjustment.Name = "buttonAdjustment";
            this.buttonAdjustment.Size = new System.Drawing.Size(129, 50);
            this.buttonAdjustment.TabIndex = 4;
            this.buttonAdjustment.Text = "&Adjustment";
            this.buttonAdjustment.UseVisualStyleBackColor = true;
            this.buttonAdjustment.Click += new System.EventHandler(this.buttonAdjustment_Click);
            // 
            // panelUnstagedProducts
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelUnstagedProducts, 2);
            this.panelUnstagedProducts.Controls.Add(this.listViewUnstagedProducts);
            this.panelUnstagedProducts.Controls.Add(this.label1);
            this.panelUnstagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProducts.Location = new System.Drawing.Point(6, 6);
            this.panelUnstagedProducts.Name = "panelUnstagedProducts";
            this.panelUnstagedProducts.Size = new System.Drawing.Size(855, 510);
            this.panelUnstagedProducts.TabIndex = 0;
            // 
            // listViewUnstagedProducts
            // 
            this.listViewUnstagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUnstagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUnstagedProducts.FullRowSelect = true;
            this.listViewUnstagedProducts.HideSelection = false;
            this.listViewUnstagedProducts.Location = new System.Drawing.Point(0, 25);
            this.listViewUnstagedProducts.Name = "listViewUnstagedProducts";
            this.listViewUnstagedProducts.Size = new System.Drawing.Size(855, 485);
            this.listViewUnstagedProducts.TabIndex = 2;
            this.listViewUnstagedProducts.UseCompatibleStateImageBehavior = false;
            this.listViewUnstagedProducts.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(855, 25);
            this.label1.TabIndex = 1;
            // 
            // panelUnstagedProductsTotals
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelUnstagedProductsTotals, 2);
            this.panelUnstagedProductsTotals.Controls.Add(this.label3);
            this.panelUnstagedProductsTotals.Controls.Add(this.labelUnstagedTotalQuantity);
            this.panelUnstagedProductsTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProductsTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProductsTotals.Location = new System.Drawing.Point(6, 525);
            this.panelUnstagedProductsTotals.Name = "panelUnstagedProductsTotals";
            this.panelUnstagedProductsTotals.Size = new System.Drawing.Size(855, 59);
            this.panelUnstagedProductsTotals.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Totals:";
            // 
            // labelUnstagedTotalQuantity
            // 
            this.labelUnstagedTotalQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnstagedTotalQuantity.Location = new System.Drawing.Point(135, 1);
            this.labelUnstagedTotalQuantity.Name = "labelUnstagedTotalQuantity";
            this.labelUnstagedTotalQuantity.Size = new System.Drawing.Size(128, 18);
            this.labelUnstagedTotalQuantity.TabIndex = 2;
            this.labelUnstagedTotalQuantity.Text = "0";
            this.labelUnstagedTotalQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelFooterLeft
            // 
            this.panelFooterLeft.Controls.Add(this.checkBoxDates);
            this.panelFooterLeft.Controls.Add(this.dateTimePickerTo);
            this.panelFooterLeft.Controls.Add(this.label5);
            this.panelFooterLeft.Controls.Add(this.label4);
            this.panelFooterLeft.Controls.Add(this.dateTimePickerFrom);
            this.panelFooterLeft.Controls.Add(this.checkBoxShowZeros);
            this.panelFooterLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFooterLeft.Location = new System.Drawing.Point(6, 593);
            this.panelFooterLeft.Name = "panelFooterLeft";
            this.panelFooterLeft.Size = new System.Drawing.Size(423, 64);
            this.panelFooterLeft.TabIndex = 4;
            // 
            // checkBoxDates
            // 
            this.checkBoxDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDates.Location = new System.Drawing.Point(10, 12);
            this.checkBoxDates.Name = "checkBoxDates";
            this.checkBoxDates.Size = new System.Drawing.Size(80, 44);
            this.checkBoxDates.TabIndex = 11;
            this.checkBoxDates.Text = "&Use dates";
            this.checkBoxDates.UseVisualStyleBackColor = true;
            this.checkBoxDates.CheckedChanged += new System.EventHandler(this.checkBoxDates_CheckedChanged);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Enabled = false;
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(171, 33);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(111, 23);
            this.dateTimePickerTo.TabIndex = 10;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(104, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "&To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(104, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "&From:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Enabled = false;
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(171, 5);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(111, 23);
            this.dateTimePickerFrom.TabIndex = 8;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // checkBoxShowZeros
            // 
            this.checkBoxShowZeros.AutoSize = true;
            this.checkBoxShowZeros.Enabled = false;
            this.checkBoxShowZeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowZeros.Location = new System.Drawing.Point(296, 21);
            this.checkBoxShowZeros.Name = "checkBoxShowZeros";
            this.checkBoxShowZeros.Size = new System.Drawing.Size(102, 21);
            this.checkBoxShowZeros.TabIndex = 6;
            this.checkBoxShowZeros.Text = "&Show Zeros";
            this.checkBoxShowZeros.UseVisualStyleBackColor = true;
            this.checkBoxShowZeros.CheckedChanged += new System.EventHandler(this.checkBoxShowZeros_CheckedChanged);
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelServer,
            this.toolStripStatusLabelServerName,
            this.toolStripStatusLabelDate,
            this.toolStripStatusLabelToday,
            this.toolStripStatusLabelTime,
            this.toolStripStatusLabelTimer,
            this.toolStripStatusLabelTrainingMode});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 691);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(867, 22);
            this.statusStripBottom.TabIndex = 9;
            this.statusStripBottom.Text = "statusStrip1";
            // 
            // toolStripStatusLabelServer
            // 
            this.toolStripStatusLabelServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabelServer.Name = "toolStripStatusLabelServer";
            this.toolStripStatusLabelServer.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabelServer.Text = "Server:";
            // 
            // toolStripStatusLabelServerName
            // 
            this.toolStripStatusLabelServerName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelServerName.Name = "toolStripStatusLabelServerName";
            this.toolStripStatusLabelServerName.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabelServerName.Text = "Not connected";
            // 
            // toolStripStatusLabelDate
            // 
            this.toolStripStatusLabelDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabelDate.Name = "toolStripStatusLabelDate";
            this.toolStripStatusLabelDate.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabelDate.Text = "Date:";
            // 
            // toolStripStatusLabelToday
            // 
            this.toolStripStatusLabelToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelToday.Name = "toolStripStatusLabelToday";
            this.toolStripStatusLabelToday.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelToday.Text = "Today";
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabelTime.Text = "Time:";
            this.toolStripStatusLabelTime.Visible = false;
            // 
            // toolStripStatusLabelTimer
            // 
            this.toolStripStatusLabelTimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelTimer.Name = "toolStripStatusLabelTimer";
            this.toolStripStatusLabelTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelTrainingMode
            // 
            this.toolStripStatusLabelTrainingMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelTrainingMode.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelTrainingMode.Name = "toolStripStatusLabelTrainingMode";
            this.toolStripStatusLabelTrainingMode.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabelTrainingMode.Text = "Training Mode!";
            this.toolStripStatusLabelTrainingMode.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonInventory,
            this.toolStripSeparator1,
            this.toolStripButtonLogOff,
            this.toolStripSeparator5,
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(867, 28);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonInventory
            // 
            this.toolStripButtonInventory.Checked = true;
            this.toolStripButtonInventory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonInventory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonInventory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInventory.Name = "toolStripButtonInventory";
            this.toolStripButtonInventory.Size = new System.Drawing.Size(146, 25);
            this.toolStripButtonInventory.Text = "Supply Inventory";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButtonLogOff
            // 
            this.toolStripButtonLogOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLogOff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonLogOff.Image = global::Solum.Properties.Resources.exit;
            this.toolStripButtonLogOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLogOff.Name = "toolStripButtonLogOff";
            this.toolStripButtonLogOff.Size = new System.Drawing.Size(70, 68);
            this.toolStripButtonLogOff.Text = "Log Off";
            this.toolStripButtonLogOff.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
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
            // dataSetSuppyInventoryByDate
            // 
            this.dataSetSuppyInventoryByDate.DataSetName = "DataSetSuppyInventoryByDate";
            this.dataSetSuppyInventoryByDate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_SupplyInventory_ByDateBindingSource
            // 
            this.sol_SupplyInventory_ByDateBindingSource.DataMember = "sol_SupplyInventory_ByDate";
            this.sol_SupplyInventory_ByDateBindingSource.DataSource = this.dataSetSuppyInventoryByDate;
            // 
            // sol_SupplyInventory_ByDateTableAdapter
            // 
            this.sol_SupplyInventory_ByDateTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetSuppyInventoryByDateTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // SupplyInventory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(867, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Supply Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SupplyInventory_FormClosing);
            this.Load += new System.EventHandler(this.SupplyInventory_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelFooterRigth.ResumeLayout(false);
            this.panelUnstagedProducts.ResumeLayout(false);
            this.panelUnstagedProductsTotals.ResumeLayout(false);
            this.panelUnstagedProductsTotals.PerformLayout();
            this.panelFooterLeft.ResumeLayout(false);
            this.panelFooterLeft.PerformLayout();
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSuppyInventoryByDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_SupplyInventory_ByDateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelFooterRigth;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonAdjustment;
        private System.Windows.Forms.Panel panelUnstagedProducts;
        private SirLib.ListViewModificada listViewUnstagedProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelUnstagedProductsTotals;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUnstagedTotalQuantity;
        private System.Windows.Forms.Panel panelFooterLeft;
        private System.Windows.Forms.CheckBox checkBoxDates;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.CheckBox checkBoxShowZeros;
        private System.Windows.Forms.Button buttonReceived;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServerName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelToday;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrainingMode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonInventory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private DataSetSuppyInventoryByDate dataSetSuppyInventoryByDate;
        private System.Windows.Forms.BindingSource sol_SupplyInventory_ByDateBindingSource;
        private DataSetSuppyInventoryByDateTableAdapters.sol_SupplyInventory_ByDateTableAdapter sol_SupplyInventory_ByDateTableAdapter;
        private DataSetSuppyInventoryByDateTableAdapters.TableAdapterManager tableAdapterManager;
    }
}