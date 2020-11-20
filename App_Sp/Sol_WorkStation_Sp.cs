using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_WorkStation_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_WorkStation_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_WorkStations table.
		/// </summary>
		public virtual void Insert(Sol_WorkStation sol_WorkStation)
		{
			ValidationUtility.ValidateArgument("sol_WorkStation", sol_WorkStation);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sol_WorkStation.Name),
				new SqlParameter("@Description", sol_WorkStation.Description),
				new SqlParameter("@Location", sol_WorkStation.Location),
				new SqlParameter("@ConveyorID", sol_WorkStation.ConveyorID)
			};

			sol_WorkStation.WorkStationID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_WorkStations table.
		/// </summary>
		public virtual void Update(Sol_WorkStation sol_WorkStation)
		{
			ValidationUtility.ValidateArgument("sol_WorkStation", sol_WorkStation);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@WorkStationID", sol_WorkStation.WorkStationID),
				new SqlParameter("@Name", sol_WorkStation.Name),
				new SqlParameter("@Description", sol_WorkStation.Description),
				new SqlParameter("@Location", sol_WorkStation.Location),
				new SqlParameter("@ConveyorID", sol_WorkStation.ConveyorID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_WorkStations table by its primary key.
		/// </summary>
		public virtual void Delete(int workStationID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@WorkStationID", workStationID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_WorkStations table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByConveyorID(int conveyorID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorID", conveyorID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_DeleteAllByConveyorID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_WorkStations table.
		/// </summary>
		public virtual Sol_WorkStation Select(int workStationID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@WorkStationID", workStationID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_WorkStation(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_WorkStations table.
		/// </summary>
		public virtual List<Sol_WorkStation> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_SelectAll"))
			{
				List<Sol_WorkStation> sol_WorkStationList = new List<Sol_WorkStation>();
				while (dataReader.Read())
				{
					Sol_WorkStation sol_WorkStation = MakeSol_WorkStation(dataReader);
					sol_WorkStationList.Add(sol_WorkStation);
				}

				return sol_WorkStationList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_WorkStations table by a foreign key.
		/// </summary>
		public virtual List<Sol_WorkStation> _SelectAllByConveyorID(int conveyorID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorID", conveyorID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_SelectAllByConveyorID", parameters))
			{
				List<Sol_WorkStation> sol_WorkStationList = new List<Sol_WorkStation>();
				while (dataReader.Read())
				{
					Sol_WorkStation sol_WorkStation = MakeSol_WorkStation(dataReader);
					sol_WorkStationList.Add(sol_WorkStation);
				}

				return sol_WorkStationList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_WorkStations class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_WorkStation MakeSol_WorkStation(SqlDataReader dataReader)
		{
			Sol_WorkStation sol_WorkStation = new Sol_WorkStation();
			sol_WorkStation.WorkStationID = SqlClientUtility.GetInt32(dataReader, "WorkStationID", 0);
			sol_WorkStation.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sol_WorkStation.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_WorkStation.Location = SqlClientUtility.GetString(dataReader, "Location", String.Empty);
			sol_WorkStation.ConveyorID = SqlClientUtility.GetInt32(dataReader, "ConveyorID", 0);

			return sol_WorkStation;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Selects a single record from the sol_WorkStations table.
        /// </summary>
        public virtual Sol_WorkStation SelectByName(string name)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_WorkStations_SelectByName", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_WorkStation(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

    }
}
