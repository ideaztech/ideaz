using System;

namespace Solum
{
	public class Sol_QueryDate
	{
		#region Fields

		private DateTime dateFrom;
		private DateTime dateTo;
		private string userName;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_QueryDate class.
		/// </summary>
		public Sol_QueryDate()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_QueryDate class.
		/// </summary>
		public Sol_QueryDate(DateTime dateFrom, DateTime dateTo, string userName)
		{
			this.dateFrom = dateFrom;
			this.dateTo = dateTo;
			this.userName = userName;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the DateFrom value.
		/// </summary>
		public virtual DateTime DateFrom
		{
			get { return dateFrom; }
			set { dateFrom = value; }
		}

		/// <summary>
		/// Gets or sets the DateTo value.
		/// </summary>
		public virtual DateTime DateTo
		{
			get { return dateTo; }
			set { dateTo = value; }
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
