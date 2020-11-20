using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;
using System.Web.Security;

namespace Solum
{
    public partial class ShippingShipmentsInventory : Form
    {
        int shipmentId;
        Sol_Container sol_Container;
        Sol_Container_Sp sol_Container_Sp;

        int[] sbolContainersID; 
        string[] sbolContainersName;

        Sol_Product sol_Product;
        Sol_Product_Sp sol_Product_Sp;

        public bool confirmed;

        public DataSetBoL dsBol;
        public DataSetBol2 dsBol2;

        public ShippingShipmentsInventory(int shipmentID)
        {
            InitializeComponent();
            shipmentId = shipmentID;
        }

        private void ShippingShipmentsInventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetContainersLookup.sol_Containers' table. You can move, or remove it, as needed.
            this.sol_ContainersTableAdapter.FillByType(this.dataSetContainersLookup.sol_Containers, 1);   //1 = Shipping Containers
            confirmed = false;

            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //read sbol containers
            sol_Container_Sp = new Sol_Container_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sbolContainersID = new int[4];
            sbolContainersName = new string[4];

            if (Main.Sol_ControlInfo.WhiteBagID < 1
                || Main.Sol_ControlInfo.BlueBagID < 1
                || Main.Sol_ControlInfo.OneWayBagID < 1
                || Main.Sol_ControlInfo.ABCRCPalletsID < 1
                )
            {
                MessageBox.Show("You have to define ALL containers for Straight BOL, cannot continue.\r\n Please go to Tools -> Settings -> ABCRC to do that.");
                Close();
                return;
            }

            if (!ReadSBolContainers(Main.Sol_ControlInfo.WhiteBagID, 0)
                || !ReadSBolContainers(Main.Sol_ControlInfo.BlueBagID, 1)
                || !ReadSBolContainers(Main.Sol_ControlInfo.OneWayBagID, 2)
                || !ReadSBolContainers(Main.Sol_ControlInfo.ABCRCPalletsID, 3)

                )
            {
                Close();
                return;
            }

            AddRows2();
        }

        private bool ReadSBolContainers(int containerID, int index)
        {

            sol_Container = sol_Container_Sp.Select(containerID);
            if (sol_Container == null)
            {
                MessageBox.Show("ContainerID for Column1 for Straight BOL does not exist, cannot continue.\r\n Please go to Tools -> Settings -> ABCRC to fix this.");
                return false;

            }
            sbolContainersID[index] = containerID;
            sbolContainersName[index] = sol_Container.Description;


            return true;
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

        private void AddRows()
        {
            DataRow drBol = dsBol.Tables["BOL"].Rows[0];

            //to skip header info and first dozen
            int colIndex = 8;
            foreach (string cc in Main.crisCodes)
            {
                foreach (int cID in sbolContainersID)
                {
                    int quantity = (int)dsBol.Tables[0].Rows[0][colIndex];
                    if(quantity>0)
                        AddRow(cc, cID, quantity, false, colIndex, true);
                    colIndex++;
                }

                //to skip dozens
                colIndex++;
            }

            //add extra container (pallets)
            ////AddRow("", Main.Sol_ControlInfo.SBolExtraContainerID, 0, false, 0);
            //foreach (int cID in sbolContainersID)
            //    AddRow("Pallets", cID, 0, false, 0);
            AddRow("Pallets", sbolContainersID[3], 0, false, 0, false);    //only col4 = ABCRCPallets
            //add empty containers
            for (int i = 0; i<3; i++)   // cID in sbolContainersID)
                AddRow("EmptyBags", sbolContainersID[i], 0, true, 0, false);


        }

        private void AddRow(string productCode, int containerID, int quantity, bool empty, int dataSetCol, bool quantityLocked)
        {
            //if (String.IsNullOrEmpty(productCode))
            //    return;

            //if (String.IsNullOrEmpty(categoryName))
            //    return;

            //if (quantity == 0)
            //    return;


            sol_Product = new Sol_Product();
            if (productCode == "Pallets")
            {
                sol_Product.ProductID = -1;
                sol_Product.ProName = productCode;
            }
            else if (productCode == "EmptyBags")
            {
                sol_Product.ProductID = 0;
                sol_Product.ProName = productCode;
            }
            //if (String.IsNullOrEmpty(productCode))
            //{
                //if(empty)
                //    sol_Product.ProName = "Empty";   //Undefined";
                //else
                //    sol_Product.ProName = "";   //Undefined";
            //}
            else
            {
                sol_Product = sol_Product_Sp.SelectProductCode(productCode);
                if (sol_Product == null)
                {
                    sol_Product = new Sol_Product();
                    sol_Product.ProName = "Undefined";
                }
            }

            this.dataGridViewShippingContainers.Rows.Add();
            int colIndex = 0;
            int rowIndex = this.dataGridViewShippingContainers.Rows.Count - 1;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = sol_Product.ProName;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = containerID;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = quantity;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].ReadOnly = quantityLocked;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = empty;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = sol_Product.ProductID;

        }


        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewShippingContainers.Rows.Count < 2)
                return;

            //this.dataGridViewShippingContainers.AllowUserToAddRows = true;
            try
            {
                this.dataGridViewShippingContainers.Rows.RemoveAt(this.dataGridViewShippingContainers.CurrentRow.Index);
            }
            catch { }

            this.dataGridViewShippingContainers.Select();

        }

        private void OK_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            foreach (DataGridViewRow row in dataGridViewShippingContainers.Rows)
            {
                if (row.IsNewRow) continue;
                Int32.TryParse(row.Cells[2].Value.ToString(), out quantity);
                if (quantity == 0) continue;
                if (String.IsNullOrEmpty(row.Cells[1].FormattedValue.ToString()) )
                {
                    MessageBox.Show(String.Format("Please select a container in row {0}", row.Index+1));
                    return;
                }
            }
            
            AddRowsToTable();

            confirmed = true;
            Close();
        }

        private void dataGridViewShippingContainers_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            //if (e.ColumnIndex == 0)     // 
            //{
            //    e.Value = 0;
            //}

        }

        private void AddRowsToTable()
        {
            //Sol_SupplyInventory Sol_SupplyInventory = new Sol_SupplyInventory();
            Sol_SupplyInventory_Sp sol_SupplyInventory_Sp = new Sol_SupplyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);

            MembershipUser membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot add shipping containers entry");
                return ;
            }

            Guid userID = (Guid)membershipUser.ProviderUserKey;

            int quantity = 0;
            foreach (DataGridViewRow row in dataGridViewShippingContainers.Rows)
            {
                if (row.IsNewRow) continue;

                Int32.TryParse(row.Cells[2].Value.ToString(), out quantity);

                if (quantity == 0) continue;

                Sol_SupplyInventory sol_SupplyInventory = new Sol_SupplyInventory();
                ////SupplyInventoryTypes
                //"0", "Order"
                //"R", "Received Order"
                //"A", "Adjustment"
                //"S", "Shipped"
                sol_SupplyInventory.SupplyInventoryType = "S";
                sol_SupplyInventory.UserID = userID;
                sol_SupplyInventory.Date = Main.rc.FechaActual;
                sol_SupplyInventory.DateOrdered = DateTime.Parse("1753-1-1 12:00:00");
                sol_SupplyInventory.ProductID = (int)row.Cells[4].Value;
                sol_SupplyInventory.ContainerID = (int)row.Cells[1].Value;
                sol_SupplyInventory.Quantity = quantity;
                sol_SupplyInventory.ShipmentID = shipmentId;
                sol_SupplyInventory.ReferenceNumber = String.Empty;

                sol_SupplyInventory_Sp.Insert(sol_SupplyInventory);



            }

            //dataGridViewShippingContainers.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

        }

        private void dataGridViewShippingContainers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //this is just to avoid unnecessary error warnings
            //e.Cancel = true;

        }



        private void AddRows2()
        {
            DataTable dt = dsBol2.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if(string.IsNullOrEmpty((string)dr["ProCode"]))
                    continue;

                //para leer la cantidad de contenedores (despues de dozens) WhiteBags, BluBags etc.
                int colIndex = 4;
                foreach (int cID in sbolContainersID)
                {
                    int quantity = (int)dr[colIndex];
                    if (quantity > 0)
                        AddRow2((string)dr["ProCode"], cID, quantity, false, true);
                    colIndex++;
                }

                //to skip dozens
                colIndex++;

            }

            //add extra container (pallets)
            ////AddRow("", Main.Sol_ControlInfo.SBolExtraContainerID, 0, false, 0);
            //foreach (int cID in sbolContainersID)
            //    AddRow("Pallets", cID, 0, false, 0);
            AddRow("Pallets", sbolContainersID[3], 0, false, 0, false);    //only col4 = ABCRCPallets
            //add empty containers
            for (int i = 0; i < 3; i++)   // cID in sbolContainersID)
                AddRow("EmptyBags", sbolContainersID[i], 0, true, 0, false);


        }

        private void AddRow2(string productCode, int containerID, int quantity, bool empty, bool quantityLocked)
        {
            //if (String.IsNullOrEmpty(productCode))
            //    return;

            //if (String.IsNullOrEmpty(categoryName))
            //    return;

            //if (quantity == 0)
            //    return;


            sol_Product = new Sol_Product();
            if (productCode == "Pallets")
            {
                sol_Product.ProductID = -1;
                sol_Product.ProName = productCode;
            }
            else if (productCode == "EmptyBags")
            {
                sol_Product.ProductID = 0;
                sol_Product.ProName = productCode;
            }
            //if (String.IsNullOrEmpty(productCode))
            //{
            //if(empty)
            //    sol_Product.ProName = "Empty";   //Undefined";
            //else
            //    sol_Product.ProName = "";   //Undefined";
            //}
            else
            {
                sol_Product = sol_Product_Sp.SelectProductCode(productCode);
                if (sol_Product == null)
                {
                    sol_Product = new Sol_Product();
                    sol_Product.ProName = "Undefined";
                }
            }

            this.dataGridViewShippingContainers.Rows.Add();
            int colIndex = 0;
            int rowIndex = this.dataGridViewShippingContainers.Rows.Count - 1;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = sol_Product.ProName;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = containerID;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = quantity;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].ReadOnly = quantityLocked;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = empty;
            colIndex++;
            this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = sol_Product.ProductID;

        }




    }
}
