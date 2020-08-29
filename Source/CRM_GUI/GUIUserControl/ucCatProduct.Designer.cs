namespace CRM_GUI.GUIUserControl
{
    partial class ucCatProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControlCatProduct = new DevExpress.XtraLayout.LayoutControl();
            this.pictureEditImage = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControlGroupCatProduct = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblCatProduct = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemImage = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCatProduct)).BeginInit();
            this.layoutControlCatProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCatProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCatProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlCatProduct
            // 
            this.layoutControlCatProduct.Controls.Add(this.pictureEditImage);
            this.layoutControlCatProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlCatProduct.Font = new System.Drawing.Font("Arial", 12F);
            this.layoutControlCatProduct.Location = new System.Drawing.Point(0, 0);
            this.layoutControlCatProduct.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControlCatProduct.Name = "layoutControlCatProduct";
            this.layoutControlCatProduct.Root = this.layoutControlGroupCatProduct;
            this.layoutControlCatProduct.Size = new System.Drawing.Size(165, 198);
            this.layoutControlCatProduct.TabIndex = 0;
            this.layoutControlCatProduct.Text = "layoutControl1";
            // 
            // pictureEditImage
            // 
            this.pictureEditImage.Location = new System.Drawing.Point(4, 2);
            this.pictureEditImage.Name = "pictureEditImage";
            this.pictureEditImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEditImage.Size = new System.Drawing.Size(156, 156);
            this.pictureEditImage.StyleController = this.layoutControlCatProduct;
            this.pictureEditImage.TabIndex = 4;
            this.pictureEditImage.Click += new System.EventHandler(this.pictureEditImage_Click);
            // 
            // layoutControlGroupCatProduct
            // 
            this.layoutControlGroupCatProduct.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupCatProduct.GroupBordersVisible = false;
            this.layoutControlGroupCatProduct.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblCatProduct,
            this.layoutControlItemImage});
            this.layoutControlGroupCatProduct.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupCatProduct.Name = "layoutControlGroupCatProduct";
            this.layoutControlGroupCatProduct.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupCatProduct.Size = new System.Drawing.Size(165, 198);
            this.layoutControlGroupCatProduct.TextVisible = false;
            // 
            // lblCatProduct
            // 
            this.lblCatProduct.AllowHotTrack = false;
            this.lblCatProduct.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 8F);
            this.lblCatProduct.AppearanceItemCaption.Options.UseFont = true;
            this.lblCatProduct.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblCatProduct.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCatProduct.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCatProduct.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCatProduct.Location = new System.Drawing.Point(0, 160);
            this.lblCatProduct.Name = "lblCatProduct";
            this.lblCatProduct.Size = new System.Drawing.Size(165, 38);
            this.lblCatProduct.Text = "CatProduct";
            this.lblCatProduct.TextSize = new System.Drawing.Size(0, 0);
            this.lblCatProduct.TextVisible = true;
            this.lblCatProduct.Click += new System.EventHandler(this.lblCatProduct_Click);
            // 
            // layoutControlItemImage
            // 
            this.layoutControlItemImage.Control = this.pictureEditImage;
            this.layoutControlItemImage.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItemImage.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemImage.MaxSize = new System.Drawing.Size(160, 160);
            this.layoutControlItemImage.MinSize = new System.Drawing.Size(160, 160);
            this.layoutControlItemImage.Name = "layoutControlItemImage";
            this.layoutControlItemImage.Size = new System.Drawing.Size(165, 160);
            this.layoutControlItemImage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemImage.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemImage.TextVisible = false;
            this.layoutControlItemImage.Click += new System.EventHandler(this.layoutControlItemImage_Click);
            // 
            // ucCatProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.layoutControlCatProduct);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(167, 200);
            this.MinimumSize = new System.Drawing.Size(167, 200);
            this.Name = "ucCatProduct";
            this.Size = new System.Drawing.Size(165, 198);
            this.Click += new System.EventHandler(this.ucCatProduct_Click);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCatProduct)).EndInit();
            this.layoutControlCatProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCatProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCatProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlCatProduct;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupCatProduct;
        private DevExpress.XtraEditors.PictureEdit pictureEditImage;
        private DevExpress.XtraLayout.EmptySpaceItem lblCatProduct;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemImage;
    }
}
