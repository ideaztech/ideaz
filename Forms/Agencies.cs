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
    public partial class Agencies : Form
    {
        int intValue = 0;
        Sol_AutoNumber sol_AutoNumber;
        Sol_AutoNumber_Sp sol_AutoNumber_Sp;

        private bool b_Add = false;

        public Agencies()
        {
            InitializeComponent();
        }

        private void Agencies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetAgencies.sol_Agencies' table. You can move, or remove it, as needed.
            this.sol_AgenciesTableAdapter.Fill(this.dataSetAgencies.sol_Agencies);

            this.Width = Main.ActiveForm.Width - 50;
            
            this.Height = Main.ActiveForm.Height - 50;

          //  if (Properties.Settings.Default.TouchOriented)
            //{
                //this.Height = this.Height + (OK.Height) + 150;
                //OK.Height = OK.Height * 2;
                //buttonDetails.Height = buttonDetails.Height * 2;

                //Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
                this.CenterToParent();

            //}
            /*else
            {
                int tamano = 16;
                sol_AgenciesBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_AgenciesBindingNavigator.Size = new System.Drawing.Size(sol_AgenciesBindingNavigator.Size.Width, tamano + 7);
                sol_AgenciesBindingNavigator.Stretch = false;

            }*/


            //bloquear  columnas
            sol_AgenciesDataGridView.ReadOnly = true;

            short indice = 0;
            //agencyID;
            sol_AgenciesDataGridView.Columns[indice].HeaderText = "Id";
            sol_AgenciesDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            sol_AgenciesDataGridView.Columns[indice].Width = 80;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //name
            sol_AgenciesDataGridView.Columns[indice].HeaderText = "Name";
            sol_AgenciesDataGridView.Columns[indice].Width = 200;
            //sol_AgenciesDataGridView.Columns[indice].Width = splitContainer1.Width / 3;
            indice++;
            //description;
            sol_AgenciesDataGridView.Columns[indice].HeaderText = "Description";
            sol_AgenciesDataGridView.Columns[indice].Width = 350;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;

            //address1;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //address2;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //city;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //province;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //country;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //postalCode;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //VendorID;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //AutogenerateTagNumber;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;
            //AutogenerateRBillNumber;
            sol_AgenciesDataGridView.Columns[indice].Visible = false;
            indice++;

            sol_AgenciesBindingNavigator.Renderer = new App_Code.NewToolStripRenderer();

            sol_AgenciesDataGridView.Width = splitContainer1.Width / 3;
            sol_AgenciesDataGridView.Columns[1].Width = sol_AgenciesDataGridView.Width;
            panelDetails.Width = splitContainer1.Width - sol_AgenciesDataGridView.Width;

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

            //bool flag = panelDetails.Visible;
            /*if (flag)
            {
                if (!ValidateForm())
                    return;

                cambiarVista();
            }*/

            ////hay cambios?
            //if (dataSetProducts.HasChanges())
            //{
            this.Validate();
            this.sol_AgenciesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetAgencies);
            try
            {
                //if (Convert.ToInt32(productIDTextBox.Text) < 0)
                if (b_Add)
                {
                    b_Add = false;
                    this.sol_AgenciesTableAdapter.Fill(this.dataSetAgencies.sol_Agencies);
                    this.sol_AgenciesBindingSource.MoveLast();
                }
                else
                {
                    intValue = 0;
                    int.TryParse(agencyIDTextBox.Text, out intValue);
                    if (sol_AutoNumber_Sp == null)
                        sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    if (sol_AutoNumber == null)
                    {
                        sol_AutoNumber = new Sol_AutoNumber();
                        sol_AutoNumber.AgencyID = intValue;
                        sol_AutoNumber.FolioID = 1;
                        sol_AutoNumber.TagNumber = 0;
                        sol_AutoNumber.RBillNumber = 0;
                        sol_AutoNumber_Sp.Insert(sol_AutoNumber);

                    }

                    intValue = 0;
                    int.TryParse(textBoxTagNumber.Text, out intValue);
                    sol_AutoNumber.TagNumber = intValue;

                    intValue = 0;
                    int.TryParse(textBoxRBillNumber.Text, out intValue);
                    sol_AutoNumber.RBillNumber = intValue;

                    sol_AutoNumber_Sp.Update(sol_AutoNumber);

                    //Main.Sol_ControlInfo.AutoGenerateTagNumber = checkBoxAutoTagNumber.Checked;
                    //Main.Sol_ControlInfo.AutoGenerateRBillNumber = checkBoxAutoRBillNumber.Checked;

                }

            }
            catch
            {
                //
            }

            //}
            //if (!flag)
                Close();


        }


        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (sol_AgenciesDataGridView.Rows.Count <= 1)
                return;

           // cambiarVista();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Agencies_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.dataSetAgencies.HasChanges())
            //{
            //    DialogResult result = MessageBox.Show("There are uncommitted changes, do you wish to continue?", "", MessageBoxButtons.YesNo);
            //    if (result == System.Windows.Forms.DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            /*
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
            }*/

            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                return;

            b_Add = true;

            //add row manually (AddNewItem = <none> in BindingNavigator)
            sol_AgenciesBindingSource.AddNew();

            ////valores por omision
            //this.dataSetAgencies.sol_Agencies.Columns[11].DefaultValue = false;
            ////isactive
            //this.sol_AgenciesDataGridView.CurrentRow.Cells[11].Value = false;

            //AutogenerateTagNumber;
            this.dataSetAgencies.sol_Agencies.Columns[10].DefaultValue = false;
            this.sol_AgenciesDataGridView.CurrentRow.Cells[10].Value = false;

            //AutogenerateRBillNumber;
            this.dataSetAgencies.sol_Agencies.Columns[11].DefaultValue = false;
            this.sol_AgenciesDataGridView.CurrentRow.Cells[11].Value = false;


            this.Validate();

            cambiarVista();

        }

        private void sol_AgenciesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if(b_Add)
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                    return;
            }
            else
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                return;
            }


            if (!ValidateForm())
                return;

            this.Validate();
            this.sol_AgenciesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetAgencies);

            cambiarVista();

        }

        private void sol_AgenciesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDetails.PerformClick();

        }

        private void sol_AgenciesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
                buttonDetails.Text = "&Agencies";
                //solo si no es una alta
                try
                {
                    if (b_Add)
                    {
                        bindingNavigatorMoveFirstItem.Enabled = flag;
                        bindingNavigatorMovePreviousItem.Enabled = flag;
                        bindingNavigatorPositionItem.Enabled = flag;
                        bindingNavigatorMoveNextItem.Enabled = flag;
                        bindingNavigatorMoveLastItem.Enabled = flag;
                    }
                    else
                    {
                        //ReadAutoGeneratedNumbers();

                    }
                }
                catch
                {
                    //
                }
            }

            bindingNavigatorAddNewItem.Enabled = flag;
            bindingNavigatorDeleteItem.Enabled = flag;

            sol_AgenciesDataGridView.Visible = !sol_AgenciesDataGridView.Visible;
            panelDetails.Visible = !panelDetails.Visible;

            if (sol_AgenciesDataGridView.Visible)
                sol_AgenciesDataGridView.Focus();
            else
                nameTextBox.Focus();


            this.Validate();
        }

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateText(sender);

        }

        private bool ValidateForm()
        {
            bool flagError = false;
            ArrayList cajasDeTexto = new ArrayList();


            cajasDeTexto.Add(nameTextBox);

            bool bValidText = false;
            foreach (object tb in cajasDeTexto)
            {
                bValidText = ValidateText(tb);

                //if (!bValidText)
                //    break;
            }

            if (bValidText) // && bValidValue)
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

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                return;

            //empty datagrid
            if (this.sol_AgenciesDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.sol_AgenciesDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.sol_AgenciesDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", descripcion), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.sol_AgenciesDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.sol_AgenciesDataGridView.SelectedRows.Count > 0 &&
                            this.sol_AgenciesDataGridView.SelectedRows[0].Index !=
                            this.sol_AgenciesDataGridView.Rows.Count)
                        {
                            this.sol_AgenciesDataGridView.Rows.RemoveAt(
                               this.sol_AgenciesDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.sol_AgenciesDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.sol_AgenciesDataGridView.EndEdit();
                try
                {
                    this.tableAdapterManager.UpdateAll(this.dataSetAgencies);
                }
                catch
                {
                    MessageBox.Show("Can not delete row, maybe it is referenced by another row");
                    return;
                }


                try
                {
                    this.sol_AgenciesDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }

        }

        private void autoGenerateTagNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTagNumber.Enabled = ((CheckBox)sender).Checked;

        }

        private void autoGenerateRBillNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            textBoxRBillNumber.Enabled = ((CheckBox)sender).Checked;

        }

        private void agencyIDTextBox_TextChanged(object sender, EventArgs e)
        {
            ReadAutoGeneratedNumbers();
        }

        private void ReadAutoGeneratedNumbers()
        {
            intValue = 0;
            int.TryParse(agencyIDTextBox.Text, out intValue);

            sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_AutoNumber = sol_AutoNumber_Sp.Select(intValue, 1);
            if (sol_AutoNumber == null)
            {
                sol_AutoNumber = new Sol_AutoNumber();
                sol_AutoNumber.AgencyID = intValue;
                sol_AutoNumber.FolioID = 1;
                sol_AutoNumber.TagNumber = 0;
                sol_AutoNumber.RBillNumber = 0;
                sol_AutoNumber_Sp.Insert(sol_AutoNumber);

            }

            //checkBoxAutoTagNumber.Checked = Main.Sol_ControlInfo.AutoGenerateTagNumber;
            textBoxTagNumber.Text = sol_AutoNumber.TagNumber.ToString();

            //checkBoxAutoRBillNumber.Checked = Main.Sol_ControlInfo.AutoGenerateRBillNumber;
            textBoxRBillNumber.Text = sol_AutoNumber.RBillNumber.ToString();


        }
    }
}
