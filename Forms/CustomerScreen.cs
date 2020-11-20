using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Collections;

using SirLib;


namespace Solum
{
    public partial class CustomerScreen : Form
    {
        public static System.Windows.Forms.Timer timerBlink;
        public static Label tslCntr = null;
        private static int intCntr = 0;

        public static string customerScreenSourceForm { set; get; }

        //public  System.Windows.Forms.Label labelClerk;

        public static SplitContainer splitContainerCustomerScreen;

        public static Panel panelQuantityCustomerScreen;
        public static Panel panelAmountCustomerScreen;

        public static ListView listViewReturns;

        public static Label labelTotalQty, labelTotalAmt;

        private ArrayList FolderImageFiles;

        //string[] files;
        int index = 0;
        int MaxIndex = 0;

        //System.IO.FileInfo fileInfo;
        //System.IO.FileStream fileStream;

        public CustomerScreen(string User)  //, string Today )
        {
            InitializeComponent();

            //// labelClerk
            //// 
            //labelClerk = new System.Windows.Forms.Label();
            //this.labelClerk.AutoSize = true;
            //this.labelClerk.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.labelClerk.Location = new System.Drawing.Point(97, 9);
            //this.labelClerk.Name = "labelClerk";
            //this.labelClerk.Size = new System.Drawing.Size(174, 36);
            //this.labelClerk.TabIndex = 7;
            //this.labelClerk.Text = "Clerk name";

            //this.panelClerk.Controls.Add(this.labelClerk);

            if(User.Length>10)
                toolStripStatusLabelUser.Text = User.Substring(0, 10);   //User.Trim()+".";
            else
                toolStripStatusLabelUser.Text = User;   //User.Trim()+".";
            //toolStripStatusLabelDate.Text = Today;

            //customerScreenSourceForm = "nada";//String.Empty;
            switch(Properties.Settings.Default.SettingsAdCustomerScreenImageSizeMode)
            {
                case 0:
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    break;
                case 1:
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 2:
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case 3:
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
                case 4:
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                default:
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    break;
            }
        }

        private void CustomerScreen_Load(object sender, EventArgs e)
        {

            //FullScreenMode
            //if (Properties.Settings.Default.SettingsAdFullScreenMode)
            this.WindowState = FormWindowState.Maximized;
            //else
            //    this.WindowState = FormWindowState.Normal;

            splitContainerCustomerScreen = splitContainer1;
            panelQuantityCustomerScreen = panelQuantity;
            panelAmountCustomerScreen = panelAmount;

            int paddingQuantity = 25;   // 45;

            // Create a new ListView control.
            listViewReturns = new ListView();
            //listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            listViewReturns.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            // Set the view to show details.
            listViewReturns.View = View.Details;
            // Allow the user to edit item text.
            listViewReturns.LabelEdit = false;
            // Allow the user to rearrange columns.
            listViewReturns.AllowColumnReorder = false;
            // Display check boxes.
            listViewReturns.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listViewReturns.FullRowSelect = false;
            // Display grid lines.
            listViewReturns.GridLines = true;
            // Sort the items in the list in ascending order.
            //listView1.Sorting = SortOrder.Ascending;
            //Colors
           listViewReturns.BackColor = Color.FromArgb(235, 247, 255);
            listViewReturns.ForeColor = Color.FromArgb(0, 114, 187);

            //listview with headers
            //listView1.Columns.Add("Quantity", 90, HorizontalAlignment.Left);
            //listView1.Columns.Add("Description", 250, HorizontalAlignment.Left);
            //listView1.Columns.Add("Price", 80, HorizontalAlignment.Left);
            //listView1.Columns.Add("Amount", 110, HorizontalAlignment.Left);


            listViewReturns.Columns.Add("Qty", 80 + paddingQuantity, HorizontalAlignment.Left);
            listViewReturns.Columns.Add("Description", 154 + paddingQuantity, HorizontalAlignment.Center);
            listViewReturns.Columns.Add("Price", 100 + paddingQuantity, HorizontalAlignment.Right);
            listViewReturns.Columns.Add("Amount", 125 + paddingQuantity, HorizontalAlignment.Right);
            //listViewReturns.Columns.Add("", 1000, HorizontalAlignment.Right);

            
            //listViewReturns.HeaderStyle = ColumnHeaderStyle.None;
            listViewReturns.BorderStyle = BorderStyle.None;
            
            
            for (int i = 0; i < listViewReturns.Items.Count; i++)
            {
                listViewReturns.Items[i].UseItemStyleForSubItems = false;
                //listViewReturns.Items[i].
            }

            listViewReturns.Dock = DockStyle.Fill;
            listViewReturns.OwnerDraw = true;
            
            //listView1.Scrollable = false;
            listViewReturns.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewReturns_DrawColumnHeader);
            //listViewReturns.DrawItem += new DrawListViewItemEventHandler(listViewReturns_DrawItem);
            listViewReturns.DrawSubItem += new DrawListViewSubItemEventHandler(listViewReturns_DrawSubItem);

            // Add the ListView to the control collection.
            this.splitContainer1.Panel2.Controls.Add(listViewReturns);
            listViewReturns.Columns[1].Width = listViewReturns.Width -
                (listViewReturns.Columns[0].Width +
                listViewReturns.Columns[2].Width +
                listViewReturns.Columns[3].Width);
            // 
            // labelTotalQty
            // 
            labelTotalQty = new Label();
            labelTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            labelTotalQty.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTotalQty.ForeColor = Color.FromArgb(0, 114, 187);
            labelTotalQty.Location = new System.Drawing.Point(17, 4);
            labelTotalQty.Name = "labelTotalQty";
            labelTotalQty.Size = new System.Drawing.Size(142, 74);
            labelTotalQty.TabIndex = 0;
            labelTotalQty.Text = "Quantity:";
            labelTotalQty.Dock = DockStyle.Fill;

            panelQuantity.Controls.Add(labelTotalQty);

            // 
            // labelTotalAmt
            // 
            labelTotalAmt = new Label();
            labelTotalAmt.BackColor = System.Drawing.Color.FromArgb(0, 114, 187);
            labelTotalAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            labelTotalAmt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTotalAmt.ForeColor = System.Drawing.Color.FromArgb(235, 247, 255);
            labelTotalAmt.Location = new System.Drawing.Point(176, 4);
            labelTotalAmt.Name = "labelTotalAmt";
            labelTotalAmt.Size = new System.Drawing.Size(142, 74);
            labelTotalAmt.TabIndex = 1;
            labelTotalAmt.Text = "Total:";
            labelTotalAmt.Dock = DockStyle.Fill;

            panelAmount.Controls.Add(labelTotalAmt);


            //Screen Refresh
            //this.timer1.Interval = Properties.Settings.Default.SettingsAdCustomerScreenRefresh*1000;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //timer1.Enabled = true;


            ReadFolderFiles();

            if (MaxIndex > 0)
            {
                string fn = Properties.Settings.Default.SettingsAdCustomerScreenImagesFolder + "\\" + FolderImageFiles[index++].ToString();
                //fileInfo = new System.IO.FileInfo(fn);
                //fileStream = fileInfo.OpenRead();
                //pictureBox1.Image = System.Drawing.Image.FromStream(fileStream);
                //Application.DoEvents();
                //fileStream.Close();
                //Image fastImage = ImageFast.FromFile(fn);
                //pictureBox1.Image = fastImage;
                pictureBox1.Image = Funciones.LoadBitmap(fn);

                if (MaxIndex > 1)
                {
                    //slide
                    this.timer2.Interval = Properties.Settings.Default.SettingsAdCustomerScreenImageInterval * 1000;
                    this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
                    timer2.Enabled = true;
                }
            }

            //for a slide show

            //clock
            //this.timer3.Interval = 1000;
            //this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            //timer3.Enabled = true;

            //object obj1 = toolStripStatusLabelDate;
            //object obj2 = toolStripStatusLabelTime;
            //Main.rc.CambiarControlFecha(ref obj1);
            //Main.rc.CambiarControlHora(ref obj2);


            //DateTimePicker dtp = null;
            //object lb1 = toolStripStatusLabelDate;
            //object lb2 = toolStripStatusLabelTime;
            //rc1 = new RelojCalendario(Properties.Settings.Default.FechaActual, "Short", "", ref dtp, ref lb1, ref lb2);

            //own date and time
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Enabled = true;


            //blinking timer
            tslCntr = labelNextCustomer;
            timerBlink = new System.Windows.Forms.Timer();
            timerBlink.Enabled = false;
            timerBlink.Interval = 350;
            timerBlink.Tick += new System.EventHandler(timerBlink_Tick);

        }

        private void listViewReturns_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
           
            using (StringFormat s = new StringFormat())
            {
                s.Alignment = StringAlignment.Center;
                using (Font f = new Font("Arial", 20F, FontStyle.Bold))
                {
                    SolidBrush b = new SolidBrush(Color.FromArgb(53, 164, 212));
                    
                    e.Graphics.FillRectangle(b, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, f, SystemBrushes.Control, e.Bounds, s);
                }
            }
        }

        private void listViewReturns_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawText();
        }

        private void listViewReturns_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText();
        }
        
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //DateTime t = DateTime.Now;
            //Properties.Settings.Default.FechaActual = DateTime.Now;
            toolStripStatusLabelDate.Text = Main.rc.LeerFecha();
            toolStripStatusLabelTime.Text = Main.rc.LeerHora();

        }

        // This method handles the FileOK event.  It opens each file 
        // selected and loads the image from a stream into pictureBox1.
        private void timer2_Tick(object sender, System.EventArgs e)
        {
            //this.Activate();

            // Open each file and display the image in pictureBox1.
            // Call Application.DoEvents to force a repaint after each
            // file is read.        
            string fn = Properties.Settings.Default.SettingsAdCustomerScreenImagesFolder + "\\" + FolderImageFiles[index].ToString();
            //Image fastImage = ImageFast.FromFile(fn);
            //pictureBox1.Image = fastImage;

            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            pictureBox1.Image = Funciones.LoadBitmap(fn);

            //if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            //    return;
            //axWindowsMediaPlayer1.URL = fn;

            if (++index >= MaxIndex)
                index = 0;
        }

        //private void timer3_Tick(object sender, System.EventArgs e)
        //{
        //    DateTime t = DateTime.Now;
        //    //string s = t.ToLongTimeString();
        //    string s = t.ToShortTimeString();
        //    toolStripStatusLabelTime.Text = s;

        //}

        //blinking mode
        public static void timerBlink_Tick(object sender, System.EventArgs e)
        {
            if(!tslCntr.Visible)
                tslCntr.Visible = true;

            intCntr = intCntr + 1;
            if (intCntr % 2 == 0)
            {
                if (tslCntr != null)
                {
                    //tslCntr.Visible = false;
                    tslCntr.BackColor = System.Drawing.Color.OrangeRed;
                    tslCntr.ForeColor = System.Drawing.Color.White;
                }
            }
            else
            {
                if (tslCntr != null)
                {
                    //tslCntr.Visible = true;
                    tslCntr.BackColor = System.Drawing.Color.White;
                    tslCntr.ForeColor = System.Drawing.Color.OrangeRed;
                }

                if (intCntr > 9)
                {
                    intCntr = 0;
                    timerBlink.Enabled = false;
                    tslCntr.Visible = false;
                }
            }

        }

        private void ReadFolderFiles()
        {
            // Change this path to the directory you want to read
            this.FolderImageFiles = new ArrayList();
            string path = Properties.Settings.Default.SettingsAdCustomerScreenImagesFolder.Trim();
            if (String.IsNullOrEmpty(path))
                return;

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                foreach (FileInfo flInfo in dir.GetFiles()) //"*.jpg *.bmp"))
                {
                    //String name = flInfo.Name;
                    //long size = flInfo.Length;
                    //DateTime creationTime = flInfo.CreationTime;
                    //Console.WriteLine("{0, -30:g} {1,-12:N0} {2} ", name, size, creationTime);

                    if (flInfo.Extension.ToLower() == ".jpg"
                        || flInfo.Extension.ToLower() == ".gif" 
                        || flInfo.Extension.ToLower() == ".bmp"
                        || flInfo.Extension.ToLower() == ".png"
                        //|| flInfo.Extension.ToLower() == ".mov"
                        )
                    {
                        FolderImageFiles.Add(flInfo.Name);
                        MaxIndex++;
                    }

                }
            }

            catch { }
        }

        public static void ClearCustomerScreen()
        {
            if (Main.CustomerScreenForm != null)
            {
                CustomerScreen.listViewReturns.Items.Clear();
                CustomerScreen.labelTotalQty.Text = "Quantity:";
                CustomerScreen.labelTotalAmt.Text = "Total:";
            }

        }

    }
}
