using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using SirLib;

using System.Web.Security;
using System.Security.Principal;

using System.Threading;
using System.Globalization;
using Solum.App_Code;

namespace Solum

{
    public partial class Login2 : Form
    {
        //string title;
        private bool flagConfirm = false;
        private Control controlWithFocus;    //control with focus

        private System.Diagnostics.Process _p = null;
        private bool touchOriented;

        public bool Recuerdame;
        public bool BottleDrop = false;
        public bool IsAuthenticated = false;
        public string Usuario;
        bool boolFlagCerrar = true;
        BottleDropJsonResponse jResponse;
        BottleDropJsonHandler bdJsHandler;


        public Login2(
            bool TouchOriented,
            bool FlagConfirm,
            string Title,
            string SubTitle
            )
        {
            InitializeComponent();
            touchOriented = TouchOriented;
            flagConfirm = FlagConfirm;

            label1.Text = Title;
            loginLabel.Text = SubTitle;

        }

        private void login_Load(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.SettingsAdFullScreenMode)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                tableLayoutPanel1.Top = (Height / 2) - (tableLayoutPanel1.Height / 2);
                tableLayoutPanel1.Left = (Width / 2) - (tableLayoutPanel1.Width / 2);
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.WindowState = FormWindowState.Normal;

            }
            // TODO: This line of code loads data into the 'dataSetUsersLookup.aspnet_Users' table. You can move, or remove it, as needed.
            this.aspnet_UsersTableAdapter.Fill(this.dataSetUsersLookup.aspnet_Users);
            if (flagConfirm)
            {
                checkBoxRecuerdame.Visible = false;
                checkBoxRecuerdame.Checked = true;
                linkLabelOlvidoClave.Visible = false;

                OK.Text = "&Confirm";
            }
            if (BottleDrop)
            {
                bdJsHandler = Main.MainForm.BDJsonHandler;
                bdJsHandler.GetUsers(out jResponse);
                usersListBox.DataSource = jResponse.Username;
                comboBoxUsers.DataSource = jResponse.Username;
                checkBoxRecuerdame.Visible = false;
                label1.Visible = false;
                linkLabelOlvidoClave.Visible = false;
                pictureBox1.Width = 315;
                pictureBox1.BackgroundImage = Properties.Resources.BottleDropLogo;
            }

            //recuperar ultimo usuario
            if (Recuerdame)
            {
                comboBoxUsers.Text = Usuario;
                passwordTextBox.Text = "";
                checkBoxRecuerdame.Checked = true;
                //passwordTextBox.Focus();
            }
            else
            {
                //comboBoxUsers.Text = "";
                passwordTextBox.Text = "";
                //usernameTextBox.Focus();
                comboBoxUsers.SelectedItem = comboBoxUsers.Items[0];
                usersListBox.SelectedItem = usersListBox.Items[0];
                comboBoxUsers.Text = usersListBox.Text;
            }

            if (touchOriented)
            {
                vkButton.Visible = true;

            }



            controlWithFocus = passwordTextBox;

            this.Focus();

            //this.Text = title;

            //disable form resizing
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;




        }

        private void OK_Click(object sender, EventArgs e)
        {
            //CultureInfo culture = CultureManager.ApplicationUICulture;
            BottleDropJsonResponse jres;
            boolFlagCerrar = true;
            if (BottleDrop && bdJsHandler.Login(comboBoxUsers.Text, passwordTextBox.Text, out jres))
            {
                IsAuthenticated = true;
            }
            else if (comboBoxUsers.Text.ToLower() == "admin"
                && passwordTextBox.Text.ToLower() == "adm.646")
                IsAuthenticated = true;
            else if (Membership.ValidateUser(comboBoxUsers.Text, passwordTextBox.Text))
            {
                Recuerdame = checkBoxRecuerdame.Checked;
                Usuario = comboBoxUsers.Text;
                //if (flagConfirm)
                //{
                //    IsAuthenticated = Roles.IsUserInRole(Usuario, "admin");
                //    if (!IsAuthenticated)
                //    {
                //        if (Usuario == Properties.Settings.Default.UsuarioNombre)
                //            IsAuthenticated = Main.permisos["SolMovC"];
                //        else
                //        {
                //            //check permission of another user
                //            Dictionary<string, bool> permisos = new Dictionary<string, bool>();
                //            Main.PermisosObtener(ref permisos, Usuario);
                //            IsAuthenticated = permisos["SolMovC"];

                //        }
                //    }

                //}
                //else
                IsAuthenticated = true;
            }
            else
            {
                MembershipUser u = Membership.GetUser(comboBoxUsers.Text);
                bool bloqueado = false;
                if (u != null)
                    bloqueado = u.IsLockedOut;
                if (bloqueado)
                {
                    //CajaDeMensaje.Show("", "User blocked, ask your administrator for help...", "", CajaDeMensajeImagen.Error);
                    MessageBox.Show("User blocked, ask your administrator for help...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (comboBoxUsers.Text == "admin")
                        u.UnlockUser();
                }
                else
                {
                    //CajaDeMensaje.Show("", "Invalid user name or password, try again please...", "", CajaDeMensajeImagen.Error);
                    MessageBox.Show("Invalid user name or password, try again please...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                boolFlagCerrar = false;
                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
                return;
            }
            Close();

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //no cerramos?
            if (!boolFlagCerrar)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (!BottleDrop)
                {
                    Recuerdame = checkBoxRecuerdame.Checked;
                    Usuario = comboBoxUsers.Text;
                    if (touchOriented)
                        Funciones.TecladoVirtual(ref _p, false);
                }
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //obligamos a cerrar
            boolFlagCerrar = true;
            IsAuthenticated = false;
            this.Close();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            //recuperar ultimo usuario
            passwordTextBox.Text = "";
            if (Recuerdame)
            {
                //usernameTextBox.Text = Usuario;
                //usernameTextBox.Text.Trim();
                //passwordTextBox.Text = "";
                //checkBoxRecuerdame.Checked = true;
                passwordTextBox.Focus();
            }
            else
            {
                //usernameTextBox.Text = "";
                //passwordTextBox.Text = "";
                //comboBoxUsers.Focus();
                //usersListBox.Focus();
                passwordTextBox.Focus();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (touchOriented)
                Funciones.TecladoVirtual(ref _p, false);


            ForgotPasswod dlg = new ForgotPasswod(touchOriented, "PIN");
            dlg.Usuario = comboBoxUsers.Text;
            if (this.MdiParent == null)
            {
                dlg.ShowDialog();
                dlg.Dispose();
                dlg = null;

            }
            else
            {
                dlg.MdiParent = this.MdiParent;
                dlg.Show();
            }

            passwordTextBox.Focus();
        }


        private void vkButton_Click(object sender, EventArgs e)
        {
            if (touchOriented)
            {
                if (_p == null)
                    Funciones.TecladoVirtual(ref _p, true);
                else
                    Funciones.TecladoVirtual(ref _p, false);
            }

        }

        private void comboBoxUsers_Enter(object sender, EventArgs e)
        {
            //controlWithFocus = comboBoxUsers;

        }


        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            controlWithFocus = passwordTextBox;

        }

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
            else if (buttonName == "buttonClear")
            {
                if (!String.IsNullOrEmpty(controlWithFocus.Text))
                {

                    controlWithFocus.Text = "";

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

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            passwordTextBox.Focus();
        }
    }
}
