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
    public partial class eRBill_CheckList_ListView : Form
    {
        public static System.Windows.Forms.ListView listView2;
        public static System.Windows.Forms.ListView listView1;


        public eRBill_CheckList_ListView()
        {
            InitializeComponent();

            listView2 = new System.Windows.Forms.ListView();
            listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();

            // 
            // listView2
            // 
            listView2.Location = new System.Drawing.Point(11, 254);
            listView2.Name = "listView2";
            listView2.Size = new System.Drawing.Size(503, 186);
            listView2.TabIndex = 6;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(11, 33);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(503, 193);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;

            this.Controls.Add(listView2);
            this.Controls.Add(listView1);
            this.ResumeLayout(false);
            //this.PerformLayout();
        }

        private void eRBill_CheckList_ListView_Load(object sender, EventArgs e)
        {
            //listview1 with headers
            listView1.View = View.Details;
            listView1.Columns.Add("BagTag", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("ItemTypeCrisID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("ShippingContainerTypeCrisID", 180, HorizontalAlignment.Left);
            listView1.Columns.Add("UnitsShipped", 110, HorizontalAlignment.Left);
            listView1.GridLines = true;

            //listview2 with headers
            listView2.View = View.Details;
            listView2.Columns.Add("BagTag", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("ItemTypeCrisID", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("ShippingContainerTypeCrisID", 180, HorizontalAlignment.Left);
            listView2.Columns.Add("ContainersShipped", 110, HorizontalAlignment.Left);
            listView2.GridLines = true;


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
