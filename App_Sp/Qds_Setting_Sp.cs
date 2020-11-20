using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Qds_Setting_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Qds_Setting_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Qds_Settings table.
		/// </summary>
		public virtual void Insert(Qds_Setting qds_Setting)
		{
			ValidationUtility.ValidateArgument("qds_Setting", qds_Setting);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", qds_Setting.Name),
				new SqlParameter("@Description", qds_Setting.Description),
				new SqlParameter("@SetValue", qds_Setting.SetValue)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Settings_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Qds_Settings table.
		/// </summary>
		public virtual void Update(Qds_Setting qds_Setting)
		{
			ValidationUtility.ValidateArgument("qds_Setting", qds_Setting);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", qds_Setting.Name),
				new SqlParameter("@Description", qds_Setting.Description),
				new SqlParameter("@SetValue", qds_Setting.SetValue)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Settings_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Qds_Settings table by its primary key.
		/// </summary>
		public virtual void Delete(string name)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", name)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Settings_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Qds_Settings table.
		/// </summary>
		public virtual Qds_Setting Select(string name)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", name)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Settings_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeQds_Setting(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Qds_Settings table.
		/// </summary>
		public virtual List<Qds_Setting> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Settings_SelectAll"))
			{
				List<Qds_Setting> qds_SettingList = new List<Qds_Setting>();
				while (dataReader.Read())
				{
					Qds_Setting qds_Setting = MakeQds_Setting(dataReader);
					qds_SettingList.Add(qds_Setting);
				}

				return qds_SettingList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Qds_Settings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Qds_Setting MakeQds_Setting(SqlDataReader dataReader)
		{
			Qds_Setting qds_Setting = new Qds_Setting();
			qds_Setting.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			qds_Setting.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			qds_Setting.SetValue = SqlClientUtility.GetObject(dataReader, "SetValue", new object());

			return qds_Setting;
		}

		#endregion
	}
}
