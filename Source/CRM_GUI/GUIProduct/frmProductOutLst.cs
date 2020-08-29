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
using CRM_BLL.BLLSystem;
using DevExpress.XtraGrid.Views.Grid;
using CRM_DTO.DTOProduct;
using CRM_BLL.BLLProduct;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductOutLst : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private frmProductOut gbFrmProductOut = null;
        #endregion

        #region Form
        public frmProductOutLst()
        {
            InitializeComponent();
            DesignControls();
        }

        public frmProductOutLst(frmProductOut _Frm)
        {
            InitializeComponent();
            DesignControls();
            gbFrmProductOut = _Frm;
        }

        private void frmProductOutLst_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            LoadDataToGrid();
        }
        #endregion

        #region Design
        #region Declare Controls
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
        public GridColumn colStallsID { get; set; }
        public GridColumn colStallsCode { get; set; }
        public GridColumn colStallsName { get; set; }
        public GridColumn colShopID { get; set; }
        public GridColumn colShopCode { get; set; }
        public GridColumn colShopName { get; set; }
        public GridColumn colNotes { get; set; }
        public GridColumn colEmpID { get; set; }
        public GridColumn colEmpCode { get; set; }
        public GridColumn colEmpName { get; set; }
        public GridColumn colStatusCode { get; set; }
        public GridColumn colStatusName { get; set; }
        public GridColumn colQuantityOut { get; set; }
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
            this.Load += new System.EventHandler(this.frmProductOutLst_Load);
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
            colTrnDate.Caption = "Ngày";
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
            colStallsName.VisibleIndex = 2;
            colStallsName.Width = 150;
            #endregion

            #region colShopID
            colShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            colShopID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colShopID.AppearanceCell.Options.UseFont = true;
            colShopID.Caption = "ID Cửa hàng";
            colShopID.FieldName = "ShopID";
            colShopID.Name = "colShopID";
            colShopID.Visible = false;
            //colShopID.VisibleIndex = -1;
            colShopID.Width = 80;
            #endregion

            #region colShopCode
            colShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colShopCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colShopCode.AppearanceCell.Options.UseFont = true;
            colShopCode.Caption = "Mã Cửa hàng";
            colShopCode.FieldName = "ShopCode";
            colShopCode.Name = "colShopCode";
            colShopCode.Visible = false;
            //colShopCode.VisibleIndex = -1;
            colShopCode.Width = 120;
            #endregion

            #region colShopName
            colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            colShopName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colShopName.AppearanceCell.Options.UseFont = true;
            colShopName.Caption = "Cửa hàng";
            colShopName.FieldName = "ShopName";
            colShopName.Name = "colShopName";
            colShopName.Visible = false;
            //colShopName.VisibleIndex = -1;
            colShopName.Width = 120;
            #endregion

            #region colQuantityOut
            colQuantityOut = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantityOut.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colQuantityOut.AppearanceCell.Options.UseFont = true;
            colQuantityOut.DisplayFormat.FormatString = "{0:#,##0}";
            colQuantityOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQuantityOut.Caption = "Số lượng xuất";
            colQuantityOut.FieldName = "QuantityOut";
            colQuantityOut.Name = "colQuantityOut";
            colQuantityOut.Visible = true;
            colQuantityOut.VisibleIndex = 3;
            colQuantityOut.Width = 150;
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
            colNotes.Width = 200;
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
            colEmpID.Visible = false;
            //colEmpID.VisibleIndex = -1;
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
            grvProductOutLst.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvProductOutLst.OptionsBehavior.Editable = false;
            // Hiển thị filter
            //grvProductOutLst.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvProductOutLst.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductOutLst.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductOutLst.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductOutLst.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductOutLst.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductOutLst.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductOutLst.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            grvProductOutLst.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductOutLst.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colTrnID,
                colTrnCode,
                colTrnDate,
                colTrnTime,
                colStallsID,
                colStallsCode,
                colStallsName,
                colShopID,
                colShopCode,
                colShopName,
                colNotes,
                colEmpID,
                colEmpCode,
                colEmpName,
                colStatusCode,
                colStatusName,
                colQuantityOut
            });
            grvProductOutLst.DoubleClick += new System.EventHandler(this.grvProductOutLst_DoubleClick);
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
                DTOTrnProductOut objTrnProductOut = new DTOTrnProductOut();
                objTrnProductOut.TrnCode = txtTrnCode.Text.Trim();
                DTOCatEmployee objCatEmployee = new DTOCatEmployee();
                objCatEmployee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnProductOut.Employee = objCatEmployee;
                objTrnProductOut.StatusCode = cboStatus.EditValue == null ? string.Empty : Convert.ToString(cboStatus.EditValue);
                ds = BLLTrnProductOut.TrnProductOut_Lst(objTrnProductOut, sDateFrom, sDateTo, out sMessage);
                grcProductOutLst.DataSource = ds.Tables[0].Copy();
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
                grcProductOutLst.DataSource = InitDataSourceGrid();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Load dữ liệu đã chọn qua form Xuất hàng
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SelectClick()
        {
            bool bResult = false;
            try
            {
                DataRow drSelect = grvProductOutLst.GetFocusedDataRow();
                if (drSelect == null)
                {
                    VMHMessages.ShowWarning("Vui lòng chọn dòng dữ liệu!");
                }
                if (drSelect["TrnID"] == DBNull.Value)
                {
                    VMHMessages.ShowWarning(MessagesText.TextGetTrnInfoFailure);
                }
                long sTrnID = Convert.ToInt64(drSelect["TrnID"]);
                gbFrmProductOut.gbTrnID = sTrnID;
                gbFrmProductOut.LoadDataToForm(sTrnID);
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
        private void grvProductOutLst_DoubleClick(object sender, EventArgs e)
        {
            if (SelectClick())
            {
                this.Close();
            }
        }
        #endregion
    }
}