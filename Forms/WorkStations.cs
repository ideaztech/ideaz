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

namespace Solum
{
    public partial class WorkStations : Form
    {
        private bool b_Add = false;

        public WorkStations()
        {
            InitializeComponent();
        }

        private void WorkStations_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetWorkStations.sol_WorkStations' table. You can move, or remove it, as needed.
            this.sol_WorkStationsTableAdapter.Fill(this.dataSetWorkStations.sol_WorkStations);

            if (Properties.Settings.Default.TouchOriented)
            {
                this.Height = this.Height + (OK.Height) + 150;
                OK.Height = OK.Height * 2;
                buttonDetails.Height = buttonDetails.Height * 2;

                Cancel.Height = Cancel.Height * 2;
                toolStripButtonVirtualKb.Visible = true;
                this.CenterToParent();

            }
            else
            {
                int tamano = 16;
                sol_WorkStationsBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_WorkStationsBindingNavigator.Size = new System.Drawing.Size(sol_WorkStationsBindingNavigator.Size.Width, tamano + 7);
                sol_WorkStationsBindingNavigator.Stretch = false;

            }


            //bloquear  columnas
            sol_WorkStationsDataGridView.ReadOnly = true;

            short indice = 0;
            //WorkStationID;
            sol_WorkStationsDataGridView.Columns[indice].HeaderText = "Id";
            sol_WorkStationsDataGridView.Columns[indice].ReadOnly = true;  //.Visible = false;
            sol_WorkStationsDataGridView.Columns[indice].Width = 80;
            indice++;
            //name
            sol_WorkStationsDataGridView.Columns[indice].HeaderText = "Name";
            sol_WorkStationsDataGridView.Columns[indice].Width = 200;
            indice++;
            //description;
            sol_WorkStationsDataGridView.Columns[indice].HeaderText = "Description";
            sol_WorkStationsDataGridView.Columns[indice].Width = 350;
            indice++;

            //Location;
            sol_WorkStationsDataGridView.Columns[indice].Visible = false;
            indice++;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            bool flag = panelDetails.Visible;
            if (flag)
            {
                if (!ValidateForm())
                    return;

                cambiarVista();
            }

            ////hay cambios?
            //if (dataSetProducts.HasChanges())
            //{
            this.Validate();
            this.sol_WorkStationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetWorkStations);
            try
            {
                //if (Convert.ToInt32(productIDTextBox.Text) < 0)
                if (b_Add)
                {
                    b_Add = false;
                    this.sol_WorkStationsTableAdapter.Fill(this.dataSetWorkStations.sol_WorkStations);
                    this.sol_WorkStationsBindingSource.MoveLast();
                }
            }
            catch
            {
                //
            }

            //}
            if (!flag)
                Close();

        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (sol_WorkStationsDataGridView.Rows.Count <= 1)
                return;

            cambiarVista();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void WorkStations_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dataSetWorkStations.HasChanges())
            {
                DialogResult result = MessageBox.Show("There are uncommitted changes, do you wish to continue?", "", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }


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
            }

            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            b_Add = true;

            ////valores por omision
            //this.dataSetWorkStations.sol_WorkStations.Columns[11].DefaultValue = false;
            ////isactive
            //this.sol_WorkStationsDataGridView.CurrentRow.Cells[11].Value = false;

            this.Validate();
            cambiarVista();

        }

        private void sol_WorkStationsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            this.Validate();
            this.sol_WorkStationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetWorkStations);
            cambiarVista();
        }

        private void sol_WorkStationsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDetails.PerformClick();
        }

        private void sol_WorkStationsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
                buttonDetails.Text = "&WorkStations";
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
                }
                catch
                {
                    //
                }
            }

            bindingNavigatorAddNewItem.Enabled = flag;
            bindingNavigatorDeleteItem.Enabled = flag;

            sol_WorkStationsDataGridView.Visible = !sol_WorkStationsDataGridView.Visible;
            panelDetails.Visible = !panelDetails.Visible;

            if (sol_WorkStationsDataGridView.Visible)
                sol_WorkStationsDataGridView.Focus();
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
            //cajasDeTexto.Add(descriptionTextBox);
            //cajasDeTexto.Add(locationTextBox);

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
    }
}
