using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Fee_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Fee_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Fees table.
		/// </summary>
		public virtual void Insert(Sol_Fee sol_Fee)
		{
			ValidationUtility.ValidateArgument("sol_Fee", sol_Fee);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@FeeDescription", sol_Fee.FeeDescription),
				new SqlParameter("@FeeAmount", sol_Fee.FeeAmount),
				new SqlParameter("@Percentage", sol_Fee.Percentage)
			};

			sol_Fee.FeeID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Fees_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Fees table.
		/// </summary>
		public virtual void Update(Sol_Fee sol_Fee)
		{
			ValidationUtility.ValidateArgument("sol_Fee", sol_Fee);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@FeeID", sol_Fee.FeeID),
				new SqlParameter("@FeeDescription", sol_Fee.FeeDescription),
				new SqlParameter("@FeeAmount", sol_Fee.FeeAmount),
				new SqlParameter("@Percentage", sol_Fee.Percentage)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Fees_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Fees table by its primary key.
		/// </summary>
		public virtual void Delete(int feeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@FeeID", feeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Fees_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Fees table.
		/// </summary>
		public virtual Sol_Fee Select(int feeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@FeeID", feeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Fees_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Fee(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Fees table.
		/// </summary>
		public virtual List<Sol_Fee> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Fees_SelectAll"))
			{
				List<Sol_Fee> sol_FeeList = new List<Sol_Fee>();
				while (dataReader.Read())
				{
					Sol_Fee sol_Fee = MakeSol_Fee(dataReader);
					sol_FeeList.Add(sol_Fee);
				}

				return sol_FeeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Fees class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Fee MakeSol_Fee(SqlDataReader dataReader)
		{
			Sol_Fee sol_Fee = new Sol_Fee();
			sol_Fee.FeeID = SqlClientUtility.GetInt32(dataReader, "FeeID", 0);
			sol_Fee.FeeDescription = SqlClientUtility.GetString(dataReader, "FeeDescription", String.Empty);
			sol_Fee.FeeAmount = SqlClientUtility.GetDecimal(dataReader, "FeeAmount", Decimal.Zero);
			sol_Fee.Percentage = SqlClientUtility.GetBoolean(dataReader, "Percentage", false);

			return sol_Fee;
		}

		#endregion
	}
}
