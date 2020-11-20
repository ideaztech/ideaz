
//using Microsoft.Win32.SafeHandles;
//using System.Globalization;
//using System.IO;
//using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Microsoft.VisualBasic;
//using System.Collections;
//using System.Diagnostics;
//using System.Timers;
using System.Web.Security;
//using System.Threading;

using SirLib;
//using SirLib.Hid;


namespace Solum
{
    public partial class Cashier : Form
    {
        #region UsbHid Variables
        //TextBox textBoxRFID = new System.Windows.Forms.TextBox();

        private bool cardReadInProgress;

        #endregion

        #region CardLink Variables

        List<Sol_OrderCardLink> sol_OrderCardLinkList;

        //private string Main.strMsrCardNumber;
        //private ArrayList arrayListCardNumber;
        //Sol_OrderCardLink sol_OrderCardLink;

        Sol_OrderCardLink_Sp sol_OrderCardLink_Sp;

        #endregion

        #region Cashier Variables

        int qdCustomerID = 0;
        TextBox sourceTextBox = new TextBox();

        bool formQuickDrop = false;
        string strOrderType = "R";  //R = Returns, S = Sales, A = Adjustment. Q=QuickDrop


        Sol_CategoryButton sol_CategoryButton;
        Sol_CategoryButton_Sp sol_CategoryButton_Sp;

        Sol_BinCount sol_BinCount;
        Sol_BinCount_Sp sol_BinCount_Sp;

        private bool onAccount = false;

        public bool formReturn = false;
        public bool formSales = false;

        Sol_Order sol_Order;
        Sol_Order_Sp sol_Order_Sp;

        List<Sol_Order> sol_OrderList;
        Sol_OrdersDetail sol_OrdersDetail;
        Sol_OrdersDetail_Sp sol_OrdersDetail_Sp;
        List<Sol_OrdersDetail> sol_OrdersDetailList;

        Sol_Customer sol_Customer;
        Sol_Customer_Sp sol_Customer_Sp;
        

        #endregion

        #region Cashier Methods

        public Cashier(string Texto, string User, string Server)    //, string Today)
        {

            InitializeComponent();

            this.Text = Texto;
            toolStripStatusLabelUserName.Text = User.Trim();    // +".";
            //toolStripStatusLabelMessage.Text = "Please open one bag at a time and place on counter";
            toolStripStatusLabelServerName.Text = Server;
            toolStripStatusLabelToday.Text = "";    // Today;

            //FullScreenMode
            if (Properties.Settings.Default.SettingsAdFullScreenMode)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //if (Properties.Settings.Default.SettingsAdHideTaskBar)
                //{
                //    this.ControlBox = true;
                //    this.MaximizeBox = false;
                //    this.MinimizeBox = false;
                //}
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }

        }


        //private void Cashier_FormClosing(object sender, FormClosingEventArgs e)
        //private void Cashier_Closed(System.Object eventSender, System.EventArgs eventArgs)
        //{
        //    if (Main.CardReader_Enabled)
        //    {
        //        if (Main.CardReader_EmulationMode == 0)    //HID
        //        {
        //            //Shutdown();
        //            Main.usbReadEventForm = "";
        //            this.timerCashier.Tick -= new System.EventHandler(this.timerCashier_Tick);
        //        }
        //        else if (Main.CardReader_EmulationMode == 1)    //keyboard
        //        {
        //            //
        //        }
        //    }

        //    if (Properties.Settings.Default.TouchOriented)
        //        Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        //}

        private void Cashier_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Main.CustomerScreenForm.ToString());
            toolStrip1.Renderer = new App_Code.NewToolStripRenderer();
            toolStrip1.DefaultDropDownDirection = ToolStripDropDownDirection.AboveRight;
            //for usb hid
            if (Main.CardReader_Enabled)
            {
                if (Main.CardReader_EmulationMode == 0)    //HID
                {

                    Main.usbReadEventForm = "Cashier";

                    toolStripStatusLabelMsr.Visible = true;
                    toolStripStatusLabelMsrMessage.Visible = true;
                    
                    if (Main.myDeviceDetected)
                        this.toolStripStatusLabelMsrMessage.Text = "was found";

                    //this.timer1.Tick -= new System.EventHandler(this.timer1_Tick);
                    this.timerCashier.Interval = 1 * 1000;
                    this.timerCashier.Tick += new System.EventHandler(this.timerCashier_Tick);
                    this.timerCashier.Enabled = true;

                }
                else if (Main.CardReader_EmulationMode == 1)    //keyboard
                {
                    // 
                    // textBoxRFID
                    // 
                    //panelHeader.Controls.Add(textBoxRFID);
                    //textBoxOrderId.Location = new System.Drawing.Point(639, 26);
                    //textBoxRFID.Name = "textBoxRFID";
                    //textBoxRFID.Size = new System.Drawing.Size(100, 26);
                    //textBoxRFID.TabIndex = 11;
                    //textBoxRFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRFID_KeyDown);
                }


            }

            // TODO: This line of code loads data into the 'dataSetCategories.Sol_Categories' table. You can move, or remove it, as needed.
            //check cashier
            buttonCashRefund.Visible = SolFunctions.CheckCashier();

            if (Properties.Settings.Default.TouchOriented)
                //toolStripButtonVirtualKb.Visible = true;
                keyboardButton.Visible = true;

            //classes of tables
            sol_Order = new Sol_Order();
            sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_OrdersDetail = new Sol_OrdersDetail();
            sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_OrdersDetailList = new List<Sol_OrdersDetail>();

            //clock
            object obj1 = toolStripStatusLabelToday;
            object obj2 = toolStripStatusLabelTimer;
            if (Main.rc != null)
            {
                Main.rc.CambiarControlFecha(ref obj1);
                Main.rc.CambiarControlHora(ref obj2);
            }

            //disable form resizing
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Order #", 185, HorizontalAlignment.Right);
            listView1.Columns.Add("Amount", 140, HorizontalAlignment.Right);
            listView1.Columns.Add("Station", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Employee", 157, HorizontalAlignment.Left);
            listView1.Columns.Add("T", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Fee", 124, HorizontalAlignment.Right);
            listView1.Columns.Add("Open Time", 350, HorizontalAlignment.Center);
            listView1.Columns.Add("Submit Time", 350, HorizontalAlignment.Center);
            listView1.Columns.Add("Status", 110, HorizontalAlignment.Center);

            listView1.Columns[2].Width = listView1.Width -
                (listView1.Columns[0].Width +
                listView1.Columns[1].Width +
                listView1.Columns[3].Width +
                listView1.Columns[4].Width +
                listView1.Columns[5].Width +
                listView1.Columns[6].Width +
                listView1.Columns[7].Width +
                listView1.Columns[8].Width);

            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            //listView1.Activation = ItemActivation.OneClick;

            //addItem(1, 1.25M, "ws01", "kevin", DateTime.Today.TimeOfDay.ToString(), DateTime.Today.TimeOfDay.ToString(), true);
            //addItem(2, 10.25M, "ws01", "kevin", DateTime.Today.TimeOfDay.ToString(), DateTime.Today.TimeOfDay.ToString(), false);
            //addItem(3, 11.25M, "ws01", "kevin", DateTime.Today.TimeOfDay.ToString(), DateTime.Today.TimeOfDay.ToString(), false);
            //addItem(5, 120.00M, "ws01", "kevin", DateTime.Today.TimeOfDay.ToString(), DateTime.Today.TimeOfDay.ToString(), false);

            //read outstandig orders (unpaid)
            //sol_OrderList = sol_Order_Sp._SelectAllByStatus(strOrderType, "A");  //all unpaid orders (returns, sales)
            //if (sol_OrderList != null)
            //    ReadOutStandigOrders();

            //totals();
            buttonOutStandingOrders.PerformClick();


            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }

            //current cashtray
            Sol_CashTray_Sp sol_CashTray_Sp = new Solum.Sol_CashTray_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Sol_CashTray sol_CashTray = sol_CashTray_Sp.Select(Properties.Settings.Default.SettingsCurrentCashTray);
            if (sol_CashTray != null)
                label1CurrentCashTray.Text = sol_CashTray.Description;

            CheckComputerRole();

            textBoxOrderId.Focus();

            if (Main.Sol_ControlInfo.State == "AB"
                && Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
            {
                toolStripButtonQdCustomer.Visible = true;
                toolStripSeparatorQdCustomer.Visible = true;
                buttonQuickDropOrders.Visible = true;
            }


            CustomerScreen.ClearCustomerScreen();

            buttonUnPay.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUnpayOrder", false);
            buttonDelete.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolVoidOrder", false);
            buttonOnAccount.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", false);
            toolStripButtonAttendance.Visible = Properties.Settings.Default.UseAttendance;
            toolStripButtonSales.Visible = Properties.Settings.Default.UseSales;

        }

        private bool addItem(int orderNumber, decimal amount, string station, string employee, string openTime, string submitTime, bool select, string orderType, decimal fee, string status)
        {
            string[] str = new string[11];
            ListViewItem itm = new ListViewItem();
            //formatting numbers
            string c = String.Format("{0,8:#,##0.00}", amount);
            if (orderType == strOrderType)  //"R")
                c = String.Format("{0,8:(#,##0.00)}", amount);


            str[0] = Funciones.Indent(7)+String.Format("{0,3:##000}", orderNumber);
            str[1] = c; //String.Format("{0,8:$#,##0.00;($#,##0.00)}", amount);
            str[2] = station;
            str[3] = employee;
            str[4] = orderType;
            c = String.Format("{0,8:#,##0.00}", fee);
            str[5] = c; //String.Format("{0,8:$#,##0.00;($#,##0.00)}", fee);
            str[6] = openTime;
            str[7] = submitTime;
            str[8] = status;

            itm = new ListViewItem(str);

            itm.Checked = select;

            listView1.Items.Add(itm);

            return true;
        }


        private void totals()
        {
            string c = "";
            //decimal totalUnSelectedOrders = 0, totalUnSelectedOrdersSales = 0;
            decimal totalSelectedOrders = 0, totalSelectedOrdersSales = 0;

            //unselected items
            //ListView.ListViewItemCollection Items = listView1.Items;
            //foreach (ListViewItem item in Items)
            //{
            //    c = item.SubItems[1].Text;
            //    c = c.Replace('$', ' ');
            //    c = c.Replace('(', ' ');
            //    c = c.Replace(')', ' ');
            //    decimal amount = Convert.ToDecimal(c);

            //    c = item.SubItems[5].Text;  //7
            //    c = c.Replace('$', ' ');
            //    c = c.Replace('(', ' ');
            //    c = c.Replace(')', ' ');
            //    decimal fee = Convert.ToDecimal(c);


            //    if (item.SubItems[4].Text == strOrderType)  //"R")   //6
            //    {
            //        totalUnSelectedOrders = totalUnSelectedOrders + amount-fee;
            //    }
            //    else
            //    {
            //        totalUnSelectedOrdersSales = totalUnSelectedOrdersSales + amount -fee;
            //    }

            //}


            //selected items
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                c = item.SubItems[1].Text;
                c = c.Replace('$', ' ');
                c = c.Replace('(', ' ');
                c = c.Replace(')', ' ');
                decimal amount = Convert.ToDecimal(c);

                c = item.SubItems[5].Text;  //7
                c = c.Replace('$', ' ');
                c = c.Replace('(', ' ');
                c = c.Replace(')', ' ');
                decimal fee = Convert.ToDecimal(c);

                if (item.SubItems[4].Text == strOrderType)  //"R")  
                    totalSelectedOrders = totalSelectedOrders + amount - fee;
                else if (item.SubItems[4].Text == "S") 
                    totalSelectedOrdersSales = totalSelectedOrdersSales + amount - fee;
            }

            //totalUnSelectedOrders -= totalSelectedOrders;
            //totalUnSelectedOrdersSales -= totalSelectedOrdersSales;


            //c = String.Format(
            //    "UnSelected Orders:\n\r"+
            //    "\n\rReturns:" + Funciones.Indent(1) + "{0,12:($##,##0.00)}" +
            //    "\n\rSales:" + Funciones.Indent(6) + "{1,11:$##,##0.00}", 
            //    totalUnSelectedOrders,
            //    totalUnSelectedOrdersSales
            //    );

            //labelTotalUnSelectedOrders.Text = c;

            c = String.Format(
                "Selected Orders:\n\r" +
                "\n\rReturns:" + Funciones.Indent(1) + "{0,12:($##,##0.00)}" +
                "\n\rSales:" + Funciones.Indent(6) + "{1,11:$##,##0.00}",
                totalSelectedOrders,
                totalSelectedOrdersSales
                );
            labelTotalSelectedOrders.Text = c;

        }


        private void toolStripButtonLogOff_Click(object sender, EventArgs e)
        {
            SolFunctions.LogOff(ref toolStripStatusLabelUserName);
            CheckComputerRole();

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", true))
            {
                buttonExit.PerformClick();
                return;
            }

            buttonUnPay.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUnpayOrder", false);
            buttonDelete.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolVoidOrder", false);
            buttonOnAccount.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", false);
            

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            ////memory leak
            //formReturn = true;
            //Close();
            //return;

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
            textBoxOrderId.Focus();

        }

        private void toolStripButtonReturns_Click(object sender, EventArgs e)
        {
            formReturn = true;
            Close();

        }

        private void toolStripButtonSales_Click(object sender, EventArgs e)
        {
            formSales = true;
            Close();

        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            totals();

            if (e.Item.Checked)
            {
                int orderId = 0;
                Int32.TryParse(e.Item.SubItems[0].Text, out orderId);
                sol_Order.OrderID = orderId;
                sol_Order.OrderType = e.Item.SubItems[4].Text;
            }

        }

        //private void SelectItems(bool select)
        //{
        //    ListView.ListViewItemCollection Items = listView1.Items;
        //    foreach (ListViewItem item in Items)
        //        item.Checked = select;
        //}

        private void ReadOutStandingOrders()
        {
            this.Cursor = Cursors.WaitCursor;

            listView1.Items.Clear();

            MembershipUser membershipUser;
            foreach (Sol_Order or in sol_OrderList)
            {
                int orderNumber = or.OrderID;
                decimal amount  = or.TotalAmount;
                string station = or.ComputerName;   // or.WorkStationID.ToString();

                string employee = "Not found";  // or.UserID.ToString();
                membershipUser = membershipUser = Membership.GetUser((Guid)or.UserID);
                if (membershipUser != null)
                    employee = membershipUser.UserName;

                string openTime = or.Date.ToString();  //.TimeOfDay.ToString().Substring(0,8);
                string submitTime = or.DateClosed.ToString();  //.TimeOfDay.ToString().Substring(0, 8);

                decimal fee = or.FeeAmount;

                if (strOrderType == "Q")
                {

                    if (sol_Customer_Sp == null)
                        sol_Customer_Sp = new Sol_Customer_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    sol_Customer = sol_Customer_Sp.Select(or.CustomerID);
                    employee = sol_Customer.Name;

                }


                addItem(orderNumber, amount, station, employee, openTime, submitTime, false, or.OrderType, fee, or.Status);
            }

            totals();

            this.Cursor = Cursors.Default;


        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //if (myDeviceDetected)
            //    this.toolStripStatusLabelMsrMessage.Text = "was found";

            //if (string.IsNullOrEmpty(textBoxQdCardNumber.Text)
            //    || string.IsNullOrEmpty(textBoxOrderId.Text))
            //    qdCustomerID = 0;

            if(strOrderType == "R")
                sol_OrderList = sol_Order_Sp._SelectAllByStatus(strOrderType, "A", qdCustomerID, String.Empty, String.Empty);  //all unpaid orders (returns, sales)
            else
                sol_OrderList = sol_Order_Sp._SelectAllByStatus(strOrderType, "U", qdCustomerID, String.Empty, String.Empty);  //all unpaid orders (returns, sales)

            if (sol_OrderList != null)
                ReadOutStandingOrders();

            buttonReprint.Enabled = false;
            buttonUnPay.Enabled = false;
            textBoxOrderId.Focus();

            buttonViewTodaysOrders.Text = "&View Today's Orders";

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //if (myDeviceDetected)
            //    this.toolStripStatusLabelMsrMessage.Text = "was found";

            bool firstTime = true;
            int orderId = 0;
            string orderType = "";

            //selected items
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                if (firstTime)
                {
                    if (!SolFunctions.PermisosConfirmar("Need permission to delete!", "Please provide password to delete selected orders.", "SolDeleteChit"))   //true))
                    {
                        //MessageBox.Show("Sorry, you cannot void orders!");
                        textBoxOrderId.Focus();
                        return;
                    }

                    firstTime = false;
                    if (MessageBox.Show("Are you sure you want to delete selected orders?", "Delete Orders", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                    {
                        textBoxOrderId.Focus();
                        return;
                    }


                }
                try
                {
                    orderId = Int32.Parse(item.SubItems[0].Text);
                    orderType = item.SubItems[4].Text;  //6
                }
                catch
                {
                    continue;
                }


                //read order
                sol_Order = sol_Order_Sp.Select(orderId, orderType);
                //not found?
                if (sol_Order == null)
                    continue;

                //remove customer, if any
                //if (sol_Order.CustomerID > 0)
                //{
                //    sol_Order.CustomerID = 0;
                //    sol_Order.Name = String.Empty;
                //    sol_Order.Address1 = String.Empty;
                //    sol_Order.Address2 = String.Empty;
                //    sol_Order.City = String.Empty;
                //    sol_Order.Province = String.Empty;
                //    sol_Order.Country = String.Empty;
                //    sol_Order.PostalCode = String.Empty;
                //}
                sol_Order.Status = "D";
                sol_Order_Sp.Update(sol_Order);

                //mark details as deleted
                sol_OrdersDetailList = sol_OrdersDetail_Sp._SelectAllByOrderID_OrderType(orderId, orderType);
                foreach (Sol_OrdersDetail od in sol_OrdersDetailList)
                {
                    sol_OrdersDetail = sol_OrdersDetail_Sp.Select(od.DetailID);
                    sol_OrdersDetail.Status = sol_Order.Status;
                    sol_OrdersDetail_Sp.Update(sol_OrdersDetail);
                    
                    if(sol_CategoryButton_Sp== null)
                        sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    sol_CategoryButton = sol_CategoryButton_Sp.Select(sol_OrdersDetail.CategoryButtonID);
                    if(sol_CategoryButton != null)
                    {
                        if(sol_CategoryButton.SubContainerMaxCount>0)
                            updateCurrentCount(
                                sol_OrdersDetail.Quantity,
                                sol_CategoryButton.SubContainerCountDown,   // bool counterDown,
                                sol_OrdersDetail.CategoryButtonID,
                                sol_CategoryButton.SubContainerMaxCount,    // int maxCount,
                                -1  //remove
                            );

                    }
                }

                //sol_OrdersDetail_Sp._DeleteAllByOrderID_OrderType(


            }

            //refresh list or remove item above???
            buttonRefresh.PerformClick();

            textBoxOrderId.Focus();

        }

        private void updateCurrentCount(
            int quantity,
            //string description, 
            //decimal price, 
            //int categoryId, 
            //int detailId, 
            bool counterDown,
            int categoryButtonId,
            int maxCount,
            short factor
            )
        {

            //sol_BinCount = new Sol_BinCount();
            if(sol_BinCount_Sp == null)
                sol_BinCount_Sp = new Sol_BinCount_Sp(Properties.Settings.Default.WsirDbConnectionString);


            sol_BinCount = sol_BinCount_Sp.Select(Main.myHostName, categoryButtonId);
            if (sol_BinCount == null)
            {
                sol_BinCount = new Sol_BinCount();
                sol_BinCount.ClientID = Main.myHostName;
                sol_BinCount.CategoryButtonID = categoryButtonId;
                sol_BinCount.CurrentCount = 0;
                sol_BinCount.CurrentCount = adjustCurrentBin(sol_BinCount.CurrentCount, quantity, counterDown, maxCount, factor);
                sol_BinCount_Sp.Insert(sol_BinCount);
            }
            else
            {
                sol_BinCount.CurrentCount = adjustCurrentBin(sol_BinCount.CurrentCount, quantity, counterDown, maxCount, factor);
                sol_BinCount_Sp.Update(sol_BinCount);
            }

            //updateThreshold(int totalQuantity, int subContainerMaxCount, short factor, bool subContainerCountDown)


        }

        private int adjustCurrentBin(int currentCount, int quantity, bool counterDown, int maxCount, short factor)
        {
            //string t = String.Empty;
            //string tFactor;
            decimal result = 0;
            int pint = 0;
            int pdec = 0;

            int totalQuantity = 0;
            if (factor == 1)
            {
                //tFactor = "Time to close";
                totalQuantity = currentCount + quantity;
            }
            else
            {
                //tFactor = "Please re-open previous";

                pint = (int)((Math.Floor((double)(quantity / maxCount))) * maxCount);
                totalQuantity = currentCount - quantity + pint;

                pint /= maxCount;

                if (quantity > currentCount)
                {
                    totalQuantity = totalQuantity + maxCount;
                }
                if (totalQuantity == maxCount)
                {
                    totalQuantity = 0;
                }

            }

            if (totalQuantity >= maxCount)
            {
                result = (decimal)totalQuantity / (decimal)maxCount;
                pint = (int)result;
                pdec = totalQuantity - (maxCount * pint);
            }
            else
                pdec = totalQuantity;


            //if (pint == 1)
            //    t = tFactor + " container!";
            //else if (pint > 1)
            //    t = tFactor + String.Format(" {0} containers!", pint);

            //if (pdec > 0 && pint != 0)
            //    t += String.Format("\r\nPlease keep {0} items for next bin", pdec);

            totalQuantity = pdec;

            //if (!String.IsNullOrEmpty(t))
            //    MessageBox.Show(t);

            return totalQuantity;

        }



        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (sourceTextBox == null)
            {
                sourceTextBox = textBoxOrderId;
            }

            switch (sourceTextBox.Name)
            {
                case "textBoxOrderId":


                    //if (myDeviceDetected)
                    //    this.toolStripStatusLabelMsrMessage.Text = "was found";


                    if (String.IsNullOrEmpty(textBoxOrderId.Text))
                    {
                        if (String.IsNullOrEmpty(textBoxQdCardNumber.Text))
                        {
                            qdCustomerID = 0;
                            MessageBox.Show("Please enter an Order or a QD Card number");
                            textBoxQdCardNumber.Focus();
                            return;
                        }

                        if (!ReadQdCardNumber(textBoxQdCardNumber.Text))
                        {
                            MessageBox.Show("Please enter a valid Order number");
                            textBoxOrderId.Focus();
                            textBoxOrderId.SelectAll();
                            return;
                        }
                    }

                    string securityCode = String.Empty;
                    string[] k = textBoxOrderId.Text.Split(' ');
                    if (k.Count() > 1)
                        securityCode = k[1];

                    int orderId = 0;
                    try
                    {

                        orderId = Int32.Parse(k[0]);    //textBoxOrderId.Text);
                    }
                    catch
                    {
                        if (!ReadQdCardNumber(textBoxOrderId.Text))
                        {

                            //aqui
                            Main.strMsrCardNumber = textBoxOrderId.Text;
                            if (!String.IsNullOrEmpty(Main.strMsrCardNumber))
                            {

                                if (ReadOrderCardLink())
                                {
                                    cardReadInProgress = false;
                                    Main.strMsrCardNumber = String.Empty;
                                    textBoxOrderId.Text = String.Empty;
                                    return;
                                }
                            }

                            MessageBox.Show("Please enter a valid Order number.");
                            textBoxOrderId.Focus();
                            textBoxOrderId.SelectAll();
                            return;
                        }
                    }

                    bool flag = ReadOrder(orderId, securityCode, true);

                    if (!flag && sol_Order.Status != "P")
                    {
                        if (!ReadQdCardNumber(textBoxOrderId.Text))
                        {

                            //aqui
                            Main.strMsrCardNumber = textBoxOrderId.Text;
                            if (!String.IsNullOrEmpty(Main.strMsrCardNumber))
                            {

                                if (ReadOrderCardLink())
                                {
                                    cardReadInProgress = false;
                                    Main.strMsrCardNumber = String.Empty;
                                    textBoxOrderId.Text = String.Empty;
                                    return;
                                }
                            }

                            MessageBox.Show("Order not found, try another number.");
                            textBoxOrderId.Focus();
                            textBoxOrderId.SelectAll();
                            return;
                        }
                    }
                    else
                    {

                        if (sol_Order.Status != "P")
                        {
                            textBoxOrderId.Text = "";
                            buttonCashRefund.PerformClick();
                            textBoxOrderId.Focus();
                            textBoxOrderId.SelectAll();
                        }

                        buttonReprint.Enabled = true;
                        buttonUnPay.Enabled = Properties.Settings.Default.SettingsSecurityEnableUnPay;

                    }
    
                    break;
                case "textBoxQdCardNumber":
                    if (String.IsNullOrEmpty(textBoxQdCardNumber.Text))
                    {
                        qdCustomerID = 0;
                        MessageBox.Show("Please enter QD Card number");
                        textBoxQdCardNumber.Focus();
                        return;
                    }
                    if(!ReadQdCardNumber(textBoxQdCardNumber.Text))
                        MessageBox.Show("Please enter a valid QD Card number");

                break;
                    default:
                break;
            }


        }

        private bool ReadQdCardNumber(string qdCardNumber)
        {
            if (String.IsNullOrEmpty(qdCardNumber))
                return false;

                if (sol_Customer_Sp == null)
                    sol_Customer_Sp = new Sol_Customer_Sp(Properties.Settings.Default.WsirDbConnectionString);

                sol_Customer = sol_Customer_Sp.SelectByCardNumber(qdCardNumber);
                if (sol_Customer == null)
                {
                    qdCustomerID = 0;
                    //MessageBox.Show("QD Card number not found");
                    textBoxQdCardNumber.Focus();
                    return false;

                }
                else
                {
                    CashierQdCustomer f1 = new CashierQdCustomer();
                    f1.fieldName = sol_Customer.Name;
                    f1.address1 = sol_Customer.Address1;
                    f1.address2 = sol_Customer.Address2;
                    f1.city = sol_Customer.City;
                    f1.phone = sol_Customer.PhoneNumber;
                    f1.postalCode = sol_Customer.PostalCode;
                    f1.ShowDialog();

                    if (!f1.result)
                    {
                        textBoxQdCardNumber.Text = String.Empty;
                        qdCustomerID = 0;
                    }
                    else
                    {
                        qdCustomerID = sol_Customer.CustomerID;
                        buttonQuickDropOrders.PerformClick();
                    }

                    f1.Dispose();
                    f1 = null;


                }


            return true;
        }

        private bool ReadOrder(int orderId, string securityCode, bool search)
        {
            listView1.Items.Clear();

            if(String.IsNullOrEmpty(securityCode))
                sol_Order = sol_Order_Sp._SelectByOrderID(orderId);
            else
                sol_Order = sol_Order_Sp.SelectWithSecCode(orderId, securityCode);      //_SelectByOrderID(orderId);

            if (sol_Order == null)
            {
                sol_Order = new Sol_Order();
                return false;
            }
            if (sol_Order.Status == "D")
            {
                MessageBox.Show("Order is deleted");
                return false;
            }
            else if (sol_Order.Status == "P" )
            {
                if (!search)
                {
                    MessageBox.Show("Order already paid");
                    return false;
                }
            }
            else if (sol_Order.Status != "O" && sol_Order.Status != "A")
            {
                MessageBox.Show("Invalid Order number");
                return false;
            }

            //search for return
            //sol_OrdersDetailList = sol_OrdersDetail_Sp._SelectAllByOrderID_OrderType(orderId, sol_Order.OrderType);
            //if (sol_OrdersDetailList == null)
            //    return false;

            MembershipUser membershipUser;
            //foreach (Sol_OrdersDetail rd in sol_OrdersDetailList)
            //{
                int orderNumber = sol_Order.OrderID;
                decimal amount = sol_Order.TotalAmount;
                string station = sol_Order.ComputerName;   // or.WorkStationID.ToString();
                //if (or.OrderType == "R")
                //    amount = amount * -1.00m;
                string employee = "Not found";  // or.UserID.ToString();
                membershipUser = membershipUser = Membership.GetUser((Guid)sol_Order.UserID);
                if (membershipUser != null)
                    employee = membershipUser.UserName;

                string openTime = sol_Order.Date.ToShortDateString();  //.TimeOfDay.ToString().Substring(0, 8);
                string submitTime = sol_Order.DateClosed.ToShortDateString();  //.TimeOfDay.ToString().Substring(0, 8);
                //string orderType = "Sale";
                //if (or.OrderType == "R")
                //{
                //    orderType = "Return";
                //    //amount = amount * -1.00m;
                //}
                decimal fee = sol_Order.FeeAmount;


                if (strOrderType == "Q")
                {

                    if (sol_Customer_Sp == null)
                        sol_Customer_Sp = new Sol_Customer_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    sol_Customer = sol_Customer_Sp.Select(sol_Order.CustomerID);
                    employee = sol_Customer.Name;

                }

                addItem(orderNumber, amount, station, employee, openTime, submitTime, true, sol_Order.OrderType, fee, sol_Order.Status);

            //}
            totals();



            return true;
        }


        private void buttonCashRefund_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", true))
                return;

            //if (myDeviceDetected)
            //    this.toolStripStatusLabelMsrMessage.Text = "was found";

            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("No Orders selected");
                onAccount = false;
                textBoxOrderId.Focus();
                return;
            }

            string qdcn = string.Empty;
            foreach (ListViewItem item in checkedItems)
            {
                int orderID = 0;
                Int32.TryParse(item.SubItems[0].Text, out orderID);
                sol_Order = sol_Order_Sp.Select(orderID, item.SubItems[4].Text);
                qdcn = item.SubItems[3].Text;//employee is customer name in quickdrop
                //if (!(item.SubItems[8].Text == "A"))
                if(sol_Order == null)
                {
                    MessageBox.Show("Sorry, this order no longer exist! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    onAccount = false;
                    //buttonRefresh.PerformClick();
                    textBoxOrderId.Focus();
                    return;
                }

                if (sol_Order.Status == "D")
                {
                    //MessageBox.Show("Sorry, this order is already paid! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    Funciones.DisplayAutoClosingMessageBox(
                        this,
                        "Sorry, this order has been void! (Order #" + item.SubItems[0].Text.Trim() + ")",
                        "Cashier Screen",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        1000 * 3//FrontScreen.MessageTimeOut
                    );

                    onAccount = false;
                    //buttonRefresh.PerformClick();
                    textBoxOrderId.Focus();
                    return;
                }


                if (formQuickDrop)
                {
                    PayNowOnAccountOrders();
                    onAccount = false;
                    return;
                }
                else if (sol_Order.Status != "A" && sol_Order.DatePaid >= sol_Order.Date)
                {
                    //MessageBox.Show("Sorry, this order is already paid! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    Funciones.DisplayAutoClosingMessageBox(
                        this,
                        "Sorry, this order is already paid! (Order #" + item.SubItems[0].Text.Trim() + ")",
                        "Cashier Screen",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        1000 * 3//FrontScreen.MessageTimeOut
                    );

                    onAccount = false;
                    //buttonRefresh.PerformClick();
                    textBoxOrderId.Focus();
                    return;
                }

                //open order
                if (sol_Order.DateClosed < sol_Order.Date)
                {
                    MessageBox.Show("Sorry, this order is open! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    onAccount = false;
                    //buttonRefresh.PerformClick();
                    textBoxOrderId.Focus();
                    return;
                }

            }
            //if (Main.myDeviceDetected)
            //    this.timer1.Enabled = false;
            CashierCash f1 = new CashierCash();
            f1.buttonSource = "Cashier";
            f1.checkedItems = checkedItems;
            f1.strCardNumber = Main.strMsrCardNumber;

            if (formQuickDrop)
            {

                f1.qdCustomerName = qdcn;
                f1.strOrderType = "Q";
            }
            else
                f1.strOrderType = "R";
          
            f1.onAccount = onAccount;

            //busy cursor
            Cursor = Cursors.WaitCursor;
            f1.ShowDialog();
            bool ordersProcessed = f1.ordersProcessed;
            f1.Dispose();
            f1 = null;

            //if (Main.myDeviceDetected)
            //    this.timer1.Enabled = true;

            //default cursor
            this.Cursor = Cursors.Default;

            Main.strMsrCardNumber = String.Empty;

            if (ordersProcessed)
                buttonRefresh.PerformClick();

            onAccount = false;

            textBoxOrderId.Focus();

        }

        private void buttonOnAccount_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", true))
                return;

            //if (myDeviceDetected)
            //    this.toolStripStatusLabelMsrMessage.Text = "was found";

            onAccount = true;
            buttonCashRefund.PerformClick();

            textBoxOrderId.Focus();

        }

        private void PayNowOnAccountOrders()
        {
            //MessageBox.Show("Pay Now");

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", true))
                return;

            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("No Orders selected");
                return;
            }

            foreach (ListViewItem item in checkedItems)
            {
                int orderID = 0;
                Int32.TryParse(item.SubItems[0].Text, out orderID);
                sol_Order = sol_Order_Sp.Select(orderID, item.SubItems[4].Text);

                //if (!(item.SubItems[8].Text == "A"))
                if (sol_Order == null)
                {
                    MessageBox.Show("Sorry, this order no longer exist! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    //buttonRefresh.PerformClick();
                    return;
                }

                if (sol_Order.Status == "O" && sol_Order.DatePaid >= sol_Order.Date)
                {
                    MessageBox.Show("Sorry, this order is already paid! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    //buttonRefresh.PerformClick();
                    return;
                }

                //open order
                if (sol_Order.DateClosed < sol_Order.Date)
                {
                    MessageBox.Show("Sorry, this order is open! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    //buttonRefresh.PerformClick();
                    return;
                }

            }


            CustomerOrdersPayNow f1 = new CustomerOrdersPayNow(0);
            //CashierCash.buttonSource = "CustomerOrders";
            if(onAccount)
                f1.paymentType = 1;
            else
                f1.paymentType = 0;
            f1.checkedItems = checkedItems;
            f1.ShowDialog();
            bool ordersProcessed = f1.ordersProcessed;
            f1.Dispose();
            f1 = null;
            if (ordersProcessed)
                buttonRefresh.PerformClick();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes =
                        this.listView1.SelectedIndices;

            foreach (int index in indexes)
            {
                this.listView1.Items[index].Checked = !this.listView1.Items[index].Checked;
                if (this.listView1.Items[index].Checked)
                    this.listView1.Items[index].BackColor = Color.LightGray;    // SystemColors.ControlLight;
                else
                    this.listView1.Items[index].BackColor = SystemColors.Window;
                //break;
            }

        }

        private void buttonViewTodaysOrders_Click(object sender, EventArgs e)
        {
            //if (myDeviceDetected)
            //    this.toolStripStatusLabelMsrMessage.Text = "was found";

            string dateFrom;
            string dateTo;
            if (buttonViewTodaysOrders.Text == "&View Older Orders")
            {
                CashierGetDates f1 = new CashierGetDates();
                f1.ShowDialog();
                if (f1.cancelFlag)
                {
                    f1.Dispose();
                    f1 = null;
                    return;
                }
                dateFrom = f1.dateFrom.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");
                dateTo = f1.dateTo.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");
                f1.Dispose();
                f1 = null;
            }
            else
            {
                dateFrom = Main.rc.FechaActual.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");
                dateTo = Main.rc.FechaActual.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");

            }

            //sol_Order_Sp._SelectAllByStatus(strOrderType, "A", 0, String.Empty, String.Empty);

            if (strOrderType == "R")
            {
                //sol_OrderList = sol_Order_Sp._SelectAllByStatus(strOrderType, "A", 0, dateFrom, dateTo);  //all unpaid orders (returns, sales)
                sol_OrderList = sol_Order_Sp._SelectAllBy(strOrderType, "", 0, dateFrom, dateTo);  //all orders (returns, sales)
            }
            else
            {
                //sol_OrderList = sol_Order_Sp._SelectAllByStatus(strOrderType, "U", 0, dateFrom, dateTo);  //all unpaid orders (quickdrop)
                sol_OrderList = sol_Order_Sp._SelectAllBy(strOrderType, "", 0, dateFrom, dateTo);  //all orders (quickdrop)
            }


            if (sol_OrderList != null)
            {
                if (sol_OrderList.Count > 100)
                {
                    if (MessageBox.Show(String.Format("This operation will take sometime to complete, because you are trying to view {0} orders, do you want to continue?",sol_OrderList.Count), "View Older Orders", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                        return;

                }

                ReadOutStandingOrders();
                buttonReprint.Enabled = true;
                buttonUnPay.Enabled = Properties.Settings.Default.SettingsSecurityEnableUnPay;
            }
            textBoxOrderId.Focus();

            buttonViewTodaysOrders.Text = "&View Older Orders";


        }

        private void buttonReprint_Click(object sender, EventArgs e)
        {
            //if (myDeviceDetected)
            //    this.toolStripStatusLabelMsrMessage.Text = "was found";

            ListView listView2 = new ListView();
            if (CreateListView(ref listView2, "RePrint"))
            {
                this.Cursor = Cursors.WaitCursor;
                string errorMessage = string.Empty;
                bool flag = SolFunctions.PrintReceipt(listView2, "", ref errorMessage, Properties.Settings.Default.BarcodeEncoding
                    , "Cashier", string.Empty, 0.0m
                    );
                this.Cursor = Cursors.Default;
                if (!flag)
                {
                    MessageBox.Show("There was a problem printing the receipt, please try again.\nError: " + errorMessage);
                }

            }
            textBoxOrderId.Focus();

        }

        private void buttonUnPay_Click(object sender, EventArgs e)
        {
            //if (myDeviceDetected)
            //    this.toolStripStatusLabelMsrMessage.Text = "was found";

            ListView listView2 = new ListView();
            if (CreateListView(ref listView2, "UnPay"))
            {
                //
                if (Properties.Settings.Default.SettingsSecurityApprovalUnPay)
                {
                    if (SolFunctions.PermisosConfirmar("Need permission to unpay(unvoid)!", "Please provide password to unpay selected orders.", "SolUnpayOrder"))
                    {
                        UnpayOrders(listView2);
                        MessageBox.Show("Order(s) UnPaid!");
                    }
                    //else
                    //    MessageBox.Show("Sorry, you cannot UnPaid orders!");
                }
                else
                {
                    if (Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUnpayOrder", true))
                    {
                        UnpayOrders(listView2);
                        MessageBox.Show("Order(s) UnPaid!");
                    }
                    else
                        return;
                }
            }
            textBoxOrderId.Focus();

        }

        private bool CreateListView(ref ListView listView2, string men)
        {
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("No Orders selected");
                //onAccount = false;
                return false;
            }

            if(men.ToLower() == "unpay"
                && checkedItems.Count >1
                )
            {
                MessageBox.Show("Please select only one order for this operation");
                return false;

            }
            

            //listview with headers
            listView2.View = View.Details;
            listView2.View = View.Details;
            listView2.Columns.Add("Order #", 190, HorizontalAlignment.Right);
            listView2.Columns.Add("Amount", 150, HorizontalAlignment.Right);
            listView2.Columns.Add("Station", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("Employee", 157, HorizontalAlignment.Left);
            listView2.Columns.Add("T", 50, HorizontalAlignment.Center);
            listView2.Columns.Add("Fee", 124, HorizontalAlignment.Right);
            listView2.Columns.Add("Open Time", 180, HorizontalAlignment.Center);
            listView2.Columns.Add("Submit Time", 200, HorizontalAlignment.Center);
            listView2.Columns.Add("Status", 110, HorizontalAlignment.Center);

            //listView2.Columns.Add("Order #", 80, HorizontalAlignment.Center);
            //listView2.Columns.Add("Amount", 75, HorizontalAlignment.Center);
            //listView2.Columns.Add("Fee", 75, HorizontalAlignment.Center);
            //listView2.Columns.Add("Type", 60, HorizontalAlignment.Center);

            listView2.Visible = false;

            listView2.Items.Clear();
            string[] str = new string[10];
            ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in checkedItems)
            {
                str[0] = item.SubItems[0].Text.Trim();
                if (!(
                    item.SubItems[8].Text == "P"
                    || item.SubItems[8].Text == "O"
                    || item.SubItems[8].Text == "D"
                    ))
                {
                    MessageBox.Show("Sorry, Cannot "+men+" an Unpaid Order! (Order #" + str[0] + ")");
                    return false;
                }


                str[1] = item.SubItems[1].Text;
                str[2] = item.SubItems[2].Text;     //7
                str[3] = item.SubItems[3].Text;     //6
                str[4] = item.SubItems[4].Text;     //6
                str[5] = item.SubItems[5].Text;     //6
                str[6] = item.SubItems[6].Text;     //6
                str[7] = item.SubItems[7].Text;     //6
                str[8] = item.SubItems[8].Text;     //6
                itm = new ListViewItem(str);
                listView2.Items.Add(itm);

            }
            return true;
        }

        private void UnpayOrders(ListView listView2)
        {
            //selecciona orders
            ListView.ListViewItemCollection Items = listView2.Items;
            foreach (ListViewItem item in Items)
            {
                string c = item.SubItems[0].Text.Trim();
                int orderId = 0;
                try
                {
                    orderId = Int32.Parse(c);
                }
                catch
                {
                    continue;
                }

                sol_Order = new Sol_Order();
                sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);

                //delete actual detail's voucher
                if (formQuickDrop)
                    sol_Order_Sp.UpdateStatus(orderId, item.SubItems[4].Text, "O"); // A = normal D = void  O = On account P = paid or processed
                else
                    sol_Order_Sp.UpdateStatus(orderId, item.SubItems[4].Text, "A"); // A = normal D = void  O = On account P = paid or processed

            }

            //change status in the original listview
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                if (formQuickDrop)
                    item.SubItems[8].Text = "O";
                else
                    item.SubItems[8].Text = "A";
            }


        }

        //private void timer1_Tick(object sender, System.EventArgs e)
        //{
        //    //Display current time on status bar
        //    DateTime t = DateTime.Now;
        //    toolStripStatusLabelTimer.Text = t.ToShortTimeString();
        //    toolStripStatusLabelToday.Text = t.ToShortDateString();

        //}

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void toolStripButtonAttendance_Click(object sender, EventArgs e)
        {
            Attendance f1 = new Attendance();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

            textBoxOrderId.Focus();


        }

        //public static bool CheckCashier()
        //{
        //    Sol_Entrie sol_Entrie = new Sol_Entrie();
        //    Sol_Entrie_Sp sol_Entrie_Sp = new Sol_Entrie_Sp(Properties.Settings.Default.WsirDbConnectionString);
        //    if (SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, Properties.Settings.Default.SettingsCurrentCashTray))
        //    {
        //        //*************************************************
        //        //check if the Main.rc is enabled (RelojCalendario)
        //        //*************************************************
        //        //MessageBox.Show("You need to Open a new Cashier before using this option!");  //can pay a Return!");
        //        //Close();
        //        return false;

        //    }
        //    return true;
        //}

        private void textBoxOrderId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    //this.GetNextControl(ActiveControl, true).Focus();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                    sourceTextBox = textBoxOrderId;
                    buttonSearch.PerformClick();

                }
            }


        }

        private void textBoxQdCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    //this.GetNextControl(ActiveControl, true).Focus();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                    sourceTextBox = textBoxQdCardNumber;
                    buttonSearch.PerformClick();

                }
            }

        }


        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            if (checkedItems.Count > 0)
            {
                MessageBox.Show("Please Unselect all Orders before sorting by column!");
                return;
            }

            SirLib.ListViewItemComparer.ColumnClick((ListView)sender, e);

        }

        //public static bool PermisosConfirmar(
        //    string title,
        //    string action, 
        //    string permissionName)
        //{


        //    if (!Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin"))
        //    {
        //        if (Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, permissionName, false))
        //            return true;
        //    }

        //    bool IsAuthenticated = false;
        //    if (String.IsNullOrEmpty(action))
        //        action = "Need permission to do this!";
        //    Login2 dlg = new Login2(Properties.Settings.Default.TouchOriented, true, title, action);   //, "Confirm your authenticity please");
        //    dlg.Usuario = Properties.Settings.Default.LoginUsuarioNombre;
        //    dlg.Recuerdame = Properties.Settings.Default.LoginUsuarioRecuerdame;
        //    //dlg.IsAuthenticated = true; //IsAuthenticated;
        //    dlg.ShowDialog();
        //    IsAuthenticated = dlg.IsAuthenticated;
        //    if (IsAuthenticated)
        //    {
        //        //is an admin?
        //        if (!Roles.IsUserInRole(dlg.Usuario, "admin"))
        //        {
        //            //has that permission in particular?
        //            //Dictionary<string, bool> permisos = null;  // = new Dictionary<string, bool>();
        //            if (!
        //                //Funciones.PermisosObtener_Leer(Properties.Settings.Default.WsirConnectionString, ref permisos, permissionName, dlg.Usuario, "", false))
        //                Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, dlg.Usuario, permissionName, false))
        //                IsAuthenticated = false;
        //        }
        //    }

        //    if (!IsAuthenticated)
        //    {
        //        MessageBox.Show("Sorry! You don't have the permission to do this, cannot continue!");
        //        return false;
        //    }

        //    return true;
        //}

        private void CheckComputerRole()
        {
            //computer roles
            toolStripButtonReturns.Enabled = true;
            toolStripButtonSales.Enabled = true;
            if (!(
                Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                switch (Properties.Settings.Default.SettingComputerRole)
                {
                    //case 0:     //full role
                    //    break;
                    //case 1:     //Returns/Sales
                    //    break;
                    case 2:     //Cashier
                        toolStripButtonReturns.Enabled = false;
                        toolStripButtonSales.Enabled = false;
                        break;
                    //case 3:     //Shipping
                    //    break;
                    default:    //anything else
                        //toolStripButtonExit.PerformClick();
                        exitButton.PerformClick();
                        break;

                }

            }

        }


        private bool ReadOrderCardLink()
        {
            if (String.IsNullOrEmpty(Main.strMsrCardNumber))
                return false;

            string strCardNumber = Main.strMsrCardNumber;
            Main.strMsrCardNumber = String.Empty;

            if (sol_OrderCardLink_Sp == null)
                sol_OrderCardLink_Sp = new Sol_OrderCardLink_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //6) The Cashier screen should be listening for the card to scan.  
            //                 If a card is scanned it should look up the order linked to the card in sol_OrderCardLink
            //                 If OPTION1 is selected, it should look up all the orders linked to the card and list them on the cashier screen and check them all as selected. 


            sol_OrderCardLinkList = sol_OrderCardLink_Sp.SelectAllByCardNumber(strCardNumber);
            if (sol_OrderCardLinkList == null || sol_OrderCardLinkList.Count <1)
            {
                //MessageBox.Show("No Vouchers asociated with this Card Number, try another please.");
                Funciones.DisplayAutoClosingMessageBox(
                    this,
                    String.Format("No Vouchers asociated with this Card Number, try another please. CardNumber: {0}", strCardNumber),
                    "Cashier Screen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    1000 * 3//FrontScreen.MessageTimeOut
                );

                //if (myDeviceDetected)
                //    this.toolStripStatusLabelMsrMessage.Text = "was found";


                return false;
            }

            listView1.Items.Clear();
            MembershipUser membershipUser;

            foreach (Sol_OrderCardLink oc in sol_OrderCardLinkList)
            {

                if (sol_Order_Sp == null)
                    sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);

                Sol_Order or = sol_Order_Sp.Select(oc.OrderID, strOrderType);   //"R");
                if (or == null)
                    continue;

                    int orderNumber = or.OrderID;
                    decimal amount = or.TotalAmount;
                    string station = or.ComputerName;   // or.WorkStationID.ToString();

                    string employee = "Not found";  // or.UserID.ToString();
                    membershipUser = membershipUser = Membership.GetUser((Guid)or.UserID);
                    if (membershipUser != null)
                        employee = membershipUser.UserName;

                    string openTime = or.Date.ToShortDateString();  //.TimeOfDay.ToString().Substring(0, 8);
                    string submitTime = or.DateClosed.ToShortDateString();  //.TimeOfDay.ToString().Substring(0, 8);

                    decimal fee = or.FeeAmount;


                    addItem(orderNumber, amount, station, employee, openTime, submitTime, true, or.OrderType, fee, or.Status);

                totals();



            }

            totals();


            ////e) it creates an entry in the sol_OrderCardLog table with CardNumber, OrderId, GetDate()
            //sol_OrderCardLog = new Sol_OrderCardLog();
            //sol_OrderCardLog.CardNumber = Main.strMsrCardNumber;
            //sol_OrderCardLog.OrderID = sol_Order.OrderID;
            //sol_OrderCardLog.DateAdded = Main.rc.FechaActual;
            //sol_OrderCardLog.DatePaid = DateTime.Parse("1753-1-1 12:00:00");
            //sol_OrderCardLog_Sp.Insert(sol_OrderCardLog);

            ////f) pop up a message that says "Order [Ordernumber] was successfully linked to Card [cardnumber]"  The message should be on a timer and the message should disappear after 10 seconds.
            //MessageBox.Show(String.Format("Order: {0} was successfully linked to Card: {1}", sol_Order.OrderID, Main.strMsrCardNumber));

            buttonCashRefund.PerformClick();


            return true;

        }

        #endregion

        #region UsbHid Methods

        private void timerCashier_Tick(object sender, System.EventArgs e)
        {

            if (String.IsNullOrEmpty(Main.strMsrCardNumber))
                return;

            //toolStripStatusLabelMsrMessage.Text = Main.strMsrCardNumber;

            if (cardReadInProgress)
                return;
            cardReadInProgress = true;

            ReadOrderCardLink();

            cardReadInProgress = false;
            Main.strMsrCardNumber = String.Empty;

        }

        #endregion

        private void toolStripButtonQdCustomer_Click(object sender, EventArgs e)
        {
            if (!((Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
    || Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false))))
            {
                MessageBox.Show("Sorry, you don't have permission to view and edit customers");
                return;
            }
            Customers f1 = new Customers();
            f1.manageMode = true;
            f1.customerType = 1;    //quickdrop

            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void buttonOutStandingOrders_Click(object sender, EventArgs e)
        {
            buttonQuickDropOrders.BackColor = SystemColors.Control;
            //buttonOutStandingOrders.BackColor = SystemColors.ButtonHighlight;
            //OutStanding Orders
            formQuickDrop = false;
            strOrderType = "R";  //R = Returns, S = Sales, A = Adjustment. Q=QuickDrop

            //read outstandig orders (unpaid)
            listView1.Columns[3].Text = "Employee";
            // A = normal D = void  O = On account P = paid or processed, I = In Process QuickDrop
            // 
            sol_OrderList = sol_Order_Sp._SelectAllByStatus(strOrderType, "A", 0, String.Empty, String.Empty);  //all unpaid orders (returns, sales)
            if (sol_OrderList != null)
                ReadOutStandingOrders();


            totals();

            labelQdCardNumber.Visible = false;
            textBoxQdCardNumber.Visible = false;
            buttonClearQdCustomerFilter.Visible = false;
            textBoxOrderId.Focus();

        }

        private void buttonQuickDropOrders_Click(object sender, EventArgs e)
        {
            buttonQuickDropOrders.BackColor = SystemColors.ButtonHighlight;
            buttonOutStandingOrders.BackColor = SystemColors.Control;

            //QuickDrop
            formQuickDrop = true;
            strOrderType = "Q";  //R = Returns, S = Sales, A = Adjustment. Q=QuickDrop

            //read outstandig orders (unpaid)
            listView1.Columns[3].Text = "Customer";

            // A = normal D = void  O = On account P = paid or processed, I = In Process QuickDrop
            // Status for sp U = all unpaid orders
            sol_OrderList = sol_Order_Sp._SelectAllByStatus(strOrderType, "U", qdCustomerID, String.Empty, String.Empty);  //all quickdrop unpaid orders 
            if (sol_OrderList != null)
                ReadOutStandingOrders();


            totals();

            labelQdCardNumber.Visible = true;
            textBoxQdCardNumber.Visible = true;
            buttonClearQdCustomerFilter.Visible = true;
            textBoxOrderId.Focus();

        }

        private void textBoxOrderId_Leave(object sender, EventArgs e)
        {
            sourceTextBox = (TextBox)sender;
        }

        private void textBoxQdCardNumber_Leave(object sender, EventArgs e)
        {
            sourceTextBox = (TextBox)sender;
        }

        private void buttonClearQdCustomerFilter_Click(object sender, EventArgs e)
        {
            qdCustomerID = 0;
            textBoxOrderId.Text = string.Empty;
            textBoxQdCardNumber.Text = string.Empty;
            buttonQuickDropOrders.PerformClick();
        }


    }
}
