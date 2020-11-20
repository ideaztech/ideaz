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

namespace Solum
{
    public partial class Inventory : Form
    {
        private ArrayList 
            arrayListViewCategoryId,
            arrayListViewQuantity,
            arrayListViewRefundAmount;

        Sol_Order sol_Order;
        Sol_Order_Sp sol_Order_Sp;
        Sol_OrdersDetail sol_OrdersDetail;
        Sol_OrdersDetail_Sp sol_OrdersDetail_Sp;

        private bool flagInicio = true;
        private string dateFrom, dateTo;

        private Sol_Shipment sol_Shipment;
        private Sol_Shipment_Sp sol_Shipment_Sp;
        private List<Sol_Shipment> sol_ShipmentList;

        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;
        private List<Sol_Stage> sol_StageList;

        public Inventory(string Texto, string User, string Server, string Today)
        {
            InitializeComponent();

            this.Text = Texto;
            toolStripStatusLabelUser.Text = User.Trim() + ".";
            toolStripStatusLabelMessage.Text = "Message for Inventory";
            toolStripStatusLabelServerName.Text = Server;
            toolStripStatusLabelToday.Text = Today;

        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);


        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }


            //FullScreenMode
            if (Properties.Settings.Default.SettingsAdFullScreenMode)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            //años                                                      //ejemplo:
            int aa = Main.rc.FechaActual.Year;   // System.DateTime.Now.Year;                          // 2010 año actual computadora
            byte ah = Main.Sol_ControlInfo.HistoryYears;                    //   -5 años de historia
            //-----
            int uah = aa - ah;                                          // 2005 ultimo año de historia

            string c = Main.rc.FechaActual.ToString();  // DateTime.Now.ToString();

            flagInicio = true;
            dateTimePickerTo.MaxDate = Main.rc.FechaActual;
            dateTimePickerTo.Value = dateTimePickerTo.MaxDate;
            flagInicio = false;

            dateFrom = null;
            dateTo = null;
            UpdateDataSets();


            //classes of tables
            sol_Shipment = new Sol_Shipment();
            sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_ShipmentList = new List<Sol_Shipment>();

            sol_Stage = new Sol_Stage();
            sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_StageList = new List<Sol_Stage>();

            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //listview with headers
            listViewUnstagedProducts.View = View.Details;
            listViewUnstagedProducts.Columns.Add("Category", 160, HorizontalAlignment.Left);
            listViewUnstagedProducts.Columns.Add("Quantity", 100, HorizontalAlignment.Right);
            listViewUnstagedProducts.Columns.Add("Dozen", 90, HorizontalAlignment.Right);
            listViewUnstagedProducts.Columns.Add("Amount", 120, HorizontalAlignment.Right);

            listViewUnstagedProducts.FullRowSelect = true;
            //listViewCurrentStagedContainers.CheckBoxes = true;
            listViewUnstagedProducts.GridLines = true;
            //listView1.Activation = ItemActivation.OneClick;


            //listViewUnstagedProducts.FullRowSelect = true;
            //listViewUnstagedProducts.GridLines = true;
            listViewUnstagedProducts.LabelEdit = false; // true;
            listViewUnstagedProducts.columnEditable = 1;    //-1 = all


            //listview with headers
            listViewStagedProducts.View = View.Details;
            listViewStagedProducts.Columns.Add("Product Category", 175, HorizontalAlignment.Left);
            listViewStagedProducts.Columns.Add("Quantity", 100, HorizontalAlignment.Right);
            listViewStagedProducts.Columns.Add("Dozen", 90, HorizontalAlignment.Right);
            listViewStagedProducts.Columns.Add("Amount", 120, HorizontalAlignment.Right);

            listViewStagedProducts.GridLines = true;

            //array to store categoryid
            this.arrayListViewCategoryId = new ArrayList();
            this.arrayListViewQuantity = new ArrayList();
            this.arrayListViewRefundAmount = new ArrayList();


            ReadProducts(dataSetProductsUnstaged.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, labelUnstagedTotalAmount, false, "Unstaged");
            ReadProducts(dataSetProductsStaged.Tables[0], listViewStagedProducts, labelStagedTotalQuantity, labelStagedTotalAmount, false, "Staged");

            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }


        }


        private void checkBoxShowZeros_CheckedChanged(object sender, EventArgs e)
        {
            ReadProducts(dataSetProductsUnstaged.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, labelUnstagedTotalAmount, checkBoxShowZeros.Checked, "Unstaged");
            ReadProducts(dataSetProductsStaged.Tables[0], listViewStagedProducts, labelStagedTotalQuantity, labelStagedTotalAmount, checkBoxShowZeros.Checked, "Staged");
        }


        private void ReadProducts(DataTable dtable, ListView lv1, Label labelTotalQuantity, Label labelTotalAmount, bool zeros, string type)
        {
            //DataTable dtable = dataSetProductsStaged.Tables[0];

            // Clear the ListView control
            lv1.Items.Clear();
            if (type == "Unstaged")
            {
                this.arrayListViewQuantity.Clear();
                this.arrayListViewCategoryId.Clear();
                this.arrayListViewRefundAmount.Clear();
            }
            int totalQuantity = 0;
            decimal totalAmount = 0m;

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {

                    int categoryId = 0;
                    Int32.TryParse(drow["Id"].ToString(), out categoryId);
                    int quantity = 0;
                    Int32.TryParse(drow["Quantity"].ToString(), out quantity);

                    decimal refundAmount = 0;
                    Decimal.TryParse(drow["RefundAmount"].ToString(), out refundAmount);

                    if (type == "Unstaged")
                    {
                        this.arrayListViewQuantity.Add(quantity);
                        this.arrayListViewCategoryId.Add(categoryId);
                        this.arrayListViewRefundAmount.Add(refundAmount);
                    }

                    if (!zeros && quantity == 0)
                        continue;
                    
                    
                    // Define the list items
                    ListViewItem lvi;
                    lvi = new ListViewItem(drow["Description"].ToString());

                    string c = String.Format("{0:#,###,##0}", quantity);
                    lvi.SubItems.Add(c);

                    decimal dozen = 0;
                    Decimal.TryParse(drow["Dozen"].ToString(), out dozen);
                    c = String.Format("{0:###,##0}", dozen);
                    lvi.SubItems.Add(c);
                    decimal amount = 0;
                    Decimal.TryParse(drow["Amount"].ToString(), out amount);
                    c = String.Format("{0:###,##0.00}", amount);
                    lvi.SubItems.Add(c);

                    // Add the list items to the ListView
                    lv1.Items.Add(lvi);

                    totalQuantity += quantity;
                    totalAmount += amount;

                }
            }

            labelTotalQuantity.Text = String.Format("{0:#,###,##0}", totalQuantity);
            labelTotalAmount.Text = String.Format("{0:###,##0.00}", totalAmount);

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPrintInventory", true))
                return;

            this.Cursor = Cursors.WaitCursor;

            //query
            string query = "storedprocedure";
            string query2 = "";
            string query3 = "";

            //subreports
            string subReportName2 = "";
            string subReportName3 = "";

            string dateFromShort = "",  dateToShort = "";

            //for parameters
            dateFromShort = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            dateToShort = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            dateFrom = dateTimePickerTo.Value.ToShortDateString();
            dateTo = dateTimePickerTo.Value.ToShortDateString();

            //CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new CgPrg.Reportes.Crystal_Report102__Polizas();
            CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new Solum.Reports.Inventory();   // UnstagedProducts();

            object[,] parametros = new object[,] { 
                { "1_BusinessName", Main.Sol_ControlInfo.BusinessName }, 
                //{ "DateFrom", dateFromShort },
                { "DateTo", dateToShort },
                //{ "DateFromDate", dateFrom },
                { "DateToDate", dateTo },
                { "CurrentUserName", Properties.Settings.Default.UsuarioNombre },
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

            this.Cursor = Cursors.Default;

        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (flagInicio)
                return;

            dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");
            UpdateDataSets();

            ReadProducts(dataSetProductsUnstaged.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, labelUnstagedTotalAmount, checkBoxShowZeros.Checked, "Unstaged");
            ReadProducts(dataSetProductsStaged.Tables[0], listViewStagedProducts, labelStagedTotalQuantity, labelStagedTotalAmount, checkBoxShowZeros.Checked, "Staged");
        }

        private void UpdateDataSets()
        {
            // TODO: This line of code loads data into the 'dataSetProductsStaged.sol_Products_SelectAllStaged' table. You can move, or remove it, as needed.
            this.sol_Products_SelectAllStagedTableAdapter.Fill(this.dataSetProductsStaged.sol_Products_SelectAllStaged, dateFrom, dateTo);
            // TODO: This line of code loads data into the 'dataSetProductsUnstaged.sol_Products_SelectAllUnstaged' table. You can move, or remove it, as needed.
            this.sol_Products_SelectAllUnstagedTableAdapter.Fill(this.dataSetProductsUnstaged.sol_Products_SelectAllUnstaged, dateFrom, dateTo, Properties.Settings.Default.UsuarioNombre.Trim());
            //// TODO: This line of code loads data into the 'dataSetProductsUnstaged.sol_Products_SelectAllUnstaged' table. You can move, or remove it, as needed.
            //this.sol_Products_SelectAllUnstagedTableAdapter.Fill(this.dataSetProductsUnstaged.sol_Products_SelectAllUnstaged);

        }

        private void buttonInventoryAdjustment_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateProductAdjustment", true))
                return;

            if (!listViewUnstagedProducts.LabelEdit)
            {
                checkBoxShowZeros.Enabled = false;
                checkBoxShowZeros.Checked = true;
                listViewUnstagedProducts.LabelEdit = true;
                buttonInventoryAdjustment.Text = "&Save Adjustment";
                MessageBox.Show("Double Click on Quantity column to edit.\nThen click on Save Button to create the Adjustment.");
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to create this adjustment?", "", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
                return;

            checkBoxShowZeros.Enabled = true;

            listViewUnstagedProducts.LabelEdit = false;
            buttonInventoryAdjustment.Text = "&Create Adjustment";

            //create adjustment
            CreateAdjustemnt();

            UpdateDataSets();

            ReadProducts(dataSetProductsUnstaged.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, labelUnstagedTotalAmount, checkBoxShowZeros.Checked, "Unstaged");
            ReadProducts(dataSetProductsStaged.Tables[0], listViewStagedProducts, labelStagedTotalQuantity, labelStagedTotalAmount, checkBoxShowZeros.Checked, "Staged");





        }

        private void CreateAdjustemnt()
        {
            bool flagDone = false;
            //classes of tables
            sol_Order = new Sol_Order();
            sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_OrdersDetail = new Sol_OrdersDetail();
            sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);


            //if (MessageBox.Show("Do you want to continue", "Closing Voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
            //    return;

            //int totalqty = 0;
            decimal totalamt = 0.00M;
            int nrows = listViewUnstagedProducts.Items.Count;

            sol_Order.OrderType = "A";      // R = Returns, S = Sales, A = Adjustment 
            sol_Order.WorkStationID = -1;   // Main.Sol_ControlInfo.WorkStationID;

            //computer name
            string c = Properties.Settings.Default.SettingsWsWorkStationName.Trim();
            if (String.IsNullOrEmpty(c))
                c = Main.myHostName;
            sol_Order.ComputerName = c;  // 

            MembershipUser membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot create Adjustment!");
                return;
            }
            Guid userId = (Guid)membershipUser.ProviderUserKey;
            sol_Order.UserID = userId;
            sol_Order.Date = Main.rc.FechaActual; // ;// Properties.Settings.Default.FechaActual;
            sol_Order.CustomerID = 0; // (none)
            sol_Order.Status = "A";    //Applied

            //?? we close it below again with sqlserver getdate funtion
            sol_Order.DateClosed = sol_Order.Date;  //DateTime.Parse("1753-1-1 12:00:00");
            
            sol_Order.DatePaid = DateTime.Parse("1753-1-1 12:00:00");
            //sol_Order.IsNew = true;
            sol_Order_Sp.Insert(sol_Order);

            //close order
            sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");


            //int detailID
            //int orderID
            sol_OrdersDetail.OrderID = sol_Order.OrderID;
            //string orderType
            sol_OrdersDetail.OrderType = sol_Order.OrderType;
            //date
            sol_OrdersDetail.Date = sol_Order.Date;
            //string status
            sol_OrdersDetail.Status = sol_Order.Status;

            for (int i = 0; i < nrows; i++)
            {

                //int quantity
                c = listViewUnstagedProducts.Items[i].SubItems[1].Text;
                c = c.Replace("$", "");
                c = c.Replace("(", "");
                c = c.Replace(")", "");
                c = c.Replace(",", "");

                int quantity = 0;
                try
                {
                    quantity = Convert.ToInt32(c);
                }
                catch
                {
                    string m = String.Format("Error found in quantity: {0} ",c);
                    MessageBox.Show(m, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;

                }

                c = this.arrayListViewQuantity[i].ToString();

                int oldQuantity = (int)this.arrayListViewQuantity[i];
                if (oldQuantity == quantity)
                    continue;

                int adjustmenQuantity = quantity - oldQuantity;
                sol_OrdersDetail.Quantity = adjustmenQuantity;

                //totalqty = totalqty + (adjustmenQuantity);

                //int categoryID
                sol_OrdersDetail.CategoryID = (int)this.arrayListViewCategoryId[i];

                //int productID
                //string description
                sol_OrdersDetail.Description = listViewUnstagedProducts.Items[i].SubItems[0].Text;

                //decimal price
                sol_OrdersDetail.Price = (decimal)arrayListViewRefundAmount[i];

                //decimal amount
                //c = listViewUnstagedProducts.Items[i].SubItems[3].Text;
                //c = c.Replace('$', ' ');
                decimal amount = sol_OrdersDetail.Quantity * sol_OrdersDetail.Price;
                sol_OrdersDetail.Amount = amount;
                totalamt = totalamt + amount;


                //add row
                //sol_OrdersDetail.IsNew = true;
                sol_OrdersDetail_Sp.Insert(sol_OrdersDetail);

                flagDone = true;

            }

            if (flagDone)
            {
                //update TotalAmount
                sol_Order.TotalAmount = totalamt;
                //?? we close it again below with getdate() 
                sol_Order.DateClosed = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
                sol_Order_Sp.Update(sol_Order);

                //close order
                sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");

            }
            else
            {
                sol_Order_Sp.Delete(sol_Order.OrderID, sol_Order.OrderType);
                 MessageBox.Show("No adjustment created.");
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

    }
}
