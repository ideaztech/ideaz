using System;

namespace Solum
{
	public class Sol_Payment
	{
		#region Fields

		private int paymentID;
		private float paymentAmount;
		private DateTime date;
		private int userID;
		private string userName;
		private int customerID;
		private string chequeNumber;
		private string name;
		private string address1;
		private string address2;
		private string city;
		private string province;
		private string country;
		private string postalCode;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Payment class.
		/// </summary>
		public Sol_Payment()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Payment class.
		/// </summary>
		public Sol_Payment(float paymentAmount, DateTime date, int userID, string userName, int customerID, string chequeNumber, string name, string address1, string address2, string city, string province, string country, string postalCode)
		{
			this.paymentAmount = paymentAmount;
			this.date = date;
			this.userID = userID;
			this.userName = userName;
			this.customerID = customerID;
			this.chequeNumber = chequeNumber;
			this.name = name;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Payment class.
		/// </summary>
		public Sol_Payment(int paymentID, float paymentAmount, DateTime date, int userID, string userName, int customerID, string chequeNumber, string name, string address1, string address2, string city, string province, string country, string postalCode)
		{
			this.paymentID = paymentID;
			this.paymentAmount = paymentAmount;
			this.date = date;
			this.userID = userID;
			this.userName = userName;
			this.customerID = customerID;
			this.chequeNumber = chequeNumber;
			this.name = name;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the PaymentID value.
		/// </summary>
		public virtual int PaymentID
		{
			get { return paymentID; }
			set { paymentID = value; }
		}

		/// <summary>
		/// Gets or sets the PaymentAmount value.
		/// </summary>
		public virtual float PaymentAmount
		{
			get { return paymentAmount; }
			set { paymentAmount = value; }
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
		/// Gets or sets the UserID value.
		/// </summary>
		public virtual int UserID
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
		/// Gets or sets the CustomerID value.
		/// </summary>
		public virtual int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
		}

		/// <summary>
		/// Gets or sets the ChequeNumber value.
		/// </summary>
		public virtual string ChequeNumber
		{
			get { return chequeNumber; }
			set { chequeNumber = value; }
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

		#endregion
	}
}
