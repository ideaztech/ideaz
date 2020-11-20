using System;

namespace Solum
{
	public class Sac_ClientName
	{
		#region Fields

		private string clientID;
		private int cashTrayID;
		private decimal coinAmountInventory;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_ClientName class.
		/// </summary>
		public Sac_ClientName()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_ClientName class.
		/// </summary>
		public Sac_ClientName(string clientID, int cashTrayID, decimal coinAmountInventory)
		{
			this.clientID = clientID;
			this.cashTrayID = cashTrayID;
			this.coinAmountInventory = coinAmountInventory;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ClientID value.
		/// </summary>
		public virtual string ClientID
		{
			get { return clientID; }
			set { clientID = value; }
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
		/// Gets or sets the CoinAmountInventory value.
		/// </summary>
		public virtual decimal CoinAmountInventory
		{
			get { return coinAmountInventory; }
			set { coinAmountInventory = value; }
		}

		#endregion
	}
}
