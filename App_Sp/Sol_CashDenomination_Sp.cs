using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_CashDenomination_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_CashDenomination_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_CashDenominations table.
		/// </summary>
		public virtual void Insert(Sol_CashDenomination sol_CashDenomination)
		{
			ValidationUtility.ValidateArgument("sol_CashDenomination", sol_CashDenomination);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashType", sol_CashDenomination.CashType),
				new SqlParameter("@CashValue", sol_CashDenomination.CashValue),
				new SqlParameter("@Description", sol_CashDenomination.Description),
				new SqlParameter("@OrderValue", sol_CashDenomination.OrderValue),
				new SqlParameter("@CashItemValue", sol_CashDenomination.CashItemValue),
				new SqlParameter("@Quantity", sol_CashDenomination.Quantity),
				new SqlParameter("@MoneyID", sol_CashDenomination.MoneyID)
			};

			sol_CashDenomination.CashID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_CashDenominations_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_CashDenominations table.
		/// </summary>
		public virtual void Update(Sol_CashDenomination sol_CashDenomination)
		{
			ValidationUtility.ValidateArgument("sol_CashDenomination", sol_CashDenomination);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashID", sol_CashDenomination.CashID),
				new SqlParameter("@CashType", sol_CashDenomination.CashType),
				new SqlParameter("@CashValue", sol_CashDenomination.CashValue),
				new SqlParameter("@Description", sol_CashDenomination.Description),
				new SqlParameter("@OrderValue", sol_CashDenomination.OrderValue),
				new SqlParameter("@CashItemValue", sol_CashDenomination.CashItemValue),
				new SqlParameter("@Quantity", sol_CashDenomination.Quantity),
				new SqlParameter("@MoneyID", sol_CashDenomination.MoneyID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CashDenominations_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_CashDenominations table by its primary key.
		/// </summary>
		public virtual void Delete(int cashID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashID", cashID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CashDenominations_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_CashDenominations table.
		/// </summary>
		public virtual Sol_CashDenomination Select(int cashID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashID", cashID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CashDenominations_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_CashDenomination(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_CashDenominations table.
		/// </summary>
		public virtual List<Sol_CashDenomination> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CashDenominations_SelectAll"))
			{
				List<Sol_CashDenomination> sol_CashDenominationList = new List<Sol_CashDenomination>();
				while (dataReader.Read())
				{
					Sol_CashDenomination sol_CashDenomination = MakeSol_CashDenomination(dataReader);
					sol_CashDenominationList.Add(sol_CashDenomination);
				}

				return sol_CashDenominationList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_CashDenominations class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_CashDenomination MakeSol_CashDenomination(SqlDataReader dataReader)
		{
			Sol_CashDenomination sol_CashDenomination = new Sol_CashDenomination();
			sol_CashDenomination.CashID = SqlClientUtility.GetInt32(dataReader, "CashID", 0);
			sol_CashDenomination.CashType = SqlClientUtility.GetByte(dataReader, "CashType", 0x00);
			sol_CashDenomination.CashValue = SqlClientUtility.GetDecimal(dataReader, "CashValue", Decimal.Zero);
			sol_CashDenomination.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_CashDenomination.OrderValue = SqlClientUtility.GetInt16(dataReader, "OrderValue", 0);
			sol_CashDenomination.CashItemValue = SqlClientUtility.GetDecimal(dataReader, "CashItemValue", Decimal.Zero);
			sol_CashDenomination.Quantity = SqlClientUtility.GetInt32(dataReader, "Quantity", 0);
			sol_CashDenomination.MoneyID = SqlClientUtility.GetInt32(dataReader, "MoneyID", 0);

			return sol_CashDenomination;
		}

		#endregion
	}
}
