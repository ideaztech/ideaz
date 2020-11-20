
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Sql;
using System.Data.SqlClient;

using SirLib;

namespace Solum.Forms.Modes
{
    public partial class Modes : Form
    {
        #region AlertForm

        AlertForm alert;
        // ProgressBar
        int //progressBarMinimum = 1,
            progressBarMaximum = 100,
            progressBarValue = 1,
            progressBarStep = 10;

        #endregion

        string strMode = string.Empty;

        bool changeModeSuccessfully = false;
        SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();

        public bool CancelFlag { get; set; }


        public Modes()
        {
            InitializeComponent();
        }

        private void Modes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCashTraysLookup.sol_CashTrays' table. You can move, or remove it, as needed.

            CheckForIllegalCrossThreadCalls = false;

            try
            {
                this.sol_CashTraysTableAdapter.Fill(this.dataSetCashTraysLookup.sol_CashTrays);
            }
            catch { }

            foreach (Main.ModesAvailables m in Enum.GetValues(typeof(Main.ModesAvailables)))
            {
                listBoxModesAvailables.Items.Add(m);
            }

            if(Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName)
                toolStripLabelCurrentMode.Text = Main.ModesAvailables.OFF_LINE.ToString();
            else
                toolStripLabelCurrentMode.Text = Main.ModesAvailables.DEPOT.ToString();


            //this.sol_CashTraysTableAdapter.Fill(this.dataSetCashTraysLookup.sol_CashTrays);

            if (Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName)
                listBoxModesAvailables.SelectedIndex = listBoxModesAvailables.FindString(Main.ModesAvailables.DEPOT.ToString());
            else
                listBoxModesAvailables.SelectedIndex = listBoxModesAvailables.FindString(Main.ModesAvailables.OFF_LINE.ToString());

        }

        private void buttonSynchronize_Click(object sender, EventArgs e)
        {

        }

        private void buttonChangeMode_Click(object sender, EventArgs e)
        {

            if (listBoxModesAvailables.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Mode!");
                listBoxModesAvailables.Focus();
                return;
            }

            if ((listBoxModesAvailables.SelectedIndex == 0
                && Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.BaseDeDatosPrincipal)
                || (listBoxModesAvailables.SelectedIndex == 1
                && Properties.Settings.Default.SQLBaseDeDatos == Properties.Settings.Default.ModesLocalDbDatabaseName))
            {
                MessageBox.Show("You are already in this mode!");
                listBoxModesAvailables.Focus();
                return;
            }

            buttonChangeMode.Enabled = false;
            buttonExit.Enabled = false;

            strMode = listBoxModesAvailables.Text;

            // Barra de progreso
            //progressBar1.Minimum = 1;
            //progressBar1.Maximum = 100;
            //progressBar1.Value = 1;
            //progressBar1.Step = 10;

            //start backgorund worker
            if (backgroundWorker1.IsBusy != true)
            {
                // create a new instance of the alert form
                alert = new AlertForm();
                alert.FormTitle = "Syncrhonizing...";
                alert.ProgressMinimum = 1;
                alert.ProgressMaximum = 100;
                alert.ProgressStep = 10;

                // event handler for the Cancel button in AlertForm
                alert.Canceled += new EventHandler<EventArgs>(cancelAsyncButton_Click);
                alert.EnableCancel = false;
                alert.Show();
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxModesAvailables_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCashTray.Enabled = false;
            panelCashTrayRadioButtons.Enabled = false;
            buttonSynchronize.Enabled = false;
            switch (listBoxModesAvailables.Text)
            {
                case "OFF_LINE":
                    panelCashTray.Enabled = true;
                    panelCashTrayRadioButtons.Enabled = true;
                    buttonSynchronize.Enabled = true;
                    break;
                default:
                    break;
            }

        }

        private bool OfflineMode(BackgroundWorker worker, DoWorkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //progressBarValue = 2;
            //for (int i = progressBarValue; i <= 10; i++)
            //{
            //    if (worker.CancellationPending == true)
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    else
            //    {
            //        // Perform a time consuming operation and report progress.
            //        alert.Message = string.Format("Step {0}", i);
            //        worker.ReportProgress(i * 10);
            //        System.Threading.Thread.Sleep(500);
            //    }
            //}
            //this.Cursor = Cursors.Default;
            //return true;

            int pasos = 15;
            progressBarValue = 1;
            progressBarStep = progressBarMaximum / pasos;

            //"Server=(LocalDB)\MSSQLLocalDB; Integrated Security=true ;AttachDbFileName=D:\Data\MyDB1.mdf".
            var localConnBuilder = new SqlConnectionStringBuilder();
            localConnBuilder.DataSource = Properties.Settings.Default.ModesLocalDbServerName;
            localConnBuilder.IntegratedSecurity = true;
            localConnBuilder.InitialCatalog = "master"; 
            localConnBuilder.ConnectTimeout = 30;

            string strConnectionString = localConnBuilder.ConnectionString;

            bool flagError = false;

            //progressBar1.PerformStep();
            //labelResult.Text = "Connecting to Local Server...";
            if(!UpdateProgress(worker, e, "Connecting to Local Server...", progressBarValue++))
                return false;

            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    //exist server?
                    try
                    {
                        connection.Open();

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Error connecting to LocalDB Server: " + ex.Message);
                        return false;

                    }

                    //exist database?
                    try
                    {
                        command.CommandText = "USE [" + Properties.Settings.Default.ModesLocalDbDatabaseName + "]";
                        command.ExecuteNonQuery();

                    }
                    catch
                    {
                        flagError = true;
                    }

                    strConnectionString = strConnectionString.Replace("master", Properties.Settings.Default.ModesLocalDbDatabaseName);

                    //exist database tables?
                    //progressBar1.PerformStep();
                    //labelResult.Text = "Checking Schema...";
                    if (!UpdateProgress(worker, e, "Checking Schema...", progressBarValue++))
                        return false;

                    if (!flagError)
                    {
                        try
                        {
                            command.CommandText = "SELECT COUNT(*) FROM Sol_Control ";
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // Call Read before accessing data.
                                reader.Read();
                                int nr = reader.GetInt32(0);
                                //if (nr > 0)
                                //    flagError = false;

                            }

                        }
                        catch
                        {
                            flagError = true;
                        }
                    }

                    //backup and clean database
                    //progressBar1.PerformStep();
                    //labelResult.Text = "Backup Database...";
                    if (!UpdateProgress(worker, e, "Backup Database...", progressBarValue++))
                        return false;
                    if (!flagError)
                    {
                        //backup database
                        //In C:\Backups\Solum_Offline2015 03 20 1015.bak
                        //(Includes year, month, day, hour, minute in name)
                        string backupFileName = string.Empty;
                        if (string.IsNullOrEmpty(Properties.Settings.Default.ModesBackupsFolder))
                            backupFileName = Main.myDocuments + @"\" + Properties.Settings.Default.ModesLocalDbDatabaseName;
                        else
                            if (Properties.Settings.Default.ModesBackupsFolder.EndsWith(@"\"))
                                backupFileName = Properties.Settings.Default.ModesBackupsFolder + Properties.Settings.Default.ModesLocalDbDatabaseName;
                            else
                                backupFileName = Properties.Settings.Default.ModesBackupsFolder + @"\" + Properties.Settings.Default.ModesLocalDbDatabaseName;

                        backupFileName = string.Format("{0}{1}{2,2:0#}{3,2:0#}{4,2:0#}{5,2:0#}.bak",
                            backupFileName.Replace(".mdf", "")
                            , Main.rc.FechaActual.Year
                            , Main.rc.FechaActual.Month
                            , Main.rc.FechaActual.Day
                            , Main.rc.FechaActual.Hour
                            , Main.rc.FechaActual.Minute);

                        SirLib.Respaldar f1 = new SirLib.Respaldar(
                            Properties.Settings.Default.ModesLocalDbServerName,   //Properties.Settings.Default.SQLServidorNombre,
                            Properties.Settings.Default.ModesLocalDbDatabaseName,   //Properties.Settings.Default.ModesLocalDbDatabaseName, //Properties.Settings.Default.SQLBaseDeDatos,
                            0,              //Properties.Settings.Default.SQLAutentificacion,
                            string.Empty,   //Properties.Settings.Default.SQLUsuarioNombre,
                            string.Empty,   //Properties.Settings.Default.SQLUsuarioClave,
                            strConnectionString,
                            Properties.Settings.Default.TouchOriented,
                            string.Empty   //"Sol_Control"
                            );
                        f1.backupFileName = backupFileName;
                        f1.ShowDialog();
                        f1.Dispose();
                        f1 = null;

                        //delete data
                        //this script cleans all views, SPS, functions PKs, FKs and tables.
                        //progressBar1.PerformStep();
                        //labelResult.Text = "Clean Up Database...";
                        if (!UpdateProgress(worker, e, "Clean Up Database...", progressBarValue++))
                            return false;
                        try
                        {
                            command.CommandText = @"
                                /* Drop all non-system stored procs */
                                DECLARE @name VARCHAR(128)
                                DECLARE @SQL VARCHAR(254)
    
                                SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'P' AND category = 0 ORDER BY [name])
    
                                WHILE @name is not null
                                BEGIN
                                    SELECT @SQL = 'DROP PROCEDURE [dbo].[' + RTRIM(@name) +']'
                                    EXEC (@SQL)
                                    --PRINT 'Dropped Procedure: ' + @name
                                    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'P' AND category = 0 AND [name] > @name ORDER BY [name])
                                END
                                --GO

                                /* Drop all views */
                                SET @name = ''
                                SET @SQL = ''
    
                                SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'V' AND category = 0 ORDER BY [name])
    
                                WHILE @name IS NOT NULL
                                BEGIN
                                    SELECT @SQL = 'DROP VIEW [dbo].[' + RTRIM(@name) +']'
                                    EXEC (@SQL)
                                    --PRINT 'Dropped View: ' + @name
                                    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'V' AND category = 0 AND [name] > @name ORDER BY [name])
                                END
                                --GO

                                /* Drop all functions */
                                SET @name = ''
                                SET @SQL = ''
    
                                SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0 ORDER BY [name])
    
                                WHILE @name IS NOT NULL
                                BEGIN
                                    SELECT @SQL = 'DROP FUNCTION [dbo].[' + RTRIM(@name) +']'
                                    EXEC (@SQL)
                                    --PRINT 'Dropped Function: ' + @name
                                    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] IN (N'FN', N'IF', N'TF', N'FS', N'FT') AND category = 0 AND [name] > @name ORDER BY [name])
                                END
                                --GO

                                /* Drop all Foreign Key constraints */
                                SET @name = ''
                                SET @SQL = ''
                                DECLARE @constraint VARCHAR(254)
    
                                SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)
    
                                WHILE @name is not null
                                BEGIN
                                    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
                                    WHILE @constraint IS NOT NULL
                                    BEGIN
                                        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint) +']'
                                        EXEC (@SQL)
                                        --PRINT 'Dropped FK Constraint: ' + @constraint + ' on ' + @name
                                        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
                                    END
                                SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)
                                END
                                --GO

                                /* Drop all Primary Key constraints */
                                SET @name = ''
                                SET @SQL = ''
                                SET @constraint = ''
    
                                SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)
    
                                WHILE @name IS NOT NULL
                                BEGIN
                                    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
                                    WHILE @constraint is not null
                                    BEGIN
                                        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint)+']'
                                        EXEC (@SQL)
                                        --PRINT 'Dropped PK Constraint: ' + @constraint + ' on ' + @name
                                        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
                                    END
                                SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)
                                END
                                --GO

                                /* Drop all tables */
                                SET @name = ''
                                SET @SQL = ''
    
                                SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 ORDER BY [name])
    
                                WHILE @name IS NOT NULL
                                BEGIN
                                    SELECT @SQL = 'DROP TABLE [dbo].[' + RTRIM(@name) +']'
                                    EXEC (@SQL)
                                    --PRINT 'Dropped Table: ' + @name
                                    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 AND [name] > @name ORDER BY [name])
                                END
                                --GO
                            ";
                            command.ExecuteNonQuery();
                            flagError = true;   //to force recreation of database
                        }
                        catch (Exception ex)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Error deleting objects from Offline database: " + ex.Message);
                            return false;

                        }

                    }

                    //recreate database
                    //progressBar1.PerformStep();
                    //labelResult.Text = "Recreating Database...";
                    if (!UpdateProgress(worker, e, "Recreate Database...", progressBarValue++))
                        return false;

                    if (flagError)
                    {
                        CrearWsir.flagSolumOfflineMode = true;
                        if (!CrearWsir.CrearTablasWsir(
                            connection
                            , command
                            , string.Empty
                            , strConnectionString
                            , null  //progressBar1
                            , Properties.Settings.Default.ModesLocalDbDatabaseName  //string.Empty
                            ))
                        {
                            this.Cursor = Cursors.Default;
                            //it gives a message error inside the function if any
                            //MessageBox.Show("Error creating Solum objects in Offline database, please review connections and try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                        //create tables
                        //progressBar1.PerformStep();
                        //labelResult.Text = "Creating Tables...";
                        if (!UpdateProgress(worker, e, "Create Tables...", progressBarValue++))
                            return false;
                        string script1 = Properties.Resources._1_CrearTablas.Replace("USE [Solum]", "USE [" + Properties.Settings.Default.ModesLocalDbDatabaseName + "]");
                        script1 = script1.Replace("FOREIGN KEY REFERENCES dbo.aspnet_Users(UserId)", "");
                        //script1 = script1.Replace("GO", "");
                        if (!SirLib.Empresas.CrearTablas(
                            connection,
                            command,
                            Main.DatabaseVersion.ToString(),
                            script1, //Properties.Resources._1_CrearTablas.Replace("USE [Solum]", ""),
                            Properties.Resources._2_CrearStoredProcedures.Replace("USE [Solum]", "USE [" + Properties.Settings.Default.ModesLocalDbDatabaseName + "]"),
                            null, //Properties.Resources._4_CrearTrainingData.Replace("USE [Solum]", ""),
                            null
                            ))
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Error creating Solum objects in Offline database, please review connections and try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        flagError = false;
                    }

                    //import data to Solum_Offline
                    try
                    {
                        //connection2.Open();
                        //Membership Tables
                        //string tableList = "aspnet_Applications,aspnet_Users,aspnet_Membership,aspnet_Paths,aspnet_PersonalizationAllUsers,aspnet_PersonalizationPerUser,aspnet_Profile,aspnet_Roles,aspnet_SchemaVersions,aspnet_UsersInRoles,aspnet_WebEvent_Events,wsir_LogError,wsir_Permisos,wsir_PermisosEnRoles,wsir_PermisosEnUsers,wsir_Reportes,wsir_ReportesEnRoles,wsir_ReportesEnUsers";   //,wsir_Versiones";
                        //, aspnet_SchemaVersions
                        string tableList = "aspnet_Applications, aspnet_Users, aspnet_Membership, aspnet_Paths, aspnet_PersonalizationAllUsers, aspnet_PersonalizationPerUser, aspnet_Profile, aspnet_Roles, aspnet_UsersInRoles, aspnet_WebEvent_Events, wsir_LogError, wsir_Permisos, wsir_PermisosEnRoles, wsir_PermisosEnUsers, wsir_Reportes, wsir_ReportesEnRoles, wsir_ReportesEnUsers";  //,wsir_Versiones";
                        //progressBar1.PerformStep();
                        //labelResult.Text = "Importing Membership Information...";
                        if (!UpdateProgress(worker, e, "Importing Membership Information...", progressBarValue++))
                            return false;

                        command.CommandText = "sps_GoingOffline_Import_Tables";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@SolumServerName", Properties.Settings.Default.SQLServidorNombre));
                        command.Parameters.Add(new SqlParameter("@TableList", tableList));
                        command.ExecuteScalar();

                        //Settings Tables
                        //progressBar1.PerformStep();
                        //labelResult.Text = "Importing Setting Information...";
                        if (!UpdateProgress(worker, e, "Importing Setting Information...", progressBarValue++))
                            return false;
                        tableList = "Sol_ExpensesTypes, sol_CashDenominations, sol_CashTrays, sol_WorkStations, sol_Categories, sol_CategoryButtons, sol_QuantityButtons, sol_Control, sol_Settings, sol_Fees, Qds_CardType, Qds_Settings";
                        command.Parameters["@TableList"].Value = tableList;
                        command.ExecuteScalar();

                        //Customer Tables
                        //progressBar1.PerformStep();
                        //labelResult.Text = "Importing Customer Information...";
                        if (!UpdateProgress(worker, e, "Importing Customer Information...", progressBarValue++))
                            return false;
                        tableList = @"sol_Customers";
                        command.Parameters["@TableList"].Value = tableList;
                        command.ExecuteScalar();

                        //Order Tables
                        //progressBar1.PerformStep();
                        //labelResult.Text = "Importing Orders...";
                        if (!UpdateProgress(worker, e, "Importing Orders...", progressBarValue++))
                            return false;

                        tableList = "sol_Orders, sol_OrdersDetail";
                        command.Parameters["@TableList"].Value = tableList;
                        command.ExecuteScalar();

                        //QDS Tables
                        //progressBar1.PerformStep();
                        //labelResult.Text = "Importing QDS Information...";
                        if (!UpdateProgress(worker, e, "Importing QDS Information...", progressBarValue++))
                            return false;

                        tableList = "Qds_PaymentMethod, Qds_PaymentMethodAvailableByDepot, Qds_Drop, Qds_Bag";
                        command.Parameters["@TableList"].Value = tableList;
                        command.ExecuteScalar();

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        //SirLib.CajaDeMensaje.Show(
                        //    "Changing Mode"
                        //    , "Error importing data in Offline database: "
                        //    , ex.Message
                        //    , CajaDeMensajeImagen.Alert
                        //    );
                        MessageBox.Show("Error importing data in Offline database: " + ex.Message);
                        return false;
                    }

                    //TrackDataForSync
                    try
                    {
                        //--Run the following SP for any master table that you want to sync back to Master database later
                        //  --This isn't required for detail tables unless update tracking is required.
                        //EXEC sps_GoingOffline_TrackDataForSync 'sol_Customers','CustomerID'
                        if (!UpdateProgress(worker, e, "TrackDataForSync for Customers...", progressBarValue++))
                            return false;
                        command.CommandText = "sps_GoingOffline_TrackDataForSync";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter("@TableName", "Sol_Customers"));
                        command.Parameters.Add(new SqlParameter("@IDName", "CustomerID"));
                        command.ExecuteScalar();

                        //EXEC sps_GoingOffline_TrackDataForSync 'sol_Orders','OrderID'
                        if (!UpdateProgress(worker, e, "TrackDataForSync for Orders...", progressBarValue++))
                            return false;
                        command.CommandText = "sps_GoingOffline_TrackDataForSync";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters["@TableName"].Value = "Sol_Orders";
                        command.Parameters["@IDName"].Value = "OrderID";
                        command.ExecuteScalar();

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        //SirLib.CajaDeMensaje.Show(
                        //    "Changing Mode"
                        //    , "Error importing data in Offline database: "
                        //    , ex.Message
                        //    , CajaDeMensajeImagen.Alert
                        //    );
                        MessageBox.Show("Error Tracking Data for Sync in Offline database: " + ex.Message);
                        return false;
                    }


                    //--Create Stored Procedures for later
                    try
                    {
                        //--3)sps_GoingOnline_AddInsertedData
                        if (!UpdateProgress(worker, e, "Create Sps_GoingOnline_AddInsertedData...", progressBarValue++))
                            return false;
                        command.Parameters.Clear();
                        command.CommandType = CommandType.Text;

                        command.CommandText = @"CREATE PROCEDURE [dbo].[sps_GoingOnline_AddInsertedData] 
                            (
	                            @SolumServerName nvarchar(200),
	                            @TableName nvarchar(200),
	                            @IDName nvarchar(200),
	                            @DetailTableName nvarchar(200) = Null,   --Optional
	                            @DetailIDName nvarchar(200) = Null
                            )
                            AS
                            DECLARE @Current tinyint = 0,
                                    @End tinyint,
		                            @ID nvarchar(200),
		                            @NewID int,
		                            @sql nvarchar(4000),
		                            @ColumnNames nvarchar(4000),
		                            @DetailColumnNames nvarchar(4000),
		                            @DetailColumnsToInsert nvarchar(4000)

                            --Link to Depot Server
                            --EXEC sp_addlinkedsrvlogin @rmtsrvname = @SolumServerName, @useself = 'FALSE', @rmtuser = 'winsir', @rmtpassword = 'win.747'; 
                            EXEC sp_droplinkedsrvlogin @SolumServerName, null
                            EXEC sp_dropserver @SolumServerName, 'droplogins'
                            EXEC sp_addlinkedserver @server = @SolumServerName
                            EXEC sp_addlinkedsrvlogin @rmtsrvname = @SolumServerName, @useself = 'FALSE', @rmtuser = 'winsir', @rmtpassword = 'win.747' 

                            --GET COLUMN NAMES
                            SELECT @ColumnNames = CONVERT(nvarchar(4000), SetValue) FROM [dbo].[Sol_Settings] WHERE Name = @TableName + '_ColumnNames'
                            --remove IDName column from ColumnNames (This is only for tables with Autonumber ID field)
                            SELECT @Current = CHARINDEX(@IDName,@ColumnNames)
                            IF @Current > 0
	                            BEGIN
		                            IF @Current = 1
			                            BEGIN
				                            SET @ColumnNames = LTRIM(SUBSTRING(@ColumnNames, LEN(@IDName) + 2, LEN(@ColumnNames)-LEN(@IDName)-1))
			                            END
		                            ELSE
			                            BEGIN
				                            SET @ColumnNames = LTRIM(SUBSTRING(@ColumnNames, 1, @Current-1) + SUBSTRING(@ColumnNames, @Current + LEN(@IDName) + 2, LEN(@ColumnNames)-LEN(@IDName)-1-@Current))
			                            END
	                            END
                            --GET DETAIL TABLE COLUMN NAMES
                            IF @DetailTableName Is Not NULL
                            BEGIN
	                            SELECT @DetailColumnNames = CONVERT(nvarchar(4000), SetValue) FROM [dbo].[Sol_Settings] WHERE Name = @DetailTableName + '_ColumnNames'
	                            --remove IDName column from ColumnNames (This is only for tables with Autonumber ID field)
	                            SELECT @Current = CHARINDEX(@DetailIDName,@DetailColumnNames)
	                            IF @Current > 0
		                            BEGIN
			                            IF @Current = 1
				                            BEGIN
					                            SET @DetailColumnNames = LTRIM(SUBSTRING(@DetailColumnNames, LEN(@DetailIDName) + 2, LEN(@DetailColumnNames)-LEN(@DetailIDName)-1))
				                            END
			                            ELSE
				                            BEGIN
					                            SET @DetailColumnNames = LTRIM(SUBSTRING(@DetailColumnNames, 1, @Current-1) + SUBSTRING(@DetailColumnNames, @Current + LEN(@DetailIDName) + 2, LEN(@DetailColumnNames)-LEN(@DetailIDName)-1-@Current))
				                            END
		                            END
	                            --Add table name to ColumnNames
	                            SET @DetailColumnNames = REPLACE(@DetailColumnNames, ' ' , '')
	                            SET @DetailColumnNames = REPLACE(@DetailColumnNames, ',' , ',dbo.' + @DetailTableName + '.')	
	                            --Remove master IDName from ColumnNames
	                            SELECT @Current = CHARINDEX(@IDName,@DetailColumnNames)
	                            IF @Current > 0
		                            BEGIN
			                            IF @Current = 1
				                            BEGIN
					                            SET @DetailColumnNames = LTRIM(SUBSTRING(@DetailColumnNames, LEN(@IDName) + 2, LEN(@DetailColumnNames)-LEN(@IDName)-1))
				                            END
			                            ELSE
				                            BEGIN
					                            SET @DetailColumnNames = LTRIM(SUBSTRING(@DetailColumnNames, 1, @Current-1) + SUBSTRING(@DetailColumnNames, @Current + LEN(@IDName) + 2, LEN(@DetailColumnNames)-LEN(@IDName)-1-@Current))
				                            END
		                            END
                            END

                            --create list of all new itmes to be INSERTed
                            SET @Current = 0
                            IF OBJECT_ID('tmp_InsertList', 'U') IS NOT NULL 
	                            DROP TABLE tmp_InsertList;
                            CREATE TABLE tmp_InsertList  (RowID  int identity(1,1), ID int)
                            EXEC('INSERT INTO tmp_InsertList (ID)	SELECT ' + @IDName + ' FROM [dbo].[' + @TableName + '] WHERE CreatedOffline = 1')
                            SELECT @End = COUNT(ID) FROM tmp_InsertList;
                            WHILE @Current<@End
                            BEGIN
                                SET @Current=@Current+1
                                SELECT @ID = ID FROM tmp_InsertList WHERE RowID=@Current
	                            SET @sql = 'INSERT INTO [' + @SolumServerName + '].[Solum].[dbo].[' + @TableName + '] (' + @ColumnNames + ') 
		                                SELECT ' + @ColumnNames + ' FROM [dbo].[' + @TableName + '] WHERE ' + @IDName + ' = ' + @ID 
	                            EXEC(@sql)

	                            DECLARE	@Identity varchar(50)
	                            DECLARE @ScopeIdentity Table(ID int)
	                            SET @sql = 'EXEC [' + @SolumServerName + '].[Solum]..sp_executesql N''
		                            SELECT IDENT_CURRENT(''''dbo.' + @TableName + ''''') '';'
	                            INSERT INTO @ScopeIdentity EXEC(@sql);
	                            SELECT @Identity = ID FROM @ScopeIdentity;
	                            --PRINT @Identity
	                            SET @sql = 'UPDATE [dbo].[' + @TableName + '] SET OnlineID = ' + @Identity + ' WHERE ' + @IDName + ' = ' + @ID;
	                            EXEC(@sql)
	                            IF @DetailTableName Is Not NULL
	                            BEGIN
		                            SET @sql = 'INSERT INTO [' + @SolumServerName + '].[Solum].[dbo].[' + @DetailTableName + '] (dbo.' + @DetailTableName + '.' + @IDName + ', ' + @DetailColumnNames + ') ' +
				                            ' SELECT dbo.' + @TableName + '.OnlineID,' + @DetailColumnNames +  
				                            ' FROM dbo.' + @TableName + ' INNER JOIN dbo.' + @DetailTableName + ' ON dbo.' + @TableName + '.' + @IDName + ' = dbo.' + @DetailTableName + '.' + @IDName +
				                            ' WHERE dbo.' + @DetailTableName + '.' + @IDName + ' = ' + @ID
		                            EXEC(@sql)
	                            END 
                            END
                            DROP TABLE tmp_InsertList;
                            ";

                        //command.ExecuteScalar();
                        command.ExecuteNonQuery();


                        //--4)sps_GoingOnline_SyncUpdatedData
                        if (!UpdateProgress(worker, e, "Create Sps_GoingOnline_SyncUpdatedData...", progressBarValue++))
                            return false;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"
                            CREATE PROCEDURE [dbo].[sps_GoingOnline_SyncUpdatedData]
                            (
	                            @SolumServerName nvarchar(200),
	                            @TableName nvarchar(200),
	                            @IDName nvarchar(200)
                            )
                            AS
                            DECLARE @SQL nvarchar(4000),
		                            @ColumnNames nvarchar(4000),
		                            @ColumnName nvarchar(200),
		                            @ColumnCount tinyint,
		                            @Index tinyint,
		                            @Start tinyint,
		                            @End tinyint,
		                            @Current tinyint = 0,
		                            @ID int
                            DECLARE @tbColumnNames Table(sList nvarchar(4000))

                            --Link to Depot Server
                            --EXEC sp_addlinkedsrvlogin @rmtsrvname = @SolumServerName, @useself = 'FALSE', @rmtuser = 'winsir', @rmtpassword = 'win.747'; 
                            EXEC sp_droplinkedsrvlogin @SolumServerName, null
                            EXEC sp_dropserver @SolumServerName, 'droplogins'
                            EXEC sp_addlinkedserver @server = @SolumServerName
                            EXEC sp_addlinkedsrvlogin @rmtsrvname = @SolumServerName, @useself = 'FALSE', @rmtuser = 'winsir', @rmtpassword = 'win.747' 

                            IF OBJECT_ID('tmp_UpdateList', 'U') IS NOT NULL 
	                            DROP TABLE tmp_UpdateList;
                            CREATE TABLE tmp_UpdateList  (RowID  int identity(1,1), ID int)
                            EXEC ('INSERT INTO tmp_UpdateList(ID)	SELECT OnlineID from [dbo].[' + @TableName + '] WHERE UpdatedOffline = 1')
                            SELECT @End = Count(ID) FROM tmp_UpdateList
                            WHILE @Current<@End
                            BEGIN
                                SET @Current=@Current+1
                                SELECT @ID = ID FROM tmp_UpdateList WHERE RowID=@Current
	                            INSERT INTO @tbColumnNames EXEC('SELECT ISNULL(ColumnUpdated,'''') FROM [dbo].[' + @TAbleName + '] WHERE OnlineID = ' + @ID);	
	                            SELECT @ColumnNames = sList FROM @tbColumnNames;
	                            WHILE LEN(@ColumnNames) > 0
                                BEGIN
                                    SET @Index = CHARINDEX(',', @ColumnNames)
                                    IF @Index = 0
                                        BEGIN
                                            SET @ColumnName = LTRIM(RTRIM(@ColumnNames))
				                            IF LEN(@ColumnName)>0
					                            BEGIN
						                            SET @SQL = 'UPDATE [' + @SolumServerName + '].[Solum].[dbo].[' + @TableName +'] SET ' + @ColumnName + ' = (SELECT ' + @ColumnName + ' FROM [dbo].[' + @TableName +'] WHERE OnlineID = ' + CONVERT(nvarchar(50),@ID) + ') WHERE ' + @IDName + ' = ' + CONVERT(nvarchar(50),@ID)
						                            EXEC(@SQL)
					                            END
                                            BREAK
                                        END
                                    ELSE
                                        BEGIN
                                            SET @ColumnName = (LTRIM(RTRIM(SUBSTRING(@ColumnNames, 1,@Index - 1))))
                                            SET @Start = @Index + 1
                                            SET @ColumnNames = SUBSTRING(@ColumnNames, @Start , LEN(@ColumnNames) - @Start + 1)
				                            IF LEN(@ColumnName)>0
					                            BEGIN
						                            SET @SQL = 'UPDATE [' + @SolumServerName + '].[Solum].[dbo].[' + @TableName +'] SET ' + @ColumnName + ' = (SELECT ' + @ColumnName + ' FROM [dbo].[' + @TableName +'] WHERE OnlineID = ' + CONVERT(nvarchar(50),@ID) + ') WHERE ' + @IDName + ' = ' + CONVERT(nvarchar(50),@ID)
						                            EXEC(@SQL)
					                            END
                                       END
                                END
                            END  
                            DROP TABLE tmp_UpdateList;
                            ";

                        //command.ExecuteScalar();
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        //SirLib.CajaDeMensaje.Show(
                        //    "Changing Mode"
                        //    , "Error importing data in Offline database: "
                        //    , ex.Message
                        //    , CajaDeMensajeImagen.Alert
                        //    );
                        MessageBox.Show("Error Createing Stored Procedures for later use: " + ex.Message);
                        return false;
                    }


                }
            }

            this.Cursor = Cursors.Default;

            return true;
        }

        private bool DepotMode(BackgroundWorker worker, DoWorkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //progressBarValue = 2;
            //for (int i = progressBarValue; i <= 10; i++)
            //{
            //    if (worker.CancellationPending == true)
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    else
            //    {
            //        // Perform a time consuming operation and report progress.
            //        alert.Message = string.Format("Step {0}", i);
            //        worker.ReportProgress(i * 10);
            //        System.Threading.Thread.Sleep(500);
            //    }
            //}
            //this.Cursor = Cursors.Default;
            //return true;

            int pasos = 5;
            progressBarValue = 1;
            progressBarStep = progressBarMaximum / pasos;

            //Data Source=RUBITO2-PC\SQLEXPRESS;Initial Catalog=Solum;Integrated Security=True
            var localConnBuilder = new SqlConnectionStringBuilder(Properties.Settings.Default.ModesSolumConnectionString);
            //localConnBuilder.DataSource = Properties.Settings.Default.ModesLocalDbServerName;

            string strConnectionString = Properties.Settings.Default.WsirDbConnectionString;

            //progressBar1.PerformStep();
            //labelResult.Text = "Connecting to Local Server...";
            if (!UpdateProgress(worker, e, "Connecting to LocalDB Server...", progressBarValue++))
                return false;

            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    //exist server?
                    try
                    {
                        connection.Open();

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Error connecting to LocalDB Server: " + ex.Message);
                        return false;

                    }

                    //export data to Solum
                    //AddInsertedData
                    try
                    {
                        //EXEC Sps_GoingOnline_AddInsertedData 'DELL','sol_Customers','CustomerID'
                        if (!UpdateProgress(worker, e, "AddInsertedData for Customers...", progressBarValue++))
                            return false;
                        command.CommandText = "Sps_GoingOnline_AddInsertedData";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        command.Parameters.Add(new SqlParameter("@SolumServerName", localConnBuilder.DataSource));
                        command.Parameters.Add(new SqlParameter("@TableName", "Sol_Customers"));
                        command.Parameters.Add(new SqlParameter("@IDName", "CustomerID"));
                        command.Parameters.Add(new SqlParameter("@DetailTableName", ""));
                        command.Parameters.Add(new SqlParameter("@DetailIDName", ""));

                        command.ExecuteScalar();

                        //EXEC sps_GoingOnline_AddInsertedData 'DELL','sol_Orders','OrderID','sol_OrdersDetail','DetailID'
                        if (!UpdateProgress(worker, e, "AddInsertedData for Orders...", progressBarValue++))
                            return false;
                        command.CommandText = "sps_GoingOnline_AddInsertedData";
                        command.CommandType = CommandType.StoredProcedure;
                        //command.Parameters.Clear();

                        //command.Parameters["@SolumServerName"].Value = "Sol_Customers";
                        command.Parameters["@TableName"].Value = "Sol_Orders";
                        command.Parameters["@IDName"].Value = "OrderID";
                        command.Parameters["@DetailTableName"].Value = "sol_OrdersDetail";
                        command.Parameters["@DetailIDName"].Value = "DetailID";

                        command.ExecuteScalar();

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        //SirLib.CajaDeMensaje.Show(
                        //    "Changing Mode"
                        //    , "Error importing data in Offline database: "
                        //    , ex.Message
                        //    , CajaDeMensajeImagen.Alert
                        //    );
                        MessageBox.Show("Error Adding Inserted Data: " + ex.Message);
                        return false;
                    }


                    //SyncUpdatedData
                    try
                    {
                        //EXEC sps_GoingOnline_SyncUpdatedData 'DELL','sol_Customers','CustomerID'
                        if (!UpdateProgress(worker, e, "AddInsertedData for Customers...", progressBarValue++))
                            return false;

                        command.CommandText = "Sps_GoingOnline_SyncUpdatedData";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();

                        command.Parameters.Add(new SqlParameter("@SolumServerName", localConnBuilder.DataSource));
                        command.Parameters.Add(new SqlParameter("@TableName", "Sol_Customers"));
                        command.Parameters.Add(new SqlParameter("@IDName", "CustomerID"));

                        command.ExecuteScalar();

                        //EXEC sps_GoingOnline_SyncUpdatedData 'DELL','sol_Orders','OrderID'
                        if (!UpdateProgress(worker, e, "AddInsertedData for Orders...", progressBarValue++))
                            return false;

                        command.CommandText = "Sps_GoingOnline_SyncUpdatedData";
                        command.CommandType = CommandType.StoredProcedure;
                        //command.Parameters.Clear();

                        //command.Parameters["@SolumServerName"].Value = "Sol_Customers";
                        command.Parameters["@TableName"].Value = "Sol_Orders";
                        command.Parameters["@IDName"].Value = "OrderID";

                        command.ExecuteScalar();

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        //SirLib.CajaDeMensaje.Show(
                        //    "Changing Mode"
                        //    , "Error importing data in Offline database: "
                        //    , ex.Message
                        //    , CajaDeMensajeImagen.Alert
                        //    );
                        MessageBox.Show("Error Synchronizing Updated Data: " + ex.Message);
                        return false;
                    }


                }
            }


            this.Cursor = Cursors.Default;

            return true;
        }

        private bool UpdateProgress(BackgroundWorker worker, DoWorkEventArgs e, string message, int percentage)
        {
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return false;
            }
            else
            {
                percentage *= progressBarStep;
                if (percentage > progressBarMaximum)
                    percentage = progressBarMaximum;

                alert.Message = message;
                worker.ReportProgress(percentage);
            }
            return true;
        }

        // This event handler cancels the backgroundworker, fired from Cancel button in AlertForm.
        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                // Close the AlertForm
                alert.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            switch (strMode)
            {
                case "DEPOT":
                    changeModeSuccessfully = true;

                    Properties.Settings.Default.SQLBaseDeDatos = Properties.Settings.Default.BaseDeDatosPrincipal;
                    //Properties.Settings.Default.RuntimeConnectString = "Data Source=RUBITO2-PC\\SQLEXPRESS;Initial Catalog=Solum;Integrated Security=True";    //Properties.Settings.Default.ModesSolumConnectionString;

                    var connModeBuilder = new SqlConnectionStringBuilder(Properties.Settings.Default.ModesSolumConnectionString);
                    //connModeBuilder.DataSource="192.168.1.1";
                    connModeBuilder.ConnectTimeout = 10;

                    //test connection
                    UpdateProgress(worker, e, "Checking Depot Server connection...", progressBarValue++);
                    using (SqlConnection connection = new SqlConnection(connModeBuilder.ConnectionString))
                    {
                        //using (SqlCommand command = new SqlCommand("", connection))
                        //{
                        //exist server?
                        try
                        {
                            connection.Open();

                        }
                        catch (Exception ex)
                        {
                            //buttonChangeMode.Enabled = true;
                            //buttonExit.Enabled = true;
                            MessageBox.Show("Error connecting back to Depot Server, please check your connections: " + ex.Message);
                            if (backgroundWorker1.WorkerSupportsCancellation == true)
                            {
                                // Cancel the asynchronous operation.
                                backgroundWorker1.CancelAsync();
                                // Close the AlertForm
                                alert.Close();
                            }
                            return;

                        }

                        //}
                    }

                    changeModeSuccessfully = DepotMode(worker, e);

                    if (changeModeSuccessfully)
                    {
                        connBuilder = connModeBuilder;
                        Properties.Settings.Default.RuntimeConnectString = connBuilder.ConnectionString; //Properties.Settings.Default.ModesSolumConnectionString;
                        Properties.Settings.Default.RuntimeDbConnectString = connBuilder.ConnectionString; //Properties.Settings.Default.ModesSolumConnectionString;
                        //connBuilder = new SqlConnectionStringBuilder(Properties.Settings.Default.WsirDbConnectionString);
                        Properties.Settings.Default.SQLRecuerdame = Properties.Settings.Default.ModesSolumRecuerdame;
                    }
                    break;
                case "OFF_LINE":
                    changeModeSuccessfully = OfflineMode(worker, e);
                    if (changeModeSuccessfully)
                    {
                        //string sc = Properties.Settings.Default.WsirDbConnectionString;
                        Properties.Settings.Default.ModesSolumConnectionString = Properties.Settings.Default.WsirDbConnectionString;

                        Properties.Settings.Default.SQLBaseDeDatos = Properties.Settings.Default.ModesLocalDbDatabaseName;

                        connBuilder.DataSource = Properties.Settings.Default.ModesLocalDbServerName;
                        connBuilder.InitialCatalog = Properties.Settings.Default.SQLBaseDeDatos;
                        connBuilder.IntegratedSecurity = true;
                        connBuilder.ConnectTimeout = 30;
                        Properties.Settings.Default.RuntimeConnectString = connBuilder.ConnectionString;
                        Properties.Settings.Default.RuntimeDbConnectString = connBuilder.ConnectionString;

                    }
                    break;

            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Show the progress in main form (GUI)
            labelResult.Text = (e.ProgressPercentage.ToString() + "%");
            // Pass the progress to AlertForm label and progressbar
            alert.Percentage = e.ProgressPercentage.ToString() + "%";
            alert.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Close the AlertForm
            alert.Close();

            buttonChangeMode.Enabled = true;
            buttonExit.Enabled = true;

            if (e.Cancelled == true)
            {
                labelResult.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                labelResult.Text = "Error: " + e.Error.Message;
            }
            else
            {
                labelResult.Text = "Done!";

                if (changeModeSuccessfully)
                {
                    Properties.Settings.Default.SQLServidorNombre = connBuilder.DataSource;
                    Properties.Settings.Default.SQLServidorConectado = true;
                    if (connBuilder.IntegratedSecurity)
                    {
                        Properties.Settings.Default.SQLAutentificacion = 0;
                    }
                    else
                    {
                        if (connBuilder.UserID == "winsir")
                            Properties.Settings.Default.SQLAutentificacion = 2;
                        else
                            Properties.Settings.Default.SQLAutentificacion = 1;
                    }
                    Properties.Settings.Default.SQLUsuarioNombre = connBuilder.UserID;
                    Properties.Settings.Default.SQLUsuarioClave = connBuilder.Password;

                    Properties.Settings.Default.Save();

                    Funciones.SetMembershipProviderConnectionString(connBuilder.ConnectionString);


                    string ns = Properties.Settings.Default.SQLServidorNombre;

                }

                //progressBar1.Value = progressBar1.Maximum;

                //cashtray options
                if (changeModeSuccessfully
                    && listBoxModesAvailables.Text == "OFF_LINE")
                {
                    if (radioButtonOpenDedicatedCashTray.Checked)
                    {
                        //Open Dedicated Cash Tray for Off-Site/Off-Line use
                        Float f1 = new Float("Open");
                        f1.ShowDialog();
                        f1.Dispose();
                        f1 = null;

                    }
                    else if (radioButtonUseCashTrayAsExt.Checked)
                    {
                        //Use Cash Tray as an extension On-Line version
                        //save entry
                        Sol_Entrie_Sp sol_Entrie_Sp = new Sol_Entrie_Sp(Properties.Settings.Default.WsirDbConnectionString);
                        Sol_Entrie sol_Entrie = new Sol_Entrie();
                        sol_Entrie.EntryType = "O";
                        System.Web.Security.MembershipUser membershipUser = membershipUser = System.Web.Security.Membership.GetUser(Properties.Settings.Default.UsuarioNombre);
                        if (membershipUser == null)
                            sol_Entrie.UserID = Guid.Empty;
                        else
                            sol_Entrie.UserID = (Guid)membershipUser.ProviderUserKey;

                        sol_Entrie.UserName = Properties.Settings.Default.UsuarioNombre;

                        sol_Entrie.Date = Main.rc.FechaActual; // Properties.Settings.Default.FechaActual;
                        sol_Entrie.CashTrayID = Properties.Settings.Default.SettingsCurrentCashTray;
                        sol_Entrie.ExpenseTypeID = 0; //<none>
                        sol_Entrie.Amount = 0;
                        sol_Entrie.DiscrepancyAmount = 0.0m;
                        sol_Entrie_Sp.Insert(sol_Entrie);
                    }
                    else if (radioButtonNoCashNeeded.Checked)
                    {
                        //No Cash needed – all transactions will be On Account only.
                    }
                }


                this.Close();

            }
        }
    }
}
