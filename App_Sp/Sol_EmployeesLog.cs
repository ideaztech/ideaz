using System;

namespace Solum
{
	public class Sol_EmployeesLog
	{
		#region Fields

		private long logId;
		private Guid userId;
		private DateTime punchInTime;
		private DateTime punchOutTime;
		private string comments;
		private bool approved;
		private bool modified;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_EmployeesLog class.
		/// </summary>
		public Sol_EmployeesLog()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_EmployeesLog class.
		/// </summary>
		public Sol_EmployeesLog(Guid userId, DateTime punchInTime, DateTime punchOutTime, string comments, bool approved, bool modified)
		{
			this.userId = userId;
			this.punchInTime = punchInTime;
			this.punchOutTime = punchOutTime;
			this.comments = comments;
			this.approved = approved;
			this.modified = modified;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_EmployeesLog class.
		/// </summary>
		public Sol_EmployeesLog(long logId, Guid userId, DateTime punchInTime, DateTime punchOutTime, string comments, bool approved, bool modified)
		{
			this.logId = logId;
			this.userId = userId;
			this.punchInTime = punchInTime;
			this.punchOutTime = punchOutTime;
			this.comments = comments;
			this.approved = approved;
			this.modified = modified;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the LogId value.
		/// </summary>
		public virtual long LogId
		{
			get { return logId; }
			set { logId = value; }
		}

		/// <summary>
		/// Gets or sets the UserId value.
		/// </summary>
		public virtual Guid UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		/// <summary>
		/// Gets or sets the PunchInTime value.
		/// </summary>
		public virtual DateTime PunchInTime
		{
			get { return punchInTime; }
			set { punchInTime = value; }
		}

		/// <summary>
		/// Gets or sets the PunchOutTime value.
		/// </summary>
		public virtual DateTime PunchOutTime
		{
			get { return punchOutTime; }
			set { punchOutTime = value; }
		}

		/// <summary>
		/// Gets or sets the Comments value.
		/// </summary>
		public virtual string Comments
		{
			get { return comments; }
			set { comments = value; }
		}

		/// <summary>
		/// Gets or sets the Approved value.
		/// </summary>
		public virtual bool Approved
		{
			get { return approved; }
			set { approved = value; }
		}

		/// <summary>
		/// Gets or sets the Modified value.
		/// </summary>
		public virtual bool Modified
		{
			get { return modified; }
			set { modified = value; }
		}

		#endregion
	}
}
