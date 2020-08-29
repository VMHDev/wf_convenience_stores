namespace CRM_GUI.GUISystem
{
    partial class frmAccessRights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccessRights));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.treeListAccessRights = new DevExpress.XtraTreeList.TreeList();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionButton = new DevExpress.Utils.ImageCollection(this.components);
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cboUserGroup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListAccessRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.treeListAccessRights);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.cboUserGroup);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(576, 570);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // treeListAccessRights
            // 
            this.treeListAccessRights.Location = new System.Drawing.Point(2, 30);
            this.treeListAccessRights.Name = "treeListAccessRights";
            this.treeListAccessRights.Size = new System.Drawing.Size(572, 503);
            this.treeListAccessRights.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageIndex = 23;
            this.btnRefresh.ImageList = this.imageCollectionButton;
            this.btnRefresh.Location = new System.Drawing.Point(5, 540);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 25);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // imageCollectionButton
            // 
            this.imageCollectionButton.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionButton.ImageStream")));
            this.imageCollectionButton.Images.SetKeyName(0, "01_Search_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(1, "02_Add_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(2, "03_Edit_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(3, "04_DeleteList_16x16.png");
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
            this.imageCollectionButton.Images.SetKeyName(30, "39_Close_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(31, "40_AddFile_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(32, "41_AddItem_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(33, "42_WithTextWrapping_BottomRight_16x16.png");
            this.imageCollectionButton.Images.SetKeyName(34, "43_Map_16x16.png");
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageIndex = 5;
            this.btnSave.ImageList = this.imageCollectionButton;
            this.btnSave.Location = new System.Drawing.Point(354, 540);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageIndex = 4;
            this.btnClose.ImageList = this.imageCollectionButton;
            this.btnClose.Location = new System.Drawing.Point(458, 540);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 25);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboUserGroup
            // 
            this.cboUserGroup.Location = new System.Drawing.Point(131, 2);
            this.cboUserGroup.Name = "cboUserGroup";
            this.cboUserGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.Appearance.Options.UseFont = true;
            this.cboUserGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUserGroup.Properties.View = this.gridLookUpEdit1View;
            this.cboUserGroup.Size = new System.Drawing.Size(443, 24);
            this.cboUserGroup.StyleController = this.layoutControl1;
            this.cboUserGroup.TabIndex = 4;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(576, 570);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.cboUserGroup;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(576, 28);
            this.layoutControlItem1.Text = "Nhóm người dùng";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(126, 18);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 535);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(576, 35);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.Location = new System.Drawing.Point(453, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(117, 29);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(105, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(244, 29);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSave;
            this.layoutControlItem3.Location = new System.Drawing.Point(349, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(104, 29);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRefresh;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(105, 29);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.treeListAccessRights;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(576, 507);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmAccessRights
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 570);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAccessRights";
            this.Text = "frmAccessRights";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListAccessRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraTreeList.TreeList treeListAccessRights;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.GridLookUpEdit cboUserGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.Utils.ImageCollection imageCollectionButton;
    }
}