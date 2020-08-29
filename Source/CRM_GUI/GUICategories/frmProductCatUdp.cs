using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CRM_DTO.DTOCategories;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_GUI.CRMUtility.Messages;
using CRM_BLL.BLLCategories;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOSystem;
using CRM_GUI.CRMFunctions;

namespace CRM_GUI.GUICategories
{
    public partial class frmProductCatUdp : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private DTOCatProduct gbObjProductCat = null;
        private long gbOrderBy = -1;
        public bool gbResultHandler = false;
        #endregion

        #region Form
        public frmProductCatUdp()
        {
            InitializeComponent();
            DesignControls();
        }

        public frmProductCatUdp(long _OrderBy)
        {
            InitializeComponent();
            DesignControls();
            gbOrderBy = _OrderBy + 1;                    
        }

        public frmProductCatUdp(DTOCatProduct _obj)
        {
            InitializeComponent();
            DesignControls();
            gbObjProductCat = _obj;
        }

        private void frmProductCatUdp_Load(object sender, EventArgs e)
        {           
            LoadDataToDropDownList();
            LoadDataToForm();
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboProductType
        public GridView grvCboProductType { get; set; }
        public GridColumn colCboProductTypeID { get; set; }
        public GridColumn colCboProductTypeCode { get; set; }
        public GridColumn colCboProductTypeName { get; set; }
        #endregion

        #region cboProductGroup
        public GridView grvCboProductGroup { get; set; }
        public GridColumn colCboProductGroupID { get; set; }
        public GridColumn colCboProductGroupCode { get; set; }
        public GridColumn colCboProductGroupName { get; set; }
        #endregion

        #region cboSupplier
        public GridView grvCboSupplier { get; set; }
        public GridColumn colCboSupplierID { get; set; }
        public GridColumn colCboSupplierCode { get; set; }
        public GridColumn colCboSupplierName { get; set; }
        public GridColumn colCboSupplierAddress { get; set; }
        public GridColumn colCboSupplierPhone { get; set; }

        #endregion
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Danh mục hàng hóa";
            this.Load += new System.EventHandler(this.frmProductCatUdp_Load);
            #endregion
            DesignGridLookUpEdit();
            DesignTextSpinEdit();
        }

        private void DesignTextSpinEdit()
        {
            txtProductCatCode.ReadOnly = true;
            txtProductCatCode.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtProductCatCode.Properties.Appearance.Options.UseBackColor = true;
            txtProductCatCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            txtProductCatCode.Properties.Appearance.Options.UseFont = true;
            txtProductCatCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            txtProductCatCode.Properties.Appearance.Options.UseForeColor = true;
            txtProductCatCode.TabStop = false;

            txtOrderBy.Properties.DisplayFormat.FormatString = "#,##0";
            txtOrderBy.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOrderBy.Properties.EditFormat.FormatString = "#,##0";
            txtOrderBy.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOrderBy.Properties.Mask.EditMask = "n0";
            txtOrderBy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtOrderBy.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void DesignGridLookUpEdit()
        {
            #region cboProductType
            //
            // colCboProductTypeID
            //
            this.colCboProductTypeID = new GridColumn();
            this.colCboProductTypeID.Caption = "ID loại hàng";
            this.colCboProductTypeID.FieldName = "ProductTypeID";
            this.colCboProductTypeID.Name = "colCboProductTypeID";
            this.colCboProductTypeID.Visible = false;
            //this.colCboProductTypeID.VisibleIndex = -1;
            //
            // colCboProductTypeCode
            //
            this.colCboProductTypeCode = new GridColumn();
            this.colCboProductTypeCode.Caption = "Mã loại hàng";
            this.colCboProductTypeCode.FieldName = "ProductTypeCode";
            this.colCboProductTypeCode.Name = "colCboProductTypeCode";
            this.colCboProductTypeCode.Visible = true;
            this.colCboProductTypeCode.VisibleIndex = 0;
            //
            // colCboProductTypeName
            //
            this.colCboProductTypeName = new GridColumn();
            this.colCboProductTypeName.Caption = "Tên loại hàng";
            this.colCboProductTypeName.FieldName = "ProductTypeName";
            this.colCboProductTypeName.Name = "colCboProductTypeName";
            this.colCboProductTypeName.Visible = true;
            this.colCboProductTypeName.VisibleIndex = 1;
            // 
            // grvCboProductType
            // 
            this.grvCboProductType = new GridView();
            this.grvCboProductType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboProductTypeID,
                this.colCboProductTypeCode,
                this.colCboProductTypeName});
            this.grvCboProductType.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboProductType.Name = "grvCboProductType";
            this.grvCboProductType.OptionsBehavior.Editable = false;
            this.grvCboProductType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboProductType.OptionsView.ShowAutoFilterRow = true;
            this.grvCboProductType.OptionsView.ShowGroupPanel = false;
            this.grvCboProductType.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductType.Appearance.Row.Options.UseFont = true;
            this.grvCboProductType.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductType.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboProductType.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboProductType.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboProductType.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboProductType
            // 
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.Appearance.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboProductType.Properties.NullText = "";
            this.cboProductType.Properties.ShowFooter = false;
            this.cboProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboProductType.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboProductType.Properties.View = this.grvCboProductType;
            //this.cboProductType.EditValueChanged += new System.EventHandler(this.cboProductType_EditValueChanged);
            this.cboProductType.ReadOnly = true;
            this.cboProductType.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboProductType.Properties.Appearance.Options.UseBackColor = true;
            this.cboProductType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboProductType.Properties.Appearance.Options.UseForeColor = true;
            this.cboProductType.TabStop = false;
            #endregion

            #region cboProductGroup
            //
            // colCboProductGroupID
            //
            this.colCboProductGroupID = new GridColumn();
            this.colCboProductGroupID.Caption = "ID nhóm hàng";
            this.colCboProductGroupID.FieldName = "ProductGroupID";
            this.colCboProductGroupID.Name = "colCboProductGroupID";
            this.colCboProductGroupID.Visible = false;
            //this.colCboProductGroupID.VisibleIndex = -1;
            //
            // colCboProductGroupCode
            //
            this.colCboProductGroupCode = new GridColumn();
            this.colCboProductGroupCode.Caption = "Mã nhóm hàng";
            this.colCboProductGroupCode.FieldName = "ProductGroupCode";
            this.colCboProductGroupCode.Name = "colCboProductGroupCode";
            this.colCboProductGroupCode.Visible = true;
            this.colCboProductGroupCode.VisibleIndex = 0;
            //
            // colCboProductGroupName
            //
            this.colCboProductGroupName = new GridColumn();
            this.colCboProductGroupName.Caption = "Tên nhóm hàng";
            this.colCboProductGroupName.FieldName = "ProductGroupName";
            this.colCboProductGroupName.Name = "colCboProductGroupName";
            this.colCboProductGroupName.Visible = true;
            this.colCboProductGroupName.VisibleIndex = 1;
            // 
            // grvCboProductGroup
            // 
            this.grvCboProductGroup = new GridView();
            this.grvCboProductGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboProductGroupID,
                this.colCboProductGroupCode,
                this.colCboProductGroupName});
            this.grvCboProductGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboProductGroup.Name = "grvCboProductGroup";
            this.grvCboProductGroup.OptionsBehavior.Editable = false;
            this.grvCboProductGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboProductGroup.OptionsView.ShowAutoFilterRow = true;
            this.grvCboProductGroup.OptionsView.ShowGroupPanel = false;
            this.grvCboProductGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductGroup.Appearance.Row.Options.UseFont = true;
            this.grvCboProductGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboProductGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboProductGroup.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboProductGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboProductGroup
            // 
            this.cboProductGroup.Name = "cboProductGroup";
            this.cboProductGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.Appearance.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboProductGroup.Properties.NullText = "";
            this.cboProductGroup.Properties.ShowFooter = false;
            this.cboProductGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProductGroup.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboProductGroup.Properties.View = this.grvCboProductGroup;
            //this.cboProductGroup.EditValueChanged += new System.EventHandler(this.cboProductGroup_EditValueChanged);
            #endregion

            #region cboSupplier
            //
            // colCboSupplierID
            //
            this.colCboSupplierID = new GridColumn();
            this.colCboSupplierID.Caption = "ID nhà cung cấp";
            this.colCboSupplierID.FieldName = "SupplierID";
            this.colCboSupplierID.Name = "colCboSupplierID";
            this.colCboSupplierID.Visible = false;
            //this.colCboSupplierID.VisibleIndex = -1;
            //
            // colCboSupplierCode
            //
            this.colCboSupplierCode = new GridColumn();
            this.colCboSupplierCode.Caption = "Mã nhà cung cấp";
            this.colCboSupplierCode.FieldName = "SupplierCode";
            this.colCboSupplierCode.Name = "colCboSupplierCode";
            this.colCboSupplierCode.Visible = true;
            this.colCboSupplierCode.VisibleIndex = 0;
            //
            // colCboSupplierName
            //
            this.colCboSupplierName = new GridColumn();
            this.colCboSupplierName.Caption = "Tên nhà cung cấp";
            this.colCboSupplierName.FieldName = "SupplierName";
            this.colCboSupplierName.Name = "colCboSupplierName";
            this.colCboSupplierName.Visible = true;
            this.colCboSupplierName.VisibleIndex = 1;
            // 
            // grvCboSupplier
            // 
            this.grvCboSupplier = new GridView();
            this.grvCboSupplier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboSupplierID,
                this.colCboSupplierCode,
                this.colCboSupplierName});
            this.grvCboSupplier.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboSupplier.Name = "grvCboSupplier";
            this.grvCboSupplier.OptionsBehavior.Editable = false;
            this.grvCboSupplier.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboSupplier.OptionsView.ShowAutoFilterRow = true;
            this.grvCboSupplier.OptionsView.ShowGroupPanel = false;
            this.grvCboSupplier.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboSupplier.Appearance.Row.Options.UseFont = true;
            this.grvCboSupplier.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboSupplier.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboSupplier.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboSupplier.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboSupplier.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboSupplier
            // 
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.Appearance.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboSupplier.Properties.NullText = "";
            this.cboSupplier.Properties.ShowFooter = false;
            this.cboSupplier.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSupplier.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboSupplier.Properties.View = this.grvCboSupplier;
            //this.cboSupplier.EditValueChanged += new System.EventHandler(this.cboSupplier_EditValueChanged);
            #endregion
        }        
        #endregion

        #region Functions
        /// <summary>
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadDefault()
        {
            txtDescriptions.EditValue = string.Empty;
            txtProductCatCode.EditValue = "Tự động";
            txtProductCatName.EditValue = string.Empty;
            txtOrderBy.EditValue = gbOrderBy;
            
            cboProductType.EditValue = cboProductType.Properties.GetKeyValue(0);
            cboProductGroup.EditValue = cboProductGroup.Properties.GetKeyValue(1);            
            cboSupplier.EditValue = cboSupplier.Properties.GetKeyValue(0);

            chkActive.Checked = true;
            ucPictureEdit.gbProductCatImage = null;
        }

        /// <summary>
        /// Load dữ liệu DropDownList
        /// </summary>
        private void LoadDataToDropDownList()
        {
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatProductGroup.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboProductGroup.Properties.DataSource = ds.Tables[0].Copy();
                    cboProductGroup.Properties.DisplayMember = "ProductGroupName";
                    cboProductGroup.Properties.ValueMember = "ProductGroupID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatProductType.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboProductType.Properties.DataSource = ds.Tables[0].Copy();
                    cboProductType.Properties.DisplayMember = "ProductTypeName";
                    cboProductType.Properties.ValueMember = "ProductTypeID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatSupplier.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboSupplier.Properties.DataSource = ds.Tables[0].Copy();
                    cboSupplier.Properties.DisplayMember = "SupplierName";
                    cboSupplier.Properties.ValueMember = "SupplierID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
        }

        /// <summary>
        /// Load dữ liệu cho form
        /// </summary>
        private void LoadDataToForm()
        {
            txtDescriptions.EditValue = gbObjProductCat == null ? string.Empty : gbObjProductCat.Descriptions;
            txtProductCatCode.EditValue = gbObjProductCat == null ? "Tự động" : gbObjProductCat.ProductCatCode;
            txtProductCatName.EditValue = gbObjProductCat == null ? string.Empty : gbObjProductCat.ProductCatName;
            txtOrderBy.EditValue = gbObjProductCat == null ? gbOrderBy : gbObjProductCat.OrderBy;

            cboProductType.EditValue = gbObjProductCat == null ?cboProductType.Properties.GetKeyValue(0) : gbObjProductCat.ProductType.ID;
            cboProductGroup.EditValue = gbObjProductCat == null ? cboProductGroup.Properties.GetKeyValue(1) : gbObjProductCat.ProductGroup.ID;
            cboSupplier.EditValue = gbObjProductCat == null ? cboSupplier.Properties.GetKeyValue(0) : gbObjProductCat.Supplier.ID;

            chkActive.Checked = gbObjProductCat == null ? true : gbObjProductCat.IsActive;
            byte[] btarrImage = gbObjProductCat == null ? null : gbObjProductCat.ProductCatImage;
            ucPictureEdit.gbProductCatImage = btarrImage;
            ucPictureEdit.SetValuePictureEdit(btarrImage);
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        /// <param name="_ID">ID quầy thu ngân</param>
        /// <param name="_Message">Thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SaveClick(long _ID, out string _CodeUpd, out string _Message)
        {
            _Message = string.Empty;
            _CodeUpd = string.Empty;
            DataSet ds = new DataSet();            
            bool bResult = false;
            try
            {
                string sCode = txtProductCatCode.Text;
                long lCurrentID = FuncGeneral.GetCurrentID("CAT_PRODUCT");
                _CodeUpd = _ID == -1 ? FuncGeneral.GenTransactionCode("CAT_PRODUCT", lCurrentID) : sCode;

                DTOCatProduct objCatProduct = new DTOCatProduct();
                objCatProduct.ProductCatID = _ID;
                objCatProduct.ProductCatCode = _CodeUpd;
                objCatProduct.ProductCatName = txtProductCatName.EditValue == null ? string.Empty : Convert.ToString(txtProductCatName.EditValue);
                objCatProduct.Descriptions = txtDescriptions.EditValue == null ? string.Empty : Convert.ToString(txtDescriptions.EditValue);
                objCatProduct.ProductType.ID = cboProductType.EditValue == null ? -1 : Convert.ToInt64(cboProductType.EditValue);
                objCatProduct.ProductGroup.ID = cboProductGroup.EditValue == null ? -1 : Convert.ToInt64(cboProductGroup.EditValue);
                objCatProduct.Supplier.ID = cboSupplier.EditValue == null ? -1 : Convert.ToInt64(cboSupplier.EditValue);
                objCatProduct.ProductCatImage = ucPictureEdit.gbProductCatImage == null ? null : (byte[])ucPictureEdit.gbProductCatImage;
                objCatProduct.OrderBy = txtOrderBy.EditValue == null ? gbOrderBy : Convert.ToInt64(txtOrderBy.EditValue);
                objCatProduct.IsActive = chkActive.Checked;
                objCatProduct.UpdateDate = DateTime.Now;
                objCatProduct.UpdateBy = DTOAttributeSystem.CurrentUser.ID;
                objCatProduct.IsDelete = false;

                bResult = BLLCatProduct.CatProduct_InsUpd(objCatProduct, out _Message);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            long lID = gbObjProductCat == null ? -1 : gbObjProductCat.ProductCatID;
            string sCode = string.Empty;
            if (SaveClick(lID, out sCode, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
                gbResultHandler = true;
                txtProductCatCode.Text = sCode;
                this.Close();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}