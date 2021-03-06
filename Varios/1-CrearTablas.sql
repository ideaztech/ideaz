
/**********************************************************************/
/* 1-CrearTablas.sql                                                  */
/*                                                                    */
/* Copyright winsir, Inc. 2012                                        */
/* All Rights Reserved.                                               */
/**********************************************************************/
USE [Solum]
GO

--********************
--Vir_Conveyor
--********************
/****** Object:  Table [dbo].[Vir_Conveyor]    Script Date: 04/05/2016 12:17:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vir_Conveyor](
	[ConveyorID] [int] IDENTITY(1,1) NOT NULL,
	[ConveyorDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK_Vir_Conveyor] PRIMARY KEY CLUSTERED 
(
	[ConveyorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--********************
--Vir_ConveyorLink
--********************
/****** Object:  Table [dbo].[Vir_ConveyorLink]    Script Date: 04/05/2016 12:17:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vir_ConveyorLink](
	[ConveyorLinkID] [int] IDENTITY(1,1) NOT NULL,
	[BagPositionID] [int] NOT NULL,
	[ConveyorID] [int] NOT NULL,
 CONSTRAINT [PK_Vir_ConveyorLink] PRIMARY KEY CLUSTERED 
(
	[ConveyorLinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--********************
--Vir_BagPosition
--********************
/****** Object:  Table [dbo].[Vir_BagPosition]    Script Date: 04/05/2016 12:17:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vir_BagPosition](
	[BagPositionID] [int] NOT NULL,
	[BagPositionName] [nvarchar](100) NULL,
	[ProductID] [int] NULL,
	[CurrentStageID] [int] NULL,
	[CurrentQuantity] [int] NOT NULL,
	[TargetQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Vir_BagPosition] PRIMARY KEY CLUSTERED 
(
	[BagPositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--********************
--Vir_StagingMethod
--********************
/****** Object:  Table [dbo].[Vir_StagingMethod]    Script Date: 04/05/2016 12:17:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vir_StagingMethod](
	[StagingMethodID] [int] IDENTITY(1,1) NOT NULL,
	[StagingMethodName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Vir_StagingMethod] PRIMARY KEY CLUSTERED 
(
	[StagingMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--********************
--Syn_UpdateLog
--********************
/****** Object:  Table [dbo].[Syc_UpdateLog]    Script Date: 16/10/2015 9:22:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Syc_UpdateLog](
	[TempID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NULL,
	[IDName] [nvarchar](50) NULL,
	[IDValue] [int] NULL,
	[ColumnName] [nvarchar](50) NULL,
	[ColumnData] [nvarchar](256) NULL,
 CONSTRAINT [PK_Syc_UpdateLog] PRIMARY KEY CLUSTERED 
(
	[TempID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--********************
--SAC
--********************
--Sac_LogType
/****** Object:  Table [dbo].[Sac_LogType]    Script Date: 26/12/2017 9:22:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--  (1 = SuccessfullPayout, 2 = IncompletePayout, 3 = Error, 4 = AddFloat, 5 = OpenCash, 6 = CloseCash, 7 = OpenCustomerScreen, 8 = CloseCustomerScreen)

/* Updated to version 2.146 of Solum */
CREATE TABLE [dbo].[Sac_LogType](

	[LogTypeID] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sac_LogType] PRIMARY KEY CLUSTERED 
(
	[LogTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--********************
--Sac_Log
--********************
/****** Object:  Table [dbo].[Sac_Log]    Script Date: 26/12/2017 9:22:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE TABLE [dbo].[Sac_Log](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[EntryType]  [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Sac_LogType]([LogTypeID]),
	[OrderNumber] [int] NOT NULL,			--  (default zero if not applicable)
	[OrderAmount] [money] NOT NULL,			--
	[Description] [nvarchar](150) NULL,		--  (text could include a short description of the entry or error details)
	[Quantityof50] [int] NOT NULL,			--  (These would be amount paidout or open, close, add float amounts)
	[Quantityof20] [int] NOT NULL,
	[Quantityof10] [int] NOT NULL,
	[Quantityof5] [int] NOT NULL,
	[QuantityofToonie] [int] NOT NULL,
	[QuantityofLoonie] [int] NOT NULL,
	[QuantityofQuarter] [int] NOT NULL,
	[QuantityofDime] [int] NOT NULL,
	[QuantityofNickel] [int] NOT NULL,
	[TotalValue] [money] NOT NULL,
	[Remaining50] [int] NOT NULL,			--  (These would be the cash inventory left after this )
	[Remaining20] [int] NOT NULL,
	[Remaining10] [int] NOT NULL,
	[Remaining5] [int] NOT NULL,
	[RemainingToonie] [int] NOT NULL,
	[RemainingLoonie] [int] NOT NULL,
	[RemainingQuarter] [int] NOT NULL,
	[RemainingDime] [int] NOT NULL,
	[RemainingNickel] [int] NOT NULL,
	[TimeStamp] [datetime] NOT NULL Default(GetDate()), 
 CONSTRAINT [PK_Sac_Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--Sac_CharityType
/****** Object:  Table [dbo].[Sac_CharityType]    Script Date: 9/6/2015 9:22:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sac_CharityType](
	[CharityTypeID] [int] NOT NULL,
	[CharityType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sac_CharityType] PRIMARY KEY CLUSTERED 
(
	[CharityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--Sac_Charity
/****** Object:  Table [dbo].[Sac_Charity]    Script Date: 9/6/2015 9:12:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sac_Charity](
	[CharityID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ShortName] [nvarchar](50) NULL,
	[CharityDescription] [nvarchar](500) NULL,
	[CharityTypeID] [int] NOT NULL,
	[RegistrationNumber] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[ButtonPosition] [tinyint] NOT NULL,
	[Logo] [image] NULL,
 CONSTRAINT [PK_Sac_Charity] PRIMARY KEY CLUSTERED 
(
	[CharityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


--Sac_Settings
/****** Object:  Table [dbo].[Sac_Settings]    Script Date: 10/4/2014 11:52:00 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sac_Settings](
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](2048) NOT NULL,
	[SetValue] [sql_variant] NOT NULL,  
 CONSTRAINT [PK_Sac_Settings] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--********************
--QDS
--********************
--Qds_Settings
/****** Object:  Table [dbo].[Qds_Settings]    Script Date: 21/11/2013 01:00:03 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Qds_Settings](
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](2048) NOT NULL,
	[SetValue] [sql_variant] NOT NULL,  
 CONSTRAINT [PK_Qds_Settings] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Qds_CardType]    Script Date: 11/8/2013 8:37:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qds_CardType](
	[CardTypeID] [int] IDENTITY(0,1) NOT NULL,
	[CardType] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Qds_CardType] PRIMARY KEY CLUSTERED 
(
	[CardTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Qds_PaymentMethod]    Script Date: 11/8/2013 8:37:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qds_PaymentMethod](		-- cash, pick up check, mail me check, paypal
	[PaymentMethodID] [int] IDENTITY(0,1) NOT NULL,
	[PaymentMethod] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Qds_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qds_PaymentMethodAvailableByDepot]    Script Date: 11/8/2013 8:37:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Qds_PaymentMethodAvailableByDepot](
	[DepotID] [char](6) NOT NULL,				--from solum's setting 
	[PaymentMethodID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Qds_PaymentMethod](PaymentMethodID),
	[DepotDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Qds_PaymentMethodAvailableByDepot] PRIMARY KEY CLUSTERED 
(
	[DepotID] ASC,
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Qds_Drop]    Script Date: 11/8/2013 8:37:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Qds_Drop](
	[DropID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,	-- FOREIGN KEY REFERENCES is created after sol_customers table is created
	[NumberOfBags] [int] NOT NULL,
	[PaymentMethodID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Qds_PaymentMethod](PaymentMethodID),
	[DepotID] [char](6) NOT NULL,				-- from solum's setting 
	[OrderID] [int] NOT NULL,					-- only one order for every drop, FOREIGN KEY REFERENCES is created after sol_orders table is created
	[OrderType] [char](1) NOT NULL,				-- R = Returns, S = Sales, A = Adjustment
	[IsNew] bit Default(1) NOT NULL,
 CONSTRAINT [PK_Qds_Drop] PRIMARY KEY CLUSTERED 
(
	[DropID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Qds_Bag]    Script Date: 11/8/2013 8:37:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Qds_Bag](
	[BagID] [int] IDENTITY(1,1) NOT NULL,
	[DropID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Qds_Drop](DropID),
	[BagEstimateUnderLitre] [int] NOT NULL,
	[BagEstimateOverLitre] [int] NOT NULL,
	[DateEntered] [datetime] NOT NULL,			-- Date the dropoff was set up online
	[DateAccepted] [datetime] NOT NULL,			-- When the machine received the bag
	[DateCounted] [datetime] NOT NULL,			-- when the staff counted
	[DatePaid] [datetime] NOT NULL,				-- when it was paid
	[DepotID] [char](6) NOT NULL,				-- from solum's setting 
	[DatePrinted] [datetime] NOT NULL,			-- when they printed the label
	[IsNew] bit Default(1) NOT NULL,
 CONSTRAINT [PK_Qds_Bag] PRIMARY KEY CLUSTERED 
(
	[BagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Qds_Customer]    Script Date: 11/8/2013 8:37:47 AM ******/
--SET ANSI_NULLS ON								we will use sol_customer and add new fields there for now
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
--CREATE TABLE [dbo].[Qds_Customer](
--	[CustomerID] [uniqueidentifier] NOT NULL,
--	--[FirstName] [nvarchar](50) NULL,			--these information 
--	--[LastName] [nvarchar](50) NULL,
--	--[Address1] [nvarchar](250) NULL,
--	--[Address2] [nvarchar](250) NULL,
--	--[City] [nvarchar](100) NULL,
--	--[Province] [nvarchar](100) NULL,
--	--[PostCode] [nvarchar](100) NULL,
--	--[Email] [nvarchar](256) NULL,
--	--[Phone] [nvarchar](20) NULL,
--	[PIN] [nvarchar](128) NOT NULL,				-- (as password)
--	--[DepotID] [char](6) NOT NULL,				|add these fields
--	[CardNumber] [nvarchar](50) NOT NULL,		|to sol customers table
--	[CardTypeID] [int] NOT NULL,				--
-- CONSTRAINT [PK_Qds_Customer] PRIMARY KEY CLUSTERED 
--(
--	[CustomerID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--SET ANSI_PADDING OFF
--GO

/****** Object:  Table [dbo].[Qds_Depot]    Script Date: 11/8/2013 8:37:47 AM ******/
--SET ANSI_NULLS ON								--we will use a setting for depotid in solum
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
--CREATE TABLE [dbo].[Qds_Depot](
--	[DepotID] [char](6) NOT NULL,	--6 digit number – first digit random. 4 digits sequential. 6th digit 10-first digit.
--	[Name] [nvarchar](256) NOT NULL,
--	[City] [nvarchar](100) NOT NULL,
--	[PostCode] [nvarchar](100) NOT NULL,
-- CONSTRAINT [PK_Qds_Depot] PRIMARY KEY CLUSTERED 
--(
--	[DepotID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO
--SET ANSI_PADDING OFF
--GO

--*********************************
--Sol_Settings
--*********************************
/****** Object:  Table [dbo].[Sol_Settings]    Script Date: 16/09/2013 11:00:03 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sol_Settings](
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](2048) NOT NULL,
	[SetValue] [sql_variant] NOT NULL,  
 CONSTRAINT [PK_Sol_Settings] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--*********************************
--Sol_OrderCardLink
--*********************************
/****** Object:  Table [dbo].[Sol_OrderCardLink]    Script Date: 16/09/2013 10:47:13 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sol_OrderCardLink](
	[CardNumber] [nvarchar](50) NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_Sol_OrderCardLink] PRIMARY KEY CLUSTERED 
(
	[CardNumber] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Sol_OrderCardLink]') AND name = N'IN_Sol_OrderCardLink_CardNumber')
CREATE NONCLUSTERED INDEX [IN_Sol_OrderCardLink_CardNumber] ON [dbo].[Sol_OrderCardLink] 
(
	[CardNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


--*********************************
--Sol_OrderCardLog
--*********************************
/****** Object:  Table [dbo].[Sol_OrderCardLog]    Script Date: 16/09/2013 10:50:13 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sol_OrderCardLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [nvarchar](50) NOT NULL,
	[OrderID] [int] NOT NULL,
	[DateAdded] [datetime] NULL,
	[DatePaid] [datetime] NULL,
CONSTRAINT [PK_Sol_OrderCardLog] PRIMARY KEY CLUSTERED 
(
	[CardNumber] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Sol_OrderCardLink]') AND name = N'IN_Sol_OrderCardLink_OrderID')
--CREATE NONCLUSTERED INDEX [IN_Sol_OrderCardLink_OrderID] ON [dbo].[Sol_OrderCardLink] 
--(
--	[OrderID] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--GO

/****** Object:  Table [dbo].[Sol_AutoNumbers]    Script Date: 24/07/2013 15:47:13 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sol_AutoNumbers](
	[AgencyID] [int] NOT NULL,
	[FolioID] [int] NOT NULL,
	[TagNumber] [int] NOT NULL,
	[RBillNumber] [int] NOT NULL,
 CONSTRAINT [PK_Sol_AutoNumbers] PRIMARY KEY CLUSTERED 
(
	[AgencyID] ASC,
	[FolioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Sol_AutoNumbers]') AND name = N'IN_Sol_AutoNumbers_TagNumber')
--CREATE NONCLUSTERED INDEX [IN_Sol_AutoNumbers_TagNumber] ON [dbo].[Sol_AutoNumbers] 
--(
--	[TagNumber] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--GO

--IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Sol_AutoNumbers]') AND name = N'IN_Sol_AutoNumbers_RBillNumber')
--CREATE NONCLUSTERED INDEX [IN_Sol_AutoNumbers_RBillNumber] ON [dbo].[Sol_AutoNumbers] 
--(
--	[RBillNumber] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--GO


/****** Object:  Table [dbo].[Sac_ClientNames]    Script Date: 27/06/2013 12:17:13 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sac_ClientNames](
	[ClientID] [nvarchar](50) NOT NULL,
	[CashTrayID] [int] NOT NULL,
	[CoinAmountInventory] [money] NOT NULL,
 CONSTRAINT [PK_Sac_ClientNames] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Sac_ClientNames]') AND name = N'IN_Sac_ClientNames_CashTrayID')
CREATE NONCLUSTERED INDEX [IN_Sac_ClientNames_CashTrayID] ON [dbo].[Sac_ClientNames] 
(
	[CashTrayID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

--Sac_Money
/****** Object:  Table [dbo].[Sac_Money]    Script Date: 13/06/2013 04:14:10 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sac_Money](
	[MoneyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[TypeID] [tinyint] NULL,				--0 = coin, 1=bill
	[DollarValue] [money] NULL,
	[CountryCode] [nchar](2) NULL,
 CONSTRAINT [PK_Sac_Money] PRIMARY KEY CLUSTERED 
(
	[MoneyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Default [DF_Sac_Money_MoneyID]    Script Date: 13/06/2013 04:14:10 p. m. ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Sac_Money_MoneyID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sac_Money]'))
--Begin
--	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Sac_Money_MoneyID]') AND type = 'D')
--	BEGIN
--		ALTER TABLE [dbo].[Sac_Money] ADD  CONSTRAINT [DF_Sac_Money_MoneyID]  DEFAULT (Newid()) FOR [MoneyID]
--	END
--End
--GO

--Sac_MoneyInventory
/****** Object:  Table [dbo].[Sac_MoneyInventory]    Script Date: 13/06/2013 04:19:17 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sac_MoneyInventory](
	[ClientID] [nvarchar](50) NOT NULL,	--[ComputerName] 
	[MoneyID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Sac_Money](MoneyID),
	[BillDispenserID] [int] NOT NULL,
	[Address] [nvarchar](10) NULL,
	[Inventory] [int] NULL,
	[MaxNumBills] [int] NULL,				-- Maximum number of bills to be dispensed
	[FullQuantity] [int] NULL,
 CONSTRAINT [PK_Sac_MoneyInventory] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[MoneyID] ASC,
	[BillDispenserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Sac_MoneyInventory]') AND name = N'IN_Sac_MoneyInventory_CashID')
--CREATE NONCLUSTERED INDEX [IN_Sac_MoneyInventory_CashID] ON [dbo].[Sac_MoneyInventory] 
--(
--	[ClientID] ASC,
--	[CashID] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--GO

/****** Object:  Table [dbo].[Sol_BinCount]    Script Date: 21/05/2013 12:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_BinCount]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_BinCount](
	[ClientID] [varchar](50) NOT NULL,	--[ComputerName] 
	[CategoryButtonID] [int] NOT NULL,	--FOREIGN KEY REFERENCES [dbo].[Sol_CategoryButton](CategoryButtonID),
	[CurrentCount] [int] NULL,	
 CONSTRAINT [PK_Sol_BinCount] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CategoryButtonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Sol_WS_ErrorCodes]    Script Date: 10/11/2012 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_WS_ErrorCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_WS_ErrorCodes](
	[ErrorNumber] [int] NOT NULL,
	[ErrorDescription] [varchar](256) NULL,
	[MessageToClient] [bit] NULL,	
	[Notes] [nvarchar](256) NULL,
 CONSTRAINT [PK_Sol_WS_ErrorCodes] PRIMARY KEY CLUSTERED 
(
	[ErrorNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Sol_WS_ShippingContainerTypes]    Script Date: 10/11/2012 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_WS_ShippingContainerTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_WS_ShippingContainerTypes](
	[ShippingContainerTypeID] [int] NOT NULL,
	[ShippingContainerType] [varchar](256) NULL,
 CONSTRAINT [PK_Sol_WS_ShippingContainerTypes] PRIMARY KEY CLUSTERED 
(
	[ShippingContainerTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Sol_WS_ItemTypes]    Script Date: 10/11/2012 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_WS_ItemTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_WS_ItemTypes](
	[ItemTypeID] [int] NOT NULL,
	[ItemType] [varchar](256) NULL,
 CONSTRAINT [PK_Sol_WS_ItemTypes] PRIMARY KEY CLUSTERED 
(
	[ItemTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Sol_WS_Plants]    Script Date: 10/11/2012 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_WS_Plants]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_WS_Plants](
	[PlantID] [int] NOT NULL,
	[Plant] [varchar](256) NULL,
 CONSTRAINT [PK_Sol_WS_Plants] PRIMARY KEY CLUSTERED 
(
	[PlantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Sol_WS_Carriers]    Script Date: 10/11/2012 10:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_WS_Carriers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_WS_Carriers](
	[CarrierID] [int] NOT NULL,
	[Carrier] [varchar](256) NULL,
 CONSTRAINT [PK_Sol_WS_Carriers] PRIMARY KEY CLUSTERED 
(
	[CarrierID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Sol_SupplyInventory]    Script Date: 21/03/2012 16:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_SupplyInventory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_SupplyInventory](
	[SupplyInventoryID] [int] IDENTITY(1,1) NOT NULL,
	[SupplyInventoryType] [char](1) NOT NULL,		-- SupplyInventoryTypeID Class =  O = Order, R = Received Order, A = Adjustment, S = Shipped
	[UserID] [uniqueidentifier] NOT NULL,			-- FOREIGN KEY REFERENCES [dbo].aspnet_Applications(UserID),
	[Date] [datetime] NULL,
	[DateOrdered] [datetime] NULL,					-- example:		(for BOL)
	[ProductID] [int] NULL,							-- 1006			(CRIS Code from productId)
	[ContainerID] [int] NULL,						--     WhiteBags
	[Quantity] [int] NULL,
	[ShipmentID] [int] NOT NULL,
	[ReferenceNumber] [varchar](100) NULL,
 CONSTRAINT [PK_Sol_SupplyInventory] PRIMARY KEY CLUSTERED 
(
	[SupplyInventoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Sol_Employees]    Script Date: 12/13/2011 16:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Employees]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Sol_Employees](
		[UserId] [uniqueidentifier] NOT NULL PRIMARY KEY NONCLUSTERED FOREIGN KEY REFERENCES dbo.aspnet_Users(UserId),
		--[ApplicationId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [dbo].aspnet_Applications(ApplicationId),
		--[UserName] [nvarchar](256) NOT NULL,
		[FirstName] [nvarchar](256) NULL,
		[LastName] [nvarchar](256) NULL,
		[MiddleName] [nvarchar](256) NULL,
		[BirthDate] [datetime] NULL,
		[HireDate] [datetime] NULL,
		[EmployeeNotes] [nvarchar](512) NULL,
		[SIN] [nvarchar](256) NULL,
		[Gender] [tinyint] NULL,					-- 0 = male, 1= female
		[EmployeeNumber] [nvarchar](256) NULL,
		[PayrollNumber] [nvarchar](256) NULL,
		[CompensationAmount] [money] NULL,
		[CompensationType] [tinyint] NULL)			-- 0 = hourly, 1= anually
	--CREATE UNIQUE CLUSTERED INDEX Sol_Employees_Index ON [dbo].Sol_Employees(ApplicationId, UserName)
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[sol_EmployeesLog]    Script Date: 12/13/2011 16:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_EmployeesLog]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Sol_EmployeesLog](
		[LogId]  [bigint] IDENTITY(0,1) NOT NULL PRIMARY KEY NONCLUSTERED,
		[UserId] [uniqueidentifier] NOT NULL,	-- FOREIGN KEY REFERENCES dbo.Sol_Employees(UserId),
		[PunchInTime] [DateTime] NULL,
		[PunchOutTime] [DateTime] NULL,
		[Comments] [nvarchar](512) NULL,
		[Approved] [bit] NULL,	
		[Modified] [bit] NULL)
	CREATE UNIQUE CLUSTERED INDEX Sol_EmployeesLog_Index ON [dbo].Sol_EmployeesLog(PunchInTime)
	CREATE NONCLUSTERED INDEX Sol_EmployeesLog_Index2 ON [dbo].Sol_EmployeesLog(UserId, PunchInTime)
END
GO
SET ANSI_PADDING OFF
GO


--********************
--Sol_Categories
--********************
/****** Object:  Table [dbo].[Sol_Categories]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sol_Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sol_Categories](
	[CategoryID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[RefundAmount] [money] NULL,
	[SubContainerQuantity] [int] NULL,
	[StagingMethodID] [int] NOT NULL,
	[StagingProductID] [int] NULL,
 CONSTRAINT [PK_Sol_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_CashTrays]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_CashTrays]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_CashTrays](
	[CashTrayID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](256) NULL,
	[WorkStationID] [int] NULL,
	[UserID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_sol_CashTrays] PRIMARY KEY CLUSTERED 
(
	[CashTrayID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_CashDenominations]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_CashDenominations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_CashDenominations](
	[CashID] [int] IDENTITY(1,1) NOT NULL,
	[CashType] [tinyint] NOT NULL,								-- 0 - Coin, 1 - Bill, 2 - Roll
	[CashValue] [money] NOT NULL,								-- Item or Total Value for rolls
	[Description] [varchar](256) NULL,
	[OrderValue] [smallint] NULL,
	[CashItemValue] [money] NOT NULL DEFAULT (0),				-- Item Value for rolls (to get count = CashValue/CashItemValue)
	[Quantity] [int] NOT NULL DEFAULT (1),						-- # of Items in a rolls (1 for the rest of denominations)
	[MoneyID] [int] NULL,										--FOREIGN KEY REFERENCES [dbo].[Sac_Money](MoneyID),
 CONSTRAINT [PK_CashDenominations] PRIMARY KEY CLUSTERED 
(
	[CashID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[sol_Agencies]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Agencies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Agencies](
	[AgencyID] [int] IDENTITY(0,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Address1] [varchar](250) NULL,
	[Address2] [varchar](250) NULL,
	[City] [varchar](100) NULL,
	[Province] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[VendorID] [nvarchar](50) NULL,
	[AutoGenerateTagNumber] [bit] NULL,
	[AutoGenerateRBillNumber] [bit] NULL,
 CONSTRAINT [PK_sol_Agencies] PRIMARY KEY CLUSTERED 
(
	[AgencyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_Messages]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Messages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Messages](
	[MessageID] [int] IDENTITY(0,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](256) NULL,
 CONSTRAINT [PK_sol_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_Fees]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Fees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Fees](
	[FeeID] [int] IDENTITY(0,1) NOT NULL,
	[FeeDescription] [varchar](256) NULL,
	[FeeAmount] [money] NULL,
	[Percentage] [bit] NULL,
 CONSTRAINT [PK_Fees] PRIMARY KEY CLUSTERED 
(
	[FeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_ExpenseTypes]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_ExpenseTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_ExpenseTypes](
	[ExpenseTypeID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](256) NULL,
 CONSTRAINT [PK_sol_ExpenseTypes] PRIMARY KEY CLUSTERED 
(
	[ExpenseTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

--*********************************
--sol_Customers
--*********************************
/****** Object:  Table [dbo].[sol_Customers]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Customers](
	[CustomerID] [int] IDENTITY(0,1) NOT NULL,
	[CustomerCode] [varchar](10) NULL,
	[Name] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Address1] [varchar](250) NULL,
	[Address2] [varchar](250) NULL,
	[City] [varchar](100) NULL,
	[Province] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[IsActive] [bit] NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Notes] [nvarchar](512) NULL,
	[Password] [nvarchar](128) NOT NULL Default(''),
	[DepotID] [char](6) NOT NULL Default(''),			--not used for now, from solums settings
	[CardNumber] [nvarchar](50) NOT NULL Default(''),
	[CardTypeID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Qds_CardType](CardTypeID) Default(0),
	[SolumCustomer] [bit] NOT NULL Default(1),
	[QuickDropCustomer] [bit] NOT NULL Default(0),
	[IsNew] bit Default(1) NOT NULL,
 CONSTRAINT [PK_sol_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Sol_Customers]') AND name = N'FK_Sol_Customers_CardNumber')
CREATE NONCLUSTERED INDEX [FK_Sol_Customers_CardNumber] ON [dbo].[Sol_Customers] 
(
	[CardNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_Control]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Control]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Control](
	[ControlID] [int] NOT NULL,
	[BusinessName] [nvarchar](256) NULL,
	[LegalName] [nvarchar](256) NULL,
	[StoreNumber] [int] NULL,
	[Address] [nvarchar](256) NULL,
	[City] [nvarchar](56) NULL,
	[State] [nvarchar](56) NULL,
	[Country] [nvarchar](56) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[BusinessHoursFrom] [datetime] NULL,		--sunday
	[BusinessHoursTo] [datetime] NULL,			--sunday
	[IdFiscal1Name] [char](15) NULL,
	[IdFiscal1Value] [nvarchar](25) NULL,
	[IdFiscal2Name] [char](15) NULL,
	[IdFiscal2Value] [nvarchar](25) NULL,
	[WorkStationID] [int] NULL,
	[CustomerScreenMessageID] [int] NULL,
	[FrontStationMessageID] [int] NULL,
	[CashierRoutineMessageID] [int] NULL,
	[ReturnStationMessageID] [int] NULL,
	[CashierStationMessageID] [int] NULL,
	[ShippingStationMessageID] [int] NULL,
	[ReceiptMessageID] [int] NULL,
	[SMTPServer] [varchar](50) NULL,
	[SMTPPort] [int] NULL,
	[EmailAccount] [varchar](256) NULL,
	[EmailPassword] [varchar](128) NULL,
	[HistoryYears] [tinyint] NOT NULL,
	[FiscalYearInitialMonth] [tinyint] NOT NULL,
	[NumericKeyPadOn] [bit] NULL,
	[NumericKeyPadPosition] [tinyint] NULL,								-- 0 = right 1 = left
	[ReturnButtonExtra] [tinyint] NULL,									-- 0 = QuickCashOut 1 = Print Chit
	[Tax1Name] [nvarchar](64) NULL,
	[Tax1Rate] [decimal](18, 3) NULL,
	[Tax2Name] [nvarchar](64) NULL,
	[Tax2Rate] [decimal](18, 3) NULL,
	[DatabaseVersion] [decimal](18, 3) NULL,
	[Status] [char](1) NULL,
	[EmployeesListRefresh] [int] NULL,									-- in minutes
	[WebBrowserUrl] [nvarchar](512) NULL,
	[AutoGenerateTagNumber] [bit] NULL,									-- moved to agency table
	[AutoGenerateRBillNumber] [bit] NULL,
	[DefaultAgencyID] [int] NULL,										-- for Shipping
	[ChitTicketComplete] [tinyint] NULL,								-- 0 = Complete 1 = Order Number only
	[ChitTicketIncludeBarcode] [bit] NULL,
	[CashOutPrintingOverride] [bit] NULL,
	[WhiteBagID] [int] NULL,											-- for Straight BOL
	[BlueBagID] [int] NULL,												-- for Straight BOL
	[OneWayBagID] [int] NULL,											-- for Straight BOL
	[ABCRCPalletsID] [int] NULL,										-- for Straight BOL
	[CustomerScreenMonitor] [tinyint] NULL,								-- moved to local settings --monitor to use, 1 or higher
	[CategoryButtonsPanelBgColor] [int] NULL,
	[CategoryButtonsSnapToGrid] [bit] NULL,
	[BusinessHoursFromTue] [datetime] NULL,
	[BusinessHoursToTue] [datetime] NULL,
	[BusinessHoursFromWed] [datetime] NULL,
	[BusinessHoursToWed] [datetime] NULL,
	[BusinessHoursFromThu] [datetime] NULL,
	[BusinessHoursToThu] [datetime] NULL,
	[BusinessHoursFromFri] [datetime] NULL,
	[BusinessHoursToFri] [datetime] NULL,
	[BusinessHoursFromSat] [datetime] NULL,
	[BusinessHoursToSat] [datetime] NULL,
	[BusinessHoursFromSun] [datetime] NULL,
	[BusinessHoursToSun] [datetime] NULL,
	[ReturnsMaxQuantity] [int] NULL,
	[WebBrowserUpdateHistoryUrl] [nvarchar](512) NULL,
	[CashierMaxAmount] [money] NULL,
	[ComputerRole] [tinyint] NULL,										-- is a local setting now
	[SqlServerDate] [bit] NULL,											-- use sql server date-time instead of pc local date-time
	[VendorID] [int] NULL,
	[DefaultPlantID] [int] NULL,
	[DefaultCarrierID] [int] NULL,
	[ABCRCUserName] [nvarchar](256) NULL,
	[ABCRCPassword] [varchar](128) NULL,
	[ReceiptAmountBarcode] [bit] NULL,
	[IncludeSecurityCode] [bit] NULL,
	[RBillNumberBarcode] [bit] NULL,
	[SacCashTrayID] [int] NULL,											-- SAC's cash tray, if any (tengo que pasarlo a Sac-Settings, pendiente)
 CONSTRAINT [CG_PK_ControlID] PRIMARY KEY CLUSTERED 
(
	[ControlID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

UPDATE [Sol_Control] WITH (ROWLOCK)
SET [SacCashTrayID] = -1
GO


/****** Object:  Table [dbo].[sol_ContainerTypes]    Script Date: 20/03/2012 11:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_ContainerTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_ContainerTypes](
	[ContainerTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_sol_ContainerTypes] PRIMARY KEY CLUSTERED 
(
	[ContainerTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[sol_Containers]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Containers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Containers](
	[ContainerID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[ShortDescription] [varchar](50) NULL,
	[ContainerTypeID] [int] NULL,
	[ShippingContainerID] [int] NULL,					--ShippingContainerCRISID
	[ShippingContainerTypeID] [int] NULL,				--link to Sol_WS_ShippingContainerTypes table (later)
 CONSTRAINT [PK_sol_Containers] PRIMARY KEY CLUSTERED 
(
	[ContainerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

--********************
--Sol_WorkStations
--********************
/****** Object:  Table [dbo].[sol_WorkStations]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_WorkStations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_WorkStations](
	[WorkStationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[ConveyorID] [int] NOT NULL,
 CONSTRAINT [PK_sol_WorkStations] PRIMARY KEY CLUSTERED 
(
	[WorkStationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_StandardDozen]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_StandardDozen]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_StandardDozen](
	[StandardDozenID] [int] IDENTITY(0,1) NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_sol_StandardDozen] PRIMARY KEY CLUSTERED 
(
	[StandardDozenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

--*********************************
--Sol_Stage
--*********************************
/****** Object:  Table [dbo].[sol_Stage]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Stage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Stage](
	[StageID] [int] IDENTITY(1,1) NOT NULL,
	[ShipmentID] [int] NULL,
	[UserID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](256) NULL,
	[Date] [datetime] NULL,
	[TagNumber] [nvarchar](50) NULL,
	[ContainerID] [int] NULL,
	[ContainerDescription] [varchar](100) NULL,
	[ProductID] [int] NULL,
	[ProductName] [varchar](50) NULL,
	[Dozen] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
	[Remarks] [ntext] NULL,
	[Status] [char](1) NULL,								-- I-InProgress; P-Picked S-Shipped D - Void
	[DateClosed] [datetime] NOT NULL DEFAULT('1753-01-01 12:00:00.000'),
 CONSTRAINT [PK_sol_Stage] PRIMARY KEY CLUSTERED 
(
	[StageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[sol_Shipment]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Shipment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Shipment](
	[ShipmentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](256) NULL,
	[RBillNumber] [nvarchar](50) NULL,						-- Adjustments: same RBillNumber + 'A' at the end
	[Date] [datetime] NULL,
	[AgencyID] [int] NULL,
	[AgencyName] [varchar](50) NULL,
	[AgencyAddress1] [varchar](250) NULL,
	[AgencyAddress2] [varchar](250) NULL,
	[AgencyCity] [varchar](100) NULL,
	[AgencyProvince] [varchar](100) NULL,
	[AgencyCountry] [varchar](50) NULL,
	[AgencyPostalCode] [varchar](50) NULL,
	[Status] [char](1) NULL,								-- I-InProgress; S-Shipped; A - Adjustment; D - Void
	[CarrierID] [int] NULL,
	[PlantID] [int] NULL,
	[TrailerNumber] [nvarchar](50) NULL,
	[ProBillNumber] [nvarchar](50) NULL,
	[ShippedDate] [datetime] NULL,
	[SealNumber] [nvarchar](50) NULL,
	[LoadReference] [nvarchar](50) NULL,
	[eRBillTransmitted] [bit] NULL,
 CONSTRAINT [PK_sol_Shipment] PRIMARY KEY CLUSTERED 
(
	[ShipmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sol_Shipment]') AND name = N'FK_sol_Shipment_RBillNumber')
CREATE NONCLUSTERED INDEX [FK_sol_Shipment_RBillNumber] ON [dbo].[sol_Shipment] 
(
	[RBillNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sol_QueryDate]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_QueryDate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_QueryDate](
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_sol_QueryDate] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[sol_QuantityButtons]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_QuantityButtons]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_QuantityButtons](
	[QuantityButtonID] [int] IDENTITY(1,1) NOT NULL,
	[WorkStationID] [int] NOT NULL,								-- not used
	[ControlType] [tinyint] NULL,								-- 0 = 'Label' or 1 = 'Button'
	[Description] [varchar](50) NULL,
	[DefaultQuantity] [int] NULL,
	[CategoryID] [int] NOT NULL,								-- no se usa
	[LocationX] [int] NULL,
	[LocationY] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Font] [varchar](250) NULL,
	[FontStyle] [varchar](50) NULL,
	[ForeColor] [varchar](50) NULL,
	[BackColor] [varchar](50) NULL,
 CONSTRAINT [PK_sol_QuantityButtons] PRIMARY KEY CLUSTERED 
(
	[QuantityButtonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

--********************
--Sol_Products
--********************
/****** Object:  Table [dbo].[sol_Products]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Products]') AND type in (N'U'))
BEGIN
/* Updated to version 2.146 of Solum */
CREATE TABLE [dbo].[sol_Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProName] [varchar](50) NULL,
	[ProDescription] [varchar](50) NULL,
	[ProShortDescription] [varchar](50) NULL,
	[ProImage] [image] NULL,
	[AgencyID] [int] NULL,
	[MenuOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Price] [money] NULL,
	[CategoryID] [int] NULL,
	[RefundAmount] [money] NULL,									-- readonly, from Sol_Categories
	[HandlingCommissionAmount] [numeric](18, 6) NULL,
	[CommissionUnit] [int] NULL,
	[VafAmount] [numeric](18, 6) NULL,
	[FeeUnit] [int] NULL,
	[ContainerID] [int] NULL,
	[StandardDozenID] [int] NULL,
	[UPC] [varchar](50) NULL,
	[ProductCode] [varchar](50) NULL,								--ItemTypesCRISID
	[TypeId] [tinyint] NULL,										-- 0 or null = returns 1 = sales
	[Tax1Exempt] [bit] NULL,
	[Tax2Exempt] [bit] NULL,
	[MasterProductID] [int] NULL,
	[Weight] [numeric](8, 4) NULL,
	[Volume] [numeric](8, 4) NULL,
	[TargetQuantity] [int] NULL,
 CONSTRAINT [PK_sol_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE NONCLUSTERED INDEX Sol_Products_Index ON [dbo].Sol_Products(ProductCode)

END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_Payments]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Payments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentAmount] [float] NOT NULL,
	[date] [datetime] NULL,
	[UserID] [int] NULL,
	[UserName] [nvarchar](256) NULL,
	[CustomerID] [int] NULL,
	[ChequeNumber] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Address1] [varchar](250) NULL,
	[Address2] [varchar](250) NULL,
	[City] [varchar](100) NULL,
	[Province] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
 CONSTRAINT [PK_sol_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

--sol_Orders
/****** Object:  Table [dbo].[sol_Orders]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [char](1) NOT NULL,								-- R = Returns, S = Sales, A = Adjustment. Q=QuickDrop
	[WorkStationID] [int] NOT NULL,								-- not used
	[ComputerName] [varchar](50) NULL,
	[UserID] [uniqueidentifier] NULL,
	[UserName] [varchar](50) NULL,
	[Date] [datetime] NULL,										-- date and time of creation (open)
	[CashTrayID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Address1] [varchar](250) NULL,
	[Address2] [varchar](250) NULL,
	[City] [varchar](100) NULL,
	[Province] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[TotalAmount] [money] NULL,
	[DateClosed] [datetime] NULL,								-- date and time closed
	[DatePaid] [datetime] NULL,									-- date and time of payment
	[FeeID] [int] NOT NULL,
	[FeeAmount] [money] NULL,
	[Tax1Amount] [money] NULL,
	[Tax2Amount] [money] NULL,
	[Status] [char](1) NULL,									-- A = normal D = void  O = On account P = paid or processed, I = In Process QuickDrop
	[Reference] [varchar](100) NULL,
	[PaymentTypeID] [tinyint] NULL,								-- 0 the default for Not Paid, 1 for Cheque and 2 for cash
	[SecurityCode] [nvarchar](12) NULL,							-- second id for ATM (random integer length 3)
	[Comments] [nvarchar](256) NULL,
	[IsNew] bit Default(1) NOT NULL,
 CONSTRAINT [PK_sol_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[OrderType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sol_Orders]') AND name = N'FK_sol_Orders_SecCode')
CREATE NONCLUSTERED INDEX [FK_sol_Orders_SecCode] ON [dbo].[sol_Orders] 
(
	[OrderID] ASC,
	[SecurityCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[sol_Entries]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_Entries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_Entries](
	[EntryID] [int] IDENTITY(1,1) NOT NULL,
	[EntryType] [char](1) NOT NULL,								-- O - Open Cashier, F - Float  C - Close Cashier, E - Expenses
	[UserID] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[Date] [datetime] NULL,
	[CashTrayID] [int] NOT NULL,
	[ExpenseTypeID] [int] NOT NULL,
	[Amount] [money] NULL,
	[DiscrepancyAmount] [money] NULL,
 CONSTRAINT [PK_sol_Entries] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC,
	[EntryType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

--sol_CategoryButtons
/****** Object:  Table [dbo].[sol_CategoryButtons]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_CategoryButtons]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_CategoryButtons](
	[CategoryButtonID] [int] IDENTITY(1,1) NOT NULL,
	[WorkStationID] [int] NOT NULL,								-- not used
	[ControlType] [tinyint] NULL,								-- 0 = 'Label' 1 = 'Button' 2 = Button v2
	[Description] [varchar](50) NULL,
	[DefaultQuantity] [int] NULL,
	[CategoryID] [int] NOT NULL,
	[LocationX] [int] NULL,
	[LocationY] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Font] [varchar](250) NULL,
	[FontStyle] [varchar](50) NULL,
	[ForeColor] [varchar](50) NULL,
	[BackColor] [varchar](50) NULL,
	[ImageIndex] [int] NULL,									-- from a imageList
	[ImagePath] [varchar](255) NULL,							-- from a path
	[SubContainerMaxCount] [int] NULL,							-- threshold
	[SubContainerCounter] [int] NULL,
	[ImageSize] [tinyint] NULL,									-- 0 = Normal Size 1 = Double Width 2 = Double Height 3 = Double Size
	[SubContainerCountDown] [bit] null,
	[MaxCountPerLine] [int] NULL,								-- < 1 = defaults to MaxCountPerLine in Settings
	[ForeColorArgb] int NULL,
	[BackColorArgb] int NULL,
 CONSTRAINT [PK_sol_CategoryButtons] PRIMARY KEY CLUSTERED 
(
	[CategoryButtonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sol_EntriesDetail]    Script Date: 12/02/2011 09:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_EntriesDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_EntriesDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[EntryID] [int] NOT NULL,
	[EntryType] [char](1) NOT NULL,								-- O - Open Cashier, F - Float  C - Close Cashier, E - Expenses
	[CashID] [int] NOT NULL,									-- denomination
	[Count] [int] NULL,
 CONSTRAINT [PK_sol_EntriesDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sol_EntriesDetail]') AND name = N'FK_sol_EntriesDetail_EntryType')
CREATE NONCLUSTERED INDEX [FK_sol_EntriesDetail_EntryType] ON [dbo].[sol_EntriesDetail] 
(
	[EntryID] ASC,
	[EntryType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

--********************
--Sol_OrdersDetail
--********************
/****** Object:  Table [dbo].[sol_OrdersDetail]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sol_OrdersDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,								-- R = Returns, S = Sales, A = Adjustment
	[OrderType] [char](1) NOT NULL,
	[Date] [datetime] NULL,									-- date and time of creation (open)
	[CategoryID] [int] NOT NULL,
	[ProductID] [int] NULL,									-- no se usa por ahora
	[Description] [varchar](100) NULL,						-- from Category or Product
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Amount] [money] NOT NULL,
	[Status] [char](1) NULL,								-- A = normal D = void  O = On account P = paid or processed
	[CategoryButtonID] [int] NULL,
	[BagID] [int] NOT NULL CONSTRAINT [DF_Sol_OrdersDetail_BagId]  DEFAULT ((0)),
	[IsNew] bit Default(1) NOT NULL,
	[ConveyorID] [int] NULL,
	[StageID] [int] NULL,
 CONSTRAINT [PK_sol_OrdersDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]') AND name = N'FK_sol_OrdersDetail_OrderType')
CREATE NONCLUSTERED INDEX [FK_sol_OrdersDetail_OrderType] ON [dbo].[sol_OrdersDetail] 
(
	[OrderID] ASC,
	[OrderType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

--*********************************
--Indexes
--*********************************
--********************
--Vir_Conveyor
--********************
--********************
--Vir_ConveyorLink
--********************
--********************
--Vir_BagPosition
--********************
--********************
--Vir_StagingMethod
--********************


--*********************************
--Sol_Stage
--*********************************
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sol_Stage]') AND name = N'FK_sol_Stage_ShipmentId')
CREATE NONCLUSTERED INDEX [FK_sol_Stage_ShipmentId] ON [dbo].[sol_Stage] 
(
	[ShipmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sol_Stage]') AND name = N'FK_sol_Stage_TagNumber')
CREATE NONCLUSTERED INDEX [FK_sol_Stage_TagNumber] ON [dbo].[sol_Stage] 
(
	[TagNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO



--*********************************
--References
--*********************************

--********************
--Vir_Conveyor
--********************
--********************
--Vir_ConveyorLink
--********************
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Vir_ConveyorLink_BagPositionID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Vir_ConveyorLink]'))
ALTER TABLE [dbo].[Vir_ConveyorLink] WITH CHECK ADD  CONSTRAINT [FK_Vir_ConveyorLink_BagPositionID] FOREIGN KEY([BagPositionID])
REFERENCES [dbo].[Vir_BagPosition] ([BagPositionID])
ON DELETE CASCADE
GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Vir_ConveyorLink_BagPositionID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Vir_ConveyorLink]'))
--ALTER TABLE [dbo].[Vir_ConveyorLink] CHECK CONSTRAINT [FK_Vir_ConveyorLink_BagPositionID]
--GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys 
WHERE object_id = OBJECT_ID(N'[dbo].[FK_Vir_ConveyorLink_ConveyorID]') 
AND parent_object_id = OBJECT_ID(N'[dbo].[Vir_ConveyorLink]'))
ALTER TABLE [dbo].[Vir_ConveyorLink] WITH CHECK 
ADD CONSTRAINT [FK_Vir_ConveyorLink_ConveyorID] FOREIGN KEY([ConveyorID])
REFERENCES [dbo].[Vir_Conveyor] ([ConveyorID])
ON DELETE CASCADE
GO



--********************
--Vir_BagPosition
--********************

--********************
--Vir_StagingMethod
--********************


--********************
--Sol_WorkStations
--********************
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_WorkStations_ConveyorId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_WorkStations]'))
ALTER TABLE [dbo].[Sol_WorkStations]  WITH CHECK ADD CONSTRAINT [FK_Sol_WorkStations_ConveyorId] FOREIGN KEY([ConveyorId])
REFERENCES [dbo].[Vir_Conveyor] ([ConveyorId])
GO
--ALTER TABLE [dbo].[Sol_WorkStations] CHECK CONSTRAINT [FK_Sol_WorkStations_ConveyorId]
--GO

--********************
--Sol_Products
--********************


--Sac_Charity
ALTER TABLE [dbo].[Sac_Charity] ADD  CONSTRAINT [DF_Sac_Charity_CharityTypeID]  DEFAULT ((1)) FOR [CharityTypeID]
GO

ALTER TABLE [dbo].[Sac_Charity] ADD  CONSTRAINT [DF_Sac_Charity_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Sac_Charity] ADD  CONSTRAINT [DF_Sac_Charity_ButtonPosition]  DEFAULT ((0)) FOR [ButtonPosition]
GO


--Qds_Drop
/****** Object:  ForeignKey [FK_Qds_Drop_CustomerID]    Script Date: 12/11/2013 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Qds_Drop_CustomerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Qds_Drop]'))
ALTER TABLE [dbo].[Qds_Drop] WITH CHECK ADD  CONSTRAINT [FK_Qds_Drop_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[sol_Customers] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Qds_Drop_CustomerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Qds_Drop]'))
ALTER TABLE [dbo].[Qds_Drop] CHECK CONSTRAINT [FK_Qds_Drop_CustomerID]
GO

--/****** Object:  ForeignKey [FK_Qds_Drop_OrderID]    Script Date: 12/11/2013 09:07:28 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Qds_Drop_OrderID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Qds_Drop]'))
--ALTER TABLE [dbo].[Qds_Drop] WITH CHECK ADD  CONSTRAINT [FK_Qds_Drop_OrderID] FOREIGN KEY([OrderID], [OrderType])
--REFERENCES [dbo].[sol_Orders] ([OrderID], [OrderType])
--GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Qds_Drop_OrderID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Qds_Drop]'))
--ALTER TABLE [dbo].[Qds_Drop] CHECK CONSTRAINT [FK_Qds_Drop_OrderID]
--GO

/****** Object:  ForeignKey [FK_Sac_MoneyInventory_Sol_CashDenominations]    Script Date: 25/06/2013 08:45:27 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sac_MoneyInventory_Sol_CashDenominations]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sac_MoneyInventory]'))
--ALTER TABLE [dbo].[Sac_MoneyInventory]  WITH CHECK ADD  CONSTRAINT [FK_Sac_MoneyInventory_Sol_CashDenominations] FOREIGN KEY([CashID])
--REFERENCES [dbo].[Sol_CashDenominations] ([CashID])
--GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sac_MoneyInventory_Sol_CashDenominations]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sac_MoneyInventory]'))
--ALTER TABLE [dbo].[Sac_MoneyInventory] CHECK CONSTRAINT [FK_Sac_MoneyInventory_Sol_CashDenominations]
--GO


/****** Object:  ForeignKey [FK_Sol_BinCount_Sol_CategoryButtons]    Script Date: 22/05/2013 15:27:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_BinCount_Sol_CategoryButton]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_BinCount]'))
ALTER TABLE [dbo].[Sol_BinCount]  WITH CHECK ADD  CONSTRAINT [FK_Sol_BinCount_Sol_CategoryButtons] FOREIGN KEY([CategoryButtonID])
REFERENCES [dbo].[Sol_CategoryButtons] ([CategoryButtonID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_BinCount_Sol_CategoryButtons]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_BinCount]'))
ALTER TABLE [dbo].[Sol_BinCount] CHECK CONSTRAINT [FK_Sol_BinCount_Sol_CategoryButtons]
GO

/****** Object:  ForeignKey [FK_Sol_SupplyInventory_Sol_Shipment]    Script Date: 22/03/2012 12:27:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_SupplyInventory_Sol_Containers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_SupplyInventory]'))
ALTER TABLE [dbo].[Sol_SupplyInventory]  WITH CHECK ADD  CONSTRAINT [FK_Sol_SupplyInventory_Sol_Containers] FOREIGN KEY([ContainerID])
REFERENCES [dbo].[Sol_Containers] ([ContainerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_SupplyInventory_Sol_Containers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_SupplyInventory]'))
ALTER TABLE [dbo].[Sol_SupplyInventory] CHECK CONSTRAINT [FK_Sol_SupplyInventory_Sol_Containers]
GO

/****** Object:  ForeignKey [FK_Sol_Containers_Sol_ContainerTypes]    Script Date: 20/03/2012 12:07:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_Containers_Sol_ContainerTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_Containers]'))
	ALTER TABLE [dbo].[Sol_Containers]  WITH CHECK ADD  CONSTRAINT [FK_Sol_Containers_Sol_ContainerTypes] FOREIGN KEY([ContainerTypeID])
	REFERENCES [dbo].[Sol_ContainerTypes] ([ContainerTypeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_Containers_Sol_ContainerTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_Containers]'))
	ALTER TABLE [dbo].[Sol_Containers] CHECK CONSTRAINT [FK_Sol_Containers_Sol_ContainerTypes]
GO

/****** Object:  ForeignKey [FK_Sol_CategoryButtons_Sol_Categories]    Script Date: 12/02/2011 09:07:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_CategoryButtons_Sol_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_CategoryButtons]'))
ALTER TABLE [dbo].[sol_CategoryButtons]  WITH CHECK ADD  CONSTRAINT [FK_Sol_CategoryButtons_Sol_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Sol_Categories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_CategoryButtons_Sol_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_CategoryButtons]'))
ALTER TABLE [dbo].[sol_CategoryButtons] CHECK CONSTRAINT [FK_Sol_CategoryButtons_Sol_Categories]
GO


/****** Object:  ForeignKey [FK_Sol_CategoryButtons_Sol_WorkStations]    Script Date: 12/02/2011 09:07:27 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_CategoryButtons_Sol_WorkStations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_CategoryButtons]'))
--ALTER TABLE [dbo].[sol_CategoryButtons]  WITH CHECK ADD  CONSTRAINT [FK_Sol_CategoryButtons_Sol_WorkStations] FOREIGN KEY([WorkStationID])
--REFERENCES [dbo].[sol_WorkStations] ([WorkStationID])
--GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_CategoryButtons_Sol_WorkStations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_CategoryButtons]'))
--ALTER TABLE [dbo].[sol_CategoryButtons] CHECK CONSTRAINT [FK_Sol_CategoryButtons_Sol_WorkStations]
--GO

/****** Object:  ForeignKey [FK_sol_Entries_sol_CashTrays]    Script Date: 12/02/2011 09:07:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Entries_sol_CashTrays]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Entries]'))
ALTER TABLE [dbo].[sol_Entries]  WITH CHECK ADD  CONSTRAINT [FK_sol_Entries_sol_CashTrays] FOREIGN KEY([CashTrayID])
REFERENCES [dbo].[sol_CashTrays] ([CashTrayID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Entries_sol_CashTrays]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Entries]'))
ALTER TABLE [dbo].[sol_Entries] CHECK CONSTRAINT [FK_sol_Entries_sol_CashTrays]
GO
/****** Object:  ForeignKey [FK_sol_Entries_sol_ExpenseTypes]    Script Date: 12/02/2011 09:07:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Entries_sol_ExpenseTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Entries]'))
ALTER TABLE [dbo].[sol_Entries]  WITH CHECK ADD  CONSTRAINT [FK_sol_Entries_sol_ExpenseTypes] FOREIGN KEY([ExpenseTypeID])
REFERENCES [dbo].[sol_ExpenseTypes] ([ExpenseTypeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Entries_sol_ExpenseTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Entries]'))
ALTER TABLE [dbo].[sol_Entries] CHECK CONSTRAINT [FK_sol_Entries_sol_ExpenseTypes]
GO
/****** Object:  ForeignKey [FK_sol_EntriesDetail_sol_CashDenominations]    Script Date: 12/02/2011 09:07:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_EntriesDetail_sol_CashDenominations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_EntriesDetail]'))
ALTER TABLE [dbo].[sol_EntriesDetail]  WITH CHECK ADD  CONSTRAINT [FK_sol_EntriesDetail_sol_CashDenominations] FOREIGN KEY([CashID])
REFERENCES [dbo].[sol_CashDenominations] ([CashID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_EntriesDetail_sol_CashDenominations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_EntriesDetail]'))
ALTER TABLE [dbo].[sol_EntriesDetail] CHECK CONSTRAINT [FK_sol_EntriesDetail_sol_CashDenominations]
GO
/****** Object:  ForeignKey [FK_sol_EntriesDetail_sol_Entries]    Script Date: 12/02/2011 09:07:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_EntriesDetail_sol_Entries]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_EntriesDetail]'))
ALTER TABLE [dbo].[sol_EntriesDetail]  WITH CHECK ADD  CONSTRAINT [FK_sol_EntriesDetail_sol_Entries] FOREIGN KEY([EntryID], [EntryType])
REFERENCES [dbo].[sol_Entries] ([EntryID], [EntryType])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_EntriesDetail_sol_Entries]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_EntriesDetail]'))
ALTER TABLE [dbo].[sol_EntriesDetail] CHECK CONSTRAINT [FK_sol_EntriesDetail_sol_Entries]
GO
/****** Object:  ForeignKey [FK_sol_Orders_sol_CashTrays]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_CashTrays]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
ALTER TABLE [dbo].[sol_Orders]  WITH CHECK ADD  CONSTRAINT [FK_sol_Orders_sol_CashTrays] FOREIGN KEY([CashTrayID])
REFERENCES [dbo].[sol_CashTrays] ([CashTrayID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_CashTrays]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
ALTER TABLE [dbo].[sol_Orders] CHECK CONSTRAINT [FK_sol_Orders_sol_CashTrays]
GO
/****** Object:  ForeignKey [FK_sol_Orders_sol_Customers]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
ALTER TABLE [dbo].[sol_Orders]  WITH CHECK ADD  CONSTRAINT [FK_sol_Orders_sol_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[sol_Customers] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
ALTER TABLE [dbo].[sol_Orders] CHECK CONSTRAINT [FK_sol_Orders_sol_Customers]
GO
/****** Object:  ForeignKey [FK_sol_Orders_sol_Fees]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_Fees]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
ALTER TABLE [dbo].[sol_Orders]  WITH CHECK ADD  CONSTRAINT [FK_sol_Orders_sol_Fees] FOREIGN KEY([FeeID])
REFERENCES [dbo].[sol_Fees] ([FeeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_Fees]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
ALTER TABLE [dbo].[sol_Orders] CHECK CONSTRAINT [FK_sol_Orders_sol_Fees]
GO
/****** Object:  ForeignKey [FK_sol_Orders_sol_WorkStations]    Script Date: 12/02/2011 09:07:28 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_WorkStations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
--ALTER TABLE [dbo].[sol_Orders]  WITH CHECK ADD  CONSTRAINT [FK_sol_Orders_sol_WorkStations] FOREIGN KEY([WorkStationID])
--REFERENCES [dbo].[sol_WorkStations] ([WorkStationID])
--GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Orders_sol_WorkStations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
--ALTER TABLE [dbo].[sol_Orders] CHECK CONSTRAINT [FK_sol_Orders_sol_WorkStations]
--GO


/****** Object:  ForeignKey [FK_sol_OrdersDetail_Sol_Categories]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_OrdersDetail_Sol_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]'))
ALTER TABLE [dbo].[sol_OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_sol_OrdersDetail_Sol_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Sol_Categories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_OrdersDetail_Sol_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]'))
ALTER TABLE [dbo].[sol_OrdersDetail] CHECK CONSTRAINT [FK_sol_OrdersDetail_Sol_Categories]
GO

/****** Object:  ForeignKey [FK_sol_OrdersDetail_sol_Orders]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_OrdersDetail_sol_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]'))
ALTER TABLE [dbo].[sol_OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_sol_OrdersDetail_sol_Orders] FOREIGN KEY([OrderID], [OrderType])
REFERENCES [dbo].[sol_Orders] ([OrderID], [OrderType])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_OrdersDetail_sol_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]'))
ALTER TABLE [dbo].[sol_OrdersDetail] CHECK CONSTRAINT [FK_sol_OrdersDetail_sol_Orders]
GO
/****** Object:  ForeignKey [FK_sol_Payments_sol_Customers]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Payments_sol_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Payments]'))
ALTER TABLE [dbo].[sol_Payments]  WITH CHECK ADD  CONSTRAINT [FK_sol_Payments_sol_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[sol_Customers] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Payments_sol_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Payments]'))
ALTER TABLE [dbo].[sol_Payments] CHECK CONSTRAINT [FK_sol_Payments_sol_Customers]
GO
/****** Object:  ForeignKey [FK_sol_Products_sol_Agencies]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_sol_Agencies]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products]  WITH CHECK ADD  CONSTRAINT [FK_sol_Products_sol_Agencies] FOREIGN KEY([AgencyID])
REFERENCES [dbo].[sol_Agencies] ([AgencyID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_sol_Agencies]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products] CHECK CONSTRAINT [FK_sol_Products_sol_Agencies]
GO
/****** Object:  ForeignKey [FK_sol_Products_Sol_Categories]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_Sol_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products]  WITH CHECK ADD  CONSTRAINT [FK_sol_Products_Sol_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Sol_Categories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_Sol_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products] CHECK CONSTRAINT [FK_sol_Products_Sol_Categories]
GO
/****** Object:  ForeignKey [FK_sol_Products_sol_Containers]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_sol_Containers]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products]  WITH CHECK ADD  CONSTRAINT [FK_sol_Products_sol_Containers] FOREIGN KEY([ContainerID])
REFERENCES [dbo].[sol_Containers] ([ContainerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_sol_Containers]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products] CHECK CONSTRAINT [FK_sol_Products_sol_Containers]
GO
/****** Object:  ForeignKey [FK_sol_Products_sol_StandardDozen]    Script Date: 12/02/2011 09:07:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_sol_StandardDozen]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products]  WITH CHECK ADD  CONSTRAINT [FK_sol_Products_sol_StandardDozen] FOREIGN KEY([StandardDozenID])
REFERENCES [dbo].[sol_StandardDozen] ([StandardDozenID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_Products_sol_StandardDozen]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
ALTER TABLE [dbo].[sol_Products] CHECK CONSTRAINT [FK_sol_Products_sol_StandardDozen]
GO
/****** Object:  ForeignKey [FK_sol_QuantityButtons_Sol_WorkStations]    Script Date: 12/02/2011 09:07:28 ******/
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_QuantityButtons_Sol_WorkStations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_QuantityButtons]'))
--ALTER TABLE [dbo].[sol_QuantityButtons]  WITH CHECK ADD  CONSTRAINT [FK_sol_QuantityButtons_Sol_WorkStations] FOREIGN KEY([WorkStationID])
--REFERENCES [dbo].[sol_WorkStations] ([WorkStationID])
--GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sol_QuantityButtons_Sol_WorkStations]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_QuantityButtons]'))
--ALTER TABLE [dbo].[sol_QuantityButtons] CHECK CONSTRAINT [FK_sol_QuantityButtons_Sol_WorkStations]
--GO

/****** Object:  ForeignKey [FK_Sol_EmployeesLog_UserId]    Script Date: 07/08/2011 10:33:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sol_EmployeesLog_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_EmployeesLog]'))
ALTER TABLE [dbo].[Sol_EmployeesLog]  WITH CHECK ADD CONSTRAINT [FK_Sol_EmployeesLog_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Sol_Employees] ([UserId])
GO
ALTER TABLE [dbo].[Sol_EmployeesLog] CHECK CONSTRAINT [FK_Sol_EmployeesLog_UserId]
GO



--*********************************
--Defaults
--*********************************

--/****** Object:  Default [DF_Sol_OrdersDetail_BagId]    Script Date: 16/05/2014 10:07:27 ******/
--IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Sol_OrdersDetail_BagId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_OrdersDetail]'))
--Begin
--	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Sol_OrdersDetail_BagId]') AND type = 'D')
--	BEGIN
--		ALTER TABLE [dbo].[Sol_OrdersDetail] ADD  CONSTRAINT [DF_Sol_OrdersDetail_BagId]  DEFAULT ((0)) FOR [BagId]
--	END
--End
--GO

/****** Object:  Default [DF_Sol_OrdersDetail_CategoryButtonId]    Script Date: 22/05/2013 17:07:27 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Sol_OrdersDetail_CategoryButtonId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sol_OrdersDetail]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Sol_OrdersDetail_CategoryButtonId]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[Sol_OrdersDetail] ADD  CONSTRAINT [DF_Sol_OrdersDetail_CategoryButtonId]  DEFAULT ((-1)) FOR [CategoryButtonId]
	END
End
GO
/****** Object:  Default [DF_sol_Customers_IsActive]    Script Date: 12/02/2011 09:07:27 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Customers_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Customers]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Customers_IsActive]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Customers] ADD  CONSTRAINT [DF_sol_Customers_IsActive]  DEFAULT ((-1)) FOR [IsActive]
	END
End
GO
/****** Object:  Default [DF_sol_Entries_Amount]    Script Date: 12/02/2011 09:07:27 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Entries_Amount]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Entries]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Entries_Amount]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Entries] ADD  CONSTRAINT [DF_sol_Entries_Amount]  DEFAULT ((0)) FOR [Amount]
	END
End
GO
/****** Object:  Default [DF_sol_Entries_DiscrepancyAmount]    Script Date: 12/02/2011 09:07:27 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Entries_DiscrepancyAmount]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Entries]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Entries_DiscrepancyAmount]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Entries] ADD  CONSTRAINT [DF_sol_Entries_DiscrepancyAmount]  DEFAULT ((0)) FOR [DiscrepancyAmount]
	END
End
GO
/****** Object:  Default [DF_sol_EntriesDetail_Count]    Script Date: 12/02/2011 09:07:27 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_EntriesDetail_Count]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_EntriesDetail]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_EntriesDetail_Count]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_EntriesDetail] ADD  CONSTRAINT [DF_sol_EntriesDetail_Count]  DEFAULT ((0)) FOR [Count]
	END
End
GO

/****** Object:  Default [DF_sol_Orders_PaymentTypeID]    Script Date: 08/17/2012 16:00:00 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Orders_PaymentTypeID]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Orders_PaymentTypeID]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Orders] ADD  CONSTRAINT [DF_sol_Orders_PaymentTypeID]  DEFAULT ((0)) FOR [PaymentTypeID]
	END
End
GO


/****** Object:  Default [DF_sol_Orders_TotalAmount]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Orders_TotalAmount]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Orders_TotalAmount]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Orders] ADD  CONSTRAINT [DF_sol_Orders_TotalAmount]  DEFAULT ((0)) FOR [TotalAmount]
	END
End
GO
/****** Object:  Default [DF_sol_Orders_FeeAmount]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Orders_FeeAmount]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Orders]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Orders_FeeAmount]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Orders] ADD  CONSTRAINT [DF_sol_Orders_FeeAmount]  DEFAULT ((0)) FOR [FeeAmount]
	END
End
GO

/****** Object:  Default [DF_sol_OrdersDetail_Quantity]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_OrdersDetail_Quantity]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_OrdersDetail_Quantity]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_OrdersDetail] ADD  CONSTRAINT [DF_sol_OrdersDetail_Quantity]  DEFAULT ((0)) FOR [Quantity]
	END
End
GO
/****** Object:  Default [DF_sol_OrdersDetail_Amount]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_OrdersDetail_Amount]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_OrdersDetail]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_OrdersDetail_Amount]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_OrdersDetail] ADD  CONSTRAINT [DF_sol_OrdersDetail_Amount]  DEFAULT ((0)) FOR [Amount]
	END
End
GO
/****** Object:  Default [DF_sol_Payments_PaymentAmount]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Payments_PaymentAmount]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Payments]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Payments_PaymentAmount]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Payments] ADD  CONSTRAINT [DF_sol_Payments_PaymentAmount]  DEFAULT ((0)) FOR [PaymentAmount]
	END
End
GO
/****** Object:  Default [DF_sol_Products_IsActive]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Products_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Products_IsActive]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Products] ADD  CONSTRAINT [DF_sol_Products_IsActive]  DEFAULT ((-1)) FOR [IsActive]
	END
End
GO
/****** Object:  Default [DF_sol_Products_Price]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Products_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Products]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Products_Price]') AND type = 'D')
	BEGIN
	ALTER TABLE [dbo].[sol_Products] ADD  CONSTRAINT [DF_sol_Products_Price]  DEFAULT ((0)) FOR [Price]
	END
End
GO
/****** Object:  Default [DF_sol_Shipment_Status]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Shipment_Status]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Shipment]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Shipment_Status]') AND type = 'D')
BEGIN
	ALTER TABLE [dbo].[sol_Shipment] ADD  CONSTRAINT [DF_sol_Shipment_Status]  DEFAULT ('I') FOR [Status]
END
End
GO

--*********************************
--Sol_Stage
--*********************************
/****** Object:  Default [DF_sol_Stage_Quantity]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Stage_Quantity]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Stage]'))
Begin
	IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Stage_Quantity]') AND type = 'D')
	BEGIN
		ALTER TABLE [dbo].[sol_Stage] ADD  CONSTRAINT [DF_sol_Stage_Quantity]  DEFAULT ((0)) FOR [Quantity]
	END
End
GO
/****** Object:  Default [DF_sol_Stage_Price]    Script Date: 12/02/2011 09:07:28 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_sol_Stage_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[sol_Stage]'))
Begin
    IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_sol_Stage_Price]') AND type = 'D')
    BEGIN
        ALTER TABLE [dbo].[sol_Stage] ADD  CONSTRAINT [DF_sol_Stage_Price]  DEFAULT ((0)) FOR [Price]
    END
END
GO



--*********************************
--Views
--*********************************
/****** Object:  View [dbo].[vw_sol_Products_Unstaged_Part2]    Script Date: 12/02/2011 09:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_sol_Products_Unstaged_Part2]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[vw_sol_Products_Unstaged_Part2]
AS
SELECT      dbo.sol_QueryDate.UserName, dbo.Sol_Categories.CategoryID, SUM(dbo.sol_Stage.Dozen) AS TotalDozen
FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID INNER JOIN
                        dbo.sol_QueryDate ON dbo.sol_Stage.Date >= dbo.sol_QueryDate.DateFrom AND dbo.sol_Stage.Date <= dbo.sol_QueryDate.DateTo
                        RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
WHERE      (NOT (dbo.sol_Stage.Status = ''D''))
GROUP BY dbo.sol_QueryDate.UserName, dbo.Sol_Categories.CategoryID

'
GO
/****** Object:  View [dbo].[vw_sol_Products_Unstaged_Part1]    Script Date: 12/02/2011 09:29:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_sol_Products_Unstaged_Part1]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[vw_sol_Products_Unstaged_Part1]
AS
SELECT      dbo.Sol_Categories.CategoryID, dbo.sol_QueryDate.UserName, SUM(dbo.sol_OrdersDetail.Quantity) AS TotalQuantity
FROM        dbo.sol_OrdersDetail 
			INNER JOIN
			dbo.sol_QueryDate ON dbo.sol_OrdersDetail.Date >= dbo.sol_QueryDate.DateFrom AND dbo.sol_OrdersDetail.Date <= dbo.sol_QueryDate.DateTo 
            RIGHT OUTER JOIN
            dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID
WHERE      (NOT (dbo.sol_OrdersDetail.Status = ''D''))
GROUP BY dbo.Sol_Categories.CategoryID, dbo.sol_QueryDate.UserName

'
GO

