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

using System.Data.SqlClient;


namespace Solum
{
    public partial class QdBags : Form
    {
        private ListViewItem lastDropItemChecked;
        private ListViewItem lastBagItemChecked;

        //private ListViewItem _curDropItem = null;
        //private ListViewItem _curBagItem = null;

        List<Qds_Drop> qds_DropList;
        //Qds_Drop qds_Drop;
        Qds_Drop_Sp qds_Drop_Sp;

        List<Qds_Bag> qds_BagList;
        //Qds_Bag qds_Bag;
        Qds_Bag_Sp qds_Bag_Sp;

        Qds_PaymentMethod qds_PaymentMethod;
        Qds_PaymentMethod_Sp qds_PaymentMethod_Sp;

        Sol_Customer sol_Customer;
        Sol_Customer_Sp sol_Customer_Sp;

        Sol_Order sol_Order;
        Sol_Order_Sp sol_Order_Sp;

        public int bagID { get; set; }

        int orderID = 0;

        #region QdBags Methods

        public QdBags()
        {
            InitializeComponent();
        }

        private void QdBags_Load(object sender, EventArgs e)
        {
            panelDrops.Dock = DockStyle.Fill;
            panelDrops.Visible = true;

            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (Properties.Settings.Default.TouchOriented)
            {
                this.Height = this.Height + (OK.Height) + 150;
                OK.Height = OK.Height * 2;
                buttonBags.Height = buttonBags.Height * 2;
                buttonRefresh.Height = buttonRefresh.Height * 2;
                Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
                this.radioButtonShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.radioButtonMineOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.CenterToParent();

                //bags
                buttonBagsSelect.Height = buttonBagsSelect.Height * 2;
                buttonBagsRefresh.Height = buttonBagsRefresh.Height * 2;
                buttonBagsClose.Height = buttonBagsClose.Height * 2;
                this.radioButtonBagsShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.radioButtonBagsUnused.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }

            //drops
            //listview with headers
            listViewDrops.View = View.Details;
            listViewDrops.Columns.Add("Drop #", 120, HorizontalAlignment.Right);
            listViewDrops.Columns.Add("Customer", 230, HorizontalAlignment.Left);
            listViewDrops.Columns.Add("Bags", 110, HorizontalAlignment.Right);
            listViewDrops.Columns.Add("Payment Method", 230, HorizontalAlignment.Left);
//            listViewDrop.Columns.Add("DepotID", 120, HorizontalAlignment.Left);
            listViewDrops.Columns.Add("Order #", 120, HorizontalAlignment.Right);
            listViewDrops.Columns.Add("Type", 75, HorizontalAlignment.Center);

            listViewDrops.FullRowSelect = true;
            listViewDrops.CheckBoxes = true;
            listViewDrops.GridLines = true;
            //listViewDrops.Activation = ItemActivation.OneClick;
            listViewDrops.MultiSelect = true;


            //bags
            //listview with headers
            listViewBags.View = View.Details;
            listViewBags.Columns.Add("Bag #", 120, HorizontalAlignment.Right);
            listViewBags.Columns.Add("Date Entered", 230, HorizontalAlignment.Center);
            listViewBags.Columns.Add("Date Counted", 230, HorizontalAlignment.Center);
            listViewBags.Columns.Add("Date Printed", 230, HorizontalAlignment.Center);
            //            listViewDrop.Columns.Add("DepotID", 120, HorizontalAlignment.Left);
            listViewBags.Columns.Add("Order #", 120, HorizontalAlignment.Right);

            listViewBags.FullRowSelect = true;
            listViewBags.CheckBoxes = true;
            listViewBags.GridLines = true;
            //listViewBags.Activation = ItemActivation.OneClick;


            if (qds_Drop_Sp == null)
                qds_Drop_Sp = new Qds_Drop_Sp(Properties.Settings.Default.WsirDbConnectionString);

            if (qds_Bag_Sp == null)
                qds_Bag_Sp = new Qds_Bag_Sp(Properties.Settings.Default.WsirDbConnectionString);

            if (qds_PaymentMethod_Sp == null)
                qds_PaymentMethod_Sp = new Qds_PaymentMethod_Sp(Properties.Settings.Default.WsirDbConnectionString);

            if (sol_Customer_Sp == null)
                sol_Customer_Sp = new Sol_Customer_Sp(Properties.Settings.Default.WsirDbConnectionString);


            radioButtonMineOnly.Checked = true;

            ReadDrops(radioButtonMineOnly.Checked);


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

        #endregion

        #region Drops Methods

        private void radioButtonShowAll_CheckedChanged(object sender, EventArgs e)
        {

            ReadDrops(!radioButtonShowAll.Checked);
            buttonMissingBags.Visible = !checkBoxMissingBags.Checked;
            buttonBagsMissingBags.Visible = !checkBoxMissingBags.Checked;

        }

        private void ReadDrops(bool MineOnly)
        {
            listViewDrops.Items.Clear();

            string orderType = String.Empty;
            if (checkBoxMissingBags.Checked)
                orderType = "M";
            else
                orderType = "Q";

            //qds_DropList = qds_Drop_Sp.SelectAllInProcess();
            qds_DropList = qds_Drop_Sp.SelectAllByOrderTpe(orderType);
            if (qds_DropList != null)
                if (buttonBags.Text == "&Unselect all")
                    buttonBags.Text = "&Select all";


            Guid UserId = new Guid();
            if (MineOnly)
            {
                if (sol_Order_Sp == null)
                    sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);

                MembershipUser UserAccount = Membership.GetUser();
                UserId = (Guid)UserAccount.ProviderUserKey;
            }

            //dropID
            //customer
            //bags
            //paymentMethod
            //depotID
            //orderID

            foreach (Qds_Drop or in qds_DropList)
            {

                if (MineOnly)
                {
                    //is not user's order if does not exist
                    if (or.OrderID < 1)
                        continue;

                    sol_Order = sol_Order_Sp.Select(or.OrderID, or.OrderType);
                    //is not user's order if does not exist
                    if (sol_Order == null)
                        continue;

                    if(UserId != null)
                        if (UserId  != sol_Order.UserID)
                            continue;

                }

                int dropID = or.DropID;
                string customer = or.CustomerID.ToString();
                sol_Customer = sol_Customer_Sp.Select(or.CustomerID);
                if (sol_Customer != null)
                    customer = sol_Customer.Name;

                int bags = or.NumberOfBags;

                string paymentMethod = or.PaymentMethodID.ToString();
                qds_PaymentMethod = qds_PaymentMethod_Sp.Select(or.PaymentMethodID);
                if (qds_PaymentMethod != null)
                    paymentMethod = qds_PaymentMethod.PaymentMethod;

                string depotID = or.DepotID;
                int orderID = or.OrderID;

                addDropItem(dropID, customer, bags, paymentMethod, depotID, orderID, or.OrderType);
            }

        }

        private bool addDropItem(int dropID, string customer, int bags, string paymentMethod, string depotID, int orderID, string orderType)
        {
            string[] str = new string[8];
            ListViewItem itm = new ListViewItem();

            //formatting numbers
            string c = String.Empty;    //.Format("{0,8:#,###}", dropID);
            int index = 0;
            str[index++] = String.Format("{0,6:#}", dropID);
            str[index++] = customer;
            str[index++] = String.Format("{0,6:##,###}", bags);
            str[index++] = paymentMethod;
            if (orderID > 0)
                str[index++] = String.Format("{0,6:#}", orderID);
            else
                index++;
            str[index++] = orderType;

            itm = new ListViewItem(str);

            //itm.Checked = select;
            //if (!String.IsNullOrEmpty(str[10]))    //date paid
            //    itm.BackColor = System.Drawing.SystemColors.Control;

            listViewDrops.Items.Add(itm);

            return true;
        }

        private void listViewDrop_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewDrops.CheckedItems;
            if (checkedItems.Count > 0)
            {
                MessageBox.Show("Please Unselect all Orders before sorting by column!");
                return;
            }

            //sort
            SirLib.ListViewItemComparer.ColumnClick((ListView)sender, e);

        }

        private void listViewDrop_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            //if (_curDropItem != null)
            //{
            //    _curDropItem.Checked = false;
            //}
            //_curDropItem = e.Item;

            ////ListViewItem item = e.Item;
            //if (!e.Item.Checked)
            //    return;

            //if (!String.IsNullOrEmpty(e.item.SubItems[10].Text))    //date paid
            //{
            //    e.item.Checked = false;

            //}

            // if we have the lastItem set as checked, and it is different
            // item than the one that fired the event, uncheck it
            if (lastDropItemChecked != null && lastDropItemChecked.Checked
                && lastDropItemChecked != listViewDrops.Items[e.Item.Index])
            {
                // uncheck the last item and store the new one
                lastDropItemChecked.Checked = false;
                this.lastDropItemChecked.BackColor = SystemColors.Window;
            }

            // store current item
            lastDropItemChecked = listViewDrops.Items[e.Item.Index];




        }

        private void listViewDrops_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes =
            this.listViewDrops.SelectedIndices;

            foreach (int index in indexes)
            {
                this.listViewDrops.Items[index].Checked = !this.listViewDrops.Items[index].Checked;
                if (this.listViewDrops.Items[index].Checked)
                    this.listViewDrops.Items[index].BackColor = Color.LightGray;    // SystemColors.ControlLight;
                else
                    this.listViewDrops.Items[index].BackColor = SystemColors.Window;

                //break;
            }

        }



        private void OK_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewDrops.CheckedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("No Bag selected");
                return;
            }

            foreach (ListViewItem item in checkedItems)
            {
                bagID = 0;
                //Int32.TryParse(item.SubItems[0].Text, out bagID);
                break;
            }
            Close();


        }

        private void buttonBags_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewDrops.CheckedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("No Drop selected");
                return;
            }

            foreach (ListViewItem item in checkedItems)
            {
                textBoxDropID.Text = item.SubItems[0].Text;
                textBoxCustomer.Text = item.SubItems[1].Text;
                orderID = 0;
                Int32.TryParse(item.SubItems[4].Text, out orderID);

                break;
            }


            panelDrops.Visible = false;
            panelDrops.Dock = DockStyle.None;

            panelBags.Dock = DockStyle.Fill;
            panelBags.Visible = true;

            radioButtonBagsUnused.Checked = true;

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ReadDrops(!radioButtonShowAll.Checked);
        }


        #endregion

        #region Bags Methods

        private void buttonBagsClose_Click(object sender, EventArgs e)
        {
            radioButtonBagsShowAll.Checked = false;
            radioButtonBagsUnused.Checked = false;

            panelBags.Visible = false;
            panelBags.Dock = DockStyle.None;

            panelDrops.Dock = DockStyle.Fill;
            panelDrops.Visible = true;

        }

        private void radioButtonBagsShowAll_CheckedChanged(object sender, EventArgs e)
        {
            ReadBags(!radioButtonBagsShowAll.Checked);
            labelUsedBags.Visible = radioButtonBagsShowAll.Checked;

        }

        private void ReadBags(bool UnusedOnly)
        {
            int intValue =0;
            Int32.TryParse(textBoxDropID.Text, out intValue);
            if (intValue == 0)
                return;

            qds_BagList = qds_Bag_Sp._SelectAllByDropID(intValue);
            //if (qds_BagList != null)
            //    if (buttonBags.Text == "&Unselect all")
            //        buttonBags.Text = "&Select all";

            listViewBags.Items.Clear();

            //Bag #
            //Date Entered
            //Date Counted
            //Date Printed
            ////DepotID
            //Order #

            foreach (Qds_Bag or in qds_BagList)
            {

                if (UnusedOnly)
                {
                    //its used
                    if (or.DateCounted.Year > 1753)
                        continue;
                }

                int BagID = or.BagID;
                string dateEntered = String.Empty;
                if(or.DateEntered.Year > 1753)
                    dateEntered = or.DateEntered.ToShortDateString();
                string dateCounted = String.Empty;
                if (or.DateCounted.Year > 1753)
                    dateCounted = or.DateCounted.ToShortDateString();
                string datePrinted = String.Empty;
                if (or.DatePrinted.Year > 1753)
                    datePrinted = or.DatePrinted.ToShortDateString();


                int oid = orderID;
                if (or.DateCounted.Year <= 1753)
                    oid = 0;
                addBagItem(BagID, dateEntered, dateCounted, datePrinted, oid);
            }
        }

        private bool addBagItem(int BagID, string dateEntered, string dateCounted, string datePrinted, int orderID)
        {
            string[] str = new string[7];
            ListViewItem itm = new ListViewItem();

            //formatting numbers
            string c = String.Empty;    //.Format("{0,8:#,###}", BagID);
            int index = 0;
            str[index++] = String.Format("{0,6:#}", BagID);
            str[index++] = dateEntered;
            str[index++] = dateCounted;
            str[index++] = datePrinted;
            if (orderID > 0)
                str[index++] = String.Format("{0,6:#}", orderID);

            itm = new ListViewItem(str);

            ////itm.Checked = select;
            //if (!String.IsNullOrEmpty(str[2]))    //dateCounted
            //    itm.BackColor = System.Drawing.SystemColors.Control;

            listViewBags.Items.Add(itm);

            return true;
        }

        private void listViewBags_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            //if (_curBagItem != null)
            //{
            //    _curBagItem.Checked = false;
            //}
            //_curBagItem = e.Item;

            ListViewItem item = e.Item;
            if (!item.Checked)
                return;

            if (!String.IsNullOrEmpty(item.SubItems[2].Text))    //dateCounted
            {
                item.Checked = false;
                MessageBox.Show("You cannot select this bag, is already counted!");
                return;
            }

            // if we have the lastItem set as checked, and it is different
            // item than the one that fired the event, uncheck it
            if (lastBagItemChecked != null && lastBagItemChecked.Checked
                && lastBagItemChecked != listViewBags.Items[e.Item.Index])
            {
                // uncheck the last item and store the new one
                lastBagItemChecked.Checked = false;
                this.lastBagItemChecked.BackColor = SystemColors.Window;
            }

            // store current item
            lastBagItemChecked = listViewBags.Items[e.Item.Index];



        }

        private void buttonBagsSelect_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewBags.CheckedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("No Bag selected");
                return;
            }

            foreach (ListViewItem item in checkedItems)
            {
                int intValue = 0;
                Int32.TryParse(item.SubItems[0].Text, out intValue);
                bagID = intValue;

                break;
            }

            Close();

        }

        private void listViewBags_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes =
            this.listViewBags.SelectedIndices;

            foreach (int index in indexes)
            {
                this.listViewBags.Items[index].Checked = !this.listViewBags.Items[index].Checked;
                if (this.listViewBags.Items[index].Checked)
                    this.listViewBags.Items[index].BackColor = Color.LightGray;    // SystemColors.ControlLight;
                else
                    this.listViewBags.Items[index].BackColor = SystemColors.Window;

                //break;
            }

        }

        private void listViewBags_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewBags.CheckedItems;
            if (checkedItems.Count > 0)
            {
                MessageBox.Show("Please Unselect all Bags before sorting by column!");
                return;
            }

            SirLib.ListViewItemComparer.ColumnClick((ListView)sender, e);

        }

        //private void SelectItems(bool select)
        //{
        //    ListView.ListViewItemCollection Items = listViewBags.Items;
        //    foreach (ListViewItem item in Items)
        //        item.Checked = select;
        //}

        #endregion

        private void buttonMissingBags_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewDrops.CheckedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("No Drop selected");
                return;
            }

            string strDropId = string.Empty;
            int orderId = 0;
            foreach (ListViewItem item in checkedItems)
            {
                strDropId = item.SubItems[0].Text;
                orderId = 0;
                Int32.TryParse(item.SubItems[4].Text, out orderId);
                break;
            }

            int missingBags = 0;

            List<int> listOfBagsCounted = new List<int>();
            List<int> listOfBagsNotCounted = new List<int>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                string sql = string.Empty;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    sql = @"
                        select [BagID]
                        from [qds_bag] 
                        where [DropID] = @DropId 
                        AND YEAR([DateCounted]) > 1753 
                    ";

                    sql = sql.Replace("@DropId", strDropId);
                    command.CommandText = sql;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listOfBagsCounted.Add((int)reader[0]);
                        }
                    }

                    sql = sql.Replace("> 1753", "= 1753");
                    command.CommandText = sql;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listOfBagsNotCounted.Add((int)reader[0]);
                        }
                    }

                }
            }

            missingBags =  listOfBagsNotCounted.Count;

            string m = String.Format("{0} bags from this drop have not been counted yet.  Do you want to complete this order and set the status of the rest of the bags to MISSING?", missingBags);
            if (MessageBox.Show(m, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                return;


            //busy cursor
            this.Cursor = Cursors.WaitCursor;

            SolFunctions.CompleteOrder(
            orderId
            , "Q"
            , ref listOfBagsCounted
            , ref listOfBagsNotCounted
            );

            //Add comment to order
            if (sol_Order_Sp == null)
                sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_Order = sol_Order_Sp.Select(orderId, "Q");
            if (sol_Order != null)
            {
                sol_Order.Comments += string.Format("Bags Counted: {0} Bags Missing: {1}. ", listOfBagsCounted.Count(), missingBags);
                sol_Order_Sp.Update(sol_Order);

            }

            this.Cursor = Cursors.Default;
            MessageBox.Show("Ready!");

            buttonRefresh.PerformClick();


        }

        private void buttonBagsMissingBags_Click(object sender, EventArgs e)
        {
            buttonBagsClose.PerformClick();
            buttonMissingBags.PerformClick();

        }

        private void listViewDrops_Click(object sender, EventArgs e)
        {

        }
    }
}
