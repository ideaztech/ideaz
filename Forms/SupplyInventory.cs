
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
    public partial class SupplyInventory : Form
    {
        private ArrayList
            arrayListViewContainerId,
            arrayListViewQuantity;

        Sol_SupplyInventory sol_SupplyInventory;
        Sol_SupplyInventory_Sp sol_SupplyInventory_Sp;


        private bool flagInicio = true;
        private string dateFrom, dateTo;

        public SupplyInventory(string Texto, string Server, string Today)
        {
            InitializeComponent();
            this.Text = Texto;
            //toolStripStatusLabelUser.Text = User.Trim() + ".";
            //toolStripStatusLabelMessage.Text = "Message for Inventory";
            toolStripStatusLabelServerName.Text = Server;
            toolStripStatusLabelToday.Text = Today;
        }

        private void SupplyInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void SupplyInventory_Load(object sender, EventArgs e)
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
            int aa = Main.rc.FechaActual.Year;  // System.DateTime.Now.Year;                          // 2010 año actual computadora
            byte ah = Main.Sol_ControlInfo.HistoryYears;                    //   -5 años de historia
            //-----
            int uah = aa - ah;                                          // 2005 ultimo año de historia

            dateTimePickerFrom.MinDate = DateTime.Parse(String.Format("{0}-1-1", uah));
            string c = Main.rc.FechaActual.ToString();  // DateTime.Now.ToString();

            flagInicio = true;
            dateTimePickerFrom.MaxDate = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
            dateTimePickerFrom.Value = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.MinDate = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.MaxDate = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.Value = dateTimePickerFrom.MaxDate;
            flagInicio = false;

            dateFrom = null;    // dateTimePickerFrom.Value.ToString("yyyy-MM-dd");
            dateTo = null;      // dateTimePickerTo.Value.ToString("yyyy-MM-dd");
            UpdateDataSets();


            //classes of tables
            //sol_SupplyInventory = new Sol_SupplyInventory();
            //sol_SupplyInventory_Sp = new Sol_SupplyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //listview with headers
            listViewUnstagedProducts.View = View.Details;
            listViewUnstagedProducts.Columns.Add("Container", 160, HorizontalAlignment.Left);
            listViewUnstagedProducts.Columns.Add("Quantity", 100, HorizontalAlignment.Right);
            //listViewUnstagedProducts.Columns.Add("Dozen", 90, HorizontalAlignment.Right);
            //listViewUnstagedProducts.Columns.Add("Amount", 120, HorizontalAlignment.Right);

            listViewUnstagedProducts.FullRowSelect = true;
            //listViewCurrentStagedContainers.CheckBoxes = true;
            listViewUnstagedProducts.GridLines = true;
            //listView1.Activation = ItemActivation.OneClick;

            //listViewUnstagedProducts.FullRowSelect = true;
            //listViewUnstagedProducts.GridLines = true;
            listViewUnstagedProducts.LabelEdit = false; // true;
            listViewUnstagedProducts.columnEditable = 1;    //-1 = all


            //array to store categoryid
            this.arrayListViewContainerId = new ArrayList();
            this.arrayListViewQuantity = new ArrayList();

            ReadContainers(dataSetSuppyInventoryByDate.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, false);

            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }
        }

        private void UpdateDataSets()
        {
            // TODO: This line of code loads data into the 'dataSetProductsStaged.sol_Products_SelectAllStaged' table. You can move, or remove it, as needed.
            this.sol_SupplyInventory_ByDateTableAdapter.Fill(this.dataSetSuppyInventoryByDate.sol_SupplyInventory_ByDate, dateFrom, dateTo);

        }


        private void ReadContainers(
            DataTable dtable, 
            ListView lv1, 
            Label labelTotalQuantity, 
            //Label labelTotalAmount, 
            bool zeros
            //, 
            //string type
            )
        {
            //DataTable dtable = dataSetProductsStaged.Tables[0];

            // Clear the ListView control
            lv1.Items.Clear();
            this.arrayListViewQuantity.Clear();
            this.arrayListViewContainerId.Clear();
            int totalQuantity = 0;

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DataRow drow = dtable.Rows[i];

                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {

                    int containerId = 0;
                    Int32.TryParse(drow["ContainerID"].ToString(), out containerId);
                    int quantity = 0;
                    Int32.TryParse(drow["Inventory"].ToString(), out quantity);

                        this.arrayListViewQuantity.Add(quantity);
                        this.arrayListViewContainerId.Add(containerId);

                    if (!zeros && quantity == 0)
                        continue;


                    // Define the list items
                    ListViewItem lvi;
                    lvi = new ListViewItem(drow["Description"].ToString());

                    string c = String.Format("{0:#,###,##0}", quantity);
                    lvi.SubItems.Add(c);


                    // Add the list items to the ListView
                    lv1.Items.Add(lvi);

                    totalQuantity += quantity;

                }
            }

            labelTotalQuantity.Text = String.Format("{0:#,###,##0}", totalQuantity);


        }

        private void checkBoxDates_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.Enabled = checkBoxDates.Checked;
            dateTimePickerTo.Enabled = checkBoxDates.Checked;

            if (checkBoxDates.Checked)
            {
                dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");
                //DateTime dt = dateTimePickerTo.Value.AddDays(1);
                //dateTo = dt.ToString("yyyy-MM-dd"); // hh:mm:ss");
                dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");
            }
            else
            {
                dateFrom = null;    // dateTimePickerFrom.Value.ToString("yyyy-MM-dd");
                dateTo = null;      // dateTimePickerTo.Value.ToString("yyyy-MM-dd");
            }
            UpdateDataSets();
            ReadContainers(dataSetSuppyInventoryByDate.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, false);

        }

        private void checkBoxShowZeros_CheckedChanged(object sender, EventArgs e)
        {
            ReadContainers(dataSetSuppyInventoryByDate.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, false);

        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (flagInicio)
                return;

            dateTimePickerTo.MinDate = dateTimePickerFrom.Value;

            dateFrom = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00"; // hh:mm:ss");

            UpdateDataSets();
            ReadContainers(dataSetSuppyInventoryByDate.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, false);

        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (flagInicio)
                return;

            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;

            dateTo = dateTimePickerTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"; // hh:mm:ss");
            UpdateDataSets();

            ReadContainers(dataSetSuppyInventoryByDate.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, false);

        }

        private void buttonAdjustment_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateSupplyAdjustment", true))
                return;

            if (!listViewUnstagedProducts.LabelEdit)
            {
                checkBoxShowZeros.Enabled = false;
                checkBoxShowZeros.Checked = true;
                listViewUnstagedProducts.LabelEdit = true;
                buttonAdjustment.Text = "&Save Adjustment";
                MessageBox.Show("Double Click on Quantity column to edit.\nThen click on Save Button to create the Adjustment.");
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to create this adjustment?", "", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
                return;

            checkBoxShowZeros.Enabled = true;

            listViewUnstagedProducts.LabelEdit = false;
            buttonAdjustment.Text = "&Create Adjustment";

            //create adjustment
            CreateAdjustemnt();

            UpdateDataSets();

            ReadContainers(dataSetSuppyInventoryByDate.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, false);

        }
        private void CreateAdjustemnt()
        {
            bool flagDone = false;

            //classes of tables
            sol_SupplyInventory = new Sol_SupplyInventory();
            if(sol_SupplyInventory_Sp == null)
                sol_SupplyInventory_Sp = new Sol_SupplyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //if (MessageBox.Show("Do you want to continue", "Closing Voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
            //    return;

            //int totalqty = 0;
            int nrows = listViewUnstagedProducts.Items.Count;

            sol_SupplyInventory.SupplyInventoryType = "A";      // O = Order, R = Received Order, A = Adjustment, S = Shipped

            string c;
            //computer name
            //c = Properties.Settings.Default.SettingsWsWorkStationName.Trim();
            //if (String.IsNullOrEmpty(c))
            //    c = Main.myHostName;
            //sol_SupplyInventory.ComputerName = c;  // 

            MembershipUser membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot create Adjustment!");
                return;
            }
            Guid userId = (Guid)membershipUser.ProviderUserKey;
            sol_SupplyInventory.UserID = userId;
            sol_SupplyInventory.Date = Main.rc.FechaActual; // ;// Properties.Settings.Default.FechaActual;
            sol_SupplyInventory.DateOrdered = DateTime.Parse("1753-1-1 12:00:00");
            sol_SupplyInventory_Sp.Insert(sol_SupplyInventory);

            for (int i = 0; i < nrows; i++)
            {

                //int quantity
                c = listViewUnstagedProducts.Items[i].SubItems[1].Text;
                c = c.Replace("(", "");
                c = c.Replace(")", "");
                c = c.Replace(",", "");

                int quantity = Convert.ToInt32(c);

                c = this.arrayListViewQuantity[i].ToString();

                int oldQuantity = (int)this.arrayListViewQuantity[i];
                if (oldQuantity == quantity)
                    continue;

                int adjustmenQuantity = quantity - oldQuantity;
                sol_SupplyInventory.Quantity = adjustmenQuantity;

                //totalqty = totalqty + (adjustmenQuantity);

                //int categoryID
                sol_SupplyInventory.ContainerID = (int)this.arrayListViewContainerId[i];


                //add row
                sol_SupplyInventory_Sp.Insert(sol_SupplyInventory);

                flagDone = true;

            }

            if (flagDone)
            {
                MessageBox.Show("Adjustment created.");
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

        private void buttonReceived_Click(object sender, EventArgs e)
        {
            SupplyInventoryReceive f1 = new SupplyInventoryReceive();
            f1.ShowDialog();
            bool confirmed = f1.confirmed;
            f1.Dispose();
            f1 = null;
            if (confirmed)
            {
                if (!checkBoxDates.Checked)
                    checkBoxDates.Checked = true;
                checkBoxDates.Checked = false;
                //UpdateDataSets();
                //ReadContainers(dataSetSuppyInventoryByDate.Tables[0], listViewUnstagedProducts, labelUnstagedTotalQuantity, false);

            }

        }

    }
}
