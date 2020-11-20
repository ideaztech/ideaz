using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Qds_Drop_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Qds_Drop_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Qds_Drop table.
		/// </summary>
		public virtual void Insert(Qds_Drop qds_Drop)
		{
			ValidationUtility.ValidateArgument("qds_Drop", qds_Drop);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", qds_Drop.CustomerID),
				new SqlParameter("@NumberOfBags", qds_Drop.NumberOfBags),
				new SqlParameter("@PaymentMethodID", qds_Drop.PaymentMethodID),
				new SqlParameter("@DepotID", qds_Drop.DepotID),
				new SqlParameter("@OrderID", qds_Drop.OrderID),
				new SqlParameter("@OrderType", qds_Drop.OrderType)
    //            ,
				//new SqlParameter("@IsNew", qds_Drop.IsNew)
			};

			qds_Drop.DropID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Qds_Drop table.
		/// </summary>
		public virtual void Update(Qds_Drop qds_Drop)
		{
			ValidationUtility.ValidateArgument("qds_Drop", qds_Drop);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DropID", qds_Drop.DropID),
				new SqlParameter("@CustomerID", qds_Drop.CustomerID),
				new SqlParameter("@NumberOfBags", qds_Drop.NumberOfBags),
				new SqlParameter("@PaymentMethodID", qds_Drop.PaymentMethodID),
				new SqlParameter("@DepotID", qds_Drop.DepotID),
				new SqlParameter("@OrderID", qds_Drop.OrderID),
				new SqlParameter("@OrderType", qds_Drop.OrderType)
    //            ,
				//new SqlParameter("@IsNew", qds_Drop.IsNew)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_Drop table by its primary key.
		/// </summary>
		public virtual void Delete(int dropID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DropID", dropID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_Drop table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByPaymentMethodID(int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_DeleteAllByPaymentMethodID", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_Drop table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCustomerID(int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", customerID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_DeleteAllByCustomerID", parameters);
		}

		/// <summary>
		/// Selects a single record from the Qds_Drop table.
		/// </summary>
		public virtual Qds_Drop Select(int dropID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DropID", dropID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeQds_Drop(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Qds_Drop table.
		/// </summary>
		public virtual List<Qds_Drop> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_SelectAll"))
			{
				List<Qds_Drop> qds_DropList = new List<Qds_Drop>();
				while (dataReader.Read())
				{
					Qds_Drop qds_Drop = MakeQds_Drop(dataReader);
					qds_DropList.Add(qds_Drop);
				}

				return qds_DropList;
			}
		}

		/// <summary>
		/// Selects all records from the Qds_Drop table by a foreign key.
		/// </summary>
		public virtual List<Qds_Drop> _SelectAllByPaymentMethodID(int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_SelectAllByPaymentMethodID", parameters))
			{
				List<Qds_Drop> qds_DropList = new List<Qds_Drop>();
				while (dataReader.Read())
				{
					Qds_Drop qds_Drop = MakeQds_Drop(dataReader);
					qds_DropList.Add(qds_Drop);
				}

				return qds_DropList;
			}
		}

		/// <summary>
		/// Selects all records from the Qds_Drop table by a foreign key.
		/// </summary>
		public virtual List<Qds_Drop> _SelectAllByCustomerID(int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", customerID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_SelectAllByCustomerID", parameters))
			{
				List<Qds_Drop> qds_DropList = new List<Qds_Drop>();
				while (dataReader.Read())
				{
					Qds_Drop qds_Drop = MakeQds_Drop(dataReader);
					qds_DropList.Add(qds_Drop);
				}

				return qds_DropList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Qds_Drop class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Qds_Drop MakeQds_Drop(SqlDataReader dataReader)
		{
			Qds_Drop qds_Drop = new Qds_Drop();
			qds_Drop.DropID = SqlClientUtility.GetInt32(dataReader, "DropID", 0);
			qds_Drop.CustomerID = SqlClientUtility.GetInt32(dataReader, "CustomerID", 0);
			qds_Drop.NumberOfBags = SqlClientUtility.GetInt32(dataReader, "NumberOfBags", 0);
			qds_Drop.PaymentMethodID = SqlClientUtility.GetInt32(dataReader, "PaymentMethodID", 0);
			qds_Drop.DepotID = SqlClientUtility.GetString(dataReader, "DepotID", String.Empty);
			qds_Drop.OrderID = SqlClientUtility.GetInt32(dataReader, "OrderID", 0);
			qds_Drop.OrderType = SqlClientUtility.GetString(dataReader, "OrderType", String.Empty);
			//qds_Drop.IsNew = SqlClientUtility.GetBoolean(dataReader, "IsNew", false);

			return qds_Drop;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Selects all records from the Qds_Drop table by a foreign key.
        /// </summary>
        public virtual List<Qds_Drop> _SelectAllByOrderID_OrderType(int orderID, string orderType)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderID),
                new SqlParameter("@OrderType", orderType)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_SelectAllByOrderID_OrderType", parameters))
            {
                List<Qds_Drop> qds_DropList = new List<Qds_Drop>();
                while (dataReader.Read())
                {
                    Qds_Drop qds_Drop = MakeQds_Drop(dataReader);
                    qds_DropList.Add(qds_Drop);
                }

                return qds_DropList;
            }
        }

        /// <summary>
        /// Selects all records from the Qds_Drop table.
        /// </summary>
        public virtual List<Qds_Drop> SelectAllByOrderTpe(string orderType)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderType", orderType)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_SelectAllByOrderType", parameters))
            {
                List<Qds_Drop> qds_DropList = new List<Qds_Drop>();
                while (dataReader.Read())
                {
                    Qds_Drop qds_Drop = MakeQds_Drop(dataReader);
                    qds_DropList.Add(qds_Drop);
                }

                return qds_DropList;
            }
        }


        /// <summary>
        /// Selects all records from the Qds_Drop table.
        /// </summary>
        public virtual List<Qds_Drop> SelectAllInProcess()
        {
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_SelectAllInProcess"))
            {
                List<Qds_Drop> qds_DropList = new List<Qds_Drop>();
                while (dataReader.Read())
                {
                    Qds_Drop qds_Drop = MakeQds_Drop(dataReader);
                    qds_DropList.Add(qds_Drop);
                }

                return qds_DropList;
            }
        }

        /// <summary>
        /// Selects a single record from the Qds_Drop table.
        /// </summary>
        public virtual bool IsReady(int dropID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DropID", dropID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Drop_IsReady", parameters))
            {
                if (dataReader.Read())
                {
                    return SqlClientUtility.GetBoolean(dataReader, "Ready", false);
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

    }
}
