
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
    public partial class CustomerOrdersPayNow : Form
    {
        public short paymentType { get; set; }  //-1 = both, 0 = cash, 1= check

        int customerId;
        public bool ordersProcessed = false;
        public ListView.CheckedListViewItemCollection checkedItems;

        public CustomerOrdersPayNow(int CustomerId)
        {
            InitializeComponent();
            customerId = CustomerId;
            paymentType = -1;
        }

        private void CustomerOrdersPayNow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCashTraysLookup.sol_CashTrays' table. You can move, or remove it, as needed.
            this.sol_CashTraysTableAdapter.Fill(this.dataSetCashTraysLookup.sol_CashTrays);
            if (Properties.Settings.Default.TouchOriented)
            {
                //this.Height = this.Height + (OK.Height) + 150;
                //OK.Height = OK.Height * 2;
                //buttonSelectAll.Height = buttonSelectAll.Height * 2;
                //buttonRefresh.Height = buttonRefresh.Height * 2;
                //Cancel.Height = Cancel.Height * 2;
                this.radioButtonCheckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBoxCheckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.radioButtonCashTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.comboBoxCashTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBoxReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                toolStripButtonVirtualKb.Visible = true;
                //this.CenterToParent();
            }

            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //check cashier is open
            radioButtonCashTray.Enabled = SolFunctions.CheckCashier();
            comboBoxCashTray.Enabled = radioButtonCashTray.Enabled;

            radioButtonCheckNumber.Checked = true;

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Order #", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Amount", 75, HorizontalAlignment.Center);
            listView1.Columns.Add("", 0, HorizontalAlignment.Center);
            listView1.Columns.Add("", 0, HorizontalAlignment.Center);
            listView1.Columns.Add("Type", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Fee", 75, HorizontalAlignment.Center);

            DisplayOrders();

            if (paymentType == 0)    //cash
            {
                radioButtonCheckNumber.Enabled = false;
                radioButtonCheckNumber.Checked = false;
                textBoxCheckNumber.Enabled = false;

                radioButtonCashTray.Enabled = true;
                radioButtonCashTray.Checked = true;
                comboBoxCashTray.Enabled = true;
                textBoxReference.Enabled = true;

            }
            else if(paymentType == 1)    // check
            {
                radioButtonCheckNumber.Enabled = true;
                radioButtonCheckNumber.Checked = true;
                textBoxCheckNumber.Enabled = true;

                radioButtonCashTray.Enabled = false;
                radioButtonCashTray.Checked = false;
                comboBoxCashTray.Enabled = false;
                textBoxReference.Enabled = false;
            }


        }

        private void DisplayOrders()
        {
            listView1.Items.Clear();
            string[] str = new string[6];
            ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in checkedItems)
            {
                str[0] = item.SubItems[0].Text;
                str[1] = item.SubItems[1].Text;

                str[2] = "";     //7
                str[3] = "";     //6

                str[4] = item.SubItems[4].Text;     //6     //3
                str[5] = item.SubItems[5].Text;     //7     //2

                itm = new ListViewItem(str);
                listView1.Items.Add(itm);

            }

            totals();


        }

        private void totals()
        {
            string c = "";
            decimal totalSelectedOrders = 0, totalSelectedOrdersSales = 0;

            //items
            ListView.ListViewItemCollection Items = listView1.Items;
            foreach (ListViewItem item in Items)
            {
                //amount
                c = item.SubItems[1].Text;
                c = c.Replace('$', ' ');
                c = c.Replace('(', ' ');
                c = c.Replace(')', ' ');
                decimal amount = Convert.ToDecimal(c);
                //fee
                c = item.SubItems[5].Text;
                c = c.Replace('$', ' ');
                c = c.Replace('(', ' ');
                c = c.Replace(')', ' ');
                decimal fee = Convert.ToDecimal(c);
                if (item.SubItems[4].Text == "R")   //3
                    totalSelectedOrders = totalSelectedOrders + amount - fee;
                else
                    totalSelectedOrdersSales = totalSelectedOrdersSales + amount - fee;

            }

            c = String.Format(
                "Amount:\n\r" +
                "\n\rReturns:" + SirLib.Funciones.Indent(6) + "{0,9:($##,##0.00)}", // +
                //"\n\rSales:" + SirLib.Funciones.Indent(9) + "{1,9:$##,##0.00}",
                totalSelectedOrders,
                totalSelectedOrdersSales
                );
            labelTotalSelectedOrders.Text = c;

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

        private void radioButtonCheckNumber_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = radioButtonCheckNumber.Checked;
            textBoxCheckNumber.Enabled = flag;
            comboBoxCashTray.Enabled = !flag;
            textBoxReference.Enabled = !flag;

            errorProvider1.SetError(textBoxCheckNumber, "");
            errorProvider1.SetError(comboBoxCashTray, "");

            //buttonReOpenDrawer.Enabled = !flag;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            //check data
            if (radioButtonCheckNumber.Checked)
            {
                //check number
                textBoxCheckNumber.Text = textBoxCheckNumber.Text.Trim();
                if (!Funciones.ValidateText(textBoxCheckNumber, ref errorProvider1))
                {
                    textBoxCheckNumber.Focus();
                    return;
                }
            }
            else
            {
                ////check cashier is open
                //if (!Cashier.CheckCashier())
                //    return;


                if (!Funciones.ValidateText(comboBoxCashTray, ref errorProvider1))
                {
                    comboBoxCashTray.Focus();
                    return;
                }
            }

            //busy cursor
            this.Cursor = Cursors.WaitCursor;

            //update orders
            UpdateOrders();

            ordersProcessed = true;


            buttonRePrint.Enabled = true;
            //printing is optional
            //if (!Main.Sol_ControlInfo.CashOutPrintingOverride)
            //{
            //    buttonRePrint.PerformClick();
            //}

            //open drawer
            if (radioButtonCashTray.Checked)
            {
                //OpenDrawer();
                PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);
            }


            buttonContinue.Text = "&Close";
            this.buttonContinue.Click -= new System.EventHandler(this.buttonContinue_Click);
            this.buttonContinue.Click += new System.EventHandler(this.Cancel_Click);

            //buttonRePrint.Enabled = true;
            buttonReOpenDrawer.Enabled = radioButtonCashTray.Checked;

            Cancel.Enabled = false;

            this.Cursor = Cursors.Default;

        }

        private void buttonRePrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string errorMessage = string.Empty;
            bool flag = SolFunctions.PrintReceipt(
                listView1, "paynow"
                , ref errorMessage, Properties.Settings.Default.BarcodeEncoding
                    , "RePrint"
                    , String.Empty
                    , 0.0m
                );
            if (!flag)
            {
                MessageBox.Show("There was a problem printing the receipt, please try again.\nError: "+errorMessage);
            }
            
            this.Cursor = Cursors.Default;

        }

        private void buttonReOpenDrawer_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void UpdateOrders()
        {
            //bool firstTime = true;
            int orderId = 0;
            string orderType = "";

            Sol_Order sol_Order = new Sol_Order();
            Sol_Order_Sp sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Sol_OrdersDetail sol_OrdersDetail = new Sol_OrdersDetail();
            Sol_OrdersDetail_Sp sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);
            List<Sol_OrdersDetail> sol_OrdersDetailList = new List<Sol_OrdersDetail>();

            //items
            ListView.ListViewItemCollection Items = listView1.Items;
            foreach (ListViewItem item in Items)
            {
                if (!Int32.TryParse(item.SubItems[0].Text, out orderId))
                {
                    MessageBox.Show("We couldn't parse Order " + item.SubItems[0].Text);
                    continue;
                }

                orderType = item.SubItems[4].Text;

                //read order
                sol_Order = sol_Order_Sp.Select(orderId, orderType);

                //not found?
                if (sol_Order == null)
                {
                    MessageBox.Show(String.Format("Order #{0} not found!", orderId));
                    continue;
                }

                //search for customer data if its on account
                //Sol_Customer_Sp sol_Customer_Sp = new Sol_Customer_Sp(Properties.Settings.Default.WsirDbConnectionString);
                //Sol_Customer  sol_Customer = sol_Customer_Sp.Select(customerId);
                //sol_Order.CustomerID = customerId;
                //sol_Order.Name = sol_Customer.Name;
                //sol_Order.Address1 = sol_Customer.Address1;
                //sol_Order.Address2 = sol_Customer.Address2;
                //sol_Order.City = sol_Customer.City;
                //sol_Order.Province = sol_Customer.Province;
                //sol_Order.Country = sol_Customer.Country;
                //sol_Order.PostalCode = sol_Customer.PostalCode;

                //check number
                if (radioButtonCheckNumber.Checked)
                {
                    sol_Order.Reference = textBoxCheckNumber.Text;
                    sol_Order.PaymentTypeID = 1;
                }
                else
                {
                    sol_Order.Reference = textBoxReference.Text;
                    //sol_Order.Status = "P"; //paid, cash  //we know is paid by checking datepaid field
                    sol_Order.CashTrayID = (int)comboBoxCashTray.SelectedValue;
                    sol_Order.PaymentTypeID = 2;
                }

                ////close order if it is not
                //if (sol_Order.DateClosed < sol_Order.Date)
                //    sol_Order.DateClosed = Main.rc.FechaActual;

                sol_Order.DatePaid = Main.rc.FechaActual;

                sol_Order_Sp.Update(sol_Order);

                //close order if it is not
                if (sol_Order.DateClosed < sol_Order.Date)
                    sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");

                sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DatePaid");


                //mark details if paid with cash
                if (radioButtonCashTray.Checked)
                {
                    sol_OrdersDetailList = sol_OrdersDetail_Sp._SelectAllByOrderID_OrderType(orderId, orderType);
                    foreach (Sol_OrdersDetail od in sol_OrdersDetailList)
                    {
                        sol_OrdersDetail = sol_OrdersDetail_Sp.Select(od.DetailID);
                        sol_OrdersDetail.Status = sol_Order.Status;
                        sol_OrdersDetail_Sp.Update(sol_OrdersDetail);
                    }
                }

            }

        }


    }
}
