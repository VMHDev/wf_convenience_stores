namespace Messages
{
    partial class frmVMHMessages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVMHMessages));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.imageList = new DevExpress.Utils.ImageCollection(this.components);
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox = new DevExpress.XtraEditors.PictureEdit();
            this.imageCollection = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.ImageIndex = 0;
            this.btnOK.ImageList = this.imageList;
            this.btnOK.Location = new System.Drawing.Point(141, 58);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(18, 18);
            this.imageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageList.ImageStream")));
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageIndex = 1;
            this.btnCancel.ImageList = this.imageList;
            this.btnCancel.Location = new System.Drawing.Point(222, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Location = new System.Drawing.Point(24, 51);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(272, 2);
            this.lblLine.TabIndex = 10;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(58, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(236, 32);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Properties.Appearance.Options.UseBackColor = true;
            this.pictureBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.TabIndex = 8;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.TransparentColor = System.Drawing.Color.Transparent;
            this.imageCollection.Images.SetKeyName(0, "176.gif");
            this.imageCollection.Images.SetKeyName(1, "253.gif");
            this.imageCollection.Images.SetKeyName(2, "172.gif");
            this.imageCollection.Images.SetKeyName(3, "296.gif");
            // 
            // frmVMHMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 89);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVMHMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVMHMessages";
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        internal System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.PictureEdit pictureBox;
        private System.Windows.Forms.ImageList imageCollection;
        private DevExpress.Utils.ImageCollection imageList;
    }
}