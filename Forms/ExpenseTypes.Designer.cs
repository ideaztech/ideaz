namespace Solum
{
    partial class ExpenseTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseTypes));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sol_ExpenseTypes_SelectAllDataGridView = new SirLib.DataGridViewModificada();
            this.expenseTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sol_ExpenseTypes_SelectAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetExpenseTypes = new Solum.DataSetExpenseTypes();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.sol_ExpenseTypes_SelectAllTableAdapter = new Solum.DataSetExpenseTypesTableAdapters.sol_ExpenseTypes_SelectAllTableAdapter();
            this.tableAdapterManager = new Solum.DataSetExpenseTypesTableAdapters.TableAdapterManager();
            this.sol_ExpenseTypes_SelectAllBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ExpenseTypes_SelectAllDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ExpenseTypes_SelectAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExpenseTypes)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ExpenseTypes_SelectAllBindingNavigator)).BeginInit();
            this.sol_ExpenseTypes_SelectAllBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.38147F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.61853F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sol_ExpenseTypes_SelectAllDataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 288);
            this.panel1.TabIndex = 0;
            // 
            // sol_ExpenseTypes_SelectAllDataGridView
            // 
            this.sol_ExpenseTypes_SelectAllDataGridView.AllowUserToAddRows = false;
            this.sol_ExpenseTypes_SelectAllDataGridView.AllowUserToDeleteRows = false;
            this.sol_ExpenseTypes_SelectAllDataGridView.AutoGenerateColumns = false;
            this.sol_ExpenseTypes_SelectAllDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sol_ExpenseTypes_SelectAllDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.expenseTypeIDDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.sol_ExpenseTypes_SelectAllDataGridView.DataSource = this.sol_ExpenseTypes_SelectAllBindingSource;
            this.sol_ExpenseTypes_SelectAllDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sol_ExpenseTypes_SelectAllDataGridView.Location = new System.Drawing.Point(0, 0);
            this.sol_ExpenseTypes_SelectAllDataGridView.Name = "sol_ExpenseTypes_SelectAllDataGridView";
            this.sol_ExpenseTypes_SelectAllDataGridView.RowTemplate.Height = 24;
            this.sol_ExpenseTypes_SelectAllDataGridView.Size = new System.Drawing.Size(718, 288);
            this.sol_ExpenseTypes_SelectAllDataGridView.TabIndex = 0;
            // 
            // expenseTypeIDDataGridViewTextBoxColumn
            // 
            this.expenseTypeIDDataGridViewTextBoxColumn.DataPropertyName = "ExpenseTypeID";
            this.expenseTypeIDDataGridViewTextBoxColumn.HeaderText = "ExpenseTypeID";
            this.expenseTypeIDDataGridViewTextBoxColumn.Name = "expenseTypeIDDataGridViewTextBoxColumn";
            this.expenseTypeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // sol_ExpenseTypes_SelectAllBindingSource
            // 
            this.sol_ExpenseTypes_SelectAllBindingSource.DataMember = "sol_ExpenseTypes_SelectAll";
            this.sol_ExpenseTypes_SelectAllBindingSource.DataSource = this.dataSetExpenseTypes;
            // 
            // dataSetExpenseTypes
            // 
            this.dataSetExpenseTypes.DataSetName = "DataSetExpenseTypes";
            this.dataSetExpenseTypes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OK);
            this.panel2.Controls.Add(this.Cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 67);
            this.panel2.TabIndex = 1;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(273, 20);
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
            this.Cancel.Location = new System.Drawing.Point(370, 20);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 29);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "&Close";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // sol_ExpenseTypes_SelectAllTableAdapter
            // 
            this.sol_ExpenseTypes_SelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.sol_ExpenseTypes_SelectAllTableAdapter = this.sol_ExpenseTypes_SelectAllTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetExpenseTypesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sol_ExpenseTypes_SelectAllBindingNavigator
            // 
            this.sol_ExpenseTypes_SelectAllBindingNavigator.AddNewItem = null;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.BindingSource = this.sol_ExpenseTypes_SelectAllBindingSource;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.DeleteItem = null;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sol_ExpenseTypes_SelectAllBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem,
            this.toolStripButtonVirtualKb});
            this.sol_ExpenseTypes_SelectAllBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.sol_ExpenseTypes_SelectAllBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.Name = "sol_ExpenseTypes_SelectAllBindingNavigator";
            this.sol_ExpenseTypes_SelectAllBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.Size = new System.Drawing.Size(724, 39);
            this.sol_ExpenseTypes_SelectAllBindingNavigator.TabIndex = 1;
            this.sol_ExpenseTypes_SelectAllBindingNavigator.Text = "bindingNavigator1";
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
            // sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem
            // 
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem.Image")));
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem.Name = "sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem";
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem.Size = new System.Drawing.Size(36, 36);
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem.Text = "Save Data";
            this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem.Click += new System.EventHandler(this.sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem_Click);
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
            // ExpenseTypes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(724, 406);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.sol_ExpenseTypes_SelectAllBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExpenseTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expense Types";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Expenses_FormClosing);
            this.Load += new System.EventHandler(this.Expenses_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sol_ExpenseTypes_SelectAllDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_ExpenseTypes_SelectAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExpenseTypes)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sol_ExpenseTypes_SelectAllBindingNavigator)).EndInit();
            this.sol_ExpenseTypes_SelectAllBindingNavigator.ResumeLayout(false);
            this.sol_ExpenseTypes_SelectAllBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DataSetExpenseTypes dataSetExpenseTypes;
        private System.Windows.Forms.BindingSource sol_ExpenseTypes_SelectAllBindingSource;
        private Solum.DataSetExpenseTypesTableAdapters.sol_ExpenseTypes_SelectAllTableAdapter sol_ExpenseTypes_SelectAllTableAdapter;
        private Solum.DataSetExpenseTypesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator sol_ExpenseTypes_SelectAllBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton sol_ExpenseTypes_SelectAllBindingNavigatorSaveItem;
        private System.Windows.Forms.Panel panel1;
        private SirLib.DataGridViewModificada sol_ExpenseTypes_SelectAllDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn expenseTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
    }
}