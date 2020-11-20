using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_Money_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_Money_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_Money table.
		/// </summary>
		public virtual void Insert(Sac_Money sac_Money)
		{
			ValidationUtility.ValidateArgument("sac_Money", sac_Money);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sac_Money.Name),
				new SqlParameter("@TypeID", sac_Money.TypeID),
				new SqlParameter("@DollarValue", sac_Money.DollarValue),
				new SqlParameter("@CountryCode", sac_Money.CountryCode)
			};

			sac_Money.MoneyID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sac_Money_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_Money table.
		/// </summary>
		public virtual void Update(Sac_Money sac_Money)
		{
			ValidationUtility.ValidateArgument("sac_Money", sac_Money);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MoneyID", sac_Money.MoneyID),
				new SqlParameter("@Name", sac_Money.Name),
				new SqlParameter("@TypeID", sac_Money.TypeID),
				new SqlParameter("@DollarValue", sac_Money.DollarValue),
				new SqlParameter("@CountryCode", sac_Money.CountryCode)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Money_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_Money table by its primary key.
		/// </summary>
		public virtual void Delete(int moneyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MoneyID", moneyID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Money_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_Money table.
		/// </summary>
		public virtual Sac_Money Select(int moneyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MoneyID", moneyID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Money_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_Money(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_Money table.
		/// </summary>
		public virtual List<Sac_Money> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Money_SelectAll"))
			{
				List<Sac_Money> sac_MoneyList = new List<Sac_Money>();
				while (dataReader.Read())
				{
					Sac_Money sac_Money = MakeSac_Money(dataReader);
					sac_MoneyList.Add(sac_Money);
				}

				return sac_MoneyList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_Money class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_Money MakeSac_Money(SqlDataReader dataReader)
		{
			Sac_Money sac_Money = new Sac_Money();
			sac_Money.MoneyID = SqlClientUtility.GetInt32(dataReader, "MoneyID", 0);
			sac_Money.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sac_Money.TypeID = SqlClientUtility.GetByte(dataReader, "TypeID", 0x00);
			sac_Money.DollarValue = SqlClientUtility.GetDecimal(dataReader, "DollarValue", Decimal.Zero);
			sac_Money.CountryCode = SqlClientUtility.GetString(dataReader, "CountryCode", String.Empty);

			return sac_Money;
		}

        #endregion

        #region Aditional Methods

        /// <summary>
        /// Selects all records from the Sac_Money table by a foreign key.
        /// </summary>
        public virtual List<Sac_Money> _SelectAllByTypeID(string countryCode, int typeID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CountryCode", countryCode),
                new SqlParameter("@TypeID", typeID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Money_SelectAllByTypeID", parameters))
            {
                List<Sac_Money> sac_MoneyList = new List<Sac_Money>();
                while (dataReader.Read())
                {
                    Sac_Money sac_Money = MakeSac_Money(dataReader);
                    sac_MoneyList.Add(sac_Money);
                }

                return sac_MoneyList;
            }
        }

        #endregion

    }
}
