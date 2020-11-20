using System;

namespace Solum
{
	public class Sol_Control
	{
		#region Fields

		private int controlID;
		private string businessName;
		private string legalName;
		private int storeNumber;
		private string address;
		private string city;
		private string state;
		private string country;
		private string phoneNumber;
		private DateTime businessHoursFrom;
		private DateTime businessHoursTo;
		private string idFiscal1Name;
		private string idFiscal1Value;
		private string idFiscal2Name;
		private string idFiscal2Value;
		private int workStationID;
		private int customerScreenMessageID;
		private int frontStationMessageID;
		private int cashierRoutineMessageID;
		private int returnStationMessageID;
		private int cashierStationMessageID;
		private int shippingStationMessageID;
		private int receiptMessageID;
		private string sMTPServer;
		private int sMTPPort;
		private string emailAccount;
		private string emailPassword;
		private byte historyYears;
		private byte fiscalYearInitialMonth;
		private bool numericKeyPadOn;
		private byte numericKeyPadPosition;
		private byte returnButtonExtra;
		private string tax1Name;
		private decimal tax1Rate;
		private string tax2Name;
		private decimal tax2Rate;
		private decimal databaseVersion;
		private string status;
		private int employeesListRefresh;
		private string webBrowserUrl;
		private bool autoGenerateTagNumber;
		private bool autoGenerateRBillNumber;
		private int defaultAgencyID;
		private byte chitTicketComplete;
		private bool chitTicketIncludeBarcode;
		private bool cashOutPrintingOverride;
		private int whiteBagID;
		private int blueBagID;
		private int oneWayBagID;
		private int aBCRCPalletsID;
		private byte customerScreenMonitor;
		private int categoryButtonsPanelBgColor;
		private bool categoryButtonsSnapToGrid;
		private DateTime businessHoursFromTue;
		private DateTime businessHoursToTue;
		private DateTime businessHoursFromWed;
		private DateTime businessHoursToWed;
		private DateTime businessHoursFromThu;
		private DateTime businessHoursToThu;
		private DateTime businessHoursFromFri;
		private DateTime businessHoursToFri;
		private DateTime businessHoursFromSat;
		private DateTime businessHoursToSat;
		private DateTime businessHoursFromSun;
		private DateTime businessHoursToSun;
		private int returnsMaxQuantity;
		private string webBrowserUpdateHistoryUrl;
		private decimal cashierMaxAmount;
		private byte computerRole;
		private bool sqlServerDate;
		private int vendorID;
		private int defaultPlantID;
		private int defaultCarrierID;
		private string aBCRCUserName;
		private string aBCRCPassword;
		private bool receiptAmountBarcode;
		private bool includeSecurityCode;
		private bool rBillNumberBarcode;
		private int sacCashTrayID;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Control class.
		/// </summary>
		public Sol_Control()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Control class.
		/// </summary>
		public Sol_Control(int controlID, string businessName, string legalName, int storeNumber, string address, string city, string state, string country, string phoneNumber, DateTime businessHoursFrom, DateTime businessHoursTo, string idFiscal1Name, string idFiscal1Value, string idFiscal2Name, string idFiscal2Value, int workStationID, int customerScreenMessageID, int frontStationMessageID, int cashierRoutineMessageID, int returnStationMessageID, int cashierStationMessageID, int shippingStationMessageID, int receiptMessageID, string sMTPServer, int sMTPPort, string emailAccount, string emailPassword, byte historyYears, byte fiscalYearInitialMonth, bool numericKeyPadOn, byte numericKeyPadPosition, byte returnButtonExtra, string tax1Name, decimal tax1Rate, string tax2Name, decimal tax2Rate, decimal databaseVersion, string status, int employeesListRefresh, string webBrowserUrl, bool autoGenerateTagNumber, bool autoGenerateRBillNumber, int defaultAgencyID, byte chitTicketComplete, bool chitTicketIncludeBarcode, bool cashOutPrintingOverride, int whiteBagID, int blueBagID, int oneWayBagID, int aBCRCPalletsID, byte customerScreenMonitor, int categoryButtonsPanelBgColor, bool categoryButtonsSnapToGrid, DateTime businessHoursFromTue, DateTime businessHoursToTue, DateTime businessHoursFromWed, DateTime businessHoursToWed, DateTime businessHoursFromThu, DateTime businessHoursToThu, DateTime businessHoursFromFri, DateTime businessHoursToFri, DateTime businessHoursFromSat, DateTime businessHoursToSat, DateTime businessHoursFromSun, DateTime businessHoursToSun, int returnsMaxQuantity, string webBrowserUpdateHistoryUrl, decimal cashierMaxAmount, byte computerRole, bool sqlServerDate, int vendorID, int defaultPlantID, int defaultCarrierID, string aBCRCUserName, string aBCRCPassword, bool receiptAmountBarcode, bool includeSecurityCode, bool rBillNumberBarcode, int sacCashTrayID)
		{
			this.controlID = controlID;
			this.businessName = businessName;
			this.legalName = legalName;
			this.storeNumber = storeNumber;
			this.address = address;
			this.city = city;
			this.state = state;
			this.country = country;
			this.phoneNumber = phoneNumber;
			this.businessHoursFrom = businessHoursFrom;
			this.businessHoursTo = businessHoursTo;
			this.idFiscal1Name = idFiscal1Name;
			this.idFiscal1Value = idFiscal1Value;
			this.idFiscal2Name = idFiscal2Name;
			this.idFiscal2Value = idFiscal2Value;
			this.workStationID = workStationID;
			this.customerScreenMessageID = customerScreenMessageID;
			this.frontStationMessageID = frontStationMessageID;
			this.cashierRoutineMessageID = cashierRoutineMessageID;
			this.returnStationMessageID = returnStationMessageID;
			this.cashierStationMessageID = cashierStationMessageID;
			this.shippingStationMessageID = shippingStationMessageID;
			this.receiptMessageID = receiptMessageID;
			this.sMTPServer = sMTPServer;
			this.sMTPPort = sMTPPort;
			this.emailAccount = emailAccount;
			this.emailPassword = emailPassword;
			this.historyYears = historyYears;
			this.fiscalYearInitialMonth = fiscalYearInitialMonth;
			this.numericKeyPadOn = numericKeyPadOn;
			this.numericKeyPadPosition = numericKeyPadPosition;
			this.returnButtonExtra = returnButtonExtra;
			this.tax1Name = tax1Name;
			this.tax1Rate = tax1Rate;
			this.tax2Name = tax2Name;
			this.tax2Rate = tax2Rate;
			this.databaseVersion = databaseVersion;
			this.status = status;
			this.employeesListRefresh = employeesListRefresh;
			this.webBrowserUrl = webBrowserUrl;
			this.autoGenerateTagNumber = autoGenerateTagNumber;
			this.autoGenerateRBillNumber = autoGenerateRBillNumber;
			this.defaultAgencyID = defaultAgencyID;
			this.chitTicketComplete = chitTicketComplete;
			this.chitTicketIncludeBarcode = chitTicketIncludeBarcode;
			this.cashOutPrintingOverride = cashOutPrintingOverride;
			this.whiteBagID = whiteBagID;
			this.blueBagID = blueBagID;
			this.oneWayBagID = oneWayBagID;
			this.aBCRCPalletsID = aBCRCPalletsID;
			this.customerScreenMonitor = customerScreenMonitor;
			this.categoryButtonsPanelBgColor = categoryButtonsPanelBgColor;
			this.categoryButtonsSnapToGrid = categoryButtonsSnapToGrid;
			this.businessHoursFromTue = businessHoursFromTue;
			this.businessHoursToTue = businessHoursToTue;
			this.businessHoursFromWed = businessHoursFromWed;
			this.businessHoursToWed = businessHoursToWed;
			this.businessHoursFromThu = businessHoursFromThu;
			this.businessHoursToThu = businessHoursToThu;
			this.businessHoursFromFri = businessHoursFromFri;
			this.businessHoursToFri = businessHoursToFri;
			this.businessHoursFromSat = businessHoursFromSat;
			this.businessHoursToSat = businessHoursToSat;
			this.businessHoursFromSun = businessHoursFromSun;
			this.businessHoursToSun = businessHoursToSun;
			this.returnsMaxQuantity = returnsMaxQuantity;
			this.webBrowserUpdateHistoryUrl = webBrowserUpdateHistoryUrl;
			this.cashierMaxAmount = cashierMaxAmount;
			this.computerRole = computerRole;
			this.sqlServerDate = sqlServerDate;
			this.vendorID = vendorID;
			this.defaultPlantID = defaultPlantID;
			this.defaultCarrierID = defaultCarrierID;
			this.aBCRCUserName = aBCRCUserName;
			this.aBCRCPassword = aBCRCPassword;
			this.receiptAmountBarcode = receiptAmountBarcode;
			this.includeSecurityCode = includeSecurityCode;
			this.rBillNumberBarcode = rBillNumberBarcode;
			this.sacCashTrayID = sacCashTrayID;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ControlID value.
		/// </summary>
		public virtual int ControlID
		{
			get { return controlID; }
			set { controlID = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessName value.
		/// </summary>
		public virtual string BusinessName
		{
			get { return businessName; }
			set { businessName = value; }
		}

		/// <summary>
		/// Gets or sets the LegalName value.
		/// </summary>
		public virtual string LegalName
		{
			get { return legalName; }
			set { legalName = value; }
		}

		/// <summary>
		/// Gets or sets the StoreNumber value.
		/// </summary>
		public virtual int StoreNumber
		{
			get { return storeNumber; }
			set { storeNumber = value; }
		}

		/// <summary>
		/// Gets or sets the Address value.
		/// </summary>
		public virtual string Address
		{
			get { return address; }
			set { address = value; }
		}

		/// <summary>
		/// Gets or sets the City value.
		/// </summary>
		public virtual string City
		{
			get { return city; }
			set { city = value; }
		}

		/// <summary>
		/// Gets or sets the State value.
		/// </summary>
		public virtual string State
		{
			get { return state; }
			set { state = value; }
		}

		/// <summary>
		/// Gets or sets the Country value.
		/// </summary>
		public virtual string Country
		{
			get { return country; }
			set { country = value; }
		}

		/// <summary>
		/// Gets or sets the PhoneNumber value.
		/// </summary>
		public virtual string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursFrom value.
		/// </summary>
		public virtual DateTime BusinessHoursFrom
		{
			get { return businessHoursFrom; }
			set { businessHoursFrom = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursTo value.
		/// </summary>
		public virtual DateTime BusinessHoursTo
		{
			get { return businessHoursTo; }
			set { businessHoursTo = value; }
		}

		/// <summary>
		/// Gets or sets the IdFiscal1Name value.
		/// </summary>
		public virtual string IdFiscal1Name
		{
			get { return idFiscal1Name; }
			set { idFiscal1Name = value; }
		}

		/// <summary>
		/// Gets or sets the IdFiscal1Value value.
		/// </summary>
		public virtual string IdFiscal1Value
		{
			get { return idFiscal1Value; }
			set { idFiscal1Value = value; }
		}

		/// <summary>
		/// Gets or sets the IdFiscal2Name value.
		/// </summary>
		public virtual string IdFiscal2Name
		{
			get { return idFiscal2Name; }
			set { idFiscal2Name = value; }
		}

		/// <summary>
		/// Gets or sets the IdFiscal2Value value.
		/// </summary>
		public virtual string IdFiscal2Value
		{
			get { return idFiscal2Value; }
			set { idFiscal2Value = value; }
		}

		/// <summary>
		/// Gets or sets the WorkStationID value.
		/// </summary>
		public virtual int WorkStationID
		{
			get { return workStationID; }
			set { workStationID = value; }
		}

		/// <summary>
		/// Gets or sets the CustomerScreenMessageID value.
		/// </summary>
		public virtual int CustomerScreenMessageID
		{
			get { return customerScreenMessageID; }
			set { customerScreenMessageID = value; }
		}

		/// <summary>
		/// Gets or sets the FrontStationMessageID value.
		/// </summary>
		public virtual int FrontStationMessageID
		{
			get { return frontStationMessageID; }
			set { frontStationMessageID = value; }
		}

		/// <summary>
		/// Gets or sets the CashierRoutineMessageID value.
		/// </summary>
		public virtual int CashierRoutineMessageID
		{
			get { return cashierRoutineMessageID; }
			set { cashierRoutineMessageID = value; }
		}

		/// <summary>
		/// Gets or sets the ReturnStationMessageID value.
		/// </summary>
		public virtual int ReturnStationMessageID
		{
			get { return returnStationMessageID; }
			set { returnStationMessageID = value; }
		}

		/// <summary>
		/// Gets or sets the CashierStationMessageID value.
		/// </summary>
		public virtual int CashierStationMessageID
		{
			get { return cashierStationMessageID; }
			set { cashierStationMessageID = value; }
		}

		/// <summary>
		/// Gets or sets the ShippingStationMessageID value.
		/// </summary>
		public virtual int ShippingStationMessageID
		{
			get { return shippingStationMessageID; }
			set { shippingStationMessageID = value; }
		}

		/// <summary>
		/// Gets or sets the ReceiptMessageID value.
		/// </summary>
		public virtual int ReceiptMessageID
		{
			get { return receiptMessageID; }
			set { receiptMessageID = value; }
		}

		/// <summary>
		/// Gets or sets the SMTPServer value.
		/// </summary>
		public virtual string SMTPServer
		{
			get { return sMTPServer; }
			set { sMTPServer = value; }
		}

		/// <summary>
		/// Gets or sets the SMTPPort value.
		/// </summary>
		public virtual int SMTPPort
		{
			get { return sMTPPort; }
			set { sMTPPort = value; }
		}

		/// <summary>
		/// Gets or sets the EmailAccount value.
		/// </summary>
		public virtual string EmailAccount
		{
			get { return emailAccount; }
			set { emailAccount = value; }
		}

		/// <summary>
		/// Gets or sets the EmailPassword value.
		/// </summary>
		public virtual string EmailPassword
		{
			get { return emailPassword; }
			set { emailPassword = value; }
		}

		/// <summary>
		/// Gets or sets the HistoryYears value.
		/// </summary>
		public virtual byte HistoryYears
		{
			get { return historyYears; }
			set { historyYears = value; }
		}

		/// <summary>
		/// Gets or sets the FiscalYearInitialMonth value.
		/// </summary>
		public virtual byte FiscalYearInitialMonth
		{
			get { return fiscalYearInitialMonth; }
			set { fiscalYearInitialMonth = value; }
		}

		/// <summary>
		/// Gets or sets the NumericKeyPadOn value.
		/// </summary>
		public virtual bool NumericKeyPadOn
		{
			get { return numericKeyPadOn; }
			set { numericKeyPadOn = value; }
		}

		/// <summary>
		/// Gets or sets the NumericKeyPadPosition value.
		/// </summary>
		public virtual byte NumericKeyPadPosition
		{
			get { return numericKeyPadPosition; }
			set { numericKeyPadPosition = value; }
		}

		/// <summary>
		/// Gets or sets the ReturnButtonExtra value.
		/// </summary>
		public virtual byte ReturnButtonExtra
		{
			get { return returnButtonExtra; }
			set { returnButtonExtra = value; }
		}

		/// <summary>
		/// Gets or sets the Tax1Name value.
		/// </summary>
		public virtual string Tax1Name
		{
			get { return tax1Name; }
			set { tax1Name = value; }
		}

		/// <summary>
		/// Gets or sets the Tax1Rate value.
		/// </summary>
		public virtual decimal Tax1Rate
		{
			get { return tax1Rate; }
			set { tax1Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Tax2Name value.
		/// </summary>
		public virtual string Tax2Name
		{
			get { return tax2Name; }
			set { tax2Name = value; }
		}

		/// <summary>
		/// Gets or sets the Tax2Rate value.
		/// </summary>
		public virtual decimal Tax2Rate
		{
			get { return tax2Rate; }
			set { tax2Rate = value; }
		}

		/// <summary>
		/// Gets or sets the DatabaseVersion value.
		/// </summary>
		public virtual decimal DatabaseVersion
		{
			get { return databaseVersion; }
			set { databaseVersion = value; }
		}

		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public virtual string Status
		{
			get { return status; }
			set { status = value; }
		}

		/// <summary>
		/// Gets or sets the EmployeesListRefresh value.
		/// </summary>
		public virtual int EmployeesListRefresh
		{
			get { return employeesListRefresh; }
			set { employeesListRefresh = value; }
		}

		/// <summary>
		/// Gets or sets the WebBrowserUrl value.
		/// </summary>
		public virtual string WebBrowserUrl
		{
			get { return webBrowserUrl; }
			set { webBrowserUrl = value; }
		}

		/// <summary>
		/// Gets or sets the AutoGenerateTagNumber value.
		/// </summary>
		public virtual bool AutoGenerateTagNumber
		{
			get { return autoGenerateTagNumber; }
			set { autoGenerateTagNumber = value; }
		}

		/// <summary>
		/// Gets or sets the AutoGenerateRBillNumber value.
		/// </summary>
		public virtual bool AutoGenerateRBillNumber
		{
			get { return autoGenerateRBillNumber; }
			set { autoGenerateRBillNumber = value; }
		}

		/// <summary>
		/// Gets or sets the DefaultAgencyID value.
		/// </summary>
		public virtual int DefaultAgencyID
		{
			get { return defaultAgencyID; }
			set { defaultAgencyID = value; }
		}

		/// <summary>
		/// Gets or sets the ChitTicketComplete value.
		/// </summary>
		public virtual byte ChitTicketComplete
		{
			get { return chitTicketComplete; }
			set { chitTicketComplete = value; }
		}

		/// <summary>
		/// Gets or sets the ChitTicketIncludeBarcode value.
		/// </summary>
		public virtual bool ChitTicketIncludeBarcode
		{
			get { return chitTicketIncludeBarcode; }
			set { chitTicketIncludeBarcode = value; }
		}

		/// <summary>
		/// Gets or sets the CashOutPrintingOverride value.
		/// </summary>
		public virtual bool CashOutPrintingOverride
		{
			get { return cashOutPrintingOverride; }
			set { cashOutPrintingOverride = value; }
		}

		/// <summary>
		/// Gets or sets the WhiteBagID value.
		/// </summary>
		public virtual int WhiteBagID
		{
			get { return whiteBagID; }
			set { whiteBagID = value; }
		}

		/// <summary>
		/// Gets or sets the BlueBagID value.
		/// </summary>
		public virtual int BlueBagID
		{
			get { return blueBagID; }
			set { blueBagID = value; }
		}

		/// <summary>
		/// Gets or sets the OneWayBagID value.
		/// </summary>
		public virtual int OneWayBagID
		{
			get { return oneWayBagID; }
			set { oneWayBagID = value; }
		}

		/// <summary>
		/// Gets or sets the ABCRCPalletsID value.
		/// </summary>
		public virtual int ABCRCPalletsID
		{
			get { return aBCRCPalletsID; }
			set { aBCRCPalletsID = value; }
		}

		/// <summary>
		/// Gets or sets the CustomerScreenMonitor value.
		/// </summary>
		public virtual byte CustomerScreenMonitor
		{
			get { return customerScreenMonitor; }
			set { customerScreenMonitor = value; }
		}

		/// <summary>
		/// Gets or sets the CategoryButtonsPanelBgColor value.
		/// </summary>
		public virtual int CategoryButtonsPanelBgColor
		{
			get { return categoryButtonsPanelBgColor; }
			set { categoryButtonsPanelBgColor = value; }
		}

		/// <summary>
		/// Gets or sets the CategoryButtonsSnapToGrid value.
		/// </summary>
		public virtual bool CategoryButtonsSnapToGrid
		{
			get { return categoryButtonsSnapToGrid; }
			set { categoryButtonsSnapToGrid = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursFromTue value.
		/// </summary>
		public virtual DateTime BusinessHoursFromTue
		{
			get { return businessHoursFromTue; }
			set { businessHoursFromTue = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursToTue value.
		/// </summary>
		public virtual DateTime BusinessHoursToTue
		{
			get { return businessHoursToTue; }
			set { businessHoursToTue = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursFromWed value.
		/// </summary>
		public virtual DateTime BusinessHoursFromWed
		{
			get { return businessHoursFromWed; }
			set { businessHoursFromWed = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursToWed value.
		/// </summary>
		public virtual DateTime BusinessHoursToWed
		{
			get { return businessHoursToWed; }
			set { businessHoursToWed = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursFromThu value.
		/// </summary>
		public virtual DateTime BusinessHoursFromThu
		{
			get { return businessHoursFromThu; }
			set { businessHoursFromThu = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursToThu value.
		/// </summary>
		public virtual DateTime BusinessHoursToThu
		{
			get { return businessHoursToThu; }
			set { businessHoursToThu = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursFromFri value.
		/// </summary>
		public virtual DateTime BusinessHoursFromFri
		{
			get { return businessHoursFromFri; }
			set { businessHoursFromFri = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursToFri value.
		/// </summary>
		public virtual DateTime BusinessHoursToFri
		{
			get { return businessHoursToFri; }
			set { businessHoursToFri = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursFromSat value.
		/// </summary>
		public virtual DateTime BusinessHoursFromSat
		{
			get { return businessHoursFromSat; }
			set { businessHoursFromSat = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursToSat value.
		/// </summary>
		public virtual DateTime BusinessHoursToSat
		{
			get { return businessHoursToSat; }
			set { businessHoursToSat = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursFromSun value.
		/// </summary>
		public virtual DateTime BusinessHoursFromSun
		{
			get { return businessHoursFromSun; }
			set { businessHoursFromSun = value; }
		}

		/// <summary>
		/// Gets or sets the BusinessHoursToSun value.
		/// </summary>
		public virtual DateTime BusinessHoursToSun
		{
			get { return businessHoursToSun; }
			set { businessHoursToSun = value; }
		}

		/// <summary>
		/// Gets or sets the ReturnsMaxQuantity value.
		/// </summary>
		public virtual int ReturnsMaxQuantity
		{
			get { return returnsMaxQuantity; }
			set { returnsMaxQuantity = value; }
		}

		/// <summary>
		/// Gets or sets the WebBrowserUpdateHistoryUrl value.
		/// </summary>
		public virtual string WebBrowserUpdateHistoryUrl
		{
			get { return webBrowserUpdateHistoryUrl; }
			set { webBrowserUpdateHistoryUrl = value; }
		}

		/// <summary>
		/// Gets or sets the CashierMaxAmount value.
		/// </summary>
		public virtual decimal CashierMaxAmount
		{
			get { return cashierMaxAmount; }
			set { cashierMaxAmount = value; }
		}

		/// <summary>
		/// Gets or sets the ComputerRole value.
		/// </summary>
		public virtual byte ComputerRole
		{
			get { return computerRole; }
			set { computerRole = value; }
		}

		/// <summary>
		/// Gets or sets the SqlServerDate value.
		/// </summary>
		public virtual bool SqlServerDate
		{
			get { return sqlServerDate; }
			set { sqlServerDate = value; }
		}

		/// <summary>
		/// Gets or sets the VendorID value.
		/// </summary>
		public virtual int VendorID
		{
			get { return vendorID; }
			set { vendorID = value; }
		}

		/// <summary>
		/// Gets or sets the DefaultPlantID value.
		/// </summary>
		public virtual int DefaultPlantID
		{
			get { return defaultPlantID; }
			set { defaultPlantID = value; }
		}

		/// <summary>
		/// Gets or sets the DefaultCarrierID value.
		/// </summary>
		public virtual int DefaultCarrierID
		{
			get { return defaultCarrierID; }
			set { defaultCarrierID = value; }
		}

		/// <summary>
		/// Gets or sets the ABCRCUserName value.
		/// </summary>
		public virtual string ABCRCUserName
		{
			get { return aBCRCUserName; }
			set { aBCRCUserName = value; }
		}

		/// <summary>
		/// Gets or sets the ABCRCPassword value.
		/// </summary>
		public virtual string ABCRCPassword
		{
			get { return aBCRCPassword; }
			set { aBCRCPassword = value; }
		}

		/// <summary>
		/// Gets or sets the ReceiptAmountBarcode value.
		/// </summary>
		public virtual bool ReceiptAmountBarcode
		{
			get { return receiptAmountBarcode; }
			set { receiptAmountBarcode = value; }
		}

		/// <summary>
		/// Gets or sets the IncludeSecurityCode value.
		/// </summary>
		public virtual bool IncludeSecurityCode
		{
			get { return includeSecurityCode; }
			set { includeSecurityCode = value; }
		}

		/// <summary>
		/// Gets or sets the RBillNumberBarcode value.
		/// </summary>
		public virtual bool RBillNumberBarcode
		{
			get { return rBillNumberBarcode; }
			set { rBillNumberBarcode = value; }
		}

		/// <summary>
		/// Gets or sets the SacCashTrayID value.
		/// </summary>
		public virtual int SacCashTrayID
		{
			get { return sacCashTrayID; }
			set { sacCashTrayID = value; }
		}

		#endregion
	}
}
