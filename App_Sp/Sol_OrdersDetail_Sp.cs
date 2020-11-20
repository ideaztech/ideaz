using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_OrdersDetail_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_OrdersDetail_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_OrdersDetail table.
		/// </summary>
		public virtual void Insert(Sol_OrdersDetail sol_OrdersDetail)
		{
			ValidationUtility.ValidateArgument("sol_OrdersDetail", sol_OrdersDetail);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@OrderID", sol_OrdersDetail.OrderID),
				new SqlParameter("@OrderType", sol_OrdersDetail.OrderType),
				new SqlParameter("@Date", sol_OrdersDetail.Date),
				new SqlParameter("@CategoryID", sol_OrdersDetail.CategoryID),
				new SqlParameter("@ProductID", sol_OrdersDetail.ProductID),
				new SqlParameter("@Description", sol_OrdersDetail.Description),
				new SqlParameter("@Quantity", sol_OrdersDetail.Quantity),
				new SqlParameter("@Price", sol_OrdersDetail.Price),
				new SqlParameter("@Amount", sol_OrdersDetail.Amount),
				new SqlParameter("@Status", sol_OrdersDetail.Status),
				new SqlParameter("@CategoryButtonID", sol_OrdersDetail.CategoryButtonID),
				new SqlParameter("@BagID", sol_OrdersDetail.BagID),
				//new SqlParameter("@IsNew", sol_OrdersDetail.IsNew),
				new SqlParameter("@ConveyorID", sol_OrdersDetail.ConveyorID),
				new SqlParameter("@StageID", sol_OrdersDetail.StageID)
			};

			sol_OrdersDetail.DetailID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_OrdersDetail table.
		/// </summary>
		public virtual void Update(Sol_OrdersDetail sol_OrdersDetail)
		{
			ValidationUtility.ValidateArgument("sol_OrdersDetail", sol_OrdersDetail);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DetailID", sol_OrdersDetail.DetailID),
				new SqlParameter("@OrderID", sol_OrdersDetail.OrderID),
				new SqlParameter("@OrderType", sol_OrdersDetail.OrderType),
				new SqlParameter("@Date", sol_OrdersDetail.Date),
				new SqlParameter("@CategoryID", sol_OrdersDetail.CategoryID),
				new SqlParameter("@ProductID", sol_OrdersDetail.ProductID),
				new SqlParameter("@Description", sol_OrdersDetail.Description),
				new SqlParameter("@Quantity", sol_OrdersDetail.Quantity),
				new SqlParameter("@Price", sol_OrdersDetail.Price),
				new SqlParameter("@Amount", sol_OrdersDetail.Amount),
				new SqlParameter("@Status", sol_OrdersDetail.Status),
				new SqlParameter("@CategoryButtonID", sol_OrdersDetail.CategoryButtonID),
				new SqlParameter("@BagID", sol_OrdersDetail.BagID),
				//new SqlParameter("@IsNew", sol_OrdersDetail.IsNew),
				new SqlParameter("@ConveyorID", sol_OrdersDetail.ConveyorID),
				new SqlParameter("@StageID", sol_OrdersDetail.StageID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_OrdersDetail table by its primary key.
		/// </summary>
		public virtual void Delete(int detailID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DetailID", detailID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_OrdersDetail table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCategoryID(int categoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryID", categoryID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_DeleteAllByCategoryID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_OrdersDetail table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByOrderID_OrderType(int orderID, string orderType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@OrderID", orderID),
				new SqlParameter("@OrderType", orderType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_DeleteAllByOrderID_OrderType", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_OrdersDetail table.
		/// </summary>
		public virtual Sol_OrdersDetail Select(int detailID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DetailID", detailID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_OrdersDetail(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_OrdersDetail table.
		/// </summary>
		public virtual List<Sol_OrdersDetail> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_SelectAll"))
			{
				List<Sol_OrdersDetail> sol_OrdersDetailList = new List<Sol_OrdersDetail>();
				while (dataReader.Read())
				{
					Sol_OrdersDetail sol_OrdersDetail = MakeSol_OrdersDetail(dataReader);
					sol_OrdersDetailList.Add(sol_OrdersDetail);
				}

				return sol_OrdersDetailList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_OrdersDetail table by a foreign key.
		/// </summary>
		public virtual List<Sol_OrdersDetail> _SelectAllByCategoryID(int categoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryID", categoryID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_SelectAllByCategoryID", parameters))
			{
				List<Sol_OrdersDetail> sol_OrdersDetailList = new List<Sol_OrdersDetail>();
				while (dataReader.Read())
				{
					Sol_OrdersDetail sol_OrdersDetail = MakeSol_OrdersDetail(dataReader);
					sol_OrdersDetailList.Add(sol_OrdersDetail);
				}

				return sol_OrdersDetailList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_OrdersDetail table by a foreign key.
		/// </summary>
		public virtual List<Sol_OrdersDetail> _SelectAllByOrderID_OrderType(int orderID, string orderType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@OrderID", orderID),
				new SqlParameter("@OrderType", orderType)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_OrdersDetail_SelectAllByOrderID_OrderType", parameters))
			{
				List<Sol_OrdersDetail> sol_OrdersDetailList = new List<Sol_OrdersDetail>();
				while (dataReader.Read())
				{
					Sol_OrdersDetail sol_OrdersDetail = MakeSol_OrdersDetail(dataReader);
					sol_OrdersDetailList.Add(sol_OrdersDetail);
				}

				return sol_OrdersDetailList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_OrdersDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_OrdersDetail MakeSol_OrdersDetail(SqlDataReader dataReader)
		{
			Sol_OrdersDetail sol_OrdersDetail = new Sol_OrdersDetail();
			sol_OrdersDetail.DetailID = SqlClientUtility.GetInt32(dataReader, "DetailID", 0);
			sol_OrdersDetail.OrderID = SqlClientUtility.GetInt32(dataReader, "OrderID", 0);
			sol_OrdersDetail.OrderType = SqlClientUtility.GetString(dataReader, "OrderType", String.Empty);
			sol_OrdersDetail.Date = SqlClientUtility.GetDateTime(dataReader, "Date", new DateTime(0));
			sol_OrdersDetail.CategoryID = SqlClientUtility.GetInt32(dataReader, "CategoryID", 0);
			sol_OrdersDetail.ProductID = SqlClientUtility.GetInt32(dataReader, "ProductID", 0);
			sol_OrdersDetail.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_OrdersDetail.Quantity = SqlClientUtility.GetInt32(dataReader, "Quantity", 0);
			sol_OrdersDetail.Price = SqlClientUtility.GetDecimal(dataReader, "Price", Decimal.Zero);
			sol_OrdersDetail.Amount = SqlClientUtility.GetDecimal(dataReader, "Amount", Decimal.Zero);
			sol_OrdersDetail.Status = SqlClientUtility.GetString(dataReader, "Status", String.Empty);
			sol_OrdersDetail.CategoryButtonID = SqlClientUtility.GetInt32(dataReader, "CategoryButtonID", 0);
			sol_OrdersDetail.BagID = SqlClientUtility.GetInt32(dataReader, "BagID", 0);
			//sol_OrdersDetail.IsNew = SqlClientUtility.GetBoolean(dataReader, "IsNew", false);
			sol_OrdersDetail.ConveyorID = SqlClientUtility.GetInt32(dataReader, "ConveyorID", 0);
			sol_OrdersDetail.StageID = SqlClientUtility.GetInt32(dataReader, "StageID", 0);

			return sol_OrdersDetail;
		}

        #endregion

    }
}
