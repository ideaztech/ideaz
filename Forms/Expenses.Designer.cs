namespace Solum
{
    partial class Expenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expenses));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonOpenDrawer = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewExpenses = new SirLib.DataGridViewModificada();
            this.comboBoxExpense = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.solExpenseTypesSelectAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetExpenseTypes = new Solum.DataSetExpenseTypes();
            this.textBoxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelNumericKb = new System.Windows.Forms.Panel();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonAsterisc = new System.Windows.Forms.Button();
            this.buttonSlash = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.labelPad = new System.Windows.Forms.Label();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonBackSpace = new System.Windows.Forms.Button();
            this.buttonPeriod = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBoxCashTray = new System.Windows.Forms.ComboBox();
            this.sol_CashTrays_SelectAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetCashTrays = new Solum.DataSetCashTrays();
            this.sol_CashTrays_SelectAllTableAdapter = new Solum.DataSetCashTraysTableAdapters.sol_CashTrays_SelectAllTableAdapter();
            this.tableAdapterManager = new Solum.DataSetCashTraysTableAdapters.TableAdapterManager();
            this.dataSetCashTraysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sol_ExpenseTypes_SelectAllTableAdapter = new Solum.DataSetExpenseTypesTableAdapters.sol_ExpenseTypes_SelectAllTableAdapter();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solExpenseTypesSelectAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExpenseTypes)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelNumericKb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_CashTrays_SelectAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTrays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTraysBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1006, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.80062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.19938F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 688);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.buttonOpenDrawer);
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Controls.Add(this.Cancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(6, 578);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 104);
            this.panel3.TabIndex = 2;
            // 
            // buttonOpenDrawer
            // 
            this.buttonOpenDrawer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOpenDrawer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenDrawer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenDrawer.Location = new System.Drawing.Point(282, 23);
            this.buttonOpenDrawer.Name = "buttonOpenDrawer";
            this.buttonOpenDrawer.Size = new System.Drawing.Size(129, 50);
            this.buttonOpenDrawer.TabIndex = 5;
            this.buttonOpenDrawer.Text = "&Open Drawer";
            this.buttonOpenDrawer.UseVisualStyleBackColor = true;
            this.buttonOpenDrawer.Click += new System.EventHandler(this.buttonOpenDrawer_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSave.Location = new System.Drawing.Point(461, 23);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(129, 50);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.Color.Red;
            this.Cancel.Location = new System.Drawing.Point(640, 24);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(101, 50);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "E&xit";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewExpenses);
            this.splitContainer1.Size = new System.Drawing.Size(492, 563);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridViewExpenses
            // 
            this.dataGridViewExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comboBoxExpense,
            this.textBoxAmount});
            this.dataGridViewExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExpenses.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewExpenses.Name = "dataGridViewExpenses";
            this.dataGridViewExpenses.RowTemplate.Height = 24;
            this.dataGridViewExpenses.Size = new System.Drawing.Size(492, 479);
            this.dataGridViewExpenses.TabIndex = 0;
            // 
            // comboBoxExpense
            // 
            this.comboBoxExpense.DataSource = this.solExpenseTypesSelectAllBindingSource;
            this.comboBoxExpense.DisplayMember = "Description";
            this.comboBoxExpense.DisplayStyleForCurrentCellOnly = true;
            this.comboBoxExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxExpense.HeaderText = "Expense";
            this.comboBoxExpense.Name = "comboBoxExpense";
            this.comboBoxExpense.ValueMember = "ExpenseTypeID";
            this.comboBoxExpense.Width = 250;
            // 
            // solExpenseTypesSelectAllBindingSource
            // 
            this.solExpenseTypesSelectAllBindingSource.DataMember = "sol_ExpenseTypes_SelectAll";
            this.solExpenseTypesSelectAllBindingSource.DataSource = this.dataSetExpenseTypes;
            // 
            // dataSetExpenseTypes
            // 
            this.dataSetExpenseTypes.DataSetName = "DataSetExpenseTypes";
            this.dataSetExpenseTypes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.textBoxAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.textBoxAmount.HeaderText = "Amount";
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panelNumericKb);
            this.panel2.Controls.Add(this.comboBoxCashTray);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(507, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 563);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Cash Tray:";
            // 
            // panelNumericKb
            // 
            this.panelNumericKb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNumericKb.Controls.Add(this.buttonPlus);
            this.panelNumericKb.Controls.Add(this.buttonAsterisc);
            this.panelNumericKb.Controls.Add(this.buttonSlash);
            this.panelNumericKb.Controls.Add(this.buttonEnter);
            this.panelNumericKb.Controls.Add(this.labelPad);
            this.panelNumericKb.Controls.Add(this.buttonMinus);
            this.panelNumericKb.Controls.Add(this.buttonBackSpace);
            this.panelNumericKb.Controls.Add(this.buttonPeriod);
            this.panelNumericKb.Controls.Add(this.button0);
            this.panelNumericKb.Controls.Add(this.button3);
            this.panelNumericKb.Controls.Add(this.button2);
            this.panelNumericKb.Controls.Add(this.button1);
            this.panelNumericKb.Controls.Add(this.button6);
            this.panelNumericKb.Controls.Add(this.button5);
            this.panelNumericKb.Controls.Add(this.button4);
            this.panelNumericKb.Controls.Add(this.button9);
            this.panelNumericKb.Controls.Add(this.button8);
            this.panelNumericKb.Controls.Add(this.button7);
            this.panelNumericKb.Location = new System.Drawing.Point(102, 99);
            this.panelNumericKb.Name = "panelNumericKb";
            this.panelNumericKb.Size = new System.Drawing.Size(289, 422);
            this.panelNumericKb.TabIndex = 2;
            // 
            // buttonPlus
            // 
            this.buttonPlus.BackgroundImage = global::Solum.Properties.Resources.plus_big;
            this.buttonPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlus.Enabled = false;
            this.buttonPlus.FlatAppearance.BorderSize = 0;
            this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.buttonPlus.Location = new System.Drawing.Point(216, 144);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(62, 129);
            this.buttonPlus.TabIndex = 8;
            this.buttonPlus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonAsterisc
            // 
            this.buttonAsterisc.BackgroundImage = global::Solum.Properties.Resources.asterisc;
            this.buttonAsterisc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAsterisc.Enabled = false;
            this.buttonAsterisc.FlatAppearance.BorderSize = 0;
            this.buttonAsterisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAsterisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAsterisc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAsterisc.Location = new System.Drawing.Point(147, 76);
            this.buttonAsterisc.Name = "buttonAsterisc";
            this.buttonAsterisc.Size = new System.Drawing.Size(62, 60);
            this.buttonAsterisc.TabIndex = 3;
            this.buttonAsterisc.UseVisualStyleBackColor = true;
            // 
            // buttonSlash
            // 
            this.buttonSlash.BackgroundImage = global::Solum.Properties.Resources.symbol_9;
            this.buttonSlash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSlash.Enabled = false;
            this.buttonSlash.FlatAppearance.BorderSize = 0;
            this.buttonSlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSlash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSlash.Location = new System.Drawing.Point(78, 76);
            this.buttonSlash.Name = "buttonSlash";
            this.buttonSlash.Size = new System.Drawing.Size(62, 60);
            this.buttonSlash.TabIndex = 2;
            this.buttonSlash.UseVisualStyleBackColor = true;
            // 
            // buttonEnter
            // 
            this.buttonEnter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEnter.BackgroundImage")));
            this.buttonEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEnter.FlatAppearance.BorderSize = 0;
            this.buttonEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonEnter.Location = new System.Drawing.Point(216, 282);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(62, 129);
            this.buttonEnter.TabIndex = 15;
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // labelPad
            // 
            this.labelPad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPad.BackColor = System.Drawing.Color.Black;
            this.labelPad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPad.ForeColor = System.Drawing.Color.Lime;
            this.labelPad.Location = new System.Drawing.Point(9, 9);
            this.labelPad.Name = "labelPad";
            this.labelPad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPad.Size = new System.Drawing.Size(269, 60);
            this.labelPad.TabIndex = 0;
            this.labelPad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonMinus
            // 
            this.buttonMinus.BackgroundImage = global::Solum.Properties.Resources.symbol_11;
            this.buttonMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMinus.FlatAppearance.BorderSize = 0;
            this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMinus.Location = new System.Drawing.Point(216, 76);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(62, 60);
            this.buttonMinus.TabIndex = 4;
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonBackSpace
            // 
            this.buttonBackSpace.BackgroundImage = global::Solum.Properties.Resources.backspace2;
            this.buttonBackSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBackSpace.FlatAppearance.BorderSize = 0;
            this.buttonBackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackSpace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBackSpace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackSpace.Location = new System.Drawing.Point(9, 76);
            this.buttonBackSpace.Name = "buttonBackSpace";
            this.buttonBackSpace.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonBackSpace.Size = new System.Drawing.Size(62, 60);
            this.buttonBackSpace.TabIndex = 1;
            this.buttonBackSpace.UseVisualStyleBackColor = true;
            this.buttonBackSpace.Click += new System.EventHandler(this.buttonBackSpace_Click);
            // 
            // buttonPeriod
            // 
            this.buttonPeriod.BackgroundImage = global::Solum.Properties.Resources.symbol_10;
            this.buttonPeriod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPeriod.FlatAppearance.BorderSize = 0;
            this.buttonPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPeriod.Location = new System.Drawing.Point(147, 351);
            this.buttonPeriod.Name = "buttonPeriod";
            this.buttonPeriod.Size = new System.Drawing.Size(62, 60);
            this.buttonPeriod.TabIndex = 17;
            this.buttonPeriod.UseVisualStyleBackColor = true;
            this.buttonPeriod.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button0
            // 
            this.button0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button0.BackgroundImage")));
            this.button0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button0.FlatAppearance.BorderSize = 0;
            this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button0.Location = new System.Drawing.Point(9, 351);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(131, 60);
            this.button0.TabIndex = 16;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button3.Location = new System.Drawing.Point(147, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 60);
            this.button3.TabIndex = 14;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button2.Location = new System.Drawing.Point(78, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 60);
            this.button2.TabIndex = 13;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button1.Location = new System.Drawing.Point(9, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 60);
            this.button1.TabIndex = 12;
            this.button1.Text = "1";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button6.Location = new System.Drawing.Point(147, 213);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(62, 60);
            this.button6.TabIndex = 11;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button5.Location = new System.Drawing.Point(78, 213);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(62, 60);
            this.button5.TabIndex = 10;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button4.Location = new System.Drawing.Point(9, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 60);
            this.button4.TabIndex = 9;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button9
            // 
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button9.Location = new System.Drawing.Point(147, 144);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(62, 60);
            this.button9.TabIndex = 7;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button8.Location = new System.Drawing.Point(78, 144);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(62, 60);
            this.button8.TabIndex = 6;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(97)))), ((int)(((byte)(95)))));
            this.button7.Location = new System.Drawing.Point(9, 144);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(62, 60);
            this.button7.TabIndex = 5;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // comboBoxCashTray
            // 
            this.comboBoxCashTray.DataSource = this.sol_CashTrays_SelectAllBindingSource;
            this.comboBoxCashTray.DisplayMember = "Description";
            this.comboBoxCashTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCashTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCashTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCashTray.FormattingEnabled = true;
            this.comboBoxCashTray.Location = new System.Drawing.Point(245, 30);
            this.comboBoxCashTray.Name = "comboBoxCashTray";
            this.comboBoxCashTray.Size = new System.Drawing.Size(183, 28);
            this.comboBoxCashTray.TabIndex = 2;
            this.comboBoxCashTray.ValueMember = "CashTrayID";
            this.comboBoxCashTray.SelectedIndexChanged += new System.EventHandler(this.comboBoxCashTray_SelectedIndexChanged);
            // 
            // sol_CashTrays_SelectAllBindingSource
            // 
            this.sol_CashTrays_SelectAllBindingSource.DataMember = "sol_CashTrays_SelectAll";
            this.sol_CashTrays_SelectAllBindingSource.DataSource = this.dataSetCashTrays;
            // 
            // dataSetCashTrays
            // 
            this.dataSetCashTrays.DataSetName = "DataSetCashTrays";
            this.dataSetCashTrays.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_CashTrays_SelectAllTableAdapter
            // 
            this.sol_CashTrays_SelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.sol_CashTrays_SelectAllTableAdapter = this.sol_CashTrays_SelectAllTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetCashTraysTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataSetCashTraysBindingSource
            // 
            this.dataSetCashTraysBindingSource.DataSource = this.dataSetCashTrays;
            this.dataSetCashTraysBindingSource.Position = 0;
            // 
            // sol_ExpenseTypes_SelectAllTableAdapter
            // 
            this.sol_ExpenseTypes_SelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // Expenses
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(1006, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Expenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expenses";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Expenses_FormClosing);
            this.Load += new System.EventHandler(this.Expenses_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solExpenseTypesSelectAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExpenseTypes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelNumericKb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sol_CashTrays_SelectAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTrays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTraysBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCashTray;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonOpenDrawer;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SirLib.DataGridViewModificada dataGridViewExpenses;
        private DataSetCashTrays dataSetCashTrays;
        private System.Windows.Forms.BindingSource sol_CashTrays_SelectAllBindingSource;
        private Solum.DataSetCashTraysTableAdapters.sol_CashTrays_SelectAllTableAdapter sol_CashTrays_SelectAllTableAdapter;
        private Solum.DataSetCashTraysTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource dataSetCashTraysBindingSource;
        private DataSetExpenseTypes dataSetExpenseTypes;
        private System.Windows.Forms.BindingSource solExpenseTypesSelectAllBindingSource;
        private Solum.DataSetExpenseTypesTableAdapters.sol_ExpenseTypes_SelectAllTableAdapter sol_ExpenseTypes_SelectAllTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelNumericKb;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonAsterisc;
        private System.Windows.Forms.Button buttonSlash;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Label labelPad;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonBackSpace;
        private System.Windows.Forms.Button buttonPeriod;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridViewComboBoxColumn comboBoxExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn textBoxAmount;
    }
}