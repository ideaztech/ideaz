using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solum
{
    public partial class ShippingMultiProductStagedContainersTagNumber : Form
    {
        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;
        public bool cancelFlag { get; private set; }
        public string tagNumber { get; private set; }

        public ShippingMultiProductStagedContainersTagNumber()
        {
            InitializeComponent();
            cancelFlag = true;
        }

        private void ShippingMultiProductStagedContainersTagNumber_Load(object sender, EventArgs e)
        {
            textBoxTagNumber.Focus();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxTagNumber.Text))
            {
                MessageBox.Show("Please, enter a valid tag number!");
                textBoxTagNumber.Focus();
                return;
            }

            if(sol_Stage_Sp == null)
                sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_Stage = sol_Stage_Sp._SelectByTagNumberStatus(textBoxTagNumber.Text, "");   //I");
            if (sol_Stage != null)
            {
                MessageBox.Show("Tag number already exists, try another one please.");
                textBoxTagNumber.Focus();
                return;
            }

            tagNumber = textBoxTagNumber.Text;
            cancelFlag = false;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //cancelFlag = true;
            Close();
        }

    }
}
