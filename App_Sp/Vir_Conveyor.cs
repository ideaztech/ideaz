using System;

namespace Solum
{
	public class Vir_Conveyor
	{
		#region Fields

		private int conveyorID;
		private string conveyorDescription;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vir_Conveyor class.
		/// </summary>
		public Vir_Conveyor()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Vir_Conveyor class.
		/// </summary>
		public Vir_Conveyor(string conveyorDescription)
		{
			this.conveyorDescription = conveyorDescription;
		}

		/// <summary>
		/// Initializes a new instance of the Vir_Conveyor class.
		/// </summary>
		public Vir_Conveyor(int conveyorID, string conveyorDescription)
		{
			this.conveyorID = conveyorID;
			this.conveyorDescription = conveyorDescription;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ConveyorID value.
		/// </summary>
		public virtual int ConveyorID
		{
			get { return conveyorID; }
			set { conveyorID = value; }
		}

		/// <summary>
		/// Gets or sets the ConveyorDescription value.
		/// </summary>
		public virtual string ConveyorDescription
		{
			get { return conveyorDescription; }
			set { conveyorDescription = value; }
		}

		#endregion
	}
}
