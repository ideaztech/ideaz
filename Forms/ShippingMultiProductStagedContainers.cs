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

//using System.Runtime.InteropServices;

namespace Solum
{
    public partial class ShippingMultiProductStagedContainers : Form
    {
        #region Variables

        Sol_Agencie_Sp sol_Agency_Sp;

        //Sol_Product sol_Product;
        Sol_Product_Sp sol_Product_Sp;

        Timer timerBlink;
        Button tslCntr;
        int intCntr = 0;

        Button buttonBagPositionClicked = null;
        MembershipUser membershipUser;

        //Sol_AutoNumber sol_AutoNumber;
        Sol_AutoNumber_Sp sol_AutoNumber_Sp;
        string tagNumber = string.Empty;


        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;

        //Vir_BagPosition vir_BagPosition;
        Vir_BagPosition_Sp vir_BagPosition_Sp;


        private ArrayList arrayListBagPositionButtons;
        private ArrayList arrayListBagPositionObjects;
        private ArrayList arrayListBagPositionTagNumbers;

        Sol_Order_Sp sol_Orders_Sp;
        Sol_OrdersDetail_Sp sol_OrdersDetail_Sp;
        //Sol_OrdersDetail sol_OrdersDetail;

        int currentOrderDetailID = 0;

        int[] conveyors = new int[] { 0, 0 };
        int currentConveyorID = 0;
        int currentMasterProductID = 0;

        ListView currentListView;

        bool isItemChecking = false;

        Vir_Conveyor_Sp vir_Conveyor_Sp;
        //Vir_Conveyor vir_Conveyor;

        //MembershipUser membershipUser;

        private bool flagChange = false;

        //private string buttonClicked = "";

        public int ShippingForm = 0;    //1 - Home, 2 - StagedContainers, 3 - Shipments 4 - lookup, 5 - Adjustments

        #endregion

        public ShippingMultiProductStagedContainers(string Texto, string User, string Server, string Today)
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
                this.WindowState = FormWindowState.Maximized;
                //if (Properties.Settings.Default.SettingsAdHideTaskBar)
                //{
                //    this.ControlBox = true;
                //    this.MaximizeBox = false;
                //    this.MinimizeBox = false;
                //}
            }
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void ShippingMultiProductStagedContainers_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Warn Lost data upon exit
            if (flagChange)
            {
                if (MessageBox.Show("You have unsaved data, do you want to exit anyway?", "Closing form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void ShippingMultiProductStagedContainers_Load(object sender, EventArgs e)
        {

            //this.Width = 1280;
            //this.Height = 1024;
            //this.CenterToScreen();

            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            //clock
            object obj1 = toolStripStatusLabelToday;
            object obj2 = toolStripStatusLabelTimer;
            Main.rc.CambiarControlFecha(ref obj1);
            Main.rc.CambiarControlHora(ref obj2);

            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Product", 230, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantity", 140, HorizontalAlignment.Right);
            listView1.Columns.Add("OrderID", 150, HorizontalAlignment.Right);
            listView1.Columns.Add("MasterProductID", 150, HorizontalAlignment.Right);

            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.Activation = ItemActivation.OneClick;
            listView1.HideSelection = false;

            //listview with headers
            listView2.View = View.Details;
            listView2.Columns.Add("Product", 230, HorizontalAlignment.Left);
            listView2.Columns.Add("Quantity", 140, HorizontalAlignment.Right);
            listView2.Columns.Add("OrderID", 150, HorizontalAlignment.Right);
            listView2.Columns.Add("MasterProductID", 150, HorizontalAlignment.Right);

            listView2.FullRowSelect = true;
            listView2.CheckBoxes = true;
            listView2.GridLines = true;
            listView2.MultiSelect = false;
            listView2.Activation = ItemActivation.OneClick;
            listView2.HideSelection = false;

            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }

            CheckUserPermissions();

            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            this.toolStripMenuItemModify.Click += new System.EventHandler(this.toolStripMenuItemModify_Click);

            FillData();

            timer1.Interval = 5 * 1000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Enabled = true;

            //blinking timer
            timerBlink = new System.Windows.Forms.Timer();  //this.components);
            timerBlink.Interval = 250;
            timerBlink.Tick += new System.EventHandler(timerBlink_Tick);


        }

        private void CreateBagPositionButtons()
        {


        }

        private void CheckUserPermissions()
        {
            toolStripButtonShipmentAdjustments.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAdjustContainer", false);
            toolStripButtonLookup.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", false);

            //buttonNew.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);

        }

        private void toolStripButtonHome_Click(object sender, EventArgs e)
        {
            ShippingForm = 1;   //Home
            Close();

        }

        private void toolStripButtonStagedContainers_Click(object sender, EventArgs e)
        {
            ShippingForm = 2;   //StagedContainers
            Close();

        }

        private void toolStripButtonShipments_Click(object sender, EventArgs e)
        {
            ShippingForm = 3;   //Shipments
            Close();

        }

        private void toolStripButtonLookup_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", true))
                return;

            ShippingForm = 4;   //lookup
            Close();
        }

        private void toolStripButtonShipmentAdjustments_Click(object sender, EventArgs e)
        {
            ShippingForm = 5;   //Adjustments
            Close();

        }

        private void EnableControls(bool flag)
        {
            //comboBoxContainers.Enabled = flag;
            //comboBoxProducts.Enabled = flag;

            //textBoxDozen.ReadOnly = !flag;
            //textBoxRemarks.ReadOnly = !flag;

        }

        private void ClearForm()
        {
            //textBoxStageID.Text = "";
            //textBoxUserName.Text = "";
            //textBoxDate.Text = "";


            //for upon exit
            flagChange = false;



        }

        private void FillForm()
        {
            //textBoxStageID.Text = sol_Stage.StageID.ToString();

            //textBoxUserName.Text = sol_Stage.UserName;
            //textBoxDate.Text = sol_Stage.Date.ToString("G");

            //this.comboBoxProducts.SelectedIndexChanged -= new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
            //comboBoxProducts.SelectedValue = sol_Stage.ProductID;
            //this.comboBoxProducts.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);

        }

        private void EnableButtons(string buttonName)
        {

            toolStripButtonHome.Enabled = true;
            toolStripButtonStagedContainers.Enabled = true;
            toolStripButtonShipments.Enabled = true;
            toolStripButtonLookup.Enabled = true;
            toolStripButtonLogOff.Enabled = true;
            toolStripButtonExit.Enabled = true;

            switch (buttonName)
            {
                case "new":
                    //buttonNew.Enabled = false;
                    //buttonClose.Enabled = true;
                    //buttonCancel.Enabled = true;
                    //buttonView.Enabled = false;
                    //buttonSearch.Enabled = false;
                    //buttonPrintLabel.Enabled = false;

                    //panelNumericKb.Enabled = true;

                    toolStripButtonHome.Enabled = false;
                    toolStripButtonStagedContainers.Enabled = false;
                    toolStripButtonShipments.Enabled = false;
                    toolStripButtonLookup.Enabled = false;
                    toolStripButtonLogOff.Enabled = false;
                    toolStripButtonExit.Enabled = false;

                    break;
                case "close":
                    //buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
                    //buttonClose.Enabled = false;
                    //buttonCancel.Enabled = true;
                    //buttonView.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolModifyContainer", false);
                    //buttonView.Text = "&Edit";
                    //buttonSearch.Enabled = false;
                    //buttonPrintLabel.Enabled = true;
                    //panelNumericKb.Enabled = false;
                    break;
                case "cancel":
                    //buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
                    //buttonClose.Enabled = false;
                    //buttonCancel.Enabled = false;
                    //buttonView.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewContainer", false);
                    //buttonView.Text = "&View";
                    //buttonSearch.Enabled = false;
                    //buttonPrintLabel.Enabled = false;
                    //panelNumericKb.Enabled = false;
                    break;
                case "view":
                    //buttonNew.Enabled = false;
                    //buttonClose.Enabled = false;
                    //buttonCancel.Enabled = true;
                    //buttonView.Enabled = false;
                    //buttonSearch.Enabled = true;
                    //buttonPrintLabel.Enabled = false;
                    //panelNumericKb.Enabled = true;
                    break;
                case "search":
                    //buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
                    //buttonClose.Enabled = false;
                    //buttonCancel.Enabled = true;
                    //buttonView.Enabled = true  & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolModifyContainer", false);;
                    //buttonView.Text = "&Edit";
                    //buttonSearch.Enabled = false;
                    //buttonPrintLabel.Enabled = true;
                    //panelNumericKb.Enabled = false;
                    break;
                case "edit":
                    //buttonNew.Enabled = false;
                    //buttonClose.Enabled = true;
                    //buttonCancel.Enabled = true;
                    //buttonView.Enabled = false;
                    //buttonView.Text = "&View";
                    //buttonSearch.Enabled = false;
                    //buttonPrintLabel.Enabled = false;
                    //panelNumericKb.Enabled = true;
                    toolStripButtonHome.Enabled = false;
                    toolStripButtonStagedContainers.Enabled = false;
                    toolStripButtonShipments.Enabled = false;
                    toolStripButtonLookup.Enabled = false;
                    toolStripButtonLogOff.Enabled = false;
                    toolStripButtonExit.Enabled = false;
                    break;
                default:
                    break;

            }

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

        private void toolStripButtonLogOff_Click(object sender, EventArgs e)
        {
            //hacer logout si el usuario estaba conectado
            SolFunctions.LogOff(ref toolStripStatusLabelUserName);
            SolFunctions.CheckComputerRole(ref toolStripButtonExit);

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolShipping", true))
            {
                toolStripButtonExit.PerformClick();
                return;
            }

            CheckUserPermissions();

        }

        private void toolStripButtonAttendance_Click(object sender, EventArgs e)
        {
            Attendance f1 = new Attendance();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillData()
        {
            //Conveyors
            FillDataConveyors();

            //ListViews
            FillDataListView(listView1, conveyors[0]);
            FillDataListView(listView2, conveyors[1]);

            //bagposition buttons
            FillDataBagPosition();

        }

        private void FillDataConveyors()
        {
            //conveyors
            if (vir_Conveyor_Sp == null)
                vir_Conveyor_Sp = new Vir_Conveyor_Sp(Properties.Settings.Default.WsirDbConnectionString);
            int index = 0;

            List<Vir_Conveyor> vir_ConveyorList = vir_Conveyor_Sp.SelectAll();
            foreach (Vir_Conveyor c in vir_ConveyorList)
            {
                if (index == 0)
                {
                    labelConveyor1.Text = c.ConveyorDescription;
                    conveyors[0] = c.ConveyorID;
                }
                else if (index == 1)
                {
                    labelConveyor2.Text = c.ConveyorDescription;
                    conveyors[1] = c.ConveyorID;
                }
                else
                    break;
                index++;
            }

        }

        private void FillDataListView(ListView listView, int conveyorID)
        {

            listView.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            listView.SelectedIndexChanged -= new System.EventHandler(this.listView1_SelectedIndexChanged);

            //save selected item
            int orderDetailID = 0;
            ListView.CheckedListViewItemCollection checkedItems = listView.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                int.TryParse(item.SubItems[2].Text, out orderDetailID);
                break;
            }

            listView.Items.Clear();
            string[] str = new string[4];

            List<MultiProductOrderDetail> odList = new List<MultiProductOrderDetail>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sol_OrdersDetail_SelectAllByConveyorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ConveyorID", conveyorID));
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MultiProductOrderDetail od = new MultiProductOrderDetail();
                            int index = 0;
                            od.DetailID = (int)reader[index++];
                            od.ProductID = (int)reader[index++];
                            od.ProductDescription = (string)reader[index++];
                            od.Quantity = (int)reader[index++];
                            od.Price = (decimal)reader[index++];
                            od.Amount = (decimal)reader[index++];
                            od.MasterProductID = (int)reader[index++];
                            od.AgencyID = (int)reader[index++];
                            od.AutoGenerateTagNumber = (bool)reader[index++];
                            odList.Add(od);
                        }
                    }
                }
            }

            foreach (MultiProductOrderDetail od in odList)
            {
                str[0] = od.ProductDescription;
                str[1] = String.Format("{0,6:##,##0}", od.Quantity);
                str[2] = od.DetailID.ToString();
                str[3] = od.MasterProductID.ToString();
                ListViewItem itm = new ListViewItem(str);

                if (orderDetailID == od.DetailID)
                {
                    itm.Selected = true;
                    itm.Checked = true;

                    if (listView.Name.ToLower() == "listview1")
                        currentConveyorID = 1;
                    else
                        currentConveyorID = 2;
                    Int32.TryParse(itm.SubItems[2].Text, out currentOrderDetailID);
                    Int32.TryParse(itm.SubItems[3].Text, out currentMasterProductID);

                }

                listView.Items.Add(itm);
            }

            listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            listView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isItemChecking)
                return;

            isItemChecking = true;

            if (e.NewValue == CheckState.Checked)
            {
                ListView lv = (ListView)sender;
                foreach (ListViewItem item in lv.Items)
                {
                    if (item.Index == e.Index)
                        continue;

                    item.Checked = false;
                }

                lv.Items[e.Index].Checked = true;
            }
            isItemChecking = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                currentListView = (ListView)sender;
                if (currentListView.Name.ToLower() == "listview1")
                {
                    SolFunctions.CheckAllItemsListView(listView2, false);
                    currentConveyorID = 1;
                }
                else
                {
                    SolFunctions.CheckAllItemsListView(listView1, false);
                    currentConveyorID = 2;
                }
                Int32.TryParse(e.Item.SubItems[2].Text, out currentOrderDetailID);
                Int32.TryParse(e.Item.SubItems[3].Text, out currentMasterProductID);
            }
            else
            {
                currentListView = null;
                currentOrderDetailID = 0;
                currentMasterProductID = 0;
                currentConveyorID = 0;
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView1 = (ListView)sender;

            ListView.SelectedIndexCollection indexes = listView1.SelectedIndices;

            foreach (int index in indexes)
            {
                listView1.Items[index].Checked = !listView1.Items[index].Checked;
                if (listView1.Items[index].Checked)
                    listView1.Items[index].BackColor = Color.LightGray;    // SystemColors.ControlLight;
                else
                    listView1.Items[index].BackColor = SystemColors.Window;
                //break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            //ListViews
            FillDataListView(listView1, conveyors[0]);
            FillDataListView(listView2, conveyors[1]);

            timer1.Start();

        }

        void FillDataBagPosition()
        {
            arrayListBagPositionButtons = new ArrayList();
            arrayListBagPositionButtons.Add(buttonBagPosition_01);
            arrayListBagPositionButtons.Add(buttonBagPosition_02);
            arrayListBagPositionButtons.Add(buttonBagPosition_03);
            arrayListBagPositionButtons.Add(buttonBagPosition_04);
            arrayListBagPositionButtons.Add(buttonBagPosition_05);
            arrayListBagPositionButtons.Add(buttonBagPosition_06);
            arrayListBagPositionButtons.Add(buttonBagPosition_07);
            arrayListBagPositionButtons.Add(buttonBagPosition_08);

            arrayListBagPositionObjects = new ArrayList();
            arrayListBagPositionTagNumbers = new ArrayList();

            foreach (Button b in arrayListBagPositionButtons)
            {
                arrayListBagPositionTagNumbers.Add(string.Empty);
                b.Text = string.Empty;
            }

            if(vir_BagPosition_Sp == null)
                vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Vir_BagPosition> bpList = vir_BagPosition_Sp.SelectAll();
            if(bpList.Count <0)
            {
                MessageBox.Show("There is no Bag Position available, can not continue.");
                this.Close();
                return;
            }

            int index = 0;
            foreach (Vir_BagPosition bp in bpList)
            {
                arrayListBagPositionObjects.Add(bp);

                //if (bp.ProductID < 1)
                //{
                //    ((Button)arrayListBagPositionButtons[index]).Text = bp.BagPositionName;
                //    index++;
                //    continue;
                //}

                tagNumber = string.Empty;
                if (bp.CurrentStageID > 1)
                {
                    //open
                    if (sol_Stage_Sp == null)
                        sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
                    sol_Stage = sol_Stage_Sp.Select(bp.CurrentStageID);
                    if (sol_Stage == null)
                    {
                        bp.CurrentStageID = 0;
                        bp.CurrentQuantity = 0;
                        ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity = 0;
                        ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID = 0;
                        vir_BagPosition_Sp.Update((Vir_BagPosition)arrayListBagPositionObjects[index]);
                        //sol_Stage.TagNumber = string.Empty;
                        //sol_Stage_Sp.Update(sol_Stage);
                    }
                    else
                    {
                        tagNumber = sol_Stage.TagNumber;
                        arrayListBagPositionTagNumbers[index] = tagNumber;
                        ((Button)arrayListBagPositionButtons[index]).BackColor = ColorTranslator.FromHtml("#01b866");  //green
                    }
                }

                if (bp.ProductID < 1)
                    ((Button)arrayListBagPositionButtons[index]).Text = bp.BagPositionName;
                else
                   FormatBagPositionText((Button)arrayListBagPositionButtons[index], bp, tagNumber);

                index++;
            }


        }

        void FormatBagPositionText(Button button, Vir_BagPosition bp, string tagNumber)
        {
            int l = 23;
            if (l > bp.BagPositionName.Length) l = bp.BagPositionName.Length;

            button.Text = string.Format(
                "{0}\r" +
                "{1:#,0}\r" +
                "Target: {2:#,0}\r" +
                "TAG {3}\r"
                , bp.BagPositionName.Substring(0, l)
                , bp.CurrentQuantity
                , bp.TargetQuantity
                , tagNumber
                );
        }

        private void buttonBagPosition_02_Click(object sender, EventArgs e)
        {
            buttonBagPositionClicked = (Button)sender;

            if(buttonBagPositionClicked.BackColor == ColorTranslator.FromHtml("#01b866"))  //green
            {
                //
                toolStripMenuItemOpen.Visible = false;
                toolStripMenuItemClose.Visible = true;
            }
            else
            {
                //
                //toolStripMenuItemOpen.Visible = true;
                //toolStripMenuItemClose.Visible = false;
                OpenCloseBagPosition();
                return;
            }


            //contextMenuStrip1.Show(button, new Point(0, button.Height));
            Point screenPoint = buttonBagPositionClicked.PointToScreen(new Point(buttonBagPositionClicked.Left, buttonBagPositionClicked.Bottom));
            if (screenPoint.Y + contextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                contextMenuStrip1.Show(buttonBagPositionClicked, new Point(0, -contextMenuStrip1.Size.Height));
            }
            else
            {
                contextMenuStrip1.Show(buttonBagPositionClicked, new Point(0, buttonBagPositionClicked.Height));
            }
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            OpenCloseBagPosition();

        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            OpenCloseBagPosition();

        }

        private void toolStripMenuItemModify_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();

            ShippingMultiProductStagedContainersModify f1 = new ShippingMultiProductStagedContainersModify();
            f1.buttonText = buttonBagPositionClicked.Text;
            f1.buttonBackColor = buttonBagPositionClicked.BackColor;

            //arrayListBagPositionObjects

            int index = 0;
            int.TryParse(buttonBagPositionClicked.Name.Right(2), out index);
            index--;


            Vir_BagPosition bp = (Vir_BagPosition)arrayListBagPositionObjects[index];
            if (bp == null)
            {
                MessageBox.Show("Bag position does not exists. Please review configuration.");
                timer1_Tick(timer1, new EventArgs());
                return;
            }

            f1.vir_BagPosition = bp;

            f1.tagNumber = (string)arrayListBagPositionTagNumbers[index];

            f1.ShowDialog();
            buttonBagPositionClicked.Text = f1.buttonText;

            f1.Dispose();
            f1 = null;

            timer1_Tick(timer1, new EventArgs());

        }

        private void OpenCloseBagPosition()
        {

            if (buttonBagPositionClicked == null)
                return;

            int index = 0;
            int.TryParse(buttonBagPositionClicked.Name.Right(2), out index);
            index--;

            if (arrayListBagPositionObjects.Count < 1
                || index >= arrayListBagPositionObjects.Count
                )
            {
                MessageBox.Show("There is no Bag Position available to open.");
                //this.Close();
                return;
            }

            Vir_BagPosition bp = (Vir_BagPosition)arrayListBagPositionObjects[index];
            if (bp == null)
                return;

            this.timer1.Stop();

            if (vir_BagPosition_Sp == null)
                vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);

            int stageId = ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID;

            if (bp.CurrentQuantity <1 && bp.CurrentStageID <1)
            {
                //is closed
                int containerID = 0;
                int dozen = 0;
                decimal price = 0;
                int agencyID = 0;
                bool autoGenerateTagNumber = false;
                if(!ReadProductAgency(bp.ProductID, ref containerID, ref dozen, ref price, ref agencyID, ref autoGenerateTagNumber))
                {
                    MessageBox.Show("Product linked to this bag position does not exists, please review!");
                    timer1_Tick(timer1, new EventArgs());
                    return;
                }

                if (!AddStagedRow(bp.ProductID, containerID, dozen, price, agencyID, autoGenerateTagNumber))
                {
                    timer1_Tick(timer1, new EventArgs());
                    return;
                }

                ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity = 0;
                ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID = sol_Stage.StageID;
                arrayListBagPositionTagNumbers[index] = tagNumber;

                vir_BagPosition_Sp.Update((Vir_BagPosition)arrayListBagPositionObjects[index]);
                FormatBagPositionText(buttonBagPositionClicked, (Vir_BagPosition)arrayListBagPositionObjects[index], tagNumber);
                buttonBagPositionClicked.BackColor = ColorTranslator.FromHtml("#01b866");  //green

                //update bag DateClosed
                SolFunctions.SetDateClosedInStage(stageId, "1753-01-01 12:00:00.000");

            }
            else
            {
                //is open
                if(bp.CurrentQuantity < bp.TargetQuantity)
                {
                    if (MessageBox.Show("Current Quantity is below Target Quantity.  Are you sure you want to close this bag?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                    {
                        //
                        timer1_Tick(timer1, new EventArgs());
                        return;
                    }
                }

                //set final quantity in stage
                SolFunctions.SetFinalQuantityInStage(bp.CurrentStageID, bp.CurrentQuantity);

                int quantity = ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity;
                //int stageId = ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID;

                //print label
                //I removed this: A300,110,1,4,2,1,N,"Doz:  {dozen}"
                bool printLabel = true;

                do
                {
                    if (sol_Agency_Sp == null)
                        sol_Agency_Sp = new Sol_Agencie_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    if (sol_Product_Sp == null)
                        sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    if (sol_Stage_Sp == null)
                        sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    if (sol_Orders_Sp == null)
                        sol_Orders_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    if (sol_OrdersDetail_Sp == null)
                        sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    if (!PrintLabel(
                                sol_Agency_Sp
                                , sol_Product_Sp
                                , sol_Stage_Sp
                                , sol_Orders_Sp
                                , sol_OrdersDetail_Sp
                                , stageId
                                , DateTime.Now
                                ))
                    {

                        if (MessageBox.Show("There was a problem printing the bag tag, do you want to try again?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                        {
                            if (MessageBox.Show("Do you want to close the bag anyway?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                            {
                                return; 
                            }
                            printLabel = false;
                        }
                    }
                    else
                        printLabel = false;

                } while (printLabel);

                //                    

                //MessageBox.Show("Closing bag");

                //update bagposition
                ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity = 0;
                ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID = 0;
                arrayListBagPositionTagNumbers[index] = string.Empty;

                //quitar (uncomment)
                vir_BagPosition_Sp.Update((Vir_BagPosition)arrayListBagPositionObjects[index]);
                FormatBagPositionText(buttonBagPositionClicked, (Vir_BagPosition)arrayListBagPositionObjects[index], string.Empty);
                buttonBagPositionClicked.BackColor = ColorTranslator.FromHtml("#e84141");  //red

                //update bag DateClosed
                SolFunctions.SetDateClosedInStage(stageId, Main.rc.FechaActual.ToString());

            }

            timer1_Tick(timer1, new EventArgs());
        }

        private bool AddStagedRow(int productID, int containerID, int dozen, decimal price, int agencyID, bool autoGenerateTagNumber)
        {
            //if(osi == null)
            //    osi = new SirLib.ObtenerSiguienteId(Properties.Settings.Default.WsirDbConnectionString);

            if(sol_Stage_Sp == null)
                sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_Stage = new Sol_Stage();
            sol_Stage.ProductID = productID;
            sol_Stage.ContainerID = containerID;
            sol_Stage.Dozen = dozen;
            sol_Stage.Price = price;

            if (autoGenerateTagNumber)
            {
                if(!AutoGenerateTagNumber(agencyID))
                {
                    tagNumber = string.Empty;
                    return false;
                }
                sol_Stage.TagNumber = tagNumber;
            }
            else
            {
                ShippingMultiProductStagedContainersTagNumber f1 = new ShippingMultiProductStagedContainersTagNumber();
                f1.ShowDialog();
                bool cancelFlag = f1.cancelFlag;
                tagNumber = f1.tagNumber;
                f1.Dispose();
                f1 = null;
                if (cancelFlag)
                {
                    tagNumber = string.Empty;
                    return false;
                }
                sol_Stage.TagNumber = tagNumber;
            }

            if (membershipUser == null)
                membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                tagNumber = string.Empty;
                MessageBox.Show("User does not exits, cannot open bag position!");
                return false;
            }

            sol_Stage.UserID = (Guid)membershipUser.ProviderUserKey;
            sol_Stage.UserName = Properties.Settings.Default.UsuarioNombre;
            sol_Stage.Date = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
            sol_Stage.Status = "I"; //InProcess

            try
            {
                sol_Stage_Sp.Insert(sol_Stage);
            }
            catch //(Exception ex)
            {
                //try once more
                if (autoGenerateTagNumber)
                {
                    if (!AutoGenerateTagNumber(agencyID))
                    {
                        tagNumber = string.Empty;
                        return false;
                    }
                    sol_Stage.TagNumber = tagNumber;
                }
                try
                {
                    sol_Stage_Sp.Insert(sol_Stage);
                }
                catch (Exception e)
                {
                    tagNumber = string.Empty;
                    MessageBox.Show("Error trying to add a new Staged Container, try again please", e.Message);
                    sol_Stage = null;
                    return false;
                }
            }


            return true;
        }

        private bool AutoGenerateTagNumber(int agencyID)
        {
            if (agencyID < 1)
                return false;

            if (sol_AutoNumber_Sp == null)
                sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

            int newTagNumber = sol_AutoNumber_Sp.UpdateTagNumber(agencyID, 1);
            if (newTagNumber < 1)
            {
                MessageBox.Show("Can not generate next tag number, it should be a valid integer.");
                return false;
            }
            tagNumber = newTagNumber.ToString();
            return true;
        }

        private MultiProductOrderDetail ReadMultiProductOrderDetail(int detailID)
        {
            MultiProductOrderDetail od = new MultiProductOrderDetail();
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sol_OrdersDetail_SelectByDetailID_ForConveyorID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@DetailID", detailID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int index = 0;
                                od.DetailID = (int)reader[index++];
                                od.ProductID = (int)reader[index++];
                                od.ProductDescription = (string)reader[index++];
                                od.Quantity = (int)reader[index++];
                                od.Price = (decimal)reader[index++];
                                od.Amount = (decimal)reader[index++];
                                od.MasterProductID = (int)reader[index++];
                                od.AgencyID = (int)reader[index++];
                                od.AutoGenerateTagNumber = (bool)reader[index++];
                            }
                        }
                    }
                }
            }
            catch { }
            return od;

        }

        private bool ReadProductAgency(
            int productID
            , ref int containerID
            , ref int dozen
            , ref decimal price
            , ref int agencyID
            , ref bool autoGenerateTagNumber)
        {

            containerID = 0;
            dozen = 0;
            price = 0;
            agencyID = 0;
            autoGenerateTagNumber = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    string sql = @"
                        SELECT 
                        dbo.[sol_Products].ContainerID
                        , dbo.[sol_StandardDozen].Quantity as Dozen
                        , dbo.[sol_Products].Price
                        , dbo.[sol_Products].AgencyID
                        , ISNULL(dbo.[sol_Agencies].AutoGenerateTagNumber, 0) as AutoGenerateTagNumber
                        FROM dbo.[sol_Products]
                        INNER JOIN dbo.[sol_Agencies] ON dbo.[sol_Agencies].AgencyID =  dbo.[sol_Products].AgencyID
						LEFT JOIN dbo.[sol_StandardDozen] ON dbo.[sol_StandardDozen].StandardDozenID =  dbo.[sol_Products].StandardDozenID
                        WHERE [ProductID] = @ProductID
                        ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@ProductID", productID));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int index = 0;
                                try { containerID = (int)reader[index++]; } catch { containerID = 0; }
                                try { dozen = (int)reader[index++]; } catch { dozen = 0; }
                                price = (decimal)reader[index++];
                                agencyID = (int)reader[index++];
                                autoGenerateTagNumber = (bool)reader[index++];
                            }
                            else
                                return false;
                        }
                    }
                }
            }
            catch //(Exception ex)
            {
                return false;
            }
            return true;

        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (currentOrderDetailID < 1)
            {
                MessageBox.Show("Please select a product from one of the conveyors!");
                timer1_Tick(timer1, new EventArgs());
                return;
            }

            int bagPositionID = ReadBagPosition();
            if (bagPositionID < 1)
            {
                MessageBox.Show("Item not linked to a Bag position. Please review configuration.");
                timer1_Tick(timer1, new EventArgs());
                return;
            }

            //review if more than 8 bags and only 8 buttons
            int index = 0; // agPositionID-1;
            //int bpIndex = 0;
            foreach (Vir_BagPosition vbp in arrayListBagPositionObjects)
            {
                if (vbp.BagPositionID == bagPositionID)
                    break;
                index++;
            }

            if (index > arrayListBagPositionObjects.Count - 1)
            {
                MessageBox.Show("Bag position does not exists. Please review configuration.");
                timer1_Tick(timer1, new EventArgs());
                return;
            }

            //review if more than 8 bags and only 8 buttons
            Button b = (Button)arrayListBagPositionButtons[index];

            if (vir_BagPosition_Sp == null)
                vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //Vir_BagPosition bp = vir_BagPosition_Sp.Select(index);


            Vir_BagPosition bp = (Vir_BagPosition)arrayListBagPositionObjects[index];
            if (bp == null)
            {
                MessageBox.Show("Bag position does not exists. Please review configuration.");
                timer1_Tick(timer1, new EventArgs());
                return;
            }

            if(bp.CurrentStageID <1)
            {
                MessageBox.Show("This Bag position is close. Open it first please.");

                tslCntr = b;
                timerBlink.Enabled = true;

                timer1_Tick(timer1, new EventArgs());
                return;
            }

            if (sol_OrdersDetail_Sp == null)
                sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //A = normal D = void  O = On account P = paid or processed
            Sol_OrdersDetail od = sol_OrdersDetail_Sp.Select(currentOrderDetailID);
            if (od == null
                || od.StageID > 0
                || od.Status != "A")
            {
                MessageBox.Show("Sorry, that item no longer exists.  Please select another item.");
                timer1_Tick(timer1, new EventArgs());
                return;
            }

            if (bp.CurrentQuantity > bp.TargetQuantity)
            {
                if (MessageBox.Show("Bag position if full.  Do you want to continue?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                {
                    timer1_Tick(timer1, new EventArgs());
                    return;
                }

            }
            else
            {
                if ((bp.CurrentQuantity + od.Quantity) > bp.TargetQuantity)
                {
                    if (MessageBox.Show("Current Quantity will be above Target Quantity.  Do you want to continue?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                    {
                        timer1_Tick(timer1, new EventArgs());
                        return;
                    }
                }
            }

            //recheck again
            od = sol_OrdersDetail_Sp.Select(currentOrderDetailID);
            if (od == null
                || od.StageID > 0
                || od.Status != "A")
            {
                MessageBox.Show("Sorry, that item no longer exists.  Please select another item.");
                timer1_Tick(timer1, new EventArgs());
                return;
            }


            bp.CurrentQuantity += od.Quantity;
            vir_BagPosition_Sp.Update(bp);

            od.StageID = bp.CurrentStageID;
            //sol_OrdersDetail.Status = "";

            sol_OrdersDetail_Sp.Update(od);

            //update quantity in sol_stage
            //we use a trigger [Sol_OrdersDetail_UpdateStageQuantity]

            FillDataListView(currentListView, currentConveyorID);

            //if (sol_Stage_Sp == null)
            //    sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

            FormatBagPositionText(b, bp, (string)arrayListBagPositionTagNumbers[index]);

            timer1_Tick(timer1, new EventArgs());
        }

        private int ReadBagPosition()
        {
            int bagPositionID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    string sql = @"
                        SELECT 
                        dbo.Vir_BagPosition.BagPositionID
                        , dbo.Vir_BagPosition.CurrentStageID
                        , dbo.Vir_BagPosition.CurrentQuantity
                        , dbo.Vir_BagPosition.TargetQuantity
                        FROM dbo.Vir_BagPosition INNER JOIN
                            dbo.Vir_ConveyorLink ON dbo.Vir_BagPosition.BagPositionID = dbo.Vir_ConveyorLink.BagPositionID
                        WHERE(dbo.Vir_BagPosition.ProductID = @MasterProductID) AND(dbo.Vir_ConveyorLink.ConveyorID = @ConveyorID)
                        ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@ConveyorID", currentConveyorID));
                        command.Parameters.Add(new SqlParameter("@MasterProductID", currentMasterProductID));

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int index = 0;
                                bagPositionID = (int)reader[index++];
                            }
                        }
                    }
                }
            }
            catch { }
            return bagPositionID;
        }

        //blinking mode
        private void timerBlink_Tick(object sender, System.EventArgs e)
        {
            intCntr = intCntr + 1;
            if (intCntr % 2 == 0)
            {
                tslCntr.Visible = false;
            }
            else
            {
                tslCntr.Visible = true;
                if (intCntr > 5)
                {
                    intCntr = 0;
                    timerBlink.Enabled = false;
                }
            }

        }

        //
        public static bool PrintLabel(
            Sol_Agencie_Sp sol_Agency_Sp
            , Sol_Product_Sp sol_Product_Sp
            , Sol_Stage_Sp sol_Stage_Sp
            , Sol_Order_Sp sol_Orders_Sp
            , Sol_OrdersDetail_Sp sol_OrdersDetail_Sp
            , int stageId
            , DateTime date
            )
        {
            //commands
            /*
             * standard staging
             * 
             * {barCode}                    ss - ms
             * {vendorId}                   ss - ms
             * {productCode}                ss
             * {quantity}                   ss
             * {tag}                        ss - ms
             * {depotName}                  ss
             * {description} of the product ss
             * {dozen}                      ss
             * {date}                       ss - ms
             * {stageId}                    ss - ms
             * 
             * multi-product or instant staging
             * 
             * {time}                       ms
             * {masterProductCode}          ms
             * {weight}                     ms
             * {volume}                     ms
             * {units}                      ms
             * {productDescription[n]}      ms
             * {productQuantity[n]}         ms
             *     n = 0 to 4 (up to five products)
             * 
            */

            string barCode = String.Empty;
            string vendorId = String.Empty;
            string productCode = String.Empty;
            //string tag = String.Empty;
            string dateBagCreated = "yyyymmdd";
            


            int intValue = 0;

            //sending raw directly to lp2844
            UpcLabel label = new UpcLabel("");
            string labelCommands = Properties.Settings.Default.SettingsWsLabelCommands;
            if (string.IsNullOrEmpty(labelCommands))
                return false;

            Sol_Stage sol_Stage = sol_Stage_Sp.Select(stageId);
            if (sol_Stage == null)
                return false;

            string tagNumber = sol_Stage.TagNumber;

            //search for products

            Sol_Product sol_Product = null;
            Sol_Product sol_MasterProduct = null;

            int index = 0;
//            List<Sol_OrdersDetail> odList = sol_OrdersDetail_Sp._SelectAllByStageID(stageId);


            List<MultiProductOrderDetail> odList = ReadMultiProductsStaging(stageId);

            int units = 0;
            decimal weight = 0, volume = 0;

            Sol_Agencie sol_Agency = null;

            Sol_Order sol_Order = null;

            foreach (MultiProductOrderDetail od in odList)
            {
                sol_Product = sol_Product_Sp.Select(od.ProductID);
                if (sol_Product == null)
                {
                    labelCommands = labelCommands.Replace("{description[" + index.ToString() + "]}", " ");
                    labelCommands = labelCommands.Replace("{quantity[" + index.ToString() + "]}", "");
                }
                else
                {

                    labelCommands = labelCommands.Replace("{description[" + index.ToString() + "]}", sol_Product.ProDescription.Trim());
                    labelCommands = labelCommands.Replace("{quantity[" + index.ToString() + "]}", od.Quantity.ToString());

                    units += od.Quantity;
                    weight += od.Weight;
                    volume += od.Volume;

                    if (sol_MasterProduct == null)
                    {
                        sol_MasterProduct = sol_Product_Sp.Select(od.MasterProductID);
                        if (sol_MasterProduct != null)
                        {

                            sol_Agency = sol_Agency_Sp.Select(sol_MasterProduct.AgencyID);
                            if (sol_Agency != null)
                            {
                                intValue = 0;
                                Int32.TryParse(sol_Agency.VendorID, out intValue);
                                vendorId = intValue.ToString("000000");
                            }

                            productCode = sol_MasterProduct.ProductCode;
                        }
                    }

                    if(sol_Order == null)
                    {
                        sol_Order = sol_Orders_Sp.Select(od.OrderID, od.OrderType);
                        if (sol_Order != null)
                            dateBagCreated = string.Format("{0}{1,2:0#}{2,2:0#}", sol_Order.Date.Year, sol_Order.Date.Month, sol_Order.Date.Day);

                    }

                }

                index++;
                if (index > 4) break;
            }

            //print nothing when no product in the array
            if(index < 4)
            {
                for(int i = index; i < 5; i++)
                {
                    labelCommands = labelCommands.Replace("{description[" + i.ToString() + "]}", "");
                    labelCommands = labelCommands.Replace("{quantity[" + i.ToString() + "]}", "");
                }
            }

            if(sol_MasterProduct != null)
                labelCommands = labelCommands.Replace("{masterProductCode}", sol_MasterProduct.ProductCode.Trim());


            labelCommands = labelCommands.Replace("{weight}", weight.ToString());
            labelCommands = labelCommands.Replace("{volume}", volume.ToString());
            labelCommands = labelCommands.Replace("{units}", units.ToString());

            intValue = 0;
            Int32.TryParse(tagNumber, out intValue);
            tagNumber = intValue.ToString("000");

            
            barCode = vendorId + "100" + dateBagCreated + productCode + tagNumber;
            labelCommands = labelCommands.Replace("{barCode}", barCode);

            labelCommands = labelCommands.Replace("{tag}", tagNumber);

            //labelCommands = labelCommands.Replace("{depotName}", Main.Sol_ControlInfo.BusinessName.Trim());


            labelCommands = labelCommands.Replace("{date}", date.ToString("dd-MMM-yyyy"));
            labelCommands = labelCommands.Replace("{time}", date.ToLongTimeString());
            labelCommands = labelCommands.Replace("{stageId}", sol_Stage.StageID.ToString());

            try
            {
                //quitar (uncomment)
                label.Print(Properties.Settings.Default.SettingsWsLabelPrinter, labelCommands);

                //quitar (comment)
                //MessageBox.Show(labelCommands);

            }
            catch
            {
                MessageBox.Show("Label printer not found!");
                return false;
            }

            return true;
        }

        public static List<MultiProductOrderDetail> ReadMultiProductsStaging(int stageId)
        {
            //string[] str = new string[4];

            List<MultiProductOrderDetail> odList = new List<MultiProductOrderDetail>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sol_OrdersDetail_SelectAllByStageID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@StageID", stageId));
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MultiProductOrderDetail od = new MultiProductOrderDetail();
                            od.DetailID = (int)reader["DetailID"];
                            od.OrderID = (int)reader["OrderID"];
                            od.OrderType = (string)reader["OrderType"];
                            od.ProductID = (int)reader["ProductID"];
                            od.ProductDescription = (string)reader["ProDescription"];
                            od.Weight = (decimal)reader["Weight"];
                            od.Volume = (decimal)reader["Volume"];
                            od.Quantity = (int)reader["Quantity"];
                            od.MasterProductID = (int)reader["MasterProductID"];
                            odList.Add(od);
                        }
                    }
                }
            }

            return odList;
        }

    }
}
