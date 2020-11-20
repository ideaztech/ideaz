using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Message_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Message_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Messages table.
		/// </summary>
		public virtual void Insert(Sol_Message sol_Message)
		{
			ValidationUtility.ValidateArgument("sol_Message", sol_Message);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sol_Message.Name),
				new SqlParameter("@Description", sol_Message.Description)
			};

			sol_Message.MessageID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Messages_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Messages table.
		/// </summary>
		public virtual void Update(Sol_Message sol_Message)
		{
			ValidationUtility.ValidateArgument("sol_Message", sol_Message);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MessageID", sol_Message.MessageID),
				new SqlParameter("@Name", sol_Message.Name),
				new SqlParameter("@Description", sol_Message.Description)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Messages_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Messages table by its primary key.
		/// </summary>
		public virtual void Delete(int messageID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MessageID", messageID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Messages_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Messages table.
		/// </summary>
		public virtual Sol_Message Select(int messageID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MessageID", messageID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Messages_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Message(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Messages table.
		/// </summary>
		public virtual List<Sol_Message> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Messages_SelectAll"))
			{
				List<Sol_Message> sol_MessageList = new List<Sol_Message>();
				while (dataReader.Read())
				{
					Sol_Message sol_Message = MakeSol_Message(dataReader);
					sol_MessageList.Add(sol_Message);
				}

				return sol_MessageList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Messages class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Message MakeSol_Message(SqlDataReader dataReader)
		{
			Sol_Message sol_Message = new Sol_Message();
			sol_Message.MessageID = SqlClientUtility.GetInt32(dataReader, "MessageID", 0);
			sol_Message.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sol_Message.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);

			return sol_Message;
		}

		#endregion
	}
}
