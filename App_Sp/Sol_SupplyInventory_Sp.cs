using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_SupplyInventory_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_SupplyInventory_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_SupplyInventory table.
		/// </summary>
		public virtual void Insert(Sol_SupplyInventory sol_SupplyInventory)
		{
			ValidationUtility.ValidateArgument("sol_SupplyInventory", sol_SupplyInventory);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@SupplyInventoryType", sol_SupplyInventory.SupplyInventoryType),
				new SqlParameter("@UserID", sol_SupplyInventory.UserID),
				new SqlParameter("@Date", sol_SupplyInventory.Date),
				new SqlParameter("@DateOrdered", sol_SupplyInventory.DateOrdered),
				new SqlParameter("@ProductID", sol_SupplyInventory.ProductID),
				new SqlParameter("@ContainerID", sol_SupplyInventory.ContainerID),
				new SqlParameter("@Quantity", sol_SupplyInventory.Quantity),
				new SqlParameter("@ShipmentID", sol_SupplyInventory.ShipmentID),
				new SqlParameter("@ReferenceNumber", sol_SupplyInventory.ReferenceNumber)
			};

			sol_SupplyInventory.SupplyInventoryID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_SupplyInventory table.
		/// </summary>
		public virtual void Update(Sol_SupplyInventory sol_SupplyInventory)
		{
			ValidationUtility.ValidateArgument("sol_SupplyInventory", sol_SupplyInventory);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@SupplyInventoryID", sol_SupplyInventory.SupplyInventoryID),
				new SqlParameter("@SupplyInventoryType", sol_SupplyInventory.SupplyInventoryType),
				new SqlParameter("@UserID", sol_SupplyInventory.UserID),
				new SqlParameter("@Date", sol_SupplyInventory.Date),
				new SqlParameter("@DateOrdered", sol_SupplyInventory.DateOrdered),
				new SqlParameter("@ProductID", sol_SupplyInventory.ProductID),
				new SqlParameter("@ContainerID", sol_SupplyInventory.ContainerID),
				new SqlParameter("@Quantity", sol_SupplyInventory.Quantity),
				new SqlParameter("@ShipmentID", sol_SupplyInventory.ShipmentID),
				new SqlParameter("@ReferenceNumber", sol_SupplyInventory.ReferenceNumber)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_SupplyInventory table by its primary key.
		/// </summary>
		public virtual void Delete(int supplyInventoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@SupplyInventoryID", supplyInventoryID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_SupplyInventory table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByContainerID(int containerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerID", containerID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_DeleteAllByContainerID", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_SupplyInventory table.
		/// </summary>
		public virtual Sol_SupplyInventory Select(int supplyInventoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@SupplyInventoryID", supplyInventoryID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_SupplyInventory(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_SupplyInventory table.
		/// </summary>
		public virtual List<Sol_SupplyInventory> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_SelectAll"))
			{
				List<Sol_SupplyInventory> sol_SupplyInventoryList = new List<Sol_SupplyInventory>();
				while (dataReader.Read())
				{
					Sol_SupplyInventory sol_SupplyInventory = MakeSol_SupplyInventory(dataReader);
					sol_SupplyInventoryList.Add(sol_SupplyInventory);
				}

				return sol_SupplyInventoryList;
			}
		}

		/// <summary>
		/// Selects all records from the Sol_SupplyInventory table by a foreign key.
		/// </summary>
		public virtual List<Sol_SupplyInventory> _SelectAllByContainerID(int containerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerID", containerID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_SelectAllByContainerID", parameters))
			{
				List<Sol_SupplyInventory> sol_SupplyInventoryList = new List<Sol_SupplyInventory>();
				while (dataReader.Read())
				{
					Sol_SupplyInventory sol_SupplyInventory = MakeSol_SupplyInventory(dataReader);
					sol_SupplyInventoryList.Add(sol_SupplyInventory);
				}

				return sol_SupplyInventoryList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_SupplyInventory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_SupplyInventory MakeSol_SupplyInventory(SqlDataReader dataReader)
		{
			Sol_SupplyInventory sol_SupplyInventory = new Sol_SupplyInventory();
			sol_SupplyInventory.SupplyInventoryID = SqlClientUtility.GetInt32(dataReader, "SupplyInventoryID", 0);
			sol_SupplyInventory.SupplyInventoryType = SqlClientUtility.GetString(dataReader, "SupplyInventoryType", String.Empty);
			sol_SupplyInventory.UserID = SqlClientUtility.GetGuid(dataReader, "UserID", Guid.Empty);
			sol_SupplyInventory.Date = SqlClientUtility.GetDateTime(dataReader, "Date", new DateTime(0));
			sol_SupplyInventory.DateOrdered = SqlClientUtility.GetDateTime(dataReader, "DateOrdered", new DateTime(0));
			sol_SupplyInventory.ProductID = SqlClientUtility.GetInt32(dataReader, "ProductID", 0);
			sol_SupplyInventory.ContainerID = SqlClientUtility.GetInt32(dataReader, "ContainerID", 0);
			sol_SupplyInventory.Quantity = SqlClientUtility.GetInt32(dataReader, "Quantity", 0);
			sol_SupplyInventory.ShipmentID = SqlClientUtility.GetInt32(dataReader, "ShipmentID", 0);
			sol_SupplyInventory.ReferenceNumber = SqlClientUtility.GetString(dataReader, "ReferenceNumber", String.Empty);

			return sol_SupplyInventory;
		}

        #endregion

        #region aditional methods

        /// <summary>
        /// Selects all records from the Sol_SupplyInventory table by a foreign key.
        /// </summary>
        public virtual List<Sol_SupplyInventory> _SelectAllByShipmentID(int shipmentID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_SelectAllByShipmentID", parameters))
            {
                List<Sol_SupplyInventory> sol_SupplyInventoryList = new List<Sol_SupplyInventory>();
                while (dataReader.Read())
                {
                    Sol_SupplyInventory sol_SupplyInventory = MakeSol_SupplyInventory(dataReader);
                    sol_SupplyInventoryList.Add(sol_SupplyInventory);
                }

                return sol_SupplyInventoryList;
            }
        }

        /// <summary>
        /// Deletes a record from the Sol_SupplyInventory table by a foreign key.
        /// </summary>
        public virtual void _DeleteAllByShipmentID(int shipmentID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentID)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_SupplyInventory_DeleteAllByShipmentID", parameters);
        }


        #endregion

    }
}
