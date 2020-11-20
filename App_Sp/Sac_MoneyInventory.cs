using System;

namespace Solum
{
	public class Sac_MoneyInventory
	{
		#region Fields

		private string clientID;
		private int moneyID;
		private int billDispenserID;
		private string address;
		private int inventory;
		private int maxNumBills;
		private int fullQuantity;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_MoneyInventory class.
		/// </summary>
		public Sac_MoneyInventory()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_MoneyInventory class.
		/// </summary>
		public Sac_MoneyInventory(string clientID, int moneyID, int billDispenserID, string address, int inventory, int maxNumBills, int fullQuantity)
		{
			this.clientID = clientID;
			this.moneyID = moneyID;
			this.billDispenserID = billDispenserID;
			this.address = address;
			this.inventory = inventory;
			this.maxNumBills = maxNumBills;
			this.fullQuantity = fullQuantity;
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
		/// Gets or sets the MoneyID value.
		/// </summary>
		public virtual int MoneyID
		{
			get { return moneyID; }
			set { moneyID = value; }
		}

		/// <summary>
		/// Gets or sets the BillDispenserID value.
		/// </summary>
		public virtual int BillDispenserID
		{
			get { return billDispenserID; }
			set { billDispenserID = value; }
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
		/// Gets or sets the Inventory value.
		/// </summary>
		public virtual int Inventory
		{
			get { return inventory; }
			set { inventory = value; }
		}

		/// <summary>
		/// Gets or sets the MaxNumBills value.
		/// </summary>
		public virtual int MaxNumBills
		{
			get { return maxNumBills; }
			set { maxNumBills = value; }
		}

		/// <summary>
		/// Gets or sets the FullQuantity value.
		/// </summary>
		public virtual int FullQuantity
		{
			get { return fullQuantity; }
			set { fullQuantity = value; }
		}

		#endregion
	}
}
