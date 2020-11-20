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
    public partial class CashierGetDates : Form
    {
        public bool cancelFlag { get; private set; }
        public DateTime dateFrom { get; private set; }
        public DateTime dateTo { get; private set; }

        public CashierGetDates()
        {
            InitializeComponent();
            cancelFlag = true;
        }


        private void CashierGetDates_Load(object sender, EventArgs e)
        {
            //años
            int aa = Main.rc.FechaActual.Year;
            byte ah = Main.Sol_ControlInfo.HistoryYears;
            if (ah < 1) ah = 1;
            int uah = aa - ah;

            this.dateTimePickerFrom.ValueChanged -= new System.EventHandler(this.dateTimePickerFrom_ValueChanged);

            dateTimePickerFrom.MinDate = DateTime.Parse(String.Format("{0}-1-1 00:00:00 ", uah));
            dateTimePickerFrom.MaxDate = DateTime.Parse(String.Format("{0}-{1}-{2} 23:59:59 ", Main.rc.FechaActual.Year, Main.rc.FechaActual.Month, Main.rc.FechaActual.Day));
            dateTimePickerFrom.Value = Main.rc.FechaActual;

            dateTimePickerTo.MinDate = DateTime.Parse(String.Format("{0}-{1}-{2} 00:00:00 ", dateTimePickerFrom.MaxDate.Year, dateTimePickerFrom.MaxDate.Month, dateTimePickerFrom.MaxDate.Day));
            dateTimePickerTo.MaxDate = dateTimePickerFrom.MaxDate;
            dateTimePickerTo.Value = dateTimePickerFrom.Value;

            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);

            cancelFlag = true;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            dateFrom = dateTimePickerFrom.Value;
            dateTo = dateTimePickerTo.Value;
            cancelFlag = false;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //cancelFlag = true;
            Close();

        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.MinDate = DateTime.Parse(String.Format("{0}-{1}-{2} 00:00:00 ", dateTimePickerFrom.Value.Year, dateTimePickerFrom.Value.Month, dateTimePickerFrom.Value.Day));
            DateTime dt = dateTimePickerFrom.Value.AddDays(14);
            if (dt > Main.rc.FechaActual)
                dt = Main.rc.FechaActual;
            //dateTimePickerTo.MaxDate = dt;

            dateTimePickerTo.Value = dt;    // dateTimePickerTo.MaxDate;

        }

        private void CashierGetDates_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cancelFlag = true;

        }

  
    }
}
