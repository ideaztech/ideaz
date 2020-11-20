using System;

namespace Solum
{
	public class Qds_Drop
	{
		#region Fields

		private int dropID;
		private int customerID;
		private int numberOfBags;
		private int paymentMethodID;
		private string depotID;
		private int orderID;
		private string orderType;
		//private bool isNew;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Qds_Drop class.
		/// </summary>
		public Qds_Drop()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Qds_Drop class.
		/// </summary>
		public Qds_Drop(int customerID, int numberOfBags, int paymentMethodID, string depotID, int orderID, string orderType)//, bool isNew
		{
			this.customerID = customerID;
			this.numberOfBags = numberOfBags;
			this.paymentMethodID = paymentMethodID;
			this.depotID = depotID;
			this.orderID = orderID;
			this.orderType = orderType;
			//this.isNew = isNew;
		}

		/// <summary>
		/// Initializes a new instance of the Qds_Drop class.
		/// </summary>
		public Qds_Drop(int dropID, int customerID, int numberOfBags, int paymentMethodID, string depotID, int orderID, string orderType)//, bool isNew
		{
			this.dropID = dropID;
			this.customerID = customerID;
			this.numberOfBags = numberOfBags;
			this.paymentMethodID = paymentMethodID;
			this.depotID = depotID;
			this.orderID = orderID;
			this.orderType = orderType;
			//this.isNew = isNew;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the DropID value.
		/// </summary>
		public virtual int DropID
		{
			get { return dropID; }
			set { dropID = value; }
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
		/// Gets or sets the NumberOfBags value.
		/// </summary>
		public virtual int NumberOfBags
		{
			get { return numberOfBags; }
			set { numberOfBags = value; }
		}

		/// <summary>
		/// Gets or sets the PaymentMethodID value.
		/// </summary>
		public virtual int PaymentMethodID
		{
			get { return paymentMethodID; }
			set { paymentMethodID = value; }
		}

		/// <summary>
		/// Gets or sets the DepotID value.
		/// </summary>
		public virtual string DepotID
		{
			get { return depotID; }
			set { depotID = value; }
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
		/// Gets or sets the OrderType value.
		/// </summary>
		public virtual string OrderType
		{
			get { return orderType; }
			set { orderType = value; }
		}

		/// <summary>
		/// Gets or sets the IsNew value.
		/// </summary>
		//public virtual bool IsNew
		//{
		//	get { return isNew; }
		//	set { isNew = value; }
		//}

		#endregion
	}
}
