using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_OrderCardLink_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_OrderCardLink_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_OrderCardLink table.
		/// </summary>
		public virtual void Insert(Sol_OrderCardLink sol_OrderCardLink)
		{
			ValidationUtility.ValidateArgument("sol_OrderCardLink", sol_OrderCardLink);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardNumber", sol_OrderCardLink.CardNumber),
				new SqlParameter("@OrderID", sol_OrderCardLink.OrderID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLink_Insert", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_OrderCardLink table by its primary key.
		/// </summary>
		public virtual void Delete(string cardNumber, int orderID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardNumber", cardNumber),
				new SqlParameter("@OrderID", orderID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLink_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_OrderCardLink table.
		/// </summary>
		public virtual Sol_OrderCardLink Select(string cardNumber, int orderID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CardNumber", cardNumber),
				new SqlParameter("@OrderID", orderID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLink_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_OrderCardLink(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_OrderCardLink class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_OrderCardLink MakeSol_OrderCardLink(SqlDataReader dataReader)
		{
			Sol_OrderCardLink sol_OrderCardLink = new Sol_OrderCardLink();
			sol_OrderCardLink.CardNumber = SqlClientUtility.GetString(dataReader, "CardNumber", String.Empty);
			sol_OrderCardLink.OrderID = SqlClientUtility.GetInt32(dataReader, "OrderID", 0);

			return sol_OrderCardLink;
		}

        #endregion

        #region Aditional Methods

        /// <summary>
        /// Selects a single record from the Sol_OrderCardLink table.
        /// </summary>
        public virtual Sol_OrderCardLink SelectByCardNumber(string cardNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CardNumber", cardNumber)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLink_SelectByCardNumber", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_OrderCardLink(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Deletes a record from the Sol_OrderCardLink table by its primary key.
        /// </summary>
        public virtual void DeleteByCardNumber(string cardNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CardNumber", cardNumber)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLink_DeleteByCardNumber", parameters);
        }


        /// <summary>
        /// Selects all records from the Sol_OrderCardLink table by a foreign key.
        /// </summary>
        public virtual List<Sol_OrderCardLink> SelectAllByCardNumber(string cardNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CardNumber", cardNumber)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_OrderCardLink_SelectByCardNumber", parameters))
            {
                List<Sol_OrderCardLink> sol_OrderCardLinkList = new List<Sol_OrderCardLink>();
                while (dataReader.Read())
                {
                    Sol_OrderCardLink sol_OrderCardLink = MakeSol_OrderCardLink(dataReader);
                    sol_OrderCardLinkList.Add(sol_OrderCardLink);
                }

                return sol_OrderCardLinkList;
            }
        }


        #endregion

    }
}
