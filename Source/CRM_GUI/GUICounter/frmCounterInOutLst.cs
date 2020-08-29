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
using CRM_BLL.BLLCounter;
using CRM_DTO.DTOCounter;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUICounter
{
    public partial class frmCounterInOutLst : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private frmCounterInOut gbFrmCounterInOut = null;
        #endregion

        #region Form
        public frmCounterInOutLst()
        {
            InitializeComponent();
            DesignControls();
        }

        public frmCounterInOutLst(frmCounterInOut _Frm)
        {
            InitializeComponent();
            DesignControls();
            gbFrmCounterInOut = _Frm;
        }

        private void frmCounterInOutLst_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            LoadDataToGrid();
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboCounter
        public GridView grvCboCounter { get; set; }
        public GridColumn colCboCounterCode { get; set; }
        public GridColumn colCboCounterName { get; set; }
        public GridColumn colCboCounterShopName { get; set; }
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
        public GridColumn colNotes { get; set; }
        public GridColumn colEmpID { get; set; }
        public GridColumn colEmpCode { get; set; }
        public GridColumn colEmpName { get; set; }
        public GridColumn colStatusCode { get; set; }
        public GridColumn colStatusName { get; set; }
        #endregion
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Danh sách thu chi tại quầy";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmCounterInOutLst_Load);
            #endregion

            DesignDateTimeEdit();
            DesignGridview();
            DesignGridLookUpEdit();
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
            #region cboCounter
            //
            // colCboCounterCode
            //
            this.colCboCounterCode = new GridColumn();
            this.colCboCounterCode.Caption = "Mã quầy thu ngân";
            this.colCboCounterCode.FieldName = "CounterCode";
            this.colCboCounterCode.Name = "colCboCounterCode";
            this.colCboCounterCode.Visible = true;
            this.colCboCounterCode.VisibleIndex = 0;
            //
            // colCboCounterName
            //
            this.colCboCounterName = new GridColumn();
            this.colCboCounterName.Caption = "Tên quầy thu ngân";
            this.colCboCounterName.FieldName = "CounterName";
            this.colCboCounterName.Name = "colCboCounterName";
            this.colCboCounterName.Visible = true;
            this.colCboCounterName.VisibleIndex = 1;
            //
            // colCboCounterShopName
            //
            this.colCboCounterShopName = new GridColumn();
            this.colCboCounterShopName.Caption = "Tên cửa hàng";
            this.colCboCounterShopName.FieldName = "ShopName";
            this.colCboCounterShopName.Name = "colCboCounterShopName";
            this.colCboCounterShopName.Visible = true;
            this.colCboCounterShopName.VisibleIndex = 2;
            // 
            // grvCboCounter
            // 
            this.grvCboCounter = new GridView();
            this.grvCboCounter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboCounterCode,
            this.colCboCounterName});
            this.grvCboCounter.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCounter.Name = "grvCboCounter";
            this.grvCboCounter.OptionsBehavior.Editable = false;
            this.grvCboCounter.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCounter.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCounter.OptionsView.ShowGroupPanel = false;
            this.grvCboCounter.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCounter.Appearance.Row.Options.UseFont = true;
            this.grvCboCounter.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCounter.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboCounter.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboCounter.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboCounter.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboCounter
            // 
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounter.Properties.Appearance.Options.UseFont = true;
            this.cboCounter.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounter.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCounter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCounter.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounter.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCounter.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCounter.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCounter.Properties.NullText = "";
            this.cboCounter.Properties.ShowFooter = false;
            this.cboCounter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCounter.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCounter.Properties.View = this.grvCboCounter;
            //this.cboCounter.EditValueChanged += new System.EventHandler(this.cboCounter_EditValueChanged);
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
            colEmpName.VisibleIndex = 3;
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
            colStatusName.VisibleIndex = 4;
            colStatusName.Width = 150;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvCounterInOutLst.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvCounterInOutLst.OptionsBehavior.Editable = false;
            // Hiển thị filter
            //grvCounterInOutLst.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvCounterInOutLst.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterInOutLst.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCounterInOutLst.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterInOutLst.Appearance.HeaderPanel.Options.UseFont = true;
            grvCounterInOutLst.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCounterInOutLst.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCounterInOutLst.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCounterInOutLst.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCounterInOutLst.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colTrnID,
            colTrnCode,
            colTrnDate,
            colTrnTime,
            colNotes,
            colEmpID,
            colEmpCode,
            colEmpName,
            colStatusCode,
            colStatusName,
            });
            grvCounterInOutLst.DoubleClick += new System.EventHandler(this.grvCounterInOutLst_DoubleClick);
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
                    cboCounter.Properties.DataSource = ds.Tables[0].Copy();
                    cboCounter.Properties.DisplayMember = "CounterName";
                    cboCounter.Properties.ValueMember = "CounterID";
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
                ds = BLLSysStatus.LoadDataCombobox("STATUS_TRN_Counter_INOUT", out sMessages);
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
                DTOTrnCounterInOut objTrnCounterInOut = new DTOTrnCounterInOut();
                objTrnCounterInOut.TrnCode = txtTrnCode.Text.Trim();
                DTOCatEmployee objEmployee = new DTOCatEmployee();
                objEmployee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnCounterInOut.Employee = objEmployee;
                objTrnCounterInOut.StatusCode = cboStatus.EditValue == null ? string.Empty : Convert.ToString(cboStatus.EditValue);
                ds = BLLTrnCounterInOut.TrnCounterInOut_Lst(objTrnCounterInOut, sDateFrom, sDateTo, out sMessage);
                grcCounterInOutLst.DataSource = ds.Tables[0].Copy();
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
                grcCounterInOutLst.DataSource = InitDataSourceGrid();
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
                DataRow drSelect = grvCounterInOutLst.GetFocusedDataRow();
                if (drSelect == null)
                {
                    VMHMessages.ShowWarning("Vui lòng chọn dòng dữ liệu!");
                }
                if (drSelect["TrnID"] == DBNull.Value)
                {
                    VMHMessages.ShowWarning(MessagesText.TextGetTrnInfoFailure);
                }
                long sTrnID = Convert.ToInt64(drSelect["TrnID"]);
                gbFrmCounterInOut.gbTrnID = sTrnID;
                gbFrmCounterInOut.LoadDataToForm(sTrnID);
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
        private void grvCounterInOutLst_DoubleClick(object sender, EventArgs e)
        {
            if (SelectClick())
            {
                this.Close();
            }
        }
        #endregion
    }
}