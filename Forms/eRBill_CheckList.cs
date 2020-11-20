using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;
using Solum.WsHttpsAbcrcServiceReference;
using System.Threading;

namespace Solum
{
    public partial class eRBill_CheckList : Form
    {
        #region Fields

        eRBill_CheckList_ListView f1;

        private Sol_Shipment sol_Shipment;
        private Sol_Shipment_Sp sol_Shipment_Sp;

        private int eResult;


        #endregion

        #region Properties
        public virtual int EResult
        {
            get { return eResult; }
            set { eResult = value; }
        }

        /// <summary>
        /// Gets or sets the Sol_Shipment value.
        /// </summary>
        public virtual Sol_Shipment Sol_Shipment
        {
            get { return sol_Shipment; }
            set { sol_Shipment = value; }
        }

        /// <summary>
        /// Gets or sets the Sol_Shipment value.
        /// </summary>
        public virtual Sol_Shipment_Sp Sol_Shipment_Sp
        {
            get { return sol_Shipment_Sp; }
            set { sol_Shipment_Sp = value; }
        }

        #endregion

        private void MyThreadRoutine()
        {
            //this.Invoke(this.ShowProgressGifDelegate);
            //your long running process
            System.Threading.Thread.Sleep(3000);
            if (!Test_validate(sol_Shipment, sol_Shipment_Sp))
                eResult = -1;


            ////this.Invoke(this.HideProgressGifDelegate);
            //pictureBox1.Visible = false;
            //Cancel.Enabled = true;
            if (checkBoxViewERBill.Checked)
            {
                f1.TopMost = true;
                f1.ShowDialog();
                f1.Dispose();
                f1 = null;

            }
            this.Close();
        }


        public eRBill_CheckList()
        {
            InitializeComponent();
        }

        private void eRBill_CheckList_Load(object sender, EventArgs e)
        {
            //661, 683

            // TODO: This line of code loads data into the 'dataSetPlantsLookup.Sol_WS_Plants' table. You can move, or remove it, as needed.
            this.sol_WS_PlantsTableAdapter.Fill(this.dataSetPlantsLookup.Sol_WS_Plants);
            // TODO: This line of code loads data into the 'dataSetCarriersLookup.Sol_WS_Carriers' table. You can move, or remove it, as needed.
            this.sol_WS_CarriersTableAdapter.Fill(this.dataSetCarriersLookup.Sol_WS_Carriers);



            textBoxRBillNumber.Text = sol_Shipment.RBillNumber;


            if (sol_Shipment.CarrierID < 1)
            {

                try
                {
                    comboBoxCarrier.SelectedValue = Main.Sol_ControlInfo.DefaultCarrierID;
                }
                catch
                {
                    comboBoxCarrier.SelectedValue = 0;
                }
            }
            else
                comboBoxCarrier.SelectedValue = sol_Shipment.CarrierID;

            if (sol_Shipment.PlantID < 1)
            {

                try
                {
                    comboBoxPlant.SelectedValue = Main.Sol_ControlInfo.DefaultPlantID;
                }
                catch
                {
                    comboBoxPlant.SelectedValue = 0;
                }
            }
            else
                comboBoxPlant.SelectedValue = sol_Shipment.PlantID;

            textBoxTrailerNumber.Text = sol_Shipment.TrailerNumber;
            textBoxProBillNumber.Text = sol_Shipment.ProBillNumber;

            if (sol_Shipment.ShippedDate.Year == 1753)
                dateTimePickerShippedDate.Value = DateTime.Now;
            else
                dateTimePickerShippedDate.Value = sol_Shipment.ShippedDate;

            dateTimePickerShippedDate.MinDate = sol_Shipment.Date;
            dateTimePickerShippedDate.MaxDate = DateTime.Now; 


            textBoxSealNumber.Text = sol_Shipment.SealNumber;
            textBoxLoadReference.Text = sol_Shipment.LoadReference;


            //default result
            eResult = -1;

        }

        private void OK_Click(object sender, EventArgs e)
        {
            eResult = 0;
            UpdateERbill();

            Close();

        }

        private void buttonTransmit_Click(object sender, EventArgs e)
        {
            //if (sol_Shipment.ERBillTransmitted)    //KEV - this was commented out to allow an RBill to be transmitted again
            //{
            //    MessageBox.Show("Shipment already transmitted!");
            //    return;
            //}  

            buttonTransmit.Enabled = false;
            OK.Enabled = false;
            Cancel.Enabled = false;
            pictureBox1.Enabled = true;
            pictureBox1.Show();
            pictureBox1.Update();
            eResult = 1;
            UpdateERbill();

            if (Properties.Settings.Default.SQLBaseDeDatos == "Solum_Training")
            {
                MessageBox.Show("In Training mode, the eRBill is not actually transmitted, the shipment is just marked as transmitted.");
                Close();
                return;
            }

            ThreadStart myThreadStart = new ThreadStart(MyThreadRoutine);
            Thread myThread = new Thread(myThreadStart);
            myThread.Start();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateERbill()
        {
            //store data
            sol_Shipment.CarrierID = (int)comboBoxCarrier.SelectedValue;
            sol_Shipment.PlantID = (int)comboBoxPlant.SelectedValue;
            sol_Shipment.TrailerNumber = textBoxTrailerNumber.Text;
            sol_Shipment.ProBillNumber = textBoxProBillNumber.Text;
            sol_Shipment.ShippedDate = (DateTime)dateTimePickerShippedDate.Value;
            sol_Shipment.SealNumber = textBoxSealNumber.Text;
            sol_Shipment.LoadReference = textBoxLoadReference.Text;
            sol_Shipment.ERBillTransmitted = false;
            sol_Shipment_Sp.UpdateERBill(sol_Shipment);

        }

        //SOAP v1.2, and binding is wsHttpBindin
        private bool Test_validate(Sol_Shipment sol_Shipment, Sol_Shipment_Sp sol_Shipment_Sp)
        {
            if (String.IsNullOrEmpty(Main.Sol_ControlInfo.ABCRCUserName))
            {
                MessageBox.Show("Please go to Settings -> ABCRC and add User Name and Password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (checkBoxViewERBill.Checked)
            {
                f1 = new eRBill_CheckList_ListView();
            }

            //https://abcrcerbill.com/WcfAbcrcService/ //former: https://abcrcerbill.com/WsHttpsAbcrcService.svc


            WsHttpsAbcrcServiceClient client = new WsHttpsAbcrcServiceClient(); //"configName", "https://abcrcerbill.com/WsHttpsAbcrcService.svc");
            client.ClientCredentials.UserName.UserName = Main.Sol_ControlInfo.ABCRCUserName;
            client.ClientCredentials.UserName.Password = Main.Sol_ControlInfo.ABCRCPassword;

            int intNumber = 0;
            string strValue = String.Empty;
            string vendorId = String.Empty;
            string tagNumber = String.Empty;
            string productCode = String.Empty;
            int iProductCode = 0;
            string quantity = String.Empty;

            try
            {
                AbcrcERBill eRBill = new AbcrcERBill();

                strValue = sol_Shipment.RBillNumber;
                vendorId = string.Format("{0:d4}", Main.Sol_ControlInfo.VendorID);
                //parse it
                if (sol_Shipment.RBillNumber.Length < 7)
                {
                    Int32.TryParse(sol_Shipment.RBillNumber, out intNumber);
                    strValue = vendorId + string.Format("{0:d6}", intNumber);
                }
                eRBill.RBillNumber = strValue;

                ////temporaly change for testing
                //vendorId = "0000";

                eRBill.CarrierCrisID = sol_Shipment.CarrierID;
                eRBill.PlantCrisID = sol_Shipment.PlantID;
                eRBill.TrailerNumber = sol_Shipment.TrailerNumber;
                eRBill.ProBillNumber = sol_Shipment.ProBillNumber;
                eRBill.ShippedDate = sol_Shipment.ShippedDate;
                eRBill.SealNumber = sol_Shipment.SealNumber;
                eRBill.LoadReference = sol_Shipment.LoadReference;

                //add used and empty bags
                AbcrcERBillBag bag;                 
                int nBags = 0, nMaxBags = 0;

                AbcrcOtherShippingContainer aosc;   
                int nAosc = 0, nMaxAosc = 0;

                //open product table
                Sol_Product_Sp sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
                Sol_Product sol_Product;
                
                //open Container table
                Sol_Container_Sp sol_Container_Sp = new Sol_Container_Sp(Properties.Settings.Default.WsirDbConnectionString);
                Sol_Container sol_Container;

                //read containers in shipment and get number of bags
                Sol_Stage_Sp sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
                List<Sol_Stage> sol_StageList = sol_Stage_Sp._SelectAllByShipmentID(sol_Shipment.ShipmentID);
                if (sol_StageList.Count < 1)
                {
                    MessageBox.Show("", "No containers found in shipment, cannot continue!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
                nMaxBags = sol_StageList.Count;

                //read eRBill empty containers and get number of bags
                Sol_SupplyInventory_Sp sol_SupplyInventory_Sp = new Sol_SupplyInventory_Sp(Properties.Settings.Default.WsirDbConnectionString);
                List<Sol_SupplyInventory> sol_SupplyInventoryList = sol_SupplyInventory_Sp._SelectAllByShipmentID(sol_Shipment.ShipmentID);
                foreach (Sol_SupplyInventory ssi in sol_SupplyInventoryList)
                {
                    if (ssi.ProductID < 1)
                    {
                        //Empty Bags - EmptyContainer
                        nMaxAosc++;
                    }
                }

                //set max bags
                if (nMaxBags > 0)
                    eRBill.Bags = new AbcrcERBillBag[nMaxBags];
                if (nMaxAosc > 0)
                    eRBill.AdditionalShippingContainers = new AbcrcOtherShippingContainer[nMaxAosc];


                //process shipment containers
                foreach (Sol_Stage ssi in sol_StageList)
                {

                    //get ShippingContainerID for ItemTypeCrisID 
                    sol_Container = sol_Container_Sp.Select(ssi.ContainerID);

                   //begin loop

                        //get productCode for ShippingContainerTypeCrisID 
                        sol_Product = sol_Product_Sp.Select(ssi.ProductID);
                        Int32.TryParse(sol_Product.ProductCode, out iProductCode);
                        productCode = string.Format("{0:d4}", iProductCode);

                        bag = new AbcrcERBillBag();
                        quantity = string.Format("{0:d5}", ssi.Quantity);

                        if (ssi.TagNumber.Length < 8)
                        {
                            Int32.TryParse(ssi.TagNumber, out intNumber);
                            tagNumber = string.Format("{0:d7}", intNumber);
                            strValue = vendorId + productCode + quantity + tagNumber;
                        }
                        else if (ssi.TagNumber.Length == 20)
                        {
                            strValue = ssi.TagNumber;
                        }
                        else
                        {
                            string m = String.Format("Tag Number {0} has the wrong number of digits.  eR-Bill can't be processed.  Please correct the Tag Number and submit the eR-Bill again.", ssi.TagNumber);
                            MessageBox.Show("", m, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        bag.BagTag = strValue;                      //sol_Stage.TagNumber
                        bag.ItemTypeCrisID = iProductCode;
                        bag.ShippingContainerTypeCrisID = sol_Container.ShippingContainerTypeID;
                        bag.UnitsShipped = ssi.Quantity; //ssi.Dozen * 12;     //KEV - this was fixed in 5.0.4.  Dozens are not used.

                    if (checkBoxViewERBill.Checked)
                            addItem(bag.BagTag, bag.ItemTypeCrisID, bag.ShippingContainerTypeCrisID, bag.UnitsShipped, ref eRBill_CheckList_ListView.listView1);


                        eRBill.Bags[nBags++] = bag;
                        //end loop

                }

                //process empty containers
                foreach (Sol_SupplyInventory ssi in sol_SupplyInventoryList)
                {
                    //bag tag ?
                    //Item Type ID
                    //Shipping Container Type ID
                    //Units Shipped

                    //get ShippingContainerID for ItemTypeCrisID 
                    sol_Container = sol_Container_Sp.Select(ssi.ContainerID);

                    //}
                    if (ssi.ProductID < 1)
                    {
                        //Empty Bags - EmptyContainer
                        //empty bags
                        aosc = new AbcrcOtherShippingContainer();
                        //eRBill.AdditionalShippingContainers = new AbcrcOtherShippingContainer[1];
                        aosc.ShippingContainerTypeCrisID = sol_Container.ShippingContainerTypeID;
                        aosc.ContainersShipped = ssi.Quantity;

                        if (checkBoxViewERBill.Checked)
                            addItem("", 0, aosc.ShippingContainerTypeCrisID, aosc.ContainersShipped, ref eRBill_CheckList_ListView.listView2);

                        eRBill.AdditionalShippingContainers[nAosc++] = aosc;
                    }

                }

                AbcrcValidationResponse response = client.ValidateErBill(eRBill);
                string c = String.Empty;

                foreach (AbcrcValidationMessage m in response.ValidationMessages)
                    c = c + "\r\n" + m.ValidationMessage;

                c = c + "\r\n" + response.ErrorMessage;
                if (response.Error == false && response.IsValid == true)
                {
                    //MessageBox.Show("Validation passed successful!");

                    c = String.Empty;
                    //submit
                    AbcrcSubmitResponse submitResponse = client.SubmitErBill(eRBill);
                    foreach (AbcrcValidationMessage m in submitResponse.ValidationMessages)
                        c = c + "\r\n" + m.ValidationMessage;

                    c = c + "\r\n" + submitResponse.ErrorMessage;
                    if (!(submitResponse.Error == false && submitResponse.IsValid == true))
                    {
                        //CajaDeMensaje.Show("", "Validation not passed successful, debug it!", c, CajaDeMensajeImagen.Error);
                        MessageBox.Show(c, "Even thought the erBill validation was succesfull, it was not received by the agency!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                   

                }
                else
                {
                    //CajaDeMensaje.Show("", "Validation not passed successful, debug it!", c, CajaDeMensajeImagen.Error);
                    MessageBox.Show(c, "Validation not passed successful, debug it!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
                //CajaDeMensaje.Show("", exception.Message, exception.InnerException.Message, CajaDeMensajeImagen.Error);
                string m1 = String.Empty;
                try
                {
                    m1 = exception.InnerException.Message;
                }
                catch 
                {
                    m1 = "Error when trying to create and validate eRBill's object. ";
                }

                //string m2 = exception.Message;

                MessageBox.Show(exception.Message, m1, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }

            return true;

        }


        private void addItem(
            string BagTag, 
            int ItemTypeCrisID, 
            int ShippingContainerTypeCrisID, 
            int quantity,
            ref ListView listView
            )
        {
            string[] str = new string[4];
            ListViewItem itm;   // = new ListViewItem();
            //formatting numbers
            str[0] = BagTag;
            if (ItemTypeCrisID == 0)
                str[1] = String.Empty;
            else
                str[1] = String.Format("{0,8:###0}", ItemTypeCrisID);
            str[2] = String.Format("{0,8:###0}", ShippingContainerTypeCrisID);
            str[3] = String.Format("{0,3}", quantity);
            itm = new ListViewItem(str);
            listView.Items.Add(itm);

            //scroll to last item automatically
            listView.EnsureVisible(listView.Items.Count - 1);
            listView.Update();

        }



    }
}
