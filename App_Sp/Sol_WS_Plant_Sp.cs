using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_WS_Plant_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_WS_Plant_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_WS_Plants table.
		/// </summary>
		public virtual void Insert(Sol_WS_Plant sol_WS_Plant)
		{
			ValidationUtility.ValidateArgument("sol_WS_Plant", sol_WS_Plant);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PlantID", sol_WS_Plant.PlantID),
				new SqlParameter("@Plant", sol_WS_Plant.Plant)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Plants_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_WS_Plants table.
		/// </summary>
		public virtual void Update(Sol_WS_Plant sol_WS_Plant)
		{
			ValidationUtility.ValidateArgument("sol_WS_Plant", sol_WS_Plant);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PlantID", sol_WS_Plant.PlantID),
				new SqlParameter("@Plant", sol_WS_Plant.Plant)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Plants_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_WS_Plants table by its primary key.
		/// </summary>
		public virtual void Delete(int plantID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PlantID", plantID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Plants_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_WS_Plants table.
		/// </summary>
		public virtual Sol_WS_Plant Select(int plantID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PlantID", plantID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Plants_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_WS_Plant(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_WS_Plants table.
		/// </summary>
		public virtual List<Sol_WS_Plant> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Plants_SelectAll"))
			{
				List<Sol_WS_Plant> sol_WS_PlantList = new List<Sol_WS_Plant>();
				while (dataReader.Read())
				{
					Sol_WS_Plant sol_WS_Plant = MakeSol_WS_Plant(dataReader);
					sol_WS_PlantList.Add(sol_WS_Plant);
				}

				return sol_WS_PlantList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_WS_Plants class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_WS_Plant MakeSol_WS_Plant(SqlDataReader dataReader)
		{
			Sol_WS_Plant sol_WS_Plant = new Sol_WS_Plant();
			sol_WS_Plant.PlantID = SqlClientUtility.GetInt32(dataReader, "PlantID", 0);
			sol_WS_Plant.Plant = SqlClientUtility.GetString(dataReader, "Plant", String.Empty);

			return sol_WS_Plant;
		}

		#endregion
	}
}
