using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_Log_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_Log_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_Log table.
		/// </summary>
		public virtual void Insert(Sac_Log sac_Log)
		{
			ValidationUtility.ValidateArgument("sac_Log", sac_Log);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryType", sac_Log.EntryType),
				new SqlParameter("@OrderNumber", sac_Log.OrderNumber),
				new SqlParameter("@OrderAmount", sac_Log.OrderAmount),
				new SqlParameter("@Description", sac_Log.Description),
				new SqlParameter("@Quantityof50", sac_Log.Quantityof50),
				new SqlParameter("@Quantityof20", sac_Log.Quantityof20),
				new SqlParameter("@Quantityof10", sac_Log.Quantityof10),
				new SqlParameter("@Quantityof5", sac_Log.Quantityof5),
				new SqlParameter("@QuantityofToonie", sac_Log.QuantityofToonie),
				new SqlParameter("@QuantityofLoonie", sac_Log.QuantityofLoonie),
				new SqlParameter("@QuantityofQuarter", sac_Log.QuantityofQuarter),
				new SqlParameter("@QuantityofDime", sac_Log.QuantityofDime),
				new SqlParameter("@QuantityofNickel", sac_Log.QuantityofNickel),
				new SqlParameter("@TotalValue", sac_Log.TotalValue),
				new SqlParameter("@Remaining50", sac_Log.Remaining50),
				new SqlParameter("@Remaining20", sac_Log.Remaining20),
				new SqlParameter("@Remaining10", sac_Log.Remaining10),
				new SqlParameter("@Remaining5", sac_Log.Remaining5),
				new SqlParameter("@RemainingToonie", sac_Log.RemainingToonie),
				new SqlParameter("@RemainingLoonie", sac_Log.RemainingLoonie),
				new SqlParameter("@RemainingQuarter", sac_Log.RemainingQuarter),
				new SqlParameter("@RemainingDime", sac_Log.RemainingDime),
				new SqlParameter("@RemainingNickel", sac_Log.RemainingNickel),
				new SqlParameter("@TimeStamp", sac_Log.TimeStamp)
			};

			sac_Log.LogID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sac_Log_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_Log table.
		/// </summary>
		public virtual void Update(Sac_Log sac_Log)
		{
			ValidationUtility.ValidateArgument("sac_Log", sac_Log);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogID", sac_Log.LogID),
				new SqlParameter("@EntryType", sac_Log.EntryType),
				new SqlParameter("@OrderNumber", sac_Log.OrderNumber),
				new SqlParameter("@OrderAmount", sac_Log.OrderAmount),
				new SqlParameter("@Description", sac_Log.Description),
				new SqlParameter("@Quantityof50", sac_Log.Quantityof50),
				new SqlParameter("@Quantityof20", sac_Log.Quantityof20),
				new SqlParameter("@Quantityof10", sac_Log.Quantityof10),
				new SqlParameter("@Quantityof5", sac_Log.Quantityof5),
				new SqlParameter("@QuantityofToonie", sac_Log.QuantityofToonie),
				new SqlParameter("@QuantityofLoonie", sac_Log.QuantityofLoonie),
				new SqlParameter("@QuantityofQuarter", sac_Log.QuantityofQuarter),
				new SqlParameter("@QuantityofDime", sac_Log.QuantityofDime),
				new SqlParameter("@QuantityofNickel", sac_Log.QuantityofNickel),
				new SqlParameter("@TotalValue", sac_Log.TotalValue),
				new SqlParameter("@Remaining50", sac_Log.Remaining50),
				new SqlParameter("@Remaining20", sac_Log.Remaining20),
				new SqlParameter("@Remaining10", sac_Log.Remaining10),
				new SqlParameter("@Remaining5", sac_Log.Remaining5),
				new SqlParameter("@RemainingToonie", sac_Log.RemainingToonie),
				new SqlParameter("@RemainingLoonie", sac_Log.RemainingLoonie),
				new SqlParameter("@RemainingQuarter", sac_Log.RemainingQuarter),
				new SqlParameter("@RemainingDime", sac_Log.RemainingDime),
				new SqlParameter("@RemainingNickel", sac_Log.RemainingNickel),
				new SqlParameter("@TimeStamp", sac_Log.TimeStamp)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Log_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_Log table by its primary key.
		/// </summary>
		public virtual void Delete(int logID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogID", logID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Log_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_Log table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByEntryType(int entryType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryType", entryType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Log_DeleteAllByEntryType", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_Log table.
		/// </summary>
		public virtual Sac_Log Select(int logID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogID", logID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Log_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_Log(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_Log table.
		/// </summary>
		public virtual List<Sac_Log> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Log_SelectAll"))
			{
				List<Sac_Log> sac_LogList = new List<Sac_Log>();
				while (dataReader.Read())
				{
					Sac_Log sac_Log = MakeSac_Log(dataReader);
					sac_LogList.Add(sac_Log);
				}

				return sac_LogList;
			}
		}

		/// <summary>
		/// Selects all records from the Sac_Log table by a foreign key.
		/// </summary>
		public virtual List<Sac_Log> _SelectAllByEntryType(int entryType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryType", entryType)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Log_SelectAllByEntryType", parameters))
			{
				List<Sac_Log> sac_LogList = new List<Sac_Log>();
				while (dataReader.Read())
				{
					Sac_Log sac_Log = MakeSac_Log(dataReader);
					sac_LogList.Add(sac_Log);
				}

				return sac_LogList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_Log class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_Log MakeSac_Log(SqlDataReader dataReader)
		{
			Sac_Log sac_Log = new Sac_Log();
			sac_Log.LogID = SqlClientUtility.GetInt32(dataReader, "LogID", 0);
			sac_Log.EntryType = SqlClientUtility.GetInt32(dataReader, "EntryType", 0);
			sac_Log.OrderNumber = SqlClientUtility.GetInt32(dataReader, "OrderNumber", 0);
			sac_Log.OrderAmount = SqlClientUtility.GetDecimal(dataReader, "OrderAmount", Decimal.Zero);
			sac_Log.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sac_Log.Quantityof50 = SqlClientUtility.GetInt32(dataReader, "Quantityof50", 0);
			sac_Log.Quantityof20 = SqlClientUtility.GetInt32(dataReader, "Quantityof20", 0);
			sac_Log.Quantityof10 = SqlClientUtility.GetInt32(dataReader, "Quantityof10", 0);
			sac_Log.Quantityof5 = SqlClientUtility.GetInt32(dataReader, "Quantityof5", 0);
			sac_Log.QuantityofToonie = SqlClientUtility.GetInt32(dataReader, "QuantityofToonie", 0);
			sac_Log.QuantityofLoonie = SqlClientUtility.GetInt32(dataReader, "QuantityofLoonie", 0);
			sac_Log.QuantityofQuarter = SqlClientUtility.GetInt32(dataReader, "QuantityofQuarter", 0);
			sac_Log.QuantityofDime = SqlClientUtility.GetInt32(dataReader, "QuantityofDime", 0);
			sac_Log.QuantityofNickel = SqlClientUtility.GetInt32(dataReader, "QuantityofNickel", 0);
			sac_Log.TotalValue = SqlClientUtility.GetDecimal(dataReader, "TotalValue", Decimal.Zero);
			sac_Log.Remaining50 = SqlClientUtility.GetInt32(dataReader, "Remaining50", 0);
			sac_Log.Remaining20 = SqlClientUtility.GetInt32(dataReader, "Remaining20", 0);
			sac_Log.Remaining10 = SqlClientUtility.GetInt32(dataReader, "Remaining10", 0);
			sac_Log.Remaining5 = SqlClientUtility.GetInt32(dataReader, "Remaining5", 0);
			sac_Log.RemainingToonie = SqlClientUtility.GetInt32(dataReader, "RemainingToonie", 0);
			sac_Log.RemainingLoonie = SqlClientUtility.GetInt32(dataReader, "RemainingLoonie", 0);
			sac_Log.RemainingQuarter = SqlClientUtility.GetInt32(dataReader, "RemainingQuarter", 0);
			sac_Log.RemainingDime = SqlClientUtility.GetInt32(dataReader, "RemainingDime", 0);
			sac_Log.RemainingNickel = SqlClientUtility.GetInt32(dataReader, "RemainingNickel", 0);
			sac_Log.TimeStamp = SqlClientUtility.GetDateTime(dataReader, "TimeStamp", new DateTime(0));

			return sac_Log;
		}

		#endregion
	}
}
