using System;

namespace Solum
{
	public class Vir_BagPosition
	{
		#region Fields

		private int bagPositionID;
		private string bagPositionName;
		private int productID;
		private int currentStageID;
		private int currentQuantity;
		private int targetQuantity;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vir_BagPosition class.
		/// </summary>
		public Vir_BagPosition()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Vir_BagPosition class.
		/// </summary>
		public Vir_BagPosition(int bagPositionID, string bagPositionName, int productID, int currentStageID, int currentQuantity, int targetQuantity)
		{
			this.bagPositionID = bagPositionID;
			this.bagPositionName = bagPositionName;
			this.productID = productID;
			this.currentStageID = currentStageID;
			this.currentQuantity = currentQuantity;
			this.targetQuantity = targetQuantity;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the BagPositionID value.
		/// </summary>
		public virtual int BagPositionID
		{
			get { return bagPositionID; }
			set { bagPositionID = value; }
		}

		/// <summary>
		/// Gets or sets the BagPositionName value.
		/// </summary>
		public virtual string BagPositionName
		{
			get { return bagPositionName; }
			set { bagPositionName = value; }
		}

		/// <summary>
		/// Gets or sets the ProductID value.
		/// </summary>
		public virtual int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}

		/// <summary>
		/// Gets or sets the CurrentStageID value.
		/// </summary>
		public virtual int CurrentStageID
		{
			get { return currentStageID; }
			set { currentStageID = value; }
		}

		/// <summary>
		/// Gets or sets the CurrentQuantity value.
		/// </summary>
		public virtual int CurrentQuantity
		{
			get { return currentQuantity; }
			set { currentQuantity = value; }
		}

		/// <summary>
		/// Gets or sets the TargetQuantity value.
		/// </summary>
		public virtual int TargetQuantity
		{
			get { return targetQuantity; }
			set { targetQuantity = value; }
		}

		#endregion
	}
}
