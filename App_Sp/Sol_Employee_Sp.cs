using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Employee_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Employee_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_Employees table.
		/// </summary>
		public virtual void Insert(Sol_Employee sol_Employee)
		{
			ValidationUtility.ValidateArgument("sol_Employee", sol_Employee);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", sol_Employee.UserId),
				new SqlParameter("@FirstName", sol_Employee.FirstName),
				new SqlParameter("@LastName", sol_Employee.LastName),
				new SqlParameter("@MiddleName", sol_Employee.MiddleName),
				new SqlParameter("@BirthDate", sol_Employee.BirthDate),
				new SqlParameter("@HireDate", sol_Employee.HireDate),
				new SqlParameter("@EmployeeNotes", sol_Employee.EmployeeNotes),
				new SqlParameter("@SIN", sol_Employee.SIN),
				new SqlParameter("@Gender", sol_Employee.Gender),
				new SqlParameter("@EmployeeNumber", sol_Employee.EmployeeNumber),
				new SqlParameter("@PayrollNumber", sol_Employee.PayrollNumber),
				new SqlParameter("@CompensationAmount", sol_Employee.CompensationAmount),
				new SqlParameter("@CompensationType", sol_Employee.CompensationType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_Employees table.
		/// </summary>
		public virtual void Update(Sol_Employee sol_Employee)
		{
			ValidationUtility.ValidateArgument("sol_Employee", sol_Employee);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", sol_Employee.UserId),
				new SqlParameter("@FirstName", sol_Employee.FirstName),
				new SqlParameter("@LastName", sol_Employee.LastName),
				new SqlParameter("@MiddleName", sol_Employee.MiddleName),
				new SqlParameter("@BirthDate", sol_Employee.BirthDate),
				new SqlParameter("@HireDate", sol_Employee.HireDate),
				new SqlParameter("@EmployeeNotes", sol_Employee.EmployeeNotes),
				new SqlParameter("@SIN", sol_Employee.SIN),
				new SqlParameter("@Gender", sol_Employee.Gender),
				new SqlParameter("@EmployeeNumber", sol_Employee.EmployeeNumber),
				new SqlParameter("@PayrollNumber", sol_Employee.PayrollNumber),
				new SqlParameter("@CompensationAmount", sol_Employee.CompensationAmount),
				new SqlParameter("@CompensationType", sol_Employee.CompensationType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_Employees table by its primary key.
		/// </summary>
		public virtual void Delete(Guid userId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_Employees table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByUserId(Guid userId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_DeleteAllByUserId", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_Employees table.
		/// </summary>
		public virtual Sol_Employee Select(Guid userId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Employee(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_Employees table.
		/// </summary>
		public virtual List<Sol_Employee> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_SelectAll"))
			{
				List<Sol_Employee> sol_EmployeeList = new List<Sol_Employee>();
				while (dataReader.Read())
				{
					Sol_Employee sol_Employee = MakeSol_Employee(dataReader);
					sol_EmployeeList.Add(sol_Employee);
				}

				return sol_EmployeeList;
			}
		}

		/// <summary>
		/// Selects all records from the Sol_Employees table by a foreign key.
		/// </summary>
		public virtual List<Sol_Employee> _SelectAllByUserId(Guid userId)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_SelectAllByUserId", parameters))
			{
				List<Sol_Employee> sol_EmployeeList = new List<Sol_Employee>();
				while (dataReader.Read())
				{
					Sol_Employee sol_Employee = MakeSol_Employee(dataReader);
					sol_EmployeeList.Add(sol_Employee);
				}

				return sol_EmployeeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_Employees class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Employee MakeSol_Employee(SqlDataReader dataReader)
		{
			Sol_Employee sol_Employee = new Sol_Employee();
			sol_Employee.UserId = SqlClientUtility.GetGuid(dataReader, "UserId", Guid.Empty);
			sol_Employee.FirstName = SqlClientUtility.GetString(dataReader, "FirstName", String.Empty);
			sol_Employee.LastName = SqlClientUtility.GetString(dataReader, "LastName", String.Empty);
			sol_Employee.MiddleName = SqlClientUtility.GetString(dataReader, "MiddleName", String.Empty);
			sol_Employee.BirthDate = SqlClientUtility.GetDateTime(dataReader, "BirthDate", new DateTime(0));
			sol_Employee.HireDate = SqlClientUtility.GetDateTime(dataReader, "HireDate", new DateTime(0));
			sol_Employee.EmployeeNotes = SqlClientUtility.GetString(dataReader, "EmployeeNotes", String.Empty);
			sol_Employee.SIN = SqlClientUtility.GetString(dataReader, "SIN", String.Empty);
			sol_Employee.Gender = SqlClientUtility.GetByte(dataReader, "Gender", 0x00);
			sol_Employee.EmployeeNumber = SqlClientUtility.GetString(dataReader, "EmployeeNumber", String.Empty);
			sol_Employee.PayrollNumber = SqlClientUtility.GetString(dataReader, "PayrollNumber", String.Empty);
			sol_Employee.CompensationAmount = SqlClientUtility.GetDecimal(dataReader, "CompensationAmount", Decimal.Zero);
			sol_Employee.CompensationType = SqlClientUtility.GetByte(dataReader, "CompensationType", 0x00);

			return sol_Employee;
		}

        #endregion

        #region Additional Methods

        ///// <summary>
        ///// Selects all records from the Sol_Employees table (lookup).
        ///// </summary>
        //public virtual List<Sol_Employee> SelectAllLookup()
        //{
        //    using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_SelectAllLookup"))
        //    {
        //        List<Sol_Employee> sol_EmployeeList = new List<Sol_Employee>();
        //        while (dataReader.Read())
        //        {
        //            Sol_Employee sol_Employee = MakeSol_Employee(dataReader);
        //            sol_EmployeeList.Add(sol_Employee);
        //        }

        //        return sol_EmployeeList;
        //    }
        //}

        //Aditional Stored Procedures 
        /// <summary>
        /// Selects all records from the Sol_Employees table (lookup).
        /// </summary>
        public virtual List<Sol_EmployeeLookup> SelectAllLookup()
        {
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Employees_SelectAllLookup"))
            {
                List<Sol_EmployeeLookup> sol_EmployeeLookupList = new List<Sol_EmployeeLookup>();
                while (dataReader.Read())
                {
                    Sol_EmployeeLookup sol_EmployeeLookup = new Sol_EmployeeLookup();
                    sol_EmployeeLookup.UserId = SqlClientUtility.GetGuid(dataReader, "UserId", Guid.Empty);
                    sol_EmployeeLookup.FullName = SqlClientUtility.GetString(dataReader, "FullName", String.Empty);
                    sol_EmployeeLookupList.Add(sol_EmployeeLookup);
                }

                return sol_EmployeeLookupList;
            }
        }


        #endregion

    }
}
