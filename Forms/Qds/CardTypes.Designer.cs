namespace Solum
{
    partial class CardTypes
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
            System.Windows.Forms.Label cardTypeIDLabel;
            System.Windows.Forms.Label cardTypeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardTypes));
            this.Qds_CardTypesDataGridView = new SirLib.DataGridViewModificada();
            this.cardTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qds_CardTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qdsDataSetCardTypes = new Solum.QdsDataSetCardTypes();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.cardTypeIDTextBox = new System.Windows.Forms.TextBox();
            this.cardTypeTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelGrid = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.qds_CardTypesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.BindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.tableAdapterManager = new Solum.QdsDataSetCardTypesTableAdapters.TableAdapterManager();
            this.qds_CardTypesTableAdapter = new Solum.QdsDataSetCardTypesTableAdapters.Qds_CardTypesTableAdapter();
            cardTypeIDLabel = new System.Windows.Forms.Label();
            cardTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Qds_CardTypesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qds_CardTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qdsDataSetCardTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.tableLayoutPanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qds_CardTypesBindingNavigator)).BeginInit();
            this.qds_CardTypesBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardTypeIDLabel
            // 
            cardTypeIDLabel.AutoSize = true;
            cardTypeIDLabel.Location = new System.Drawing.Point(72, 49);
            cardTypeIDLabel.Name = "cardTypeIDLabel";
            cardTypeIDLabel.Size = new System.Drawing.Size(95, 17);
            cardTypeIDLabel.TabIndex = 0;
            cardTypeIDLabel.Text = "Card Type ID:";
            // 
            // cardTypeLabel
            // 
            cardTypeLabel.AutoSize = true;
            cardTypeLabel.Location = new System.Drawing.Point(72, 81);
            cardTypeLabel.Name = "cardTypeLabel";
            cardTypeLabel.Size = new System.Drawing.Size(78, 17);
            cardTypeLabel.TabIndex = 2;
            cardTypeLabel.Text = "Card Type:";
            // 
            // Qds_CardTypesDataGridView
            // 
            this.Qds_CardTypesDataGridView.AllowUserToAddRows = false;
            this.Qds_CardTypesDataGridView.AllowUserToDeleteRows = false;
            this.Qds_CardTypesDataGridView.AutoGenerateColumns = false;
            this.Qds_CardTypesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Qds_CardTypesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cardTypeIDDataGridViewTextBoxColumn,
            this.cardTypeDataGridViewTextBoxColumn});
            this.Qds_CardTypesDataGridView.DataSource = this.qds_CardTypesBindingSource;
            this.Qds_CardTypesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Qds_CardTypesDataGridView.Location = new System.Drawing.Point(6, 75);
            this.Qds_CardTypesDataGridView.MultiSelect = false;
            this.Qds_CardTypesDataGridView.Name = "Qds_CardTypesDataGridView";
            this.Qds_CardTypesDataGridView.RowTemplate.Height = 24;
            this.Qds_CardTypesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Qds_CardTypesDataGridView.Size = new System.Drawing.Size(711, 242);
            this.Qds_CardTypesDataGridView.TabIndex = 1;
            // 
            // cardTypeIDDataGridViewTextBoxColumn
            // 
            this.cardTypeIDDataGridViewTextBoxColumn.DataPropertyName = "CardTypeID";
            this.cardTypeIDDataGridViewTextBoxColumn.HeaderText = "CardTypeID";
            this.cardTypeIDDataGridViewTextBoxColumn.Name = "cardTypeIDDataGridViewTextBoxColumn";
            this.cardTypeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardTypeDataGridViewTextBoxColumn
            // 
            this.cardTypeDataGridViewTextBoxColumn.DataPropertyName = "CardType";
            this.cardTypeDataGridViewTextBoxColumn.HeaderText = "CardType";
            this.cardTypeDataGridViewTextBoxColumn.Name = "cardTypeDataGridViewTextBoxColumn";
            // 
            // qds_CardTypesBindingSource
            // 
            this.qds_CardTypesBindingSource.DataMember = "Qds_CardTypes";
            this.qds_CardTypesBindingSource.DataSource = this.qdsDataSetCardTypes;
            // 
            // qdsDataSetCardTypes
            // 
            this.qdsDataSetCardTypes.DataSetName = "QdsDataSetCardTypes";
            this.qdsDataSetCardTypes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(206, 11);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 29);
            this.OK.TabIndex = 0;
            this.OK.Text = "&Select";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(442, 11);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 29);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "&Close";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanelGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonDetails);
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Panel2.Controls.Add(this.Cancel);
            this.splitContainer1.Size = new System.Drawing.Size(723, 380);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 3;
            // 
            // panelDetails
            // 
            this.panelDetails.AutoScroll = true;
            this.panelDetails.Controls.Add(cardTypeIDLabel);
            this.panelDetails.Controls.Add(this.cardTypeIDTextBox);
            this.panelDetails.Controls.Add(cardTypeLabel);
            this.panelDetails.Controls.Add(this.cardTypeTextBox);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(723, 323);
            this.panelDetails.TabIndex = 2;
            this.panelDetails.Visible = false;
            // 
            // cardTypeIDTextBox
            // 
            this.cardTypeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qds_CardTypesBindingSource, "CardTypeID", true));
            this.cardTypeIDTextBox.Location = new System.Drawing.Point(184, 46);
            this.cardTypeIDTextBox.Name = "cardTypeIDTextBox";
            this.cardTypeIDTextBox.ReadOnly = true;
            this.cardTypeIDTextBox.Size = new System.Drawing.Size(100, 22);
            this.cardTypeIDTextBox.TabIndex = 1;
            // 
            // cardTypeTextBox
            // 
            this.cardTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qds_CardTypesBindingSource, "CardType", true));
            this.cardTypeTextBox.Location = new System.Drawing.Point(184, 78);
            this.cardTypeTextBox.MaxLength = 100;
            this.cardTypeTextBox.Name = "cardTypeTextBox";
            this.cardTypeTextBox.Size = new System.Drawing.Size(333, 22);
            this.cardTypeTextBox.TabIndex = 3;
            this.cardTypeTextBox.TextChanged += new System.EventHandler(this.cardTypeIDTextBox_TextChanged);
            this.cardTypeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.cardTypeTextBox_Validating);
            // 
            // tableLayoutPanelGrid
            // 
            this.tableLayoutPanelGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanelGrid.ColumnCount = 1;
            this.tableLayoutPanelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGrid.Controls.Add(this.Qds_CardTypesDataGridView, 0, 1);
            this.tableLayoutPanelGrid.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGrid.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGrid.Name = "tableLayoutPanelGrid";
            this.tableLayoutPanelGrid.RowCount = 2;
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.1838F));
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.8162F));
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGrid.Size = new System.Drawing.Size(723, 323);
            this.tableLayoutPanelGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 60);
            this.panel1.TabIndex = 0;
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(320, 11);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(83, 29);
            this.buttonDetails.TabIndex = 1;
            this.buttonDetails.Text = "&Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // qds_CardTypesBindingNavigator
            // 
            this.qds_CardTypesBindingNavigator.AddNewItem = null;
            this.qds_CardTypesBindingNavigator.BindingSource = this.qds_CardTypesBindingSource;
            this.qds_CardTypesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.qds_CardTypesBindingNavigator.DeleteItem = null;
            this.qds_CardTypesBindingNavigator.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.qds_CardTypesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.BindingNavigatorSaveItem,
            this.toolStripButtonVirtualKb});
            this.qds_CardTypesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.qds_CardTypesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.qds_CardTypesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.qds_CardTypesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.qds_CardTypesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.qds_CardTypesBindingNavigator.Name = "qds_CardTypesBindingNavigator";
            this.qds_CardTypesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.qds_CardTypesBindingNavigator.Size = new System.Drawing.Size(723, 39);
            this.qds_CardTypesBindingNavigator.TabIndex = 4;
            this.qds_CardTypesBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 36);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(36, 36);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // BindingNavigatorSaveItem
            // 
            this.BindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("BindingNavigatorSaveItem.Image")));
            this.BindingNavigatorSaveItem.Name = "BindingNavigatorSaveItem";
            this.BindingNavigatorSaveItem.Size = new System.Drawing.Size(36, 36);
            this.BindingNavigatorSaveItem.Text = "Save Data";
            this.BindingNavigatorSaveItem.Click += new System.EventHandler(this.bindingNavigatorSaveItem_Click);
            // 
            // toolStripButtonVirtualKb
            // 
            this.toolStripButtonVirtualKb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonVirtualKb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVirtualKb.Image = global::Solum.Properties.Resources.kxkb;
            this.toolStripButtonVirtualKb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVirtualKb.Name = "toolStripButtonVirtualKb";
            this.toolStripButtonVirtualKb.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonVirtualKb.Text = "Virtual keyboard";
            this.toolStripButtonVirtualKb.Visible = false;
            this.toolStripButtonVirtualKb.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Qds_CardTypesTableAdapter = this.qds_CardTypesTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.QdsDataSetCardTypesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // qds_CardTypesTableAdapter
            // 
            this.qds_CardTypesTableAdapter.ClearBeforeFill = true;
            // 
            // CardTypes
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(723, 419);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.qds_CardTypesBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CardTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CardTypes";
            this.Load += new System.EventHandler(this.CardTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Qds_CardTypesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qds_CardTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qdsDataSetCardTypes)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.tableLayoutPanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qds_CardTypesBindingNavigator)).EndInit();
            this.qds_CardTypesBindingNavigator.ResumeLayout(false);
            this.qds_CardTypesBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private SirLib.DataGridViewModificada Qds_CardTypesDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource qds_CardTypesBindingSource;
        private System.Windows.Forms.TextBox cardTypeIDTextBox;
        private System.Windows.Forms.TextBox cardTypeTextBox;
        private System.Windows.Forms.BindingNavigator qds_CardTypesBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton BindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private QdsDataSetCardTypes qdsDataSetCardTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardTypeDataGridViewTextBoxColumn;
        private QdsDataSetCardTypesTableAdapters.TableAdapterManager tableAdapterManager;
        private QdsDataSetCardTypesTableAdapters.Qds_CardTypesTableAdapter qds_CardTypesTableAdapter;
    }
}