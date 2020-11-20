using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Customer_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Customer_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Customers table.
		/// </summary>
		public virtual void Insert(Sol_Customer sol_Customer)
		{
			ValidationUtility.ValidateArgument("sol_Customer", sol_Customer);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerCode", sol_Customer.CustomerCode),
				new SqlParameter("@Name", sol_Customer.Name),
				new SqlParameter("@Contact", sol_Customer.Contact),
				new SqlParameter("@Address1", sol_Customer.Address1),
				new SqlParameter("@Address2", sol_Customer.Address2),
				new SqlParameter("@City", sol_Customer.City),
				new SqlParameter("@Province", sol_Customer.Province),
				new SqlParameter("@Country", sol_Customer.Country),
				new SqlParameter("@PostalCode", sol_Customer.PostalCode),
				new SqlParameter("@Email", sol_Customer.Email),
				new SqlParameter("@LoweredEmail", sol_Customer.LoweredEmail),
				new SqlParameter("@IsActive", sol_Customer.IsActive),
				new SqlParameter("@PhoneNumber", sol_Customer.PhoneNumber),
				new SqlParameter("@Notes", sol_Customer.Notes),
				new SqlParameter("@Password", sol_Customer.Password),
				new SqlParameter("@DepotID", sol_Customer.DepotID),
				new SqlParameter("@CardNumber", sol_Customer.CardNumber),
				new SqlParameter("@CardTypeID", sol_Customer.CardTypeID),
				new SqlParameter("@SolumCustomer", sol_Customer.SolumCustomer),
				new SqlParameter("@QuickDropCustomer", sol_Customer.QuickDropCustomer)
    //            ,
				//new SqlParameter("@IsNew", sol_Customer.IsNew)
			};

			sol_Customer.CustomerID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Customers_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Customers table.
		/// </summary>
		public virtual void Update(Sol_Customer sol_Customer)
		{
			ValidationUtility.ValidateArgument("sol_Customer", sol_Customer);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", sol_Customer.CustomerID),
				new SqlParameter("@CustomerCode", sol_Customer.CustomerCode),
				new SqlParameter("@Name", sol_Customer.Name),
				new SqlParameter("@Contact", sol_Customer.Contact),
				new SqlParameter("@Address1", sol_Customer.Address1),
				new SqlParameter("@Address2", sol_Customer.Address2),
				new SqlParameter("@City", sol_Customer.City),
				new SqlParameter("@Province", sol_Customer.Province),
				new SqlParameter("@Country", sol_Customer.Country),
				new SqlParameter("@PostalCode", sol_Customer.PostalCode),
				new SqlParameter("@Email", sol_Customer.Email),
				new SqlParameter("@LoweredEmail", sol_Customer.LoweredEmail),
				new SqlParameter("@IsActive", sol_Customer.IsActive),
				new SqlParameter("@PhoneNumber", sol_Customer.PhoneNumber),
				new SqlParameter("@Notes", sol_Customer.Notes),
				new SqlParameter("@Password", sol_Customer.Password),
				new SqlParameter("@DepotID", sol_Customer.DepotID),
				new SqlParameter("@CardNumber", sol_Customer.CardNumber),
				new SqlParameter("@CardTypeID", sol_Customer.CardTypeID),
				new SqlParameter("@SolumCustomer", sol_Customer.SolumCustomer),
				new SqlParameter("@QuickDropCustomer", sol_Customer.QuickDropCustomer)
    //            ,
				//new SqlParameter("@IsNew", sol_Customer.IsNew)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Customers_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Customers table by its primary key.
		/// </summary>
		public virtual void Delete(int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", customerID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Customers_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Customers table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCardTypeID(int cardTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardTypeID", cardTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Customers_DeleteAllByCardTypeID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Customers table.
		/// </summary>
		public virtual Sol_Customer Select(int customerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", customerID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Customers_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Customer(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Customers table.
		/// </summary>
		public virtual List<Sol_Customer> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Customers_SelectAll"))
			{
				List<Sol_Customer> sol_CustomerList = new List<Sol_Customer>();
				while (dataReader.Read())
				{
					Sol_Customer sol_Customer = MakeSol_Customer(dataReader);
					sol_CustomerList.Add(sol_Customer);
				}

				return sol_CustomerList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Customers table by a foreign key.
		/// </summary>
		public virtual List<Sol_Customer> _SelectAllByCardTypeID(int cardTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardTypeID", cardTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Customers_SelectAllByCardTypeID", parameters))
			{
				List<Sol_Customer> sol_CustomerList = new List<Sol_Customer>();
				while (dataReader.Read())
				{
					Sol_Customer sol_Customer = MakeSol_Customer(dataReader);
					sol_CustomerList.Add(sol_Customer);
				}

				return sol_CustomerList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Customers class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Customer MakeSol_Customer(SqlDataReader dataReader)
		{
			Sol_Customer sol_Customer = new Sol_Customer();
			sol_Customer.CustomerID = SqlClientUtility.GetInt32(dataReader, "CustomerID", 0);
			sol_Customer.CustomerCode = SqlClientUtility.GetString(dataReader, "CustomerCode", String.Empty);
			sol_Customer.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sol_Customer.Contact = SqlClientUtility.GetString(dataReader, "Contact", String.Empty);
			sol_Customer.Address1 = SqlClientUtility.GetString(dataReader, "Address1", String.Empty);
			sol_Customer.Address2 = SqlClientUtility.GetString(dataReader, "Address2", String.Empty);
			sol_Customer.City = SqlClientUtility.GetString(dataReader, "City", String.Empty);
			sol_Customer.Province = SqlClientUtility.GetString(dataReader, "Province", String.Empty);
			sol_Customer.Country = SqlClientUtility.GetString(dataReader, "Country", String.Empty);
			sol_Customer.PostalCode = SqlClientUtility.GetString(dataReader, "PostalCode", String.Empty);
			sol_Customer.Email = SqlClientUtility.GetString(dataReader, "Email", String.Empty);
			sol_Customer.LoweredEmail = SqlClientUtility.GetString(dataReader, "LoweredEmail", String.Empty);
			sol_Customer.IsActive = SqlClientUtility.GetBoolean(dataReader, "IsActive", false);
			sol_Customer.PhoneNumber = SqlClientUtility.GetString(dataReader, "PhoneNumber", String.Empty);
			sol_Customer.Notes = SqlClientUtility.GetString(dataReader, "Notes", String.Empty);
			sol_Customer.Password = SqlClientUtility.GetString(dataReader, "Password", String.Empty);
			sol_Customer.DepotID = SqlClientUtility.GetString(dataReader, "DepotID", String.Empty);
			sol_Customer.CardNumber = SqlClientUtility.GetString(dataReader, "CardNumber", String.Empty);
			sol_Customer.CardTypeID = SqlClientUtility.GetInt32(dataReader, "CardTypeID", 0);
			sol_Customer.SolumCustomer = SqlClientUtility.GetBoolean(dataReader, "SolumCustomer", false);
			sol_Customer.QuickDropCustomer = SqlClientUtility.GetBoolean(dataReader, "QuickDropCustomer", false);
			//sol_Customer.IsNew = SqlClientUtility.GetBoolean(dataReader, "IsNew", false);

			return sol_Customer;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Selects a single record from the sol_Customers table.
        /// </summary>
        public virtual Sol_Customer SelectByCardNumber(string cardNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CardNumber", cardNumber)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Customers_SelectByCardNumber", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Customer(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Get customer balance
        /// </summary>
        public virtual decimal GetCustomerBalance(int customerID, string dateTo)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customerID),
                new SqlParameter("@DateTo", dateTo)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Customers_Balance", parameters))
            {
                if (dataReader.Read())
                {
                    return SqlClientUtility.GetDecimal(dataReader, "Balance", Decimal.Zero);
                }
                else
                {
                    return 0m;
                }
            }
        }

        #endregion

    }
}
