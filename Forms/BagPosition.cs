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
    public partial class BagPosition : Form
    {

        DataSet dsAssigned, dsUnassigned;
        DataTable dtAssigned, dtUnassigned;
        DataRow drAssigned, drUnassigned;

        private static Vir_ConveyorLink_Sp vir_ConveyorLink_Sp;
        private static Vir_ConveyorLink vir_ConveyorLink;

        private static Vir_Conveyor_Sp vir_Conveyor_Sp;
        //private static Vir_Conveyor vir_Conveyor;

        private string b_Accion = "";

        public BagPosition()
        {
            InitializeComponent();
        }

        private void BagPosition_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetBagPosition.Vir_BagPosition_SelectAll' table. You can move, or remove it, as needed.
            this.vir_BagPosition_SelectAllTableAdapter.Fill(this.dataSetBagPosition.Vir_BagPosition_SelectAll);

            this.sol_ProductsTableAdapter.Fill(this.dataSetProductsLookup.sol_Products, 0);
            this.Width = Main.ActiveForm.Width - 50;
            this.Height = Main.ActiveForm.Height - 100;

            vir_BagPosition_SelectAllBindingNavigator.Renderer = new App_Code.NewToolStripRenderer();

            if (Properties.Settings.Default.TouchOriented)
            {
                //this.Height = this.Height + (OK.Height) + 150;
                //OK.Height = OK.Height * 2;
                //buttonDetails.Height = buttonDetails.Height * 2;
                //Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
                this.CenterToParent();

            }
            else
            {
                int tamano = 16;
                vir_BagPosition_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                vir_BagPosition_SelectAllBindingNavigator.Size = new System.Drawing.Size(vir_BagPosition_SelectAllBindingNavigator.Size.Width, tamano + 7);
                vir_BagPosition_SelectAllBindingNavigator.Stretch = false;

            }
            //bloquear  columnas
            vir_BagPosition_SelectAllDataGridView.ReadOnly = true;

            short indice = 0;
            //id
            vir_BagPosition_SelectAllDataGridView.Columns[indice].HeaderText = "Id";
            vir_BagPosition_SelectAllDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            vir_BagPosition_SelectAllDataGridView.Columns[indice].Width = 50;
            indice++;
            //Name
            vir_BagPosition_SelectAllDataGridView.Columns[indice].HeaderText = "Name";
            vir_BagPosition_SelectAllDataGridView.Columns[indice].Width = 100;
            indice++;
            //Product
            vir_BagPosition_SelectAllDataGridView.Columns[indice].HeaderText = "Product";
            vir_BagPosition_SelectAllDataGridView.Columns[indice].Width = 200;
            indice++;
            //CurentStageID
            //vir_BagPosition_SelectAllDataGridView.Columns[indice].HeaderText = "Description";
            //vir_BagPosition_SelectAllDataGridView.Columns[indice].Width = 150;
            indice++;

            //CurrentQuantity
            //vir_BagPosition_SelectAllDataGridView.Columns[indice].HeaderText = "Staging Method";
            //vir_BagPosition_SelectAllDataGridView.Columns[indice].Width = 150;
            indice++;

            //TargetQuantity
            //vir_BagPosition_SelectAllDataGridView.Columns[indice].HeaderText = "Staging Product";
            //vir_BagPosition_SelectAllDataGridView.Columns[indice].Width = 150;
            indice++;

            //make dataGrid active (focus)
            this.vir_BagPosition_SelectAllDataGridView.Select();

            vir_BagPosition_SelectAllDataGridView.Width = panel1.Width / 2;
            panelDetails.Width = panel1.Width - vir_BagPosition_SelectAllDataGridView.Width;
            if (vir_BagPosition_SelectAllDataGridView.Width > 250)
                vir_BagPosition_SelectAllDataGridView.Columns[2].Width = vir_BagPosition_SelectAllDataGridView.Width - 150;


        }

        private void OK_Click(object sender, EventArgs e)
        {
            vir_BagPosition_SelectAllBindingNavigatorSaveItem.PerformClick();

        }

        private void vir_BagPosition_SelectAllBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            ////first row
            //string c = this.vir_BagPosition_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();
            //if (String.IsNullOrEmpty(c))
            //{
            //    MessageBox.Show("Please enter data for row");
            //    return;
            //}

            //name 
            bagPositionNameTextBox.Text = bagPositionNameTextBox.Text.Trim();
            if (!Funciones.ValidateText(bagPositionNameTextBox, ref errorProvider1))
            {
                bagPositionNameTextBox.Focus();
                return;
            }
            this.Validate();
            this.vir_BagPosition_SelectAllBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetBagPosition);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.vir_BagPosition_SelectAllTableAdapter.Fill(this.dataSetBagPosition.Vir_BagPosition_SelectAll);
                    this.vir_BagPosition_SelectAllBindingSource.MoveLast();

                    //bindingNavigatorDeleteItem.Enabled = true;
                    //bindingNavigatorAddNewItem.Enabled = true;


                }
            }
            catch
            {
                //
            }

            b_Accion = "";
            //Cancel.Text = "&Close";

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

        private void BagPosition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (Cancel.Text == "&Close")
            {
                Close();
            }
            else if (Cancel.Text == "&Cancel")
            {
                //cancelar alta
                if (b_Accion == "agregar")
                {
                    ((BindingSource)this.vir_BagPosition_SelectAllDataGridView.DataSource).RemoveCurrent();
                    try
                    {
                        this.vir_BagPosition_SelectAllDataGridView.Rows[this.vir_BagPosition_SelectAllDataGridView.CurrentRow.Index].Selected = true;
                    }
                    catch { }

                }

                b_Accion = "cancelar";
                Cancel.Text = "&Close";
                cambiarVista();
              
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolAddCatalogues", true))
                return;

            b_Accion = "agregar";

            //add row manually (AddNewItem = <none> in BindingNavigator)

            //to update next id

            this.vir_BagPosition_SelectAllDataGridView.DataSource = this.vir_BagPosition_SelectAllBindingSource;



            this.vir_BagPosition_SelectAllBindingSource.AddNew();

            //valores por omision
            short indice = 3;

            //CurrentStageID
            this.dataSetBagPosition.Vir_BagPosition_SelectAll.Columns[indice].DefaultValue = 0;
            this.vir_BagPosition_SelectAllDataGridView.CurrentRow.Cells[indice++].Value = 0;

            //CurrentQuantity
            this.dataSetBagPosition.Vir_BagPosition_SelectAll.Columns[indice].DefaultValue = 0;
            this.vir_BagPosition_SelectAllDataGridView.CurrentRow.Cells[indice++].Value = 0;

            //TargetQuantity
            this.dataSetBagPosition.Vir_BagPosition_SelectAll.Columns[indice].DefaultValue = 0;
            this.vir_BagPosition_SelectAllDataGridView.CurrentRow.Cells[indice++].Value = 0;

            this.Validate();

           // cambiarVista();


        }

        private void cambiarVista()
        {
            groupBoxButtons.Enabled = true;

            switch (b_Accion)
            {
                case "agregar":
                    vir_BagPosition_SelectAllDataGridView.Visible = false;
                    panelDetails.Visible = true;
                    //bagPositionIDTextBox.ReadOnly = false;
                    groupBoxButtons.Enabled = false;
                    break;
                case "actualizar":
                    vir_BagPosition_SelectAllDataGridView.Visible = false;
                    panelDetails.Visible = true;
                    break;
                case "cancelar":
                    vir_BagPosition_SelectAllDataGridView.Visible = true;
                    panelDetails.Visible = false;
                    break;
                default:
                    vir_BagPosition_SelectAllDataGridView.Visible = true;
                    panelDetails.Visible = false;
                    break;
            }

            if (panelDetails.Visible)
            {
                Cancel.Text = "&Cancel";


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
                    //bindListBoxConveyors();

                }
                vir_BagPosition_SelectAllBindingNavigatorSaveItem.Enabled = true;
                buttonDetails.Enabled = false;
                //buttonRefresh.Enabled = false;

                //bagPositionNameTextBox.Enabled = true;
                //panelDetails.Enabled = true;
                bagPositionNameTextBox.Focus();

                //if (containerIDTextBox.Text == "0")
                //{
                //    //bagPositionNameTextBox.Enabled = false;
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
                vir_BagPosition_SelectAllBindingNavigatorSaveItem.Enabled = false;
                buttonDetails.Enabled = true;
                //buttonRefrescar.Enabled = true;

                this.vir_BagPosition_SelectAllDataGridView.Focus();
            }

            this.Validate();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCatalogues", true))
                return;

            //empty datagrid
            if (this.vir_BagPosition_SelectAllDataGridView.Rows.Count < 1)
                return;

            int id = (int)this.vir_BagPosition_SelectAllDataGridView.CurrentRow.Cells[0].Value;
            if (id == 0)
            {
                MessageBox.Show("Cannot delete this row!");
                return;
            }

            string descripcion = this.vir_BagPosition_SelectAllDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this row: {0}?", descripcion), "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {

                //if (vir_ConveyorLink_Sp == null)
                //    vir_ConveyorLink_Sp = new Vir_ConveyorLink_Sp(Properties.Settings.Default.WsirDbConnectionString);

                //List<Vir_ConveyorLink> vir_ConveyorLinkList = vir_ConveyorLink_Sp._SelectAllByBagPositionID(id);
                //if (vir_ConveyorLinkList.Count() > 0)
                //{
                //    MessageBox.Show("Cannot delete this bag position because it is currently opened, first close it!");
                //    return;
                //}


                int cnt = this.vir_BagPosition_SelectAllDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.vir_BagPosition_SelectAllDataGridView.SelectedRows.Count > 0 &&
                            this.vir_BagPosition_SelectAllDataGridView.SelectedRows[0].Index !=
                            this.vir_BagPosition_SelectAllDataGridView.Rows.Count)
                        {
                            this.vir_BagPosition_SelectAllDataGridView.Rows.RemoveAt(
                               this.vir_BagPosition_SelectAllDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.vir_BagPosition_SelectAllDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.vir_BagPosition_SelectAllDataGridView.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dataSetBagPosition);


                try
                {
                    this.vir_BagPosition_SelectAllDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }

        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (this.vir_BagPosition_SelectAllDataGridView.Rows.Count < 1)
                return;

            b_Accion = "actualizar";
            OK.Text = "&Update";

            cambiarVista();

        }

        private void bagPositionIDTextBox_TextChanged(object sender, EventArgs e)
        {
            bindListBoxConveyors();
        }


        #region conveyors

        private void bindListBoxConveyors()
        {

            //DataSet dsAssigned, dsUnAssigned;
            //DataTable dtAssigned, dtUnAssigned;
            //DataRow drAssigned, drUnAssigned;

            dsAssigned = new DataSet();
            dtAssigned = new DataTable("MyTable");
            dtAssigned.Columns.Add(new DataColumn("id", typeof(int)));
            dtAssigned.Columns.Add(new DataColumn("name", typeof(string)));
            dtAssigned.Columns.Add(new DataColumn("conveyorId", typeof(string)));

            dsUnassigned = new DataSet();
            dtUnassigned = new DataTable("MyTable");
            dtUnassigned.Columns.Add(new DataColumn("id", typeof(int)));
            dtUnassigned.Columns.Add(new DataColumn("name", typeof(string)));
            dtUnassigned.Columns.Add(new DataColumn("conveyorId", typeof(string)));

            listBoxUnassignedConveyors.DataSource = null;
            listBoxAssignedConveyors.DataSource = null;

            int bagPositionID = 0;
            int.TryParse(bagPositionIDTextBox.Text, out bagPositionID);

            if (vir_ConveyorLink_Sp == null)
                vir_ConveyorLink_Sp = new Vir_ConveyorLink_Sp(Properties.Settings.Default.WsirDbConnectionString);

            if (vir_Conveyor_Sp == null)
                vir_Conveyor_Sp = new Vir_Conveyor_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Vir_Conveyor> vir_ConveyorList = vir_Conveyor_Sp.SelectAll();
            foreach (Vir_Conveyor c in vir_ConveyorList)
            {

                vir_ConveyorLink = vir_ConveyorLink_Sp._SelectByBagPositionIDConveyorID(bagPositionID, c.ConveyorID);
                if (vir_ConveyorLink == null)
                {
                    drUnassigned = dtUnassigned.NewRow();
                    drUnassigned["id"] = 0; // vir_ConveyorLink.ConveyorLinkID;
                    drUnassigned["name"] = c.ConveyorDescription;
                    drUnassigned["conveyorid"] = c.ConveyorID;
                    dtUnassigned.Rows.Add(drUnassigned);

                }
                else
                {
                    drAssigned = dtAssigned.NewRow();
                    drAssigned["id"] = vir_ConveyorLink.ConveyorLinkID;
                    drAssigned["name"] = c.ConveyorDescription;
                    drAssigned["conveyorid"] = c.ConveyorID;
                    dtAssigned.Rows.Add(drAssigned);

                }
            }

            //Unassigned
            dsUnassigned.Tables.Add(dtUnassigned);
            listBoxUnassignedConveyors.ValueMember = "id";
            listBoxUnassignedConveyors.DisplayMember = "name";
            listBoxUnassignedConveyors.DataSource = dtUnassigned;
            //listBoxUnassignedConveyors.Items.Add(c.ConveyorDescription);

            //Assigned
            dsAssigned.Tables.Add(dtAssigned);
            //listBoxAssignedConveyors.Items.Add(c.ConveyorDescription);
            listBoxAssignedConveyors.ValueMember = "id";
            listBoxAssignedConveyors.DisplayMember = "name";
            listBoxAssignedConveyors.DataSource = dtAssigned;
            //listBoxAssignedConveyors.r



        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            //vir_BagPosition_SelectAllBindingNavigatorSaveItem.PerformClick();

            bagPositionNameTextBox.Text = bagPositionNameTextBox.Text.Trim();
            if (!Funciones.ValidateText(bagPositionNameTextBox, ref errorProvider1))
            {
                bagPositionNameTextBox.Focus();
                return;
            }

            string t = targetQuantityTextBox.Text;

            this.Validate();
            this.vir_BagPosition_SelectAllBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetBagPosition);

            DataRowView conveyor = (DataRowView)listBoxUnassignedConveyors.SelectedItem;
            if(conveyor == null)
            {
                MessageBox.Show("PLease select a conveyor to add!");
                listBoxUnassignedConveyors.Focus();
                return;
            }

            int bagPositionID = 0;
            int.TryParse(bagPositionIDTextBox.Text, out bagPositionID);


            if (vir_ConveyorLink_Sp == null)
                vir_ConveyorLink_Sp = new Vir_ConveyorLink_Sp(Properties.Settings.Default.WsirDbConnectionString);

            //vir_ConveyorLink_Sp._DeleteByBagPositionIDConveyorID(bagPositionID, c.ConveyorID);

            vir_ConveyorLink = new Vir_ConveyorLink();
            vir_ConveyorLink.BagPositionID = bagPositionID;

            int conveyorid = 0;
            int.TryParse(conveyor["conveyorid"].ToString(), out conveyorid);

            vir_ConveyorLink.ConveyorID = conveyorid;
            vir_ConveyorLink_Sp.Insert(vir_ConveyorLink);

            bindListBoxConveyors();

        }

        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            DataRowView conveyor = (DataRowView)listBoxAssignedConveyors.SelectedItem;
            
            if (conveyor == null)
            {
                MessageBox.Show("PLease select a conveyor to remove!");
                listBoxAssignedConveyors.Focus();
                return;
            }

            if (vir_ConveyorLink_Sp == null)
                vir_ConveyorLink_Sp = new Vir_ConveyorLink_Sp(Properties.Settings.Default.WsirDbConnectionString);

            int id = 0;
            int.TryParse(conveyor["id"].ToString(), out id);

            vir_ConveyorLink_Sp.Delete(id);

            bindListBoxConveyors();

        }

        #endregion
    }

}
