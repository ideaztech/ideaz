using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Qds_PaymentMethod_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Qds_PaymentMethod_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Qds_PaymentMethod table.
		/// </summary>
		public virtual void Insert(Qds_PaymentMethod qds_PaymentMethod)
		{
			ValidationUtility.ValidateArgument("qds_PaymentMethod", qds_PaymentMethod);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethod", qds_PaymentMethod.PaymentMethod)
			};

			qds_PaymentMethod.PaymentMethodID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethod_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Qds_PaymentMethod table.
		/// </summary>
		public virtual void Update(Qds_PaymentMethod qds_PaymentMethod)
		{
			ValidationUtility.ValidateArgument("qds_PaymentMethod", qds_PaymentMethod);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethodID", qds_PaymentMethod.PaymentMethodID),
				new SqlParameter("@PaymentMethod", qds_PaymentMethod.PaymentMethod)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethod_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_PaymentMethod table by its primary key.
		/// </summary>
		public virtual void Delete(int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethod_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Qds_PaymentMethod table.
		/// </summary>
		public virtual Qds_PaymentMethod Select(int paymentMethodID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PaymentMethodID", paymentMethodID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethod_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeQds_PaymentMethod(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Qds_PaymentMethod table.
		/// </summary>
		public virtual List<Qds_PaymentMethod> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_PaymentMethod_SelectAll"))
			{
				List<Qds_PaymentMethod> qds_PaymentMethodList = new List<Qds_PaymentMethod>();
				while (dataReader.Read())
				{
					Qds_PaymentMethod qds_PaymentMethod = MakeQds_PaymentMethod(dataReader);
					qds_PaymentMethodList.Add(qds_PaymentMethod);
				}

				return qds_PaymentMethodList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Qds_PaymentMethod class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Qds_PaymentMethod MakeQds_PaymentMethod(SqlDataReader dataReader)
		{
			Qds_PaymentMethod qds_PaymentMethod = new Qds_PaymentMethod();
			qds_PaymentMethod.PaymentMethodID = SqlClientUtility.GetInt32(dataReader, "PaymentMethodID", 0);
			qds_PaymentMethod.PaymentMethod = SqlClientUtility.GetString(dataReader, "PaymentMethod", String.Empty);

			return qds_PaymentMethod;
		}

		#endregion
	}
}
