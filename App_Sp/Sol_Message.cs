using System;

namespace Solum
{
	public class Sol_Message
	{
		#region Fields

		private int messageID;
		private string name;
		private string description;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Message class.
		/// </summary>
		public Sol_Message()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Message class.
		/// </summary>
		public Sol_Message(string name, string description)
		{
			this.name = name;
			this.description = description;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Message class.
		/// </summary>
		public Sol_Message(int messageID, string name, string description)
		{
			this.messageID = messageID;
			this.name = name;
			this.description = description;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the MessageID value.
		/// </summary>
		public virtual int MessageID
		{
			get { return messageID; }
			set { messageID = value; }
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

		#endregion
	}
}
