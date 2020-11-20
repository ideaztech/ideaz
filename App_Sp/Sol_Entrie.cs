using System;

namespace Solum
{
	public class Sol_Entrie
	{
		#region Fields

		private int entryID;
		private string entryType;
		private Guid userID;
		private string userName;
		private DateTime date;
		private int cashTrayID;
		private int expenseTypeID;
		private decimal amount;
		private decimal discrepancyAmount;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Entrie class.
		/// </summary>
		public Sol_Entrie()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Entrie class.
		/// </summary>
		public Sol_Entrie(string entryType, Guid userID, string userName, DateTime date, int cashTrayID, int expenseTypeID, decimal amount, decimal discrepancyAmount)
		{
			this.entryType = entryType;
			this.userID = userID;
			this.userName = userName;
			this.date = date;
			this.cashTrayID = cashTrayID;
			this.expenseTypeID = expenseTypeID;
			this.amount = amount;
			this.discrepancyAmount = discrepancyAmount;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Entrie class.
		/// </summary>
		public Sol_Entrie(int entryID, string entryType, Guid userID, string userName, DateTime date, int cashTrayID, int expenseTypeID, decimal amount, decimal discrepancyAmount)
		{
			this.entryID = entryID;
			this.entryType = entryType;
			this.userID = userID;
			this.userName = userName;
			this.date = date;
			this.cashTrayID = cashTrayID;
			this.expenseTypeID = expenseTypeID;
			this.amount = amount;
			this.discrepancyAmount = discrepancyAmount;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the EntryID value.
		/// </summary>
		public virtual int EntryID
		{
			get { return entryID; }
			set { entryID = value; }
		}

		/// <summary>
		/// Gets or sets the EntryType value.
		/// </summary>
		public virtual string EntryType
		{
			get { return entryType; }
			set { entryType = value; }
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
		/// Gets or sets the ExpenseTypeID value.
		/// </summary>
		public virtual int ExpenseTypeID
		{
			get { return expenseTypeID; }
			set { expenseTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public virtual decimal Amount
		{
			get { return amount; }
			set { amount = value; }
		}

		/// <summary>
		/// Gets or sets the DiscrepancyAmount value.
		/// </summary>
		public virtual decimal DiscrepancyAmount
		{
			get { return discrepancyAmount; }
			set { discrepancyAmount = value; }
		}

		#endregion
	}
}
