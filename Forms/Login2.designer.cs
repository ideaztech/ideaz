namespace Solum
{
    partial class Login2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login2));
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vkButton = new System.Windows.Forms.Button();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.bindingSourceUsers = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetUsersLookup = new Solum.DataSetUsersLookup();
            this.loginLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.checkBoxRecuerdame = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
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
            this.linkLabelOlvidoClave = new System.Windows.Forms.LinkLabel();
            this.aspnet_UsersTableAdapter = new Solum.DataSetUsersLookupTableAdapters.aspnet_UsersTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsersLookup)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelNumericKb.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(214)))), ((int)(((byte)(93)))));
            this.OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.FlatAppearance.BorderSize = 0;
            this.OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OK.Location = new System.Drawing.Point(240, 327);
            this.OK.Margin = new System.Windows.Forms.Padding(0);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(105, 70);
            this.OK.TabIndex = 6;
            this.OK.Text = "ok";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Transparent;
            this.Cancel.BackgroundImage = global::Solum.Properties.Resources.ExitThin75;
            this.Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Cancel.Location = new System.Drawing.Point(684, 0);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 77);
            this.Cancel.TabIndex = 5;
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.passwordTextBox.Location = new System.Drawing.Point(56, 8);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextBox.MaxLength = 32;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(292, 37);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.PasswordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PasswordLabel.Location = new System.Drawing.Point(9, 17);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(39, 28);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "&PIN";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.UsernameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UsernameLabel.Location = new System.Drawing.Point(4, 38);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(137, 28);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "&Username";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.vkButton);
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 77);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(251, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Login";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Solum.Properties.Resources.SolumLogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 77);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // vkButton
            // 
            this.vkButton.BackColor = System.Drawing.Color.Transparent;
            this.vkButton.BackgroundImage = global::Solum.Properties.Resources.Keyboard75;
            this.vkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.vkButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.vkButton.FlatAppearance.BorderSize = 0;
            this.vkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vkButton.Location = new System.Drawing.Point(609, 0);
            this.vkButton.Name = "vkButton";
            this.vkButton.Size = new System.Drawing.Size(75, 77);
            this.vkButton.TabIndex = 8;
            this.vkButton.UseVisualStyleBackColor = false;
            this.vkButton.Click += new System.EventHandler(this.vkButton_Click);
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxUsers.DataSource = this.bindingSourceUsers;
            this.comboBoxUsers.DisplayMember = "UserName";
            this.comboBoxUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxUsers.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(8, 88);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(306, 36);
            this.comboBoxUsers.TabIndex = 1;
            this.comboBoxUsers.ValueMember = "UserId";
            this.comboBoxUsers.Visible = false;
            this.comboBoxUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);
            this.comboBoxUsers.Enter += new System.EventHandler(this.comboBoxUsers_Enter);
            // 
            // bindingSourceUsers
            // 
            this.bindingSourceUsers.DataMember = "aspnet_Users";
            this.bindingSourceUsers.DataSource = this.dataSetUsersLookup;
            // 
            // dataSetUsersLookup
            // 
            this.dataSetUsersLookup.DataSetName = "DataSetUsersLookup";
            this.dataSetUsersLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.loginLabel.Location = new System.Drawing.Point(3, 17);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(53, 19);
            this.loginLabel.TabIndex = 9;
            this.loginLabel.Text = "Login";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.26455F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.73545F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 88);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 518);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.usersListBox);
            this.panel2.Controls.Add(this.loginLabel);
            this.panel2.Controls.Add(this.UsernameLabel);
            this.panel2.Controls.Add(this.checkBoxRecuerdame);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 512);
            this.panel2.TabIndex = 0;
            // 
            // usersListBox
            // 
            this.usersListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.usersListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersListBox.DataSource = this.bindingSourceUsers;
            this.usersListBox.DisplayMember = "UserName";
            this.usersListBox.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(187)))));
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.ItemHeight = 33;
            this.usersListBox.Location = new System.Drawing.Point(7, 68);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(363, 429);
            this.usersListBox.TabIndex = 10;
            this.usersListBox.ValueMember = "UserId";
            // 
            // checkBoxRecuerdame
            // 
            this.checkBoxRecuerdame.AutoSize = true;
            this.checkBoxRecuerdame.FlatAppearance.BorderSize = 0;
            this.checkBoxRecuerdame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRecuerdame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRecuerdame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.checkBoxRecuerdame.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxRecuerdame.Location = new System.Drawing.Point(239, 38);
            this.checkBoxRecuerdame.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRecuerdame.Name = "checkBoxRecuerdame";
            this.checkBoxRecuerdame.Size = new System.Drawing.Size(130, 24);
            this.checkBoxRecuerdame.TabIndex = 4;
            this.checkBoxRecuerdame.Text = "&Remember me";
            this.checkBoxRecuerdame.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.passwordTextBox);
            this.panel3.Controls.Add(this.panelNumericKb);
            this.panel3.Controls.Add(this.PasswordLabel);
            this.panel3.Controls.Add(this.linkLabelOlvidoClave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(382, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(371, 512);
            this.panel3.TabIndex = 1;
            // 
            // panelNumericKb
            // 
            this.panelNumericKb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelNumericKb.Controls.Add(this.OK);
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
            this.panelNumericKb.Location = new System.Drawing.Point(3, 52);
            this.panelNumericKb.Name = "panelNumericKb";
            this.panelNumericKb.Size = new System.Drawing.Size(355, 406);
            this.panelNumericKb.TabIndex = 0;
            // 
            // buttonGuion
            // 
            this.buttonGuion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.buttonGuion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGuion.FlatAppearance.BorderSize = 0;
            this.buttonGuion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGuion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGuion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuion.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.buttonGuion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonGuion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGuion.Location = new System.Drawing.Point(10, 11);
            this.buttonGuion.Name = "buttonGuion";
            this.buttonGuion.Size = new System.Drawing.Size(102, 63);
            this.buttonGuion.TabIndex = 1;
            this.buttonGuion.TabStop = false;
            this.buttonGuion.Text = "-";
            this.buttonGuion.UseVisualStyleBackColor = false;
            this.buttonGuion.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonBackSpace
            // 
            this.buttonBackSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(116)))), ((int)(((byte)(85)))));
            this.buttonBackSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBackSpace.FlatAppearance.BorderSize = 0;
            this.buttonBackSpace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonBackSpace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonBackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackSpace.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.buttonBackSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonBackSpace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackSpace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBackSpace.Location = new System.Drawing.Point(240, 11);
            this.buttonBackSpace.Name = "buttonBackSpace";
            this.buttonBackSpace.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonBackSpace.Size = new System.Drawing.Size(105, 63);
            this.buttonBackSpace.TabIndex = 0;
            this.buttonBackSpace.TabStop = false;
            this.buttonBackSpace.Text = "delete";
            this.buttonBackSpace.UseVisualStyleBackColor = false;
            this.buttonBackSpace.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonPoint
            // 
            this.buttonPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(145)))), ((int)(((byte)(214)))));
            this.buttonPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPoint.FlatAppearance.BorderSize = 0;
            this.buttonPoint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPoint.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.buttonPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.buttonPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonPoint.Location = new System.Drawing.Point(128, 11);
            this.buttonPoint.Name = "buttonPoint";
            this.buttonPoint.Size = new System.Drawing.Size(102, 63);
            this.buttonPoint.TabIndex = 12;
            this.buttonPoint.TabStop = false;
            this.buttonPoint.Text = ".";
            this.buttonPoint.UseVisualStyleBackColor = false;
            this.buttonPoint.Click += new System.EventHandler(this.button7_Click);
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button0.FlatAppearance.BorderSize = 0;
            this.button0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button0.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button0.Location = new System.Drawing.Point(10, 327);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(220, 70);
            this.button0.TabIndex = 11;
            this.button0.TabStop = false;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(240, 249);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 66);
            this.button3.TabIndex = 10;
            this.button3.TabStop = false;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(128, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 66);
            this.button2.TabIndex = 9;
            this.button2.TabStop = false;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(10, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 66);
            this.button1.TabIndex = 8;
            this.button1.TabStop = false;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(240, 171);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 62);
            this.button6.TabIndex = 7;
            this.button6.TabStop = false;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(128, 171);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 62);
            this.button5.TabIndex = 6;
            this.button5.TabStop = false;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(10, 171);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 62);
            this.button4.TabIndex = 5;
            this.button4.TabStop = false;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button9.Location = new System.Drawing.Point(240, 90);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(105, 63);
            this.button9.TabIndex = 4;
            this.button9.TabStop = false;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(128, 90);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(102, 63);
            this.button8.TabIndex = 3;
            this.button8.TabStop = false;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button7_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(164)))), ((int)(((byte)(212)))));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(10, 90);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(102, 63);
            this.button7.TabIndex = 2;
            this.button7.TabStop = false;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // linkLabelOlvidoClave
            // 
            this.linkLabelOlvidoClave.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.linkLabelOlvidoClave.AutoSize = true;
            this.linkLabelOlvidoClave.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelOlvidoClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.linkLabelOlvidoClave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabelOlvidoClave.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(149)))), ((int)(((byte)(173)))));
            this.linkLabelOlvidoClave.Location = new System.Drawing.Point(233, 484);
            this.linkLabelOlvidoClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelOlvidoClave.Name = "linkLabelOlvidoClave";
            this.linkLabelOlvidoClave.Size = new System.Drawing.Size(115, 17);
            this.linkLabelOlvidoClave.TabIndex = 7;
            this.linkLabelOlvidoClave.TabStop = true;
            this.linkLabelOlvidoClave.Text = "&Forgot your PIN?";
            this.linkLabelOlvidoClave.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(214)))), ((int)(((byte)(226)))));
            this.linkLabelOlvidoClave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // aspnet_UsersTableAdapter
            // 
            this.aspnet_UsersTableAdapter.ClearBeforeFill = true;
            // 
            // Login2
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(769, 610);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxUsers);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(88)))), ((int)(((byte)(92)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login2";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsersLookup)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelNumericKb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        internal System.Windows.Forms.Button Cancel;
        internal System.Windows.Forms.TextBox passwordTextBox;
        internal System.Windows.Forms.Label PasswordLabel;
        internal System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource bindingSourceUsers;
        private Solum.DataSetUsersLookup dataSetUsersLookup;
        private Solum.DataSetUsersLookupTableAdapters.aspnet_UsersTableAdapter aspnet_UsersTableAdapter;
        private System.Windows.Forms.LinkLabel linkLabelOlvidoClave;
        private System.Windows.Forms.CheckBox checkBoxRecuerdame;
        private System.Windows.Forms.Button vkButton;
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
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox usersListBox;
    }
}