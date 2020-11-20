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
    public partial class CashierQdCustomer : Form
    {
        public string fieldName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string postalCode { get; set; }
        public bool result { get; set; }

        public CashierQdCustomer()
        {
            InitializeComponent();
            fieldName = string.Empty;
            address1 = string.Empty;
            address2 = string.Empty;
            city = string.Empty;
            phone = string.Empty;
            postalCode = string.Empty;
        }

        private void CashierQdCustomer_Load(object sender, EventArgs e)
        {

            fieldNameTextBox.Text = fieldName;
            address1TextBox.Text = address1;
            address2TextBox.Text = address2;
            cityTextBox.Text = city;
            phoneNumberTextBox.Text = phone;
            postalCodeTextBox.Text = postalCode;

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            result = true;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            result = false;
            Close();

        }


    }
}
