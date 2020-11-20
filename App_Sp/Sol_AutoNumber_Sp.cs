using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_AutoNumber_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_AutoNumber_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_AutoNumbers table.
		/// </summary>
		public virtual void Insert(Sol_AutoNumber sol_AutoNumber)
		{
			ValidationUtility.ValidateArgument("sol_AutoNumber", sol_AutoNumber);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", sol_AutoNumber.AgencyID),
				new SqlParameter("@FolioID", sol_AutoNumber.FolioID),
				new SqlParameter("@TagNumber", sol_AutoNumber.TagNumber),
				new SqlParameter("@RBillNumber", sol_AutoNumber.RBillNumber)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_AutoNumbers_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_AutoNumbers table.
		/// </summary>
		public virtual void Update(Sol_AutoNumber sol_AutoNumber)
		{
			ValidationUtility.ValidateArgument("sol_AutoNumber", sol_AutoNumber);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", sol_AutoNumber.AgencyID),
				new SqlParameter("@FolioID", sol_AutoNumber.FolioID),
				new SqlParameter("@TagNumber", sol_AutoNumber.TagNumber),
				new SqlParameter("@RBillNumber", sol_AutoNumber.RBillNumber)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_AutoNumbers_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_AutoNumbers table by its primary key.
		/// </summary>
		public virtual void Delete(int agencyID, int folioID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", agencyID),
				new SqlParameter("@FolioID", folioID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_AutoNumbers_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_AutoNumbers table.
		/// </summary>
		public virtual Sol_AutoNumber Select(int agencyID, int folioID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", agencyID),
				new SqlParameter("@FolioID", folioID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_AutoNumbers_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_AutoNumber(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_AutoNumbers table.
		/// </summary>
		public virtual List<Sol_AutoNumber> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_AutoNumbers_SelectAll"))
			{
				List<Sol_AutoNumber> sol_AutoNumberList = new List<Sol_AutoNumber>();
				while (dataReader.Read())
				{
					Sol_AutoNumber sol_AutoNumber = MakeSol_AutoNumber(dataReader);
					sol_AutoNumberList.Add(sol_AutoNumber);
				}

				return sol_AutoNumberList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_AutoNumbers class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_AutoNumber MakeSol_AutoNumber(SqlDataReader dataReader)
		{
			Sol_AutoNumber sol_AutoNumber = new Sol_AutoNumber();
			sol_AutoNumber.AgencyID = SqlClientUtility.GetInt32(dataReader, "AgencyID", 0);
			sol_AutoNumber.FolioID = SqlClientUtility.GetInt32(dataReader, "FolioID", 0);
			sol_AutoNumber.TagNumber = SqlClientUtility.GetInt32(dataReader, "TagNumber", 0);
			sol_AutoNumber.RBillNumber = SqlClientUtility.GetInt32(dataReader, "RBillNumber", 0);

			return sol_AutoNumber;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Updates a record in the Sol_AutoNumbers table.
        /// </summary>
        public virtual int UpdateTagNumber(int agencyID, int folioID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgencyID", agencyID),
                new SqlParameter("@FolioID", folioID)
            };

            return (int)SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sol_AutoNumbers_UpdateTagNumber", parameters);
        }

        /// <summary>
        /// Updates a record in the Sol_AutoNumbers table.
        /// </summary>
        public virtual int UpdateRBillNumber(int agencyID, int folioID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgencyID", agencyID),
                new SqlParameter("@FolioID", folioID)
            };

            return (int)SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sol_AutoNumbers_UpdateRBillNumber", parameters);
        }

        #endregion

    }
}
