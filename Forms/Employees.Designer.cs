namespace Solum
{
    partial class Employees
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
            System.Windows.Forms.Label userIdLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label middleNameLabel;
            System.Windows.Forms.Label birthDateLabel;
            System.Windows.Forms.Label hireDateLabel;
            System.Windows.Forms.Label employeeNotesLabel;
            System.Windows.Forms.Label sINLabel;
            System.Windows.Forms.Label genderLabel;
            System.Windows.Forms.Label employeeNumberLabel;
            System.Windows.Forms.Label payrollNumberLabel;
            System.Windows.Forms.Label compensationAmountLabel;
            System.Windows.Forms.Label compensationTypeLabel;
            System.Windows.Forms.Label userNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employees));
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.middleNameTextBox = new System.Windows.Forms.TextBox();
            this.birthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.hireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.employeeNotesTextBox = new System.Windows.Forms.TextBox();
            this.sINTextBox = new System.Windows.Forms.TextBox();
            this.employeeNumberTextBox = new System.Windows.Forms.TextBox();
            this.payrollNumberTextBox = new System.Windows.Forms.TextBox();
            this.compensationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.compensationAmountTextBox = new SirLib.NumericTextBox();
            userIdLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            birthDateLabel = new System.Windows.Forms.Label();
            hireDateLabel = new System.Windows.Forms.Label();
            employeeNotesLabel = new System.Windows.Forms.Label();
            sINLabel = new System.Windows.Forms.Label();
            genderLabel = new System.Windows.Forms.Label();
            employeeNumberLabel = new System.Windows.Forms.Label();
            payrollNumberLabel = new System.Windows.Forms.Label();
            compensationAmountLabel = new System.Windows.Forms.Label();
            compensationTypeLabel = new System.Windows.Forms.Label();
            userNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Location = new System.Drawing.Point(369, 9);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new System.Drawing.Size(44, 13);
            userIdLabel.TabIndex = 14;
            userIdLabel.Text = "User Id:";
            userIdLabel.Visible = false;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(21, 53);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(60, 13);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(21, 152);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 6;
            lastNameLabel.Text = "Last Name:";
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new System.Drawing.Point(21, 103);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new System.Drawing.Size(72, 13);
            middleNameLabel.TabIndex = 4;
            middleNameLabel.Text = "Middle Name:";
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Location = new System.Drawing.Point(21, 200);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new System.Drawing.Size(57, 13);
            birthDateLabel.TabIndex = 8;
            birthDateLabel.Text = "Birth Date:";
            // 
            // hireDateLabel
            // 
            hireDateLabel.AutoSize = true;
            hireDateLabel.Location = new System.Drawing.Point(159, 200);
            hireDateLabel.Name = "hireDateLabel";
            hireDateLabel.Size = new System.Drawing.Size(55, 13);
            hireDateLabel.TabIndex = 10;
            hireDateLabel.Text = "Hire Date:";
            // 
            // employeeNotesLabel
            // 
            employeeNotesLabel.AutoSize = true;
            employeeNotesLabel.Location = new System.Drawing.Point(21, 249);
            employeeNotesLabel.Name = "employeeNotesLabel";
            employeeNotesLabel.Size = new System.Drawing.Size(87, 13);
            employeeNotesLabel.TabIndex = 12;
            employeeNotesLabel.Text = "Employee Notes:";
            // 
            // sINLabel
            // 
            sINLabel.AutoSize = true;
            sINLabel.Location = new System.Drawing.Point(369, 56);
            sINLabel.Name = "sINLabel";
            sINLabel.Size = new System.Drawing.Size(28, 13);
            sINLabel.TabIndex = 16;
            sINLabel.Text = "SIN:";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new System.Drawing.Point(369, 103);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new System.Drawing.Size(45, 13);
            genderLabel.TabIndex = 18;
            genderLabel.Text = "Gender:";
            // 
            // employeeNumberLabel
            // 
            employeeNumberLabel.AutoSize = true;
            employeeNumberLabel.Location = new System.Drawing.Point(369, 152);
            employeeNumberLabel.Name = "employeeNumberLabel";
            employeeNumberLabel.Size = new System.Drawing.Size(96, 13);
            employeeNumberLabel.TabIndex = 20;
            employeeNumberLabel.Text = "Employee Number:";
            // 
            // payrollNumberLabel
            // 
            payrollNumberLabel.AutoSize = true;
            payrollNumberLabel.Location = new System.Drawing.Point(369, 199);
            payrollNumberLabel.Name = "payrollNumberLabel";
            payrollNumberLabel.Size = new System.Drawing.Size(81, 13);
            payrollNumberLabel.TabIndex = 22;
            payrollNumberLabel.Text = "Payroll Number:";
            // 
            // compensationAmountLabel
            // 
            compensationAmountLabel.AutoSize = true;
            compensationAmountLabel.Location = new System.Drawing.Point(369, 246);
            compensationAmountLabel.Name = "compensationAmountLabel";
            compensationAmountLabel.Size = new System.Drawing.Size(116, 13);
            compensationAmountLabel.TabIndex = 24;
            compensationAmountLabel.Text = "Compensation Amount:";
            // 
            // compensationTypeLabel
            // 
            compensationTypeLabel.AutoSize = true;
            compensationTypeLabel.Location = new System.Drawing.Point(369, 293);
            compensationTypeLabel.Name = "compensationTypeLabel";
            compensationTypeLabel.Size = new System.Drawing.Size(104, 13);
            compensationTypeLabel.TabIndex = 26;
            compensationTypeLabel.Text = "Compensation Type:";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            userNameLabel.Location = new System.Drawing.Point(21, 23);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(73, 15);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "User Name:";
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Location = new System.Drawing.Point(369, 30);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(72, 20);
            this.userIdTextBox.TabIndex = 15;
            this.userIdTextBox.Visible = false;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(21, 75);
            this.firstNameTextBox.MaxLength = 256;
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(282, 20);
            this.firstNameTextBox.TabIndex = 3;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(21, 174);
            this.lastNameTextBox.MaxLength = 256;
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(282, 20);
            this.lastNameTextBox.TabIndex = 7;
            // 
            // middleNameTextBox
            // 
            this.middleNameTextBox.Location = new System.Drawing.Point(21, 125);
            this.middleNameTextBox.MaxLength = 256;
            this.middleNameTextBox.Name = "middleNameTextBox";
            this.middleNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.middleNameTextBox.TabIndex = 5;
            // 
            // birthDateDateTimePicker
            // 
            this.birthDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthDateDateTimePicker.Location = new System.Drawing.Point(21, 222);
            this.birthDateDateTimePicker.Name = "birthDateDateTimePicker";
            this.birthDateDateTimePicker.Size = new System.Drawing.Size(88, 20);
            this.birthDateDateTimePicker.TabIndex = 9;
            // 
            // hireDateDateTimePicker
            // 
            this.hireDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hireDateDateTimePicker.Location = new System.Drawing.Point(162, 222);
            this.hireDateDateTimePicker.Name = "hireDateDateTimePicker";
            this.hireDateDateTimePicker.Size = new System.Drawing.Size(88, 20);
            this.hireDateDateTimePicker.TabIndex = 11;
            // 
            // employeeNotesTextBox
            // 
            this.employeeNotesTextBox.Location = new System.Drawing.Point(21, 271);
            this.employeeNotesTextBox.MaxLength = 512;
            this.employeeNotesTextBox.Multiline = true;
            this.employeeNotesTextBox.Name = "employeeNotesTextBox";
            this.employeeNotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.employeeNotesTextBox.Size = new System.Drawing.Size(282, 99);
            this.employeeNotesTextBox.TabIndex = 13;
            // 
            // sINTextBox
            // 
            this.sINTextBox.Location = new System.Drawing.Point(369, 77);
            this.sINTextBox.MaxLength = 256;
            this.sINTextBox.Name = "sINTextBox";
            this.sINTextBox.Size = new System.Drawing.Size(200, 20);
            this.sINTextBox.TabIndex = 17;
            // 
            // employeeNumberTextBox
            // 
            this.employeeNumberTextBox.Location = new System.Drawing.Point(369, 173);
            this.employeeNumberTextBox.MaxLength = 256;
            this.employeeNumberTextBox.Name = "employeeNumberTextBox";
            this.employeeNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.employeeNumberTextBox.TabIndex = 21;
            // 
            // payrollNumberTextBox
            // 
            this.payrollNumberTextBox.Location = new System.Drawing.Point(369, 220);
            this.payrollNumberTextBox.MaxLength = 256;
            this.payrollNumberTextBox.Name = "payrollNumberTextBox";
            this.payrollNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.payrollNumberTextBox.TabIndex = 23;
            // 
            // compensationTypeComboBox
            // 
            this.compensationTypeComboBox.FormattingEnabled = true;
            this.compensationTypeComboBox.Items.AddRange(new object[] {
            "Hourly",
            "Yearly"});
            this.compensationTypeComboBox.Location = new System.Drawing.Point(369, 314);
            this.compensationTypeComboBox.Name = "compensationTypeComboBox";
            this.compensationTypeComboBox.Size = new System.Drawing.Size(99, 21);
            this.compensationTypeComboBox.TabIndex = 27;
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.genderComboBox.Location = new System.Drawing.Point(372, 124);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(96, 21);
            this.genderComboBox.TabIndex = 19;
            // 
            // OK
            // 
            this.OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OK.Location = new System.Drawing.Point(170, 432);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(125, 28);
            this.OK.TabIndex = 28;
            this.OK.Text = "&Submit";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Cancel.Location = new System.Drawing.Point(319, 432);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(125, 28);
            this.Cancel.TabIndex = 29;
            this.Cancel.Text = "&Cancel";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTextBox.Location = new System.Drawing.Point(118, 22);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.ReadOnly = true;
            this.userNameTextBox.Size = new System.Drawing.Size(185, 21);
            this.userNameTextBox.TabIndex = 1;
            this.userNameTextBox.TabStop = false;
            // 
            // compensationAmountTextBox
            // 
            this.compensationAmountTextBox.AllowSpace = false;
            this.compensationAmountTextBox.Location = new System.Drawing.Point(369, 268);
            this.compensationAmountTextBox.Name = "compensationAmountTextBox";
            this.compensationAmountTextBox.Size = new System.Drawing.Size(143, 20);
            this.compensationAmountTextBox.TabIndex = 25;
            // 
            // Employees
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(614, 513);
            this.Controls.Add(this.compensationAmountTextBox);
            this.Controls.Add(userNameLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.compensationTypeComboBox);
            this.Controls.Add(userIdLabel);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(middleNameLabel);
            this.Controls.Add(this.middleNameTextBox);
            this.Controls.Add(birthDateLabel);
            this.Controls.Add(this.birthDateDateTimePicker);
            this.Controls.Add(hireDateLabel);
            this.Controls.Add(this.hireDateDateTimePicker);
            this.Controls.Add(employeeNotesLabel);
            this.Controls.Add(this.employeeNotesTextBox);
            this.Controls.Add(sINLabel);
            this.Controls.Add(this.sINTextBox);
            this.Controls.Add(genderLabel);
            this.Controls.Add(employeeNumberLabel);
            this.Controls.Add(this.employeeNumberTextBox);
            this.Controls.Add(payrollNumberLabel);
            this.Controls.Add(this.payrollNumberTextBox);
            this.Controls.Add(compensationAmountLabel);
            this.Controls.Add(compensationTypeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Employees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employees - More Info";
            this.Load += new System.EventHandler(this.Employees_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox middleNameTextBox;
        private System.Windows.Forms.DateTimePicker birthDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker hireDateDateTimePicker;
        private System.Windows.Forms.TextBox employeeNotesTextBox;
        private System.Windows.Forms.TextBox sINTextBox;
        private System.Windows.Forms.TextBox employeeNumberTextBox;
        private System.Windows.Forms.TextBox payrollNumberTextBox;
        private System.Windows.Forms.ComboBox compensationTypeComboBox;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Button OK;
        internal System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private SirLib.NumericTextBox compensationAmountTextBox;

    }
}