namespace CRM_GUI.GUISystem.User
{
    partial class frmAccountUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountUpdate));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtOrderBy = new DevExpress.XtraEditors.SpinEdit();
            this.cboShop = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionButton16x16 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cboUser = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtEmpName = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupInfo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkActive);
            this.layoutControl1.Controls.Add(this.txtOrderBy);
            this.layoutControl1.Controls.Add(this.cboShop);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.cboUser);
            this.layoutControl1.Controls.Add(this.txtEmpName);
            this.layoutControl1.Controls.Add(this.txtEmpCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroupMain;
            this.layoutControl1.Size = new System.Drawing.Size(731, 124);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(376, 61);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Hoạt động";
            this.chkActive.Size = new System.Drawing.Size(350, 22);
            this.chkActive.StyleController = this.layoutControl1;
            this.chkActive.TabIndex = 25;
            // 
            // txtOrderBy
            // 
            this.txtOrderBy.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOrderBy.Location = new System.Drawing.Point(103, 61);
            this.txtOrderBy.Name = "txtOrderBy";
            this.txtOrderBy.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrderBy.Properties.Appearance.Options.UseFont = true;
            this.txtOrderBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderBy.Size = new System.Drawing.Size(269, 24);
            this.txtOrderBy.StyleController = this.layoutControl1;
            this.txtOrderBy.TabIndex = 24;
            // 
            // cboShop
            // 
            this.cboShop.Location = new System.Drawing.Point(474, 33);
            this.cboShop.Name = "cboShop";
            this.cboShop.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShop.Properties.Appearance.Options.UseFont = true;
            this.cboShop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboShop.Properties.View = this.gridLookUpEdit2View;
            this.cboShop.Size = new System.Drawing.Size(252, 24);
            this.cboShop.StyleController = this.layoutControl1;
            this.cboShop.TabIndex = 23;
            // 
            // gridLookUpEdit2View
            // 
            this.gridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit2View.Name = "gridLookUpEdit2View";
            this.gridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageIndex = 5;
            this.btnSave.ImageList = this.imageCollectionButton16x16;
            this.btnSave.Location = new System.Drawing.Point(533, 92);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 28);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageCollectionButton16x16
            // 
            this.imageCollectionButton16x16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionButton16x16.ImageStream")));
            this.imageCollectionButton16x16.Images.SetKeyName(0, "01_Search_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(1, "02_Add_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(2, "03_Edit_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(3, "04_Close_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(4, "05_LogOut_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(5, "06_Save_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(6, "07_ListBox_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(7, "08_Link_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(8, "09_Print_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(9, "10_Task_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(10, "11_Payment_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(11, "20_Up_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(12, "21_Down_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(13, "22_Delete_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(14, "23_Dot_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(15, "24_Cancel_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(16, "25_Today_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(17, "26_Redo_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(18, "27_ResetChanges_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(19, "28_ShowProduct_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(20, "29_Undo_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(21, "30_ViewReset_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(22, "31_Task_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(23, "32_Refresh_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(24, "33_BOReport_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(25, "34_BOReport2_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(26, "35_Apply_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(27, "36_Article_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(28, "37_BONote_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(29, "38_BOFileAttachment_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(30, "40_AddFile_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(31, "41_AddItem_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(32, "42_WithTextWrapping_BottomRight_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(33, "43_Map_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(34, "44_AddItem_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(35, "45_DeleteList_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(36, "46_Edit_16x16.png");
            this.imageCollectionButton16x16.Images.SetKeyName(37, "47_RemoveFriend_16x16.png");
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageIndex = 4;
            this.btnClose.ImageList = this.imageCollectionButton16x16;
            this.btnClose.Location = new System.Drawing.Point(633, 92);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(474, 5);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.View = this.gridLookUpEdit1View;
            this.cboUser.Size = new System.Drawing.Size(252, 24);
            this.cboUser.StyleController = this.layoutControl1;
            this.cboUser.TabIndex = 11;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(103, 33);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmpName.Properties.Appearance.Options.UseFont = true;
            this.txtEmpName.Size = new System.Drawing.Size(269, 24);
            this.txtEmpName.StyleController = this.layoutControl1;
            this.txtEmpName.TabIndex = 6;
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.Location = new System.Drawing.Point(103, 5);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmpCode.Properties.Appearance.Options.UseFont = true;
            this.txtEmpCode.Size = new System.Drawing.Size(269, 24);
            this.txtEmpCode.StyleController = this.layoutControl1;
            this.txtEmpCode.TabIndex = 4;
            // 
            // layoutControlGroupMain
            // 
            this.layoutControlGroupMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupMain.GroupBordersVisible = false;
            this.layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem17,
            this.layoutControlItem18,
            this.layoutControlGroupInfo});
            this.layoutControlGroupMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupMain.Name = "layoutControlGroupMain";
            this.layoutControlGroupMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupMain.Size = new System.Drawing.Size(731, 124);
            this.layoutControlGroupMain.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 90);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(531, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.btnClose;
            this.layoutControlItem17.Location = new System.Drawing.Point(631, 90);
            this.layoutControlItem17.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(100, 34);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.btnSave;
            this.layoutControlItem18.Location = new System.Drawing.Point(531, 90);
            this.layoutControlItem18.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(100, 34);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlGroupInfo
            // 
            this.layoutControlGroupInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroupInfo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupInfo.Name = "layoutControlGroupInfo";
            this.layoutControlGroupInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupInfo.Size = new System.Drawing.Size(731, 90);
            this.layoutControlGroupInfo.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtEmpCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(371, 28);
            this.layoutControlItem1.Text = "Mã nhân viên";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(95, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtEmpName;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(371, 28);
            this.layoutControlItem3.Text = "Tên nhân viên";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(95, 18);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.cboUser;
            this.layoutControlItem8.Location = new System.Drawing.Point(371, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(354, 28);
            this.layoutControlItem8.Text = "Tài khoản";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(95, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.cboShop;
            this.layoutControlItem2.Location = new System.Drawing.Point(371, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(354, 28);
            this.layoutControlItem2.Text = "Cửa hàng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(95, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtOrderBy;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(371, 28);
            this.layoutControlItem4.Text = "Thứ tự";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(95, 18);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkActive;
            this.layoutControlItem5.Location = new System.Drawing.Point(371, 56);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(354, 28);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmAccountUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 124);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAccountUpdate";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.GridLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtEmpName;
        private DevExpress.XtraEditors.TextEdit txtEmpCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.Utils.ImageCollection imageCollectionButton16x16;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupInfo;
        private DevExpress.XtraEditors.GridLookUpEdit cboShop;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit2View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.SpinEdit txtOrderBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;

    }
}