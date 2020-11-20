using System;

namespace Solum
{
	public class Qds_PaymentMethodAvailableByDepot
	{
		#region Fields

		private string depotID;
		private int paymentMethodID;
		private bool depotDefault;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Qds_PaymentMethodAvailableByDepot class.
		/// </summary>
		public Qds_PaymentMethodAvailableByDepot()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Qds_PaymentMethodAvailableByDepot class.
		/// </summary>
		public Qds_PaymentMethodAvailableByDepot(string depotID, int paymentMethodID, bool depotDefault)
		{
			this.depotID = depotID;
			this.paymentMethodID = paymentMethodID;
			this.depotDefault = depotDefault;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the DepotID value.
		/// </summary>
		public virtual string DepotID
		{
			get { return depotID; }
			set { depotID = value; }
		}

		/// <summary>
		/// Gets or sets the PaymentMethodID value.
		/// </summary>
		public virtual int PaymentMethodID
		{
			get { return paymentMethodID; }
			set { paymentMethodID = value; }
		}

		/// <summary>
		/// Gets or sets the DepotDefault value.
		/// </summary>
		public virtual bool DepotDefault
		{
			get { return depotDefault; }
			set { depotDefault = value; }
		}

		#endregion
	}
}
