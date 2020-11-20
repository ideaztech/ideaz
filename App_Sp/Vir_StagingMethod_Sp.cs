using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Vir_StagingMethod_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Vir_StagingMethod_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Vir_StagingMethod table.
		/// </summary>
		public virtual void Insert(Vir_StagingMethod vir_StagingMethod)
		{
			ValidationUtility.ValidateArgument("vir_StagingMethod", vir_StagingMethod);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StagingMethodName", vir_StagingMethod.StagingMethodName)
			};

			vir_StagingMethod.StagingMethodID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Vir_StagingMethod_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Vir_StagingMethod table.
		/// </summary>
		public virtual void Update(Vir_StagingMethod vir_StagingMethod)
		{
			ValidationUtility.ValidateArgument("vir_StagingMethod", vir_StagingMethod);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StagingMethodID", vir_StagingMethod.StagingMethodID),
				new SqlParameter("@StagingMethodName", vir_StagingMethod.StagingMethodName)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_StagingMethod_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Vir_StagingMethod table by its primary key.
		/// </summary>
		public virtual void Delete(int stagingMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StagingMethodID", stagingMethodID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_StagingMethod_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Vir_StagingMethod table.
		/// </summary>
		public virtual Vir_StagingMethod Select(int stagingMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StagingMethodID", stagingMethodID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_StagingMethod_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeVir_StagingMethod(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Vir_StagingMethod table.
		/// </summary>
		public virtual List<Vir_StagingMethod> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_StagingMethod_SelectAll"))
			{
				List<Vir_StagingMethod> vir_StagingMethodList = new List<Vir_StagingMethod>();
				while (dataReader.Read())
				{
					Vir_StagingMethod vir_StagingMethod = MakeVir_StagingMethod(dataReader);
					vir_StagingMethodList.Add(vir_StagingMethod);
				}

				return vir_StagingMethodList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Vir_StagingMethod class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Vir_StagingMethod MakeVir_StagingMethod(SqlDataReader dataReader)
		{
			Vir_StagingMethod vir_StagingMethod = new Vir_StagingMethod();
			vir_StagingMethod.StagingMethodID = SqlClientUtility.GetInt32(dataReader, "StagingMethodID", 0);
			vir_StagingMethod.StagingMethodName = SqlClientUtility.GetString(dataReader, "StagingMethodName", String.Empty);

			return vir_StagingMethod;
		}

		#endregion
	}
}
