using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solum
{
    public partial class ShippingShipmentsWarehouseMode : Form
    {
        public ShippingShipmentsWarehouseMode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShippingShipments.blnWarewhouseMode = false;
            Close();
        }
    }
}
