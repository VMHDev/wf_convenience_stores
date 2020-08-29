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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_BLL.BLLCategories;
using CRM_GUI.CRMUtility.Messages;
using CRM_DTO.DTOProduct;
using CRM_BLL.BLLProduct;
using CRM_DTO.CRMUtility;
using CRM_DTO.CRMFunctions;
using CRM_BLL.BLLSystem;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductInDtl : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private DTOTrnProductInDT ObjTrnProductInDT = null;
        private frmProductIn FrmProductIn = null;
        #endregion

        #region Form
        public frmProductInDtl()
        {
            InitializeComponent();
            DesignControls();
            ObjTrnProductInDT = null;
            FrmProductIn = null;
        }

        public frmProductInDtl(frmProductIn _Frm)
        {
            InitializeComponent();
            DesignControls();
            FrmProductIn = _Frm;
            ObjTrnProductInDT = null;
        }

        public frmProductInDtl(frmProductIn _Frm, DTOTrnProductInDT _TrnProductInDT)
        {
            InitializeComponent();
            DesignControls();
            FrmProductIn = _Frm;
            ObjTrnProductInDT = new DTOTrnProductInDT(_TrnProductInDT);
        }

        private void frmProductInDtl_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboSupplier
        public GridView grvCboSupplier { get; set; }
        public GridColumn colCboSupplierID { get; set; }
        public GridColumn colCboSupplierCode { get; set; }
        public GridColumn colCboSupplierName { get; set; }
        public GridColumn colCboSupplierAddress { get; set; }
        public GridColumn colCboSupplierPhone { get; set; }
        #endregion

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

        #region cboUnitWeight
        public GridView grvCboUnitWeight { get; set; }
        public GridColumn colCboUnitWeightID { get; set; }
        public GridColumn colCboUnitWeightCode { get; set; }
        public GridColumn colCboUnitWeightDesc { get; set; }
        #endregion

        #region cboUnitSell
        public GridView grvCboUnitSell { get; set; }
        public GridColumn colCboUnitSellID { get; set; }
        public GridColumn colCboUnitSellCode { get; set; }
        public GridColumn colCboUnitSellDesc { get; set; }
        #endregion

        #region cboUnitIn
        public GridView grvCboUnitIn { get; set; }
        public GridColumn colCboUnitInID { get; set; }
        public GridColumn colCboUnitInCode { get; set; }
        public GridColumn colCboUnitInDesc { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design giao diện
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Thông tin nhập hàng";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmProductInDtl_Load);
            #endregion

            DesignTextSpinEdit();
            DesignGridLookUpEdit();
        }

        /// <summary>
        /// Design TextSpinEdit
        /// </summary>
        private void DesignTextSpinEdit()
        {
            txtProductCode.ReadOnly = true;
            txtProductCode.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtProductCode.Properties.Appearance.Options.UseBackColor = true;
            txtProductCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            txtProductCode.Properties.Appearance.Options.UseFont = true;
            txtProductCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            txtProductCode.Properties.Appearance.Options.UseForeColor = true;
            txtProductCode.TabStop = false;

            txtWeight.Properties.DisplayFormat.FormatString = "#,##0.00";
            txtWeight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeight.Properties.EditFormat.FormatString = "#,##0.00";
            txtWeight.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeight.Properties.Mask.EditMask = "n2";
            txtWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtWeight.EditValueChanged += new System.EventHandler(this.txtWeight_EditValueChanged);

            txtQuantity.Properties.DisplayFormat.FormatString = "#,##0";
            txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantity.Properties.EditFormat.FormatString = "#,##0";
            txtQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantity.Properties.Mask.EditMask = "n0";
            txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtQuantity.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtQuantity.EditValueChanged += new System.EventHandler(this.txtQuantity_EditValueChanged);

            txtQuantityStockCalc.ReadOnly = true;
            txtQuantityStockCalc.Properties.DisplayFormat.FormatString = "#,##0";
            txtQuantityStockCalc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityStockCalc.Properties.EditFormat.FormatString = "#,##0";
            txtQuantityStockCalc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityStockCalc.Properties.Mask.EditMask = "n0";
            txtQuantityStockCalc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtQuantityStockCalc.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtQuantityStockCalc.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtQuantityStockCalc.Properties.Appearance.Options.UseBackColor = true;
            txtQuantityStockCalc.TabStop = false;

            txtRateIn.Properties.DisplayFormat.FormatString = "#,##0";
            txtRateIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateIn.Properties.EditFormat.FormatString = "#,##0";
            txtRateIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateIn.Properties.Mask.EditMask = "n0";
            txtRateIn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtRateIn.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtRateIn.EditValueChanged += new System.EventHandler(this.txtRateIn_EditValueChanged);

            txtRateSellEstimate.ReadOnly = true;
            txtRateSellEstimate.Properties.DisplayFormat.FormatString = "#,##0";
            txtRateSellEstimate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateSellEstimate.Properties.EditFormat.FormatString = "#,##0";
            txtRateSellEstimate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRateSellEstimate.Properties.Mask.EditMask = "n0";
            txtRateSellEstimate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtRateSellEstimate.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtRateSellEstimate.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtRateSellEstimate.Properties.Appearance.Options.UseBackColor = true;
            txtRateSellEstimate.TabStop = false;

            txtQuantity.Properties.DisplayFormat.FormatString = "#,##0";
            txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantity.Properties.EditFormat.FormatString = "#,##0";
            txtQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantity.Properties.Mask.EditMask = "n0";
            txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtQuantity.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
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
            this.cboSupplier.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboSupplier.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboSupplier.Properties.View = this.grvCboSupplier;
            #endregion

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
            this.cboProductType.EditValueChanged += new System.EventHandler(this.cboProductType_EditValueChanged);
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
            this.cboProductGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboProductGroup.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboProductGroup.Properties.View = this.grvCboProductGroup;
            #endregion

            #region cboUnitWeight
            //
            // colCboUnitWeightID
            //
            this.colCboUnitWeightID = new GridColumn();
            this.colCboUnitWeightID.Caption = "ID đơn vị";
            this.colCboUnitWeightID.FieldName = "UnitWeightID";
            this.colCboUnitWeightID.Name = "colCboUnitWeightID";
            this.colCboUnitWeightID.Visible = false;
            //this.colCboUnitWeightID.VisibleIndex = -1;
            //
            // colCboUnitWeightCode
            //
            this.colCboUnitWeightCode = new GridColumn();
            this.colCboUnitWeightCode.Caption = "Mã đơn vị";
            this.colCboUnitWeightCode.FieldName = "UnitWeightCode";
            this.colCboUnitWeightCode.Name = "colCboUnitWeightCode";
            this.colCboUnitWeightCode.Visible = true;
            this.colCboUnitWeightCode.VisibleIndex = 0;
            //
            // colCboUnitWeightDesc
            //
            this.colCboUnitWeightDesc = new GridColumn();
            this.colCboUnitWeightDesc.Caption = "Tên đơn vị";
            this.colCboUnitWeightDesc.FieldName = "UnitWeightDesc";
            this.colCboUnitWeightDesc.Name = "colCboUnitWeightDesc";
            this.colCboUnitWeightDesc.Visible = true;
            this.colCboUnitWeightDesc.VisibleIndex = 1;
            // 
            // grvCboUnitWeight
            // 
            this.grvCboUnitWeight = new GridView();
            this.grvCboUnitWeight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboUnitWeightID,
                this.colCboUnitWeightCode,
                this.colCboUnitWeightDesc});
            this.grvCboUnitWeight.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUnitWeight.Name = "grvCboUnitWeight";
            this.grvCboUnitWeight.OptionsBehavior.Editable = false;
            this.grvCboUnitWeight.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUnitWeight.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUnitWeight.OptionsView.ShowGroupPanel = false;
            this.grvCboUnitWeight.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitWeight.Appearance.Row.Options.UseFont = true;
            this.grvCboUnitWeight.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitWeight.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUnitWeight.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUnitWeight.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUnitWeight.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUnitWeight
            // 
            this.cboUnitWeight.Name = "cboUnitWeight";
            this.cboUnitWeight.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.Appearance.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUnitWeight.Properties.NullText = "";
            this.cboUnitWeight.Properties.ShowFooter = false;
            this.cboUnitWeight.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUnitWeight.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUnitWeight.Properties.View = this.grvCboUnitWeight;
            this.cboUnitWeight.EditValueChanged += new System.EventHandler(this.cboUnitWeight_EditValueChanged);
            #endregion

            #region cboUnitSell
            //
            // colCboUnitSellID
            //
            this.colCboUnitSellID = new GridColumn();
            this.colCboUnitSellID.Caption = "ID đơn vị";
            this.colCboUnitSellID.FieldName = "UnitSellID";
            this.colCboUnitSellID.Name = "colCboUnitSellID";
            this.colCboUnitSellID.Visible = false;
            //this.colCboUnitSellID.VisibleIndex = -1;
            //
            // colCboUnitSellCode
            //
            this.colCboUnitSellCode = new GridColumn();
            this.colCboUnitSellCode.Caption = "Mã đơn vị";
            this.colCboUnitSellCode.FieldName = "UnitSellCode";
            this.colCboUnitSellCode.Name = "colCboUnitSellCode";
            this.colCboUnitSellCode.Visible = true;
            this.colCboUnitSellCode.VisibleIndex = 0;
            //
            // colCboUnitSellDesc
            //
            this.colCboUnitSellDesc = new GridColumn();
            this.colCboUnitSellDesc.Caption = "Tên đơn vị";
            this.colCboUnitSellDesc.FieldName = "UnitSellDesc";
            this.colCboUnitSellDesc.Name = "colCboUnitSellDesc";
            this.colCboUnitSellDesc.Visible = true;
            this.colCboUnitSellDesc.VisibleIndex = 1;
            // 
            // grvCboUnitSell
            // 
            this.grvCboUnitSell = new GridView();
            this.grvCboUnitSell.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboUnitSellID,
                this.colCboUnitSellCode,
                this.colCboUnitSellDesc});
            this.grvCboUnitSell.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUnitSell.Name = "grvCboUnitSell";
            this.grvCboUnitSell.OptionsBehavior.Editable = false;
            this.grvCboUnitSell.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUnitSell.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUnitSell.OptionsView.ShowGroupPanel = false;
            this.grvCboUnitSell.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitSell.Appearance.Row.Options.UseFont = true;
            this.grvCboUnitSell.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitSell.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUnitSell.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUnitSell.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUnitSell.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUnitSell
            // 
            this.cboUnitSell.Name = "cboUnitSell";
            this.cboUnitSell.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.Appearance.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUnitSell.Properties.NullText = "";
            this.cboUnitSell.Properties.ShowFooter = false;
            this.cboUnitSell.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUnitSell.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUnitSell.Properties.View = this.grvCboUnitSell;
            #endregion

            #region cboUnitIn
            //
            // colCboUnitInID
            //
            this.colCboUnitInID = new GridColumn();
            this.colCboUnitInID.Caption = "ID đơn vị";
            this.colCboUnitInID.FieldName = "UnitInID";
            this.colCboUnitInID.Name = "colCboUnitInID";
            this.colCboUnitInID.Visible = false;
            //this.colCboUnitInID.VisibleIndex = -1;
            //
            // colCboUnitInCode
            //
            this.colCboUnitInCode = new GridColumn();
            this.colCboUnitInCode.Caption = "Mã đơn vị";
            this.colCboUnitInCode.FieldName = "UnitInCode";
            this.colCboUnitInCode.Name = "colCboUnitInCode";
            this.colCboUnitInCode.Visible = true;
            this.colCboUnitInCode.VisibleIndex = 0;
            //
            // colCboUnitInDesc
            //
            this.colCboUnitInDesc = new GridColumn();
            this.colCboUnitInDesc.Caption = "Tên đơn vị";
            this.colCboUnitInDesc.FieldName = "UnitInDesc";
            this.colCboUnitInDesc.Name = "colCboUnitInDesc";
            this.colCboUnitInDesc.Visible = true;
            this.colCboUnitInDesc.VisibleIndex = 1;
            // 
            // grvCboUnitIn
            // 
            this.grvCboUnitIn = new GridView();
            this.grvCboUnitIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboUnitInID,
                this.colCboUnitInCode,
                this.colCboUnitInDesc});
            this.grvCboUnitIn.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUnitIn.Name = "grvCboUnitIn";
            this.grvCboUnitIn.OptionsBehavior.Editable = false;
            this.grvCboUnitIn.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUnitIn.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUnitIn.OptionsView.ShowGroupPanel = false;
            this.grvCboUnitIn.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitIn.Appearance.Row.Options.UseFont = true;
            this.grvCboUnitIn.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitIn.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUnitIn.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUnitIn.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUnitIn.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUnitIn
            // 
            this.cboUnitIn.Name = "cboUnitIn";
            this.cboUnitIn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.Appearance.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUnitIn.Properties.NullText = "";
            this.cboUnitIn.Properties.ShowFooter = false;
            this.cboUnitIn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUnitIn.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUnitIn.Properties.View = this.grvCboUnitIn;
            this.cboUnitIn.EditValueChanged += new System.EventHandler(this.cboUnitIn_EditValueChanged);
            #endregion
        }
        #endregion

        #region Function
        /// <summary>
        /// Load dữ liêu lên DropDownList
        /// </summary>
        private void LoadDataToDropDownList()
        {
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
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
                ds = BLLCatUnitIn.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboUnitIn.Properties.DataSource = ds.Tables[0].Copy();
                    cboUnitIn.Properties.DisplayMember = "UnitInDesc";
                    cboUnitIn.Properties.ValueMember = "UnitInID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatUnitSell.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboUnitSell.Properties.DataSource = ds.Tables[0].Copy();
                    cboUnitSell.Properties.DisplayMember = "UnitSellDesc";
                    cboUnitSell.Properties.ValueMember = "UnitSellID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatUnitWeight.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboUnitWeight.Properties.DataSource = ds.Tables[0].Copy();
                    cboUnitWeight.Properties.DisplayMember = "UnitWeightDesc";
                    cboUnitWeight.Properties.ValueMember = "UnitWeightID";
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
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadDefault()
        {
            try
            {
                txtProductCode.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Product.ProductCode : "Tự động";
                txtRateSellEstimate.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.RateSell : 0;
                txtRateIn.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.RateIn : 0;
                txtQuantityStockCalc.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Quantity : 0;
                txtQuantity.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Quantity : 0;
                txtWeight.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.ProductWeight : 0;
                txtProductDesc.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Product.ProductDesc : string.Empty;
                txtDescriptions.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Product.Descriptions : string.Empty;

                cboProductGroup.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Product.ProductGroup.ID : cboProductGroup.Properties.GetKeyValue(2);
                cboProductType.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Product.ProductType.ID : cboProductType.Properties.GetKeyValue(2);
                cboSupplier.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.Supplier : cboSupplier.Properties.GetKeyValue(1);
                cboUnitIn.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.UnitIn : cboUnitIn.Properties.GetKeyValue(1);
                cboUnitSell.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.UnitSell : cboUnitSell.Properties.GetKeyValue(0); ;
                cboUnitWeight.EditValue = ObjTrnProductInDT != null ? ObjTrnProductInDT.UnitWeight : cboUnitWeight.Properties.GetKeyValue(0); ;
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu hợp lệ trước khi nhấn OK
        /// </summary>
        /// <returns>true: Hợp lệ | false: Không hợp lệ</returns>
        private bool IsValidOK()
        {
            string sProductDesc = txtProductDesc.EditValue == null ? string.Empty : Convert.ToString(txtProductDesc.EditValue);
            if (string.IsNullOrWhiteSpace(sProductDesc))
            {
                VMHMessages.ShowWarning("Vui lòng nhập tên hàng");
                return false;
            }
            long lSupplierID = cboSupplier.EditValue == null ? -1 : Convert.ToInt64(cboSupplier.EditValue);
            if (lSupplierID == -1)
            {
                VMHMessages.ShowWarning("Vui lòng chọn nhà cung cấp");
                return false;
            }
            long lProductTypeID = cboProductType.EditValue == null ? -1 : Convert.ToInt64(cboProductType.EditValue);
            if (lProductTypeID == -1)
            {
                VMHMessages.ShowWarning("Vui lòng chọn loại hàng");
                return false;
            }
            long lProductGroupID = cboProductGroup.EditValue == null ? -1 : Convert.ToInt64(cboProductGroup.EditValue);
            if (lProductGroupID == -1)
            {
                VMHMessages.ShowWarning("Vui lòng chọn nhóm hàng");
                return false;
            }
            long lUnitInID = cboUnitIn.EditValue == null ? -1 : Convert.ToInt64(cboUnitIn.EditValue);
            if (lProductTypeID == 1 && lUnitInID == -1)
            {
                VMHMessages.ShowWarning("Vui lòng chọn đơn vị nhập");
                return false;
            }
            long lUnitWeightID = cboUnitWeight.EditValue == null ? -1 : Convert.ToInt64(cboUnitWeight.EditValue);
            if (lProductTypeID == 2 && lUnitWeightID == -1)
            {
                VMHMessages.ShowWarning("Vui lòng chọn đơn vị cân");
                return false;
            }

            decimal lQuantity = txtQuantity.EditValue == null ? 0M : Convert.ToDecimal(txtQuantity.EditValue);
            if (lProductTypeID == 1 && lQuantity == 0M)
            {
                VMHMessages.ShowWarning("Vui lòng chọn số lượng nhập");
                return false;
            }
            decimal lWeight = txtWeight.EditValue == null ? 0M : Convert.ToDecimal(txtWeight.EditValue);
            if (lProductTypeID == 2 && lWeight == 0M)
            {
                VMHMessages.ShowWarning("Vui lòng chọn số trọng lượng");
                return false;
            }
            decimal lRateIn = txtRateIn.EditValue == null ? 0M : Convert.ToDecimal(txtRateIn.EditValue);
            if (-lRateIn == 0M)
            {
                VMHMessages.ShowWarning("Vui lòng chọn số trọng lượng");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Xong
        /// </summary>
        /// <param name="_TrnID"></param>
        /// <param name="_Message"></param>
        /// <returns></returns>
        private bool OKClick(out string _Message)
        {
            _Message = string.Empty;
            bool bResult = false;
            try
            {
                if (!IsValidOK())
                {
                    return false;
                }

                DataTable dtProductType = cboProductType.Properties.DataSource as DataTable;
                long lProductTypeID = cboProductType.EditValue == null ? -1 : Convert.ToInt64(cboProductType.EditValue);
                DataTable dtProductGroup = cboProductGroup.Properties.DataSource as DataTable;
                long lProductGroupID = cboProductGroup.EditValue == null ? -1 : Convert.ToInt64(cboProductGroup.EditValue);
                DataTable dtUnitWeight = cboUnitWeight.Properties.DataSource as DataTable;
                long lUnitWeightID = cboUnitWeight.EditValue == null ? -1 : Convert.ToInt64(cboUnitWeight.EditValue);
                DataTable dtUnitIn = cboUnitIn.Properties.DataSource as DataTable;
                long lUnitInID = cboUnitIn.EditValue == null ? -1 : Convert.ToInt64(cboUnitIn.EditValue);
                DataTable dtUnitSell = cboUnitSell.Properties.DataSource as DataTable;
                long lUnitSellID = cboUnitSell.EditValue == null ? -1 : Convert.ToInt64(cboUnitSell.EditValue);
                DataTable dtSupplier = cboSupplier.Properties.DataSource as DataTable;
                long lSupplierID = cboSupplier.EditValue == null ? -1 : Convert.ToInt64(cboSupplier.EditValue);

                DTOTrnProductInDT objectTrnProductInDT = new DTOTrnProductInDT();
                objectTrnProductInDT.TrnID = -1;
                objectTrnProductInDT.Product.ProductCode = string.Empty;
                objectTrnProductInDT.Product.ProductDesc = txtProductDesc.Text.Trim();
                objectTrnProductInDT.Product.ProductType.ID = lProductTypeID;
                objectTrnProductInDT.Product.ProductType.ProductTypeCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtProductType, "ProductTypeID", lProductTypeID, "ProductTypeCode"));
                objectTrnProductInDT.Product.ProductType.ProductTypeName = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtProductType, "ProductTypeID", lProductTypeID, "ProductTypeName"));
                objectTrnProductInDT.Product.ProductGroup.ID = lProductGroupID;
                objectTrnProductInDT.Product.ProductGroup.ProductGroupCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtProductGroup, "ProductGroupID", lProductGroupID, "ProductGroupCode"));
                objectTrnProductInDT.Product.ProductGroup.ProductGroupName = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtProductGroup, "ProductGroupID", lProductGroupID, "ProductGroupName"));
                objectTrnProductInDT.Product.ProductGroup.Descriptions = txtDescriptions.Text.Trim();
                objectTrnProductInDT.ProductWeight = txtWeight.EditValue == null ? 0 : Convert.ToDecimal(txtWeight.EditValue);
                objectTrnProductInDT.Quantity = txtQuantity.EditValue == null ? 0 : Convert.ToInt32(txtQuantity.EditValue);
                objectTrnProductInDT.UnitWeight.ID = lUnitWeightID;
                objectTrnProductInDT.UnitWeight.UnitWeightCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtUnitWeight, "UnitWeightID", lUnitWeightID, "UnitWeightCode"));
                objectTrnProductInDT.UnitWeight.UnitWeightDesc = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtUnitWeight, "UnitWeightID", lUnitWeightID, "UnitWeightDesc"));
                objectTrnProductInDT.UnitIn.ID = lUnitInID;
                objectTrnProductInDT.UnitIn.UnitInCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtUnitIn, "UnitInID", lUnitInID, "UnitInCode"));
                objectTrnProductInDT.UnitIn.UnitInDesc = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtUnitIn, "UnitInID", lUnitInID, "UnitInDesc"));
                objectTrnProductInDT.UnitSell.ID = lUnitSellID;
                objectTrnProductInDT.UnitSell.UnitSellCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtUnitSell, "UnitSellID", lUnitSellID, "UnitSellCode"));
                objectTrnProductInDT.UnitSell.UnitSellDesc = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtUnitSell, "UnitSellID", lUnitSellID, "UnitSellDesc"));
                objectTrnProductInDT.RateIn = txtRateIn.EditValue == null ? 0 : Convert.ToDecimal(txtRateIn.EditValue);
                objectTrnProductInDT.RateSell = txtRateSellEstimate.EditValue == null ? 0 : Convert.ToDecimal(txtRateSellEstimate.EditValue);
                objectTrnProductInDT.Supplier.ID = lSupplierID;
                objectTrnProductInDT.Supplier.SupplierCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtSupplier, "SupplierID", lSupplierID, "SupplierCode"));
                objectTrnProductInDT.Supplier.SupplierName = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtSupplier, "SupplierID", lSupplierID, "SupplierName"));
                FrmProductIn.AddItemDataSourceGrid(objectTrnProductInDT);
                bResult = true;
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Button
        private void btnOK_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (OKClick(out sMessage))
            {
                VMHMessages.ShowPopup(MessagesText.TextHandlerSuccess, 1000);
                LoadDefault();
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

        #region Combobox
        private void cboProductType_EditValueChanged(object sender, EventArgs e)
        {
            long lProductType = cboProductType.EditValue == null ? -1 : Convert.ToInt64(cboProductType.EditValue);
            if (lProductType == 1) // Hàng bán theo số lượng
            {
                txtQuantity.ReadOnly = false;
                txtQuantity.Properties.Appearance.Options.UseBackColor = false;
                txtQuantity.TabStop = true;

                txtWeight.ReadOnly = true;
                txtWeight.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                txtWeight.Properties.Appearance.Options.UseBackColor = true;
                txtWeight.TabStop = false;

                cboUnitIn.ReadOnly = false;
                cboUnitIn.Properties.Appearance.Options.UseBackColor = false;
                cboUnitIn.TabStop = true;

                cboUnitWeight.ReadOnly = true;
                cboUnitWeight.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                cboUnitWeight.Properties.Appearance.Options.UseBackColor = true;
                cboUnitWeight.TabStop = false;

                cboUnitSell.ReadOnly = false;
                cboUnitSell.Properties.Appearance.Options.UseBackColor = false;
                cboUnitSell.TabStop = true;
            }
            else if (lProductType == 2) // Hàng bán theo trọng lượng
            {
                txtQuantity.ReadOnly = true;
                txtQuantity.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                txtQuantity.Properties.Appearance.Options.UseBackColor = true;
                txtQuantity.TabStop = false;

                txtWeight.ReadOnly = false;
                txtWeight.Properties.Appearance.Options.UseBackColor = false;
                txtWeight.TabStop = true;

                cboUnitIn.ReadOnly = true;
                cboUnitIn.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                cboUnitIn.Properties.Appearance.Options.UseBackColor = true;
                cboUnitIn.TabStop = false;

                cboUnitWeight.ReadOnly = false;
                cboUnitWeight.Properties.Appearance.Options.UseBackColor = false;
                cboUnitWeight.TabStop = true;

                cboUnitSell.ReadOnly = true;
                cboUnitSell.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
                cboUnitSell.Properties.Appearance.Options.UseBackColor = true;
                cboUnitSell.TabStop = false;
            }
            else if (lProductType == -1)
            {
                VMHMessages.ShowWarning("Vui lòng chọn loại hàng!");
            }
            else
            {
                VMHMessages.ShowWarning("Loại hàng không hỗ trợ nhập hàng!");
            }
        }

        private void cboUnitWeight_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                long lProductType = cboProductType.EditValue == null ? -1 : Convert.ToInt64(cboProductType.EditValue);
                if (lProductType != 2)
                {
                    return;
                }

                DataTable dtUnitWeight = cboUnitWeight.Properties.DataSource as DataTable;
                long lUnitWeightID = cboUnitWeight.EditValue == null ? -1 : Convert.ToInt64(cboUnitWeight.EditValue);
                string sUnitWeightCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtUnitWeight, "UnitWeightID", lUnitWeightID, "UnitWeightCode"));

                DataTable dtUnitSell = cboUnitSell.Properties.DataSource as DataTable;
                var objUnitWeightID = FuncDropDownList.GetItemGridLookUp(dtUnitSell, "UnitSellCode", sUnitWeightCode, "UnitSellID");
                long lUnitSellID = objUnitWeightID == null ? -1 : Convert.ToInt64(objUnitWeightID);
                if (lUnitSellID == -1)
                {
                    VMHMessages.ShowWarning("Không lấy được dữ liệu!");
                    return;
                }
                cboUnitSell.EditValue = lUnitSellID;

                decimal dWeight = txtWeight.EditValue == null ? 0 : Convert.ToDecimal(txtWeight.EditValue);
                txtQuantityStockCalc.EditValue = dWeight;
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        private void cboUnitIn_EditValueChanged(object sender, EventArgs e)
        {
            long lProductType = cboProductType.EditValue == null ? -1 : Convert.ToInt64(cboProductType.EditValue);
            if (lProductType != 1)
            {
                return;
            }

            DataTable dtUnitIn = cboUnitIn.Properties.DataSource as DataTable;
            long lUnitInID = cboUnitIn.EditValue == null ? -1 : Convert.ToInt64(cboUnitIn.EditValue);
            decimal dScaleChange = Convert.ToDecimal(FuncDropDownList.GetItemGridLookUp(dtUnitIn, "UnitInID", lUnitInID, "ScaleChange"));

            decimal dQuantity = txtQuantity.EditValue == null ? 0 : Convert.ToDecimal(txtQuantity.EditValue);
            txtQuantityStockCalc.EditValue = dQuantity * dScaleChange;
        }
        #endregion

        #region TextEdit
        private void txtWeight_EditValueChanged(object sender, EventArgs e)
        {
            decimal dWeight = txtWeight.EditValue == null ? 0 : Convert.ToDecimal(txtWeight.EditValue);
            txtQuantityStockCalc.EditValue = dWeight;
        }

        private void txtQuantity_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtUnitIn = cboUnitIn.Properties.DataSource as DataTable;
            long lUnitInID = cboUnitIn.EditValue == null ? -1 : Convert.ToInt64(cboUnitIn.EditValue);
            decimal dScaleChange = Convert.ToDecimal(FuncDropDownList.GetItemGridLookUp(dtUnitIn, "UnitInID", lUnitInID, "ScaleChange"));

            decimal dQuantity = txtQuantity.EditValue == null ? 0 : Convert.ToDecimal(txtQuantity.EditValue);
            txtQuantityStockCalc.EditValue = dQuantity * dScaleChange;
        }

        private void txtRateIn_EditValueChanged(object sender, EventArgs e)
        {
            decimal dRateIn = txtRateIn.EditValue == null ? 0M : Convert.ToDecimal(txtRateIn.EditValue);
            txtRateSellEstimate.EditValue = FuncCalculate.CalcRateEstimate(dRateIn, 20);
        }
        #endregion
    }
}