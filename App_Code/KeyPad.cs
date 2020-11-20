using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Solum
{
    public partial class KeyPad : Form
    {
        private bool flagPeriod = false, flagReiniciar= false;
        public int resultNumber = 0;

        public KeyPad()
        {
            InitializeComponent();
        }

        private void label0_Click(object sender, EventArgs e)
        {
            //System.Media.SystemSounds.Asterisk.Play(); 
            //SoundPlayer click = new SoundPlayer(Properties.Resources.click);
            //click.Play();

            if (labelPad.Text.Length > 22)
                return;

            Label label = (Label)sender;
            string labelText = "";
            switch (label.Name)
            {
                case "labelMinus":
                    labelText = "-";
                    break;
                case "labelPeriod":
                    if (!flagPeriod)
                    {
                        flagPeriod = true;
                        labelText = ".";
                    }
                    break;
                default:
                    labelText = label.Name.Replace("label", "");
                    break;
            }
            DisplayPad(labelText);

        }

        private void DisplayPad(string c)
        {

            if (String.IsNullOrEmpty(c))
                return;

            if (flagReiniciar)
            {
                labelPad.Text = "";
                flagReiniciar = false;
            }

            labelPad.Text += c;

        }

        private void labelBackSpace_Click(object sender, EventArgs e)
        {
            if (labelPad.Text.Length > 0)
            {
                if (labelPad.Text.EndsWith("."))
                    flagPeriod = false;
                string c = labelPad.Text;
                labelPad.Text = c.Remove(c.Length - 1, 1);
            }

        }

        private void labelEnter_Click(object sender, EventArgs e)
        {
            resultNumber = 0;

            if (!String.IsNullOrEmpty(labelPad.Text))
                if (!Int32.TryParse(labelPad.Text, out resultNumber))
                {
                    MessageBox.Show("Error parsing quantity, default to 1 item!");
                    resultNumber = 1;
                }

            Close();

        }

        private void labelClear_Click(object sender, EventArgs e)
        {
            labelPad.Text = "";
            flagPeriod = false;
            flagReiniciar = false;
            resultNumber = 0;
        }

        private void labelX12_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(labelPad.Text))
            {
                Label label = (Label)sender;
                int Quantity = 0;
                label.Name = label.Name.Replace("labelX", "");
                Int32.TryParse(label.Name, out Quantity);
                Int32.TryParse(labelPad.Text, out resultNumber);
                resultNumber *= Quantity;
                labelPad.Text = resultNumber.ToString();
                flagReiniciar = true;
            }
        }

        private void KeyPad_KeyPress(object sender, KeyPressEventArgs e)
        {
            string k = e.KeyChar.ToString();
            if (e.KeyChar == (char)Keys.Back)            //k == "\b")
            {
                //((IButtonControl)labelBackSpace).PerformClick();
                this.labelBackSpace_Click(this.labelBackSpace, EventArgs.Empty);
            }
            else if (e.KeyChar == (char)Keys.Return)            //k == "\r")
                this.labelEnter_Click(this.labelEnter, EventArgs.Empty);
            else if (e.KeyChar == (char)Keys.Escape)
                this.Close();
            else if (!System.Text.RegularExpressions.Regex.IsMatch(k, "\\d+"))
                e.Handled = true;
            else
                DisplayPad(k);
        }
    }
}
