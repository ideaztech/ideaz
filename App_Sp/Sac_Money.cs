using System;

namespace Solum
{
	public class Sac_Money
	{
		#region Fields

		private int moneyID;
		private string name;
		private byte typeID;
		private decimal dollarValue;
		private string countryCode;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_Money class.
		/// </summary>
		public Sac_Money()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_Money class.
		/// </summary>
		public Sac_Money(string name, byte typeID, decimal dollarValue, string countryCode)
		{
			this.name = name;
			this.typeID = typeID;
			this.dollarValue = dollarValue;
			this.countryCode = countryCode;
		}

		/// <summary>
		/// Initializes a new instance of the Sac_Money class.
		/// </summary>
		public Sac_Money(int moneyID, string name, byte typeID, decimal dollarValue, string countryCode)
		{
			this.moneyID = moneyID;
			this.name = name;
			this.typeID = typeID;
			this.dollarValue = dollarValue;
			this.countryCode = countryCode;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the MoneyID value.
		/// </summary>
		public virtual int MoneyID
		{
			get { return moneyID; }
			set { moneyID = value; }
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
		/// Gets or sets the TypeID value.
		/// </summary>
		public virtual byte TypeID
		{
			get { return typeID; }
			set { typeID = value; }
		}

		/// <summary>
		/// Gets or sets the DollarValue value.
		/// </summary>
		public virtual decimal DollarValue
		{
			get { return dollarValue; }
			set { dollarValue = value; }
		}

		/// <summary>
		/// Gets or sets the CountryCode value.
		/// </summary>
		public virtual string CountryCode
		{
			get { return countryCode; }
			set { countryCode = value; }
		}

		#endregion
	}
}
