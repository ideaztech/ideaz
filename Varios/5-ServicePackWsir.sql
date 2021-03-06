
/**********************************************************************/
/* 5-ServicePackWsir.sql                                                  */
/*                                                                    */
/* Copyright winsir, Inc. 2012                                        */
/* All Rights Reserved.                                               */
/**********************************************************************/

/********************************************
Update each time the wsir main database changes
*********************************************
private const decimal DatabaseVersion = 2.000m;
*********************************************/

USE [Solum]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DECLARE @version [decimal](18,3);
 
SELECT @version = [DatabaseVersion] FROM [sol_Control] WHERE [ControlID] = 1
/********************************************/
--check the goto statement in 3-ServicePack.sql
/********************************************/
IF @version < 2.027 GOTO Version_2027
IF @version < 2.028 GOTO Version_2028
IF @version < 2.029 GOTO Version_2029
IF @version < 2.030 GOTO Version_2030
IF @version < 2.031 GOTO Version_2031
IF @version < 2.036 GOTO Version_2036
IF @version < 2.039 GOTO Version_2039
IF @version < 2.041 GOTO Version_2041
IF @version < 2.043 GOTO Version_2043
IF @version < 2.053 GOTO Version_2053
IF @version < 2.103 GOTO Version_2103
--IF @version < 2.105 GOTO Version_2105
IF @version < 2.106 GOTO Version_2106

GOTO Version_Fin

Version_2027:
/*****************************************************************************
Less than version 2.027
******************************************************************************/
EXEC('
if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].[wsir_Permisos_Agregar]'') and OBJECTPROPERTY(id, N''IsProcedure'') = 1)
BEGIN
	--1.- List Of Permissions
	--POS
	exec [wsir_Permisos_Agregar] ''SolCreateChit'', ''Create and add items to chit'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolDeleteChit'', ''Delete and remove items to chit'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolLookupChit'', ''Find chit'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolOpenChit'', ''Edit a closed chit'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolCashOutOrder'', ''Cash out an order'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolUnpayOrder'', ''Unpay an order'', '''', 0

	--Shipping
	exec [wsir_Permisos_Agregar] ''SolShipping'', ''Access to shipping menus'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolCreateContainer'', ''Create staged container'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolModifyContainer'', ''Modify staged container'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolViewContainer'', ''View a created staged container'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolCreateShipment'', ''Create and modify shipment'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolViewShipment'', ''View old shipment'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolUnshipShipment'', ''Unship a R-Bill'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolLookupShipment'', ''Find shipment history'', '''', 0

	--Inventory
	exec [wsir_Permisos_Agregar] ''SolViewInventory'', ''View inventory'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolCreateAdjustment'', ''Create adjustment'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolPrintInventory'', ''Print out inventory sheet'', '''', 0

	--Accounting
	exec [wsir_Permisos_Agregar] ''SolOpenCashier'', ''Open Cashier'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolAddFloat'', ''Add Float'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolCloseCashier'', ''Close Cashier'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolAddExpenses'', ''Add Expenses'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolViewCustomer'', ''View customer accounts'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolEditCustomer'', ''Edit customer accounts'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolViewEntries'', ''View entries manager'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolEditEntries'', ''Edit any entries'', '''', 0

	--Reports
	--separate report system based on our discussion today

	--Catalogs
	--exec [wsir_Permisos_Agregar] ''SolAddCatalogues'', ''Add Catalogues'', '''', 0
	--exec [wsir_Permisos_Agregar] ''SolEditCatalogues'', ''Edit Catalogues'', '''', 0

	--Tools
	--exec [wsir_Permisos_Agregar] ''SolManageUsers'', ''Manage users'', '''', 0		--GeUsuariosABC
	--exec [wsir_Permisos_Agregar] ''SolManagerRoles'', ''Manager roles'', '''', 0		--GeGruposABC
	--exec [wsir_Permisos_Agregar] ''SolManageCompanies'', ''Manage companies'', '''', 0	--GeCambiarEmpresa
	--exec [wsir_Permisos_Agregar] ''SolBackupDatabase'', ''Backup database'', '''', 0	--GeRespaldar
	--exec [wsir_Permisos_Agregar] ''SolRestoreDatabase'', ''Restore database'', '''', 0	--GeRecuperar
	--exec [wsir_Permisos_Agregar] ''SolYearClose'', ''Year close'', '''', 0		--GeCierreAnual
	--exec [wsir_Permisos_Agregar] ''SolChangeSettings'', ''Change settings'', '''', 0	--SolCambiarOpciones
	exec [wsir_Permisos_Agregar] ''SolUpdateVersion'', ''Update Solum Version'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolViewHelp'', ''View help screens'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolViewHelp'', ''View help screens'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolUserEmail'', ''User receives email notifications'', '''', 0
END
');


Version_2028:
/*****************************************************************************
Less than version 2.028
******************************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wsir_PermisosEnRoles_Borrar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
EXEC('
	ALTER PROCEDURE [dbo].[wsir_PermisosEnRoles_Borrar]
		@PermisoNombre	nvarchar(256),
		@RoleName		nvarchar(256)
	AS 
		DECLARE @sql NVARCHAR(3000)
	
		DECLARE @PermisoId uniqueidentifier
		SELECT  @PermisoId = NULL
		DECLARE @RoleId uniqueidentifier
		SELECT  @RoleId = NULL

   		IF(@PermisoNombre = '''') SET @PermisoNombre = NULL 
		IF (@PermisoNombre IS NOT NULL)
		BEGIN
			SELECT  @PermisoId = PermisoId
			FROM    dbo.wsir_Permisos
			WHERE   PermisoNombreEnMinusculas = LOWER(@PermisoNombre)

			IF (@PermisoId IS NULL)
				RETURN(1)
		END

		SELECT  @RoleId = RoleId
		FROM    dbo.aspnet_Roles
		WHERE   LoweredRoleName = LOWER(@RoleName)

		IF (@RoleId IS NULL)
			RETURN(2)
        
		SET @sql = ''DELETE FROM wsir_PermisosEnRoles WITH (ROWLOCK) ''+
				   ''WHERE RoleId = '''''' +CAST(@RoleId  AS nvarchar(256))+ '''''' '';
      
		IF (@PermisoId IS NOT NULL)
			SET @sql = @sql + ''AND PermisoId = ''''''+CAST(@PermisoId  AS nvarchar(256))+ '''''' '';
	
		EXEC(@sql)
	
	RETURN(0)
');

Version_2029:
/*****************************************************************************
Less than version 2.029
******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[wsir_PermisosEnUsers_Borrar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
EXEC('
	ALTER PROCEDURE [dbo].[wsir_PermisosEnUsers_Borrar]
		@PermisoNombre	nvarchar(256),
		@UserName		nvarchar(256)
	AS 
		DECLARE @sql NVARCHAR(3000)
	
		DECLARE @PermisoId uniqueidentifier
		SELECT  @PermisoId = NULL
		DECLARE @UserId uniqueidentifier
		SELECT  @UserId = NULL
    
   		IF(@PermisoNombre = '''') SET @PermisoNombre = NULL 

		IF (@PermisoNombre IS NOT NULL)
		BEGIN
			SELECT  @PermisoId = PermisoId
			FROM    dbo.wsir_Permisos
			WHERE   PermisoNombreEnMinusculas = LOWER(@PermisoNombre)

			IF (@PermisoId IS NULL)
				RETURN(1)
		END

		SELECT  @UserId = UserId
		FROM    dbo.aspnet_Users
		WHERE   LoweredUserName = LOWER(@UserName)

		IF (@UserId IS NULL)
			RETURN(2)
        
		SET @sql = ''DELETE FROM wsir_PermisosEnUsers WITH (ROWLOCK) ''+
				   ''WHERE UserId = '''''' +CAST(@UserId  AS nvarchar(256))+ '''''' '';
      
		IF (@PermisoId IS NOT NULL)
			SET @sql = @sql + ''AND PermisoId = ''''''+CAST(@PermisoId  AS nvarchar(256))+ '''''' '';
	
		EXEC(@sql)
	RETURN(0)
');

/*********************************************************************************************/
/********** Object:  Table [dbo].[wsir_Reportes]    Script Date: 02/23/2010 17:48:50 *********/
/*********************************************************************************************/
EXEC('
CREATE TABLE [dbo].[wsir_Reportes](
	[ReporteId]		[uniqueidentifier] NOT NULL DEFAULT (newid()),
	[ReporteNombre] [nvarchar](256) NOT NULL,
	[ReporteNombreEnMinusculas] [nvarchar](256) NOT NULL,
	[Descripcion]	[nvarchar](256) NULL,
	[Modulo]		[nvarchar](10) NULL,
	[admin]			[bit]		NOT NULL,

PRIMARY KEY NONCLUSTERED 
(
	[ReporteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
');

/**********************/
/* COMMAND PROCEDURES */
/**********************/
/* agregar Reportes */
EXEC('
CREATE PROCEDURE [dbo].[wsir_Reportes_Agregar]
			/*@ReporteId				uniqueidentifier,*/
			@ReporteNombre			nvarchar(256),
			/*@ReporteNombreEnMinusculas nvarchar(256),*/
			@Descripcion			nvarchar(256),
			@Modulo					nvarchar(10),
			@admin					bit
AS 
	INSERT INTO 
		wsir_Reportes(
			[ReporteNombre],
			[ReporteNombreEnMinusculas],
			[Descripcion],
			[Modulo],
			[admin]
		) 
	VALUES
		(
			@ReporteNombre,
			LOWER(@ReporteNombre),
			@Descripcion,
			@Modulo,
			@admin
		)
RETURN
');

/* actualizar  */
EXEC('
CREATE PROCEDURE [dbo].[wsir_Reportes_Actualizar]
			@ReporteId				uniqueidentifier,
			@ReporteNombre			nvarchar(256),
			@Descripcion			nvarchar(256),
			@Modulo					nvarchar(10),
			@admin					bit
 AS 
	UPDATE wsir_Reportes WITH (ROWLOCK)
	SET 
			[ReporteNombre] = @ReporteNombre,
			[ReporteNombreEnMinusculas] = LOWER(@ReporteNombre),
			[Descripcion] = @Descripcion,
			[Modulo] = @Modulo,
			[admin] = @admin
	WHERE 
		([wsir_Reportes].[ReporteId] = @ReporteId)
RETURN
');

/* leer */
EXEC('
CREATE PROCEDURE [dbo].[wsir_Reportes_Leer]
			@ReporteId				uniqueidentifier
AS 
	SELECT * 
	FROM 
		wsir_Reportes 
	WHERE 
		([wsir_Reportes].[ReporteId] = @ReporteId)
RETURN
');

/* leer todo */
EXEC('
CREATE PROCEDURE [dbo].[wsir_Reportes_LeerRegistros]

AS 
	SELECT * 
	FROM wsir_Reportes

	ORDER BY 
		[wsir_Reportes].[ReporteNombre]
RETURN
');

/* borrar */
EXEC('
CREATE PROCEDURE [dbo].[wsir_Reportes_Borrar]
		@ReporteId				uniqueidentifier
AS 
	DELETE FROM wsir_Reportes WITH (ROWLOCK)
	WHERE
		([wsir_Reportes].[ReporteId] = @ReporteId)
RETURN
');

/* buscar */
EXEC('
CREATE PROCEDURE [dbo].[wsir_Reportes_Buscar]
			@ReporteNombreEnMinusculas	nvarchar(256)
AS 
	SELECT * 
	FROM 
		wsir_Reportes 
	WHERE 
		([wsir_Reportes].[ReporteNombreEnMinusculas] = @ReporteNombreEnMinusculas)
RETURN
');

/*********************************************************************************************/
/****** Object:  Table [dbo].[wsir_ReportesEnRoles]    Script Date: 02/22/2010 16:30:16 ******/
/*********************************************************************************************/
EXEC('
CREATE TABLE [dbo].[wsir_ReportesEnRoles](
	[ReporteId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReporteId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
');

EXEC('
ALTER TABLE [dbo].[wsir_ReportesEnRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
');

EXEC('
ALTER TABLE [dbo].[wsir_ReportesEnRoles]  WITH CHECK ADD FOREIGN KEY([ReporteId])
REFERENCES [dbo].[wsir_Reportes] ([ReporteId])
');

/**********************/
/* COMMAND PROCEDURES */
/**********************/
/* agregar Reportes */
EXEC('
CREATE PROCEDURE [dbo].[wsir_ReportesEnRoles_Agregar]
	@ReporteNombre	nvarchar(256),
	@RoleName		nvarchar(256)
AS 
    DECLARE @ReporteId uniqueidentifier
    SELECT  @ReporteId = NULL
    DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL

    SELECT  @ReporteId = ReporteId
    FROM    dbo.wsir_Reportes
    WHERE   ReporteNombreEnMinusculas = LOWER(@ReporteNombre)

    IF (@ReporteId IS NULL)
        RETURN(1)

    SELECT  @RoleId = RoleId
    FROM    dbo.aspnet_Roles
    WHERE   LoweredRoleName = LOWER(@RoleName)

    IF (@RoleId IS NULL)
        RETURN(2)


    IF (EXISTS( SELECT * FROM dbo.wsir_ReportesEnRoles WHERE  ReporteId = @ReporteId AND RoleId = @RoleId))
        RETURN(3)
          	
	INSERT INTO 
		wsir_ReportesEnRoles(
			ReporteId,
			RoleId
		) 
	VALUES(
			@ReporteId,
			@RoleId
		)
	
	RETURN(0)
');

/* Existe */
EXEC('
CREATE PROCEDURE [dbo].[wsir_ReportesEnRoles_Existe]
	@ReporteNombre	nvarchar(256),
	@RoleName		nvarchar(256)
AS 
	
    DECLARE @ReporteId uniqueidentifier
    SELECT  @ReporteId = NULL
    DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL

    SELECT  @ReporteId = ReporteId
    FROM    dbo.wsir_Reportes
    WHERE   ReporteNombreEnMinusculas = LOWER(@ReporteNombre)

    IF (@ReporteId IS NULL)
        RETURN(1)

    SELECT  @RoleId = RoleId
    FROM    dbo.aspnet_Roles
    WHERE   LoweredRoleName = LOWER(@RoleName)

    IF (@RoleId IS NULL)
        RETURN(2)

    IF (EXISTS( SELECT * FROM dbo.wsir_ReportesEnRoles WHERE  ReporteId = @ReporteId AND RoleId = @RoleId))
        RETURN(0)
    ELSE
        RETURN(3)
');


/* borrar */
EXEC('
CREATE PROCEDURE [dbo].[wsir_ReportesEnRoles_Borrar]
	@ReporteNombre	nvarchar(256),
	@RoleName		nvarchar(256)
AS 
	DECLARE @sql NVARCHAR(3000)
	
    DECLARE @ReporteId uniqueidentifier
    SELECT  @ReporteId = NULL
    DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL

   	IF(@ReporteNombre = '''') SET @ReporteNombre = NULL 
    IF (@ReporteNombre IS NOT NULL)
    BEGIN
		SELECT  @ReporteId = ReporteId
		FROM    dbo.wsir_Reportes
		WHERE   ReporteNombreEnMinusculas = LOWER(@ReporteNombre)

		IF (@ReporteId IS NULL)
			RETURN(1)
	END

    SELECT  @RoleId = RoleId
    FROM    dbo.aspnet_Roles
    WHERE   LoweredRoleName = LOWER(@RoleName)

    IF (@RoleId IS NULL)
        RETURN(2)
        
	SET @sql = ''DELETE FROM wsir_ReportesEnRoles WITH (ROWLOCK) ''+
			   ''WHERE RoleId = '''''' +CAST(@RoleId  AS nvarchar(256))+ '''''' '';
      
	IF (@ReporteId IS NOT NULL)
		SET @sql = @sql + ''AND ReporteId = ''''''+CAST(@ReporteId  AS nvarchar(256))+ '''''' '';
	
	EXEC(@sql)
	
	RETURN(0)
');

/*********************************************************************************************/
/****** Object:  Table [dbo].[wsir_ReportesEnUsers]    Script Date: 02/22/2010 16:30:16 ******/
/*********************************************************************************************/
EXEC('
CREATE TABLE [dbo].[wsir_ReportesEnUsers](
	[ReporteId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReporteId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
');

EXEC('
ALTER TABLE [dbo].[wsir_ReportesEnUsers]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
');

EXEC('
ALTER TABLE [dbo].[wsir_ReportesEnUsers]  WITH CHECK ADD FOREIGN KEY([ReporteId])
REFERENCES [dbo].[wsir_Reportes] ([ReporteId])
');

/**********************/
/* COMMAND PROCEDURES */
/**********************/
/* agregar Reportes */
EXEC('
CREATE PROCEDURE [dbo].[wsir_ReportesEnUsers_Agregar]
	@ReporteNombre	nvarchar(256),
	@UserName		nvarchar(256)
AS 
    DECLARE @ReporteId uniqueidentifier
    SELECT  @ReporteId = NULL
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT  @ReporteId = ReporteId
    FROM    dbo.wsir_Reportes
    WHERE   ReporteNombreEnMinusculas = LOWER(@ReporteNombre)

    IF (@ReporteId IS NULL)
        RETURN(1)

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName)

    IF (@UserId IS NULL)
        RETURN(2)


    IF (EXISTS( SELECT * FROM dbo.wsir_ReportesEnUsers WHERE  ReporteId = @ReporteId AND UserId = @UserId))
        RETURN(3)
          	
	INSERT INTO 
		wsir_ReportesEnUsers(
			ReporteId,
			UserId
		) 
	VALUES(
			@ReporteId,
			@UserId
		)
	
	RETURN(0)
');

/* Existe */
EXEC('
CREATE PROCEDURE [dbo].[wsir_ReportesEnUsers_Existe]
	@ReporteNombre	nvarchar(256),
	@UserName		nvarchar(256)
AS 
	
    DECLARE @ReporteId uniqueidentifier
    SELECT  @ReporteId = NULL
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT  @ReporteId = ReporteId
    FROM    dbo.wsir_Reportes
    WHERE   ReporteNombreEnMinusculas = LOWER(@ReporteNombre)

    IF (@ReporteId IS NULL)
        RETURN(1)

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName)

    IF (@UserId IS NULL)
        RETURN(2)

    IF (EXISTS( SELECT * FROM dbo.wsir_ReportesEnUsers WHERE  ReporteId = @ReporteId AND UserId = @UserId))
        RETURN(0)
    ELSE
        RETURN(3)
');


/* borrar */
EXEC('
CREATE PROCEDURE [dbo].[wsir_ReportesEnUsers_Borrar]
	@ReporteNombre	nvarchar(256),
	@UserName		nvarchar(256)
AS 
	
	DECLARE @sql NVARCHAR(3000)
	
    DECLARE @ReporteId uniqueidentifier
    SELECT  @ReporteId = NULL
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    
   	IF(@ReporteNombre = '''') SET @ReporteNombre = NULL 

    IF (@ReporteNombre IS NOT NULL)
    BEGIN
		SELECT  @ReporteId = ReporteId
		FROM    dbo.wsir_Reportes
		WHERE   ReporteNombreEnMinusculas = LOWER(@ReporteNombre)

		IF (@ReporteId IS NULL)
			RETURN(1)
    END

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName)

    IF (@UserId IS NULL)
        RETURN(2)
        
	SET @sql = ''DELETE FROM wsir_ReportesEnUsers WITH (ROWLOCK) ''+
			   ''WHERE UserId = '''''' +CAST(@UserId  AS nvarchar(256))+ '''''' '';
      
	IF (@ReporteId IS NOT NULL)
		SET @sql = @sql + ''AND ReporteId = ''''''+CAST(@ReporteId  AS nvarchar(256))+ '''''' '';
	
	EXEC(@sql)
			
	RETURN(0)
');

EXEC('
if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].[wsir_Reportes_Agregar]'') and OBJECTPROPERTY(id, N''IsProcedure'') = 1)
BEGIN
	exec [wsir_Reportes_Agregar] ''CategoryRefundStatistics.rpt'', ''Category Refund Statistics'', '''', 0
	exec [wsir_Reportes_Agregar] ''ClerkReport.rpt'', ''Clerk Report'', '''', 0
	exec [wsir_Reportes_Agregar] ''CorporateAccountStatement.rpt'', ''Corporate Account Statement'', '''', 0
	exec [wsir_Reportes_Agregar] ''DailyTotal.rpt'', ''Daily Total'', '''', 0
	exec [wsir_Reportes_Agregar] ''Inventory.rpt'', ''Inventory'', '''', 0
	exec [wsir_Reportes_Agregar] ''InventoryOnHandUnstaged.rpt'', ''Inventory On Hand'', '''', 0
	exec [wsir_Reportes_Agregar] ''Orders1.rpt'', ''Orders'', '''', 0
	exec [wsir_Reportes_Agregar] ''PurchasedInventory.rpt'', ''Purchased Inventory'', '''', 0
	exec [wsir_Reportes_Agregar] ''PurchasingCategory.rpt'', ''Purchasing Category'', '''', 0
	exec [wsir_Reportes_Agregar] ''Refund.rpt'', ''Refund'', '''', 0
	exec [wsir_Reportes_Agregar] ''Shipment.rpt'', ''Shipment'', '''', 0
	exec [wsir_Reportes_Agregar] ''StagedContainers.rpt'', ''Staged Containers'', '''', 0
	exec [wsir_Reportes_Agregar] ''Staging.rpt'', ''Staging'', '''', 0
	exec [wsir_Reportes_Agregar] ''TimeClock.rpt'', ''TimeClock'', '''', 0
	exec [wsir_Reportes_Agregar] ''TransactionDuration.rpt'', ''Order Duration'', '''', 0
	exec [wsir_Reportes_Agregar] ''TransactionReport.rpt'', ''Order Report'', '''', 0
	exec [wsir_Reportes_Agregar] ''TransactionSearch.rpt'', ''Order Search'', '''', 0
	exec [wsir_Reportes_Agregar] ''TransactionSummary.rpt'', ''Order Summary'', '''', 0

END
');

Version_2030:
/*****************************************************************************
Less than version 2.030
******************************************************************************/

EXEC('
	UPDATE wsir_Reportes WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Order Duration''
	WHERE 
		([wsir_Reportes].[ReporteNombreEnMinusculas] = ''transactionduration.rpt'')
');

EXEC('
	UPDATE wsir_Reportes WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Order Report''
	WHERE 
		([wsir_Reportes].[ReporteNombreEnMinusculas] = ''transactionreport.rpt'')
');

EXEC('
	UPDATE wsir_Reportes WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Order Search''
	WHERE 
		([wsir_Reportes].[ReporteNombreEnMinusculas] = ''transactionsearch.rpt'')
');

EXEC('
	UPDATE wsir_Reportes WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Order Summary''
	WHERE 
		([wsir_Reportes].[ReporteNombreEnMinusculas] = ''transactionsummary.rpt'')
');

EXEC('
	--Inventory
	exec [wsir_Permisos_Agregar] ''SolViewProducts'', ''View products'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolCreateProductAdjustment'', ''Create product adjustment'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolViewSupplies'', ''View supplies'', '''', 0
	exec [wsir_Permisos_Agregar] ''SolCreateSupplyAdjustment'', ''Create supply adjustment'', '''', 0
');

EXEC('
	exec wsir_PermisosEnRoles_Borrar ''SolViewInventory'', ''''
');	

EXEC('
	exec wsir_PermisosEnUsers_Borrar ''SolViewInventory'', ''''
');	
	
EXEC('
	DELETE FROM wsir_Permisos WITH (ROWLOCK)
	WHERE
		PermisoNombreEnMinusculas = LOWER(''SolViewInventory'') 
');

EXEC('
	exec wsir_PermisosEnRoles_Borrar ''SolCreateAdjustment'', ''''
');	
	
EXEC('
	exec wsir_PermisosEnUsers_Borrar ''SolCreateAdjustment'', ''''
');	

EXEC('
	DELETE FROM wsir_Permisos WITH (ROWLOCK)
	WHERE
		PermisoNombreEnMinusculas = LOWER(''SolCreateAdjustment'') 
');


Version_2031:
/*****************************************************************************
Less than version 2.031
******************************************************************************/

EXEC('
	UPDATE wsir_Reportes WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Customer Account Statement''
	WHERE 
		([wsir_Reportes].[ReporteNombreEnMinusculas] = LOWER(''CorporateAccountStatement.rpt''))
');


Version_2036:
/*****************************************************************************
Less than version 2.036
******************************************************************************/

EXEC('
	UPDATE wsir_Permisos WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Find chit''
	WHERE 
		([wsir_Permisos].[PermisoNombre] = ''SolLookupChit'')
');

EXEC('
	UPDATE wsir_Permisos WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Find shipment history''
	WHERE 
		([wsir_Permisos].[PermisoNombre] = ''SolLookupShipment'')
');


Version_2039:
/*****************************************************************************
Less than version 2.039
******************************************************************************/

EXEC('
	UPDATE wsir_Reportes WITH (ROWLOCK)
	SET 
			[Descripcion] = ''Financial Transaction Summary''
	WHERE 
		([wsir_Reportes].[ReporteNombreEnMinusculas] = LOWER(''DailyTotal.rpt''))
');

Version_2041:
/*****************************************************************************
Less than version 2.041
******************************************************************************/
EXEC('
	--Tools
	exec [wsir_Permisos_Agregar] ''SolUseTraining'', ''Can use Training Mode'', '''', 0
');


Version_2043:
/*****************************************************************************
Less than version 2.043
******************************************************************************/
EXEC('
	exec [wsir_Reportes_Agregar] ''InventoryStatus.rpt'', ''Inventory Status'', '''', 0
');

Version_2053:
/*****************************************************************************
Less than version 2.053
******************************************************************************/
EXEC('
CREATE TABLE [dbo].[wsir_LogError](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[host] [nvarchar](150) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[type] [nvarchar](50) NULL,
	[source] [nvarchar](50) NULL,
	[message] [nvarchar](max) NULL,
	[stacktrace] [nvarchar](max) NULL,
	[screenshot] [image] NULL,
 CONSTRAINT [PK_wsir_LogError] PRIMARY KEY CLUSTERED
(
	[Id] ASC,
	[host] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
');

EXEC('
ALTER TABLE [dbo].[wsir_LogError] ADD  CONSTRAINT [DF_wsir_LogError_time_stamp]  DEFAULT (getdate()) FOR [timestamp]
');

EXEC('
CREATE PROCEDURE [dbo].[wsir_LogError_Insert]
(
	@host nvarchar(150),
	@timestamp datetime,
	@type nvarchar(50),
	@source nvarchar(50),
	@message nvarchar(max),
	@stacktrace nvarchar(max),
	@screenshot image
)

AS

SET NOCOUNT ON

INSERT INTO [wsir_LogError]
(
	[host],
	[timestamp],
	[type],
	[source],
	[message],
	[stacktrace],
	[screenshot]
)
VALUES
(
	@host,
	@timestamp,
	@type,
	@source,
	@message,
	@stacktrace,
	@screenshot
)

SELECT CAST(scope_identity() AS int)
');

EXEC('
CREATE PROCEDURE [dbo].[wsir_LogError_Update]
(
	@Id int,
	@host nvarchar(150),
	@timestamp datetime,
	@type nvarchar(50),
	@source nvarchar(50),
	@message nvarchar(max),
	@stacktrace nvarchar(max),
	@screenshot image
)

AS

SET NOCOUNT ON

UPDATE [wsir_LogError] WITH (ROWLOCK)
SET [timestamp] = @timestamp,
	[type] = @type,
	[source] = @source,
	[message] = @message,
	[stacktrace] = @stacktrace,
	[screenshot] = @screenshot
WHERE [Id] = @Id	AND [host] = @host
');

EXEC('
CREATE PROCEDURE [dbo].[wsir_LogError_Delete]
(
	@Id int,
	@host nvarchar(150)
)

AS

SET NOCOUNT ON

DELETE FROM [wsir_LogError] WITH (ROWLOCK)
WHERE [Id] = @Id
	AND [host] = @host
');

EXEC('
CREATE PROCEDURE [dbo].[wsir_LogError_Select]
(
	@Id int,
	@host nvarchar(150)
)

AS

SET NOCOUNT ON

SELECT [Id],
	[host],
	[timestamp],
	[type],
	[source],
	[message],
	[stacktrace],
	[screenshot]
FROM [wsir_LogError]
WHERE [Id] = @Id
	AND [host] = @host
');

EXEC('
CREATE PROCEDURE [dbo].[wsir_LogError_SelectAll]
(
	@host nvarchar(150)
)

AS

SET NOCOUNT ON

SELECT [Id],
	[host],
	[timestamp],
	[type],
	[source],
	[message],
	[stacktrace],
	[screenshot]
FROM [wsir_LogError]
WHERE [host] = @host
');

EXEC('
CREATE PROCEDURE [dbo].[wsir_LogError_DeleteAll]
(
	@host nvarchar(150)
)

AS

SET NOCOUNT ON

DELETE FROM [wsir_LogError] WITH (ROWLOCK)
WHERE [host] = @host

');

Version_2103:
/*****************************************************************************
Less than version 2103
******************************************************************************/

EXEC('
DECLARE @PermisoNombre nvarchar(256)
SET @PermisoNombre = ''SolPutOnAccountButton''

EXEC	[dbo].[wsir_Permisos_Agregar] @PermisoNombre, N''Put OnAccount an order'', '''', 0

DECLARE @PermisoId uniqueidentifier
SELECT @PermisoId = [PermisoId]
FROM 
	wsir_Permisos 
WHERE 
	([wsir_Permisos].[PermisoNombreEnMinusculas] = LOWER(@PermisoNombre))

INSERT INTO wsir_PermisosEnRoles(
	PermisoId,
	RoleId
	) 
SELECT 
	@PermisoId, 
	RoleId
FROM aspnet_Roles
WHERE --wsir_PermisosEnRoles.[PermisoId] <> @PermisoId AND
	aspnet_Roles.[LoweredRoleName] <> ''admin''

');

Version_2106:
/*****************************************************************************
Less than version 2106
******************************************************************************/

EXEC('
--POS
exec [wsir_Permisos_Agregar] ''SolVoidOrder'', ''Void an order'', '''', 0
--Shipping
exec [wsir_Permisos_Agregar] ''SolAdjustShipment'', ''Adjust a shipment'', '''', 0
exec [wsir_Permisos_Agregar] ''SolVoidShipment'', ''Void a shipment'', '''', 0
exec [wsir_Permisos_Agregar] ''SolVoidStaged'', ''Void staged item'', '''', 0
');


Version_Fin:
/******************************************************************************/
--SELECT 'Version Fin'
/******************************************************************************/
