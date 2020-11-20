using System;

namespace Solum
{
	public class Sol_Container
	{
		#region Fields

		private int containerID;
		private string description;
		private string shortDescription;
		private int containerTypeID;
		private int shippingContainerID;
		private int shippingContainerTypeID;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Container class.
		/// </summary>
		public Sol_Container()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Container class.
		/// </summary>
		public Sol_Container(string description, string shortDescription, int containerTypeID, int shippingContainerID, int shippingContainerTypeID)
		{
			this.description = description;
			this.shortDescription = shortDescription;
			this.containerTypeID = containerTypeID;
			this.shippingContainerID = shippingContainerID;
			this.shippingContainerTypeID = shippingContainerTypeID;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Container class.
		/// </summary>
		public Sol_Container(int containerID, string description, string shortDescription, int containerTypeID, int shippingContainerID, int shippingContainerTypeID)
		{
			this.containerID = containerID;
			this.description = description;
			this.shortDescription = shortDescription;
			this.containerTypeID = containerTypeID;
			this.shippingContainerID = shippingContainerID;
			this.shippingContainerTypeID = shippingContainerTypeID;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ContainerID value.
		/// </summary>
		public virtual int ContainerID
		{
			get { return containerID; }
			set { containerID = value; }
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
		/// Gets or sets the ShortDescription value.
		/// </summary>
		public virtual string ShortDescription
		{
			get { return shortDescription; }
			set { shortDescription = value; }
		}

		/// <summary>
		/// Gets or sets the ContainerTypeID value.
		/// </summary>
		public virtual int ContainerTypeID
		{
			get { return containerTypeID; }
			set { containerTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the ShippingContainerID value.
		/// </summary>
		public virtual int ShippingContainerID
		{
			get { return shippingContainerID; }
			set { shippingContainerID = value; }
		}

		/// <summary>
		/// Gets or sets the ShippingContainerTypeID value.
		/// </summary>
		public virtual int ShippingContainerTypeID
		{
			get { return shippingContainerTypeID; }
			set { shippingContainerTypeID = value; }
		}

		#endregion
	}
}
