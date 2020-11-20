
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

using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

using System.Web.Security;
using System.IO;

namespace Solum
{
    public partial class ReportsMain : Form
    {
        static string fileName;

        private bool flagInicio = true;
        private string dateFrom, dateTo;

        public ReportsMain()
        {
            InitializeComponent();
        }

        private void ReportsMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void ReportsMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetWorkStationsLookup.sol_WorkStations' table. You can move, or remove it, as needed.
            this.sol_WorkStationsTableAdapter.Fill(this.dataSetWorkStationsLookup.sol_WorkStations);
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            toolStrip1.Renderer = new App_Code.NewToolStripRenderer();

            // TODO: This line of code loads data into the 'dataSetCashTraysLookup.sol_CashTrays' table. You can move, or remove it, as needed.
            this.sol_CashTraysTableAdapter.Fill(this.dataSetCashTraysLookup.sol_CashTrays);
            // TODO: This line of code loads data into the 'dataSetCustomerLookup.sol_Customers' table. You can move, or remove it, as needed.
            this.sol_CustomersTableAdapter.Fill(this.dataSetCustomerLookup.sol_Customers);
            // TODO: This line of code loads data into the 'dataSetUsersLookup.aspnet_Users' table. You can move, or remove it, as needed.
            this.aspnet_UsersTableAdapter.Fill(this.dataSetUsersLookup.aspnet_Users);

            //años
            int aa = Main.rc.FechaActual.Year;      // System.DateTime.Now.Year;
            byte ah = Main.Sol_ControlInfo.HistoryYears;
            int uah = aa - ah;

            dateTimePickerFrom.MinDate = DateTime.Parse(String.Format("{0}-1-1", uah));
            string c = Main.rc.FechaActual.ToString();      // DateTime.Now.ToString();



            flagInicio = true;
            dateTimePickerFrom.MaxDate = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
            dateTimePickerFrom.Value = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.MinDate = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.MaxDate = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.Value = dateTimePickerFrom.MaxDate;
            flagInicio = false;

            dateFrom = null;    // dateTimePickerFrom.Value.ToString("yyyy-MM-dd");
            dateTo = null;      // dateTimePickerTo.Value.ToString("yyyy-MM-dd");

            //disable form resizing
           // this.FormBorderStyle = FormBorderStyle.FixedSingle;

            bindReportesInRolesUsers(listBoxReports);

            if(listBoxReports.Items.Count>0)
                listBoxReports.SelectedIndex = 0;   //select 1st report
            //checkBoxDates.Enabled = true;
            ////parameters
            //checkBoxDates.Checked = false;
            //dateTimePickerFrom.Enabled = checkBoxDates.Checked;
            //dateTimePickerTo.Enabled = checkBoxDates.Checked;

            if (Properties.Settings.Default.SettingsWsReportPrintPreview)
                radioButtonPreview.Checked = true;
            else
                radioButtonPrinter.Checked = true;


            listBoxReports.Focus();

            toolStripStatusLabelServerName.Text = Properties.Settings.Default.SQLServidorNombre;
            toolStripStatusLabelToday.Text = DateTime.Today.ToShortDateString();


            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }

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


        //private void buttonFilePath_Click(object sender, EventArgs e)
        //{
        //    saveFileDialog1.FileName = textBoxFileName.Text;
        //    DialogResult result = saveFileDialog1.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        textBoxFileName.Text = this.saveFileDialog1.FileName;
        //    }
        //    else
        //    {
        //        textBoxFileName.Text = string.Empty;
        //        return;
        //    }

        //    //store last dirName
        //    string dirName = Path.GetDirectoryName(this.saveFileDialog1.FileName);
        //    if (dirName != Properties.Settings.Default.ReportsTextBoxFileNameText)
        //    {
        //        Properties.Settings.Default.ReportsTextBoxFileNameText = dirName;
        //        Properties.Settings.Default.Save();
        //    }


        //}

        private void buttonPrinter_Click(object sender, EventArgs e)
        {

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if(listBoxReports.SelectedIndex <0)
            {
                MessageBox.Show("Please select a Report");
                listBoxReports.Focus();
                return;
            }

            if (radioButtonExport.Checked)
            {
                if(comboBoxFileFormat.SelectedIndex<0)
                {
                    MessageBox.Show("No file format specified!");
                    comboBoxFileFormat.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(fileName))
                    fileName = DefaultFileName();   

                saveFileDialog1.FileName = fileName;    // textBoxFileName.Text;
                
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //textBoxFileName.Text = this.saveFileDialog1.FileName;
                    fileName = this.saveFileDialog1.FileName;
                }
                else
                {
                    //textBoxFileName.Text = string.Empty;
                    fileName = string.Empty;
                    return;
                }

                //store last dirName
                //string dirName = Path.GetDirectoryName(this.saveFileDialog1.FileName);
                //if (dirName != Properties.Settings.Default.ReportsTextBoxFileNameText)
                //{
                //    Properties.Settings.Default.ReportsTextBoxFileNameText = dirName;
                //    Properties.Settings.Default.Save();
                //}


                //if (String.IsNullOrEmpty(textBoxFileName.Text))
                //if (String.IsNullOrEmpty(fileName))
                //{
                    //textBoxFileName.Text = fileName;
                    //buttonFilePath.PerformClick();


                    //if(!string.IsNullOrEmpty(textBoxFileName.Text))
                    //    textBoxFileName.Text = fileName;
                    //if (String.IsNullOrEmpty(textBoxFileName.Text))
                    if (String.IsNullOrEmpty(fileName))
                    {
                        MessageBox.Show("No filename specified!");
                        //textBoxFileName.Focus();
                        return;
                    }
                //}

            }

            PrintReport();
        }

        private void checkBoxDates_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.Enabled = checkBoxDates.Checked;
            dateTimePickerTo.Enabled = checkBoxDates.Checked;

            if (checkBoxDates.Checked)
            {
                //dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");
                dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerFromTime.Value.ToString("HH:mm:ss"); 
                //DateTime dt = dateTimePickerTo.Value.AddDays(1);
                //dateTo = dt.ToString("yyyy-MM-dd"); // hh:mm:ss");
                //dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");
                dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerToTime.Value.ToString("HH:mm:ss"); 
            }
            else
            {
                dateFrom = null;    // dateTimePickerFrom.Value.ToString("yyyy-MM-dd");
                dateTo = null;      // dateTimePickerTo.Value.ToString("yyyy-MM-dd");
            }


        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (flagInicio)
                return;

            dateTimePickerTo.MinDate = dateTimePickerFrom.Value;
            //dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");
            dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerFromTime.Value.ToString("HH:mm:ss"); 

        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (flagInicio)
                return;

            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;
            //dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");
            dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerToTime.Value.ToString("HH:mm:ss"); 

        }


        private void dateTimePickerFromTime_ValueChanged(object sender, EventArgs e)
        {
            //if (flagInicio)
            //    return;

            //dateTimePickerToTime.MinDate = dateTimePickerFromTime.Value;
            ////dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");
            //dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerFromTime.Value.ToString("HH:mm:ss"); 

        }

        private void dateTimePickerToTime_ValueChanged(object sender, EventArgs e)
        {
            //if (flagInicio)
            //    return;

            //dateTimePickerFromTime.MaxDate = dateTimePickerToTime.Value;
            ////dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");
            //dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerToTime.Value.ToString("HH:mm:ss"); 

        }


        private void radioButtonExport_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxFileFormat.Enabled =  radioButtonExport.Checked;
            if (radioButtonExport.Checked)
            {
                comboBoxFileFormat.Focus();

            }
            //else
            //{
                //textBoxFileName.Enabled = radioButtonExport.Checked;
                //buttonFilePath.Enabled = radioButtonExport.Checked;

            //}

        }

        private void comboBoxFileFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxReports.SelectedIndex < 0)
            {
                MessageBox.Show("No Report selected");
                return;
            }

            fileName = DefaultFileName();   

            //textBoxFileName.Text = fileName;
            //textBoxFileName.Enabled = true;
            //buttonFilePath.Enabled = true;
            //textBoxFileName.Focus();


        }

        private string DefaultFileName()
        {
            string fn = listBoxReports.Text;
            switch (comboBoxFileFormat.SelectedIndex)
            {
                case 0: //rtf
                    if (fn.Substring(fn.Length - 4, 4) != ".rtf")
                        fn += ".rtf";
                    break;
                case 1: //pdf
                    if (fn.Substring(fn.Length - 4, 4) != ".pdf")
                        fn += ".pdf";
                    break;
                case 2: //word
                    //if (fileName.Substring(fileName.Length - 5, 5) != ".docx")
                    //    fileName += ".docx";
                    //else 
                    if (fn.Substring(fn.Length - 4, 4) != ".doc")
                        fn += ".doc";
                    break;

                case 3: //excel
                    //if (fileName.Substring(fileName.Length - 5, 5) != ".xlsx")
                    //    fileName += ".xlsx";
                    //else 
                    if (fn.Substring(fn.Length - 4, 4) != ".xls")
                        fn += ".xls";
                    break;

                default:
                    break;
            }

            //empty path
            if (!fn.Contains('\\') && !String.IsNullOrEmpty(Properties.Settings.Default.ReportsTextBoxFileNameText))
                fn = Properties.Settings.Default.ReportsTextBoxFileNameText + "\\" + fn;

            return fn;

        }

        private void listBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileName = string.Empty;
            //textBoxFileName.Text = string.Empty;
            checkBoxDates.Enabled = false;
            checkBoxDates.Checked = false;
            labelDateFrom.Text = "&From:";
            labelDateTo.Visible = true;
            dateTimePickerTo.Visible = true;

            dateTimePickerFrom.Enabled = false;
            dateTimePickerTo.Enabled = false;

            dateTimePickerFromTime.Enabled = false;
            dateTimePickerFromTime.Visible = false;
            dateTimePickerFromTime.Value = DateTime.Parse("00:00:00");

            dateTimePickerToTime.Enabled = false;
            dateTimePickerToTime.Visible = false;
            dateTimePickerToTime.Value = DateTime.Parse("23:59:59");


            //string value = dateTimePickerToTime.Value.ToString("HH:mm:ss"); 

            comboBoxStatus.Items.Clear();
            comboBoxStatus.Enabled = false;

            comboBoxType.Items.Clear();
            comboBoxType.Enabled = false;

            labelOrderId.Text = "&Order #";
            textBoxOrderID.Enabled = false;

            groupBoxClerkName.Enabled = false;
            groupBoxCustomer.Enabled = false;
            groupBoxCashTray.Enabled = false;
            
            checkBoxShowDetails.Enabled = false;

            switch (listBoxReports.Text)    //.SelectedIndex)
            {

                case "Category Refund Statistics":          //1.- CategoryRefundStatistics.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;
                    break;
                case "Clerk Report":                        //2.- ClerkReport.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    groupBoxClerkName.Text = "Clerk Name";
                    groupBoxClerkName.Enabled = true;
                    checkBoxAllClerks.Enabled = true;
                    checkBoxAllClerks.Checked = true;
                    comboBoxClerkName.Enabled = false;

                    comboBoxClerkName.Visible = true;
                    nameComboBox.Visible = !comboBoxClerkName.Visible;

                    //this.comboBoxClerkName.DataSource = this.aspnet_UsersBindingSource;
                    //this.comboBoxClerkName.DisplayMember = "UserName";
                    //this.comboBoxClerkName.ValueMember = "UserId";

                    break;
                case "Customer Account Statement":          //3.- CorporateAccountStatement.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    groupBoxCustomer.Enabled = true;
                    checkBoxAllCustomers.Enabled = true;
                    checkBoxAllCustomers.Checked = true;
                    comboBoxCustomers.Enabled = false;

                    break;
                case "Financial Transaction Summary":       //4.- DailyTotal.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    dateTimePickerFromTime.Enabled = true;
                    dateTimePickerFromTime.Visible = true;
                    dateTimePickerToTime.Enabled = true;
                    dateTimePickerToTime.Visible = true;

                    groupBoxCashTray.Enabled = true;
                    checkBoxAllCashTray.Enabled = true;
                    checkBoxAllCashTray.Checked = true;
                    comboBoxCashTray.Enabled = false;

                    break;
                case "Inventory":                           //5.- Inventory.rpt Hided
                    checkBoxDates.Checked = true;
                    labelDateFrom.Text = "&To:";
                    dateTimePickerFrom.Enabled = true;
                    labelDateTo.Visible = false;
                    dateTimePickerTo.Visible = false;

                    break;
                case "Inventory Reconciliation":            //6.- InventoryStatus.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;

                    break;
                case "Order Detail":                        //7.- TransactionReport.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    break;
                case "Order Duration":                      //8.- TransactionDuration.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    break;
                case "Order Search":                        //9.- TransactionSearch.rpt
                    textBoxOrderID.Enabled = true;

                    break;
                case "Order Summary":                       //10.-TransactionSummary.rpt  
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;

                    checkBoxShowDetails.Enabled = true;
                    break;
                case "Orders":                              //11.-Orders1.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    comboBoxStatus.Enabled = true;
                    comboBoxStatus.Items.Add("All");
                    comboBoxStatus.Items.Add("Normal");
                    comboBoxStatus.Items.Add("Void");
                    comboBoxStatus.Items.Add("OnAccount");
                    comboBoxStatus.Items.Add("Paid");
                    comboBoxStatus.Items.Add("InProcess");
                    comboBoxStatus.SelectedIndex = 0;

                    comboBoxType.Enabled = true;
                    comboBoxType.Items.Add("All");
                    comboBoxType.Items.Add("Returns");
                    comboBoxType.Items.Add("Sales");
                    comboBoxType.Items.Add("Adjustments");
                    comboBoxType.Items.Add("QuickDrops");
                    comboBoxType.SelectedIndex = 0;

                    checkBoxShowDetails.Enabled = true;

                    break;
                case "Purchased Inventory":                 //12.-PurchasedInventory.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    groupBoxCustomer.Enabled = true;
                    checkBoxAllCustomers.Enabled = true;
                    checkBoxAllCustomers.Checked = true;
                    comboBoxCustomers.Enabled = false;

                    break;
                case "Purchasing Category":                 //13.-PurchasingCategory.rpt

                    break;
                case "QuickDrop Orders Report":             //14.-QuickDropOrders.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;

                    comboBoxStatus.Enabled = true;
                    comboBoxStatus.Items.Add("All");
                    comboBoxStatus.Items.Add("Normal");
                    comboBoxStatus.Items.Add("Void");
                    comboBoxStatus.Items.Add("OnAccount");
                    comboBoxStatus.Items.Add("Paid");
                    comboBoxStatus.Items.Add("InProcess");
                    comboBoxStatus.SelectedIndex = 0;
                    checkBoxShowDetails.Enabled = true;
                    break;

                case "Shipment Detail":                     //15.-ShipmentDetail.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;
                    labelOrderId.Text = "&RBill Number";
                    textBoxOrderID.Enabled = true;
                    break;
                case "Shipment Summary":                    //16.-Shipment.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;

                    break;
                case "Shipment Value Calculation":          //20.-ShipmentValueCalculation.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;
                    labelOrderId.Text = "&RBill Number";
                    textBoxOrderID.Enabled = true;
                    break;
                case "Staged Containers":                   //17.-StagedContainers.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;

                    comboBoxStatus.Enabled = true;
                    comboBoxStatus.Items.Add("All");
                    comboBoxStatus.Items.Add("InProgress");
                    comboBoxStatus.Items.Add("Picked");
                    comboBoxStatus.Items.Add("Shipped");
                    comboBoxStatus.Items.Add("Void");
                    comboBoxStatus.SelectedIndex = 0;

                    break;
                case "Staging":                             //18.-Staging.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;

                    break;
                case "TimeClock":                           //19.-TimeClock.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    groupBoxClerkName.Enabled = true;
                    checkBoxAllClerks.Enabled = true;
                    checkBoxAllClerks.Checked = true;
                    comboBoxClerkName.Enabled = false;

                    break;

                case "CRIS Summary":                     //21.-CRISSummary.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Enabled = true;
                    labelOrderId.Text = "&RBill Number";
                    textBoxOrderID.Enabled = true;
                    break;

                case "Station Report":                        //2.- StationReport.rpt
                    groupBoxDates.Enabled = true;
                    checkBoxDates.Checked = true;

                    groupBoxClerkName.Text = "Station Name";
                    groupBoxClerkName.Enabled = true;
                    checkBoxAllClerks.Enabled = true;
                    checkBoxAllClerks.Checked = true;

                    nameComboBox.Enabled = false;

                    comboBoxClerkName.Visible = false;
                    nameComboBox.Visible = !comboBoxClerkName.Visible;

                    //this.comboBoxClerkName.DataSource = this.aspnet_UsersBindingSource;
                    //this.comboBoxClerkName.DisplayMember = "Name";
                    //this.comboBoxClerkName.ValueMember = "Name";

                    break;

                //case "Refund":                              //Refund.rpt    Not Used
                //    groupBoxDates.Enabled = true;
                //    checkBoxDates.Enabled = true;

                //    break;
                //case "Inventory On Hand":                   //InventoryOnHandUnstaged.rpt   Not Used
                //    groupBoxDates.Enabled = true;
                //    checkBoxDates.Checked = true;
                //    labelDateFrom.Text = "&To:";
                //    dateTimePickerFrom.Enabled = true;
                //    labelDateTo.Visible = false;
                //    dateTimePickerTo.Visible = false;

                //    break;

                default:
                    break;

            }

            //filename
            fileName = DefaultFileName();   

        }

        private void PrintReport()
        {
            string strDetails = "No";
            bool flagWhere = false;
            string c = "";

            //c = "DateFrom: "+dateFrom + " DateTo: " + dateTo;
            //MessageBox.Show(c);
            //return;

            this.Cursor = Cursors.WaitCursor;

            //query
            string query = "";
            //query 2
            string query2 = "";
            string subReportName2 = "";
            //query 3
            string query3 = "";
            string subReportName3 = "";


            string dateFromShort = "", dateToShort = "";
            //string dateFrom = "", dateTo = "";
            int orderID=0;

            int customerID = -1;

            bool flagError = false;
            string userID;

            CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new ReportDocument();

            object[,] parametros = new object[,] 
                                    { 
                                        {"", ""}
                                    };

            switch (listBoxReports.Text)    //.SelectedIndex)
            {
                //**************************
                case "Category Refund Statistics":          //1.- CategoryRefundStatistics.rpt
                //**************************
                    //query
                    query =
                        "SELECT " +
                        "    dbo.Sol_Categories.Description AS Category, SUM(dbo.sol_OrdersDetail.Quantity) AS TotalQuantity, COUNT(dbo.sol_OrdersDetail.DetailID)  AS NumOfTransactions, SUM(dbo.sol_OrdersDetail.Amount) AS TotalAmount " +
                        "FROM  " +
                        "    dbo.sol_OrdersDetail  " +
                        "INNER JOIN " +
                        "    dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID " +
                        "WHERE " +
                        "    (dbo.sol_OrdersDetail.Status = 'P' OR dbo.sol_OrdersDetail.Status = 'O') " +    //dbo.sol_OrdersDetail.Status != 'D' " +
                        "DATES " +
                        "GROUP BY " +
                        "    dbo.sol_OrdersDetail.CategoryID, dbo.Sol_Categories.Description ";

                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";

                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    if (checkBoxDates.Checked)
                    {

                        //query
                        query = query.Replace("DATES",
                            "AND " +
                            "( " +
                            " ISNULL( CONVERT(varchar(23), sol_OrdersDetail.Date, 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                            "AND " +
                            " ISNULL( CONVERT(varchar(23), sol_OrdersDetail.Date, 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                            ") "
                        );


                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();


                    }
                    else
                    {
                        query = query.Replace("DATES", "");
                    }

                    rp = new Solum.Reports.CategoryRefundStatistics();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        {"", ""}
                    };
                    break;

                //**************************
                case "Clerk Report":                        //2.- ClerkReport.rpt
                //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    dateToShort = dateTimePickerTo.Value.ToShortDateString();

                    userID = "";
                    if (!checkBoxAllClerks.Checked)
                    {
                        try
                        {
                            MembershipUser membershipUser = membershipUser = Membership.GetUser(comboBoxClerkName.Text);
                            if (membershipUser != null)
                                userID = membershipUser.ProviderUserKey.ToString();
                        }
                        catch { };

                    }


                    rp = new Solum.Reports.ClerkReport();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "DateFromDate", dateFromShort },
                        { "DateToDate", dateToShort },
                        { "UserID", userID },
                        {"", ""}
                    };
                    break;

                //**************************
                case "Customer Account Statement":          //3.- CorporateAccountStatement.rpt
                //**************************
                    //query (has a stored procedure) 
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    dateFromShort = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateToShort = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFrom = dateTimePickerFrom.Value.ToShortDateString();
                    dateTo = dateTimePickerTo.Value.ToShortDateString();

                    customerID = -1;
                    if (!checkBoxAllCustomers.Checked)
                    {

                        customerID = (int)comboBoxCustomers.SelectedValue;

                    }


                    rp = new Solum.Reports.CorporateAccountStatement();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "DateFrom", dateFromShort },
                        { "DateTo", dateToShort },
                        { "CustomerID", customerID }, 
                        { "DateFromDate", dateFrom },
                        { "DateToDate", dateTo },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Financial Transaction Summary":       //4.- DailyTotal.rpt
                //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "Daily_Expenses";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "DailyTotal_BreakDown";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    //dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerFromTime.Value.ToString("HH:mm:ss");
                    //dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " " + dateTimePickerToTime.Value.ToString("HH:mm:ss");

                    if (dateTimePickerFromTime.Value.ToString("HH:mm:ss") == "00:00:00" &&
                        dateTimePickerToTime.Value.ToString("HH:mm:ss") == "23:59:59")
                    {
                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();
                    }
                    else
                    {
                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString() + " " + dateTimePickerFromTime.Value.ToString("HH:mm:ss");
                        dateToShort = dateTimePickerTo.Value.ToShortDateString() + " " + dateTimePickerToTime.Value.ToString("HH:mm:ss");
                    }

                    int cashTrayID = -1;
                    if (!checkBoxAllCashTray.Checked)
                    {

                        cashTrayID = (int)comboBoxCashTray.SelectedValue;

                    }


                    rp = new Solum.Reports.DailyTotal();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "DateFromDate", dateTimePickerFrom.Value },   //dateFromShort },
                        { "DateToDate", dateTimePickerTo.Value },       //dateToShort },
                        { "CashTrayID", cashTrayID }, 
                        { "CashTrayName", comboBoxCashTray.Text },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Inventory":                           //5.- Inventory.rpt Hided
                //**************************
                    if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPrintInventory", true))
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    //query (has a stored procedure)
                    query = "storedprocedure";
                    query2 = "";
                    query3 = "";
                    //subreports
                    subReportName2 = "";
                    subReportName3 = "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 23:59:59";//00:00:00";
                    //dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    //dateToShort = dateTimePickerTo.Value.ToShortDateString();


                    rp = new Solum.Reports.Inventory();   // UnstagedProducts();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "DateFrom", dateFrom },
                        { "DateTo", dateFrom },
                        //{ "DateFromDate", dateFromShort },
                        { "DateToDate", dateFromShort },
                        { "CurrentUserName", Properties.Settings.Default.UsuarioNombre },
                        {"", ""}
                    };
                    break;

                //**************************
                case "Inventory Reconciliation":            //6.- InventoryStatus.rpt
                //**************************
                    if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPrintInventory", true))
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    dateToShort = dateTimePickerTo.Value.ToShortDateString();

                    rp = new Solum.Reports.InventoryStatus();

                    parametros = new object[,] 
                    { 
                        { "0_ReportName", listBoxReports.Text }, 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "DateFromDate", dateFromShort },
                        { "DateToDate", dateToShort },
                        { "CurrentUserName", Properties.Settings.Default.UsuarioNombre },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Order Detail":                        //7.- TransactionReport.rpt
                //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    dateFromShort = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateToShort = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFrom = dateTimePickerFrom.Value.ToShortDateString();
                    dateTo = dateTimePickerTo.Value.ToShortDateString();

                    rp = new Solum.Reports.TransactionReport();

                    parametros = new object[,] 
                    { 
                        { "0_ReportName", listBoxReports.Text }, 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "DateFrom", dateFromShort },
                        { "DateTo", dateToShort },
                        { "DateFromDate", dateFrom },
                        { "DateToDate", dateTo },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Order Duration":                      //8.- TransactionDuration.rpt
                //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    dateFromShort = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateToShort = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFrom = dateTimePickerFrom.Value.ToShortDateString();
                    dateTo = dateTimePickerTo.Value.ToShortDateString();

                    rp = new Solum.Reports.TransactionDuration();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "DateFrom", dateFromShort },
                        { "DateTo", dateToShort },
                        { "DateFromDate", dateFrom },
                        { "DateToDate", dateTo },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Order Search":                        //9.- TransactionSearch.rpt
                //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    if (String.IsNullOrEmpty(textBoxOrderID.Text))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("You need to specify an Order # please");
                        textBoxOrderID.Focus();
                        return;
                    }

                    orderID = Convert.ToInt32(textBoxOrderID.Text);
                    Sol_Order_Sp sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
                    Sol_Order sol_Order = sol_Order_Sp._SelectByOrderID(orderID);
                    if (sol_Order == null)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Order# not found, please try another.");
                        textBoxOrderID.Focus();
                        return;
                    }


                    rp = new Solum.Reports.TransactionSearch();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "OrderID", orderID },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Order Summary":                       //10.-TransactionSummary.rpt  
                //**************************
                    //query
                    if (checkBoxShowDetails.Checked)
                        query =
                            "SELECT TOP 100 PERCENT " +
                            "dbo.sol_Orders.OrderID, dbo.sol_Orders.Date, dbo.sol_Orders.WorkStationID, dbo.sol_Orders.ComputerName, dbo.sol_Orders.TotalAmount, dbo.sol_Orders.Status, u.UserName, dbo.sol_OrdersDetail.Description,  dbo.sol_OrdersDetail.Quantity,  dbo.sol_OrdersDetail.Amount " +
                            "FROM           " +
                            "dbo.sol_OrdersDetail  " +
                            "RIGHT OUTER JOIN " +
                            "dbo.sol_Orders  " +
                            "LEFT OUTER JOIN " +
                            "dbo.aspnet_Users u ON dbo.sol_Orders.UserID = u.UserId ON dbo.sol_OrdersDetail.OrderID = dbo.sol_Orders.OrderID " +
                            "WHERE " +
                            "dbo.sol_Orders.Status != 'D'  AND (dbo.sol_Orders.OrderType <> 'A')" +
                            "DATES " +
                            "ORDER BY  " +
                            "dbo.sol_Orders.OrderID ";

                    else
                        query =
                            "SELECT TOP 100 PERCENT " +
                            "dbo.sol_Orders.OrderID, dbo.sol_Orders.Date, dbo.sol_Orders.WorkStationID, dbo.sol_Orders.ComputerName, dbo.sol_Orders.TotalAmount, dbo.sol_Orders.Status, u.UserName " +
                            "FROM " +
                            "dbo.sol_Orders  " +
                            "INNER JOIN " +
                            "dbo.aspnet_Users u ON dbo.sol_Orders.UserID = u.UserId " +
                            "WHERE " +
                            "dbo.sol_Orders.Status != 'D' AND (dbo.sol_Orders.OrderType <> 'A') " +
                            "DATES " +
                            "ORDER BY  " +
                            "dbo.sol_Orders.OrderID ";


                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";


                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    if (checkBoxDates.Checked)
                    {

                        //query
                        query = query.Replace("DATES",
                            "AND " +
                            "( " +
                            " ISNULL( CONVERT(varchar(23), sol_Orders.Date, 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                            "AND " +
                            " ISNULL( CONVERT(varchar(23), sol_Orders.Date, 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                            ") "
                        );


                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();


                    }
                    else
                    {
                        query = query.Replace("DATES", "");
                    }

                    if (checkBoxShowDetails.Checked)
                        rp = new Solum.Reports.TransactionDetail();
                    else
                        rp = new Solum.Reports.TransactionSummary();


                    strDetails = "No";
                    if (checkBoxShowDetails.Checked)
                        strDetails = "Si";


                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        //{ "Details", strDetails },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Orders":                              //11.-Orders1.rpt
                //**************************
                    //query
                    query =
                        "SELECT [sol_Orders].[OrderID] " +
                        "      ,[sol_Orders].[OrderType] " +
                        "      ,[sol_Orders].[ComputerName] " +
                        "      ,[sol_Orders].[UserName] " +
                        "      ,[sol_Orders].[Date] " +
                        //"      ,[sol_Orders].[Name] " +
                        "      , ISNULL(c.Name, '') as Name " +
                        "      ,[sol_Orders].[TotalAmount] " +
                        "      ,[sol_Orders].[FeeAmount] " +
                        "      ,[sol_Orders].[DateClosed] " +
                        "      ,[sol_Orders].[Status] " +
                        "      , [sol_OrdersDetail] .[Description] " +
                        "      ,[sol_OrdersDetail] .[Quantity] " +
                        "      ,[sol_OrdersDetail] .[Price] " +
                        "      ,[sol_OrdersDetail] .[Amount] " +
                        "  FROM [sol_Orders] [sol_Orders] " +
                        "  INNER JOIN [sol_OrdersDetail] [sol_OrdersDetail]  ON  " +
                        "  [sol_Orders].[OrderID] = [sol_OrdersDetail] .[OrderID] " +
                        "  AND [sol_Orders].[OrderType] = [sol_OrdersDetail].[OrderType] " +
                        "  INNER JOIN [sol_Customers] as c ON c.[CustomerID] = [sol_Orders].[CustomerID] ";

                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";

                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    flagWhere = false;
                    if (checkBoxDates.Checked)
                    {

                        //query
                        query +=
                            "WHERE " +
                            "( " +
                            " ISNULL( CONVERT(varchar(23), sol_Orders.Date, 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                            "AND " +
                            " ISNULL( CONVERT(varchar(23), sol_Orders.Date, 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                            ") ";


                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();
                        flagWhere = true;

                    }

                    if (comboBoxStatus.Enabled)
                    {
                        if (comboBoxStatus.SelectedIndex > 0)
                        {
                            string st = "A";
                            switch (comboBoxStatus.Text)    //.SelectedIndex)
                            {
                                case "Normal":
                                    st = "A";
                                    break;
                                case "Void":
                                    st = "D";
                                    break;
                                case "OnAccount":
                                    st = "O";
                                    break;
                                case "Paid":
                                    st = "P";
                                    break;
                                case "InProcess":
                                    st = "I";
                                    break;
                                default:
                                    break;
                            }
                            c =
                                "WHERE " +
                                "sol_Orders.Status = '" + st + "' ";
                            if (flagWhere)
                                c = c.Replace("WHERE ", "AND ");
                            else
                                flagWhere = true;

                            query += c;
                        }
                    }
                    if (comboBoxType.Enabled)
                    {
                        if (comboBoxType.SelectedIndex > 0)
                        {
                            string ty = "R";
                            switch (comboBoxType.Text)  //.SelectedIndex)
                            {
                                case "Returns":
                                    ty = "R";
                                    break;
                                case "Sales":
                                    ty = "S";
                                    break;
                                case "Adjustments":
                                    ty = "A";
                                    break;
                                case "QuickDrop":
                                    ty = "Q";
                                    break;
                                default:
                                    break;
                            }
                            c =
                                "WHERE " +
                                "sol_Orders.OrderType = '" + ty + "' ";
                            if (flagWhere)
                                c = c.Replace("WHERE ", "AND ");
                            else
                                flagWhere = true;

                            query += c;
                        }
                    }
                    strDetails = "No";
                    if (checkBoxShowDetails.Checked)
                        strDetails = "Si";


                    rp = new Solum.Reports.Orders1();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        { "Details", strDetails },
                        {"", ""}
                    };
                    break;

                //**************************
                case "Purchased Inventory":                 //12.-PurchasedInventory.rpt
                //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    if (checkBoxDates.Checked)
                    {
                        dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                        dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();
                    }
                    else
                    {
                        dateFromShort = "";
                        dateToShort = "";
                        dateFrom = "";
                        dateTo = "";

                    }

                    customerID = -1;
                    if (!checkBoxAllCustomers.Checked)
                    {

                        customerID = (int)comboBoxCustomers.SelectedValue;

                    }

                    rp = new Solum.Reports.PurchasedInventory();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "DateFromDate", dateFromShort },
                        { "DateToDate", dateToShort },
                        { "CustomerID", customerID }, 
                        { "CustomerName", comboBoxCustomers.Text },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Purchasing Category":                 //13.-PurchasingCategory.rpt
                //**************************
                    //query
                    query =
                        "SELECT      " +
                        "dbo.Sol_Categories.Description, dbo.sol_Products.UPC, dbo.sol_Products.ProDescription " +
                        "FROM          " +
                        "dbo.sol_Products " +
                        "INNER JOIN " +
                        "dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID ";


                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";

                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";
                    rp = new Solum.Reports.PurchasingCategory();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        //{ "9_DateFrom", dateFromShort },
                        //{ "10_DateTo", dateToShort },
                        {"", ""}
                    };
                    break;
                //**************************
                case "QuickDrop Orders Report":             //14.-QuickDropOrders.rpt
                //**************************
                    //query AND o.[OrderType] = 'Q' 
                    query =@"
                    SELECT  o.[OrderID] 
                          , o.[OrderType] 
                          , o.[ComputerName] 
                          , o.[UserName] 
                          , o.[Date] 
                          , c.[Name] 
                          , o.[TotalAmount] 
                          , o.[FeeAmount] 
                          , o.[DateClosed] 
                          , o.[Status] 

                          , od.[Description] 
                          , od.[Quantity] 
                          , od.[Price] 
                          , od.[Amount] 

	                      , qd.[NumberOfBags] 

                    FROM [dbo].[sol_Orders] o 
                    LEFT JOIN  sol_Customers as c ON c.[CustomerID] = o.[CustomerID] 
                    AND o.[CustomerID] != 0 
                    INNER JOIN [dbo].[sol_OrdersDetail] od  ON o.[OrderID] = od .[OrderID]  
                    INNER JOIN [dbo].[Qds_Drop] qd ON o.[OrderID] = qd.[OrderID] 
                    ";

                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";

                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    flagWhere = false;
                    if (checkBoxDates.Checked)
                    {

                        //query
                        query +=
                            "WHERE " +
                            "( " +
                            " ISNULL( CONVERT(varchar(23), o.[Date], 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                            "AND " +
                            " ISNULL( CONVERT(varchar(23), o.[Date], 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                            ") ";


                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();
                        flagWhere = true;

                    }

                    if (comboBoxStatus.Enabled)
                    {
                        if (comboBoxStatus.SelectedIndex > 0)
                        {
                            string st = "A";
                            switch (comboBoxStatus.Text)    //.SelectedIndex)
                            {
                                case "Normal":
                                    st = "A";
                                    break;
                                case "Paid":
                                    st = "P";
                                    break;
                                case "OnAccount":
                                    st = "O";
                                    break;
                                case "Void":
                                    st = "D";
                                    break;
                                default:
                                    break;
                            }
                            c =
                                "WHERE " +
                                "o.[Status] = '" + st + "' ";
                            if (flagWhere)
                                c = c.Replace("WHERE ", "AND ");
                            else
                                flagWhere = true;

                            query += c;
                        }
                    }
                    //if (comboBoxType.Enabled)
                    //{
                    //    if (comboBoxType.SelectedIndex > 0)
                    //    {
                    //        string ty = "R";
                    //        switch (comboBoxType.Text)  //.SelectedIndex)
                    //        {
                    //            case "Returns":
                    //                ty = "R";
                    //                break;
                    //            case "Sales":
                    //                ty = "S";
                    //                break;
                    //            case "Adjustments":
                    //                ty = "A";
                    //                break;
                    //            default:
                    //                break;
                    //        }
                            //c =
                            //    "WHERE " +
                            //    "sol_Orders.OrderType = 'Q' ";
                            //if (flagWhere)
                            //    c = c.Replace("WHERE ", "AND ");
                            //else
                            //    flagWhere = true;

                            //query += c;
                    //    }
                    //}

                    strDetails = "No";
                    if (checkBoxShowDetails.Checked)
                        strDetails = "Si";


                    rp = new Solum.Reports.QuickDropOrders();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        { "Details", strDetails },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Shipment Detail":                     //15.-ShipmentDetail.rpt
                //**************************

                    //query (has a stored procedure)
                    query = "storedprocedure";
                    query2 = "";
                    query3 = "";
                    //subreports
                    subReportName2 = "";
                    subReportName3 = "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 23:59:59";//00:00:00";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    dateToShort = dateTimePickerTo.Value.ToShortDateString();

                    //parameters
                    string rbNumber = string.Empty;
                    if (!checkBoxDates.Checked)
                    {
                        if (String.IsNullOrEmpty(textBoxOrderID.Text))
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Please enter a RBill Number or select a range date!");
                            textBoxOrderID.Focus();
                            return;
                        }
                        rbNumber = textBoxOrderID.Text;
                    }

                    rp = new Solum.Reports.ShipmentDetail2();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "RBillNUmber", rbNumber },
                        {"", ""}
                    };

                    break;
                //**************************
                case "Shipment Summary":                    //16.-Shipment.rpt
                //**************************
                    //query
                    query =
                        "SELECT " +
                        "dbo.sol_Shipment.ShipmentID, dbo.sol_Shipment.RBillNumber, dbo.sol_Shipment.Date, dbo.sol_Shipment.AgencyName, Sum(CONVERT(decimal(18,4), dbo.sol_Stage.Quantity))/12 AS TotalDozen, COUNT(dbo.sol_Stage.StageID) AS NumberOfContainers, SUM(dbo.sol_Stage.Quantity)  AS TotalQuantity " +
                        "FROM  " +
                        "dbo.sol_Shipment  " +
                        "INNER JOIN " +
                        "dbo.sol_Stage ON dbo.sol_Shipment.ShipmentID = dbo.sol_Stage.ShipmentID " +
                        "WHERE " +
                        "    dbo.sol_Shipment.Status != 'D' " +
                         "DATES " +
                        "GROUP BY  " +
                        "dbo.sol_Shipment.ShipmentID, dbo.sol_Shipment.RBillNumber, dbo.sol_Shipment.Date, dbo.sol_Shipment.AgencyName ";


                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";

                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    if (checkBoxDates.Checked)
                    {

                        //query
                        query = query.Replace("DATES",
                            "AND " +
                            "( " +
                            " ISNULL( CONVERT(varchar(23), sol_Shipment.Date, 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                            "AND " +
                            " ISNULL( CONVERT(varchar(23), sol_Shipment.Date, 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                            ") "
                        );


                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();


                    }
                    else
                    {
                        query = query.Replace("DATES", "");
                    }

                    rp = new Solum.Reports.Shipment();

                    parametros = new object[,] 
                    { 
                        { "0_ReportName", listBoxReports.Text }, 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 

                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        {"", ""}
                    };
                    break;

                //**************************
                case "Shipment Value Calculation":             //20.-ShipmentValueCalculation.rpt
                    //**************************

                    //query 1
                    query = "storedprocedure";
                    query2 = "";
                    query3 = "";
                    //subreports
                    subReportName2 = "";
                    subReportName3 = "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    dateToShort = dateTimePickerTo.Value.ToShortDateString();

                    //parameters
                    rbNumber = string.Empty;
                    if (!checkBoxDates.Checked)
                    {
                        if (String.IsNullOrEmpty(textBoxOrderID.Text))
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Please enter a RBill Number or select a range date!");
                            textBoxOrderID.Focus();
                            return;
                        }
                        rbNumber = textBoxOrderID.Text;
                    }

                    rp = new Solum.Reports.ShipmentValueCalculation();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "GtsRate", Main.Sol_ControlInfo.Tax1Rate },
                        { "RBillNUmber", rbNumber },
                        {"", ""}
                    };

                    break;
                //**************************
                case "Staged Containers":                   //17.-StagedContainers.rpt
                //**************************
                    //query
                    query =
                        "SELECT [StageID] " +
                        "      ,[ShipmentID] "+
                        "      ,[UserID] "+
                        "      ,[UserName] "+
                        "      ,[Date] "+
                        "      ,[TagNumber] "+
                        "      ,[ContainerID] "+
                        "      ,[ContainerDescription] "+
                        "      ,[ProductID] "+
                        "      ,[ProductName] "+
                        "      ,[Dozen] "+
                        "      ,[Quantity] "+
                        "      ,[Price] "+
                        "      ,[Remarks] "+
                        "      ,[Status] "+
                        "  FROM [sol_Stage] ";
                        //" WHERE ";

                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";

                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    flagWhere = false;
                    if (checkBoxDates.Checked)
                    {

                        //query
                        query +=
                            "WHERE " +
                            "( " +
                            " ISNULL( CONVERT(varchar(23), sol_Stage.Date, 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                            "AND " +
                            " ISNULL( CONVERT(varchar(23), sol_Stage.Date, 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                            ") ";


                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();
                        flagWhere = true;

                    }

                    if (comboBoxStatus.Enabled)
                    {
                        if (comboBoxStatus.SelectedIndex > 0)
                        {
                            //I-InProgress; P-Picked S-Shipped D -Void 
                            string st = "I";
                            switch (comboBoxStatus.Text)    //.SelectedIndex)
                            {
                                case "InProgress":
                                    st = "I";
                                    break;
                                case "Picked":
                                    st = "P";
                                    break;
                                case "Shipped":
                                    st = "S";
                                    break;
                                case "Void":
                                    st = "D";
                                    break;
                                default:
                                    break;
                            }
                            c =
                                "WHERE " +
                                "sol_Stage.Status = '" + st + "' ";
                            if (flagWhere)
                                c = c.Replace("WHERE ", "AND ");

                            query += c;
                        }
                    }

                    rp = new Solum.Reports.StagedContainers();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        {"", ""}
                    };
                    break;
                //**************************
                case "Staging":                             //18.-Staging.rpt
                //**************************
                    //query
                    query =
                        "SELECT " +
                        "StageID, ProductName, Dozen, Date, ContainerDescription, ShipmentID, Quantity " +
                        "FROM " +
                        "dbo.sol_Stage " +
                        "WHERE " +
                        "    dbo.sol_Stage.Status != 'D' " +
                         "DATES ";

                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";

                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    if (checkBoxDates.Checked)
                    {

                        //query
                        query = query.Replace("DATES",
                            "AND " +
                            "( " +
                            " ISNULL( CONVERT(varchar(23), sol_Stage.Date, 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                            "AND " +
                            " ISNULL( CONVERT(varchar(23), sol_Stage.Date, 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                            ") "
                        );


                        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                        dateToShort = dateTimePickerTo.Value.ToShortDateString();


                    }
                    else
                    {
                        query = query.Replace("DATES", "");
                    }

                    rp = new Solum.Reports.Staging();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                        //{ "3_Address", Main.Sol_ControlInfo.Address },
                        //{ "4_City", Main.Sol_ControlInfo.City },
                        //{ "5_State", Main.Sol_ControlInfo.State },
                        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                        //{ "7_Message", "" },
                        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        {"", ""}
                    };
                    break;
                //**************************
                case "TimeClock":                           //19.-TimeClock.rpt
                //**************************

                    //training warning
                    if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
                    {
                        DialogResult result = MessageBox.Show("This information comes from Production Database. Do you want to continue?", "", MessageBoxButtons.YesNo);
                        if (result != System.Windows.Forms.DialogResult.Yes)
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }

                    }

                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    dateToShort = dateTimePickerTo.Value.ToShortDateString();

                    userID = null;
                    if (!checkBoxAllClerks.Checked)
                    {
                        try
                        {
                            MembershipUser membershipUser = membershipUser = Membership.GetUser(comboBoxClerkName.Text);
                            if (membershipUser != null)
                                userID = membershipUser.ProviderUserKey.ToString();
                        }
                        catch { };

                    }


                    rp = new Solum.Reports.TimeClock();

                    parametros = new object[,] 
                    { 
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "UserID", userID },
                        { "DateFromDate", dateFromShort },
                        { "DateToDate", dateToShort },
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        {"", ""}
                    };

                    break;

                //**************************
                case "CRIS Summary":                     //21.-CRISSummary.rpt
                    //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    query2 = "";
                    query3 = "";
                    //subreports
                    subReportName2 = "";
                    subReportName3 = "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    dateToShort = dateTimePickerTo.Value.ToShortDateString();

                    //parameters
                    rbNumber = string.Empty;
                    if (!checkBoxDates.Checked)
                    {
                        if (String.IsNullOrEmpty(textBoxOrderID.Text))
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Please enter a RBill Number or select a range date!");
                            textBoxOrderID.Focus();
                            return;
                        }
                        rbNumber = textBoxOrderID.Text;
                    }

                    rp = new Solum.Reports.CRISSummary();

                    parametros = new object[,] 
                    { 
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                        { "9_DateFrom", dateFromShort },
                        { "10_DateTo", dateToShort },
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "RBillNUmber", rbNumber },
                        {"", ""}
                    };

                    break;

                //**************************
                case "Station Report":                        //2.- StationReport.rpt
                //**************************
                    //query (has a stored procedure)
                    query = "storedprocedure";
                    subReportName2 = "";
                    //query 2
                    query2 =
                        "";
                    subReportName3 = "";
                    //query 3
                    query3 =
                        "";

                    //for parameters
                    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                    dateToShort = dateTimePickerTo.Value.ToShortDateString();

                    string workStationName = "";
                    if (!checkBoxAllClerks.Checked)
                    {
                        workStationName = nameComboBox.Text;
                    }


                    rp = new Solum.Reports.StationReport();

                    parametros = new object[,]
                    {
                        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName },
                        { "DateFrom", dateFrom },
                        { "DateTo", dateTo },
                        { "DateFromDate", dateFromShort },
                        { "DateToDate", dateToShort },
                        { "WorkStation", workStationName },
                        {"", ""}
                    };
                    break;

                ////**************************
                //case "Refund":                              //Refund.rpt    Not Used
                ////**************************
                //    //query
                //    query =
                //        "SELECT " +
                //        "    dbo.sol_OrdersDetail.Date, SUM(dbo.sol_OrdersDetail.Amount) AS TotalAmount "+
                //        "FROM  " +
                //        "    dbo.sol_OrdersDetail " +
                //        "INNER JOIN " +
                //        "    dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID " +
                //        "WHERE " +
                //        "    dbo.sol_OrdersDetail.Status != 'D' " +
                //        "AND " +
                //        "    dbo.sol_OrdersDetail.OrderType != 'A' " +  //avoid adjustments
                //        "DATES " +
                //        "GROUP BY " +
                //        "    dbo.sol_OrdersDetail.Date ";



                //    subReportName2 = "";
                //    //query 2
                //    query2 =
                //        "";

                //    subReportName3 = "";
                //    //query 3
                //    query3 =
                //        "";

                //    if (checkBoxDates.Checked)
                //    {

                //        //query
                //        query = query.Replace("DATES",
                //            "AND " +
                //            "( " +
                //            " ISNULL( CONVERT(varchar(23), sol_OrdersDetail.Date, 120), '" + dateFrom + "' )  >= '" + dateFrom + "'  " +
                //            "AND " +
                //            " ISNULL( CONVERT(varchar(23), sol_OrdersDetail.Date, 120), '" + dateFrom + "' ) <= '" + dateTo + "' " +
                //            ") "
                //        );


                //        dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                //        dateToShort = dateTimePickerTo.Value.ToShortDateString();


                //    }
                //    else
                //    {
                //        query = query.Replace("DATES", "");
                //    }

                //    rp = new Solum.Reports.Refund();

                //    parametros = new object[,] 
                //    { 
                //        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                //        //{ "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() }, 
                //        //{ "3_Address", Main.Sol_ControlInfo.Address },
                //        //{ "4_City", Main.Sol_ControlInfo.City },
                //        //{ "5_State", Main.Sol_ControlInfo.State },
                //        //{ "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                //        //{ "7_Message", "" },
                //        //{ "8_LegalName", Main.Sol_ControlInfo.LegalName },
                //        { "9_DateFrom", dateFromShort },
                //        { "10_DateTo", dateToShort },
                //        {"", ""}
                //    };
                //    break;

                ////**************************
                //case "Inventory On Hand":                   //InventoryOnHandUnstaged.rpt   Not Used
                ////**************************
                //    if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPrintInventory", true))
                //    {
                //        this.Cursor = Cursors.Default;
                //        return;
                //    }

                //    //query (has a stored procedure)
                //    query = "";
                //    subReportName2 = "";
                //    //query 2
                //    query2 =
                //        "";
                //    subReportName3 = "";
                //    //query 3
                //    query3 =
                //        "";

                //    //for parameters
                //    dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 23:59:59";//00:00:00";
                //    //dateToShort = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                //    dateFromShort = dateTimePickerFrom.Value.ToShortDateString();
                //    //dateTo = dateTimePickerTo.Value.ToShortDateString();

                //    rp = new Solum.Reports.InventoryOnHandUnstaged();

                //    parametros = new object[,] 
                //    { 
                //        { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                //        //{ "DateFrom", dateFromShort },
                //        { "DateTo", dateFrom },
                //        //{ "DateFromDate", dateFrom },
                //        { "DateToDate", dateFromShort },
                //        { "CurrentUserName", Properties.Settings.Default.UsuarioNombre },
                //        {"", ""}
                //    };
                //    break;

                //**************************
                default:
                //**************************
                    groupBoxDates.Enabled = false;
                    flagError = true;
                    rp = new Solum.Reports.Inventory();   // to avoid error
                    parametros = new object[,] 
                    { 
                        {"", ""}
                    };

                    break;

            }

            if (!flagError)
            {

                bool imprimirReporte = false;
                bool exportarReporte = false;
                short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
                string filePath = "";
                bool preverReporte = false;
                short numeroDeCopias = 1;

                if (radioButtonPreview.Checked)
                    preverReporte = true;
                else if (radioButtonExport.Checked)
                {
                    exportarReporte = true;      //export
                    fileFormat = (short)comboBoxFileFormat.SelectedIndex;
                    filePath = fileName;// textBoxFileName.Text;
                    //aqui Properties.Settings.Default.ReportsTextBoxFileNameText= 
                }
                else
                    imprimirReporte = true;

                ReportesPrevista f1 = new ReportesPrevista(
                    Properties.Settings.Default.WsirDbConnectionString,
                    Properties.Settings.Default.SQLServidorNombre,
                    Properties.Settings.Default.SQLBaseDeDatos,     //wsir_
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
                    filePath,
                    true,
                    true
                    );
                f1.WindowState = FormWindowState.Maximized;
                f1.ShowDialog();
                f1.Dispose();
                f1 = null;

            }

            this.Cursor = Cursors.Default;

        }

        private void checkBoxAllClerks_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxClerkName.Enabled = !checkBoxAllClerks.Checked;

            nameComboBox.Enabled = !checkBoxAllClerks.Checked;

        }

        private void checkBoxAllCustomers_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxCustomers.Enabled = !checkBoxAllCustomers.Checked;

        }

        private void checkBoxAllCashTray_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxCashTray.Enabled = !checkBoxAllCashTray.Checked;
        }

        private void bindReportesInRolesUsers(ListBox lista)
        {
            bool flag = false;
            try
            {
                List<SirLib.wsir_Reportes_info> wsir_Reportes_infoList = SirLib.wsir_Reportes.LeerRegistros(Properties.Settings.Default.WsirConnectionString);
                foreach (SirLib.wsir_Reportes_info ri in wsir_Reportes_infoList)
                {
                    //hide reports
                    if (ri.ReporteNombre == "Inventory.rpt")
                        continue;

                    flag = true;
                    if (!(Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
                        || Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")))
                    {

                        flag = SirLib.wsir_ReportesEnUsers.Existe(Properties.Settings.Default.WsirConnectionString,
                            ri.ReporteNombre,
                            Properties.Settings.Default.UsuarioNombre);
                        if (!flag)
                        {
                            //search in user roles' permissions
                            try
                            {
                                string[] rolesArray;
                                rolesArray = Roles.GetRolesForUser(Properties.Settings.Default.UsuarioNombre);
                                foreach (string role in rolesArray)
                                {
                                    //is an admin role member?
                                    if (role == "admin")
                                    {
                                        flag = true;
                                        break;
                                    }

                                    //has a role report
                                    flag = SirLib.wsir_ReportesEnRoles.Existe(Properties.Settings.Default.WsirConnectionString,
                                        ri.ReporteNombre,
                                        role);

                                    if (flag)
                                        break;

                                }
                            }
                            catch
                            {
                                //
                            }

                            //flag = SirLib.wsir_ReportesEnRoles.Existe(Properties.Settings.Default.WsirConnectionString,
                            //    ri.ReporteNombre,
                            //    labelNombre.Text);
                        }
                    }
                    if (!flag)
                        continue;
                    lista.Items.Add(ri.Descripcion);
                }
            }
            catch
            {
                //
            }
        }
    }
}
