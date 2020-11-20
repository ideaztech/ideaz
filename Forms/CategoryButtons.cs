
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Solum.Forms;
using System.Collections;
using SirLib;

using System.Runtime.InteropServices;


namespace Solum
{
    public partial class CategoryButtons : Form
    {
        bool updateFlag = false;
        enum ControlType
        {
            Label
            , Button
        }

        byte buttonType;

        ButtonAction lastButtonAction;
        enum ButtonAction
        {
            AddLabel
            , AddButton
            , Delete
            , Cancel
            , Save
            , Edit
            , None
        }

        public static int buttonW = 96;
        public static int buttonH = 66;

        public static Size Grid;
        public static Size HalfGrid;

        //************************************************************************
        #region PanelTableLayoutPanelView3_Buttons Variables   //17" screen setup

        private System.Windows.Forms.Label labelPanel;
        private System.Windows.Forms.ComboBox comboBoxPanel;


        int lastPage = 0;
        int pageNumber = 1;
        public static int pageSize = 14;

        private ArrayList arrayListItems4;                  //for horizontal panel buttonType 3
        List<Sol_CategoryButton> sol_CategoryButtonList4;

        public static Color defaultForeColor = System.Drawing.SystemColors.ControlText;
        public static Color defaultBackColor = System.Drawing.SystemColors.Control;

        Color newForeColor;
        Color newBackColor;

        public static string defaultFont = "[Font: Name=Microsoft Sans Serif, Size=7.8, Units=3, GdiCharSet=0, GdiVerticalFont=False]";
        public static string defaultFontStyle = "Regular";

        string newFont; // = defaultFont;
        string newFontStyle;    // = defaultFontStyle;


        MyPanel panelTableLayoutPanelView3_Buttons;

        MyPanel panelTableLayoutPanelView3Vertical_Buttons;
        public static int view3Rows = 7;
        public static int view3Cells = 4;

        MyPanel panelTableLayoutPanelView3Horizontal_Buttons;
        public static int view3HorizontalRows = 2;
        public static int view3HorizontalCells = 7;

        Button buttonFirstPage;
        Button buttonPreviousPage;
        Button buttonNextPage;
        Button buttonLastPage;

        #endregion

        //************************************************************************
        #region PanelTableLayoutPanelView2_Buttons Variables   //NumericKeyPad On

        Point categoryButtonLocationOnForm;

        public static int paddingX = 5;
        public static int paddingY = 5;
        public static int maxNumberOfButtonsPerRow = 2;

        public static int categoryButtonWidth = buttonW;
        public static int categoryButtonHeight = buttonH;

        public static int galleyButtonsWidth = 367;
        public static int galleryButtonsHeight = 482;

        public static int buttonContainerWidth = 239;   //239
        public static int buttonContainerHeight = 488;  //476

        public static Button buttonSender;

        private Button buttonClicked;
        private Button buttonClickedPrevious;

        private MyPanel panelTableLayoutPanelView2_Buttons;

        #endregion

        //string hexForeColor = "#000000";
        //string hexBackColor = "#f0f0f0";

        private string controlName = "";

        private ArrayList arrayListItems;       //buttons and labels collection

        private int CategoryButtonID = 0, indice = 0;
        List<Sol_CategoryButton> sol_CategoryButtonList;
        //Sol_CategoryButton sol_CategoryButton;
        Sol_CategoryButton_Sp sol_CategoryButton_Sp;

        public CategoryButtons()
        {
            InitializeComponent();
        }

        private void CategoryButtons_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCategoriesLookup.Sol_Categories' table. You can move, or remove it, as needed.
            this.sol_CategoriesTableAdapter.Fill(this.dataSetCategoriesLookup.Sol_Categories);
            newFont = defaultFont;
            newFontStyle = defaultFontStyle;

            newForeColor = defaultForeColor;
            newBackColor = defaultBackColor;


            if (Properties.Settings.Default.TouchOriented)
            {
                toolStripButtonVirtualKb.Visible = true;
            }


            // TODO: This line of code loads data into the 'dataSetCategoriesLookup.Sol_Categories' table. You can move, or remove it, as needed.
            this.sol_CategoriesTableAdapter.Fill(this.dataSetCategoriesLookup.Sol_Categories);
            // TODO: This line of code loads data into the 'dataSetWorkStationsLookup.sol_WorkStations' table. You can move, or remove it, as needed.
            this.sol_WorkStationsTableAdapter.Fill(this.dataSetWorkStationsLookup.sol_WorkStations);


            //default definition
            comboBoxWorkStation.SelectedValue = 1;
            //comboBoxCategory.SelectedValue = 1;

            sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);
            comboBoxButtonSize.SelectedIndex = 0;

            buttonSender = null;

            buttonClicked = null;
            buttonClickedPrevious = null;

            buttonW = 96;
            buttonH = 66;

            buttonContainerWidth = 239;   //239
            buttonContainerHeight = 488;  //476


            //views
            if (Properties.Settings.Default.SettingsAd17ScreenSetup)
            {
                //buttons 3
                buttonType = 3;

                this.Width = 1280;
                this.Height = 1024;
                this.CenterToScreen();

                buttonContainerWidth = (view3Cells * buttonW)+6; // 239; 
                buttonContainerHeight = 484;

                EnableFormButtonType(ControlType.Button);

                panelCategoryButtons.Visible = false;
                panelGalleryButtons.Visible = false;
                //groupBoxCategoryButtonsDef.Visible = false;

                labelDrag.Visible = false;

                CreatePanelTableLayoutPanelView3Vertical();
                CreatePanelTableLayoutPanelView3Horizontal();

                CreateComboBoxPanel();
                panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Vertical_Buttons;


                buttonAddLabel.Enabled = false;

                //readGalleryButtons(ref panelGalleryButtons);

                this.Show();

                ReadButtons2();

            }
            else if (Main.Sol_ControlInfo.NumericKeyPadOn)
            {
                //buttons 2
                buttonType = 2;

                EnableFormButtonType(ControlType.Button);

                panelCategoryButtons.Visible = false;

                labelDrag.Visible = true;
                CreatePanelTableLayoutPanelView2();

                buttonAddLabel.Enabled = false;
                buttonAddButton.Enabled = false;

                //labelSize.Visible = true;

                readGalleryButtons(ref panelGalleryButtons);

                //panelGalleryButtons

                this.Show();

                ReadButtons2();

                panelTableLayoutPanelView2_Buttons.BackColor = Color.FromArgb(Main.Sol_ControlInfo.CategoryButtonsPanelBgColor);

            }
            else
            {
                //buttons 1
                buttonType = 1;

                EnableFormButtonType(ControlType.Button);

                panelGalleryButtons.Visible = false;
                panelCategoryButtons.Visible = true;

                //read controls for workstation
                ReadControls();

            }

            lastButtonAction = ButtonAction.None;
        }

        private void buttonAddLabel_Click(object sender, EventArgs e)
        {
            ClearForm();
            newFont = defaultFont;
            newFontStyle = defaultFontStyle;

            newForeColor = defaultForeColor;
            newBackColor = defaultBackColor;


            EnableFormButtonType(ControlType.Label);

            EnableButtons(ButtonAction.AddLabel);
        }

        private void AddLabel()
        {
            if (String.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Please enter a description");
                textBoxDescription.Focus();
                return;
            }

            Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();
            //try
            //{
            //    sol_CategoryButton.WorkStationID = Convert.ToInt32(comboBoxWorkStation.SelectedValue.ToString());
            //}
            //catch
            //{
            //    sol_CategoryButton.WorkStationID = 1;
            //}
            sol_CategoryButton.WorkStationID = -1;
            sol_CategoryButton.ControlType = 0;
            sol_CategoryButton.Description = textBoxDescription.Text;

            sol_CategoryButton.DefaultQuantity = 0;
            sol_CategoryButton.CategoryID = 0; 
            sol_CategoryButton.LocationX = 0;
            sol_CategoryButton.LocationY = 0;
            sol_CategoryButton.Width = 0;
            sol_CategoryButton.Height = 0;
            sol_CategoryButton.Font = newFont;
            sol_CategoryButton.FontStyle = newFontStyle;
            sol_CategoryButton.ForeColorArgb = newForeColor.ToArgb();
            sol_CategoryButton.BackColorArgb = newBackColor.ToArgb();

            sol_CategoryButton_Sp.Insert2(sol_CategoryButton);
            sol_CategoryButtonList.Add(sol_CategoryButton);


            //read controls for workstation
            ReadControls();

            EnableButtons(ButtonAction.Save);
            //ClearForm();

        }

        private void buttonAddButton_Click(object sender, EventArgs e)
        {
            if(buttonType == 3
                && (comboBoxPanel.SelectedIndex == 0 && arrayListItems.Count >=28)
                )
            {
                if (MessageBox.Show("You can not add more buttons to the vertical panel!\r\nDo you want to use the horizontal panel instead?", "Deleting item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                {
                    comboBoxPanel.Focus();
                    return;
                }
                comboBoxPanel.SelectedIndex = 1;
                //panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Horizontal_Buttons;
            }            ClearForm();

            newFont = defaultFont;
            newFontStyle = defaultFontStyle;

            newForeColor = defaultForeColor;
            newBackColor = defaultBackColor;

            EnableFormButtonType(ControlType.Button);

            EnableButtons(ButtonAction.AddButton);
        }
        private void AddButton()
        {
            if (buttonType == 3)
            {
                //textBoxDescription.Text = String.Format("{0}", arrayListItems.Count + 1);//

                if (String.IsNullOrEmpty(textBoxDescription.Text))
                {
                    MessageBox.Show("Please enter a description");
                    textBoxDescription.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(textBoxDefaultQuantity.Text))
                {
                    MessageBox.Show("Please enter a Quantity");
                    textBoxDescription.Focus();
                    return;
                }
            }
            else if(buttonType == 2)
            {
                if (buttonSender == null)
                {
                    MessageBox.Show("Please select a button from the gallery");
                    return;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(textBoxDescription.Text))
                {
                    MessageBox.Show("Please enter a description");
                    textBoxDescription.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(textBoxDefaultQuantity.Text))
                {
                    MessageBox.Show("Please enter a Quantity");
                    textBoxDescription.Focus();
                    return;
                }
            }

            bool goToLastPage = false;

            Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();

            //try { sol_CategoryButton.WorkStationID = Convert.ToInt32(comboBoxWorkStation.SelectedValue.ToString()); }
            //catch { sol_CategoryButton.WorkStationID = 1; }
            sol_CategoryButton.WorkStationID = -1;
            byte controlType = buttonType;

            if (buttonType == 3)
            {
                if (comboBoxPanel.SelectedIndex == 0)
                {
                    panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Vertical_Buttons;
                    categoryButtonLocationOnForm = CalculatePointOfButton(controlType, arrayListItems.Count);
                }
                else
                {
                    controlType = 4;
                    panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Horizontal_Buttons;

                    //if panel is full go to last page
                    if(arrayListItems4.Count >= pageSize)
                    {
                        goToLastPage = true;
                        //pageNumber = lastPage;
                        //ReadButtons4();

                    }
                    categoryButtonLocationOnForm = CalculatePointOfButton(controlType, arrayListItems4.Count);

                }

                //sol_CategoryButtonList[indice].LocationX = p.X;
                //sol_CategoryButtonList[indice].LocationY = p.Y;
            }

            sol_CategoryButton.ControlType = controlType;

            sol_CategoryButton.Description = textBoxDescription.Text;

            try { sol_CategoryButton.DefaultQuantity = Convert.ToInt32(textBoxDefaultQuantity.Text); }
            catch { sol_CategoryButton.DefaultQuantity = 1; }

            try { sol_CategoryButton.CategoryID = (int)comboBoxCategory.SelectedValue; }
            catch { sol_CategoryButton.CategoryID = 0; }

            sol_CategoryButton.LocationX = categoryButtonLocationOnForm.X;
            sol_CategoryButton.LocationY = categoryButtonLocationOnForm.Y;

            sol_CategoryButton.Width = 0;
            sol_CategoryButton.Height = 0;

            sol_CategoryButton.Font = newFont;
            sol_CategoryButton.FontStyle = newFontStyle;
            sol_CategoryButton.ForeColorArgb = newForeColor.ToArgb();
            sol_CategoryButton.BackColorArgb = newBackColor.ToArgb();

            if (buttonType == 2)
            {
                sol_CategoryButton.ImageIndex = buttonSender.ImageIndex;

                try { sol_CategoryButton.ImageSize = (byte)comboBoxButtonSize.SelectedIndex; }
                catch { sol_CategoryButton.ImageSize = 0; }
            }
            
            if (buttonType != 1)
            {
                try { sol_CategoryButton.MaxCountPerLine = Convert.ToInt32(textBoxMaxCountPerLine.Text); }
                catch { sol_CategoryButton.MaxCountPerLine = 0; }

                try { sol_CategoryButton.SubContainerMaxCount = Convert.ToInt32(textBoxSubContainerCount.Text); }
                catch { sol_CategoryButton.SubContainerMaxCount = 1; }

                sol_CategoryButton.SubContainerCountDown = checkBoxCountDown.Checked;
            }


            sol_CategoryButton_Sp.Insert2(sol_CategoryButton);

            //read controls for workstation
            if(buttonType == 3)
            {
                if (comboBoxPanel.SelectedIndex == 0)
                {
                    sol_CategoryButtonList.Add(sol_CategoryButton);
                    AddButton2(panelTableLayoutPanelView3_Buttons, sol_CategoryButton
                        , sol_CategoryButtonList
                        , arrayListItems
                        );
                }
                else
                {
                    sol_CategoryButton.ControlType = 4;
                    sol_CategoryButtonList4.Add(sol_CategoryButton);
                    AddButton2(panelTableLayoutPanelView3_Buttons, sol_CategoryButton
                        , sol_CategoryButtonList4
                        , arrayListItems4
                        );

                }
                if (goToLastPage)
                {
                    goToLastPage = false;
                    pageNumber = lastPage;
                    ReadButtons4();
                }

                EnableButtons(ButtonAction.Save);
                ClearForm();
                return;
            }
            else if (buttonType == 2)
            {
                sol_CategoryButtonList.Add(sol_CategoryButton);
                AddButton2(panelTableLayoutPanelView2_Buttons, sol_CategoryButton
                    , sol_CategoryButtonList
                    , arrayListItems
                    );
                EnableButtons(ButtonAction.Save);
                ClearForm();
                //???
                controlName = "Button";
                indice = sol_CategoryButtonList.Count - 1;
                return;
            }
            else
            {
                sol_CategoryButtonList.Add(sol_CategoryButton);
                ReadControls();
            }

            //select last button
            //if (Main.Sol_ControlInfo.NumericKeyPadOn)
            //{
            //    controlName = "Button";
            //    indice = sol_CategoryButtonList.Count - 1;
            //}

            //buttonSender = null;

            EnableButtons(ButtonAction.Save);
            //ClearForm();


        }

        private void AddButton2(MyPanel panelButtons, Sol_CategoryButton cb
            , List<Sol_CategoryButton> buttonList
            , ArrayList listItems
            )
        {

            panelButtons.SuspendLayout();
            this.SuspendLayout();

            int categoryButtonWidth = buttonW;
            int categoryButtonHeight = buttonH;

            indice = buttonList.Count - 1;

            ImageList buttonsImageList;

            switch (cb.ImageSize)
            {
                case 0: //-- 0 = Normal Size 
                    buttonsImageList = Main.bImageList1;
                    categoryButtonWidth = buttonW;
                    categoryButtonHeight = buttonH;
                    break;
                case 1: //-- 1 = Double Width
                    buttonsImageList = Main.bImageList2;
                    categoryButtonWidth = (buttonW * 2);
                    categoryButtonHeight = buttonH;
                    break;
                case 2: //-- 2 = Double Height
                    buttonsImageList = Main.bImageList3;
                    categoryButtonWidth = buttonW;
                    categoryButtonHeight = buttonH * 2;
                    break;
                case 3: //-- 3 = Double Size
                    buttonsImageList = Main.bImageList4;
                    categoryButtonWidth = (buttonW * 2);
                    categoryButtonHeight = buttonH * 2;
                    break;
                default:
                    buttonsImageList = Main.bImageList1;
                    categoryButtonWidth = buttonW;
                    categoryButtonHeight = buttonH;
                    break;
            }


            Color foreColor = SolFunctions.ColorTryParse(cb.ForeColorArgb, cb.ForeColor);
            Color backColor = SolFunctions.ColorTryParse(cb.BackColorArgb, cb.BackColor);

            listItems.Add(new System.Windows.Forms.Button());
            int idx = listItems.Count;

            ((System.Windows.Forms.Button)listItems[indice]).Location = new System.Drawing.Point(
                cb.LocationX, 
                cb.LocationY 
                );

            ((System.Windows.Forms.Button)listItems[indice]).Name = "Button_" + Convert.ToString(indice);
            ((System.Windows.Forms.Button)listItems[indice]).Size = new System.Drawing.Size(categoryButtonWidth, categoryButtonHeight);

            //((System.Windows.Forms.Button)arrayListItems[indice]).Width = categoryButtonWidth;
            //((System.Windows.Forms.Button)arrayListItems[indice]).Height = categoryButtonHeight;

            ((System.Windows.Forms.Button)listItems[indice]).TabIndex = indice + 2;
            ((System.Windows.Forms.Button)listItems[indice]).Text = cb.Description.Trim();

            ((System.Windows.Forms.Button)listItems[indice]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);
            ((System.Windows.Forms.Button)listItems[indice]).ForeColor = foreColor;

            ((System.Windows.Forms.Button)listItems[indice]).BackColor = backColor;
            ((System.Windows.Forms.Button)listItems[indice]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ((System.Windows.Forms.Button)listItems[indice]).Cursor = System.Windows.Forms.Cursors.Hand;

            ((System.Windows.Forms.Button)listItems[indice]).FlatAppearance.BorderSize = 1;
            //((System.Windows.Forms.Button)arrayListItems[indice]).FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            //((System.Windows.Forms.Button)arrayListItems[indice]).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

            ((System.Windows.Forms.Button)listItems[indice]).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ((System.Windows.Forms.Button)listItems[indice]).UseVisualStyleBackColor = false;

            //Image img = Main.buttonsImageList.Images[cb.ImageIndex];
            //((System.Windows.Forms.Button)arrayListItems[indice]).Image = img;

            if (Properties.Settings.Default.SettingsAd17ScreenSetup)
            {
                //((System.Windows.Forms.Button)arrayListItems[indice]).FlatStyle = FlatStyle.Flat;
                //((System.Windows.Forms.Button)arrayListItems[indice]).FlatAppearance.BorderSize = 1;
            }
            else
            {
                ((System.Windows.Forms.Button)listItems[indice]).ImageList = buttonsImageList;
                ((System.Windows.Forms.Button)listItems[indice]).ImageIndex = cb.ImageIndex;
            }

            ((System.Windows.Forms.Button)listItems[indice]).Click += new System.EventHandler(this.button_Click);

            ((System.Windows.Forms.Button)listItems[indice]).MouseDown += new System.Windows.Forms.MouseEventHandler(this.catButton_MouseDown);
            ((System.Windows.Forms.Button)listItems[indice]).MouseUp += new System.Windows.Forms.MouseEventHandler(this.catButton_MouseUp);


            panelButtons.Controls.Add(((System.Windows.Forms.Button)listItems[indice]));
            SirLib.ControlMover.Init(((System.Windows.Forms.Button)listItems[indice]));

            //break;

            panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

            this.Refresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SettingsAd17ScreenSetup
                || Main.Sol_ControlInfo.NumericKeyPadOn)
            {
                if(indice <0)
                {
                    MessageBox.Show("Please select a button to delete!");
                    return;
                }
                //get last one
                //indice--;

            }
            else
            {
                if (String.IsNullOrEmpty(controlName) || indice < 0)
                {
                    MessageBox.Show("Please select a Label or a button category.");
                    return;
                }
            }

            if (MessageBox.Show("Are you sure you want to delete this item?", "Deleting item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                return;


            if(updateFlag)
            {
                if (MessageBox.Show("Do you want to save pending changes?", "Save item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    button2SaveAll();
                }
            }


            //sol_CategoryButtonList.RemoveAt(indice);
            //panelCategoryButtons.Controls.Remove(((System.Windows.Forms.Control)this.arrayListItems[indice]));
            //((System.Windows.Forms.Control)this.arrayListItems[indice]).Dispose();
            //arrayListItems.RemoveAt(indice);

            //if (!Properties.Settings.Default.SettingsAd17ScreenSetup
            //    && Main.Sol_ControlInfo.NumericKeyPadOn)
            //{
            //    button2SaveAll();
            //}

            if (buttonType == 3)
            {
                if (comboBoxPanel.SelectedIndex == 0)
                    CategoryButtonID = sol_CategoryButtonList[indice].CategoryButtonID;
                else
                    CategoryButtonID = sol_CategoryButtonList4[indice].CategoryButtonID;
            }
            else
            {
                CategoryButtonID = sol_CategoryButtonList[indice].CategoryButtonID;
            }

            sol_CategoryButton_Sp.Delete(CategoryButtonID);

            //panelCategoryButtons.Controls.Remove(((System.Windows.Forms.Button)this.arrayListItems[indice]));
            //((System.Windows.Forms.Button)this.arrayListItems[indice]).Dispose();

            //read controls for workstation
            if (Properties.Settings.Default.SettingsAd17ScreenSetup)
            {
                ReadButtons2();
            }
            else if (Main.Sol_ControlInfo.NumericKeyPadOn)
            {
                //ReadButtons2();
                ReadButtons2();
            }
            else
                ReadControls();

            EnableButtons(ButtonAction.Delete);
            ClearForm();
          
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //read controls for workstation
            if (buttonType == 1)
                ReadControls();
            else
                ReadButtons2();

            EnableButtons(ButtonAction.Cancel);
            //ClearForm();

        }

        private void ClearForm()
        {
            indice = -1;
            buttonClicked = null;
            buttonClickedPrevious = buttonClicked;

            textBoxDescription.Text = string.Empty;
            textBoxMaxCountPerLine.Text = string.Empty;
            textBoxDefaultQuantity.Text = "1";
            checkBoxCountDown.Checked = false;
            comboBoxCategory.SelectedIndex = 0;

            comboBoxButtonSize.SelectedIndex = 0;

            groupBoxControlInformation.Enabled = false;
            if (comboBoxPanel != null)
                comboBoxPanel.Enabled = true;

            updateFlag = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            switch (lastButtonAction)
            {
                case ButtonAction.AddButton:
                    AddButton();
                    return;

                case ButtonAction.AddLabel:
                    AddLabel();
                    return;
            }

            if (!Properties.Settings.Default.SettingsAd17ScreenSetup
                && Main.Sol_ControlInfo.NumericKeyPadOn)
            {
                button2SaveAll();
                EnableButtons(ButtonAction.Save);
                ClearForm();
                return;
            }

            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {
                MessageBox.Show("Please select a, item.");
                return;
            }

            if (String.IsNullOrEmpty(textBoxDefaultQuantity.Text) && controlName == "Button")
            {
                MessageBox.Show("Please enter a default quantity");
                textBoxDefaultQuantity.Focus();
                return;
            }

            if (String.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Please enter a description");
                textBoxDescription.Focus();
                return;
            }

            button2SaveAll();
            EnableButtons(ButtonAction.Save);

        }

        private void button2SaveAll()
        {
            foreach (Sol_CategoryButton cb in sol_CategoryButtonList)
            {
                sol_CategoryButton_Sp.Update2(cb);
            }

            if(buttonType == 3)
            {
                foreach (Sol_CategoryButton cb in sol_CategoryButtonList4)
                {
                    sol_CategoryButton_Sp.Update2(cb);
                }

            }


            //ReadButtons2();
            updateFlag = false;
        }

    

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {
                MessageBox.Show("Please select a Label or a button category.");
                return;
            }

            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                ((System.Windows.Forms.Control)panelCategoryButtons.Controls["Label_" + indice.ToString()]).Font = Funciones.FontParser(defaultFont, defaultFontStyle);
                ((System.Windows.Forms.Control)panelCategoryButtons.Controls["Label_" + indice.ToString()]).ForeColor = defaultForeColor;
                ((System.Windows.Forms.Control)panelCategoryButtons.Controls["Label_" + indice.ToString()]).BackColor = DefaultBackColor;
            }
            else
            {
                ((System.Windows.Forms.Control)panelCategoryButtons.Controls["Label_" + indice.ToString()]).Font = Funciones.FontParser(defaultFont, defaultFontStyle);
                ((System.Windows.Forms.Control)panelCategoryButtons.Controls["Label_" + indice.ToString()]).ForeColor = defaultForeColor;
                ((System.Windows.Forms.Control)panelCategoryButtons.Controls["Label_" + indice.ToString()]).BackColor = DefaultBackColor;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (updateFlag)
            {
                if (MessageBox.Show("Do you want to save pending changes?", "Save item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    button2SaveAll();
                }
            }

            Close();
        }

        //read controls for workstation buttonType 1
        private void ReadControls()
        {
            panelCategoryButtons.Controls.Clear();

            //sol_CategoryButtonList = new List<Sol_CategoryButton>();
            //Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();
            //sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);

            sol_CategoryButtonList = sol_CategoryButton_Sp._SelectAllByButtonType(/*Main.Sol_ControlInfo.WorkStationID,*/ buttonType);

            this.arrayListItems = new ArrayList();

            int numberOfButtons = 3, buttonNumber = 1, panelWidth = panelCategoryButtons.Size.Width + 10;

            int scrollBarLength = 27;  //20
            int separationLength = 20;

            decimal ajuste = 1m;  // 0.95m;
            decimal ajusteHeight = 0.79m;
            int labelWidth = panelWidth - scrollBarLength, labelHeight = 34;  //37
            labelWidth = (int)(labelWidth * ajuste);
            labelHeight = (int)(labelHeight * ajusteHeight);
            int buttonWidth = (panelWidth - separationLength - scrollBarLength) / numberOfButtons, buttonHeight = 68; // 76 55;

            buttonWidth = (int)(buttonWidth * ajuste);
            buttonHeight = (int)(buttonHeight * ajusteHeight);

            //int labelWidth = 481, labelHeight = 37;
            //int buttonWidth = 154, buttonHeight = 55;


            //int buttonWidth = 113, buttonHeight = 60;
            int separatorX = 10, separatorY = 8;    //10

            int locationX = 0;  // panelCategoryButtons.Location.X;
            int locationY = panelCategoryButtons.Location.Y;

            int col = 0;
            int i = 0;
            foreach (Sol_CategoryButton cb in sol_CategoryButtonList)
            {

                Color foreColor = SolFunctions.ColorTryParse(cb.ForeColorArgb, cb.ForeColor);
                Color backColor = SolFunctions.ColorTryParse(cb.BackColorArgb, cb.BackColor);

                switch (cb.ControlType)
                {
                    case 0: //Label

                        //textBoxDescription.Text = cb.Description;
                        locationX = 0;  // panel1.Location.X;
                        //locationY += separatorY;
                        if (i == 0)
                            locationY -= separatorY;

                        if (col > 0)
                        {
                            col = 0;
                            locationY += buttonHeight + separatorY;
                        }


                        this.arrayListItems.Add(new System.Windows.Forms.Label());

                        ((System.Windows.Forms.Label)this.arrayListItems[i]).Location = new System.Drawing.Point(
                            //panel1.Location.X + cb.LocationX,
                            //panel1.Location.Y + cb.LocationY
                        locationX + separatorX,
                        locationY + separatorY
                        );

                        locationX = 0;  // panel1.Location.X;
                        locationY += labelHeight + separatorY;

                        ((System.Windows.Forms.Label)this.arrayListItems[i]).Name = "Label_" + Convert.ToString(i);
                        ((System.Windows.Forms.Label)this.arrayListItems[i]).Size = new System.Drawing.Size(labelWidth, labelHeight);   // cb.Width, cb.Height);
                        ((System.Windows.Forms.Label)this.arrayListItems[i]).TabIndex = i + 2;
                        ((System.Windows.Forms.Label)this.arrayListItems[i]).Text = cb.Description.Trim();

                        ((System.Windows.Forms.Label)this.arrayListItems[i]).TextAlign = ContentAlignment.MiddleCenter;
                        ((System.Windows.Forms.Label)this.arrayListItems[i]).BorderStyle = BorderStyle.FixedSingle;

                        ((System.Windows.Forms.Label)this.arrayListItems[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);
                        //ChangeFontSize(((System.Windows.Forms.Label)this.arrayListItems[i]).Font, 12);
                        ((System.Windows.Forms.Label)this.arrayListItems[i]).ForeColor = foreColor;
                        ((System.Windows.Forms.Label)this.arrayListItems[i]).BackColor = backColor;

                        ((System.Windows.Forms.Label)this.arrayListItems[i]).Click += new System.EventHandler(this.label_Click);

                        //this.Controls.Add(((System.Windows.Forms.Label)this.arrayListItems[i]));
                        panelCategoryButtons.Controls.Add(((System.Windows.Forms.Label)this.arrayListItems[i++]));

                        break;
                    case 1: //Button
                        //locationX += separatorX;
                        //if (col == 0)
                        //    locationY += separatorY;

                        int buttonWidth2 = buttonWidth;

                        if (buttonNumber > 1)
                            buttonWidth2 = (int)(buttonWidth / 1.32);
                        else
                            buttonWidth2 = (int)(buttonWidth * 1.50);

                        buttonNumber++;
                        if (buttonNumber > numberOfButtons) buttonNumber = 1;

                        this.arrayListItems.Add(new System.Windows.Forms.Button());
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Location = new System.Drawing.Point(
                            //panel1.Location.X + cb.LocationX,
                            //panel1.Location.Y + cb.LocationY
                        locationX + separatorX,
                        locationY + separatorY
                        );

                        locationX += buttonWidth2 + separatorX;
                        col++;
                        if (col > 2)
                        {
                            col = 0;
                            locationX = 0;// panel1.Location.X;
                            locationY += buttonHeight + separatorY;
                        }

                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Name = "Button_" + Convert.ToString(i);
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Size = new System.Drawing.Size(buttonWidth2, buttonHeight);    //cb.Width, cb.Height);
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).TabIndex = i + 2;
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Text = cb.Description.Trim();

                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).ForeColor = foreColor;
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).BackColor = backColor;

                        ((System.Windows.Forms.Button)this.arrayListItems[i]).Click += new System.EventHandler(this.button_Click);

                        //this.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i]));
                        panelCategoryButtons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i++]));

                        break;

                }
            }

            //panel1.SendToBack();


        }

        private void label_Click(object sender, EventArgs e)
        {
            EnableButtons(ButtonAction.Edit);

            EnableFormButtonType(ControlType.Label);

            controlName = "Label";
            Label lbl = (Label)sender;
            string[] strControl = lbl.Name.Split('_');
            indice = Convert.ToInt32(strControl[1]);

            //foreach (System.Windows.Forms.Control ctrl in panelCategoryButtons.Controls)
            //{
            //    //ctrl.BackColor = SystemColors.Control;
            //    try
            //    {
            //        ((Label)ctrl).BorderStyle = BorderStyle.FixedSingle;
            //    }
            //    catch
            //    { }

            //}

            //lbl.BackColor = SystemColors.ActiveCaption;

            newFont = lbl.Font.ToString();
            newFontStyle = lbl.Font.Style.ToString();

            newForeColor = lbl.ForeColor;
            newBackColor = lbl.BackColor;

            lbl.BorderStyle = BorderStyle.Fixed3D;

            this.textBoxDescription.TextChanged -= new System.EventHandler(this.textBoxDescription_TextChanged);
            this.textBoxDefaultQuantity.Leave -= new System.EventHandler(this.textBoxDefaultQuantity_Leave);
            this.comboBoxCategory.SelectedValueChanged -= new System.EventHandler(this.comboBoxCategory_SelectedValueChanged);

            textBoxDescription.Text = lbl.Text;
            textBoxDefaultQuantity.Text = "";
            comboBoxCategory.SelectedValue = 0;

            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            this.textBoxDefaultQuantity.Leave += new System.EventHandler(this.textBoxDefaultQuantity_Leave);
            this.comboBoxCategory.SelectedValueChanged += new System.EventHandler(this.comboBoxCategory_SelectedValueChanged);

        }

        private void button_Click(object sender, EventArgs e)
        {
            bool f = updateFlag;

            EnableButtons(ButtonAction.Edit);

            if (buttonClickedPrevious != null)
                buttonClickedPrevious.FlatAppearance.BorderSize = 1;

            //buttonColor.Enabled = !buttonColor.Enabled;
            //textBoxSubContainerCount.Enabled = true;

            EnableFormButtonType(ControlType.Button);

            controlName = "Button";
            buttonClicked = (Button)sender;
            buttonClickedPrevious = buttonClicked;
            buttonClicked.FlatAppearance.BorderSize = 2;

            string[] strControl = buttonClicked.Name.Split('_');
            indice = Convert.ToInt32(strControl[1]);

            if (buttonType == 3)
            {
                Control tp = buttonClicked.Parent as Control; //tab panel
                //Control tc = tp.Parent as Control;  //tab container
                //Control ri = tc.Parent as Control;  //repeater item
                if (tp.Name == "panelTableLayoutPanelView3Horizontal")
                    comboBoxPanel.SelectedIndex = 1;
                else
                    comboBoxPanel.SelectedIndex = 0;
            }

            this.buttonFont.Click -= new System.EventHandler(this.buttonFont_Click);
            this.buttonColor.Click -= new System.EventHandler(this.buttonColor_Click);
            this.textBoxDescription.TextChanged -= new System.EventHandler(this.textBoxDescription_TextChanged);
            this.textBoxMaxCountPerLine.Leave -= new System.EventHandler(this.textBoxMaxCountPerLine_Leave);
            this.textBoxDefaultQuantity.Leave -= new System.EventHandler(this.textBoxDefaultQuantity_Leave);
            this.checkBoxCountDown.CheckedChanged -= new System.EventHandler(this.checkBoxCountDown_CheckedChanged);
            this.comboBoxCategory.SelectedValueChanged -= new System.EventHandler(this.comboBoxCategory_SelectedValueChanged);
            this.comboBoxButtonSize.SelectedIndexChanged -= new System.EventHandler(this.comboBoxButtonSize_SelectedIndexChanged);
            //this.comboBoxButtonSize.SelectedValueChanged -= new System.EventHandler(this.comboBoxButtonSize_SelectedValueChanged);

            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                textBoxDescription.Text = sol_CategoryButtonList4[indice].Description;   // buttonClicked.Text;
                textBoxMaxCountPerLine.Text = sol_CategoryButtonList4[indice].MaxCountPerLine.ToString();
                textBoxDefaultQuantity.Text = sol_CategoryButtonList4[indice].DefaultQuantity.ToString();
                textBoxSubContainerCount.Text = sol_CategoryButtonList4[indice].SubContainerMaxCount.ToString();
                checkBoxCountDown.Checked = sol_CategoryButtonList4[indice].SubContainerCountDown;
                comboBoxCategory.SelectedValue = sol_CategoryButtonList4[indice].CategoryID;
                newFont = sol_CategoryButtonList4[indice].Font.ToString();
                newFontStyle = sol_CategoryButtonList4[indice].FontStyle.ToString();
                newForeColor = Color.FromArgb(sol_CategoryButtonList4[indice].ForeColorArgb);
                newBackColor = Color.FromArgb(sol_CategoryButtonList4[indice].BackColorArgb);
                comboBoxButtonSize.SelectedIndex = sol_CategoryButtonList4[indice].ImageSize;
            }
            else
            {
                textBoxDescription.Text = sol_CategoryButtonList[indice].Description;   // buttonClicked.Text;
                textBoxMaxCountPerLine.Text = sol_CategoryButtonList[indice].MaxCountPerLine.ToString();
                textBoxDefaultQuantity.Text = sol_CategoryButtonList[indice].DefaultQuantity.ToString();
                textBoxSubContainerCount.Text = sol_CategoryButtonList[indice].SubContainerMaxCount.ToString();
                checkBoxCountDown.Checked = sol_CategoryButtonList[indice].SubContainerCountDown;
                comboBoxCategory.SelectedValue = sol_CategoryButtonList[indice].CategoryID;
                newFont = sol_CategoryButtonList[indice].Font.ToString();
                newFontStyle = sol_CategoryButtonList[indice].FontStyle.ToString();
                newForeColor = Color.FromArgb(sol_CategoryButtonList[indice].ForeColorArgb);
                newBackColor = Color.FromArgb(sol_CategoryButtonList[indice].BackColorArgb);
                comboBoxButtonSize.SelectedIndex = sol_CategoryButtonList[indice].ImageSize;
                if (buttonType == 2)
                {
                    //get button location
                    categoryButtonLocationOnForm = Funciones.LeerPosicionRelativa(panelTableLayoutPanelView2_Buttons, buttonClicked);
                    sol_CategoryButtonList[indice].LocationX = categoryButtonLocationOnForm.X;
                    sol_CategoryButtonList[indice].LocationY = categoryButtonLocationOnForm.Y;
                }
            }

            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            this.textBoxMaxCountPerLine.Leave += new System.EventHandler(this.textBoxMaxCountPerLine_Leave);
            this.textBoxDefaultQuantity.Leave += new System.EventHandler(this.textBoxDefaultQuantity_Leave);
            this.checkBoxCountDown.CheckedChanged += new System.EventHandler(this.checkBoxCountDown_CheckedChanged);
            this.comboBoxCategory.SelectedValueChanged += new System.EventHandler(this.comboBoxCategory_SelectedValueChanged);
            this.comboBoxButtonSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxButtonSize_SelectedIndexChanged);
            //this.comboBoxButtonSize.SelectedValueChanged += new System.EventHandler(this.comboBoxButtonSize_SelectedValueChanged);


            f = updateFlag;
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {

                if (Properties.Settings.Default.SettingsAd17ScreenSetup
                    || !Main.Sol_ControlInfo.NumericKeyPadOn)
                {
                    fontDialog1.ShowColor = true;
                    if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                    {

                        newForeColor = fontDialog1.Color;
                        newFont = fontDialog1.Font.ToString();
                        newFontStyle = fontDialog1.Font.Style.ToString();

                    }
                    return;
                }


                MessageBox.Show("Please select a Label or a button category.");
                return;
            }

            fontDialog1.ShowColor = true;
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                fontDialog1.Font = ((System.Windows.Forms.Control)this.arrayListItems4[indice]).Font;
                fontDialog1.Color = ((System.Windows.Forms.Control)this.arrayListItems4[indice]).ForeColor;
            }
            else
            {
                fontDialog1.Font = ((System.Windows.Forms.Control)this.arrayListItems[indice]).Font;
                fontDialog1.Color = ((System.Windows.Forms.Control)this.arrayListItems[indice]).ForeColor;
            }

            //try
            //{
                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {

                    newForeColor = fontDialog1.Color;
                    newFont = fontDialog1.Font.ToString();
                    newFontStyle = fontDialog1.Font.Style.ToString();

                    if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
                    {
                        ((System.Windows.Forms.Control)this.arrayListItems4[indice]).Font = Funciones.FontParser(newFont, newFontStyle);
                        ((System.Windows.Forms.Control)this.arrayListItems4[indice]).ForeColor = newForeColor;

                        sol_CategoryButtonList4[indice].Font = Funciones.FontParser(newFont, newFontStyle).ToString();
                        sol_CategoryButtonList4[indice].FontStyle = newFontStyle;
                        sol_CategoryButtonList4[indice].ForeColorArgb = newForeColor.ToArgb();
                    }
                    else
                    {
                        ((System.Windows.Forms.Control)this.arrayListItems[indice]).Font = Funciones.FontParser(newFont, newFontStyle);
                        ((System.Windows.Forms.Control)this.arrayListItems[indice]).ForeColor = newForeColor;

                        sol_CategoryButtonList[indice].Font = Funciones.FontParser(newFont, newFontStyle).ToString();
                        sol_CategoryButtonList[indice].FontStyle = newFontStyle;
                        sol_CategoryButtonList[indice].ForeColorArgb = newForeColor.ToArgb();
                    }

                    updateFlag = true;
                }
            //}
            //catch
            //{
            //    //MessageBox.Show("Only TrueType fonts are supported.");
            //}


        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(controlName) || indice < 0)
            {

                if (Properties.Settings.Default.SettingsAd17ScreenSetup
                    || !Main.Sol_ControlInfo.NumericKeyPadOn)
                {
                    //colorDialog1.AllowFullOpen = true;
                    //colorDialog1.AnyColor = true;
                    //colorDialog1.SolidColorOnly = false;

                    if (colorDialog1.ShowDialog() != DialogResult.Cancel)
                    {
                        newBackColor = colorDialog1.Color;

                    }
                    return;
                }


                MessageBox.Show("Please select a Label or a button category.");
                return;
            }

            //ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            //colorDialog1.AllowFullOpen = false;
            //colorDialog1.AnyColor = true;
            //colorDialog1.SolidColorOnly = false;
            //colorDialog1.Color = Color.Red; 
            
            // Allows the user to get help. (The default is false.)
            colorDialog1.ShowHelp = true;
            // Sets the initial color select to the current text color.
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                colorDialog1.Color = ((System.Windows.Forms.Control)this.arrayListItems4[indice]).BackColor;
            }
            else
            {
                colorDialog1.Color = ((System.Windows.Forms.Control)this.arrayListItems[indice]).BackColor;
            }

            //???
            //colorDialog1.Color = label7.ForeColor;

            //try
            //{
                // Update the text box color if the user clicks OK 
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    newBackColor = colorDialog1.Color;

                    //int backColor = colorDialog1.Color.ToArgb();
                    //Color bc = Color.FromArgb(backColor);
                    if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
                    {
                        ((System.Windows.Forms.Control)this.arrayListItems4[indice]).BackColor = newBackColor;
                        sol_CategoryButtonList4[indice].BackColorArgb = newBackColor.ToArgb();
                    }
                    else
                    {
                        ((System.Windows.Forms.Control)this.arrayListItems[indice]).BackColor = newBackColor;
                        sol_CategoryButtonList[indice].BackColorArgb = newBackColor.ToArgb();
                    }

                    updateFlag = true;

                }
            //}
            //catch
            //{
            //    MessageBox.Show("Color not supported.");
            //}

        }

        private void comboBoxWorkStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadControls();

        }

        private void CategoryButtons_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
                Funciones.TecladoVirtual(ref Main._pVirtualKb, false);

                //numericUpDownSnapToGridWidth.Value = Main.CategoryButtons_SnapToGridWidth;
                //numericUpDownSnapToGridHeight.Value = Main.CategoryButtons_SnapToGridHeight;

        }

        private void toolStripButtonVirtualKb_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                if (Main._pVirtualKb == null)
                    Funciones.TecladoVirtual(ref Main._pVirtualKb, true);
                else
                    Funciones.TecladoVirtual(ref Main._pVirtualKb, false);
            }

        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                if (sol_CategoryButtonList4 == null || indice < 0)
                    return;

                updateFlag = true;
                sol_CategoryButtonList4[indice].Description = textBoxDescription.Text;
                //buttonClicked.Text = textBoxDescription.Text;
                ((System.Windows.Forms.Control)this.arrayListItems4[indice]).Text = textBoxDescription.Text;
            }
            else
            {
                if (sol_CategoryButtonList == null || indice < 0)
                    return;

                updateFlag = true;
                sol_CategoryButtonList[indice].Description = textBoxDescription.Text;
                //buttonClicked.Text = textBoxDescription.Text;
                ((System.Windows.Forms.Control)this.arrayListItems[indice]).Text = textBoxDescription.Text;
            }

        }

        private void textBoxMaxCountPerLine_Leave(object sender, EventArgs e)
        {
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                if (sol_CategoryButtonList4 == null || indice < 0)
                    return;

                updateFlag = true;
                try { sol_CategoryButtonList4[indice].MaxCountPerLine = Convert.ToInt32(textBoxMaxCountPerLine.Text); }
                catch { sol_CategoryButtonList4[indice].MaxCountPerLine = 0; }
            }
            else
            {
                if (sol_CategoryButtonList == null || indice < 0)
                    return;

                updateFlag = true;
                try { sol_CategoryButtonList[indice].MaxCountPerLine = Convert.ToInt32(textBoxMaxCountPerLine.Text); }
                catch { sol_CategoryButtonList[indice].MaxCountPerLine = 0; }
            }

        }

        private void textBoxDefaultQuantity_Leave(object sender, EventArgs e)
        {
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                if (sol_CategoryButtonList4 == null || indice < 0)
                    return;

                updateFlag = true;
                try { sol_CategoryButtonList4[indice].DefaultQuantity = Convert.ToInt32(textBoxDefaultQuantity.Text); }
                catch { sol_CategoryButtonList4[indice].DefaultQuantity = 1; }
            }
            else
            {
                if (sol_CategoryButtonList == null || indice < 0)
                    return;

                updateFlag = true;
                try { sol_CategoryButtonList[indice].DefaultQuantity = Convert.ToInt32(textBoxDefaultQuantity.Text); }
                catch { sol_CategoryButtonList[indice].DefaultQuantity = 1; }
            }

        }

        private void textBoxSubContainerCount_Leave(object sender, EventArgs e)
        {
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                if (sol_CategoryButtonList4 == null || indice < 0)
                    return;

                updateFlag = true;
                try { sol_CategoryButtonList4[indice].SubContainerMaxCount = Convert.ToInt32(textBoxSubContainerCount.Text); }
                catch { sol_CategoryButtonList4[indice].SubContainerMaxCount = 1; }
            }
            else
            {
                if (sol_CategoryButtonList == null || indice < 0)
                    return;

                updateFlag = true;
                try { sol_CategoryButtonList[indice].SubContainerMaxCount = Convert.ToInt32(textBoxSubContainerCount.Text); }
                catch { sol_CategoryButtonList[indice].SubContainerMaxCount = 1; }
            }

        }

        private void checkBoxCountDown_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                if (sol_CategoryButtonList4 == null || indice < 0)
                    return;

                updateFlag = true;
                sol_CategoryButtonList4[indice].SubContainerCountDown = checkBoxCountDown.Checked;
            }
            else
            {
                if (sol_CategoryButtonList == null || indice < 0)
                    return;

                updateFlag = true;
                sol_CategoryButtonList[indice].SubContainerCountDown = checkBoxCountDown.Checked;
            }

        }


        private void comboBoxCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                if (sol_CategoryButtonList4 == null || indice < 0)
                    return;
                updateFlag = true;

                //category
                try { sol_CategoryButtonList4[indice].CategoryID = (int)comboBoxCategory.SelectedValue; }
                catch { sol_CategoryButtonList4[indice].CategoryID = 0; }
            }
            else
            {
                if (sol_CategoryButtonList == null || indice < 0)
                    return;
                updateFlag = true;

                //category
                try { sol_CategoryButtonList[indice].CategoryID = (int)comboBoxCategory.SelectedValue; }
                catch { sol_CategoryButtonList[indice].CategoryID = 0; }
            }
        }

        //???
        //private void comboBoxButtonSize_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
        //    {
        //        if (sol_CategoryButtonList4 == null || indice < 0)
        //            return;
        //        updateFlag = true;

        //        try { sol_CategoryButtonList4[indice].ImageSize = (byte)comboBoxButtonSize.SelectedIndex; }
        //        catch { sol_CategoryButtonList4[indice].ImageSize = 0; }
        //    }
        //    else
        //    {
        //        if (sol_CategoryButtonList == null || indice < 0)
        //            return;
        //        updateFlag = true;

        //        try { sol_CategoryButtonList[indice].ImageSize = (byte)comboBoxButtonSize.SelectedIndex; }
        //        catch { sol_CategoryButtonList[indice].ImageSize = 0; }
        //    }
        //}

        
        private void comboBoxButtonSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buttonType == 3 && comboBoxPanel.SelectedIndex == 1)
            {
                if (sol_CategoryButtonList4 == null || indice < 0)
                    return;

                updateFlag = true;

                ImageList buttonsImageList;
                //sol_CategoryButtonList[indice].ImageSize

                switch (comboBoxButtonSize.SelectedIndex)
                {
                    case 0: //-- 0 = Normal Size
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                    case 1: //-- 1 = Double Width
                        buttonsImageList = Main.bImageList2;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH;
                        break;
                    case 2: //-- 2 = Double Height
                        buttonsImageList = Main.bImageList3;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH * 2;
                        break;
                    case 3: //-- 3 = Double Size
                        buttonsImageList = Main.bImageList4;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH * 2;
                        break;
                    default:
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                }

                sol_CategoryButtonList4[indice].ImageSize = (byte)comboBoxButtonSize.SelectedIndex;
                //sol_CategoryButtonList[indice].ImageIndex = (byte)comboBoxButtonSize.SelectedIndex;
                sol_CategoryButtonList4[indice].Width = categoryButtonWidth;
                sol_CategoryButtonList4[indice].Height = categoryButtonHeight;

                ((System.Windows.Forms.Button)this.arrayListItems4[indice]).Size = new System.Drawing.Size(categoryButtonWidth, categoryButtonHeight);
                ((System.Windows.Forms.Button)this.arrayListItems4[indice]).ImageList = buttonsImageList;
                //((System.Windows.Forms.Button)this.arrayListItems[indice]).ImageIndex = (byte)comboBoxButtonSize.SelectedIndex;
            }
            else
            {
                if (sol_CategoryButtonList == null || indice < 0)
                    return;

                updateFlag = true;

                ImageList buttonsImageList;
                //sol_CategoryButtonList[indice].ImageSize

                switch (comboBoxButtonSize.SelectedIndex)
                {
                    case 0: //-- 0 = Normal Size
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                    case 1: //-- 1 = Double Width
                        buttonsImageList = Main.bImageList2;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH;
                        break;
                    case 2: //-- 2 = Double Height
                        buttonsImageList = Main.bImageList3;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH * 2;
                        break;
                    case 3: //-- 3 = Double Size
                        buttonsImageList = Main.bImageList4;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH * 2;
                        break;
                    default:
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                }

                sol_CategoryButtonList[indice].ImageSize = (byte)comboBoxButtonSize.SelectedIndex;
                //sol_CategoryButtonList[indice].ImageIndex = (byte)comboBoxButtonSize.SelectedIndex;
                sol_CategoryButtonList[indice].Width = categoryButtonWidth;
                sol_CategoryButtonList[indice].Height = categoryButtonHeight;

                ((System.Windows.Forms.Button)this.arrayListItems[indice]).Size = new System.Drawing.Size(categoryButtonWidth, categoryButtonHeight);
                ((System.Windows.Forms.Button)this.arrayListItems[indice]).ImageList = buttonsImageList;
                //((System.Windows.Forms.Button)this.arrayListItems[indice]).ImageIndex = (byte)comboBoxButtonSize.SelectedIndex;
            }

        }

        #region PanelTableLayoutPanelView2 Routines   //NumericKeyPad On

        private void CreatePanelTableLayoutPanelView2()
        {
            panelTableLayoutPanelView2_Buttons = new MyPanel();
            panelTableLayoutPanelView2_Buttons.scroolFlag = true;
            panelTableLayoutPanelView2_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTableLayoutPanelView2
            // 
            panelTableLayoutPanelView2_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(56)))));
            panelTableLayoutPanelView2_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTableLayoutPanelView2_Buttons.Location = new System.Drawing.Point(3, 3);
            panelTableLayoutPanelView2_Buttons.Name = "panelTableLayoutPanelView2";
            //this.panelTableLayoutPanelView2.Size = new System.Drawing.Size(245, 482);
            panelTableLayoutPanelView2_Buttons.TabIndex = 0;

            panelTableLayoutPanelView2_Buttons.AutoScroll = true;

            panelTableLayoutPanelView2_Buttons.AllowDrop = true;
            panelTableLayoutPanelView2_Buttons.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelTableLayoutPanelView2_DragDrop);
            panelTableLayoutPanelView2_Buttons.DragOver += new System.Windows.Forms.DragEventHandler(this.panelTableLayoutPanelView2_DragOver);

            panelTableLayoutPanelView2_Buttons.Click += new System.EventHandler(panelTableLayoutPanelView2_Buttons_Click);


            this.groupBoxCategoryButtonsDef.Controls.Add(panelTableLayoutPanelView2_Buttons);
            this.groupBoxCategoryButtonsDef.Size = new System.Drawing.Size(buttonContainerWidth, buttonContainerHeight);  //245, 482);

            this.panelGalleryButtons.Location = new System.Drawing.Point(
                this.groupBoxCategoryButtonsDef.Location.X + 265,
                this.groupBoxCategoryButtonsDef.Location.Y + 10);

            panelTableLayoutPanelView2_Buttons.ResumeLayout(false);

            this.ResumeLayout(false);

        }


        private void panelTableLayoutPanelView2_DragDrop(object sender, DragEventArgs e)
        {

            //aqui
            //Button btn = (Button)sender;
            ////get button location
            //categoryButtonLocationOnForm = Funciones.LeerPosicionRelativa(panelTableLayoutPanelView2_Buttons, btn);

            Point p = new Point();
            p = panelTableLayoutPanelView2_Buttons.PointToClient((MousePosition));


            //Point p = new Point();
            //p.X = ((Button)sender).Location.X + (e.X - MouseDownX);
            //p.Y = ((Button)sender).Location.Y + (e.Y - MouseDownY);

            //Size s = new Size();
            //s.Width = ((Button)sender).Size.Width;
            //s.Height = ((Button)sender).Size.Height;

            //if (Main.Sol_ControlInfo.CategoryButtonsSnapToGrid)
            //{
            //    //p = snapToGrid(p);
            //    p = SnapCalculate(p, s);
            //    //((Button)sender).Location = p;
            //}

            //categoryButtonLocationOnForm = p;   // this.PointToClient(p);
            categoryButtonLocationOnForm = p;

            //buttonAddButton.PerformClick();

            ClearForm();
            newFont = defaultFont;
            newFontStyle = defaultFontStyle;

            newForeColor = defaultForeColor;
            newBackColor = defaultBackColor;

            EnableFormButtonType(ControlType.Button);
            EnableButtons(ButtonAction.AddButton);
            AddButton();
            //ReadButtons2();


        }

        private void panelTableLayoutPanelView2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void panelTableLayoutPanelView2_Buttons_Click(object sender, EventArgs e)
        {
            if (buttonClickedPrevious != null)
                buttonClickedPrevious.FlatAppearance.BorderSize = 1;

            indice = -1;
            buttonClicked = null;
            buttonClickedPrevious = null;
            buttonSender = null;

            textBoxDescription.Text = "";
            textBoxDefaultQuantity.Text = "1";
            textBoxSubContainerCount.Text = "0";
            comboBoxCategory.SelectedValue = 0;
            comboBoxButtonSize.SelectedIndex = 0;
        }



        public static void readGalleryButtons(ref Panel panel1)
        {
            int categoryButtonWidth = buttonW;
            int categoryButtonHeight = buttonH;
            int positionX = 0;
            int positionY = 0;
            int numberOfButtonsPerRow = 0;

            Main.bImageList1.ImageSize = new Size(categoryButtonWidth, categoryButtonHeight);  //96, 66);
            int index = 0;
            foreach (Image img in Main.bImageList1.Images)
            {
                Button btn = new Button();
                btn.Name = "Button_" + Convert.ToString(index);
                btn.Size = new System.Drawing.Size(categoryButtonWidth, categoryButtonHeight);  //96, 66);
                btn.TabIndex = index + 2;
                btn.Location = new Point(
                    positionX + paddingX,
                    positionY + paddingY + panel1.AutoScrollPosition.Y
                    );

                if (numberOfButtonsPerRow++ >= maxNumberOfButtonsPerRow)
                {
                    numberOfButtonsPerRow = 0;
                    positionX = 0;
                    positionY += categoryButtonHeight + paddingY;
                }
                else
                    positionX += categoryButtonWidth + paddingX + panel1.AutoScrollPosition.Y;
                btn.ImageList = Main.bImageList1;
                btn.ImageIndex = index;
                //btn.Image = img;
                btn.MouseDown += new System.Windows.Forms.MouseEventHandler(CategoryButtons.button_MouseDown);
                panel1.Controls.Add(btn);

                index++;

            }

        }

        public static void button_MouseDown(object sender, MouseEventArgs e)
        {
            buttonSender = (Button)sender;
            buttonSender.DoDragDrop(buttonSender, DragDropEffects.Copy);

        }

        #endregion

        private void buttonBackgroundColor_Click(object sender, EventArgs e)
        {

            //http://stackoverflow.com/questions/9336864/sql-data-type-for-system-drawing-color
            //Use Int32, then use Color.FromArgb(Int32) and Color.ToArgb() to read and write, respectively
            // Assigns an array of custom colors to the CustomColors property
            colorDialog1.CustomColors = new int[] { 0x333438, };  //System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(56))))) = 0x333438
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                if (buttonType == 2)
                {
                    int bgColor = colorDialog1.Color.ToArgb();
                    //this.panelCategoryButtons.BackColor = System.Drawing.Color.Black;
                    panelTableLayoutPanelView2_Buttons.BackColor = Color.FromArgb(bgColor);
                    Main.Sol_ControlInfo.CategoryButtonsPanelBgColor = bgColor;
                    Sol_Control_Sp sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
                    sp.Update(Main.Sol_ControlInfo);
                }
                else if(buttonType ==3)
                {
                    Properties.Settings.Default.SettingsAd17ScreenBackground = colorDialog1.Color;
                    Properties.Settings.Default.Save();
                    panelTableLayoutPanelView3Vertical_Buttons.BackColor = Properties.Settings.Default.SettingsAd17ScreenBackground;

                }

            }

        }

        private void checkBoxSnapToGrid_CheckedChanged(object sender, EventArgs e)
        {
            Main.Sol_ControlInfo.CategoryButtonsSnapToGrid = checkBoxSnapToGrid.Checked;
            Sol_Control_Sp sp = new Sol_Control_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sp.Update(Main.Sol_ControlInfo);

        }

        private Boolean dragInProgress = false;
        int MouseDownX = 0;
        int MouseDownY = 0;

        private void catButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.dragInProgress)
            {
                this.dragInProgress = true;
                this.MouseDownX = e.X;
                this.MouseDownY = e.Y;
            }
            return;
        }

        private void catButton_MouseUp(object sender, MouseEventArgs e)
        {

            if (indice < 0)
            {
                button_Click(sender, (EventArgs)e);
                //buttonClicked = (Button)sender;
                //buttonClickedPrevious = buttonClicked;
                //buttonClicked.FlatAppearance.BorderSize = 1;

                //string[] strControl = buttonClicked.Name.Split('_');
                //indice = Convert.ToInt32(strControl[1]);

            }

            if (e.Button == MouseButtons.Left)
            {
                this.dragInProgress = false;
                Point p = new Point();
                p.X = ((Button)sender).Location.X + (e.X - MouseDownX);
                p.Y = ((Button)sender).Location.Y + (e.Y - MouseDownY);

                Size s = new Size();
                s.Width = ((Button)sender).Size.Width;
                s.Height = ((Button)sender).Size.Height;

                if (Main.Sol_ControlInfo.CategoryButtonsSnapToGrid)
                {
                    p = snapToGrid(p, s);
                    //p = SnapCalculate(p, s);
                    ((Button)sender).Location = p;
                }
                categoryButtonLocationOnForm = p;
                sol_CategoryButtonList[indice].LocationX = p.X;
                sol_CategoryButtonList[indice].LocationY = p.Y;
            }

        }

        private Point snapToGrid(Point p, Size s)
        {
            if (s.Height > buttonH)
                s.Height = s.Height / 2;

            int gridWidth = s.Width;        //10;
            int gridHeight = s.Height;    //10;

            if (p.X % gridWidth < gridWidth / 2)
                p.X = p.X - p.X % gridWidth;
            else
                p.X = p.X + (gridWidth - p.X % gridWidth);


            if (p.Y % gridHeight < gridHeight / 2)
                p.Y = p.Y - p.Y % gridHeight;
            else
                p.Y = p.Y + (gridHeight - p.Y % gridHeight);

            return p;

        }


        // ~~~~ Round to nearest Grid point ~~~~
        public Point SnapCalculate(Point p, Size s)
        {

            if (s.Height > buttonH)
                s.Height = s.Height / 2;

            Grid = new Size(s.Width, s.Height);

            HalfGrid = new Size(Grid.Width / 2, Grid.Height / 2);

            int snapX = (((p.X + HalfGrid.Width) / Grid.Width) * Grid.Width);       // +panelTableLayoutPanelView2_Buttons.AutoScrollPosition.X;
            int snapY = (((p.Y + HalfGrid.Height) / Grid.Height) * Grid.Height);    // +panelTableLayoutPanelView2_Buttons.AutoScrollPosition.Y;

            return new Point(snapX, snapY);
        }

        private void buttonCustomImage_Click(object sender, EventArgs e)
        {
            if (buttonClicked == null)
            {
                MessageBox.Show("Please select a button first!");
                return;
            }

            string resp = String.Empty;
            try
            {
                resp = SirLib.DialogoAbrirArchivo.DialogoBuscar(sol_CategoryButtonList[indice].ImagePath, "", true, "jpg", true, 1, true);
            }
            catch { }
            if (!String.IsNullOrEmpty(resp))
            {
                try
                {
                    Image fastImage = ImageFast.FromFile(resp);
                    ((System.Windows.Forms.Button)this.arrayListItems[indice]).BackgroundImage = fastImage;
                    buttonClicked.BackgroundImage = fastImage;

                    ((System.Windows.Forms.Button)this.arrayListItems[indice]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    buttonClicked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

                    ((System.Windows.Forms.Button)this.arrayListItems[indice]).ImageList = null;
                    buttonClicked.ImageList = null;

                    sol_CategoryButtonList[indice].ImagePath = resp;

                }
                catch
                {
                    MessageBox.Show("Error displaying image in button");
                }


            }

        }

        private void buttonRemoveImage_Click(object sender, EventArgs e)
        {
            if (buttonClicked == null)
            {
                MessageBox.Show("Please select a button first!");
                return;
            }

            ((System.Windows.Forms.Button)this.arrayListItems[indice]).BackgroundImage = null;
            buttonClicked.BackgroundImage = null;

            ((System.Windows.Forms.Button)this.arrayListItems[indice]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            buttonClicked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;

            ((System.Windows.Forms.Button)this.arrayListItems[indice]).ImageList = Main.bImageList1;
            buttonClicked.ImageList = Main.bImageList1;

            sol_CategoryButtonList[indice].ImagePath = String.Empty;

        }


        #region PanelTableLayoutPanelView3 Routines   //17" screen setup

        private void CreatePanelTableLayoutPanelView3Vertical()
        {
            panelTableLayoutPanelView3Vertical_Buttons = new MyPanel();
            panelTableLayoutPanelView3Vertical_Buttons.scroolFlag = false;

            panelTableLayoutPanelView3Vertical_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTableLayoutPanelView3Vertical
            // 
            panelTableLayoutPanelView3Vertical_Buttons.BackColor = Properties.Settings.Default.SettingsAd17ScreenBackground;
            panelTableLayoutPanelView3Vertical_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTableLayoutPanelView3Vertical_Buttons.Location = new System.Drawing.Point(3, 3);
            panelTableLayoutPanelView3Vertical_Buttons.Name = "panelTableLayoutPanelView3Vertical";
            //this.panelTableLayoutPanelView2.Size = new System.Drawing.Size(245, 482);
            panelTableLayoutPanelView3Vertical_Buttons.TabIndex = 0;
            panelTableLayoutPanelView3Vertical_Buttons.AutoScroll = false;
            //panelTableLayoutPanelView3Vertical_Buttons.
            //panelTableLayoutPanelView3Vertical_Buttons.AllowDrop = false;
            //panelTableLayoutPanelView3Vertical_Buttons.Click += new System.EventHandler(panelTableLayoutPanelView3_Buttons_Click);

            this.groupBoxCategoryButtonsDef.Controls.Add(panelTableLayoutPanelView3Vertical_Buttons);
            this.groupBoxCategoryButtonsDef.Size = new System.Drawing.Size(buttonContainerWidth, buttonContainerHeight);  //245, 482);

            this.panelGalleryButtons.Location = new System.Drawing.Point(
                this.groupBoxCategoryButtonsDef.Location.X + 265,
                this.groupBoxCategoryButtonsDef.Location.Y + 10);

            panelTableLayoutPanelView3Vertical_Buttons.ResumeLayout(false);

            this.ResumeLayout(false);

        }

        private void CreatePanelTableLayoutPanelView3Horizontal()
        {

            buttonFirstPage = new Button();
            // 
            // buttonFirstPage
            //                                                   x    y
            int width = 345;
            buttonFirstPage.Location = new System.Drawing.Point(width, 551);
            buttonFirstPage.Name = "buttonFirstPage";
            buttonFirstPage.Size = new System.Drawing.Size(32, 132);
            buttonFirstPage.TabIndex = 9;
            buttonFirstPage.Text = "<<";
            buttonFirstPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            buttonFirstPage.UseVisualStyleBackColor = true;
            buttonFirstPage.Click += new System.EventHandler(ButtonFirstPage_Click);


            buttonPreviousPage = new Button();
            // 
            // buttonPreviousPage
            //                                                      x    y
            width += buttonFirstPage.Size.Width;
            buttonPreviousPage.Location = new System.Drawing.Point(width, 551);
            buttonPreviousPage.Name = "buttonPreviousPage";
            buttonPreviousPage.Size = new System.Drawing.Size(30, 132);
            buttonPreviousPage.TabIndex = 9;
            buttonPreviousPage.Text = "<";
            buttonPreviousPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            buttonPreviousPage.UseVisualStyleBackColor = true;
            buttonPreviousPage.Click += new System.EventHandler(ButtonPreviousPage_Click);
            

            panelTableLayoutPanelView3Horizontal_Buttons = new MyPanel();
            panelTableLayoutPanelView3Horizontal_Buttons.scroolFlag = false;

            panelTableLayoutPanelView3Horizontal_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTableLayoutPanelView3Vertical
            // 
            panelTableLayoutPanelView3Horizontal_Buttons.BackColor = Properties.Settings.Default.SettingsAd17ScreenBackground;
            //panelTableLayoutPanelView3Horizontal_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;

            width += buttonPreviousPage.Size.Width;
            panelTableLayoutPanelView3Horizontal_Buttons.Location = new System.Drawing.Point(width, 551);
            panelTableLayoutPanelView3Horizontal_Buttons.Name = "panelTableLayoutPanelView3Horizontal";

            panelTableLayoutPanelView3Horizontal_Buttons.Size = 
                new System.Drawing.Size(
                    view3HorizontalCells * buttonW         //buttonContainerWidth
                    , view3HorizontalRows * buttonH        //buttonContainerHeight
                    ); 

            panelTableLayoutPanelView3Horizontal_Buttons.TabIndex = 0;
            panelTableLayoutPanelView3Horizontal_Buttons.AutoScroll = false;
            //panelTableLayoutPanelView3Vertical_Buttons.
            //panelTableLayoutPanelView3Vertical_Buttons.AllowDrop = false;
            //panelTableLayoutPanelView3Vertical_Buttons.Click += new System.EventHandler(panelTableLayoutPanelView3_Buttons_Click);

            //this.groupBoxCategoryButtonsDef.Controls.Add(panelTableLayoutPanelView3Horizontal_Buttons);
            //this.groupBoxCategoryButtonsDef.Size = new System.Drawing.Size(buttonContainerWidth, buttonContainerHeight);  //245, 482);


            buttonNextPage = new Button();
            // 
            // buttonNextPage
            //                                                 
            width += panelTableLayoutPanelView3Horizontal_Buttons.Size.Width;
            buttonNextPage.Location = new System.Drawing.Point(width, 551);
            buttonNextPage.Name = "buttonNextPage";
            buttonNextPage.Size = new System.Drawing.Size(30, 132);
            buttonNextPage.TabIndex = 9;
            buttonNextPage.Text = ">";
            buttonNextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            buttonNextPage.UseVisualStyleBackColor = true;
            buttonNextPage.Click += new System.EventHandler(ButtonNextPage_Click);


            buttonLastPage = new Button();
            // 
            // buttonLastPage
            //                                                 
            width += buttonNextPage.Size.Width;
            buttonLastPage.Location = new System.Drawing.Point(width, 551);
            buttonLastPage.Name = "buttonLastPage";
            buttonLastPage.Size = new System.Drawing.Size(32, 132);
            buttonLastPage.TabIndex = 9;
            buttonLastPage.Text = ">>";
            buttonLastPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            buttonLastPage.UseVisualStyleBackColor = true;
            buttonLastPage.Click += new System.EventHandler(ButtonLastPage_Click);

            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(panelTableLayoutPanelView3Horizontal_Buttons);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonLastPage);


            panelTableLayoutPanelView3Horizontal_Buttons.ResumeLayout(false);

            this.ResumeLayout(false);

        }

        private void CreateComboBoxPanel()
        {
            //this.groupBoxControlInformation.Size = new System.Drawing.Size(325, 461);

            labelPanel = new System.Windows.Forms.Label();
            // 
            // labelPanel
            // 
            labelPanel.AutoSize = true;
            labelPanel.Location = new System.Drawing.Point(22, 595);
            labelPanel.Name = "labelPanel";
            labelPanel.Size = new System.Drawing.Size(48, 17);
            labelPanel.TabIndex = 21;
            labelPanel.Text = "&Panel:";

            comboBoxPanel = new System.Windows.Forms.ComboBox();
            // 
            // comboBoxPanel
            // 
            comboBoxPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxPanel.FormattingEnabled = true;
            comboBoxPanel.Items.AddRange(new object[] {
            "Vertical",
            "Horizontal"});
            comboBoxPanel.Location = new System.Drawing.Point(145, 592);
            comboBoxPanel.Name = "comboBoxPanel";
            comboBoxPanel.Size = new System.Drawing.Size(117, 24);
            comboBoxPanel.TabIndex = 22;

            comboBoxPanel.SelectedIndex = 0;

            comboBoxPanel.SelectedIndexChanged += new System.EventHandler(comboBoxPanel_SelectedIndexChanged);

            //this.groupBoxControlInformation.Controls.Add(labelPanel);
            //this.groupBoxControlInformation.Controls.Add(comboBoxPanel);
            this.Controls.Add(labelPanel);
            this.Controls.Add(comboBoxPanel);

        }

        //private void panelTableLayoutPanelView3_Buttons_Click(object sender, EventArgs e)
        //{
        //    if (buttonClickedPrevious != null)
        //        buttonClickedPrevious.FlatAppearance.BorderSize = 1;

        //    indice = -1;
        //    buttonClicked = null;
        //    buttonClickedPrevious = null;
        //    buttonSender = null;

        //    textBoxDescription.Text = "";
        //    textBoxDefaultQuantity.Text = "1";
        //    textBoxSubContainerCount.Text = "0";
        //    comboBoxCategory.SelectedValue = 0;
        //    comboBoxButtonSize.SelectedIndex = 0;
        //}


        private void ReadButtons2()  //type 2 and 3
        {
            indice = -1;
            buttonClicked = null;
            buttonClickedPrevious = null;
            buttonSender = null;

            textBoxDescription.Text = "";
            textBoxDefaultQuantity.Text = "1";
            textBoxSubContainerCount.Text = "0";
            checkBoxCountDown.Checked = false;
            comboBoxCategory.SelectedValue = 0;
            comboBoxButtonSize.SelectedIndex = 0;


            if (buttonType == 2)
            {
                panelTableLayoutPanelView2_Buttons.Controls.Clear();
                //panelTableLayoutPanelView2_Buttons.SuspendLayout();
                //this.SuspendLayout();

            }
            else if (buttonType == 3)
            {
                panelTableLayoutPanelView3Vertical_Buttons.Controls.Clear();
                panelTableLayoutPanelView3Horizontal_Buttons.Controls.Clear();

                //panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Vertical_Buttons;
                //panelTableLayoutPanelView3_Buttons.SuspendLayout();
                //this.SuspendLayout();

            }



            //sol_CategoryButtonList = new List<Sol_CategoryButton>();
            //Sol_CategoryButton sol_CategoryButton = new Sol_CategoryButton();
            //sol_CategoryButton_Sp = new Sol_CategoryButton_Sp(Properties.Settings.Default.WsirDbConnectionString);
            sol_CategoryButtonList = sol_CategoryButton_Sp._SelectAllByButtonType(/*Main.Sol_ControlInfo.WorkStationID,*/buttonType);

            this.arrayListItems = new ArrayList();

            ImageList buttonsImageList = Main.bImageList1;

            int i = 0;
            foreach (Sol_CategoryButton cb in sol_CategoryButtonList)
            {
                switch (cb.ImageSize)
                {
                    case 0: //-- 0 = Normal Size
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                    case 1: //-- 1 = Double Width
                        buttonsImageList = Main.bImageList2;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH;
                        break;
                    case 2: //-- 2 = Double Height
                        buttonsImageList = Main.bImageList3;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH * 2;
                        break;
                    case 3: //-- 3 = Double Size
                        buttonsImageList = Main.bImageList4;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH * 2;
                        break;
                    default:
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                }

                cb.Width = categoryButtonWidth;
                cb.Height = categoryButtonHeight;

                Color foreColor = Color.FromArgb(cb.ForeColorArgb); //ColorTryParse(cb.ForeColorArgb, cb.ForeColor);
                Color backColor = Color.FromArgb(cb.BackColorArgb); //ColorTryParse(cb.BackColorArgb, cb.BackColor);

                this.arrayListItems.Add(new System.Windows.Forms.Button());

                if (buttonType == 3)
                {
                    ((System.Windows.Forms.Button)this.arrayListItems[i]).Location = CalculatePointOfButton(buttonType, i);
                    //new System.Drawing.Point(
                    //cb.LocationX,
                    //cb.LocationY 
                    //);
                }
                else
                {
                    ((System.Windows.Forms.Button)this.arrayListItems[i]).Location = new System.Drawing.Point(
                    cb.LocationX,
                    cb.LocationY
                    );

                }

                ((System.Windows.Forms.Button)this.arrayListItems[i]).Name = "Button_" + Convert.ToString(i);
                ((System.Windows.Forms.Button)this.arrayListItems[i]).Size = new System.Drawing.Size(categoryButtonWidth, categoryButtonHeight);

                ((System.Windows.Forms.Button)this.arrayListItems[i]).TabIndex = i + 2;
                ((System.Windows.Forms.Button)this.arrayListItems[i]).Text = cb.Description.Trim();

                ((System.Windows.Forms.Button)this.arrayListItems[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);

                ((System.Windows.Forms.Button)this.arrayListItems[i]).ForeColor = foreColor;
                ((System.Windows.Forms.Button)this.arrayListItems[i]).BackColor = backColor;

                ((System.Windows.Forms.Button)this.arrayListItems[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                ((System.Windows.Forms.Button)this.arrayListItems[i]).Cursor = System.Windows.Forms.Cursors.Hand;

                ((System.Windows.Forms.Button)this.arrayListItems[i]).FlatAppearance.BorderSize = 1;
                //((System.Windows.Forms.Button)this.arrayListItems[i]).FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                //((System.Windows.Forms.Button)this.arrayListItems[i]).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

                ((System.Windows.Forms.Button)this.arrayListItems[i]).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                ((System.Windows.Forms.Button)this.arrayListItems[i]).UseVisualStyleBackColor = false;

                //Image img = Main.buttonsImageList.Images[cb.ImageIndex];
                //((System.Windows.Forms.Button)this.arrayListItems[i]).Image = img;

                //only for buttons type 2
                //if (cb.ControlType == 2)
                if (buttonType == 2)
                {
                    ((System.Windows.Forms.Button)this.arrayListItems[i]).ImageIndex = cb.ImageIndex;
                    //if (cb.ImageIndex < 4 && !String.IsNullOrEmpty(cb.ImagePath))
                    if (!String.IsNullOrEmpty(cb.ImagePath))
                    {
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).ImageList = null;

                        try
                        {
                            Image fastImage = ImageFast.FromFile(cb.ImagePath);
                            ((System.Windows.Forms.Button)this.arrayListItems[i]).BackgroundImage = fastImage;
                            ((System.Windows.Forms.Button)this.arrayListItems[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        catch
                        {
                            ((System.Windows.Forms.Button)this.arrayListItems[i]).ImageList = buttonsImageList;
                        }

                    }
                    else
                        ((System.Windows.Forms.Button)this.arrayListItems[i]).ImageList = buttonsImageList;
                }

                ((System.Windows.Forms.Button)this.arrayListItems[i]).Click += new System.EventHandler(this.button_Click);


                if (buttonType == 2)
                {
                    ((System.Windows.Forms.Button)this.arrayListItems[i]).MouseDown += new System.Windows.Forms.MouseEventHandler(this.catButton_MouseDown);
                    ((System.Windows.Forms.Button)this.arrayListItems[i]).MouseUp += new System.Windows.Forms.MouseEventHandler(this.catButton_MouseUp);
                    panelTableLayoutPanelView2_Buttons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i]));
                    SirLib.ControlMover.Init(((System.Windows.Forms.Button)this.arrayListItems[i]));
                }
                else if (buttonType == 3)
                {
                    panelTableLayoutPanelView3Vertical_Buttons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems[i]));
                }

                i++;

                //break;

            }

            if (buttonType == 3)
            {
                pageNumber = 1;
                ReadButtons4();
            }
        }


        private void ReadButtons4()  //horizontal panel of buttonType 3
        {
            indice = -1;
            buttonClicked = null;
            buttonClickedPrevious = null;
            buttonSender = null;

            //textBoxDescription.Text = "";
            //textBoxDefaultQuantity.Text = "1";
            //textBoxSubContainerCount.Text = "0";
            //checkBoxCountDown.Checked = false;
            //comboBoxCategory.SelectedValue = 0;
            //comboBoxButtonSize.SelectedIndex = 0;

            panelTableLayoutPanelView3Horizontal_Buttons.Controls.Clear();

            sol_CategoryButtonList4 = sol_CategoryButton_Sp._SelectAllByPaging(/*Main.Sol_ControlInfo.WorkStationID-1, buttonType, */pageNumber, pageSize, ref lastPage);

            this.arrayListItems4 = new ArrayList();

            ImageList buttonsImageList = Main.bImageList1;

            int i = 0;
            foreach (Sol_CategoryButton cb in sol_CategoryButtonList4)
            {
                switch (cb.ImageSize)
                {
                    case 0: //-- 0 = Normal Size
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                    case 1: //-- 1 = Double Width
                        buttonsImageList = Main.bImageList2;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH;
                        break;
                    case 2: //-- 2 = Double Height
                        buttonsImageList = Main.bImageList3;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH * 2;
                        break;
                    case 3: //-- 3 = Double Size
                        buttonsImageList = Main.bImageList4;
                        categoryButtonWidth = (buttonW * 2);
                        categoryButtonHeight = buttonH * 2;
                        break;
                    default:
                        buttonsImageList = Main.bImageList1;
                        categoryButtonWidth = buttonW;
                        categoryButtonHeight = buttonH;
                        break;
                }

                cb.Width = categoryButtonWidth;
                cb.Height = categoryButtonHeight;

                Color foreColor = Color.FromArgb(cb.ForeColorArgb); //ColorTryParse(cb.ForeColorArgb, cb.ForeColor);
                Color backColor = Color.FromArgb(cb.BackColorArgb); //ColorTryParse(cb.BackColorArgb, cb.BackColor);

                this.arrayListItems4.Add(new System.Windows.Forms.Button());

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).Location = CalculatePointOfButton(4, i);
                    //new System.Drawing.Point(
                    //cb.LocationX,
                    //cb.LocationY
                    //);
                ((System.Windows.Forms.Button)this.arrayListItems4[i]).Name = "Button_" + Convert.ToString(i);
                ((System.Windows.Forms.Button)this.arrayListItems4[i]).Size = new System.Drawing.Size(categoryButtonWidth, categoryButtonHeight);

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).TabIndex = i + 2;
                ((System.Windows.Forms.Button)this.arrayListItems4[i]).Text = cb.Description.Trim();

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).Font = Funciones.FontParser(cb.Font, cb.FontStyle);

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).ForeColor = foreColor;
                ((System.Windows.Forms.Button)this.arrayListItems4[i]).BackColor = backColor;

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                ((System.Windows.Forms.Button)this.arrayListItems4[i]).Cursor = System.Windows.Forms.Cursors.Hand;

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatAppearance.BorderSize = 1;
                //((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                //((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                ((System.Windows.Forms.Button)this.arrayListItems4[i]).UseVisualStyleBackColor = false;

                //Image img = Main.buttonsImageList.Images[cb.ImageIndex];
                //((System.Windows.Forms.Button)this.arrayListItems4[i]).Image = img;

                //only for buttons type 2
                //if (cb.ControlType == 2)
                //if (buttonType == 2)
                //{
                //    ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageIndex = cb.ImageIndex;
                //    //if (cb.ImageIndex < 4 && !String.IsNullOrEmpty(cb.ImagePath))
                //    if (!String.IsNullOrEmpty(cb.ImagePath))
                //    {
                //        ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageList = null;

                //        try
                //        {
                //            Image fastImage = ImageFast.FromFile(cb.ImagePath);
                //            ((System.Windows.Forms.Button)this.arrayListItems4[i]).BackgroundImage = fastImage;
                //            ((System.Windows.Forms.Button)this.arrayListItems4[i]).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                //        }
                //        catch
                //        {
                //            ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageList = buttonsImageList;
                //        }

                //    }
                //    else
                //        ((System.Windows.Forms.Button)this.arrayListItems4[i]).ImageList = buttonsImageList;
                //}

                ((System.Windows.Forms.Button)this.arrayListItems4[i]).Click += new System.EventHandler(this.button_Click);


                panelTableLayoutPanelView3Horizontal_Buttons.Controls.Add(((System.Windows.Forms.Button)this.arrayListItems4[i]));

                i++;

                //break;

            }

        }



        #endregion

        private void EnableFormButtonType(ControlType ct)
        {

            comboBoxWorkStation.Enabled = false;
            checkBoxSnapToGrid.Enabled = false;
            checkBoxSnapToGrid.Checked = false;
            buttonBackgroundColor.Enabled = false;

            textBoxDescription.Enabled = false;

            textBoxMaxCountPerLine.Enabled = false;
            textBoxDefaultQuantity.Enabled = false;
            textBoxSubContainerCount.Enabled = false;
            checkBoxCountDown.Enabled = false;
            comboBoxCategory.Enabled = false;

            buttonFont.Enabled = false;
            buttonColor.Enabled = false;
            comboBoxButtonSize.Enabled = false;

            buttonCustomImage.Enabled = false;
            buttonRemoveImage.Enabled = false;

            switch(buttonType)
            { 
                case 1:
                    comboBoxWorkStation.Enabled = true;
                    //checkBoxSnapToGrid.Enabled = true;
                    //checkBoxSnapToGrid.Checked = true;
                    //buttonBackgroundColor.Enabled = true;

                    textBoxDescription.Enabled = true;
                    //textBoxMaxCountPerLine.Enabled = true;

                    if(ct == ControlType.Button)
                        textBoxDefaultQuantity.Enabled = true;

                    //textBoxSubContainerCount.Enabled = true;
                    //checkBoxCountDown.Enabled = true;
                    if (ct == ControlType.Button)
                        comboBoxCategory.Enabled = true;

                    buttonFont.Enabled = true;
                    buttonColor.Enabled = true;
                    //comboBoxButtonSize.Enabled = true;

                    //buttonCustomImage.Enabled = true;
                    //buttonRemoveImage.Enabled = true;
                    break;
                case 2:
                    comboBoxWorkStation.Enabled = true;
                    checkBoxSnapToGrid.Enabled = true;
                    checkBoxSnapToGrid.Checked = true;
                    buttonBackgroundColor.Enabled = true;

                    textBoxDescription.Enabled = true;
                    textBoxMaxCountPerLine.Enabled = true;
                    textBoxDefaultQuantity.Enabled = true;
                    textBoxSubContainerCount.Enabled = true;
                    checkBoxCountDown.Enabled = true;
                    comboBoxCategory.Enabled = true;

                    buttonFont.Enabled = true;
                    //buttonColor.Enabled = true;
                    comboBoxButtonSize.Enabled = true;

                    buttonCustomImage.Enabled = true;
                    buttonRemoveImage.Enabled = true;
                    break;
                case 3:
                    comboBoxWorkStation.Enabled = true;
                    //checkBoxSnapToGrid.Enabled = true;
                    //checkBoxSnapToGrid.Checked = true;
                    buttonBackgroundColor.Enabled = true;

                    textBoxDescription.Enabled = true;
                    textBoxMaxCountPerLine.Enabled = true;
                    textBoxDefaultQuantity.Enabled = true;
                    textBoxSubContainerCount.Enabled = true;
                    checkBoxCountDown.Enabled = true;
                    comboBoxCategory.Enabled = true;

                    buttonFont.Enabled = true;
                    buttonColor.Enabled = true;
                    //comboBoxButtonSize.Enabled = true;

                    //buttonCustomImage.Enabled = true;
                    //buttonRemoveImage.Enabled = true;
                    break;
            }
        }

        private void EnableButtons(ButtonAction action)
        {
            groupBoxControlInformation.Enabled = false;

            if (comboBoxPanel != null)
                comboBoxPanel.Enabled = true;

            buttonAddLabel.Enabled = false;
            buttonAddButton.Enabled = false;

            buttonDelete.Enabled = false;
            buttonCancel.Enabled = false;
            buttonSave.Enabled = false;

            switch (action)
            {
                case ButtonAction.AddButton:
                    groupBoxControlInformation.Enabled = true;
                    if (comboBoxPanel != null)
                        comboBoxPanel.Enabled = false;

                    buttonCancel.Enabled = true;
                    buttonSave.Enabled = true;
                    break;
                case ButtonAction.AddLabel:
                    groupBoxControlInformation.Enabled = true;
                    if (comboBoxPanel != null)
                        comboBoxPanel.Enabled = false;

                    buttonCancel.Enabled = true;
                    buttonSave.Enabled = true;
                    break;
                case ButtonAction.Cancel:
                    if (buttonType == 1)
                        buttonAddLabel.Enabled = true;

                    if (buttonType != 2)
                        buttonAddButton.Enabled = true;
                    break;
                case ButtonAction.Delete:
                    if (buttonType == 1)
                        buttonAddLabel.Enabled = true;
                    if (buttonType != 2)
                        buttonAddButton.Enabled = true;
                    break;
                case ButtonAction.Save:
                    if (buttonType == 1)
                        buttonAddLabel.Enabled = true;
                    if (buttonType != 2)
                        buttonAddButton.Enabled = true;
                    break;
                case ButtonAction.Edit:
                    groupBoxControlInformation.Enabled = true;
                    if (comboBoxPanel != null)
                        comboBoxPanel.Enabled = false;

                    buttonDelete.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonSave.Enabled = true;
                    break;
            }

            lastButtonAction = action;

        }

        private void ButtonFirstPage_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            ReadButtons4();

        }
        private void ButtonPreviousPage_Click(object sender, EventArgs e)
        {
            if (pageNumber < 2)
                return;

            pageNumber--;
            ReadButtons4();

        }

        private void ButtonNextPage_Click(object sender, EventArgs e)
        {
            if (arrayListItems4.Count < pageSize)
                return;

            pageNumber++;
            ReadButtons4();

        }

        private void ButtonLastPage_Click(object sender, EventArgs e)
        {
            pageNumber = lastPage;
            ReadButtons4();
        }

        private void comboBoxPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPanel.SelectedIndex == 0)
            {
                panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Vertical_Buttons;
                //view3Rows = 7;
                //view3Cells = 4;

            }
            else
            {
                panelTableLayoutPanelView3_Buttons = panelTableLayoutPanelView3Horizontal_Buttons;
                //view3HorizontalRows = 2;
                //view3HorizontalCells = 7;
            }        
        }

        public static Point CalculatePointOfButton(byte controlType, int count)
        {
            //size of standard button 96 x 66
            //public static int buttonW = 96;
            //public static int buttonH = 66;
            //arrayListItems.Count()
            //const int view3Rows = 7;
            //const int view3Cells = 4;
            //const int view3HorizontalRows = 2;
            //const int view3HorizontalCells = 7;

            int row = 0;
            int cells = 0;
            if (controlType == 3)
            {
                //count = arrayListItems.Count;
                cells = view3Cells;
                //obtain row and cell number
                row = count / cells;
            }
            else //if(controlType == 4)
            {
                cells = view3HorizontalCells;
                //obtain row and cell number
                row = count / cells;
            }

            decimal a = Convert.ToDecimal(count) / cells;
            int b = count / cells;
            decimal c = a - b;
            int cell = Convert.ToInt32(c * cells);
            int y = row * buttonH;
            int x = cell * buttonW;

            Point p = new Point();
            p.X = x;    // ((Button)sender).Location.X + (x);
            p.Y = y;    // ((Button)sender).Location.Y + (y);

            return p;
        }

    }

    public class MyPanel : Panel
    {
        public bool scroolFlag { get; set; }
        public MyPanel()
        {
            AdjustFormScrollbars(scroolFlag);

        }

        public new void AdjustFormScrollbars(bool displayScrollbars)
        {
            base.VerticalScroll.Visible = displayScrollbars;
            base.HorizontalScroll.Visible = displayScrollbars;
        }
    }



}




