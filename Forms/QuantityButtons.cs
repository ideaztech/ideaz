
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using SirLib;

namespace Solum
{
    public partial class QuantityButtons : Form
    {
        private string controlName = "";
        private ArrayList arrayListItems, arrayListControls;
        private int QuantityButtonID = 0, indice = 0;
        List<Sol_QuantityButton> sol_QuantityButtonList;
        //Sol_QuantityButton sol_QuantityButton;
        Sol_QuantityButton_Sp sol_QuantityButton_Sp;

        public QuantityButtons()
        {
            InitializeComponent();
        }

        private void QuantityButtons_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }

            // TODO: This line of code loads data into the 'dataSetWorkStationsLookup.sol_WorkStations' table. You can move, or remove it, as needed.
            this.sol_WorkStationsTableAdapter.Fill(this.dataSetWorkStationsLookup.sol_WorkStations);

            //default definition
            comboBoxWorkStation.SelectedValue = 1;

            //read controls for workstation
            ReadControlsQuantity();

        }

        private void buttonAddButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Please enter a description");
                textBoxDescription.Focus();
                return;
            }

            if (String.IsNullOrEmpty(textBoxDefaultQuantity.Text))
            {
                MessageBox.Show("Please enter a Quantity");
                textBoxDescription.Focus();
                return;
            }


            Sol_QuantityButton sol_QuantityButton = new Sol_QuantityButton();
            //try
            //{
            //    sol_QuantityButton.WorkStationID = Convert.ToInt32(comboBoxWorkStation.SelectedValue.ToString());
            //}
            //catch
            //{
            //    sol_QuantityButton.WorkStationID = 1;
            //}
            sol_QuantityButton.WorkStationID = -1;
            sol_QuantityButton.ControlType = 1;
            sol_QuantityButton.Description = textBoxDescription.Text;

            try
            {
                sol_QuantityButton.DefaultQuantity = Convert.ToInt32(textBoxDefaultQuantity.Text);
            }
            catch
            {
                sol_QuantityButton.DefaultQuantity = 1;
            }


            sol_QuantityButton.CategoryID = 0;// comboBoxCategory.SelectedIndex;

            sol_QuantityButton.LocationX = 0;
            sol_QuantityButton.LocationY = 0;
            sol_QuantityButton.Width = 0;
            sol_QuantityButton.Height = 0;

            sol_QuantityButton.Font = "[Font: Name=Microsoft Sans Serif, Size=7.8, Units=3, GdiCharSet=0, GdiVerticalFont=False]";
            sol_QuantityButton.FontStyle = "Regular";
            //sol_QuantityButton.ForeColor = label5.ForeColor.ToArgb().ToString("x");
            //sol_QuantityButton.BackColor = label5.BackColor.ToArgb().ToString("x");
            sol_QuantityButton_Sp.Insert(sol_QuantityButton);

            ReadControlsQuantity();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {
                MessageBox.Show("Please select a button.");
                return;
            }

            QuantityButtonID = ((Sol_QuantityButton)arrayListControls[indice]).QuantityButtonID;

            sol_QuantityButton_Sp.Delete(QuantityButtonID);

            panelQuantityButtons.Controls.Remove(((System.Windows.Forms.Button)this.arrayListItems[indice]));
            ((System.Windows.Forms.Button)this.arrayListItems[indice]).Dispose();

            ReadControlsQuantity();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {
                MessageBox.Show("Please select button.");
                return;
            }

            if (String.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Please enter a description");
                textBoxDescription.Focus();
                return;
            }

            if (String.IsNullOrEmpty(textBoxDefaultQuantity.Text) && controlName == "Button")
            {
                MessageBox.Show("Please enter a default quantity");
                textBoxDefaultQuantity.Focus();
                return;
            }

            ((Sol_QuantityButton)arrayListControls[indice]).Description = textBoxDescription.Text;
            ((System.Windows.Forms.Button)this.arrayListItems[indice]).Text = textBoxDescription.Text;
            try
            {
                ((Sol_QuantityButton)arrayListControls[indice]).DefaultQuantity = Convert.ToInt32(textBoxDefaultQuantity.Text);
            }
            catch
            {
                ((Sol_QuantityButton)arrayListControls[indice]).DefaultQuantity = 1;
            }

            //category
            ((Sol_QuantityButton)arrayListControls[indice]).CategoryID = 0;

            switch (controlName)
            {
                case "Button":
                    ((Sol_QuantityButton)arrayListControls[indice]).Font = ((System.Windows.Forms.Button)this.arrayListItems[indice]).Font.ToString();
                    ((Sol_QuantityButton)arrayListControls[indice]).ForeColor = ((System.Windows.Forms.Button)this.arrayListItems[indice]).ForeColor.ToString();
                    ((Sol_QuantityButton)arrayListControls[indice]).BackColor = ((System.Windows.Forms.Button)this.arrayListItems[indice]).BackColor.ToString();
                    break;
                default:
                    break;
            }


            sol_QuantityButton_Sp.Update(((Sol_QuantityButton)arrayListControls[indice]));

            MessageBox.Show("Updated!");

        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {
                MessageBox.Show("Please select a button.");
                return;
            }


            switch (controlName)
            {
                case "Button":
                    ((System.Windows.Forms.Button)this.arrayListItems[indice]).Font = Funciones.FontParser("[Font: Name=Microsoft Sans Serif, Size=7.8, Units=3, GdiCharSet=0, GdiVerticalFont=False]", "Regular");
                    ((System.Windows.Forms.Button)this.arrayListItems[indice]).ForeColor = Funciones.ColorParser("Color [ControlText]");
                    ((System.Windows.Forms.Button)this.arrayListItems[indice]).BackColor = Funciones.ColorParser("Color [fff0f0f0]");
                    break;
                default:
                    break;
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        //read controls for workstation
        private void ReadControlsQuantity()
        {
            panelQuantityButtons.Controls.Clear();

            sol_QuantityButtonList = new List<Sol_QuantityButton>();
            Sol_QuantityButton sol_QuantityButton = new Sol_QuantityButton();
            sol_QuantityButton_Sp = new Sol_QuantityButton_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //sol_QuantityButtonList = sol_QuantityButton_Sp._SelectAllByWorkStationID(/*Convert.ToInt32(comboBoxWorkStation.SelectedValue.ToString())*/-1);
            sol_QuantityButtonList = sol_QuantityButton_Sp.SelectAll();

            this.arrayListItems = new ArrayList();
            this.arrayListControls = new ArrayList();

            int numberOfButtons = 1;
            int scrollBardLength = 20;
            int separationLength = 20;
            decimal ajuste = 0.95m;
            decimal ajusteHeight = 0.79m;
            int buttonWidth = (panelQuantityButtons.Size.Width - separationLength - scrollBardLength) / numberOfButtons, buttonHeight = 76; // 55;
            buttonWidth = (int)(buttonWidth * ajuste);
            buttonHeight = (int)(buttonHeight * ajusteHeight);



            //int buttonWidth = 100, buttonHeight = 62;
            int separatorX = 10, separatorY = 10;





            int locationX = panelQuantityButtons.Location.X, locationY = panelQuantityButtons.Location.Y;

            int col = 0;
            int i = 0;
            foreach (Sol_QuantityButton cb in sol_QuantityButtonList)
            {
                arrayListControls.Add(cb);

                switch (cb.ControlType)
                {
                    case 1: //Button

                        if (i == 0)
                            locationY -= separatorY;


                        this.arrayListItems.Add(new System.Windows.Forms.Button());
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Location = new System.Drawing.Point(
                            //panel1.Location.X + cb.LocationX,
                            //panel1.Location.Y + cb.LocationY
                        locationX + separatorX,
                        locationY + separatorY
                        );

                        locationX += buttonWidth + separatorX;
                        col++;
                        if (col > 0)
                        {
                            col = 0;
                            locationX = panelQuantityButtons.Location.X;
                            locationY += buttonHeight + separatorY;
                        }

                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Name = "Button_" + Convert.ToString(i);
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Size = new System.Drawing.Size(buttonWidth, buttonHeight);    //cb.Width, cb.Height);
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).TabIndex = i + 2;
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Text = cb.Description.Trim();

                        //((System.Windows.Forms.Button)this.arrayListItems[i]).BackColor = SystemColors.Control;
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).ForeColor = Funciones.ColorParser(cb.ForeColor);
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).BackColor = Funciones.ColorParser(cb.BackColor);

                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Click += new System.EventHandler(this.buttonQuantity_Click);

                        //this.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i]));
                        panelQuantityButtons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i++]));

                        break;

                }
            }

            //panel1.SendToBack();

        }

        private void buttonQuantity_Click(object sender, EventArgs e)
        {
            controlName = "Button";
            Button btn = (Button)sender;
            string[] strControl = btn.Name.Split('_');
            indice = Convert.ToInt32(strControl[1]);

            foreach (System.Windows.Forms.Control ctrl in panelQuantityButtons.Controls)
            {
                //ctrl.BackColor = SystemColors.Control;
                try
                {
                    ((Label)ctrl).BorderStyle = BorderStyle.FixedSingle;
                }
                catch
                { }
            }



            textBoxDescription.Text = btn.Text;
            textBoxDefaultQuantity.Text = ((Sol_QuantityButton)arrayListControls[indice]).DefaultQuantity.ToString();


        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {
                MessageBox.Show("Please select a button.");
                return;
            }

            fontDialog1.ShowColor = true;

            switch (controlName)
            {
                case "Button":
                    fontDialog1.Font = ((System.Windows.Forms.Button)this.arrayListItems[indice]).Font;
                    fontDialog1.Color = ((System.Windows.Forms.Button)this.arrayListItems[indice]).ForeColor;
                    break;
                default:
                    break;
            }


            try
            {
                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    string c = fontDialog1.Color.ToString();

                    switch (controlName)
                    {
                        case "Button":
                            ((System.Windows.Forms.Button)this.arrayListItems[indice]).Font = Funciones.FontParser(fontDialog1.Font.ToString(), fontDialog1.Font.Style.ToString());
                            ((System.Windows.Forms.Button)this.arrayListItems[indice]).ForeColor = Funciones.ColorParser(c);
                            break;
                        default:
                            break;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Only TrueType fonts are supported.");
            }

        }

        private void comboBoxWorkStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadControlsQuantity();

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

        private void QuantityButtons_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

        }

    }
}
