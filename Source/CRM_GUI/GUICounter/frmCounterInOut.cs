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
using CRM_BLL.BLLSystem;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOSystem;
using CRM_BLL.BLLCounter;
using CRM_DTO.DTOCounter;
using CRM_GUI.CRMFunctions;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUICounter
{
    public partial class frmCounterInOut : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public long gbTrnID = -1;
        #endregion

        #region Form
        public frmCounterInOut()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmCounterInOut_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
        }
        #endregion

        #region Design
        #region Declare Controls
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

        #region cboCounter
        public GridView grvCboCounter { get; set; }
        public GridColumn colCboCounterID { get; set; }
        public GridColumn colCboCounterCode { get; set; }
        public GridColumn colCboCounterName { get; set; }
        public GridColumn colCboCounterShopName { get; set; }
        #endregion

        #region Gridview
        public GridColumn colTrnID { get; set; }
        public GridColumn colTrnTypeID { get; set; }
        public GridColumn colTrnTypeName { get; set; }
        public GridColumn colCurrencyID { get; set; }
        public GridColumn colCurrencyCode { get; set; }
        public GridColumn colCurrencyDesc { get; set; }
        public GridColumn colAmount { get; set; }
        public GridColumn colNotes { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Thu chi tại quầy";
            this.Load += new System.EventHandler(this.frmCounterInOut_Load);
            #endregion

            DesignTextSpinEdit();
            DesignDateTimeEdit();
            DesignGridLookUpEdit();
            DesignGridview();
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
            dtpTrnDate.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            dtpTrnDate.Properties.Appearance.Options.UseBackColor = true;
            dtpTrnDate.TabStop = false;
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
            #region cboEmployee
            //
            // colCboEmpID
            //
            this.colCboEmpID = new GridColumn();
            this.colCboEmpID.Caption = "ID nhân viên";
            this.colCboEmpID.FieldName = "EmpID";
            this.colCboEmpID.Name = "colCboEmpID";
            this.colCboEmpID.Visible = false;
            //this.colCboEmpID.VisibleIndex = -1;
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
                this.colCboEmpID,
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
            this.cboEmployee.EditValueChanged += new System.EventHandler(this.cboEmployee_EditValueChanged);
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
            this.cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboStatus.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboStatus.Properties.View = this.grvCboStatus;
            //this.cboStatus.EditValueChanged += new System.EventHandler(this.cboStatus_EditValueChanged);
            this.cboStatus.ReadOnly = true;
            this.cboStatus.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboStatus.Properties.Appearance.Options.UseFont = true;
            this.cboStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboStatus.Properties.Appearance.Options.UseForeColor = true;
            this.cboStatus.TabStop = false;
            #endregion

            #region cboCounter
            //
            // colCboCounterID
            //
            this.colCboCounterID = new GridColumn();
            this.colCboCounterID.Caption = "ID quầy thu ngân";
            this.colCboCounterID.FieldName = "CounterID";
            this.colCboCounterID.Name = "colCboCounterID";
            this.colCboCounterID.Visible = false;
            //this.colCboCounterID.VisibleIndex = -1;
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
                this.colCboCounterID,
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
            this.cboCounter.ReadOnly = true;
            this.cboCounter.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboCounter.Properties.Appearance.Options.UseBackColor = true;
            this.cboCounter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboCounter.Properties.Appearance.Options.UseFont = true;
            this.cboCounter.TabStop = false;
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

            #region colTrnTypeID
            colTrnTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrnTypeID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colTrnTypeID.AppearanceCell.Options.UseFont = true;
            colTrnTypeID.Caption = "ID Loại giao dịch";
            colTrnTypeID.FieldName = "TrnTypeID";
            colTrnTypeID.Name = "colTrnTypeID";
            colTrnTypeID.Visible = false;
            //colTrnTypeID.VisibleIndex = -1;
            colTrnTypeID.Width = 120;
            #endregion

            #region colTrnTypeName
            colTrnTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrnTypeName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colTrnTypeName.AppearanceCell.Options.UseFont = true;
            colTrnTypeName.Caption = "Loại giao dịch";
            colTrnTypeName.FieldName = "TrnTypeName";
            colTrnTypeName.Name = "colTrnTypeName";
            colTrnTypeName.Visible = true;
            colTrnTypeName.VisibleIndex = 0;
            colTrnTypeName.Width = 120;
            #endregion

            #region colCurrencyID
            colCurrencyID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCurrencyID.AppearanceCell.Options.UseFont = true;
            colCurrencyID.Caption = "ID Loại tiền";
            colCurrencyID.FieldName = "CurrencyID";
            colCurrencyID.Name = "colCurrencyID";
            colCurrencyID.Visible = false;
            //colCurrencyID.VisibleIndex = -1;
            colCurrencyID.Width = 80;
            #endregion

            #region colCurrencyCode
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCurrencyCode.AppearanceCell.Options.UseFont = true;
            colCurrencyCode.Caption = "Mã Loại tiền";
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
            colCurrencyDesc.Caption = "Loại tiền";
            colCurrencyDesc.FieldName = "CurrencyDesc";
            colCurrencyDesc.Name = "colCurrencyDesc";
            colCurrencyDesc.Visible = true;
            colCurrencyDesc.VisibleIndex = 1;
            colCurrencyDesc.Width = 150;
            #endregion

            #region colAmount
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmount.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colAmount.AppearanceCell.Options.UseFont = true;
            colAmount.DisplayFormat.FormatString = "{0:#,##0}";
            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.Caption = "Số lượng";
            colAmount.FieldName = "Amount";
            colAmount.Name = "colAmount";
            colAmount.Visible = true;
            colAmount.VisibleIndex = 2;
            colAmount.Width = 100;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 3;
            colNotes.Width = 180;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = true;
            layoutControlItemGridView.Text = "   Thông tin thu chi tại quầy";
            grvCounterInOut.OptionsView.ShowGroupPanel = false;
            grvCounterInOut.OptionsBehavior.Editable = false;
            // Định dạng chữ dòng dữ liệu
            grvCounterInOut.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterInOut.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCounterInOut.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterInOut.Appearance.HeaderPanel.Options.UseFont = true;
            grvCounterInOut.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCounterInOut.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCounterInOut.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            // grvCounterInOut.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCounterInOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colTrnID,
            colTrnTypeID,
            colTrnTypeName,
            colCurrencyID,
            colCurrencyCode,
            colCurrencyDesc,
            colAmount,
            colNotes,
            });
            grvCounterInOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvCounterInOut_KeyDown);
            grvCounterInOut.DoubleClick += new System.EventHandler(this.grvCounterInOut_DoubleClick);
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
            tblInit.Columns.Add("TrnTypeID", typeof(bool));
            tblInit.Columns.Add("TrnTypeName", typeof(string));
            tblInit.Columns.Add("CurrencyID", typeof(long));
            tblInit.Columns.Add("CurrencyCode", typeof(string));
            tblInit.Columns.Add("CurrencyDesc", typeof(string));
            tblInit.Columns.Add("Amount", typeof(decimal));
            tblInit.Columns.Add("Notes", typeof(string));
            return tblInit;
        }

        /// <summary>
        /// Cập nhật lưới dữ liệu thông tin các món hàng
        /// </summary>
        /// <param name="_Row"></param>
        /// <returns></returns>
        public bool AddItemDataSourceGrid(DTOTrnCounterInOutDT _TrnCounterInOutDT)
        {
            bool bResult = false;
            try
            {
                DataTable dtDtl = grcCounterInOut.DataSource as DataTable;
                DataRow drDtl = dtDtl.NewRow();
                drDtl["TrnID"] = _TrnCounterInOutDT.TrnID;
                drDtl["Amount"] = _TrnCounterInOutDT.Amount;
                drDtl["Notes"] = _TrnCounterInOutDT.Notes;
                drDtl["CurrencyID"] = _TrnCounterInOutDT.Currency.ID;
                drDtl["CurrencyCode"] = _TrnCounterInOutDT.Currency.CurrencyCode;
                drDtl["CurrencyDesc"] = _TrnCounterInOutDT.Currency.CurrencyDesc;
                drDtl["TrnTypeID"] = _TrnCounterInOutDT.TrnTypeID;
                drDtl["TrnTypeName"] = _TrnCounterInOutDT.TrnTypeName;
                dtDtl.Rows.Add(drDtl);
                grcCounterInOut.DataSource = dtDtl;
                bResult = true;
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
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
                ds = BLLSysStatus.LoadDataCombobox("STATUS_TRN_COUNTER_INOUT", out sMessages);
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
        public void LoadDataToForm(long _TrnID)
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                ds = BLLTrnCounterInOut.TrnCounterInOut_GetWithID(_TrnID, out sMessage);
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                    return;
                }
                txtTrnCode.EditValue = ds.Tables[0].Rows[0]["TrnCode"] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[0]["TrnCode"];
                txtNotes.EditValue = ds.Tables[0].Rows[0]["Notes"] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[0]["Notes"];
                cboEmployee.EditValue = ds.Tables[0].Rows[0]["EmpID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["EmpID"];
                cboCounter.EditValue = ds.Tables[0].Rows[0]["CounterID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["CounterID"];
                cboStatus.EditValue = ds.Tables[0].Rows[0]["StatusCode"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["StatusCode"];
                dtpTrnDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["TrnDate"];
                grcCounterInOut.DataSource = ds.Tables[1].Copy();
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
                gbTrnID = -1;
                grcCounterInOut.DataSource = InitDataSourceGrid();
                txtTrnCode.Text = "Tự động";
                txtNotes.Text = string.Empty;
                dtpTrnDate.EditValue = DateTime.Now;
                cboEmployee.EditValue = DTOAttributeSystem.CurrentEmployee.ID;
                cboStatus.EditValue = null;
                cboCounter.EditValue = DTOAttributeSystem.CurrentCounter.ID;
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Kiểm tra mở quầy thu ngân
        /// </summary>
        public bool IsOpenCounter()
        {
            if (cboCounter.EditValue == null || Convert.ToInt64(cboCounter.EditValue) == -1)
            {
                VMHMessages.ShowWarning(MessagesText.TextNotOpenCounter);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật chi tiết
        /// </summary>
        private void EditDtlClick()
        {
            int idxFocused = grvCounterInOut.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                VMHMessages.ShowWarning("Vui lòng chọn một dòng dữ liệu");
                return;
            }
            DTOTrnCounterInOutDT objTrnCounterInOutDT = new DTOTrnCounterInOutDT();
            objTrnCounterInOutDT.TrnID = gbTrnID;
            objTrnCounterInOutDT.Amount = grvCounterInOut.GetFocusedRowCellValue(colAmount) == DBNull.Value ? 0M : Convert.ToDecimal(grvCounterInOut.GetFocusedRowCellValue(colAmount));
            objTrnCounterInOutDT.Notes = grvCounterInOut.GetFocusedRowCellValue(colNotes) == DBNull.Value ? string.Empty : Convert.ToString(grvCounterInOut.GetFocusedRowCellValue(colNotes));
            objTrnCounterInOutDT.TrnTypeID = grvCounterInOut.GetFocusedRowCellValue(colTrnTypeID) == DBNull.Value ? true : Convert.ToBoolean(grvCounterInOut.GetFocusedRowCellValue(colTrnTypeID));
            objTrnCounterInOutDT.TrnTypeName = grvCounterInOut.GetFocusedRowCellValue(colTrnTypeName) == DBNull.Value ? string.Empty : Convert.ToString(grvCounterInOut.GetFocusedRowCellValue(colTrnTypeName));

            DTOCatCurrency objCurrency = new DTOCatCurrency();
            objCurrency.ID = grvCounterInOut.GetFocusedRowCellValue(colCurrencyID) == DBNull.Value ? -1 : Convert.ToInt64(grvCounterInOut.GetFocusedRowCellValue(colCurrencyID));
            objCurrency.CurrencyCode = grvCounterInOut.GetFocusedRowCellValue(colCurrencyCode) == DBNull.Value ? string.Empty : Convert.ToString(grvCounterInOut.GetFocusedRowCellValue(colCurrencyCode));
            objCurrency.CurrencyDesc = grvCounterInOut.GetFocusedRowCellValue(colCurrencyDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvCounterInOut.GetFocusedRowCellValue(colCurrencyDesc));
            objTrnCounterInOutDT.Currency = objCurrency;
            frmCounterInOutDtl frm = new frmCounterInOutDtl(this, objTrnCounterInOutDT);
            frm.ShowDialog();
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
                if (grvCounterInOut.OptionsBehavior.Editable == true)
                {
                    if (VMHMessages.ShowConfirm("Bạn có muốn xóa dòng dữ liệu này không?") == DialogResult.OK)
                    {
                        int i = grvCounterInOut.FocusedRowHandle;
                        grvCounterInOut.DeleteRow(i);
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
                long lCurrentID = FuncGeneral.GetCurrentID("TRN_COUNTER_INOUT");
                _TrnCodeUdp = _TrnID == -1 ? FuncGeneral.GenTransactionCode("TRN_COUNTER_INOUT", lCurrentID) : _TrnCode;

                DTOTrnCounterInOut objTrnCounterInOut = new DTOTrnCounterInOut();
                objTrnCounterInOut.TrnID = _TrnID;
                objTrnCounterInOut.TrnCode = _TrnCodeUdp;
                objTrnCounterInOut.TrnDate = DateTime.Now;
                objTrnCounterInOut.TrnTime = TimeSpan.FromTicks(DateTime.Now.ToLocalTime().Ticks);
                DTOCatCounter objCounter = new DTOCatCounter();
                objCounter.ID = cboCounter.EditValue == null ? -1 : Convert.ToInt64(cboCounter.EditValue);
                objTrnCounterInOut.Counter = objCounter;
                objTrnCounterInOut.Notes = txtNotes.Text;
                DTOCatEmployee objEmployee = new DTOCatEmployee();
                objEmployee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnCounterInOut.Employee = objEmployee;
                objTrnCounterInOut.StatusCode = "S";
                objTrnCounterInOut.UpdateDate = DateTime.Now;
                objTrnCounterInOut.UpdateBy = DTOAttributeSystem.CurrentUser.ID;
                objTrnCounterInOut.IsDelete = false;

                DataTable dtDtl = new DataTable("Transaction");
                dtDtl = ((DataView)grvCounterInOut.DataSource).ToTable("Transaction");
                grcCounterInOut.DataSource = dtDtl.Copy();
                dtDtl.DefaultView.Sort = "TrnTypeID DESC, CurrencyCode DESC";
                ds.Tables.Add(dtDtl);
                string xmlDtl = ds.GetXml();
                bResult = BLLTrnCounterInOut.TrnCounterInOut_InsUpd(objTrnCounterInOut, xmlDtl, out _TrnIDUdp, out _Message);
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
                    bResult = BLLTrnCounterInOut.TrnCounterInOut_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
                }

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
                    bResult = BLLTrnCounterInOut.TrnCounterInOut_Complete(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Button
        private void btnAddDtl_Click(object sender, EventArgs e)
        {
            frmCounterInOutDtl frm = new frmCounterInOutDtl(this);
            frm.ShowDialog();
        }

        private void btnEditDtl_Click(object sender, EventArgs e)
        {
            EditDtlClick();
        }

        private void btnDeleteDtl_Click(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDefault();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsOpenCounter())
            {
                return;
            }
            string sMessage = string.Empty;
            string sTrnCodeUdp = string.Empty;
            string sTrnCode = txtTrnCode.Text.Trim();
            long lTrnID = -1;
            if (SaveClick(gbTrnID, sTrnCode, out lTrnID, out sTrnCodeUdp, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.HandlerSuccess("Lưu"));
                txtTrnCode.EditValue = sTrnCodeUdp;
                gbTrnID = lTrnID;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (DeleteClick(gbTrnID, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
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

        private void btnList_Click(object sender, EventArgs e)
        {
            frmCounterInOutLst frm = new frmCounterInOutLst(this);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Combobox
        private void cboEmployee_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Gridview
        private void grvCounterInOut_KeyDown(object sender, KeyEventArgs e)
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

        private void grvCounterInOut_DoubleClick(object sender, EventArgs e)
        {
            EditDtlClick();
        }
        #endregion
    }
}