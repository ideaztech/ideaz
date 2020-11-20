using System;

namespace Solum
{
	public class Sol_Stage
	{
		#region Fields

		private int stageID;
		private int shipmentID;
		private Guid userID;
		private string userName;
		private DateTime date;
		private string tagNumber;
		private int containerID;
		private string containerDescription;
		private int productID;
		private string productName;
		private int dozen;
		private int quantity;
		private decimal price;
		private string remarks;
		private string status;
		private DateTime dateClosed;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Stage class.
		/// </summary>
		public Sol_Stage()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Stage class.
		/// </summary>
		public Sol_Stage(int shipmentID, Guid userID, string userName, DateTime date, string tagNumber, int containerID, string containerDescription, int productID, string productName, int dozen, int quantity, decimal price, string remarks, string status, DateTime dateClosed)
		{
			this.shipmentID = shipmentID;
			this.userID = userID;
			this.userName = userName;
			this.date = date;
			this.tagNumber = tagNumber;
			this.containerID = containerID;
			this.containerDescription = containerDescription;
			this.productID = productID;
			this.productName = productName;
			this.dozen = dozen;
			this.quantity = quantity;
			this.price = price;
			this.remarks = remarks;
			this.status = status;
			this.dateClosed = dateClosed;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Stage class.
		/// </summary>
		public Sol_Stage(int stageID, int shipmentID, Guid userID, string userName, DateTime date, string tagNumber, int containerID, string containerDescription, int productID, string productName, int dozen, int quantity, decimal price, string remarks, string status, DateTime dateClosed)
		{
			this.stageID = stageID;
			this.shipmentID = shipmentID;
			this.userID = userID;
			this.userName = userName;
			this.date = date;
			this.tagNumber = tagNumber;
			this.containerID = containerID;
			this.containerDescription = containerDescription;
			this.productID = productID;
			this.productName = productName;
			this.dozen = dozen;
			this.quantity = quantity;
			this.price = price;
			this.remarks = remarks;
			this.status = status;
			this.dateClosed = dateClosed;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the StageID value.
		/// </summary>
		public virtual int StageID
		{
			get { return stageID; }
			set { stageID = value; }
		}

		/// <summary>
		/// Gets or sets the ShipmentID value.
		/// </summary>
		public virtual int ShipmentID
		{
			get { return shipmentID; }
			set { shipmentID = value; }
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
		/// Gets or sets the TagNumber value.
		/// </summary>
		public virtual string TagNumber
		{
			get { return tagNumber; }
			set { tagNumber = value; }
		}

		/// <summary>
		/// Gets or sets the ContainerID value.
		/// </summary>
		public virtual int ContainerID
		{
			get { return containerID; }
			set { containerID = value; }
		}

		/// <summary>
		/// Gets or sets the ContainerDescription value.
		/// </summary>
		public virtual string ContainerDescription
		{
			get { return containerDescription; }
			set { containerDescription = value; }
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
		/// Gets or sets the ProductName value.
		/// </summary>
		public virtual string ProductName
		{
			get { return productName; }
			set { productName = value; }
		}

		/// <summary>
		/// Gets or sets the Dozen value.
		/// </summary>
		public virtual int Dozen
		{
			get { return dozen; }
			set { dozen = value; }
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
		/// Gets or sets the Remarks value.
		/// </summary>
		public virtual string Remarks
		{
			get { return remarks; }
			set { remarks = value; }
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
		/// Gets or sets the DateClosed value.
		/// </summary>
		public virtual DateTime DateClosed
		{
			get { return dateClosed; }
			set { dateClosed = value; }
		}

		#endregion
	}
}
