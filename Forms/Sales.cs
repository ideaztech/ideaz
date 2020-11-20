
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

using System.Threading;
namespace Solum
{
    public partial class Sales : Form
    {
        #region tableLayoutPanelView2 Variables   //NumericKeyPad On

        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.DataGridView sol_ProductsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxUpc;
        private System.Windows.Forms.Label labelUpc;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private SirLib.NumericTextBox numericTextBoxId;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label labelFilters;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelView2;
        private System.Windows.Forms.Panel panelTableLayoutPanelView2_KeyPad;
        private System.Windows.Forms.Panel panelTableLayoutPanelView2_Buttons;
        private System.Windows.Forms.Label labeBackSpace;
        private System.Windows.Forms.Label labelX02;
        private System.Windows.Forms.Label labelX01;

        //private System.Windows.Forms.Label labelX24;
        //private System.Windows.Forms.Label labelX12;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPad;
        private System.Windows.Forms.Label labelClear;

        private bool flagPeriod = false, flagReiniciar = false;
        public int resultNumber = 0;

        #endregion


        private decimal tax1AmountOrg;
        private decimal tax2AmountOrg;

        //bool flagNumericPad = false;

        //string hexForeColor = "#000000";
        //string hexBackColor = "#f0f0f0";

        DateTime OpenDate;

        //private bool flagClear = false;
        private IButtonControl originalAcceptButton;
        private string buttonClicked = "";

        public bool formReturn = false;
        public bool formCashier = false;

        string strOrderType = "S";  //S = sales

        Sol_Order sol_Order;
        Sol_Order_Sp sol_Order_Sp;
        Sol_OrdersDetail sol_OrdersDetail;
        Sol_OrdersDetail_Sp sol_OrdersDetail_Sp;


        Sol_Product sol_Product;
        Sol_Product_Sp sol_Product_Sp;


        List<Sol_OrdersDetail> sol_OrdersDetailList;

        //static int intCntr = 0;
        private int intQuantityButton = 1;

        //private ArrayList arrayListItems, arrayListControls, arrayListViewProductId, arrayListViewDetailId;
        private ArrayList arrayListViewProductId, arrayListViewDetailId;
        private int indice = 0;//, CategoryButtonID = 0;
        //List<Sol_CategoryButton> sol_CategoryButtonList;
        //Sol_CategoryButton_Sp sol_CategoryButton_Sp;

        //private ArrayList arrayListItemsQuantity, arrayListControlsQuantity;
        //private int indiceQuantity = 0;   //, QuantityButtonID = 0;
        //List<Sol_QuantityButton> sol_QuantityButtonList;
        Sol_QuantityButton_Sp sol_QuantityButton_Sp;


        public Sales(string Texto, string User, string Server)    //, string Today )
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


        private void Sales_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'dataSetFees.sol_Fees_SelectAll' table. You can move, or remove it, as needed.
            this.sol_Fees_SelectAllTableAdapter.Fill(this.dataSetFees.sol_Fees_SelectAll);
            originalAcceptButton = this.AcceptButton;
            this.toolStrip2.Renderer = new App_Code.NewToolStripRenderer();
            if (Properties.Settings.Default.TouchOriented)
            {
                //toolStripButtonVirtualKb.Visible = true;
                keyboardButton.Visible = true;
            }

            //classes of tables
            //sol_Order = new Sol_Order();
            //sol_Order.OrderID = -1;
            sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //sol_OrdersDetail = new Sol_OrdersDetail();
            sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_OrdersDetailList = new List<Sol_OrdersDetail>();


            //sol_Product = new Sol_Product();
            sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);


            //clock
            object obj1 = toolStripStatusLabelToday;
            object obj2 = toolStripStatusLabelTimer;
            Main.rc.CambiarControlFecha(ref obj1);
            Main.rc.CambiarControlHora(ref obj2);

            //disable form resizing
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //disable quick cash out if no cashtray open
            if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)    //quick cash out
                if (Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", true))
                    buttonExtra.Visible = SolFunctions.CheckCashier();

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Qty", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Description", 130, HorizontalAlignment.Left);
            listView1.Columns.Add("Price", 64, HorizontalAlignment.Left);
            listView1.Columns.Add("Amount", 86, HorizontalAlignment.Left);

            listView1.Columns[1].Width = listView1.Width -
                (listView1.Columns[0].Width +
                listView1.Columns[2].Width +
                listView1.Columns[3].Width)-5;
        


        listView1.FullRowSelect = true;
            //listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;

            //array to store categoryid
            this.arrayListViewProductId = new ArrayList();
            this.arrayListViewDetailId = new ArrayList();

            tableLayoutPanelView1.Visible = false;
            CreateTableLayoutPanelView2();
            createProductsList();

            //panelTableLayoutPanelView2_Buttons.BackColor = Color.FromArgb(Main.Sol_ControlInfo.CategoryButtonsPanelBgColor);


            comboBoxOrderId.Text = "";

            //extra button 0 = QuickCashOut 1 = Print Chit
            if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)
                buttonExtra.Text = "&Cash Out";
            else
                buttonExtra.Text = "&Print Chit";

            //taxes
            labelTax1.Text = labelTax1.Text.Replace("Tax1", Main.Sol_ControlInfo.Tax1Name.Trim() + " ");
            if (String.IsNullOrEmpty(Main.Sol_ControlInfo.Tax2Name.Trim()))
            {
                labelTax2.Visible = false;
                numericTextBoxTax2Amount.Visible = false;
            }
            else
                labelTax2.Text = labelTax2.Text.Replace("Tax2", Main.Sol_ControlInfo.Tax2Name.Trim() + " ");

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

            //computer roles
            CheckComputerRole();

            //cash out permission check
            toolStripButtonCashier.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", false);

            if (Main.Sol_ControlInfo.State == "AB"
                && Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)

            {
                toolStripButtonQdCustomer.Visible = true;
                toolStripSeparatorQdCustomer.Visible = true;
            }

            toolStripButtonAttendance.Visible = Properties.Settings.Default.UseAttendance;

            CustomerScreen.ClearCustomerScreen();
            

        }

        
        //private void timer1_Tick(object sender, System.EventArgs e)
        //{
        //    DateTime t = DateTime.Now;
        //    toolStripStatusLabelTimer.Text = t.ToShortTimeString();
        //    toolStripStatusLabelToday.Text = t.ToShortDateString();
        //}


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


        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateChit", true))
                return;

            tax1AmountOrg = 0;
            tax2AmountOrg = 0;

            //date of creation
            OpenDate = Main.rc.FechaActual; // ;
            ClearForm();
            //comboBoxFees.SelectedValue = 0;

            buttonClicked = buttonNew.Text; // "new";
            EnableControls(true);
            EnableButtons("new");


        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            //check if the order is still open 
            if (!CheckOrderStillOpen("Close"))
                return; //false;


            if (sol_Order != null)
            {
                if (buttonClicked == "&New")
                {
                    comboBoxOrderId.Text = sol_Order.OrderID.ToString();
                }

                UpdateTotalTaxAmount();

                CloseOrder(true);
            }
            //view state
            EnableControls(false);
            EnableButtons("close");

            ClearForm();

            this.AcceptButton = originalAcceptButton;
            comboBoxOrderId.Enabled = false;
            comboBoxOrderId.DropDownStyle = ComboBoxStyle.Simple;

        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this operation?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                return;
            CancelProc();
        }

        private void CancelProc()
        {
            EnableControls(false);
            EnableButtons("cancel");
            ClearForm();

            this.AcceptButton = originalAcceptButton;
            comboBoxOrderId.Enabled = false;
            comboBoxOrderId.DropDownStyle = ComboBoxStyle.Simple;

        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            //read and display Order
            buttonClicked = buttonView.Text;    // "view";

            if (buttonClicked == "&Find" && !Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupChit", true))
                return;

            if (buttonClicked == "&Edit")
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolOpenChit", true))
                    return;

                EnableControls(true);
                EnableButtons("edit");
                this.AcceptButton = originalAcceptButton;

                //open order
                CloseOrder(false);

                //select las item, if any
                int index = listView1.Items.Count - 1;
                if (index >= 0)
                {
                    listView1.Items[index].Selected = true;
                    listView1.Focus();
                }

                return;
            }




            EnableButtons("lookup");
            ClearForm();

            comboBoxOrderId.Enabled = true;
            comboBoxOrderId.Text = string.Empty;
            comboBoxOrderId.SelectedIndex = -1;
            comboBoxOrderId.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxOrderId.Focus();


        }


        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolDeleteChit", true))
                return;

            //check if the order is still open 
            if (!CheckOrderStillOpen("Delete"))
                return; //false;

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



            int totalQuantity = Convert.ToInt32(itm.SubItems[0].Text);

            if (lastItem >= 0)
            {

                listView1.Items.RemoveAt(lastItem);
                DeleteRow(itm, lastItem);
                arrayListViewProductId.RemoveAt(lastItem);
                arrayListViewDetailId.RemoveAt(lastItem);

            }


            totals();


            if (Main.CustomerScreenForm != null)
            {
                if (lastItem >= 0)
                {
                    CustomerScreen.listViewReturns.Items.RemoveAt(lastItem);

                }

            }
            int index = listView1.Items.Count - 1;
            if (index >= 0)
            {
                listView1.Items[index].Selected = true;
                listView1.Focus();
            }

        }

        private void toolStripButtonLogOff_Click(object sender, EventArgs e)
        {
            SolFunctions.LogOff(ref toolStripStatusLabelUserName);
            CheckComputerRole();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();

        }


        private void Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            

            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void toolStripButtonReturns_Click(object sender, EventArgs e)
        {
            formReturn = true;
            Close();

        }
        private void toolStripButtonCashier_Click(object sender, EventArgs e)
        {
            formCashier = true;
            Close();


        }

        private void comboBoxOrderId_DropDown(object sender, EventArgs e)
        {
            string userName = Properties.Settings.Default.UsuarioNombre;
            if (userName.ToLower() == "admin")
                userName = "";
            sol_Orders_SelectAllLookupTableAdapter.Fill(this.dataSetOrdersLookup.sol_Orders_SelectAllLookup, userName, strOrderType, "A", "");   //S = sales,  = normal unpaid


        }



        //********
        //routines
        //********

        private bool addItem(int quantity, string description, decimal price, int productId, int detailId)
        {
            //check if the order is still open on New status
            if (detailId < 1)
            {
                if (!CheckOrderStillOpen("Add"))
                    return false;
            }
            string[] str = new string[4];
            ListViewItem itm;   // = new ListViewItem();
            //formatting numbers
            str[0] = String.Format("{0,3}", quantity);
            str[1] = description;
            str[2] = String.Format("{0,6:##0.00}", price);
            str[3] = String.Format("{0,8:#,##0.00}", quantity * price);
            itm = new ListViewItem(str);
            listView1.Items.Add(itm);

            //scroll to last item automatically
            listView1.EnsureVisible(listView1.Items.Count - 1);
            listView1.Update();

            this.arrayListViewProductId.Add(productId);

            if (Main.CustomerScreenForm != null)
            {
                ListViewItem itm2;
                str[0] = String.Format("{0,3}", quantity);
                str[1] = description;
                str[2] = String.Format("{0,6:##0.00}", price);
                str[3] = String.Format("{0,9:##,##0.00}", quantity * price);
                itm2 = new ListViewItem(str);
                CustomerScreen.listViewReturns.Items.Add(itm2);

                //scroll to last item automatically
                CustomerScreen.listViewReturns.EnsureVisible(CustomerScreen.listViewReturns.Items.Count - 1);
                CustomerScreen.listViewReturns.Update();

            }

            if (detailId < 1)
            {
                detailId = AddRow(itm, productId);
                if (detailId < 1)
                    return false;
            }

            if (detailId > 0)
                this.arrayListViewDetailId.Add(detailId);

            return true;
        }

        private void totals()
        {
            int totalqty = 0;
            decimal totalamt = 0.00M;
            int nrows = listView1.Items.Count;

            for (int i = 0; i < nrows; i++)
            {
                totalqty = totalqty + Convert.ToInt32(listView1.Items[i].SubItems[0].Text);
                string c = listView1.Items[i].SubItems[3].Text;
                c = c.Replace('$', ' ');
                totalamt = totalamt + Convert.ToDecimal(c);
            }

            try { totalamt += Decimal.Parse(numericTextBoxTax1Amount.Text); }
            catch { }
            try { totalamt += Decimal.Parse(numericTextBoxTax2Amount.Text); }
            catch { }

            labelTotalQty.Text = String.Format("Quantity:" + Funciones.Indent(2) + "{0,4:#,###}", totalqty);
            labelTotalAmt.Text = String.Format("Amount:"   + "{0,10:$##,##0.00}", totalamt);

            if (Main.CustomerScreenForm != null)
            {
                string totalQty = String.Format("Quantity:\r\n " + Funciones.Indent(20) + "{0,3}", totalqty);
                string totalAmt = String.Format("Amount:\r\n" + Funciones.Indent(8) + "{0,10:$##,##0.00}", totalamt);

                CustomerScreen.labelTotalQty.Text = totalQty;
                CustomerScreen.labelTotalAmt.Text = totalAmt;
            }

        }



        private void EnableControls(bool flag)
        {
            //panelCategoryButtons.Enabled = flag;
            //panelQuantityButtons.Enabled = flag;
            //panelNumericKb.Enabled = flag;
            panelView.Enabled = flag;

            buttonDeleteRow.Enabled = flag;

            numericTextBoxTax1Amount.Enabled = flag;
            numericTextBoxTax2Amount.Enabled = flag;
        }

        private void EnableButtons(string buttonName)
        {
            toolStripButtonReturns.Enabled = true;
            toolStripButtonCashier.Enabled = true;
            toolStripButtonLogOff.Enabled = true;
            //toolStripButtonExit.Enabled = true;
            exitButton.Enabled = true;

            switch (buttonName)
            {
                case "new":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = true;
                    buttonCancel.Enabled = true;    // false;
                    buttonView.Enabled = false;
                    buttonExtra.Enabled = true;

                    //panelNumericKb.Enabled = true;
                    toolStripButtonReturns.Enabled = false;
                    toolStripButtonCashier.Enabled = false;
                    toolStripButtonLogOff.Enabled = false;
                    //toolStripButtonExit.Enabled = false;
                    exitButton.Enabled = false;

                    break;
                case "close":
                    buttonNew.Enabled = true;
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = false;
                    buttonView.Enabled = true;
                    buttonView.Text = "&Find";
                    buttonExtra.Enabled = false;

                    //panelNumericKb.Enabled = false;
                    break;
                case "cancel":
                    buttonNew.Enabled = true;
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = false;
                    buttonView.Enabled = true;
                    buttonView.Text = "&Find";
                    buttonExtra.Enabled = false;

                    //panelNumericKb.Enabled = false;
                    break;
                case "lookup":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = false;
                    buttonExtra.Enabled = false;

                    //panelNumericKb.Enabled = true;
                    break;
                case "search":
                    buttonNew.Enabled = true;
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = true;
                    buttonView.Text = "&Edit";
                    buttonExtra.Enabled = true;

                    //panelNumericKb.Enabled = false;
                    break;
                case "edit":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = true;
                    buttonCancel.Enabled = true;    // false;
                    buttonView.Enabled = false;
                    buttonView.Text = "&Find";
                    buttonExtra.Enabled = true;

                    //panelNumericKb.Enabled = true;
                    toolStripButtonReturns.Enabled = false;
                    toolStripButtonCashier.Enabled = false;
                    toolStripButtonLogOff.Enabled = false;
                    //toolStripButtonExit.Enabled = false;
                    exitButton.Enabled = false;
                    break;
                default:
                    break;

            }


        }

        private void ClearForm()
        {

            comboBoxOrderId.Text = "";

            intQuantityButton = 1;
            listView1.Items.Clear();
            this.arrayListViewProductId.Clear();
            this.arrayListViewDetailId.Clear();

            //flag to prevent comboBoxFees_SelectedIndexChanged to execute
            //flagClear = true;

            numericTextBoxTax1Amount.Text = "";
            numericTextBoxTax2Amount.Text = "";
            //flagClear = false;

            labelTotalQty.Text = "Quantity:";
            labelTotalAmt.Text = "Amount:";

            if (Main.CustomerScreenForm != null)
            {
                CustomerScreen.listViewReturns.Items.Clear();
                CustomerScreen.labelTotalQty.Text = "Quantity:";
                CustomerScreen.labelTotalAmt.Text = "Amount:";
            }

            if (sol_Order != null)
                sol_Order.OrderID = -1;

            //simulate click labelClear
            EventArgs e1 = new EventArgs();
            labelClear_Click(labelClear, e1);



        }

        private bool ReadVoucher(int orderId)
        {

            sol_Order = sol_Order_Sp.Select(orderId, strOrderType);
            if (sol_Order == null)
            {
                MessageBox.Show("Order not found! Try another please.");
                return false;
            }
            //A = normal D = void  O = On account P = paid or processed*/
            string c = "";
            if (sol_Order.Status == "D")
                c = String.Format("Order {0} is voided! Try another please.", sol_Order.OrderID);
            else if (sol_Order.Status == "O" || sol_Order.Status == "P")
                c = String.Format("Order {0} is already paid! Try another please.", sol_Order.OrderID);
            if (c != "")
            {
                MessageBox.Show(c);
                return false;
            }

            numericTextBoxTax1Amount.Text = sol_Order.Tax1Amount.ToString();
            numericTextBoxTax2Amount.Text = sol_Order.Tax2Amount.ToString();

            //search for return
            sol_OrdersDetailList = sol_OrdersDetail_Sp._SelectAllByOrderID_OrderType(orderId, strOrderType);
            if (sol_OrdersDetailList == null)
            {
                MessageBox.Show("Order empty, try another please.");
                return false;
            }

            foreach (Sol_OrdersDetail rd in sol_OrdersDetailList)
            {
                int quantity = rd.Quantity;
                string description = rd.Description;
                decimal price = rd.Price;
                int productId = rd.ProductID;
                addItem(quantity, description, price, productId, rd.DetailID);
            }

            totals();

            return true;
        }

        private void ShowNumericPad()
        {
            KeyPad f1 = new KeyPad();
            f1.ShowDialog();
            if (f1.resultNumber > 0)
                intQuantityButton = f1.resultNumber;
            f1.Dispose();
            f1 = null;
            if (intQuantityButton < 1) intQuantityButton = 1;

            //flagNumericPad = false;

        }

        private string obtainOrderId(string s)
        {
            string[] parts = s.Split('-');

            return parts[0];

        }

        private int AddRow(ListViewItem itm, int productId)
        {
            //if first item, add main row
            if (listView1.Items.Count < 2)
            {
                if (!AddMainRow())
                    return -1;
            }

            //add current row
            sol_OrdersDetail = new Sol_OrdersDetail();

            //detailID
            //orderID
            sol_OrdersDetail.OrderID = sol_Order.OrderID;
            //orderType
            sol_OrdersDetail.OrderType = sol_Order.OrderType;
            //date
            sol_OrdersDetail.Date = sol_Order.Date;
            //status
            sol_OrdersDetail.Status = sol_Order.Status;

            //categoryID
            sol_OrdersDetail.CategoryID = 0;    //<none>

            //productId
            sol_OrdersDetail.ProductID = productId;

            //productID
            //string description
            sol_OrdersDetail.Description = itm.SubItems[1].Text;
            //quantity
            int quantity = Convert.ToInt32(itm.SubItems[0].Text);
            sol_OrdersDetail.Quantity = quantity;
            //price
            decimal price = Convert.ToDecimal(itm.SubItems[2].Text);
            sol_OrdersDetail.Price = price;
            //amount
            string c = itm.SubItems[3].Text;
            c = c.Replace('$', ' ');
            decimal amount = Convert.ToDecimal(c);
            sol_OrdersDetail.Amount = amount;

            //add row
            //sol_OrdersDetail.IsNew = true;
            sol_OrdersDetail_Sp.Insert(sol_OrdersDetail);

            //calculate taxes
            CalculateTax(price, Main.Sol_ControlInfo.Tax1Rate, numericTextBoxTax1Amount, 1);
            if (String.IsNullOrEmpty(Main.Sol_ControlInfo.Tax2Name.Trim()))
                CalculateTax(price, Main.Sol_ControlInfo.Tax2Rate, numericTextBoxTax2Amount, 1);

            UpdateTotalTaxAmount();

            return sol_OrdersDetail.DetailID;
        }


        private void DeleteRow(ListViewItem itm, int index)
        {
            //delete current row
            int detailId = (int)this.arrayListViewDetailId[index];
            sol_OrdersDetail_Sp.Delete(detailId);

            //update taxes
            int productId= (int)this.arrayListViewProductId[index];

            sol_Product = new Sol_Product();
            sol_Product = sol_Product_Sp.Select(productId);
            if (sol_Product != null)
            {

                CalculateTax(sol_Product.Price, Main.Sol_ControlInfo.Tax1Rate, numericTextBoxTax1Amount, -1);
                if (String.IsNullOrEmpty(Main.Sol_ControlInfo.Tax2Name.Trim()))
                    CalculateTax(sol_Product.Price, Main.Sol_ControlInfo.Tax2Rate, numericTextBoxTax2Amount, -1);

                UpdateTotalTaxAmount();
            }

            //delete main row if order empty
            if (listView1.Items.Count < 1)
                if (!DeleteMainRow())
                    return;
        }

        private bool AddMainRow()
        {
            sol_Order = new Sol_Order();

            sol_Order.OrderType = strOrderType;
            sol_Order.WorkStationID = -1;   // Main.Sol_ControlInfo.WorkStationID;

            //computer name
            string c = Properties.Settings.Default.SettingsWsWorkStationName.Trim();
            if (String.IsNullOrEmpty(c))
                c = Main.myHostName;
            sol_Order.ComputerName = c;  // 

            MembershipUser membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot add Order");
                return false;
            }

            Guid userId = (Guid)membershipUser.ProviderUserKey;
            sol_Order.UserID = userId;
            sol_Order.UserName = Properties.Settings.Default.UsuarioNombre;
            sol_Order.Date = OpenDate;  // DateTime.Now;// Properties.Settings.Default.FechaActual;
            sol_Order.CashTrayID = Properties.Settings.Default.SettingsCurrentCashTray;

            sol_Order.CustomerID = 0; // (none)
            sol_Order.Status = "A";    //Applied

            sol_Order.DateClosed = DateTime.Parse("1753-1-1 12:00:00");
            sol_Order.DatePaid = DateTime.Parse("1753-1-1 12:00:00");

            sol_Order.FeeID = 0;
            sol_Order.FeeAmount = Decimal.Zero;
            //sol_Order.IsNew = true;
            sol_Order_Sp.Insert(sol_Order);
            if (sol_Order.OrderID < 1)
                return false;

            comboBoxOrderId.Text = sol_Order.OrderID.ToString();

            return true;

        }

        private bool DeleteMainRow()
        {
            sol_Order_Sp.Delete(sol_Order.OrderID, sol_Order.OrderType);
            //so it does not ask again for unsaved data if the user click cancel and then exit
            sol_Order.DateClosed = sol_Order.Date;
            comboBoxOrderId.Text = "";
            return true;
        }

        private void CloseOrder(bool close)
        {
            if (sol_Order == null)
                return;
            try
            {
                if (sol_Order.OrderType == null)
                    return;
            }
            catch { return; }

            //if (close)
            //    sol_Order.DateClosed = Main.rc.FechaActual; // ;
            //else
            //    sol_Order.DateClosed = DateTime.Parse("1753-1-1 12:00:00");
            //sol_Order_Sp.Update(sol_Order);

            if (close)
                sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");
            else
                sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "1753-1-1 12:00:00", "DateClosed");

        }

        private bool UpdateTotalTaxAmount()
        {

            if (listView1.Items.Count < 1)
                return false;

            //update amounts
            try { sol_Order.Tax1Amount = Decimal.Parse(numericTextBoxTax1Amount.Text); }
            catch { sol_Order.Tax1Amount = Decimal.Zero; }

            try { sol_Order.Tax2Amount = Decimal.Parse(numericTextBoxTax2Amount.Text); }
            catch { sol_Order.Tax2Amount = Decimal.Zero; }
      


            //changes?
            //if (tax1AmountOrg == sol_Order.Tax1Amount && tax2AmountOrg == sol_Order.Tax2Amount)
            //    return true;

            try { sol_Order_Sp.UpdateTaxes(sol_Order.OrderID, sol_Order.OrderType, sol_Order.Tax1Amount, sol_Order.Tax2Amount); }
            catch { return false; }

            return true;
        }


        //
        private bool CheckOrderStillOpen(string mode)
        {
            if (sol_Order == null || sol_Order.OrderID < 1)
                return true;

            sol_Order = sol_Order_Sp.Select(sol_Order.OrderID, sol_Order.OrderType);

            if (sol_Order == null || sol_Order.OrderID < 1)
                return true;

            if (sol_Order.DateClosed >= sol_Order.Date)
            {
                string c;
                if (mode == "Add")
                    c = "This Order is already Closed. You cannot add more items to it!";
                else if (mode == "Close")
                    c = "This Order is already Closed or Paid. You cannot close it again!";
                else if (mode == "Delete")
                    c = "This Order is already Closed. You cannot delete items from it!";
                else
                    return true;

                MessageBox.Show(c);
                CancelProc();
                return false;
            }
            return true;
        }

        private bool CheckComputerNameOnOpenOrders()
        {
            //computer name
            string c = Properties.Settings.Default.SettingsWsWorkStationName.Trim();
            if (String.IsNullOrEmpty(c))
                c = Main.myHostName;

            if (sol_Order.ComputerName != c)
                return false;
            return true;
        }


        #region tableLayoutPanelView2 Routines   //NumericKeyPad On

        private void CreateTableLayoutPanelView2()
        {
            this.tableLayoutPanelView2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTableLayoutPanelView2_KeyPad = new System.Windows.Forms.Panel();
            this.labelClear = new System.Windows.Forms.Label();
            this.labelPad = new System.Windows.Forms.Label();
            this.labeBackSpace = new System.Windows.Forms.Label();
            this.labelX02 = new System.Windows.Forms.Label();
            this.labelX01 = new System.Windows.Forms.Label();
            this.label0 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();

            this.panelTableLayoutPanelView2_Buttons = new System.Windows.Forms.Panel();
            this.tableLayoutPanelView2.SuspendLayout();
            this.panelTableLayoutPanelView2_KeyPad.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelView2
            // 
            //this.tableLayoutPanelView2.BackColor = System.Drawing.SystemColors.WindowText;// .WindowFrame;
            this.tableLayoutPanelView2.BackColor = System.Drawing.Color.FromArgb(235, 247, 255);
            this.tableLayoutPanelView2.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tableLayoutPanelView2.ColumnCount = 2;
            float size1 = 0F;
            float size2 = 0F;
            int col1 = 0;
            int col2 = 0;

            if (Main.Sol_ControlInfo.NumericKeyPadPosition == 0)    //right
            {
                size1 = 275;//CategoryButtons.buttonContainerWidth; // 245F;
                size2 = 367F;
                col1 = 1;
                col2 = 0;
            }
            else
            {
                size1 = 367F;
                size2 = 275;// CategoryButtons.buttonContainerWidth; // 245F;
                col1 = 0;
                col2 = 1;
            }

            this.tableLayoutPanelView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, size1));
            this.tableLayoutPanelView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, size2));
            this.tableLayoutPanelView2.Controls.Add(this.panelTableLayoutPanelView2_KeyPad, col1, 0);
            this.tableLayoutPanelView2.Controls.Add(this.panelTableLayoutPanelView2_Buttons, col2, 0);

            this.tableLayoutPanelView2.Location = new System.Drawing.Point(199, 173);   //199, 173
            this.tableLayoutPanelView2.Name = "tableLayoutPanelView2";
            this.tableLayoutPanelView2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);  //0, 10, 0, 0
            this.tableLayoutPanelView2.RowCount = 1;
            this.tableLayoutPanelView2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelView2.Size = new System.Drawing.Size(642, 482);    //642, 482
            this.tableLayoutPanelView2.TabIndex = 12;

            // 
            // panelTableLayoutPanelView2Left
            // 
            this.panelTableLayoutPanelView2_KeyPad.BackgroundImage = global::Solum.Properties.Resources.NumericKeyPad1;
            this.panelTableLayoutPanelView2_KeyPad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelClear);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelPad);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labeBackSpace);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelX01);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelX02);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label0);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label3);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label2);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label1);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label6);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label5);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label4);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label9);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label8);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label7);
            this.panelTableLayoutPanelView2_KeyPad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableLayoutPanelView2_KeyPad.Location = new System.Drawing.Point(3, 3);
            this.panelTableLayoutPanelView2_KeyPad.Name = "panelTableLayoutPanelView2Left";
            this.panelTableLayoutPanelView2_KeyPad.Size = new System.Drawing.Size(367, 476);
            this.panelTableLayoutPanelView2_KeyPad.TabIndex = 0;
            // 
            // labelClear
            // 
            this.labelClear.BackColor = System.Drawing.Color.Transparent;
            this.labelClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClear.Location = new System.Drawing.Point(250, 4);
            this.labelClear.Name = "labelClear";
            this.labelClear.Size = new System.Drawing.Size(102, 64);
            this.labelClear.TabIndex = 17;
            this.labelClear.Click += new System.EventHandler(this.labelClear_Click);
            // 
            // labelPad
            // 
            this.labelPad.BackColor = System.Drawing.Color.Transparent;
            this.labelPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPad.ForeColor = Color.FromArgb(0, 114, 187);
            this.labelPad.Location = new System.Drawing.Point(16, 3);
            this.labelPad.Name = "labelPad";
            this.labelPad.Size = new System.Drawing.Size(220, 59);
            this.labelPad.TabIndex = 16;
            this.labelPad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labeBackSpace
            // 
            this.labeBackSpace.BackColor = System.Drawing.Color.Transparent;
            this.labeBackSpace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labeBackSpace.Location = new System.Drawing.Point(248, 81);
            this.labeBackSpace.Name = "labeBackSpace";
            this.labeBackSpace.Size = new System.Drawing.Size(102, 64);
            this.labeBackSpace.TabIndex = 15;
            this.labeBackSpace.Click += new System.EventHandler(this.labeBackSpace_Click);

            // 
            // labelX01
            // 
            //Sol_QuantityButton sol_QuantityButton = new Sol_QuantityButton();
            if (sol_QuantityButton_Sp == null)
                sol_QuantityButton_Sp = new Sol_QuantityButton_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Sol_QuantityButton> sol_QuantityButtonList;
            sol_QuantityButtonList = sol_QuantityButton_Sp.SelectAll();

            //string[] str = new string[2];
            //foreach (Sol_EmployeeLookup emp in sol_EmployeeLookupList)
            //{

            Sol_QuantityButton sol_QuantityButton = null;
            if (sol_QuantityButtonList != null)
                if (sol_QuantityButtonList.Count > 0)
                    sol_QuantityButton = sol_QuantityButtonList[0];
            if (sol_QuantityButton == null)
            {
                sol_QuantityButton = new Sol_QuantityButton();
                sol_QuantityButton.Description = "2x";
                sol_QuantityButton.DefaultQuantity = 2;
            }
            this.labelX01.Text = sol_QuantityButton.Description;
            //this.labelX02.ImageIndex = sol_QuantityButton.DefaultQuantity; //i'm using imageIndex to stored defaultQuantity

            this.labelX01.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX01.ForeColor = System.Drawing.Color.FromArgb(0, 114, 187);
            this.labelX01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelX01.BackColor = System.Drawing.Color.Transparent;
            this.labelX01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelX01.Location = new System.Drawing.Point(14, 81);
            this.labelX01.Name = "labelX" + sol_QuantityButton.DefaultQuantity.ToString();
            this.labelX01.Size = new System.Drawing.Size(102, 64);
            this.labelX01.TabIndex = 14;
            this.labelX01.Click += new System.EventHandler(this.labelX_Click);   //this.labelX02_Click);

            // 
            // labelX02
            // 
            sol_QuantityButton = null;
            if (sol_QuantityButtonList != null)
                if (sol_QuantityButtonList.Count > 1)
                    sol_QuantityButton = sol_QuantityButtonList[1];
            if (sol_QuantityButton == null)
            {
                sol_QuantityButton = new Sol_QuantityButton();
                sol_QuantityButton.Description = "6x";
                sol_QuantityButton.DefaultQuantity = 6;
            }
            this.labelX02.Text = sol_QuantityButton.Description;
            //this.labelX02.ImageIndex = sol_QuantityButton.DefaultQuantity; //i'm using imageIndex to stored defaultQuantity

            this.labelX02.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX02.ForeColor = System.Drawing.Color.FromArgb(0, 114, 187);
            this.labelX02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelX02.BackColor = System.Drawing.Color.Transparent;
            this.labelX02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelX02.Location = new System.Drawing.Point(129, 81);
            this.labelX02.Name = "labelX" + sol_QuantityButton.DefaultQuantity.ToString();
            this.labelX02.Size = new System.Drawing.Size(102, 64);
            this.labelX02.TabIndex = 13;
            this.labelX02.Click += new System.EventHandler(this.labelX_Click);  //this.labelX01_Click);
            // 
            // label0
            // 
            this.label0.BackColor = System.Drawing.Color.Transparent;
            this.label0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label0.Location = new System.Drawing.Point(10, 422);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(220, 70);
            this.label0.TabIndex = 12;
            this.label0.Click += new System.EventHandler(this.label0_Click);
            this.label0.DoubleClick += new System.EventHandler(this.label0_Click);

            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Location = new System.Drawing.Point(246, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 67);
            this.label3.TabIndex = 11;
            this.label3.Click += new System.EventHandler(this.label0_Click);
            this.label3.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Location = new System.Drawing.Point(129, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 67);
            this.label2.TabIndex = 10;
            this.label2.Click += new System.EventHandler(this.label0_Click);
            this.label2.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(11, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 67);
            this.label1.TabIndex = 9;
            this.label1.Click += new System.EventHandler(this.label0_Click);
            this.label1.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point(247, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 67);
            this.label6.TabIndex = 8;
            this.label6.Click += new System.EventHandler(this.label0_Click);
            this.label6.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Location = new System.Drawing.Point(129, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 67);
            this.label5.TabIndex = 7;
            this.label5.Click += new System.EventHandler(this.label0_Click);
            this.label5.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Location = new System.Drawing.Point(11, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 67);
            this.label4.TabIndex = 6;
            this.label4.Click += new System.EventHandler(this.label0_Click);
            this.label4.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Location = new System.Drawing.Point(248, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 67);
            this.label9.TabIndex = 5;
            this.label9.Click += new System.EventHandler(this.label0_Click);
            this.label9.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Location = new System.Drawing.Point(130, 164);  //134, 157
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 67);    //98,57
            this.label8.TabIndex = 4;
            this.label8.Click += new System.EventHandler(this.label0_Click);
            this.label8.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Location = new System.Drawing.Point(11, 165);   //15, 158
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 67);         //98, 57
            this.label7.TabIndex = 3;
            this.label7.Click += new System.EventHandler(this.label0_Click);
            this.label7.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // panelTableLayoutPanelView2Right
            // 
            this.panelTableLayoutPanelView2_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableLayoutPanelView2_Buttons.Location = new System.Drawing.Point(3, 3);    //370, 3
            this.panelTableLayoutPanelView2_Buttons.Name = "panelTableLayoutPanelView2Right";
           // this.panelTableLayoutPanelView2_Buttons.Size = new System.Drawing.Size(300, 500);
            this.panelTableLayoutPanelView2_Buttons.Size = new System.Drawing.Size(270, 476);
            // this.panelTableLayoutPanelView2_Buttons.Size = new System.Drawing.Size(CategoryButtons.buttonContainerWidth, CategoryButtons.buttonContainerHeight);
            this.panelTableLayoutPanelView2_Buttons.TabIndex = 1;

            this.panelTableLayoutPanelView2_Buttons.AutoScroll = true;

            
            this.panelTableLayoutPanelView2_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;

            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(959, 716);
            //this.Controls.Add(this.tableLayoutPanelView2);
            //this.Name = "Form1";
            //this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);


            this.panelView.Controls.Add(this.tableLayoutPanelView2);

            this.tableLayoutPanelView2.ResumeLayout(false);
            this.panelTableLayoutPanelView2_KeyPad.ResumeLayout(false);
            this.ResumeLayout(false);


        }

        private void labelClear_Click(object sender, EventArgs e)
        {
            labelPad.Text = "";
            flagPeriod = false;
            flagReiniciar = false;
            resultNumber = 0;

        }

        private void label0_Click(object sender, EventArgs e)
        {
            //System.Media.SystemSounds.Asterisk.Play(); 
            //SoundPlayer click = new SoundPlayer(Properties.Resources.click);
            //click.Play();

            if (labelPad.Text.Length > 22)
                return;

            Label label = (Label)sender;
            string labelText = "";
            switch (label.Name)
            {
                case "labelMinus":
                    labelText = "-";
                    break;
                case "labelPeriod":
                    if (!flagPeriod)
                    {
                        flagPeriod = true;
                        labelText = ".";
                    }
                    break;
                default:
                    labelText = label.Name.Replace("label", "");
                    break;
            }
            DisplayPad(labelText);

        }

        private void DisplayPad(string c)
        {

            if (String.IsNullOrEmpty(c))
                return;

            if (flagReiniciar)
            {
                labelPad.Text = "";
                flagReiniciar = false;
            }

            labelPad.Text += c;

        }

        private void labelX_Click(object sender, EventArgs e)
        {
            //simulate click
            //EventArgs e1 = new EventArgs();
            //labelClear_Click(this.labelClear, e1);

            //Label label = (Label)sender;
            //string labelText = label.Name.Replace("labelX", "");
            //DisplayPad(labelText);


            if (String.IsNullOrEmpty(labelPad.Text))
                labelPad.Text = "1";

            Label label = (Label)sender;
            int Quantity = 0;
            label.Name = label.Name.Replace("labelX", "");
            Int32.TryParse(label.Name, out Quantity);
            Int32.TryParse(labelPad.Text, out resultNumber);
            resultNumber *= Quantity;
            labelPad.Text = resultNumber.ToString();
            flagReiniciar = true;

        }

        private void labelX12_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(labelPad.Text))
            {
                Label label = (Label)sender;
                int Quantity = 0;
                label.Name = label.Name.Replace("labelX", "");
                Int32.TryParse(label.Name, out Quantity);
                Int32.TryParse(labelPad.Text, out resultNumber);
                resultNumber *= Quantity;
                labelPad.Text = resultNumber.ToString();
                flagReiniciar = true;
            }

        }

        private void labelX24_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(labelPad.Text))
            {
                Label label = (Label)sender;
                int Quantity = 0;
                label.Name = label.Name.Replace("labelX", "");
                Int32.TryParse(label.Name, out Quantity);
                Int32.TryParse(labelPad.Text, out resultNumber);
                resultNumber *= Quantity;
                labelPad.Text = resultNumber.ToString();
                flagReiniciar = true;
            }

        }

        private void labeBackSpace_Click(object sender, EventArgs e)
        {
            if (labelPad.Text.Length > 0)
            {
                if (labelPad.Text.EndsWith("."))
                    flagPeriod = false;
                string c = labelPad.Text;
                labelPad.Text = c.Remove(c.Length - 1, 1);
            }

        }


        private void getPadNumber()
        {
            resultNumber = 0;

            if (!String.IsNullOrEmpty(labelPad.Text))
                if (!Int32.TryParse(labelPad.Text, out resultNumber))
                {
                    MessageBox.Show("Error parsing quantity, default to 1 item!");
                    resultNumber = 1;
                }

            //return resultNumber;
        }

        private void createProductsList()
        {
            //this.panelTableLayoutPanelView2_Buttons.SuspendLayout();
            //this.panelProducts.Dock = System.Windows.Forms.DockStyle.Fill;

            panelTableLayoutPanelView2_Buttons.Controls.Clear();


            this.components = new System.ComponentModel.Container();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.sol_ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.textBoxUpc = new System.Windows.Forms.TextBox();
            this.labelUpc = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.numericTextBoxId = new SirLib.NumericTextBox();
            this.labelId = new System.Windows.Forms.Label();

            this.panelFilters = new System.Windows.Forms.Panel();
            this.labelFilters = new System.Windows.Forms.Label();

            this.panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ProductsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsLookup)).BeginInit();
            this.panelFilters.SuspendLayout();

            //this.panelTableLayoutPanelView2_Buttons.SuspendLayout();
            // 
            // panelProducts
            // 
            this.panelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.panelProducts.BackColor = 
            //    System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(56)))));
            this.panelProducts.Location = new System.Drawing.Point(5, 4);   //460, 110
            this.panelProducts.Name = "panelProducts";
            //this.panelProducts.Size = new System.Drawing.Size(250, 276);    //250, 276
            this.panelProducts.TabIndex = 0;
            this.panelProducts.Controls.Add(this.sol_ProductsDataGridView);
            // 
            // sol_ProductsDataGridView
            // 
            sol_ProductsDataGridView.ForeColor = Color.Black;

            this.sol_ProductsDataGridView.AllowUserToAddRows = false;
            this.sol_ProductsDataGridView.AllowUserToDeleteRows = false;
            this.sol_ProductsDataGridView.AutoGenerateColumns = false;
            this.sol_ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sol_ProductsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.sol_ProductsDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sol_ProductsDataGridView.DataSource = this.sol_ProductsBindingSource;

            this.sol_ProductsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;

            this.sol_ProductsDataGridView.AutoSize = true;

            //this.sol_ProductsDataGridView.Location = new System.Drawing.Point(3, 3);  //4, 215
            this.sol_ProductsDataGridView.Name = "sol_ProductsDataGridView";
            this.sol_ProductsDataGridView.RowTemplate.Height = 24;

            //this.sol_ProductsDataGridView.Size = new System.Drawing.Size(262, 519); //257);
        
            this.sol_ProductsDataGridView.TabIndex = 0;
            this.sol_ProductsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sol_ProductsDataGridView_CellClick);


            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 255;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(18, 180);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(196, 22);
            this.textBoxCode.TabIndex = 8;
            this.textBoxCode.TextChanged += new System.EventHandler(this.textBoxCode_TextChanged);
            this.textBoxCode.Enter += new System.EventHandler(this.textBoxCode_Enter);
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCode.Location = new System.Drawing.Point(18, 159);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(45, 17);
            this.labelCode.TabIndex = 7;
            this.labelCode.Text = "&Code:";
            // 
            // textBoxUpc
            // 
            this.textBoxUpc.Location = new System.Drawing.Point(18, 133);
            this.textBoxUpc.Name = "textBoxUpc";
            this.textBoxUpc.Size = new System.Drawing.Size(196, 22);
            this.textBoxUpc.TabIndex = 6;
            this.textBoxUpc.TextChanged += new System.EventHandler(this.textBoxUpc_TextChanged);
            this.textBoxUpc.Enter += new System.EventHandler(this.textBoxUpc_Enter);
            // 
            // labelUpc
            // 
            this.labelUpc.AutoSize = true;
            this.labelUpc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUpc.Location = new System.Drawing.Point(18, 112);
            this.labelUpc.Name = "labelUpc";
            this.labelUpc.Size = new System.Drawing.Size(40, 17);
            this.labelUpc.TabIndex = 5;
            this.labelUpc.Text = "&UPC:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(18, 86);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(196, 22);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelName.Location = new System.Drawing.Point(18, 65);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 17);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "&Name:";
            // 
            // numericTextBoxId
            // 
            this.numericTextBoxId.AllowSpace = false;
            this.numericTextBoxId.Location = new System.Drawing.Point(18, 39);
            this.numericTextBoxId.Name = "numericTextBoxId";
            this.numericTextBoxId.Size = new System.Drawing.Size(137, 22);
            this.numericTextBoxId.TabIndex = 2;
            this.numericTextBoxId.TextChanged += new System.EventHandler(this.numericTextBoxId_TextChanged);
            this.numericTextBoxId.Enter += new System.EventHandler(this.numericTextBoxId_Enter);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelId.Location = new System.Drawing.Point(18, 18);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(23, 17);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "&Id:";
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.SystemColors.Control;
            this.panelFilters.Controls.Add(this.textBoxCode);
            this.panelFilters.Controls.Add(this.labelFilters);
            this.panelFilters.Controls.Add(this.labelCode);
            this.panelFilters.Controls.Add(this.labelId);
            this.panelFilters.Controls.Add(this.textBoxUpc);
            this.panelFilters.Controls.Add(this.numericTextBoxId);
            this.panelFilters.Controls.Add(this.labelUpc);
            this.panelFilters.Controls.Add(this.labelName);
            this.panelFilters.Controls.Add(this.textBoxName);
            this.panelFilters.Location = new System.Drawing.Point(5, 4);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(260, 213);
            this.panelFilters.TabIndex = 1;
            // 
            // labelFilters
            // 
            this.labelFilters.AutoSize = true;
            this.labelFilters.Location = new System.Drawing.Point(72, 3);
            this.labelFilters.Name = "labelFilters";
            this.labelFilters.Size = new System.Drawing.Size(77, 17);
            this.labelFilters.TabIndex = 0;
            this.labelFilters.Text = "Search By:";
            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(959, 716);

            //this.panelTableLayoutPanelView2_Buttons.Controls.Add(this.panelFilters);

            this.panelTableLayoutPanelView2_Buttons.Controls.Add(this.panelProducts);

            //this.Name = "Form1";
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);

            this.panelProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sol_ProductsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsLookup)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            
            this.panelTableLayoutPanelView2_Buttons.ResumeLayout(false);

            //datagridview
            DataGridViewRow row = this.sol_ProductsDataGridView.RowTemplate;
            //row.DefaultCellStyle.BackColor = Color.Bisque;
            row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            row.Height = 35;
            row.MinimumHeight = 20;

            this.sol_ProductsDataGridView.RowHeadersVisible = false;
            //this.sol_ProductsDataGridView.ColumnHeadersVisible = false;

            //this.sol_Products_SelectAllTableAdapter.FillByType(this.dataSetProducts.sol_Products_SelectAll, 1);
            this.sol_ProductsTableAdapter.Fill(this.dataSetProductsLookup.sol_Products, 1);


        }

        private void numericTextBoxId_Enter(object sender, EventArgs e)
        {
            //numericTextBoxId.Text = String.Empty;
            textBoxName.Text = String.Empty;
            textBoxUpc.Text = String.Empty;
            textBoxCode.Text = String.Empty;
        }

        private void numericTextBoxId_TextChanged(object sender, EventArgs e)
        {
            this.sol_ProductsTableAdapter.FillByKey(this.dataSetProductsLookup.sol_Products, 1, "ProductID", numericTextBoxId.Text);
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            numericTextBoxId.Text = String.Empty;
            //textBoxName.Text = String.Empty;
            textBoxUpc.Text = String.Empty;
            textBoxCode.Text = String.Empty;

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            this.sol_ProductsTableAdapter.FillByKey(this.dataSetProductsLookup.sol_Products, 1, "ProName", textBoxName.Text);

        }

        private void textBoxUpc_Enter(object sender, EventArgs e)
        {
            numericTextBoxId.Text = String.Empty;
            textBoxName.Text = String.Empty;
            //textBoxUpc.Text = String.Empty;
            textBoxCode.Text = String.Empty;

        }

        private void textBoxUpc_TextChanged(object sender, EventArgs e)
        {
            this.sol_ProductsTableAdapter.FillByKey(this.dataSetProductsLookup.sol_Products, 1, "UPC", textBoxUpc.Text);

        }

        private void textBoxCode_Enter(object sender, EventArgs e)
        {
            numericTextBoxId.Text = String.Empty;
            textBoxName.Text = String.Empty;
            textBoxUpc.Text = String.Empty;
            //textBoxCode.Text = String.Empty;

        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            this.sol_ProductsTableAdapter.FillByKey(this.dataSetProductsLookup.sol_Products, 1, "ProductCode", textBoxCode.Text);

        }

        private void sol_ProductsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = e.RowIndex;

            int productId = (int)this.sol_ProductsDataGridView.CurrentRow.Cells[0].Value;

            sol_Product = new Sol_Product();
            //Sol_Product_Sp sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_Product = sol_Product_Sp.Select(productId);
            if (sol_Product == null)
            {
                MessageBox.Show("Product not found!");
                return;
            }

            getPadNumber();
            if (resultNumber > 0)
                intQuantityButton = resultNumber;
            if (intQuantityButton < 1) intQuantityButton = 1;

            int totalQuantity = intQuantityButton;    //((Sol_CategoryButton)arrayListControls[indice]).DefaultQuantity * intQuantityButton;

            //simulate click labelClear
            EventArgs e1 = new EventArgs();
            labelClear_Click(labelClear, e1);

            if (!addItem(totalQuantity,
                sol_Product.ProName,                //((Sol_CategoryButton)arrayListControls[indice]).Description,
                sol_Product.Price,                                 //sol_Category.RefundAmount,
                sol_Product.ProductID,                                  //((Sol_CategoryButton)arrayListControls[indice]).CategoryID,
                -1
                ))
            {
                return;
            }

            //
            //updateThreshold(totalQuantity, ((Sol_CategoryButton)arrayListControls[indice]).SubContainerMaxCount, 1);

            totals();

            intQuantityButton = 1;

            //select last item, if any
            int index = listView1.Items.Count - 1;
            if (index >= 0)
            {
                listView1.Items[index].Selected = true;
                listView1.Focus();
            }
        }

        private void CalculateTax(decimal price, decimal tax1Rate, NumericTextBox numericTextBoxTaxAmount, short factor)
        {
            decimal tax1 = price * (tax1Rate / 100);
            decimal tax1Amount = 0;
            Decimal.TryParse(numericTextBoxTaxAmount.Text, out tax1Amount);
            //ignore if substract to zero
            if (factor == -1 && tax1Amount == 0)
                return;
            tax1Amount += tax1 * factor;
            numericTextBoxTaxAmount.Text = tax1Amount.ToString();
        }


        #endregion


        private void comboBoxOrderId_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxOrderId.Text = obtainOrderId(comboBoxOrderId.Text);
            if (String.IsNullOrEmpty(comboBoxOrderId.Text))
            {
                //MessageBox.Show("Please enter a Order number");
                comboBoxOrderId.Focus();
                return;
            }

            int orderId = 0;
            try
            {
                orderId = Int32.Parse(comboBoxOrderId.Text);
            }
            catch
            {
                //MessageBox.Show("Please enter a valid Order number.");
                return;
            }

            if (!ReadVoucher(orderId))
            {
                //MessageBox.Show("Order not found, try another number.");
                return;
            }

            tax1AmountOrg = sol_Order.Tax1Amount;
            tax2AmountOrg = sol_Order.Tax2Amount;

            comboBoxOrderId.Enabled = false;
            comboBoxOrderId.DropDownStyle = ComboBoxStyle.Simple;

            EnableButtons("search");

            if (sol_Order.Status != "A")
                buttonView.Enabled = false;

            if (sol_Order.DateClosed < sol_Order.Date)
            {
                if (!CheckComputerNameOnOpenOrders())
                {
                    if (MessageBox.Show("This Order was created in another terminal. Do not continue unless you know what you are doing. Do you want to continue?",
                        "Warning form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MessageBox.Show("Please make sure that no one else is using this order! Do you still want to continue?", "Warning Form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                        {
                            //edit state
                            buttonView.PerformClick();
                        }
                        else
                        {
                            buttonCancel.Enabled = true;
                            buttonCancel.PerformClick();
                            buttonCancel.Enabled = false;
                        }
                    }
                    else
                    {
                        buttonCancel.Enabled = true;
                        buttonCancel.PerformClick();
                        buttonCancel.Enabled = false;
                    }

                }
                else
                {
                    //edit state
                    buttonView.PerformClick();
                }
            }

        }

        private void buttonExtra_Click(object sender, EventArgs e)
        {
            //if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", true))
            //    return;

            //if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)    //quick cash out
            //    //check cashier
            //    if (!Cashier.CheckCashier())
            //        return;


            //check if the order is still open 
            if (buttonClicked == "&New" || buttonClicked == "&Edit")
                if (!CheckOrderStillOpen("Close"))
                    return; //false;

            if (sol_Order != null)
            {
                comboBoxOrderId.Text = sol_Order.OrderID.ToString();

                UpdateTotalTaxAmount();

                CloseOrder(true);
            }

            //extra button 0 = QuickCashOut 1 = Print Chit
            ListView listView2 = new ListView();
            if (!CreateListView(ref listView2, ""))
                return;

            ListView.ListViewItemCollection Items = listView2.Items;
            foreach (ListViewItem item in Items)
                item.Checked = true;



            if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)    //quick cash out
            {
                ListView.CheckedListViewItemCollection checkedItems = listView2.CheckedItems;
                if (checkedItems.Count < 1)
                {
                    MessageBox.Show("No Orders selected");
                    return;
                }

                CashierCash f1 = new CashierCash();
                f1.checkedItems = checkedItems;
                f1.onAccount = false;
                f1.ShowDialog();
                bool ordersProcessed = f1.ordersProcessed;
                f1.Dispose();
                f1 = null;

                if (!ordersProcessed)
                {
                    //view state
                    EnableControls(false);
                    EnableButtons("search");
                    return;
                }

            }
            else
            {
                //
                this.Cursor = Cursors.WaitCursor;
                string errorMessage = string.Empty;
                bool flag = SolFunctions.PrintReceipt(listView2, "chit", ref errorMessage, Properties.Settings.Default.BarcodeEncoding
                    , "Extra"
                    , String.Empty
                    , 0.0m
                    );
                this.Cursor = Cursors.Default;
                if (!flag)
                {
                    MessageBox.Show("There was a problem printing the receipt, please try again.\nError: " + errorMessage);
                }

            }

            //view state
            EnableControls(false);
            EnableButtons("close");

            ClearForm();

            this.AcceptButton = originalAcceptButton;
            comboBoxOrderId.Enabled = false;
            comboBoxOrderId.DropDownStyle = ComboBoxStyle.Simple;



        }

        private bool CreateListView(ref ListView listView2, string men)
        {
            int orderID = 0;
            Int32.TryParse(comboBoxOrderId.Text, out orderID);
            sol_Order = sol_Order_Sp.Select(orderID, strOrderType);
            if (sol_Order == null)
            {
                MessageBox.Show("Sorry, this order no longer exist! (Order #" + comboBoxOrderId.Text.Trim() + ")");
                return false;
            }

            if (sol_Order.Status != "A")
            {
                MessageBox.Show("Sorry, this order is already paid! (Order #" + comboBoxOrderId.Text.Trim() + ")");
                return false;
            }

            //open order
            if (sol_Order.DateClosed < sol_Order.Date)
            {
                MessageBox.Show("Sorry, this order is open! (Order #" + comboBoxOrderId.Text.Trim() + ")");
                return false;
            }

            //listview with headers
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
            listView2.FullRowSelect = true;
            listView2.CheckBoxes = true;
            listView2.GridLines = true;

            listView2.Items.Clear();
            string[] str = new string[10];
            ListViewItem itm;   // = new ListViewItem();
            str[0] = sol_Order.OrderID.ToString().Trim();
            str[1] = sol_Order.TotalAmount.ToString();
            str[2] = sol_Order.ComputerName;
            str[3] = sol_Order.UserName;
            str[4] = sol_Order.OrderType;
            str[5] = sol_Order.FeeAmount.ToString();
            str[6] = sol_Order.Date.TimeOfDay.ToString().Substring(0, 8);
            str[7] = sol_Order.DateClosed.TimeOfDay.ToString().Substring(0, 8);
            str[8] = sol_Order.Status;

            itm = new ListViewItem(str);
            listView2.Items.Add(itm);

            return true;
        }


        private void toolStripButtonAttendance_Click(object sender, EventArgs e)
        {
            Attendance f1 = new Attendance();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void ButtonNew_EnabledChanged(object sender, EventArgs e)
        {
            buttonNew.Visible = buttonNew.Enabled;
        }

        private void ButtonClose_EnabledChanged(object sender, EventArgs e)
        {
            buttonClose.Visible = buttonClose.Enabled;
        }

        private void ButtonCancel_EnabledChanged(object sender, EventArgs e)
        {
            buttonCancel.Visible = buttonCancel.Enabled;
        }

        private void ButtonView_EnabledChanged(object sender, EventArgs e)
        {
            buttonView.Visible = buttonView.Enabled;
        }

        private void ButtonExtra_EnabledChanged(object sender, EventArgs e)
        {
            buttonExtra.Visible = buttonExtra.Enabled;
        }

        private void ButtonDeleteRow_EnabledChanged(object sender, EventArgs e)
        {
            buttonDeleteRow.Visible = buttonDeleteRow.Enabled;
        }

        private void CheckComputerRole()
        {
            //computer roles
            toolStripButtonCashier.Enabled = true;
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
                    case 1:     //Returns/Sales
                        toolStripButtonCashier.Enabled = false;
                        break;
                    //case 2:     //Cashier
                    //    break;
                    //case 3:     //Shipping
                    //    break;
                    default:    //anything else
                        //toolStripButtonExit.PerformClick();
                        exitButton.PerformClick();
                        break;

                }

            }
        }

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

    }
}
