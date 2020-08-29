using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using CRM_GUI.GUIProduct;
using CRM_DTO.DTOCategories;
using CRM_GUI.CRMUtility.Messages;

namespace CRM_GUI.GUIUserControl
{
    public partial class ucCatProduct : UserControl
    {
        private frmProductSell gbFrmProductSell;
        public DTOCatProduct gbObjCatProduct { get; set; }
        public PictureEdit ctrlImage
        {
            get { return this.pictureEditImage; }
            set { this.pictureEditImage = value; }
        }

        public EmptySpaceItem ctrlInfo
        {
            get { return this.lblCatProduct; }
            set { this.lblCatProduct = value; }
        }

        public ucCatProduct()
        {
            InitializeComponent();
        }

        public ucCatProduct(frmProductSell _Frm)
        {
            InitializeComponent();
            gbObjCatProduct = new DTOCatProduct();
            gbFrmProductSell = _Frm;
        }

        public void SendDataToForm()
        {
            this.layoutControlGroupCatProduct.GroupBordersVisible = true;
            this.layoutControlGroupCatProduct.AppearanceGroup.BorderColor = System.Drawing.Color.Blue;
            gbFrmProductSell.ReceiveDataFromUC(gbObjCatProduct);
        }

        private void ucCatProduct_Click(object sender, EventArgs e)
        {
            SendDataToForm();
        }

        private void lblCatProduct_Click(object sender, EventArgs e)
        {
            SendDataToForm();
        }

        private void pictureEditImage_Click(object sender, EventArgs e)
        {
            SendDataToForm();
        }

        private void layoutControlItemImage_Click(object sender, EventArgs e)
        {
            SendDataToForm();
        }
    }
}
