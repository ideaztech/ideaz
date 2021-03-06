
/**********************************************************************/
/* 2-CrearStoredProcedures.sql                                        */
/*                                                                    */
/* Copyright winsir, Inc. 2012                                        */
/* All Rights Reserved.                                               */
/**********************************************************************/

USE [Solum]
GO

--********************
--Vir_Conveyor
--SELECT CAST(scope_identity() AS int) 
--********************
/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_Conveyor_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_Conveyor_Insert]
GO

CREATE PROCEDURE [dbo].[Vir_Conveyor_Insert]
(
	@ConveyorDescription nvarchar(100)
)

AS

SET NOCOUNT ON

INSERT INTO [Vir_Conveyor]
(
	[ConveyorDescription]
)
VALUES
(
	@ConveyorDescription
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_Conveyor_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_Conveyor_Update]
GO

CREATE PROCEDURE [dbo].[Vir_Conveyor_Update]
(
	@ConveyorID int,
	@ConveyorDescription nvarchar(100)
)

AS

SET NOCOUNT ON

UPDATE [Vir_Conveyor] WITH (ROWLOCK)
SET [ConveyorDescription] = @ConveyorDescription
WHERE [ConveyorID] = @ConveyorID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_Conveyor_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_Conveyor_Delete]
GO

CREATE PROCEDURE [dbo].[Vir_Conveyor_Delete]
(
	@ConveyorID int
)

AS

SET NOCOUNT ON

DELETE FROM [Vir_Conveyor] WITH (ROWLOCK)
WHERE [ConveyorID] = @ConveyorID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_Conveyor_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_Conveyor_Select]
GO

CREATE PROCEDURE [dbo].[Vir_Conveyor_Select]
(
	@ConveyorID int
)

AS

SET NOCOUNT ON

SELECT [ConveyorID],
	[ConveyorDescription]
FROM [Vir_Conveyor]
WHERE [ConveyorID] = @ConveyorID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_Conveyor_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_Conveyor_SelectAll]
GO

CREATE PROCEDURE [dbo].[Vir_Conveyor_SelectAll]

AS

SET NOCOUNT ON

SELECT [ConveyorID],
	[ConveyorDescription]
FROM [Vir_Conveyor]
GO

--********************
--Vir_ConveyorLink
--SELECT CAST(scope_identity() AS int) 
--********************
/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_ConveyorLink_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_ConveyorLink_Insert]
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_Insert]
(
	@BagPositionID int,
	@ConveyorID int
)

AS

SET NOCOUNT ON

INSERT INTO [Vir_ConveyorLink]
(
	[BagPositionID],
	[ConveyorID]
)
VALUES
(
	@BagPositionID,
	@ConveyorID
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_ConveyorLink_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_ConveyorLink_Update]
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_Update]
(
	@ConveyorLinkID int,
	@BagPositionID int,
	@ConveyorID int
)

AS

SET NOCOUNT ON

UPDATE [Vir_ConveyorLink] WITH (ROWLOCK)
SET [BagPositionID] = @BagPositionID,
	[ConveyorID] = @ConveyorID
WHERE [ConveyorLinkID] = @ConveyorLinkID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_ConveyorLink_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_ConveyorLink_Delete]
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_Delete]
(
	@ConveyorLinkID int
)

AS

SET NOCOUNT ON

DELETE FROM [Vir_ConveyorLink] WITH (ROWLOCK)
WHERE [ConveyorLinkID] = @ConveyorLinkID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_ConveyorLink_DeleteAllByBagPositionID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_ConveyorLink_DeleteAllByBagPositionID]
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_DeleteAllByBagPositionID]
(
	@BagPositionID int
)

AS

SET NOCOUNT ON

DELETE FROM [Vir_ConveyorLink] WITH (ROWLOCK)
WHERE [BagPositionID] = @BagPositionID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_ConveyorLink_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_ConveyorLink_Select]
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_Select]
(
	@ConveyorLinkID int
)

AS

SET NOCOUNT ON

SELECT [ConveyorLinkID],
	[BagPositionID],
	[ConveyorID]
FROM [Vir_ConveyorLink]
WHERE [ConveyorLinkID] = @ConveyorLinkID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_ConveyorLink_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_ConveyorLink_SelectAll]
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_SelectAll]

AS

SET NOCOUNT ON

SELECT [ConveyorLinkID],
	[BagPositionID],
	[ConveyorID]
FROM [Vir_ConveyorLink]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_ConveyorLink_SelectAllByBagPositionID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_ConveyorLink_SelectAllByBagPositionID]
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_SelectAllByBagPositionID]
(
	@BagPositionID int
)

AS

SET NOCOUNT ON

SELECT [ConveyorLinkID],
	[BagPositionID],
	[ConveyorID]
FROM [Vir_ConveyorLink]
WHERE [BagPositionID] = @BagPositionID
GO

--********************
--Vir_BagPosition
--COMMENT OUT Vir_BagPosition_Update
--********************
/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_BagPosition_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_BagPosition_Insert]
GO

CREATE PROCEDURE [dbo].[Vir_BagPosition_Insert]
(
	@BagPositionID int,
	@BagPositionName nvarchar(100),
	@ProductID int,
	@CurrentStageID int,
	@CurrentQuantity int,
	@TargetQuantity int
)

AS

SET NOCOUNT ON

INSERT INTO [Vir_BagPosition]
(
	[BagPositionID],
	[BagPositionName],
	[ProductID],
	[CurrentStageID],
	[CurrentQuantity],
	[TargetQuantity]
)
VALUES
(
	@BagPositionID,
	@BagPositionName,
	@ProductID,
	@CurrentStageID,
	@CurrentQuantity,
	@TargetQuantity
)
GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_BagPosition_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[Vir_BagPosition_Update]
--GO

--CREATE PROCEDURE [dbo].[Vir_BagPosition_Update]
--(
--	@BagPositionID int,
--	@BagPositionName nvarchar(100),
--	@ProductID int,
--	@CurrentStageID int,
--	@CurrentQuantity int,
--	@TargetQuantity int
--)

--AS

--SET NOCOUNT ON

--UPDATE [Vir_BagPosition] WITH (ROWLOCK)
--SET [BagPositionName] = @BagPositionName,
--	[ProductID] = @ProductID,
--	[CurrentStageID] = @CurrentStageID,
--	[CurrentQuantity] = @CurrentQuantity,
--	[TargetQuantity] = @TargetQuantity
--WHERE [BagPositionID] = @BagPositionID
--GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_BagPosition_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_BagPosition_Delete]
GO

CREATE PROCEDURE [dbo].[Vir_BagPosition_Delete]
(
	@BagPositionID int
)

AS

SET NOCOUNT ON

DELETE FROM [Vir_BagPosition] WITH (ROWLOCK)
WHERE [BagPositionID] = @BagPositionID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_BagPosition_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_BagPosition_Select]
GO

CREATE PROCEDURE [dbo].[Vir_BagPosition_Select]
(
	@BagPositionID int
)

AS

SET NOCOUNT ON

SELECT [BagPositionID],
	[BagPositionName],
	[ProductID],
	[CurrentStageID],
	[CurrentQuantity],
	[TargetQuantity]
FROM [Vir_BagPosition]
WHERE [BagPositionID] = @BagPositionID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_BagPosition_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_BagPosition_SelectAll]
GO

CREATE PROCEDURE [dbo].[Vir_BagPosition_SelectAll]

AS

SET NOCOUNT ON

SELECT [BagPositionID],
	[BagPositionName],
	[ProductID],
	[CurrentStageID],
	[CurrentQuantity],
	[TargetQuantity]
FROM [Vir_BagPosition]
GO

--********************
--Vir_StagingMethod
--SELECT CAST(scope_identity() AS int) 
--********************
/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_StagingMethod_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_StagingMethod_Insert]
GO

CREATE PROCEDURE [dbo].[Vir_StagingMethod_Insert]
(
	@StagingMethodName nvarchar(100)
)

AS

SET NOCOUNT ON

INSERT INTO [Vir_StagingMethod]
(
	[StagingMethodName]
)
VALUES
(
	@StagingMethodName
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_StagingMethod_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_StagingMethod_Update]
GO

CREATE PROCEDURE [dbo].[Vir_StagingMethod_Update]
(
	@StagingMethodID int,
	@StagingMethodName nvarchar(100)
)

AS

SET NOCOUNT ON

UPDATE [Vir_StagingMethod] WITH (ROWLOCK)
SET [StagingMethodName] = @StagingMethodName
WHERE [StagingMethodID] = @StagingMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_StagingMethod_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_StagingMethod_Delete]
GO

CREATE PROCEDURE [dbo].[Vir_StagingMethod_Delete]
(
	@StagingMethodID int
)

AS

SET NOCOUNT ON

DELETE FROM [Vir_StagingMethod] WITH (ROWLOCK)
WHERE [StagingMethodID] = @StagingMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_StagingMethod_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_StagingMethod_Select]
GO

CREATE PROCEDURE [dbo].[Vir_StagingMethod_Select]
(
	@StagingMethodID int
)

AS

SET NOCOUNT ON

SELECT [StagingMethodID],
	[StagingMethodName]
FROM [Vir_StagingMethod]
WHERE [StagingMethodID] = @StagingMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vir_StagingMethod_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Vir_StagingMethod_SelectAll]
GO

CREATE PROCEDURE [dbo].[Vir_StagingMethod_SelectAll]

AS

SET NOCOUNT ON

SELECT [StagingMethodID],
	[StagingMethodName]
FROM [Vir_StagingMethod]
GO


/******************************************************************************
--Sac_Log
/* Updated to version 2.146 of Solum */

--SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Log_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Log_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_Log_Insert]
(
	@EntryType int,
	@OrderNumber int,
	@OrderAmount money,
	@Description nvarchar(150),
	@Quantityof50 int,
	@Quantityof20 int,
	@Quantityof10 int,
	@Quantityof5 int,
	@QuantityofToonie int,
	@QuantityofLoonie int,
	@QuantityofQuarter int,
	@QuantityofDime int,
	@QuantityofNickel int,
	@TotalValue money,
	@Remaining50 int,
	@Remaining20 int,
	@Remaining10 int,
	@Remaining5 int,
	@RemainingToonie int,
	@RemainingLoonie int,
	@RemainingQuarter int,
	@RemainingDime int,
	@RemainingNickel int,
	@TimeStamp datetime
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_Log]
(
	[EntryType],
	[OrderNumber],
	[OrderAmount],
	[Description],
	[Quantityof50],
	[Quantityof20],
	[Quantityof10],
	[Quantityof5],
	[QuantityofToonie],
	[QuantityofLoonie],
	[QuantityofQuarter],
	[QuantityofDime],
	[QuantityofNickel],
	[TotalValue],
	[Remaining50],
	[Remaining20],
	[Remaining10],
	[Remaining5],
	[RemainingToonie],
	[RemainingLoonie],
	[RemainingQuarter],
	[RemainingDime],
	[RemainingNickel],
	[TimeStamp]
)
VALUES
(
	@EntryType,
	@OrderNumber,
	@OrderAmount,
	@Description,
	@Quantityof50,
	@Quantityof20,
	@Quantityof10,
	@Quantityof5,
	@QuantityofToonie,
	@QuantityofLoonie,
	@QuantityofQuarter,
	@QuantityofDime,
	@QuantityofNickel,
	@TotalValue,
	@Remaining50,
	@Remaining20,
	@Remaining10,
	@Remaining5,
	@RemainingToonie,
	@RemainingLoonie,
	@RemainingQuarter,
	@RemainingDime,
	@RemainingNickel,
	@TimeStamp
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Log_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Log_Update]
GO

CREATE PROCEDURE [dbo].[Sac_Log_Update]
(
	@LogID int,
	@EntryType int,
	@OrderNumber int,
	@OrderAmount money,
	@Description nvarchar(150),
	@Quantityof50 int,
	@Quantityof20 int,
	@Quantityof10 int,
	@Quantityof5 int,
	@QuantityofToonie int,
	@QuantityofLoonie int,
	@QuantityofQuarter int,
	@QuantityofDime int,
	@QuantityofNickel int,
	@TotalValue money,
	@Remaining50 int,
	@Remaining20 int,
	@Remaining10 int,
	@Remaining5 int,
	@RemainingToonie int,
	@RemainingLoonie int,
	@RemainingQuarter int,
	@RemainingDime int,
	@RemainingNickel int,
	@TimeStamp datetime
)

AS

SET NOCOUNT ON

UPDATE [Sac_Log] WITH (ROWLOCK)
SET [EntryType] = @EntryType,
	[OrderNumber] = @OrderNumber,
	[OrderAmount] = @OrderAmount,
	[Description] = @Description,
	[Quantityof50] = @Quantityof50,
	[Quantityof20] = @Quantityof20,
	[Quantityof10] = @Quantityof10,
	[Quantityof5] = @Quantityof5,
	[QuantityofToonie] = @QuantityofToonie,
	[QuantityofLoonie] = @QuantityofLoonie,
	[QuantityofQuarter] = @QuantityofQuarter,
	[QuantityofDime] = @QuantityofDime,
	[QuantityofNickel] = @QuantityofNickel,
	[TotalValue] = @TotalValue,
	[Remaining50] = @Remaining50,
	[Remaining20] = @Remaining20,
	[Remaining10] = @Remaining10,
	[Remaining5] = @Remaining5,
	[RemainingToonie] = @RemainingToonie,
	[RemainingLoonie] = @RemainingLoonie,
	[RemainingQuarter] = @RemainingQuarter,
	[RemainingDime] = @RemainingDime,
	[RemainingNickel] = @RemainingNickel,
	[TimeStamp] = @TimeStamp
WHERE [LogID] = @LogID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Log_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Log_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_Log_Delete]
(
	@LogID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_Log] WITH (ROWLOCK)
WHERE [LogID] = @LogID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Log_DeleteAllByEntryType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Log_DeleteAllByEntryType]
GO

CREATE PROCEDURE [dbo].[Sac_Log_DeleteAllByEntryType]
(
	@EntryType int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_Log] WITH (ROWLOCK)
WHERE [EntryType] = @EntryType
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Log_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Log_Select]
GO

CREATE PROCEDURE [dbo].[Sac_Log_Select]
(
	@LogID int
)

AS

SET NOCOUNT ON

SELECT [LogID],
	[EntryType],
	[OrderNumber],
	[OrderAmount],
	[Description],
	[Quantityof50],
	[Quantityof20],
	[Quantityof10],
	[Quantityof5],
	[QuantityofToonie],
	[QuantityofLoonie],
	[QuantityofQuarter],
	[QuantityofDime],
	[QuantityofNickel],
	[TotalValue],
	[Remaining50],
	[Remaining20],
	[Remaining10],
	[Remaining5],
	[RemainingToonie],
	[RemainingLoonie],
	[RemainingQuarter],
	[RemainingDime],
	[RemainingNickel],
	[TimeStamp]
FROM [Sac_Log]
WHERE [LogID] = @LogID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Log_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Log_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_Log_SelectAll]

AS

SET NOCOUNT ON

SELECT [LogID],
	[EntryType],
	[OrderNumber],
	[OrderAmount],
	[Description],
	[Quantityof50],
	[Quantityof20],
	[Quantityof10],
	[Quantityof5],
	[QuantityofToonie],
	[QuantityofLoonie],
	[QuantityofQuarter],
	[QuantityofDime],
	[QuantityofNickel],
	[TotalValue],
	[Remaining50],
	[Remaining20],
	[Remaining10],
	[Remaining5],
	[RemainingToonie],
	[RemainingLoonie],
	[RemainingQuarter],
	[RemainingDime],
	[RemainingNickel],
	[TimeStamp]
FROM [Sac_Log]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Log_SelectAllByEntryType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Log_SelectAllByEntryType]
GO

CREATE PROCEDURE [dbo].[Sac_Log_SelectAllByEntryType]
(
	@EntryType int
)

AS

SET NOCOUNT ON

SELECT [LogID],
	[EntryType],
	[OrderNumber],
	[OrderAmount],
	[Description],
	[Quantityof50],
	[Quantityof20],
	[Quantityof10],
	[Quantityof5],
	[QuantityofToonie],
	[QuantityofLoonie],
	[QuantityofQuarter],
	[QuantityofDime],
	[QuantityofNickel],
	[TotalValue],
	[Remaining50],
	[Remaining20],
	[Remaining10],
	[Remaining5],
	[RemainingToonie],
	[RemainingLoonie],
	[RemainingQuarter],
	[RemainingDime],
	[RemainingNickel],
	[TimeStamp]
FROM [Sac_Log]
WHERE [EntryType] = @EntryType
GO


/******************************************************************************
--Sac_LogType
/* Updated to version 2.146 of Solum */
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_LogType_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_LogType_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_LogType_Insert]
(
	@LogTypeID int,
	@Description nvarchar(50)
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_LogType]
(
	[LogTypeID],
	[Description]
)
VALUES
(
	@LogTypeID,
	@Description
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_LogType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_LogType_Update]
GO

CREATE PROCEDURE [dbo].[Sac_LogType_Update]
(
	@LogTypeID int,
	@Description nvarchar(50)
)

AS

SET NOCOUNT ON

UPDATE [Sac_LogType] WITH (ROWLOCK)
SET [Description] = @Description
WHERE [LogTypeID] = @LogTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_LogType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_LogType_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_LogType_Delete]
(
	@LogTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_LogType] WITH (ROWLOCK)
WHERE [LogTypeID] = @LogTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_LogType_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_LogType_Select]
GO

CREATE PROCEDURE [dbo].[Sac_LogType_Select]
(
	@LogTypeID int
)

AS

SET NOCOUNT ON

SELECT [LogTypeID],
	[Description]
FROM [Sac_LogType]
WHERE [LogTypeID] = @LogTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_LogType_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_LogType_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_LogType_SelectAll]

AS

SET NOCOUNT ON

SELECT [LogTypeID],
	[Description]
FROM [Sac_LogType]
GO

/******************************************************************************
--Syn_UpdateLog
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Charity_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Charity_Insert]
GO

CREATE PROCEDURE [dbo].[Syc_UpdatesToSync]

AS

SELECT      dbo.syc_UpdateLog.TempID, dbo.syc_UpdateLog.TableName, dbo.syc_UpdateLog.IDName, dbo.syc_UpdateLog.IDValue, 
                        dbo.syc_UpdateLog.ColumnName, dbo.syc_UpdateLog.ColumnData, dbo.Qds_Settings.SetValue AS DepotID, 
                        dbo.Sol_Control.BusinessName AS DepotName
FROM          dbo.Qds_Settings CROSS JOIN
                        dbo.syc_UpdateLog CROSS JOIN
                        dbo.Sol_Control
WHERE      (dbo.Qds_Settings.Name = N'QuickDrop_DepotID')
GO

/******************************************************************************
--Sac_Charity
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Charity_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Charity_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_Charity_Insert]
(
	@CustomerID int,
	@ShortName nvarchar(50),
	@CharityDescription nvarchar(500),
	@CharityTypeID int,
	@RegistrationNumber nvarchar(50),
	@IsActive bit,
	@ButtonPosition tinyint,
	@Logo image
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_Charity]
(
	[CustomerID],
	[ShortName],
	[CharityDescription],
	[CharityTypeID],
	[RegistrationNumber],
	[IsActive],
	[ButtonPosition],
	[Logo]
)
VALUES
(
	@CustomerID,
	@ShortName,
	@CharityDescription,
	@CharityTypeID,
	@RegistrationNumber,
	@IsActive,
	@ButtonPosition,
	@Logo
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Charity_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Charity_Update]
GO

CREATE PROCEDURE [dbo].[Sac_Charity_Update]
(
	@CharityID int,
	@CustomerID int,
	@ShortName nvarchar(50),
	@CharityDescription nvarchar(500),
	@CharityTypeID int,
	@RegistrationNumber nvarchar(50),
	@IsActive bit,
	@ButtonPosition tinyint,
	@Logo image
)

AS

SET NOCOUNT ON

UPDATE [Sac_Charity] WITH (ROWLOCK)
SET [CustomerID] = @CustomerID,
	[ShortName] = @ShortName,
	[CharityDescription] = @CharityDescription,
	[CharityTypeID] = @CharityTypeID,
	[RegistrationNumber] = @RegistrationNumber,
	[IsActive] = @IsActive,
	[ButtonPosition] = @ButtonPosition,
	[Logo] = @Logo
WHERE [CharityID] = @CharityID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Charity_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Charity_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_Charity_Delete]
(
	@CharityID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_Charity] WITH (ROWLOCK)
WHERE [CharityID] = @CharityID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Charity_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Charity_Select]
GO

CREATE PROCEDURE [dbo].[Sac_Charity_Select]
(
	@CharityID int
)

AS

SET NOCOUNT ON

SELECT [CharityID],
	[CustomerID],
	[ShortName],
	[CharityDescription],
	[CharityTypeID],
	[RegistrationNumber],
	[IsActive],
	[ButtonPosition],
	[Logo]
FROM [Sac_Charity]
WHERE [CharityID] = @CharityID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Charity_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Charity_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_Charity_SelectAll]

AS

SET NOCOUNT ON

SELECT [CharityID],
	[CustomerID],
	[ShortName],
	[CharityDescription],
	[CharityTypeID],
	[RegistrationNumber],
	[IsActive],
	[ButtonPosition],
	[Logo]
FROM [Sac_Charity]
GO

/******************************************************************************
--Sac_CharityType
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_CharityType_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_CharityType_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_CharityType_Insert]
(
	@CharityTypeID int,
	@CharityType nvarchar(50)
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_CharityType]
(
	[CharityTypeID],
	[CharityType]
)
VALUES
(
	@CharityTypeID,
	@CharityType
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_CharityType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_CharityType_Update]
GO

CREATE PROCEDURE [dbo].[Sac_CharityType_Update]
(
	@CharityTypeID int,
	@CharityType nvarchar(50)
)

AS

SET NOCOUNT ON

UPDATE [Sac_CharityType] WITH (ROWLOCK)
SET [CharityType] = @CharityType
WHERE [CharityTypeID] = @CharityTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_CharityType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_CharityType_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_CharityType_Delete]
(
	@CharityTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_CharityType] WITH (ROWLOCK)
WHERE [CharityTypeID] = @CharityTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_CharityType_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_CharityType_Select]
GO

CREATE PROCEDURE [dbo].[Sac_CharityType_Select]
(
	@CharityTypeID int
)

AS

SET NOCOUNT ON

SELECT [CharityTypeID],
	[CharityType]
FROM [Sac_CharityType]
WHERE [CharityTypeID] = @CharityTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_CharityType_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_CharityType_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_CharityType_SelectAll]

AS

SET NOCOUNT ON

SELECT [CharityTypeID],
	[CharityType]
FROM [Sac_CharityType]
GO



/******************************************************************************
--Sac_Settings
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Settings_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Settings_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_Settings_Insert]
(
	@Name nvarchar(100),
	@Description nvarchar(2048),
	@SetValue sql_variant
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_Settings]
(
	[Name],
	[Description],
	[SetValue]
)
VALUES
(
	@Name,
	@Description,
	@SetValue
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Settings_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Settings_Update]
GO

CREATE PROCEDURE [dbo].[Sac_Settings_Update]
(
	@Name nvarchar(100),
	@Description nvarchar(2048),
	@SetValue sql_variant
)

AS

SET NOCOUNT ON

UPDATE [Sac_Settings] WITH (ROWLOCK)
SET [Description] = @Description,
	[SetValue] = @SetValue
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Settings_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Settings_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_Settings_Delete]
(
	@Name nvarchar(100)
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_Settings] WITH (ROWLOCK)
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Settings_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Settings_Select]
GO

CREATE PROCEDURE [dbo].[Sac_Settings_Select]
(
	@Name nvarchar(100)
)

AS

SET NOCOUNT ON

SELECT [Name],
	[Description],
	[SetValue]
FROM [Sac_Settings]
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Settings_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Settings_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_Settings_SelectAll]

AS

SET NOCOUNT ON

SELECT [Name],
	[Description],
	[SetValue]
FROM [Sac_Settings]
GO

/******************************************************************************
--Qds_Settings
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Settings_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Settings_Insert]
GO

CREATE PROCEDURE [dbo].[Qds_Settings_Insert]
(
	@Name nvarchar(100),
	@Description nvarchar(2048),
	@SetValue sql_variant
)

AS

SET NOCOUNT ON

INSERT INTO [Qds_Settings]
(
	[Name],
	[Description],
	[SetValue]
)
VALUES
(
	@Name,
	@Description,
	@SetValue
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Settings_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Settings_Update]
GO

CREATE PROCEDURE [dbo].[Qds_Settings_Update]
(
	@Name nvarchar(100),
	@Description nvarchar(2048),
	@SetValue sql_variant
)

AS

SET NOCOUNT ON

UPDATE [Qds_Settings] WITH (ROWLOCK)
SET [Description] = @Description,
	[SetValue] = @SetValue
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Settings_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Settings_Delete]
GO

CREATE PROCEDURE [dbo].[Qds_Settings_Delete]
(
	@Name nvarchar(100)
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_Settings] WITH (ROWLOCK)
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Settings_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Settings_Select]
GO

CREATE PROCEDURE [dbo].[Qds_Settings_Select]
(
	@Name nvarchar(100)
)

AS

SET NOCOUNT ON

SELECT [Name],
	[Description],
	[SetValue]
FROM [Qds_Settings]
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Settings_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Settings_SelectAll]
GO

CREATE PROCEDURE [dbo].[Qds_Settings_SelectAll]

AS

SET NOCOUNT ON

SELECT [Name],
	[Description],
	[SetValue]
FROM [Qds_Settings]
GO

/******************************************************************************
--Qds_Bag
SELECT CAST(scope_identity() AS int) 
Comment out Qds_Bag_Update
comment all [IsNew] references
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Bag_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Bag_Insert]
GO

CREATE PROCEDURE [dbo].[Qds_Bag_Insert]
(
	@DropID int,
	@BagEstimateUnderLitre int,
	@BagEstimateOverLitre int,
	@DateEntered datetime,
	@DateAccepted datetime,
	@DateCounted datetime,
	@DatePaid datetime,
	@DepotID char(6),
	@DatePrinted datetime
	--, @IsNew bit
)

AS

SET NOCOUNT ON

INSERT INTO [Qds_Bag]
(
	[DropID],
	[BagEstimateUnderLitre],
	[BagEstimateOverLitre],
	[DateEntered],
	[DateAccepted],
	[DateCounted],
	[DatePaid],
	[DepotID],
	[DatePrinted]
	--, [IsNew]
)
VALUES
(
	@DropID,
	@BagEstimateUnderLitre,
	@BagEstimateOverLitre,
	@DateEntered,
	@DateAccepted,
	@DateCounted,
	@DatePaid,
	@DepotID,
	@DatePrinted
	--, @IsNew
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Bag_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[Qds_Bag_Update]
--GO

--CREATE PROCEDURE [dbo].[Qds_Bag_Update]
--(
--	@BagID int,
--	@DropID int,
--	@BagEstimateUnderLitre int,
--	@BagEstimateOverLitre int,
--	@DateEntered datetime,
--	@DateAccepted datetime,
--	@DateCounted datetime,
--	@DatePaid datetime,
--	@DepotID char(6),
--	@DatePrinted datetime,
--	@IsNew bit
--)

--AS

--SET NOCOUNT ON

--UPDATE [Qds_Bag] WITH (ROWLOCK)
--SET [DropID] = @DropID,
--	[BagEstimateUnderLitre] = @BagEstimateUnderLitre,
--	[BagEstimateOverLitre] = @BagEstimateOverLitre,
--	[DateEntered] = @DateEntered,
--	[DateAccepted] = @DateAccepted,
--	[DateCounted] = @DateCounted,
--	[DatePaid] = @DatePaid,
--	[DepotID] = @DepotID,
--	[DatePrinted] = @DatePrinted,
--	[IsNew] = @IsNew
--WHERE [BagID] = @BagID
--GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Bag_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Bag_Delete]
GO

CREATE PROCEDURE [dbo].[Qds_Bag_Delete]
(
	@BagID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_Bag] WITH (ROWLOCK)
WHERE [BagID] = @BagID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Bag_DeleteAllByDropID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Bag_DeleteAllByDropID]
GO

CREATE PROCEDURE [dbo].[Qds_Bag_DeleteAllByDropID]
(
	@DropID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_Bag] WITH (ROWLOCK)
WHERE [DropID] = @DropID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Bag_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Bag_Select]
GO

CREATE PROCEDURE [dbo].[Qds_Bag_Select]
(
	@BagID int
)

AS

SET NOCOUNT ON

SELECT [BagID],
	[DropID],
	[BagEstimateUnderLitre],
	[BagEstimateOverLitre],
	[DateEntered],
	[DateAccepted],
	[DateCounted],
	[DatePaid],
	[DepotID],
	[DatePrinted]
	--, 	[IsNew]
FROM [Qds_Bag]
WHERE [BagID] = @BagID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Bag_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Bag_SelectAll]
GO

CREATE PROCEDURE [dbo].[Qds_Bag_SelectAll]

AS

SET NOCOUNT ON

SELECT [BagID],
	[DropID],
	[BagEstimateUnderLitre],
	[BagEstimateOverLitre],
	[DateEntered],
	[DateAccepted],
	[DateCounted],
	[DatePaid],
	[DepotID],
	[DatePrinted]
	--, 	[IsNew]
FROM [Qds_Bag]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Bag_SelectAllByDropID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Bag_SelectAllByDropID]
GO

CREATE PROCEDURE [dbo].[Qds_Bag_SelectAllByDropID]
(
	@DropID int
)

AS

SET NOCOUNT ON

SELECT [BagID],
	[DropID],
	[BagEstimateUnderLitre],
	[BagEstimateOverLitre],
	[DateEntered],
	[DateAccepted],
	[DateCounted],
	[DatePaid],
	[DepotID],
	[DatePrinted]
	--, 	[IsNew]
FROM [Qds_Bag]
WHERE [DropID] = @DropID
GO

/******************************************************************************
--Qds_CardType
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_CardType_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_CardType_Insert]
GO

CREATE PROCEDURE [dbo].[Qds_CardType_Insert]
(
	@CardType nvarchar(100)
)

AS

SET NOCOUNT ON

INSERT INTO [Qds_CardType]
(
	[CardType]
)
VALUES
(
	@CardType
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_CardType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_CardType_Update]
GO

CREATE PROCEDURE [dbo].[Qds_CardType_Update]
(
	@CardTypeID int,
	@CardType nvarchar(100)
)

AS

SET NOCOUNT ON

UPDATE [Qds_CardType] WITH (ROWLOCK)
SET [CardType] = @CardType
WHERE [CardTypeID] = @CardTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_CardType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_CardType_Delete]
GO

CREATE PROCEDURE [dbo].[Qds_CardType_Delete]
(
	@CardTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_CardType] WITH (ROWLOCK)
WHERE [CardTypeID] = @CardTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_CardType_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_CardType_Select]
GO

CREATE PROCEDURE [dbo].[Qds_CardType_Select]
(
	@CardTypeID int
)

AS

SET NOCOUNT ON

SELECT [CardTypeID],
	[CardType]
FROM [Qds_CardType]
WHERE [CardTypeID] = @CardTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_CardType_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_CardType_SelectAll]
GO

CREATE PROCEDURE [dbo].[Qds_CardType_SelectAll]

AS

SET NOCOUNT ON

SELECT [CardTypeID],
	[CardType]
FROM [Qds_CardType]
GO

/******************************************************************************
--Qds_Drop
SELECT CAST(scope_identity() AS int) 
Comment out Qds_Drop_Update
comment all [IsNew] references
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_Insert]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_Insert]
(
	@CustomerID int,
	@NumberOfBags int,
	@PaymentMethodID int,
	@DepotID char(6),
	@OrderID int,
	@OrderType char(1)
	--, 	@IsNew bit
)

AS

SET NOCOUNT ON

INSERT INTO [Qds_Drop]
(
	[CustomerID],
	[NumberOfBags],
	[PaymentMethodID],
	[DepotID],
	[OrderID],
	[OrderType] 
	--, 	[IsNew]
)
VALUES
(
	@CustomerID,
	@NumberOfBags,
	@PaymentMethodID,
	@DepotID,
	@OrderID,
	@OrderType
	--, 	@IsNew
)

SELECT CAST(scope_identity() AS int) 
GO

--/******************************************************************************
--******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[Qds_Drop_Update]
--GO

--CREATE PROCEDURE [dbo].[Qds_Drop_Update]
--(
--	@DropID int,
--	@CustomerID int,
--	@NumberOfBags int,
--	@PaymentMethodID int,
--	@DepotID char(6),
--	@OrderID int,
--	@OrderType char(1),
--	@IsNew bit
--)

--AS

--SET NOCOUNT ON

--UPDATE [Qds_Drop] WITH (ROWLOCK)
--SET [CustomerID] = @CustomerID,
--	[NumberOfBags] = @NumberOfBags,
--	[PaymentMethodID] = @PaymentMethodID,
--	[DepotID] = @DepotID,
--	[OrderID] = @OrderID,
--	[OrderType] = @OrderType,
--	[IsNew] = @IsNew
--WHERE [DropID] = @DropID
--GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_Delete]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_Delete]
(
	@DropID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_Drop] WITH (ROWLOCK)
WHERE [DropID] = @DropID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_DeleteAllByPaymentMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_DeleteAllByPaymentMethodID]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_DeleteAllByPaymentMethodID]
(
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_Drop] WITH (ROWLOCK)
WHERE [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_DeleteAllByCustomerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_DeleteAllByCustomerID]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_DeleteAllByCustomerID]
(
	@CustomerID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_Drop] WITH (ROWLOCK)
WHERE [CustomerID] = @CustomerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_Select]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_Select]
(
	@DropID int
)

AS

SET NOCOUNT ON

SELECT [DropID],
	[CustomerID],
	[NumberOfBags],
	[PaymentMethodID],
	[DepotID],
	[OrderID],
	[OrderType]
	--, [IsNew]
FROM [Qds_Drop]
WHERE [DropID] = @DropID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_SelectAll]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_SelectAll]

AS

SET NOCOUNT ON

SELECT [DropID],
	[CustomerID],
	[NumberOfBags],
	[PaymentMethodID],
	[DepotID],
	[OrderID],
	[OrderType]
	--, 	[IsNew]
FROM [Qds_Drop]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_SelectAllByPaymentMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_SelectAllByPaymentMethodID]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_SelectAllByPaymentMethodID]
(
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

SELECT [DropID],
	[CustomerID],
	[NumberOfBags],
	[PaymentMethodID],
	[DepotID],
	[OrderID],
	[OrderType] 
	--, 	[IsNew]
FROM [Qds_Drop]
WHERE [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_Drop_SelectAllByCustomerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_Drop_SelectAllByCustomerID]
GO

CREATE PROCEDURE [dbo].[Qds_Drop_SelectAllByCustomerID]
(
	@CustomerID int
)

AS

SET NOCOUNT ON

SELECT [DropID],
	[CustomerID],
	[NumberOfBags],
	[PaymentMethodID],
	[DepotID],
	[OrderID],
	[OrderType] 
	--, 	[IsNew]
FROM [Qds_Drop]
WHERE [CustomerID] = @CustomerID
GO

/******************************************************************************
--Qds_PaymentMethod
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethod_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethod_Insert]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethod_Insert]
(
	@PaymentMethod nvarchar(100)
)

AS

SET NOCOUNT ON

INSERT INTO [Qds_PaymentMethod]
(
	[PaymentMethod]
)
VALUES
(
	@PaymentMethod
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethod_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethod_Update]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethod_Update]
(
	@PaymentMethodID int,
	@PaymentMethod nvarchar(100)
)

AS

SET NOCOUNT ON

UPDATE [Qds_PaymentMethod] WITH (ROWLOCK)
SET [PaymentMethod] = @PaymentMethod
WHERE [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethod_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethod_Delete]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethod_Delete]
(
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_PaymentMethod] WITH (ROWLOCK)
WHERE [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethod_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethod_Select]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethod_Select]
(
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

SELECT [PaymentMethodID],
	[PaymentMethod]
FROM [Qds_PaymentMethod]
WHERE [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethod_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethod_SelectAll]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethod_SelectAll]

AS

SET NOCOUNT ON

SELECT [PaymentMethodID],
	[PaymentMethod]
FROM [Qds_PaymentMethod]
GO

/******************************************************************************
--Qds_PaymentMethodAvailableByDepot
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethodAvailableByDepot_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethodAvailableByDepot_Insert]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethodAvailableByDepot_Insert]
(
	@DepotID char(6),
	@PaymentMethodID int,
	@DepotDefault bit
)

AS

SET NOCOUNT ON

INSERT INTO [Qds_PaymentMethodAvailableByDepot]
(
	[DepotID],
	[PaymentMethodID],
	[DepotDefault]
)
VALUES
(
	@DepotID,
	@PaymentMethodID,
	@DepotDefault
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethodAvailableByDepot_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethodAvailableByDepot_Update]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethodAvailableByDepot_Update]
(
	@DepotID char(6),
	@PaymentMethodID int,
	@DepotDefault bit
)

AS

SET NOCOUNT ON

UPDATE [Qds_PaymentMethodAvailableByDepot] WITH (ROWLOCK)
SET [DepotDefault] = @DepotDefault
WHERE [DepotID] = @DepotID	AND [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethodAvailableByDepot_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethodAvailableByDepot_Delete]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethodAvailableByDepot_Delete]
(
	@DepotID char(6),
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_PaymentMethodAvailableByDepot] WITH (ROWLOCK)
WHERE [DepotID] = @DepotID
	AND [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethodAvailableByDepot_DeleteAllByPaymentMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethodAvailableByDepot_DeleteAllByPaymentMethodID]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethodAvailableByDepot_DeleteAllByPaymentMethodID]
(
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

DELETE FROM [Qds_PaymentMethodAvailableByDepot] WITH (ROWLOCK)
WHERE [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethodAvailableByDepot_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethodAvailableByDepot_Select]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethodAvailableByDepot_Select]
(
	@DepotID char(6),
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

SELECT [DepotID],
	[PaymentMethodID],
	[DepotDefault]
FROM [Qds_PaymentMethodAvailableByDepot]
WHERE [DepotID] = @DepotID
	AND [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethodAvailableByDepot_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethodAvailableByDepot_SelectAll]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethodAvailableByDepot_SelectAll]

AS

SET NOCOUNT ON

SELECT [DepotID],
	[PaymentMethodID],
	[DepotDefault]
FROM [Qds_PaymentMethodAvailableByDepot]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Qds_PaymentMethodAvailableByDepot_SelectAllByPaymentMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Qds_PaymentMethodAvailableByDepot_SelectAllByPaymentMethodID]
GO

CREATE PROCEDURE [dbo].[Qds_PaymentMethodAvailableByDepot_SelectAllByPaymentMethodID]
(
	@PaymentMethodID int
)

AS

SET NOCOUNT ON

SELECT [DepotID],
	[PaymentMethodID],
	[DepotDefault]
FROM [Qds_PaymentMethodAvailableByDepot]
WHERE [PaymentMethodID] = @PaymentMethodID
GO

/******************************************************************************
--Sol_Settings
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Settings_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Settings_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_Settings_Insert]
(
	@Name nvarchar(100),
	@Description nvarchar(2048),
	@SetValue sql_variant
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_Settings]
(
	[Name],
	[Description],
	[SetValue]
)
VALUES
(
	@Name,
	@Description,
	@SetValue
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Settings_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Settings_Update]
GO

CREATE PROCEDURE [dbo].[Sol_Settings_Update]
(
	@Name nvarchar(100),
	@Description nvarchar(2048),
	@SetValue sql_variant
)

AS

SET NOCOUNT ON

UPDATE [Sol_Settings] WITH (ROWLOCK)
SET [Description] = @Description,
	[SetValue] = @SetValue
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Settings_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Settings_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_Settings_Delete]
(
	@Name nvarchar(100)
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_Settings] WITH (ROWLOCK)
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Settings_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Settings_Select]
GO

CREATE PROCEDURE [dbo].[Sol_Settings_Select]
(
	@Name nvarchar(100)
)

AS

SET NOCOUNT ON

SELECT [Name],
	[Description],
	[SetValue]
FROM [Sol_Settings]
WHERE [Name] = @Name
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Settings_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Settings_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_Settings_SelectAll]

AS

SET NOCOUNT ON

SELECT [Name],
	[Description],
	[SetValue]
FROM [Sol_Settings]
GO

/******************************************************************************
--Sol_OrderCardLink
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLink_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLink_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLink_Insert]
(
	@CardNumber nvarchar(50),
	@OrderID int
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_OrderCardLink]
(
	[CardNumber],
	[OrderID]
)
VALUES
(
	@CardNumber,
	@OrderID
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLink_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLink_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLink_Delete]
(
	@CardNumber nvarchar(50),
	@OrderID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_OrderCardLink] WITH (ROWLOCK)
WHERE [CardNumber] = @CardNumber
	AND [OrderID] = @OrderID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLink_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLink_Select]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLink_Select]
(
	@CardNumber nvarchar(50),
	@OrderID int
)

AS

SET NOCOUNT ON

SELECT [CardNumber],
	[OrderID]
FROM [Sol_OrderCardLink]
WHERE [CardNumber] = @CardNumber
	AND [OrderID] = @OrderID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLink_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLink_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLink_SelectAll]

AS

SET NOCOUNT ON

SELECT [CardNumber],
	[OrderID]
FROM [Sol_OrderCardLink]
GO
/******************************************************************************
--Sol_OrderCardLog
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLog_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLog_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLog_Insert]
(
	@CardNumber nvarchar(50),
	@OrderID int,
	@DateAdded datetime,
	@DatePaid datetime
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_OrderCardLog]
(
	[CardNumber],
	[OrderID],
	[DateAdded],
	[DatePaid]
)
VALUES
(
	@CardNumber,
	@OrderID,
	@DateAdded,
	@DatePaid
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLog_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLog_Update]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLog_Update]
(
	@LogID int,
	@CardNumber nvarchar(50),
	@OrderID int,
	@DateAdded datetime,
	@DatePaid datetime
)

AS

SET NOCOUNT ON

UPDATE [Sol_OrderCardLog] WITH (ROWLOCK)
SET --[LogID] = @LogID,
	[DateAdded] = @DateAdded,
	[DatePaid] = @DatePaid
WHERE [CardNumber] = @CardNumber	AND [OrderID] = @OrderID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLog_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLog_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLog_Delete]
(
	@CardNumber nvarchar(50),
	@OrderID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_OrderCardLog] WITH (ROWLOCK)
WHERE [CardNumber] = @CardNumber
	AND [OrderID] = @OrderID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLog_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLog_Select]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLog_Select]
(
	@CardNumber nvarchar(50),
	@OrderID int
)

AS

SET NOCOUNT ON

SELECT [LogID],
	[CardNumber],
	[OrderID],
	[DateAdded],
	[DatePaid]
FROM [Sol_OrderCardLog]
WHERE [CardNumber] = @CardNumber
	AND [OrderID] = @OrderID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLog_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLog_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLog_SelectAll]

AS

SET NOCOUNT ON

SELECT [LogID],
	[CardNumber],
	[OrderID],
	[DateAdded],
	[DatePaid]
FROM [Sol_OrderCardLog]
GO

/******************************************************************************
--Sol_AutoNumbers
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_AutoNumbers_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_AutoNumbers_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_AutoNumbers_Insert]
(
	@AgencyID int,
	@FolioID int,
	@TagNumber int,
	@RBillNumber int
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_AutoNumbers]
(
	[AgencyID],
	[FolioID],
	[TagNumber],
	[RBillNumber]
)
VALUES
(
	@AgencyID,
	@FolioID,
	@TagNumber,
	@RBillNumber
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_AutoNumbers_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_AutoNumbers_Update]
GO

CREATE PROCEDURE [dbo].[Sol_AutoNumbers_Update]
(
	@AgencyID int,
	@FolioID int,
	@TagNumber int,
	@RBillNumber int
)

AS

SET NOCOUNT ON

UPDATE [Sol_AutoNumbers] WITH (ROWLOCK)
SET [TagNumber] = @TagNumber,
	[RBillNumber] = @RBillNumber
WHERE [AgencyID] = @AgencyID	AND [FolioID] = @FolioID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_AutoNumbers_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_AutoNumbers_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_AutoNumbers_Delete]
(
	@AgencyID int,
	@FolioID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_AutoNumbers] WITH (ROWLOCK)
WHERE [AgencyID] = @AgencyID
	AND [FolioID] = @FolioID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_AutoNumbers_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_AutoNumbers_Select]
GO

CREATE PROCEDURE [dbo].[Sol_AutoNumbers_Select]
(
	@AgencyID int,
	@FolioID int
)

AS

SET NOCOUNT ON

SELECT [AgencyID],
	[FolioID],
	[TagNumber],
	[RBillNumber]
FROM [Sol_AutoNumbers]
WHERE [AgencyID] = @AgencyID
	AND [FolioID] = @FolioID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_AutoNumbers_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_AutoNumbers_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_AutoNumbers_SelectAll]

AS

SET NOCOUNT ON

SELECT [AgencyID],
	[FolioID],
	[TagNumber],
	[RBillNumber]
FROM [Sol_AutoNumbers]
GO

/******************************************************************************
--Sac_ClientNames
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_ClientNames_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_ClientNames_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_ClientNames_Insert]
(
	@ClientID nvarchar(50),
	@CashTrayID int,
	@CoinAmountInventory money
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_ClientNames]
(
	[ClientID],
	[CashTrayID],
	[CoinAmountInventory]
)
VALUES
(
	@ClientID,
	@CashTrayID,
	@CoinAmountInventory
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_ClientNames_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_ClientNames_Update]
GO

CREATE PROCEDURE [dbo].[Sac_ClientNames_Update]
(
	@ClientID nvarchar(50),
	@CashTrayID int,
	@CoinAmountInventory money
)

AS

SET NOCOUNT ON

UPDATE [Sac_ClientNames] WITH (ROWLOCK)
SET [CashTrayID] = @CashTrayID,
	[CoinAmountInventory] = @CoinAmountInventory
WHERE [ClientID] = @ClientID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_ClientNames_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_ClientNames_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_ClientNames_Delete]
(
	@ClientID nvarchar(50)
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_ClientNames] WITH (ROWLOCK)
WHERE [ClientID] = @ClientID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_ClientNames_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_ClientNames_Select]
GO

CREATE PROCEDURE [dbo].[Sac_ClientNames_Select]
(
	@ClientID nvarchar(50)
)

AS

SET NOCOUNT ON

SELECT [ClientID],
	[CashTrayID],
	[CoinAmountInventory]
FROM [Sac_ClientNames]
WHERE [ClientID] = @ClientID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_ClientNames_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_ClientNames_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_ClientNames_SelectAll]

AS

SET NOCOUNT ON

SELECT [ClientID],
	[CashTrayID],
	[CoinAmountInventory]
FROM [Sac_ClientNames]
GO

/******************************************************************************
--Sac_Money
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Money_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Money_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_Money_Insert]
(
	@Name nvarchar(100),
	@TypeID tinyint,
	@DollarValue money,
	@CountryCode nchar(2)
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_Money]
(
	[Name],
	[TypeID],
	[DollarValue],
	[CountryCode]
)
VALUES
(
	@Name,
	@TypeID,
	@DollarValue,
	@CountryCode
)

SELECT CAST(scope_identity() AS int)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Money_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Money_Update]
GO

CREATE PROCEDURE [dbo].[Sac_Money_Update]
(
	@MoneyID int,
	@Name nvarchar(100),
	@TypeID tinyint,
	@DollarValue money,
	@CountryCode nchar(2)
)

AS

SET NOCOUNT ON

UPDATE [Sac_Money] WITH (ROWLOCK)
SET [Name] = @Name,
	[TypeID] = @TypeID,
	[DollarValue] = @DollarValue,
	[CountryCode] = @CountryCode
WHERE [MoneyID] = @MoneyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Money_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Money_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_Money_Delete]
(
	@MoneyID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_Money] WITH (ROWLOCK)
WHERE [MoneyID] = @MoneyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Money_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Money_Select]
GO

CREATE PROCEDURE [dbo].[Sac_Money_Select]
(
	@MoneyID int
)

AS

SET NOCOUNT ON

SELECT [MoneyID],
	[Name],
	[TypeID],
	[DollarValue],
	[CountryCode]
FROM [Sac_Money]
WHERE [MoneyID] = @MoneyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_Money_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_Money_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_Money_SelectAll]

AS

SET NOCOUNT ON

SELECT [MoneyID],
	[Name],
	[TypeID],
	[DollarValue],
	[CountryCode]
FROM [Sac_Money]
GO

----initial data for the Sac_Money table
--EXEC('
--    exec [Sac_Money_Insert] ''Fifty Dollars'', 1, 50.00, ''CA'';
--    exec [Sac_Money_Insert] ''Twenty Dollars'', 1, 20.00, ''CA'';
--    exec [Sac_Money_Insert] ''Ten Dollars'', 1, 10.00, ''CA'';
--    exec [Sac_Money_Insert] ''Five Dollars'', 1, 5.00, ''CA'';
--    exec [Sac_Money_Insert] ''Toonie'', 0, 2.00, ''CA'';
--    exec [Sac_Money_Insert] ''Loonie'', 0, 1.00, ''CA'';
--    exec [Sac_Money_Insert] ''Quarter'', 0, 0.25, ''CA'';
--    exec [Sac_Money_Insert] ''Dime'', 0, 0.10, ''CA'';
--    exec [Sac_Money_Insert] ''Nickel'', 0, 0.05, ''CA'';
--');


/******************************************************************************
--Sac_MoneyInventory

In Sac_MoneyInventory_Select
comment --AND [BillDispenserID] = @BillDispenserID

******************************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_Insert]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_Insert]
(
	@ClientID nvarchar(50),
	@MoneyID int,
	@BillDispenserID int,
	@Address nvarchar(10),
	@Inventory int,
	@MaxNumBills int,
	@FullQuantity int
)

AS

SET NOCOUNT ON

INSERT INTO [Sac_MoneyInventory]
(
	[ClientID],
	[MoneyID],
	[BillDispenserID],
	[Address],
	[Inventory],
	[MaxNumBills],
	[FullQuantity]
)
VALUES
(
	@ClientID,
	@MoneyID,
	@BillDispenserID,
	@Address,
	@Inventory,
	@MaxNumBills,
	@FullQuantity
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_Update]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_Update]
(
	@ClientID nvarchar(50),
	@MoneyID int,
	@BillDispenserID int,
	@Address nvarchar(10),
	@Inventory int,
	@MaxNumBills int,
	@FullQuantity int
)

AS

SET NOCOUNT ON

UPDATE [Sac_MoneyInventory] WITH (ROWLOCK)
SET [Address] = @Address,
	[Inventory] = @Inventory,
	[MaxNumBills] = @MaxNumBills,
	[FullQuantity] = @FullQuantity
WHERE [ClientID] = @ClientID	AND [MoneyID] = @MoneyID	AND [BillDispenserID] = @BillDispenserID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_Delete]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_Delete]
(
	@ClientID nvarchar(50),
	@MoneyID int,
	@BillDispenserID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_MoneyInventory] WITH (ROWLOCK)
WHERE [ClientID] = @ClientID
	AND [MoneyID] = @MoneyID
	AND [BillDispenserID] = @BillDispenserID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_DeleteAllByMoneyID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_DeleteAllByMoneyID]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_DeleteAllByMoneyID]
(
	@MoneyID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sac_MoneyInventory] WITH (ROWLOCK)
WHERE [MoneyID] = @MoneyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_Select]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_Select]
(
	@ClientID nvarchar(50),
	@MoneyID int,
	@BillDispenserID int
)

AS

SET NOCOUNT ON

SELECT [ClientID],
	[MoneyID],
	[BillDispenserID],
	[Address],
	[Inventory],
	[MaxNumBills],
	[FullQuantity]
FROM [Sac_MoneyInventory]
WHERE [ClientID] = @ClientID
	AND [MoneyID] = @MoneyID
	--AND [BillDispenserID] = @BillDispenserID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_SelectAll]

AS

SET NOCOUNT ON

SELECT [ClientID],
	[MoneyID],
	[BillDispenserID],
	[Address],
	[Inventory],
	[MaxNumBills],
	[FullQuantity]
FROM [Sac_MoneyInventory]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_SelectAllByMoneyID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_SelectAllByMoneyID]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_SelectAllByMoneyID]
(
	@MoneyID int
)

AS

SET NOCOUNT ON

SELECT [ClientID],
	[MoneyID],
	[BillDispenserID],
	[Address],
	[Inventory],
	[MaxNumBills],
	[FullQuantity]
FROM [Sac_MoneyInventory]
WHERE [MoneyID] = @MoneyID
GO

/******************************************************************************
--Sol_BinCount
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_BinCount_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_BinCount_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_BinCount_Insert]
(
	@ClientID varchar(50),
	@CategoryButtonID int,
	@CurrentCount int
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_BinCount]
(
	[ClientID],
	[CategoryButtonID],
	[CurrentCount]
)
VALUES
(
	@ClientID,
	@CategoryButtonID,
	@CurrentCount
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_BinCount_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_BinCount_Update]
GO

CREATE PROCEDURE [dbo].[Sol_BinCount_Update]
(
	@ClientID varchar(50),
	@CategoryButtonID int,
	@CurrentCount int
)

AS

SET NOCOUNT ON

UPDATE [Sol_BinCount] WITH (ROWLOCK)
SET [CurrentCount] = @CurrentCount
WHERE [ClientID] = @ClientID	AND [CategoryButtonID] = @CategoryButtonID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_BinCount_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_BinCount_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_BinCount_Delete]
(
	@ClientID varchar(50),
	@CategoryButtonID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_BinCount] WITH (ROWLOCK)
WHERE [ClientID] = @ClientID
	AND [CategoryButtonID] = @CategoryButtonID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_BinCount_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_BinCount_Select]
GO

CREATE PROCEDURE [dbo].[Sol_BinCount_Select]
(
	@ClientID varchar(50),
	@CategoryButtonID int
)

AS

SET NOCOUNT ON

SELECT [ClientID],
	[CategoryButtonID],
	[CurrentCount]
FROM [Sol_BinCount]
WHERE [ClientID] = @ClientID
	AND [CategoryButtonID] = @CategoryButtonID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_BinCount_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_BinCount_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_BinCount_SelectAll]

AS

SET NOCOUNT ON

SELECT [ClientID],
	[CategoryButtonID],
	[CurrentCount]
FROM [Sol_BinCount]
GO

/******************************************************************************
--Sol_WS_Carriers
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Carriers_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Carriers_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Carriers_Insert]
(
	@CarrierID int,
	@Carrier varchar(256)
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_WS_Carriers]
(
	[CarrierID],
	[Carrier]
)
VALUES
(
	@CarrierID,
	@Carrier
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Carriers_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Carriers_Update]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Carriers_Update]
(
	@CarrierID int,
	@Carrier varchar(256)
)

AS

SET NOCOUNT ON

UPDATE [Sol_WS_Carriers] WITH (ROWLOCK)
SET [Carrier] = @Carrier
WHERE [CarrierID] = @CarrierID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Carriers_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Carriers_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Carriers_Delete]
(
	@CarrierID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_WS_Carriers] WITH (ROWLOCK)
WHERE [CarrierID] = @CarrierID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Carriers_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Carriers_Select]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Carriers_Select]
(
	@CarrierID int
)

AS

SET NOCOUNT ON

SELECT [CarrierID],
	[Carrier]
FROM [Sol_WS_Carriers]
WHERE [CarrierID] = @CarrierID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Carriers_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Carriers_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Carriers_SelectAll]

AS

SET NOCOUNT ON

SELECT [CarrierID],
	[Carrier]
FROM [Sol_WS_Carriers]
GO

/******************************************************************************
--Sol_WS_ErrorCodes
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ErrorCodes_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ErrorCodes_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ErrorCodes_Insert]
(
	@ErrorNumber int,
	@ErrorDescription varchar(256),
	@MessageToClient bit,
	@Notes nvarchar(256)
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_WS_ErrorCodes]
(
	[ErrorNumber],
	[ErrorDescription],
	[MessageToClient],
	[Notes]
)
VALUES
(
	@ErrorNumber,
	@ErrorDescription,
	@MessageToClient,
	@Notes
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ErrorCodes_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ErrorCodes_Update]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ErrorCodes_Update]
(
	@ErrorNumber int,
	@ErrorDescription varchar(256),
	@MessageToClient bit,
	@Notes nvarchar(256)
)

AS

SET NOCOUNT ON

UPDATE [Sol_WS_ErrorCodes] WITH (ROWLOCK)
SET [ErrorDescription] = @ErrorDescription,
	[MessageToClient] = @MessageToClient,
	[Notes] = @Notes
WHERE [ErrorNumber] = @ErrorNumber
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ErrorCodes_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ErrorCodes_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ErrorCodes_Delete]
(
	@ErrorNumber int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_WS_ErrorCodes] WITH (ROWLOCK)
WHERE [ErrorNumber] = @ErrorNumber
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ErrorCodes_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ErrorCodes_Select]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ErrorCodes_Select]
(
	@ErrorNumber int
)

AS

SET NOCOUNT ON

SELECT [ErrorNumber],
	[ErrorDescription],
	[MessageToClient],
	[Notes]
FROM [Sol_WS_ErrorCodes]
WHERE [ErrorNumber] = @ErrorNumber
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ErrorCodes_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ErrorCodes_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ErrorCodes_SelectAll]

AS

SET NOCOUNT ON

SELECT [ErrorNumber],
	[ErrorDescription],
	[MessageToClient],
	[Notes]
FROM [Sol_WS_ErrorCodes]
GO

/******************************************************************************
--Sol_WS_ItemTypes
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ItemTypes_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ItemTypes_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ItemTypes_Insert]
(
	@ItemTypeID int,
	@ItemType varchar(256)
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_WS_ItemTypes]
(
	[ItemTypeID],
	[ItemType]
)
VALUES
(
	@ItemTypeID,
	@ItemType
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ItemTypes_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ItemTypes_Update]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ItemTypes_Update]
(
	@ItemTypeID int,
	@ItemType varchar(256)
)

AS

SET NOCOUNT ON

UPDATE [Sol_WS_ItemTypes] WITH (ROWLOCK)
SET [ItemType] = @ItemType
WHERE [ItemTypeID] = @ItemTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ItemTypes_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ItemTypes_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ItemTypes_Delete]
(
	@ItemTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_WS_ItemTypes] WITH (ROWLOCK)
WHERE [ItemTypeID] = @ItemTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ItemTypes_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ItemTypes_Select]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ItemTypes_Select]
(
	@ItemTypeID int
)

AS

SET NOCOUNT ON

SELECT [ItemTypeID],
	[ItemType]
FROM [Sol_WS_ItemTypes]
WHERE [ItemTypeID] = @ItemTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ItemTypes_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ItemTypes_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ItemTypes_SelectAll]

AS

SET NOCOUNT ON

SELECT [ItemTypeID],
	[ItemType]
FROM [Sol_WS_ItemTypes]
GO

/******************************************************************************
--Sol_WS_Plants
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Plants_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Plants_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Plants_Insert]
(
	@PlantID int,
	@Plant varchar(256)
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_WS_Plants]
(
	[PlantID],
	[Plant]
)
VALUES
(
	@PlantID,
	@Plant
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Plants_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Plants_Update]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Plants_Update]
(
	@PlantID int,
	@Plant varchar(256)
)

AS

SET NOCOUNT ON

UPDATE [Sol_WS_Plants] WITH (ROWLOCK)
SET [Plant] = @Plant
WHERE [PlantID] = @PlantID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Plants_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Plants_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Plants_Delete]
(
	@PlantID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_WS_Plants] WITH (ROWLOCK)
WHERE [PlantID] = @PlantID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Plants_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Plants_Select]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Plants_Select]
(
	@PlantID int
)

AS

SET NOCOUNT ON

SELECT [PlantID],
	[Plant]
FROM [Sol_WS_Plants]
WHERE [PlantID] = @PlantID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_Plants_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_Plants_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_WS_Plants_SelectAll]

AS

SET NOCOUNT ON

SELECT [PlantID],
	[Plant]
FROM [Sol_WS_Plants]
GO

/******************************************************************************
--Sol_WS_ShippingContainerTypes
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ShippingContainerTypes_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ShippingContainerTypes_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ShippingContainerTypes_Insert]
(
	@ShippingContainerTypeID int,
	@ShippingContainerType varchar(256)
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_WS_ShippingContainerTypes]
(
	[ShippingContainerTypeID],
	[ShippingContainerType]
)
VALUES
(
	@ShippingContainerTypeID,
	@ShippingContainerType
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ShippingContainerTypes_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ShippingContainerTypes_Update]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ShippingContainerTypes_Update]
(
	@ShippingContainerTypeID int,
	@ShippingContainerType varchar(256)
)

AS

SET NOCOUNT ON

UPDATE [Sol_WS_ShippingContainerTypes] WITH (ROWLOCK)
SET [ShippingContainerType] = @ShippingContainerType
WHERE [ShippingContainerTypeID] = @ShippingContainerTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ShippingContainerTypes_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ShippingContainerTypes_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ShippingContainerTypes_Delete]
(
	@ShippingContainerTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_WS_ShippingContainerTypes] WITH (ROWLOCK)
WHERE [ShippingContainerTypeID] = @ShippingContainerTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ShippingContainerTypes_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ShippingContainerTypes_Select]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ShippingContainerTypes_Select]
(
	@ShippingContainerTypeID int
)

AS

SET NOCOUNT ON

SELECT [ShippingContainerTypeID],
	[ShippingContainerType]
FROM [Sol_WS_ShippingContainerTypes]
WHERE [ShippingContainerTypeID] = @ShippingContainerTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_WS_ShippingContainerTypes_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_WS_ShippingContainerTypes_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_WS_ShippingContainerTypes_SelectAll]

AS

SET NOCOUNT ON

SELECT [ShippingContainerTypeID],
	[ShippingContainerType]
FROM [Sol_WS_ShippingContainerTypes]
GO


----initial data for the WS tables
--EXEC('
--	exec [Sol_WS_Carriers_Insert] ''229'', ''J-6 Freightways Inc.''
--	exec [Sol_WS_Carriers_Insert] ''231'', ''Barrhead Trucking, Div of Westlock Trans.''
--	exec [Sol_WS_Carriers_Insert] ''234'', ''Boyle Transport''
--	exec [Sol_WS_Carriers_Insert] ''238'', ''Devon Transport Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''239'', ''Drayton Valley Transport''
--	exec [Sol_WS_Carriers_Insert] ''240'', ''Eastline Transfer Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''242'', ''Glendon Transport''
--	exec [Sol_WS_Carriers_Insert] ''243'', ''Grimshaw Trucking''
--	exec [Sol_WS_Carriers_Insert] ''244'', ''Hi Fab Holdings Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''245'', ''Hi Way ''''13'''' Transport''
--	exec [Sol_WS_Carriers_Insert] ''246'', ''Hi Way 9 Express Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''247'', ''Hlewka''''s Transfer''

--	exec [Sol_WS_Carriers_Insert] ''248'', ''Hythe Transfer Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''249'', ''Jenta Transport Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''251'', ''Lac La Biche Transport''
--	exec [Sol_WS_Carriers_Insert] ''252'', ''La Crete Transport''
--	exec [Sol_WS_Carriers_Insert] ''253'', ''Manitoulin Transport''
--	exec [Sol_WS_Carriers_Insert] ''254'', ''Leduc Truck Service Ltd''
--	exec [Sol_WS_Carriers_Insert] ''255'', ''Maiko''''s Trucking (1990) Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''257'', ''Monarch Messenger''
--	exec [Sol_WS_Carriers_Insert] ''258'', ''Morinville Express''
--	exec [Sol_WS_Carriers_Insert] ''261'', ''Mike Rae''
--	exec [Sol_WS_Carriers_Insert] ''262'', ''R.C.S. Cartage''
--	exec [Sol_WS_Carriers_Insert] ''264'', ''Redi Recycle - Carrier''
--	exec [Sol_WS_Carriers_Insert] ''266'', ''S.A.V.E Recycling''
--	exec [Sol_WS_Carriers_Insert] ''267'', ''Stony Plain Transfer''
--	exec [Sol_WS_Carriers_Insert] ''270'', ''Swan Hills Transport''
--	exec [Sol_WS_Carriers_Insert] ''272'', ''Vilna Transport''
--	exec [Sol_WS_Carriers_Insert] ''274'', ''Westwind Trucking Inc.''
--	exec [Sol_WS_Carriers_Insert] ''275'', ''Whitecourt Transport''
--	exec [Sol_WS_Carriers_Insert] ''277'', ''PLANT SELF CARRIER''
--	exec [Sol_WS_Carriers_Insert] ''278'', ''Basic Transport''
--	exec [Sol_WS_Carriers_Insert] ''280'', ''B & R Eckle''''s Transport''
--	exec [Sol_WS_Carriers_Insert] ''281'', ''Turner Valley Carrier''
--	exec [Sol_WS_Carriers_Insert] ''284'', ''Hi Way ''''4'''' Express''
--	exec [Sol_WS_Carriers_Insert] ''287'', ''Bob''''s Bottle Return - Carrier''
--	exec [Sol_WS_Carriers_Insert] ''288'', ''Sundre Container Depot - Carrier''
--	exec [Sol_WS_Carriers_Insert] ''290'', ''Westlock Bottle Depot - Carrier''
--	exec [Sol_WS_Carriers_Insert] ''292'', ''Cochrane Bottle Depot-CARRIER''
--	exec [Sol_WS_Carriers_Insert] ''295'', ''Allans Transport (1999) Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''297'', ''Edson Truck Lines''
--	exec [Sol_WS_Carriers_Insert] ''298'', ''Wolf Transport''
--	exec [Sol_WS_Carriers_Insert] ''300'', ''Westlock Pony Express Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''307'', ''Depot pickup''
--	exec [Sol_WS_Carriers_Insert] ''300000002'', ''Great Northern Transport''
--	exec [Sol_WS_Carriers_Insert] ''300000003'', ''Day & Ross''
--	exec [Sol_WS_Carriers_Insert] ''400000002'', ''Pedersen Transport Ltd''
--	exec [Sol_WS_Carriers_Insert] ''400000010'', ''Strathmore Carrier''
--	exec [Sol_WS_Carriers_Insert] ''400000014'', ''Afreight Traffic Systems''
--	exec [Sol_WS_Carriers_Insert] ''400000015'', ''Bullet/Orlick Transport Company Inc.''
--	exec [Sol_WS_Carriers_Insert] ''400000016'', ''Calgary Metal''
--	exec [Sol_WS_Carriers_Insert] ''400000017'', ''General Recycling Industries Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''400000022'', ''Gibbons Bottle Depot--Carrier''
--	exec [Sol_WS_Carriers_Insert] ''400000023'', ''Jaskreet Holdings Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''400000030'', ''Lynn''''s Foremost Transport''
--	exec [Sol_WS_Carriers_Insert] ''400000043'', ''Quick Silver Transportation''
--	exec [Sol_WS_Carriers_Insert] ''400000052'', ''Gleichen Standard Transport (1990)''
--	exec [Sol_WS_Carriers_Insert] ''400000053'', ''Mayerthorpe Bottle Depot - CARRIER''
--	exec [Sol_WS_Carriers_Insert] ''400000054'', ''Rosenau Transport''
--	exec [Sol_WS_Carriers_Insert] ''400000061'', ''Coaldale Transport/Lethbridge Truck''
--	exec [Sol_WS_Carriers_Insert] ''400000075'', ''Cochrane Transport''
--	exec [Sol_WS_Carriers_Insert] ''400000080'', ''Super B Trucking''
--	exec [Sol_WS_Carriers_Insert] ''400000081'', ''REEM''
--	exec [Sol_WS_Carriers_Insert] ''400000082'', ''T & R''
--	exec [Sol_WS_Carriers_Insert] ''400000083'', ''Waste Management''
--	exec [Sol_WS_Carriers_Insert] ''400000084'', ''Executive Mat Calgary''
--	exec [Sol_WS_Carriers_Insert] ''400000085'', ''Pepsi Carrier''
--	exec [Sol_WS_Carriers_Insert] ''400000088'', ''Roberge''
--	exec [Sol_WS_Carriers_Insert] ''400000089'', ''Pedersen Transport''
--	exec [Sol_WS_Carriers_Insert] ''400000090'', ''Gar-Lyn Trucking''
--	exec [Sol_WS_Carriers_Insert] ''400000092'', ''TBM Transport''
--	exec [Sol_WS_Carriers_Insert] ''400000099'', ''Elite Choice Trucking''
--	exec [Sol_WS_Carriers_Insert] ''400000102'', ''Fernie Cartage''
--	exec [Sol_WS_Carriers_Insert] ''400000105'', ''T.M.C Distributors Ltd''
--	exec [Sol_WS_Carriers_Insert] ''400000107'', ''Dolphin Transport''
--	exec [Sol_WS_Carriers_Insert] ''400000109'', ''Steve Wowk''
--	exec [Sol_WS_Carriers_Insert] ''400000110'', ''Baseline Transport Ltd''
--	exec [Sol_WS_Carriers_Insert] ''400000113'', ''Coyote Courier Ltd''
--	exec [Sol_WS_Carriers_Insert] ''400000138'', ''Beaver Grinding & Recycling Ltd''
--	exec [Sol_WS_Carriers_Insert] ''400000143'', ''Brazel Construction''
--	exec [Sol_WS_Carriers_Insert] ''400000477'', ''Steel Transfer''
--	exec [Sol_WS_Carriers_Insert] ''400000711'', ''Merlin Carrier''
--	exec [Sol_WS_Carriers_Insert] ''400000772'', ''Nu Plastics''
--	exec [Sol_WS_Carriers_Insert] ''400000822'', ''BDL Calgary Carrier''
--	exec [Sol_WS_Carriers_Insert] ''400000823'', ''BDL Edmonton Carrier''
--	exec [Sol_WS_Carriers_Insert] ''400000827'', ''Celadon Trucking''
--	exec [Sol_WS_Carriers_Insert] ''400000835'', ''Hub Group Canada''
--	exec [Sol_WS_Carriers_Insert] ''400000838'', ''US Xpress''
--	exec [Sol_WS_Carriers_Insert] ''500000087'', ''CN''
--	exec [Sol_WS_Carriers_Insert] ''500000152'', ''Richaena Transport''
--	exec [Sol_WS_Carriers_Insert] ''500000224'', ''MJ Smart Transport Ltd''
--	exec [Sol_WS_Carriers_Insert] ''500000475'', ''Plus Fibre Transport''
--	exec [Sol_WS_Carriers_Insert] ''500000571'', ''Barr West Express/ Triple Hitch Transport LTD''
--	exec [Sol_WS_Carriers_Insert] ''510000139'', ''Cornerstone System''
--	exec [Sol_WS_Carriers_Insert] ''510000191'', ''Mode Transportation''
--	exec [Sol_WS_Carriers_Insert] ''510000193'', ''Lethbridge Truck Terminals Ltd.''
--	exec [Sol_WS_Carriers_Insert] ''510000196'', ''Penner International''
--');
--GO

--EXEC('
--	exec [Sol_WS_Plants_Insert] ''3'', ''1-ABCRC-Calgary''
--	exec [Sol_WS_Plants_Insert] ''4'', ''0-ABCRC-Edmonton''
--	exec [Sol_WS_Plants_Insert] ''5'', ''RECYCLE PLUS - Grande Prairie - PLANT''
--	exec [Sol_WS_Plants_Insert] ''6'', ''Redi Recycle - PLANT''
--	exec [Sol_WS_Plants_Insert] ''7'', ''BFI Canada''
--	exec [Sol_WS_Plants_Insert] ''8'', ''S.A.V.E''
--	exec [Sol_WS_Plants_Insert] ''400000049'', ''OTHER Processing Plant''
--	exec [Sol_WS_Plants_Insert] ''400000108'', ''Northwest Territories''
--	exec [Sol_WS_Plants_Insert] ''500000208'', ''Lassonde Western Canada''
--	exec [Sol_WS_Plants_Insert] ''500000398'', ''Executive Mat Edmonton''
--	exec [Sol_WS_Plants_Insert] ''500000581'', ''SAVE Compaction''
--');
--GO

--EXEC('
--	exec [Sol_WS_ItemTypes_Insert] ''0000'', ''NA''
--	exec [Sol_WS_ItemTypes_Insert] ''1006'', ''Aluminum 0 - 1 L''
--	exec [Sol_WS_ItemTypes_Insert] ''1009'', ''Scrap Aluminum''
--	exec [Sol_WS_ItemTypes_Insert] ''2003'', ''Bi-Metal Cans Over 1 Litre''
--	exec [Sol_WS_ItemTypes_Insert] ''2006'', ''Bi Metal 0 - 1 L''
--	exec [Sol_WS_ItemTypes_Insert] ''3003'', ''Glass Over 1 Litre''
--	exec [Sol_WS_ItemTypes_Insert] ''3501'', ''Liq/Wine Ceramics''
--	exec [Sol_WS_ItemTypes_Insert] ''4003'', ''PET Over 1 Litre(Clear & Light Blue Tint)''
--	exec [Sol_WS_ItemTypes_Insert] ''4006'', ''PET 0 - 1 L(Clear & Light Blue Tint)''
--	exec [Sol_WS_ItemTypes_Insert] ''4303'', ''HDPE Plastics Over 1 Litre (Natural)''
--	exec [Sol_WS_ItemTypes_Insert] ''5006'', ''Tetra Brik 0 - 1 L''
--	exec [Sol_WS_ItemTypes_Insert] ''6003'', ''Gable Top Over 1L''
--	exec [Sol_WS_ItemTypes_Insert] ''6006'', ''Gable Top 0 -1 L''
--	exec [Sol_WS_ItemTypes_Insert] ''7006'', ''Drink Pouch 0 - 1 L''
--	exec [Sol_WS_ItemTypes_Insert] ''8001'', ''Bag in Box Over 1 L''
--	exec [Sol_WS_ItemTypes_Insert] ''7008'', ''Aerosol 0 - 1 Litre''
--	exec [Sol_WS_ItemTypes_Insert] ''5003'', ''Tetra Brik Over 1 Litre''
--	exec [Sol_WS_ItemTypes_Insert] ''3006'', ''Glass 0-1 Litre''
--	exec [Sol_WS_ItemTypes_Insert] ''9999'', ''CAPS''
--	exec [Sol_WS_ItemTypes_Insert] ''4023'', ''KeyKeg Over 1 Litre''
--	exec [Sol_WS_ItemTypes_Insert] ''4603'', ''Plastic Over 1 Litre (Other)''
--	exec [Sol_WS_ItemTypes_Insert] ''4606'', ''Plastic Under 1 Litre (Other)''
--');
--GO

--EXEC('
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''0'', ''Foreign''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''7'', ''Mega Bags''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''8'', ''Non ABCRC Pallet''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''9'', ''ABCRC Pallet''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''14'', ''G1-Coroplast''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''15'', ''G3- Coroplast''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''17'', ''Mega Bag GLASS''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''400000006'', ''BDL Pallet''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''500000080'', ''One Way Bag''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''500000423'', ''Collapsible Tote''
--	exec [Sol_WS_ShippingContainerTypes_Insert] ''500000652'', ''Black Baffle Bags''
--');
--GO

--EXEC('
--	exec [Sol_WS_ErrorCodes_Insert] ''100'', ''RBill number is required'', ''0'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''101'', ''RBill number already exists'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''102'', ''RBill number must be 10 characters: four digits for the vendor code followed by a zero padded six digit number'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''103'', ''The first four digits of the RBill number do not match Vendor ID'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''200'', ''Depot ID is required'', ''0'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''201'', ''Depot ID not recognized'', ''0'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''202'', ''A supplier with the specified Depot ID exists, but has not been classified as a Depot'', ''1'', ''Depots don''''t send Depot ID, so may need to change wording in web service''
--	exec [Sol_WS_ErrorCodes_Insert] ''203'', ''The specified Depot has been marked inactive'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''301'', ''Carrier ID not recognized'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''302'', ''A supplier with the specified Carrier ID exists, but has not been classified as a Carrier'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''303'', ''The specified Carrier has been marked inactive'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''304'', ''No Carrier Rates have been defined for the Depot/Carrier combination'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''400'', ''Plant ID is required'', ''0'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''401'', ''Plant ID not recognized'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''402'', ''A supplier with the specified Plant ID exists, but has not been classified as a Plant'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''403'', ''The specified Plant has been marked inactive'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''500'', ''Shipped Date is required'', ''0'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1001'', ''Item Type %s in Bag list not recognized'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1002'', ''Item Type %s in Bag list has been marked inactive'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1101'', ''Shipping Container Type %s in Bag list not recognized'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1102'', ''Shipping Container Type %s in Bag list has been marked inactive'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1201'', ''Tag Number %s in Bag list must be exactly than 20 characters'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1202'', ''Tag Number %s in Bag list already exists'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1203'', ''Tag Number %s occurs more than once in supplied Bag list'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1204'', ''The first for characters of Tag Number %s do not match Vendor ID'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1205'', ''Characters 5 to 8 of Tag Number %s do not match the item type specified for the bag'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1206'', ''Characters 9 to 13 of Tag Number %s do not match the unit count specified for the bag'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''1301'', ''Unit Count for Bag %s is less than zero'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''2001'', ''Shipping Container Type %s in Additional Shipping Container list not recognized'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''2002'', ''Shipping Container Type %s in Additional Shipping Container list has been marked inactive'', ''1'', ''''
--	exec [Sol_WS_ErrorCodes_Insert] ''2101'', ''Shipping Container Count for SC ID %s in Additional Shipping Container list is less than zero'', ''1'', ''''
--');
--GO


/******************************************************************************
--Sol_SupplyInventory
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_Insert]
(
	@SupplyInventoryType char(1),
	@UserID uniqueidentifier,
	@Date datetime,
	@DateOrdered datetime,
	@ProductID int,
	@ContainerID int,
	@Quantity int,
	@ShipmentID int,
	@ReferenceNumber varchar(100)
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_SupplyInventory]
(
	[SupplyInventoryType],
	[UserID],
	[Date],
	[DateOrdered],
	[ProductID],
	[ContainerID],
	[Quantity],
	[ShipmentID],
	[ReferenceNumber]
)
VALUES
(
	@SupplyInventoryType,
	@UserID,
	@Date,
	@DateOrdered,
	@ProductID,
	@ContainerID,
	@Quantity,
	@ShipmentID,
	@ReferenceNumber
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_Update]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_Update]
(
	@SupplyInventoryID int,
	@SupplyInventoryType char(1),
	@UserID uniqueidentifier,
	@Date datetime,
	@DateOrdered datetime,
	@ProductID int,
	@ContainerID int,
	@Quantity int,
	@ShipmentID int,
	@ReferenceNumber varchar(100)
)

AS

SET NOCOUNT ON

UPDATE [Sol_SupplyInventory] WITH (ROWLOCK)
SET [SupplyInventoryType] = @SupplyInventoryType,
	[UserID] = @UserID,
	[Date] = @Date,
	[DateOrdered] = @DateOrdered,
	[ProductID] = @ProductID,
	[ContainerID] = @ContainerID,
	[Quantity] = @Quantity,
	[ShipmentID] = @ShipmentID,
	[ReferenceNumber] = @ReferenceNumber
WHERE [SupplyInventoryID] = @SupplyInventoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_Delete]
(
	@SupplyInventoryID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_SupplyInventory] WITH (ROWLOCK)
WHERE [SupplyInventoryID] = @SupplyInventoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_DeleteAllByContainerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_DeleteAllByContainerID]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_DeleteAllByContainerID]
(
	@ContainerID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_SupplyInventory] WITH (ROWLOCK)
WHERE [ContainerID] = @ContainerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_DeleteAllByShipmentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_DeleteAllByShipmentID]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_DeleteAllByShipmentID]
(
	@ShipmentID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_SupplyInventory] WITH (ROWLOCK)
WHERE [ShipmentID] = @ShipmentID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_Select]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_Select]
(
	@SupplyInventoryID int
)

AS

SET NOCOUNT ON

SELECT [SupplyInventoryID],
	[SupplyInventoryType],
	[UserID],
	[Date],
	[DateOrdered],
	[ProductID],
	[ContainerID],
	[Quantity],
	[ShipmentID],
	[ReferenceNumber]
FROM [Sol_SupplyInventory]
WHERE [SupplyInventoryID] = @SupplyInventoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_SelectAll]

AS

SET NOCOUNT ON

SELECT [SupplyInventoryID],
	[SupplyInventoryType],
	[UserID],
	[Date],
	[DateOrdered],
	[ProductID],
	[ContainerID],
	[Quantity],
	[ShipmentID],
	[ReferenceNumber]
FROM [Sol_SupplyInventory]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_SelectAllByContainerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_SelectAllByContainerID]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_SelectAllByContainerID]
(
	@ContainerID int
)

AS

SET NOCOUNT ON

SELECT [SupplyInventoryID],
	[SupplyInventoryType],
	[UserID],
	[Date],
	[DateOrdered],
	[ProductID],
	[ContainerID],
	[Quantity],
	[ShipmentID],
	[ReferenceNumber]
FROM [Sol_SupplyInventory]
WHERE [ContainerID] = @ContainerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_SupplyInventory_SelectAllByShipmentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_SupplyInventory_SelectAllByShipmentID]
GO

CREATE PROCEDURE [dbo].[Sol_SupplyInventory_SelectAllByShipmentID]
(
	@ShipmentID int
)

AS

SET NOCOUNT ON

SELECT [SupplyInventoryID],
	[SupplyInventoryType],
	[UserID],
	[Date],
	[DateOrdered],
	[ProductID],
	[ContainerID],
	[Quantity],
	[ShipmentID],
	[ReferenceNumber]
FROM [Sol_SupplyInventory]
WHERE [ShipmentID] = @ShipmentID
GO
/******************************************************************************
--Sol_Employees
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Employees_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Employees_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_Employees_Insert]
(
	@UserId uniqueidentifier,
	@FirstName nvarchar(256),
	@LastName nvarchar(256),
	@MiddleName nvarchar(256),
	@BirthDate datetime,
	@HireDate datetime,
	@EmployeeNotes nvarchar(512),
	@SIN nvarchar(256),
	@Gender tinyint,
	@EmployeeNumber nvarchar(256),
	@PayrollNumber nvarchar(256),
	@CompensationAmount money,
	@CompensationType tinyint
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_Employees]
(
	[UserId],
	[FirstName],
	[LastName],
	[MiddleName],
	[BirthDate],
	[HireDate],
	[EmployeeNotes],
	[SIN],
	[Gender],
	[EmployeeNumber],
	[PayrollNumber],
	[CompensationAmount],
	[CompensationType]
)
VALUES
(
	@UserId,
	@FirstName,
	@LastName,
	@MiddleName,
	@BirthDate,
	@HireDate,
	@EmployeeNotes,
	@SIN,
	@Gender,
	@EmployeeNumber,
	@PayrollNumber,
	@CompensationAmount,
	@CompensationType
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Employees_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Employees_Update]
GO

CREATE PROCEDURE [dbo].[Sol_Employees_Update]
(
	@UserId uniqueidentifier,
	@FirstName nvarchar(256),
	@LastName nvarchar(256),
	@MiddleName nvarchar(256),
	@BirthDate datetime,
	@HireDate datetime,
	@EmployeeNotes nvarchar(512),
	@SIN nvarchar(256),
	@Gender tinyint,
	@EmployeeNumber nvarchar(256),
	@PayrollNumber nvarchar(256),
	@CompensationAmount money,
	@CompensationType tinyint
)

AS

SET NOCOUNT ON

UPDATE [Sol_Employees] WITH (ROWLOCK)
SET [FirstName] = @FirstName,
	[LastName] = @LastName,
	[MiddleName] = @MiddleName,
	[BirthDate] = @BirthDate,
	[HireDate] = @HireDate,
	[EmployeeNotes] = @EmployeeNotes,
	[SIN] = @SIN,
	[Gender] = @Gender,
	[EmployeeNumber] = @EmployeeNumber,
	[PayrollNumber] = @PayrollNumber,
	[CompensationAmount] = @CompensationAmount,
	[CompensationType] = @CompensationType
WHERE [UserId] = @UserId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Employees_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Employees_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_Employees_Delete]
(
	@UserId uniqueidentifier
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_Employees] WITH (ROWLOCK)
WHERE [UserId] = @UserId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Employees_DeleteAllByUserId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Employees_DeleteAllByUserId]
GO

CREATE PROCEDURE [dbo].[Sol_Employees_DeleteAllByUserId]
(
	@UserId uniqueidentifier
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_Employees] WITH (ROWLOCK)
WHERE [UserId] = @UserId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Employees_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Employees_Select]
GO

CREATE PROCEDURE [dbo].[Sol_Employees_Select]
(
	@UserId uniqueidentifier
)

AS

SET NOCOUNT ON

SELECT [UserId],
	[FirstName],
	[LastName],
	[MiddleName],
	[BirthDate],
	[HireDate],
	[EmployeeNotes],
	[SIN],
	[Gender],
	[EmployeeNumber],
	[PayrollNumber],
	[CompensationAmount],
	[CompensationType]
FROM [Sol_Employees]
WHERE [UserId] = @UserId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Employees_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Employees_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_Employees_SelectAll]

AS

SET NOCOUNT ON

SELECT [UserId],
	[FirstName],
	[LastName],
	[MiddleName],
	[BirthDate],
	[HireDate],
	[EmployeeNotes],
	[SIN],
	[Gender],
	[EmployeeNumber],
	[PayrollNumber],
	[CompensationAmount],
	[CompensationType]
FROM [Sol_Employees]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Employees_SelectAllByUserId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Employees_SelectAllByUserId]
GO

CREATE PROCEDURE [dbo].[Sol_Employees_SelectAllByUserId]
(
	@UserId uniqueidentifier
)

AS

SET NOCOUNT ON

SELECT [UserId],
	[FirstName],
	[LastName],
	[MiddleName],
	[BirthDate],
	[HireDate],
	[EmployeeNotes],
	[SIN],
	[Gender],
	[EmployeeNumber],
	[PayrollNumber],
	[CompensationAmount],
	[CompensationType]
FROM [Sol_Employees]
WHERE [UserId] = @UserId
GO

/******************************************************************************
--Sol_EmployeesLog
SELECT CAST(scope_identity() AS bigint) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_EmployeesLog_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_EmployeesLog_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_EmployeesLog_Insert]
(
	@UserId uniqueidentifier,
	@PunchInTime datetime,
	@PunchOutTime datetime,
	@Comments nvarchar(512),
	@Approved bit,
	@Modified bit
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_EmployeesLog]
(
	[UserId],
	[PunchInTime],
	[PunchOutTime],
	[Comments],
	[Approved],
	[Modified]
)
VALUES
(
	@UserId,
	@PunchInTime,
	@PunchOutTime,
	@Comments,
	@Approved,
	@Modified
)

SELECT CAST(scope_identity() AS bigint) 

GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_EmployeesLog_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_EmployeesLog_Update]
GO

CREATE PROCEDURE [dbo].[Sol_EmployeesLog_Update]
(
	@LogId bigint,
	@UserId uniqueidentifier,
	@PunchInTime datetime,
	@PunchOutTime datetime,
	@Comments nvarchar(512),
	@Approved bit,
	@Modified bit
)

AS

SET NOCOUNT ON

UPDATE [Sol_EmployeesLog] WITH (ROWLOCK)
SET [UserId] = @UserId,
	[PunchInTime] = @PunchInTime,
	[PunchOutTime] = @PunchOutTime,
	[Comments] = @Comments,
	[Approved] = @Approved,
	[Modified] = @Modified
WHERE [LogId] = @LogId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_EmployeesLog_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_EmployeesLog_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_EmployeesLog_Delete]
(
	@LogId bigint
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_EmployeesLog] WITH (ROWLOCK)
WHERE [LogId] = @LogId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_EmployeesLog_DeleteAllByUserId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_EmployeesLog_DeleteAllByUserId]
GO

CREATE PROCEDURE [dbo].[Sol_EmployeesLog_DeleteAllByUserId]
(
	@UserId uniqueidentifier
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_EmployeesLog] WITH (ROWLOCK)
WHERE [UserId] = @UserId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_EmployeesLog_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_EmployeesLog_Select]
GO

CREATE PROCEDURE [dbo].[Sol_EmployeesLog_Select]
(
	@LogId bigint
)

AS

SET NOCOUNT ON

SELECT [LogId],
	[UserId],
	[PunchInTime],
	[PunchOutTime],
	[Comments],
	[Approved],
	[Modified]
FROM [Sol_EmployeesLog]
WHERE [LogId] = @LogId
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_EmployeesLog_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_EmployeesLog_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_EmployeesLog_SelectAll]

AS

SET NOCOUNT ON

SELECT [LogId],
	[UserId],
	[PunchInTime],
	[PunchOutTime],
	[Comments],
	[Approved],
	[Modified]
FROM [Sol_EmployeesLog]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_EmployeesLog_SelectAllByUserId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_EmployeesLog_SelectAllByUserId]
GO

CREATE PROCEDURE [dbo].[Sol_EmployeesLog_SelectAllByUserId]
(
	@UserId uniqueidentifier
)

AS

SET NOCOUNT ON

SELECT [LogId],
	[UserId],
	[PunchInTime],
	[PunchOutTime],
	[Comments],
	[Approved],
	[Modified]
FROM [Sol_EmployeesLog]
WHERE [UserId] = @UserId
GO

/******************************************************************************
--Sol_Control
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Control_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Control_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_Control_Insert]
(
	@ControlID int,
	@BusinessName nvarchar(256),
	@LegalName nvarchar(256),
	@StoreNumber int,
	@Address nvarchar(256),
	@City nvarchar(56),
	@State nvarchar(56),
	@Country nvarchar(56),
	@PhoneNumber nvarchar(20),
	@BusinessHoursFrom datetime,
	@BusinessHoursTo datetime,
	@IdFiscal1Name char(15),
	@IdFiscal1Value nvarchar(25),
	@IdFiscal2Name char(15),
	@IdFiscal2Value nvarchar(25),
	@WorkStationID int,
	@CustomerScreenMessageID int,
	@FrontStationMessageID int,
	@CashierRoutineMessageID int,
	@ReturnStationMessageID int,
	@CashierStationMessageID int,
	@ShippingStationMessageID int,
	@ReceiptMessageID int,
	@SMTPServer varchar(50),
	@SMTPPort int,
	@EmailAccount varchar(256),
	@EmailPassword varchar(128),
	@HistoryYears tinyint,
	@FiscalYearInitialMonth tinyint,
	@NumericKeyPadOn bit,
	@NumericKeyPadPosition tinyint,
	@ReturnButtonExtra tinyint,
	@Tax1Name nvarchar(64),
	@Tax1Rate decimal(18, 3),
	@Tax2Name nvarchar(64),
	@Tax2Rate decimal(18, 3),
	@DatabaseVersion decimal(18, 3),
	@Status char(1),
	@EmployeesListRefresh int,
	@WebBrowserUrl nvarchar(512),
	@AutoGenerateTagNumber bit,
	@AutoGenerateRBillNumber bit,
	@DefaultAgencyID int,
	@ChitTicketComplete tinyint,
	@ChitTicketIncludeBarcode bit,
	@CashOutPrintingOverride bit,
	@WhiteBagID int,
	@BlueBagID int,
	@OneWayBagID int,
	@ABCRCPalletsID int,
	@CustomerScreenMonitor tinyint,
	@CategoryButtonsPanelBgColor int,
	@CategoryButtonsSnapToGrid bit,
	@BusinessHoursFromTue datetime,
	@BusinessHoursToTue datetime,
	@BusinessHoursFromWed datetime,
	@BusinessHoursToWed datetime,
	@BusinessHoursFromThu datetime,
	@BusinessHoursToThu datetime,
	@BusinessHoursFromFri datetime,
	@BusinessHoursToFri datetime,
	@BusinessHoursFromSat datetime,
	@BusinessHoursToSat datetime,
	@BusinessHoursFromSun datetime,
	@BusinessHoursToSun datetime,
	@ReturnsMaxQuantity int,
	@WebBrowserUpdateHistoryUrl nvarchar(512),
	@CashierMaxAmount money,
	@ComputerRole tinyint,
	@SqlServerDate bit,
	@VendorID int,
	@DefaultPlantID int,
	@DefaultCarrierID int,
	@ABCRCUserName nvarchar(256),
	@ABCRCPassword varchar(128),
	@ReceiptAmountBarcode bit,
	@IncludeSecurityCode bit,
	@RBillNumberBarcode bit,
	@SacCashTrayID int
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_Control]
(
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
VALUES
(
	@ControlID,
	@BusinessName,
	@LegalName,
	@StoreNumber,
	@Address,
	@City,
	@State,
	@Country,
	@PhoneNumber,
	@BusinessHoursFrom,
	@BusinessHoursTo,
	@IdFiscal1Name,
	@IdFiscal1Value,
	@IdFiscal2Name,
	@IdFiscal2Value,
	@WorkStationID,
	@CustomerScreenMessageID,
	@FrontStationMessageID,
	@CashierRoutineMessageID,
	@ReturnStationMessageID,
	@CashierStationMessageID,
	@ShippingStationMessageID,
	@ReceiptMessageID,
	@SMTPServer,
	@SMTPPort,
	@EmailAccount,
	@EmailPassword,
	@HistoryYears,
	@FiscalYearInitialMonth,
	@NumericKeyPadOn,
	@NumericKeyPadPosition,
	@ReturnButtonExtra,
	@Tax1Name,
	@Tax1Rate,
	@Tax2Name,
	@Tax2Rate,
	@DatabaseVersion,
	@Status,
	@EmployeesListRefresh,
	@WebBrowserUrl,
	@AutoGenerateTagNumber,
	@AutoGenerateRBillNumber,
	@DefaultAgencyID,
	@ChitTicketComplete,
	@ChitTicketIncludeBarcode,
	@CashOutPrintingOverride,
	@WhiteBagID,
	@BlueBagID,
	@OneWayBagID,
	@ABCRCPalletsID,
	@CustomerScreenMonitor,
	@CategoryButtonsPanelBgColor,
	@CategoryButtonsSnapToGrid,
	@BusinessHoursFromTue,
	@BusinessHoursToTue,
	@BusinessHoursFromWed,
	@BusinessHoursToWed,
	@BusinessHoursFromThu,
	@BusinessHoursToThu,
	@BusinessHoursFromFri,
	@BusinessHoursToFri,
	@BusinessHoursFromSat,
	@BusinessHoursToSat,
	@BusinessHoursFromSun,
	@BusinessHoursToSun,
	@ReturnsMaxQuantity,
	@WebBrowserUpdateHistoryUrl,
	@CashierMaxAmount,
	@ComputerRole,
	@SqlServerDate,
	@VendorID,
	@DefaultPlantID,
	@DefaultCarrierID,
	@ABCRCUserName,
	@ABCRCPassword,
	@ReceiptAmountBarcode,
	@IncludeSecurityCode,
	@RBillNumberBarcode,
	@SacCashTrayID
)
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Control_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Control_Update]
GO

CREATE PROCEDURE [dbo].[Sol_Control_Update]
(
	@ControlID int,
	@BusinessName nvarchar(256),
	@LegalName nvarchar(256),
	@StoreNumber int,
	@Address nvarchar(256),
	@City nvarchar(56),
	@State nvarchar(56),
	@Country nvarchar(56),
	@PhoneNumber nvarchar(20),
	@BusinessHoursFrom datetime,
	@BusinessHoursTo datetime,
	@IdFiscal1Name char(15),
	@IdFiscal1Value nvarchar(25),
	@IdFiscal2Name char(15),
	@IdFiscal2Value nvarchar(25),
	@WorkStationID int,
	@CustomerScreenMessageID int,
	@FrontStationMessageID int,
	@CashierRoutineMessageID int,
	@ReturnStationMessageID int,
	@CashierStationMessageID int,
	@ShippingStationMessageID int,
	@ReceiptMessageID int,
	@SMTPServer varchar(50),
	@SMTPPort int,
	@EmailAccount varchar(256),
	@EmailPassword varchar(128),
	@HistoryYears tinyint,
	@FiscalYearInitialMonth tinyint,
	@NumericKeyPadOn bit,
	@NumericKeyPadPosition tinyint,
	@ReturnButtonExtra tinyint,
	@Tax1Name nvarchar(64),
	@Tax1Rate decimal(18, 3),
	@Tax2Name nvarchar(64),
	@Tax2Rate decimal(18, 3),
	@DatabaseVersion decimal(18, 3),
	@Status char(1),
	@EmployeesListRefresh int,
	@WebBrowserUrl nvarchar(512),
	@AutoGenerateTagNumber bit,
	@AutoGenerateRBillNumber bit,
	@DefaultAgencyID int,
	@ChitTicketComplete tinyint,
	@ChitTicketIncludeBarcode bit,
	@CashOutPrintingOverride bit,
	@WhiteBagID int,
	@BlueBagID int,
	@OneWayBagID int,
	@ABCRCPalletsID int,
	@CustomerScreenMonitor tinyint,
	@CategoryButtonsPanelBgColor int,
	@CategoryButtonsSnapToGrid bit,
	@BusinessHoursFromTue datetime,
	@BusinessHoursToTue datetime,
	@BusinessHoursFromWed datetime,
	@BusinessHoursToWed datetime,
	@BusinessHoursFromThu datetime,
	@BusinessHoursToThu datetime,
	@BusinessHoursFromFri datetime,
	@BusinessHoursToFri datetime,
	@BusinessHoursFromSat datetime,
	@BusinessHoursToSat datetime,
	@BusinessHoursFromSun datetime,
	@BusinessHoursToSun datetime,
	@ReturnsMaxQuantity int,
	@WebBrowserUpdateHistoryUrl nvarchar(512),
	@CashierMaxAmount money,
	@ComputerRole tinyint,
	@SqlServerDate bit,
	@VendorID int,
	@DefaultPlantID int,
	@DefaultCarrierID int,
	@ABCRCUserName nvarchar(256),
	@ABCRCPassword varchar(128),
	@ReceiptAmountBarcode bit,
	@IncludeSecurityCode bit,
	@RBillNumberBarcode bit,
	@SacCashTrayID int
)

AS

SET NOCOUNT ON

UPDATE [Sol_Control] WITH (ROWLOCK)
SET [BusinessName] = @BusinessName,
	[LegalName] = @LegalName,
	[StoreNumber] = @StoreNumber,
	[Address] = @Address,
	[City] = @City,
	[State] = @State,
	[Country] = @Country,
	[PhoneNumber] = @PhoneNumber,
	[BusinessHoursFrom] = @BusinessHoursFrom,
	[BusinessHoursTo] = @BusinessHoursTo,
	[IdFiscal1Name] = @IdFiscal1Name,
	[IdFiscal1Value] = @IdFiscal1Value,
	[IdFiscal2Name] = @IdFiscal2Name,
	[IdFiscal2Value] = @IdFiscal2Value,
	[WorkStationID] = @WorkStationID,
	[CustomerScreenMessageID] = @CustomerScreenMessageID,
	[FrontStationMessageID] = @FrontStationMessageID,
	[CashierRoutineMessageID] = @CashierRoutineMessageID,
	[ReturnStationMessageID] = @ReturnStationMessageID,
	[CashierStationMessageID] = @CashierStationMessageID,
	[ShippingStationMessageID] = @ShippingStationMessageID,
	[ReceiptMessageID] = @ReceiptMessageID,
	[SMTPServer] = @SMTPServer,
	[SMTPPort] = @SMTPPort,
	[EmailAccount] = @EmailAccount,
	[EmailPassword] = @EmailPassword,
	[HistoryYears] = @HistoryYears,
	[FiscalYearInitialMonth] = @FiscalYearInitialMonth,
	[NumericKeyPadOn] = @NumericKeyPadOn,
	[NumericKeyPadPosition] = @NumericKeyPadPosition,
	[ReturnButtonExtra] = @ReturnButtonExtra,
	[Tax1Name] = @Tax1Name,
	[Tax1Rate] = @Tax1Rate,
	[Tax2Name] = @Tax2Name,
	[Tax2Rate] = @Tax2Rate,
	[DatabaseVersion] = @DatabaseVersion,
	[Status] = @Status,
	[EmployeesListRefresh] = @EmployeesListRefresh,
	[WebBrowserUrl] = @WebBrowserUrl,
	[AutoGenerateTagNumber] = @AutoGenerateTagNumber,
	[AutoGenerateRBillNumber] = @AutoGenerateRBillNumber,
	[DefaultAgencyID] = @DefaultAgencyID,
	[ChitTicketComplete] = @ChitTicketComplete,
	[ChitTicketIncludeBarcode] = @ChitTicketIncludeBarcode,
	[CashOutPrintingOverride] = @CashOutPrintingOverride,
	[WhiteBagID] = @WhiteBagID,
	[BlueBagID] = @BlueBagID,
	[OneWayBagID] = @OneWayBagID,
	[ABCRCPalletsID] = @ABCRCPalletsID,
	[CustomerScreenMonitor] = @CustomerScreenMonitor,
	[CategoryButtonsPanelBgColor] = @CategoryButtonsPanelBgColor,
	[CategoryButtonsSnapToGrid] = @CategoryButtonsSnapToGrid,
	[BusinessHoursFromTue] = @BusinessHoursFromTue,
	[BusinessHoursToTue] = @BusinessHoursToTue,
	[BusinessHoursFromWed] = @BusinessHoursFromWed,
	[BusinessHoursToWed] = @BusinessHoursToWed,
	[BusinessHoursFromThu] = @BusinessHoursFromThu,
	[BusinessHoursToThu] = @BusinessHoursToThu,
	[BusinessHoursFromFri] = @BusinessHoursFromFri,
	[BusinessHoursToFri] = @BusinessHoursToFri,
	[BusinessHoursFromSat] = @BusinessHoursFromSat,
	[BusinessHoursToSat] = @BusinessHoursToSat,
	[BusinessHoursFromSun] = @BusinessHoursFromSun,
	[BusinessHoursToSun] = @BusinessHoursToSun,
	[ReturnsMaxQuantity] = @ReturnsMaxQuantity,
	[WebBrowserUpdateHistoryUrl] = @WebBrowserUpdateHistoryUrl,
	[CashierMaxAmount] = @CashierMaxAmount,
	[ComputerRole] = @ComputerRole,
	[SqlServerDate] = @SqlServerDate,
	[VendorID] = @VendorID,
	[DefaultPlantID] = @DefaultPlantID,
	[DefaultCarrierID] = @DefaultCarrierID,
	[ABCRCUserName] = @ABCRCUserName,
	[ABCRCPassword] = @ABCRCPassword,
	[ReceiptAmountBarcode] = @ReceiptAmountBarcode,
	[IncludeSecurityCode] = @IncludeSecurityCode,
	[RBillNumberBarcode] = @RBillNumberBarcode,
	[SacCashTrayID] = @SacCashTrayID
WHERE [ControlID] = @ControlID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Control_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Control_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_Control_Delete]
(
	@ControlID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_Control] WITH (ROWLOCK)
WHERE [ControlID] = @ControlID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Control_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Control_Select]
GO

CREATE PROCEDURE [dbo].[Sol_Control_Select]
(
	@ControlID int
)

AS

SET NOCOUNT ON

SELECT [ControlID],
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
FROM [Sol_Control]
WHERE [ControlID] = @ControlID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Control_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Control_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_Control_SelectAll]

AS

SET NOCOUNT ON

SELECT [ControlID],
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
FROM [Sol_Control]
GO

/******************************************************************************
--Sol_Products
SELECT CAST(scope_identity() AS int) 

******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_Insert]
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_Insert]
(
	@ProName varchar(50),
	@ProDescription varchar(50),
	@ProShortDescription varchar(50),
	@ProImage image,
	@AgencyID int,
	@MenuOrder int,
	@IsActive bit,
	@Price money,
	@CategoryID int,
	@RefundAmount money,
	@HandlingCommissionAmount numeric(18, 6),
	@CommissionUnit int,
	@VafAmount numeric(18, 6),
	@FeeUnit int,
	@ContainerID int,
	@StandardDozenID int,
	@UPC varchar(50),
	@ProductCode varchar(50),
	@TypeId tinyint,
	@Tax1Exempt bit,
	@Tax2Exempt bit,
	@MasterProductID int,
	@Weight numeric(8, 4),
	@Volume numeric(8, 4),
	@TargetQuantity int =0
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Products]
(
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
	[MasterProductID],
	[Weight],
	[Volume],
	[TargetQuantity]
)
VALUES
(
	@ProName,
	@ProDescription,
	@ProShortDescription,
	@ProImage,
	@AgencyID,
	@MenuOrder,
	@IsActive,
	@Price,
	@CategoryID,
	@RefundAmount,
	@HandlingCommissionAmount,
	@CommissionUnit,
	@VafAmount,
	@FeeUnit,
	@ContainerID,
	@StandardDozenID,
	@UPC,
	@ProductCode,
	@TypeId,
	@Tax1Exempt,
	@Tax2Exempt,
	@MasterProductID,
	@Weight,
	@Volume,
	@TargetQuantity
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_Update]
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_Update]
(
	@ProductID int,
	@ProName varchar(50),
	@ProDescription varchar(50),
	@ProShortDescription varchar(50),
	@ProImage image,
	@AgencyID int,
	@MenuOrder int,
	@IsActive bit,
	@Price money,
	@CategoryID int,
	@RefundAmount money,
	@HandlingCommissionAmount numeric(18, 6),
	@CommissionUnit int,
	@VafAmount numeric(18, 6),
	@FeeUnit int,
	@ContainerID int,
	@StandardDozenID int,
	@UPC varchar(50),
	@ProductCode varchar(50),
	@TypeId tinyint,
	@Tax1Exempt bit,
	@Tax2Exempt bit,
	@MasterProductID int,
	@Weight numeric(8, 4),
	@Volume numeric(8, 4),
	@TargetQuantity int
)

AS

SET NOCOUNT ON

UPDATE [sol_Products] WITH (ROWLOCK)
SET [ProName] = @ProName,
	[ProDescription] = @ProDescription,
	[ProShortDescription] = @ProShortDescription,
	[ProImage] = @ProImage,
	[AgencyID] = @AgencyID,
	[MenuOrder] = @MenuOrder,
	[IsActive] = @IsActive,
	[Price] = @Price,
	[CategoryID] = @CategoryID,
	[RefundAmount] = @RefundAmount,
	[HandlingCommissionAmount] = @HandlingCommissionAmount,
	[CommissionUnit] = @CommissionUnit,
	[VafAmount] = @VafAmount,
	[FeeUnit] = @FeeUnit,
	[ContainerID] = @ContainerID,
	[StandardDozenID] = @StandardDozenID,
	[UPC] = @UPC,
	[ProductCode] = @ProductCode,
	[TypeId] = @TypeId,
	[Tax1Exempt] = @Tax1Exempt,
	[Tax2Exempt] = @Tax2Exempt,
	[MasterProductID] = @MasterProductID,
	[Weight] = @Weight,
	[Volume] = @Volume,
	[TargetQuantity] = @TargetQuantity
WHERE [ProductID] = @ProductID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Products_Delete]
(
	@ProductID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Products] WITH (ROWLOCK)
WHERE [ProductID] = @ProductID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_DeleteAllByAgencyID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_DeleteAllByAgencyID]
GO

CREATE PROCEDURE [dbo].[sol_Products_DeleteAllByAgencyID]
(
	@AgencyID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Products] WITH (ROWLOCK)
WHERE [AgencyID] = @AgencyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_DeleteAllByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_DeleteAllByCategoryID]
GO

CREATE PROCEDURE [dbo].[sol_Products_DeleteAllByCategoryID]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Products] WITH (ROWLOCK)
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_DeleteAllByContainerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_DeleteAllByContainerID]
GO

CREATE PROCEDURE [dbo].[sol_Products_DeleteAllByContainerID]
(
	@ContainerID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Products] WITH (ROWLOCK)
WHERE [ContainerID] = @ContainerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_DeleteAllByStandardDozenID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_DeleteAllByStandardDozenID]
GO

CREATE PROCEDURE [dbo].[sol_Products_DeleteAllByStandardDozenID]
(
	@StandardDozenID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Products] WITH (ROWLOCK)
WHERE [StandardDozenID] = @StandardDozenID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_Select]
GO

CREATE PROCEDURE [dbo].[sol_Products_Select]
(
	@ProductID int
)

AS

SET NOCOUNT ON

SELECT [ProductID],
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
	[MasterProductID],
	[Weight],
	[Volume],
	[TargetQuantity]
FROM [sol_Products]
WHERE [ProductID] = @ProductID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_SelectAll]
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectAll]

AS

SET NOCOUNT ON

SELECT [ProductID],
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
	[MasterProductID],
	[Weight],
	[Volume],
	[TargetQuantity]
FROM [sol_Products]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_SelectAllByAgencyID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_SelectAllByAgencyID]
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectAllByAgencyID]
(
	@AgencyID int
)

AS

SET NOCOUNT ON

SELECT [ProductID],
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
	[MasterProductID],
	[Weight],
	[Volume],
	[TargetQuantity]
FROM [sol_Products]
WHERE [AgencyID] = @AgencyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_SelectAllByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_SelectAllByCategoryID]
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectAllByCategoryID]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

SELECT [ProductID],
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
	[MasterProductID],
	[Weight],
	[Volume],
	[TargetQuantity]
FROM [sol_Products]
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_SelectAllByContainerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_SelectAllByContainerID]
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectAllByContainerID]
(
	@ContainerID int
)

AS

SET NOCOUNT ON

SELECT [ProductID],
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
	[MasterProductID],
	[Weight],
	[Volume],
	[TargetQuantity]
FROM [sol_Products]
WHERE [ContainerID] = @ContainerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Products_SelectAllByStandardDozenID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Products_SelectAllByStandardDozenID]
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectAllByStandardDozenID]
(
	@StandardDozenID int
)

AS

SET NOCOUNT ON

SELECT [ProductID],
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
	[MasterProductID],
	[Weight],
	[Volume],
	[TargetQuantity]
FROM [sol_Products]
WHERE [StandardDozenID] = @StandardDozenID
GO

/******************************************************************************
--Sol_Customers
	DBCC CHECKIDENT ('sol_Customers', RESEED, 0)
	DBCC CHECKIDENT ('sol_Customers', RESEED)

	SELECT CAST(scope_identity() AS int) 

	comment out sol_Customers_Update
	comment out sol_Customers_SelectAll

	comment all [IsNew] references

******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_Insert]
GO

CREATE PROCEDURE [dbo].[sol_Customers_Insert]
(
	@CustomerCode varchar(10),
	@Name varchar(50),
	@Contact varchar(50),
	@Address1 varchar(250),
	@Address2 varchar(250),
	@City varchar(100),
	@Province varchar(100),
	@Country varchar(50),
	@PostalCode varchar(50),
	@Email nvarchar(256),
	@LoweredEmail nvarchar(256),
	@IsActive bit,
	@PhoneNumber nvarchar(20),
	@Notes nvarchar(512),
	@Password nvarchar(128),
	@DepotID char(6),
	@CardNumber nvarchar(50),
	@CardTypeID int,
	@SolumCustomer bit,
	@QuickDropCustomer bit
	--, 	@IsNew bit
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Customers]
(
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
	[CardTypeID],
	[SolumCustomer],
	[QuickDropCustomer]
	--, 	[IsNew]
)
VALUES
(
	@CustomerCode,
	@Name,
	@Contact,
	@Address1,
	@Address2,
	@City,
	@Province,
	@Country,
	@PostalCode,
	@Email,
	@LoweredEmail,
	@IsActive,
	@PhoneNumber,
	@Notes,
	@Password,
	@DepotID,
	@CardNumber,
	@CardTypeID,
	@SolumCustomer,
	@QuickDropCustomer
	--, 	@IsNew
)

	SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[sol_Customers_Update]
--GO

--CREATE PROCEDURE [dbo].[sol_Customers_Update]
--(
--	@CustomerID int,
--	@CustomerCode varchar(10),
--	@Name varchar(50),
--	@Contact varchar(50),
--	@Address1 varchar(250),
--	@Address2 varchar(250),
--	@City varchar(100),
--	@Province varchar(100),
--	@Country varchar(50),
--	@PostalCode varchar(50),
--	@Email nvarchar(256),
--	@LoweredEmail nvarchar(256),
--	@IsActive bit,
--	@PhoneNumber nvarchar(20),
--	@Notes nvarchar(512),
--	@Password nvarchar(128),
--	@DepotID char(6),
--	@CardNumber nvarchar(50),
--	@CardTypeID int,
--	@SolumCustomer bit,
--	@QuickDropCustomer bit,
--	@IsNew bit
--)

--AS

--SET NOCOUNT ON

--UPDATE [sol_Customers] WITH (ROWLOCK)
--SET [CustomerCode] = @CustomerCode,
--	[Name] = @Name,
--	[Contact] = @Contact,
--	[Address1] = @Address1,
--	[Address2] = @Address2,
--	[City] = @City,
--	[Province] = @Province,
--	[Country] = @Country,
--	[PostalCode] = @PostalCode,
--	[Email] = @Email,
--	[LoweredEmail] = @LoweredEmail,
--	[IsActive] = @IsActive,
--	[PhoneNumber] = @PhoneNumber,
--	[Notes] = @Notes,
--	[Password] = @Password,
--	[DepotID] = @DepotID,
--	[CardNumber] = @CardNumber,
--	[CardTypeID] = @CardTypeID,
--	[SolumCustomer] = @SolumCustomer,
--	[QuickDropCustomer] = @QuickDropCustomer,
--	[IsNew] = @IsNew
--WHERE [CustomerID] = @CustomerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Customers_Delete]
(
	@CustomerID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Customers] WITH (ROWLOCK)
WHERE [CustomerID] = @CustomerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_DeleteAllByCardTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_DeleteAllByCardTypeID]
GO

CREATE PROCEDURE [dbo].[sol_Customers_DeleteAllByCardTypeID]
(
	@CardTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Customers] WITH (ROWLOCK)
WHERE [CardTypeID] = @CardTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_Select]
GO

CREATE PROCEDURE [dbo].[sol_Customers_Select]
(
	@CustomerID int
)

AS

SET NOCOUNT ON

SELECT [CustomerID],
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
	[CardTypeID],
	[SolumCustomer],
	[QuickDropCustomer]
	--, 	[IsNew]
FROM [sol_Customers]
WHERE [CustomerID] = @CustomerID
GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[sol_Customers_SelectAll]
--GO

--CREATE PROCEDURE [dbo].[sol_Customers_SelectAll]

--AS

--SET NOCOUNT ON

--SELECT [CustomerID],
--	[CustomerCode],
--	[Name],
--	[Contact],
--	[Address1],
--	[Address2],
--	[City],
--	[Province],
--	[Country],
--	[PostalCode],
--	[Email],
--	[LoweredEmail],
--	[IsActive],
--	[PhoneNumber],
--	[Notes],
--	[Password],
--	[DepotID],
--	[CardNumber],
--	[CardTypeID],
--	[SolumCustomer],
--	[QuickDropCustomer],
--	[IsNew]
--FROM [sol_Customers]
--GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_SelectAllByCardTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_SelectAllByCardTypeID]
GO

CREATE PROCEDURE [dbo].[sol_Customers_SelectAllByCardTypeID]
(
	@CardTypeID int
)

AS

SET NOCOUNT ON

SELECT [CustomerID],
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
	[CardTypeID],
	[SolumCustomer],
	[QuickDropCustomer]
	--, 	[IsNew]
FROM [sol_Customers]
WHERE [CardTypeID] = @CardTypeID
GO

/******************************************************************************
--Sol_Messages
	DBCC CHECKIDENT ('sol_Messages', RESEED, 0)
	DBCC CHECKIDENT ('sol_Messages', RESEED)
	SELECT CAST(scope_identity() AS int) 
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Messages_Update]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Messages_Update]
(
	@MessageID int,
	@Name varchar(50),
	@Description varchar(256)
)

AS

SET NOCOUNT ON

UPDATE [sol_Messages] WITH (ROWLOCK)
SET [Name] = @Name,
	[Description] = @Description
WHERE [MessageID] = @MessageID
GO
/****** Object:  StoredProcedure [dbo].[sol_Messages_SelectAll]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Messages_SelectAll]

AS

SET NOCOUNT ON

SELECT [MessageID],
	[Name],
	[Description]
FROM [sol_Messages]
GO
/****** Object:  StoredProcedure [dbo].[sol_Messages_Select]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Messages_Select]
(
	@MessageID int
)

AS

SET NOCOUNT ON

SELECT [MessageID],
	[Name],
	[Description]
FROM [sol_Messages]
WHERE [MessageID] = @MessageID
GO
/****** Object:  StoredProcedure [dbo].[sol_Messages_Insert]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Messages_Insert]
(
	@Name varchar(50),
	@Description varchar(256)
)

AS

SET NOCOUNT ON
	--DBCC CHECKIDENT ('sol_Messages', RESEED, 0)
	--DBCC CHECKIDENT ('sol_Messages', RESEED)


INSERT INTO [sol_Messages]
(
	[Name],
	[Description]
)
VALUES
(
	@Name,
	@Description
)

	SELECT CAST(scope_identity() AS int)
GO
/****** Object:  StoredProcedure [dbo].[sol_Messages_Delete]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Messages_Delete]
(
	@MessageID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Messages] WITH (ROWLOCK)
WHERE [MessageID] = @MessageID
GO

/******************************************************************************
--Sol_Orders

	SELECT CAST(scope_identity() AS int) 
Comment out
[sol_Orders_Insert]
	All, moved to additional sp's

sol_Orders_SelectAllByCustomerID
	All, moved to additional sp's

Comment out Sol_Orders_Update

comment all [IsNew] references

******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[sol_Orders_Insert]
--GO

--CREATE PROCEDURE [dbo].[sol_Orders_Insert]
--(
--	@OrderType char(1),
--	@WorkStationID int,
--	@ComputerName varchar(50),
--	@UserID uniqueidentifier,
--	@UserName varchar(50),
--	@Date datetime,
--	@CashTrayID int,
--	@CustomerID int,
--	@Name varchar(50),
--	@Address1 varchar(250),
--	@Address2 varchar(250),
--	@City varchar(100),
--	@Province varchar(100),
--	@Country varchar(50),
--	@PostalCode varchar(50),
--	@TotalAmount money,
--	@DateClosed datetime,
--	@FeeID int,
--	@FeeAmount money,
--	@Status char(1),
--	@DatePaid datetime,
--	@Tax1Amount money,
--	@Tax2Amount money,
--	@Reference varchar(100),
--	@PaymentTypeID tinyint,
--	@SecurityCode nvarchar(12),
--	@Comments nvarchar(256),
--	@IsNew bit
--)

--AS

--SET NOCOUNT ON

--INSERT INTO [sol_Orders]
--(
--	[OrderType],
--	[WorkStationID],
--	[ComputerName],
--	[UserID],
--	[UserName],
--	[Date],
--	[CashTrayID],
--	[CustomerID],
--	[Name],
--	[Address1],
--	[Address2],
--	[City],
--	[Province],
--	[Country],
--	[PostalCode],
--	[TotalAmount],
--	[DateClosed],
--	[FeeID],
--	[FeeAmount],
--	[Status],
--	[DatePaid],
--	[Tax1Amount],
--	[Tax2Amount],
--	[Reference],
--	[PaymentTypeID],
--	[SecurityCode],
--	[Comments],
--	[IsNew]
--)
--VALUES
--(
--	@OrderType,
--	@WorkStationID,
--	@ComputerName,
--	@UserID,
--	@UserName,
--	@Date,
--	@CashTrayID,
--	@CustomerID,
--	@Name,
--	@Address1,
--	@Address2,
--	@City,
--	@Province,
--	@Country,
--	@PostalCode,
--	@TotalAmount,
--	@DateClosed,
--	@FeeID,
--	@FeeAmount,
--	@Status,
--	@DatePaid,
--	@Tax1Amount,
--	@Tax2Amount,
--	@Reference,
--	@PaymentTypeID,
--	@SecurityCode,
--	@Comments,
--	@IsNew
--)

--SELECT SCOPE_IDENTITY()
--GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[sol_Orders_Update]
--GO

--CREATE PROCEDURE [dbo].[sol_Orders_Update]
--(
--	@OrderID int,
--	@OrderType char(1),
--	@WorkStationID int,
--	@ComputerName varchar(50),
--	@UserID uniqueidentifier,
--	@UserName varchar(50),
--	@Date datetime,
--	@CashTrayID int,
--	@CustomerID int,
--	@Name varchar(50),
--	@Address1 varchar(250),
--	@Address2 varchar(250),
--	@City varchar(100),
--	@Province varchar(100),
--	@Country varchar(50),
--	@PostalCode varchar(50),
--	@TotalAmount money,
--	@DateClosed datetime,
--	@FeeID int,
--	@FeeAmount money,
--	@Status char(1),
--	@DatePaid datetime,
--	@Tax1Amount money,
--	@Tax2Amount money,
--	@Reference varchar(100),
--	@PaymentTypeID tinyint,
--	@SecurityCode nvarchar(12),
--	@Comments nvarchar(256),
--	@IsNew bit
--)

--AS

--SET NOCOUNT ON

--UPDATE [sol_Orders] WITH (ROWLOCK)
--SET [WorkStationID] = @WorkStationID,
--	[ComputerName] = @ComputerName,
--	[UserID] = @UserID,
--	[UserName] = @UserName,
--	[Date] = @Date,
--	[CashTrayID] = @CashTrayID,
--	[CustomerID] = @CustomerID,
--	[Name] = @Name,
--	[Address1] = @Address1,
--	[Address2] = @Address2,
--	[City] = @City,
--	[Province] = @Province,
--	[Country] = @Country,
--	[PostalCode] = @PostalCode,
--	[TotalAmount] = @TotalAmount,
--	[DateClosed] = @DateClosed,
--	[FeeID] = @FeeID,
--	[FeeAmount] = @FeeAmount,
--	[Status] = @Status,
--	[DatePaid] = @DatePaid,
--	[Tax1Amount] = @Tax1Amount,
--	[Tax2Amount] = @Tax2Amount,
--	[Reference] = @Reference,
--	[PaymentTypeID] = @PaymentTypeID,
--	[SecurityCode] = @SecurityCode,
--	[Comments] = @Comments,
--	[IsNew] = @IsNew
--WHERE [OrderID] = @OrderID	AND [OrderType] = @OrderType
--GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Orders_Delete]
(
	@OrderID int,
	@OrderType char(1)
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Orders] WITH (ROWLOCK)
WHERE [OrderID] = @OrderID
	AND [OrderType] = @OrderType
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_DeleteAllByCashTrayID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_DeleteAllByCashTrayID]
GO

CREATE PROCEDURE [dbo].[sol_Orders_DeleteAllByCashTrayID]
(
	@CashTrayID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Orders] WITH (ROWLOCK)
WHERE [CashTrayID] = @CashTrayID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_DeleteAllByCustomerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_DeleteAllByCustomerID]
GO

CREATE PROCEDURE [dbo].[sol_Orders_DeleteAllByCustomerID]
(
	@CustomerID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Orders] WITH (ROWLOCK)
WHERE [CustomerID] = @CustomerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_DeleteAllByFeeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_DeleteAllByFeeID]
GO

CREATE PROCEDURE [dbo].[sol_Orders_DeleteAllByFeeID]
(
	@FeeID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Orders] WITH (ROWLOCK)
WHERE [FeeID] = @FeeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_DeleteAllByWorkStationID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_DeleteAllByWorkStationID]
GO

CREATE PROCEDURE [dbo].[sol_Orders_DeleteAllByWorkStationID]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Orders] WITH (ROWLOCK)
WHERE [WorkStationID] = @WorkStationID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_Select]
GO

CREATE PROCEDURE [dbo].[sol_Orders_Select]
(
	@OrderID int,
	@OrderType char(1)
)

AS

SET NOCOUNT ON

SELECT [OrderID],
	[OrderType],
	[WorkStationID],
	[ComputerName],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[CustomerID],
	[Name],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[TotalAmount],
	[DateClosed],
	[FeeID],
	[FeeAmount],
	[Status],
	[DatePaid],
	[Tax1Amount],
	[Tax2Amount],
	[Reference],
	[PaymentTypeID],
	[SecurityCode],
	[Comments]
	--, 	[IsNew]
FROM [sol_Orders]
WHERE [OrderID] = @OrderID
	AND [OrderType] = @OrderType
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAll]

AS

SET NOCOUNT ON

SELECT [OrderID],
	[OrderType],
	[WorkStationID],
	[ComputerName],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[CustomerID],
	[Name],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[TotalAmount],
	[DateClosed],
	[FeeID],
	[FeeAmount],
	[Status],
	[DatePaid],
	[Tax1Amount],
	[Tax2Amount],
	[Reference],
	[PaymentTypeID],
	[SecurityCode],
	[Comments]
	--, 	[IsNew]
FROM [sol_Orders]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_SelectAllByCashTrayID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_SelectAllByCashTrayID]
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByCashTrayID]
(
	@CashTrayID int
)

AS

SET NOCOUNT ON

SELECT [OrderID],
	[OrderType],
	[WorkStationID],
	[ComputerName],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[CustomerID],
	[Name],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[TotalAmount],
	[DateClosed],
	[FeeID],
	[FeeAmount],
	[Status],
	[DatePaid],
	[Tax1Amount],
	[Tax2Amount],
	[Reference],
	[PaymentTypeID],
	[SecurityCode],
	[Comments]
	--, 	[IsNew]
FROM [sol_Orders]
WHERE [CashTrayID] = @CashTrayID
GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_SelectAllByCustomerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[sol_Orders_SelectAllByCustomerID]
--GO

--CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByCustomerID]
--(
--	@CustomerID int
--)

--AS

--SET NOCOUNT ON

--SELECT [OrderID],
--	[OrderType],
--	[WorkStationID],
--	[ComputerName],
--	[UserID],
--	[UserName],
--	[Date],
--	[CashTrayID],
--	[CustomerID],
--	[Name],
--	[Address1],
--	[Address2],
--	[City],
--	[Province],
--	[Country],
--	[PostalCode],
--	[TotalAmount],
--	[DateClosed],
--	[FeeID],
--	[FeeAmount],
--	[Status],
--	[DatePaid],
--	[Tax1Amount],
--	[Tax2Amount],
--	[Reference],
--	[PaymentTypeID],
--	[SecurityCode],
--	[Comments],
--	[IsNew]
--FROM [sol_Orders]
--WHERE [CustomerID] = @CustomerID
--GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_SelectAllByFeeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_SelectAllByFeeID]
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByFeeID]
(
	@FeeID int
)

AS

SET NOCOUNT ON

SELECT [OrderID],
	[OrderType],
	[WorkStationID],
	[ComputerName],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[CustomerID],
	[Name],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[TotalAmount],
	[DateClosed],
	[FeeID],
	[FeeAmount],
	[Status],
	[DatePaid],
	[Tax1Amount],
	[Tax2Amount],
	[Reference],
	[PaymentTypeID],
	[SecurityCode],
	[Comments]
	--, 	[IsNew]
FROM [sol_Orders]
WHERE [FeeID] = @FeeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_SelectAllByWorkStationID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_SelectAllByWorkStationID]
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByWorkStationID]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

SELECT [OrderID],
	[OrderType],
	[WorkStationID],
	[ComputerName],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[CustomerID],
	[Name],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[TotalAmount],
	[DateClosed],
	[FeeID],
	[FeeAmount],
	[Status],
	[DatePaid],
	[Tax1Amount],
	[Tax2Amount],
	[Reference],
	[PaymentTypeID],
	[SecurityCode],
	[Comments]
	--, 	[IsNew]
FROM [sol_Orders]
WHERE [WorkStationID] = @WorkStationID
GO

/******************************************************************************
--Sol_OrdersDetail
	--DBCC CHECKIDENT ('sol_OrdersDetail', RESEED, 1)
	--DBCC CHECKIDENT ('sol_OrdersDetail', RESEED)
	SELECT CAST(scope_identity() AS int) 

	*********************************************
	add 
	ORDER BY [Description] ASC
	at the end of sp
	sol_OrdersDetail_SelectAllByOrderID_OrderType
	*********************************************
	Comment out Sol_OrdersDetail_Update

	comment all [IsNew] references

	Change in sol_OrdersDetail_Insert
	In Values:
		GetDate(), --@Date,			-- use sql server date

******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_Insert]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_Insert]
(
	@OrderID int,
	@OrderType char(1),
	@Date datetime,
	@CategoryID int,
	@ProductID int,
	@Description varchar(100),
	@Quantity int,
	@Price money,
	@Amount money,
	@Status char(1),
	@CategoryButtonID int,
	@BagID int,
	--@IsNew bit,
	@ConveyorID int,
	@StageID int
)

AS

SET NOCOUNT ON

INSERT INTO [sol_OrdersDetail]
(
	[OrderID],
	[OrderType],
	[Date],
	[CategoryID],
	[ProductID],
	[Description],
	[Quantity],
	[Price],
	[Amount],
	[Status],
	[CategoryButtonID],
	[BagID],
	--[IsNew],
	[ConveyorID],
	[StageID]
)
VALUES
(
	@OrderID,
	@OrderType,
	GetDate(), --@Date,			-- use sql server date
	@CategoryID,
	@ProductID,
	@Description,
	@Quantity,
	@Price,
	@Amount,
	@Status,
	@CategoryButtonID,
	@BagID,
	--@IsNew,
	@ConveyorID,
	@StageID
)

	SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[sol_OrdersDetail_Update]
--GO

--CREATE PROCEDURE [dbo].[sol_OrdersDetail_Update]
--(
--	@DetailID int,
--	@OrderID int,
--	@OrderType char(1),
--	@Date datetime,
--	@CategoryID int,
--	@ProductID int,
--	@Description varchar(100),
--	@Quantity int,
--	@Price money,
--	@Amount money,
--	@Status char(1),
--	@CategoryButtonID int,
--	@BagID int,
--	@IsNew bit,
--	@ConveyorID int,
--	@StageID int
--)

--AS

--SET NOCOUNT ON

--UPDATE [sol_OrdersDetail] WITH (ROWLOCK)
--SET [OrderID] = @OrderID,
--	[OrderType] = @OrderType,
--	[Date] = @Date,
--	[CategoryID] = @CategoryID,
--	[ProductID] = @ProductID,
--	[Description] = @Description,
--	[Quantity] = @Quantity,
--	[Price] = @Price,
--	[Amount] = @Amount,
--	[Status] = @Status,
--	[CategoryButtonID] = @CategoryButtonID,
--	[BagID] = @BagID,
--	[IsNew] = @IsNew,
--	[ConveyorID] = @ConveyorID,
--	[StageID] = @StageID
--WHERE [DetailID] = @DetailID
--GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_Delete]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_Delete]
(
	@DetailID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_OrdersDetail] WITH (ROWLOCK)
WHERE [DetailID] = @DetailID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_DeleteAllByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_DeleteAllByCategoryID]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_DeleteAllByCategoryID]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_OrdersDetail] WITH (ROWLOCK)
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_DeleteAllByOrderID_OrderType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_DeleteAllByOrderID_OrderType]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_DeleteAllByOrderID_OrderType]
(
	@OrderID int,
	@OrderType char(1)
)

AS

SET NOCOUNT ON

DELETE FROM [sol_OrdersDetail] WITH (ROWLOCK)
WHERE [OrderID] = @OrderID
	AND [OrderType] = @OrderType
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_Select]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_Select]
(
	@DetailID int
)

AS

SET NOCOUNT ON

SELECT [DetailID],
	[OrderID],
	[OrderType],
	[Date],
	[CategoryID],
	[ProductID],
	[Description],
	[Quantity],
	[Price],
	[Amount],
	[Status],
	[CategoryButtonID],
	[BagID],
	--[IsNew],
	[ConveyorID],
	[StageID]
FROM [sol_OrdersDetail]
WHERE [DetailID] = @DetailID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_SelectAll]

AS

SET NOCOUNT ON

SELECT [DetailID],
	[OrderID],
	[OrderType],
	[Date],
	[CategoryID],
	[ProductID],
	[Description],
	[Quantity],
	[Price],
	[Amount],
	[Status],
	[CategoryButtonID],
	[BagID],
	--[IsNew],
	[ConveyorID],
	[StageID]
FROM [sol_OrdersDetail]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_SelectAllByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_SelectAllByCategoryID]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_SelectAllByCategoryID]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

SELECT [DetailID],
	[OrderID],
	[OrderType],
	[Date],
	[CategoryID],
	[ProductID],
	[Description],
	[Quantity],
	[Price],
	[Amount],
	[Status],
	[CategoryButtonID],
	[BagID],
	--[IsNew],
	[ConveyorID],
	[StageID]
FROM [sol_OrdersDetail]
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_OrdersDetail_SelectAllByOrderID_OrderType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_OrdersDetail_SelectAllByOrderID_OrderType]
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_SelectAllByOrderID_OrderType]
(
	@OrderID int,
	@OrderType char(1)
)

AS

SET NOCOUNT ON

SELECT [DetailID],
	[OrderID],
	[OrderType],
	[Date],
	[CategoryID],
	[ProductID],
	[Description],
	[Quantity],
	[Price],
	[Amount],
	[Status],
	[CategoryButtonID],
	[BagID],
	--[IsNew],
	[ConveyorID],
	[StageID]
FROM [sol_OrdersDetail]
WHERE [OrderID] = @OrderID
	AND [OrderType] = @OrderType
ORDER BY [Description] ASC

GO

/******************************************************************************
--Sol_ContanierTypes
	SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_ContainerTypes_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_ContainerTypes_Insert]
GO

CREATE PROCEDURE [dbo].[sol_ContainerTypes_Insert]
(
	@Description varchar(50)
)

AS

SET NOCOUNT ON

INSERT INTO [sol_ContainerTypes]
(
	[Description]
)
VALUES
(
	@Description
)

	SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_ContainerTypes_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_ContainerTypes_Update]
GO

CREATE PROCEDURE [dbo].[sol_ContainerTypes_Update]
(
	@ContainerTypeID int,
	@Description varchar(50)
)

AS

SET NOCOUNT ON

UPDATE [sol_ContainerTypes] WITH (ROWLOCK)
SET [Description] = @Description
WHERE [ContainerTypeID] = @ContainerTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_ContainerTypes_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_ContainerTypes_Delete]
GO

CREATE PROCEDURE [dbo].[sol_ContainerTypes_Delete]
(
	@ContainerTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_ContainerTypes] WITH (ROWLOCK)
WHERE [ContainerTypeID] = @ContainerTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_ContainerTypes_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_ContainerTypes_Select]
GO

CREATE PROCEDURE [dbo].[sol_ContainerTypes_Select]
(
	@ContainerTypeID int
)

AS

SET NOCOUNT ON

SELECT [ContainerTypeID],
	[Description]
FROM [sol_ContainerTypes]
WHERE [ContainerTypeID] = @ContainerTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_ContainerTypes_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_ContainerTypes_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_ContainerTypes_SelectAll]

AS

SET NOCOUNT ON

SELECT [ContainerTypeID],
	[Description]
FROM [sol_ContainerTypes]
GO

/******************************************************************************
--Sol_Containers
	SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Containers_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Containers_Insert]
GO

CREATE PROCEDURE [dbo].[sol_Containers_Insert]
(
	@Description varchar(100),
	@ShortDescription varchar(50),
	@ContainerTypeID int,
	@ShippingContainerID int,
	@ShippingContainerTypeID int
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Containers]
(
	[Description],
	[ShortDescription],
	[ContainerTypeID],
	[ShippingContainerID],
	[ShippingContainerTypeID]
)
VALUES
(
	@Description,
	@ShortDescription,
	@ContainerTypeID,
	@ShippingContainerID,
	@ShippingContainerTypeID
)

	SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Containers_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Containers_Update]
GO

CREATE PROCEDURE [dbo].[sol_Containers_Update]
(
	@ContainerID int,
	@Description varchar(100),
	@ShortDescription varchar(50),
	@ContainerTypeID int,
	@ShippingContainerID int,
	@ShippingContainerTypeID int
)

AS

SET NOCOUNT ON

UPDATE [sol_Containers] WITH (ROWLOCK)
SET [Description] = @Description,
	[ShortDescription] = @ShortDescription,
	[ContainerTypeID] = @ContainerTypeID,
	[ShippingContainerID] = @ShippingContainerID,
	[ShippingContainerTypeID] = @ShippingContainerTypeID
WHERE [ContainerID] = @ContainerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Containers_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Containers_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Containers_Delete]
(
	@ContainerID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Containers] WITH (ROWLOCK)
WHERE [ContainerID] = @ContainerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Containers_DeleteAllByContainerTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Containers_DeleteAllByContainerTypeID]
GO

CREATE PROCEDURE [dbo].[sol_Containers_DeleteAllByContainerTypeID]
(
	@ContainerTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Containers] WITH (ROWLOCK)
WHERE [ContainerTypeID] = @ContainerTypeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Containers_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Containers_Select]
GO

CREATE PROCEDURE [dbo].[sol_Containers_Select]
(
	@ContainerID int
)

AS

SET NOCOUNT ON

SELECT [ContainerID],
	[Description],
	[ShortDescription],
	[ContainerTypeID],
	[ShippingContainerID],
	[ShippingContainerTypeID]
FROM [sol_Containers]
WHERE [ContainerID] = @ContainerID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Containers_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Containers_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_Containers_SelectAll]

AS

SET NOCOUNT ON

SELECT [ContainerID],
	[Description],
	[ShortDescription],
	[ContainerTypeID],
	[ShippingContainerID],
	[ShippingContainerTypeID]
FROM [sol_Containers]
GO


/******************************************************************************
--Sol_Categories 
	SELECT CAST(scope_identity() AS int) 

******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Categories_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Categories_Insert]
GO

CREATE PROCEDURE [dbo].[Sol_Categories_Insert]
(
	@Description varchar(100),
	@RefundAmount money,
	@SubContainerQuantity int,
	@StagingMethodID int,
	@StagingProductID int
)

AS

SET NOCOUNT ON

INSERT INTO [Sol_Categories]
(
	[Description],
	[RefundAmount],
	[SubContainerQuantity],
	[StagingMethodID],
	[StagingProductID]
)
VALUES
(
	@Description,
	@RefundAmount,
	@SubContainerQuantity,
	@StagingMethodID,
	@StagingProductID
)

	SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Categories_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Categories_Update]
GO

CREATE PROCEDURE [dbo].[Sol_Categories_Update]
(
	@CategoryID int,
	@Description varchar(100),
	@RefundAmount money,
	@SubContainerQuantity int,
	@StagingMethodID int,
	@StagingProductID int
)

AS

SET NOCOUNT ON

UPDATE [Sol_Categories] WITH (ROWLOCK)
SET [Description] = @Description,
	[RefundAmount] = @RefundAmount,
	[SubContainerQuantity] = @SubContainerQuantity,
	[StagingMethodID] = @StagingMethodID,
	[StagingProductID] = @StagingProductID
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Categories_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Categories_Delete]
GO

CREATE PROCEDURE [dbo].[Sol_Categories_Delete]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_Categories] WITH (ROWLOCK)
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Categories_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Categories_Select]
GO

CREATE PROCEDURE [dbo].[Sol_Categories_Select]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

SELECT [CategoryID],
	[Description],
	[RefundAmount],
	[SubContainerQuantity],
	[StagingMethodID],
	[StagingProductID]
FROM [Sol_Categories]
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_Categories_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_Categories_SelectAll]
GO

CREATE PROCEDURE [dbo].[Sol_Categories_SelectAll]

AS

SET NOCOUNT ON

SELECT [CategoryID],
	[Description],
	[RefundAmount],
	[SubContainerQuantity],
	[StagingMethodID],
	[StagingProductID]
FROM [Sol_Categories]
GO

/******************************************************************************
--Sol_StandardDozen
	SELECT CAST(scope_identity() AS int) 
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_StandardDozen_Update]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_StandardDozen_Update]
(
	@StandardDozenID int,
	@Quantity int
)

AS

SET NOCOUNT ON

UPDATE [sol_StandardDozen] WITH (ROWLOCK)
SET [Quantity] = @Quantity
WHERE [StandardDozenID] = @StandardDozenID
GO
/****** Object:  StoredProcedure [dbo].[sol_StandardDozen_SelectAll]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_StandardDozen_SelectAll]

AS

SET NOCOUNT ON

SELECT [StandardDozenID],
	[Quantity]
FROM [sol_StandardDozen]
GO
/****** Object:  StoredProcedure [dbo].[sol_StandardDozen_Select]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_StandardDozen_Select]
(
	@StandardDozenID int
)

AS

SET NOCOUNT ON

SELECT [StandardDozenID],
	[Quantity]
FROM [sol_StandardDozen]
WHERE [StandardDozenID] = @StandardDozenID
GO
/****** Object:  StoredProcedure [dbo].[sol_StandardDozen_Insert]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_StandardDozen_Insert]
(
	@Quantity int
)

AS

SET NOCOUNT ON
	--DBCC CHECKIDENT ('sol_StandardDozen', RESEED, 0)
	--DBCC CHECKIDENT ('sol_StandardDozen', RESEED)

INSERT INTO [sol_StandardDozen]
(
	[Quantity]
)
VALUES
(
	@Quantity
)

	SELECT CAST(scope_identity() AS int) 
GO
/****** Object:  StoredProcedure [dbo].[sol_StandardDozen_Delete]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_StandardDozen_Delete]
(
	@StandardDozenID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_StandardDozen] WITH (ROWLOCK)
WHERE [StandardDozenID] = @StandardDozenID
GO

/******************************************************************************
--Sol_Agencies
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Agencies_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Agencies_Insert]
GO

CREATE PROCEDURE [dbo].[sol_Agencies_Insert]
(
	@Name varchar(50),
	@Description varchar(50),
	@Address1 varchar(250),
	@Address2 varchar(250),
	@City varchar(100),
	@Province varchar(100),
	@Country varchar(50),
	@PostalCode varchar(50),
	@VendorID nvarchar(50),
	@AutoGenerateTagNumber bit,
	@AutoGenerateRBillNumber bit
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Agencies]
(
	[Name],
	[Description],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[VendorID],
	[AutoGenerateTagNumber],
	[AutoGenerateRBillNumber]
)
VALUES
(
	@Name,
	@Description,
	@Address1,
	@Address2,
	@City,
	@Province,
	@Country,
	@PostalCode,
	@VendorID,
	@AutoGenerateTagNumber,
	@AutoGenerateRBillNumber
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Agencies_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Agencies_Update]
GO

CREATE PROCEDURE [dbo].[sol_Agencies_Update]
(
	@AgencyID int,
	@Name varchar(50),
	@Description varchar(50),
	@Address1 varchar(250),
	@Address2 varchar(250),
	@City varchar(100),
	@Province varchar(100),
	@Country varchar(50),
	@PostalCode varchar(50),
	@VendorID nvarchar(50),
	@AutoGenerateTagNumber bit,
	@AutoGenerateRBillNumber bit
)

AS

SET NOCOUNT ON

UPDATE [sol_Agencies] WITH (ROWLOCK)
SET [Name] = @Name,
	[Description] = @Description,
	[Address1] = @Address1,
	[Address2] = @Address2,
	[City] = @City,
	[Province] = @Province,
	[Country] = @Country,
	[PostalCode] = @PostalCode,
	[VendorID] = @VendorID,
	[AutoGenerateTagNumber] = @AutoGenerateTagNumber,
	[AutoGenerateRBillNumber] = @AutoGenerateRBillNumber
WHERE [AgencyID] = @AgencyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Agencies_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Agencies_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Agencies_Delete]
(
	@AgencyID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Agencies] WITH (ROWLOCK)
WHERE [AgencyID] = @AgencyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Agencies_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Agencies_Select]
GO

CREATE PROCEDURE [dbo].[sol_Agencies_Select]
(
	@AgencyID int
)

AS

SET NOCOUNT ON

SELECT [AgencyID],
	[Name],
	[Description],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[VendorID],
	[AutoGenerateTagNumber],
	[AutoGenerateRBillNumber]
FROM [sol_Agencies]
WHERE [AgencyID] = @AgencyID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Agencies_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Agencies_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_Agencies_SelectAll]

AS

SET NOCOUNT ON

SELECT [AgencyID],
	[Name],
	[Description],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[VendorID],
	[AutoGenerateTagNumber],
	[AutoGenerateRBillNumber]
FROM [sol_Agencies]
GO


/******************************************************************************
--Sol_WorkStations
	SELECT CAST(scope_identity() AS int) 

******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_WorkStations_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_WorkStations_Insert]
GO

CREATE PROCEDURE [dbo].[sol_WorkStations_Insert]
(
	@Name varchar(50),
	@Description varchar(50),
	@Location varchar(50),
	@ConveyorID int
)

AS

SET NOCOUNT ON

INSERT INTO [sol_WorkStations]
(
	[Name],
	[Description],
	[Location],
	[ConveyorID]
)
VALUES
(
	@Name,
	@Description,
	@Location,
	@ConveyorID
)

	SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_WorkStations_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_WorkStations_Update]
GO

CREATE PROCEDURE [dbo].[sol_WorkStations_Update]
(
	@WorkStationID int,
	@Name varchar(50),
	@Description varchar(50),
	@Location varchar(50),
	@ConveyorID int
)

AS

SET NOCOUNT ON

UPDATE [sol_WorkStations] WITH (ROWLOCK)
SET [Name] = @Name,
	[Description] = @Description,
	[Location] = @Location,
	[ConveyorID] = @ConveyorID
WHERE [WorkStationID] = @WorkStationID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_WorkStations_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_WorkStations_Delete]
GO

CREATE PROCEDURE [dbo].[sol_WorkStations_Delete]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_WorkStations] WITH (ROWLOCK)
WHERE [WorkStationID] = @WorkStationID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_WorkStations_DeleteAllByConveyorID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_WorkStations_DeleteAllByConveyorID]
GO

CREATE PROCEDURE [dbo].[sol_WorkStations_DeleteAllByConveyorID]
(
	@ConveyorID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_WorkStations] WITH (ROWLOCK)
WHERE [ConveyorID] = @ConveyorID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_WorkStations_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_WorkStations_Select]
GO

CREATE PROCEDURE [dbo].[sol_WorkStations_Select]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

SELECT [WorkStationID],
	[Name],
	[Description],
	[Location],
	[ConveyorID]
FROM [sol_WorkStations]
WHERE [WorkStationID] = @WorkStationID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_WorkStations_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_WorkStations_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_WorkStations_SelectAll]

AS

SET NOCOUNT ON

SELECT [WorkStationID],
	[Name],
	[Description],
	[Location],
	[ConveyorID]
FROM [sol_WorkStations]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_WorkStations_SelectAllByConveyorID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_WorkStations_SelectAllByConveyorID]
GO

CREATE PROCEDURE [dbo].[sol_WorkStations_SelectAllByConveyorID]
(
	@ConveyorID int
)

AS

SET NOCOUNT ON

SELECT [WorkStationID],
	[Name],
	[Description],
	[Location],
	[ConveyorID]
FROM [sol_WorkStations]
WHERE [ConveyorID] = @ConveyorID
GO


/******************************************************************************
--Sol_CategoryButtons

sol_CategoryButtons_Insert
	change SELECT CAST(scope_identity() AS int) 

sol_CategoryButtons_SelectAllByWorkStationID
	add ORDER BY [LocationY],[LocationX] ASC

change all selects to *
keep sol_CategoryButtons2 sp

******************************************************************************/
/*
sol_CategoryButtons2 sp's
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_Insert2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_Insert2]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_Insert2]
(
	@WorkStationID int,
	@ControlType tinyint,
	@Description varchar(50),
	@DefaultQuantity int,
	@CategoryID int,
	@LocationX int,
	@LocationY int,
	@Width int,
	@Height int,
	@Font varchar(250),
	@FontStyle varchar(50),
	@ForeColor varchar(50),
	@BackColor varchar(50),
	@ImageIndex int,
	@ImagePath varchar(255),
	@SubContainerMaxCount int,
	@SubContainerCounter int,
	@ImageSize tinyint,
	@SubContainerCountDown bit,
	@MaxCountPerLine int,
	@ForeColorArgb int,
	@BackColorArgb int
)

AS

SET NOCOUNT ON

INSERT INTO [sol_CategoryButtons]
(
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
VALUES
(
	@WorkStationID,
	@ControlType,
	@Description,
	@DefaultQuantity,
	@CategoryID,
	@LocationX,
	@LocationY,
	@Width,
	@Height,
	@Font,
	@FontStyle,
	@ForeColor,
	@BackColor,
	@ImageIndex,
	@ImagePath,
	@SubContainerMaxCount,
	@SubContainerCounter,
	@ImageSize,
	@SubContainerCountDown,
	@MaxCountPerLine,
	@ForeColorArgb,
	@BackColorArgb
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_Update2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_Update2]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_Update2]
(
	@CategoryButtonID int,
	@WorkStationID int,
	@ControlType tinyint,
	@Description varchar(50),
	@DefaultQuantity int,
	@CategoryID int,
	@LocationX int,
	@LocationY int,
	@Width int,
	@Height int,
	@Font varchar(250),
	@FontStyle varchar(50),
	@ForeColor varchar(50),
	@BackColor varchar(50),
	@ImageIndex int,
	@ImagePath varchar(255),
	@SubContainerMaxCount int,
	@SubContainerCounter int,
	@ImageSize tinyint,
	@SubContainerCountDown bit,
	@MaxCountPerLine int,
	@ForeColorArgb int,
	@BackColorArgb int
)

AS

SET NOCOUNT ON

UPDATE [sol_CategoryButtons] WITH (ROWLOCK)
SET [WorkStationID] = @WorkStationID,
	[ControlType] = @ControlType,
	[Description] = @Description,
	[DefaultQuantity] = @DefaultQuantity,
	[CategoryID] = @CategoryID,
	[LocationX] = @LocationX,
	[LocationY] = @LocationY,
	[Width] = @Width,
	[Height] = @Height,
	[Font] = @Font,
	[FontStyle] = @FontStyle,
	[ForeColor] = @ForeColor,
	[BackColor] = @BackColor,
	[ImageIndex] = @ImageIndex,
	[ImagePath] = @ImagePath,
	[SubContainerMaxCount] = @SubContainerMaxCount,
	[SubContainerCounter] = @SubContainerCounter,
	[ImageSize] = @ImageSize,
	[SubContainerCountDown] = @SubContainerCountDown,
	[MaxCountPerLine] = @MaxCountPerLine,
	[ForeColorArgb] = @ForeColorArgb,
	[BackColorArgb] = @BackColorArgb
WHERE [CategoryButtonID] = @CategoryButtonID
GO

/*
normal sp's
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons3_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_Insert]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_Insert]
(
	@WorkStationID int,
	@ControlType tinyint,
	@Description varchar(50),
	@DefaultQuantity int,
	@CategoryID int,
	@LocationX int,
	@LocationY int,
	@Width int,
	@Height int,
	@Font varchar(250),
	@FontStyle varchar(50),
	@ForeColor varchar(50),
	@BackColor varchar(50),
	@ImageIndex int,
	@ImagePath varchar(255),
	@SubContainerMaxCount int,
	@SubContainerCounter int,
	@ImageSize tinyint,
	@SubContainerCountDown bit,
	@MaxCountPerLine int
)

AS

SET NOCOUNT ON

INSERT INTO [sol_CategoryButtons]
(
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
	[MaxCountPerLine]
)
VALUES
(
	@WorkStationID,
	@ControlType,
	@Description,
	@DefaultQuantity,
	@CategoryID,
	@LocationX,
	@LocationY,
	@Width,
	@Height,
	@Font,
	@FontStyle,
	@ForeColor,
	@BackColor,
	@ImageIndex,
	@ImagePath,
	@SubContainerMaxCount,
	@SubContainerCounter,
	@ImageSize,
	@SubContainerCountDown,
	@MaxCountPerLine
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_Update]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_Update]
(
	@CategoryButtonID int,
	@WorkStationID int,
	@ControlType tinyint,
	@Description varchar(50),
	@DefaultQuantity int,
	@CategoryID int,
	@LocationX int,
	@LocationY int,
	@Width int,
	@Height int,
	@Font varchar(250),
	@FontStyle varchar(50),
	@ForeColor varchar(50),
	@BackColor varchar(50),
	@ImageIndex int,
	@ImagePath varchar(255),
	@SubContainerMaxCount int,
	@SubContainerCounter int,
	@ImageSize tinyint,
	@SubContainerCountDown bit,
	@MaxCountPerLine int
)

AS

SET NOCOUNT ON

UPDATE [sol_CategoryButtons] WITH (ROWLOCK)
SET [WorkStationID] = @WorkStationID,
	[ControlType] = @ControlType,
	[Description] = @Description,
	[DefaultQuantity] = @DefaultQuantity,
	[CategoryID] = @CategoryID,
	[LocationX] = @LocationX,
	[LocationY] = @LocationY,
	[Width] = @Width,
	[Height] = @Height,
	[Font] = @Font,
	[FontStyle] = @FontStyle,
	[ForeColor] = @ForeColor,
	[BackColor] = @BackColor,
	[ImageIndex] = @ImageIndex,
	[ImagePath] = @ImagePath,
	[SubContainerMaxCount] = @SubContainerMaxCount,
	[SubContainerCounter] = @SubContainerCounter,
	[ImageSize] = @ImageSize,
	[SubContainerCountDown] = @SubContainerCountDown,
	[MaxCountPerLine] = @MaxCountPerLine
WHERE [CategoryButtonID] = @CategoryButtonID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_Delete]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_Delete]
(
	@CategoryButtonID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_CategoryButtons] WITH (ROWLOCK)
WHERE [CategoryButtonID] = @CategoryButtonID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_DeleteAllByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_DeleteAllByCategoryID]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_DeleteAllByCategoryID]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_CategoryButtons] WITH (ROWLOCK)
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_DeleteAllByWorkStationID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_DeleteAllByWorkStationID]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_DeleteAllByWorkStationID]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_CategoryButtons] WITH (ROWLOCK)
WHERE [WorkStationID] = @WorkStationID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_Select]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_Select]
(
	@CategoryButtonID int
)

AS

SET NOCOUNT ON

SELECT *
	--[CategoryButtonID],
	--[WorkStationID],
	--[ControlType],
	--[Description],
	--[DefaultQuantity],
	--[CategoryID],
	--[LocationX],
	--[LocationY],
	--[Width],
	--[Height],
	--[Font],
	--[FontStyle],
	--[ForeColor],
	--[BackColor],
	--[ImageIndex],
	--[ImagePath],
	--[SubContainerMaxCount],
	--[SubContainerCounter],
	--[ImageSize],
	--[SubContainerCountDown],
	--[MaxCountPerLine],
	--[ForeColorArgb],
	--[BackColorArgb]
FROM [sol_CategoryButtons]
WHERE [CategoryButtonID] = @CategoryButtonID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_SelectAll]

AS

SET NOCOUNT ON

SELECT *
	--[CategoryButtonID],
	--[WorkStationID],
	--[ControlType],
	--[Description],
	--[DefaultQuantity],
	--[CategoryID],
	--[LocationX],
	--[LocationY],
	--[Width],
	--[Height],
	--[Font],
	--[FontStyle],
	--[ForeColor],
	--[BackColor],
	--[ImageIndex],
	--[ImagePath],
	--[SubContainerMaxCount],
	--[SubContainerCounter],
	--[ImageSize],
	--[SubContainerCountDown],
	--[MaxCountPerLine],
	--[ForeColorArgb],
	--[BackColorArgb]
FROM [sol_CategoryButtons]
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_SelectAllByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_SelectAllByCategoryID]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_SelectAllByCategoryID]
(
	@CategoryID int
)

AS

SET NOCOUNT ON

SELECT *
	--[CategoryButtonID],
	--[WorkStationID],
	--[ControlType],
	--[Description],
	--[DefaultQuantity],
	--[CategoryID],
	--[LocationX],
	--[LocationY],
	--[Width],
	--[Height],
	--[Font],
	--[FontStyle],
	--[ForeColor],
	--[BackColor],
	--[ImageIndex],
	--[ImagePath],
	--[SubContainerMaxCount],
	--[SubContainerCounter],
	--[ImageSize],
	--[SubContainerCountDown],
	--[MaxCountPerLine],
	--[ForeColorArgb],
	--[BackColorArgb]
FROM [sol_CategoryButtons]
WHERE [CategoryID] = @CategoryID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CategoryButtons_SelectAllByWorkStationID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CategoryButtons_SelectAllByWorkStationID]
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_SelectAllByWorkStationID]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

SELECT *
	--[CategoryButtonID],
	--[WorkStationID],
	--[ControlType],
	--[Description],
	--[DefaultQuantity],
	--[CategoryID],
	--[LocationX],
	--[LocationY],
	--[Width],
	--[Height],
	--[Font],
	--[FontStyle],
	--[ForeColor],
	--[BackColor],
	--[ImageIndex],
	--[ImagePath],
	--[SubContainerMaxCount],
	--[SubContainerCounter],
	--[ImageSize],
	--[SubContainerCountDown],
	--[MaxCountPerLine],
	--[ForeColorArgb],
	--[BackColorArgb]
FROM [sol_CategoryButtons]
WHERE [WorkStationID] = @WorkStationID
ORDER BY [LocationY],[LocationX] ASC

GO

/****** Object:  StoredProcedure [dbo].[sol_CategoryButtons_SelectAllByButtonType]    Script Date: 06/04/2016 01:07:16 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_CategoryButtons_SelectAllByButtonType]
(
	--@WorkStationID int,
	@ButtonType binary(1)
)

AS

SET NOCOUNT ON

IF(@ButtonType = 1)
BEGIN
	SELECT *
	FROM [sol_CategoryButtons]
	WHERE --[WorkStationID] = @WorkStationID AND 
	([ControlType] = 0 OR [ControlType] = 1)
	ORDER BY [LocationY],[LocationX] ASC
END
ELSE 
BEGIN
	SELECT *
	FROM [sol_CategoryButtons]
	WHERE --[WorkStationID] = @WorkStationID AND 
	[ControlType] = @ButtonType
	ORDER BY [LocationY],[LocationX] ASC
END
GO


/****** Object:  StoredProcedure [dbo].[sol_CategoryButtons_SelectAllByPaging]    Script Date: 08/04/2016 09:45:17 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_CategoryButtons_SelectAllByPaging]
(
	--@WorkStationID int,
	--@ButtonType binary(1),	  --needed only for ControlType = 4
	@PageNumber int,			--1
	@PageSize int,				--14
	@LastPage INT OUTPUT
)

AS

SET NOCOUNT ON

	select @LastPage = count(*) from sol_CategoryButtons where [ControlType] = 4
	set @LastPage = Convert(int,  @LastPage / @PageSize)+1

	if(@PageSize <0)
	BEGIN
		set @PageNumber = @LastPage;
	END;

    with query as
    (
       select *, ROW_NUMBER() OVER(ORDER BY CategoryButtonID ASC) as line from sol_CategoryButtons where [ControlType] = 4 --@ButtonType
    )
    select top (@pagesize) *, 
       (SELECT MAX(line) FROM query) AS total 
    from query
    where line > (@pagenumber - 1) * @pagesize

GO

/******************************************************************************
--Sol_QuantityButtons
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[Sol_QuantityButtons_Update]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_QuantityButtons_Update]
(
	@QuantityButtonID int,
	@WorkStationID int,
	@ControlType tinyint,
	@Description varchar(50),
	@DefaultQuantity int,
	@CategoryID int,
	@LocationX int,
	@LocationY int,
	@Width int,
	@Height int,
	@Font varchar(250),
	@FontStyle varchar(50),
	@ForeColor varchar(50),
	@BackColor varchar(50)
)

AS

SET NOCOUNT ON

UPDATE [Sol_QuantityButtons] WITH (ROWLOCK)
SET [WorkStationID] = @WorkStationID,
	[ControlType] = @ControlType,
	[Description] = @Description,
	[DefaultQuantity] = @DefaultQuantity,
	[CategoryID] = @CategoryID,
	[LocationX] = @LocationX,
	[LocationY] = @LocationY,
	[Width] = @Width,
	[Height] = @Height,
	[Font] = @Font,
	[FontStyle] = @FontStyle,
	[ForeColor] = @ForeColor,
	[BackColor] = @BackColor
WHERE [QuantityButtonID] = @QuantityButtonID
GO
/****** Object:  StoredProcedure [dbo].[Sol_QuantityButtons_SelectAllByWorkStationID]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_QuantityButtons_SelectAllByWorkStationID]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

SELECT [QuantityButtonID],
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
FROM [Sol_QuantityButtons]
WHERE [WorkStationID] = @WorkStationID
GO
/****** Object:  StoredProcedure [dbo].[Sol_QuantityButtons_SelectAll]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_QuantityButtons_SelectAll]

AS

SET NOCOUNT ON

SELECT [QuantityButtonID],
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
FROM [Sol_QuantityButtons]
GO
/****** Object:  StoredProcedure [dbo].[Sol_QuantityButtons_Select]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_QuantityButtons_Select]
(
	@QuantityButtonID int
)

AS

SET NOCOUNT ON

SELECT [QuantityButtonID],
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
FROM [Sol_QuantityButtons]
WHERE [QuantityButtonID] = @QuantityButtonID
GO
/****** Object:  StoredProcedure [dbo].[Sol_QuantityButtons_Insert]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_QuantityButtons_Insert]
(
	@WorkStationID int,
	@ControlType tinyint,
	@Description varchar(50),
	@DefaultQuantity int,
	@CategoryID int,
	@LocationX int,
	@LocationY int,
	@Width int,
	@Height int,
	@Font varchar(250),
	@FontStyle varchar(50),
	@ForeColor varchar(50),
	@BackColor varchar(50)
)

AS

SET NOCOUNT ON
	--DBCC CHECKIDENT ('Sol_QuantityButtons', RESEED, 1)
	--DBCC CHECKIDENT ('Sol_QuantityButtons', RESEED)

INSERT INTO [Sol_QuantityButtons]
(
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
VALUES
(
	@WorkStationID,
	@ControlType,
	@Description,
	@DefaultQuantity,
	@CategoryID,
	@LocationX,
	@LocationY,
	@Width,
	@Height,
	@Font,
	@FontStyle,
	@ForeColor,
	@BackColor
)

SELECT CAST(scope_identity() AS int) 
GO
/****** Object:  StoredProcedure [dbo].[Sol_QuantityButtons_DeleteAllByWorkStationID]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_QuantityButtons_DeleteAllByWorkStationID]
(
	@WorkStationID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_QuantityButtons] WITH (ROWLOCK)
WHERE [WorkStationID] = @WorkStationID
GO
/****** Object:  StoredProcedure [dbo].[Sol_QuantityButtons_Delete]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_QuantityButtons_Delete]
(
	@QuantityButtonID int
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_QuantityButtons] WITH (ROWLOCK)
WHERE [QuantityButtonID] = @QuantityButtonID
GO

/******************************************************************************
--Sol_Shipment
	SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Shipment_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Shipment_Insert]
GO

CREATE PROCEDURE [dbo].[sol_Shipment_Insert]
(
	@UserID uniqueidentifier,
	@UserName nvarchar(256),
	@RBillNumber nvarchar(50),
	@Date datetime,
	@AgencyID int,
	@AgencyName varchar(50),
	@AgencyAddress1 varchar(250),
	@AgencyAddress2 varchar(250),
	@AgencyCity varchar(100),
	@AgencyProvince varchar(100),
	@AgencyCountry varchar(50),
	@AgencyPostalCode varchar(50),
	@Status char(1),
	@CarrierID int,
	@PlantID int,
	@TrailerNumber nvarchar(50),
	@ProBillNumber nvarchar(50),
	@ShippedDate datetime,
	@SealNumber nvarchar(50),
	@LoadReference nvarchar(50),
	@eRBillTransmitted bit
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Shipment]
(
	[UserID],
	[UserName],
	[RBillNumber],
	[Date],
	[AgencyID],
	[AgencyName],
	[AgencyAddress1],
	[AgencyAddress2],
	[AgencyCity],
	[AgencyProvince],
	[AgencyCountry],
	[AgencyPostalCode],
	[Status],
	[CarrierID],
	[PlantID],
	[TrailerNumber],
	[ProBillNumber],
	[ShippedDate],
	[SealNumber],
	[LoadReference],
	[eRBillTransmitted]
)
VALUES
(
	@UserID,
	@UserName,
	@RBillNumber,
	@Date,
	@AgencyID,
	@AgencyName,
	@AgencyAddress1,
	@AgencyAddress2,
	@AgencyCity,
	@AgencyProvince,
	@AgencyCountry,
	@AgencyPostalCode,
	@Status,
	@CarrierID,
	@PlantID,
	@TrailerNumber,
	@ProBillNumber,
	@ShippedDate,
	@SealNumber,
	@LoadReference,
	@eRBillTransmitted
)

	SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Shipment_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Shipment_Update]
GO

CREATE PROCEDURE [dbo].[sol_Shipment_Update]
(
	@ShipmentID int,
	@UserID uniqueidentifier,
	@UserName nvarchar(256),
	@RBillNumber nvarchar(50),
	@Date datetime,
	@AgencyID int,
	@AgencyName varchar(50),
	@AgencyAddress1 varchar(250),
	@AgencyAddress2 varchar(250),
	@AgencyCity varchar(100),
	@AgencyProvince varchar(100),
	@AgencyCountry varchar(50),
	@AgencyPostalCode varchar(50),
	@Status char(1),
	@CarrierID int,
	@PlantID int,
	@TrailerNumber nvarchar(50),
	@ProBillNumber nvarchar(50),
	@ShippedDate datetime,
	@SealNumber nvarchar(50),
	@LoadReference nvarchar(50),
	@eRBillTransmitted bit
)

AS

SET NOCOUNT ON

UPDATE [sol_Shipment] WITH (ROWLOCK)
SET [UserID] = @UserID,
	[UserName] = @UserName,
	[RBillNumber] = @RBillNumber,
	[Date] = @Date,
	[AgencyID] = @AgencyID,
	[AgencyName] = @AgencyName,
	[AgencyAddress1] = @AgencyAddress1,
	[AgencyAddress2] = @AgencyAddress2,
	[AgencyCity] = @AgencyCity,
	[AgencyProvince] = @AgencyProvince,
	[AgencyCountry] = @AgencyCountry,
	[AgencyPostalCode] = @AgencyPostalCode,
	[Status] = @Status,
	[CarrierID] = @CarrierID,
	[PlantID] = @PlantID,
	[TrailerNumber] = @TrailerNumber,
	[ProBillNumber] = @ProBillNumber,
	[ShippedDate] = @ShippedDate,
	[SealNumber] = @SealNumber,
	[LoadReference] = @LoadReference,
	[eRBillTransmitted] = @eRBillTransmitted
WHERE [ShipmentID] = @ShipmentID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Shipment_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Shipment_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Shipment_Delete]
(
	@ShipmentID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Shipment] WITH (ROWLOCK)
WHERE [ShipmentID] = @ShipmentID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Shipment_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Shipment_Select]
GO

CREATE PROCEDURE [dbo].[sol_Shipment_Select]
(
	@ShipmentID int
)

AS

SET NOCOUNT ON

SELECT [ShipmentID],
	[UserID],
	[UserName],
	[RBillNumber],
	[Date],
	[AgencyID],
	[AgencyName],
	[AgencyAddress1],
	[AgencyAddress2],
	[AgencyCity],
	[AgencyProvince],
	[AgencyCountry],
	[AgencyPostalCode],
	[Status],
	[CarrierID],
	[PlantID],
	[TrailerNumber],
	[ProBillNumber],
	[ShippedDate],
	[SealNumber],
	[LoadReference],
	[eRBillTransmitted]
FROM [sol_Shipment]
WHERE [ShipmentID] = @ShipmentID
GO

/******************************************************************************
******************************************************************************/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Shipment_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[sol_Shipment_SelectAll]
--GO

--CREATE PROCEDURE [dbo].[sol_Shipment_SelectAll]

--AS

--SET NOCOUNT ON

--SELECT [ShipmentID],
--	[UserID],
--	[UserName],
--	[RBillNumber],
--	[Date],
--	[AgencyID],
--	[AgencyName],
--	[AgencyAddress1],
--	[AgencyAddress2],
--	[AgencyCity],
--	[AgencyProvince],
--	[AgencyCountry],
--	[AgencyPostalCode],
--	[Status],
--	[CarrierID],
--	[PlantID],
--	[TrailerNumber],
--	[ProBillNumber],
--	[ShippedDate],
--	[SealNumber],
--	[LoadReference],
--	[eRBillTransmitted]
--FROM [sol_Shipment]
--GO

/******************************************************************************
--Sol_Stage
	--DBCC CHECKIDENT ('sol_Stage', RESEED, 1)
	--DBCC CHECKIDENT ('sol_Stage', RESEED)
	SELECT CAST(scope_identity() AS int) 
******************************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Stage_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Stage_Insert]
GO

CREATE PROCEDURE [dbo].[sol_Stage_Insert]
(
	@ShipmentID int,
	@UserID uniqueidentifier,
	@UserName nvarchar(256),
	@Date datetime,
	@TagNumber nvarchar(50),
	@ContainerID int,
	@ContainerDescription varchar(100),
	@ProductID int,
	@ProductName varchar(50),
	@Dozen int,
	@Quantity int,
	@Price money,
	@Remarks ntext,
	@Status char(1),
	@DateClosed datetime
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Stage]
(
	[ShipmentID],
	[UserID],
	[UserName],
	[Date],
	[TagNumber],
	[ContainerID],
	[ContainerDescription],
	[ProductID],
	[ProductName],
	[Dozen],
	[Quantity],
	[Price],
	[Remarks],
	[Status],
	[DateClosed]
)
VALUES
(
	@ShipmentID,
	@UserID,
	@UserName,
	@Date,
	@TagNumber,
	@ContainerID,
	@ContainerDescription,
	@ProductID,
	@ProductName,
	@Dozen,
	@Quantity,
	@Price,
	@Remarks,
	@Status,
	@DateClosed
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Stage_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Stage_Update]
GO

CREATE PROCEDURE [dbo].[sol_Stage_Update]
(
	@StageID int,
	@ShipmentID int,
	@UserID uniqueidentifier,
	@UserName nvarchar(256),
	@Date datetime,
	@TagNumber nvarchar(50),
	@ContainerID int,
	@ContainerDescription varchar(100),
	@ProductID int,
	@ProductName varchar(50),
	@Dozen int,
	@Quantity int,
	@Price money,
	@Remarks ntext,
	@Status char(1),
	@DateClosed datetime
)

AS

SET NOCOUNT ON

UPDATE [sol_Stage] WITH (ROWLOCK)
SET [ShipmentID] = @ShipmentID,
	[UserID] = @UserID,
	[UserName] = @UserName,
	[Date] = @Date,
	[TagNumber] = @TagNumber,
	[ContainerID] = @ContainerID,
	[ContainerDescription] = @ContainerDescription,
	[ProductID] = @ProductID,
	[ProductName] = @ProductName,
	[Dozen] = @Dozen,
	[Quantity] = @Quantity,
	[Price] = @Price,
	[Remarks] = @Remarks,
	[Status] = @Status,
	[DateClosed] = @DateClosed
WHERE [StageID] = @StageID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Stage_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Stage_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Stage_Delete]
(
	@StageID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Stage] WITH (ROWLOCK)
WHERE [StageID] = @StageID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Stage_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Stage_Select]
GO

CREATE PROCEDURE [dbo].[sol_Stage_Select]
(
	@StageID int
)

AS

SET NOCOUNT ON

SELECT [StageID],
	[ShipmentID],
	[UserID],
	[UserName],
	[Date],
	[TagNumber],
	[ContainerID],
	[ContainerDescription],
	[ProductID],
	[ProductName],
	[Dozen],
	[Quantity],
	[Price],
	[Remarks],
	[Status],
	[DateClosed]
FROM [sol_Stage]
WHERE [StageID] = @StageID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Stage_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Stage_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_Stage_SelectAll]

AS

SET NOCOUNT ON

SELECT [StageID],
	[ShipmentID],
	[UserID],
	[UserName],
	[Date],
	[TagNumber],
	[ContainerID],
	[ContainerDescription],
	[ProductID],
	[ProductName],
	[Dozen],
	[Quantity],
	[Price],
	[Remarks],
	[Status],
	[DateClosed]
FROM [sol_Stage]
GO

/******************************************************************************
--Sol_Entries
	DBCC CHECKIDENT ('sol_Entries', RESEED, 1)
	DBCC CHECKIDENT ('sol_Entries', RESEED)
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Entries_Update]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_Update]
(
	@EntryID int,
	@EntryType char(1),
	@UserID uniqueidentifier,
	@UserName nvarchar(256),
	@Date datetime,
	@CashTrayID int,
	@ExpenseTypeID int,
	@Amount money,
	@DiscrepancyAmount money
)

AS

SET NOCOUNT ON

UPDATE [sol_Entries] WITH (ROWLOCK)
SET [UserID] = @UserID,
	[UserName] = @UserName,
	[Date] = @Date,
	[CashTrayID] = @CashTrayID,
	[ExpenseTypeID] = @ExpenseTypeID,
	[Amount] = @Amount,
	[DiscrepancyAmount] = @DiscrepancyAmount
WHERE [EntryID] = @EntryID	AND [EntryType] = @EntryType
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_SelectAllByExpenseTypeID]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_SelectAllByExpenseTypeID]
(
	@ExpenseTypeID int
)

AS

SET NOCOUNT ON

SELECT [EntryID],
	[EntryType],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[ExpenseTypeID],
	[Amount],
	[DiscrepancyAmount]
FROM [sol_Entries]
WHERE [ExpenseTypeID] = @ExpenseTypeID
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_SelectAllByCashTrayID]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_SelectAllByCashTrayID]
(
	@CashTrayID int
)

AS

SET NOCOUNT ON

SELECT [EntryID],
	[EntryType],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[ExpenseTypeID],
	[Amount],
	[DiscrepancyAmount]
FROM [sol_Entries]
WHERE [CashTrayID] = @CashTrayID
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_SelectAll]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_SelectAll]

AS

SET NOCOUNT ON

SELECT [EntryID],
	[EntryType],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[ExpenseTypeID],
	[Amount],
	[DiscrepancyAmount]
FROM [sol_Entries]
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_Select]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_Select]
(
	@EntryID int,
	@EntryType char(1)
)

AS

SET NOCOUNT ON

SELECT [EntryID],
	[EntryType],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[ExpenseTypeID],
	[Amount],
	[DiscrepancyAmount]
FROM [sol_Entries]
WHERE [EntryID] = @EntryID
	AND [EntryType] = @EntryType
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_Insert]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_Insert]
(
	@EntryType char(1),
	@UserID uniqueidentifier,
	@UserName nvarchar(256),
	@Date datetime,
	@CashTrayID int,
	@ExpenseTypeID int,
	@Amount money,
	@DiscrepancyAmount money
)

AS

SET NOCOUNT ON
	--DBCC CHECKIDENT ('sol_Entries', RESEED, 1)
	--DBCC CHECKIDENT ('sol_Entries', RESEED)

INSERT INTO [sol_Entries]
(
	[EntryType],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[ExpenseTypeID],
	[Amount],
	[DiscrepancyAmount]
)
VALUES
(
	@EntryType,
	@UserID,
	@UserName,
	@Date,
	@CashTrayID,
	@ExpenseTypeID,
	@Amount,
	@DiscrepancyAmount
)

SELECT CAST(scope_identity() AS int)
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_DeleteAllByExpenseTypeID]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_DeleteAllByExpenseTypeID]
(
	@ExpenseTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Entries] WITH (ROWLOCK)
WHERE [ExpenseTypeID] = @ExpenseTypeID
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_DeleteAllByCashTrayID]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_DeleteAllByCashTrayID]
(
	@CashTrayID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Entries] WITH (ROWLOCK)
WHERE [CashTrayID] = @CashTrayID
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_Delete]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_Delete]
(
	@EntryID int,
	@EntryType char(1)
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Entries] WITH (ROWLOCK)
WHERE [EntryID] = @EntryID
	AND [EntryType] = @EntryType
GO

/******************************************************************************
--Sol_EntriesDetail
	DBCC CHECKIDENT ('sol_EntriesDetail', RESEED, 1)
	DBCC CHECKIDENT ('sol_EntriesDetail', RESEED)
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_EntriesDetail_Update]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_EntriesDetail_Update]
(
	@DetailID int,
	@EntryID int,
	@EntryType char(1),
	@CashID int,
	@Count int
)

AS

SET NOCOUNT ON

UPDATE [sol_EntriesDetail] WITH (ROWLOCK)
SET [EntryID] = @EntryID,
	[EntryType] = @EntryType,
	[CashID] = @CashID,
	[Count] = @Count
WHERE [DetailID] = @DetailID
GO
/****** Object:  StoredProcedure [dbo].[sol_EntriesDetail_SelectAll]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_EntriesDetail_SelectAll]

AS

SET NOCOUNT ON

SELECT [DetailID],
	[EntryID],
	[EntryType],
	[CashID],
	[Count]
FROM [sol_EntriesDetail]
GO
/****** Object:  StoredProcedure [dbo].[sol_EntriesDetail_Select]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_EntriesDetail_Select]
(
	@DetailID int
)

AS

SET NOCOUNT ON

SELECT [DetailID],
	[EntryID],
	[EntryType],
	[CashID],
	[Count]
FROM [sol_EntriesDetail]
WHERE [DetailID] = @DetailID
GO
/****** Object:  StoredProcedure [dbo].[sol_EntriesDetail_Insert]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_EntriesDetail_Insert]
(
	@EntryID int,
	@EntryType char(1),
	@CashID int,
	@Count int
)

AS

SET NOCOUNT ON
	--DBCC CHECKIDENT ('sol_EntriesDetail', RESEED, 1)
	--DBCC CHECKIDENT ('sol_EntriesDetail', RESEED)

INSERT INTO [sol_EntriesDetail]
(
	[EntryID],
	[EntryType],
	[CashID],
	[Count]
)
VALUES
(
	@EntryID,
	@EntryType,
	@CashID,
	@Count
)

SELECT CAST(scope_identity() AS int)
GO
/****** Object:  StoredProcedure [dbo].[sol_EntriesDetail_Delete]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_EntriesDetail_Delete]
(
	@DetailID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_EntriesDetail] WITH (ROWLOCK)
WHERE [DetailID] = @DetailID
GO

/******************************************************************************
--Sol_ExpenseTypes
	DBCC CHECKIDENT ('sol_ExpenseTypes', RESEED, 1)
	DBCC CHECKIDENT ('sol_ExpenseTypes', RESEED)
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_ExpenseTypes_Update]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ExpenseTypes_Update]
(
	@ExpenseTypeID int,
	@Description varchar(256)
)

AS

SET NOCOUNT ON

UPDATE [sol_ExpenseTypes] WITH (ROWLOCK)
SET [Description] = @Description
WHERE [ExpenseTypeID] = @ExpenseTypeID
GO
/****** Object:  StoredProcedure [dbo].[sol_ExpenseTypes_SelectAll]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ExpenseTypes_SelectAll]

AS

SET NOCOUNT ON

SELECT [ExpenseTypeID],
	[Description]
FROM [sol_ExpenseTypes]
GO
/****** Object:  StoredProcedure [dbo].[sol_ExpenseTypes_Select]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ExpenseTypes_Select]
(
	@ExpenseTypeID int
)

AS

SET NOCOUNT ON

SELECT [ExpenseTypeID],
	[Description]
FROM [sol_ExpenseTypes]
WHERE [ExpenseTypeID] = @ExpenseTypeID
GO
/****** Object:  StoredProcedure [dbo].[sol_ExpenseTypes_Insert]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ExpenseTypes_Insert]
(
	@Description varchar(256)
)

AS

SET NOCOUNT ON
	--DBCC CHECKIDENT ('sol_ExpenseTypes', RESEED, 0)
	--DBCC CHECKIDENT ('sol_ExpenseTypes', RESEED)

INSERT INTO [sol_ExpenseTypes]
(
	[Description]
)
VALUES
(
	@Description
)

SELECT CAST(scope_identity() AS int)
GO
/****** Object:  StoredProcedure [dbo].[sol_ExpenseTypes_Delete]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_ExpenseTypes_Delete]
(
	@ExpenseTypeID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_ExpenseTypes] WITH (ROWLOCK)
WHERE [ExpenseTypeID] = @ExpenseTypeID
GO

/******************************************************************************
--Sol_CashDenominations
	DBCC CHECKIDENT ('sol_CashDenominations', RESEED, 1)
	DBCC CHECKIDENT ('sol_CashDenominations', RESEED)
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CashDenominations_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CashDenominations_Insert]
GO

CREATE PROCEDURE [dbo].[sol_CashDenominations_Insert]
(
	@CashType tinyint,
	@CashValue money,
	@Description varchar(256),
	@OrderValue smallint,
	@CashItemValue money,
	@Quantity int,
	@MoneyID int
)

AS

SET NOCOUNT ON

INSERT INTO [sol_CashDenominations]
(
	[CashType],
	[CashValue],
	[Description],
	[OrderValue],
	[CashItemValue],
	[Quantity],
	[MoneyID]
)
VALUES
(
	@CashType,
	@CashValue,
	@Description,
	@OrderValue,
	@CashItemValue,
	@Quantity,
	@MoneyID
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CashDenominations_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CashDenominations_Update]
GO

CREATE PROCEDURE [dbo].[sol_CashDenominations_Update]
(
	@CashID int,
	@CashType tinyint,
	@CashValue money,
	@Description varchar(256),
	@OrderValue smallint,
	@CashItemValue money,
	@Quantity int,
	@MoneyID int
)

AS

SET NOCOUNT ON

UPDATE [sol_CashDenominations] WITH (ROWLOCK)
SET [CashType] = @CashType,
	[CashValue] = @CashValue,
	[Description] = @Description,
	[OrderValue] = @OrderValue,
	[CashItemValue] = @CashItemValue,
	[Quantity] = @Quantity,
	[MoneyID] = @MoneyID
WHERE [CashID] = @CashID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CashDenominations_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CashDenominations_Delete]
GO

CREATE PROCEDURE [dbo].[sol_CashDenominations_Delete]
(
	@CashID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_CashDenominations] WITH (ROWLOCK)
WHERE [CashID] = @CashID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CashDenominations_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CashDenominations_Select]
GO

CREATE PROCEDURE [dbo].[sol_CashDenominations_Select]
(
	@CashID int
)

AS

SET NOCOUNT ON

SELECT [CashID],
	[CashType],
	[CashValue],
	[Description],
	[OrderValue],
	[CashItemValue],
	[Quantity],
	[MoneyID]
FROM [sol_CashDenominations]
WHERE [CashID] = @CashID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_CashDenominations_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_CashDenominations_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_CashDenominations_SelectAll]

AS

SET NOCOUNT ON

SELECT [CashID],
	[CashType],
	[CashValue],
	[Description],
	[OrderValue],
	[CashItemValue],
	[Quantity],
	[MoneyID]
FROM [sol_CashDenominations]
ORDER BY [OrderValue] Desc
GO

/******************************************************************************
--Sol_CashTrays
	DBCC CHECKIDENT ('sol_CashTrays', RESEED, 0)
	DBCC CHECKIDENT ('sol_CashTrays', RESEED)
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_CashTrays_Update]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_CashTrays_Update]
(
	@CashTrayID int,
	@Description nvarchar(256),
	@WorkStationID int,
	@UserID uniqueidentifier,
	@UserName nvarchar(256)
)

AS

SET NOCOUNT ON

UPDATE [sol_CashTrays] WITH (ROWLOCK)
SET [Description] = @Description,
	[WorkStationID] = @WorkStationID,
	[UserID] = @UserID,
	[UserName] = @UserName
WHERE [CashTrayID] = @CashTrayID
GO
/****** Object:  StoredProcedure [dbo].[sol_CashTrays_SelectAll]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_CashTrays_SelectAll]

AS

SET NOCOUNT ON

SELECT [CashTrayID],
	[Description],
	[WorkStationID],
	[UserID],
	[UserName]
FROM [sol_CashTrays]
GO
/****** Object:  StoredProcedure [dbo].[sol_CashTrays_Select]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_CashTrays_Select]
(
	@CashTrayID int
)

AS

SET NOCOUNT ON

SELECT [CashTrayID],
	[Description],
	[WorkStationID],
	[UserID],
	[UserName]
FROM [sol_CashTrays]
WHERE [CashTrayID] = @CashTrayID
GO
/****** Object:  StoredProcedure [dbo].[sol_CashTrays_Insert]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_CashTrays_Insert]
(
	@Description nvarchar(256),
	@WorkStationID int,
	@UserID uniqueidentifier,
	@UserName nvarchar(256)
)

AS

SET NOCOUNT ON
	--DBCC CHECKIDENT ('sol_CashTrays', RESEED, 0)
	--DBCC CHECKIDENT ('sol_CashTrays', RESEED)

INSERT INTO [sol_CashTrays]
(
	[Description],
	[WorkStationID],
	[UserID],
	[UserName]
)
VALUES
(
	@Description,
	@WorkStationID,
	@UserID,
	@UserName
)

SELECT CAST(scope_identity() AS int)
GO
/****** Object:  StoredProcedure [dbo].[sol_CashTrays_Delete]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_CashTrays_Delete]
(
	@CashTrayID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_CashTrays] WITH (ROWLOCK)
WHERE [CashTrayID] = @CashTrayID
GO

/******************************************************************************
--Sol_Fees
	DBCC CHECKIDENT ('sol_Fees', RESEED, 0)
	DBCC CHECKIDENT ('sol_Fees', RESEED)
SELECT CAST(scope_identity() AS int) 
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Fees_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Fees_Insert]
GO

CREATE PROCEDURE [dbo].[sol_Fees_Insert]
(
	@FeeDescription varchar(256),
	@FeeAmount money,
	@Percentage bit
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Fees]
(
	[FeeDescription],
	[FeeAmount],
	[Percentage]
)
VALUES
(
	@FeeDescription,
	@FeeAmount,
	@Percentage
)

SELECT CAST(scope_identity() AS int) 
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Fees_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Fees_Update]
GO

CREATE PROCEDURE [dbo].[sol_Fees_Update]
(
	@FeeID int,
	@FeeDescription varchar(256),
	@FeeAmount money,
	@Percentage bit
)

AS

SET NOCOUNT ON

UPDATE [sol_Fees] WITH (ROWLOCK)
SET [FeeDescription] = @FeeDescription,
	[FeeAmount] = @FeeAmount,
	[Percentage] = @Percentage
WHERE [FeeID] = @FeeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Fees_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Fees_Delete]
GO

CREATE PROCEDURE [dbo].[sol_Fees_Delete]
(
	@FeeID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Fees] WITH (ROWLOCK)
WHERE [FeeID] = @FeeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Fees_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Fees_Select]
GO

CREATE PROCEDURE [dbo].[sol_Fees_Select]
(
	@FeeID int
)

AS

SET NOCOUNT ON

SELECT [FeeID],
	[FeeDescription],
	[FeeAmount],
	[Percentage]
FROM [sol_Fees]
WHERE [FeeID] = @FeeID
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Fees_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Fees_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_Fees_SelectAll]

AS

SET NOCOUNT ON

SELECT [FeeID],
	[FeeDescription],
	[FeeAmount],
	[Percentage]
FROM [sol_Fees]
GO


/****************************************************************************/
/****************************************************************************/
/******                  Additional Stored Procedures                   ******/
/****************************************************************************/
/******************************************************************************/
--Vir_BagPosition
/******************************************************************************/
/****** Object:  StoredProcedure [dbo].[Vir_BagPosition_Update]    Script Date: 25/05/2016 10:37:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Vir_BagPosition_Update]
(
	@BagPositionID int,
	@BagPositionName nvarchar(100),
	@ProductID int,
	@CurrentStageID int,
	@CurrentQuantity int,
	@TargetQuantity int
)

AS
DECLARE --@OLDBagPositionID int,
	@OLDBagPositionName nvarchar(100),
	@OLDProductID int,
	@OLDCurrentStageID int,
	@OLDCurrentQuantity int,
	@OLDTargetQuantity int,
	@SQL nvarchar(2000),
	@FoundChange bit = 0

SET NOCOUNT ON

SELECT --@OLDBagPositionID = [BagPositionID],
	@OLDBagPositionName = [BagPositionName],
	@OLDProductID = ISNULL([ProductID], 0),
	@OLDCurrentStageID = ISNULL([CurrentStageID], 0),
	@OLDCurrentQuantity = [CurrentQuantity],
	@OLDTargetQuantity = [TargetQuantity]
FROM [Vir_BagPosition]
WHERE [BagPositionID] = @BagPositionID

SET @SQL = 'UPDATE [Vir_BagPosition] WITH (ROWLOCK) SET '

If @OLDBagPositionName != @BagPositionName 
	BEGIN
		SET @SQL = @SQL + 'BagPositionName = ''' + @BagPositionName + ''''
		SET @FoundChange = 1
	END
If @OLDProductID != @ProductID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'ProductID = ' + CONVERT(nvarchar(50), @ProductID) 
		SET @FoundChange = 1
	END
If @OLDCurrentStageID != @CurrentStageID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CurrentStageID = ' + CONVERT(nvarchar(50), @CurrentStageID) 
		SET @FoundChange = 1
	END
If @OLDCurrentQuantity != @CurrentQuantity
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CurrentQuantity = ' + CONVERT(nvarchar(50), @CurrentQuantity) 
		SET @FoundChange = 1
	END
If @OLDTargetQuantity != @TargetQuantity
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'TargetQuantity = ' + CONVERT(nvarchar(50), @TargetQuantity) 
		SET @FoundChange = 1
	END
If @FoundChange = 1 
	BEGIN
		SET @SQL = @SQL + ' WHERE [BagPositionID] = ' + Convert(nvarchar(50), @BagPositionID)
		EXEC(@SQL)
	END

/******************************************************************************/
--Vir_Conveyor
/******************************************************************************/

/******************************************************************************/
--Vir_ConveyorLink
/******************************************************************************/

/****** Object:  StoredProcedure [dbo].[Vir_ConveyorLink_SelectByBagPositionIDConveyorID]    Script Date: 18/05/2016 10:22:48 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Vir_ConveyorLink_SelectByBagPositionIDConveyorID]
(
	@BagPositionID int,
	@ConveyorID int
)

AS

SET NOCOUNT ON

SELECT [ConveyorLinkID],
	[BagPositionID],
	[ConveyorID]
FROM [Vir_ConveyorLink]
WHERE [BagPositionID] = @BagPositionID
AND [ConveyorID] = @ConveyorID

GO


/******************************************************************************/
--Vir_StagingMethod
/******************************************************************************/

/******************************************************************************
--Sol_WorkStations
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_WorkStations_SelectByName]    Script Date: 09/05/2016 11:28:21 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_WorkStations_SelectByName]
(
	@Name nvarchar(50)
)

AS

SET NOCOUNT ON

SELECT *
FROM [sol_WorkStations]
WHERE [Name] = @Name
GO

/******************************************************************************
--Qds_Drop
******************************************************************************/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.QDS_DropByCustomer( 
	@CustomerID as int
	)
AS
BEGIN
	SET NOCOUNT ON;

   SELECT        dbo.Qds_Drop.DropID, dbo.Qds_Drop.NumberOfBags, ISNULL(dbo.sol_Orders.OrderID, ' ') AS OrderID, 
                 ISNULL(dbo.sol_Orders.Status,' ') AS Status, ISNULL(dbo.sol_Orders.Comments, ' ') AS Comments
	FROM            dbo.Qds_Drop LEFT OUTER JOIN
                         dbo.sol_Orders ON dbo.Qds_Drop.OrderID = dbo.sol_Orders.OrderID
	WHERE dbo.Qds_Drop.CustomerID = @CUSTOMERID
	ORDER BY dbo.Qds_Drop.DropID desc
END
GO


/****** Object:  StoredProcedure [dbo].[Qds_Drop_Update]    Script Date: 10/19/2015 9:24:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Qds_Drop_Update]
(
	@DropID int,
	@CustomerID int,
	@NumberOfBags int,
	@PaymentMethodID int,
	@DepotID char(6),
	@OrderID int,
	@OrderType char(1)
)

AS
DECLARE	@OLDCustomerID int,
	@OLDNumberOfBags int,
	@OLDPaymentMethodID int,
	@OLDDepotID char(6),
	@OLDOrderID int,
	@OLDOrderType char(1),
	@SQL nvarchar(2000),
	@FoundChange bit = 0

SET NOCOUNT ON
--check what was updated
SELECT @OLDCustomerID = CustomerID, 
	@OLDNumberOfBags = NumberOfBags, 
	@OLDPaymentMethodID = PaymentMethodID, 
	@OLDDepotID = DepotID, 
	@OLDOrderID = OrderID, 
	@OLDOrderType = OrderType
	FROM Qds_Drop WHERE DropID = @DropID

SET @SQL = 'UPDATE Qds_Drop WITH (ROWLOCK) SET '

If @OLDCustomerID != @CustomerID 
	BEGIN
		SET @SQL = @SQL + 'CustomerID = ' + CONVERT(nvarchar(50), @CustomerID)
		SET @FoundChange = 1
	END
If @OLDNumberOfBags != @NumberOfBags
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'NumberOfBags = ' + CONVERT(nvarchar(50), @NumberOfBags)
		SET @FoundChange = 1
	END
If @OLDPaymentMethodID != @PaymentMethodID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'PaymentMethodID = ' + CONVERT(nvarchar(50), @PaymentMethodID)
		SET @FoundChange = 1
	END
If @OLDDepotID != @DepotID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DepotID = ''' + CONVERT(nvarchar(50), @DepotID) + ''''
		SET @FoundChange = 1
	END
If @OLDOrderID != @OrderID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'OrderID = ' + CONVERT(nvarchar(50), @OrderID)
		SET @FoundChange = 1
	END
If @OLDOrderType != @OrderType
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'OrderType = ''' + CONVERT(nvarchar(50), @OrderType) + ''''
		SET @FoundChange = 1
	END

If @FoundChange = 1 
	BEGIN
		SET @SQL = @SQL + ' WHERE DropID = ' + Convert(nvarchar(50), @DropID)
		EXEC(@SQL)
	END
GO

/****** Object:  StoredProcedure [dbo].[Qds_Drop_NewToSync]    Script Date: 10/10/2015 8:47:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Qds_Drop_NewToSync]

AS

SELECT      dbo.Qds_Drop.DropID, dbo.Qds_Drop.CustomerID, dbo.Qds_Drop.NumberOfBags, dbo.Qds_Drop.PaymentMethodID, 
                        dbo.Qds_Settings.SetValue AS DepotID, dbo.Qds_Drop.OrderID, dbo.Qds_Drop.OrderType
FROM          dbo.Qds_Drop INNER JOIN
                        dbo.sol_Customers ON dbo.Qds_Drop.CustomerID = dbo.sol_Customers.CustomerID CROSS JOIN
                        dbo.Qds_Settings
WHERE      (dbo.Qds_Settings.Name = N'QuickDrop_DepotID') AND (dbo.sol_Customers.IsNew IS NULL OR dbo.sol_Customers.IsNew = 0) AND (dbo.Qds_Drop.IsNew = 1)

GO



/****** Object:  StoredProcedure [dbo].[Qds_Drop_SelectAllByOrderType]    Script Date: 5/20/2014 10:11:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/****** Object:  StoredProcedure [dbo].[Qds_Drop_SelectAllByOrderType]    Script Date: 5/20/2014 10:11:35 AM ******/
CREATE PROCEDURE [dbo].[Qds_Drop_SelectAllByOrderType]
(
	@OrderType char(1)
)

AS

SET NOCOUNT ON
	--[DropID],
	--[CustomerID],
	--[NumberOfBags],
	--[PaymentMethodID],
	--[DepotID],
	--[OrderID],
	--[OrderType]

SELECT *
FROM [Qds_Drop]
WHERE 
[OrderType] = @OrderType
AND [NumberOfBags] > 
  (
	  SELECT COUNT(*)
	  FROM [dbo].[Qds_Bag]
	  WHERE [DropID] = [dbo].[Qds_Drop].[DropID]
	  AND [DateCounted] > '1753-01-01 12:00:00'
  ) 

GO

/****** Object:  StoredProcedure [dbo].[Qds_Drop_SelectAllInProcess]    Script Date: 12/13/2013 9:28:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Qds_Drop_SelectAllInProcess]

AS

SET NOCOUNT ON
	--[DropID],
	--[CustomerID],
	--[NumberOfBags],
	--[PaymentMethodID],
	--[DepotID],
	--[OrderID],
	--[OrderType]

SELECT *
FROM [Qds_Drop]
WHERE 
  [NumberOfBags] > 
  (
	  SELECT COUNT(*)
	  FROM [dbo].[Qds_Bag]
	  WHERE [DropID] = [dbo].[Qds_Drop].[DropID]
	  AND [DateCounted] > '1753-01-01 12:00:00'
  ) 
GO

/****** Object:  StoredProcedure [dbo].[Qds_Drop_IsReady]    Script Date: 12/12/2013 11:04:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Qds_Drop_IsReady]
(
	@DropID int
)

AS

SET NOCOUNT ON

DECLARE @Count int
DECLARE @Flag bit

SELECT @Count = COUNT(*)
  FROM [dbo].[Qds_Drop] 
  where [DropID] = @DropID AND
  [NumberOfBags] > 
  (
	  SELECT COUNT(*)
	  FROM [dbo].[Qds_Bag]
	  WHERE [DropID] = [dbo].[Qds_Drop].[DropID]
	  AND [DateCounted] > '1753-01-01 12:00:00'
  )

if(@Count>0)
	SET @Flag = 0
else
	SET @Flag = 1

SELECT @Flag as Ready
GO

/******************************************************************************
--Qds_Bag
******************************************************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.QDS_BagsByCustomer(
	@CustomerID as int
	)
AS
BEGIN
	SET NOCOUNT ON;
   SELECT dbo.Qds_Bag.BagID, dbo.Qds_Bag.DateEntered, CASE dbo.Qds_Bag.DateCounted WHEN '1753-01-01 12:00:00.000' THEN null ELSE dbo.Qds_Bag.DateCounted END AS DateCounted, dbo.Qds_Drop.DropID, dbo.Qds_Drop.NumberOfBags, ISNULL(dbo.sol_Orders.OrderID, ' ') AS OrderID, ISNULL(dbo.sol_Orders.Status,' ') AS Status, ISNULL(dbo.sol_Orders.Comments, ' ') AS Comments
	FROM  dbo.Qds_Drop INNER JOIN dbo.Qds_Bag ON dbo.Qds_Drop.DropID = dbo.Qds_Bag.DropID LEFT OUTER JOIN dbo.sol_Orders ON dbo.Qds_Drop.OrderID = dbo.sol_Orders.OrderID
	WHERE dbo.Qds_Drop.CustomerID = @CUSTOMERID
	ORDER BY dbo.Qds_Bag.BagID desc
END
GO

/****** Object:  StoredProcedure [dbo].[Qds_Bag_Update]    Script Date: 10/19/2015 11:22:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Qds_Bag_Update]
(
	@BagID int,
	@DropID int,
	@BagEstimateUnderLitre int,
	@BagEstimateOverLitre int,
	@DateEntered datetime,
	@DateAccepted datetime,
	@DatePrinted datetime,
	@DateCounted datetime,
	@DatePaid datetime,
	@DepotID char(6)
)

AS


DECLARE	@OLDDropID int,
	@OLDBagEstimateUnderLitre int,
	@OLDBagEstimateOverLitre int,
	@OLDDateEntered datetime,
	@OLDDateAccepted datetime,
	@OLDDatePrinted datetime,
	@OLDDateCounted datetime,
	@OLDDatePaid datetime,
	@OLDDepotID char(6),
	@SQL nvarchar(2000),
	@FoundChange bit = 0

SET NOCOUNT ON
--check what was updated
SELECT @OLDDropID = DropID,
	@OLDBagEstimateUnderLitre = BagEstimateUnderLitre,
	@OLDBagEstimateOverLitre = BagEstimateOverLitre,
	@OLDDateEntered = DateEntered,
	@OLDDateAccepted = DateAccepted,
	@OLDDatePrinted = DatePrinted,
	@OLDDateCounted = DateCounted,
	@OLDDatePaid = DatePaid,
	@OLDDepotID = DepotID
	FROM Qds_Bag WHERE BagID = @BagID

SET @SQL = 'UPDATE Qds_Bag WITH (ROWLOCK) SET '

If @OLDDropID != @DropID 
	BEGIN
		SET @SQL = @SQL + 'DropID = ' + CONVERT(nvarchar(50), @DropID)
		SET @FoundChange = 1
	END
If @OLDBagEstimateUnderLitre != @BagEstimateUnderLitre
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'NumberOfBags = ' + CONVERT(nvarchar(50), @BagEstimateUnderLitre)
		SET @FoundChange = 1
	END
If @OLDBagEstimateOverLitre != @BagEstimateOverLitre
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'BagEstimateOverLitre = ' + CONVERT(nvarchar(50), @BagEstimateOverLitre)
		SET @FoundChange = 1
	END
If @OLDDateEntered != @DateEntered
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DateEntered = ''' + CONVERT(nvarchar(50), @DateEntered,120) + ''''
		SET @FoundChange = 1
	END
If @OLDDateAccepted != @DateAccepted
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DateAccepted = ''' + CONVERT(nvarchar(50), @DateAccepted,120) + ''''
		SET @FoundChange = 1
	END
If @OLDDatePrinted != @DatePrinted
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DatePrinted = ''' + CONVERT(nvarchar(50), @DatePrinted,120) + ''''
		SET @FoundChange = 1
	END
If @OLDDateCounted != @DateCounted
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DateCounted = ''' + CONVERT(nvarchar(50), @DateCounted,120) + ''''
		SET @FoundChange = 1
	END
If @OLDDatePaid != @DatePaid
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DatePaid = ''' + CONVERT(nvarchar(50), @DatePaid,120) + ''''
		SET @FoundChange = 1
	END
If @OLDDepotID != @DepotID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DepotID = ''' + CONVERT(nvarchar(50), @DepotID) + ''''
		SET @FoundChange = 1
	END

If @FoundChange = 1 
	BEGIN
		SET @SQL = @SQL + ' WHERE BagID = ' + Convert(nvarchar(50), @BagID)
		EXEC(@SQL)
	END
GO
/****** Object:  StoredProcedure [dbo].[Qds_Bag_NewToSync]    Script Date: 10/10/2015 8:47:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Qds_Bag_NewToSync]

AS

SELECT      dbo.Qds_Bag.BagID, dbo.Qds_Bag.DropID, dbo.Qds_Bag.BagEstimateUnderLitre, dbo.Qds_Bag.BagEstimateOverLitre, 
                        dbo.Qds_Bag.DateEntered, dbo.Qds_Bag.DateAccepted, dbo.Qds_Bag.DateCounted, dbo.Qds_Bag.DatePaid, dbo.Qds_Bag.DatePrinted, 
                        dbo.Qds_Settings.SetValue AS DepotID
FROM          dbo.Qds_Drop INNER JOIN
                        dbo.Qds_Bag ON dbo.Qds_Drop.DropID = dbo.Qds_Bag.DropID CROSS JOIN
                        dbo.Qds_Settings
WHERE      (dbo.Qds_Settings.Name = N'QuickDrop_DepotID') AND (dbo.Qds_Drop.IsNew IS NULL OR dbo.Qds_Drop.IsNew = 0) AND (dbo.Qds_Bag.IsNew = 1)

GO


/******************************************************************************
--Sol_OrderCardLink
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLink_SelectByCardNumber]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLink_SelectByCardNumber]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLink_SelectByCardNumber]
(
	@CardNumber nvarchar(50)
)

AS

SET NOCOUNT ON

SELECT [CardNumber],
	[OrderID]
FROM [Sol_OrderCardLink]
WHERE [CardNumber] = @CardNumber
GO

/******************************************************************************
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_OrderCardLink_DeleteByCardNumber]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_OrderCardLink_DeleteByCardNumber]
GO

CREATE PROCEDURE [dbo].[Sol_OrderCardLink_DeleteByCardNumber]
(
	@CardNumber nvarchar(50)
)

AS

SET NOCOUNT ON

DELETE FROM [Sol_OrderCardLink] WITH (ROWLOCK)
WHERE [CardNumber] = @CardNumber
GO


/******************************************************************************
--Sol_AutoNumbers
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_AutoNumbers_UpdateTagNumber]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_AutoNumbers_UpdateTagNumber]
GO

CREATE PROCEDURE [dbo].[Sol_AutoNumbers_UpdateTagNumber]
(
	@AgencyID int,
	@FolioID int
)

AS

SET NOCOUNT ON

DECLARE @NextId int
SELECT @NextId = MAX([TagNumber])+1 FROM [Sol_AutoNumbers] WHERE [AgencyID] = @AgencyID AND [FolioID] = @FolioID

WHILE (SELECT COUNT(*) FROM [sol_Stage] WHERE [TagNumber] = CAST(@NextId  AS nvarchar(50))) >0
BEGIN
	UPDATE [Sol_AutoNumbers] WITH (ROWLOCK)
	SET [TagNumber] = @NextId
	WHERE [AgencyID] = @AgencyID AND [FolioID] = @FolioID
	SELECT @NextId = [TagNumber]+1 FROM [Sol_AutoNumbers] WHERE [AgencyID] = @AgencyID AND [FolioID] = @FolioID
END

UPDATE [Sol_AutoNumbers] WITH (ROWLOCK)
SET [TagNumber] = @NextId
WHERE [AgencyID] = @AgencyID AND [FolioID] = @FolioID

SELECT @NextId

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sol_AutoNumbers_UpdateRBillNumber]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sol_AutoNumbers_UpdateRBillNumber]
GO

CREATE PROCEDURE [dbo].[Sol_AutoNumbers_UpdateRBillNumber]
(
	@AgencyID int,
	@FolioID int
)

AS

SET NOCOUNT ON

DECLARE @NextId int
SELECT @NextId = MAX([RBillNumber])+1 FROM [Sol_AutoNumbers] WHERE [AgencyID] = @AgencyID AND [FolioID] = @FolioID

WHILE (SELECT COUNT(*) FROM [sol_Shipment] WHERE [RBillNumber] = CAST(@NextId  AS nvarchar(50))) >0
BEGIN
	UPDATE [Sol_AutoNumbers] WITH (ROWLOCK)
	SET [RBillNumber] = @NextId
	WHERE [AgencyID] = @AgencyID AND [FolioID] =  @FolioID
	SELECT @NextId = [RBillNumber]+1 FROM [Sol_AutoNumbers] WHERE [AgencyID] = @AgencyID AND [FolioID] = @FolioID
END

UPDATE [Sol_AutoNumbers] WITH (ROWLOCK)
SET [RBillNumber] = @NextId
WHERE [AgencyID] = @AgencyID AND [FolioID] = @FolioID

SELECT @NextId
GO

/******************************************************************************
--Sac_ClientNames
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_ClientNames_SelectByCashTrayID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_ClientNames_SelectByCashTrayID]
GO

CREATE PROCEDURE [dbo].[Sac_ClientNames_SelectByCashTrayID]
(
	@CashTrayID int
)

AS

SELECT [ClientID],
	[CashTrayID],
	[CoinAmountInventory]
FROM [Sac_ClientNames]
WHERE [CashTrayID] = @CashTrayID
GO

/****************************************************************************/
 --Sac_Money
/****************************************************************************/
CREATE PROCEDURE [dbo].[Sac_Money_SelectAllByTypeID]
(
	@CountryCode nchar(2),
	@TypeID int
)

AS

SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)
	--IF(@TypeID = 0) SET @TypeID = NULL 
	SET @sql = 
	'SELECT [MoneyID], '+
	'	[Name], '+
	'	[TypeID], '+
	'	[DollarValue], '+
	'	[CountryCode] '+
	'FROM [Sac_Money] '+
	'WHERE [CountryCode] = '''+@CountryCode+''' ';
	IF(@TypeID != -1)
	BEGIN
		SET @sql = @sql +
		'AND [TypeID] = '+CAST(@TypeID  AS VARCHAR);
		IF(@TypeID = 0)
			SET @sql = @sql +
			'OR [TypeID] = 2 ';	-- rolls
	END

	SET @sql = @sql +
	'ORDER BY [DollarValue] DESC ';

EXEC(@sql)


/****************************************************************************/
 --Sac_MoneyInventory
/****************************************************************************/
/****** Object:  StoredProcedure [dbo].[Sac_MoneyInventory_SelectAllByTypeID]    Script Date: 16/12/2015 10:35:44 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sac_MoneyInventory_SelectAllByTypeID]
(
	@TypeID tinyint		-- 0 = coins, 1 = bills, otro numero = todos
	, @ClientID nvarchar(50)
)
AS

SET NOCOUNT ON

if(@TypeID = 0 OR @TypeID = 1)
BEGIN
	SELECT [ClientID],
		m.[MoneyID]
		, m.Name
		, m.[TypeID]
		, m.[DollarValue]
		, m.[CountryCode]
		, [BillDispenserID]
		, [Address]
		, [Inventory]
		, [MaxNumBills]
		, [FullQuantity]
	FROM [Sac_Money] as m
	left join [Sac_MoneyInventory] as mi ON mi.[MoneyID] = m.[MoneyID]
	AND mi.[ClientID] = @ClientID
	WHERE m.[TypeID] = @TypeID
	ORDER BY m.[DollarValue] Desc
END
ELSE
BEGIN
	SELECT [ClientID],
		m.[MoneyID]
		, m.Name
		, m.[DollarValue]
		, m.[TypeID]
		, [BillDispenserID]
		, [Address]
		, [Inventory]
		, [MaxNumBills]
		, [FullQuantity]
	FROM [Sac_Money] as m
	left join [Sac_MoneyInventory] as mi ON m.[MoneyID] = mi.[MoneyID]
	AND mi.[ClientID] = @ClientID
	ORDER BY m.[DollarValue] Desc
END

GO

/****** Object:  StoredProcedure [dbo].[Sac_MoneyInventory_SelectAllByBillDispenserID]    Script Date: 04/09/2015 12:00:39 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_SelectAllByBillDispenserID]
(
	@BillDispenserID int
	, @TypeID tinyint		-- 0 = coins, 1 = bills, otro numero = todos
)
AS

SET NOCOUNT ON

if(@TypeID = 0 OR @TypeID = 1)
BEGIN
	SELECT [ClientID],
		mi.[MoneyID]
		, m.Name
		, m.[TypeID]
		, m.[DollarValue]
		, m.[CountryCode]
		, [BillDispenserID]
		, [Address]
		, [Inventory]
		, [MaxNumBills]
		, [FullQuantity]
	FROM [Sac_MoneyInventory] as mi
	right join [Sac_Money] as m ON m.[MoneyID] = mi.[MoneyID]
	AND m.[TypeID] = @TypeID
	WHERE [BillDispenserID] = @BillDispenserID
	ORDER BY m.[DollarValue] Desc
END
ELSE
BEGIN
	SELECT [ClientID],
		mi.[MoneyID]
		, m.Name
		, m.[DollarValue]
		, m.[TypeID]
		, [BillDispenserID]
		, [Address]
		, [Inventory]
		, [MaxNumBills]
		, [FullQuantity]
	FROM [Sac_MoneyInventory] as mi
	right join [Sac_Money] as m ON m.[MoneyID] = mi.[MoneyID]
	WHERE [BillDispenserID] = @BillDispenserID
	ORDER BY m.[DollarValue] Desc
END

GO

--DON'T USE IT FOR NOW
/****** Object:  StoredProcedure [dbo].[Sac_MoneyInventory_SelectByClientIDTypeID]    Script Date: 20/06/2013 12:04:26 p. m. ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--CREATE PROCEDURE [dbo].[Sac_MoneyInventory_SelectByClientIDTypeID]
--(
--	@ClientID nvarchar(50),
--	@TypeID int

--)

--AS

--SET NOCOUNT ON
--	DECLARE @sql NVARCHAR(3000)

--	--IF(@ClientID = '') SET @ClientID = NULL 
--	--IF(@TypeID = 0) SET @TypeID = NULL 

--	SET @sql = 

--	'SELECT mi.[ClientID] '+
--	'      ,mi.[MoneyID] '+
--	'      ,mi.[Address] '+
--	'      ,mi.[Inventory] '+
--	'      ,mi.[MaxNumBills] '+
--	'      ,m.[MoneyID] '+
--	'      ,m.[TypeID] '+
--	'FROM [Sac_MoneyInventory] as mi  '+
--	'INNER JOIN [Sac_Money] as m ON m.MoneyID = mi.MoneyID ';
--	if(@TypeID != -1)
--		SET @sql = @sql +
--		'AND m.TypeID = '+CAST(@TypeID  AS VARCHAR);


--	SET @sql = @sql +
--	'WHERE mi.[ClientID] =  '''+@ClientID+''' ';

--EXEC(@sql)
--GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sac_MoneyInventory_SelectAllByClientID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sac_MoneyInventory_SelectAllByClientID]
GO

CREATE PROCEDURE [dbo].[Sac_MoneyInventory_SelectAllByClientID]
(
	@ClientID nvarchar(50)
)

AS

SET NOCOUNT ON

SELECT [ClientID],
	[MoneyID],
	[BillDispenserID],
	[Address],
	[Inventory],
	[MaxNumBills],
	[FullQuantity]
FROM [Sac_MoneyInventory]
WHERE [ClientID] = @ClientID
GO

/****************************************************************************/
 --Sol_SupplyInventory
/****************************************************************************/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.sol_SupplyInventory_ByDate
(
   @DateFrom varchar(23),
   @DateTo varchar(23)
)
AS

BEGIN
   SET NOCOUNT ON
   IF(@DateFrom IS NULL) SET @DateFrom = '1950-01-01 00:00:00'
   IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'

CREATE TABLE #tmpInventory(
      ContainerID int,
      SignedQuantity int)

INSERT INTO #tmpInventory
      SELECT      ContainerID, 0 - SUM(Quantity) AS SignedQuantity
            FROM          dbo.Sol_SupplyInventory
            WHERE      (SupplyInventoryType = 'S') AND (dbo.Sol_SupplyInventory.Date BETWEEN @DateFrom AND @DateTo)
            GROUP BY ContainerID

INSERT INTO #tmpInventory
      SELECT      ContainerID, SUM(Quantity) AS SignedQuantity
      FROM          dbo.Sol_SupplyInventory
      WHERE      (SupplyInventoryType = 'A' OR SupplyInventoryType = 'R') 
            AND (Date BETWEEN @DateFrom AND @DateTo)
      GROUP BY ContainerID

SELECT      dbo.sol_Containers.ContainerID, dbo.sol_Containers.Description, dbo.sol_Containers.ShortDescription, dbo.sol_Containers.ContainerTypeID, 
                        SUM(#tmpInventory.SignedQuantity) AS Inventory
FROM          dbo.sol_Containers INNER JOIN
                        #tmpInventory ON dbo.sol_Containers.ContainerID = #tmpInventory.ContainerID
GROUP BY dbo.sol_Containers.ContainerID, dbo.sol_Containers.Description, dbo.sol_Containers.ShortDescription, dbo.sol_Containers.ContainerTypeID
                              
END

GO


/****************************************************************************/
 --Sol_Containers
/****************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Containers_SelectAllLookup]    Script Date: 03/21/2012 13:02:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_Containers_SelectAllLookup]

AS

SET NOCOUNT ON

SELECT [ContainerID],
	[Description],
	--[ShortDescription],
	[ContainerTypeID]
FROM [sol_Containers]

GO
/****** Object:  StoredProcedure [dbo].[sol_Containers_SelectAllByTypeLookup]    Script Date: 03/21/2012 12:16:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Containers_SelectAllByTypeLookup]
(
	@ContainerTypeId int
)

AS

SET NOCOUNT ON

SELECT [ContainerID],
	[Description],
	--[ShortDescription],
	[ContainerTypeID]
FROM [sol_Containers]
WHERE [ContainerTypeID] = @ContainerTypeId

GO

/****** Object:  StoredProcedure [dbo].[sol_Containers_SelectAllByType]    Script Date: 03/21/2012 12:16:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_Containers_SelectAllByType]
(
	@ContainerTypeId int
)

AS

SET NOCOUNT ON

SELECT [ContainerID],
	[Description],
	[ShortDescription],
	[ContainerTypeID],
	[ShippingContainerID],
	[ShippingContainerTypeID]
FROM [sol_Containers]
WHERE [ContainerTypeID] = @ContainerTypeId

GO

/******************************************************************************
--Sol_Employees
******************************************************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Employees_SelectAllLookup]

AS

SET NOCOUNT ON

SELECT [UserId], [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS FullName
FROM [Sol_Employees]
WHERE (

        SELECT COUNT(*)
        FROM    dbo.aspnet_Membership m
        WHERE   m.UserId = [Sol_Employees].UserId
		AND m.IsApproved = 1 AND m.[IsLockedOut] = 0
) > 0

Order BY FullName
GO

/******************************************************************************
--Sol_EmployeesLog
******************************************************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[Sol_EmployeesLog_LastPunch]
	(
		@UserId nvarchar(256)
	)

	AS

	SET NOCOUNT ON
	
	SELECT TOP 1 
		[LogId],
		[UserId],
		[PunchInTime],
		[PunchOutTime],
		[Comments],
		[Approved],
		[Modified]
	FROM [Sol_EmployeesLog] 
	--WHERE [UserId] = '+CAST(@UserId  AS VARCHAR)+ ' ';
	WHERE [UserId] = @UserId
	AND [PunchInTime]= (SELECT MAX([PunchInTime]) FROM [Sol_EmployeesLog] WHERE [UserId] = @UserId)

GO

/****************************************************************************/
--Sol_Orders

--comment all [IsNew] references

/****************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectAllBy]    Script Date: 12/02/2016 12:20:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAllBy]
(
	@OrderType char(1),
	@Status char (1),
	@CustomerID int,
    @DateFrom varchar(23),
    @DateTo varchar(23)
)

AS

SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)

    IF(@OrderType = '') SET @OrderType = NULL 
    IF(@Status = '') SET @Status = NULL 
	IF(@CustomerID <1) SET @CustomerID = NULL
	
    IF(@DateFrom = '' OR @DateFrom = NULL) SET @DateFrom = '1950-01-01 00:00:00'
    IF(@DateTo = '' OR @DateTo = NULL) SET @DateTo = '3000-01-01 00:00:00'

	SET @sql = 
	'SELECT * '+
	'FROM [sol_Orders] ';

	SET @sql = @sql + 'WHERE [Date] between '''+@DateFrom+''' and '''+@DateTo+''' ';

	IF(@OrderType IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
			'AND ([OrderType] = '''+@OrderType+''' ';
		IF(@OrderType = 'R')
		BEGIN
			SET @sql = @sql + 
			'OR [OrderType] = ''S'') ';
		END
		ELSE
			SET @sql = @sql + ') ';
	END

	IF(@Status IS NOT NULL )
		SET @sql = @sql + 'AND [Status] = '''+@Status +''' ';

	IF(@CustomerID IS NOT NULL)
		SET @sql = @sql + 
			'AND [CustomerID] = '+CAST(@CustomerID  AS VARCHAR)+' ';
	EXEC(@sql)
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_Update]    Script Date: 10/19/2015 12:28:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_Update]
(
	@OrderID int,
	@OrderType char(1),
	@WorkStationID int,
	@ComputerName varchar(50),
	@UserID uniqueidentifier,
	@UserName varchar(50),
	@Date datetime,
	@CashTrayID int,
	@CustomerID int,
	@Name varchar(50),
	@Address1 varchar(250),
	@Address2 varchar(250),
	@City varchar(100),
	@Province varchar(100),
	@Country varchar(50),
	@PostalCode varchar(50),
	@TotalAmount money,
	@DateClosed datetime,
	@FeeID int,
	@FeeAmount money,
	@Status char(1),
	@DatePaid datetime,
	@Tax1Amount money,
	@Tax2Amount money,
	@Reference varchar(100),
	@PaymentTypeID tinyint,
	@SecurityCode nvarchar(12),
	@Comments nvarchar(256)
)

AS

DECLARE @OLDWorkStationID int,
	@OLDComputerName varchar(50),
	@OLDUserID uniqueidentifier,
	@OLDUserName varchar(50),
	@OLDDate datetime,
	@OLDCashTrayID int,
	@OLDCustomerID int,
	@OLDName varchar(50),
	@OLDAddress1 varchar(250),
	@OLDAddress2 varchar(250),
	@OLDCity varchar(100),
	@OLDProvince varchar(100),
	@OLDCountry varchar(50),
	@OLDPostalCode varchar(50),
	@OLDTotalAmount money,
	@OLDDateClosed datetime,
	@OLDFeeID int,
	@OLDFeeAmount money,
	@OLDStatus char(1),
	@OLDDatePaid datetime,
	@OLDTax1Amount money,
	@OLDTax2Amount money,
	@OLDReference varchar(100),
	@OLDPaymentTypeID tinyint,
	@OLDSecurityCode nvarchar(12),
	@OLDComments nvarchar(256),	
	@SQL nvarchar(2000),
	@FoundChange bit = 0

SET NOCOUNT ON

 SELECT @OLDWorkStationID = WorkStationID,
	@OLDComputerName = ISNULL([ComputerName], ''),
	@OLDUserID = ISNULL([UserID], ''),
	@OLDUserName = ISNULL([UserName], ''),
	@OLDDate = ISNULL([Date], ''),
	@OLDCashTrayID = [CashTrayID],
	@OLDCustomerID = [CustomerID],
	@OLDName = ISNULL([Name], ''),
	@OLDAddress1 = ISNULL([Address1], ''),
	@OLDAddress2 = ISNULL([Address2], ''),
	@OLDCity = ISNULL([City], ''),
	@OLDProvince = ISNULL([Province], ''),
	@OLDCountry = ISNULL([Country], ''),
	@OLDPostalCode = ISNULL([PostalCode], ''),
	@OLDTotalAmount = ISNULL([TotalAmount], 0),
	@OLDDateClosed = ISNULL([DateClosed], ''),
	@OLDFeeID = [FeeID],
	@OLDFeeAmount = ISNULL([FeeAmount], 0),
	@OLDStatus = ISNULL([Status], ''),
	@OLDDatePaid = ISNULL([DatePaid], ''),
	@OLDTax1Amount = ISNULL([Tax1Amount], 0),
	@OLDTax2Amount = ISNULL([Tax2Amount], 0),
	@OLDReference = ISNULL([Reference], ''),
	@OLDPaymentTypeID = ISNULL([PaymentTypeID], 0),
	@OLDSecurityCode = ISNULL([SecurityCode], ''),
	@OLDComments = ISNULL([Comments], '')
	FROM dbo.sol_Orders WHERE [OrderID] = @OrderID	AND [OrderType] = @OrderType

SET @SQL = 'UPDATE sol_Orders WITH (ROWLOCK) SET '

If @WorkStationID != @WorkStationID 
	BEGIN
		SET @SQL = @SQL + 'WorkStationID = ' + CONVERT(nvarchar(50), @WorkStationID)
		SET @FoundChange = 1
	END
If @OLDComputerName != ISNULL(@ComputerName, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'ComputerName = ''' + @ComputerName + ''''
		SET @FoundChange = 1
	END
If @OLDUserID != ISNULL(@UserID, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'UserID = ''' + CONVERT(nvarchar(50), @UserID) + ''''
		SET @FoundChange = 1
	END
If @OLDDate != ISNULL(@Date, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + '[Date] = ''' + CONVERT(nvarchar(50), @Date,120) + ''''
		SET @FoundChange = 1
	END
If @OLDCashTrayID != @CashTrayID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CashTrayID = ' + CONVERT(nvarchar(50), @CashTrayID)
		SET @FoundChange = 1
	END
If @OLDCustomerID != @CustomerID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CustomerID = ' + CONVERT(nvarchar(50), @CustomerID)
		SET @FoundChange = 1
	END
If @OLDName != ISNULL(@Name, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Name = ''' + @Name + ''''
		SET @FoundChange = 1
	END
If @OLDAddress1 != ISNULL(@Address1, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Address1 = ''' + @Address1 + ''''
		SET @FoundChange = 1
	END
If @OLDAddress2 != ISNULL(@Address2, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Address2 = ''' + @Address2 + ''''
		SET @FoundChange = 1
	END
If @OLDCity != ISNULL(@City, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'City = ''' + @City + ''''
		SET @FoundChange = 1
	END
If @OLDProvince != ISNULL(@Province, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Province = ''' + @Province + ''''
		SET @FoundChange = 1
	END
If @OLDCountry != ISNULL(@Country, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Country = ''' + @Country + ''''
		SET @FoundChange = 1
	END
If @OLDPostalCode != ISNULL(@PostalCode, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'PostalCode = ''' + @PostalCode + ''''
		SET @FoundChange = 1
	END
If @OLDTotalAmount != ISNULL(@TotalAmount, 0)
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'TotalAmount = ' + CONVERT(nvarchar(50), @TotalAmount)
		SET @FoundChange = 1
	END
If @OLDDateClosed != ISNULL(@DateClosed, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DateClosed = ''' + CONVERT(nvarchar(50), @DateClosed,120) + ''''
		SET @FoundChange = 1
	END
If @OLDFeeAmount != ISNULL(@FeeAmount, 0)
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'FeeAmount = ' + CONVERT(nvarchar(50), @FeeAmount)
		SET @FoundChange = 1
	END
If @OLDFeeID != @FeeID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'FeeID = ' + CONVERT(nvarchar(50), @FeeID)
		SET @FoundChange = 1
	END
If @OLDStatus != ISNULL(@Status, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Status = ''' + CONVERT(nvarchar(50), @Status) + ''''
		SET @FoundChange = 1
	END
If @OLDDatePaid != ISNULL(@DatePaid, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DatePaid = ''' + CONVERT(nvarchar(50), @DatePaid,120) + ''''
		SET @FoundChange = 1
	END
If @OLDTax1Amount != ISNULL(@Tax1Amount, 0)
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Tax1Amount = ' + CONVERT(nvarchar(50), @Tax1Amount)
		SET @FoundChange = 1
	END
If @OLDTax2Amount != ISNULL(@Tax2Amount, 0)
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Tax2Amount = ' + CONVERT(nvarchar(50), @Tax2Amount)
		SET @FoundChange = 1
	END
If @OLDReference != ISNULL(@Reference, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Reference = ''' + @Reference + ''''
		SET @FoundChange = 1
	END
If @OLDPaymentTypeID != ISNULL(@PaymentTypeID, 0)
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'PaymentTypeID = ' + CONVERT(nvarchar(50), @PaymentTypeID)
		SET @FoundChange = 1
	END
If @OLDSecurityCode != ISNULL(@SecurityCode, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'SecurityCode = ''' + @SecurityCode + ''''
		SET @FoundChange = 1
	END
If @Comments != ISNULL(@Comments, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Comments = ''' + @Comments + ''''
		SET @FoundChange = 1
	END

If @FoundChange = 1 
	BEGIN
		SET @SQL = @SQL + ' WHERE [OrderID] = ' + Convert(nvarchar(50), @OrderID) + ' AND [OrderType] = ''' + Convert(nvarchar(50), @OrderType) + ''''
		EXEC(@SQL)
	END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Orders_NewToSync]    Script Date: 10/10/2015 8:47:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Orders_NewToSync]

AS

SELECT      dbo.sol_Orders.OrderID, dbo.sol_Orders.OrderType, dbo.sol_Orders.Date, dbo.sol_Orders.CustomerID, dbo.sol_Orders.TotalAmount, 
                        dbo.sol_Orders.DateClosed, dbo.sol_Orders.DatePaid, dbo.sol_Orders.FeeAmount, dbo.sol_Orders.Status, ISNULL(dbo.sol_Orders.Reference, '') as Reference, 
                        ISNULL(dbo.sol_Orders.Comments, '') as Comments, dbo.Qds_Settings.SetValue AS DepotID
FROM          dbo.sol_Customers INNER JOIN
                        dbo.sol_Orders ON dbo.sol_Customers.CustomerID = dbo.sol_Orders.CustomerID CROSS JOIN
                        dbo.Qds_Settings
WHERE      (dbo.Qds_Settings.Name = N'QuickDrop_DepotID') AND (dbo.sol_Customers.IsNew IS NULL OR dbo.sol_Customers.IsNew = 0) AND (dbo.sol_Orders.IsNew = 1)

GO



if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Orders_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Orders_Insert]
GO

CREATE PROCEDURE [dbo].[sol_Orders_Insert]
(
	@OrderType char(1),
	@WorkStationID int,
	@ComputerName varchar(50),
	@UserID uniqueidentifier,
	@UserName varchar(50),
	@Date datetime,
	@CashTrayID int,
	@CustomerID int,
	@Name varchar(50),
	@Address1 varchar(250),
	@Address2 varchar(250),
	@City varchar(100),
	@Province varchar(100),
	@Country varchar(50),
	@PostalCode varchar(50),
	@TotalAmount money,
	@DateClosed datetime,
	@FeeID int,
	@FeeAmount money,
	@Status char(1),
	@DatePaid datetime,
	@Tax1Amount money,
	@Tax2Amount money,
	@Reference varchar(100),
	@PaymentTypeID tinyint,
	--@SecurityCode nvarchar(12),
	@Comments nvarchar(256)
	--, 	@IsNew bit
)

AS

SET NOCOUNT ON

INSERT INTO [sol_Orders]
(
	[OrderType],
	[WorkStationID],
	[ComputerName],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[CustomerID],
	[Name],
	[Address1],
	[Address2],
	[City],
	[Province],
	[Country],
	[PostalCode],
	[TotalAmount],
	[DateClosed],
	[FeeID],
	[FeeAmount],
	[Status],
	[DatePaid],
	[Tax1Amount],
	[Tax2Amount],
	[Reference],
	[PaymentTypeID],
	[SecurityCode],
	[Comments]
	--, 	[IsNew]
)
VALUES
(
	@OrderType,
	@WorkStationID,
	@ComputerName,
	@UserID,
	@UserName,
	GetDate(), --@Date,			-- use sql server date
	@CashTrayID,
	@CustomerID,
	@Name,
	@Address1,
	@Address2,
	@City,
	@Province,
	@Country,
	@PostalCode,
	@TotalAmount,
	@DateClosed,
	@FeeID,
	@FeeAmount,
	@Status,
	@DatePaid,
	@Tax1Amount,
	@Tax2Amount,
	@Reference,
	@PaymentTypeID,
	right('000'+right(-convert(int, convert(varbinary(max), newid())),3),3),
	@Comments
	--, 	@IsNew
)

	SELECT CAST(scope_identity() AS int) 
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectAllByCustomerID]    Script Date: 6/16/2014 8:27:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByCustomerID]
(
	@OrderType char(1),
	@CustomerID int
)

AS

SET NOCOUNT ON
IF(@OrderType = NULL) SET @OrderType = ''

IF(@OrderType <> '')
BEGIN
	SELECT *
	FROM [sol_Orders]
	WHERE [OrderType] = @OrderType
	AND [CustomerID] = @CustomerID
	AND [Status] <> 'D' 
END
ELSE
BEGIN
	SELECT *
	FROM [sol_Orders]
	WHERE [CustomerID] = @CustomerID
	AND [Status] <> 'D' 
END
GO
/****** Object:  StoredProcedure [dbo].[sol_Orders_UpdateCustomerID]    Script Date: 1/14/2014 1:14:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_UpdateCustomerID]
(
	@OrderID int,
	@OrderType char(1),
	@CustomerID int
)

AS

SET NOCOUNT ON

	UPDATE [sol_Orders] WITH (ROWLOCK)
	SET [CustomerID] = @CustomerID
	WHERE [OrderID] = @OrderID	AND [OrderType] = @OrderType
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectWithSecCode]    Script Date: 06/11/2013 10:17:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectWithSecCode]
(
	@OrderID int,
	@SecurityCode nvarchar(12)
)

AS

SET NOCOUNT ON
SELECT * --[OrderID],
--	[OrderType],
--	[WorkStationID],
--	[ComputerName],
--	[UserID],
--	[UserName],
--	[Date],
--	[CashTrayID],
--	[CustomerID],
--	[Name],
--	[Address1],
--	[Address2],
--	[City],
--	[Province],
--	[Country],
--	[PostalCode],
--	[TotalAmount],
--	[DateClosed],
--	[FeeID],
--	[FeeAmount],
--	[Status],
--	[DatePaid],
--	[Tax1Amount],
--	[Tax2Amount],
--	[Reference],
--	[PaymentTypeID],
--	[SecurityCode]
FROM [sol_Orders]
WHERE [OrderID] = @OrderID
	AND [SecurityCode] = @SecurityCode
GO


/****** Object:  StoredProcedure [dbo].[sol_Orders_UpdateDates]    Script Date: 05/17/2012 10:17:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_UpdateDates]
(
	@OrderID int,
	@OrderType char(1),
	@Date varchar(23),
	@DateField varchar(25)	
)

AS

SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)
	
	IF(@Date = '') SET @Date = NULL 

	SET @sql = 'UPDATE [sol_Orders] WITH (ROWLOCK) ';

	if(@Date IS NULL)
	BEGIN
		SET @sql = @sql +
		'SET ['+@DateField+'] = '''+CONVERT(varchar(23), GetDate(), 120)+''' ';	
		
	END
	ELSE
	BEGIN
		SET @sql = @sql +
		'SET ['+@DateField+'] = '''+@Date+''' ';
	END

	SET @sql = @sql +
	'WHERE [OrderID] = '+CAST(@OrderID  AS VARCHAR)+ '	AND [OrderType] = '''+@OrderType+''' ';

EXEC(@sql)
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectAllByCustomerUnPaid]    Script Date: 03/18/2012 16:20:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByCustomerUnPaid]
(
	@OrderType char(1),	--temporary type B = both (R and Q)
	@CustomerID int,
	@UnPaid bit			-- 1 = true = Unpaid, 0 = false = all

)

AS

SET NOCOUNT ON

	DECLARE @sql NVARCHAR(3000)

	IF(@OrderType = NULL) SET @OrderType = ''
	IF(@UnPaid = null) SET @UnPaid = 0
	
	SET @sql = 
	'SELECT * '+
	'FROM [sol_Orders] '+
	'WHERE [CustomerID] = '+CAST(@CustomerID  AS VARCHAR)+' '+
	'AND [Status] <> ''D'' ';

	if(@OrderType = 'B')	--temporary type B = both (R and Q)
		SET @sql = @sql + 
		'AND ([OrderType] = ''R'' OR [OrderType] = ''Q'') ';
	else if(@OrderType != '')
		SET @sql = @sql + 
		'AND [OrderType] = '''+CAST(@OrderType  AS VARCHAR)+''' ';

	if(@UnPaid = 1)
		SET @sql = @sql + 
		'AND [Status] = ''O'' '+
		'AND [DatePaid] < [DATE] ';
			
	EXEC(@sql)

GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectAllByStatus]    Script Date: 1/13/2014 5:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByStatus]
(
	@OrderType char(1),
	@Status char (1),
	@CustomerID int,
    @DateFrom varchar(23),
    @DateTo varchar(23)

)

AS

SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)

    IF(@OrderType = '') SET @OrderType = NULL 

	IF(@CustomerID <1) SET @CustomerID = NULL
	
    IF(@DateFrom = '') SET @DateFrom = NULL 
    IF(@DateFrom IS NULL ) SET @DateFrom = '1950-01-01 00:00:00'
    IF(@DateTo = '') SET @DateTo = NULL 
    IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'

	SET @sql = 
	'SELECT * '+
	'FROM [sol_Orders] ';
	
	IF(@DateFrom IS NOT NULL)
		SET @sql = @sql + 'WHERE [Date] between '''+@DateFrom+''' and '''+@DateTo+''' AND ';	--+
		--'OR [DateClosed] between '''+@DateFrom+''' and '''+@DateTo+''' ) ';
	ELSE
		SET @sql = @sql + 'WHERE ';

	IF(@Status = 'U' )
		SET @sql = @sql + 
		'([Status] = ''O'' OR [Status] = ''A'')  
		 AND [DatePaid] < [Date] ';
	ELSE
		SET @sql = @sql + '[Status] = '''+@Status +''' ';

	SET @sql = @sql +
	'AND [DateClosed] >= [Date] ';

	IF(@CustomerID IS NOT NULL)
		SET @sql = @sql + 
			'AND [CustomerID] = '+CAST(@CustomerID  AS VARCHAR)+' ';

	IF(@OrderType IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
			'AND ([OrderType] = '''+@OrderType+''' ';
		IF(@OrderType = 'R')
		BEGIN
			SET @sql = @sql + 
			'OR [OrderType] = ''S'') ';
		END
		ELSE
			SET @sql = @sql + ') ';
	END
	EXEC(@sql)

GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectByOrderID]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Orders_SelectByOrderID]
(
	@OrderID int
)

AS

SET NOCOUNT ON

SELECT * --[OrderID],
	--[OrderType],
	--[WorkStationID],
	--[ComputerName],
	--[UserID],
	--[UserName],
	--[Date],
	--[CashTrayID],
	--[CustomerID],
	--[Name],
	--[Address1],
	--[Address2],
	--[City],
	--[Province],
	--[Country],
	--[PostalCode],
	--[TotalAmount],
	--[DateClosed],
	--[DatePaid],
	--[FeeID],
	--[FeeAmount],
	--[Tax1Amount],
	--[Tax2Amount],
	--[Status],
	--[Reference],
	--[PaymentTypeID], 
	--[SecurityCode] 
FROM [sol_Orders]
WHERE [OrderID] = @OrderID
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectAllLookup]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Orders_SelectAllLookup]
(
	@UserName varchar(50),
	@OrderType char(1),
	@Status char(1),
	@Status2 char(1)
)

AS

BEGIN
	SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)
	
	SET @sql = 
	'SELECT [OrderID],'+
	'(convert(varchar(20), [orderid])+'' - ''+ [UserName]+'' - ''+[ComputerName]+ '' - ''+ [Status]) as displayMember '+
	'FROM [sol_Orders] '+
	'WHERE ';
	
	if(@UserName = '')
	set @UserName = NULL

	IF(@UserName IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
		'[UserName] = '''+@UserName+''' AND ';
	END
		
	SET @sql = @sql + 
	'[OrderType] = '''+@OrderType+''' ';
	
	if(@Status = '')
	set @Status = NULL
	IF(@Status IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
		'AND ([Status] = '''+@Status+''' ';

		if(@Status2 = '')
		set @Status2 = NULL
		IF(@Status2 IS NOT NULL)
		BEGIN
			SET @sql = @sql + 
			'OR [Status] = '''+@Status2+''') ';
		END
		ELSE
			SET @sql = @sql + ') ';

	END

	print @sql
	
	SET @sql = @sql + 
	'Order By [OrderID] desc';
	
	EXEC(@sql)
END
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_SelectAllByDates]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Orders_SelectAllByDates]
(
   @OrderType char(1),
   @DateFrom varchar(23),
   @DateTo varchar(23),
   @Status char (1)
)

AS

SET NOCOUNT ON
DECLARE @sql NVARCHAR(3000)

   IF(@DateFrom = '') SET @DateFrom = NULL 
   IF(@DateFrom IS NULL ) SET @DateFrom = '1950-01-01 00:00:00'
   IF(@DateTo = '') SET @DateTo = NULL 
   IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'

SET @sql = 
'SELECT *  
FROM [sol_Orders] 
WHERE (';

if(@OrderType = 'R')
	SET @sql = @sql + '[OrderType] = ''R'' OR [OrderType] = ''S'')  ';
else --if(@OrderType = 'Q')
	SET @sql = @sql + '[OrderType] = '''+@OrderType+''') ';

SET @sql = @sql + 'AND ( [Date] between '''+@DateFrom+''' and '''+@DateTo+''' '+
	'OR [DateClosed] between '''+@DateFrom+''' and '''+@DateTo+''' ) ';

IF(@Status = 'U' )
	SET @sql = @sql + 'AND ( [Status] = ''O'' OR [Status] = ''A'' ) ';
ELSE IF(@Status != '' )
	SET @sql = @sql + 'AND [Status] = '''+@Status+''' ';

EXEC(@sql)
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_UpdateStatus]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Orders_UpdateStatus]
(
	@OrderID int,
	@OrderType char(1),
	@Status char(1)
)

AS

SET NOCOUNT ON
DECLARE @sql NVARCHAR(3000)
BEGIN
	UPDATE [sol_OrdersDetail] WITH (ROWLOCK)
	SET [Status] = @Status
	WHERE [OrderID] = @OrderID	AND [OrderType] = @OrderType

	SET @sql = 
	'UPDATE [sol_Orders] WITH (ROWLOCK) '+
	'SET ';
	
	if(@Status = 'A' OR @Status = 'O')
	BEGIN
		SET @sql = @sql + 
		'[Reference] = '''', '+
		'[DatePaid] = ''1753-1-1 12:00:00'', '+	--reverse payment
		'[PaymentTypeID] = 0, ';

		if(@OrderType != 'Q')
			SET @sql = @sql + 
			'[CustomerID] = 0, '+
			'[Name] = '''', '+
			'[Address1] = '''', '+
			'[Address2] = '''', '+
			'[City] = '''', '+
			'[Province] = '''', '+
			'[Country] = '''', '+
			'[PostalCode] = '''', ';
	END

	SET @sql = @sql + 
		'[Status] = '''+@Status+''' '+
	'WHERE [OrderID] = '+CAST(@OrderID  AS VARCHAR)+ '	AND [OrderType] = '''+@OrderType+''' ';
	
	EXEC(@sql)
	
END
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_CheckIntegrity]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Orders_CheckIntegrity]
(
	@OrderID int,
	@OrderType char(1)
)

AS

SET NOCOUNT ON

	DECLARE @TotalAmount money;
	--DECLARE @Quantity money;
	--DECLARE @Price money;
	DECLARE @DetailTotalAmount money;

SELECT 
	@TotalAmount = [TotalAmount]
FROM [sol_Orders]
WHERE [OrderID] = @OrderID
	AND [OrderType] = @OrderType
	
SELECT 
	--@Quantity = [Quantity],
	--@Price = [Price],
	@DetailTotalAmount = SUM([Amount])
FROM [sol_OrdersDetail]
WHERE [OrderID] = @OrderID
	AND [OrderType] = @OrderType
	
SELECT --@OrderID, @OrderType, 
 @TotalAmount AS TotalAmount, @DetailTotalAmount AS DetailTotalAmount
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_UpdateFees]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Orders_UpdateFees]
(
	@OrderID int,
	@OrderType char(1),
	@FeeID int,
	@FeeAmount money
)

AS

SET NOCOUNT ON

UPDATE [sol_Orders] WITH (ROWLOCK)
SET [FeeID] = @FeeID,
	[FeeAmount] = @FeeAmount
WHERE [OrderID] = @OrderID	AND [OrderType] = @OrderType
GO

/****** Object:  StoredProcedure [dbo].[sol_Orders_UpdateTaxes]    Script Date: 12/23/2011 12:29:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Orders_UpdateTaxes]
(
	@OrderID int,
	@OrderType char(1),
	@Tax1Amount money,
	@Tax2Amount money
)

AS

SET NOCOUNT ON

UPDATE [sol_Orders] WITH (ROWLOCK)
SET [Tax1Amount] = @Tax1Amount,
	[Tax2Amount] = @Tax2Amount
WHERE [OrderID] = @OrderID	AND [OrderType] = @OrderType

GO

/******************************************************************************
--Sol_OrdersDetail
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_OrdersDetail_SelectAllByStageID]    Script Date: 25/07/2017 10:16:55 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_OrdersDetail_SelectAllByStageID]
(
	@StageID int
)

AS

SET NOCOUNT ON

    SELECT   
		dbo.sol_OrdersDetail.DetailID
		, dbo.sol_OrdersDetail.OrderID
		, dbo.sol_OrdersDetail.OrderType
		, dbo.sol_Products.ProductID
		, dbo.sol_Products.ProDescription
		, ISNULL(dbo.sol_Products.[Weight], 0) as [Weight]
		, ISNULL(dbo.sol_Products.Volume, 0) as Volume
		, dbo.sol_OrdersDetail.Quantity
		, dbo.sol_Products.MasterProductID
    FROM dbo.sol_OrdersDetail 
    INNER JOIN dbo.sol_Products ON dbo.sol_OrdersDetail.ProductID = dbo.sol_Products.ProductID
    WHERE (dbo.sol_OrdersDetail.Status <> 'D') 
    AND (dbo.sol_OrdersDetail.StageID = @StageID)
    ORDER BY dbo.sol_OrdersDetail.OrderID

GO





/****** Object:  StoredProcedure [dbo].[sol_OrdersDetail_SelectByDetailID_ForConveyorID]    Script Date: 24/05/2016 09:37:41 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_SelectByDetailID_ForConveyorID]
(
	@DetailID int
)

AS

SET NOCOUNT ON

SELECT   
dbo.sol_OrdersDetail.DetailID
, dbo.sol_OrdersDetail.ProductID
, dbo.sol_Products.ProDescription
, dbo.sol_OrdersDetail.Quantity
, dbo.sol_OrdersDetail.Price
, dbo.sol_OrdersDetail.Amount
, dbo.sol_Products.MasterProductID
, dbo.sol_Products.AgencyID
, dbo.sol_Agencies.AutoGenerateTagNumber
FROM dbo.sol_OrdersDetail 
INNER JOIN dbo.sol_Products ON dbo.sol_OrdersDetail.ProductID = dbo.sol_Products.ProductID
INNER JOIN dbo.sol_Agencies ON dbo.sol_Agencies.AgencyID = dbo.sol_Products.AgencyID
WHERE (dbo.sol_OrdersDetail.DetailID = @DetailID) 
AND (dbo.sol_OrdersDetail.Status <> 'D') 
AND (dbo.sol_OrdersDetail.StageID = 0 OR dbo.sol_OrdersDetail.StageID IS NULL)
ORDER BY dbo.sol_OrdersDetail.OrderID
GO

/****** Object:  StoredProcedure [dbo].[sol_OrdersDetail_SelectAllByConveyorID]    Script Date: 20/05/2016 10:46:06 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_OrdersDetail_SelectAllByConveyorID]
(
	@ConveyorID int
)

AS

SET NOCOUNT ON

SELECT   
dbo.sol_OrdersDetail.DetailID
, dbo.sol_OrdersDetail.ProductID
, dbo.sol_Products.ProDescription
, dbo.sol_OrdersDetail.Quantity
, dbo.sol_OrdersDetail.Price
, dbo.sol_OrdersDetail.Amount
, dbo.sol_Products.MasterProductID
, dbo.sol_Products.AgencyID
, ISNULL(dbo.sol_Agencies.AutoGenerateTagNumber, 0) as AutoGenerateTagNumber
, dbo.sol_OrdersDetail.Status
FROM dbo.sol_OrdersDetail 
INNER JOIN dbo.sol_Products ON dbo.sol_OrdersDetail.ProductID = dbo.sol_Products.ProductID
INNER JOIN dbo.sol_Agencies ON dbo.sol_Agencies.AgencyID = dbo.sol_Products.AgencyID
WHERE (dbo.sol_OrdersDetail.ConveyorID = @ConveyorID) 
AND (dbo.sol_OrdersDetail.Status = 'A') 
AND (dbo.sol_OrdersDetail.StageID = 0 OR dbo.sol_OrdersDetail.StageID IS NULL)
ORDER BY dbo.sol_OrdersDetail.OrderID
GO

/****** Object:  StoredProcedure [dbo].[sol_OrdersDetail_Update]    Script Date: 10/19/2015 2:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_OrdersDetail_Update]
(
	@DetailID int,
	@OrderID int,
	@OrderType char(1),
	@Date datetime,
	@CategoryID int,
	@ProductID int,
	@Description varchar(100),
	@Quantity int,
	@Price money,
	@Amount money,
	@Status char(1),
	@CategoryButtonID int,
	@BagID int,
	@ConveyorID int,
	@StageID int
)

AS
DECLARE @OLDOrderID int,
	@OLDOrderType char(1),
	@OLDDate datetime,
	@OLDCategoryID int,
	@OLDProductID int,
	@OLDDescription varchar(100),
	@OLDQuantity int,
	@OLDPrice money,
	@OLDAmount money,
	@OLDStatus char(1),
	@OLDCategoryButtonID int,
	@OLDBagID int,	
	@OldConveyorID int,
	@OldStageID int,
	@SQL nvarchar(2000),
	@FoundChange bit = 0

SET NOCOUNT ON

SELECT @OLDOrderID = [OrderID],
	@OLDOrderType = [OrderType],
	@OLDDate = ISNULL([Date],''),
	@OLDCategoryID = [CategoryID],
	@OLDProductID = ISNULL([ProductID],0),
	@OLDDescription = [Description],
	@OLDQuantity = [Quantity],
	@OLDPrice = [Price],
	@OLDAmount = [Amount],
	@OLDStatus = ISNULL([Status],''),
	@OLDCategoryButtonID = ISNULL([CategoryButtonID],0),
	@OLDBagID = [BagID],
	@OldConveyorID = ISNULL([ConveyorID], 0),
	@OldStageID = ISNULL([StageID], 0)

FROM dbo.sol_OrdersDetail WHERE [DetailID] = @DetailID

SET @SQL = 'UPDATE dbo.sol_OrdersDetail WITH (ROWLOCK) SET '

If @OLDOrderID != @OrderID 
	BEGIN
		SET @SQL = @SQL + 'OrderID = ' + CONVERT(nvarchar(50), @OrderID)
		SET @FoundChange = 1
	END
If @OLDOrderType != @OrderType
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'OrderType = ''' + CONVERT(nvarchar(50), @OrderType) + ''''
		SET @FoundChange = 1
	END
If @OLDDate != ISNULL(@Date, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + '[Date] = ''' + CONVERT(nvarchar(50), @Date,120) + ''''
		SET @FoundChange = 1
	END
If @OLDCategoryID != @CategoryID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CategoryID = ' + CONVERT(nvarchar(50), @CategoryID)
		SET @FoundChange = 1
	END
If @OLDProductID != ISNULL(@ProductID, 0)
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'ProductID = ' + CONVERT(nvarchar(50), @ProductID)
		SET @FoundChange = 1
	END
If @OLDDescription != ISNULL(@Description, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Description = ''' + @Description + ''''
		SET @FoundChange = 1
	END
If @OLDQuantity != @Quantity
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Quantity = ' + CONVERT(nvarchar(50), @Quantity)
		SET @FoundChange = 1
	END
If @OLDPrice != @Price
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Price = ' + CONVERT(nvarchar(50), @Price)
		SET @FoundChange = 1
	END
If @OLDAmount != @Amount
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Amount = ' + CONVERT(nvarchar(50), @Amount)
		SET @FoundChange = 1
	END
If @OLDStatus != ISNULL(@Status, '')
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Status = ''' + CONVERT(nvarchar(50), @Status) + ''''
		SET @FoundChange = 1
	END
If @OLDCategoryButtonID != ISNULL(@CategoryButtonID, 0)
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CategoryButtonID = ' + CONVERT(nvarchar(50), @CategoryButtonID)
		SET @FoundChange = 1
	END
If @OLDBagID != @BagID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'BagID = ' + CONVERT(nvarchar(50), @BagID)
		SET @FoundChange = 1
	END
If @OldConveyorID != @ConveyorID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'ConveyorID = ' + CONVERT(nvarchar(50), @ConveyorID)
		SET @FoundChange = 1
	END
If @OldStageID != @StageID
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'StageID = ' + CONVERT(nvarchar(50), @StageID)
		SET @FoundChange = 1
	END

If @FoundChange = 1 
	BEGIN
		SET @SQL = @SQL + ' WHERE [DetailID] = ' + Convert(nvarchar(50), @DetailID)
		EXEC(@SQL)
	END
GO

/****** Object:  StoredProcedure [dbo].[Sol_OrdersDetail_NewToSync]    Script Date: 10/10/2015 8:47:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_OrdersDetail_NewToSync]

AS

SELECT      dbo.sol_OrdersDetail.DetailID, dbo.sol_OrdersDetail.OrderID, dbo.sol_OrdersDetail.Description, dbo.sol_OrdersDetail.Quantity, 
                        dbo.sol_OrdersDetail.Price, dbo.sol_OrdersDetail.Amount, dbo.sol_OrdersDetail.Status, dbo.sol_OrdersDetail.BagID, 
						dbo.sol_OrdersDetail.ConveyorID, dbo.sol_OrdersDetail.StageID, 
                        dbo.Qds_Settings.SetValue AS DepotID
FROM          dbo.sol_Orders INNER JOIN
                        dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID CROSS JOIN
                        dbo.Qds_Settings
WHERE      (dbo.Qds_Settings.Name = N'QuickDrop_DepotID') AND (dbo.sol_Orders.IsNew IS NULL OR dbo.sol_Orders.IsNew = 0) AND (dbo.sol_OrdersDetail.IsNew = 1)

GO

/******************************************************************************
--Sol_Customers
******************************************************************************/
/****** Object:  View [dbo].[vw_sol_Customers_PendingBags]    Script Date: 2/10/2016 8:36:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_sol_Customers_PendingBags]
AS
SELECT        dbo.Qds_Drop.CustomerID, COUNT(dbo.Qds_Bag.BagID) AS PendingBags
FROM            dbo.Qds_Bag INNER JOIN
                         dbo.Qds_Drop ON dbo.Qds_Bag.DropID = dbo.Qds_Drop.DropID
WHERE        (dbo.Qds_Bag.DateCounted < 2)
GROUP BY dbo.Qds_Drop.CustomerID

GO


/****** Object:  StoredProcedure [dbo].[sol_Customers_Update]    Script Date: 19/10/2015 11:12:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Customers_Update]
(
	@CustomerID int,
	@CustomerCode varchar(10),
	@Name varchar(50),
	@Contact varchar(50),
	@Address1 varchar(250),
	@Address2 varchar(250),
	@City varchar(100),
	@Province varchar(100),
	@Country varchar(50),
	@PostalCode varchar(50),
	@Email nvarchar(256),
	@LoweredEmail nvarchar(256),
	@IsActive bit,
	@PhoneNumber nvarchar(20),
	@Notes nvarchar(512),
	@Password nvarchar(128),
	@DepotID char(6),
	@CardNumber nvarchar(50),
	@CardTypeID int,
	@SolumCustomer bit,
	@QuickDropCustomer bit
)

AS

	if @CustomerCode IS NULL SET @CustomerCode = ''
	if @Name IS NULL SET @Name = ''
	if @Contact IS NULL SET @Contact = ''
	if @Address1 IS NULL SET @Address1 = ''
	if @Address2 IS NULL SET @Address2 = ''
	if @City IS NULL SET @City = ''
	if @Province IS NULL SET @Province = ''
	if @Country IS NULL SET @Country = ''
	if @PostalCode IS NULL SET @PostalCode = ''
	if @Email IS NULL SET @Email = ''
	if @LoweredEmail IS NULL SET @LoweredEmail = ''
	if @PhoneNumber IS NULL SET @PhoneNumber = ''


DECLARE	@OldCustomerID int,
	@OldCustomerCode varchar(10),
	@OldName varchar(50),
	@OldContact varchar(50),
	@OldAddress1 varchar(250),
	@OldAddress2 varchar(250),
	@OldCity varchar(100),
	@OldProvince varchar(100),
	@OldCountry varchar(50),
	@OldPostalCode varchar(50),
	@OldEmail nvarchar(256),
	@OldLoweredEmail nvarchar(256),
	@OldIsActive bit,
	@OldPhoneNumber nvarchar(20),
	@OldNotes nvarchar(512),
	@OldPassword nvarchar(128),
	@OldDepotID char(6),
	@OldCardNumber nvarchar(50),
	@OldCardTypeID int,
	@OldSolumCustomer bit,
	@OldQuickDropCustomer bit

DECLARE @SQL nvarchar(4000),
	@FoundChange bit = 0

SET NOCOUNT ON
--check what was updated
SELECT @OldCustomerID = [CustomerID],
	@OldCustomerCode = ISNULL([CustomerCode], ''),
	@OldName = ISNULL([Name], ''),
	@OldContact = ISNULL([Contact], ''),
	@OldAddress1 = ISNULL([Address1], ''),
	@OldAddress2 = ISNULL([Address2], ''),
	@OldCity = ISNULL([City], ''),
	@OldProvince = ISNULL([Province], ''),
	@OldCountry = ISNULL([Country], ''),
	@OldPostalCode = ISNULL([PostalCode], ''),
	@OldEmail = ISNULL([Email], ''),
	@OldLoweredEmail = ISNULL([LoweredEmail], ''),
	@OldIsActive = [IsActive],
	@OldPhoneNumber = ISNULL([PhoneNumber], ''),
	@OldNotes = ISNULL([Notes], ''),
	@OldPassword = [Password],
	@OldDepotID = [DepotID],
	@OldCardNumber = [CardNumber],
	@OldCardTypeID = [CardTypeID],
	@OldSolumCustomer = [SolumCustomer],
	@OldQuickDropCustomer = [QuickDropCustomer]
FROM [sol_Customers]
WHERE [CustomerID] = @CustomerID

SET @SQL = 'UPDATE [sol_Customers] WITH (ROWLOCK) SET '

If @OldCustomerID != @CustomerID 
	BEGIN
		SET @SQL = @SQL + 'CustomerID = ' + CONVERT(nvarchar(50), @CustomerID)
		SET @FoundChange = 1
	END

If @OldCustomerCode != @CustomerCode 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CustomerCode = ''' + CONVERT(nvarchar(50), @CustomerCode) + ''' '
		SET @FoundChange = 1
	END

If @OldName != @Name 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Name = ''' + CONVERT(nvarchar(50), @Name) + ''' '
		SET @FoundChange = 1
	END

If @OldContact != @Contact 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Contact = ''' + CONVERT(nvarchar(50), @Contact) + ''' '
		SET @FoundChange = 1
	END

If @OldAddress1 != @Address1 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Address1 = ''' + CONVERT(nvarchar(250), @Address1) + ''' '
		SET @FoundChange = 1
	END

If @OldAddress2 != @Address2 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Address2 = ''' + CONVERT(nvarchar(250), @Address2) + ''' '
		SET @FoundChange = 1
	END

If @OldCity != @City 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'City = ''' + CONVERT(nvarchar(100), @City) + ''' '
		SET @FoundChange = 1
	END

If @OldProvince != @Province 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Province = ''' + CONVERT(nvarchar(100), @Province) + ''' '
		SET @FoundChange = 1
	END
If @OldCountry != @Country 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Country = ''' + CONVERT(nvarchar(50), @Country) + ''' '
		SET @FoundChange = 1
	END
If @OldPostalCode != @PostalCode 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'PostalCode = ''' + CONVERT(nvarchar(50), @PostalCode) + ''' '
		SET @FoundChange = 1
	END
If @OldEmail != @Email 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Email = ''' + CONVERT(nvarchar(256), @Email) + ''' '
		SET @FoundChange = 1
	END
If @OldLoweredEmail != @LoweredEmail 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'LoweredEmail = ''' + CONVERT(nvarchar(256), @LoweredEmail) + ''' '
		SET @FoundChange = 1
	END
If @OldIsActive != @IsActive 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'IsActive = ' + CONVERT(nvarchar(50), @IsActive)
		SET @FoundChange = 1
	END
If @OldPhoneNumber != @PhoneNumber 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'PhoneNumber = ''' + CONVERT(nvarchar(20), @PhoneNumber) + ''' '
		SET @FoundChange = 1
	END
If @OldNotes != @Notes 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Notes = ''' + CONVERT(nvarchar(512), @Notes) + ''' '
		SET @FoundChange = 1
	END
If @OldPassword != @Password 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'Password = ''' + CONVERT(nvarchar(128), @Password) + ''' '
		SET @FoundChange = 1
	END
If @OldDepotID != @DepotID 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'DepotID = ''' + CONVERT(nvarchar(10), @DepotID) + ''' '
		SET @FoundChange = 1
	END
If @OldCardNumber != @CardNumber 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CardNumber = ''' + CONVERT(nvarchar(50), @CardNumber) + ''' '
		SET @FoundChange = 1
	END
If @OldCardTypeID != @CardTypeID 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'CardTypeID = ' + CONVERT(nvarchar(50), @CardTypeID)
		SET @FoundChange = 1
	END
If @OldSolumCustomer != @SolumCustomer 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'SolumCustomer = ' + CONVERT(nvarchar(50), @SolumCustomer)
		SET @FoundChange = 1
	END
If @OldQuickDropCustomer != @QuickDropCustomer 
	BEGIN
		If @FoundChange = 1 SET @SQL = @SQL + ','
		SET @SQL = @SQL + 'QuickDropCustomer = ' + CONVERT(nvarchar(50), @QuickDropCustomer)
		SET @FoundChange = 1
	END

If @FoundChange = 1 
	BEGIN
		SET @SQL = @SQL + ' WHERE [CustomerID] = ' + Convert(nvarchar(50), @CustomerID)
		EXEC(@SQL)
		--select @SQL
	END

GO

/****** Object:  StoredProcedure [dbo].[sol_Customers_NewToSync]    Script Date: 10/10/2015 8:47:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Customers_NewToSync]

AS

SELECT  dbo.sol_Customers.CustomerID
, dbo.sol_Customers.Name
, ISNULL(dbo.sol_Customers.Contact, '') as Contact
, ISNULL(dbo.sol_Customers.Address1, '') as Address1
, ISNULL(dbo.sol_Customers.Address2, '') as Address2
, ISNULL(dbo.sol_Customers.City, '') as City
, ISNULL(dbo.sol_Customers.Province, '') as Province
, ISNULL(dbo.sol_Customers.PostalCode, '') as PostalCode
, dbo.sol_Customers.Email
, dbo.sol_Customers.IsActive
, ISNULL(dbo.sol_Customers.PhoneNumber, '') as PhoneNumber
, dbo.sol_Customers.Password
, dbo.Qds_Settings.SetValue AS DepotID
FROM dbo.Qds_Settings 
CROSS JOIN dbo.sol_Customers
WHERE (dbo.Qds_Settings.Name = N'QuickDrop_DepotID') 
AND (dbo.sol_Customers.IsNew = 1) 
AND (CHARINDEX('@',dbo.sol_Customers.Email)>0) 
AND (dbo.sol_Customers.IsActive = 1) 
GO



/****** Object:  StoredProcedure [dbo].[sol_Customers_SelectAllByCustomerActiveType]    Script Date: 20/11/2014 10:58:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Customers_SelectAllByCustomerActiveType]   --test [sol_Customers_SelectAllByCustomerActiveType] 1, 'Joe', 1
(							--  1 = solum, 2 = quickdrop else = all
	@CustomerType smallint, -- -1 = all 0 = solum 1 = quickdrop
	@Name [varchar](50),
	@ActiveType smallint 	-- -1 = all 0 = inactivos 1 = activos

)

AS

SET NOCOUNT ON

	DECLARE @sql NVARCHAR(3000)
	SET @sql = 
	'SELECT * '+
	', ISNULL( (SELECT Balance FROM dbo.vw_sol_Customers_Balance WHERE (CustomerID = c.[CustomerID]) ), 0) as CustomerBalance '+
	', ISNULL( (SELECT SolumBalance FROM dbo.vw_sol_Customers_Balance WHERE (CustomerID = c.[CustomerID]) ), 0) as CustomerSolumBalance '+
	', ISNULL( (SELECT QuickDropBalance FROM dbo.vw_sol_Customers_Balance WHERE (CustomerID = c.[CustomerID]) ), 0) as CustomerQuickDropBalance '+
	', ISNULL( (SELECT PendingBags FROM dbo.vw_sol_Customers_PendingBags WHERE (CustomerID = c.[CustomerID]) ), 0) as CustomerPendingBags '+   --kevin added Feb 10, 2016
	'FROM [sol_Customers] as c ';

	DECLARE @FlagWhere bit = 0

	IF(@CustomerType = 0)
	BEGIN
		SET @FlagWhere = 1
		SET @sql = @sql + 'WHERE c.[SolumCustomer] = 1 ';
	END
	ELSE IF(@CustomerType = 1)
	BEGIN
		SET @FlagWhere = 1
		SET @sql = @sql + 'WHERE c.[QuickDropCustomer] = 1 ';
	END

	if(@Name != '')
	BEGIN
		IF(@FlagWhere = 0)
		BEGIN
			SET @sql = @sql + ' WHERE '
		END
		ELSE
			SET @sql = @sql + ' AND '

		SET @sql = @sql + 'c.[Name] LIKE '''+@Name+'%'' ';
	END

	if(@ActiveType >= 0)
	BEGIN
		IF(@FlagWhere = 0)
		BEGIN
			SET @sql = @sql + ' WHERE '
		END
		ELSE
			SET @sql = @sql + ' AND '

		SET @sql = @sql + 'c.[IsActive] = '+ CONVERT(char(1), @ActiveType);
	END


	SET @sql = @sql +
	'ORDER BY c.[Name] ';
EXEC(@sql)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_SelectAllByCustomerType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_SelectAllByCustomerType]
GO

CREATE PROCEDURE [dbo].[sol_Customers_SelectAllByCustomerType]
(
	@CustomerType int, -- 1 = solum 2 = quickdrop, else = all
	@Name [varchar](50),
	@OnlyActives bit 

)

AS

SET NOCOUNT ON

	DECLARE @sql NVARCHAR(3000)
	SET @sql = 
	'SELECT * '+
	', ISNULL( (SELECT Balance FROM dbo.vw_sol_Customers_Balance WHERE (CustomerID = c.[CustomerID]) ), 0) as CustomerBalance '+
	'FROM [sol_Customers] as c ';

	IF(@CustomerType = 1)
		SET @sql = @sql + 'WHERE c.[SolumCustomer] = 1 ';
	ELSE --IF(@CustomerType = 2)
		SET @sql = @sql + 'WHERE c.[QuickDropCustomer] = 1 ';

	if(@Name != '')
		SET @sql = @sql + 'AND c.[Name] LIKE '''+@Name+'%'' ';

	if(@OnlyActives = 1)
		SET @sql = @sql + 'AND c.[IsActive] = 1 ';


	SET @sql = @sql +
	'ORDER BY c.[Name] ';
EXEC(@sql)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_SelectByCardNumber]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_SelectByCardNumber]
GO

CREATE PROCEDURE [dbo].[sol_Customers_SelectByCardNumber]
(
	@CardNumber nvarchar(50)
)

AS

SET NOCOUNT ON

DECLARE @CustomerID INT 

SELECT @CustomerId = [CustomerID]
FROM [sol_Customers]
WHERE [CardNumber] = @CardNumber

IF(@CustomerId > 0)
	SELECT * 
	FROM [sol_Customers]
	WHERE [CardNumber] = @CardNumber
ELSE
	SELECT *
	FROM [sol_Customers]
	WHERE [PhoneNumber] = @CardNumber
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sol_Customers_SelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sol_Customers_SelectAll]
GO

CREATE PROCEDURE [dbo].[sol_Customers_SelectAll]

AS

SET NOCOUNT ON

SELECT [Sol_Customers].[CustomerID],
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
	[CardTypeID],
	[SolumCustomer],
	[QuickDropCustomer],
	--[IsNew],
    vw_sol_Customers_Balance.Balance
FROM [sol_Customers] 
	LEFT OUTER JOIN dbo.vw_sol_Customers_Balance ON sol_Customers.CustomerID = vw_sol_Customers_Balance.CustomerID
GO

/****** Object:  View [dbo].[vw_sol_Customers_Balance]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_sol_Customers_Balance]
AS
	SELECT  o.CustomerID, SUM(o.TotalAmount - o.FeeAmount) as Balance
	, ISNULL((
		SELECT  SUM(TotalAmount - FeeAmount)
		FROM dbo.sol_Orders
		WHERE (DatePaid = CONVERT(DATETIME, '1753-01-01 12:00:00', 102))
		AND OrderType = 'R'
		AND Status = 'O'
		GROUP BY CustomerID
		HAVING (CustomerID = o.CustomerID)

	), 0) as SolumBalance
	, ISNULL((
		SELECT  SUM(TotalAmount - FeeAmount)
		FROM dbo.sol_Orders
		WHERE (DatePaid = CONVERT(DATETIME, '1753-01-01 12:00:00', 102))
		AND OrderType = 'Q'
		AND Status = 'O'
		GROUP BY CustomerID
		HAVING (CustomerID = o.CustomerID)

	), 0) as QuickDropBalance

	FROM dbo.sol_Orders as o
	WHERE (o.DatePaid = CONVERT(DATETIME, '1753-01-01 12:00:00', 102))
	AND o.Status = 'O'
	GROUP BY o.CustomerID
	HAVING (o.CustomerID > 0)

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Customers_Balance](
      @CustomerID int,
      @DateTo varchar(23)	--the date should include 23:59:59 as the time.
      )
AS 

BEGIN
   SET NOCOUNT ON

      IF(@DateTo IS NULL) 
      BEGIN   
            SELECT Balance
            FROM   dbo.vw_sol_Customers_Balance
            WHERE (CustomerID = @CustomerID)
      END
      ELSE
      BEGIN
            SELECT CustomerID, SUM(TotalAmount - FeeAmount) AS Balance
            FROM   dbo.sol_Orders
            WHERE  (DatePaid = CONVERT(DATETIME, '1753-01-01 12:00:00', 102)
                  OR DatePaid > @DateTo)
                  AND DateClosed <= @DateTo 
            GROUP BY CustomerID
            HAVING (CustomerID > 0)
      END
END
GO

/****** Object:  StoredProcedure [dbo].[sol_Customers_SelectAllByName]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Customers_SelectAllByName]
(
	@Name [varchar](50)
)

AS

SET NOCOUNT ON

SELECT [CustomerID],
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
	[CardTypeID],
	[SolumCustomer],
	[QuickDropCustomer]
	--, 	[IsNew]
	, ISNULL( (SELECT Balance FROM dbo.vw_sol_Customers_Balance WHERE (CustomerID = [sol_Customers].[CustomerID]) ), 0) as CustomerBalance 
	, ISNULL( (SELECT SolumBalance FROM dbo.vw_sol_Customers_Balance WHERE (CustomerID = [sol_Customers].[CustomerID]) ), 0) as CustomerSolumBalance 
	, ISNULL( (SELECT QuickDropBalance FROM dbo.vw_sol_Customers_Balance WHERE (CustomerID = [sol_Customers].[CustomerID]) ), 0) as CustomerQuickDropBalance 
	, ISNULL( (SELECT PendingBags FROM dbo.vw_sol_Customers_PendingBags WHERE (CustomerID = [sol_Customers].[CustomerID]) ), 0) as CustomerPendingBags

FROM [sol_Customers]
WHERE [Name] LIKE @Name+'%'
GO

/*****************************************************************************
--Sol_Stage
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Stage_SelectProductsByShipmentID]    Script Date: 04/08/2017 10:12:40 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_Stage_SelectProductsByShipmentID]
(
	@ShipmentID int
)

AS

SET NOCOUNT ON

SELECT --* 
s.[Stageid], s.[Date]
, s.[DateClosed]
, od.BagID
--, ISNULL(s.[DateClosed], CONVERT(datetime, '1753-01-01 12:00:00.000', 120)) as DateClosed
, p.ProductID, p.ProductCode, ISNULL(p.[Weight], 0) as [Weight]
, od.Quantity
, mp.ProDescription

FROM sol_Stage as s
INNER JOIN  dbo.sol_OrdersDetail as od ON od.StageID = s.StageID
AND (od.Status <> 'D') 
INNER JOIN dbo.sol_Products as p ON p.ProductID = od.ProductID
INNER JOIN dbo.sol_Products as mp ON mp.ProductID = p.MasterProductID

WHERE s.[ShipmentID] = @ShipmentID

--ORDER BY dbo.sol_OrdersDetail.OrderID

GO


/****** Object:  StoredProcedure [dbo].[sol_Stage_SelectAllByShipmentID]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Stage_SelectAllByShipmentID]
(
	@ShipmentID int
)

AS

SET NOCOUNT ON

SELECT [StageID],
	[ShipmentID],
	[UserID],
	[UserName],
	[Date],
	[TagNumber],
	s.[ContainerID],
	[ContainerDescription],
	s.[ProductID],
	p.[ProName] as ProductName,
	[Dozen],
	[Quantity],
	p.[Price],
	[Remarks],
	[Status],
	[DateClosed]
FROM [sol_Stage] as s
INNER JOIN [Sol_Products] as p ON p.ProductId = [s].[ProductID]
WHERE [ShipmentID] = @ShipmentID

GO

/****** Object:  StoredProcedure [dbo].[sol_Stage_DeleteAllByShipmentID]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Stage_DeleteAllByShipmentID]
(
	@ShipmentID int
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Stage] WITH (ROWLOCK)
WHERE [ShipmentID] = @ShipmentID
GO

/****** Object:  StoredProcedure [dbo].[sol_Stage_DeleteAllByShipmentIdTagNumber]    Script Date: 6/27/2014 10:01:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_Stage_DeleteAllByShipmentIdTagNumber]
(
	@ShipmentID int,
	@TagNumber nvarchar(50)
)

AS

SET NOCOUNT ON

DELETE FROM [sol_Stage] WITH (ROWLOCK)
WHERE [ShipmentID] = @ShipmentID 
AND [TagNumber] = @TagNumber

GO

/****** Object:  StoredProcedure [dbo].[sol_Stage_SelectByShipMentIdContainerId]    Script Date: 10/25/2012 16:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Stage_SelectByShipMentIdContainerId]
(
	@ShipmentID int,
	@ContainerID int
)

AS
SET NOCOUNT ON
	 SELECT [StageID], 
		[ShipmentID], 
		[UserID], 
		[UserName], 
		[Date], 
		[TagNumber], 
		[ContainerID], 
		[ContainerDescription], 
		[ProductID], 
		[ProductName], 
		[Dozen], 
		[Quantity], 
		[Price], 
		[Remarks], 
		[Status],
		[DateClosed]
	FROM [sol_Stage] 
	WHERE [ShipmentID] = @ShipmentID 
	AND [ContainerID] = @ContainerID
GO

/****** Object:  StoredProcedure [dbo].[sol_Stage_SelectAllByAgency]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Stage_SelectAllByAgency]
(
	@Status char(1),
	@Agency int

)

AS
BEGIN
	SET NOCOUNT ON
		
	if(@Agency < 1)
	BEGIN
		SELECT [sol_Stage].[StageID], 
			[sol_Stage].[ShipmentID], 
			[sol_Stage].[UserID], 
			[sol_Stage].[UserName], 
			[sol_Stage].[Date], 
			[sol_Stage].[TagNumber], 
			[sol_Stage].[ContainerID], 
			[sol_Stage].[ContainerDescription], 
			[sol_Stage].[ProductID], 
			[sol_Products].[ProName] as ProductName, 
			[sol_Stage].[Dozen], 
			[sol_Stage].[Quantity], 
			[sol_Stage].[Price], 
			[sol_Stage].[Remarks], 
			[sol_Stage].[Status], 
			[sol_Stage].[DateClosed],
			[sol_Products].AgencyID,
			[sol_Stage].[TagNumber] + ' - ' + [sol_Products].[ProName] + ' - ' + (CONVERT(varchar(20), [sol_Stage].[Quantity])) as [fullDescription]
		FROM [sol_Stage] 
		INNER JOIN [sol_Products] ON [sol_Stage].ProductID = [sol_Products].ProductID 
		WHERE [sol_Stage].[Status] = @Status
	END
	ELSE
	BEGIN
		SELECT [sol_Stage].[StageID], 
			[sol_Stage].[ShipmentID], 
			[sol_Stage].[UserID], 
			[sol_Stage].[UserName], 
			[sol_Stage].[Date], 
			[sol_Stage].[TagNumber], 
			[sol_Stage].[ContainerID], 
			[sol_Stage].[ContainerDescription], 
			[sol_Stage].[ProductID], 
			[sol_Products].[ProName] as ProductName, 
			[sol_Stage].[Dozen], 
			[sol_Stage].[Quantity], 
			[sol_Stage].[Price], 
			[sol_Stage].[Remarks], 
			[sol_Stage].[Status], 
			[sol_Stage].[DateClosed],
			[sol_Products].AgencyID,
			[sol_Stage].[TagNumber] + ' - ' + [sol_Products].[ProName] + ' - ' + (CONVERT(varchar(20), [sol_Stage].[Quantity])) as [fullDescription]
		FROM [sol_Stage] 
		INNER JOIN [sol_Products] ON [sol_Stage].ProductID = [sol_Products].ProductID 
		WHERE [sol_Stage].[Status] = @Status
		AND [sol_Products].AgencyID = @Agency
	END
	
END
GO

/****** Object:  StoredProcedure [dbo].[sol_Stage_SelectAllByAgencyClosed]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Stage_SelectAllByAgencyClosed]
(
	@Status char(1),
	@Agency int

)

AS
BEGIN
	SET NOCOUNT ON
		
	if(@Agency < 1)
	BEGIN
		SELECT [sol_Stage].[StageID], 
			[sol_Stage].[ShipmentID], 
			[sol_Stage].[UserID], 
			[sol_Stage].[UserName], 
			[sol_Stage].[Date], 
			[sol_Stage].[TagNumber], 
			[sol_Stage].[ContainerID], 
			[sol_Stage].[ContainerDescription], 
			[sol_Stage].[ProductID], 
			[sol_Products].[ProName] as ProductName, 
			[sol_Stage].[Dozen], 
			[sol_Stage].[Quantity], 
			[sol_Stage].[Price], 
			[sol_Stage].[Remarks], 
			[sol_Stage].[Status], 
			[sol_Stage].[DateClosed],
			[sol_Products].AgencyID,
			[sol_Stage].[TagNumber] + ' - ' + [sol_Products].[ProName] + ' - ' + (CONVERT(varchar(20), [sol_Stage].[Dozen])) as [fullDescription]
		FROM [sol_Stage] 
		INNER JOIN [sol_Products] ON [sol_Stage].ProductID = [sol_Products].ProductID 
		WHERE [sol_Stage].[Status] = @Status
		AND [sol_Stage].[DateClosed] >= [sol_Stage].[Date]
	END
	ELSE
	BEGIN
		SELECT [sol_Stage].[StageID], 
			[sol_Stage].[ShipmentID], 
			[sol_Stage].[UserID], 
			[sol_Stage].[UserName], 
			[sol_Stage].[Date], 
			[sol_Stage].[TagNumber], 
			[sol_Stage].[ContainerID], 
			[sol_Stage].[ContainerDescription], 
			[sol_Stage].[ProductID], 
			[sol_Products].[ProName] as ProductName, 
			[sol_Stage].[Dozen], 
			[sol_Stage].[Quantity], 
			[sol_Stage].[Price], 
			[sol_Stage].[Remarks], 
			[sol_Stage].[Status], 
			[sol_Stage].[DateClosed],
			[sol_Products].AgencyID,
			[sol_Stage].[TagNumber] + ' - ' + [sol_Products].[ProName] + ' - ' + (CONVERT(varchar(20), [sol_Stage].[Dozen])) as [fullDescription]
		FROM [sol_Stage] 
		INNER JOIN [sol_Products] ON [sol_Stage].ProductID = [sol_Products].ProductID 
		WHERE [sol_Stage].[Status] = @Status
		AND [sol_Stage].[DateClosed] >= [sol_Stage].[Date]
		AND [sol_Products].AgencyID = @Agency
	END
	
END
GO


/****** Object:  StoredProcedure [dbo].[sol_Stage_SelectAllByStatus]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Stage_SelectAllByStatus]
(
	@Status char(1)
)

AS

SET NOCOUNT ON

SELECT [StageID],
	[ShipmentID],
	[UserID],
	[UserName],
	[Date],
	[TagNumber],
	[ContainerID],
	[ContainerDescription],
	[ProductID],
	[ProductName],
	[Dozen],
	[Quantity],
	[Price],
	[Remarks],
	[Status],
	[DateClosed]
FROM [sol_Stage]
WHERE [Status] = @Status
GO
/****** Object:  StoredProcedure [dbo].[sol_Stage_SelectByTagNumberStatus]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Stage_SelectByTagNumberStatus]
(
	@TagNumber nvarchar(50),
	@Status char(1)
)

AS
SET NOCOUNT ON
DECLARE @sql NVARCHAR(3000)
	IF(@Status = '') SET @Status = NULL 

	SET @sql = 
	' SELECT [StageID], 
		[ShipmentID], 
		[UserID], 
		[UserName], 
		[Date], 
		[TagNumber], 
		[ContainerID], 
		[ContainerDescription], 
		[ProductID], 
		[ProductName], 
		[Dozen], 
		[Quantity], 
		[Price], 
		[Remarks], 
		[Status],
		[DateClosed]
	FROM [sol_Stage] 
	WHERE [TagNumber] = '''+@TagNumber+''' ';
	
	if(@Status IS NOT NULL)
	BEGIN
		SET @sql = @sql +
		'AND [Status] = '''+@Status+''' ';
	END
	EXEC(@sql)
GO

/****** Object:  StoredProcedure [dbo].[sol_Stage_UpdateStatus]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Stage_UpdateStatus]
(
	@ShipmentID int,
	@TagNumber nvarchar(50),
	@StatusOld char(1),
	@Status char(1)
)

AS

SET NOCOUNT ON

UPDATE [sol_Stage] WITH (ROWLOCK)
SET [ShipmentID] = @ShipmentID, 
	[Status] = @Status
WHERE [TagNumber] = @TagNumber
AND [Status] = @StatusOld
GO

/****** Object:  StoredProcedure [dbo].[sol_Stage_UpdateStatusByShipmentId]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Stage_UpdateStatusByShipmentId]
(
	@ShipmentID int,
	@Status char(1)
)

AS

SET NOCOUNT ON

UPDATE [sol_Stage] WITH (ROWLOCK)
SET [Status] = @Status
WHERE [ShipmentID] = @ShipmentID
GO

/*****************************************************************************
--Sol_Shipment
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Shipment_Detail]    Script Date: 9/14/2013 2:33:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Shipment_Detail]
(
	@DateFrom varchar(23),
	@DateTo varchar(23),
	@RBillNumber varchar(50)
)

AS

DECLARE @sql NVARCHAR(3000)
IF(@DateFrom = '') SET @DateFrom = NULL
--IF(@DateFrom IS NULL ) SET @DateFrom = '1950-01-01 00:00:00'
IF(@DateTo = '') SET @DateTo = NULL 
--IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'
IF(@RBillNumber = '') SET @RBillNumber = NULL 

SET @sql = 

'SELECT '+
'	sh.[RBillNumber], sh.[AgencyName], sh.[ShippedDate], sh.[TrailerNumber],  '+
'	sh.[ProBillNumber], st.[TagNumber], p.[ProductCode], p.[ProName] as ProductName, CONVERT(decimal(18,4), st.Quantity) / 12 as Dozen, st.[Quantity] '+
'FROM sol_Shipment AS sh '+
'INNER JOIN sol_Stage AS st ON sh.[ShipmentID] = st.[ShipmentID] '+
'INNER JOIN sol_Products AS p ON p.[ProductID] = st.[ProductID] ';

IF(@RBillNumber IS NOT NULL)
BEGIN
	SET @sql = @sql +
	'WHERE sh.[RBillNumber] = '''+@RBillNumber+''' ';
END
ELSE IF(@DateFrom IS NOT NULL)
BEGIN
	SET @sql = @sql +
	' AND sh.[Date] between '''+@DateFrom+''' AND '''+@DateTo+''' ';
END

SET @sql = @sql +
	'ORDER BY st.[ProductName] ';
EXEC(@sql)
GO

/****** Object:  StoredProcedure [dbo].[sol_Shipment_UpdateERBillTransmitted]    Script Date: 10/26/2012 16:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Shipment_UpdateERBillTransmitted]
(
	@ShipmentID int,
	@eRBillTransmitted bit
)

AS

SET NOCOUNT ON

UPDATE [sol_Shipment] WITH (ROWLOCK)
SET [eRBillTransmitted] = @eRBillTransmitted
WHERE [ShipmentID] = @ShipmentID
GO


/****** Object:  StoredProcedure [dbo].[sol_Shipment_UpdateERBill]    Script Date: 10/24/2012 16:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Shipment_UpdateERBill]
(
	@ShipmentID int,
	@CarrierID int,
	@PlantID int,
	@TrailerNumber nvarchar(50),
	@ProBillNumber nvarchar(50),
	@ShippedDate datetime,
	@SealNumber nvarchar(50),
	@LoadReference nvarchar(50),
	@eRBillTransmitted bit
)

AS

SET NOCOUNT ON

UPDATE [sol_Shipment] WITH (ROWLOCK)
SET [CarrierID] = @CarrierID,
	[PlantID] = @PlantID,
	[TrailerNumber] = @TrailerNumber,
	[ProBillNumber] = @ProBillNumber,
	[ShippedDate] = @ShippedDate,
	[SealNumber] = @SealNumber,
	[LoadReference] = @LoadReference,
	[eRBillTransmitted] = @eRBillTransmitted

WHERE [ShipmentID] = @ShipmentID
GO

/****** Object:  StoredProcedure [dbo].[sol_Shipment_UpdateStatus]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Shipment_UpdateStatus]
(
	@ShipmentID int,
	@Status char(1)
)

AS

SET NOCOUNT ON

IF(@Status = 'S')
BEGIN
	UPDATE [sol_Shipment] WITH (ROWLOCK)
	SET [Status] = @Status,
	[ShippedDate] = GETDATE()
	WHERE [ShipmentID] = @ShipmentID
END
ELSE
BEGIN
	UPDATE [sol_Shipment] WITH (ROWLOCK)
	SET [Status] = @Status,
	[ShippedDate] = '1753-1-1 12:00:00'
	WHERE [ShipmentID] = @ShipmentID
END
GO

/****** Object:  StoredProcedure [dbo].[sol_Shipment_SelectByRBillNumber]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Shipment_SelectByRBillNumber]
(
	@RBillNumber nvarchar(50)
)

AS

SET NOCOUNT ON

SELECT [ShipmentID],
	[UserID],
	[UserName],
	[RBillNumber],
	[Date],
	[AgencyID],
	[AgencyName],
	[AgencyAddress1],
	[AgencyAddress2],
	[AgencyCity],
	[AgencyProvince],
	[AgencyCountry],
	[AgencyPostalCode],
	[Status],
	[CarrierID],
	[PlantID],
	[TrailerNumber],
	[ProBillNumber],
	[ShippedDate],
	[SealNumber],
	[LoadReference],
	[eRBillTransmitted]
FROM [sol_Shipment]
WHERE [RBillNumber] = @RBillNumber
GO

/****** Object:  StoredProcedure [dbo].[sol_Shipment_SelectAllByStatus]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Shipment_SelectAllByStatus]
(
	@Status char(1),
	@NewestOnTop bit
)

AS
BEGIN
	SET NOCOUNT ON
		
	IF (@NewestOnTop = 0)
	BEGIN
		SELECT [ShipmentID], 
			[UserID], 
			[UserName], 
			[RBillNumber], 
			[Date], 
			[AgencyID], 
			[AgencyName], 
			[AgencyAddress1], 
			[AgencyAddress2], 
			[AgencyCity], 
			[AgencyProvince], 
			[AgencyCountry], 
			[AgencyPostalCode], 
			[Status], 
			[CarrierID], 
			[PlantID], 
			[TrailerNumber], 
			[ProBillNumber], 
			[ShippedDate], 
			[SealNumber], 
			[LoadReference], 
			[eRBillTransmitted] 
		FROM [sol_Shipment] 
		WHERE [Status] = @Status
	END
	ELSE
	BEGIN
		SELECT [ShipmentID], 
			[UserID], 
			[UserName], 
			[RBillNumber], 
			[Date], 
			[AgencyID], 
			[AgencyName], 
			[AgencyAddress1], 
			[AgencyAddress2], 
			[AgencyCity], 
			[AgencyProvince], 
			[AgencyCountry], 
			[AgencyPostalCode], 
			[Status], 
			[CarrierID], 
			[PlantID], 
			[TrailerNumber], 
			[ProBillNumber], 
			[ShippedDate], 
			[SealNumber], 
			[LoadReference], 
			[eRBillTransmitted] 
		FROM [sol_Shipment] 
		WHERE [Status] = @Status
		ORDER BY [Date] DESC
	END

END
GO

/****** Object:  StoredProcedure [dbo].[sol_Shipment_SelectAllBetweenDatesByStatus]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Shipment_SelectAllBetweenDatesByStatus]
(
    @DateFrom varchar(23),
    @DateTo varchar(23),
	@Status char(1),
	@NewestOnTop bit
)
AS
BEGIN

	SET NOCOUNT ON
    DECLARE @sql NVARCHAR(3000)

    IF(@DateFrom = '') SET @DateFrom = NULL 
    IF(@DateFrom IS NULL ) SET @DateFrom = '1950-01-01 00:00:00'
    IF(@DateTo = '') SET @DateTo = NULL 
    IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'
    
    SET @sql = 
		'SELECT * FROM [sol_Shipment] '+
		--'WHERE [Date] BETWEEN @DateFrom AND @DateTo ';
        --' ISNULL( CONVERT(varchar(23), sol_Shipment.Date, 120), '''+@DateFrom+''' ) Between '''+@DateFrom+''' AND '''+@DateTo+''' ';
		' WHERE [Date] between '''+@DateFrom+''' and '''+@DateTo+''' ';
		
	if(@Status = '') set @Status = NULL
	IF(@Status IS NOT NULL)
		SET @sql = @sql + 'AND [Status] = '''+@Status+''' ';

	IF @NewestOnTop = 1
		SET @sql = @sql + 'Order By [Date] desc';

	EXEC(@sql)
	
END
GO

/******************************************************************************
--comment out the original procedure
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Shipment_SelectAll]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Shipment_SelectAll]
(
	@NewestOnTop bit
)
AS
BEGIN
	SET NOCOUNT ON
    DECLARE @sql NVARCHAR(3000)

    SET @sql = 
		'SELECT [ShipmentID], '+
		'	[UserID], '+
		'	[UserName], '+
		'	[RBillNumber], '+
		'	[Date], '+
		'	[AgencyID], '+
		'	[AgencyName], '+
		'	[AgencyAddress1], '+
		'	[AgencyAddress2], '+
		'	[AgencyCity], '+
		'	[AgencyProvince], '+
		'	[AgencyCountry], '+
		'	[AgencyPostalCode], '+
		'	[Status], '+
		'	[CarrierID], '+
		'	[PlantID], '+
		'	[TrailerNumber], '+
		'	[ProBillNumber], '+
		'	[ShippedDate], '+
		'	[SealNumber], '+
		'	[LoadReference], '+
		'	[eRBillTransmitted] '+
		'FROM [sol_Shipment] ';

	IF (@NewestOnTop = 1)
		SET @sql = @sql + 'Order By [Date] desc';

	EXEC(@sql)
END
GO

/******************************************************************************
--Sol_Products
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_Products_SelectAllUnstaged]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectAllUnstaged]	
(
   @DateFrom varchar(23) = NULL, /*'1950-01-01 00:00:00', No longer used.  For backwards compatibility*/
   @DateTo varchar(23) = NULL,
   @CurrentUserName nvarchar(256) = NULL  /*No longer used.  For backwards compatibility*/
)
AS
/**  With this version starting 9/24/2014 V2.1.22:
        dbo.sol_QueryDate  is no longer used
		dbo.vw_sol_Products_Unstaged_Part1 is no longer used
		dbo.vw_sol_Products_Unstaged_Part2 is no longer used
**/

BEGIN
   SET NOCOUNT ON
   IF(@DateTo IS NULL) SET @DateTo = CONVERT(varchar, GETDATE(), 23) + ' 23:59:59'

CREATE TABLE #Unstaged ( CategoryID int, TotalQuantity int );
INSERT INTO #Unstaged 
   SELECT      dbo.Sol_Categories.CategoryID, SUM(dbo.sol_OrdersDetail.Quantity) AS TotalQuantity
   FROM          dbo.sol_OrdersDetail RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID
   WHERE      (NOT (dbo.sol_OrdersDetail.Status = 'D')) AND (dbo.sol_OrdersDetail.Date <= CONVERT(datetime,@DateTo,120))
   GROUP BY dbo.Sol_Categories.CategoryID

CREATE TABLE #Staged ( CategoryID int, TotalDozen decimal(18,4), TotalQuantity int );
INSERT INTO #Staged 
   SELECT      dbo.sol_Products.CategoryID, Sum(CONVERT(decimal(18,4), sol_Stage.Quantity))/12 AS TotalDozen, SUM(dbo.sol_Stage.Quantity) AS TotalQuantity
   FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID
   WHERE      (NOT (dbo.sol_Stage.Status = 'D')) AND (dbo.sol_Stage.Date <= CONVERT(datetime,@DateTo,120))
   GROUP BY dbo.sol_Products.CategoryID

SELECT      dbo.Sol_Categories.CategoryID AS Id, dbo.Sol_Categories.Description, dbo.Sol_Categories.RefundAmount, 
                        ISNULL(#Unstaged.TotalQuantity, 0) - ISNULL(#Staged.TotalQuantity, 0) AS Quantity,
						(ISNULL(CONVERT(decimal(18,4), #Unstaged.TotalQuantity)/12, 0) - ISNULL(#Staged.TotalDozen, 0))  AS Dozen
FROM          dbo.Sol_Categories LEFT OUTER JOIN
                        #Staged ON dbo.Sol_Categories.CategoryID = #Staged.CategoryID LEFT OUTER JOIN
                        #Unstaged ON dbo.Sol_Categories.CategoryID = #Unstaged.CategoryID
WHERE      (dbo.Sol_Categories.CategoryID > 0)

END

GO

/****** Object:  StoredProcedure [dbo].[sol_Products_SelectAllStaged]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectAllStaged]
(
      @DateFrom varchar(23) = Null,  /** Date From is not used as of Sept 28, 2014 Version 2.1.23**/
      @DateTo varchar(23)
)

AS
BEGIN
      SET NOCOUNT ON
		IF(@DateTo IS NULL) SET @DateTo = CONVERT(varchar, GETDATE(), 23) + ' 23:59:59'

SELECT      sol_Products.ProductID as Id, 
				dbo.sol_Products.ProDescription As Description, 
				dbo.sol_Products.Price as RefundAmount,				
				Sum(CONVERT(decimal(18,4), sol_Stage.Quantity))/12 AS Dozen,
				SUM(dbo.sol_Stage.Quantity) AS Quantity
FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID
WHERE      ((dbo.sol_Stage.Status = 'P' OR dbo.sol_Stage.Status = 'I') AND (dbo.sol_Stage.Date <= @DateTo)) 
   OR      ((dbo.sol_Stage.Status = 'S') AND (dbo.sol_Stage.Date <= @DateTo) AND (dbo.sol_Shipment.ShippedDate > @DateTo))
GROUP BY dbo.sol_Products.ProductID, dbo.sol_Products.ProDescription, dbo.sol_Products.Price

END

GO

/****** Object:  StoredProcedure [dbo].[sol_Products_SelectTypeId]    Script Date: 12/21/2011 08:02:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectTypeId]
(
	@TypeId tinyint
)

AS

SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)
	
	SET @sql = 
	'SELECT * '+
	'FROM [sol_Products] ';
	IF(@TypeId IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
		'WHERE [TypeId] = '+CAST(@TypeId  AS VARCHAR)+ ' ';
	END
	EXEC(@sql)

GO

/****** Object:  StoredProcedure [dbo].[sol_Products_SelectAllLookup]    Script Date: 12/22/2011 09:47:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sol_Products_SelectAllLookup]
(
	@TypeId tinyint -- 0 or null = returns 1 = sales
)

AS

SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)
	
	SET @sql = 
	'SELECT [ProductID], '+
	'	[ProName] '+
	'FROM [sol_Products] '+
	'WHERE (IsActive = 1) ';
	
	IF(@TypeId IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
		'AND [TypeId] = '+CAST(@TypeId  AS VARCHAR)+ ' ';

	END

	SET @sql = @sql + 
	'ORDER BY ProName ';
	
	EXEC(@sql)
GO

/****** Object:  StoredProcedure [dbo].[sol_Products_LookupByKey]    Script Date: 12/22/2011 15:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_Products_LookupByKey]
	@TypeId tinyint,
	@KeyName [varchar](50),
	@KeyValue [varchar](128)
	

AS

SET NOCOUNT ON
	DECLARE @sql NVARCHAR(3000)

	SET @sql = 
	'SELECT [ProductID], '+
	'	[ProName] '+
	'FROM [sol_Products] '+
	'WHERE (IsActive = 1) ';

	IF(@TypeId IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
		'AND [TypeId] = '+CAST(@TypeId  AS VARCHAR)+ ' ';
	END

	IF(@KeyValue = '') set @KeyValue = NULL
	IF(@KeyValue IS NOT NULL)
	BEGIN
		SET @sql = @sql + 
		'AND ['+@KeyName+'] LIKE '''+@KeyValue+'%'' ';
	END

	SET @sql = @sql + 
	'ORDER BY ProName ';
	
EXEC(@sql)
GO

/****** Object:  StoredProcedure [dbo].[sol_Products_SelectProductCode]    Script Date: 01/20/2012 15:04:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[sol_Products_SelectProductCode]
(
	@ProductCode varchar(50)
)

AS

SET NOCOUNT ON
	
	SELECT *
	FROM [sol_Products] 
	WHERE [ProductCode] = ''+@ProductCode+'' 
GO


/******************************************************************************
--Sol_Entries
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[Sol_Entries_GetLastClosingValue]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Entries_GetLastClosingValue] 
      (
            @CashTrayID int  
      )
      
AS
BEGIN
   SET NOCOUNT ON

SELECT   Amount
    FROM  dbo.sol_Entries
    WHERE (EntryType = 'C') AND (CashTrayID = @CashTrayID) AND (Date =
          (SELECT MAX(Date) FROM dbo.sol_Entries
              WHERE (EntryType = 'C') AND (CashTrayID = @CashTrayID))) 
END
GO
/****** Object:  StoredProcedure [dbo].[Sol_Entries_GetValueOfFloat]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Entries_GetValueOfFloat] 
      (
            @CashTrayID int,  --not required when providing Closing EntryID
            @ClosingEntryID int = NULL  
                  --optional if you want to know the calculated value of a previous close
      )
AS
BEGIN
      DECLARE @DateFrom datetime
      DECLARE @DateTo datetime
      DECLARE @CurrentFloat money
      
      IF (@CashTrayID < 0) SET @CashTrayID = NULL
      IF (@ClosingEntryID < 0) SET @ClosingEntryID = NULL
      
      IF (@CashTrayID IS NULL) SET @CashTrayID = 0
      IF (@ClosingEntryID IS NULL) 
        BEGIN
            -- Get last opening
            SELECT @DateFrom = MAX(Date) FROM dbo.sol_Entries
                  WHERE (CashTrayID = @CashTrayID) AND (EntryType = 'O')
            
            SET @DateTo = CONVERT(varchar, GETDATE(), 23) + ' 23:59:59'
        END
      
      IF (@ClosingEntryID IS NOT NULL)
        BEGIN
            -- Get Closing date
            SELECT @DateTo = dbo.sol_Entries.Date FROM dbo.sol_Entries WHERE EntryID = @ClosingEntryID
            -- Get CashTrayID
            SELECT @CashTrayID = dbo.sol_Entries.CashTrayID FROM dbo.sol_Entries WHERE EntryID = @ClosingEntryID
            -- Get Opening date
            SELECT @DateFrom = MAX(Date) FROM dbo.sol_Entries
                  WHERE (CashTrayID = @CashTrayID) AND (EntryType = 'O') AND (Date < @DateTo)      
                    
        END
        --Note: If the Sol_Reports_DailyTotal_Breakdown procedure changes, the following temp table has to be changed to match
	CREATE TABLE #result(CashRefundQTY int, 
                  CashRefundReturns money,
                  CashRefundSales money,
                  PreviousOrdersPaidOut money,
                  PreviousSalesPaidOut money,
                  CashRefund money,  /*Not used anymore*/
                  TotalCashRefund money,
                  TotalReturnOrders money,
                  TotalSalesOrders money,
                  OnAccountReturns money,
                  OnAccountSales money,
                  ClosedReturnOrders money,
                  ClosedReturnOrdersQTY int,
                  ClosedSalesOrders money,
                  ClosedSalesOrdersQTY int,  
                  --OnAccountQTY int,  /*Not used anymore*/
                  --OnAccount money,  /*Not used anymore*/
                  --TotalRefundQTY int,  /*Not used anymore*/
                  --TotalRefund money,  /*Not used anymore*/
                  OutstandingOrders money,
                  OutstandingOrdersQTY int,
                  PreviousCashFee money,
                  CashFee money,
                  OnAccountFee money,
                  OutstandingFee money,
                  TotalFee money,
                  TotalCashFee money,
                  ClosedReturnFees money,
                  ClosedSalesFees money,
                  TotalExpense money,
                  CashFloat money,
                  CashBalance money,
                  CashCounted money,
                  Discrepency money,
                  VoidTransactionsQTY int,
                  VoidTransactions money,
                  VoidTransactionFees money,
                  AccountPaidCash money,
                  AccountPaidCheque money,
                  TotalAccountPayments money)
                  
	INSERT INTO #result 
		Exec Sol_Reports_DailyTotal_Breakdown @DateFrom, @DateTo, @CashTrayID
	SELECT @CurrentFloat = CashBalance FROM #result
	Drop Table #result
	
	SELECT @CurrentFloat AS CurrentFloat
END

GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_SelectAllByTypeDateTray]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_SelectAllByTypeDateTray]
(
	@EntryType char(1),
	@Date datetime,
	@CashTrayID int
)

AS

SET NOCOUNT ON

SELECT [EntryID],
	[EntryType],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[ExpenseTypeID],
	[Amount],
	[DiscrepancyAmount]
FROM [sol_Entries]
WHERE [EntryType] = @EntryType
	AND [Date] = @Date
	AND [CashTrayID] = @CashTrayID
GO
/****** Object:  StoredProcedure [dbo].[sol_Entries_SelectLastType]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_Entries_SelectLastType]
(
	@EntryType char(1),
	@CashTrayID int
)

AS

SET NOCOUNT ON
/*
SELECT MAX([Date])  AS LatestDate
FROM [sol_Entries]
WHERE [EntryType] = @EntryType
	AND [CashTrayID] = @CashTrayID
*/

SELECT [EntryID],
	[EntryType],
	[UserID],
	[UserName],
	[Date],
	[CashTrayID],
	[ExpenseTypeID],
	[Amount],
	[DiscrepancyAmount]
FROM [sol_Entries]
WHERE [EntryType] = @EntryType
	AND [CashTrayID] = @CashTrayID
	AND [Date] =(select max([Date]) from [sol_Entries]
WHERE [EntryType] = @EntryType
	AND [CashTrayID] = @CashTrayID )
GO
/******************************************************************************
--Sol_EntriesDetails
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_EntriesDetail_SelectAllByEntryIDType]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sol_EntriesDetail_SelectAllByEntryIDType]
(
	@EntryID int,
	@EntryType char(1)

)
AS

SET NOCOUNT ON

SELECT [DetailID],
	[EntryID],
	[EntryType],
	[CashID],
	[Count]
FROM [sol_EntriesDetail]
WHERE [EntryID] = @EntryID
	AND [EntryType] = @EntryType
GO

/******************************************************************************
--Sol_CashDenominations
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[sol_CashDenominations_SelectAllDescription]    Script Date: 12/02/2011 10:04:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sol_CashDenominations_SelectAllDescription]
AS

SET NOCOUNT ON

SELECT [CashID],
	[CashType],
	[CashValue],
	/*IF( [CashType] = 0, "Coin", "Bill") as typeDescription, */
	(CASE [CashType]     WHEN 0 THEN 'Coin'  WHEN 1 THEN 'Bill' WHEN 2 THEN 'Roll'  END) as typeDescription,
	(CASE [CashType]     WHEN 0 THEN 'Coin'  WHEN 1 THEN 'Bill' WHEN 2 THEN 'Roll'  END) + ' - ' + CONVERT(varchar, [CashValue], 23) as strDescription,
	[Description],
	[OrderValue],
	[CashItemValue],
	[Quantity],
	[MoneyID]
FROM [sol_CashDenominations]
GO


/******************************************************************************
--Sol_Stored Procedures for Reports
--Sol_Reports
******************************************************************************/

/****** Object:  StoredProcedure [dbo].[Sol_Reports_EncorpBol]    Script Date: 15/08/2017 10:53:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Reports_EncorpBol]
(
   @ShipmentID int
)
AS

BEGIN
   SET NOCOUNT ON

   --DECLARE @Column1ID int    /*bags*/

   DECLARE @RBillNumber nvarchar(256)

   DECLARE @Bags int

 --/*** GET DEPOT INFO  ***/
 --SELECT --@DepotName = BusinessName, @DepotAddress = Address, @DepotCity = City, @DepotProvince = State, @VendorID = VendorID,
	--	@Column1ID = BagID, @Column2ID = BlueBagID, @Column3ID = OneWayBagID, @Column4ID = ABCRCPalletsID 
 --FROM dbo.Sol_Control
 --WHERE ControlID = 1
 
 /*** GET SHIPMENT INFO  ***/
 SELECT @RBILLNumber = RBillNumber--, @Date = Date, @ShipDate = ShippedDate, @CarrierID = CarrierID, @TrailerNumber = TrailerNumber, @ProBillNumber = ProBillNumber
 FROM dbo.sol_Shipment
 WHERE ShipmentID = @ShipmentID


 /*** CREATE TEMP TABLE  ***/
 CREATE TABLE #LocalTempTable(
 ProductID int,
 ProductCode varchar(50),
 ProName varchar(50),
 Bags int,
 Quantity int,
 MasterProductDescription varchar(50))
 
 INSERT INTO #LocalTempTable (ProductID, Quantity, MasterProductDescription) /* GET PRODUCTS FROM SHIPMENT */
  --SELECT sol_Stage.productid, Sum(sol_Stage.Quantity)
  --FROM dbo.sol_Stage 
  --WHERE sol_Stage.ShipmentID = @ShipmentID
  --GROUP BY sol_Stage.ProductID


	SELECT 
	p.ProductID	--, p.ProductCode, ISNULL(p.[Weight], 0) as [Weight]
	, SUM(od.Quantity)
	, mp.ProDescription as MasterProductDescription
	FROM sol_Stage as s
	INNER JOIN  dbo.sol_OrdersDetail as od ON od.StageID = s.StageID
	AND (od.Status <> 'D') 
	INNER JOIN dbo.sol_Products as p ON p.ProductID = od.ProductID
	INNER JOIN dbo.sol_Products as mp ON mp.ProductID = p.MasterProductID
	WHERE s.[ShipmentID] = @ShipmentID
	GROUP BY p.ProductID, mp.ProDescription

 --INSERT INTO #LocalTempTable (ProductID) Values (-1) /* Add Pallets */
 --INSERT INTO #LocalTempTable (ProductID) Values (0)  /* Add Empty bags */
 
 UPDATE #LocalTempTable   /* GET Bag counts */
   SET Bags = (SELECT Quantity FROM dbo.Sol_SupplyInventory WHERE ShipmentID = @ShipmentID AND ProductID = #LocalTempTable.ProductID)

UPDATE #LocalTempTable   /* Get Product Name */
   SET 
   ProName = (SELECT dbo.sol_Products.ProName FROM dbo.sol_Products WHERE dbo.sol_Products.ProductID = #LocalTempTable.ProductID),
   ProductCode = (SELECT dbo.sol_Products.ProductCode FROM dbo.sol_Products WHERE dbo.sol_Products.ProductID = #LocalTempTable.ProductID)

/*** COMPILE DATA TO OUTPUT   ***/     
SELECT  @RBILLNumber as rBillNumber, --@DepotName as DepotName, @DepotAddress as DepotAddress, @DepotCity as DepotCity, @DepotProvince as DepotProvince, @VendorID as VendorID, @ShipDate as Date,
ProductID, ProName, ProductCode as ProCode, 

 ISNULL(Quantity, 0) as Quantity, 
 ISNULL(Bags, 0) as Bags
 , MasterProductDescription

FROM #LocalTempTable
WHERE ProductID > 0

END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_EncorpBOL_Containers]    Script Date: 15/08/2017 10:53:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Reports_EncorpBOL_Containers]
(
	@ShipmentID int,
	@ProductCode varchar(50),
	@ContainerID int
)
AS 

	SELECT COUNT(s.ShipmentID) AS ContainerCount
	FROM sol_Stage as s
	INNER JOIN  dbo.sol_OrdersDetail as od ON od.StageID = s.StageID
	AND (od.Status <> 'D') 
	INNER JOIN dbo.sol_Products as p ON p.ProductID = od.ProductID
	AND (p.ProductCode = @ProductCode )
	--INNER JOIN dbo.sol_Products as mp ON mp.ProductID = p.MasterProductID
	WHERE s.ContainerID = @ContainerID AND s.[ShipmentID] = @ShipmentID
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
/**NOTE: This SP uses ShippedDate and includes Adjustments  **/
CREATE PROCEDURE [dbo].[Sol_Reports_CRIS_Summary]
(
	@RBILLNumber nvarchar(10),
    @DateFrom varchar(23),
	@DateTo varchar(23)
)

AS 
BEGIN
    SET NOCOUNT ON    

	IF(@RBILLNumber = '') SET @RBILLNumber = NULL 
	IF(@DateFrom = '') SET @DateFrom = NULL 
    IF(@DateFrom IS NULL ) SET @DateFrom = '1950-01-01 00:00:00'
    IF(@DateTo = '') SET @DateTo = NULL 
    IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'

	IF (@RBILLNumber IS NULL)
	BEGIN
		SELECT      dbo.sol_Products.ProductCode, dbo.sol_Stage.ProductName, COUNT(dbo.sol_Stage.StageID) AS NumberOfBags
		, SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity
		FROM          dbo.sol_Products INNER JOIN
                        dbo.sol_Shipment INNER JOIN
                        dbo.sol_Stage ON dbo.sol_Shipment.ShipmentID = dbo.sol_Stage.ShipmentID ON 
                        dbo.sol_Products.ProductID = dbo.sol_Stage.ProductID
		WHERE      (dbo.sol_Stage.Status <> 'D') AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo)
		GROUP BY dbo.sol_Stage.ProductName, dbo.sol_Products.ProductCode
		ORDER BY dbo.sol_Products.ProductCode
	END
	ELSE
	BEGIN
		SELECT      dbo.sol_Products.ProductCode, dbo.sol_Stage.ProductName, COUNT(dbo.sol_Stage.StageID) AS NumberOfBags
		, SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity
		FROM          dbo.sol_Products INNER JOIN
                        dbo.sol_Shipment INNER JOIN
                        dbo.sol_Stage ON dbo.sol_Shipment.ShipmentID = dbo.sol_Stage.ShipmentID ON 
                        dbo.sol_Products.ProductID = dbo.sol_Stage.ProductID
		WHERE		(dbo.sol_Stage.Status <> 'D') 
					--AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo) 
					AND ((dbo.sol_Shipment.RBillNumber = @RBILLNumber) 
					OR (dbo.sol_Shipment.RBillNumber = @RBILLNumber + 'A' )) --Include adjustments
		GROUP BY dbo.sol_Stage.ProductName, dbo.sol_Products.ProductCode
		ORDER BY dbo.sol_Products.ProductCode
	END

END
GO


/****** Object:  StoredProcedure [dbo].[Sol_Reports_Shipment_Value]    Script Date: 1/11/2015 5:04:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
/**NOTE: This SP uses ShippedDate and includes Adjustments  **/
CREATE PROCEDURE [dbo].[Sol_Reports_Shipment_Value]
(
	@RBILLNumber nvarchar(10),
    @DateFrom varchar(23),
	@DateTo varchar(23)
)

AS 
BEGIN
    SET NOCOUNT ON    

	IF(@RBILLNumber = '') SET @RBILLNumber = NULL 
	IF(@DateFrom = '') SET @DateFrom = NULL 
    IF(@DateFrom IS NULL ) SET @DateFrom = '1950-01-01 00:00:00'
    IF(@DateTo = '') SET @DateTo = NULL 
    IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'
	DECLARE @GST Varchar(10) 
	SELECT @GST= Convert(Varchar(10),Tax1Rate) FROM Sol_Control WHERE ControlID = 1   --GET GST

	IF (@RBILLNumber IS NULL)
	BEGIN
		SELECT      dbo.sol_Shipment.RBillNumber, dbo.sol_Products.ProductCode, dbo.sol_Stage.ProductName, COUNT(dbo.sol_Stage.StageID) 
                    AS NumberOfBags, dbo.sol_Containers.Description AS ShippingContainer, 
					SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, 
					SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity, 
                    dbo.Sol_Categories.RefundAmount * SUM(dbo.sol_Stage.Quantity) AS Refund, 
                    dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) AS HandlingCommision, 
                    dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity) AS VAF, 
					CONVERT(money, 
                    (dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) + dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity) 
                    ) / 100 *  @GST  ) AS GST, CONVERT(money, dbo.Sol_Categories.RefundAmount * SUM(dbo.sol_Stage.Quantity) 
                    + dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) 
                    + dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity) 
                    + (dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) 
                    + dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity)) / 100 * @GST ) AS LineTotal,
					ISNULL(dbo.sol_Shipment.ShippedDate, '1753-01-01 12:00:00') as ShippedDate
		FROM        dbo.sol_Containers 
					RIGHT OUTER JOIN dbo.sol_Products 
					INNER JOIN dbo.sol_Shipment 
					INNER JOIN dbo.sol_Stage ON dbo.sol_Shipment.ShipmentID = dbo.sol_Stage.ShipmentID 
					ON dbo.sol_Products.ProductID = dbo.sol_Stage.ProductID 
					ON dbo.sol_Containers.ContainerID = dbo.sol_Products.ContainerID 
					LEFT OUTER JOIN dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE		(dbo.sol_Stage.Status <> 'D') 
				AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo) 

		GROUP BY dbo.sol_Shipment.RBillNumber, dbo.sol_Stage.ProductName, dbo.sol_Products.ProductCode, dbo.Sol_Categories.RefundAmount, 
        dbo.sol_Products.HandlingCommissionAmount, dbo.sol_Products.VafAmount, dbo.sol_Containers.Description
		, dbo.sol_Shipment.ShippedDate
		ORDER By dbo.sol_Shipment.RBillNumber, dbo.sol_Products.ProductCode
	END
	ELSE
	BEGIN
		SELECT      dbo.sol_Shipment.RBillNumber, dbo.sol_Products.ProductCode, dbo.sol_Stage.ProductName, COUNT(dbo.sol_Stage.StageID) 
                    AS NumberOfBags, dbo.sol_Containers.Description AS ShippingContainer, 
					SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, 
					SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity, 
                    dbo.Sol_Categories.RefundAmount * SUM(dbo.sol_Stage.Quantity) AS Refund, 
                    dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) AS HandlingCommision, 
                    dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity) AS VAF, 
					CONVERT(money, 
                    (dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) + dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity) 
                    ) / 100 *  @GST  ) AS GST, CONVERT(money, dbo.Sol_Categories.RefundAmount * SUM(dbo.sol_Stage.Quantity) 
                    + dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) 
                    + dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity) 
                    + (dbo.sol_Products.HandlingCommissionAmount * SUM(dbo.sol_Stage.Quantity) 
                    + dbo.sol_Products.VafAmount * SUM(dbo.sol_Stage.Quantity)) / 100 * @GST ) AS LineTotal,
					ISNULL(dbo.sol_Shipment.ShippedDate, '1753-01-01 12:00:00') as ShippedDate
		FROM        dbo.sol_Containers 
					RIGHT OUTER JOIN dbo.sol_Products 
					INNER JOIN dbo.sol_Shipment 
					INNER JOIN dbo.sol_Stage ON dbo.sol_Shipment.ShipmentID = dbo.sol_Stage.ShipmentID 
					ON dbo.sol_Products.ProductID = dbo.sol_Stage.ProductID 
					ON dbo.sol_Containers.ContainerID = dbo.sol_Products.ContainerID 
					LEFT OUTER JOIN dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE		(dbo.sol_Stage.Status <> 'D') 
					--AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo) 
					AND ((dbo.sol_Shipment.RBillNumber = @RBILLNumber) 
					OR (dbo.sol_Shipment.RBillNumber = @RBILLNumber + 'A' )) --Include adjustments

		GROUP BY dbo.sol_Shipment.RBillNumber, dbo.sol_Stage.ProductName, dbo.sol_Products.ProductCode, dbo.Sol_Categories.RefundAmount, 
        dbo.sol_Products.HandlingCommissionAmount, dbo.sol_Products.VafAmount, dbo.sol_Containers.Description
		, dbo.sol_Shipment.ShippedDate
		ORDER By dbo.sol_Shipment.RBillNumber, dbo.sol_Products.ProductCode
	END

END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_RBILL]    Script Date: 7/7/2014 5:04:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[Sol_Reports_RBILL]
(
   @ShipmentID int
)
AS

BEGIN
   SET NOCOUNT ON

   --DECLARE @DepotName nvarchar(256)
   --DECLARE @DepotAddress nvarchar(256)
   --DECLARE @DepotCity nvarchar(56)
   --DECLARE @DepotProvince nvarchar(56)

   --DECLARE @VendorID int
   --DECLARE @Carrier nvarchar(256)
   --DECLARE @CarrierID int
   --DECLARE @TrailerNumber nvarchar(50)
   --DECLARE @ProBillNumber nvarchar(50)

   DECLARE @Column1ID int    /*Black bags*/
   DECLARE @Column2ID int    /*Blue bags*/
   DECLARE @Column3ID int    /*One Way Bags*/
   DECLARE @Column4ID int    /*Pallets*/

   DECLARE @RBILLNumber nvarchar(256)
   --DECLARE @Date datetime
   --DECLARE @ShipDate datetime

   DECLARE @ExtraContainerWhiteBags int
   DECLARE @ExtraContainerBluBags int
   DECLARE @ExtraContainerOneWayBags int
   DECLARE @ExtraContainerABCRCPallets int
   DECLARE @EmptyContainerWhiteBags int
   DECLARE @EmptyContainerBluBags int
   DECLARE @EmptyContainerOneWayBags int
   DECLARE @EmptyContainerABCRCPallets int

 --/*** GET DEPOT INFO  ***/
 SELECT --@DepotName = BusinessName, @DepotAddress = Address, @DepotCity = City, @DepotProvince = State, @VendorID = VendorID,
		@Column1ID = WhiteBagID, @Column2ID = BlueBagID, @Column3ID = OneWayBagID, @Column4ID = ABCRCPalletsID 
 FROM dbo.Sol_Control
 WHERE ControlID = 1
 
 /*** GET SHIPMENT INFO  ***/
 SELECT @RBILLNumber = RBillNumber--, @Date = Date, @ShipDate = ShippedDate, @CarrierID = CarrierID, @TrailerNumber = TrailerNumber, @ProBillNumber = ProBillNumber
 FROM dbo.sol_Shipment
 WHERE ShipmentID = @ShipmentID

 --SELECT @Carrier = Carrier FROM dbo.Sol_WS_Carriers WHERE CarrierID = @CarrierID

 /*** USE Date feild if ShippedDate is not set **/
 --IF @ShipDate < @Date 
 --  BEGIN
	-- SET @ShipDate = @Date
 --  END

 /*** CREATE TEMP TABLE  ***/
 CREATE TABLE #LocalTempTable(
 ProductID int,
 ProName varchar(50),
 ProductCode varchar(50),
 Dozen decimal(18,4),
 Quantity int,
 Column1 int,
 Column2 int,
 Column3 int,
 Column4 int)

 INSERT INTO #LocalTempTable (ProductID, Dozen, Quantity) /* GET PRODUCTS FROM SHIPMENT */
  SELECT sol_Stage.productid, Sum(CONVERT(decimal(18,4), sol_Stage.Quantity))/12, Sum(sol_Stage.Quantity)
  FROM dbo.sol_Stage 
  WHERE sol_Stage.ShipmentID = @ShipmentID
  GROUP BY sol_Stage.ProductID
 
 INSERT INTO #LocalTempTable (ProductID) Values (-1) /* Add Pallets */
 INSERT INTO #LocalTempTable (ProductID) Values (0)  /* Add Empty bags */
 
 UPDATE #LocalTempTable   /* GET Bag counts */
   SET Column1 = (SELECT Quantity FROM dbo.Sol_SupplyInventory WHERE (ContainerID = @Column1ID OR ContainerID = 100) AND ShipmentID = @ShipmentID AND ProductID = #LocalTempTable.ProductID),
   Column2 = (SELECT Quantity FROM dbo.Sol_SupplyInventory WHERE (ContainerID = @Column2ID OR ContainerID = 200) AND ShipmentID = @ShipmentID AND ProductID = #LocalTempTable.ProductID),
   Column4 = (SELECT Quantity FROM dbo.Sol_SupplyInventory WHERE (ContainerID = @Column4ID OR ContainerID = 400) AND ShipmentID = @ShipmentID AND ProductID = #LocalTempTable.ProductID),
   Column3 = (SELECT Quantity FROM dbo.Sol_SupplyInventory WHERE ContainerID <> @Column1ID AND ContainerID <> @Column2ID AND ContainerID <> @Column4ID AND ContainerID <> 100 AND ContainerID <> 200 AND ContainerID <> 400 AND ShipmentID = @ShipmentID AND ProductID = #LocalTempTable.ProductID)

UPDATE #LocalTempTable   /* Get Product Name */
   SET ProName = (SELECT dbo.sol_Products.ProName FROM dbo.sol_Products WHERE dbo.sol_Products.ProductID = #LocalTempTable.ProductID),
   ProductCode = (SELECT dbo.sol_Products.ProductCode FROM dbo.sol_Products WHERE dbo.sol_Products.ProductID = #LocalTempTable.ProductID)

 /*** GET EXTRA AND EMPTY BAGS ***/
SELECT @ExtraContainerWhiteBags = Column1,
 @ExtraContainerBluBags  = Column2,
 @ExtraContainerOneWayBags = Column3,
 @ExtraContainerABCRCPallets  = Column4
 FROM #LocalTempTable WHERE ProductID = -1
SELECT @EmptyContainerWhiteBags = Column1,
 @EmptyContainerBluBags  = Column2,
 @EmptyContainerOneWayBags = Column3,
 @EmptyContainerABCRCPallets  = Column4
 FROM #LocalTempTable WHERE ProductID = 0

 /*** COMPILE DATA TO OUTPUT   ***/     
SELECT  @RBILLNumber as rBillNumber, --@DepotName as DepotName, @DepotAddress as DepotAddress, @DepotCity as DepotCity, @DepotProvince as DepotProvince, @VendorID as VendorID, @ShipDate as Date,
ProName, ProductCode as ProCode, 

 ISNULL(Dozen, 0) as Dozens, 
 ISNULL(Quantity, 0) as Units, 
 ISNULL(Column1, 0) as WhiteBags, 
 ISNULL(Column2, 0) as BluBags, 
 ISNULL(Column3, 0) as OneWayBags, 
 ISNULL(Column4, 0) as ABCRCPallets, 

 --ISNULL(Column1, 0) as WhiteBags, 
 --ISNULL(Column2, 0) as BluBags, 
 --ISNULL(Column3, 0) as OneWayBags, 
 --ISNULL(Column4, 0) as ABCRCPallets, 

 ISNULL(@ExtraContainerWhiteBags, 0) as ExtraContainerWhiteBags,
 ISNULL(@ExtraContainerBluBags, 0) as ExtraContainerBluBags,
 ISNULL(@ExtraContainerOneWayBags, 0) as ExtraContainerOneWayBags,
 ISNULL(@ExtraContainerABCRCPallets, 0) as ExtraContainerABCRCPallets,
 ISNULL(@EmptyContainerWhiteBags, 0) as EmptyContainerWhiteBags,
 ISNULL(@EmptyContainerBluBags, 0) as EmptyContainerBluBags,
 ISNULL(@EmptyContainerOneWayBags, 0) as EmptyContainerOneWayBags,
 ISNULL(@EmptyContainerABCRCPallets, 0) as EmptyContainerABCRCPallets
 --,
 --@Carrier as Carrier,
 --@TrailerNumber as TrailerNumber,
 --@ProBillNumber as ProBillNumber

FROM #LocalTempTable
WHERE ProductID > 0

END
GO


/****** Object:  StoredProcedure [dbo].[Sol_Reports_InventoryStatus]    Script Date: 08/30/2012 17:39:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[Sol_Reports_InventoryStatus]
(
   @DateFrom varchar(23) = NULL,
   @DateTo varchar(23) = NULL,
   @CurrentUserName nvarchar(256) = NULL
)
AS

BEGIN
	DECLARE @TotalQuantity Float
	IF(@DateFrom IS NULL) SET @DateFrom = '1950-01-01 00:00:00'
    IF(@DateTo IS NULL) SET @DateTo = CONVERT(varchar, GETDATE(), 23) + ' 23:59:59'
	
-- Opening Inventory
    CREATE TABLE #Opening
    (
        IndexID int IDENTITY (0, 1) NOT NULL,
        CategoryId int,
        Description varchar(100),
        RefundAmount money,
        Quantity int,
        PercentOfTotal float,
        Dozen decimal(18,4)
    )
    INSERT INTO #Opening(CategoryId,Description,RefundAmount,Quantity,PercentOfTotal,Dozen)
        Exec dbo.Sol_Reports_InventoryOnHand_Unstaged @DateFrom, @CurrentUserName 

  
-- Purchased Inventory
    CREATE TABLE #Purchased
    (
        IndexID int IDENTITY (0, 1) NOT NULL,
        CategoryId int,
        Description varchar(100),
        Quantity int,
        PercentOfTotal float,
        Dozen decimal(18,4),
        Amount money
    )
    INSERT INTO #Purchased(CategoryId,Description,Quantity,PercentOfTotal,Dozen,Amount)
		EXEC Sol_Reports_PurchasedInventory @DateFrom, @DateTo, -1


-- Staged Inventory
    CREATE TABLE #Staged
    (
        IndexID int IDENTITY (0, 1) NOT NULL,
        CategoryId int,
        Description varchar(100),
        Quantity int,
        PercentOfTotal float,
        Dozen decimal(18,4),
        Amount money
    )
    
    SELECT      @TotalQuantity = SUM(dbo.sol_Stage.Quantity)	--Dozen * 12)
		FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE      ((dbo.sol_Stage.Status = 'I') AND (dbo.sol_Stage.Date <= @DateTo)) 
            OR ((dbo.sol_Stage.Status = 'S') AND (dbo.sol_Shipment.ShippedDate > @DateTo) AND (dbo.sol_Stage.Date <= @DateTo))

    INSERT INTO #Staged(CategoryId,Description,Quantity,PercentOfTotal,Dozen,Amount)
		SELECT      dbo.Sol_Categories.CategoryID, 
                  dbo.Sol_Categories.Description, 
                  SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity, 
                  CASE @TotalQuantity
                        WHEN 0 THEN 0 --cant divide by zero
                        ELSE SUM(dbo.sol_Stage.Quantity) / @TotalQuantity * 100 
                        END
                  AS PercentOfTotal, 
                  SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, 
                  SUM(dbo.sol_Stage.Quantity) * dbo.Sol_Categories.RefundAmount AS Amount
		FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE      ((dbo.sol_Stage.Status = 'I') AND (dbo.sol_Stage.Date <= @DateTo)) 
            OR ((dbo.sol_Stage.Status = 'S') AND (dbo.sol_Shipment.ShippedDate > @DateTo) AND (dbo.sol_Stage.Date <= @DateTo))
		GROUP BY dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description, dbo.Sol_Categories.RefundAmount
	-- Note to Kevin:  sol_Shipment.Date should be changed to DateStarted and DateShipped



-- OnRBill Inventory
    CREATE TABLE #OnRBill
    (
        IndexID int IDENTITY (0, 1) NOT NULL,
        CategoryId int,
        Description varchar(100),
        Quantity int,
        PercentOfTotal float,
        Dozen decimal(18,4),
        Amount money
    )
    
    SELECT      @TotalQuantity = SUM(dbo.sol_Stage.Quantity)	--Dozen * 12)
		FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE      ((dbo.sol_Stage.Status = 'P') AND (dbo.sol_Stage.Date <= @DateTo)) 

    INSERT INTO #OnRBill(CategoryId,Description,Quantity,PercentOfTotal,Dozen,Amount)
		SELECT      dbo.Sol_Categories.CategoryID, 
                  dbo.Sol_Categories.Description, 
                  SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity, 
                  CASE @TotalQuantity
                        WHEN 0 THEN 0 --cant divide by zero
                        ELSE SUM(dbo.sol_Stage.Quantity) / @TotalQuantity * 100 
                        END
                  AS PercentOfTotal, 
                  SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, 
                  SUM(dbo.sol_Stage.Quantity) * dbo.Sol_Categories.RefundAmount AS Amount
		FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE      ((dbo.sol_Stage.Status = 'P') AND (dbo.sol_Stage.Date <= @DateTo)) 
		GROUP BY dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description, dbo.Sol_Categories.RefundAmount
	-- Note to Kevin:  sol_Shipment.Date should be changed to DateStarted and DateShipped



-- Shipped Inventory
    CREATE TABLE #Shipped
    (
        IndexID int IDENTITY (0, 1) NOT NULL,
        CategoryId int,
        Description varchar(100),
        Quantity int,
        PercentOfTotal float,
        Dozen decimal(18,4),
        Amount money
    )
    
    SELECT      @TotalQuantity = SUM(dbo.sol_Stage.Quantity)	--Dozen * 12)
		FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE      (dbo.sol_Stage.Status = 'S') AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo) 

    INSERT INTO #Shipped(CategoryId,Description,Quantity,PercentOfTotal,Dozen,Amount)
		SELECT      dbo.Sol_Categories.CategoryID, 
                  dbo.Sol_Categories.Description, 
                  SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity, 
                  CASE @TotalQuantity
                        WHEN 0 THEN 0 --cant divide by zero
                        ELSE SUM(dbo.sol_Stage.Quantity) / @TotalQuantity * 100 
                        END
                  AS PercentOfTotal, 
                  SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, 
                  SUM(dbo.sol_Stage.Quantity) * dbo.Sol_Categories.RefundAmount AS Amount
		FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
		WHERE      (dbo.sol_Stage.Status = 'S') AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo)
		GROUP BY dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description, dbo.Sol_Categories.RefundAmount
	-- Note to Kevin:  sol_Shipment.Date should be changed to DateStarted and DateShipped
	
	
	
-- Unstaged Inventory
    CREATE TABLE #Unstaged
    (
        IndexID int IDENTITY (0, 1) NOT NULL,
        CategoryId int,
        Description varchar(100),
        RefundAmount money,
        Quantity int,
        PercentOfTotal float,
        Dozen decimal(18,4)
    )
    -- Insert into our temp table
    INSERT INTO #Unstaged(CategoryId,Description,RefundAmount,Quantity,PercentOfTotal,Dozen)
        Exec dbo.Sol_Reports_InventoryOnHand_Unstaged @DateTo, @CurrentUserName
        

-- Combine Data        
	SELECT      dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description, #Opening.Quantity AS OpeningQuantity, 
                        #Opening.PercentOfTotal AS OpeningPercent, #Opening.RefundAmount * #Opening.Quantity AS OpeningAmount, 
                        #Purchased.Quantity AS PurchasedQuantity, #Purchased.PercentOfTotal AS PurchasedPercent, #Purchased.Amount AS PurchasedAmount, 
                        #Staged.Quantity AS StagedQuantity, #Staged.PercentOfTotal AS StagedPercent, #Staged.Amount AS StagedAmount, 
                        #OnRBill.Quantity AS OnRBillQuantity, #OnRBill.PercentOfTotal AS OnRBillPercent, #OnRBill.Amount AS OnRBillAmount, 
                        #Shipped.Quantity AS ShippedQuantity, #Shipped.PercentOfTotal AS ShippedPercent, #Shipped.Amount AS ShippedAmount, 
                        #Unstaged.Quantity AS UnStagedQuantity, #Unstaged.PercentOfTotal AS UnStagedPercent, 
                        #Unstaged.RefundAmount * #Unstaged.Quantity AS UnStagedAmount
	FROM          dbo.Sol_Categories LEFT OUTER JOIN
                        #Opening ON dbo.Sol_Categories.CategoryID = #Opening.CategoryId LEFT OUTER JOIN
                        #Purchased ON dbo.Sol_Categories.CategoryID = #Purchased.CategoryId LEFT OUTER JOIN
                        #Staged ON dbo.Sol_Categories.CategoryID = #Staged.CategoryId LEFT OUTER JOIN
                        #OnRBill ON dbo.Sol_Categories.CategoryID = #OnRBill.CategoryId LEFT OUTER JOIN
                        #Shipped ON dbo.Sol_Categories.CategoryID = #Shipped.CategoryId LEFT OUTER JOIN
                        #Unstaged ON dbo.Sol_Categories.CategoryID = #Unstaged.CategoryId         	



END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_BOL_Containers]    Script Date: 02/27/2012 22:03:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Reports_BOL_Containers]
(
	@ShipmentID int,
	@ProductCode varchar(50),
	@ContainerID int
)
AS 
SELECT	COUNT(s.ShipmentID) AS ContainerCount
FROM    dbo.sol_Stage s
INNER JOIN Sol_Products p ON s.ProductID = p.ProductID
AND (p.ProductCode = @ProductCode )
WHERE	(s.ContainerID = @ContainerID) AND (s.ShipmentID = @ShipmentID)

GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_BOL]    Script Date: 20/02/2012 15:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[Sol_Reports_BOL]
(
   @ShipmentID int,
   @ProductCode varchar(50)
)
AS

	BEGIN
	   SET NOCOUNT ON
   
	SELECT  
	Sum(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 as Dozen, 
	Sum(sol_Stage.Quantity) as Quantity
	FROM  
	dbo.sol_Shipment sol_Shipment  
	INNER JOIN sol_Stage sol_Stage ON sol_Shipment.ShipmentID=sol_Stage.ShipmentID  
	INNER JOIN Sol_Products p ON Sol_Stage.ProductID = p.ProductID
	AND (p.ProductCode = @ProductCode )
	WHERE  
	sol_Shipment.ShipmentID = @ShipmentID

	END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_DailyTotal_Category]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Reports_DailyTotal_Category]
(
      @DateFrom varchar(23),
      @DateTo varchar(23),
      @CashTrayID int
)
AS
 
BEGIN
            SET NOCOUNT ON
    if(@CashTrayID IS NULL ) SET @CashTrayID = -1;
    if(@CashTrayID < 0)
            BEGIN
                        SELECT  
                                    CASE dbo.sol_OrdersDetail.OrderType
                                               WHEN 'S' THEN 'SALES'
                                               ELSE dbo.Sol_Categories.Description
                                    END
                                    AS Description,                      
                                    SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, 
                                    CASE dbo.sol_OrdersDetail.OrderType
                                               WHEN 'S' THEN 0 - SUM(dbo.sol_OrdersDetail.Amount)  /* Tax needs to be added here  */
                                               ELSE SUM(dbo.sol_OrdersDetail.Amount)
                                    END
                                    AS SumOfAmount
                        
                        FROM    dbo.sol_Orders INNER JOIN
                                               dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID AND 
                                               dbo.sol_Orders.OrderType = dbo.sol_OrdersDetail.OrderType INNER JOIN
                                               dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID
                        WHERE   (dbo.sol_Orders.Status = 'P' OR dbo.sol_Orders.Status = 'O') AND (dbo.sol_Orders.DateClosed BETWEEN @DateFrom AND @DateTo)
                        GROUP BY dbo.Sol_Categories.Description, dbo.sol_OrdersDetail.OrderType
                        ORDER BY dbo.Sol_Categories.Description
    END
    ELSE
            BEGIN
                        SELECT
                                    CASE dbo.sol_OrdersDetail.OrderType
                                               WHEN 'S' THEN 'SALES'
                                               ELSE dbo.Sol_Categories.Description
                                    END
                                    AS Description,                      
                                    SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, 
                                    CASE dbo.sol_OrdersDetail.OrderType
                                               WHEN 'S' THEN 0 - SUM(dbo.sol_OrdersDetail.Amount)  /* Tax needs to be added here  */
                                               ELSE SUM(dbo.sol_OrdersDetail.Amount)
                                    END
                                    AS SumOfAmount
                        
                        FROM    dbo.sol_Orders INNER JOIN
                                               dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID AND 
                                               dbo.sol_Orders.OrderType = dbo.sol_OrdersDetail.OrderType INNER JOIN
                                               dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID
                        WHERE   (dbo.sol_Orders.Status = 'P' OR dbo.sol_Orders.Status = 'O') AND (dbo.sol_Orders.DateClosed BETWEEN @DateFrom AND @DateTo)
                                               AND sol_Orders.CashTrayID = @CashTrayID
                        GROUP BY dbo.Sol_Categories.Description, dbo.sol_OrdersDetail.OrderType
                        ORDER BY dbo.Sol_Categories.Description
    END
    
END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_TransactionSearch]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Reports_TransactionSearch]
(
   @OrderID int
)
AS

BEGIN
   SET NOCOUNT ON

SELECT      dbo.sol_Orders.OrderID, dbo.sol_OrdersDetail.Date, u.UserName, 
					CASE 
						WHEN (dbo.sol_orders.DateClosed >= dbo.sol_Orders.Date) THEN 
							CONVERT(VARCHAR(10), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60) 
							+ ':' + RIGHT('00' + CONVERT(VARCHAR(4), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) 
							- DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60 * 60),2) 
						ELSE
							'-'
						END
					AS Duration, 
                    dbo.sol_OrdersDetail.Description, dbo.sol_OrdersDetail.Quantity, dbo.sol_OrdersDetail.Amount, dbo.sol_Orders.Status, 
                    dbo.sol_Customers.CustomerCode
FROM          dbo.aspnet_Users u INNER JOIN
                        dbo.sol_Orders ON u.UserId = dbo.sol_Orders.UserID INNER JOIN
                        dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID AND 
                        dbo.sol_Orders.OrderType = dbo.sol_OrdersDetail.OrderType LEFT OUTER JOIN
                        dbo.sol_Customers ON dbo.sol_Orders.CustomerID = dbo.sol_Customers.CustomerID
WHERE      (dbo.sol_Orders.OrderID = @OrderID)
END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_TransactionReport]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Reports_TransactionReport]
(
      @DateFrom varchar(23),
      @DateTo varchar(23)
)
AS

BEGIN
   SET NOCOUNT ON

SELECT      dbo.sol_Orders.Date, 
			dbo.sol_Orders.OrderID, 
			u.UserName, 
			DATEDIFF(ss,dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed)/CAST(SUM(dbo.sol_OrdersDetail.Quantity) AS Float) AS TimePerContainer, 
			SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, 
			CONVERT(VARCHAR(10), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60) 
                        + ':' + RIGHT('00' + CONVERT(VARCHAR(4), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) 
                        - DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60 * 60),2) AS Duration, 
			dbo.sol_Orders.TotalAmount, 
			dbo.sol_Orders.Status,
			dbo.sol_orders.DatePaid, 
            dbo.sol_Customers.CustomerCode
FROM          dbo.aspnet_Users u INNER JOIN
                        dbo.sol_Orders ON u.UserId = dbo.sol_Orders.UserID INNER JOIN
                        dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID AND 
                        dbo.sol_Orders.OrderType = dbo.sol_OrdersDetail.OrderType LEFT OUTER JOIN
                        dbo.sol_Customers ON dbo.sol_Orders.CustomerID = dbo.sol_Customers.CustomerID
WHERE      (dbo.sol_Orders.Status <> 'D') AND (dbo.sol_Orders.OrderType <> 'A') AND (dbo.sol_Orders.DateClosed >= @DateFrom)
GROUP BY dbo.sol_Orders.Date, 
            dbo.sol_Orders.OrderID, u.UserName, 
            DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed), 
            dbo.sol_Orders.TotalAmount, 
            dbo.sol_Customers.CustomerCode,
            dbo.sol_orders.DatePaid,  
            dbo.sol_Orders.Status
HAVING       (dbo.sol_Orders.Date BETWEEN @DateFrom AND @DateTo)
ORDER BY dbo.sol_Orders.Date

END

GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_TransactionDuration]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Reports_TransactionDuration]
(
      @DateFrom varchar(23),
      @DateTo varchar(23)
)
AS

BEGIN
   SET NOCOUNT ON

SELECT      dbo.sol_Orders.Date, 
                  dbo.sol_Orders.OrderID, 
                  u.UserName, 
                  DATEDIFF(ss,dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed)/CAST(SUM(dbo.sol_OrdersDetail.Quantity) AS Float) AS TimePerContainer,
                  CONVERT(VARCHAR(10), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60) 
                        + ':' + RIGHT('00' + CONVERT(VARCHAR(4), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) 
                        - DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60 * 60),2) AS Duration, 
                  SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, 
            dbo.sol_Orders.TotalAmount
FROM        dbo.aspnet_Users u INNER JOIN
            dbo.sol_Orders ON u.UserId = dbo.sol_Orders.UserID INNER JOIN
            dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID AND 
            dbo.sol_Orders.OrderType = dbo.sol_OrdersDetail.OrderType
WHERE      (dbo.sol_Orders.Status <> 'D') AND (dbo.sol_Orders.DateClosed >= @DateFrom)
GROUP BY    dbo.sol_Orders.Date, 
                  dbo.sol_Orders.OrderID, 
                  u.UserName, 
                  dbo.sol_Orders.TotalAmount, 
                  DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed)
HAVING       (dbo.sol_Orders.Date BETWEEN @DateFrom AND @DateTo)
ORDER BY DATEDIFF(ss,dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed)/CAST(SUM(dbo.sol_OrdersDetail.Quantity) AS Float)

END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_PurchasedInventory]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[Sol_Reports_PurchasedInventory]
(
      @DateFrom varchar(23),
      @DateTo varchar(23),
      @CustomerID int
)
AS

BEGIN
   DECLARE @TotalQuantity Float
   SET NOCOUNT ON
   IF(@DateFrom IS NULL) SET @DateFrom = '1950-01-01 00:00:00'
   IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'
   if(@CustomerID <0) SET @CustomerID = Null

IF(@CustomerID IS Null)
BEGIN
  SELECT      @TotalQuantity = SUM(Quantity)
    FROM          dbo.sol_OrdersDetail
    WHERE      (Status <> 'D') AND (Date BETWEEN @DateFrom AND @DateTo)

  SELECT      dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description, 
						SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, 
						SUM(dbo.sol_OrdersDetail.Quantity) / @TotalQuantity * 100 AS PercentOfTotal, 
						Sum(CONVERT(decimal(18,4), dbo.sol_OrdersDetail.Quantity))/12 AS Dozen,
						SUM(dbo.sol_OrdersDetail.Amount) AS SumOfAmount
    FROM          dbo.sol_OrdersDetail INNER JOIN
                        dbo.sol_Orders ON dbo.sol_OrdersDetail.OrderID = dbo.sol_Orders.OrderID AND 
                        dbo.sol_OrdersDetail.OrderType = dbo.sol_Orders.OrderType INNER JOIN
                        dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID
    WHERE      (dbo.sol_Orders.Status <> 'D') AND (dbo.sol_Orders.Date BETWEEN @DateFrom AND @DateTo)
    GROUP BY dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description
END

-- Else
IF(@CustomerID IS NOT NULL)
BEGIN
  SELECT      @TotalQuantity = SUM(dbo.sol_OrdersDetail.Quantity)
    FROM          dbo.sol_OrdersDetail INNER JOIN
                        dbo.sol_Orders ON dbo.sol_OrdersDetail.OrderID = dbo.sol_Orders.OrderID AND dbo.sol_OrdersDetail.OrderType = dbo.sol_Orders.OrderType
    WHERE      (dbo.sol_Orders.Status <> 'D') AND (dbo.sol_Orders.Date BETWEEN @DateFrom AND @DateTo) AND (dbo.sol_Orders.CustomerID = @CustomerID)

  SELECT      dbo.sol_Customers.Name AS CustomerName, dbo.Sol_Categories.Description, SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, 
                        SUM(dbo.sol_OrdersDetail.Quantity) / @TotalQuantity * 100 AS PercentOfTotal, Sum(CONVERT(decimal(18,4), dbo.sol_OrdersDetail.Quantity))/12 AS Dozen, 
                        SUM(dbo.sol_OrdersDetail.Amount) AS SumOfAmount
    FROM          dbo.sol_OrdersDetail INNER JOIN
                        dbo.sol_Orders ON dbo.sol_OrdersDetail.OrderID = dbo.sol_Orders.OrderID AND 
                        dbo.sol_OrdersDetail.OrderType = dbo.sol_Orders.OrderType INNER JOIN
                        dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID INNER JOIN
                        dbo.sol_Customers ON dbo.sol_Orders.CustomerID = dbo.sol_Customers.CustomerID
    WHERE      (dbo.sol_Orders.Status <> 'D') AND (dbo.sol_Orders.Date BETWEEN @DateFrom AND @DateTo) AND (dbo.sol_Orders.CustomerID = @CustomerID)
    GROUP BY dbo.Sol_Categories.Description, dbo.sol_Customers.Name

END


END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_InventoryOnHand_Unstaged]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[Sol_Reports_InventoryOnHand_Unstaged]
(
   @DateTo varchar(23) = NULL,
   @CurrentUserName nvarchar(256) = NULL  /** UserName is no longer used but left here for backwards compatibility 9/13/2014 **/
)
AS
/**  With this version starting 9/24/2014 V2.1.22:
        dbo.sol_QueryDate  is no longer used
		dbo.vw_sol_Products_Unstaged_Part1 is no longer used
		dbo.vw_sol_Products_Unstaged_Part2 is no longer used
**/

BEGIN
   DECLARE @TotalQuantity Float
   SET NOCOUNT ON
   IF(@DateTo IS NULL) SET @DateTo = CONVERT(varchar, GETDATE(), 23) + ' 23:59:59'

CREATE TABLE #Unstaged ( CategoryID int, TotalQuantity int );
INSERT INTO #Unstaged 
   SELECT      dbo.Sol_Categories.CategoryID, SUM(dbo.sol_OrdersDetail.Quantity) AS TotalQuantity
   FROM          dbo.sol_OrdersDetail RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_OrdersDetail.CategoryID = dbo.Sol_Categories.CategoryID
   WHERE      (NOT (dbo.sol_OrdersDetail.Status = 'D')) AND (dbo.sol_OrdersDetail.Date <= CONVERT(datetime,@DateTo,120))
   GROUP BY dbo.Sol_Categories.CategoryID

CREATE TABLE #Staged ( CategoryID int, TotalDozen decimal(18,4), TotalQuantity int );
INSERT INTO #Staged 
   SELECT      dbo.sol_Products.CategoryID, SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS TotalDozen, SUM(dbo.sol_Stage.Quantity) AS TotalQuantity
   FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID
   WHERE      (NOT (dbo.sol_Stage.Status = 'D')) AND (dbo.sol_Stage.Date <= CONVERT(datetime,@DateTo,120))
   GROUP BY dbo.sol_Products.CategoryID

/** The following Includes TotalQuanity for calculating percentage  **/
SELECT      @TotalQuantity = SUM(#Unstaged.TotalQuantity) - (SUM(ISNULL(#Staged.TotalQuantity, 0)))
FROM   #Unstaged LEFT OUTER JOIN #Staged ON #Unstaged.CategoryID = #Staged.CategoryID
WHERE  #Unstaged.CategoryID > 0

IF(@TotalQuantity = 0) SET @TotalQuantity = 1  --can not divide by zero

SELECT      dbo.Sol_Categories.CategoryID AS Id, dbo.Sol_Categories.Description, dbo.Sol_Categories.RefundAmount, 
                        ISNULL(#Unstaged.TotalQuantity, 0) - ISNULL(#Staged.TotalQuantity, 0) AS Quantity, 
                        (ISNULL(#Unstaged.TotalQuantity, 0) - ISNULL(#Staged.TotalQuantity, 0)) 
                        / @TotalQuantity * 100 AS PercentOfTotal, 
						(ISNULL(#Unstaged.TotalQuantity, 0) - ISNULL(#Staged.TotalQuantity, 0)) / 12 AS Dozen
FROM          dbo.Sol_Categories LEFT OUTER JOIN
                        #Staged ON dbo.Sol_Categories.CategoryID = #Staged.CategoryID LEFT OUTER JOIN
                        #Unstaged ON dbo.Sol_Categories.CategoryID = #Unstaged.CategoryID
WHERE      (dbo.Sol_Categories.CategoryID > 0)

END

GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_CorporateAccountStatement]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Reports_CorporateAccountStatement]
(
   @DateFrom varchar(23),
   @DateTo varchar(23),
   @CustomerId int
)
AS

BEGIN
   SET NOCOUNT ON
   DECLARE @sql NVARCHAR(3000)

   IF(@DateFrom IS NULL) SET @DateFrom = '1950-01-01 00:00:00'
   IF(@DateTo IS NULL) SET @DateTo = '2200-01-01 00:00:00'
   IF(@CustomerId <0 ) SET @CustomerId = NULL

	SET @sql = 
		'SELECT '''+@DateFrom+''' AS DateFrom, '''+@DateTo+''' AS DateTo, dbo.sol_Customers.CustomerID, dbo.sol_Customers.CustomerCode, dbo.sol_Customers.Name, dbo.sol_Customers.Contact, dbo.sol_Customers.Address1, '+
        '                dbo.sol_Customers.Address2, dbo.sol_Customers.City, dbo.sol_Customers.Province, dbo.sol_Customers.PostalCode, dbo.sol_Customers.PhoneNumber, dbo.sol_Customers.Email,   '+
        '                dbo.sol_Orders.Date, dbo.sol_Orders.OrderID, SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, SUM(dbo.sol_OrdersDetail.Amount)-dbo.sol_orders.FeeAmount AS SumOfAmount,  '+
        '                dbo.sol_Orders.Reference, '+
		'                dbo.sol_Orders.OrderType, '+
        '                CASE dbo.sol_Orders.DatePaid '+
        '                                  WHEN CONVERT(datetime, ''1753-01-01 12:00:00'', 120) THEN Null  '+
        '                                  ELSE dbo.sol_Orders.DatePaid  '+
        '                END  '+
        '                AS DateOfPayment, '+
        '                CASE dbo.sol_Orders.DatePaid '+
        '                                  WHEN CONVERT(datetime, ''1753-01-01 12:00:00'', 120) THEN SUM(dbo.sol_OrdersDetail.Amount)-dbo.sol_orders.FeeAmount  '+
        '                                  ELSE 0 '+
        '                END  '+
        '                AS Outstanding '+
		'FROM          dbo.sol_Orders INNER JOIN '+
        '                dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID AND  '+
        '                dbo.sol_Orders.OrderType = dbo.sol_OrdersDetail.OrderType INNER JOIN '+
        '                dbo.sol_Customers ON dbo.sol_Orders.CustomerID = dbo.sol_Customers.CustomerID '+
		'WHERE      (dbo.sol_Orders.Status = ''O'') AND (dbo.sol_OrdersDetail.Date >= CONVERT(datetime, '''+@DateFrom+''', 120)) AND  '+
        '                (dbo.sol_OrdersDetail.Date <= CONVERT(datetime, '''+@DateTo+''', 120) ) ';
		IF(@CustomerId IS NOT NULL)
		BEGIN
			SET @sql = @sql +
			'AND dbo.sol_Orders.CustomerId = '+CAST(@CustomerId as nvarchar(100))+ ' ';
		END

		SET @sql = @sql +
		'GROUP BY dbo.sol_Customers.CustomerID, dbo.sol_Customers.CustomerCode, dbo.sol_Customers.Name, dbo.sol_Customers.Contact, dbo.sol_Customers.Address1, dbo.sol_Customers.Address2, dbo.sol_Customers.City, '+
        '                dbo.sol_Customers.Province, dbo.sol_Customers.PostalCode, dbo.sol_Customers.PhoneNumber, dbo.sol_Customers.Email, dbo.sol_Orders.OrderID, dbo.sol_Orders.Date, dbo.sol_Orders.FeeAmount,  '+
        '                dbo.sol_Orders.DatePaid, dbo.sol_Orders.Reference, dbo.sol_Orders.OrderType ';
		EXEC(@sql)
END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_DailyTotal_Expenses]    Script Date: 28/06/2012 12:04:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Reports_DailyTotal_Expenses]
(
      @DateFrom varchar(23),
      @DateTo varchar(23),
      @CashTrayID int
)
AS
BEGIN

    if(@CashTrayID IS NULL ) SET @CashTrayID = -1;
    if(@CashTrayID < 0)
      BEGIN
            SELECT dbo.sol_ExpenseTypes.Description, SUM(dbo.sol_Entries.Amount) AS ExpenseAmount
                  FROM dbo.sol_Entries LEFT OUTER JOIN dbo.sol_ExpenseTypes ON dbo.sol_Entries.ExpenseTypeID = dbo.sol_ExpenseTypes.ExpenseTypeID
                  WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'E')
                  GROUP BY dbo.sol_ExpenseTypes.Description
      END            
      ELSE
      BEGIN
      SELECT dbo.sol_ExpenseTypes.Description, SUM(dbo.sol_Entries.Amount) AS ExpenseAmount
                  FROM dbo.sol_Entries LEFT OUTER JOIN dbo.sol_ExpenseTypes ON dbo.sol_Entries.ExpenseTypeID = dbo.sol_ExpenseTypes.ExpenseTypeID
                  WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'E') 
                        AND sol_Entries.CashTrayID = @CashTrayID
                  GROUP BY dbo.sol_ExpenseTypes.Description
      END
END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_DailyTotal_Breakdown]    Script Date: 04/17/2013 18:08:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Reports_DailyTotal_Breakdown]  --test:  Sol_Reports_DailyTotal_Breakdown '2016-01-31 00:00:00','2016-02-01 23:59:59',0
(
      @DateFrom varchar(23),
      @DateTo varchar(23),
      @CashTrayID int
)
AS
BEGIN

    DECLARE @PreviousOrdersPaidOut money
    DECLARE @PreviousSalesPaidOut money
    DECLARE @CashRefundQTY int
    DECLARE @CashRefund money
    DECLARE @OnAccountQTY int
    /*DECLARE @OnAccount money*/
    DECLARE @CashRefundSalesQTY int
    DECLARE @CashRefundSales money
    DECLARE @OnAccountSalesQTY int
    DECLARE @OnAccountSales money
    DECLARE @CashRefundReturnsQTY int
    DECLARE @CashRefundReturns money
    DECLARE @OnAccountReturnsQTY int
    DECLARE @OnAccountReturns money
    /*DECLARE @OutstandingReturns money
    DECLARE @OutstandingSales money*/
    DECLARE @OutstandingOrders money
    DECLARE @OutstandingOrdersQTY int
    /*DECLARE @TotalRefundQTY int
    DECLARE @TotalRefund money*/
    DECLARE @CashFee money
    DECLARE @OnAccountFee money
    DECLARE @CashFeeSales money
    DECLARE @OnAccountFeeSales money
    DECLARE @CashFeeReturns money
    DECLARE @OnAccountFeeReturns money
    DECLARE @ClosedReturnFees money
    DECLARE @ClosedSalesFees money
    DECLARE @PreviousCashFeeReturns money
    DECLARE @PreviousCashFeeSales money
    DECLARE @PreviousCashFee money
    /*DECLARE @OutstandingFeeReturns money
    DECLARE @OutstandingFeeSales money*/
    DECLARE @OutstandingFee money
    DECLARE @TotalExpense money
    DECLARE @CashFloat money
    DECLARE @CashBalance money 
    DECLARE @CashCounted money
    DECLARE @Discrepancy money 
    DECLARE @VoidTransactionsQTY int
    DECLARE @VoidTransactions money
    DECLARE @VoidTransactionFees money
    DECLARE @AccountPaidCash money   /* PaymentTypeID = 2 */
    DECLARE	@AccountPaidCheque money /* PaymentTypeID = 1 */
    DECLARE @TotalAccountPayments money
    
   
    if(@CashTrayID IS NULL ) SET @CashTrayID = -1;
    if(@CashTrayID < 0)
      BEGIN
      SELECT @CashRefundReturnsQTY = ISNULL(COUNT(OrderID),0), @CashRefundReturns = ISNULL(SUM(TotalAmount),0), @CashFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'R' OR OrderType = 'Q') -- QD orders added on 2016-01-31
      SELECT @OnAccountReturnsQTY = ISNULL(COUNT(OrderID),0), @OnAccountReturns = ISNULL(SUM(TotalAmount),0), @OnAccountFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'R' OR OrderType = 'Q') -- QD orders added on 2016-01-31
      SELECT @CashRefundSalesQTY = ISNULL(COUNT(OrderID),0), @CashRefundSales = 0 - ISNULL(SUM(TotalAmount),0), @CashFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'S')
      SELECT @OnAccountSalesQTY = ISNULL(COUNT(OrderID),0), @OnAccountSales = 0 - ISNULL(SUM(TotalAmount),0), @OnAccountFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'S')
      SELECT @VoidTransactionsQTY = ISNULL(COUNT(OrderID),0), @VoidTransactions = ISNULL(SUM(TotalAmount),0), @VoidTransactionFees = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'D') AND (DateClosed BETWEEN @DateFrom AND @DateTo)
      SELECT @PreviousOrdersPaidOut = ISNULL(SUM(TotalAmount),0), @PreviousCashFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed < @DateFrom) AND (OrderType = 'R' OR OrderType = 'Q') -- QD orders added on 2016-01-31
      SELECT @PreviousSalesPaidOut = 0 - ISNULL(SUM(TotalAmount),0), @PreviousCashFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed < @DateFrom) AND (OrderType = 'S')
      
      /* The following change on for Version 2.1 makes the report include all outstanding orders.  Before it only include outstanding orders that were created during the time period.
      SELECT @OutstandingOrdersQTY = ISNULL(COUNT(OrderID),0), @OutstandingReturns = ISNULL(SUM(TotalAmount),0), @OutstandingFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid NOT BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo)) 
              OR ((Status = 'A') AND (DateClosed BETWEEN @DateFrom AND @DateTo))) 
              AND (OrderType = 'R')
      SELECT @OutstandingOrdersQTY = @OutstandingOrdersQTY + ISNULL(COUNT(OrderID),0), @OutstandingSales = 0 - ISNULL(SUM(TotalAmount),0), @OutstandingFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid NOT BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo)) 
              OR ((Status = 'A') AND (DateClosed BETWEEN @DateFrom AND @DateTo))) 
              AND (OrderType = 'S')  
        The above two statements are replaced with the following*/
      /*
      SELECT @OutstandingOrdersQTY = ISNULL(COUNT(OrderID),0), @OutstandingReturns = ISNULL(SUM(TotalAmount),0), @OutstandingFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid > @DateTo) AND (DateClosed <= @DateTo)) 
              OR ((Status = 'A') AND (DateClosed <= @DateTo))) 
              AND (OrderType = 'R')
      SELECT @OutstandingOrdersQTY = @OutstandingOrdersQTY + ISNULL(COUNT(OrderID),0), @OutstandingSales = 0 - ISNULL(SUM(TotalAmount),0), @OutstandingFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid > @DateTo) AND (DateClosed <= @DateTo)) 
              OR ((Status = 'A') AND (DateClosed <= @DateTo))) 
              AND (OrderType = 'S')  
       */

      SELECT @OutstandingOrdersQTY = ISNULL(COUNT(OrderID),0), @OutstandingOrders = ISNULL(SUM(TotalAmount),0), @OutstandingFee = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid > @DateTo) AND (DateClosed <= @DateTo)) 
              OR ((Status = 'A') AND (DateClosed <= @DateTo))) AND (DateClosed >= Date) AND (OrderType = 'R' OR OrderType = 'S')
		
      SELECT @TotalExpense = ISNULL(SUM(Amount),0) FROM dbo.sol_Entries
            WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'E')
      SELECT @CashFloat = ISNULL(SUM(Amount),0) FROM dbo.sol_Entries
            WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'O' OR  EntryType = 'F')
      SELECT @CashCounted = ISNULL(SUM(Amount),0) FROM dbo.sol_Entries
            WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'C')
      SELECT @AccountPaidCash = ISNULL(SUM(TotalAmount),0) - ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (OrderType != 'A') AND PaymentTypeID = 2
      SELECT @AccountPaidCheque = ISNULL(SUM(TotalAmount),0) - ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (OrderType != 'A') AND PaymentTypeID = 1

      END            
      ELSE
      BEGIN
      SELECT @AccountPaidCash = ISNULL(SUM(TotalAmount),0) - ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (OrderType != 'A') AND PaymentTypeID = 2 AND CashTrayID = @CashTrayID
      SELECT @AccountPaidCheque = ISNULL(SUM(TotalAmount),0) - ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (OrderType != 'A') AND PaymentTypeID = 1 AND CashTrayID = @CashTrayID

      SELECT @CashRefundReturnsQTY = ISNULL(COUNT(OrderID),0), @CashRefundReturns = ISNULL(SUM(TotalAmount),0), @CashFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'R')
            AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @OnAccountReturnsQTY = ISNULL(COUNT(OrderID),0), @OnAccountReturns = ISNULL(SUM(TotalAmount),0), @OnAccountFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'R')
            AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @CashRefundSalesQTY = ISNULL(COUNT(OrderID),0), @CashRefundSales = 0 - ISNULL(SUM(TotalAmount),0), @CashFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'S')
            AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @OnAccountSalesQTY = ISNULL(COUNT(OrderID),0), @OnAccountSales = 0 - ISNULL(SUM(TotalAmount),0), @OnAccountFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DateClosed BETWEEN @DateFrom AND @DateTo) AND (OrderType = 'S')
            AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @VoidTransactionsQTY = ISNULL(COUNT(OrderID),0), @VoidTransactions = ISNULL(SUM(TotalAmount),0), @VoidTransactionFees = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'D') AND (DateClosed BETWEEN @DateFrom AND @DateTo)
            AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @PreviousOrdersPaidOut = ISNULL(SUM(TotalAmount),0), @PreviousCashFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed < @DateFrom) AND (OrderType = 'R')
            AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @PreviousSalesPaidOut = 0 - ISNULL(SUM(TotalAmount),0), @PreviousCashFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'P') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (DateClosed < @DateFrom) AND (OrderType = 'S')
            AND sol_Orders.CashTrayID = @CashTrayID
      
      /*  Same change added here as above for outstanding orders
      SELECT @OutstandingOrdersQTY = ISNULL(COUNT(OrderID),0), @OutstandingReturns = ISNULL(SUM(TotalAmount),0), @OutstandingFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid NOT BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo)) 
              OR ((Status = 'A') AND (DateClosed BETWEEN @DateFrom AND @DateTo))) 
              AND (OrderType = 'R')
              AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @OutstandingOrdersQTY = @OutstandingOrdersQTY + ISNULL(COUNT(OrderID),0), @OutstandingSales = 0 - ISNULL(SUM(TotalAmount),0), @OutstandingFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid NOT BETWEEN @DateFrom AND @DateTo) AND (DateClosed BETWEEN @DateFrom AND @DateTo)) 
              OR ((Status = 'A') AND (DateClosed BETWEEN @DateFrom AND @DateTo))) 
              AND (OrderType = 'S')
              AND sol_Orders.CashTrayID = @CashTrayID
      */
      /*
      SELECT @OutstandingOrdersQTY = ISNULL(COUNT(OrderID),0), @OutstandingReturns = ISNULL(SUM(TotalAmount),0), @OutstandingFeeReturns = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid > @DateTo) AND (DateClosed <= @DateTo)) 
              OR ((Status = 'A') AND (DateClosed <= @DateTo))) 
              AND (OrderType = 'R')
              AND sol_Orders.CashTrayID = @CashTrayID
      SELECT @OutstandingOrdersQTY = @OutstandingOrdersQTY + ISNULL(COUNT(OrderID),0), @OutstandingSales = 0 - ISNULL(SUM(TotalAmount),0), @OutstandingFeeSales = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid > @DateTo) AND (DateClosed <= @DateTo)) 
              OR ((Status = 'A') AND (DateClosed <= @DateTo))) 
              AND (OrderType = 'S')
              AND sol_Orders.CashTrayID = @CashTrayID
		*/
      SELECT @OutstandingOrdersQTY = ISNULL(COUNT(OrderID),0), @OutstandingOrders = ISNULL(SUM(TotalAmount),0), @OutstandingFee = ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (((Status = 'P') AND (DatePaid > @DateTo) AND (DateClosed <= @DateTo)) 
              OR ((Status = 'A') AND (DateClosed <= @DateTo))) AND (DateClosed >= Date) AND (OrderType = 'R' OR OrderType = 'S')
              AND sol_Orders.CashTrayID = @CashTrayID

      SELECT @TotalExpense = ISNULL(SUM(Amount),0) FROM dbo.sol_Entries
            WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'E')
             AND sol_Entries.CashTrayID = @CashTrayID
      SELECT @CashFloat = ISNULL(SUM(Amount),0) FROM dbo.sol_Entries
            WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'O' OR  EntryType = 'F')
            AND sol_Entries.CashTrayID = @CashTrayID
      SELECT @CashCounted = ISNULL(SUM(Amount),0) FROM dbo.sol_Entries
            WHERE (Date BETWEEN @DateFrom AND @DateTo) AND (EntryType = 'C')
            AND sol_Entries.CashTrayID = @CashTrayID
      SELECT @AccountPaidCash = ISNULL(SUM(TotalAmount),0) - ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (OrderType != 'A') AND PaymentTypeID = 2
            AND CashTrayID = @CashTrayID
      SELECT @AccountPaidCheque = ISNULL(SUM(TotalAmount),0) - ISNULL(SUM(FeeAmount),0)
            FROM dbo.sol_Orders WHERE (Status = 'O') AND (DatePaid BETWEEN @DateFrom AND @DateTo) AND (OrderType != 'A') AND PaymentTypeID = 1
            AND CashTrayID = @CashTrayID
      END
      
      SET @CashRefundQTY = @CashRefundReturnsQTY + @CashRefundSalesQTY
      SET @CashRefund = @CashRefundReturns + @CashRefundSales
      /*Removed 4/12/14 SET @OutstandingOrders = @OutstandingReturns + @OutstandingSales*/
      SET @CashFee = @CashFeeReturns + @CashFeeSales
      /*Removed 4/12/14 SET @OutstandingFee = @OutstandingFeeReturns + @OutstandingFeeSales*/
      SET @ClosedReturnFees = @OnAccountFeeReturns + @CashFeeReturns
      SET @ClosedSalesFees = @OnAccountFeeSales + @CashFeeSales
      SET @PreviousCashFee = @PreviousCashFeeReturns + @PreviousCashFeeSales
      /*Removed 4/12/14 SET @OnAccount = @OnAccountReturns + @OnAccountSales  
      SET @OnAccountFee = @OnAccountFeeReturns + @OnAccountFeeSales
      SET @TotalRefundQTY = @CashRefundQTY + @OnAccountQTY
      SET @TotalRefund = @CashRefund + @OnAccount + @PreviousOrdersPaidOut + @PreviousSalesPaidOut + @OutstandingOrders*/
      SET @CashBalance = @CashFloat - (@PreviousOrdersPaidOut + @PreviousSalesPaidOut + @CashRefund) + (@CashFee + @PreviousCashFee) + @TotalExpense - @AccountPaidCash  --updated 2016-01-31
      SET @Discrepancy = @CashBalance - @CashCounted
      SET @TotalAccountPayments = @AccountPaidCash + @AccountPaidCheque
      
      SELECT @CashRefundQTY AS CashRefundQTY,
                  @CashRefundReturns AS CashRefundReturns,
                  (0 - @CashRefundSales) AS CashRefundSales,
                  @PreviousOrdersPaidOut AS PreviousOrdersPaidOut,
                  (0 - @PreviousSalesPaidOut) AS PreviousSalesPaidOut,
                  @CashRefund AS CashRefund,  /*Not used anymore  ?? This might be used*/
                  (@PreviousOrdersPaidOut + @PreviousSalesPaidOut + @CashRefund) AS TotalCashRefund,
                  (@PreviousOrdersPaidOut + @CashRefundReturns + @OnAccountReturns) AS TotalReturnOrders,
                  (0 - @PreviousSalesPaidOut - @CashRefundSales - @OnAccountSales) AS TotalSalesOrders,
                  @OnAccountReturns AS OnAccountReturns,
                  (0 - @OnAccountSales) AS OnAccountSales,
                  (@OnAccountReturns + @CashRefundReturns) AS ClosedReturnOrders,
                  (@OnAccountReturnsQTY + @CashRefundReturnsQTY) AS ClosedReturnOrdersQTY,
                  (0 - @OnAccountSales - @CashRefundSales) AS ClosedSalesOrders,
                  (@OnAccountSalesQTY + @CashRefundSalesQTY) AS ClosedSalesOrdersQTY,  
                   /*Removed 4/12/14 @OnAccountQTY AS OnAccountQTY,  Not used anymore*/
                    /*@OnAccount AS OnAccount,  Not used anymore*/
                    /*@TotalRefundQTY AS TotalRefundQTY,  Not used anymore*/
                    /*@TotalRefund AS TotalRefund,  Not used anymore*/
                  @OutstandingOrders AS OutstandingOrders,
                  @OutstandingOrdersQTY AS OutstandingOrdersQTY,
                  @PreviousCashFee AS PreviousCashFee,
                  @CashFee AS CashFee,
                  @OnAccountFee AS OnAccountFee,
                  @OutstandingFee AS OutstandingFee,
                  (@CashFee + @OnAccountFee + @PreviousCashFee) AS TotalFee,
                  (@CashFee + @PreviousCashFee) AS TotalCashFee,
                  @ClosedReturnFees AS ClosedReturnFees,
                  @ClosedSalesFees AS ClosedSalesFees,
                  @TotalExpense AS TotalExpense,
                  @CashFloat AS CashFloat,
                  @CashBalance AS CashBalance,
                  @CashCounted AS CashCounted,
                  @Discrepancy AS Discrepency,
                  @VoidTransactionsQTY AS VoidTransactionsQTY,
                  @VoidTransactions AS VoidTransactions,
                  @VoidTransactionFees AS VoidTransactionFees,
                  @AccountPaidCash AS AccountPaidCash,
                  @AccountPaidCheque AS AccountPaidCheque,
                  @TotalAccountPayments AS TotalAccountPayments
                  
END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_InventoryOnHand_Staged]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[Sol_Reports_InventoryOnHand_Staged]
(
      @DateTo varchar(23)
)
AS

BEGIN
   DECLARE @TotalQuantity Float
   SET NOCOUNT ON
   IF(@DateTo IS NULL) SET @DateTo = CONVERT(varchar, GETDATE(), 23) + ' 23:59:59'

SELECT      @TotalQuantity = SUM(dbo.sol_Stage.Quantity)	--Dozen * 12)
FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
WHERE      ((dbo.sol_Stage.Status = 'P' OR dbo.sol_Stage.Status = 'I') AND (dbo.sol_Stage.Date <= @DateTo)) 
            OR ((dbo.sol_Stage.Status = 'S') AND (dbo.sol_Shipment.ShippedDate > @DateTo) AND (dbo.sol_Stage.Date <= @DateTo))

SELECT      dbo.sol_Products.ProductID, 
				dbo.sol_Products.ProDescription As Description, 
				SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity, 
				CASE @TotalQuantity WHEN 0 THEN 0 ELSE SUM(dbo.sol_Stage.Quantity) / @TotalQuantity * 100 END AS PercentOfTotal, 
				SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, 
				SUM(dbo.sol_Stage.Quantity) * dbo.Sol_Categories.RefundAmount AS Amount, 
				COUNT(dbo.sol_Stage.StageID) AS StagedContainers
				, dbo.Sol_Categories.RefundAmount as RefundAmount
FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID 
			RIGHT OUTER JOIN dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
WHERE      (dbo.sol_Stage.Status = 'P' OR
                        dbo.sol_Stage.Status = 'I') AND (dbo.sol_Stage.Date <= @DateTo) OR
                        (dbo.sol_Stage.Status = 'S') AND (dbo.sol_Stage.Date <= @DateTo) AND (dbo.sol_Shipment.ShippedDate > @DateTo)
GROUP BY dbo.sol_Products.ProductID, dbo.sol_Products.ProDescription, dbo.Sol_Categories.RefundAmount, dbo.Sol_Categories.RefundAmount

END

GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_InventoryOnHand_Shipped]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE PROCEDURE [dbo].[Sol_Reports_InventoryOnHand_Shipped]
(
      @DateTo varchar(23)
)
AS

BEGIN
   DECLARE @TotalQuantity Float
   DECLARE @DateFrom varchar(23)
   SET NOCOUNT ON
   IF(@DateTo IS NULL) SET @DateTo = CONVERT(varchar, GETDATE(), 23) + ' 23:59:59'
   SET @DateFrom = LEFT(@DateTO,10) + ' 00:00:00'

SELECT      @TotalQuantity = SUM(dbo.sol_Stage.Quantity)	--Dozen * 12) 
FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
WHERE      (dbo.sol_Stage.Status = 'S') AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo)

IF(@TotalQuantity = 0) SET @TotalQuantity = 1  --can't divide by zero

SELECT      dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description, 
						SUM(dbo.sol_Stage.Quantity) AS SumOfQuantity, 
						SUM(dbo.sol_Stage.Quantity) / @TotalQuantity * 100 AS PercentOfTotal, 
						SUM(CONVERT(decimal(18,4), sol_Stage.Quantity)) / 12 AS SumOfDozen, 
						SUM(dbo.sol_Stage.Quantity) * dbo.Sol_Categories.RefundAmount AS Amount
FROM          dbo.sol_Stage INNER JOIN
                        dbo.sol_Products ON dbo.sol_Stage.ProductID = dbo.sol_Products.ProductID LEFT OUTER JOIN
                        dbo.sol_Shipment ON dbo.sol_Stage.ShipmentID = dbo.sol_Shipment.ShipmentID RIGHT OUTER JOIN
                        dbo.Sol_Categories ON dbo.sol_Products.CategoryID = dbo.Sol_Categories.CategoryID
WHERE      (dbo.sol_Stage.Status = 'S') AND (dbo.sol_Shipment.ShippedDate BETWEEN @DateFrom AND @DateTo)
GROUP BY dbo.Sol_Categories.CategoryID, dbo.Sol_Categories.Description, dbo.Sol_Categories.RefundAmount


END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_ClerkReport]    Script Date: 12/02/2011 10:04:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sol_Reports_ClerkReport]
(
      @DateFrom varchar(23),
      @DateTo varchar(23),
      @UserID varchar(38)  = NULL  
)
AS

BEGIN
   SET NOCOUNT ON
   DECLARE @sql NVARCHAR(3000)
   IF(@DateFrom IS NULL) SET @DateFrom = '1950-01-01 00:00:00'
   IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 00:00:00'
   if(@UserID = '') set @UserID = NULL
   SET @sql = 'SELECT      dbo.sol_Orders.Date, 
                  dbo.sol_Orders.OrderID, 
                  u.UserName, 
                  DATEDIFF(ss,dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed)/CAST(SUM(dbo.sol_OrdersDetail.Quantity) AS Float) AS TimePerContainer,
                  CONVERT(VARCHAR(10), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60) 
                        + '':'' + RIGHT(''00'' + CONVERT(VARCHAR(4), DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) 
                        - DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) / 60 * 60),2 ) AS Duration, 
                  SUM(dbo.sol_OrdersDetail.Quantity) AS SumOfQuantity, 
                  dbo.sol_Orders.TotalAmount, dbo.sol_Orders.Comments,
                  CAST(DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed) AS Float)/60 AS floatDuration
FROM        dbo.aspnet_Users u INNER JOIN
            dbo.sol_Orders ON u.UserId = dbo.sol_Orders.UserID INNER JOIN
            dbo.sol_OrdersDetail ON dbo.sol_Orders.OrderID = dbo.sol_OrdersDetail.OrderID AND 
            dbo.sol_Orders.OrderType = dbo.sol_OrdersDetail.OrderType
WHERE      (dbo.sol_Orders.Status <> ''D'') AND (dbo.sol_Orders.OrderType <> ''A'') AND (dbo.sol_Orders.DateClosed >= ''' + @DateFrom + ''')';
                
   IF(@UserID IS NOT NULL) SET @sql = @sql + 'AND dbo.sol_Orders.UserId =''' + @UserID + ''' ';

   SET @sql = @sql + 'GROUP BY    dbo.sol_Orders.Date, 
                  dbo.sol_Orders.OrderID, 
                  u.UserName, 
                  dbo.sol_Orders.TotalAmount, 
                  DATEDIFF(ss, dbo.sol_Orders.Date, dbo.sol_Orders.DateClosed), dbo.sol_Orders.TotalAmount, dbo.sol_Orders.Comments '
                  + 'HAVING  dbo.sol_Orders.Date BETWEEN ''' + @DateFrom + ''' AND ''' + @DateTo + ''' '
                  + 'ORDER BY dbo.sol_Orders.Date ';

   EXEC(@sql)
END
GO

/****** Object:  StoredProcedure [dbo].[Sol_Reports_TimeClock]    Script Date: 12/19/2011 09:24:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sol_Reports_TimeClock]
(
      @DateFrom varchar(23),
      @DateTo varchar(23),
      @UserID varchar(40)	--uniqueidentifier 
)
AS
BEGIN
    SET NOCOUNT ON
      IF(@DateFrom IS NULL) SET @DateFrom = '1950-01-01 00:00:00'
      IF(@DateTo IS NULL) SET @DateTo = '3000-01-01 23:59:59'
       -- Date should be given in String format as above
      
      IF(@UserID IS NOT NULL)  --If UserID was provided
        BEGIN
            SELECT dbo.Sol_Employees.FirstName + ' ' + dbo.Sol_Employees.LastName AS EmployeeName, 
                     dbo.Sol_EmployeesLog.PunchInTime,
                     CASE WHEN (dbo.Sol_EmployeesLog.PunchInTime > dbo.Sol_EmployeesLog.PunchOutTime) THEN null ELSE dbo.Sol_EmployeesLog.PunchOutTime END AS PunchOutTime, 
                     dbo.fn_MinZero(ROUND((CAST(dbo.Sol_EmployeesLog.PunchOutTime AS Float) - CAST(dbo.Sol_EmployeesLog.PunchInTime AS FLOAT)) * 24, 1)) AS TotalHours, 
                     dbo.Sol_EmployeesLog.Comments
            FROM dbo.Sol_Employees INNER JOIN dbo.Sol_EmployeesLog ON dbo.Sol_Employees.UserId = dbo.Sol_EmployeesLog.UserId
            WHERE (dbo.Sol_EmployeesLog.PunchInTime BETWEEN CONVERT(DATETIME, @DateFrom, 102) AND CONVERT(DATETIME, @DateTo, 102)) 
              AND (dbo.Sol_EmployeesLog.UserId = @UserID)
        END
      
      ELSE    ---UserID wasn't provided 
        BEGIN
            SELECT dbo.Sol_Employees.FirstName + ' ' + dbo.Sol_Employees.LastName AS EmployeeName, 
                     dbo.Sol_EmployeesLog.PunchInTime,
                     CASE WHEN (dbo.Sol_EmployeesLog.PunchInTime > dbo.Sol_EmployeesLog.PunchOutTime) THEN null ELSE dbo.Sol_EmployeesLog.PunchOutTime END AS PunchOutTime, 
                     dbo.fn_MinZero(ROUND((CAST(dbo.Sol_EmployeesLog.PunchOutTime AS Float) - CAST(dbo.Sol_EmployeesLog.PunchInTime AS FLOAT)) * 24, 1)) AS TotalHours, 
                     dbo.Sol_EmployeesLog.Comments
            FROM dbo.Sol_Employees INNER JOIN dbo.Sol_EmployeesLog ON dbo.Sol_Employees.UserId = dbo.Sol_EmployeesLog.UserId
            WHERE (dbo.Sol_EmployeesLog.PunchInTime BETWEEN CONVERT(DATETIME, @DateFrom, 102) AND CONVERT(DATETIME, @DateTo, 102)) 
        END
END
GO

/***************/
/***TRIGGERS***/
/**************/

/****** Object:  Trigger [dbo].[Sol_OrdersDetail_UpdateStageQuantity]    Script Date: 02/08/2017 03:55:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[Sol_OrdersDetail_UpdateStageQuantity]
   ON  [dbo].[sol_OrdersDetail]
   AFTER INSERT, UPDATE, DELETE
AS 

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
    
   	DECLARE @StageID int = 0, @TotalQuantity int = 0;

	if exists(SELECT * from inserted) and exists (SELECT * from deleted)
	begin
		--update
  		SELECT @StageID = [StageID]
  		FROM INSERTED;

		if(@StageID <1)
		begin
  			SELECT @StageID = [StageID]
  			FROM DELETED;
		end
	end

	if exists (Select * from inserted) and not exists(Select * from deleted)
	begin
		--insert
  		SELECT @StageID = [StageID]
  		FROM INSERTED;
	end

	If exists(select * from deleted) and not exists(Select * from inserted)
	begin
		--delete
  		SELECT @StageID = [StageID]
  		FROM DELETED;
	end

	SELECT @TotalQuantity = SUM(ISNULL([Quantity], 0)) from [sol_OrdersDetail]
	WHERE [StageID] = @StageID
	AND [Status] != 'D';
	
   	--print @StageID;
   	--print @TotalQuantity;

	if(@TotalQuantity IS NULL) SET @TotalQuantity =0
	
	UPDATE [sol_Stage] WITH (ROWLOCK)
	SET [Quantity] = @TotalQuantity
	WHERE [StageID] = @StageID	

	--PRINT 'AFTER TRIGGER EXECUTED SUCESSFULLY';
	
END
GO

--sol_Customers
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_sol_Customers_AfterUpdate] ON [dbo].[sol_Customers]
AFTER UPDATE
AS
 	BEGIN

			DECLARE @IsNew bit
 
			SELECT @IsNew = IsNew FROM dbo.sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted) 
	If @IsNew = 0
		BEGIN
	--check each column
	   --We only care about columns that are to be synced with QuickDrop Web Service
			IF update(Name)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'Name', '''' + Name + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  
			 END
			IF update(Contact)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'Contact', '''' + Contact + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(Address1)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'Address1', '''' + Address1 + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(Address2)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'Address2', '''' + Address2 + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(City)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'City', '''' + City + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(Province)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'Province', '''' + Province + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(PostalCode)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'PostalCode', '''' + PostalCode + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(Email)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'Email', '''' + Email + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(IsActive)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'IsActive', IsActive FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(PhoneNumber)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'PhoneNumber', '''' + PhoneNumber + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
			IF update(Password)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'sol_Customers','CustomerID', CustomerID, 'Password', '''' + Password + '''' AS ColumnData FROM sol_Customers WHERE CustomerID in (SELECT CustomerID FROM inserted)  			 
			END
		END
	END
GO

--qds_bag

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_Qds_Bag_AfterUpdate] ON [dbo].[Qds_Bag]
AFTER UPDATE
AS
 	BEGIN
			DECLARE @IsNew bit
			SELECT @IsNew = IsNew FROM dbo.Qds_Bag WHERE BagID in (SELECT BagID FROM inserted) 
	If @IsNew = 0
		BEGIN
	--check each column
	   --We only care about columns that are to be synced with QuickDrop Web Service
			IF update(DropID)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'DropID', DropID FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
			IF update(BagEstimateUnderLitre)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'BagEstimateUnderLitre', BagEstimateUnderLitre FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
			IF update(BagEstimateOverLitre)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'BagEstimateOverLitre', BagEstimateOverLitre AS ColumnData FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
			IF update(DateEntered)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'DateEntered', '''' + Convert(nvarchar(50),DateEntered,120) + '''' AS ColumnData FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
			IF update(DateAccepted)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'DateAccepted', '''' + Convert(nvarchar(50),DateAccepted,120) + '''' AS ColumnData FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
			IF update(DateCounted)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'DateCounted', '''' + Convert(nvarchar(50),DateCounted,120) + '''' AS ColumnData FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
			IF update(DatePaid)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'DatePaid', '''' + Convert(nvarchar(50),DatePaid,120) + '''' AS ColumnData FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
			IF update(DatePrinted)
			 BEGIN
				INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
					SELECT 'Qds_Bag','BagID', BagID, 'DatePrinted', '''' + Convert(nvarchar(50),DatePrinted,120) + '''' AS ColumnData FROM Qds_Bag WHERE BagID in (SELECT BagID FROM inserted)  
			 END
		END
	END
GO

--Qds_Drop
CREATE TRIGGER [dbo].[trg_Qds_Drop_AfterUpdate] ON [dbo].[Qds_Drop]
AFTER UPDATE
AS
 	BEGIN
		DECLARE @IsNew bit
		SELECT @IsNew = IsNew FROM dbo.Qds_Drop WHERE DropID in (SELECT DropID FROM inserted) 
		If @IsNew = 0
			BEGIN
			--check each column	   --We only care about columns that are to be synced with QuickDrop Web Service
				IF update(CustomerID)
				 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'Qds_Drop','DropID', DropID, 'CustomerID', CustomerID FROM Qds_Drop WHERE DropID in (SELECT DropID FROM inserted)  
				 END
				IF update(NumberOfBags)
				 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'Qds_Drop','DropID', DropID, 'NumberOfBags', NumberOfBags FROM Qds_Drop WHERE DropID in (SELECT DropID FROM inserted)  
				 END
				IF update(PaymentMethodID)
				 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'Qds_Drop','DropID', DropID, 'PaymentMethodID', PaymentMethodID FROM Qds_Drop WHERE DropID in (SELECT DropID FROM inserted)  
				 END
				IF update(OrderID)
				 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'Qds_Drop','DropID', DropID, 'OrderID', OrderID FROM Qds_Drop WHERE DropID in (SELECT DropID FROM inserted)  
				 END
				IF update(OrderType)
				 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'Qds_Drop','DropID', DropID, 'OrderType', '''' + Convert(nvarchar(50),OrderType) + '''' AS ColumnData FROM Qds_Drop WHERE DropID in (SELECT DropID FROM inserted)  
				 END
			END
	END


GO

/******************************************************************************
--Sol_Order
******************************************************************************/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_sol_Orders_AfterUpdate] ON [dbo].[sol_Orders]
AFTER UPDATE
AS
 	BEGIN
			DECLARE @IsNew bit
			SELECT @IsNew = IsNew FROM dbo.sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted) 
	If @IsNew = 0
		BEGIN
	--check each column --We only care about columns that are to be synced with QuickDrop Web Service
			IF update(OrderType)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'OrderType', '''' + Convert(nvarchar(50),OrderType) + '''' AS ColumnData FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(Date)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, '[Date]', '''' + Convert(nvarchar(50),[Date],120) + '''' AS ColumnData FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(CustomerID)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'CustomerID', CustomerID FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(TotalAmount)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'TotalAmount', TotalAmount FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(DateClosed)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'DateClosed', '''' + Convert(nvarchar(50),DateClosed,120) + '''' AS ColumnData FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(DatePaid)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'DatePaid', '''' + Convert(nvarchar(50),DatePaid,120) + '''' AS ColumnData FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(FeeAmount)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'FeeAmount', FeeAmount FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(Status)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'Status', '''' + Convert(nvarchar(50),Status) + '''' AS ColumnData FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(Reference)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'Reference', '''' + Reference + '''' AS ColumnData FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
			IF update(Comments)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_Orders','OrderID', OrderID, 'Comments', '''' + Comments + '''' AS ColumnData FROM sol_Orders WHERE OrderID in (SELECT OrderID FROM inserted)  
			 END
		END
	END
GO

--dont need it anymore
--/****** Object:  Trigger [Sol_Orders_UpdateDatePaid]    Script Date: 12/02/2011 09:07:28 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[Sol_Orders_UpdateDatePaid]'))
--EXEC dbo.sp_executesql @statement = N'-- =============================================
---- Author:		<Ruben Carreon>
---- Create date: <29/06/2011>
---- Description:	<Update Order''s DatePaid on Update
---- =============================================
--CREATE TRIGGER [dbo].[Sol_Orders_UpdateDatePaid]
--   ON  [dbo].[sol_Orders]
--   AFTER UPDATE
--AS 
--BEGIN
--	-- SET NOCOUNT ON added to prevent extra result sets from
--	-- interfering with SELECT statements.
--	SET NOCOUNT ON;

--    -- Insert statements for trigger here
    
--   	DECLARE @OrderID int;
--   	DECLARE @OrderType char(1);
--   	DECLARE @DatePaid datetime;
--   	DECLARE @Status char(1);

--	--set @OrderID = 2;   	
--	--print @OrderID;


--	--
--	-- Table INSERTED is common to both the INSERT, UPDATE trigger
--	--
--	SELECT @OrderID = [OrderID],
--		@OrderType = [OrderType],
--		@Status = [Status] 
--	FROM INSERTED;
		
--   	--print @OrderID;
--   	--print @OrderType;
--   	--print @TotalAmount;
   	
--   	SET @DatePaid = ''1753-1-1 12:00:00'';
--   	if(@Status = ''P'')
--   		SET @DatePaid = GetDate();
	
	
--	UPDATE [sol_Orders] WITH (ROWLOCK)
--	SET [DatePaid] = @DatePaid
--	WHERE [OrderID] = @OrderID	
--	AND [OrderType] = @OrderType;

--	--PRINT ''AFTER TRIGGER EXECUTED SUCESSFULLY'';
	

--END
--'
--GO

/******************************************************************************
--Sol_OrderDetails
******************************************************************************/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_sol_OrdersDetail_AfterUpdate] ON [dbo].[sol_OrdersDetail]
AFTER UPDATE
AS
 	BEGIN
			DECLARE @IsNew bit
			SELECT @IsNew = IsNew FROM dbo.sol_OrdersDetail WHERE DetailID in (SELECT DetailID FROM inserted) 
	If @IsNew = 0
		BEGIN
	--check each column --We only care about columns that are to be synced with QuickDrop Web Service
			IF update(Description)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_OrdersDetail','DetailID', DetailID, 'Description', '''' + Description + '''' AS ColumnData FROM sol_OrdersDetail WHERE DetailID in (SELECT DetailID FROM inserted)  
			 END
			IF update(Quantity)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_OrdersDetail','DetailID', DetailID, 'Quantity', Quantity FROM sol_OrdersDetail WHERE DetailID in (SELECT DetailID FROM inserted)  
			 END
			IF update(Price)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_OrdersDetail','DetailID', DetailID, 'Price', Price FROM sol_OrdersDetail WHERE DetailID in (SELECT DetailID FROM inserted)  
			 END
			IF update(Amount)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_OrdersDetail','DetailID', DetailID, 'Amount', Amount FROM sol_OrdersDetail WHERE DetailID in (SELECT DetailID FROM inserted)  
			 END
			IF update(Status)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_OrdersDetail','DetailID', DetailID, 'Status', '''' + Convert(nvarchar(50),[Status]) + '''' AS ColumnData FROM sol_OrdersDetail WHERE DetailID in (SELECT DetailID FROM inserted)  
			 END
			IF update(BagID)
			 BEGIN
					INSERT INTO dbo.syc_UpdateLog(TableName, IDName, IDValue, ColumnName, ColumnData)
						SELECT 'sol_OrdersDetail','DetailID', DetailID, 'BagID', BagID FROM sol_OrdersDetail WHERE DetailID in (SELECT DetailID FROM inserted)  
			 END
		END
	END

GO

/****** Object:  Trigger [Sol_OrdersDetail_UpdateTotalAmount]    Script Date: 12/02/2011 09:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[Sol_OrdersDetail_UpdateTotalAmount]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Ruben Carreon>
-- Create date: <29/06/2011>
-- Description:	<Update Order''s TotalAmount on Insert, Delete>
-- =============================================

CREATE TRIGGER [dbo].[Sol_OrdersDetail_UpdateTotalAmount]
   ON  [dbo].[sol_OrdersDetail]
   AFTER INSERT, DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
    
   	DECLARE @OrderID int;
   	DECLARE @OrderType char(1);
   	DECLARE @TotalAmount money;

	--set @OrderID = 2;   	
	--print @OrderID;


	DECLARE @Action as char(1)
	DECLARE @Count as int
	SET @Action = ''I'' -- Set Action to ''I''nsert by default.
	SELECT @Count = COUNT(*) FROM DELETED

			--print @Action;
			--print @Count;
	

	if @Count > 0    
		BEGIN        
			SET @Action = ''D'' -- Set Action to ''D''eleted.
	        SELECT @Count = COUNT(*) FROM INSERTED
	        IF @Count > 0
				SET @Action = ''U''; -- Set Action to ''U''pdated.    
		END   	
   	
	if @Action = ''D''    
		-- This is a DELETE Record Action
		--
   		BEGIN
   			SELECT @OrderID = [OrderID],
   				@OrderType = [OrderType] 
   			FROM DELETED;
   			
   			
   			--print @OrderID;
   			--print @OrderType;
   			
		END
	ELSE
		--
		-- Table INSERTED is common to both the INSERT, UPDATE trigger
		--
		BEGIN
   			SELECT @OrderID = [OrderID],
   				@OrderType = [OrderType] 
   			FROM INSERTED;
		END
		
	SELECT @TotalAmount = SUM(ISNULL([Amount],0)) from [sol_OrdersDetail]
	WHERE [OrderID] = @OrderID
	AND [OrderType] = @OrderType;
	--AND Status != ''D'';
	
   	--print @OrderID;
   	--print @OrderType;
   	--print @TotalAmount;
	
	
	UPDATE [sol_Orders] WITH (ROWLOCK)
	SET [TotalAmount] = @TotalAmount
	WHERE [OrderID] = @OrderID	
	AND [OrderType] = @OrderType;

	--PRINT ''AFTER TRIGGER EXECUTED SUCESSFULLY'';
	

END
'
GO

/***************/
/***FUNCTIONS**/
/**************/

/****** Object:  UserDefinedFunction [dbo].[fn_Shipment_SumOfQuantity]    Script Date: 03/08/2017 11:21:50 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE FUNCTION [dbo].[fn_Shipment_SumOfQuantity]
      (@ShipmentId int, @ProductId int)

RETURNS int
AS
	BEGIN
		DECLARE @SumOfQuantity int
		SET @SumOfQuantity = 0

		SELECT @SumOfQuantity = SUM(sol_Stage.Quantity)

		FROM sol_Shipment sol_Shipment  
		INNER JOIN sol_Stage sol_Stage ON sol_Shipment.ShipmentID=sol_Stage.ShipmentID  
		AND sol_Stage.ProductID = @ProductId
		WHERE sol_Shipment.ShipmentID =   @ShipmentId
		GROUP BY sol_Stage.Quantity

		RETURN @SumOfQuantity
	END
GO

/****** Object:  UserDefinedFunction [dbo].[fn_SumofDozen]    Script Date: 11/18/2014 12:23:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Updated to version 2.146 of Solum */
CREATE FUNCTION [dbo].[fn_Shipment_SumOfDozen]
      (@ShipmentId int, @ProductId int)

RETURNS decimal(18,4)
AS
	BEGIN
		DECLARE @SumOfDozen decimal(18,4) = 0.0

		SELECT @SumOfDozen = SUM(sol_Stage.Quantity)/12

		FROM sol_Shipment sol_Shipment  
		INNER JOIN sol_Stage sol_Stage ON sol_Shipment.ShipmentID=sol_Stage.ShipmentID  
		AND sol_Stage.ProductID = @ProductId
		WHERE sol_Shipment.ShipmentID =   @ShipmentId
		GROUP BY sol_Stage.Quantity

		RETURN @SumOfDozen
	END
GO

/****** Object:  UserDefinedFunction [dbo].[Sol_RemoveNonNumericChar]    Script Date: 19/07/2013 09:23:02 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[Sol_RemoveNonNumericChar](@str varchar(500))  
returns varchar(500)  
begin  
declare @startingIndex int  
set @startingIndex=0  
while 1=1  
begin  
    set @startingIndex= patindex('%[^0-9]%',@str)  
    if @startingIndex <> 0  
    begin  
        set @str = replace(@str,substring(@str,@startingIndex,1),'')  
    end  
    else    break;   
end  
return @str  
end

GO


/****** Object:  UserDefinedFunction [dbo].[fn_MinZero]    Script Date: 12/19/2011 09:23:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_MinZero]
      (@Amount Float)
RETURNS Float
AS
      BEGIN
            IF @Amount < 0 SET @Amount = 0
      RETURN @Amount
      END


GO


/******************************************************************************
Various
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[PV_Personal_SelectAllBy]    Script Date: 07/24/2011 12:41:44 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GE_ObtenerSiguienteID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[GE_ObtenerSiguienteID]
GO

CREATE PROCEDURE [dbo].[GE_ObtenerSiguienteID]
	-- Add the parameters for the stored procedure here
	@Tabla varchar(50),
	@CampoId varchar(50),
	@CampoKey varchar(50),
	@Key varchar(50)
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@CampoKey ='' )
		SET @CampoKey = NULL;
		
	
	DECLARE @sql NVARCHAR(3000)
	SET @sql = 
	'SELECT ISNULL((MAX('+@CampoId+')),0)+1 as sid FROM '+@Tabla+' ';

	IF(@CampoKey IS NOT NULL)
	BEGIN
		SET @sql = @sql +
		'WHERE ['+@CampoKey+'] = '''+@Key+''' ';
	END

	EXEC(@sql)
	
GO

/******************************************************************************
--SPS - Solum Portable System
******************************************************************************/
/****** Object:  StoredProcedure [dbo].[Sps_GoingOffline_Import_Tables]    Script Date: 03/25/2015 09:41:44 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sps_GoingOffline_Import_Tables]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Sps_GoingOffline_Import_Tables]
GO

CREATE PROCEDURE [dbo].[Sps_GoingOffline_Import_Tables]
(
	@SolumServerName varchar(200),
	@TableList nvarchar(MAX)
)
AS
Declare @TableName nvarchar(200),
		@ColumnName nvarchar(200),
		@ColumnNames nvarchar(4000),
		@SQL nvarchar(4000),
		@TableCount smallint,
		@ColumnCount smallint,
		@tint smallint,
		@cint smallint,
		@Autonumber smallint,
		@Index smallint,
        @Start smallint

SET		@tint = 1
SET		@cint = 1

--Table List:
CREATE TABLE #TableList (TableID int identity (1,1) PRIMARY KEY CLUSTERED NOT NULL, TableName varchar(200));
    -- Loop through source string and add elements to table 
    WHILE LEN(@TableList) > 0
    BEGIN
        SET @Index = CHARINDEX(',', @TableList)
        IF @Index = 0
            BEGIN
                INSERT INTO #TableList (TableName) VALUES (LTRIM(RTRIM(@TableList)))
                BREAK
            END
        ELSE
            BEGIN
                INSERT INTO #TableList (TableName) VALUES (LTRIM(RTRIM(SUBSTRING(@TableList, 1,@Index - 1))))
                SET @Start = @Index + 1
                SET @TableList = SUBSTRING(@TableList, @Start , LEN(@TableList) - @Start + 1)
            END
    END

SELECT @TableCount = COUNT(*) FROM #TableList;

--Link to Depot Server
EXEC sp_droplinkedsrvlogin @SolumServerName, null
EXEC sp_dropserver @SolumServerName, 'droplogins'
EXEC sp_addlinkedserver @server = @SolumServerName
EXEC sp_addlinkedsrvlogin @rmtsrvname = @SolumServerName, @useself = 'FALSE', @rmtuser = 'winsir', @rmtpassword = 'win.747' 

--Loop through all tables
WHILE @tint <= @TableCount
BEGIN
	
	SELECT @TableName = TableName FROM #TableList WHERE TableID = @tint
	PRINT @TableName -- This is for TESTING only
	CREATE TABLE #ColumnList (ColumnID int identity (1,1) PRIMARY KEY CLUSTERED NOT NULL, ColumnName varchar(200));
	INSERT INTO #ColumnList(ColumnName)	SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = @TableName
	SELECT @ColumnCount = COUNT(*) FROM #ColumnList
	
	-- Loop through columns to Get Column names 
	SELECT @ColumnNames = ColumnName FROM #ColumnList WHERE ColumnID = 1
	SET @cint = 2;
	While @cint <= @ColumnCount
	BEGIN
		SELECT @ColumnName = ColumnName FROM #ColumnList WHERE ColumnID = @cint 
		SET @ColumnNames = @ColumnNames + ', ' + @ColumnName
		SET @cint = @cint + 1;
	END;
	DROP Table #ColumnList;
	
	-- Build SQL
	SET @SQL = ''	
 	-- Does table have autonumber??
	Select @Autonumber = Count(*) from sys.identity_columns where object_name(object_id) = @TableName
	If @Autonumber > 0 SET @SQL = 'SET IDENTITY_INSERT [dbo].[' + @TableName + '] ON' + CHAR(13)+CHAR(10);
	SET @SQL = @SQL + 'INSERT INTO [dbo].[' + @TableName + '](' + @ColumnNames + ') SELECT ' + @ColumnNames + ' FROM [' + @SolumServerName + '].[Solum].[dbo].' + @TableName
	If @TableName = 'sol_Orders' SET @SQL = @SQL + ' WHERE CustomerID >0';
	If @TableName = 'sol_OrdersDetail' SET @SQL = @SQL + ' WHERE OrderID IN (SELECT OrderID FROM [dbo].[sol_Orders])';
	If @Autonumber > 0 SET @SQL = @SQL + CHAR(13)+CHAR(10) + 'SET IDENTITY_INSERT [dbo].[' + @TableName + '] OFF';
	EXEC(@SQL)    
	
	IF @ColumnNames IS NOT NULL
	INSERT INTO [dbo].[Sol_Settings] (Name, Description, SetValue) 
		Values(@TableName + '_ColumnNames','List of Columns in ' + @TableName + ' table.', @ColumnNames);

	SET @tint = @tint + 1;
END;
GO


/****** Object:  StoredProcedure [dbo].[Sps_GoingOffline_TrackDataForSync]    Script Date: 03/25/2015 09:41:44 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sps_GoingOffline_TrackDataForSync]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sps_GoingOffline_TrackDataForSync]
GO

CREATE PROCEDURE [dbo].[sps_GoingOffline_TrackDataForSync]
(
	@TableName nvarchar(200),
	@IDName nvarchar(200)
)
AS

DECLARE @SQL nvarchar(4000),
		@ColumnNames nvarchar(4000),
		@ColumnName nvarchar(200),
		@ColumnCount tinyint,
		@Index tinyint,
		@Start tinyint

SET @SQL = 'ALTER TABLE [dbo].[' + @TableName + ']'  + CHAR(13)+CHAR(10) +
	  '		ADD CreatedOffline Bit'  + CHAR(13)+CHAR(10) +
	  '	ALTER TABLE [dbo].[' + @TableName + ']'  + CHAR(13)+CHAR(10) +
	  '		ADD UpdatedOffline Bit'  + CHAR(13)+CHAR(10) +
	  '	ALTER TABLE [dbo].[' + @TableName + ']'  + CHAR(13)+CHAR(10) +
	  '		ADD ColumnUpdated nvarchar(4000)'  + CHAR(13)+CHAR(10) +
	  '	ALTER TABLE [dbo].[' + @TableName + ']'  + CHAR(13)+CHAR(10) +
	  '		ADD OnlineID Int'  + CHAR(13)+CHAR(10) +
	  '	ALTER TABLE [dbo].[' + @TableName + ']'  + CHAR(13)+CHAR(10) +
	  '		ADD DEFAULT 1 FOR CreatedOffline'  + CHAR(13)+CHAR(10)
EXEC(@SQL)
SET @SQL = '	UPDATE [dbo].[' + @TableName + '] SET OnlineID = ' + @IDName + ' WHERE ' + @IDName + ' > -1'
EXEC(@SQL)

SELECT @ColumnNames = CONVERT(nvarchar(4000), SetValue) FROM [dbo].[Sol_Settings] WHERE Name = @TableName + '_ColumnNames'
--Column List:
CREATE TABLE #ColumnList (ColumnID int identity (1,1) PRIMARY KEY CLUSTERED NOT NULL, ColumnName varchar(200));
    -- Loop through source string and add elements to table 
    WHILE LEN(@ColumnNames) > 0
    BEGIN
        SET @Index = CHARINDEX(',', @ColumnNames)
        IF @Index = 0
            BEGIN
                INSERT INTO #ColumnList (ColumnName) VALUES (LTRIM(RTRIM(@ColumnNames)))
                BREAK
            END
        ELSE
            BEGIN
                INSERT INTO #ColumnList (ColumnName) VALUES (LTRIM(RTRIM(SUBSTRING(@ColumnNames, 1,@Index - 1))))
                SET @Start = @Index + 1
                SET @ColumnNames = SUBSTRING(@ColumnNames, @Start , LEN(@ColumnNames) - @Start + 1)
            END
    END
SELECT @ColumnCount = COUNT(*) FROM #ColumnList;

-- Check if trigger exists
SET @SQL = 'IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N''[dbo].[trg_' + @TableName + '_AfterUpdate]))'  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + 'DROP TRIGGER [dbo].[trg_' + @TableName + '_AfterUpdate]'  + CHAR(13)+CHAR(10);
EXEC(@SQL)
-- Create trigger
SET @SQL = 'CREATE TRIGGER trg_' + @TableName + '_AfterUpdate ON [dbo].[' + @TableName + ']'  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + 'AFTER UPDATE '  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '	AS '  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '	IF NOT update(UpdatedOffline) '  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '	BEGIN'  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '		DECLARE @UpdatedColumns nvarchar(2000) = '''''  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '		SELECT @UpdatedColumns = ISNULL(ColumnUpdated,'''') FROM [dbo].[' + @TableName + '] WHERE ' + @IDName + ' in (SELECT ' + @IDName + ' FROM inserted) '  + CHAR(13)+CHAR(10);
--loop for each column
	SET @Index = 1;
	While @Index <= @ColumnCount
	BEGIN
		SELECT @ColumnName = ColumnName FROM #ColumnList WHERE ColumnID = @Index 
		SET @SQL = @SQL + '		IF update(' + @ColumnName + ') AND CHARINDEX(''' + @ColumnName + ''',@UpdatedColumns) = 0'  + CHAR(13)+CHAR(10);
		SET @SQL = @SQL + '			SET @UpdatedColumns = @UpdatedColumns + '',' + @ColumnName + ''';'  + CHAR(13)+CHAR(10);
		SET @Index = @Index + 1;
	END;
			
--finish up
SET @SQL = @SQL + '		IF LEFT (@UpdatedColumns, 1) = '','''  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '			SET @UpdatedColumns = SUBSTRING (@UpdatedColumns,2,LEN(@UpdatedColumns)-1)'  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '		Update [dbo].[' + @TableName + '] SET UpdatedOffline = 1, ColumnUpdated = @UpdatedColumns WHERE ' + @IDName + ' in (SELECT ' + @IDName + ' FROM inserted) '  + CHAR(13)+CHAR(10);
SET @SQL = @SQL + '	END'  + CHAR(13)+CHAR(10);
DROP Table #ColumnList;
EXEC(@SQL)

GO
