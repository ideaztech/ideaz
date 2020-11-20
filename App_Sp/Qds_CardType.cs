using System;

namespace Solum
{
	public class Qds_CardType
	{
		#region Fields

		private int cardTypeID;
		private string cardType;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Qds_CardType class.
		/// </summary>
		public Qds_CardType()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Qds_CardType class.
		/// </summary>
		public Qds_CardType(string cardType)
		{
			this.cardType = cardType;
		}

		/// <summary>
		/// Initializes a new instance of the Qds_CardType class.
		/// </summary>
		public Qds_CardType(int cardTypeID, string cardType)
		{
			this.cardTypeID = cardTypeID;
			this.cardType = cardType;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CardTypeID value.
		/// </summary>
		public virtual int CardTypeID
		{
			get { return cardTypeID; }
			set { cardTypeID = value; }
		}

		/// <summary>
		/// Gets or sets the CardType value.
		/// </summary>
		public virtual string CardType
		{
			get { return cardType; }
			set { cardType = value; }
		}

		#endregion
	}
}
