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
    public partial class CardTypes : Form
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

        public CardTypes()
        {
            InitializeComponent();
        }

        private void CardTypes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qdsDataSetCardTypes.Qds_CardTypes' table. You can move, or remove it, as needed.
            this.qds_CardTypesTableAdapter.Fill(this.qdsDataSetCardTypes.Qds_CardTypes);
            // TODO: This line of code loads data into the 'dataSetCardTypes.Qds_CardTypes' table. You can move, or remove it, as needed.
            //this.Qds_CardTypesTableAdapter.Fill(this.dataSetCardTypes.Qds_CardTypes);

            if (Properties.Settings.Default.TouchOriented)
            {
                this.Height = this.Height + (OK.Height) + 150;
                OK.Height = OK.Height * 2;
                buttonDetails.Height = buttonDetails.Height * 2;
                Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
            }
            else
            {
                int tamano = 16;
                qds_CardTypesBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                qds_CardTypesBindingNavigator.Size = new System.Drawing.Size(qds_CardTypesBindingNavigator.Size.Width, tamano + 7);
                qds_CardTypesBindingNavigator.Stretch = false;

            }
            this.CenterToParent();

            //bloquear  columnas
            Qds_CardTypesDataGridView.ReadOnly = true;
            short indice = 0;
            //id
            Qds_CardTypesDataGridView.Columns[indice].HeaderText = "Id";
            Qds_CardTypesDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            Qds_CardTypesDataGridView.Columns[indice].Width = 80;
            indice++;
            //description
            //Qds_CardTypesDataGridView.Columns[indice].HeaderText = "Description";
            Qds_CardTypesDataGridView.Columns[indice].Width = 400;
            indice++;

            //make dataGrid active (focus)
            this.Qds_CardTypesDataGridView.Select();



        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (Qds_CardTypesDataGridView.Rows.Count < 1)
                return;

            if (OK.Text == "&Select")
            {
                try
                {
                    containerId = (int)this.Qds_CardTypesDataGridView.CurrentRow.Cells[0].Value;
                    if (containerId < 1)
                        throw new Exception();
                    containerName = Qds_CardTypesDataGridView.CurrentRow.Cells[1].Value.ToString().Trim();
                }
                catch
                {
                    MessageBox.Show("Please select a valid customer.");
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
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatA", true))
                    return;
            }
            else
            {
                if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatC", true))
                    return;
            }

            //check data
            //name 
            cardTypeTextBox.Text = cardTypeTextBox.Text.Trim();
            if (!Funciones.ValidateText(cardTypeTextBox, ref errorProvider1))
            {
                cardTypeTextBox.Focus();
                return;
            }
            this.Validate();
            this.qds_CardTypesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qdsDataSetCardTypes);

            //goto last row
            try
            {
                if (b_Accion == "agregar")
                {
                    this.qds_CardTypesTableAdapter.Fill(this.qdsDataSetCardTypes.Qds_CardTypes);
                    this.qds_CardTypesBindingSource.MoveLast();
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
            //if (this.dataSetCardTypes.HasChanges())
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
            if (Cancel.Text == "&Close")
            {
                containerId = -1;
                Close();
            }
            else if (Cancel.Text == "&Cancel")
            {
                //cancelar alta
                if (b_Accion == "agregar")
                {
                    ((BindingSource)this.Qds_CardTypesDataGridView.DataSource).RemoveCurrent();
                    try
                    {
                        this.Qds_CardTypesDataGridView.Rows[this.Qds_CardTypesDataGridView.CurrentRow.Index].Selected = true;
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
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatA", true))
                return;

            b_Accion = "agregar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            //add row manually (AddNewItem = <none> in BindingNavigator)
            qds_CardTypesBindingSource.AddNew();

            //valores por omision
            //short indice = 3;

            ////containerType
            //this.dataSetCardTypes.Qds_CardTypes.Columns[indice].DefaultValue = 1;
            //this.Qds_CardTypesDataGridView.CurrentRow.Cells[indice++].Value = 1;

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
                BindingNavigatorSaveItem.Enabled = true;
                buttonDetails.Enabled = false;
                //buttonRefresh.Enabled = false;

                //cardTypeTextBox.Enabled = true;
                //panelDetails.Enabled = true;
                cardTypeTextBox.Focus();

                //if (cardTypeIDTextBox.Text == "0")
                //{
                //    //cardTypeTextBox.Enabled = false;
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
                BindingNavigatorSaveItem.Enabled = false;
                buttonDetails.Enabled = true;
                //buttonRefrescar.Enabled = true;

                this.Qds_CardTypesDataGridView.Focus();
            }

            this.Validate();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatC", true))
                return;

            //empty datagrid
            if (this.Qds_CardTypesDataGridView.Rows.Count < 1)
                return;

            containerId = (int)this.Qds_CardTypesDataGridView.CurrentRow.Cells[0].Value;
            if (containerId == 0)
            {
                MessageBox.Show("Cannot delete this item!");
                return;
            }

            string descripcion = this.Qds_CardTypesDataGridView.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this item: {0}?", descripcion), "Deleting Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.Qds_CardTypesDataGridView.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.Qds_CardTypesDataGridView.SelectedRows.Count > 0 &&
                            this.Qds_CardTypesDataGridView.SelectedRows[0].Index !=
                            this.Qds_CardTypesDataGridView.Rows.Count)
                        {
                            this.Qds_CardTypesDataGridView.Rows.RemoveAt(
                               this.Qds_CardTypesDataGridView.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.Qds_CardTypesDataGridView.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.qds_CardTypesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.qdsDataSetCardTypes);


                try
                {
                    this.Qds_CardTypesDataGridView.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }

        private void cardTypeTextBox_Validating(object sender, CancelEventArgs e)
        {
            Funciones.ValidateText(sender, ref errorProvider1);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (this.Qds_CardTypesDataGridView.Rows.Count < 1)
                return;

            b_Accion = "actualizar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            cambiarVista();

        }


        private void cardTypeIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cardTypeIDTextBox.Text == "0")
                panelDetails.Enabled = false;
            else
                panelDetails.Enabled = true;

        }

        private void Qds_CardTypesDataGridView_KeyUp(object sender, KeyEventArgs e)
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
    }
}

