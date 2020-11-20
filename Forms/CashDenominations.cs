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
    public partial class CashDenominations : Form
    {
        private string b_Accion = "";

        public CashDenominations()
        {
            InitializeComponent();
        }

        private void CashDenominations_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetMoney.Sac_Money' table. You can move, or remove it, as needed.
            this.sac_MoneyTableAdapter.Fill(this.dataSetMoney.Sac_Money);
            // TODO: This line of code loads data into the 'dataSetCashDenominations.sol_CashDenominations_SelectAll' table. You can move, or remove it, as needed.
            CashDenominationsTypeBindingSource.DataSource = Main.cashDenominationsType;

            this.sol_CashDenominations_SelectAllTableAdapter.Fill(this.dataSetCashDenominations.sol_CashDenominations_SelectAll);

            this.Width = Main.ActiveForm.Width - 50;
            this.Height = Main.ActiveForm.Height - 50;
            //this.Size = Main.ActiveForm.Size;
            sol_CashDenominations_SelectAllBindingNavigator.Renderer = new App_Code.NewToolStripRenderer();

            //if (Properties.Settings.Default.TouchOriented)
            //{
                //this.Height = this.Height + (OK.Height) + 150;
                //OK.Height = OK.Height * 2;
                //Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
                this.CenterToParent();

            //}
           // else
           // {
            //    int tamano = 16;
            //    sol_CashDenominations_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
            //    sol_CashDenominations_SelectAllBindingNavigator.Size = new System.Drawing.Size(sol_CashDenominations_SelectAllBindingNavigator.Size.Width, tamano + 7);
            //    sol_CashDenominations_SelectAllBindingNavigator.Stretch = false;
//
            //}



            //bloquear  columnas
            short indice = 0;
            //id
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "Id";
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].ReadOnly = true;
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 50;
            indice++;
            //type
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "Type";
            //sol_CashDenominations_SelectAllDataGridView.Columns[indice].ReadOnly = true;
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 100;
            indice++;
            //value
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "Value";
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 80;
            indice++;
            //description
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "Description";
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 200;
            indice++;
            //orderValue
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "Order";
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 80;
            indice++;
            //CashItemValue
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "Item Value";
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 80;
            indice++;
            //Quantity
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "Quantity";
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 80;
            indice++;
            //MoneyID
            //sol_CashDenominations_SelectAllDataGridView.Columns[indice].HeaderText = "SAC Money";
            //sol_CashDenominations_SelectAllDataGridView.Columns[indice].Width = 200;
            sol_CashDenominations_SelectAllDataGridView.Columns[indice].Visible = false;
            indice++;

            if (sol_CashDenominations_SelectAllDataGridView.Width > 290)
                sol_CashDenominations_SelectAllDataGridView.Columns[3].Width = sol_CashDenominations_SelectAllDataGridView.Width - 470;


        }

        private void OK_Click(object sender, EventArgs e)
        {
            sol_CashDenominations_SelectAllBindingNavigatorSaveItem.PerformClick();
            //Close();
        }

        private void sol_CashDenominations_SelectAllBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            //first row
            string c = this.sol_CashDenominations_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();
            if (String.IsNullOrEmpty(c))
            {
                MessageBox.Show("Please enter data for row");
                return;
            }


            this.Validate();
            this.sol_CashDenominations_SelectAllBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetCashDenominations);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.sol_CashDenominations_SelectAllTableAdapter.Fill(this.dataSetCashDenominations.sol_CashDenominations_SelectAll);
                    this.sol_CashDenominations_SelectAllBindingSource.MoveLast();
                    bindingNavigatorDeleteItem.Enabled = true;
                    bindingNavigatorAddNewItem.Enabled = true;

                }
            }
            catch
            {
                //
            }

            b_Accion = "";

            //cambiarVista();



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

        private void CashDenominations_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.dataSetCashDenominations.HasChanges())
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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                return;

            b_Accion = "agregar";

            //add row manually (AddNewItem = <none> in BindingNavigator)
            sol_CashDenominations_SelectAllBindingSource.AddNew();

            //valores por omision
            //short indice = 3;

            //containerType
            //this.dataSetStandardDozenLookup.sol_Containers.Columns[indice].DefaultValue = 1;
            //this.sol_CashDenominations_SelectAllDataGridView.CurrentRow.Cells[indice++].Value = 1;

            this.Validate();

            //cambiarVista();

            bindingNavigatorAddNewItem.Enabled = false;
            bindingNavigatorDeleteItem.Enabled = false;

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                return;

            //empty datagrid
            if (this.sol_CashDenominations_SelectAllDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.sol_CashDenominations_SelectAllDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.sol_CashDenominations_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", id), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.sol_CashDenominations_SelectAllDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.sol_CashDenominations_SelectAllDataGridView.SelectedRows.Count > 0 &&
                            this.sol_CashDenominations_SelectAllDataGridView.SelectedRows[0].Index !=
                            this.sol_CashDenominations_SelectAllDataGridView.Rows.Count)
                        {
                            this.sol_CashDenominations_SelectAllDataGridView.Rows.RemoveAt(
                               this.sol_CashDenominations_SelectAllDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.sol_CashDenominations_SelectAllDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.sol_CashDenominations_SelectAllDataGridView.EndEdit();
                try
                {
                    this.tableAdapterManager.UpdateAll(this.dataSetCashDenominations);
                }
                catch
                {
                    MessageBox.Show("Cannot delete this row, it has a reference");
                }

                try
                {
                    this.sol_CashDenominations_SelectAllDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }

        private void sol_CashDenominations_SelectAllDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
        }

        //calculate cell (quantity)
        private void sol_CashDenominations_SelectAllDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = sol_CashDenominations_SelectAllDataGridView.Rows[e.RowIndex];
                try
                {
                    decimal cashValue = 0;
                    decimal.TryParse(row.Cells[2].Value.ToString(), out cashValue);
                    decimal cashItemValue = 1;
                    decimal.TryParse(row.Cells[5].Value.ToString(), out cashItemValue);

                    if (cashItemValue > 0)
                        row.Cells[6].Value = cashValue / cashItemValue;
                }
                catch
                {
                    row.Cells[6].Value = 1;
                }
            }

        }

        private void sol_CashDenominations_SelectAllDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}
