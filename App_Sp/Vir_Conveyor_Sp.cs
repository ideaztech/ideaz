using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Vir_Conveyor_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Vir_Conveyor_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Vir_Conveyor table.
		/// </summary>
		public virtual void Insert(Vir_Conveyor vir_Conveyor)
		{
			ValidationUtility.ValidateArgument("vir_Conveyor", vir_Conveyor);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorDescription", vir_Conveyor.ConveyorDescription)
			};

			vir_Conveyor.ConveyorID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Vir_Conveyor_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Vir_Conveyor table.
		/// </summary>
		public virtual void Update(Vir_Conveyor vir_Conveyor)
		{
			ValidationUtility.ValidateArgument("vir_Conveyor", vir_Conveyor);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorID", vir_Conveyor.ConveyorID),
				new SqlParameter("@ConveyorDescription", vir_Conveyor.ConveyorDescription)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_Conveyor_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Vir_Conveyor table by its primary key.
		/// </summary>
		public virtual void Delete(int conveyorID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorID", conveyorID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_Conveyor_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Vir_Conveyor table.
		/// </summary>
		public virtual Vir_Conveyor Select(int conveyorID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorID", conveyorID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_Conveyor_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeVir_Conveyor(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Vir_Conveyor table.
		/// </summary>
		public virtual List<Vir_Conveyor> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_Conveyor_SelectAll"))
			{
				List<Vir_Conveyor> vir_ConveyorList = new List<Vir_Conveyor>();
				while (dataReader.Read())
				{
					Vir_Conveyor vir_Conveyor = MakeVir_Conveyor(dataReader);
					vir_ConveyorList.Add(vir_Conveyor);
				}

				return vir_ConveyorList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Vir_Conveyor class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Vir_Conveyor MakeVir_Conveyor(SqlDataReader dataReader)
		{
			Vir_Conveyor vir_Conveyor = new Vir_Conveyor();
			vir_Conveyor.ConveyorID = SqlClientUtility.GetInt32(dataReader, "ConveyorID", 0);
			vir_Conveyor.ConveyorDescription = SqlClientUtility.GetString(dataReader, "ConveyorDescription", String.Empty);

			return vir_Conveyor;
		}

		#endregion
	}
}
