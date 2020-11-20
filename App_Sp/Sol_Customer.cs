using System;

namespace Solum
{
	public class Sol_Customer
	{
		#region Fields

		private int customerID;
		private string customerCode;
		private string name;
		private string contact;
		private string address1;
		private string address2;
		private string city;
		private string province;
		private string country;
		private string postalCode;
		private string email;
		private string loweredEmail;
		private bool isActive;
		private string phoneNumber;
		private string notes;
		private string password;
		private string depotID;
		private string cardNumber;
		private int cardTypeID;
		private bool solumCustomer;
		private bool quickDropCustomer;
		//private bool isNew;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Customer class.
		/// </summary>
		public Sol_Customer()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Customer class.
		/// </summary>
		public Sol_Customer(string customerCode, string name, string contact, string address1, string address2, string city, string province, string country, string postalCode, string email, string loweredEmail, bool isActive, string phoneNumber, string notes, string password, string depotID, string cardNumber, int cardTypeID, bool solumCustomer, bool quickDropCustomer)//, bool isNew
		{
			this.customerCode = customerCode;
			this.name = name;
			this.contact = contact;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
			this.email = email;
			this.loweredEmail = loweredEmail;
			this.isActive = isActive;
			this.phoneNumber = phoneNumber;
			this.notes = notes;
			this.password = password;
			this.depotID = depotID;
			this.cardNumber = cardNumber;
			this.cardTypeID = cardTypeID;
			this.solumCustomer = solumCustomer;
			this.quickDropCustomer = quickDropCustomer;
			//this.isNew = isNew;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Customer class.
		/// </summary>
		public Sol_Customer(int customerID, string customerCode, string name, string contact, string address1, string address2, string city, string province, string country, string postalCode, string email, string loweredEmail, bool isActive, string phoneNumber, string notes, string password, string depotID, string cardNumber, int cardTypeID, bool solumCustomer, bool quickDropCustomer)//, bool isNew
		{
			this.customerID = customerID;
			this.customerCode = customerCode;
			this.name = name;
			this.contact = contact;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
			this.email = email;
			this.loweredEmail = loweredEmail;
			this.isActive = isActive;
			this.phoneNumber = phoneNumber;
			this.notes = notes;
			this.password = password;
			this.depotID = depotID;
			this.cardNumber = cardNumber;
			this.cardTypeID = cardTypeID;
			this.solumCustomer = solumCustomer;
			this.quickDropCustomer = quickDropCustomer;
			//this.isNew = isNew;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CustomerID value.
		/// </summary>
		public virtual int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
		}

		/// <summary>
		/// Gets or sets the CustomerCode value.
		/// </summary>
		public virtual string CustomerCode
		{
			get { return customerCode; }
			set { customerCode = value; }
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
		/// Gets or sets the Contact value.
		/// </summary>
		public virtual string Contact
		{
			get { return contact; }
			set { contact = value; }
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
		/// Gets or sets the Email value.
		/// </summary>
		public virtual string Email
		{
			get { return email; }
			set { email = value; }
		}

		/// <summary>
		/// Gets or sets the LoweredEmail value.
		/// </summary>
		public virtual string LoweredEmail
		{
			get { return loweredEmail; }
			set { loweredEmail = value; }
		}

		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public virtual bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
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
		/// Gets or sets the Notes value.
		/// </summary>
		public virtual string Notes
		{
			get { return notes; }
			set { notes = value; }
		}

		/// <summary>
		/// Gets or sets the Password value.
		/// </summary>
		public virtual string Password
		{
			get { return password; }
			set { password = value; }
		}

		/// <summary>
		/// Gets or sets the DepotID value.
		/// </summary>
		public virtual string DepotID
		{
			get { return depotID; }
			set { depotID = value; }
		}

		/// <summary>
		/// Gets or sets the CardNumber value.
		/// </summary>
		public virtual string CardNumber
		{
			get { return cardNumber; }
			set { cardNumber = value; }
		}

		/// <summary>
		/// Gets or sets the CardTypeID value.
		/// </summary>
		public virtual int CardTypeID
		{
			get { return cardTypeID; }
			set { cardTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the SolumCustomer value.
		/// </summary>
		public virtual bool SolumCustomer
		{
			get { return solumCustomer; }
			set { solumCustomer = value; }
		}

		/// <summary>
		/// Gets or sets the QuickDropCustomer value.
		/// </summary>
		public virtual bool QuickDropCustomer
		{
			get { return quickDropCustomer; }
			set { quickDropCustomer = value; }
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
