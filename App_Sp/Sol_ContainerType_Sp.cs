using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_ContainerType_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_ContainerType_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_ContainerTypes table.
		/// </summary>
		public virtual void Insert(Sol_ContainerType sol_ContainerType)
		{
			ValidationUtility.ValidateArgument("sol_ContainerType", sol_ContainerType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Description", sol_ContainerType.Description)
			};

			sol_ContainerType.ContainerTypeID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_ContainerTypes_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_ContainerTypes table.
		/// </summary>
		public virtual void Update(Sol_ContainerType sol_ContainerType)
		{
			ValidationUtility.ValidateArgument("sol_ContainerType", sol_ContainerType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerTypeID", sol_ContainerType.ContainerTypeID),
				new SqlParameter("@Description", sol_ContainerType.Description)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_ContainerTypes_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_ContainerTypes table by its primary key.
		/// </summary>
		public virtual void Delete(int containerTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerTypeID", containerTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_ContainerTypes_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_ContainerTypes table.
		/// </summary>
		public virtual Sol_ContainerType Select(int containerTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerTypeID", containerTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_ContainerTypes_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_ContainerType(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_ContainerTypes table.
		/// </summary>
		public virtual List<Sol_ContainerType> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_ContainerTypes_SelectAll"))
			{
				List<Sol_ContainerType> sol_ContainerTypeList = new List<Sol_ContainerType>();
				while (dataReader.Read())
				{
					Sol_ContainerType sol_ContainerType = MakeSol_ContainerType(dataReader);
					sol_ContainerTypeList.Add(sol_ContainerType);
				}

				return sol_ContainerTypeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_ContainerTypes class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_ContainerType MakeSol_ContainerType(SqlDataReader dataReader)
		{
			Sol_ContainerType sol_ContainerType = new Sol_ContainerType();
			sol_ContainerType.ContainerTypeID = SqlClientUtility.GetInt32(dataReader, "ContainerTypeID", 0);
			sol_ContainerType.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);

			return sol_ContainerType;
		}

		#endregion
	}
}
