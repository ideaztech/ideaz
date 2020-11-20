using System;

namespace Solum
{
	public class Sol_ExpenseType
	{
		#region Fields

		private int expenseTypeID;
		private string description;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_ExpenseType class.
		/// </summary>
		public Sol_ExpenseType()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_ExpenseType class.
		/// </summary>
		public Sol_ExpenseType(string description)
		{
			this.description = description;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_ExpenseType class.
		/// </summary>
		public Sol_ExpenseType(int expenseTypeID, string description)
		{
			this.expenseTypeID = expenseTypeID;
			this.description = description;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ExpenseTypeID value.
		/// </summary>
		public virtual int ExpenseTypeID
		{
			get { return expenseTypeID; }
			set { expenseTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public virtual string Description
		{
			get { return description; }
			set { description = value; }
		}

		#endregion
	}
}
