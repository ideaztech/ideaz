namespace Solum
{
    partial class Attendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxEmployees = new System.Windows.Forms.ListBox();
            this.solEmployeesSelectAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetEmployees = new Solum.DataSetEmployees();
            this.solEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetEmployeesLookup = new Solum.DataSetEmployeesLookup();
            this.sol_EmployeesTableAdapter = new Solum.DataSetEmployeesLookupTableAdapters.Sol_EmployeesTableAdapter();
            this.pictureBoxPunch = new System.Windows.Forms.PictureBox();
            this.pictureBoxClock = new System.Windows.Forms.PictureBox();
            this.labelLasPunchOut = new System.Windows.Forms.Label();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.panelNumericKb = new System.Windows.Forms.Panel();
            this.buttonGuion = new System.Windows.Forms.Button();
            this.buttonBackSpace = new System.Windows.Forms.Button();
            this.buttonPoint = new System.Windows.Forms.Button();
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
            this.labelPin = new System.Windows.Forms.Label();
            this.buttonViewOptions = new System.Windows.Forms.Button();
            this.buttonPunchOut = new System.Windows.Forms.Button();
            this.buttonPunchIn = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCurrentTimeTimer = new System.Windows.Forms.Label();
            this.sol_Employees_SelectAllTableAdapter = new Solum.DataSetEmployeesTableAdapters.Sol_Employees_SelectAllTableAdapter();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solEmployeesSelectAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmployeesLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClock)).BeginInit();
            this.panelNumericKb.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButtonExit,
            this.toolStripSeparator1,
            this.toolStripButtonVirtualKb});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(723, 71);
            this.toolStrip2.TabIndex = 12;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(181, 68);
            this.toolStripLabel1.Text = "Please select name and enter PIN";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExit.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonExit.Image = global::Solum.Properties.Resources.Close;
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(68, 68);
            this.toolStripButtonExit.Text = "Exit";
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Employee:";
            // 
            // listBoxEmployees
            // 
            this.listBoxEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxEmployees.DataSource = this.solEmployeesSelectAllBindingSource;
            this.listBoxEmployees.DisplayMember = "FirstName";
            this.listBoxEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEmployees.FormattingEnabled = true;
            this.listBoxEmployees.HorizontalScrollbar = true;
            this.listBoxEmployees.ItemHeight = 16;
            this.listBoxEmployees.Location = new System.Drawing.Point(12, 95);
            this.listBoxEmployees.Name = "listBoxEmployees";
            this.listBoxEmployees.Size = new System.Drawing.Size(304, 532);
            this.listBoxEmployees.TabIndex = 15;
            this.listBoxEmployees.ValueMember = "UserId";
            this.listBoxEmployees.SelectedIndexChanged += new System.EventHandler(this.listBoxEmployees_SelectedIndexChanged);
            // 
            // solEmployeesSelectAllBindingSource
            // 
            this.solEmployeesSelectAllBindingSource.DataMember = "Sol_Employees_SelectAll";
            this.solEmployeesSelectAllBindingSource.DataSource = this.dataSetEmployeesBindingSource;
            // 
            // dataSetEmployeesBindingSource
            // 
            this.dataSetEmployeesBindingSource.DataSource = this.dataSetEmployees;
            this.dataSetEmployeesBindingSource.Position = 0;
            // 
            // dataSetEmployees
            // 
            this.dataSetEmployees.DataSetName = "DataSetEmployees";
            this.dataSetEmployees.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // solEmployeesBindingSource
            // 
            this.solEmployeesBindingSource.DataMember = "Sol_Employees";
            this.solEmployeesBindingSource.DataSource = this.dataSetEmployeesLookup;
            this.solEmployeesBindingSource.Sort = "FullName";
            // 
            // dataSetEmployeesLookup
            // 
            this.dataSetEmployeesLookup.DataSetName = "DataSetEmployeesLookup";
            this.dataSetEmployeesLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_EmployeesTableAdapter
            // 
            this.sol_EmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBoxPunch
            // 
            this.pictureBoxPunch.Image = global::Solum.Properties.Resources.Big_Red_Button;
            this.pictureBoxPunch.Location = new System.Drawing.Point(325, 76);
            this.pictureBoxPunch.Name = "pictureBoxPunch";
            this.pictureBoxPunch.Size = new System.Drawing.Size(59, 34);
            this.pictureBoxPunch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPunch.TabIndex = 16;
            this.pictureBoxPunch.TabStop = false;
            // 
            // pictureBoxClock
            // 
            this.pictureBoxClock.Image = global::Solum.Properties.Resources.Big_clock;
            this.pictureBoxClock.Location = new System.Drawing.Point(326, 116);
            this.pictureBoxClock.Name = "pictureBoxClock";
            this.pictureBoxClock.Size = new System.Drawing.Size(59, 42);
            this.pictureBoxClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClock.TabIndex = 17;
            this.pictureBoxClock.TabStop = false;
            // 
            // labelLasPunchOut
            // 
            this.labelLasPunchOut.AutoSize = true;
            this.labelLasPunchOut.Location = new System.Drawing.Point(392, 84);
            this.labelLasPunchOut.Name = "labelLasPunchOut";
            this.labelLasPunchOut.Size = new System.Drawing.Size(109, 15);
            this.labelLasPunchOut.TabIndex = 18;
            this.labelLasPunchOut.Text = "Last punch out: ";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Location = new System.Drawing.Point(392, 128);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(98, 15);
            this.labelCurrentTime.TabIndex = 19;
            this.labelCurrentTime.Text = "Current Time: ";
            // 
            // panelNumericKb
            // 
            this.panelNumericKb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNumericKb.Controls.Add(this.buttonGuion);
            this.panelNumericKb.Controls.Add(this.buttonBackSpace);
            this.panelNumericKb.Controls.Add(this.buttonPoint);
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
            this.panelNumericKb.Location = new System.Drawing.Point(378, 227);
            this.panelNumericKb.Name = "panelNumericKb";
            this.panelNumericKb.Size = new System.Drawing.Size(276, 264);
            this.panelNumericKb.TabIndex = 20;
            // 
            // buttonGuion
            // 
            this.buttonGuion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGuion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonGuion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonGuion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGuion.Location = new System.Drawing.Point(188, 12);
            this.buttonGuion.Name = "buttonGuion";
            this.buttonGuion.Size = new System.Drawing.Size(70, 42);
            this.buttonGuion.TabIndex = 1;
            this.buttonGuion.TabStop = false;
            this.buttonGuion.Text = "-";
            this.buttonGuion.UseVisualStyleBackColor = true;
            this.buttonGuion.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonBackSpace
            // 
            this.buttonBackSpace.BackgroundImage = global::Solum.Properties.Resources.back;
            this.buttonBackSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBackSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonBackSpace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBackSpace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackSpace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBackSpace.Location = new System.Drawing.Point(16, 12);
            this.buttonBackSpace.Name = "buttonBackSpace";
            this.buttonBackSpace.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonBackSpace.Size = new System.Drawing.Size(155, 42);
            this.buttonBackSpace.TabIndex = 0;
            this.buttonBackSpace.TabStop = false;
            this.buttonBackSpace.UseVisualStyleBackColor = true;
            this.buttonBackSpace.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonPoint
            // 
            this.buttonPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonPoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonPoint.Location = new System.Drawing.Point(188, 209);
            this.buttonPoint.Name = "buttonPoint";
            this.buttonPoint.Size = new System.Drawing.Size(70, 42);
            this.buttonPoint.TabIndex = 12;
            this.buttonPoint.TabStop = false;
            this.buttonPoint.Text = ".";
            this.buttonPoint.UseVisualStyleBackColor = true;
            this.buttonPoint.Click += new System.EventHandler(this.button7_Click);
            // 
            // button0
            // 
            this.button0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button0.Location = new System.Drawing.Point(16, 209);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(153, 42);
            this.button0.TabIndex = 11;
            this.button0.TabStop = false;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(188, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 42);
            this.button3.TabIndex = 10;
            this.button3.TabStop = false;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(102, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 42);
            this.button2.TabIndex = 9;
            this.button2.TabStop = false;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(16, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 42);
            this.button1.TabIndex = 8;
            this.button1.TabStop = false;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(188, 111);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(69, 42);
            this.button6.TabIndex = 7;
            this.button6.TabStop = false;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(102, 111);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(69, 42);
            this.button5.TabIndex = 6;
            this.button5.TabStop = false;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(16, 111);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 42);
            this.button4.TabIndex = 5;
            this.button4.TabStop = false;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button9.Location = new System.Drawing.Point(188, 62);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(69, 42);
            this.button9.TabIndex = 4;
            this.button9.TabStop = false;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(102, 62);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(69, 42);
            this.button8.TabIndex = 3;
            this.button8.TabStop = false;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button7_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(16, 62);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(69, 42);
            this.button7.TabIndex = 2;
            this.button7.TabStop = false;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // labelPin
            // 
            this.labelPin.AutoSize = true;
            this.labelPin.Location = new System.Drawing.Point(375, 170);
            this.labelPin.Name = "labelPin";
            this.labelPin.Size = new System.Drawing.Size(34, 15);
            this.labelPin.TabIndex = 21;
            this.labelPin.Text = "PIN:";
            // 
            // buttonViewOptions
            // 
            this.buttonViewOptions.Location = new System.Drawing.Point(456, 607);
            this.buttonViewOptions.Name = "buttonViewOptions";
            this.buttonViewOptions.Size = new System.Drawing.Size(113, 48);
            this.buttonViewOptions.TabIndex = 35;
            this.buttonViewOptions.Text = "&View Options";
            this.buttonViewOptions.UseVisualStyleBackColor = true;
            this.buttonViewOptions.Click += new System.EventHandler(this.buttonViewOptions_Click);
            // 
            // buttonPunchOut
            // 
            this.buttonPunchOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPunchOut.FlatAppearance.BorderSize = 0;
            this.buttonPunchOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPunchOut.Image = global::Solum.Properties.Resources.PunchOut;
            this.buttonPunchOut.Location = new System.Drawing.Point(400, 496);
            this.buttonPunchOut.Name = "buttonPunchOut";
            this.buttonPunchOut.Size = new System.Drawing.Size(114, 108);
            this.buttonPunchOut.TabIndex = 36;
            this.buttonPunchOut.UseVisualStyleBackColor = false;
            this.buttonPunchOut.Click += new System.EventHandler(this.buttonPunchOut_Click);
            // 
            // buttonPunchIn
            // 
            this.buttonPunchIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPunchIn.FlatAppearance.BorderSize = 0;
            this.buttonPunchIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPunchIn.Image = global::Solum.Properties.Resources.PunchIn;
            this.buttonPunchIn.Location = new System.Drawing.Point(520, 496);
            this.buttonPunchIn.Name = "buttonPunchIn";
            this.buttonPunchIn.Size = new System.Drawing.Size(114, 108);
            this.buttonPunchIn.TabIndex = 37;
            this.buttonPunchIn.UseVisualStyleBackColor = false;
            this.buttonPunchIn.Click += new System.EventHandler(this.buttonPunchIn_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(378, 192);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextBox.MaxLength = 32;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(279, 21);
            this.passwordTextBox.TabIndex = 38;
            // 
            // labelCurrentTimeTimer
            // 
            this.labelCurrentTimeTimer.AutoSize = true;
            this.labelCurrentTimeTimer.Location = new System.Drawing.Point(510, 128);
            this.labelCurrentTimeTimer.Name = "labelCurrentTimeTimer";
            this.labelCurrentTimeTimer.Size = new System.Drawing.Size(0, 15);
            this.labelCurrentTimeTimer.TabIndex = 39;
            // 
            // sol_Employees_SelectAllTableAdapter
            // 
            this.sol_Employees_SelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // Attendance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(723, 668);
            this.Controls.Add(this.labelCurrentTimeTimer);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.buttonPunchIn);
            this.Controls.Add(this.buttonPunchOut);
            this.Controls.Add(this.buttonViewOptions);
            this.Controls.Add(this.labelPin);
            this.Controls.Add(this.panelNumericKb);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.labelLasPunchOut);
            this.Controls.Add(this.pictureBoxClock);
            this.Controls.Add(this.pictureBoxPunch);
            this.Controls.Add(this.listBoxEmployees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Attendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solEmployeesSelectAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmployeesLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClock)).EndInit();
            this.panelNumericKb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxEmployees;
        private DataSetEmployeesLookup dataSetEmployeesLookup;
        private System.Windows.Forms.BindingSource solEmployeesBindingSource;
        private DataSetEmployeesLookupTableAdapters.Sol_EmployeesTableAdapter sol_EmployeesTableAdapter;
        private System.Windows.Forms.PictureBox pictureBoxPunch;
        private System.Windows.Forms.PictureBox pictureBoxClock;
        private System.Windows.Forms.Label labelLasPunchOut;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Panel panelNumericKb;
        private System.Windows.Forms.Button buttonGuion;
        private System.Windows.Forms.Button buttonBackSpace;
        private System.Windows.Forms.Button buttonPoint;
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
        private System.Windows.Forms.Label labelPin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button buttonViewOptions;
        private System.Windows.Forms.Button buttonPunchOut;
        private System.Windows.Forms.Button buttonPunchIn;
        internal System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelCurrentTimeTimer;
        private System.Windows.Forms.BindingSource dataSetEmployeesBindingSource;
        private DataSetEmployees dataSetEmployees;
        private System.Windows.Forms.BindingSource solEmployeesSelectAllBindingSource;
        private DataSetEmployeesTableAdapters.Sol_Employees_SelectAllTableAdapter sol_Employees_SelectAllTableAdapter;
    }
}