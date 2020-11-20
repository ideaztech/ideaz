using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SirLibCore.Data;
using SirLibCore.Utilities;

namespace Solum
{
	public class Sol_Control_Sp
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public Sol_Control_Sp(string connectionStringName)
		{
			//ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the sol_Control table.
		/// </summary>
		public virtual void Insert(Sol_Control sol_Control)
		{
			ValidationUtility.ValidateArgument("sol_Control", sol_Control);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ControlID", sol_Control.ControlID),
				new SqlParameter("@BusinessName", sol_Control.BusinessName),
				new SqlParameter("@LegalName", sol_Control.LegalName),
				new SqlParameter("@StoreNumber", sol_Control.StoreNumber),
				new SqlParameter("@Address", sol_Control.Address),
				new SqlParameter("@City", sol_Control.City),
				new SqlParameter("@State", sol_Control.State),
				new SqlParameter("@Country", sol_Control.Country),
				new SqlParameter("@PhoneNumber", sol_Control.PhoneNumber),
				new SqlParameter("@BusinessHoursFrom", sol_Control.BusinessHoursFrom),
				new SqlParameter("@BusinessHoursTo", sol_Control.BusinessHoursTo),
				new SqlParameter("@IdFiscal1Name", sol_Control.IdFiscal1Name),
				new SqlParameter("@IdFiscal1Value", sol_Control.IdFiscal1Value),
				new SqlParameter("@IdFiscal2Name", sol_Control.IdFiscal2Name),
				new SqlParameter("@IdFiscal2Value", sol_Control.IdFiscal2Value),
				new SqlParameter("@WorkStationID", sol_Control.WorkStationID),
				new SqlParameter("@CustomerScreenMessageID", sol_Control.CustomerScreenMessageID),
				new SqlParameter("@FrontStationMessageID", sol_Control.FrontStationMessageID),
				new SqlParameter("@CashierRoutineMessageID", sol_Control.CashierRoutineMessageID),
				new SqlParameter("@ReturnStationMessageID", sol_Control.ReturnStationMessageID),
				new SqlParameter("@CashierStationMessageID", sol_Control.CashierStationMessageID),
				new SqlParameter("@ShippingStationMessageID", sol_Control.ShippingStationMessageID),
				new SqlParameter("@ReceiptMessageID", sol_Control.ReceiptMessageID),
				new SqlParameter("@SMTPServer", sol_Control.SMTPServer),
				new SqlParameter("@SMTPPort", sol_Control.SMTPPort),
				new SqlParameter("@EmailAccount", sol_Control.EmailAccount),
				new SqlParameter("@EmailPassword", sol_Control.EmailPassword),
				new SqlParameter("@HistoryYears", sol_Control.HistoryYears),
				new SqlParameter("@FiscalYearInitialMonth", sol_Control.FiscalYearInitialMonth),
				new SqlParameter("@NumericKeyPadOn", sol_Control.NumericKeyPadOn),
				new SqlParameter("@NumericKeyPadPosition", sol_Control.NumericKeyPadPosition),
				new SqlParameter("@ReturnButtonExtra", sol_Control.ReturnButtonExtra),
				new SqlParameter("@Tax1Name", sol_Control.Tax1Name),
				new SqlParameter("@Tax1Rate", sol_Control.Tax1Rate),
				new SqlParameter("@Tax2Name", sol_Control.Tax2Name),
				new SqlParameter("@Tax2Rate", sol_Control.Tax2Rate),
				new SqlParameter("@DatabaseVersion", sol_Control.DatabaseVersion),
				new SqlParameter("@Status", sol_Control.Status),
				new SqlParameter("@EmployeesListRefresh", sol_Control.EmployeesListRefresh),
				new SqlParameter("@WebBrowserUrl", sol_Control.WebBrowserUrl),
				new SqlParameter("@AutoGenerateTagNumber", sol_Control.AutoGenerateTagNumber),
				new SqlParameter("@AutoGenerateRBillNumber", sol_Control.AutoGenerateRBillNumber),
				new SqlParameter("@DefaultAgencyID", sol_Control.DefaultAgencyID),
				new SqlParameter("@ChitTicketComplete", sol_Control.ChitTicketComplete),
				new SqlParameter("@ChitTicketIncludeBarcode", sol_Control.ChitTicketIncludeBarcode),
				new SqlParameter("@CashOutPrintingOverride", sol_Control.CashOutPrintingOverride),
				new SqlParameter("@WhiteBagID", sol_Control.WhiteBagID),
				new SqlParameter("@BlueBagID", sol_Control.BlueBagID),
				new SqlParameter("@OneWayBagID", sol_Control.OneWayBagID),
				new SqlParameter("@ABCRCPalletsID", sol_Control.ABCRCPalletsID),
				new SqlParameter("@CustomerScreenMonitor", sol_Control.CustomerScreenMonitor),
				new SqlParameter("@CategoryButtonsPanelBgColor", sol_Control.CategoryButtonsPanelBgColor),
				new SqlParameter("@CategoryButtonsSnapToGrid", sol_Control.CategoryButtonsSnapToGrid),
				new SqlParameter("@BusinessHoursFromTue", sol_Control.BusinessHoursFromTue),
				new SqlParameter("@BusinessHoursToTue", sol_Control.BusinessHoursToTue),
				new SqlParameter("@BusinessHoursFromWed", sol_Control.BusinessHoursFromWed),
				new SqlParameter("@BusinessHoursToWed", sol_Control.BusinessHoursToWed),
				new SqlParameter("@BusinessHoursFromThu", sol_Control.BusinessHoursFromThu),
				new SqlParameter("@BusinessHoursToThu", sol_Control.BusinessHoursToThu),
				new SqlParameter("@BusinessHoursFromFri", sol_Control.BusinessHoursFromFri),
				new SqlParameter("@BusinessHoursToFri", sol_Control.BusinessHoursToFri),
				new SqlParameter("@BusinessHoursFromSat", sol_Control.BusinessHoursFromSat),
				new SqlParameter("@BusinessHoursToSat", sol_Control.BusinessHoursToSat),
				new SqlParameter("@BusinessHoursFromSun", sol_Control.BusinessHoursFromSun),
				new SqlParameter("@BusinessHoursToSun", sol_Control.BusinessHoursToSun),
				new SqlParameter("@ReturnsMaxQuantity", sol_Control.ReturnsMaxQuantity),
				new SqlParameter("@WebBrowserUpdateHistoryUrl", sol_Control.WebBrowserUpdateHistoryUrl),
				new SqlParameter("@CashierMaxAmount", sol_Control.CashierMaxAmount),
				new SqlParameter("@ComputerRole", sol_Control.ComputerRole),
				new SqlParameter("@SqlServerDate", sol_Control.SqlServerDate),
				new SqlParameter("@VendorID", sol_Control.VendorID),
				new SqlParameter("@DefaultPlantID", sol_Control.DefaultPlantID),
				new SqlParameter("@DefaultCarrierID", sol_Control.DefaultCarrierID),
				new SqlParameter("@ABCRCUserName", sol_Control.ABCRCUserName),
				new SqlParameter("@ABCRCPassword", sol_Control.ABCRCPassword),
				new SqlParameter("@ReceiptAmountBarcode", sol_Control.ReceiptAmountBarcode),
				new SqlParameter("@IncludeSecurityCode", sol_Control.IncludeSecurityCode),
				new SqlParameter("@RBillNumberBarcode", sol_Control.RBillNumberBarcode),
				new SqlParameter("@SacCashTrayID", sol_Control.SacCashTrayID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Control_Insert", parameters);
		}

		/// <summary>
		/// Updates a record in the sol_Control table.
		/// </summary>
		public virtual void Update(Sol_Control sol_Control)
		{
			ValidationUtility.ValidateArgument("sol_Control", sol_Control);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ControlID", sol_Control.ControlID),
				new SqlParameter("@BusinessName", sol_Control.BusinessName),
				new SqlParameter("@LegalName", sol_Control.LegalName),
				new SqlParameter("@StoreNumber", sol_Control.StoreNumber),
				new SqlParameter("@Address", sol_Control.Address),
				new SqlParameter("@City", sol_Control.City),
				new SqlParameter("@State", sol_Control.State),
				new SqlParameter("@Country", sol_Control.Country),
				new SqlParameter("@PhoneNumber", sol_Control.PhoneNumber),
				new SqlParameter("@BusinessHoursFrom", sol_Control.BusinessHoursFrom),
				new SqlParameter("@BusinessHoursTo", sol_Control.BusinessHoursTo),
				new SqlParameter("@IdFiscal1Name", sol_Control.IdFiscal1Name),
				new SqlParameter("@IdFiscal1Value", sol_Control.IdFiscal1Value),
				new SqlParameter("@IdFiscal2Name", sol_Control.IdFiscal2Name),
				new SqlParameter("@IdFiscal2Value", sol_Control.IdFiscal2Value),
				new SqlParameter("@WorkStationID", sol_Control.WorkStationID),
				new SqlParameter("@CustomerScreenMessageID", sol_Control.CustomerScreenMessageID),
				new SqlParameter("@FrontStationMessageID", sol_Control.FrontStationMessageID),
				new SqlParameter("@CashierRoutineMessageID", sol_Control.CashierRoutineMessageID),
				new SqlParameter("@ReturnStationMessageID", sol_Control.ReturnStationMessageID),
				new SqlParameter("@CashierStationMessageID", sol_Control.CashierStationMessageID),
				new SqlParameter("@ShippingStationMessageID", sol_Control.ShippingStationMessageID),
				new SqlParameter("@ReceiptMessageID", sol_Control.ReceiptMessageID),
				new SqlParameter("@SMTPServer", sol_Control.SMTPServer),
				new SqlParameter("@SMTPPort", sol_Control.SMTPPort),
				new SqlParameter("@EmailAccount", sol_Control.EmailAccount),
				new SqlParameter("@EmailPassword", sol_Control.EmailPassword),
				new SqlParameter("@HistoryYears", sol_Control.HistoryYears),
				new SqlParameter("@FiscalYearInitialMonth", sol_Control.FiscalYearInitialMonth),
				new SqlParameter("@NumericKeyPadOn", sol_Control.NumericKeyPadOn),
				new SqlParameter("@NumericKeyPadPosition", sol_Control.NumericKeyPadPosition),
				new SqlParameter("@ReturnButtonExtra", sol_Control.ReturnButtonExtra),
				new SqlParameter("@Tax1Name", sol_Control.Tax1Name),
				new SqlParameter("@Tax1Rate", sol_Control.Tax1Rate),
				new SqlParameter("@Tax2Name", sol_Control.Tax2Name),
				new SqlParameter("@Tax2Rate", sol_Control.Tax2Rate),
				new SqlParameter("@DatabaseVersion", sol_Control.DatabaseVersion),
				new SqlParameter("@Status", sol_Control.Status),
				new SqlParameter("@EmployeesListRefresh", sol_Control.EmployeesListRefresh),
				new SqlParameter("@WebBrowserUrl", sol_Control.WebBrowserUrl),
				new SqlParameter("@AutoGenerateTagNumber", sol_Control.AutoGenerateTagNumber),
				new SqlParameter("@AutoGenerateRBillNumber", sol_Control.AutoGenerateRBillNumber),
				new SqlParameter("@DefaultAgencyID", sol_Control.DefaultAgencyID),
				new SqlParameter("@ChitTicketComplete", sol_Control.ChitTicketComplete),
				new SqlParameter("@ChitTicketIncludeBarcode", sol_Control.ChitTicketIncludeBarcode),
				new SqlParameter("@CashOutPrintingOverride", sol_Control.CashOutPrintingOverride),
				new SqlParameter("@WhiteBagID", sol_Control.WhiteBagID),
				new SqlParameter("@BlueBagID", sol_Control.BlueBagID),
				new SqlParameter("@OneWayBagID", sol_Control.OneWayBagID),
				new SqlParameter("@ABCRCPalletsID", sol_Control.ABCRCPalletsID),
				new SqlParameter("@CustomerScreenMonitor", sol_Control.CustomerScreenMonitor),
				new SqlParameter("@CategoryButtonsPanelBgColor", sol_Control.CategoryButtonsPanelBgColor),
				new SqlParameter("@CategoryButtonsSnapToGrid", sol_Control.CategoryButtonsSnapToGrid),
				new SqlParameter("@BusinessHoursFromTue", sol_Control.BusinessHoursFromTue),
				new SqlParameter("@BusinessHoursToTue", sol_Control.BusinessHoursToTue),
				new SqlParameter("@BusinessHoursFromWed", sol_Control.BusinessHoursFromWed),
				new SqlParameter("@BusinessHoursToWed", sol_Control.BusinessHoursToWed),
				new SqlParameter("@BusinessHoursFromThu", sol_Control.BusinessHoursFromThu),
				new SqlParameter("@BusinessHoursToThu", sol_Control.BusinessHoursToThu),
				new SqlParameter("@BusinessHoursFromFri", sol_Control.BusinessHoursFromFri),
				new SqlParameter("@BusinessHoursToFri", sol_Control.BusinessHoursToFri),
				new SqlParameter("@BusinessHoursFromSat", sol_Control.BusinessHoursFromSat),
				new SqlParameter("@BusinessHoursToSat", sol_Control.BusinessHoursToSat),
				new SqlParameter("@BusinessHoursFromSun", sol_Control.BusinessHoursFromSun),
				new SqlParameter("@BusinessHoursToSun", sol_Control.BusinessHoursToSun),
				new SqlParameter("@ReturnsMaxQuantity", sol_Control.ReturnsMaxQuantity),
				new SqlParameter("@WebBrowserUpdateHistoryUrl", sol_Control.WebBrowserUpdateHistoryUrl),
				new SqlParameter("@CashierMaxAmount", sol_Control.CashierMaxAmount),
				new SqlParameter("@ComputerRole", sol_Control.ComputerRole),
				new SqlParameter("@SqlServerDate", sol_Control.SqlServerDate),
				new SqlParameter("@VendorID", sol_Control.VendorID),
				new SqlParameter("@DefaultPlantID", sol_Control.DefaultPlantID),
				new SqlParameter("@DefaultCarrierID", sol_Control.DefaultCarrierID),
				new SqlParameter("@ABCRCUserName", sol_Control.ABCRCUserName),
				new SqlParameter("@ABCRCPassword", sol_Control.ABCRCPassword),
				new SqlParameter("@ReceiptAmountBarcode", sol_Control.ReceiptAmountBarcode),
				new SqlParameter("@IncludeSecurityCode", sol_Control.IncludeSecurityCode),
				new SqlParameter("@RBillNumberBarcode", sol_Control.RBillNumberBarcode),
				new SqlParameter("@SacCashTrayID", sol_Control.SacCashTrayID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Control_Update", parameters);
		}

		/// <summary>
		/// Deletes a record from the sol_Control table by its primary key.
		/// </summary>
		public virtual void Delete(int controlID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ControlID", controlID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "sol_Control_Delete", parameters);
		}

		/// <summary>
		/// Selects a single record from the sol_Control table.
		/// </summary>
		public virtual Sol_Control Select(int controlID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ControlID", controlID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Control_Select", parameters))
			{
				if (dataReader.Read())
				{
					return MakeSol_Control(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the sol_Control table.
		/// </summary>
		public virtual List<Sol_Control> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "sol_Control_SelectAll"))
			{
				List<Sol_Control> sol_ControlList = new List<Sol_Control>();
				while (dataReader.Read())
				{
					Sol_Control sol_Control = MakeSol_Control(dataReader);
					sol_ControlList.Add(sol_Control);
				}

				return sol_ControlList;
			}
		}

		/// <summary>
		/// Creates a new instance of the sol_Control class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Sol_Control MakeSol_Control(SqlDataReader dataReader)
		{
			Sol_Control sol_Control = new Sol_Control();
			sol_Control.ControlID = SqlClientUtility.GetInt32(dataReader, "ControlID", 0);
			sol_Control.BusinessName = SqlClientUtility.GetString(dataReader, "BusinessName", String.Empty);
			sol_Control.LegalName = SqlClientUtility.GetString(dataReader, "LegalName", String.Empty);
			sol_Control.StoreNumber = SqlClientUtility.GetInt32(dataReader, "StoreNumber", 0);
			sol_Control.Address = SqlClientUtility.GetString(dataReader, "Address", String.Empty);
			sol_Control.City = SqlClientUtility.GetString(dataReader, "City", String.Empty);
			sol_Control.State = SqlClientUtility.GetString(dataReader, "State", String.Empty);
			sol_Control.Country = SqlClientUtility.GetString(dataReader, "Country", String.Empty);
			sol_Control.PhoneNumber = SqlClientUtility.GetString(dataReader, "PhoneNumber", String.Empty);
			sol_Control.BusinessHoursFrom = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursFrom", new DateTime(0));
			sol_Control.BusinessHoursTo = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursTo", new DateTime(0));
			sol_Control.IdFiscal1Name = SqlClientUtility.GetString(dataReader, "IdFiscal1Name", String.Empty);
			sol_Control.IdFiscal1Value = SqlClientUtility.GetString(dataReader, "IdFiscal1Value", String.Empty);
			sol_Control.IdFiscal2Name = SqlClientUtility.GetString(dataReader, "IdFiscal2Name", String.Empty);
			sol_Control.IdFiscal2Value = SqlClientUtility.GetString(dataReader, "IdFiscal2Value", String.Empty);
			sol_Control.WorkStationID = SqlClientUtility.GetInt32(dataReader, "WorkStationID", 0);
			sol_Control.CustomerScreenMessageID = SqlClientUtility.GetInt32(dataReader, "CustomerScreenMessageID", 0);
			sol_Control.FrontStationMessageID = SqlClientUtility.GetInt32(dataReader, "FrontStationMessageID", 0);
			sol_Control.CashierRoutineMessageID = SqlClientUtility.GetInt32(dataReader, "CashierRoutineMessageID", 0);
			sol_Control.ReturnStationMessageID = SqlClientUtility.GetInt32(dataReader, "ReturnStationMessageID", 0);
			sol_Control.CashierStationMessageID = SqlClientUtility.GetInt32(dataReader, "CashierStationMessageID", 0);
			sol_Control.ShippingStationMessageID = SqlClientUtility.GetInt32(dataReader, "ShippingStationMessageID", 0);
			sol_Control.ReceiptMessageID = SqlClientUtility.GetInt32(dataReader, "ReceiptMessageID", 0);
			sol_Control.SMTPServer = SqlClientUtility.GetString(dataReader, "SMTPServer", String.Empty);
			sol_Control.SMTPPort = SqlClientUtility.GetInt32(dataReader, "SMTPPort", 0);
			sol_Control.EmailAccount = SqlClientUtility.GetString(dataReader, "EmailAccount", String.Empty);
			sol_Control.EmailPassword = SqlClientUtility.GetString(dataReader, "EmailPassword", String.Empty);
			sol_Control.HistoryYears = SqlClientUtility.GetByte(dataReader, "HistoryYears", 0x00);
			sol_Control.FiscalYearInitialMonth = SqlClientUtility.GetByte(dataReader, "FiscalYearInitialMonth", 0x00);
			sol_Control.NumericKeyPadOn = SqlClientUtility.GetBoolean(dataReader, "NumericKeyPadOn", false);
			sol_Control.NumericKeyPadPosition = SqlClientUtility.GetByte(dataReader, "NumericKeyPadPosition", 0x00);
			sol_Control.ReturnButtonExtra = SqlClientUtility.GetByte(dataReader, "ReturnButtonExtra", 0x00);
			sol_Control.Tax1Name = SqlClientUtility.GetString(dataReader, "Tax1Name", String.Empty);
			sol_Control.Tax1Rate = SqlClientUtility.GetDecimal(dataReader, "Tax1Rate", Decimal.Zero);
			sol_Control.Tax2Name = SqlClientUtility.GetString(dataReader, "Tax2Name", String.Empty);
			sol_Control.Tax2Rate = SqlClientUtility.GetDecimal(dataReader, "Tax2Rate", Decimal.Zero);
			sol_Control.DatabaseVersion = SqlClientUtility.GetDecimal(dataReader, "DatabaseVersion", Decimal.Zero);
			sol_Control.Status = SqlClientUtility.GetString(dataReader, "Status", String.Empty);
			sol_Control.EmployeesListRefresh = SqlClientUtility.GetInt32(dataReader, "EmployeesListRefresh", 0);
			sol_Control.WebBrowserUrl = SqlClientUtility.GetString(dataReader, "WebBrowserUrl", String.Empty);
			sol_Control.AutoGenerateTagNumber = SqlClientUtility.GetBoolean(dataReader, "AutoGenerateTagNumber", false);
			sol_Control.AutoGenerateRBillNumber = SqlClientUtility.GetBoolean(dataReader, "AutoGenerateRBillNumber", false);
			sol_Control.DefaultAgencyID = SqlClientUtility.GetInt32(dataReader, "DefaultAgencyID", 0);
			sol_Control.ChitTicketComplete = SqlClientUtility.GetByte(dataReader, "ChitTicketComplete", 0x00);
			sol_Control.ChitTicketIncludeBarcode = SqlClientUtility.GetBoolean(dataReader, "ChitTicketIncludeBarcode", false);
			sol_Control.CashOutPrintingOverride = SqlClientUtility.GetBoolean(dataReader, "CashOutPrintingOverride", false);
			sol_Control.WhiteBagID = SqlClientUtility.GetInt32(dataReader, "WhiteBagID", 0);
			sol_Control.BlueBagID = SqlClientUtility.GetInt32(dataReader, "BlueBagID", 0);
			sol_Control.OneWayBagID = SqlClientUtility.GetInt32(dataReader, "OneWayBagID", 0);
			sol_Control.ABCRCPalletsID = SqlClientUtility.GetInt32(dataReader, "ABCRCPalletsID", 0);
			sol_Control.CustomerScreenMonitor = SqlClientUtility.GetByte(dataReader, "CustomerScreenMonitor", 0x00);
			sol_Control.CategoryButtonsPanelBgColor = SqlClientUtility.GetInt32(dataReader, "CategoryButtonsPanelBgColor", 0);
			sol_Control.CategoryButtonsSnapToGrid = SqlClientUtility.GetBoolean(dataReader, "CategoryButtonsSnapToGrid", false);
			sol_Control.BusinessHoursFromTue = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursFromTue", new DateTime(0));
			sol_Control.BusinessHoursToTue = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursToTue", new DateTime(0));
			sol_Control.BusinessHoursFromWed = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursFromWed", new DateTime(0));
			sol_Control.BusinessHoursToWed = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursToWed", new DateTime(0));
			sol_Control.BusinessHoursFromThu = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursFromThu", new DateTime(0));
			sol_Control.BusinessHoursToThu = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursToThu", new DateTime(0));
			sol_Control.BusinessHoursFromFri = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursFromFri", new DateTime(0));
			sol_Control.BusinessHoursToFri = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursToFri", new DateTime(0));
			sol_Control.BusinessHoursFromSat = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursFromSat", new DateTime(0));
			sol_Control.BusinessHoursToSat = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursToSat", new DateTime(0));
			sol_Control.BusinessHoursFromSun = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursFromSun", new DateTime(0));
			sol_Control.BusinessHoursToSun = SqlClientUtility.GetDateTime(dataReader, "BusinessHoursToSun", new DateTime(0));
			sol_Control.ReturnsMaxQuantity = SqlClientUtility.GetInt32(dataReader, "ReturnsMaxQuantity", 0);
			sol_Control.WebBrowserUpdateHistoryUrl = SqlClientUtility.GetString(dataReader, "WebBrowserUpdateHistoryUrl", String.Empty);
			sol_Control.CashierMaxAmount = SqlClientUtility.GetDecimal(dataReader, "CashierMaxAmount", Decimal.Zero);
			sol_Control.ComputerRole = SqlClientUtility.GetByte(dataReader, "ComputerRole", 0x00);
			sol_Control.SqlServerDate = SqlClientUtility.GetBoolean(dataReader, "SqlServerDate", false);
			sol_Control.VendorID = SqlClientUtility.GetInt32(dataReader, "VendorID", 0);
			sol_Control.DefaultPlantID = SqlClientUtility.GetInt32(dataReader, "DefaultPlantID", 0);
			sol_Control.DefaultCarrierID = SqlClientUtility.GetInt32(dataReader, "DefaultCarrierID", 0);
			sol_Control.ABCRCUserName = SqlClientUtility.GetString(dataReader, "ABCRCUserName", String.Empty);
			sol_Control.ABCRCPassword = SqlClientUtility.GetString(dataReader, "ABCRCPassword", String.Empty);
			sol_Control.ReceiptAmountBarcode = SqlClientUtility.GetBoolean(dataReader, "ReceiptAmountBarcode", false);
			sol_Control.IncludeSecurityCode = SqlClientUtility.GetBoolean(dataReader, "IncludeSecurityCode", false);
			sol_Control.RBillNumberBarcode = SqlClientUtility.GetBoolean(dataReader, "RBillNumberBarcode", false);
			sol_Control.SacCashTrayID = SqlClientUtility.GetInt32(dataReader, "SacCashTrayID", 0);

			return sol_Control;
		}

		#endregion
	}
}
