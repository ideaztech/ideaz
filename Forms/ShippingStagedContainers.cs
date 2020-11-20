
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

//using System.Runtime.InteropServices;

namespace Solum
{
    public partial class ShippingStagedContainers : Form
    {
        //Sol_AutoNumber sol_AutoNumber;
        Sol_AutoNumber_Sp sol_AutoNumber_Sp;

        MembershipUser membershipUser;
        //private SirLib.ObtenerSiguienteId osi;

        Sol_Agencie sol_Agency;
        Sol_Agencie_Sp sol_Agency_Sp;
        Sol_Product sol_Product;
        Sol_Product_Sp sol_Product_Sp;

        private NumericTextBox textBoxTagNumber;

        private bool flagChange = false;

        private IButtonControl originalAcceptButton;
        private Control controlWithFocus;    //control with focus

        //// Import GetFocus() from user32.dll
        //[DllImport("user32.dll", CharSet = CharSet.Auto,
        //   CallingConvention = CallingConvention.Winapi)]
        //internal static extern IntPtr GetFocus(); 

        private string buttonClicked = "";

        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;

        public int ShippingForm = 0;    //1 - Home, 2 - StagedContainers, 3 - Shipments 4 - lookup, 5 - Adjustments

        public ShippingStagedContainers(string Texto, string User, string Server, string Today)
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

        private void ShippingStagedContainers_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Warn Lost data upon exit
            if (flagChange)
            {
                if (MessageBox.Show("You have unsaved data, do you want to exit anyway?", "Closing form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }


        private void ShippingStagedContainers_Load(object sender, EventArgs e)
        {
            // Create an instance of NumericTextBox.
            textBoxTagNumber = new NumericTextBox();
            textBoxTagNumber.Parent = this;

            toolStrip1.Renderer = new App_Code.NewToolStripRenderer();
            //Draw the bounds of the NumericTextBox.
            //textBoxTagNumber.Bounds = new Rectangle(5, 5, 150, 100);

            textBoxTagNumber.Location = new System.Drawing.Point(171, 26);        //Point(171, 26);
            textBoxTagNumber.Name = "textBoxTagNumber";
            textBoxTagNumber.ReadOnly = true;
            textBoxTagNumber.Size = new System.Drawing.Size(200, 26);
            textBoxTagNumber.TabIndex = 1;
            textBoxTagNumber.MaxLength = 20;
            textBoxTagNumber.Enter += new System.EventHandler(this.textBoxTagNumber_Enter);
            textBoxTagNumber.Leave += new System.EventHandler(this.textBoxTagNumber_Leave);
            textBoxTagNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTagNumber_KeyDown);


            this.panelLeft.Controls.Add(textBoxTagNumber);

            // TODO: This line of code loads data into the 'dataSetProductsLookup.sol_Products' table. You can move, or remove it, as needed.
            this.sol_ProductsTableAdapter.Fill(this.dataSetProductsLookup.sol_Products, 0); //0 = return products

            // TODO: This line of code loads data into the 'dataSetContainersLookup.sol_Containers' table. You can move, or remove it, as needed.
            //this.sol_ContainersTableAdapter.Fill(this.dataSetContainersLookup.sol_Containers);
            this.sol_ContainersTableAdapter.FillByType(this.dataSetContainersLookup.sol_Containers, 1); //1 = shipping containers

            originalAcceptButton = this.AcceptButton;

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

            //classes of tables
            sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

            comboBoxProducts.SelectedValue = -1;
            comboBoxContainers.SelectedValue = -1;

            if (ShippingHome.StagedContainerButtonNew)
            {
                ShippingHome.StagedContainerButtonNew = false;
                buttonNew.PerformClick();
            }

            else if (ShippingHome.StagedContainerButtonView)
            {
                textBoxTagNumber.Text = ShippingHome.tagNumber;
                ShippingHome.tagNumber = "";
                ShippingHome.StagedContainerButtonView = false;
                buttonSearch.Enabled = true;
                buttonSearch.PerformClick();
            }

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

            buttonNew.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
            buttonView.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewContainer", false);

        }


        private void toolStripButtonHome_Click(object sender, EventArgs e)
        {
            ShippingForm = 1;   //Home
            Close();

        }

        private void toolStripButtonShipments_Click(object sender, EventArgs e)
        {
            ShippingForm = 3;   //Shipments
            Close();

        }

        private void toolStripButtonLookup_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupShipment", true))
                return;

            ShippingForm = 4;   //lookup
            Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", true))
                return;

            buttonClicked = buttonNew.Text; // "new";
            //textBoxStageID;
            //textBoxUserName;
            //dateTimePicker1;

            EnableControls(true);

            comboBoxContainers.SelectedValue = -1;
            comboBoxProducts.SelectedValue = -1;

            EnableButtons("new");

            ClearForm();

            textBoxTagNumber.Focus();
            controlWithFocus = textBoxTagNumber;

            //comboBoxProducts.Focus();
            //controlWithFocus = comboBoxProducts;

            //for upon exit
            flagChange = true;

            if (sol_Agency != null
                && sol_Agency.AutoGenerateTagNumber
                )
            {
                //add row
                if (AddStagedRow())
                {
                    //textBoxTagNumber.Text = sol_Stage.TagNumber;
                    textBoxTagNumber.ReadOnly = true;
                    comboBoxProducts.Focus();
                }
                else
                    buttonCancel.PerformClick();
            }



        }

        private bool AddStagedRow()
        {
            //if(osi == null)
            //    osi = new SirLib.ObtenerSiguienteId(Properties.Settings.Default.WsirDbConnectionString);

            sol_Stage = new Sol_Stage();


            if (sol_Agency != null
                && sol_Agency.AutoGenerateTagNumber
                )
            {

                AutoGenerateTagNumber();
                sol_Stage.TagNumber = textBoxTagNumber.Text;
            }

            //sol_Stage.StageID = osi.Id("Sol_Stage", "StageId", null, null);

            if(membershipUser == null)
                membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot close the Container");
                return false;
            }
            sol_Stage.UserID = (Guid)membershipUser.ProviderUserKey;
            sol_Stage.UserName = Properties.Settings.Default.UsuarioNombre;
            sol_Stage.Date = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
            sol_Stage.Status = "I"; //InProcess

            //sol_Stage.TagNumber = osi.Id("Sol_Stage", "Cast(TagNumber as int)", null, null).ToString();

            //in case there is no default value in the db
            sol_Stage.DateClosed = DateTime.Parse("1753-01-01 12:00:00.000");

            try
            {
                sol_Stage_Sp.Insert(sol_Stage);
            }
            catch
            {
                //try once more
                if (sol_Agency != null
                    && sol_Agency.AutoGenerateTagNumber
                    )
                {

                    AutoGenerateTagNumber();
                }
                try
                {
                    sol_Stage_Sp.Insert(sol_Stage);
                }
                catch (Exception e)
                {
                    CajaDeMensaje.Show("SqlError", "Error trying to add a new Staged Container row, try again later please", e.Message, CajaDeMensajeImagen.Error);
                    sol_Stage = null;
                    return false;
                }
            }


            return true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter a Product");
                comboBoxProducts.Focus();
                return;
            }

            if (String.IsNullOrEmpty(textBoxTagNumber.Text))
            {
                MessageBox.Show("Please enter a Tag number");
                textBoxTagNumber.Focus();
                controlWithFocus = textBoxTagNumber;
                return;
            }

            if (comboBoxContainers.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter a Container Type");
                comboBoxContainers.Focus();
                return;
            }

            int quantity = 0;
            try
            {

                quantity = Int32.Parse(textBoxQuantity.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid quantity.");
                textBoxQuantity.Focus();
                return;
            }

            if (String.IsNullOrEmpty(textBoxDozen.Text))
            {
                MessageBox.Show("Please enter number of dozens");
                textBoxDozen.Focus();
                return;
            }

            decimal dozen = 0;
            try
            {

                dozen = decimal.Parse(textBoxDozen.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid number of dozens.");
                textBoxDozen.Focus();
                return;
            }

            //add
            if (sol_Agency != null
                && sol_Agency.AutoGenerateTagNumber 
                && buttonClicked == "&New"
                )
            {
                //update
                UpdateStagedContainer();
            }
            else
            {
                if (buttonClicked == "&New")
                {
                    /* I-InProgress; P-Picked S-Shipped D -Void "" = any */
                    sol_Stage = sol_Stage_Sp._SelectByTagNumberStatus(textBoxTagNumber.Text, "");   //I");
                    if (sol_Stage != null)
                    {
                        MessageBox.Show("Tag number already exists, try another one please.");
                        textBoxTagNumber.Focus();
                        controlWithFocus = textBoxTagNumber;
                        return;
                    }

                    AddStagedContanier();

                }
                else
                {
                    //update
                    UpdateStagedContainer();
                }
            }                

            //view state
            EnableControls(false);

            EnableButtons("close");

            //for upon exit
            flagChange = false;

            sol_Agency = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //delete row if it was new
            if (sol_Agency != null
               && sol_Agency.AutoGenerateTagNumber
               && buttonClicked == "&New"
            )
            {
                if (DeleteStagedRow())
                    RestoreTagNumber();

                

            }

            EnableControls(false);

            EnableButtons("cancel");

            ClearForm();
            this.AcceptButton = originalAcceptButton;

        }

        private bool DeleteStagedRow()
        {
            try
            {
                sol_Stage_Sp.Delete(sol_Stage.StageID);
            }
            catch { }

            textBoxTagNumber.Text = "";
            return true;
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            buttonClicked = buttonView.Text;    // "view";

            if (buttonClicked == "&View" && !Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewContainer", true))
                return;


            if (buttonClicked == "&Edit")
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolModifyContainer", true))
                    return;

                EnableControls(true);
                textBoxTagNumber.ReadOnly = true;
                comboBoxContainers.Focus();
                EnableButtons("edit");
                this.AcceptButton = originalAcceptButton;

                //for upon exit
                flagChange = true;

                return;
            }



            textBoxTagNumber.ReadOnly = false;
            EnableButtons("view");
            ClearForm();
            textBoxTagNumber.Focus();
            controlWithFocus = textBoxTagNumber;    // GetFocusControl();

            this.AcceptButton = buttonSearch;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxTagNumber.Text))
            {
                MessageBox.Show("Please enter a Tag number");
                textBoxTagNumber.Focus();
                controlWithFocus = textBoxTagNumber;
                return;
            }

            //wasStage  a barcode read?
            string barCode = textBoxTagNumber.Text.Trim();
            string x = barCode;
            if (x.Length > 7)
            {
                //x = x.Substring(x.Length - 7);
                //int intValue = 0;
                //Int32.TryParse(x, out intValue);
                //if (intValue > 0)
                //    textBoxTagNumber.Text = String.Format("{0}", intValue);
                //else
                //{
                //    MessageBox.Show("Error parsing the Tag Number!");
                //    textBoxTagNumber.Focus();
                //    return;
                //}


                ////search for product from barcode
                //x = barCode;
                //x = x.Substring(x.Length - (7 + 5 + 4), 4);
                //if (sol_Product_Sp == null)
                //    sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);

                ////search for product
                //sol_Product = sol_Product_Sp.SelectProductCode(x);
                //if (sol_Product != null)
                //{

                //    comboBoxProducts.SelectedValue = sol_Product.ProductID;


                //}


            }

            sol_Stage = sol_Stage_Sp._SelectByTagNumberStatus(textBoxTagNumber.Text, "I");
            if (sol_Stage == null)
            {
                MessageBox.Show("Tag number not found, try another one please.");
                textBoxTagNumber.Focus();
                controlWithFocus = textBoxTagNumber;
                return;

            }


            FillForm();

            textBoxTagNumber.ReadOnly = true;

            EnableButtons("search");



        }
        

        private void EnableControls(bool flag)
        {
            textBoxTagNumber.ReadOnly = !flag;
            comboBoxContainers.Enabled = flag;
            comboBoxProducts.Enabled = flag;

            textBoxQuantity.ReadOnly = !flag;
            textBoxDozen.ReadOnly = !flag;
            textBoxRemarks.ReadOnly = !flag;
        }

        private bool AddStagedContanier()
        {

            if (sol_Agency != null
                && sol_Agency.AutoGenerateTagNumber
                )
            {

                AutoGenerateTagNumber();
            }

            sol_Stage = new Sol_Stage();
            if (membershipUser == null)
                membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
            if (membershipUser == null)
            {
                MessageBox.Show("User does not exits, cannot close the Container");
                return false;
            }
            sol_Stage.UserID = (Guid)membershipUser.ProviderUserKey;
            sol_Stage.UserName = Properties.Settings.Default.UsuarioNombre;
            sol_Stage.Date = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
            sol_Stage.TagNumber = textBoxTagNumber.Text;
            sol_Stage.ContainerID= Int32.Parse(comboBoxContainers.SelectedValue.ToString());
            sol_Stage.ContainerDescription = comboBoxContainers.Text;
            sol_Stage.ProductID  = Int32.Parse(comboBoxProducts.SelectedValue.ToString());
            sol_Stage.ProductName = comboBoxProducts.Text;
            sol_Stage.Quantity = Int32.Parse(textBoxQuantity.Text);
            sol_Stage.Dozen = 0;    //not using it anymore
            sol_Stage.Status = "I"; //InProcess
            sol_Stage.Remarks = textBoxRemarks.Text.Trim();

            ////include product price
            //Sol_Product_Sp sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //Sol_Product sol_Product = sol_Product_Sp.Select(sol_Stage.ProductID);
            //sol_Stage.Price = sol_Product.Price;
            sol_Stage.Price = 0.00m;

            //in case there is no default value in the db
            sol_Stage.DateClosed = DateTime.Parse("1753-01-01 12:00:00.000");

            try
            {
                sol_Stage_Sp.Insert(sol_Stage);
            }
            catch
            {
                if (sol_Agency != null
                    && sol_Agency.AutoGenerateTagNumber
                    )
                {

                    AutoGenerateTagNumber();
                }
                try
                {
                    sol_Stage_Sp.Insert(sol_Stage);
                }
                catch (Exception e)
                {
                    CajaDeMensaje.Show("SqlError", "Error trying to add a new Staging, try again later please", e.Message, CajaDeMensajeImagen.Error);
                    sol_Stage = null;
                    return false;
                }

            }

            //textBoxStageID.Text = sol_Stage.StageID.ToString();
            textBoxUserName.Text = sol_Stage.UserName;
            //dateTimePicker1.Value = sol_Stage.Date;
            textBoxDate.Text = sol_Stage.Date.ToString("G");


            

            return true;
        }

        private void ClearForm()
        {
            //textBoxStageID.Text = "";
            textBoxUserName.Text = "";
            textBoxDate.Text = "";

            textBoxTagNumber.Text = "";
            comboBoxContainers.SelectedValue = -1;
            comboBoxContainers.Text = "";
            comboBoxProducts.SelectedValue = -1;
            comboBoxProducts.Text = "";
            textBoxQuantity.Text = "";
            textBoxDozen.Text = "";
            textBoxDefaultDozen.Text = "";
            textBoxRemarks.Text = "";

            controlWithFocus = null;

            //for upon exit
            flagChange = false;

            sol_Agency = null;


        }

        private void FillForm()
        {
            //textBoxStageID.Text = sol_Stage.StageID.ToString();

            textBoxUserName.Text = sol_Stage.UserName;
            textBoxDate.Text = sol_Stage.Date.ToString("G");


            this.comboBoxProducts.SelectedIndexChanged -= new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
            comboBoxProducts.SelectedValue = sol_Stage.ProductID;
            this.comboBoxProducts.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
            //comboBoxProducts.Text = sol_Stage.ProductName;

            comboBoxContainers.SelectedValue = sol_Stage.ContainerID;
            //comboBoxContainers.Text = sol_Stage.ContainerDescription;

            textBoxQuantity.Text = sol_Stage.Quantity.ToString();
            textBoxDozen.Text = SolFunctions.Quantity2Dozen(sol_Stage.Quantity);
            textBoxRemarks.Text = sol_Stage.Remarks;
        }

        private bool UpdateStagedContainer()
        {
            //sol_Stage.UserID = (Guid)membershipUser.ProviderUserKey;
            //sol_Stage.UserName = Properties.Settings.Default.UsuarioNombre;
            //sol_Stage.Date = DateTime.Now;
            //sol_Stage.TagNumber = textBoxTagNumber.Text;
            
            int intVal = 0;
            Int32.TryParse(comboBoxContainers.SelectedValue.ToString(), out intVal);
            sol_Stage.ContainerID = intVal;

            sol_Stage.ContainerDescription = comboBoxContainers.Text;
            sol_Stage.ProductID = Int32.Parse(comboBoxProducts.SelectedValue.ToString());
            sol_Stage.ProductName = comboBoxProducts.Text;

            Int32.TryParse(textBoxDozen.Text, out intVal);
            sol_Stage.Dozen = intVal;

            sol_Stage.Remarks = textBoxRemarks.Text ;

            ////include product price
            //Sol_Product_Sp sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //Sol_Product sol_Product = sol_Product_Sp.Select(sol_Stage.ProductID);
            //sol_Stage.Price = sol_Product.Price;
            sol_Stage.Price = 0.00m;

            try
            {
                sol_Stage_Sp.Update(sol_Stage);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        private void EnableButtons(string buttonName)
        {

            toolStripButtonHome.Enabled = true;
            toolStripButtonStagedContainers.Enabled = true;
            toolStripButtonShipments.Enabled = true;
            toolStripButtonLookup.Enabled = true;
            toolStripButtonLogOff.Enabled = true;
            toolStripButtonExit.Enabled = true;

            switch(buttonName)
            {
                case "new":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = false;
                    buttonSearch.Enabled = false;
                    buttonPrintLabel.Enabled = false;

                    panelNumericKb.Enabled = true;

    	            toolStripButtonHome.Enabled = false;
            	    toolStripButtonStagedContainers.Enabled = false;
	                toolStripButtonShipments.Enabled = false;
    		        toolStripButtonLookup.Enabled = false;
                    toolStripButtonLogOff.Enabled = false;
                    toolStripButtonExit.Enabled = false;

                    break;
                case "close":
                    buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolModifyContainer", false);
                    buttonView.Text = "&Edit";
                    buttonSearch.Enabled = false;
                    buttonPrintLabel.Enabled = true;
                    panelNumericKb.Enabled = false;
                    break;
                case "cancel":
                    buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = false;
                    buttonView.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewContainer", false);
                    buttonView.Text = "&View";
                    buttonSearch.Enabled = false;
                    buttonPrintLabel.Enabled = false;
                    panelNumericKb.Enabled = false;
                    break;
                case "view":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = false;
                    buttonSearch.Enabled = true;
                    buttonPrintLabel.Enabled = false;
                    panelNumericKb.Enabled = true;
                    break;
                case "search":
                    buttonNew.Enabled = true & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateContainer", false);
                    buttonClose.Enabled = false;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = true  & Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolModifyContainer", false);;
                    buttonView.Text = "&Edit";
                    buttonSearch.Enabled = false;
                    buttonPrintLabel.Enabled = true;
                    panelNumericKb.Enabled = false;
                    break;
                case "edit":
                    buttonNew.Enabled = false;
                    buttonClose.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonView.Enabled = false;
                    buttonView.Text = "&View";
                    buttonSearch.Enabled = false;
                    buttonPrintLabel.Enabled = false;
                    panelNumericKb.Enabled = true;
    	            toolStripButtonHome.Enabled = false;
            	    toolStripButtonStagedContainers.Enabled = false;
	                toolStripButtonShipments.Enabled = false;
    		        toolStripButtonLookup.Enabled = false;
                    toolStripButtonLogOff.Enabled = false;
                    toolStripButtonExit.Enabled = false;
                    break;
                default:
                    break;

            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (controlWithFocus == null)
                return;
            
            string buttonName = ((Button)sender).Name;
            if(buttonName == "buttonBackSpace")
            {
                if (!String.IsNullOrEmpty(controlWithFocus.Text))
                {
                    string c = controlWithFocus.Text;
                    c = c.Remove(controlWithFocus.Text.Length-1, 1);
                    controlWithFocus.Text = c;

                }
                controlWithFocus.Focus();
                ((TextBox)controlWithFocus).DeselectAll();
                ((TextBox)controlWithFocus).Select(controlWithFocus.Text.Length, 1);
                return;
            }
            else if (buttonName == "buttonGuion")
                buttonName = "-";
            else if (buttonName == "buttonPoint")
                buttonName = ".";
            else
                buttonName = buttonName.Replace("button", "");

            controlWithFocus.Text += buttonName;
            controlWithFocus.Focus();
            ((TextBox)controlWithFocus).DeselectAll();
            ((TextBox)controlWithFocus).Select(controlWithFocus.Text.Length, 1);


        }

        private void textBoxTagNumber_Enter(object sender, EventArgs e)
        {
            if(textBoxTagNumber.ReadOnly)
                controlWithFocus = null;
            else
                controlWithFocus = textBoxTagNumber;
        }

        private void comboBoxContainers_Enter(object sender, EventArgs e)
        {
            controlWithFocus = null;
        }

        private void textBoxQuantity_Enter(object sender, EventArgs e)
        {
            controlWithFocus = textBoxQuantity;
        }

        private void textBoxDozen_Enter(object sender, EventArgs e)
        {
            controlWithFocus = textBoxDozen;
        }

        private void textBoxRemarks_Enter(object sender, EventArgs e)
        {
            controlWithFocus = textBoxRemarks;
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

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = -1;
            try
            {
                Id = (int)comboBoxProducts.SelectedValue;
            }
            catch
            {
                return;
            }


            //delete row if it was new
            if (sol_Agency != null)
            {
                if (sol_Agency.AutoGenerateTagNumber)
                    if (buttonClicked == "&New")
                        DeleteStagedRow();
            }

            //Sol_Product sol_Product = new Sol_Product();
            if(sol_Product_Sp == null)
                sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_Product = sol_Product_Sp.Select(Id);

            comboBoxContainers.SelectedValue = sol_Product.ContainerID;


            //open table connection
            if (sol_Agency_Sp == null)
                sol_Agency_Sp = new Sol_Agencie_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_Agency = sol_Agency_Sp.Select(sol_Product.AgencyID);
            //if (sol_Agency != null)
            //{
            //    Int32.TryParse(sol_Agency.VendorID, out intValue);
            //    vendorId = intValue.ToString("0000");
            //}


            if (sol_Agency.AutoGenerateTagNumber)
            {
                //add row
                if (AddStagedRow())
                {
                    textBoxTagNumber.Text = sol_Stage.TagNumber;
                    textBoxTagNumber.ReadOnly = true;
                    comboBoxContainers.Focus();
                    comboBoxProducts.Enabled = false;
                }
                else
                    buttonCancel.PerformClick();
            }
            else
            {
                textBoxTagNumber.ReadOnly = false;
                //textBoxTagNumber.Focus();
            }

            //Sol_StandardDozen_Sp sol_StandardDozen_Sp = new Sol_StandardDozen_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //Sol_StandardDozen sol_StandardDozen = sol_StandardDozen_Sp.Select(sol_Product.StandardDozenID);
            //textBoxDefaultDozen.Text = sol_StandardDozen.Quantity.ToString();

            textBoxQuantity.Text = sol_Product.TargetQuantity.ToString();
            textBoxDozen.Text = SolFunctions.Quantity2Dozen(sol_Product.TargetQuantity);

        }

        private void buttonPrintLabel_Click(object sender, EventArgs e)
        {
            //commands
            /*
             * {barCode}
             * {vendorId}
             * {productCode}
             * {quantity}
             * {tag}
             * {depotName}
             * {description}    of the product
             * {dozen}
             * {date}
             * {stageId}
            */


            string barCode = String.Empty;
            string vendorId = String.Empty;
            string productCode = String.Empty;
            string quantity = String.Empty;
            string tag = String.Empty;

            int intValue = 0;

            //sending raw directly to lp2844
            UpcLabel label = new UpcLabel("");
            string labelCommands = Properties.Settings.Default.SettingsWsLabelCommands;

            //open table connection
            if(sol_Agency_Sp == null)
                sol_Agency_Sp = new Sol_Agencie_Sp(Properties.Settings.Default.WsirDbConnectionString);
            if(sol_Product_Sp == null)
                sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //search for product
            sol_Product = sol_Product_Sp.Select(sol_Stage.ProductID);
            if (sol_Product != null)
            {

                intValue = 0;
                Int32.TryParse(sol_Product.ProductCode, out intValue);
                productCode = intValue.ToString("0000");

                sol_Agency = sol_Agency_Sp.Select(sol_Product.AgencyID);
                if (sol_Agency != null)
                {
                    intValue = 0;
                    Int32.TryParse(sol_Agency.VendorID, out intValue);
                    vendorId = intValue.ToString("0000");
                }
            }

          
            intValue = 0;
            Int32.TryParse(textBoxDozen.Text, out intValue);
            string c = String.Format("{0}", intValue);
            labelCommands = labelCommands.Replace("{dozen}", c);

            int intQuantity = intValue * 12;
            c = String.Format("{0}", intQuantity);
            labelCommands = labelCommands.Replace("{quantity}", c);
            quantity = intQuantity.ToString("00000");

            intValue = 0;
            Int32.TryParse(textBoxTagNumber.Text, out intValue);
            tag = intValue.ToString("0000000");

            barCode = vendorId + productCode + quantity + tag;
            labelCommands = labelCommands.Replace("{barCode}", barCode);

            labelCommands = labelCommands.Replace("{vendorId}", sol_Agency.VendorID.Trim());
            labelCommands = labelCommands.Replace("{productCode}", sol_Product.ProductCode.Trim());
            labelCommands = labelCommands.Replace("{quantity}", sol_Stage.Quantity.ToString().Trim());

            labelCommands = labelCommands.Replace("{tag}", textBoxTagNumber.Text.Trim());

            labelCommands = labelCommands.Replace("{depotName}", Main.Sol_ControlInfo.BusinessName.Trim());
            labelCommands = labelCommands.Replace("{description}", sol_Product.ProDescription.Trim());

            //labelCommands = labelCommands.Replace("{dozen}", textBoxTagNumber.Text.Trim());
            //labelCommands = labelCommands.Replace("{date}", textBoxTagNumber.Text.Trim());
            //labelCommands = labelCommands.Replace("{stageId}", textBoxTagNumber.Text.Trim());

            ////MessageBox.Show(labelCommands);
            //labelCommands = labelCommands.Replace("{tag}", textBoxTagNumber.Text.Trim());
            ////labelCommands = labelCommands.Replace("{agency}", textBoxTagNumber.Text.Trim());
            //labelCommands = labelCommands.Replace("{description}", comboBoxProducts.Text.Trim());

            DateTime dt = Main.rc.FechaActual; // ;
            try
            {
                dt = DateTime.Parse(textBoxDate.Text);
            }
            catch { }

            labelCommands = labelCommands.Replace("{date}", dt.ToString("dd-MMM-yyyy"));
            labelCommands = labelCommands.Replace("{stageId}", sol_Stage.StageID.ToString());

            try
            {
                //quitar (uncomment)
                label.Print(Properties.Settings.Default.SettingsWsLabelPrinter, labelCommands);

                //quitar (comment)
                //MessageBox.Show(labelCommands);

            }
            catch
            {
                MessageBox.Show("Label printer not found!");
            }

        }

        private void toolStripButtonLogOff_Click(object sender, EventArgs e)
        {
            //hacer logout si el usuario estaba conectado
            SolFunctions.LogOff(ref toolStripStatusLabelUserName);
            SolFunctions.CheckComputerRole(ref toolStripButtonExit);

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


        private void textBoxTagNumber_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxTagNumber.Text))
                return;

            if (buttonClicked != "&New")
                return;


            //was a barcode read?
            string barCode = textBoxTagNumber.Text.Trim();
            string x = barCode;
            if (x.Length > 7)
            {
                //x = x.Substring(x.Length - 7);
                //int intValue = 0;
                //Int32.TryParse(x, out intValue);
                //if (intValue > 0)
                //    textBoxTagNumber.Text = String.Format("{0}", intValue);
                //else
                //{
                //    MessageBox.Show("Error parsing the Tag Number!");
                //    textBoxTagNumber.Focus();
                //    return;
                //}


                //search for product from barcode   
                /* 0000 1006 00000 0004209
                 * 4 = vendorID
                 *      4 = productCode = ItemTypes (CRIS)
                 *           5 = quantity
                 *                 7 = tagNumber
                 * 7 + 5 + 4
                 * 
                */

                x = barCode;
                if(x.Length>19)
                {
                    int i = x.Length - 16;
                    x = x.Substring(i, 4);
                }
                if (sol_Product_Sp == null)
                    sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);

                //search for product
                sol_Product = sol_Product_Sp.SelectProductCode(x);
                if (sol_Product != null)
                {
                    comboBoxProducts.SelectedValue = sol_Product.ProductID;
                    textBoxQuantity.Focus();
                    //textBoxDozen.Focus();
                }
            }
        }

        private void textBoxTagNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    //this.GetNextControl(ActiveControl, true).Focus();
                    System.Windows.Forms.SendKeys.Send("{TAB}"); 

                }
            }
        }

        private void textBoxDefaultDozen_Click(object sender, EventArgs e)
        {
            decimal decValue = 0;
            decimal.TryParse(textBoxDefaultDozen.Text, out decValue);

            textBoxQuantity.Text = (decValue * 12).ToString();
            int intValue = 0;
            int.TryParse(textBoxQuantity.Text, out intValue);
            textBoxDozen.Text = SolFunctions.Quantity2Dozen(intValue);
        }


        //find out which control has focus
        //protected Control GetFocusControl()
        //{
        //    Control focusControl = null;
        //    IntPtr focusHandle = GetFocus();
        //    if (focusHandle != IntPtr.Zero)
        //        // returns null if handle is not to a .NET control
        //        focusControl = Control.FromHandle(focusHandle);
        //    return focusControl;
        //} 


        private bool AutoGenerateTagNumber()
        {
            int id = sol_Agency.AgencyID;

            if (id < 1)
                return false;

            if (sol_AutoNumber_Sp == null)
                sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

            id = sol_AutoNumber_Sp.UpdateTagNumber(id, 1);
            if (id < 1)
            {
                MessageBox.Show("Can not generate next Tag number, last Tag number should be a valid integer.");
                return false;

            }
            textBoxTagNumber.Text = id.ToString();

            return true;
        }

        private bool RestoreTagNumber()
        {
            int id = sol_Agency.AgencyID;

            if (id < 1)
                return false;

            if (sol_AutoNumber_Sp == null)
                sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

            Sol_AutoNumber sol_AutoNumber = sol_AutoNumber_Sp.Select(id, 1);
            int tagNumber = 0;
            int.TryParse(sol_Stage.TagNumber, out tagNumber);
            if (sol_AutoNumber.TagNumber == tagNumber)
            {
                sol_AutoNumber.TagNumber--;
                sol_AutoNumber_Sp.Update(sol_AutoNumber);
            }

            return true;

        }

        private void toolStripButtonShipmentAdjustments_Click(object sender, EventArgs e)
        {
            ShippingForm = 5;   //Adjustments
            Close();

        }

        private void toolStripButtonMultiProductStaging_Click(object sender, EventArgs e)
        {
            ShippingForm = 6;   //MultiProductStagedContainers
            Close();

        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            this.textBoxDozen.TextChanged -= new System.EventHandler(this.textBoxDozen_TextChanged);
            int qty = 0;
            int.TryParse(textBoxQuantity.Text, out qty);
            textBoxDozen.Text = SolFunctions.Quantity2Dozen(qty);
            this.textBoxDozen.TextChanged += new System.EventHandler(this.textBoxDozen_TextChanged);

        }

        private void textBoxDozen_TextChanged(object sender, EventArgs e)
        {
            this.textBoxQuantity.TextChanged -= new System.EventHandler(this.textBoxQuantity_TextChanged);
            decimal dzn = 0;
            decimal.TryParse(textBoxDozen.Text, out dzn);
            int qty = (int)(dzn * 12);
            textBoxQuantity.Text = (qty).ToString();
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxQuantity_TextChanged);
        }

        private void ButtonEnabledChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = button.Enabled;
        }

    }
}
