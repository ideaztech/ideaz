using System;

namespace Solum
{
	public class Sol_WS_ItemType
	{
		#region Fields

		private int itemTypeID;
		private string itemType;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_WS_ItemType class.
		/// </summary>
		public Sol_WS_ItemType()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_WS_ItemType class.
		/// </summary>
		public Sol_WS_ItemType(int itemTypeID, string itemType)
		{
			this.itemTypeID = itemTypeID;
			this.itemType = itemType;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ItemTypeID value.
		/// </summary>
		public virtual int ItemTypeID
		{
			get { return itemTypeID; }
			set { itemTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the ItemType value.
		/// </summary>
		public virtual string ItemType
		{
			get { return itemType; }
			set { itemType = value; }
		}

		#endregion
	}
}
