using System;

namespace Solum
{
	public class Qds_PaymentMethod
	{
		#region Fields

		private int paymentMethodID;
		private string paymentMethod;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Qds_PaymentMethod class.
		/// </summary>
		public Qds_PaymentMethod()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Qds_PaymentMethod class.
		/// </summary>
		public Qds_PaymentMethod(string paymentMethod)
		{
			this.paymentMethod = paymentMethod;
		}

		/// <summary>
		/// Initializes a new instance of the Qds_PaymentMethod class.
		/// </summary>
		public Qds_PaymentMethod(int paymentMethodID, string paymentMethod)
		{
			this.paymentMethodID = paymentMethodID;
			this.paymentMethod = paymentMethod;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the PaymentMethodID value.
		/// </summary>
		public virtual int PaymentMethodID
		{
			get { return paymentMethodID; }
			set { paymentMethodID = value; }
		}

		/// <summary>
		/// Gets or sets the PaymentMethod value.
		/// </summary>
		public virtual string PaymentMethod
		{
			get { return paymentMethod; }
			set { paymentMethod = value; }
		}

		#endregion
	}
}
