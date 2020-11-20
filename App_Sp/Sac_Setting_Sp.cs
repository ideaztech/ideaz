using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sac_Setting_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sac_Setting_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sac_Settings table.
		/// </summary>
		public virtual void Insert(Sac_Setting sac_Setting)
		{
			ValidationUtility.ValidateArgument("sac_Setting", sac_Setting);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sac_Setting.Name),
				new SqlParameter("@Description", sac_Setting.Description),
				new SqlParameter("@SetValue", sac_Setting.SetValue)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Settings_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sac_Settings table.
		/// </summary>
		public virtual void Update(Sac_Setting sac_Setting)
		{
			ValidationUtility.ValidateArgument("sac_Setting", sac_Setting);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", sac_Setting.Name),
				new SqlParameter("@Description", sac_Setting.Description),
				new SqlParameter("@SetValue", sac_Setting.SetValue)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Settings_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sac_Settings table by its primary key.
		/// </summary>
		public virtual void Delete(string name)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", name)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sac_Settings_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sac_Settings table.
		/// </summary>
		public virtual Sac_Setting Select(string name)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name", name)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Settings_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSac_Setting(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Sac_Settings table.
		/// </summary>
		public virtual List<Sac_Setting> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sac_Settings_SelectAll"))
			{
				List<Sac_Setting> sac_SettingList = new List<Sac_Setting>();
				while (dataReader.Read())
				{
					Sac_Setting sac_Setting = MakeSac_Setting(dataReader);
					sac_SettingList.Add(sac_Setting);
				}

				return sac_SettingList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Sac_Settings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sac_Setting MakeSac_Setting(SqlDataReader dataReader)
		{
			Sac_Setting sac_Setting = new Sac_Setting();
			sac_Setting.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			sac_Setting.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sac_Setting.SetValue = SqlClientUtility.GetBytes(dataReader, "SetValue", new byte[0]);

			return sac_Setting;
		}

		#endregion
	}
}
