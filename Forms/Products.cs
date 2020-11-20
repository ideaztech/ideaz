
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
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


namespace Solum
{
    public partial class Products : Form
    {
        private bool b_Add = false;
        private long m_lImageFileLength = 0;
        private byte[] m_barrImg;

        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCategoriesLookup.Sol_Categories' table. You can move, or remove it, as needed.
            this.sol_CategoriesTableAdapter.Fill(this.dataSetCategoriesLookup.Sol_Categories);
            // TODO: This line of code loads data into the 'dataSetCategories.Sol_Categories' table. You can move, or remove it, as needed.
            //this.Sol_CategoriesTableAdapter1.Fill(this.dataSetCategories.Sol_Categories);

            if (Properties.Settings.Default.StagingType != 0)   //Properties.Settings.Default.MultiProductStagingEnabled)
            {
                panelMultiProductStaging.Visible = true;
                this.sol_ProductsTableAdapter.Fill(this.dataSetProductsLookup.sol_Products, 0);
            }

            // TODO: This line of code loads data into the 'dataSetAgenciesLookup.sol_Agencies' table. You can move, or remove it, as needed.
            this.sol_AgenciesTableAdapter.Fill(this.dataSetAgenciesLookup.sol_Agencies);
            // TODO: This line of code loads data into the 'dataSetStandardDozenLookup.sol_StandardDozen' table. You can move, or remove it, as needed.
            this.sol_StandardDozenTableAdapter.Fill(this.dataSetStandardDozenLookup.sol_StandardDozen);
            // TODO: This line of code loads data into the 'dataSetStandardDozenLookup.sol_StandardDozen' table. You can move, or remove it, as needed.
            this.sol_StandardDozenTableAdapter.Fill(this.dataSetStandardDozenLookup.sol_StandardDozen);
            // TODO: This line of code loads data into the 'dataSetContainersLookup.sol_Containers' table. You can move, or remove it, as needed.
            //this.sol_ContainersTableAdapter.Fill(this.dataSetContainersLookup.sol_Containers);
            this.sol_ContainersTableAdapter.FillByType(this.dataSetContainersLookup.sol_Containers, 1); //1 = shipping containers

            // TODO: This line of code loads data into the 'dataSetTypesLookup.sol_Types' table. You can move, or remove it, as needed.
            //this.sol_Products_SelectAllTableAdapter.Fill(this.dataSetProducts.sol_Products_SelectAll);
            comboBoxType.SelectedIndex = 0;

            productTypeBindingSource.DataSource = Main.productsType;


            // TODO: This line of code loads data into the 'dataSetTypes.sol_Types_SelectAll' table. You can move, or remove it, as needed.
            if (Properties.Settings.Default.TouchOriented)
            {
                this.Height = this.Height + (OK.Height) + 150;
                OK.Height = OK.Height * 2;
                buttonDetails.Height = buttonDetails.Height * 2;
                buttonClose.Height = buttonClose.Height * 2;

                buttonBrowse.Height = buttonClose.Height;
                buttonRemoveImage.Height = buttonClose.Height;

                //Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
            }
            else
            {
                int tamano = 16;
                sol_Products_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_Products_SelectAllBindingNavigator.Size = new System.Drawing.Size(sol_Products_SelectAllBindingNavigator.Size.Width, tamano + 7);
                sol_Products_SelectAllBindingNavigator.Stretch = false;

            }
            this.CenterToParent();

            this.sol_Products_SelectAllTableAdapter.Fill(this.dataSetProducts.sol_Products_SelectAll);

            //bloquear  columnas
            sol_Products_SelectAllDataGridView.ReadOnly = true;
            short indice = 0;
            //0 @ProductID int,
            sol_Products_SelectAllDataGridView.Columns[indice].HeaderText = "Id";
            sol_Products_SelectAllDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            sol_Products_SelectAllDataGridView.Columns[indice].Width = 80;
            indice++;
            //1 @ProName varchar(50),
            sol_Products_SelectAllDataGridView.Columns[indice].HeaderText = "Name";
            sol_Products_SelectAllDataGridView.Columns[indice].Width = 200;
            indice++;
            //2 @ProDescription varchar(50),
            sol_Products_SelectAllDataGridView.Columns[indice].HeaderText = "Description";
            sol_Products_SelectAllDataGridView.Columns[indice].Width = 300;
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //3 @ProShortDescription varchar(50),
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //4 @ProImage image,
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //5 @MenuOrder int,
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //6 @IsActive bit,
            sol_Products_SelectAllDataGridView.Columns[indice].Width = 90;
            //sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //7 [CategoryID] [int] NULL,
            sol_Products_SelectAllDataGridView.Columns[indice].HeaderText = "Category";
            sol_Products_SelectAllDataGridView.Columns[indice].Width = 300;
            //sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //8 [CommissionUnit] [int] NULL,
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //9 [FeeUnit] [int] NULL,
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //10 [ContainerID] [int] NULL,
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //11 [StandardDozenID] [int] NULL,
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //12 @AgencyID int,
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //13 uPC;
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //14 productCode;
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //15 @Price decimal(53)
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //16 [RefundAmount] [decimal] NULL, /* readonly, from Sol_Categories */
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //17 [HandlingCommissionAmount] [decimalfloat] NULL, 
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;
            //18 [VafAmount] [decimal] NULL, 
            sol_Products_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;

            panelDetails.Controls["tax1ExemptLabel"].Text = panelDetails.Controls["tax1ExemptLabel"].Text.Replace("Tax1", Main.Sol_ControlInfo.Tax1Name.Trim() + " ");
            if(String.IsNullOrEmpty(Main.Sol_ControlInfo.Tax2Name.Trim()))
            {
                panelDetails.Controls["tax2ExemptLabel"].Visible = false;
                panelDetails.Controls["tax2ExemptCheckBox"].Visible = false;
            }
            else
                panelDetails.Controls["tax2ExemptLabel"].Text = panelDetails.Controls["tax2ExemptLabel"].Text.Replace("Tax2", Main.Sol_ControlInfo.Tax2Name.Trim() + " ");


            
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (b_Add)
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                    return;
            }
            else
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                    return;
            }

            bool flag = panelDetails.Visible;
            if (flag)
            {
                if (!ValidateForm())
                    return;

                cambiarVista();
            }

            ////hay cambios?
            //if (dataSetProducts.HasChanges())
            //{

            this.Validate();
            this.sol_Products_SelectAllBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dataSetProducts);
            try
            {
                this.tableAdapterManager.UpdateAll(this.dataSetProducts);
                //if (Convert.ToInt32(productIDTextBox.Text) < 0)
                if (b_Add)
                {
                    b_Add = false; 
                    this.sol_Products_SelectAllTableAdapter.Fill(this.dataSetProducts.sol_Products_SelectAll);
                    this.sol_Products_SelectAllBindingSource.MoveLast();
                }
            }
            catch
            {
                //
            }

            //}
            if (!flag)
                Close();

        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            bool flag = panelDetails.Visible;
            if (flag)
                this.sol_Products_SelectAllDataGridView.CancelEdit();
            else
            {
                this.sol_Products_SelectAllDataGridView.ReadOnly = false;
                this.sol_Products_SelectAllDataGridView.BeginEdit(true);


            }

            //datagrid vacia
            if (sol_Products_SelectAllDataGridView.Rows.Count <= 1)
                return;

            ////cell vacia
            //string c = sol_Products_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();
            //if (String.IsNullOrEmpty(sol_Products_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString()))
            //    return;

            cambiarVista();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //bool flag = panelDetails.Visible;
            //if (flag)
            //{
            //    cambiarVista();
            //    if (Convert.ToInt32(productIDTextBox.Text) < 0)
            //        bindingNavigatorDeleteItem.PerformClick();
            //}
            //else
            Close();

        }

        private void Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.dataSetProducts.HasChanges())
            //{
            //    DialogResult result = MessageBox.Show("There are uncommitted changes, do you wish to continue?", "", MessageBoxButtons.YesNo);
            //    if (result == System.Windows.Forms.DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            bool flag = panelDetails.Visible;
            if (flag)
            {
                cambiarVista();

                //if (Convert.ToInt32(productIDTextBox.Text) < 0)
                if (b_Add)
                {
                    b_Add = false;
                    bindingNavigatorDeleteItem.PerformClick();
                }
                e.Cancel = true;
                return;
            }

            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                return;

            b_Add = true;

            //add row manually (AddNewItem = <none> in BindingNavigator)
            sol_Products_SelectAllBindingSource.AddNew();

            //valores por omision
            //Agencyid
            //isactive
            //value

            dataSetProducts.sol_Products_SelectAll.Columns["AgencyID"].DefaultValue = 0;    //5
            dataSetProducts.sol_Products_SelectAll.Columns["IsActive"].DefaultValue = true;         //7
            dataSetProducts.sol_Products_SelectAll.Columns["Price"].DefaultValue = 0.0m;            //8
            dataSetProducts.sol_Products_SelectAll.Columns["CategoryID"].DefaultValue = 0;             //9
            dataSetProducts.sol_Products_SelectAll.Columns["ContainerID"].DefaultValue = 0;            //15
            dataSetProducts.sol_Products_SelectAll.Columns["StandardDozenID"].DefaultValue = 0;            //16
            dataSetProducts.sol_Products_SelectAll.Columns["TargetQuantity"].DefaultValue = 0;
            dataSetProducts.sol_Products_SelectAll.Columns["HandlingCommissionAmount"].DefaultValue = (decimal)0.0;     
            dataSetProducts.sol_Products_SelectAll.Columns["VafAmount"].DefaultValue = (decimal)0.0;

            sol_Products_SelectAllDataGridView.CurrentRow.Cells[16].Value = 0;           //5
            sol_Products_SelectAllDataGridView.CurrentRow.Cells[6].Value = true;       //7
            sol_Products_SelectAllDataGridView.CurrentRow.Cells[7].Value = 0.0m;          //8

            sol_Products_SelectAllDataGridView.CurrentRow.Cells[17].Value = 0.0m;           
            sol_Products_SelectAllDataGridView.CurrentRow.Cells[18].Value = 0.0m;           

            sol_Products_SelectAllDataGridView.CurrentRow.Cells[8].Value = 0;           //9
            sol_Products_SelectAllDataGridView.CurrentRow.Cells[14].Value = 0;          //15
            sol_Products_SelectAllDataGridView.CurrentRow.Cells[15].Value = 0;          //16


            //desable type if neccesary
            int index = comboBoxType.SelectedIndex;
            if (index > 0)
            {
                index--;
                sol_Products_SelectAllDataGridView.CurrentRow.Cells[19].Value = index;          //typeid
                typeIdComboBox.SelectedIndex = index;
                typeIdComboBox.Enabled = false;
            }
            else
                sol_Products_SelectAllDataGridView.CurrentRow.Cells[19].Value = 0;          //typeid



            agencyIDComboBox.SelectedIndex = 0;
            categoryIDComboBox.SelectedIndex = 0;
            containerIDComboBox.SelectedIndex = 0;
            standardDozenIDComboBox.SelectedIndex = 0;
            isActiveCheckBox.Checked = false;
            priceTextBox.Text = "";
            
            this.Validate();

            cambiarVista();

        }

        private void sol_Products_SelectAllBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (b_Add)
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                    return;
            }
            else
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                    return;
            }


            if (!panelDetails.Visible)
                return;

            //if (!ValidateForm())
            //    return;

            this.Validate();
            this.sol_Products_SelectAllBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetProducts);

            cambiarVista();



        }

        private void sol_Products_SelectAllDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDetails.PerformClick();

        }

        private void sol_Products_SelectAllDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //esta funcion es para que si hay error no salga la ventana de error
            //e.Cancel = true;

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

        private void cambiarVista()
        {
            bool flag = false;
            if (panelDetails.Visible)
            {
                buttonDetails.Text = "&Details";
                flag = true;


            }
            else
            {
                buttonDetails.Text = "&Products";
                //solo si no es una alta
                try
                {
                    if(b_Add)
                    {
                        bindingNavigatorMoveFirstItem.Enabled = flag;
                        bindingNavigatorMovePreviousItem.Enabled = flag;
                        bindingNavigatorPositionItem.Enabled = flag;
                        bindingNavigatorMoveNextItem.Enabled = flag;
                        bindingNavigatorMoveLastItem.Enabled = flag;
                    }
                }
                catch
                {
                    //
                }

                //disable type if neccesary
                if (comboBoxType.SelectedIndex > 0)
                {
                    //typeIdComboBox.SelectedValue = comboBoxType.SelectedIndex - 1;
                    typeIdComboBox.Enabled = false;
                }

            }

            bindingNavigatorAddNewItem.Enabled = flag;
            bindingNavigatorDeleteItem.Enabled = flag;

            panelGeneral.Visible = !panelGeneral.Visible;
            panelDetails.Visible = !panelDetails.Visible;

            if (panelGeneral.Visible)
                sol_Products_SelectAllDataGridView.Focus();
            else
                proNameTextBox.Focus();


            this.Validate();
        }

        private void proNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateText(sender);

        }

        private void priceTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateAmount("price");
        }

        private void handlingCommissionAmountTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateAmount("hc");

        }

        private void vafAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateAmount("vaf");

        }

        private bool ValidateForm()
        {
            bool flagError = false;
            ArrayList cajasDeTexto = new ArrayList();

            cajasDeTexto.Add(proNameTextBox);
            //cajasDeTexto.Add(proDescriptionTextBox);
            cajasDeTexto.Add(uPCTextBox);
            cajasDeTexto.Add(productCodeTextBox);

            bool bValidText = false;
            foreach (object tb in cajasDeTexto)
            {
                bValidText = ValidateText(tb);
            }


            bool bValidPrice = ValidateAmount("price");
            bool bValidHC = ValidateAmount("hc");
            bool bValidVAF = ValidateAmount("vaf");
            //if (bValidIsActive && bValidValue)
            if (bValidText && bValidPrice && bValidHC && bValidVAF)
                flagError = true;
            //else
            //    MessageBox.Show("Please enter valid data");

            return flagError;
        }


        private bool ValidateText(object sender)
        {
            bool flagError = false;
            TextBox tBox = (TextBox)sender;


            if (String.IsNullOrEmpty(tBox.Text))
                errorProvider1.SetError(tBox, "Please enter information.");
            else
            {
                errorProvider1.SetError(tBox, "");
                flagError = true;
            }


            return flagError;
        }

        private bool ValidateAmount(string name)
        {
            bool flagError = false;
            try
            {
                switch(name)
                {
                    case "price":
                        Decimal.Parse(priceTextBox.Text);
                        errorProvider1.SetError(priceTextBox, "");
                        flagError = true;
                        break;
                    case "hc":
                        Decimal.Parse(handlingCommissionAmountTextBox.Text);
                        errorProvider1.SetError(handlingCommissionAmountTextBox, "");
                        flagError = true;
                        break;
                    case "vaf":
                        Decimal.Parse(vafAmountTextBox.Text);
                        errorProvider1.SetError(vafAmountTextBox, "");
                        flagError = true;
                        break;
                    default:
                        break;
                }
            }
            catch //(Exception ex)
            {
                switch(name)
                {
                    case "price":
                        errorProvider1.SetError(priceTextBox, "Please enter a valid Price amount.");
                        break;
                    case "hc":
                        errorProvider1.SetError(handlingCommissionAmountTextBox, "Please enter a valid Comission amount.");
                        break;
                    case "vaf":
                        errorProvider1.SetError(vafAmountTextBox, "Please enter a valid VAF amount.");
                        break;
                    default:
                        break;
                }
            }


            return flagError;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        protected void LoadImage()
        {

            try
            {
                this.openFileDialog1.ShowDialog(this);
                string strFn = this.openFileDialog1.FileName;
                this.proImagePictureBox.Image = Image.FromFile(strFn);
                FileInfo fiImage = new FileInfo(strFn);
                this.m_lImageFileLength = fiImage.Length;
                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                m_barrImg = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(this.m_lImageFileLength));
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRemoveImage_Click(object sender, EventArgs e)
        {
            if (this.proImagePictureBox.Image != null)
                this.proImagePictureBox.Image = null;

        }

        private void sol_Products_SelectAllDataGridView_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            buttonDetails.PerformClick();
        }

        private void typeIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = true;
            if (typeIdComboBox.SelectedIndex == 0)
            {
                flag = false;
                categoryIDComboBox.Enabled = true;
                menuOrderTextBox.Enabled = true;
                handlingCommissionAmountTextBox.Enabled = true;
                vafAmountTextBox.Enabled = true;
                agencyIDComboBox.Enabled = true;
                containerIDComboBox.Enabled = true;
                standardDozenIDComboBox.Enabled = true;
            }
            else if (typeIdComboBox.SelectedIndex == 1)
            {
                categoryIDComboBox.Enabled = false;
                menuOrderTextBox.Enabled = false;
                handlingCommissionAmountTextBox.Enabled = false;
                vafAmountTextBox.Enabled = false;
                agencyIDComboBox.Enabled = false;
                containerIDComboBox.Enabled = false;
                standardDozenIDComboBox.Enabled = false;

                agencyIDComboBox.SelectedIndex = 0;
                categoryIDComboBox.SelectedIndex = 0;
                containerIDComboBox.SelectedIndex = 0;
                standardDozenIDComboBox.SelectedIndex = 0;

            }

            panelDetails.Controls["tax1ExemptLabel"].Visible = flag;
            panelDetails.Controls["tax1ExemptCheckBox"].Visible = flag;

            if (String.IsNullOrEmpty(Main.Sol_ControlInfo.Tax2Name.Trim()))
            {
                panelDetails.Controls["tax2ExemptLabel"].Visible = false;
                panelDetails.Controls["tax2ExemptCheckBox"].Visible = false;
            }
            else
            {
                panelDetails.Controls["tax2ExemptLabel"].Visible = flag;
                panelDetails.Controls["tax2ExemptCheckBox"].Visible = flag;
            }


        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex > 0)
            {
                byte index = (byte)(comboBoxType.SelectedIndex - 1);
                this.sol_Products_SelectAllTableAdapter.FillByType(this.dataSetProducts.sol_Products_SelectAll, index);
            }
            else
                this.sol_Products_SelectAllTableAdapter.Fill(this.dataSetProducts.sol_Products_SelectAll);


        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                return;

            //empty datagrid
            if (this.sol_Products_SelectAllDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.sol_Products_SelectAllDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.sol_Products_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", descripcion), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.sol_Products_SelectAllDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.sol_Products_SelectAllDataGridView.SelectedRows.Count > 0 &&
                            this.sol_Products_SelectAllDataGridView.SelectedRows[0].Index !=
                            this.sol_Products_SelectAllDataGridView.Rows.Count)
                        {
                            this.sol_Products_SelectAllDataGridView.Rows.RemoveAt(
                               this.sol_Products_SelectAllDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.sol_Products_SelectAllDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.sol_Products_SelectAllDataGridView.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dataSetProducts);


                try
                {
                    this.sol_Products_SelectAllDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }


    }
}
