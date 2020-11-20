using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Container_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Container_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Containers table.
		/// </summary>
		public virtual void Insert(Sol_Container sol_Container)
		{
			ValidationUtility.ValidateArgument("sol_Container", sol_Container);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Description", sol_Container.Description),
				new SqlParameter("@ShortDescription", sol_Container.ShortDescription),
				new SqlParameter("@ContainerTypeID", sol_Container.ContainerTypeID),
				new SqlParameter("@ShippingContainerID", sol_Container.ShippingContainerID),
				new SqlParameter("@ShippingContainerTypeID", sol_Container.ShippingContainerTypeID)
			};

			sol_Container.ContainerID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Containers_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Containers table.
		/// </summary>
		public virtual void Update(Sol_Container sol_Container)
		{
			ValidationUtility.ValidateArgument("sol_Container", sol_Container);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerID", sol_Container.ContainerID),
				new SqlParameter("@Description", sol_Container.Description),
				new SqlParameter("@ShortDescription", sol_Container.ShortDescription),
				new SqlParameter("@ContainerTypeID", sol_Container.ContainerTypeID),
				new SqlParameter("@ShippingContainerID", sol_Container.ShippingContainerID),
				new SqlParameter("@ShippingContainerTypeID", sol_Container.ShippingContainerTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Containers_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Containers table by its primary key.
		/// </summary>
		public virtual void Delete(int containerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerID", containerID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Containers_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Containers table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByContainerTypeID(int containerTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerTypeID", containerTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Containers_DeleteAllByContainerTypeID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Containers table.
		/// </summary>
		public virtual Sol_Container Select(int containerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerID", containerID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Containers_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Container(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Containers table.
		/// </summary>
		public virtual List<Sol_Container> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Containers_SelectAll"))
			{
				List<Sol_Container> sol_ContainerList = new List<Sol_Container>();
				while (dataReader.Read())
				{
					Sol_Container sol_Container = MakeSol_Container(dataReader);
					sol_ContainerList.Add(sol_Container);
				}

				return sol_ContainerList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Containers table by a foreign key.
		/// </summary>
		public virtual List<Sol_Container> _SelectAllByContainerTypeID(int containerTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerTypeID", containerTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Containers_SelectAllByContainerTypeID", parameters))
			{
				List<Sol_Container> sol_ContainerList = new List<Sol_Container>();
				while (dataReader.Read())
				{
					Sol_Container sol_Container = MakeSol_Container(dataReader);
					sol_ContainerList.Add(sol_Container);
				}

				return sol_ContainerList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Containers class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Container MakeSol_Container(SqlDataReader dataReader)
		{
			Sol_Container sol_Container = new Sol_Container();
			sol_Container.ContainerID = SqlClientUtility.GetInt32(dataReader, "ContainerID", 0);
			sol_Container.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_Container.ShortDescription = SqlClientUtility.GetString(dataReader, "ShortDescription", String.Empty);
			sol_Container.ContainerTypeID = SqlClientUtility.GetInt32(dataReader, "ContainerTypeID", 0);
			sol_Container.ShippingContainerID = SqlClientUtility.GetInt32(dataReader, "ShippingContainerID", 0);
			sol_Container.ShippingContainerTypeID = SqlClientUtility.GetInt32(dataReader, "ShippingContainerTypeID", 0);

			return sol_Container;
		}

		#endregion
	}
}
