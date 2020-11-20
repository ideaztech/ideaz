using System;

namespace Solum
{
	public class Sol_ContainerType
	{
		#region Fields

		private int containerTypeID;
		private string description;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_ContainerType class.
		/// </summary>
		public Sol_ContainerType()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_ContainerType class.
		/// </summary>
		public Sol_ContainerType(string description)
		{
			this.description = description;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_ContainerType class.
		/// </summary>
		public Sol_ContainerType(int containerTypeID, string description)
		{
			this.containerTypeID = containerTypeID;
			this.description = description;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ContainerTypeID value.
		/// </summary>
		public virtual int ContainerTypeID
		{
			get { return containerTypeID; }
			set { containerTypeID = value; }
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
