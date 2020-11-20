using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;
using System.Collections;
using System.Web.Security;

namespace Solum
{
    public partial class Expenses : Form
    {
        private bool flagInicio = true;
        bool entrySaved = false;
        private Sol_Entrie sol_Entrie;
        private Sol_Entrie_Sp sol_Entrie_Sp;
        
        public Expenses()
        {
            InitializeComponent();
        }

        private void Expenses_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            // TODO: This line of code loads data into the 'dataSetExpenseTypes.sol_ExpenseTypes_SelectAll' table. You can move, or remove it, as needed.
            this.sol_ExpenseTypes_SelectAllTableAdapter.Fill(this.dataSetExpenseTypes.sol_ExpenseTypes_SelectAll);
            // TODO: This line of code loads data into the 'dataSetCashTrays.sol_CashTrays_SelectAll' table. You can move, or remove it, as needed.
            this.sol_CashTrays_SelectAllTableAdapter.Fill(this.dataSetCashTrays.sol_CashTrays_SelectAll);

            sol_Entrie = new Sol_Entrie();
            sol_Entrie_Sp = new Sol_Entrie_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //current cashtray
            flagInicio = true;
            comboBoxCashTray.SelectedValue = Properties.Settings.Default.SettingsCurrentCashTray;
            flagInicio = false;

            if (SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, Properties.Settings.Default.SettingsCurrentCashTray))
            {
                DialogResult result = MessageBox.Show("The default cash tray is not open. You cannot add an expense!. Are you sure you want to continue?", "", MessageBoxButtons.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    Close();
                    return;
                }
                buttonSave.Enabled = false;

            }

        }

        private void buttonOpenDrawer_Click(object sender, EventArgs e)
        {
            //open drawer
            //if (PrinterCommand.Send(Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer))
            //    MessageBox.Show("Drawer opened!");

            PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);
            if (Properties.Settings.Default.SettingsWsTicketOpenDrawerSendTwice)
                PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int j = dataGridViewExpenses.Rows.Count;
            if (j < 1)
            {
                MessageBox.Show("Nothing to save!");
                return;
            }

            sol_Entrie = new Sol_Entrie();

            for (int i = 0; i < j; i++)
            {
                //save entry
                sol_Entrie.EntryType = "E"; //Expenses
                MembershipUser membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
                if (membershipUser == null)
                {
                    MessageBox.Show("User does not exits, cannot save this entry");
                    return;
                }
                sol_Entrie.UserID = (Guid)membershipUser.ProviderUserKey;
                sol_Entrie.UserName = Properties.Settings.Default.UsuarioNombre;

                sol_Entrie.Date = Main.rc.FechaActual; // Properties.Settings.Default.FechaActual;
                sol_Entrie.CashTrayID = Properties.Settings.Default.SettingsCurrentCashTray;
                sol_Entrie.ExpenseTypeID = Convert.ToInt32(dataGridViewExpenses[0, i].Value);
                sol_Entrie.Amount = Convert.ToDecimal(dataGridViewExpenses[1, i].Value)*-1;
                //ignore zero amount
                if (sol_Entrie.Amount == 0)
                    continue;
                //discrepancy
                sol_Entrie.DiscrepancyAmount = 0.0m;
                sol_Entrie_Sp.Insert(sol_Entrie);
                entrySaved = true;

            }
            if (entrySaved)
            {
                buttonSave.Enabled = false;
                dataGridViewExpenses.ReadOnly = !buttonSave.Enabled;
                MessageBox.Show("Entry(ies) Saved!");
            }
            entrySaved = false;

            //if (Properties.Settings.Default.SettingsCurrentCashTray != (int)comboBoxCashTray.SelectedIndex)
            //{
            //    DialogResult result = MessageBox.Show("Dou you want to make this cash tray the current cash tray?", "", MessageBoxButtons.YesNo);
            //    if (result == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        Properties.Settings.Default.SettingsCurrentCashTray = comboBoxCashTray.SelectedIndex;
            //        Properties.Settings.Default.Save();
            //    }

            //}


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

        //numericPad routines
        private bool flagPeriod = false;
        public float resultNumber = 0;

        private void DisplayPad(string c)
        {

            if (String.IsNullOrEmpty(c))
                return;

            labelPad.Text += c;

        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            if (labelPad.Text.Length > 0)
            {
                if (labelPad.Text.EndsWith("."))
                    flagPeriod = false;
                string c = labelPad.Text;
                labelPad.Text = c.Remove(c.Length - 1, 1);
            }
            if (labelPad.Text.Length < 1)
                buttonMinus.Enabled = true;

        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (labelPad.Text.Length > 22)
                return;

            buttonMinus.Enabled = false;

            Button button = (Button)sender;
            string buttonText = "";
            switch (button.Name)
            {
                case "buttonMinus":
                    buttonText = "-";
                    break;
                case "buttonPeriod":
                    if (!flagPeriod)
                    {
                        flagPeriod = true;
                        buttonText = ".";
                    }
                    break;
                default:
                    buttonText = button.Name.Replace("button", "");
                    break;
            }
            DisplayPad(buttonText);

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (dataGridViewExpenses.CurrentRow == null)
            {
                dataGridViewExpenses.CurrentCell = dataGridViewExpenses[0, 0];
                //dataGridViewExpenses.Rows[0].Selected = true;
            }


            if (!String.IsNullOrEmpty(labelPad.Text))
                Single.TryParse(labelPad.Text, out resultNumber);
            //Close();

            dataGridViewExpenses.CurrentRow.Cells[1].Value = resultNumber;
            labelPad.Text = "";

            //string c = dataGridViewExpenses.CurrentRow.Cells[0].Value.ToString();
            //c = c.Replace(",", "");
            //decimal den = Decimal.Parse(c);

            //c = dataGridViewExpenses.CurrentRow.Cells[2].Value.ToString();
            //int count = Int32.Parse(c);

            //dataGridViewExpenses.CurrentRow.Cells[3].Value = String.Format("{0:$##,##0.00}", den * count);

            flagPeriod = false;
        }

        private void comboBoxCashTray_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ignore on startup
            if (flagInicio)
                return;

            buttonSave.Enabled = false;
            int cashTrayID = Convert.ToInt32(comboBoxCashTray.SelectedValue);

            if (!SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, cashTrayID))
                buttonSave.Enabled = true;


        }

    }
}
