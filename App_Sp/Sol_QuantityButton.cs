using System;

namespace Solum
{
	public class Sol_QuantityButton
	{
		#region Fields

		private int quantityButtonID;
		private int workStationID;
		private byte controlType;
		private string description;
		private int defaultQuantity;
		private int categoryID;
		private int locationX;
		private int locationY;
		private int width;
		private int height;
		private string font;
		private string fontStyle;
		private string foreColor;
		private string backColor;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_QuantityButton class.
		/// </summary>
		public Sol_QuantityButton()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_QuantityButton class.
		/// </summary>
		public Sol_QuantityButton(int workStationID, byte controlType, string description, int defaultQuantity, int categoryID, int locationX, int locationY, int width, int height, string font, string fontStyle, string foreColor, string backColor)
		{
			this.workStationID = workStationID;
			this.controlType = controlType;
			this.description = description;
			this.defaultQuantity = defaultQuantity;
			this.categoryID = categoryID;
			this.locationX = locationX;
			this.locationY = locationY;
			this.width = width;
			this.height = height;
			this.font = font;
			this.fontStyle = fontStyle;
			this.foreColor = foreColor;
			this.backColor = backColor;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_QuantityButton class.
		/// </summary>
		public Sol_QuantityButton(int quantityButtonID, int workStationID, byte controlType, string description, int defaultQuantity, int categoryID, int locationX, int locationY, int width, int height, string font, string fontStyle, string foreColor, string backColor)
		{
			this.quantityButtonID = quantityButtonID;
			this.workStationID = workStationID;
			this.controlType = controlType;
			this.description = description;
			this.defaultQuantity = defaultQuantity;
			this.categoryID = categoryID;
			this.locationX = locationX;
			this.locationY = locationY;
			this.width = width;
			this.height = height;
			this.font = font;
			this.fontStyle = fontStyle;
			this.foreColor = foreColor;
			this.backColor = backColor;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the QuantityButtonID value.
		/// </summary>
		public virtual int QuantityButtonID
		{
			get { return quantityButtonID; }
			set { quantityButtonID = value; }
		}

		/// <summary>
		/// Gets or sets the WorkStationID value.
		/// </summary>
		public virtual int WorkStationID
		{
			get { return workStationID; }
			set { workStationID = value; }
		}

		/// <summary>
		/// Gets or sets the ControlType value.
		/// </summary>
		public virtual byte ControlType
		{
			get { return controlType; }
			set { controlType = value; }
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
		/// Gets or sets the DefaultQuantity value.
		/// </summary>
		public virtual int DefaultQuantity
		{
			get { return defaultQuantity; }
			set { defaultQuantity = value; }
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
		/// Gets or sets the LocationX value.
		/// </summary>
		public virtual int LocationX
		{
			get { return locationX; }
			set { locationX = value; }
		}

		/// <summary>
		/// Gets or sets the LocationY value.
		/// </summary>
		public virtual int LocationY
		{
			get { return locationY; }
			set { locationY = value; }
		}

		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public virtual int Width
		{
			get { return width; }
			set { width = value; }
		}

		/// <summary>
		/// Gets or sets the Height value.
		/// </summary>
		public virtual int Height
		{
			get { return height; }
			set { height = value; }
		}

		/// <summary>
		/// Gets or sets the Font value.
		/// </summary>
		public virtual string Font
		{
			get { return font; }
			set { font = value; }
		}

		/// <summary>
		/// Gets or sets the FontStyle value.
		/// </summary>
		public virtual string FontStyle
		{
			get { return fontStyle; }
			set { fontStyle = value; }
		}

		/// <summary>
		/// Gets or sets the ForeColor value.
		/// </summary>
		public virtual string ForeColor
		{
			get { return foreColor; }
			set { foreColor = value; }
		}

		/// <summary>
		/// Gets or sets the BackColor value.
		/// </summary>
		public virtual string BackColor
		{
			get { return backColor; }
			set { backColor = value; }
		}

		#endregion
	}
}
