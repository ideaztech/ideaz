
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
using System.Reflection;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Security.Principal;
using System.Configuration;
using System.Collections;
using System.Threading;
using System.Globalization;
using System.Net.Mail;

using System.Deployment;
using System.Deployment.Application;

//using System.Drawing.Image;
using System.Drawing.Printing;

using SAS.SASClient.Forms;
using SAS.SASClient.UIHelper;
using SAS.SASClient.ClientStorage;
using Client;

using System.IO;
using System.Diagnostics;

using System.Runtime.InteropServices;
using System.Net;

// it's required for reading/writing into the registry:
using Microsoft.Win32;
using System.Collections.Specialized;

//UsbHid 
using Microsoft.Win32.SafeHandles;
using Microsoft.VisualBasic;
using System.Timers;
using SirLib.Hid;

using System.Net.Http;
using System.Net.Http.Headers;
using Solum.App_Code;


namespace Solum
{
    public partial class Main : Form
    {

        #region UsbHid Variables
        public static string strMsrCardNumber;
        public static string strMsrMessage;
        //private IntPtr fmh;
        //private string resultMessage;

        private string txtInputReportBufferSize;
        private IntPtr deviceNotificationHandle;
        //private Boolean exclusiveAccess;
        private FileStream fileStreamDeviceData;
        private SafeFileHandle hidHandle;
        private String hidUsage;
        public static Boolean myDeviceDetected;
        private String myDevicePathName;
        private Boolean transferInProgress = false;

        private Debugging MyDebugging = new Debugging(); //  For viewing results of API calls via Debug.Write.
        private DeviceManagement MyDeviceManagement = new DeviceManagement();
        private Hid MyHid = new Hid();
        //private static System.Timers.Timer //tmrReadTimeout;
        private static System.Timers.Timer tmrContinuousDataCollect;

        internal Main FrmMy;

        //  This delegate has the same parameters as AccessForm.
        //  Used in accessing the application's form from a different thread.

        private delegate void MarshalToForm(String action, String textToAdd);

        #endregion

        #region Main Variables

        public static bool Attendance_Enabled = false;

        public static int ConveyorId = 0;
        Sol_WorkStation_Sp sol_WorkStation_Sp;
        Sol_WorkStation sol_WorkStation;
        
        public enum ModesAvailables
        {
            DEPOT,
            OFF_LINE
        }
        //*******************************************
        public static bool EnableModes = false;      //has to be false on updates until is ready, then remove it
        
        //http://stackoverflow.com/questions/6310908/installer-wont-overwrite-existing-app

        public const string versionNumber="2.4.0";

        //also change file version in AssemblyInfo
        //and in properties of SolumSetup
        //and if local settings are change or a dll, change Assembly version aswell

        //*******************************************

        public static string usbReadEventForm = "";

        Qds_Setting qds_Setting;
        Qds_Setting_Sp qds_Setting_Sp;

        public static int SqlTimeout;

        public static string QuickDrop_DepotID;
        public static bool QuickDrop_CardReader_Enabled;
        public static byte QuickDrop_CardReader_EmulationMode;
        public static int QuickDrop_CardReader_VID;
        public static int QuickDrop_CardReader_PID;
        public static int QuickDrop_CardReader_CharSeparator;

        Sol_Setting sol_Setting;
        Sol_Setting_Sp sol_Setting_Sp;

        public static string SecurityCodeSeparator = string.Empty;

        public static bool CardReader_Enabled;
        public static byte CardReader_EmulationMode;
        public static int CardReader_VID;
        public static int CardReader_PID;
        public static int CardReader_CharSeparator;

        public static bool CardReader_CloseOrder;
        public static byte CardReader_LinkMethod;

        public static string Business_PostalCode;

        public static int CategoryButtons_SnapToGridWidth;
        public static int CategoryButtons_SnapToGridHeight;

        public static BindingList<Country> countries;

        public static string clientId;

        //public static BindingList<BillsAndCoinsByCountry> billsAndCoinsByCountry;

        public static RelojCalendario rc;

        public static string[] crisCodes;
        public static string[] dataSetContainersName;

        Sol_EmployeesLog_Sp sol_EmployeesLog_Sp;
        Sol_Employee_Sp sol_Employee_Sp;

        public static System.Windows.Forms.Timer timerBlink;
        public static ToolStripLabel tslCntr;
        private static int intCntr = 0;

        public static string appFolder = "";
        public static string temFolder = "";
        public static string localUserAppDataPath = "";
        public static string myDocuments = "";

        public static ImageList bImageList1;
        public static ImageList bImageList2;
        public static ImageList bImageList3;
        
        public static ImageList bImageList4;

        public static int timerIntervalRefresment = 10000;
        
        //*******************************************
        //Actualizar cada vez que cambie la 
        //estructura de la base de datos

        //en la clase Main
        //*******************************************
        public const decimal DatabaseVersion = 3.008m; //2.146, 2.133m
        //*******************************************

        public static BindingList<SupplyInventoryType> supplyInventoryTypes;
        public static BindingList<EntriesType> entriesType;

        //private bool //sasActivated = false,
            //sasUserRegistered = false,
            //sasExpiredTrial = false;

        public static CustomerScreen CustomerScreenForm = null;

        public static BindingList<OrderStatus> returnOrderStatusType;

        public static BindingList<ProductType> productsType;

        public static BindingList<CashDenominationsType> cashDenominationsType;
        public static string myHostName;
        public static System.Diagnostics.Process _pVirtualKb = null;
        public static Sol_Control Sol_ControlInfo;

        //Pos podDlg;
        //public string stringDeConexion = "";
        public static bool IsAuthenticated = false;

        public static BindingList<SirLib.MesesNombre> mesesNombre;

        public static bool EnableBottleDrop = false;
        public string BottleDropAuthorizationToken { get; set; } = String.Empty;

        public static Main MainForm = null;

        BottleDropJsonHandler bdJsonHandler;
        public BottleDropJsonHandler BDJsonHandler
        {
            get
            {
                if (bdJsonHandler == null)
                {
                    bdJsonHandler = new BottleDropJsonHandler();
                }
                return bdJsonHandler;
            }
        }

        #endregion

        #region Main Methods

        public Main() //: base()
        {

            InitializeComponent();
            //toolStripMain.Renderer = new MyRenderer();
            // toolStripUpperRight.Renderer = new MyRenderer();
            toolStripMain.Renderer = new App_Code.NewToolStripRenderer();
            toolStripUpperRight.Renderer = new App_Code.NewToolStripRenderer();
            toolStripMain.DefaultDropDownDirection = ToolStripDropDownDirection.AboveRight;
        }

        //private void Returns_Closed(object sender, FormClosedEventArgs e)

        private void Main_Closed(System.Object eventSender, System.EventArgs eventArgs)
        {
            //try
            //{

            //for usb hid
            if (Main.CardReader_Enabled)
            {
                if (Main.CardReader_EmulationMode == 0)    //HID
                {
                    Shutdown();
                }
            }

            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            MainForm = this;
            this.Icon = Properties.Resources.Solum1;

            clientId = Funciones.CreateUniqueMachineID();

            //use for Straight BOL ABCRC Agency
            crisCodes = new string[22]
            {
                "1006",
                "4006",
                "4003",
                "4303",
                "3006",
                "3003",
                "6006",
                "6003",
                "5006",
                "5003",
                "4606",
                "4603",
                "7006",
                "4023",
                "2006",
                "2003",
                "8001",
                "3501",
                "7008",
                "9999",
                "ExtraContainer",
                "EmptyContainer"
            };

            dataSetContainersName = new string[4] 
            {
                "WhiteBags",
                "BluBags",
                "OneWayBags",
                "ABCRCPallets"
            };

            //make the image list public
            /*
            buttonsImageList1 = imageList1;
            buttonsImageList1.ImageSize = new Size(CategoryButtons.categoryButtonWidth, CategoryButtons.categoryButtonHeight);  //96, 66);

           buttonsImageList2 = imageList2;
            buttonsImageList2.ImageSize = new Size(CategoryButtons.categoryButtonWidth * 2, CategoryButtons.categoryButtonHeight);  //192, 66);
           buttonsImageList3 = imageList3;
           buttonsImageList3.ImageSize = new Size(CategoryButtons.categoryButtonWidth, CategoryButtons.categoryButtonHeight * 2);  //96, 132);
            buttonsImageList4 = imageList4;
            buttonsImageList4.ImageSize = new Size(CategoryButtons.categoryButtonWidth * 2, CategoryButtons.categoryButtonHeight * 2);  //192, 132);
            */

            bImageList1 = buttonImageList1;
            bImageList1.ImageSize = new Size(CategoryButtons.categoryButtonWidth, CategoryButtons.categoryButtonHeight);  //96, 66);

            bImageList2 = buttonImageList2;
            bImageList2.ImageSize = new Size(CategoryButtons.categoryButtonWidth * 2, CategoryButtons.categoryButtonHeight);  //192, 66);
            bImageList3 = buttonImageList3;
            bImageList3.ImageSize = new Size(CategoryButtons.categoryButtonWidth, CategoryButtons.categoryButtonHeight * 2);  //96, 132);
            bImageList4 = buttonImageList4;
            bImageList4.ImageSize = new Size(CategoryButtons.categoryButtonWidth * 2, CategoryButtons.categoryButtonHeight * 2);

            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripUpperRightButtonKeyBoard.Visible = true;
            }
            toolStripButtonUpperRightAttendance.Visible = Properties.Settings.Default.UseAttendance;
            //FullScreenMode

            
                this.FormBorderStyle = (Properties.Settings.Default.SettingsAdFullScreenMode)?FormBorderStyle.None: FormBorderStyle.Sizable;
                this.WindowState = (Properties.Settings.Default.SettingsAdFullScreenMode)?FormWindowState.Maximized:FormWindowState.Normal;
            
            //appFolder
            //running the deployed application
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                appFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            else
            {
                //formaPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Reportes\\";

                //appFolder = System.IO.Path.GetDirectoryName(Application.StartupPath);
                //appFolder = appFolder.Substring(0, appFolder.Length - 4);
                appFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            }

            //tempFolder
            temFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            localUserAppDataPath = System.IO.Path.GetDirectoryName(Application.LocalUserAppDataPath);
            myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //string x = string.Format("{0}\r\nCommonAppDataPath: {1}\r\nExecutablePath: {2}\r\nLocalUserAppDataPath: {3}\r\nStartupPath: {4}\r\nUserAppDataPath: {5}\r\n"
            //    , System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
            //    , System.IO.Path.GetDirectoryName(Application.CommonAppDataPath)
            //    , System.IO.Path.GetDirectoryName(Application.ExecutablePath)
            //    , System.IO.Path.GetDirectoryName(Application.LocalUserAppDataPath)
            //    , System.IO.Path.GetDirectoryName(Application.StartupPath)
            //    , System.IO.Path.GetDirectoryName(Application.UserAppDataPath)
            //    );
            //x += string.Format("{0}\r\nApplicationData: {1}\r\nCommonApplicationData: {2}\r\n"
            //    , System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
            //    , Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            //    , Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
            //    );
            

            //MessageBox.Show(x);

            //own date and time
            //Properties.Settings.Default.FechaActual = DateTime.Parse("2012-05-16 23:58:40");
            Properties.Settings.Default.FechaActual = DateTime.Now;
            DateTimePicker dtp = null;
            object lb1 = toolStripLabelDate;
            object lb2 = null;

            rc = new RelojCalendario(Properties.Settings.Default.FechaActual, "Short", "", ref dtp, ref lb1, ref lb2,
                "", "local");

            //quitar - comentar en produccion
            //rc.HabilitarTimer(false); // false = off 
            

            //Countries
            countries = new BindingList<Country>();
            countries.Clear();
            countries.Add(new Country("CA", "Canada"));
            countries.Add(new Country("US", "United State"));
            countries.Add(new Country("MX", "Mexico"));

            //SupplyInventoryType
            supplyInventoryTypes = new BindingList<SupplyInventoryType>();
            supplyInventoryTypes.Clear();
            supplyInventoryTypes.Add(new SupplyInventoryType("O", "Order"));
            supplyInventoryTypes.Add(new SupplyInventoryType("R", "Received Order"));
            supplyInventoryTypes.Add(new SupplyInventoryType("A", "Adjustment"));
            supplyInventoryTypes.Add(new SupplyInventoryType("S", "Shipped"));

            //entriesType
            entriesType = new BindingList<EntriesType>();
            entriesType.Clear();
            entriesType.Add(new EntriesType("O", "Open Cashier"));
            entriesType.Add(new EntriesType("F", "Float"));
            entriesType.Add(new EntriesType("C", "Close Cashier"));
            entriesType.Add(new EntriesType("E", "Expenses"));

            //ProductType
            productsType = new BindingList<ProductType>();
            productsType.Clear();
            productsType.Add(new ProductType(0, "Return"));
            productsType.Add(new ProductType(1, "Sale"));

            //DenominationsType
            cashDenominationsType = new BindingList<CashDenominationsType>();
            cashDenominationsType.Clear();
            cashDenominationsType.Add(new CashDenominationsType(0, "Coin"));
            cashDenominationsType.Add(new CashDenominationsType(1, "Bill"));
            cashDenominationsType.Add(new CashDenominationsType(2, "Rolls"));

            //returnOrderStatusType
            returnOrderStatusType = new BindingList<OrderStatus>();
            returnOrderStatusType.Clear();
            returnOrderStatusType.Add(new OrderStatus("A", "Normal"));
            returnOrderStatusType.Add(new OrderStatus("D", "Void"));
            returnOrderStatusType.Add(new OrderStatus("O", "OnAcc"));
            returnOrderStatusType.Add(new OrderStatus("P", "Paid"));
            returnOrderStatusType.Add(new OrderStatus("I", "InProc"));

            //
            myHostName = System.Net.Dns.GetHostName();
            //asign hostame for logs
            SirLib.ExcepcionesNoControladas.HostName = myHostName;

            //nombre de los meses
            mesesNombre = new BindingList<SirLib.MesesNombre>();

            LlenarDiccionarios();

            this.Show();
            //Properties.Settings.Default.FechaActual = DateTime.Now;
            //toolStripLabelDate.Text = Properties.Settings.Default.FechaActual.ToShortDateString();   // Vars.FechaActual.ToShortDateString();

            CultureInfo culture = CultureManager.ApplicationUICulture;
            //if (System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en")
            //this.Text = String.Format(this.Text, AssemblyTitle, AssemblyVersion);

            //versionNumber = AssemblyVersion.Remove(AssemblyVersion.Length - 2);
            this.Text = String.Format(this.Text, AssemblyTitle, versionNumber); //version);
            toolStripStatusLabelVersion.Text = "Version: " + versionNumber;

            //reiniciar variables de coneccion
            Properties.Settings.Default.SQLServidorConectado = false;
            //Properties.Settings.Default.UsuarioConectado = false;
            Properties.Settings.Default.UsuarioNombre = "";
            Properties.Settings.Default.UsuarioRol = "";
            Properties.Settings.Default.Save();

            //verificar nombre de la base de datos
            if (String.IsNullOrEmpty(Properties.Settings.Default.SQLBaseDeDatos.Trim()))
            {
                Properties.Settings.Default.SQLBaseDeDatos = "Solum";
                Properties.Settings.Default.Save();

            }

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Current employee", 256, HorizontalAlignment.Left);
            listView1.Columns.Add("Status", 75, HorizontalAlignment.Left);
            splitContainer1.Visible = true;

            //connect to server

            //check for modes inconsistency 
            if (!Properties.Settings.Default.ModesEnabled
                && Properties.Settings.Default.SQLServidorNombre == Properties.Settings.Default.ModesLocalDbServerName
                )
                Properties.Settings.Default.ModesEnabled = true;

            if (!ServerConnection(false))
                return;


            //read options if not Authenticated
            if (!IsAuthenticated)
            {
                string connectionString = Properties.Settings.Default.WsirDbConnectionString;
                if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
                    connectionString = connectionString.Replace("Solum", "Solum_Training");

                try
                {
                    Sol_Control_Sp sol_Control_Sp = new Sol_Control_Sp(connectionString);
                    if (sol_Control_Sp == null)
                    {
                        Main.Sol_ControlInfo = sol_Control_Sp.Select(1);
                        ReadNewSettings();
                    }
                }
                catch { }
            }


            //dateTime from sql server
            //if (IsAuthenticated && Sol_ControlInfo.SqlServerDate)
            //error without login ??? kevin
            SetDateFromServer();

            //clock
            try
            {
                this.timer2.Interval = 60000 * Main.Sol_ControlInfo.EmployeesListRefresh; //60000 = 1 minute
            }
            catch
            {
                this.timer2.Interval = 60000;
            }

            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            //simulate click (emulate click)
            EventArgs e1 = new EventArgs();
            timer2_Tick(timer2, e1);

            //web browser object
            try
            {
                Navigate(Main.Sol_ControlInfo.WebBrowserUrl);
            }
            catch { };

            //blinking timer
            tslCntr = toolStripStatusLabelTrainingMode;
            timerBlink = new System.Windows.Forms.Timer();  //this.components);
            timerBlink.Interval = 250;
            timerBlink.Tick += new System.EventHandler(timerBlink_Tick);

            //Training Database
            bool flag = Funciones.DatabaseExists(Properties.Settings.Default.WsirConnectionString, "Solum_Training");

            //validate training db existance
            if (!flag && toolStripStatusEmpresa.Text == "Solum_Training")
            {
                Properties.Settings.Default.SQLBaseDeDatos = "Solum";
                Properties.Settings.Default.Save();
                toolStripStatusEmpresa.Text = Properties.Settings.Default.SQLBaseDeDatos;
            }

            //toolStripMenuItemCreateTrainingDatabase.Visible = flag;
            if (toolStripStatusEmpresa.Text == "Solum")
            {
                toolStripMenuItemCreateTrainingDatabase.Visible = true;
                toolStripMenuItemUseTrainingMode.Visible = flag;
                toolStripStatusLabelTrainingMode.Visible = false;

            }
            else if (toolStripStatusEmpresa.Text == "Solum_Training" || Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripMenuItemCreateTrainingDatabase.Visible = false;
                toolStripMenuItemUseTrainingMode.Text = "&Back to Production Mode";
                toolStripStatusLabelTrainingMode.Visible = true;
                timerBlink.Enabled = true;

            }

            //computer roles
            CheckComputerRole();

            //computer wakes up
            SystemEvents.PowerModeChanged += OnPowerChange;

            //Check if Depot is a BottleDrop Partner
            try
            {
                EnableBottleDrop = BDJsonHandler.ConfirmCertifiedCountingLocation();
            }
            catch { }

            //for usb hid
            if (Main.CardReader_Enabled)
            {
                if (Main.CardReader_EmulationMode == 0)    //HID
                {
                    toolStripStatusLabelMsr.Visible = true;
                    toolStripStatusLabelMsrMessage.Visible = true;

                    FrmMy = this;
                    Startup();

                    tmrContinuousDataCollect.Enabled = true;
                    tmrContinuousDataCollect.Start();
                    ReadAndWriteToDevice();

                    if (myDeviceDetected)
                    {
                        toolStripStatusLabelMsrMessage.Text = "was found";
                        strMsrMessage = toolStripStatusLabelMsrMessage.Text;
                    }

                }
            }


            if (Sol_ControlInfo == null)
            {
                Sol_ControlInfo = new Sol_Control();
                Sol_ControlInfo.State = string.Empty;
            }

            if (Main.Sol_ControlInfo.State == "AB"
                && Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
            {
                toolStripButtonXpressReturn.Visible = true;

                toolStripMenuItemXpressReturn.Visible = true;
                //toolStripMenuItemXpressReturn.Visible = true;
            }

            //Register use of Solum
            if (sol_Setting_Sp == null)
                sol_Setting_Sp = new Sol_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //last registration date
            try
            {
                sol_Setting = sol_Setting_Sp.Select("Register_LastDate");
            }
            catch
            {
                MessageBox.Show("Please update this database.");
                Application.Exit();
                return;
            }
            DateTime dt = (DateTime)sol_Setting.SetValue;
            //dt = dt.AddDays(-1);
            if (dt.Date.Date < rc.FechaActual.Date)
            {
                this.timerRegister.Interval = 10*1000;  //10 * 10000;   //10 min
                this.timerRegister.Tick += new System.EventHandler(this.timerRegister_Tick);
                this.timerRegister.Enabled = true;
            }

            toolStripButtonSales.Visible = Properties.Settings.Default.UseSales;
            toolStripMenuItemSales.Visible = Properties.Settings.Default.UseSales;

            //set options for OFF_LINE mode
            SetOptionsForCurrentMode();

            //check default printers
            //

            //check ABCRC info
            flag = Sol_ControlInfo.State == "AB";
            //toolStripButtonXpressReturn.Visible = flag;
            //toolStripMenuItemXpressReturn.Visible = flag;
            //toolStripMenuItemXpressReturn.Visible = flag;

            //toolStripMenuItemQuickDrop.Visible = toolStripButtonQuickDrop.Visible;

            //sol_Setting = sol_Setting_Sp.Select("Attendance_Enabled");
            //if (!(bool)sol_Setting.SetValue)
            //{
            //    splitContainer1.Panel1Collapsed = true;
            //    toolStripButtonAttendance.Visible = false;
            //}


            //string hexacode = ColorTranslator.ToHtml(Color.Black).ToString();
            //webBrowser1.DocumentText = "<html><body style='background-color:" + hexacode + "'></body></html>";

            #region check reports (moved to 6-InitalData.sql)

            SirLib.wsir_Reportes_info ri;

            ri = SirLib.wsir_Reportes.Buscar(Properties.Settings.Default.WsirConnectionString, "CategoryRefundStatistics.rpt");

            if (ri == null || String.IsNullOrEmpty(ri.ReporteNombreEnMinusculas.Trim()))
            {
                //add reports
                try
                {
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "CategoryRefundStatistics.rpt", "Category Refund Statistics", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "ClerkReport.rpt", "Clerk Report", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "CorporateAccountStatement.rpt", "Customer Account Statement", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "DailyTotal.rpt", "Financial Transaction Summary", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "Inventory.rpt", "Inventory", "", false);
                    //wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "InventoryOnHandUnstaged.rpt", "Inventory On Hand", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "InventoryStatus.rpt", "Inventory Reconciliation", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "Orders1.rpt", "Orders", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "PurchasedInventory.rpt", "Purchased Inventory", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "PurchasingCategory.rpt", "Purchasing Category", "", false);
                    //wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "Refund.rpt", "Refund", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "Shipment.rpt", "Shipment Summary", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "ShipmentDetail.rpt", "Shipment Detail", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "StagedContainers.rpt", "Staged Containers", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "Staging.rpt", "Staging", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "TimeClock.rpt", "TimeClock", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "TransactionDuration.rpt", "Order Duration", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "TransactionReport.rpt", "Order Detail", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "TransactionSearch.rpt", "Order Search", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "TransactionSummary.rpt", "Order Summary", "", false);

                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "ShipmentValueCalculation.rpt", "Shipment Value Calculation", "", false);
                    wsir_Reportes.Agregar(Properties.Settings.Default.WsirConnectionString, "CRISSummary.rpt", "CRIS Summary", "", false);

                }
                catch
                {
                    //MessageBox.Show("Error adding reports, please notify the administrator.");
                    //return false;
                }
            }

            #endregion

        }

        private void SetOptionsForCurrentMode()
        {
            if (!(Properties.Settings.Default.ModesEnabled
                && Main.EnableModes))
            {
                toolStripMenuItemChangeMode.Visible = false;
                toolStripSeparatorChangeMode.Visible = false;

                toolStripStatusLabelCurrentModeTitle.Visible = false;
                toolStripStatusLabelCurrentMode.Visible = false;

                return;
            }


            bool flag = true;

            string sbd = Properties.Settings.Default.SQLBaseDeDatos;
            string lbd = Properties.Settings.Default.ModesLocalDbDatabaseName;
            //is in offline mode?
            if (Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName)
                flag = false;

            //MainMenu
            foreach (ToolStripMenuItem subItem in menuStripMain.Items)  //["toolStripMenuItemTools"])
            {
                if (subItem.Name == "toolStripMenuItemTools")
                {
                    ToolStripItemCollection dropDownItems = subItem.DropDownItems;

                    foreach (object o in dropDownItems)
                    {
                        if (o == null) continue;

                        if (o.GetType() == typeof(ToolStripSeparator))
                        {
                            ToolStripSeparator s = o as ToolStripSeparator;
                            if (s == null) continue;
                            s.Visible = flag;
                        }
                        else
                        {
                            ToolStripMenuItem mi = o as ToolStripMenuItem;
                            if (mi == null) continue;

                            if (Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName)
                                if(mi.Name == "toolStripMenuItemChangeMode")
                                    continue;

                            if (mi.Name == "toolStripMenuItemToolsExit")
                                continue;

                            mi.Visible = flag;
                        }

                        //MessageBox.Show(mi.Name);
                    }
                }
                else if (subItem.Name == "toolStripMenuItemPor"
                    || subItem.Name == "toolStripMenuItemAccounting"
                    || subItem.Name == "toolStripMenuItemReports"
                    )
                {
                    continue;
                }
                else
                    subItem.Visible = flag;

            }

            toolStripSeparatorCustomerScreen.Visible = flag;
            toolStripMenuItemCustomerScreen.Visible = flag;

            //toolStripMain
            foreach (ToolStripItem item in toolStripMain.Items)
            {
                switch (item.GetType().Name)
                {
                    case "ToolStripButton":
                        ToolStripButton b = (ToolStripButton)item;

                        if (b.Name == "toolStripButtonServer")
                            continue;

                        if (b.Name == "toolStripButtonReturns"
                            || b.Name == "toolStripButtonSales"
                            || b.Name == "toolStripButtonCashier"
                            || b.Name == "toolStripButtonExit"

                            )
                            continue;

                        if (b.Name == "toolStripButtonXpressReturn"
                            && !(Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
                            )
                            continue;
                        b.Visible = flag;
                        break;
                    //case "ToolStripSeparator":
                    //    ToolStripSeparator s = (ToolStripSeparator)item;

                    //    if (s.Name == "toolStripSeparatorQuickDrop"
                    //        && !(Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
                    //        )
                    //        continue;
                    //    s.Visible = flag;
                    //    break;
                }
            }

            //splitContainer1
            splitContainer1.Visible = flag;

            //toolStripMenuItemChangeMode.Visible = true;
            //toolStripSeparatorChangeMode.Visible = true;

            //toolStripStatusLabelCurrentModeTitle.Visible = flag;
            //toolStripStatusLabelCurrentMode.Visible = flag;

            if (Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName)
                toolStripStatusLabelCurrentMode.Text = Main.ModesAvailables.OFF_LINE.ToString();
            else
                toolStripStatusLabelCurrentMode.Text = Main.ModesAvailables.DEPOT.ToString();

            toolStripStatusEmpresa.Text = Properties.Settings.Default.SQLBaseDeDatos;

            toolStripStatusLabelServer.Text = Properties.Settings.Default.SQLServidorNombre;

        }

        private void OnPowerChange(object s, PowerModeChangedEventArgs e) 
        {
            switch ( e.Mode ) 
            {
                case PowerModes.Resume:
                    //MessageBox.Show("Hello sleepy head!");
                    SetDateFromServer();
                break;
                case PowerModes.Suspend:
                break;
            }
        }

        //dateTime from sql server
        private void SetDateFromServer()
        {
            //if (IsAuthenticated && Sol_ControlInfo.SqlServerDate)
            //error without login ??? kevin
            if (IsAuthenticated)
            {
                try
                {
                    if (Sol_ControlInfo.SqlServerDate)
                    {
                        DateTime fh;
                        if (Funciones.SqlLeerFecha(Properties.Settings.Default.WsirDbConnectionString, "GETDATE", out fh))
                        {
                            Properties.Settings.Default.FechaActual = fh;
                            rc.ConnectionString = Properties.Settings.Default.WsirDbConnectionString;
                            rc.SourceDate = "server";
                            rc.CambiarFecha(Properties.Settings.Default.FechaActual);
                        }
                    }
                }
                catch { }
            }

        }

        private void ReadNewSettings()
        {
            try
            {

                string cs = Properties.Settings.Default.WsirDbConnectionString;
                //leer opciones
                if (sol_Setting_Sp == null)
                    sol_Setting_Sp = new Sol_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);


                //sql server
                sol_Setting = sol_Setting_Sp.Select("SqlTimeout");
                if (sol_Setting == null)
                {
                    sol_Setting = new Sol_Setting();
                    sol_Setting.SetValue = (int)90;
                }
                SqlTimeout = (int)sol_Setting.SetValue;
                ChangeStringConnection(true);

                //security code separator
                sol_Setting = sol_Setting_Sp.Select("SecurityCodeSeparator");
                SecurityCodeSeparator = sol_Setting.SetValue.ToString();

                //cardreader
                sol_Setting = sol_Setting_Sp.Select("CardReader_Enabled");
                Main.CardReader_Enabled = (bool)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CardReader_EmulationMode");
                Main.CardReader_EmulationMode = (byte)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CardReader_VID");
                Main.CardReader_VID = (int)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CardReader_PID");
                Main.CardReader_PID = (int)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CardReader_CharSeparator");
                Main.CardReader_CharSeparator = (int)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CardReader_Enabled");
                Main.CardReader_Enabled = (bool)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CardReader_CloseOrder");
                Main.CardReader_CloseOrder = (bool)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CardReader_LinkMethod");
                Main.CardReader_LinkMethod = (byte)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("Business_PostalCode");
                Main.Business_PostalCode = sol_Setting.SetValue.ToString();

                sol_Setting = sol_Setting_Sp.Select("CategoryButtons_SnapToGridWidth");
                Main.CategoryButtons_SnapToGridWidth = (int)sol_Setting.SetValue;

                sol_Setting = sol_Setting_Sp.Select("CategoryButtons_SnapToGridHeight");
                Main.CategoryButtons_SnapToGridHeight = (int)sol_Setting.SetValue;


                sol_Setting = sol_Setting_Sp.Select("Attendance_Enabled");
                Attendance_Enabled = (bool)sol_Setting.SetValue;
                //splitContainer1.Panel1Collapsed = !Attendance_Enabled;
                //toolStripButtonAttendance.Visible = Attendance_Enabled;


                //QDS
                //leer opciones
                if (qds_Setting_Sp == null)
                    qds_Setting_Sp = new Qds_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);

                qds_Setting = qds_Setting_Sp.Select("QuickDrop_DepotID");   //123459
                Main.QuickDrop_DepotID = qds_Setting.SetValue.ToString();

                //cardreader for qds
                qds_Setting = qds_Setting_Sp.Select("CardReader_Enabled");
                Main.QuickDrop_CardReader_Enabled = (bool)qds_Setting.SetValue;

                qds_Setting = qds_Setting_Sp.Select("CardReader_EmulationMode");
                Main.QuickDrop_CardReader_EmulationMode = (byte)qds_Setting.SetValue;

                qds_Setting = qds_Setting_Sp.Select("CardReader_VID");
                Main.QuickDrop_CardReader_VID = (int)qds_Setting.SetValue;

                qds_Setting = qds_Setting_Sp.Select("CardReader_PID");
                Main.QuickDrop_CardReader_PID = (int)qds_Setting.SetValue;

                qds_Setting = qds_Setting_Sp.Select("CardReader_CharSeparator");
                Main.QuickDrop_CardReader_CharSeparator = (int)qds_Setting.SetValue;

            }
            catch
            { }
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        #region Main Menu

        #region Tools
        private void toolStripMenuItemToolsSettings_Click(object sender, EventArgs e)
        {
            string formerUrl = Sol_ControlInfo.WebBrowserUrl;
            Settings f1 = new Settings();

            //this.Hide();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

            //this.Show();

            //FullScreenMode
            
            this.WindowState = (Properties.Settings.Default.SettingsAdFullScreenMode) ? FormWindowState.Maximized : FormWindowState.Normal;
            this.FormBorderStyle = (Properties.Settings.Default.SettingsAdFullScreenMode) ? FormBorderStyle.None : FormBorderStyle.Sizable;


            toolStripButtonSales.Visible = Properties.Settings.Default.UseSales;
            toolStripMenuItemSales.Visible = Properties.Settings.Default.UseSales;
            //
            toolStripUpperRightButtonKeyBoard.Visible = Properties.Settings.Default.TouchOriented;
            toolStripButtonUpperRightAttendance.Visible = Properties.Settings.Default.UseAttendance;

            //web browser object
            if(formerUrl != Sol_ControlInfo.WebBrowserUrl)
                Navigate(Main.Sol_ControlInfo.WebBrowserUrl);
            
            if (Main.QuickDrop_DepotID.Length == 6)
            {
               // toolStripButtonXpressReturn.Visible = true;

               // toolStripMenuItemXpressReturn.Visible = true;
                //toolStripMenuItemXpressReturn.Visible = true;
            }
            else
            {
                toolStripButtonXpressReturn.Visible = false;

                toolStripMenuItemXpressReturn.Visible = false;
                //toolStripMenuItemXpressReturn.Visible = true;
            }

            //set options for OFF_LINE mode
            SetOptionsForCurrentMode();


            if (Properties.Settings.Default.StagingType == 0)   //!Properties.Settings.Default.MultiProductStagingEnabled)
            {
                //toolStripSeparatorMultiProductStaging.Visible = false;
                toolStripMenuItemCatalogsConveyors.Visible = false;
                toolStripMenuItemCatalogsBagPosition.Visible = false;

                toolStripMenuItemMultiProductStaging.Visible = false;
            }
            else
            {
                //toolStripSeparatorMultiProductStaging.Visible = true;
                toolStripMenuItemCatalogsConveyors.Visible = true;
                toolStripMenuItemCatalogsBagPosition.Visible = true;
                toolStripMenuItemMultiProductStaging.Visible = true;

                toolStripMenuItemCatalogsConveyors.Enabled = true
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));

                toolStripMenuItemCatalogsBagPosition.Enabled = true
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));

                toolStripMenuItemMultiProductStaging.Enabled = true
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));
            }

            if(sol_WorkStation_Sp == null)
                sol_WorkStation_Sp = new Sol_WorkStation_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_WorkStation = Settings.ReadWorkStation(sol_WorkStation_Sp, Properties.Settings.Default.SettingsWsWorkStationName, false, ConveyorId);
            ConveyorId = sol_WorkStation.ConveyorID;

            if (sol_Setting_Sp == null)
                sol_Setting_Sp = new Sol_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_Setting = sol_Setting_Sp.Select("Attendance_Enabled");
            Attendance_Enabled = (bool)sol_Setting.SetValue;
            //splitContainer1.Panel1Collapsed = !Attendance_Enabled;
            toolStripButtonUpperRightAttendance.Visible = Attendance_Enabled;
            //toolStripButtonAttendance.Visible = Attendance_Enabled;
            //toolStripButtonAttendance.Enabled = toolStripButtonAttendance.Visible;

        }

        private void toolStripMenuItemToolsMessages_Click(object sender, EventArgs e)
        {
            Messages f1 = new Messages();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }



        private void toolStripMenuItemToolsWorkStations_Click(object sender, EventArgs e)
        {
            WorkStations f1 = new WorkStations();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;


        }

        private void toolStripMenuItemToolsCategoryButtons_Click(object sender, EventArgs e)
        {
            CategoryButtons f1 = new CategoryButtons();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemToolsQuantityButtons_Click(object sender, EventArgs e)
        {
            QuantityButtons f1 = new QuantityButtons();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemToolsFees_Click(object sender, EventArgs e)
        {
            Fees f1 = new Fees();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemToolsCashTrays_Click(object sender, EventArgs e)
        {
            CashTrays f1 = new CashTrays();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemToolsCashDenominations_Click(object sender, EventArgs e)
        {
            CashDenominations f1 = new CashDenominations();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemToolsExpenseTypes_Click(object sender, EventArgs e)
        {
            ExpenseTypes f1 = new ExpenseTypes();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }


        private void toolStripMenuItemToolsUsers_Click(object sender, EventArgs e)
        {
            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                DialogResult result = MessageBox.Show("This information is from Production Database. Do you want to continue?", "", MessageBoxButtons.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Cursor = Cursors.Default;
                    return;
                }

            }

            Usuarios f1 = new Usuarios(Properties.Settings.Default.WsirConnectionString, 
                Properties.Settings.Default.TouchOriented
                );

            f1.ReportesDesHabilitados = true;
            f1.PermisosDesHabilitados = true;
            f1.Employees = new Employees();

            f1.PermissionsAsign = new PermissionsAsign(
                Properties.Settings.Default.WsirConnectionString,
                "user"
                );

            f1.ReportsAssign = new ReportsAssign(
                Properties.Settings.Default.TouchOriented,
                Properties.Settings.Default.WsirConnectionString,
                "user"
                );

            f1.strUsuarioNombre = Properties.Settings.Default.UsuarioNombre;
            f1.strUsuarioRol = Properties.Settings.Default.UsuarioRol;
            f1.strConnectionString = Properties.Settings.Default.WsirConnectionString;
            f1.strNombreServidorSQL = Properties.Settings.Default.SQLServidorNombre;
            f1.StandAloneAPP = true;
            f1.ApplicationName = AssemblyProduct;
            f1.appPermissionsName = null;
            f1.ShowDialog();

            //simulate click
            timer2_Tick(timer2, new EventArgs());

            f1.PermissionsAsign = null;
            //GC.Collect();

            f1.Dispose();
            f1 = null;


        }


        private void toolStripMenuItemToolsRoles_Click(object sender, EventArgs e)
        {
            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                DialogResult result = MessageBox.Show("This information is from Production Database. Do you want to continue?", "", MessageBoxButtons.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Cursor = Cursors.Default;
                    return;
                }

            }

            SirLib.Grupos f1 = new SirLib.Grupos(Properties.Settings.Default.WsirConnectionString,
                Properties.Settings.Default.TouchOriented);


            f1.PermissionsAsign = new PermissionsAsign(
                Properties.Settings.Default.WsirConnectionString,
                "role"
                );

            f1.ReportsAssign = new ReportsAssign(
                Properties.Settings.Default.TouchOriented,
                Properties.Settings.Default.WsirConnectionString,
                "role"
                );

            f1.strUsuarioNombre = Properties.Settings.Default.UsuarioNombre;
            f1.strUsuarioRol = Properties.Settings.Default.UsuarioRol;
            f1.strConnectionString = Properties.Settings.Default.WsirConnectionString;
            f1.strNombreServidorSQL = Properties.Settings.Default.SQLServidorNombre;
            f1.StandAloneAPP = true;
            f1.ApplicationName = AssemblyProduct;
            f1.appPermissionsName = null;
            f1.ShowDialog();

            f1.PermissionsAsign = null;
            //GC.Collect();

            f1.Dispose();
            f1 = null;

        }

        private void toolStripMenuItemToolsMyAccount_Click(object sender, EventArgs e)
        {
            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                DialogResult result = MessageBox.Show("This information is from Production Database. Do you want to continue?", "", MessageBoxButtons.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Cursor = Cursors.Default;
                    return;
                }

            }
            
            SirLib.MyAccount dlg = new SirLib.MyAccount(Properties.Settings.Default.TouchOriented, "PIN");
            
            dlg.Usuario = Properties.Settings.Default.LoginUsuarioNombre;
            dlg.ShowDialog();

            dlg.Dispose();
            dlg = null;

        }

        private void toolStripMenuItemToolsServer_Click(object sender, EventArgs e)
        {
            //connect to server
            ServerConnection(true);

            //set options for OFF_LINE mode
            SetOptionsForCurrentMode();

            
        }

        private void toolStripMenuItemToolsBackup_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SQLAutentificacion == 1 && !Properties.Settings.Default.SQLRecuerdame)
            {
                MessageBox.Show("To make a backup, the connection to the SQL Server must have the  'Windows Authentication' option selected or have the option 'Remember me' turned on.", "SQL server connection warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SirLib.Respaldar f1 = new SirLib.Respaldar(
                Properties.Settings.Default.SQLServidorNombre,
                Properties.Settings.Default.SQLBaseDeDatos,
                Properties.Settings.Default.SQLAutentificacion,
                Properties.Settings.Default.SQLUsuarioNombre,
                Properties.Settings.Default.SQLUsuarioClave,
                Properties.Settings.Default.WsirDbConnectionString,
                Properties.Settings.Default.TouchOriented,
                "Sol_Control"
                );
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void toolStripMenuItemToolsRestore_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SQLAutentificacion == 1 && !Properties.Settings.Default.SQLRecuerdame)
            {
                MessageBox.Show("To make a restore, the connection to the SQL Server must have the  'Windows Authentication' option selected or have the option 'Remember me' turned on.", "SQL server connection warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SirLib.Respaldar f1 = new SirLib.Respaldar(
                Properties.Settings.Default.SQLServidorNombre,
                Properties.Settings.Default.SQLBaseDeDatos,
                Properties.Settings.Default.SQLAutentificacion,
                Properties.Settings.Default.SQLUsuarioNombre,
                Properties.Settings.Default.SQLUsuarioClave,
                Properties.Settings.Default.WsirDbConnectionString,
                Properties.Settings.Default.TouchOriented,
                "Sol_Control"
                );
            f1.boolRecuperar = true;
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

            LeerOpciones(true);

        }

        private void toolStripMenuItemToolsApplyLastServicePack_Click(object sender, EventArgs e)
        {
            if (LeerOpciones(false))
            {
                MessageBox.Show("Database Up to Date!");

                //Training Database
                bool flag = Funciones.DatabaseExists(Properties.Settings.Default.WsirConnectionString, "Solum_Training");

                toolStripMenuItemCreateTrainingDatabase.Visible = flag;
                if (toolStripStatusEmpresa.Text == "Solum")
                {
                    toolStripMenuItemCreateTrainingDatabase.Visible = true;
                    toolStripStatusLabelTrainingMode.Visible = false;
                }
                else if (toolStripStatusEmpresa.Text == "Solum_Training")
                {
                    toolStripMenuItemCreateTrainingDatabase.Visible = false;
                    toolStripMenuItemUseTrainingMode.Text = "&Back to Production Mode";
                    toolStripStatusLabelTrainingMode.Visible = true;
                    timerBlink.Enabled = true;

                }


            }
        }



        private void toolStripMenuItemToolsDate_Click(object sender, EventArgs e)
        {
            //SirLib.CambiarFecha f1 = new SirLib.CambiarFecha(Main.Sol_ControlInfo.HistoryYears, Properties.Settings.Default.TouchOriented);
            ////CambiarFecha f1 = new CambiarFecha();
            //f1.FechaActual = Properties.Settings.Default.FechaActual;   // Vars.FechaActual;
            //f1.ShowDialog();
            ////Vars.FechaActual = f1.FechaActual;
            //Properties.Settings.Default.FechaActual = f1.FechaActual; //Vars.FechaActual;
            //Properties.Settings.Default.Save();

            //toolStripLabelDate.Text = Properties.Settings.Default.FechaActual.ToShortDateString(); //Vars.FechaActual.ToShortDateString();

        }


        private void toolStripMenuItemToolsLogError_Click(object sender, EventArgs e)
        {

            //throw new Exception("A test exception");

            SirLib.LogErrors f1 = new SirLib.LogErrors(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.TouchOriented, myHostName);
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemChangeMode_Click(object sender, EventArgs e)
        {

            Forms.Modes.Modes f1 = new Forms.Modes.Modes();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

            //set options for OFF_LINE mode
            SetOptionsForCurrentMode();

        }

        private void toolStripMenuItemToolsExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemCreateTrainingDatabase_Click(object sender, EventArgs e)
        {
            CreateTrainingDb f1 = new CreateTrainingDb(version);
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

            bool flag = Funciones.DatabaseExists(Properties.Settings.Default.WsirDbConnectionString, "Solum_Training");

            toolStripMenuItemCreateTrainingDatabase.Visible = flag; //f1.dbCreated;
            toolStripMenuItemUseTrainingMode.Visible = flag;


        }

        private void toolStripMenuItemUseTrainingMode_Click(object sender, EventArgs e)
        {
            string connectString = Properties.Settings.Default.WsirDbConnectionString;

            if (toolStripStatusEmpresa.Text == "Solum")
            {
                Properties.Settings.Default.SQLBaseDeDatos = "Solum_Training";
                connectString = connectString.Replace("Solum;", "Solum_Training;");
                toolStripMenuItemCreateTrainingDatabase.Visible = false;

                toolStripMenuItemUseTrainingMode.Text = "&Back to Production Mode";
                toolStripStatusLabelTrainingMode.Visible = true;

                //timerBlink.Enabled = false;
                intCntr = 0;
                //timerBlink.Enabled = true;
                try
                {
                    timerBlink.Enabled = true;
                }
                catch { }


            }
            else
            {
                Properties.Settings.Default.SQLBaseDeDatos = "Solum";
                connectString = connectString.Replace("Solum_Training;", "Solum;");
                toolStripMenuItemCreateTrainingDatabase.Visible = true;

                toolStripMenuItemUseTrainingMode.Text = "&Use Training Mode";
                toolStripStatusLabelTrainingMode.Visible = false;
                try
                {
                    timerBlink.Enabled = false;
                }
                catch { }
                intCntr = 0;

            }


            toolStripStatusEmpresa.Text = Properties.Settings.Default.SQLBaseDeDatos;

            //update ConnectString of settings

            //NOT NEEDED Properties.Settings.Default.RuntimeConnectString = connectString; NOT NEEDED
            Properties.Settings.Default.RuntimeDbConnectString = connectString;

            Properties.Settings.Default.Save();

            if (!LeerOpciones(true))
            {
                toolStripStatusEmpresa.Text = "Not connected";
                EnableOptions("database");

            }


        }

        #endregion

        #region Catalogs

        private void toolStripMenuItemCatalogsConveyors_Click(object sender, EventArgs e)
        {
            Conveyors f1 = new Conveyors();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void toolStripMenuItemCatalogsBagPosition_Click(object sender, EventArgs e)
        {
            BagPosition f1 = new BagPosition();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }


        private void toolStripMenuItemCatalogsStandardDozen_Click(object sender, EventArgs e)
        {
            StandardDozen f1 = new StandardDozen();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void toolStripMenuItemCatalogsAgencies_Click(object sender, EventArgs e)
        {
            Agencies f1 = new Agencies();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemCatalogsContainers_Click(object sender, EventArgs e)
        {
            Containers f1 = new Containers();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemCatalogsCategories_Click(object sender, EventArgs e)
        {
            Categories f1 = new Categories();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemCatalogsProducts_Click(object sender, EventArgs e)
        {
            Products f1 = new Products();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemCatalogsCustomers_Click(object sender, EventArgs e)
        {
            if (!((CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false))))
            {
                MessageBox.Show("Sorry, you don't have permission to view and edit customers");
                return;
            }
            Customers f1 = new Customers();
            f1.manageMode = true;
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }
        #endregion

        #region Point of Return

        private void toolStripMenuItemReturns_Click(object sender, EventArgs e)
        {
            CustomerScreen.customerScreenSourceForm = "Returns";
            if (Properties.Settings.Default.SettingsAdCustomerScreenAutomaticLoading)
            {
                if (CustomerScreenForm == null)
                {
                    //toolStripMenuItemCustomerScreen.PerformClick();
                    OpenCustomerScreen();
                }
            }

            Returns f1 = new Returns(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text //,
                //toolStripLabelDate.Text
                );
            try
            {
                f1.ShowDialog();
            }
            catch
            {
                //MessageBox.Show("Please restart Solum");
                //return;
            }

            bool formSales = f1.formSales;
            bool formCashier = f1.formCashier;
            f1.Dispose();
            f1 = null;

            Main.usbReadEventForm = "";

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }

            if (formSales)
            {
                toolStripMenuItemSales.PerformClick();
                return;
            }
            else if (formCashier)
            {
                toolStripMenuItemCashier.PerformClick();
                return;
            }

            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0 //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 1)   //returns
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }
        }

        private void toolStripMenuItemSales_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SettingsAdCustomerScreenAutomaticLoading &&
                CustomerScreenForm == null)
            {
                toolStripMenuItemCustomerScreen.PerformClick();
            }

            Sales f1 = new Sales(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text //,
                //toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();

            bool formReturn = f1.formReturn;
            bool formCashier = f1.formCashier;
            f1.Dispose();
            f1 = null;

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }

            if (formCashier)
            {
                toolStripMenuItemCashier.PerformClick();
                return;
            }
            else if (formReturn)
            {
                toolStripMenuItemReturns.PerformClick();
                return;
            }
            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0 //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 1)   //returns
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }

        }

        private void toolStripMenuItemCashier_Click(object sender, EventArgs e)
        {
            CustomerScreen.customerScreenSourceForm = "Cashier";
            if (Properties.Settings.Default.SettingsAdCustomerScreenAutomaticLoading)
            {
                if (CustomerScreenForm == null)
                {
                    //CustomerScreen.customerScreenSourceForm = "Cashier";
                    //toolStripMenuItemCustomerScreen.PerformClick();
                    OpenCustomerScreen();
                }
            }


            Cashier f1 = new Cashier(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text
                //,toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            bool formReturn = f1.formReturn;
            bool formSales = f1.formSales;
            f1.Dispose();
            f1 = null;

            Main.usbReadEventForm = "";

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }
            if (formSales)
            {
                toolStripMenuItemSales.PerformClick();
                return;
            }
            else if (formReturn)
            {
                toolStripMenuItemReturns.PerformClick();
                return;
            }
            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 2)   //Cashier
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }

        }
        private void toolStripMenuItemQuickDrop_Click(object sender, EventArgs e)
        {
            toolStripButtonXpressReturn.PerformClick();

        }

        private void toolStripButtonXpressReturn_Click(object sender, EventArgs e)
        {

            Returns f1 = new Returns(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text //,
                //toolStripLabelDate.Text
                );

            f1.formQuickDrop = true;
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

            Main.usbReadEventForm = "";

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }

            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 1)   //returns
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }


        }

        private void toolStripMenuItemCustomerScreen_Click(object sender, EventArgs e)
        {
            CustomerScreen.customerScreenSourceForm = "Direct";
            OpenCustomerScreen();
        }

        private bool OpenCustomerScreen()
        {
            if (Properties.Settings.Default.SettingsAdCustomerScreenEnable)
            {

                //how many displays
                // Add each property of the SystemInformation class to the list box.
                int monitorCount = System.Windows.Forms.SystemInformation.MonitorCount;
                if (monitorCount < 2)
                {
                    //for (int i = 0; i < nm; i++)
                    //    comboBoxDisplay.Items.Add(i.ToString());
                    toolStripMenuItemCustomerScreen.Enabled = false;
                    toolStripMenuItemCustomerScreen.Text = "Customer Screen - Only one monitor detected";
                    MessageBox.Show(toolStripMenuItemCustomerScreen.Text);
                    return false;
                }

                if (CustomerScreenForm == null)
                {
                    try
                    {

                        if (Properties.Settings.Default.SettingsCustomerScreenMonitor > monitorCount)
                        {
                            MessageBox.Show("CustomerScreen Monitor invalid. Please go to in Tools -> Settings -> Advance to fix it.");
                            return false;
                        }

                        if (Properties.Settings.Default.SettingsCustomerScreenMonitor < 0)
                        {
                            //MessageBox.Show("Please assign CustomerScreen Monitor in Tools -> Settings -> Advanced.");
                            //return;
                            Properties.Settings.Default.SettingsCustomerScreenMonitor = 0;
                        }

                        Screen[] sc;
                        sc = Screen.AllScreens;

                        //get all the screen width and heights 
                        CustomerScreenForm = new CustomerScreen(
                            statusStripMainHeaderLabelUser.Text
                            //,
                            //Properties.Settings.Default.FechaActual.ToString("dd-MMM-yyyy")
                            //Main.rc.FechaActual.ToString("dd-MMM-yyyy")
                            );
                        CustomerScreenForm.FormBorderStyle = FormBorderStyle.None;// .None;
                        CustomerScreenForm.Left = sc[Properties.Settings.Default.SettingsCustomerScreenMonitor].Bounds.Width;
                        CustomerScreenForm.Top = sc[Properties.Settings.Default.SettingsCustomerScreenMonitor].Bounds.Height;
                        CustomerScreenForm.StartPosition = FormStartPosition.Manual;
                        CustomerScreenForm.Location = sc[Properties.Settings.Default.SettingsCustomerScreenMonitor].Bounds.Location;
                        Point p = new Point(sc[Properties.Settings.Default.SettingsCustomerScreenMonitor].Bounds.Location.X, sc[Properties.Settings.Default.SettingsCustomerScreenMonitor].Bounds.Location.Y);
                        CustomerScreenForm.Location = p;
                        //CustomerScreenForm.WindowState = FormWindowState.Normal;
                        //CustomerScreenForm.WindowState = FormWindowState.Maximized;
                        CustomerScreenForm.ControlBox = false;  // true;
                        CustomerScreenForm.MaximizeBox = true;  // false;
                        CustomerScreenForm.MinimizeBox = false;
                        //CustomerScreenForm.ShowDialog();


                        CustomerScreenForm.Show();

                        toolStripMenuItemCustomerScreen.Text = "Close C&ustomer Screen";

                        this.Focus();
                    }
                    catch
                    {
                        CustomerScreenForm = null;
                        MessageBox.Show("Problems with the secondary display, please check your settings.");
                        return false;
                    }
                }
                else
                {
                    CustomerScreenForm.Close();
                    CustomerScreenForm = null;

                    toolStripMenuItemCustomerScreen.Text = "C&ustomer Screen";
                }
            }

            return true;
        }

        #endregion

        #region Shipping

        private void toolStripMenuItemShippingHome_Click(object sender, EventArgs e)
        {
            ShippingHome f1 = new ShippingHome(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            int shippingForm = f1.ShippingForm;
            f1.Dispose();
            f1 = null;

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }

            if (shippingForm == 2)    //StagedContainers
            {
                toolStripMenuItemShippingStagedContainers.PerformClick();
                return;
            }
            else if (shippingForm == 3)    //Shipment
            {
                toolStripMenuItemShippingShipments.PerformClick();
                return;
            }
            else if (shippingForm == 4)    //Lookup
            {
                toolStripMenuItemShippingLookup.PerformClick();
                return;
            }
            else if (shippingForm == 5)    //Adjustments
            {
                toolStripMenuItemShippingAdjustments.PerformClick();
                return;
            }
            else if (shippingForm == 6)    //MultiProductStagedContainers
            {
                toolStripMenuItemMultiProductStaging.PerformClick();
                return;
            }

            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 3)   //shipping
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }

        }

        private void toolStripMenuItemShippingStagedContainers_Click(object sender, EventArgs e)
        {
            ShippingStagedContainers f1 = new ShippingStagedContainers(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            int shippingForm = f1.ShippingForm;
            f1.Dispose();
            f1 = null;

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }

            if (shippingForm == 1)    //Home
            {
                toolStripMenuItemShippingHome.PerformClick();
                return;
            }
            else if (shippingForm == 3)    //Shipment
            {
                toolStripMenuItemShippingShipments.PerformClick();
                return;
            }
            else if (shippingForm == 4)    //Lookup
            {
                toolStripMenuItemShippingLookup.PerformClick();
                return;
            }
            else if (shippingForm == 5)    //Adjustments
            {
                toolStripMenuItemShippingAdjustments.PerformClick();
                return;
            }
            else if (shippingForm == 6)    //MultiProductStagedContainers
            {
                toolStripMenuItemMultiProductStaging.PerformClick();
                return;
            }

            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 3)   //shipping
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }

        }

        private void toolStripMenuItemMultiProductStaging_Click(object sender, EventArgs e)
        {
            ShippingMultiProductStagedContainers f1 = new ShippingMultiProductStagedContainers(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            int shippingForm = f1.ShippingForm;
            f1.Dispose();
            f1 = null;

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }
            if (shippingForm == 1)    //Home
            {
                toolStripMenuItemShippingHome.PerformClick();
                return;
            }
            if (shippingForm == 2)    //StagedContainers
            {
                toolStripMenuItemShippingStagedContainers.PerformClick();
                return;
            }
            else if (shippingForm == 3)    //Shipment
            {
                toolStripMenuItemShippingShipments.PerformClick();
                return;
            }
            else if (shippingForm == 4)    //Lookup
            {
                toolStripMenuItemShippingLookup.PerformClick();
                return;
            }
            else if (shippingForm == 5)    //Adjustments
            {
                toolStripMenuItemShippingAdjustments.PerformClick();
                return;
            }

            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 3)   //shipping
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }

        }


        private void toolStripMenuItemShippingShipments_Click(object sender, EventArgs e)
        {
            ShippingShipments f1 = new ShippingShipments(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            int shippingForm = f1.ShippingForm;
            f1.Dispose();
            f1 = null;

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }
            if (shippingForm == 1)    //Home
            {
                toolStripMenuItemShippingHome.PerformClick();
                return;
            }
            else if (shippingForm == 2)    //StagedContainers
            {
                toolStripMenuItemShippingStagedContainers.PerformClick();
                return;
            }
            else if (shippingForm == 4)    //Lookup
            {
                toolStripMenuItemShippingLookup.PerformClick();
                return;
            }
            else if (shippingForm == 5)    //Adjustments
            {
                toolStripMenuItemShippingAdjustments.PerformClick();
                return;
            }
            else if (shippingForm == 6)    //MultiProductStagedContainers
            {
                toolStripMenuItemMultiProductStaging.PerformClick();
                return;
            }
            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 3)   //shipping
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }
        }

        private void toolStripMenuItemShippingAdjustments_Click(object sender, EventArgs e)
        {
            ShippingAdjustments f1 = new ShippingAdjustments(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            int shippingForm = f1.ShippingForm;
            f1.Dispose();
            f1 = null;

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }

            if (shippingForm == 1)    //Home
            {
                toolStripMenuItemShippingHome.PerformClick();
                return;
            }
            else if (shippingForm == 2)    //StagedContainers
            {
                toolStripMenuItemShippingStagedContainers.PerformClick();
                return;
            }
            else if (shippingForm == 3)    //Shipment
            {
                toolStripMenuItemShippingShipments.PerformClick();
                return;
            }
            else if (shippingForm == 4)    //Lookup
            {
                toolStripMenuItemShippingLookup.PerformClick();
                return;
            }
            else if (shippingForm == 6)    //MultiProductStagedContainers
            {
                toolStripMenuItemMultiProductStaging.PerformClick();
                return;
            }
            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);

            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 3)   //shipping
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }

        }

        private void toolStripMenuItemShippingLookup_Click(object sender, EventArgs e)
        {
            ShippingLookup f1 = new ShippingLookup(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            int shippingForm = f1.ShippingForm;
            f1.Dispose();
            f1 = null;

            if (statusStripMainHeaderLabelUser.Text != Properties.Settings.Default.UsuarioNombre)
            {
                statusStripMainHeaderLabelUser.Text = Properties.Settings.Default.UsuarioNombre;
                //EnableOptions("user");
                EnableOptions("database");
            }

            if (shippingForm == 1)    //Home
            {
                toolStripMenuItemShippingHome.PerformClick();
                return;
            }
            else if (shippingForm == 2)    //StagedContainers
            {
                toolStripMenuItemShippingStagedContainers.PerformClick();
                return;
            }
            else if (shippingForm == 3)    //Shipment
            {
                toolStripMenuItemShippingShipments.PerformClick();
                return;
            }
            else if (shippingForm == 5)    //Adjustments
            {
                toolStripMenuItemShippingAdjustments.PerformClick();
                return;
            }
            else if (shippingForm == 6)    //MultiProductStagedContainers
            {
                toolStripMenuItemMultiProductStaging.PerformClick();
                return;
            }
            //this.Show();
            object obj1 = toolStripLabelDate;
            object obj2 = null;
            rc.CambiarControlFecha(ref obj1);
            rc.CambiarControlHora(ref obj2);
            //exit app according to role
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {
                if (Properties.Settings.Default.SettingComputerRole == 3)   //shipping
                    toolStripMenuItemToolsExit.PerformClick();
                else
                    CheckComputerRole();
            }
        }
        #endregion

        #region Inventory

        private void toolStripMenuItemInventoryProducts_Click(object sender, EventArgs e)
        {
            Inventory f1 = new Inventory(
                this.Text,
                statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            //this.Hide();
            f1.ShowDialog();
            //this.Show();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemInventorySupplies_Click(object sender, EventArgs e)
        {
            SupplyInventory f1 = new SupplyInventory(
                this.Text,
                //statusStripMainHeaderLabelUser.Text,
                toolStripStatusLabelServer.Text,
                toolStripLabelDate.Text
                );
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }


        #endregion

        #region Accounting
        private void toolStripMenuItemAccountingExpenseTypes_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItemAccountingCashDenominations_Click(object sender, EventArgs e)
        {
            CashDenominations f1 = new CashDenominations();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }


        private void toolStripMenuItemAccountingOpenCashier_Click(object sender, EventArgs e)
        {
            Float f1 = new Float("Open");
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void ToolStripMenuItemAccountingFloat_Click(object sender, EventArgs e)
        {
            Float f1 = new Float("Float");
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void ToolStripMenuItemAccountingCloseCashier_Click(object sender, EventArgs e)
        {
            Float f1 = new Float("Close");
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemAccountingExpenses_Click(object sender, EventArgs e)
        {
            Expenses f1 = new Expenses();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemAccountingEntriesManager_Click(object sender, EventArgs e)
        {
            Entries f1 = new Entries();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        #endregion

        #region Others Modules like Reports, Login, Help, Register etc.
        private void toolStripMenuItemReports_Click(object sender, EventArgs e)
        {
            ReportsMain f1 = new ReportsMain();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
        }

        private void toolStripMenuItemLogin_Click(object sender, EventArgs e)
        {
            //hacer logout si el usuario estaba conectado
            if (IsAuthenticated)
            {

                DialogResult result = MessageBox.Show("Do you want to log out?", "", MessageBoxButtons.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                    return;

                //close customerScreen if any
                if (CustomerScreenForm != null)
                {
                    CustomerScreenForm.Close();
                    CustomerScreenForm = null;
                    toolStripMenuItemCustomerScreen.Text = "C&ustomer Screen";
                }

                toolStripStatusEmpresa.Text = "Not connected";
                IsAuthenticated = false;
                Properties.Settings.Default.UsuarioNombre = String.Empty;
                Properties.Settings.Default.Save();

                EnableOptions("database");
                //EnableOptions("user");
            }

            IniciarSesion();

            //seleccionar empresa
            if (IsAuthenticated && toolStripStatusEmpresa.Text.Trim() == "Not connected")   // && Properties.Settings.Default.PermisoUsarAplicacion)
            {
                bool boolPreguntar = false, boolConsultar = false;
                //if (Properties.Settings.Default.UsuarioNombre.ToLower() != "admin")
                //    boolConsultar = !permisos["GeEmpresasABC"];
                //if (Properties.Settings.Default.SQLBaseDeDatos.Length < 1)
                //    boolPreguntar = true;
                SeleccionarEmpresa(Properties.Settings.Default.SQLBaseDeDatos, boolPreguntar, boolConsultar);

                //poder conectarse a empresa aunque no tenga permiso si esta conectado a ninguna
                //if (Properties.Settings.Default.NombreBaseDeDatos.Trim().Length < 1)
                //if (toolStripStatusEmpresa.Text.Trim().Length < 1)
                //    toolStrip.Items["toolStripButtonEmpresa"].Enabled = true;
            }


            CheckComputerRole();

        }

        private void toolStripMenuItemHelp_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemActivate_Click(object sender, EventArgs e)
        {
            try
            {
                BuyNowForm buyMe = new BuyNowForm(false);
                buyMe.ShowDialog();
                buyMe.Dispose();
                buyMe = null;
                ChecarActivacion();
            }
            catch (DataStoreAppConfigException) // datStoreAppConfigException)
            {
                //Form cannot be used until the datstore has been initialized.
            }

        }

        private void toolStripMenuItemRegister_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterForm register = new RegisterForm();
                register.ShowDialog();
                register.Dispose();
                register = null;

                ChecarActivacion();
            }
            catch (DataStoreAppConfigException) // datStoreAppConfigException)
            {
                //Form cannot be used until the datstore has been initialized.
            }

        }

        private void toolStripMenuItemCheckUpdates_Click(object sender, EventArgs e)
        {
            ChecarActualizaciones f1 = new ChecarActualizaciones(false, false);
            //f1.ShowDialog();
            f1.Show(this);
        }

        private void toolStripMenuItemViewHelp_Click(object sender, EventArgs e)
        {
            string url = "http://solumpor.com/2.0/training/Solum_2.0_POR_User_Manual.pdf";
            if (Funciones.RemoteFileExists(url))
                System.Diagnostics.Process.Start(url);
            else
            {
                url = "http://debug.solum2.winsir.net/Solum 2.0 POR User Manual.pdf";
                if (Funciones.RemoteFileExists(url))
                    System.Diagnostics.Process.Start(url);
                else
                    MessageBox.Show("Online Help not available at the moment, please try again later!", "url not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripMenuItemViewLocalHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Main.appFolder + "\\Varios\\Solum 2.0 POR User Manual.pdf");
        }

        private void toolStripMenuItemTrainigResources_Click(object sender, EventArgs e)
        {
            string url = "http://solumpor.com/2.0/training/";
            if (Funciones.RemoteFileExists(url))
                System.Diagnostics.Process.Start(url);
            else
                MessageBox.Show("Resources not available at the moment, please try again later!", "url not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void toolStripMenuItemForum_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://forum.solum.winsir.net");

            string url = "http://support.solumpor.com/";
            if (Funciones.RemoteFileExists(url))
                System.Diagnostics.Process.Start(url);
            else
                MessageBox.Show("Support not available at the moment, please try again later!", "url not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void toolStripMenuItemForumUpdateHistory_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemForumUpdateHistory.Text == "&Update History")
            {
                Navigate(Main.Sol_ControlInfo.WebBrowserUpdateHistoryUrl);
                toolStripMenuItemForumUpdateHistory.Text = "&Close Update History";
            }
            else
            {
                Navigate(Main.Sol_ControlInfo.WebBrowserUrl);
                toolStripMenuItemForumUpdateHistory.Text = "&Update History";
            }


        }

        private void toolStripMenuItemAcerca_Click(object sender, EventArgs e)
        {
            SirLib.AboutBox1 f1 = new AboutBox1(
                        AssemblyProduct,
                        String.Format("Version {0}", versionNumber),    //version),  //AssemblyVersion),
                        String.Format("Copyright © 2016 - {0}", DateTime.Today.Year),
                        AssemblyCompany,
                        AssemblyDescription,    //RecursoLocal.SistemaDescripcion,
                        Properties.Resources.Solum

                );

            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }
        #endregion 

        #region ToolBar


        private void toolStripButtonVirtualKb_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                if (_pVirtualKb == null)
                    Funciones.TecladoVirtual(ref _pVirtualKb, true);
                else
                    Funciones.TecladoVirtual(ref _pVirtualKb, false);
            }
        }

        private void toolStripButtonAttendance_Click(object sender, EventArgs e)
        {
            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                DialogResult result = MessageBox.Show("This information is from Production Database. Do you want to continue?", "", MessageBoxButtons.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Cursor = Cursors.Default;
                    return;
                }
            }

            Attendance f1 = new Attendance();

            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                int lastItem = 0;
                foreach (ListViewItem item in selectedItems)
                    lastItem = item.Index;
                f1.itemIndex = lastItem;

            }

            f1.ShowDialog();
            f1.Dispose();
            f1 = null;
            //simulate click
            timer2_Tick(timer2, new EventArgs());

        }


        #endregion

        #endregion

        #region Other routines
        private bool ServerConnection(bool flag)
        {

            if (!ConectarServidor(flag))
                return false;

            //check main database
            string bd = Properties.Settings.Default.SQLBaseDeDatos;

            bool flagContinue = false;
            if (Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName)
                flagContinue = true;
            else
                flagContinue = Funciones.ChecarWsir(
                    Properties.Settings.Default.SQLServidorNombre,
                    Properties.Settings.Default.WsirConnectionString,
                    Properties.Settings.Default.VersionPaqueteServicioWsir,
                    Properties.Settings.Default.TouchOriented,
                    bd
                );

            if (flagContinue)
            {

                //check permissions
                if (Properties.Settings.Default.SQLBaseDeDatos != Properties.Settings.Default.ModesLocalDbDatabaseName)
                {
                    SirLib.wsir_Permisos_info pi = SirLib.wsir_Permisos.Buscar(Properties.Settings.Default.WsirConnectionString, "SolCreateChit");
                    if (String.IsNullOrEmpty(pi.PermisoNombreEnMinusculas.Trim()))
                    {
                        //add permissions
                        try
                        {

                            //1.- List Of Permissions
                            //POS
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCreateChit", "Create and/or add items to chit", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolDeleteChit", "Delete and/or remove items to chit", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolLookupChit", "Find chit", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolOpenChit", "Edit a closed chit", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCashOutOrder", "Cash out an order", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolUnpayOrder", "Unpay an order", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolPutOnAccountButton", "Put OnAccount an order", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolVoidOrder", "Void an order", "", false);

                            //Shipping
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolShipping", "Access to shipping menus", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCreateContainer", "Create staged container", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolModifyContainer", "Modify staged container", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewContainer", "View a created staged container", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCreateShipment", "Create and/or modify shipment", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewShipment", "View old shipment", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolUnshipShipment", "Unship a R-Bill", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolLookupShipment", "Find shipment history", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolAdjustShipment", "Adjust a shipment", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolVoidShipment", "Void a shipment", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolVoidStaged", "Void staged item", "", false);

                            //Inventory
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewInventory", "View inventory", "", false);
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCreateAdjustment", "Create adjustment", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewProducts", "View products", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCreateProductAdjustment", "Create product adjustment", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewSupplies", "View supplies", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCreateSupplyAdjustment", "Create supply adjustment", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolPrintInventory", "Print out inventory sheet", "", false);


                            //Accounting
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolOpenCashier", "Open Cashier", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolAddFloat", "Add Float", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolCloseCashier", "Close Cashier", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolAddExpenses", "Add Expenses", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewCustomer", "View customer accounts", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolEditCustomer", "Edit customer accounts", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewEntries", "View entries manager", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolEditEntries", "Edit any entries", "", false);

                            //Reports
                            //separate report system based on our discussion today

                            //Catalogs //REVIEW
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolAddCatalogues", "Add Catalogues", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolEditCatalogues", "Edit Catalogues", "", false);

                            //Tools
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolManageUsers", "Manage users", "", false);			//GeUsuariosABC
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolManagerRoles", "Manager roles", "", false);		//GeGruposABC
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolManageCompanies", "Manage companies", "", false);	//GeCambiarEmpresa
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolBackupDatabase", "Backup database", "", false);	//GeRespaldar
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolRestoreDatabase", "Restore database", "", false);	//GeRecuperar
                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolYearClose", "Year close", "", false);				//GeCierreAnual

                            //wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolChangeSettings", "Change settings", "", false);	//SolCambiarOpciones
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolUpdateVersion", "Update Solum Version", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolViewHelp", "View help screens", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolUserEmail", "User receives email notifications", "", false);
                            wsir_Permisos.Agregar(Properties.Settings.Default.WsirConnectionString, "SolUseTraining", "Can use Training Mode", "", false);

                        }
                        catch
                        {
                            MessageBox.Show("Error adding permissions, please notify the administrator.");
                            return false;
                        }
                    }

                    //aqui estaba
                }

                //Iniciar sesion
                IniciarSesion();

                //validate training db existance
                //if (!Funciones.DatabaseExists(Properties.Settings.Default.WsirConnectionString, "Solum_Training") && Properties.Settings.Default.SQLBaseDeDatos != "Solum")
                //{
                //    Properties.Settings.Default.SQLBaseDeDatos = "Solum";
                //    Properties.Settings.Default.Save();
                //}

                //select db
                if (IsAuthenticated)    // && Properties.Settings.Default.PermisoUsarAplicacion)
                {
                    bool boolPreguntar = false, boolConsultar = false;
                    //if (Properties.Settings.Default.UsuarioNombre.ToLower() != "admin")
                    //    boolConsultar = !permisos["GeEmpresasABC"];
                    //if (Properties.Settings.Default.SQLBaseDeDatos.Length < 1)
                    //    boolPreguntar = true;
                    SeleccionarEmpresa(Properties.Settings.Default.SQLBaseDeDatos, boolPreguntar, boolConsultar);

                    //poder conectarse a empresa aunque no tenga permiso si esta conectado a ninguna
                    //if (Properties.Settings.Default.SQLBaseDeDatos.Trim().Length < 1)
                    //{
                    //    //toolStrip.Items["toolStripButtonEmpresa"].Enabled = true;
                    //}
                }

                ////leer opciones
                ////Sol_Control
                ////Sol_Control_Sp sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
                //Sol_Control_Sp sol_Control_Sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
                //Main.Sol_ControlInfo = sol_Control_Sp.Select(1);
                
                //if (Main.Sol_ControlInfo == null)
                //    CreateDefaultControlInfo();

                ////Main.Sol_ControlInfo.WorkStationID = 1;

                //LeerOpciones();

                
            }
            else
            {
                Properties.Settings.Default.SQLServidorConectado = false;
                Properties.Settings.Default.Save();
                return false;
            }

            return true;
        }

        private bool LeerOpciones(bool Notificar)
        {
            toolStripStatusLabelEmpresaVersion.Text = "";
            string c = Properties.Settings.Default.WsirDbConnectionString;
            Sol_Control_Sp sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
            try
            {
                ReadNewSettings();
                Sol_ControlInfo = sp.Select(1);
            }
            catch
            {
                Sol_ControlInfo = null;
            }

            if (Sol_ControlInfo == null)
            {
                //nop
                Sol_ControlInfo = new Sol_Control();
                string query =
                    "SELECT [DatabaseVersion] FROM Sol_Control WHERE ControlID = 1 ";
                Sol_ControlInfo.DatabaseVersion = 0m;
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                    Sol_ControlInfo.DatabaseVersion = (decimal)reader[0];
                            }
                        }
                    }
                    catch
                    {

                        return false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }

            if(sol_WorkStation_Sp == null)
                sol_WorkStation_Sp = new Sol_WorkStation_Sp(Properties.Settings.Default.WsirDbConnectionString);

            toolStripMenuItemToolsApplyLastServicePack.Enabled = false;
            //checar version de base de datos
            if (Sol_ControlInfo.DatabaseVersion < 1.112m)
            {
                MessageBox.Show("Your database doesn't appear to have the latest ServicesPack applied for Version 1, please apply the last ServicePack before converting to Version 2");
                Application.Exit();
                return false;
            }


            if (Sol_ControlInfo.DatabaseVersion < DatabaseVersion)
            {
                DialogResult result = MessageBox.Show("Database out of date, do you want to apply last Service Pack?", "", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    result = MessageBox.Show("Do you want to perfom a backup first?", "", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Properties.Settings.Default.SQLAutentificacion == 1 && !Properties.Settings.Default.SQLRecuerdame)
                        {
                            MessageBox.Show("To make a backup, the connection to the SQL Server must have the  'Windows Authentication' option selected or have the option 'Remember me' turned on.", "SQL server connection warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ActivarOpcionesMinimas();
                            return false;
                        }
                        else
                        {
                            SirLib.Respaldar f1 = new SirLib.Respaldar(
                                Properties.Settings.Default.SQLServidorNombre,
                                Properties.Settings.Default.SQLBaseDeDatos,
                                Properties.Settings.Default.SQLAutentificacion,
                                Properties.Settings.Default.SQLUsuarioNombre,
                                Properties.Settings.Default.SQLUsuarioClave,
                                Properties.Settings.Default.WsirDbConnectionString,
                                Properties.Settings.Default.TouchOriented,
                                Properties.Settings.Default.SQLBaseDeDatos    //"Sol_Control"
                                );
                            f1.ShowDialog();
                            f1.Dispose();
                            f1 = null;

                        }
                    }


                    this.Cursor = Cursors.WaitCursor;

                    //servicepack for wsir database does not apply to training database
                    string sP = Properties.Resources._3_ServicePack;
                    string sPwsir = Properties.Resources._5_ServicePackWsir;
                    if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
                    {
                        sP = sP.Replace("@FlagTraining [bit]  = 0;", "@FlagTraining [bit]  = 1;");
                        sPwsir = null;
                    }


                    //aplicar servicepack
                    if (Funciones.AplicarServicePack(
                        Properties.Settings.Default.WsirDbConnectionString,
                        Properties.Settings.Default.SQLBaseDeDatos,
                        sP, //Properties.Resources._3_ServicePack,
                        sPwsir,
                        null,
                        null
                        ))
                    {

                        //we try to read options once again
                        //sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
                        try
                        {
                            ReadNewSettings(); 
                            Sol_ControlInfo = sp.Select(1);
                        }
                        catch
                        {
                            Sol_ControlInfo = null;
                        }

                        if (Sol_ControlInfo == null)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Something is wrong with you Control Table, please notify your administrator!");
                            return false;
                        }


                        if (Sol_ControlInfo.DatabaseVersion < 3.001m)
                        {
                            ConveyorId = 1;
                            sol_WorkStation = Settings.ReadWorkStation(sol_WorkStation_Sp, Properties.Settings.Default.SettingsWsWorkStationName, true, ConveyorId);

                        }

                        //actualizar version
                        Sol_ControlInfo.DatabaseVersion = DatabaseVersion;
                        sp.Update(Sol_ControlInfo);

                        toolStripStatusEmpresa.Text = Properties.Settings.Default.SQLBaseDeDatos;

                        this.Cursor = Cursors.Default;
                        if(Notificar)
                            MessageBox.Show("Database Up to Date!");

                        //EnableOptions("database");

                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        ActivarOpcionesMinimas();
                        return false;
                    }
                }
                else
                {
                    if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
                    {
                        toolStripMenuItemUseTrainingMode.Enabled = true;
                        toolStripMenuItemUseTrainingMode.PerformClick();
                        MessageBox.Show("Cannot use Training database without updating! Going back to Production.");

                        //EnableOptions("database");
                        //return true;
                    }
                    else
                    {
                        ActivarOpcionesMinimas();
                        return false;
                    }
                }
            }
            else if (Sol_ControlInfo.DatabaseVersion > DatabaseVersion)
            {

                DialogResult result = MessageBox.Show("Database version is newer than the application internal version!\r\nPlease update Solum to the newest version.");  //, "", MessageBoxButtons.YesNo);
                //if (!Properties.Settings.Default.CheckUpdatesOnStart && result == System.Windows.Forms.DialogResult.Yes)
                //{
                //    ChecarActualizaciones f1 = new ChecarActualizaciones(false, true);
                //    f1.Show(this);
                //}
                ////ActivarOpcionesMinimas();
                ////toolStripMenuItemCheckUpdates.Enabled = true && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUpdateVersion", false);

                //return false;

            }

            EnableOptions("database");


            sol_WorkStation = Settings.ReadWorkStation(sol_WorkStation_Sp, Properties.Settings.Default.SettingsWsWorkStationName, false, ConveyorId);
            if(sol_WorkStation!=null)
            ConveyorId = sol_WorkStation.ConveyorID;

            return true;
        }

        private void ActivarOpcionesMinimas()
        {
            toolStripStatusLabelEmpresaVersion.Text = "Database Out of Date!";
            toolStripMenuItemToolsApplyLastServicePack.Enabled = true;

            bool flag = true;

            toolStripMenuItemToolsSettings.Enabled = !flag;
            toolStripMenuItemToolsMessages.Enabled = !flag;
            toolStripMenuItemToolsWorkStations.Enabled = !flag;
            toolStripMenuItemToolsCategoryButtons.Enabled = !flag;
            toolStripMenuItemToolsQuantityButtons.Enabled = !flag;
            toolStripMenuItemToolsFees.Enabled = !flag;
            toolStripMenuItemToolsCashTrays.Enabled = !flag;
            toolStripMenuItemToolsCashDenominations.Enabled = !flag;
            toolStripMenuItemToolsExpenseTypes.Enabled = !flag;
            toolStripMenuItemToolsUsers.Enabled = !flag;
            toolStripMenuItemToolsRoles.Enabled = !flag;
            toolStripMenuItemToolsMyAccount.Enabled = flag;
            //toolStripMenuItemToolsServer.Enabled = flag;
            toolStripMenuItemToolsBackup.Enabled = flag;
            toolStripMenuItemToolsRestore.Enabled = flag;
            //toolStripMenuItemToolsApplyLastServicePack.Enabled = flag;
            toolStripMenuItemToolsDate.Enabled = !flag;

            toolStripMenuItemToolsLogError.Enabled = flag;



            toolStripMenuItemCreateTrainingDatabase.Enabled = !flag;
            toolStripMenuItemUseTrainingMode.Enabled = !flag;


            //toolStripMenuItemToolsExit.Enabled = flag;

            toolStripMenuItemPor.Enabled = !flag;
            //toolStripMenuItemReturns.Enabled = true;
            //toolStripMenuItemSales.Enabled = true;
            //toolStripMenuItemCashier.Enabled = true;
            toolStripMenuItemShipping.Enabled = !flag;
            //toolStripMenuItemShippingHome.Enabled = toolStripMenuItemShipping.Enabled;
            //toolStripMenuItemShippingStagedContainers.Enabled = toolStripMenuItemShipping.Enabled;
            //toolStripMenuItemShippingShipments.Enabled = toolStripMenuItemShipping.Enabled;
            //toolStripMenuItemShippingLookup.Enabled = toolStripMenuItemShipping.Enabled;

            toolStripMenuItemInventory.Enabled = !flag;

            toolStripMenuItemAccounting.Enabled = !flag;
            //toolStripMenuItemAccountingExpenseTypes.Enabled = toolStripMenuItemAccounting.Enabled;
            //toolStripMenuItemAccountingCashDenominations.Enabled = toolStripMenuItemAccounting.Enabled;
            //toolStripMenuItemAccountingOpenCashier.Enabled = toolStripMenuItemAccounting.Enabled;
            //ToolStripMenuItemAccountingFloat.Enabled = toolStripMenuItemAccounting.Enabled;
            //ToolStripMenuItemAccountingCloseCashier.Enabled = toolStripMenuItemAccounting.Enabled;
            //toolStripMenuItemAccountingExpenses.Enabled = toolStripMenuItemAccounting.Enabled;


            toolStripMenuItemReports.Enabled = !flag;
            toolStripButtonReports.Enabled = !flag;

            //help
            //toolStripMenuItemCheckUpdates.Enabled = !flag;

            //TOOLS
            toolStripButtonSettings.Enabled = !flag;
            toolStripUpperRightButtonMyAccount.Enabled = flag;
            toolStripLabelDate.Enabled = !flag;

            toolStripButtonReturns.Enabled = !flag;
            //toolStripButtonSales.Enabled = !flag;
            toolStripButtonCashier.Enabled = !flag;
            toolStripButtonShipping.Enabled = !flag;

            toolStripButtonXpressReturn.Enabled = !flag;

            //toolStripButtonAttendance.Enabled = !flag & Attendance_Enabled;

        }

        //funciones generales
        private void LlenarDiccionarios()
        {
            //leer nombre de los meses segun el idioma
            Funciones.ObtenerMeses(ref mesesNombre);
        }

        //conectar con servidor
        private bool ConectarServidor(bool boolPreguntar)
        {
            string sn = Properties.Settings.Default.SQLServidorNombre;

            if (Properties.Settings.Default.SQLServidorNombre == Properties.Settings.Default.ModesLocalDbServerName)
                Properties.Settings.Default.SQLBaseDeDatos = Properties.Settings.Default.ModesLocalDbDatabaseName;
            else
                Properties.Settings.Default.SQLBaseDeDatos = Properties.Settings.Default.BaseDeDatosPrincipal;

            string bd = Properties.Settings.Default.SQLBaseDeDatos;

            SirLib.ConexionServidor dlg = new SirLib.ConexionServidor(
                Properties.Settings.Default.WsirConnectionString,
                Properties.Settings.Default.SQLServidorNombre,
                Properties.Settings.Default.SQLAutentificacion,
                Properties.Settings.Default.SQLUsuarioNombre,
                Properties.Settings.Default.SQLUsuarioClave,
                Properties.Settings.Default.SQLRecuerdame,
                Properties.Settings.Default.SQLServidorConectado,
                Properties.Settings.Default.TouchOriented,
                Properties.Settings.Default.SQLBaseDeDatos
                );
            dlg.boolPreguntar = boolPreguntar;
            bool f = Properties.Settings.Default.ModesEnabled;
            dlg.ModesEnabled = Properties.Settings.Default.ModesEnabled && Main.EnableModes;
            dlg.localDbServerName = Properties.Settings.Default.ModesLocalDbServerName;
            
            
                dlg.ShowDialog();
            
            //cancel
            if (dlg.boolFlagCancelar)
            {
                dlg.Dispose();
                dlg = null;
                return false;
            }

            //make sure we are connected
            if (!dlg.flagServidorSQLConectado)
            {
                dlg.Dispose();
                dlg = null;
                this.Close();
                return false;
            }

            Properties.Settings.Default.SQLServidorNombre = dlg.strNombreServidorSQL;
            //Properties.Settings.Default.NombreBaseDeDatos = dlg.strNombreBaseDeDatos;
            Properties.Settings.Default.SQLServidorConectado = dlg.flagServidorSQLConectado;
            Properties.Settings.Default.SQLAutentificacion = dlg.shortAutentificacion;
            Properties.Settings.Default.SQLUsuarioNombre = dlg.strSQLUsuario;
            if (dlg.boolSQLRecuerda)
                Properties.Settings.Default.SQLUsuarioClave = dlg.strSQLClave;
            else
                Properties.Settings.Default.SQLUsuarioClave = "";
            Properties.Settings.Default.SQLRecuerdame = dlg.boolSQLRecuerda;
            Properties.Settings.Default.RuntimeConnectString = dlg.strConnectionString;
            Properties.Settings.Default.RuntimeDbConnectString = dlg.strConnectionString;

            if (!(Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName)
                )
            {
                Properties.Settings.Default.ModesConnectionString = dlg.strConnectionString;
                Properties.Settings.Default.ModesRecuerdame = Properties.Settings.Default.SQLRecuerdame;
                if (Properties.Settings.Default.SQLBaseDeDatos.ToLower() == "not connected")
                    Properties.Settings.Default.SQLBaseDeDatos = Properties.Settings.Default.BaseDeDatosPrincipal;
            }

            Properties.Settings.Default.Save();

            //To update ConnectionStrings for membership and roles providers
            Funciones.SetMembershipProviderConnectionString(dlg.strConnectionString);

            //show status
            toolStripStatusLabelServer.Text = Properties.Settings.Default.SQLServidorNombre;

            EnableOptions("Server");

            dlg.Dispose();
            dlg = null;

            return true;
        }

        private void EnableOptions(string objeto)
        {
            bool flag = false;
            if (objeto.ToLower() == "server")
            {
                //server connected
                flag = Properties.Settings.Default.SQLServidorConectado;
                //menuStripMain
                //File
                toolStripMenuItemLogin.Enabled = flag;

                //Tools
                toolStripMenuItemToolsServer.Enabled = flag;
                //toolStripMain
                toolStripUpperRightButtonLogin.Enabled = flag;
            }
            else if (objeto.ToLower() == "user")
            {
                //user logged in
                flag = IsAuthenticated;

                //menuStripMain
                //Tools
                toolStripMenuItemToolsUsers.Enabled = CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "GeUsuariosABC", false);
                toolStripMenuItemToolsRoles.Enabled = CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "GeGruposABC", false);
                toolStripMenuItemToolsMyAccount.Enabled = flag;

                //menuStripMain
                //Tools
                toolStripUpperRightButtonMyAccount.Enabled = flag;
            }
            else if (objeto.ToLower() == "database")
            {
                //database connected
                if (toolStripStatusEmpresa.Text.Trim() == "Not connected")
                    flag = false;
                else
                    flag = true;

                //menuStripMain;
                //Tools
                //toolStripMenuItemTools;
                toolStripMenuItemToolsSettings.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCambiarOpciones", false);
                //toolStripMenuItemToolsMessages.Enabled = flag
                //    &&
                //    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                //    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                //toolStripMenuItemToolsWorkStations.Enabled = flag
                //    &&
                //    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                //    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemToolsCategoryButtons.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCambiarOpciones", false);
                toolStripMenuItemToolsQuantityButtons.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCambiarOpciones", false);
                toolStripMenuItemToolsFees.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemToolsCashTrays.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemToolsCashDenominations.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemToolsExpenseTypes.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));


                toolStripMenuItemToolsUsers.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "GeUsuariosABC", false);
                toolStripMenuItemToolsRoles.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "GeGruposABC", false);
                toolStripMenuItemToolsMyAccount.Enabled = flag;
                toolStripMenuItemToolsBackup.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "GeRespaldar", false);
                toolStripMenuItemToolsRestore.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "GeRecuperar", false);
                toolStripMenuItemToolsDate.Enabled = flag;
                toolStripMenuItemToolsLogError.Enabled = flag;

                //Catalogs
                toolStripMenuItemCatalogsStandardDozen.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemCatalogsAgencies.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemCatalogsCategories.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemCatalogsContainers.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemCatalogsProducts.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false));
                toolStripMenuItemCatalogsCustomers.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));

                if(Properties.Settings.Default.StagingType == 0)    //!Properties.Settings.Default.MultiProductStagingEnabled)
                {
                    //toolStripSeparatorMultiProductStaging.Visible = false;
                    toolStripMenuItemCatalogsConveyors.Visible = false;
                    toolStripMenuItemCatalogsBagPosition.Visible = false;

                    toolStripMenuItemMultiProductStaging.Visible = false;
                }
                else
                {
                    toolStripMenuItemCatalogsConveyors.Enabled = flag
                        &&
                        (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));

                    toolStripMenuItemCatalogsBagPosition.Enabled = flag
                        &&
                        (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));

                    toolStripMenuItemMultiProductStaging.Enabled = flag
                        &&
                        (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                        || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));
                }

                //POS
                toolStripMenuItemPor.Enabled = flag;
                toolStripMenuItemReturns.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateChit", false);
                toolStripMenuItemSales.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateChit", false);
                toolStripMenuItemCashier.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", false);
                toolStripMenuItemXpressReturn.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", false);
                toolStripMenuItemXpressReturn.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", false);
                toolStripMenuItemCustomerScreen.Enabled = toolStripMenuItemReturns.Enabled;// flag;

                //Shipping
                toolStripMenuItemShipping.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolShipping", false);
                toolStripMenuItemShippingHome.Enabled = toolStripMenuItemShipping.Enabled;
                toolStripMenuItemShippingStagedContainers.Enabled = toolStripMenuItemShipping.Enabled;
                toolStripMenuItemShippingShipments.Enabled = toolStripMenuItemShipping.Enabled;
                toolStripMenuItemShippingAdjustments.Enabled = toolStripMenuItemShipping.Enabled && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAdjustShipment", false);
                toolStripMenuItemShippingLookup.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", false);

                //Inventory
                toolStripMenuItemInventory.Enabled = flag 
                    && 
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewProducts", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewSupplies", false));
                toolStripMenuItemInventoryProducts.Enabled = CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewProducts", false);
                toolStripMenuItemInventorySupplies.Enabled = CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewSupplies", false);

                //Accounting
                //toolStripMenuItemAccounting.Enabled = flag;
                toolStripMenuItemAccountingOpenCashier.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolOpenCashier", false);
                toolStripButtonOpenCashier.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolOpenCashier", false);
                ToolStripMenuItemAccountingFloat.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddFloat", false);
                toolStripButtonAddFloat.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddFloat", false);
                ToolStripMenuItemAccountingCloseCashier.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCloseCashier", false);
                toolStripButtonCloseCashier.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCloseCashier", false);
                toolStripMenuItemAccountingExpenses.Enabled = flag && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddExpenses", false);
                toolStripMenuItemAccountingEntriesManager.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewEntries", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditEntries", false));
                toolStripMenuItemAccountingCustomerAccountManagement.Enabled = flag
                    &&
                    (CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
                    || CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false));

                toolStripMenuItemAccounting.Enabled = toolStripMenuItemAccountingOpenCashier.Enabled
                    || ToolStripMenuItemAccountingFloat.Enabled
                    || ToolStripMenuItemAccountingCloseCashier.Enabled
                    || toolStripMenuItemAccountingExpenses.Enabled
                    || toolStripMenuItemAccountingEntriesManager.Enabled
                    || toolStripMenuItemAccountingCustomerAccountManagement.Enabled;

                toolStripMenuItemReports.Enabled = flag;
                toolStripButtonReports.Enabled = flag;

                //help
                toolStripMenuItemCheckUpdates.Enabled = true && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUpdateVersion", false);
                toolStripMenuItemCreateTrainingDatabase.Enabled = flag;
                //toolStripMenuItemUseTrainingMode.Enabled = flag;
                toolStripMenuItemUseTrainingMode.Enabled = true && CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUseTraining", false); ;

                //toolStripMain;
                //toolBar
                toolStripButtonSettings.Enabled = toolStripMenuItemToolsSettings.Enabled;
                toolStripUpperRightButtonMyAccount.Enabled = toolStripMenuItemToolsMyAccount.Enabled;
                toolStripButtonReturns.Enabled = toolStripMenuItemReturns.Enabled;
                //toolStripButtonSales.Enabled = toolStripMenuItemSales.Enabled;
                toolStripButtonCashier.Enabled = toolStripMenuItemCashier.Enabled;

                toolStripButtonXpressReturn.Enabled = toolStripMenuItemXpressReturn.Enabled;

                toolStripButtonShipping.Enabled = toolStripMenuItemShipping.Enabled;
                toolStripLabelDate.Enabled = flag;
                //toolStripButtonAttendance.Enabled = flag & Attendance_Enabled;

            }
        }


        private bool ChecarTablasPorSistema(
            SqlConnection connection,
            SqlCommand command,
            string commandText,
            string mensajeCrearTablas,
            string script1,
            string script2,
            string script3,
            string script4,
            string mensajeErrorCrearTablas

            )
        {
            bool boolExistenTablas = true;

            command.CommandText = commandText;  //"SELECT COUNT(*) FROM " + Properties.Resources.Prefijo + "_Control ";
            try
            {
                //connection.Open();
                ////command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                reader.Read();
                int nr = reader.GetInt32(0);
                reader.Close();
                //if (nr < 1)
                //    boolExistenTablas = false;

            }
            catch
            {
                boolExistenTablas = false;
            }

            //create tables
            if (boolExistenTablas)
                return true;


            //preguntar si desea crear las tablas
            //DialogResult result = MessageBox.Show(mensajeCrearTablas, "", MessageBoxButtons.YesNo);
            //if (result != System.Windows.Forms.DialogResult.Yes)
            //{
            //    return false;
            //}

            //try
            //{
            if (!SirLib.Empresas.CrearTablas(
                connection,
                command,
                AssemblyVersion,
                script1,  //Properties.Resources._1_CrearTablas,
                script2,  //Properties.Resources._2_CrearStoredProcedures,
                script3,  //Properties.Resources._6_InitialData,
                script4
                ))
            {
                //CajaDeMensaje.Show("", mensajeErrorCrearTablas, "", CajaDeMensajeImagen.Error);
                MessageBox.Show(mensajeErrorCrearTablas, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            CreateData(Properties.Settings.Default.WsirDbConnectionString, false);

            return true;
        }


        private void IniciarSesion()
        {
            //CultureInfo culture = CultureManager.ApplicationUICulture;
            IsAuthenticated = false;

            //menuGeneral.Items["menuGeneralIniciarSesion"].Text = RecursoLocal.SesionIniciar;
            toolStripMenuItemLogin.Text = "&Log In";
            //toolStripButtonLogin.ToolTipText = "Log In";

            //statusStrip1.Visible = false;
            //menuStrip1.Visible = false;
            //menuStrip2.Visible = false;

            statusStripMainHeaderLabelUser.Text = "Guest";

            Login2 dlg = new Login2(Properties.Settings.Default.TouchOriented, false, "Login", "Enter your credentials please");
            dlg.Usuario = Properties.Settings.Default.LoginUsuarioNombre;
            dlg.Recuerdame = Properties.Settings.Default.LoginUsuarioRecuerdame;
            dlg.IsAuthenticated = IsAuthenticated;
            dlg.ShowDialog();
            //dlg.MdiParent = this;
            //dlg.Show();

            if (!IsAuthenticated)
                Properties.Settings.Default.UsuarioNombre = String.Empty;

            Properties.Settings.Default.LoginUsuarioNombre = dlg.Usuario;
            Properties.Settings.Default.LoginUsuarioRecuerdame = dlg.Recuerdame;
            IsAuthenticated = dlg.IsAuthenticated;
            Properties.Settings.Default.Save();

            //salimos si no hay usuario en sesion
            if (IsAuthenticated)
            {
                toolStripMenuItemLogin.Text = "Log &Out";
                //toolStripButtonLogin.ToolTipText = "Log Out";

                //menuStrip1
                //menuStrip1.Visible = false;

                //statusStrip
                //statusStrip1.Visible = true;

                statusStripMainHeaderLabelUser.Text = dlg.Usuario;

                MembershipUser user = Membership.GetUser(dlg.Usuario);
                GenericIdentity identity = new GenericIdentity(user.UserName);
                RolePrincipal principal = new RolePrincipal(identity);
                System.Threading.Thread.CurrentPrincipal = principal;


                //grabar propiedades
                Properties.Settings.Default.UsuarioNombre = dlg.Usuario;
                //Properties.Settings.Default.UsuarioRol = rol;
                Properties.Settings.Default.Save();

                //asignar fromEmail para correos a soporte
                //SirLib.ExcepcionesNoControladas.maFromMail = new MailAddress(user.Email, user.UserName);
                SirLib.ExcepcionesNoControladas.FromMail = user.Email;


            }

            EnableOptions("user");
            dlg.Dispose();
            dlg = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="boolPreguntar"></param>
        /// <param name="Consultar"></param>
        private void SeleccionarEmpresa(string empresa, bool boolPreguntar, bool Consultar)
        {

            //checar existencia de db y tablas del sistema
            if (empresa.Length > 0 && !boolPreguntar)
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirConnectionString); //Properties.Settings.Default.ConnectionString);

                SqlCommand command = new SqlCommand("", connection);
                try
                {
                    connection.Open();

                    //checar si existe y si tiene las tablas
                    command.CommandText = "USE " + empresa;    // Properties.Settings.Default.NombreBaseDeDatos;
                    command.ExecuteNonQuery();

                    //command.CommandText = "SELECT COUNT(*) AS Expr1 FROM lc_control";
                    ////command.ExecuteReader();
                    //SqlDataReader reader = command.ExecuteReader();
                    //// Call Read before accessing data.
                    //reader.Read();
                    //int nr = reader.GetInt32(0);
                    //reader.Close();
                    ////if (nr < 1)
                    ////    boolPreguntar = true;
                    //boolPreguntar = false;

                }
                catch
                {
                    boolPreguntar = true;
                    empresa = "";

                }

            }

            if (boolPreguntar)
            {
                SirLib.Empresas f1 = new SirLib.Empresas(
                    Properties.Settings.Default.WsirConnectionString,   //Properties.Settings.Default.ConnectionString,
                    empresa,    //Properties.Settings.Default.NombreBaseDeDatos,
                    AssemblyProduct.Substring(0, 2),   //"lc_controlc"
                    AssemblyVersion,
                    Properties.Resources._1_CrearTablas,
                    Properties.Resources._2_CrearStoredProcedures,
                    Properties.Resources._6_InitalData,  //null,
                    Consultar
                    );
                //f1.strConnectionString = Properties.Settings.Default.ConnectionString;
                f1.flagPreguntar = boolPreguntar;
                f1.ShowDialog();
                Properties.Settings.Default.SQLBaseDeDatos = f1.strNombreBaseDeDatos; 
                Properties.Settings.Default.Save();
                f1.Dispose();
                f1 = null;

            }

            //mostramos informacion del status
            toolStripStatusEmpresa.Text = Properties.Settings.Default.SQLBaseDeDatos;


            //se selecciono empresa
            if (String.IsNullOrEmpty(Properties.Settings.Default.SQLBaseDeDatos))
                Properties.Settings.Default.SQLBaseDeDatos = "Not connected";
            toolStripStatusEmpresa.Text = Properties.Settings.Default.SQLBaseDeDatos;


            if (toolStripStatusEmpresa.Text.Trim() != "Not connected")
            {
                //here I'm changing the stringconnection
                ChangeStringConnection(false);
                //string cs = Funciones.ConstruirStringConexion(
                //    Properties.Settings.Default.SQLServidorNombre,
                //    Properties.Settings.Default.SQLBaseDeDatos,
                //    Properties.Settings.Default.SQLAutentificacion,
                //    Properties.Settings.Default.SQLUsuarioNombre,
                //    Properties.Settings.Default.SQLUsuarioClave
                //    );

                //Properties.Settings.Default.RuntimeDbConnectString = cs;
                ////string c = Properties.Settings.Default.WsirDbConnectionString;

                //checar tablas
                if (!ChecarTablas())
                {
                    toolStripStatusEmpresa.Text = "Not connected";

                }
                else
                {
                    //mostramos informacion del status
                    toolStripStatusEmpresa.Text = Properties.Settings.Default.SQLBaseDeDatos;
                }

                //opciones
                //LeerOpciones(true);
            }
            //Close();

            EnableOptions("database");

            ////LeerOpciones(true);

        }


        //Check tables
        private bool ChecarTablas()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString);
            string query = "USE " + Properties.Settings.Default.SQLBaseDeDatos;
            SqlCommand command = new SqlCommand(query, connection);    //queryString, connection);

            string commandText = "SELECT COUNT(*) FROM SOL_Control ";
            string mensajeCrearTablas = "The tables for Solum do not exist. Do you want to create them?";
            string script1 = Properties.Resources._1_CrearTablas;
            string script2 = Properties.Resources._2_CrearStoredProcedures; //.Replace("[wsir_]", "[wsir_" + Properties.Settings.Default.SQLBaseDeDatos + "]");
            string script3 = Properties.Resources._6_InitalData;
            string script4 = "";
            string mensajeErrorCrearTablas = "Error creanting Solum's tables, check connections and try again please!";

            try
            {
                connection.Open();
            }
            catch
            {
                return false;
            }

            //pv
            if (ChecarTablasPorSistema(
                connection,
                command,
                commandText,
                mensajeCrearTablas,
                script1,
                script2,
                script3,
                script4,
                mensajeErrorCrearTablas))
            {
                //leer opciones y aplicar ultimo service pack si es necesario
                if (!LeerOpciones(true))
                {
                    //ActivarOpcionesMinimas();

                    return false;
                }
            }

            return true;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        private bool ActualizarConnectionStrings(string connectionStringName, string connectionString)
        {
            //ejemplo de connectionStringName = "Solum.Properties.Settings.WsirConnectionString"

            //esta es para actualizar ConnectionStrings en el app.config de ejecucion (para que funcione el membershipprovider)
            // Open App.Config of executable
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //leer valor grabado
                ConnectionStringsSection conStrings = config.ConnectionStrings as ConnectionStringsSection;
                string c = conStrings.ConnectionStrings[connectionStringName].ToString();

                // Add an Application Setting.
                config.ConnectionStrings.ConnectionStrings.Remove(connectionStringName);
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(connectionStringName, connectionString));

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");

                //reiniciar applicacion si hubo cambio de servidor...
                //if (dlg.strNombreServidorSQL != Properties.Settings.Default.NombreServidorSQL)
                //{
                    //MessageBox.Show("restart");
//#if (!DEBUG)
                    //System.Windows.Forms.Application.Restart();
//#else
                    //this.Close();
//#endif
                //}
            }
            catch
            {
                return false;
            }
            return true;
        }


        public string version
        {
            get
            {
                System.Reflection.Assembly _assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();
                string ourVersion = string.Empty;
                //if running the deployed application, you can get the version
                // from the ApplicationDeployment information. If you try
                // to access this when you are running in Visual Studio, it will not work.
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    ourVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                else
                {
                    if (_assemblyInfo != null)
                    {
                        ourVersion = _assemblyInfo.GetName().Version.ToString();
                    }
                }
                return ourVersion;

            }

        }

        public static void CreateData(string ConnectionString, bool TrainingMode)
        {
            CreateDefaultControlInfo(ConnectionString);

            //workstation
            Sol_WorkStation_Sp sol_WorkStation_Sp = new Sol_WorkStation_Sp(ConnectionString);
            Sol_WorkStation sol_WorkStation = new Sol_WorkStation();
            sol_WorkStation.Name = Main.myHostName;
            sol_WorkStation.Description = string.Empty;
            sol_WorkStation.Location = string.Empty;
            sol_WorkStation.ConveyorID = 1;
            sol_WorkStation_Sp.Insert(sol_WorkStation);

            //Agencies
            Sol_Agencie Sol_AgencyInfo = new Sol_Agencie();
            Sol_Agencie_Sp asp = new Sol_Agencie_Sp(ConnectionString);
            //Sol_TypeInfo.TypeID = 0;
            Sol_AgencyInfo.Name = "(none)";
            asp.Insert(Sol_AgencyInfo);

            Sol_ContainerType sol_ContainerType = new Sol_ContainerType();
            Sol_ContainerType_Sp sol_ContainerType_Sp = new Sol_ContainerType_Sp(ConnectionString);
            sol_ContainerType.Description = "Shipping Containers";
            sol_ContainerType_Sp.Insert(sol_ContainerType);
            sol_ContainerType.Description = "Shipping Supplies";
            sol_ContainerType_Sp.Insert(sol_ContainerType);
            sol_ContainerType.Description = "Others";
            sol_ContainerType_Sp.Insert(sol_ContainerType);

            //containers
            Sol_Container sol_Container = new Sol_Container();
            Sol_Container_Sp sol_Container_Sp = new Sol_Container_Sp(ConnectionString);
            //Sol_TypeInfo.TypeID = 0;
            sol_Container.Description = "(none)";
            sol_Container.ContainerTypeID = 1;
            sol_Container_Sp.Insert(sol_Container);

            //categories
            Sol_Category Sol_CategoryInfo = new Sol_Category();
            Sol_Category_Sp casp = new Sol_Category_Sp(ConnectionString);
            //Sol_TypeInfo.TypeID = 0;
            Sol_CategoryInfo.Description = "(none)";
            casp.Insert(Sol_CategoryInfo);

            //StandardDozen
            Sol_StandardDozen Sol_StandardDozenInfo = new Sol_StandardDozen();
            Sol_StandardDozen_Sp sdsp = new Sol_StandardDozen_Sp(ConnectionString);
            //Sol_TypeInfo.TypeID = 0;
            Sol_StandardDozenInfo.Quantity = 0;
            sdsp.Insert(Sol_StandardDozenInfo);

            //Customers
            Sol_Customer sol_Customer = new Sol_Customer();
            Sol_Customer_Sp sol_Customer_Sp = new Sol_Customer_Sp(ConnectionString);
            //Sol_TypeInfo.TypeID = 0;
            sol_Customer.Name = "(none)";
            sol_Customer.IsActive = true;
            sol_Customer.Password = string.Empty;
            sol_Customer.DepotID = string.Empty;
            sol_Customer.CardNumber = string.Empty;
            sol_Customer.CardTypeID = 0;
            sol_Customer.SolumCustomer= true;
            sol_Customer_Sp.Insert(sol_Customer);

            //Messages
            Sol_Message sol_Message = new Sol_Message();
            Sol_Message_Sp sol_Message_Sp = new Sol_Message_Sp(ConnectionString);
            sol_Message.Name = "(none)";
            sol_Message_Sp.Insert(sol_Message);

            //ExpenseTypes
            Sol_ExpenseType sol_ExpenseType = new Sol_ExpenseType();
            Sol_ExpenseType_Sp sol_ExpenseType_Sp = new Sol_ExpenseType_Sp(ConnectionString);
            sol_ExpenseType.Description = "<none>";
            sol_ExpenseType_Sp.Insert(sol_ExpenseType);

            //ExpenseTypes
            Sol_Fee sol_Fee = new Sol_Fee();
            Sol_Fee_Sp sol_Fee_Sp = new Sol_Fee_Sp(ConnectionString);
            sol_Fee.FeeDescription = "<none>";
            sol_Fee_Sp.Insert(sol_Fee);

            //CashTray
            Sol_CashTray sol_CashTray = new Sol_CashTray();
            Sol_CashTray_Sp sol_CashTray_Sp = new Sol_CashTray_Sp(ConnectionString);
            sol_CashTray.Description = "<default>";
            sol_CashTray_Sp.Insert(sol_CashTray);

            DialogResult result = MessageBox.Show("Do you want to add some sample data?", "", MessageBoxButtons.YesNo);

            //sample data
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //user groups
                //roles
                if (!TrainingMode)
                {
                    Roles.CreateRole("Front Staff");
                    Roles.CreateRole("Cashier");
                    Roles.CreateRole("Staging Staff");
                    Roles.CreateRole("Supervisor");
                    Roles.CreateRole("Manager");
                    Roles.CreateRole("Owner");
                }
                //control
                Sol_Control_Sp sp = new Sol_Control_Sp(ConnectionString);
                Sol_ControlInfo = sp.Select(1);
                Sol_ControlInfo.BusinessName = "Demo Bottle Depot";
                Sol_ControlInfo.LegalName = "Bottle Depot Corporation";
                Sol_ControlInfo.Address = "101 Eagle Crescent";
                Sol_ControlInfo.StoreNumber = 1;
                Sol_ControlInfo.City = "Banff";
                Sol_ControlInfo.State = "AB";
                Sol_ControlInfo.Country = "Canada";
                Sol_ControlInfo.PhoneNumber = "(403) 766-1234";

                Sol_ControlInfo.SacCashTrayID = -1;

                sp.Update(Sol_ControlInfo);

                //WorkStations
                //Sol_WorkStation Sol_WokStationInfo = new Sol_WorkStation();
                //Sol_WorkStation_Sp wssp = new Sol_WorkStation_Sp(ConnectionString);
                //Sol_WokStationInfo.Name = "Default";
                //wssp.Insert(Sol_WokStationInfo);

                //agencies
                Sol_AgencyInfo.Name = "BDL";    //1
                asp.Insert(Sol_AgencyInfo);
                Sol_AgencyInfo.Name = "ABCRC";
                asp.Insert(Sol_AgencyInfo);
                Sol_AgencyInfo.Name = "Ecorp Electronics";
                asp.Insert(Sol_AgencyInfo);

                //containers
                sol_Container.Description = "White Bags";
                sol_Container.ShortDescription = sol_Container.Description;
                sol_Container_Sp.Insert(sol_Container);

                sol_Container.Description = "Blue Bags";
                sol_Container.ShortDescription = sol_Container.Description;
                sol_Container_Sp.Insert(sol_Container);

                sol_Container.Description = "One Way Bags";
                sol_Container.ShortDescription = sol_Container.Description;
                sol_Container_Sp.Insert(sol_Container);

                sol_Container.Description = "ABCRC Pallets";
                sol_Container.ShortDescription = sol_Container.Description;
                sol_Container_Sp.Insert(sol_Container);

                sol_Container.Description = "Megabag";
                sol_Container.ShortDescription = sol_Container.Description;
                sol_Container_Sp.Insert(sol_Container);

                sol_Container.Description = "Utility Box";
                sol_Container.ShortDescription = sol_Container.Description;
                sol_Container_Sp.Insert(sol_Container);

                sol_Container.Description = "Pallets";
                sol_Container.ShortDescription = sol_Container.Description;
                sol_Container_Sp.Insert(sol_Container);

                //categories
                Sol_CategoryInfo.Description = "Aluminum Cans";
                Sol_CategoryInfo.RefundAmount = 0.10M;
                Sol_CategoryInfo.SubContainerQuantity = 0;
                casp.Insert(Sol_CategoryInfo);

                Sol_CategoryInfo.Description = "Beer ISO";
                Sol_CategoryInfo.RefundAmount = 0.15M;
                Sol_CategoryInfo.SubContainerQuantity = 0;
                casp.Insert(Sol_CategoryInfo);

                Sol_CategoryInfo.Description = "Clear Pet < 1L";
                Sol_CategoryInfo.RefundAmount = 0.20M;
                Sol_CategoryInfo.SubContainerQuantity = 0;
                casp.Insert(Sol_CategoryInfo);

                Sol_CategoryInfo.Description = "Glass < 1L";
                Sol_CategoryInfo.RefundAmount = 0.25M;
                Sol_CategoryInfo.SubContainerQuantity = 0;
                casp.Insert(Sol_CategoryInfo);

                Sol_CategoryInfo.Description = "Glass > 1L";
                Sol_CategoryInfo.RefundAmount = 0.30M;
                Sol_CategoryInfo.SubContainerQuantity = 0;
                casp.Insert(Sol_CategoryInfo);

                Sol_CategoryInfo.Description = "Plast Poly Metal < 1L";
                Sol_CategoryInfo.RefundAmount = 0.35M;
                Sol_CategoryInfo.SubContainerQuantity = 0;
                casp.Insert(Sol_CategoryInfo);

                Sol_CategoryInfo.Description = "Plast Poly Metal > 1L";
                Sol_CategoryInfo.RefundAmount = 0.40M;
                Sol_CategoryInfo.SubContainerQuantity = 0;
                casp.Insert(Sol_CategoryInfo);

                //StandardDozen
                Sol_StandardDozenInfo.Quantity = 10;
                sdsp.Insert(Sol_StandardDozenInfo);
                Sol_StandardDozenInfo.Quantity = 20;
                sdsp.Insert(Sol_StandardDozenInfo);
                Sol_StandardDozenInfo.Quantity = 120;
                sdsp.Insert(Sol_StandardDozenInfo);
                Sol_StandardDozenInfo.Quantity = 150;
                sdsp.Insert(Sol_StandardDozenInfo);

                //products
                Sol_Product Sol_ProductInfo = new Sol_Product();
                Sol_Product_Sp psp = new Sol_Product_Sp(ConnectionString);

                Sol_ProductInfo.UPC = "1006";
                Sol_ProductInfo.ProName = "Alum Cans";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.AgencyID = 2;
                Sol_ProductInfo.CategoryID = 1;
                Sol_ProductInfo.ContainerID = 1;
                Sol_ProductInfo.IsActive = true;
                Sol_ProductInfo.RefundAmount = 0.15m;
                Sol_ProductInfo.StandardDozenID = 1;
                Sol_ProductInfo.Price = 0.10m;
                Sol_ProductInfo.ProductCode = "1006";
                Sol_ProductInfo.HandlingCommissionAmount = 0.01010m;
                Sol_ProductInfo.VafAmount = 0.0102m;
                Sol_ProductInfo.TypeId = 0;             //returns
                psp.Insert(Sol_ProductInfo);

                Sol_ProductInfo.UPC = "4006";
                Sol_ProductInfo.ProName = "PET 0-1 L Clear";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.AgencyID = 2;
                Sol_ProductInfo.CategoryID = 3;
                Sol_ProductInfo.ContainerID = 2;
                Sol_ProductInfo.IsActive = true;
                Sol_ProductInfo.RefundAmount = 0.25m;
                Sol_ProductInfo.StandardDozenID = 1;
                Sol_ProductInfo.Price = 0.20m;
                Sol_ProductInfo.ProductCode = "4006";
                Sol_ProductInfo.HandlingCommissionAmount = 0.02010m;
                Sol_ProductInfo.VafAmount = 0.0202m;
                psp.Insert(Sol_ProductInfo);


                Sol_ProductInfo.UPC = "2006";
                Sol_ProductInfo.ProName = "Bi Metal O-1 L";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.AgencyID = 2;
                Sol_ProductInfo.CategoryID = 6;
                Sol_ProductInfo.ContainerID = 3;
                Sol_ProductInfo.IsActive = true;
                Sol_ProductInfo.RefundAmount = 0.35m;
                Sol_ProductInfo.StandardDozenID = 3;
                Sol_ProductInfo.Price = 0.30m;
                Sol_ProductInfo.ProductCode = "2006";
                Sol_ProductInfo.HandlingCommissionAmount = 0.03010m;
                Sol_ProductInfo.VafAmount = 0.0302m;
                psp.Insert(Sol_ProductInfo);

                Sol_ProductInfo.UPC = "1";
                Sol_ProductInfo.ProName = "Bi Metal Over 1 L";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.AgencyID = 1;
                Sol_ProductInfo.CategoryID = 7;
                Sol_ProductInfo.ContainerID = 5;
                Sol_ProductInfo.IsActive = true;
                Sol_ProductInfo.RefundAmount = 0.45m;
                Sol_ProductInfo.StandardDozenID = 3;
                Sol_ProductInfo.Price = 0.40m;
                Sol_ProductInfo.ProductCode = "2003";
                Sol_ProductInfo.HandlingCommissionAmount = 0.04010m;
                Sol_ProductInfo.VafAmount = 0.0402m;
                psp.Insert(Sol_ProductInfo);

                Sol_ProductInfo.UPC = "2";
                Sol_ProductInfo.ProName = "Beer Bottle ISB Glass";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.AgencyID = 1;
                Sol_ProductInfo.CategoryID = 2;
                Sol_ProductInfo.ContainerID = 6;
                Sol_ProductInfo.IsActive = true;
                Sol_ProductInfo.RefundAmount = 0.55m;
                Sol_ProductInfo.StandardDozenID = 1;
                Sol_ProductInfo.Price = 0.50m;
                Sol_ProductInfo.ProductCode = "3006";
                Sol_ProductInfo.HandlingCommissionAmount = 0.05010m;
                Sol_ProductInfo.VafAmount = 0.0502m;
                psp.Insert(Sol_ProductInfo);

                //sales
                Sol_ProductInfo.UPC = "1101";
                Sol_ProductInfo.ProName = "Coke";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.AgencyID = 0;           //none
                Sol_ProductInfo.CategoryID = 0;         //none
                Sol_ProductInfo.ContainerID = 0;        //none
                Sol_ProductInfo.IsActive = true;
                Sol_ProductInfo.RefundAmount = 0m;
                Sol_ProductInfo.StandardDozenID = 0;    //0
                Sol_ProductInfo.Price = 1.00m;
                Sol_ProductInfo.ProductCode = "101";
                Sol_ProductInfo.HandlingCommissionAmount = 0m;
                Sol_ProductInfo.VafAmount = 0m;
                Sol_ProductInfo.TypeId = 1;             //sales
                Sol_ProductInfo.Tax1Exempt = false;
                Sol_ProductInfo.Tax2Exempt = false;
                psp.Insert(Sol_ProductInfo);

                Sol_ProductInfo.UPC = "1102";
                Sol_ProductInfo.ProName = "Diet Coke";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.Price = 1.10m;
                Sol_ProductInfo.ProductCode = "102";
                Sol_ProductInfo.Tax1Exempt = true;
                psp.Insert(Sol_ProductInfo);

                Sol_ProductInfo.UPC = "1103";
                Sol_ProductInfo.ProName = "Potatoes Chips";
                Sol_ProductInfo.ProDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.ProShortDescription = Sol_ProductInfo.ProName;
                Sol_ProductInfo.Price = 0.65m;
                Sol_ProductInfo.ProductCode = "103";
                Sol_ProductInfo.Tax2Exempt = true;
                psp.Insert(Sol_ProductInfo);

                //CategoryButtons
                Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();
                Sol_CategoryButton_Sp sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(ConnectionString);
                //sol_CategoryButton.categoryButtonID;
                sol_CategoryButton.WorkStationID = -1;
                sol_CategoryButton.ControlType = 0;
                sol_CategoryButton.Description = "LESS 1 LITRE";
                sol_CategoryButton.DefaultQuantity = 0;
                sol_CategoryButton.CategoryID = 0;
                sol_CategoryButton.Font = "[Font: Name=Microsoft Sans Serif, Size=7.8, Units=3, GdiCharSet=0, GdiVerticalFont=False]";
                sol_CategoryButton.FontStyle = "Regular";
                sol_CategoryButton.ForeColor = "Color [ControlText]";
                sol_CategoryButton.BackColor = "Color [fff0f0f0]";  //"Color [Control]";
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.ControlType = 1;
                sol_CategoryButton.Description = "1 CAN";
                sol_CategoryButton.DefaultQuantity = 1;
                sol_CategoryButton.CategoryID = 1;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "12 CAN";
                sol_CategoryButton.DefaultQuantity = 12;
                sol_CategoryButton.CategoryID = 1;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "24 CAN";
                sol_CategoryButton.DefaultQuantity = 24;
                sol_CategoryButton.CategoryID = 1;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "1 CLEAR PET";
                sol_CategoryButton.DefaultQuantity = 1;
                sol_CategoryButton.CategoryID = 3;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "12 CLEAR PET";
                sol_CategoryButton.DefaultQuantity = 12;
                sol_CategoryButton.CategoryID = 3;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "24 CLEAR PET";
                sol_CategoryButton.DefaultQuantity = 24;
                sol_CategoryButton.CategoryID = 3;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "1 LESS LITRE";
                sol_CategoryButton.DefaultQuantity = 1;
                sol_CategoryButton.CategoryID = 6;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "12 LESS LITRE";
                sol_CategoryButton.DefaultQuantity = 12;
                sol_CategoryButton.CategoryID = 6;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "24 LESS LITRE";
                sol_CategoryButton.DefaultQuantity = 24;
                sol_CategoryButton.CategoryID = 6;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);


                sol_CategoryButton.ControlType = 0;
                sol_CategoryButton.Description = "OVER 1 LITRE";
                sol_CategoryButton.DefaultQuantity = 0;
                sol_CategoryButton.CategoryID = 0;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.ControlType = 1;
                sol_CategoryButton.Description = "1 OVER LITRE";
                sol_CategoryButton.DefaultQuantity = 1;
                sol_CategoryButton.CategoryID = 7;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "12 OVER LITRE";
                sol_CategoryButton.DefaultQuantity = 12;
                sol_CategoryButton.CategoryID = 7;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "24 OVER LITRE";
                sol_CategoryButton.DefaultQuantity = 24;
                sol_CategoryButton.CategoryID = 7;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.ControlType = 0;
                sol_CategoryButton.Description = "GLASS";
                sol_CategoryButton.DefaultQuantity = 0;
                sol_CategoryButton.CategoryID = 0;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.ControlType = 1;
                sol_CategoryButton.Description = "ISB 1 BEER";
                sol_CategoryButton.DefaultQuantity = 1;
                sol_CategoryButton.CategoryID = 2;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "ISB 12 BEER";
                sol_CategoryButton.DefaultQuantity = 12;
                sol_CategoryButton.CategoryID = 2;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                //newview buttons
                sol_CategoryButton.ControlType = 2;
                sol_CategoryButton.Description = "1 CAN";
                sol_CategoryButton.DefaultQuantity = 1;
                sol_CategoryButton.CategoryID = 1;
                sol_CategoryButton.ImageIndex = 3;
                sol_CategoryButton.SubContainerMaxCount = 0;
                sol_CategoryButton.LocationX = 0;
                sol_CategoryButton.LocationY = 0;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                sol_CategoryButton.Description = "";//1 CLEAR PET";
                sol_CategoryButton.CategoryID = 3;
                sol_CategoryButton.ImageIndex = 11;
                sol_CategoryButton.SubContainerMaxCount = 10;
                sol_CategoryButton.LocationX = 98;
                sol_CategoryButton.LocationY = 0;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                //sol_CategoryButton.Description = "1 LESS LITRE";
                sol_CategoryButton.CategoryID = 6;
                sol_CategoryButton.ImageIndex = 13;
                sol_CategoryButton.SubContainerMaxCount = 20;
                sol_CategoryButton.LocationX = 0;
                sol_CategoryButton.LocationY = 70;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

                //sol_CategoryButton.Description = "OVER 1 LITRE";
                sol_CategoryButton.DefaultQuantity = 1;
                sol_CategoryButton.CategoryID = 7;
                sol_CategoryButton.ImageIndex = 18;
                sol_CategoryButton.SubContainerMaxCount = 30;
                sol_CategoryButton.LocationX = 98;
                sol_CategoryButton.LocationY = 70;
                sol_CategoryButton_Sp.Insert2(sol_CategoryButton);


                //QuantitytButtons
                Sol_QuantityButton sol_QuantityButton = new Sol_QuantityButton();
                Sol_QuantityButton_Sp sol_QuantityButton_Sp = new Sol_QuantityButton_Sp(ConnectionString);
                //sol_QuantityButton.QuantityButtonID;
                sol_QuantityButton.WorkStationID = -1;
                sol_QuantityButton.ControlType = 1;
                sol_QuantityButton.Description = "2 X";
                sol_QuantityButton.DefaultQuantity = 2;
                sol_QuantityButton.CategoryID = 0;
                sol_QuantityButton.Font = "[Font: Name=Microsoft Sans Serif, Size=12, Units=3, GdiCharSet=0, GdiVerticalFont=False]";
                sol_QuantityButton.FontStyle = "Regular";
                sol_QuantityButton.ForeColor = "Color [ControlText]";
                sol_QuantityButton.BackColor = "Color [fff0f0f0]";  //"Color [Control]";
                sol_QuantityButton_Sp.Insert(sol_QuantityButton);

                sol_QuantityButton.Description = "6 X";
                sol_QuantityButton.DefaultQuantity = 6;
                sol_QuantityButton_Sp.Insert(sol_QuantityButton);

                sol_QuantityButton.Description = "12";
                sol_QuantityButton.DefaultQuantity = 12;
                sol_QuantityButton_Sp.Insert(sol_QuantityButton);

                sol_QuantityButton.Description = "24";
                sol_QuantityButton.DefaultQuantity = 24;
                sol_QuantityButton_Sp.Insert(sol_QuantityButton);

                sol_QuantityButton.Description = "50";
                sol_QuantityButton.DefaultQuantity = 50;
                sol_QuantityButton_Sp.Insert(sol_QuantityButton);

                //Messages
                sol_Message.Name = "Customer Screen";
                sol_Message.Description = "Sorry, no employee is logged on";
                sol_Message_Sp.Insert(sol_Message);
                sol_Message.Name = "Front Station";
                sol_Message.Description = "Please collect refund at Cashier\n\rThank you!";
                sol_Message_Sp.Insert(sol_Message);
                sol_Message.Name = "Cashier Routine";
                sol_Message.Description = "Take receipt to Cashier - Thanks!";
                sol_Message_Sp.Insert(sol_Message);
                sol_Message.Name = "Receipt";
                sol_Message.Description = "Thank you for visiting our store!";
                sol_Message_Sp.Insert(sol_Message);
                sol_Message.Name = "Station Open";
                sol_Message.Description = "WELCOME - Please open one bag at a time and place on counter";
                sol_Message_Sp.Insert(sol_Message);
                sol_Message.Name = "Station Close";
                sol_Message.Description = "This Station is Close - Please Use Another one!";
                sol_Message_Sp.Insert(sol_Message);
                sol_Message.Name = "Short Absence";
                sol_Message.Description = "I'll be right back - Thanks for your patience!";
                sol_Message_Sp.Insert(sol_Message);
                sol_Message.Name = "End of Day";
                sol_Message.Description = "Sorry  - We're Now Closed For the Day - Come Back Soon!";
                sol_Message_Sp.Insert(sol_Message);

                //ExpenseTypes
                sol_ExpenseType.Description = "Casual Labor";
                sol_ExpenseType_Sp.Insert(sol_ExpenseType);
                sol_ExpenseType.Description = "Staff Meal";
                sol_ExpenseType_Sp.Insert(sol_ExpenseType);
                sol_ExpenseType.Description = "Staff Travel";
                sol_ExpenseType_Sp.Insert(sol_ExpenseType);
                sol_ExpenseType.Description = "Misc";
                sol_ExpenseType_Sp.Insert(sol_ExpenseType);

                //CashDenominations
                Sol_CashDenomination sol_CashDenomination = new Sol_CashDenomination();
                Sol_CashDenomination_Sp sol_CashDenomination_Sp = new Sol_CashDenomination_Sp(ConnectionString);
                sol_CashDenomination.CashType = 0;
                sol_CashDenomination.CashValue = 0.05m;
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination.Description = "Nickel";
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashType = 0;
                sol_CashDenomination.CashValue = 0.10m;
                sol_CashDenomination.Description = "Dime";
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination.CashType = 0;
                sol_CashDenomination.CashValue = 0.25m;
                sol_CashDenomination.Description = "Quarter";
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashType = 0;
                sol_CashDenomination.CashValue = 1.00m;
                sol_CashDenomination.Description = "Loonie";
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashType = 0;
                sol_CashDenomination.CashValue = 2.00m;
                sol_CashDenomination.Description = "Toonie";
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashType = 1;
                sol_CashDenomination.CashValue = 5.00m;
                sol_CashDenomination.Description = "Five Dollars";
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashType = 1;
                sol_CashDenomination.CashValue = 10.00m;
                sol_CashDenomination.Description = "Ten Dollars";
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashType = 1;
                sol_CashDenomination.CashValue = 20.00m;
                sol_CashDenomination.Description = "Twenty Dollars";
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);
                sol_CashDenomination.CashType = 1;
                sol_CashDenomination.CashValue = 50.00m;
                sol_CashDenomination.Description = "Fifty Dollars";
                sol_CashDenomination.CashItemValue = sol_CashDenomination.CashValue;
                sol_CashDenomination_Sp.Insert(sol_CashDenomination);

                //ExpenseTypes
                sol_Fee.FeeDescription = "Pickup Fee";
                sol_Fee.FeeAmount = 0.50m;
                sol_Fee_Sp.Insert(sol_Fee);
            }
        }


        public static void CreateDefaultControlInfo(string ConnectionString)
        {
            Sol_ControlInfo = new Sol_Control();
            Sol_ControlInfo.ControlID = 1;
            Sol_ControlInfo.BusinessName = "";
            Sol_ControlInfo.LegalName = "";
            Sol_ControlInfo.Address = "";
            Sol_ControlInfo.StoreNumber = 0;
            Sol_ControlInfo.City = "";
            Sol_ControlInfo.State = "";
            Sol_ControlInfo.Country = "";
            Sol_ControlInfo.PhoneNumber = "";
            Sol_ControlInfo.BusinessHoursFrom = DateTime.Parse("09:00:00");
            Sol_ControlInfo.BusinessHoursTo = DateTime.Parse("17:30:00");
            Sol_ControlInfo.BusinessHoursFromTue = DateTime.Parse("09:00:00");
            Sol_ControlInfo.BusinessHoursToTue = DateTime.Parse("17:30:00");
            Sol_ControlInfo.BusinessHoursFromWed = DateTime.Parse("09:00:00");
            Sol_ControlInfo.BusinessHoursToWed = DateTime.Parse("17:30:00");
            Sol_ControlInfo.BusinessHoursFromThu = DateTime.Parse("09:00:00");
            Sol_ControlInfo.BusinessHoursToThu = DateTime.Parse("17:30:00");
            Sol_ControlInfo.BusinessHoursFromFri = DateTime.Parse("09:00:00");
            Sol_ControlInfo.BusinessHoursToFri = DateTime.Parse("17:30:00");
            Sol_ControlInfo.BusinessHoursFromSat = DateTime.Parse("09:00:00");
            Sol_ControlInfo.BusinessHoursToSat = DateTime.Parse("17:30:00");
            Sol_ControlInfo.BusinessHoursFromSun = DateTime.Parse("09:00:00");
            Sol_ControlInfo.BusinessHoursToSun = DateTime.Parse("13:00:00");
            Sol_ControlInfo.IdFiscal1Name = "";
            Sol_ControlInfo.IdFiscal1Value = "";
            Sol_ControlInfo.IdFiscal2Name = "";
            Sol_ControlInfo.IdFiscal2Value = "";
            Sol_ControlInfo.SMTPServer = "";
            Sol_ControlInfo.SMTPPort = 0;
            Sol_ControlInfo.EmailAccount = "";
            Sol_ControlInfo.EmailPassword = "";
            Sol_ControlInfo.WorkStationID = -1;

            Sol_ControlInfo.FiscalYearInitialMonth = 1;
            Sol_ControlInfo.HistoryYears = 3;
            Sol_ControlInfo.DatabaseVersion = DatabaseVersion;
            Sol_ControlInfo.NumericKeyPadOn = true;
            Sol_ControlInfo.NumericKeyPadPosition = 0;
            Sol_ControlInfo.Tax1Name = "GST";
            Sol_ControlInfo.Tax1Rate = 5m;
            Sol_ControlInfo.Tax1Name = "PST";
            Sol_ControlInfo.Tax1Rate = 3m;
            Sol_ControlInfo.Status = "N";
            Sol_ControlInfo.WebBrowserUrl = "http://Solum.ca/resources/dashboard.php?Depot=";
            Sol_ControlInfo.DefaultAgencyID = 0;
            Sol_ControlInfo.CategoryButtonsPanelBgColor = -16777216;
            //Sol_ControlInfo.WebBrowserUpdateHistoryUrl = "http://forum.Solum.winsir.net/default.aspx?g=posts&m=9&#post9"; //version 1
            //Sol_ControlInfo.WebBrowserUpdateHistoryUrl = "http://forum.Solum.winsir.net/default.aspx?g=posts&t=28";         //version 2
            //Sol_ControlInfo.WebBrowserUpdateHistoryUrl = "http://forum.Solum.winsir.net/default.aspx?g=posts&t=32";
            Sol_ControlInfo.WebBrowserUpdateHistoryUrl = "http://forum.Solum.winsir.net/default.aspx?g=posts&t=33";
            Sol_ControlInfo.SacCashTrayID = -1;

            //Sol_Control_Sp sp = new Sol_Control_Sp("Solum.Properties.Settings.WsirDbConnectionString");
            Sol_Control_Sp sp = new Sol_Control_Sp(ConnectionString);
            try
            {
                sp.Insert(Sol_ControlInfo);
            }
            catch
            {
                //    try
                //    {
                sp.Update(Sol_ControlInfo);
                //    }
                //    catch { }

            }


            //options in settings
            Properties.Settings.Default.SettingsWsWorkStationName = myHostName;
            Properties.Settings.Default.SettingsDefaultCashTray = 0;
            Properties.Settings.Default.SettingsCurrentCashTray = 0;

            

            //read default printer
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            Properties.Settings.Default.SettingsWsReceiptPrinter = strDefaultPrinter;

            Properties.Settings.Default.SettingsWsTicketOpenDrawer =
                "27\r\n" +
                "112\r\n" +
                "48\r\n" +
                "100\r\n" +
                "100\r\n";

            Properties.Settings.Default.SettingsWsTicketCutPaper =
                "27\r\n" +
                "105\r\n";

            Properties.Settings.Default.SettingsWsReportPrinter = strDefaultPrinter;
            Properties.Settings.Default.SettingsWsLabelPrinter = strDefaultPrinter;

            //commands
            /*
             * {vendorId}
             * {productCode}
             * {quantity}
             * {tag}
             * {depotName}
             * {description}    of the product
             * {dozen}
             * {date}
             * {stageId}
            */

            //                          SettingsWsLabelCommands
            Properties.Settings.Default.SettingsWsLabelCommands =
                " \r\n" +
                "N\r\n" +
                "q609\r\n" +
                "Q400,30\r\n" +
                "B55,0,0,3,4,12,100,N,\"{tag}\"\r\n" +
                "A600,100,1,4,2,1,N,\"Banff Bottle\"\r\n" +
                "A530,100,1,4,2,1,N,\"      Depot\"\r\n" +
                "A475,100,1,3,1,1,N,\"TAG:\"\r\n" +
                "A450,110,1,3,3,2,N,\"{tag}\"\r\n" +
                "A375,110,1,3,2,1,N,\"{description}\"\r\n" +
                "A300,110,1,4,2,1,N,\"Doz:  {dozen}\"\r\n" +
                "A225,110,1,4,2,1,N,\"Items: {quantity}\"\r\n" +
                "A150,110,1,4,1,1,N,\"{date}\"\r\n" +
                "A75,120,1,3,1,1,N,\"StageID: {stageId}\"\r\n" +
                "P1,1\r\n";

            Properties.Settings.Default.SettingsSecurityEnableUnPay = true;
            Properties.Settings.Default.SettingsSecurityApprovalUnPay = true;

            

            //Solum settings
            Properties.Settings.Default.Save();


        }

        private void ChecarActivacion()
        {
            //sasExpiredTrial = false;
            System.Windows.Forms.Form form = this;
            //product info
            DataStore ds = SirLib.sas.ChecarActivacion(
                ref form,
                "WinSir_Solum2",
                "Demo",
                true,
                "Demo license level.",
                0.00m,
                "Standard",
                false,
                "Standard license level.",
                7999.00m,
                "Premiun",
                false,
                "",
                0.00m,
                30,
                "Solum - Point Of Return (V2)",
                "Solum2012",
                "USD",
                true
                );

            //if the user is not registered then display a reminder
            if (ds.UserRegistered)
            {
                //sasUserRegistered = true;
                toolStripMenuItemRegister.Text = "&Registered";
                toolStripMenuItemRegister.ToolTipText = "Registered";
                toolStripMenuItemRegister.Enabled = false;
            }

            //if the product is activated
            if (ds.GetProductState == ProductState.Activated)
            {
                //sasActivated = true;
                toolStripMenuItemActivate.Text = "&Activated";
                toolStripMenuItemActivate.ToolTipText = "Activated";
                toolStripMenuItemActivate.Enabled = false;

                //if the product is activated at a premium level as configured in the server database
                if (ds.GetProductState == ProductState.Activated && ds.GetLicenseLevel.LicenseLevel == "Premium")
                {
                    //enable your premium features here
                    // MessageBox.Show("You own premium app");
                }
            }
            //detect the trial period has expired
            else if (ds.GetProductState == ProductState.ExpiredTrial)
            {
                //    int numberOfDaysInstalled = ds.DaysElapsedSinceInstall;
                //sasExpiredTrial = true;
                //toolStripButtonServer.Enabled = false;
                toolStripStatusLabelSSK.Text = ds.GetProductState.ToString();
            }
            else
            {
                //toolTip1.SetToolTip(this.buttonTrialVersion, "Trial Version");
                int numberOfDaysLeft = 30-ds.DaysElapsedSinceInstall;
                string m = ds.GetProductState.ToString();

                toolStripStatusLabelSSK.Text = ds.GetProductState.ToString() +String.Format(" - {0} days left", numberOfDaysLeft);
            }

        }

        //private void timer1_Tick(object sender, System.EventArgs e)
        //{
        //    DateTime t = DateTime.Now;
        //    Properties.Settings.Default.FechaActual = DateTime.Now;
        //    toolStripLabelDate.Text = Properties.Settings.Default.FechaActual.ToShortDateString();

        //}

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            if (!IsAuthenticated)
                return;

            //fill listbox
            Sol_EmployeesLog sol_EmployeesLog;
            if(sol_EmployeesLog_Sp == null)
                sol_EmployeesLog_Sp = new Sol_EmployeesLog_Sp(Properties.Settings.Default.WsirConnectionString);

            Sol_EmployeeLookup sol_EmployeesLookup = new Sol_EmployeeLookup();
            if(sol_Employee_Sp == null)
                sol_Employee_Sp = new Sol_Employee_Sp(Properties.Settings.Default.WsirConnectionString);

            List<Sol_EmployeeLookup> sol_EmployeeLookupList;    // = new List<Sol_EmployeeLookup>();
            sol_EmployeeLookupList = sol_Employee_Sp.SelectAllLookup();
            string[] str = new string[2];

            listView1.Items.Clear();
            foreach (Sol_EmployeeLookup emp in sol_EmployeeLookupList)
            {
                MembershipUser u = Membership.GetUser(emp.UserId);
                if (!u.IsApproved || u.IsLockedOut)
                    continue;

                ListViewItem itm;
                str[0] = emp.FullName;
                str[1] = "";

                string[] resultPunchDatesString = new string[2];

                //DateTime[] resultDate;
                try
                {
                    sol_EmployeesLog = sol_EmployeesLog_Sp.LastPunch(emp.UserId.ToString());
                    if (sol_EmployeesLog.PunchInTime.Year == 1753)
                        resultPunchDatesString[0] = "<none>";
                    else
                        resultPunchDatesString[0] = sol_EmployeesLog.PunchInTime.ToString();

                    if (sol_EmployeesLog.PunchOutTime.Year == 1753)
                        resultPunchDatesString[1] = "<none>";
                    else
                        resultPunchDatesString[1] = sol_EmployeesLog.PunchOutTime.ToString();
                }
                catch
                {
                    sol_EmployeesLog = new Sol_EmployeesLog();
                    sol_EmployeesLog.UserId = emp.UserId;
                    sol_EmployeesLog.PunchInTime = DateTime.Parse("1753-1-1 12:00:00");
                    sol_EmployeesLog.PunchOutTime = DateTime.Parse("1753-1-1 12:00:00");
                    resultPunchDatesString[0] = "<none>";
                    resultPunchDatesString[1] = "<none>";
                }

                //never punched in
                if (resultPunchDatesString[0] == "<none>" &&
                    resultPunchDatesString[1] == "<none>")
                {
                    str[1] = "-";
                }
                //punch out
                else if (resultPunchDatesString[1] != "<none>")
                {
                    str[1] = "Out";
                }
                //punch in
                else
                {
                    str[1] = "In";
                }

                itm = new ListViewItem(str);
                listView1.Items.Add(itm);
                listView1.Height = listView1.Height + 5;

            }

        }

        // Navigates to the given URL if it is valid.
        private void Navigate(String address)
        {

            //if (String.IsNullOrEmpty(address)) return;
            //if (address.Equals("about:blank")) return;

            if (String.IsNullOrEmpty(address))
            {
                address = "about:blank";
                return;
            }

            //if (!address.StartsWith("http://") &&
            //    !address.StartsWith("https://"))
            //{
            //    address = "http://" + address;
            //}

            try
            {
                //MessageBox.Show(webBrowser1.Version.ToString());
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                //return;

                if (!address.StartsWith("http://") &&
                    !address.StartsWith("https://"))
                {
                    address = "http://" + address;
                }

                try
                {
                    //webBrowser1

                    webBrowser1.Navigate(new Uri(address));
                }
                catch (System.UriFormatException)
                {
                    return;
                }

            }
        }


        //blinking mode
        public static void timerBlink_Tick(object sender, System.EventArgs e)
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

        private void CheckComputerRole()
        {
            if (!(IsAuthenticated)) // && Properties.Settings.Default.PermisoUsarAplicacion))
                return;

            


            //computer roles
            if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
                || Properties.Settings.Default.SettingComputerRole == 0   //full role
                ))
            {

                if (!CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", false))
                {
                    MessageBox.Show("This computer has a Cashier Role, but you don't have Cash Out permission, cannot continue.");
                    //close customerScreen if any
                    if (CustomerScreenForm != null)
                    {
                        CustomerScreenForm.Close();
                        CustomerScreenForm = null;
                        toolStripMenuItemCustomerScreen.Text = "C&ustomer Screen";
                    }

                    toolStripStatusEmpresa.Text = "Not connected";
                    IsAuthenticated = false;
                    Properties.Settings.Default.UsuarioNombre = String.Empty;
                    Properties.Settings.Default.Save();

                    EnableOptions("database");
                    //EnableOptions("user");

                    return;
                }


                switch (Properties.Settings.Default.SettingComputerRole)
                {
                    case 0:     //full role
                        break;
                    case 1:     //Returns/Sales
                        toolStripMenuItemReturns.PerformClick();
                        break;
                    case 2:     //Cashier
                        toolStripMenuItemCashier.PerformClick();
                        break;
                    case 3:     //Shipping
                        toolStripButtonShipping.PerformClick();
                        break;
                    default:    //anything else
                        break;

                }
            }
        }

        public static bool CheckUserPermission(
            string strConnectionString,
            string userName,
            string permissionName,
            bool warn
            )
        {
            if (String.IsNullOrEmpty(userName))
            {
                if (warn)
                    MessageBox.Show("User name cannot be empty!");
                return false;
            }


            //is admin or an admin role memeber?
            if (userName == "admin" || Roles.IsUserInRole(userName, "admin"))
                return true;


            //does the permission exist?
            SirLib.wsir_Permisos_info pi = SirLib.wsir_Permisos.Buscar(strConnectionString, permissionName);
            if (String.IsNullOrEmpty(pi.PermisoNombreEnMinusculas.Trim()))
            {
                if (warn)
                    MessageBox.Show("Permission does not exist!");
                return false;
            }


            //the user has the permission?
            if (SirLib.wsir_PermisosEnUsers.Existe(strConnectionString, permissionName, userName))
                return true;

            //search in user roles' permissions
            try
            {
                string[] rolesArray;
                rolesArray = Roles.GetRolesForUser(userName);
                foreach (string role in rolesArray)
                {
                    //is an admin role member?
                    if (role == "admin")
                        return true;


                    //has a role permission
                    if (SirLib.wsir_PermisosEnRoles.Existe(strConnectionString, permissionName, role))
                            return true;

                }
            }
            catch
            {
                //
            }


            //permission not found
            if (warn)
                MessageBox.Show("Sorry, you don't have permission to " + pi.Descripcion);
            return false;
        }

        #endregion

        #endregion

        #region UsbHid Methods
        ///  <summary>
        ///  Called when a WM_DEVICECHANGE message has arrived,
        ///  indicating that a device has been attached or removed.
        ///  </summary>
        ///  
        ///  <param name="m"> a message with information about the device </param>

        internal void OnDeviceChange(Message m)
        {
            //try
            //{
                if ((m.WParam.ToInt32() == DeviceManagement.DBT_DEVICEARRIVAL))
                {
                    //  If WParam contains DBT_DEVICEARRIVAL, a device has been attached.
                    //  Find out if it's the device we're communicating with.

                    if (MyDeviceManagement.DeviceNameMatch(m, myDevicePathName))
                    {
                        toolStripStatusLabelMsrMessage.Text = "attached.";
                        strMsrMessage = toolStripStatusLabelMsrMessage.Text;

                    }

                }
                else if ((m.WParam.ToInt32() == DeviceManagement.DBT_DEVICEREMOVECOMPLETE))
                {

                    //  If WParam contains DBT_DEVICEREMOVAL, a device has been removed.
                    //  Find out if it's the device we're communicating with.

                    if (MyDeviceManagement.DeviceNameMatch(m, myDevicePathName))
                    {

                        toolStripStatusLabelMsrMessage.Text = "removed.";
                        strMsrMessage = toolStripStatusLabelMsrMessage.Text;

                        //  Set MyDeviceDetected False so on the next data-transfer attempt,
                        //  FindTheHid() will be called to look for the device 
                        //  and get a new handle.
                        tmrContinuousDataCollect.Stop();
                        tmrContinuousDataCollect.Enabled = false;

                        //FrmMy.myDeviceDetected = false;
                        myDeviceDetected = false;
                    }
                }//}
            //catch (Exception ex)
            //{
            //    DisplayException(this.Name + " OnDeviceChange", ex);
            //    //throw;
            //}
        }

        ///  <summary>
        ///  Uses a series of API calls to locate a HID-class device
        ///  by its Vendor ID and Product ID.
        ///  </summary>
        ///          
        ///  <returns>
        ///   True if the device is detected, False if not detected.
        ///  </returns>

        private Boolean FindTheHid()
        {
            Boolean deviceFound = false;
            String[] devicePathName = new String[128];
            Guid hidGuid = Guid.Empty;
            Int32 memberIndex = 0;
            Int32 myProductID = 0;
            Int32 myVendorID = 0;
            Boolean success = false;

            try
            {
                myDeviceDetected = false;
                CloseCommunications();

                //  Get the device's Vendor ID and Product ID

                myVendorID = Main.CardReader_VID;
                myProductID = Main.CardReader_PID;
                //  ***
                //  API function: 'HidD_GetHidGuid
                //  Purpose: Retrieves the interface class GUID for the HID class.
                //  Accepts: 'A System.Guid object for storing the GUID.
                //  ***

                Hid.HidD_GetHidGuid(ref hidGuid);

                //  Fill an array with the device path names of all attached HIDs.
                deviceFound = MyDeviceManagement.FindDeviceFromGuid(hidGuid, ref devicePathName);

                //  If there is at least one HID, attempt to read the Vendor ID and Product ID
                //  of each device until there is a match or all devices have been examined.

                if (deviceFound)
                {
                    memberIndex = 0;

                    do
                    {
                        //  ***
                        //  API function:
                        //  CreateFile

                        //  Purpose:
                        //  Retrieves a handle to a device.

                        //  Accepts:
                        //  A device path name returned by SetupDiGetDeviceInterfaceDetail
                        //  The type of access requested (read/write).
                        //  FILE_SHARE attributes to allow other processes to access the device while this handle is open.
                        //  A Security structure or IntPtr.Zero. 
                        //  A creation disposition value. Use OPEN_EXISTING for devices.
                        //  Flags and attributes for files. Not used for devices.
                        //  Handle to a template file. Not used.

                        //  Returns: a handle without read or write access.
                        //  This enables obtaining information about all HIDs, even system
                        //  keyboards and mice. 
                        //  Separate handles are used for reading and writing.
                        //  ***

                        // Open the handle without read/write access to enable getting information about any HID, even system keyboards and mice.
                        hidHandle = FileIO.CreateFile(devicePathName[memberIndex], 0, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                        if (!hidHandle.IsInvalid)
                        {
                            //  The returned handle is valid, 
                            //  so find out if this is the device we're looking for.

                            //  Set the Size property of DeviceAttributes to the number of bytes in the structure.

                            MyHid.DeviceAttributes.Size = Marshal.SizeOf(MyHid.DeviceAttributes);

                            //  ***
                            //  API function:
                            //  HidD_GetAttributes

                            //  Purpose:
                            //  Retrieves a HIDD_ATTRIBUTES structure containing the Vendor ID, 
                            //  Product ID, and Product Version Number for a device.

                            //  Accepts:
                            //  A handle returned by CreateFile.
                            //  A pointer to receive a HIDD_ATTRIBUTES structure.

                            //  Returns:
                            //  True on success, False on failure.
                            //  ***                            

                            success = Hid.HidD_GetAttributes(hidHandle, ref MyHid.DeviceAttributes);

                            if (success)
                            {

                                //  Find out if the device matches the one we're looking for.
                                if ((MyHid.DeviceAttributes.VendorID == myVendorID) && (MyHid.DeviceAttributes.ProductID == myProductID))
                                {
                                    //  Display the information in form's list box.
                                    strMsrMessage = "was found.";

                                    myDeviceDetected = true;

                                    //  Save the DevicePathName for OnDeviceChange().
                                    myDevicePathName = devicePathName[memberIndex];
                                }
                                else
                                {
                                    //  It's not a match, so close the handle.

                                    myDeviceDetected = false;
                                    hidHandle.Close();
                                }
                            }
                            else
                            {
                                //  There was a problem in retrieving the information.

                                //Debug.WriteLine("  Error in filling HIDD_ATTRIBUTES structure.");
                                myDeviceDetected = false;
                                hidHandle.Close();
                            }
                        }

                        //  Keep looking until we find the device or there are no devices left to examine.

                        memberIndex = memberIndex + 1;
                    }
                    while (!((myDeviceDetected || (memberIndex == devicePathName.Length))));
                }

                if (myDeviceDetected)
                {
                    //  The device was detected.
                    //  Register to receive notifications if the device is removed or attached.

                    success = MyDeviceManagement.RegisterForDeviceNotifications(myDevicePathName, FrmMy.Handle, hidGuid, ref deviceNotificationHandle);

                    //  Learn the capabilities of the device.

                    MyHid.Capabilities = MyHid.GetDeviceCapabilities(hidHandle);

                    if (success)
                    {
                        //  Find out if the device is a system mouse or keyboard.

                        hidUsage = MyHid.GetHidUsage(MyHid.Capabilities);

                        //  Get the Input report buffer size.

                        GetInputReportBufferSize();

                        //Close the handle and reopen it with read/write access.

                        hidHandle.Close();
                        hidHandle = FileIO.CreateFile(myDevicePathName, FileIO.GENERIC_READ | FileIO.GENERIC_WRITE, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                        if (hidHandle.IsInvalid)
                        {
                            //exclusiveAccess = true;
                        }
                        else
                        {
                            if (MyHid.Capabilities.InputReportByteLength > 0)
                            {
                                //  Set the size of the Input report buffer. 

                                Byte[] inputReportBuffer = null;
                                inputReportBuffer = new Byte[MyHid.Capabilities.InputReportByteLength];

                                fileStreamDeviceData = new FileStream(hidHandle, FileAccess.Read | FileAccess.Write, inputReportBuffer.Length, false);
                            }

                            if (MyHid.Capabilities.OutputReportByteLength > 0)
                            {
                                Byte[] outputReportBuffer = null;
                                outputReportBuffer = new Byte[MyHid.Capabilities.OutputReportByteLength];
                            }

                            //  Flush any waiting reports in the input buffer. (optional)

                            MyHid.FlushQueue(hidHandle);
                        }
                    }
                }
                else
                {
                    //  The device wasn't detected.

                    strMsrMessage = "not found.";

                }
                return myDeviceDetected;
            }
            catch (Exception ex)
            {
                DisplayException(this.Name + " FindTheHid", ex);
                //throw;
            }

            return false;
        }

        ///  <summary>
        ///  Performs various application-specific functions that
        ///  involve accessing the application's form.
        ///  </summary>
        ///  
        ///  <param name="action"> a String that names the action to perform on the form</param>
        ///  <param name="formText"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter. </param>

        private void AccessForm(String action, String formText)
        {
            //try
            //{
                //  Select an action to perform on the form:
                switch (action)
                {
                    case "toolStripStatusLabelMsrMessage":
                        strMsrMessage = formText;
                        break;
                    default:
                        break;
                }
            //}
            //catch (Exception ex)
            //{
            //    DisplayException(this.Name + " AccessForm", ex);
            //    //throw;
            //}
        }

        /// <summary>
        /// Close the handle and FileStreams for a device.
        /// </summary>
        /// 
        private void CloseCommunications()
        {
            if (fileStreamDeviceData != null)
            {
                fileStreamDeviceData.Close();
            }

            if ((hidHandle != null) && (!(hidHandle.IsInvalid)))
            {
                hidHandle.Close();
            }

            // The next attempt to communicate will get new handles and FileStreams.
            myDeviceDetected = false;
        }


        ///  <summary>
        ///  Set the number of Input reports the host will store.
        ///  </summary>
        /// if i remove this it gives an error ???
        private void cmdInputReportBufferSize_Click(System.Object sender, System.EventArgs e)
        {
            //try
            //{
                SetInputReportBufferSize();
            //}
            //catch (Exception ex)
            //{
            //    DisplayException(this.Name + " AccessForm", ex);
            //    //throw;
            //}
        }

        ///  <summary>
        ///  Called if the user changes the Vendor ID or Product ID in the text box.
        ///  </summary>

        private void DeviceHasChanged()
        {
            //try
            //{
                //  If a device was previously detected, stop receiving notifications about it.
                if (myDeviceDetected)
                {
                    MyDeviceManagement.StopReceivingDeviceNotifications(deviceNotificationHandle);

                    CloseCommunications();
                    //HidMethods.CloseCommunications(
                    //    ref myDeviceDetected
                    //    , ref fileStreamDeviceData
                    //    , ref hidHandle
                    //    );
                }
                    
            //}
            //catch (Exception ex)
            //{
            //    DisplayException(this.Name+" DeviceHasChanged", ex);
            //    //throw;
            //}
        }


        ///  <summary>
        ///  Sends an Output report, then retrieves an Input report.
        ///  Assumes report ID = 0 for both reports.
        ///  </summary>

        private void ExchangeInputAndOutputReports()
        {
            Byte[] inputReportBuffer = null;
            try
            {
                //  Don't attempt to exchange reports if valid handles aren't available
                //  (as for a mouse or keyboard under Windows 2000/XP.)

                if (!hidHandle.IsInvalid)
                {
                    //  Read an Input report.

                    //  Don't attempt to send an Input report if the HID has no Input report.
                    //  (The HID spec requires all HIDs to have an interrupt IN endpoint,
                    //  which suggests that all HIDs must support Input reports.)

                    if (MyHid.Capabilities.InputReportByteLength > 0)
                    {
                        //  Set the size of the Input report buffer. 

                        inputReportBuffer = new Byte[MyHid.Capabilities.InputReportByteLength];

                        //  Read a report using interrupt transfers.                
                        //  To enable reading a report without blocking the main thread, this
                        //  application uses an asynchronous delegate.

                        transferInProgress = true;

                        // Timeout if no report is available.

                        //tmrReadTimeout.Start();

                        if (fileStreamDeviceData.CanRead)
                        {
                            fileStreamDeviceData.BeginRead(inputReportBuffer, 0, inputReportBuffer.Length, new AsyncCallback(GetInputReportData), inputReportBuffer);
                        }
                        else
                        {
                            CloseCommunications();
                            //HidMethods.CloseCommunications(
                            //    ref myDeviceDetected
                            //    , ref fileStreamDeviceData
                            //    , ref hidHandle
                            //    );

                            toolStripStatusLabelMsrMessage.Text = "The attempt to read card has failed.";
                            strMsrMessage = toolStripStatusLabelMsrMessage.Text;


                        }
                    }
                    else
                    {
                        toolStripStatusLabelMsrMessage.Text = "The MSR doesn't have an Input report.";
                        strMsrMessage = toolStripStatusLabelMsrMessage.Text;
                    }
                }
                else
                {
                    toolStripStatusLabelMsrMessage.Text = "Invalid handle. The device is probably a system mouse or keyboard.";
                    strMsrMessage = toolStripStatusLabelMsrMessage.Text;
                }
            }
            catch (Exception ex)
            {
                DisplayException(this.Name + " ExchangeInputAndOutputReports", ex);
                //throw;
            }
        }

        ///  <summary>
        ///  Finds and displays the number of Input buffers
        ///  (the number of Input reports the host will store). 
        ///  </summary>

        private void GetInputReportBufferSize()
        {
            Int32 numberOfInputBuffers = 0;
            Boolean success;

            try
            {
                //  Get the number of input buffers.

                success = MyHid.GetNumberOfInputBuffers(hidHandle, ref numberOfInputBuffers);

                //  Display the result in the text box.

                txtInputReportBufferSize = Convert.ToString(numberOfInputBuffers);
            }
            catch (Exception ex)
            {
                DisplayException(this.Name + " GetInputReportBufferSize", ex);
                //throw;
            }
        }

        ///  <summary>
        ///  Retrieves Input report data and status information.
        ///  This routine is called automatically when myInputReport.Read
        ///  returns. Calls several marshaling routines to access the main form.
        ///  </summary>
        ///  
        ///  <param name="ar"> an object containing status information about 
        ///  the asynchronous operation. </param>

        private void GetInputReportData(IAsyncResult ar)
        {
            //read cardnumber

            Byte[] inputReportBuffer = null;
            try
            {


                inputReportBuffer = (byte[])ar.AsyncState;

                try
                {
                    fileStreamDeviceData.EndRead(ar);
                }
                catch 
                {
                    MyMarshalToForm("toolStripStatusLabelMsrMessage", "removed.");
                    //MessageBox.Show("The MSR device were removed!\r\n" +
                    //    "Please restart Solum.");
                    Funciones.DisplayAutoClosingMessageBox(
                        null,
                        "The MSR device were removed!\r\n Please restart Solum.",
                        Main.usbReadEventForm + " Screen",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        1000 * 5//FrontScreen.MessageTimeOut
                    );

                    return;
                }


                //tmrReadTimeout.Stop();

                string message = String.Empty;
                strMsrCardNumber = message;
                if (!(Main.usbReadEventForm == "Returns"
                    || Main.usbReadEventForm == "Cashier"
                    || Main.usbReadEventForm == "Customers")
                    )
                {
                    //  Enable requesting another transfer.
                    transferInProgress = false;
                    return;
                }

                if ((ar.IsCompleted))
                {

                    if (inputReportBuffer != null)
                    {
                        //string result = "Solum?;380000001497?;380000001497?";
                        string result = System.Text.UTF8Encoding.UTF8.GetString(inputReportBuffer);
                        if (SolFunctions.GetCardNumber(
                            result, 
                            ref strMsrCardNumber, 
                            Convert.ToChar(Main.CardReader_CharSeparator)))
                        {
                            //System.Media.SystemSounds.Beep.Play();
                            //message = String.Format("Card number: {0}\r\n", strMsrCardNumber);
                            //Funciones.DisplayAutoClosingMessageBox(
                            //    null,
                            //    message,
                            //    Main.usbReadEventForm + " Screen", //"Successful read",
                            //    MessageBoxButtons.OK,
                            //    MessageBoxIcon.None,
                            //    1000 * 2//FrontScreen.MessageTimeOut
                            //);


                            //  Enable requesting another transfer.
                            transferInProgress = false;
                            return;

                        }
                        else
                        {
                            //MyMarshalToForm("toolStripStatusLabelMsrMessage", "Try again please");
                            message = "Try again please";
                        }
                    }
                    else
                    {
                        //MyMarshalToForm("toolStripStatusLabelMsrMessage", "Try again please");
                        message = "Try again please";
                    }
                }
                else
                {
                    //MyMarshalToForm("toolStripStatusLabelMsrMessage", "The attempt to read an Input report has failed.");
                    message = "The attempt to read an Input report has failed.";
                }

                if (!String.IsNullOrEmpty(message))
                {
                    Funciones.DisplayAutoClosingMessageBox(
                        null,
                        message,
                        Main.usbReadEventForm+" Screen",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        1000 * 3//FrontScreen.MessageTimeOut
                    );
                    //strMsrMessage = message;

                }

                //  Enable requesting another transfer.
                transferInProgress = false;
            }
            catch (Exception ex)
            {
                DisplayException(this.Name + " GetInputReportData", ex);
                //throw;
            }
        }

        ///  <summary>
        ///  Enables accessing a form's controls from another thread 
        ///  </summary>
        ///  
        ///  <param name="action"> a String that names the action to perform on the form </param>
        ///  <param name="textToDisplay"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter.  </param>

        private void MyMarshalToForm(String action, String textToDisplay)
        {
            object[] args = { action, textToDisplay };
            MarshalToForm MarshalToFormDelegate = null;

            //  The AccessForm routine contains the code that accesses the form.

            MarshalToFormDelegate = new MarshalToForm(AccessForm);

            //  Execute AccessForm, passing the parameters in args.
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                    base.Invoke(MarshalToFormDelegate, args);
            }
        }

        ///  <summary>
        ///  Exchange data with the device.
        ///  </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        ///  <remarks>
        ///  The timer is enabled only if cmdContinous has been clicked, 
        ///  selecting continous (periodic) transfers.
        ///  </remarks>
        private void OnDataCollect(object source, ElapsedEventArgs e)
        {
            try
            {
                if (transferInProgress == false)
                {
                    ReadAndWriteToDevice();
                }
            }
            catch (Exception ex)
            {
                DisplayException(this.Name + " OnDataCollect", ex);
                //throw;
            }
        }

        /// <summary>
        /// ystem timer timeout if read via interrupt transfer doesn't return.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>

        private void OnReadTimeout(object source, ElapsedEventArgs e)
        {
            CloseCommunications();
            //HidMethods.CloseCommunications(
            //    ref myDeviceDetected
            //    , ref fileStreamDeviceData
            //    , ref hidHandle
            //    );

            //tmrReadTimeout.Stop();

            //  Enable requesting another transfer.

            //MyMarshalToForm("EnableCmdOnce", "");
        }

        ///  <summary>
        ///  Initiates exchanging reports. 
        ///  The application sends a report and requests to read a report.
        ///  </summary>

        private void ReadAndWriteToDevice()
        {

            try
            {
                //  If the device hasn't been detected, was removed, or timed out on a previous attempt
                //  to access it, look for the device.

                if ((myDeviceDetected == false))
                {
                    myDeviceDetected = FindTheHid();
                    //HidMethods.FindTheHid(
                    //    Main.CardReader_VID
                    //    , Main.CardReader_PID
                    //    , ref fmh
                    //    , ref deviceNotificationHandle
                    //    , ref exclusiveAccess
                    //    , ref hidUsage
                    //    , ref myDeviceDetected
                    //    , ref myDevicePathName
                    //    , ref fileStreamDeviceData
                    //    , ref hidHandle
                    //    , ref MyDeviceManagement
                    //    , ref MyHid
                    //    , ref resultMessage
                    //    , ref txtInputReportBufferSize
                    //);

                    //toolStripStatusLabelMsrMessage.Text = resultMessage;
                    //strMsrMessage = toolStripStatusLabelMsrMessage.Text;

                }

                if ((myDeviceDetected == true))
                {
                    ExchangeInputAndOutputReports();
                }
            }
            catch (Exception ex)
            {
                DisplayException(this.Name + " ReadAndWriteToDevice", ex);
                //throw;
            }
        }

        ///  <summary>
        ///  Set the number of Input buffers (the number of Input reports 
        ///  the host will store) from the value in the text box.
        ///  </summary>

        private void SetInputReportBufferSize()
        {
            Int32 numberOfInputBuffers = 0;

            try
            {
                //  Get the number of buffers from the text box.

                numberOfInputBuffers = Convert.ToInt32(Conversion.Val(txtInputReportBufferSize));

                //  Set the number of buffers.

                MyHid.SetNumberOfInputBuffers(hidHandle, numberOfInputBuffers);

                //  Verify and display the result.
                GetInputReportBufferSize();
                //HidMethods.GetInputReportBufferSize(
                //    ref exclusiveAccess
                //    , ref hidHandle
                //    , ref MyHid
                //    , ref txtInputReportBufferSize
                //    );
            }
            catch (Exception ex)
            {
                DisplayException(this.Name + " SetInputReportBufferSize", ex);
                //throw;
            }
        }

        ///  <summary>
        ///  Perform actions that must execute when the program ends.
        ///  </summary>

        private void Shutdown()
        {
            //try
            //{
                CloseCommunications();
            //HidMethods.CloseCommunications(
            //    ref myDeviceDetected
            //    , ref fileStreamDeviceData
            //    , ref hidHandle
            //    );

                //  Stop receiving notifications.

                MyDeviceManagement.StopReceivingDeviceNotifications(deviceNotificationHandle);
            //}
            //catch (Exception ex)
            //{
            //    DisplayException(this.Name + " Shutdown", ex);
            //    //throw;
            //}
        }

        ///  <summary>
        ///  Perform actions that must execute when the program starts.
        ///  </summary>

        private void Startup()
        {
            //try
            //{
                toolStripStatusLabelMsr.Visible = true;
                toolStripStatusLabelMsrMessage.Visible = true;

                MyHid = new Hid();

                tmrContinuousDataCollect = new System.Timers.Timer(1000);
                tmrContinuousDataCollect.Elapsed += new ElapsedEventHandler(OnDataCollect);
                tmrContinuousDataCollect.Stop();
                tmrContinuousDataCollect.SynchronizingObject = this;

                //tmrReadTimeout = new System.Timers.Timer(1000*3);			
                //tmrReadTimeout.Elapsed += new ElapsedEventHandler(OnReadTimeout);				
                //tmrReadTimeout.Stop();

            //}
            //catch (Exception ex)
            //{
            //    DisplayException(this.Name + " Startup", ex);
            //    //throw;
            //}
        }


        ///  <summary>
        ///  Finalize method.
        ///  </summary>

        ~Main()
        {
        }

        ///  <summary>
        ///   Overrides WndProc to enable checking for and handling WM_DEVICECHANGE messages.
        ///  </summary>
        ///  
        ///  <param name="m"> a Windows Message </param>

        //quitar - sin comentarios en produccion
        //protected override void WndProc(ref Message m)
        //{
        //    //try
        //    //{
        //    //  The OnDeviceChange routine processes WM_DEVICECHANGE messages.

        //    if (m.Msg == DeviceManagement.WM_DEVICECHANGE)
        //    {
        //        OnDeviceChange(m);
        //    }

        //    //  Let the base form process the message.

        //    base.WndProc(ref m);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    DisplayException(this.Name + " WndProc", ex);
        //    //    //throw;
        //    //}
        //}

        ///  <summary>
        ///  Provides a central mechanism for exception handling.
        ///  Displays a message box that describes the exception.
        ///  </summary>
        ///  
        ///  <param name="moduleName"> the module where the exception occurred. </param>
        ///  <param name="e"> the exception </param>

        internal static void DisplayException(String moduleName, Exception e)
        {
            String message = null;
            String caption = null;

            //  Create an error message.

            message = "Exception: " + e.Message + ControlChars.CrLf + "Module: " + moduleName + ControlChars.CrLf + "Method: " + e.TargetSite.Name;

            caption = "Unexpected Exception";

            MessageBox.Show(message, caption, MessageBoxButtons.OK);
            //Debug.Write(message);
        }

        //[STAThread]
        //internal static void Main() { Application.Run( new Returns() ); }       

        //private static Returns transDefaultFormReturns = null;
        //internal static Returns TransDefaultFormReturns
        //{ 
        //    get
        //    { 
        //        if (transDefaultFormReturns == null)
        //        {
        //            transDefaultFormReturns = new Returns();
        //        }
        //        return transDefaultFormReturns;
        //    } 
        //}

        #endregion

        #region Register use of Solum

        private void timerRegister_Tick(object sender, System.EventArgs e)
        {
            this.timerRegister.Enabled = false;

            //bwbilldispenser
            //bgWorkerRegister.WorkerReportsProgress = true;
            //bgWorkerRegister.WorkerSupportsCancellation = true;
            bgWorkerRegister.DoWork += new DoWorkEventHandler(bgWorkerRegister_DoWork);
            //bgWorkerRegister.ProgressChanged += new ProgressChangedEventHandler(bgWorkerRegister_ProgressChanged);
            bgWorkerRegister.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorkerRegister_RunWorkerCompleted);
            bgWorkerRegister.RunWorkerAsync();


        }

        private void bgWorkerRegister_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
            //for (int i = 1; (i <= 10); i++)
            //{
            //    if ((worker.CancellationPending == true))
            //    {
            //        e.Cancel = true;
            //        break;
            //    }

            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential("winsir", "win.747");
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("http://registration.solumsoft.com/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var Registration = new sol_Registration();

            try
            {
                Registration.DepotName = Sol_ControlInfo.BusinessName;
                Registration.DepotAddress =
                    String.Format("{0}, {1}, {2}, {3}"
                    , Sol_ControlInfo.Address.Trim()
                    , Sol_ControlInfo.City.Trim()
                    , Sol_ControlInfo.State.Trim()
                    , Main.Business_PostalCode
                    );
                if (Registration.DepotAddress.Length > 255)
                    Registration.DepotAddress = Registration.DepotAddress.Substring(0, 254);

            }
            catch
            {
                Registration.DepotName = "Not logged in";
                Registration.DepotAddress = "Not logged in";
            }
            if (myHostName == "rubito2-pc")
            {
                Registration.ComputerName = "mycomputername";
                Registration.Username = "myusername";
                Registration.IPAddress = "mypublicIP";
            }
            else if (myHostName == "kevin-pc")
            {
                Registration.ComputerName = "kevin's-computername";
                Registration.Username = "kevin's-username";
                Registration.IPAddress = "kevin's-publicIP";
            }
            else
            {
                Registration.ComputerName = myHostName;
                Registration.Username = Properties.Settings.Default.UsuarioNombre;
                Registration.IPAddress = GetMyPublicIP();
            }

            Registration.ProgramName = AssemblyTitle;
            Registration.ProgramVersion = versionNumber;

            try
            {
                //var response = client.PostAsJsonAsync("api/sol_registration", Registration).Result;

                //KEV changed this on March 1, 2019  Previous line wasn't compatible with .NET 4.5.2 and higher
                var response = client.PostAsync("sol_registration", new StringContent(new JavaScriptSerializer().Serialize(Registration), Encoding.UTF8, "application/json")).Result;

                //if (response.IsSuccessStatusCode)
                //{
                //    //MessageBox.Show("Registration Added");
                //    Funciones.DisplayAutoClosingMessageBox(
                //        null,
                //        "Registration Added",
                //        AssemblyTitle,
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Exclamation,
                //        1000 * 5//FrontScreen.MessageTimeOut
                //    );
                //}
                //else
                //{
                //    //MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                //    Funciones.DisplayAutoClosingMessageBox(
                //        null,
                //        "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase,
                //        AssemblyTitle,
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Exclamation,
                //        1000 * 5//FrontScreen.MessageTimeOut
                //    );
                //}
            }
            catch
            {
                //MessageBox.Show("Check your internet connection");
                //Funciones.DisplayAutoClosingMessageBox(
                //    null,
                //    "Check your internet connection please.",
                //    AssemblyTitle,
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Exclamation,
                //    1000 * 5//FrontScreen.MessageTimeOut
                //);

            }

        }

        private void bgWorkerRegister_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if ((e.Cancelled == true))
            //{
            //    this.tbProgress.Text = "Canceled!";
            //}

            //else if (!(e.Error == null))
            //{
            //    this.tbProgress.Text = ("Error: " + e.Error.Message);
            //}

            //else
            //{
            //    this.tbProgress.Text = "Done!";
            //}

            //flagBillDispenserWorking = false;

            if (sol_Setting_Sp == null)
                sol_Setting_Sp = new Sol_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //last registration date
            sol_Setting = sol_Setting_Sp.Select("Register_LastDate");
            sol_Setting.SetValue = rc.FechaActual;
            sol_Setting_Sp.Update(sol_Setting);

        }

        private void bgWorkerRegister_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
        }


        private string GetMyPrivateIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public string GetMyPublicIP()
        {
            String direction = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                direction = stream.ReadToEnd();
            }

            //Search for the ip in the html
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body>");
            direction = direction.Substring(first, last - first);

            return direction;
        }


        #endregion

        private void toolStripMainButton_MouseEnter(object sender, EventArgs e)
        {
            //toolStripButtonMyAccount.Image = Properties.Resources.Btn_MyAccount;
           //ToolStripButton b = (ToolStripButton)sender;
           //b.Image = b.BackgroundImage;
            
        }

        private void toolStripMainButton_MouseLeave(object sender, EventArgs e)
        {
            //toolStripButtonMyAccount.Image = null;
            //ToolStripButton b = (ToolStripButton)sender;
           //b.Image = null;
        }

        //moved to NewToolStripRenderer Class for global access
        /*private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                //var btn = e.Item as ToolStripButton;
                //if (btn != null && btn.CheckOnClick && btn.Checked)
                //{
                //    Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                //    e.Graphics.FillRectangle(Brushes.Olive, bounds);
                //    //Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                //    //e.Graphics.FillRectangle(Brushes.Transparent, rectangle);
                //    //e.Graphics.DrawRectangle(Pens.Transparent, rectangle);
                //}
                //else base.OnRenderButtonBackground(e);

                if (!e.Item.Selected)
                {
                    base.OnRenderButtonBackground(e);
                }
                else
                {
                    Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                    e.Graphics.FillRectangle(Brushes.Transparent, rectangle);
                    e.Graphics.DrawRectangle(Pens.Transparent, rectangle);
                    
                }

            }
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                //base.OnRenderToolStripBorder(e);
            }
            protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.ToolStrip.LayoutStyle == ToolStripLayoutStyle.VerticalStackWithOverflow)
                {
                    Rectangle rect = new Rectangle(0, 0, 75, 12);

                    e.Graphics.DrawImage(Properties.Resources.MoreWide, rect);
                }
                else if (e.ToolStrip.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow)
                {
                    Rectangle rect = new Rectangle(0, 0, 12, 75);

                    e.Graphics.DrawImage(Properties.Resources.MoreTall, rect);
                }
                else
                {
                    base.OnRenderOverflowButtonBackground(e);
                }


            }
            
        }*/

        private void toolStripButtonMore_Click(object sender, EventArgs e)
        {
            if (!menuStripMain.Visible)
            {
                menuStripMain.Visible = true;
                toolStripButtonMore.BackgroundImage = Properties.Resources.MoreSelected;
                
                //toolStripButtonMore.BackColor = Color.FromArgb(219, 174, 88);
                
            }
            else
            {
                menuStripMain.Visible = false;
                toolStripButtonMore.BackgroundImage = Properties.Resources.More;
                //toolStripButtonMore.BackColor = Color.Transparent;
            }
            if (toolStripButtonMore.Image != null) toolStripButtonMore.Image = toolStripButtonMore.BackgroundImage;
        }

        public static void ChangeStringConnection(bool changeTimeout)
        {
            //here I'm changing the stringconnection
            string cs = Funciones.ConstruirStringConexion(
                Properties.Settings.Default.SQLServidorNombre,
                Properties.Settings.Default.SQLBaseDeDatos,
                Properties.Settings.Default.SQLAutentificacion,
                Properties.Settings.Default.SQLUsuarioNombre,
                Properties.Settings.Default.SQLUsuarioClave
                );


            string dbSc = string.Empty;

            if (changeTimeout && SqlTimeout != 90)
            {
                cs = cs.Replace("Timeout=90;", string.Format("Timeout={0};", SqlTimeout) + ";");
                //dbSc = Properties.Settings.Default.RuntimeConnectString;
                //dbSc = dbSc.Replace("Timeout=90;", string.Format("Timeout={0};", SqlTimeout) + ";");
            }

            Properties.Settings.Default.RuntimeConnectString = cs;
            Properties.Settings.Default.RuntimeDbConnectString = cs;


            string c = Properties.Settings.Default.WsirDbConnectionString;

        }
    }

}
