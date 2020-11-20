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
    public partial class Categories : Form
    {
        //private static Sol_CategoryButton sol_CategoryButton;
        private static Sol_CategoryButton_Sp sol_CategoryButton_Sp;

        private string b_Accion = "";

        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCategories.sol_Categories' table. You can move, or remove it, as needed.
            this.sol_CategoriesTableAdapter.Fill(this.dataSetCategories.sol_Categories);
            this.Width = Main.ActiveForm.Width - 50;
            this.Height = Main.ActiveForm.Height - 50;

            sol_CategoriesBindingNavigator.Renderer = new App_Code.NewToolStripRenderer();
            //if (Properties.Settings.Default.TouchOriented)
            //{
              //  this.Height = this.Height + (OK.Height) + 150;
               // OK.Height = OK.Height * 2;
               // Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
                this.CenterToParent();

            //}
            /*else
            {
                int tamano = 16;
                sol_CategoriesBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_CategoriesBindingNavigator.Size = new System.Drawing.Size(sol_CategoriesBindingNavigator.Size.Width, tamano + 7);
                sol_CategoriesBindingNavigator.Stretch = false;

            }*/
            //bloquear  columnas
            short indice = 0;
            //id
            sol_CategoriesDataGridView.Columns[indice].HeaderText = "Id";
            sol_CategoriesDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            sol_CategoriesDataGridView.Columns[indice].Width = 80;
            indice++;
            //description
            //sol_CategoriesDataGridView.Columns[indice].HeaderText = "Name";
            sol_CategoriesDataGridView.Columns[indice].Width = 200;
            indice++;
            //refundAmount
            //sol_CategoriesDataGridView.Columns[indice].HeaderText = "Description";
            sol_CategoriesDataGridView.Columns[indice].Width = 150;
            indice++;
            //subContainerQuantity
            //sol_CategoriesDataGridView.Columns[indice].HeaderText = "Description";
            sol_CategoriesDataGridView.Columns[indice].Width = 150;
            indice++;

            if (sol_CategoriesDataGridView.Width > 480)
                sol_CategoriesDataGridView.Columns[1].Width = sol_CategoriesDataGridView.Width - 380;

        }

        private void OK_Click(object sender, EventArgs e)
        {
            sol_CategoriesBindingNavigatorSaveItem.PerformClick();

            //Close();

        }

        private void sol_CategoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (b_Accion == "agregar")
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatA", true))
                    return;
            }
            else
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatC", true))
                    return;
            }


            //check data
            //first row
            string c = this.sol_CategoriesDataGridView.CurrentRow.Cells[1].Value.ToString();
            if (String.IsNullOrEmpty(c))
            {
                MessageBox.Show("Please enter data for row");
                return;
            }


            this.Validate();
            this.sol_CategoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetCategories);
            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.sol_CategoriesTableAdapter.Fill(this.dataSetCategories.sol_Categories);
                    this.sol_CategoriesBindingSource.MoveLast();
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

        private void Categories_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.dataSetCategories.HasChanges())
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
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatA", true))
                return;

            b_Accion = "agregar";

            //add row manually (AddNewItem = <none> in BindingNavigator)
            sol_CategoriesBindingSource.AddNew();

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
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatC", true))
                return;

            //empty datagrid
            if (this.sol_CategoriesDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.sol_CategoriesDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.sol_CategoriesDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", descripcion), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {

                if (sol_CategoryButton_Sp == null)
                    sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);

                List<Sol_CategoryButton> sol_CategoryButtonList = sol_CategoryButton_Sp._SelectAllByCategoryID(id);
                if (sol_CategoryButtonList.Count() > 0)
                {
                    MessageBox.Show("Cannot delete this category, first remove it from all category buttons!");
                    return;
                }


                int cnt = this.sol_CategoriesDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.sol_CategoriesDataGridView.SelectedRows.Count > 0 &&
                            this.sol_CategoriesDataGridView.SelectedRows[0].Index !=
                            this.sol_CategoriesDataGridView.Rows.Count)
                        {
                            this.sol_CategoriesDataGridView.Rows.RemoveAt(
                               this.sol_CategoriesDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.sol_CategoriesDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.sol_CategoriesDataGridView.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dataSetCategories);


                try
                {
                    this.sol_CategoriesDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }
    }
}
