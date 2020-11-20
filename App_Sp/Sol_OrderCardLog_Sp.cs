using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_OrderCardLog_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_OrderCardLog_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_OrderCardLog table.
		/// </summary>
		public virtual void Insert(Sol_OrderCardLog sol_OrderCardLog)
		{
			ValidationUtility.ValidateArgument("sol_OrderCardLog", sol_OrderCardLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardNumber", sol_OrderCardLog.CardNumber),
				new SqlParameter("@OrderID", sol_OrderCardLog.OrderID),
				new SqlParameter("@DateAdded", sol_OrderCardLog.DateAdded),
				new SqlParameter("@DatePaid", sol_OrderCardLog.DatePaid)
			};

			sol_OrderCardLog.LogID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLog_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_OrderCardLog table.
		/// </summary>
		public virtual void Update(Sol_OrderCardLog sol_OrderCardLog)
		{
			ValidationUtility.ValidateArgument("sol_OrderCardLog", sol_OrderCardLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogID", sol_OrderCardLog.LogID),
				new SqlParameter("@CardNumber", sol_OrderCardLog.CardNumber),
				new SqlParameter("@OrderID", sol_OrderCardLog.OrderID),
				new SqlParameter("@DateAdded", sol_OrderCardLog.DateAdded),
				new SqlParameter("@DatePaid", sol_OrderCardLog.DatePaid)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLog_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_OrderCardLog table by its primary key.
		/// </summary>
		public virtual void Delete(string cardNumber, int orderID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				//new SqlParameter("@LogID", logID),
                new SqlParameter("@CardNumber", cardNumber),
                new SqlParameter("@CardNumber", cardNumber)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLog_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_OrderCardLog table.
		/// </summary>
		public virtual Sol_OrderCardLog Select(string cardNumber, int orderID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				//new SqlParameter("@LogID", logID),
				new SqlParameter("@CardNumber", cardNumber),
                new SqlParameter("@OrderID", orderID),
            };

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLog_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_OrderCardLog(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_OrderCardLog table.
		/// </summary>
		public virtual List<Sol_OrderCardLog> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLog_SelectAll"))
			{
				List<Sol_OrderCardLog> sol_OrderCardLogList = new List<Sol_OrderCardLog>();
				while (dataReader.Read())
				{
					Sol_OrderCardLog sol_OrderCardLog = MakeSol_OrderCardLog(dataReader);
					sol_OrderCardLogList.Add(sol_OrderCardLog);
				}

				return sol_OrderCardLogList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_OrderCardLog class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_OrderCardLog MakeSol_OrderCardLog(SqlDataReader dataReader)
		{
			Sol_OrderCardLog sol_OrderCardLog = new Sol_OrderCardLog();
			sol_OrderCardLog.LogID = SqlClientUtility.GetInt32(dataReader, "LogID", 0);
			sol_OrderCardLog.CardNumber = SqlClientUtility.GetString(dataReader, "CardNumber", String.Empty);
			sol_OrderCardLog.OrderID = SqlClientUtility.GetInt32(dataReader, "OrderID", 0);
			sol_OrderCardLog.DateAdded = SqlClientUtility.GetDateTime(dataReader, "DateAdded", new DateTime(0));
			sol_OrderCardLog.DatePaid = SqlClientUtility.GetDateTime(dataReader, "DatePaid", new DateTime(0));

			return sol_OrderCardLog;
		}

		#endregion
	}
}
