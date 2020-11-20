using System;

namespace Solum
{
	public class Sol_WS_Carrier
	{
		#region Fields

		private int carrierID;
		private string carrier;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_WS_Carrier class.
		/// </summary>
		public Sol_WS_Carrier()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_WS_Carrier class.
		/// </summary>
		public Sol_WS_Carrier(int carrierID, string carrier)
		{
			this.carrierID = carrierID;
			this.carrier = carrier;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CarrierID value.
		/// </summary>
		public virtual int CarrierID
		{
			get { return carrierID; }
			set { carrierID = value; }
		}

		/// <summary>
		/// Gets or sets the Carrier value.
		/// </summary>
		public virtual string Carrier
		{
			get { return carrier; }
			set { carrier = value; }
		}

		#endregion
	}
}
