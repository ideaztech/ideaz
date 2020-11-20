using System;

namespace Solum
{
	public class Sac_LogType
	{
		#region Fields

		private int logTypeID;
		private string description;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_LogType class.
		/// </summary>
		public Sac_LogType()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_LogType class.
		/// </summary>
		public Sac_LogType(int logTypeID, string description)
		{
			this.logTypeID = logTypeID;
			this.description = description;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the LogTypeID value.
		/// </summary>
		public virtual int LogTypeID
		{
			get { return logTypeID; }
			set { logTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public virtual string Description
		{
			get { return description; }
			set { description = value; }
		}

		#endregion
	}
}
