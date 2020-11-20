using System;

namespace Solum
{
	public class Sac_Log
	{
		#region Fields

		private int logID;
		private int entryType;
		private int orderNumber;
		private decimal orderAmount;
		private string description;
		private int quantityof50;
		private int quantityof20;
		private int quantityof10;
		private int quantityof5;
		private int quantityofToonie;
		private int quantityofLoonie;
		private int quantityofQuarter;
		private int quantityofDime;
		private int quantityofNickel;
		private decimal totalValue;
		private int remaining50;
		private int remaining20;
		private int remaining10;
		private int remaining5;
		private int remainingToonie;
		private int remainingLoonie;
		private int remainingQuarter;
		private int remainingDime;
		private int remainingNickel;
		private DateTime timeStamp;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sac_Log class.
		/// </summary>
		public Sac_Log()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sac_Log class.
		/// </summary>
		public Sac_Log(int entryType, int orderNumber, decimal orderAmount, string description, int quantityof50, int quantityof20, int quantityof10, int quantityof5, int quantityofToonie, int quantityofLoonie, int quantityofQuarter, int quantityofDime, int quantityofNickel, decimal totalValue, int remaining50, int remaining20, int remaining10, int remaining5, int remainingToonie, int remainingLoonie, int remainingQuarter, int remainingDime, int remainingNickel, DateTime timeStamp)
		{
			this.entryType = entryType;
			this.orderNumber = orderNumber;
			this.orderAmount = orderAmount;
			this.description = description;
			this.quantityof50 = quantityof50;
			this.quantityof20 = quantityof20;
			this.quantityof10 = quantityof10;
			this.quantityof5 = quantityof5;
			this.quantityofToonie = quantityofToonie;
			this.quantityofLoonie = quantityofLoonie;
			this.quantityofQuarter = quantityofQuarter;
			this.quantityofDime = quantityofDime;
			this.quantityofNickel = quantityofNickel;
			this.totalValue = totalValue;
			this.remaining50 = remaining50;
			this.remaining20 = remaining20;
			this.remaining10 = remaining10;
			this.remaining5 = remaining5;
			this.remainingToonie = remainingToonie;
			this.remainingLoonie = remainingLoonie;
			this.remainingQuarter = remainingQuarter;
			this.remainingDime = remainingDime;
			this.remainingNickel = remainingNickel;
			this.timeStamp = timeStamp;
		}

		/// <summary>
		/// Initializes a new instance of the Sac_Log class.
		/// </summary>
		public Sac_Log(int logID, int entryType, int orderNumber, decimal orderAmount, string description, int quantityof50, int quantityof20, int quantityof10, int quantityof5, int quantityofToonie, int quantityofLoonie, int quantityofQuarter, int quantityofDime, int quantityofNickel, decimal totalValue, int remaining50, int remaining20, int remaining10, int remaining5, int remainingToonie, int remainingLoonie, int remainingQuarter, int remainingDime, int remainingNickel, DateTime timeStamp)
		{
			this.logID = logID;
			this.entryType = entryType;
			this.orderNumber = orderNumber;
			this.orderAmount = orderAmount;
			this.description = description;
			this.quantityof50 = quantityof50;
			this.quantityof20 = quantityof20;
			this.quantityof10 = quantityof10;
			this.quantityof5 = quantityof5;
			this.quantityofToonie = quantityofToonie;
			this.quantityofLoonie = quantityofLoonie;
			this.quantityofQuarter = quantityofQuarter;
			this.quantityofDime = quantityofDime;
			this.quantityofNickel = quantityofNickel;
			this.totalValue = totalValue;
			this.remaining50 = remaining50;
			this.remaining20 = remaining20;
			this.remaining10 = remaining10;
			this.remaining5 = remaining5;
			this.remainingToonie = remainingToonie;
			this.remainingLoonie = remainingLoonie;
			this.remainingQuarter = remainingQuarter;
			this.remainingDime = remainingDime;
			this.remainingNickel = remainingNickel;
			this.timeStamp = timeStamp;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the LogID value.
		/// </summary>
		public virtual int LogID
		{
			get { return logID; }
			set { logID = value; }
		}

		/// <summary>
		/// Gets or sets the EntryType value.
		/// </summary>
		public virtual int EntryType
		{
			get { return entryType; }
			set { entryType = value; }
		}

		/// <summary>
		/// Gets or sets the OrderNumber value.
		/// </summary>
		public virtual int OrderNumber
		{
			get { return orderNumber; }
			set { orderNumber = value; }
		}

		/// <summary>
		/// Gets or sets the OrderAmount value.
		/// </summary>
		public virtual decimal OrderAmount
		{
			get { return orderAmount; }
			set { orderAmount = value; }
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
		/// Gets or sets the Quantityof50 value.
		/// </summary>
		public virtual int Quantityof50
		{
			get { return quantityof50; }
			set { quantityof50 = value; }
		}

		/// <summary>
		/// Gets or sets the Quantityof20 value.
		/// </summary>
		public virtual int Quantityof20
		{
			get { return quantityof20; }
			set { quantityof20 = value; }
		}

		/// <summary>
		/// Gets or sets the Quantityof10 value.
		/// </summary>
		public virtual int Quantityof10
		{
			get { return quantityof10; }
			set { quantityof10 = value; }
		}

		/// <summary>
		/// Gets or sets the Quantityof5 value.
		/// </summary>
		public virtual int Quantityof5
		{
			get { return quantityof5; }
			set { quantityof5 = value; }
		}

		/// <summary>
		/// Gets or sets the QuantityofToonie value.
		/// </summary>
		public virtual int QuantityofToonie
		{
			get { return quantityofToonie; }
			set { quantityofToonie = value; }
		}

		/// <summary>
		/// Gets or sets the QuantityofLoonie value.
		/// </summary>
		public virtual int QuantityofLoonie
		{
			get { return quantityofLoonie; }
			set { quantityofLoonie = value; }
		}

		/// <summary>
		/// Gets or sets the QuantityofQuarter value.
		/// </summary>
		public virtual int QuantityofQuarter
		{
			get { return quantityofQuarter; }
			set { quantityofQuarter = value; }
		}

		/// <summary>
		/// Gets or sets the QuantityofDime value.
		/// </summary>
		public virtual int QuantityofDime
		{
			get { return quantityofDime; }
			set { quantityofDime = value; }
		}

		/// <summary>
		/// Gets or sets the QuantityofNickel value.
		/// </summary>
		public virtual int QuantityofNickel
		{
			get { return quantityofNickel; }
			set { quantityofNickel = value; }
		}

		/// <summary>
		/// Gets or sets the TotalValue value.
		/// </summary>
		public virtual decimal TotalValue
		{
			get { return totalValue; }
			set { totalValue = value; }
		}

		/// <summary>
		/// Gets or sets the Remaining50 value.
		/// </summary>
		public virtual int Remaining50
		{
			get { return remaining50; }
			set { remaining50 = value; }
		}

		/// <summary>
		/// Gets or sets the Remaining20 value.
		/// </summary>
		public virtual int Remaining20
		{
			get { return remaining20; }
			set { remaining20 = value; }
		}

		/// <summary>
		/// Gets or sets the Remaining10 value.
		/// </summary>
		public virtual int Remaining10
		{
			get { return remaining10; }
			set { remaining10 = value; }
		}

		/// <summary>
		/// Gets or sets the Remaining5 value.
		/// </summary>
		public virtual int Remaining5
		{
			get { return remaining5; }
			set { remaining5 = value; }
		}

		/// <summary>
		/// Gets or sets the RemainingToonie value.
		/// </summary>
		public virtual int RemainingToonie
		{
			get { return remainingToonie; }
			set { remainingToonie = value; }
		}

		/// <summary>
		/// Gets or sets the RemainingLoonie value.
		/// </summary>
		public virtual int RemainingLoonie
		{
			get { return remainingLoonie; }
			set { remainingLoonie = value; }
		}

		/// <summary>
		/// Gets or sets the RemainingQuarter value.
		/// </summary>
		public virtual int RemainingQuarter
		{
			get { return remainingQuarter; }
			set { remainingQuarter = value; }
		}

		/// <summary>
		/// Gets or sets the RemainingDime value.
		/// </summary>
		public virtual int RemainingDime
		{
			get { return remainingDime; }
			set { remainingDime = value; }
		}

		/// <summary>
		/// Gets or sets the RemainingNickel value.
		/// </summary>
		public virtual int RemainingNickel
		{
			get { return remainingNickel; }
			set { remainingNickel = value; }
		}

		/// <summary>
		/// Gets or sets the TimeStamp value.
		/// </summary>
		public virtual DateTime TimeStamp
		{
			get { return timeStamp; }
			set { timeStamp = value; }
		}

		#endregion
	}
}
