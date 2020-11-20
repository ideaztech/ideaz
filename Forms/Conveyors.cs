using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SirLib;

namespace Solum
{
    public partial class Conveyors : Form
    {
        private string b_Accion = "";

        public Conveyors()
        {
            InitializeComponent();
        }

        private void Conveyors_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetConveyors.Vir_Conveyor_SelectAll' table. You can move, or remove it, as needed.
            this.vir_Conveyor_SelectAllTableAdapter.Fill(this.dataSetConveyors.Vir_Conveyor_SelectAll);
            // TODO: This line of code loads data into the 'dataSetConveyors.Vir_Conveyor_SelectAll' table. You can move, or remove it, as needed.
            this.vir_Conveyor_SelectAllTableAdapter.Fill(this.dataSetConveyors.Vir_Conveyor_SelectAll);


            //if (Properties.Settings.Default.TouchOriented)
            //{
            //  this.Height = this.Height + (OK.Height) + 150;
            // OK.Height = OK.Height * 2;
            //Cancel.Height = Cancel.Height * 2;
            toolStripButtonVirtualKb.Visible = true;

            this.Height = Main.ActiveForm.Height - 50;
            this.Width = Main.ActiveForm.Width - 50;
            vir_Conveyor_SelectAllBindingNavigator.Renderer = new App_Code.NewToolStripRenderer();

                this.CenterToParent();

            //}
            //else
            //{
             //   int tamano = 16;
             //   vir_Conveyor_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
             //   vir_Conveyor_SelectAllBindingNavigator.Size = new System.Drawing.Size(vir_Conveyor_SelectAllBindingNavigator.Size.Width, tamano + 7);
             //   vir_Conveyor_SelectAllBindingNavigator.Stretch = false;

           // }



            //bloquear  columnas
            short indice = 0;
            //id
            vir_Conveyor_SelectAllDataGridView.Columns[indice].HeaderText = "Id";
            vir_Conveyor_SelectAllDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            //sol_ContainersDataGridView.Columns[indice].Width = 80;
            indice++;
            //Description
            vir_Conveyor_SelectAllDataGridView.Columns[indice].HeaderText = "Description";
            vir_Conveyor_SelectAllDataGridView.Columns[indice].Width = 200;
            indice++;

            if (vir_Conveyor_SelectAllDataGridView.Width > 280) vir_Conveyor_SelectAllDataGridView.Columns[1].Width =
                    vir_Conveyor_SelectAllDataGridView.Width - vir_Conveyor_SelectAllDataGridView.Columns[0].Width;

        }

        private void vir_Conveyor_SelectAllBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            string c = vir_Conveyor_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();
            if (String.IsNullOrEmpty(c))
            {
                MessageBox.Show("Please enter data for row");
                return;
            }

            this.Validate();
            this.vir_Conveyor_SelectAllBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetConveyors);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.vir_Conveyor_SelectAllTableAdapter.Fill(this.dataSetConveyors.Vir_Conveyor_SelectAll);
                    this.vir_Conveyor_SelectAllBindingSource.MoveLast();
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
            vir_Conveyor_SelectAllBindingNavigatorSaveItem.PerformClick();

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

        private void Conveyors_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            vir_Conveyor_SelectAllBindingSource.AddNew();

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
            if (this.vir_Conveyor_SelectAllDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.vir_Conveyor_SelectAllDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.vir_Conveyor_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", descripcion), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.vir_Conveyor_SelectAllDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.vir_Conveyor_SelectAllDataGridView.SelectedRows.Count > 0 &&
                            this.vir_Conveyor_SelectAllDataGridView.SelectedRows[0].Index !=
                            this.vir_Conveyor_SelectAllDataGridView.Rows.Count)
                        {
                            this.vir_Conveyor_SelectAllDataGridView.Rows.RemoveAt(
                               this.vir_Conveyor_SelectAllDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.vir_Conveyor_SelectAllDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.vir_Conveyor_SelectAllDataGridView.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dataSetConveyors);


                try
                {
                    this.vir_Conveyor_SelectAllDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }
    }
}
