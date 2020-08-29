namespace CRM_GUI.GUICategories
{
    partial class frmStalls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStalls));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionButton16x16 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grc = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnEdit);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.grc);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(978, 405);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageIndex = 1;
            this.btnAdd.ImageList = this.imageCollectionButton16x16;
            this.btnAdd.Location = new System.Drawing.Point(580, 375);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 28);
            this.btnAdd.StyleController = this.layoutControl1;
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm";
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
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageIndex = 3;
            this.btnDelete.ImageList = this.imageCollectionButton16x16;
            this.btnDelete.Location = new System.Drawing.Point(680, 375);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 28);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageIndex = 2;
            this.btnEdit.ImageList = this.imageCollectionButton16x16;
            this.btnEdit.Location = new System.Drawing.Point(780, 375);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 28);
            this.btnEdit.StyleController = this.layoutControl1;
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageIndex = 4;
            this.btnClose.ImageList = this.imageCollectionButton16x16;
            this.btnClose.Location = new System.Drawing.Point(880, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            // 
            // grc
            // 
            this.grc.Location = new System.Drawing.Point(98, 2);
            this.grc.MainView = this.grv;
            this.grc.Name = "grc";
            this.grc.Size = new System.Drawing.Size(878, 369);
            this.grc.TabIndex = 4;
            this.grc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.GridControl = this.grc;
            this.grv.Name = "grv";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(978, 405);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grc;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(978, 373);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
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
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(778, 373);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(100, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnDelete;
            this.layoutControlItem4.Location = new System.Drawing.Point(678, 373);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(100, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnAdd;
            this.layoutControlItem5.Location = new System.Drawing.Point(578, 373);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(100, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(100, 32);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 373);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(578, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmStalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 405);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmStalls";
            this.Text = "frmStalls";
            this.Load += new System.EventHandler(this.frmStalls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionButton16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl grc;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.Utils.ImageCollection imageCollectionButton16x16;
    }
}