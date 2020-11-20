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
    public partial class Messages : Form
    {
        public Messages()
        {
            InitializeComponent();
        }

        private void Messages_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetMessages.sol_Messages' table. You can move, or remove it, as needed.
            this.sol_MessagesTableAdapter.Fill(this.dataSetMessages.sol_Messages);
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
                sol_MessagesBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_MessagesBindingNavigator.Size = new System.Drawing.Size(sol_MessagesBindingNavigator.Size.Width, tamano + 7);
                sol_MessagesBindingNavigator.Stretch = false;

            }



            //bloquear  columnas
            short indice = 0;
            //id
            sol_MessagesDataGridView.Columns[indice].HeaderText = "Id";
            sol_MessagesDataGridView.Columns[indice].ReadOnly = true;
            sol_MessagesDataGridView.Columns[indice].Width = 80;
            indice++;
            //name
            //sol_MessagesDataGridView.Columns[indice].HeaderText = "Name";
            sol_MessagesDataGridView.Columns[indice].ReadOnly = true;
            sol_MessagesDataGridView.Columns[indice].Width = 250;
            indice++;
            //des
            //sol_MessagesDataGridView.Columns[indice].HeaderText = "Description";
            sol_MessagesDataGridView.Columns[indice].Width = 350;
            indice++;

        }

        private void OK_Click(object sender, EventArgs e)
        {
            sol_MessagesBindingNavigatorSaveItem.PerformClick();
            Close();

        }

        private void sol_MessagesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sol_MessagesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetMessages);

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

        private void Messages_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dataSetMessages.HasChanges())
            {
                DialogResult result = MessageBox.Show("There are uncommitted changes, do you wish to continue?", "", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }


            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
