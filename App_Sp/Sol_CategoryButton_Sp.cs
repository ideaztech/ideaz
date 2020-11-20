using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_CategoryButton_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_CategoryButton_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_CategoryButtons table.
		/// </summary>
		public virtual void Insert(Sol_CategoryButton sol_CategoryButton)
		{
			ValidationUtility.ValidateArgument("sol_CategoryButton", sol_CategoryButton);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@WorkStationID", sol_CategoryButton.WorkStationID),
				new SqlParameter("@ControlType", sol_CategoryButton.ControlType),
				new SqlParameter("@Description", sol_CategoryButton.Description),
				new SqlParameter("@DefaultQuantity", sol_CategoryButton.DefaultQuantity),
				new SqlParameter("@CategoryID", sol_CategoryButton.CategoryID),
				new SqlParameter("@LocationX", sol_CategoryButton.LocationX),
				new SqlParameter("@LocationY", sol_CategoryButton.LocationY),
				new SqlParameter("@Width", sol_CategoryButton.Width),
				new SqlParameter("@Height", sol_CategoryButton.Height),
				new SqlParameter("@Font", sol_CategoryButton.Font),
				new SqlParameter("@FontStyle", sol_CategoryButton.FontStyle),
				new SqlParameter("@ForeColor", sol_CategoryButton.ForeColor),
				new SqlParameter("@BackColor", sol_CategoryButton.BackColor),
				new SqlParameter("@ImageIndex", sol_CategoryButton.ImageIndex),
				new SqlParameter("@ImagePath", sol_CategoryButton.ImagePath),
				new SqlParameter("@SubContainerMaxCount", sol_CategoryButton.SubContainerMaxCount),
				new SqlParameter("@SubContainerCounter", sol_CategoryButton.SubContainerCounter),
				new SqlParameter("@ImageSize", sol_CategoryButton.ImageSize),
				new SqlParameter("@SubContainerCountDown", sol_CategoryButton.SubContainerCountDown),
				new SqlParameter("@MaxCountPerLine", sol_CategoryButton.MaxCountPerLine)
				//new SqlParameter("@ForeColorArgb", sol_CategoryButton.ForeColorArgb),
				//new SqlParameter("@BackColorArgb", sol_CategoryButton.BackColorArgb)
			};

			sol_CategoryButton.CategoryButtonID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_CategoryButtons table.
		/// </summary>
		public virtual void Update(Sol_CategoryButton sol_CategoryButton)
		{
			ValidationUtility.ValidateArgument("sol_CategoryButton", sol_CategoryButton);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryButtonID", sol_CategoryButton.CategoryButtonID),
				new SqlParameter("@WorkStationID", sol_CategoryButton.WorkStationID),
				new SqlParameter("@ControlType", sol_CategoryButton.ControlType),
				new SqlParameter("@Description", sol_CategoryButton.Description),
				new SqlParameter("@DefaultQuantity", sol_CategoryButton.DefaultQuantity),
				new SqlParameter("@CategoryID", sol_CategoryButton.CategoryID),
				new SqlParameter("@LocationX", sol_CategoryButton.LocationX),
				new SqlParameter("@LocationY", sol_CategoryButton.LocationY),
				new SqlParameter("@Width", sol_CategoryButton.Width),
				new SqlParameter("@Height", sol_CategoryButton.Height),
				new SqlParameter("@Font", sol_CategoryButton.Font),
				new SqlParameter("@FontStyle", sol_CategoryButton.FontStyle),
				new SqlParameter("@ForeColor", sol_CategoryButton.ForeColor),
				new SqlParameter("@BackColor", sol_CategoryButton.BackColor),
				new SqlParameter("@ImageIndex", sol_CategoryButton.ImageIndex),
				new SqlParameter("@ImagePath", sol_CategoryButton.ImagePath),
				new SqlParameter("@SubContainerMaxCount", sol_CategoryButton.SubContainerMaxCount),
				new SqlParameter("@SubContainerCounter", sol_CategoryButton.SubContainerCounter),
				new SqlParameter("@ImageSize", sol_CategoryButton.ImageSize),
				new SqlParameter("@SubContainerCountDown", sol_CategoryButton.SubContainerCountDown),
				new SqlParameter("@MaxCountPerLine", sol_CategoryButton.MaxCountPerLine)
				//new SqlParameter("@ForeColorArgb", sol_CategoryButton.ForeColorArgb),
				//new SqlParameter("@BackColorArgb", sol_CategoryButton.BackColorArgb)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_CategoryButtons table by its primary key.
		/// </summary>
		public virtual void Delete(int categoryButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryButtonID", categoryButtonID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_CategoryButtons table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCategoryID(int categoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryID", categoryID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_DeleteAllByCategoryID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_CategoryButtons table.
		/// </summary>
		public virtual Sol_CategoryButton Select(int categoryButtonID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryButtonID", categoryButtonID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_CategoryButton(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_CategoryButtons table.
		/// </summary>
		public virtual List<Sol_CategoryButton> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_SelectAll"))
			{
				List<Sol_CategoryButton> sol_CategoryButtonList = new List<Sol_CategoryButton>();
				while (dataReader.Read())
				{
					Sol_CategoryButton sol_CategoryButton = MakeSol_CategoryButton(dataReader);
					sol_CategoryButtonList.Add(sol_CategoryButton);
				}

				return sol_CategoryButtonList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_CategoryButtons table by a foreign key.
		/// </summary>
		public virtual List<Sol_CategoryButton> _SelectAllByCategoryID(int categoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryID", categoryID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_SelectAllByCategoryID", parameters))
			{
				List<Sol_CategoryButton> sol_CategoryButtonList = new List<Sol_CategoryButton>();
				while (dataReader.Read())
				{
					Sol_CategoryButton sol_CategoryButton = MakeSol_CategoryButton(dataReader);
					sol_CategoryButtonList.Add(sol_CategoryButton);
				}

				return sol_CategoryButtonList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_CategoryButtons class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_CategoryButton MakeSol_CategoryButton(SqlDataReader dataReader)
		{
			Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();
			sol_CategoryButton.CategoryButtonID = SqlClientUtility.GetInt32(dataReader, "CategoryButtonID", 0);
			sol_CategoryButton.WorkStationID = SqlClientUtility.GetInt32(dataReader, "WorkStationID", 0);
			sol_CategoryButton.ControlType = SqlClientUtility.GetByte(dataReader, "ControlType", 0x00);
			sol_CategoryButton.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
			sol_CategoryButton.DefaultQuantity = SqlClientUtility.GetInt32(dataReader, "DefaultQuantity", 0);
			sol_CategoryButton.CategoryID = SqlClientUtility.GetInt32(dataReader, "CategoryID", 0);
			sol_CategoryButton.LocationX = SqlClientUtility.GetInt32(dataReader, "LocationX", 0);
			sol_CategoryButton.LocationY = SqlClientUtility.GetInt32(dataReader, "LocationY", 0);
			sol_CategoryButton.Width = SqlClientUtility.GetInt32(dataReader, "Width", 0);
			sol_CategoryButton.Height = SqlClientUtility.GetInt32(dataReader, "Height", 0);
			sol_CategoryButton.Font = SqlClientUtility.GetString(dataReader, "Font", String.Empty);
			sol_CategoryButton.FontStyle = SqlClientUtility.GetString(dataReader, "FontStyle", String.Empty);
			sol_CategoryButton.ForeColor = SqlClientUtility.GetString(dataReader, "ForeColor", String.Empty);
			sol_CategoryButton.BackColor = SqlClientUtility.GetString(dataReader, "BackColor", String.Empty);
			sol_CategoryButton.ImageIndex = SqlClientUtility.GetInt32(dataReader, "ImageIndex", 0);
			sol_CategoryButton.ImagePath = SqlClientUtility.GetString(dataReader, "ImagePath", String.Empty);
			sol_CategoryButton.SubContainerMaxCount = SqlClientUtility.GetInt32(dataReader, "SubContainerMaxCount", 0);
			sol_CategoryButton.SubContainerCounter = SqlClientUtility.GetInt32(dataReader, "SubContainerCounter", 0);
			sol_CategoryButton.ImageSize = SqlClientUtility.GetByte(dataReader, "ImageSize", 0x00);
			sol_CategoryButton.SubContainerCountDown = SqlClientUtility.GetBoolean(dataReader, "SubContainerCountDown", false);
			sol_CategoryButton.MaxCountPerLine = SqlClientUtility.GetInt32(dataReader, "MaxCountPerLine", 0);
            try
            {
                sol_CategoryButton.ForeColorArgb = SqlClientUtility.GetInt32(dataReader, "ForeColorArgb", 0);
                sol_CategoryButton.BackColorArgb = SqlClientUtility.GetInt32(dataReader, "BackColorArgb", 0);
            }
            catch { }

			return sol_CategoryButton;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Saves a record to the sol_CategoryButtons table.
        /// </summary>
        public virtual void Insert2(Sol_CategoryButton sol_CategoryButton)
        {
            ValidationUtility.ValidateArgument("sol_CategoryButton", sol_CategoryButton);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@WorkStationID", sol_CategoryButton.WorkStationID),
                new SqlParameter("@ControlType", sol_CategoryButton.ControlType),
                new SqlParameter("@Description", sol_CategoryButton.Description),
                new SqlParameter("@DefaultQuantity", sol_CategoryButton.DefaultQuantity),
                new SqlParameter("@CategoryID", sol_CategoryButton.CategoryID),
                new SqlParameter("@LocationX", sol_CategoryButton.LocationX),
                new SqlParameter("@LocationY", sol_CategoryButton.LocationY),
                new SqlParameter("@Width", sol_CategoryButton.Width),
                new SqlParameter("@Height", sol_CategoryButton.Height),
                new SqlParameter("@Font", sol_CategoryButton.Font),
                new SqlParameter("@FontStyle", sol_CategoryButton.FontStyle),
                new SqlParameter("@ForeColor", sol_CategoryButton.ForeColor),
                new SqlParameter("@BackColor", sol_CategoryButton.BackColor),
                new SqlParameter("@ImageIndex", sol_CategoryButton.ImageIndex),
                new SqlParameter("@ImagePath", sol_CategoryButton.ImagePath),
                new SqlParameter("@SubContainerMaxCount", sol_CategoryButton.SubContainerMaxCount),
                new SqlParameter("@SubContainerCounter", sol_CategoryButton.SubContainerCounter),
                new SqlParameter("@ImageSize", sol_CategoryButton.ImageSize),
                new SqlParameter("@SubContainerCountDown", sol_CategoryButton.SubContainerCountDown),
                new SqlParameter("@MaxCountPerLine", sol_CategoryButton.MaxCountPerLine),
                new SqlParameter("@ForeColorArgb", sol_CategoryButton.ForeColorArgb),
                new SqlParameter("@BackColorArgb", sol_CategoryButton.BackColorArgb)
            };

            sol_CategoryButton.CategoryButtonID = (int)SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_Insert2", parameters);
        }

        /// <summary>
        /// Updates a record in the sol_CategoryButtons table.
        /// </summary>
        public virtual void Update2(Sol_CategoryButton sol_CategoryButton)
        {
            ValidationUtility.ValidateArgument("sol_CategoryButton", sol_CategoryButton);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryButtonID", sol_CategoryButton.CategoryButtonID),
                new SqlParameter("@WorkStationID", sol_CategoryButton.WorkStationID),
                new SqlParameter("@ControlType", sol_CategoryButton.ControlType),
                new SqlParameter("@Description", sol_CategoryButton.Description),
                new SqlParameter("@DefaultQuantity", sol_CategoryButton.DefaultQuantity),
                new SqlParameter("@CategoryID", sol_CategoryButton.CategoryID),
                new SqlParameter("@LocationX", sol_CategoryButton.LocationX),
                new SqlParameter("@LocationY", sol_CategoryButton.LocationY),
                new SqlParameter("@Width", sol_CategoryButton.Width),
                new SqlParameter("@Height", sol_CategoryButton.Height),
                new SqlParameter("@Font", sol_CategoryButton.Font),
                new SqlParameter("@FontStyle", sol_CategoryButton.FontStyle),
                new SqlParameter("@ForeColor", sol_CategoryButton.ForeColor),
                new SqlParameter("@BackColor", sol_CategoryButton.BackColor),
                new SqlParameter("@ImageIndex", sol_CategoryButton.ImageIndex),
                new SqlParameter("@ImagePath", sol_CategoryButton.ImagePath),
                new SqlParameter("@SubContainerMaxCount", sol_CategoryButton.SubContainerMaxCount),
                new SqlParameter("@SubContainerCounter", sol_CategoryButton.SubContainerCounter),
                new SqlParameter("@ImageSize", sol_CategoryButton.ImageSize),
                new SqlParameter("@SubContainerCountDown", sol_CategoryButton.SubContainerCountDown),
                new SqlParameter("@MaxCountPerLine", sol_CategoryButton.MaxCountPerLine),
                new SqlParameter("@ForeColorArgb", sol_CategoryButton.ForeColorArgb),
                new SqlParameter("@BackColorArgb", sol_CategoryButton.BackColorArgb)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_Update2", parameters);
        }

        /// <summary>
        /// Selects all records from the sol_CategoryButtons table by a foreign key.
        /// </summary>
        public virtual List<Sol_CategoryButton> _SelectAllByButtonType(/*int workStationID,*/ byte buttonType)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
				//new SqlParameter("@WorkStationID", workStationID),
				new SqlParameter("@ButtonType", buttonType)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_SelectAllByButtonType", parameters))
            {
                List<Sol_CategoryButton> sol_CategoryButtonList = new List<Sol_CategoryButton>();
                while (dataReader.Read())
                {
                    Sol_CategoryButton sol_CategoryButton = MakeSol_CategoryButton(dataReader);
                    sol_CategoryButtonList.Add(sol_CategoryButton);
                }

                return sol_CategoryButtonList;
            }
        }

        /// <summary>
        /// Selects all records from the sol_CategoryButtons table by a foreign key.
        /// </summary>
        public virtual List<Sol_CategoryButton> _SelectAllByPaging(/*int workStationID, byte buttonType, */int pageNumber, int pageSize, ref int lastPage)
        {
            SqlParameter outputParameter = new SqlParameter("@LastPage", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters = new SqlParameter[]
            {
				//new SqlParameter("@WorkStationID", workStationID),
				//new SqlParameter("@ButtonType", buttonType), 
				new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize),
                outputParameter
            };

            List<Sol_CategoryButton> sol_CategoryButtonList = new List<Sol_CategoryButton>();
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_CategoryButtons_SelectAllByPaging", parameters))
            {
                while (dataReader.Read())
                {
                    Sol_CategoryButton sol_CategoryButton = MakeSol_CategoryButton(dataReader);
                    sol_CategoryButtonList.Add(sol_CategoryButton);
                }

                //lastPage = (int)parameters("@LastPage").Value;

                //return sol_CategoryButtonList;
            }

            lastPage = (int)outputParameter.Value;

            return sol_CategoryButtonList;

        }

        #endregion
    }
}
