using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solum
{
    public partial class Entries : Form
    {
        DateTimePicker dateTimePcr;
        public Entries()
        {
            InitializeComponent();
        }

        private void sol_EntriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditEntries", true))
                return;

            this.Validate();
            
            if (sol_EntriesDetailDataGridView.Rows.Count > 0)
            {

                this.sol_EntriesDetailBindingSource.EndEdit();
                this.sol_EntriesDetailTableAdapter.Update(this.dataSetEntriesEntryDetail);

                this.sol_EntriesDetailTableAdapter.Fill(this.dataSetEntriesEntryDetail.sol_EntriesDetail);

                CalculateTotal();

                decimal total = 0;
                string amount = textBoxTotal.Text.Replace("$", "");
                amount = amount.Replace(",", "");

                decimal.TryParse(amount, out total);

                this.sol_EntriesDataGridView.CurrentRow.Cells[5].Value = total;
            }

            this.sol_EntriesBindingSource.EndEdit();
            this.sol_EntriesTableAdapter.Update(this.dataSetEntriesEntryDetail);

            //this.sol_EntriesTableAdapter.FillByDate(this.dataSetEntriesEntryDetail.sol_Entries, dateTimePcr.Value);

            //this.tableAdapterManager.UpdateAll(this.dataSetEntriesEntryDetail);

        }

        private void Entries_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCashDenominationsSelectAllDescription.sol_CashDenominations_SelectAllDescription' table. You can move, or remove it, as needed.


            this.dataSetCashDenominationsSelectAllDescription.Clear();
            this.sol_CashDenominations_SelectAllDescriptionTableAdapter.Fill(this.dataSetCashDenominationsSelectAllDescription.sol_CashDenominations_SelectAllDescription);

            // TODO: This line of code loads data into the 'dataSetCashTrays.sol_CashTrays_SelectAll' table. You can move, or remove it, as needed.
            this.sol_CashTrays_SelectAllTableAdapter.Fill(this.dataSetCashTrays.sol_CashTrays_SelectAll);
            // TODO: This line of code loads data into the 'dataSetUsersLookup.aspnet_Users' table. You can move, or remove it, as needed.
            this.aspnet_UsersTableAdapter.Fill(this.dataSetUsersLookup.aspnet_Users);
            // TODO: This line of code loads data into the 'dataSetExpenseTypes.sol_ExpenseTypes_SelectAll' table. You can move, or remove it, as needed.
            this.sol_ExpenseTypes_SelectAllTableAdapter.Fill(this.dataSetExpenseTypes.sol_ExpenseTypes_SelectAll);
            // TODO: This line of code loads data into the 'dataSetEntriesEntryDetail.sol_EntriesDetail' table. You can move, or remove it, as needed.
            //this.sol_EntriesDetailTableAdapter.Fill(this.dataSetEntriesEntryDetail.sol_EntriesDetail);
            // TODO: This line of code loads data into the 'dataSetEntriesEntryDetail.sol_Entries' table. You can move, or remove it, as needed.
            //this.sol_EntriesTableAdapter.Fill(this.dataSetEntriesEntryDetail.sol_Entries);

            // TODO: This line of code loads data into the 'dataSetUsersLookup.aspnet_Users' table. You can move, or remove it, as needed.
            //comboBoxEntriesType.DataSource = Main.entriesType;
            //comboBoxEntriesType.SelectedIndex = -1;
            entriesTypeBindingSource.DataSource = Main.entriesType;

            //populate types
            toolStripComboBoxTypes.Items.Add("View All");
            foreach (EntriesType et in Main.entriesType)
            {
                toolStripComboBoxTypes.Items.Add(et.Description);
            }


            //from date
            //años                                                      //ejemplo:
            int aa = Main.rc.FechaActual.Year;                          // 2010 año actual computadora
            byte ah = Main.Sol_ControlInfo.HistoryYears;                    //   -5 años de historia
            //-----
            int uah = aa - ah;                                          // 2005 ultimo año de historia
            dateTimePcr = new DateTimePicker();
            dateTimePcr.Format = DateTimePickerFormat.Short;
            dateTimePcr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dateTimePcr.Width = 120;
            dateTimePcr.MinDate = DateTime.Parse(String.Format("{0}-1-1", uah));
            int dd = Main.rc.FechaActual.Day;
            int mm = Main.rc.FechaActual.Month;
            aa = Main.rc.FechaActual.Year;
            dateTimePcr.MaxDate = DateTime.Parse(String.Format("{0}-{1}-{2} 00:00", aa, mm, dd));
            dateTimePcr.Value = dateTimePcr.MaxDate;
            dateTimePcr.ValueChanged += new System.EventHandler(dateTimePcr_ValueChanged);
            fillByTypeToolStrip.Items.Add(new ToolStripControlHost(dateTimePcr));

            //select View all
            toolStripComboBoxTypes.SelectedIndex = 0;

            if (Properties.Settings.Default.TouchOriented)
            {
                this.Height = this.Height + (OK.Height);
                this.OK.Height = OK.Height +(OK.Height/2);
                this.Cancel.Height = Cancel.Height + (Cancel.Height / 2);
                this.OK.Location = new System.Drawing.Point(407, 1);
                this.Cancel.Location = new System.Drawing.Point(505, 1);

                toolStripButtonVirtualKb.Visible = true;
                this.CenterToParent();

            }
            else
            {
                int tamano = 16;
                sol_EntriesBindingNavigator.ImageScalingSize = new System.Drawing.Size(tamano, tamano);
                sol_EntriesBindingNavigator.Size = new System.Drawing.Size(sol_EntriesBindingNavigator.Size.Width, tamano + 7);
                sol_EntriesBindingNavigator.Stretch = false;

            }


        }

        private void sol_EntriesDetailDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void CalculateTotal()
        {
            if (this.sol_EntriesBindingSource.Position > -1)
            {
                decimal total = 0;
                foreach (DataRowView row in sol_EntriesDetailBindingSource)
                {
                    total += Convert.ToDecimal(row["Total"]);
                }
                textBoxTotal.Text = String.Format("{0:c}", total);
            }
            else
            {
                textBoxTotal.Text = "";
            }
        }


        private void sol_EntriesBindingSource_PositionChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void toolStripComboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataSet();
            CalculateTotal();
        }

        private void dateTimePcr_ValueChanged(object sender, EventArgs e)
        {
            FillDataSet();
            CalculateTotal();
        }

        private void FillDataSet()
        {
            try
            {
                if (toolStripComboBoxTypes.SelectedIndex == 0)
                {
                    //// TODO: This line of code loads data into the 'dataSetEntriesEntryDetail.sol_EntriesDetail' table. You can move, or remove it, as needed.
                    //this.sol_EntriesDetailTableAdapter.Fill(this.dataSetEntriesEntryDetail.sol_EntriesDetail);
                    //// TODO: This line of code loads data into the 'dataSetEntriesEntryDetail.sol_Entries' table. You can move, or remove it, as needed.
                    //this.sol_EntriesTableAdapter.Fill(this.dataSetEntriesEntryDetail.sol_Entries);
                    this.sol_EntriesTableAdapter.FillByDate(this.dataSetEntriesEntryDetail.sol_Entries, dateTimePcr.Value);
                    this.sol_EntriesDetailTableAdapter.Fill(this.dataSetEntriesEntryDetail.sol_EntriesDetail);
                }
                else
                {
                    string t = "";
                    switch (toolStripComboBoxTypes.SelectedIndex)
                    {
                        case 1:
                            t = "O";    //Open Cashier
                            break;
                        case 2:
                            t = "F";    //Float
                            break;
                        case 3:
                            t = "C";    //Close Cashier
                            break;
                        case 4:
                            t = "E";    //Expenses
                            break;
                        default:
                            t = "";
                            break;
                    }

                    //this.sol_EntriesTableAdapter.FillByType(this.dataSetEntriesEntryDetail.sol_Entries, t);
                    
                    //this.sol_EntriesTableAdapter.FillByTypeDate(this.dataSetEntriesEntryDetail.sol_Entries, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(dateToolStripTextBox.Text, typeof(System.DateTime))))), typeToolStripTextBox1.Text);
                    this.sol_EntriesTableAdapter.FillByTypeDate(this.dataSetEntriesEntryDetail.sol_Entries, dateTimePcr.Value, t);
                    this.sol_EntriesDetailTableAdapter.Fill(this.dataSetEntriesEntryDetail.sol_EntriesDetail);

                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void OK_Click(object sender, EventArgs e)
        {
            sol_EntriesBindingNavigatorSaveItem.PerformClick();
        }

        //private void sol_EntriesDetailDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex >= 0 && e.ColumnIndex <= 1)
        //    {
        //        if(sol_CashDenomination_Sp == null)
        //            sol_CashDenomination_Sp = new Sol_CashDenomination_Sp(Properties.Settings.Default.WsirDbConnectionString);


        //        string c = sol_EntriesDetailDataGridView[0, e.RowIndex].Value.ToString();


        //        //CalculateTotal();
                
        //    }


        //}

    }
}
