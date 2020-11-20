
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;

using System.Data.SqlClient;

using BarcodeLib;
using Solum.App_Code;

namespace Solum
{

    public partial class CashierCash : Form
    {
        decimal totalAmount = 0;
        decimal totalFees = 0;
        decimal totalSales = 0;

        #region CardLink Variables

        //Sol_OrderCardLink sol_OrderCardLink;
        Sol_OrderCardLink_Sp sol_OrderCardLink_Sp;
        Sol_OrderCardLog sol_OrderCardLog;
        Sol_OrderCardLog_Sp sol_OrderCardLog_Sp;
        public string strCardNumber { get; set; }

        #endregion

        //public static string securityCode;
        string securityCode;

        #region tflex coin dispenser variables
        public static AxCOINUSBLib.AxCoinUSB AxCoinUSB2;
        public static short SUCCESS = 1;      //1 = success if a function worked
        #endregion

        public string qdCustomerName { get; set; }
        public string strOrderType { get; set; }

        decimal totalPaidOrders = 0;

        //public static decimal totalSelectedOrders = 0;
        public decimal totalSelectedOrders { get; set; }

        //public static string buttonSource;
        public string buttonSource { get; set; }

        //private BarCodeCtrl userControl11;
        
        private int customerId =0;
        public bool onAccount = false;
        public bool BottleDrop = false;
        public string BottleDropCustomer = "";
        public string BottleDropBagID = "";
        public List<BottleDropOrderDetail> BottleDropOrderDetails = null;
        public bool ordersProcessed = false;

        public ListView.CheckedListViewItemCollection checkedItems { get; set; }

        public CashierCash()
        {
            InitializeComponent();
            //buttonSource = "";
            strCardNumber = String.Empty;
            qdCustomerName = String.Empty;
            strCardNumber = String.Empty;

            buttonSource = String.Empty;
            securityCode = String.Empty;
            totalSelectedOrders = 0.0m;

        }

        private void CashierCash_Load(object sender, EventArgs e)
        {
            //if not onAccount, use coin dispenser if there is one
            if (!onAccount)
            {
                bool flag = Properties.Settings.Default.CoinDispenserEnabled;
                groupBoxCoinDispenser.Visible = flag;
                if (!flag)
                    listView1.Dock = DockStyle.Fill;
                else
                    InitializeDevice();
            }
            else
            {
                labelCustomer.Visible = true;
                listView1.Dock = DockStyle.Fill;
                buttonSelectCustomer.BackColor = Color.FromArgb(30, 145, 214);
               // buttonSelectCustomer.ForeColor = Color.FromArgb(53, 164, 212);
            }
            UpdateButtonVisibility();

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Order #", 85, HorizontalAlignment.Center);
            listView1.Columns.Add("Amount", 88, HorizontalAlignment.Center);
            listView1.Columns.Add("", 0, HorizontalAlignment.Center);
            listView1.Columns.Add("", 0, HorizontalAlignment.Center);
            listView1.Columns.Add("Type", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Fee", 80, HorizontalAlignment.Center);

            //listView1.Width = 300;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            if (BottleDrop)
            {
                buttonContinue.Enabled = true;
                buttonRePrint.Enabled = false;
                buttonReOpenDrawer.Enabled = false;
                buttonSelectCustomer.Enabled = false;
                buttonViewReceipt.Enabled = false;
                labelCustomer.Visible = true;
                labelCustomerName.Text = BottleDropCustomer;
                bottleDropLogoPanel.Visible = true;
                customerId = Properties.Settings.Default.BottleDropLocalAccountNumer;

            }
            else {
            buttonContinue.Enabled = !onAccount;
            buttonSelectCustomer.Enabled = onAccount;
            }
            if (!string.IsNullOrEmpty(qdCustomerName))
            {
                labelCustomer.Visible = true;
                labelCustomerName.Text = qdCustomerName;
            }


            DisplayOrders();
        }

        private void CashierCash_FormClosing(object sender, FormClosingEventArgs e)
        {
            //((IDisposable)AxCoinUSB2).Dispose(); 
            if (Main.CustomerScreenForm != null)
            {
                CustomerScreen.listViewReturns.Items.Clear();
                CustomerScreen.labelTotalQty.Text = String.Format("SubTotal:");
                CustomerScreen.labelTotalAmt.Text = String.Format("Total:");
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

                //if (Main.CustomerScreenForm != null)
                //{
                //    CustomerScreen.listViewReturns.Items.Add((ListViewItem)itm.Clone());

                //    //scroll to last item automatically
                //    //CustomerScreen.listViewReturns.EnsureVisible(CustomerScreen.listViewReturns.Items.Count - 1);
                //    //CustomerScreen.listViewReturns.Update();


                //}

            }

            totals();

            if (Main.CustomerScreenForm != null
                && CustomerScreen.customerScreenSourceForm == "Cashier"
                )
            {
                displayDetails("R");
                displayDetails("S");

                if (Main.CustomerScreenForm != null)
                {
                    CustomerScreen.labelTotalQty.Text = String.Format(
                        "Returns:" + SirLib.Funciones.Indent(1) + "{0,10:$##,##0.00}"
                        + "\nFees:" + SirLib.Funciones.Indent(6) + "{1,10:($##,##0.00)}"
                        + "\nSales:" + SirLib.Funciones.Indent(5) + "{2,10:($##,##0.00)}"
                        , totalAmount
                        , totalFees
                        , totalSales
                        );


                    CustomerScreen.labelTotalAmt.Text = String.Format(
                        "Total:"
                        + "\n" + SirLib.Funciones.Indent(2) + "{0,9:$##,##0.00}"
                        , (totalAmount-totalFees-totalSales)    //totalSelectedOrders
                        );


                    //string totalQty = String.Format("Quantity:\r\n " + Funciones.Indent(20) + "{0,3}", totalqty);
                    //string totalAmt = String.Format("Amount:\r\n" + Funciones.Indent(8) + "{0,10:$##,##0.00}", totalSelectedOrders);

                    //CustomerScreen.labelTotalQty.Text = totalQty;
                    //CustomerScreen.labelTotalAmt.Text = totalAmt;

                }


            }


            //select last item, if any
            int index = listView1.Items.Count - 1;
            if (index >= 0)
            {
                listView1.Items[index].Selected = true;
                listView1.Focus();
            }

        }


        private void displayDetails(string orderType)
        {
            string strOrderId, strOrderType;
            string query = String.Empty;
            bool firstTime = true;
            ListView.ListViewItemCollection Items;
            switch (orderType)
            {
                case "R":   //returns

                    //string c = "";
                    query =
                        @"
                    SELECT 
	                    SUM(od.[Quantity]) as Quantity,
	                    c.[Description],
	                    MAX(od.[Price]) as Price,
	                    SUM(od.[Quantity]) * MAX(od.[Price]) as Total
                    FROM [sol_OrdersDetail] as od
                    INNER JOIN [Sol_Categories] as c ON od.[CategoryID] = c.[CategoryID]
                    WHERE od.[OrderType] = 'R' ";

                    //items
                    firstTime = true;
                    Items = listView1.Items;
                    foreach (ListViewItem item in Items)
                    {
                        //orderId
                        strOrderId = item.SubItems[0].Text.Trim();
                        strOrderType = item.SubItems[4].Text;
                        if (strOrderType != orderType)
                            continue;

                        if (firstTime)
                        {
                            query += "AND (od.[OrderID] = " + strOrderId + " ";
                            firstTime = false;
                        }
                        else
                            query += "OR od.[OrderID] = " + strOrderId + " ";
                    }

                    if (firstTime)
                        break;

                    query +=
                        @")
                        GROUP BY c.[Description]
                        ORDER BY c.[Description] ASC
                        ";
                    break;
                case "S":   //sales
                    query =
                        @"
                    SELECT 
	                    SUM(od.[Quantity]) as Quantity,
	                    p.[ProDescription] as Description,
	                    MAX(od.[Price]) as Price,
	                    (SUM(od.[Quantity]) * MAX(od.[Price])) * -1 as Total
                    FROM [sol_OrdersDetail] as od
                    INNER JOIN [sol_Products] as p ON p.[ProductID] = od.[ProductID]
                    WHERE od.[OrderType] = 'S' ";

                    //items
                    firstTime = true;
                    Items = listView1.Items;
                    foreach (ListViewItem item in Items)
                    {
                        //orderId
                        strOrderId = item.SubItems[0].Text.Trim();
                        strOrderType = item.SubItems[4].Text;
                        if (strOrderType != orderType)
                            continue;

                        if (firstTime)
                        {
                            query += "AND (od.[OrderID] = " + strOrderId + " ";
                            firstTime = false;
                        }
                        else
                            query += "OR od.[OrderID] = " + strOrderId + " ";
                    }

                    if (firstTime)
                        break;

                    query +=
                        @")
                        GROUP BY p.[ProDescription]
                        ORDER BY p.[ProDescription] ASC
                        ";

                    break;
                default:
                    break;

            }

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                addItem((int)reader["Quantity"], reader["Description"].ToString(), (decimal)reader["Price"], (decimal)reader["Total"]);
                        }
                    }
                }
                catch
                {
                    return;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private bool addItem(int quantity, string description, decimal price, decimal total)
        {
            string[] str = new string[4];
            ListViewItem itm;   // = new ListViewItem();
            //formatting numbers
            str[0] = String.Format("{0,3}", quantity);
            str[1] = description;
            str[2] = String.Format("{0,6:##0.00}", price);
            str[3] = String.Format("{0,8:#,##0.00}", total);
            itm = new ListViewItem(str);
            CustomerScreen.listViewReturns.Items.Add(itm);

            //scroll to last item automatically
            CustomerScreen.listViewReturns.EnsureVisible(CustomerScreen.listViewReturns.Items.Count - 1);
            CustomerScreen.listViewReturns.Update();

            return true;
        }

        private void totals()
        {
            string c = "";
            //totalSelectedOrders = 0;
            //decimal totalSelectedOrdersSales = 0;
            totalFees = 0;
            totalAmount = 0;
            totalSales = 0;
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

                if(item.SubItems[4].Text == "R")
                    totalAmount += amount;
                else
                    totalSales += amount;

                //fee
                c = item.SubItems[5].Text;
                c = c.Replace('$', ' ');
                c = c.Replace('(', ' ');
                c = c.Replace(')', ' ');
                decimal fee = Convert.ToDecimal(c);
                totalFees += fee;



                //if (item.SubItems[4].Text == strOrderType)   //3
                //    totalSelectedOrders = totalSelectedOrders + amount-fee;
                //else
                //    totalSelectedOrdersSales = totalSelectedOrdersSales + amount-fee;

            }

            c = String.Format(
                "Returns:" + SirLib.Funciones.Indent(9) + "{0,10:$##,##0.00}" 
                + "\nFees:" + SirLib.Funciones.Indent(15) + "{1,10:($##,##0.00)}"
                + "\nSales:" + SirLib.Funciones.Indent(14) + "{2,10:($##,##0.00)}"
                //+ "\n" + SirLib.Funciones.Indent(22) + "--------------------"
                //+ "\n" + SirLib.Funciones.Indent(25) + "{3,10:$##,##0.00}"
                        , totalAmount
                        , totalFees
                        , totalSales
                //        , (totalAmount - totalFees - totalSales)
                //totalSelectedOrders
                //, totalSales    //totalSelectedOrdersSales
                );
            
            labelTotalSelectedOrders.Text = c;
            totalLabel.Text = String.Format(
                "Total: " + SirLib.Funciones.Indent(14)
                + "{0,10:$##,##0.00}"
                       //, totalAmount
                        //, totalFees
                        //, totalSales
                        , (totalAmount - totalFees - totalSales)
                );

            //labelTotalQty.Text = String.Format("Quantity:" + Funciones.Indent(22) + "{0,3}", totalqty);
            //labelTotalAmt.Text = String.Format("Amount:" + Funciones.Indent(13) + "{0,10:$##,##0.00}", totalAmount);

        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            //check max amount
            if (Main.Sol_ControlInfo.CashierMaxAmount > 0.00m)
            {
                if (Main.Sol_ControlInfo.CashierMaxAmount < totalSelectedOrders)

                    if (!SolFunctions.PermisosConfirmar("The amount to pay is over the maximum allowed!", "Please provide password for Manager Override.", ""))
                    {
                        //MessageBox.Show("Sorry, you cannot void orders!");
                        return;

                    }
            }


            //busy cursor
            this.Cursor = Cursors.WaitCursor;

            if (BottleDrop && !SaveOrderToBottleDrop()) return;
            //update orders
            UpdateOrders();
            ordersProcessed = true;

            //print receipt
            //if (!onAccount)   ??? not sure

            if (!Main.Sol_ControlInfo.CashOutPrintingOverride && !BottleDrop)
            {
                string errorMessage = string.Empty;
                bool flag = SolFunctions.PrintReceipt(listView1, "", ref errorMessage, Properties.Settings.Default.BarcodeEncoding
                    , buttonSource
                    , securityCode
                    , totalSelectedOrders
                    );
                if (!flag)
                {
                    MessageBox.Show("There was a problem printing the receipt, please try again.\nError: " + errorMessage);
                }
            }

            //open drawer
            if (!onAccount)
            {
                //OpenDrawer();
                PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);

                //coin dispenser
                if (AxCoinUSB2 != null)
                {
                    //int iDecimalPart = (int)((totalPaidOrders - Math.Truncate(totalPaidOrders)) * 100);
                    //int iIntegerPart = (int)(totalPaidOrders) * 100;
                    //int iTotalPaidOrders = iIntegerPart+iDecimalPart;

                    //Cajero_Automatico.Calculate("ca", totalPaidOrders, ref Main.billsAndCoinsByCountry);
                    decimal totalCoins = 0;
                    decimal totalBills = 0;
                    Cajero_Automatico.Calculate(
                        "CA", 
                        totalPaidOrders, 
                        //ref Main.billsAndCoinsByCountry, 
                        out totalCoins, 
                        out totalBills);

                    int iCoins = (int)(totalCoins*100);

                    if (iCoins > 0)
                    {
                        bool flag = Properties.Settings.Default.CoinDispenserEnabled;
                        if (flag)
                        {

                            switch (Properties.Settings.Default.CoinDispenserDevice)
                            {
                                case 0: // tflex coin dispenser
                                    decimal totalDiference = 0;

                                    // We call a subroutine to dispense it.
                                    DispenseByAmount(iCoins);

                                    //if (iCoins >= AxCoinUSB2.DispenseBelowValue)
                                    //{
                                    //    totalDiference = totalCoins;
                                    //    decimal dispenseBelowValue = (decimal)(AxCoinUSB2.DispenseBelowValue)/100;
                                    //    decimal amountDispensed = totalCoins - dispenseBelowValue;
                                    //    totalCoins = amountDispensed;
                                    //    totalDiference -= totalCoins;
                                    //}

                                    // Get our status and show the user
                                    UpdateCanisterStatus(true, iCoins, totalCoins, totalBills, totalDiference);
                                    utilDelay(1);
                                    break;
                                default:
                                    MessageBox.Show("Invalid coin dispenser selection, please go to settings and fix this");
                                    break;

                            }
                        }
                    }
                    else
                        // Show amount dispensed in the status bar
                        UpdateStatus(String.Format("Total Bills:" + SirLib.Funciones.Indent(18) + "{0,9:$##,##0.00}\r\nTotal Coins dispensed:" + SirLib.Funciones.Indent(1) + "{1,9:$##,##0.00}", totalBills, totalCoins));

                }

            }

            buttonContinue.Text = "&Close";
            this.buttonContinue.Click -= new System.EventHandler(this.buttonContinue_Click);
            this.buttonContinue.Click += new System.EventHandler(this.Cancel_Click);
            buttonContinue.BackColor = Color.FromArgb(241, 116, 85);
            buttonContinue.ForeColor = SystemColors.Control;

            if (!BottleDrop)
            {
                buttonRePrint.Enabled = true;
                buttonReOpenDrawer.Enabled = true;
            }
            //buttonViewReceipt.Enabled = false;
            Cancel.Visible = false;

            buttonSelectCustomer.Visible = false;

            this.Cursor = Cursors.Default;
        }

        private void buttonRePrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string errorMessage = string.Empty;
            bool flag = SolFunctions.PrintReceipt(listView1, "", ref errorMessage, Properties.Settings.Default.BarcodeEncoding
                    , buttonSource
                    , securityCode
                    , totalSelectedOrders
                );
            this.Cursor = Cursors.Default;
            if (!flag)
            {
                MessageBox.Show("There was a problem printing the receipt, please try again.\nError: " + errorMessage);
            }
        }

        private void buttonReOpenDrawer_Click(object sender, EventArgs e)
        {
            PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);
            if (Properties.Settings.Default.SettingsWsTicketOpenDrawerSendTwice)
                PrinterCommand.Send(Main.AssemblyProduct, Properties.Settings.Default.SettingsWsReceiptPrinter, Properties.Settings.Default.SettingsWsTicketOpenDrawer);
        }

        private void buttonSelectCustomer_Click(object sender, EventArgs e)
        {
            Customers f1 = new Customers();
            f1.fromPutOnAccountForm = true;
            if (strOrderType == "R")
                f1.customerType = 0;
            else
                f1.customerType = 1;
            f1.ShowDialog();
            
            if (f1.fieldId < 1)
            {
                f1.Dispose();
                f1 = null;
                MessageBox.Show("Must select a valid customer to proceed");
                return;
            }

            buttonContinue.Enabled = true;
            buttonSelectCustomer.BackColor = Color.FromArgb(161, 214, 226);
            labelCustomerName.Text = f1.fieldName;
            customerId = f1.fieldId;
            f1.Dispose();
            f1 = null;

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

            totalPaidOrders = 0;

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
                    MessageBox.Show("We couldn't parse Order "+item.SubItems[0].Text);
                    continue;
                }
                
                orderType = item.SubItems[4].Text;

                
                //read order
                Sol_Order sol_Order = sol_Order_Sp.Select(orderId, orderType);
                
                //not found?
                if (sol_Order == null)
                {
                    MessageBox.Show(String.Format("Order #{0} not found!", orderId));
                    continue;
                }


                //marked as paid
                if (onAccount)
                {
                    //search for customer data if its on account
                    Sol_Customer sol_Customer = new Sol_Customer();
                    Sol_Customer_Sp sol_Customer_Sp = new Sol_Customer_Sp(Properties.Settings.Default.WsirDbConnectionString);
                    sol_Customer = sol_Customer_Sp.Select(customerId);
                    sol_Order.CustomerID = customerId;
                    //sol_Order.Name = sol_Customer.Name;
                    //sol_Order.Address1 = sol_Customer.Address1;
                    //sol_Order.Address2 = sol_Customer.Address2;
                    //sol_Order.City = sol_Customer.City;
                    //sol_Order.Province = sol_Customer.Province;
                    //sol_Order.Country = sol_Customer.Country;
                    //sol_Order.PostalCode = sol_Customer.PostalCode;

                    sol_Order.Status = "O"; //O = On account
                    //sol_Order_Sp.Update(sol_Order);
                }
                else
                {
                    sol_Order.DatePaid = Main.rc.FechaActual;
                    sol_Order.Status = "P"; //paid, processed

                }

                //close order if it is not
                if (sol_Order.DateClosed < sol_Order.Date)
                    sol_Order.DateClosed = Main.rc.FechaActual;


                sol_Order_Sp.Update(sol_Order);

                totalPaidOrders = totalPaidOrders + sol_Order.TotalAmount - sol_Order.FeeAmount;

                //close order if it is not
                if (sol_Order.DateClosed < sol_Order.Date)
                    sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");

                //paid
                if (!onAccount)
                    sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DatePaid");


                //mark details
                sol_OrdersDetailList = sol_OrdersDetail_Sp._SelectAllByOrderID_OrderType(orderId, orderType);
                foreach (Sol_OrdersDetail od in sol_OrdersDetailList)
                {
                    sol_OrdersDetail = sol_OrdersDetail_Sp.Select(od.DetailID);
                    sol_OrdersDetail.Status = sol_Order.Status;
                    sol_OrdersDetail_Sp.Update(sol_OrdersDetail);
                }


                if(Main.CardReader_Enabled)
                    UpdateOrderCardLink(orderId);

            }

        }

        private void buttonViewReceipt_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count < 1)
            {
                MessageBox.Show("Please select a row to delete");
                return;
            }


            int lastItem = 0;
            ListViewItem itm = new ListViewItem();
            foreach (ListViewItem item in selectedItems)
            {
                lastItem = item.Index;
                itm = item;
            }

            ViewReceipt(Convert.ToInt32(itm.SubItems[0].Text));

            listView1.Focus();

        }

        private void ViewReceipt(int orderID)
        {
            if (orderID < 1)
                return;

            this.Cursor = Cursors.WaitCursor;

            //query (has a stored procedure)
            string query = "storedprocedure";
            string subReportName2 = "";
            //query 2
            string query2 = "";
            string subReportName3 = "";
            //query 3
            string query3 = "";


            Sol_Order_Sp sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Sol_Order sol_Order = sol_Order_Sp._SelectByOrderID(orderID);
            if (sol_Order == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Transaction # not found, please try another.");
                return;
            }


            CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new Solum.Reports.TransactionSearch();

            object[,] parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "OrderID", orderID },
                        {"", ""}
                    };


            bool imprimirReporte = false;
            bool exportarReporte = false;
            short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
            bool preverReporte = true;
            short numeroDeCopias = 1;
            //if (Properties.Settings.Default.SettingsWsReceiptPrintPreview)
            //    preverReporte = true;
            //else
            //    imprimirReporte = true;

            ReportesPrevista f1 = new ReportesPrevista(
                Properties.Settings.Default.WsirDbConnectionString,
                Properties.Settings.Default.SQLServidorNombre,
                Properties.Settings.Default.SQLBaseDeDatos,
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
                String.Empty,
                true,
                true
            );
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

            this.Cursor = Cursors.Default;

        }

        #region tflex coin dispenser

        private void InitializeDevice()
        {

            //coin dispenser
            if (Properties.Settings.Default.CoinDispenserEnabled)
            {
                switch (Properties.Settings.Default.CoinDispenserDevice)
                {
                    case 0: // tflex coin dispenser
                        //already initialized
                        if (AxCoinUSB2 != null)
                        {
                            //Get our status and show the user
                            UpdateCanisterStatus(false, 0, 0, 0, 0);
                            //default cursor
                            this.Cursor = Cursors.Default;
                            return;
                        }

                        try
                        {
                            AxCoinUSB2 = new AxCOINUSBLib.AxCoinUSB();
                            AxCoinUSB2.CreateControl();
                        }
                        catch
                        {
                            //default cursor
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Error creating object for Coin Dispenser!\r\nDid you install and configure the driver for it?\r\nSolum will continue without the use of a Coin Dispenser",
                                "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            groupBoxCoinDispenser.Visible = false;
                            listView1.Dock = DockStyle.Fill;

                            Properties.Settings.Default.CoinDispenserEnabled = false;
                            return;

                        }
                        // Dimension return values
                        string strOcxVersion = "";
                        int lRetVal = 0;
                        // Set OCX property "CommunicationChannel". True for Serial and False for USB.
                        bool flag = true;   // serial
                        if (Properties.Settings.Default.CoinDispenserTFlexCommunicationChannel == 0)
                            flag = false;   // usb
                        AxCoinUSB2.CommunicationChannel = flag;
                        // Call OCX Method "SetProtocol" to set the Protocol
                        lRetVal = AxCoinUSB2.SetProtocol(Properties.Settings.Default.CoinDispenserTFlexSetProtocol);
                        // Call OCX Method "InitPortSettings" to initialize Communication.
                        // Before calling this method One should set "CommunicationChannel".
                        // In Case of Serial Communication, One should set "CommBaud", "CommPort" properties
                        // along with "Communicationchannel" property.
                        if (Properties.Settings.Default.CoinDispenserTFlexCommunicationChannel == 1)    //serial
                        {
                            AxCoinUSB2.CommBaud = Properties.Settings.Default.CoinDispenserTFlexSetCommBaud;
                            AxCoinUSB2.CommPort = Properties.Settings.Default.CoinDispenserTFlexSetCommBaud;
                        }

                        //
                        lRetVal = AxCoinUSB2.InitPortSettings(ref strOcxVersion);
                        if (lRetVal == SUCCESS)
                        {
                            UpdateStatus("Found Telequip Active X Control Version " + strOcxVersion + ". Comm OK");
                            // We are talking. Clear machine and semsor status.
                            AxCoinUSB2.ClearMachineStatus();
                            AxCoinUSB2.ClearSensorStatus();
                        }
                        else
                        {
                            // If the active x control can//t communicate with the
                            // TFlex we end up here. The program will exit.
                            //defualt cursor
                            //this.Cursor = Cursors.Default;
                            //MessageBox.Show(AxCoinUSB2.GetTransactLastError(), "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            UpdateStatus(AxCoinUSB2.GetTransactLastError().Trim()+"\r\nPlease check that Coin Dispenser is ON, connected and loaded with coins! Then click on Reconnect.");
                            buttonCoinDispenserReconnect.Visible = true;
                            //((IDisposable)AxCoinUSB2).Dispose(); 
                        }

                        //default cursor
                        this.Cursor = Cursors.Default;

                        break;
                    default:
                        MessageBox.Show("Invalid coin dispenser selection, please go to settings and fix this");
                        break;

                }
            }
        }

        private void UpdateStatus(string CurrentStat)
        {
            //StatusBar1.Text = CurrentStat;
            labelCanisterStatus.Text = CurrentStat;
        }

        private void UpdateCanisterStatus(bool checkDispense, int amount, decimal totalCoins, decimal totalBills, decimal totalDiference)
        {
            // We will use this Sub to check for low coin and
            // depleted canister conditions.
            //
            // First set up a few variables
            // ERROR: Not supported in C#: OnErrorStatement

            object machineStatus = null;
            int lRetVal = 0;
            //object i = null;
            //int lBoundVal = 0;
            //int uBoundVal = 0;
            //
            bool CoinDispensed = false;
            bool LowCoin = false;
            //
            // Get the Status byte.

            lRetVal = AxCoinUSB2.GetMachineStatus(ref machineStatus);
            //
            // Handel any errors
            //if (Err().Number != 0)
            //{
            //    Err().Clear();
            //    Interaction.MsgBox(AxCoinUSB2.GetTransactLastError, MsgBoxStyle.Critical, "Critical Error");
            //    UpdateStatus(AxCoinUSB2.GetTransactLastError());
            //    return;
            //}
            //
            // Break down the machine status byte
            if (lRetVal == SUCCESS)
            {
                //lBoundVal = Information.LBound(machineStatus);
                //uBoundVal = Information.UBound(machineStatus);
                //lBoundVal = (byte[])machineStatus.
                //uBoundVal = Information.UBound(machineStatus);


                //for (i = lBoundVal; i <= uBoundVal; i++)
                //http://stackoverflow.com/questions/6438015/c-sharp-object-to-array
                System.Collections.IEnumerable myList = machineStatus as System.Collections.IEnumerable;
                short i = 1;
                foreach (object ms in myList)
                {
                    switch (i++)
                    {
                        case 1:  //Parity error
                            break;
                        case 2:  //Function error
                            break;
                        //
                        case 3:  //Malfunction
                            break;
                        //
                        case 4: //Busy
                            break;
                        //
                        case 5: //low coin
                            if ((bool)ms)
                            {
                                // If this bit is set we are low on coins
                                LowCoin = true;
                            }
                            break;
                        case 6: //Coin Dispensed
                            if ((bool)ms)
                            {
                                // If this bit is set we dispensed coins
                                CoinDispensed = true;
                                //FirstDispense = true;
                            }
                            break;
                    }
                }

                // Display our results.
                if (CoinDispensed && checkDispense)
                {
                    //
                    // Ok we have dispensed coins
                    // We are in low coin
                    string c;
                    if (LowCoin)
                    {
                        c = "Low on coins. ";
                        //Everything is nominal. Coins were dispensed
                    }
                    else
                    {
                        c = ""; //"Canister has coins.";
                    }
                    //
                    // Show amount dispensed in the status bar
                    c += String.Format("Total Bills:" + SirLib.Funciones.Indent(18) + "{0,9:$##,##0.00}\r\nTotal Coins dispensed:"+ SirLib.Funciones.Indent(1) + "{1,9:$##,##0.00}", totalBills, totalCoins);
                    if(totalDiference>0)
                        c += String.Format("\r\n Coins not dispensed: " + SirLib.Funciones.Indent(2) + "{0,9:$##,##0.00} because of Dispense Below Amount", totalDiference);
                    UpdateStatus(c);
                }
                else
                {
                    //if (FirstDispense)
                    //{
                    //    //Label2.Text = "Canister empty.";
                    //    // Show information in the status bar
                    //    UpdateStatus("Canister empty. Dispensed Failed.");
                    //}
                    //else
                    //{
                    //    //Label2.Text = "";
                    //    // If we get here we are unsure of the current
                    //    // machine condition. The canister may not
                    //    // be in the TFlex so we show it
                    //    // in the status bar.
                    //    UpdateStatus("Please make sure the canister is installed.");
                    //}
                    if (LowCoin)
                    {
                        // Show information in the status bar
                        UpdateStatus("Low on coins.");

                    }
                    else
                    {
                        // Show information in the status bar
                        UpdateStatus("Ready.");

                    }

                }
            }
            else
            {
                UpdateStatus("Get Status Failed. Unable to check canister.");
                //Label2.Text = "Unknown coin condition";
            }
            //Err().Clear();
        }

        public void utilDelay(short sec)
        {
            //**************************************
            // Provide Delay
            //**************************************
            //object stopvalue = null;
            //stopvalue = DateTime.Timer + sec;
            //while ((DateTime.Timer <= stopvalue))
            //{
            //    System.Windows.Forms.Application.DoEvents();
            //}
            System.Threading.Thread.Sleep(1000 * sec);
        }

        private bool DispenseByAmount(int Amount)
        {
            //  Dispense the Ampunt
            bool bRetVal = false; ;
            bRetVal = AxCoinUSB2.DispenseByAmount(Amount);
            // Did we dispense?
            if (!bRetVal)
            {
                // No We failed
                UpdateStatus("Dispense by Amount Failed.");

            }

            return bRetVal;
        }

        private void buttonCoinDispenserReconnect_Click(object sender, EventArgs e)
        {

            switch (Properties.Settings.Default.CoinDispenserDevice)
            {
                case 0: // tflex coin dispenser

                    //UpdateStatus("Reconnecting...");
                    labelCanisterStatus.Text = "Reconnecting...";

                    //busy cursor
                    Cursor = Cursors.WaitCursor;

                    // Dimension return values
                    string strOcxVersion = "";
                    int lRetVal = 0;
                    lRetVal = AxCoinUSB2.InitPortSettings(ref strOcxVersion);
                    if (lRetVal == SUCCESS)
                    {
                        UpdateStatus("Found Telequip Active X Control Version " + strOcxVersion + ". Comm OK");
                        // We are talking. Clear machine and semsor status.
                        AxCoinUSB2.ClearMachineStatus();
                        AxCoinUSB2.ClearSensorStatus();
                        buttonCoinDispenserReconnect.Visible = false;
                    }
                    else
                    {
                        // If the active x control can//t communicate with the
                        // TFlex we end up here. The program will exit.
                        //defualt cursor
                        //this.Cursor = Cursors.Default;
                        //MessageBox.Show(AxCoinUSB2.GetTransactLastError(), "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateStatus(AxCoinUSB2.GetTransactLastError().Trim() + "\r\nPlease check that Coin Dispenser is ON, connected and loaded with coins! Then click on Reconnect.");
                        buttonCoinDispenserReconnect.Visible = true;
                        //((IDisposable)AxCoinUSB2).Dispose(); 
                    }

                    //default cursor
                    this.Cursor = Cursors.Default;

                    break;
                default:
                    MessageBox.Show("Invalid coin dispenser selection, please go to settings and fix this");
                    break;

            }
        }

        #endregion


        private bool UpdateOrderCardLink(int orderId)
        {
            if (String.IsNullOrEmpty(strCardNumber))
                return true;

            
            if (sol_OrderCardLink_Sp == null)
                sol_OrderCardLink_Sp = new Sol_OrderCardLink_Sp(Properties.Settings.Default.WsirDbConnectionString);


            if (sol_OrderCardLog_Sp == null)
                sol_OrderCardLog_Sp = new Sol_OrderCardLog_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //7) The paid routine should also:
            //                 Delete all paid orders from the sol_OrderCardLink table
            //                 Update all paid orders in the sol_OrderCardLog table with paiddate


            sol_OrderCardLink_Sp.DeleteByCardNumber(strCardNumber);
            

            sol_OrderCardLog = sol_OrderCardLog_Sp.Select(strCardNumber, orderId);
            if (sol_OrderCardLog == null)
                return false;

            sol_OrderCardLog.DatePaid = Main.rc.FechaActual;
            sol_OrderCardLog_Sp.Update(sol_OrderCardLog);

            return true;
        }
        private void UpdateButtonVisibility()
        {
            buttonContinue.Visible = buttonContinue.Enabled;
            buttonRePrint.Visible = buttonRePrint.Enabled;
            buttonReOpenDrawer.Visible = buttonReOpenDrawer.Enabled;
            buttonViewReceipt.Visible = buttonViewReceipt.Enabled;
            buttonSelectCustomer.Visible = buttonSelectCustomer.Enabled;
            Cancel.Visible = Cancel.Enabled;
        }

        private void Button_EnabledChanged(object sender, EventArgs e)
        {
            UpdateButtonVisibility();
        }

        private bool SaveOrderToBottleDrop()
        {
            BottleDropJsonResponse jres;
            Main.MainForm.BDJsonHandler.ConfirmJWT(out jres);
            if (!jres.Verified)
            {
                if (!OpenBottleDropLogin())
                {
                    MessageBox.Show("Could not verify BottleDrop Login credentials.", "Validation Error");
                    return false;
                }
            }
            Main.MainForm.BDJsonHandler.SaveCount(BottleDropOrderDetails, totalAmount, BottleDropBagID, out jres);
            return true;
        }
        private bool OpenBottleDropLogin()
        {
            var bdLoginForm = new Login2(Properties.Settings.Default.TouchOriented, false, "", "Please verify your BottleDrop Login");
            bdLoginForm.BottleDrop = true;
            bdLoginForm.Recuerdame = false;
            bool auth;
            bdLoginForm.ShowDialog();
            auth = bdLoginForm.IsAuthenticated;
            bdLoginForm.Dispose();
            return auth;
        }
    }
}
