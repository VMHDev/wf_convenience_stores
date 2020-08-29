using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Camera;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace CRM_GUI.GUIUserControl
{
    public partial class ucPictureEdit : DevExpress.XtraEditors.XtraUserControl
    {
        #region Variables
        public byte[] gbProductCatImage { get; set; }

        public const int ImageWidth = 160;
        public const int ImageHeight = 160;
        #endregion

        #region UserControl
        public ucPictureEdit()
        {
            InitializeComponent();
            DesignControls();
        }

        public ucPictureEdit(byte[] _ProductCatImage)
        {
            InitializeComponent();
            DesignControls();
            gbProductCatImage = _ProductCatImage;
        }

        private void ucPictureEdit_Load(object sender, EventArgs e)
        {
            pictureEditPhoto.EditValue = gbProductCatImage;
        }
        #endregion

        #region Design
        /// <summary>
        /// Design controls
        /// </summary>
        private void DesignControls()
        {
            this.Load += new System.EventHandler(this.ucPictureEdit_Load);
            DesignPictureEdit();
            DesignHyperLinkEdit();
        }

        /// <summary>
        /// Design PictureEdit
        /// </summary>
        private void DesignPictureEdit()
        {
            this.pictureEditPhoto.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.pictureEditPhoto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEditPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEditPhoto.TabStop = true;
        }

        /// <summary>
        /// Design HyperLinkEdit
        /// </summary>
        private void DesignHyperLinkEdit()
        {
            this.hyperLinkEditDelete.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Underline);
            this.hyperLinkEditDelete.Properties.Appearance.Options.UseFont = true;
            this.hyperLinkEditDelete.Properties.Appearance.Options.UseTextOptions = true;
            this.hyperLinkEditDelete.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hyperLinkEditDelete.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.hyperLinkEditDelete.TabStop = true;
            this.hyperLinkEditDelete.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEditDelete_OpenLink);

            this.hyperLinkEditTakePhoto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Underline);
            this.hyperLinkEditTakePhoto.Properties.Appearance.Options.UseFont = true;
            this.hyperLinkEditTakePhoto.Properties.Appearance.Options.UseTextOptions = true;
            this.hyperLinkEditTakePhoto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hyperLinkEditTakePhoto.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.hyperLinkEditDelete.TabStop = true;
            this.hyperLinkEditTakePhoto.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEditTakePhoto_OpenLink);

            this.hyperLinkEditUpPhoto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Underline);
            this.hyperLinkEditUpPhoto.Properties.Appearance.Options.UseFont = true;
            this.hyperLinkEditUpPhoto.Properties.Appearance.Options.UseTextOptions = true;
            this.hyperLinkEditUpPhoto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hyperLinkEditUpPhoto.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.hyperLinkEditDelete.TabStop = true;
            this.hyperLinkEditUpPhoto.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEditUpPhoto_OpenLink);
        }
        #endregion

        #region Functions
        public void SetValuePictureEdit(byte[] _Value)
        {
            pictureEditPhoto.EditValue = _Value;
            gbProductCatImage = _Value;
        }
        #endregion

        #region HyperLinkEdit
        private void hyperLinkEditUpPhoto_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            pictureEditPhoto.LoadImage();
            Image imgUpload = pictureEditPhoto.Image;
            if (imgUpload == null)
            {
                return;
            }

            using (var stream = new MemoryStream())
            {
                using (Bitmap dst = new Bitmap(ImageWidth, ImageHeight))
                {
                    using (Graphics g = Graphics.FromImage(dst))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(imgUpload, 0, 0, dst.Width, dst.Height);
                    }
                    Image imgScale = new Bitmap(dst);
                    imgScale.Save(stream, ImageFormat.Jpeg);
                    pictureEditPhoto.EditValue = stream.ToArray();
                    gbProductCatImage = stream.ToArray();
                }
            }
        }

        private void hyperLinkEditTakePhoto_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            TakePictureDialog dialog = new TakePictureDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image imgTake = dialog.Image;
                if (imgTake == null)
                {
                    return;
                }

                using (var stream = new MemoryStream())
                {
                    using (Bitmap dst = new Bitmap(ImageWidth, ImageHeight))
                    {
                        using (Graphics g = Graphics.FromImage(dst))
                        {
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.DrawImage(imgTake, 0, 0, dst.Width, dst.Height);
                        }
                        Image imgScale = new Bitmap(dst);
                        imgScale.Save(stream, ImageFormat.Jpeg);
                        pictureEditPhoto.EditValue = stream.ToArray();
                        gbProductCatImage = stream.ToArray();
                    }
                }
            }
        }

        private void hyperLinkEditDelete_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            pictureEditPhoto.EditValue = null;
            gbProductCatImage = null;
        }
        #endregion
    }
}
