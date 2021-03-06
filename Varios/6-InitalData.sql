
/**********************************************************************/
/* 6-InitialData.sql                                                  */
/*                                                                    */
/* Copyright winsir, Inc. 2013                                        */
/* All Rights Reserved.                                               */
/**********************************************************************/

USE [Solum]
GO

IF (NOT EXISTS(SELECT LogTypeID FROM dbo.sac_LogType WHERE LogTypeID = 1))
BEGIN
	exec Sac_LogType_Insert 1, 'SuccessfullPayout'
	exec Sac_LogType_Insert 2, 'IncompletePayout'
	exec Sac_LogType_Insert 3, 'Error'
	exec Sac_LogType_Insert 4, 'AddFloat'
	exec Sac_LogType_Insert 5, 'OpenCash'
	exec Sac_LogType_Insert 6, 'CloseCash'
	exec Sac_LogType_Insert 7, 'OpenCustomerScreen'
	exec Sac_LogType_Insert 8, 'CloseCustomerScreen'
END


DECLARE @SetValue sql_variant
SET @SetValue = cast(1 as bit)
exec [dbo].[Sol_Settings_Insert] 'Attendance_Enabled', 'Enable Attendance', @SetValue
GO

DECLARE @Count int = 0
SELECT @Count = Count(*)
FROM [Vir_BagPosition]
WHERE [BagPositionID] = 1
if(@Count < 1) 
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
		1,
		'Empty',
		null,
		null,
		0,
		0
	)

--Vir_Conveyor
	INSERT INTO [Vir_Conveyor]
	(
		--[ConveyorID],
		[ConveyorDescription]
	)
	VALUES
	(
		'Conveyor 1'
	)

GO

--StagingMethod
	INSERT INTO [Vir_StagingMethod]
	(
		--[StagingMethodID],
		[StagingMethodName]
	)
	VALUES
	(
		'Standard Staging'
	)

	INSERT INTO [Vir_StagingMethod]
	(
		--[StagingMethodID],
		[StagingMethodName]
	)
	VALUES
	(
		'Multi-Product Staging'
	)
GO

--Sac_Settings
DECLARE @SetValue sql_variant

SET @SetValue = cast(0 as int)
exec [dbo].[Sac_Settings_Insert] 'CoinDispenserId', 'Bill Dispenser Id currently selected', @SetValue
SET @SetValue = cast(0 as int)
exec [dbo].[Sac_Settings_Insert] 'BillDispenserId', 'Bill Dispenser Id currently selected', @SetValue
--SET @SetValue = 'COM1'
--exec [dbo].[Sac_Settings_Insert] 'CDM1000_PortName', 'eZCDM1000ADV Port Name', @SetValue
--SET @SetValue = cast(4 as smallint)
--exec [dbo].[Sac_Settings_Insert] 'CDM1000_MaxCassete', 'eZCDM1000ADV Mex Cassetes', @SetValue
SET @SetValue = 'COM1'
exec [dbo].[Sac_Settings_Insert] 'F56_PortName', 'Fujitsi F56 Port Name', @SetValue
SET @SetValue = cast(4 as smallint)
exec [dbo].[Sac_Settings_Insert] 'F56_MaxCassete', 'Fujitsi F56 Mex Cassetes', @SetValue
SET	@SetValue = CAST(1 as bit)
EXEC [dbo].[Sac_Settings_Insert] 'EnableMoneyInventory', 'Keep track of Money Inventory', @SetValue
GO

--Qds_Settings
DECLARE @SetValue sql_variant
--initial data for Qds_Settings
--DECLARE @SetValue sql_variant
SET @SetValue = cast(0 as bit)
exec [dbo].[Qds_Settings_Insert] 'CardReader_Enabled', 'Use USB Card Reader', @SetValue
SET @SetValue = cast(1 as tinyint)
exec [dbo].[Qds_Settings_Insert] 'CardReader_EmulationMode', 'Emulation mode', @SetValue
SET @SetValue = cast(0x0801 as int)
exec [dbo].[Qds_Settings_Insert] 'CardReader_VID', 'Vendor Id', @SetValue
SET @SetValue = cast(0x0002 as int)
exec [dbo].[Qds_Settings_Insert] 'CardReader_PID', 'Product Id', @SetValue
--SET @SetValue = cast(0 as int)
--exec [dbo].[Qds_Settings_Insert] 'CardReader_LastChar', 'Last char sent by device in keyboard mode', @SetValue
SET @SetValue = cast(0x3B as int)
exec [dbo].[Qds_Settings_Insert] 'CardReader_CharSeparator', 'Last char sent by device in keyboard mode', @SetValue
SET @SetValue = cast(0 as char(1))
exec [dbo].[Qds_Settings_Insert] 'QuickDrop_DepotID', 'DepotID for Quick Drop System', @SetValue
GO

--Sol_Settings
DECLARE @SetValue sql_variant
SET @SetValue = cast(' ' as char)
exec [dbo].[Sol_Settings_Insert] 'SecurityCodeSeparator', 'Security Code Separator Char', @SetValue
SET @SetValue = cast(1 as int)
exec [dbo].[Sol_Settings_Insert] 'CategoryButtons_SnapToGridWidth', 'Width for Snap to Grid in CategoryButtons Tool.', @SetValue
SET @SetValue = cast(1 as int)
exec [dbo].[Sol_Settings_Insert] 'CategoryButtons_SnapToGridHeight', 'Height for Snap to Grid in CategoryButtons Tool.', @SetValue
SET @SetValue = cast(' ' as nvarchar(10))
exec [dbo].[Sol_Settings_Insert] 'Business_PostalCode', 'Business Postal Code', @SetValue
GO

--Qds_CardType
EXEC [dbo].[Qds_CardType_Insert] N'(None)'
EXEC [dbo].[Qds_CardType_Insert] N'QuickDrop Card'
EXEC [dbo].[Qds_CardType_Insert] N'Credit/Debit'
 
--Qds_PaymentMethod
EXEC [dbo].[Qds_PaymentMethod_Insert] N'(None)'
EXEC [dbo].[Qds_PaymentMethod_Insert] N'Mail Payment'
EXEC [dbo].[Qds_PaymentMethod_Insert] N'Cheque'
EXEC [dbo].[Qds_PaymentMethod_Insert] N'Cash'
EXEC [dbo].[Qds_PaymentMethod_Insert] N'Put On Account'
EXEC [dbo].[Qds_PaymentMethod_Insert] N'PayPal'

--Qds_PaymentMethodAvailableByDepot
EXEC [dbo].[Qds_PaymentMethodAvailableByDepot_Insert] N'0', 1, 0
EXEC [dbo].[Qds_PaymentMethodAvailableByDepot_Insert]  N'0', 3, 0

--initial data for Sol_Settings
DECLARE @SetValue sql_variant
SET @SetValue = cast(0 as bit)
exec [dbo].[Sol_Settings_Insert] 'CardReader_Enabled', 'Use USB Card Reader', @SetValue
SET @SetValue = cast(1 as bit)
exec [dbo].[Sol_Settings_Insert] 'CardReader_CloseOrder', 'Automatically close order', @SetValue
SET @SetValue = cast(1 as tinyint)
exec [dbo].[Sol_Settings_Insert] 'CardReader_LinkMethod', 'Order to card link method', @SetValue
SET @SetValue = cast(0 as tinyint)
exec [dbo].[Sol_Settings_Insert] 'CardReader_EmulationMode', 'Emulation mode', @SetValue
SET @SetValue = cast(0x0801 as int)
exec [dbo].[Sol_Settings_Insert] 'CardReader_VID', 'Vendor Id', @SetValue
SET @SetValue = cast(0x0002 as int)
exec [dbo].[Sol_Settings_Insert] 'CardReader_PID', 'Product Id', @SetValue
--SET @SetValue = cast(0 as int)
--exec [dbo].[Sol_Settings_Insert] 'CardReader_LastChar', 'Last char sent by device in keyboard mode', @SetValue
SET @SetValue = cast(0x3B as int)
exec [dbo].[Sol_Settings_Insert] 'CardReader_CharSeparator', 'Last char sent by device in keyboard mode', @SetValue
SET @SetValue = cast('1753-1-1 12:00:00' as DateTime)
exec [dbo].[Sol_Settings_Insert] 'Register_LastDate', 'Last date of registration/log.', @SetValue
GO


--initial data for the Sac_Money table
EXEC('
    exec [Sac_Money_Insert] ''Fifty Dollars'', 1, 50.00, ''CA'';
    exec [Sac_Money_Insert] ''Twenty Dollars'', 1, 20.00, ''CA'';
    exec [Sac_Money_Insert] ''Ten Dollars'', 1, 10.00, ''CA'';
    exec [Sac_Money_Insert] ''Five Dollars'', 1, 5.00, ''CA'';
    exec [Sac_Money_Insert] ''Toonie'', 0, 2.00, ''CA'';
    exec [Sac_Money_Insert] ''Loonie'', 0, 1.00, ''CA'';
    exec [Sac_Money_Insert] ''Quarter'', 0, 0.25, ''CA'';
    exec [Sac_Money_Insert] ''Dime'', 0, 0.10, ''CA'';
    exec [Sac_Money_Insert] ''Nickel'', 0, 0.05, ''CA'';
');
GO

--initial data for the WS tables
EXEC('
	exec [Sol_WS_Carriers_Insert] ''229'', ''J-6 Freightways Inc.''
	exec [Sol_WS_Carriers_Insert] ''231'', ''Barrhead Trucking, Div of Westlock Trans.''
	exec [Sol_WS_Carriers_Insert] ''234'', ''Boyle Transport''
	exec [Sol_WS_Carriers_Insert] ''238'', ''Devon Transport Ltd.''
	exec [Sol_WS_Carriers_Insert] ''239'', ''Drayton Valley Transport''
	exec [Sol_WS_Carriers_Insert] ''240'', ''Eastline Transfer Ltd.''
	exec [Sol_WS_Carriers_Insert] ''242'', ''Glendon Transport''
	exec [Sol_WS_Carriers_Insert] ''243'', ''Grimshaw Trucking''
	exec [Sol_WS_Carriers_Insert] ''244'', ''Hi Fab Holdings Ltd.''
	exec [Sol_WS_Carriers_Insert] ''245'', ''Hi Way ''''13'''' Transport''
	exec [Sol_WS_Carriers_Insert] ''246'', ''Hi Way 9 Express Ltd.''
	exec [Sol_WS_Carriers_Insert] ''247'', ''Hlewka''''s Transfer''

	exec [Sol_WS_Carriers_Insert] ''248'', ''Hythe Transfer Ltd.''
	exec [Sol_WS_Carriers_Insert] ''249'', ''Jenta Transport Ltd.''
	exec [Sol_WS_Carriers_Insert] ''251'', ''Lac La Biche Transport''
	exec [Sol_WS_Carriers_Insert] ''252'', ''La Crete Transport''
	exec [Sol_WS_Carriers_Insert] ''253'', ''Manitoulin Transport''
	exec [Sol_WS_Carriers_Insert] ''254'', ''Leduc Truck Service Ltd''
	exec [Sol_WS_Carriers_Insert] ''255'', ''Maiko''''s Trucking (1990) Ltd.''
	--exec [Sol_WS_Carriers_Insert] ''257'', ''Monarch Messenger''
	exec [Sol_WS_Carriers_Insert] ''258'', ''Morinville Express''
	exec [Sol_WS_Carriers_Insert] ''261'', ''Mike Rae''
	exec [Sol_WS_Carriers_Insert] ''262'', ''R.C.S. Cartage''
	exec [Sol_WS_Carriers_Insert] ''264'', ''Redi Recycle - Carrier''
	exec [Sol_WS_Carriers_Insert] ''266'', ''S.A.V.E Recycling''
	exec [Sol_WS_Carriers_Insert] ''267'', ''Stony Plain Transfer''
	exec [Sol_WS_Carriers_Insert] ''270'', ''Swan Hills Transport''
	exec [Sol_WS_Carriers_Insert] ''272'', ''Vilna Transport''
	exec [Sol_WS_Carriers_Insert] ''274'', ''Westwind Trucking Inc.''
	exec [Sol_WS_Carriers_Insert] ''275'', ''Whitecourt Transport''
	exec [Sol_WS_Carriers_Insert] ''277'', ''PLANT SELF CARRIER''
	exec [Sol_WS_Carriers_Insert] ''278'', ''Basic Transport''
	exec [Sol_WS_Carriers_Insert] ''280'', ''B & R Eckle''''s Transport''
	exec [Sol_WS_Carriers_Insert] ''281'', ''Turner Valley Carrier''
	exec [Sol_WS_Carriers_Insert] ''284'', ''Hi Way ''''4'''' Express''
	exec [Sol_WS_Carriers_Insert] ''287'', ''Bob''''s Bottle Return - Carrier''
	exec [Sol_WS_Carriers_Insert] ''288'', ''Sundre Container Depot - Carrier''
	exec [Sol_WS_Carriers_Insert] ''290'', ''Westlock Bottle Depot - Carrier''
	exec [Sol_WS_Carriers_Insert] ''292'', ''Cochrane Bottle Depot-CARRIER''
	exec [Sol_WS_Carriers_Insert] ''295'', ''Allans Transport (1999) Ltd.''
	exec [Sol_WS_Carriers_Insert] ''297'', ''Edson Truck Lines''
	exec [Sol_WS_Carriers_Insert] ''298'', ''Wolf Transport''
	exec [Sol_WS_Carriers_Insert] ''300'', ''Westlock Pony Express Ltd.''
	exec [Sol_WS_Carriers_Insert] ''307'', ''Depot pickup''
	exec [Sol_WS_Carriers_Insert] ''300000002'', ''Great Northern Transport''
	exec [Sol_WS_Carriers_Insert] ''300000003'', ''Day & Ross''
	exec [Sol_WS_Carriers_Insert] ''400000002'', ''Pedersen Transport Ltd''
	exec [Sol_WS_Carriers_Insert] ''400000010'', ''Strathmore Carrier''
	exec [Sol_WS_Carriers_Insert] ''400000014'', ''Afreight Traffic Systems''
	exec [Sol_WS_Carriers_Insert] ''400000015'', ''Bullet/Orlick Transport Company Inc.''
	exec [Sol_WS_Carriers_Insert] ''400000016'', ''Calgary Metal''
	exec [Sol_WS_Carriers_Insert] ''400000017'', ''General Recycling Industries Ltd.''
	exec [Sol_WS_Carriers_Insert] ''400000022'', ''Gibbons Bottle Depot--Carrier''
	exec [Sol_WS_Carriers_Insert] ''400000023'', ''Jaskreet Holdings Ltd.''
	exec [Sol_WS_Carriers_Insert] ''400000030'', ''Lynn''''s Foremost Transport''
	exec [Sol_WS_Carriers_Insert] ''400000043'', ''Quick Silver Transportation''
	exec [Sol_WS_Carriers_Insert] ''400000052'', ''Gleichen Standard Transport (1990)''
	exec [Sol_WS_Carriers_Insert] ''400000053'', ''Mayerthorpe Bottle Depot - CARRIER''
	exec [Sol_WS_Carriers_Insert] ''400000054'', ''Rosenau Transport''
	exec [Sol_WS_Carriers_Insert] ''400000061'', ''Coaldale Transport/Lethbridge Truck''
	exec [Sol_WS_Carriers_Insert] ''400000075'', ''Cochrane Transport''
	exec [Sol_WS_Carriers_Insert] ''400000080'', ''Super B Trucking''
	exec [Sol_WS_Carriers_Insert] ''400000081'', ''REEM''
	exec [Sol_WS_Carriers_Insert] ''400000082'', ''T & R''
	exec [Sol_WS_Carriers_Insert] ''400000083'', ''Waste Management''
	exec [Sol_WS_Carriers_Insert] ''400000084'', ''Executive Mat Calgary''
	exec [Sol_WS_Carriers_Insert] ''400000085'', ''Pepsi Carrier''
	exec [Sol_WS_Carriers_Insert] ''400000088'', ''Roberge''
	exec [Sol_WS_Carriers_Insert] ''400000089'', ''Pedersen Transport''
	exec [Sol_WS_Carriers_Insert] ''400000090'', ''Gar-Lyn Trucking''
	exec [Sol_WS_Carriers_Insert] ''400000092'', ''TBM Transport''
	exec [Sol_WS_Carriers_Insert] ''400000099'', ''Elite Choice Trucking''
	exec [Sol_WS_Carriers_Insert] ''400000102'', ''Fernie Cartage''
	exec [Sol_WS_Carriers_Insert] ''400000105'', ''T.M.C Distributors Ltd''
	exec [Sol_WS_Carriers_Insert] ''400000107'', ''Dolphin Transport''
	exec [Sol_WS_Carriers_Insert] ''400000109'', ''Steve Wowk''
	exec [Sol_WS_Carriers_Insert] ''400000110'', ''Baseline Transport Ltd''
	exec [Sol_WS_Carriers_Insert] ''400000113'', ''Coyote Courier Ltd''
	exec [Sol_WS_Carriers_Insert] ''400000138'', ''Beaver Grinding & Recycling Ltd''
	exec [Sol_WS_Carriers_Insert] ''400000143'', ''Brazel Construction''
	exec [Sol_WS_Carriers_Insert] ''400000477'', ''Steel Transfer''
	exec [Sol_WS_Carriers_Insert] ''400000711'', ''Merlin Carrier''
	exec [Sol_WS_Carriers_Insert] ''400000772'', ''Nu Plastics''
	exec [Sol_WS_Carriers_Insert] ''400000822'', ''BDL Calgary Carrier''
	exec [Sol_WS_Carriers_Insert] ''400000823'', ''BDL Edmonton Carrier''
	exec [Sol_WS_Carriers_Insert] ''400000827'', ''Celadon Trucking''
	exec [Sol_WS_Carriers_Insert] ''400000835'', ''Hub Group Canada''
	exec [Sol_WS_Carriers_Insert] ''400000838'', ''US Xpress''
	exec [Sol_WS_Carriers_Insert] ''500000087'', ''CN''
	exec [Sol_WS_Carriers_Insert] ''500000152'', ''Richaena Transport''
	exec [Sol_WS_Carriers_Insert] ''500000224'', ''MJ Smart Transport Ltd''
	exec [Sol_WS_Carriers_Insert] ''500000475'', ''Plus Fibre Transport''
	exec [Sol_WS_Carriers_Insert] ''500000571'', ''Barr West Express/ Triple Hitch Transport LTD''
	exec [Sol_WS_Carriers_Insert] ''510000139'', ''Cornerstone System''
	exec [Sol_WS_Carriers_Insert] ''510000191'', ''Mode Transportation''
	exec [Sol_WS_Carriers_Insert] ''510000193'', ''Lethbridge Truck Terminals Ltd.''
	exec [Sol_WS_Carriers_Insert] ''510000196'', ''Penner International''

	--NEW carrier IDs ADDED April 2015
	exec [Sol_WS_Carriers_Insert] ''223'', ''Westlock Bottle Depot''
	exec [Sol_WS_Carriers_Insert] ''233'', ''Bison Freightline''
	exec [Sol_WS_Carriers_Insert] ''235'', ''Buckler Transport Ltd.''
	exec [Sol_WS_Carriers_Insert] ''256'', ''Miller Trucking''
	exec [Sol_WS_Carriers_Insert] ''259'', ''Nanton Transport''
	exec [Sol_WS_Carriers_Insert] ''260'', ''Patrick''''s Transport''
    exec [Sol_WS_Carriers_Insert] ''265'', ''Reiger''''s Terminal''
	exec [Sol_WS_Carriers_Insert] ''269'', ''Sundre Transport''
	exec [Sol_WS_Carriers_Insert] ''271'', ''Thorhild Freightliners''
	exec [Sol_WS_Carriers_Insert] ''273'', ''Vulcan Transport Co. Ltd.''
	exec [Sol_WS_Carriers_Insert] ''286'', ''B.J''''s Bottle Pick Up''
	exec [Sol_WS_Carriers_Insert] ''289'', ''Warburg Bottle Depot - Carrier''
	exec [Sol_WS_Carriers_Insert] ''291'', ''Wheatland B/D - Carrier''
	exec [Sol_WS_Carriers_Insert] ''294'', ''Unknown Supplier Name 1''
	exec [Sol_WS_Carriers_Insert] ''400000013'', ''Consolidated Fee Payment Carrier''
	exec [Sol_WS_Carriers_Insert] ''400000031'', ''Clarke Transport''
	exec [Sol_WS_Carriers_Insert] ''400000048'', ''Vauxhaul Transport (1979) LTD''
	exec [Sol_WS_Carriers_Insert] ''400000098'', ''Hill Bros. Expressway Ltd.''
	exec [Sol_WS_Carriers_Insert] ''510000218'', ''BFI Canada - Carrier''
	exec [Sol_WS_Carriers_Insert] ''510000223'', ''Harlyn Transport''
	exec [Sol_WS_Carriers_Insert] ''510000228'', ''Capital Recycling Paper Ltd. - Carrier''
	exec [Sol_WS_Carriers_Insert] ''510000237'', ''Accord Transportation Ltd.''

	exec [Sol_WS_Carriers_Insert] 510000249, ''Caravan AB Inc''

');
GO

EXEC('
	exec [Sol_WS_Plants_Insert] ''3'', ''1-ABCRC-Calgary''
	exec [Sol_WS_Plants_Insert] ''4'', ''0-ABCRC-Edmonton''
	exec [Sol_WS_Plants_Insert] ''5'', ''RECYCLE PLUS - Grande Prairie - PLANT''
	exec [Sol_WS_Plants_Insert] ''6'', ''Redi Recycle - PLANT''
	exec [Sol_WS_Plants_Insert] ''7'', ''BFI Canada''
	exec [Sol_WS_Plants_Insert] ''8'', ''S.A.V.E''
	exec [Sol_WS_Plants_Insert] ''400000049'', ''OTHER Processing Plant''
	exec [Sol_WS_Plants_Insert] ''400000108'', ''Northwest Territories''
	exec [Sol_WS_Plants_Insert] ''500000208'', ''Lassonde Western Canada''
	exec [Sol_WS_Plants_Insert] ''500000398'', ''Executive Mat Edmonton''
	exec [Sol_WS_Plants_Insert] ''500000581'', ''SAVE Compaction''
');
GO

EXEC('
	exec [Sol_WS_ItemTypes_Insert] ''0000'', ''NA''
	exec [Sol_WS_ItemTypes_Insert] ''1006'', ''Aluminum 0 - 1 L''
	exec [Sol_WS_ItemTypes_Insert] ''1009'', ''Scrap Aluminum''
	exec [Sol_WS_ItemTypes_Insert] ''2003'', ''Bi-Metal Cans Over 1 Litre''
	exec [Sol_WS_ItemTypes_Insert] ''2006'', ''Bi Metal 0 - 1 L''
	exec [Sol_WS_ItemTypes_Insert] ''3003'', ''Glass Over 1 Litre''
	exec [Sol_WS_ItemTypes_Insert] ''3501'', ''Liq/Wine Ceramics''
	exec [Sol_WS_ItemTypes_Insert] ''4003'', ''PET Over 1 Litre(Clear & Light Blue Tint)''
	exec [Sol_WS_ItemTypes_Insert] ''4006'', ''PET 0 - 1 L(Clear & Light Blue Tint)''
	exec [Sol_WS_ItemTypes_Insert] ''4303'', ''HDPE Plastics Over 1 Litre (Natural)''
	exec [Sol_WS_ItemTypes_Insert] ''5006'', ''Tetra Brik 0 - 1 L''
	exec [Sol_WS_ItemTypes_Insert] ''6003'', ''Gable Top Over 1L''
	exec [Sol_WS_ItemTypes_Insert] ''6006'', ''Gable Top 0 -1 L''
	exec [Sol_WS_ItemTypes_Insert] ''7006'', ''Drink Pouch 0 - 1 L''
	exec [Sol_WS_ItemTypes_Insert] ''8001'', ''Bag in Box Over 1 L''
	exec [Sol_WS_ItemTypes_Insert] ''7008'', ''Aerosol 0 - 1 Litre''
	exec [Sol_WS_ItemTypes_Insert] ''5003'', ''Tetra Brik Over 1 Litre''
	exec [Sol_WS_ItemTypes_Insert] ''3006'', ''Glass 0-1 Litre''
	exec [Sol_WS_ItemTypes_Insert] ''9999'', ''CAPS''
	exec [Sol_WS_ItemTypes_Insert] ''4023'', ''KeyKeg Over 1 Litre''
	exec [Sol_WS_ItemTypes_Insert] ''4603'', ''Plastic Over 1 Litre (Other)''
	exec [Sol_WS_ItemTypes_Insert] ''4606'', ''Plastic Under 1 Litre (Other)''
');
GO

EXEC('
	exec [Sol_WS_ShippingContainerTypes_Insert] ''0'', ''Foreign''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''7'', ''Mega Bags''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''8'', ''Non ABCRC Pallet''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''9'', ''ABCRC Pallet''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''14'', ''G1-Coroplast''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''15'', ''G3- Coroplast''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''17'', ''Mega Bag GLASS''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''400000006'', ''BDL Pallet''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''500000080'', ''One Way Bag''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''500000423'', ''Collapsible Tote''
	exec [Sol_WS_ShippingContainerTypes_Insert] ''500000652'', ''Black Baffle Bags''
');
GO

EXEC('
	exec [Sol_WS_ErrorCodes_Insert] ''100'', ''RBill number is required'', ''0'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''101'', ''RBill number already exists'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''102'', ''RBill number must be 10 characters: four digits for the vendor code followed by a zero padded six digit number'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''103'', ''The first four digits of the RBill number do not match Vendor ID'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''200'', ''Depot ID is required'', ''0'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''201'', ''Depot ID not recognized'', ''0'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''202'', ''A supplier with the specified Depot ID exists, but has not been classified as a Depot'', ''1'', ''Depots don''''t send Depot ID, so may need to change wording in web service''
	exec [Sol_WS_ErrorCodes_Insert] ''203'', ''The specified Depot has been marked inactive'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''301'', ''Carrier ID not recognized'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''302'', ''A supplier with the specified Carrier ID exists, but has not been classified as a Carrier'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''303'', ''The specified Carrier has been marked inactive'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''304'', ''No Carrier Rates have been defined for the Depot/Carrier combination'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''400'', ''Plant ID is required'', ''0'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''401'', ''Plant ID not recognized'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''402'', ''A supplier with the specified Plant ID exists, but has not been classified as a Plant'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''403'', ''The specified Plant has been marked inactive'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''500'', ''Shipped Date is required'', ''0'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1001'', ''Item Type %s in Bag list not recognized'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1002'', ''Item Type %s in Bag list has been marked inactive'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1101'', ''Shipping Container Type %s in Bag list not recognized'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1102'', ''Shipping Container Type %s in Bag list has been marked inactive'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1201'', ''Tag Number %s in Bag list must be exactly than 20 characters'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1202'', ''Tag Number %s in Bag list already exists'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1203'', ''Tag Number %s occurs more than once in supplied Bag list'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1204'', ''The first for characters of Tag Number %s do not match Vendor ID'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1205'', ''Characters 5 to 8 of Tag Number %s do not match the item type specified for the bag'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1206'', ''Characters 9 to 13 of Tag Number %s do not match the unit count specified for the bag'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''1301'', ''Unit Count for Bag %s is less than zero'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''2001'', ''Shipping Container Type %s in Additional Shipping Container list not recognized'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''2002'', ''Shipping Container Type %s in Additional Shipping Container list has been marked inactive'', ''1'', ''''
	exec [Sol_WS_ErrorCodes_Insert] ''2101'', ''Shipping Container Count for SC ID %s in Additional Shipping Container list is less than zero'', ''1'', ''''
');
GO

--wsir_Reports
EXEC	[dbo].[wsir_Reportes_Agregar] N'QuickDropOrders.rpt', N'QuickDrop Orders Report', N'', 0
EXEC	[dbo].[wsir_Reportes_Agregar] N'StationReport.rpt', N'Station Report', N'', 0


--EXEC	[dbo].[wsir_Reportes_Agregar] N'CategoryRefundStatistics.rpt', N'Category Refund Statistics', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'ClerkReport.rpt', N'Clerk Report', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'CorporateAccountStatement.rpt', N'Customer Account Statement', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'DailyTotal.rpt', N'Financial Transaction Summary', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'Inventory.rpt', N'Inventory', N'', 0
---- EXEC	[dbo].[wsir_Reportes_Agregar] N'InventoryOnHandUnstaged.rpt', N'Inventory On Hand', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'InventoryStatus.rpt', N'Inventory Reconciliation', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'Orders1.rpt', N'Orders', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'PurchasedInventory.rpt', N'Purchased Inventory', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'PurchasingCategory.rpt', N'Purchasing Category', N'', 0
----EXEC	[dbo].[wsir_Reportes_Agregar] N'Refund.rpt', N'Refund', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'Shipment.rpt', N'Shipment Summary', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'ShipmentDetail.rpt', N'Shipment Detail', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'StagedContainers.rpt', N'Staged Containers', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'Staging.rpt', N'Staging', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'TimeClock.rpt', N'TimeClock', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'TransactionDuration.rpt', N'Order Duration', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'TransactionReport.rpt', N'Order Detail', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'TransactionSearch.rpt', N'Order Search', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'TransactionSummary.rpt', N'Order Summary', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'ShipmentValueCalculation.rpt', N'Shipment Value Calculation', N'', 0
--EXEC	[dbo].[wsir_Reportes_Agregar] N'CRISSummary.rpt', N'CRIS Summary', N'', 0

