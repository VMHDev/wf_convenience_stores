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
using CRM_GUI.CRMUtility.Messages;
using CRM_BLL.BLLCategories;
using CRM_BLL.BLLSystem;
using CRM_DTO.DTOProduct;
using CRM_BLL.BLLProduct;
using CRM_DTO.CRMUtility;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductSellLst : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private frmProductSell gbProductSell = null;
        private frmProductSellDtl gbFrmProductSellDtl = null;
        #endregion

        #region Form
        public frmProductSellLst(frmProductSell _Frm)
        {
            InitializeComponent();
            gbProductSell = _Frm;
            gbFrmProductSellDtl = null;
            DesignControls();
        }

        public frmProductSellLst(frmProductSellDtl _Frm)
        {
            InitializeComponent();
            gbProductSell = _Frm.gbFrmProductSell;
            gbFrmProductSellDtl = _Frm;
            DesignControls();            
        }

        private void frmProductSellLst_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            LoadDataToGrid();
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboCustomer
        public GridView grvCboCustomer { get; set; }
        public GridColumn colCboCustCode { get; set; }
        public GridColumn colCboCustName { get; set; }
        public GridColumn colCboCustAddress { get; set; }
        public GridColumn colCboCustPhone { get; set; }
        public GridColumn colCboIdentificationCard { get; set; }
        #endregion

        #region cboEmployee
        public GridView grvCboEmployee { get; set; }
        public GridColumn colCboEmpCode { get; set; }
        public GridColumn colCboEmpName { get; set; }
        public GridColumn colCboEmpShopName { get; set; }
        #endregion

        #region cboStatus
        public GridView grvCboStatus { get; set; }
        public GridColumn colCboStatusCode { get; set; }
        public GridColumn colCboStatusName { get; set; }
        #endregion

        #region Gridview
        public GridColumn colTrnID { get; set; }
        public GridColumn colTrnCode { get; set; }
        public GridColumn colTrnDate { get; set; }
        public GridColumn colTrnTime { get; set; }
        public GridColumn colCustID { get; set; }
        public GridColumn colCustCode { get; set; }
        public GridColumn colCustName { get; set; }
        public GridColumn colDiscountTrn { get; set; }
        public GridColumn colDiscountTotal { get; set; }
        public GridColumn colAmountTotal { get; set; }
        public GridColumn colAmountPay { get; set; }
        public GridColumn colUnitPayment { get; set; }
        public GridColumn colCurrencyCode { get; set; }
        public GridColumn colCurrencyDesc { get; set; }
        public GridColumn colNotes { get; set; }
        public GridColumn colEmpID { get; set; }
        public GridColumn colEmpCode { get; set; }
        public GridColumn colEmpName { get; set; }
        public GridColumn colStatusCode { get; set; }
        public GridColumn colStatusName { get; set; }
        public GridColumn colQuantitySell { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Danh sách bán hàng";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmProductSellLst_Load);
            #endregion

            DesignDateTimeEdit();
            DesignGridLookUpEdit();
            DesignGridview();
        }

        /// <summary>
        /// Design DateTimeEdit
        /// </summary>
        private void DesignDateTimeEdit()
        {
            this.dtpDateFrom.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDateFrom.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDateFrom.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDateFrom.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";

            this.dtpDateTo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDateTo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDateTo.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDateTo.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.dtpDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
            #region cboCustomer
            //
            // colCboCustCode
            //
            this.colCboCustCode = new GridColumn();
            this.colCboCustCode.Caption = "Mã KH";
            this.colCboCustCode.FieldName = "CustCode";
            this.colCboCustCode.Name = "colCboCustCode";
            this.colCboCustCode.Visible = true;
            this.colCboCustCode.VisibleIndex = 0;
            //
            // colCboCustName
            //
            this.colCboCustName = new GridColumn();
            this.colCboCustName.Caption = "Tên KH";
            this.colCboCustName.FieldName = "CustName";
            this.colCboCustName.Name = "colCboCustName";
            this.colCboCustName.Visible = true;
            this.colCboCustName.VisibleIndex = 1;
            // 
            // colCboCustAddress
            // 
            this.colCboCustAddress = new GridColumn();
            this.colCboCustAddress.Caption = "Địa chỉ";
            this.colCboCustAddress.FieldName = "CustAddress";
            this.colCboCustAddress.Name = "colCboCustAddress";
            this.colCboCustAddress.Visible = true;
            this.colCboCustAddress.VisibleIndex = 2;
            // 
            // colCboCustPhone
            // 
            this.colCboCustPhone = new GridColumn();
            this.colCboCustPhone.Caption = "Điện thoại";
            this.colCboCustPhone.FieldName = "Phone";
            this.colCboCustPhone.Name = "colCboCustPhone";
            this.colCboCustPhone.Visible = true;
            this.colCboCustPhone.VisibleIndex = 3;
            // 
            // colCboIdentificationCard
            // 
            this.colCboIdentificationCard = new GridColumn();
            this.colCboIdentificationCard.Caption = "CMND";
            this.colCboIdentificationCard.FieldName = "IdentificationCard";
            this.colCboIdentificationCard.Name = "colCboIdentificationCard";
            this.colCboIdentificationCard.Visible = true;
            this.colCboIdentificationCard.VisibleIndex = 4;
            // 
            // grvCboCustomer
            // 
            this.grvCboCustomer = new GridView();
            this.grvCboCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboCustCode,
            this.colCboCustName,
            this.colCboCustAddress,
            this.colCboCustPhone,
            this.colCboIdentificationCard});
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
            this.cboCustomer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustomer.Properties.Appearance.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustomer.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustomer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustomer.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCustomer.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustomer.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCustomer.Properties.NullText = "";
            this.cboCustomer.Properties.ShowFooter = false;
            this.cboCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCustomer.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCustomer.Properties.View = this.grvCboCustomer;
            //this.cboCustomer.EditValueChanged += new System.EventHandler(this.cboCustomer_EditValueChanged);
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
            this.grvCboEmployee.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboEmployee.Appearance.Row.Options.UseFont = true;
            this.grvCboEmployee.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboEmployee.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboEmployee.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboEmployee.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboEmployee.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboEmployee
            // 
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboEmployee.Properties.Appearance.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboEmployee.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboEmployee.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboEmployee.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboEmployee.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboEmployee.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboEmployee.Properties.NullText = "";
            this.cboEmployee.Properties.ShowFooter = false;
            this.cboEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboEmployee.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboEmployee.Properties.View = this.grvCboEmployee;
            //this.cboEmployee.EditValueChanged += new System.EventHandler(this.cboEmployee_EditValueChanged);
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
            this.cboStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStatus.Properties.Appearance.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStatus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStatus.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStatus.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboStatus.Properties.NullText = "";
            this.cboStatus.Properties.ShowFooter = false;
            this.cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboStatus.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboStatus.Properties.View = this.grvCboStatus;
            //this.cboStatus.EditValueChanged += new System.EventHandler(this.cboStatus_EditValueChanged);
            #endregion
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
            #endregion

            #region colTrnCode
            colTrnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrnCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colTrnCode.AppearanceCell.Options.UseFont = true;
            colTrnCode.Caption = "Mã giao dịch";
            colTrnCode.FieldName = "TrnCode";
            colTrnCode.Name = "colTrnCode";
            colTrnCode.Visible = true;
            colTrnCode.VisibleIndex = 0;
            colTrnCode.Width = 150;
            #endregion

            #region colTrnDate
            colTrnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrnDate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colTrnDate.AppearanceCell.Options.UseFont = true;
            colTrnDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            colTrnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colTrnDate.Caption = "Ngày giao dịch";
            colTrnDate.FieldName = "TrnDate";
            colTrnDate.Name = "colTrnDate";
            colTrnDate.Visible = true;
            colTrnDate.VisibleIndex = 1;
            colTrnDate.Width = 150;
            #endregion

            #region colTrnTime
            colTrnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrnTime.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colTrnTime.AppearanceCell.Options.UseFont = true;
            colTrnTime.DisplayFormat.FormatString = "HH:mm";
            colTrnTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colTrnTime.Caption = "Giờ";
            colTrnTime.FieldName = "TrnTime";
            colTrnTime.Name = "colTrnTime";
            colTrnTime.Visible = false;
            //colTrnTime.VisibleIndex = -1;
            colTrnTime.Width = 100;
            #endregion

            #region colCustID
            colCustID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustID.AppearanceCell.Options.UseFont = true;
            colCustID.Caption = "ID khách hàng";
            colCustID.FieldName = "CustID";
            colCustID.Name = "colCustID";
            colCustID.Visible = false;
            //colCustID.VisibleIndex = -1;
            colCustID.Width = 80;
            #endregion

            #region colCustCode
            colCustCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustCode.AppearanceCell.Options.UseFont = true;
            colCustCode.Caption = "Mã khách hàng";
            colCustCode.FieldName = "CustCode";
            colCustCode.Name = "colCustCode";
            colCustCode.Visible = false;
            //colCustCode.VisibleIndex = -1;
            colCustCode.Width = 120;
            #endregion

            #region colCustName
            colCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustName.AppearanceCell.Options.UseFont = true;
            colCustName.Caption = "Khách hàng";
            colCustName.FieldName = "CustName";
            colCustName.Name = "colCustName";
            colCustName.Visible = true;
            colCustName.VisibleIndex = 2;
            colCustName.Width = 150;
            #endregion

            #region colQuantitySell
            colQuantitySell = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantitySell.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colQuantitySell.AppearanceCell.Options.UseFont = true;
            colQuantitySell.DisplayFormat.FormatString = "{0:#,##0}";
            colQuantitySell.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQuantitySell.Caption = "Số lượng /Trọng lượng bán";
            colQuantitySell.FieldName = "QuantitySell";
            colQuantitySell.Name = "colQuantitySell";
            colQuantitySell.Visible = true;
            colQuantitySell.VisibleIndex = 3;
            colQuantitySell.Width = 200;
            #endregion

            #region colDiscountTrn
            colDiscountTrn = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountTrn.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDiscountTrn.AppearanceCell.Options.UseFont = true;
            colDiscountTrn.DisplayFormat.FormatString = "{0:#,##0}";
            colDiscountTrn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiscountTrn.Caption = "Tiền giảm";
            colDiscountTrn.FieldName = "DiscountTrn";
            colDiscountTrn.Name = "colDiscountTrn";
            colDiscountTrn.Visible = true;
            colDiscountTrn.VisibleIndex = 4;
            colDiscountTrn.Width = 150;
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
            colDiscountTotal.VisibleIndex = 5;
            colDiscountTotal.Width = 150;
            #endregion

            #region colAmountTotal
            colAmountTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmountTotal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colAmountTotal.AppearanceCell.Options.UseFont = true;
            colAmountTotal.DisplayFormat.FormatString = "{0:#,##0}";
            colAmountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmountTotal.Caption = "Tổng tiền";
            colAmountTotal.FieldName = "AmountTotal";
            colAmountTotal.Name = "colAmountTotal";
            colAmountTotal.Visible = true;
            colAmountTotal.VisibleIndex = 6;
            colAmountTotal.Width = 150;
            #endregion

            #region colAmountPay
            colAmountPay = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmountPay.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colAmountPay.AppearanceCell.Options.UseFont = true;
            colAmountPay.DisplayFormat.FormatString = "{0:#,##0}";
            colAmountPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmountPay.Caption = "Khách trả";
            colAmountPay.FieldName = "AmountPay";
            colAmountPay.Name = "colAmountPay";
            colAmountPay.Visible = true;
            colAmountPay.VisibleIndex = 7;
            colAmountPay.Width = 150;
            #endregion

            #region colUnitPayment
            colUnitPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitPayment.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitPayment.AppearanceCell.Options.UseFont = true;
            colUnitPayment.Caption = "ID Đơn vị thanh toán";
            colUnitPayment.FieldName = "UnitPayment";
            colUnitPayment.Name = "colUnitPayment";
            colUnitPayment.Visible = false;
            //colUnitPayment.VisibleIndex = -1;
            colUnitPayment.Width = 80;
            #endregion

            #region colCurrencyCode
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCurrencyCode.AppearanceCell.Options.UseFont = true;
            colCurrencyCode.Caption = "Mã Đơn vị thanh toán";
            colCurrencyCode.FieldName = "CustCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = false;
            //colCurrencyCode.VisibleIndex = -1;
            colCurrencyCode.Width = 120;
            #endregion

            #region colCurrencyDesc
            colCurrencyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCurrencyDesc.AppearanceCell.Options.UseFont = true;
            colCurrencyDesc.Caption = "Đơn vị thanh toán";
            colCurrencyDesc.FieldName = "CurrencyDesc";
            colCurrencyDesc.Name = "colCurrencyDesc";
            colCurrencyDesc.Visible = false;
            //colCurrencyDesc.VisibleIndex = -1;
            colCurrencyDesc.Width = 120;
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
            colNotes.Width = 180;
            #endregion

            #region colEmpID
            colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmpID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colEmpID.AppearanceCell.Options.UseFont = true;
            colEmpID.Caption = "ID nhân viên";
            colEmpID.FieldName = "EmpID";
            colEmpID.Name = "colEmpID";
            colEmpID.Visible = false;
            //colEmpID.VisibleIndex = -1;
            colEmpID.Width = 80;
            #endregion

            #region colEmpCode
            colEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmpCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colEmpCode.AppearanceCell.Options.UseFont = true;
            colEmpCode.Caption = "Mã nhân viên";
            colEmpCode.FieldName = "EmpCode";
            colEmpCode.Name = "colEmpCode";
            colEmpCode.Visible = false;
            //colEmpCode.VisibleIndex = -1;
            colEmpCode.Width = 120;
            #endregion

            #region colEmpName
            colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmpName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colEmpName.AppearanceCell.Options.UseFont = true;
            colEmpName.Caption = "Nhân viên";
            colEmpName.FieldName = "EmpName";
            colEmpName.Name = "colEmpName";
            colEmpName.Visible = true;
            colEmpName.VisibleIndex = 9;
            colEmpName.Width = 150;
            #endregion

            #region colStatusCode
            colStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatusCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStatusCode.AppearanceCell.Options.UseFont = true;
            colStatusCode.Caption = "Mã tình trạng";
            colStatusCode.FieldName = "StatusCode";
            colStatusCode.Name = "colStatusCode";
            colStatusCode.Visible = false;
            //colStatusCode.VisibleIndex = -1;
            colStatusCode.Width = 120;
            #endregion

            #region colStatusName
            colStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatusName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStatusName.AppearanceCell.Options.UseFont = true;
            colStatusName.Caption = "Tình trạng";
            colStatusName.FieldName = "StatusName";
            colStatusName.Name = "colStatusName";
            colStatusName.Visible = true;
            colStatusName.VisibleIndex = 10;
            colStatusName.Width = 150;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvProductSellLst.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvProductSellLst.OptionsBehavior.Editable = false;
            // Hiển thị filter
            //grvProductSellLst.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvProductSellLst.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductSellLst.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductSellLst.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductSellLst.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductSellLst.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductSellLst.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductSellLst.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            grvProductSellLst.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductSellLst.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colTrnID,
            colTrnCode,
            colTrnDate,
            colTrnTime,
            colCustID,
            colCustCode,
            colCustName,
            colQuantitySell,
            colDiscountTrn,
            colDiscountTotal,
            colAmountTotal,
            colAmountPay,
            colUnitPayment,
            colCurrencyCode,
            colCurrencyDesc,
            colNotes,
            colEmpID,
            colEmpCode,
            colEmpName,
            colStatusCode,
            colStatusName,
            });
            grvProductSellLst.DoubleClick += new System.EventHandler(this.grvProductSellLst_DoubleClick);
            #endregion
        }
        #endregion

        #region Function
        /// <summary>
        /// Khởi tạo datasource trên lưới
        /// </summary>
        /// <returns></returns>
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("TrnID", typeof(long));
            tblInit.Columns.Add("TrnCode", typeof(string));
            tblInit.Columns.Add("TrnDate", typeof(DateTime));
            tblInit.Columns.Add("TrnTime", typeof(TimeSpan));
            tblInit.Columns.Add("CustID", typeof(long));
            tblInit.Columns.Add("CustCode", typeof(string));
            tblInit.Columns.Add("CustName", typeof(string));
            tblInit.Columns.Add("DiscountTrn", typeof(decimal));
            tblInit.Columns.Add("DiscountTotal", typeof(decimal));
            tblInit.Columns.Add("AmountTotal", typeof(decimal));
            tblInit.Columns.Add("AmountPay", typeof(decimal));
            tblInit.Columns.Add("UnitPayment", typeof(decimal));
            tblInit.Columns.Add("CurrencyCode", typeof(string));
            tblInit.Columns.Add("CurrencyDesc", typeof(string));
            tblInit.Columns.Add("Notes", typeof(string));
            tblInit.Columns.Add("EmpID", typeof(long));
            tblInit.Columns.Add("EmpCode", typeof(string));
            tblInit.Columns.Add("EmpName", typeof(string));
            tblInit.Columns.Add("StatusCode", typeof(string));
            tblInit.Columns.Add("StatusName", typeof(string));
            tblInit.Columns.Add("QuantitySell", typeof(decimal));
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
        /// Load dữ liệu lên lưới
        /// </summary>
        private void LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                string sDateFrom = Convert.ToDateTime(dtpDateFrom.EditValue).ToString("dd/MM/yyyy");
                string sDateTo = Convert.ToDateTime(dtpDateTo.EditValue).ToString("dd/MM/yyyy");
                DTOTrnProductSell objTrnProductSell = new DTOTrnProductSell();
                objTrnProductSell.TrnCode = txtTrnCode.Text.Trim();
                objTrnProductSell.Customer.ID = cboCustomer.EditValue == null ? -1 : Convert.ToInt64(cboCustomer.EditValue);
                objTrnProductSell.Employee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnProductSell.StatusCode = cboStatus.EditValue == null ? string.Empty : Convert.ToString(cboStatus.EditValue);
                ds = BLLTrnProductSell.TrnProductSell_Lst(objTrnProductSell, sDateFrom, sDateTo, out sMessage);
                grcProductSellLst.DataSource = ds.Tables[0].Copy();
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
                dtpDateFrom.EditValue = DateTime.Now.AddDays(-7);
                dtpDateTo.EditValue = DateTime.Now;
                grcProductSellLst.DataSource = InitDataSourceGrid();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Load dữ liệu đã chọn qua form Nhập hàng
        /// </summary>
        /// <param name="_IsList">Gọi từ form thêm sản phẩm</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SelectClick(out bool _IsAdd)
        {
            _IsAdd = true;
            bool bResult = false;
            try
            {
                DataRow drSelect = grvProductSellLst.GetFocusedDataRow();
                if (drSelect == null)
                {
                    VMHMessages.ShowWarning("Vui lòng chọn dòng dữ liệu!");
                }
                if (drSelect["TrnID"] == DBNull.Value)
                {
                    VMHMessages.ShowWarning(MessagesText.TextGetTrnInfoFailure);
                }
                long lTrnID = Convert.ToInt64(drSelect["TrnID"]);
                if (gbFrmProductSellDtl == null)
                {
                    gbFrmProductSellDtl = new frmProductSellDtl(gbProductSell, lTrnID);                    
                    gbFrmProductSellDtl.gbTrnID = lTrnID;
                    gbFrmProductSellDtl.LoadDataToForm(lTrnID);
                }
                else
                {
                    gbFrmProductSellDtl.gbTrnID = lTrnID;
                    gbFrmProductSellDtl.LoadDataToForm(lTrnID);
                    _IsAdd = false;
                }
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            bool bIsAdd;
            if (SelectClick(out bIsAdd))
            {
                this.Hide();
                if (bIsAdd)
                {
                    gbFrmProductSellDtl.ShowDialog();
                }
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Gridview
        private void grvProductSellLst_DoubleClick(object sender, EventArgs e)
        {
            bool bIsAdd;
            if (SelectClick(out bIsAdd))
            {
                this.Hide();
                if (bIsAdd)
                {
                    gbFrmProductSellDtl.ShowDialog();
                }
                this.Close();
            }
        }
        #endregion
    }
}