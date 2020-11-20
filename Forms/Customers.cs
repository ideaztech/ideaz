
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
    public partial class Customers : Form
    {
        public bool fromPutOnAccountForm { get;  set; }       // 
        public short customerType { get; set; }     //-1 = all, 0 = solum, 1 = quickdrop

        public short activeType { get; set; }    //-1 = all, 0 = inactivos, 1 = activos

        string formerCardNumber;

        Sol_Customer sol_Customer;
        Sol_Customer_Sp sol_Customer_Sp;


        public bool manageMode {get; set;}

        #region UsbHid Variables
        #endregion

        Sol_Order_Sp sol_Order_Sp;
        //Sol_Order sol_Order;

        public int fieldId = -1;
        public string fieldName = "";

        private string b_Accion = "";

        public Customers()
        {
            InitializeComponent();
            manageMode = false;
            customerType = -1;   //all
            activeType = 1;   //actives
            fromPutOnAccountForm = false;
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qdsDataSetCardTypes.Qds_CardTypes' table. You can move, or remove it, as needed.

            toolStripButtonInactives.Visible = !fromPutOnAccountForm;

            this.qds_CardTypesTableAdapter.Fill(this.qdsDataSetCardTypes.Qds_CardTypes);

            //don't show select button in manage mode
            OK.Visible = !manageMode;

            //if (Properties.Settings.Default.TouchOriented)
            //{
              //  this.Height = this.Height + (OK.Height) + 150;
                //OK.Height = OK.Height * 2;
                //buttonDetails.Height = buttonDetails.Height * 2;
                //buttonOrders.Height = buttonOrders.Height * 2;
                //Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
            // }
            //else
            //{
            //   int tamano = 16;
            //  BindingNavigator1.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
            // BindingNavigator1.Size = new System.Drawing.Size(BindingNavigator1.Size.Width, tamano + 7);
            // BindingNavigator1.Stretch = false;

            //}

            BindingNavigator1.Renderer = new App_Code.NewToolStripRenderer();

            this.Width = Main.ActiveForm.Width - 50;
            this.Height = Main.ActiveForm.Height - 50;


            this.CenterToParent();

            //bloquear  columnas
            DataGridView1.ReadOnly = true;
            
            short indice = 0;
            //0 id
            DataGridView1.Columns[indice].HeaderText = "Id";
            DataGridView1.Columns[indice].ReadOnly = true;  //.Visible = false;
            DataGridView1.Columns[indice].Width = 80;
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //1 Code
            //DataGridView1.Columns[indice].HeaderText = "Description";
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //2 Name
            //DataGridView1.Columns[indice].HeaderText = "Description";
            DataGridView1.Columns[indice].Width = 300;
            indice++;

            //3 [Contact] [varchar](50) NULL,
            //DataGridView1.Columns[indice].HeaderText = "Description";
            DataGridView1.Columns[indice].Width = 220;  // 350;
            indice++;
            //4 [Address1] [varchar](250) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //5 [Address2] [varchar](250) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //6 [City] [varchar](100) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //7 [Province] [varchar](100) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //8 [Country] [varchar](50) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //9 [PostalCode] [varchar](50) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //10 [Email] [nvarchar] (256) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //11 [LoweredEmail] [nvarchar] (256) NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //12- [IsActive] [bit] NOT NULL,
            DataGridView1.Columns[indice].Width = 80;  // 350;
            //DataGridView1.Columns[indice].Visible = false;
            indice++;
            //13- [PhoneNumber] [bit] NOT NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //14- [Notes] [bit] NOT NULL,
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //15- [Balance] [bit] NOT NULL,
            DataGridView1.Columns[indice].Width = 100;
            indice++;
            //16- [Password]
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //17- [DepotID]
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //18- [CardNumber]
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //19- [CardTypeID]
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //20- [SolumCustomer]
            DataGridView1.Columns[indice].Visible = false;
            indice++;
            //21- [QuickDropCustomer]
            DataGridView1.Columns[indice].Visible = false;
            indice++;

            //22- currentSolumBalance
            DataGridView1.Columns[indice].Visible = true;
            indice++;
            //23- currentQuickDropBalance
            DataGridView1.Columns[indice].Visible = true;
            indice++;
            //24- currentBalance
            DataGridView1.Columns[indice].Visible = true;
            indice++;
            //25- PendingBags
            DataGridView1.Columns[indice].Visible = true;
            DataGridView1.Columns[indice].Width = 70;  // 350;

            indice++;


            //quickdrop
            if (Main.QuickDrop_DepotID == null || Main.QuickDrop_DepotID.Length != 6)
            {
                //this.Width = 844;
                //22- currentSolumBalance
                DataGridView1.Columns[22].Visible = false;
                indice++;
                //23- currentQuickDropBalance
                DataGridView1.Columns[23].Visible = false;

            }
            else
            {
               // this.Width = 944;

                if (customerType < 1)     //-1 = all, 0 = solum, 1 = quickdrop
                {
                    //22- currentSolumBalance
                    DataGridView1.Columns[22].Visible = true;
                    indice++;
                    //23- currentQuickDropBalance
                    DataGridView1.Columns[23].Visible = false;
                }
                else
                {
                    //22- currentSolumBalance
                    DataGridView1.Columns[22].Visible = false;
                    indice++;
                    //23- currentQuickDropBalance
                    DataGridView1.Columns[23].Visible = true;
                }
            }


            //make dataGrid active (focus)
            this.DataGridView1.Select();

            //for usb hid
            if (Main.CardReader_Enabled)
            {
                if (Main.CardReader_EmulationMode == 0)    //HID
                {
                    //Shutdown();
                    Main.usbReadEventForm = "";
                    this.timer1.Tick -= new System.EventHandler(this.timer1_Tick);
                    timer1.Enabled = false;
                    labelSwipeCard.Visible = true;

                }
            }

            if (Main.Sol_ControlInfo.State == "AB"
                && Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
            {
                labelQuickDropCustomer.Visible = true;
                quickDropCustomerCheckBox.Visible = true;
                panelQuickDrop.Visible = true;
                solumCustomerCheckBox.Enabled = true;


                if (customerType == 0)  //solum
                {
                    //localCustomerType = 1;
                    buttonSolum.Visible = false;
                    buttonQuickDrop.Visible = false;

                    //customerType = 0;
                    this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);
                }
                else if (customerType == 1) //quickdrop
                {
                    buttonSolum.Visible = false;
                    buttonQuickDrop.Visible = true;
                    buttonQuickDrop.Location = buttonSolum.Location;

                    buttonQuickDrop.PerformClick();

                }
                else
                {
                    buttonSolum.Visible = true;
                    buttonQuickDrop.Visible = true;

                    buttonSolum.PerformClick();
                }



            }
            else
            {
                customerType = 0;   //solum
                this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);
            }


        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count < 1)
                return;

            if (OK.Text == "&Select")
            {
                try
                {
                    fieldId = (int)this.DataGridView1.CurrentRow.Cells[0].Value;
                    if (fieldId < 1)
                        throw new Exception();
                    fieldName = DataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                }
                catch
                {
                    MessageBox.Show("Please select a valid item.");
                    return;
                }

                Close();
                return;
            }


            BindingNavigatorSaveItem.PerformClick();

        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (b_Accion == "agregar")
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                    return;
            }
            else
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                    return;
            }

            //check data
            //name 
            fieldNameTextBox.Text = fieldNameTextBox.Text.Trim();
            if (!Funciones.ValidateText(fieldNameTextBox, ref errorProvider1))
            {
                fieldNameTextBox.Focus();
                return;
            }

            //quickdrop
            if (quickDropCustomerCheckBox.Checked)
            {

                //this.Validate();
                //this.BindingSource1.EndEdit();


                //cardNumberTextBox
                if (String.IsNullOrEmpty(cardNumberTextBox.Text))
                {
                    MessageBox.Show("Enter a card number please!");
                    cardNumberTextBox.Focus();
                    return;
                }


                //aqui
                if (formerCardNumber != cardNumberTextBox.Text)
                {
                    if (sol_Customer_Sp == null)
                        sol_Customer_Sp = new Sol_Customer_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    sol_Customer = sol_Customer_Sp.SelectByCardNumber(cardNumberTextBox.Text);
                    if (sol_Customer != null)
                    {
                        MessageBox.Show("Card number already used, try another please!");
                        cardNumberTextBox.Focus();
                        return;
                    }
                }
                

            }


            this.Validate();
            this.BindingSource1.EndEdit();

            this.TableAdapterManager.UpdateAll(this.DataSet1);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);
                    this.BindingSource1.MoveLast();
                }
            }
            catch
            {
                //
            }

            b_Accion = "";
            OK.Text = "&Select";
            Cancel.Text = "&Close";

            cambiarVista();


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

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.DataSet1.HasChanges())
            //{
            //    DialogResult result = MessageBox.Show("There are uncommitted changes, do you wish to continue?", "", MessageBoxButtons.YesNo);
            //    if (result == System.Windows.Forms.DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}


            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count < 1)
                return;

            fieldId = (int)this.DataGridView1.CurrentRow.Cells[0].Value;
            if (fieldId > 0)
            {


                decimal currentBalance = 0;
                decimal.TryParse(this.DataGridView1.CurrentRow.Cells[22].Value.ToString(), out currentBalance);

                CustomerOrders f1 = new CustomerOrders(
                                fieldId,
                                DataGridView1.CurrentRow.Cells[1].Value.ToString(),
                                String.Format("{0} {1}, {2} {3}, {4}, {5}",
                                DataGridView1.CurrentRow.Cells[3].Value.ToString().Trim(),
                                DataGridView1.CurrentRow.Cells[4].Value.ToString().Trim(),
                                DataGridView1.CurrentRow.Cells[5].Value.ToString().Trim(),
                                DataGridView1.CurrentRow.Cells[6].Value.ToString().Trim(),
                                DataGridView1.CurrentRow.Cells[7].Value.ToString().Trim(),
                                DataGridView1.CurrentRow.Cells[8].Value.ToString().Trim()),
                                currentBalance
                    );


                //solumCustomerCheckBox.Checked = (bool)DataGridView1.CurrentRow.Cells[20].Value;
                //quickDropCustomerCheckBox.Checked = (bool)DataGridView1.CurrentRow.Cells[21].Value;


                //if (solumCustomerCheckBox.Checked
                //    && quickDropCustomerCheckBox.Checked)
                //    f1.customerType = -1;    //both
                //else if (solumCustomerCheckBox.Checked)
                //    f1.customerType = 0;    //solum
                //else if (quickDropCustomerCheckBox.Checked)
                //    f1.customerType = 1;    //quickdrop

                if (DataGridView1.Columns[22].Visible)
                    f1.customerType = 0;    //solum
                else if (DataGridView1.Columns[23].Visible)
                    f1.customerType = 1;    //quickdrop

                f1.ShowDialog();
                f1.Dispose();
                f1 = null;

                //refresh
                this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);
                BindingSource1.Position = BindingSource1.Find("CustomerID", fieldId);

                ////balance
                //this.DataGridView1.CurrentRow.Cells[14].Value = f1.currentBalance;
                ////this.DataGridView1.CurrentRow.Cells[14] = f1.currentBalance;
            }
            else
                MessageBox.Show("Nothing to show!");


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (Cancel.Text == "&Close")
            {
                fieldId = -1;
                Close();
            }
            else if (Cancel.Text == "&Cancel")
            {
                //cancelar alta
                if (b_Accion == "agregar")
                {
                    ((BindingSource)this.DataGridView1.DataSource).RemoveCurrent();
                    try
                    {
                        this.DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Selected = true;
                    }
                    catch { }

                }

                b_Accion = "cancelar";
                OK.Text = "&Select";
                Cancel.Text = "&Close";
                cambiarVista();
            }


        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                return;

            b_Accion = "agregar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            //add row manually (AddNewItem = <none> in BindingNavigator)
            BindingSource1.AddNew();

            //valores por omision
            //province
            this.DataSet1.sol_Customers.Columns[7].DefaultValue = Main.Sol_ControlInfo.State;
            this.DataGridView1.CurrentRow.Cells[7].Value = Main.Sol_ControlInfo.State;
            //country
            this.DataSet1.sol_Customers.Columns[8].DefaultValue = Main.Sol_ControlInfo.Country;
            this.DataGridView1.CurrentRow.Cells[8].Value = Main.Sol_ControlInfo.Country;

            //isactive
            isActiveCheckBox.Checked = true;
            this.DataSet1.sol_Customers.Columns[12].DefaultValue = isActiveCheckBox.Checked;
            this.DataGridView1.CurrentRow.Cells[12].Value = isActiveCheckBox.Checked;
            //password
            this.DataSet1.sol_Customers.Columns[16].DefaultValue = String.Empty;
            this.DataGridView1.CurrentRow.Cells[16].Value = String.Empty;
            //depotId
            this.DataSet1.sol_Customers.Columns[17].DefaultValue = String.Empty;
            this.DataGridView1.CurrentRow.Cells[17].Value = String.Empty;
            //cardNumber
            this.DataSet1.sol_Customers.Columns[18].DefaultValue = String.Empty;
            this.DataGridView1.CurrentRow.Cells[18].Value = String.Empty;
            //cardTypeID
            this.DataSet1.sol_Customers.Columns[19].DefaultValue = 0;
            this.DataGridView1.CurrentRow.Cells[19].Value = 0;

            //CustomerType
            bool flag = false;
            if (customerType == 0)  //0 = solum, 1 = quickdrop 
            {
                flag = true; //true = solum false = quickdrop
            }
            //else //if(customerType == 2)
            //{
            //    this.DataSet1.sol_Customers.Columns[20].DefaultValue = false;
            //    this.DataGridView1.CurrentRow.Cells[20].Value = false;
            //    this.DataSet1.sol_Customers.Columns[21].DefaultValue = true;
            //    this.DataGridView1.CurrentRow.Cells[21].Value = true;
            //}

            this.DataSet1.sol_Customers.Columns[20].DefaultValue = flag;
            this.DataGridView1.CurrentRow.Cells[20].Value = flag;
            this.DataSet1.sol_Customers.Columns[21].DefaultValue = !flag;
            this.DataGridView1.CurrentRow.Cells[21].Value = !flag;

            //25 isNew
            //this.DataSet1.sol_Customers.Columns[25].DefaultValue = true; ;
            //this.DataGridView1.CurrentRow.Cells[25].Value = true;

            solumCustomerCheckBox.Checked = flag;
            quickDropCustomerCheckBox.Checked = !flag;

            this.Validate();

            cambiarVista();


        }

        private void cambiarVista()
        {
            switch (b_Accion)
            {
                case "agregar":
                    tableLayoutPanelGrid.Visible = false;
                    panelDetails.Visible = true;
                    break;
                case "actualizar":
                    tableLayoutPanelGrid.Visible = false;
                    panelDetails.Visible = true;
                    break;
                case "cancelar":
                    tableLayoutPanelGrid.Visible = true;
                    panelDetails.Visible = false;
                    break;
                default:
                    tableLayoutPanelGrid.Visible = true;
                    panelDetails.Visible = false;
                    break;
            }

            if (panelDetails.Visible)
            {
                //show select button for update
                OK.Visible = true;

                if (b_Accion == "agregar")
                {
                    bindingNavigatorMoveFirstItem.Enabled = false;
                    bindingNavigatorMovePreviousItem.Enabled = false;
                    bindingNavigatorPositionItem.Enabled = false;
                    bindingNavigatorMoveNextItem.Enabled = false;
                    bindingNavigatorMoveLastItem.Enabled = false;
                    bindingNavigatorAddNewItem.Enabled = false;
                    bindingNavigatorDeleteItem.Enabled = false;
                }
                else
                {
                    //bindingNavigatorMoveFirstItem.Enabled = flag;
                }
                BindingNavigatorSaveItem.Enabled = true;
                buttonDetails.Enabled = false;
                //buttonRefresh.Enabled = false;

                //fieldNameTextBox.Enabled = true;
                //panelDetails.Enabled = true;
                fieldNameTextBox.Focus();

                //if (fieldIDTextBox.Text == "0")
                //{
                //    //fieldNameTextBox.Enabled = false;
                //    panelDetails.Enabled = false;
                //}


                formerCardNumber = cardNumberTextBox.Text;

            }
            else
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                bindingNavigatorPositionItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
                bindingNavigatorMoveLastItem.Enabled = true;
                bindingNavigatorAddNewItem.Enabled = true;
                bindingNavigatorDeleteItem.Enabled = true;
                BindingNavigatorSaveItem.Enabled = false;
                buttonDetails.Enabled = true;
                //buttonRefrescar.Enabled = true;

                this.DataGridView1.Focus();

                //don't show select button in manage mode
                OK.Visible = !manageMode;

            }

            this.Validate();

            if (panelDetails.Visible)
            {



                //usb
                if (Main.CardReader_Enabled)
                {
                    Main.usbReadEventForm = "Customers";
                    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                    timer1.Enabled = true;
                }
            }
            else
            {
                if (Main.CardReader_Enabled)
                {
                    Main.usbReadEventForm = "";
                    this.timer1.Tick -= new System.EventHandler(this.timer1_Tick);
                    timer1.Enabled = false;
                }
            }

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                return;

            //empty datagrid
            if (this.DataGridView1.Rows.Count < 1)
                return;

            fieldId = (int)this.DataGridView1.CurrentRow.Cells[0].Value;
            if (fieldId == 0)
            {
                MessageBox.Show("Cannot delete this item!");
                return;
            }

            string descripcion = this.DataGridView1.CurrentRow.Cells[2].Value.ToString();

            //check for orders
            if (sol_Order_Sp == null)
                sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Sol_Order> sol_OrderList = sol_Order_Sp._SelectAllByCustomerID("", fieldId);
            if (sol_OrderList.Count() > 0)
            {
                MessageBox.Show("Cannot delete this customer because he has orders linked to.\r\nFirst delete all his orders and then try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(String.Format("Are you sure you want to delete this item: {0}?", descripcion), "Deleting Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.DataGridView1.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.DataGridView1.SelectedRows.Count > 0 &&
                            this.DataGridView1.SelectedRows[0].Index !=
                            this.DataGridView1.Rows.Count)
                        {
                            this.DataGridView1.Rows.RemoveAt(
                               this.DataGridView1.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.DataGridView1.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.BindingSource1.EndEdit();
                this.TableAdapterManager.UpdateAll(this.DataSet1);


                try
                {
                    this.DataGridView1.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }

        private void fieldNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            Funciones.ValidateText(sender, ref errorProvider1);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (this.DataGridView1.Rows.Count < 1)
                return;

            b_Accion = "actualizar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            cambiarVista();

        }

        private void fieldIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (fieldIDTextBox.Text == "0")
                panelDetails.Enabled = false;
            else
                panelDetails.Enabled = true;

        }

        private void DataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert) // && (e.Alt || e.Control || e.Shift))
            {
                //AgregarRegistro();
                bindingNavigatorAddNewItem.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete) // && (e.Alt || e.Control || e.Shift))
            {
                //EliminarRegistro();
                bindingNavigatorDeleteItem.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape) // && (e.Alt || e.Control || e.Shift))
            {
                Cancel.PerformClick();
            }
            //else if (e.KeyCode == Keys.Enter) 
            //{
            //    //OK.PerformClick();
            //}

        }

        private void quickDropCustomerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            panelQuickDrop.Enabled = quickDropCustomerCheckBox.Checked;

            if (quickDropCustomerCheckBox.Checked)
            {
                depotIDTextBox.Text = Main.QuickDrop_DepotID;
                //passwordTextBox.Validating += new System.ComponentModel.CancelEventHandler(textBox_Validating);
            }
            else
            {
                depotIDTextBox.Text = String.Empty;
                //passwordTextBox.Validating -= new System.ComponentModel.CancelEventHandler(textBox_Validating);
            }
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            Funciones.ValidateText(sender, ref errorProvider1);
        }

        private void DataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row =
            DataGridView1.Rows[e.RowIndex];

           // DataGridViewCell passCell =
           //row.Cells[DataGridView1Columns[16].Index];

            
            ////string pass = passCell.Value.ToString();
            //string pass = Funciones.DecodeFrom64(passCell.Value.ToString());
            ////string pass = Funciones.EncodeTo64(passCell.Value.ToString());
            ////passwordTextBox.Text = pass;
            //this.dataSetCustomers.sol_Customers.Columns["Password"].DefaultValue = pass;
            //this.DataGridView1.CurrentRow.Cells["Password"].Value = pass;


        }

        #region UsbHid Methods

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(Main.strMsrCardNumber))
                return;

            cardNumberTextBox.Text = String.Empty;

            timer1.Enabled = false;
            cardNumberTextBox.Text = Main.strMsrCardNumber;
            Main.strMsrCardNumber = String.Empty;
            timer1.Enabled = true;
        }

        #endregion

        private void fieldNameTextBox_Leave(object sender, EventArgs e)
        {
            if (b_Accion != "agregar")
                return;

            if (!String.IsNullOrEmpty(customerCodeTextBox.Text.Trim()))
                return;

            int l = fieldNameTextBox.Text.Length;
            if (l > 10) l = 10;
            customerCodeTextBox.Text = fieldNameTextBox.Text.Substring(0, l);

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDetails.PerformClick();
        }

        private void buttonSolum_Click(object sender, EventArgs e)
        {
            buttonSolum.BackColor = SystemColors.ButtonHighlight;
            buttonQuickDrop.BackColor = SystemColors.Control;

            customerType = 0;
            this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);

            //22- currentSolumBalance
            DataGridView1.Columns[22].Visible = true;
            //23- currentQuickDropBalance
            DataGridView1.Columns[23].Visible = false;


        }

        private void buttonQuickDrop_Click(object sender, EventArgs e)
        {
            buttonSolum.BackColor = SystemColors.Control;
            buttonQuickDrop.BackColor = SystemColors.ButtonHighlight;

            customerType = 1;
            this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);

            //22- currentSolumBalance
            DataGridView1.Columns[22].Visible = false;
            //23- currentQuickDropBalance
            DataGridView1.Columns[23].Visible = true;

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);

        }

        private void toolStripButtonInactives_Click(object sender, EventArgs e)
        {

            if (activeType == 0) //inactives
            {
                toolStripButtonInactives.Text = "Inactives";
                toolStripButtonInactives.ToolTipText = "Show Inactive Customers";
                toolStripButtonInactives.Image = Properties.Resources.PeopleInActive;
                activeType = 1;
            }
            else if (activeType == 1) //actives
            {
                toolStripButtonInactives.Text = "Actives";
                toolStripButtonInactives.ToolTipText = "Show Active Customers";
                toolStripButtonInactives.Image = Properties.Resources.PeopleActive;
                activeType = 0;
            }

            this.TableAdapter1.Fill(this.DataSet1.sol_Customers, customerType, textBoxName.Text, activeType);
        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {
            string pass = string.Empty;
            try
            {
                pass = Funciones.DecodeFrom64(DataGridView1.CurrentRow.Cells[16].Value.ToString());
            }
            catch { }

            CustomersRetypePass f1 = new CustomersRetypePass();
            f1.password = pass;
            f1.ShowDialog();
            bool cancel = f1.cancel;
            f1.Dispose();
            f1 = null;

            if (!cancel)
            {
                try
                {
                    pass = Funciones.EncodeTo64(f1.password);
                }
                catch
                {
                    MessageBox.Show("Error setting Password, try another please!");
                    return;
                }


                this.DataSet1.sol_Customers.Columns["Password"].DefaultValue = pass;
                this.DataGridView1.CurrentRow.Cells[16].Value = pass;
            }



            //if (quickDropCustomerCheckBox.Checked)
            //{
            //    string pass = DataGridView1.CurrentRow.Cells[16].Value.ToString();
            //    try
            //    {
            //        pass = Funciones.DecodeFrom64(pass);
            //    }
            //    catch { }
            //    passwordTextBox.Text = pass;
            //    formerPass = pass;
            //}


        }

    }
}

