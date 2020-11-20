using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_WS_ShippingContainerType_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_WS_ShippingContainerType_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_WS_ShippingContainerTypes table.
		/// </summary>
		public virtual void Insert(Sol_WS_ShippingContainerType sol_WS_ShippingContainerType)
		{
			ValidationUtility.ValidateArgument("sol_WS_ShippingContainerType", sol_WS_ShippingContainerType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShippingContainerTypeID", sol_WS_ShippingContainerType.ShippingContainerTypeID),
				new SqlParameter("@ShippingContainerType", sol_WS_ShippingContainerType.ShippingContainerType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ShippingContainerTypes_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_WS_ShippingContainerTypes table.
		/// </summary>
		public virtual void Update(Sol_WS_ShippingContainerType sol_WS_ShippingContainerType)
		{
			ValidationUtility.ValidateArgument("sol_WS_ShippingContainerType", sol_WS_ShippingContainerType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShippingContainerTypeID", sol_WS_ShippingContainerType.ShippingContainerTypeID),
				new SqlParameter("@ShippingContainerType", sol_WS_ShippingContainerType.ShippingContainerType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ShippingContainerTypes_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_WS_ShippingContainerTypes table by its primary key.
		/// </summary>
		public virtual void Delete(int shippingContainerTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShippingContainerTypeID", shippingContainerTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ShippingContainerTypes_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_WS_ShippingContainerTypes table.
		/// </summary>
		public virtual Sol_WS_ShippingContainerType Select(int shippingContainerTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ShippingContainerTypeID", shippingContainerTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ShippingContainerTypes_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_WS_ShippingContainerType(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_WS_ShippingContainerTypes table.
		/// </summary>
		public virtual List<Sol_WS_ShippingContainerType> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_WS_ShippingContainerTypes_SelectAll"))
			{
				List<Sol_WS_ShippingContainerType> sol_WS_ShippingContainerTypeList = new List<Sol_WS_ShippingContainerType>();
				while (dataReader.Read())
				{
					Sol_WS_ShippingContainerType sol_WS_ShippingContainerType = MakeSol_WS_ShippingContainerType(dataReader);
					sol_WS_ShippingContainerTypeList.Add(sol_WS_ShippingContainerType);
				}

				return sol_WS_ShippingContainerTypeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_WS_ShippingContainerTypes class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_WS_ShippingContainerType MakeSol_WS_ShippingContainerType(SqlDataReader dataReader)
		{
			Sol_WS_ShippingContainerType sol_WS_ShippingContainerType = new Sol_WS_ShippingContainerType();
			sol_WS_ShippingContainerType.ShippingContainerTypeID = SqlClientUtility.GetInt32(dataReader, "ShippingContainerTypeID", 0);
			sol_WS_ShippingContainerType.ShippingContainerType = SqlClientUtility.GetString(dataReader, "ShippingContainerType", String.Empty);

			return sol_WS_ShippingContainerType;
		}

		#endregion
	}
}
