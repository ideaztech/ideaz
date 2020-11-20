using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Vir_ConveyorLink_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Vir_ConveyorLink_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Vir_ConveyorLink table.
		/// </summary>
		public virtual void Insert(Vir_ConveyorLink vir_ConveyorLink)
		{
			ValidationUtility.ValidateArgument("vir_ConveyorLink", vir_ConveyorLink);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BagPositionID", vir_ConveyorLink.BagPositionID),
				new SqlParameter("@ConveyorID", vir_ConveyorLink.ConveyorID)
			};

			vir_ConveyorLink.ConveyorLinkID = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the Vir_ConveyorLink table.
		/// </summary>
		public virtual void Update(Vir_ConveyorLink vir_ConveyorLink)
		{
			ValidationUtility.ValidateArgument("vir_ConveyorLink", vir_ConveyorLink);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorLinkID", vir_ConveyorLink.ConveyorLinkID),
				new SqlParameter("@BagPositionID", vir_ConveyorLink.BagPositionID),
				new SqlParameter("@ConveyorID", vir_ConveyorLink.ConveyorID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the Vir_ConveyorLink table by its primary key.
		/// </summary>
		public virtual void Delete(int conveyorLinkID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorLinkID", conveyorLinkID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_Delete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Vir_ConveyorLink table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByBagPositionID(int bagPositionID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BagPositionID", bagPositionID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_DeleteAllByBagPositionID", parameters);
		}

		/// <summary>
		/// Deletes a record from the Vir_ConveyorLink table by a foreign key.
		/// </summary>
		public virtual void _DeleteAllByConveyorID(int conveyorID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorID", conveyorID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_DeleteAllByConveyorID", parameters);
		}

		/// <summary>
		/// Selects a single record from the Vir_ConveyorLink table.
		/// </summary>
		public virtual Vir_ConveyorLink Select(int conveyorLinkID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorLinkID", conveyorLinkID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeVir_ConveyorLink(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Vir_ConveyorLink table.
		/// </summary>
		public virtual List<Vir_ConveyorLink> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_SelectAll"))
			{
				List<Vir_ConveyorLink> vir_ConveyorLinkList = new List<Vir_ConveyorLink>();
				while (dataReader.Read())
				{
					Vir_ConveyorLink vir_ConveyorLink = MakeVir_ConveyorLink(dataReader);
					vir_ConveyorLinkList.Add(vir_ConveyorLink);
				}

				return vir_ConveyorLinkList;
			}
		}

		/// <summary>
		/// Selects all records from the Vir_ConveyorLink table by a foreign key.
		/// </summary>
		public virtual List<Vir_ConveyorLink> _SelectAllByBagPositionID(int bagPositionID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BagPositionID", bagPositionID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_SelectAllByBagPositionID", parameters))
			{
				List<Vir_ConveyorLink> vir_ConveyorLinkList = new List<Vir_ConveyorLink>();
				while (dataReader.Read())
				{
					Vir_ConveyorLink vir_ConveyorLink = MakeVir_ConveyorLink(dataReader);
					vir_ConveyorLinkList.Add(vir_ConveyorLink);
				}

				return vir_ConveyorLinkList;
			}
		}

		/// <summary>
		/// Selects all records from the Vir_ConveyorLink table by a foreign key.
		/// </summary>
		public virtual List<Vir_ConveyorLink> _SelectAllByConveyorID(int conveyorID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ConveyorID", conveyorID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_SelectAllByConveyorID", parameters))
			{
				List<Vir_ConveyorLink> vir_ConveyorLinkList = new List<Vir_ConveyorLink>();
				while (dataReader.Read())
				{
					Vir_ConveyorLink vir_ConveyorLink = MakeVir_ConveyorLink(dataReader);
					vir_ConveyorLinkList.Add(vir_ConveyorLink);
				}

				return vir_ConveyorLinkList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Vir_ConveyorLink class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Vir_ConveyorLink MakeVir_ConveyorLink(SqlDataReader dataReader)
		{
			Vir_ConveyorLink vir_ConveyorLink = new Vir_ConveyorLink();
			vir_ConveyorLink.ConveyorLinkID = SqlClientUtility.GetInt32(dataReader, "ConveyorLinkID", 0);
			vir_ConveyorLink.BagPositionID = SqlClientUtility.GetInt32(dataReader, "BagPositionID", 0);
			vir_ConveyorLink.ConveyorID = SqlClientUtility.GetInt32(dataReader, "ConveyorID", 0);

			return vir_ConveyorLink;
		}

        #endregion

        #region Additional Methods

        /// <summary>
        /// Selects all records from the Vir_ConveyorLink table by a foreign key.
        /// </summary>
        public virtual Vir_ConveyorLink _SelectByBagPositionIDConveyorID(int bagPositionID, int conveyorID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BagPositionID", bagPositionID)
                , new SqlParameter("@ConveyorID", conveyorID)
            };

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "Vir_ConveyorLink_SelectByBagPositionIDConveyorID", parameters))
            {
                if (dataReader.Read())
                {
                    return MakeVir_ConveyorLink(dataReader);
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
