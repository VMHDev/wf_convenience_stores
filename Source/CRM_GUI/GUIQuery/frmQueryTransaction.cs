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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_BLL.BLLCategories;
using CRM_BLL.BLLSystem;
using CRM_BLL.BLLProduct;

namespace CRM_GUI.GUIQuery
{
    public partial class frmQueryTransaction : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmQueryTransaction()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmQueryTransaction_Load(object sender, EventArgs e)
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
        public GridColumn colCboCustID { get; set; }
        public GridColumn colCboCustCode { get; set; }
        public GridColumn colCboCustName { get; set; }
        public GridColumn colCboCustAddress { get; set; }
        public GridColumn colCboCustPhone { get; set; }
        public GridColumn colCboIdentificationCard { get; set; }
        #endregion

        #region cboEmployee
        public GridView grvCboEmployee { get; set; }
        public GridColumn colCboEmpID { get; set; }
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

        #region Gridview ProductOut
        public GridColumn colPDOTrnID { get; set; }
        public GridColumn colPDOTrnCode { get; set; }
        public GridColumn colPDOTrnDate { get; set; }
        public GridColumn colPDOTrnTime { get; set; }
        public GridColumn colPDOStallsID { get; set; }
        public GridColumn colPDOStallsCode { get; set; }
        public GridColumn colPDOStallsName { get; set; }
        public GridColumn colPDOShopID { get; set; }
        public GridColumn colPDOShopCode { get; set; }
        public GridColumn colPDOShopName { get; set; }
        public GridColumn colPDONotes { get; set; }
        public GridColumn colPDOEmpID { get; set; }
        public GridColumn colPDOEmpCode { get; set; }
        public GridColumn colPDOEmpName { get; set; }
        public GridColumn colPDOStatusCode { get; set; }
        public GridColumn colPDOStatusName { get; set; }
        public GridColumn colPDOQuantityOut { get; set; }
        #endregion

        #region Gridview ProductSell
        public GridColumn colPDSTrnID { get; set; }
        public GridColumn colPDSTrnCode { get; set; }
        public GridColumn colPDSTrnDate { get; set; }
        public GridColumn colPDSTrnTime { get; set; }
        public GridColumn colPDSCustID { get; set; }
        public GridColumn colPDSCustCode { get; set; }
        public GridColumn colPDSCustName { get; set; }
        public GridColumn colPDSDiscountTrn { get; set; }
        public GridColumn colPDSDiscountTotal { get; set; }
        public GridColumn colPDSAmountTotal { get; set; }
        public GridColumn colPDSAmountPay { get; set; }
        public GridColumn colPDSUnitPayment { get; set; }
        public GridColumn colPDSCurrencyCode { get; set; }
        public GridColumn colPDSCurrencyDesc { get; set; }
        public GridColumn colPDSNotes { get; set; }
        public GridColumn colPDSEmpID { get; set; }
        public GridColumn colPDSEmpCode { get; set; }
        public GridColumn colPDSEmpName { get; set; }
        public GridColumn colPDSStatusCode { get; set; }
        public GridColumn colPDSStatusName { get; set; }
        public GridColumn colPDSQuantitySell { get; set; }
        #endregion
        #endregion

        private void DesignControls()
        {
            try
            {
                #region Form
                this.Text = "Tra cứu giao dịch";
                this.StartPosition = FormStartPosition.CenterParent;
                this.Load += new System.EventHandler(this.frmQueryTransaction_Load);
                #endregion

                DesignDateTimeEdit();
                DesignGridLookUpEdit();
                DesignGridViewProductOut();
                DesignGridViewProductSell();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
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
        /// Design lưới dữ liệu danh sách xuất hàng
        /// </summary>
        private void DesignGridViewProductOut()
        {
            #region colPDOTrnID
            colPDOTrnID = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOTrnID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOTrnID.AppearanceCell.Options.UseFont = true;
            colPDOTrnID.Caption = "ID giao dịch";
            colPDOTrnID.FieldName = "TrnID";
            colPDOTrnID.Name = "colPDOTrnID";
            colPDOTrnID.Visible = false;
            //colPDOTrnID.VisibleIndex = -1;
            colPDOTrnID.Width = 80;
            #endregion

            #region colPDOTrnCode
            colPDOTrnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOTrnCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOTrnCode.AppearanceCell.Options.UseFont = true;
            colPDOTrnCode.Caption = "Mã giao dịch";
            colPDOTrnCode.FieldName = "TrnCode";
            colPDOTrnCode.Name = "colPDOTrnCode";
            colPDOTrnCode.Visible = true;
            colPDOTrnCode.VisibleIndex = 0;
            colPDOTrnCode.Width = 150;
            #endregion

            #region colPDOTrnDate
            colPDOTrnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOTrnDate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOTrnDate.AppearanceCell.Options.UseFont = true;
            colPDOTrnDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            colPDOTrnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colPDOTrnDate.Caption = "Ngày";
            colPDOTrnDate.FieldName = "TrnDate";
            colPDOTrnDate.Name = "colPDOTrnDate";
            colPDOTrnDate.Visible = true;
            colPDOTrnDate.VisibleIndex = 1;
            colPDOTrnDate.Width = 150;
            #endregion

            #region colPDOTrnTime
            colPDOTrnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOTrnTime.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOTrnTime.AppearanceCell.Options.UseFont = true;
            colPDOTrnTime.DisplayFormat.FormatString = "HH:mm";
            colPDOTrnTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colPDOTrnTime.Caption = "Giờ";
            colPDOTrnTime.FieldName = "TrnTime";
            colPDOTrnTime.Name = "colPDOTrnTime";
            colPDOTrnTime.Visible = false;
            //colPDOTrnTime.VisibleIndex = -1;
            colPDOTrnTime.Width = 100;
            #endregion

            #region colPDOStallsID
            colPDOStallsID = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOStallsID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOStallsID.AppearanceCell.Options.UseFont = true;
            colPDOStallsID.Caption = "ID Quầy/kho";
            colPDOStallsID.FieldName = "StallsID";
            colPDOStallsID.Name = "colPDOStallsID";
            colPDOStallsID.Visible = false;
            //colPDOStallsID.VisibleIndex = -1;
            colPDOStallsID.Width = 80;
            #endregion

            #region colPDOStallsCode
            colPDOStallsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOStallsCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOStallsCode.AppearanceCell.Options.UseFont = true;
            colPDOStallsCode.Caption = "Mã Quầy/kho";
            colPDOStallsCode.FieldName = "StallsCode";
            colPDOStallsCode.Name = "colPDOStallsCode";
            colPDOStallsCode.Visible = false;
            //colPDOStallsCode.VisibleIndex = -1;
            colPDOStallsCode.Width = 120;
            #endregion

            #region colPDOStallsName
            colPDOStallsName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOStallsName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOStallsName.AppearanceCell.Options.UseFont = true;
            colPDOStallsName.Caption = "Quầy/kho";
            colPDOStallsName.FieldName = "StallsName";
            colPDOStallsName.Name = "colPDOStallsName";
            colPDOStallsName.Visible = true;
            colPDOStallsName.VisibleIndex = 2;
            colPDOStallsName.Width = 150;
            #endregion

            #region colPDOShopID
            colPDOShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOShopID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOShopID.AppearanceCell.Options.UseFont = true;
            colPDOShopID.Caption = "ID Cửa hàng";
            colPDOShopID.FieldName = "ShopID";
            colPDOShopID.Name = "colPDOShopID";
            colPDOShopID.Visible = false;
            //colPDOShopID.VisibleIndex = -1;
            colPDOShopID.Width = 80;
            #endregion

            #region colPDOShopCode
            colPDOShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOShopCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOShopCode.AppearanceCell.Options.UseFont = true;
            colPDOShopCode.Caption = "Mã Cửa hàng";
            colPDOShopCode.FieldName = "ShopCode";
            colPDOShopCode.Name = "colPDOShopCode";
            colPDOShopCode.Visible = false;
            //colPDOShopCode.VisibleIndex = -1;
            colPDOShopCode.Width = 120;
            #endregion

            #region colPDOShopName
            colPDOShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOShopName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOShopName.AppearanceCell.Options.UseFont = true;
            colPDOShopName.Caption = "Cửa hàng";
            colPDOShopName.FieldName = "ShopName";
            colPDOShopName.Name = "colPDOShopName";
            colPDOShopName.Visible = false;
            //colPDOShopName.VisibleIndex = -1;
            colPDOShopName.Width = 120;
            #endregion

            #region colPDOQuantityOut
            colPDOQuantityOut = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOQuantityOut.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOQuantityOut.AppearanceCell.Options.UseFont = true;
            colPDOQuantityOut.DisplayFormat.FormatString = "{0:#,##0}";
            colPDOQuantityOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPDOQuantityOut.Caption = "Số lượng xuất";
            colPDOQuantityOut.FieldName = "QuantityOut";
            colPDOQuantityOut.Name = "colPDOQuantityOut";
            colPDOQuantityOut.Visible = true;
            colPDOQuantityOut.VisibleIndex = 3;
            colPDOQuantityOut.Width = 150;
            #endregion

            #region colPDONotes
            colPDONotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDONotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDONotes.AppearanceCell.Options.UseFont = true;
            colPDONotes.Caption = "Ghi chú";
            colPDONotes.FieldName = "Notes";
            colPDONotes.Name = "colPDONotes";
            colPDONotes.Visible = true;
            colPDONotes.VisibleIndex = 4;
            colPDONotes.Width = 200;
            #endregion

            #region colPDOEmpID
            colPDOEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOEmpID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOEmpID.AppearanceCell.Options.UseFont = true;
            colPDOEmpID.Caption = "ID nhân viên";
            colPDOEmpID.FieldName = "EmpID";
            colPDOEmpID.Name = "colPDOEmpID";
            colPDOEmpID.Visible = false;
            //colPDOEmpID.VisibleIndex = -1;
            colPDOEmpID.Width = 80;
            #endregion

            #region colPDOEmpCode
            colPDOEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOEmpCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOEmpCode.AppearanceCell.Options.UseFont = true;
            colPDOEmpCode.Caption = "Mã nhân viên";
            colPDOEmpCode.FieldName = "EmpCode";
            colPDOEmpCode.Name = "colPDOEmpCode";
            colPDOEmpID.Visible = false;
            //colPDOEmpID.VisibleIndex = -1;
            colPDOEmpCode.Width = 120;
            #endregion

            #region colPDOEmpName
            colPDOEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOEmpName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOEmpName.AppearanceCell.Options.UseFont = true;
            colPDOEmpName.Caption = "Nhân viên";
            colPDOEmpName.FieldName = "EmpName";
            colPDOEmpName.Name = "colPDOEmpName";
            colPDOEmpName.Visible = true;
            colPDOEmpName.VisibleIndex = 5;
            colPDOEmpName.Width = 150;
            #endregion

            #region colPDOStatusCode
            colPDOStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOStatusCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOStatusCode.AppearanceCell.Options.UseFont = true;
            colPDOStatusCode.Caption = "Mã tình trạng";
            colPDOStatusCode.FieldName = "StatusCode";
            colPDOStatusCode.Name = "colPDOStatusCode";
            colPDOStatusCode.Visible = false;
            //colPDOStatusCode.VisibleIndex = -1;
            colPDOStatusCode.Width = 120;
            #endregion

            #region colPDOStatusName
            colPDOStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDOStatusName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDOStatusName.AppearanceCell.Options.UseFont = true;
            colPDOStatusName.Caption = "Tình trạng";
            colPDOStatusName.FieldName = "StatusName";
            colPDOStatusName.Name = "colPDOStatusName";
            colPDOStatusName.Visible = true;
            colPDOStatusName.VisibleIndex = 6;
            colPDOStatusName.Width = 150;
            #endregion

            #region Gridview
            layoutControlItemGridViewProductOut.TextVisible = false;
            grvQueryProductOut.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvQueryProductOut.OptionsBehavior.Editable = false;
            // Hiển thị filter
            //grvQueryProductOut.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvQueryProductOut.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvQueryProductOut.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvQueryProductOut.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvQueryProductOut.Appearance.HeaderPanel.Options.UseFont = true;
            grvQueryProductOut.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvQueryProductOut.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvQueryProductOut.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            // grvQueryProductOut.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvQueryProductOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colPDOTrnID,
                colPDOTrnCode,
                colPDOTrnDate,
                colPDOTrnTime,
                colPDOStallsID,
                colPDOStallsCode,
                colPDOStallsName,
                colPDOShopID,
                colPDOShopCode,
                colPDOShopName,
                colPDONotes,
                colPDOEmpID,
                colPDOEmpCode,
                colPDOEmpName,
                colPDOStatusCode,
                colPDOStatusName,
                colPDOQuantityOut
            });
            //grvQueryProductOut.DoubleClick += new System.EventHandler(this.grvQueryProductOut_DoubleClick);
            #endregion
        }

        /// <summary>
        /// Design lưới dữ liệu
        /// </summary>
        private void DesignGridViewProductSell()
        {
            #region colPDSTrnID
            colPDSTrnID = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSTrnID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSTrnID.AppearanceCell.Options.UseFont = true;
            colPDSTrnID.Caption = "ID giao dịch";
            colPDSTrnID.FieldName = "TrnID";
            colPDSTrnID.Name = "colPDSTrnID";
            colPDSTrnID.Visible = false;
            //colPDSTrnID.VisibleIndex = -1;
            colPDSTrnID.Width = 80;
            #endregion

            #region colPDSTrnCode
            colPDSTrnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSTrnCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSTrnCode.AppearanceCell.Options.UseFont = true;
            colPDSTrnCode.Caption = "Mã giao dịch";
            colPDSTrnCode.FieldName = "TrnCode";
            colPDSTrnCode.Name = "colPDSTrnCode";
            colPDSTrnCode.Visible = true;
            colPDSTrnCode.VisibleIndex = 0;
            colPDSTrnCode.Width = 150;
            #endregion

            #region colPDSTrnDate
            colPDSTrnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSTrnDate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSTrnDate.AppearanceCell.Options.UseFont = true;
            colPDSTrnDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            colPDSTrnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colPDSTrnDate.Caption = "Ngày";
            colPDSTrnDate.FieldName = "TrnDate";
            colPDSTrnDate.Name = "colPDSTrnDate";
            colPDSTrnDate.Visible = true;
            colPDSTrnDate.VisibleIndex = 1;
            colPDSTrnDate.Width = 150;
            #endregion

            #region colPDSTrnTime
            colPDSTrnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSTrnTime.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSTrnTime.AppearanceCell.Options.UseFont = true;
            colPDSTrnTime.DisplayFormat.FormatString = "HH:mm";
            colPDSTrnTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colPDSTrnTime.Caption = "Giờ";
            colPDSTrnTime.FieldName = "TrnTime";
            colPDSTrnTime.Name = "colPDSTrnTime";
            colPDSTrnTime.Visible = false;
            //colPDSTrnTime.VisibleIndex = -1;
            colPDSTrnTime.Width = 100;
            #endregion

            #region colPDSCustID
            colPDSCustID = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSCustID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSCustID.AppearanceCell.Options.UseFont = true;
            colPDSCustID.Caption = "ID khách hàng";
            colPDSCustID.FieldName = "CustID";
            colPDSCustID.Name = "colPDSCustID";
            colPDSCustID.Visible = false;
            //colPDSCustID.VisibleIndex = -1;
            colPDSCustID.Width = 80;
            #endregion

            #region colPDSCustCode
            colPDSCustCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSCustCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSCustCode.AppearanceCell.Options.UseFont = true;
            colPDSCustCode.Caption = "Mã khách hàng";
            colPDSCustCode.FieldName = "CustCode";
            colPDSCustCode.Name = "colPDSCustCode";
            colPDSCustCode.Visible = false;
            //colPDSCustCode.VisibleIndex = -1;
            colPDSCustCode.Width = 120;
            #endregion

            #region colPDSCustName
            colPDSCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSCustName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSCustName.AppearanceCell.Options.UseFont = true;
            colPDSCustName.Caption = "Khách hàng";
            colPDSCustName.FieldName = "CustName";
            colPDSCustName.Name = "colPDSCustName";
            colPDSCustName.Visible = true;
            colPDSCustName.VisibleIndex = 2;
            colPDSCustName.Width = 150;
            #endregion

            #region colPDSQuantitySell
            colPDSQuantitySell = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSQuantitySell.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSQuantitySell.AppearanceCell.Options.UseFont = true;
            colPDSQuantitySell.DisplayFormat.FormatString = "{0:#,##0}";
            colPDSQuantitySell.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPDSQuantitySell.Caption = "Số lượng /Trọng lượng bán";
            colPDSQuantitySell.FieldName = "QuantitySell";
            colPDSQuantitySell.Name = "colPDSQuantitySell";
            colPDSQuantitySell.Visible = true;
            colPDSQuantitySell.VisibleIndex = 3;
            colPDSQuantitySell.Width = 200;
            #endregion

            #region colPDSDiscountTrn
            colPDSDiscountTrn = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSDiscountTrn.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSDiscountTrn.AppearanceCell.Options.UseFont = true;
            colPDSDiscountTrn.DisplayFormat.FormatString = "{0:#,##0}";
            colPDSDiscountTrn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPDSDiscountTrn.Caption = "Tiền giảm";
            colPDSDiscountTrn.FieldName = "DiscountTrn";
            colPDSDiscountTrn.Name = "colPDSDiscountTrn";
            colPDSDiscountTrn.Visible = true;
            colPDSDiscountTrn.VisibleIndex = 4;
            colPDSDiscountTrn.Width = 150;
            #endregion

            #region colPDSDiscountTotal
            colPDSDiscountTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSDiscountTotal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSDiscountTotal.AppearanceCell.Options.UseFont = true;
            colPDSDiscountTotal.DisplayFormat.FormatString = "{0:#,##0}";
            colPDSDiscountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPDSDiscountTotal.Caption = "Tổng tiền giảm";
            colPDSDiscountTotal.FieldName = "DiscountTotal";
            colPDSDiscountTotal.Name = "colPDSDiscountTotal";
            colPDSDiscountTotal.Visible = true;
            colPDSDiscountTotal.VisibleIndex = 5;
            colPDSDiscountTotal.Width = 150;
            #endregion

            #region colPDSAmountTotal
            colPDSAmountTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSAmountTotal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSAmountTotal.AppearanceCell.Options.UseFont = true;
            colPDSAmountTotal.DisplayFormat.FormatString = "{0:#,##0}";
            colPDSAmountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPDSAmountTotal.Caption = "Tổng tiền";
            colPDSAmountTotal.FieldName = "AmountTotal";
            colPDSAmountTotal.Name = "colPDSAmountTotal";
            colPDSAmountTotal.Visible = true;
            colPDSAmountTotal.VisibleIndex = 6;
            colPDSAmountTotal.Width = 150;
            #endregion

            #region colPDSAmountPay
            colPDSAmountPay = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSAmountPay.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSAmountPay.AppearanceCell.Options.UseFont = true;
            colPDSAmountPay.DisplayFormat.FormatString = "{0:#,##0}";
            colPDSAmountPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPDSAmountPay.Caption = "Khách trả";
            colPDSAmountPay.FieldName = "AmountPay";
            colPDSAmountPay.Name = "colPDSAmountPay";
            colPDSAmountPay.Visible = true;
            colPDSAmountPay.VisibleIndex = 7;
            colPDSAmountPay.Width = 150;
            #endregion

            #region colPDSUnitPayment
            colPDSUnitPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSUnitPayment.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSUnitPayment.AppearanceCell.Options.UseFont = true;
            colPDSUnitPayment.Caption = "ID Đơn vị thanh toán";
            colPDSUnitPayment.FieldName = "UnitPayment";
            colPDSUnitPayment.Name = "colPDSUnitPayment";
            colPDSUnitPayment.Visible = false;
            //colPDSUnitPayment.VisibleIndex = -1;
            colPDSUnitPayment.Width = 80;
            #endregion

            #region colPDSCurrencyCode
            colPDSCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSCurrencyCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSCurrencyCode.AppearanceCell.Options.UseFont = true;
            colPDSCurrencyCode.Caption = "Mã Đơn vị thanh toán";
            colPDSCurrencyCode.FieldName = "CustCode";
            colPDSCurrencyCode.Name = "colPDSCurrencyCode";
            colPDSCurrencyCode.Visible = false;
            //colPDSCurrencyCode.VisibleIndex = -1;
            colPDSCurrencyCode.Width = 120;
            #endregion

            #region colPDSCurrencyDesc
            colPDSCurrencyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSCurrencyDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSCurrencyDesc.AppearanceCell.Options.UseFont = true;
            colPDSCurrencyDesc.Caption = "Đơn vị thanh toán";
            colPDSCurrencyDesc.FieldName = "CurrencyDesc";
            colPDSCurrencyDesc.Name = "colPDSCurrencyDesc";
            colPDSCurrencyDesc.Visible = false;
            //colPDSCurrencyDesc.VisibleIndex = -1;
            colPDSCurrencyDesc.Width = 120;
            #endregion

            #region colPDSNotes
            colPDSNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSNotes.AppearanceCell.Options.UseFont = true;
            colPDSNotes.Caption = "Ghi chú";
            colPDSNotes.FieldName = "Notes";
            colPDSNotes.Name = "colPDSNotes";
            colPDSNotes.Visible = true;
            colPDSNotes.VisibleIndex = 8;
            colPDSNotes.Width = 180;
            #endregion

            #region colPDSEmpID
            colPDSEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSEmpID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSEmpID.AppearanceCell.Options.UseFont = true;
            colPDSEmpID.Caption = "ID nhân viên";
            colPDSEmpID.FieldName = "EmpID";
            colPDSEmpID.Name = "colPDSEmpID";
            colPDSEmpID.Visible = false;
            //colPDSEmpID.VisibleIndex = -1;
            colPDSEmpID.Width = 80;
            #endregion

            #region colPDSEmpCode
            colPDSEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSEmpCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSEmpCode.AppearanceCell.Options.UseFont = true;
            colPDSEmpCode.Caption = "Mã nhân viên";
            colPDSEmpCode.FieldName = "EmpCode";
            colPDSEmpCode.Name = "colPDSEmpCode";
            colPDSEmpCode.Visible = false;
            //colPDSEmpCode.VisibleIndex = -1;
            colPDSEmpCode.Width = 120;
            #endregion

            #region colPDSEmpName
            colPDSEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSEmpName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSEmpName.AppearanceCell.Options.UseFont = true;
            colPDSEmpName.Caption = "Nhân viên";
            colPDSEmpName.FieldName = "EmpName";
            colPDSEmpName.Name = "colPDSEmpName";
            colPDSEmpName.Visible = true;
            colPDSEmpName.VisibleIndex = 9;
            colPDSEmpName.Width = 150;
            #endregion

            #region colPDSStatusCode
            colPDSStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSStatusCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSStatusCode.AppearanceCell.Options.UseFont = true;
            colPDSStatusCode.Caption = "Mã tình trạng";
            colPDSStatusCode.FieldName = "StatusCode";
            colPDSStatusCode.Name = "colPDSStatusCode";
            colPDSStatusCode.Visible = false;
            //colPDSStatusCode.VisibleIndex = -1;
            colPDSStatusCode.Width = 120;
            #endregion

            #region colPDSStatusName
            colPDSStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            colPDSStatusName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPDSStatusName.AppearanceCell.Options.UseFont = true;
            colPDSStatusName.Caption = "Tình trạng";
            colPDSStatusName.FieldName = "StatusName";
            colPDSStatusName.Name = "colPDSStatusName";
            colPDSStatusName.Visible = true;
            colPDSStatusName.VisibleIndex = 10;
            colPDSStatusName.Width = 150;
            #endregion

            #region Gridview
            layoutControlItemGridViewProductSell.TextVisible = false;
            grvQueryProductSell.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvQueryProductSell.OptionsBehavior.Editable = false;
            // Hiển thị filter
            //grvQueryProductSell.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvQueryProductSell.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvQueryProductSell.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvQueryProductSell.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvQueryProductSell.Appearance.HeaderPanel.Options.UseFont = true;
            grvQueryProductSell.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvQueryProductSell.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvQueryProductSell.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            grvQueryProductSell.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvQueryProductSell.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colPDSTrnID,
            colPDSTrnCode,
            colPDSTrnDate,
            colPDSTrnTime,
            colPDSCustID,
            colPDSCustCode,
            colPDSCustName,
            colPDSQuantitySell,
            colPDSDiscountTrn,
            colPDSDiscountTotal,
            colPDSAmountTotal,
            colPDSAmountPay,
            colPDSUnitPayment,
            colPDSCurrencyCode,
            colPDSCurrencyDesc,
            colPDSNotes,
            colPDSEmpID,
            colPDSEmpCode,
            colPDSEmpName,
            colPDSStatusCode,
            colPDSStatusName,
            });
            //grvQueryProductSell.DoubleClick += new System.EventHandler(this.grvQueryProductSell_DoubleClick);
            #endregion
        }
        #endregion

        #region Functions
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("TrnID", typeof(long));
            tblInit.Columns.Add("TrnCode", typeof(string));
            tblInit.Columns.Add("TrnDate", typeof(DateTime));
            tblInit.Columns.Add("TrnTime", typeof(TimeSpan));
            tblInit.Columns.Add("StallsID", typeof(long));
            tblInit.Columns.Add("StallsCode", typeof(string));
            tblInit.Columns.Add("StallsName", typeof(string));
            tblInit.Columns.Add("ShopID", typeof(long));
            tblInit.Columns.Add("ShopCode", typeof(string));
            tblInit.Columns.Add("ShopName", typeof(string));
            tblInit.Columns.Add("Notes", typeof(string));
            tblInit.Columns.Add("EmpID", typeof(long));
            tblInit.Columns.Add("EmpCode", typeof(string));
            tblInit.Columns.Add("EmpName", typeof(string));
            tblInit.Columns.Add("StatusCode", typeof(string));
            tblInit.Columns.Add("StatusName", typeof(string));
            tblInit.Columns.Add("QuantityOut", typeof(decimal));
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
                ds = BLLSysStatus.LoadDataCombobox("STATUS_TRN_PRODUCT_OUT", out sMessages);
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
                string sTrnCode = txtTrnCode.Text.Trim();
                long lEmpID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                long lCustID = cboCustomer.EditValue == null ? -1 : Convert.ToInt64(cboCustomer.EditValue);
                string sStatusCode = cboStatus.EditValue == null ? string.Empty : Convert.ToString(cboStatus.EditValue);
                ds = BLLProduct.Product_QueryTransaction(sTrnCode, sDateFrom, sDateTo, lCustID, lEmpID, sStatusCode, out sMessage);
                grcQueryProductSell.DataSource = ds.Tables[0].Copy();
                grcQueryProductOut.DataSource = ds.Tables[1].Copy();
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
                grcQueryProductOut.DataSource = InitDataSourceGrid();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }
        #endregion

        #region Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        #endregion
    }
}