using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_StandardDozen_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_StandardDozen_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_StandardDozen table.
		/// </summary>
		public virtual void Insert(Sol_StandardDozen sol_StandardDozen)
		{
			ValidationUtility.ValidateArgument("sol_StandardDozen", sol_StandardDozen);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Quantity", sol_StandardDozen.Quantity)
			};

			sol_StandardDozen.StandardDozenID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_StandardDozen_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_StandardDozen table.
		/// </summary>
		public virtual void Update(Sol_StandardDozen sol_StandardDozen)
		{
			ValidationUtility.ValidateArgument("sol_StandardDozen", sol_StandardDozen);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StandardDozenID", sol_StandardDozen.StandardDozenID),
				new SqlParameter("@Quantity", sol_StandardDozen.Quantity)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_StandardDozen_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_StandardDozen table by its primary key.
		/// </summary>
		public virtual void Delete(int standardDozenID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StandardDozenID", standardDozenID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_StandardDozen_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_StandardDozen table.
		/// </summary>
		public virtual Sol_StandardDozen Select(int standardDozenID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StandardDozenID", standardDozenID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_StandardDozen_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_StandardDozen(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_StandardDozen table.
		/// </summary>
		public virtual List<Sol_StandardDozen> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_StandardDozen_SelectAll"))
			{
				List<Sol_StandardDozen> sol_StandardDozenList = new List<Sol_StandardDozen>();
				while (dataReader.Read())
				{
					Sol_StandardDozen sol_StandardDozen = MakeSol_StandardDozen(dataReader);
					sol_StandardDozenList.Add(sol_StandardDozen);
				}

				return sol_StandardDozenList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_StandardDozen class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_StandardDozen MakeSol_StandardDozen(SqlDataReader dataReader)
		{
			Sol_StandardDozen sol_StandardDozen = new Sol_StandardDozen();
			sol_StandardDozen.StandardDozenID = SqlClientUtility.GetInt32(dataReader, "StandardDozenID", 0);
			sol_StandardDozen.Quantity = SqlClientUtility.GetInt32(dataReader, "Quantity", 0);

			return sol_StandardDozen;
		}

		#endregion
	}
}
