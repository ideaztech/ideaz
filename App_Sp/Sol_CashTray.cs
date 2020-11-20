using System;

namespace Solum
{
	public class Sol_CashTray
	{
		#region Fields

		private int cashTrayID;
		private string description;
		private int workStationID;
		private Guid userID;
		private string userName;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_CashTray class.
		/// </summary>
		public Sol_CashTray()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_CashTray class.
		/// </summary>
		public Sol_CashTray(string description, int workStationID, Guid userID, string userName)
		{
			this.description = description;
			this.workStationID = workStationID;
			this.userID = userID;
			this.userName = userName;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_CashTray class.
		/// </summary>
		public Sol_CashTray(int cashTrayID, string description, int workStationID, Guid userID, string userName)
		{
			this.cashTrayID = cashTrayID;
			this.description = description;
			this.workStationID = workStationID;
			this.userID = userID;
			this.userName = userName;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CashTrayID value.
		/// </summary>
		public virtual int CashTrayID
		{
			get { return cashTrayID; }
			set { cashTrayID = value; }
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
		/// Gets or sets the WorkStationID value.
		/// </summary>
		public virtual int WorkStationID
		{
			get { return workStationID; }
			set { workStationID = value; }
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

		#endregion
	}
}
