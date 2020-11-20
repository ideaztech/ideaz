using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Security;

using System.Drawing;
using SirLib;
using System.Data.SqlClient;
using System.Data;

namespace Solum
{
    
    public class SolFunctions
    {
        public static string Quantity2Dozen(int quantity)
        {
            // Use schoolboy rounding, not bankers.
            decimal dozen = (decimal)quantity / 12;
            dozen = Math.Round(dozen, 2, MidpointRounding.AwayFromZero);
            string c = string.Format("{0:##0.00}", dozen);
            return c;
        }


        public static bool SetDateClosedInStage(int stageID, string dateClosed)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    string sql = @"
                        UPDATE [sol_Stage] WITH (ROWLOCK)
                        SET 
	                        [DateClosed] = @DateClosed
                        WHERE [StageID] = @StageID
                        ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@StageID", stageID));
                        command.Parameters.Add(new SqlParameter("@DateClosed", dateClosed));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool SetFinalQuantityInStage(int stageID, int quantity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.WsirDbConnectionString))
                {
                    string sql = @"
                        UPDATE [sol_Stage] WITH (ROWLOCK)
                        SET 
	                        [Quantity] = @Quantity
                        WHERE [StageID] = @StageID
                        ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@StageID", stageID));
                        command.Parameters.Add(new SqlParameter("@Quantity", quantity));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        public static bool PrintReceipt(
            ListView listView1
            , string printParam
            , ref string errorMessage
            , int barcodeEncoding
            , string buttonSource
            , string securityCode
            , decimal totalSelectedOrders
            )
        {
            errorMessage = string.Empty;
            try
            {
                //query
                string query =
                " SELECT " +
                " sol_OrdersDetail.CategoryID, sol_OrdersDetail.Description, " +
                " sol_Orders.OrderID, sol_Orders.OrderType, sol_Orders.ComputerName, sol_Orders.Date, ISNULL(c.Name, '') as Name,  sol_Orders.TotalAmount,  sol_Orders.FeeAmount, " +
                " sol_Fees.FeeDescription, " +
                "SUM(sol_OrdersDetail.Quantity) AS TotalQuantity, sol_OrdersDetail.Price, SUM(sol_OrdersDetail.Amount) as TotalAmountDetail, " +
                //"ISNULL(c.Name, '') as Name, " +
                " u.UserName, " +
                "sol_Orders.Comments " +
                "FROM    " +
                " sol_Orders sol_Orders  " +
                "LEFT JOIN  sol_Customers as c ON c.[CustomerID] = sol_Orders.[CustomerID] " +
                "AND sol_Orders.[CustomerID] != 0 " +
                " INNER JOIN sol_OrdersDetail sol_OrdersDetail  ON (sol_Orders.OrderID = sol_OrdersDetail.OrderID)  " +
                " INNER JOIN sol_Fees sol_Fees ON (sol_Orders.FeeID = sol_Fees.FeeID) " +
                " INNER JOIN Sol_Categories Sol_Categories ON (sol_OrdersDetail.CategoryID = Sol_Categories.CategoryID) " +
                " INNER JOIN Solum.Dbo.aspnet_Users u ON (sol_Orders.UserId = u.UserId) " +
                "WHERE  ";

                string strBarCode = String.Empty;

                //select orders
                bool flagFirstTime = true;
                ListView.ListViewItemCollection Items = listView1.Items;
                foreach (ListViewItem item in Items)
                {
                    string c = item.SubItems[0].Text.Trim();
                    int orderId = 0;
                    try
                    {
                        orderId = Int32.Parse(c);
                    }
                    catch
                    {
                        continue;
                    }

                    c = " OR (sol_Orders.OrderType = '" + item.SubItems[4].Text.Trim() + "' AND  " +
                        "sol_Orders.OrderID =  " + orderId.ToString() + ") ";

                    //if(string.IsNullOrEmpty(strBarCode))
                    strBarCode = orderId.ToString("0000000");
                    //else
                    //    strBarCode = strBarCode + orderId.ToString("0000000") + " ";

                    if (flagFirstTime)
                    {
                        c = c.Replace("OR", "");
                        flagFirstTime = false;
                    }
                    query += c;
                }

                query +=
                "GROUP by sol_OrdersDetail.CategoryID, sol_OrdersDetail.Description,  " +
                "sol_Orders.OrderID, sol_Orders.OrderType, sol_Orders.ComputerName, sol_Orders.Date, c.Name,  sol_Orders.TotalAmount,  sol_Orders.FeeAmount, " +
                "sol_Fees.FeeDescription, " +
                "sol_OrdersDetail.Price, u.UserName, " +
                "sol_Orders.Comments " +
                "ORDER BY sol_OrdersDetail.Description ";

                //query 2
                string query2 = "";
                string subReportName2 = "";

                //query 3
                string query3 = "";
                string subReportName3 = "";


                //receipt message
                Sol_Message sol_Message = new Sol_Message();
                Sol_Message_Sp sol_Message_Sp = new Sol_Message_Sp(Properties.Settings.Default.WsirDbConnectionString);
                sol_Message = sol_Message_Sp.Select(Main.Sol_ControlInfo.ReceiptMessageID);

                CrystalDecisions.CrystalReports.Engine.ReportDocument rp = new Solum.Reports.Receipt2();

                string imagePath = String.Empty;
                string imagePath2 = String.Empty;
                bool printComplete = false;

                //0 = Quick Cash Out 1 = Print Chit
                if (printParam.ToLower() == "paynow")
                    printComplete = true;
                else if (Main.Sol_ControlInfo.ReturnButtonExtra == 0 || buttonSource == "Cashier")
                    printComplete = true;
                else
                {
                    //0 = complete 1 = order number only
                    if (Main.Sol_ControlInfo.ChitTicketComplete == 0)
                        printComplete = true;

                    if (Main.Sol_ControlInfo.ChitTicketIncludeBarcode)
                    {

                        if (Main.Sol_ControlInfo.IncludeSecurityCode)
                        {
                            strBarCode = strBarCode + Main.SecurityCodeSeparator + securityCode;
                        }

                        //MessageBox.Show(string.Format("barcode = {0} length = {1}", strBarCode, strBarCode.Length));
                        //try
                        //{
                        //    System.IO.File.Delete(Main.temFolder + "\\barCode.bmp");
                        //}
                        //catch { }

                        //generate barcode
                        imagePath = Main.temFolder + "\\barCode.bmp";  //Barcodes\\
                        errorMessage = string.Empty;
                        SolFunctions.GenerateBarcode(
                                    Properties.Settings.Default.BarcodeEncoding
                                    , Properties.Settings.Default.BarcodeWidth
                                    , Properties.Settings.Default.BarcodeHeight
                                    , BarcodeLib.AlignmentPositions.LEFT
                                    , System.Drawing.RotateFlipType.RotateNoneFlipNone
                                    , BarcodeLib.LabelPositions.BOTTOMLEFT
                                    , strBarCode
                                    , imagePath
                                    , BarcodeLib.SaveTypes.BMP
                                    , null
                                    , ref errorMessage
                                    );
                    }
                }

                if (Main.Sol_ControlInfo.ReceiptAmountBarcode)
                {

                    //generate barcode
                    imagePath2 = Main.temFolder + "\\barCodeAmount.bmp";  //Barcodes\\
                    errorMessage = string.Empty;
                    SolFunctions.GenerateBarcode(
                                Properties.Settings.Default.BarcodeEncoding
                                , Properties.Settings.Default.BarcodeWidth
                                , Properties.Settings.Default.BarcodeHeight
                                , BarcodeLib.AlignmentPositions.LEFT
                                , System.Drawing.RotateFlipType.RotateNoneFlipNone
                                , BarcodeLib.LabelPositions.BOTTOMLEFT
                                , totalSelectedOrders.ToString()
                                , imagePath2
                                , BarcodeLib.SaveTypes.BMP
                                , null
                                , ref errorMessage
                                );
                }

                object[,] parametros = new object[,] {
                    { "1_BusinessName", Main.Sol_ControlInfo.BusinessName },
                    { "2_StoreNumber", Main.Sol_ControlInfo.StoreNumber.ToString() },
                    { "3_Address", Main.Sol_ControlInfo.Address },
                    { "4_City", Main.Sol_ControlInfo.City },
                    { "5_State", Main.Sol_ControlInfo.State },
                    { "6_PhoneNumber", Main.Sol_ControlInfo.PhoneNumber },
                    { "7_Message", sol_Message.Description },
                    { "8_Print", printParam },
                    { "9_PrintComplete", printComplete },
                    { "imagenPath", imagePath },
                    { "email", Main.Sol_ControlInfo.EmailAccount },
                    { "imagenPath2", imagePath2 },
                    {"", ""}
                };

                bool imprimirReporte = false;
                bool exportarReporte = false;
                short fileFormat = 0;               // 0 = rtf 1 = pdf 2 = word 3 = excel
                bool preverReporte = false;
                short numeroDeCopias = 1;
                if (Properties.Settings.Default.SettingsWsReceiptPrintPreview)
                    preverReporte = true;
                else
                    imprimirReporte = true;

                ReportesPrevista f1 = new ReportesPrevista(
                    Properties.Settings.Default.WsirDbConnectionString,
                    Properties.Settings.Default.SQLServidorNombre,
                    Properties.Settings.Default.SQLBaseDeDatos,
                    Properties.Settings.Default.SQLAutentificacion,
                    Properties.Settings.Default.SQLUsuarioNombre,
                    Properties.Settings.Default.SQLUsuarioClave,
                    rp,
                    query,
                    query2,
                    query3,
                    parametros,
                    subReportName2,
                    subReportName3,
                    Properties.Settings.Default.SettingsWsReceiptPrinter.Trim(),
                    fileFormat,
                    String.Empty,
                    numeroDeCopias,
                    exportarReporte,
                    imprimirReporte,
                    preverReporte,
                    null,
                    String.Empty,
                    true,
                    true
                );

                f1.ShowDialog();
                f1.Dispose();
                f1 = null;

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }

            return true;
        }

        public static void CheckAllItemsListView(ListView lvw, bool check)
        {
            lvw.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = check);
        }

        public static Color ColorTryParse(int colorArgb, string strColor)
        {
            Color color;

            if (colorArgb != 0)
                color = Color.FromArgb(colorArgb);
            else
            {
                try
                {
                    color = ColorTranslator.FromHtml(strColor);
                }
                catch
                {
                    try
                    {
                        color = Funciones.ColorParser(strColor);

                    }
                    catch
                    {
                        //default
                        color = Color.White;
                    }

                }
            }
            return color;
        }

        public static void CompleteOrder(
            int orderID
            , string orderType
            , ref List<int> listOfBagsCounted
            , ref List<int> listOfBagsNotCounted
            )
        {

            if (listOfBagsNotCounted.Count < 1)
                return;

            //set the status of the rest of the bags to MISSING
            Qds_Drop_Sp qds_Drop_Sp = new Qds_Drop_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Qds_Drop> dl = qds_Drop_Sp._SelectAllByOrderID_OrderType(orderID, orderType);
            Qds_Drop qds_Drop = dl[0];
            Qds_Bag_Sp qds_Bag_Sp = new Qds_Bag_Sp(Properties.Settings.Default.WsirDbConnectionString);

            List<Qds_Bag> bl = qds_Bag_Sp._SelectAllByDropID(qds_Drop.DropID);
            //create new drop for missing bags
            Qds_Drop nd = new Qds_Drop();
            //nd.DropID = 0;
            nd.CustomerID = qds_Drop.CustomerID;
            nd.NumberOfBags = listOfBagsNotCounted.Count;  // od.NumberOfBags;
            nd.PaymentMethodID = qds_Drop.PaymentMethodID;
            nd.DepotID = qds_Drop.DepotID;
            nd.OrderID = 0;
            nd.OrderType = "M"; //missing
            qds_Drop_Sp.Insert(nd);

            //move missing bags to new drop
            //foreach(ComboBoxItem i in comboBoxBagId.Items)

            foreach (int id in listOfBagsNotCounted)
            {
                //move missing bag
                Qds_Bag mb = qds_Bag_Sp.Select(id); //bagIdFromComboBox);
                mb.DropID = nd.DropID;
                qds_Bag_Sp.Update(mb);

            }

            //change numer of bags of the original drop
            qds_Drop.NumberOfBags -= listOfBagsNotCounted.Count();
            qds_Drop_Sp.Update(qds_Drop);

            //close order
            Sol_Order_Sp sol_Order_Sp = new Sol_Order_Sp(Properties.Settings.Default.WsirDbConnectionString);
            Sol_Order sol_Order = sol_Order_Sp.Select(orderID, orderType);

            sol_Order_Sp.UpdateDates(sol_Order.OrderID, sol_Order.OrderType, "", "DateClosed");

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

            //update customerID
            //sol_Order_Sp._UpdateCustomerID(sol_Order.OrderID, sol_Order.OrderType, qds_Drop.CustomerID);
        }

        public static bool PermisosConfirmar(
            string title,
            string action,
            string permissionName)
        {


            if (!Roles.IsUserInRole(Properties.Settings.Default.UsuarioNombre, "admin"))
            {
                if (Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, Properties.Settings.Default.UsuarioNombre, permissionName, false))
                    return true;
            }

            bool IsAuthenticated = false;
            if (String.IsNullOrEmpty(action))
                action = "Need permission to do this!";
            Login2 dlg = new Login2(Properties.Settings.Default.TouchOriented, true, title, action);   //, "Confirm your authenticity please");
            dlg.Usuario = Properties.Settings.Default.LoginUsuarioNombre;
            dlg.Recuerdame = Properties.Settings.Default.LoginUsuarioRecuerdame;
            //dlg.IsAuthenticated = true; //IsAuthenticated;
            dlg.ShowDialog();
            IsAuthenticated = dlg.IsAuthenticated;
            if (IsAuthenticated)
            {
                //is an admin?
                if (!Roles.IsUserInRole(dlg.Usuario, "admin"))
                {
                    //has that permission in particular?
                    //Dictionary<string, bool> permisos = null;  // = new Dictionary<string, bool>();
                    if (!
                        //Funciones.PermisosObtener_Leer(Properties.Settings.Default.WsirConnectionString, ref permisos, permissionName, dlg.Usuario, "", false))
                        Main.CheckUserPermission(Properties.Settings.Default.WsirConnectionString, dlg.Usuario, permissionName, false))
                        IsAuthenticated = false;
                }
            }

            if (!IsAuthenticated)
            {
                MessageBox.Show("Sorry! You don't have the permission to do this, cannot continue!");
                return false;
            }

            dlg.Dispose();
            dlg = null;

            return true;
        }

        public static bool CheckCashier()
        {
            Sol_Entrie sol_Entrie = new Sol_Entrie();
            Sol_Entrie_Sp sol_Entrie_Sp = new Sol_Entrie_Sp(Properties.Settings.Default.WsirDbConnectionString);
            if (SolFunctions.IsCashierClosed(ref sol_Entrie, sol_Entrie_Sp, Properties.Settings.Default.SettingsCurrentCashTray))
            {
                //*************************************************
                //check if the Main.rc is enabled (RelojCalendario)
                //*************************************************
                //MessageBox.Show("You need to Open a new Cashier before using this option!");  //can pay a Return!");
                //Close();
                return false;

            }
            return true;
        }

        public static bool GenerateBarcode(
            int barcodeEncoding
            , int width
            , int height
            , BarcodeLib.AlignmentPositions alignmentPosition
            , System.Drawing.RotateFlipType rotateFlipType
            , BarcodeLib.LabelPositions labelPosition
            , string stringToEncode
            , string imagePathAndName
            , BarcodeLib.SaveTypes saveType
            , System.Windows.Forms.GroupBox barcode
            , ref string errorMessage
            )
        {
            errorMessage = string.Empty;

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.Alignment = alignmentPosition;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;

            if (barcodeEncoding > 1)
                barcodeEncoding = 1;

            switch (barcodeEncoding)
            {
                ////case 0: type = BarcodeLib.TYPE.UPCA; break;                             //"UPC-A"
                ////case 1: type = BarcodeLib.TYPE.UPCE; break;                             //"UPC-E"
                ////case 2: type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;          //"UPC 2 Digit Ext."
                ////case 3: type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;          //"UPC 5 Digit Ext".
                ////case 4: type = BarcodeLib.TYPE.EAN13; break;                            //"EAN-13"
                ////case 5: type = BarcodeLib.TYPE.JAN13; break;                            //"JAN-13"
                ////case 6: type = BarcodeLib.TYPE.EAN8; break;                             //"EAN-8"
                ////case 7: type = BarcodeLib.TYPE.ITF14; break;                            //"ITF-14"
                //case 0: type = BarcodeLib.TYPE.Interleaved2of5; break;                  //"Interleaved 2 of 5"
                //case 1: type = BarcodeLib.TYPE.Standard2of5; break;                     //"Standard 2 of 5"
                ////case 10: type = BarcodeLib.TYPE.Codabar; break;                          //"Codabar"
                ////case 11: type = BarcodeLib.TYPE.PostNet; break;                          //"PostNet"
                //case 2: type = BarcodeLib.TYPE.BOOKLAND; break;                        //"Bookland/ISBN"
                //case 3: type = BarcodeLib.TYPE.CODE11; break;                          //"Code 11"
                case 0: type = BarcodeLib.TYPE.CODE39; break;                          //"Code 39"
                //case 5: type = BarcodeLib.TYPE.CODE39Extended; break;                  //"Code 39 Extended"
                //case 6: type = BarcodeLib.TYPE.CODE39_Mod43; break;                    //"Code 39 Mod 43"
                //case 7: type = BarcodeLib.TYPE.CODE93; break;                          //"Code 93"
                case 1: type = BarcodeLib.TYPE.CODE128; break;                         //"Code 128"
                //case 9: type = BarcodeLib.TYPE.CODE128A; break;                        //"Code 128-A"
                //case 10: type = BarcodeLib.TYPE.CODE128B; break;                        //"Code 128-B"
                //case 11: type = BarcodeLib.TYPE.CODE128C; break;                        //"Code 128-C"
                //case 12: type = BarcodeLib.TYPE.LOGMARS; break;                         //"LOGMARS"
                //case 13: type = BarcodeLib.TYPE.MSI_Mod10; break;                       //"MSI"
                //case 14: type = BarcodeLib.TYPE.TELEPEN; break;                         //"Telepen"
                ////case 25: type = BarcodeLib.TYPE.FIM; break;                             //"FIM"
                ////case 26: type = BarcodeLib.TYPE.PHARMACODE; break;                      //"Pharmacode"
                default: type = BarcodeLib.TYPE.CODE128; break;                         //"Code 128"
            }//switch

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    b.IncludeLabel = true;

                    b.RotateFlipType = rotateFlipType;
                    b.LabelPosition = labelPosition;
                    if (barcode == null)
                    {
                        barcode = new System.Windows.Forms.GroupBox();
                        // 
                        // barcode
                        // 
                        barcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                        barcode.Dock = System.Windows.Forms.DockStyle.Fill;
                        barcode.Location = new System.Drawing.Point(0, 0);
                        barcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                        barcode.Name = "barcode";
                        barcode.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
                        barcode.Size = new System.Drawing.Size(754, 414);
                        barcode.TabIndex = 36;
                        barcode.TabStop = false;
                        barcode.Text = "Barcode Image";
                        barcode.Visible = false;
                    }

                    //===== Encoding performed here =====
                    barcode.BackgroundImage = b.Encode(type, stringToEncode, System.Drawing.Color.Black, System.Drawing.Color.White, width, height);
                    //===================================
                    //reposition the barcode image to the middle
                    barcode.Location = new System.Drawing.Point((barcode.Location.X + barcode.Width / 2) - barcode.Width / 2, (barcode.Location.Y + barcode.Height / 2) - barcode.Height / 2);

                    if(!string.IsNullOrEmpty(imagePathAndName))
                        b.SaveImage(imagePathAndName, saveType);

                }//if

            }//try
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;

            }//catch

            return true;
        }

        public static bool GetCardNumber(string result, ref string strCardNumber, char charSeparator)
        {
            try
            {
                strCardNumber = string.Empty;
                if (String.IsNullOrEmpty(result))
                    return false;

                string[] cardNumberArray;

                //???
                if (result.IndexOf("SOLUM", 0) >= 0)
                {
                    /*If track 1 says: SOLUM
                      Then get 12 digit number from track 2.  Confirm number starts with 38 and is 12 digits long.
                      If track to doesn't have a valid number ( such as if card is worn out)
                                  Then try to read the number from track 3.
                          If neither track 2 or 3 have valid numbers, then pop up message that it was not able to read the card.
                    */

                    cardNumberArray = result.Split(charSeparator); //'&');
                    if (cardNumberArray.Count() < 1)
                        return false;
                    else
                    {

                        strCardNumber = cardNumberArray[1];
                        if (strCardNumber.Length < 13)
                        {
                            if (cardNumberArray.Count() < 2)
                                return false;
                            strCardNumber = cardNumberArray[2];

                        }
                        if (strCardNumber.Length < 13)
                        {
                            strCardNumber = String.Empty;
                            return false;
                        }
                        else
                        {
                            strCardNumber = strCardNumber.Substring(0, 12);
                            if (strCardNumber.Substring(0, 2) != "38")
                            {
                                strCardNumber = String.Empty;
                                return false;
                            }

                        }
                    }

                }
                else
                {
                    result = result.Replace("\0", "");

                    cardNumberArray = result.Split('^'); //'&');
                    cardNumberArray[0] = cardNumberArray[0].Replace("\r", "");

                    if (cardNumberArray[0].Length > 4)
                    {
                        strCardNumber = cardNumberArray[0].Substring(4);
                        if (strCardNumber.Length > 16)
                        {
                            strCardNumber = String.Empty;
                            return false;
                        }

                    }
                    else
                    {
                        strCardNumber = String.Empty;
                        return false;
                    }

                }
            }
            catch
            {
                strCardNumber = String.Empty;
                return false;

            }

            //strCardNumber = strCardNumber + "?";
            strCardNumber = System.Text.RegularExpressions.Regex.Replace(strCardNumber, "[^.0-9]", "");

            return true;
        }

        public static void CheckComputerRole(
            ref ToolStripButton toolStripButtonExit
            )
        {
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
                    //case 1:     //Returns/Sales
                    //    break;
                    //case 2:     //Cashier
                    //    break;
                    case 3:     //Shipping
                        break;
                    default:    //anything else
                        toolStripButtonExit.PerformClick();
                        break;

                }

            }
        }

        public static void LogOff(ref ToolStripStatusLabel labelUser)
        {
            //hacer logout si el usuario estaba conectado
            if (Main.IsAuthenticated)
            {
                DialogResult result = MessageBox.Show("Do you want to log out?", "", MessageBoxButtons.YesNo);
                if (result != System.Windows.Forms.DialogResult.Yes)
                    return;

                //toolStripStatusLabelUserName.Text = String.Empty;
                labelUser.Text = String.Empty;
                Main.IsAuthenticated = false;

                Login2 dlg = new Login2(Properties.Settings.Default.TouchOriented, false, "Login", "Enter your credentials please");
                dlg.Usuario = Properties.Settings.Default.LoginUsuarioNombre;
                dlg.Recuerdame = Properties.Settings.Default.LoginUsuarioRecuerdame;
                dlg.IsAuthenticated = Main.IsAuthenticated;
                dlg.ShowDialog();
                Properties.Settings.Default.LoginUsuarioNombre = dlg.Usuario;
                Properties.Settings.Default.LoginUsuarioRecuerdame = dlg.Recuerdame;
                Main.IsAuthenticated = dlg.IsAuthenticated;
                Properties.Settings.Default.UsuarioNombre = dlg.Usuario;
                Properties.Settings.Default.Save();

                //salimos si no hay usuario en sesion
                if (!Main.IsAuthenticated)
                {
                    Application.Exit();
                    //Close();
                }

                //toolStripStatusLabelUserName.Text = dlg.Usuario;    // User.Trim();// +".";
                labelUser.Text = dlg.Usuario;

                //change clerkname in customerScreen if any
                if (Main.CustomerScreenForm != null)
                    Main.CustomerScreenForm.toolStripStatusLabelUser.Text = dlg.Usuario;

                dlg.Dispose();
                dlg = null;

            }

        }

        private int iVal(string sVal)
        {
            int iValue = 0;
            int.TryParse(sVal, out iValue);
            return iValue;
        }

        private decimal dVal(string sVal)
        {
            decimal dValue = 0m;
            decimal.TryParse(sVal, out dValue);

            return dValue;
        }

        public static bool IsCashierClosed(ref Sol_Entrie sol_Entrie, Sol_Entrie_Sp sol_Entrie_Sp, int cashTrayID)
        {
            //open cashier
            sol_Entrie = sol_Entrie_Sp.SelectLastType("O", cashTrayID);
            DateTime OpenLatestDate;
            if (sol_Entrie == null)
                OpenLatestDate = DateTime.MinValue;
            else
                OpenLatestDate = sol_Entrie.Date;
            //close cashier
            sol_Entrie = sol_Entrie_Sp.SelectLastType("C", cashTrayID);
            DateTime CloseLatestDate;
            if (sol_Entrie == null)
            {
                CloseLatestDate = DateTime.MinValue;
            }
            else
            {
                CloseLatestDate = sol_Entrie.Date;
            }

            return (CloseLatestDate >= OpenLatestDate);

        }

    }

    public class Cajero_Automatico
    {
        /// <summary>
        /// Calculate coins and bills by country
        /// </summary>
        /// <param name="country">ca</param>
        /// <param name="totalAmount"></param>
        /// <param name="billsAndCoinsByCountry"></param>
        /// <param name="totalCoins"></param>
        /// <param name="totalBills"></param>
        public static void Calculate(
            string country, 
            decimal totalAmount, 
            //ref BindingList<BillsAndCoinsByCountry> billsAndCoinsByCountry, 
            out decimal totalCoins, 
            out decimal totalBills)
        {
            totalCoins = 0;
            totalBills = 0;
            //string[,,] stringResult;

            //canada
            if (country.IndexOf("CA") < 0)
                return;

            int iDecimalPart = (int)((totalAmount - Math.Truncate(totalAmount)) * 100);
            int iIntegerPart = (int)(totalAmount) * 100;
            int iTotalPaidOrders = iIntegerPart + iDecimalPart;

            int Remain = iTotalPaidOrders;


            Sac_Money_Sp sac_Money_Sp = new Sac_Money_Sp(Properties.Settings.Default.WsirDbConnectionString);
            //List<Sac_Money> sac_MoneyList = new List<Sac_Money>();
            List<Sac_Money> sac_MoneyList = sac_Money_Sp.SelectAll();
            foreach (Sac_Money bc in sac_MoneyList)

            //foreach (BillsAndCoinsByCountry bc in billsAndCoinsByCountry)
            {
                if (bc.CountryCode != country)
                    continue;

                int iDollarValue = (int)(bc.DollarValue * 100);
                if (iDollarValue == 0)
                    continue;

                int Total = Remain / iDollarValue;
                if (Total == 0)
                    continue;

                Remain = Remain % iDollarValue;

                //totals by type 
                if (bc.TypeID == 0)   //coins
                    totalCoins += iDollarValue * Total;
                else               // bills
                    totalBills += iDollarValue * Total;
            }
            
            totalCoins /= 100;
            totalBills /= 100;


        }
    }

    public static class StringExtensions
    {
        public static string Right(this string sValue, int iMaxLength)
        {
            //Check if the value is valid
            if (string.IsNullOrEmpty(sValue))
            {
                //Set valid empty string as string could be null
                sValue = string.Empty;
            }
            else if (sValue.Length > iMaxLength)
            {
                //Make the string no longer than the max length
                sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength);
            }

            //Return the string
            return sValue;
        }

        public static string Left(this string str, int length)
        {
            str = (str ?? string.Empty);
            return str.Substring(0, Math.Min(length, str.Length));
        }
    }


}
