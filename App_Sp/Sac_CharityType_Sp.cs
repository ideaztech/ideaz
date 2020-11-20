using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_CharityType_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_CharityType_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_CharityType table.
		/// </summary>
		public virtual void Insert(Sac_CharityType sac_CharityType)
		{
			ValidationUtility.ValidateArgument("sac_CharityType", sac_CharityType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CharityTypeID", sac_CharityType.CharityTypeID),
				new SqlParameter("@CharityType", sac_CharityType.CharityType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_CharityType_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_CharityType table.
		/// </summary>
		public virtual void Update(Sac_CharityType sac_CharityType)
		{
			ValidationUtility.ValidateArgument("sac_CharityType", sac_CharityType);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CharityTypeID", sac_CharityType.CharityTypeID),
				new SqlParameter("@CharityType", sac_CharityType.CharityType)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_CharityType_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_CharityType table by its primary key.
		/// </summary>
		public virtual void Delete(int charityTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CharityTypeID", charityTypeID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_CharityType_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_CharityType table.
		/// </summary>
		public virtual Sac_CharityType Select(int charityTypeID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CharityTypeID", charityTypeID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_CharityType_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_CharityType(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_CharityType table.
		/// </summary>
		public virtual List<Sac_CharityType> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_CharityType_SelectAll"))
			{
				List<Sac_CharityType> sac_CharityTypeList = new List<Sac_CharityType>();
				while (dataReader.Read())
				{
					Sac_CharityType sac_CharityType = MakeSac_CharityType(dataReader);
					sac_CharityTypeList.Add(sac_CharityType);
				}

				return sac_CharityTypeList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_CharityType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_CharityType MakeSac_CharityType(SqlDataReader dataReader)
		{
			Sac_CharityType sac_CharityType = new Sac_CharityType();
			sac_CharityType.CharityTypeID = SqlClientUtility.GetInt32(dataReader, "CharityTypeID", 0);
			sac_CharityType.CharityType = SqlClientUtility.GetString(dataReader, "CharityType", String.Empty);

			return sac_CharityType;
		}

		#endregion
	}
}
