using System;

namespace Solum
{
	public class Sol_WS_ShippingContainerType
	{
		#region Fields

		private int shippingContainerTypeID;
		private string shippingContainerType;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_WS_ShippingContainerType class.
		/// </summary>
		public Sol_WS_ShippingContainerType()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_WS_ShippingContainerType class.
		/// </summary>
		public Sol_WS_ShippingContainerType(int shippingContainerTypeID, string shippingContainerType)
		{
			this.shippingContainerTypeID = shippingContainerTypeID;
			this.shippingContainerType = shippingContainerType;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ShippingContainerTypeID value.
		/// </summary>
		public virtual int ShippingContainerTypeID
		{
			get { return shippingContainerTypeID; }
			set { shippingContainerTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the ShippingContainerType value.
		/// </summary>
		public virtual string ShippingContainerType
		{
			get { return shippingContainerType; }
			set { shippingContainerType = value; }
		}

		#endregion
	}
}
