using System;

namespace Solum
{
	public class Sol_EntriesDetail
	{
		#region Fields

		private int detailID;
		private int entryID;
		private string entryType;
		private int cashID;
		private int count;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_EntriesDetail class.
		/// </summary>
		public Sol_EntriesDetail()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_EntriesDetail class.
		/// </summary>
		public Sol_EntriesDetail(int entryID, string entryType, int cashID, int count)
		{
			this.entryID = entryID;
			this.entryType = entryType;
			this.cashID = cashID;
			this.count = count;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_EntriesDetail class.
		/// </summary>
		public Sol_EntriesDetail(int detailID, int entryID, string entryType, int cashID, int count)
		{
			this.detailID = detailID;
			this.entryID = entryID;
			this.entryType = entryType;
			this.cashID = cashID;
			this.count = count;
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
		/// Gets or sets the EntryID value.
		/// </summary>
		public virtual int EntryID
		{
			get { return entryID; }
			set { entryID = value; }
		}

		/// <summary>
		/// Gets or sets the EntryType value.
		/// </summary>
		public virtual string EntryType
		{
			get { return entryType; }
			set { entryType = value; }
		}

		/// <summary>
		/// Gets or sets the CashID value.
		/// </summary>
		public virtual int CashID
		{
			get { return cashID; }
			set { cashID = value; }
		}

		/// <summary>
		/// Gets or sets the Count value.
		/// </summary>
		public virtual int Count
		{
			get { return count; }
			set { count = value; }
		}

		#endregion
	}
}
