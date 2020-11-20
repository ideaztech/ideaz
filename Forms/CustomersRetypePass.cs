using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;

namespace Solum
{
    public partial class CustomersRetypePass : Form
    {
        public string password { get; set; }
        public bool cancel { get; set; }

        //private string password;
        //public virtual string Password
        //{
        //    get { return password; }
        //    set { password = value; }
        //}

        public CustomersRetypePass()
        {
            InitializeComponent();
            password = string.Empty;
            cancel = false;
        }

        private void CustomersRetypePass_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                //this.Height = this.Height + (OK.Height) + 50;
                //OK.Height = OK.Height * 2;
                //Cancel.Height = Cancel.Height * 2;

                toolStripButtonVirtualKb.Visible = true;

            }

            textBoxPassword.Text = password;
        }

        private void toolStripButtonVirtualKb_Click(object sender, EventArgs e)
        {
            if (Main._pVirtualKb == null)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, true);
            else
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void OK_Click(object sender, EventArgs e)
        {
            //password = passwordTextBox.Text;

            if (textBoxRetypePassword.Text != textBoxPassword.Text)
            {
                MessageBox.Show("Password and Retype password must match!");
              
                return;
            }

            password = textBoxPassword.Text;
            cancel = false;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //password = String.Empty;
            cancel = true;
        }

        private void CustomersRetypePass_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Main._pVirtualKb != null)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }
    }
}
