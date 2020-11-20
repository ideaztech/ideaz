using System;

namespace Solum
{
	public class Sol_WS_Plant
	{
		#region Fields

		private int plantID;
		private string plant;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_WS_Plant class.
		/// </summary>
		public Sol_WS_Plant()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_WS_Plant class.
		/// </summary>
		public Sol_WS_Plant(int plantID, string plant)
		{
			this.plantID = plantID;
			this.plant = plant;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the PlantID value.
		/// </summary>
		public virtual int PlantID
		{
			get { return plantID; }
			set { plantID = value; }
		}

		/// <summary>
		/// Gets or sets the Plant value.
		/// </summary>
		public virtual string Plant
		{
			get { return plant; }
			set { plant = value; }
		}

		#endregion
	}
}
