using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_ExpenseType_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_ExpenseType_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_ExpenseTypes table.
		/// </summary>
		public virtual void Insert(Sol_ExpenseType sol_ExpenseType)
		{
			ValidationUtility.ValidateArgument("sol_ExpenseType", sol_ExpenseType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Description", sol_ExpenseType.Description)
			};

			sol_ExpenseType.ExpenseTypeID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_ExpenseTypes_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_ExpenseTypes table.
		/// </summary>
		public virtual void Update(Sol_ExpenseType sol_ExpenseType)
		{
			ValidationUtility.ValidateArgument("sol_ExpenseType", sol_ExpenseType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ExpenseTypeID", sol_ExpenseType.ExpenseTypeID),
				new SqlParameter("@Description", sol_ExpenseType.Description)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_ExpenseTypes_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_ExpenseTypes table by its primary key.
		/// </summary>
		public virtual void Delete(int expenseTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ExpenseTypeID", expenseTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_ExpenseTypes_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_ExpenseTypes table.
		/// </summary>
		public virtual Sol_ExpenseType Select(int expenseTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ExpenseTypeID", expenseTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_ExpenseTypes_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_ExpenseType(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_ExpenseTypes table.
		/// </summary>
		public virtual List<Sol_ExpenseType> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_ExpenseTypes_SelectAll"))
			{
				List<Sol_ExpenseType> sol_ExpenseTypeList = new List<Sol_ExpenseType>();
				while (dataReader.Read())
				{
					Sol_ExpenseType sol_ExpenseType = MakeSol_ExpenseType(dataReader);
					sol_ExpenseTypeList.Add(sol_ExpenseType);
				}

				return sol_ExpenseTypeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_ExpenseTypes class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_ExpenseType MakeSol_ExpenseType(SqlDataReader dataReader)
		{
			Sol_ExpenseType sol_ExpenseType = new Sol_ExpenseType();
			sol_ExpenseType.ExpenseTypeID = SqlClientUtility.GetInt32(dataReader, "ExpenseTypeID", 0);
			sol_ExpenseType.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);

			return sol_ExpenseType;
		}

		#endregion
	}
}
