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
using CRM_GUI.CRMFunctions;
using CRM_DTO.DTOCategories;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOSystem;
using CRM_DTO.CRMUtility;
using CRM_GUI.GUICounter;
using DevExpress.XtraEditors.Repository;
using CRM_BLL.BLLSystem;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductSellDtl : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public long gbTrnID = -1;
        /// <summary>Block sự kiện grvRTForeignCurrency_CellValueChanged khi thay đổi dữ liệu làm thay đổi dữ liệu khác trên lưới</summary>
        private bool gbLockCellChanged = false;
        /// <summary>Form ProductSell gọi Form ProductSellDtl</summary>
        public frmProductSell gbFrmProductSell = null;
        public DataTable gbDataSource { get; set; }
        public DTOTrnProductSell gbObjProductSell { get; set; }
        #endregion

        #region Form
        public frmProductSellDtl(frmProductSell _Frm, long _TrnID)
        {
            InitializeComponent();
            DesignControls();
            gbDataSource = InitDataSource().Copy();
            gbObjProductSell = new DTOTrnProductSell();
            gbFrmProductSell = _Frm;
            gbTrnID = _TrnID;
            LoadDataToDropDownList();            
        }

        private void frmProductSellDtl_Load(object sender, EventArgs e)
        {
            SetValueControlMoney();
            LoadDefault();
        }
        #endregion

        #region DesignControls
        #region Declare Controls
        #region cboCustomer
        public GridView grvCboCustomer { get; set; }
        public GridColumn colCustCode { get; set; }
        public GridColumn colCustName { get; set; }
        public GridColumn colCustAddress { get; set; }
        public GridColumn colPhone { get; set; }
        public GridColumn colIdentificationCard { get; set; }
        #endregion

        #region cboEmployee
        public GridView grvCboEmployee { get; set; }
        public GridColumn colCboEmpCode { get; set; }
        public GridColumn colCboEmpName { get; set; }
        public GridColumn colCboEmpShopName { get; set; }
        #endregion

        #region cboStatus
        public GridView grvCboStatus { get; set; }
        public GridColumn colCboStatusID { get; set; }
        public GridColumn colCboStatusCode { get; set; }
        public GridColumn colCboStatusName { get; set; }
        #endregion

        #region Gridview
        public GridColumn colTrnID { get; set; }
        public GridColumn colTrnCode { get; set; }
        public GridColumn colProductID { get; set; }
        public GridColumn colProductCode { get; set; }
        public GridColumn colProductDesc { get; set; }
        public GridColumn colDescriptions { get; set; }
        public GridColumn colStallsID { get; set; }
        public GridColumn colStallsCode { get; set; }
        public GridColumn colStallsName { get; set; }
        public GridColumn colProductTypeID { get; set; }
        public GridColumn colProductTypeCode { get; set; }
        public GridColumn colProductTypeName { get; set; }
        public GridColumn colProductGroupID { get; set; }
        public GridColumn colProductGroupCode { get; set; }
        public GridColumn colProductGroupName { get; set; }
        public GridColumn colSupplierID { get; set; }
        public GridColumn colSupplierCode { get; set; }
        public GridColumn colSupplierName { get; set; }
        public GridColumn colProductWeight { get; set; }
        public GridColumn colQuantity { get; set; }
        public GridColumn colUnitSellID { get; set; }
        public GridColumn colUnitSellCode { get; set; }
        public GridColumn colUnitSellDesc { get; set; }
        public GridColumn colRateIn { get; set; }
        public GridColumn colRateEstimate { get; set; }
        public GridColumn colDiscountPercent { get; set; }
        public GridColumn colDiscount { get; set; }
        public GridColumn colDiscountTotal { get; set; }
        public GridColumn colRateSell { get; set; }
        public GridColumn colAmount { get; set; }
        public GridColumn colNotes { get; set; }

        public RepositoryItemSpinEdit rtxtProductWeight { get; set; }
        public RepositoryItemSpinEdit rtxtQuantity { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            try
            {
                #region Form
                this.StartPosition = FormStartPosition.CenterParent;
                this.Text = "Bán hàng";
                this.Load += new System.EventHandler(this.frmProductSellDtl_Load);
                #endregion

                DesignTextSpinEdit();
                DesignDateTimeEdit();
                DesignGridLookUpEdit();
                DesignGridview();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
            #region cboCustomer
            //
            // colCustCode
            //
            this.colCustCode = new GridColumn();
            this.colCustCode.Caption = "Mã KH";
            this.colCustCode.FieldName = "CustCode";
            this.colCustCode.Name = "CustCode";
            this.colCustCode.Visible = true;
            this.colCustCode.VisibleIndex = 0;
            //
            // colCustName
            //
            this.colCustName = new GridColumn();
            this.colCustName.Caption = "Tên KH";
            this.colCustName.FieldName = "CustName";
            this.colCustName.Name = "colCustName";
            this.colCustName.Visible = true;
            this.colCustName.VisibleIndex = 1;
            // 
            // colCustAddress
            // 
            this.colCustAddress = new GridColumn();
            this.colCustAddress.Caption = "Địa chỉ";
            this.colCustAddress.FieldName = "CustAddress";
            this.colCustAddress.Name = "colCustAddress";
            this.colCustAddress.Visible = true;
            this.colCustAddress.VisibleIndex = 2;
            // 
            // colPhone
            // 
            this.colPhone = new GridColumn();
            this.colPhone.Caption = "Điện thoại";
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 3;
            // 
            // colIdentificationCard
            // 
            this.colIdentificationCard = new GridColumn();
            this.colIdentificationCard.Caption = "CMND";
            this.colIdentificationCard.FieldName = "IdentificationCard";
            this.colIdentificationCard.Name = "colIdentificationCard";
            this.colIdentificationCard.Visible = true;
            this.colIdentificationCard.VisibleIndex = 4;
            // 
            // grvCboCustomer
            // 
            this.grvCboCustomer = new GridView();
            this.grvCboCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustCode,
            this.colCustName,
            this.colCustAddress,
            this.colPhone,
            this.colIdentificationCard});
            this.grvCboCustomer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCustomer.Name = "grvCboCustomer";
            this.grvCboCustomer.OptionsBehavior.Editable = false;
            this.grvCboCustomer.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCustomer.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCustomer.OptionsView.ShowGroupPanel = false;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14F);
            this.cboCustomer.Properties.Appearance.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 14F);
            this.cboCustomer.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 14F);
            this.cboCustomer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 14F);
            this.cboCustomer.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 14F);
            this.cboCustomer.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCustomer.Properties.NullText = "";
            this.cboCustomer.Properties.ShowFooter = false;
            this.cboCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboEmployee.Properties.PopupFormSize = new System.Drawing.Size(1200, 0);
            this.cboCustomer.Properties.View = this.grvCboCustomer;
            this.cboCustomer.EditValueChanged += new System.EventHandler(this.cboCustomer_EditValueChanged);
            this.cboEmployee.TabStop = false;
            #endregion

            #region cboEmployee
            //
            // colCboEmpCode
            //
            this.colCboEmpCode = new GridColumn();
            this.colCboEmpCode.Caption = "Mã nhân viên";
            this.colCboEmpCode.FieldName = "EmpCode";
            this.colCboEmpCode.Name = "colCboEmpCode";
            this.colCboEmpCode.Visible = true;
            this.colCboEmpCode.VisibleIndex = 0;
            //
            // colCboEmpName
            //
            this.colCboEmpName = new GridColumn();
            this.colCboEmpName.Caption = "Tên nhân viên";
            this.colCboEmpName.FieldName = "EmpName";
            this.colCboEmpName.Name = "colCboEmpName";
            this.colCboEmpName.Visible = true;
            this.colCboEmpName.VisibleIndex = 1;
            // 
            // grvCboEmployee
            // 
            this.grvCboEmployee = new GridView();
            this.grvCboEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboEmpCode,
            this.colCboEmpName});
            this.grvCboEmployee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboEmployee.Name = "grvCboEmployee";
            this.grvCboEmployee.OptionsBehavior.Editable = false;
            this.grvCboEmployee.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboEmployee.OptionsView.ShowAutoFilterRow = true;
            this.grvCboEmployee.OptionsView.ShowGroupPanel = false;
            // 
            // cboEmployee
            // 
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Properties.Appearance.Font = new System.Drawing.Font("Arial", 14F);
            this.cboEmployee.Properties.Appearance.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 14F);
            this.cboEmployee.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 14F);
            this.cboEmployee.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 14F);
            this.cboEmployee.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 14F);
            this.cboEmployee.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboEmployee.Properties.NullText = "";
            this.cboEmployee.Properties.ShowFooter = false;
            this.cboEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboEmployee.Properties.PopupFormSize = new System.Drawing.Size(800, 0);
            this.cboEmployee.Properties.View = this.grvCboEmployee;
            this.cboEmployee.ReadOnly = true;
            this.cboEmployee.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboEmployee.Properties.Appearance.Options.UseBackColor = true;
            this.cboEmployee.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboEmployee.Properties.Appearance.Options.UseFont = true;
            this.cboEmployee.TabStop = false;
            #endregion

            #region cboStatus
            //
            // colCboStatusCode
            //
            this.colCboStatusCode = new GridColumn();
            this.colCboStatusCode.Caption = "Mã quầy thu ngân";
            this.colCboStatusCode.FieldName = "StatusCode";
            this.colCboStatusCode.Name = "colCboStatusCode";
            this.colCboStatusCode.Visible = false;
            //this.colCboStatusCode.VisibleIndex = -1;
            //
            // colCboStatusName
            //
            this.colCboStatusName = new GridColumn();
            this.colCboStatusName.Caption = "Tình trạng";
            this.colCboStatusName.FieldName = "StatusName";
            this.colCboStatusName.Name = "colCboStatusName";
            this.colCboStatusName.Visible = true;
            this.colCboStatusName.VisibleIndex = 0;
            // 
            // grvCboStatus
            // 
            this.grvCboStatus = new GridView();
            this.grvCboStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboStatusCode,
            this.colCboStatusName});
            this.grvCboStatus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboStatus.Name = "grvCboStatus";
            this.grvCboStatus.OptionsBehavior.Editable = false;
            this.grvCboStatus.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboStatus.OptionsView.ShowAutoFilterRow = true;
            this.grvCboStatus.OptionsView.ShowGroupPanel = false;
            this.grvCboStatus.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStatus.Appearance.Row.Options.UseFont = true;
            this.grvCboStatus.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStatus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboStatus.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboStatus.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboStatus.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboStatus
            // 
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboStatus.Properties.Appearance.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboStatus.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboStatus.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboStatus.Properties.NullText = "";
            this.cboStatus.Properties.ShowFooter = false;
            this.cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboStatus.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboStatus.Properties.View = this.grvCboStatus;
            //this.cboStatus.EditValueChanged += new System.EventHandler(this.cboStatus_EditValueChanged);
            this.cboStatus.ReadOnly = true;
            this.cboStatus.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboStatus.Properties.Appearance.Options.UseForeColor = true;
            this.cboStatus.TabStop = false;
            #endregion
        }

        /// <summary>
        /// Design TextSpinEdit
        /// </summary>
        private void DesignTextSpinEdit()
        {
            txtTrnCode.ReadOnly = true;
            txtTrnCode.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtTrnCode.Properties.Appearance.Options.UseBackColor = true;
            txtTrnCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            txtTrnCode.Properties.Appearance.Options.UseFont = true;
            txtTrnCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            txtTrnCode.Properties.Appearance.Options.UseForeColor = true;
            txtTrnCode.TabStop = false;

            txtAmountTotal.ReadOnly = true;
            txtAmountTotal.Properties.DisplayFormat.FormatString = "#,##0";
            txtAmountTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtAmountTotal.Properties.EditFormat.FormatString = "#,##0";
            txtAmountTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtAmountTotal.Properties.Mask.EditMask = "n0";
            txtAmountTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtAmountTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtAmountTotal.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtAmountTotal.Properties.Appearance.Options.UseBackColor = true;
            txtAmountTotal.TabStop = false;

            txtDiscountProduct.ReadOnly = true;
            txtDiscountProduct.Properties.DisplayFormat.FormatString = "#,##0";
            txtDiscountProduct.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountProduct.Properties.EditFormat.FormatString = "#,##0";
            txtDiscountProduct.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountProduct.Properties.Mask.EditMask = "n0";
            txtDiscountProduct.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDiscountProduct.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDiscountProduct.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDiscountProduct.Properties.Appearance.Options.UseBackColor = true;
            txtDiscountProduct.TabStop = false;

            txtDiscountTrn.Properties.DisplayFormat.FormatString = "#,##0";
            txtDiscountTrn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountTrn.Properties.EditFormat.FormatString = "#,##0";
            txtDiscountTrn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountTrn.Properties.Mask.EditMask = "n0";
            txtDiscountTrn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDiscountTrn.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDiscountTrn.Properties.MaxValue = 9999999999;
            txtDiscountTrn.Properties.MinValue = 0;
            this.txtDiscountTrn.EditValueChanged += new System.EventHandler(this.txtDiscountTrn_EditValueChanged);

            txtDiscountTotalTrn.ReadOnly = true;
            txtDiscountTotalTrn.Properties.DisplayFormat.FormatString = "#,##0";
            txtDiscountTotalTrn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountTotalTrn.Properties.EditFormat.FormatString = "#,##0";
            txtDiscountTotalTrn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtDiscountTotalTrn.Properties.Mask.EditMask = "n0";
            txtDiscountTotalTrn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDiscountTotalTrn.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtDiscountTotalTrn.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDiscountTotalTrn.Properties.Appearance.Options.UseBackColor = true;
            txtDiscountTotalTrn.TabStop = false;

            txtAmountPay.ReadOnly = true;
            txtAmountPay.Properties.DisplayFormat.FormatString = "#,##0";
            txtAmountPay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtAmountPay.Properties.EditFormat.FormatString = "#,##0";
            txtAmountPay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtAmountPay.Properties.Mask.EditMask = "n0";
            txtAmountPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtAmountPay.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtAmountPay.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtAmountPay.Properties.Appearance.Options.UseBackColor = true;
            txtAmountPay.TabStop = false;

            txtAmountPay.ReadOnly = true;
            txtAmountPay.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtAmountPay.Properties.Appearance.Options.UseBackColor = true;
            txtAmountPay.TabStop = false;
        }

        /// <summary>
        /// Design DateTimeEdit
        /// </summary>
        private void DesignDateTimeEdit()
        {
            dtpTrnDate.ReadOnly = true;
            dtpTrnDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            dtpTrnDate.Properties.AppearanceDropDown.Options.UseFont = true;
            dtpTrnDate.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            dtpTrnDate.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            dtpTrnDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            dtpTrnDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dtpTrnDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtpTrnDate.TabStop = false;
        }

        /// <summary>
        /// Design lưới dữ liệu
        /// </summary>
        private void DesignGridview()
        {
            #region colTrnID
            colTrnID = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrnID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colTrnID.AppearanceCell.Options.UseFont = true;
            colTrnID.Caption = "ID giao dịch";
            colTrnID.FieldName = "TrnID";
            colTrnID.Name = "colTrnID";
            colTrnID.Visible = false;
            //colTrnID.VisibleIndex = -1;
            colTrnID.Width = 80;
            colTrnID.OptionsColumn.AllowEdit = false;
            #endregion

            #region colTrnCode
            colTrnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrnCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colTrnCode.AppearanceCell.Options.UseFont = true;
            colTrnCode.Caption = "Mã giao dịch";
            colTrnCode.FieldName = "TrnCode";
            colTrnCode.Name = "colTrnCode";
            colTrnCode.Visible = false;
            colTrnCode.VisibleIndex = -1;
            colTrnCode.Width = 120;
            colTrnCode.OptionsColumn.AllowEdit = false;
            #endregion

            #region colProductID
            colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductID.AppearanceCell.Options.UseFont = true;
            colProductID.Caption = "Mã hàng";
            colProductID.FieldName = "ProductCode";
            colProductID.Name = "colProductCode";
            colTrnID.Visible = false;
            //colTrnID.VisibleIndex = -1;
            colTrnID.Width = 80;
            colTrnID.OptionsColumn.AllowEdit = false;
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
            colProductCode.OptionsColumn.AllowEdit = false;
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
            colProductDesc.Width = 300;
            colProductDesc.OptionsColumn.AllowEdit = false;
            #endregion

            #region colDescriptions
            colDescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescriptions.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDescriptions.AppearanceCell.Options.UseFont = true;
            colDescriptions.Caption = "Mô tả";
            colDescriptions.FieldName = "Descriptions";
            colDescriptions.Name = "colDescriptions";
            colDescriptions.Visible = false;
            //colDescriptions.VisibleIndex = -1;
            colDescriptions.Width = 80;
            colDescriptions.OptionsColumn.AllowEdit = false;
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
            colProductTypeID.OptionsColumn.AllowEdit = false;
            #endregion

            #region colProductTypeCode
            colProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductTypeCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductTypeCode.AppearanceCell.Options.UseFont = true;
            colProductTypeCode.Caption = "Mã Loại hàng";
            colProductTypeCode.FieldName = "CustCode";
            colProductTypeCode.Name = "colProductTypeCode";
            colProductTypeCode.Visible = false;
            //colProductTypeCode.VisibleIndex = -1;
            colProductTypeCode.Width = 120;
            colProductTypeCode.OptionsColumn.AllowEdit = false;
            #endregion

            #region colProductTypeName
            colProductTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductTypeName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductTypeName.AppearanceCell.Options.UseFont = true;
            colProductTypeName.Caption = "Loại hàng";
            colProductTypeName.FieldName = "ProductTypeName";
            colProductTypeName.Name = "colProductTypeName";
            colProductTypeName.Visible = false;
            //colProductTypeName.VisibleIndex = -1;
            colProductTypeName.Width = 80;
            colProductTypeName.OptionsColumn.AllowEdit = false;
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
            colProductGroupID.OptionsColumn.AllowEdit = false;
            #endregion

            #region colProductGroupCode
            colProductGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductGroupCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductGroupCode.AppearanceCell.Options.UseFont = true;
            colProductGroupCode.Caption = "Mã Nhóm hàng";
            colProductGroupCode.FieldName = "CustCode";
            colProductGroupCode.Name = "colProductGroupCode";
            colProductGroupCode.Visible = false;
            //colProductGroupCode.VisibleIndex = -1;
            colProductGroupCode.Width = 120;
            colProductGroupCode.OptionsColumn.AllowEdit = false;
            #endregion

            #region colProductGroupName
            colProductGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductGroupName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductGroupName.AppearanceCell.Options.UseFont = true;
            colProductGroupName.Caption = "Nhóm hàng";
            colProductGroupName.FieldName = "ProductGroupName";
            colProductGroupName.Name = "colProductGroupName";
            colProductGroupName.Visible = false;
            //colProductGroupName.VisibleIndex = -1;
            colProductGroupName.Width = 80;
            colProductGroupName.OptionsColumn.AllowEdit = false;
            #endregion

            #region colStallsID
            colStallsID = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsID.AppearanceCell.Options.UseFont = true;
            colStallsID.Caption = "ID Quầy/kho";
            colStallsID.FieldName = "StallsID";
            colStallsID.Name = "colStallsID";
            colStallsID.Visible = false;
            //colStallsID.VisibleIndex = -1;
            colStallsID.Width = 80;
            colStallsID.OptionsColumn.AllowEdit = false;
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
            colStallsCode.OptionsColumn.AllowEdit = false;
            #endregion

            #region colStallsName
            colStallsName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsName.AppearanceCell.Options.UseFont = true;
            colStallsName.Caption = "Quầy/kho";
            colStallsName.FieldName = "StallsName";
            colStallsName.Name = "colStallsName";
            colStallsName.Visible = false;
            //colStallsName.VisibleIndex = -1;
            colStallsName.Width = 120;
            colStallsName.OptionsColumn.AllowEdit = false;
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
            colSupplierID.OptionsColumn.AllowEdit = false;
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
            colSupplierCode.OptionsColumn.AllowEdit = false;
            #endregion

            #region colSupplierName
            colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSupplierName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colSupplierName.AppearanceCell.Options.UseFont = true;
            colSupplierName.Caption = "Nhà cung cấp";
            colSupplierName.FieldName = "SupplierName";
            colSupplierName.Name = "colSupplierName";
            colSupplierName.Visible = false;
            //colSupplierName.VisibleIndex = -1;
            colSupplierName.Width = 80;
            colSupplierName.OptionsColumn.AllowEdit = false;
            #endregion

            #region colProductWeight
            colProductWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductWeight.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductWeight.AppearanceCell.Options.UseFont = true;
            colProductWeight.DisplayFormat.FormatString = "{0:#,##0.00}";
            colProductWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colProductWeight.Caption = "Trọng lượng";
            colProductWeight.FieldName = "ProductWeight";
            colProductWeight.Name = "colProductWeight";
            colProductWeight.Visible = true;
            colProductWeight.VisibleIndex = 2;
            colProductWeight.Width = 130;
            colProductWeight.OptionsColumn.AllowEdit = true;
            colProductWeight.ColumnEdit = this.rtxtProductWeight;

            rtxtProductWeight = new RepositoryItemSpinEdit();
            rtxtProductWeight.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            rtxtProductWeight.AutoHeight = false;
            rtxtProductWeight.Mask.EditMask = "n2";
            rtxtProductWeight.Mask.UseMaskAsDisplayFormat = true;
            rtxtProductWeight.Name = "rtxtFcyAmount";
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
            colQuantity.VisibleIndex = 3;
            colQuantity.Width = 100;
            colQuantity.OptionsColumn.AllowEdit = true;
            colQuantity.ColumnEdit = this.rtxtQuantity;

            rtxtQuantity = new RepositoryItemSpinEdit();
            rtxtQuantity.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            rtxtQuantity.AutoHeight = false;
            rtxtQuantity.Mask.EditMask = "n0";
            rtxtQuantity.Mask.UseMaskAsDisplayFormat = true;
            rtxtQuantity.Name = "rtxtFcyAmount";
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
            colUnitSellID.OptionsColumn.AllowEdit = false;
            #endregion

            #region colUnitSellCode
            colUnitSellCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitSellCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitSellCode.AppearanceCell.Options.UseFont = true;
            colUnitSellCode.Caption = "Mã Đơn vị bán";
            colUnitSellCode.FieldName = "UnitSellCode";
            colUnitSellCode.Name = "colUnitSellCode";
            colUnitSellCode.Visible = false;
            //colUnitSellCode.VisibleIndex = -1;
            colUnitSellCode.Width = 120;
            colUnitSellCode.OptionsColumn.AllowEdit = false;
            #endregion

            #region colUnitSellDesc
            colUnitSellDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitSellDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitSellDesc.AppearanceCell.Options.UseFont = true;
            colUnitSellDesc.Caption = "Đơn vị bán";
            colUnitSellDesc.FieldName = "UnitSellDesc";
            colUnitSellDesc.Name = "colUnitSellDesc";
            colUnitSellDesc.Visible = false;
            //colUnitSellDesc.VisibleIndex = -1;
            colUnitSellDesc.Width = 120;
            colUnitSellDesc.OptionsColumn.AllowEdit = false;
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
            colRateIn.Visible = false;
            //colRateIn.VisibleIndex = -1;
            colRateIn.Width = 80;
            colRateIn.OptionsColumn.AllowEdit = false;
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
            colRateEstimate.VisibleIndex = 4;
            colRateEstimate.Width = 120;
            colRateEstimate.OptionsColumn.AllowEdit = false;
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
            colDiscountPercent.Visible = false;
            //colDiscountPercent.VisibleIndex = -1;
            colDiscountPercent.Width = 80;
            colDiscountPercent.OptionsColumn.AllowEdit = false;
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
            colDiscount.Visible = false;
            //colDiscount.VisibleIndex = -1;
            colDiscount.Width = 80;
            colDiscount.OptionsColumn.AllowEdit = false;
            #endregion

            #region colDiscountTotal
            colDiscountTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountTotal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDiscountTotal.AppearanceCell.Options.UseFont = true;
            colDiscountTotal.DisplayFormat.FormatString = "{0:#,##0}";
            colDiscountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiscountTotal.Caption = "Giảm giá";
            colDiscountTotal.FieldName = "DiscountTotal";
            colDiscountTotal.Name = "colDiscountTotal";
            colDiscountTotal.Visible = true;
            colDiscountTotal.VisibleIndex = 5;
            colDiscountTotal.Width = 120;
            colDiscountTotal.OptionsColumn.AllowEdit = false;
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
            colRateSell.VisibleIndex = 6;
            colRateSell.Width = 120;
            colRateSell.OptionsColumn.AllowEdit = false;
            #endregion

            #region colAmount
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmount.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colAmount.AppearanceCell.Options.UseFont = true;
            colAmount.DisplayFormat.FormatString = "{0:#,##0}";
            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.Caption = "Thành tiền";
            colAmount.FieldName = "Amount";
            colAmount.Name = "colAmount";
            colAmount.Visible = true;
            colAmount.VisibleIndex = 7;
            colAmount.Width = 120;
            colAmount.OptionsColumn.AllowEdit = false;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 8;
            colNotes.Width = 250;
            colNotes.OptionsColumn.AllowEdit = true;
            #endregion

            #region Gridview
            grcProductSellDtl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                rtxtProductWeight,
                rtxtQuantity
            });

            layoutControlItemGridView.TextVisible = false;
            //layoutControlItemGridView.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 12F);
            //layoutControlItemGridView.AppearanceItemCaption.Options.UseFont = true;
            //layoutControlItemGridView.Text = "Thông tin hàng bán";
            //layoutControlItemGridView.TextLocation = DevExpress.Utils.Locations.Top;
            grvProductSellDtl.OptionsView.ShowGroupPanel = false;
            grvProductSellDtl.OptionsBehavior.Editable = true;
            // Định dạng chữ dòng dữ liệu
            grvProductSellDtl.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductSellDtl.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductSellDtl.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductSellDtl.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductSellDtl.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductSellDtl.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductSellDtl.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            // grvProductSellLst.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductSellDtl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colTrnID,
                colTrnCode,
                colProductID,
                colProductCode,
                colDescriptions,
                colProductDesc,
                colProductTypeID,
                colProductTypeCode,
                colProductTypeName,
                colProductGroupID,
                colProductGroupCode,
                colProductGroupName,
                colSupplierID,
                colSupplierCode,
                colSupplierName,
                colProductWeight,
                colQuantity,
                colRateIn,
                colRateEstimate,
                colDiscountPercent,
                colDiscount,
                colDiscountTotal,
                colRateSell,
                colAmount
            });
            this.grvProductSellDtl.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvProductSellDtl_FocusedRowChanged);
            this.grvProductSellDtl.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvProductSellDtl_CellValueChanged);
            this.grvProductSellDtl.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvProductSellDtl_ValidatingEditor);
            this.grvProductSellDtl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvProductSellDtl_KeyDown);
            #endregion
        }
        #endregion

        #region Function
        /// <summary>
        /// Khởi tạo datasource cho lưới dữ liệu
        /// </summary>
        /// <returns></returns>
        public DataTable InitDataSource()
        {
            DataTable table = new DataTable("DataSource");
            table.Columns.Add("TrnID", typeof(long));
            table.Columns.Add("TrnCode", typeof(string));
            table.Columns.Add("ProductID", typeof(long));
            table.Columns.Add("ProductCode", typeof(string));
            table.Columns.Add("ProductDesc", typeof(string));
            table.Columns.Add("Descriptions", typeof(string));
            table.Columns.Add("StallsID", typeof(long));
            table.Columns.Add("StallsCode", typeof(string));
            table.Columns.Add("StallsName", typeof(string));
            table.Columns.Add("ProductTypeID", typeof(long));
            table.Columns.Add("ProductTypeCode", typeof(string));
            table.Columns.Add("ProductTypeName", typeof(string));
            table.Columns.Add("ProductGroupID", typeof(long));
            table.Columns.Add("ProductGroupCode", typeof(string));
            table.Columns.Add("ProductGroupName", typeof(string));
            table.Columns.Add("SupplierID", typeof(long));
            table.Columns.Add("SupplierCode", typeof(string));
            table.Columns.Add("SupplierName", typeof(string));
            table.Columns.Add("ProductWeight", typeof(decimal));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("UnitSellID", typeof(long));
            table.Columns.Add("UnitSellCode", typeof(string));
            table.Columns.Add("UnitSellDesc", typeof(string));
            table.Columns.Add("RateIn", typeof(decimal));
            table.Columns.Add("RateEstimate", typeof(decimal));
            table.Columns.Add("DiscountPercent", typeof(decimal));
            table.Columns.Add("Discount", typeof(decimal));
            table.Columns.Add("DiscountTotal", typeof(decimal));
            table.Columns.Add("RateSell", typeof(decimal));
            table.Columns.Add("Amount", typeof(decimal));
            table.Columns.Add("Notes", typeof(string));
            return table;
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
                ds = BLLCatCustomer.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboCustomer.Properties.DataSource = ds.Tables[0].Copy();
                    cboCustomer.Properties.DisplayMember = "CustName";
                    cboCustomer.Properties.ValueMember = "CustID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatEmployee.LoadDataCombobox(-1, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboEmployee.Properties.DataSource = ds.Tables[0].Copy();
                    cboEmployee.Properties.DisplayMember = "EmpName";
                    cboEmployee.Properties.ValueMember = "EmpID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLSysStatus.LoadDataCombobox("STATUS_TRN_PRODUCT_SELL", out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboStatus.Properties.DataSource = ds.Tables[0].Copy();
                    cboStatus.Properties.DisplayMember = "StatusName";
                    cboStatus.Properties.ValueMember = "StatusCode";
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
        /// Disable/Enable Controls
        /// </summary>
        /// <param name="_StatusCode">Tình trạng</param>
        private void DisableControls(string _StatusCode)
        {
            if (_StatusCode == string.Empty)
            {
                cboCustomer.Enabled = true;

                txtNotes.Enabled = true;
                txtDiscountTrn.Enabled = true;

                btnAddProduct.Enabled = true;
                btnSave.Enabled = true;
                btnPayment.Enabled = false;
                btnPrint.Enabled = false;
                btnDelete.Enabled = false;
                btnList.Enabled = true;

                grvProductSellDtl.OptionsBehavior.Editable = true;
            }
            else if (_StatusCode == "S")
            {
                cboCustomer.Enabled = true;

                txtNotes.Enabled = true;
                txtDiscountTrn.Enabled = true;

                btnAddProduct.Enabled = true;
                btnSave.Enabled = true;
                btnPayment.Enabled = true;
                btnPrint.Enabled = true;
                btnDelete.Enabled = true;
                btnList.Enabled = true;

                grvProductSellDtl.OptionsBehavior.Editable = true;
            }
            else if (_StatusCode == "C")
            {
                cboCustomer.Enabled = false;

                txtNotes.Enabled = false;
                txtDiscountTrn.Enabled = false;

                btnAddProduct.Enabled = false;
                btnSave.Enabled = false;
                btnPayment.Enabled = false;
                btnPrint.Enabled = true;
                btnDelete.Enabled = false;
                btnList.Enabled = true;

                grvProductSellDtl.OptionsBehavior.Editable = false;
            }
        }

        private void ResetData()
        {
            gbTrnID = -1;
            gbLockCellChanged = false;
            gbFrmProductSell = null;
            gbDataSource = InitDataSource().Clone();
            gbObjProductSell = null;
            LoadDefault();
        }

        /// <summary>
        /// Load dữ liệu mặc định cho form
        /// </summary>
        private void LoadDefault()
        {
            try
            {
                dtpTrnDate.EditValue = DateTime.Now;
                txtTrnCode.Text = gbObjProductSell == null ? "{Tự động}" : gbObjProductSell.TrnCode;
                txtDiscountTrn.EditValue = gbObjProductSell == null ? 0M : gbObjProductSell.DiscountTrn;

                cboCustomer.EditValue = gbObjProductSell == null ? -1 : gbObjProductSell.Customer.ID;
                cboEmployee.EditValue = gbObjProductSell == null ? -1 : gbObjProductSell.Employee.ID;

                txtNotes.EditValue = gbObjProductSell == null ? string.Empty : gbObjProductSell.Notes;
                grcProductSellDtl.DataSource = gbDataSource;
                SetValueControlMoney();

                string sStatusCode = gbObjProductSell == null ? string.Empty : gbObjProductSell.StatusCode;
                cboStatus.EditValue = sStatusCode;
                DisableControls(sStatusCode);
                txtDiscountTrn.Focus();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Load dữ liệu cho form
        /// </summary>
        public void LoadDataToForm(long _TrnID)
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                ds = BLLTrnProductSell.TrnProductSell_GetWithID(_TrnID, out sMessage);
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                    return;
                }
                gbDataSource = ds.Tables[1].Copy();

                gbObjProductSell.TrnCode = ds.Tables[0].Rows[0]["TrnCode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[0]["TrnCode"]);
                gbObjProductSell.Notes = ds.Tables[0].Rows[0]["Notes"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[0]["Notes"]);
                gbObjProductSell.Customer.ID = ds.Tables[0].Rows[0]["CustID"] == DBNull.Value ? -1 : Convert.ToInt64(ds.Tables[0].Rows[0]["CustID"]);
                gbObjProductSell.Employee.ID = ds.Tables[0].Rows[0]["EmpID"] == DBNull.Value ? -1 : Convert.ToInt64(ds.Tables[0].Rows[0]["EmpID"]);
                gbObjProductSell.TrnDate = ds.Tables[0].Rows[0]["TrnDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(ds.Tables[0].Rows[0]["TrnDate"]);
                gbObjProductSell.AmountTotal = ds.Tables[0].Rows[0]["AmountTotal"] == DBNull.Value ? -1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["AmountTotal"]);
                gbObjProductSell.DiscountTrn = ds.Tables[0].Rows[0]["DiscountTrn"] == DBNull.Value ? -1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["DiscountTrn"]);
                gbObjProductSell.DiscountTotal = ds.Tables[0].Rows[0]["DiscountTotal"] == DBNull.Value ? -1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["DiscountTotal"]);
                gbObjProductSell.AmountPay = ds.Tables[0].Rows[0]["AmountPay"] == DBNull.Value ? -1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["AmountPay"]);
                gbObjProductSell.StatusCode = ds.Tables[0].Rows[0]["StatusCode"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["StatusCode"].ToString();

                txtTrnCode.EditValue = gbObjProductSell.TrnCode;
                txtNotes.EditValue = gbObjProductSell.Notes;
                cboCustomer.EditValue = gbObjProductSell.Customer.ID;
                cboEmployee.EditValue = gbObjProductSell.Employee.ID;                
                dtpTrnDate.EditValue = gbObjProductSell.TrnDate;

                txtAmountTotal.EditValue = gbObjProductSell.AmountTotal;
                txtDiscountTrn.EditValue = gbObjProductSell.DiscountTrn;
                txtDiscountTotalTrn.EditValue = gbObjProductSell.DiscountTotal;
                txtAmountPay.EditValue = gbObjProductSell.AmountPay;

                decimal dTotalAmountProduct, dDiscountTotalProduct, dAmountPayTemp;
                FuncCalculate.CalcValueTransaction(gbDataSource, out dTotalAmountProduct, out dDiscountTotalProduct, out dAmountPayTemp);
                txtDiscountProduct.EditValue = dDiscountTotalProduct;

                grcProductSellDtl.DataSource = gbDataSource;
                
                cboStatus.EditValue = gbObjProductSell.StatusCode;
                DisableControls(gbObjProductSell.StatusCode);
                SetLabelPayAmountByNumber(gbObjProductSell.AmountPay);
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
        /// Kiểm tra cột số lượng/trọng lượng hợp lệ
        /// </summary>
        /// <param name="_Quantity">Số lượng/Trọng lượng</param>
        /// <param name="_Error">Thông báo lỗi</param>
        /// <returns>true: Hợp lệ | false: Không hợp lệ</returns>
        private bool IsColQuantityCalcValid(decimal _Quantity, out string _Error)
        {
            _Error = string.Empty;
            if (_Quantity <= 0)
            {
                _Error = "Vui lòng nhập số lượng/trọng lượng hàng lớn hơn không!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thiết lập nhãn thu - chi
        /// </summary>
        /// <param name="_Value">Tổng tiền thu - chi</param>
        private void SetLabelPayAmountByNumber(decimal _Value)
        {
            if (_Value == 0)
            {
                lblPayAmountByNumber.Text = " ";
                return;
            }
            string sLabel = (_Value > 0 ? "Phải thu: " : "Phải chi: ") + FuncNumber.ReadNumberInteger(Math.Abs(_Value).ToString("###")) + "Đồng";
            lblPayAmountByNumber.Text = sLabel;
            if (_Value > 0)
            {
                lblPayAmountByNumber.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblPayAmountByNumber.AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
            }
        }

        /// <summary>
        /// Thiết lập giá trị cho các control liên quan đền tiền
        /// </summary>
        private void SetValueControlMoney()
        {
            try
            {
                if(gbDataSource == null)
                {
                    return;
                }

                decimal dTotalAmount, dDiscountProduct, dAmountPay;
                FuncCalculate.CalcValueTransaction(gbDataSource, out dTotalAmount, out dDiscountProduct, out dAmountPay);
                txtAmountTotal.EditValue = dTotalAmount;
                txtDiscountProduct.EditValue = dDiscountProduct;

                decimal dDiscountTrn = txtDiscountTrn.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTrn.EditValue);
                decimal dDiscountTotalTrn = FuncCalculate.CalcDiscountTotalTransaction(dDiscountTrn, dDiscountProduct);
                txtDiscountTotalTrn.EditValue = dDiscountTotalTrn;

                dAmountPay = FuncCalculate.CalcAmountPay(dTotalAmount, dDiscountTotalTrn);
                txtAmountPay.EditValue = dAmountPay;
                SetLabelPayAmountByNumber(dAmountPay);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        /// <param name="_TrnID">ID giao dịch</param>
        /// <param name="_Message">Thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SaveClick(long _TrnID, string _TrnCode, out long _TrnIDUdp, out string _TrnCodeUdp, out string _Message)
        {
            _Message = string.Empty;
            _TrnIDUdp = -1;
            _TrnCodeUdp = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                if (DTOAttributeSystem.CurrentCounter == null || DTOAttributeSystem.CurrentCounter.ID == -1)
                {
                    VMHMessages.ShowWarning("Quầy thu ngân chưa mở! Không thể giao dịch!");
                    return false;
                }

                long lCurrentID = FuncGeneral.GetCurrentID("TRN_PRODUCT_SELL");
                _TrnCodeUdp = _TrnID == -1 ? FuncGeneral.GenTransactionCode("TRN_PRODUCT_SELL", lCurrentID) : _TrnCode;

                DTOTrnProductSell objTrnProductSell = new DTOTrnProductSell();
                objTrnProductSell.TrnID = _TrnID;
                objTrnProductSell.TrnCode = _TrnCodeUdp;
                objTrnProductSell.TrnDate = DateTime.Now;
                objTrnProductSell.TrnTime = TimeSpan.FromTicks(DateTime.Now.ToLocalTime().Ticks);

                DTOCatCustomer objCatCustomer = new DTOCatCustomer();
                DataTable dtCustomer = cboCustomer.Properties.DataSource as DataTable;
                objCatCustomer.ID = cboCustomer.EditValue == null ? -1 : Convert.ToInt64(cboCustomer.EditValue);
                objCatCustomer.CustCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtCustomer, "CustID", objCatCustomer.ID, "CustCode"));
                objCatCustomer.CustName = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtCustomer, "CustID", objCatCustomer.ID, "CustName"));
                objTrnProductSell.Customer = objCatCustomer;

                DTOCatCounter objCatCounter = new DTOCatCounter();
                objCatCounter.ID = DTOAttributeSystem.CurrentCounter.ID;
                objCatCounter.CounterCode = DTOAttributeSystem.CurrentCounter.CounterCode;
                objCatCounter.CounterName = DTOAttributeSystem.CurrentCounter.CounterName;
                objTrnProductSell.Counter = objCatCounter;

                objTrnProductSell.DiscountTrn = txtDiscountTrn.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTrn.EditValue);
                objTrnProductSell.DiscountTotal = txtDiscountTotalTrn.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTotalTrn.EditValue);
                objTrnProductSell.AmountTotal = txtAmountTotal.EditValue == null ? 0M : Convert.ToDecimal(txtAmountTotal.EditValue);
                objTrnProductSell.AmountPay = txtAmountPay.EditValue == null ? 0M : Convert.ToDecimal(txtAmountPay.EditValue);

                DTOCatCurrency objUnitPayment = new DTOCatCurrency();
                objUnitPayment.ID = 0;
                objUnitPayment.CurrencyCode = "VND";
                objUnitPayment.CurrencyDesc = "Việt Nam Đồng";
                objTrnProductSell.UnitPayment = objUnitPayment;

                objTrnProductSell.Notes = txtNotes.EditValue == null ? string.Empty : Convert.ToString(txtNotes.EditValue);

                DTOCatEmployee objCatEmployee = new DTOCatEmployee();
                DataTable dtEmployee = cboEmployee.Properties.DataSource as DataTable;
                objCatEmployee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objCatEmployee.EmpCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtEmployee, "EmpID", objCatEmployee.ID, "EmpCode"));
                objCatEmployee.EmpName = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtEmployee, "EmpID", objCatEmployee.ID, "EmpName"));
                objTrnProductSell.Employee = objCatEmployee;

                objTrnProductSell.StatusCode = "S";
                objTrnProductSell.UpdateDate = DateTime.Now;
                objTrnProductSell.UpdateBy = DTOAttributeSystem.CurrentUser.ID;
                objTrnProductSell.IsDelete = false;

                DataTable dtDtl = new DataTable("Transaction");
                dtDtl = ((DataView)grvProductSellDtl.DataSource).ToTable("Transaction");
                dtDtl.DefaultView.Sort = "ProductCode DESC";
                grcProductSellDtl.DataSource = dtDtl.Copy();
                ds.Tables.Add(dtDtl);
                string xmlDtl = ds.GetXml();
                bResult = BLLTrnProductSell.TrnProductSell_InsUpd(objTrnProductSell, xmlDtl, out _TrnIDUdp, out _Message);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }

        /// <summary>
        /// Hoàn tất
        /// </summary>
        /// <param name="_ID">ID</param>
        /// <param name="_Message">Thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool CompleteClick(long _ID, out string _Message)
        {
            bool bResult = false;
            _Message = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                if (VMHMessages.ShowConfirm("Bạn có muốn hoàn tất giao dịch này không?") == DialogResult.OK)
                {
                    bResult = BLLTrnProductSell.TrnProductSell_Complete(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="_ID">ID</param>
        /// <param name="_Message">Thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool DeleteClick(long _ID, out string _Message)
        {
            bool bResult = false;
            _Message = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                if (VMHMessages.ShowConfirm("Bạn có muốn xóa giao dịch này không?") == DialogResult.OK)
                {
                    bResult = BLLTrnProductSell.TrnProductSell_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
                }

            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }

        /// <summary>
        /// Xóa dòng dữ liệu
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool DeleteDtlClick()
        {
            bool bResult = false;
            try
            {
                if (grvProductSellDtl.OptionsBehavior.Editable == true)
                {
                    if (VMHMessages.ShowConfirm("Bạn có muốn xóa dòng dữ liệu này không?") == DialogResult.OK)
                    {
                        int i = grvProductSellDtl.FocusedRowHandle;
                        grvProductSellDtl.DeleteRow(i);
                    }
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Combobox
        private void cboCustomer_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region TextEdit
        private void txtDiscountTrn_EditValueChanged(object sender, EventArgs e)
        {
            decimal dDiscountTrn = txtDiscountTrn.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTrn.EditValue);
            decimal dDiscountProduct = txtDiscountProduct.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountProduct.EditValue);
            txtDiscountTotalTrn.EditValue = FuncCalculate.CalcDiscountTotalTransaction(dDiscountTrn, dDiscountProduct);

            decimal dDiscountTotalTrn = txtDiscountTotalTrn.EditValue == null ? 0M : Convert.ToDecimal(txtDiscountTotalTrn.EditValue);
            decimal dAmountTotal = txtAmountTotal.EditValue == null ? 0M : Convert.ToDecimal(txtAmountTotal.EditValue);
            
            decimal dAmountPay = FuncCalculate.CalcAmountPay(dAmountTotal, dDiscountTotalTrn);
            txtAmountPay.EditValue = dAmountPay;
            SetLabelPayAmountByNumber(dAmountPay);
        }
        #endregion

        #region Button
        private void btnCounterOpenClose_Click(object sender, EventArgs e)
        {
            frmCounterOpenClose frm = new frmCounterOpenClose();
            frm.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if(gbFrmProductSell != null)
            {
                DTOTrnProductSell objTrnProductSell = new DTOTrnProductSell();
                objTrnProductSell.TrnID = gbTrnID;
                objTrnProductSell.TrnCode = txtTrnCode.EditValue == null ? string.Empty : Convert.ToString(txtTrnCode.EditValue);
                objTrnProductSell.TrnDate = dtpTrnDate.EditValue == null ? DateTime.Now : Convert.ToDateTime(dtpTrnDate.EditValue);
                objTrnProductSell.Customer.ID = cboCustomer.EditValue == null ? -1 : Convert.ToInt64(cboCustomer.EditValue);
                objTrnProductSell.Employee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnProductSell.Notes = txtNotes.EditValue == null ? string.Empty : Convert.ToString(txtNotes.EditValue);
                objTrnProductSell.AmountPay = txtAmountPay.EditValue == null ? 0M : Convert.ToDecimal(txtAmountPay.EditValue);
                gbDataSource = grcProductSellDtl.DataSource as DataTable;
                gbFrmProductSell.LoadDataToForm(this, objTrnProductSell);
                this.Close();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (DeleteDtlClick())
            {
                VMHMessages.ShowInformation(MessagesText.HandlerSuccess("Xóa"));
            }
            else
            {
                VMHMessages.ShowError(MessagesText.HandlerFailure("Xóa"));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            string sTrnCodeUdp = string.Empty;
            string sTrnCode = txtTrnCode.Text.Trim();
            long lTrnID = -1;
            if (SaveClick(gbTrnID, sTrnCode, out lTrnID, out sTrnCodeUdp, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.HandlerSuccess("Lưu"));
                txtTrnCode.EditValue = sTrnCodeUdp;
                gbTrnID = lTrnID;
                LoadDataToForm(gbTrnID);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (CompleteClick(gbTrnID, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
                LoadDataToForm(gbTrnID);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                string sParameters = string.Empty, sValues = string.Empty;
                if (gbTrnID != -1)
                {
                    ds = BLLTrnProductSell.TrnProductSell_GetWithID(gbTrnID, out sMessage);
                    if (!string.IsNullOrWhiteSpace(sMessage))
                    {
                        VMHMessages.ShowWarning(sMessage);
                        return;
                    }

                    decimal dAmountPay = txtAmountPay.EditValue == null ? 0M : Convert.ToDecimal(txtAmountPay.EditValue);
                    string sNumberToText = FuncNumber.ReadNumberInteger(Math.Abs(dAmountPay).ToString("###")) + "Đồng" + "\n";
                    sParameters = "ReadNumberToText";
                    sValues = sNumberToText;
                    FuncReportGUI.ShowReport(ds, "TRN_PRODUCT_SELL_PrintBill.rpt", sParameters, sValues, out sMessage);
                }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (DeleteClick(gbTrnID, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
                ResetData();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }  
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmProductSellLst frm = new frmProductSellLst(this);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region GridView
        private void grvProductSellDtl_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int idxFocused = e.FocusedRowHandle;
            if (idxFocused < 0)
            {
                return;
            }
            long sProductTypeID = grvProductSellDtl.GetFocusedRowCellValue(colProductTypeID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductSellDtl.GetFocusedRowCellValue(colProductTypeID));
            if (sProductTypeID == 0 || sProductTypeID == 1)
            {
                colQuantity.OptionsColumn.AllowEdit = true;
                colQuantity.OptionsColumn.AllowFocus = true;
                colProductWeight.OptionsColumn.AllowEdit = false;
                colProductWeight.OptionsColumn.AllowFocus = false;
            }
            else if (sProductTypeID == 2)
            {
                colQuantity.OptionsColumn.AllowEdit = false;
                colQuantity.OptionsColumn.AllowFocus = false;
                colProductWeight.OptionsColumn.AllowEdit = true;
                colProductWeight.OptionsColumn.AllowFocus = true;
            }
            else
            {
                colQuantity.OptionsColumn.AllowEdit = false;
                colQuantity.OptionsColumn.AllowFocus = false;
                colProductWeight.OptionsColumn.AllowEdit = false;
                colProductWeight.OptionsColumn.AllowFocus = false;
            }
        }

        private void grvProductSellDtl_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gbLockCellChanged || e.Value == null)
            {
                return;
            }
            gbLockCellChanged = true;
            try
            {
                string sFieldName = e.Column.FieldName;
                string sValue = e.Value.ToString();
                long lProductTypeID = -1;
                decimal dSellRate = decimal.Zero, dQuantityCalc = decimal.Zero, dQuantity = decimal.Zero, dProductWeight = decimal.Zero, dAmount = decimal.Zero;

                lProductTypeID = grvProductSellDtl.GetRowCellValue(e.RowHandle, colProductTypeID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductSellDtl.GetRowCellValue(e.RowHandle, colProductTypeID));
                dAmount = grvProductSellDtl.GetRowCellValue(e.RowHandle, colAmount) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductSellDtl.GetRowCellValue(e.RowHandle, colAmount));
                dSellRate = grvProductSellDtl.GetRowCellValue(e.RowHandle, colRateSell) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductSellDtl.GetRowCellValue(e.RowHandle, colRateSell));
                dProductWeight = grvProductSellDtl.GetRowCellValue(e.RowHandle, colProductWeight) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductSellDtl.GetRowCellValue(e.RowHandle, colProductWeight));
                dQuantity = grvProductSellDtl.GetRowCellValue(e.RowHandle, colQuantity) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductSellDtl.GetRowCellValue(e.RowHandle, colQuantity));
                dQuantityCalc = lProductTypeID == 2 ? dProductWeight : dQuantity;

                bool isEdit = false;
                switch (sFieldName)
                {
                    case "Quantity":
                        dQuantityCalc = Convert.ToDecimal(sValue);
                        isEdit = true;
                        break;
                    case "ProductWeight":
                        dQuantityCalc = Convert.ToDecimal(sValue);
                        isEdit = true;
                        break;
                    default:
                        break;
                }

                if (isEdit)
                {
                    #region Cập nhật dữ liệu
                    dAmount = FuncCalculate.CalcAmount(dSellRate, dQuantityCalc);
                    #endregion

                    #region Gán dữ liệu mới
                    grvProductSellDtl.SetRowCellValue(e.RowHandle, colAmount, dAmount);
                    SetValueControlMoney();
                    #endregion
                }

            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                gbLockCellChanged = false;
            }
        }

        private void grvProductSellDtl_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int idxRow = view.FocusedRowHandle;
                DataRow rowHandle = view.GetDataRow(idxRow);

                decimal dProductWeight = rowHandle["ProductWeight"] == DBNull.Value ? 0M : Convert.ToDecimal(rowHandle["ProductWeight"]);
                decimal dQuantity = rowHandle["Quantity"] == DBNull.Value ? 0M : Convert.ToDecimal(rowHandle["Quantity"]);

                string sError = string.Empty;

                switch (view.FocusedColumn.FieldName)
                {
                    case "Quantity":
                        dQuantity = e.Value == null ? 0 : Convert.ToDecimal(e.Value);
                        if (IsColQuantityCalcValid(dQuantity, out sError))
                        {
                            e.Valid = true;
                        }
                        else
                        {
                            e.Valid = false;
                            e.ErrorText = sError;
                        }
                        break;
                    case "ProductWeight":
                        dProductWeight = e.Value == null ? 0 : Convert.ToDecimal(e.Value);
                        if (IsColQuantityCalcValid(dProductWeight, out sError))
                        {
                            e.Valid = true;
                        }
                        else
                        {
                            e.Valid = false;
                            e.ErrorText = sError;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        private void grvProductSellDtl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DeleteDtlClick())
                {
                    VMHMessages.ShowInformation(MessagesText.HandlerSuccess("Xóa"));
                }
                else
                {
                    VMHMessages.ShowError(MessagesText.HandlerFailure("Xóa"));
                }
            }
        }
        #endregion
    }
}