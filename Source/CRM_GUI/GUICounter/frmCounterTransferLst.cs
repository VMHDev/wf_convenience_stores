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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using CRM_GUI.CRMUtility.Messages;
using CRM_BLL.BLLCategories;
using CRM_BLL.BLLSystem;
using CRM_DTO.DTOCounter;
using CRM_BLL.BLLCounter;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUICounter
{
    public partial class frmCounterTransferLst : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private frmCounterTransfer gbFrmCounterTransfer = null;
        #endregion

        #region Form
        public frmCounterTransferLst()
        {
            InitializeComponent();
            DesignControls();
        }

        public frmCounterTransferLst(frmCounterTransfer _Frm)
        {
            InitializeComponent();
            DesignControls();
            gbFrmCounterTransfer = _Frm;
        }

        private void frmCounterTransferLst_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            LoadDataToGrid();
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboCounterFrom
        public GridView grvCboCounterFrom { get; set; }
        public GridColumn colCboCounterFromCode { get; set; }
        public GridColumn colCboCounterFromName { get; set; }
        public GridColumn colCboCounterFromShopName { get; set; }
        #endregion

        #region cboCounterTo
        public GridView grvCboCounterTo { get; set; }
        public GridColumn colCboCounterToCode { get; set; }
        public GridColumn colCboCounterToName { get; set; }
        public GridColumn colCboCounterToShopName { get; set; }
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
        public GridColumn colCounterFromID { get; set; }
        public GridColumn colCounterFromCode { get; set; }
        public GridColumn colCounterFromName { get; set; }
        public GridColumn colCounterToID { get; set; }
        public GridColumn colCounterToCode { get; set; }
        public GridColumn colCounterToName { get; set; }
        public GridColumn colNotes { get; set; }
        public GridColumn colEmpID { get; set; }
        public GridColumn colEmpCode { get; set; }
        public GridColumn colEmpName { get; set; }
        public GridColumn colStatusCode { get; set; }
        public GridColumn colStatusName { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Danh sách chuyển quầy";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmCounterTransferLst_Load);
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
            #region cboCounterFrom
            //
            // colCboCounterFromCode
            //
            this.colCboCounterFromCode = new GridColumn();
            this.colCboCounterFromCode.Caption = "Mã quầy thu ngân";
            this.colCboCounterFromCode.FieldName = "CounterCode";
            this.colCboCounterFromCode.Name = "colCboCounterFromCode";
            this.colCboCounterFromCode.Visible = true;
            this.colCboCounterFromCode.VisibleIndex = 0;
            //
            // colCboCounterFromName
            //
            this.colCboCounterFromName = new GridColumn();
            this.colCboCounterFromName.Caption = "Tên quầy thu ngân";
            this.colCboCounterFromName.FieldName = "CounterName";
            this.colCboCounterFromName.Name = "colCboCounterFromName";
            this.colCboCounterFromName.Visible = true;
            this.colCboCounterFromName.VisibleIndex = 1;
            //
            // colCboCounterFromShopName
            //
            this.colCboCounterFromShopName = new GridColumn();
            this.colCboCounterFromShopName.Caption = "Tên cửa hàng";
            this.colCboCounterFromShopName.FieldName = "ShopName";
            this.colCboCounterFromShopName.Name = "colCboCounterFromShopName";
            this.colCboCounterFromShopName.Visible = true;
            this.colCboCounterFromShopName.VisibleIndex = 2;
            // 
            // grvCboCounterFrom
            // 
            this.grvCboCounterFrom = new GridView();
            this.grvCboCounterFrom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboCounterFromCode,
            this.colCboCounterFromName});
            this.grvCboCounterFrom.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCounterFrom.Name = "grvCboCounterFrom";
            this.grvCboCounterFrom.OptionsBehavior.Editable = false;
            this.grvCboCounterFrom.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCounterFrom.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCounterFrom.OptionsView.ShowGroupPanel = false;
            this.grvCboCounterFrom.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCounterFrom.Appearance.Row.Options.UseFont = true;
            this.grvCboCounterFrom.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCounterFrom.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboCounterFrom.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboCounterFrom.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboCounterFrom.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboCounterFrom
            // 
            this.cboCounterFrom.Name = "cboCounterFrom";
            this.cboCounterFrom.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterFrom.Properties.Appearance.Options.UseFont = true;
            this.cboCounterFrom.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterFrom.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCounterFrom.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterFrom.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCounterFrom.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterFrom.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCounterFrom.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterFrom.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCounterFrom.Properties.NullText = "";
            this.cboCounterFrom.Properties.ShowFooter = false;
            this.cboCounterFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCounterFrom.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCounterFrom.Properties.View = this.grvCboCounterFrom;
            //this.cboCounterFrom.EditValueChanged += new System.EventHandler(this.cboCounterFrom_EditValueChanged);
            #endregion

            #region cboCounterTo
            //
            // colCboCounterToCode
            //
            this.colCboCounterToCode = new GridColumn();
            this.colCboCounterToCode.Caption = "Mã quầy thu ngân";
            this.colCboCounterToCode.FieldName = "CounterCode";
            this.colCboCounterToCode.Name = "colCboCounterToCode";
            this.colCboCounterToCode.Visible = true;
            this.colCboCounterToCode.VisibleIndex = 0;
            //
            // colCboCounterToName
            //
            this.colCboCounterToName = new GridColumn();
            this.colCboCounterToName.Caption = "Tên quầy thu ngân";
            this.colCboCounterToName.FieldName = "CounterName";
            this.colCboCounterToName.Name = "colCboCounterToName";
            this.colCboCounterToName.Visible = true;
            this.colCboCounterToName.VisibleIndex = 1;
            //
            // colCboCounterToShopName
            //
            this.colCboCounterToShopName = new GridColumn();
            this.colCboCounterToShopName.Caption = "Tên cửa hàng";
            this.colCboCounterToShopName.FieldName = "ShopName";
            this.colCboCounterToShopName.Name = "colCboCounterToShopName";
            this.colCboCounterToShopName.Visible = true;
            this.colCboCounterToShopName.VisibleIndex = 2;
            // 
            // grvCboCounterTo
            // 
            this.grvCboCounterTo = new GridView();
            this.grvCboCounterTo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboCounterToCode,
            this.colCboCounterToName});
            this.grvCboCounterTo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCounterTo.Name = "grvCboCounterTo";
            this.grvCboCounterTo.OptionsBehavior.Editable = false;
            this.grvCboCounterTo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCounterTo.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCounterTo.OptionsView.ShowGroupPanel = false;
            this.grvCboCounterTo.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCounterTo.Appearance.Row.Options.UseFont = true;
            this.grvCboCounterTo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCounterTo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboCounterTo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboCounterTo.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboCounterTo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboCounterTo
            // 
            this.cboCounterTo.Name = "cboCounterTo";
            this.cboCounterTo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterTo.Properties.Appearance.Options.UseFont = true;
            this.cboCounterTo.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterTo.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCounterTo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterTo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCounterTo.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterTo.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCounterTo.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounterTo.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCounterTo.Properties.NullText = "";
            this.cboCounterTo.Properties.ShowFooter = false;
            this.cboCounterTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCounterTo.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCounterTo.Properties.View = this.grvCboCounterTo;
            //this.cboCounterTo.EditValueChanged += new System.EventHandler(this.cboCounterTo_EditValueChanged);
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
            colTrnCode.Width = 120;
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
            colTrnDate.Width = 100;
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

            #region colCounterFromID
            colCounterFromID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterFromID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterFromID.AppearanceCell.Options.UseFont = true;
            colCounterFromID.Caption = "ID Quầy chuyển";
            colCounterFromID.FieldName = "ID";
            colCounterFromID.Name = "colCounterFromID";
            colCounterFromID.Visible = false;
            //colCounterFromID.VisibleIndex = -1;
            colCounterFromID.Width = 80;
            #endregion

            #region colCounterFromCode
            colCounterFromCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterFromCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterFromCode.AppearanceCell.Options.UseFont = true;
            colCounterFromCode.Caption = "Mã Quầy chuyển";
            colCounterFromCode.FieldName = "CounterFromCode";
            colCounterFromCode.Name = "colCounterFromCode";
            colCounterToID.Visible = false;
            //colCounterToID.VisibleIndex = -1;
            colCounterFromCode.Width = 120;
            #endregion

            #region colCounterFromName
            colCounterFromName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterFromName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterFromName.AppearanceCell.Options.UseFont = true;
            colCounterFromName.Caption = "Quầy chuyển";
            colCounterFromName.FieldName = "CounterFromName";
            colCounterFromName.Name = "colCounterFromName";
            colCounterFromName.Visible = true;
            colCounterFromName.VisibleIndex = 2;
            colCounterFromName.Width = 150;
            #endregion

            #region colCounterToID
            colCounterToID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterToID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterToID.AppearanceCell.Options.UseFont = true;
            colCounterToID.Caption = "ID Quầy nhận";
            colCounterToID.FieldName = "CounterToID";
            colCounterToID.Name = "colCounterToID";
            colCounterToID.Visible = false;
            //colCounterToID.VisibleIndex = -1;
            colCounterToID.Width = 80;
            #endregion

            #region colCounterToCode
            colCounterToCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterToCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterToCode.AppearanceCell.Options.UseFont = true;
            colCounterToCode.Caption = "Mã Quầy nhận";
            colCounterToCode.FieldName = "CounterToCode";
            colCounterToCode.Name = "colCounterToCode";
            colCounterToID.Visible = false;
            //colCounterToID.VisibleIndex = -1;
            colCounterToCode.Width = 120;
            #endregion

            #region colCounterToName
            colCounterToName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterToName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterToName.AppearanceCell.Options.UseFont = true;
            colCounterToName.Caption = "Quầy nhận";
            colCounterToName.FieldName = "CounterToName";
            colCounterToName.Name = "colCounterToName";
            colCounterToName.Visible = true;
            colCounterToName.VisibleIndex = 3;
            colCounterToName.Width = 150;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 4;
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
            colCounterToID.Visible = false;
            //colCounterToID.VisibleIndex = -1;
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
            colEmpName.VisibleIndex = 5;
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
            colStatusName.VisibleIndex = 6;
            colStatusName.Width = 150;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvCounterTransferLst.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvCounterTransferLst.OptionsBehavior.Editable = false;
            // Hiển thị filter
            //grvCounterTransferLst.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvCounterTransferLst.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterTransferLst.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCounterTransferLst.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterTransferLst.Appearance.HeaderPanel.Options.UseFont = true;
            grvCounterTransferLst.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCounterTransferLst.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCounterTransferLst.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCounterTransferLst.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCounterTransferLst.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colTrnID,
            colTrnCode,
            colTrnDate,
            colTrnTime,
            colCounterFromID,
            colCounterFromCode,
            colCounterFromName,
            colCounterToID,
            colCounterToCode,
            colCounterToName,
            colNotes,
            colEmpID,
            colEmpCode,
            colEmpName,
            colStatusCode,
            colStatusName,
            });
            grvCounterTransferLst.DoubleClick += new System.EventHandler(this.grvCounterTransferLst_DoubleClick);
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
            tblInit.Columns.Add("CounterFromID", typeof(long));
            tblInit.Columns.Add("CounterFromCode", typeof(string));
            tblInit.Columns.Add("CounterFromName", typeof(string));
            tblInit.Columns.Add("CounterToID", typeof(long));
            tblInit.Columns.Add("CounterToCode", typeof(string));
            tblInit.Columns.Add("CounterToName", typeof(string));
            tblInit.Columns.Add("Notes", typeof(string));
            tblInit.Columns.Add("EmpID", typeof(long));
            tblInit.Columns.Add("EmpCode", typeof(string));
            tblInit.Columns.Add("EmpName", typeof(string));
            tblInit.Columns.Add("StatusCode", typeof(string));
            tblInit.Columns.Add("StatusName", typeof(string));
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
                ds = BLLCatCounter.LoadDataCombobox(-1, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboCounterFrom.Properties.DataSource = ds.Tables[0].Copy();
                    cboCounterFrom.Properties.DisplayMember = "CounterName";
                    cboCounterFrom.Properties.ValueMember = "CounterID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatCounter.LoadDataCombobox(-1, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboCounterTo.Properties.DataSource = ds.Tables[0].Copy();
                    cboCounterTo.Properties.DisplayMember = "CounterName";
                    cboCounterTo.Properties.ValueMember = "CounterID";
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
                ds = BLLSysStatus.LoadDataCombobox("STATUS_TRN_COUNTER_TRANSFER", out sMessages);
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
                DTOTrnCounterTransfer objTrnCounterTransfer = new DTOTrnCounterTransfer();
                objTrnCounterTransfer.TrnCode = txtTrnCode.Text.Trim();
                DTOCatEmployee objEmployee = new DTOCatEmployee();
                objEmployee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnCounterTransfer.Employee = objEmployee;
                objTrnCounterTransfer.StatusCode = cboStatus.EditValue == null ? string.Empty : Convert.ToString(cboStatus.EditValue);
                ds = BLLTrnCounterTransfer.TrnCounterTransfer_Lst(objTrnCounterTransfer, sDateFrom, sDateTo, out sMessage);
                grcCounterTransferLst.DataSource = ds.Tables[0].Copy();
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
                grcCounterTransferLst.DataSource = InitDataSourceGrid();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Load dữ liệu đã chọn qua form Nhập hàng
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SelectClick()
        {
            bool bResult = false;
            try
            {
                DataRow drSelect = grvCounterTransferLst.GetFocusedDataRow();
                if (drSelect == null)
                {
                    VMHMessages.ShowWarning("Vui lòng chọn dòng dữ liệu!");
                }
                if (drSelect["TrnID"] == DBNull.Value)
                {
                    VMHMessages.ShowWarning(MessagesText.TextGetTrnInfoFailure);
                }
                long sTrnID = Convert.ToInt64(drSelect["TrnID"]);
                gbFrmCounterTransfer.gbTrnID = sTrnID;
                gbFrmCounterTransfer.LoadDataToForm(sTrnID);
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
            if (SelectClick())
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Gridview
        private void grvCounterTransferLst_DoubleClick(object sender, EventArgs e)
        {
            if (SelectClick())
            {
                this.Close();
            }
        }
        #endregion
    }
}