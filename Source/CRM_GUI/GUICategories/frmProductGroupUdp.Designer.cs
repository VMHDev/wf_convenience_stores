﻿namespace CRM_GUI.GUICategories
{
    partial class frmProductGroupUdp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductGroupUdp));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDescriptions = new DevExpress.XtraEditors.MemoEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionButton16x16 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtOrderBy = new DevExpress.XtraEditors.SpinEdit();
            this.txtProductGroupName = new DevExpress.XtraEditors.TextEdit();
            this.txtProductGroupCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupInfo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescriptions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductGroupCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDescriptions);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.chkActive);
            this.layoutControl1.Controls.Add(this.txtOrderBy);
            this.layoutControl1.Controls.Add(this.txtProductGroupName);
            this.layoutControl1.Controls.Add(this.txtProductGroupCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroupMain;
            this.layoutControl1.Size = new System.Drawing.Size(731, 122);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDescriptions
            // 
            this.txtDescriptions.Location = new System.Drawing.Point(476, 5);
            this.txtDescriptions.Name = "txtDescriptions";
            this.txtDescriptions.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDescriptions.Properties.Appearance.Options.UseFont = true;
            this.txtDescriptions.Size = new System.Drawing.Size(250, 52);
            this.txtDescriptions.StyleController = this.layoutControl1;
            this.txtDescriptions.TabIndex = 22;
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
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(367, 61);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Hoạt động";
            this.chkActive.Size = new System.Drawing.Size(359, 22);
            this.chkActive.StyleController = this.layoutControl1;
            this.chkActive.TabIndex = 17;
            // 
            // txtOrderBy
            // 
            this.txtOrderBy.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOrderBy.Location = new System.Drawing.Point(114, 61);
            this.txtOrderBy.Name = "txtOrderBy";
            this.txtOrderBy.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrderBy.Properties.Appearance.Options.UseFont = true;
            this.txtOrderBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderBy.Size = new System.Drawing.Size(249, 24);
            this.txtOrderBy.StyleController = this.layoutControl1;
            this.txtOrderBy.TabIndex = 15;
            // 
            // txtProductGroupName
            // 
            this.txtProductGroupName.Location = new System.Drawing.Point(114, 33);
            this.txtProductGroupName.Name = "txtProductGroupName";
            this.txtProductGroupName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtProductGroupName.Properties.Appearance.Options.UseFont = true;
            this.txtProductGroupName.Size = new System.Drawing.Size(249, 24);
            this.txtProductGroupName.StyleController = this.layoutControl1;
            this.txtProductGroupName.TabIndex = 6;
            // 
            // txtProductGroupCode
            // 
            this.txtProductGroupCode.Location = new System.Drawing.Point(114, 5);
            this.txtProductGroupCode.Name = "txtProductGroupCode";
            this.txtProductGroupCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtProductGroupCode.Properties.Appearance.Options.UseFont = true;
            this.txtProductGroupCode.Size = new System.Drawing.Size(249, 24);
            this.txtProductGroupCode.StyleController = this.layoutControl1;
            this.txtProductGroupCode.TabIndex = 4;
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
            this.layoutControlGroupMain.Size = new System.Drawing.Size(731, 122);
            this.layoutControlGroupMain.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 90);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(531, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.btnClose;
            this.layoutControlItem17.Location = new System.Drawing.Point(631, 90);
            this.layoutControlItem17.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(100, 32);
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
            this.layoutControlItem18.Size = new System.Drawing.Size(100, 32);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlGroupInfo
            // 
            this.layoutControlGroupInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem14,
            this.layoutControlItem4,
            this.layoutControlItem12});
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
            this.layoutControlItem1.Control = this.txtProductGroupCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(362, 28);
            this.layoutControlItem1.Text = "Mã nhóm hàng";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(106, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtProductGroupName;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(362, 28);
            this.layoutControlItem3.Text = "Tên nhóm hàng";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(106, 18);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.chkActive;
            this.layoutControlItem14.Location = new System.Drawing.Point(362, 56);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(363, 28);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtDescriptions;
            this.layoutControlItem4.Location = new System.Drawing.Point(362, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(363, 56);
            this.layoutControlItem4.Text = "Mô tả";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(106, 18);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.Control = this.txtOrderBy;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(362, 28);
            this.layoutControlItem12.Text = "Thứ tự";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(106, 18);
            // 
            // frmProductGroupUdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 122);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductGroupUdp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProductGroupUdp";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescriptions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductGroupCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.SpinEdit txtOrderBy;
        private DevExpress.XtraEditors.TextEdit txtProductGroupName;
        private DevExpress.XtraEditors.TextEdit txtProductGroupCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.Utils.ImageCollection imageCollectionButton16x16;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupInfo;
        private DevExpress.XtraEditors.MemoEdit txtDescriptions;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;

    }
}