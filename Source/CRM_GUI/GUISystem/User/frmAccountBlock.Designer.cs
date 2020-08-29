namespace CRM_GUI.GUISystem.User
{
    partial class frmAccountBlock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountBlock));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.cboUser = new DevExpress.XtraEditors.GridLookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnBlock = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollectionButton16x16 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.btnBlock);
            this.layoutControl1.Controls.Add(this.cboUser);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(516, 61);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(516, 61);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(90, 2);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.View = this.gridLookUpEdit1View;
            this.cboUser.Size = new System.Drawing.Size(424, 24);
            this.cboUser.StyleController = this.layoutControl1;
            this.cboUser.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.cboUser;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(516, 28);
            this.layoutControlItem1.Text = "Người dùng";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(84, 18);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(292, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnBlock
            // 
            this.btnBlock.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBlock.Appearance.Options.UseFont = true;
            this.btnBlock.ImageIndex = 37;
            this.btnBlock.ImageList = this.imageCollectionButton16x16;
            this.btnBlock.Location = new System.Drawing.Point(294, 30);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(110, 28);
            this.btnBlock.StyleController = this.layoutControl1;
            this.btnBlock.TabIndex = 5;
            this.btnBlock.Text = "Khóa";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnBlock;
            this.layoutControlItem2.Location = new System.Drawing.Point(292, 28);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(114, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(114, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(114, 33);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageIndex = 4;
            this.simpleButton2.ImageList = this.imageCollectionButton16x16;
            this.simpleButton2.Location = new System.Drawing.Point(408, 30);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(106, 28);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "Thoát";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton2;
            this.layoutControlItem3.Location = new System.Drawing.Point(406, 28);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(110, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(110, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(110, 33);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
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
            // frmAccountBlock
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 61);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAccountBlock";
            this.Text = "frmAccountBlock";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnBlock;
        private DevExpress.XtraEditors.GridLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.Utils.ImageCollection imageCollectionButton16x16;
    }
}