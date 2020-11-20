
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Diagnostics;
using SirLib;

using System.Drawing.Printing;

using System.Collections;
using System.Reflection;

using System.Runtime.InteropServices;

//using System.Data.SqlLocalDb;  //KEV disabled LocalDb functions  #DISABLELOCALDB

namespace Solum
{
    public partial class Settings : Form
    {
        string OlderWorkStationName = string.Empty;
        Sol_WorkStation_Sp sol_WorkStation_Sp = null;

        //Qds_Drop qds_Drop;
        //Qds_Drop_Sp qds_Drop_Sp;

        Qds_PaymentMethodAvailableByDepot qds_PaymentMethodAvailableByDepot;
        //Qds_PaymentMethodAvailableByDepot_Sp qds_PaymentMethodAvailableByDepot_Sp;

        Qds_Setting qds_Setting;
        Qds_Setting_Sp qds_Setting_Sp;

        Sol_Setting sol_Setting;
        Sol_Setting_Sp sol_Setting_Sp;
        //List<Sol_Setting> sol_SettingList;
  
        //Sol_AutoNumber sol_AutoNumber;
        //Sol_AutoNumber_Sp sol_AutoNumber_Sp;

        #region tflex coin dispenser variables
        //private AxCOINUSBLib.AxCoinUSB AxCoinUSB2;
        //private short SUCCESS = 1;      //1 = success if a function worked

        #endregion

        bool firsTimeFlag;

        Label currentLabelContainerDescription;
        NumericTextBox currentNumericTextBoxContainerID;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
                 [MarshalAs(UnmanagedType.LPTStr)]
                   string path,
                 [MarshalAs(UnmanagedType.LPTStr)]
                   StringBuilder shortPath,
                 int shortPathLength
                 );

        [DllImport("gdi32", EntryPoint = "AddFontResource")]
        public static extern int AddFontResourceA(string lpFileName);
        [DllImport("gdi32", EntryPoint = "RemoveFontResource")]
        public static extern int RemoveFontResourceA(string lpFileName);

        //Sol_Control Sol_ControlInfo;

        public Settings()
        {
            InitializeComponent();

            //this.groupBoxModes.Visible = Main.EnableModes & (Properties.Settings.Default.SQLBaseDeDatos != Properties.Settings.Default.ModesLocalDbDatabaseName);

            string bd = Properties.Settings.Default.SQLBaseDeDatos;
            string ldb_bd = Properties.Settings.Default.ModesLocalDbDatabaseName;

            if (!(Main.EnableModes
                & (Properties.Settings.Default.SQLBaseDeDatos != Properties.Settings.Default.ModesLocalDbDatabaseName)
                ))
                tabControl1.TabPages.Remove(tabPageSQLModes);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            //sol_WorkStation_Sp = new Sol_WorkStation_Sp();

            // TODO: This line of code loads data into the 'dataSetConveyors.Vir_Conveyor_SelectAll' table. You can move, or remove it, as needed.
            this.vir_Conveyor_SelectAllTableAdapter.Fill(this.dataSetConveyors.Vir_Conveyor_SelectAll);
            firsTimeFlag = true;

            //disable form resizing
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = (Properties.Settings.Default.SettingsAdFullScreenMode) ? FormBorderStyle.None : FormBorderStyle.SizableToolWindow;
            this.WindowState = (Properties.Settings.Default.SettingsAdFullScreenMode) ? FormWindowState.Maximized : FormWindowState.Normal;

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            xpressReturnTabButton.Visible = false;

            generalTabButton.PerformClick();
            

            currentLabelContainerDescription = null;
            currentNumericTextBoxContainerID = null;

            // TODO: This line of code loads data into the 'dataSetContainersLookup.sol_Containers' table. You can move, or remove it, as needed.
            this.sol_ContainersTableAdapter.Fill(this.dataSetContainersLookup.sol_Containers);
            // TODO: This line of code loads data into the 'dataSetAgenciesLookup.sol_Agencies' table. You can move, or remove it, as needed.
            this.sol_AgenciesTableAdapter.Fill(this.dataSetAgenciesLookup.sol_Agencies);
            // TODO: This line of code loads data into the 'dataSetCashTrays.sol_CashTrays_SelectAll' table. You can move, or remove it, as needed.
            this.sol_CashTrays_SelectAllTableAdapter.Fill(this.dataSetCashTrays.sol_CashTrays_SelectAll);
            // TODO: This line of code loads data into the 'dataSetPlantsLookup.Sol_WS_Plants' table. You can move, or remove it, as needed.
            this.sol_WS_PlantsTableAdapter.Fill(this.dataSetPlantsLookup.Sol_WS_Plants);
            // TODO: This line of code loads data into the 'dataSetCarriersLookup.Sol_WS_Carriers' table. You can move, or remove it, as needed.
            this.sol_WS_CarriersTableAdapter.Fill(this.dataSetCarriersLookup.Sol_WS_Carriers);

            ////FullScreenMode
            //if (Properties.Settings.Default.SettingsAdFullScreenMode)
            //    this.WindowState = FormWindowState.Maximized;
            //else
            //    this.WindowState = FormWindowState.Normal;


            // TODO: This line of code loads data into the 'dataSetMessages.sol_Messages' table. You can move, or remove it, as needed.
            this.sol_MessagesTableAdapter.Fill(this.dataSetMessages.sol_Messages);
            // TODO: This line of code loads data into the 'dataSetMessageLookup.sol_Messages' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dataSetWorkStationsLookup.sol_WorkStations' table. You can move, or remove it, as needed.
            this.sol_WorkStationsTableAdapter.Fill(this.dataSetWorkStationsLookup.sol_WorkStations);
            if (Properties.Settings.Default.TouchOriented)
            {
                OK.Height = OK.Height * 2;
                Cancel.Height = Cancel.Height * 2;
                buttonApply.Height = buttonApply.Height * 2;
                //toolStripButtonVirtualKb.Visible = true;

            }

            this.Show();

            //tabControl1.TabPages[2].Hide(); // = true;

            //llenar combox de meses
            BindingList<MesesNombre> mesesNombre = new BindingList<MesesNombre>();
            Funciones.ObtenerMeses(ref mesesNombre);
            for (int i = 0; i < 12; i++)
                CGcomboBoxMesInicial.Items.Add(mesesNombre[i].Nombre);

            //how many displays
            // Add each property of the SystemInformation class to the list box.
            int monitorCount= System.Windows.Forms.SystemInformation.MonitorCount;
            numericUpDownCustomerScreenMonitor.Minimum = 0;
            numericUpDownCustomerScreenMonitor.Maximum = monitorCount - 1;
            if (monitorCount > 1)
            {
                //numericUpDownCustomerScreenMonitor.Maximum = monitorCount - 1;
                numericUpDownCustomerScreenMonitor.Value = 1;
            }
            else //if (monitorCount < 2)
            {
                //for (int i = 0; i < nm; i++)
                //    comboBoxDisplay.Items.Add(i.ToString());
                //groupBoxCustomerScreen.Enabled = false;
               // groupBoxCustomerScreen.Text = "Customer Screen - Only one monitor detected";

            }
           

            //leer opciones
            qds_Setting_Sp = new Qds_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_Setting_Sp = new Sol_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //sol_SettingList = sol_Setting_Sp.SelectAll();

            //Sol_Control
            //Sol_Control_Sp sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Sol_Control_Sp sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Main.Sol_ControlInfo = sp.Select(1);
            if (Main.Sol_ControlInfo != null)
            {
                //general
                GEtextBoxRazonSocial.Text = Main.Sol_ControlInfo.BusinessName;
                GEtextBoxRazonFiscal.Text = Main.Sol_ControlInfo.LegalName;
                GEtextBoxStoreNumber.Text = Main.Sol_ControlInfo.StoreNumber.ToString();
                GEtextBoxDireccion.Text = Main.Sol_ControlInfo.Address;
                GEtextBoxCiudad.Text = Main.Sol_ControlInfo.City;

                comboBoxProvince.SelectedItem = Main.Sol_ControlInfo.State;
                comboBoxProvinceName.SelectedIndex = comboBoxProvince.SelectedIndex;

                //GEtextBoxPais.Text = Main.Sol_ControlInfo.Country;
                GEtextBoxPhoneNumber.Text = Main.Sol_ControlInfo.PhoneNumber;
                GEtextBoxEmail.Text = Main.Sol_ControlInfo.EmailAccount;

                //PostalCode
                sol_Setting = sol_Setting_Sp.Select("Business_PostalCode");
                textBoxPostalCode.Text = sol_Setting.SetValue.ToString();

                //Monday
                GEdateTimePickerHoursFrom.Value = Main.Sol_ControlInfo.BusinessHoursFrom;
                GEdateTimePickerHoursTo.Value = Main.Sol_ControlInfo.BusinessHoursTo;

                dateTimePickerFromTue.Value = Main.Sol_ControlInfo.BusinessHoursFromTue;
                dateTimePickerToTue.Value = Main.Sol_ControlInfo.BusinessHoursToTue;
                dateTimePickerFromWed.Value = Main.Sol_ControlInfo.BusinessHoursFromWed;
                dateTimePickerToWed.Value = Main.Sol_ControlInfo.BusinessHoursToWed;
                dateTimePickerFromThu.Value = Main.Sol_ControlInfo.BusinessHoursFromThu;
                dateTimePickerToThu.Value = Main.Sol_ControlInfo.BusinessHoursToThu;
                dateTimePickerFromFri.Value = Main.Sol_ControlInfo.BusinessHoursFromFri;
                dateTimePickerToFri.Value = Main.Sol_ControlInfo.BusinessHoursToFri;
                dateTimePickerFromSat.Value = Main.Sol_ControlInfo.BusinessHoursFromSat;
                dateTimePickerToSat.Value = Main.Sol_ControlInfo.BusinessHoursToSat;
                dateTimePickerFromSun.Value = Main.Sol_ControlInfo.BusinessHoursFromSun;
                dateTimePickerToSun.Value = Main.Sol_ControlInfo.BusinessHoursToSun;

                GEtextBoxIdFiscal1Nombre.Text = Main.Sol_ControlInfo.IdFiscal1Name;
                GEtextBoxIdFiscal1Valor.Text = Main.Sol_ControlInfo.IdFiscal1Value;
                GEtextBoxIdFiscal2Nombre.Text = Main.Sol_ControlInfo.IdFiscal2Name;
                GEtextBoxIdFiscal2Valor.Text = Main.Sol_ControlInfo.IdFiscal2Value;


                checkBoxSplashHide.Checked = Properties.Settings.Default.SplashEsconder;
                checkBoxSplashMute.Checked = Properties.Settings.Default.SplashSilenciar;

                //workstation
                //WStextBoxWorkStationNumber.Text = Properties.Settings.Default.SettingsWsWorkStationNumber.ToString();
                WStextBoxWorkStationName.Text = Properties.Settings.Default.SettingsWsWorkStationName.ToString();


                comboBoxCashTray.SelectedValue = Properties.Settings.Default.SettingsDefaultCashTray;
                //comboBoxCashTray.SelectedValue = Properties.Settings.Default.SettingsCurrentCashTray;

                //checkBoxMultiProductStagingEnabled.Checked = Properties.Settings.Default.MultiProductStagingEnabled;
                ////if(Properties.Settings.Default.MultiProductStagingEnabled)
                ////{
                //    int conveyorId = (int)comboBoxConveyor.SelectedValue;
                //    if (conveyorId < 1) conveyorId = 1;

                //    Sol_WorkStation sol_WorkStation = ReadWorkStation(sol_WorkStation_Sp, WStextBoxWorkStationName.Text, true, conveyorId);

                //    try { comboBoxConveyor.SelectedValue = sol_WorkStation.ConveyorID; } catch { comboBoxConveyor.SelectedIndex = 1; }

                ////}

                comboBoxStagingType.SelectedIndex = Properties.Settings.Default.StagingType;
                comboBoxConveyor.Enabled = comboBoxStagingType.SelectedIndex > 0;

                comboBoxConveyor.Enabled = Properties.Settings.Default.StagingType > 0;
                //if(comboBoxConveyor.Enabled)
                //{
                    int conveyorId = (int)comboBoxConveyor.SelectedValue;
                    if (conveyorId < 1) conveyorId = 1;
                    Sol_WorkStation sol_WorkStation = ReadWorkStation(sol_WorkStation_Sp, WStextBoxWorkStationName.Text, true, conveyorId);
                    try { comboBoxConveyor.SelectedValue = sol_WorkStation.ConveyorID; } catch { comboBoxConveyor.SelectedIndex = 1; }
                //}


                //???
                if (string.IsNullOrEmpty(WStextBoxWorkStationName.Text))
                    WStextBoxWorkStationName.Text = sol_WorkStation.Name;

                comboBoxComputerRole.SelectedIndex = Properties.Settings.Default.SettingComputerRole;


                //SQL Server
                numericUpDownSqlTimeout.Value = Properties.Settings.Default.SettingsAdCustomerScreenImageInterval;
                sol_Setting = sol_Setting_Sp.Select("SqlTimeout");
                if (sol_Setting == null || string.IsNullOrEmpty(sol_Setting.Name))
                {
                    sol_Setting = new Sol_Setting();
                    sol_Setting.SetValue = (int)90;
                }
                numericUpDownSqlTimeout.Value = (int)sol_Setting.SetValue;

                //Receipt
                //read default printer
                //using System.Drawing.Printing;
                PrintDocument prtdoc = new PrintDocument();
                    string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
                string c = Properties.Settings.Default.SettingsWsReceiptPrinter.Trim();
                if (String.IsNullOrEmpty(c))
                    c = strDefaultPrinter;
                WScomboBoxReceiptPrinter.Text = c;
                WStextBoxLines.Text = Properties.Settings.Default.SettingsWsReceiptLinesAfterPrinting.ToString();
                WScheckBoxReceiptPrintPreview.Checked = Properties.Settings.Default.SettingsWsReceiptPrintPreview;
                WSComboBoxReceiptMessage.SelectedValue = Main.Sol_ControlInfo.ReceiptMessageID;

                WStextBoxOpenDrawer.Text = Properties.Settings.Default.SettingsWsTicketOpenDrawer;
                WScheckBoxOpenDrawerSendTwice.Checked = Properties.Settings.Default.SettingsWsTicketOpenDrawerSendTwice;
                WStextBoxCutPaper.Text = Properties.Settings.Default.SettingsWsTicketCutPaper;

                //reports
                c = Properties.Settings.Default.SettingsWsReportPrinter.Trim();
                if (String.IsNullOrEmpty(c))
                    c = strDefaultPrinter;
                WScomboBoxReportPrinter.Text = c;
                WScheckBoxReportsPrintPreview.Checked = Properties.Settings.Default.SettingsWsReportPrintPreview;

                //label
                c = Properties.Settings.Default.SettingsWsLabelPrinter.Trim();
                if (String.IsNullOrEmpty(c))
                    c = strDefaultPrinter;
                WScomboBoxLabelPrinter.Text = c;

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

                if (Properties.Settings.Default.StagingType == 0)
                {
                    if (string.IsNullOrEmpty(Properties.Settings.Default.SettingsWsLabelCommands))
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
                }
                else
                {
                    if (string.IsNullOrEmpty(Properties.Settings.Default.SettingsWsLabelCommands))
                        Properties.Settings.Default.SettingsWsLabelCommands =
                            " \r\n" +
                            "N\r\n" +
                            "q609\r\n" +
                            "Q400,30\r\n" +
                            "B55,0,0,3,4,12,100,N,\"masterProductCode: {masterProductCode}\"\r\n" +
                            "A600,100,1,4,2,1,N,\"{f_45}\"\r\n" +
                            "A530,100,1,4,2,1,N,\"Weight: {weight}\"\r\n" +
                            "A530,100,1,4,2,1,N,\"Volume: {volume}\"\r\n" +
                            "A150,110,1,4,1,1,N,\"Date: {date}\"\r\n" +
                            "A150,110,1,4,1,1,N,\"Time: {time}\"\r\n" +
                            "A530,100,1,4,2,1,N,\"Units: {units}\"\r\n" +
                            //"A475,100,1,3,1,1,N,\"TAG:\"\r\n" +
                            "A450,110,1,3,3,2,N,\"Tag: {tag}\"\r\n" +
                            "A450,110,1,3,3,2,N,\"Barcode: {barCode}\"\r\n" +
                            "A375,110,1,3,2,1,N,\"Description[0]: {description[0]}\"\r\n" +
                            "A225,110,1,4,2,1,N,\"Quantity[0]: {quantity[0]}\"\r\n" +
                            "A375,110,1,3,2,1,N,\"Description[1]: {description[1]}\"\r\n" +
                            "A225,110,1,4,2,1,N,\"Quantity[1]: {quantity[1]}\"\r\n" +
                            "A375,110,1,3,2,1,N,\"{description[2]}\"\r\n" +
                            "A225,110,1,4,2,1,N,\"{quantity[2]}\"\r\n" +
                            "A375,110,1,3,2,1,N,\"{description[3]}\"\r\n" +
                            "A225,110,1,4,2,1,N,\"{quantity[3]}\"\r\n" +
                            "A375,110,1,3,2,1,N,\"{description[4]}\"\r\n" +
                            "A225,110,1,4,2,1,N,\"{quantity[4]}\"\r\n" +
                            "P1,1\r\n";

                }
                WStextBoxCommands.Text = Properties.Settings.Default.SettingsWsLabelCommands;

                //system
                //SysCheckBoxCheckUpdates.Checked = Properties.Settings.Default.CheckUpdatesOnStart;

                SysButtonCheckNow.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolUpdateVersion", false);

                SysCheckBoxSelectProductFirst.Checked = Properties.Settings.Default.SettingReturnsNumericPadSelectProductFirst;

                //email
                SystextBoxSMTPServer.Text = Main.Sol_ControlInfo.SMTPServer;
                SystextBoxSMTPPort.Text = Main.Sol_ControlInfo.SMTPPort.ToString();
                SystextBoxEmailAccount.Text = Main.Sol_ControlInfo.EmailAccount;
                SystextBoxEmailPassword.Text = Main.Sol_ControlInfo.EmailPassword;

                checkBoxSqlServerDate.Checked = Main.Sol_ControlInfo.SqlServerDate;

                //Advanced
                CGcomboBoxMesInicial.SelectedIndex = (int)Main.Sol_ControlInfo.FiscalYearInitialMonth;
                CGnumericUpDownHistoria.Value = (byte)Main.Sol_ControlInfo.HistoryYears;
                checkBoxTouchScreenOriented.Checked = Properties.Settings.Default.TouchOriented;
                checkBoxFullScreenMode.Checked = Properties.Settings.Default.SettingsAdFullScreenMode;
//                checkBoxShowTaskBar.Enabled = !checkBoxFullScreenMode.Checked;
                //checkBoxHideTaskBar.Checked = Properties.Settings.Default.SettingsAdHideTaskBar;

                checkBoxAutomaticLoading.Checked = Properties.Settings.Default.SettingsAdCustomerScreenAutomaticLoading;
                checkBoxEnableCustomerScreen.Checked = Properties.Settings.Default.SettingsAdCustomerScreenEnable;
                //numericUpDownRefreshScreen.Value = Properties.Settings.Default.SettingsAdCustomerScreenRefresh;
                textBoxImagesFolder.Text = Properties.Settings.Default.SettingsAdCustomerScreenImagesFolder;
                numericUpDownImageInterval.Value = Properties.Settings.Default.SettingsAdCustomerScreenImageInterval;

                comboBoxImageSizeMode.SelectedIndex = Properties.Settings.Default.SettingsAdCustomerScreenImageSizeMode;

                bool flag = checkBoxEnableCustomerScreen.Checked;
                    checkBoxAutomaticLoading.Enabled = flag;
                    //numericUpDownRefreshScreen.Enabled = flag;
                    textBoxImagesFolder.Enabled = flag;
                    buttonBrowse.Enabled = flag;
                    numericUpDownImageInterval.Enabled = flag;
                    comboBoxImageSizeMode.Enabled = flag;
                    numericUpDownCustomerScreenMonitor.Enabled = flag;



                //monitor to use in customer screen
                //if (Main.Sol_ControlInfo.CustomerScreenMonitor >= 0)
                    //numericUpDownCustomerScreenMonitor.Value = Main.Sol_ControlInfo.CustomerScreenMonitor;
                int m = Properties.Settings.Default.SettingsCustomerScreenMonitor;
                if (Properties.Settings.Default.SettingsCustomerScreenMonitor >= 0)
                {
                    if (m <= numericUpDownCustomerScreenMonitor.Maximum)
                        numericUpDownCustomerScreenMonitor.Value = m;
                }

                //else
                //{
                //    numericUpDownCustomerScreenMonitor.Minimum = 0;
                //    numericUpDownCustomerScreenMonitor.Value = 0;
                //    //numericUpDownCustomerScreenMonitor.Minimum = 1;
                //}

                checkBoxSecurityEnableUnpPay.Checked = Properties.Settings.Default.SettingsSecurityEnableUnPay;
                checkBoxSecurityApprovalUnPay.Enabled = checkBoxSecurityEnableUnpPay.Checked;
                checkBoxSecurityApprovalUnPay.Checked = Properties.Settings.Default.SettingsSecurityApprovalUnPay;

                try
                {
                    comboBoxBarcodeEncoding.SelectedIndex = Properties.Settings.Default.BarcodeEncoding;
                }
                catch {
                    comboBoxBarcodeEncoding.SelectedIndex = 1;
                }
                textBoxBarcodeWidth.Text = Properties.Settings.Default.BarcodeWidth.ToString();
                textBoxBarcodeHeight.Text = Properties.Settings.Default.BarcodeHeight.ToString();

//#DISABLELOCALDB
//                //SQL MODES
//                txtInstanceName.Text = Properties.Settings.Default.ModesLocalDbServerName;
//                txtInstanceName.Text = txtInstanceName.Text.Replace(@"(LocalDB)\", "");

//                checkBoxModesEnabled.Checked = Properties.Settings.Default.ModesEnabled;
//                textBoxAdvModesBackupsFolder.Text = Properties.Settings.Default.ModesBackupsFolder;
//                checkBoxModesEnableChanging_CheckedChanged(this.checkBoxModesEnabled, EventArgs.Empty);

                //returns
                checkBox17ScreenSetup.Checked = Properties.Settings.Default.SettingsAd17ScreenSetup;
                checkBoxNumericKeyPadOn.Checked = Main.Sol_ControlInfo.NumericKeyPadOn;

                //Sales
                useSalesCheckBox.Checked = Properties.Settings.Default.UseSales;

                //0 = right 1 = left
                if (Main.Sol_ControlInfo.NumericKeyPadPosition == 0)
                    radioButtonNumericKeyPadRight.Checked = true;
                else
                    radioButtonNumericKeyPadLeft.Checked = true;

                //0 = Quick Cas Out 1 = Print Chit
                if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)
                    radioButtonQuickCheckOut.Checked = true;
                else
                    radioButtonPrintChit.Checked = true;


                //0 = complete 1 = order number only
                if (Main.Sol_ControlInfo.ChitTicketComplete == 0)
                    radioButtonChitTicketComplete.Checked = true;
                else
                    radioButtonChitTicketOrderNumberOnly.Checked = true;

                checkBoxChitTicketIncludeBarcode.Checked = Main.Sol_ControlInfo.ChitTicketIncludeBarcode;

                checkBoxSnapToGrid.Checked = Main.Sol_ControlInfo.CategoryButtonsSnapToGrid;
                numericTextBoxMaxQtyAllowed.Text = Main.Sol_ControlInfo.ReturnsMaxQuantity.ToString();

                checkBoxIncludeSecurityCode.Checked = Main.Sol_ControlInfo.IncludeSecurityCode;

                    //cardreader
                    sol_Setting = sol_Setting_Sp.Select("CardReader_Enabled");
                    Main.CardReader_Enabled = (bool)sol_Setting.SetValue;
                    checkBoxCardReader_Enabled.Checked = Main.CardReader_Enabled;
                    //groupBoxCardReader.Enabled = Main.CardReader_Enabled;

                    sol_Setting = sol_Setting_Sp.Select("CardReader_EmulationMode");
                    Main.CardReader_EmulationMode = (byte)sol_Setting.SetValue;
                    comboBoxMsrEmulationMode.SelectedIndex = Main.CardReader_EmulationMode;

                    sol_Setting = sol_Setting_Sp.Select("CardReader_VID");
                    Main.CardReader_VID = (int)sol_Setting.SetValue;
                    textBoxMsrVid.Text = Main.CardReader_VID.ToString("X4");

                    sol_Setting = sol_Setting_Sp.Select("CardReader_PID");
                    Main.CardReader_PID = (int)sol_Setting.SetValue;
                    textBoxMsrPid.Text = Main.CardReader_PID.ToString("X4");

                    sol_Setting = sol_Setting_Sp.Select("CardReader_CharSeparator");
                    if(sol_Setting == null)
                    {
                        sol_Setting = new Sol_Setting();
                        sol_Setting.Description = "Char separator for tracks";
                        sol_Setting.Name = "CardReader_CharSeparator";
                        sol_Setting.SetValue = (int)59;
                        sol_Setting_Sp.Insert(sol_Setting);
                    }
                    Main.CardReader_CharSeparator = (int)sol_Setting.SetValue;
                    textBoxMsrCharSeparator.Text = Main.CardReader_CharSeparator.ToString("X2");

                    sol_Setting = sol_Setting_Sp.Select("CardReader_CloseOrder");
                    Main.CardReader_CloseOrder = (bool)sol_Setting.SetValue;
                    checkBoxCardReader_CloseOrder.Checked = Main.CardReader_CloseOrder;

                    sol_Setting = sol_Setting_Sp.Select("CardReader_LinkMethod");
                    Main.CardReader_LinkMethod = (byte)sol_Setting.SetValue;
                    if (Main.CardReader_LinkMethod == 0)
                        radioButtonCardReader_LinkMethod_Opcion0.Checked = true;
                    else if (Main.CardReader_LinkMethod == 1)
                        radioButtonCardReader_LinkMethod_Opcion1.Checked = true;
                    else if (Main.CardReader_LinkMethod == 2)
                        radioButtonCardReader_LinkMethod_Opcion2.Checked = true;


                //sales
                textBoxTax1Name.Text = Main.Sol_ControlInfo.Tax1Name;
                numericTextBoxTax1Rate.Text = Main.Sol_ControlInfo.Tax1Rate.ToString();
                textBoxTax2Name.Text = Main.Sol_ControlInfo.Tax2Name;
                numericTextBoxTax2Rate.Text = Main.Sol_ControlInfo.Tax2Rate.ToString();

                //cashier
                checkBoxCashOutPrintingOverride.Checked = !Main.Sol_ControlInfo.CashOutPrintingOverride;
                try
                {
                    numericTextBoxCashierMaxAmountAllowed.Text = Main.Sol_ControlInfo.CashierMaxAmount.ToString("###,##0.00");
                }
                catch
                {
                    numericTextBoxCashierMaxAmountAllowed.Text = "";
                }
                checkBoxReceiptAmountBarcode.Checked = Main.Sol_ControlInfo.ReceiptAmountBarcode;

                //coin dispensers
                checkBoxCoinDispenserEnable.Checked = Properties.Settings.Default.CoinDispenserEnabled;
                comboBoxCoinDispenserDevice.SelectedIndex = Properties.Settings.Default.CoinDispenserDevice;
                comboBoxCoinDispenserTFlexCommunicationChannel.SelectedIndex = Properties.Settings.Default.CoinDispenserTFlexCommunicationChannel;
                comboBoxCoinDispenserTFlexSetProtocol.SelectedIndex = Properties.Settings.Default.CoinDispenserTFlexSetProtocol;
                comboBoxCoinDispenserTFlexSetCommBaud.SelectedIndex = Properties.Settings.Default.CoinDispenserTFlexSetCommBaud;
                numericUpDownCoinDispenserTFlexSetCommPort.Value = Properties.Settings.Default.CoinDispenserTFlexSetCommPort;

                //BottleDrop
                if (Main.EnableBottleDrop) {
                    bottleDropLocalAccountPanel.Visible = true;
                bdLocalAccountNumberTextBox.Text = Properties.Settings.Default.BottleDropLocalAccountNumer.ToString();
                }
                //shipping

                try
                {
                    comboBoxDefaultAgency.SelectedValue = Main.Sol_ControlInfo.DefaultAgencyID;
                }
                catch
                {
                    comboBoxDefaultAgency.SelectedValue = 0;
                }

                useAttendanceCheckBox.Checked = Properties.Settings.Default.UseAttendance;
                //sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);
                //sol_AutoNumber = sol_AutoNumber_Sp.Select(1, 1);
                //if(sol_AutoNumber == null)
                //{
                //    sol_AutoNumber = new Sol_AutoNumber();
                //    sol_AutoNumber.FolioID=1;
                //    sol_AutoNumber.TagNumber = 0;
                //    sol_AutoNumber.RBillNumber = 0;
                //    sol_AutoNumber_Sp.Insert(sol_AutoNumber);

                //}


                //checkBoxAutoTagNumber.Checked = Main.Sol_ControlInfo.AutoGenerateTagNumber;
                //textBoxTagNumber.Text = sol_AutoNumber.TagNumber.ToString();

                //checkBoxAutoRBillNumber.Checked = Main.Sol_ControlInfo.AutoGenerateRBillNumber;
                //textBoxRBillNumber.Text = sol_AutoNumber.RBillNumber.ToString();

                //homePage
                //Atendance
                sol_Setting = sol_Setting_Sp.Select("Attendance_Enabled");
                checkBoxAttendanceEnabled.Checked = (bool)sol_Setting.SetValue;
                groupBoxAttendanceEmpList.Enabled = checkBoxAttendanceEnabled.Checked;

                if (Main.Sol_ControlInfo.EmployeesListRefresh < 1)
                    Main.Sol_ControlInfo.EmployeesListRefresh = 5;
                numericUpDownAttendanceMinutes.Value = Main.Sol_ControlInfo.EmployeesListRefresh;
                if (String.IsNullOrEmpty(Main.Sol_ControlInfo.WebBrowserUrl))
                    Main.Sol_ControlInfo.WebBrowserUrl = "about:blank";
                textBoxHomePageUrl.Text = Main.Sol_ControlInfo.WebBrowserUrl;

                if (String.IsNullOrEmpty(Main.Sol_ControlInfo.WebBrowserUpdateHistoryUrl))
                    Main.Sol_ControlInfo.WebBrowserUrl = "about:blank";
                textBoxUpdateHistoryUrl.Text = Main.Sol_ControlInfo.WebBrowserUpdateHistoryUrl;
                


                //ABCRC
                comboBoxContainers.SelectedValue = -1;
                numericTextBoxWhiteBagId.Text = Main.Sol_ControlInfo.WhiteBagID.ToString();
                numericTextBoxBlueBagId.Text = Main.Sol_ControlInfo.BlueBagID.ToString();
                numericTextBoxOneWayBagId.Text = Main.Sol_ControlInfo.OneWayBagID.ToString();
                numericTextBoxABCRCPalletId.Text = Main.Sol_ControlInfo.ABCRCPalletsID.ToString();


                numericTextBoxVendorID.Text = Main.Sol_ControlInfo.VendorID.ToString();
                try
                {
                    comboBoxDefaultPlant.SelectedValue = Main.Sol_ControlInfo.DefaultPlantID;
                    if(comboBoxDefaultPlant.SelectedValue == null)
                        comboBoxDefaultPlant.SelectedValue = 0;
                }
                catch
                {
                    comboBoxDefaultPlant.SelectedValue = 0;
                }
                try
                {
                    comboBoxDefaultCarrier.SelectedValue = Main.Sol_ControlInfo.DefaultCarrierID;
                    if (comboBoxDefaultCarrier.SelectedValue == null)
                        comboBoxDefaultCarrier.SelectedValue = 0;
                }
                catch
                {
                    comboBoxDefaultCarrier.SelectedValue = 0;
                }
                textBoxABCRCUserName.Text = Main.Sol_ControlInfo.ABCRCUserName;
                textBoxABCRCPassword.Text = Main.Sol_ControlInfo.ABCRCPassword;


                checkBoxRBillBarcode.Checked = Main.Sol_ControlInfo.RBillNumberBarcode;

                int intvalue = 0;
                sol_Setting = sol_Setting_Sp.Select("RBillVersion");
                if (sol_Setting != null)
                    int.TryParse(sol_Setting.SetValue.ToString(), out intvalue);
                comboBoxRBillVersion.SelectedIndex = intvalue;

                //QDS
                //--6 digit number – first digit random. 4 digits sequential. 6th digit 10-first digit.
                //when the depotid is entered, the 1st and 6th digits must add to 10 or it give a message that it is not a valid id.
                //123459
                qds_Setting = qds_Setting_Sp.Select("QuickDrop_DepotID");
                Main.QuickDrop_DepotID = qds_Setting.SetValue.ToString();
                textBoxQdsDepotId.Text = Main.QuickDrop_DepotID;

                if (textBoxQdsDepotId.Text.Length == 6)
                    panelQuickDrop.Enabled = true;

                //cardreader for qds
                qds_Setting = qds_Setting_Sp.Select("CardReader_Enabled");
                Main.QuickDrop_CardReader_Enabled = (bool)qds_Setting.SetValue;
                checkBoxQdsCardReader_Enabled.Checked = Main.QuickDrop_CardReader_Enabled;
                xprPanel.Enabled = Main.QuickDrop_CardReader_Enabled;

                qds_Setting = qds_Setting_Sp.Select("CardReader_EmulationMode");
                Main.QuickDrop_CardReader_EmulationMode = (byte)qds_Setting.SetValue;
                comboBoxQdsMsrEmulationMode.SelectedIndex = Main.QuickDrop_CardReader_EmulationMode;

                qds_Setting = qds_Setting_Sp.Select("CardReader_VID");
                Main.QuickDrop_CardReader_VID = (int)qds_Setting.SetValue;
                textBoxQdsMsrVid.Text = Main.QuickDrop_CardReader_VID.ToString("X4");

                qds_Setting = qds_Setting_Sp.Select("CardReader_PID");
                Main.QuickDrop_CardReader_PID = (int)qds_Setting.SetValue;
                textBoxQdsMsrPid.Text = Main.QuickDrop_CardReader_PID.ToString("X4");

                qds_Setting = qds_Setting_Sp.Select("CardReader_CharSeparator");
                //if (sol_Setting == null)
                //{
                //    sol_Setting = new Sol_Setting();
                //    sol_Setting.Description = "Char separator for tracks";
                //    sol_Setting.Name = "CardReader_CharSeparator";
                //    sol_Setting.SetValue = (int)59;
                //    sol_Setting_Sp.Insert(sol_Setting);
                //}
                Main.QuickDrop_CardReader_CharSeparator = (int)qds_Setting.SetValue;
                textBoxQdsMsrCharSeparator.Text = Main.QuickDrop_CardReader_CharSeparator.ToString("X2");


            }


            GEtextBoxRazonSocial.Focus();

            firsTimeFlag = false;

            //check ABCRC info
            if (Main.Sol_ControlInfo.State != "AB")
            {
                tabControl1.TabPages.Remove(tabPageABCRC);
                tabControl1.TabPages.Remove(tabPageQds);
            }

        }

        private void OK_Click(object sender, EventArgs e)
        {
            if(ApplyChanges())
                Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private bool ApplyChanges()
        {
            //validate some answers
            //Phone number
            if (!String.IsNullOrEmpty(GEtextBoxPhoneNumber.Text) && !Funciones.validarTelefono(GEtextBoxPhoneNumber.Text.Trim()))
            {
                tabControl1.SelectTab(0);
                GEtextBoxPhoneNumber.SelectAll();
                GEtextBoxPhoneNumber.Focus();
                MessageBox.Show("Invalid PhoneNumber, please verify. (xxx) xxx-xxxx");
                return false;
            }

            //email
            if (!String.IsNullOrEmpty(GEtextBoxEmail.Text) && !Funciones.validarEmail(GEtextBoxEmail.Text.Trim()))
            {
                tabControl1.SelectTab(0);
                GEtextBoxEmail.SelectAll();
                GEtextBoxEmail.Focus();
                MessageBox.Show("Invalid Email format, please verify.");
                return false;
            }

            //grabar opciones
            //Sol_Control
            Sol_Control_Sp sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //Main.Sol_ControlInfo = new Sol_Control();
            //Main.Sol_ControlInfo.ControlID = 1;

            //general
            Main.Sol_ControlInfo.BusinessName = GEtextBoxRazonSocial.Text;
            Main.Sol_ControlInfo.LegalName = GEtextBoxRazonFiscal.Text.Trim();
            int intValue = 0;
            try
            {
                intValue = Int32.Parse(GEtextBoxStoreNumber.Text);
            }
            catch { }
            Main.Sol_ControlInfo.StoreNumber = intValue;

            Main.Sol_ControlInfo.Address = GEtextBoxDireccion.Text.Trim();
            Main.Sol_ControlInfo.City = GEtextBoxCiudad.Text.Trim();
            Main.Sol_ControlInfo.State = comboBoxProvince.SelectedItem.ToString();

            //check ABCRC info
            if (Main.Sol_ControlInfo.State == "AB")
            {
                if (!tabControl1.TabPages.Contains(tabPageABCRC))
                {
                    tabControl1.TabPages.Add(tabPageABCRC);
                    tabControl1.TabPages.Add(tabPageQds);
                }
            }
            else
            {
                if (tabControl1.TabPages.Contains(tabPageABCRC))
                {
                    tabControl1.TabPages.Remove(tabPageABCRC);
                    tabControl1.TabPages.Remove(tabPageQds);
                }
            }


            Main.Sol_ControlInfo.Country = GEtextBoxPais.Text.Trim();
            Main.Sol_ControlInfo.PhoneNumber = GEtextBoxPhoneNumber.Text;
            Main.Sol_ControlInfo.EmailAccount = GEtextBoxEmail.Text;

            //PostalCode
            sol_Setting = sol_Setting_Sp.Select("Business_PostalCode");
            sol_Setting.SetValue = textBoxPostalCode.Text;
            sol_Setting_Sp.Update(sol_Setting);

            
            //monday
            Main.Sol_ControlInfo.BusinessHoursFrom = GEdateTimePickerHoursFrom.Value;
            Main.Sol_ControlInfo.BusinessHoursTo = GEdateTimePickerHoursTo.Value;
            Main.Sol_ControlInfo.BusinessHoursFromTue = dateTimePickerFromTue.Value;
            Main.Sol_ControlInfo.BusinessHoursToTue = dateTimePickerToTue.Value;
            Main.Sol_ControlInfo.BusinessHoursFromWed = dateTimePickerFromWed.Value;
            Main.Sol_ControlInfo.BusinessHoursToWed = dateTimePickerToWed.Value;
            Main.Sol_ControlInfo.BusinessHoursFromThu = dateTimePickerFromThu.Value;
            Main.Sol_ControlInfo.BusinessHoursToThu = dateTimePickerToThu.Value;
            Main.Sol_ControlInfo.BusinessHoursFromFri = dateTimePickerFromFri.Value;
            Main.Sol_ControlInfo.BusinessHoursToFri = dateTimePickerToFri.Value;
            Main.Sol_ControlInfo.BusinessHoursFromSat = dateTimePickerFromSat.Value;
            Main.Sol_ControlInfo.BusinessHoursToSat = dateTimePickerToSat.Value;
            Main.Sol_ControlInfo.BusinessHoursFromSun = dateTimePickerFromSun.Value;
            Main.Sol_ControlInfo.BusinessHoursToSun = dateTimePickerToSun.Value;

            Main.Sol_ControlInfo.IdFiscal1Name = GEtextBoxIdFiscal1Nombre.Text.Trim();
            Main.Sol_ControlInfo.IdFiscal1Value = GEtextBoxIdFiscal1Valor.Text.Trim();
            Main.Sol_ControlInfo.IdFiscal2Name = GEtextBoxIdFiscal2Nombre.Text.Trim();
            Main.Sol_ControlInfo.IdFiscal2Value = GEtextBoxIdFiscal2Valor.Text.Trim();

            Properties.Settings.Default.SplashEsconder = checkBoxSplashHide.Checked;
            Properties.Settings.Default.SplashSilenciar = checkBoxSplashMute.Checked;

            //**************
            //workstation
            //**************
            //WStextBoxWorkStationNumber.Text = Properties.Settings.Default.SettingsWsWorkStationNumber.ToString();

            if(Properties.Settings.Default.SettingsWsWorkStationName != WStextBoxWorkStationName.Text)
            {
                int conveyorId = (int)comboBoxConveyor.SelectedValue;
                if (conveyorId < 1) conveyorId = 1;
                if (!UpdateWorkStation(sol_WorkStation_Sp, Properties.Settings.Default.SettingsWsWorkStationName, WStextBoxWorkStationName.Text, conveyorId))
                    return false;
            }
            Properties.Settings.Default.SettingsWsWorkStationName = WStextBoxWorkStationName.Text;


            Properties.Settings.Default.SettingsDefaultCashTray = Convert.ToInt32(comboBoxCashTray.SelectedValue);
            //Properties.Settings.Default.SettingsCurrentCashTray = Convert.ToInt32(comboBoxCashTray.SelectedValue);

            //Properties.Settings.Default.MultiProductStagingEnabled = checkBoxMultiProductStagingEnabled.Checked;

            Properties.Settings.Default.StagingType = comboBoxStagingType.SelectedIndex;

            Properties.Settings.Default.SettingComputerRole = comboBoxComputerRole.SelectedIndex;

            //SQL Server
            bool flagInsert = false;
            sol_Setting = sol_Setting_Sp.Select("SqlTimeout");
            if (sol_Setting == null || string.IsNullOrEmpty(sol_Setting.Name))
            {
                sol_Setting = new Sol_Setting();
                sol_Setting.Name = "SqlTimeout";
                sol_Setting.Description = "Sql Time-out interval";
                flagInsert = true;
            }
            Int32.TryParse(numericUpDownSqlTimeout.Value.ToString(), out intValue);
            sol_Setting.SetValue = intValue;
            if(flagInsert)
                sol_Setting_Sp.Insert(sol_Setting);
            else
                sol_Setting_Sp.Update(sol_Setting);

            Main.SqlTimeout = (int)numericUpDownSqlTimeout.Value;
            Main.ChangeStringConnection(true);

            //Receipt
            Properties.Settings.Default.SettingsWsReceiptPrinter = WScomboBoxReceiptPrinter.Text;

            try
            {
                intValue = Int32.Parse(WStextBoxLines.Text);
            }
            catch
            {
                intValue = 0;
            }
            Properties.Settings.Default.SettingsWsReceiptLinesAfterPrinting = intValue;
            Properties.Settings.Default.SettingsWsReceiptPrintPreview = WScheckBoxReceiptPrintPreview.Checked;
            try
            {
                Main.Sol_ControlInfo.ReceiptMessageID = Convert.ToInt32(WSComboBoxReceiptMessage.SelectedValue.ToString());
            }
            catch { }

            Properties.Settings.Default.SettingsWsTicketOpenDrawer = WStextBoxOpenDrawer.Text;
            Properties.Settings.Default.SettingsWsTicketOpenDrawerSendTwice = WScheckBoxOpenDrawerSendTwice.Checked;
            Properties.Settings.Default.SettingsWsTicketCutPaper = WStextBoxCutPaper.Text;

            //reports
            Properties.Settings.Default.SettingsWsReportPrinter = WScomboBoxReportPrinter.Text;
            Properties.Settings.Default.SettingsWsReportPrintPreview = WScheckBoxReportsPrintPreview.Checked;

            //label
            //label
            Properties.Settings.Default.SettingsWsLabelPrinter = WScomboBoxLabelPrinter.Text;
            Properties.Settings.Default.SettingsWsLabelCommands = WStextBoxCommands.Text;

            //**************
            //system
            //**************
            //Properties.Settings.Default.CheckUpdatesOnStart = SysCheckBoxCheckUpdates.Checked;
            Properties.Settings.Default.SettingReturnsNumericPadSelectProductFirst = SysCheckBoxSelectProductFirst.Checked;

            //email
            Main.Sol_ControlInfo.SMTPServer = SystextBoxSMTPServer.Text;
            try
            {
                intValue = Int32.Parse(SystextBoxSMTPPort.Text);
            }
            catch
            {
                intValue = 0;
            }
            Main.Sol_ControlInfo.SMTPPort = intValue;
            //Main.Sol_ControlInfo.EmailAccount = SystextBoxEmailAccount.Text;
            Main.Sol_ControlInfo.EmailPassword = SystextBoxEmailPassword.Text;

            //syncronize date
            //if (Main.Sol_ControlInfo.SqlServerDate != checkBoxSqlServerDate.Checked)
            //{
                if (!Main.Sol_ControlInfo.SqlServerDate)  //checkBoxSqlServerDate.Checked)
                {
                    DateTime fh;
                    if (Funciones.SqlLeerFecha(Properties.Settings.Default.WsirDbConnectionString, "GETDATE", out fh))
                        Properties.Settings.Default.FechaActual = fh;
                    else
                        Properties.Settings.Default.FechaActual = DateTime.Now;

                    Main.rc.ConnectionString = Properties.Settings.Default.WsirDbConnectionString;
                    Main.rc.SourceDate = "server";
                Main.Sol_ControlInfo.SqlServerDate = true;//checkBoxSqlServerDate.Checked;
            }
               // else
                //{
                 //   Properties.Settings.Default.FechaActual = DateTime.Now;
                   // Main.rc.ConnectionString = "";
                    //Main.rc.SourceDate = "local";
                //}
                Main.rc.CambiarFecha(Properties.Settings.Default.FechaActual);
            //}

            

            //**************
            //advanced
            //**************
            Main.Sol_ControlInfo.FiscalYearInitialMonth = (byte)CGcomboBoxMesInicial.SelectedIndex;
            Main.Sol_ControlInfo.HistoryYears = (byte)CGnumericUpDownHistoria.Value;

            Properties.Settings.Default.TouchOriented = true;//checkBoxTouchScreenOriented.Checked;
            Properties.Settings.Default.SettingsAdFullScreenMode = checkBoxFullScreenMode.Checked;
            //Properties.Settings.Default.SettingsAdHideTaskBar = checkBoxHideTaskBar.Checked;

            Properties.Settings.Default.SettingsAdCustomerScreenAutomaticLoading = checkBoxAutomaticLoading.Checked;
            Properties.Settings.Default.SettingsAdCustomerScreenEnable = checkBoxEnableCustomerScreen.Checked;
            //Properties.Settings.Default.SettingsAdCustomerScreenRefresh = (int)numericUpDownRefreshScreen.Value;
            Properties.Settings.Default.SettingsAdCustomerScreenImagesFolder = textBoxImagesFolder.Text;
            Properties.Settings.Default.SettingsAdCustomerScreenImageInterval = (int)numericUpDownImageInterval.Value;
            Properties.Settings.Default.SettingsAdCustomerScreenImageSizeMode = comboBoxImageSizeMode.SelectedIndex;

            //monitor to use in customer screen
            //Main.Sol_ControlInfo.CustomerScreenMonitor = (byte)numericUpDownCustomerScreenMonitor.Value;
            Properties.Settings.Default.SettingsCustomerScreenMonitor = (byte)numericUpDownCustomerScreenMonitor.Value;

            Properties.Settings.Default.SettingsSecurityEnableUnPay = checkBoxSecurityEnableUnpPay.Checked;
            Properties.Settings.Default.SettingsSecurityApprovalUnPay = checkBoxSecurityApprovalUnPay.Checked;

            Properties.Settings.Default.BarcodeEncoding = comboBoxBarcodeEncoding.SelectedIndex;

            intValue = 0;
            int.TryParse(textBoxBarcodeWidth.Text, out intValue);
            Properties.Settings.Default.BarcodeWidth = intValue;
            intValue = 0;
            int.TryParse(textBoxBarcodeHeight.Text, out intValue);
            Properties.Settings.Default.BarcodeHeight = intValue;


            //SQL MODES
            Properties.Settings.Default.ModesLocalDbServerName = @"(LocalDB)\"+txtInstanceName.Text;
            Properties.Settings.Default.ModesEnabled = checkBoxModesEnabled.Checked;
            Properties.Settings.Default.ModesBackupsFolder = textBoxAdvModesBackupsFolder.Text;

            //returns
            Properties.Settings.Default.SettingsAd17ScreenSetup = checkBox17ScreenSetup.Checked;
            Main.Sol_ControlInfo.NumericKeyPadOn = checkBoxNumericKeyPadOn.Checked;

            //Sales
            Properties.Settings.Default.UseSales = useSalesCheckBox.Checked;

            //0 = right 1 = left
            if (radioButtonNumericKeyPadRight.Checked)
                Main.Sol_ControlInfo.NumericKeyPadPosition = 0;
            else
                Main.Sol_ControlInfo.NumericKeyPadPosition = 1;

            //0 = Quick Cash Out 1 = Print Chit
            if (radioButtonQuickCheckOut.Checked)
                Main.Sol_ControlInfo.ReturnButtonExtra = 0;
            else
                Main.Sol_ControlInfo.ReturnButtonExtra = 1;

            //0 = complete 1 = order number only
            if (radioButtonChitTicketComplete.Checked)
                Main.Sol_ControlInfo.ChitTicketComplete = 0;
            else
                Main.Sol_ControlInfo.ChitTicketComplete = 1;

            Main.Sol_ControlInfo.ChitTicketIncludeBarcode = checkBoxChitTicketIncludeBarcode.Checked;

            Main.Sol_ControlInfo.CategoryButtonsSnapToGrid = checkBoxSnapToGrid.Checked;

            intValue = Int32.Parse(numericTextBoxMaxQtyAllowed.Text);
            Main.Sol_ControlInfo.ReturnsMaxQuantity = intValue;

            Main.Sol_ControlInfo.IncludeSecurityCode = checkBoxIncludeSecurityCode.Checked;

                //cardreader
                sol_Setting = sol_Setting_Sp.Select("CardReader_Enabled");
                Main.CardReader_Enabled = checkBoxCardReader_Enabled.Checked;
                sol_Setting.SetValue = Main.CardReader_Enabled;
                sol_Setting_Sp.Update(sol_Setting);

                sol_Setting = sol_Setting_Sp.Select("CardReader_EmulationMode");
                Main.CardReader_EmulationMode = (byte)comboBoxMsrEmulationMode.SelectedIndex;
                sol_Setting.SetValue = Main.CardReader_EmulationMode;
                sol_Setting_Sp.Update(sol_Setting);

                sol_Setting = sol_Setting_Sp.Select("CardReader_VID");
                try
                {
                    intValue = Int32.Parse(textBoxMsrVid.Text, System.Globalization.NumberStyles.HexNumber);
                }
                catch 
                {
                    MessageBox.Show("Use a valid hex number (example: 0801)");
                    textBoxMsrVid.Focus();
                    intValue = 0;
                    return false;
                }
                Main.CardReader_VID = intValue;
                sol_Setting.SetValue = Main.CardReader_VID;
                sol_Setting_Sp.Update(sol_Setting);

                sol_Setting = sol_Setting_Sp.Select("CardReader_PID");
                try
                {
                    intValue = Int32.Parse(textBoxMsrPid.Text, System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    MessageBox.Show("Use a valid hex number (example: 0001)");
                    textBoxMsrPid.Focus();
                    intValue = 0;
                    return false;
                }
                Main.CardReader_PID = intValue;
                sol_Setting.SetValue = Main.CardReader_PID;
                sol_Setting_Sp.Update(sol_Setting);

                sol_Setting = sol_Setting_Sp.Select("CardReader_CharSeparator");
                try
                {
                    intValue = Int32.Parse(textBoxMsrCharSeparator.Text, System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    MessageBox.Show("Use a valid hex number (example: 3B)");
                    textBoxMsrCharSeparator.Focus();
                    intValue = 0;
                    return false;
                }
                Main.CardReader_CharSeparator = intValue;
                sol_Setting.SetValue = Main.CardReader_CharSeparator;
                sol_Setting_Sp.Update(sol_Setting);

                sol_Setting = sol_Setting_Sp.Select("CardReader_CloseOrder");
                Main.CardReader_CloseOrder = checkBoxCardReader_CloseOrder.Checked;
                sol_Setting.SetValue = Main.CardReader_CloseOrder;
                sol_Setting_Sp.Update(sol_Setting);

                sol_Setting = sol_Setting_Sp.Select("CardReader_LinkMethod");
                if (radioButtonCardReader_LinkMethod_Opcion0.Checked)
                    Main.CardReader_LinkMethod = (byte)0;
                else if (radioButtonCardReader_LinkMethod_Opcion1.Checked)
                    Main.CardReader_LinkMethod = (byte)1;
                else if (radioButtonCardReader_LinkMethod_Opcion2.Checked)
                    Main.CardReader_LinkMethod = (byte)2;
                sol_Setting.SetValue = Main.CardReader_LinkMethod;
                sol_Setting_Sp.Update(sol_Setting);

            //sales
            Main.Sol_ControlInfo.Tax1Name = textBoxTax1Name.Text;
            decimal amount = 0m;
            Decimal.TryParse(numericTextBoxTax1Rate.Text, out amount);
            Main.Sol_ControlInfo.Tax1Rate = amount;
            Main.Sol_ControlInfo.Tax2Name = textBoxTax2Name.Text;
            Decimal.TryParse(numericTextBoxTax2Rate.Text, out amount);
            Main.Sol_ControlInfo.Tax2Rate = amount;

            //cashier
            Main.Sol_ControlInfo.CashOutPrintingOverride = !checkBoxCashOutPrintingOverride.Checked;
            Decimal.TryParse(numericTextBoxCashierMaxAmountAllowed.Text, out amount);
            Main.Sol_ControlInfo.CashierMaxAmount = amount;
            Main.Sol_ControlInfo.ReceiptAmountBarcode = checkBoxReceiptAmountBarcode.Checked;

            //coin dispensers
            Properties.Settings.Default.CoinDispenserEnabled = checkBoxCoinDispenserEnable.Checked;
            Properties.Settings.Default.CoinDispenserDevice = (short)comboBoxCoinDispenserDevice.SelectedIndex;
            Properties.Settings.Default.CoinDispenserTFlexCommunicationChannel = (short)comboBoxCoinDispenserTFlexCommunicationChannel.SelectedIndex;
            Properties.Settings.Default.CoinDispenserTFlexSetProtocol = (short)comboBoxCoinDispenserTFlexSetProtocol.SelectedIndex;
            Properties.Settings.Default.CoinDispenserTFlexSetCommBaud = (short)comboBoxCoinDispenserTFlexSetCommBaud.SelectedIndex;
            Properties.Settings.Default.CoinDispenserTFlexSetCommPort = (short)numericUpDownCoinDispenserTFlexSetCommPort.Value;

            //BottleDrop
            int bdcustnum;
            if (int.TryParse(bdLocalAccountNumberTextBox.Text, out bdcustnum)) Properties.Settings.Default.BottleDropLocalAccountNumer = bdcustnum;

            //shipping
            //Main.Sol_ControlInfo.AutoGenerateRBillNumber = checkBoxAutoRBillNumber.Checked;
            int valorInt = 0;
            try
            {
                int.TryParse(comboBoxDefaultAgency.SelectedValue.ToString(), out valorInt);
            }
            catch { }
            Main.Sol_ControlInfo.DefaultAgencyID = valorInt;


            Properties.Settings.Default.UseAttendance = useAttendanceCheckBox.Checked;
            //if (sol_AutoNumber_Sp == null)
            //    sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //if (sol_AutoNumber == null)
            //{
            //    sol_AutoNumber = new Sol_AutoNumber();
            //    sol_AutoNumber.FolioID = 1;
            //    sol_AutoNumber.TagNumber = 0;
            //    sol_AutoNumber.RBillNumber = 0;
            //    sol_AutoNumber_Sp.Insert(sol_AutoNumber);

            //}

            //intValue = 0;
            //int.TryParse(textBoxTagNumber.Text, out intValue);
            //sol_AutoNumber.TagNumber = intValue;
            //intValue = 0;
            //int.TryParse(textBoxRBillNumber.Text, out intValue);
            //sol_AutoNumber.RBillNumber = intValue;
            //sol_AutoNumber_Sp.Update(sol_AutoNumber);

            //Main.Sol_ControlInfo.AutoGenerateTagNumber = checkBoxAutoTagNumber.Checked;
            //Main.Sol_ControlInfo.AutoGenerateRBillNumber = checkBoxAutoRBillNumber.Checked;


            //homePage
            //Atendance
            sol_Setting = sol_Setting_Sp.Select("Attendance_Enabled");
            sol_Setting.SetValue = checkBoxAttendanceEnabled.Checked;
            sol_Setting_Sp.Update(sol_Setting);

            Main.Sol_ControlInfo.EmployeesListRefresh = (int)numericUpDownAttendanceMinutes.Value;
            Main.Sol_ControlInfo.WebBrowserUrl = textBoxHomePageUrl.Text;

            Main.Sol_ControlInfo.WebBrowserUpdateHistoryUrl = textBoxUpdateHistoryUrl.Text;


            //ABCRC
            Int32.TryParse(numericTextBoxWhiteBagId.Text, out intValue);
            Main.Sol_ControlInfo.WhiteBagID = intValue;
            Int32.TryParse(numericTextBoxBlueBagId.Text, out intValue);
            Main.Sol_ControlInfo.BlueBagID = intValue;
            Int32.TryParse(numericTextBoxOneWayBagId.Text, out intValue);
            Main.Sol_ControlInfo.OneWayBagID = intValue;
            Int32.TryParse(numericTextBoxABCRCPalletId.Text, out intValue);
            Main.Sol_ControlInfo.ABCRCPalletsID = intValue;

            Int32.TryParse(numericTextBoxVendorID.Text, out intValue);
            Main.Sol_ControlInfo.VendorID = intValue;
            try
            {
                Main.Sol_ControlInfo.DefaultPlantID = (int)comboBoxDefaultPlant.SelectedValue;
            }
            catch { }
            try
            {
                Main.Sol_ControlInfo.DefaultCarrierID = (int)comboBoxDefaultCarrier.SelectedValue;
            }
            catch { }

            Main.Sol_ControlInfo.ABCRCUserName = textBoxABCRCUserName.Text;
            Main.Sol_ControlInfo.ABCRCPassword = textBoxABCRCPassword.Text;

            Main.Sol_ControlInfo.RBillNumberBarcode = checkBoxRBillBarcode.Checked;

            sol_Setting = sol_Setting_Sp.Select("RBillVersion");
            if (sol_Setting == null || string.IsNullOrEmpty(sol_Setting.Name))
            {
                sol_Setting = new Sol_Setting();
                sol_Setting.Name = "RBillVersion";
                sol_Setting.Description = "Dozens or Units";
                sol_Setting.SetValue = comboBoxRBillVersion.SelectedIndex;
                sol_Setting_Sp.Insert(sol_Setting);
            }
            else
            {
                sol_Setting.SetValue = comboBoxRBillVersion.SelectedIndex;
                sol_Setting_Sp.Update(sol_Setting);
            }

            //QDS
            //--6 digit number – first digit random. 4 digits sequential. 6th digit 10-first digit.
            //when the depotid is entered, the 1st and 6th digits must add to 10 or it give a message that it is not a valid id.
            // example: 123459
            if (Main.QuickDrop_DepotID != textBoxQdsDepotId.Text)
            {
                if (!(textBoxQdsDepotId.Text == "0" || String.IsNullOrEmpty(textBoxQdsDepotId.Text)))
                {
                    bool error = false;
                    if (textBoxQdsDepotId.Text.Length != 6)
                        error = true;
                    else
                    {
                        int fdig = 0;
                        int ldig = 0;
                        int.TryParse(textBoxQdsDepotId.Text.Substring(0, 1), out fdig);
                        int.TryParse(textBoxQdsDepotId.Text.Substring(5, 1), out ldig);
                        if (fdig + ldig != 10)
                            error = true;

                    }
                    if (error)
                    {
                        MessageBox.Show("DepotId is not valid.");
                        return false;
                    }
                }

                qds_Setting = qds_Setting_Sp.Select("QuickDrop_DepotID");

                //if (string.IsNullOrEmpty(textBoxQdsDepotId.Text))
                //{
                //    if (depotIDReferences(textBoxQdsDepotId.Text))
                //        return false;

                //}
                //else if (Main.QuickDrop_DepotID != textBoxQdsDepotId.Text)
                //{
                //    if (depotIDReferences(textBoxQdsDepotId.Text))
                //        return false;
                //}

                if (depotIDReferences(textBoxQdsDepotId.Text))
                    return false;

                if (textBoxQdsDepotId.Text == "0" || String.IsNullOrEmpty(textBoxQdsDepotId.Text))
                    panelQuickDrop.Enabled = false;
                else
                    panelQuickDrop.Enabled = true;

                UpdateDepotIDInPaymentMethodAvailableByDepot(textBoxQdsDepotId.Text);

                Main.QuickDrop_DepotID = textBoxQdsDepotId.Text;
                qds_Setting.SetValue = Main.QuickDrop_DepotID;
                qds_Setting_Sp.Update(qds_Setting);

            }

            //cardreader
            qds_Setting = qds_Setting_Sp.Select("CardReader_Enabled");
            Main.QuickDrop_CardReader_Enabled = checkBoxQdsCardReader_Enabled.Checked;
            qds_Setting.SetValue = Main.QuickDrop_CardReader_Enabled;
            qds_Setting_Sp.Update(qds_Setting);

            qds_Setting = qds_Setting_Sp.Select("CardReader_EmulationMode");
            Main.QuickDrop_CardReader_EmulationMode = (byte)comboBoxQdsMsrEmulationMode.SelectedIndex;
            qds_Setting.SetValue = Main.QuickDrop_CardReader_EmulationMode;
            qds_Setting_Sp.Update(qds_Setting);

            qds_Setting = qds_Setting_Sp.Select("CardReader_VID");
            try
            {
                intValue = Int32.Parse(textBoxQdsMsrVid.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Use a valid hex number (example: 0801)");
                textBoxQdsMsrVid.Focus();
                intValue = 0;
                return false;
            }
            Main.QuickDrop_CardReader_VID = intValue;
            qds_Setting.SetValue = Main.QuickDrop_CardReader_VID;
            qds_Setting_Sp.Update(qds_Setting);

            qds_Setting = qds_Setting_Sp.Select("CardReader_PID");
            try
            {
                intValue = Int32.Parse(textBoxQdsMsrPid.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Use a valid hex number (example: 0001)");
                textBoxQdsMsrPid.Focus();
                intValue = 0;
                return false;
            }

            Main.QuickDrop_CardReader_PID = intValue;
            qds_Setting.SetValue = Main.QuickDrop_CardReader_PID;
            qds_Setting_Sp.Update(qds_Setting);

            qds_Setting = qds_Setting_Sp.Select("CardReader_CharSeparator");
            try
            {
                intValue = Int32.Parse(textBoxQdsMsrCharSeparator.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Use a valid hex number (example: 3B)");
                textBoxQdsMsrCharSeparator.Focus();
                intValue = 0;
                return false;
            }

            Main.QuickDrop_CardReader_CharSeparator = intValue;
            qds_Setting.SetValue = Main.QuickDrop_CardReader_CharSeparator;
            qds_Setting_Sp.Update(qds_Setting);

            //update
            sol_Setting_Sp.Update(sol_Setting);
            sp.Update(Main.Sol_ControlInfo);
            //solum settings
            Properties.Settings.Default.Save();

            return true;
        }

        private bool depotIDReferences(string depotID)
        {
            qds_PaymentMethodAvailableByDepot = new Qds_PaymentMethodAvailableByDepot();
            string query =
                "SELECT COUNT(*) FROM Qds_Drop ";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if ((int)reader[0] > 0)
                            {
                                connection.Close();
                                MessageBox.Show("Cannot change depotID, it has references in Qds_Drop table!");
                                return true;
                            }
                        }
                    }

                }
                connection.Close();
            }
            return false;
        }

        private bool UpdateDepotIDInPaymentMethodAvailableByDepot(string depotID)
        {
            qds_PaymentMethodAvailableByDepot = new Qds_PaymentMethodAvailableByDepot();
            string query =
                "UPDATE [Qds_PaymentMethodAvailableByDepot] WITH (ROWLOCK) " +
                "SET [DepotID] = '" + depotID + "' ";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
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

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);
        }

        private void checkBoxTouchScreenOriented_CheckedChanged(object sender, EventArgs e)
        {

            //toolStripButtonVirtualKb.Visible = checkBoxTouchScreenOriented.Checked;
            Properties.Settings.Default.TouchOriented = checkBoxTouchScreenOriented.Checked;
            if (!checkBoxTouchScreenOriented.Checked)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        //Windows Printer SelectionList
        private void WScomboBoxReportPrinter_DropDown(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.Items.Clear();
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cb.Items.Add(strPrinter);
                //if (strPrinter == strDefaultPrinter)
                //{
                //    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(strPrinter);
                //}
            }

        }

        private void checkBoxFullScreenMode_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHideTaskBar.Enabled = checkBoxFullScreenMode.Checked;
            this.FormBorderStyle = (checkBoxFullScreenMode.Checked) ? FormBorderStyle.None : FormBorderStyle.SizableToolWindow;
            this.WindowState = (checkBoxFullScreenMode.Checked) ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // the code here will be executed if the user presses Open in
                // the dialog.

                string foldername = this.folderBrowserDialog1.SelectedPath;
                textBoxImagesFolder.Text = foldername;
            }

        }

        private void checkBoxEnableCustomerScreen_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = checkBoxEnableCustomerScreen.Checked;
            checkBoxAutomaticLoading.Enabled = flag;
            //numericUpDownRefreshScreen.Enabled = checkBoxEnableCustomerScreen.Checked;
            textBoxImagesFolder.Enabled = flag;
            buttonBrowse.Enabled = flag;
            numericUpDownImageInterval.Enabled = flag;
            comboBoxImageSizeMode.Enabled = flag;
            numericUpDownCustomerScreenMonitor.Enabled = flag;
        }

        private void SysButtonCheckNow_Click(object sender, EventArgs e)
        {
            ChecarActualizaciones f1 = new ChecarActualizaciones(false, false);
            //f1.ShowDialog();
            f1.Show(this);

        }

        private void checkBoxSecurityEnableUnpPay_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSecurityApprovalUnPay.Enabled = checkBoxSecurityEnableUnpPay.Checked;
        }

        private void checkBoxNumericKeyPadOn_CheckedChanged(object sender, EventArgs e)
        {
            numKeypadPanel.Enabled = checkBoxNumericKeyPadOn.Checked;
            //bool flag = checkBoxNumericKeyPadOn.Checked;
            //radioButtonNumericKeyPadLeft.Enabled = flag;
            //radioButtonNumericKeyPadRight.Enabled = flag;
        }

        private void buttonHomePagePreview_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBoxHomePageUrl.Text);
            textBoxHomePageUrl.Focus();

        }

        private void buttonUpdateHistoryPreview_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBoxUpdateHistoryUrl.Text);
            textBoxUpdateHistoryUrl.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int right = this.Location.X;
            int bottom = this.Location.Y;
            Control ctl = FindControlRecursive(tabControl1, "tabControl1");

            right += ctl.Location.X;
            bottom += ctl.Location.Y;

            ctl = FindControlRecursive(tabControl1, "groupBox10");

            right += ctl.Location.X;
            bottom += ctl.Location.Y;

            ctl = FindControlRecursive(tabControl1, "button1");

            right += ctl.Location.X;
            bottom += ctl.Location.Y;
            

            Point np = new Point(right, bottom);

            //Help.ShowPopup(this, "Commands:\r\n"+
            ////"   \r\n" +
            //"        {barCode}\r\n" +
            //"        {vendorId}\r\n" +
            //"        {productCode}\r\n" +
            //"        {quantity}\r\n" +
            //"        {tag}\r\n" +
            //"        {depotName}\r\n" +
            //"        {description}\r\n" +
            //"        {dozen}\r\n" +
            //"        {date}\r\n" +
            //"        {stageId}\r\n" +
            //"        \r\n" +
            //"        {time}\r\n" +
            //"        {masterProductCode}\r\n" +
            ////"        {f_45}\r\n" +
            //"        {weight}\r\n" +
            //"        {volume}\r\n" +
            //"        \r\n" +
            //"        {productDescription[n]}\r\n" +
            //"        {productQuantity[n]}\r\n" +
            //"            n = 0 to 4 (up to five products)\r\n" +
            //"        \r\n",
            //np);

            if (comboBoxStagingType.SelectedIndex == 0) //standard staging
                Help.ShowPopup(this, "Commands:\r\n" +
                //"   \r\n" +
                "        {barCode}\r\n" +
                "        {vendorId}\r\n" +
                "        {productCode}\r\n" +
                "        {quantity}\r\n" +
                "        {tag}\r\n" +
                "        {depotName}\r\n" +
                "        {description}\r\n" +
                "        {dozen}\r\n" +
                "        {date}\r\n" +
                "        {stageId}\r\n" +
                "        \r\n",
                np);
            else
                Help.ShowPopup(this, "Commands:\r\n" +
                //"   \r\n" +
                "        {barCode}\r\n" +
                "        {vendorId}\r\n" +
                "        {tag}\r\n" +
                "        {date}\r\n" +
                "        {stageId}\r\n" +
                "        {time}\r\n" +
                "        {masterProductCode}\r\n" +
                //"        {f_45}\r\n" +
                "        {weight}\r\n" +
                "        {volume}\r\n" +
                "        \r\n" +
                "        {description[n]}\r\n" +
                "        {quantity[n]}\r\n" +
                "            n = 0 to 4 (up to five products)\r\n" +
                "        \r\n",
                np);

        }

        public Control FindControlRecursive(Control container, string name)
        {
            if (container.Name == name)
                return container;
 
            foreach (Control ctrl in container.Controls)
            {
                Control foundCtrl = FindControlRecursive(ctrl, name);
                if (foundCtrl != null)
                    return foundCtrl;
            }
            return null;
        }

        private void radioButtonPrintChit_CheckedChanged(object sender, EventArgs e)
        {
            //groupBoxChitTicket.Enabled = radioButtonPrintChit.Checked;
            chitTicketPanel.Enabled = radioButtonPrintChit.Checked;

            //checkBoxCashOutPrintingOverride.Enabled = radioButtonQuickCheckOut.Checked;
        }

        private void buttonInstallFonts_Click(object sender, EventArgs e)
        {

            string fontFolder = Main.appFolder + "\\Varios\\";

            StringBuilder shortPath = new StringBuilder(255);
            GetShortPathName(fontFolder, shortPath, shortPath.Capacity);
            string shortFontFolder = shortPath.ToString();

            string fontFile = "ARIALN";         //"BaroqueScript";   //
            string fontName = "Arial Narrow";   //"Baroque Script";    //
            string fontFileName = fontFile + ".ttf";
            string batFileName = fontFile + ".bat";
            string regFileName = fontFile + ".reg";

            string lines = String.Empty;

            //bat file
            //@echo off
            //xcopy h:\BaroqueScript.ttf "%WinDir%\Fonts"
            //regedit /s h:\BaroqueScript.reg
            lines = "@echo off\r\n" +
                "xcopy " + shortFontFolder + fontFileName + " \"%WinDir%\\Fonts\"\r\n" +
                "regedit /s " + shortFontFolder + regFileName + "\r\n";

            // Write the string to a file.
            System.IO.StreamWriter file;
            try
            {
                file = new System.IO.StreamWriter(fontFolder + batFileName);
                file.WriteLine(lines);
                file.Close();
            }
            catch
            {
                MessageBox.Show("Need to run Solum as an Administrator.");   // Please close Solum and log off from your computer to make changes available.");
                return;
            }

            //reg file
            //Windows Registry Editor Version 5.00
            //[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts]
            // "BaroqueScript (TrueType)"="BaroqueScript.ttf" 

            lines = "Windows Registry Editor Version 5.00\r\n"+
                "[HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts] \r\n" +
                " \"" + fontName + " (TrueType)\"=\"" + fontFile + ".ttf\"\r\n";

            // Write the string to a file.
            file = new System.IO.StreamWriter(fontFolder + regFileName);
            file.WriteLine(lines);
            file.Close();

            Font testFont = new Font(fontName, 8.0f, FontStyle.Regular,
                         GraphicsUnit.Pixel);

            //if (testFont.Name != fontName)
            //{
                // The font exists, so use it.
                try
                {

                    ProcessStartInfo procInfo = new ProcessStartInfo();
                    procInfo.UseShellExecute = true;
                    procInfo.FileName = batFileName;  //The file in that DIR.
                    procInfo.WorkingDirectory = fontFolder; //The working DIR.
                    procInfo.Verb = "runas";
                    Process.Start(procInfo);  //Start that process.

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                    return;

                }

                //to avoid having restart the computer
                int result = AddFontResourceA(fontFolder + fontFileName);
                MessageBox.Show("Fonts installed successfully. Now, Solum needs to restart.");   // Please close Solum and log off from your computer to make changes available.");
                System.Windows.Forms.Application.Restart();
            //}
            //else
            //{
            //    MessageBox.Show("Fonts already installed.");
            //}

        }

        private void comboBoxContainers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentNumericTextBoxContainerID == null)
                return;

            try
            {
                currentNumericTextBoxContainerID.Text = comboBoxContainers.SelectedValue.ToString();
            }
            catch { }
            currentLabelContainerDescription.Text = comboBoxContainers.Text;


        }

        private void labelWhiteBagDescription_Click(object sender, EventArgs e)
        {

            ActivateContainersComboBox((Label)sender, numericTextBoxWhiteBagId);
        }

        private void labelBlueBagDescription_Click(object sender, EventArgs e)
        {

            ActivateContainersComboBox((Label)sender, numericTextBoxBlueBagId);

        }

        private void labelOneWayBag_Click(object sender, EventArgs e)
        {
            ActivateContainersComboBox((Label)sender, numericTextBoxOneWayBagId);

        }

        private void labelABCRCPallet_Click(object sender, EventArgs e)
        {
            ActivateContainersComboBox((Label)sender, numericTextBoxABCRCPalletId);

        }


        //activate container's combobox
        private void ActivateContainersComboBox(Label labelSender, NumericTextBox numericTextBoxIdSender)
        {
            currentLabelContainerDescription = labelSender; //labelWhiteBagDescription;
            currentNumericTextBoxContainerID = numericTextBoxIdSender;// numericTextBoxWhiteBagId;
            if (!comboBoxContainers.Visible)
                comboBoxContainers.Visible = true;
            comboBoxContainers.Location = labelSender.Location; // labelWhiteBagDescription.Location;    //new System.Drawing.Point(400, 26);

            //force change selectvalue in container's combobox
            string id = numericTextBoxIdSender.Text;    // numericTextBoxWhiteBagId.Text;
            numericTextBoxIdSender.Text = "";   // numericTextBoxWhiteBagId.Text = "";
            numericTextBoxIdSender.Text = id;   // numericTextBoxWhiteBagId.Text = id;


        }

        private void numericTextBoxWhiteBagId_TextChanged(object sender, EventArgs e)
        {
            DisplayContainerAssigned((NumericTextBox)sender, labelWhiteBagDescription);

        }

        private void numericTextBoxBlueBagId_TextChanged(object sender, EventArgs e)
        {
            DisplayContainerAssigned((NumericTextBox)sender, labelBlueBagDescription);

        }

        private void numericTextBoxOneWayBagId_TextChanged(object sender, EventArgs e)
        {
            DisplayContainerAssigned((NumericTextBox)sender, labelOneWayBagDescription);

        }

        private void numericTextBoxABCRCPalletId_TextChanged(object sender, EventArgs e)
        {
            DisplayContainerAssigned((NumericTextBox)sender, labelABCRCPalletDescription);

        }


        //activate container's combobox
        private void DisplayContainerAssigned(NumericTextBox numericTextBoxIdSender, Label labelSender )
        {

            if (String.IsNullOrEmpty(numericTextBoxIdSender.Text))  //numericTextBoxWhiteBagId.Text))
            {
                comboBoxContainers.SelectedValue = -1;
                labelSender.Text = "Unassigned";    //labelWhiteBagDescription.Text = "Unassigned";
                return;
            }

            int intValue = -1;
            //Int32.TryParse(numericTextBoxWhiteBagId.Text, out intValue);
            Int32.TryParse(numericTextBoxIdSender.Text, out intValue);
            comboBoxContainers.SelectedValue = intValue;
            //labelWhiteBagDescription.Text = comboBoxContainers.Text;
            labelSender.Text = comboBoxContainers.Text;

        }

        private void WSbuttonReceiptDefault_Click(object sender, EventArgs e)
        {
            WStextBoxOpenDrawer.Text =
                "27\r\n" +
                "112\r\n" +
                "48\r\n" +
                "100\r\n" +
                "100\r\n";

            WStextBoxCutPaper.Text =
                "27\r\n" +
                "105\r\n";

        }

        private void buttonShippingContainerTypes_Click(object sender, EventArgs e)
        {
            Containers f1 = new Containers();
            f1.AbcrcAgency = true;
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void checkBoxCoinDispenserEnable_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = checkBoxCoinDispenserEnable.Checked;
            comboBoxCoinDispenserDevice.Enabled = flag;
            coinDispenserPanel.Enabled = flag;
            //groupBoxTFlexCoinDispenserSetup.Enabled = flag;

            if (flag && !firsTimeFlag)
                MessageBox.Show("Remember to install driver and configure selected Coin Dispenser!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void comboBoxCoinDispenserDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            short index = (short)comboBoxCoinDispenserDevice.SelectedIndex;
            if (index >= 0)
            {
                coinDispenserPanel.Visible = true;
            }
        }

        private void comboBoxCoinDispenserTFlexCommunicationChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            short index = (short)comboBoxCoinDispenserTFlexCommunicationChannel.SelectedIndex;
            //if (index == 0)
                //groupBoxTFlexCoinDispenserSerial.Enabled = false;
            //else
               // groupBoxTFlexCoinDispenserSerial.Enabled = true;

        }

        private void buttonCoinDispenserTFlexGetConfigSettings_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeDevice();
            this.Cursor = Cursors.Default;
            if (CashierCash.AxCoinUSB2 == null)
                return;

            textBoxCoinDispenserTFlexDispenseBelowAmount.Enabled = true;
            buttonCoinDispenserTFlexGetConfigSettings.Enabled = false;
            buttonCoinDispenserTFlexSetConfigSettings.Enabled = true;
            textBoxCoinDispenserTFlexDispenseBelowAmount.Text = CashierCash.AxCoinUSB2.DispenseBelowValue.ToString();
        }

        private void buttonCoinDispenserTFlexSetConfigSettings_Click(object sender, EventArgs e)
        {
            int iRetVal = 0;
            //textBoxCoinDispenserTFlexDispenseBelowAmount.Text = "500";  //for canada
            int.TryParse(textBoxCoinDispenserTFlexDispenseBelowAmount.Text, out iRetVal);

            if (iRetVal == CashierCash.AxCoinUSB2.DispenseBelowValue)
                return;

            //CashierCash.AxCoinUSB2.EnterSetupMode();
            this.Cursor = Cursors.WaitCursor;

            //CashierCash.AxCoinUSB2.GetConfigSettings();
            CashierCash.AxCoinUSB2.DispenseBelowValue = iRetVal;
            iRetVal = CashierCash.AxCoinUSB2.LoadConfigSettings();
            //if (iRetVal == CashierCash.SUCCESS)
                UpdateStatus("Setup loaded!");
            //else
                //UpdateStatus(CashierCash.AxCoinUSB2.GetTransactLastError());
            //CashierCash.AxCoinUSB2.ExitSetupMode();

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
                        if (CashierCash.AxCoinUSB2 != null)
                        {
                            //Get our status and show the user
                            UpdateCanisterStatus(false, 0);
                            //default cursor
                            this.Cursor = Cursors.Default;
                            return;
                        }

                        try
                        {
                            CashierCash.AxCoinUSB2 = new AxCOINUSBLib.AxCoinUSB();
                            CashierCash.AxCoinUSB2.CreateControl();
                        }
                        catch
                        {
                            //default cursor
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Error creating object for Coin Dispenser!\r\nDid you install and configure the driver for it?\r\nSolum will continue without the use of a Coin Dispenser",
                                "", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                        CashierCash.AxCoinUSB2.CommunicationChannel = flag;
                        // Call OCX Method "SetProtocol" to set the Protocol
                        lRetVal = CashierCash.AxCoinUSB2.SetProtocol(Properties.Settings.Default.CoinDispenserTFlexSetProtocol);
                        // Call OCX Method "InitPortSettings" to initialize Communication.
                        // Before calling this method One should set "CommunicationChannel".
                        // In Case of Serial Communication, One should set "CommBaud", "CommPort" properties
                        // along with "Communicationchannel" property.
                        if (Properties.Settings.Default.CoinDispenserTFlexCommunicationChannel == 1)    //serial
                        {
                            CashierCash.AxCoinUSB2.CommBaud = Properties.Settings.Default.CoinDispenserTFlexSetCommBaud;
                            CashierCash.AxCoinUSB2.CommPort = Properties.Settings.Default.CoinDispenserTFlexSetCommBaud;
                        }

                        //
                        lRetVal = CashierCash.AxCoinUSB2.InitPortSettings(ref strOcxVersion);
                        if (lRetVal == CashierCash.SUCCESS)
                        {
                            UpdateStatus("Found Telequip Active X Control Version " + strOcxVersion + ". Comm OK");
                            // We are talking. Clear machine and semsor status.
                            CashierCash.AxCoinUSB2.ClearMachineStatus();
                            CashierCash.AxCoinUSB2.ClearSensorStatus();
                        }
                        else
                        {
                            // If the active x control can//t communicate with the
                            // TFlex we end up here. The program will exit.
                            //defualt cursor
                            //this.Cursor = Cursors.Default;
                            //MessageBox.Show(AxCoinUSB2.GetTransactLastError(), "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            UpdateStatus(CashierCash.AxCoinUSB2.GetTransactLastError().Trim() + "\r\nPlease check that Coin Dispenser is ON, connected and loaded with coins! Then click on Reconnect.");
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

        private void UpdateCanisterStatus(bool checkDispense, int amount)
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

            lRetVal = CashierCash.AxCoinUSB2.GetMachineStatus(ref machineStatus);
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
            if (lRetVal == CashierCash.SUCCESS)
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
                    UpdateStatus(c+"Coins dispensed: " + amount.ToString() + " cents.");
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



        #endregion

        private void checkBoxChitTicketIncludeBarcode_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxIncludeSecurityCode.Enabled = checkBoxChitTicketIncludeBarcode.Checked;
        }

        
        private void checkBoxAutoTagNumber_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTagNumber.Enabled = ((CheckBox)sender).Checked;
        }

        private void checkBoxAutoRBillNumber_CheckedChanged(object sender, EventArgs e)
        {
            textBoxRBillNumber.Enabled = ((CheckBox)sender).Checked;

        }

        private void checkBoxCardReader_Enabled_CheckedChanged(object sender, EventArgs e)
        {
            //groupBoxCardReader.Enabled = checkBoxCardReader_Enabled.Checked;
        }

        private void comboBoxMsrEmulationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (comboBoxMsrEmulationMode.SelectedIndex == 0)            //HID
            {
                flag = true;
                textBoxMsrVid.Enabled = flag;
                textBoxMsrPid.Enabled = flag;
                textBoxMsrCharSeparator.Enabled = false;
            }
            else if (comboBoxMsrEmulationMode.SelectedIndex == 1)       //KB
            {
                textBoxMsrVid.Enabled = flag;
                textBoxMsrPid.Enabled = flag;
                textBoxMsrCharSeparator.Enabled = true;
            }
        }

        private void buttonQdsCardTypes_Click(object sender, EventArgs e)
        {
            CardTypes f1 = new CardTypes();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void buttonQdsPaymentMethods_Click(object sender, EventArgs e)
        {
            PaymentMethods f1 = new PaymentMethods();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void buttonQdsPaymentMethodsAvailableByDepot_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxQdsDepotId.Text))
            {
                MessageBox.Show("depotID cannot be empty!");
                return;
            }
            if (Main.QuickDrop_DepotID != textBoxQdsDepotId.Text)
            {
                if (depotIDReferences(textBoxQdsDepotId.Text))
                    return;
            }

            qds_Setting = qds_Setting_Sp.Select("QuickDrop_DepotID");
            Main.QuickDrop_DepotID = textBoxQdsDepotId.Text;
            qds_Setting.SetValue = Main.QuickDrop_DepotID;
            //update
            qds_Setting_Sp.Update(qds_Setting);


            PaymentMethodAvailableByDepot f1 = new PaymentMethodAvailableByDepot();
            f1.ShowDialog();
            f1.Dispose();
            f1 = null;

        }

        private void comboBoxBarcodeEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxBarcode.BackgroundImage = null;
            string errorMessage = string.Empty;
            SolFunctions.GenerateBarcode(
                        comboBoxBarcodeEncoding.SelectedIndex
                        , Properties.Settings.Default.BarcodeWidth
                        , Properties.Settings.Default.BarcodeHeight
                        , BarcodeLib.AlignmentPositions.CENTER
                        , System.Drawing.RotateFlipType.RotateNoneFlipNone
                        , BarcodeLib.LabelPositions.BOTTOMCENTER
                        , "1234567890"
                        , string.Empty
                        , BarcodeLib.SaveTypes.BMP
                        , groupBoxBarcode
                        , ref errorMessage
                        );


        }

        private void textBoxBarcodeWidth_TextChanged(object sender, EventArgs e)
        {
            int width = 0;
            int.TryParse(textBoxBarcodeWidth.Text, out width);
            int height = 0;
            int.TryParse(textBoxBarcodeHeight.Text, out height);

            groupBoxBarcode.BackgroundImage = null;
            string errorMessage = string.Empty;
            SolFunctions.GenerateBarcode(
                        comboBoxBarcodeEncoding.SelectedIndex
                        , width
                        , height
                        , BarcodeLib.AlignmentPositions.CENTER
                        , System.Drawing.RotateFlipType.RotateNoneFlipNone
                        , BarcodeLib.LabelPositions.BOTTOMCENTER
                        , "1234567890"
                        , string.Empty
                        , BarcodeLib.SaveTypes.BMP
                        , groupBoxBarcode
                        , ref errorMessage
                        );

        }

        private void textBoxBarcodeHeight_TextChanged(object sender, EventArgs e)
        {
            int width = 0;
            int.TryParse(textBoxBarcodeWidth.Text, out width);
            int height = 0;
            int.TryParse(textBoxBarcodeHeight.Text, out height);

            groupBoxBarcode.BackgroundImage = null;
            string errorMessage = string.Empty;
            SolFunctions.GenerateBarcode(
                        comboBoxBarcodeEncoding.SelectedIndex
                        , width
                        , height
                        , BarcodeLib.AlignmentPositions.CENTER
                        , System.Drawing.RotateFlipType.RotateNoneFlipNone
                        , BarcodeLib.LabelPositions.BOTTOMCENTER
                        , "1234567890"
                        , string.Empty
                        , BarcodeLib.SaveTypes.BMP
                        , groupBoxBarcode
                        , ref errorMessage
                        );

        }
        
        
//#DISABLELOCALDB
        private void buttonAdvModesBrowse_Click(object sender, EventArgs e)
        {
//           DialogResult result = folderBrowserDialog1.ShowDialog();
//            if (result == DialogResult.OK)
//                textBoxAdvModesBackupsFolder.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void checkBoxModesEnableChanging_CheckedChanged(object sender, EventArgs e)
        {
//            bool flag = checkBoxModesEnabled.Checked;
//            textBoxAdvModesBackupsFolder.Enabled = flag;
//            buttonAdvModesBrowse.Enabled = flag;

//            txtInstanceName.Enabled = flag;
//            btnCreate.Enabled = flag;
//            btnDelete.Enabled = flag;
//            btnGetAllInst.Enabled = flag;
//            btnGetInfo.Enabled = flag;
//            btnRestart.Enabled = flag;
//            btnStart.Enabled = flag;
//            btnStop.Enabled = flag;
//            btnUseDefaultInst.Enabled = flag;
//            
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
//            LocalDbCommand("create");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
//            LocalDbCommand("start");
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
 //           LocalDbCommand("restart");
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
//            if (string.IsNullOrEmpty(txtInstanceName.Text))
//            {
//                MessageBox.Show("Please enter an instance name!");
//                txtInstanceName.Focus();
//                return;
//            }

//            ISqlLocalDbProvider provider = new SqlLocalDbProvider();
//            StringBuilder info = new StringBuilder();
//            ISqlLocalDbInstance instance;
//            try
//            {
//                instance = provider.GetInstance(txtInstanceName.Text);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: "+ex.Message);
//                txtInstanceName.Focus();
//                return;

//            }

//            string state = "Stopped";
//            if(instance.GetInstanceInfo().IsRunning)
//                state = "Running";
//            info.AppendLine("Name: " + instance.GetInstanceInfo().Name);
//            info.AppendLine("Version: " + instance.GetInstanceInfo().LocalDbVersion.ToString());
//            info.AppendLine("Shared name: " + instance.GetInstanceInfo().SharedName);
//            info.AppendLine("State: " + state);
//            info.AppendLine("Pipe name: " + instance.GetInstanceInfo().NamedPipe);
//            info.AppendLine("Last start time: " + instance.GetInstanceInfo().LastStartTimeUtc.ToString());
//            txtResult.Text = info.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
//            LocalDbCommand("stop");
//
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
//            LocalDbCommand("Delete");

        }

        private void btnGetAllInst_Click(object sender, EventArgs e)
        {
//            ISqlLocalDbProvider provider = new SqlLocalDbProvider();
//            StringBuilder info = new StringBuilder();

//            try
//            {
//                foreach (ISqlLocalDbInstanceInfo instanceInfo in provider.GetInstances())
//                {
//                    info.AppendLine("Name: " + instanceInfo.Name);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + ex.Message);
//                return;

//            }


//            txtResult.Text = info.ToString();
        }

//
//        private void LocalDbCommand(string command)
//        {
//            if (string.IsNullOrEmpty(txtInstanceName.Text))
//            {
//                MessageBox.Show("Please enter an instance name!");
//                txtInstanceName.Focus();
//                return;
//            }
//            ISqlLocalDbProvider provider = new SqlLocalDbProvider();

//            try
//            {
//                switch(command.ToLower())
//                {
//                    case "start":
//                    provider.GetInstance(txtInstanceName.Text).Start();
//                    break;
//                    case "stop":
//                    provider.GetInstance(txtInstanceName.Text).Stop();
//                    break;
//                    case "restart":
//                    provider.GetInstance(txtInstanceName.Text).Restart();
//                    break;
//                    case "create":
//                    provider.CreateInstance(txtInstanceName.Text);
//                    break;
//                    case "delete":
//                    //provider.DeleteInstance(txtInstanceName.Text);
//                    break;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + ex.Message);
//                txtInstanceName.Focus();
//                return;

//            }

//            btnGetInfo.PerformClick();

//        }

        private void btnUseDefaultInst_Click(object sender, EventArgs e)
       {
//
//            ISqlLocalDbProvider provider = new SqlLocalDbProvider();
//            StringBuilder info = new StringBuilder();
//            try
//            {
//                ISqlLocalDbInstance instance = provider.GetDefaultInstance();
//                txtResult.Text = instance.GetInstanceInfo().Name.ToString();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error: " + ex.Message);
//                return;
//            }
//            btnGetInfo.PerformClick();
        }
        // END #DISABLELOCALDB


        private void comboBoxStagingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxConveyor.Enabled = comboBoxStagingType.SelectedIndex > 0;

        }

        public static Sol_WorkStation ReadWorkStation(Sol_WorkStation_Sp sol_WorkStation_Sp, string name, bool create, int conveyorId)
        {
            //computer name
            if (string.IsNullOrEmpty(name))
                name = Main.myHostName;


            if (sol_WorkStation_Sp == null)
                sol_WorkStation_Sp = new Sol_WorkStation_Sp(Properties.Settings.Default.WsirDbConnectionString);

            Sol_WorkStation workStation = sol_WorkStation_Sp.SelectByName(name);
            if (workStation == null && create)
            {
                workStation = sol_WorkStation_Sp.SelectByName("Default");
                if (workStation == null)
                {
                    workStation = new Sol_WorkStation();
                    workStation.Name = name;
                    workStation.Description = string.Empty;
                    workStation.Location = string.Empty;
                    workStation.ConveyorID = conveyorId;
                    sol_WorkStation_Sp.Insert(workStation);
                }
                else
                {
                    workStation.Name = name;
                    workStation.Description = string.Empty;
                    workStation.Location = string.Empty;
                    workStation.ConveyorID = conveyorId;
                    sol_WorkStation_Sp.Update(workStation);
                }

            }

            return workStation;

        }

        public static bool UpdateWorkStation(Sol_WorkStation_Sp sol_WorkStation_Sp, string oldName, string newName, int conveyorId)
        {
            //computer name
            if (string.IsNullOrEmpty(oldName))
                oldName = Main.myHostName;
            if (string.IsNullOrEmpty(newName))
                newName = Main.myHostName;

            if (oldName == newName)
                return true;

            if (sol_WorkStation_Sp == null)
                sol_WorkStation_Sp = new Sol_WorkStation_Sp(Properties.Settings.Default.WsirDbConnectionString);

            Sol_WorkStation workStation = sol_WorkStation_Sp.SelectByName(newName);
            if(workStation != null)
            {
                MessageBox.Show("Workstation name already exists!");
                return false;
            }


            workStation = sol_WorkStation_Sp.SelectByName(oldName);
            if (workStation != null)
            {
                workStation.Name = newName;
                //workStation.Description = string.Empty;
                //workStation.Location = string.Empty;
                workStation.ConveyorID = conveyorId;
                sol_WorkStation_Sp.Update(workStation);
                return true;
            }

            return false;

        }

        private void comboBoxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProvinceName.SelectedIndex = comboBoxProvince.SelectedIndex;
        }

        private void comboBoxProvinceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProvince.SelectedIndex = comboBoxProvinceName.SelectedIndex;
        }
        private void ResetButtonColors()
        {
            generalTabButton.BackColor = Color.FromArgb(53, 164, 212);
            workStationTabButton.BackColor = Color.FromArgb(53, 164, 212);
            advancedTabButton.BackColor = Color.FromArgb(53, 164, 212);
            returnsTabButton.BackColor = Color.FromArgb(53, 164, 212);
            cashierTabButton.BackColor = Color.FromArgb(53, 164, 212);
            
            abcrcTabButton.BackColor = Color.FromArgb(53, 164, 212);
            xpressReturnTabButton.BackColor = Color.FromArgb(53, 164, 212);
        }
        private void ChangeButtonColor(Button btn)
        {
            ResetButtonColors();
            btn.BackColor = Color.FromArgb(30, 145, 214);
                
        }

        private void generalTabButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageGeneral;
            ChangeButtonColor(generalTabButton);
        }

        private void workStationTabButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageWorkStation;
            ChangeButtonColor(workStationTabButton);
        }

        private void advancedTabButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAdvanced;
            ChangeButtonColor(advancedTabButton);
        }

        private void returnsTabButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageReturns;
            ChangeButtonColor(returnsTabButton);
        }

        private void cashierTabButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageCashier;
            ChangeButtonColor(cashierTabButton);
        }

        

        private void abcrcTabButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageABCRC;
            ChangeButtonColor(abcrcTabButton);
        }

        private void xpressReturnTabButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageQds;
            ChangeButtonColor(xpressReturnTabButton);
        }

        private void SelectLocalBottleDropCustomerButton_Click(object sender, EventArgs e)
        {
            Customers f1 = new Customers();
            f1.fromPutOnAccountForm = true;
                f1.customerType = 0;
            
            f1.ShowDialog();

            if (f1.fieldId < 1)
            {
                f1.Dispose();
                f1 = null;
                MessageBox.Show("Must select a valid customer to proceed");
                return;
            }
            bdLocalAccountNumberTextBox.Text = f1.fieldId.ToString();
            f1.Dispose();
            f1 = null;
        }
    }
}
