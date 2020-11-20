using System;

namespace Solum
{
	public class Sac_Charity
	{
		#region Fields

		private int charityID;
		private int customerID;
		private string shortName;
		private string charityDescription;
		private int charityTypeID;
		private string registrationNumber;
		private bool isActive;
		private byte buttonPosition;
		private byte[] logo;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_Charity class.
		/// </summary>
		public Sac_Charity()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_Charity class.
		/// </summary>
		public Sac_Charity(int customerID, string shortName, string charityDescription, int charityTypeID, string registrationNumber, bool isActive, byte buttonPosition, byte[] logo)
		{
			this.customerID = customerID;
			this.shortName = shortName;
			this.charityDescription = charityDescription;
			this.charityTypeID = charityTypeID;
			this.registrationNumber = registrationNumber;
			this.isActive = isActive;
			this.buttonPosition = buttonPosition;
			this.logo = logo;
		}

		/// <summary>
		/// Initializes a new instance of the Sac_Charity class.
		/// </summary>
		public Sac_Charity(int charityID, int customerID, string shortName, string charityDescription, int charityTypeID, string registrationNumber, bool isActive, byte buttonPosition, byte[] logo)
		{
			this.charityID = charityID;
			this.customerID = customerID;
			this.shortName = shortName;
			this.charityDescription = charityDescription;
			this.charityTypeID = charityTypeID;
			this.registrationNumber = registrationNumber;
			this.isActive = isActive;
			this.buttonPosition = buttonPosition;
			this.logo = logo;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CharityID value.
		/// </summary>
		public virtual int CharityID
		{
			get { return charityID; }
			set { charityID = value; }
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
		/// Gets or sets the ShortName value.
		/// </summary>
		public virtual string ShortName
		{
			get { return shortName; }
			set { shortName = value; }
		}

		/// <summary>
		/// Gets or sets the CharityDescription value.
		/// </summary>
		public virtual string CharityDescription
		{
			get { return charityDescription; }
			set { charityDescription = value; }
		}

		/// <summary>
		/// Gets or sets the CharityTypeID value.
		/// </summary>
		public virtual int CharityTypeID
		{
			get { return charityTypeID; }
			set { charityTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the RegistrationNumber value.
		/// </summary>
		public virtual string RegistrationNumber
		{
			get { return registrationNumber; }
			set { registrationNumber = value; }
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
		/// Gets or sets the ButtonPosition value.
		/// </summary>
		public virtual byte ButtonPosition
		{
			get { return buttonPosition; }
			set { buttonPosition = value; }
		}

		/// <summary>
		/// Gets or sets the Logo value.
		/// </summary>
		public virtual byte[] Logo
		{
			get { return logo; }
			set { logo = value; }
		}

		#endregion
	}
}
