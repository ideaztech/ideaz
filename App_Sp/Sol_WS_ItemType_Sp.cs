using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_WS_ItemType_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_WS_ItemType_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_WS_ItemTypes table.
		/// </summary>
		public virtual void Insert(Sol_WS_ItemType sol_WS_ItemType)
		{
			ValidationUtility.ValidateArgument("sol_WS_ItemType", sol_WS_ItemType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ItemTypeID", sol_WS_ItemType.ItemTypeID),
				new SqlParameter("@ItemType", sol_WS_ItemType.ItemType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ItemTypes_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_WS_ItemTypes table.
		/// </summary>
		public virtual void Update(Sol_WS_ItemType sol_WS_ItemType)
		{
			ValidationUtility.ValidateArgument("sol_WS_ItemType", sol_WS_ItemType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ItemTypeID", sol_WS_ItemType.ItemTypeID),
				new SqlParameter("@ItemType", sol_WS_ItemType.ItemType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ItemTypes_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_WS_ItemTypes table by its primary key.
		/// </summary>
		public virtual void Delete(int itemTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ItemTypeID", itemTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ItemTypes_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_WS_ItemTypes table.
		/// </summary>
		public virtual Sol_WS_ItemType Select(int itemTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ItemTypeID", itemTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ItemTypes_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_WS_ItemType(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_WS_ItemTypes table.
		/// </summary>
		public virtual List<Sol_WS_ItemType> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ItemTypes_SelectAll"))
			{
				List<Sol_WS_ItemType> sol_WS_ItemTypeList = new List<Sol_WS_ItemType>();
				while (dataReader.Read())
				{
					Sol_WS_ItemType sol_WS_ItemType = MakeSol_WS_ItemType(dataReader);
					sol_WS_ItemTypeList.Add(sol_WS_ItemType);
				}

				return sol_WS_ItemTypeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_WS_ItemTypes class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_WS_ItemType MakeSol_WS_ItemType(SqlDataReader dataReader)
		{
			Sol_WS_ItemType sol_WS_ItemType = new Sol_WS_ItemType();
			sol_WS_ItemType.ItemTypeID = SqlClientUtility.GetInt32(dataReader, "ItemTypeID", 0);
			sol_WS_ItemType.ItemType = SqlClientUtility.GetString(dataReader, "ItemType", String.Empty);

			return sol_WS_ItemType;
		}

		#endregion
	}
}
