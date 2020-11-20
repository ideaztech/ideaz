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
    public partial class Containers : Form
    {
        public static bool abcrcAgency;
        public virtual bool AbcrcAgency
        {
            get { return abcrcAgency; }
            set { abcrcAgency = value; }
        }


        public int containerId = -1;
        public string containerName = "";

        private string b_Accion = "";

        public Containers()
        {
            InitializeComponent();
        }

        private void Containers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetWSShippingContainerTypes.Sol_WS_ShippingContainerTypes' table. You can move, or remove it, as needed.
            if (abcrcAgency)
            {
                this.sol_WS_ShippingContainerTypesTableAdapter.Fill(this.dataSetWSShippingContainerTypes.Sol_WS_ShippingContainerTypes);
                groupBoxAbcrc.Visible = true;
            }
            else
                groupBoxAbcrc.Visible = false;


            // TODO: This line of code loads data into the 'dataSetContainerTypes.sol_ContainerTypes' table. You can move, or remove it, as needed.
            this.sol_ContainerTypesTableAdapter.Fill(this.dataSetContainerTypes.sol_ContainerTypes);
            // TODO: This line of code loads data into the 'dataSetContainers.sol_Containers' table. You can move, or remove it, as needed.
            //this.sol_ContainersTableAdapter.Fill(this.dataSetContainers.sol_Containers);

            //if (Properties.Settings.Default.TouchOriented)
            //{
            //    this.Height = this.Height + (OK.Height) + 150;
              //  OK.Height = OK.Height * 2;
             //   buttonDetails.Height = buttonDetails.Height * 2;
              //  Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
            //}
            // else
            // {
            //   int tamano = 16;
            //   sol_ContainersBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
            //   sol_ContainersBindingNavigator.Size = new System.Drawing.Size(sol_ContainersBindingNavigator.Size.Width, tamano + 7);
            //   sol_ContainersBindingNavigator.Stretch = false;

            // }

            this.Height = Main.ActiveForm.Height - 50;
            this.Width = Main.ActiveForm.Width - 50;

            this.CenterToParent();

            //bloquear  columnas
            sol_ContainersDataGridView.ReadOnly = true;
            short indice = 0;
            //id
            sol_ContainersDataGridView.Columns[indice].HeaderText = "Id";
            sol_ContainersDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            sol_ContainersDataGridView.Columns[indice].Width = 80;
            indice++;
            //description
            //sol_ContainersDataGridView.Columns[indice].HeaderText = "Description";
            sol_ContainersDataGridView.Columns[indice].Width = 300;
            indice++;
            //short description
            //sol_ContainersDataGridView.Columns[indice].HeaderText = "Short Description";
            //sol_ContainersDataGridView.Columns[indice].Width = 350;
            sol_ContainersDataGridView.Columns[indice].Visible = false;
            indice++;
            sol_ContainersDataGridView.Columns[indice].HeaderText = "ContainerType";
            sol_ContainersDataGridView.Columns[indice].Width = 150;

            checkBoxContainerTypeAll.Checked = true;
            comboBoxContainerTypes.SelectedValue = -1;

            sol_ContainersBindingNavigator.Renderer = new App_Code.NewToolStripRenderer();

            tableLayoutPanelGrid.Width = splitContainer1.Width / 2;
            panelDetails.Width = splitContainer1.Width - tableLayoutPanelGrid.Width;

            if (sol_ContainersDataGridView.Width > 480) sol_ContainersDataGridView.Columns[1].Width =
                     sol_ContainersDataGridView.Width - 230;
            //make dataGrid active (focus)
            this.sol_ContainersDataGridView.Select();



        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (sol_ContainersDataGridView.Rows.Count < 1)
                return;

            if (OK.Text == "&Select")
            {
                try
                {
                    containerId = (int)this.sol_ContainersDataGridView.CurrentRow.Cells[0].Value;
                    if (containerId < 1)
                        throw new Exception();
                    containerName = sol_ContainersDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                }
                catch
                {
                    MessageBox.Show("Please select a valid customer.");
                    return;
                }

                Close();
                return;
            }


            sol_ContainersBindingNavigatorSaveItem.PerformClick();

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
            descriptionTextBox.Text = descriptionTextBox.Text.Trim();
            if (!Funciones.ValidateText(descriptionTextBox, ref errorProvider1))
            {
                descriptionTextBox.Focus();
                return;
            }
            this.Validate();
            this.sol_ContainersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetContainers);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.sol_ContainersTableAdapter.Fill(this.dataSetContainers.sol_Containers);
                    this.sol_ContainersBindingSource.MoveLast();
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

        private void Containers_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.dataSetContainers.HasChanges())
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
           // if (Cancel.Text == "&Close")
           // {
                containerId = -1;
                Close();
           // }
            /*else if (Cancel.Text == "&Cancel")
            {
                //cancelar alta
                if (b_Accion == "agregar")
                {
                    ((BindingSource)this.sol_ContainersDataGridView.DataSource).RemoveCurrent();
                    try
                    {
                        this.sol_ContainersDataGridView.Rows[this.sol_ContainersDataGridView.CurrentRow.Index].Selected = true;
                    }
                    catch { }

                }

                b_Accion = "cancelar";
                OK.Text = "&Select";
                Cancel.Text = "&Close";
                cambiarVista();
            }*/


        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                return;

            b_Accion = "agregar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            //add row manually (AddNewItem = <none> in BindingNavigator)
            sol_ContainersBindingSource.AddNew();

            //valores por omision
            short indice = 3;

            //containerType
            this.dataSetContainers.sol_Containers.Columns[indice].DefaultValue = 1;
            this.sol_ContainersDataGridView.CurrentRow.Cells[indice++].Value = 1;

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
                sol_ContainersBindingNavigatorSaveItem.Enabled = true;
                buttonDetails.Enabled = false;
                //buttonRefresh.Enabled = false;

                //descriptionTextBox.Enabled = true;
                //panelDetails.Enabled = true;
                descriptionTextBox.Focus();

                //if (containerIDTextBox.Text == "0")
                //{
                //    //descriptionTextBox.Enabled = false;
                //    panelDetails.Enabled = false;
                //}

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
                sol_ContainersBindingNavigatorSaveItem.Enabled = false;
                buttonDetails.Enabled = true;
                //buttonRefrescar.Enabled = true;

                this.sol_ContainersDataGridView.Focus();
            }

            this.Validate();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                return;

            //empty datagrid
            if (this.sol_ContainersDataGridView.Rows.Count < 1)
                return;

            containerId = (int)this.sol_ContainersDataGridView.CurrentRow.Cells[0].Value;
            if (containerId == 0)
            {
                MessageBox.Show("Cannot delete this container!");
                return;
            }

            string descripcion = this.sol_ContainersDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this container: {0}?", descripcion), "Deleting Container", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.sol_ContainersDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.sol_ContainersDataGridView.SelectedRows.Count > 0 &&
                            this.sol_ContainersDataGridView.SelectedRows[0].Index !=
                            this.sol_ContainersDataGridView.Rows.Count)
                        {
                            this.sol_ContainersDataGridView.Rows.RemoveAt(
                               this.sol_ContainersDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.sol_ContainersDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.sol_ContainersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dataSetContainers);


                try
                {
                    this.sol_ContainersDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }

        private void descriptionTextBox_Validating(object sender, CancelEventArgs e)
        {
            Funciones.ValidateText(sender, ref errorProvider1);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (this.sol_ContainersDataGridView.Rows.Count < 1)
                return;

            b_Accion = "actualizar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            cambiarVista();

        }

        private void comboBoxContainerTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int containerTypeId;
            try
            {
                containerTypeId = (int)comboBoxContainerTypes.SelectedValue;
            }
            catch
            {
                containerTypeId = -1;
            }

            if (containerTypeId > 0)
            {
                //this.tableAdapter1.FillByProveedor(this.dataSet1.CI_Articulos, containerTypeId);
                this.sol_ContainersTableAdapter.FillByType(this.dataSetContainers.sol_Containers, containerTypeId);
            }

        }

        private void checkBoxContainerTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxContainerTypes.Enabled = !checkBoxContainerTypeAll.Checked;
            comboBoxContainerTypes.SelectedValue = -1;

            if (checkBoxContainerTypeAll.Checked)
                this.sol_ContainersTableAdapter.Fill(this.dataSetContainers.sol_Containers);

        }

        private void containerIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (containerIDTextBox.Text == "0")
                panelDetails.Enabled = false;
            else
                panelDetails.Enabled = true;

        }

        private void sol_ContainersDataGridView_KeyUp(object sender, KeyEventArgs e)
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

        private void containerTypeIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (containerTypeIDComboBox.Text == "Shipping Containers")
                shippingContainerTypeIDComboBox.Enabled = true;
            else
                shippingContainerTypeIDComboBox.Enabled = false;

        }



    }
}

