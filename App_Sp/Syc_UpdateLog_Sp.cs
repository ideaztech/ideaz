using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Syc_UpdateLog_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Syc_UpdateLog_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Syc_UpdateLog table.
		/// </summary>
		public virtual void Insert(Syc_UpdateLog syc_UpdateLog)
		{
			ValidationUtility.ValidateArgument("syc_UpdateLog", syc_UpdateLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@TableName", syc_UpdateLog.TableName),
				new SqlParameter("@IDName", syc_UpdateLog.IDName),
				new SqlParameter("@IDValue", syc_UpdateLog.IDValue),
				new SqlParameter("@ColumnName", syc_UpdateLog.ColumnName),
				new SqlParameter("@ColumnData", syc_UpdateLog.ColumnData)
			};

			syc_UpdateLog.TempID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Syc_UpdateLog_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Syc_UpdateLog table.
		/// </summary>
		public virtual void Update(Syc_UpdateLog syc_UpdateLog)
		{
			ValidationUtility.ValidateArgument("syc_UpdateLog", syc_UpdateLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@TempID", syc_UpdateLog.TempID),
				new SqlParameter("@TableName", syc_UpdateLog.TableName),
				new SqlParameter("@IDName", syc_UpdateLog.IDName),
				new SqlParameter("@IDValue", syc_UpdateLog.IDValue),
				new SqlParameter("@ColumnName", syc_UpdateLog.ColumnName),
				new SqlParameter("@ColumnData", syc_UpdateLog.ColumnData)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Syc_UpdateLog_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Syc_UpdateLog table by its primary key.
		/// </summary>
		public virtual void Delete(int tempID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@TempID", tempID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Syc_UpdateLog_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Syc_UpdateLog table.
		/// </summary>
		public virtual Syc_UpdateLog Select(int tempID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@TempID", tempID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Syc_UpdateLog_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSyc_UpdateLog(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Syc_UpdateLog table.
		/// </summary>
		public virtual List<Syc_UpdateLog> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Syc_UpdateLog_SelectAll"))
			{
				List<Syc_UpdateLog> syc_UpdateLogList = new List<Syc_UpdateLog>();
				while (dataReader.Read())
				{
					Syc_UpdateLog syc_UpdateLog = MakeSyc_UpdateLog(dataReader);
					syc_UpdateLogList.Add(syc_UpdateLog);
				}

				return syc_UpdateLogList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Syc_UpdateLog class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Syc_UpdateLog MakeSyc_UpdateLog(SqlDataReader dataReader)
		{
			Syc_UpdateLog syc_UpdateLog = new Syc_UpdateLog();
			syc_UpdateLog.TempID = SqlClientUtility.GetInt32(dataReader, "TempID", 0);
			syc_UpdateLog.TableName = SqlClientUtility.GetString(dataReader, "TableName", String.Empty);
			syc_UpdateLog.IDName = SqlClientUtility.GetString(dataReader, "IDName", String.Empty);
			syc_UpdateLog.IDValue = SqlClientUtility.GetInt32(dataReader, "IDValue", 0);
			syc_UpdateLog.ColumnName = SqlClientUtility.GetString(dataReader, "ColumnName", String.Empty);
			syc_UpdateLog.ColumnData = SqlClientUtility.GetString(dataReader, "ColumnData", String.Empty);

			return syc_UpdateLog;
		}

		#endregion
	}
}
