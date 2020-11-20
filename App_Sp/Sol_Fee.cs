using System;

namespace Solum
{
	public class Sol_Fee
	{
		#region Fields

		private int feeID;
		private string feeDescription;
		private decimal feeAmount;
		private bool percentage;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Fee class.
		/// </summary>
		public Sol_Fee()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Fee class.
		/// </summary>
		public Sol_Fee(string feeDescription, decimal feeAmount, bool percentage)
		{
			this.feeDescription = feeDescription;
			this.feeAmount = feeAmount;
			this.percentage = percentage;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Fee class.
		/// </summary>
		public Sol_Fee(int feeID, string feeDescription, decimal feeAmount, bool percentage)
		{
			this.feeID = feeID;
			this.feeDescription = feeDescription;
			this.feeAmount = feeAmount;
			this.percentage = percentage;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the FeeID value.
		/// </summary>
		public virtual int FeeID
		{
			get { return feeID; }
			set { feeID = value; }
		}

		/// <summary>
		/// Gets or sets the FeeDescription value.
		/// </summary>
		public virtual string FeeDescription
		{
			get { return feeDescription; }
			set { feeDescription = value; }
		}

		/// <summary>
		/// Gets or sets the FeeAmount value.
		/// </summary>
		public virtual decimal FeeAmount
		{
			get { return feeAmount; }
			set { feeAmount = value; }
		}

		/// <summary>
		/// Gets or sets the Percentage value.
		/// </summary>
		public virtual bool Percentage
		{
			get { return percentage; }
			set { percentage = value; }
		}

		#endregion
	}
}
