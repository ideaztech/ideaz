
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
    public partial class ShippingLookup : Form
    {
        Sol_WS_Carrier sol_WS_Carrier;
        Sol_WS_Carrier_Sp sol_WS_Carrier_Sp;

        Sol_Agencie sol_Agencie;
        Sol_Agencie_Sp sol_Agencie_Sp;

        //bool initialFlag = true;
        //Sol_SupplyInventory Sol_SupplyInventory;
        Sol_SupplyInventory_Sp sol_SupplyInventory_Sp;

        public static string RBillNumber = "";
        public static bool ShipmentButtonView = false;
        public static bool ShipmentButtonAdjustment = false;

        public int ShippingForm = 0;    //1 - Home, 2 - StagedContainers, 3 - Shipments 4 - lookup, 5 - Adjustments

        private Sol_Shipment sol_Shipment;
        private Sol_Shipment_Sp sol_Shipment_Sp;
        private List<Sol_Shipment> sol_ShipmentList;

        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;
        private List<Sol_Stage> sol_StageList;

        public ShippingLookup(string Texto, string User, string Server, string Today)
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

            //enable erbill
            if (Main.Sol_ControlInfo.VendorID > 0)
                if (CheckForUnlikedContainers() < 1)
                    buttoneRBill.Enabled = true;
        }

        private void ShippingLookup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void ShippingLookup_Load(object sender, EventArgs e)
        {
            ShipmentButtonAdjustment = false;

            //classes of tables
            sol_Shipment = new Sol_Shipment();
            sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_ShipmentList = new List<Sol_Shipment>();

            sol_Stage = new Sol_Stage();
            sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_StageList = new List<Sol_Stage>();

            toolStrip1.Renderer = new App_Code.NewToolStripRenderer();

            //años
            int aa = Main.rc.FechaActual.Year;
            byte ah = Main.Sol_ControlInfo.HistoryYears;
            int uah = aa - ah;

            dateTimePickerFrom.MinDate = DateTime.Parse(String.Format("{0}-1-1", uah));
            dateTimePickerFrom.MaxDate = Main.rc.FechaActual;
            dateTimePickerFrom.Value = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.MinDate = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.MaxDate = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.Value = dateTimePickerFrom.MaxDate;

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
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;


            //dataGridViewCurrentShipment 
            //this.dataGridViewCurrentShipment.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //this.dataGridViewCurrentShipment.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //this.dataGridViewCurrentShipment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;


            //this.dataGridViewCurrentShipment.GridColor = Color.Black;
            //this.dataGridViewCurrentShipment.BorderStyle = BorderStyle.Fixed3D;
            //this.dataGridViewCurrentShipment.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //this.dataGridViewCurrentShipment.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //this.dataGridViewCurrentShipment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;


            //listview with headers
            listViewContainersOnShipment.View = View.Details;
            //listViewContainersOnShipment.Columns.Add("Tag #", 190, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Product", 170, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Dozen", 80, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Container", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Tag #", 190, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Product", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Quantity", 80, HorizontalAlignment.Right);
            listViewContainersOnShipment.Columns.Add("Container", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Dozen", 80, HorizontalAlignment.Right);

            //listViewContainersOnShipment.FullRowSelect = true;
            //listViewContainersOnShipment.CheckBoxes = true;
            listViewContainersOnShipment.GridLines = true;
            //listViewContainersOnShipment.Activation = ItemActivation.OneClick;

            //read shipments ready to be shippped
            ReadCurrentShipments();

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

            //originally in Solum
            //if (!(Main.Sol_ControlInfo.State == "AB"
            //    && Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
            //    )
            //{
            //    buttoneRBill.Visible = false;
            //    //buttonPrintRBill
            //    //buttonUnNow

            //    //this.buttoneRBill.Location = new System.Drawing.Point(604, 5);
            //    this.buttonPrintRBill.Location = new System.Drawing.Point(604, 5); //new System.Drawing.Point(721, 5);
            //    this.buttonUnNow.Location = new System.Drawing.Point(721, 5); //new System.Drawing.Point(838, 5);
            //}

        }

        private void CheckUserPermissions()
        {
            toolStripButtonShipmentAdjustments.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAdjustContainer", false);
            //toolStripButtonLookup.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", false);

            buttonMakeAdjustment.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAdjustShipment", false);
            buttonViewShipment.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", false);
            buttonUnNow.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUnshipShipment", false);
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

        //read shipments
        private void ReadCurrentShipments()
        {
            int selectedRow = -1;
            try
            {
                selectedRow = dataGridViewCurrentShipment.SelectedRows[0].Index;
            }
            catch { }

            dataGridViewCurrentShipment.Rows.Clear();

            listViewContainersOnShipment.Items.Clear();

            if (checkBoxDates.Checked)
            {
                string status = "";
                if (radioButtonInProgress.Checked)
                    status = "I";
                else if (radioButtonShipped.Checked)
                    status = "S";

                string dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");
                string dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");

                sol_ShipmentList = sol_Shipment_Sp.SelectAllBetweenDatesByStatus(
                    //dateTimePickerFrom.Value, dateTimePickerTo.Value, 
                    dateFrom, dateTo,
                    status, true);
            }
            else
            {
                if (radioButtonAll.Checked)
                    sol_ShipmentList = sol_Shipment_Sp.SelectAll(true);
                else
                {
                    string status = "";
                    if (radioButtonInProgress.Checked)
                        status = "I";
                    else if (radioButtonShipped.Checked)
                        status = "S";
                    sol_ShipmentList = sol_Shipment_Sp.SelectAllByStatus(status, true);
                }
            }

            if (sol_ShipmentList == null
                || sol_ShipmentList.Count <1)
                return;

            foreach (Sol_Shipment ss in sol_ShipmentList)
            {
                dataGridViewCurrentShipment.Rows.Add(ss.RBillNumber, ss.AgencyName, ss.Date.ToShortDateString(), ss.Status, ss.ERBillTransmitted, ss.ShipmentID);
            }
            //select pre-selected row if any
            if (selectedRow > 0)    //-1)
            {
                try
                {
                    dataGridViewCurrentShipment.Rows[selectedRow].Selected = true;
                }
                catch { }
            }

            labelCurrentShipmentsCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", dataGridViewCurrentShipment.Rows.Count);

        }


        private void dataGridViewCurrentShipment_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ReadContainersOnShipment(ref listViewContainersOnShipment, dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch { }


        }


        private void ReadContainersOnShipment(ref ListView lv1, string rBillNumber)
        {
            sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(rBillNumber);
            lv1.Items.Clear();
            sol_StageList = sol_Stage_Sp._SelectAllByShipmentID(sol_Shipment.ShipmentID);  //I-InProgress; P-Picked S-Shipped
            if (sol_StageList == null)
                return;
            foreach (Sol_Stage st in sol_StageList)
            {
                addItemStagedContainers(ref lv1, st.TagNumber, st.ProductName, st.Dozen, st.ContainerDescription, st.Quantity);
            }
            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);
        }

        private bool addItemStagedContainers(ref ListView lv1, string tagNumber, string product, int dozen, string container, int quantity)
        {
            string[] str = new string[5];
            ListViewItem itm = new ListViewItem();
            str[0] = tagNumber;
            str[1] = product;
            str[2] = String.Format("{0,3:##,##0}", quantity);
            str[3] = container;
            str[4] = SolFunctions.Quantity2Dozen(quantity);
            itm = new ListViewItem(str);
            lv1.Items.Add(itm);
            //this.arrayListViewCategoryId.Add(categoryId);

            return true;
        }

        private void checkBoxDates_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.Enabled = checkBoxDates.Checked;
            dateTimePickerTo.Enabled = checkBoxDates.Checked;

            //if (checkBoxDates.Checked && !initialFlag)
                ReadCurrentShipments();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.MinDate = dateTimePickerFrom.Value;
            //if (!initialFlag)
                ReadCurrentShipments();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;
            //if (!initialFlag)
                ReadCurrentShipments();
        }

        private void buttonViewShipment_Click(object sender, EventArgs e)
        {
            dataGridViewCurrentShipment.Focus();

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", true))
                return;

            if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to view", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
            string status = dataGridViewCurrentShipment.SelectedRows[0].Cells[3].Value.ToString();

            if (status.ToLower() !="i")
            {
                MessageBox.Show("Only Shipments in progress please", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShippingForm = 3;   //Shipments
            ShipmentButtonView = true;
            Close();

        }

        private void buttonPrintRBill_Click(object sender, EventArgs e)
        {
            dataGridViewCurrentShipment.Focus();

            if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to print", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
            string status = dataGridViewCurrentShipment.SelectedRows[0].Cells[3].Value.ToString();
            string strShipmentId = dataGridViewCurrentShipment.SelectedRows[0].Cells[5].Value.ToString();
            string agencyName = dataGridViewCurrentShipment.SelectedRows[0].Cells[1].Value.ToString();
            string rBillDate = dataGridViewCurrentShipment.SelectedRows[0].Cells[2].Value.ToString();

            if (status != "S")
            {
                MessageBox.Show("Only shipped Shipments can be printed.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            this.Cursor = Cursors.WaitCursor;

            if (agencyName.Trim().ToLower() == "abcrc")
            {


                int shipmentId = 0;
                Int32.TryParse(strShipmentId, out shipmentId);

                if (sol_Shipment_Sp == null)
                    sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);
                sol_Shipment = sol_Shipment_Sp.Select(shipmentId);

                if(sol_WS_Carrier_Sp == null)
                    sol_WS_Carrier_Sp = new Sol_WS_Carrier_Sp(Properties.Settings.Default.WsirDbConnectionString);
                sol_WS_Carrier = sol_WS_Carrier_Sp.Select(sol_Shipment.CarrierID);
                if (sol_WS_Carrier == null)
                {
                    sol_WS_Carrier = new Sol_WS_Carrier();
                    sol_WS_Carrier.CarrierID = 0;
                    sol_WS_Carrier.Carrier = String.Empty;
                }

                ShippingShipments.UpdateDataSetBol2(shipmentId, RBillNumber);

                ShippingShipments.PrintBol2(
                    shipmentId, 
                    RBillNumber, 
                    sol_Shipment.ShippedDate.ToString(),
                    sol_WS_Carrier.Carrier,
                    sol_Shipment.TrailerNumber,
                    sol_Shipment.ProBillNumber
                    );
                
            }
            else
                ShippingShipments.PrintRBill(strShipmentId);

            this.Cursor = Cursors.Default;

        }

        private void buttonUnNow_Click(object sender, EventArgs e)
        {
            dataGridViewCurrentShipment.Focus();

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUnshipShipment", true))
                return;

            if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to Unship", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            RBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
            string status = dataGridViewCurrentShipment.SelectedRows[0].Cells[3].Value.ToString();
            string strShipmentId = dataGridViewCurrentShipment.SelectedRows[0].Cells[5].Value.ToString();
            string rBillDate = dataGridViewCurrentShipment.SelectedRows[0].Cells[2].Value.ToString();

            if (status.ToLower() != "s")
            {
                MessageBox.Show("Only Shipments already shipped can be Unshipped", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            //update shipment status
            int shipmentId = 0;
            Int32.TryParse(strShipmentId, out shipmentId);
            if (shipmentId < 1)
                MessageBox.Show("Shipment ID invalid!");
            else
            {

                sol_Shipment = sol_Shipment_Sp.Select(shipmentId);
                //if (sol_Shipment.ERBillTransmitted)
                //{
                //    MessageBox.Show("Shipment already transmitted!");
                //    return;
                //}



                //update stage status
                sol_Stage_Sp.UpdateStatusByShipmentId(shipmentId, "P");//I-InProgress; P-Picked S-Shipped
                sol_Shipment_Sp.UpdateStatus(shipmentId, "I");//I-InProgress; P-Picked S-Shipped 

                //sol_Shipment_Sp.UpdateERBillTransmitted(shipmentId, false);

                //delete supply inventory entries
                //Sol_SupplyInventory sol_SupplyInventory;
                if (sol_SupplyInventory_Sp == null)
                    sol_SupplyInventory_Sp = new Sol_SupplyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);
                sol_SupplyInventory_Sp._DeleteAllByShipmentID(shipmentId);

                //refresh shipments
                ReadCurrentShipments();
                MessageBox.Show("UnShipped!");

                dataGridViewCurrentShipment.Focus();

            }

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

        //private void timer1_Tick(object sender, System.EventArgs e)
        //{
        //    DateTime t = DateTime.Now;
        //    toolStripStatusLabelTimer.Text = t.ToShortTimeString();
        //    toolStripStatusLabelToday.Text = t.ToShortDateString();
        //}


        private void radioButtonInProgress_CheckedChanged(object sender, EventArgs e)
        {
            //if(radioButtonInProgress.Checked && !initialFlag)
                ReadCurrentShipments();
        }

        private void radioButtonShipped_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonShipped.Checked && !initialFlag)
                ReadCurrentShipments();

        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonAll.Checked && !initialFlag)
                ReadCurrentShipments();

        }

        private void buttoneRBill_Click(object sender, EventArgs e)
        {
            dataGridViewCurrentShipment.Focus();

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", true))
                return;

            if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to tramsmit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            RBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
            string status = dataGridViewCurrentShipment.SelectedRows[0].Cells[3].Value.ToString();

            if (status.ToLower() != "s")
            {
                MessageBox.Show("Only Shipments marked as Shipped please", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(sol_Shipment_Sp == null)
                sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(RBillNumber);
            if (sol_Shipment == null)
            {
                MessageBox.Show(String.Format("Invalid RBill Number: {0}, please verify it!", RBillNumber), "", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }

            if (sol_Shipment.ERBillTransmitted)
            {
                //MessageBox.Show("Shipment already transmitted!");
                //return;
                DialogResult result = MessageBox.Show("This R-Bill has already been submitted.  Are you sure you want to send it again?", "", MessageBoxButtons.YesNoCancel);    //.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                    return;
            }

            if (sol_Agencie_Sp == null)
                sol_Agencie_Sp = new Sol_Agencie_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_Agencie = sol_Agencie_Sp.Select(sol_Shipment.AgencyID);
            if (sol_Agencie.Name.ToLower().Trim() != "abcrc")
            {
                MessageBox.Show("Shipment's agency is not ABCRC!");
                return;
            }

            ShippingShipments.eRBill(sol_Shipment, sol_Shipment_Sp);
        }

        public static int CheckForUnlikedContainers()
        {
            //are solum's container linked to abcrc containers?
            int unliknedContainers = 0;
            //try
            //{
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("", connection))
                    {
                        command.CommandText = "SELECT COUNT(*) " +
                                              "FROM [dbo].[sol_Containers] " +
                                              "WHERE [ContainerID] <> 0 "+
                                              "AND [ContainerTypeID] = 1 "+
                                              "AND ([ShippingContainerTypeID] IS NULL  " +
                                              "OR [ShippingContainerTypeID] <0)";
                        //try
                        //{
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                reader.Read();
                                unliknedContainers = reader.GetInt32(0);

                            }
                        //}
                        //catch
                        //{
                        //    //
                        //}
                        connection.Close();
                    }
                }
            //}
            //catch
            //{
            //    //return false;
            //}

            if (unliknedContainers > 0)
                MessageBox.Show("There are unlinked containers for ABCRC Shipping container types!\r\nPlease go to Settings -> ABRCRC - Set Shipping Container Types before being able to transmit eRBills.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return unliknedContainers;
        }


        private void listViewContainersOnShipment_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SirLib.ListViewItemComparer.ColumnClick((ListView)sender, e);

        }

        private void dataGridViewCurrentShipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButtonShipmentAdjustments_Click(object sender, EventArgs e)
        {
            ShippingForm = 5;   //Adjustments
            Close();

        }

        private void buttonMakeAdjustment_Click(object sender, EventArgs e)
        {
            dataGridViewCurrentShipment.Focus();

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", true))
                return;

            if (dataGridViewCurrentShipment.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to adjust", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RBillNumber = dataGridViewCurrentShipment.SelectedRows[0].Cells[0].Value.ToString();
            string status = dataGridViewCurrentShipment.SelectedRows[0].Cells[3].Value.ToString();

            if (status.ToLower() != "s")
            {
                MessageBox.Show("Only Shipments already shipped please", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            ShippingForm = 5;   //Adjustments
            ShipmentButtonAdjustment = true;
            Close();

        }

        private void toolStripButtonLookup_Click(object sender, EventArgs e)
        {

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
