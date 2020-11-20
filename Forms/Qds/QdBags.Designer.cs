namespace Solum
{
    partial class QdBags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QdBags));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.radioButtonMineOnly = new System.Windows.Forms.RadioButton();
            this.radioButtonShowAll = new System.Windows.Forms.RadioButton();
            this.listViewDrops = new System.Windows.Forms.ListView();
            this.panelDropHeader = new System.Windows.Forms.Panel();
            this.panelDrops = new System.Windows.Forms.Panel();
            this.panelDropFooter = new System.Windows.Forms.Panel();
            this.buttonMissingBags = new System.Windows.Forms.Button();
            this.checkBoxMissingBags = new System.Windows.Forms.CheckBox();
            this.buttonBags = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panelBags = new System.Windows.Forms.Panel();
            this.panelBagsFooter = new System.Windows.Forms.Panel();
            this.buttonBagsMissingBags = new System.Windows.Forms.Button();
            this.labelUsedBags = new System.Windows.Forms.Label();
            this.buttonBagsSelect = new System.Windows.Forms.Button();
            this.buttonBagsClose = new System.Windows.Forms.Button();
            this.buttonBagsRefresh = new System.Windows.Forms.Button();
            this.radioButtonBagsUnused = new System.Windows.Forms.RadioButton();
            this.radioButtonBagsShowAll = new System.Windows.Forms.RadioButton();
            this.listViewBags = new System.Windows.Forms.ListView();
            this.panelBagsHeader = new System.Windows.Forms.Panel();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDropID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelDrops.SuspendLayout();
            this.panelDropFooter.SuspendLayout();
            this.panelBags.SuspendLayout();
            this.panelBagsFooter.SuspendLayout();
            this.panelBagsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(983, 71);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Solum.Properties.Resources.QDIcon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 68);
            this.toolStripButton1.Text = "toolStripButtonQds";
            this.toolStripButton1.ToolTipText = "QuickDrop Bags InProcess";
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
            this.toolStripButtonVirtualKb.Click += new System.EventHandler(this.toolStripButtonVirtualKb_Click);
            // 
            // radioButtonMineOnly
            // 
            this.radioButtonMineOnly.AutoSize = true;
            this.radioButtonMineOnly.Location = new System.Drawing.Point(131, 19);
            this.radioButtonMineOnly.Name = "radioButtonMineOnly";
            this.radioButtonMineOnly.Size = new System.Drawing.Size(92, 21);
            this.radioButtonMineOnly.TabIndex = 1;
            this.radioButtonMineOnly.Text = "&Mine Only";
            this.radioButtonMineOnly.UseVisualStyleBackColor = true;
            this.radioButtonMineOnly.CheckedChanged += new System.EventHandler(this.radioButtonBagsShowAll_CheckedChanged);
            // 
            // radioButtonShowAll
            // 
            this.radioButtonShowAll.AutoSize = true;
            this.radioButtonShowAll.Location = new System.Drawing.Point(25, 19);
            this.radioButtonShowAll.Name = "radioButtonShowAll";
            this.radioButtonShowAll.Size = new System.Drawing.Size(82, 21);
            this.radioButtonShowAll.TabIndex = 0;
            this.radioButtonShowAll.Text = "&Show All";
            this.radioButtonShowAll.UseVisualStyleBackColor = true;
            this.radioButtonShowAll.CheckedChanged += new System.EventHandler(this.radioButtonShowAll_CheckedChanged);
            // 
            // listViewDrops
            // 
            this.listViewDrops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDrops.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewDrops.Location = new System.Drawing.Point(3, 80);
            this.listViewDrops.Name = "listViewDrops";
            this.listViewDrops.Size = new System.Drawing.Size(968, 245);
            this.listViewDrops.TabIndex = 1;
            this.listViewDrops.UseCompatibleStateImageBehavior = false;
            this.listViewDrops.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewDrop_ColumnClick);
            this.listViewDrops.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewDrop_ItemChecked);
            this.listViewDrops.SelectedIndexChanged += new System.EventHandler(this.listViewDrops_SelectedIndexChanged);
            // 
            // panelDropHeader
            // 
            this.panelDropHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDropHeader.Location = new System.Drawing.Point(3, 3);
            this.panelDropHeader.Name = "panelDropHeader";
            this.panelDropHeader.Size = new System.Drawing.Size(977, 71);
            this.panelDropHeader.TabIndex = 0;
            // 
            // panelDrops
            // 
            this.panelDrops.Controls.Add(this.panelDropFooter);
            this.panelDrops.Controls.Add(this.listViewDrops);
            this.panelDrops.Controls.Add(this.panelDropHeader);
            this.panelDrops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrops.Location = new System.Drawing.Point(0, 71);
            this.panelDrops.Name = "panelDrops";
            this.panelDrops.Size = new System.Drawing.Size(983, 431);
            this.panelDrops.TabIndex = 16;
            this.panelDrops.Visible = false;
            // 
            // panelDropFooter
            // 
            this.panelDropFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDropFooter.Controls.Add(this.buttonMissingBags);
            this.panelDropFooter.Controls.Add(this.checkBoxMissingBags);
            this.panelDropFooter.Controls.Add(this.buttonBags);
            this.panelDropFooter.Controls.Add(this.OK);
            this.panelDropFooter.Controls.Add(this.Cancel);
            this.panelDropFooter.Controls.Add(this.buttonRefresh);
            this.panelDropFooter.Controls.Add(this.radioButtonMineOnly);
            this.panelDropFooter.Controls.Add(this.radioButtonShowAll);
            this.panelDropFooter.Location = new System.Drawing.Point(3, 331);
            this.panelDropFooter.Name = "panelDropFooter";
            this.panelDropFooter.Size = new System.Drawing.Size(977, 97);
            this.panelDropFooter.TabIndex = 1;
            // 
            // buttonMissingBags
            // 
            this.buttonMissingBags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMissingBags.ForeColor = System.Drawing.Color.Red;
            this.buttonMissingBags.Location = new System.Drawing.Point(850, 19);
            this.buttonMissingBags.Name = "buttonMissingBags";
            this.buttonMissingBags.Size = new System.Drawing.Size(113, 61);
            this.buttonMissingBags.TabIndex = 11;
            this.buttonMissingBags.Text = "&Complete Order";
            this.buttonMissingBags.UseVisualStyleBackColor = true;
            this.buttonMissingBags.Click += new System.EventHandler(this.buttonMissingBags_Click);
            // 
            // checkBoxMissingBags
            // 
            this.checkBoxMissingBags.AutoSize = true;
            this.checkBoxMissingBags.Location = new System.Drawing.Point(25, 52);
            this.checkBoxMissingBags.Name = "checkBoxMissingBags";
            this.checkBoxMissingBags.Size = new System.Drawing.Size(113, 21);
            this.checkBoxMissingBags.TabIndex = 10;
            this.checkBoxMissingBags.Text = "&Missing Bags";
            this.checkBoxMissingBags.UseVisualStyleBackColor = true;
            this.checkBoxMissingBags.CheckedChanged += new System.EventHandler(this.radioButtonShowAll_CheckedChanged);
            // 
            // buttonBags
            // 
            this.buttonBags.Location = new System.Drawing.Point(487, 19);
            this.buttonBags.Name = "buttonBags";
            this.buttonBags.Size = new System.Drawing.Size(113, 29);
            this.buttonBags.TabIndex = 7;
            this.buttonBags.Text = "&Bags";
            this.buttonBags.UseVisualStyleBackColor = true;
            this.buttonBags.Click += new System.EventHandler(this.buttonBags_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(366, 19);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(113, 29);
            this.OK.TabIndex = 6;
            this.OK.Text = "&Select";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Visible = false;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(729, 19);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(113, 29);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "&Close";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(608, 19);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(113, 29);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "&Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // panelBags
            // 
            this.panelBags.Controls.Add(this.panelBagsFooter);
            this.panelBags.Controls.Add(this.listViewBags);
            this.panelBags.Controls.Add(this.panelBagsHeader);
            this.panelBags.Location = new System.Drawing.Point(477, 71);
            this.panelBags.Name = "panelBags";
            this.panelBags.Size = new System.Drawing.Size(461, 272);
            this.panelBags.TabIndex = 17;
            this.panelBags.Visible = false;
            // 
            // panelBagsFooter
            // 
            this.panelBagsFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBagsFooter.Controls.Add(this.buttonBagsMissingBags);
            this.panelBagsFooter.Controls.Add(this.labelUsedBags);
            this.panelBagsFooter.Controls.Add(this.buttonBagsSelect);
            this.panelBagsFooter.Controls.Add(this.buttonBagsClose);
            this.panelBagsFooter.Controls.Add(this.buttonBagsRefresh);
            this.panelBagsFooter.Controls.Add(this.radioButtonBagsUnused);
            this.panelBagsFooter.Controls.Add(this.radioButtonBagsShowAll);
            this.panelBagsFooter.Location = new System.Drawing.Point(3, 172);
            this.panelBagsFooter.Name = "panelBagsFooter";
            this.panelBagsFooter.Size = new System.Drawing.Size(458, 97);
            this.panelBagsFooter.TabIndex = 1;
            // 
            // buttonBagsMissingBags
            // 
            this.buttonBagsMissingBags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBagsMissingBags.ForeColor = System.Drawing.Color.Red;
            this.buttonBagsMissingBags.Location = new System.Drawing.Point(834, 19);
            this.buttonBagsMissingBags.Name = "buttonBagsMissingBags";
            this.buttonBagsMissingBags.Size = new System.Drawing.Size(113, 61);
            this.buttonBagsMissingBags.TabIndex = 12;
            this.buttonBagsMissingBags.Text = "&Complete Order";
            this.buttonBagsMissingBags.UseVisualStyleBackColor = true;
            this.buttonBagsMissingBags.Click += new System.EventHandler(this.buttonBagsMissingBags_Click);
            // 
            // labelUsedBags
            // 
            this.labelUsedBags.AutoSize = true;
            this.labelUsedBags.Location = new System.Drawing.Point(33, 55);
            this.labelUsedBags.Name = "labelUsedBags";
            this.labelUsedBags.Size = new System.Drawing.Size(178, 17);
            this.labelUsedBags.TabIndex = 10;
            this.labelUsedBags.Text = "Counted bags are disabled";
            // 
            // buttonBagsSelect
            // 
            this.buttonBagsSelect.Location = new System.Drawing.Point(408, 19);
            this.buttonBagsSelect.Name = "buttonBagsSelect";
            this.buttonBagsSelect.Size = new System.Drawing.Size(110, 29);
            this.buttonBagsSelect.TabIndex = 6;
            this.buttonBagsSelect.Text = "&Select";
            this.buttonBagsSelect.UseVisualStyleBackColor = true;
            this.buttonBagsSelect.Click += new System.EventHandler(this.buttonBagsSelect_Click);
            // 
            // buttonBagsClose
            // 
            this.buttonBagsClose.Location = new System.Drawing.Point(708, 19);
            this.buttonBagsClose.Name = "buttonBagsClose";
            this.buttonBagsClose.Size = new System.Drawing.Size(110, 29);
            this.buttonBagsClose.TabIndex = 9;
            this.buttonBagsClose.Text = "&Close";
            this.buttonBagsClose.UseVisualStyleBackColor = true;
            this.buttonBagsClose.Click += new System.EventHandler(this.buttonBagsClose_Click);
            // 
            // buttonBagsRefresh
            // 
            this.buttonBagsRefresh.Location = new System.Drawing.Point(558, 19);
            this.buttonBagsRefresh.Name = "buttonBagsRefresh";
            this.buttonBagsRefresh.Size = new System.Drawing.Size(110, 29);
            this.buttonBagsRefresh.TabIndex = 8;
            this.buttonBagsRefresh.Text = "&Refresh";
            this.buttonBagsRefresh.UseVisualStyleBackColor = true;
            // 
            // radioButtonBagsUnused
            // 
            this.radioButtonBagsUnused.AutoSize = true;
            this.radioButtonBagsUnused.Location = new System.Drawing.Point(136, 19);
            this.radioButtonBagsUnused.Name = "radioButtonBagsUnused";
            this.radioButtonBagsUnused.Size = new System.Drawing.Size(142, 21);
            this.radioButtonBagsUnused.TabIndex = 1;
            this.radioButtonBagsUnused.Text = "&Show not counted";
            this.radioButtonBagsUnused.UseVisualStyleBackColor = true;
            this.radioButtonBagsUnused.CheckedChanged += new System.EventHandler(this.radioButtonBagsShowAll_CheckedChanged);
            // 
            // radioButtonBagsShowAll
            // 
            this.radioButtonBagsShowAll.AutoSize = true;
            this.radioButtonBagsShowAll.Location = new System.Drawing.Point(25, 19);
            this.radioButtonBagsShowAll.Name = "radioButtonBagsShowAll";
            this.radioButtonBagsShowAll.Size = new System.Drawing.Size(82, 21);
            this.radioButtonBagsShowAll.TabIndex = 0;
            this.radioButtonBagsShowAll.Text = "&Show All";
            this.radioButtonBagsShowAll.UseVisualStyleBackColor = true;
            this.radioButtonBagsShowAll.CheckedChanged += new System.EventHandler(this.radioButtonBagsShowAll_CheckedChanged);
            // 
            // listViewBags
            // 
            this.listViewBags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBags.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBags.Location = new System.Drawing.Point(3, 80);
            this.listViewBags.Name = "listViewBags";
            this.listViewBags.Size = new System.Drawing.Size(425, 90);
            this.listViewBags.TabIndex = 1;
            this.listViewBags.UseCompatibleStateImageBehavior = false;
            this.listViewBags.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewBags_ColumnClick);
            this.listViewBags.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewBags_ItemChecked);
            this.listViewBags.SelectedIndexChanged += new System.EventHandler(this.listViewBags_SelectedIndexChanged);
            // 
            // panelBagsHeader
            // 
            this.panelBagsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBagsHeader.Controls.Add(this.textBoxCustomer);
            this.panelBagsHeader.Controls.Add(this.label2);
            this.panelBagsHeader.Controls.Add(this.textBoxDropID);
            this.panelBagsHeader.Controls.Add(this.label1);
            this.panelBagsHeader.Location = new System.Drawing.Point(3, 3);
            this.panelBagsHeader.Name = "panelBagsHeader";
            this.panelBagsHeader.Size = new System.Drawing.Size(455, 71);
            this.panelBagsHeader.TabIndex = 0;
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Location = new System.Drawing.Point(388, 17);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.ReadOnly = true;
            this.textBoxCustomer.Size = new System.Drawing.Size(430, 22);
            this.textBoxCustomer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer:";
            // 
            // textBoxDropID
            // 
            this.textBoxDropID.Location = new System.Drawing.Point(144, 17);
            this.textBoxDropID.Name = "textBoxDropID";
            this.textBoxDropID.ReadOnly = true;
            this.textBoxDropID.Size = new System.Drawing.Size(130, 22);
            this.textBoxDropID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drop #:";
            // 
            // QdBags
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(983, 502);
            this.Controls.Add(this.panelDrops);
            this.Controls.Add(this.panelBags);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QdBags";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QuickDrop Bags InProcess";
            this.Load += new System.EventHandler(this.QdBags_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelDrops.ResumeLayout(false);
            this.panelDropFooter.ResumeLayout(false);
            this.panelDropFooter.PerformLayout();
            this.panelBags.ResumeLayout(false);
            this.panelBagsFooter.ResumeLayout(false);
            this.panelBagsFooter.PerformLayout();
            this.panelBagsHeader.ResumeLayout(false);
            this.panelBagsHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.RadioButton radioButtonMineOnly;
        private System.Windows.Forms.RadioButton radioButtonShowAll;
        private System.Windows.Forms.ListView listViewDrops;
        private System.Windows.Forms.Panel panelDropHeader;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panelDrops;
        private System.Windows.Forms.Panel panelDropFooter;
        private System.Windows.Forms.Button buttonBags;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Panel panelBags;
        private System.Windows.Forms.Panel panelBagsFooter;
        private System.Windows.Forms.Button buttonBagsSelect;
        private System.Windows.Forms.Button buttonBagsClose;
        private System.Windows.Forms.Button buttonBagsRefresh;
        private System.Windows.Forms.RadioButton radioButtonBagsUnused;
        private System.Windows.Forms.RadioButton radioButtonBagsShowAll;
        private System.Windows.Forms.ListView listViewBags;
        private System.Windows.Forms.Panel panelBagsHeader;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDropID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUsedBags;
        private System.Windows.Forms.CheckBox checkBoxMissingBags;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button buttonMissingBags;
        private System.Windows.Forms.Button buttonBagsMissingBags;
    }
}