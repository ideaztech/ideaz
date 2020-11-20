
using Microsoft.Win32.SafeHandles;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Controls;

using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Timers;

using SirLib.Hid;

using System.Web.Security;
using System.Threading;
using SirLib;

using System.Data.SqlClient;
using System.Net.Sockets;
using Solum.App_Code;

namespace Solum
{
	public partial class Returns : Form
	{

		#region Nextinline variables

		bool EnableNextinLine;
		static string NextinLineIPAddress;
		string computerName;

		#endregion

		#region Instant Staging Variables

		Sol_Agencie_Sp sol_Agency_Sp;

		Sol_Product sol_Product;
		Sol_Product_Sp sol_Product_Sp;

		System.Windows.Forms.Timer timerBlink;
		Button tslCntr;
		int intCntr = 0;

		System.Windows.Forms.Button buttonBagPosition_01 = new System.Windows.Forms.Button();
		System.Windows.Forms.Button buttonBagPosition_08 = new System.Windows.Forms.Button();

		Button buttonBagPositionClicked = null;
		MembershipUser membershipUser;

		Sol_AutoNumber_Sp sol_AutoNumber_Sp;
		string tagNumber = string.Empty;

		private Sol_Stage sol_Stage;
		private Sol_Stage_Sp sol_Stage_Sp;

		Vir_BagPosition_Sp vir_BagPosition_Sp;

		private ArrayList arrayListBagPositionButtons;
		private ArrayList arrayListBagPositionObjects;
		private ArrayList arrayListBagPositionTagNumbers;

		int currentOrderDetailID = 0;

		int[] conveyors = new int[] { 0, 0 };
		int currentConveyorID = 0;
		int currentMasterProductID = 0;

		//ListView currentListView;

		//bool isItemChecking = false;

		//Vir_Conveyor_Sp vir_Conveyor_Sp;

		//private bool flagChange = false;

		#endregion

		#region QuickDrop Variables

		int listViewItemsCount = 0; //static

		//int dropId = 0;
		int bagIdFromTextBox = 0;

		int listViewOriginalCount =0;
		//bool formQuickDrop = false;

		Qds_Drop qds_Drop;
		Qds_Drop_Sp qds_Drop_Sp;

		Qds_Bag qds_Bag;
		Qds_Bag_Sp qds_Bag_Sp;

		#endregion

		#region UsbHid Variables

		TextBox textBoxRFID = new System.Windows.Forms.TextBox();
		private bool cardReadInProgress;

		#endregion

		#region CardLink Variables

		//private string strCardNumber;
		//private ArrayList arrayListCardNumber;

		Sol_OrderCardLink sol_OrderCardLink;
		Sol_OrderCardLink_Sp sol_OrderCardLink_Sp;

		Sol_OrderCardLog sol_OrderCardLog;
		Sol_OrderCardLog_Sp sol_OrderCardLog_Sp;

		#endregion

		/*
			2 bags from this drop have not been counted yet.  Do you want to complete this order and set the status of the rest of the bags to MISSING?
		*/

		#region 17" screen setup - buttonType 3 Variables

		int lastPage = 0;
		int pageNumber = 1;

		byte buttonType;

		private ArrayList arrayListItems4;                  //for horizontal panel buttonType 3
		List<Sol_CategoryButton> sol_CategoryButtonList4;

		Panel panelTableLayoutPanelView3_Buttons;         // here Im using  tableLayoutPanelView2
		Panel panelTableLayoutPanelView3Vertical_Buttons; //and for this panelTableLayoutPanelView2_Buttons

		Panel panelTableLayoutPanelView3Horizontal_Buttons;

		//Button buttonFirstPage;
		Button buttonPreviousPage;
		Button buttonNextPage;
		//Button buttonLastPage;

		#endregion

		#region tableLayoutPanelView2 Variables   //NumericKeyPad On

		int multiplyBy = 0;     //private static 

		private Button buttonSender;
		private Label labelSender;

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

        #endregion

        #region Returns Variables

        int originalItemCount = 0;  //private static 

        private Sol_Fee sol_Fee;
		private Sol_Fee_Sp sol_Fee_Sp;

		private decimal totalAmount = 0.00M;

		private int feeIdOrg;
		private decimal feeAmountOrg;

		bool flagNumericPad = false;

		//string hexForeColor = "#000000";
		//string hexBackColor = "#f0f0f0";

		DateTime OpenDate;

		//private bool flagClear = false;
		private IButtonControl originalAcceptButton;
		private string buttonClicked = "";

		public bool formSales = false;
		public bool formCashier = false;

		string strOrderType = "R";  //R = Returns, S = Sales, A = Adjustment. Q=QuickDrop

		//Sol_CategoryButton sol_CategoryButton;
		Sol_CategoryButton_Sp sol_CategoryButton_Sp;


		Sol_BinCount sol_BinCount;
		Sol_BinCount_Sp sol_BinCount_Sp;

		Sol_Order sol_Order;
		Sol_Order_Sp sol_Order_Sp;
		Sol_OrdersDetail sol_OrdersDetail;

		Sol_Order_Sp sol_Orders_Sp;
		Sol_OrdersDetail_Sp sol_OrdersDetail_Sp;

		List<Sol_OrdersDetail> sol_OrdersDetailList;

		//static int intCntr = 0;
		private int intQuantityButton = 1;

		private ArrayList arrayListItems, arrayListViewCategoryId, arrayListViewDetailId;

		private ArrayList arrayListViewSubContainerCountDown;

		private ArrayList arrayListViewCategoryButtonId;

		private int indice = 0;//, CategoryButtonID = 0;

		List<Sol_CategoryButton> sol_CategoryButtonList;

		//Sol_CategoryButton_Sp sol_CategoryButton_Sp;

		private ArrayList arrayListItemsQuantity, arrayListControlsQuantity;

		private int indiceQuantity = 0;   //, QuantityButtonID = 0;

		List<Sol_QuantityButton> sol_QuantityButtonList;
		Sol_QuantityButton_Sp sol_QuantityButton_Sp;

        BottleDropJsonHandler bdjsHandler;
        BottleDropJsonResponse bdjsResponse;
        BottleDropJsonResponse bdjsCurrentOrder;
        private IButtonControl previousAcceptButton;
        string bdCurrentLblNumber = "";
        bool currentOrderIsForBottleDrop = false;





        #endregion

        #region Returns Methods

        public Returns(string Texto, string User, string Server)
		{
			InitializeComponent();

			this.Text = Texto;
			toolStripStatusLabelUserName.Text = User.Trim();    // +".";
			//toolStripStatusLabelMessage.Text = "Please open one bag at a time and place on counter";
			toolStripStatusLabelServerName.Text = Server;
			toolStripStatusLabelToday.Text = "";    // Today;
            panelNumericKb.Enabled = true;
			toolStrip2.DefaultDropDownDirection = ToolStripDropDownDirection.AboveRight;
			//FullScreenMode
			if (Properties.Settings.Default.SettingsAdFullScreenMode)
			{
				this.FormBorderStyle = FormBorderStyle.None;
				this.WindowState = FormWindowState.Maximized;
				//if (Properties.Settings.Default.SettingsAdHideTaskBar)
				//{
				//    this.ControlBox = true;
				//    this.MaximizeBox = false;
				//    this.MinimizeBox = false;
				//}
			}
			else
			{
				this.FormBorderStyle = FormBorderStyle.Sizable;
				this.WindowState = FormWindowState.Normal;
			}
			//Main.usbReadEventForm = "Returns";

			formQuickDrop = false;

		}

		private void Returns_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (Properties.Settings.Default.TouchOriented)
				Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

		}

		private void Returns_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			try
			{
				toolStrip2.Renderer = new App_Code.NewToolStripRenderer();
				//for usb hid
				if (Main.CardReader_Enabled)
				{
					if (Main.CardReader_EmulationMode == 0)    //HID
					{
						toolStripStatusLabelMsr.Visible = true;
						toolStripStatusLabelMsrMessage.Visible = true;

						if (Main.myDeviceDetected)
							this.toolStripStatusLabelMsrMessage.Text = "was found";

						this.timerReturns.Interval = 1 * 1000;
						this.timerReturns.Tick += new System.EventHandler(this.timerReturns_Tick);
						this.timerReturns.Enabled = false;


					}
					else if (Main.CardReader_EmulationMode == 1)    //keyboard
					{
						// 
						// textBoxRFID
						// 
						panel1.Controls.Add(textBoxRFID);
						textBoxRFID.Location = new System.Drawing.Point(176, 10);
						//textBoxRFID.Location = new System.Drawing.Point(176, 46);
						textBoxRFID.Name = "textBoxRFID";
						textBoxRFID.Size = new System.Drawing.Size(100, 26);
						textBoxRFID.TabIndex = 11;
						textBoxRFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRFID_KeyDown);
					}

				}

				// TODO: This line of code loads data into the 'dataSetFees.sol_Fees_SelectAll' table. You can move, or remove it, as needed.
				sol_Fee = new Sol_Fee();


				this.sol_Fees_SelectAllTableAdapter.Fill(this.dataSetFees.sol_Fees_SelectAll);
				originalAcceptButton = this.AcceptButton;

				if (Properties.Settings.Default.TouchOriented)
				{
					//toolStripButtonVirtualKb.Visible = true;
					//toolStripSeparatorVirtualKb.Visible = true;
					keyboardButton.Visible = true;
				}


				//classes of tables
				//sol_CategoryButton = new Sol_CategoryButton();
				sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);

				//sol_BinCount = new Sol_BinCount();
				sol_BinCount_Sp = new Sol_BinCount_Sp(Properties.Settings.Default.WsirDbConnectionString);

				//sol_Order = new Sol_Order();
				//sol_Order.OrderID = -1;
				sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
				//sol_OrdersDetail = new Sol_OrdersDetail();
				sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);
				sol_OrdersDetailList = new List<Sol_OrdersDetail>();

				buttonSender = null;
				labelSender = null;

				//clock
				object obj1 = toolStripStatusLabelToday;
				object obj2 = toolStripStatusLabelTimer;
				Main.rc.CambiarControlFecha(ref obj1);
				Main.rc.CambiarControlHora(ref obj2);


				//disable form resizing
				//this.FormBorderStyle = FormBorderStyle.FixedSingle;


				//disable quick cash out if no cashtray open
				if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)    //quick cash out
					if (Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", true))
                        //buttonExtra.Visible = SolFunctions.CheckCashier();
                        buttonExtra.Enabled = SolFunctions.CheckCashier();

                //listview with headers
                listView1.View = View.Details;
				
				if (formQuickDrop)
				{
					listView1.Columns.Add("Qty", 30, HorizontalAlignment.Center);
					listView1.Columns.Add("Description", 120, HorizontalAlignment.Left);
					listView1.Columns.Add("Price", 50, HorizontalAlignment.Right);
					listView1.Columns.Add("Amount", 80, HorizontalAlignment.Right);
					listView1.Columns.Add("Bag", 60, HorizontalAlignment.Center);   //46
					listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

					listView1.Columns[1].Width = listView1.Width -
				(listView1.Columns[0].Width +
				listView1.Columns[2].Width +
				listView1.Columns[3].Width +
				listView1.Columns[4].Width);
				}
				else
				{
					listView1.Columns.Add("Qty", 50, HorizontalAlignment.Center);
					listView1.Columns.Add("Description", 125, HorizontalAlignment.Left);
					listView1.Columns.Add("Price", 62, HorizontalAlignment.Right);
					listView1.Columns.Add("Amount", 90, HorizontalAlignment.Right);
					//listView1.Columns.Add("Bag", 0, HorizontalAlignment.Center);   //46
					listView1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					listView1.Columns[1].Width = listView1.Width -
				(listView1.Columns[0].Width +
				listView1.Columns[2].Width +
				listView1.Columns[3].Width);
				}

				listView1.BackColor = SystemColors.Control;
				listView1.ForeColor = Color.FromArgb(0, 114, 187);

				//if (Properties.Settings.Default.StagingType == 2)
				//{
				//    listView1.Columns.Add("Product", 50, HorizontalAlignment.Left);              //5 --0
				//    listView1.Columns.Add("MasterProductID", 50, HorizontalAlignment.Right);     //6 --3
				//}

				listView1.FullRowSelect = true;
				//listView1.CheckBoxes = true;
				listView1.GridLines = true;
				listView1.MultiSelect = false;

				//array to store categoryid
				this.arrayListViewCategoryId = new ArrayList();
				this.arrayListViewDetailId = new ArrayList();
				this.arrayListViewSubContainerCountDown = new ArrayList();
				this.arrayListViewCategoryButtonId = new ArrayList();

				#region views

				if (Properties.Settings.Default.SettingsAd17ScreenSetup)
				{
					//buttons 3
					buttonType = 3;

					//this.Width = 1280;
					//this.Height = 1024;
					//this.CenterToScreen();

					CategoryButtons.buttonW = 96 + 16;
					CategoryButtons.buttonH = 76 + 8;


					CategoryButtons.buttonContainerWidth = (CategoryButtons.view3Cells * CategoryButtons.buttonW) + 3;      // 239; 
					CategoryButtons.buttonContainerHeight = (CategoryButtons.view3Rows * CategoryButtons.buttonH) + 20;     //484;

					CreatePanelTableLayoutPanelView3Horizontal();

					tableLayoutPanelView1.Visible = false;
					CreateTableLayoutPanelView2();          //this is for numericKeyPad and category buttons

					//CreatePanelTableLayoutPanelView3Vertical();
					panelTableLayoutPanelView3Vertical_Buttons = panelTableLayoutPanelView2_Buttons;

					//CreatePanelTableLayoutPanelView3Horizontal();

					panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Vertical_Buttons;

					this.Show();

					ReadButtons2();
                    panelView.Enabled = true;
                    panelCategoryButtons.Enabled = true;
                    panelNumericKb.Enabled = true;

				}
				else if (Main.Sol_ControlInfo.NumericKeyPadOn)
				{
					//buttons 2
					buttonType = 2;

					this.Width = 1025;
					this.Height = 760;
					this.CenterToScreen();

					CategoryButtons.buttonW = 75;
					CategoryButtons.buttonH = 75;

					CategoryButtons.buttonContainerWidth = 200;   //239
					CategoryButtons.buttonContainerHeight = 488;  //476

					tableLayoutPanelView1.Visible = false;
					CreateTableLayoutPanelView2();

					ReadButtons2();
                    panelView.Enabled = true;
                    panelCategoryButtons.Enabled = true;
                    panelNumericKb.Enabled = true;
                    //panelTableLayoutPanelView2_Buttons.BackColor = Color.FromArgb(Main.Sol_ControlInfo.CategoryButtonsPanelBgColor);
                }
				else
				{
					//buttons 1
					buttonType = 1;

					this.Width = 1025;
					this.Height = 760;
					this.CenterToScreen();

					//tableLayoutPanelView2.Visible = false;
					tableLayoutPanelView1.Visible = true;
					tableLayoutPanelView1.Location = new System.Drawing.Point(0, 0);
					tableLayoutPanelView1.Dock = DockStyle.Fill;

					ReadControlsQuantity();
					ReadControls();
				}

				#endregion

				comboBoxReturnId.Text = "";

				#region extra button 0 = QuickCashOut 1 = Print Chit

				if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)
				{
					buttonExtra.Text = "&Cash Out";
				}
				else
				{
					buttonExtra.Text = "&Print Ticket";

					//buttonExtra.Dock = DockStyle.None;
					//buttonExtra.Location = new System.Drawing.Point(7, 11);
					//buttonExtra.Size = new System.Drawing.Size(101, 61);
					//panelButtonExtra.Panel2Collapsed = true;
					//buttonPutOnAccount.Visible = false;
				}

				#endregion

				//training warning
				if (Properties.Settings.Default.SQLBaseDeDatos == "Virdis_Training")
				{
					toolStripStatusLabelTrainingMode.Visible = true;
					Main.tslCntr = toolStripStatusLabelTrainingMode;
					Main.timerBlink.Enabled = true;
				}

				//current cashtray
				Sol_CashTray_Sp sol_CashTray_Sp = new Solum.Sol_CashTray_Sp(Properties.Settings.Default.WsirDbConnectionString);
				Sol_CashTray sol_CashTray = sol_CashTray_Sp.Select(Properties.Settings.Default.SettingsCurrentCashTray);
				if (sol_CashTray != null)
					toolStripStatusLabellabel1CurrentCashTrayDescription.Text = sol_CashTray.Description;

				//computer roles
				CheckComputerRole();

				toolStripButtonCashier.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", false);
				buttonPutOnAccount.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", false);
                //buttonPutOnAccount.Visible = buttonPutOnAccount.Enabled;
				//ReadAndWriteToDevice();

				#region QuickDrop

				if (formQuickDrop)
				{
					toolStripSeparatorViewFront.Visible = true;

					toolStripSeparatorReturns.Visible = false;
					toolStripSeparatorQdCustomer.Visible = true;
					toolStripButtonQdBags.Visible = true;
					strOrderType = "Q";  //R = Returns, S = Sales, A = Adjustment. Q=QuickDrop

					// 
					// toolStripButtonQuickDrop
					// 
					this.toolStripButtonReturns.AutoSize = false;
					this.toolStripButtonReturns.BackColor = System.Drawing.SystemColors.Control;
					this.toolStripButtonReturns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
					this.toolStripButtonReturns.Enabled = false;
					this.toolStripButtonReturns.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					this.toolStripButtonReturns.ForeColor = System.Drawing.Color.OliveDrab;
					this.toolStripButtonReturns.Size = new System.Drawing.Size(68, 68);
					this.toolStripButtonReturns.Text = "QD";
					this.toolStripButtonReturns.ToolTipText = "Manage QuickDrop Bags";

					this.toolStripButtonSales.Visible = false;
					this.toolStripButtonCashier.Visible = false;

					this.buttonNew.Visible = false;

					this.buttonExtra.Visible = false;
					this.buttonPutOnAccount.Visible = false;

					this.labelBagID.Visible = true;
					this.comboBoxBagId.Visible = true;
					this.buttonBagIdSubmit.Visible = true;
					this.labelBagCount.Visible = true;

					//this.buttonBagIdSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
					this.AcceptButton = this.buttonBagIdSubmit;

					this.comboBoxBagId.Focus();

					//this.comboBoxBagId.DropDownStyle = ComboBoxStyle.Simple;

					//this.buttonMissingBags.Visible = true;
				}
				else
					listView1.Focus();

				#endregion

				toolStripSeparatorLogOff.Visible = true;

				if (Main.Sol_ControlInfo.State == "AB"
					&& Main.QuickDrop_DepotID != null && Main.QuickDrop_DepotID.Length == 6)
				{
					toolStripButtonQdCustomer.Visible = true;
					toolStripSeparatorQdCustomer.Visible = true;
				}

				CustomerScreen.ClearCustomerScreen();


				#region Instant Staging

				if (Properties.Settings.Default.StagingType == 2)
				{
					//Instant Staging
					currentConveyorID = Main.ConveyorId;

					this.tableLayoutPanel3.Size = new System.Drawing.Size(388, 690);
					this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.None;
					this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel3, 2);
					this.panelInstantStaging.Visible = true;

					buttonBagPosition_01.Location = new System.Drawing.Point(1, 1);
					buttonBagPosition_01.Name = "buttonBagPosition_01";
					buttonBagPosition_01.Size = new System.Drawing.Size(120, 100);
					buttonBagPosition_01.TabIndex = 19;
					buttonBagPosition_01.Text = "button1";
					buttonBagPosition_01.Visible = false;

					buttonBagPosition_08.Location = new System.Drawing.Point(1, 1);
					buttonBagPosition_08.Name = "buttonBagPosition_08";
					buttonBagPosition_08.Size = new System.Drawing.Size(120, 100);
					buttonBagPosition_08.TabIndex = 19;
					buttonBagPosition_08.Text = "button8";
					buttonBagPosition_08.Visible = false;

					this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
					this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
					this.toolStripMenuItemModify.Click += new System.EventHandler(this.toolStripMenuItemModify_Click);

					//bagposition buttons
					FillDataBagPosition();

					//blinking timer
					timerBlink = new System.Windows.Forms.Timer();  //this.components);
					timerBlink.Interval = 250;
					timerBlink.Tick += new System.EventHandler(timerBlink_Tick);


				}
				else
				{
					this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
					this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel3, 4);
				}

				#endregion

				#region EnableNextinLine

				//leer opciones
				Sol_Setting_Sp sol_Setting_Sp = new Sol_Setting_Sp(Properties.Settings.Default.WsirDbConnectionString);

				/*
				 see buttonNextInLine_Click(object sender, EventArgs e) function 
				 for instructions 

				*/

				EnableNextinLine = false;
				NextinLineIPAddress = string.Empty;
				Sol_Setting sol_Setting = sol_Setting_Sp.Select("EnableNextinLine");
				if (sol_Setting != null)
				{
					try
					{
						EnableNextinLine = (bool)sol_Setting.SetValue;
						if (EnableNextinLine)
						{
							sol_Setting = sol_Setting_Sp.Select("NextinLineIPAddress");
							if (sol_Setting != null)
								NextinLineIPAddress = (string)sol_Setting.SetValue;
						}
					}
					catch
					{
						string sv = sol_Setting.SetValue.ToString().ToLower();
						if (sv == "true" || sv == "1")
						{
							EnableNextinLine = true;
							sol_Setting = sol_Setting_Sp.Select("NextinLineIPAddress");
							if (sol_Setting != null)
								NextinLineIPAddress = (string)sol_Setting.SetValue;
						}
					}
				}

				if (EnableNextinLine)
				{
					buttonNextInLine.Visible = !buttonExtra.Enabled;
				}

				#endregion


			}
			catch (Exception ex)
			{
				HidMethods.DisplayException("Returns_Load", ex);
				//throw;
			}

            //BottleDrop
            if (Main.EnableBottleDrop)
            {
                bottleDropButton.Visible = true;
                bdjsHandler = Main.MainForm.BDJsonHandler;
            }
			computerName = Main.myHostName;

            toolStripButtonAttendance.Visible = Properties.Settings.Default.UseAttendance;
            toolStripButtonSales.Visible = Properties.Settings.Default.UseSales;
		}

		private void button_Click(object sender, EventArgs e)
		{
            #region initial procedure

            buttonClose.Enabled = false;
            buttonClose.Visible = false;


            if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateChit", true))
			{
				buttonClose.Enabled = true;
                buttonClose.Visible = true;

                return;
			}

            if (buttonNew.Enabled) {
                string s1 = labelPad.Text;
                string s2 = labelPadTotal.Text;
                
                buttonNew.PerformClick();

                labelPad.Text = s1;
                labelPadTotal.Text = s2;

            }

			buttonSender = (Button)sender;

			string[] strControl = buttonSender.Name.Split('_');

			labelSender = (Label)buttonSender.Controls["Label_" + strControl[1]];

            #endregion

            #region category index button

            if (!Int32.TryParse(strControl[1], out indice))
			{
				MessageBox.Show("Error parsing button index, please restart the aplication!");
				buttonClose.Enabled = true;
                buttonClose.Visible = true;

                return;
			}

            #endregion

            #region adjusting bincount

            if (toolStripButtonResetCounter.Text != "Adjust count")
			{
				if ((sol_CategoryButtonList[indice]).SubContainerMaxCount < 1)
					MessageBox.Show("This button does not have a thershold, cannot adjust it!");
				else
					adjustCount();

				buttonClose.Enabled = true;
                buttonClose.Visible = true;

                return;
			}

            #endregion

            #region lookup category 

            Sol_Category sol_Category = new Sol_Category();
			Sol_Category_Sp sol_Category_Sp = new Sol_Category_Sp(Properties.Settings.Default.WsirDbConnectionString);
			sol_Category = sol_Category_Sp.Select((sol_CategoryButtonList[indice]).CategoryID);
			if (sol_Category == null)
			{
				MessageBox.Show("Category not found!");
				buttonClose.Enabled = true;
                buttonClose.Visible = true;

                return;
			}

            #endregion

            #region views 

            if (Main.Sol_ControlInfo.NumericKeyPadOn)
			{
				getPadNumber();
				if (resultNumber > 0)
					intQuantityButton = resultNumber;
				if (intQuantityButton < 1) intQuantityButton = 1;
			}
			else
				if (flagNumericPad)
					ShowNumericPad();

            #endregion

            #region check maximum quantity allowed

            int totalQuantity = (sol_CategoryButtonList[indice]).DefaultQuantity * intQuantityButton;
			int maxCountPerLine = (sol_CategoryButtonList[indice]).MaxCountPerLine;
			if (maxCountPerLine < 1)
				maxCountPerLine = Main.Sol_ControlInfo.ReturnsMaxQuantity;


			if (maxCountPerLine > 0)
			{
				if (maxCountPerLine < totalQuantity)
				{
					intQuantityButton = 1;
					MessageBox.Show("Quantity greater than the maximum allowed!");
					buttonClose.Enabled = true;
                    buttonClose.Visible = true;
                    if (Main.Sol_ControlInfo.NumericKeyPadOn)
                    {
                        EventArgs e1 = new EventArgs();
                        labelClear_Click(labelClear, e1);
                    }
                    return;
				}
			}

            #endregion

            #region get bagID if QuickDrop

            int bagId = 0;
			if (formQuickDrop)
				int.TryParse(comboBoxBagId.Text, out bagId);

            #endregion

            #region add item

            if (!addItem(totalQuantity,
				sol_Category.Description,                //(sol_CategoryButtonList[indice]).Description,
				sol_Category.RefundAmount,
				(sol_CategoryButtonList[indice]).CategoryID,
				-1,
				(sol_CategoryButtonList[indice]).SubContainerCountDown,
				(sol_CategoryButtonList[indice]).CategoryButtonID,
				(sol_CategoryButtonList[indice]).SubContainerMaxCount,
				bagId
				, sol_Category.StagingProductID
				))
			{
				buttonClose.Enabled = true;
                buttonClose.Visible = true;

                return;
			}

            #endregion

            #region final checkup and cleanup

            if (formQuickDrop)
				listViewItemsCount++;

			if (Main.Sol_ControlInfo.NumericKeyPadOn)
			{
				EventArgs e1 = new EventArgs();
				labelClear_Click(labelClear, e1);
			}

			//                                                                              MaxCount = 10                                                             CountDown = True
			//updateThreshold(totalQuantity, (sol_CategoryButtonList[indice]).SubContainerMaxCount, 1, (sol_CategoryButtonList[indice]).SubContainerCountDown);

			totals();

			intQuantityButton = 1;

			//select las item, if any
			int index = listView1.Items.Count - 1;
			if (index >= 0)
			{
				listView1.Items[index].Selected = true;
				//listView1.Focus();
			}
            if (!currentOrderIsForBottleDrop)
            {
                buttonClose.Enabled = true;
                buttonClose.Visible = true;
            }

            #endregion

        }

        private void adjustCount()
		{
			enableAdjustCountControls(true);

		}

		private void buttonQuantity_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			string[] strControl = btn.Name.Split('_');
			indiceQuantity = Convert.ToInt32(strControl[1]);
			intQuantityButton = ((Sol_QuantityButton)arrayListControlsQuantity[indiceQuantity]).DefaultQuantity;
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

		private void buttonNew_Click(object sender, EventArgs e)
		{
			////memory leak
			//formCashier = true;
			//Close();
			//return;

			if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateChit", true))
				return;

			feeIdOrg = 0;
			feeAmountOrg = 0;

			//date of creation
			OpenDate = Main.rc.FechaActual; // ;
			ClearForm();
			//comboBoxFees.SelectedValue = 0;

			buttonClicked = buttonNew.Text; // "new";
			EnableControls(true);
			EnableButtons("new");


		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
            //check order consistency between virdis and sql server
            if (!CheckOrderConsistency())
                return;

			if (formQuickDrop)
				if(listViewItemsCount < 1)
					if (MessageBox.Show("Do you want to save the bag with no containers in it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
						return;

			//check if the order is still open 
			if (!CheckOrderStillOpen("Close"))
			{
				if (formQuickDrop)
					comboBoxBagId.Focus();
				return; //false;
			}

			if (sol_Order != null)
			{
				if (buttonClicked == "&New")
				{
					comboBoxReturnId.Text = sol_Order.OrderID.ToString();
				}
				else if(buttonClicked == "&Edit")
				{
					if (originalItemCount != listView1.Items.Count)
					{
						//este
						sol_Order.Comments += String.Format("Edited {0} {1}.", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
						orderCommentsUpdate(sol_Order.OrderID, sol_Order.OrderType, sol_Order.Comments);
						//sol_Order_Sp.Update(sol_Order);
					}
				}

				UpdateTotalFeeAmount();    //Int32.Parse(comboBoxReturnId.Text));

				if (!CloseOrder(true))
				{
					if (formQuickDrop)
						comboBoxBagId.Focus();
					return;
				}
			}

			//view state
			EnableControls(false);
			EnableButtons("close");
			ClearForm();
			this.AcceptButton = originalAcceptButton;
			comboBoxReturnId.Enabled = false;
			comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
			buttonSubmit.Enabled = false;
			comboBoxBagId.DropDownStyle = ComboBoxStyle.Simple;

			if (formQuickDrop)
				comboBoxBagId.Focus();

		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(comboBoxReturnId.Text))
			{
                //if (MessageBox.Show("Are you sure you want to cancel this operation?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                //    return;
                orderLookupPanel.Visible = false;
				CancelProc();
			}
			else
			{
                orderLookupPanel.Visible = false;
				EnableControls(false);
				EnableButtons("cancel");
				toolStripButtonView.Text = "&Find";
                toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Image;

				ClearForm();

				this.AcceptButton = originalAcceptButton;
				comboBoxReturnId.Enabled = false;
				comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
				buttonSubmit.Enabled = false;

				comboBoxBagId.DropDownStyle = ComboBoxStyle.Simple;


			}
			if (formQuickDrop)
				comboBoxBagId.Focus();

		}

		private void CancelProc()
		{
			if (buttonClicked == "&New"
				&& sol_Order != null
				&& (sol_Order.Status == "A" || sol_Order.Status == "I")
				)
			{
				if (MessageBox.Show("Are you sure you want to Void this Order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
				{
					//delete it
					//remove customer, if any
					//if (sol_Order.CustomerID > 0)
					//{
					//    sol_Order.CustomerID = 0;
					//    sol_Order.Name = String.Empty;
					//    sol_Order.Address1 = String.Empty;
					//    sol_Order.Address2 = String.Empty;
					//    sol_Order.City = String.Empty;
					//    sol_Order.Province = String.Empty;
					//    sol_Order.Country = String.Empty;
					//    sol_Order.PostalCode = String.Empty;
					//}
					sol_Order.Status = "D";
					sol_Order_Sp.UpdateStatus(sol_Order.OrderID, sol_Order.OrderType, sol_Order.Status);

					//mark details as deleted
					foreach (ListViewItem itm in listView1.Items)
					{
						int totalQuantity = Convert.ToInt32(itm.SubItems[0].Text);
						int categoryButtonId = (int)arrayListViewCategoryButtonId[itm.Index];

						int index = -1;
						if (categoryButtonId > 0
							&& labelSender != null)
							index = getLabelSender(categoryButtonId, ref labelSender);

						if (index >= 0)
						{
							if ((sol_CategoryButtonList[index]).SubContainerMaxCount > 0)
								updateCurrentCount(
									totalQuantity,
									(sol_CategoryButtonList[index]).SubContainerCountDown,
									categoryButtonId,
									(sol_CategoryButtonList[index]).SubContainerMaxCount,
									-1
								);
						}


						int detailId = (int)this.arrayListViewDetailId[itm.Index];  //index];

						if (Properties.Settings.Default.StagingType == 2)
						{
							//Instant Staging
							sol_OrdersDetail = sol_OrdersDetail_Sp.Select(detailId);

							if (sol_Product_Sp == null)
								sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
							sol_Product = sol_Product_Sp.Select(sol_OrdersDetail.ProductID);
							if (sol_Product == null)
								currentMasterProductID = 0;
							else
								currentMasterProductID = sol_Product.MasterProductID;

							currentOrderDetailID = detailId;
							buttonRemove();
						}

						sol_OrdersDetail = sol_OrdersDetail_Sp.Select(detailId);
						sol_OrdersDetail.Status = sol_Order.Status;
						sol_OrdersDetail_Sp.Update(sol_OrdersDetail);

					}

					//remove all items
					listView1.Items.Clear();
					arrayListViewCategoryId.Clear();
					arrayListViewDetailId.Clear();
					arrayListViewSubContainerCountDown.Clear();
					arrayListViewCategoryButtonId.Clear();

					if (Main.CustomerScreenForm != null)
						CustomerScreen.listViewReturns.Items.Clear();

					totals();

					EnableControls(false);
					EnableButtons("cancel");
					toolStripButtonView.Text = "&Find";
                    toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Image;

					ClearForm();

					this.AcceptButton = originalAcceptButton;
					comboBoxReturnId.Enabled = false;
					comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
					buttonSubmit.Enabled = false;

					comboBoxBagId.DropDownStyle = ComboBoxStyle.Simple;

				}
			   


			}
			else
			{

				EnableControls(false);
				EnableButtons("cancel");
				toolStripButtonView.Text = "&Find";
                toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Image;

				ClearForm();

				this.AcceptButton = originalAcceptButton;
				comboBoxReturnId.Enabled = false;
				comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
				buttonSubmit.Enabled = false;

				comboBoxBagId.DropDownStyle = ComboBoxStyle.Simple;
			}
		}

		private void buttonView_Click(object sender, EventArgs e)
		{
			originalItemCount = listView1.Items.Count;
            string userName = Properties.Settings.Default.UsuarioNombre;
            if (userName.ToLower() == "admin")
                userName = "";
            //read and display voucher
            buttonClicked = toolStripButtonView.Text;    // "view";

			if (buttonClicked == "&Find" && !Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolLookupChit", true))
				return;
            


			if (buttonClicked == "&Edit")
			{
				if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolOpenChit", true))
					return;

				EnableControls(true);
				EnableButtons("edit");
				this.AcceptButton = originalAcceptButton;

				//open order
				OpenDate = Main.rc.FechaActual;
				CloseOrder(false);

				//select last item, if any
				int index = listView1.Items.Count - 1;
				if (index >= 0)
				{
					listView1.Items[index].Selected = true;
					listView1.Focus();
				}

				return;
			}

			EnableButtons("search");    //lookup");
			ClearForm();

            orderLookupPanel.Left = (this.Width / 2) - (orderLookupPanel.Width / 2);
            orderLookupPanel.Top = (this.Height / 2) - (orderLookupPanel.Height / 2);
            orderLookupPanel.Visible = true;

			orderLookupListBox.Enabled = true;
            comboBoxReturnId.Enabled = true;
            orderLookupListBox.Text = string.Empty;
            comboBoxReturnId.Text = string.Empty;
            orderLookupListBox.SelectedIndex = -1;
            comboBoxReturnId.SelectedIndex = -1;
			comboBoxReturnId.DropDownStyle = ComboBoxStyle.DropDown;
            sol_Orders_SelectAllLookupTableAdapter.Fill(this.dataSetOrdersLookup.sol_Orders_SelectAllLookup, userName, strOrderType, "A", "");
            orderLookupListBox.Focus();
			buttonSubmit.Enabled = true;

		}

		private void buttonDeleteRow_Click(object sender, EventArgs e)
		{
			if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolDeleteChit", true))
				return;

			//check if the order is still open 
			if (!CheckOrderStillOpen("Delete"))
				return; //false;

			ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
			if (selectedItems.Count < 1)
			{
				MessageBox.Show("Please select a row to delete");
				return;
			}

			int lastItem = 0;
			ListViewItem itm = new ListViewItem();
			foreach (ListViewItem item in selectedItems)
			{
				lastItem = item.Index;
				itm = item;
			}

			if (formQuickDrop && bagIdFromTextBox > 0)
			{
				int bagId = Convert.ToInt32(itm.SubItems[4].Text);
				if (bagIdFromTextBox != bagId)
				{
					MessageBox.Show("Cannot delete an item from another bag, change to that bag please!");
					return;
				}

			}

			int totalQuantity = Convert.ToInt32(itm.SubItems[0].Text);
			//bool countDown = (bool)arrayListViewSubContainerCountDown[lastItem];

			int categoryButtonId = 0;
			if (lastItem >= 0)
			{

				listView1.Items.RemoveAt(lastItem);

				arrayListViewCategoryId.RemoveAt(lastItem);

				DeleteRow(itm, lastItem);

				arrayListViewDetailId.RemoveAt(lastItem);

				arrayListViewSubContainerCountDown.RemoveAt(lastItem);

				categoryButtonId = (int)arrayListViewCategoryButtonId[lastItem];
				arrayListViewCategoryButtonId.RemoveAt(lastItem);


			}

			//                                                                              MaxCount = 10                                                             CountDown = True
			//updateThreshold(totalQuantity, (sol_CategoryButtonList[indice]).SubContainerMaxCount, -1, (sol_CategoryButtonList[indice]).SubContainerCountDown);

			//(sol_CategoryButtonList[index]).

			int index = -1;
			if (categoryButtonId > 0)
				index = getLabelSender(categoryButtonId, ref labelSender);

			if (index >= 0)
			{
				if ((sol_CategoryButtonList[index]).SubContainerMaxCount > 0)
					updateCurrentCount(
						totalQuantity,
						(sol_CategoryButtonList[index]).SubContainerCountDown,
						categoryButtonId,
						(sol_CategoryButtonList[index]).SubContainerMaxCount,
						-1
					);
			}


			totals();

			if (Main.CustomerScreenForm != null)
			{
				if (lastItem >= 0)
				{
					CustomerScreen.listViewReturns.Items.RemoveAt(lastItem);

				}

			}

			index = listView1.Items.Count - 1;
			if (index >= 0)
			{
				listView1.Items[index].Selected = true;
				//listView1.Focus();
			}

		}

		private int getLabelSender(int categoryButtonID, ref Label labelCategoryButton)
		{
			//string labelSenderName = String.Empty;
			int index = -1;

			for (int i = 0; i <= sol_CategoryButtonList.Count; i++)
			{
				try
				{
					if ((sol_CategoryButtonList[i]).CategoryButtonID == categoryButtonID)
					{
						index = i;
						break;
					}
				}
				catch 
				{
					index = -1;
				}

			}
			if (index >= 0)
				labelCategoryButton = (Label)panelTableLayoutPanelView2_Buttons.Controls["Button_" + index.ToString()].Controls["Label_" + index.ToString()]; // + strControl[1]];
			else
				labelCategoryButton = null;


			//MessageBox.Show(labelCategoryButton.Name);

			return index;
		}

		private void toolStripButtonLogOff_Click(object sender, EventArgs e)
		{
			SolFunctions.LogOff(ref toolStripStatusLabelUserName);
			CheckComputerRole();

			if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCreateChit", true))
			{
				exitButton.PerformClick();
				return;
			}

			toolStripButtonCashier.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolCashOutOrder", false);
			buttonPutOnAccount.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", false);
            buttonPutOnAccount.Visible = buttonPutOnAccount.Enabled;

		}

		private void toolStripButtonExit_Click(object sender, EventArgs e)
		{
			Close();

		}

		private void toolStripButtonSales_Click(object sender, EventArgs e)
		{
			formSales = true;
			Close();
		}

		private void toolStripButtonCashier_Click(object sender, EventArgs e)
		{
			formCashier = true;
			
			Close();
		}

		private void buttonNumericPad_Click(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.SettingReturnsNumericPadSelectProductFirst)

				flagNumericPad = true;
			else
				ShowNumericPad();
		}

		private void comboBoxReturnId_DropDown(object sender, EventArgs e)
		{
			string userName = Properties.Settings.Default.UsuarioNombre;
			if (userName.ToLower() == "admin")
				userName = "";

			if(formQuickDrop)
				sol_Orders_SelectAllLookupTableAdapter.Fill(this.dataSetOrdersLookup.sol_Orders_SelectAllLookup, userName, strOrderType, "A", "I");   //Q = QuickDrop Order,  A = normal unpaid, I = in process
			else
				sol_Orders_SelectAllLookupTableAdapter.Fill(this.dataSetOrdersLookup.sol_Orders_SelectAllLookup, userName, strOrderType, "A", "");   //r = returns,  = normal unpaid


		}

		private void comboBoxFees_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (flagClear)
			//    return;

			if (comboBoxFees.SelectedValue == null)
				return;

			//sol_Fee = new Sol_Fee();
			sol_Fee_Sp = new Sol_Fee_Sp(Properties.Settings.Default.WsirDbConnectionString);
			sol_Fee = sol_Fee_Sp.Select((int)comboBoxFees.SelectedValue);

			if (sol_Fee.Percentage)
			{

				textBoxFeeAmount.Text = CalculateFeePer(GetOrderTotalAmount(), sol_Fee.FeeAmount).ToString();
			}
			else
				textBoxFeeAmount.Text = sol_Fee.FeeAmount.ToString();
			totals();            
		}

		private decimal GetOrderTotalAmount()
		{
			int totalqty = 0;
			//decimal totalamt = 0.00M;
			decimal totalAmount = 0.00M;
			totalAmount = 0.00M;
			int nrows = listView1.Items.Count;

			for (int i = 0; i < nrows; i++)
			{
				totalqty = totalqty + Convert.ToInt32(listView1.Items[i].SubItems[0].Text);
				string c = listView1.Items[i].SubItems[3].Text;
				c = c.Replace('$', ' ');
				totalAmount = totalAmount + Convert.ToDecimal(c);
			}


			return totalAmount;
		}

		private decimal CalculateFeePer(decimal totalAmount, decimal feeRate)
		{
			decimal fee1 = totalAmount * (feeRate / 100);
			return fee1;
		}

		private void textBoxFeeAmount_TextChanged(object sender, EventArgs e)
		{
			//sol_Fee.Percentage = false;
			totals();
		}

        //********
        //routines
        //********

        private bool addItem(int quantity, string description, decimal price, int categoryId, int detailId, bool counterDown, int categoryButtonId, int maxCount, int bagId
            , int stagingProductID
            )
        {
            string messageTitle = @"An unexpected problem ocurred. We apologize for the inconvenience.";
            string messageError = string.Empty;
            bool result = true;
            try
            {
                #region check if the order is still open on New status

                if (detailId < 1)
                {
                    if (!CheckOrderStillOpen("Add"))
                        return false;
                }

                #endregion

                #region prepare item for the listview

                string[] str = new string[5];
                ListViewItem itm;   // = new ListViewItem();
                                    //formatting numbers
                str[0] = String.Format("{0,3}", quantity);
                str[1] = description;
                str[2] = String.Format("{0,6:##0.00}", price);
                str[3] = String.Format("{0,8:#,##0.00}", quantity * price);

                if (formQuickDrop)
                    str[4] = bagId.ToString();

                if (Properties.Settings.Default.StagingType == 2)
                {
                    //Instant Staging
                    if (sol_Product_Sp == null)
                        sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);

                    sol_Product = sol_Product_Sp.Select(stagingProductID);

                    if (sol_Product == null)
                        currentMasterProductID = 0;
                    else
                        currentMasterProductID = sol_Product.MasterProductID;

                }

                itm = new ListViewItem(str);

                if (formQuickDrop && bagIdFromTextBox > 0 && bagIdFromTextBox != bagId)
                {
                    itm.ForeColor = ForeColor = SystemColors.GrayText;
                    itm.BackColor = SystemColors.InactiveBorder;
                    itm.Selected = false;
                }

                #region //item is added to the listview after updating to sql

                //listView1.Items.Add(itm);
                ////scroll to last item automatically
                //listView1.EnsureVisible(listView1.Items.Count - 1);
                //listView1.Update();
                #endregion

                #endregion

                #region add to database

                if (detailId < 1)
                {
                    detailId = AddRow(itm, categoryId, categoryButtonId, stagingProductID);
                    if (detailId < 1)
                        return false;

                }


                #endregion

                #region add item to listview

                listView1.Items.Add(itm);

                //scroll to last item automatically
                listView1.EnsureVisible(listView1.Items.Count - 1);
                listView1.Update();

                #endregion

                #region add to customer screen

                if (Main.CustomerScreenForm != null)
                {
                    ListViewItem itm2;
                    str[0] = String.Format("{0,3}", quantity);
                    str[1] = description;
                    str[2] = String.Format("{0,6:##0.00}", price);
                    str[3] = String.Format("{0,9:##,##0.00}", quantity * price);
                    itm2 = new ListViewItem(str);
                    CustomerScreen.listViewReturns.Items.Add(itm2);

                    //scroll to last item automatically
                    CustomerScreen.listViewReturns.EnsureVisible(CustomerScreen.listViewReturns.Items.Count - 1);
                    CustomerScreen.listViewReturns.Update();


                }

                #endregion

                #region preserve parameters

                this.arrayListViewCategoryId.Add(categoryId);

                this.arrayListViewSubContainerCountDown.Add(counterDown);

                this.arrayListViewCategoryButtonId.Add(categoryButtonId);

                if (detailId > 0)
                    this.arrayListViewDetailId.Add(detailId);

                #endregion

                #region updateCurrentCount

                if (categoryButtonId > 0 && maxCount > 0)
                {
                    updateCurrentCount(
                        quantity,
                        //string description, 
                        //decimal price, 
                        //int categoryId, 
                        //int detailId, 
                        counterDown,
                        categoryButtonId,
                        maxCount,
                        1
                    );
                }

                #endregion

            }
            catch (SqlException sqlex)
            {
                messageError = sqlex.Message;
                result = false;
            }

            catch (Exception ex)
            {
                messageError = ex.Message;
                result = false;
            }

            if (!result)
            {
                messageError += "\n" + "Please try again later.";
                MessageBox.Show(messageError, messageTitle);
            }

            return result;
		}

		private void updateCurrentCount(
			int quantity,
			//string description, 
			//decimal price, 
			//int categoryId, 
			//int detailId, 
			bool counterDown,
			int categoryButtonId,
			int maxCount,
			short factor
			)
		{
			sol_BinCount = sol_BinCount_Sp.Select(Main.myHostName, categoryButtonId);
			if (sol_BinCount == null)
			{
				sol_BinCount = new Sol_BinCount();
				sol_BinCount.ClientID = Main.myHostName;
				sol_BinCount.CategoryButtonID = categoryButtonId;
				sol_BinCount.CurrentCount = 0;
				sol_BinCount.CurrentCount = adjustCurrentBin(sol_BinCount.CurrentCount, quantity, counterDown, maxCount, factor);
				sol_BinCount_Sp.Insert(sol_BinCount);
			}
			else
			{
				sol_BinCount.CurrentCount = adjustCurrentBin(sol_BinCount.CurrentCount, quantity, counterDown, maxCount, factor);
				sol_BinCount_Sp.Update(sol_BinCount);
			}

			//updateThreshold(int totalQuantity, int subContainerMaxCount, short factor, bool subContainerCountDown)


		}

		private int adjustCurrentBin(int currentCount, int quantity, bool counterDown, int maxCount, short factor)
		{
			string t = String.Empty;
			string tFactor;
			decimal result = 0;
			int pint = 0;
			int pdec = 0;

			int totalQuantity = 0;
			if (factor == 1)
			{
				tFactor = "Time to close";
				totalQuantity = currentCount + quantity;
			}
			else
			{
				tFactor = "Please re-open previous";

				pint = (int)((Math.Floor((double)(quantity / maxCount))) * maxCount);
				totalQuantity = currentCount - quantity + pint;

				pint /= maxCount;

				if (quantity > currentCount)
				{
					totalQuantity = totalQuantity + maxCount;
				}
				if (totalQuantity == maxCount)
				{
					totalQuantity = 0;
				}

			}



			if (totalQuantity >= maxCount)
			{
				result = (decimal)totalQuantity / (decimal)maxCount;
				pint = (int)result;
				pdec = totalQuantity - (maxCount * pint);


			}
			else
				pdec = totalQuantity;


			if (pint == 1)
				t = tFactor + " container!";
			else if (pint > 1)
				t = tFactor + String.Format(" {0} containers!", pint);

			if (pdec > 0 && pint != 0)
				t += String.Format("\r\nPlease keep {0} items for next bin", pdec);

			totalQuantity = pdec;

			if (!String.IsNullOrEmpty(t))
				MessageBox.Show(t);



			//display count
			if (labelSender != null)
			{
				if (counterDown)
				{
					if ((sol_CategoryButtonList[indice]).SubContainerCountDown)
						if (totalQuantity == (sol_CategoryButtonList[indice]).SubContainerMaxCount)
							totalQuantity = 0;
					labelSender.Text = (maxCount - totalQuantity).ToString();
				}
				else
				{
					labelSender.Text = totalQuantity.ToString();
				}
			}

			return totalQuantity;

		}

		private void totals()
		{
			int totalqty = 0;
			//decimal totalamt = 0.00M;
			//decimal totalAmount = 0.00M;
			totalAmount = 0.00M;
			int nrows = listView1.Items.Count;

			for (int i = 0; i < nrows; i++)
			{
				totalqty = totalqty + Convert.ToInt32(listView1.Items[i].SubItems[0].Text);
				string c = listView1.Items[i].SubItems[3].Text;
				c = c.Replace('$', ' ');
				totalAmount = totalAmount + Convert.ToDecimal(c);
			}


			if (sol_Fee != null)
			{
				if (sol_Fee.Percentage)
					textBoxFeeAmount.Text = CalculateFeePer(totalAmount, sol_Fee.FeeAmount).ToString();
				try { totalAmount -= Decimal.Parse(textBoxFeeAmount.Text); }
				catch { }
			}

			labelTotalQty.Text = String.Format("Qty:" + Funciones.Indent(2) + "{0,4:#,###}", totalqty);
			labelTotalAmt.Text = String.Format("Total:{0,13:$#,###,##0.00}", totalAmount);

			if (Main.CustomerScreenForm != null)
			{
				string totalQty = String.Format("Quantity:\n " + Funciones.Indent(20) + "{0,3}", totalqty);
				string totalAmt = String.Format("Total:\n" + Funciones.Indent(7) + "{0,10:$##,##0.00}", totalAmount);

				CustomerScreen.labelTotalQty.Text = totalQty;
				CustomerScreen.labelTotalAmt.Text = totalAmt;
			}

			textBoxRFID.Focus();

		}

		//read controls for workstation
		private void ReadControls()
		{
			panelCategoryButtons.Controls.Clear();

			//sol_CategoryButtonList = new List<Sol_CategoryButton>();
			//Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();
			//sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);

			sol_CategoryButtonList = sol_CategoryButton_Sp._SelectAllByButtonType(/*Main.Sol_ControlInfo.WorkStationID,*/ buttonType);


			this.arrayListItems = new ArrayList();

			int numberOfButtons = 3, buttonNumber = 1, panelWidth = panelCategoryButtons.Size.Width + 10;

			int scrollBarLength = 27;  //20
			int separationLength = 20;

			decimal ajuste = 1m;  // 0.95m;
			decimal ajusteHeight = 0.79m;
			int labelWidth = panelWidth - scrollBarLength, labelHeight = 34;  //37
			labelWidth = (int)(labelWidth * ajuste);
			labelHeight = (int)(labelHeight * ajusteHeight);
			int buttonWidth = (panelWidth - separationLength - scrollBarLength) / numberOfButtons, buttonHeight = 68; // 76 55;

			buttonWidth = (int)(buttonWidth * ajuste);
			buttonHeight = (int)(buttonHeight * ajusteHeight);

			int separatorX = 10, separatorY = 8;    //10

			int locationX = 0;  // panelCategoryButtons.Location.X;
			int locationY = panelCategoryButtons.Location.Y;

			int col = 0;
			int i = 0;
			foreach (Sol_CategoryButton cb in sol_CategoryButtonList)
			{

				Color foreColor = SolFunctions.ColorTryParse(cb.ForeColorArgb, cb.ForeColor);
				Color backColor = SolFunctions.ColorTryParse(cb.BackColorArgb, cb.BackColor);

				switch (cb.ControlType)
				{
					case 0: //Label

						locationX = 0;  // panelCategoryButtons.Location.X;
						if (i == 0)
							locationY -= separatorY;

						if (col > 0)
						{
							col = 0;
							locationY += buttonHeight + separatorY;
						}


						this.arrayListItems.Add(new System.Windows.Forms.Label());
						((System.Windows.Forms.Label)this.arrayListItems[i]).Location = new System.Drawing.Point(
							locationX + separatorX,
							locationY + separatorY
						);

						locationX = 0;  // panelCategoryButtons.Location.X;
						locationY += labelHeight + separatorY;

						((System.Windows.Forms.Label)this.arrayListItems[i]).Name = "Label_" + Convert.ToString(i);
						((System.Windows.Forms.Label)this.arrayListItems[i]).Size = new System.Drawing.Size(labelWidth, labelHeight);   // cb.Width, cb.Height);
						((System.Windows.Forms.Label)this.arrayListItems[i]).TabIndex = i + 2;
						((System.Windows.Forms.Label)this.arrayListItems[i]).Text = cb.Description.Trim();

						((System.Windows.Forms.Label)this.arrayListItems[i]).TextAlign = ContentAlignment.MiddleCenter;
						((System.Windows.Forms.Label)this.arrayListItems[i]).BorderStyle = BorderStyle.FixedSingle;

						((System.Windows.Forms.Label)this.arrayListItems[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);
						((System.Windows.Forms.Label)this.arrayListItems[i]).ForeColor = foreColor;
						((System.Windows.Forms.Label)this.arrayListItems[i]).BackColor = backColor;

						panelCategoryButtons.Controls.Add(((System.Windows.Forms.Label)this.arrayListItems[i++]));

						break;
					case 1: //Button
						int buttonWidth2 = buttonWidth;

						if (buttonNumber > 1)
							buttonWidth2 = (int)(buttonWidth / 1.32);
						else
							buttonWidth2 = (int)(buttonWidth * 1.50);

						buttonNumber++;
						if (buttonNumber > numberOfButtons) buttonNumber = 1;

						this.arrayListItems.Add(new System.Windows.Forms.Button());
						((System.Windows.Forms.Button)this.arrayListItems[i]).Location = new System.Drawing.Point(
							locationX + separatorX,
							locationY + separatorY
						);

						locationX += buttonWidth2 + separatorX;
						col++;
						if (col > 2)
						{
							col = 0;
							locationX = 0;// panelCategoryButtons.Location.X;
							locationY += buttonHeight + separatorY;
						}

						((System.Windows.Forms.Button)this.arrayListItems[i]).Name = "Button_" + Convert.ToString(i);
						((System.Windows.Forms.Button)this.arrayListItems[i]).Size = new System.Drawing.Size(buttonWidth2, buttonHeight);    //cb.Width, cb.Height);
						((System.Windows.Forms.Button)this.arrayListItems[i]).TabIndex = i + 2;
						((System.Windows.Forms.Button)this.arrayListItems[i]).Text = cb.Description.Trim();

						((System.Windows.Forms.Button)this.arrayListItems[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);
						((System.Windows.Forms.Button)this.arrayListItems[i]).ForeColor = foreColor;
						((System.Windows.Forms.Button)this.arrayListItems[i]).BackColor = backColor;

						((System.Windows.Forms.Button)this.arrayListItems[i]).Click += new System.EventHandler(this.button_Click);

						panelCategoryButtons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i++]));

						break;

				}
			}

		}

		//read controls for workstation
		private void ReadControlsQuantity()
		{
			panelQuantityButtons.Controls.Clear();

			sol_QuantityButtonList = new List<Sol_QuantityButton>();
			Sol_QuantityButton sol_QuantityButton = new Sol_QuantityButton();
			sol_QuantityButton_Sp = new Sol_QuantityButton_Sp(Properties.Settings.Default.WsirDbConnectionString);
			//sol_QuantityButtonList = sol_QuantityButton_Sp._SelectAllByWorkStationID(/*Main.Sol_ControlInfo.WorkStationID*/-1);
			sol_QuantityButtonList = sol_QuantityButton_Sp.SelectAll();

			this.arrayListItemsQuantity = new ArrayList();
			this.arrayListControlsQuantity = new ArrayList();

			int numberOfButtons = 1;
			int scrollBardLength = 20;
			int separationLength = 20;
			decimal ajuste = 1.2m;// 95m;
			decimal ajusteHeight = 0.79m;
			int buttonWidth = (panelQuantityButtons.Size.Width - separationLength - scrollBardLength) / numberOfButtons, buttonHeight = 76; // 55;
			buttonWidth = (int)(buttonWidth * ajuste);
			buttonHeight = (int)(buttonHeight * ajusteHeight);

			int separatorX = 10, separatorY = 10;

			int locationX = panelQuantityButtons.Location.X, locationY = panelQuantityButtons.Location.Y;

			int col = 0;
			int i = 0;
			foreach (Sol_QuantityButton cb in sol_QuantityButtonList)
			{
				arrayListControlsQuantity.Add(cb);

				switch (cb.ControlType)
				{
					case 1: //Button

						if (i == 0)
							locationY -= separatorY;


						this.arrayListItemsQuantity.Add(new System.Windows.Forms.Button());
						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).Location = new System.Drawing.Point(
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

						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).Name = "ButtonQuantity_" + Convert.ToString(i);
						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).Size = new System.Drawing.Size(buttonWidth, buttonHeight);    //cb.Width, cb.Height);
						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).TabIndex = i + 2;
						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).Text = cb.Description.Trim();

						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);
						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).ForeColor = Funciones.ColorParser(cb.ForeColor);
						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).BackColor = Funciones.ColorParser(cb.BackColor);

						((System.Windows.Forms.Button)this.arrayListItemsQuantity[i]).Click += new System.EventHandler(this.buttonQuantity_Click);

						panelQuantityButtons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItemsQuantity[i++]));

						break;

				}
			}

		}

		private void EnableControls(bool flag)
		{
			//panelCategoryButtons.Enabled = flag;
			//panelQuantityButtons.Enabled = flag;
			//panelNumericKb.Enabled = flag;

			//panelView.Enabled = flag;

			buttonDeleteRow.Enabled = flag;
            buttonDeleteRow.Visible = flag;

			comboBoxFees.Enabled = flag;
			textBoxFeeAmount.Enabled = flag;

		}

		private void EnableButtons(string buttonName)
		{
			//toolStripButtonReturns.Enabled = true;
			toolStripButtonCashier.Enabled = true;
			toolStripButtonLogOff.Enabled = true;
			// toolStripButtonExit.Enabled = true;
			exitButton.Enabled = true;

			if (Main.CardReader_Enabled)
			{
				if (Main.CardReader_EmulationMode == 0)    //HID
				{
				   Main.usbReadEventForm = "";

				   if (Main.myDeviceDetected)
						this.toolStripStatusLabelMsrMessage.Text = "was found";


					//tmrContinuousDataCollect.Enabled = false;
					//tmrContinuousDataCollect.Stop();

				   this.timerReturns.Enabled = false;
				   cardReadInProgress = false;
				}
				else if (Main.CardReader_EmulationMode == 1)    //KB
				{
					Main.usbReadEventForm = "";
				}

			}

			if (formQuickDrop)
			{
				buttonBagIdSubmit.Enabled = true;
				comboBoxBagId.Enabled = true;
			}


			buttonCancel.Text = "&Cancel";
			//toolStripButtonView.Text = "&Find";

			buttonMissingBags.Visible = false;
			//panelInstantStaging.Enabled = false;

			switch (buttonName)
			{
				case "new":
					buttonNew.Enabled = false;
                    buttonNew.Visible = false;
                    
					
                    buttonCancel.Enabled = true;    // false;
                    buttonCancel.Visible = true;
                    buttonCancel.Text = "&Cancel && Delete";
					toolStripButtonView.Enabled = false;
                    if (!currentOrderIsForBottleDrop)
                    {
                        buttonClose.Enabled = true;
                        buttonClose.Visible = true;
                        buttonExtra.Enabled = true;
                        buttonExtra.Visible = true;
                    }
					//buttonPutOnAccount.Enabled = true;
					//disable buttons
					buttonPutOnAccount.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", false);
                    if (currentOrderIsForBottleDrop)
                    {
                        buttonPutOnAccount.Enabled = true;
                        buttonPutOnAccount.Text = "Finish";
                        buttonPutOnAccount.BackColor = Color.FromArgb(0, 114, 187);
                        buttonPutOnAccount.ForeColor = SystemColors.Control;
                    }
                    buttonPutOnAccount.Visible = buttonPutOnAccount.Enabled;
					panelNumericKb.Enabled = true;

					if (Main.Sol_ControlInfo.NumericKeyPadOn)
						panelTableLayoutPanelView2_KeyPad.Enabled = true;

					toolStripButtonReturns.Enabled = false;
					toolStripButtonCashier.Enabled = false;
					toolStripButtonLogOff.Enabled = false;
					//toolStripButtonExit.Enabled = false;
					exitButton.Enabled = false;

                    //panelInstantStaging.Enabled = true;

                    

					if (Main.CardReader_Enabled)
					{
						if (Main.CardReader_EmulationMode == 0)    //hid
						{
							if (Main.myDeviceDetected)
							{
								Main.usbReadEventForm = "Returns";
								this.timerReturns.Enabled = true;
							}
						}
						else if (Main.CardReader_EmulationMode == 1)    //KB
						{
							Main.usbReadEventForm = "Returns";
						}
					}

					break;
				case "close":
					buttonNew.Enabled = true;
                    buttonNew.Visible = true;
					buttonClose.Enabled = false;
                    buttonClose.Visible = false;
                    buttonCancel.Enabled = false;
                    buttonCancel.Visible = false;

                    toolStripButtonView.Enabled = true;

					buttonExtra.Enabled = false;
                    buttonExtra.Visible = false;
                    buttonPutOnAccount.Enabled = false;
                    buttonPutOnAccount.Visible = false;

					//panelNumericKb.Enabled = false;
					//if (Main.Sol_ControlInfo.NumericKeyPadOn)
						//panelTableLayoutPanelView2_KeyPad.Enabled = false;

					toolStripButtonView.Text = "&Find";
                    toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Image;
                    if (currentOrderIsForBottleDrop) ClearBottleDrop();


                    break;
				case "cancel":
					buttonNew.Enabled = true;
                    buttonNew.Visible = true;
					buttonClose.Enabled = false;
                    buttonClose.Visible = false;
                    buttonCancel.Enabled = false;
                    buttonCancel.Visible = false;

                    toolStripButtonView.Enabled = true;

					buttonExtra.Enabled = false;
                    buttonExtra.Visible = false;
                    buttonPutOnAccount.Enabled = false;
                    buttonPutOnAccount.Visible = false;

                    if (currentOrderIsForBottleDrop) ClearBottleDrop();
                    //panelNumericKb.Enabled = false;
                    //if (Main.Sol_ControlInfo.NumericKeyPadOn)
                    //panelTableLayoutPanelView2_KeyPad.Enabled = false;

                    break;
				case "lookup":
					buttonNew.Enabled = false;
                    buttonNew.Visible = false;
                    buttonClose.Enabled = false;
                    buttonClose.Visible = false;
                    buttonCancel.Enabled = true;
                    buttonCancel.Visible = true;
                    toolStripButtonView.Enabled = false;

					buttonExtra.Enabled = false;
                    buttonExtra.Visible = false;
                    buttonPutOnAccount.Enabled = false;
                    buttonPutOnAccount.Visible = false;

					//panelNumericKb.Enabled = true;
					//if (Main.Sol_ControlInfo.NumericKeyPadOn)
						//panelTableLayoutPanelView2_KeyPad.Enabled = true;

					break;
				case "search":

					buttonNew.Enabled = true;
                    buttonNew.Visible = true;
                    buttonClose.Enabled = false;
                    buttonClose.Visible = false;
                    buttonCancel.Enabled = true;
                    buttonCancel.Visible = true;
                    toolStripButtonView.Enabled = true;
                    if (!currentOrderIsForBottleDrop)
                    {
                        buttonExtra.Enabled = true;
                        buttonExtra.Visible = true;
                    }
                    //buttonPutOnAccount.Enabled = true;
                    //disable buttons
                    buttonPutOnAccount.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", false);
                    if (currentOrderIsForBottleDrop)
                    {
                        buttonPutOnAccount.Enabled = true;
                        buttonPutOnAccount.Text = "Finish";
                        buttonPutOnAccount.BackColor = Color.FromArgb(0, 114, 187);
                        buttonPutOnAccount.ForeColor = SystemColors.Control;
                    }
                    
                    buttonPutOnAccount.Visible = buttonPutOnAccount.Enabled;
					//panelNumericKb.Enabled = false;
					//if (Main.Sol_ControlInfo.NumericKeyPadOn)
						//panelTableLayoutPanelView2_KeyPad.Enabled = false;

					break;
				case "edit":
					buttonNew.Enabled = false;
                    buttonNew.Visible = false;
                    
                    
                    buttonCancel.Enabled = true;//false;
                    buttonCancel.Visible = true;//false;
					//buttonCancel.Text = "&Cancel (Undo)";

					toolStripButtonView.Enabled = false;
                    if (!currentOrderIsForBottleDrop)
                    {
                        buttonClose.Enabled = true;
                        buttonClose.Visible = true;
                        buttonExtra.Enabled = true;
                        buttonExtra.Visible = true;
                    }
                    //buttonPutOnAccount.Enabled = true;
                    //disable buttons
                    buttonPutOnAccount.Enabled = Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", false);
                    if (currentOrderIsForBottleDrop)
                    {
                        buttonPutOnAccount.Enabled = true;
                        buttonPutOnAccount.Text = "Finish";
                        buttonPutOnAccount.BackColor = Color.FromArgb(0, 114, 187);
                        buttonPutOnAccount.ForeColor = SystemColors.Control;
                    }
                    buttonPutOnAccount.Visible = buttonPutOnAccount.Enabled;
					//panelNumericKb.Enabled = true;
					//if (Main.Sol_ControlInfo.NumericKeyPadOn)
						//panelTableLayoutPanelView2_KeyPad.Enabled = true;

					toolStripButtonReturns.Enabled = false;
					toolStripButtonCashier.Enabled = false;
					toolStripButtonLogOff.Enabled = false;
					//toolStripButtonExit.Enabled = false;
					exitButton.Enabled = false;

					if (Main.CardReader_Enabled)
					{
						if (Main.CardReader_EmulationMode == 0)    //hid
						{
							if (Main.myDeviceDetected)
							{
								Main.usbReadEventForm = "Returns";
								//tmrContinuousDataCollect.Enabled = true;
								//tmrContinuousDataCollect.Start();
								//ReadAndWriteToDevice();

								this.timerReturns.Enabled = true;
							}

						}
						else if (Main.CardReader_EmulationMode == 1)    //KB
						{
							Main.usbReadEventForm = "Returns";
						}

					}

					if (formQuickDrop)
					{
						comboBoxBagId.Enabled = false;
						buttonBagIdSubmit.Enabled = false;
					}
					break;
				default:
					break;
			}
			if (EnableNextinLine)
				buttonNextInLine.Visible = !buttonExtra.Enabled;
		}

		private void ClearForm()
		{
			comboBoxReturnId.Text = "";

			intQuantityButton = 1;
			listView1.Items.Clear();
			this.arrayListViewCategoryId.Clear();
			this.arrayListViewDetailId.Clear();
			this.arrayListViewCategoryButtonId.Clear();

			this.arrayListViewSubContainerCountDown.Clear();

			//flag to prevent comboBoxFees_SelectedIndexChanged to execute
			//flagClear = true;
			this.comboBoxFees.SelectedIndexChanged -= new System.EventHandler(this.comboBoxFees_SelectedIndexChanged);
			comboBoxFees.SelectedValue = 0;
			this.comboBoxFees.SelectedIndexChanged += new System.EventHandler(this.comboBoxFees_SelectedIndexChanged);
			//flagClear = false;
			textBoxFeeAmount.Text = "";

			sol_Fee = null;

			labelTotalQty.Text = "Qty:";
			labelTotalAmt.Text = "Total:";

			CustomerScreen.ClearCustomerScreen();

			if (sol_Order != null)
				sol_Order.OrderID = -1;


			if (Main.Sol_ControlInfo.NumericKeyPadOn)
			{
				//clear kp
				EventArgs e1 = new EventArgs();
				labelClear_Click(labelClear, e1);
			}

			if (formQuickDrop)
			{
				comboBoxBagId.Text = string.Empty;
				this.comboBoxBagId.SelectedIndexChanged -= new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);
				comboBoxBagId.SelectedIndex = -1;
				this.comboBoxBagId.SelectedIndexChanged += new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);
				labelBagCount.Text = string.Empty;
				bagIdFromTextBox = 0;
			}
		}

		private bool ReadVoucher(int returnId)
		{
			sol_Order = sol_Order_Sp.Select(returnId, strOrderType);
			if (sol_Order == null)
			{
				MessageBox.Show("Voucher not found! Try another please.");
				return false;
			}

			//A = normal D = void  O = On account P = paid or processed, I = In Process QuickDrop (not ready to be paid)
			string c = "";
			if (sol_Order.Status == "D")
				c = String.Format("Order {0} is voided! Try another please.", sol_Order.OrderID);
			else if (sol_Order.Status == "O" || sol_Order.Status == "P")
				c = String.Format("Order {0} is already Paid or On Account! Try another please.", sol_Order.OrderID);

			if (c != "")
			{
				MessageBox.Show(c);
				return false;
			}

			comboBoxFees.SelectedValue = sol_Order.FeeID;
			textBoxFeeAmount.Text = sol_Order.FeeAmount.ToString();

			//search for return
			sol_OrdersDetailList = sol_OrdersDetail_Sp._SelectAllByOrderID_OrderType(returnId, strOrderType);
			if (sol_OrdersDetailList == null)
			{
				MessageBox.Show("Voucher empty, try another please.");
				return false;
			}

			listView1.Items.Clear();

			foreach (Sol_OrdersDetail rd in sol_OrdersDetailList)
			{
				int quantity = rd.Quantity;
				string description = rd.Description;
				decimal price = rd.Price;
				int categoryId = rd.CategoryID;
				int categoryButtonId = rd.CategoryButtonID;


                if (!addItem(quantity, description, price, categoryId, rd.DetailID, false, categoryButtonId, 0, rd.BagID
                    , rd.ProductID
                    ))
                {
                    comboBoxReturnId.Text = string.Empty;
                    return false;
                }

			}

			totals();

			if (formQuickDrop)
				listViewOriginalCount = listView1.Items.Count;

			return true;
		}

		private void ShowNumericPad()
		{
			KeyPad f1 = new KeyPad();
			f1.ShowDialog();
			if (f1.resultNumber > 0)
				intQuantityButton = f1.resultNumber;

			f1.Dispose();
			f1 = null;

			if (intQuantityButton < 1) intQuantityButton = 1;

			flagNumericPad = false;

		}

		private string obtainOrderId(string s)
		{
			string[] parts = s.Split('-');

			return parts[0];

		}

		private int AddRow(ListViewItem itm, int categoryID, int categoryButtonId
			, int stagingProductID
			)
		{
			//if first item, add main row
			if (listView1.Items.Count < 1)
			{
				if (!AddMainRow())
					return -1;
			}

			//add current row
			sol_OrdersDetail = new Sol_OrdersDetail();

			//detailID
			//orderID
			sol_OrdersDetail.OrderID = sol_Order.OrderID;
			//orderType
			sol_OrdersDetail.OrderType = sol_Order.OrderType;
			//date
			sol_OrdersDetail.Date = Main.rc.FechaActual;    // sol_Order.Date;
			//status
			sol_OrdersDetail.Status = sol_Order.Status;

			//categoryID
			sol_OrdersDetail.CategoryID = categoryID;

			//productID
			//string description
			sol_OrdersDetail.Description = itm.SubItems[1].Text;
			//quantity
			int quantity = Convert.ToInt32(itm.SubItems[0].Text);
			sol_OrdersDetail.Quantity = quantity;
			//price
			decimal price = Convert.ToDecimal(itm.SubItems[2].Text);
			sol_OrdersDetail.Price = price;
			//amount
			string c = itm.SubItems[3].Text;
			c = c.Replace('$', ' ');
			decimal amount = Convert.ToDecimal(c);
			sol_OrdersDetail.Amount = amount;
			sol_OrdersDetail.CategoryButtonID = categoryButtonId;

			if (formQuickDrop)
				sol_OrdersDetail.BagID = qds_Bag.BagID;


			if(Properties.Settings.Default.StagingType != 0)    //Properties.Settings.Default.MultiProductStagingEnabled)
			{
				sol_OrdersDetail.ConveyorID = Main.ConveyorId;
				sol_OrdersDetail.ProductID = stagingProductID;
			}

            try
            {
                sol_OrdersDetail_Sp.Insert(sol_OrdersDetail);
            }
            catch
            {
                //try a second time
                sol_OrdersDetail_Sp.Insert(sol_OrdersDetail);
            }

            if (Properties.Settings.Default.StagingType == 2)
			{
				//Instant Staging
				currentOrderDetailID = sol_OrdersDetail.DetailID;
				buttonMove();
			}

			return sol_OrdersDetail.DetailID;
		}

        private void DeleteRow(ListViewItem itm, int index)
		{
			//delete current row
			int detailId = (int)this.arrayListViewDetailId[index];

			if (Properties.Settings.Default.StagingType == 2)
			{
				//Instant Staging
				sol_OrdersDetail = sol_OrdersDetail_Sp.Select(detailId);

				if (sol_Product_Sp == null)
					sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);
				sol_Product = sol_Product_Sp.Select(sol_OrdersDetail.ProductID);
				if (sol_Product == null)
					currentMasterProductID = 0;
				else
					currentMasterProductID = sol_Product.MasterProductID;

				currentOrderDetailID = detailId;
				buttonRemove();
			}

			sol_OrdersDetail_Sp.Delete(detailId);

			//if (qds_Bag != null)
			//{
			//    qds_Bag.DateCounted = Main.rc.FechaActual;
			//    qds_Bag_Sp.Update(qds_Bag);

			//}


			//delete main row if order empty
			if (listView1.Items.Count < 1)
				if (!DeleteMainRow())
					return;
		}

		private bool AddMainRow()
		{
			sol_Order = new Sol_Order();

			sol_Order.OrderType = strOrderType;
			sol_Order.WorkStationID = -1;   // Main.Sol_ControlInfo.WorkStationID;

			//computer name
			string c = Properties.Settings.Default.SettingsWsWorkStationName.Trim();
			if (String.IsNullOrEmpty(c))
				c = Main.myHostName;
			sol_Order.ComputerName = c;  // 

			membershipUser = membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
			if (membershipUser == null)
			{
				MessageBox.Show("User does not exits, cannot add Order");
				return false;
			}

			Guid userId = (Guid)membershipUser.ProviderUserKey;
			sol_Order.UserID = userId;
			sol_Order.UserName = Properties.Settings.Default.UsuarioNombre;
			sol_Order.Date = OpenDate;  // DateTime.Now;// Properties.Settings.Default.FechaActual;
			sol_Order.CashTrayID = Properties.Settings.Default.SettingsCurrentCashTray;

			sol_Order.CustomerID = 0; // (none)


			if (formQuickDrop)
				sol_Order.Status = "I";    //in Process (QuickDrop)Applied
			else
				sol_Order.Status = "A";    //Applied


			sol_Order.DateClosed = DateTime.Parse("1753-1-1 12:00:00");
			sol_Order.DatePaid = DateTime.Parse("1753-1-1 12:00:00");

			try { sol_Order.FeeID = (int)comboBoxFees.SelectedValue; }
			catch { sol_Order.FeeID = 0; }

			try { sol_Order.FeeAmount = Decimal.Parse(textBoxFeeAmount.Text); }
			catch { sol_Order.FeeAmount = Decimal.Zero; }

            try
            {
                sol_Order_Sp.Insert(sol_Order);
            }
            catch
            {
                //try a second time
                sol_Order_Sp.Insert(sol_Order);
            }

            if (sol_Order.OrderID < 1)
				return false;

			comboBoxReturnId.Text = sol_Order.OrderID.ToString();

			return true;

		}

		private bool DeleteMainRow()
		{
			sol_Order_Sp.Delete(sol_Order.OrderID, sol_Order.OrderType);
			//so it does not ask again for unsaved data if the user click cancel and then exit
			sol_Order.DateClosed = sol_Order.Date;

			if (formQuickDrop)
			{
				//delete orderid from qds_drop & bags
				try
				{
					List<Qds_Drop> qds_DropList = qds_Drop_Sp._SelectAllByOrderID_OrderType(sol_Order.OrderID, sol_Order.OrderType);
					if (!(qds_DropList == null || qds_DropList.Count < 1))
					{
						foreach (Qds_Drop d in qds_DropList)
						{
							d.OrderID = 0;
							d.OrderType = "Q";
							qds_Drop_Sp.Update(d);

							List<Qds_Bag> qds_BagList = qds_Bag_Sp._SelectAllByDropID(d.DropID);
							foreach (Qds_Bag b in qds_BagList)
							{
								b.DateCounted = DateTime.Parse("1753-1-1 12:00:00");
								b.DatePaid = DateTime.Parse("1753-1-1 12:00:00");
								qds_Bag_Sp.Update(b);
							}


						}

						qds_Drop = null;
						qds_Bag = null;
					}
				}
				catch { }
			}


			comboBoxReturnId.Text = "";

			sol_Order = null;

			return true;
		}

		private bool CloseOrder(bool close)
		{
			if (sol_Order == null)
				return true;
			try
			{
				if (sol_Order.OrderType == null)
					return true;
			}
			catch { return true; }

			//if (close)
			//    sol_Order.DateClosed = Main2.rc.FechaActual; // DateTime.Now;
			//else
			//    sol_Order.DateClosed = DateTime.Parse("1753-1-1 12:00:00");
			//sol_Order_Sp.Update(sol_Order);

			if (Main.CardReader_Enabled)
			{
				if (!LinkCardToOrder())
					return false;
			}


			if (close)
			{
				sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");

				//QuickDrop
				if (formQuickDrop)
				{

					//if (listViewOriginalCount != listView1.Items.Count)
					//{
						if (qds_Drop != null)
						{
							if (qds_Drop.OrderID < 1)
							{
								qds_Drop.OrderID = sol_Order.OrderID;
								qds_Drop.OrderType = sol_Order.OrderType;
								qds_Drop_Sp.Update(qds_Drop);
							}

							if (qds_Bag != null)
							{
								//check if bag has been counted
								bool flagCounted = false;
								foreach (ListViewItem itm in listView1.Items)
								{
									if (qds_Bag.BagID == Convert.ToInt32(itm.SubItems[4].Text))
									{
										flagCounted = true;
										break;
									}
								}

								if (flagCounted)
									qds_Bag.DateCounted = Main.rc.FechaActual;
								else
									qds_Bag.DateCounted = DateTime.Parse("1753-1-1 12:00:00");

								qds_Bag_Sp.Update(qds_Bag);
							}

							//is drop ready for payment?
							if (qds_Drop_Sp.IsReady(qds_Drop.DropID))
							{
								string status = String.Empty;
								if (qds_Drop.PaymentMethodID == 1)
									status = "A";
								else
									status = "O";
								sol_Order_Sp.UpdateStatus(sol_Order.OrderID, sol_Order.OrderType, status);
							}

							//udate customerID
							sol_Order_Sp._UpdateCustomerID(sol_Order.OrderID, sol_Order.OrderType, qds_Drop.CustomerID);
						}
					//}

					comboBoxBagId.Text = string.Empty;
					this.comboBoxBagId.SelectedIndexChanged -= new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);
					comboBoxBagId.SelectedIndex = -1;
					this.comboBoxBagId.SelectedIndexChanged += new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);

				}

			}
			else
			{
				sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "1753-1-1 12:00:00", "DateClosed");
				sol_Order.DateClosed = DateTime.Parse("1753-1-1 12:00:00");
			}

			return true;

		}

		private bool UpdateTotalFeeAmount()
		{

			if (listView1.Items.Count < 1)
				return false;

			//update fee id and amount
			sol_Order.FeeID = (int)comboBoxFees.SelectedValue;

			try { sol_Order.FeeAmount = Decimal.Parse(textBoxFeeAmount.Text); }
			catch { sol_Order.FeeAmount = Decimal.Zero; }

			//changes?
			if (feeAmountOrg == sol_Order.FeeAmount && feeIdOrg == sol_Order.FeeID)
				return true;


			try { sol_Order_Sp.UpdateFees(sol_Order.OrderID, sol_Order.OrderType, sol_Order.FeeID, sol_Order.FeeAmount); }
			catch { return false; }

			return true;
		}

        private bool CheckOrderStillOpen(string mode)
		{
			if (sol_Order == null || sol_Order.OrderID < 1)
				return true;


			if (sol_Order.DateClosed >= sol_Order.Date)
			{
				string c;
				if (mode == "Add")
					c = "This Order is already Closed. You cannot add more items to it!";
				else if (mode == "Close")
				{
					if (sol_Order.Status == "A")
						return true;
					c = "This Order is already Paid and Closed!";
				}
				else if (mode == "Delete")
					c = "This Order is already Closed. You cannot delete items from it!";
				else
					return true;

				MessageBox.Show(c);
				CancelProc();
				return false;
			}
			return true;
		}

		private bool CheckComputerNameOnOpenOrders()
		{
			//computer name
			string c = Properties.Settings.Default.SettingsWsWorkStationName.Trim();
			if (String.IsNullOrEmpty(c))
				c = Main.myHostName;

			if (sol_Order.ComputerName != c)
				return false;
			return true;
		}

		private void comboBoxReturnId_SelectedIndexChanged(object sender, EventArgs e)
		{
			//try
			//{
			//    comboBoxReturnId.Text = obtainOrderId(comboBoxReturnId.Text);
			//    if (String.IsNullOrEmpty(comboBoxReturnId.Text))
			//    {
			//        //MessageBox.Show("Please enter a Voucher number");
			//        comboBoxReturnId.Focus();
			//        return;
			//    }
			//    int returnId = 0;
			//    try
			//    {
			//        returnId = Int32.Parse(comboBoxReturnId.Text);
			//    }
			//    catch
			//    {
			//        //MessageBox.Show("Please enter a valid Voucher number.");
			//        return;
			//    }



			//    comboBoxReturnId.Enabled = false;
			//    comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
			//    buttonSubmit.Enabled = false;

			//    ReadOrder(returnId);

			//    //EnableButtons("search");
			//    toolStripButtonView.Text = "&Edit";

			//    //if (formQuickDrop)
			//    //{
			//    //    buttonBagIdSubmit.Enabled = false;
			//    //}

			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show("Error getting the order: " + ex.Message);
			//    return;
			//}

			buttonSubmit.PerformClick();

		}

		private bool ReadOrder(int returnId)
		{
			if (!ReadVoucher(returnId))
			{
				//MessageBox.Show("Voucher not found, try another number.");
				return false;
			}

			feeIdOrg = sol_Order.FeeID;
			feeAmountOrg = sol_Order.FeeAmount;


			if (!(sol_Order.Status == "A" || sol_Order.Status == "I"))
				toolStripButtonView.Enabled = false;

			if (sol_Order.DateClosed < sol_Order.Date)
			{
				if (!CheckComputerNameOnOpenOrders())
				{
					if (MessageBox.Show("This Order was created in another terminal. Do not continue unless you know what you are doing. Do you want to continue?",
						"Warning form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
					{
						if (MessageBox.Show("Please make sure that no one else is using this order! Do you still want to continue?", "Warning Form", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
						{
							//edit state
							toolStripButtonView.PerformClick();
						}
						else
						{
							buttonCancel.Enabled = true;
							buttonCancel.PerformClick();
							buttonCancel.Enabled = false;
							return false;
						}
					}
					else
					{
						buttonCancel.Enabled = true;
						buttonCancel.PerformClick();
						buttonCancel.Enabled = false;
						return false;
					}

				}
				else
				{
					//edit state
					//toolStripButtonView.PerformClick();
				}
			}

			if (formQuickDrop)
			{
				if (qds_Drop_Sp == null)
					qds_Drop_Sp = new Qds_Drop_Sp(Properties.Settings.Default.WsirDbConnectionString);

				List<Qds_Drop> dl = qds_Drop_Sp._SelectAllByOrderID_OrderType(sol_Order.OrderID, sol_Order.OrderType);
				Qds_Drop d = dl[0];

				if (qds_Bag_Sp == null)
					qds_Bag_Sp = new Qds_Bag_Sp(Properties.Settings.Default.WsirDbConnectionString);

				List<Qds_Bag> bl = qds_Bag_Sp._SelectAllByDropID(d.DropID);

				//comboBoxBagId
				comboBoxBagId.Items.Clear();
				comboBoxBagId.DropDownStyle = ComboBoxStyle.Simple;
				foreach (Qds_Bag b in bl)
				{
					comboBoxBagId.Items.Add(b.BagID);
				}

				//comboBoxBagId.Enabled = true;
				//comboBoxBagId.Text = string.Empty;
				//comboBoxBagId.SelectedIndex = -1;

				if (comboBoxBagId.Items.Count > 0)
				{
					comboBoxBagId.DropDownStyle = ComboBoxStyle.DropDown;
				}

				labelBagCount.Text = string.Format("({0}) bags found.", comboBoxBagId.Items.Count);


				int numOfBags = comboBoxBagId.Items.Count;

				List<int> listOfBagsCounted = new List<int>();
				List<int> listOfBagsNotCounted = new List<int>();
				int missingBags = GetNumberOfMissingBags(numOfBags, ref listOfBagsCounted, ref listOfBagsNotCounted);

				if (missingBags == 0)
				{
					buttonMissingBags.Visible = false;
					MessageBox.Show("All bags on this drop have now been counted.  The order is now ready to be paid out.");
				}
				else
				{
					buttonMissingBags.Visible = true;

				}

				if (numOfBags > 0)
				{
					if (comboBoxBagId.SelectedIndex < 0)
					{
						this.comboBoxBagId.SelectedIndexChanged -= new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);


						int i = comboBoxBagId.FindStringExact(bagIdFromTextBox.ToString());
						if (i < 0) i = 0;
						comboBoxBagId.SelectedIndex = i;

						this.comboBoxBagId.SelectedIndexChanged += new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);
					}
				}

			}

			return true;
		}

		private void buttonSubmit_Click(object sender, EventArgs e)
		{
			try
			{
				comboBoxReturnId.Text = obtainOrderId(comboBoxReturnId.Text);
				if (String.IsNullOrEmpty(comboBoxReturnId.Text))
				{
					comboBoxReturnId.Focus();
                    orderLookupPanel.Visible = false;
					return;
				}
				int returnId = 0;
				try
				{
					returnId = Int32.Parse(comboBoxReturnId.Text);
				}
				catch
				{
                    orderLookupPanel.Visible = false;
					return;
				}

                orderLookupPanel.Visible = false;
				comboBoxReturnId.Enabled = false;
				comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
				buttonSubmit.Enabled = false;

				toolStripButtonView.Text = "&Edit";
                toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Text;

				if (!ReadOrder(returnId))
				{
					toolStripButtonView.Text = "&Find";
                    toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Image;

				}


			}
			catch (Exception ex)
			{
				toolStripButtonView.Text = "&Find";
                toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Image;
				MessageBox.Show("Error getting the order: " + ex.Message);
                orderLookupPanel.Visible = false;
				return;
			}



		}

		private void buttonExtra_Click(object sender, EventArgs e)
		{

            //check order consistency between virdis and sql server
            if (sol_Order != null && !CheckOrderConsistency())
                return;

            //check if the order is still open 
            if (buttonClicked == "&New" || buttonClicked == "&Edit")
			{
				buttonClicked = "C&ash Out";
				if (!CheckOrderStillOpen("Close"))
				{
					buttonExtra.Enabled = true;
                    buttonExtra.Visible = true;
					return; //false;
				}
			}

			if (sol_Order != null)
			{
				comboBoxReturnId.Text = sol_Order.OrderID.ToString();

				UpdateTotalFeeAmount();    //Int32.Parse(comboBoxReturnId.Text));

				CloseOrder(true);
			}

			//extra button 0 = QuickCashOut 1 = Print Chit
			ListView listView2 = new ListView();
			if (!CreateListView(ref listView2, ""))
			{
				buttonExtra.Enabled = true;
                buttonExtra.Visible = true;

                return;
			}

			ListView.ListViewItemCollection Items = listView2.Items;
			foreach (ListViewItem item in Items)
				item.Checked = true;


			if (Main.Sol_ControlInfo.ReturnButtonExtra == 0)    //quick cash out
			{

				ListView.CheckedListViewItemCollection checkedItems = listView2.CheckedItems;
				if (checkedItems.Count < 1)
				{
					MessageBox.Show("No Orders selected");
					buttonExtra.Enabled = true;
                    buttonExtra.Visible = true;

                    return;
				}

				CashierCash f1 = new CashierCash();

				f1.buttonSource = "CashOut";
				f1.checkedItems = checkedItems;
				f1.onAccount = false;

				if (Main.Sol_ControlInfo.ReceiptAmountBarcode)
					f1.totalSelectedOrders = totalAmount;

				f1.ShowDialog();
				bool ordersProcessed = f1.ordersProcessed;
				f1.Dispose();
				f1 = null;

				if (!ordersProcessed)
				{
					//view state
					EnableControls(false);
					EnableButtons("search");
					buttonClicked = "&Find";
                    toolStripButtonView.Text = "&Edit";
                    toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    toolStripButtonView.PerformClick();
					//buttonExtra.Enabled = true;
					return;
				}
                
			}
			else
			{
				//
				this.Cursor = Cursors.WaitCursor;

				string errorMessage = string.Empty;
				bool flag = SolFunctions.PrintReceipt(listView2, "chit", ref errorMessage, Properties.Settings.Default.BarcodeEncoding
					, "PrintChit"
					, Main.Sol_ControlInfo.IncludeSecurityCode ? sol_Order.SecurityCode.ToString() : String.Empty
					, Main.Sol_ControlInfo.ReceiptAmountBarcode ? totalAmount : 0.0m
					);
				this.Cursor = Cursors.Default;
				if (!flag)
				{
					MessageBox.Show("There was a problem printing the receipt, please try again.\nError: " + errorMessage);
					//view state
					EnableControls(false);
					EnableButtons("search");
					buttonClicked = "&Find";
					//buttonExtra.Enabled = true;
					return;
				}


			}

			//view state
			EnableControls(false);
			EnableButtons("close");

			ClearForm();

			this.AcceptButton = originalAcceptButton;
			comboBoxReturnId.Enabled = false;
			comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
			buttonSubmit.Enabled = false;

		}

		private void buttonPutOnAccount_Click(object sender, EventArgs e)
		{
			//if (Main.Sol_ControlInfo.ReturnButtonExtra != 0)    //quick cash out
			//    return;

			if (!Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolPutOnAccountButton", true))
				return;

			//check cashier
			//if (!Cashier.CheckCashier())
			//    return;

			//check if the order is still open 
			if (buttonClicked == "&New" || buttonClicked == "&Edit")
				if (!CheckOrderStillOpen("Close"))
					return; //false;

			if (sol_Order != null)
			{
				comboBoxReturnId.Text = sol_Order.OrderID.ToString();

				UpdateTotalFeeAmount();    //Int32.Parse(comboBoxReturnId.Text));

				CloseOrder(true);
			}

			ListView listView2 = new ListView();
			if (!CreateListView(ref listView2, ""))
				return;

			ListView.ListViewItemCollection Items = listView2.Items;
			foreach (ListViewItem item in Items)
				item.Checked = true;


			ListView.CheckedListViewItemCollection checkedItems = listView2.CheckedItems;
			if (checkedItems.Count < 1)
			{
				MessageBox.Show("No Orders selected");
				return;
			}

			CashierCash f1 = new CashierCash();

			f1.buttonSource = "Cashier";
			f1.checkedItems = checkedItems;
			f1.strOrderType = "R";
			f1.onAccount = true;
            if (currentOrderIsForBottleDrop)
            {
                f1.BottleDrop = true;
                f1.BottleDropCustomer = bdjsCurrentOrder.Customer;
                f1.BottleDropBagID = bdjsCurrentOrder.BagID;
                f1.BottleDropOrderDetails = CreateBottleDropOrderDetail();
            }

			if (Main.Sol_ControlInfo.ReceiptAmountBarcode)
				f1.totalSelectedOrders = totalAmount;

			f1.ShowDialog();
			bool ordersProcessed = f1.ordersProcessed;
			f1.Dispose();
			f1 = null;

			if (!ordersProcessed)
			{
                ///view state
                EnableControls(false);
                EnableButtons("search");
                buttonClicked = "&Find";
                toolStripButtonView.Text = "&Edit";
                toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Text;
                toolStripButtonView.PerformClick();
                //buttonExtra.Enabled = true;
                return;
            }

            

			//view state
			EnableControls(false);
			EnableButtons("close");



			ClearForm();

			this.AcceptButton = originalAcceptButton;
			comboBoxReturnId.Enabled = false;
			comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
			buttonSubmit.Enabled = false;

		}

		private bool CreateListView(ref ListView listView2, string men)
		{
			int orderID = 0;
			Int32.TryParse(comboBoxReturnId.Text, out orderID);
			sol_Order = sol_Order_Sp.Select(orderID, strOrderType);
			if (sol_Order == null)
			{
				MessageBox.Show("Sorry, this order no longer exist! (Order #" + comboBoxReturnId.Text.Trim() + ")");
				return false;
			}

			if (!(sol_Order.Status == "A" || sol_Order.Status == "I"))
			{
				MessageBox.Show("Sorry, this order is already paid! (Order #" + comboBoxReturnId.Text.Trim() + ")");
				return false;
			}

			//open order
			if (sol_Order.DateClosed < sol_Order.Date)
			{
				MessageBox.Show("Sorry, this order is open! (Order #" + comboBoxReturnId.Text.Trim() + ")");
				return false;
			}

			//listview with headers
			listView2.View = View.Details;
			listView2.Columns.Add("Order #", 190, HorizontalAlignment.Right);
			listView2.Columns.Add("Amount", 150, HorizontalAlignment.Right);
			listView2.Columns.Add("Station", 150, HorizontalAlignment.Left);
			listView2.Columns.Add("Employee", 157, HorizontalAlignment.Left);
			listView2.Columns.Add("T", 50, HorizontalAlignment.Center);
			listView2.Columns.Add("Fee", 124, HorizontalAlignment.Right);
			listView2.Columns.Add("Open Time", 180, HorizontalAlignment.Center);
			listView2.Columns.Add("Submit Time", 200, HorizontalAlignment.Center);
			listView2.Columns.Add("Status", 110, HorizontalAlignment.Center);

			//listView1.Columns.Add("Order #", 80, HorizontalAlignment.Center);
			//listView1.Columns.Add("Amount", 75, HorizontalAlignment.Center);
			//listView1.Columns.Add("Fee", 75, HorizontalAlignment.Center);
			//listView1.Columns.Add("Type", 60, HorizontalAlignment.Center);


			listView2.FullRowSelect = true;
			listView2.CheckBoxes = true;
			listView2.GridLines = true;

			listView2.Items.Clear();
			string[] str = new string[10];
			ListViewItem itm;   // = new ListViewItem();
			str[0] = sol_Order.OrderID.ToString().Trim();
			str[1] = sol_Order.TotalAmount.ToString();
			str[2] = sol_Order.ComputerName;
			str[3] = sol_Order.UserName;
			str[4] = sol_Order.OrderType;
			str[5] = sol_Order.FeeAmount.ToString();
			str[6] = sol_Order.Date.TimeOfDay.ToString().Substring(0, 8);
			str[7] = sol_Order.DateClosed.TimeOfDay.ToString().Substring(0, 8);
			str[8] = sol_Order.Status;

			itm = new ListViewItem(str);
			listView2.Items.Add(itm);

			return true;
		}

		//                                                      MaxCount = 10                           CountDown = True
		private void updateThreshold(int totalQuantity, int subContainerMaxCount, short factor, bool subContainerCountDown)
		{

			if (labelSender == null)
				return;
			if (subContainerMaxCount < 1 && factor == 1)
				return;

			//buttonSender.Text = m[0] + " " + splitter + " " + counter.ToString();
			string mes = labelSender.Text;
			int counter = 0;
			try
			{
				Int32.TryParse(mes, out counter);
			}
			catch { }

			string t = String.Empty;

			if (subContainerCountDown)
			{
				if (String.IsNullOrEmpty(mes))
					counter = subContainerMaxCount;
				counter -= (totalQuantity * factor);

				if (counter <= 0 && factor == 1)
				{
					if (counter < 0)
						t = String.Format("\r\nPlease keep {0} items for next bin", counter * -1);
					//labelSender.Text = counter.ToString();
					counter += subContainerMaxCount;
					MessageBox.Show("Time to close the container!" + t);
					//if (counter < 1)
					//{
					//    label3.Text = String.Empty;
					//    return;
					//}

				}
				if (counter > subContainerMaxCount)
					counter = subContainerMaxCount;
			}
			else
			{
				counter += (totalQuantity * factor);
				if (counter < 0) counter = 0;   //subContainerMaxCount - totalQuantity;            

				if (counter >= subContainerMaxCount && factor == 1)
				{
					if (counter > subContainerMaxCount)
						t = String.Format("\r\nPlease keep {0} items for next bin", counter - subContainerMaxCount);

					//labelSender.Text = counter.ToString();
					counter -= subContainerMaxCount;
					MessageBox.Show("Time to close the container!" + t);
					//if (counter < 1)
					//{
					//    label3.Text = String.Empty;
					//    return;
					//}

				}
			}

			labelSender.Text = counter.ToString();

		}

		private bool[] flags = new bool[20];

		private void toolStripButtonResetCounter_Click(object sender, EventArgs e)
		{

			short index = 0;
			if (toolStripButtonResetCounter.Text != "Adjust count")
			{
				panel1.Enabled = flags[index++];
				listView1.Enabled = flags[index++];
				panel2.Enabled = flags[index++];
				panel4.Enabled = flags[index++];
				panelButtonExtra.Enabled = flags[index++];

				panelView.Enabled = flags[index++];
				panelCategoryButtons.Enabled = flags[index++];
				panelQuantityButtons.Enabled = flags[index++];
				panelNumericKb.Enabled = flags[index++];
				panelTableLayoutPanelView2_KeyPad.Enabled = flags[index++];

				toolStripButtonReturns.Enabled = flags[index++];
				toolStripButtonSales.Enabled = flags[index++];
				toolStripButtonCashier.Enabled = flags[index++];
				toolStripButtonLogOff.Enabled = flags[index++];
				toolStripButtonAttendance.Enabled = flags[index++];
				//toolStripButtonExit.Enabled = flags[index++];
				exitButton.Enabled = flags[index++];
				toolStripButtonResetCounter.Text = "Adjust count";
				toolStripButtonResetCounter.BackgroundImage = Properties.Resources.AdjustCount;
				messageLabel.Visible = false;
				messageLabel.Text = "";
				//toolStripLabelResetCounter.Visible = false;
				//toolStripSeparatorResetCounter.Visible = false; 

				toolStripSeparatorQdBags.Visible = false;

				return;
			}


			//toolStripButtonResetCounter.Visible = false;

			//toolStripLabelResetCounter.Visible = true;
			//toolStripSeparatorResetCounter.Visible = true;

			//Main.tslCntr = toolStripLabelResetCounter;
			//Main.timerBlink.Enabled = true;

			//toolStripButtonResetCounter.Visible = true;
			toolStripButtonResetCounter.Text = "Done";
			toolStripSeparatorQdBags.Visible = true;
			toolStripButtonResetCounter.BackgroundImage = Properties.Resources.ExitAdjustCount;
			messageLabel.Text = "Please Select Bin To Adjust";
			messageLabel.Visible = true;
		   

			index = 0;
			flags[index++] = panel1.Enabled;                                //orders panel
			flags[index++] = listView1.Enabled;                             //orders items
			flags[index++] = panel2.Enabled;                                //totals panel
			flags[index++] = panel4.Enabled;                                //buttons panel
			flags[index++] = panelButtonExtra.Enabled;                                //extra button panel
			flags[index++] = panelView.Enabled;                             //catbuttons and keypad panel
			flags[index++] = panelCategoryButtons.Enabled;                  //catbuttons panel
			flags[index++] = panelQuantityButtons.Enabled;                //quantity buttons panel old
			flags[index++] = panelNumericKb.Enabled;                      //numerickb panel        old
			flags[index++] = panelTableLayoutPanelView2_KeyPad.Enabled;
			flags[index++] = toolStripButtonReturns.Enabled;
			flags[index++] = toolStripButtonSales.Enabled;
			flags[index++] = toolStripButtonCashier.Enabled;
			flags[index++] = toolStripButtonLogOff.Enabled;
			flags[index++] = toolStripButtonAttendance.Enabled;
			//flags[index++] = toolStripButtonExit.Enabled;
			flags[index++] = exitButton.Enabled;

			bool flag = false;
			panel1.Enabled = flag;
			listView1.Enabled = flag;
			panel2.Enabled = flag;
			panel4.Enabled = flag;
			panelButtonExtra.Enabled = flag;

			panelView.Enabled = !flag;
			//panelCategoryButtons.Enabled = !flag;
			//panelQuantityButtons.Enabled = flag;
			//panelNumericKb.Enabled = flag;
			//panelTableLayoutPanelView2_KeyPad.Enabled = !flag;

			toolStripButtonReturns.Enabled = flag;
			toolStripButtonSales.Enabled = flag;
			toolStripButtonCashier.Enabled = flag;
			toolStripButtonLogOff.Enabled = flag;
			toolStripButtonAttendance.Enabled = flag;
			//toolStripButtonExit.Enabled = flag;
			exitButton.Enabled = flag;

		}

		private void toolStripButtonSave_Click(object sender, EventArgs e)
		{
			adjustBinCount(0);  //save
			toolStripButtonResetCounter.PerformClick();
		}

		private void toolStripButtonAdd_Click(object sender, EventArgs e)
		{
			adjustBinCount(1);  //add

		}

		private void toolStripButtonRemove_Click(object sender, EventArgs e)
		{
			adjustBinCount(2);  //remove

		}

		private void adjustBinCount(short action)
		{
			//action 0 = save, 1 = add, 2 = remove
			int categoryButtonId = (sol_CategoryButtonList[indice]).CategoryButtonID;
			int intValue = 0;
			Int32.TryParse(toolStripTextBoxCount.Text, out intValue);

			if (intValue < 0)
				return;



			if (action == 0)            //save
			{
				sol_BinCount = sol_BinCount_Sp.Select(Main.myHostName, categoryButtonId);
				if (sol_BinCount == null)
				{
					sol_BinCount = new Sol_BinCount();
					sol_BinCount.ClientID = Main.myHostName;
					sol_BinCount.CategoryButtonID = categoryButtonId;
					sol_BinCount.CurrentCount = 0;

					//sol_BinCount.CurrentCount = intValue;
					sol_BinCount_Sp.Insert(sol_BinCount);
				}

				sol_BinCount.CurrentCount = intValue;
				if ((sol_CategoryButtonList[indice]).SubContainerCountDown)
					if (sol_BinCount.CurrentCount == (sol_CategoryButtonList[indice]).SubContainerMaxCount)
						sol_BinCount.CurrentCount = 0;

				if (sol_BinCount.CurrentCount > (sol_CategoryButtonList[indice]).SubContainerMaxCount)
				{
					MessageBox.Show("The new count cannot be bigger than the button's threshold, cannot adjust it!");
					return;
				}

				if ((sol_CategoryButtonList[indice]).SubContainerCountDown)
					if (sol_BinCount.CurrentCount == (sol_CategoryButtonList[indice]).SubContainerMaxCount)
						sol_BinCount.CurrentCount = 0;

				sol_BinCount_Sp.Update(sol_BinCount);

				//display count
				if (labelSender != null)
				{
					//intValue = sol_BinCount.CurrentCount;
					if ((sol_CategoryButtonList[indice]).SubContainerCountDown)
					{
						intValue = (sol_CategoryButtonList[indice]).SubContainerMaxCount - sol_BinCount.CurrentCount;
						if (intValue == 0)
							intValue = (sol_CategoryButtonList[indice]).SubContainerMaxCount;

						//labelSender.Text = ((sol_CategoryButtonList[indice]).SubContainerMaxCount - sol_BinCount.CurrentCount).ToString();
					}
					else
					{
						intValue = sol_BinCount.CurrentCount;
						//labelSender.Text = sol_BinCount.CurrentCount.ToString();
					}

					labelSender.Text = intValue.ToString();
				}
				enableAdjustCountControls(false);

			}

			else if (action == 1)       //add
			{
				if ((sol_CategoryButtonList[indice]).SubContainerMaxCount > 0)
					updateCurrentCount(
						intValue,
						(sol_CategoryButtonList[indice]).SubContainerCountDown,
						categoryButtonId,
						(sol_CategoryButtonList[indice]).SubContainerMaxCount,
						1
					);

			}
			else //if (action == 2)       //remove
			{
				if ((sol_CategoryButtonList[indice]).SubContainerMaxCount > 0)
					updateCurrentCount(
						intValue,
						(sol_CategoryButtonList[indice]).SubContainerCountDown,
						categoryButtonId,
						(sol_CategoryButtonList[indice]).SubContainerMaxCount,
						-1
					);
			}


			//enableAdjustCountControls(false);

		}

		private void toolStripButtonCancel_Click(object sender, EventArgs e)
		{

			enableAdjustCountControls(false);
			toolStripButtonResetCounter.PerformClick();


		}

		private void enableAdjustCountControls(bool flag)
		{

			toolStripSeparatorQdBags.Visible = !flag;

			//toolStripLabelResetCounter.Visible = !flag;
			//toolStripSeparatorResetCounter.Visible = !flag;

			toolStripButtonResetCounter.Visible = !flag;

			toolStripSeparatorResetCounter.Visible = flag;
			//toolStripLabelCount.Visible = flag;
			toolStripTextBoxCount.Visible = flag;
			toolStripSeparatorCount.Visible = flag;

			toolStripButtonSave.Visible = flag;
			toolStripSeparatorSave.Visible = flag;
		    toolStripButtonAdd.Visible = flag;
		   // toolStripSeparatorAdd.Visible = flag;
		    toolStripButtonRemove.Visible = flag;
		   // toolStripSeparatorRemove.Visible = flag;
			toolStripButtonCancel.Visible = flag;

			toolStripSeparatorVirtualKb.Visible = !flag;


			//panelCategoryButtons.Enabled = !flag;
			//panelNumericKb.Enabled = flag;
			//panelTableLayoutPanelView2_KeyPad.Enabled = flag;

			if (flag)
			{
				toolStripTextBoxCount.Focus();
				messageLabel.Text = "Please enter new count or touch save to reset to zero.";
			}


			//clear kp
			EventArgs e1 = new EventArgs();
			labelClear_Click(labelClear, e1);
		}

		private void toolStripButtonAttendance_Click(object sender, EventArgs e)
		{
			Attendance f1 = new Attendance();
			f1.ShowDialog();
			f1.Dispose();
			f1 = null;

		}

		private void CheckComputerRole()
		{
			//computer roles
			toolStripButtonCashier.Enabled = true;
			if (!(
				Properties.Settings.Default.UsuarioNombre.ToLower() == "admin"
				|| Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin")
				|| Properties.Settings.Default.SettingComputerRole == 0   //full role
				))
			{
				switch (Properties.Settings.Default.SettingComputerRole)
				{
					//case 0:     //full role
					//    break;
					case 1:     //Returns/Sales
						toolStripButtonCashier.Enabled = false;
						break;
					//case 2:     //Cashier
					//    break;
					//case 3:     //Shipping
					//    break;
					default:    //anything else
						exitButton.PerformClick();
						break;

				}

			}

		}

		private void comboBoxReturnId_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)//(char)13)
			{                           // Then Enter key was pressed
				buttonSubmit.PerformClick();
			}
		}

		//http://stackoverflow.com/questions/1226726/how-do-i-capture-the-enter-key-in-a-windows-forms-combobox
		private void comboBoxReturnId_Enter(object sender, EventArgs e)
		{
			this.AcceptButton = null;

		}

		private void comboBoxReturnId_Leave(object sender, EventArgs e)
		{
			this.AcceptButton = this.buttonExtra;

		}

		private bool LinkCardToOrder()
		{

			//if (this.arrayListCardNumber == null)
			//    return true;

			//if (this.arrayListCardNumber.Count <1)
			//    return true;

			//if (String.IsNullOrEmpty((string)this.arrayListCardNumber[0]))
			//    return true;



			//string[] cardNumberArray = ((string)this.arrayListCardNumber[0]).Split('&');
			//if (String.IsNullOrEmpty(cardNumberArray[0]))
			//{
			//    strCardNumber = String.Empty;
			//    MessageBox.Show("Error reading the card number, try again please");
			//    return false;
			//}
			//else
			//{
			//    cardNumberArray[0] = cardNumberArray[0].Replace("\r", "");
			//    strCardNumber = cardNumberArray[0].Substring(2);
			//}


			if (String.IsNullOrEmpty(Main.strMsrCardNumber))
				return true;

			string strCardNumber = Main.strMsrCardNumber;
			Main.strMsrCardNumber = String.Empty;


			if(listView1.Items.Count<1)
				return true;


			if (sol_OrderCardLink_Sp == null)
				sol_OrderCardLink_Sp = new Sol_OrderCardLink_Sp(Properties.Settings.Default.WsirDbConnectionString);

			if (sol_OrderCardLog_Sp == null)
				sol_OrderCardLog_Sp = new Sol_OrderCardLog_Sp(Properties.Settings.Default.WsirDbConnectionString);

			//(if a card read error message is returned from the card reader, the error message should be displayed)

			//b) If NOT OPTION1 is selected it checks to see if any other order is linked to that cardnumber in the sol_OrderCardLink table.
			//            If another order is linked already:
			//                   If OPTION2 was selected, 
			//                          Delete entry in solOrderCardLink and proceed to 5c
			//                   ELSE  'OPTION3
			//                          If the ordernumber on the card the same as the current ordernumber?  
			//                                       Delete entry in sol_OrderCardLink table and proceed to 5c)
			//                          Else 
			//                               Check status of order linked to card.
			//                                    If order is already paid, 
			//                                                Delete entry in sol_OrderCardLink table and proceed to 5c
			//                                     Else (if order linked to card isn't paid)  pop up this message:  "This card already is linked to Order [order number].  Please use a different card."

			//bool cardReader_CloseOrder;
			//byte cardReader_LinkMethod_Opcion;

			if (Main.CardReader_LinkMethod != 0)
			{
				sol_OrderCardLink = sol_OrderCardLink_Sp.SelectByCardNumber(strCardNumber);
				if (sol_OrderCardLink != null)
				{
					if (Main.CardReader_LinkMethod == 1)
					{
						//sol_OrderCardLink_Sp.Delete(strCardNumber, sol_Order.OrderID);
						sol_OrderCardLink_Sp.DeleteByCardNumber(strCardNumber);
					}
					else if (Main.CardReader_LinkMethod == 2)
					{
						if (sol_OrderCardLink.OrderID == sol_Order.OrderID)
						{
							//sol_OrderCardLink_Sp.Delete(strCardNumber, sol_Order.OrderID);
							sol_OrderCardLink_Sp.DeleteByCardNumber(strCardNumber);
						}
						else
						{
							if (sol_Order.Status == "P")
							{
								//sol_OrderCardLink_Sp.Delete(strCardNumber, sol_Order.OrderID);
								sol_OrderCardLink_Sp.DeleteByCardNumber(strCardNumber);
							}
							else
							{
								//MessageBox.Show(String.Format("This card number: {0} already is linked to Order: {1}.  Please use a different card", strCardNumber, sol_OrderCardLink.OrderID));

								Funciones.DisplayAutoClosingMessageBox(
									this,
									String.Format("This card number: {0} already is linked to Order: {1}.  Please use a different card", strCardNumber, sol_OrderCardLink.OrderID),
									"Returns Screen",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation,
									1000 * 5//FrontScreen.MessageTimeOut
								);

								//this.arrayListCardNumber.Clear();
								strCardNumber = String.Empty;
								return false;
							}

						}
					}

				}
			}
			//c) it saves / closes the order
			//d) it creates an entry in the sol_OrderCardLink table with CardNumber and OrderId
			sol_OrderCardLink = new Sol_OrderCardLink();
			sol_OrderCardLink.CardNumber = strCardNumber;
			sol_OrderCardLink.OrderID = sol_Order.OrderID;
			sol_OrderCardLink_Sp.Insert(sol_OrderCardLink);

			//e) it creates an entry in the sol_OrderCardLog table with CardNumber, OrderId, GetDate()
			sol_OrderCardLog = new Sol_OrderCardLog();
			sol_OrderCardLog.CardNumber = strCardNumber;
			sol_OrderCardLog.OrderID = sol_Order.OrderID;
			sol_OrderCardLog.DateAdded = Main.rc.FechaActual;
			sol_OrderCardLog.DatePaid = DateTime.Parse("1753-1-1 12:00:00");
			sol_OrderCardLog_Sp.Insert(sol_OrderCardLog);



			//f) pop up a message that says "Order [Ordernumber] was successfully linked to Card [cardnumber]"  The message should be on a timer and the message should disappear after 10 seconds.
			//MessageBox.Show(String.Format("Order: {0} was successfully linked to Card: {1}", sol_Order.OrderID, strCardNumber));
			Funciones.DisplayAutoClosingMessageBox(
				this,
				String.Format("Order: {0} was successfully linked to Card: {1}", sol_Order.OrderID, strCardNumber),
				"Returns Screen",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation,
				1000 * 3//FrontScreen.MessageTimeOut
			);


			strCardNumber = String.Empty;

			return true;
		}

		private void toolStripButtonQdCustomer_Click(object sender, EventArgs e)
		{
			if (!((Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolViewCustomer", false)
	|| Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, "SolEditCustomer", false))))
			{
				MessageBox.Show("Sorry, you don't have permission to view and edit customers");
				return;
			}
			Customers f1 = new Customers();
			f1.manageMode = true;
			f1.customerType = 1;    //quickdrop
			f1.ShowDialog();
			f1.Dispose();
			f1 = null;

		}

		//check order consistency between virdis and sql server
		private bool CheckOrderConsistency()
		{
            string messageTitle = @"An unexpected problem ocurred. We apologize for the inconvenience.";
            string messageError = string.Empty;
            bool result = true;
            try
            {
                //check items
                decimal detailsTotalAmount = 0.00M;
                decimal detailsTotalAmountCompute = 0;

                sol_OrdersDetailList = sol_OrdersDetail_Sp._SelectAllByOrderID_OrderType(sol_Order.OrderID, sol_Order.OrderType);
                if (sol_OrdersDetailList == null)
                    sol_OrdersDetailList = new List<Sol_OrdersDetail>();
                else
                {
                    //check totals, returns forms total = sol_order_TotalAmount = sum of sol_orderdetails.amount
                    foreach (var od in sol_OrdersDetailList)
                    {
                        detailsTotalAmountCompute += od.Quantity * od.Price;
                        detailsTotalAmount += od.Amount;
                    }
                }

                if (totalAmount != detailsTotalAmount
                    || totalAmount != detailsTotalAmountCompute
                    || listView1.Items.Count != sol_OrdersDetailList.Count()
                    )
                {
                    //sol_OrdersDetail_Sp._DeleteAllByOrderID_OrderType(sol_Order.OrderID, sol_Order.OrderType);

                    int categoryID = 0, categoryButtonID = 0, detailID = 0;
                    bool counterDown = false;

                    int index = 0;
                    foreach (ListViewItem itm in listView1.Items)
                    {
                        try
                        {
                            categoryID = (int)arrayListViewCategoryId[index];
                            counterDown = (bool)arrayListViewSubContainerCountDown[index];
                            categoryButtonID = (int)arrayListViewCategoryButtonId[index];
                            detailID = (int)arrayListViewDetailId[index];
                            //sol_OrdersDetail = sol_OrdersDetailList[index];
                        }
                        catch
                        {
                            categoryID = 0;
                            counterDown = false;
                            categoryButtonID = 0;
                            detailID = 0;
                            //sol_OrdersDetail = new Sol_OrdersDetail();
                        }

                        index++;

                        decimal price = 0m, amount = 0m;
                        int quantity = 0;
                        int.TryParse(itm.SubItems[0].Text, out quantity);
                        decimal.TryParse(itm.SubItems[2].Text, out price);
                        decimal.TryParse(itm.SubItems[3].Text.Replace("$", ""), out amount);

                        if (detailID > 0)
                            sol_OrdersDetail = sol_OrdersDetail_Sp.Select(detailID);

                        if (sol_OrdersDetail == null || sol_OrdersDetail.DetailID < 1)
                            sol_OrdersDetail = new Sol_OrdersDetail();

                        #region add item

                        if (sol_OrdersDetail.DetailID < 1)
                        {
                            sol_OrdersDetail.OrderID = sol_Order.OrderID;
                            sol_OrdersDetail.OrderType = sol_Order.OrderType;
                            sol_OrdersDetail.Date = sol_Order.Date;
                            sol_OrdersDetail.CategoryID = categoryID;
                            sol_OrdersDetail.Description = itm.SubItems[1].Text;
                            sol_OrdersDetail.Quantity = quantity;
                            sol_OrdersDetail.Price = price;
                            sol_OrdersDetail.Amount = amount;
                            sol_OrdersDetail.Status = sol_Order.Status;
                            sol_OrdersDetail.CategoryButtonID = categoryButtonID;

                            if (formQuickDrop)
                                sol_OrdersDetail.BagID = qds_Bag.BagID;

                            if (Properties.Settings.Default.StagingType != 0)
                            {
                                sol_OrdersDetail.ConveyorID = Main.ConveyorId;
                                //sol_OrdersDetail.ProductID = stagingProductID;
                            }
                            //sol_OrdersDetail.StageID
                            sol_OrdersDetail_Sp.Insert(sol_OrdersDetail);

                            return result;
                        }

                        #endregion

                        #region update item

                        if (sol_OrdersDetail.Quantity != quantity
                            || sol_OrdersDetail.Price != price
                            || sol_OrdersDetail.Amount != amount
                            )
                        {
                            sol_OrdersDetail.Quantity = quantity;
                            sol_OrdersDetail.Price = price;
                            sol_OrdersDetail.Amount = amount;

                            sol_OrdersDetail_Sp.Update(sol_OrdersDetail);
                        }

                        #endregion

                    }
                }

            }
            catch (SqlException sqlex)
            {
                messageError = sqlex.Message;
                result = false;
            }

            catch (Exception ex)
            {
                messageError = ex.Message;
                result = false;
            }

            if (!result)
            {
                messageError += "\n" + string.Format("Please try again later or remove this order:{0}, and start all over again.", sol_Order.OrderID);
                MessageBox.Show(messageError, messageTitle);
            }

            return result;
        }

        private bool orderCommentsUpdate(int orderId, string orderType, string comments)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
            {
                try
                {
                    string sql = @"
							UPDATE [sol_Orders] WITH (ROWLOCK)
							SET [Comments] = @Comments
							WHERE [OrderID] = @OrderID	AND [OrderType] = @OrderType
							";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.Add(new SqlParameter("@OrderID", orderId));
                        command.Parameters.Add(new SqlParameter("@OrderType", orderType));
                        command.Parameters.Add(new SqlParameter("@Comments", comments));
                        command.ExecuteNonQuery();

                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return true;

        }

        private void comboBoxFees_Enter(object sender, EventArgs ex)
        {
            //textBoxRFID.LostFocus += new EventHandler((s, e) => textBoxRFID.Focus());

        }

        private void textBoxRFID_TextChanged(object sender, EventArgs e)
        {

            //if (textBoxRFID.Text.Contains((char)13)) 
            //{
            //    MessageBox.Show("You Entered: " + textBoxRFID.Text);
            //}

        }

        private void textBoxRFID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBoxRFID.Text.Length < 10)
                {
                    textBoxRFID.Text = string.Empty;
                    return;
                }

                Main.strMsrCardNumber = textBoxRFID.Text;
                textBoxRFID.Text = string.Empty;

                //MessageBox.Show("You Entered: " + textBoxRFID.Text);

                timerReturns_Tick(textBoxRFID, new System.EventArgs());
            }
        }

        #endregion

        #region UsbHid Methods

        private void timerReturns_Tick(object sender, System.EventArgs e)
		{

			if (String.IsNullOrEmpty(Main.strMsrCardNumber))
			{
				return;
			}

			//toolStripStatusLabelMsrMessage.Text = Main.strMsrCardNumber;

			if (listView1.Items.Count < 1)
			{
				Main.strMsrCardNumber = String.Empty;
				return;
			}

			if (cardReadInProgress)
				return;

			cardReadInProgress = true;

			buttonClose.PerformClick();
			cardReadInProgress = false;
			Main.strMsrCardNumber = String.Empty;


		}

		#endregion

		#region QuickDrop Methods

		public bool formQuickDrop { get; set; }

		private void buttonBagIdSubmit_Click(object sender, EventArgs e)
		{
			listViewItemsCount = 0;

			//if (buttonClose.Enabled)
			//{
			//    string bid = comboBoxBagId.Text;
			//    buttonClose.PerformClick();
			//    comboBoxBagId.Text = bid;
			//}

			bagIdFromTextBox = 0;
			int.TryParse(comboBoxBagId.Text, out bagIdFromTextBox);

			if (bagIdFromTextBox < 1)
			{
				MessageBox.Show("Please enter a valid BagID!");
				comboBoxBagId.Focus();
				return;
			}

			if (qds_Bag_Sp == null)
				qds_Bag_Sp = new Qds_Bag_Sp(Properties.Settings.Default.WsirDbConnectionString);

			qds_Bag = qds_Bag_Sp.Select(bagIdFromTextBox);
			if(qds_Bag == null)
			{
				MessageBox.Show("BagID not found! Try another please.");
				comboBoxBagId.Focus();
				return;
			}

			if(qds_Bag.DateCounted.Year > 1753)
			{
				//MessageBox.Show("This bag was already counted! Do you want to view the order?");
				DialogResult result = MessageBox.Show("This bag was already counted! Do you want to view the order?", "", MessageBoxButtons.YesNo);
				if (result != System.Windows.Forms.DialogResult.Yes)
				{
					comboBoxBagId.Text = string.Empty;
					this.comboBoxBagId.SelectedIndexChanged -= new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);
					comboBoxBagId.SelectedIndex = -1;
					this.comboBoxBagId.SelectedIndexChanged += new System.EventHandler(this.comboBoxBagId_SelectedIndexChanged);
					comboBoxBagId.Focus();
					return;
				}
			}


			if (qds_Drop_Sp == null)
				qds_Drop_Sp = new Qds_Drop_Sp(Properties.Settings.Default.WsirDbConnectionString);

			qds_Drop = qds_Drop_Sp.Select(qds_Bag.DropID);
			if (qds_Drop == null)
			{
				MessageBox.Show("Invalid BagID! Try another please.");
				comboBoxBagId.Focus();
				return;
			}

			if (qds_Drop.OrderID < 1)
			{

				//new order
				//buttonNew.PerformClick();
				feeIdOrg = 0;
				feeAmountOrg = 0;

				//date of creation
				OpenDate = Main.rc.FechaActual; // ;

				//ClearForm();
					comboBoxReturnId.Text = "";
					intQuantityButton = 1;
					listView1.Items.Clear();
					this.arrayListViewCategoryId.Clear();
					this.arrayListViewDetailId.Clear();
					this.arrayListViewCategoryButtonId.Clear();
					this.arrayListViewSubContainerCountDown.Clear();

					//flag to prevent comboBoxFees_SelectedIndexChanged to execute
					//flagClear = true;
					this.comboBoxFees.SelectedIndexChanged -= new System.EventHandler(this.comboBoxFees_SelectedIndexChanged);
					comboBoxFees.SelectedValue = 0;
					this.comboBoxFees.SelectedIndexChanged += new System.EventHandler(this.comboBoxFees_SelectedIndexChanged);
					//flagClear = false;
					textBoxFeeAmount.Text = "";

					labelTotalQty.Text = "Qty:";
					labelTotalAmt.Text = "Total:";

					CustomerScreen.ClearCustomerScreen();
					if (sol_Order != null)
						sol_Order.OrderID = -1;
					//clear kp
					EventArgs e1 = new EventArgs();
					labelClear_Click(labelClear, e1);


				buttonClicked = buttonNew.Text; // "new";
				
				//buttonClicked = "&New";

				EnableControls(true);
				EnableButtons("new");

				//qds_Drop.OrderID = sol_Order.OrderID;
				//qds_Drop.OrderType = sol_Order.OrderType;


				toolStripButtonView.Text = "&Edit";
                toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Text;
				buttonCancel.Enabled = true;
                buttonCancel.Visible = true;

                comboBoxReturnId.Enabled = false;

				comboBoxBagId.Enabled = false;



			}
			else
			{
				//select order
				if (!ReadOrder(qds_Drop.OrderID))
				{
					comboBoxBagId.SelectAll();
					comboBoxBagId.Focus();
					return;
				}



				comboBoxReturnId.Text = qds_Drop.OrderID.ToString();

				//toolStripButtonView.PerformClick();

				toolStripButtonView.Text = "&Edit";
                toolStripButtonView.DisplayStyle = ToolStripItemDisplayStyle.Text;
				buttonCancel.Enabled = true;
                buttonCancel.Visible = true;
                comboBoxReturnId.Enabled = false;
				
				//comboBoxBagId.Enabled = false;



			}

			if (qds_Bag.DateCounted.Year == 1753)
				toolStripButtonView.PerformClick();

		}

		private void toolStripButtonQdBags_Click(object sender, EventArgs e)
		{
			QdBags f1 = new QdBags();
			f1.ShowDialog();
			int bagID = f1.bagID;
			f1.Dispose();
			f1 = null;

			if (bagID > 0)
			{
				comboBoxBagId.Text = bagID.ToString();
				comboBoxBagId.Focus();
				buttonBagIdSubmit.PerformClick();
			}
		}

		private void comboBoxBagId_Enter(object sender, EventArgs e)
		{
			this.AcceptButton = null;

		}

		private void comboBoxBagId_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)//(char)13)
			{                           // Then Enter key was pressed
				buttonBagIdSubmit.PerformClick();
			}

		}

		private void comboBoxBagId_Leave(object sender, EventArgs e)
		{
			this.AcceptButton = this.buttonExtra;

		}

		private void comboBoxBagId_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonBagIdSubmit.PerformClick();
		}

		private void buttonMissingBags_Click(object sender, EventArgs e)
		{
			int numOfBags = comboBoxBagId.Items.Count;

			if (numOfBags < 1)
			{
				MessageBox.Show("There are no bags to check!");
				return;
			}

			List<int> listOfBagsCounted = new List<int>();
			List<int> listOfBagsNotCounted = new List<int>();
			int missingBags = GetNumberOfMissingBags(numOfBags, ref listOfBagsCounted, ref listOfBagsNotCounted);

			if (missingBags < 1)
			{
				MessageBox.Show("There are no missing bags!");
				return;
			}

			string m = String.Format("{0} bags from this drop have not been counted yet.  Do you want to complete this order and set the status of the rest of the bags to MISSING?", missingBags);
			if (MessageBox.Show(m, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
				return;


			//busy cursor
			this.Cursor = Cursors.WaitCursor;
			SolFunctions.CompleteOrder(
			sol_Order.OrderID
			, sol_Order.OrderType
			, ref listOfBagsCounted
			, ref listOfBagsNotCounted
			);

			this.Cursor = Cursors.Default;
			MessageBox.Show("Ready!");

			//change status of order from (I) InProgress to (A) Ready 
			qds_Bag = null;
			CloseOrder(true);

			//view state
			EnableControls(false);
			EnableButtons("close");
			//toolStripButtonView.Text = "&Find";

			ClearForm();

			this.AcceptButton = originalAcceptButton;
			comboBoxReturnId.Enabled = false;
			comboBoxReturnId.DropDownStyle = ComboBoxStyle.Simple;
			buttonSubmit.Enabled = false;

			comboBoxBagId.DropDownStyle = ComboBoxStyle.Simple;
		}

		//public static void CompleteOrder(
		//    int orderID
		//    , string orderType
		//    , ref List<int> listOfBagsCounted
		//    , ref List<int> listOfBagsNotCounted
		//    )
		//{

		//    if (listOfBagsNotCounted.Count < 1)
		//        return;

		//    //set the status of the rest of the bags to MISSING
		//    Qds_Drop_Sp qds_Drop_Sp = new Qds_Drop_Sp(Properties.Settings.Default.WsirDbConnectionString);

		//    List<Qds_Drop> dl = qds_Drop_Sp._SelectAllByOrderID_OrderType(orderID, orderType);
		//    Qds_Drop qds_Drop = dl[0];
		//    Qds_Bag_Sp qds_Bag_Sp = new Qds_Bag_Sp(Properties.Settings.Default.WsirDbConnectionString);

		//    List<Qds_Bag> bl = qds_Bag_Sp._SelectAllByDropID(qds_Drop.DropID);
		//    //create new drop for missing bags
		//    Qds_Drop nd = new Qds_Drop();
		//    //nd.DropID = 0;
		//    nd.CustomerID = qds_Drop.CustomerID;
		//    nd.NumberOfBags = listOfBagsNotCounted.Count;  // od.NumberOfBags;
		//    nd.PaymentMethodID = qds_Drop.PaymentMethodID;
		//    nd.DepotID = qds_Drop.DepotID;
		//    nd.OrderID = 0;
		//    nd.OrderType = "M"; //missing
		//    qds_Drop_Sp.Insert(nd);

		//    //move missing bags to new drop
		//    //foreach(ComboBoxItem i in comboBoxBagId.Items)

		//    foreach (int id in listOfBagsNotCounted)
		//    {
		//        //move missing bag
		//        Qds_Bag mb = qds_Bag_Sp.Select(id); //bagIdFromComboBox);
		//        mb.DropID = nd.DropID;
		//        qds_Bag_Sp.Update(mb);

		//    }

		//    //change numer of bags of the original drop
		//    qds_Drop.NumberOfBags -= listOfBagsNotCounted.Count();
		//    qds_Drop_Sp.Update(qds_Drop);

		//    //close order
		//    Sol_Order_Sp sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
		//    Sol_Order sol_Order = sol_Order_Sp.Select(orderID, orderType);

		//    sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");

		//    //is drop ready for payment?
		//    if (qds_Drop_Sp.IsReady(qds_Drop.DropID))
		//    {
		//        string status = String.Empty;
		//        if (qds_Drop.PaymentMethodID == 1)
		//            status = "A";
		//        else
		//            status = "O";
		//        sol_Order_Sp.UpdateStatus(sol_Order.OrderID, sol_Order.OrderType, status);
		//    }

		//    //update customerID
		//    //sol_Order_Sp._UpdateCustomerID(sol_Order.OrderID, sol_Order.OrderType, qds_Drop.CustomerID);




		//}

		private int GetNumberOfMissingBags(
			int numOfBags
			, ref List<int> listOfBagsCounted
			, ref List<int> listOfBagsNotCounted
			)
		{
			int formerBagId = 0, bagId = 0;
			//bags counted
			foreach (ListViewItem itm in listView1.Items)
			{
				bagId = Convert.ToInt32(itm.SubItems[4].Text);
				if (formerBagId != bagId)
				{
					formerBagId = bagId;
					listOfBagsCounted.Add(formerBagId);
				}
			}

			//missing bags
			for (int i = 0; i < numOfBags; i++)
			{
				bagId = (int)comboBoxBagId.Items[i];
				
				if (listOfBagsCounted.IndexOf(bagId) < 0)
				{
					//move missing bag
					listOfBagsNotCounted.Add(bagId);
				}

			   }


			return listOfBagsNotCounted.Count;

		}

		#endregion

		#region tableLayoutPanelView2 Routines   //NumericKeyPad On

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
			//this.tableLayoutPanelView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(56)))));

			int buttonWidthOffset = 0;
			int buttonHeightOffset = 0;

			int buttonXOffset = 0;
			int buttonYOffset = 0;
			if (buttonType == 3)
			{
				buttonWidthOffset = 20;
				buttonHeightOffset = 15;

				buttonXOffset = 10;
				buttonYOffset = 0;

			}

			this.tableLayoutPanelView2.ColumnCount = 2;
			float size1 = 0F;
			float size2 = 0F;
			int col1 = 0;
			int col2 = 0;

			if (Main.Sol_ControlInfo.NumericKeyPadPosition == 0)    //right
			{
				size1 = CategoryButtons.buttonContainerWidth; // 245F;
				size2 = 367F;
				col1 = 1;
				col2 = 0;
			}
			else
			{
				size1 = 367F;
				size2 = CategoryButtons.buttonContainerWidth; // 245F;
				col1 = 0;
				col2 = 1;
			}
			this.tableLayoutPanelView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, size1));
			this.tableLayoutPanelView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, size2));
			this.tableLayoutPanelView2.Controls.Add(this.panelTableLayoutPanelView2_KeyPad, col1, 0);
			this.tableLayoutPanelView2.Controls.Add(this.panelTableLayoutPanelView2_Buttons, col2, 0);

			this.tableLayoutPanelView2.Name = "tableLayoutPanelView2";
			this.tableLayoutPanelView2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.tableLayoutPanelView2.RowCount = 1;
			this.tableLayoutPanelView2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelView2.TabIndex = 12;
			// 
			// panelTableLayoutPanelView2Left
			// 
			this.panelTableLayoutPanelView2_KeyPad.BackgroundImage = global::Solum.Properties.Resources.NumericKeyPad2;
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

			if (buttonType == 2)
				this.panelTableLayoutPanelView2_KeyPad.Dock = System.Windows.Forms.DockStyle.Fill;
			else
			{
				this.panelTableLayoutPanelView2_KeyPad.Location = new System.Drawing.Point(this.panelTableLayoutPanelView2_Buttons.Width, 1);   //3, 3
				this.panelTableLayoutPanelView2_KeyPad.Size = new System.Drawing.Size(          //410, 476);    //361, 476
					410
					, 476 + (6 * buttonHeightOffset)
					);
			}

			this.panelTableLayoutPanelView2_KeyPad.Name = "panelTableLayoutPanelView2Left";

			//this.panelTableLayoutPanelView2_KeyPad.Size = new System.Drawing.Size(361, 476);

			this.panelTableLayoutPanelView2_KeyPad.TabIndex = 0;
			// 
			// labelClear
			// 
			this.labelClear.BackColor = System.Drawing.Color.Transparent;
			this.labelClear.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.labelClear.Location = new System.Drawing.Point(250 + buttonWidthOffset, 4);
			this.labelClear.Name = "labelClear";
			//this.labelClear.Size = new System.Drawing.Size(102 + buttonWidthOffset, 64 + buttonHeightOffset);
			this.labelClear.TabIndex = 17;
			this.labelClear.Click += new System.EventHandler(this.labelClear_Click);

			// 
			// labelPadTotal
			// 
			this.labelPadTotal.BackColor = System.Drawing.Color.Transparent;
			this.labelPadTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPadTotal.ForeColor = Color.FromArgb(0, 114, 187);
			//this.labelPadTotal.Location = new System.Drawing.Point(16, 3);
			this.labelPadTotal.Location = new System.Drawing.Point(16, 3);
			this.labelPadTotal.Name = "labelPadTotal";
			//this.labelPadTotal.Size = new System.Drawing.Size(220, 29 + buttonHeightOffset);
			this.labelPadTotal.Size = new System.Drawing.Size(220, 60);
			this.labelPadTotal.TabIndex = 23;
			this.labelPadTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;



			// 
			// labelPad
			// 
			this.labelPad.BackColor = System.Drawing.Color.Transparent;
			this.labelPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPad.ForeColor = Color.FromArgb(0, 114, 187);
			//this.labelPad.Location = new System.Drawing.Point(16, 26);
			this.labelPad.Location = new System.Drawing.Point(16, 3);
			this.labelPad.Name = "labelPad";
			//this.labelPad.Size = new System.Drawing.Size(220, 36 + buttonHeightOffset);
			this.labelPad.Size = new System.Drawing.Size(220, 60);
			this.labelPad.TabIndex = 16;
			this.labelPad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labeBackSpace
			// 
			this.labeBackSpace.BackColor = System.Drawing.Color.Transparent;
			this.labeBackSpace.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.labeBackSpace.Location = new System.Drawing.Point(248 + buttonWidthOffset, 81 + buttonHeightOffset);
			this.labeBackSpace.Name = "labeBackSpace";
			//this.labeBackSpace.Size = new System.Drawing.Size(102 + buttonWidthOffset, 64 + buttonHeightOffset);
			this.labeBackSpace.TabIndex = 15;
			this.labeBackSpace.Click += new System.EventHandler(this.labelBackSpace_Click);

			//this.labelClear

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
			//this.labelX02.ImageIndex = sol_QuantityButton.DefaultQuantity; //i'm using imageIndex to stored defaultQuantity
			this.labelX01.Text = sol_QuantityButton.Description;
			this.labelX01.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelX01.ForeColor = System.Drawing.Color.FromArgb(0, 114, 187);
			this.labelX01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			this.labelX01.BackColor = System.Drawing.Color.Transparent;
			this.labelX01.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.labelX01.Location = new System.Drawing.Point(1, 81 + buttonHeightOffset);
			this.labelX01.Name = "labelX" + sol_QuantityButton.DefaultQuantity.ToString();
			//this.labelX01.Size = new System.Drawing.Size(102  + buttonWidthOffset, 64 + buttonHeightOffset);
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

			this.labelX02.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelX02.ForeColor = System.Drawing.Color.FromArgb(0, 114, 187);
			this.labelX02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			this.labelX02.BackColor = System.Drawing.Color.Transparent;
			this.labelX02.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.labelX02.Location = new System.Drawing.Point(129 + buttonWidthOffset, 81 + buttonHeightOffset);
			this.labelX02.Name = "labelX" + sol_QuantityButton.DefaultQuantity.ToString();
			//this.labelX02.Size = new System.Drawing.Size(102 + buttonWidthOffset, 64 + buttonHeightOffset);
			this.labelX02.TabIndex = 13;
			this.labelX02.Click += new System.EventHandler(this.labelX_Click);  //this.labelX01_Click);

			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label7.Location = new System.Drawing.Point(1, 165 + buttonHeightOffset);   //15, 158
			this.label7.Name = "label7";
			//this.label7.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);         //98, 57
			this.label7.TabIndex = 3;
			this.label7.Click += new System.EventHandler(this.label0_Click);
			this.label7.DoubleClick += new System.EventHandler(this.label0_Click);

			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label8.Location = new System.Drawing.Point(130 + buttonWidthOffset, 165 + buttonHeightOffset);  //134, 157
			this.label8.Name = "label8";
			//this.label8.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);    //98,57
			this.label8.TabIndex = 4;
			this.label8.Click += new System.EventHandler(this.label0_Click);
			this.label8.DoubleClick += new System.EventHandler(this.label0_Click);
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label9.Location = new System.Drawing.Point(248 + buttonWidthOffset, 165 + buttonHeightOffset);
			this.label9.Name = "label9";
			//this.label9.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.label9.TabIndex = 5;
			this.label9.Click += new System.EventHandler(this.label0_Click);
			this.label9.DoubleClick += new System.EventHandler(this.label0_Click);

			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label4.Location = new System.Drawing.Point(1, 252 + buttonHeightOffset);
			this.label4.Name = "label4";
			//this.label4.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.label4.TabIndex = 6;
			this.label4.Click += new System.EventHandler(this.label0_Click);
			this.label4.DoubleClick += new System.EventHandler(this.label0_Click);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label5.Location = new System.Drawing.Point(129 + buttonWidthOffset, 252 + buttonHeightOffset);
			this.label5.Name = "label5";
			//this.label5.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.label5.TabIndex = 7;
			this.label5.Click += new System.EventHandler(this.label0_Click);
			this.label5.DoubleClick += new System.EventHandler(this.label0_Click);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label6.Location = new System.Drawing.Point(247 + buttonWidthOffset, 252 + buttonHeightOffset);
			this.label6.Name = "label6";
			//this.label6.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.label6.TabIndex = 8;
			this.label6.Click += new System.EventHandler(this.label0_Click);
			this.label6.DoubleClick += new System.EventHandler(this.label0_Click);

			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label1.Location = new System.Drawing.Point(1, 336 + buttonHeightOffset);
			this.label1.Name = "label1";
			//this.label1.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.label1.TabIndex = 9;
			this.label1.Click += new System.EventHandler(this.label0_Click);
			this.label1.DoubleClick += new System.EventHandler(this.label0_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label2.Location = new System.Drawing.Point(129 + buttonWidthOffset, 336 + buttonHeightOffset);
			this.label2.Name = "label2";
			//this.label2.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.label2.TabIndex = 10;
			this.label2.Click += new System.EventHandler(this.label0_Click);
			this.label2.DoubleClick += new System.EventHandler(this.label0_Click);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label3.Location = new System.Drawing.Point(246 + buttonWidthOffset, 336 + buttonHeightOffset);
			this.label3.Name = "label3";
			//this.label3.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.label3.TabIndex = 11;
			this.label3.Click += new System.EventHandler(this.label0_Click);
			this.label3.DoubleClick += new System.EventHandler(this.label0_Click);

			// 
			// label0
			// 
			this.label0.BackColor = System.Drawing.Color.Transparent;
			this.label0.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.label0.Location = new System.Drawing.Point(1, 422 + buttonHeightOffset);
			this.label0.Name = "label0";
			//this.label0.Size = new System.Drawing.Size(220 + buttonWidthOffset, 70 + buttonHeightOffset);
			this.label0.TabIndex = 12;
			this.label0.Click += new System.EventHandler(this.label0_Click);
			this.label0.DoubleClick += new System.EventHandler(this.label0_Click);
			// 
			// labelX
			// 
			this.labelX.BackColor = System.Drawing.Color.Transparent;
			this.labelX.Cursor = System.Windows.Forms.Cursors.Hand;
			//this.labelX.Location = new System.Drawing.Point(250 + buttonWidthOffset, 424 + buttonHeightOffset);
			this.labelX.Name = "labelX";
			//this.labelX.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);
			this.labelX.TabIndex = 22;

			//this.labelX.Text = "X";
			//this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			//this.labelX.ForeColor = System.Drawing.Color.WhiteSmoke;
			//this.labelX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			this.labelX.Click += new System.EventHandler(this.labelXMultiply_Click);
			this.labelX.DoubleClick += new System.EventHandler(this.labelXMultiply_Click);

			//this.labelClear.Text = "clear";
			//this.labeBackSpace.Text = "back";

			//this.label7.Text = "label7";
			//this.label8.Text = "label8";
			//this.label9.Text = "label9";

			//this.label4.Text = "label4";
			//this.label5.Text = "label5";
			//this.label6.Text = "label6";

			//this.label1.Text = "label1";
			//this.label2.Text = "label2";
			//this.label3.Text = "label3";

			//this.label0.Text = "label0";
			//this.labelX.Text = "labelX";

			//this.labelClear.BorderStyle = BorderStyle.Fixed3D;
			//this.labeBackSpace.BorderStyle = BorderStyle.Fixed3D;

			//this.labelX01.BorderStyle = BorderStyle.Fixed3D;
			//this.labelX02.BorderStyle = BorderStyle.Fixed3D;


			//this.label7.BorderStyle = BorderStyle.Fixed3D;
			//this.label8.BorderStyle = BorderStyle.Fixed3D;
			//this.label9.BorderStyle = BorderStyle.Fixed3D;

			//this.label4.BorderStyle = BorderStyle.Fixed3D;
			//this.label5.BorderStyle = BorderStyle.Fixed3D;
			//this.label6.BorderStyle = BorderStyle.Fixed3D;

			//this.label1.BorderStyle = BorderStyle.Fixed3D;
			//this.label2.BorderStyle = BorderStyle.Fixed3D;
			//this.label3.BorderStyle = BorderStyle.Fixed3D;

			//this.label0.BorderStyle = BorderStyle.Fixed3D;
			//this.labelX.BorderStyle = BorderStyle.Fixed3D;


			// 
			// panelTableLayoutPanelView2Right
			// 
			if (buttonType == 2 
				//|| buttonType == 3
				)
			{
				//this.labelPadTotal.Location = new System.Drawing.Point(16, 3);
				//this.labelPadTotal.Size = new System.Drawing.Size(220, 60);

				//this.labelPad.Location = new System.Drawing.Point(16, 3);
				//this.labelPad.Size = new System.Drawing.Size(220, 60);

				this.labelClear.Location = new System.Drawing.Point(250, 4);
				this.labelClear.Size = new System.Drawing.Size(102, 64);

				this.labelX01.Location = new System.Drawing.Point(10, 81);
				this.labelX01.Size = new System.Drawing.Size(102, 64);

				this.labelX02.Location = new System.Drawing.Point(129, 81);
				this.labelX02.Size = new System.Drawing.Size(102, 64);

				this.labeBackSpace.Location = new System.Drawing.Point(250, 81);
				this.labeBackSpace.Size = new System.Drawing.Size(102, 64);

				this.label7.Location = new System.Drawing.Point(10, 165);   //15, 158
				this.label7.Size = new System.Drawing.Size(102, 67);         //98, 57

				this.label8.Location = new System.Drawing.Point(129, 165);  //134, 157
				this.label8.Size = new System.Drawing.Size(102, 67);    //98,57

				this.label9.Location = new System.Drawing.Point(250, 165);
				this.label9.Size = new System.Drawing.Size(102, 67);

				this.label4.Location = new System.Drawing.Point(10, 252);
				this.label4.Size = new System.Drawing.Size(102, 67);

				this.label5.Location = new System.Drawing.Point(129, 252);
				this.label5.Size = new System.Drawing.Size(102, 67);

				this.label6.Location = new System.Drawing.Point(250, 252);
				this.label6.Size = new System.Drawing.Size(102, 67);

				this.label1.Location = new System.Drawing.Point(10, 336);
				this.label1.Size = new System.Drawing.Size(102, 67);

				this.label2.Location = new System.Drawing.Point(129, 336);
				this.label2.Size = new System.Drawing.Size(102, 67);

				this.label3.Location = new System.Drawing.Point(250, 336);
				this.label3.Size = new System.Drawing.Size(102, 67);

				this.label0.Location = new System.Drawing.Point(10, 422);
				this.label0.Size = new System.Drawing.Size(220, 70);

				this.labelX.Location = new System.Drawing.Point(250, 424);
				this.labelX.Size = new System.Drawing.Size(102, 67);

				this.panelTableLayoutPanelView2_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
			}
			else
			{
				buttonWidthOffset = 18;
				buttonHeightOffset = 10;

				buttonXOffset = 9;
				buttonYOffset = 12;

				this.labelClear.Location = new System.Drawing.Point(250 + buttonWidthOffset + buttonXOffset, 4);
				this.labelClear.Size = new System.Drawing.Size(102 + buttonWidthOffset, 64 + buttonHeightOffset);

				this.labelX01.Location = new System.Drawing.Point(10, 81 + buttonHeightOffset);
				this.labelX01.Size = new System.Drawing.Size(102 + buttonWidthOffset, 64 + buttonHeightOffset);

				this.labelX02.Location = new System.Drawing.Point(129 + buttonWidthOffset, 81 + buttonHeightOffset);
				this.labelX02.Size = new System.Drawing.Size(102 + buttonWidthOffset, 64 + buttonHeightOffset);

				this.labeBackSpace.Location = new System.Drawing.Point(250 + buttonWidthOffset + buttonXOffset, 81 + buttonHeightOffset);
				this.labeBackSpace.Size = new System.Drawing.Size(102 + buttonWidthOffset, 64 + buttonHeightOffset);

				this.label7.Location = new System.Drawing.Point(10, 165 + buttonHeightOffset + buttonYOffset);   //15, 158
				this.label7.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);         //98, 57

				this.label8.Location = new System.Drawing.Point(129 + buttonWidthOffset, 165 + buttonHeightOffset + buttonYOffset);  //134, 157
				this.label8.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);    //98,57

				this.label9.Location = new System.Drawing.Point(250 + buttonWidthOffset + buttonYOffset, 165 + buttonHeightOffset + buttonYOffset);
				this.label9.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.label4.Location = new System.Drawing.Point(10, 252 + buttonHeightOffset + ( buttonYOffset * 2));
				this.label4.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.label5.Location = new System.Drawing.Point(129 + buttonWidthOffset, 252 + buttonHeightOffset + (buttonYOffset * 2));
				this.label5.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.label6.Location = new System.Drawing.Point(250 + buttonWidthOffset + buttonYOffset, 252 + buttonHeightOffset + (buttonYOffset * 2));
				this.label6.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.label1.Location = new System.Drawing.Point(10, 336 + buttonHeightOffset + (buttonYOffset * 3));
				this.label1.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.label2.Location = new System.Drawing.Point(129 + buttonWidthOffset, 336 + buttonHeightOffset + (buttonYOffset * 3));
				this.label2.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.label3.Location = new System.Drawing.Point(250 + buttonWidthOffset + buttonYOffset, 336 + buttonHeightOffset + (buttonYOffset * 3));
				this.label3.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.label0.Location = new System.Drawing.Point(10, 422 + buttonHeightOffset + (buttonYOffset * 4));
				this.label0.Size = new System.Drawing.Size(220 + buttonWidthOffset + 10, 70 + buttonHeightOffset);

				this.labelX.Location = new System.Drawing.Point(250 + buttonWidthOffset + buttonYOffset, 424 + buttonHeightOffset + (buttonYOffset * 4));
				this.labelX.Size = new System.Drawing.Size(102 + buttonWidthOffset, 67 + buttonHeightOffset);

				this.panelTableLayoutPanelView2_Buttons.Location = new System.Drawing.Point(1, 1); //370, 3 

				this.panelTableLayoutPanelView2_Buttons.Size = new System.Drawing.Size(             //239, 476);
					CategoryButtons.buttonContainerWidth
					, CategoryButtons.buttonContainerHeight);


			}

			this.panelTableLayoutPanelView2_Buttons.Name = "panelTableLayoutPanelView2Right";

			//this.panelTableLayoutPanelView2_Buttons.Size = new System.Drawing.Size(CategoryButtons.buttonContainerWidth, CategoryButtons.buttonContainerHeight);


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


			if (buttonType == 2)
			{
				this.tableLayoutPanelView2.Dock = System.Windows.Forms.DockStyle.Fill;

			}
			else
			{
				this.tableLayoutPanelView2.Location = new System.Drawing.Point(1, 1);   //199, 173
																						// w    h
				this.tableLayoutPanelView2.Size = new System.Drawing.Size(              //612, 482);
					CategoryButtons.buttonContainerWidth + this.panelTableLayoutPanelView2_KeyPad.Width
					, CategoryButtons.buttonContainerHeight 
					);

				this.panelView.Dock = DockStyle.Fill;
			}



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
					labelText = labelText.Replace("x", "");
					break;
			}

			if (multiplyBy > 0)
			{
				string multiplier = string.Empty;
				if (!string.IsNullOrEmpty(labelPad.Text))
					multiplier = labelPad.Text + labelText;
				else
					multiplier = labelText;

				int valorInt = 0;
				int.TryParse(multiplier, out valorInt);

				if (valorInt > 0)
				{
					string subTotal = string.Format("{1} * {0} = {2}", valorInt, multiplyBy, valorInt * multiplyBy);
					DisplayPadTotal(subTotal);
				}
			}

			DisplayPad(labelText);

		}

		private void labelX_Click(object sender, EventArgs e)
		{
			//simulate click
			//EventArgs e1 = new EventArgs();
			//labelClear_Click(this.labelClear, e1);

			//Label label = (Label)sender;
			//string labelText = label.Name.Replace("labelX", "");
			//DisplayPad(labelText);


			Label label = (Label)sender;
			int Quantity = 0;
			label.Name = label.Name.Replace("labelX", "");
			Int32.TryParse(label.Name, out Quantity);

			if (String.IsNullOrEmpty(labelPad.Text))
			{
				//labelPad.Text = "1";
				label0_Click(label, new EventArgs());
				labelXMultiply_Click(labelX, new EventArgs());
			}
			else
			{
				Int32.TryParse(labelPad.Text, out resultNumber);
				resultNumber *= Quantity;
				labelPad.Text = resultNumber.ToString();
				flagReiniciar = true;

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
			if (toolStripButtonResetCounter.Text != "Adjust count")
			{
				toolStripTextBoxCount.Text = text;
			}

		}


		private string readBinCount(int index)
		{
			int iCount = 0;
			string sCount = String.Empty;
			int dCount = 0;

			if ((sol_CategoryButtonList[index]).SubContainerMaxCount < 1)
				return sCount;


			sol_BinCount = sol_BinCount_Sp.Select(Main.myHostName, (sol_CategoryButtonList[index]).CategoryButtonID);
			if (sol_BinCount == null)
			{
				if ((sol_CategoryButtonList[index]).SubContainerCountDown)
					iCount = 0;//(sol_CategoryButtonList[index]).SubContainerMaxCount;
			}
			else
				iCount = sol_BinCount.CurrentCount;


			if ((sol_CategoryButtonList[index]).SubContainerCountDown)
			{
				dCount = (sol_CategoryButtonList[index]).SubContainerMaxCount - iCount;
				if (dCount == 0)
					dCount = (sol_CategoryButtonList[index]).SubContainerMaxCount;
			}
			else
				dCount = iCount;

			if (dCount != 0)
				sCount = dCount.ToString();

			return sCount;
		}

		private void getPadNumber()
		{
			resultNumber = 0;

			if (!String.IsNullOrEmpty(labelPadTotal.Text))
			{
				string[] total = labelPadTotal.Text.Split('=');
				if (total.Count() == 1)
				{
					total = labelPadTotal.Text.Split('*');
					multiplyBy = 0;
					labelPadTotal.Text = string.Empty;

					if (total.Count() > 0)
						labelPad.Text = total[0];
					else
						labelPad.Text = "1";

				}
				else if (total.Count() > 1)
				{
					multiplyBy = 0;
					labelPadTotal.Text = string.Empty;
					labelPad.Text = total[1];

				}
			}


			if (!String.IsNullOrEmpty(labelPad.Text))
				if (!Int32.TryParse(labelPad.Text, out resultNumber))
				{
					MessageBox.Show("Error parsing quantity, default to 1 item!");
					resultNumber = 1;
				}

			//return resultNumber;
		}


		#endregion

		#region PanelTableLayoutPanelView3 Routines   //17" screen setup

		//private void CreatePanelTableLayoutPanelView3Vertical()
		//{
		//    panelTableLayoutPanelView3Vertical_Buttons = new MyPanel();
		//    panelTableLayoutPanelView3Vertical_Buttons.scroolFlag = false;

		//    panelTableLayoutPanelView3Vertical_Buttons.SuspendLayout();
		//    this.SuspendLayout();
		//    // 
		//    // panelTableLayoutPanelView3Vertical
		//    // 
		//    panelTableLayoutPanelView3Vertical_Buttons.BackColor = Properties.Settings.Default.SettingsAd17ScreenBackground;
		//    panelTableLayoutPanelView3Vertical_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
		//    panelTableLayoutPanelView3Vertical_Buttons.Location = new System.Drawing.Point(3, 3);
		//    panelTableLayoutPanelView3Vertical_Buttons.Name = "panelTableLayoutPanelView3Vertical";
		//    //this.panelTableLayoutPanelView2.Size = new System.Drawing.Size(245, 482);
		//    panelTableLayoutPanelView3Vertical_Buttons.TabIndex = 0;
		//    panelTableLayoutPanelView3Vertical_Buttons.AutoScroll = false;
		//    //panelTableLayoutPanelView3Vertical_Buttons.
		//    //panelTableLayoutPanelView3Vertical_Buttons.AllowDrop = false;
		//    //panelTableLayoutPanelView3Vertical_Buttons.Click += new System.EventHandler(panelTableLayoutPanelView3_Buttons_Click);

		//    this.panelView.Controls.Add(panelTableLayoutPanelView3Vertical_Buttons);
		//    this.panelView.Size = new System.Drawing.Size(CategoryButtons.buttonContainerWidth, CategoryButtons.buttonContainerHeight);  //245, 482);

		//    panelTableLayoutPanelView3Vertical_Buttons.ResumeLayout(false);

		//    this.ResumeLayout(false);

		//}

		private void CreatePanelTableLayoutPanelView3Horizontal()
		{
			int height = CategoryButtons.buttonContainerHeight;

			//buttonFirstPage = new Button();
			//// 
			//// buttonFirstPage
			////                                                   x    y
			int width = 1;
			//buttonFirstPage.Location = new System.Drawing.Point(width, 551);
			//buttonFirstPage.Name = "buttonFirstPage";
			//buttonFirstPage.Size = new System.Drawing.Size(32, CategoryButtons.buttonH*2);
			//buttonFirstPage.TabIndex = 9;
			//buttonFirstPage.Text = "<<";
			//buttonFirstPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			//buttonFirstPage.UseVisualStyleBackColor = true;
			//buttonFirstPage.Click += new System.EventHandler(ButtonFirstPage_Click);


			buttonPreviousPage = new Button();
			// 
			// buttonPreviousPage
			//                                                      x    y
			//width += buttonFirstPage.Size.Width;
			buttonPreviousPage.Location = new System.Drawing.Point(width, height);
			buttonPreviousPage.Name = "buttonPreviousPage";
			buttonPreviousPage.Size = new System.Drawing.Size(40, (CategoryButtons.buttonH * 2)+2);
			buttonPreviousPage.TabIndex = 9;
			buttonPreviousPage.Text = "<";
			buttonPreviousPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			buttonPreviousPage.UseVisualStyleBackColor = true;
			buttonPreviousPage.Click += new System.EventHandler(ButtonPreviousPage_Click);


			panelTableLayoutPanelView3Horizontal_Buttons = new Panel();
			//panelTableLayoutPanelView3Horizontal_Buttons.scroolFlag = false;

			panelTableLayoutPanelView3Horizontal_Buttons.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTableLayoutPanelView3Vertical
			// 
			panelTableLayoutPanelView3Horizontal_Buttons.BackColor = Properties.Settings.Default.SettingsAd17ScreenBackground;
			//panelTableLayoutPanelView3Horizontal_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;

			width += buttonPreviousPage.Size.Width;
			panelTableLayoutPanelView3Horizontal_Buttons.Location = new System.Drawing.Point(width, height);
			panelTableLayoutPanelView3Horizontal_Buttons.Name = "panelTableLayoutPanelView3Horizontal";

			panelTableLayoutPanelView3Horizontal_Buttons.Size =
				new System.Drawing.Size(
					 CategoryButtons.view3HorizontalCells * CategoryButtons.buttonW         //buttonContainerWidth
					, CategoryButtons.view3HorizontalRows * CategoryButtons.buttonH        //buttonContainerHeight
					);

			panelTableLayoutPanelView3Horizontal_Buttons.TabIndex = 0;
			panelTableLayoutPanelView3Horizontal_Buttons.AutoScroll = false;
			//panelTableLayoutPanelView3Vertical_Buttons.
			//panelTableLayoutPanelView3Vertical_Buttons.AllowDrop = false;
			//panelTableLayoutPanelView3Vertical_Buttons.Click += new System.EventHandler(panelTableLayoutPanelView3_Buttons_Click);

			//this.groupBoxCategoryButtonsDef.Controls.Add(panelTableLayoutPanelView3Horizontal_Buttons);
			//this.groupBoxCategoryButtonsDef.Size = new System.Drawing.Size(buttonContainerWidth, buttonContainerHeight);  //245, 482);


			buttonNextPage = new Button();
			// 
			// buttonNextPage
			//                                                 
			width += panelTableLayoutPanelView3Horizontal_Buttons.Size.Width;
			buttonNextPage.Location = new System.Drawing.Point(width, height);
			buttonNextPage.Name = "buttonNextPage";
			buttonNextPage.Size = new System.Drawing.Size(40, (CategoryButtons.buttonH * 2) + 2);
			buttonNextPage.TabIndex = 9;
			buttonNextPage.Text = ">";
			buttonNextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			buttonNextPage.UseVisualStyleBackColor = true;
			buttonNextPage.Click += new System.EventHandler(ButtonNextPage_Click);


			//buttonLastPage = new Button();
			 
			// buttonLastPage
															 
			//width += buttonNextPage.Size.Width;
			//buttonLastPage.Location = new System.Drawing.Point(width, height);
			//buttonLastPage.Name = "buttonLastPage";
			//buttonLastPage.Size = new System.Drawing.Size(32, CategoryButtons.buttonH*2);
			//buttonLastPage.TabIndex = 9;
			//buttonLastPage.Text = ">>";
			//buttonLastPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			//buttonLastPage.UseVisualStyleBackColor = true;
			//buttonLastPage.Click += new System.EventHandler(ButtonLastPage_Click);

			//this.panelView.Controls.Add(this.buttonFirstPage);
			this.panelView.Controls.Add(this.buttonPreviousPage);
			this.panelView.Controls.Add(panelTableLayoutPanelView3Horizontal_Buttons);
			this.panelView.Controls.Add(this.buttonNextPage);
			//this.panelView.Controls.Add(this.buttonLastPage);


			panelTableLayoutPanelView3Horizontal_Buttons.ResumeLayout(false);

			//this.tableLayoutPanel1.Controls.Add(this.panelView, 1, 0);

			this.ResumeLayout(false);

		}

		private void ReadButtons2()
		{
			if (buttonType == 2)
			{
				panelTableLayoutPanelView2_Buttons.Controls.Clear();
			}
			else if (buttonType == 3)
			{
				panelTableLayoutPanelView3Vertical_Buttons.Controls.Clear();
				panelTableLayoutPanelView3Horizontal_Buttons.Controls.Clear();
			}


			//sol_CategoryButtonList = new List<Sol_CategoryButton>();
			//Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();
			//sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);
			sol_CategoryButtonList = sol_CategoryButton_Sp._SelectAllByButtonType(/*Main.Sol_ControlInfo.WorkStationID,*/ buttonType);


			this.arrayListItems = new ArrayList();

			ImageList buttonsImageList = Main.bImageList1;

			int categoryButtonWidth = 0;
			int categoryButtonHeight = 0;

			int nr = 0;
			int paddingX = 4;
			int paddingY = 0;
			int formerLocationY = 0;

			int i = 0;
			foreach (Sol_CategoryButton cb in sol_CategoryButtonList)
			{
				switch (cb.ImageSize)
				{
					case 0: //-- 0 = Normal Size
						buttonsImageList = Main.bImageList1;
						categoryButtonWidth = CategoryButtons.buttonW;
						categoryButtonHeight = CategoryButtons.buttonH;
						break;
					case 1: //-- 1 = Double Width
						buttonsImageList = Main.bImageList2;
						categoryButtonWidth = (CategoryButtons.buttonW * 2);
						categoryButtonHeight = CategoryButtons.buttonH;
						break;
					case 2: //-- 2 = Double Height
						buttonsImageList = Main.bImageList3;
						categoryButtonWidth = CategoryButtons.buttonW;
						categoryButtonHeight = CategoryButtons.buttonH * 2;
						break;
					case 3: //-- 3 = Double Size
						buttonsImageList = Main.bImageList4;
						categoryButtonWidth = (CategoryButtons.buttonW * 2);
						categoryButtonHeight = CategoryButtons.buttonH * 2;
						break;
					default:
						buttonsImageList = Main.bImageList1;
						categoryButtonWidth = CategoryButtons.buttonW;
						categoryButtonHeight = CategoryButtons.buttonH;
						break;
				}

				cb.Width = categoryButtonWidth;
				cb.Height = categoryButtonHeight;

				Color foreColor = Color.FromArgb(cb.ForeColorArgb); //ColorTryParse(cb.ForeColorArgb, cb.ForeColor);
				Color backColor = Color.FromArgb(cb.BackColorArgb); //ColorTryParse(cb.BackColorArgb, cb.BackColor);


				this.arrayListItems.Add(new System.Windows.Forms.Button());


				if (buttonType == 3)
				{
					((System.Windows.Forms.Button)this.arrayListItems[i]).Location = CategoryButtons.CalculatePointOfButton(buttonType, i);
					//new System.Drawing.Point(
					//cb.LocationX,
					//cb.LocationY 
					//);
				}
				else
				{
					//((System.Windows.Forms.Button)this.arrayListItems[i]).Location = new System.Drawing.Point(
					//cb.LocationX,
					//cb.LocationY
					//);
					if (cb.LocationX > 0)
						paddingX = 2;
					else
						paddingX = 0;
					if (formerLocationY != cb.LocationY)
					{
						formerLocationY = cb.LocationY;
						nr++;
						paddingY = nr * 2;
						//MessageBox.Show("cambio de renglon");
					}

					((System.Windows.Forms.Button)this.arrayListItems[i]).Location = new System.Drawing.Point(
						cb.LocationX + 10 + paddingX,
						cb.LocationY + paddingY
						);
				}

				((System.Windows.Forms.Button)this.arrayListItems[i]).Name = "Button_" + Convert.ToString(i);
				((System.Windows.Forms.Button)this.arrayListItems[i]).Size = new System.Drawing.Size(categoryButtonWidth, categoryButtonHeight);

				//((System.Windows.Forms.Button)this.arrayListItems[i]).Width = categoryButtonWidth;
				//((System.Windows.Forms.Button)this.arrayListItems[i]).Height = categoryButtonHeight;

				((System.Windows.Forms.Button)this.arrayListItems[i]).TabIndex = i + 2;
				((System.Windows.Forms.Button)this.arrayListItems[i]).Text = cb.Description.Trim();

				((System.Windows.Forms.Button)this.arrayListItems[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);

				((System.Windows.Forms.Button)this.arrayListItems[i]).ForeColor = foreColor;
				((System.Windows.Forms.Button)this.arrayListItems[i]).BackColor = backColor;

				((System.Windows.Forms.Button)this.arrayListItems[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
				((System.Windows.Forms.Button)this.arrayListItems[i]).Cursor = System.Windows.Forms.Cursors.Hand;

				((System.Windows.Forms.Button)this.arrayListItems[i]).FlatAppearance.BorderSize = 1;
				//((System.Windows.Forms.Button)this.arrayListItems[i]).FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
				//((System.Windows.Forms.Button)this.arrayListItems[i]).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

				((System.Windows.Forms.Button)this.arrayListItems[i]).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				((System.Windows.Forms.Button)this.arrayListItems[i]).UseVisualStyleBackColor = false;

				//Image img = Main2.buttonsImageList.Images[cb.ImageIndex];
				//((System.Windows.Forms.Button)this.arrayListItems[i]).Image = img;

				if (buttonType == 2)
				{
					((System.Windows.Forms.Button)this.arrayListItems[i]).ImageIndex = cb.ImageIndex;
					//if (cb.ImageIndex < 4 && !String.IsNullOrEmpty(cb.ImagePath))
					if (!String.IsNullOrEmpty(cb.ImagePath))
					{
						((System.Windows.Forms.Button)this.arrayListItems[i]).ImageList = null;
						try
						{
							Image fastImage = ImageFast.FromFile(cb.ImagePath);
							((System.Windows.Forms.Button)this.arrayListItems[i]).BackgroundImage = fastImage;
							((System.Windows.Forms.Button)this.arrayListItems[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
						}
						catch
						{
							((System.Windows.Forms.Button)this.arrayListItems[i]).ImageList = buttonsImageList;
						}

					}
					else
						((System.Windows.Forms.Button)this.arrayListItems[i]).ImageList = buttonsImageList;
				}

				//memory leak
				((System.Windows.Forms.Button)this.arrayListItems[i]).Click += new System.EventHandler(this.button_Click);

				if (buttonType == 2)
				{
					//add counter label
					Label label = new System.Windows.Forms.Label();
					//this.SuspendLayout();
					// 
					// label
					// 
					label.AutoSize = true;
					label.BackColor = System.Drawing.Color.Transparent;
					label.Location = new System.Drawing.Point(3, 3);    //59, 80);
					label.Name = "Label_" + Convert.ToString(i);
					label.Size = new System.Drawing.Size(0, 17);
					label.TabIndex = 5;
					label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
					//this.Controls.Add(this.label_3);
					((System.Windows.Forms.Button)this.arrayListItems[i]).Controls.Add(label);

					label.Text = readBinCount(i);

					panelTableLayoutPanelView2_Buttons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i]));
				}
				else if (buttonType == 3)
				{
					panelTableLayoutPanelView3Vertical_Buttons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i]));
				}
				i++;

				//break;

			}
			if (buttonType == 3)
			{
				pageNumber = 1;
				ReadButtons4();
			}

		}

		private void ReadButtons4()  //horizontal panel of buttonType 3
		{
			indice = -1;
			buttonClicked = null;
			//buttonClickedPrevious = null;
			buttonSender = null;

			//textBoxDescription.Text = "";
			//textBoxDefaultQuantity.Text = "1";
			//textBoxSubContainerCount.Text = "0";
			//checkBoxCountDown.Checked = false;
			//comboBoxCategory.SelectedValue = 0;
			//comboBoxButtonSize.SelectedIndex = 0;

			panelTableLayoutPanelView3Horizontal_Buttons.Controls.Clear();

			sol_CategoryButtonList4 = sol_CategoryButton_Sp._SelectAllByPaging(/*Main.Sol_ControlInfo.WorkStationID, buttonType, */pageNumber, CategoryButtons.pageSize, ref lastPage);

			this.arrayListItems4 = new ArrayList();

			ImageList buttonsImageList = Main.bImageList1;

			int i = 0;
			foreach (Sol_CategoryButton cb in sol_CategoryButtonList4)
			{
				switch (cb.ImageSize)
				{
					case 0: //-- 0 = Normal Size
						buttonsImageList = Main.bImageList1;
						CategoryButtons.categoryButtonWidth = CategoryButtons.buttonW;
						CategoryButtons.categoryButtonHeight = CategoryButtons.buttonH;
						break;
					case 1: //-- 1 = Double Width
						buttonsImageList = Main.bImageList2;
						CategoryButtons.categoryButtonWidth = (CategoryButtons.buttonW * 2);
						CategoryButtons.categoryButtonHeight = CategoryButtons.buttonH;
						break;
					case 2: //-- 2 = Double Height
						buttonsImageList = Main.bImageList3;
						CategoryButtons.categoryButtonWidth = CategoryButtons.buttonW;
						CategoryButtons.categoryButtonHeight = CategoryButtons.buttonH * 2;
						break;
					case 3: //-- 3 = Double Size
						buttonsImageList = Main.bImageList4;
						CategoryButtons.categoryButtonWidth = (CategoryButtons.buttonW * 2);
						CategoryButtons.categoryButtonHeight = CategoryButtons.buttonH * 2;
						break;
					default:
						buttonsImageList = Main.bImageList1;
						CategoryButtons.categoryButtonWidth = CategoryButtons.buttonW;
						CategoryButtons.categoryButtonHeight = CategoryButtons.buttonH;
						break;
				}

				cb.Width = CategoryButtons.categoryButtonWidth;
				cb.Height = CategoryButtons.categoryButtonHeight;

				Color foreColor = Color.FromArgb(cb.ForeColorArgb); //ColorTryParse(cb.ForeColorArgb, cb.ForeColor);
				Color backColor = Color.FromArgb(cb.BackColorArgb); //ColorTryParse(cb.BackColorArgb, cb.BackColor);

				this.arrayListItems4.Add(new System.Windows.Forms.Button());

				((System.Windows.Forms.Button)this.arrayListItems4[i]).Location = CategoryButtons.CalculatePointOfButton(4, i);
				//new System.Drawing.Point(
				//cb.LocationX,
				//cb.LocationY
				//);
				((System.Windows.Forms.Button)this.arrayListItems4[i]).Name = "Button_" + Convert.ToString(i);
				((System.Windows.Forms.Button)this.arrayListItems4[i]).Size = new System.Drawing.Size(CategoryButtons.categoryButtonWidth, CategoryButtons.categoryButtonHeight);

				((System.Windows.Forms.Button)this.arrayListItems4[i]).TabIndex = i + 2;
				((System.Windows.Forms.Button)this.arrayListItems4[i]).Text = cb.Description.Trim();

				((System.Windows.Forms.Button)this.arrayListItems4[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);

				((System.Windows.Forms.Button)this.arrayListItems4[i]).ForeColor = foreColor;
				((System.Windows.Forms.Button)this.arrayListItems4[i]).BackColor = backColor;

				((System.Windows.Forms.Button)this.arrayListItems4[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
				((System.Windows.Forms.Button)this.arrayListItems4[i]).Cursor = System.Windows.Forms.Cursors.Hand;

				((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatAppearance.BorderSize = 1;
				//((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
				//((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

				((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				((System.Windows.Forms.Button)this.arrayListItems4[i]).UseVisualStyleBackColor = false;

				//Image img = Main.buttonsImageList.Images[cb.ImageIndex];
				//((System.Windows.Forms.Button)this.arrayListItems4[i]).Image = img;

				//only for buttons type 2
				//if (cb.ControlType == 2)
				//if (buttonType == 2)
				//{
				//    ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageIndex = cb.ImageIndex;
				//    //if (cb.ImageIndex < 4 && !String.IsNullOrEmpty(cb.ImagePath))
				//    if (!String.IsNullOrEmpty(cb.ImagePath))
				//    {
				//        ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageList = null;

				//        try
				//        {
				//            Image fastImage = ImageFast.FromFile(cb.ImagePath);
				//            ((System.Windows.Forms.Button)this.arrayListItems4[i]).BackgroundImage = fastImage;
				//            ((System.Windows.Forms.Button)this.arrayListItems4[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
				//        }
				//        catch
				//        {
				//            ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageList = buttonsImageList;
				//        }

				//    }
				//    else
				//        ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageList = buttonsImageList;
				//}

				((System.Windows.Forms.Button)this.arrayListItems4[i]).Click += new System.EventHandler(this.button_Click);


				panelTableLayoutPanelView3Horizontal_Buttons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems4[i]));

				i++;

				//break;

			}

		}

		private void ButtonFirstPage_Click(object sender, EventArgs e)
		{
			pageNumber = 1;
			ReadButtons4();

		}
		private void ButtonPreviousPage_Click(object sender, EventArgs e)
		{
			if (pageNumber < 2)
				return;

			pageNumber--;
			ReadButtons4();

		}

		private void ButtonNextPage_Click(object sender, EventArgs e)
		{
			if (arrayListItems4.Count < CategoryButtons.pageSize)
				return;

			pageNumber++;
			ReadButtons4();

		}

		private void ButtonLastPage_Click(object sender, EventArgs e)
		{
			pageNumber = lastPage;
			ReadButtons4();
		}


		#endregion

		#region Instant Staging

		void FillDataBagPosition()
		{
			arrayListBagPositionButtons = new ArrayList();
			arrayListBagPositionButtons.Add(buttonBagPosition_01);
			arrayListBagPositionButtons.Add(buttonBagPosition_02);
			arrayListBagPositionButtons.Add(buttonBagPosition_03);
			arrayListBagPositionButtons.Add(buttonBagPosition_04);
			arrayListBagPositionButtons.Add(buttonBagPosition_05);
			arrayListBagPositionButtons.Add(buttonBagPosition_06);
			arrayListBagPositionButtons.Add(buttonBagPosition_07);
			arrayListBagPositionButtons.Add(buttonBagPosition_08);

			arrayListBagPositionObjects = new ArrayList();
			arrayListBagPositionTagNumbers = new ArrayList();

			foreach (Button b in arrayListBagPositionButtons)
			{
				arrayListBagPositionTagNumbers.Add(string.Empty);
				b.Text = string.Empty;
			}

			if (vir_BagPosition_Sp == null)
				vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);

			List<Vir_BagPosition> bpList = vir_BagPosition_Sp.SelectAll();
			if (bpList.Count < 0)
			{
				MessageBox.Show("There is no Bag Position available, can not continue.");
				this.Close();
				return;
			}

			int index = 0;
			foreach (Vir_BagPosition bp in bpList)
			{
				arrayListBagPositionObjects.Add(bp);

				tagNumber = string.Empty;
				if (bp.CurrentStageID > 1)
				{
					//open
					if (sol_Stage_Sp == null)
						sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);
					sol_Stage = sol_Stage_Sp.Select(bp.CurrentStageID);
					if (sol_Stage == null)
					{
						bp.CurrentStageID = 0;
						bp.CurrentQuantity = 0;
						((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity = 0;
						((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID = 0;
						vir_BagPosition_Sp.Update((Vir_BagPosition)arrayListBagPositionObjects[index]);
						//sol_Stage.TagNumber = string.Empty;
						//sol_Stage_Sp.Update(sol_Stage);
					}
					else
					{
						tagNumber = sol_Stage.TagNumber;
						arrayListBagPositionTagNumbers[index] = tagNumber;
						((Button)arrayListBagPositionButtons[index]).BackColor = ColorTranslator.FromHtml("#01b866");  //green
					}
				}

				if (bp.ProductID < 1)
					((Button)arrayListBagPositionButtons[index]).Text = bp.BagPositionName;
				else
					FormatBagPositionText((Button)arrayListBagPositionButtons[index], bp, tagNumber);

				index++;
			}


		}

		void FormatBagPositionText(Button button, Vir_BagPosition bp, string tagNumber)
		{
			int l = 23;
			if (l > bp.BagPositionName.Length) l = bp.BagPositionName.Length;

			button.Text = string.Format(
				"{0}\r" +
				"{1:#,0}\r" +
				"Target: {2:#,0}\r" +
				"TAG {3}\r"
				, bp.BagPositionName.Substring(0, l)
				, bp.CurrentQuantity
				, bp.TargetQuantity
				, tagNumber
				);
		}

		private void buttonBagPosition_02_Click(object sender, EventArgs e)
		{
			buttonBagPositionClicked = (Button)sender;

			if (buttonBagPositionClicked.BackColor == ColorTranslator.FromHtml("#01b866"))  //green
			{
				//
				toolStripMenuItemOpen.Visible = false;
				toolStripMenuItemClose.Visible = true;
			}
			else
			{
				//
				//toolStripMenuItemOpen.Visible = true;
				//toolStripMenuItemClose.Visible = false;
				OpenCloseBagPosition();
				return;
			}


			//contextMenuStrip1.Show(button, new Point(0, button.Height));
			Point screenPoint = buttonBagPositionClicked.PointToScreen(new Point(buttonBagPositionClicked.Left, buttonBagPositionClicked.Bottom));
			if (screenPoint.Y + contextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
			{
				contextMenuStrip1.Show(buttonBagPositionClicked, new Point(0, -contextMenuStrip1.Size.Height));
			}
			else
			{
				contextMenuStrip1.Show(buttonBagPositionClicked, new Point(0, buttonBagPositionClicked.Height));
			}
		}

		private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
		{
			OpenCloseBagPosition();
		}

		private void toolStripMenuItemClose_Click(object sender, EventArgs e)
		{
			OpenCloseBagPosition();
		}

		private void toolStripMenuItemModify_Click(object sender, EventArgs e)
		{
			//this.timer1.Stop();

			ShippingMultiProductStagedContainersModify f1 = new ShippingMultiProductStagedContainersModify();
			f1.buttonText = buttonBagPositionClicked.Text;
			f1.buttonBackColor = buttonBagPositionClicked.BackColor;

			//arrayListBagPositionObjects

			int index = 0;
			int.TryParse(buttonBagPositionClicked.Name.Right(2), out index);
			index--;


			Vir_BagPosition bp = (Vir_BagPosition)arrayListBagPositionObjects[index];
			if (bp == null)
			{
				MessageBox.Show("Bag position does not exists. Please review configuration.");
				//timer1_Tick(timer1, new EventArgs());
				return;
			}

			f1.vir_BagPosition = bp;

			f1.tagNumber = (string)arrayListBagPositionTagNumbers[index];

			f1.ShowDialog();
			buttonBagPositionClicked.Text = f1.buttonText;

			f1.Dispose();
			f1 = null;

			//timer1_Tick(timer1, new EventArgs());

		}

		private bool OpenCloseBagPosition()
		{

			if (buttonBagPositionClicked == null)
				return false;


			int index = 0;
			int.TryParse(buttonBagPositionClicked.Name.Right(2), out index);
			index--;


			if (arrayListBagPositionObjects.Count < 1
				|| index >= arrayListBagPositionObjects.Count
				)
			{
				MessageBox.Show("There is no Bag Position available to open.");
				//this.Close();
				return false;
			}

			Vir_BagPosition bp = (Vir_BagPosition)arrayListBagPositionObjects[index];
			if (bp == null)
				return false;

			//this.timer1.Stop();

			if (vir_BagPosition_Sp == null)
				vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);

			int stageId = ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID;

			if (bp.CurrentQuantity < 1 && bp.CurrentStageID < 1)
			{
				//is closed
				int containerID = 0;
				int dozen = 0;
				decimal price = 0;
				int agencyID = 0;
				bool autoGenerateTagNumber = false;
				if (!ReadProductAgency(bp.ProductID, ref containerID, ref dozen, ref price, ref agencyID, ref autoGenerateTagNumber))
				{
					MessageBox.Show("Product linked to this bag position does not exists, please review!");
					//timer1_Tick(timer1, new EventArgs());
					return false;
				}

				if (!AddStagedRow(bp.ProductID, containerID, dozen, price, agencyID, autoGenerateTagNumber))
				{
					//timer1_Tick(timer1, new EventArgs());
					return false;
				}

				((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity = 0;
				((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID = sol_Stage.StageID;
				arrayListBagPositionTagNumbers[index] = tagNumber;

				vir_BagPosition_Sp.Update((Vir_BagPosition)arrayListBagPositionObjects[index]);
				FormatBagPositionText(buttonBagPositionClicked, (Vir_BagPosition)arrayListBagPositionObjects[index], tagNumber);
				buttonBagPositionClicked.BackColor = ColorTranslator.FromHtml("#01b866");  //green

				//update bag DateClosed
				SolFunctions.SetDateClosedInStage(stageId, "1753-01-01 12:00:00.000");
			}
			else
			{
				//is open
				if (bp.CurrentQuantity < bp.TargetQuantity)
				{
					if (MessageBox.Show("Current Quantity is below Target Quantity.  Are you sure you want to close this bag?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
					{
						//
						//timer1_Tick(timer1, new EventArgs());
						return false;
					}
				}


				//set final quantity in stage
				SolFunctions.SetFinalQuantityInStage(bp.CurrentStageID, bp.CurrentQuantity);

				int quantity = ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity;
				//int stageId = ((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID;

				//print label
				//I removed this: A300,110,1,4,2,1,N,"Doz:  {dozen}"
				bool printLabel = true;

				do
				{
					if (sol_Agency_Sp == null)
						sol_Agency_Sp = new Sol_Agencie_Sp(Properties.Settings.Default.WsirDbConnectionString);

					if (sol_Product_Sp == null)
						sol_Product_Sp = new Sol_Product_Sp(Properties.Settings.Default.WsirDbConnectionString);

					if (sol_Stage_Sp == null)
						sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

					if (sol_Orders_Sp == null)
						sol_Orders_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);

					if (sol_OrdersDetail_Sp == null)
						sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);

					if (!ShippingMultiProductStagedContainers.PrintLabel(
								sol_Agency_Sp
								, sol_Product_Sp
								, sol_Stage_Sp
								, sol_Orders_Sp
								, sol_OrdersDetail_Sp
								, stageId
								, DateTime.Now
								))
					{

						if (MessageBox.Show("There was a problem printing the bag tag, do you want to try again?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
						{
							if (MessageBox.Show("Do you want to close the bag anyway?", "Closing Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
							{
								return false;
							}
							printLabel = false;
						}
					}
					else
						printLabel = false;

				} while (printLabel);

				//                    

				//MessageBox.Show("Closing bag");

				//update bagposition
				((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentQuantity = 0;
				((Vir_BagPosition)arrayListBagPositionObjects[index]).CurrentStageID = 0;
				arrayListBagPositionTagNumbers[index] = string.Empty;

				vir_BagPosition_Sp.Update((Vir_BagPosition)arrayListBagPositionObjects[index]);
				FormatBagPositionText(buttonBagPositionClicked, (Vir_BagPosition)arrayListBagPositionObjects[index], string.Empty);
				buttonBagPositionClicked.BackColor = ColorTranslator.FromHtml("#e84141");  //red

				//update bag DateClosed
				SolFunctions.SetDateClosedInStage(stageId, Main.rc.FechaActual.ToString());
			}

			return true;
		}


		private bool AddStagedRow(int productID, int containerID, int dozen, decimal price, int agencyID, bool autoGenerateTagNumber)
		{
			//if(osi == null)
			//    osi = new SirLib.ObtenerSiguienteId(Properties.Settings.Default.WsirDbConnectionString);

			if (sol_Stage_Sp == null)
				sol_Stage_Sp = new Sol_Stage_Sp(Properties.Settings.Default.WsirDbConnectionString);

			sol_Stage = new Sol_Stage();
			sol_Stage.ProductID = productID;
			sol_Stage.ContainerID = containerID;
			sol_Stage.Dozen = dozen;
			sol_Stage.Price = price;

			if (autoGenerateTagNumber)
			{
				if (!AutoGenerateTagNumber(agencyID))
				{
					tagNumber = string.Empty;
					return false;
				}
				sol_Stage.TagNumber = tagNumber;
			}
			else
			{
				ShippingMultiProductStagedContainersTagNumber f1 = new ShippingMultiProductStagedContainersTagNumber();
				f1.ShowDialog();
				bool cancelFlag = f1.cancelFlag;
				tagNumber = f1.tagNumber;
				f1.Dispose();
				f1 = null;
				if (cancelFlag)
				{
					tagNumber = string.Empty;
					return false;
				}
				sol_Stage.TagNumber = tagNumber;
			}

			if (membershipUser == null)
				membershipUser = Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
			if (membershipUser == null)
			{
				tagNumber = string.Empty;
				MessageBox.Show("User does not exits, cannot open bag position!");
				return false;
			}

			sol_Stage.UserID = (Guid)membershipUser.ProviderUserKey;
			sol_Stage.UserName = Properties.Settings.Default.UsuarioNombre;
			sol_Stage.Date = Main.rc.FechaActual; // ; // Properties.Settings.Default.FechaActual;;
			sol_Stage.Status = "I"; //InProcess

			try
			{
				sol_Stage_Sp.Insert(sol_Stage);
			}
			catch //(Exception ex)
			{
				//try once more
				if (autoGenerateTagNumber)
				{
					if (!AutoGenerateTagNumber(agencyID))
					{
						tagNumber = string.Empty;
						return false;
					}
					sol_Stage.TagNumber = tagNumber;
				}
				try
				{
					sol_Stage_Sp.Insert(sol_Stage);
				}
				catch (Exception e)
				{
					tagNumber = string.Empty;
					MessageBox.Show("Error trying to add a new Staged Container, try again please", e.Message);
					sol_Stage = null;
					return false;
				}
			}


			return true;
		}

		private bool AutoGenerateTagNumber(int agencyID)
		{
			if (agencyID < 1)
				return false;

			if (sol_AutoNumber_Sp == null)
				sol_AutoNumber_Sp = new Sol_AutoNumber_Sp(Properties.Settings.Default.WsirDbConnectionString);

			int newTagNumber = sol_AutoNumber_Sp.UpdateTagNumber(agencyID, 1);
			if (newTagNumber < 1)
			{
				MessageBox.Show("Can not generate next tag number, it should be a valid integer.");
				return false;
			}
			tagNumber = newTagNumber.ToString();
			return true;
		}

		private MultiProductOrderDetail ReadMultiProductOrderDetail(int detailID)
		{
			MultiProductOrderDetail od = new MultiProductOrderDetail();
			try
			{
				using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
				{
					using (SqlCommand command = new SqlCommand("sol_OrdersDetail_SelectByDetailID_ForConveyorID", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@DetailID", detailID));
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								int index = 0;
								od.DetailID = (int)reader[index++];
								od.ProductID = (int)reader[index++];
								od.ProductDescription = (string)reader[index++];
								od.Quantity = (int)reader[index++];
								od.Price = (decimal)reader[index++];
								od.Amount = (decimal)reader[index++];
								od.MasterProductID = (int)reader[index++];
								od.AgencyID = (int)reader[index++];
								od.AutoGenerateTagNumber = (bool)reader[index++];
							}
						}
					}
				}
			}
			catch { }
			return od;

		}

		private bool ReadProductAgency(
			int productID
			, ref int containerID
			, ref int dozen
			, ref decimal price
			, ref int agencyID
			, ref bool autoGenerateTagNumber)
		{

			containerID = 0;
			dozen = 0;
			price = 0;
			agencyID = 0;
			autoGenerateTagNumber = false;

			try
			{
				using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
				{
					string sql = @"
						SELECT 
						dbo.[sol_Products].ContainerID
						, dbo.[sol_StandardDozen].Quantity as Dozen
						, dbo.[sol_Products].Price
						, dbo.[sol_Products].AgencyID
						, dbo.[sol_Agencies].AutoGenerateTagNumber
						FROM dbo.[sol_Products]
						INNER JOIN dbo.[sol_Agencies] ON dbo.[sol_Agencies].AgencyID =  dbo.[sol_Products].AgencyID
						LEFT JOIN dbo.[sol_StandardDozen] ON dbo.[sol_StandardDozen].StandardDozenID =  dbo.[sol_Products].StandardDozenID
						WHERE [ProductID] = @ProductID
						";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.CommandType = CommandType.Text;
						command.Parameters.Add(new SqlParameter("@ProductID", productID));
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								int index = 0;
								try { containerID = (int)reader[index++]; } catch { containerID = 0; }
								try { dozen = (int)reader[index++]; } catch { dozen = 0; }
								price = (decimal)reader[index++];
								agencyID = (int)reader[index++];
								autoGenerateTagNumber = (bool)reader[index++];
							}
							else
								return false;
						}
					}
				}
			}
			catch //(Exception ex)
			{
				return false;
			}
			return true;

		}

		private void buttonMove()  //_Click(object sender, EventArgs e)
		{
			//if (currentOrderDetailID < 1)
			//{
			//    MessageBox.Show("Please select a product from one of the conveyors!");
			//    return;
			//}

			int bagPositionID = ReadBagPosition();
			if (bagPositionID < 1)
			{
				//MessageBox.Show("Item not linked to a Bag position. Please review configuration.");
				return;
			}

			int index = 0; // agPositionID-1;
			//int bpIndex = 0;
			foreach (Vir_BagPosition vbp in arrayListBagPositionObjects)
			{
				if (vbp.BagPositionID == bagPositionID)
					break;
				index++;
			}

			if (index > arrayListBagPositionObjects.Count - 1)
			{
				MessageBox.Show("Bag position does not exists. Please review configuration.");
				return;
			}

			Button b = (Button)arrayListBagPositionButtons[index];
			buttonBagPositionClicked = b;

			if (vir_BagPosition_Sp == null)
				vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);

			Vir_BagPosition bp = (Vir_BagPosition)arrayListBagPositionObjects[index];
			if (bp == null)
			{
				MessageBox.Show("Bag position does not exists. Please review configuration.");
				return;
			}

			if (bp.CurrentStageID < 1)
			{
				//open new bag
				if (!OpenCloseBagPosition())
				{
					MessageBox.Show("This Bag position is close. Open it first please.");
					tslCntr = b;
					timerBlink.Enabled = true;
					return;
				}
			}

			if (sol_OrdersDetail_Sp == null)
				sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);

			//A = normal D = void  O = On account P = paid or processed
			Sol_OrdersDetail od = sol_OrdersDetail_Sp.Select(currentOrderDetailID);
			if (od == null
				|| od.StageID > 0
				|| od.Status != "A")
			{
				MessageBox.Show("Sorry, that item no longer exists.  Please select another item.");
				return;
			}

			if (bp.CurrentQuantity >= bp.TargetQuantity)
			{
				if (MessageBox.Show("Bag position if full.  Do you want to continue?", "Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
				{
					//closing bag and print label
					if(OpenCloseBagPosition())
						//open new bag
						if (!OpenCloseBagPosition())
							return;
					else
						return;
				}
			}
			else
			{
				if ((bp.CurrentQuantity + od.Quantity) > bp.TargetQuantity)
				{
					if (MessageBox.Show("Current Quantity will be above Target Quantity.  Do you want to continue?", "Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
					{
						return;
					}
				}
			}

			//recheck again
			od = sol_OrdersDetail_Sp.Select(currentOrderDetailID);
			if (od == null
				|| od.StageID > 0
				|| od.Status != "A")
			{
				MessageBox.Show("Sorry, that item no longer exists.  Please select another item.");
				return;
			}

			bp.CurrentQuantity += od.Quantity;
			vir_BagPosition_Sp.Update(bp);

			od.StageID = bp.CurrentStageID;

			sol_OrdersDetail_Sp.Update(od);

			//FillDataListView(currentListView, currentConveyorID);

			FormatBagPositionText(b, bp, (string)arrayListBagPositionTagNumbers[index]);

			//close bag
			if (bp.CurrentQuantity >= bp.TargetQuantity)
			{
				if (MessageBox.Show("Bag position if full.  Do you want to close it?", "Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
				{
					//closing bag and print label
					if (OpenCloseBagPosition())
						if (MessageBox.Show("Do you want to open a new bag?", "Bag Position", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
							//open new bag
							OpenCloseBagPosition();
				}
			}
		}

		private int ReadBagPosition()
		{
			int bagPositionID = 0;
			try
			{
				using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
				{
					string sql = @"
						SELECT 
						dbo.Vir_BagPosition.BagPositionID
						, dbo.Vir_BagPosition.CurrentStageID
						, dbo.Vir_BagPosition.CurrentQuantity
						, dbo.Vir_BagPosition.TargetQuantity
						FROM dbo.Vir_BagPosition INNER JOIN
							dbo.Vir_ConveyorLink ON dbo.Vir_BagPosition.BagPositionID = dbo.Vir_ConveyorLink.BagPositionID
						WHERE(dbo.Vir_BagPosition.ProductID = @MasterProductID) AND(dbo.Vir_ConveyorLink.ConveyorID = @ConveyorID)
						";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.CommandType = CommandType.Text;
						command.Parameters.Add(new SqlParameter("@ConveyorID", currentConveyorID));
						command.Parameters.Add(new SqlParameter("@MasterProductID", currentMasterProductID));

						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								int index = 0;
								bagPositionID = (int)reader[index++];
							}
						}
					}
				}
			}
			catch { }
			return bagPositionID;
		}

        private void OrderLookupCancelButton_Click(object sender, EventArgs e)
        {
            buttonCancel.PerformClick();
            
        }

      

        //blinking mode
        private void timerBlink_Tick(object sender, System.EventArgs e)
		{
			intCntr = intCntr + 1;
			if (intCntr % 2 == 0)
			{
				tslCntr.Visible = false;
			}
			else
			{
				tslCntr.Visible = true;
				if (intCntr > 5)
				{
					intCntr = 0;
					timerBlink.Enabled = false;
				}
			}

		}

		private void buttonRemove() //_Click(object sender, EventArgs e)
		{
			//update orderdetail
			if (sol_OrdersDetail_Sp == null)
				sol_OrdersDetail_Sp = new Sol_OrdersDetail_Sp(Properties.Settings.Default.WsirDbConnectionString);

			Sol_OrdersDetail od = sol_OrdersDetail_Sp.Select(currentOrderDetailID);
			if (od == null
				//|| od.StageID > 0
				//|| od.Status != "A"
				)
			{
				//MessageBox.Show("Sorry, that item no longer exists.  Please select another item.");
				//FillDataListView();
				return;
			}

			//??
			//od.StageID = 0;
			//sol_OrdersDetail_Sp.Update(od);

			//update bagposition
			int bagPositionID = ReadBagPosition();
			if (bagPositionID < 1)
			{
				//MessageBox.Show("Item not linked to a Bag position. Please review configuration.");
				return;
			}

			int index = 0;
			foreach (Vir_BagPosition vbp in arrayListBagPositionObjects)
			{
				if (vbp.BagPositionID == bagPositionID)
					break;
				index++;
			}
			Button b = (Button)arrayListBagPositionButtons[index];
			buttonBagPositionClicked = b;

			if (vir_BagPosition_Sp == null)
				vir_BagPosition_Sp = new Vir_BagPosition_Sp(Properties.Settings.Default.WsirDbConnectionString);

			Vir_BagPosition bp = (Vir_BagPosition)arrayListBagPositionObjects[index];

			//is another bag, don't update
			if (od.StageID != bp.CurrentStageID)
				return;

			od.StageID = 0;
			sol_OrdersDetail_Sp.Update(od);


			bp.CurrentQuantity -= od.Quantity;
			vir_BagPosition_Sp.Update(bp);

			FormatBagPositionText(b, bp, (string)arrayListBagPositionTagNumbers[index]);

			currentOrderDetailID = 0;
			currentMasterProductID = 0;

		}

		#endregion

		#region NextInLine procedures

		private void buttonNextInLine_Click(object sender, EventArgs e)
		{
			/* width: 1280
			 *
				1) Add two settings to the Virdis settings table:  
					 1-EnableNextinLine (true/false)    
					 2-NextinLineIPAddress varchar(20)   
				   These settings should be added to the database ONLY.  
				   Do not add any extra code or settings in the Virdis program.  
				   When we set up NextInLine, we will just manually add these settings in the Database.             

					USE [Virdis]
					GO
					declare @flag bit = 1
					EXEC	[dbo].[Sol_Settings_Insert] N'EnableNextinLine', N'Enable Next in Line', @flag
					EXEC [dbo].[Sol_Settings_Insert] N'NextinLineIPAddress', N'Next in Line IP Adress', ''
					GO
			 
			*/

			this.Cursor = Cursors.WaitCursor;
			buttonNextInLine.Enabled = false;
			SendToNextinLine(NextinLineIPAddress, computerName);
			this.Cursor = Cursors.Default;
			buttonNextInLine.Enabled = true;
		}

        private void BdBarcodeTextBox_Enter(object sender, EventArgs e)
        {
            previousAcceptButton = this.AcceptButton;
            this.AcceptButton = bdBarcodeSubmitButton;
        }

        private void BdBarcodeTextBox_Leave(object sender, EventArgs e)
        {
            if (bdBarcodeSubmitButton.ContainsFocus || bdBarcodeTextBox.ContainsFocus) return;
            this.AcceptButton = previousAcceptButton;
            bdBarcodePanel.Visible = false;
            bdBarcodeTextBox.Text = "";
        }

        private void BdBarcodeCloseButton_Click(object sender, EventArgs e)
        {
            bdBarcodePanel.Visible = false;
            bdBarcodeTextBox.Text = "";
        }

        private void BdBarcodeSubmitButton_Enter(object sender, EventArgs e)
        {
            bdBarcodeTextBox.Focus();
        }

        private void BdBarcodeSubmitButton_Click(object sender, EventArgs e)
        {
            if(!bdjsHandler.VerifyLabel(bdBarcodeTextBox.Text, out bdjsCurrentOrder))
            {
                bdBarcodeErrorLabel.Text = "Error: " + bdjsCurrentOrder.Message;

                return;
            }
            bdCurrentLblNumber = bdBarcodeTextBox.Text;
            bdLabelNumLabel.Text = "Label #" + bdCurrentLblNumber;
            bdCustNameLabel.Text = "Customer: " + bdjsCurrentOrder.Customer;
            bdCustomerPanel.Visible = true;

            bdBarcodeTextBox.Text = "";
            bdBarcodePanel.Visible = false;

            currentOrderIsForBottleDrop = true;
            buttonNew.PerformClick();
            
        }

        static void SendToNextinLine(String server, String message)
		{

           if (string.IsNullOrEmpty(server))
				return;

			try
			{
				Int32 port = 8888;
				TcpClient client = new TcpClient(server, port);

				// Translate the passed message into ASCII and store it as a Byte array.
				Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

				// Get a client stream for reading and writing.
				//  Stream stream = client.GetStream();

				NetworkStream stream = client.GetStream();

				// Send the message to the connected TcpServer. 
				stream.Write(data, 0, data.Length);

				// Close everything.
				stream.Close();
				client.Close();

                #region add to customer screen

                if (Main.CustomerScreenForm != null)
                    CustomerScreen.timerBlink.Enabled = true;

                #endregion
            }
            catch (ArgumentNullException e)
			{
				MessageBox.Show(String.Format("ArgumentNullException: {0}", e.Message), "NextInLine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (SocketException e)
			{
				MessageBox.Show(String.Format("SocketException: {0}", e.Message), "NextInLine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			//MessageBox.Show("NextInLine", "\n Press Enter to continue...");
			//Console.Read();
		}

        #endregion
        #region BottleDropMethods
        private void BottleDropButton_Click(object sender, EventArgs e)
        {

            if(!bdjsHandler.ConfirmJWT(out bdjsResponse))
                return;
            if (bdjsResponse.Verified) OpenBottleDropBarcodeInput();
            else if(bdjsResponse.Error == "100") OpenBottleDropLogin();

        }

        private void OpenBottleDropLogin()
        {
            var bdLoginForm = new Login2(Properties.Settings.Default.TouchOriented, false, "", "Please verify your BottleDrop Login");
            bdLoginForm.BottleDrop = true;
            bdLoginForm.Recuerdame = false;
            bool auth;
            bdLoginForm.ShowDialog();
            auth = bdLoginForm.IsAuthenticated;
            bdLoginForm.Dispose();
            if (auth) OpenBottleDropBarcodeInput();
        }

        private void OpenBottleDropBarcodeInput()
        {
            bdBarcodePanel.Left = (this.Width / 2) - (bdBarcodePanel.Width / 2);
            bdBarcodePanel.Top = (this.Height / 2) - (bdBarcodePanel.Height / 2);
            bdBarcodePanel.Visible = true;
            bdBarcodeTextBox.Focus();

        }
        private List<BottleDropOrderDetail> CreateBottleDropOrderDetail()
        {
            var orderDetailsList = new List<BottleDropOrderDetail>();
            foreach (ListViewItem itm in listView1.Items)
            {
                int count;
                int.TryParse(itm.SubItems[0].Text, out count);
                double value;
                double.TryParse(itm.SubItems[2].Text, out value);

                orderDetailsList.Add(new BottleDropOrderDetail { Count = count, Value = value, Description = itm.SubItems[1].Text });
            }

            return orderDetailsList;
        }
        private void ClearBottleDrop()
        {
            currentOrderIsForBottleDrop = false;
            bdCustomerPanel.Visible = false;
            bdCustNameLabel.Text = "Customer:";
            bdCurrentLblNumber = "";
            bdLabelNumLabel.Text = "Label #";
            buttonPutOnAccount.Text = "&Put On Account";
            buttonPutOnAccount.BackColor = Color.FromArgb(161, 214, 226);
            buttonPutOnAccount.ForeColor = Color.FromArgb(75, 88, 92);
        }
        #endregion

    }
}
