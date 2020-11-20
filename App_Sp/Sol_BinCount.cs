using System;

namespace Solum
{
	public class Sol_BinCount
	{
		#region Fields

		private string clientID;
		private int categoryButtonID;
		private int currentCount;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_BinCount class.
		/// </summary>
		public Sol_BinCount()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_BinCount class.
		/// </summary>
		public Sol_BinCount(string clientID, int categoryButtonID, int currentCount)
		{
			this.clientID = clientID;
			this.categoryButtonID = categoryButtonID;
			this.currentCount = currentCount;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ClientID value.
		/// </summary>
		public virtual string ClientID
		{
			get { return clientID; }
			set { clientID = value; }
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
		/// Gets or sets the CurrentCount value.
		/// </summary>
		public virtual int CurrentCount
		{
			get { return currentCount; }
			set { currentCount = value; }
		}

		#endregion
	}
}
