using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;
using System.Web.Security;

namespace Solum
{
    public partial class Attendance : Form
    {
        public int itemIndex;

        public static Sol_EmployeesLog sol_EmployeesLog;
        public static Sol_EmployeesLog_Sp sol_EmployeesLog_Sp;
        public static Guid userId;
        public static string userName;

        private Control controlWithFocus;    //control with focus

        public Attendance()
        {
            InitializeComponent();
            itemIndex = -1;
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetEmployees.Sol_Employees_SelectAll' table. You can move, or remove it, as needed.
            this.sol_Employees_SelectAllTableAdapter.Fill(this.dataSetEmployees.Sol_Employees_SelectAll);
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            // TODO: This line of code loads data into the 'dataSetEmployeesLookup.Sol_Employees' table. You can move, or remove it, as needed.
            this.sol_EmployeesTableAdapter.Fill(this.dataSetEmployeesLookup.Sol_Employees);

            controlWithFocus = passwordTextBox;
            sol_EmployeesLog = new Sol_EmployeesLog();
            sol_EmployeesLog_Sp = new Sol_EmployeesLog_Sp(Properties.Settings.Default.WsirConnectionString);

            //clock
            //this.timer1.Interval = 1000;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //timer1.Enabled = true;

            object obj1 = null;// toolStripStatusLabelToday;
            object obj2 = labelCurrentTimeTimer;
            Main.rc.CambiarControlFecha(ref obj1);
            Main.rc.CambiarControlHora(ref obj2);

            //select pre-selected employee
            if (itemIndex >= 0)
            {
                listBoxEmployees.SelectedIndex = itemIndex;
                passwordTextBox.Focus();
            }

            //last punch out
            if(listBoxEmployees.Items.Count>0)
                CheckLastPunch();


            
            
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButtonVirtualKb_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                if (Main._pVirtualKb == null)
                    Funciones.TecladoVirtual(ref Main._pVirtualKb, true);
                else
                    Funciones.TecladoVirtual(ref Main._pVirtualKb, false);
            }

        }

        private void buttonPunchOut_Click(object sender, EventArgs e)
        {
            userId = (Guid)listBoxEmployees.SelectedValue;
            MembershipUser myObject = Membership.GetUser(userId);
            userName = myObject.UserName;
            if (Membership.ValidateUser(userName, passwordTextBox.Text))
            {
                if (PunchOut())
                {
                    //buttonPunchIn.Enabled = false;
                    pictureBoxPunch.Image = Properties.Resources.Big_Red_Button;
                    labelLasPunchOut.Text = "Last Punch Out: " + sol_EmployeesLog.PunchOutTime.ToString();
                }
            }
            else
            {
                //CajaDeMensaje.Show("", "Invalid user name or password, try again please...", "", CajaDeMensajeImagen.Error);
                MessageBox.Show("Invalid user name or password, try again please...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
                return;
            }

            passwordTextBox.Text = String.Empty;
            Close();
        }

        private void buttonPunchIn_Click(object sender, EventArgs e)
        {
            userId = (Guid)listBoxEmployees.SelectedValue;
            MembershipUser myObject = Membership.GetUser(userId);
            userName = myObject.UserName;
            if (Membership.ValidateUser(userName, passwordTextBox.Text))
            {
                if (PunchIn())
                {
                    //buttonPunchIn.Enabled = false;
                    pictureBoxPunch.Image = Properties.Resources.Big_Green_Button;
                    labelLasPunchOut.Text = "Last Punch In: " + sol_EmployeesLog.PunchInTime.ToString();
                }
            }
            else
            {
                //CajaDeMensaje.Show("", "Invalid user name or password, try again please...", "", CajaDeMensajeImagen.Error);
                MessageBox.Show("Invalid user name or password, try again please...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
                return;
            }

            passwordTextBox.Text = String.Empty;
            Close();

        }

        private void buttonViewOptions_Click(object sender, EventArgs e)
        {
            userId = (Guid)listBoxEmployees.SelectedValue;
            MembershipUser myObject = Membership.GetUser(userId);
            userName = myObject.UserName;
            if (Membership.ValidateUser(userName, passwordTextBox.Text))
            {
                AttendanceDetails f1 = new AttendanceDetails();
                f1.fullName = listBoxEmployees.Text;
                f1.currentPassword = passwordTextBox.Text;
                f1.ShowDialog();
                f1.Dispose();
                f1 = null;
            }
            else
            {
                //CajaDeMensaje.Show("", "Invalid user name or password, try again please...", "", CajaDeMensajeImagen.Error);
                MessageBox.Show("Invalid user name or password, try again please...", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
                return;
            }

            passwordTextBox.Text = String.Empty;

        }

        private void listBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBoxPunch.Image = Properties.Resources.Big_Red_Button;
            //labelLasPunchOut.Text = "Last punch out: " + CheckLastPunch(1);  //1 = last punch out
            CheckLastPunch();

        }
        
        private bool PunchOut()
        {
            //cannot punchout without a previous punchin
            if (sol_EmployeesLog.PunchInTime.Year == 1753 || sol_EmployeesLog.PunchOutTime.Year != 1753)
                {
                    MessageBox.Show("Cannot punch out without punch in first!");
                    return false;
                }

            //sol_EmployeesLog.UserId = userId;
            //sol_EmployeesLog.PunchInTime = ;
            sol_EmployeesLog.PunchOutTime = Main.rc.FechaActual;
            try
            {
                sol_EmployeesLog_Sp.Update(sol_EmployeesLog);
            }
            catch (Exception e)
            {
                CajaDeMensaje.Show("", "Unable to Punch Out, try again later please...", e.Message, CajaDeMensajeImagen.Error);
                return false;
            }
            return true;
        }

        private bool PunchIn()
        {
            //punchin a second time on same date only if they punched out the previous time
            if(sol_EmployeesLog.PunchInTime.ToShortDateString() == Main.rc.FechaActual.ToShortDateString())
                if (sol_EmployeesLog.PunchOutTime.ToShortDateString() != sol_EmployeesLog.PunchInTime.ToShortDateString())
                {
                    MessageBox.Show("Cannot punch in the same date without punch out first!");
                    return false;
                }

            sol_EmployeesLog = new Sol_EmployeesLog();
            sol_EmployeesLog.UserId = userId;
            sol_EmployeesLog.PunchInTime = Main.rc.FechaActual;
            sol_EmployeesLog.PunchOutTime = DateTime.Parse("1753-1-1 12:00:00");
            try
            {
                sol_EmployeesLog_Sp.Insert(sol_EmployeesLog);
            }
            catch (Exception e)
            {
                CajaDeMensaje.Show("", "Unable to Punch In, try again later please...", e.Message, CajaDeMensajeImagen.Error);
                return false;
            }
            return true;
        }

        private void CheckLastPunch()
        {
            if (listBoxEmployees.SelectedValue == null)
                return;

            string[] resultPunchDatesString = new string[2];
            //DateTime[] resultDate;
            try { userId = (Guid)listBoxEmployees.SelectedValue; } catch { return; }

            try
            {
                sol_EmployeesLog = sol_EmployeesLog_Sp.LastPunch(userId.ToString());
                if (sol_EmployeesLog.PunchInTime.Year == 1753)
                    resultPunchDatesString[0] = "<none>";
                else
                    resultPunchDatesString[0] = sol_EmployeesLog.PunchInTime.ToString();

                if (sol_EmployeesLog.PunchOutTime.Year == 1753)
                    resultPunchDatesString[1] = "<none>";
                else
                    resultPunchDatesString[1] = sol_EmployeesLog.PunchOutTime.ToString();
            }
            catch
            {
                sol_EmployeesLog = new Sol_EmployeesLog();
                sol_EmployeesLog.UserId = userId;
                sol_EmployeesLog.PunchInTime = DateTime.Parse("1753-1-1 12:00:00");
                sol_EmployeesLog.PunchOutTime = DateTime.Parse("1753-1-1 12:00:00");
                resultPunchDatesString[0] = "<none>";
                resultPunchDatesString[1] = "<none>";
            }

            //punch out
            if (resultPunchDatesString[1] != "<none>")
            {
                pictureBoxPunch.Image = Properties.Resources.Big_Red_Button;
                labelLasPunchOut.Text = "Last punch out: " + resultPunchDatesString[1];  //1 = last punch out
            }
            //punch in
            else
            {
                pictureBoxPunch.Image = Properties.Resources.Big_Green_Button;
                labelLasPunchOut.Text = "Last punch in: " + resultPunchDatesString[0];  //0 = last punch in

            }

        }

        //private void timer1_Tick(object sender, System.EventArgs e)
        //{
        //    DateTime t = DateTime.Now;
        //    labelCurrentTime.Text = "Current Time:"+Funciones.Indent(3)+t.ToString();
        //}


        #region KeyPad
        private void button7_Click(object sender, EventArgs e)
        {
            if (controlWithFocus == null)
                return;

            string buttonName = ((Button)sender).Name;
            if (buttonName == "buttonBackSpace")
            {
                if (!String.IsNullOrEmpty(controlWithFocus.Text))
                {
                    string c = controlWithFocus.Text;
                    c = c.Remove(controlWithFocus.Text.Length - 1, 1);
                    controlWithFocus.Text = c;

                }
                controlWithFocus.Focus();
                ((TextBox)controlWithFocus).DeselectAll();
                ((TextBox)controlWithFocus).Select(controlWithFocus.Text.Length, 1);
                return;
            }
            else if (buttonName == "buttonGuion")
                buttonName = "-";
            else if (buttonName == "buttonPoint")
                buttonName = ".";
            else
                buttonName = buttonName.Replace("button", "");

            controlWithFocus.Text += buttonName;
            controlWithFocus.Focus();

            string tc = controlWithFocus.Name;
            if (tc.Substring(0, 5).ToLower() == "combo")
            {
                //((ComboBox)controlWithFocus).DeselectAll();
                ((ComboBox)controlWithFocus).Select(controlWithFocus.Text.Length, 1);
            }
            else
            {
                ((TextBox)controlWithFocus).DeselectAll();
                ((TextBox)controlWithFocus).Select(controlWithFocus.Text.Length, 1);
            }

        }
        #endregion

    }
}
