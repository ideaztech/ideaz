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
    public partial class Fees : Form
    {
        private string b_Accion = "";

        public Fees()
        {
            InitializeComponent();
        }

        private void Fees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetFees.sol_Fees_SelectAll' table. You can move, or remove it, as needed.
            this.sol_Fees_SelectAllTableAdapter.Fill(this.dataSetFees.sol_Fees_SelectAll);

            if (Properties.Settings.Default.TouchOriented)
            {
                this.Height = this.Height + (OK.Height) + 150;
                OK.Height = OK.Height * 2;
                Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
                this.CenterToParent();

            }
            else
            {
                int tamano = 16;
                sol_Fees_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_Fees_SelectAllBindingNavigator.Size = new System.Drawing.Size(sol_Fees_SelectAllBindingNavigator.Size.Width, tamano + 7);
                sol_Fees_SelectAllBindingNavigator.Stretch = false;

            }
            //bloquear  columnas
            short indice = 0;
            //id
            sol_Fees_SelectAllDataGridView.Columns[indice].HeaderText = "Id";
            sol_Fees_SelectAllDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            sol_Fees_SelectAllDataGridView.Columns[indice].Width = 80;
            indice++;
            //description
            sol_Fees_SelectAllDataGridView.Columns[indice].HeaderText = "Description";
            sol_Fees_SelectAllDataGridView.Columns[indice].Width = 250;
            indice++;
            //refundAmount
            sol_Fees_SelectAllDataGridView.Columns[indice].HeaderText = "Amount";
            sol_Fees_SelectAllDataGridView.Columns[indice].Width = 150;
            indice++;
            //Percentage
            sol_Fees_SelectAllDataGridView.Columns[indice].HeaderText = "Percentage";
            sol_Fees_SelectAllDataGridView.Columns[indice].Width = 150;
            indice++;

        }

        private void OK_Click(object sender, EventArgs e)
        {
            sol_Fees_SelectAllBindingNavigatorSaveItem.PerformClick();
            //Close();

        }

        private void sol_Fees_SelectAllBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            string c = this.sol_Fees_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();
            if (String.IsNullOrEmpty(c))
            {
                MessageBox.Show("Please enter data for row");
                return;
            }


            this.Validate();
            this.sol_Fees_SelectAllBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetFees);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.sol_Fees_SelectAllTableAdapter.Fill(this.dataSetFees.sol_Fees_SelectAll);
                    this.sol_Fees_SelectAllBindingSource.MoveLast();
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

        private void Fees_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.dataSetFees.HasChanges())
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
            sol_Fees_SelectAllBindingSource.AddNew();

            //valores por omision
            //short indice = 3;

            //containerType
            //this.dataSetStandardDozenLookup.sol_Containers.Columns[indice].DefaultValue = 1;
            //this.sol_Fees_SelectAllDataGridView.CurrentRow.Cells[indice++].Value = 1;

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
            if (this.sol_Fees_SelectAllDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.sol_Fees_SelectAllDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.sol_Fees_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", descripcion), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.sol_Fees_SelectAllDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.sol_Fees_SelectAllDataGridView.SelectedRows.Count > 0 &&
                            this.sol_Fees_SelectAllDataGridView.SelectedRows[0].Index !=
                            this.sol_Fees_SelectAllDataGridView.Rows.Count)
                        {
                            this.sol_Fees_SelectAllDataGridView.Rows.RemoveAt(
                               this.sol_Fees_SelectAllDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.sol_Fees_SelectAllDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.sol_Fees_SelectAllDataGridView.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dataSetFees);


                try
                {
                    this.sol_Fees_SelectAllDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }

        }

    }
}
