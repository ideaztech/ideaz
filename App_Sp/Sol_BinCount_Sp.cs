using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_BinCount_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_BinCount_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_BinCount table.
		/// </summary>
		public virtual void Insert(Sol_BinCount sol_BinCount)
		{
			ValidationUtility.ValidateArgument("sol_BinCount", sol_BinCount);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", sol_BinCount.ClientID),
				new SqlParameter("@CategoryButtonID", sol_BinCount.CategoryButtonID),
				new SqlParameter("@CurrentCount", sol_BinCount.CurrentCount)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_BinCount_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_BinCount table.
		/// </summary>
		public virtual void Update(Sol_BinCount sol_BinCount)
		{
			ValidationUtility.ValidateArgument("sol_BinCount", sol_BinCount);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", sol_BinCount.ClientID),
				new SqlParameter("@CategoryButtonID", sol_BinCount.CategoryButtonID),
				new SqlParameter("@CurrentCount", sol_BinCount.CurrentCount)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_BinCount_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_BinCount table by its primary key.
		/// </summary>
		public virtual void Delete(string clientID, int categoryButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", clientID),
				new SqlParameter("@CategoryButtonID", categoryButtonID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_BinCount_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_BinCount table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCategoryButtonID(int categoryButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryButtonID", categoryButtonID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_BinCount_DeleteAllByCategoryButtonID", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_BinCount table.
		/// </summary>
		public virtual Sol_BinCount Select(string clientID, int categoryButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", clientID),
				new SqlParameter("@CategoryButtonID", categoryButtonID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_BinCount_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_BinCount(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_BinCount table.
		/// </summary>
		public virtual List<Sol_BinCount> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_BinCount_SelectAll"))
			{
				List<Sol_BinCount> sol_BinCountList = new List<Sol_BinCount>();
				while (dataReader.Read())
				{
					Sol_BinCount sol_BinCount = MakeSol_BinCount(dataReader);
					sol_BinCountList.Add(sol_BinCount);
				}

				return sol_BinCountList;
			}
		}

		/// <summary>
		/// Selects all records from the Sol_BinCount table by a foreign key.
		/// </summary>
		public virtual List<Sol_BinCount> _SelectAllByCategoryButtonID(int categoryButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryButtonID", categoryButtonID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_BinCount_SelectAllByCategoryButtonID", parameters))
			{
				List<Sol_BinCount> sol_BinCountList = new List<Sol_BinCount>();
				while (dataReader.Read())
				{
					Sol_BinCount sol_BinCount = MakeSol_BinCount(dataReader);
					sol_BinCountList.Add(sol_BinCount);
				}

				return sol_BinCountList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_BinCount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_BinCount MakeSol_BinCount(SqlDataReader dataReader)
		{
			Sol_BinCount sol_BinCount = new Sol_BinCount();
			sol_BinCount.ClientID = SqlClientUtility.GetString(dataReader, "ClientID", String.Empty);
			sol_BinCount.CategoryButtonID = SqlClientUtility.GetInt32(dataReader, "CategoryButtonID", 0);
			sol_BinCount.CurrentCount = SqlClientUtility.GetInt32(dataReader, "CurrentCount", 0);

			return sol_BinCount;
		}

		#endregion
	}
}
