using System;

namespace Solum
{
	public class Vir_ConveyorLink
	{
		#region Fields

		private int conveyorLinkID;
		private int bagPositionID;
		private int conveyorID;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vir_ConveyorLink class.
		/// </summary>
		public Vir_ConveyorLink()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Vir_ConveyorLink class.
		/// </summary>
		public Vir_ConveyorLink(int bagPositionID, int conveyorID)
		{
			this.bagPositionID = bagPositionID;
			this.conveyorID = conveyorID;
		}

		/// <summary>
		/// Initializes a new instance of the Vir_ConveyorLink class.
		/// </summary>
		public Vir_ConveyorLink(int conveyorLinkID, int bagPositionID, int conveyorID)
		{
			this.conveyorLinkID = conveyorLinkID;
			this.bagPositionID = bagPositionID;
			this.conveyorID = conveyorID;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ConveyorLinkID value.
		/// </summary>
		public virtual int ConveyorLinkID
		{
			get { return conveyorLinkID; }
			set { conveyorLinkID = value; }
		}

		/// <summary>
		/// Gets or sets the BagPositionID value.
		/// </summary>
		public virtual int BagPositionID
		{
			get { return bagPositionID; }
			set { bagPositionID = value; }
		}

		/// <summary>
		/// Gets or sets the ConveyorID value.
		/// </summary>
		public virtual int ConveyorID
		{
			get { return conveyorID; }
			set { conveyorID = value; }
        }

		#endregion

    }
}
