using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Order_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Order_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Orders table.
		/// </summary>
		public virtual void Insert(Sol_Order sol_Order)
		{
			ValidationUtility.ValidateArgument("sol_Order", sol_Order);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@OrderType", sol_Order.OrderType),
				new SqlParameter("@WorkStationID", sol_Order.WorkStationID),
				new SqlParameter("@ComputerName", sol_Order.ComputerName),
				new SqlParameter("@UserID", sol_Order.UserID),
				new SqlParameter("@UserName", sol_Order.UserName),
				new SqlParameter("@Date", sol_Order.Date),
				new SqlParameter("@CashTrayID", sol_Order.CashTrayID),
				new SqlParameter("@CustomerID", sol_Order.CustomerID),
				new SqlParameter("@Name", sol_Order.Name),
				new SqlParameter("@Address1", sol_Order.Address1),
				new SqlParameter("@Address2", sol_Order.Address2),
				new SqlParameter("@City", sol_Order.City),
				new SqlParameter("@Province", sol_Order.Province),
				new SqlParameter("@Country", sol_Order.Country),
				new SqlParameter("@PostalCode", sol_Order.PostalCode),
				new SqlParameter("@TotalAmount", sol_Order.TotalAmount),
				new SqlParameter("@DateClosed", sol_Order.DateClosed),
				new SqlParameter("@DatePaid", sol_Order.DatePaid),
				new SqlParameter("@FeeID", sol_Order.FeeID),
				new SqlParameter("@FeeAmount", sol_Order.FeeAmount),
				new SqlParameter("@Tax1Amount", sol_Order.Tax1Amount),
				new SqlParameter("@Tax2Amount", sol_Order.Tax2Amount),
				new SqlParameter("@Status", sol_Order.Status),
				new SqlParameter("@Reference", sol_Order.Reference),
				new SqlParameter("@PaymentTypeID", sol_Order.PaymentTypeID),
				//new SqlParameter("@SecurityCode", sol_Order.SecurityCode),
				new SqlParameter("@Comments", sol_Order.Comments)
    //            ,
				//new SqlParameter("@IsNew", sol_Order.IsNew)
			};

			sol_Order.OrderID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Orders_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Orders table.
		/// </summary>
		public virtual void Update(Sol_Order sol_Order)
		{
			ValidationUtility.ValidateArgument("sol_Order", sol_Order);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@OrderID", sol_Order.OrderID),
				new SqlParameter("@OrderType", sol_Order.OrderType),
				new SqlParameter("@WorkStationID", sol_Order.WorkStationID),
				new SqlParameter("@ComputerName", sol_Order.ComputerName),
				new SqlParameter("@UserID", sol_Order.UserID),
				new SqlParameter("@UserName", sol_Order.UserName),
				new SqlParameter("@Date", sol_Order.Date),
				new SqlParameter("@CashTrayID", sol_Order.CashTrayID),
				new SqlParameter("@CustomerID", sol_Order.CustomerID),
				new SqlParameter("@Name", sol_Order.Name),
				new SqlParameter("@Address1", sol_Order.Address1),
				new SqlParameter("@Address2", sol_Order.Address2),
				new SqlParameter("@City", sol_Order.City),
				new SqlParameter("@Province", sol_Order.Province),
				new SqlParameter("@Country", sol_Order.Country),
				new SqlParameter("@PostalCode", sol_Order.PostalCode),
				new SqlParameter("@TotalAmount", sol_Order.TotalAmount),
				new SqlParameter("@DateClosed", sol_Order.DateClosed),
				new SqlParameter("@DatePaid", sol_Order.DatePaid),
				new SqlParameter("@FeeID", sol_Order.FeeID),
				new SqlParameter("@FeeAmount", sol_Order.FeeAmount),
				new SqlParameter("@Tax1Amount", sol_Order.Tax1Amount),
				new SqlParameter("@Tax2Amount", sol_Order.Tax2Amount),
				new SqlParameter("@Status", sol_Order.Status),
				new SqlParameter("@Reference", sol_Order.Reference),
				new SqlParameter("@PaymentTypeID", sol_Order.PaymentTypeID),
				new SqlParameter("@SecurityCode", sol_Order.SecurityCode),
				new SqlParameter("@Comments", sol_Order.Comments)
    //            ,
				//new SqlParameter("@IsNew", sol_Order.IsNew)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Orders table by its primary key.
		/// </summary>
		public virtual void Delete(int orderID, string orderType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@OrderID", orderID),
				new SqlParameter("@OrderType", orderType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Orders table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCashTrayID(int cashTrayID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashTrayID", cashTrayID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_DeleteAllByCashTrayID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Orders table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCustomerID(int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", customerID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_DeleteAllByCustomerID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Orders table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByFeeID(int feeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@FeeID", feeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_DeleteAllByFeeID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Orders table.
		/// </summary>
		public virtual Sol_Order Select(int orderID, string orderType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@OrderID", orderID),
				new SqlParameter("@OrderType", orderType)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Order(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Orders table.
		/// </summary>
		public virtual List<Sol_Order> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectAll"))
			{
				List<Sol_Order> sol_OrderList = new List<Sol_Order>();
				while (dataReader.Read())
				{
					Sol_Order sol_Order = MakeSol_Order(dataReader);
					sol_OrderList.Add(sol_Order);
				}

				return sol_OrderList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Orders table by a foreign key.
		/// </summary>
		public virtual List<Sol_Order> _SelectAllByCashTrayID(int cashTrayID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashTrayID", cashTrayID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectAllByCashTrayID", parameters))
			{
				List<Sol_Order> sol_OrderList = new List<Sol_Order>();
				while (dataReader.Read())
				{
					Sol_Order sol_Order = MakeSol_Order(dataReader);
					sol_OrderList.Add(sol_Order);
				}

				return sol_OrderList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Orders table by a foreign key.
		/// </summary>
		public virtual List<Sol_Order> _SelectAllByCustomerID(string orderType, int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@CustomerID", customerID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectAllByCustomerID", parameters))
			{
				List<Sol_Order> sol_OrderList = new List<Sol_Order>();
				while (dataReader.Read())
				{
					Sol_Order sol_Order = MakeSol_Order(dataReader);
					sol_OrderList.Add(sol_Order);
				}

				return sol_OrderList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Orders table by a foreign key.
		/// </summary>
		public virtual List<Sol_Order> _SelectAllByFeeID(int feeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@FeeID", feeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectAllByFeeID", parameters))
			{
				List<Sol_Order> sol_OrderList = new List<Sol_Order>();
				while (dataReader.Read())
				{
					Sol_Order sol_Order = MakeSol_Order(dataReader);
					sol_OrderList.Add(sol_Order);
				}

				return sol_OrderList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Orders class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Order MakeSol_Order(SqlDataReader dataReader)
		{
			Sol_Order sol_Order = new Sol_Order();
			sol_Order.OrderID = SqlClientUtility.GetInt32(dataReader, "OrderID", 0);
			sol_Order.OrderType = SqlClientUtility.GetString(dataReader, "OrderType", String.Empty);
			sol_Order.WorkStationID = SqlClientUtility.GetInt32(dataReader, "WorkStationID", 0);
			sol_Order.ComputerName = SqlClientUtility.GetString(dataReader, "ComputerName", String.Empty);
			sol_Order.UserID = SqlClientUtility.GetGuid(dataReader, "UserID", Guid.Empty);
			sol_Order.UserName = SqlClientUtility.GetString(dataReader, "UserName", String.Empty);
			sol_Order.Date = SqlClientUtility.GetDateTime(dataReader, "Date", new DateTime(0));
			sol_Order.CashTrayID = SqlClientUtility.GetInt32(dataReader, "CashTrayID", 0);
			sol_Order.CustomerID = SqlClientUtility.GetInt32(dataReader, "CustomerID", 0);
			sol_Order.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sol_Order.Address1 = SqlClientUtility.GetString(dataReader, "Address1", String.Empty);
			sol_Order.Address2 = SqlClientUtility.GetString(dataReader, "Address2", String.Empty);
			sol_Order.City = SqlClientUtility.GetString(dataReader, "City", String.Empty);
			sol_Order.Province = SqlClientUtility.GetString(dataReader, "Province", String.Empty);
			sol_Order.Country = SqlClientUtility.GetString(dataReader, "Country", String.Empty);
			sol_Order.PostalCode = SqlClientUtility.GetString(dataReader, "PostalCode", String.Empty);
			sol_Order.TotalAmount = SqlClientUtility.GetDecimal(dataReader, "TotalAmount", Decimal.Zero);
			sol_Order.DateClosed = SqlClientUtility.GetDateTime(dataReader, "DateClosed", new DateTime(0));
			sol_Order.DatePaid = SqlClientUtility.GetDateTime(dataReader, "DatePaid", new DateTime(0));
			sol_Order.FeeID = SqlClientUtility.GetInt32(dataReader, "FeeID", 0);
			sol_Order.FeeAmount = SqlClientUtility.GetDecimal(dataReader, "FeeAmount", Decimal.Zero);
			sol_Order.Tax1Amount = SqlClientUtility.GetDecimal(dataReader, "Tax1Amount", Decimal.Zero);
			sol_Order.Tax2Amount = SqlClientUtility.GetDecimal(dataReader, "Tax2Amount", Decimal.Zero);
			sol_Order.Status = SqlClientUtility.GetString(dataReader, "Status", String.Empty);
			sol_Order.Reference = SqlClientUtility.GetString(dataReader, "Reference", String.Empty);
			sol_Order.PaymentTypeID = SqlClientUtility.GetByte(dataReader, "PaymentTypeID", 0x00);
			sol_Order.SecurityCode = SqlClientUtility.GetString(dataReader, "SecurityCode", String.Empty);
			sol_Order.Comments = SqlClientUtility.GetString(dataReader, "Comments", String.Empty);
			//sol_Order.IsNew = SqlClientUtility.GetBoolean(dataReader, "IsNew", false);

			return sol_Order;
		}

        #endregion

        #region Aditional Methods

        /// <summary>
        /// Selects all records from the sol_Orders table by a foreign key.
        /// </summary>
        public virtual List<Sol_Order> _SelectAllBy(string orderType, string status, int customerID, string dateFrom, string dateTo)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@Status", status),
                new SqlParameter("@CustomerID", customerID),
                   new SqlParameter("@DateFrom", dateFrom),
                new SqlParameter("@DateTo", dateTo)

            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectAllBy", parameters))
            {
                List<Sol_Order> sol_OrderList = new List<Sol_Order>();
                while (dataReader.Read())
                {
                    Sol_Order sol_Order = MakeSol_Order(dataReader);
                    sol_OrderList.Add(sol_Order);
                }

                return sol_OrderList;
            }
        }

        /// <summary>
        /// Selects all records from the sol_Orders table by a foreign key.
        /// </summary>
        public virtual void _UpdateCustomerID(int orderID, string orderType, int customerID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@CustomerID", customerID)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_UpdateCustomerID", parameters);
        }

        /// <summary>
        /// Selects a single record from the sol_Orders table.
        /// </summary>
        public virtual Sol_Order SelectWithSecCode(int orderID, string securityCode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@SecurityCode", securityCode)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectWithSecCode", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Order(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// Updates a record in the sol_Orders table.
        /// </summary>
        public virtual void UpdateDates(int orderID, string orderType, string date, string dateField)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@Date", date),
                new SqlParameter("@DateField", dateField)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_UpdateDates", parameters);
        }


        public virtual List<Sol_Order> SelectAllByCustomerUnpaid(string orderType, int customerID, bool unPaid)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@CustomerID", customerID),
                new SqlParameter("@UnPaid", unPaid)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectAllByCustomerUnPaid", parameters))
            {
                List<Sol_Order> sol_OrderList = new List<Sol_Order>();
                while (dataReader.Read())
                {
                    Sol_Order sol_Order = MakeSol_Order(dataReader);
                    sol_OrderList.Add(sol_Order);
                }

                return sol_OrderList;
            }
        }


        /// <summary>
        /// Selects all records from the sol_Orders table by a foreign key.
        /// </summary>
        public virtual List<Sol_Order> _SelectAllByStatus(string orderType, string status, int customerID, string dateFrom, string dateTo)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@Status", status),
                new SqlParameter("@CustomerID", customerID),
                   new SqlParameter("@DateFrom", dateFrom),
                new SqlParameter("@DateTo", dateTo)

            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectAllByStatus", parameters))
            {
                List<Sol_Order> sol_OrderList = new List<Sol_Order>();
                while (dataReader.Read())
                {
                    Sol_Order sol_Order = MakeSol_Order(dataReader);
                    sol_OrderList.Add(sol_Order);
                }

                return sol_OrderList;
            }
        }


        /// <summary>
        /// Selects all records from the sol_Orders table by a foreign key.
        /// </summary>
        public virtual Sol_Order _SelectByOrderID(int orderID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_SelectByOrderID", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Order(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Updates a record in the sol_Orders table.
        /// </summary>
        public virtual void UpdateStatus(int orderID, string orderType, string status)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@Status", status)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_UpdateStatus", parameters);
        }

        /// <summary>
        /// Selects a single record from the sol_Orders table.
        /// </summary>
        public virtual void CheckIntegrity(
            int orderID, string orderType,
            ref decimal @TotalAmount,
            ref decimal @DetailTotalAmount
            )
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@OrderType", orderType)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Orders_CheckIntegrity", parameters))
            {
                if (dataReader.Read())
                {
                    @TotalAmount = SqlClientUtility.GetDecimal(dataReader, "TotalAmount", Decimal.Zero);
                    @DetailTotalAmount = SqlClientUtility.GetDecimal(dataReader, "DetailTotalAmount", Decimal.Zero);

                    //return MakeSol_Order(dataReader);
                }
                else
                {
                    @TotalAmount = Decimal.Zero;
                    @DetailTotalAmount = Decimal.Zero;

                    //return null;
                }
            }
        }

        /// <summary>
        /// Updates a record in the sol_Orders table.
        /// </summary>
        public virtual void UpdateFees(int orderID, string orderType, int feeID, decimal feeAmount)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@FeeID", feeID),
                new SqlParameter("@FeeAmount", feeAmount)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_UpdateFees", parameters);
        }


        /// <summary>
        /// Updates a record in the sol_Orders table.
        /// </summary>
        public virtual void UpdateTaxes(int orderID, string orderType, decimal tax1Amount, decimal tax2Amount)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@OrderType", orderType),
                new SqlParameter("@Tax1Amount", tax1Amount),
                new SqlParameter("@Tax2Amount", tax2Amount)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Orders_UpdateTaxes", parameters);
        }
        #endregion

    }
}
