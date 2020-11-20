using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_MoneyInventory_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_MoneyInventory_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_MoneyInventory table.
		/// </summary>
		public virtual void Insert(Sac_MoneyInventory sac_MoneyInventory)
		{
			ValidationUtility.ValidateArgument("sac_MoneyInventory", sac_MoneyInventory);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", sac_MoneyInventory.ClientID),
				new SqlParameter("@MoneyID", sac_MoneyInventory.MoneyID),
				new SqlParameter("@BillDispenserID", sac_MoneyInventory.BillDispenserID),
				new SqlParameter("@Address", sac_MoneyInventory.Address),
				new SqlParameter("@Inventory", sac_MoneyInventory.Inventory),
				new SqlParameter("@MaxNumBills", sac_MoneyInventory.MaxNumBills),
				new SqlParameter("@FullQuantity", sac_MoneyInventory.FullQuantity)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_MoneyInventory table.
		/// </summary>
		public virtual void Update(Sac_MoneyInventory sac_MoneyInventory)
		{
			ValidationUtility.ValidateArgument("sac_MoneyInventory", sac_MoneyInventory);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", sac_MoneyInventory.ClientID),
				new SqlParameter("@MoneyID", sac_MoneyInventory.MoneyID),
				new SqlParameter("@BillDispenserID", sac_MoneyInventory.BillDispenserID),
				new SqlParameter("@Address", sac_MoneyInventory.Address),
				new SqlParameter("@Inventory", sac_MoneyInventory.Inventory),
				new SqlParameter("@MaxNumBills", sac_MoneyInventory.MaxNumBills),
				new SqlParameter("@FullQuantity", sac_MoneyInventory.FullQuantity)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_MoneyInventory table by its primary key.
		/// </summary>
		public virtual void Delete(string clientID, int moneyID, int billDispenserID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", clientID),
				new SqlParameter("@MoneyID", moneyID),
				new SqlParameter("@BillDispenserID", billDispenserID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_MoneyInventory table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByMoneyID(int moneyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MoneyID", moneyID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_DeleteAllByMoneyID", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_MoneyInventory table.
		/// </summary>
		public virtual Sac_MoneyInventory Select(string clientID, int moneyID, int billDispenserID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ClientID", clientID),
				new SqlParameter("@MoneyID", moneyID),
				new SqlParameter("@BillDispenserID", billDispenserID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_MoneyInventory(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_MoneyInventory table.
		/// </summary>
		public virtual List<Sac_MoneyInventory> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_SelectAll"))
			{
				List<Sac_MoneyInventory> sac_MoneyInventoryList = new List<Sac_MoneyInventory>();
				while (dataReader.Read())
				{
					Sac_MoneyInventory sac_MoneyInventory = MakeSac_MoneyInventory(dataReader);
					sac_MoneyInventoryList.Add(sac_MoneyInventory);
				}

				return sac_MoneyInventoryList;
			}
		}

		/// <summary>
		/// Selects all records from the Sac_MoneyInventory table by a foreign key.
		/// </summary>
		public virtual List<Sac_MoneyInventory> _SelectAllByMoneyID(int moneyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MoneyID", moneyID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_SelectAllByMoneyID", parameters))
			{
				List<Sac_MoneyInventory> sac_MoneyInventoryList = new List<Sac_MoneyInventory>();
				while (dataReader.Read())
				{
					Sac_MoneyInventory sac_MoneyInventory = MakeSac_MoneyInventory(dataReader);
					sac_MoneyInventoryList.Add(sac_MoneyInventory);
				}

				return sac_MoneyInventoryList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_MoneyInventory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_MoneyInventory MakeSac_MoneyInventory(SqlDataReader dataReader)
		{
			Sac_MoneyInventory sac_MoneyInventory = new Sac_MoneyInventory();
			sac_MoneyInventory.ClientID = SqlClientUtility.GetString(dataReader, "ClientID", String.Empty);
			sac_MoneyInventory.MoneyID = SqlClientUtility.GetInt32(dataReader, "MoneyID", 0);
			sac_MoneyInventory.BillDispenserID = SqlClientUtility.GetInt32(dataReader, "BillDispenserID", 0);
			sac_MoneyInventory.Address = SqlClientUtility.GetString(dataReader, "Address", String.Empty);
			sac_MoneyInventory.Inventory = SqlClientUtility.GetInt32(dataReader, "Inventory", 0);
			sac_MoneyInventory.MaxNumBills = SqlClientUtility.GetInt32(dataReader, "MaxNumBills", 0);
			sac_MoneyInventory.FullQuantity = SqlClientUtility.GetInt32(dataReader, "FullQuantity", 0);

			return sac_MoneyInventory;
		}

        #endregion

        #region Aditional Methods

        /// <summary>
        /// Selects all records from the Sac_MoneyInventory table by a foreign key.
        /// </summary>
        public virtual List<Sac_MoneyInventory> _SelectAllByClientID(string clientID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ClientID", clientID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_MoneyInventory_SelectAllByClientID", parameters))
            {
                List<Sac_MoneyInventory> sac_MoneyInventoryList = new List<Sac_MoneyInventory>();
                while (dataReader.Read())
                {
                    Sac_MoneyInventory sac_MoneyInventory = MakeSac_MoneyInventory(dataReader);
                    sac_MoneyInventoryList.Add(sac_MoneyInventory);
                }

                return sac_MoneyInventoryList;
            }
        }

        #endregion

    }
}
