
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
    public partial class Float : Form
    {
        //Sac_Setting sac_Setting;
        //Sac_Setting_Sp sac_Setting_Sp;
        int billDispenserId = 0;

        decimal totalCoinAmountInventory = 0;

        Sac_MoneyInventory sac_MoneyInventory;
        Sac_MoneyInventory_Sp sac_MoneyInventory_Sp;

        //private int ClosingEntryID = 0;
        private bool flagInicio = true;
        List<Sol_EntriesDetail> sol_EntriesDetailList;

        //DateTimePicker dateTimePcr;

        private bool flagPeriod = false;
        public int resultNumber = 0;

        private DateTime closingDate;
        private string entryType = "", entryName = "";    //O - Open Cashier F-Float C – Close Cashier E- Expense

        private Sol_Entrie sol_Entrie;
        private Sol_Entrie_Sp sol_Entrie_Sp;
        private Sol_EntriesDetail sol_EntriesDetail;
        private Sol_EntriesDetail_Sp sol_EntriesDetail_Sp;

        public Float(string entryType)
        {
            InitializeComponent();
            this.entryName = entryType;
        }

        private void Float_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void Float_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            // TODO: This line of code loads data into the 'dataSetCashTraysLookup.sol_CashTrays' table. You can move, or remove it, as needed.
            this.sol_CashTraysTableAdapter.Fill(this.dataSetCashTraysLookup.sol_CashTrays);

            sol_Entrie = new Sol_Entrie();
            sol_Entrie_Sp = new Sol_Entrie_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_EntriesDetail = new Sol_EntriesDetail();
            sol_EntriesDetail_Sp = new Sol_EntriesDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            flagInicio = true;
            //current cashtray
            //int currentTray = Properties.Settings.Default.SettingsCurrentCashTray;

            comboBoxCashTray.SelectedValue = Properties.Settings.Default.SettingsCurrentCashTray;
            flagInicio = false;



            dataGridViewFloat.ColumnCount = 9;
            dataGridViewFloat.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridViewFloat.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGridViewFloat.ColumnHeadersDefaultCellStyle.Font =
            //    new Font(dataGridViewFloat.Font, FontStyle.Bold);

            //dataGridViewFloat.Name = "dataGridViewFloat";
            //dataGridViewFloat.Location = new Point(8, 8);
            //dataGridViewFloat.Size = new Size(500, 250);
            dataGridViewFloat.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewFloat.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dataGridViewFloat.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewFloat.GridColor = Color.Black;
            dataGridViewFloat.RowHeadersVisible = false;
            dataGridViewFloat.AllowUserToAddRows = false;

            int index = 0;
            //0
            dataGridViewFloat.Columns[index].Name = "Denomination";
            dataGridViewFloat.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewFloat.Columns[index].Width = 160;
            dataGridViewFloat.Columns[index++].ReadOnly = true;
            //1
            dataGridViewFloat.Columns[index].Name = "Type";
            dataGridViewFloat.Columns[index].Width = 90;
            dataGridViewFloat.Columns[index++].ReadOnly = true;
            //2
            dataGridViewFloat.Columns[index].Name = "Count";
            dataGridViewFloat.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewFloat.Columns[index++].Width = 80;
            //3
            dataGridViewFloat.Columns[index].Name = "Total";
            dataGridViewFloat.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewFloat.Columns[index].Width = 120;
            dataGridViewFloat.Columns[index++].ReadOnly = true;
            //4
            dataGridViewFloat.Columns[index].Name = "CashID";
            dataGridViewFloat.Columns[index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewFloat.Columns[index].Width = 120;
            dataGridViewFloat.Columns[index].ReadOnly = true;
            //dataGridViewFloat.Columns[index++].Visible = false;
            //5
            //CashValue
            dataGridViewFloat.Columns[index].Name = "CashValue";
            dataGridViewFloat.Columns[index].Width = 150;
            //dataGridViewFloat.Columns[index++].Visible = false;
            //6
            //Cash Item value
            dataGridViewFloat.Columns[index].Name = "CashItemValue";
            dataGridViewFloat.Columns[index].Width = 150;
            //dataGridViewFloat.Columns[index++].Visible = false;

            //7
            //Quantity
            dataGridViewFloat.Columns[index].Name = "Quantity";
            dataGridViewFloat.Columns[index].Width = 150;
            //dataGridViewFloat.Columns[index++].Visible = false;

            //8
            //MoneyID
            dataGridViewFloat.Columns[index].Name = "MoneyID";
            dataGridViewFloat.Columns[index].Width = 150;
            //dataGridViewFloat.Columns[index++].Visible = false;


            closingDate = Main.rc.FechaActual;

            readCashDenominations();


            if (entryName == "Open")
            {
                this.Text = "Open Cashier";
                entryType = "O";
                labelTotal1.Text = "Last Closing Value:";
                labelTotal2.Text = "Opening Value:";
                labelTotal3.Text = "";//New Value of Float:";
                labelTotalAmount3.Text = "";

                if (!SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, Properties.Settings.Default.SettingsCurrentCashTray))
                {

                    DialogResult result = MessageBox.Show("The current cash tray is already open. You cannot open it until it is closed. Are you sure you want to continue?", "", MessageBoxButtons.YesNo);
                    if (result != System.Windows.Forms.DialogResult.Yes)
                    {
                        Close();
                        return;
                    }
                    buttonSave.Enabled = false;
                    //buttonUseLastClose.Enabled = false;
                }
                else
                    buttonUseLastClose.Enabled = true;
            }
            else if (entryName == "Float")
            {
                this.Text = "Add Float";
                entryType = "F";
                labelTotal1.Text = "Current Value of Float:";
                labelTotal2.Text = "Amount to add:";
                labelTotal3.Text = "New Value of Float:";
                //comboBoxCashTray.Enabled = false;

                if (SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, Properties.Settings.Default.SettingsCurrentCashTray))
                {
                    buttonSave.Enabled = false;
                    MessageBox.Show("You need to Open a new Cashier before you can add a Float!");
                    //Close();
                    //return;

                }


            }
            else if (entryName == "Close")
            {
                this.Text = "Close Cashier";
                entryType = "C";
                labelTotal1.Text = "Calculated Float:";
                labelTotal2.Text = "Closing Amount Entered:";
                labelTotal3.Text = "Discrepancy:";

                if (Main.Sol_ControlInfo.SacCashTrayID >= 0)
                {
                    if (Main.Sol_ControlInfo.SacCashTrayID == (int)comboBoxCashTray.SelectedIndex)
                    {
                        buttonUseCalculatedInventory.Visible = true;
                    }
                }

                //buttonOpenDrawer.Visible = false;
                //comboBoxCashTray.Enabled = false;

                if (SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, Properties.Settings.Default.SettingsCurrentCashTray))
                {
                    DialogResult result = MessageBox.Show("The current cash tray is already closed. You cannot close it until it is opened. Are you sure you want to continue?", "", MessageBoxButtons.YesNo);
                    if (result != System.Windows.Forms.DialogResult.Yes)
                    {
                        Close();
                        return;
                    }
                    buttonSave.Enabled = false;

                }
            }


            //SAC
            //leer opciones
            //if (sac_Setting_Sp == null)
            //    sac_Setting_Sp = new Sac_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //sac_Setting = sac_Setting_Sp.Select("BillDispenserId");
            //if(sac_Setting != null)
            //    int.TryParse(sac_Setting.SetValue.ToString(), out billDispenserId);
            billDispenserId = 0;
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

        private void readCashDenominations()
        {


            dataGridViewFloat.Rows.Clear();

            ClearForm();

            Sol_CashDenomination sol_CashDenomination = new Sol_CashDenomination();
            Sol_CashDenomination_Sp sol_CashDenomination_Sp = new Sol_CashDenomination_Sp(Properties.Settings.Default.WsirDbConnectionString);
            List<Sol_CashDenomination> sol_CashDenominationList = new List<Sol_CashDenomination>();


            sol_CashDenominationList = sol_CashDenomination_Sp.SelectAll();

            if (sol_CashDenominationList == null
                || sol_CashDenominationList.Count < 1)
            {
                MessageBox.Show("There are no Cash Denominations defined! Please go to Tools -> Cash Denomination option to add them.");
                return;
            }



            string[] str = new string[dataGridViewFloat.ColumnCount];
            foreach (Sol_CashDenomination cd in sol_CashDenominationList)
            {
                if (Main.cashDenominationsType[cd.CashType].Description.ToLower() == "rolls")
                    str[0] = cd.Description;
                else
                    str[0] = String.Format("{0:#,##0.00}", cd.CashValue);
                str[1] = Main.cashDenominationsType[cd.CashType].Description;
                str[2] = "0";   // String.Format("{0,3:##,##0}", dozen);
                str[3] = "$0.00";// container;
                str[4] = cd.CashID.ToString();
                str[5] = cd.CashValue.ToString();
                str[6] = cd.CashItemValue.ToString();
                str[7] = cd.Quantity.ToString();
                str[8] = cd.MoneyID.ToString();

                if (cd.CashType == 2 && cd.CashItemValue <= 0)   //"Rolls"
                {
                    MessageBox.Show("Please, all CashDenomination Rolls types should have the Item Value set, goto Tools -> Cash Denomination option.");
                    this.Close();
                    return;

                }


                dataGridViewFloat.Rows.Add(str);
            }
            dataGridViewFloat.Focus();
            dataGridViewFloat[0, 0].Selected = false;
            dataGridViewFloat[2, 0].Selected = true;
            dataGridViewFloat.CurrentCell = this.dataGridViewFloat[2, 0];
        }

        private void dataGridViewFloat_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
                return;

            int count = 0;
            Int32.TryParse(dataGridViewFloat[e.ColumnIndex, e.RowIndex].Value.ToString(), out count);

            decimal total = CalculateTotalAmount(ref count,
                dataGridViewFloat.Rows[e.RowIndex].Cells[5].Value.ToString(),
                dataGridViewFloat.Rows[e.RowIndex].Cells[6].Value.ToString(),
                dataGridViewFloat.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dataGridViewFloat.Rows[e.RowIndex].Cells[7].Value.ToString(),
                false);

            dataGridViewFloat.Rows[e.RowIndex].Cells[3].Value = String.Format("{0:$##,##0.00}", total);
            CalculateTotals();

        }

        private void dataGridViewFloat_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 2)
                return;

            DataGridViewTextBoxCell cell = dataGridViewFloat[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;

            if (cell != null)
            {
                char[] chars = e.FormattedValue.ToString().ToCharArray();
                foreach (char c in chars)
                {
                    if (char.IsDigit(c) == false)
                    {
                        MessageBox.Show("You have to enter digits only");

                        e.Cancel = true;
                        break;
                    }
                }
            }

        }

        private void CalculateTotals()
        {
            totalCoinAmountInventory = 0;

            string c = labelTotalAmount1.Text;
            c = c.Replace("$", "");
            c = c.Replace(",", "");
            decimal totalAmount1 = Decimal.Parse(c);

            decimal totalAmount2 = 0;
            labelTotalAmount2.Text = String.Format("{0:$##,##0.00}", totalAmount2);

            int j = dataGridViewFloat.Rows.Count;
            if (j < 1)
                return;

            for (int i = 0; i < j; i++)
            {
                //total amount
                c = dataGridViewFloat[3, i].Value.ToString();
                c = c.Replace("$", "");
                c = c.Replace(",", "");
                decimal amount = Decimal.Parse(c);
                totalAmount2 += amount;
                try
                {
                    if (dataGridViewFloat[1, i].Value.ToString() == "Coin"
                        || dataGridViewFloat[1, i].Value.ToString() == "Rolls")
                        totalCoinAmountInventory += amount;
                }
                catch { }


            }

            labelTotalAmount2.Text = String.Format("{0:$##,##0.00}", totalAmount2);

            decimal totalAmount3 = totalAmount1 - totalAmount2;
            if (entryName == "Open")
            {
                //
            }
            else if (entryName == "Float")
            {
                totalAmount3 = totalAmount1 + totalAmount2;
                labelTotalAmount3.Text = String.Format("{0:$##,##0.00}", totalAmount3);
            }
            else if (entryName == "Close")
            {
                totalAmount3 = totalAmount1 - totalAmount2;
                labelTotalAmount3.Text = String.Format("{0:$##,##0.00}", totalAmount3);
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //total amount
            string c = labelTotalAmount2.Text;
            c = c.Replace("$", "");
            c = c.Replace(",", "");

            decimal totalAmount = 0;
            Decimal.TryParse(c, out totalAmount);

            if (totalAmount <= 0)
            {
                MessageBox.Show("Nothing to save!");
                return;
            }

            //save entry
            sol_Entrie = new Sol_Entrie();
            sol_Entrie.EntryType = entryType;
            MembershipUser membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exist, cannot save this entry");
                return;
            }
            sol_Entrie.UserID = (Guid)membershipUser.ProviderUserKey;
            sol_Entrie.UserName = Properties.Settings.Default.UsuarioNombre;

            sol_Entrie.Date = Main.rc.FechaActual; // Properties.Settings.Default.FechaActual;
            sol_Entrie.CashTrayID = Convert.ToInt32(comboBoxCashTray.SelectedValue); //Properties.Settings.Default.SettingsCurrentCashTray;
            sol_Entrie.ExpenseTypeID = 0; //<none>
            sol_Entrie.Amount = totalAmount;

            Sac_MoneyInventory sac_MoneyInventory;
            Sac_MoneyInventory_Sp sac_MoneyInventory_Sp = new Sac_MoneyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Sac_ClientName sac_ClientName = new Sac_ClientName();
            Sac_ClientName_Sp sac_ClientName_Sp = new Sac_ClientName_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //get sac clientID if we are using sac cashtray
            string bdd = Properties.Settings.Default.SQLBaseDeDatos;
            if (Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.BaseDeDatosPrincipal
                && Main.Sol_ControlInfo.SacCashTrayID >= 0)
            {
                //Sac_ClientName sac_ClientName = new Sac_ClientName();
                //Sac_ClientName_Sp sac_ClientName_Sp = new Sac_ClientName_Sp(Properties.Settings.Default.WsirDbConnectionString);
                //get sac's clientID
                sac_ClientName = sac_ClientName_Sp.SelectByCashTrayID(Main.Sol_ControlInfo.SacCashTrayID);
                if (sac_ClientName == null)
                {
                    MessageBox.Show("SAC's Client Not Found!\r\n" +
                        "Goto SAC -> Settings -> FrontScreen and select a Cash Tray."
                        );
                    return;
                }

                //update coin amount inventory if we are using sac cashtray
                if (sol_Entrie.CashTrayID == Main.Sol_ControlInfo.SacCashTrayID)
                {
                    // search for active clientID using the CashTrayID in Sac_ClienNames
                    //sac_ClientName = sac_ClientName_Sp.SelectByCashTrayID(Main.Sol_ControlInfo.SacCashTrayID);
                    if (!String.IsNullOrEmpty(sac_ClientName.ClientID))
                    {
                        //clientID = sac_ClientName.ClientID;
                        if (entryName == "Open")
                            sac_ClientName.CoinAmountInventory = totalCoinAmountInventory;
                        else if (entryName == "Float")
                            sac_ClientName.CoinAmountInventory += totalCoinAmountInventory;
                        else if (entryName == "Close")
                            sac_ClientName.CoinAmountInventory = 0;
                        sac_ClientName_Sp.Update(sac_ClientName);
                    }
                }
            }


            decimal decimalAmount = 0;
            if (entryName == "Close")
            {
                c = labelTotalAmount3.Text;
                c = c.Replace("$", "");
                c = c.Replace(",", "");
                Decimal.TryParse(c, out decimalAmount);
                sol_Entrie.DiscrepancyAmount = decimalAmount;    // Decimal.Parse(c);
            }
            else
                sol_Entrie.DiscrepancyAmount = 0.0m;


            sol_Entrie_Sp.Insert(sol_Entrie);

            //clear form
            //decimal totalAmount2 = 0;
            //labelTotalAmount2.Text = String.Format("{0:$##,##0.00}", totalAmount2);

            int j = dataGridViewFloat.Rows.Count;
            if (j < 1)
                return;

            sol_EntriesDetail = new Sol_EntriesDetail();
            int intValue = 0;
            int count = 0;
            decimal cashValue = 0;
            decimal cashItemValue = 0;
            int quantity = 0;
            int moneyID = -1;

            for (int i = 0; i < j; i++)
            {
                sol_EntriesDetail.EntryID = sol_Entrie.EntryID;
                sol_EntriesDetail.EntryType = sol_Entrie.EntryType;


                //CashID (Sol_CashDenomination)
                try
                {
                    c = dataGridViewFloat[4, i].Value.ToString();
                    Int32.TryParse(c, out intValue);
                }
                catch
                {
                    intValue = 0;
                }
                sol_EntriesDetail.CashID = intValue; // Convert.ToInt32(dataGridViewFloat[4, i].Value);

                //Count
                try
                {
                    c = dataGridViewFloat[2, i].Value.ToString();
                    Int32.TryParse(c, out count);
                }
                catch
                {
                    count = 0;
                }

                sol_EntriesDetail.Count = count;  // Convert.ToInt32(dataGridViewFloat[2, i].Value);

                //CashValue
                try
                {
                    c = dataGridViewFloat[5, i].Value.ToString();
                    decimal.TryParse(c, out cashValue);
                }
                catch
                {
                    cashValue = 0;
                }

                //CashItemValue
                try
                {
                    c = dataGridViewFloat[6, i].Value.ToString();
                    decimal.TryParse(c, out cashItemValue);
                }
                catch
                {
                    cashItemValue = 1;
                }

                //Quantity
                try
                {
                    c = dataGridViewFloat[7, i].Value.ToString();
                    int.TryParse(c, out quantity);
                }
                catch
                {
                    quantity = 1;
                }

                //MoneyID
                try
                {
                    c = dataGridViewFloat[8, i].Value.ToString();
                    int.TryParse(c, out moneyID);
                }
                catch
                {
                    moneyID = 1;
                }

                if (dataGridViewFloat[1, i].Value.ToString() == "Rolls")
                    count *= quantity;

                //sol_EntriesDetail.Count = count;  // Convert.ToInt32(dataGridViewFloat[2, i].Value);
                sol_EntriesDetail_Sp.Insert(sol_EntriesDetail);

                //if (entryName == "Close")
                //    continue;

                //if we are using sac cashtray update money inventory
                if (Main.Sol_ControlInfo.SacCashTrayID >= 0)
                {
                    if (Main.Sol_ControlInfo.SacCashTrayID == (int)comboBoxCashTray.SelectedIndex)
                    {
                        //sac_MoneyInventory.
                        if (String.IsNullOrEmpty(sac_ClientName.ClientID))
                            continue;

                        sac_MoneyInventory = sac_MoneyInventory_Sp.Select(sac_ClientName.ClientID, moneyID, billDispenserId);
                        if (sac_MoneyInventory == null)
                            continue;

                        if (entryName == "Open")
                        {
                            sac_MoneyInventory.Inventory += count;
                        }
                        else if (entryName == "Float")
                        {
                            sac_MoneyInventory.Inventory += count;
                        }
                        else //if (entryName == "Float")
                        {
                            sac_MoneyInventory.Inventory = 0;
                        }
                        sac_MoneyInventory_Sp.Update(sac_MoneyInventory);

                    }
                }
            }

            //MessageBox.Show("Entry Saved!");
            buttonSave.Enabled = false;
            buttonSave.Text = "Saved";
            dataGridViewFloat.Columns["Count"].ReadOnly = !buttonSave.Enabled;
            comboBoxCashTray.Enabled = false;
            buttonUseLastClose.Enabled = false;
            //readCashDenominations();
            //ClearForm();

            if (Properties.Settings.Default.SettingsCurrentCashTray != (int)comboBoxCashTray.SelectedIndex)
            {
                DialogResult result = MessageBox.Show("Do you want to make this cash tray the current cash tray?", "", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Properties.Settings.Default.SettingsCurrentCashTray = Convert.ToInt32(comboBoxCashTray.SelectedValue); //comboBoxCashTray.SelectedIndex;
                    Properties.Settings.Default.Save();
                }

            }
        }

        private void buttonOpenDrawer_Click(object sender, EventArgs e)
        {

            PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);
            if (Properties.Settings.Default.SettingsWsTicketOpenDrawerSendTwice)
                PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);


        }

        //clear form
        private void ClearForm()
        {
            decimal InitialAmount = 0;

            if (entryName == "Open")
            {
                //ClosingValue
                InitialAmount = sol_Entrie_Sp.GetLastClosingValue(Properties.Settings.Default.SettingsCurrentCashTray);
            }
            else if (entryName == "Float")
            {
                //MessageBox.Show(Properties.Settings.Default.WsirDbConnectionString);
                //MessageBox.Show(Properties.Settings.Default.SettingsCurrentCashTray.ToString());
                InitialAmount = sol_Entrie_Sp.GetValueOfFloat(Properties.Settings.Default.SettingsCurrentCashTray, -1);
                //MessageBox.Show(InitialAmount.ToString());
            }
            else if (entryName == "Close")
            {
                //InitialAmount = sol_Entrie_Sp.GetValueOfFloat(- 1, ClosingEntryID);
                InitialAmount = sol_Entrie_Sp.GetValueOfFloat(Properties.Settings.Default.SettingsCurrentCashTray, -1);

            }
            labelTotalAmount1.Text = String.Format("{0:$##,##0.00}", InitialAmount);

            int j = dataGridViewFloat.Rows.Count;
            if (j < 1)
                return;

            for (int i = 0; i < j; i++)
            {
                dataGridViewFloat[2, i].Value = "0";
                dataGridViewFloat[3, i].Value = "$0.00";

            }

        }

        private void comboBoxCashTray_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ignore on startup
            if (flagInicio)
                return;

            buttonSave.Enabled = false;
            buttonUseLastClose.Enabled = false;
            int cashTrayID = Convert.ToInt32(comboBoxCashTray.SelectedValue);

            if (entryName == "Open")
            {
                if (SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, cashTrayID))
                {
                    buttonSave.Enabled = true;
                    buttonUseLastClose.Enabled = true;
                }

            }
            else if (entryName == "Float")
            {
                if (!SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, cashTrayID))
                    buttonSave.Enabled = true;
            }
            else if (entryName == "Close")
            {
                if (!SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, cashTrayID))
                    buttonSave.Enabled = true;
            }

            //if (!SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, cashTrayID))
            //{
            //    MessageBox.Show("You need to Close the Cashier before you can Open a new one!\n"+
            //        "Change the Default CashTray in Settings to Close it!");
            //    comboBoxCashTray.SelectedValue = Properties.Settings.Default.SettingsCurrentCashTray;
            //    return;

            //}

            //Properties.Settings.Default.SettingsCurrentCashTray = comboBoxCashTray.SelectedIndex;
            //Properties.Settings.Default.Save();

        }

        private void buttonUseLastClose_Click(object sender, EventArgs e)
        {
            if (sol_Entrie == null)
            {
                MessageBox.Show("No previous close found!");
                return;
            }

            sol_EntriesDetailList = sol_EntriesDetail_Sp.SelectAllByEntryIDType(sol_Entrie.EntryID, sol_Entrie.EntryType);
            if (sol_EntriesDetailList == null)
            {
                MessageBox.Show("No data found!");
                return;
            }

            string c;
            int i = 0;
            foreach (Sol_EntriesDetail ed in sol_EntriesDetailList)
            {
                int count = ed.Count;
                decimal cashValue = 0;

                //CashValue
                try
                {
                    c = dataGridViewFloat[5, i].Value.ToString();
                    decimal.TryParse(c, out cashValue);
                }
                catch
                {
                    cashValue = 0;
                }

                dataGridViewFloat[3, i].Value = String.Format("{0:$##,##0.00}", count * cashValue);
                dataGridViewFloat[2, i++].Value = count;

            }
            CalculateTotals();
            buttonUseLastClose.Enabled = false;
        }

        private void buttonUseCalculatedInventory_Click(object sender, EventArgs e)
        {
            //sac_MoneyInventory;
            sac_MoneyInventory_Sp = new Sac_MoneyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);
            string c;
            int j = dataGridViewFloat.Rows.Count;
            if (j < 1)
                return;


            Sac_ClientName sac_ClientName = new Sac_ClientName();
            if (Main.Sol_ControlInfo.SacCashTrayID >= 0)
            {
                Sac_ClientName_Sp sac_ClientName_Sp = new Sac_ClientName_Sp(Properties.Settings.Default.WsirDbConnectionString);
                //get sac's clientID
                sac_ClientName = sac_ClientName_Sp.SelectByCashTrayID(Main.Sol_ControlInfo.SacCashTrayID);
            }

            int moneyID = 0;
            decimal cashValue = 0;
            for (int i = 0; i < j; i++)
            {

                if (dataGridViewFloat[1, i].Value.ToString() == "Rolls")
                    continue;

                //MoneyID
                try
                {
                    c = dataGridViewFloat[8, i].Value.ToString();
                    Int32.TryParse(c, out moneyID);
                }
                catch
                {
                    continue;
                }


                if (String.IsNullOrEmpty(sac_ClientName.ClientID))
                    continue;



                sac_MoneyInventory = sac_MoneyInventory_Sp.Select(sac_ClientName.ClientID, moneyID, billDispenserId);
                if (sac_MoneyInventory == null)
                    continue;

                //CashValue
                try
                {
                    c = dataGridViewFloat[5, i].Value.ToString();
                    decimal.TryParse(c, out cashValue);
                }
                catch
                {
                    cashValue = 0;
                }
                //Save Count
                try
                {
                    dataGridViewFloat[2, i].Value = (int)sac_MoneyInventory.Inventory;  // count;
                }
                catch
                {
                    continue;
                }

                dataGridViewFloat[3, i].Value = String.Format("{0:$##,##0.00}", sac_MoneyInventory.Inventory * cashValue);
            }

            CalculateTotals();
            buttonUseCalculatedInventory.Visible = false;

        }

        //move to next row (goto)
        private delegate void OverrideFocusDelegate(DataGridViewCell cell);
        private void OverrideFocus(DataGridViewCell cell)
        {
            int rowCount = dataGridViewFloat.Rows.Count;
            try
            {
                if (cell.RowIndex + 1 < rowCount)
                    dataGridViewFloat.CurrentCell = dataGridViewFloat[cell.ColumnIndex, cell.RowIndex + 1];
            }
            catch { }
        }



        private decimal CalculateTotalAmount(
            ref int count,
            string sCashValue,
            string sCashItemValue,
            string sType,
            string sQuantity,
            bool reverse)
        {

            //int intValue = 0;
            decimal cashValue = 0;
            decimal cashItemValue = 0;
            decimal total = 0;
            int quantity = 0;

            //CashValue
            decimal.TryParse(sCashValue, out cashValue);

            //CashItemValue
            decimal.TryParse(sCashItemValue, out cashItemValue);

            //Quantity
            int.TryParse(sQuantity, out quantity);

            //rolls
            if (sType == "Rolls")
            {
                if (quantity == 0) quantity = 1;
                if (reverse)
                {
                    count /= quantity;
                    total = cashValue * count;

                }
                else
                {
                    count *= quantity;
                    total = cashItemValue * count;
                }
            }
            else
                total = cashItemValue * count;

            return total;

        }

        #region NumericPad

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
            if (dataGridViewFloat.CurrentCell.ColumnIndex != 2)
            {
                dataGridViewFloat.CurrentCell = dataGridViewFloat.CurrentRow.Cells[2];
                dataGridViewFloat.CurrentRow.Cells[2].Selected = true;


            }

            resultNumber = 0;
            if (!String.IsNullOrEmpty(labelPad.Text))
                Int32.TryParse(labelPad.Text, out resultNumber);
            //Close();

            labelPad.Text = "";
            dataGridViewFloat.CurrentCell.Value = resultNumber;

            int count = resultNumber;
            decimal total = CalculateTotalAmount(ref count,
                dataGridViewFloat.CurrentRow.Cells[5].Value.ToString(),
                dataGridViewFloat.CurrentRow.Cells[6].Value.ToString(),
                dataGridViewFloat.CurrentRow.Cells[1].Value.ToString(),
                dataGridViewFloat.CurrentRow.Cells[7].Value.ToString(),
                false);
            dataGridViewFloat.CurrentRow.Cells[3].Value = String.Format("{0:$##,##0.00}", total);
            CalculateTotals();

            //para elegir siguiente renglon
            DataGridViewCell cell = dataGridViewFloat.Rows[dataGridViewFloat.CurrentRow.Index].Cells[dataGridViewFloat.CurrentCell.ColumnIndex];
            this.BeginInvoke(new OverrideFocusDelegate(OverrideFocus), cell);

        }

        #endregion

    }
}
