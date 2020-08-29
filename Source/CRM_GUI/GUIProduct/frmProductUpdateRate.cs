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
using CRM_GUI.CRMUtility.Messages;
using DevExpress.XtraGrid.Columns;
using CRM_BLL.BLLCategories;
using DevExpress.XtraEditors.Repository;
using CRM_DTO.DTOSystem;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;
using CRM_BLL.BLLProduct;
using DevExpress.XtraGrid.Views.Grid;
using CRM_BLL.BLLSystem;
using CRM_DTO.CRMFunctions;

namespace CRM_GUI.GUIQuery
{
    public partial class frmProductUpdateRate : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private const int gbSizeImage = 160;
        #endregion

        #region Form
        public frmProductUpdateRate()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmProductUpdateRate_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            LoadDataToGrid(-1, "I");
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

        #region cboDtlStalls
        public GridView grvCboDtlStalls { get; set; }
        public GridColumn colCboDtlStallsID { get; set; }
        public GridColumn colCboDtlStallsCode { get; set; }
        public GridColumn colCboDtlStallsName { get; set; }
        #endregion

        #region cboDtlStatus
        public GridView grvCboDtlStatus { get; set; }
        public GridColumn colCboDtlStatusID { get; set; }
        public GridColumn colCboDtlStatusCode { get; set; }
        public GridColumn colCboDtlStatusName { get; set; }
        #endregion

        #region Gridview
        public GridColumn colProductID { get; set; }
        public GridColumn colProductCode { get; set; }
        public GridColumn colProductDesc { get; set; }
        public GridColumn colDescriptions { get; set; }
        public GridColumn colProductTypeID { get; set; }
        public GridColumn colProductTypeCode { get; set; }
        public GridColumn colProductTypeName { get; set; }
        public GridColumn colProductGroupID { get; set; }
        public GridColumn colProductGroupCode { get; set; }
        public GridColumn colProductGroupName { get; set; }
        public GridColumn colUnitWeightID { get; set; }
        public GridColumn colUnitWeightCode { get; set; }
        public GridColumn colUnitWeightDesc { get; set; }
        public GridColumn colUnitSellID { get; set; }
        public GridColumn colUnitSellCode { get; set; }
        public GridColumn colUnitSellDesc { get; set; }
        public GridColumn colSupplierID { get; set; }
        public GridColumn colSupplierCode { get; set; }
        public GridColumn colSupplierName { get; set; }
        public GridColumn colStatusCode { get; set; }
        public GridColumn colStatusName { get; set; }
        public GridColumn colStallsID { get; set; }
        public GridColumn colStallsCode { get; set; }
        public GridColumn colStallsName { get; set; }
        public GridColumn colQuantity { get; set; }
        public GridColumn colQuantityReal { get; set; }
        public GridColumn colWeights { get; set; }
        public GridColumn colWeightsReal { get; set; }
        public GridColumn colRateIn { get; set; }
        public GridColumn colRateEstimate { get; set; }
        public GridColumn colDiscountPercent { get; set; }
        public GridColumn colDiscount { get; set; }
        public GridColumn colDiscountTotal { get; set; }
        public GridColumn colRateSell { get; set; }
        public GridColumn colUpdateDate { get; set; }
        public GridColumn colUpdateBy { get; set; }
        public GridColumn colUserUpdate { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Cập nhật giá";
            this.Load += new System.EventHandler(this.frmProductUpdateRate_Load);
            #endregion

            DesignGridLookUpEdit();
            DesignTextSpinEdit();
            DesignGridview();
        }

        /// <summary>
        /// Design TextSpinEdit
        /// </summary>
        private void DesignTextSpinEdit()
        {
            txtDtlProductCode.ReadOnly = true;
            txtDtlProductCode.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDtlProductCode.Properties.Appearance.Options.UseBackColor = true;
            txtDtlProductCode.TabStop = false;

            txtDtlProductDesc.ReadOnly = true;
            txtDtlProductDesc.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDtlProductDesc.Properties.Appearance.Options.UseBackColor = true;
            txtDtlProductDesc.TabStop = false;

            txtDtlDescriptions.ReadOnly = true;
            txtDtlDescriptions.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDtlDescriptions.Properties.Appearance.Options.UseBackColor = true;
            txtDtlDescriptions.TabStop = false;

            txtDtlQuantity.ReadOnly = true;
            txtDtlQuantity.Properties.DisplayFormat.FormatString = "#,##0";
            txtDtlQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlQuantity.Properties.EditFormat.FormatString = "#,##0";
            txtDtlQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlQuantity.Properties.Mask.EditMask = "n0";
            txtDtlQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDtlQuantity.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDtlQuantity.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDtlQuantity.Properties.Appearance.Options.UseBackColor = true;
            txtDtlQuantity.TabStop = false;

            txtDtlQuantityReal.ReadOnly = true;
            txtDtlQuantityReal.Properties.DisplayFormat.FormatString = "#,##0";
            txtDtlQuantityReal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlQuantityReal.Properties.EditFormat.FormatString = "#,##0";
            txtDtlQuantityReal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlQuantityReal.Properties.Mask.EditMask = "n0";
            txtDtlQuantityReal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDtlQuantityReal.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDtlQuantityReal.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDtlQuantityReal.Properties.Appearance.Options.UseBackColor = true;
            txtDtlQuantityReal.TabStop = false;

            txtDtlWeights.ReadOnly = true;
            txtDtlWeights.Properties.DisplayFormat.FormatString = "#,##0.00";
            txtDtlWeights.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlWeights.Properties.EditFormat.FormatString = "#,##0.00";
            txtDtlWeights.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlWeights.Properties.Mask.EditMask = "n2";
            txtDtlWeights.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDtlWeights.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDtlWeights.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDtlWeights.Properties.Appearance.Options.UseBackColor = true;
            txtDtlWeights.TabStop = false;

            txtDtlWeightsReal.ReadOnly = true;
            txtDtlWeightsReal.Properties.DisplayFormat.FormatString = "#,##0.00";
            txtDtlWeightsReal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlWeightsReal.Properties.EditFormat.FormatString = "#,##0.00";
            txtDtlWeightsReal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDtlWeightsReal.Properties.Mask.EditMask = "n2";
            txtDtlWeightsReal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDtlWeightsReal.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDtlWeightsReal.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDtlWeightsReal.Properties.Appearance.Options.UseBackColor = true;
            txtDtlWeightsReal.TabStop = false;

            txtRateIn.ReadOnly = true;
            txtRateIn.Properties.DisplayFormat.FormatString = "#,##0";
            txtRateIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateIn.Properties.EditFormat.FormatString = "#,##0";
            txtRateIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateIn.Properties.Mask.EditMask = "n0";
            txtRateIn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtRateIn.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtRateIn.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtRateIn.Properties.Appearance.Options.UseBackColor = true;
            txtRateIn.TabStop = false;

            txtRateSell.ReadOnly = true;
            txtRateSell.Properties.DisplayFormat.FormatString = "#,##0";
            txtRateSell.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateSell.Properties.EditFormat.FormatString = "#,##0";
            txtRateSell.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateSell.Properties.Mask.EditMask = "n0";
            txtRateSell.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtRateSell.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtRateSell.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtRateSell.Properties.Appearance.Options.UseBackColor = true;
            txtRateSell.TabStop = false;

            txtDiscountPercentMoney.ReadOnly = true;
            txtDiscountPercentMoney.Properties.DisplayFormat.FormatString = "#,##0";
            txtDiscountPercentMoney.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountPercentMoney.Properties.EditFormat.FormatString = "#,##0";
            txtDiscountPercentMoney.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountPercentMoney.Properties.Mask.EditMask = "n0";
            txtDiscountPercentMoney.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDiscountPercentMoney.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDiscountPercentMoney.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDiscountPercentMoney.Properties.Appearance.Options.UseBackColor = true;
            txtDiscountPercentMoney.TabStop = false;

            txtDiscountTotal.ReadOnly = true;
            txtDiscountTotal.Properties.DisplayFormat.FormatString = "#,##0";
            txtDiscountTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountTotal.Properties.EditFormat.FormatString = "#,##0";
            txtDiscountTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountTotal.Properties.Mask.EditMask = "n0";
            txtDiscountTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDiscountTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDiscountTotal.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDiscountTotal.Properties.Appearance.Options.UseBackColor = true;
            txtDiscountTotal.TabStop = false;

            txtRateEstimate.Properties.DisplayFormat.FormatString = "#,##0";
            txtRateEstimate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateEstimate.Properties.EditFormat.FormatString = "#,##0";
            txtRateEstimate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateEstimate.Properties.Mask.EditMask = "n0";
            txtRateEstimate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtRateEstimate.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtRateEstimate.Properties.MaxValue = 9999999999;
            txtRateEstimate.Properties.MinValue = 0;
            this.txtRateEstimate.EditValueChanged += new System.EventHandler(this.txtRateEstimate_EditValueChanged);

            txtDiscountPercent.Properties.DisplayFormat.FormatString = "#,##0";
            txtDiscountPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountPercent.Properties.EditFormat.FormatString = "#,##0.00";
            txtDiscountPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountPercent.Properties.Mask.EditMask = "n2";
            txtDiscountPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDiscountPercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDiscountPercent.Properties.MaxValue = 100;
            txtDiscountPercent.Properties.MinValue = 0;
            this.txtDiscountPercent.EditValueChanged += new System.EventHandler(this.txtDiscountPercent_EditValueChanged);

            txtDiscount.Properties.DisplayFormat.FormatString = "#,##0";
            txtDiscount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscount.Properties.EditFormat.FormatString = "#,##0";
            txtDiscount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscount.Properties.Mask.EditMask = "n0";
            txtDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDiscount.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDiscount.Properties.MaxValue = 9999999999;
            txtDiscount.Properties.MinValue = 0;
            this.txtDiscount.EditValueChanged += new System.EventHandler(this.txtDiscount_EditValueChanged);
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
            #region cboDtlProductType
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
            // cboDtlProductType
            // 
            this.cboDtlProductType.Name = "cboDtlProductType";
            this.cboDtlProductType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductType.Properties.Appearance.Options.UseFont = true;
            this.cboDtlProductType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDtlProductType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDtlProductType.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDtlProductType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDtlProductType.Properties.NullText = "";
            this.cboDtlProductType.Properties.ShowFooter = false;
            this.cboDtlProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDtlProductType.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboDtlProductType.Properties.View = this.grvCboProductType;
            this.cboDtlProductType.ReadOnly = true;
            this.cboDtlProductType.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboDtlProductType.Properties.Appearance.Options.UseBackColor = true;
            this.cboDtlProductType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboDtlProductType.Properties.Appearance.Options.UseFont = true;
            this.cboDtlProductType.TabStop = false;
            #endregion

            #region cboDtlProductGroup
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
            // cboDtlProductGroup
            // 
            this.cboDtlProductGroup.Name = "cboDtlProductGroup";
            this.cboDtlProductGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductGroup.Properties.Appearance.Options.UseFont = true;
            this.cboDtlProductGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDtlProductGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDtlProductGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDtlProductGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlProductGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDtlProductGroup.Properties.NullText = "";
            this.cboDtlProductGroup.Properties.ShowFooter = false;
            this.cboDtlProductGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDtlProductGroup.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboDtlProductGroup.Properties.View = this.grvCboProductGroup;
            this.cboDtlProductGroup.ReadOnly = true;
            this.cboDtlProductGroup.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboDtlProductGroup.Properties.Appearance.Options.UseBackColor = true;
            this.cboDtlProductGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboDtlProductGroup.Properties.Appearance.Options.UseFont = true;
            this.cboDtlProductGroup.TabStop = false;
            #endregion

            #region cboDtlStalls
            //
            // colCboDtlStallsID
            //
            this.colCboDtlStallsID = new GridColumn();
            this.colCboDtlStallsID.Caption = "ID quầy/kho";
            this.colCboDtlStallsID.FieldName = "StallsID";
            this.colCboDtlStallsID.Name = "colCboStallsID";
            this.colCboDtlStallsID.Visible = false;
            //this.colCboDtlStallsID.VisibleIndex = -1;
            //
            // colCboDtlStallsCode
            //
            this.colCboDtlStallsCode = new GridColumn();
            this.colCboDtlStallsCode.Caption = "Mã quầy/kho";
            this.colCboDtlStallsCode.FieldName = "StallsCode";
            this.colCboDtlStallsCode.Name = "colCboStallsCode";
            this.colCboDtlStallsCode.Visible = true;
            this.colCboDtlStallsCode.VisibleIndex = 0;
            //
            // colCboDtlStallsName
            //
            this.colCboDtlStallsName = new GridColumn();
            this.colCboDtlStallsName.Caption = "Tên quầy/kho";
            this.colCboDtlStallsName.FieldName = "StallsName";
            this.colCboDtlStallsName.Name = "colCboStallsName";
            this.colCboDtlStallsName.Visible = true;
            this.colCboDtlStallsName.VisibleIndex = 1;
            // 
            // grvCboStalls
            // 
            this.grvCboDtlStalls = new GridView();
            this.grvCboDtlStalls.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboDtlStallsID,
                this.colCboDtlStallsCode,
                this.colCboDtlStallsName});
            this.grvCboDtlStalls.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboDtlStalls.Name = "grvCboStalls";
            this.grvCboDtlStalls.OptionsBehavior.Editable = false;
            this.grvCboDtlStalls.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboDtlStalls.OptionsView.ShowAutoFilterRow = true;
            this.grvCboDtlStalls.OptionsView.ShowGroupPanel = false;
            this.grvCboDtlStalls.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboDtlStalls.Appearance.Row.Options.UseFont = true;
            this.grvCboDtlStalls.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboDtlStalls.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboDtlStalls.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboDtlStalls.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboDtlStalls.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboDtlStalls
            // 
            this.cboDtlStalls.Name = "cboDtlStalls";
            this.cboDtlStalls.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStalls.Properties.Appearance.Options.UseFont = true;
            this.cboDtlStalls.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStalls.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDtlStalls.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStalls.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDtlStalls.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStalls.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDtlStalls.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStalls.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDtlStalls.Properties.NullText = "";
            this.cboDtlStalls.Properties.ShowFooter = false;
            this.cboDtlStalls.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDtlStalls.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboDtlStalls.Properties.View = this.grvCboDtlStalls;
            this.cboDtlStalls.ReadOnly = true;
            this.cboDtlStalls.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboDtlStalls.Properties.Appearance.Options.UseBackColor = true;
            this.cboDtlStalls.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboDtlStalls.Properties.Appearance.Options.UseFont = true;
            this.cboDtlStalls.TabStop = false;
            #endregion

            #region cboDtlSupplier
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
            // cboDtlSupplier
            // 
            this.cboDtlSupplier.Name = "cboDtlSupplier";
            this.cboDtlSupplier.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlSupplier.Properties.Appearance.Options.UseFont = true;
            this.cboDtlSupplier.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlSupplier.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDtlSupplier.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlSupplier.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDtlSupplier.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlSupplier.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDtlSupplier.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlSupplier.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDtlSupplier.Properties.NullText = "";
            this.cboDtlSupplier.Properties.ShowFooter = false;
            this.cboDtlSupplier.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDtlSupplier.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboDtlSupplier.Properties.View = this.grvCboSupplier;
            this.cboDtlSupplier.ReadOnly = true;
            this.cboDtlSupplier.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboDtlSupplier.Properties.Appearance.Options.UseBackColor = true;
            this.cboDtlSupplier.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboDtlSupplier.Properties.Appearance.Options.UseFont = true;
            this.cboDtlSupplier.TabStop = false;
            #endregion

            #region cboDtlStatus
            //
            // colCboDtlStatusCode
            //
            this.colCboDtlStatusCode = new GridColumn();
            this.colCboDtlStatusCode.Caption = "Mã quầy thu ngân";
            this.colCboDtlStatusCode.FieldName = "StatusCode";
            this.colCboDtlStatusCode.Name = "colCboStatusCode";
            this.colCboDtlStatusCode.Visible = false;
            //this.colCboDtlStatusCode.VisibleIndex = -1;
            //
            // colCboDtlStatusName
            //
            this.colCboDtlStatusName = new GridColumn();
            this.colCboDtlStatusName.Caption = "Tình trạng";
            this.colCboDtlStatusName.FieldName = "StatusName";
            this.colCboDtlStatusName.Name = "colCboStatusName";
            this.colCboDtlStatusName.Visible = true;
            this.colCboDtlStatusName.VisibleIndex = 0;
            // 
            // grvCboDtlStatus
            // 
            this.grvCboDtlStatus = new GridView();
            this.grvCboDtlStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboDtlStatusCode,
                this.colCboDtlStatusName});
            this.grvCboDtlStatus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboDtlStatus.Name = "grvCboStatus";
            this.grvCboDtlStatus.OptionsBehavior.Editable = false;
            this.grvCboDtlStatus.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboDtlStatus.OptionsView.ShowAutoFilterRow = true;
            this.grvCboDtlStatus.OptionsView.ShowGroupPanel = false;
            this.grvCboDtlStatus.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboDtlStatus.Appearance.Row.Options.UseFont = true;
            this.grvCboDtlStatus.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboDtlStatus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboDtlStatus.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboDtlStatus.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboDtlStatus.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboDtlStatus
            // 
            this.cboDtlStatus.Name = "cboDtlStatus";
            this.cboDtlStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStatus.Properties.Appearance.Options.UseFont = true;
            this.cboDtlStatus.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDtlStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDtlStatus.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStatus.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDtlStatus.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboDtlStatus.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDtlStatus.Properties.NullText = "";
            this.cboDtlStatus.Properties.ShowFooter = false;
            this.cboDtlStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDtlStatus.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboDtlStatus.Properties.View = this.grvCboDtlStatus;
            this.cboDtlStatus.ReadOnly = true;
            this.cboDtlStatus.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboDtlStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboDtlStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboDtlStatus.Properties.Appearance.Options.UseFont = true;
            this.cboDtlStatus.TabStop = false;
            #endregion
        }

        /// <summary>
        /// Design lưới dữ liệu
        /// </summary>
        private void DesignGridview()
        {
            #region colProductID
            colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductID.AppearanceCell.Options.UseFont = true;
            colProductID.Caption = "ID Món hàng";
            colProductID.FieldName = "ProductID";
            colProductID.Name = "colProductID";
            colProductID.Visible = false;
            //colProductID.VisibleIndex = -1;
            colProductID.Width = 80;
            #endregion

            #region colProductCode
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductCode.AppearanceCell.Options.UseFont = true;
            colProductCode.Caption = "Mã hàng";
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 0;
            colProductCode.Width = 120;
            #endregion

            #region colProductDesc
            colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductDesc.AppearanceCell.Options.UseFont = true;
            colProductDesc.Caption = "Tên hàng";
            colProductDesc.FieldName = "ProductDesc";
            colProductDesc.Name = "colProductDesc";
            colProductDesc.Visible = true;
            colProductDesc.VisibleIndex = 1;
            colProductDesc.Width = 200;
            #endregion

            #region colDescriptions
            colDescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescriptions.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDescriptions.AppearanceCell.Options.UseFont = true;
            colDescriptions.Caption = "Mô tả";
            colDescriptions.FieldName = "Descriptions";
            colDescriptions.Name = "colDescriptions";
            colDescriptions.Visible = true;
            colDescriptions.VisibleIndex = 2;
            colDescriptions.Width = 200;
            #endregion

            #region colProductTypeID
            colProductTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductTypeID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductTypeID.AppearanceCell.Options.UseFont = true;
            colProductTypeID.Caption = "ID Loại hàng";
            colProductTypeID.FieldName = "ProductTypeID";
            colProductTypeID.Name = "colProductTypeID";
            colProductTypeID.Visible = false;
            //colProductTypeID.VisibleIndex = -1;
            colProductTypeID.Width = 80;
            #endregion

            #region colProductTypeCode
            colProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductTypeCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductTypeCode.AppearanceCell.Options.UseFont = true;
            colProductTypeCode.Caption = "Mã Loại hàng";
            colProductTypeCode.FieldName = "ProductTypeCode";
            colProductTypeCode.Name = "colProductTypeCode";
            colProductTypeCode.Visible = false;
            //colProductTypeCode.VisibleIndex = -1;
            colProductTypeCode.Width = 120;
            #endregion

            #region colProductTypeName
            colProductTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductTypeName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductTypeName.AppearanceCell.Options.UseFont = true;
            colProductTypeName.Caption = "Loại hàng";
            colProductTypeName.FieldName = "ProductTypeName";
            colProductTypeName.Name = "colProductTypeName";
            colProductTypeName.Visible = true;
            colProductTypeName.VisibleIndex = 3;
            colProductTypeName.Width = 150;
            #endregion

            #region colProductGroupID
            colProductGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductGroupID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductGroupID.AppearanceCell.Options.UseFont = true;
            colProductGroupID.Caption = "ID Nhóm hàng";
            colProductGroupID.FieldName = "ProductGroupID";
            colProductGroupID.Name = "colProductGroupID";
            colProductGroupID.Visible = false;
            //colProductGroupID.VisibleIndex = -1;
            colProductGroupID.Width = 80;
            #endregion

            #region colProductGroupCode
            colProductGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductGroupCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductGroupCode.AppearanceCell.Options.UseFont = true;
            colProductGroupCode.Caption = "Mã Nhóm hàng";
            colProductGroupCode.FieldName = "ProductGroupCode";
            colProductGroupCode.Name = "colProductGroupCode";
            colProductGroupCode.Visible = false;
            //colProductGroupCode.VisibleIndex = -1;
            colProductGroupCode.Width = 120;
            #endregion

            #region colProductGroupName
            colProductGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductGroupName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductGroupName.AppearanceCell.Options.UseFont = true;
            colProductGroupName.Caption = "Nhóm hàng";
            colProductGroupName.FieldName = "ProductGroupName";
            colProductGroupName.Name = "colProductGroupName";
            colProductGroupName.Visible = true;
            colProductGroupName.VisibleIndex = 4;
            colProductGroupName.Width = 150;
            #endregion

            #region colUnitWeightID
            colUnitWeightID = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitWeightID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitWeightID.AppearanceCell.Options.UseFont = true;
            colUnitWeightID.Caption = "ID Đơn vị cân";
            colUnitWeightID.FieldName = "UnitWeightID";
            colUnitWeightID.Name = "colUnitWeightID";
            colUnitWeightID.Visible = false;
            //colUnitWeightID.VisibleIndex = -1;
            colUnitWeightID.Width = 80;
            #endregion

            #region colUnitWeightCode
            colUnitWeightCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitWeightCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitWeightCode.AppearanceCell.Options.UseFont = true;
            colUnitWeightCode.Caption = "Mã đơn vị cân";
            colUnitWeightCode.FieldName = "UnitWeightCode";
            colUnitWeightCode.Name = "colUnitWeightCode";
            colUnitWeightID.Visible = false;
            //colUnitWeightID.VisibleIndex = -1;
            colUnitWeightID.Width = 80;
            #endregion

            #region colUnitWeightDesc
            colUnitWeightDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitWeightDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitWeightDesc.AppearanceCell.Options.UseFont = true;
            colUnitWeightDesc.Caption = "Đơn vị cân";
            colUnitWeightDesc.FieldName = "UnitWeightDesc";
            colUnitWeightDesc.Name = "colUnitWeightDesc";
            colUnitWeightDesc.Visible = true;
            colUnitWeightDesc.VisibleIndex = 5;
            colUnitWeightDesc.Width = 150;
            #endregion

            #region colUnitSellID
            colUnitSellID = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitSellID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitSellID.AppearanceCell.Options.UseFont = true;
            colUnitSellID.Caption = "ID Đơn vị bán";
            colUnitSellID.FieldName = "UnitSellID";
            colUnitSellID.Name = "colUnitSellID";
            colUnitSellID.Visible = false;
            //colUnitSellID.VisibleIndex = -1;
            colUnitSellID.Width = 80;
            #endregion

            #region colUnitSellCode
            colUnitSellCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitSellCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitSellCode.AppearanceCell.Options.UseFont = true;
            colUnitSellCode.Caption = "Mã đơn vị bán";
            colUnitSellCode.FieldName = "UnitSellCode";
            colUnitSellCode.Name = "colUnitSellCode";
            colUnitSellID.Visible = false;
            //colUnitSellID.VisibleIndex = -1;
            colUnitSellID.Width = 80;
            #endregion

            #region colUnitSellDesc
            colUnitSellDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitSellDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitSellDesc.AppearanceCell.Options.UseFont = true;
            colUnitSellDesc.Caption = "Đơn vị bán";
            colUnitSellDesc.FieldName = "UnitSellDesc";
            colUnitSellDesc.Name = "colUnitSellDesc";
            colUnitSellDesc.Visible = true;
            colUnitSellDesc.VisibleIndex = 6;
            colUnitSellDesc.Width = 150;
            #endregion

            #region colSupplierID
            colSupplierID = new DevExpress.XtraGrid.Columns.GridColumn();
            colSupplierID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colSupplierID.AppearanceCell.Options.UseFont = true;
            colSupplierID.Caption = "ID Nhà cung cấp";
            colSupplierID.FieldName = "SupplierID";
            colSupplierID.Name = "colSupplierID";
            colSupplierID.Visible = false;
            //colSupplierID.VisibleIndex = -1;
            colSupplierID.Width = 80;
            #endregion

            #region colSupplierCode
            colSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colSupplierCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colSupplierCode.AppearanceCell.Options.UseFont = true;
            colSupplierCode.Caption = "Mã Nhà cung cấp";
            colSupplierCode.FieldName = "SupplierCode";
            colSupplierCode.Name = "colSupplierCode";
            colSupplierCode.Visible = false;
            //colSupplierCode.VisibleIndex = -1;
            colSupplierCode.Width = 120;
            #endregion

            #region colSupplierName
            colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSupplierName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colSupplierName.AppearanceCell.Options.UseFont = true;
            colSupplierName.Caption = "Nhà cung cấp";
            colSupplierName.FieldName = "SupplierName";
            colSupplierName.Name = "colSupplierName";
            colSupplierName.Visible = true;
            colSupplierName.VisibleIndex = 7;
            colSupplierName.Width = 150;
            #endregion

            #region colStatusCode
            colStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatusCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStatusCode.AppearanceCell.Options.UseFont = true;
            colStatusCode.Caption = "Mã tình trạng";
            colStatusCode.FieldName = "StatusCode";
            colStatusCode.Name = "colStatusCode";
            colSupplierCode.Visible = false;
            //colSupplierCode.VisibleIndex = -1;
            colSupplierCode.Width = 120;
            #endregion

            #region colStatusName
            colStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatusName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStatusName.AppearanceCell.Options.UseFont = true;
            colStatusName.Caption = "Tình trạng";
            colStatusName.FieldName = "StatusName";
            colStatusName.Name = "colStatusName";
            colStatusName.Visible = true;
            colStatusName.VisibleIndex = 8;
            colStatusName.Width = 100;
            #endregion

            #region colStallsID
            colStallsID = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsID.AppearanceCell.Options.UseFont = true;
            colStallsID.Caption = "ID Quầy/Kho";
            colStallsID.FieldName = "StallsID";
            colStallsID.Name = "colStallsID";
            colStallsID.Visible = false;
            //colStallsID.VisibleIndex = -1;
            colStallsID.Width = 80;
            #endregion

            #region colStallsCode
            colStallsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsCode.AppearanceCell.Options.UseFont = true;
            colStallsCode.Caption = "Mã Quầy/kho";
            colStallsCode.FieldName = "StallsCode";
            colStallsCode.Name = "colStallsCode";
            colStallsCode.Visible = false;
            //colStallsCode.VisibleIndex = -1;
            colStallsCode.Width = 120;
            #endregion

            #region colStallsName
            colStallsName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsName.AppearanceCell.Options.UseFont = true;
            colStallsName.Caption = "Quầy/kho";
            colStallsName.FieldName = "StallsName";
            colStallsName.Name = "colStallsName";
            colStallsName.Visible = true;
            colStallsName.VisibleIndex = 9;
            colStallsName.Width = 120;
            #endregion

            #region colQuantity
            colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantity.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colQuantity.AppearanceCell.Options.UseFont = true;
            colQuantity.DisplayFormat.FormatString = "{0:#,##0}";
            colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQuantity.Caption = "Số lượng";
            colQuantity.FieldName = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.Visible = true;
            colQuantity.VisibleIndex = 10;
            colQuantity.Width = 100;
            #endregion

            #region colQuantityReal
            colQuantityReal = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantityReal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colQuantityReal.AppearanceCell.Options.UseFont = true;
            colQuantityReal.DisplayFormat.FormatString = "{0:#,##0}";
            colQuantityReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQuantityReal.Caption = "Số lượng thực";
            colQuantityReal.FieldName = "QuantityReal";
            colQuantityReal.Name = "colQuantityReal";
            colQuantityReal.Visible = true;
            colQuantityReal.VisibleIndex = 11;
            colQuantityReal.Width = 150;
            #endregion

            #region colWeights
            colWeights = new DevExpress.XtraGrid.Columns.GridColumn();
            colWeights.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colWeights.AppearanceCell.Options.UseFont = true;
            colWeights.DisplayFormat.FormatString = "{0:#,##0.00}";
            colWeights.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colWeights.Caption = "Trọng lượng";
            colWeights.FieldName = "Weights";
            colWeights.Name = "colWeights";
            colWeights.Visible = true;
            colWeights.VisibleIndex = 12;
            colWeights.Width = 150;
            #endregion

            #region colWeightsReal
            colWeightsReal = new DevExpress.XtraGrid.Columns.GridColumn();
            colWeightsReal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colWeightsReal.AppearanceCell.Options.UseFont = true;
            colWeightsReal.DisplayFormat.FormatString = "{0:#,##0.00}";
            colWeightsReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colWeightsReal.Caption = "Trọng lượng thực";
            colWeightsReal.FieldName = "WeightsReal";
            colWeightsReal.Name = "colWeightsReal";
            colWeightsReal.Visible = true;
            colWeightsReal.VisibleIndex = 13;
            colWeightsReal.Width = 150;
            #endregion

            #region colRateIn
            colRateIn = new DevExpress.XtraGrid.Columns.GridColumn();
            colRateIn.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colRateIn.AppearanceCell.Options.UseFont = true;
            colRateIn.DisplayFormat.FormatString = "{0:#,##0}";
            colRateIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRateIn.Caption = "Giá nhập";
            colRateIn.FieldName = "RateIn";
            colRateIn.Name = "colRateIn";
            colRateIn.Visible = true;
            colRateIn.VisibleIndex = 14;
            colRateIn.Width = 150;
            #endregion

            #region colRateEstimate
            colRateEstimate = new DevExpress.XtraGrid.Columns.GridColumn();
            colRateEstimate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colRateEstimate.AppearanceCell.Options.UseFont = true;
            colRateEstimate.DisplayFormat.FormatString = "{0:#,##0}";
            colRateEstimate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRateEstimate.Caption = "Giá gốc";
            colRateEstimate.FieldName = "RateEstimate";
            colRateEstimate.Name = "colRateEstimate";
            colRateEstimate.Visible = true;
            colRateEstimate.VisibleIndex = 15;
            colRateEstimate.Width = 150;
            #endregion

            #region colDiscountPercent
            colDiscountPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountPercent.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDiscountPercent.AppearanceCell.Options.UseFont = true;
            colDiscountPercent.DisplayFormat.FormatString = "{0:#,##0.00}";
            colDiscountPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiscountPercent.Caption = "Giảm giá (%)";
            colDiscountPercent.FieldName = "DiscountPercent";
            colDiscountPercent.Name = "colDiscountPercent";
            colDiscountPercent.Visible = true;
            colDiscountPercent.VisibleIndex = 16;
            colDiscountPercent.Width = 150;
            #endregion

            #region colDiscount
            colDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscount.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDiscount.AppearanceCell.Options.UseFont = true;
            colDiscount.DisplayFormat.FormatString = "{0:#,##0}";
            colDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiscount.Caption = "Tiền giảm";
            colDiscount.FieldName = "Discount";
            colDiscount.Name = "colDiscount";
            colDiscount.Visible = true;
            colDiscount.VisibleIndex = 17;
            colDiscount.Width = 150;
            #endregion

            #region colDiscountTotal
            colDiscountTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountTotal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDiscountTotal.AppearanceCell.Options.UseFont = true;
            colDiscountTotal.DisplayFormat.FormatString = "{0:#,##0}";
            colDiscountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiscountTotal.Caption = "Tổng tiền giảm";
            colDiscountTotal.FieldName = "DiscountTotal";
            colDiscountTotal.Name = "colDiscountTotal";
            colDiscountTotal.Visible = true;
            colDiscountTotal.VisibleIndex = 18;
            colDiscountTotal.Width = 150;
            #endregion

            #region colRateSell
            colRateSell = new DevExpress.XtraGrid.Columns.GridColumn();
            colRateSell.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colRateSell.AppearanceCell.Options.UseFont = true;
            colRateSell.DisplayFormat.FormatString = "{0:#,##0}";
            colRateSell.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colRateSell.Caption = "Giá bán";
            colRateSell.FieldName = "RateSell";
            colRateSell.Name = "colRateSell";
            colRateSell.Visible = true;
            colRateSell.VisibleIndex = 19;
            colRateSell.Width = 150;
            #endregion

            #region colUpdateDate
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUpdateDate.AppearanceCell.Options.UseFont = true;
            colUpdateDate.Caption = "Ngày cập nhật";
            colUpdateDate.FieldName = "UpdateDate";
            colUpdateDate.Name = "colUpdateDate";
            colUpdateDate.Visible = false;
            //colUpdateDate.VisibleIndex = -1;
            colUpdateDate.Width = 100;
            #endregion

            #region colUpdateBy
            colUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateBy.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUpdateBy.AppearanceCell.Options.UseFont = true;
            colUpdateBy.Caption = "User cập nhật";
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.Name = "colUpdateBy";
            colUpdateDate.Visible = false;
            //colUpdateDate.VisibleIndex = -1;
            colUpdateDate.Width = 100;
            #endregion

            #region colUserUpdate
            colUserUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUserUpdate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUserUpdate.AppearanceCell.Options.UseFont = true;
            colUserUpdate.Caption = "User cập nhật";
            colUserUpdate.FieldName = "UserUpdate";
            colUserUpdate.Name = "colUserUpdate";
            colUpdateDate.Visible = false;
            //colUpdateDate.VisibleIndex = -1;
            colUpdateDate.Width = 100;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvQueryProduct.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvQueryProduct.OptionsBehavior.Editable = false;
            // Hiển thị filter
            grvQueryProduct.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvQueryProduct.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvQueryProduct.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvQueryProduct.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvQueryProduct.Appearance.HeaderPanel.Options.UseFont = true;
            grvQueryProduct.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvQueryProduct.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvQueryProduct.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            grvQueryProduct.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvQueryProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colProductID,
                colProductCode,
                colProductDesc,
                colDescriptions,
                colProductTypeID,
                colProductTypeCode,
                colProductTypeName,
                colProductGroupID,
                colProductGroupCode,
                colProductGroupName,
                colUnitWeightID,
                colUnitWeightCode,
                colUnitWeightDesc,
                colUnitSellID,
                colUnitSellCode,
                colUnitSellDesc,
                colSupplierID,
                colSupplierCode,
                colSupplierName,
                colStatusCode,
                colStatusName,
                colStallsID,
                colStallsCode,
                colStallsName,
                colQuantity,
                colQuantityReal,
                colWeights,
                colWeightsReal,
                colRateIn,
                colRateEstimate,
                colDiscountPercent,
                colDiscount,
                colDiscountTotal,
                colRateSell,
                colUpdateDate,
                colUpdateBy,
                colUserUpdate
            });
            this.grvQueryProduct.Click += new System.EventHandler(this.grvQueryProduct_Click);
            #endregion
        }
        #endregion

        #region Functions
        /// <summary>
        /// Khởi tạo datasource cho lưới dữ liệu
        /// </summary>
        /// <returns>Datasource</returns>
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("DataSource");
            tblInit.Columns.Add("ProductID", typeof(Int64));
            tblInit.Columns.Add("ProductCode", typeof(string));
            tblInit.Columns.Add("ProductDesc", typeof(string));
            tblInit.Columns.Add("Descriptions", typeof(string));
            tblInit.Columns.Add("ProductTypeID", typeof(Int64));
            tblInit.Columns.Add("ProductTypeCode", typeof(string));
            tblInit.Columns.Add("ProductTypeName", typeof(string));
            tblInit.Columns.Add("ProductGroupID", typeof(Int64));
            tblInit.Columns.Add("ProductGroupCode", typeof(string));
            tblInit.Columns.Add("ProductGroupName", typeof(string));
            tblInit.Columns.Add("UnitWeightID", typeof(Int64));
            tblInit.Columns.Add("UnitWeightCode", typeof(string));
            tblInit.Columns.Add("UnitWeightDesc", typeof(string));
            tblInit.Columns.Add("UnitSellID", typeof(Int64));
            tblInit.Columns.Add("UnitSellCode", typeof(string));
            tblInit.Columns.Add("UnitSellDesc", typeof(string));
            tblInit.Columns.Add("SupplierID", typeof(Int64));
            tblInit.Columns.Add("SupplierCode", typeof(string));
            tblInit.Columns.Add("SupplierName", typeof(string));
            tblInit.Columns.Add("StatusCode", typeof(string));
            tblInit.Columns.Add("StatusName", typeof(string));
            tblInit.Columns.Add("StallsID", typeof(Int64));
            tblInit.Columns.Add("StallsCode", typeof(string));
            tblInit.Columns.Add("StallsName", typeof(string));
            tblInit.Columns.Add("Quantity", typeof(int));
            tblInit.Columns.Add("QuantityReal", typeof(int));
            tblInit.Columns.Add("Weights", typeof(decimal));
            tblInit.Columns.Add("WeightsReal", typeof(decimal));
            tblInit.Columns.Add("RateIn", typeof(decimal));
            tblInit.Columns.Add("RateEstimate", typeof(decimal));
            tblInit.Columns.Add("DiscountPercent", typeof(decimal));
            tblInit.Columns.Add("Discount", typeof(decimal));
            tblInit.Columns.Add("DiscountTotal", typeof(decimal));
            tblInit.Columns.Add("RateSell", typeof(decimal));
            tblInit.Columns.Add("UpdateDate", typeof(DateTime));
            tblInit.Columns.Add("UpdateBy", typeof(Int64));
            tblInit.Columns.Add("UserUpdate", typeof(string));
            return tblInit;
        }

        /// <summary>
        /// Load dữ liêu lên DropDownList
        /// </summary>
        private void LoadDataToDropDownList()
        {
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatStalls.LoadDataCombobox(DTOAttributeSystem.CurrentShop.ID, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboDtlStalls.Properties.DataSource = ds.Tables[0].Copy();
                    cboDtlStalls.Properties.DisplayMember = "StallsName";
                    cboDtlStalls.Properties.ValueMember = "StallsID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLSysStatus.LoadDataCombobox("STATUS_OBJ_PRODUCT", out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    DataTable dt = ds.Tables[0].Copy();
                    DataRow dr = dt.NewRow();
                    dr["StatusCode"] = string.Empty;
                    dr["StatusName"] = string.Empty;
                    dt.Rows.Add(dr);
                    cboDtlStatus.Properties.DataSource = dt;
                    cboDtlStatus.Properties.DisplayMember = "StatusName";
                    cboDtlStatus.Properties.ValueMember = "StatusCode";
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
                    cboDtlProductType.Properties.DataSource = ds.Tables[0].Copy();
                    cboDtlProductType.Properties.DisplayMember = "ProductTypeName";
                    cboDtlProductType.Properties.ValueMember = "ProductTypeID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatProductGroup.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboDtlProductGroup.Properties.DataSource = ds.Tables[0].Copy();
                    cboDtlProductGroup.Properties.DisplayMember = "ProductGroupName";
                    cboDtlProductGroup.Properties.ValueMember = "ProductGroupID";
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
                    cboDtlSupplier.Properties.DataSource = ds.Tables[0].Copy();
                    cboDtlSupplier.Properties.DisplayMember = "SupplierName";
                    cboDtlSupplier.Properties.ValueMember = "SupplierID";
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
        /// Load dữ liệu lên lưới
        /// </summary>
        private void LoadDataToGrid(long _StallsID, string _StatusCode)
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                ds = BLLProduct.Product_GetStock(_StallsID, _StatusCode, out sMessage);
                grcQueryProduct.DataSource = ds.Tables[0].Copy();
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
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadDefault()
        {
            try
            {
                txtDtlProductCode.EditValue = string.Empty;
                txtDtlProductDesc.EditValue = string.Empty;
                txtDtlDescriptions.EditValue = string.Empty;
                cboDtlProductType.EditValue = -1;
                cboDtlProductGroup.EditValue = -1;
                cboDtlStalls.EditValue = -1;
                cboDtlSupplier.EditValue = -1;
                txtDtlQuantity.EditValue = 0;
                txtDtlQuantityReal.EditValue = 0;
                txtDtlWeights.EditValue = 0;
                txtDtlWeightsReal.EditValue = 0;
                txtRateIn.EditValue = 0;
                txtDiscount.EditValue = 0;
                txtDiscountPercent.EditValue = 0;
                cboDtlStatus.EditValue = string.Empty;
                UpdateDataControlsRate();
                grcQueryProduct.DataSource = InitDataSourceGrid();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Cập nhật giá trị cho các controls giá
        /// </summary>
        private void UpdateDataControlsRate()
        {
            decimal dRateIn = txtRateIn.EditValue == null ? 0M : Convert.ToDecimal(txtRateIn.EditValue);
            txtRateEstimate.EditValue = FuncCalculate.CalcRateEstimate(dRateIn, 20);

            decimal dRateEstimate = txtRateEstimate.EditValue == null ? 0M : Convert.ToDecimal(txtRateEstimate.EditValue);
            decimal dDiscountPercent = txtDiscountPercent.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountPercent.EditValue);
            txtDiscountPercentMoney.EditValue = FuncCalculate.CalcDiscountPercentMoney(dRateEstimate, dDiscountPercent);

            decimal dDiscount = txtDiscount.EditValue == null ? 0M : Convert.ToDecimal(txtDiscount.EditValue);
            decimal dDiscountPercentMoney = txtDiscountPercentMoney.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountPercentMoney.EditValue);
            txtDiscountTotal.EditValue = FuncCalculate.CalcDiscountTotalProduct(dDiscount, dDiscountPercentMoney);

            decimal dDiscountTotal = txtDiscountTotal.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTotal.EditValue);
            txtRateSell.EditValue = FuncCalculate.CalcRateSell(dRateEstimate, dDiscountTotal);
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        /// <param name="_TrnID">ID giao dịch</param>
        /// <param name="_Message">Thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SaveClick(DTOSysProductRate _ObjSysProductRate, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                bResult = BLLProduct.Product_UpdateRate(_ObjSysProductRate, out _Message);
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
            int idxFocused = grvQueryProduct.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                return;
            }
            string sMessage = string.Empty;
            DTOSysProductRate objSysProductRate = new DTOSysProductRate();
            objSysProductRate.ProductID = grvQueryProduct.GetFocusedRowCellValue(colProductID) == DBNull.Value ? -1 : Convert.ToInt64(grvQueryProduct.GetFocusedRowCellValue(colProductID));
            
            decimal dRateEstimate = grvQueryProduct.GetFocusedRowCellValue(colRateEstimate) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colRateEstimate));            
            objSysProductRate.RateEstimate = txtRateEstimate.EditValue == null ? dRateEstimate : Convert.ToDecimal(txtRateEstimate.EditValue);
            
            decimal dDiscountPercent = grvQueryProduct.GetFocusedRowCellValue(colDiscountPercent) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colDiscountPercent));            
            objSysProductRate.DiscountPercent = txtDiscountPercent.EditValue == null ? dDiscountPercent : Convert.ToDecimal(txtDiscountPercent.EditValue);

            decimal dDiscount = grvQueryProduct.GetFocusedRowCellValue(colDiscount) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colDiscount));
            objSysProductRate.Discount = txtDiscount.EditValue == null ? dDiscount : Convert.ToDecimal(txtDiscount.EditValue);

            decimal dDiscountTotal = grvQueryProduct.GetFocusedRowCellValue(colDiscountTotal) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colDiscountTotal));
            objSysProductRate.DiscountTotal = txtDiscountTotal.EditValue == null ? dDiscountTotal : Convert.ToDecimal(txtDiscountTotal.EditValue);

            decimal dRateSell = grvQueryProduct.GetFocusedRowCellValue(colRateSell) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colRateSell));
            objSysProductRate.RateSell = txtRateSell.EditValue == null ? dRateSell : Convert.ToDecimal(txtRateSell.EditValue);

            if (SaveClick(objSysProductRate, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.HandlerSuccess("Lưu"));
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

        #region Gridview
        private void grvQueryProduct_Click(object sender, EventArgs e)
        {
            int idxFocused = grvQueryProduct.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                return;
            }
            txtDtlProductCode.EditValue = grvQueryProduct.GetFocusedRowCellValue(colProductCode) == DBNull.Value ? string.Empty : Convert.ToString(grvQueryProduct.GetFocusedRowCellValue(colProductCode));
            txtDtlProductDesc.EditValue = grvQueryProduct.GetFocusedRowCellValue(colProductDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvQueryProduct.GetFocusedRowCellValue(colProductDesc));
            txtDtlDescriptions.EditValue = grvQueryProduct.GetFocusedRowCellValue(colDescriptions) == DBNull.Value ? string.Empty : Convert.ToString(grvQueryProduct.GetFocusedRowCellValue(colDescriptions));
            cboDtlProductType.EditValue = grvQueryProduct.GetFocusedRowCellValue(colProductTypeID) == DBNull.Value ? -1 : Convert.ToInt64(grvQueryProduct.GetFocusedRowCellValue(colProductTypeID));
            cboDtlProductGroup.EditValue = grvQueryProduct.GetFocusedRowCellValue(colProductGroupID) == DBNull.Value ? -1 : Convert.ToInt64(grvQueryProduct.GetFocusedRowCellValue(colProductGroupID));
            cboDtlStalls.EditValue = grvQueryProduct.GetFocusedRowCellValue(colStallsID) == DBNull.Value ? -1 : Convert.ToInt64(grvQueryProduct.GetFocusedRowCellValue(colStallsID));
            cboDtlSupplier.EditValue = grvQueryProduct.GetFocusedRowCellValue(colSupplierID) == DBNull.Value ? -1 : Convert.ToInt64(grvQueryProduct.GetFocusedRowCellValue(colSupplierID));
            txtDtlQuantity.EditValue = grvQueryProduct.GetFocusedRowCellValue(colQuantity) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colQuantity));
            txtDtlQuantityReal.EditValue = grvQueryProduct.GetFocusedRowCellValue(colQuantityReal) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colQuantityReal));
            txtDtlWeights.EditValue = grvQueryProduct.GetFocusedRowCellValue(colWeights) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colWeights));
            txtDtlWeightsReal.EditValue = grvQueryProduct.GetFocusedRowCellValue(colWeightsReal) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colWeightsReal));
            txtRateIn.EditValue = grvQueryProduct.GetFocusedRowCellValue(colRateIn) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colRateIn));
            txtRateEstimate.EditValue = grvQueryProduct.GetFocusedRowCellValue(colRateEstimate) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colRateEstimate));
            txtDiscount.EditValue = grvQueryProduct.GetFocusedRowCellValue(colDiscount) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colDiscount));
            //txtDiscountPercentMoney.EditValue = grvQueryProduct.GetFocusedRowCellValue(colRateIn) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colRateIn));
            txtDiscountPercent.EditValue = grvQueryProduct.GetFocusedRowCellValue(colDiscountPercent) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colDiscountPercent));
            txtDiscountTotal.EditValue = grvQueryProduct.GetFocusedRowCellValue(colDiscountTotal) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colDiscountTotal));
            txtRateSell.EditValue = grvQueryProduct.GetFocusedRowCellValue(colRateSell) == DBNull.Value ? 0M : Convert.ToDecimal(grvQueryProduct.GetFocusedRowCellValue(colRateSell));
            cboDtlStatus.EditValue = grvQueryProduct.GetFocusedRowCellValue(colStatusCode) == DBNull.Value ? string.Empty : Convert.ToString(grvQueryProduct.GetFocusedRowCellValue(colStatusCode));
            UpdateDataControlsRate();
        }
        #endregion

        #region TextEdit
        private void txtRateEstimate_EditValueChanged(object sender, EventArgs e)
        {
            int idxFocused = grvQueryProduct.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                VMHMessages.ShowWarning("Vui lòng chọn món hàng muốn cập nhật giá!");
            }

            decimal dRateEstimate = txtRateEstimate.EditValue == null ? 0M : Convert.ToDecimal(txtRateEstimate.EditValue);
            decimal dDiscountTotal = txtDiscountTotal.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTotal.EditValue);
            txtRateSell.EditValue = FuncCalculate.CalcRateSell(dRateEstimate, dDiscountTotal);
        }
        
        private void txtDiscountPercent_EditValueChanged(object sender, EventArgs e)
        {
            int idxFocused = grvQueryProduct.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                VMHMessages.ShowWarning("Vui lòng chọn món hàng muốn cập nhật giá!");
            }

            decimal dRateEstimate = txtRateEstimate.EditValue == null ? 0M : Convert.ToDecimal(txtRateEstimate.EditValue);
            decimal dDiscountPercent = txtDiscountPercent.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountPercent.EditValue);
            txtDiscountPercentMoney.EditValue = FuncCalculate.CalcDiscountPercentMoney(dRateEstimate, dDiscountPercent);

            decimal dDiscount = txtDiscount.EditValue == null ? 0M : Convert.ToDecimal(txtDiscount.EditValue);
            decimal dDiscountPercentMoney = txtDiscountPercentMoney.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountPercentMoney.EditValue);
            txtDiscountTotal.EditValue = FuncCalculate.CalcDiscountTotalProduct(dDiscount, dDiscountPercentMoney);
            
            decimal dDiscountTotal = txtDiscountTotal.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTotal.EditValue);
            txtRateSell.EditValue = FuncCalculate.CalcRateSell(dRateEstimate, dDiscountTotal);
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            int idxFocused = grvQueryProduct.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                VMHMessages.ShowWarning("Vui lòng chọn món hàng muốn cập nhật giá!");
            }
            decimal dDiscount = txtDiscount.EditValue == null ? 0M : Convert.ToDecimal(txtDiscount.EditValue);
            decimal dDiscountPercentMoney = txtDiscountPercentMoney.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountPercentMoney.EditValue);
            txtDiscountTotal.EditValue = FuncCalculate.CalcDiscountTotalProduct(dDiscount, dDiscountPercentMoney);
            
            decimal dRateEstimate = txtRateEstimate.EditValue == null ? 0M : Convert.ToDecimal(txtRateEstimate.EditValue);
            decimal dDiscountTotal = txtDiscountTotal.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTotal.EditValue);
            txtRateSell.EditValue = FuncCalculate.CalcRateSell(dRateEstimate, dDiscountTotal);
        }
        #endregion
    }
}