using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_EntriesDetail_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_EntriesDetail_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_EntriesDetail table.
		/// </summary>
		public virtual void Insert(Sol_EntriesDetail sol_EntriesDetail)
		{
			ValidationUtility.ValidateArgument("sol_EntriesDetail", sol_EntriesDetail);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryID", sol_EntriesDetail.EntryID),
				new SqlParameter("@EntryType", sol_EntriesDetail.EntryType),
				new SqlParameter("@CashID", sol_EntriesDetail.CashID),
				new SqlParameter("@Count", sol_EntriesDetail.Count)
			};

			sol_EntriesDetail.DetailID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_EntriesDetail table.
		/// </summary>
		public virtual void Update(Sol_EntriesDetail sol_EntriesDetail)
		{
			ValidationUtility.ValidateArgument("sol_EntriesDetail", sol_EntriesDetail);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DetailID", sol_EntriesDetail.DetailID),
				new SqlParameter("@EntryID", sol_EntriesDetail.EntryID),
				new SqlParameter("@EntryType", sol_EntriesDetail.EntryType),
				new SqlParameter("@CashID", sol_EntriesDetail.CashID),
				new SqlParameter("@Count", sol_EntriesDetail.Count)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_EntriesDetail table by its primary key.
		/// </summary>
		public virtual void Delete(int detailID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DetailID", detailID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_EntriesDetail table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCashID(int cashID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashID", cashID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_DeleteAllByCashID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_EntriesDetail table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByEntryID_EntryType(int entryID, string entryType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryID", entryID),
				new SqlParameter("@EntryType", entryType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_DeleteAllByEntryID_EntryType", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_EntriesDetail table.
		/// </summary>
		public virtual Sol_EntriesDetail Select(int detailID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DetailID", detailID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_EntriesDetail(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_EntriesDetail table.
		/// </summary>
		public virtual List<Sol_EntriesDetail> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_SelectAll"))
			{
				List<Sol_EntriesDetail> sol_EntriesDetailList = new List<Sol_EntriesDetail>();
				while (dataReader.Read())
				{
					Sol_EntriesDetail sol_EntriesDetail = MakeSol_EntriesDetail(dataReader);
					sol_EntriesDetailList.Add(sol_EntriesDetail);
				}

				return sol_EntriesDetailList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_EntriesDetail table by a foreign key.
		/// </summary>
		public virtual List<Sol_EntriesDetail> _SelectAllByCashID(int cashID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CashID", cashID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_SelectAllByCashID", parameters))
			{
				List<Sol_EntriesDetail> sol_EntriesDetailList = new List<Sol_EntriesDetail>();
				while (dataReader.Read())
				{
					Sol_EntriesDetail sol_EntriesDetail = MakeSol_EntriesDetail(dataReader);
					sol_EntriesDetailList.Add(sol_EntriesDetail);
				}

				return sol_EntriesDetailList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_EntriesDetail table by a foreign key.
		/// </summary>
		public virtual List<Sol_EntriesDetail> _SelectAllByEntryID_EntryType(int entryID, string entryType)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@EntryID", entryID),
				new SqlParameter("@EntryType", entryType)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_SelectAllByEntryID_EntryType", parameters))
			{
				List<Sol_EntriesDetail> sol_EntriesDetailList = new List<Sol_EntriesDetail>();
				while (dataReader.Read())
				{
					Sol_EntriesDetail sol_EntriesDetail = MakeSol_EntriesDetail(dataReader);
					sol_EntriesDetailList.Add(sol_EntriesDetail);
				}

				return sol_EntriesDetailList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_EntriesDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_EntriesDetail MakeSol_EntriesDetail(SqlDataReader dataReader)
		{
			Sol_EntriesDetail sol_EntriesDetail = new Sol_EntriesDetail();
			sol_EntriesDetail.DetailID = SqlClientUtility.GetInt32(dataReader, "DetailID", 0);
			sol_EntriesDetail.EntryID = SqlClientUtility.GetInt32(dataReader, "EntryID", 0);
			sol_EntriesDetail.EntryType = SqlClientUtility.GetString(dataReader, "EntryType", String.Empty);
			sol_EntriesDetail.CashID = SqlClientUtility.GetInt32(dataReader, "CashID", 0);
			sol_EntriesDetail.Count = SqlClientUtility.GetInt32(dataReader, "Count", 0);

			return sol_EntriesDetail;
		}

        #endregion

        #region additional methods

        /// <summary>
        /// Selects all records from the sol_EntriesDetail table.
        /// </summary>
        public virtual List<Sol_EntriesDetail> SelectAllByEntryIDType(int entryID, string entryType)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EntryID", entryID),
                new SqlParameter("@EntryType", entryType)
            };
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_EntriesDetail_SelectAllByEntryIDType", parameters))
            {
                List<Sol_EntriesDetail> sol_EntriesDetailList = new List<Sol_EntriesDetail>();
                while (dataReader.Read())
                {
                    Sol_EntriesDetail sol_EntriesDetail = MakeSol_EntriesDetail(dataReader);
                    sol_EntriesDetailList.Add(sol_EntriesDetail);
                }

                return sol_EntriesDetailList;
            }
        }



        #endregion
    }
}
