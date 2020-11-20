using System;

namespace Solum
{
	public class Sol_Product
	{
		#region Fields

		private int productID;
		private string proName;
		private string proDescription;
		private string proShortDescription;
		private byte[] proImage;
		private int agencyID;
		private int menuOrder;
		private bool isActive;
		private decimal price;
		private int categoryID;
		private decimal refundAmount;
		private decimal handlingCommissionAmount;
		private int commissionUnit;
		private decimal vafAmount;
		private int feeUnit;
		private int containerID;
		private int standardDozenID;
		private string uPC;
		private string productCode;
		private byte typeId;
		private bool tax1Exempt;
		private bool tax2Exempt;
		private int masterProductID;
		private decimal weight;
		private decimal volume;
		private int targetQuantity;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_Product class.
		/// </summary>
		public Sol_Product()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Product class.
		/// </summary>
		public Sol_Product(string proName, string proDescription, string proShortDescription, byte[] proImage, int agencyID, int menuOrder, bool isActive, decimal price, int categoryID, decimal refundAmount, decimal handlingCommissionAmount, int commissionUnit, decimal vafAmount, int feeUnit, int containerID, int standardDozenID, string uPC, string productCode, byte typeId, bool tax1Exempt, bool tax2Exempt, int masterProductID, decimal weight, decimal volume, int targetQuantity)
		{
			this.proName = proName;
			this.proDescription = proDescription;
			this.proShortDescription = proShortDescription;
			this.proImage = proImage;
			this.agencyID = agencyID;
			this.menuOrder = menuOrder;
			this.isActive = isActive;
			this.price = price;
			this.categoryID = categoryID;
			this.refundAmount = refundAmount;
			this.handlingCommissionAmount = handlingCommissionAmount;
			this.commissionUnit = commissionUnit;
			this.vafAmount = vafAmount;
			this.feeUnit = feeUnit;
			this.containerID = containerID;
			this.standardDozenID = standardDozenID;
			this.uPC = uPC;
			this.productCode = productCode;
			this.typeId = typeId;
			this.tax1Exempt = tax1Exempt;
			this.tax2Exempt = tax2Exempt;
			this.masterProductID = masterProductID;
			this.weight = weight;
			this.volume = volume;
			this.targetQuantity = targetQuantity;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_Product class.
		/// </summary>
		public Sol_Product(int productID, string proName, string proDescription, string proShortDescription, byte[] proImage, int agencyID, int menuOrder, bool isActive, decimal price, int categoryID, decimal refundAmount, decimal handlingCommissionAmount, int commissionUnit, decimal vafAmount, int feeUnit, int containerID, int standardDozenID, string uPC, string productCode, byte typeId, bool tax1Exempt, bool tax2Exempt, int masterProductID, decimal weight, decimal volume, int targetQuantity)
		{
			this.productID = productID;
			this.proName = proName;
			this.proDescription = proDescription;
			this.proShortDescription = proShortDescription;
			this.proImage = proImage;
			this.agencyID = agencyID;
			this.menuOrder = menuOrder;
			this.isActive = isActive;
			this.price = price;
			this.categoryID = categoryID;
			this.refundAmount = refundAmount;
			this.handlingCommissionAmount = handlingCommissionAmount;
			this.commissionUnit = commissionUnit;
			this.vafAmount = vafAmount;
			this.feeUnit = feeUnit;
			this.containerID = containerID;
			this.standardDozenID = standardDozenID;
			this.uPC = uPC;
			this.productCode = productCode;
			this.typeId = typeId;
			this.tax1Exempt = tax1Exempt;
			this.tax2Exempt = tax2Exempt;
			this.masterProductID = masterProductID;
			this.weight = weight;
			this.volume = volume;
			this.targetQuantity = targetQuantity;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ProductID value.
		/// </summary>
		public virtual int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}

		/// <summary>
		/// Gets or sets the ProName value.
		/// </summary>
		public virtual string ProName
		{
			get { return proName; }
			set { proName = value; }
		}

		/// <summary>
		/// Gets or sets the ProDescription value.
		/// </summary>
		public virtual string ProDescription
		{
			get { return proDescription; }
			set { proDescription = value; }
		}

		/// <summary>
		/// Gets or sets the ProShortDescription value.
		/// </summary>
		public virtual string ProShortDescription
		{
			get { return proShortDescription; }
			set { proShortDescription = value; }
		}

		/// <summary>
		/// Gets or sets the ProImage value.
		/// </summary>
		public virtual byte[] ProImage
		{
			get { return proImage; }
			set { proImage = value; }
		}

		/// <summary>
		/// Gets or sets the AgencyID value.
		/// </summary>
		public virtual int AgencyID
		{
			get { return agencyID; }
			set { agencyID = value; }
		}

		/// <summary>
		/// Gets or sets the MenuOrder value.
		/// </summary>
		public virtual int MenuOrder
		{
			get { return menuOrder; }
			set { menuOrder = value; }
		}

		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public virtual bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
		}

		/// <summary>
		/// Gets or sets the Price value.
		/// </summary>
		public virtual decimal Price
		{
			get { return price; }
			set { price = value; }
		}

		/// <summary>
		/// Gets or sets the CategoryID value.
		/// </summary>
		public virtual int CategoryID
		{
			get { return categoryID; }
			set { categoryID = value; }
		}

		/// <summary>
		/// Gets or sets the RefundAmount value.
		/// </summary>
		public virtual decimal RefundAmount
		{
			get { return refundAmount; }
			set { refundAmount = value; }
		}

		/// <summary>
		/// Gets or sets the HandlingCommissionAmount value.
		/// </summary>
		public virtual decimal HandlingCommissionAmount
		{
			get { return handlingCommissionAmount; }
			set { handlingCommissionAmount = value; }
		}

		/// <summary>
		/// Gets or sets the CommissionUnit value.
		/// </summary>
		public virtual int CommissionUnit
		{
			get { return commissionUnit; }
			set { commissionUnit = value; }
		}

		/// <summary>
		/// Gets or sets the VafAmount value.
		/// </summary>
		public virtual decimal VafAmount
		{
			get { return vafAmount; }
			set { vafAmount = value; }
		}

		/// <summary>
		/// Gets or sets the FeeUnit value.
		/// </summary>
		public virtual int FeeUnit
		{
			get { return feeUnit; }
			set { feeUnit = value; }
		}

		/// <summary>
		/// Gets or sets the ContainerID value.
		/// </summary>
		public virtual int ContainerID
		{
			get { return containerID; }
			set { containerID = value; }
		}

		/// <summary>
		/// Gets or sets the StandardDozenID value.
		/// </summary>
		public virtual int StandardDozenID
		{
			get { return standardDozenID; }
			set { standardDozenID = value; }
		}

		/// <summary>
		/// Gets or sets the UPC value.
		/// </summary>
		public virtual string UPC
		{
			get { return uPC; }
			set { uPC = value; }
		}

		/// <summary>
		/// Gets or sets the ProductCode value.
		/// </summary>
		public virtual string ProductCode
		{
			get { return productCode; }
			set { productCode = value; }
		}

		/// <summary>
		/// Gets or sets the TypeId value.
		/// </summary>
		public virtual byte TypeId
		{
			get { return typeId; }
			set { typeId = value; }
		}

		/// <summary>
		/// Gets or sets the Tax1Exempt value.
		/// </summary>
		public virtual bool Tax1Exempt
		{
			get { return tax1Exempt; }
			set { tax1Exempt = value; }
		}

		/// <summary>
		/// Gets or sets the Tax2Exempt value.
		/// </summary>
		public virtual bool Tax2Exempt
		{
			get { return tax2Exempt; }
			set { tax2Exempt = value; }
		}

		/// <summary>
		/// Gets or sets the MasterProductID value.
		/// </summary>
		public virtual int MasterProductID
		{
			get { return masterProductID; }
			set { masterProductID = value; }
		}

		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public virtual decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		/// <summary>
		/// Gets or sets the Volume value.
		/// </summary>
		public virtual decimal Volume
		{
			get { return volume; }
			set { volume = value; }
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
