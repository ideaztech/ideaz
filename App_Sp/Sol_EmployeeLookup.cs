using System;

namespace Solum
{
	public class Sol_EmployeeLookup
	{
		#region Fields

		private Guid userId;
		private string fullName;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Employee class.
		/// </summary>
		public Sol_EmployeeLookup()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Employee class.
		/// </summary>
		public Sol_EmployeeLookup(Guid userId, string fullName)
		{
			this.userId = userId;
			this.fullName = fullName;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the UserId value.
		/// </summary>
		public virtual Guid UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		/// <summary>
		/// Gets or sets the FirstName value.
		/// </summary>
		public virtual string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}


		#endregion
	}
}
