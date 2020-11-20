
namespace Solum
{
    partial class Products
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
            System.Windows.Forms.Label isActiveLabel;
            System.Windows.Forms.Label menuOrderLabel;
            System.Windows.Forms.Label proImageLabel;
            System.Windows.Forms.Label proDescriptionLabel;
            System.Windows.Forms.Label proNameLabel;
            System.Windows.Forms.Label productIDLabel;
            System.Windows.Forms.Label refundAmountLabel;
            System.Windows.Forms.Label containerIDLabel;
            System.Windows.Forms.Label standardDozenIDLabel;
            System.Windows.Forms.Label categoryIDLabel;
            System.Windows.Forms.Label agencyIDLabel;
            System.Windows.Forms.Label uPCLabel;
            System.Windows.Forms.Label productCodeLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label handlingCommissionAmountLabel;
            System.Windows.Forms.Label vafAmountLabel;
            System.Windows.Forms.Label tax1ExemptLabel;
            System.Windows.Forms.Label tax2ExemptLabel;
            System.Windows.Forms.Label typeIdLabel;
            System.Windows.Forms.Label masterProductIDLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label targetQuantityLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sol_Products_SelectAllBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.sol_Products_SelectAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetProducts = new Solum.DataSetProducts();
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
            this.sol_Products_SelectAllBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVirtualKb = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.sol_Products_SelectAllDataGridView = new SirLib.DataGridViewModificada();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proShortDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.menuOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.categoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sol_CategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetCategoriesLookup = new Solum.DataSetCategoriesLookup();
            this.commissionUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.containerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standardDozenIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refundAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlingCommissionAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vafAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tax1Exempt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tax2Exempt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MasterProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.targetQuantityTextBox = new System.Windows.Forms.TextBox();
            this.tax2ExemptCheckBox = new System.Windows.Forms.CheckBox();
            this.volumeTextBox = new System.Windows.Forms.TextBox();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.panelMultiProductStaging = new System.Windows.Forms.Panel();
            this.masterProductIDComboBox = new System.Windows.Forms.ComboBox();
            this.solProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetProductsLookup = new Solum.DataSetProductsLookup();
            this.typeIdComboBox = new System.Windows.Forms.ComboBox();
            this.tax1ExemptCheckBox = new System.Windows.Forms.CheckBox();
            this.vafAmountTextBox = new System.Windows.Forms.TextBox();
            this.handlingCommissionAmountTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.uPCTextBox = new System.Windows.Forms.TextBox();
            this.agencyIDComboBox = new System.Windows.Forms.ComboBox();
            this.AgenciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetAgenciesLookup = new Solum.DataSetAgenciesLookup();
            this.categoryIDComboBox = new System.Windows.Forms.ComboBox();
            this.standardDozenIDComboBox = new System.Windows.Forms.ComboBox();
            this.StandardDozenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetStandardDozenLookup = new Solum.DataSetStandardDozenLookup();
            this.containerIDComboBox = new System.Windows.Forms.ComboBox();
            this.ContainersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetContainersLookup = new Solum.DataSetContainersLookup();
            this.refundAmountTextBox = new System.Windows.Forms.TextBox();
            this.buttonRemoveImage = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.proImagePictureBox = new System.Windows.Forms.PictureBox();
            this.productIDTextBox = new System.Windows.Forms.TextBox();
            this.proNameTextBox = new System.Windows.Forms.TextBox();
            this.proDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.menuOrderTextBox = new System.Windows.Forms.TextBox();
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.sol_Products_SelectAllTableAdapter = new Solum.DataSetProductsTableAdapters.sol_Products_SelectAllTableAdapter();
            this.tableAdapterManager = new Solum.DataSetProductsTableAdapters.TableAdapterManager();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sol_ContainersTableAdapter = new Solum.DataSetContainersLookupTableAdapters.sol_ContainersTableAdapter();
            this.sol_StandardDozenTableAdapter = new Solum.DataSetStandardDozenLookupTableAdapters.sol_StandardDozenTableAdapter();
            this.sol_AgenciesTableAdapter = new Solum.DataSetAgenciesLookupTableAdapters.sol_AgenciesTableAdapter();
            this.sol_ProductsTableAdapter = new Solum.DataSetProductsLookupTableAdapters.sol_ProductsTableAdapter();
            this.sol_CategoriesTableAdapter = new Solum.DataSetCategoriesLookupTableAdapters.Sol_CategoriesTableAdapter();
            this.tableAdapterManager1 = new Solum.DataSetCategoriesLookupTableAdapters.TableAdapterManager();
            isActiveLabel = new System.Windows.Forms.Label();
            menuOrderLabel = new System.Windows.Forms.Label();
            proImageLabel = new System.Windows.Forms.Label();
            proDescriptionLabel = new System.Windows.Forms.Label();
            proNameLabel = new System.Windows.Forms.Label();
            productIDLabel = new System.Windows.Forms.Label();
            refundAmountLabel = new System.Windows.Forms.Label();
            containerIDLabel = new System.Windows.Forms.Label();
            standardDozenIDLabel = new System.Windows.Forms.Label();
            categoryIDLabel = new System.Windows.Forms.Label();
            agencyIDLabel = new System.Windows.Forms.Label();
            uPCLabel = new System.Windows.Forms.Label();
            productCodeLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            handlingCommissionAmountLabel = new System.Windows.Forms.Label();
            vafAmountLabel = new System.Windows.Forms.Label();
            tax1ExemptLabel = new System.Windows.Forms.Label();
            tax2ExemptLabel = new System.Windows.Forms.Label();
            typeIdLabel = new System.Windows.Forms.Label();
            masterProductIDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            targetQuantityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Products_SelectAllBindingNavigator)).BeginInit();
            this.sol_Products_SelectAllBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Products_SelectAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Products_SelectAllDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_CategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCategoriesLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelMultiProductStaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgenciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAgenciesLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandardDozenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStandardDozenLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetContainersLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // isActiveLabel
            // 
            isActiveLabel.AutoSize = true;
            isActiveLabel.Location = new System.Drawing.Point(18, 212);
            isActiveLabel.Name = "isActiveLabel";
            isActiveLabel.Size = new System.Drawing.Size(51, 13);
            isActiveLabel.TabIndex = 16;
            isActiveLabel.Text = "Is Active:";
            // 
            // menuOrderLabel
            // 
            menuOrderLabel.AutoSize = true;
            menuOrderLabel.Location = new System.Drawing.Point(18, 184);
            menuOrderLabel.Name = "menuOrderLabel";
            menuOrderLabel.Size = new System.Drawing.Size(66, 13);
            menuOrderLabel.TabIndex = 14;
            menuOrderLabel.Text = "Menu Order:";
            // 
            // proImageLabel
            // 
            proImageLabel.AutoSize = true;
            proImageLabel.Location = new System.Drawing.Point(497, 7);
            proImageLabel.Name = "proImageLabel";
            proImageLabel.Size = new System.Drawing.Size(58, 13);
            proImageLabel.TabIndex = 26;
            proImageLabel.Text = "Pro Image:";
            // 
            // proDescriptionLabel
            // 
            proDescriptionLabel.AutoSize = true;
            proDescriptionLabel.Location = new System.Drawing.Point(18, 97);
            proDescriptionLabel.Name = "proDescriptionLabel";
            proDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            proDescriptionLabel.TabIndex = 8;
            proDescriptionLabel.Text = "Description:";
            // 
            // proNameLabel
            // 
            proNameLabel.AutoSize = true;
            proNameLabel.Location = new System.Drawing.Point(18, 68);
            proNameLabel.Name = "proNameLabel";
            proNameLabel.Size = new System.Drawing.Size(38, 13);
            proNameLabel.TabIndex = 6;
            proNameLabel.Text = "Name:";
            // 
            // productIDLabel
            // 
            productIDLabel.AutoSize = true;
            productIDLabel.Location = new System.Drawing.Point(18, 11);
            productIDLabel.Name = "productIDLabel";
            productIDLabel.Size = new System.Drawing.Size(61, 13);
            productIDLabel.TabIndex = 0;
            productIDLabel.Text = "Product ID:";
            // 
            // refundAmountLabel
            // 
            refundAmountLabel.AutoSize = true;
            refundAmountLabel.Location = new System.Drawing.Point(18, 155);
            refundAmountLabel.Name = "refundAmountLabel";
            refundAmountLabel.Size = new System.Drawing.Size(84, 13);
            refundAmountLabel.TabIndex = 12;
            refundAmountLabel.Text = "Refund Amount:";
            // 
            // containerIDLabel
            // 
            containerIDLabel.AutoSize = true;
            containerIDLabel.Location = new System.Drawing.Point(18, 299);
            containerIDLabel.Name = "containerIDLabel";
            containerIDLabel.Size = new System.Drawing.Size(92, 13);
            containerIDLabel.TabIndex = 22;
            containerIDLabel.Text = "Default Container:";
            // 
            // standardDozenIDLabel
            // 
            standardDozenIDLabel.AutoSize = true;
            standardDozenIDLabel.Location = new System.Drawing.Point(302, 328);
            standardDozenIDLabel.Name = "standardDozenIDLabel";
            standardDozenIDLabel.Size = new System.Drawing.Size(87, 13);
            standardDozenIDLabel.TabIndex = 24;
            standardDozenIDLabel.Text = "Standard Dozen:";
            standardDozenIDLabel.Visible = false;
            // 
            // categoryIDLabel
            // 
            categoryIDLabel.AutoSize = true;
            categoryIDLabel.Location = new System.Drawing.Point(18, 126);
            categoryIDLabel.Name = "categoryIDLabel";
            categoryIDLabel.Size = new System.Drawing.Size(52, 13);
            categoryIDLabel.TabIndex = 10;
            categoryIDLabel.Text = "Category:";
            // 
            // agencyIDLabel
            // 
            agencyIDLabel.AutoSize = true;
            agencyIDLabel.Location = new System.Drawing.Point(18, 270);
            agencyIDLabel.Name = "agencyIDLabel";
            agencyIDLabel.Size = new System.Drawing.Size(46, 13);
            agencyIDLabel.TabIndex = 20;
            agencyIDLabel.Text = "Agency:";
            // 
            // uPCLabel
            // 
            uPCLabel.AutoSize = true;
            uPCLabel.Location = new System.Drawing.Point(298, 39);
            uPCLabel.Name = "uPCLabel";
            uPCLabel.Size = new System.Drawing.Size(32, 13);
            uPCLabel.TabIndex = 4;
            uPCLabel.Text = "UPC:";
            // 
            // productCodeLabel
            // 
            productCodeLabel.AutoSize = true;
            productCodeLabel.Location = new System.Drawing.Point(18, 41);
            productCodeLabel.Name = "productCodeLabel";
            productCodeLabel.Size = new System.Drawing.Size(112, 13);
            productCodeLabel.TabIndex = 2;
            productCodeLabel.Text = "Product (CRIS) Code: ";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(18, 244);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(34, 13);
            priceLabel.TabIndex = 18;
            priceLabel.Text = "Price:";
            // 
            // handlingCommissionAmountLabel
            // 
            handlingCommissionAmountLabel.AutoSize = true;
            handlingCommissionAmountLabel.Location = new System.Drawing.Point(317, 158);
            handlingCommissionAmountLabel.Name = "handlingCommissionAmountLabel";
            handlingCommissionAmountLabel.Size = new System.Drawing.Size(110, 13);
            handlingCommissionAmountLabel.TabIndex = 29;
            handlingCommissionAmountLabel.Text = "Handling Commission:";
            // 
            // vafAmountLabel
            // 
            vafAmountLabel.AutoSize = true;
            vafAmountLabel.Location = new System.Drawing.Point(317, 213);
            vafAmountLabel.Name = "vafAmountLabel";
            vafAmountLabel.Size = new System.Drawing.Size(65, 13);
            vafAmountLabel.TabIndex = 31;
            vafAmountLabel.Text = "Vaf Amount:";
            // 
            // tax1ExemptLabel
            // 
            tax1ExemptLabel.AutoSize = true;
            tax1ExemptLabel.Location = new System.Drawing.Point(465, 227);
            tax1ExemptLabel.Name = "tax1ExemptLabel";
            tax1ExemptLabel.Size = new System.Drawing.Size(69, 13);
            tax1ExemptLabel.TabIndex = 36;
            tax1ExemptLabel.Text = "Tax1Exempt:";
            // 
            // tax2ExemptLabel
            // 
            tax2ExemptLabel.AutoSize = true;
            tax2ExemptLabel.Location = new System.Drawing.Point(465, 253);
            tax2ExemptLabel.Name = "tax2ExemptLabel";
            tax2ExemptLabel.Size = new System.Drawing.Size(69, 13);
            tax2ExemptLabel.TabIndex = 38;
            tax2ExemptLabel.Text = "Tax2Exempt:";
            // 
            // typeIdLabel
            // 
            typeIdLabel.AutoSize = true;
            typeIdLabel.Location = new System.Drawing.Point(465, 195);
            typeIdLabel.Name = "typeIdLabel";
            typeIdLabel.Size = new System.Drawing.Size(34, 13);
            typeIdLabel.TabIndex = 39;
            typeIdLabel.Text = "Type:";
            // 
            // masterProductIDLabel
            // 
            masterProductIDLabel.AutoSize = true;
            masterProductIDLabel.Location = new System.Drawing.Point(34, 27);
            masterProductIDLabel.Name = "masterProductIDLabel";
            masterProductIDLabel.Size = new System.Drawing.Size(82, 13);
            masterProductIDLabel.TabIndex = 2;
            masterProductIDLabel.Text = "Master Product:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 355);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 42;
            label1.Text = "Weight: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 382);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 13);
            label2.TabIndex = 44;
            label2.Text = "Volume: ";
            // 
            // targetQuantityLabel
            // 
            targetQuantityLabel.AutoSize = true;
            targetQuantityLabel.Location = new System.Drawing.Point(18, 326);
            targetQuantityLabel.Name = "targetQuantityLabel";
            targetQuantityLabel.Size = new System.Drawing.Size(83, 13);
            targetQuantityLabel.TabIndex = 47;
            targetQuantityLabel.Text = "Target Quantity:";
            // 
            // sol_Products_SelectAllBindingNavigator
            // 
            this.sol_Products_SelectAllBindingNavigator.AddNewItem = null;
            this.sol_Products_SelectAllBindingNavigator.BindingSource = this.sol_Products_SelectAllBindingSource;
            this.sol_Products_SelectAllBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.sol_Products_SelectAllBindingNavigator.DeleteItem = null;
            this.sol_Products_SelectAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sol_Products_SelectAllBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.sol_Products_SelectAllBindingNavigatorSaveItem,
            this.toolStripButtonVirtualKb});
            this.sol_Products_SelectAllBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.sol_Products_SelectAllBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.sol_Products_SelectAllBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.sol_Products_SelectAllBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.sol_Products_SelectAllBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.sol_Products_SelectAllBindingNavigator.Name = "sol_Products_SelectAllBindingNavigator";
            this.sol_Products_SelectAllBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.sol_Products_SelectAllBindingNavigator.Size = new System.Drawing.Size(738, 39);
            this.sol_Products_SelectAllBindingNavigator.TabIndex = 0;
            this.sol_Products_SelectAllBindingNavigator.Text = "bindingNavigator1";
            // 
            // sol_Products_SelectAllBindingSource
            // 
            this.sol_Products_SelectAllBindingSource.DataMember = "sol_Products_SelectAll";
            this.sol_Products_SelectAllBindingSource.DataSource = this.dataSetProducts;
            // 
            // dataSetProducts
            // 
            this.dataSetProducts.DataSetName = "DataSetProducts";
            this.dataSetProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // sol_Products_SelectAllBindingNavigatorSaveItem
            // 
            this.sol_Products_SelectAllBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sol_Products_SelectAllBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("sol_Products_SelectAllBindingNavigatorSaveItem.Image")));
            this.sol_Products_SelectAllBindingNavigatorSaveItem.Name = "sol_Products_SelectAllBindingNavigatorSaveItem";
            this.sol_Products_SelectAllBindingNavigatorSaveItem.Size = new System.Drawing.Size(36, 36);
            this.sol_Products_SelectAllBindingNavigatorSaveItem.Text = "Save Data";
            this.sol_Products_SelectAllBindingNavigatorSaveItem.Click += new System.EventHandler(this.sol_Products_SelectAllBindingNavigatorSaveItem_Click);
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
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.panelGeneral);
            this.splitContainer1.Panel1.Controls.Add(this.panelDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonClose);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDetails);
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Size = new System.Drawing.Size(738, 491);
            this.splitContainer1.SplitterDistance = 414;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelGeneral
            // 
            this.panelGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGeneral.Controls.Add(this.sol_Products_SelectAllDataGridView);
            this.panelGeneral.Controls.Add(this.groupBox1);
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(738, 414);
            this.panelGeneral.TabIndex = 1;
            // 
            // sol_Products_SelectAllDataGridView
            // 
            this.sol_Products_SelectAllDataGridView.AllowUserToAddRows = false;
            this.sol_Products_SelectAllDataGridView.AllowUserToDeleteRows = false;
            this.sol_Products_SelectAllDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sol_Products_SelectAllDataGridView.AutoGenerateColumns = false;
            this.sol_Products_SelectAllDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sol_Products_SelectAllDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.proNameDataGridViewTextBoxColumn,
            this.proDescriptionDataGridViewTextBoxColumn,
            this.proShortDescriptionDataGridViewTextBoxColumn,
            this.proImageDataGridViewImageColumn,
            this.menuOrderDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn,
            this.categoryIDDataGridViewTextBoxColumn,
            this.commissionUnitDataGridViewTextBoxColumn,
            this.feeUnitDataGridViewTextBoxColumn,
            this.containerIDDataGridViewTextBoxColumn,
            this.standardDozenIDDataGridViewTextBoxColumn,
            this.agencyIDDataGridViewTextBoxColumn,
            this.uPCDataGridViewTextBoxColumn,
            this.productCodeDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.refundAmountDataGridViewTextBoxColumn,
            this.handlingCommissionAmountDataGridViewTextBoxColumn,
            this.vafAmountDataGridViewTextBoxColumn,
            this.TypeId,
            this.Tax1Exempt,
            this.Tax2Exempt,
            this.MasterProductID});
            this.sol_Products_SelectAllDataGridView.DataSource = this.sol_Products_SelectAllBindingSource;
            this.sol_Products_SelectAllDataGridView.Location = new System.Drawing.Point(16, 85);
            this.sol_Products_SelectAllDataGridView.Name = "sol_Products_SelectAllDataGridView";
            this.sol_Products_SelectAllDataGridView.RowTemplate.Height = 24;
            this.sol_Products_SelectAllDataGridView.Size = new System.Drawing.Size(698, 311);
            this.sol_Products_SelectAllDataGridView.TabIndex = 0;
            this.sol_Products_SelectAllDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sol_Products_SelectAllDataGridView_CellDoubleClick_1);
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "ProductID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIDDataGridViewTextBoxColumn.Width = 90;
            // 
            // proNameDataGridViewTextBoxColumn
            // 
            this.proNameDataGridViewTextBoxColumn.DataPropertyName = "ProName";
            this.proNameDataGridViewTextBoxColumn.HeaderText = "ProName";
            this.proNameDataGridViewTextBoxColumn.Name = "proNameDataGridViewTextBoxColumn";
            // 
            // proDescriptionDataGridViewTextBoxColumn
            // 
            this.proDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ProDescription";
            this.proDescriptionDataGridViewTextBoxColumn.HeaderText = "ProDescription";
            this.proDescriptionDataGridViewTextBoxColumn.Name = "proDescriptionDataGridViewTextBoxColumn";
            // 
            // proShortDescriptionDataGridViewTextBoxColumn
            // 
            this.proShortDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ProShortDescription";
            this.proShortDescriptionDataGridViewTextBoxColumn.HeaderText = "ProShortDescription";
            this.proShortDescriptionDataGridViewTextBoxColumn.Name = "proShortDescriptionDataGridViewTextBoxColumn";
            // 
            // proImageDataGridViewImageColumn
            // 
            this.proImageDataGridViewImageColumn.DataPropertyName = "ProImage";
            this.proImageDataGridViewImageColumn.HeaderText = "ProImage";
            this.proImageDataGridViewImageColumn.Name = "proImageDataGridViewImageColumn";
            // 
            // menuOrderDataGridViewTextBoxColumn
            // 
            this.menuOrderDataGridViewTextBoxColumn.DataPropertyName = "MenuOrder";
            this.menuOrderDataGridViewTextBoxColumn.HeaderText = "MenuOrder";
            this.menuOrderDataGridViewTextBoxColumn.Name = "menuOrderDataGridViewTextBoxColumn";
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.Visible = false;
            // 
            // categoryIDDataGridViewTextBoxColumn
            // 
            this.categoryIDDataGridViewTextBoxColumn.DataPropertyName = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.DataSource = this.sol_CategoriesBindingSource;
            this.categoryIDDataGridViewTextBoxColumn.DisplayMember = "Description";
            this.categoryIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.categoryIDDataGridViewTextBoxColumn.HeaderText = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.Name = "categoryIDDataGridViewTextBoxColumn";
            this.categoryIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.categoryIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.categoryIDDataGridViewTextBoxColumn.ValueMember = "CategoryID";
            // 
            // sol_CategoriesBindingSource
            // 
            this.sol_CategoriesBindingSource.DataMember = "Sol_Categories";
            this.sol_CategoriesBindingSource.DataSource = this.dataSetCategoriesLookup;
            // 
            // dataSetCategoriesLookup
            // 
            this.dataSetCategoriesLookup.DataSetName = "DataSetCategoriesLookup";
            this.dataSetCategoriesLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commissionUnitDataGridViewTextBoxColumn
            // 
            this.commissionUnitDataGridViewTextBoxColumn.DataPropertyName = "CommissionUnit";
            this.commissionUnitDataGridViewTextBoxColumn.HeaderText = "CommissionUnit";
            this.commissionUnitDataGridViewTextBoxColumn.Name = "commissionUnitDataGridViewTextBoxColumn";
            // 
            // feeUnitDataGridViewTextBoxColumn
            // 
            this.feeUnitDataGridViewTextBoxColumn.DataPropertyName = "FeeUnit";
            this.feeUnitDataGridViewTextBoxColumn.HeaderText = "FeeUnit";
            this.feeUnitDataGridViewTextBoxColumn.Name = "feeUnitDataGridViewTextBoxColumn";
            // 
            // containerIDDataGridViewTextBoxColumn
            // 
            this.containerIDDataGridViewTextBoxColumn.DataPropertyName = "ContainerID";
            this.containerIDDataGridViewTextBoxColumn.HeaderText = "ContainerID";
            this.containerIDDataGridViewTextBoxColumn.Name = "containerIDDataGridViewTextBoxColumn";
            // 
            // standardDozenIDDataGridViewTextBoxColumn
            // 
            this.standardDozenIDDataGridViewTextBoxColumn.DataPropertyName = "StandardDozenID";
            this.standardDozenIDDataGridViewTextBoxColumn.HeaderText = "StandardDozenID";
            this.standardDozenIDDataGridViewTextBoxColumn.Name = "standardDozenIDDataGridViewTextBoxColumn";
            // 
            // agencyIDDataGridViewTextBoxColumn
            // 
            this.agencyIDDataGridViewTextBoxColumn.DataPropertyName = "AgencyID";
            this.agencyIDDataGridViewTextBoxColumn.HeaderText = "AgencyID";
            this.agencyIDDataGridViewTextBoxColumn.Name = "agencyIDDataGridViewTextBoxColumn";
            // 
            // uPCDataGridViewTextBoxColumn
            // 
            this.uPCDataGridViewTextBoxColumn.DataPropertyName = "UPC";
            this.uPCDataGridViewTextBoxColumn.HeaderText = "UPC";
            this.uPCDataGridViewTextBoxColumn.Name = "uPCDataGridViewTextBoxColumn";
            // 
            // productCodeDataGridViewTextBoxColumn
            // 
            this.productCodeDataGridViewTextBoxColumn.DataPropertyName = "ProductCode";
            this.productCodeDataGridViewTextBoxColumn.HeaderText = "ProductCode";
            this.productCodeDataGridViewTextBoxColumn.Name = "productCodeDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // refundAmountDataGridViewTextBoxColumn
            // 
            this.refundAmountDataGridViewTextBoxColumn.DataPropertyName = "RefundAmount";
            this.refundAmountDataGridViewTextBoxColumn.HeaderText = "RefundAmount";
            this.refundAmountDataGridViewTextBoxColumn.Name = "refundAmountDataGridViewTextBoxColumn";
            // 
            // handlingCommissionAmountDataGridViewTextBoxColumn
            // 
            this.handlingCommissionAmountDataGridViewTextBoxColumn.DataPropertyName = "HandlingCommissionAmount";
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = "0";
            this.handlingCommissionAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.handlingCommissionAmountDataGridViewTextBoxColumn.HeaderText = "HandlingCommissionAmount";
            this.handlingCommissionAmountDataGridViewTextBoxColumn.Name = "handlingCommissionAmountDataGridViewTextBoxColumn";
            // 
            // vafAmountDataGridViewTextBoxColumn
            // 
            this.vafAmountDataGridViewTextBoxColumn.DataPropertyName = "VafAmount";
            dataGridViewCellStyle2.Format = "N5";
            dataGridViewCellStyle2.NullValue = "0";
            this.vafAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.vafAmountDataGridViewTextBoxColumn.HeaderText = "VafAmount";
            this.vafAmountDataGridViewTextBoxColumn.Name = "vafAmountDataGridViewTextBoxColumn";
            // 
            // TypeId
            // 
            this.TypeId.DataPropertyName = "TypeId";
            this.TypeId.DataSource = this.productTypeBindingSource;
            this.TypeId.DisplayMember = "Description";
            this.TypeId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TypeId.DisplayStyleForCurrentCellOnly = true;
            this.TypeId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TypeId.HeaderText = "Type";
            this.TypeId.Name = "TypeId";
            this.TypeId.ValueMember = "Id";
            this.TypeId.Width = 60;
            // 
            // productTypeBindingSource
            // 
            this.productTypeBindingSource.DataSource = typeof(Solum.ProductType);
            // 
            // Tax1Exempt
            // 
            this.Tax1Exempt.DataPropertyName = "Tax1Exempt";
            this.Tax1Exempt.HeaderText = "Tax1Exempt";
            this.Tax1Exempt.Name = "Tax1Exempt";
            this.Tax1Exempt.Visible = false;
            // 
            // Tax2Exempt
            // 
            this.Tax2Exempt.DataPropertyName = "Tax2Exempt";
            this.Tax2Exempt.HeaderText = "Tax2Exempt";
            this.Tax2Exempt.Name = "Tax2Exempt";
            this.Tax2Exempt.Visible = false;
            // 
            // MasterProductID
            // 
            this.MasterProductID.DataPropertyName = "MasterProductID";
            this.MasterProductID.HeaderText = "MasterProductID";
            this.MasterProductID.Name = "MasterProductID";
            this.MasterProductID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxType);
            this.groupBox1.Controls.Add(this.labelType);
            this.groupBox1.Location = new System.Drawing.Point(17, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "All",
            "Return",
            "Sale"});
            this.comboBoxType.Location = new System.Drawing.Point(119, 28);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(146, 21);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelType.Location = new System.Drawing.Point(39, 28);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 13);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "&Type:";
            // 
            // panelDetails
            // 
            this.panelDetails.AutoScroll = true;
            this.panelDetails.Controls.Add(targetQuantityLabel);
            this.panelDetails.Controls.Add(this.targetQuantityTextBox);
            this.panelDetails.Controls.Add(this.tax2ExemptCheckBox);
            this.panelDetails.Controls.Add(label2);
            this.panelDetails.Controls.Add(this.volumeTextBox);
            this.panelDetails.Controls.Add(label1);
            this.panelDetails.Controls.Add(this.weightTextBox);
            this.panelDetails.Controls.Add(this.panelMultiProductStaging);
            this.panelDetails.Controls.Add(typeIdLabel);
            this.panelDetails.Controls.Add(this.typeIdComboBox);
            this.panelDetails.Controls.Add(tax2ExemptLabel);
            this.panelDetails.Controls.Add(tax1ExemptLabel);
            this.panelDetails.Controls.Add(this.tax1ExemptCheckBox);
            this.panelDetails.Controls.Add(vafAmountLabel);
            this.panelDetails.Controls.Add(this.vafAmountTextBox);
            this.panelDetails.Controls.Add(handlingCommissionAmountLabel);
            this.panelDetails.Controls.Add(this.handlingCommissionAmountTextBox);
            this.panelDetails.Controls.Add(priceLabel);
            this.panelDetails.Controls.Add(this.priceTextBox);
            this.panelDetails.Controls.Add(productCodeLabel);
            this.panelDetails.Controls.Add(this.productCodeTextBox);
            this.panelDetails.Controls.Add(uPCLabel);
            this.panelDetails.Controls.Add(this.uPCTextBox);
            this.panelDetails.Controls.Add(agencyIDLabel);
            this.panelDetails.Controls.Add(this.agencyIDComboBox);
            this.panelDetails.Controls.Add(categoryIDLabel);
            this.panelDetails.Controls.Add(this.categoryIDComboBox);
            this.panelDetails.Controls.Add(standardDozenIDLabel);
            this.panelDetails.Controls.Add(this.standardDozenIDComboBox);
            this.panelDetails.Controls.Add(containerIDLabel);
            this.panelDetails.Controls.Add(this.containerIDComboBox);
            this.panelDetails.Controls.Add(refundAmountLabel);
            this.panelDetails.Controls.Add(this.refundAmountTextBox);
            this.panelDetails.Controls.Add(this.buttonRemoveImage);
            this.panelDetails.Controls.Add(this.buttonBrowse);
            this.panelDetails.Controls.Add(this.proImagePictureBox);
            this.panelDetails.Controls.Add(productIDLabel);
            this.panelDetails.Controls.Add(this.productIDTextBox);
            this.panelDetails.Controls.Add(proNameLabel);
            this.panelDetails.Controls.Add(this.proNameTextBox);
            this.panelDetails.Controls.Add(proDescriptionLabel);
            this.panelDetails.Controls.Add(this.proDescriptionTextBox);
            this.panelDetails.Controls.Add(proImageLabel);
            this.panelDetails.Controls.Add(menuOrderLabel);
            this.panelDetails.Controls.Add(this.menuOrderTextBox);
            this.panelDetails.Controls.Add(isActiveLabel);
            this.panelDetails.Controls.Add(this.isActiveCheckBox);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(738, 414);
            this.panelDetails.TabIndex = 0;
            this.panelDetails.Visible = false;
            // 
            // targetQuantityTextBox
            // 
            this.targetQuantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "TargetQuantity", true));
            this.targetQuantityTextBox.Location = new System.Drawing.Point(178, 327);
            this.targetQuantityTextBox.Name = "targetQuantityTextBox";
            this.targetQuantityTextBox.Size = new System.Drawing.Size(100, 20);
            this.targetQuantityTextBox.TabIndex = 48;
            // 
            // tax2ExemptCheckBox
            // 
            this.tax2ExemptCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.sol_Products_SelectAllBindingSource, "Tax2Exempt", true));
            this.tax2ExemptCheckBox.Location = new System.Drawing.Point(558, 253);
            this.tax2ExemptCheckBox.Name = "tax2ExemptCheckBox";
            this.tax2ExemptCheckBox.Size = new System.Drawing.Size(104, 24);
            this.tax2ExemptCheckBox.TabIndex = 46;
            this.tax2ExemptCheckBox.UseVisualStyleBackColor = true;
            // 
            // volumeTextBox
            // 
            this.volumeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "Volume", true));
            this.volumeTextBox.Location = new System.Drawing.Point(178, 382);
            this.volumeTextBox.MaxLength = 50;
            this.volumeTextBox.Name = "volumeTextBox";
            this.volumeTextBox.Size = new System.Drawing.Size(100, 20);
            this.volumeTextBox.TabIndex = 45;
            // 
            // weightTextBox
            // 
            this.weightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "Weight", true));
            this.weightTextBox.Location = new System.Drawing.Point(178, 354);
            this.weightTextBox.MaxLength = 50;
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightTextBox.TabIndex = 43;
            // 
            // panelMultiProductStaging
            // 
            this.panelMultiProductStaging.Controls.Add(masterProductIDLabel);
            this.panelMultiProductStaging.Controls.Add(this.masterProductIDComboBox);
            this.panelMultiProductStaging.Location = new System.Drawing.Point(431, 270);
            this.panelMultiProductStaging.Name = "panelMultiProductStaging";
            this.panelMultiProductStaging.Size = new System.Drawing.Size(272, 105);
            this.panelMultiProductStaging.TabIndex = 41;
            this.panelMultiProductStaging.Visible = false;
            // 
            // masterProductIDComboBox
            // 
            this.masterProductIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sol_Products_SelectAllBindingSource, "MasterProductID", true));
            this.masterProductIDComboBox.DataSource = this.solProductsBindingSource;
            this.masterProductIDComboBox.DisplayMember = "ProName";
            this.masterProductIDComboBox.FormattingEnabled = true;
            this.masterProductIDComboBox.Location = new System.Drawing.Point(38, 47);
            this.masterProductIDComboBox.Name = "masterProductIDComboBox";
            this.masterProductIDComboBox.Size = new System.Drawing.Size(179, 21);
            this.masterProductIDComboBox.TabIndex = 3;
            this.masterProductIDComboBox.ValueMember = "ProductID";
            // 
            // solProductsBindingSource
            // 
            this.solProductsBindingSource.DataMember = "sol_Products";
            this.solProductsBindingSource.DataSource = this.dataSetProductsLookup;
            // 
            // dataSetProductsLookup
            // 
            this.dataSetProductsLookup.DataSetName = "DataSetProductsLookup";
            this.dataSetProductsLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // typeIdComboBox
            // 
            this.typeIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sol_Products_SelectAllBindingSource, "TypeId", true));
            this.typeIdComboBox.DataSource = this.productTypeBindingSource;
            this.typeIdComboBox.DisplayMember = "Description";
            this.typeIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeIdComboBox.FormattingEnabled = true;
            this.typeIdComboBox.Location = new System.Drawing.Point(558, 195);
            this.typeIdComboBox.Name = "typeIdComboBox";
            this.typeIdComboBox.Size = new System.Drawing.Size(86, 21);
            this.typeIdComboBox.TabIndex = 40;
            this.typeIdComboBox.ValueMember = "Id";
            this.typeIdComboBox.SelectedIndexChanged += new System.EventHandler(this.typeIdComboBox_SelectedIndexChanged);
            // 
            // tax1ExemptCheckBox
            // 
            this.tax1ExemptCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.sol_Products_SelectAllBindingSource, "Tax1Exempt", true));
            this.tax1ExemptCheckBox.Location = new System.Drawing.Point(558, 225);
            this.tax1ExemptCheckBox.Name = "tax1ExemptCheckBox";
            this.tax1ExemptCheckBox.Size = new System.Drawing.Size(104, 24);
            this.tax1ExemptCheckBox.TabIndex = 37;
            this.tax1ExemptCheckBox.UseVisualStyleBackColor = true;
            // 
            // vafAmountTextBox
            // 
            this.vafAmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "VafAmount", true));
            this.vafAmountTextBox.Location = new System.Drawing.Point(317, 238);
            this.vafAmountTextBox.Name = "vafAmountTextBox";
            this.vafAmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.vafAmountTextBox.TabIndex = 32;
            // 
            // handlingCommissionAmountTextBox
            // 
            this.handlingCommissionAmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "HandlingCommissionAmount", true));
            this.handlingCommissionAmountTextBox.Location = new System.Drawing.Point(317, 181);
            this.handlingCommissionAmountTextBox.Name = "handlingCommissionAmountTextBox";
            this.handlingCommissionAmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.handlingCommissionAmountTextBox.TabIndex = 30;
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "Price", true));
            this.priceTextBox.Location = new System.Drawing.Point(178, 238);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(121, 20);
            this.priceTextBox.TabIndex = 19;
            this.priceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.priceTextBox_Validating);
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "ProductCode", true));
            this.productCodeTextBox.Location = new System.Drawing.Point(178, 39);
            this.productCodeTextBox.MaxLength = 50;
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.productCodeTextBox.TabIndex = 3;
            this.productCodeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.proNameTextBox_Validating);
            // 
            // uPCTextBox
            // 
            this.uPCTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "UPC", true));
            this.uPCTextBox.Location = new System.Drawing.Point(344, 38);
            this.uPCTextBox.MaxLength = 50;
            this.uPCTextBox.Name = "uPCTextBox";
            this.uPCTextBox.Size = new System.Drawing.Size(134, 20);
            this.uPCTextBox.TabIndex = 5;
            // 
            // agencyIDComboBox
            // 
            this.agencyIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sol_Products_SelectAllBindingSource, "AgencyID", true));
            this.agencyIDComboBox.DataSource = this.AgenciesBindingSource;
            this.agencyIDComboBox.DisplayMember = "Name";
            this.agencyIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agencyIDComboBox.FormattingEnabled = true;
            this.agencyIDComboBox.Location = new System.Drawing.Point(178, 267);
            this.agencyIDComboBox.Name = "agencyIDComboBox";
            this.agencyIDComboBox.Size = new System.Drawing.Size(194, 21);
            this.agencyIDComboBox.TabIndex = 21;
            this.agencyIDComboBox.ValueMember = "AgencyID";
            // 
            // AgenciesBindingSource
            // 
            this.AgenciesBindingSource.DataMember = "sol_Agencies";
            this.AgenciesBindingSource.DataSource = this.dataSetAgenciesLookup;
            // 
            // dataSetAgenciesLookup
            // 
            this.dataSetAgenciesLookup.DataSetName = "DataSetAgenciesLookup";
            this.dataSetAgenciesLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryIDComboBox
            // 
            this.categoryIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sol_Products_SelectAllBindingSource, "CategoryID", true));
            this.categoryIDComboBox.DataSource = this.sol_CategoriesBindingSource;
            this.categoryIDComboBox.DisplayMember = "Description";
            this.categoryIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryIDComboBox.FormattingEnabled = true;
            this.categoryIDComboBox.Location = new System.Drawing.Point(178, 123);
            this.categoryIDComboBox.Name = "categoryIDComboBox";
            this.categoryIDComboBox.Size = new System.Drawing.Size(194, 21);
            this.categoryIDComboBox.TabIndex = 11;
            this.categoryIDComboBox.ValueMember = "CategoryID";
            // 
            // standardDozenIDComboBox
            // 
            this.standardDozenIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sol_Products_SelectAllBindingSource, "StandardDozenID", true));
            this.standardDozenIDComboBox.DataSource = this.StandardDozenBindingSource;
            this.standardDozenIDComboBox.DisplayMember = "Quantity";
            this.standardDozenIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.standardDozenIDComboBox.FormattingEnabled = true;
            this.standardDozenIDComboBox.Location = new System.Drawing.Point(302, 348);
            this.standardDozenIDComboBox.Name = "standardDozenIDComboBox";
            this.standardDozenIDComboBox.Size = new System.Drawing.Size(100, 21);
            this.standardDozenIDComboBox.TabIndex = 25;
            this.standardDozenIDComboBox.ValueMember = "StandardDozenID";
            this.standardDozenIDComboBox.Visible = false;
            // 
            // StandardDozenBindingSource
            // 
            this.StandardDozenBindingSource.DataMember = "sol_StandardDozen";
            this.StandardDozenBindingSource.DataSource = this.dataSetStandardDozenLookup;
            // 
            // dataSetStandardDozenLookup
            // 
            this.dataSetStandardDozenLookup.DataSetName = "DataSetStandardDozenLookup";
            this.dataSetStandardDozenLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // containerIDComboBox
            // 
            this.containerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sol_Products_SelectAllBindingSource, "ContainerID", true));
            this.containerIDComboBox.DataSource = this.ContainersBindingSource;
            this.containerIDComboBox.DisplayMember = "Description";
            this.containerIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.containerIDComboBox.FormattingEnabled = true;
            this.containerIDComboBox.Location = new System.Drawing.Point(178, 297);
            this.containerIDComboBox.Name = "containerIDComboBox";
            this.containerIDComboBox.Size = new System.Drawing.Size(194, 21);
            this.containerIDComboBox.TabIndex = 23;
            this.containerIDComboBox.ValueMember = "ContainerID";
            // 
            // ContainersBindingSource
            // 
            this.ContainersBindingSource.DataMember = "sol_Containers";
            this.ContainersBindingSource.DataSource = this.dataSetContainersLookup;
            // 
            // dataSetContainersLookup
            // 
            this.dataSetContainersLookup.DataSetName = "DataSetContainersLookup";
            this.dataSetContainersLookup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // refundAmountTextBox
            // 
            this.refundAmountTextBox.Location = new System.Drawing.Point(178, 158);
            this.refundAmountTextBox.Name = "refundAmountTextBox";
            this.refundAmountTextBox.ReadOnly = true;
            this.refundAmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.refundAmountTextBox.TabIndex = 13;
            this.refundAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonRemoveImage
            // 
            this.buttonRemoveImage.Location = new System.Drawing.Point(654, 120);
            this.buttonRemoveImage.Name = "buttonRemoveImage";
            this.buttonRemoveImage.Size = new System.Drawing.Size(71, 46);
            this.buttonRemoveImage.TabIndex = 28;
            this.buttonRemoveImage.Text = "&Remove image";
            this.buttonRemoveImage.UseVisualStyleBackColor = true;
            this.buttonRemoveImage.Click += new System.EventHandler(this.buttonRemoveImage_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(654, 57);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(71, 46);
            this.buttonBrowse.TabIndex = 27;
            this.buttonBrowse.Text = "&Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // proImagePictureBox
            // 
            this.proImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.proImagePictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.sol_Products_SelectAllBindingSource, "ProImage", true));
            this.proImagePictureBox.Location = new System.Drawing.Point(494, 30);
            this.proImagePictureBox.Name = "proImagePictureBox";
            this.proImagePictureBox.Size = new System.Drawing.Size(150, 150);
            this.proImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.proImagePictureBox.TabIndex = 18;
            this.proImagePictureBox.TabStop = false;
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "ProductID", true));
            this.productIDTextBox.Location = new System.Drawing.Point(178, 11);
            this.productIDTextBox.Name = "productIDTextBox";
            this.productIDTextBox.ReadOnly = true;
            this.productIDTextBox.Size = new System.Drawing.Size(121, 20);
            this.productIDTextBox.TabIndex = 1;
            this.productIDTextBox.TabStop = false;
            // 
            // proNameTextBox
            // 
            this.proNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "ProName", true));
            this.proNameTextBox.Location = new System.Drawing.Point(178, 67);
            this.proNameTextBox.MaxLength = 50;
            this.proNameTextBox.Name = "proNameTextBox";
            this.proNameTextBox.Size = new System.Drawing.Size(309, 20);
            this.proNameTextBox.TabIndex = 7;
            this.proNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.proNameTextBox_Validating);
            // 
            // proDescriptionTextBox
            // 
            this.proDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "ProDescription", true));
            this.proDescriptionTextBox.Location = new System.Drawing.Point(178, 95);
            this.proDescriptionTextBox.MaxLength = 50;
            this.proDescriptionTextBox.Name = "proDescriptionTextBox";
            this.proDescriptionTextBox.Size = new System.Drawing.Size(309, 20);
            this.proDescriptionTextBox.TabIndex = 9;
            // 
            // menuOrderTextBox
            // 
            this.menuOrderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sol_Products_SelectAllBindingSource, "MenuOrder", true));
            this.menuOrderTextBox.Location = new System.Drawing.Point(178, 181);
            this.menuOrderTextBox.Name = "menuOrderTextBox";
            this.menuOrderTextBox.Size = new System.Drawing.Size(121, 20);
            this.menuOrderTextBox.TabIndex = 15;
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.sol_Products_SelectAllBindingSource, "IsActive", true));
            this.isActiveCheckBox.Location = new System.Drawing.Point(178, 209);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(121, 24);
            this.isActiveCheckBox.TabIndex = 17;
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(431, 18);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(83, 29);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(321, 18);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(83, 29);
            this.buttonDetails.TabIndex = 1;
            this.buttonDetails.Text = "&Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(211, 18);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(83, 29);
            this.OK.TabIndex = 0;
            this.OK.Text = "&Update";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // sol_Products_SelectAllTableAdapter
            // 
            this.sol_Products_SelectAllTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.sol_Products_SelectAllTableAdapter = this.sol_Products_SelectAllTableAdapter;
            this.tableAdapterManager.UpdateOrder = Solum.DataSetProductsTableAdapters.TableAdapterManager.UpdateOrderOption.UpdateInsertDelete;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // sol_ContainersTableAdapter
            // 
            this.sol_ContainersTableAdapter.ClearBeforeFill = true;
            // 
            // sol_StandardDozenTableAdapter
            // 
            this.sol_StandardDozenTableAdapter.ClearBeforeFill = true;
            // 
            // sol_AgenciesTableAdapter
            // 
            this.sol_AgenciesTableAdapter.ClearBeforeFill = true;
            // 
            // sol_ProductsTableAdapter
            // 
            this.sol_ProductsTableAdapter.ClearBeforeFill = true;
            // 
            // sol_CategoriesTableAdapter
            // 
            this.sol_CategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Sol_CategoriesTableAdapter = this.sol_CategoriesTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Solum.DataSetCategoriesLookupTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Products
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(738, 530);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sol_Products_SelectAllBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Products";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Products_FormClosing);
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sol_Products_SelectAllBindingNavigator)).EndInit();
            this.sol_Products_SelectAllBindingNavigator.ResumeLayout(false);
            this.sol_Products_SelectAllBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sol_Products_SelectAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProducts)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sol_Products_SelectAllDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sol_CategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCategoriesLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelMultiProductStaging.ResumeLayout(false);
            this.panelMultiProductStaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductsLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgenciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAgenciesLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandardDozenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStandardDozenLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContainersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetContainersLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetProducts dataSetProducts;
        private System.Windows.Forms.BindingSource sol_Products_SelectAllBindingSource;
        private Solum.DataSetProductsTableAdapters.sol_Products_SelectAllTableAdapter sol_Products_SelectAllTableAdapter;
        private Solum.DataSetProductsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator sol_Products_SelectAllBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton sol_Products_SelectAllBindingNavigatorSaveItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVirtualKb;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private SirLib.DataGridViewModificada sol_Products_SelectAllDataGridView;
        //private Solum.DataSetCategoriesLookupTableAdapters.Sol_CategoriesTableAdapter Sol_CategoriesTableAdapter;
        private System.Windows.Forms.BindingSource ContainersBindingSource;
        private DataSetContainersLookup dataSetContainersLookup;
        private Solum.DataSetContainersLookupTableAdapters.sol_ContainersTableAdapter sol_ContainersTableAdapter;
        private System.Windows.Forms.BindingSource StandardDozenBindingSource;
        private DataSetStandardDozenLookup dataSetStandardDozenLookup;
        private Solum.DataSetStandardDozenLookupTableAdapters.sol_StandardDozenTableAdapter sol_StandardDozenTableAdapter;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.ComboBox agencyIDComboBox;
        private System.Windows.Forms.ComboBox categoryIDComboBox;
        private System.Windows.Forms.ComboBox standardDozenIDComboBox;
        private System.Windows.Forms.ComboBox containerIDComboBox;
        private System.Windows.Forms.TextBox refundAmountTextBox;
        private System.Windows.Forms.Button buttonRemoveImage;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.PictureBox proImagePictureBox;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox proNameTextBox;
        private System.Windows.Forms.TextBox proDescriptionTextBox;
        private System.Windows.Forms.TextBox menuOrderTextBox;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.BindingSource AgenciesBindingSource;
        private DataSetAgenciesLookup dataSetAgenciesLookup;
        private Solum.DataSetAgenciesLookupTableAdapters.sol_AgenciesTableAdapter sol_AgenciesTableAdapter;
        private System.Windows.Forms.TextBox uPCTextBox;
        private System.Windows.Forms.TextBox productCodeTextBox;
        //private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        //private Solum.DataSetCategoriesTableAdapters.sol_Categories_SelectAllTableAdapter Sol_CategoriesTableAdapter1;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox handlingCommissionAmountTextBox;
        private System.Windows.Forms.TextBox vafAmountTextBox;
        private System.Windows.Forms.CheckBox tax1ExemptCheckBox;
        private System.Windows.Forms.ComboBox typeIdComboBox;
        private System.Windows.Forms.BindingSource productTypeBindingSource;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Panel panelMultiProductStaging;
        private System.Windows.Forms.ComboBox masterProductIDComboBox;
        private System.Windows.Forms.BindingSource solProductsBindingSource;
        private DataSetProductsLookup dataSetProductsLookup;
        private DataSetProductsLookupTableAdapters.sol_ProductsTableAdapter sol_ProductsTableAdapter;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.TextBox volumeTextBox;
        private DataSetCategoriesLookup dataSetCategoriesLookup;
        private System.Windows.Forms.BindingSource sol_CategoriesBindingSource;
        private DataSetCategoriesLookupTableAdapters.Sol_CategoriesTableAdapter sol_CategoriesTableAdapter;
        private DataSetCategoriesLookupTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.CheckBox tax2ExemptCheckBox;
        private System.Windows.Forms.TextBox targetQuantityTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proShortDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn proImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn categoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commissionUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn containerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn standardDozenIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refundAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlingCommissionAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vafAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tax1Exempt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tax2Exempt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MasterProductID;
        //private DataSetCategoriesTableAdapters.sol_CategoriesTableAdapter sol_CategoriesTableAdapter;
    }
}