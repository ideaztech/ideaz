using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Solum
{
    public partial class ShippingMultiProductStagedContainersModify : Form
    {
        Sol_OrdersDetail_Sp sol_OrdersDetail_Sp;

        //Vir_BagPosition vir_BagPosition;
        Vir_BagPosition_Sp vir_BagPosition_Sp;

        //private Sol_Stage sol_Stage;
        //private Sol_Stage_Sp sol_Stage_Sp;

        bool isItemChecking = false;
        int currentOrderDetailID = 0;
        int currentMasterProductID = 0;

        public bool cancelFlag { get; private set; }
        public string buttonText { get; set; }
        public Color buttonBackColor { get; set; }
        public Vir_BagPosition vir_BagPosition { get; set; }
        public string tagNumber { get; set; }

        public ShippingMultiProductStagedContainersModify()
        {
            InitializeComponent();
            cancelFlag = true;
        }

        private void ShippingMultiProductStagedContainersModify_Load(object sender, EventArgs e)
        {
            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //listview with headers
            listView1.View = View.Details;
            listView1.Columns.Add("Product", 230, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantity", 140, HorizontalAlignment.Right);
            listView1.Columns.Add("OrderID", 150, HorizontalAlignment.Right);
            listView1.Columns.Add("MasterProductID", 150, HorizontalAlignment.Right);

            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.Activation = ItemActivation.OneClick;
            listView1.HideSelection = false;

            buttonBagPosition.Text = buttonText;
            buttonBagPosition.BackColor = buttonBackColor;

            FillDataListView();

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (currentOrderDetailID < 1)
            {
                MessageBox.Show("Please select an item from the list!");
                return;
            }

            if (MessageBox.Show("Are you sure want to remove this item from the bag?", "Modifying Bag Position Content", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            //update orderdetail
            if (sol_OrdersDetail_Sp == null)
                sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);

            Sol_OrdersDetail od = sol_OrdersDetail_Sp.Select(currentOrderDetailID);
            if (od == null
                //|| od.StageID > 0
                || od.Status != "A")
            {
                MessageBox.Show("Sorry, that item no longer exists.  Please select another item.");
                FillDataListView();
                return;
            }

            od.StageID = 0;
            sol_OrdersDetail_Sp.Update(od);

            //update bagposition
            if (vir_BagPosition_Sp == null)
                vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);

            vir_BagPosition.CurrentQuantity -= od.Quantity;
            vir_BagPosition_Sp.Update(vir_BagPosition);


            FillDataListView();

            //if (sol_Stage_Sp == null)
            //    sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

            FormatBagPositionText(buttonBagPosition, vir_BagPosition, tagNumber);

            currentOrderDetailID = 0;
            currentMasterProductID = 0;

            cancelFlag = false;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //cancelFlag = true;
            buttonText = buttonBagPosition.Text;

            Close();

        }
        private void FillDataListView()
        {
            listView1.Items.Clear();
            string[] str = new string[4];

            List<MultiProductOrderDetail> odList = new List<MultiProductOrderDetail>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                //string sql = @"
                //    SELECT   
                //    dbo.sol_Products.ProDescription
                //    , dbo.sol_OrdersDetail.Quantity
                //    , dbo.sol_OrdersDetail.DetailID
                //    , dbo.sol_Products.MasterProductID
                //    FROM dbo.sol_OrdersDetail 
                //    INNER JOIN dbo.sol_Products ON dbo.sol_OrdersDetail.ProductID = dbo.sol_Products.ProductID
                //    WHERE (dbo.sol_OrdersDetail.Status <> 'D') 
                //    AND (dbo.sol_OrdersDetail.StageID = @StageID)
                //    ORDER BY dbo.sol_OrdersDetail.OrderID
                //    ";

                using (SqlCommand command = new SqlCommand("sol_OrdersDetail_SelectAllByStageID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@StageID", vir_BagPosition.CurrentStageID));
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MultiProductOrderDetail od = new MultiProductOrderDetail();
                            od.DetailID = (int)reader["DetailID"];
                            od.ProductID = (int)reader["ProductID"];
                            od.ProductDescription = (string)reader["ProDescription"];
                            od.Weight = (decimal)reader["Weight"];
                            od.Volume = (decimal)reader["Volume"];
                            od.Quantity = (int)reader["Quantity"];
                            od.MasterProductID = (int)reader["MasterProductID"];
                            odList.Add(od);
                        }
                    }
                }
            }

            foreach (MultiProductOrderDetail od in odList)
            {
                str[0] = od.ProductDescription;
                str[1] = String.Format("{0,6:##,##0}", od.Quantity);
                str[2] = od.DetailID.ToString();
                str[3] = od.MasterProductID.ToString();
                ListViewItem itm = new ListViewItem(str);
                listView1.Items.Add(itm);
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isItemChecking)
                return;

            isItemChecking = true;

            if (e.NewValue == CheckState.Checked)
            {
                ListView lv = (ListView)sender;
                foreach (ListViewItem item in lv.Items)
                {
                    if (item.Index == e.Index)
                        continue;

                    item.Checked = false;
                }

                lv.Items[e.Index].Checked = true;
            }
            isItemChecking = false;

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                Int32.TryParse(e.Item.SubItems[2].Text, out currentOrderDetailID);
                Int32.TryParse(e.Item.SubItems[3].Text, out currentMasterProductID);
            }
            else
            {
                currentOrderDetailID = 0;
                currentMasterProductID = 0;
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = listView1.SelectedIndices;

            foreach (int index in indexes)
            {
                listView1.Items[index].Checked = !listView1.Items[index].Checked;
                if (listView1.Items[index].Checked)
                    listView1.Items[index].BackColor = Color.LightGray;    // SystemColors.ControlLight;
                else
                    listView1.Items[index].BackColor = SystemColors.Window;
                //break;
            }

        }

        void FormatBagPositionText(Button button, Vir_BagPosition bp, string tagNumber)
        {
            int l = 23;
            if (l > bp.BagPositionName.Length) l = bp.BagPositionName.Length;

            button.Text = string.Format(
                "{0}\r" +
                "{1:#,0}\r" +
                "Target: {2:#,0}\r" +
                "TAG {3}\r"
                , bp.BagPositionName.Substring(0, l)
                , bp.CurrentQuantity
                , bp.TargetQuantity
                , tagNumber
                );
        }

    }
}
