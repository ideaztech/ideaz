using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Shipment_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Shipment_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Shipment table.
		/// </summary>
		public virtual void Insert(Sol_Shipment sol_Shipment)
		{
			ValidationUtility.ValidateArgument("sol_Shipment", sol_Shipment);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserID", sol_Shipment.UserID),
				new SqlParameter("@UserName", sol_Shipment.UserName),
				new SqlParameter("@RBillNumber", sol_Shipment.RBillNumber),
				new SqlParameter("@Date", sol_Shipment.Date),
				new SqlParameter("@AgencyID", sol_Shipment.AgencyID),
				new SqlParameter("@AgencyName", sol_Shipment.AgencyName),
				new SqlParameter("@AgencyAddress1", sol_Shipment.AgencyAddress1),
				new SqlParameter("@AgencyAddress2", sol_Shipment.AgencyAddress2),
				new SqlParameter("@AgencyCity", sol_Shipment.AgencyCity),
				new SqlParameter("@AgencyProvince", sol_Shipment.AgencyProvince),
				new SqlParameter("@AgencyCountry", sol_Shipment.AgencyCountry),
				new SqlParameter("@AgencyPostalCode", sol_Shipment.AgencyPostalCode),
				new SqlParameter("@Status", sol_Shipment.Status),
				new SqlParameter("@CarrierID", sol_Shipment.CarrierID),
				new SqlParameter("@PlantID", sol_Shipment.PlantID),
				new SqlParameter("@TrailerNumber", sol_Shipment.TrailerNumber),
				new SqlParameter("@ProBillNumber", sol_Shipment.ProBillNumber),
				new SqlParameter("@ShippedDate", sol_Shipment.ShippedDate),
				new SqlParameter("@SealNumber", sol_Shipment.SealNumber),
				new SqlParameter("@LoadReference", sol_Shipment.LoadReference),
				new SqlParameter("@eRBillTransmitted", sol_Shipment.ERBillTransmitted)
			};

			sol_Shipment.ShipmentID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Shipment table.
		/// </summary>
		public virtual void Update(Sol_Shipment sol_Shipment)
		{
			ValidationUtility.ValidateArgument("sol_Shipment", sol_Shipment);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShipmentID", sol_Shipment.ShipmentID),
				new SqlParameter("@UserID", sol_Shipment.UserID),
				new SqlParameter("@UserName", sol_Shipment.UserName),
				new SqlParameter("@RBillNumber", sol_Shipment.RBillNumber),
				new SqlParameter("@Date", sol_Shipment.Date),
				new SqlParameter("@AgencyID", sol_Shipment.AgencyID),
				new SqlParameter("@AgencyName", sol_Shipment.AgencyName),
				new SqlParameter("@AgencyAddress1", sol_Shipment.AgencyAddress1),
				new SqlParameter("@AgencyAddress2", sol_Shipment.AgencyAddress2),
				new SqlParameter("@AgencyCity", sol_Shipment.AgencyCity),
				new SqlParameter("@AgencyProvince", sol_Shipment.AgencyProvince),
				new SqlParameter("@AgencyCountry", sol_Shipment.AgencyCountry),
				new SqlParameter("@AgencyPostalCode", sol_Shipment.AgencyPostalCode),
				new SqlParameter("@Status", sol_Shipment.Status),
				new SqlParameter("@CarrierID", sol_Shipment.CarrierID),
				new SqlParameter("@PlantID", sol_Shipment.PlantID),
				new SqlParameter("@TrailerNumber", sol_Shipment.TrailerNumber),
				new SqlParameter("@ProBillNumber", sol_Shipment.ProBillNumber),
				new SqlParameter("@ShippedDate", sol_Shipment.ShippedDate),
				new SqlParameter("@SealNumber", sol_Shipment.SealNumber),
				new SqlParameter("@LoadReference", sol_Shipment.LoadReference),
				new SqlParameter("@eRBillTransmitted", sol_Shipment.ERBillTransmitted)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Shipment table by its primary key.
		/// </summary>
		public virtual void Delete(int shipmentID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShipmentID", shipmentID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Shipment table.
		/// </summary>
		public virtual Sol_Shipment Select(int shipmentID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShipmentID", shipmentID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Shipment(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Shipment table.
		/// </summary>
		public virtual List<Sol_Shipment> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_SelectAll"))
			{
				List<Sol_Shipment> sol_ShipmentList = new List<Sol_Shipment>();
				while (dataReader.Read())
				{
					Sol_Shipment sol_Shipment = MakeSol_Shipment(dataReader);
					sol_ShipmentList.Add(sol_Shipment);
				}

				return sol_ShipmentList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Shipment class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Shipment MakeSol_Shipment(SqlDataReader dataReader)
		{
			Sol_Shipment sol_Shipment = new Sol_Shipment();
			sol_Shipment.ShipmentID = SqlClientUtility.GetInt32(dataReader, "ShipmentID", 0);
			sol_Shipment.UserID = SqlClientUtility.GetGuid(dataReader, "UserID", Guid.Empty);
			sol_Shipment.UserName = SqlClientUtility.GetString(dataReader, "UserName", String.Empty);
			sol_Shipment.RBillNumber = SqlClientUtility.GetString(dataReader, "RBillNumber", String.Empty);
			sol_Shipment.Date = SqlClientUtility.GetDateTime(dataReader, "Date", new DateTime(0));
			sol_Shipment.AgencyID = SqlClientUtility.GetInt32(dataReader, "AgencyID", 0);
			sol_Shipment.AgencyName = SqlClientUtility.GetString(dataReader, "AgencyName", String.Empty);
			sol_Shipment.AgencyAddress1 = SqlClientUtility.GetString(dataReader, "AgencyAddress1", String.Empty);
			sol_Shipment.AgencyAddress2 = SqlClientUtility.GetString(dataReader, "AgencyAddress2", String.Empty);
			sol_Shipment.AgencyCity = SqlClientUtility.GetString(dataReader, "AgencyCity", String.Empty);
			sol_Shipment.AgencyProvince = SqlClientUtility.GetString(dataReader, "AgencyProvince", String.Empty);
			sol_Shipment.AgencyCountry = SqlClientUtility.GetString(dataReader, "AgencyCountry", String.Empty);
			sol_Shipment.AgencyPostalCode = SqlClientUtility.GetString(dataReader, "AgencyPostalCode", String.Empty);
			sol_Shipment.Status = SqlClientUtility.GetString(dataReader, "Status", String.Empty);
			sol_Shipment.CarrierID = SqlClientUtility.GetInt32(dataReader, "CarrierID", 0);
			sol_Shipment.PlantID = SqlClientUtility.GetInt32(dataReader, "PlantID", 0);
			sol_Shipment.TrailerNumber = SqlClientUtility.GetString(dataReader, "TrailerNumber", String.Empty);
			sol_Shipment.ProBillNumber = SqlClientUtility.GetString(dataReader, "ProBillNumber", String.Empty);
			sol_Shipment.ShippedDate = SqlClientUtility.GetDateTime(dataReader, "ShippedDate", new DateTime(0));
			sol_Shipment.SealNumber = SqlClientUtility.GetString(dataReader, "SealNumber", String.Empty);
			sol_Shipment.LoadReference = SqlClientUtility.GetString(dataReader, "LoadReference", String.Empty);
			sol_Shipment.ERBillTransmitted = SqlClientUtility.GetBoolean(dataReader, "eRBillTransmitted", false);

			return sol_Shipment;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Updates a record in the sol_Shipment table.
        /// </summary>
        public virtual void UpdateERBillTransmitted(int shipmentId, bool eRBillTransmitted)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentId),
                new SqlParameter("@eRBillTransmitted", eRBillTransmitted)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_UpdateERBillTransmitted", parameters);
        }


        /// <summary>
        /// Updates a record in the sol_Shipment table.
        /// </summary>
        public virtual void UpdateERBill(Sol_Shipment sol_Shipment)
        {
            ValidationUtility.ValidateArgument("sol_Shipment", sol_Shipment);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", sol_Shipment.ShipmentID),
                new SqlParameter("@CarrierID", sol_Shipment.CarrierID),
                new SqlParameter("@PlantID", sol_Shipment.PlantID),
                new SqlParameter("@TrailerNumber", sol_Shipment.TrailerNumber),
                new SqlParameter("@ProBillNumber", sol_Shipment.ProBillNumber),
                new SqlParameter("@ShippedDate", sol_Shipment.ShippedDate),
                new SqlParameter("@SealNumber", sol_Shipment.SealNumber),
                new SqlParameter("@LoadReference", sol_Shipment.LoadReference),
                new SqlParameter("@eRBillTransmitted", sol_Shipment.ERBillTransmitted)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_UpdateERBill", parameters);
        }

        /// <summary>
        /// Updates a record in the sol_Shipment table.
        /// </summary>
        public virtual void UpdateStatus(int shipmentId, string status)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShipmentID", shipmentId),
                new SqlParameter("@Status", status)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_UpdateStatus", parameters);
        }


        /// <summary>
        /// Selects all records from the sol_Shipment table.
        /// </summary>
        public virtual List<Sol_Shipment> SelectAllByStatus(string status, bool newestOnTop)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@NewestOnTop", newestOnTop)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_SelectAllByStatus", parameters))
            {
                List<Sol_Shipment> sol_ShipmentList = new List<Sol_Shipment>();
                while (dataReader.Read())
                {
                    Sol_Shipment sol_Shipment = MakeSol_Shipment(dataReader);
                    sol_ShipmentList.Add(sol_Shipment);
                }

                return sol_ShipmentList;
            }
        }

        /// <summary>
        /// Selects a single record from the sol_Shipment table.
        /// </summary>
        public virtual Sol_Shipment SelectByRBillNumber(string rBillNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RBillNumber", rBillNumber)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_SelectByRBillNumber", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Shipment(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Selects all records from the sol_Shipment table.
        /// </summary>
        public virtual List<Sol_Shipment> SelectAllBetweenDatesByStatus(string dateFrom, string dateTo, string status, bool newestOnTop)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DateFrom", dateFrom),
                new SqlParameter("@DateTo", dateTo),
                new SqlParameter("@Status", status),
                new SqlParameter("@NewestOnTop", newestOnTop)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_SelectAllBetweenDatesByStatus", parameters))
            {
                List<Sol_Shipment> sol_ShipmentList = new List<Sol_Shipment>();
                while (dataReader.Read())
                {
                    Sol_Shipment sol_Shipment = MakeSol_Shipment(dataReader);
                    sol_ShipmentList.Add(sol_Shipment);
                }

                return sol_ShipmentList;
            }
        }

        // comment out the original routine
        /// <summary>
        /// Selects all records from the sol_Shipment table.
        /// </summary>
        public virtual List<Sol_Shipment> SelectAll(bool newestOnTop)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NewestOnTop", newestOnTop)
            };
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Shipment_SelectAll", parameters))
            {
                List<Sol_Shipment> sol_ShipmentList = new List<Sol_Shipment>();
                while (dataReader.Read())
                {
                    Sol_Shipment sol_Shipment = MakeSol_Shipment(dataReader);
                    sol_ShipmentList.Add(sol_Shipment);
                }

                return sol_ShipmentList;
            }
        }

        #endregion

    }
}
