using System;

namespace Solum
{
	public class Sol_Order
	{
		#region Fields

		private int orderID;
		private string orderType;
		private int workStationID;
		private string computerName;
		private Guid userID;
		private string userName;
		private DateTime date;
		private int cashTrayID;
		private int customerID;
		private string name;
		private string address1;
		private string address2;
		private string city;
		private string province;
		private string country;
		private string postalCode;
		private decimal totalAmount;
		private DateTime dateClosed;
		private DateTime datePaid;
		private int feeID;
		private decimal feeAmount;
		private decimal tax1Amount;
		private decimal tax2Amount;
		private string status;
		private string reference;
		private byte paymentTypeID;
		private string securityCode;
		private string comments;
		//private bool isNew;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Order class.
		/// </summary>
		public Sol_Order()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Order class.
		/// </summary>
		public Sol_Order(string orderType, int workStationID, string computerName, Guid userID, string userName, DateTime date, int cashTrayID, int customerID, string name, string address1, string address2, string city, string province, string country, string postalCode, decimal totalAmount, DateTime dateClosed, DateTime datePaid, int feeID, decimal feeAmount, decimal tax1Amount, decimal tax2Amount, string status, string reference, byte paymentTypeID, string securityCode, string comments)//, bool isNew
		{
			this.orderType = orderType;
			this.workStationID = workStationID;
			this.computerName = computerName;
			this.userID = userID;
			this.userName = userName;
			this.date = date;
			this.cashTrayID = cashTrayID;
			this.customerID = customerID;
			this.name = name;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
			this.totalAmount = totalAmount;
			this.dateClosed = dateClosed;
			this.datePaid = datePaid;
			this.feeID = feeID;
			this.feeAmount = feeAmount;
			this.tax1Amount = tax1Amount;
			this.tax2Amount = tax2Amount;
			this.status = status;
			this.reference = reference;
			this.paymentTypeID = paymentTypeID;
			this.securityCode = securityCode;
			this.comments = comments;
			//this.isNew = isNew;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Order class.
		/// </summary>
		public Sol_Order(int orderID, string orderType, int workStationID, string computerName, Guid userID, string userName, DateTime date, int cashTrayID, int customerID, string name, string address1, string address2, string city, string province, string country, string postalCode, decimal totalAmount, DateTime dateClosed, DateTime datePaid, int feeID, decimal feeAmount, decimal tax1Amount, decimal tax2Amount, string status, string reference, byte paymentTypeID, string securityCode, string comments)//, bool isNew
		{
			this.orderID = orderID;
			this.orderType = orderType;
			this.workStationID = workStationID;
			this.computerName = computerName;
			this.userID = userID;
			this.userName = userName;
			this.date = date;
			this.cashTrayID = cashTrayID;
			this.customerID = customerID;
			this.name = name;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
			this.totalAmount = totalAmount;
			this.dateClosed = dateClosed;
			this.datePaid = datePaid;
			this.feeID = feeID;
			this.feeAmount = feeAmount;
			this.tax1Amount = tax1Amount;
			this.tax2Amount = tax2Amount;
			this.status = status;
			this.reference = reference;
			this.paymentTypeID = paymentTypeID;
			this.securityCode = securityCode;
			this.comments = comments;
			//this.isNew = isNew;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the OrderID value.
		/// </summary>
		public virtual int OrderID
		{
			get { return orderID; }
			set { orderID = value; }
		}

		/// <summary>
		/// Gets or sets the OrderType value.
		/// </summary>
		public virtual string OrderType
		{
			get { return orderType; }
			set { orderType = value; }
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
		/// Gets or sets the ComputerName value.
		/// </summary>
		public virtual string ComputerName
		{
			get { return computerName; }
			set { computerName = value; }
		}

		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public virtual Guid UserID
		{
			get { return userID; }
			set { userID = value; }
		}

		/// <summary>
		/// Gets or sets the UserName value.
		/// </summary>
		public virtual string UserName
		{
			get { return userName; }
			set { userName = value; }
		}

		/// <summary>
		/// Gets or sets the Date value.
		/// </summary>
		public virtual DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		/// <summary>
		/// Gets or sets the CashTrayID value.
		/// </summary>
		public virtual int CashTrayID
		{
			get { return cashTrayID; }
			set { cashTrayID = value; }
		}

		/// <summary>
		/// Gets or sets the CustomerID value.
		/// </summary>
		public virtual int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
		}

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Gets or sets the Address1 value.
		/// </summary>
		public virtual string Address1
		{
			get { return address1; }
			set { address1 = value; }
		}

		/// <summary>
		/// Gets or sets the Address2 value.
		/// </summary>
		public virtual string Address2
		{
			get { return address2; }
			set { address2 = value; }
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
		/// Gets or sets the Province value.
		/// </summary>
		public virtual string Province
		{
			get { return province; }
			set { province = value; }
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
		/// Gets or sets the PostalCode value.
		/// </summary>
		public virtual string PostalCode
		{
			get { return postalCode; }
			set { postalCode = value; }
		}

		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public virtual decimal TotalAmount
		{
			get { return totalAmount; }
			set { totalAmount = value; }
		}

		/// <summary>
		/// Gets or sets the DateClosed value.
		/// </summary>
		public virtual DateTime DateClosed
		{
			get { return dateClosed; }
			set { dateClosed = value; }
		}

		/// <summary>
		/// Gets or sets the DatePaid value.
		/// </summary>
		public virtual DateTime DatePaid
		{
			get { return datePaid; }
			set { datePaid = value; }
		}

		/// <summary>
		/// Gets or sets the FeeID value.
		/// </summary>
		public virtual int FeeID
		{
			get { return feeID; }
			set { feeID = value; }
		}

		/// <summary>
		/// Gets or sets the FeeAmount value.
		/// </summary>
		public virtual decimal FeeAmount
		{
			get { return feeAmount; }
			set { feeAmount = value; }
		}

		/// <summary>
		/// Gets or sets the Tax1Amount value.
		/// </summary>
		public virtual decimal Tax1Amount
		{
			get { return tax1Amount; }
			set { tax1Amount = value; }
		}

		/// <summary>
		/// Gets or sets the Tax2Amount value.
		/// </summary>
		public virtual decimal Tax2Amount
		{
			get { return tax2Amount; }
			set { tax2Amount = value; }
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
		/// Gets or sets the Reference value.
		/// </summary>
		public virtual string Reference
		{
			get { return reference; }
			set { reference = value; }
		}

		/// <summary>
		/// Gets or sets the PaymentTypeID value.
		/// </summary>
		public virtual byte PaymentTypeID
		{
			get { return paymentTypeID; }
			set { paymentTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the SecurityCode value.
		/// </summary>
		public virtual string SecurityCode
		{
			get { return securityCode; }
			set { securityCode = value; }
		}

		/// <summary>
		/// Gets or sets the Comments value.
		/// </summary>
		public virtual string Comments
		{
			get { return comments; }
			set { comments = value; }
		}

		/// <summary>
		/// Gets or sets the IsNew value.
		/// </summary>
		//public virtual bool IsNew
		//{
		//	get { return isNew; }
		//	set { isNew = value; }
		//}

		#endregion
	}
}
