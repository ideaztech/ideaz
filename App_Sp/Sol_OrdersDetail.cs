using System;

namespace Solum
{
	public class Sol_OrdersDetail
	{
		#region Fields

		private int detailID;
		private int orderID;
		private string orderType;
		private DateTime date;
		private int categoryID;
		private int productID;
		private string description;
		private int quantity;
		private decimal price;
		private decimal amount;
		private string status;
		private int categoryButtonID;
		private int bagID;
		//private bool isNew;
		private int conveyorID;
		private int stageID;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_OrdersDetail class.
		/// </summary>
		public Sol_OrdersDetail()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_OrdersDetail class.
		/// </summary>
		public Sol_OrdersDetail(int orderID, string orderType, DateTime date, int categoryID, int productID, string description, int quantity, decimal price, decimal amount, string status, int categoryButtonID, int bagID, bool isNew, int conveyorID, int stageID)
		{
			this.orderID = orderID;
			this.orderType = orderType;
			this.date = date;
			this.categoryID = categoryID;
			this.productID = productID;
			this.description = description;
			this.quantity = quantity;
			this.price = price;
			this.amount = amount;
			this.status = status;
			this.categoryButtonID = categoryButtonID;
			this.bagID = bagID;
			//this.isNew = isNew;
			this.conveyorID = conveyorID;
			this.stageID = stageID;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_OrdersDetail class.
		/// </summary>
		public Sol_OrdersDetail(int detailID, int orderID, string orderType, DateTime date, int categoryID, int productID, string description, int quantity, decimal price, decimal amount, string status, int categoryButtonID, int bagID, bool isNew, int conveyorID, int stageID)
		{
			this.detailID = detailID;
			this.orderID = orderID;
			this.orderType = orderType;
			this.date = date;
			this.categoryID = categoryID;
			this.productID = productID;
			this.description = description;
			this.quantity = quantity;
			this.price = price;
			this.amount = amount;
			this.status = status;
			this.categoryButtonID = categoryButtonID;
			this.bagID = bagID;
			//this.isNew = isNew;
			this.conveyorID = conveyorID;
			this.stageID = stageID;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the DetailID value.
		/// </summary>
		public virtual int DetailID
		{
			get { return detailID; }
			set { detailID = value; }
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
		/// Gets or sets the Date value.
		/// </summary>
		public virtual DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		/// <summary>
		/// Gets or sets the CategoryID value.
		/// </summary>
		public virtual int CategoryID
		{
			get { return categoryID; }
			set { categoryID = value; }
		}

		/// <summary>
		/// Gets or sets the ProductID value.
		/// </summary>
		public virtual int ProductID
		{
			get { return productID; }
			set { productID = value; }
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
		/// Gets or sets the Quantity value.
		/// </summary>
		public virtual int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		/// <summary>
		/// Gets or sets the Price value.
		/// </summary>
		public virtual decimal Price
		{
			get { return price; }
			set { price = value; }
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
		/// Gets or sets the Status value.
		/// </summary>
		public virtual string Status
		{
			get { return status; }
			set { status = value; }
		}

		/// <summary>
		/// Gets or sets the CategoryButtonID value.
		/// </summary>
		public virtual int CategoryButtonID
		{
			get { return categoryButtonID; }
			set { categoryButtonID = value; }
		}

		/// <summary>
		/// Gets or sets the BagID value.
		/// </summary>
		public virtual int BagID
		{
			get { return bagID; }
			set { bagID = value; }
		}

		/// <summary>
		/// Gets or sets the IsNew value.
		/// </summary>
		//public virtual bool IsNew
		//{
		//	get { return isNew; }
		//	set { isNew = value; }
		//}

		/// <summary>
		/// Gets or sets the ConveyorID value.
		/// </summary>
		public virtual int ConveyorID
		{
			get { return conveyorID; }
			set { conveyorID = value; }
		}

		/// <summary>
		/// Gets or sets the StageID value.
		/// </summary>
		public virtual int StageID
		{
			get { return stageID; }
			set { stageID = value; }
		}

		#endregion
	}
}
