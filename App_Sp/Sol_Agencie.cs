using System;

namespace Solum
{
	public class Sol_Agencie
	{
		#region Fields

		private int agencyID;
		private string name;
		private string description;
		private string address1;
		private string address2;
		private string city;
		private string province;
		private string country;
		private string postalCode;
		private string vendorID;
		private bool autoGenerateTagNumber;
		private bool autoGenerateRBillNumber;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Agencie class.
		/// </summary>
		public Sol_Agencie()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Agencie class.
		/// </summary>
		public Sol_Agencie(string name, string description, string address1, string address2, string city, string province, string country, string postalCode, string vendorID, bool autoGenerateTagNumber, bool autoGenerateRBillNumber)
		{
			this.name = name;
			this.description = description;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
			this.vendorID = vendorID;
			this.autoGenerateTagNumber = autoGenerateTagNumber;
			this.autoGenerateRBillNumber = autoGenerateRBillNumber;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Agencie class.
		/// </summary>
		public Sol_Agencie(int agencyID, string name, string description, string address1, string address2, string city, string province, string country, string postalCode, string vendorID, bool autoGenerateTagNumber, bool autoGenerateRBillNumber)
		{
			this.agencyID = agencyID;
			this.name = name;
			this.description = description;
			this.address1 = address1;
			this.address2 = address2;
			this.city = city;
			this.province = province;
			this.country = country;
			this.postalCode = postalCode;
			this.vendorID = vendorID;
			this.autoGenerateTagNumber = autoGenerateTagNumber;
			this.autoGenerateRBillNumber = autoGenerateRBillNumber;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the AgencyID value.
		/// </summary>
		public virtual int AgencyID
		{
			get { return agencyID; }
			set { agencyID = value; }
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
		/// Gets or sets the Description value.
		/// </summary>
		public virtual string Description
		{
			get { return description; }
			set { description = value; }
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
		/// Gets or sets the VendorID value.
		/// </summary>
		public virtual string VendorID
		{
			get { return vendorID; }
			set { vendorID = value; }
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

		#endregion
	}
}
