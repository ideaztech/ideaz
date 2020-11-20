namespace Solum
{
    partial class Fees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fees));
            this.dataSetFees = new Solum.DataSetFees();
            this.sol_Fees_SelectAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sol_Fees_SelectAllTableAdapter = new Solum.DataSetFeesTableAdapters.sol_Fees_SelectAllTableAdapter();
            this.tableAdapterManager = new Solum.DataSetFeesTableAdapters.TableAdapterManager();
            this.sol_Fees_SelectAllBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.sol_Fees_SelectAllBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sol_Fees_SelectAllDataGridView = new SirLib.DataGridViewModificada();
            this.feeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percentage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Fees_SelectAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Fees_SelectAllBindingNavigator)).BeginInit();
            this.sol_Fees_SelectAllBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Fees_SelectAllDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSetFees
            // 
            this.dataSetFees.DataSetName = "DataSetFees";
            this.dataSetFees.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_Fees_SelectAllBindingSource
            // 
            this.sol_Fees_SelectAllBindingSource.DataMember = "sol_Fees_SelectAll";
            this.sol_Fees_SelectAllBindingSource.DataSource = this.dataSetFees;
            // 
            // sol_Fees_SelectAllTableAdapter
            // 
            this.sol_Fees_SelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.sol_Fees_SelectAllTableAdapter = this.sol_Fees_SelectAllTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetFeesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sol_Fees_SelectAllBindingNavigator
            // 
            this.sol_Fees_SelectAllBindingNavigator.AddNewItem = null;
            this.sol_Fees_SelectAllBindingNavigator.BindingSource = this.sol_Fees_SelectAllBindingSource;
            this.sol_Fees_SelectAllBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.sol_Fees_SelectAllBindingNavigator.DeleteItem = null;
            this.sol_Fees_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sol_Fees_SelectAllBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.sol_Fees_SelectAllBindingNavigatorSaveItem,
            this.toolStripButtonVirtualKb});
            this.sol_Fees_SelectAllBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.sol_Fees_SelectAllBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.sol_Fees_SelectAllBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.sol_Fees_SelectAllBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.sol_Fees_SelectAllBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.sol_Fees_SelectAllBindingNavigator.Name = "sol_Fees_SelectAllBindingNavigator";
            this.sol_Fees_SelectAllBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.sol_Fees_SelectAllBindingNavigator.Size = new System.Drawing.Size(724, 39);
            this.sol_Fees_SelectAllBindingNavigator.TabIndex = 0;
            this.sol_Fees_SelectAllBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 36);
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 33);
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
            // sol_Fees_SelectAllBindingNavigatorSaveItem
            // 
            this.sol_Fees_SelectAllBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sol_Fees_SelectAllBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("sol_Fees_SelectAllBindingNavigatorSaveItem.Image")));
            this.sol_Fees_SelectAllBindingNavigatorSaveItem.Name = "sol_Fees_SelectAllBindingNavigatorSaveItem";
            this.sol_Fees_SelectAllBindingNavigatorSaveItem.Size = new System.Drawing.Size(36, 36);
            this.sol_Fees_SelectAllBindingNavigatorSaveItem.Text = "Save Data";
            this.sol_Fees_SelectAllBindingNavigatorSaveItem.Click += new System.EventHandler(this.sol_Fees_SelectAllBindingNavigatorSaveItem_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.sol_Fees_SelectAllDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Panel2.Controls.Add(this.Cancel);
            this.splitContainer1.Size = new System.Drawing.Size(724, 367);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 2;
            // 
            // sol_Fees_SelectAllDataGridView
            // 
            this.sol_Fees_SelectAllDataGridView.AllowUserToAddRows = false;
            this.sol_Fees_SelectAllDataGridView.AllowUserToDeleteRows = false;
            this.sol_Fees_SelectAllDataGridView.AutoGenerateColumns = false;
            this.sol_Fees_SelectAllDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sol_Fees_SelectAllDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.feeIDDataGridViewTextBoxColumn,
            this.feeDescriptionDataGridViewTextBoxColumn,
            this.feeAmountDataGridViewTextBoxColumn,
            this.Percentage});
            this.sol_Fees_SelectAllDataGridView.DataSource = this.sol_Fees_SelectAllBindingSource;
            this.sol_Fees_SelectAllDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sol_Fees_SelectAllDataGridView.Location = new System.Drawing.Point(0, 0);
            this.sol_Fees_SelectAllDataGridView.Name = "sol_Fees_SelectAllDataGridView";
            this.sol_Fees_SelectAllDataGridView.RowTemplate.Height = 24;
            this.sol_Fees_SelectAllDataGridView.Size = new System.Drawing.Size(724, 211);
            this.sol_Fees_SelectAllDataGridView.TabIndex = 3;
            // 
            // feeIDDataGridViewTextBoxColumn
            // 
            this.feeIDDataGridViewTextBoxColumn.DataPropertyName = "FeeID";
            this.feeIDDataGridViewTextBoxColumn.HeaderText = "FeeID";
            this.feeIDDataGridViewTextBoxColumn.Name = "feeIDDataGridViewTextBoxColumn";
            this.feeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // feeDescriptionDataGridViewTextBoxColumn
            // 
            this.feeDescriptionDataGridViewTextBoxColumn.DataPropertyName = "FeeDescription";
            this.feeDescriptionDataGridViewTextBoxColumn.HeaderText = "FeeDescription";
            this.feeDescriptionDataGridViewTextBoxColumn.Name = "feeDescriptionDataGridViewTextBoxColumn";
            // 
            // feeAmountDataGridViewTextBoxColumn
            // 
            this.feeAmountDataGridViewTextBoxColumn.DataPropertyName = "FeeAmount";
            this.feeAmountDataGridViewTextBoxColumn.HeaderText = "FeeAmount";
            this.feeAmountDataGridViewTextBoxColumn.Name = "feeAmountDataGridViewTextBoxColumn";
            // 
            // Percentage
            // 
            this.Percentage.DataPropertyName = "Percentage";
            this.Percentage.HeaderText = "Percentage";
            this.Percentage.Name = "Percentage";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(276, 11);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 29);
            this.OK.TabIndex = 7;
            this.OK.Text = "&Update";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(373, 11);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 29);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "&Close";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Fees
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(724, 406);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sol_Fees_SelectAllBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fees";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fees_FormClosing);
            this.Load += new System.EventHandler(this.Fees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Fees_SelectAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Fees_SelectAllBindingNavigator)).EndInit();
            this.sol_Fees_SelectAllBindingNavigator.ResumeLayout(false);
            this.sol_Fees_SelectAllBindingNavigator.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sol_Fees_SelectAllDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetFees dataSetFees;
        private System.Windows.Forms.BindingSource sol_Fees_SelectAllBindingSource;
        private Solum.DataSetFeesTableAdapters.sol_Fees_SelectAllTableAdapter sol_Fees_SelectAllTableAdapter;
        private Solum.DataSetFeesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator sol_Fees_SelectAllBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton sol_Fees_SelectAllBindingNavigatorSaveItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SirLib.DataGridViewModificada sol_Fees_SelectAllDataGridView;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Percentage;
    }
}