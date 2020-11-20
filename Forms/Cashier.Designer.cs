namespace Solum
{
    partial class Cashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cashier));
            this.buttonExit = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCashier = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReturns = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSales = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonQdCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLogOff = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAttendance = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparatorLogOff = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparatorQdCustomer = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.keyboardButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.buttonClearQdCustomerFilter = new System.Windows.Forms.Button();
            this.textBoxQdCardNumber = new System.Windows.Forms.TextBox();
            this.labelQdCardNumber = new System.Windows.Forms.Label();
            this.buttonQuickDropOrders = new System.Windows.Forms.Button();
            this.buttonOutStandingOrders = new System.Windows.Forms.Button();
            this.label1CurrentCashTray = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panelBody1 = new System.Windows.Forms.Panel();
            this.buttonOnAccount = new System.Windows.Forms.Button();
            this.buttonCashRefund = new System.Windows.Forms.Button();
            this.panelBody2 = new System.Windows.Forms.Panel();
            this.labelTotalSelectedOrders = new System.Windows.Forms.Label();
            this.labelTotalUnSelectedOrders = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.buttonUnPay = new System.Windows.Forms.Button();
            this.buttonReprint = new System.Windows.Forms.Button();
            this.buttonViewTodaysOrders = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelFooter1 = new System.Windows.Forms.Panel();
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
            this.toolStripStatusLabelMsr = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMsrMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerCashier = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelBody1.SuspendLayout();
            this.panelBody2.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelFooter1.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(116)))), ((int)(((byte)(85)))));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonExit.Location = new System.Drawing.Point(21, 16);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(120, 60);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(75, 75);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCashier,
            this.toolStripButtonReturns,
            this.toolStripButtonSales,
            this.toolStripButtonQdCustomer,
            this.toolStripButtonExit,
            this.toolStripButtonLogOff,
            this.toolStripButtonAttendance,
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(76, 691);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCashier
            // 
            this.toolStripButtonCashier.AutoSize = false;
            this.toolStripButtonCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(149)))), ((int)(((byte)(173)))));
            this.toolStripButtonCashier.BackgroundImage = global::Solum.Properties.Resources.cashierwhite;
            this.toolStripButtonCashier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonCashier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCashier.Enabled = false;
            this.toolStripButtonCashier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonCashier.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStripButtonCashier.Image = global::Solum.Properties.Resources.cashierwhite;
            this.toolStripButtonCashier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCashier.Name = "toolStripButtonCashier";
            this.toolStripButtonCashier.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonCashier.Text = "Cashier";
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
            this.toolStripButtonSales.BackgroundImage = global::Solum.Properties.Resources.solumsales;
            this.toolStripButtonSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonSales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButtonSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonSales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSales.Name = "toolStripButtonSales";
            this.toolStripButtonSales.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonSales.Text = "Sales";
            this.toolStripButtonSales.Click += new System.EventHandler(this.toolStripButtonSales_Click);
            // 
            // toolStripButtonQdCustomer
            // 
            this.toolStripButtonQdCustomer.AutoSize = false;
            this.toolStripButtonQdCustomer.BackgroundImage = global::Solum.Properties.Resources.xpressreturnIcon;
            this.toolStripButtonQdCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonQdCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButtonQdCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonQdCustomer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonQdCustomer.Image")));
            this.toolStripButtonQdCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQdCustomer.Name = "toolStripButtonQdCustomer";
            this.toolStripButtonQdCustomer.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonQdCustomer.Text = "QD Customer";
            this.toolStripButtonQdCustomer.ToolTipText = "Manage QuickDrop Customers";
            this.toolStripButtonQdCustomer.Visible = false;
            this.toolStripButtonQdCustomer.Click += new System.EventHandler(this.toolStripButtonQdCustomer_Click);
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExit.AutoSize = false;
            this.toolStripButtonExit.BackgroundImage = global::Solum.Properties.Resources.ExitThin75;
            this.toolStripButtonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExit.Enabled = false;
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonExit.Text = "Exit";
            this.toolStripButtonExit.Visible = false;
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // toolStripButtonLogOff
            // 
            this.toolStripButtonLogOff.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonLogOff.AutoSize = false;
            this.toolStripButtonLogOff.BackgroundImage = global::Solum.Properties.Resources.LogOut75;
            this.toolStripButtonLogOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonLogOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButtonLogOff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonLogOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLogOff.Name = "toolStripButtonLogOff";
            this.toolStripButtonLogOff.Size = new System.Drawing.Size(75, 75);
            this.toolStripButtonLogOff.Text = "Log Off";
            this.toolStripButtonLogOff.Click += new System.EventHandler(this.toolStripButtonLogOff_Click);
            // 
            // toolStripButtonAttendance
            // 
            this.toolStripButtonAttendance.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAttendance.AutoSize = false;
            this.toolStripButtonAttendance.BackgroundImage = global::Solum.Properties.Resources.Clock;
            this.toolStripButtonAttendance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonAttendance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(73, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(73, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(73, 6);
            // 
            // toolStripSeparatorLogOff
            // 
            this.toolStripSeparatorLogOff.Name = "toolStripSeparatorLogOff";
            this.toolStripSeparatorLogOff.Size = new System.Drawing.Size(73, 6);
            // 
            // toolStripSeparatorQdCustomer
            // 
            this.toolStripSeparatorQdCustomer.Name = "toolStripSeparatorQdCustomer";
            this.toolStripSeparatorQdCustomer.Size = new System.Drawing.Size(73, 6);
            this.toolStripSeparatorQdCustomer.Visible = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(73, 6);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(73, 6);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.93549F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.06452F));
            this.tableLayoutPanel1.Controls.Add(this.panelHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelBody, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelBody1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelBody2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelFooter, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelFooter1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(76, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.94737F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.05264F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 691);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelHeader, 2);
            this.panelHeader.Controls.Add(this.keyboardButton);
            this.panelHeader.Controls.Add(this.exitButton);
            this.panelHeader.Controls.Add(this.buttonClearQdCustomerFilter);
            this.panelHeader.Controls.Add(this.textBoxQdCardNumber);
            this.panelHeader.Controls.Add(this.labelQdCardNumber);
            this.panelHeader.Controls.Add(this.buttonQuickDropOrders);
            this.panelHeader.Controls.Add(this.buttonOutStandingOrders);
            this.panelHeader.Controls.Add(this.label1CurrentCashTray);
            this.panelHeader.Controls.Add(this.label10);
            this.panelHeader.Controls.Add(this.buttonSearch);
            this.panelHeader.Controls.Add(this.textBoxOrderId);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(924, 93);
            this.panelHeader.TabIndex = 2;
            // 
            // keyboardButton
            // 
            this.keyboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboardButton.BackgroundImage = global::Solum.Properties.Resources.Keyboard75;
            this.keyboardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.keyboardButton.FlatAppearance.BorderSize = 0;
            this.keyboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyboardButton.Location = new System.Drawing.Point(765, 3);
            this.keyboardButton.Name = "keyboardButton";
            this.keyboardButton.Size = new System.Drawing.Size(75, 75);
            this.keyboardButton.TabIndex = 11;
            this.keyboardButton.UseVisualStyleBackColor = true;
            this.keyboardButton.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackgroundImage = global::Solum.Properties.Resources.ExitThin75;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(846, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 75);
            this.exitButton.TabIndex = 10;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // buttonClearQdCustomerFilter
            // 
            this.buttonClearQdCustomerFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearQdCustomerFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearQdCustomerFilter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buttonClearQdCustomerFilter.Location = new System.Drawing.Point(529, 56);
            this.buttonClearQdCustomerFilter.Name = "buttonClearQdCustomerFilter";
            this.buttonClearQdCustomerFilter.Size = new System.Drawing.Size(40, 22);
            this.buttonClearQdCustomerFilter.TabIndex = 5;
            this.buttonClearQdCustomerFilter.Text = "X";
            this.buttonClearQdCustomerFilter.UseVisualStyleBackColor = true;
            this.buttonClearQdCustomerFilter.Click += new System.EventHandler(this.buttonClearQdCustomerFilter_Click);
            // 
            // textBoxQdCardNumber
            // 
            this.textBoxQdCardNumber.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxQdCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxQdCardNumber.Location = new System.Drawing.Point(388, 62);
            this.textBoxQdCardNumber.Name = "textBoxQdCardNumber";
            this.textBoxQdCardNumber.Size = new System.Drawing.Size(135, 16);
            this.textBoxQdCardNumber.TabIndex = 3;
            this.textBoxQdCardNumber.Visible = false;
            this.textBoxQdCardNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxQdCardNumber_KeyDown);
            this.textBoxQdCardNumber.Leave += new System.EventHandler(this.textBoxQdCardNumber_Leave);
            // 
            // labelQdCardNumber
            // 
            this.labelQdCardNumber.AutoSize = true;
            this.labelQdCardNumber.Location = new System.Drawing.Point(302, 61);
            this.labelQdCardNumber.Name = "labelQdCardNumber";
            this.labelQdCardNumber.Size = new System.Drawing.Size(72, 17);
            this.labelQdCardNumber.TabIndex = 2;
            this.labelQdCardNumber.Text = "XP Card #";
            this.labelQdCardNumber.Visible = false;
            // 
            // buttonQuickDropOrders
            // 
            this.buttonQuickDropOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.buttonQuickDropOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuickDropOrders.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuickDropOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonQuickDropOrders.Location = new System.Drawing.Point(148, 40);
            this.buttonQuickDropOrders.Name = "buttonQuickDropOrders";
            this.buttonQuickDropOrders.Size = new System.Drawing.Size(149, 38);
            this.buttonQuickDropOrders.TabIndex = 1;
            this.buttonQuickDropOrders.Text = "Xpress Return";
            this.buttonQuickDropOrders.UseVisualStyleBackColor = false;
            this.buttonQuickDropOrders.Visible = false;
            this.buttonQuickDropOrders.Click += new System.EventHandler(this.buttonQuickDropOrders_Click);
            // 
            // buttonOutStandingOrders
            // 
            this.buttonOutStandingOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.buttonOutStandingOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOutStandingOrders.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOutStandingOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonOutStandingOrders.Location = new System.Drawing.Point(-1, 40);
            this.buttonOutStandingOrders.Name = "buttonOutStandingOrders";
            this.buttonOutStandingOrders.Size = new System.Drawing.Size(150, 38);
            this.buttonOutStandingOrders.TabIndex = 0;
            this.buttonOutStandingOrders.Text = "Outstanding Orders";
            this.buttonOutStandingOrders.UseVisualStyleBackColor = false;
            this.buttonOutStandingOrders.Click += new System.EventHandler(this.buttonOutStandingOrders_Click);
            // 
            // label1CurrentCashTray
            // 
            this.label1CurrentCashTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1CurrentCashTray.Location = new System.Drawing.Point(136, 4);
            this.label1CurrentCashTray.Name = "label1CurrentCashTray";
            this.label1CurrentCashTray.Size = new System.Drawing.Size(118, 20);
            this.label1CurrentCashTray.TabIndex = 9;
            this.label1CurrentCashTray.Text = "<Undefined>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Current CashTray:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonSearch.Location = new System.Drawing.Point(575, 18);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(120, 60);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxOrderId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOrderId.Location = new System.Drawing.Point(389, 38);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(135, 16);
            this.textBoxOrderId.TabIndex = 1;
            this.textBoxOrderId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOrderId_KeyDown);
            this.textBoxOrderId.Leave += new System.EventHandler(this.textBoxOrderId_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Order #";
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.listView1);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(3, 102);
            this.panelBody.Name = "panelBody";
            this.tableLayoutPanel1.SetRowSpan(this.panelBody, 2);
            this.panelBody.Size = new System.Drawing.Size(755, 487);
            this.panelBody.TabIndex = 8;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(755, 487);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // panelBody1
            // 
            this.panelBody1.Controls.Add(this.buttonOnAccount);
            this.panelBody1.Controls.Add(this.buttonCashRefund);
            this.panelBody1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody1.Location = new System.Drawing.Point(764, 102);
            this.panelBody1.Name = "panelBody1";
            this.panelBody1.Size = new System.Drawing.Size(163, 237);
            this.panelBody1.TabIndex = 0;
            // 
            // buttonOnAccount
            // 
            this.buttonOnAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(187)))));
            this.buttonOnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOnAccount.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonOnAccount.Location = new System.Drawing.Point(21, 69);
            this.buttonOnAccount.Name = "buttonOnAccount";
            this.buttonOnAccount.Size = new System.Drawing.Size(120, 60);
            this.buttonOnAccount.TabIndex = 1;
            this.buttonOnAccount.Text = "&On Account";
            this.buttonOnAccount.UseVisualStyleBackColor = false;
            this.buttonOnAccount.Click += new System.EventHandler(this.buttonOnAccount_Click);
            // 
            // buttonCashRefund
            // 
            this.buttonCashRefund.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.buttonCashRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCashRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonCashRefund.Location = new System.Drawing.Point(21, 3);
            this.buttonCashRefund.Name = "buttonCashRefund";
            this.buttonCashRefund.Size = new System.Drawing.Size(120, 60);
            this.buttonCashRefund.TabIndex = 0;
            this.buttonCashRefund.Text = "&Cash Refund";
            this.buttonCashRefund.UseVisualStyleBackColor = false;
            this.buttonCashRefund.Click += new System.EventHandler(this.buttonCashRefund_Click);
            // 
            // panelBody2
            // 
            this.panelBody2.Controls.Add(this.labelTotalSelectedOrders);
            this.panelBody2.Controls.Add(this.labelTotalUnSelectedOrders);
            this.panelBody2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody2.Location = new System.Drawing.Point(764, 345);
            this.panelBody2.Name = "panelBody2";
            this.panelBody2.Size = new System.Drawing.Size(163, 244);
            this.panelBody2.TabIndex = 3;
            // 
            // labelTotalSelectedOrders
            // 
            this.labelTotalSelectedOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.labelTotalSelectedOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSelectedOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.labelTotalSelectedOrders.Location = new System.Drawing.Point(0, 127);
            this.labelTotalSelectedOrders.Name = "labelTotalSelectedOrders";
            this.labelTotalSelectedOrders.Size = new System.Drawing.Size(170, 117);
            this.labelTotalSelectedOrders.TabIndex = 1;
            this.labelTotalSelectedOrders.Text = "Selected Orders:";
            // 
            // labelTotalUnSelectedOrders
            // 
            this.labelTotalUnSelectedOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalUnSelectedOrders.Location = new System.Drawing.Point(0, 0);
            this.labelTotalUnSelectedOrders.Name = "labelTotalUnSelectedOrders";
            this.labelTotalUnSelectedOrders.Size = new System.Drawing.Size(170, 117);
            this.labelTotalUnSelectedOrders.TabIndex = 0;
            this.labelTotalUnSelectedOrders.Text = "UnSelected Orders:";
            this.labelTotalUnSelectedOrders.Visible = false;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.buttonUnPay);
            this.panelFooter.Controls.Add(this.buttonReprint);
            this.panelFooter.Controls.Add(this.buttonViewTodaysOrders);
            this.panelFooter.Controls.Add(this.buttonRefresh);
            this.panelFooter.Controls.Add(this.buttonDelete);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFooter.Location = new System.Drawing.Point(3, 595);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(755, 93);
            this.panelFooter.TabIndex = 3;
            // 
            // buttonUnPay
            // 
            this.buttonUnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(187)))));
            this.buttonUnPay.Enabled = false;
            this.buttonUnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnPay.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonUnPay.Location = new System.Drawing.Point(615, 16);
            this.buttonUnPay.Name = "buttonUnPay";
            this.buttonUnPay.Size = new System.Drawing.Size(120, 60);
            this.buttonUnPay.TabIndex = 4;
            this.buttonUnPay.Text = "&UnPay";
            this.buttonUnPay.UseVisualStyleBackColor = false;
            this.buttonUnPay.Click += new System.EventHandler(this.buttonUnPay_Click);
            // 
            // buttonReprint
            // 
            this.buttonReprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.buttonReprint.Enabled = false;
            this.buttonReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonReprint.Location = new System.Drawing.Point(462, 16);
            this.buttonReprint.Name = "buttonReprint";
            this.buttonReprint.Size = new System.Drawing.Size(120, 60);
            this.buttonReprint.TabIndex = 3;
            this.buttonReprint.Text = "&RePrint";
            this.buttonReprint.UseVisualStyleBackColor = false;
            this.buttonReprint.Click += new System.EventHandler(this.buttonReprint_Click);
            // 
            // buttonViewTodaysOrders
            // 
            this.buttonViewTodaysOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.buttonViewTodaysOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewTodaysOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonViewTodaysOrders.Location = new System.Drawing.Point(309, 16);
            this.buttonViewTodaysOrders.Name = "buttonViewTodaysOrders";
            this.buttonViewTodaysOrders.Size = new System.Drawing.Size(120, 60);
            this.buttonViewTodaysOrders.TabIndex = 2;
            this.buttonViewTodaysOrders.Text = "&View Today\'s Orders";
            this.buttonViewTodaysOrders.UseVisualStyleBackColor = false;
            this.buttonViewTodaysOrders.Click += new System.EventHandler(this.buttonViewTodaysOrders_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonRefresh.Location = new System.Drawing.Point(156, 16);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(120, 60);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "&Refresh Unpaid Orders";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(116)))), ((int)(((byte)(85)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonDelete.Location = new System.Drawing.Point(13, 16);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(120, 60);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "&Void Selected Orders";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panelFooter1
            // 
            this.panelFooter1.Controls.Add(this.buttonExit);
            this.panelFooter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFooter1.Location = new System.Drawing.Point(764, 595);
            this.panelFooter1.Name = "panelFooter1";
            this.panelFooter1.Size = new System.Drawing.Size(163, 93);
            this.panelFooter1.TabIndex = 1;
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelUserName,
            this.toolStripStatusLabelServer,
            this.toolStripStatusLabelServerName,
            this.toolStripStatusLabelDate,
            this.toolStripStatusLabelToday,
            this.toolStripStatusLabelTime,
            this.toolStripStatusLabelTimer,
            this.toolStripStatusLabelTrainingMode,
            this.toolStripStatusLabelMsr,
            this.toolStripStatusLabelMsrMessage});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 691);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1006, 22);
            this.statusStripBottom.SizingGrip = false;
            this.statusStripBottom.TabIndex = 1;
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
            // toolStripStatusLabelMsr
            // 
            this.toolStripStatusLabelMsr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabelMsr.Name = "toolStripStatusLabelMsr";
            this.toolStripStatusLabelMsr.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabelMsr.Text = "MSR:";
            this.toolStripStatusLabelMsr.Visible = false;
            // 
            // toolStripStatusLabelMsrMessage
            // 
            this.toolStripStatusLabelMsrMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelMsrMessage.Name = "toolStripStatusLabelMsrMessage";
            this.toolStripStatusLabelMsrMessage.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabelMsrMessage.Text = "not found";
            this.toolStripStatusLabelMsrMessage.Visible = false;
            // 
            // Cashier
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(1006, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStripBottom);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(187)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cashier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Cashier_FormClosed);
            this.Load += new System.EventHandler(this.Cashier_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panelBody1.ResumeLayout(false);
            this.panelBody2.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter1.ResumeLayout(false);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonReturns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSales;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCashier;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorQdCustomer;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelFooter1;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonViewTodaysOrders;
        private System.Windows.Forms.Button buttonReprint;
        private System.Windows.Forms.Button buttonUnPay;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButtonAttendance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServerName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelToday;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimer;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panelBody1;
        private System.Windows.Forms.Button buttonOnAccount;
        private System.Windows.Forms.Button buttonCashRefund;
        private System.Windows.Forms.Panel panelBody2;
        private System.Windows.Forms.Label labelTotalSelectedOrders;
        private System.Windows.Forms.Label labelTotalUnSelectedOrders;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrainingMode;
        private System.Windows.Forms.Label label1CurrentCashTray;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMsr;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMsrMessage;
        private System.Windows.Forms.Timer timerCashier;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorLogOff;
        private System.Windows.Forms.ToolStripButton toolStripButtonQdCustomer;
        private System.Windows.Forms.Button buttonOutStandingOrders;
        private System.Windows.Forms.Button buttonQuickDropOrders;
        private System.Windows.Forms.TextBox textBoxQdCardNumber;
        private System.Windows.Forms.Label labelQdCardNumber;
        private System.Windows.Forms.Button buttonClearQdCustomerFilter;
        private System.Windows.Forms.Button keyboardButton;
        private System.Windows.Forms.Button exitButton;
    }
}