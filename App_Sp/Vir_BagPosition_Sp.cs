using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Vir_BagPosition_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Vir_BagPosition_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Vir_BagPosition table.
		/// </summary>
		public virtual void Insert(Vir_BagPosition vir_BagPosition)
		{
			ValidationUtility.ValidateArgument("vir_BagPosition", vir_BagPosition);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BagPositionID", vir_BagPosition.BagPositionID),
				new SqlParameter("@BagPositionName", vir_BagPosition.BagPositionName),
				new SqlParameter("@ProductID", vir_BagPosition.ProductID),
				new SqlParameter("@CurrentStageID", vir_BagPosition.CurrentStageID),
				new SqlParameter("@CurrentQuantity", vir_BagPosition.CurrentQuantity),
				new SqlParameter("@TargetQuantity", vir_BagPosition.TargetQuantity)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_BagPosition_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Vir_BagPosition table.
		/// </summary>
		public virtual void Update(Vir_BagPosition vir_BagPosition)
		{
			ValidationUtility.ValidateArgument("vir_BagPosition", vir_BagPosition);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BagPositionID", vir_BagPosition.BagPositionID),
				new SqlParameter("@BagPositionName", vir_BagPosition.BagPositionName),
				new SqlParameter("@ProductID", vir_BagPosition.ProductID),
				new SqlParameter("@CurrentStageID", vir_BagPosition.CurrentStageID),
				new SqlParameter("@CurrentQuantity", vir_BagPosition.CurrentQuantity),
				new SqlParameter("@TargetQuantity", vir_BagPosition.TargetQuantity)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_BagPosition_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Vir_BagPosition table by its primary key.
		/// </summary>
		public virtual void Delete(int bagPositionID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BagPositionID", bagPositionID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_BagPosition_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Vir_BagPosition table.
		/// </summary>
		public virtual Vir_BagPosition Select(int bagPositionID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BagPositionID", bagPositionID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_BagPosition_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeVir_BagPosition(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Vir_BagPosition table.
		/// </summary>
		public virtual List<Vir_BagPosition> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_BagPosition_SelectAll"))
			{
				List<Vir_BagPosition> vir_BagPositionList = new List<Vir_BagPosition>();
				while (dataReader.Read())
				{
					Vir_BagPosition vir_BagPosition = MakeVir_BagPosition(dataReader);
					vir_BagPositionList.Add(vir_BagPosition);
				}

				return vir_BagPositionList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Vir_BagPosition class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Vir_BagPosition MakeVir_BagPosition(SqlDataReader dataReader)
		{
			Vir_BagPosition vir_BagPosition = new Vir_BagPosition();
			vir_BagPosition.BagPositionID = SqlClientUtility.GetInt32(dataReader, "BagPositionID", 0);
			vir_BagPosition.BagPositionName = SqlClientUtility.GetString(dataReader, "BagPositionName", String.Empty);
			vir_BagPosition.ProductID = SqlClientUtility.GetInt32(dataReader, "ProductID", 0);
			vir_BagPosition.CurrentStageID = SqlClientUtility.GetInt32(dataReader, "CurrentStageID", 0);
			vir_BagPosition.CurrentQuantity = SqlClientUtility.GetInt32(dataReader, "CurrentQuantity", 0);
			vir_BagPosition.TargetQuantity = SqlClientUtility.GetInt32(dataReader, "TargetQuantity", 0);

			return vir_BagPosition;
		}

		#endregion
	}
}
