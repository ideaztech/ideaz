namespace Solum
{
    partial class ShippingShipmentsInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShippingShipmentsInventory));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelUnstagedProductsTotals = new System.Windows.Forms.Panel();
            this.panelFooterLeft = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.panelUnstagedProducts = new System.Windows.Forms.Panel();
            this.dataGridViewShippingContainers = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContainerID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.solContainersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetContainersLookup = new Solum.DataSetContainersLookup();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empty = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.sol_ContainersTableAdapter = new Solum.DataSetContainersLookupTableAdapters.sol_ContainersTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFooterLeft.SuspendLayout();
            this.panelUnstagedProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingContainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solContainersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetContainersLookup)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panelUnstagedProductsTotals, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelFooterLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelUnstagedProducts, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.75969F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.24031F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(899, 603);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panelUnstagedProductsTotals
            // 
            this.panelUnstagedProductsTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProductsTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProductsTotals.Location = new System.Drawing.Point(6, 472);
            this.panelUnstagedProductsTotals.Name = "panelUnstagedProductsTotals";
            this.panelUnstagedProductsTotals.Size = new System.Drawing.Size(887, 52);
            this.panelUnstagedProductsTotals.TabIndex = 2;
            // 
            // panelFooterLeft
            // 
            this.panelFooterLeft.Controls.Add(this.OK);
            this.panelFooterLeft.Controls.Add(this.Cancel);
            this.panelFooterLeft.Controls.Add(this.buttonDeleteRow);
            this.panelFooterLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFooterLeft.Location = new System.Drawing.Point(6, 533);
            this.panelFooterLeft.Name = "panelFooterLeft";
            this.panelFooterLeft.Size = new System.Drawing.Size(887, 64);
            this.panelFooterLeft.TabIndex = 4;
            // 
            // OK
            // 
            this.OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OK.Location = new System.Drawing.Point(200, 8);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(129, 50);
            this.OK.TabIndex = 6;
            this.OK.Text = "&Confirm";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.Color.Red;
            this.Cancel.Location = new System.Drawing.Point(558, 8);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(129, 50);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "&Back";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteRow.Location = new System.Drawing.Point(379, 8);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(129, 50);
            this.buttonDeleteRow.TabIndex = 5;
            this.buttonDeleteRow.Text = "&Delete Row";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // panelUnstagedProducts
            // 
            this.panelUnstagedProducts.Controls.Add(this.dataGridViewShippingContainers);
            this.panelUnstagedProducts.Controls.Add(this.label1);
            this.panelUnstagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProducts.Location = new System.Drawing.Point(6, 6);
            this.panelUnstagedProducts.Name = "panelUnstagedProducts";
            this.panelUnstagedProducts.Size = new System.Drawing.Size(887, 457);
            this.panelUnstagedProducts.TabIndex = 0;
            // 
            // dataGridViewShippingContainers
            // 
            this.dataGridViewShippingContainers.AllowUserToAddRows = false;
            this.dataGridViewShippingContainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShippingContainers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.ContainerID,
            this.Quantity,
            this.Empty,
            this.ProductID});
            this.dataGridViewShippingContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShippingContainers.Location = new System.Drawing.Point(0, 52);
            this.dataGridViewShippingContainers.Name = "dataGridViewShippingContainers";
            this.dataGridViewShippingContainers.RowTemplate.Height = 24;
            this.dataGridViewShippingContainers.Size = new System.Drawing.Size(887, 405);
            this.dataGridViewShippingContainers.TabIndex = 2;
            this.dataGridViewShippingContainers.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridViewShippingContainers_CellValueNeeded);
            this.dataGridViewShippingContainers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewShippingContainers_DataError);
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product.Width = 300;
            // 
            // ContainerID
            // 
            this.ContainerID.DataSource = this.solContainersBindingSource;
            this.ContainerID.DisplayMember = "Description";
            this.ContainerID.DisplayStyleForCurrentCellOnly = true;
            this.ContainerID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContainerID.HeaderText = "Container";
            this.ContainerID.Name = "ContainerID";
            this.ContainerID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ContainerID.ValueMember = "ContainerID";
            this.ContainerID.Width = 300;
            // 
            // solContainersBindingSource
            // 
            this.solContainersBindingSource.DataMember = "sol_Containers";
            this.solContainersBindingSource.DataSource = this.dataSetContainersLookup;
            // 
            // dataSetContainersLookup
            // 
            this.dataSetContainersLookup.DataSetName = "DataSetContainersLookup";
            this.dataSetContainersLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 140;
            // 
            // Empty
            // 
            this.Empty.HeaderText = "Empty";
            this.Empty.Name = "Empty";
            this.Empty.ReadOnly = true;
            this.Empty.Visible = false;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(887, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please confirm the shipping containers used for this shipment:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(899, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // toolStripButtonVirtualKb
            // 
            this.toolStripButtonVirtualKb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonVirtualKb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVirtualKb.Image = global::Solum.Properties.Resources.kxkb;
            this.toolStripButtonVirtualKb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVirtualKb.Name = "toolStripButtonVirtualKb";
            this.toolStripButtonVirtualKb.Size = new System.Drawing.Size(68, 68);
            this.toolStripButtonVirtualKb.Text = "Virtual Keyboard";
            this.toolStripButtonVirtualKb.Visible = false;
            this.toolStripButtonVirtualKb.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // sol_ContainersTableAdapter
            // 
            this.sol_ContainersTableAdapter.ClearBeforeFill = true;
            // 
            // ShippingShipmentsInventory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(899, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShippingShipmentsInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shipping Containers Inventory";
            this.Load += new System.EventHandler(this.ShippingShipmentsInventory_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelFooterLeft.ResumeLayout(false);
            this.panelUnstagedProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingContainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solContainersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetContainersLookup)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelUnstagedProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelUnstagedProductsTotals;
        private System.Windows.Forms.Panel panelFooterLeft;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.DataGridView dataGridViewShippingContainers;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private DataSetContainersLookup dataSetContainersLookup;
        private System.Windows.Forms.BindingSource solContainersBindingSource;
        private DataSetContainersLookupTableAdapters.sol_ContainersTableAdapter sol_ContainersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewComboBoxColumn ContainerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Empty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
    }
}