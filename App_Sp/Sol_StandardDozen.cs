using System;

namespace Solum
{
	public class Sol_StandardDozen
	{
		#region Fields

		private int standardDozenID;
		private int quantity;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_StandardDozen class.
		/// </summary>
		public Sol_StandardDozen()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_StandardDozen class.
		/// </summary>
		public Sol_StandardDozen(int quantity)
		{
			this.quantity = quantity;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_StandardDozen class.
		/// </summary>
		public Sol_StandardDozen(int standardDozenID, int quantity)
		{
			this.standardDozenID = standardDozenID;
			this.quantity = quantity;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the StandardDozenID value.
		/// </summary>
		public virtual int StandardDozenID
		{
			get { return standardDozenID; }
			set { standardDozenID = value; }
		}

		/// <summary>
		/// Gets or sets the Quantity value.
		/// </summary>
		public virtual int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		#endregion
	}
}
