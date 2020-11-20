using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Qds_PaymentMethodAvailableByDepot_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Qds_PaymentMethodAvailableByDepot_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Qds_PaymentMethodAvailableByDepot table.
		/// </summary>
		public virtual void Insert(Qds_PaymentMethodAvailableByDepot qds_PaymentMethodAvailableByDepot)
		{
			ValidationUtility.ValidateArgument("qds_PaymentMethodAvailableByDepot", qds_PaymentMethodAvailableByDepot);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DepotID", qds_PaymentMethodAvailableByDepot.DepotID),
				new SqlParameter("@PaymentMethodID", qds_PaymentMethodAvailableByDepot.PaymentMethodID),
				new SqlParameter("@DepotDefault", qds_PaymentMethodAvailableByDepot.DepotDefault)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethodAvailableByDepot_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Qds_PaymentMethodAvailableByDepot table.
		/// </summary>
		public virtual void Update(Qds_PaymentMethodAvailableByDepot qds_PaymentMethodAvailableByDepot)
		{
			ValidationUtility.ValidateArgument("qds_PaymentMethodAvailableByDepot", qds_PaymentMethodAvailableByDepot);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DepotID", qds_PaymentMethodAvailableByDepot.DepotID),
				new SqlParameter("@PaymentMethodID", qds_PaymentMethodAvailableByDepot.PaymentMethodID),
				new SqlParameter("@DepotDefault", qds_PaymentMethodAvailableByDepot.DepotDefault)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethodAvailableByDepot_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_PaymentMethodAvailableByDepot table by its primary key.
		/// </summary>
		public virtual void Delete(string depotID, int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DepotID", depotID),
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethodAvailableByDepot_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_PaymentMethodAvailableByDepot table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByPaymentMethodID(int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethodAvailableByDepot_DeleteAllByPaymentMethodID", parameters);
		}

		/// <summary>
		/// Selects a single record from the Qds_PaymentMethodAvailableByDepot table.
		/// </summary>
		public virtual Qds_PaymentMethodAvailableByDepot Select(string depotID, int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DepotID", depotID),
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethodAvailableByDepot_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeQds_PaymentMethodAvailableByDepot(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Qds_PaymentMethodAvailableByDepot table.
		/// </summary>
		public virtual List<Qds_PaymentMethodAvailableByDepot> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethodAvailableByDepot_SelectAll"))
			{
				List<Qds_PaymentMethodAvailableByDepot> qds_PaymentMethodAvailableByDepotList = new List<Qds_PaymentMethodAvailableByDepot>();
				while (dataReader.Read())
				{
					Qds_PaymentMethodAvailableByDepot qds_PaymentMethodAvailableByDepot = MakeQds_PaymentMethodAvailableByDepot(dataReader);
					qds_PaymentMethodAvailableByDepotList.Add(qds_PaymentMethodAvailableByDepot);
				}

				return qds_PaymentMethodAvailableByDepotList;
			}
		}

		/// <summary>
		/// Selects all records from the Qds_PaymentMethodAvailableByDepot table by a foreign key.
		/// </summary>
		public virtual List<Qds_PaymentMethodAvailableByDepot> _SelectAllByPaymentMethodID(int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethodAvailableByDepot_SelectAllByPaymentMethodID", parameters))
			{
				List<Qds_PaymentMethodAvailableByDepot> qds_PaymentMethodAvailableByDepotList = new List<Qds_PaymentMethodAvailableByDepot>();
				while (dataReader.Read())
				{
					Qds_PaymentMethodAvailableByDepot qds_PaymentMethodAvailableByDepot = MakeQds_PaymentMethodAvailableByDepot(dataReader);
					qds_PaymentMethodAvailableByDepotList.Add(qds_PaymentMethodAvailableByDepot);
				}

				return qds_PaymentMethodAvailableByDepotList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Qds_PaymentMethodAvailableByDepot class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Qds_PaymentMethodAvailableByDepot MakeQds_PaymentMethodAvailableByDepot(SqlDataReader dataReader)
		{
			Qds_PaymentMethodAvailableByDepot qds_PaymentMethodAvailableByDepot = new Qds_PaymentMethodAvailableByDepot();
			qds_PaymentMethodAvailableByDepot.DepotID = SqlClientUtility.GetString(dataReader, "DepotID", String.Empty);
			qds_PaymentMethodAvailableByDepot.PaymentMethodID = SqlClientUtility.GetInt32(dataReader, "PaymentMethodID", 0);
			qds_PaymentMethodAvailableByDepot.DepotDefault = SqlClientUtility.GetBoolean(dataReader, "DepotDefault", false);

			return qds_PaymentMethodAvailableByDepot;
		}

		#endregion
	}
}
