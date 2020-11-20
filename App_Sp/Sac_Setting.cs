using System;

namespace Solum
{
	public class Sac_Setting
	{
		#region Fields

		private string name;
		private string description;
		private byte[] setValue;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_Setting class.
		/// </summary>
		public Sac_Setting()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_Setting class.
		/// </summary>
		public Sac_Setting(string name, string description, byte[] setValue)
		{
			this.name = name;
			this.description = description;
			this.setValue = setValue;
		}

		#endregion

		#region Properties
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
		/// Gets or sets the SetValue value.
		/// </summary>
		public virtual byte[] SetValue
		{
			get { return setValue; }
			set { setValue = value; }
		}

		#endregion
	}
}
