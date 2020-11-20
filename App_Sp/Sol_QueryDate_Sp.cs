using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_QueryDate_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_QueryDate_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_QueryDate table.
		/// </summary>
		public virtual void Insert(Sol_QueryDate sol_QueryDate)
		{
			ValidationUtility.ValidateArgument("sol_QueryDate", sol_QueryDate);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DateFrom", sol_QueryDate.DateFrom),
				new SqlParameter("@DateTo", sol_QueryDate.DateTo),
				new SqlParameter("@UserName", sol_QueryDate.UserName)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_QueryDate_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_QueryDate table.
		/// </summary>
		public virtual void Update(Sol_QueryDate sol_QueryDate)
		{
			ValidationUtility.ValidateArgument("sol_QueryDate", sol_QueryDate);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DateFrom", sol_QueryDate.DateFrom),
				new SqlParameter("@DateTo", sol_QueryDate.DateTo),
				new SqlParameter("@UserName", sol_QueryDate.UserName)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_QueryDate_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_QueryDate table by its primary key.
		/// </summary>
		public virtual void Delete(string userName)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DateFrom", dateFrom)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_QueryDate_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_QueryDate table.
		/// </summary>
		public virtual Sol_QueryDate Select(string userName)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DateFrom", dateFrom)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_QueryDate_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_QueryDate(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_QueryDate table.
		/// </summary>
		public virtual List<Sol_QueryDate> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_QueryDate_SelectAll"))
			{
				List<Sol_QueryDate> sol_QueryDateList = new List<Sol_QueryDate>();
				while (dataReader.Read())
				{
					Sol_QueryDate sol_QueryDate = MakeSol_QueryDate(dataReader);
					sol_QueryDateList.Add(sol_QueryDate);
				}

				return sol_QueryDateList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_QueryDate class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_QueryDate MakeSol_QueryDate(SqlDataReader dataReader)
		{
			Sol_QueryDate sol_QueryDate = new Sol_QueryDate();
			sol_QueryDate.DateFrom = SqlClientUtility.GetDateTime(dataReader, "DateFrom", new DateTime(0));
			sol_QueryDate.DateTo = SqlClientUtility.GetDateTime(dataReader, "DateTo", new DateTime(0));
			sol_QueryDate.UserName = SqlClientUtility.GetString(dataReader, "UserName", String.Empty);

			return sol_QueryDate;
		}

		#endregion
	}
}
