using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Agencie_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Agencie_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Agencies table.
		/// </summary>
		public virtual void Insert(Sol_Agencie sol_Agencie)
		{
			ValidationUtility.ValidateArgument("sol_Agencie", sol_Agencie);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sol_Agencie.Name),
				new SqlParameter("@Description", sol_Agencie.Description),
				new SqlParameter("@Address1", sol_Agencie.Address1),
				new SqlParameter("@Address2", sol_Agencie.Address2),
				new SqlParameter("@City", sol_Agencie.City),
				new SqlParameter("@Province", sol_Agencie.Province),
				new SqlParameter("@Country", sol_Agencie.Country),
				new SqlParameter("@PostalCode", sol_Agencie.PostalCode),
				new SqlParameter("@VendorID", sol_Agencie.VendorID),
				new SqlParameter("@AutoGenerateTagNumber", sol_Agencie.AutoGenerateTagNumber),
				new SqlParameter("@AutoGenerateRBillNumber", sol_Agencie.AutoGenerateRBillNumber)
			};

			sol_Agencie.AgencyID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Agencies_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Agencies table.
		/// </summary>
		public virtual void Update(Sol_Agencie sol_Agencie)
		{
			ValidationUtility.ValidateArgument("sol_Agencie", sol_Agencie);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", sol_Agencie.AgencyID),
				new SqlParameter("@Name", sol_Agencie.Name),
				new SqlParameter("@Description", sol_Agencie.Description),
				new SqlParameter("@Address1", sol_Agencie.Address1),
				new SqlParameter("@Address2", sol_Agencie.Address2),
				new SqlParameter("@City", sol_Agencie.City),
				new SqlParameter("@Province", sol_Agencie.Province),
				new SqlParameter("@Country", sol_Agencie.Country),
				new SqlParameter("@PostalCode", sol_Agencie.PostalCode),
				new SqlParameter("@VendorID", sol_Agencie.VendorID),
				new SqlParameter("@AutoGenerateTagNumber", sol_Agencie.AutoGenerateTagNumber),
				new SqlParameter("@AutoGenerateRBillNumber", sol_Agencie.AutoGenerateRBillNumber)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Agencies_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Agencies table by its primary key.
		/// </summary>
		public virtual void Delete(int agencyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", agencyID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Agencies_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Agencies table.
		/// </summary>
		public virtual Sol_Agencie Select(int agencyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", agencyID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Agencies_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Agencie(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Agencies table.
		/// </summary>
		public virtual List<Sol_Agencie> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Agencies_SelectAll"))
			{
				List<Sol_Agencie> sol_AgencieList = new List<Sol_Agencie>();
				while (dataReader.Read())
				{
					Sol_Agencie sol_Agencie = MakeSol_Agencie(dataReader);
					sol_AgencieList.Add(sol_Agencie);
				}

				return sol_AgencieList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Agencies class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Agencie MakeSol_Agencie(SqlDataReader dataReader)
		{
			Sol_Agencie sol_Agencie = new Sol_Agencie();
			sol_Agencie.AgencyID = SqlClientUtility.GetInt32(dataReader, "AgencyID", 0);
			sol_Agencie.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sol_Agencie.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_Agencie.Address1 = SqlClientUtility.GetString(dataReader, "Address1", String.Empty);
			sol_Agencie.Address2 = SqlClientUtility.GetString(dataReader, "Address2", String.Empty);
			sol_Agencie.City = SqlClientUtility.GetString(dataReader, "City", String.Empty);
			sol_Agencie.Province = SqlClientUtility.GetString(dataReader, "Province", String.Empty);
			sol_Agencie.Country = SqlClientUtility.GetString(dataReader, "Country", String.Empty);
			sol_Agencie.PostalCode = SqlClientUtility.GetString(dataReader, "PostalCode", String.Empty);
			sol_Agencie.VendorID = SqlClientUtility.GetString(dataReader, "VendorID", String.Empty);
			sol_Agencie.AutoGenerateTagNumber = SqlClientUtility.GetBoolean(dataReader, "AutoGenerateTagNumber", false);
			sol_Agencie.AutoGenerateRBillNumber = SqlClientUtility.GetBoolean(dataReader, "AutoGenerateRBillNumber", false);

			return sol_Agencie;
		}

		#endregion
	}
}
