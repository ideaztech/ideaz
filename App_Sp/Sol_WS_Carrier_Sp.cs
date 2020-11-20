using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_WS_Carrier_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_WS_Carrier_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_WS_Carriers table.
		/// </summary>
		public virtual void Insert(Sol_WS_Carrier sol_WS_Carrier)
		{
			ValidationUtility.ValidateArgument("sol_WS_Carrier", sol_WS_Carrier);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CarrierID", sol_WS_Carrier.CarrierID),
				new SqlParameter("@Carrier", sol_WS_Carrier.Carrier)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Carriers_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_WS_Carriers table.
		/// </summary>
		public virtual void Update(Sol_WS_Carrier sol_WS_Carrier)
		{
			ValidationUtility.ValidateArgument("sol_WS_Carrier", sol_WS_Carrier);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CarrierID", sol_WS_Carrier.CarrierID),
				new SqlParameter("@Carrier", sol_WS_Carrier.Carrier)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Carriers_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_WS_Carriers table by its primary key.
		/// </summary>
		public virtual void Delete(int carrierID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CarrierID", carrierID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Carriers_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_WS_Carriers table.
		/// </summary>
		public virtual Sol_WS_Carrier Select(int carrierID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CarrierID", carrierID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Carriers_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_WS_Carrier(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_WS_Carriers table.
		/// </summary>
		public virtual List<Sol_WS_Carrier> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_Carriers_SelectAll"))
			{
				List<Sol_WS_Carrier> sol_WS_CarrierList = new List<Sol_WS_Carrier>();
				while (dataReader.Read())
				{
					Sol_WS_Carrier sol_WS_Carrier = MakeSol_WS_Carrier(dataReader);
					sol_WS_CarrierList.Add(sol_WS_Carrier);
				}

				return sol_WS_CarrierList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_WS_Carriers class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_WS_Carrier MakeSol_WS_Carrier(SqlDataReader dataReader)
		{
			Sol_WS_Carrier sol_WS_Carrier = new Sol_WS_Carrier();
			sol_WS_Carrier.CarrierID = SqlClientUtility.GetInt32(dataReader, "CarrierID", 0);
			sol_WS_Carrier.Carrier = SqlClientUtility.GetString(dataReader, "Carrier", String.Empty);

			return sol_WS_Carrier;
		}

		#endregion
	}
}
