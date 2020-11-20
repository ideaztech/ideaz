using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_EmployeesLog_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_EmployeesLog_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_EmployeesLog table.
		/// </summary>
		public virtual void Insert(Sol_EmployeesLog sol_EmployeesLog)
		{
			ValidationUtility.ValidateArgument("sol_EmployeesLog", sol_EmployeesLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", sol_EmployeesLog.UserId),
				new SqlParameter("@PunchInTime", sol_EmployeesLog.PunchInTime),
				new SqlParameter("@PunchOutTime", sol_EmployeesLog.PunchOutTime),
				new SqlParameter("@Comments", sol_EmployeesLog.Comments),
				new SqlParameter("@Approved", sol_EmployeesLog.Approved),
				new SqlParameter("@Modified", sol_EmployeesLog.Modified)
			};

			sol_EmployeesLog.LogId = (long) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_EmployeesLog table.
		/// </summary>
		public virtual void Update(Sol_EmployeesLog sol_EmployeesLog)
		{
			ValidationUtility.ValidateArgument("sol_EmployeesLog", sol_EmployeesLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogId", sol_EmployeesLog.LogId),
				new SqlParameter("@UserId", sol_EmployeesLog.UserId),
				new SqlParameter("@PunchInTime", sol_EmployeesLog.PunchInTime),
				new SqlParameter("@PunchOutTime", sol_EmployeesLog.PunchOutTime),
				new SqlParameter("@Comments", sol_EmployeesLog.Comments),
				new SqlParameter("@Approved", sol_EmployeesLog.Approved),
				new SqlParameter("@Modified", sol_EmployeesLog.Modified)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_EmployeesLog table by its primary key.
		/// </summary>
		public virtual void Delete(long logId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogId", logId)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_EmployeesLog table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByUserId(Guid userId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_DeleteAllByUserId", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_EmployeesLog table.
		/// </summary>
		public virtual Sol_EmployeesLog Select(long logId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogId", logId)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_EmployeesLog(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_EmployeesLog table.
		/// </summary>
		public virtual List<Sol_EmployeesLog> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_SelectAll"))
			{
				List<Sol_EmployeesLog> sol_EmployeesLogList = new List<Sol_EmployeesLog>();
				while (dataReader.Read())
				{
					Sol_EmployeesLog sol_EmployeesLog = MakeSol_EmployeesLog(dataReader);
					sol_EmployeesLogList.Add(sol_EmployeesLog);
				}

				return sol_EmployeesLogList;
			}
		}

		/// <summary>
		/// Selects all records from the Sol_EmployeesLog table by a foreign key.
		/// </summary>
		public virtual List<Sol_EmployeesLog> _SelectAllByUserId(Guid userId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_SelectAllByUserId", parameters))
			{
				List<Sol_EmployeesLog> sol_EmployeesLogList = new List<Sol_EmployeesLog>();
				while (dataReader.Read())
				{
					Sol_EmployeesLog sol_EmployeesLog = MakeSol_EmployeesLog(dataReader);
					sol_EmployeesLogList.Add(sol_EmployeesLog);
				}

				return sol_EmployeesLogList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_EmployeesLog class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_EmployeesLog MakeSol_EmployeesLog(SqlDataReader dataReader)
		{
			Sol_EmployeesLog sol_EmployeesLog = new Sol_EmployeesLog();
			sol_EmployeesLog.LogId = SqlClientUtility.GetInt64(dataReader, "LogId", 0);
			sol_EmployeesLog.UserId = SqlClientUtility.GetGuid(dataReader, "UserId", Guid.Empty);
			sol_EmployeesLog.PunchInTime = SqlClientUtility.GetDateTime(dataReader, "PunchInTime", new DateTime(0));
			sol_EmployeesLog.PunchOutTime = SqlClientUtility.GetDateTime(dataReader, "PunchOutTime", new DateTime(0));
			sol_EmployeesLog.Comments = SqlClientUtility.GetString(dataReader, "Comments", String.Empty);
			sol_EmployeesLog.Approved = SqlClientUtility.GetBoolean(dataReader, "Approved", false);
			sol_EmployeesLog.Modified = SqlClientUtility.GetBoolean(dataReader, "Modified", false);

			return sol_EmployeesLog;
		}

        #endregion

        #region Aditional Methods

        /// <summary>
        /// Selects last pucnh in and out from the Sol_EmployeesLog table.
        /// </summary>
        public virtual Sol_EmployeesLog LastPunch(string userId)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_EmployeesLog_LastPunch", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_EmployeesLog(dataReader);
                }
                else
                {
                    return null;
                }
            }

        }

        #endregion
    }
}
