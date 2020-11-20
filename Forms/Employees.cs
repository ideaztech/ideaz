using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solum
{
    public partial class Employees : Form
    {
        public static bool formCreated = false;
        private bool newUser = false;

        private string userName;
        private Guid userId;

        Sol_Employee sol_Employee;
        Sol_Employee_Sp sol_Employee_Sp;

        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.TouchOriented && !formCreated)
            {
                //toolStripButtonVirtualKb.Visible = true;
                OK.Height = OK.Height * 2;
                Cancel.Height = Cancel.Height * 2;
                formCreated = true;
            }

            
            //MessageBox.Show();

            if (SirLib.Usuarios.callerModule == "Usuarios")
            {
                userName = SirLib.Usuarios.userName;
                userId = SirLib.Usuarios.userId;
            }
            else
            {
                userName = SirLib.UsuariosCrear.userName;
                userId = SirLib.UsuariosCrear.userId;
            }


            userNameTextBox.Text = userName;
            //sINTextBox.Text = SirLib.Usuarios.userId.ToString();

            sol_Employee_Sp = new Sol_Employee_Sp(Properties.Settings.Default.WsirConnectionString);

            sol_Employee = sol_Employee_Sp.Select(userId);
            if (sol_Employee == null)
            {
                newUser = true;
                sol_Employee = new Sol_Employee();
                firstNameTextBox.Text = String.Empty;
                lastNameTextBox.Text = String.Empty;
                middleNameTextBox.Text = String.Empty;
                birthDateDateTimePicker.Value = Main.rc.FechaActual;
                hireDateDateTimePicker.Value = Main.rc.FechaActual;
                employeeNotesTextBox.Text = String.Empty;
                sINTextBox.Text = String.Empty;
                employeeNumberTextBox.Text = String.Empty;
                payrollNumberTextBox.Text = String.Empty;
                compensationAmountTextBox.Text = String.Empty;
                compensationTypeComboBox.SelectedIndex = 0;
                genderComboBox.SelectedIndex = 0;
            }
            else
            {
                newUser = false;
                //userIdTextBox;
                firstNameTextBox.Text = sol_Employee.FirstName;
                lastNameTextBox.Text = sol_Employee.LastName;
                middleNameTextBox.Text = sol_Employee.MiddleName;
                birthDateDateTimePicker.Value = sol_Employee.BirthDate;
                hireDateDateTimePicker.Value = sol_Employee.HireDate;
                employeeNotesTextBox.Text = sol_Employee.EmployeeNotes;
                sINTextBox.Text = sol_Employee.SIN;
                employeeNumberTextBox.Text = sol_Employee.EmployeeNumber;
                payrollNumberTextBox.Text = sol_Employee.PayrollNumber;
                compensationAmountTextBox.Text = sol_Employee.CompensationAmount.ToString();
                compensationTypeComboBox.SelectedIndex = sol_Employee.CompensationType;
                genderComboBox.SelectedIndex = sol_Employee.Gender;

            }

        }

        private void OK_Click(object sender, EventArgs e)
        {
            sol_Employee.FirstName = firstNameTextBox.Text;
            sol_Employee.LastName = lastNameTextBox.Text;
            sol_Employee.MiddleName = middleNameTextBox.Text;
            sol_Employee.BirthDate = birthDateDateTimePicker.Value;
            sol_Employee.HireDate = hireDateDateTimePicker.Value;
            sol_Employee.EmployeeNotes = employeeNotesTextBox.Text;
            sol_Employee.SIN = sINTextBox.Text;
            sol_Employee.EmployeeNumber = employeeNumberTextBox.Text;
            sol_Employee.PayrollNumber = payrollNumberTextBox.Text;
            decimal amount = 0m;
            Decimal.TryParse(compensationAmountTextBox.Text, out amount);
            sol_Employee.CompensationAmount = amount;
            sol_Employee.CompensationType = (byte)compensationTypeComboBox.SelectedIndex;
            sol_Employee.Gender = (byte)genderComboBox.SelectedIndex;
            if (newUser)
            {
                sol_Employee.UserId = userId;
                sol_Employee_Sp.Insert(sol_Employee);
            }
            else
                sol_Employee_Sp.Update(sol_Employee);

            Close();

        }
    }
}
