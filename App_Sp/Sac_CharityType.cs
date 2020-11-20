using System;

namespace Solum
{
	public class Sac_CharityType
	{
		#region Fields

		private int charityTypeID;
		private string charityType;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_CharityType class.
		/// </summary>
		public Sac_CharityType()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_CharityType class.
		/// </summary>
		public Sac_CharityType(int charityTypeID, string charityType)
		{
			this.charityTypeID = charityTypeID;
			this.charityType = charityType;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CharityTypeID value.
		/// </summary>
		public virtual int CharityTypeID
		{
			get { return charityTypeID; }
			set { charityTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the CharityType value.
		/// </summary>
		public virtual string CharityType
		{
			get { return charityType; }
			set { charityType = value; }
		}

		#endregion
	}
}
