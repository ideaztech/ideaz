using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Product_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Product_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Products table.
		/// </summary>
		public virtual void Insert(Sol_Product sol_Product)
		{
			ValidationUtility.ValidateArgument("sol_Product", sol_Product);

			SqlParameter[] parameters = new SqlParameter[]
			{
                //new SqlParameter("@ProductID", sol_Product.ProductID),
				new SqlParameter("@ProName", sol_Product.ProName),
				new SqlParameter("@ProDescription", sol_Product.ProDescription),
				new SqlParameter("@ProShortDescription", sol_Product.ProShortDescription),
				new SqlParameter("@ProImage", new byte[0]),
				new SqlParameter("@AgencyID", sol_Product.AgencyID),
				new SqlParameter("@MenuOrder", sol_Product.MenuOrder),
				new SqlParameter("@IsActive", sol_Product.IsActive),
				new SqlParameter("@Price", sol_Product.Price),
				new SqlParameter("@CategoryID", sol_Product.CategoryID),
				new SqlParameter("@RefundAmount", sol_Product.RefundAmount),
				new SqlParameter("@HandlingCommissionAmount", sol_Product.HandlingCommissionAmount),
				new SqlParameter("@CommissionUnit", sol_Product.CommissionUnit),
				new SqlParameter("@VafAmount", sol_Product.VafAmount),
				new SqlParameter("@FeeUnit", sol_Product.FeeUnit),
				new SqlParameter("@ContainerID", sol_Product.ContainerID),
				new SqlParameter("@StandardDozenID", sol_Product.StandardDozenID),
				new SqlParameter("@UPC", sol_Product.UPC),
				new SqlParameter("@ProductCode", sol_Product.ProductCode),
				new SqlParameter("@TypeId", sol_Product.TypeId),
				new SqlParameter("@Tax1Exempt", sol_Product.Tax1Exempt),
				new SqlParameter("@Tax2Exempt", sol_Product.Tax2Exempt),
				new SqlParameter("@MasterProductID", sol_Product.MasterProductID),
				new SqlParameter("@Weight", sol_Product.Weight),
				new SqlParameter("@Volume", sol_Product.Volume),
				new SqlParameter("@TargetQuantity", sol_Product.TargetQuantity)
			};

			sol_Product.ProductID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "sol_Products_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Products table.
		/// </summary>
		public virtual void Update(Sol_Product sol_Product)
		{
			ValidationUtility.ValidateArgument("sol_Product", sol_Product);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ProductID", sol_Product.ProductID),
				new SqlParameter("@ProName", sol_Product.ProName),
				new SqlParameter("@ProDescription", sol_Product.ProDescription),
				new SqlParameter("@ProShortDescription", sol_Product.ProShortDescription),
				new SqlParameter("@ProImage", sol_Product.ProImage),
				new SqlParameter("@AgencyID", sol_Product.AgencyID),
				new SqlParameter("@MenuOrder", sol_Product.MenuOrder),
				new SqlParameter("@IsActive", sol_Product.IsActive),
				new SqlParameter("@Price", sol_Product.Price),
				new SqlParameter("@CategoryID", sol_Product.CategoryID),
				new SqlParameter("@RefundAmount", sol_Product.RefundAmount),
				new SqlParameter("@HandlingCommissionAmount", sol_Product.HandlingCommissionAmount),
				new SqlParameter("@CommissionUnit", sol_Product.CommissionUnit),
				new SqlParameter("@VafAmount", sol_Product.VafAmount),
				new SqlParameter("@FeeUnit", sol_Product.FeeUnit),
				new SqlParameter("@ContainerID", sol_Product.ContainerID),
				new SqlParameter("@StandardDozenID", sol_Product.StandardDozenID),
				new SqlParameter("@UPC", sol_Product.UPC),
				new SqlParameter("@ProductCode", sol_Product.ProductCode),
				new SqlParameter("@TypeId", sol_Product.TypeId),
				new SqlParameter("@Tax1Exempt", sol_Product.Tax1Exempt),
				new SqlParameter("@Tax2Exempt", sol_Product.Tax2Exempt),
				new SqlParameter("@MasterProductID", sol_Product.MasterProductID),
				new SqlParameter("@Weight", sol_Product.Weight),
				new SqlParameter("@Volume", sol_Product.Volume),
				new SqlParameter("@TargetQuantity", sol_Product.TargetQuantity)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Products_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Products table by its primary key.
		/// </summary>
		public virtual void Delete(int productID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ProductID", productID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Products_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Products table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByAgencyID(int agencyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", agencyID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Products_DeleteAllByAgencyID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Products table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByCategoryID(int categoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryID", categoryID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Products_DeleteAllByCategoryID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Products table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByContainerID(int containerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerID", containerID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Products_DeleteAllByContainerID", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Products table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByStandardDozenID(int standardDozenID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StandardDozenID", standardDozenID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Products_DeleteAllByStandardDozenID", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Products table.
		/// </summary>
		public virtual Sol_Product Select(int productID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ProductID", productID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Products_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Product(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Products table.
		/// </summary>
		public virtual List<Sol_Product> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Products_SelectAll"))
			{
				List<Sol_Product> sol_ProductList = new List<Sol_Product>();
				while (dataReader.Read())
				{
					Sol_Product sol_Product = MakeSol_Product(dataReader);
					sol_ProductList.Add(sol_Product);
				}

				return sol_ProductList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Products table by a foreign key.
		/// </summary>
		public virtual List<Sol_Product> _SelectAllByAgencyID(int agencyID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AgencyID", agencyID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Products_SelectAllByAgencyID", parameters))
			{
				List<Sol_Product> sol_ProductList = new List<Sol_Product>();
				while (dataReader.Read())
				{
					Sol_Product sol_Product = MakeSol_Product(dataReader);
					sol_ProductList.Add(sol_Product);
				}

				return sol_ProductList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Products table by a foreign key.
		/// </summary>
		public virtual List<Sol_Product> _SelectAllByCategoryID(int categoryID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CategoryID", categoryID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Products_SelectAllByCategoryID", parameters))
			{
				List<Sol_Product> sol_ProductList = new List<Sol_Product>();
				while (dataReader.Read())
				{
					Sol_Product sol_Product = MakeSol_Product(dataReader);
					sol_ProductList.Add(sol_Product);
				}

				return sol_ProductList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Products table by a foreign key.
		/// </summary>
		public virtual List<Sol_Product> _SelectAllByContainerID(int containerID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ContainerID", containerID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Products_SelectAllByContainerID", parameters))
			{
				List<Sol_Product> sol_ProductList = new List<Sol_Product>();
				while (dataReader.Read())
				{
					Sol_Product sol_Product = MakeSol_Product(dataReader);
					sol_ProductList.Add(sol_Product);
				}

				return sol_ProductList;
			}
		}

		/// <summary>
		/// Selects all records from the sol_Products table by a foreign key.
		/// </summary>
		public virtual List<Sol_Product> _SelectAllByStandardDozenID(int standardDozenID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StandardDozenID", standardDozenID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Products_SelectAllByStandardDozenID", parameters))
			{
				List<Sol_Product> sol_ProductList = new List<Sol_Product>();
				while (dataReader.Read())
				{
					Sol_Product sol_Product = MakeSol_Product(dataReader);
					sol_ProductList.Add(sol_Product);
				}

				return sol_ProductList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Products class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Product MakeSol_Product(SqlDataReader dataReader)
		{
			Sol_Product sol_Product = new Sol_Product();
			sol_Product.ProductID = SqlClientUtility.GetInt32(dataReader, "ProductID", 0);
			sol_Product.ProName = SqlClientUtility.GetString(dataReader, "ProName", String.Empty);
			sol_Product.ProDescription = SqlClientUtility.GetString(dataReader, "ProDescription", String.Empty);
			sol_Product.ProShortDescription = SqlClientUtility.GetString(dataReader, "ProShortDescription", String.Empty);
			sol_Product.ProImage = SqlClientUtility.GetBytes(dataReader, "ProImage", new byte[0]);
			sol_Product.AgencyID = SqlClientUtility.GetInt32(dataReader, "AgencyID", 0);
			sol_Product.MenuOrder = SqlClientUtility.GetInt32(dataReader, "MenuOrder", 0);
			sol_Product.IsActive = SqlClientUtility.GetBoolean(dataReader, "IsActive", false);
			sol_Product.Price = SqlClientUtility.GetDecimal(dataReader, "Price", Decimal.Zero);
			sol_Product.CategoryID = SqlClientUtility.GetInt32(dataReader, "CategoryID", 0);
			sol_Product.RefundAmount = SqlClientUtility.GetDecimal(dataReader, "RefundAmount", Decimal.Zero);
			sol_Product.HandlingCommissionAmount = SqlClientUtility.GetDecimal(dataReader, "HandlingCommissionAmount", Decimal.Zero);
			sol_Product.CommissionUnit = SqlClientUtility.GetInt32(dataReader, "CommissionUnit", 0);
			sol_Product.VafAmount = SqlClientUtility.GetDecimal(dataReader, "VafAmount", Decimal.Zero);
			sol_Product.FeeUnit = SqlClientUtility.GetInt32(dataReader, "FeeUnit", 0);
			sol_Product.ContainerID = SqlClientUtility.GetInt32(dataReader, "ContainerID", 0);
			sol_Product.StandardDozenID = SqlClientUtility.GetInt32(dataReader, "StandardDozenID", 0);
			sol_Product.UPC = SqlClientUtility.GetString(dataReader, "UPC", String.Empty);
			sol_Product.ProductCode = SqlClientUtility.GetString(dataReader, "ProductCode", String.Empty);
			sol_Product.TypeId = SqlClientUtility.GetByte(dataReader, "TypeId", 0x00);
			sol_Product.Tax1Exempt = SqlClientUtility.GetBoolean(dataReader, "Tax1Exempt", false);
			sol_Product.Tax2Exempt = SqlClientUtility.GetBoolean(dataReader, "Tax2Exempt", false);
			sol_Product.MasterProductID = SqlClientUtility.GetInt32(dataReader, "MasterProductID", 0);
			sol_Product.Weight = SqlClientUtility.GetDecimal(dataReader, "Weight", Decimal.Zero);
			sol_Product.Volume = SqlClientUtility.GetDecimal(dataReader, "Volume", Decimal.Zero);
			sol_Product.TargetQuantity = SqlClientUtility.GetInt32(dataReader, "TargetQuantity", 0);

			return sol_Product;
		}

        #endregion

        #region Additional Procedures

        /// <summary>
        /// Selects a single record from the sol_Products table by ProductCode
        /// </summary>
        public virtual Sol_Product SelectProductCode(string productCode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductCode", productCode)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Products_SelectProductCode", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Product(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }


        #endregion

    }
}
