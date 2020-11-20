namespace Solum
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.buttonView = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.comboBoxOrderId = new System.Windows.Forms.ComboBox();
            this.bindingSourceOrdersLookup = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetOrdersLookup = new Solum.DataSetOrdersLookup();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.labelTax1 = new System.Windows.Forms.Label();
            this.bindingSourceFees = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetFees = new Solum.DataSetFees();
            this.labelTotalQty = new System.Windows.Forms.Label();
            this.labelTotalAmt = new System.Windows.Forms.Label();
            this.sol_Orders_SelectAllLookupTableAdapter = new Solum.DataSetOrdersLookupTableAdapters.sol_Orders_SelectAllLookupTableAdapter();
            this.sol_Fees_SelectAllTableAdapter = new Solum.DataSetFeesTableAdapters.sol_Fees_SelectAllTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1CurrentCashTray = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericTextBoxTax2Amount = new SirLib.NumericTextBox();
            this.labelTax2 = new System.Windows.Forms.Label();
            this.numericTextBoxTax1Amount = new SirLib.NumericTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonExtra = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.tableLayoutPanelView1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelNumericKb = new System.Windows.Forms.Panel();
            this.buttonNumericPad = new System.Windows.Forms.Button();
            this.panelQuantityButtons = new System.Windows.Forms.Panel();
            this.panelCategoryButtons = new System.Windows.Forms.Panel();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelServerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelToday = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTrainingMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCashier = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReturns = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSales = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLogOff = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonQdCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAttendance = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparatorQdCustomer = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.sol_ProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetProductsLookup = new Solum.DataSetProductsLookup();
            this.sol_ProductsTableAdapter = new Solum.DataSetProductsLookupTableAdapters.sol_ProductsTableAdapter();
            this.tableAdapterManager = new Solum.DataSetProductsLookupTableAdapters.TableAdapterManager();
            this.panel3 = new System.Windows.Forms.Panel();
            this.keyboardButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrdersLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetOrdersLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFees)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelView.SuspendLayout();
            this.tableLayoutPanelView1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelNumericKb.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsLookup)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(1006, 648);
            // 
            // buttonView
            // 
            this.buttonView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.buttonView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonView.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonView.Location = new System.Drawing.Point(324, 11);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(101, 61);
            this.buttonView.TabIndex = 5;
            this.buttonView.Text = "&Find";
            this.buttonView.UseVisualStyleBackColor = false;
            this.buttonView.EnabledChanged += new System.EventHandler(this.ButtonView_EnabledChanged);
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(116)))), ((int)(((byte)(85)))));
            this.buttonCancel.Enabled = false;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonCancel.Location = new System.Drawing.Point(217, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 61);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Visible = false;
            this.buttonCancel.EnabledChanged += new System.EventHandler(this.ButtonCancel_EnabledChanged);
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.buttonClose.Enabled = false;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonClose.Location = new System.Drawing.Point(110, 11);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(101, 61);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Visible = false;
            this.buttonClose.EnabledChanged += new System.EventHandler(this.ButtonClose_EnabledChanged);
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonNew.Location = new System.Drawing.Point(3, 11);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(101, 61);
            this.buttonNew.TabIndex = 0;
            this.buttonNew.Text = "&New";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.EnabledChanged += new System.EventHandler(this.ButtonNew_EnabledChanged);
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // comboBoxOrderId
            // 
            this.comboBoxOrderId.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxOrderId.DataSource = this.bindingSourceOrdersLookup;
            this.comboBoxOrderId.DisplayMember = "displayMember";
            this.comboBoxOrderId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxOrderId.Enabled = false;
            this.comboBoxOrderId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOrderId.FormattingEnabled = true;
            this.comboBoxOrderId.Location = new System.Drawing.Point(71, 9);
            this.comboBoxOrderId.Name = "comboBoxOrderId";
            this.comboBoxOrderId.Size = new System.Drawing.Size(180, 26);
            this.comboBoxOrderId.TabIndex = 6;
            this.comboBoxOrderId.ValueMember = "OrderID";
            this.comboBoxOrderId.DropDown += new System.EventHandler(this.comboBoxOrderId_DropDown);
            this.comboBoxOrderId.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderId_SelectedIndexChanged);
            // 
            // bindingSourceOrdersLookup
            // 
            this.bindingSourceOrdersLookup.DataMember = "sol_Orders_SelectAllLookup";
            this.bindingSourceOrdersLookup.DataSource = this.dataSetOrdersLookup;
            // 
            // dataSetOrdersLookup
            // 
            this.dataSetOrdersLookup.DataSetName = "DataSetOrdersLookup";
            this.dataSetOrdersLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(116)))), ((int)(((byte)(85)))));
            this.buttonDeleteRow.Enabled = false;
            this.buttonDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteRow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonDeleteRow.Location = new System.Drawing.Point(150, 41);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(101, 51);
            this.buttonDeleteRow.TabIndex = 1;
            this.buttonDeleteRow.Text = "&Delete Row";
            this.buttonDeleteRow.UseVisualStyleBackColor = false;
            this.buttonDeleteRow.Visible = false;
            this.buttonDeleteRow.EnabledChanged += new System.EventHandler(this.ButtonDeleteRow_EnabledChanged);
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderNumber.Location = new System.Drawing.Point(4, 12);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(61, 17);
            this.labelOrderNumber.TabIndex = 0;
            this.labelOrderNumber.Text = "Order #:";
            this.labelOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 109);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(308, 343);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // labelTax1
            // 
            this.labelTax1.AutoSize = true;
            this.labelTax1.Location = new System.Drawing.Point(10, 11);
            this.labelTax1.Name = "labelTax1";
            this.labelTax1.Size = new System.Drawing.Size(43, 17);
            this.labelTax1.TabIndex = 1;
            this.labelTax1.Text = "Tax1:";
            // 
            // bindingSourceFees
            // 
            this.bindingSourceFees.DataMember = "sol_Fees_SelectAll";
            this.bindingSourceFees.DataSource = this.dataSetFees;
            // 
            // dataSetFees
            // 
            this.dataSetFees.DataSetName = "DataSetFees";
            this.dataSetFees.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelTotalQty
            // 
            this.labelTotalQty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalQty.Location = new System.Drawing.Point(3, 92);
            this.labelTotalQty.Name = "labelTotalQty";
            this.labelTotalQty.Size = new System.Drawing.Size(169, 24);
            this.labelTotalQty.TabIndex = 0;
            this.labelTotalQty.Text = "Quantity:";
            // 
            // labelTotalAmt
            // 
            this.labelTotalAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.labelTotalAmt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmt.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTotalAmt.Location = new System.Drawing.Point(3, 123);
            this.labelTotalAmt.Name = "labelTotalAmt";
            this.labelTotalAmt.Size = new System.Drawing.Size(155, 24);
            this.labelTotalAmt.TabIndex = 1;
            this.labelTotalAmt.Text = "Amount:";
            // 
            // sol_Orders_SelectAllLookupTableAdapter
            // 
            this.sol_Orders_SelectAllLookupTableAdapter.ClearBeforeFill = true;
            // 
            // sol_Fees_SelectAllTableAdapter
            // 
            this.sol_Fees_SelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelView, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(79, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 621);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(314, 615);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1CurrentCashTray);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.labelOrderNumber);
            this.panel1.Controls.Add(this.buttonDeleteRow);
            this.panel1.Controls.Add(this.comboBoxOrderId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1CurrentCashTray
            // 
            this.label1CurrentCashTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1CurrentCashTray.Location = new System.Drawing.Point(10, 72);
            this.label1CurrentCashTray.Name = "label1CurrentCashTray";
            this.label1CurrentCashTray.Size = new System.Drawing.Size(102, 20);
            this.label1CurrentCashTray.TabIndex = 10;
            this.label1CurrentCashTray.Text = "<Undefined>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Current CashTray:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericTextBoxTax2Amount);
            this.panel2.Controls.Add(this.labelTax2);
            this.panel2.Controls.Add(this.numericTextBoxTax1Amount);
            this.panel2.Controls.Add(this.labelTotalAmt);
            this.panel2.Controls.Add(this.labelTotalQty);
            this.panel2.Controls.Add(this.labelTax1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 458);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 154);
            this.panel2.TabIndex = 1;
            // 
            // numericTextBoxTax2Amount
            // 
            this.numericTextBoxTax2Amount.AllowSpace = false;
            this.numericTextBoxTax2Amount.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxTax2Amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericTextBoxTax2Amount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTextBoxTax2Amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.numericTextBoxTax2Amount.Location = new System.Drawing.Point(59, 44);
            this.numericTextBoxTax2Amount.Name = "numericTextBoxTax2Amount";
            this.numericTextBoxTax2Amount.Size = new System.Drawing.Size(165, 15);
            this.numericTextBoxTax2Amount.TabIndex = 4;
            // 
            // labelTax2
            // 
            this.labelTax2.AutoSize = true;
            this.labelTax2.Location = new System.Drawing.Point(10, 44);
            this.labelTax2.Name = "labelTax2";
            this.labelTax2.Size = new System.Drawing.Size(43, 17);
            this.labelTax2.TabIndex = 3;
            this.labelTax2.Text = "Tax2:";
            // 
            // numericTextBoxTax1Amount
            // 
            this.numericTextBoxTax1Amount.AllowSpace = false;
            this.numericTextBoxTax1Amount.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxTax1Amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericTextBoxTax1Amount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTextBoxTax1Amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.numericTextBoxTax1Amount.Location = new System.Drawing.Point(59, 8);
            this.numericTextBoxTax1Amount.Name = "numericTextBoxTax1Amount";
            this.numericTextBoxTax1Amount.Size = new System.Drawing.Size(165, 15);
            this.numericTextBoxTax1Amount.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonView);
            this.panel4.Controls.Add(this.buttonNew);
            this.panel4.Controls.Add(this.buttonCancel);
            this.panel4.Controls.Add(this.buttonClose);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(323, 536);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(464, 82);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonExtra);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(793, 536);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(178, 82);
            this.panel5.TabIndex = 4;
            // 
            // buttonExtra
            // 
            this.buttonExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.buttonExtra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExtra.Enabled = false;
            this.buttonExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExtra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonExtra.Location = new System.Drawing.Point(7, 11);
            this.buttonExtra.Name = "buttonExtra";
            this.buttonExtra.Size = new System.Drawing.Size(101, 61);
            this.buttonExtra.TabIndex = 4;
            this.buttonExtra.Text = "C&ash Out";
            this.buttonExtra.UseVisualStyleBackColor = false;
            this.buttonExtra.Visible = false;
            this.buttonExtra.EnabledChanged += new System.EventHandler(this.ButtonExtra_EnabledChanged);
            this.buttonExtra.Click += new System.EventHandler(this.buttonExtra_Click);
            // 
            // panelView
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelView, 2);
            this.panelView.Controls.Add(this.tableLayoutPanelView1);
            this.panelView.Enabled = false;
            this.panelView.Location = new System.Drawing.Point(323, 3);
            this.panelView.Name = "panelView";
            this.tableLayoutPanel1.SetRowSpan(this.panelView, 2);
            this.panelView.Size = new System.Drawing.Size(648, 517);
            this.panelView.TabIndex = 5;
            // 
            // tableLayoutPanelView1
            // 
            this.tableLayoutPanelView1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanelView1.ColumnCount = 2;
            this.tableLayoutPanelView1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 491F));
            this.tableLayoutPanelView1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanelView1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanelView1.Controls.Add(this.panelCategoryButtons, 0, 0);
            this.tableLayoutPanelView1.Location = new System.Drawing.Point(14, 15);
            this.tableLayoutPanelView1.Name = "tableLayoutPanelView1";
            this.tableLayoutPanelView1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tableLayoutPanelView1.RowCount = 1;
            this.tableLayoutPanelView1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelView1.Size = new System.Drawing.Size(557, 349);
            this.tableLayoutPanelView1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panelNumericKb, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelQuantityButtons, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(494, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(115, 338);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panelNumericKb
            // 
            this.panelNumericKb.Controls.Add(this.buttonNumericPad);
            this.panelNumericKb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNumericKb.Location = new System.Drawing.Point(3, 251);
            this.panelNumericKb.Name = "panelNumericKb";
            this.panelNumericKb.Size = new System.Drawing.Size(109, 84);
            this.panelNumericKb.TabIndex = 1;
            // 
            // buttonNumericPad
            // 
            this.buttonNumericPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNumericPad.Location = new System.Drawing.Point(8, 11);
            this.buttonNumericPad.Name = "buttonNumericPad";
            this.buttonNumericPad.Size = new System.Drawing.Size(93, 61);
            this.buttonNumericPad.TabIndex = 1;
            this.buttonNumericPad.Text = "N&umeric Pad";
            this.buttonNumericPad.UseVisualStyleBackColor = true;
            // 
            // panelQuantityButtons
            // 
            this.panelQuantityButtons.AutoScroll = true;
            this.panelQuantityButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuantityButtons.Location = new System.Drawing.Point(3, 3);
            this.panelQuantityButtons.Name = "panelQuantityButtons";
            this.panelQuantityButtons.Size = new System.Drawing.Size(109, 242);
            this.panelQuantityButtons.TabIndex = 0;
            // 
            // panelCategoryButtons
            // 
            this.panelCategoryButtons.AutoScroll = true;
            this.panelCategoryButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCategoryButtons.Location = new System.Drawing.Point(3, 8);
            this.panelCategoryButtons.Name = "panelCategoryButtons";
            this.panelCategoryButtons.Size = new System.Drawing.Size(485, 338);
            this.panelCategoryButtons.TabIndex = 0;
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.statusStripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelUserName,
            this.toolStripStatusLabelServer,
            this.toolStripStatusLabelServerName,
            this.toolStripStatusLabelDate,
            this.toolStripStatusLabelToday,
            this.toolStripStatusLabelTime,
            this.toolStripStatusLabelTimer,
            this.toolStripStatusLabelTrainingMode});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 691);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1046, 22);
            this.statusStripBottom.SizingGrip = false;
            this.statusStripBottom.TabIndex = 10;
            this.statusStripBottom.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(30, 17);
            this.toolStripStatusLabelUser.Text = "User";
            // 
            // toolStripStatusLabelUserName
            // 
            this.toolStripStatusLabelUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelUserName.Name = "toolStripStatusLabelUserName";
            this.toolStripStatusLabelUserName.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabelUserName.Text = "UserName";
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
            // 
            // toolStripStatusLabelTimer
            // 
            this.toolStripStatusLabelTimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelTimer.Name = "toolStripStatusLabelTimer";
            this.toolStripStatusLabelTimer.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabelTimer.Text = "Time";
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
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCashier,
            this.toolStripButtonReturns,
            this.toolStripButtonSales,
            this.toolStripButtonLogOff,
            this.toolStripButtonQdCustomer,
            this.toolStripButtonExit,
            this.toolStripButtonAttendance,
            this.toolStripButtonVirtualKb});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(76, 691);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonCashier
            // 
            this.toolStripButtonCashier.AutoSize = false;
            this.toolStripButtonCashier.BackgroundImage = global::Solum.Properties.Resources.solumcashier;
            this.toolStripButtonCashier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonCashier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButtonCashier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonCashier.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButtonCashier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCashier.Name = "toolStripButtonCashier";
            this.toolStripButtonCashier.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonCashier.Text = "Cashier";
            this.toolStripButtonCashier.Click += new System.EventHandler(this.toolStripButtonCashier_Click);
            // 
            // toolStripButtonReturns
            // 
            this.toolStripButtonReturns.AutoSize = false;
            this.toolStripButtonReturns.BackgroundImage = global::Solum.Properties.Resources.returnsgreen;
            this.toolStripButtonReturns.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonReturns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButtonReturns.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonReturns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReturns.Name = "toolStripButtonReturns";
            this.toolStripButtonReturns.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonReturns.Text = "Returns";
            this.toolStripButtonReturns.Click += new System.EventHandler(this.toolStripButtonReturns_Click);
            // 
            // toolStripButtonSales
            // 
            this.toolStripButtonSales.AutoSize = false;
            this.toolStripButtonSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.toolStripButtonSales.BackgroundImage = global::Solum.Properties.Resources.saleswhite;
            this.toolStripButtonSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonSales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSales.Enabled = false;
            this.toolStripButtonSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonSales.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStripButtonSales.Image = global::Solum.Properties.Resources.saleswhite;
            this.toolStripButtonSales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSales.Name = "toolStripButtonSales";
            this.toolStripButtonSales.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonSales.Text = "Sales";
            // 
            // toolStripButtonLogOff
            // 
            this.toolStripButtonLogOff.AutoSize = false;
            this.toolStripButtonLogOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.toolStripButtonLogOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLogOff.Enabled = false;
            this.toolStripButtonLogOff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonLogOff.Image = global::Solum.Properties.Resources.exit;
            this.toolStripButtonLogOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLogOff.Name = "toolStripButtonLogOff";
            this.toolStripButtonLogOff.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonLogOff.Text = "Log Off";
            this.toolStripButtonLogOff.Visible = false;
            this.toolStripButtonLogOff.Click += new System.EventHandler(this.toolStripButtonLogOff_Click);
            // 
            // toolStripButtonQdCustomer
            // 
            this.toolStripButtonQdCustomer.AutoSize = false;
            this.toolStripButtonQdCustomer.BackgroundImage = global::Solum.Properties.Resources.xpressreturnIcon;
            this.toolStripButtonQdCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonQdCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonQdCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonQdCustomer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonQdCustomer.Image")));
            this.toolStripButtonQdCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQdCustomer.Name = "toolStripButtonQdCustomer";
            this.toolStripButtonQdCustomer.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonQdCustomer.ToolTipText = "Manage QuickDrop Customers";
            this.toolStripButtonQdCustomer.Visible = false;
            this.toolStripButtonQdCustomer.Click += new System.EventHandler(this.toolStripButtonQdCustomer_Click);
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExit.AutoSize = false;
            this.toolStripButtonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.toolStripButtonExit.BackgroundImage = global::Solum.Properties.Resources.ExitThin75;
            this.toolStripButtonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExit.Enabled = false;
            this.toolStripButtonExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonExit.Text = "Exit";
            this.toolStripButtonExit.Visible = false;
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // toolStripButtonAttendance
            // 
            this.toolStripButtonAttendance.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAttendance.AutoSize = false;
            this.toolStripButtonAttendance.BackgroundImage = global::Solum.Properties.Resources.Clock;
            this.toolStripButtonAttendance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonAttendance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAttendance.Enabled = false;
            this.toolStripButtonAttendance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAttendance.Name = "toolStripButtonAttendance";
            this.toolStripButtonAttendance.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonAttendance.Text = "Attendance";
            this.toolStripButtonAttendance.Visible = false;
            this.toolStripButtonAttendance.Click += new System.EventHandler(this.toolStripButtonAttendance_Click);
            // 
            // toolStripButtonVirtualKb
            // 
            this.toolStripButtonVirtualKb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonVirtualKb.AutoSize = false;
            this.toolStripButtonVirtualKb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVirtualKb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVirtualKb.Name = "toolStripButtonVirtualKb";
            this.toolStripButtonVirtualKb.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonVirtualKb.Text = "Virtual Keyboard";
            this.toolStripButtonVirtualKb.Visible = false;
            this.toolStripButtonVirtualKb.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 78);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 78);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 78);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 78);
            // 
            // toolStripSeparatorQdCustomer
            // 
            this.toolStripSeparatorQdCustomer.Name = "toolStripSeparatorQdCustomer";
            this.toolStripSeparatorQdCustomer.Size = new System.Drawing.Size(6, 78);
            this.toolStripSeparatorQdCustomer.Visible = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 78);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 78);
            // 
            // sol_ProductsBindingSource
            // 
            this.sol_ProductsBindingSource.DataMember = "sol_Products";
            this.sol_ProductsBindingSource.DataSource = this.dataSetProductsLookup;
            // 
            // dataSetProductsLookup
            // 
            this.dataSetProductsLookup.DataSetName = "DataSetProductsLookup";
            this.dataSetProductsLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_ProductsTableAdapter
            // 
            this.sol_ProductsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.sol_ProductsTableAdapter = this.sol_ProductsTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetProductsLookupTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.keyboardButton);
            this.panel3.Controls.Add(this.exitButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(76, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(970, 75);
            this.panel3.TabIndex = 12;
            // 
            // keyboardButton
            // 
            this.keyboardButton.BackgroundImage = global::Solum.Properties.Resources.Keyboard75;
            this.keyboardButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.keyboardButton.FlatAppearance.BorderSize = 0;
            this.keyboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyboardButton.Location = new System.Drawing.Point(820, 0);
            this.keyboardButton.Name = "keyboardButton";
            this.keyboardButton.Size = new System.Drawing.Size(75, 75);
            this.keyboardButton.TabIndex = 1;
            this.keyboardButton.UseVisualStyleBackColor = true;
            this.keyboardButton.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = global::Solum.Properties.Resources.ExitThin75;
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(895, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 75);
            this.exitButton.TabIndex = 0;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // Sales
            // 
            this.AcceptButton = this.buttonExtra;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1046, 713);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(187)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sales_FormClosing);
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrdersLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetOrdersLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFees)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            this.tableLayoutPanelView1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelNumericKb.ResumeLayout(false);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsLookup)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label labelTotalAmt;
        private System.Windows.Forms.Label labelTotalQty;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.ComboBox comboBoxOrderId;
        private System.Windows.Forms.BindingSource bindingSourceOrdersLookup;
        private DataSetOrdersLookup dataSetOrdersLookup;
        private Solum.DataSetOrdersLookupTableAdapters.sol_Orders_SelectAllLookupTableAdapter sol_Orders_SelectAllLookupTableAdapter;
        private System.Windows.Forms.Label labelTax1;
        private System.Windows.Forms.BindingSource bindingSourceFees;
        private DataSetFees dataSetFees;
        private Solum.DataSetFeesTableAdapters.sol_Fees_SelectAllTableAdapter sol_Fees_SelectAllTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServerName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelToday;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimer;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonReturns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSales;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCashier;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorQdCustomer;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonExtra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButtonAttendance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.BindingSource sol_ProductsBindingSource;
        private DataSetProductsLookup dataSetProductsLookup;
        private DataSetProductsLookupTableAdapters.sol_ProductsTableAdapter sol_ProductsTableAdapter;
        private DataSetProductsLookupTableAdapters.TableAdapterManager tableAdapterManager;
        private SirLib.NumericTextBox numericTextBoxTax2Amount;
        private System.Windows.Forms.Label labelTax2;
        private SirLib.NumericTextBox numericTextBoxTax1Amount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrainingMode;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelNumericKb;
        private System.Windows.Forms.Button buttonNumericPad;
        private System.Windows.Forms.Panel panelQuantityButtons;
        private System.Windows.Forms.Panel panelCategoryButtons;
        private System.Windows.Forms.Label label1CurrentCashTray;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonQdCustomer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button keyboardButton;
        private System.Windows.Forms.Button exitButton;
    }
}