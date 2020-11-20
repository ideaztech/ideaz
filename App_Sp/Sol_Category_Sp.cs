using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
    public class Sol_Category_Sp
    {
        #region Fields

        protected string connectionStringName;

        #endregion

        #region Constructors

        public Sol_Category_Sp(string connectionStringName)
        {
            //ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

            this.connectionStringName = connectionStringName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the Sol_Categories table.
        /// </summary>
        public virtual void Insert(Sol_Category Sol_Category)
        {
            ValidationUtility.ValidateArgument("Sol_Category", Sol_Category);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Description", Sol_Category.Description),
                new SqlParameter("@RefundAmount", Sol_Category.RefundAmount),
                new SqlParameter("@SubContainerQuantity", Sol_Category.SubContainerQuantity),
                new SqlParameter("@StagingMethodID", Sol_Category.StagingMethodID),
                new SqlParameter("@StagingProductID", Sol_Category.StagingProductID)
            };

            Sol_Category.CategoryID = (int)SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Sol_Categories_Insert", parameters);
        }

        /// <summary>
        /// Updates a record in the Sol_Categories table.
        /// </summary>
        public virtual void Update(Sol_Category Sol_Category)
        {
            ValidationUtility.ValidateArgument("Sol_Category", Sol_Category);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", Sol_Category.CategoryID),
                new SqlParameter("@Description", Sol_Category.Description),
                new SqlParameter("@RefundAmount", Sol_Category.RefundAmount),
                new SqlParameter("@SubContainerQuantity", Sol_Category.SubContainerQuantity),
                new SqlParameter("@StagingMethodID", Sol_Category.StagingMethodID),
                new SqlParameter("@StagingProductID", Sol_Category.StagingProductID)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Categories_Update", parameters);
        }

        /// <summary>
        /// Deletes a record from the Sol_Categories table by its primary key.
        /// </summary>
        public virtual void Delete(int categoryID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", categoryID)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Sol_Categories_Delete", parameters);
        }

        /// <summary>
        /// Selects a single record from the Sol_Categories table.
        /// </summary>
        public virtual Sol_Category Select(int categoryID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", categoryID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Categories_Select", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeSol_Category(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Selects all records from the Sol_Categories table.
        /// </summary>
        public virtual List<Sol_Category> SelectAll()
        {
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Sol_Categories_SelectAll"))
            {
                List<Sol_Category> Sol_CategoryList = new List<Sol_Category>();
                while (dataReader.Read())
                {
                    Sol_Category Sol_Category = MakeSol_Category(dataReader);
                    Sol_CategoryList.Add(Sol_Category);
                }

                return Sol_CategoryList;
            }
        }

        /// <summary>
        /// Creates a new instance of the Sol_Categories class and populates it with data from the specified SqlDataReader.
        /// </summary>
        protected virtual Sol_Category MakeSol_Category(SqlDataReader dataReader)
        {
            Sol_Category Sol_Category = new Sol_Category();
            Sol_Category.CategoryID = SqlClientUtility.GetInt32(dataReader, "CategoryID", 0);
            Sol_Category.Description = SqlClientUtility.GetString(dataReader, "Description", String.Empty);
            Sol_Category.RefundAmount = SqlClientUtility.GetDecimal(dataReader, "RefundAmount", Decimal.Zero);
            Sol_Category.SubContainerQuantity = SqlClientUtility.GetInt32(dataReader, "SubContainerQuantity", 0);
            Sol_Category.StagingMethodID = SqlClientUtility.GetInt32(dataReader, "StagingMethodID", 0);
            Sol_Category.StagingProductID = SqlClientUtility.GetInt32(dataReader, "StagingProductID", 0);

            return Sol_Category;
        }

        #endregion
    }
}
