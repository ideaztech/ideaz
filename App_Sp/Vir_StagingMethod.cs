using System;

namespace Solum
{
	public class Vir_StagingMethod
	{
		#region Fields

		private int stagingMethodID;
		private string stagingMethodName;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vir_StagingMethod class.
		/// </summary>
		public Vir_StagingMethod()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Vir_StagingMethod class.
		/// </summary>
		public Vir_StagingMethod(string stagingMethodName)
		{
			this.stagingMethodName = stagingMethodName;
		}

		/// <summary>
		/// Initializes a new instance of the Vir_StagingMethod class.
		/// </summary>
		public Vir_StagingMethod(int stagingMethodID, string stagingMethodName)
		{
			this.stagingMethodID = stagingMethodID;
			this.stagingMethodName = stagingMethodName;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the StagingMethodID value.
		/// </summary>
		public virtual int StagingMethodID
		{
			get { return stagingMethodID; }
			set { stagingMethodID = value; }
		}

		/// <summary>
		/// Gets or sets the StagingMethodName value.
		/// </summary>
		public virtual string StagingMethodName
		{
			get { return stagingMethodName; }
			set { stagingMethodName = value; }
		}

		#endregion
	}
}
