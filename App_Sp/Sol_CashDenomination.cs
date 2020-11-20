using System;

namespace Solum
{
	public class Sol_CashDenomination
	{
		#region Fields

		private int cashID;
		private byte cashType;
		private decimal cashValue;
		private string description;
		private short orderValue;
		private decimal cashItemValue;
		private int quantity;
		private int moneyID;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_CashDenomination class.
		/// </summary>
		public Sol_CashDenomination()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_CashDenomination class.
		/// </summary>
		public Sol_CashDenomination(byte cashType, decimal cashValue, string description, short orderValue, decimal cashItemValue, int quantity, int moneyID)
		{
			this.cashType = cashType;
			this.cashValue = cashValue;
			this.description = description;
			this.orderValue = orderValue;
			this.cashItemValue = cashItemValue;
			this.quantity = quantity;
			this.moneyID = moneyID;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_CashDenomination class.
		/// </summary>
		public Sol_CashDenomination(int cashID, byte cashType, decimal cashValue, string description, short orderValue, decimal cashItemValue, int quantity, int moneyID)
		{
			this.cashID = cashID;
			this.cashType = cashType;
			this.cashValue = cashValue;
			this.description = description;
			this.orderValue = orderValue;
			this.cashItemValue = cashItemValue;
			this.quantity = quantity;
			this.moneyID = moneyID;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CashID value.
		/// </summary>
		public virtual int CashID
		{
			get { return cashID; }
			set { cashID = value; }
		}

		/// <summary>
		/// Gets or sets the CashType value.
		/// </summary>
		public virtual byte CashType
		{
			get { return cashType; }
			set { cashType = value; }
		}

		/// <summary>
		/// Gets or sets the CashValue value.
		/// </summary>
		public virtual decimal CashValue
		{
			get { return cashValue; }
			set { cashValue = value; }
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
		/// Gets or sets the OrderValue value.
		/// </summary>
		public virtual short OrderValue
		{
			get { return orderValue; }
			set { orderValue = value; }
		}

		/// <summary>
		/// Gets or sets the CashItemValue value.
		/// </summary>
		public virtual decimal CashItemValue
		{
			get { return cashItemValue; }
			set { cashItemValue = value; }
		}

		/// <summary>
		/// Gets or sets the Quantity value.
		/// </summary>
		public virtual int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		/// <summary>
		/// Gets or sets the MoneyID value.
		/// </summary>
		public virtual int MoneyID
		{
			get { return moneyID; }
			set { moneyID = value; }
		}

		#endregion
	}
}
