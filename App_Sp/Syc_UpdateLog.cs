using System;

namespace Solum
{
	public class Syc_UpdateLog
	{
		#region Fields

		private int tempID;
		private string tableName;
		private string iDName;
		private int iDValue;
		private string columnName;
		private string columnData;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Syc_UpdateLog class.
		/// </summary>
		public Syc_UpdateLog()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Syc_UpdateLog class.
		/// </summary>
		public Syc_UpdateLog(string tableName, string iDName, int iDValue, string columnName, string columnData)
		{
			this.tableName = tableName;
			this.iDName = iDName;
			this.iDValue = iDValue;
			this.columnName = columnName;
			this.columnData = columnData;
		}

		/// <summary>
		/// Initializes a new instance of the Syc_UpdateLog class.
		/// </summary>
		public Syc_UpdateLog(int tempID, string tableName, string iDName, int iDValue, string columnName, string columnData)
		{
			this.tempID = tempID;
			this.tableName = tableName;
			this.iDName = iDName;
			this.iDValue = iDValue;
			this.columnName = columnName;
			this.columnData = columnData;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the TempID value.
		/// </summary>
		public virtual int TempID
		{
			get { return tempID; }
			set { tempID = value; }
		}

		/// <summary>
		/// Gets or sets the TableName value.
		/// </summary>
		public virtual string TableName
		{
			get { return tableName; }
			set { tableName = value; }
		}

		/// <summary>
		/// Gets or sets the IDName value.
		/// </summary>
		public virtual string IDName
		{
			get { return iDName; }
			set { iDName = value; }
		}

		/// <summary>
		/// Gets or sets the IDValue value.
		/// </summary>
		public virtual int IDValue
		{
			get { return iDValue; }
			set { iDValue = value; }
		}

		/// <summary>
		/// Gets or sets the ColumnName value.
		/// </summary>
		public virtual string ColumnName
		{
			get { return columnName; }
			set { columnName = value; }
		}

		/// <summary>
		/// Gets or sets the ColumnData value.
		/// </summary>
		public virtual string ColumnData
		{
			get { return columnData; }
			set { columnData = value; }
		}

		#endregion
	}
}
