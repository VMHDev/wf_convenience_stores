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
using CRM_DTO.DTOProduct;
using CRM_BLL.BLLProduct;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductTransferLst : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private frmProductTransfer gbFrmProductTransfer = null;
        #endregion

        #region Form
        public frmProductTransferLst()
        {
            InitializeComponent();
            DesignControls();
        }

        public frmProductTransferLst(frmProductTransfer _Frm)
        {
            InitializeComponent();
            DesignControls();
            gbFrmProductTransfer = _Frm;
        }


        private void frmProductTransferLst_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            LoadDataToGrid();
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboStallsFrom
        public GridView grvCboStallsFrom { get; set; }
        public GridColumn colCboStallsFromCode { get; set; }
        public GridColumn colCboStallsFromName { get; set; }
        #endregion

        #region cboStallsTo
        public GridView grvCboStallsTo { get; set; }
        public GridColumn colCboStallsToCode { get; set; }
        public GridColumn colCboStallsToName { get; set; }
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
        public GridColumn colStallsFromID { get; set; }
        public GridColumn colStallsFromCode { get; set; }
        public GridColumn colStallsFromName { get; set; }
        public GridColumn colStallsToID { get; set; }
        public GridColumn colStallsToCode { get; set; }
        public GridColumn colStallsToName { get; set; }
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
            this.Text = "Danh sách nhập hàng";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmProductTransferLst_Load);
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
        /// Desin GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
            #region cboStallsFrom
            //
            // colCboStallsFromCode
            //
            this.colCboStallsFromCode = new GridColumn();
            this.colCboStallsFromCode.Caption = "Mã quầy/kho";
            this.colCboStallsFromCode.FieldName = "StallsCode";
            this.colCboStallsFromCode.Name = "colCboStallsFromCode";
            this.colCboStallsFromCode.Visible = true;
            this.colCboStallsFromCode.VisibleIndex = 0;
            //
            // colCboStallsFromName
            //
            this.colCboStallsFromName = new GridColumn();
            this.colCboStallsFromName.Caption = "Tên quầy/kho";
            this.colCboStallsFromName.FieldName = "StallsName";
            this.colCboStallsFromName.Name = "colCboStallsFromName";
            this.colCboStallsFromName.Visible = true;
            this.colCboStallsFromName.VisibleIndex = 1;
            // 
            // grvCboStallsFrom
            // 
            this.grvCboStallsFrom = new GridView();
            this.grvCboStallsFrom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboStallsFromCode,
            this.colCboStallsFromName});
            this.grvCboStallsFrom.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboStallsFrom.Name = "grvCboStallsFrom";
            this.grvCboStallsFrom.OptionsBehavior.Editable = false;
            this.grvCboStallsFrom.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboStallsFrom.OptionsView.ShowAutoFilterRow = true;
            this.grvCboStallsFrom.OptionsView.ShowGroupPanel = false;
            this.grvCboStallsFrom.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStallsFrom.Appearance.Row.Options.UseFont = true;
            this.grvCboStallsFrom.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStallsFrom.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboStallsFrom.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboStallsFrom.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboStallsFrom.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboStallsFrom
            // 
            this.cboStallsFrom.Name = "cboStallsFrom";
            this.cboStallsFrom.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsFrom.Properties.Appearance.Options.UseFont = true;
            this.cboStallsFrom.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsFrom.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboStallsFrom.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsFrom.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboStallsFrom.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsFrom.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboStallsFrom.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsFrom.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboStallsFrom.Properties.NullText = "";
            this.cboStallsFrom.Properties.ShowFooter = false;
            this.cboStallsFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboStallsFrom.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboStallsFrom.Properties.View = this.grvCboStallsFrom;
            //this.cboStallsFrom.EditValueChanged += new System.EventHandler(this.cboStallsFrom_EditValueChanged);
            #endregion

            #region cboStallsTo
            //
            // colCboStallsToCode
            //
            this.colCboStallsToCode = new GridColumn();
            this.colCboStallsToCode.Caption = "Mã quầy/kho";
            this.colCboStallsToCode.FieldName = "StallsCode";
            this.colCboStallsToCode.Name = "colCboStallsToCode";
            this.colCboStallsToCode.Visible = true;
            this.colCboStallsToCode.VisibleIndex = 0;
            //
            // colCboStallsToName
            //
            this.colCboStallsToName = new GridColumn();
            this.colCboStallsToName.Caption = "Tên quầy/kho";
            this.colCboStallsToName.FieldName = "StallsName";
            this.colCboStallsToName.Name = "colCboStallsToName";
            this.colCboStallsToName.Visible = true;
            this.colCboStallsToName.VisibleIndex = 1;
            // 
            // grvCboStallsTo
            // 
            this.grvCboStallsTo = new GridView();
            this.grvCboStallsTo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboStallsToCode,
            this.colCboStallsToName});
            this.grvCboStallsTo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboStallsTo.Name = "grvCboStallsTo";
            this.grvCboStallsTo.OptionsBehavior.Editable = false;
            this.grvCboStallsTo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboStallsTo.OptionsView.ShowAutoFilterRow = true;
            this.grvCboStallsTo.OptionsView.ShowGroupPanel = false;
            this.grvCboStallsTo.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStallsTo.Appearance.Row.Options.UseFont = true;
            this.grvCboStallsTo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStallsTo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboStallsTo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboStallsTo.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboStallsTo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboStallsTo
            // 
            this.cboStallsTo.Name = "cboStallsTo";
            this.cboStallsTo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsTo.Properties.Appearance.Options.UseFont = true;
            this.cboStallsTo.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsTo.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboStallsTo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsTo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboStallsTo.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsTo.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboStallsTo.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStallsTo.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboStallsTo.Properties.NullText = "";
            this.cboStallsTo.Properties.ShowFooter = false;
            this.cboStallsTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboStallsTo.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboStallsTo.Properties.View = this.grvCboStallsTo;
            //this.cboStallsTo.EditValueChanged += new System.EventHandler(this.cboStallsTo_EditValueChanged);
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

            #region colStallsFromID
            colStallsFromID = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsFromID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsFromID.AppearanceCell.Options.UseFont = true;
            colStallsFromID.Caption = "ID Quầy chuyển";
            colStallsFromID.FieldName = "StallsFromID";
            colStallsFromID.Name = "colStallsFromID";
            colStallsFromID.Visible = false;
            //colStallsFromID.VisibleIndex = -1;
            colStallsFromID.Width = 80;
            #endregion

            #region colStallsFromCode
            colStallsFromCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsFromCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsFromCode.AppearanceCell.Options.UseFont = true;
            colStallsFromCode.Caption = "Mã Quầy chuyển";
            colStallsFromCode.FieldName = "StallsFromCode";
            colStallsFromCode.Name = "colStallsFromCode";
            colStallsFromID.Visible = false;
            //colStallsFromID.VisibleIndex = -1;
            colStallsFromCode.Width = 120;
            #endregion

            #region colStallsFromName
            colStallsFromName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsFromName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsFromName.AppearanceCell.Options.UseFont = true;
            colStallsFromName.Caption = "Quầy chuyển";
            colStallsFromName.FieldName = "StallsFromName";
            colStallsFromName.Name = "colStallsFromName";
            colStallsFromName.Visible = true;
            colStallsFromName.VisibleIndex = 1;
            colStallsFromName.Width = 150;
            #endregion

            #region colStallsToID
            colStallsToID = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsToID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsToID.AppearanceCell.Options.UseFont = true;
            colStallsToID.Caption = "ID quầy nhận";
            colStallsToID.FieldName = "StallsToID";
            colStallsToID.Name = "colStallsToID";
            colStallsToID.Visible = false;
            //colStallsToID.VisibleIndex = -1;
            colStallsToID.Width = 80;
            #endregion

            #region colCustCode
            colStallsToCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsToCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsToCode.AppearanceCell.Options.UseFont = true;
            colStallsToCode.Caption = "Mã quầy nhận";
            colStallsToCode.FieldName = "StallsToCode";
            colStallsToCode.Name = "colStallsToCode";
            colStallsToCode.Visible = true;
            colStallsToCode.VisibleIndex = 0;
            colStallsToCode.Width = 120;
            #endregion

            #region colStallsToName
            colStallsToName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStallsToName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colStallsToName.AppearanceCell.Options.UseFont = true;
            colStallsToName.Caption = "Quầy nhận";
            colStallsToName.FieldName = "StallsToName";
            colStallsToName.Name = "colStallsToName";
            colStallsToName.Visible = true;
            colStallsToName.VisibleIndex = 1;
            colStallsToName.Width = 150;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 2;
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
            colEmpName.VisibleIndex = 4;
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
            colStatusName.VisibleIndex = 5;
            colStatusName.Width = 150;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvProductTransferLst.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvProductTransferLst.OptionsBehavior.Editable = false;
            // Hiển thị filter
            //grvProductTransferLst.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvProductTransferLst.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductTransferLst.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductTransferLst.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductTransferLst.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductTransferLst.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductTransferLst.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductTransferLst.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvProductTransferLst.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductTransferLst.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colTrnID,
            colTrnCode,
            colTrnDate,
            colTrnTime,
            colStallsFromID,
            colStallsFromCode,
            colStallsFromName,
            colStallsToID,
            colStallsToCode,
            colStallsToName,
            colNotes,
            colEmpID,
            colEmpCode,
            colEmpName,
            colStatusCode,
            colStatusName,
            });
            grvProductTransferLst.DoubleClick += new System.EventHandler(this.grvProductTransferLst_DoubleClick);
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
            tblInit.Columns.Add("StallsFromID", typeof(long));
            tblInit.Columns.Add("StallsFromCode", typeof(string));
            tblInit.Columns.Add("StallsFromName", typeof(string));
            tblInit.Columns.Add("StallsToID", typeof(long));
            tblInit.Columns.Add("StallsToCode", typeof(string));
            tblInit.Columns.Add("StallsToName", typeof(string));
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
                ds = BLLCatStalls.LoadDataCombobox(-1, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboStallsFrom.Properties.DataSource = ds.Tables[0].Copy();
                    cboStallsFrom.Properties.DisplayMember = "StallsName";
                    cboStallsFrom.Properties.ValueMember = "StallsID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatStalls.LoadDataCombobox(-1, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboStallsTo.Properties.DataSource = ds.Tables[0].Copy();
                    cboStallsTo.Properties.DisplayMember = "StallsName";
                    cboStallsTo.Properties.ValueMember = "StallsID";
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
                ds = BLLSysStatus.LoadDataCombobox("STATUS_TRN_PRODUCT_TRANSFER", out sMessages);
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
                DTOTrnProductTransfer objTrnProductTransfer = new DTOTrnProductTransfer();
                objTrnProductTransfer.TrnCode = txtTrnCode.Text.Trim();
                DTOCatEmployee objCatEmployee = new DTOCatEmployee();
                objCatEmployee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnProductTransfer.Employee = objCatEmployee;
                objTrnProductTransfer.StatusCode = cboStatus.EditValue == null ? string.Empty : Convert.ToString(cboStatus.EditValue);
                ds = BLLTrnProductTransfer.TrnProductTransfer_Lst(objTrnProductTransfer, sDateFrom, sDateTo, out sMessage);
                grcProductTransferLst.DataSource = ds.Tables[0].Copy();
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
                grcProductTransferLst.DataSource = InitDataSourceGrid();
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
                DataRow drSelect = grvProductTransferLst.GetFocusedDataRow();
                if (drSelect == null)
                {
                    VMHMessages.ShowWarning("Vui lòng chọn dòng dữ liệu!");
                }
                if (drSelect["TrnID"] == DBNull.Value)
                {
                    VMHMessages.ShowWarning(MessagesText.TextGetTrnInfoFailure);
                }
                long sTrnID = Convert.ToInt64(drSelect["TrnID"]);
                gbFrmProductTransfer.gbTrnID = sTrnID;
                gbFrmProductTransfer.LoadDataToForm(sTrnID);
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
        private void grvProductTransferLst_DoubleClick(object sender, EventArgs e)
        {
            if (SelectClick())
            {
                this.Close();
            }
        }
        #endregion
    }
}