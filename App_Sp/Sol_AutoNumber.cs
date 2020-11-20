using System;

namespace Solum
{
	public class Sol_AutoNumber
	{
		#region Fields

		private int agencyID;
		private int folioID;
		private int tagNumber;
		private int rBillNumber;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_AutoNumber class.
		/// </summary>
		public Sol_AutoNumber()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_AutoNumber class.
		/// </summary>
		public Sol_AutoNumber(int agencyID, int folioID, int tagNumber, int rBillNumber)
		{
			this.agencyID = agencyID;
			this.folioID = folioID;
			this.tagNumber = tagNumber;
			this.rBillNumber = rBillNumber;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the AgencyID value.
		/// </summary>
		public virtual int AgencyID
		{
			get { return agencyID; }
			set { agencyID = value; }
		}

		/// <summary>
		/// Gets or sets the FolioID value.
		/// </summary>
		public virtual int FolioID
		{
			get { return folioID; }
			set { folioID = value; }
		}

		/// <summary>
		/// Gets or sets the TagNumber value.
		/// </summary>
		public virtual int TagNumber
		{
			get { return tagNumber; }
			set { tagNumber = value; }
		}

		/// <summary>
		/// Gets or sets the RBillNumber value.
		/// </summary>
		public virtual int RBillNumber
		{
			get { return rBillNumber; }
			set { rBillNumber = value; }
		}

		#endregion
	}
}
