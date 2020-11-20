using System;

namespace Solum
{
	public class Sol_SupplyInventory
	{
		#region Fields

		private int supplyInventoryID;
		private string supplyInventoryType;
		private Guid userID;
		private DateTime date;
		private DateTime dateOrdered;
		private int productID;
		private int containerID;
		private int quantity;
		private int shipmentID;
		private string referenceNumber;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_SupplyInventory class.
		/// </summary>
		public Sol_SupplyInventory()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_SupplyInventory class.
		/// </summary>
		public Sol_SupplyInventory(string supplyInventoryType, Guid userID, DateTime date, DateTime dateOrdered, int productID, int containerID, int quantity, int shipmentID, string referenceNumber)
		{
			this.supplyInventoryType = supplyInventoryType;
			this.userID = userID;
			this.date = date;
			this.dateOrdered = dateOrdered;
			this.productID = productID;
			this.containerID = containerID;
			this.quantity = quantity;
			this.shipmentID = shipmentID;
			this.referenceNumber = referenceNumber;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_SupplyInventory class.
		/// </summary>
		public Sol_SupplyInventory(int supplyInventoryID, string supplyInventoryType, Guid userID, DateTime date, DateTime dateOrdered, int productID, int containerID, int quantity, int shipmentID, string referenceNumber)
		{
			this.supplyInventoryID = supplyInventoryID;
			this.supplyInventoryType = supplyInventoryType;
			this.userID = userID;
			this.date = date;
			this.dateOrdered = dateOrdered;
			this.productID = productID;
			this.containerID = containerID;
			this.quantity = quantity;
			this.shipmentID = shipmentID;
			this.referenceNumber = referenceNumber;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the SupplyInventoryID value.
		/// </summary>
		public virtual int SupplyInventoryID
		{
			get { return supplyInventoryID; }
			set { supplyInventoryID = value; }
		}

		/// <summary>
		/// Gets or sets the SupplyInventoryType value.
		/// </summary>
		public virtual string SupplyInventoryType
		{
			get { return supplyInventoryType; }
			set { supplyInventoryType = value; }
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
		/// Gets or sets the Date value.
		/// </summary>
		public virtual DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		/// <summary>
		/// Gets or sets the DateOrdered value.
		/// </summary>
		public virtual DateTime DateOrdered
		{
			get { return dateOrdered; }
			set { dateOrdered = value; }
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
		/// Gets or sets the ContainerID value.
		/// </summary>
		public virtual int ContainerID
		{
			get { return containerID; }
			set { containerID = value; }
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
		/// Gets or sets the ShipmentID value.
		/// </summary>
		public virtual int ShipmentID
		{
			get { return shipmentID; }
			set { shipmentID = value; }
		}

		/// <summary>
		/// Gets or sets the ReferenceNumber value.
		/// </summary>
		public virtual string ReferenceNumber
		{
			get { return referenceNumber; }
			set { referenceNumber = value; }
		}

		#endregion
	}
}
