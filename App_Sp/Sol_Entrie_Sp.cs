using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Entrie_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Entrie_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Entries table.
		/// </summary>
		public virtual void Insert(Sol_Entrie sol_Entrie)
		{
			ValidationUtility.ValidateArgument("sol_Entrie", sol_Entrie);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryType", sol_Entrie.EntryType),
				new SqlParameter("@UserID", sol_Entrie.UserID),
				new SqlParameter("@UserName", sol_Entrie.UserName),
				new SqlParameter("@Date", sol_Entrie.Date),
				new SqlParameter("@CashTrayID", sol_Entrie.CashTrayID),
				new SqlParameter("@ExpenseTypeID", sol_Entrie.ExpenseTypeID),
				new SqlParameter("@Amount", sol_Entrie.Amount),
				new SqlParameter("@DiscrepancyAmount", sol_Entrie.DiscrepancyAmount)
			};

			sol_Entrie.EntryID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Entries_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Entries table.
		/// </summary>
		public virtual void Update(Sol_Entrie sol_Entrie)
		{
			ValidationUtility.ValidateArgument("sol_Entrie", sol_Entrie);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryID", sol_Entrie.EntryID),
				new SqlParameter("@EntryType", sol_Entrie.EntryType),
				new SqlParameter("@UserID", sol_Entrie.UserID),
				new SqlParameter("@UserName", sol_Entrie.UserName),
				new SqlParameter("@Date", sol_Entrie.Date),
				new SqlParameter("@CashTrayID", sol_Entrie.CashTrayID),
				new SqlParameter("@ExpenseTypeID", sol_Entrie.ExpenseTypeID),
				new SqlParameter("@Amount", sol_Entrie.Amount),
				new SqlParameter("@DiscrepancyAmount", sol_Entrie.DiscrepancyAmount)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Entries_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Entries table by its primary key.
		/// </summary>
		public virtual void Delete(int entryID, string entryType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryID", entryID),
				new SqlParameter("@EntryType", entryType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Entries_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Entries table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCashTrayID(int cashTrayID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashTrayID", cashTrayID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Entries_DeleteAllByCashTrayID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Entries table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByExpenseTypeID(int expenseTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ExpenseTypeID", expenseTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Entries_DeleteAllByExpenseTypeID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Entries table.
		/// </summary>
		public virtual Sol_Entrie Select(int entryID, string entryType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryID", entryID),
				new SqlParameter("@EntryType", entryType)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Entrie(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Entries table.
		/// </summary>
		public virtual List<Sol_Entrie> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_SelectAll"))
			{
				List<Sol_Entrie> sol_EntrieList = new List<Sol_Entrie>();
				while (dataReader.Read())
				{
					Sol_Entrie sol_Entrie = MakeSol_Entrie(dataReader);
					sol_EntrieList.Add(sol_Entrie);
				}

				return sol_EntrieList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Entries table by a foreign key.
		/// </summary>
		public virtual List<Sol_Entrie> _SelectAllByCashTrayID(int cashTrayID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashTrayID", cashTrayID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_SelectAllByCashTrayID", parameters))
			{
				List<Sol_Entrie> sol_EntrieList = new List<Sol_Entrie>();
				while (dataReader.Read())
				{
					Sol_Entrie sol_Entrie = MakeSol_Entrie(dataReader);
					sol_EntrieList.Add(sol_Entrie);
				}

				return sol_EntrieList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Entries table by a foreign key.
		/// </summary>
		public virtual List<Sol_Entrie> _SelectAllByExpenseTypeID(int expenseTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ExpenseTypeID", expenseTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_SelectAllByExpenseTypeID", parameters))
			{
				List<Sol_Entrie> sol_EntrieList = new List<Sol_Entrie>();
				while (dataReader.Read())
				{
					Sol_Entrie sol_Entrie = MakeSol_Entrie(dataReader);
					sol_EntrieList.Add(sol_Entrie);
				}

				return sol_EntrieList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Entries class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Entrie MakeSol_Entrie(SqlDataReader dataReader)
		{
			Sol_Entrie sol_Entrie = new Sol_Entrie();
			sol_Entrie.EntryID = SqlClientUtility.GetInt32(dataReader, "EntryID", 0);
			sol_Entrie.EntryType = SqlClientUtility.GetString(dataReader, "EntryType", String.Empty);
			sol_Entrie.UserID = SqlClientUtility.GetGuid(dataReader, "UserID", Guid.Empty);
			sol_Entrie.UserName = SqlClientUtility.GetString(dataReader, "UserName", String.Empty);
			sol_Entrie.Date = SqlClientUtility.GetDateTime(dataReader, "Date", new DateTime(0));
			sol_Entrie.CashTrayID = SqlClientUtility.GetInt32(dataReader, "CashTrayID", 0);
			sol_Entrie.ExpenseTypeID = SqlClientUtility.GetInt32(dataReader, "ExpenseTypeID", 0);
			sol_Entrie.Amount = SqlClientUtility.GetDecimal(dataReader, "Amount", Decimal.Zero);
			sol_Entrie.DiscrepancyAmount = SqlClientUtility.GetDecimal(dataReader, "DiscrepancyAmount", Decimal.Zero);

			return sol_Entrie;
		}

        #endregion

        #region Aditional Methods

        /// <summary>
        /// Selects a single record from the sol_Entries table.
        /// </summary>
        public virtual decimal GetValueOfFloat(int cashTrayID, int closingEntryID)
        {
            /*
            @CashTrayID int,            --not required when providing Closing EntryID
            @ClosingEntryID int = NULL  --optional if you want to know the calculated value of a previous close
             
            */
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CashTrayID", cashTrayID),
                new SqlParameter("@ClosingEntryID", closingEntryID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_GetValueOfFloat", parameters))
            {
                if (dataReader.Read())
                {
                    return SqlClientUtility.GetDecimal(dataReader, "CurrentFloat", Decimal.Zero);
                }
                else
                {
                    return 0m;
                }
            }
        }

        /// <summary>
        /// Selects a single record from the sol_Entries table.
        /// </summary>
        public virtual decimal GetLastClosingValue(int cashTrayID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CashTrayID", cashTrayID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_GetLastClosingValue", parameters))
            {
                if (dataReader.Read())
                {
                    return SqlClientUtility.GetDecimal(dataReader, "Amount", Decimal.Zero);
                }
                else
                {
                    return 0m;
                    //}
                }
            }
        }


        /// <summary>
        /// Selects all records from the sol_Entries table by a foreign key.
        /// </summary>
        public virtual List<Sol_Entrie> SelectAllByTypeDateTray(string entryType, DateTime date, int cashTrayID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EntryType", entryType),
                new SqlParameter("@Date", date),
                new SqlParameter("@CashTrayID", cashTrayID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_SelectAllByTypeDateTray", parameters))
            {
                List<Sol_Entrie> sol_EntrieList = new List<Sol_Entrie>();
                while (dataReader.Read())
                {
                    Sol_Entrie sol_Entrie = MakeSol_Entrie(dataReader);
                    sol_EntrieList.Add(sol_Entrie);
                }

                return sol_EntrieList;
            }
        }

        /// <summary>
        /// Selects a single record from the sol_Entries table.
        /// </summary>
        public virtual Sol_Entrie SelectLastType(string entryType, int cashTrayID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EntryType", entryType),
                new SqlParameter("@CashTrayID", cashTrayID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Entries_SelectLastType", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Entrie(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion
    }
}
