using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Qds_CardType_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Qds_CardType_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Qds_CardType table.
		/// </summary>
		public virtual void Insert(Qds_CardType qds_CardType)
		{
			ValidationUtility.ValidateArgument("qds_CardType", qds_CardType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardType", qds_CardType.CardType)
			};

			qds_CardType.CardTypeID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Qds_CardType_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Qds_CardType table.
		/// </summary>
		public virtual void Update(Qds_CardType qds_CardType)
		{
			ValidationUtility.ValidateArgument("qds_CardType", qds_CardType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardTypeID", qds_CardType.CardTypeID),
				new SqlParameter("@CardType", qds_CardType.CardType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_CardType_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_CardType table by its primary key.
		/// </summary>
		public virtual void Delete(int cardTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardTypeID", cardTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_CardType_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Qds_CardType table.
		/// </summary>
		public virtual Qds_CardType Select(int cardTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardTypeID", cardTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_CardType_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeQds_CardType(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Qds_CardType table.
		/// </summary>
		public virtual List<Qds_CardType> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_CardType_SelectAll"))
			{
				List<Qds_CardType> qds_CardTypeList = new List<Qds_CardType>();
				while (dataReader.Read())
				{
					Qds_CardType qds_CardType = MakeQds_CardType(dataReader);
					qds_CardTypeList.Add(qds_CardType);
				}

				return qds_CardTypeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Qds_CardType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Qds_CardType MakeQds_CardType(SqlDataReader dataReader)
		{
			Qds_CardType qds_CardType = new Qds_CardType();
			qds_CardType.CardTypeID = SqlClientUtility.GetInt32(dataReader, "CardTypeID", 0);
			qds_CardType.CardType = SqlClientUtility.GetString(dataReader, "CardType", String.Empty);

			return qds_CardType;
		}

		#endregion
	}
}
