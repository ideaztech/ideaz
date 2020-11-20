namespace Solum
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.statusStripTop = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonInventory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLogOff = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelServerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelToday = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTrainingMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.bindingSourceProductsUnstaged = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetProductsUnstaged = new Solum.DataSetProductsUnstaged();
            this.sol_Products_SelectAllUnstagedTableAdapter = new Solum.DataSetProductsUnstagedTableAdapters.sol_Products_SelectAllUnstagedTableAdapter();
            this.bindingSourceProductsStaged = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetProductsStaged = new Solum.DataSetProductsStaged();
            this.sol_Products_SelectAllStagedTableAdapter = new Solum.DataSetProductsStagedTableAdapters.sol_Products_SelectAllStagedTableAdapter();
            this.panelStagedProductsTotals = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelStagedTotalAmount = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.labelStagedTotalQuantity = new System.Windows.Forms.Label();
            this.buttonInventoryAdjustment = new System.Windows.Forms.Button();
            this.panelUnstagedProductsTotals = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUnstagedTotalAmount = new System.Windows.Forms.Label();
            this.checkBoxShowZeros = new System.Windows.Forms.CheckBox();
            this.labelUnstagedTotalQuantity = new System.Windows.Forms.Label();
            this.panelStagedProducts = new System.Windows.Forms.Panel();
            this.listViewStagedProducts = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelUnstagedProducts = new System.Windows.Forms.Panel();
            this.listViewUnstagedProducts = new SirLib.ListViewModificada();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStripTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductsUnstaged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsUnstaged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductsStaged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsStaged)).BeginInit();
            this.panelStagedProductsTotals.SuspendLayout();
            this.panelUnstagedProductsTotals.SuspendLayout();
            this.panelStagedProducts.SuspendLayout();
            this.panelUnstagedProducts.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripTop
            // 
            this.statusStripTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStripTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMessage,
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelWelcome});
            this.statusStripTop.Location = new System.Drawing.Point(0, 0);
            this.statusStripTop.Name = "statusStripTop";
            this.statusStripTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripTop.Size = new System.Drawing.Size(1006, 33);
            this.statusStripTop.TabIndex = 1;
            this.statusStripTop.Text = "statusStrip2";
            this.statusStripTop.Visible = false;
            // 
            // toolStripStatusLabelMessage
            // 
            this.toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            this.toolStripStatusLabelMessage.Size = new System.Drawing.Size(53, 28);
            this.toolStripStatusLabelMessage.Text = "Message";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(33, 28);
            this.toolStripStatusLabelUser.Text = "User";
            // 
            // toolStripStatusLabelWelcome
            // 
            this.toolStripStatusLabelWelcome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabelWelcome.Name = "toolStripStatusLabelWelcome";
            this.toolStripStatusLabelWelcome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabelWelcome.Size = new System.Drawing.Size(57, 28);
            this.toolStripStatusLabelWelcome.Text = "Welcome";
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
            this.toolStrip1.Size = new System.Drawing.Size(1006, 28);
            this.toolStrip1.TabIndex = 2;
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
            this.toolStripButtonInventory.Size = new System.Drawing.Size(89, 25);
            this.toolStripButtonInventory.Text = "Inventory";
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
            this.statusStripBottom.Size = new System.Drawing.Size(1006, 22);
            this.statusStripBottom.TabIndex = 6;
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
            // bindingSourceProductsUnstaged
            // 
            this.bindingSourceProductsUnstaged.DataMember = "sol_Products_SelectAllUnstaged";
            this.bindingSourceProductsUnstaged.DataSource = this.dataSetProductsUnstaged;
            // 
            // dataSetProductsUnstaged
            // 
            this.dataSetProductsUnstaged.DataSetName = "DataSetProductsUnstaged";
            this.dataSetProductsUnstaged.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_Products_SelectAllUnstagedTableAdapter
            // 
            this.sol_Products_SelectAllUnstagedTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSourceProductsStaged
            // 
            this.bindingSourceProductsStaged.DataMember = "sol_Products_SelectAllStaged";
            this.bindingSourceProductsStaged.DataSource = this.dataSetProductsStaged;
            // 
            // dataSetProductsStaged
            // 
            this.dataSetProductsStaged.DataSetName = "DataSetProductsStaged";
            this.dataSetProductsStaged.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_Products_SelectAllStagedTableAdapter
            // 
            this.sol_Products_SelectAllStagedTableAdapter.ClearBeforeFill = true;
            // 
            // panelStagedProductsTotals
            // 
            this.panelStagedProductsTotals.Controls.Add(this.buttonExit);
            this.panelStagedProductsTotals.Controls.Add(this.labelStagedTotalAmount);
            this.panelStagedProductsTotals.Controls.Add(this.buttonPrint);
            this.panelStagedProductsTotals.Controls.Add(this.labelStagedTotalQuantity);
            this.panelStagedProductsTotals.Controls.Add(this.buttonInventoryAdjustment);
            this.panelStagedProductsTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStagedProductsTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelStagedProductsTotals.Location = new System.Drawing.Point(506, 566);
            this.panelStagedProductsTotals.Name = "panelStagedProductsTotals";
            this.panelStagedProductsTotals.Size = new System.Drawing.Size(497, 94);
            this.panelStagedProductsTotals.TabIndex = 3;
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.Red;
            this.buttonExit.Location = new System.Drawing.Point(335, 31);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(129, 50);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // labelStagedTotalAmount
            // 
            this.labelStagedTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStagedTotalAmount.Location = new System.Drawing.Point(344, 1);
            this.labelStagedTotalAmount.Name = "labelStagedTotalAmount";
            this.labelStagedTotalAmount.Size = new System.Drawing.Size(128, 18);
            this.labelStagedTotalAmount.TabIndex = 5;
            this.labelStagedTotalAmount.Text = "0.00";
            this.labelStagedTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPrint.Location = new System.Drawing.Point(184, 31);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(129, 50);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "&Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // labelStagedTotalQuantity
            // 
            this.labelStagedTotalQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStagedTotalQuantity.Location = new System.Drawing.Point(139, 1);
            this.labelStagedTotalQuantity.Name = "labelStagedTotalQuantity";
            this.labelStagedTotalQuantity.Size = new System.Drawing.Size(128, 18);
            this.labelStagedTotalQuantity.TabIndex = 4;
            this.labelStagedTotalQuantity.Text = "0";
            this.labelStagedTotalQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonInventoryAdjustment
            // 
            this.buttonInventoryAdjustment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInventoryAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInventoryAdjustment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonInventoryAdjustment.Location = new System.Drawing.Point(33, 31);
            this.buttonInventoryAdjustment.Name = "buttonInventoryAdjustment";
            this.buttonInventoryAdjustment.Size = new System.Drawing.Size(129, 50);
            this.buttonInventoryAdjustment.TabIndex = 4;
            this.buttonInventoryAdjustment.Text = "&Create Adjustment";
            this.buttonInventoryAdjustment.UseVisualStyleBackColor = true;
            this.buttonInventoryAdjustment.Click += new System.EventHandler(this.buttonInventoryAdjustment_Click);
            // 
            // panelUnstagedProductsTotals
            // 
            this.panelUnstagedProductsTotals.Controls.Add(this.label5);
            this.panelUnstagedProductsTotals.Controls.Add(this.dateTimePickerTo);
            this.panelUnstagedProductsTotals.Controls.Add(this.label3);
            this.panelUnstagedProductsTotals.Controls.Add(this.labelUnstagedTotalAmount);
            this.panelUnstagedProductsTotals.Controls.Add(this.checkBoxShowZeros);
            this.panelUnstagedProductsTotals.Controls.Add(this.labelUnstagedTotalQuantity);
            this.panelUnstagedProductsTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProductsTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProductsTotals.Location = new System.Drawing.Point(3, 566);
            this.panelUnstagedProductsTotals.Name = "panelUnstagedProductsTotals";
            this.panelUnstagedProductsTotals.Size = new System.Drawing.Size(497, 94);
            this.panelUnstagedProductsTotals.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "&Show Inventory On:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(169, 43);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(111, 23);
            this.dateTimePickerTo.TabIndex = 10;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
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
            // labelUnstagedTotalAmount
            // 
            this.labelUnstagedTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnstagedTotalAmount.Location = new System.Drawing.Point(340, 1);
            this.labelUnstagedTotalAmount.Name = "labelUnstagedTotalAmount";
            this.labelUnstagedTotalAmount.Size = new System.Drawing.Size(128, 18);
            this.labelUnstagedTotalAmount.TabIndex = 3;
            this.labelUnstagedTotalAmount.Text = "0.00";
            this.labelUnstagedTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxShowZeros
            // 
            this.checkBoxShowZeros.AutoSize = true;
            this.checkBoxShowZeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowZeros.Location = new System.Drawing.Point(320, 43);
            this.checkBoxShowZeros.Name = "checkBoxShowZeros";
            this.checkBoxShowZeros.Size = new System.Drawing.Size(102, 21);
            this.checkBoxShowZeros.TabIndex = 6;
            this.checkBoxShowZeros.Text = "&Show Zeros";
            this.checkBoxShowZeros.UseVisualStyleBackColor = true;
            this.checkBoxShowZeros.CheckedChanged += new System.EventHandler(this.checkBoxShowZeros_CheckedChanged);
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
            // panelStagedProducts
            // 
            this.panelStagedProducts.Controls.Add(this.listViewStagedProducts);
            this.panelStagedProducts.Controls.Add(this.label2);
            this.panelStagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelStagedProducts.Location = new System.Drawing.Point(506, 3);
            this.panelStagedProducts.Name = "panelStagedProducts";
            this.panelStagedProducts.Size = new System.Drawing.Size(497, 557);
            this.panelStagedProducts.TabIndex = 1;
            // 
            // listViewStagedProducts
            // 
            this.listViewStagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewStagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewStagedProducts.HideSelection = false;
            this.listViewStagedProducts.Location = new System.Drawing.Point(0, 20);
            this.listViewStagedProducts.Name = "listViewStagedProducts";
            this.listViewStagedProducts.Size = new System.Drawing.Size(497, 537);
            this.listViewStagedProducts.TabIndex = 0;
            this.listViewStagedProducts.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Staged Products: (ncluding unshipped R-Bills)";
            // 
            // panelUnstagedProducts
            // 
            this.panelUnstagedProducts.Controls.Add(this.listViewUnstagedProducts);
            this.panelUnstagedProducts.Controls.Add(this.label1);
            this.panelUnstagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProducts.Location = new System.Drawing.Point(3, 3);
            this.panelUnstagedProducts.Name = "panelUnstagedProducts";
            this.panelUnstagedProducts.Size = new System.Drawing.Size(497, 557);
            this.panelUnstagedProducts.TabIndex = 0;
            // 
            // listViewUnstagedProducts
            // 
            this.listViewUnstagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUnstagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUnstagedProducts.FullRowSelect = true;
            this.listViewUnstagedProducts.HideSelection = false;
            this.listViewUnstagedProducts.Location = new System.Drawing.Point(0, 20);
            this.listViewUnstagedProducts.Name = "listViewUnstagedProducts";
            this.listViewUnstagedProducts.Size = new System.Drawing.Size(497, 537);
            this.listViewUnstagedProducts.TabIndex = 2;
            this.listViewUnstagedProducts.UseCompatibleStateImageBehavior = false;
            this.listViewUnstagedProducts.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unstaged Products:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelUnstagedProducts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelStagedProducts, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelUnstagedProductsTotals, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelStagedProductsTotals, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 663);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Inventory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(1006, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStripTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventory_FormClosing);
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.statusStripTop.ResumeLayout(false);
            this.statusStripTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductsUnstaged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsUnstaged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProductsStaged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsStaged)).EndInit();
            this.panelStagedProductsTotals.ResumeLayout(false);
            this.panelUnstagedProductsTotals.ResumeLayout(false);
            this.panelUnstagedProductsTotals.PerformLayout();
            this.panelStagedProducts.ResumeLayout(false);
            this.panelStagedProducts.PerformLayout();
            this.panelUnstagedProducts.ResumeLayout(false);
            this.panelUnstagedProducts.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripTop;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWelcome;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServerName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelToday;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimer;
        private System.Windows.Forms.BindingSource bindingSourceProductsUnstaged;
        private DataSetProductsUnstaged dataSetProductsUnstaged;
        private Solum.DataSetProductsUnstagedTableAdapters.sol_Products_SelectAllUnstagedTableAdapter sol_Products_SelectAllUnstagedTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceProductsStaged;
        private DataSetProductsStaged dataSetProductsStaged;
        private Solum.DataSetProductsStagedTableAdapters.sol_Products_SelectAllStagedTableAdapter sol_Products_SelectAllStagedTableAdapter;
        private System.Windows.Forms.ToolStripButton toolStripButtonInventory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrainingMode;
        private System.Windows.Forms.Panel panelStagedProductsTotals;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelStagedTotalAmount;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Label labelStagedTotalQuantity;
        private System.Windows.Forms.Button buttonInventoryAdjustment;
        private System.Windows.Forms.Panel panelUnstagedProductsTotals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUnstagedTotalAmount;
        private System.Windows.Forms.CheckBox checkBoxShowZeros;
        private System.Windows.Forms.Label labelUnstagedTotalQuantity;
        private System.Windows.Forms.Panel panelStagedProducts;
        private System.Windows.Forms.ListView listViewStagedProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelUnstagedProducts;
        private SirLib.ListViewModificada listViewUnstagedProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}