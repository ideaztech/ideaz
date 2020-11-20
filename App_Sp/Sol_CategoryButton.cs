using System;

namespace Solum
{
	public class Sol_CategoryButton
	{
		#region Fields

		private int categoryButtonID;
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
		private int imageIndex;
		private string imagePath;
		private int subContainerMaxCount;
		private int subContainerCounter;
		private byte imageSize;
		private bool subContainerCountDown;
		private int maxCountPerLine;
		private int foreColorArgb;
		private int backColorArgb;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Sol_CategoryButton class.
		/// </summary>
		public Sol_CategoryButton()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Sol_CategoryButton class.
		/// </summary>
		public Sol_CategoryButton(int workStationID, byte controlType, string description, int defaultQuantity, int categoryID, int locationX, int locationY, int width, int height, string font, string fontStyle, string foreColor, string backColor, int imageIndex, string imagePath, int subContainerMaxCount, int subContainerCounter, byte imageSize, bool subContainerCountDown, int maxCountPerLine, int foreColorArgb, int backColorArgb)
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
			this.imageIndex = imageIndex;
			this.imagePath = imagePath;
			this.subContainerMaxCount = subContainerMaxCount;
			this.subContainerCounter = subContainerCounter;
			this.imageSize = imageSize;
			this.subContainerCountDown = subContainerCountDown;
			this.maxCountPerLine = maxCountPerLine;
			this.foreColorArgb = foreColorArgb;
			this.backColorArgb = backColorArgb;
		}

		/// <summary>
		/// Initializes a new instance of the Sol_CategoryButton class.
		/// </summary>
		public Sol_CategoryButton(int categoryButtonID, int workStationID, byte controlType, string description, int defaultQuantity, int categoryID, int locationX, int locationY, int width, int height, string font, string fontStyle, string foreColor, string backColor, int imageIndex, string imagePath, int subContainerMaxCount, int subContainerCounter, byte imageSize, bool subContainerCountDown, int maxCountPerLine, int foreColorArgb, int backColorArgb)
		{
			this.categoryButtonID = categoryButtonID;
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
			this.imageIndex = imageIndex;
			this.imagePath = imagePath;
			this.subContainerMaxCount = subContainerMaxCount;
			this.subContainerCounter = subContainerCounter;
			this.imageSize = imageSize;
			this.subContainerCountDown = subContainerCountDown;
			this.maxCountPerLine = maxCountPerLine;
			this.foreColorArgb = foreColorArgb;
			this.backColorArgb = backColorArgb;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CategoryButtonID value.
		/// </summary>
		public virtual int CategoryButtonID
		{
			get { return categoryButtonID; }
			set { categoryButtonID = value; }
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

		/// <summary>
		/// Gets or sets the ImageIndex value.
		/// </summary>
		public virtual int ImageIndex
		{
			get { return imageIndex; }
			set { imageIndex = value; }
		}

		/// <summary>
		/// Gets or sets the ImagePath value.
		/// </summary>
		public virtual string ImagePath
		{
			get { return imagePath; }
			set { imagePath = value; }
		}

		/// <summary>
		/// Gets or sets the SubContainerMaxCount value.
		/// </summary>
		public virtual int SubContainerMaxCount
		{
			get { return subContainerMaxCount; }
			set { subContainerMaxCount = value; }
		}

		/// <summary>
		/// Gets or sets the SubContainerCounter value.
		/// </summary>
		public virtual int SubContainerCounter
		{
			get { return subContainerCounter; }
			set { subContainerCounter = value; }
		}

		/// <summary>
		/// Gets or sets the ImageSize value.
		/// </summary>
		public virtual byte ImageSize
		{
			get { return imageSize; }
			set { imageSize = value; }
		}

		/// <summary>
		/// Gets or sets the SubContainerCountDown value.
		/// </summary>
		public virtual bool SubContainerCountDown
		{
			get { return subContainerCountDown; }
			set { subContainerCountDown = value; }
		}

		/// <summary>
		/// Gets or sets the MaxCountPerLine value.
		/// </summary>
		public virtual int MaxCountPerLine
		{
			get { return maxCountPerLine; }
			set { maxCountPerLine = value; }
		}

		/// <summary>
		/// Gets or sets the ForeColorArgb value.
		/// </summary>
		public virtual int ForeColorArgb
		{
			get { return foreColorArgb; }
			set { foreColorArgb = value; }
		}

		/// <summary>
		/// Gets or sets the BackColorArgb value.
		/// </summary>
		public virtual int BackColorArgb
		{
			get { return backColorArgb; }
			set { backColorArgb = value; }
		}

		#endregion
	}
}
