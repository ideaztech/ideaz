using System;

namespace Solum
{
	public class Sol_WorkStation
	{
		#region Fields

		private int workStationID;
		private string name;
		private string description;
		private string location;
		private int conveyorID;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_WorkStation class.
		/// </summary>
		public Sol_WorkStation()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_WorkStation class.
		/// </summary>
		public Sol_WorkStation(string name, string description, string location, int conveyorID)
		{
			this.name = name;
			this.description = description;
			this.location = location;
			this.conveyorID = conveyorID;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_WorkStation class.
		/// </summary>
		public Sol_WorkStation(int workStationID, string name, string description, string location, int conveyorID)
		{
			this.workStationID = workStationID;
			this.name = name;
			this.description = description;
			this.location = location;
			this.conveyorID = conveyorID;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the WorkStationID value.
		/// </summary>
		public virtual int WorkStationID
		{
			get { return workStationID; }
			set { workStationID = value; }
		}

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public virtual string Name
		{
			get { return name; }
			set { name = value; }
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
		/// Gets or sets the Location value.
		/// </summary>
		public virtual string Location
		{
			get { return location; }
			set { location = value; }
		}

		/// <summary>
		/// Gets or sets the ConveyorID value.
		/// </summary>
		public virtual int ConveyorID
		{
			get { return conveyorID; }
			set { conveyorID = value; }
		}

		#endregion
	}
}
