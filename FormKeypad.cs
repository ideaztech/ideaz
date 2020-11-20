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
    public partial class FormKeypad : Form
    {
        private static int multiplyBy =0;

        Sol_QuantityButton_Sp sol_QuantityButton_Sp;


        //private Button buttonSender;
        //private Label labelSender;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelView2;
        private System.Windows.Forms.Panel panelTableLayoutPanelView2_KeyPad;
        private System.Windows.Forms.Panel panelTableLayoutPanelView2_Buttons;

        private System.Windows.Forms.Label labeBackSpace;
        private System.Windows.Forms.Label labelX02;
        private System.Windows.Forms.Label labelX01;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPad;
        private System.Windows.Forms.Label labelClear;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelPadTotal;

        private bool flagPeriod = false, flagReiniciar = false;

        public int resultNumber = 0;

        public FormKeypad()
        {
            InitializeComponent();
        }

        private void FormKeypad_Load(object sender, EventArgs e)
        {
            tableLayoutPanelView1.Visible = false;
            CreateTableLayoutPanelView2();

            panelView.Enabled = true;

        }



        private void CreateTableLayoutPanelView2()
        {
            this.tableLayoutPanelView2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTableLayoutPanelView2_KeyPad = new System.Windows.Forms.Panel();
            this.labelClear = new System.Windows.Forms.Label();
            this.labelPad = new System.Windows.Forms.Label();
            this.labeBackSpace = new System.Windows.Forms.Label();
            this.labelX02 = new System.Windows.Forms.Label();
            this.labelX01 = new System.Windows.Forms.Label();
            this.label0 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelPadTotal = new System.Windows.Forms.Label();

            this.panelTableLayoutPanelView2_Buttons = new System.Windows.Forms.Panel();
            this.tableLayoutPanelView2.SuspendLayout();
            this.panelTableLayoutPanelView2_KeyPad.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelView2
            // 
            //this.tableLayoutPanelView2.BackColor = System.Drawing.SystemColors.WindowText;// .WindowFrame;
            this.tableLayoutPanelView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(56)))));
            this.tableLayoutPanelView2.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tableLayoutPanelView2.ColumnCount = 2;
            float size1 = 0F;
            float size2 = 0F;
            int col1 = 0;
            int col2 = 0;

            //if (Main.Sol_ControlInfo.NumericKeyPadPosition == 0)    //right
            //{
                size1 = CategoryButtons.buttonContainerWidth; // 245F;
                size2 = 367F;
                col1 = 1;
                col2 = 0;
            //}
            //else
            //{
            //    size1 = 367F;
            //    size2 = CategoryButtons.buttonContainerWidth; // 245F;
            //    col1 = 0;
            //    col2 = 1;
            //}
            this.tableLayoutPanelView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, size1));
            this.tableLayoutPanelView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, size2));
            this.tableLayoutPanelView2.Controls.Add(this.panelTableLayoutPanelView2_KeyPad, col1, 0);
            this.tableLayoutPanelView2.Controls.Add(this.panelTableLayoutPanelView2_Buttons, col2, 0);
            this.tableLayoutPanelView2.Location = new System.Drawing.Point(199, 173);
            this.tableLayoutPanelView2.Name = "tableLayoutPanelView2";
            this.tableLayoutPanelView2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanelView2.RowCount = 1;
            this.tableLayoutPanelView2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelView2.Size = new System.Drawing.Size(612, 482);
            this.tableLayoutPanelView2.TabIndex = 12;
            // 
            // panelTableLayoutPanelView2Left
            // 
            this.panelTableLayoutPanelView2_KeyPad.BackgroundImage = global::Solum.Properties.Resources.NumericKeyPad1;
            this.panelTableLayoutPanelView2_KeyPad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelClear);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelPad);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labeBackSpace);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelX01);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelX02);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label0);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label3);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label2);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label1);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label6);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label5);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label4);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label9);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label8);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.label7);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelX);
            this.panelTableLayoutPanelView2_KeyPad.Controls.Add(this.labelPadTotal);

            this.panelTableLayoutPanelView2_KeyPad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableLayoutPanelView2_KeyPad.Location = new System.Drawing.Point(3, 3);
            this.panelTableLayoutPanelView2_KeyPad.Name = "panelTableLayoutPanelView2Left";
            this.panelTableLayoutPanelView2_KeyPad.Size = new System.Drawing.Size(361, 476);
            this.panelTableLayoutPanelView2_KeyPad.TabIndex = 0;
            // 
            // labelClear
            // 
            this.labelClear.BackColor = System.Drawing.Color.Transparent;
            this.labelClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClear.Location = new System.Drawing.Point(250, 4);
            this.labelClear.Name = "labelClear";
            this.labelClear.Size = new System.Drawing.Size(102, 64);
            this.labelClear.TabIndex = 17;
            this.labelClear.Click += new System.EventHandler(this.labelClear_Click);

            // 
            // labelPadTotal
            // 
            this.labelPadTotal.BackColor = System.Drawing.Color.Transparent;
            this.labelPadTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPadTotal.Location = new System.Drawing.Point(16, 3);
            this.labelPadTotal.Name = "labelPadTotal";
            this.labelPadTotal.Size = new System.Drawing.Size(220, 29);
            this.labelPadTotal.TabIndex = 23;
            this.labelPadTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // labelPad
            // 
            this.labelPad.BackColor = System.Drawing.Color.Transparent;
            this.labelPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPad.Location = new System.Drawing.Point(16, 33);
            this.labelPad.Name = "labelPad";
            this.labelPad.Size = new System.Drawing.Size(220, 30);
            this.labelPad.TabIndex = 16;
            this.labelPad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labeBackSpace
            // 
            this.labeBackSpace.BackColor = System.Drawing.Color.Transparent;
            this.labeBackSpace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labeBackSpace.Location = new System.Drawing.Point(248, 81);
            this.labeBackSpace.Name = "labeBackSpace";
            this.labeBackSpace.Size = new System.Drawing.Size(102, 64);
            this.labeBackSpace.TabIndex = 15;
            this.labeBackSpace.Click += new System.EventHandler(this.labelBackSpace_Click);

            // 
            // labelX01
            // 
            //Sol_QuantityButton sol_QuantityButton = new Sol_QuantityButton();
            if (sol_QuantityButton_Sp == null)
                sol_QuantityButton_Sp = new Sol_QuantityButton_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Sol_QuantityButton> sol_QuantityButtonList;
            sol_QuantityButtonList = sol_QuantityButton_Sp.SelectAll();

            //string[] str = new string[2];
            //foreach (Sol_EmployeeLookup emp in sol_EmployeeLookupList)
            //{

            Sol_QuantityButton sol_QuantityButton = null;
            if (sol_QuantityButtonList != null)
                if (sol_QuantityButtonList.Count > 0)
                    sol_QuantityButton = sol_QuantityButtonList[0];
            if (sol_QuantityButton == null)
            {
                sol_QuantityButton = new Sol_QuantityButton();
                sol_QuantityButton.Description = "2x";
                sol_QuantityButton.DefaultQuantity = 2;
            }
            this.labelX01.Text = sol_QuantityButton.Description;
            //this.labelX02.ImageIndex = sol_QuantityButton.DefaultQuantity; //i'm using imageIndex to stored defaultQuantity

            this.labelX01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX01.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelX01.BackColor = System.Drawing.Color.Transparent;
            this.labelX01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelX01.Location = new System.Drawing.Point(14, 81);
            this.labelX01.Name = "labelX" + sol_QuantityButton.DefaultQuantity.ToString();
            this.labelX01.Size = new System.Drawing.Size(102, 64);
            this.labelX01.TabIndex = 14;
            this.labelX01.Click += new System.EventHandler(this.labelX_Click);   //this.labelX02_Click);

            // 
            // labelX02
            // 
            sol_QuantityButton = null;
            if (sol_QuantityButtonList != null)
                if (sol_QuantityButtonList.Count > 1)
                    sol_QuantityButton = sol_QuantityButtonList[1]; 
            if (sol_QuantityButton == null)
            {
                sol_QuantityButton = new Sol_QuantityButton();
                sol_QuantityButton.Description = "6x";
                sol_QuantityButton.DefaultQuantity = 6;
            }
            this.labelX02.Text = sol_QuantityButton.Description;
            //this.labelX02.ImageIndex = sol_QuantityButton.DefaultQuantity; //i'm using imageIndex to stored defaultQuantity

            this.labelX02.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX02.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelX02.BackColor = System.Drawing.Color.Transparent;
            this.labelX02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelX02.Location = new System.Drawing.Point(129, 81);
            this.labelX02.Name = "labelX" + sol_QuantityButton.DefaultQuantity.ToString();
            this.labelX02.Size = new System.Drawing.Size(102, 64);
            this.labelX02.TabIndex = 13;
            this.labelX02.Click += new System.EventHandler(this.labelX_Click);  //this.labelX01_Click);
            // 
            // label0
            // 
            this.label0.BackColor = System.Drawing.Color.Transparent;
            this.label0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label0.Location = new System.Drawing.Point(10, 422);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(220, 70);
            this.label0.TabIndex = 12;
            this.label0.Click += new System.EventHandler(this.label0_Click);
            this.label0.DoubleClick += new System.EventHandler(this.label0_Click);

            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Location = new System.Drawing.Point(246, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 67);
            this.label3.TabIndex = 11;
            this.label3.Click += new System.EventHandler(this.label0_Click);
            this.label3.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Location = new System.Drawing.Point(129, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 67);
            this.label2.TabIndex = 10;
            this.label2.Click += new System.EventHandler(this.label0_Click);
            this.label2.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(11, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 67);
            this.label1.TabIndex = 9;
            this.label1.Click += new System.EventHandler(this.label0_Click);
            this.label1.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point(247, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 67);
            this.label6.TabIndex = 8;
            this.label6.Click += new System.EventHandler(this.label0_Click);
            this.label6.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Location = new System.Drawing.Point(129, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 67);
            this.label5.TabIndex = 7;
            this.label5.Click += new System.EventHandler(this.label0_Click);
            this.label5.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Location = new System.Drawing.Point(11, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 67);
            this.label4.TabIndex = 6;
            this.label4.Click += new System.EventHandler(this.label0_Click);
            this.label4.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Location = new System.Drawing.Point(248, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 67);
            this.label9.TabIndex = 5;
            this.label9.Click += new System.EventHandler(this.label0_Click);
            this.label9.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Location = new System.Drawing.Point(130, 164);  //134, 157
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 67);    //98,57
            this.label8.TabIndex = 4;
            this.label8.Click += new System.EventHandler(this.label0_Click);
            this.label8.DoubleClick += new System.EventHandler(this.label0_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Location = new System.Drawing.Point(11, 165);   //15, 158
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 67);         //98, 57
            this.label7.TabIndex = 3;
            this.label7.Click += new System.EventHandler(this.label0_Click);
            this.label7.DoubleClick += new System.EventHandler(this.label0_Click);


            // 
            // labelX
            // 
            this.labelX.BackgroundImage = global::Solum.Properties.Resources.OrangeButton;
            this.labelX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX.ForeColor = System.Drawing.Color.White;
            this.labelX.Location = new System.Drawing.Point(250, 424);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(102, 67);
            this.labelX.TabIndex = 22;
            this.labelX.Text = "X";
            this.labelX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelX.Click += new System.EventHandler(this.labelXMultiply_Click);


            // 
            // panelTableLayoutPanelView2Right
            // 
            this.panelTableLayoutPanelView2_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableLayoutPanelView2_Buttons.Location = new System.Drawing.Point(370, 3);
            this.panelTableLayoutPanelView2_Buttons.Name = "panelTableLayoutPanelView2Right";
            //this.panelTableLayoutPanelView2_Buttons.Size = new System.Drawing.Size(239, 476);
            this.panelTableLayoutPanelView2_Buttons.Size = new System.Drawing.Size(CategoryButtons.buttonContainerWidth, CategoryButtons.buttonContainerHeight);
            this.panelTableLayoutPanelView2_Buttons.TabIndex = 1;

            this.panelTableLayoutPanelView2_Buttons.AutoScroll = true;

            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(959, 716);
            //this.Controls.Add(this.tableLayoutPanelView2);
            //this.Name = "Form1";
            //this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);


            this.panelView.Controls.Add(this.tableLayoutPanelView2);

            this.tableLayoutPanelView2.ResumeLayout(false);
            this.panelTableLayoutPanelView2_KeyPad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void labelClear_Click(object sender, EventArgs e)
        {
            labelPadTotal.Text = "";
            labelPad.Text = "";

            //redisplay in toolStripTextBoxCount if adjusting
            redisplayCount("");

            flagPeriod = false;
            flagReiniciar = false;
            resultNumber = 0;

            multiplyBy = 0;
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

            if(multiplyBy >0)
            {
                string multiplier = string.Empty;
                if (!string.IsNullOrEmpty(labelPad.Text))
                    multiplier = labelPad.Text + labelText;
                else
                    multiplier = labelText;

                int valorInt =0;
                int.TryParse(multiplier, out valorInt);

                if(valorInt >0)
                {
                    string subTotal = string.Format("{1} * {0} = {2}", valorInt, multiplyBy, valorInt * multiplyBy);
                    DisplayPadTotal(subTotal);
                }
            }

            DisplayPad(labelText);

        }

        private void DisplayPadTotal(string c)
        {

            if (String.IsNullOrEmpty(c))
                return;

            if (flagReiniciar)
            {
                labelPadTotal.Text = "";
                flagReiniciar = false;
            }

            labelPadTotal.Text = c;

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

            //redisplay in toolStripTextBoxCount if adjusting
            redisplayCount(labelPad.Text);

            //if (toolStripButtonResetCounter.Text != "Adjust count")
            //{
            //    toolStripTextBoxCount.Text = labelPad.Text;
            //}

        }

        private void redisplayCount(string text)
        {
            //redisplay in toolStripTextBoxCount if adjusting
            //if (toolStripButtonResetCounter.Text != "Adjust count")
            //{
            //    toolStripTextBoxCount.Text = text;
            //}

        }

        private void labelX_Click(object sender, EventArgs e)
        {
            //simulate click
            //EventArgs e1 = new EventArgs();
            //labelClear_Click(this.labelClear, e1);

            //Label label = (Label)sender;
            //string labelText = label.Name.Replace("labelX", "");
            //DisplayPad(labelText);


            if (String.IsNullOrEmpty(labelPad.Text))
                labelPad.Text = "1";

            Label label = (Label)sender;
            int Quantity = 0;
            label.Name = label.Name.Replace("labelX", "");
            Int32.TryParse(label.Name, out Quantity);
            Int32.TryParse(labelPad.Text, out resultNumber);
            resultNumber *= Quantity;
            labelPad.Text = resultNumber.ToString();

            flagReiniciar = true;

            //redisplay in toolStripTextBoxCount if adjusting
            redisplayCount(labelPad.Text);


        }

        private void labelX01_Click(object sender, EventArgs e)
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

                //redisplay in toolStripTextBoxCount if adjusting
                redisplayCount(labelPad.Text);

            }

        }

        private void labelX02_Click(object sender, EventArgs e)
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

                //redisplay in toolStripTextBoxCount if adjusting
                redisplayCount(labelPad.Text);

            }

        }

        private void labelBackSpace_Click(object sender, EventArgs e)
        {
            if (labelPad.Text.Length > 0)
            {
                if (labelPad.Text.EndsWith("."))
                    flagPeriod = false;
                string c = labelPad.Text;

                labelPad.Text = c.Remove(c.Length - 1, 1);

                if (multiplyBy > 0)
                {
                    int valorInt = 0;
                    int.TryParse(labelPad.Text, out valorInt);

                    if (valorInt > 0)
                    {
                        string subTotal = string.Format("{1} * {0} = {2}", valorInt, multiplyBy, valorInt * multiplyBy);
                        DisplayPadTotal(subTotal);
                    }
                }


                //redisplay in toolStripTextBoxCount if adjusting
                redisplayCount(labelPad.Text);

            }

        }


        private void labelXMultiply_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(labelPad.Text))
            {
                multiplyBy = 0;
                Int32.TryParse(labelPad.Text, out multiplyBy);

                string subTotal = string.Format("{0} *", multiplyBy);
                DisplayPadTotal(subTotal);

                labelPad.Text = "";
            }

        }
    }
}
