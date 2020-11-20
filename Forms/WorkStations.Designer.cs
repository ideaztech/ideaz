namespace Solum
{
    partial class WorkStations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label workStationIDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label locationLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkStations));
            this.dataSetWorkStations = new Solum.DataSetWorkStations();
            this.sol_WorkStationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sol_WorkStationsTableAdapter = new Solum.DataSetWorkStationsTableAdapters.sol_WorkStationsTableAdapter();
            this.tableAdapterManager = new Solum.DataSetWorkStationsTableAdapters.TableAdapterManager();
            this.sol_WorkStationsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sol_WorkStationsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.workStationIDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.sol_WorkStationsDataGridView = new SirLib.DataGridViewModificada();
            this.workStationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OK = new System.Windows.Forms.Button();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            workStationIDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            locationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetWorkStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WorkStationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WorkStationsBindingNavigator)).BeginInit();
            this.sol_WorkStationsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WorkStationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // workStationIDLabel
            // 
            workStationIDLabel.AutoSize = true;
            workStationIDLabel.Location = new System.Drawing.Point(12, 16);
            workStationIDLabel.Name = "workStationIDLabel";
            workStationIDLabel.Size = new System.Drawing.Size(86, 13);
            workStationIDLabel.TabIndex = 0;
            workStationIDLabel.Text = "Work Station ID:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 44);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(12, 72);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Description:";
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Location = new System.Drawing.Point(12, 100);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new System.Drawing.Size(51, 13);
            locationLabel.TabIndex = 6;
            locationLabel.Text = "Location:";
            // 
            // dataSetWorkStations
            // 
            this.dataSetWorkStations.DataSetName = "DataSetWorkStations";
            this.dataSetWorkStations.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_WorkStationsBindingSource
            // 
            this.sol_WorkStationsBindingSource.DataMember = "sol_WorkStations";
            this.sol_WorkStationsBindingSource.DataSource = this.dataSetWorkStations;
            // 
            // sol_WorkStationsTableAdapter
            // 
            this.sol_WorkStationsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.sol_WorkStationsTableAdapter = this.sol_WorkStationsTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetWorkStationsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sol_WorkStationsBindingNavigator
            // 
            this.sol_WorkStationsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.sol_WorkStationsBindingNavigator.BindingSource = this.sol_WorkStationsBindingSource;
            this.sol_WorkStationsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.sol_WorkStationsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.sol_WorkStationsBindingNavigator.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sol_WorkStationsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.sol_WorkStationsBindingNavigatorSaveItem,
            this.toolStripButtonVirtualKb});
            this.sol_WorkStationsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.sol_WorkStationsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.sol_WorkStationsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.sol_WorkStationsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.sol_WorkStationsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.sol_WorkStationsBindingNavigator.Name = "sol_WorkStationsBindingNavigator";
            this.sol_WorkStationsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.sol_WorkStationsBindingNavigator.Size = new System.Drawing.Size(724, 39);
            this.sol_WorkStationsBindingNavigator.TabIndex = 0;
            this.sol_WorkStationsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 36);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // sol_WorkStationsBindingNavigatorSaveItem
            // 
            this.sol_WorkStationsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sol_WorkStationsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("sol_WorkStationsBindingNavigatorSaveItem.Image")));
            this.sol_WorkStationsBindingNavigatorSaveItem.Name = "sol_WorkStationsBindingNavigatorSaveItem";
            this.sol_WorkStationsBindingNavigatorSaveItem.Size = new System.Drawing.Size(36, 36);
            this.sol_WorkStationsBindingNavigatorSaveItem.Text = "Save Data";
            this.sol_WorkStationsBindingNavigatorSaveItem.Click += new System.EventHandler(this.sol_WorkStationsBindingNavigatorSaveItem_Click);
            // 
            // toolStripButtonVirtualKb
            // 
            this.toolStripButtonVirtualKb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonVirtualKb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVirtualKb.Image = global::Solum.Properties.Resources.kxkb;
            this.toolStripButtonVirtualKb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVirtualKb.Name = "toolStripButtonVirtualKb";
            this.toolStripButtonVirtualKb.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonVirtualKb.Text = "Virtual Keyboard";
            this.toolStripButtonVirtualKb.Visible = false;
            this.toolStripButtonVirtualKb.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelDetails);
            this.splitContainer1.Panel1.Controls.Add(this.sol_WorkStationsDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDetails);
            this.splitContainer1.Panel2.Controls.Add(this.Cancel);
            this.splitContainer1.Size = new System.Drawing.Size(724, 380);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(workStationIDLabel);
            this.panelDetails.Controls.Add(this.workStationIDTextBox);
            this.panelDetails.Controls.Add(nameLabel);
            this.panelDetails.Controls.Add(this.nameTextBox);
            this.panelDetails.Controls.Add(descriptionLabel);
            this.panelDetails.Controls.Add(this.descriptionTextBox);
            this.panelDetails.Controls.Add(locationLabel);
            this.panelDetails.Controls.Add(this.locationTextBox);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(724, 324);
            this.panelDetails.TabIndex = 1;
            this.panelDetails.Visible = false;
            // 
            // workStationIDTextBox
            // 
            this.workStationIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_WorkStationsBindingSource, "WorkStationID", true));
            this.workStationIDTextBox.Location = new System.Drawing.Point(128, 13);
            this.workStationIDTextBox.Name = "workStationIDTextBox";
            this.workStationIDTextBox.ReadOnly = true;
            this.workStationIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.workStationIDTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_WorkStationsBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(128, 41);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(277, 20);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nameTextBox_Validating);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_WorkStationsBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(128, 69);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(277, 20);
            this.descriptionTextBox.TabIndex = 5;
            this.descriptionTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nameTextBox_Validating);
            // 
            // locationTextBox
            // 
            this.locationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_WorkStationsBindingSource, "Location", true));
            this.locationTextBox.Location = new System.Drawing.Point(128, 97);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(277, 20);
            this.locationTextBox.TabIndex = 7;
            this.locationTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nameTextBox_Validating);
            // 
            // sol_WorkStationsDataGridView
            // 
            this.sol_WorkStationsDataGridView.AutoGenerateColumns = false;
            this.sol_WorkStationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sol_WorkStationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workStationIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn});
            this.sol_WorkStationsDataGridView.DataSource = this.sol_WorkStationsBindingSource;
            this.sol_WorkStationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sol_WorkStationsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.sol_WorkStationsDataGridView.Name = "sol_WorkStationsDataGridView";
            this.sol_WorkStationsDataGridView.RowTemplate.Height = 24;
            this.sol_WorkStationsDataGridView.Size = new System.Drawing.Size(724, 324);
            this.sol_WorkStationsDataGridView.TabIndex = 0;
            this.sol_WorkStationsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sol_WorkStationsDataGridView_CellDoubleClick);
            this.sol_WorkStationsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sol_WorkStationsDataGridView_DataError);
            // 
            // workStationIDDataGridViewTextBoxColumn
            // 
            this.workStationIDDataGridViewTextBoxColumn.DataPropertyName = "WorkStationID";
            this.workStationIDDataGridViewTextBoxColumn.HeaderText = "WorkStationID";
            this.workStationIDDataGridViewTextBoxColumn.Name = "workStationIDDataGridViewTextBoxColumn";
            this.workStationIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(181, 12);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(97, 29);
            this.OK.TabIndex = 8;
            this.OK.Text = "&Update";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(314, 12);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(97, 29);
            this.buttonDetails.TabIndex = 7;
            this.buttonDetails.Text = "&Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(447, 12);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(97, 29);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "&Close";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // WorkStations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(724, 419);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sol_WorkStationsBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkStations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorkStations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkStations_FormClosing);
            this.Load += new System.EventHandler(this.WorkStations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetWorkStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WorkStationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WorkStationsBindingNavigator)).EndInit();
            this.sol_WorkStationsBindingNavigator.ResumeLayout(false);
            this.sol_WorkStationsBindingNavigator.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_WorkStationsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetWorkStations dataSetWorkStations;
        private System.Windows.Forms.BindingSource sol_WorkStationsBindingSource;
        private Solum.DataSetWorkStationsTableAdapters.sol_WorkStationsTableAdapter sol_WorkStationsTableAdapter;
        private Solum.DataSetWorkStationsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator sol_WorkStationsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton sol_WorkStationsBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SirLib.DataGridViewModificada sol_WorkStationsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn workStationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TextBox workStationIDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}