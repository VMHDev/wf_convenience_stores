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
using CRM_BLL.BLLCounter;
using CRM_DTO.DTOSystem;
using CRM_DTO.CRMUtility;

namespace CRM_GUI.GUICounter
{
    public partial class frmCounterTransfer : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public long gbTrnID = -1;
        #endregion

        #region Form
        public frmCounterTransfer()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmCounterTransfer_Load(object sender, EventArgs e)
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

        #region cboShopFrom
        public GridView grvCboShopFrom { get; set; }
        public GridColumn colCboShopFromID { get; set; }
        public GridColumn colCboShopFromCode { get; set; }
        public GridColumn colCboShopFromName { get; set; }
        public GridColumn colCboShopFromAddress { get; set; }
        public GridColumn colCboShopFromTel { get; set; }
        #endregion

        #region cboShopTo
        public GridView grvCboShopTo { get; set; }
        public GridColumn colCboShopToID { get; set; }
        public GridColumn colCboShopToCode { get; set; }
        public GridColumn colCboShopToName { get; set; }
        public GridColumn colCboShopToAddress { get; set; }
        public GridColumn colCboShopToTel { get; set; }
        #endregion

        #region cboCounterFrom
        public GridView grvCboCounterFrom { get; set; }
        public GridColumn colCboCounterFromID { get; set; }
        public GridColumn colCboCounterFromCode { get; set; }
        public GridColumn colCboCounterFromName { get; set; }
        public GridColumn colCboCounterFromShopName { get; set; }
        #endregion

        #region cboCounterTo
        public GridView grvCboCounterTo { get; set; }
        public GridColumn colCboCounterToNameID { get; set; }
        public GridColumn colCboCounterToNameCode { get; set; }
        public GridColumn colCboCounterToName { get; set; }
        public GridColumn colCboCounterToShopName { get; set; }
        #endregion

        #region Gridview
        public GridColumn colTrnID { get; set; }
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
            this.Text = "Chuyển quầy";
            this.Load += new System.EventHandler(this.frmCounterTransfer_Load);
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
            //this.cboEmployee.EditValueChanged += new System.EventHandler(this.cboEmployee_EditValueChanged);
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

            #region cboShopFrom
            //
            // colCboShopFromID
            //
            this.colCboShopFromID = new GridColumn();
            this.colCboShopFromID.Caption = "ID cửa hàng";
            this.colCboShopFromID.FieldName = "ShopID";
            this.colCboShopFromID.Name = "colCboShopFromID";
            this.colCboShopFromID.Visible = false;
            //this.colCboShopFromID.VisibleIndex = -1;
            //
            // colCboShopFromCode
            //
            this.colCboShopFromCode = new GridColumn();
            this.colCboShopFromCode.Caption = "Mã cửa hàng";
            this.colCboShopFromCode.FieldName = "ShopCode";
            this.colCboShopFromCode.Name = "colCboShopFromCode";
            this.colCboShopFromCode.Visible = true;
            this.colCboShopFromCode.VisibleIndex = 0;
            //
            // colCboShopFromName
            //
            this.colCboShopFromName = new GridColumn();
            this.colCboShopFromName.Caption = "Tên cửa hàng";
            this.colCboShopFromName.FieldName = "ShopName";
            this.colCboShopFromName.Name = "colCboShopFromName";
            this.colCboShopFromName.Visible = true;
            this.colCboShopFromName.VisibleIndex = 1;
            // 
            // grvCboShopFrom
            // 
            this.grvCboShopFrom = new GridView();
            this.grvCboShopFrom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboShopFromID,
                this.colCboShopFromCode,
                this.colCboShopFromName});
            this.grvCboShopFrom.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboShopFrom.Name = "grvCboShopFrom";
            this.grvCboShopFrom.OptionsBehavior.Editable = false;
            this.grvCboShopFrom.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboShopFrom.OptionsView.ShowAutoFilterRow = true;
            this.grvCboShopFrom.OptionsView.ShowGroupPanel = false;
            this.grvCboShopFrom.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboShopFrom.Appearance.Row.Options.UseFont = true;
            this.grvCboShopFrom.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboShopFrom.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboShopFrom.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboShopFrom.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboShopFrom.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboShopFrom
            // 
            this.cboShopFrom.Name = "cboShopFrom";
            this.cboShopFrom.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopFrom.Properties.Appearance.Options.UseFont = true;
            this.cboShopFrom.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopFrom.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboShopFrom.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopFrom.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboShopFrom.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopFrom.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboShopFrom.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopFrom.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboShopFrom.Properties.NullText = "";
            this.cboShopFrom.Properties.ShowFooter = false;
            this.cboShopFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboShopFrom.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboShopFrom.Properties.View = this.grvCboShopFrom;
            this.cboShopFrom.EditValueChanged += new System.EventHandler(this.cboShopFrom_EditValueChanged);
            #endregion

            #region cboShopTo
            //
            // colCboShopToID
            //
            this.colCboShopToID = new GridColumn();
            this.colCboShopToID.Caption = "ID cửa hàng";
            this.colCboShopToID.FieldName = "ShopID";
            this.colCboShopToID.Name = "colCboShopToID";
            this.colCboShopToID.Visible = false;
            //this.colCboShopToID.VisibleIndex = -1;
            //
            // colCboShopToCode
            //
            this.colCboShopToCode = new GridColumn();
            this.colCboShopToCode.Caption = "Mã cửa hàng";
            this.colCboShopToCode.FieldName = "ShopCode";
            this.colCboShopToCode.Name = "colCboShopToCode";
            this.colCboShopToCode.Visible = true;
            this.colCboShopToCode.VisibleIndex = 0;
            //
            // colCboShopToName
            //
            this.colCboShopToName = new GridColumn();
            this.colCboShopToName.Caption = "Tên cửa hàng";
            this.colCboShopToName.FieldName = "ShopName";
            this.colCboShopToName.Name = "colCboShopToName";
            this.colCboShopToName.Visible = true;
            this.colCboShopToName.VisibleIndex = 1;
            // 
            // grvCboShopTo
            // 
            this.grvCboShopTo = new GridView();
            this.grvCboShopTo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboShopToID,
                this.colCboShopToCode,
                this.colCboShopToName});
            this.grvCboShopTo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboShopTo.Name = "grvCboShopTo";
            this.grvCboShopTo.OptionsBehavior.Editable = false;
            this.grvCboShopTo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboShopTo.OptionsView.ShowAutoFilterRow = true;
            this.grvCboShopTo.OptionsView.ShowGroupPanel = false;
            this.grvCboShopTo.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboShopTo.Appearance.Row.Options.UseFont = true;
            this.grvCboShopTo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboShopTo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboShopTo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboShopTo.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboShopTo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboShopTo
            // 
            this.cboShopTo.Name = "cboShopTo";
            this.cboShopTo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopTo.Properties.Appearance.Options.UseFont = true;
            this.cboShopTo.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopTo.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboShopTo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopTo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboShopTo.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopTo.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboShopTo.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShopTo.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboShopTo.Properties.NullText = "";
            this.cboShopTo.Properties.ShowFooter = false;
            this.cboShopTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboShopTo.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboShopTo.Properties.View = this.grvCboShopTo;
            this.cboShopTo.EditValueChanged += new System.EventHandler(this.cboShopTo_EditValueChanged);
            #endregion

            #region cboCounterFrom
            //
            // colCboCounterFromID
            //
            this.colCboCounterFromID = new GridColumn();
            this.colCboCounterFromID.Caption = "ID quầy thu ngân";
            this.colCboCounterFromID.FieldName = "CounterID";
            this.colCboCounterFromID.Name = "colCboCounterFromID";
            this.colCboCounterFromID.Visible = false;
            //this.colCboCounterFromID.VisibleIndex = -1;
            //
            // colCboCounterFromCode
            //
            this.colCboCounterFromCode = new GridColumn();
            this.colCboCounterFromCode.Caption = "Mã quầy thu ngân chuyển";
            this.colCboCounterFromCode.FieldName = "CounterCode";
            this.colCboCounterFromCode.Name = "colCboCounterFromCode";
            this.colCboCounterFromCode.Visible = true;
            this.colCboCounterFromCode.VisibleIndex = 0;
            //
            // colCboCounterFromName
            //
            this.colCboCounterFromName = new GridColumn();
            this.colCboCounterFromName.Caption = "Tên quầy thu ngân chuyển";
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
            this.grvCboCounterFrom.Name = "grvCboCounter";
            this.grvCboCounterFrom.OptionsBehavior.Editable = false;
            this.grvCboCounterFrom.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCounterFrom.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCounterFrom.OptionsView.ShowGroupPanel = false;
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
            // colCboCounterToNameID
            //
            this.colCboCounterToNameID = new GridColumn();
            this.colCboCounterToNameID.Caption = "ID quầy thu ngân";
            this.colCboCounterToNameID.FieldName = "CounterID";
            this.colCboCounterToNameID.Name = "colCboCounterToNameID";
            this.colCboCounterToNameID.Visible = false;
            //this.colCboCounterToNameID.VisibleIndex = -1;
            //
            // colCboCounterToNameCode
            //
            this.colCboCounterToNameCode = new GridColumn();
            this.colCboCounterToNameCode.Caption = "Mã quầy thu ngân nhận";
            this.colCboCounterToNameCode.FieldName = "CounterCode";
            this.colCboCounterToNameCode.Name = "colCboCounterToNameCode";
            this.colCboCounterToNameCode.Visible = true;
            this.colCboCounterToNameCode.VisibleIndex = 0;
            //
            // colCboCounterToName
            //
            this.colCboCounterToName = new GridColumn();
            this.colCboCounterToName.Caption = "Tên quầy thu ngân chuyển";
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
            this.colCboCounterToNameCode,
            this.colCboCounterToName});
            this.grvCboCounterTo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCounterTo.Name = "grvCboCounter";
            this.grvCboCounterTo.OptionsBehavior.Editable = false;
            this.grvCboCounterTo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCounterTo.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCounterTo.OptionsView.ShowGroupPanel = false;
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
            colNotes.Width = 250;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = true;
            layoutControlItemGridView.Text = "   Thông tin chuyển quầy";
            grvCounterTransfer.OptionsView.ShowGroupPanel = false;
            grvCounterTransfer.OptionsBehavior.Editable = false;
            // Định dạng chữ dòng dữ liệu
            grvCounterTransfer.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterTransfer.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCounterTransfer.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCounterTransfer.Appearance.HeaderPanel.Options.UseFont = true;
            grvCounterTransfer.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCounterTransfer.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCounterTransfer.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCounterTransfer.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCounterTransfer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colTrnID,
            colCurrencyID,
            colCurrencyCode,
            colCurrencyDesc,
            colAmount,
            colNotes,
            });
            grvCounterTransfer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvCounterTransfer_KeyDown);
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
            tblInit.Columns.Add("CurrencyID", typeof(long));
            tblInit.Columns.Add("CurrencyCode", typeof(string));
            tblInit.Columns.Add("CurrencyDesc", typeof(string));
            tblInit.Columns.Add("Amount", typeof(decimal));
            tblInit.Columns.Add("Notes", typeof(string));
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
                ds = BLLCatShop.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboShopFrom.Properties.DataSource = ds.Tables[0].Copy();
                    cboShopFrom.Properties.DisplayMember = "ShopName";
                    cboShopFrom.Properties.ValueMember = "ShopID";
                    cboShopTo.Properties.DataSource = ds.Tables[0].Copy();
                    cboShopTo.Properties.DisplayMember = "ShopName";
                    cboShopTo.Properties.ValueMember = "ShopID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatCounter.LoadDataCombobox(DTOAttributeSystem.CurrentShop.ID, out sMessages);
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
                //ds = BLLTrnProductIn.TrnProductIn_GetWithID(_TrnID, out sMessage);
                //if (!string.IsNullOrWhiteSpace(sMessage))
                //{
                //    VMHMessages.ShowWarning(sMessage);
                //    return;
                //}
                //txtTrnCode.EditValue = ds.Tables[0].Rows[0]["TrnCode"] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[0]["TrnCode"];
                //txtNotes.EditValue = ds.Tables[0].Rows[0]["Notes"] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[0]["Notes"];
                //cboEmployee.EditValue = ds.Tables[0].Rows[0]["EmpID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["EmpID"];
                //cboShop.EditValue = ds.Tables[0].Rows[0]["ShopID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["ShopID"];
                //cboStalls.EditValue = ds.Tables[0].Rows[0]["StallsID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["StallsID"];
                //cboStatus.EditValue = ds.Tables[0].Rows[0]["StatusCode"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["StatusCode"];
                //dtpTrnDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["TrnDate"];
                //grcProductIn.DataSource = ds.Tables[1].Copy();
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
                grcCounterTransfer.DataSource = InitDataSourceGrid();
                txtTrnCode.Text = "Tự động";
                txtNotes.Text = string.Empty;
                dtpTrnDate.EditValue = DateTime.Now;
                cboEmployee.EditValue = DTOAttributeSystem.CurrentEmployee.ID;
                cboShopFrom.EditValue = DTOAttributeSystem.CurrentShop.ID;
                cboShopTo.EditValue = null;
                cboCounterFrom.EditValue = cboCounterFrom.Properties.GetKeyValue(0);
                cboCounterTo.EditValue = null;
                cboStatus.EditValue = null;
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
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
                if (grvCounterTransfer.OptionsBehavior.Editable == true)
                {
                    if (VMHMessages.ShowConfirm("Bạn có muốn xóa dòng dữ liệu này không?") == DialogResult.OK)
                    {
                        int i = grvCounterTransfer.FocusedRowHandle;
                        grvCounterTransfer.DeleteRow(i);
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
                    bResult = BLLTrnCounterTransfer.TrnCounterTransfer_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
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
                    bResult = BLLTrnCounterTransfer.TrnCounterTransfer_Complete(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
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

        }

        private void btnEditDtl_Click(object sender, EventArgs e)
        {

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
            frmCounterTransferLst frm = new frmCounterTransferLst(this);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Combobox
        private void cboShopFrom_EditValueChanged(object sender, EventArgs e)
        {
            long lShopID = cboShopFrom.EditValue == null ? -1 : Convert.ToInt64(cboShopFrom.EditValue);
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatCounter.LoadDataCombobox(lShopID, out sMessages);
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

        private void cboShopTo_EditValueChanged(object sender, EventArgs e)
        {
            long lShopID = cboShopTo.EditValue == null ? -1 : Convert.ToInt64(cboShopTo.EditValue);
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatCounter.LoadDataCombobox(lShopID, out sMessages);
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
        #endregion

        #region Gridview
        private void grvCounterTransfer_KeyDown(object sender, KeyEventArgs e)
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