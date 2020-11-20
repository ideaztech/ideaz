using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_CashTray_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_CashTray_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_CashTrays table.
		/// </summary>
		public virtual void Insert(Sol_CashTray sol_CashTray)
		{
			ValidationUtility.ValidateArgument("sol_CashTray", sol_CashTray);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Description", sol_CashTray.Description),
				new SqlParameter("@WorkStationID", sol_CashTray.WorkStationID),
				new SqlParameter("@UserID", sol_CashTray.UserID),
				new SqlParameter("@UserName", sol_CashTray.UserName)
			};

			sol_CashTray.CashTrayID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_CashTrays_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_CashTrays table.
		/// </summary>
		public virtual void Update(Sol_CashTray sol_CashTray)
		{
			ValidationUtility.ValidateArgument("sol_CashTray", sol_CashTray);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashTrayID", sol_CashTray.CashTrayID),
				new SqlParameter("@Description", sol_CashTray.Description),
				new SqlParameter("@WorkStationID", sol_CashTray.WorkStationID),
				new SqlParameter("@UserID", sol_CashTray.UserID),
				new SqlParameter("@UserName", sol_CashTray.UserName)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CashTrays_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_CashTrays table by its primary key.
		/// </summary>
		public virtual void Delete(int cashTrayID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashTrayID", cashTrayID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CashTrays_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_CashTrays table.
		/// </summary>
		public virtual Sol_CashTray Select(int cashTrayID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashTrayID", cashTrayID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CashTrays_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_CashTray(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_CashTrays table.
		/// </summary>
		public virtual List<Sol_CashTray> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CashTrays_SelectAll"))
			{
				List<Sol_CashTray> sol_CashTrayList = new List<Sol_CashTray>();
				while (dataReader.Read())
				{
					Sol_CashTray sol_CashTray = MakeSol_CashTray(dataReader);
					sol_CashTrayList.Add(sol_CashTray);
				}

				return sol_CashTrayList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_CashTrays class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_CashTray MakeSol_CashTray(SqlDataReader dataReader)
		{
			Sol_CashTray sol_CashTray = new Sol_CashTray();
			sol_CashTray.CashTrayID = SqlClientUtility.GetInt32(dataReader, "CashTrayID", 0);
			sol_CashTray.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_CashTray.WorkStationID = SqlClientUtility.GetInt32(dataReader, "WorkStationID", 0);
			sol_CashTray.UserID = SqlClientUtility.GetGuid(dataReader, "UserID", Guid.Empty);
			sol_CashTray.UserName = SqlClientUtility.GetString(dataReader, "UserName", String.Empty);

			return sol_CashTray;
		}

		#endregion
	}
}
