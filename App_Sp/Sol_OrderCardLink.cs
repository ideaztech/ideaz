using System;

namespace Solum
{
	public class Sol_OrderCardLink
	{
		#region Fields

		private string cardNumber;
		private int orderID;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_OrderCardLink class.
		/// </summary>
		public Sol_OrderCardLink()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_OrderCardLink class.
		/// </summary>
		public Sol_OrderCardLink(string cardNumber, int orderID)
		{
			this.cardNumber = cardNumber;
			this.orderID = orderID;
		}

		#endregion

		#region Properties
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

		#endregion
	}
}
