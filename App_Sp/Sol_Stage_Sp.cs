using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Stage_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Stage_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Stage table.
		/// </summary>
		public virtual void Insert(Sol_Stage sol_Stage)
		{
			ValidationUtility.ValidateArgument("sol_Stage", sol_Stage);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShipmentID", sol_Stage.ShipmentID),
				new SqlParameter("@UserID", sol_Stage.UserID),
				new SqlParameter("@UserName", sol_Stage.UserName),
				new SqlParameter("@Date", sol_Stage.Date),
				new SqlParameter("@TagNumber", sol_Stage.TagNumber),
				new SqlParameter("@ContainerID", sol_Stage.ContainerID),
				new SqlParameter("@ContainerDescription", sol_Stage.ContainerDescription),
				new SqlParameter("@ProductID", sol_Stage.ProductID),
				new SqlParameter("@ProductName", sol_Stage.ProductName),
				new SqlParameter("@Dozen", sol_Stage.Dozen),
				new SqlParameter("@Quantity", sol_Stage.Quantity),
				new SqlParameter("@Price", sol_Stage.Price),
				new SqlParameter("@Remarks", sol_Stage.Remarks),
				new SqlParameter("@Status", sol_Stage.Status),
				new SqlParameter("@DateClosed", sol_Stage.DateClosed)
			};

			sol_Stage.StageID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Stage_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Stage table.
		/// </summary>
		public virtual void Update(Sol_Stage sol_Stage)
		{
			ValidationUtility.ValidateArgument("sol_Stage", sol_Stage);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StageID", sol_Stage.StageID),
				new SqlParameter("@ShipmentID", sol_Stage.ShipmentID),
				new SqlParameter("@UserID", sol_Stage.UserID),
				new SqlParameter("@UserName", sol_Stage.UserName),
				new SqlParameter("@Date", sol_Stage.Date),
				new SqlParameter("@TagNumber", sol_Stage.TagNumber),
				new SqlParameter("@ContainerID", sol_Stage.ContainerID),
				new SqlParameter("@ContainerDescription", sol_Stage.ContainerDescription),
				new SqlParameter("@ProductID", sol_Stage.ProductID),
				new SqlParameter("@ProductName", sol_Stage.ProductName),
				new SqlParameter("@Dozen", sol_Stage.Dozen),
				new SqlParameter("@Quantity", sol_Stage.Quantity),
				new SqlParameter("@Price", sol_Stage.Price),
				new SqlParameter("@Remarks", sol_Stage.Remarks),
				new SqlParameter("@Status", sol_Stage.Status),
				new SqlParameter("@DateClosed", sol_Stage.DateClosed)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Stage_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Stage table by its primary key.
		/// </summary>
		public virtual void Delete(int stageID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StageID", stageID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Stage_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Stage table.
		/// </summary>
		public virtual Sol_Stage Select(int stageID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StageID", stageID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Stage(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Stage table.
		/// </summary>
		public virtual List<Sol_Stage> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_SelectAll"))
			{
				List<Sol_Stage> sol_StageList = new List<Sol_Stage>();
				while (dataReader.Read())
				{
					Sol_Stage sol_Stage = MakeSol_Stage(dataReader);
					sol_StageList.Add(sol_Stage);
				}

				return sol_StageList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Stage class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Stage MakeSol_Stage(SqlDataReader dataReader)
		{
			Sol_Stage sol_Stage = new Sol_Stage();
			sol_Stage.StageID = SqlClientUtility.GetInt32(dataReader, "StageID", 0);
			sol_Stage.ShipmentID = SqlClientUtility.GetInt32(dataReader, "ShipmentID", 0);
			sol_Stage.UserID = SqlClientUtility.GetGuid(dataReader, "UserID", Guid.Empty);
			sol_Stage.UserName = SqlClientUtility.GetString(dataReader, "UserName", String.Empty);
			sol_Stage.Date = SqlClientUtility.GetDateTime(dataReader, "Date", new DateTime(0));
			sol_Stage.TagNumber = SqlClientUtility.GetString(dataReader, "TagNumber", String.Empty);
			sol_Stage.ContainerID = SqlClientUtility.GetInt32(dataReader, "ContainerID", 0);
			sol_Stage.ContainerDescription = SqlClientUtility.GetString(dataReader, "ContainerDescription", String.Empty);
			sol_Stage.ProductID = SqlClientUtility.GetInt32(dataReader, "ProductID", 0);
			sol_Stage.ProductName = SqlClientUtility.GetString(dataReader, "ProductName", String.Empty);
			sol_Stage.Dozen = SqlClientUtility.GetInt32(dataReader, "Dozen", 0);
			sol_Stage.Quantity = SqlClientUtility.GetInt32(dataReader, "Quantity", 0);
			sol_Stage.Price = SqlClientUtility.GetDecimal(dataReader, "Price", Decimal.Zero);
			sol_Stage.Remarks = SqlClientUtility.GetString(dataReader, "Remarks", String.Empty);
			sol_Stage.Status = SqlClientUtility.GetString(dataReader, "Status", String.Empty);
			sol_Stage.DateClosed = SqlClientUtility.GetDateTime(dataReader, "DateClosed", new DateTime(0));

			return sol_Stage;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Selects all records from the sol_Stage table by a foreign key.
        /// </summary>
        public virtual List<Sol_Stage> _SelectAllByShipmentID(int shipmentID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_SelectAllByShipmentID", parameters))
            {
                List<Sol_Stage> sol_StageList = new List<Sol_Stage>();
                while (dataReader.Read())
                {
                    Sol_Stage sol_Stage = MakeSol_Stage(dataReader);
                    sol_StageList.Add(sol_Stage);
                }

                return sol_StageList;
            }
        }


        /// <summary>
        /// Deletes a record from the sol_Stage table by a foreign key.
        /// </summary>
        public virtual void _DeleteAllByShipmentIdTagNumber(int shipmentID, string tagNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentID),
                new SqlParameter("@TagNumber", tagNumber)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Stage_DeleteAllByShipmentIdTagNumber", parameters);
        }



        /// <summary>
        /// Selects all records from the sol_Stage table by a foreign key.
        /// </summary>
        public virtual Sol_Stage _SelectByShipmentIdContainerId(int shipmentId, int containerId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentId),
                new SqlParameter("@ContainerID", containerId)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_SelectByShipmentIdContainerId", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Stage(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Selects all records from the sol_Stage table by a foreign key.
        /// </summary>
        public virtual List<Sol_Stage> _SelectAllByAgency(string status, int agency)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@Agency", agency)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_SelectAllByAgency", parameters))
            {
                List<Sol_Stage> sol_StageList = new List<Sol_Stage>();
                while (dataReader.Read())
                {
                    Sol_Stage sol_Stage = MakeSol_Stage(dataReader);
                    sol_StageList.Add(sol_Stage);
                }

                return sol_StageList;
            }
        }


        /// <summary>
        /// Selects all records from the sol_Stage table by a foreign key.
        /// </summary>
        public virtual List<Sol_Stage> _SelectAllByAgencyClosed(string status, int agency)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@Agency", agency)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_SelectAllByAgencyClosed", parameters))
            {
                List<Sol_Stage> sol_StageList = new List<Sol_Stage>();
                while (dataReader.Read())
                {
                    Sol_Stage sol_Stage = MakeSol_Stage(dataReader);
                    sol_StageList.Add(sol_Stage);
                }

                return sol_StageList;
            }
        }

        /// <summary>
        /// Selects all records from the sol_Stage table by a foreign key.
        /// </summary>
        public virtual List<Sol_Stage> _SelectAllByStatus(string status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_SelectAllByStatus", parameters))
            {
                List<Sol_Stage> sol_StageList = new List<Sol_Stage>();
                while (dataReader.Read())
                {
                    Sol_Stage sol_Stage = MakeSol_Stage(dataReader);
                    sol_StageList.Add(sol_Stage);
                }

                return sol_StageList;
            }
        }

        /// <summary>
        /// Selects all records from the sol_Stage table by a foreign key.
        /// </summary>
        public virtual Sol_Stage _SelectByTagNumberStatus(string tagNumber, string status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TagNumber", tagNumber),
                new SqlParameter("@Status", status)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Stage_SelectByTagNumberStatus", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Stage(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Updates a record in the sol_Stage table.
        /// </summary>
        public virtual void UpdateStatus(int shipmentId, string tagNumber, string statusOld, string status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentId),
                new SqlParameter("@TagNumber", tagNumber),
                new SqlParameter("@StatusOld", statusOld),
                new SqlParameter("@Status", status)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Stage_UpdateStatus", parameters);
        }


        /// <summary>
        /// Updates a record in the sol_Stage table.
        /// </summary>
        public virtual void UpdateStatusByShipmentId(int shipmentId, string status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentId),
                new SqlParameter("@Status", status)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Stage_UpdateStatusByShipmentId", parameters);
        }

        #endregion

    }
}
