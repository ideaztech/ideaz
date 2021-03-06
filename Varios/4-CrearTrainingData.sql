
/**********************************************************************/
/* 4-CrearTrainingData.sql                                            */
/*                                                                    */
/* Copyright winsir, Inc. 2012                                        */
/* All Rights Reserved.                                               */
/**********************************************************************/
USE [Solum]
GO

DELETE Sol_Settings
INSERT INTO [Sol_Settings]
(
	[Name],
	[Description],
	[SetValue]
)
SELECT 
	[Name],
	[Description],
	[SetValue]
FROM Solum.dbo.[Sol_Settings]

DELETE Sac_Settings
INSERT INTO [Sac_Settings]
(
	[Name],
	[Description],
	[SetValue]
)
SELECT 
	[Name],
	[Description],
	[SetValue]
FROM Solum.dbo.[Sac_Settings]

DELETE Qds_Settings
INSERT INTO [Qds_Settings]
(
	[Name],
	[Description],
	[SetValue]
)
SELECT 
	[Name],
	[Description],
	[SetValue]
FROM Solum.dbo.Qds_Settings

delete Sol_Customers
DELETE Qds_CardType
SET IDENTITY_INSERT Qds_CardType ON
INSERT INTO [Qds_CardType]
(
	[CardTypeID],
	[CardType]
)
SELECT 
	[CardTypeID],
	[CardType]
FROM Solum.dbo.Qds_CardType
SET IDENTITY_INSERT Qds_CardType OFF

delete Qds_PaymentMethodAvailableByDepot
DELETE Qds_PaymentMethod
SET IDENTITY_INSERT Qds_PaymentMethod ON
INSERT INTO [Qds_PaymentMethod]
(
	[PaymentMethodID],
	[PaymentMethod]
)
SELECT 
	[PaymentMethodID],
	[PaymentMethod]
FROM Solum.dbo.Qds_PaymentMethod
SET IDENTITY_INSERT Qds_PaymentMethod OFF

--DELETE Qds_PaymentMethodAvailableByDepot
INSERT INTO [Qds_PaymentMethodAvailableByDepot]
(
	[DepotID],
	[PaymentMethodID],
	[DepotDefault]
)
SELECT 
	[DepotID],
	[PaymentMethodID],
	[DepotDefault]
FROM Solum.dbo.Qds_PaymentMethodAvailableByDepot

DELETE sol_Control
insert into sol_Control(
	[ControlID],
	[BusinessName],
	[LegalName],
	[StoreNumber],
	[Address],
	[City],
	[State],
	[Country],
	[PhoneNumber],
	[BusinessHoursFrom],
	[BusinessHoursTo],
	[IdFiscal1Name],
	[IdFiscal1Value],
	[IdFiscal2Name],
	[IdFiscal2Value],
	[WorkStationID],
	[CustomerScreenMessageID],
	[FrontStationMessageID],
	[CashierRoutineMessageID],
	[ReturnStationMessageID],
	[CashierStationMessageID],
	[ShippingStationMessageID],
	[ReceiptMessageID],
	[SMTPServer],
	[SMTPPort],
	[EmailAccount],
	[EmailPassword],
	[HistoryYears],
	[FiscalYearInitialMonth],
	[NumericKeyPadOn],
	[NumericKeyPadPosition],
	[ReturnButtonExtra],
	[Tax1Name],
	[Tax1Rate],
	[Tax2Name],
	[Tax2Rate],
	[DatabaseVersion],
	[Status],
	[EmployeesListRefresh],
	[WebBrowserUrl],
	[AutoGenerateTagNumber],
	[AutoGenerateRBillNumber],
	[DefaultAgencyID],
	[ChitTicketComplete],
	[ChitTicketIncludeBarcode],
	[CashOutPrintingOverride],
	[WhiteBagID],
	[BlueBagID],
	[OneWayBagID],
	[ABCRCPalletsID],
	[CustomerScreenMonitor],
	[CategoryButtonsPanelBgColor],
	[CategoryButtonsSnapToGrid],
	[BusinessHoursFromTue],
	[BusinessHoursToTue],
	[BusinessHoursFromWed],
	[BusinessHoursToWed],
	[BusinessHoursFromThu],
	[BusinessHoursToThu],
	[BusinessHoursFromFri],
	[BusinessHoursToFri],
	[BusinessHoursFromSat],
	[BusinessHoursToSat],
	[BusinessHoursFromSun],
	[BusinessHoursToSun],
	[ReturnsMaxQuantity],
	[WebBrowserUpdateHistoryUrl],
	[CashierMaxAmount],
	[ComputerRole],
	[SqlServerDate],
	[VendorID],
	[DefaultPlantID],
	[DefaultCarrierID],
	[ABCRCUserName],
	[ABCRCPassword],
	[ReceiptAmountBarcode],
	[IncludeSecurityCode],
	[RBillNumberBarcode],
	[SacCashTrayID]
)
select
	[ControlID],
	[BusinessName],
	[LegalName],
	[StoreNumber],
	[Address],
	[City],
	[State],
	[Country],
	[PhoneNumber],
	[BusinessHoursFrom],
	[BusinessHoursTo],
	[IdFiscal1Name],
	[IdFiscal1Value],
	[IdFiscal2Name],
	[IdFiscal2Value],
	[WorkStationID],
	[CustomerScreenMessageID],
	[FrontStationMessageID],
	[CashierRoutineMessageID],
	[ReturnStationMessageID],
	[CashierStationMessageID],
	[ShippingStationMessageID],
	[ReceiptMessageID],
	[SMTPServer],
	[SMTPPort],
	[EmailAccount],
	[EmailPassword],
	[HistoryYears],
	[FiscalYearInitialMonth],
	[NumericKeyPadOn],
	[NumericKeyPadPosition],
	[ReturnButtonExtra],
	[Tax1Name],
	[Tax1Rate],
	[Tax2Name],
	[Tax2Rate],
	[DatabaseVersion],
	[Status],
	[EmployeesListRefresh],
	[WebBrowserUrl],
	[AutoGenerateTagNumber],
	[AutoGenerateRBillNumber],
	[DefaultAgencyID],
	[ChitTicketComplete],
	[ChitTicketIncludeBarcode],
	[CashOutPrintingOverride],
	[WhiteBagID],
	[BlueBagID],
	[OneWayBagID],
	[ABCRCPalletsID],
	[CustomerScreenMonitor],
	[CategoryButtonsPanelBgColor],
	[CategoryButtonsSnapToGrid],
	[BusinessHoursFromTue],
	[BusinessHoursToTue],
	[BusinessHoursFromWed],
	[BusinessHoursToWed],
	[BusinessHoursFromThu],
	[BusinessHoursToThu],
	[BusinessHoursFromFri],
	[BusinessHoursToFri],
	[BusinessHoursFromSat],
	[BusinessHoursToSat],
	[BusinessHoursFromSun],
	[BusinessHoursToSun],
	[ReturnsMaxQuantity],
	[WebBrowserUpdateHistoryUrl],
	[CashierMaxAmount],
	[ComputerRole],
	[SqlServerDate],
	[VendorID],
	[DefaultPlantID],
	[DefaultCarrierID],
	[ABCRCUserName],
	[ABCRCPassword],
	[ReceiptAmountBarcode],
	[IncludeSecurityCode],
	[RBillNumberBarcode],
	[SacCashTrayID]
from Solum.dbo.sol_Control

delete sol_Products
delete sol_Agencies
--DBCC CHECKIDENT ('sol_Agencies', RESEED, 0)
--DBCC CHECKIDENT ('sol_Agencies', RESEED)
SET IDENTITY_INSERT sol_Agencies ON
insert into sol_Agencies(
	[AgencyID],
	[Name],
	[Description],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[VendorID],
	[AutoGenerateTagNumber]
)
select
	[AgencyID],
	[Name],
	[Description],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[VendorID],
	[AutoGenerateTagNumber]
from Solum.dbo.sol_Agencies
SET IDENTITY_INSERT sol_Agencies OFF

delete sol_CashDenominations
SET IDENTITY_INSERT sol_CashDenominations ON
insert into sol_CashDenominations(
	[CashID],
	[CashType],
	[CashValue],
	[Description],
	[OrderValue],
	[CashItemValue],
	[Quantity],
	[MoneyID]
)
select
	[CashID],
	[CashType],
	[CashValue],
	[Description],
	[OrderValue],
	[CashItemValue],
	[Quantity],
	[MoneyID]
from Solum.dbo.sol_CashDenominations
SET IDENTITY_INSERT sol_CashDenominations OFF

delete sol_Cashtrays
SET IDENTITY_INSERT sol_Cashtrays on
insert into sol_Cashtrays(
	[CashTrayID],
	[Description],
	[WorkStationID],
	[UserID],
	[UserName]
)
select
	[CashTrayID],
	[Description],
	[WorkStationID],
	[UserID],
	[UserName]
from Solum.dbo.sol_Cashtrays
SET IDENTITY_INSERT sol_Cashtrays OFF

delete sol_CategoryButtons
delete Sol_Categories
SET IDENTITY_INSERT Sol_Categories ON
insert into Sol_Categories(
	[CategoryID],
	[Description],
	[RefundAmount],
	[SubContainerQuantity],
	[StagingMethodID]
)
select
	[CategoryID],
	[Description],
	[RefundAmount],
	[SubContainerQuantity],
	[StagingMethodID]
from Solum.dbo.Sol_Categories
SET IDENTITY_INSERT Sol_Categories OFF

delete Vir_ConveyorLink
SET IDENTITY_INSERT Vir_ConveyorLink ON
insert into Vir_ConveyorLink(
	[ConveyorLinkID],
	[BagPositionID],
	[ConveyorID]
)
select
	[ConveyorLinkID],
	[BagPositionID],
	[ConveyorID]
from Solum.dbo.Vir_ConveyorLink
SET IDENTITY_INSERT Vir_ConveyorLink OFF

delete sol_WorkStations
delete Vir_Conveyor
SET IDENTITY_INSERT Vir_Conveyor ON
insert into Vir_Conveyor(
	[ConveyorID],
	[ConveyorDescription]
)
select
	[ConveyorID],
	[ConveyorDescription]
from Solum.dbo.Vir_Conveyor
SET IDENTITY_INSERT Vir_Conveyor OFF

delete sol_QuantityButtons
--delete sol_WorkStations
SET IDENTITY_INSERT Sol_WorkStations ON
insert into sol_WorkStations(
	[WorkStationID],
	[Name],
	[Description],
	[Location],
	[ConveyorID]
)
select
	[WorkStationID],
	[Name],
	[Description],
	[Location],
	[ConveyorID]
from Solum.dbo.sol_WorkStations
SET IDENTITY_INSERT sol_WorkStations OFF

delete sol_categoryButtons
SET IDENTITY_INSERT Sol_categoryButtons ON
insert into sol_categoryButtons(
	[CategoryButtonID],
	[WorkStationID],
	[ControlType],
	[Description],
	[DefaultQuantity],
	[CategoryID],
	[LocationX],
	[LocationY],
	[Width],
	[Height],
	[Font],
	[FontStyle],
	[ForeColor],
	[BackColor],
	[ImageIndex],
	[ImagePath],
	[SubContainerMaxCount],
	[SubContainerCounter],
	[ImageSize],
	[SubContainerCountDown],
	[MaxCountPerLine],
	[ForeColorArgb],
	[BackColorArgb]
)
select
	[CategoryButtonID],
	[WorkStationID],
	[ControlType],
	[Description],
	[DefaultQuantity],
	[CategoryID],
	[LocationX],
	[LocationY],
	[Width],
	[Height],
	[Font],
	[FontStyle],
	[ForeColor],
	[BackColor],
	[ImageIndex],
	[ImagePath],
	[SubContainerMaxCount],
	[SubContainerCounter],
	[ImageSize],
	[SubContainerCountDown],
	[MaxCountPerLine],
	[ForeColorArgb],
	[BackColorArgb]
from Solum.dbo.sol_categoryButtons
SET IDENTITY_INSERT sol_categoryButtons OFF

delete sol_Containers
delete sol_ContainerTypes
SET IDENTITY_INSERT sol_ContainerTypes ON
insert into sol_ContainerTypes(
	[ContainerTypeID],
	[Description]
)
select
	[ContainerTypeID],
	[Description]
from Solum.dbo.sol_ContainerTypes
SET IDENTITY_INSERT sol_ContainerTypes OFF

--delete sol_Containers
SET IDENTITY_INSERT sol_Containers ON
insert into sol_Containers(
	[ContainerID],
	[Description],
	[ShortDescription],
	[ContainerTypeID],
	[ShippingContainerID],
	[ShippingContainerTypeID]
)
select
	[ContainerID],
	[Description],
	[ShortDescription],
	[ContainerTypeID],
	[ShippingContainerID],
	[ShippingContainerTypeID]
from Solum.dbo.sol_Containers
SET IDENTITY_INSERT sol_Containers OFF

delete sol_ExpenseTypes
SET IDENTITY_INSERT sol_ExpenseTypes ON
insert into sol_ExpenseTypes(
	[ExpenseTypeID],
	[Description]
)
select
	[ExpenseTypeID],
	[Description]
from Solum.dbo.sol_ExpenseTypes
SET IDENTITY_INSERT sol_ExpenseTypes OFF

delete sol_Fees
SET IDENTITY_INSERT sol_Fees ON
insert into sol_Fees(
	[FeeID],
	[FeeDescription],
	[FeeAmount],
	[Percentage]
)
select
	[FeeID],
	[FeeDescription],
	[FeeAmount],
	[Percentage]
from Solum.dbo.sol_Fees
SET IDENTITY_INSERT sol_Fees OFF

delete sol_StandardDozen
SET IDENTITY_INSERT sol_StandardDozen ON
insert into sol_StandardDozen(
	[StandardDozenID],
	[Quantity]
)
select
	[StandardDozenID],
	[Quantity]
from Solum.dbo.sol_StandardDozen
SET IDENTITY_INSERT sol_StandardDozen OFF

--delete sol_Products
SET IDENTITY_INSERT sol_Products ON
insert into sol_Products(
	[ProductID],
	[ProName],
	[ProDescription],
	[ProShortDescription],
	[ProImage],
	[AgencyID],
	[MenuOrder],
	[IsActive],
	[Price],
	[CategoryID],
	[RefundAmount],
	[HandlingCommissionAmount],
	[CommissionUnit],
	[VafAmount],
	[FeeUnit],
	[ContainerID],
	[StandardDozenID],
	[UPC],
	[ProductCode],
	[TypeId],
	[Tax1Exempt],
	[Tax2Exempt],
	[MasterProductID]
)
select
	[ProductID],
	[ProName],
	[ProDescription],
	[ProShortDescription],
	[ProImage],
	[AgencyID],
	[MenuOrder],
	[IsActive],
	[Price],
	[CategoryID],
	[RefundAmount],
	[HandlingCommissionAmount],
	[CommissionUnit],
	[VafAmount],
	[FeeUnit],
	[ContainerID],
	[StandardDozenID],
	[UPC],
	[ProductCode],
	[TypeId],
	[Tax1Exempt],
	[Tax2Exempt],
	[MasterProductID]
from Solum.dbo.sol_Products
SET IDENTITY_INSERT sol_Products OFF

delete sol_QuantityButtons
SET IDENTITY_INSERT sol_QuantityButtons ON
insert into sol_QuantityButtons(
	[QuantityButtonID],
	[WorkStationID],
	[ControlType],
	[Description],
	[DefaultQuantity],
	[CategoryID],
	[LocationX],
	[LocationY],
	[Width],
	[Height],
	[Font],
	[FontStyle],
	[ForeColor],
	[BackColor]
)
select
	[QuantityButtonID],
	[WorkStationID],
	[ControlType],
	[Description],
	[DefaultQuantity],
	[CategoryID],
	[LocationX],
	[LocationY],
	[Width],
	[Height],
	[Font],
	[FontStyle],
	[ForeColor],
	[BackColor]
from Solum.dbo.sol_QuantityButtons
SET IDENTITY_INSERT sol_QuantityButtons OFF

delete sol_Messages
SET IDENTITY_INSERT sol_Messages ON
insert into sol_Messages(
	[MessageID],
	[Name],
	[Description]
)
select
	[MessageID],
	[Name],
	[Description]
from Solum.dbo.sol_Messages
SET IDENTITY_INSERT sol_Messages OFF

--delete sol_Customers
SET IDENTITY_INSERT sol_Customers ON
insert into sol_Customers(
	[CustomerID],
	[CustomerCode],
	[Name],
	[Contact],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[Email],
	[LoweredEmail],
	[IsActive],
	[PhoneNumber],
	[Notes],
	[Password],
	[DepotID],
	[CardNumber],
	[CardTypeID]
)
select
	[CustomerID],
	[CustomerCode],
	[Name],
	[Contact],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[Email],
	[LoweredEmail],
	[IsActive],
	[PhoneNumber],
	[Notes],
	[Password],
	[DepotID],
	[CardNumber],
	[CardTypeID]
	from Solum.dbo.sol_Customers
SET IDENTITY_INSERT sol_Customers OFF
