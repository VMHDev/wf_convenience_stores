namespace CRM_GUI.GUIQuery
{
    partial class frmQueryInStockCounter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryInStockCounter));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboCounter = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnOpenCloseCounter = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionButton = new DevExpress.Utils.ImageCollection(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grcInStockCounter = new DevExpress.XtraGrid.GridControl();
            this.grvInStockCounter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemGridView = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCounter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInStockCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInStockCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cboCounter);
            this.layoutControl1.Controls.Add(this.btnOpenCloseCounter);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.grcInStockCounter);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(978, 405);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboCounter
            // 
            this.cboCounter.Location = new System.Drawing.Point(133, 2);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounter.Properties.Appearance.Options.UseFont = true;
            this.cboCounter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCounter.Properties.View = this.gridLookUpEdit1View;
            this.cboCounter.Size = new System.Drawing.Size(843, 24);
            this.cboCounter.StyleController = this.layoutControl1;
            this.cboCounter.TabIndex = 9;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // btnOpenCloseCounter
            // 
            this.btnOpenCloseCounter.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnOpenCloseCounter.Appearance.Options.UseFont = true;
            this.btnOpenCloseCounter.ImageIndex = 41;
            this.btnOpenCloseCounter.ImageList = this.imageCollectionButton;
            this.btnOpenCloseCounter.Location = new System.Drawing.Point(2, 375);
            this.btnOpenCloseCounter.Name = "btnOpenCloseCounter";
            this.btnOpenCloseCounter.Size = new System.Drawing.Size(146, 28);
            this.btnOpenCloseCounter.StyleController = this.layoutControl1;
            this.btnOpenCloseCounter.TabIndex = 8;
            this.btnOpenCloseCounter.Text = "Đóng/Mở quầy";
            this.btnOpenCloseCounter.Click += new System.EventHandler(this.btnOpenCloseCounter_Click);
            // 
            // imageCollectionButton
            // 
            this.imageCollectionButton.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionButton.ImageStream")));
            this.imageCollectionButton.Images.SetKeyName(0, "01_Search_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(1, "02_Add_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(2, "03_Edit_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(3, "04_Close_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(4, "05_LogOut_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(5, "06_Save_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(6, "07_ListBox_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(7, "08_Link_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(8, "09_Print_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(9, "10_Task_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(10, "11_Payment_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(11, "20_Up_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(12, "21_Down_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(13, "22_Delete_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(14, "23_Dot_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(15, "24_Cancel_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(16, "25_Today_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(17, "26_Redo_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(18, "27_ResetChanges_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(19, "28_ShowProduct_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(20, "29_Undo_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(21, "30_ViewReset_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(22, "31_Task_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(23, "32_Refresh_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(24, "33_BOReport_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(25, "34_BOReport2_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(26, "35_Apply_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(27, "36_Article_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(28, "37_BONote_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(29, "38_BOFileAttachment_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(30, "40_AddFile_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(31, "41_AddItem_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(32, "42_WithTextWrapping_BottomRight_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(33, "43_Map_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(34, "44_AddItem_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(35, "45_DeleteList_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(36, "46_Edit_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(37, "47_RemoveFriend_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(38, "48_Reset_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(39, "49_Door_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(40, "50_MoneyBag_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(41, "87_Counter_16x16.png");
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageIndex = 4;
            this.btnClose.ImageList = this.imageCollectionButton;
            this.btnClose.Location = new System.Drawing.Point(880, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grcInStockCounter
            // 
            this.grcInStockCounter.Location = new System.Drawing.Point(133, 30);
            this.grcInStockCounter.MainView = this.grvInStockCounter;
            this.grcInStockCounter.Name = "grcInStockCounter";
            this.grcInStockCounter.Size = new System.Drawing.Size(843, 341);
            this.grcInStockCounter.TabIndex = 4;
            this.grcInStockCounter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInStockCounter});
            // 
            // grvInStockCounter
            // 
            this.grvInStockCounter.GridControl = this.grcInStockCounter;
            this.grvInStockCounter.Name = "grvInStockCounter";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemGridView,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(978, 405);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemGridView
            // 
            this.layoutControlItemGridView.Control = this.grcInStockCounter;
            this.layoutControlItemGridView.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItemGridView.Name = "layoutControlItemGridView";
            this.layoutControlItemGridView.Size = new System.Drawing.Size(978, 345);
            this.layoutControlItemGridView.TextSize = new System.Drawing.Size(128, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.Location = new System.Drawing.Point(878, 373);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(100, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(150, 373);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(728, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.cboCounter;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(978, 28);
            this.layoutControlItem6.Text = "Quầy thu ngân";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(128, 18);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnOpenCloseCounter;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 373);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(150, 32);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(150, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(150, 32);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmQueryInStockCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 405);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQueryInStockCounter";
            this.Text = "frmQueryInStockCounter";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCounter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcInStockCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInStockCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnOpenCloseCounter;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl grcInStockCounter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvInStockCounter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.Utils.ImageCollection imageCollectionButton;
        private DevExpress.XtraEditors.GridLookUpEdit cboCounter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}