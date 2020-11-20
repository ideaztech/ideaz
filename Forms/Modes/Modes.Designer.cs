namespace Solum.Forms.Modes
{
    partial class Modes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modes));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelCurrentModeTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelCurrentMode = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.buttonSynchronize = new System.Windows.Forms.Button();
            this.buttonChangeMode = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.listBoxModesAvailables = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTrainingMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelCashTrayRadioButtons = new System.Windows.Forms.Panel();
            this.radioButtonNoCashNeeded = new System.Windows.Forms.RadioButton();
            this.radioButtonUseCashTrayAsExt = new System.Windows.Forms.RadioButton();
            this.radioButtonOpenDedicatedCashTray = new System.Windows.Forms.RadioButton();
            this.panelCashTray = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCashTray = new System.Windows.Forms.ComboBox();
            this.solCashTraysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetCashTraysLookup = new Solum.DataSetCashTraysLookup();
            this.sol_CashTraysTableAdapter = new Solum.DataSetCashTraysLookupTableAdapters.sol_CashTraysTableAdapter();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelCashTrayRadioButtons.SuspendLayout();
            this.panelCashTray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solCashTraysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTraysLookup)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelCurrentModeTitle,
            this.toolStripLabelCurrentMode,
            this.toolStripButtonVirtualKb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1006, 31);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelCurrentModeTitle
            // 
            this.toolStripLabelCurrentModeTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripLabelCurrentModeTitle.Name = "toolStripLabelCurrentModeTitle";
            this.toolStripLabelCurrentModeTitle.Size = new System.Drawing.Size(138, 28);
            this.toolStripLabelCurrentModeTitle.Text = "Current Mode:";
            // 
            // toolStripLabelCurrentMode
            // 
            this.toolStripLabelCurrentMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabelCurrentMode.Name = "toolStripLabelCurrentMode";
            this.toolStripLabelCurrentMode.Size = new System.Drawing.Size(0, 28);
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
            // 
            // buttonSynchronize
            // 
            this.buttonSynchronize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSynchronize.Enabled = false;
            this.buttonSynchronize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSynchronize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSynchronize.Location = new System.Drawing.Point(433, 23);
            this.buttonSynchronize.Name = "buttonSynchronize";
            this.buttonSynchronize.Size = new System.Drawing.Size(129, 50);
            this.buttonSynchronize.TabIndex = 0;
            this.buttonSynchronize.Text = "&Synchronize Off-line Data  ";
            this.buttonSynchronize.UseVisualStyleBackColor = true;
            this.buttonSynchronize.Click += new System.EventHandler(this.buttonSynchronize_Click);
            // 
            // buttonChangeMode
            // 
            this.buttonChangeMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonChangeMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonChangeMode.Location = new System.Drawing.Point(618, 23);
            this.buttonChangeMode.Name = "buttonChangeMode";
            this.buttonChangeMode.Size = new System.Drawing.Size(129, 50);
            this.buttonChangeMode.TabIndex = 1;
            this.buttonChangeMode.Text = "&Change Mode";
            this.buttonChangeMode.UseVisualStyleBackColor = true;
            this.buttonChangeMode.Click += new System.EventHandler(this.buttonChangeMode_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.Red;
            this.buttonExit.Location = new System.Drawing.Point(791, 24);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(101, 50);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // listBoxModesAvailables
            // 
            this.listBoxModesAvailables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxModesAvailables.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxModesAvailables.FormattingEnabled = true;
            this.listBoxModesAvailables.ItemHeight = 26;
            this.listBoxModesAvailables.Location = new System.Drawing.Point(0, 25);
            this.listBoxModesAvailables.Name = "listBoxModesAvailables";
            this.listBoxModesAvailables.Size = new System.Drawing.Size(380, 469);
            this.listBoxModesAvailables.TabIndex = 1;
            this.listBoxModesAvailables.SelectedIndexChanged += new System.EventHandler(this.listBoxModesAvailables_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.labelResult);
            this.panel3.Controls.Add(this.buttonSynchronize);
            this.panel3.Controls.Add(this.buttonChangeMode);
            this.panel3.Controls.Add(this.buttonExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(6, 509);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 91);
            this.panel3.TabIndex = 1;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(6, 38);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 20);
            this.labelResult.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxModesAvailables);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 494);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Modes:";
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTrainingMode});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 691);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1006, 22);
            this.statusStripBottom.TabIndex = 10;
            this.statusStripBottom.Text = "statusStrip1";
            // 
            // toolStripStatusLabelTrainingMode
            // 
            this.toolStripStatusLabelTrainingMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelTrainingMode.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelTrainingMode.Name = "toolStripStatusLabelTrainingMode";
            this.toolStripStatusLabelTrainingMode.Size = new System.Drawing.Size(115, 20);
            this.toolStripStatusLabelTrainingMode.Text = "Training Mode!";
            this.toolStripStatusLabelTrainingMode.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.78365F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.21635F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 71);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.80062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.19938F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 606);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelCashTrayRadioButtons);
            this.panel2.Controls.Add(this.panelCashTray);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(395, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 494);
            this.panel2.TabIndex = 0;
            // 
            // panelCashTrayRadioButtons
            // 
            this.panelCashTrayRadioButtons.Controls.Add(this.radioButtonNoCashNeeded);
            this.panelCashTrayRadioButtons.Controls.Add(this.radioButtonUseCashTrayAsExt);
            this.panelCashTrayRadioButtons.Controls.Add(this.radioButtonOpenDedicatedCashTray);
            this.panelCashTrayRadioButtons.Enabled = false;
            this.panelCashTrayRadioButtons.Location = new System.Drawing.Point(29, 127);
            this.panelCashTrayRadioButtons.Name = "panelCashTrayRadioButtons";
            this.panelCashTrayRadioButtons.Size = new System.Drawing.Size(511, 110);
            this.panelCashTrayRadioButtons.TabIndex = 7;
            // 
            // radioButtonNoCashNeeded
            // 
            this.radioButtonNoCashNeeded.AutoSize = true;
            this.radioButtonNoCashNeeded.Location = new System.Drawing.Point(21, 73);
            this.radioButtonNoCashNeeded.Name = "radioButtonNoCashNeeded";
            this.radioButtonNoCashNeeded.Size = new System.Drawing.Size(463, 24);
            this.radioButtonNoCashNeeded.TabIndex = 2;
            this.radioButtonNoCashNeeded.TabStop = true;
            this.radioButtonNoCashNeeded.Text = "&No Cash needed – all transactions will be On Account only";
            this.radioButtonNoCashNeeded.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseCashTrayAsExt
            // 
            this.radioButtonUseCashTrayAsExt.AutoSize = true;
            this.radioButtonUseCashTrayAsExt.Location = new System.Drawing.Point(21, 42);
            this.radioButtonUseCashTrayAsExt.Name = "radioButtonUseCashTrayAsExt";
            this.radioButtonUseCashTrayAsExt.Size = new System.Drawing.Size(393, 24);
            this.radioButtonUseCashTrayAsExt.TabIndex = 1;
            this.radioButtonUseCashTrayAsExt.TabStop = true;
            this.radioButtonUseCashTrayAsExt.Text = "&Use Cash Tray as an extension On-Line version ";
            this.radioButtonUseCashTrayAsExt.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpenDedicatedCashTray
            // 
            this.radioButtonOpenDedicatedCashTray.AutoSize = true;
            this.radioButtonOpenDedicatedCashTray.Checked = true;
            this.radioButtonOpenDedicatedCashTray.Location = new System.Drawing.Point(21, 12);
            this.radioButtonOpenDedicatedCashTray.Name = "radioButtonOpenDedicatedCashTray";
            this.radioButtonOpenDedicatedCashTray.Size = new System.Drawing.Size(419, 24);
            this.radioButtonOpenDedicatedCashTray.TabIndex = 0;
            this.radioButtonOpenDedicatedCashTray.TabStop = true;
            this.radioButtonOpenDedicatedCashTray.Text = "&Open Dedicated Cash Tray for Off-Site/Off-Line use";
            this.radioButtonOpenDedicatedCashTray.UseVisualStyleBackColor = true;
            // 
            // panelCashTray
            // 
            this.panelCashTray.Controls.Add(this.label2);
            this.panelCashTray.Controls.Add(this.comboBoxCashTray);
            this.panelCashTray.Enabled = false;
            this.panelCashTray.Location = new System.Drawing.Point(29, 25);
            this.panelCashTray.Name = "panelCashTray";
            this.panelCashTray.Size = new System.Drawing.Size(239, 96);
            this.panelCashTray.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "&Cash Tray:";
            // 
            // comboBoxCashTray
            // 
            this.comboBoxCashTray.DataSource = this.solCashTraysBindingSource;
            this.comboBoxCashTray.DisplayMember = "Description";
            this.comboBoxCashTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCashTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCashTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCashTray.FormattingEnabled = true;
            this.comboBoxCashTray.Location = new System.Drawing.Point(21, 48);
            this.comboBoxCashTray.Name = "comboBoxCashTray";
            this.comboBoxCashTray.Size = new System.Drawing.Size(183, 33);
            this.comboBoxCashTray.TabIndex = 5;
            this.comboBoxCashTray.ValueMember = "CashTrayID";
            // 
            // solCashTraysBindingSource
            // 
            this.solCashTraysBindingSource.DataMember = "sol_CashTrays";
            this.solCashTraysBindingSource.DataSource = this.dataSetCashTraysLookup;
            // 
            // dataSetCashTraysLookup
            // 
            this.dataSetCashTraysLookup.DataSetName = "DataSetCashTraysLookup";
            this.dataSetCashTraysLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sol_CashTraysTableAdapter
            // 
            this.sol_CashTraysTableAdapter.ClearBeforeFill = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Modes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1006, 713);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Modes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modes";
            this.Load += new System.EventHandler(this.Modes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelCashTrayRadioButtons.ResumeLayout(false);
            this.panelCashTrayRadioButtons.PerformLayout();
            this.panelCashTray.ResumeLayout(false);
            this.panelCashTray.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solCashTraysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCashTraysLookup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.Button buttonSynchronize;
        private System.Windows.Forms.Button buttonChangeMode;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox listBoxModesAvailables;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrainingMode;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentModeTitle;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentMode;
        private System.Windows.Forms.ComboBox comboBoxCashTray;
        private System.Windows.Forms.Label label2;
        private DataSetCashTraysLookup dataSetCashTraysLookup;
        private System.Windows.Forms.BindingSource solCashTraysBindingSource;
        private DataSetCashTraysLookupTableAdapters.sol_CashTraysTableAdapter sol_CashTraysTableAdapter;
        private System.Windows.Forms.Panel panelCashTrayRadioButtons;
        private System.Windows.Forms.RadioButton radioButtonNoCashNeeded;
        private System.Windows.Forms.RadioButton radioButtonUseCashTrayAsExt;
        private System.Windows.Forms.RadioButton radioButtonOpenDedicatedCashTray;
        private System.Windows.Forms.Panel panelCashTray;
        private System.Windows.Forms.Label labelResult;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}