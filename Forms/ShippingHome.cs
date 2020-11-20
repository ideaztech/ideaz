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
    public partial class ShippingHome : Form
    {
        public static string RBillNumber = "";
        public static bool ShipmentButtonNew = false, ShipmentButtonView = false;

        public static string tagNumber = "";

        private Sol_Shipment sol_Shipment;
        private Sol_Shipment_Sp sol_Shipment_Sp;
        private List<Sol_Shipment> sol_ShipmentList;

        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;
        private List<Sol_Stage> sol_StageList;

        public static bool StagedContainerButtonNew = false, StagedContainerButtonView = false;

        public int ShippingForm = 0;    //1 - Home, 2 - StagedContainers, 6 - MultiProductStagedContainers, 3 - Shipments 4 - lookup, 5 - Adjustments
        public ShippingHome(string Texto, string User, string Server, string Today)
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

        private void ShippingHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void Shipping_Load(object sender, EventArgs e)
        {

            //classes of tables
            sol_Shipment = new Sol_Shipment();
            sol_Shipment_Sp = new Sol_Shipment_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_ShipmentList = new List<Sol_Shipment>();

            sol_Stage = new Sol_Stage();
            sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_StageList = new List<Sol_Stage>();

            toolStrip1.Renderer = new App_Code.NewToolStripRenderer();

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


            //listview with headers
            listViewCurrentStagedContainers.View = View.Details;
            //listViewCurrentStagedContainers.Columns.Add("Tag #", 190, HorizontalAlignment.Right);   //70
            //listViewCurrentStagedContainers.Columns.Add("Product", 165, HorizontalAlignment.Left);
            //listViewCurrentStagedContainers.Columns.Add("Dozen", 80, HorizontalAlignment.Left);
            //listViewCurrentStagedContainers.Columns.Add("Container", 170, HorizontalAlignment.Left);

            listViewCurrentStagedContainers.Columns.Add("Tag #", 190, HorizontalAlignment.Left);   //70
            listViewCurrentStagedContainers.Columns.Add("Product", 165, HorizontalAlignment.Left);
            listViewCurrentStagedContainers.Columns.Add("Quantity", 80, HorizontalAlignment.Right);
            listViewCurrentStagedContainers.Columns.Add("Container", 170, HorizontalAlignment.Left);
            listViewCurrentStagedContainers.Columns.Add("Dozen", 80, HorizontalAlignment.Right);

            listViewCurrentStagedContainers.FullRowSelect = true;
            //listViewCurrentStagedContainers.CheckBoxes = true;
            listViewCurrentStagedContainers.GridLines = true;
            //listView1.Activation = ItemActivation.OneClick;

            //manual sorting of items by columns
            listViewCurrentStagedContainers.Sorting = System.Windows.Forms.SortOrder.Ascending;

            // Make owner-drawn to be able to give different alignments to single subitems 
            //listViewCurrentStagedContainers.OwnerDraw = true;
            //listViewCurrentStagedContainers.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            //listViewCurrentStagedContainers.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);

            //listViewCurrentStagedContainers.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView2_DrawSubItem);



            //listview with headers
            listViewCurrentShipment.View = View.Details;
            //listViewCurrentShipment.Columns.Add("ShipmentID", 100, HorizontalAlignment.Left);
            listViewCurrentShipment.Columns.Add("BOL #", 160, HorizontalAlignment.Left);
            listViewCurrentShipment.Columns.Add("Agency", 300, HorizontalAlignment.Left);

            listViewCurrentShipment.FullRowSelect = true;
            //listViewCurrentShipment.CheckBoxes = true;
            listViewCurrentShipment.GridLines = true;


            //listview with headers
            listViewContainersOnShipment.View = View.Details;
            //listViewContainersOnShipment.Columns.Add("Tag #", 190, HorizontalAlignment.Right);
            //listViewContainersOnShipment.Columns.Add("Product", 165, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Dozen", 80, HorizontalAlignment.Left);
            //listViewContainersOnShipment.Columns.Add("Container", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Tag #", 190, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Product", 165, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Quantity", 80, HorizontalAlignment.Right);
            listViewContainersOnShipment.Columns.Add("Container", 170, HorizontalAlignment.Left);
            listViewContainersOnShipment.Columns.Add("Dozen", 80, HorizontalAlignment.Right);

            //listViewContainersOnShipment.FullRowSelect = true;
            //listViewContainersOnShipment.CheckBoxes = true;
            listViewContainersOnShipment.GridLines = true;


            //read outstandig orders (unpaid)
            ReadCurrentStagedContainers();

            //read shipments ready to be shippped
            ReadCurrentShipments();

            //training warning
            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                toolStripStatusLabelTrainingMode.Visible = true;
                Main.tslCntr = toolStripStatusLabelTrainingMode;
                Main.timerBlink.Enabled = true;
            }

            CheckUserPermissions();


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

            buttonVoidStagedContainer.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolVoidStaged", false);
            buttonNewStagedContainer.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
            buttonViewStagedContainer.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewContainer", false);

            buttonVoidShipment.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolVoidShipment", false);
            buttonNewShipment.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", false);
            buttonViewShipment.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", false);

        }

        private void toolStripButtonStagedContainers_Click(object sender, EventArgs e)
        {
            ShippingForm = 2;   //StagedContainers
            Close();

        }

        private void toolStripButtonMultiProductStaging_Click(object sender, EventArgs e)
        {
            ShippingForm = 6;   //MultiProductStagedContainers
            Close();

        }

        private void toolStripButtonShipments_Click(object sender, EventArgs e)
        {
            ShippingForm = 3;   //Shipments
            Close();

        }

        private void toolStripButtonShipmentAdjustments_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLookup_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", true))
                return;

            ShippingForm = 4;   //lookup
            Close();
        }

        private void buttonNewStagedContainer_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", true))
                return;

            ShippingForm = 2;   //StagedContainers
            StagedContainerButtonNew = true;
            Close();

        }

        private void buttonViewStagedContainer_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewContainer", true))
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
                tagNumber = item.SubItems[0].Text;
            }

            ShippingForm = 2;   //StagedContainers
            StagedContainerButtonView = true;
            Close();

        }

        private void buttonVoidStagedContainer_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolModifyContainer", true))
                return;

            ListView.SelectedListViewItemCollection selectedItems = listViewCurrentStagedContainers.SelectedItems;
            if (selectedItems.Count < 1)
            {
                MessageBox.Show("Please select a Staged Container");
                return;
            }


            ////ListViewItem itm;   // = new ListViewItem();
            //foreach (ListViewItem item in selectedItems)
            //{
            //    tagNumber = item.SubItems[0].Text;
            //}

            //ShippingForm = 2;   //StagedContainers
            //StagedContainerButtonView = true;
            //Close();


            bool firstTime = true;
            //int stageId = 0;
            string tagNumber = "";

            //selected items
            foreach (ListViewItem item in selectedItems)
            {
                try
                {
                    //stageId = Int32.Parse(item.SubItems[0].Text);
                    tagNumber = item.SubItems[0].Text;
                }
                catch
                {
                    continue;
                }

                if (firstTime)
                {
                    firstTime = false;
                    if (MessageBox.Show("Are you sure you want to delete Staged Container:" + item.SubItems[0].Text + "?", "Delete Staged Container", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }


                //read order
                //sol_Stage = sol_Stage_Sp.Select(stageId);
                sol_Stage = sol_Stage_Sp._SelectByTagNumberStatus(tagNumber, "I");  // .Select(stageId);
                //not found?
                if (sol_Stage == null)
                    continue;

                ////marked as deleted
                //sol_Stage.Status = "D";
                //sol_Stage_Sp.Update(sol_Stage);

                sol_Stage_Sp.Delete(sol_Stage.StageID);


                //sol_OrdersDetail_Sp._DeleteAllByOrderID_OrderType(

            }

            //refresh list or remove item above???
            ReadCurrentStagedContainers();


        }


        private void buttonNewShipment_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateShipment", true))
                return;
            
            ShippingForm = 3;   //Shipment
            ShipmentButtonNew = true;
            Close();

        }

        private void buttonViewShipment_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewShipment", true))
                return;

            ListView.SelectedListViewItemCollection selectedItems = listViewCurrentShipment.SelectedItems;
            if (selectedItems.Count < 1)
            {
                MessageBox.Show("Please select a Shipment to view");
                return;
            }


            //ListViewItem itm;   // = new ListViewItem();
            foreach (ListViewItem item in selectedItems)
            {
                RBillNumber = item.SubItems[0].Text;
            }

            ShippingForm = 3;   //Shipments
            ShipmentButtonView = true;
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

        private void ReadCurrentStagedContainers()
        {
            listViewCurrentStagedContainers.Items.Clear();

            sol_StageList = sol_Stage_Sp._SelectAllByStatus("I");  //all InProgress StagedContainers
            if (sol_StageList == null)
                return;

            foreach (Sol_Stage st in sol_StageList)
            {

                addItemStagedContainers(ref listViewCurrentStagedContainers, st.TagNumber, st.ProductName, st.Quantity, st.ContainerDescription, st.Dozen);
            }
            labelStageContainersCount.Text = String.Format("Count:"+Funciones.Indent(2)+"{0,10:##,###,##0}", listViewCurrentStagedContainers.Items.Count);

        }

        private bool addItemStagedContainers(ref ListView lv1, string tagNumber, string product, int quantity, string container, int dozen)
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

        //read shipments ready to be shippped
        private void ReadCurrentShipments()
        {
            listViewCurrentShipment.Items.Clear();

            sol_ShipmentList = sol_Shipment_Sp.SelectAllByStatus("I", true);  //all InProgress StagedContainers
            if (sol_ShipmentList == null)
                return;

            foreach (Sol_Shipment ss in sol_ShipmentList)
            {

                addItemShipment(ss.RBillNumber, ss.AgencyName);
            }
            labelCurrentShipmentsCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewCurrentShipment.Items.Count);

        }

        private bool addItemShipment(string rbill, string agency)
        {
            string[] str = new string[3];
            ListViewItem itm = new ListViewItem();
            str[0] = rbill;
            str[1] = agency;
            itm = new ListViewItem(str);
            listViewCurrentShipment.Items.Add(itm);

            return true;
        }

        private void listViewCurrentShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = this.listViewCurrentShipment.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                //read containers on shipment
                ReadContainersOnShipment(ref listViewContainersOnShipment, item.SubItems[0].Text);

            }
        }

        private void ReadContainersOnShipment(ref ListView lv1, string rBillNumber)
        {
            sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(rBillNumber);
            lv1.Items.Clear();
            sol_StageList = sol_Stage_Sp ._SelectAllByShipmentID(sol_Shipment.ShipmentID);  //I-InProgress; P-Picked S-Shipped
            if (sol_StageList == null)
                return;

            foreach (Sol_Stage st in sol_StageList)
            {
                addItemStagedContainers(ref lv1, st.TagNumber, st.ProductName, st.Quantity, st.ContainerDescription, st.Dozen);
            }

            labelContainersOnShipMentCount.Text = String.Format("Count:" + Funciones.Indent(2) + "{0,10:##,###,##0}", listViewContainersOnShipment.Items.Count);

        }

        private void toolStripButtonLogOff_Click(object sender, EventArgs e)
        {
            SolFunctions.LogOff(ref toolStripStatusLabelUserName);

            CheckComputerRole(ref toolStripButtonExit);

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

        //manual sorting of items by columns
        private void listViewCurrentStagedContainers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SirLib.ListViewItemComparer.ColumnClick((ListView)sender, e);
        }

        // Handle DrawSubItem event 
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // This is the default text alignment 
            TextFormatFlags flags = 
                //TextFormatFlags.Left | 
                //TextFormatFlags.NoPadding |
                TextFormatFlags.Default;


            // Align text on first column 
            //if (e.ColumnIndex == 1) // && e.Item.Index > 11) 
            //{
            //    flags = TextFormatFlags.Right;
            //}

            e.DrawText(flags);
        }

        // Handle DrawColumnHeader event 
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Draw the column header normally 
            e.DrawDefault = true;
            e.DrawBackground();
            e.DrawText();
        }


        // Draws subitem text and applies content-based formatting.
        private void listView2_DrawSubItem(object sender,
            DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left
                 | TextFormatFlags.NoPadding
                 | TextFormatFlags.Default
                 ;

            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the text and background for a subitem with a 
                // negative value. 
                //double subItemValue;
                if (e.ColumnIndex == 0
                    //> 0 && Double.TryParse(
                    //e.SubItem.Text, NumberStyles.Currency,
                    //NumberFormatInfo.CurrentInfo, out subItemValue) &&
                    //subItemValue < 0
                    )
                {
                    // Unless the item is selected, draw the standard 
                    // background to make it stand out from the gradient.
                    if ((e.ItemState & ListViewItemStates.Selected) == 0)
                    {
                        e.DrawBackground();
                    }

                    // Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text,
                        listViewCurrentStagedContainers.Font, Brushes.Red, e.Bounds, sf);

                    return;
                }

                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                e.DrawText(flags);
            }
        }


        public static void CheckComputerRole(
            ref ToolStripButton toolStripButtonExit
            )
        {
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
                    //case 1:     //Returns/Sales
                    //    break;
                    //case 2:     //Cashier
                    //    break;
                    case 3:     //Shipping
                        break;
                    default:    //anything else
                        toolStripButtonExit.PerformClick();
                        break;

                }

            }
        }


        private void buttonVoidShipment_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolModifyContainer", true))
                return;

            ListView.SelectedListViewItemCollection selectedItems = listViewCurrentShipment.SelectedItems;
            if (selectedItems.Count < 1)
            {
                MessageBox.Show("Please select a Shipment");
                return;
            }


            bool firstTime = true;
            //int stageId = 0;
            string shipNumber = "";

            //selected items
            foreach (ListViewItem item in selectedItems)
            {
                try
                {
                    //stageId = Int32.Parse(item.SubItems[0].Text);
                    shipNumber = item.SubItems[0].Text;
                }
                catch
                {
                    continue;
                }

                if (firstTime)
                {
                    firstTime = false;
                    if (MessageBox.Show("Are you sure you want to delete shipment:" + item.SubItems[0].Text + "?", "Delete Shipment", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                sol_Shipment = sol_Shipment_Sp.SelectByRBillNumber(shipNumber);
                sol_StageList = sol_Stage_Sp._SelectAllByShipmentID(sol_Shipment.ShipmentID);  //I-InProgress; P-Picked S-Shipped
                if (sol_StageList.Count > 0)
                {
                    MessageBox.Show("Shipment is not empty, cannot void it!");
                    return;
                }

                //delete it
                sol_Shipment_Sp.Delete(sol_Shipment.ShipmentID);

            }

            //refresh list or remove item above???
            ReadCurrentShipments();

        }

        private void toolStripButtonShipmentAdjustments_Click_1(object sender, EventArgs e)
        {
            ShippingForm = 5;   //Adjustments
            Close();

        }
        private void ButtonEnabledChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = button.Enabled;
        }


    }
}
