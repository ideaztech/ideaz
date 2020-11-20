using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SirLib;
using System.Data.SqlClient;

namespace Solum
{
    public partial class PaymentMethodAvailableByDepot : Form
    {
        bool formerDepotDefault = false;
        int formerPaymentMethodID = 0;

        //Qds_PaymentMethod qds_PaymentMethod;
        Qds_PaymentMethod_Sp qds_PaymentMethod_Sp;

        Qds_PaymentMethodAvailableByDepot qds_PaymentMethodAvailableByDepot;
        Qds_PaymentMethodAvailableByDepot_Sp qds_PaymentMethodAvailableByDepot_Sp;

        Qds_Setting qds_Setting;
        Qds_Setting_Sp qds_Setting_Sp;

        string depotID;

        public int fieldId = -1;
        public string fieldName = "";

        private string b_Accion = "";

        public PaymentMethodAvailableByDepot()
        {
            InitializeComponent();
        }

        private void Containers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qdsDataSetPaymentMethods.Qds_PaymentMethods' table. You can move, or remove it, as needed.
            this.qds_PaymentMethodsTableAdapter.Fill(this.qdsDataSetPaymentMethods.Qds_PaymentMethods);

            // TODO: This line of code loads data into the 'DataSet1' table. You can move, or remove it, as needed.
            this.TableAdapter1.Fill(this.DataSet1.Qds_PaymentMethodsAvailableByDepot);

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
                BindingNavigator1.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                BindingNavigator1.Size = new System.Drawing.Size(BindingNavigator1.Size.Width, tamano + 7);
                BindingNavigator1.Stretch = false;

            }
            this.CenterToParent();

            //bloquear  columnas
            DataGridView1.ReadOnly = true;
            short indice = 0;
            //id
            //DataGridView1.Columns[indice].HeaderText = "Id";
            DataGridView1.Columns[indice].ReadOnly = true;  //.Visible = false;
            DataGridView1.Columns[indice].Width = 80;
            indice++;
            //Name
            //DataGridView1.Columns[indice].HeaderText = "Description";
            DataGridView1.Columns[indice].Width = 400;
            indice++;

            //default
            //DataGridView1.Columns[indice].HeaderText = "Description";
            DataGridView1.Columns[indice].Width = 100;
            indice++;

            //make dataGrid active (focus)
            this.DataGridView1.Select();

            //QDS
            qds_Setting_Sp = new Qds_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);
            qds_Setting = qds_Setting_Sp.Select("QuickDrop_DepotID");
            depotID = qds_Setting.SetValue.ToString();

        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count < 1)
                return;

            int paymentMethodID = (int)DataGridView1.CurrentRow.Cells[1].Value;
            if (paymentMethodID == 0)
            {
                MessageBox.Show("Please select another method!");
                return;
            }

            //Check that PaymentMethod is not assigned if change
            if (formerPaymentMethodID != paymentMethodID)
            {
                if (qds_PaymentMethodAvailableByDepot_Sp == null)
                    qds_PaymentMethodAvailableByDepot_Sp = new Qds_PaymentMethodAvailableByDepot_Sp(Properties.Settings.Default.WsirDbConnectionString);

                qds_PaymentMethodAvailableByDepot = qds_PaymentMethodAvailableByDepot_Sp.Select(depotID, paymentMethodID);

                if (qds_PaymentMethodAvailableByDepot != null)
                {
                    MessageBox.Show("Payment Method already assigned!");
                    return;
                }
            }

            //only on DepotDefault 
            bool depotDefault = (bool)DataGridView1.CurrentRow.Cells[2].Value;

            if (depotDefault
                && (formerDepotDefault != depotDefault))
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    try
                    {
                        string query =
                            "UPDATE [Qds_PaymentMethodAvailableByDepot] WITH (ROWLOCK) " +
                            "SET [DepotDefault] = 0 " +
                            "WHERE [DepotID] = '" + depotID + "' ";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        //
                    }
                    finally
                    {
                        connection.Close();
                    }
                }


            }

            if (OK.Text == "&Select")
            {
                try
                {
                    int.TryParse(this.DataGridView1.CurrentRow.Cells[0].Value.ToString(), out fieldId);
                    if (fieldId < 1)
                        throw new Exception();
                    fieldName = DataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                }
                catch
                {
                    MessageBox.Show("Please select a valid item.");
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
            ////name 
            //fieldNameTextBox.Text = fieldNameTextBox.Text.Trim();
            //if (!Funciones.ValidateText(fieldNameTextBox, ref errorProvider1))
            //{
            //    fieldNameTextBox.Focus();
            //    return;
            //}

            this.Validate();
            this.BindingSource1.EndEdit();
            this.TableAdapterManager.UpdateAll(this.DataSet1);

            //find row
            int cr = -1;
            try
            {
                cr = this.DataGridView1.CurrentRow.Index;
            }
            catch { }


            //goto last row
            try
            {
                this.TableAdapter1.Fill(this.DataSet1.Qds_PaymentMethodsAvailableByDepot);
                if (b_Accion == "agregar")
                {
                    this.BindingSource1.MoveLast();
                }
                else
                {

                    if (cr >= 0)
                    {
                        try
                        {
                            this.DataGridView1.Rows[cr].Selected = true;
                            this.BindingSource1.Position = cr;
                        }
                        catch { }
                    }
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
            //if (this.DataSet1.HasChanges())
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
                fieldId = -1;
                Close();
            }
            else if (Cancel.Text == "&Cancel")
            {
                //cancelar alta
                if (b_Accion == "agregar")
                {
                    ((BindingSource)this.DataGridView1.DataSource).RemoveCurrent();
                    try
                    {
                        this.DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Selected = true;
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

            //read next PaymentMethodID not assigned and assigned it or warn and leave
            int paymentMethodID = NextPaymentMethodID();
            if (paymentMethodID<1)
            {
                MessageBox.Show("No Payment Methods available to assigned.");
                return;
            }


            b_Accion = "agregar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            //add row manually (AddNewItem = <none> in BindingNavigator)
            BindingSource1.AddNew();

            //valores por omision
            short indice = 0;

            //DepotID
            this.DataSet1.Qds_PaymentMethodsAvailableByDepot.Columns[indice].DefaultValue = depotID;
            this.DataGridView1.CurrentRow.Cells[indice++].Value = depotID;

            //PaymentMethodID
            this.DataSet1.Qds_PaymentMethodsAvailableByDepot.Columns[indice].DefaultValue = paymentMethodID;
            this.DataGridView1.CurrentRow.Cells[indice++].Value = paymentMethodID;

            //DepotDefault
            this.DataSet1.Qds_PaymentMethodsAvailableByDepot.Columns[indice].DefaultValue = 0;
            this.DataGridView1.CurrentRow.Cells[indice++].Value = 0;


            this.Validate();

            cambiarVista();


        }

        private int NextPaymentMethodID()
        {
            //
            if (qds_PaymentMethod_Sp == null)
                qds_PaymentMethod_Sp = new Qds_PaymentMethod_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Qds_PaymentMethod> qds_PaymentMethodList = qds_PaymentMethod_Sp.SelectAll();
            if (qds_PaymentMethodList.Count < 1)
                return -1;

            if (qds_PaymentMethodAvailableByDepot_Sp == null)
                qds_PaymentMethodAvailableByDepot_Sp = new Qds_PaymentMethodAvailableByDepot_Sp(Properties.Settings.Default.WsirDbConnectionString);

            foreach (Qds_PaymentMethod pm in qds_PaymentMethodList)
            {
                if (pm.PaymentMethodID == 0)
                    continue;

                qds_PaymentMethodAvailableByDepot = qds_PaymentMethodAvailableByDepot_Sp.Select(depotID, pm.PaymentMethodID);

                if (qds_PaymentMethodAvailableByDepot == null)
                    return pm.PaymentMethodID;

            }


            return -1;
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

                //fieldNameTextBox.Focus();


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

                this.DataGridView1.Focus();
            }

            this.Validate();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCatC", true))
                return;

            //empty datagrid
            if (this.DataGridView1.Rows.Count < 1)
                return;

            int.TryParse(this.DataGridView1.CurrentRow.Cells[0].Value.ToString(), out fieldId);
            if (fieldId == 0)
            {
                MessageBox.Show("Cannot delete this item!");
                return;
            }

            string descripcion = this.DataGridView1.CurrentRow.Cells[1].Value.ToString();


            if (MessageBox.Show(String.Format("Are you sure you want to delete this item: {0}?", descripcion), "Deleting Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                int cnt = this.DataGridView1.SelectedRows.Count;
                if (cnt > 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.DataGridView1.SelectedRows.Count > 0 &&
                            this.DataGridView1.SelectedRows[0].Index !=
                            this.DataGridView1.Rows.Count)
                        {
                            this.DataGridView1.Rows.RemoveAt(
                               this.DataGridView1.SelectedRows[0].Index);
                        }
                    }
                }
                else
                {
                    ((BindingSource)this.DataGridView1.DataSource).RemoveCurrent();
                }


                this.Validate();
                this.BindingSource1.EndEdit();
                this.TableAdapterManager.UpdateAll(this.DataSet1);


                try
                {
                    this.DataGridView1.CurrentCell.Selected = true;
                }
                catch
                {
                    //
                }
            }


        }

        private void fieldNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            Funciones.ValidateText(sender, ref errorProvider1);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (this.DataGridView1.Rows.Count < 1)
                return;

            //former values
            formerPaymentMethodID = (int)DataGridView1.CurrentRow.Cells[1].Value;
            formerDepotDefault = (bool)DataGridView1.CurrentRow.Cells[2].Value;

            b_Accion = "actualizar";
            OK.Text = "&Update";
            Cancel.Text = "&Cancel";

            cambiarVista();

        }


        private void fieldIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (fieldIDTextBox.Text == "0")
                panelDetails.Enabled = false;
            else
                panelDetails.Enabled = true;

        }

        private void DataGridView1_KeyUp(object sender, KeyEventArgs e)
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

