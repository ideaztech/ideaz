using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_LogType_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_LogType_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_LogType table.
		/// </summary>
		public virtual void Insert(Sac_LogType sac_LogType)
		{
			ValidationUtility.ValidateArgument("sac_LogType", sac_LogType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogTypeID", sac_LogType.LogTypeID),
				new SqlParameter("@Description", sac_LogType.Description)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_LogType_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_LogType table.
		/// </summary>
		public virtual void Update(Sac_LogType sac_LogType)
		{
			ValidationUtility.ValidateArgument("sac_LogType", sac_LogType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogTypeID", sac_LogType.LogTypeID),
				new SqlParameter("@Description", sac_LogType.Description)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_LogType_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_LogType table by its primary key.
		/// </summary>
		public virtual void Delete(int logTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogTypeID", logTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_LogType_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_LogType table.
		/// </summary>
		public virtual Sac_LogType Select(int logTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LogTypeID", logTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_LogType_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_LogType(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_LogType table.
		/// </summary>
		public virtual List<Sac_LogType> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_LogType_SelectAll"))
			{
				List<Sac_LogType> sac_LogTypeList = new List<Sac_LogType>();
				while (dataReader.Read())
				{
					Sac_LogType sac_LogType = MakeSac_LogType(dataReader);
					sac_LogTypeList.Add(sac_LogType);
				}

				return sac_LogTypeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_LogType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_LogType MakeSac_LogType(SqlDataReader dataReader)
		{
			Sac_LogType sac_LogType = new Sac_LogType();
			sac_LogType.LogTypeID = SqlClientUtility.GetInt32(dataReader, "LogTypeID", 0);
			sac_LogType.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);

			return sac_LogType;
		}

		#endregion
	}
}
