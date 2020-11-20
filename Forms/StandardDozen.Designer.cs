namespace Solum
{
    partial class StandardDozen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandardDozen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataSetStandardDozenLookup = new Solum.DataSetStandardDozenLookup();
            this.sol_StandardDozenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sol_StandardDozenTableAdapter = new Solum.DataSetStandardDozenLookupTableAdapters.sol_StandardDozenTableAdapter();
            this.tableAdapterManager = new Solum.DataSetStandardDozenLookupTableAdapters.TableAdapterManager();
            this.sol_StandardDozenBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.sol_StandardDozenBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sol_StandardDozenDataGridView = new SirLib.DataGridViewModificada();
            this.standardDozenIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStandardDozenLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_StandardDozenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_StandardDozenBindingNavigator)).BeginInit();
            this.sol_StandardDozenBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_StandardDozenDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSetStandardDozenLookup
            // 
            this.dataSetStandardDozenLookup.DataSetName = "DataSetStandardDozenLookup";
            this.dataSetStandardDozenLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_StandardDozenBindingSource
            // 
            this.sol_StandardDozenBindingSource.DataMember = "sol_StandardDozen";
            this.sol_StandardDozenBindingSource.DataSource = this.dataSetStandardDozenLookup;
            // 
            // sol_StandardDozenTableAdapter
            // 
            this.sol_StandardDozenTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.sol_StandardDozenTableAdapter = this.sol_StandardDozenTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetStandardDozenLookupTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sol_StandardDozenBindingNavigator
            // 
            this.sol_StandardDozenBindingNavigator.AddNewItem = null;
            this.sol_StandardDozenBindingNavigator.BindingSource = this.sol_StandardDozenBindingSource;
            this.sol_StandardDozenBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.sol_StandardDozenBindingNavigator.DeleteItem = null;
            this.sol_StandardDozenBindingNavigator.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sol_StandardDozenBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.sol_StandardDozenBindingNavigatorSaveItem,
            this.toolStripButtonVirtualKb});
            this.sol_StandardDozenBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.sol_StandardDozenBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.sol_StandardDozenBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.sol_StandardDozenBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.sol_StandardDozenBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.sol_StandardDozenBindingNavigator.Name = "sol_StandardDozenBindingNavigator";
            this.sol_StandardDozenBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.sol_StandardDozenBindingNavigator.Size = new System.Drawing.Size(724, 39);
            this.sol_StandardDozenBindingNavigator.TabIndex = 0;
            this.sol_StandardDozenBindingNavigator.Text = "bindingNavigator1";
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
            // sol_StandardDozenBindingNavigatorSaveItem
            // 
            this.sol_StandardDozenBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sol_StandardDozenBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("sol_StandardDozenBindingNavigatorSaveItem.Image")));
            this.sol_StandardDozenBindingNavigatorSaveItem.Name = "sol_StandardDozenBindingNavigatorSaveItem";
            this.sol_StandardDozenBindingNavigatorSaveItem.Size = new System.Drawing.Size(36, 36);
            this.sol_StandardDozenBindingNavigatorSaveItem.Text = "Save Data";
            this.sol_StandardDozenBindingNavigatorSaveItem.Click += new System.EventHandler(this.sol_StandardDozenBindingNavigatorSaveItem_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.sol_StandardDozenDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Panel2.Controls.Add(this.Cancel);
            this.splitContainer1.Size = new System.Drawing.Size(724, 372);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 2;
            // 
            // sol_StandardDozenDataGridView
            // 
            this.sol_StandardDozenDataGridView.AllowUserToAddRows = false;
            this.sol_StandardDozenDataGridView.AllowUserToDeleteRows = false;
            this.sol_StandardDozenDataGridView.AutoGenerateColumns = false;
            this.sol_StandardDozenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sol_StandardDozenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.standardDozenIDDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.sol_StandardDozenDataGridView.DataSource = this.sol_StandardDozenBindingSource;
            this.sol_StandardDozenDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sol_StandardDozenDataGridView.Location = new System.Drawing.Point(0, 0);
            this.sol_StandardDozenDataGridView.Name = "sol_StandardDozenDataGridView";
            this.sol_StandardDozenDataGridView.RowTemplate.Height = 24;
            this.sol_StandardDozenDataGridView.Size = new System.Drawing.Size(724, 313);
            this.sol_StandardDozenDataGridView.TabIndex = 0;
            // 
            // standardDozenIDDataGridViewTextBoxColumn
            // 
            this.standardDozenIDDataGridViewTextBoxColumn.DataPropertyName = "StandardDozenID";
            this.standardDozenIDDataGridViewTextBoxColumn.HeaderText = "StandardDozenID";
            this.standardDozenIDDataGridViewTextBoxColumn.Name = "standardDozenIDDataGridViewTextBoxColumn";
            this.standardDozenIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(276, 13);
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
            this.Cancel.Location = new System.Drawing.Point(373, 13);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 29);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "&Close";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // StandardDozen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(724, 411);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sol_StandardDozenBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StandardDozen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StandardDozen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StandardDozen_FormClosing);
            this.Load += new System.EventHandler(this.StandardDozen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStandardDozenLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_StandardDozenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_StandardDozenBindingNavigator)).EndInit();
            this.sol_StandardDozenBindingNavigator.ResumeLayout(false);
            this.sol_StandardDozenBindingNavigator.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sol_StandardDozenDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetStandardDozenLookup dataSetStandardDozenLookup;
        private System.Windows.Forms.BindingSource sol_StandardDozenBindingSource;
        private Solum.DataSetStandardDozenLookupTableAdapters.sol_StandardDozenTableAdapter sol_StandardDozenTableAdapter;
        private Solum.DataSetStandardDozenLookupTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator sol_StandardDozenBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton sol_StandardDozenBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SirLib.DataGridViewModificada sol_StandardDozenDataGridView;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn standardDozenIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}