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
    public partial class StandardDozen : Form
    {
        private string b_Accion = "";

        public StandardDozen()
        {
            InitializeComponent();
        }

        private void StandardDozen_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dataSetStandardDozenLookup.sol_StandardDozen' table. You can move, or remove it, as needed.
            this.sol_StandardDozenTableAdapter.Fill(this.dataSetStandardDozenLookup.sol_StandardDozen);

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
                sol_StandardDozenBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_StandardDozenBindingNavigator.Size = new System.Drawing.Size(sol_StandardDozenBindingNavigator.Size.Width, tamano + 7);
                sol_StandardDozenBindingNavigator.Stretch = false;

            }



            //bloquear  columnas
            short indice = 0;
            //id
            sol_StandardDozenDataGridView.Columns[indice].HeaderText = "Id";
            sol_StandardDozenDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            //sol_ContainersDataGridView.Columns[indice].Width = 80;
            indice++;
            //name
            //sol_ContainersDataGridView.Columns[indice].HeaderText = "Name";
            sol_StandardDozenDataGridView.Columns[indice].Width = 200;
            indice++;
        }

        private void sol_StandardDozenBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            string c = this.sol_StandardDozenDataGridView.CurrentRow.Cells[1].Value.ToString();
            if (String.IsNullOrEmpty(c))
            {
                MessageBox.Show("Please enter data for row");
                return;
            }

            this.Validate();
            this.sol_StandardDozenBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetStandardDozenLookup);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.sol_StandardDozenTableAdapter.Fill(this.dataSetStandardDozenLookup.sol_StandardDozen);
                    this.sol_StandardDozenBindingSource.MoveLast();
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

        private void OK_Click(object sender, EventArgs e)
        {
            sol_StandardDozenBindingNavigatorSaveItem.PerformClick();

            //Close();

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

        private void StandardDozen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.dataSetStandardDozenLookup.HasChanges())
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                return;

            b_Accion = "agregar";

            //add row manually (AddNewItem = <none> in BindingNavigator)
            sol_StandardDozenBindingSource.AddNew();

            //valores por omision
            //short indice = 3;

            //containerType
            //this.dataSetStandardDozenLookup.sol_Containers.Columns[indice].DefaultValue = 1;
            //this.sol_StandardDozenDataGridView.CurrentRow.Cells[indice++].Value = 1;

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
            if (this.sol_StandardDozenDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.sol_StandardDozenDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.sol_StandardDozenDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", descripcion), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.sol_StandardDozenDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.sol_StandardDozenDataGridView.SelectedRows.Count > 0 &&
                            this.sol_StandardDozenDataGridView.SelectedRows[0].Index !=
                            this.sol_StandardDozenDataGridView.Rows.Count)
                        {
                            this.sol_StandardDozenDataGridView.Rows.RemoveAt(
                               this.sol_StandardDozenDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.sol_StandardDozenDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.sol_StandardDozenDataGridView.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dataSetStandardDozenLookup);


                try
                {
                    this.sol_StandardDozenDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }

        }

    }
}
