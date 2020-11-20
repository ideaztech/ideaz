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
    public partial class AttendanceDetails : Form
    {
        private Control controlWithFocus;    //control with focus
        public string fullName;
        public string currentPassword;

        public AttendanceDetails()
        {
            InitializeComponent();
        }

        private void AttendanceDetails_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            toolStripLabelFullName.Text = fullName;
            controlWithFocus = textBoxPassword;
            textBoxComments.Text = Attendance.sol_EmployeesLog.Comments;

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

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            controlWithFocus = textBoxPassword;

        }

        private void textBoxReTypePassword_Enter(object sender, EventArgs e)
        {
            controlWithFocus = textBoxReTypePassword;
        }

        private void buttonSaveComments_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(textBoxComments.Text) || Attendance.sol_EmployeesLog.LogId<1)
            {
                MessageBox.Show("Nothing to save or you have not punch in yet!");
                return;
            }
            Attendance.sol_EmployeesLog.Comments = textBoxComments.Text;
            try
            {
                Attendance.sol_EmployeesLog_Sp.Update(Attendance.sol_EmployeesLog);
            }
            catch (Exception ex)
            {
                CajaDeMensaje.Show("", "Unable to save comments, try again later please...", ex.Message, CajaDeMensajeImagen.Error);
            }


        }

        private void buttonViewReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //query
            string query;
            //query 2
            string query2;
            string subReportName2;
            //query 3
            string query3;
            string subReportName3;


            string dateFromShort = "", dateToShort = "";
            string dateFrom = "", dateTo = "";


            CrystalDecisions.CrystalReports.Engine.ReportDocument rp;

            //query (has a stored procedure)
            query = "storedprocedure";
            subReportName2 = "";
            //query 2
            query2 =
                "";
            subReportName3 = "";
            //query 3
            query3 =
                "";

            //for parameters
            dateFromShort = dateTimePickerViewReportFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            dateToShort = dateTimePickerViewReportTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            dateFrom = dateTimePickerViewReportFrom.Value.ToShortDateString();
            dateTo = dateTimePickerViewReportTo.Value.ToShortDateString();

            rp = new Solum.Reports.TimeClock();

            object[,] parametros;
            parametros = new object[,] 
                    { 
                        { "DateFrom", dateFromShort },
                        { "DateTo", dateToShort },
                        { "UserID", Attendance.userId.ToString() },
                        { "DateFromDate", dateFrom },
                        { "DateToDate", dateTo },
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        {"", ""}
                    };

            bool imprimirReporte = false;
            bool exportarReporte = false;
            short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
            bool preverReporte = false;
            short numeroDeCopias = 1;
            if (Properties.Settings.Default.SettingsWsReceiptPrintPreview)
                preverReporte = true;
            else
                imprimirReporte = true;

            ReportesPrevista f1 = new ReportesPrevista(
                Properties.Settings.Default.WsirConnectionString,
                Properties.Settings.Default.SQLServidorNombre,
                Properties.Settings.Default.SQLBaseDeDatos,     //wsir_
                Properties.Settings.Default.SQLAutentificacion,
                Properties.Settings.Default.SQLUsuarioNombre,
                Properties.Settings.Default.SQLUsuarioClave,
                rp,
                query,
                query2,
                query3,
                parametros,
                subReportName2,
                subReportName3,
                Properties.Settings.Default.SettingsWsReportPrinter.Trim(),
                fileFormat,
                String.Empty,
                numeroDeCopias,
                exportarReporte,
                imprimirReporte,
                preverReporte,
                null,
                String.Empty,    //filePath
                true,
                true
                );
            f1.ShowDialog();

            f1.Dispose();
            f1 = null;


            this.Cursor = Cursors.Default;
        }


        private void buttonRequestTimeOffSend_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveNewPin_Click(object sender, EventArgs e)
        {
            //validar formato clave
            if (!Funciones.validarClave(textBoxPassword.Text.Trim()))
            {
                MessageBox.Show("Use at least 4 characters or numbers please.");
                textBoxReTypePassword.Text = "";
                textBoxPassword.SelectAll();
                textBoxPassword.Focus();
                return;
            }

            if (textBoxPassword.Text.Trim() != textBoxReTypePassword.Text.Trim())
            {
                MessageBox.Show("PIN and new PIN don't match, verify please.");
                textBoxReTypePassword.SelectAll();
                textBoxReTypePassword.Focus();
                return;
            }

            try
            {
                MembershipUser u = Membership.GetUser(Attendance.userName, false);
                if (u.ChangePassword(currentPassword, textBoxPassword.Text))
                {
                    MessageBox.Show("PIN changed!");
                    textBoxPassword.Text = "";
                    textBoxReTypePassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Unable to change your PIN. Try another please.!");
                    textBoxPassword.SelectAll();
                    textBoxPassword.Focus();
                    return;
                }
            }
            catch (Exception e2)
            {
                CajaDeMensaje.Show("", "Unable to change your PIN, try again later please...", e2.Message, CajaDeMensajeImagen.Error);
                textBoxPassword.SelectAll();
                textBoxPassword.Focus();
                return;

            }

        }


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
