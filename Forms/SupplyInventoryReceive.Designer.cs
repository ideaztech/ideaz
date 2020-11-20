namespace Solum
{
    partial class SupplyInventoryReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyInventoryReceive));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelUnstagedProductsTotals = new System.Windows.Forms.Panel();
            this.panelFooterLeft = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.panelUnstagedProducts = new System.Windows.Forms.Panel();
            this.dataGridViewShippingContainers = new System.Windows.Forms.DataGridView();
            this.ContainerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContainerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxReference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFooterLeft.SuspendLayout();
            this.panelUnstagedProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingContainers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 25);
            this.toolStrip1.TabIndex = 0;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 603);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelUnstagedProductsTotals
            // 
            this.panelUnstagedProductsTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProductsTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProductsTotals.Location = new System.Drawing.Point(6, 472);
            this.panelUnstagedProductsTotals.Name = "panelUnstagedProductsTotals";
            this.panelUnstagedProductsTotals.Size = new System.Drawing.Size(768, 52);
            this.panelUnstagedProductsTotals.TabIndex = 0;
            // 
            // panelFooterLeft
            // 
            this.panelFooterLeft.Controls.Add(this.OK);
            this.panelFooterLeft.Controls.Add(this.Cancel);
            this.panelFooterLeft.Controls.Add(this.buttonDeleteRow);
            this.panelFooterLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFooterLeft.Location = new System.Drawing.Point(6, 533);
            this.panelFooterLeft.Name = "panelFooterLeft";
            this.panelFooterLeft.Size = new System.Drawing.Size(768, 64);
            this.panelFooterLeft.TabIndex = 1;
            // 
            // OK
            // 
            this.OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OK.Location = new System.Drawing.Point(107, 8);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(129, 50);
            this.OK.TabIndex = 0;
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
            this.Cancel.Location = new System.Drawing.Point(465, 8);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(129, 50);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "&Back";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteRow.Location = new System.Drawing.Point(286, 8);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(129, 50);
            this.buttonDeleteRow.TabIndex = 1;
            this.buttonDeleteRow.Text = "&Delete Row";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // panelUnstagedProducts
            // 
            this.panelUnstagedProducts.Controls.Add(this.dataGridViewShippingContainers);
            this.panelUnstagedProducts.Controls.Add(this.panel1);
            this.panelUnstagedProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnstagedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUnstagedProducts.Location = new System.Drawing.Point(6, 6);
            this.panelUnstagedProducts.Name = "panelUnstagedProducts";
            this.panelUnstagedProducts.Size = new System.Drawing.Size(768, 457);
            this.panelUnstagedProducts.TabIndex = 0;
            // 
            // dataGridViewShippingContainers
            // 
            this.dataGridViewShippingContainers.AllowUserToAddRows = false;
            this.dataGridViewShippingContainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShippingContainers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContainerID,
            this.ContainerName,
            this.Quantity,
            this.Reference});
            this.dataGridViewShippingContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShippingContainers.Location = new System.Drawing.Point(0, 45);
            this.dataGridViewShippingContainers.Name = "dataGridViewShippingContainers";
            this.dataGridViewShippingContainers.RowTemplate.Height = 24;
            this.dataGridViewShippingContainers.Size = new System.Drawing.Size(768, 412);
            this.dataGridViewShippingContainers.TabIndex = 1;
            // 
            // ContainerID
            // 
            this.ContainerID.HeaderText = "ContainerID";
            this.ContainerID.Name = "ContainerID";
            this.ContainerID.Visible = false;
            // 
            // ContainerName
            // 
            this.ContainerName.HeaderText = "Container";
            this.ContainerName.Name = "ContainerName";
            this.ContainerName.ReadOnly = true;
            this.ContainerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ContainerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ContainerName.Width = 300;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 140;
            // 
            // Reference
            // 
            this.Reference.HeaderText = "Reference";
            this.Reference.MaxInputLength = 100;
            this.Reference.Name = "Reference";
            this.Reference.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxReference);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 45);
            this.panel1.TabIndex = 0;
            // 
            // textBoxReference
            // 
            this.textBoxReference.Location = new System.Drawing.Point(487, 7);
            this.textBoxReference.Name = "textBoxReference";
            this.textBoxReference.Size = new System.Drawing.Size(279, 23);
            this.textBoxReference.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter received supplies:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Reference Number:";
            // 
            // SupplyInventoryReceive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(780, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SupplyInventoryReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Received Inventory Supplies";
            this.Load += new System.EventHandler(this.SupplyInventoryReceive_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelFooterLeft.ResumeLayout(false);
            this.panelUnstagedProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingContainers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelUnstagedProductsTotals;
        private System.Windows.Forms.Panel panelFooterLeft;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.Panel panelUnstagedProducts;
        private System.Windows.Forms.DataGridView dataGridViewShippingContainers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContainerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContainerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}