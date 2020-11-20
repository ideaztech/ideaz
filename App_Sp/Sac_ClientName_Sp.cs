using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_ClientName_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_ClientName_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_ClientNames table.
		/// </summary>
		public virtual void Insert(Sac_ClientName sac_ClientName)
		{
			ValidationUtility.ValidateArgument("sac_ClientName", sac_ClientName);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", sac_ClientName.ClientID),
				new SqlParameter("@CashTrayID", sac_ClientName.CashTrayID),
				new SqlParameter("@CoinAmountInventory", sac_ClientName.CoinAmountInventory)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_ClientNames_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_ClientNames table.
		/// </summary>
		public virtual void Update(Sac_ClientName sac_ClientName)
		{
			ValidationUtility.ValidateArgument("sac_ClientName", sac_ClientName);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", sac_ClientName.ClientID),
				new SqlParameter("@CashTrayID", sac_ClientName.CashTrayID),
				new SqlParameter("@CoinAmountInventory", sac_ClientName.CoinAmountInventory)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_ClientNames_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_ClientNames table by its primary key.
		/// </summary>
		public virtual void Delete(string clientID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", clientID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_ClientNames_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_ClientNames table.
		/// </summary>
		public virtual Sac_ClientName Select(string clientID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", clientID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_ClientNames_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_ClientName(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_ClientNames table.
		/// </summary>
		public virtual List<Sac_ClientName> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_ClientNames_SelectAll"))
			{
				List<Sac_ClientName> sac_ClientNameList = new List<Sac_ClientName>();
				while (dataReader.Read())
				{
					Sac_ClientName sac_ClientName = MakeSac_ClientName(dataReader);
					sac_ClientNameList.Add(sac_ClientName);
				}

				return sac_ClientNameList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_ClientNames class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_ClientName MakeSac_ClientName(SqlDataReader dataReader)
		{
			Sac_ClientName sac_ClientName = new Sac_ClientName();
			sac_ClientName.ClientID = SqlClientUtility.GetString(dataReader, "ClientID", String.Empty);
			sac_ClientName.CashTrayID = SqlClientUtility.GetInt32(dataReader, "CashTrayID", 0);
			sac_ClientName.CoinAmountInventory = SqlClientUtility.GetDecimal(dataReader, "CoinAmountInventory", Decimal.Zero);

			return sac_ClientName;
		}

        #endregion

        #region Aditional Methods

        /// <summary>
        /// Selects a single record from the Sac_ClientNames table.
        /// </summary>
        public virtual Sac_ClientName SelectByCashTrayID(int cashTrayID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CashTrayID", cashTrayID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_ClientNames_SelectByCashTrayID", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSac_ClientName(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

    }
}
