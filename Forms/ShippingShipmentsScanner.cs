using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Runtime.InteropServices;

namespace Solum
{
    public partial class ShippingShipmentsScanner : Form
    {
        private Sol_Stage sol_Stage;
        private Sol_Stage_Sp sol_Stage_Sp;

        //private string[] badTags;
        public ShippingShipmentsScanner()
        {
            InitializeComponent();
        }

        private void ShippingShipmentsScanner_Load(object sender, EventArgs e)
        {
            //disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //classes of tables
            sol_Stage = new Sol_Stage();
            sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "txt";

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "scanner.txt";

            string data = textBoxInput.Text;
            if (String.IsNullOrEmpty(data))
            {
                MessageBox.Show("Nothing to save! TextBox empty.");
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        myStream.Close();
                        StreamWriter writer = new StreamWriter(saveFileDialog1.FileName.ToString());
                        // Code to write the stream goes here.
                        writer.Write(data);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
                }

            }

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.AddExtension = true;
            openFileDialog1.DefaultExt = "txt";

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        // Insert code to read the stream here.
                        myStream.Close();

                        StreamReader sr = new
                        StreamReader(openFileDialog1.FileName);
                        textBoxInput.Text = sr.ReadToEnd();
                        sr.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }

        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxInput.Text))
            {
                MessageBox.Show("Nothing to parse! TextBox empty.");
                return;
            }

            // Display the ProgressBar control.
            progressBar1.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressBar1.Minimum = 1;
            // Set the initial value of the ProgressBar.
            progressBar1.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar1.Step = 1;

            
            string[] tags = textBoxInput.Text.Split('\n');
            string strBadTags ="";
            //badTags = new string[tags.GetLength(0)];
            // Set Maximum to the total number of files to copy.
            progressBar1.Maximum = tags.GetLength(0);
            bool flagAdded = false;
            foreach (string ren in tags)
            {
                // Perform the increment on the ProgressBar.
                progressBar1.PerformStep();
                string renx = ren.Trim();
                if (String.IsNullOrEmpty(renx))
                    continue;

                int ps = renx.LastIndexOf(',');
                if (ps < 0) ps = -1;
                string tagNumber= renx.Substring(ps+1);
                if (String.IsNullOrEmpty(tagNumber))
                    continue;

                //was a barcode read?
                //string x = tagNumber;
                //if (x.Length > 7)
                //{
                //    x = x.Substring(x.Length - 7);
                //    int intValue = 0;
                //    Int32.TryParse(x, out intValue);
                //    if (intValue > 0)
                //        tagNumber = String.Format("{0}", intValue);
                //    else
                //        continue;

                //}

                ps=0;
                sol_Stage = sol_Stage_Sp._SelectByTagNumberStatus(tagNumber, "I");
                if (
                    //SearchStagedContainerOnShipment(tagNumber) || 
                    sol_Stage == null)
                {

                    //badTags[ps++] = tagNumber + " - Tag number does not exist or already in shipment\n";
                    strBadTags += tagNumber + " - Tag number does not exist or already in shipment" + Environment.NewLine;
                    
                    continue;

                }
                //switch containers
                ShippingShipments.SwitchContainers(
                    ref ShippingShipments.listViewCurrentStagedContainers, 
                    ref ShippingShipments.listViewContainersOnShipment, sol_Stage.TagNumber, true, null);

                flagAdded = true;
            }

            // Perform the increment on the ProgressBar.
            progressBar1.Value = progressBar1.Maximum;


            //tags not processed
            if (!String.IsNullOrEmpty(strBadTags))
            {
                SirLib.CajaDeMensaje.Show("Tags not processed", "Error parsing tags numbers.", strBadTags, SirLib.CajaDeMensajeImagen.Error);

            }

            string men = "Done!";
            if(flagAdded)
            {
                if (String.IsNullOrEmpty(strBadTags))
                    men += " - All tags added.";
                else
                    men += " - With some tags not added.";
            }
            else
                men +=  " - Nothing added";


            MessageBox.Show(men);
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar1.Value = 1;
            textBoxInput.Text = "";




        }

    }
}
