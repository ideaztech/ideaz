
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
    public partial class ShippingAdjustments : Form
    {
        private ListViewItem lastItemChecked;

        enum AdjustmentViewTypes { Overview, Details };
        enum StageTypes { Original, Adjustment };
        enum AdjustmentActionTypes { Remove, Return, Add, Adjust, Change, Delete };

        private static StageTypes detailsButtonView;

        private static Sol_Shipment sol_ShipmentAdjustment;
        private static Sol_Stage sol_StageAdjustment;

        //Sol_WS_Carrier sol_WS_Carrier;
        //Sol_WS_Carrier_Sp sol_WS_Carrier_Sp;

        //Sol_Agencie sol_Agencie;
        //Sol_Agencie_Sp sol_Agencie_Sp;

        //bool initialFlag = true;
        //Sol_SupplyInventory Sol_SupplyInventory;
        //Sol_SupplyInventory_Sp sol_SupplyInventory_Sp;

        public static string RBillNumber = "";
        public static bool ShipmentButtonView = false;

        public int ShippingForm = 0;    //1 - Home, 2 - StagedContainers, 3 - Shipments 4 - lookup

        private static Sol_Product sol_Product;
        private static Sol_Product_Sp sol_Product_Sp;

        //private static Sol_Container sol_Container;
        //private static Sol_Container_Sp sol_Container_Sp;

        private static Sol_Shipment sol_Shipment;
        private static Sol_Shipment_Sp sol_Shipment_Sp;
        private static List<Sol_Shipment> sol_ShipmentList;

        private static Sol_Stage sol_Stage;
        private static Sol_Stage_Sp sol_Stage_Sp;
        private static List<Sol_Stage> sol_StageList;

        public ShippingAdjustments(string Texto, string User, string Server, string Today)
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

        private void ShippingAdjustments_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void ShippingAdjustments_Load(object sender, EventArgs e)
        {

            //classes of tables
            sol_Shipment = new Sol_Shipment();
            sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_ShipmentList = new List<Sol_Shipment>();

            sol_Stage = new Sol_Stage();
            sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_StageList = new List<Sol_Stage>();

            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            toolStrip1.Renderer = new App_Code.NewToolStripRenderer();

            //clock
            object obj1 = toolStripStatusLabelToday;
            object obj2 = toolStripStatusLabelTimer;
            Main.rc.CambiarControlFecha(ref obj1);
            Main.rc.CambiarControlHora(ref obj2);

            //disable form resizing
           // this.FormBorderStyle = FormBorderStyle.FixedSingle;


            //listview with headers
            listViewContainersOnShipment.View = View.Details;
            //listViewContainersOnShipment.Columns.Add("Tag #", 200, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Product", 190, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Dozen", 80, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Container", 170, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("StageID", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Tag #", 200, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Product", 190, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Quantity", 80, HorizontalAlignment.Right);
            listViewContainersOnShipment.Columns.Add("Container", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("StageID", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Dozen", 80, HorizontalAlignment.Right);

            //listViewContainersOnShipment.Columns["StageID"]

            listViewContainersOnShipment.FullRowSelect = true;
            listViewContainersOnShipment.CheckBoxes = true;
            listViewContainersOnShipment.GridLines = true;
            //listViewContainersOnShipment.Activation = ItemActivation.OneClick;
            listViewContainersOnShipment.MultiSelect = true;


            sol_Shipment_SelectAllByStatusTableAdapter.Fill(this.dataSetShipmentByStatusLookup.sol_Shipment_SelectAllByStatus, "S", true);
            //sol_Orders_SelectAllLookupTableAdapter.Fill(this.dataSetOrdersLookup.sol_Orders_SelectAllLookup, userName, strOrderType, "A", "");   //r = returns,  = normal unpaid

            this.sol_ProductsTableAdapter.Fill(this.dataSetProductsLookup.sol_Products, 0); //0 = return products

            ChangeView(AdjustmentViewTypes.Overview);
            //read shipments ready to be shippped
            ReadCurrentShipments();


            if (ShippingLookup.ShipmentButtonAdjustment)
            {
                comboBoxRbill.SelectedIndex = comboBoxRbill.FindStringExact(ShippingLookup.RBillNumber);
                buttonCreate.PerformClick();

                ////textBoxRBillNumber.Text = ShippingHome.RBillNumber;
                ////ShippingHome.RBillNumber = "";
                ////ShippingHome.ShipmentButtonView = false;

                ////buttonSearch.Enabled = true;
                ////buttonSearch.PerformClick();


                ////if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
                ////{
                ////    MessageBox.Show("Please select a Shipment to view", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ////    return;
                ////}

                //RBillNumber = ShippingLookup.RBillNumber;   // dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
                //ChangeView(AdjustmentViewTypes.Details);
                //textBoxRBill.Text = RBillNumber;    // RemoveShipmentPostFix(RBillNumber);

                //sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(RemoveShipmentPostFix(RBillNumber));
                //sol_Stage_SelectAllByAgencyTableAdapter.Fill(
                //    this.dataSetStageLookup.sol_Stage_SelectAllByAgency,
                //    "I", sol_Shipment.AgencyID);

                //buttonOriginalRbill.PerformClick();
                //buttonOriginalRbill.Select();

            }


            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }
            //initialFlag = false;


            CheckUserPermissions();

            if (Properties.Settings.Default.StagingType == 0)   //!Properties.Settings.Default.MultiProductStagingEnabled)
            {
                toolStripSeparatorMultiProductStaging.Visible = false;
                toolStripButtonMultiProductStaging.Visible = false;
            }

        }

        private void CheckUserPermissions()
        {
            toolStripButtonLookup.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", false);

            buttonView.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", false);

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

        private void toolStripButtonLogOff_Click(object sender, EventArgs e)
        {
            SolFunctions.LogOff(ref toolStripStatusLabelUserName);
            SolFunctions.CheckComputerRole(ref toolStripButtonExit);

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolShipping", true))
            {
                toolStripButtonExit.PerformClick();
                return;
            }

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAdjustShipment", true))
            {
                toolStripButtonExit.PerformClick();
                return;
            }

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


        #region Adjustment Overview

        //read shipments with adjustments
        private void ReadCurrentShipments()
        {

            int selectedRow = -1;
            try
            {
                selectedRow = dataGridViewCurrentShipment.SelectedRows[0].Index;
            }
            catch { }


            this.dataGridViewCurrentShipment.SelectionChanged -= new System.EventHandler(this.dataGridViewCurrentShipment_SelectionChanged);
            dataGridViewCurrentShipment.Rows.Clear();
            this.dataGridViewCurrentShipment.SelectionChanged += new System.EventHandler(this.dataGridViewCurrentShipment_SelectionChanged);

            listViewContainersOnShipment.Items.Clear();

            sol_ShipmentList = sol_Shipment_Sp.SelectAllByStatus("A", true);

            if (sol_ShipmentList == null)
                return;

            foreach (Sol_Shipment ss in sol_ShipmentList)
            {
                dataGridViewCurrentShipment.Rows.Add(ss.RBillNumber, ss.AgencyName, ss.Date.ToShortDateString(), ss.Status, ss.ERBillTransmitted, ss.ShipmentID);

            }
            //select pre-selected row if any
            if (selectedRow > 0)    //-1)
            {
                dataGridViewCurrentShipment.Rows[selectedRow].Selected = true;
            }

            labelCurrentShipmentsCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", dataGridViewCurrentShipment.Rows.Count);

        }


        private void dataGridViewCurrentShipment_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string rBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
                ReadContainersOnShipment(ref listViewContainersOnShipment, rBillNumber, StageTypes.Original);
            }
            catch { }
        }


        private void ReadContainersOnShipment(ref ListView lv1, string rBillNumber, StageTypes stageType)
        {
            lv1.Items.Clear();

            sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(rBillNumber);

            if (sol_Shipment == null
                || sol_Shipment.Status == "V"
                )
                return;

            sol_StageList = sol_Stage_Sp._SelectAllByShipmentID(sol_Shipment.ShipmentID);  //I-InProgress; P-Picked S-Shipped

            if (sol_StageList == null)
                return;

            foreach (Sol_Stage st in sol_StageList)
            {
                if (st.Status != "V") 
                    addItemStagedContainers(ref lv1, st.TagNumber, st.ProductName, st.Dozen, st.ContainerDescription, st.StageID, st.Quantity);
            }

            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);
        }

        private bool addItemStagedContainers(ref ListView lv1, string tagNumber, string product, int dozen, string container, int stageId, int quantity)
        {
            string[] str = new string[6];
            ListViewItem itm = new ListViewItem();
            str[0] = tagNumber;
            str[1] = product;
            str[2] = String.Format("{0,3:##,##0}", quantity);
            str[3] = container;
            str[4] = stageId.ToString();
            str[5] = SolFunctions.Quantity2Dozen(quantity); ;
            itm = new ListViewItem(str);
            lv1.Items.Add(itm);
            //this.arrayListViewCategoryId.Add(categoryId);

            return true;
        }


        //private void buttonViewShipment_Click(object sender, EventArgs e)
        //{
        //    dataGridViewCurrentShipment.Focus();

        //    if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", true))
        //        return;

        //    if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
        //    {
        //        MessageBox.Show("Please select a Shipment to view", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    RBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
        //    string status = dataGridViewCurrentShipment.SelectedRows[0].Cells[3].Value.ToString();

        //    if (status.ToLower() !="i")
        //    {
        //        MessageBox.Show("Only Shipments in progress please", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    ShippingForm = 3;   //Shipments
        //    ShipmentButtonView = true;
        //    Close();

        //}




        private void listViewContainersOnShipment_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SirLib.ListViewItemComparer.ColumnClick((ListView)sender, e);

        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            //buttonCreate.PerformClick();

            if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to view", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
            ChangeView(AdjustmentViewTypes.Details);
            textBoxRBill.Text = RBillNumber;    // RemoveShipmentPostFix(RBillNumber);

            sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(RemoveShipmentPostFix(RBillNumber));
            sol_Stage_SelectAllByAgencyTableAdapter.Fill(
                this.dataSetStageLookup.sol_Stage_SelectAllByAgency,
                "I", sol_Shipment.AgencyID);


            buttonOriginalRbill.PerformClick();
            buttonOriginalRbill.Select();


        }

        private void ChangeView(AdjustmentViewTypes av)
        {
            bool flag = false;
            DockStyle ds = DockStyle.None;

            if (av == AdjustmentViewTypes.Details)
            {
                flag = true;
                ds = DockStyle.Fill;
            }

            panelLeftOverview.Visible = !flag;
            panelLeftDetails.Visible = flag;
            panelLeftDetails.Dock = ds;

            panelRightShipment.Visible = !flag;
            panelRightStage.Dock = ds;

            panelRightStageOverview.Visible = !flag;
            panelRightStageDetails.Visible = flag;

            buttonView.Visible = !flag;
            buttonClose.Visible = flag;
            buttonDelete.Visible = flag;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            ChangeView(AdjustmentViewTypes.Overview);

            ReadCurrentShipments();


        }

        private void radioButtonRemove_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if(rb.Checked)
                ChangeDetailsPanels(rb.Name);

        }

        private void ChangeDetailsPanels(string rbName)
        {
            panelRemove.Enabled = false;
            panelAdd.Enabled = false;
            panelAdjust.Enabled = false;

            //panelChange.Enabled = false;
            //panelDelete.Enabled = false;

            switch (rbName)
            {
                case "radioButtonRemove":
                    panelRemove.Enabled = true;
                    //buttonOriginalRbill.PerformClick();
                    break;
                case "radioButtonAdd":
                    panelAdd.Enabled = true;
                    break;
                case "radioButtonAdjust":
                    panelAdjust.Enabled = true;
                    //buttonOriginalRbill.PerformClick();

                    try
                    {

                        ListView.CheckedListViewItemCollection checkedItems = listViewContainersOnShipment.CheckedItems; //.SelectedItems;
                        if (checkedItems.Count > 0)
                        {
                            //ListViewItem itm;   // = new ListViewItem();
                            foreach (ListViewItem item in checkedItems)
                            {
                                //SwitchContainers(ref listViewContainersOnShipment, ref listViewCurrentStagedContainers, item.SubItems[0].Text, false, null);
                                int stageId = 0;
                                int.TryParse(item.SubItems[4].Text, out stageId);

                                string productName = item.SubItems[1].Text;
                                int index = comboBoxNewProduct.FindStringExact(productName);
                                comboBoxNewProduct.SelectedIndex = index;
                                textBoxNewQuantity.Text = item.SubItems[2].Text;

                                break;
                            }
                        }
                    }
                    catch { }

                    break;
                //case "radioButtonChange":
                //    panelChange.Enabled = true;
                //    //buttonOriginalRbill.PerformClick();
                //    break;
                //case "radioButtonDelete":
                //    ////panelDelete.Enabled = true;
                //    //buttonAdjustments.PerformClick();
                //    break;
                default:
                    break;

            }
        }



        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboBoxRbill.SelectedIndex <0)
            //if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to adjust", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBoxRBill.Text = RemoveShipmentPostFix(comboBoxRbill.Text)+"A";

            //sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(comboBoxRbill.Text);
            //if (sol_Shipment == null)
            //{
            //    MessageBox.Show("There's no shipment to adjust");
            //    return;
            //}

            ChangeView(AdjustmentViewTypes.Details);

            sol_Stage_SelectAllByAgencyTableAdapter.Fill(
                this.dataSetStageLookup.sol_Stage_SelectAllByAgency,
                "I", sol_Shipment.AgencyID);

            buttonOriginalRbill.PerformClick();
            buttonOriginalRbill.Select();

        }

        #endregion

        #region Adjustment Details

        private void buttonOriginalRbill_Click(object sender, EventArgs e)
        {
            detailsButtonView = StageTypes.Original;

            buttonAdjustments.BackColor = SystemColors.Control;
            buttonOriginalRbill.BackColor = SystemColors.ButtonHighlight;

            string rBillNumber = RemoveShipmentPostFix(textBoxRBill.Text);
            ReadContainersOnShipment(ref listViewContainersOnShipment, rBillNumber, StageTypes.Original);

//            //if orginal button is clicked, and Delete radioButton is checked uncheck it
//            if (radioButtonDelete.Checked)
//            {
////                this.radioButtonRemove.CheckedChanged -= new System.EventHandler(this.radioButtonRemove_CheckedChanged);
//                radioButtonRemove.Checked = true;
//                //panelRemove.Enabled = true;
//                //this.radioButtonRemove.CheckedChanged += new System.EventHandler(this.radioButtonRemove_CheckedChanged);

//            }

        }

        private string  RemoveShipmentPostFix(string rBillNumber)
        {
            int l = rBillNumber.Count() - 1;

            if (l > 0)
            {
                if (rBillNumber.Substring(l, 1) == "A")
                    rBillNumber = rBillNumber.Substring(0, l);
            }
            return rBillNumber;

        }

        private void buttonAdjustments_Click(object sender, EventArgs e)
        {
            detailsButtonView = StageTypes.Adjustment;

            buttonAdjustments.BackColor = SystemColors.ButtonHighlight;
            buttonOriginalRbill.BackColor = SystemColors.Control;
            
            ReadContainersOnShipment(ref listViewContainersOnShipment, textBoxRBill.Text, StageTypes.Adjustment);
        }

        private void buttonSaveAdjustment_Click(object sender, EventArgs e)
        {
            //REMOVE
            if (radioButtonRemove.Checked)
            {
                if (detailsButtonView != StageTypes.Original)
                {
                    MessageBox.Show("You have to be in the Original Container list of Shipment");
                    buttonOriginalRbill.PerformClick();
                    return;
                }



                ListView.CheckedListViewItemCollection checkedItems = listViewContainersOnShipment.CheckedItems; //.SelectedItems;
                if (checkedItems.Count < 1)
                {
                    MessageBox.Show("Please select a Container on Shipment");
                    return;
                }

                if (radioButtonRemoveReturn.Checked
                    && String.IsNullOrEmpty(textBoxNewTagNumber.Text)
                    )
                {
                    MessageBox.Show("Please supply a new Tag Number for the inventory return");
                    textBoxNewTagNumber.Focus();
                    return;
                }


                //if needed
                CreateShipmentEntry();

                //ListViewItem itm;   // = new ListViewItem();
                foreach (ListViewItem item in checkedItems)
                {
                    //SwitchContainers(ref listViewContainersOnShipment, ref listViewCurrentStagedContainers, item.SubItems[0].Text, false, null);
                    int stageId =0;
                    int.TryParse(item.SubItems[4].Text, out stageId);

                    if (radioButtonRemoveReturn.Checked)
                        CreateAdjustment(AdjustmentActionTypes.Return, stageId, 0);
                    else if(radioButtonRemoveRemove.Checked)
                       CreateAdjustment(AdjustmentActionTypes.Remove, stageId, 0 );

                }
                
            } // ADD
            else if (radioButtonAdd.Checked)
            {
                //
                if (detailsButtonView != StageTypes.Original)
                {
                    MessageBox.Show("You have to be in the Original Container list of Shipment");
                    buttonOriginalRbill.PerformClick();
                    return;
                }

                if (comboBoxCurrentStaging.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a Stage Container");
                    return;
                }
                
                //comboBoxCurrentStaging.SelectedText = comboBoxCurrentStaging.Text;
                string fullDescription = comboBoxCurrentStaging.SelectedValue.ToString();
                string[] fields = fullDescription.Split('-');
                int stageId = 0;
                int.TryParse(fields[0], out stageId);
                sol_Stage = sol_Stage_Sp.Select(stageId);
                if (sol_Stage == null)
                {
                    MessageBox.Show("Invalid Stage Contanier");
                    return;
                }

                //if needed
                CreateShipmentEntry();

                sol_Stage.ShipmentID = sol_ShipmentAdjustment.ShipmentID;
                sol_Stage.Status = "S"; //from "I" to "S"
                sol_Stage_Sp.Update(sol_Stage);

                //sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(RemoveShipmentPostFix(RBillNumber));
                sol_Stage_SelectAllByAgencyTableAdapter.Fill(
                    this.dataSetStageLookup.sol_Stage_SelectAllByAgency,
                    "I", sol_Shipment.AgencyID);

            } //ADJUST
            else if (radioButtonAdjust.Checked)
            {
                //
                if (detailsButtonView != StageTypes.Original)
                {
                    MessageBox.Show("You have to be in the Original Container list of Shipment");
                    buttonOriginalRbill.PerformClick();
                    return;
                }

                //ListView.SelectedListViewItemCollection selectedItems = listViewContainersOnShipment.SelectedItems;
                ListView.CheckedListViewItemCollection checkedItems = listViewContainersOnShipment.CheckedItems; //.SelectedItems;

                if (checkedItems.Count < 1)
                {
                    MessageBox.Show("Please select a Container on Shipment");
                    return;
                }

                int newQuantityOfDozens = 0;
                int.TryParse(textBoxNewQuantity.Text, out newQuantityOfDozens);
                if(newQuantityOfDozens <1)
                {
                    MessageBox.Show("Please supply a valid quantity of dozens for adjustment");
                    textBoxNewQuantity.Focus();
                    return;
                }


                //if needed
                CreateShipmentEntry();
                
                foreach (ListViewItem item in checkedItems)
                {
                    int productId = 0;
                    if (item.SubItems[1].Text != comboBoxNewProduct.SelectedText)
                    {

                        productId = (int)comboBoxNewProduct.SelectedValue;
                    }


                    int stageId = 0;
                    int.TryParse(item.SubItems[4].Text, out stageId);

                    CreateAdjustment(AdjustmentActionTypes.Adjust, stageId, productId);
                }

            } //CHANGE
            //else if (radioButtonChange.Checked)
            //{
            //    if (detailsButtonView != StageTypes.Original)
            //    {
            //        MessageBox.Show("You have to be in the Original Container list of Shipment");
            //        buttonOriginalRbill.PerformClick();
            //        return;
            //    }

            //    //ListView.SelectedListViewItemCollection selectedItems = listViewContainersOnShipment.SelectedItems;
            //    ListView.CheckedListViewItemCollection checkedItems = listViewContainersOnShipment.CheckedItems; //.SelectedItems;

            //    if (checkedItems.Count < 1)
            //    {
            //        MessageBox.Show("Please select a Container on Shipment");
            //        return;
            //    }

            //    //
            //    if (comboBoxNewProduct.SelectedIndex < 0)
            //    {
            //        MessageBox.Show("Please select a new Product");
            //        return;
            //    }

            //    //if needed
            //    CreateShipmentEntry();

            //    int productId = (int)comboBoxNewProduct.SelectedValue;

            //    //ListViewItem itm;   // = new ListViewItem();
            //    foreach (ListViewItem item in checkedItems)
            //    {
            //        //SwitchContainers(ref listViewContainersOnShipment, ref listViewCurrentStagedContainers, item.SubItems[0].Text, false, null);
            //        int stageId = 0;
            //        int.TryParse(item.SubItems[4].Text, out stageId);
            //        CreateAdjustment(AdjustmentActionTypes.Change, stageId, productId);
            //    }

            //} //DELETE
            //else if (radioButtonDelete.Checked)
            //{
            //    if (detailsButtonView != StageTypes.Adjustment)
            //    {
            //        MessageBox.Show("You have to be in the Adjustments list of Shipment");
            //        buttonAdjustments.PerformClick();
            //        return;
            //    }

            //    //ListView.SelectedListViewItemCollection checkedItems = listViewContainersOnShipment.SelectedItems;
            //    ListView.CheckedListViewItemCollection checkedItems = listViewContainersOnShipment.CheckedItems; //.SelectedItems;
            //    if (checkedItems.Count < 1)
            //    {
            //        MessageBox.Show("Please select a Container on Shipment");
            //        return;
            //    }

            //    //ListViewItem itm;   // = new ListViewItem();
            //    foreach (ListViewItem item in checkedItems)
            //    {
            //        //SwitchContainers(ref listViewContainersOnShipment, ref listViewCurrentStagedContainers, item.SubItems[0].Text, false, null);
            //        int stageId = 0;
            //        int.TryParse(item.SubItems[4].Text, out stageId);
            //        DeleteAdjustment(stageId);
            //    }

            //    //if needed
            //    DeleteShipmentEntry();

            //    buttonAdjustments.PerformClick();

            //}

            buttonAdjustments.PerformClick();
            //unselect all items
            foreach (ListViewItem i in listViewContainersOnShipment.Items)
            {
                i.Selected = false;
            }

        }

        private bool CreateShipmentEntry()
        {
            /*If it is the first item added to this adjustment, 
             * it should create an entry in the sol_Shipment table with status A for Adjustment 
             * and the same RBill Number with an A added to the end.
             */

            //sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(RemoveShipmentPostFix(textBoxRBill.Text)); // + "A");

            sol_ShipmentAdjustment = sol_Shipment_Sp.SelectByRBillNumber(textBoxRBill.Text); // + "A");
            if (sol_ShipmentAdjustment == null)
            {
                DateTime dt = sol_Shipment.Date;
                if (checkBoxDate.Checked)
                    dt = Main.rc.FechaActual;

                sol_ShipmentAdjustment = new Sol_Shipment();

                sol_ShipmentAdjustment.UserID = sol_Shipment.UserID;
                sol_ShipmentAdjustment.UserName = sol_Shipment.UserName;
                sol_ShipmentAdjustment.Date = dt;   // Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;
                sol_ShipmentAdjustment.RBillNumber = sol_Shipment.RBillNumber+"A";
                sol_ShipmentAdjustment.AgencyID = sol_Shipment.AgencyID;
                sol_ShipmentAdjustment.AgencyName = sol_Shipment.AgencyName;

                sol_ShipmentAdjustment.AgencyAddress1 = sol_Shipment.AgencyAddress1;
                sol_ShipmentAdjustment.AgencyAddress2 = sol_Shipment.AgencyAddress2;
                sol_ShipmentAdjustment.AgencyCity = sol_Shipment.AgencyCity;
                sol_ShipmentAdjustment.AgencyProvince = sol_Shipment.AgencyProvince;
                sol_ShipmentAdjustment.AgencyCountry = sol_Shipment.AgencyCountry;
                sol_ShipmentAdjustment.AgencyPostalCode = sol_Shipment.AgencyPostalCode;

                sol_ShipmentAdjustment.Status = "A"; //InProcess

                sol_ShipmentAdjustment.TrailerNumber = sol_Shipment.TrailerNumber;
                sol_ShipmentAdjustment.ProBillNumber = sol_Shipment.ProBillNumber;

                sol_ShipmentAdjustment.ShippedDate = sol_Shipment.ShippedDate;
                sol_Shipment_Sp.Insert(sol_ShipmentAdjustment);

            }

            return true;
        }

        private bool CreateAdjustment(AdjustmentActionTypes adjActionTypes, int stageId, int productId)
        {

            sol_Stage = sol_Stage_Sp.Select(stageId);
            if (sol_Stage == null)
            {
                MessageBox.Show(String.Format("StageID not found ({0}) ", stageId));
                return false;
            }

            DateTime dt = sol_Stage.Date;
            if (checkBoxDate.Checked)
                dt = Main.rc.FechaActual;

            Sol_Stage sol_StageAdjustment = new Sol_Stage();

            sol_StageAdjustment.ShipmentID = sol_ShipmentAdjustment.ShipmentID;
            sol_StageAdjustment.UserID = sol_Stage.UserID;
            sol_StageAdjustment.UserName = sol_Stage.UserName;
            //sol_StageAdjustment.Date = dt;
            sol_StageAdjustment.Date = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;

            sol_StageAdjustment.TagNumber = sol_Stage.TagNumber + "A";
            sol_StageAdjustment.ContainerID = sol_Stage.ContainerID;
            sol_StageAdjustment.ContainerDescription = sol_Stage.ContainerDescription;
            sol_StageAdjustment.ProductID = sol_Stage.ProductID;
            sol_StageAdjustment.ProductName = sol_Stage.ProductName;
            sol_StageAdjustment.Dozen = 0;  //not used anymore sol_Stage.Dozen * -1;
            sol_StageAdjustment.Quantity = sol_Stage.Quantity * -1;
            sol_StageAdjustment.Price = sol_Stage.Price;
            sol_StageAdjustment.Remarks = sol_Stage.Remarks;
            sol_StageAdjustment.Status = sol_Stage.Status;

            //in case there is no default value in the db
            sol_StageAdjustment.DateClosed = DateTime.Parse("1753-01-01 12:00:00.000");

            switch (adjActionTypes)
            {
                case AdjustmentActionTypes.Return:
                    //remove it
                    //sol_StageAdjustment.TagNumber = sol_Stage.TagNumber;
                    sol_StageAdjustment.Dozen = sol_Stage.Dozen * -1;
                    sol_StageAdjustment.Quantity = sol_Stage.Quantity * -1;
                    //sol_StageAdjustment.Status = sol_Stage.Status;
                    sol_Stage_Sp.Insert(sol_StageAdjustment);

                    //add an adjustment to return to inventory
                    sol_StageAdjustment.ShipmentID = 0;
                    sol_StageAdjustment.TagNumber = textBoxNewTagNumber.Text; //sol_Stage.TagNumber
                    sol_StageAdjustment.Dozen = 0;  //not used anymore sol_Stage.Dozen;
                    sol_StageAdjustment.Quantity = sol_Stage.Quantity;
                    sol_StageAdjustment.Status = "I";//sol_Stage.Status;

                    sol_Stage_Sp.Insert(sol_StageAdjustment);

                    ////remove it from shipment
                    //sol_Stage.ShipmentID = 0;
                    //sol_Stage.TagNumber = textBoxNewTagNumber.Text;
                    //sol_Stage.Status = "I";
                    //sol_Stage_Sp.Update(sol_Stage);


                    MessageBox.Show(
                    string.Format(
                        @"Tag Number {0} has been added to inventory. Note: This tag is in inventory and is no longer linked to the previous shipment.  Therefore, the new tag will not be removed if you delete the adjustment."
                        , textBoxNewTagNumber.Text
                        ));

                    return true;
                    //break;

                case AdjustmentActionTypes.Remove:

                    break;
                //case AdjustmentActionTypes.Add:
                //    break;

                case AdjustmentActionTypes.Adjust:
                    //create reverse adjustment to remove original quantity
                    sol_Stage_Sp.Insert(sol_StageAdjustment);

                    //create adjustment with new product
                    if (productId > 0)
                    {
                        if (sol_Product_Sp == null)
                            sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
                        sol_Product = sol_Product_Sp.Select(productId);
                        sol_StageAdjustment.ProductID = productId;
                        sol_StageAdjustment.ProductName = sol_Product.ProName;
                        //sol_StageAdjustment.Dozen = sol_Stage.Dozen;
                        //sol_StageAdjustment.Quantity = sol_Stage.Quantity;
                    }

                    int newQuantity = 0;
                    int.TryParse(textBoxNewQuantity.Text, out newQuantity);

                    sol_StageAdjustment.Quantity = newQuantity;
                    sol_StageAdjustment.Dozen = 0;  //not used anymore newQuantityOfDozens;

                    break;

                //case AdjustmentActionTypes.Change:
                //    //create reverse adjustment to remove original product

                //    sol_Stage_Sp.Insert(sol_StageAdjustment);

                //    //create adjustment with new product
                //    if (sol_Product_Sp == null)
                //        sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
                //    sol_Product = sol_Product_Sp.Select(productId);
                //    sol_StageAdjustment.ProductID = productId;
                //    sol_StageAdjustment.ProductName = sol_Product.ProName;
                //    sol_StageAdjustment.Dozen = sol_Stage.Dozen;
                //    sol_StageAdjustment.Quantity = sol_Stage.Quantity;

                //    break;
                //case AdjustmentActionTypes.Delete:
                //    break;
                default:
                    break;
            }

            sol_Stage_Sp.Insert(sol_StageAdjustment);

            return true;
        }

        private bool DeleteShipmentEntry()
        {
            //sol_ShipmentAdjustment = sol_Shipment_Sp.SelectByRBillNumber(textBoxRBill.Text);

            sol_StageList = sol_Stage_Sp._SelectAllByShipmentID(sol_ShipmentAdjustment.ShipmentID);  //I-InProgress; P-Picked S-Shipped
            if (sol_StageList != null
                && sol_StageList.Count() > 0
                )
                return true;


            sol_Shipment_Sp.Delete(sol_ShipmentAdjustment.ShipmentID);

            //bool flagDelete = true;
            //foreach (Sol_Stage st in sol_StageList)
            //{
            //    if (st.Status != "V")
            //    {
            //        flagDelete = false;
            //        break;
            //    }
            //}
            //if(flagDelete)
            //    sol_Shipment_Sp.UpdateStatus(sol_ShipmentAdjustment.ShipmentID, "D");



            return true;
        }

        private bool DeleteAdjustment(int stageId)
        {
            sol_ShipmentAdjustment = sol_Shipment_Sp.SelectByRBillNumber(textBoxRBill.Text);
            sol_StageAdjustment = sol_Stage_Sp.Select(stageId);
            if (sol_StageAdjustment != null)
            {

                //check if it was a staging container addition (option 2)
                bool flagDelete = false;
                int l = sol_StageAdjustment.TagNumber.Count() - 1;
                if (l > 0)
                {
                    if (sol_StageAdjustment.TagNumber.Substring(l, 1) == "A")
                        flagDelete = true;
                }

                if (flagDelete)
                {
                    //sol_StageAdjustment.Status = "V";
                    //sol_Stage_Sp.Update(sol_StageAdjustment);
                    sol_Stage_Sp._DeleteAllByShipmentIdTagNumber(sol_ShipmentAdjustment.ShipmentID, sol_StageAdjustment.TagNumber);
                }
                else
                {
                    sol_StageAdjustment.ShipmentID = 0;
                    sol_StageAdjustment.Status = "I"; //from "S" to "I"
                    sol_Stage_Sp.Update(sol_StageAdjustment);

                    sol_Stage_SelectAllByAgencyTableAdapter.Fill(
                        this.dataSetStageLookup.sol_Stage_SelectAllByAgency,
                        "I", sol_Shipment.AgencyID);
                }
            }
            else
                return false;

            return true;
        }


        #endregion

        private void listViewContainersOnShipment_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // if we have the lastItem set as checked, and it is different
            // item than the one that fired the event, uncheck it
            if (lastItemChecked != null && lastItemChecked.Checked
                && lastItemChecked != listViewContainersOnShipment.Items[e.Item.Index])
            {
                // uncheck the last item and store the new one
                lastItemChecked.Checked = false;
                this.lastItemChecked.BackColor = SystemColors.Window;
            }

            // store current item
            lastItemChecked = listViewContainersOnShipment.Items[e.Item.Index];


        }

        private void listViewContainersOnShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            ListView.SelectedIndexCollection indexes =
            this.listViewContainersOnShipment.SelectedIndices;

            foreach (int index in indexes)
            {
                this.listViewContainersOnShipment.Items[index].Checked = !this.listViewContainersOnShipment.Items[index].Checked;

                if (this.listViewContainersOnShipment.Items[index].Checked)
                    this.listViewContainersOnShipment.Items[index].BackColor = Color.LightGray;    // SystemColors.ControlLight;
                else
                    this.listViewContainersOnShipment.Items[index].BackColor = SystemColors.Window;

                //break;
            }


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (detailsButtonView != StageTypes.Adjustment)
            {
                MessageBox.Show("You have to be in the Adjustments list of Shipment");
                buttonAdjustments.PerformClick();
                return;
            }

            //ListView.SelectedListViewItemCollection checkedItems = listViewContainersOnShipment.SelectedItems;
            ListView.CheckedListViewItemCollection checkedItems = listViewContainersOnShipment.CheckedItems; //.SelectedItems;
            if (checkedItems.Count < 1)
            {
                MessageBox.Show("Please select a Container on Shipment");
                return;
            }

            //ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in checkedItems)
            {
                //SwitchContainers(ref listViewContainersOnShipment, ref listViewCurrentStagedContainers, item.SubItems[0].Text, false, null);
                int stageId = 0;
                int.TryParse(item.SubItems[4].Text, out stageId);
                DeleteAdjustment(stageId);
            }

            //if needed
            DeleteShipmentEntry();

            buttonAdjustments.PerformClick();

        }

        private void toolStripButtonMultiProductStaging_Click(object sender, EventArgs e)
        {
            ShippingForm = 6;   //MultiProductStagedContainers
            Close();

        }
        private void ButtonEnabledChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = button.Enabled;
        }
    }
}
