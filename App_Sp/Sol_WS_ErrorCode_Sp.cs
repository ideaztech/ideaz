using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_WS_ErrorCode_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_WS_ErrorCode_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_WS_ErrorCodes table.
		/// </summary>
		public virtual void Insert(Sol_WS_ErrorCode sol_WS_ErrorCode)
		{
			ValidationUtility.ValidateArgument("sol_WS_ErrorCode", sol_WS_ErrorCode);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ErrorNumber", sol_WS_ErrorCode.ErrorNumber),
				new SqlParameter("@ErrorDescription", sol_WS_ErrorCode.ErrorDescription),
				new SqlParameter("@MessageToClient", sol_WS_ErrorCode.MessageToClient),
				new SqlParameter("@Notes", sol_WS_ErrorCode.Notes)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ErrorCodes_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_WS_ErrorCodes table.
		/// </summary>
		public virtual void Update(Sol_WS_ErrorCode sol_WS_ErrorCode)
		{
			ValidationUtility.ValidateArgument("sol_WS_ErrorCode", sol_WS_ErrorCode);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ErrorNumber", sol_WS_ErrorCode.ErrorNumber),
				new SqlParameter("@ErrorDescription", sol_WS_ErrorCode.ErrorDescription),
				new SqlParameter("@MessageToClient", sol_WS_ErrorCode.MessageToClient),
				new SqlParameter("@Notes", sol_WS_ErrorCode.Notes)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ErrorCodes_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_WS_ErrorCodes table by its primary key.
		/// </summary>
		public virtual void Delete(int errorNumber)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ErrorNumber", errorNumber)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ErrorCodes_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_WS_ErrorCodes table.
		/// </summary>
		public virtual Sol_WS_ErrorCode Select(int errorNumber)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ErrorNumber", errorNumber)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ErrorCodes_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_WS_ErrorCode(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_WS_ErrorCodes table.
		/// </summary>
		public virtual List<Sol_WS_ErrorCode> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ErrorCodes_SelectAll"))
			{
				List<Sol_WS_ErrorCode> sol_WS_ErrorCodeList = new List<Sol_WS_ErrorCode>();
				while (dataReader.Read())
				{
					Sol_WS_ErrorCode sol_WS_ErrorCode = MakeSol_WS_ErrorCode(dataReader);
					sol_WS_ErrorCodeList.Add(sol_WS_ErrorCode);
				}

				return sol_WS_ErrorCodeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_WS_ErrorCodes class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_WS_ErrorCode MakeSol_WS_ErrorCode(SqlDataReader dataReader)
		{
			Sol_WS_ErrorCode sol_WS_ErrorCode = new Sol_WS_ErrorCode();
			sol_WS_ErrorCode.ErrorNumber = SqlClientUtility.GetInt32(dataReader, "ErrorNumber", 0);
			sol_WS_ErrorCode.ErrorDescription = SqlClientUtility.GetString(dataReader, "ErrorDescription", String.Empty);
			sol_WS_ErrorCode.MessageToClient = SqlClientUtility.GetBoolean(dataReader, "MessageToClient", false);
			sol_WS_ErrorCode.Notes = SqlClientUtility.GetString(dataReader, "Notes", String.Empty);

			return sol_WS_ErrorCode;
		}

		#endregion
	}
}
