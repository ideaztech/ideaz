using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_QuantityButton_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_QuantityButton_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_QuantityButtons table.
		/// </summary>
		public virtual void Insert(Sol_QuantityButton sol_QuantityButton)
		{
			ValidationUtility.ValidateArgument("sol_QuantityButton", sol_QuantityButton);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@WorkStationID", sol_QuantityButton.WorkStationID),
				new SqlParameter("@ControlType", sol_QuantityButton.ControlType),
				new SqlParameter("@Description", sol_QuantityButton.Description),
				new SqlParameter("@DefaultQuantity", sol_QuantityButton.DefaultQuantity),
				new SqlParameter("@CategoryID", sol_QuantityButton.CategoryID),
				new SqlParameter("@LocationX", sol_QuantityButton.LocationX),
				new SqlParameter("@LocationY", sol_QuantityButton.LocationY),
				new SqlParameter("@Width", sol_QuantityButton.Width),
				new SqlParameter("@Height", sol_QuantityButton.Height),
				new SqlParameter("@Font", sol_QuantityButton.Font),
				new SqlParameter("@FontStyle", sol_QuantityButton.FontStyle),
				new SqlParameter("@ForeColor", sol_QuantityButton.ForeColor),
				new SqlParameter("@BackColor", sol_QuantityButton.BackColor)
			};

			sol_QuantityButton.QuantityButtonID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_QuantityButtons_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_QuantityButtons table.
		/// </summary>
		public virtual void Update(Sol_QuantityButton sol_QuantityButton)
		{
			ValidationUtility.ValidateArgument("sol_QuantityButton", sol_QuantityButton);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@QuantityButtonID", sol_QuantityButton.QuantityButtonID),
				new SqlParameter("@WorkStationID", sol_QuantityButton.WorkStationID),
				new SqlParameter("@ControlType", sol_QuantityButton.ControlType),
				new SqlParameter("@Description", sol_QuantityButton.Description),
				new SqlParameter("@DefaultQuantity", sol_QuantityButton.DefaultQuantity),
				new SqlParameter("@CategoryID", sol_QuantityButton.CategoryID),
				new SqlParameter("@LocationX", sol_QuantityButton.LocationX),
				new SqlParameter("@LocationY", sol_QuantityButton.LocationY),
				new SqlParameter("@Width", sol_QuantityButton.Width),
				new SqlParameter("@Height", sol_QuantityButton.Height),
				new SqlParameter("@Font", sol_QuantityButton.Font),
				new SqlParameter("@FontStyle", sol_QuantityButton.FontStyle),
				new SqlParameter("@ForeColor", sol_QuantityButton.ForeColor),
				new SqlParameter("@BackColor", sol_QuantityButton.BackColor)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_QuantityButtons_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_QuantityButtons table by its primary key.
		/// </summary>
		public virtual void Delete(int quantityButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@QuantityButtonID", quantityButtonID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_QuantityButtons_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_QuantityButtons table.
		/// </summary>
		public virtual Sol_QuantityButton Select(int quantityButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@QuantityButtonID", quantityButtonID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_QuantityButtons_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_QuantityButton(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_QuantityButtons table.
		/// </summary>
		public virtual List<Sol_QuantityButton> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_QuantityButtons_SelectAll"))
			{
				List<Sol_QuantityButton> sol_QuantityButtonList = new List<Sol_QuantityButton>();
				while (dataReader.Read())
				{
					Sol_QuantityButton sol_QuantityButton = MakeSol_QuantityButton(dataReader);
					sol_QuantityButtonList.Add(sol_QuantityButton);
				}

				return sol_QuantityButtonList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_QuantityButtons class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_QuantityButton MakeSol_QuantityButton(SqlDataReader dataReader)
		{
			Sol_QuantityButton sol_QuantityButton = new Sol_QuantityButton();
			sol_QuantityButton.QuantityButtonID = SqlClientUtility.GetInt32(dataReader, "QuantityButtonID", 0);
			sol_QuantityButton.WorkStationID = SqlClientUtility.GetInt32(dataReader, "WorkStationID", 0);
			sol_QuantityButton.ControlType = SqlClientUtility.GetByte(dataReader, "ControlType", 0x00);
			sol_QuantityButton.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_QuantityButton.DefaultQuantity = SqlClientUtility.GetInt32(dataReader, "DefaultQuantity", 0);
			sol_QuantityButton.CategoryID = SqlClientUtility.GetInt32(dataReader, "CategoryID", 0);
			sol_QuantityButton.LocationX = SqlClientUtility.GetInt32(dataReader, "LocationX", 0);
			sol_QuantityButton.LocationY = SqlClientUtility.GetInt32(dataReader, "LocationY", 0);
			sol_QuantityButton.Width = SqlClientUtility.GetInt32(dataReader, "Width", 0);
			sol_QuantityButton.Height = SqlClientUtility.GetInt32(dataReader, "Height", 0);
			sol_QuantityButton.Font = SqlClientUtility.GetString(dataReader, "Font", String.Empty);
			sol_QuantityButton.FontStyle = SqlClientUtility.GetString(dataReader, "FontStyle", String.Empty);
			sol_QuantityButton.ForeColor = SqlClientUtility.GetString(dataReader, "ForeColor", String.Empty);
			sol_QuantityButton.BackColor = SqlClientUtility.GetString(dataReader, "BackColor", String.Empty);

			return sol_QuantityButton;
		}

		#endregion
	}
}
