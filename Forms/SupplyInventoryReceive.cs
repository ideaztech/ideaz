using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;

namespace Solum
{
    public partial class SupplyInventoryReceive : Form
    {
        public bool confirmed;

        //Sol_Container sol_Container;
        Sol_Container_Sp sol_Container_Sp;

        List<Sol_Container> sol_ContainerList;

        public SupplyInventoryReceive()
        {
            InitializeComponent();
            confirmed = false;

        }

        private void SupplyInventoryReceive_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            //read sbol containers
            sol_Container_Sp = new Sol_Container_Sp(Properties.Settings.Default.WsirDbConnectionString);
            readContainers();


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

        private void readContainers()
        {

            sol_ContainerList = sol_Container_Sp.SelectAll();
            foreach (Sol_Container sc in sol_ContainerList)
            {
                if (sc.ContainerID == 0) continue;
                this.dataGridViewShippingContainers.Rows.Add();
                int colIndex = 0;
                int rowIndex = this.dataGridViewShippingContainers.Rows.Count - 1;
                this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = sc.ContainerID;
                colIndex++;
                this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = sc.Description;
                colIndex++;
                this.dataGridViewShippingContainers.Rows[rowIndex].Cells[colIndex].Value = 0;

            }

        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewShippingContainers.Rows.Count < 1)
            {
                return;
            }

            //this.dataGridViewShippingContainers.AllowUserToAddRows = true;
            try
            {
                this.dataGridViewShippingContainers.Rows.RemoveAt(this.dataGridViewShippingContainers.CurrentRow.Index);
            }
            catch { }

            this.dataGridViewShippingContainers.Select();

            if (this.dataGridViewShippingContainers.Rows.Count < 1)
            {
                OK.Enabled = false;
                buttonDeleteRow.Enabled = false;
            }

        }

        private void OK_Click(object sender, EventArgs e)
        {
            AddRowsToTable();
            confirmed = true;
            Close();

        }

        private void AddRowsToTable()
        {
            Sol_SupplyInventory sol_SupplyInventory;
            Sol_SupplyInventory_Sp sol_SupplyInventory_Sp = new Sol_SupplyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);

            System.Web.Security.MembershipUser membershipUser = System.Web.Security.Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot add shipping containers entry");
                return;
            }

            Guid userID = (Guid)membershipUser.ProviderUserKey;

            int quantity = 0;
            foreach (DataGridViewRow row in dataGridViewShippingContainers.Rows)
            {
                if (row.IsNewRow) continue;

                Int32.TryParse(row.Cells[2].Value.ToString(), out quantity);

                if (quantity == 0) continue;

                sol_SupplyInventory = new Sol_SupplyInventory();
                ////SupplyInventoryTypes
                //"0", "Order"
                //"R", "Received Order"
                //"A", "Adjustment"
                //"S", "Shipped"
                sol_SupplyInventory.SupplyInventoryType = "R";
                sol_SupplyInventory.UserID = userID;
                sol_SupplyInventory.Date = Main.rc.FechaActual;
                sol_SupplyInventory.DateOrdered = DateTime.Parse("1753-1-1 12:00:00");
                //sol_SupplyInventory.ProductID = (int)row.Cells[4].Value;
                sol_SupplyInventory.ContainerID = (int)row.Cells[0].Value;
                sol_SupplyInventory.Quantity = quantity;
                //sol_SupplyInventory.ShipmentID = shipmentId;
                sol_SupplyInventory.ReferenceNumber = textBoxReference.Text;

                sol_SupplyInventory_Sp.Insert(sol_SupplyInventory);



            }

            //dataGridViewShippingContainers.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

        }


    }
}
