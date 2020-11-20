
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

using System.IO;

using System.Data.SqlClient;
using SirLibCore.Data;
using SirLibCore.Utilities;

using System.Xml;
using System.Xml.Serialization;

namespace Solum
{
    public partial class ShippingShipments : Form
    {
        Sol_AutoNumber_Sp sol_AutoNumber_Sp;
        Sol_Product_Sp sol_Product_Sp;

        public static DataSetBoL dsBol;
        public static DataSetBol2 dsBol2;

        public static DataSetEncorpBol dsEncorpBol;


        Sol_Agencie sol_Agency;
        Sol_Agencie_Sp sol_Agency_Sp;

        MembershipUser membershipUser;

        private NumericTextBox textBoxTagNumber;

        private ShippingShipmentsWarehouseMode fWhm;
        public static bool blnWarewhouseMode = false;
        public static ListView listViewCurrentStagedContainers;
        public static ListView listViewContainersOnShipment;

        private bool flagChange = false;

        int shipmentId = 0;

        private IButtonControl originalAcceptButton;

        public static ArrayList ContainersAdded, ContainersRemoved;

        private string buttonClicked = "";

        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;
        private List<Sol_Stage> sol_StageList;

        private Sol_Shipment sol_Shipment;
        private Sol_Shipment_Sp sol_Shipment_Sp;

        public int ShippingForm = 0;    //1 - Home, 2 - StagedContainers, 3 - Shipments 4 - lookup, 5 - Adjustments

        public ShippingShipments(string Texto, string User, string Server, string Today)
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

            //formerAgencyId = 0;
        }

        private void ShippingShipments_FormClosing(object sender, FormClosingEventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
            {
                e.Cancel = true;
                return;
            }

            //Warn Lost data upon exit
            //int count = listViewContainersOnShipment.Items.Count;
            if (flagChange
                //&& count != originalCount
                )
            {
                if (MessageBox.Show("You have unsaved data, do you want to exit anyway?", "Closing form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }


            }
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);



        }

        private void toolStripButtonVirtualKb_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            if (Properties.Settings.Default.TouchOriented)
            {
                if (Main._pVirtualKb == null)
                    Funciones.TecladoVirtual(ref Main._pVirtualKb, true);
                else
                    Funciones.TecladoVirtual(ref Main._pVirtualKb, false);
            }

        }

        private void ShippingShipments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCarriersLookup.Sol_WS_Carriers' table. You can move, or remove it, as needed.
            this.sol_WS_CarriersTableAdapter.Fill(this.dataSetCarriersLookup.Sol_WS_Carriers);

            // Create an instance of NumericTextBox.
            textBoxTagNumber = new NumericTextBox();
            textBoxTagNumber.Parent = this;

            toolStrip1.Renderer = new App_Code.NewToolStripRenderer();
            // 
            // textBoxTagNumber
            // 
            textBoxTagNumber.Location = new System.Drawing.Point(600, 103); //(95, 73);
            textBoxTagNumber.Name = "textBoxTagNumber";
            textBoxTagNumber.ReadOnly = true;
            textBoxTagNumber.Size = new System.Drawing.Size(226, 26);
            textBoxTagNumber.TabIndex = 16;
            textBoxTagNumber.Leave += new System.EventHandler(this.textBoxTagNumber_Leave);
            textBoxTagNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTagNumber_KeyPress);
            textBoxTagNumber.Enter += new System.EventHandler(this.textBoxTagNumber_Enter);
            this.panelRight.Controls.Add(textBoxTagNumber);


            // TODO: This line of code loads data into the 'dataSetAgenciesLookup.sol_Agencies' table. You can move, or remove it, as needed.
            this.sol_AgenciesTableAdapter.Fill(this.dataSetAgenciesLookup.sol_Agencies);



            ////default agency
            //this.comboBoxAgency.SelectedIndexChanged -= new System.EventHandler(this.comboBoxAgency_SelectedIndexChanged);
            //comboBoxAgency.SelectedValue = -1;
            //this.comboBoxAgency.SelectedIndexChanged += new System.EventHandler(this.comboBoxAgency_SelectedIndexChanged);
            //try
            //{
            //    comboBoxAgency.SelectedValue = Main.Sol_ControlInfo.DefaultAgencyID;
            //}
            //catch
            //{
            //    comboBoxAgency.SelectedValue = 0;
            //}


            ContainersAdded = new ArrayList();
            ContainersRemoved = new ArrayList(); 

            originalAcceptButton = this.AcceptButton;

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
          //  this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //classes of tables
            sol_Stage = new Sol_Stage();
            sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_StageList = new List<Sol_Stage>();

            //sol_Shipment = new Sol_Shipment();
            sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);

            // Create a new ListView control.
            listViewCurrentStagedContainers = new ListView();
            listViewCurrentStagedContainers.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listViewCurrentStagedContainers.Name = "listViewCurrentStagedContainers";
            listViewCurrentStagedContainers.TabIndex = 2;
            listViewCurrentStagedContainers.View = View.Details;
            listViewCurrentStagedContainers.SelectedIndexChanged += new System.EventHandler(this.listViewCurrentStagedContainers_SelectedIndexChanged);
            listViewCurrentStagedContainers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewCurrentStagedContainers_ColumnClick);
            // Allow the user to rearrange columns.
            listViewCurrentStagedContainers.AllowColumnReorder = false;
            // Display check boxes.
            listViewCurrentStagedContainers.CheckBoxes = false;
            //fonts
            listViewCurrentStagedContainers.Font = new Font("Microsoft Sans Serif", 13);


            //listview with headers alt-94 ^ alt-118 v
            //listViewCurrentStagedContainers.Columns.Add("Tag #", 190, HorizontalAlignment.Left);
            //listViewCurrentStagedContainers.Columns.Add("Product", 135, HorizontalAlignment.Left);
            //listViewCurrentStagedContainers.Columns.Add(/*"Dozen"*/"Quantity", 75, HorizontalAlignment.Left);
            //listViewCurrentStagedContainers.Columns.Add("Container", 125, HorizontalAlignment.Left);
            listViewCurrentStagedContainers.Columns.Add("Tag #", 190, HorizontalAlignment.Left);
            listViewCurrentStagedContainers.Columns.Add("Product", 135, HorizontalAlignment.Left);
            listViewCurrentStagedContainers.Columns.Add("Quantity", 75, HorizontalAlignment.Right);
            listViewCurrentStagedContainers.Columns.Add("Container", 125, HorizontalAlignment.Left);
            listViewCurrentStagedContainers.Columns.Add("Dozen", 75, HorizontalAlignment.Right);

            listViewCurrentStagedContainers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listViewCurrentStagedContainers.FullRowSelect = true;
            //listViewCurrentStagedContainers.CheckBoxes = true;
            listViewCurrentStagedContainers.GridLines = true;
            //listView1.Activation = ItemActivation.OneClick;
            listViewCurrentStagedContainers.Dock = DockStyle.Fill;
            // Add the ListView to the control collection.
            this.panel1.Controls.Add(listViewCurrentStagedContainers);

            // Create a new ListView control.
            listViewContainersOnShipment = new ListView();
            listViewContainersOnShipment.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listViewContainersOnShipment.Name = "listViewContainersOnShipment";
            listViewContainersOnShipment.TabIndex = 8;
            listViewContainersOnShipment.View = View.Details;
            listViewContainersOnShipment.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewCurrentStagedContainers_ColumnClick);
            // Allow the user to rearrange columns.
            listViewContainersOnShipment.AllowColumnReorder = false;
            // Display check boxes.
            listViewContainersOnShipment.CheckBoxes = false;
            listViewContainersOnShipment.Font = new Font("Microsoft Sans Serif", 13);
          
            //listview with headers
            listViewContainersOnShipment.View = View.Details;
            //listViewContainersOnShipment.Columns.Add("Tag #", 190, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Product", 135, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add(/*"Dozen"*/"Quantity", 75, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Container", 125, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Tag #", 190, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Product", 135, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Quantity", 75, HorizontalAlignment.Right);
            listViewContainersOnShipment.Columns.Add("Container", 125, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Dozen", 75, HorizontalAlignment.Right);

            listViewContainersOnShipment.FullRowSelect = true;
            //listViewContainersOnShipment.CheckBoxes = true;
            listViewContainersOnShipment.GridLines = true;
            //listViewContainersOnShipment = ItemActivation.OneClick;
            listViewContainersOnShipment.Dock = DockStyle.Fill;
            // Add the ListView to the control collection.
            this.panel2.Controls.Add(listViewContainersOnShipment);

            //read outstandig containers (unshipped)
            //ReadStagedContainers(ref listViewCurrentStagedContainers, "I"); //I-InProgress; P-Picked S-Shipped

            //default agency
            this.comboBoxAgency.SelectedIndexChanged -= new System.EventHandler(this.comboBoxAgency_SelectedIndexChanged);
            comboBoxAgency.SelectedValue = -1;
            this.comboBoxAgency.SelectedIndexChanged += new System.EventHandler(this.comboBoxAgency_SelectedIndexChanged);
            try
            {
                comboBoxAgency.SelectedValue = Main.Sol_ControlInfo.DefaultAgencyID;
            }
            catch
            {
                comboBoxAgency.SelectedValue = 0;
            }


            if (ShippingHome.ShipmentButtonNew)
            {
                ShippingHome.ShipmentButtonNew = false;
                buttonNew.PerformClick();
            }
            else if (ShippingHome.ShipmentButtonView)
            {
                buttonView.PerformClick();

                textBoxRBillNumber.Text = ShippingHome.RBillNumber;
                ShippingHome.RBillNumber = "";
                ShippingHome.ShipmentButtonView = false;

                buttonSearch.Enabled = true;
                buttonSearch.PerformClick();
            }
            else if (ShippingLookup.ShipmentButtonView)
            {
                buttonView.PerformClick();

                textBoxRBillNumber.Text = ShippingLookup.RBillNumber;
                ShippingLookup.RBillNumber = "";
                ShippingLookup.ShipmentButtonView = false;

                buttonSearch.Enabled = true;
                buttonSearch.PerformClick();
            }

            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }


            CheckUserPermissions();

            //origianlly in Solum
            //if (!(Main.Sol_ControlInfo.State == "AB"
            //    && Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
            //    )
            //{
            //    buttoneRBill.Visible = false;
            //    //buttonPrintRBill
            //    //buttonUnNow

            //    //this.buttoneRBill.Location = new System.Drawing.Point(617, 12);
            //    this.buttonPrintRBill.Location = new System.Drawing.Point(617, 12); //new System.Drawing.Point(734, 12);
            //    this.buttonWarehouseMode.Location = new System.Drawing.Point(734, 12); //new System.Drawing.Point(851, 12);
            //}

            if (Properties.Settings.Default.StagingType == 0)   //!Properties.Settings.Default.MultiProductStagingEnabled)
            {
                toolStripSeparatorMultiProductStaging.Visible = false;
                toolStripButtonMultiProductStaging.Visible = false;
            }

        }

        private void CheckUserPermissions()
        {
            toolStripButtonShipmentAdjustments.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAdjustContainer", false);
            toolStripButtonLookup.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", false);

            buttonNew.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", false);
            //buttonNew.Visible = buttonNew.Enabled;
            buttonView.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", false);
            //buttonView.Visible = buttonView.Enabled;
        }

        private void toolStripButtonHome_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;
            ShippingForm = 1;   //Home
            Close();

        }

        private void toolStripButtonStagedContainers_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;
            ShippingForm = 2;   //StagedContainers
            Close();

        }

        private void toolStripButtonLookup_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", true))
                return;

            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;
            ShippingForm = 4;   //lookup
            Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", true))
                return;

            buttonClicked = buttonNew.Text; // "new";
            //textBoxShipmentID;
            //textBoxUserName;
            //textBoxUserDate;

            EnableControls(true);

            EnableButtons("new");
            ClearForm();

            //this.AcceptButton = buttonLoad;
            textBoxRBillNumber.Focus();
            //for upon exit
            flagChange = true;
            //originalCount = 0;

            int sv = (int)comboBoxAgency.SelectedValue;
            if (sv > 0)
                //read outstandig containers (unshipped)
                ReadStagedContainers(ref listViewCurrentStagedContainers, "I", sv); //I-InProgress; P-Picked S-Shipped

            //default agency
            //comboBoxAgency.SelectedValue = -1;
            //try
            //{
            //    comboBoxAgency.SelectedValue = Main.Sol_ControlInfo.DefaultAgencyID;
            //}
            //catch
            //{
            //    comboBoxAgency.SelectedValue = 0;
            //}

            //comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);




            //default carrier
            try
            {
                comboBoxCarrier.SelectedValue = Main.Sol_ControlInfo.DefaultCarrierID;
            }
            catch
            {
                comboBoxCarrier.SelectedValue = 0;
            }


            if (sol_Agency.AutoGenerateRBillNumber)
            {
                //add row
                if (AddShipment())
                {
                    //textBoxRBillNumber.Text = sol_Shipment.RBillNumber;
                    textBoxRBillNumber.ReadOnly = true;
                    textBoxTagNumber.Focus();
                }
                else
                    buttonCancel.PerformClick();
            }



        }

        //private bool AddShipmentRow()
        //{
        //    if (osi == null)
        //        osi = new SirLib.ObtenerSiguienteId(Properties.Settings.Default.WsirDbConnectionString);
        //    sol_Shipment = new Sol_Shipment();

        //    if (membershipUser == null)
        //        membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
        //    if (membershipUser == null)
        //    {
        //        MessageBox.Show("User does not exits, cannot close the Container");
        //        return false;
        //    }

        //    sol_Shipment.UserID = (Guid)membershipUser.ProviderUserKey;
        //    sol_Shipment.UserName = Properties.Settings.Default.UsuarioNombre;
        //    sol_Shipment.Date = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;

        //    sol_Shipment.Status = "I"; //InProcess

        //    sol_Shipment.ShippedDate = DateTime.Parse("1753-1-1 12:00:00");

        //    sol_Shipment.RBillNumber = osi.Id("Sol_Shipment", "RBillNumber", null, null).ToString();
        //    try
        //    {
        //        sol_Shipment_Sp.Insert(sol_Shipment);
        //    }
        //    catch
        //    {
        //        //try once more
        //        sol_Shipment.RBillNumber = osi.Id("Sol_Shipment", "RBillNumber", null, null).ToString();
        //        try
        //        {
        //            sol_Shipment_Sp.Insert(sol_Shipment);
        //        }
        //        catch (Exception e)
        //        {
        //            CajaDeMensaje.Show("SqlError", "Error trying to add a new Shipment row, try again later please", e.Message, CajaDeMensajeImagen.Error);
        //            sol_Shipment = null;
        //            return false;
        //        }
        //    }


        //    return true;
        //}

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            if (String.IsNullOrEmpty(textBoxRBillNumber.Text))
            {
                MessageBox.Show("Please enter a RBill number");
                textBoxRBillNumber.Focus();
                return;
            }

            if (comboBoxAgency.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter an Agency");
                comboBoxAgency.Focus();
                return;
            }


            //add
            if (sol_Agency.AutoGenerateRBillNumber && buttonClicked == "&New")
            {
                //update
                UpdateShipment();
            }
            else
            {
                if (buttonClicked == "&New")
                {
                    //rbill number already exists?
                    sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(textBoxRBillNumber.Text);
                    if (sol_Shipment != null)
                    {
                        MessageBox.Show("RBill Number already exists, try another number please.");
                        textBoxRBillNumber.Focus();
                        return;

                    }

                    AddShipment();
                }
                else
                {
                    //update
                    UpdateShipment();
                }
            }

            //update StageContainers
            UpdateStagedContainers();

            //view state
            EnableControls(false);
            EnableButtons("close");

            //for upon exit
            flagChange = false;
            //originalCount = 0;

            //blnWarewhouseMode = false;
            ////close warehousemode windows
            //if (fWhm != null)
            //    fWhm.Close();

            buttonClicked = buttonClose.Text; // "new";


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            if (sol_Shipment != null)
            {
                if (sol_Shipment.Status == "S")
                    return;

                if (UndoAutoGenerateRBillNumber())
                    DeleteShipmentRow();

                ////delete row if it was new
                //if (sol_Agency.AutoGenerateRBillNumber)
                //{
                //    if (buttonClicked == "&New")
                //    {
                //        if (DeleteShipmentRow())
                //        {

                //            RestoreRbillNumber();
                //            //if (sol_AutoNumber_Sp == null)
                //            //    sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

                //            //Sol_AutoNumber sol_AutoNumber = sol_AutoNumber_Sp.Select(
                //            //    (int)comboBoxAgency.SelectedValue, 1);

                //            //int rBillNumber = 0;
                //            //int.TryParse(sol_Shipment.RBillNumber, out rBillNumber);
                //            //if (sol_AutoNumber.RBillNumber == rBillNumber)
                //            //{
                //            //    sol_AutoNumber.RBillNumber--;
                //            //    sol_AutoNumber_Sp.Update(sol_AutoNumber);
                //            //}

                //        }

                //    }
                //}
            }

            EnableControls(false);

            EnableButtons("cancel");

            ClearForm();
            this.AcceptButton = originalAcceptButton;
            buttonClicked = buttonCancel.Text; // "new";

        }

        private bool UndoAutoGenerateRBillNumber()
        {
            //delete row if it was new
            if (sol_Agency == null)
                return false;

            if (sol_Agency.AutoGenerateRBillNumber)
            {
                if (buttonClicked == "&New")
                {
                    RestoreRbillNumber();
                    return true;
                }
            }
            return false;
        }


        private bool DeleteShipmentRow()
        {
            try
            {
                sol_Shipment_Sp.Delete(sol_Shipment.ShipmentID);
            }
            catch { }

            textBoxRBillNumber.Text = "";
            return true;
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            buttonClicked = buttonView.Text;    // "view";

            if (buttonClicked == "&View" && !Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", true))
                return;


            if (buttonClicked == "&Edit")
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", true))
                    return;

                EnableControls(true);

                textBoxRBillNumber.ReadOnly = true;
                EnableButtons("edit");
                textBoxTagNumber.Focus();
                //this.AcceptButton = buttonLoad;

                //for upon exit
                flagChange = true;
                //originalCount = listViewContainersOnShipment.Items.Count;

                return;
            }

            textBoxRBillNumber.ReadOnly = false;
            EnableButtons("view");
            ClearForm();
            textBoxRBillNumber.Focus();
            this.AcceptButton = buttonSearch;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxRBillNumber.Text))
            {
                MessageBox.Show("Please enter a RBill Number");
                textBoxRBillNumber.Focus();
                return;
            }

            sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(textBoxRBillNumber.Text);
            if (sol_Shipment == null)
            {
                MessageBox.Show("RBill Number not found, try another one please.");
                textBoxRBillNumber.Focus();
                return;

            }

            if(sol_Shipment.Status != "I")
            {
                sol_Shipment = null;
                MessageBox.Show("Shipment already shipped, try another one please.");
                textBoxRBillNumber.Focus();
                return;

            }



            FillForm();
            textBoxRBillNumber.ReadOnly = true;

            EnableButtons("search");

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            if (String.IsNullOrEmpty(textBoxTagNumber.Text))
            {
                MessageBox.Show("Please enter a Tag number");
                textBoxTagNumber.Focus();
                return;
            }

            ////was a barcode read?
            //string x = textBoxTagNumber.Text.Trim();
            //if (x.Length > 7)
            //{
            //    x = x.Substring(x.Length - 7);
            //    int intValue = 0;
            //    Int32.TryParse(x, out intValue);
            //    if (intValue > 0)
            //        textBoxTagNumber.Text = String.Format("{0}", intValue);
            //    else
            //    {
            //        MessageBox.Show("Error parsing the Tag Number!");
            //        textBoxTagNumber.Focus();
            //        return;
            //    }

            //}


            sol_Stage = sol_Stage_Sp._SelectByTagNumberStatus(textBoxTagNumber.Text, "I");
            if (SearchStagedContainerOnShipment(textBoxTagNumber.Text) || sol_Stage == null)
            {
                MessageBox.Show("Tag number already loaded or not found, try another one please.");
                textBoxTagNumber.SelectAll();
                textBoxTagNumber.Focus();
                return;

            }

            //get agency
            if(sol_Product_Sp == null)
                sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Sol_Product sol_Product = sol_Product_Sp.Select(sol_Stage.ProductID);
            if (sol_Product != null)
            {
                try
                {
                    comboBoxAgency.SelectedValue = sol_Product.AgencyID;
                }
                catch 
                { 
                    MessageBox.Show("We couldn't find the Agency for this product!");
                    return;
                }
            }

            //switch containers
            SwitchContainers(ref listViewCurrentStagedContainers, ref listViewContainersOnShipment, sol_Stage.TagNumber, true, sol_Stage);
            //d1sable comboboxagency if there are containers on shipment


            labelStageContainersCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewCurrentStagedContainers.Items.Count);
            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);


            //comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);

            textBoxTagNumber.Text = "";
            textBoxTagNumber.Focus();




        }

        private void buttonShipNow_Click(object sender, EventArgs e)
        {
            if (!buttonNew.Enabled) buttonClose.PerformClick();
            if (shipmentId < 1)
            {
                MessageBox.Show("Please select a Shipment to ship");
                return;
            }

            ListView.ListViewItemCollection items = listViewContainersOnShipment.Items;
            if (items.Count < 1)
            {
                MessageBox.Show("No Staged Containers on Shipment!");
                return;
            }


            if (comboBoxAgency.Text.Trim().ToLower() == "abcrc")
            {
                //GenerateDataSetBol(shipmentId, textBoxRBillNumber.Text, textBoxDate.Text);
                GenerateDataSetBol2(shipmentId, textBoxRBillNumber.Text);
                //add SupplyInventory entry
                ShippingShipmentsInventory f1 = new ShippingShipmentsInventory(shipmentId);
                //f1.dsBol = dsBol;
                f1.dsBol2 = dsBol2;
                f1.ShowDialog();
                bool confirmed = f1.confirmed;
                f1.Dispose();
                f1 = null;

                if (!confirmed)
                    return;
            }
            //originally in Solum
            //else if (comboBoxAgency.Text.Length > 5 && comboBoxAgency.Text.Substring(0, 6).Trim().ToLower() == "encorp")
            //{
            //    //GenerateDataSetBol(shipmentId, textBoxRBillNumber.Text, textBoxDate.Text);
            //    GenerateDataSetEncorpBol(shipmentId, textBoxRBillNumber.Text);

            //    //add SupplyInventory entry
            //    //ShippingShipmentsInventory f1 = new ShippingShipmentsInventory(shipmentId);
            //    ////f1.dsBol = dsBol;
            //    //f1.dsBol2 = dsBol2;
            //    //f1.ShowDialog();
            //    //bool confirmed = f1.confirmed;
            //    //f1.Dispose();
            //    //f1 = null;

            //    //if (!confirmed)
            //    //    return;
            //}

            //update stage status
            //int id = Int32.Parse(textBoxShipmentID.Text);

            //quitar (uncomment)
            sol_Stage_Sp.UpdateStatusByShipmentId(shipmentId, "S");//I-InProgress; P-Picked S-Shipped

            //update shipment date & status

            //quitar (uncomment)
            sol_Shipment_Sp.UpdateStatus(shipmentId, "S");//I-InProgress; P-Picked S-Shipped 
            sol_Shipment.ShippedDate = Main.rc.FechaActual;

            


            /**********************/
            //quitar (comment)
            //using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            //{
            //    SqlCommand command = new SqlCommand(string.Empty, connection);
            //    connection.Open();
            //    command.CommandText = @"
            //                UPDATE [sol_Shipment] WITH (ROWLOCK)
            //                SET 
            //	                --[Status] = @Status,
            //	                [ShippedDate] = @ShippedDate
            //                WHERE [ShipmentID] = @ShipmentID
            //                ";
            //    //command.Parameters.AddWithValue("@Status", shipmentId);
            //    command.Parameters.AddWithValue("@ShipmentID", shipmentId);
            //    sol_Shipment.ShippedDate = Main.rc.FechaActual;
            //    command.Parameters.AddWithValue("@ShippedDate", sol_Shipment.ShippedDate);
            //    command.ExecuteNonQuery();
            //}
            /**********************/

            //originally in Solum
            ////save manifest file
            //string errorMessage = SaveManifest(sol_Shipment, sol_Agency, Main.myHostName, Main.rc.FechaActual, Main.versionNumber);
            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    MessageBox.Show(errorMessage);
            //    return;
            //}

            MessageBox.Show("Shipped!");
            
            buttonShipNow.Enabled = false;
            buttonView.Enabled = false;
            buttonCancel.Enabled = false;
            
            //EnableButtons("cancel");

            buttonPrintRBill.Enabled = true;
            buttonPrintRBill.PerformClick();

            //buttoneRBill.Enabled = true;
            //enable erbill
            if (Main.Sol_ControlInfo.VendorID > 0)
                if (ShippingLookup.CheckForUnlikedContainers() < 1)
                    buttoneRBill.Enabled = true;


        }

        private void ReadStagedContainers(ref ListView lv1, string status, int agency)
        {
            try
            {
                lv1.Items.Clear();
            }
            catch
            {
                //return;
            }

            if (sol_Stage_Sp == null)
                sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

            if(Properties.Settings.Default.StagingType == 0)
                sol_StageList = sol_Stage_Sp._SelectAllByAgency(status, agency);  //I-InProgress; P-Picked S-Shipped
            else
                sol_StageList = sol_Stage_Sp._SelectAllByAgencyClosed(status, agency);  //I-InProgress; P-Picked S-Shipped

            if (sol_StageList == null)
                return;

            foreach (Sol_Stage st in sol_StageList)
            {
                addItem(ref lv1, st.TagNumber, st.ProductName, st.Dozen, st.ContainerDescription, st.Quantity);
            }
            labelStageContainersCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewCurrentStagedContainers.Items.Count);

        }

        private void ReadContainersOnShipment(ref ListView lv1, int shipmentId)
        {
            lv1.Items.Clear();
            sol_StageList = sol_Stage_Sp._SelectAllByShipmentID(shipmentId);  //I-InProgress; P-Picked S-Shipped
            if (sol_StageList == null)
                return;

            foreach (Sol_Stage st in sol_StageList)
            {
                addItem(ref lv1, st.TagNumber, st.ProductName, st.Dozen, st.ContainerDescription, st.Quantity);
            }
            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);

            //desable comboboxagency if there are conatiners on shipment
            //comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);

        }

        public static bool addItem(ref ListView lv1, string tagNumber, string product, int dozen, string container, int quantity)
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

        private void EnableControls(bool flag)
        {
            textBoxRBillNumber.ReadOnly = !flag;

            textBoxTagNumber.ReadOnly = !flag;

            //if (flag)
            //{
            //    //disable comboboxagency if there are containers on shipment
            //    int iCount = listViewContainersOnShipment.Items.Count;
            //    comboBoxAgency.Enabled = !(iCount > 0);
            //}
            //else
            //    comboBoxAgency.Enabled = flag;

        }

        private void EnableButtons(string buttonName)
        {
            toolStripButtonHome.Enabled = true;
            toolStripButtonStagedContainers.Enabled = true;
            toolStripButtonShipments.Enabled = true;
            toolStripButtonLookup.Enabled = true;
            toolStripButtonLogOff.Enabled = true;
            toolStripButtonExit.Enabled = true;
            buttonPrintRBill.Enabled = false;
            buttoneRBill.Enabled = false;

            buttonShipNow.Enabled = false;

            //comboBoxAgency.Enabled = false;

            switch (buttonName)
            {

                case "new":
                    buttonNew.Enabled = false;
                    //buttonNew.Visible = false;
                    buttonClose.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = false;
                    buttonSearch.Enabled = false;

                    comboBoxCarrier.Enabled = true;
                    textBoxTrailerNumber.Enabled = true;
                    textBoxProBillNumber.Enabled = true;


                    buttonLoad.Enabled = true;
                    panelMiddle.Enabled = true;

                    //buttonShipNow.Enabled = false;
                    buttonShipNow.Enabled = true;
                    buttonShipNow.Text = "&Save && Ship";
                    //buttonPrintRBill.Enabled = false;
                    buttonWarehouseMode.Enabled = true;

    	            toolStripButtonHome.Enabled = false;
            	    toolStripButtonStagedContainers.Enabled = false;
	                toolStripButtonShipments.Enabled = false;
    		        toolStripButtonLookup.Enabled = false;
                    toolStripButtonLogOff.Enabled = false;
                    toolStripButtonExit.Enabled = false;

                    listViewContainersOnShipment.Items.Clear();

                    break;
                case "close":
                    buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", false);
                    buttonNew.Visible = buttonNew.Enabled;
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", false);
                    buttonView.Text = "&Edit";
                    buttonSearch.Enabled = false;

                    comboBoxCarrier.Enabled = false;
                    textBoxTrailerNumber.Enabled = false;
                    textBoxProBillNumber.Enabled = false;

                    buttonLoad.Enabled = false;
                    panelMiddle.Enabled = false;
                    buttonShipNow.Enabled = true;
                    buttonShipNow.Text = "&Ship Now";
                    //buttonPrintRBill.Enabled = true;
                    buttonWarehouseMode.Enabled = false;

                    //comboBoxAgency.Enabled = true;

                    break;
                case "cancel":
                    buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", false);
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = false;
                    buttonView.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", false);
                    buttonView.Text = "&View";
                    buttonSearch.Enabled = false;

                    comboBoxCarrier.Enabled = false;
                    textBoxTrailerNumber.Enabled = false;
                    textBoxProBillNumber.Enabled = false;

                    buttonLoad.Enabled = false;
                    panelMiddle.Enabled = false;

                    buttonShipNow.Enabled = false;
                    buttonShipNow.Text = "&Ship Now";
                    //buttonPrintRBill.Enabled = false;
                    buttonWarehouseMode.Enabled = false;

                    //comboBoxAgency.Enabled = true;

                    listViewContainersOnShipment.Items.Clear();


                    break;
                case "view":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = false;
                    buttonSearch.Enabled = true;

                    comboBoxCarrier.Enabled = false;
                    textBoxTrailerNumber.Enabled = false;
                    textBoxProBillNumber.Enabled = false;

                    buttonLoad.Enabled = false;
                    panelMiddle.Enabled = false;
                    buttonShipNow.Enabled = false;
                    //buttonPrintRBill.Enabled = false;
                    //buttonShipNow.Enabled = true;
                    //buttonPrintRBill.Enabled = true;
                    buttonWarehouseMode.Enabled = false;

                    break;
                case "search":
                    buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", false);
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", false);
                    buttonView.Text = "&Edit";
                    buttonSearch.Enabled = false;

                    comboBoxCarrier.Enabled = false;
                    textBoxTrailerNumber.Enabled = false;
                    textBoxProBillNumber.Enabled = false;

                    buttonLoad.Enabled = false;
                    panelMiddle.Enabled = false;
                    buttonWarehouseMode.Enabled = false;

                    //if (sol_Shipment.Status == "I")
                        buttonShipNow.Enabled = true;

                    break;
                case "edit":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = false;
                    buttonView.Text = "&View";
                    buttonSearch.Enabled = false;

                    comboBoxCarrier.Enabled = true;
                    textBoxTrailerNumber.Enabled = true;
                    textBoxProBillNumber.Enabled = true;

                    buttonLoad.Enabled = true;
                    panelMiddle.Enabled = true;
                    // buttonShipNow.Enabled = false;
                    buttonShipNow.Enabled = true;
                    buttonShipNow.Text = "&Save && Ship";
                    //buttonPrintRBill.Enabled = false;
                    buttonWarehouseMode.Enabled = true;

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

            //enable/disable comboboxagency based on if there are containers on shipment
            comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);

            if (buttonName == "search")
            {
                comboBoxAgency.Enabled = false;
            }


        }

        private void ClearForm()
        {
            shipmentId = 0;
            //textBoxShipmentID.Text = "";
            textBoxRBillNumber.Text = "";

            textBoxUserName.Text = "";
            textBoxDate.Text = "";

            textBoxTagNumber.Text = "";

            //comboBoxAgency.SelectedValue = -1;
            comboBoxCarrier.SelectedValue = -1;

            textBoxTrailerNumber.Text = "";
            textBoxProBillNumber.Text = "";

            //labelAddress1.Text = "";
            //labelAddress2.Text = "";
            //labelCity.Text = "";
            //labelProvince.Text = "";
            //labelCountry.Text = "";
            //labelPostalCode.Text = "";

            //read outstandig containers (unshipped)
            listViewCurrentStagedContainers.Items.Clear();
            //ReadStagedContainers(ref listViewCurrentStagedContainers, "I"); // I-InProgress; P-Picked S-Shipped 

            listViewContainersOnShipment.Items.Clear();
            ContainersAdded.Clear();
            ContainersRemoved.Clear();

            //for upon exit
            flagChange = false;
            //originalCount = 0;

            blnWarewhouseMode = false;
            ////close warehousemode windows
            //if (fWhm != null)
            //    fWhm.Close();
            
        }

        private void comboBoxAgency_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxAgency.SelectedIndex < 0)
            {
                try
                {
                    listViewCurrentStagedContainers.Items.Clear();
                }
                catch { }
                return;
            }


            //buttonCancel.PerformClick();
            //if (blnWarewhouseMode)
            //    return;

            if (UndoAutoGenerateRBillNumber())
                DeleteShipmentRow();

            //EnableControls(false);

            //EnableButtons("cancel");

            //ClearForm();
            //this.AcceptButton = originalAcceptButton;

            int id=0;
            Int32.TryParse(comboBoxAgency.SelectedValue.ToString(), out id);

            //read outstandig containers (unshipped)
            ReadStagedContainers(ref listViewCurrentStagedContainers, "I", id); //I-InProgress; P-Picked S-Shipped

            //if (id < 0)
            //    return;

            sol_Agency = new Sol_Agencie();
            if(sol_Agency_Sp == null)
                sol_Agency_Sp = new Sol_Agencie_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_Agency = sol_Agency_Sp.Select(id);


            if (buttonClicked == "&New")
            {
                if (sol_Agency.AutoGenerateRBillNumber)
                {
                    //add row
                    AddShipment();
                    textBoxTagNumber.Focus();
                }
                else
                {
                    //buttonCancel.PerformClick();
                    textBoxRBillNumber.Focus();
                }

                //textBoxRBillNumber.Text = sol_Shipment.RBillNumber;
                textBoxRBillNumber.ReadOnly = sol_Agency.AutoGenerateRBillNumber;

            }



            //else
            //    comboBoxAgency.Enabled = true;

            //else if (buttonClicked == "&View")
            //{
            //    buttonNew.PerformClick();
            //}


            //if(formerAgencyId != id)
            //{
            ////    if (formerAgencyId > 0)
            ////    {
            ////        RestoreRbillNumber(formerAgencyId);
            ////    }
                
            ////    AutoGenerateRBillNumber(id);

            //    ClearForm();

            //    formerAgencyId = id;
            //}



            //labelAddress1.Text = sol_Agency.Address1;
            //labelAddress2.Text = sol_Agency.Address2;
            //labelCity.Text = sol_Agency.City;
            //labelProvince.Text = sol_Agency.Province;
            //labelCountry.Text = sol_Agency.Country;
            //labelPostalCode.Text = sol_Agency.PostalCode;

            //if (UndoAutoGenerateRBillNumber())
            //    DeleteShipmentRow();
            //buttonCancel.PerformClick();



        }

        private bool AddShipment()
        {
            if (sol_Agency.AutoGenerateRBillNumber)
            {

                AutoGenerateRBillNumber();
            }

            sol_Shipment = new Sol_Shipment();

            //MembershipUser membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
                membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot close the Container");
                return false;
            }
            sol_Shipment.UserID = (Guid)membershipUser.ProviderUserKey;
            sol_Shipment.UserName = Properties.Settings.Default.UsuarioNombre;
            sol_Shipment.Date = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
            sol_Shipment.RBillNumber = textBoxRBillNumber.Text;
            //sol_Shipment.TagNumber = textBoxTagNumber.Text;
            sol_Shipment.AgencyID = Int32.Parse(comboBoxAgency.SelectedValue.ToString());
            sol_Shipment.AgencyName = comboBoxAgency.Text;

            sol_Shipment.AgencyAddress1 = sol_Agency.Address1;
            sol_Shipment.AgencyAddress2 = sol_Agency.Address2;
            sol_Shipment.AgencyCity = sol_Agency.City;
            sol_Shipment.AgencyProvince = sol_Agency.Province;
            sol_Shipment.AgencyCountry = sol_Agency.Country;
            sol_Shipment.AgencyPostalCode = sol_Agency.PostalCode;

            sol_Shipment.Status = "I"; //InProcess

            try
            {
                sol_Shipment.CarrierID = (int)comboBoxCarrier.SelectedValue;
            }
            catch
            {
                sol_Shipment.CarrierID = -1;
            }
            sol_Shipment.TrailerNumber = textBoxTrailerNumber.Text;
            sol_Shipment.ProBillNumber = textBoxProBillNumber.Text;


            sol_Shipment.ShippedDate = DateTime.Parse("1753-1-1 12:00:00");

            try
            {
                sol_Shipment_Sp.Insert(sol_Shipment);
            }
            catch
            {
                if (sol_Agency.AutoGenerateRBillNumber)
                {
                    //try once more
                    int id = sol_AutoNumber_Sp.UpdateRBillNumber((int)comboBoxAgency.SelectedValue, 1);
                    textBoxRBillNumber.Text = id.ToString();    // osi.Id("Sol_Shipment", "RBillNumber", null, null).ToString();
                    sol_Shipment.RBillNumber = textBoxRBillNumber.Text;
                    try
                    {
                        sol_Shipment_Sp.Insert(sol_Shipment);
                    }
                    catch (Exception e)
                    {
                        CajaDeMensaje.Show("SqlError", "Error trying to add a new Shipment row, try again later please", e.Message, CajaDeMensajeImagen.Error);
                        sol_Shipment = null;
                        return false;
                    }

                }

            }



            //textBoxShipmentID.Text = sol_Shipment.ShipmentID.ToString();
            shipmentId = sol_Shipment.ShipmentID;
            textBoxUserName.Text = sol_Shipment.UserName;
            textBoxDate.Text = sol_Shipment.Date.ToString("G");

            return true;
        }

        private void FillForm()
        {
            //textBoxShipmentID.Text = sol_Shipment.ShipmentID.ToString();
            shipmentId = sol_Shipment.ShipmentID;

            textBoxUserName.Text = sol_Shipment.UserName;
            textBoxDate.Text = sol_Shipment.Date.ToString("G");

            comboBoxAgency.SelectedValue = sol_Shipment.AgencyID;
            comboBoxAgency.Text = sol_Shipment.AgencyName;

            textBoxRBillNumber.Text = sol_Shipment.RBillNumber;

            try
            {
                comboBoxCarrier.SelectedValue = sol_Shipment.CarrierID;
            }
            catch { }

            //labelAddress1.Text = sol_Shipment.AgencyAddress1;
            //labelAddress2.Text = sol_Shipment.AgencyAddress2;
            //labelCity.Text = sol_Shipment.AgencyCity;
            //labelProvince.Text = sol_Shipment.AgencyProvince;
            //labelCountry.Text = sol_Shipment.AgencyCountry;
            //labelPostalCode.Text = sol_Shipment.AgencyPostalCode;

            //read containers on shipment
            ReadContainersOnShipment(ref listViewContainersOnShipment, sol_Shipment.ShipmentID);

            //if (comboBoxAgency.SelectedValue != null)
            //{
            //    int sv = (int)comboBoxAgency.SelectedValue;
            //    if (sv > 0)
            //    {
            //        //read outstandig containers (unshipped)
            //        ReadStagedContainers(ref listViewCurrentStagedContainers, "I", sv); //I-InProgress; P-Picked S-Shipped
            //    }
            //}


            //aqui
            int agencyId = sol_Shipment.AgencyID;

            if (agencyId > 0)
            {
                //read outstandig containers (unshipped)
                ReadStagedContainers(ref listViewCurrentStagedContainers, "I", agencyId); //I-InProgress; P-Picked S-Shipped
            }

        }

        private bool UpdateShipment()
        {

            sol_Shipment.ShipmentID = shipmentId;

            //sol_Shipment.UserID = (Guid)membershipUser.ProviderUserKey;
            //sol_Shipment.UserName = Properties.Settings.Default.UsuarioNombre;
            //sol_Shipment.Date = DateTime.Now;

            sol_Shipment.RBillNumber = textBoxRBillNumber.Text;
            sol_Shipment.AgencyID = Int32.Parse(comboBoxAgency.SelectedValue.ToString());
            sol_Shipment.AgencyName = comboBoxAgency.Text;
            sol_Shipment.AgencyAddress1 = sol_Agency.Address1;
            sol_Shipment.AgencyAddress2 = sol_Agency.Address2;
            sol_Shipment.AgencyCity = sol_Agency.City;
            sol_Shipment.AgencyProvince = sol_Agency.Province;
            sol_Shipment.AgencyCountry = sol_Agency.Country;
            sol_Shipment.AgencyPostalCode = sol_Agency.PostalCode;

            try
            {
                sol_Shipment.CarrierID = (int)comboBoxCarrier.SelectedValue;
            }
            catch
            {
                sol_Shipment.CarrierID = -1;
            }
            sol_Shipment.TrailerNumber = textBoxTrailerNumber.Text;
            sol_Shipment.ProBillNumber = textBoxProBillNumber.Text;



            try
            {
                sol_Shipment_Sp.Update(sol_Shipment);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        public static void SwitchContainers(ref ListView lv1, ref ListView lv2, string tagNumber, bool added, Sol_Stage sol_Stage)
        {
            
            //remove from 
            int indice = 0;
            Sol_Stage sol_Stage1 = new Sol_Stage();
            ListView.ListViewItemCollection Items = lv1.Items;
            foreach (ListViewItem item in Items)
            {
                string tn = item.SubItems[0].Text.Trim();
                if (tn == tagNumber)
                {
                    //listView1.Items.Remove(item);
                    //listView1.Items.RemoveAt(indice);

                    sol_Stage1.TagNumber = tagNumber;
                    sol_Stage1.ProductName = item.SubItems[1].Text;
                    string c = item.SubItems[2].Text;
                    c = c.Replace(",", "");
                    int intValue = 0;
                    Int32.TryParse(c, out intValue);
                    sol_Stage1.Quantity/*Dozen*/ = intValue;
                    sol_Stage1.ContainerDescription = item.SubItems[3].Text;
                    break;
                }
                indice++;

            }

            if (indice > lv1.Items.Count)
                return;

            if (indice == 0)
                if(sol_Stage != null)
                    sol_Stage1 = sol_Stage;

            //add to
            if (added)
            {
                ContainersAdded.Add(sol_Stage1.TagNumber);
                try
                {
                    ContainersRemoved.Remove(sol_Stage1.TagNumber);
                }
                catch { }
            }
            else
            {
                ContainersRemoved.Add(sol_Stage1.TagNumber);
                try
                {
                    ContainersAdded.Remove(sol_Stage1.TagNumber);
                }
                catch { }
            }

            //addItem(listView2, tagNumber, itemFound.SubItems[1].Text, Int32.Parse(itemFound.SubItems[2].Text), itemFound.SubItems[3].Text);
            addItem(ref lv2, tagNumber, sol_Stage1.ProductName, sol_Stage1.Dozen, sol_Stage1.ContainerDescription, sol_Stage1.Quantity);

            try 
            { 
                lv1.Items.RemoveAt(indice); 
            } 
            catch 
            { 
                //
            };


        }

        private void buttonAddAll_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            ListView.ListViewItemCollection items = listViewCurrentStagedContainers.Items;
            if (items.Count < 1)
            {
                MessageBox.Show("No Staged Containers to add");
                return;
            }


            //ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in items)
            {
                SwitchContainers(ref listViewCurrentStagedContainers, ref listViewContainersOnShipment, item.SubItems[0].Text, true, null);

            }
            labelStageContainersCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewCurrentStagedContainers.Items.Count);
            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);

            //enable/disable comboboxagency based on if there are containers on shipment
            comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            ListView.SelectedListViewItemCollection selectedItems = listViewCurrentStagedContainers.SelectedItems;
            if (selectedItems.Count < 1)
            {
                MessageBox.Show("Please select a Staged Container");
                return;
            }


            //ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in selectedItems)
            {
                SwitchContainers(ref listViewCurrentStagedContainers, ref listViewContainersOnShipment, item.SubItems[0].Text, true, null);

            }

            labelStageContainersCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewCurrentStagedContainers.Items.Count);
            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);

            //enable/disable comboboxagency based on if there are containers on shipment
            comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;
            ListView.SelectedListViewItemCollection selectedItems = listViewContainersOnShipment.SelectedItems;
            if (selectedItems.Count < 1)
            {
                MessageBox.Show("Please select a Container on Shipment");
                return;
            }


            //ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in selectedItems)
            {
                SwitchContainers(ref listViewContainersOnShipment, ref listViewCurrentStagedContainers, item.SubItems[0].Text, false, null);
            }
            labelStageContainersCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewCurrentStagedContainers.Items.Count);
            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);

            //enable/disable comboboxagency based on if there are containers on shipment
            comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);

        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;
            ListView.ListViewItemCollection items = listViewContainersOnShipment.Items;
            if (items.Count < 1)
            {
                MessageBox.Show("No Staged Containers to remove");
                return;
            }


            //ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in items)
            {
                SwitchContainers(ref listViewContainersOnShipment, ref listViewCurrentStagedContainers, item.SubItems[0].Text, false, null);
            }
            labelStageContainersCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewCurrentStagedContainers.Items.Count);
            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);

            //enable/disable comboboxagency based on if there are containers on shipment
            comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);

        }

        //update StageContainers
        private void UpdateStagedContainers()
        {
            //ContainersAdded
            foreach (string tn in ContainersAdded)
            {
                //MessageBox.Show(item.SubItems[0].Text);
                sol_Stage_Sp.UpdateStatus(shipmentId, tn, "I", "P");

            }
            ContainersAdded.Clear();

            //ContainersRemoved
            foreach (string tn in ContainersRemoved)
            {
                sol_Stage_Sp.UpdateStatus(0, tn, "P", "I");

            }
            ContainersRemoved.Clear();

        }

        private void textBoxTagNumber_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = buttonLoad;

        }

        private void textBoxTagNumber_Leave(object sender, EventArgs e)
        {
            //if (blnWarewhouseMode)
            //    textBoxTagNumber.Focus();

        }

        private void buttonPrintRBill_Click(object sender, EventArgs e)
        {
            if (shipmentId < 1)
            {
                MessageBox.Show("Please select a Shipment to print");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            if (comboBoxAgency.Text.Trim().ToLower() == "abcrc")
            {
                UpdateDataSetBol2(shipmentId, textBoxRBillNumber.Text);

                //sol_Shipment.CarrierID = (int)comboBoxCarrier.SelectedValue;
                //sol_Shipment.TrailerNumber = textBoxTrailerNumber.Text;
                //sol_Shipment.ProBillNumber = textBoxProBillNumber.Text;

               // if (sol_Shipment.ShippedDate.Year == 1753)
                 //   sol_Shipment.ShippedDate = Main.rc.FechaActual;

                PrintBol2(
                    shipmentId, 
                    textBoxRBillNumber.Text, 
                    sol_Shipment.ShippedDate.ToString(), //textBoxDate.Text, 
                    comboBoxCarrier.Text,
                    textBoxTrailerNumber.Text,
                    textBoxProBillNumber.Text
                    );

            }
            //else if (comboBoxAgency.Text.Length > 5 && comboBoxAgency.Text.Substring(0, 6).Trim().ToLower() == "encorp")
            //{ //originally in Solum
            //    UpdateDataSetEncorpBol(shipmentId, textBoxRBillNumber.Text);


            //    PrintEncorpBol(
            //        shipmentId,
            //        textBoxRBillNumber.Text,
            //        sol_Shipment.ShippedDate.ToString(), //textBoxDate.Text, 
            //        comboBoxCarrier.Text,
            //        textBoxTrailerNumber.Text,
            //        textBoxProBillNumber.Text
            //        , dsEncorpBol
            //        );

            //}
            else
                PrintRBill(shipmentId.ToString());
            this.Cursor = Cursors.Default;
        }

        private void buttonWarehouseMode_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            if (String.IsNullOrEmpty(textBoxRBillNumber.Text))
            {
                MessageBox.Show("Please enter a RBill number");
                textBoxRBillNumber.Focus();
                return;
            }

            if (comboBoxAgency.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter an Agency");
                comboBoxAgency.Focus();
                return;
            }


            fWhm = new ShippingShipmentsWarehouseMode();
            //fWhm.Opacity = 75;

            fWhm.Show();

            textBoxTagNumber.Focus();
            blnWarewhouseMode = true;


        }

        public static void PrintBoL(
            int shipmentId, 
            string rBillNumber, 
            string rBillDate,
            string carrier,
            string traylerNumber,
            string proBillNumber

            )
        {

            try
            {

                //read containers
                if (Main.Sol_ControlInfo.WhiteBagID < 0)
                    MessageBox.Show("You have to define special containers for this report.\r\n Please go to Tools -> Settings -> ABCRC to do it.");

                //query
                string query = "";
                //query 2
                string query2 = "";
                string subReportName2 = "";
                //query 3
                string query3 = "";
                string subReportName3 = "";


                CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new Solum.Reports.StraightBillOfLading();

                int intNumber = 0;
                string vendorId = string.Format("{0:d4}", Main.Sol_ControlInfo.VendorID);
                Int32.TryParse(rBillNumber, out intNumber);
                rBillNumber = string.Format("{0:d6}", intNumber);

                string imagePath = String.Empty;
                string strBarcode = rBillNumber;
                if (Main.Sol_ControlInfo.RBillNumberBarcode)
                {

                    //parse it
                    if (strBarcode.Length < 7)
                    {
                        strBarcode = vendorId + rBillNumber;
                    }

                    //generate barcode
                    //SirLib.BarCodeCtrl userControl11 = new SirLib.BarCodeCtrl();

                    //userControl11.BarCode = strBarcode;

                    //userControl11.BarCodeHeight = 70;
                    //userControl11.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //userControl11.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                    ////userControl11.HeaderFont = new System.Drawing.Font("Comic Sans MS", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ////userControl11.HeaderText = "";
                    ////userControl11.LeftMargin = 5;   // 10;
                    ////userControl11.Location = new System.Drawing.Point(1,1); //10, 9);
                    //userControl11.Name = "userControl11";
                    //userControl11.ShowFooter = true;
                    //userControl11.ShowHeader = false;   // true;
                    //userControl11.Size = new System.Drawing.Size(400, 100); //340, 83);
                    //userControl11.TabIndex = 0;
                    //userControl11.TopMargin = 5;
                    //userControl11.VertAlign = BarCodeCtrl.AlignType.Center;
                    //userControl11.Weight = BarCodeCtrl.BarCodeWeight.Medium;
                    //imagePath = Main.temFolder + "\\barCodeRBill.bmp";  //Barcodes\\
                    //try
                    //{
                    //    userControl11.SaveImage(imagePath);
                    //    userControl11.Dispose();
                    //}
                    //catch (Exception e)
                    //{
                    //    CajaDeMensaje.Show("CashierCash", "Error trying to save the RBill number barcode image", e.Message, CajaDeMensajeImagen.Error);
                    //    imagePath = String.Empty;
                    //}


                    imagePath = Main.temFolder + "\\barCodeRBill.bmp";
                    string errorMessage = string.Empty;
                    SolFunctions.GenerateBarcode(
                                Properties.Settings.Default.BarcodeEncoding
                                , Properties.Settings.Default.BarcodeWidth
                                , Properties.Settings.Default.BarcodeHeight
                                , BarcodeLib.AlignmentPositions.CENTER
                                , System.Drawing.RotateFlipType.RotateNoneFlipNone
                                , BarcodeLib.LabelPositions.BOTTOMCENTER
                                , strBarcode
                                , imagePath
                                , BarcodeLib.SaveTypes.BMP
                                , null
                                , ref errorMessage
                                );
                }



                object[,] parametros = new object[,] { 
                { "imagenPath", imagePath },
                { "Carrier", carrier },
                { "TraylerNumber", traylerNumber },
                { "ProBillNumber", proBillNumber },
                { "VendorId", vendorId },
                { "RBillNumber", rBillNumber },
                {"", ""}
            };



                bool imprimirReporte = false;
                bool exportarReporte = false;
                short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
                bool preverReporte = false;
                short numeroDeCopias = 1;
                if (Properties.Settings.Default.SettingsWsReportPrintPreview)
                    preverReporte = true;
                else
                    imprimirReporte = true;

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
                    dsBol,
                    String.Empty,
                    true,
                    true
                );
                f1.ShowDialog();
                f1.Dispose();
                f1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //public static DataSet GetDataBoL(int shipmentId)
        //{
        //    DataSet dsBoL = new DataSet("BoL");

        //    DataTable dtBoL = new DataTable("BoL");
        //    // BOL
        //    dtBoL.Columns.Add("BOLNumber");
        //    dtBoL.Columns.Add("DepotName");
        //    dtBoL.Columns.Add("DepotAddress");
        //    dtBoL.Columns.Add("Date");
        //    dtBoL.Columns.Add("Logo");

        //    DataRow drBoL = dtBoL.NewRow();
        //    drBoL["BOLNumber"] = shipmentId;
        //    drBoL["DepotName"] = Main.Sol_ControlInfo.BusinessName;
        //    drBoL["DepotAddress"] = Main.Sol_ControlInfo.Address;
        //    drBoL["Date"] = DateTime.Now;


        //    dtBoL.Rows.Add(drBoL);
        //    dsBoL.Tables.Add(dtBoL);

        //    return dsBoL;
        //}

        public static void PrintRBill(string strShipmentId)
        {
            //quitar
            //need to remove Dozen when not need it anymore

            //query
            string query = @"
            SELECT st.StageID, st.TagNumber, st.ContainerDescription, p.ProDescription as ProductName, st.Dozen
            --, st.Quantity
            , st.Remarks, 
            s.RBillNumber, s.Date, s.AgencyName, s.ShipmentID   
            FROM sol_Shipment as s  
            INNER JOIN sol_Stage as st ON st.ShipmentID = s.ShipmentID  
            INNER JOIN sol_Products as p ON p.ProductID = st.ProductID  
            WHERE s.ShipmentID = 
            "
            + strShipmentId + " ";   // shipmentId.ToString();

            //query 2
            string query2 = @"
            SELECT  
            st.StageID, st.TagNumber, st.ContainerDescription, p.ProDescription as ProductName, st.Dozen
            --, st.Quantity
            , st.Price,   
            s.RBillNumber, s.Date, s.AgencyName,
            p.HandlingCommissionAmount, p.VafAmount, p.UPC,
            c.RefundAmount, [dbo].[fn_Shipment_SumOfDozen](s.ShipmentID, st.ProductID) as SumOfDozen
            --, [dbo].[fn_Shipment_SumOfQuantity](s.ShipmentID, st.ProductID) as SumOfQuantity
            FROM sol_Shipment as s
            INNER JOIN sol_Stage as st ON st.ShipmentID = s.ShipmentID  
            INNER JOIN sol_Products as p ON p.ProductID = st.ProductID  
            INNER JOIN Sol_Categories as c ON c.CategoryID = p.CategoryID  
            WHERE s.ShipmentID = 
            "
            + strShipmentId + " ";   // shipmentId.ToString();

            string subReportName2 = "BillOfLadingSummary.rpt";

            //query 3
            string query3 = @"
            SELECT  
            st.StageID, st.TagNumber, st.ContainerDescription, p.ProDescription as ProductName, st.Dozen
            --, st.Quantity
            , s.RBillNumber, s.Date, s.AgencyName  
            FROM sol_Shipment as s
            INNER JOIN sol_Stage as st ON st.ShipmentID = s.ShipmentID  
            INNER JOIN sol_Products as p ON p.ProductID = st.ProductID  
            WHERE s.ShipmentID = 
            "
            + strShipmentId + " ";   // shipmentId.ToString();

            string subReportName3 = "BillOfLadingContainerSummary.rpt";

            // message
            //Sol_Message sol_Message = new Sol_Message();
            //Sol_Message_Sp sol_Message_Sp = new Sol_Message_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //sol_Message = sol_Message_Sp.Select(Main.controlInfo.ReceiptMessageID);

            //CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new CgPrg.Reportes.Crystal_Report102__Polizas();
            CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new Solum.Reports.BillOfLading();
            object[,] parametros = new object[,] { 
                { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                { "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                { "3_Address", Main.Sol_ControlInfo.Address },
                { "4_City", Main.Sol_ControlInfo.City },
                { "5_State", Main.Sol_ControlInfo.State },
                { "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                { "7_Message", "" },
                { "8_LegalName", Main.Sol_ControlInfo.LegalName },
                {"", ""}
            };

            bool imprimirReporte = false;
            bool exportarReporte = false;
            short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
            bool preverReporte = false;
            short numeroDeCopias = 1;
            if (Properties.Settings.Default.SettingsWsReportPrintPreview)
                preverReporte = true;
            else
                imprimirReporte = true;

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

        }

        private bool SearchStagedContainerOnShipment(string tagNumber)
        {
            //
            Sol_Stage sol_Stage = new Sol_Stage();
            ListView.ListViewItemCollection Items = listViewContainersOnShipment.Items;
            foreach (ListViewItem item in Items)
            {
                string tn = item.SubItems[0].Text.Trim();
                if (tn == tagNumber)
                {
                    return true;
                }

            }
            return false;

        }

        private void listViewCurrentStagedContainers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SirLib.ListViewItemComparer.ColumnClick((ListView)sender, e);
        }

        private void listViewCurrentStagedContainers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonScanner_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;
            ShippingShipmentsScanner f1 = new ShippingShipmentsScanner();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
            //disable comboboxagency if there are containers on shipment
            //comboBoxAgency.Enabled = !(listViewContainersOnShipment.Items.Count > 0);

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //never mine if warehousemode windows
            if (blnWarewhouseMode)
                return;

            Close();

        }

        private void textBoxTagNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////numbers only textbox
            //if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            //    e.Handled = true;

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

        //private void timer1_Tick(object sender, System.EventArgs e)
        //{
        //    DateTime t = DateTime.Now;
        //    toolStripStatusLabelTimer.Text = t.ToShortTimeString();
        //    toolStripStatusLabelToday.Text = t.ToShortDateString();
        //}

        public static void GenerateDataSetBol(int shipmentId, string rBillNumber, string rBillDate)
        {
            dsBol = new DataSetBoL();
            DataRow drBoL = dsBol.Tables["BOL"].NewRow();

            drBoL["rBillNumber"] = rBillNumber;
            drBoL["DepotName"] = Main.Sol_ControlInfo.BusinessName;
            drBoL["DepotAddress"] = Main.Sol_ControlInfo.Address;
            drBoL["DepotCity"] = Main.Sol_ControlInfo.City;
            drBoL["DepotProvince"] = Main.Sol_ControlInfo.State;
            DateTime dt = Main.rc.FechaActual; // ;
            DateTime.TryParse(rBillDate, out dt);
            drBoL["Date"] = dt;
            string logoPathName = Main.appFolder + "\\Resources\\ABCRC_Logo_Blk.tif";  //@"D:\Mis Proyectos\Visual C#\Kevin\imagenes\ABCRC_Logo_Blk.tif";
            if (!String.IsNullOrEmpty(logoPathName))
            {
                try
                {
                    PictureBox pictureBoxLogo = null;
                    Label labelLogoError = null;
                    drBoL["Logo"] = SirLib.Funciones.LoadImage(logoPathName, ref pictureBoxLogo, ref labelLogoError);
                }
                catch { }
            }

            int dozens, whiteBags, blueBags, oneWayBags, aBCRCPallets;

            foreach (string cc in Main.crisCodes)
            {
                if (cc == "8888")
                {
                    int x = 0;
                    x++;
                }
                ProductInfo(ref drBoL, shipmentId, cc, out dozens, out whiteBags, out blueBags, out oneWayBags, out aBCRCPallets);
            }
            dsBol.Tables[0].Rows.Add(drBoL);

        }

        public static void ProductInfo(ref DataRow drBoL, int shipmentID, string productCode, out int dozens, out int whiteBags, out int blueBags, out int oneWayBags, out int aBCRCPallets)
        {
            dozens = 0;
            whiteBags = 0;
            blueBags = 0;
            oneWayBags = 0;
            aBCRCPallets = 0;

            readProductInfo(shipmentID, productCode, out dozens, out whiteBags, out blueBags, out oneWayBags, out aBCRCPallets);

            string columnName;
            //if (dozens != 0)
            {
                columnName = productCode + "Dozens";
                drBoL[columnName] = dozens;
            }
            //if (whiteBags > 0)
            {
                columnName = productCode + Main.dataSetContainersName[0];    // "WhiteBags";
                drBoL[columnName] = whiteBags;
            }
            //if (blueBags > 0)
            {
                columnName = productCode + Main.dataSetContainersName[1];    // "BluBags";
                drBoL[columnName] = blueBags;
            }
            //if (oneWayBags > 0)
            {
                columnName = productCode + Main.dataSetContainersName[2];    // "OneWayBags";
                drBoL[columnName] = oneWayBags;
            }
            //if (aBCRCPallets > 0)
            {
                columnName = productCode + Main.dataSetContainersName[3];    // "ABCRCPallets";
                drBoL[columnName] = aBCRCPallets;
            }


        }

        public static void readProductInfo(int shipmentID, string productCode, out int dozens, out int whiteBags, out int blueBags, out int oneWayBags, out int aBCRCPallets)
        {
            dozens = 0;
            whiteBags = 0;
            blueBags = 0;
            oneWayBags = 0;
            aBCRCPallets = 0;

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShipmentID", shipmentID),
				new SqlParameter("@ProductCode", productCode)
			};
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(Properties.Settings.Default.WsirDbConnectionString, CommandType.StoredProcedure, "sol_Reports_BOL", parameters))
            {
                if (dataReader.Read())
                {
                    dozens = SqlClientUtility.GetInt32(dataReader, "Dozen", 0);

                }
            }

            //read containers
            if (Main.Sol_ControlInfo.WhiteBagID >= 0)
                readContainerInfo(shipmentID, productCode, Main.Sol_ControlInfo.WhiteBagID, out whiteBags);
            if (Main.Sol_ControlInfo.BlueBagID >= 0)
                readContainerInfo(shipmentID, productCode, Main.Sol_ControlInfo.BlueBagID, out blueBags);
            if (Main.Sol_ControlInfo.OneWayBagID >= 0)
                readContainerInfo(shipmentID, productCode, Main.Sol_ControlInfo.OneWayBagID, out oneWayBags);
            if (Main.Sol_ControlInfo.ABCRCPalletsID >= 0)
                readContainerInfo(shipmentID, productCode, Main.Sol_ControlInfo.ABCRCPalletsID, out aBCRCPallets);

        }

        public static void readContainerInfo(int shipmentID, string productCode, int containerID, out int containerCount)
        {
            containerCount = 0;

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShipmentID", shipmentID),
				new SqlParameter("@ProductCode", productCode),
				new SqlParameter("@ContainerID", containerID)
			};
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(Properties.Settings.Default.WsirDbConnectionString, CommandType.StoredProcedure, "sol_Reports_BOL_Containers", parameters))
            {
                if (dataReader.Read())
                {
                    containerCount = SqlClientUtility.GetInt32(dataReader, "ContainerCount", 0);

                }
            }

        }

        public static void UpdateDataSetBol(int shipmentId, string textBoxRBillNumber, string textBoxDate)
        {
            //if(dsBol == null)
                GenerateDataSetBol(shipmentId, textBoxRBillNumber, textBoxDate);

            //return;


            //clear quantities
            short counter = 0;
            int maxCol = dsBol.Tables[0].Columns.Count;
            for (int i = 8; i < maxCol; i++)
            {
                dsBol.Tables[0].Rows[0][i] = 0;
                counter++;
                if (counter >= 4)
                {
                    counter = 0;
                    i++;
                    //dsBol.Tables[0].Rows[0][i] = 0;
                }


            }

            //string[] dataSetContainersName = new string[4] 
            //{
            //    "WhiteBags",
            //    "BluBags",
            //    "OneWayBags",
            //    "ABCRCPallets"
            //};

            //Sol_Container sol_Container = new Sol_Container();
            //Sol_Container_Sp sol_Container_Sp = new Solum.Sol_Container_Sp(Properties.Settings.Default.WsirDbConnectionString);

            Sol_Product sol_Product;
            //if (sol_Product_Sp == null)
            Sol_Product_Sp sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);


            //read new data
            //Sol_SupplyInventory sol_SupplyInventory;
            //if(sol_SupplyInventory_Sp == null)
            Sol_SupplyInventory_Sp sol_SupplyInventory_Sp = new Sol_SupplyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Sol_SupplyInventory> sol_SupplyInventoryList = sol_SupplyInventory_Sp._SelectAllByShipmentID(shipmentId);
            foreach (Sol_SupplyInventory ssi in sol_SupplyInventoryList)
            {
                //productCode
                sol_Product = new Sol_Product();
                //if (ssi.ProductID < 1)
                //{
                //sol_Product = new Sol_Product();
                //    if (ssi.ContainerID == Main.Sol_ControlInfo.SBolExtraContainerID)
                //        //sol_Container = sol_Container_Sp.Select(Main.Sol_ControlInfo.SBolExtraContainerID);
                //        sol_Product.ProductCode = "ExtraContainer";
                //    else
                //        sol_Product.ProductCode = "EmptyContainer";

                //}
                if (ssi.ProductID == -1)
                {
                    sol_Product.ProductCode = "ExtraContainer";
                }
                else if (ssi.ProductID == 0)
                {
                    sol_Product.ProductCode = "EmptyContainer";
                }
                else
                {
                    sol_Product = sol_Product_Sp.Select(ssi.ProductID);
                }

                //containerName
                string containerName = String.Empty;
                if (ssi.ContainerID == Main.Sol_ControlInfo.WhiteBagID)
                    containerName = Main.dataSetContainersName[0];
                else if (ssi.ContainerID == Main.Sol_ControlInfo.BlueBagID)
                    containerName = Main.dataSetContainersName[1];
                else if (ssi.ContainerID == Main.Sol_ControlInfo.OneWayBagID)
                    containerName = Main.dataSetContainersName[2];
                else if (ssi.ContainerID == Main.Sol_ControlInfo.ABCRCPalletsID)
                    containerName = Main.dataSetContainersName[3];



                string dataSetColName = sol_Product.ProductCode.Trim()+containerName;
                dsBol.Tables[0].Rows[0][dataSetColName] = ssi.Quantity;

            }
        }

        private void buttoneRBill_Click(object sender, EventArgs e)
        {
            if (sol_Shipment_Sp == null)
                sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(textBoxRBillNumber.Text);
            if (sol_Shipment == null)
            {
                MessageBox.Show(String.Format("Invalid RBill Number: {0}, please verify it", textBoxRBillNumber.Text), "", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
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

            if (sol_Agency_Sp == null)
                sol_Agency_Sp = new Sol_Agencie_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_Agency = sol_Agency_Sp.Select(sol_Shipment.AgencyID);
            if (sol_Agency.Name.ToLower().Trim() != "abcrc")
            {
                MessageBox.Show("Shipment's agency is not ABCRC!");
                return;
            }

            eRBill(sol_Shipment, sol_Shipment_Sp);
        }

        public static void eRBill(Sol_Shipment sol_Shipment, Sol_Shipment_Sp sol_Shipment_Sp)
        {
      
            //provide carrier information
            eRBill_CheckList f = new eRBill_CheckList();
            f.Sol_Shipment = sol_Shipment;
            f.Sol_Shipment_Sp = sol_Shipment_Sp;

            f.ShowDialog();
            int EResult = f.EResult;
            f.Dispose();
            f = null;
            if (EResult <1)   //== -1)    //-1 = cancel, 0 = apply, 1 transmit
                return;

            //update flag in shipment table if transmitted
            sol_Shipment_Sp.UpdateERBillTransmitted(sol_Shipment.ShipmentID, true);

            //display result 
            MessageBox.Show("eRbill submitted successfully!");
        }

        private bool AutoGenerateRBillNumber()
        {
            int id = 0;
            Int32.TryParse(comboBoxAgency.SelectedValue.ToString(), out id);

            if (id < 1)
                return false;

            if (sol_AutoNumber_Sp == null)
                sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

            id = sol_AutoNumber_Sp.UpdateRBillNumber(id, 1);
            if (id < 1)
            {
                MessageBox.Show("Can not generate next RBill number, last RBill number should be a valid integer.");
                return false;

            }
            textBoxRBillNumber.Text = id.ToString();

            return true;
        }

        private bool RestoreRbillNumber()
        {
            if (sol_Agency == null)
                return false;

            if (sol_Agency.AgencyID < 1)
                return false;

            if (sol_AutoNumber_Sp == null)
                sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

            Sol_AutoNumber sol_AutoNumber = sol_AutoNumber_Sp.Select(sol_Agency.AgencyID, 1);
            int rBillNumber = 0;
            int.TryParse(sol_Shipment.RBillNumber, out rBillNumber);
            if (sol_AutoNumber.RBillNumber == rBillNumber)
            {
                sol_AutoNumber.RBillNumber--;
                sol_AutoNumber_Sp.Update(sol_AutoNumber);
            }

            return true;

        }

        private void toolStripButtonShipmentAdjustments_Click(object sender, EventArgs e)
        {
            ShippingForm = 5;   //Adjustments
            Close();

        }

        #region DataSetBol2

        public static void UpdateDataSetBol2(int shipmentId, string textBoxRBillNumber)
        {
            GenerateDataSetBol2(shipmentId, textBoxRBillNumber);
        }

        private static DataRow CreateNewRowDataSetBol2()
        {
            //dsBol2 = new DataSetBol2();

            DataRow drBoL = dsBol2.Tables[0].NewRow();

            drBoL["ProName"] = string.Empty;
            drBoL["ProName"] = string.Empty;
            drBoL["ProCode"] = string.Empty;
            drBoL["Dozens"] = 0;
            drBoL["WhiteBags"] = 0;
            drBoL["BluBags"] = 0;
            drBoL["OneWayBags"] = 0;
            drBoL["ABCRCPallets"] = 0;
            drBoL["ExtraContainerDozens"] = 0;
            drBoL["ExtraContainerWhiteBags"] = 0;
            drBoL["ExtraContainerBluBags"] = 0;
            drBoL["ExtraContainerOneWayBags"] = 0;
            drBoL["ExtraContainerABCRCPallets"] = 0;
            drBoL["EmptyContainerDozens"] = 0;
            drBoL["EmptyContainerWhiteBags"] = 0;
            drBoL["EmptyContainerBluBags"] = 0;
            drBoL["EmptyContainerOneWayBags"] = 0;
            drBoL["EmptyContainerABCRCPallets"] = 0;
            drBoL["Units"] = 0;
            drBoL["EmptyContainerUnits"] = 0;
            drBoL["EmptyContainerUnits"] = 0;

            return drBoL;

        }

        public static void PrintBol2(
            int shipmentId
            , string rBillNumber
            , string rBillDate
            , string carrier
            , string trailerNumber
            , string proBillNumber
           )
        {
            try
            {

                //read containers
                if (Main.Sol_ControlInfo.WhiteBagID < 0)
                    MessageBox.Show("You have to define special containers for this report.\r\n Please go to Tools -> Settings -> ABCRC to do it.");

                //query
                string query = "";
                //query 2
                string query2 = "";
                string subReportName2 = "";
                //query 3
                string query3 = "";
                string subReportName3 = "";


                int rBillVersion = 0;
                Sol_Setting_Sp sol_Setting_Sp = new Sol_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);
                Sol_Setting sol_Setting = sol_Setting_Sp.Select("RBillVersion");
                if (sol_Setting != null)
                    int.TryParse(sol_Setting.SetValue.ToString(), out rBillVersion);

                CrystalDecisions.CrystalReports.Engine.ReportDocument rp;

                string logoFilename = string.Empty;
                if (rBillVersion == 0)
                {
                    rp = new Solum.Reports.StraightBillOfLading2();
                    logoFilename = "ABCRC_Logo_Blk.tif";
                }
                else
                {
                    rp = new Solum.Reports.StraightBillOfLadingUnits();
                    logoFilename = "abcrcLogo.jpg";
                }

                int intNumber = 0;
                string vendorId = string.Format("{0:d4}", Main.Sol_ControlInfo.VendorID);
                Int32.TryParse(rBillNumber, out intNumber);
                rBillNumber = string.Format("{0:d6}", intNumber);

                #region barcode

                string imagePath = String.Empty;
                string strBarcode = rBillNumber;
                if (//rBillVersion == 0           //dozen
                    //&& 
                    Main.Sol_ControlInfo.RBillNumberBarcode)
                {
                    //parse it
                    if (strBarcode.Length < 7)
                    {
                        strBarcode = vendorId + rBillNumber;
                    }

                    //generate barcode
                    imagePath = Main.temFolder + "\\barCodeRBill.bmp";
                    string errorMessage = string.Empty;
                    SolFunctions.GenerateBarcode(
                                Properties.Settings.Default.BarcodeEncoding
                                , Properties.Settings.Default.BarcodeWidth
                                , Properties.Settings.Default.BarcodeHeight
                                , BarcodeLib.AlignmentPositions.CENTER
                                , System.Drawing.RotateFlipType.RotateNoneFlipNone
                                , BarcodeLib.LabelPositions.BOTTOMCENTER
                                , strBarcode
                                , imagePath
                                , BarcodeLib.SaveTypes.BMP
                                , null
                                , ref errorMessage
                                );


                }

                #endregion

                DateTime dt = Main.rc.FechaActual; // ;
                DateTime.TryParse(rBillDate, out dt);

                //string logoPath = Main.appFolder + "\\Resources\\ABCRC_Logo_Blk.tif";  //@"D:\Mis Proyectos\Visual C#\Kevin\imagenes\ABCRC_Logo_Blk.tif";
                //string logoPath = Main.temFolder + "\\" + logoFilename;  //@"D:\Mis Proyectos\Visual C#\Kevin\imagenes\ABCRC_Logo_Blk.tif";
                string logoPath = Main.appFolder + "\\Resources\\" + logoFilename;  //@"D:\Mis Proyectos\Visual C#\Kevin\imagenes\ABCRC_Logo_Blk.tif";

                object[,] parametros = new object[,] {
                { "imagenPath", imagePath },
                { "Carrier", carrier },
                { "TrailerNumber", trailerNumber },
                { "ProBillNumber", proBillNumber },
                { "VendorId", vendorId },
                { "RBillNumber", rBillNumber },

                { "DepotName", Main.Sol_ControlInfo.BusinessName },
                { "DepotAddress", Main.Sol_ControlInfo.Address },
                { "DepotCity", Main.Sol_ControlInfo.City },
                { "DepotProvince", Main.Sol_ControlInfo.State },
                { "Date", rBillDate },
                { "LogoPath", logoPath },

                {"", ""}
            };



                bool imprimirReporte = false;
                bool exportarReporte = false;
                short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
                bool preverReporte = false;
                short numeroDeCopias = 1;
                if (Properties.Settings.Default.SettingsWsReportPrintPreview)
                    preverReporte = true;
                else
                    imprimirReporte = true;

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
                    dsBol2,
                    String.Empty,
                    true,
                    true
                );
                f1.WindowState = FormWindowState.Maximized;
                f1.ShowDialog();
                f1.Dispose();
                f1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GenerateDataSetBol2(int shipmentId, string rBillNumber)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Sol_Reports_RBILL", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ShipmentID", shipmentId));

                    connection.Open();

                    decimal ExtraContainerDozens = 0, EmptyContainerDonzens = 0;

                    int nreg = 1, nregs = 19,
                        ExtraContainerWhiteBags = 0,
                        ExtraContainerBluBags = 0,
                        ExtraContainerOneWayBags = 0,
                        ExtraContainerABCRCPallets = 0,

                        EmptyContainerWhiteBags = 0,
                        EmptyContainerBluBags = 0,
                        EmptyContainerOneWayBags = 0,
                        EmptyContainerABCRCPallets = 0,
                        ExtraContainerUnits = 0,
                        EmptyContainerUnits = 0;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dsBol2 = new DataSetBol2();

                        while (reader.Read())
                        {
                            //DataRow drBol2 = CreateNewRowDataSetBol2();
                            DataRow drBol2 = dsBol2.Tables[0].NewRow();

                            drBol2["rBillNumber"] = nreg.ToString();
                            nreg++;

                            drBol2["ProName"] = (string)reader["ProName"];
                            string productCode = (string)reader["ProCode"];
                            drBol2["ProCode"] = productCode;
                            drBol2["Dozens"] = (decimal)reader["Dozens"];

                            drBol2["Units"] = (int)reader["Units"];

                            //read containers
                            int whiteBags = 0,
                            blueBags = 0,
                            oneWayBags = 0,
                            aBCRCPallets = 0;

                            if (Main.Sol_ControlInfo.WhiteBagID >= 0)
                                readContainerInfo2(shipmentId, productCode, Main.Sol_ControlInfo.WhiteBagID, out whiteBags);
                            drBol2["WhiteBags"] = whiteBags;

                            if (Main.Sol_ControlInfo.BlueBagID >= 0)
                                readContainerInfo2(shipmentId, productCode, Main.Sol_ControlInfo.BlueBagID, out blueBags);
                            drBol2["BluBags"] = blueBags;

                            if (Main.Sol_ControlInfo.OneWayBagID >= 0)
                                readContainerInfo2(shipmentId, productCode, Main.Sol_ControlInfo.OneWayBagID, out oneWayBags);
                            drBol2["OneWayBags"] = oneWayBags;

                            if (Main.Sol_ControlInfo.ABCRCPalletsID >= 0)
                                readContainerInfo2(shipmentId, productCode, Main.Sol_ControlInfo.ABCRCPalletsID, out aBCRCPallets);
                            drBol2["ABCRCPallets"] = aBCRCPallets;

                            ExtraContainerDozens = 0;  // (int)reader["ExtraContainerDozens"];
                            ExtraContainerWhiteBags = (int)reader["ExtraContainerWhiteBags"];
                            ExtraContainerBluBags = (int)reader["ExtraContainerBluBags"];
                            ExtraContainerOneWayBags = (int)reader["ExtraContainerOneWayBags"];
                            ExtraContainerABCRCPallets = (int)reader["ExtraContainerABCRCPallets"];
                            EmptyContainerDonzens = 0;  // (int)reader["EmptyContainerDozens"];
                            EmptyContainerWhiteBags = (int)reader["EmptyContainerWhiteBags"];
                            EmptyContainerBluBags = (int)reader["EmptyContainerBluBags"];
                            EmptyContainerOneWayBags = (int)reader["EmptyContainerOneWayBags"];
                            EmptyContainerABCRCPallets = (int)reader["EmptyContainerABCRCPallets"];
                            ExtraContainerUnits = 0;  // (int)reader["ExtraContainerDozens"];
                            EmptyContainerUnits = 0;  // (int)reader["EmptyContainerDozens"];

                            drBol2["ExtraContainerDozens"] = ExtraContainerDozens;
                            drBol2["ExtraContainerWhiteBags"] = ExtraContainerWhiteBags;
                            drBol2["ExtraContainerBluBags"] = ExtraContainerBluBags;
                            drBol2["ExtraContainerOneWayBags"] = ExtraContainerOneWayBags;
                            drBol2["ExtraContainerABCRCPallets"] = ExtraContainerABCRCPallets;
                            drBol2["EmptyContainerDozens"] = EmptyContainerDonzens;
                            drBol2["EmptyContainerWhiteBags"] = EmptyContainerWhiteBags;
                            drBol2["EmptyContainerBluBags"] = EmptyContainerBluBags;
                            drBol2["EmptyContainerOneWayBags"] = EmptyContainerOneWayBags;
                            drBol2["EmptyContainerABCRCPallets"] = EmptyContainerABCRCPallets;

                            drBol2["ExtraContainerUnits"] = ExtraContainerUnits;
                            drBol2["EmptyContainerUnits"] = EmptyContainerUnits;

                            dsBol2.Tables[0].Rows.Add(drBol2);

                        }
                        reader.Close();
                    }

                    while (nreg <= nregs)
                    {

                        DataRow drBol2 = CreateNewRowDataSetBol2();
                        drBol2["rBillNumber"] = nreg.ToString();
                        //drBoL["ProName"] = nreg.ToString();
                        drBol2["ProName"] = string.Empty;
                        drBol2["ProCode"] = string.Empty;
                        drBol2["Dozens"] = 0;
                        drBol2["WhiteBags"] = 0;
                        drBol2["BluBags"] = 0;
                        drBol2["OneWayBags"] = 0;
                        drBol2["ABCRCPallets"] = 0;
                        drBol2["Units"] = 0;

                        drBol2["ExtraContainerDozens"] = ExtraContainerDozens;
                        drBol2["ExtraContainerWhiteBags"] = ExtraContainerWhiteBags;
                        drBol2["ExtraContainerBluBags"] = ExtraContainerBluBags;
                        drBol2["ExtraContainerOneWayBags"] = ExtraContainerOneWayBags;
                        drBol2["ExtraContainerABCRCPallets"] = ExtraContainerABCRCPallets;
                        drBol2["EmptyContainerDozens"] = EmptyContainerDonzens;
                        drBol2["EmptyContainerWhiteBags"] = EmptyContainerWhiteBags;
                        drBol2["EmptyContainerBluBags"] = EmptyContainerBluBags;
                        drBol2["EmptyContainerOneWayBags"] = EmptyContainerOneWayBags;
                        drBol2["EmptyContainerABCRCPallets"] = EmptyContainerABCRCPallets;

                        drBol2["ExtraContainerUnits"] = ExtraContainerUnits;
                        drBol2["EmptyContainerUnits"] = EmptyContainerUnits;

                        nreg++;
                        dsBol2.Tables[0].Rows.Add(drBol2);
                    }


                    //foreach (DataRow dr in dsBol2.Tables[0].Rows)
                    //{
                    //    string c = dr["rBillNumber"].ToString();
                    //}

                }
            }
        }

        public static void readContainerInfo2(int shipmentID, string productCode, int containerID, out int containerCount)
        {
            containerCount = 0;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentID),
                new SqlParameter("@ProductCode", productCode),
                new SqlParameter("@ContainerID", containerID)
            };
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(Properties.Settings.Default.WsirDbConnectionString, CommandType.StoredProcedure, "sol_Reports_BOL_Containers", parameters))
            {
                if (dataReader.Read())
                {
                    containerCount = SqlClientUtility.GetInt32(dataReader, "ContainerCount", 0);

                }
            }

        }

        private void toolStripButtonMultiProductStaging_Click(object sender, EventArgs e)
        {
            ShippingForm = 6;   //MultiProductStagedContainers
            Close();

        }


        #endregion

        #region Encorp

        public static string SaveManifest(
            Sol_Shipment sol_Shipment
            , Sol_Agencie sol_Agency
            , string computerName
            , DateTime date
            , string versionNumber
            )
        {

            try
            {
                //filename: manifest number + depotcode + .ma
                string fileName = sol_Shipment.ShipmentID.ToString("000000") + sol_Agency.VendorID + ".ma";
                string textFile = Path.Combine(Main.localUserAppDataPath, fileName);

                //string path = @"c:\temp\MyTest.txt";
                //if (File.Exists(textFile))
                //{
                //File.Delete(textFile);
                //}

                int totalRecords = 0, totalContainers = 0;

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(textFile))
                {
                    sw.WriteLine("BEGINHEADER");
                        sw.WriteLine("#");
                        sw.WriteLine("#"+sol_Agency.Name + " MA File");
                        sw.WriteLine("#");
                        sw.WriteLine("Version = 1.0");
                        sw.WriteLine("MachineName = " + computerName);
                        sw.WriteLine(string.Format("GenerationDate = {0}-{1:00}-{2:00} ", date.Year, date.Month, date.Day));
                        sw.WriteLine(string.Format("GenerationTime = {0:00}:{1:00}:{2:00} ", date.Hour, date.Minute, date.Second));
                        sw.WriteLine("WasManifestAdjusted = false");
                        sw.WriteLine("PORVersion = " + versionNumber);
                        sw.WriteLine("DBSize = 0 MB");
                    sw.WriteLine("ENDHEADER");

                    sw.WriteLine("#--- Containers On: BACKOFFICE ---");
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("sol_Stage_SelectProductsByShipmentID", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("@ShipmentID", sol_Shipment.ShipmentID));
                            connection.Open();
                            string ShippedDate = string.Format("{0}-{1:00}-{2:00}"
                                , sol_Shipment.ShippedDate.Year, sol_Shipment.ShippedDate.Month, sol_Shipment.ShippedDate.Day);
                            string ShippedTime = string.Format("{0:00}:{1:00}:{2:00}"
                                , sol_Shipment.ShippedDate.Hour, sol_Shipment.ShippedDate.Minute, sol_Shipment.ShippedDate.Second);
                            string bagTag = string.Empty;
                            string bagOpenDate = string.Empty;
                            string bagClosedDate = string.Empty;
                            string detail = string.Empty;


                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    totalRecords++;

                                    DateTime dt = (DateTime)reader["Date"];
                                    string dateBagCreated = string.Format("{0}{1:00}{2:00}"
                                        , dt.Year, dt.Month, dt.Day);
                                    string comodityCode = (string)reader["ProDescription"];
                                    int bagID = (int)reader["BagID"];
                                    bagTag = string.Format("{0:000000}{1}{2}{3}{4}"
                                        , sol_Agency.VendorID
                                        , "100"
                                        , dateBagCreated
                                        , comodityCode
                                        , bagID
                                        );

                                    dateBagCreated = string.Format("{0}-{1:00}-{2:00}"
                                    , dt.Year, dt.Month, dt.Day);

                                    dt = (DateTime)reader["DateClosed"];
                                    string dateBagClosed = string.Format("{0}-{1:00}-{2:00}"
                                        , dt.Year, dt.Month, dt.Day);

                                    detail = string.Format(
                                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}"
                                        , sol_Agency.VendorID
                                        , sol_Shipment.ShipmentID.ToString("000000")
                                        , ShippedDate
                                        , ShippedTime
                                        , bagTag
                                        , bagID
                                        , dateBagCreated
                                        , dateBagClosed
                                        , comodityCode
                                        , (string)reader["ProductCode"]
                                        , (int)reader["Quantity"]
                                        , ((decimal)reader["Weight"]).ToString("#,##0.0000")
                                        );

                                    sw.WriteLine(detail);

                                }
                            }
                        }
                    }


                    sw.WriteLine("#--------------------------------------------------------");

                    sw.WriteLine("BEGINFOOTER");
                        sw.WriteLine("TotalRecords = " + totalRecords.ToString());
                        sw.WriteLine("TotalShippingContainers = " + totalContainers.ToString());
                    sw.WriteLine("ENDFOOTER");

                }


                //}

                // Open the file to read from.
                /********************************************/
                //quitar (comment)
                /********************************************/
                //StringBuilder sb = new StringBuilder();
                //using (StreamReader sr = File.OpenText(textFile))
                //{
                //    string s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        //Console.WriteLine(s);
                //        sb.AppendLine(s);
                //    }
                //    return sb.ToString();
                //}
                /********************************************/

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return string.Empty;
        }

        #region Encorp BOL

        public static void UpdateDataSetEncorpBol(int shipmentId, string textBoxRBillNumber)
        {
            GenerateDataSetEncorpBol(shipmentId, textBoxRBillNumber);
        }

        public static void GenerateDataSetEncorpBol(int shipmentId, string rBillNumber)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Sol_Reports_EncorpBol", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ShipmentID", shipmentId));

                    connection.Open();

                    int nreg = 1, nregs = 22;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dsEncorpBol = new DataSetEncorpBol();

                        while (reader.Read())
                        {
                            //DataRow drBol2 = CreateNewRowDataSetBol2();
                            DataRow drEncorpBol = dsEncorpBol.Tables[0].NewRow();

                            drEncorpBol["ID"] = nreg;   //.ToString();
                            nreg++;

                            drEncorpBol["ProductID"] = (int)reader["ProductID"];

                            drEncorpBol["ProName"] = (string)reader["ProName"];
                            string productCode = (string)reader["ProCode"];
                            drEncorpBol["ProCode"] = productCode;
                            drEncorpBol["Quantity"] = (int)reader["Quantity"];

                            drEncorpBol["MasterProductDescription"] = (string)reader["MasterProductDescription"];

                            drEncorpBol["rBillNumber"] = (string)reader["rBillNumber"];

                            
                            //read containers
                            int Bags = 0;

                            readContainerInfo2(shipmentId, productCode, 0, out Bags);
                            drEncorpBol["Bags"] = Bags;

                            dsEncorpBol.Tables[0].Rows.Add(drEncorpBol);


                        }
                        reader.Close();
                    }

                    while (nreg <= nregs)
                    {

                        DataRow drEncorpBol = CreateNewRowDataSetEncorpBol();
                        drEncorpBol["ID"] = nreg;   //.ToString();

                        //drEncorpBol["ProductID"] = 0;
                        //drEncorpBol["ProName"] = string.Empty;
                        //drEncorpBol["ProCode"] = string.Empty;
                        //drEncorpBol["Quantity"] = 0;
                        //drEncorpBol["Bags"] = 0;
                        //drEncorpBol["MasterProductDescription"] = string.Empty;
                        //drEncorpBol["rBillNumber"] = string.Empty;

                        nreg++;
                        dsEncorpBol.Tables[0].Rows.Add(drEncorpBol);
                    }


                    //foreach (DataRow dr in dsBol2.Tables[0].Rows)
                    //{
                    //    string c = dr["rBillNumber"].ToString();
                    //}

                }
            }
        }

        private static DataRow CreateNewRowDataSetEncorpBol()
        {
            //dsBol2 = new DataSetBol2();


            DataRow drBoL = dsEncorpBol.Tables[0].NewRow();

            drBoL["ProductID"] = 0;
            drBoL["ProCode"] = string.Empty;
            drBoL["ProName"] = string.Empty;
            drBoL["Bags"] = 0;
            drBoL["Quantity"] = 0;
            drBoL["MasterProductDescription"] = string.Empty;
            drBoL["rBillNumber"] = string.Empty;

            return drBoL;

        }

        public static void PrintEncorpBol(
            int shipmentId
            , string rBillNumber
            , string rBillDate
            , string carrier
            , string trailerNumber
            , string proBillNumber
            , DataSet dataSet
           )
        {

            try
            {

                //query
                string query = "";
                //query 2
                string query2 = "";
                string subReportName2 = "";
                //query 3
                string query3 = "";
                string subReportName3 = "";


                CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new Solum.Reports.EncorpBol();

                int intNumber = 0;
                string vendorId = string.Format("{0:d4}", Main.Sol_ControlInfo.VendorID);
                Int32.TryParse(rBillNumber, out intNumber);
                rBillNumber = string.Format("{0:d6}", intNumber);

                string imagePath = String.Empty;
                string strBarcode = rBillNumber;
                if (Main.Sol_ControlInfo.RBillNumberBarcode)
                {

                    //parse it
                    if (strBarcode.Length < 7)
                    {
                        strBarcode = vendorId + rBillNumber;
                    }

                    //generate barcode
                    //SirLib.BarCodeCtrl userControl11 = new SirLib.BarCodeCtrl();

                    //userControl11.BarCode = strBarcode;

                    //userControl11.BarCodeHeight = 70;
                    //userControl11.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //userControl11.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                    ////userControl11.HeaderFont = new System.Drawing.Font("Comic Sans MS", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ////userControl11.HeaderText = "";
                    ////userControl11.LeftMargin = 5;   // 10;
                    ////userControl11.Location = new System.Drawing.Point(1,1); //10, 9);
                    //userControl11.Name = "userControl11";
                    //userControl11.ShowFooter = true;
                    //userControl11.ShowHeader = false;   // true;
                    //userControl11.Size = new System.Drawing.Size(400, 100); //340, 83);
                    //userControl11.TabIndex = 0;
                    //userControl11.TopMargin = 5;
                    //userControl11.VertAlign = BarCodeCtrl.AlignType.Center;
                    //userControl11.Weight = BarCodeCtrl.BarCodeWeight.Medium;
                    //imagePath = Main.temFolder + "\\barCodeRBill.bmp";  //Barcodes\\
                    //try
                    //{
                    //    userControl11.SaveImage(imagePath);
                    //    userControl11.Dispose();
                    //}
                    //catch (Exception e)
                    //{
                    //    CajaDeMensaje.Show("CashierCash", "Error trying to save the RBill number barcode image", e.Message, CajaDeMensajeImagen.Error);
                    //    imagePath = String.Empty;
                    //}

                    imagePath = Main.temFolder + "\\barCodeRBill.bmp";
                    string errorMessage = string.Empty;
                    SolFunctions.GenerateBarcode(
                                Properties.Settings.Default.BarcodeEncoding
                                , Properties.Settings.Default.BarcodeWidth
                                , Properties.Settings.Default.BarcodeHeight
                                , BarcodeLib.AlignmentPositions.CENTER
                                , System.Drawing.RotateFlipType.RotateNoneFlipNone
                                , BarcodeLib.LabelPositions.BOTTOMCENTER
                                , strBarcode
                                , imagePath
                                , BarcodeLib.SaveTypes.BMP
                                , null
                                , ref errorMessage
                                );


                }

                DateTime dt = Main.rc.FechaActual; // ;
                DateTime.TryParse(rBillDate, out dt);


                ////string logoPath = Main.appFolder + "\\Resources\\ABCRC_Logo_Blk.tif";  //@"D:\Mis Proyectos\Visual C#\Kevin\imagenes\ABCRC_Logo_Blk.tif";
                //string logoPath = Main.temFolder + "\\ABCRC_Logo_Blk.tif";  //@"D:\Mis Proyectos\Visual C#\Kevin\imagenes\ABCRC_Logo_Blk.tif";
                
                string logoPath = Main.localUserAppDataPath + "\\logo_encorp.png";

                object[,] parametros = new object[,] {
                //{ "imagenPath", imagePath },
                //{ "Carrier", carrier },
                //{ "TrailerNumber", trailerNumber },
                //{ "ProBillNumber", proBillNumber },
                //{ "VendorId", vendorId },
                //{ "RBillNumber", rBillNumber },

                //{ "DepotName", Main.Sol_ControlInfo.BusinessName },
                //{ "DepotAddress", Main.Sol_ControlInfo.Address },
                //{ "DepotCity", Main.Sol_ControlInfo.City },
                //{ "DepotProvince", Main.Sol_ControlInfo.State },
                //{ "Date", rBillDate },

                { "LogoPath", logoPath },
                { "Agency_Name", "ENCORP PACIFIC (CANADA)" },
                { "Agency_Address", "206 - 2250 Boundary Road" },
                { "Agency_City", "Bumaby" },
                { "Agency_Province", "BC" },
                { "Agency_Phone", "604.473.2400" },
                { "Agency_PhoneFree", "1.800.330.9767" },
                { "Agency_Fax", "604.473.2411" },
                { "ManifestNumber", rBillNumber },

                {"", ""}
            };



                bool imprimirReporte = false;
                bool exportarReporte = false;
                short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
                bool preverReporte = false;
                short numeroDeCopias = 1;
                if (Properties.Settings.Default.SettingsWsReportPrintPreview)
                    preverReporte = true;
                else
                    imprimirReporte = true;

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
                    dataSet,
                    String.Empty,
                    true,
                    true
                );
                f1.ShowDialog();
                f1.Dispose();
                f1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #endregion


        private void ButtonEnabledChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = button.Enabled;
        }

    }
}
