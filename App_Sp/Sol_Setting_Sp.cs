using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Setting_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Setting_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sol_Settings table.
		/// </summary>
		public virtual void Insert(Sol_Setting sol_Setting)
		{
			ValidationUtility.ValidateArgument("sol_Setting", sol_Setting);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sol_Setting.Name),
				new SqlParameter("@Description", sol_Setting.Description),
				new SqlParameter("@SetValue", sol_Setting.SetValue)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Settings_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sol_Settings table.
		/// </summary>
		public virtual void Update(Sol_Setting sol_Setting)
		{
			ValidationUtility.ValidateArgument("sol_Setting", sol_Setting);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sol_Setting.Name),
				new SqlParameter("@Description", sol_Setting.Description),
				new SqlParameter("@SetValue", sol_Setting.SetValue)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Settings_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sol_Settings table by its primary key.
		/// </summary>
		public virtual void Delete(string name)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", name)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Settings_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sol_Settings table.
		/// </summary>
		public virtual Sol_Setting Select(string name)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", name)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Settings_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Setting(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sol_Settings table.
		/// </summary>
		public virtual List<Sol_Setting> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Settings_SelectAll"))
			{
				List<Sol_Setting> sol_SettingList = new List<Sol_Setting>();
				while (dataReader.Read())
				{
					Sol_Setting sol_Setting = MakeSol_Setting(dataReader);
					sol_SettingList.Add(sol_Setting);
				}

				return sol_SettingList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sol_Settings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Setting MakeSol_Setting(SqlDataReader dataReader)
		{
			Sol_Setting sol_Setting = new Sol_Setting();
			sol_Setting.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sol_Setting.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_Setting.SetValue = SqlClientUtility.GetObject(dataReader, "SetValue", new object());

			return sol_Setting;
		}

		#endregion
	}
}
