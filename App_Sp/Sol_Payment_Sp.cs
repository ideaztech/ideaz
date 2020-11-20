using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Payment_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Payment_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Payments table.
		/// </summary>
		public virtual void Insert(Sol_Payment sol_Payment)
		{
			ValidationUtility.ValidateArgument("sol_Payment", sol_Payment);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentAmount", sol_Payment.PaymentAmount),
				new SqlParameter("@date", sol_Payment.Date),
				new SqlParameter("@UserID", sol_Payment.UserID),
				new SqlParameter("@UserName", sol_Payment.UserName),
				new SqlParameter("@CustomerID", sol_Payment.CustomerID),
				new SqlParameter("@ChequeNumber", sol_Payment.ChequeNumber),
				new SqlParameter("@Name", sol_Payment.Name),
				new SqlParameter("@Address1", sol_Payment.Address1),
				new SqlParameter("@Address2", sol_Payment.Address2),
				new SqlParameter("@City", sol_Payment.City),
				new SqlParameter("@Province", sol_Payment.Province),
				new SqlParameter("@Country", sol_Payment.Country),
				new SqlParameter("@PostalCode", sol_Payment.PostalCode)
			};

			sol_Payment.PaymentID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Payments_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Payments table.
		/// </summary>
		public virtual void Update(Sol_Payment sol_Payment)
		{
			ValidationUtility.ValidateArgument("sol_Payment", sol_Payment);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentID", sol_Payment.PaymentID),
				new SqlParameter("@PaymentAmount", sol_Payment.PaymentAmount),
				new SqlParameter("@date", sol_Payment.Date),
				new SqlParameter("@UserID", sol_Payment.UserID),
				new SqlParameter("@UserName", sol_Payment.UserName),
				new SqlParameter("@CustomerID", sol_Payment.CustomerID),
				new SqlParameter("@ChequeNumber", sol_Payment.ChequeNumber),
				new SqlParameter("@Name", sol_Payment.Name),
				new SqlParameter("@Address1", sol_Payment.Address1),
				new SqlParameter("@Address2", sol_Payment.Address2),
				new SqlParameter("@City", sol_Payment.City),
				new SqlParameter("@Province", sol_Payment.Province),
				new SqlParameter("@Country", sol_Payment.Country),
				new SqlParameter("@PostalCode", sol_Payment.PostalCode)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Payments_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Payments table by its primary key.
		/// </summary>
		public virtual void Delete(int paymentID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentID", paymentID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Payments_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Payments table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCustomerID(int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", customerID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Payments_DeleteAllByCustomerID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Payments table.
		/// </summary>
		public virtual Sol_Payment Select(int paymentID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentID", paymentID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Payments_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Payment(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Payments table.
		/// </summary>
		public virtual List<Sol_Payment> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Payments_SelectAll"))
			{
				List<Sol_Payment> sol_PaymentList = new List<Sol_Payment>();
				while (dataReader.Read())
				{
					Sol_Payment sol_Payment = MakeSol_Payment(dataReader);
					sol_PaymentList.Add(sol_Payment);
				}

				return sol_PaymentList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Payments table by a foreign key.
		/// </summary>
		public virtual List<Sol_Payment> _SelectAllByCustomerID(int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", customerID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Payments_SelectAllByCustomerID", parameters))
			{
				List<Sol_Payment> sol_PaymentList = new List<Sol_Payment>();
				while (dataReader.Read())
				{
					Sol_Payment sol_Payment = MakeSol_Payment(dataReader);
					sol_PaymentList.Add(sol_Payment);
				}

				return sol_PaymentList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Payments class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Payment MakeSol_Payment(SqlDataReader dataReader)
		{
			Sol_Payment sol_Payment = new Sol_Payment();
			sol_Payment.PaymentID = SqlClientUtility.GetInt32(dataReader, "PaymentID", 0);
			sol_Payment.PaymentAmount = SqlClientUtility.GetFloat(dataReader, "PaymentAmount", 0.0F);
			sol_Payment.Date = SqlClientUtility.GetDateTime(dataReader, "date", new DateTime(0));
			sol_Payment.UserID = SqlClientUtility.GetInt32(dataReader, "UserID", 0);
			sol_Payment.UserName = SqlClientUtility.GetString(dataReader, "UserName", String.Empty);
			sol_Payment.CustomerID = SqlClientUtility.GetInt32(dataReader, "CustomerID", 0);
			sol_Payment.ChequeNumber = SqlClientUtility.GetString(dataReader, "ChequeNumber", String.Empty);
			sol_Payment.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sol_Payment.Address1 = SqlClientUtility.GetString(dataReader, "Address1", String.Empty);
			sol_Payment.Address2 = SqlClientUtility.GetString(dataReader, "Address2", String.Empty);
			sol_Payment.City = SqlClientUtility.GetString(dataReader, "City", String.Empty);
			sol_Payment.Province = SqlClientUtility.GetString(dataReader, "Province", String.Empty);
			sol_Payment.Country = SqlClientUtility.GetString(dataReader, "Country", String.Empty);
			sol_Payment.PostalCode = SqlClientUtility.GetString(dataReader, "PostalCode", String.Empty);

			return sol_Payment;
		}

		#endregion
	}
}
