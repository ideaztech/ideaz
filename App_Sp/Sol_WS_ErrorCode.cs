using System;

namespace Solum
{
	public class Sol_WS_ErrorCode
	{
		#region Fields

		private int errorNumber;
		private string errorDescription;
		private bool messageToClient;
		private string notes;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_WS_ErrorCode class.
		/// </summary>
		public Sol_WS_ErrorCode()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_WS_ErrorCode class.
		/// </summary>
		public Sol_WS_ErrorCode(int errorNumber, string errorDescription, bool messageToClient, string notes)
		{
			this.errorNumber = errorNumber;
			this.errorDescription = errorDescription;
			this.messageToClient = messageToClient;
			this.notes = notes;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ErrorNumber value.
		/// </summary>
		public virtual int ErrorNumber
		{
			get { return errorNumber; }
			set { errorNumber = value; }
		}

		/// <summary>
		/// Gets or sets the ErrorDescription value.
		/// </summary>
		public virtual string ErrorDescription
		{
			get { return errorDescription; }
			set { errorDescription = value; }
		}

		/// <summary>
		/// Gets or sets the MessageToClient value.
		/// </summary>
		public virtual bool MessageToClient
		{
			get { return messageToClient; }
			set { messageToClient = value; }
		}

		/// <summary>
		/// Gets or sets the Notes value.
		/// </summary>
		public virtual string Notes
		{
			get { return notes; }
			set { notes = value; }
		}

		#endregion
	}
}
