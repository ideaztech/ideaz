namespace Solum
{
    partial class PaymentMethods
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
            System.Windows.Forms.Label paymentMethodIDLabel;
            System.Windows.Forms.Label paymentMethodLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethods));
            this.BindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Solum.QdsDataSetPaymentMethods();
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
            this.DataGridView1 = new SirLib.DataGridViewModificada();
            this.paymentMethodIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelGrid = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.fieldIDTextBox = new System.Windows.Forms.TextBox();
            this.fieldNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.TableAdapter1 = new Solum.QdsDataSetPaymentMethodsTableAdapters.Qds_PaymentMethodsTableAdapter();
            this.TableAdapterManager = new Solum.QdsDataSetPaymentMethodsTableAdapters.TableAdapterManager();
            paymentMethodIDLabel = new System.Windows.Forms.Label();
            paymentMethodLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator1)).BeginInit();
            this.BindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanelGrid.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentMethodIDLabel
            // 
            paymentMethodIDLabel.AutoSize = true;
            paymentMethodIDLabel.Location = new System.Drawing.Point(55, 23);
            paymentMethodIDLabel.Name = "paymentMethodIDLabel";
            paymentMethodIDLabel.Size = new System.Drawing.Size(135, 17);
            paymentMethodIDLabel.TabIndex = 0;
            paymentMethodIDLabel.Text = "Payment Method ID:";
            // 
            // paymentMethodLabel
            // 
            paymentMethodLabel.AutoSize = true;
            paymentMethodLabel.Location = new System.Drawing.Point(55, 55);
            paymentMethodLabel.Name = "paymentMethodLabel";
            paymentMethodLabel.Size = new System.Drawing.Size(118, 17);
            paymentMethodLabel.TabIndex = 2;
            paymentMethodLabel.Text = "Payment Method:";
            // 
            // BindingNavigator1
            // 
            this.BindingNavigator1.AddNewItem = null;
            this.BindingNavigator1.BindingSource = this.BindingSource1;
            this.BindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.BindingNavigator1.DeleteItem = null;
            this.BindingNavigator1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.BindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.BindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BindingNavigator1.Name = "BindingNavigator1";
            this.BindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.BindingNavigator1.Size = new System.Drawing.Size(723, 39);
            this.BindingNavigator1.TabIndex = 0;
            this.BindingNavigator1.Text = "bindingNavigator1";
            // 
            // BindingSource1
            // 
            this.BindingSource1.DataMember = "Qds_PaymentMethods";
            this.BindingSource1.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "QdsDataSetPaymentMethods";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.bindingNavigatorAddNewItem.Visible = false;
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
            this.bindingNavigatorDeleteItem.Visible = false;
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // BindingNavigatorSaveItem
            // 
            this.BindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("BindingNavigatorSaveItem.Image")));
            this.BindingNavigatorSaveItem.Name = "BindingNavigatorSaveItem";
            this.BindingNavigatorSaveItem.Size = new System.Drawing.Size(36, 36);
            this.BindingNavigatorSaveItem.Text = "Save Data";
            this.BindingNavigatorSaveItem.Visible = false;
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
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AutoGenerateColumns = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentMethodIDDataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn});
            this.DataGridView1.DataSource = this.BindingSource1;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(6, 75);
            this.DataGridView1.MultiSelect = false;
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(711, 241);
            this.DataGridView1.TabIndex = 1;
            this.DataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyUp);
            // 
            // paymentMethodIDDataGridViewTextBoxColumn
            // 
            this.paymentMethodIDDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethodID";
            this.paymentMethodIDDataGridViewTextBoxColumn.HeaderText = "PaymentMethodID";
            this.paymentMethodIDDataGridViewTextBoxColumn.Name = "paymentMethodIDDataGridViewTextBoxColumn";
            this.paymentMethodIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "PaymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanelGrid);
            this.splitContainer1.Panel1.Controls.Add(this.panelDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonDetails);
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Panel2.Controls.Add(this.Cancel);
            this.splitContainer1.Size = new System.Drawing.Size(723, 380);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanelGrid
            // 
            this.tableLayoutPanelGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanelGrid.ColumnCount = 1;
            this.tableLayoutPanelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGrid.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelGrid.Controls.Add(this.DataGridView1, 0, 1);
            this.tableLayoutPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGrid.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGrid.Name = "tableLayoutPanelGrid";
            this.tableLayoutPanelGrid.RowCount = 2;
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.1838F));
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.8162F));
            this.tableLayoutPanelGrid.Size = new System.Drawing.Size(723, 322);
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
            // panelDetails
            // 
            this.panelDetails.AutoScroll = true;
            this.panelDetails.Controls.Add(paymentMethodIDLabel);
            this.panelDetails.Controls.Add(this.fieldIDTextBox);
            this.panelDetails.Controls.Add(paymentMethodLabel);
            this.panelDetails.Controls.Add(this.fieldNameTextBox);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(723, 322);
            this.panelDetails.TabIndex = 2;
            this.panelDetails.Visible = false;
            // 
            // fieldIDTextBox
            // 
            this.fieldIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource1, "PaymentMethodID", true));
            this.fieldIDTextBox.Location = new System.Drawing.Point(215, 20);
            this.fieldIDTextBox.Name = "fieldIDTextBox";
            this.fieldIDTextBox.ReadOnly = true;
            this.fieldIDTextBox.Size = new System.Drawing.Size(100, 22);
            this.fieldIDTextBox.TabIndex = 1;
            this.fieldIDTextBox.TextChanged += new System.EventHandler(this.fieldIDTextBox_TextChanged);
            // 
            // fieldNameTextBox
            // 
            this.fieldNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource1, "PaymentMethod", true));
            this.fieldNameTextBox.Location = new System.Drawing.Point(215, 52);
            this.fieldNameTextBox.MaxLength = 100;
            this.fieldNameTextBox.Name = "fieldNameTextBox";
            this.fieldNameTextBox.Size = new System.Drawing.Size(302, 22);
            this.fieldNameTextBox.TabIndex = 3;
            this.fieldNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.fieldNameTextBox_Validating);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Enabled = false;
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
            // TableAdapter1
            // 
            this.TableAdapter1.ClearBeforeFill = true;
            // 
            // TableAdapterManager
            // 
            this.TableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.TableAdapterManager.Qds_PaymentMethodsTableAdapter = this.TableAdapter1;
            this.TableAdapterManager.UpdateOrder = Solum.QdsDataSetPaymentMethodsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // PaymentMethods
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(723, 419);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.BindingNavigator1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaymentMethods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PaymentMethods";
            this.Load += new System.EventHandler(this.PaymentMethods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator1)).EndInit();
            this.BindingNavigator1.ResumeLayout(false);
            this.BindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanelGrid.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator BindingNavigator1;
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
        private System.Windows.Forms.ToolStripButton BindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private SirLib.DataGridViewModificada DataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QdsDataSetPaymentMethods DataSet1;
        private System.Windows.Forms.BindingSource BindingSource1;
        private QdsDataSetPaymentMethodsTableAdapters.Qds_PaymentMethodsTableAdapter TableAdapter1;
        private QdsDataSetPaymentMethodsTableAdapters.TableAdapterManager TableAdapterManager;
        private System.Windows.Forms.TextBox fieldIDTextBox;
        private System.Windows.Forms.TextBox fieldNameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
    }
}