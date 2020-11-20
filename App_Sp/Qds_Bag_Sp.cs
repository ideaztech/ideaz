using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
    public class Qds_Bag_Sp
    {
        #region Fields

        protected string connectionStringName;

        #endregion

        #region Constructors

        public Qds_Bag_Sp(string connectionStringName)
        {
            //ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

            this.connectionStringName = connectionStringName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves a record to the Qds_Bag table.
        /// </summary>
        public virtual void Insert(Qds_Bag qds_Bag)
        {
            ValidationUtility.ValidateArgument("qds_Bag", qds_Bag);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DropID", qds_Bag.DropID),
                new SqlParameter("@BagEstimateUnderLitre", qds_Bag.BagEstimateUnderLitre),
                new SqlParameter("@BagEstimateOverLitre", qds_Bag.BagEstimateOverLitre),
                new SqlParameter("@DateEntered", qds_Bag.DateEntered),
                new SqlParameter("@DateAccepted", qds_Bag.DateAccepted),
                new SqlParameter("@DateCounted", qds_Bag.DateCounted),
                new SqlParameter("@DatePaid", qds_Bag.DatePaid),
                new SqlParameter("@DepotID", qds_Bag.DepotID),
                new SqlParameter("@DatePrinted", qds_Bag.DatePrinted)
                //, 	new SqlParameter("@IsNew", qds_Bag.IsNew)
			};

            qds_Bag.BagID = (int)SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Qds_Bag_Insert", parameters);
        }

        /// <summary>
        /// Updates a record in the Qds_Bag table.
        /// </summary>
        public virtual void Update(Qds_Bag qds_Bag)
        {
            ValidationUtility.ValidateArgument("qds_Bag", qds_Bag);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BagID", qds_Bag.BagID),
                new SqlParameter("@DropID", qds_Bag.DropID),
                new SqlParameter("@BagEstimateUnderLitre", qds_Bag.BagEstimateUnderLitre),
                new SqlParameter("@BagEstimateOverLitre", qds_Bag.BagEstimateOverLitre),
                new SqlParameter("@DateEntered", qds_Bag.DateEntered),
                new SqlParameter("@DateAccepted", qds_Bag.DateAccepted),
                new SqlParameter("@DateCounted", qds_Bag.DateCounted),
                new SqlParameter("@DatePaid", qds_Bag.DatePaid),
                new SqlParameter("@DepotID", qds_Bag.DepotID),
                new SqlParameter("@DatePrinted", qds_Bag.DatePrinted)
                //,
                //new SqlParameter("@IsNew", qds_Bag.IsNew)
			};

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Bag_Update", parameters);
        }

        /// <summary>
        /// Deletes a record from the Qds_Bag table by its primary key.
        /// </summary>
        public virtual void Delete(int bagID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BagID", bagID)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Bag_Delete", parameters);
        }

        /// <summary>
        /// Deletes a record from the Qds_Bag table by a foreign key.
        /// </summary>
        public virtual void _DeleteAllByDropID(int dropID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DropID", dropID)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Qds_Bag_DeleteAllByDropID", parameters);
        }

        /// <summary>
        /// Selects a single record from the Qds_Bag table.
        /// </summary>
        public virtual Qds_Bag Select(int bagID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BagID", bagID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Bag_Select", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeQds_Bag(dataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Selects all records from the Qds_Bag table.
        /// </summary>
        public virtual List<Qds_Bag> SelectAll()
        {
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Bag_SelectAll"))
            {
                List<Qds_Bag> qds_BagList = new List<Qds_Bag>();
                while (dataReader.Read())
                {
                    Qds_Bag qds_Bag = MakeQds_Bag(dataReader);
                    qds_BagList.Add(qds_Bag);
                }

                return qds_BagList;
            }
        }

        /// <summary>
        /// Selects all records from the Qds_Bag table by a foreign key.
        /// </summary>
        public virtual List<Qds_Bag> _SelectAllByDropID(int dropID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DropID", dropID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Qds_Bag_SelectAllByDropID", parameters))
            {
                List<Qds_Bag> qds_BagList = new List<Qds_Bag>();
                while (dataReader.Read())
                {
                    Qds_Bag qds_Bag = MakeQds_Bag(dataReader);
                    qds_BagList.Add(qds_Bag);
                }

                return qds_BagList;
            }
        }

        /// <summary>
        /// Creates a new instance of the Qds_Bag class and populates it with data from the specified SqlDataReader.
        /// </summary>
        protected virtual Qds_Bag MakeQds_Bag(SqlDataReader dataReader)
        {
            Qds_Bag qds_Bag = new Qds_Bag();
            qds_Bag.BagID = SqlClientUtility.GetInt32(dataReader, "BagID", 0);
            qds_Bag.DropID = SqlClientUtility.GetInt32(dataReader, "DropID", 0);
            qds_Bag.BagEstimateUnderLitre = SqlClientUtility.GetInt32(dataReader, "BagEstimateUnderLitre", 0);
            qds_Bag.BagEstimateOverLitre = SqlClientUtility.GetInt32(dataReader, "BagEstimateOverLitre", 0);
            qds_Bag.DateEntered = SqlClientUtility.GetDateTime(dataReader, "DateEntered", DateTime.Now);
            qds_Bag.DateAccepted = SqlClientUtility.GetDateTime(dataReader, "DateAccepted", DateTime.Now);
            qds_Bag.DateCounted = SqlClientUtility.GetDateTime(dataReader, "DateCounted", DateTime.Now);
            qds_Bag.DatePaid = SqlClientUtility.GetDateTime(dataReader, "DatePaid", DateTime.Now);
            qds_Bag.DepotID = SqlClientUtility.GetString(dataReader, "DepotID", String.Empty);
            qds_Bag.DatePrinted = SqlClientUtility.GetDateTime(dataReader, "DatePrinted", DateTime.Now);
            //qds_Bag.IsNew = SqlClientUtility.GetBoolean(dataReader, "IsNew", false);

            return qds_Bag;
        }

        #endregion
    }
}
