using System;

namespace Solum
{
	public class Sol_OrderCardLog
	{
		#region Fields

		private int logID;
		private string cardNumber;
		private int orderID;
		private DateTime dateAdded;
		private DateTime datePaid;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_OrderCardLog class.
		/// </summary>
		public Sol_OrderCardLog()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_OrderCardLog class.
		/// </summary>
		public Sol_OrderCardLog(string cardNumber, int orderID, DateTime dateAdded, DateTime datePaid)
		{
			this.cardNumber = cardNumber;
			this.orderID = orderID;
			this.dateAdded = dateAdded;
			this.datePaid = datePaid;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_OrderCardLog class.
		/// </summary>
		public Sol_OrderCardLog(int logID, string cardNumber, int orderID, DateTime dateAdded, DateTime datePaid)
		{
			this.logID = logID;
			this.cardNumber = cardNumber;
			this.orderID = orderID;
			this.dateAdded = dateAdded;
			this.datePaid = datePaid;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the LogID value.
		/// </summary>
		public virtual int LogID
		{
			get { return logID; }
			set { logID = value; }
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
		/// Gets or sets the OrderID value.
		/// </summary>
		public virtual int OrderID
		{
			get { return orderID; }
			set { orderID = value; }
		}

		/// <summary>
		/// Gets or sets the DateAdded value.
		/// </summary>
		public virtual DateTime DateAdded
		{
			get { return dateAdded; }
			set { dateAdded = value; }
		}

		/// <summary>
		/// Gets or sets the DatePaid value.
		/// </summary>
		public virtual DateTime DatePaid
		{
			get { return datePaid; }
			set { datePaid = value; }
		}

		#endregion
	}
}
