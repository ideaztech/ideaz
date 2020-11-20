using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_Charity_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_Charity_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_Charity table.
		/// </summary>
		public virtual void Insert(Sac_Charity sac_Charity)
		{
			ValidationUtility.ValidateArgument("sac_Charity", sac_Charity);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CustomerID", sac_Charity.CustomerID),
				new SqlParameter("@ShortName", sac_Charity.ShortName),
				new SqlParameter("@CharityDescription", sac_Charity.CharityDescription),
				new SqlParameter("@CharityTypeID", sac_Charity.CharityTypeID),
				new SqlParameter("@RegistrationNumber", sac_Charity.RegistrationNumber),
				new SqlParameter("@IsActive", sac_Charity.IsActive),
				new SqlParameter("@ButtonPosition", sac_Charity.ButtonPosition),
				new SqlParameter("@Logo", sac_Charity.Logo)
			};

			sac_Charity.CharityID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sac_Charity_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_Charity table.
		/// </summary>
		public virtual void Update(Sac_Charity sac_Charity)
		{
			ValidationUtility.ValidateArgument("sac_Charity", sac_Charity);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CharityID", sac_Charity.CharityID),
				new SqlParameter("@CustomerID", sac_Charity.CustomerID),
				new SqlParameter("@ShortName", sac_Charity.ShortName),
				new SqlParameter("@CharityDescription", sac_Charity.CharityDescription),
				new SqlParameter("@CharityTypeID", sac_Charity.CharityTypeID),
				new SqlParameter("@RegistrationNumber", sac_Charity.RegistrationNumber),
				new SqlParameter("@IsActive", sac_Charity.IsActive),
				new SqlParameter("@ButtonPosition", sac_Charity.ButtonPosition),
				new SqlParameter("@Logo", sac_Charity.Logo)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Charity_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_Charity table by its primary key.
		/// </summary>
		public virtual void Delete(int charityID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CharityID", charityID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Charity_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_Charity table.
		/// </summary>
		public virtual Sac_Charity Select(int charityID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CharityID", charityID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Charity_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_Charity(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_Charity table.
		/// </summary>
		public virtual List<Sac_Charity> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Charity_SelectAll"))
			{
				List<Sac_Charity> sac_CharityList = new List<Sac_Charity>();
				while (dataReader.Read())
				{
					Sac_Charity sac_Charity = MakeSac_Charity(dataReader);
					sac_CharityList.Add(sac_Charity);
				}

				return sac_CharityList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_Charity class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_Charity MakeSac_Charity(SqlDataReader dataReader)
		{
			Sac_Charity sac_Charity = new Sac_Charity();
			sac_Charity.CharityID = SqlClientUtility.GetInt32(dataReader, "CharityID", 0);
			sac_Charity.CustomerID = SqlClientUtility.GetInt32(dataReader, "CustomerID", 0);
			sac_Charity.ShortName = SqlClientUtility.GetString(dataReader, "ShortName", String.Empty);
			sac_Charity.CharityDescription = SqlClientUtility.GetString(dataReader, "CharityDescription", String.Empty);
			sac_Charity.CharityTypeID = SqlClientUtility.GetInt32(dataReader, "CharityTypeID", 0);
			sac_Charity.RegistrationNumber = SqlClientUtility.GetString(dataReader, "RegistrationNumber", String.Empty);
			sac_Charity.IsActive = SqlClientUtility.GetBoolean(dataReader, "IsActive", false);
			sac_Charity.ButtonPosition = SqlClientUtility.GetByte(dataReader, "ButtonPosition", 0x00);
			sac_Charity.Logo = SqlClientUtility.GetBytes(dataReader, "Logo", new byte[0]);

			return sac_Charity;
		}

		#endregion
	}
}
