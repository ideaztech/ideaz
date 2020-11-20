
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;
using System.Collections;
using System.Web.Security;

namespace Solum
{
    public partial class CustomerOrders : Form
    {
        string strOrderType = "R";  //R = Returns, S = Sales, A = Adjustment. Q=QuickDrop

        //private enum ShowOrderType
        //{
        //    All,
        //    Solum,
        //    QuickDrop
        //}

        private enum ViewType
        {
            SolumOrders,
            QuickDropOrders,
            CustomerDrops,
            QuickDropBags,
            VoidOrders
        }


        //private ShowOrderType showOrderType { get; set; }
        private ViewType viewType { get; set; }
        public short customerType { get; set; }

        private decimal currentBalance;

        //private Sol_Customer_Sp sol_Customer_Sp;

        Sol_CashTray_Sp sol_CashTray_Sp;

        List<Sol_Order> sol_OrderList;
        Sol_Order_Sp sol_Order_Sp;
        Sol_Order sol_Order;

        int customerId;
        public CustomerOrders(
            int customerID, 
            string customerName, 
            string address, 
            decimal CurrentBalance)
        {
            InitializeComponent();
            customerId = customerID;
            textBoxId.Text = customerId.ToString();
            textBoxName.Text = customerName;
            textBoxAddress.Text = address;

            currentBalance = CurrentBalance;
            textBoxCurrentBalance.Text = String.Format("{0,8:#,##0.00}", currentBalance);

            customerType = 0;   //-1 = all 0 = solum 1 = quickdrop      (1 = solum, 2 = quickdrop else =all)
//           localCustomerType = 1;

        }

        private void CustomerOrders_Load(object sender, EventArgs e)
        {
            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (Properties.Settings.Default.TouchOriented)
            {
                this.Height = this.Height + (OK.Height) + 150;
                OK.Height = OK.Height * 2;
                buttonSelectAll.Height = buttonSelectAll.Height * 2;
                buttonRefresh.Height = buttonRefresh.Height * 2;
                Cancel.Height = Cancel.Height * 2;

                double substract = dataGridView1.Height / 2.2;

                dataGridView1.Height = dataGridView1.Height + (int)substract;


                toolStripButtonVirtualKb.Visible = true;
                this.radioButtonShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.radioButtonUnpaidOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.CenterToParent();
            }

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Order #", 185, HorizontalAlignment.Right);
            listView1.Columns.Add("Amount", 140, HorizontalAlignment.Right);
            listView1.Columns.Add("Station", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Employee", 157, HorizontalAlignment.Left);
            listView1.Columns.Add("T", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Fee", 124, HorizontalAlignment.Right);
            ////6
            //listView1.Columns.Add("Open Time", 210, HorizontalAlignment.Center);
            //7 -> 6
            listView1.Columns.Add("Submit Date", 200, HorizontalAlignment.Center);
            //8 -> 7
            listView1.Columns.Add("Status", 110, HorizontalAlignment.Center);
            //9 -> 8
            listView1.Columns.Add("CashTray", 200, HorizontalAlignment.Center);
            //10 -> 9
            listView1.Columns.Add("Date Paid", 200, HorizontalAlignment.Center);
            //11 -> 10
            listView1.Columns.Add("Reference", 400, HorizontalAlignment.Center);

            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            //listView1.Activation = ItemActivation.OneClick;


            if (sol_CashTray_Sp == null)
                sol_CashTray_Sp = new Sol_CashTray_Sp(Properties.Settings.Default.WsirDbConnectionString);

            if(sol_Order_Sp == null)
                sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);


            buttonSolum.Visible = true;
            buttonVoidOrders.Visible = true;

            if (Main.Sol_ControlInfo.State == "AB"
                && Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
            {
                //buttonShowAllOrders.Visible = false;
                //buttonSolum.Visible = true;
                buttonQuickDrop.Visible = true;
                buttonDrops.Visible = true;
                buttonBags.Visible = true;
                //buttonVoidOrders.Visible = true;

                //buttonSolum.PerformClick();
            }
            else
            {
                //buttonShowAllOrders.Visible = false;
                //buttonSolum.Visible = false;
                this.buttonSolum.Text = "Orders";

                buttonQuickDrop.Visible = false;
                buttonDrops.Visible = false;
                buttonBags.Visible = false;
                //buttonVoidOrders.Visible = false;

                this.buttonVoidOrders.Location = new System.Drawing.Point(162, 95);


                //strOrderType = "R";  //R = Returns, S = Sales, A = Adjustment. Q=QuickDrop
                //radioButtonUnpaidOnly.Checked = true;
                //viewType = ViewType.SolumOrders;
            }


            buttonSolum.PerformClick();
            //buttonRefresh.PerformClick();

        }

        private void radioButtonShowAll_CheckedChanged(object sender, EventArgs e)
        {
            ReadCustomerOrders(!radioButtonShowAll.Checked);
            labelPaidOrders.Visible = radioButtonShowAll.Checked;
            textBoxCurrentBalance.Text = String.Format("{0,8:#,##0.00}", currentBalance);
               
        }

        private void ReadCustomerOrders(bool unPaid)
        {
            currentBalance = 0m;


            //if(showOrderType == ShowOrderType.All)
            //    sol_OrderList = sol_Order_Sp.SelectAllByCustomerUnpaid("B", customerId, unPaid);    //B = Both, R and Q
            //else

            if (viewType == ViewType.VoidOrders)
            {
                sol_OrderList = sol_Order_Sp._SelectAllByStatus("", "D", customerId, String.Empty, String.Empty);  //all unpaid orders (returns, sales)
            }
            else
            {
                sol_OrderList = sol_Order_Sp.SelectAllByCustomerUnpaid(strOrderType, customerId, unPaid);
            }

            if (buttonSelectAll.Text == "&Unselect all")
                buttonSelectAll.Text = "&Select all";

            listView1.Items.Clear();

            if (sol_OrderList == null)
                return;

            MembershipUser membershipUser;
            foreach (Sol_Order or in sol_OrderList)
            {
                int orderNumber = or.OrderID;
                decimal amount = or.TotalAmount;
                string station = or.ComputerName;   // or.WorkStationID.ToString();

                string employee = "Not found";  // or.UserID.ToString();
                membershipUser = membershipUser = Membership.GetUser((Guid)or.UserID);
                if (membershipUser != null)
                    employee = membershipUser.UserName;

                //string openTime = or.Date.TimeOfDay.ToString().Substring(0, 8);
                string submitDate = or.DateClosed.ToShortDateString();  //.TimeOfDay.ToString().Substring(0, 8);

                decimal fee = or.FeeAmount;

                addItem(orderNumber, amount, station, employee, /*openTime,*/ submitDate, false, or.OrderType, fee, or.Status, or.CashTrayID, or.DatePaid, or.Reference, or.Date);
                currentBalance += or.TotalAmount;

            }
        }

        private bool addItem(int orderNumber, decimal amount, string station, string employee, 
            /*string openTime,*/ 
            string submitDate, 
            bool select, string orderType, decimal fee, string status, int cashTrayID, DateTime datePaid, string reference, DateTime date)
        {
            string[] str = new string[14];
            ListViewItem itm = new ListViewItem();
            //formatting numbers
            string c = String.Format("{0,8:#,##0.00}", amount);
            if (orderType == "R")
                c = String.Format("{0,8:(#,##0.00)}", amount);

            int index = 0;
            //0
            str[index++] = Funciones.Indent(7)+String.Format("{0,3:##000}", orderNumber);
            //1
            str[index++] = c; //String.Format("{0,8:$#,##0.00;($#,##0.00)}", amount);
            //2
            str[index++] = station;
            //3
            str[index++] = employee;
            //4
            str[index++] = orderType;

            c = String.Format("{0,8:#,##0.00}", fee);
            //5
            str[index++] = c; //String.Format("{0,8:$#,##0.00;($#,##0.00)}", fee);
            //
            //str[index++] = openTime;
            //6
            str[index++] = submitDate;
            //7
            str[index++] = Main.returnOrderStatusType.SingleOrDefault(p => p.Id == status).Description;

            Sol_CashTray sol_CashTray = sol_CashTray_Sp.Select(cashTrayID);
            //8
            if (sol_CashTray == null)
                str[index++] = "";
            else
                str[index++] = sol_CashTray.Description;

            //9
            if(datePaid < date)
                str[index++] = "";
            else
                str[index++] = datePaid.ToShortDateString();
            str[index++] = reference;

            itm = new ListViewItem(str);


            itm.Checked = select;
            if (!String.IsNullOrEmpty(str[9]))    //date paid
            {
                itm.BackColor = System.Drawing.SystemColors.Control;
            }

            listView1.Items.Add(itm);

            return true;
        }


        private void OK_Click(object sender, EventArgs e)
        {
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
                    buttonRefresh.PerformClick();
                    return;
                }

                if (sol_Order.Status != "O" && sol_Order.DatePaid >= sol_Order.Date)
                {
                    MessageBox.Show("Sorry, this order is already paid! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    buttonRefresh.PerformClick();
                    return;
                }

                //open order
                if (sol_Order.DateClosed < sol_Order.Date)
                {
                    MessageBox.Show("Sorry, this order is open! (Order #" + item.SubItems[0].Text.Trim() + ")");
                    buttonRefresh.PerformClick();
                    return;
                }

            }

            int intValue = 0;
            Int32.TryParse(textBoxId.Text, out intValue);

            CustomerOrdersPayNow f1 = new CustomerOrdersPayNow(intValue);
            //CashierCash.buttonSource = "CustomerOrders";
            f1.checkedItems = checkedItems;
            f1.ShowDialog();
            bool ordersProcessed = f1.ordersProcessed;
            f1.Dispose();
            f1 = null;
            if (ordersProcessed)
                buttonRefresh.PerformClick();

        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            if (buttonSelectAll.Text == "&Select all")
            {
                buttonSelectAll.Text = "&Unselect all";
                SelectItems(true);
            }
            else
            {
                buttonSelectAll.Text = "&Select all";
                SelectItems(false);
            }

        }

        private void SelectItems(bool select)
        {
            ListView.ListViewItemCollection Items = listView1.Items;
            foreach (ListViewItem item in Items)
                item.Checked = select;
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

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item;
            if (!item.Checked)
                return;
            if (!String.IsNullOrEmpty(item.SubItems[9].Text))    //date paid
            {
                item.Checked = false;

            }


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

        private void buttonSolum_Click(object sender, EventArgs e)
        {

            listView1.Visible = true;
            dataGridView1.Visible = false;

            //buttonShowAllOrders.BackColor = SystemColors.Control;
            buttonSolum.BackColor = SystemColors.ButtonHighlight;
            buttonQuickDrop.BackColor = SystemColors.Control;
            buttonDrops.BackColor = SystemColors.Control;
            buttonBags.BackColor = SystemColors.Control;
            buttonVoidOrders.BackColor = SystemColors.Control;

            //showOrderType = ShowOrderType.Solum;

            viewType = ViewType.SolumOrders;

            //localCustomerType = 1;
            strOrderType = "R";

            //if (!(radioButtonUnpaidOnly.Checked
            //    && radioButtonShowAll.Checked))
            //{

            //    radioButtonUnpaidOnly.Checked = true;
            //}
            //else

            EnableControls(true);

            if (radioButtonShowAll.Checked)
                radioButtonShowAll_CheckedChanged(radioButtonShowAll, new EventArgs());
            else
                radioButtonShowAll_CheckedChanged(radioButtonUnpaidOnly, new EventArgs());


        }

        private void buttonQuickDrop_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            dataGridView1.Visible = false;

            //buttonShowAllOrders.BackColor = SystemColors.Control;
            buttonSolum.BackColor = SystemColors.Control;
            buttonQuickDrop.BackColor = SystemColors.ButtonHighlight;
            buttonDrops.BackColor = SystemColors.Control;
            buttonBags.BackColor = SystemColors.Control;
            buttonVoidOrders.BackColor = SystemColors.Control;

            //showOrderType = ShowOrderType.QuickDrop;

            viewType = ViewType.QuickDropOrders;

            //localCustomerType = 2;
            strOrderType = "Q";

            //if (!(radioButtonUnpaidOnly.Checked
            //    && radioButtonShowAll.Checked))
            //    radioButtonUnpaidOnly.Checked = true;
            //else
            //    ReadCustomerOrders(radioButtonUnpaidOnly.Checked);

            EnableControls(true);

            if (radioButtonShowAll.Checked)
                radioButtonShowAll_CheckedChanged(radioButtonShowAll, new EventArgs());
            else
                radioButtonShowAll_CheckedChanged(radioButtonUnpaidOnly, new EventArgs());


        }


        private void buttonDrops_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            dataGridView1.Visible = true;

            buttonSolum.BackColor = SystemColors.Control;
            buttonQuickDrop.BackColor = SystemColors.Control;
            buttonDrops.BackColor = SystemColors.ButtonHighlight; 
            buttonBags.BackColor = SystemColors.Control;
            buttonVoidOrders.BackColor = SystemColors.Control;

            viewType = ViewType.CustomerDrops;

            EnableControls(false);

            BindDataGridView("QDS_DropByCustomer");

        }

        private void buttonBags_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            dataGridView1.Visible = true;

            buttonSolum.BackColor = SystemColors.Control;
            buttonQuickDrop.BackColor = SystemColors.Control;
            buttonDrops.BackColor = SystemColors.Control;
            buttonBags.BackColor = SystemColors.ButtonHighlight; 
            buttonVoidOrders.BackColor = SystemColors.Control;

            viewType = ViewType.QuickDropBags;

            EnableControls(false);
            BindDataGridView("QDS_BagsByCustomer");
        }

        private void buttonVoidOrders_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            dataGridView1.Visible = false;

            buttonSolum.BackColor = SystemColors.Control;
            buttonQuickDrop.BackColor = SystemColors.Control;
            buttonDrops.BackColor = SystemColors.Control;
            buttonBags.BackColor = SystemColors.Control;
            buttonVoidOrders.BackColor = SystemColors.ButtonHighlight;

            viewType = ViewType.VoidOrders;

            //localCustomerType = 2;
            strOrderType = "";

            //if (!(radioButtonUnpaidOnly.Checked
            //    && radioButtonShowAll.Checked))
            //    radioButtonUnpaidOnly.Checked = true;
            //else
            //    ReadCustomerOrders(radioButtonUnpaidOnly.Checked);

            EnableControls(false);

            if (radioButtonShowAll.Checked)
                radioButtonShowAll_CheckedChanged(radioButtonShowAll, new EventArgs());
            else
                radioButtonShowAll_CheckedChanged(radioButtonUnpaidOnly, new EventArgs());
        }

        private void EnableControls(bool enabled)
        {
            radioButtonShowAll.Enabled = enabled;
            radioButtonUnpaidOnly.Enabled = enabled;
            OK.Enabled = enabled;
            buttonSelectAll.Enabled = enabled;


        }

        private void BindDataGridView(string sp)
        {
            dataGridView1.DataSource = null;

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (DataTable dt = new DataTable())
                        {
                            cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            // Resize the DataGridView columns to fit the newly loaded content.
                            dataGridView1.AutoResizeColumns(
                                DataGridViewAutoSizeColumnsMode.ColumnHeader);

                            textBoxCurrentBalance.Text = "";

                        }
                    }
                }
            }
        }



    }
}
