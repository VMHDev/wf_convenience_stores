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
using CRM_DTO.DTOProduct;
using CRM_BLL.BLLProduct;
using CRM_DTO.DTOSystem;
using CRM_DTO.CRMUtility;
using CRM_GUI.CRMFunctions;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductIn : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public long gbTrnID = -1;        
        #endregion

        #region Form
        public frmProductIn()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmProductIn_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            DisableControls(string.Empty);
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

        #region cboShop
        public GridView grvCboShop { get; set; }
        public GridColumn colCboShopID { get; set; }
        public GridColumn colCboShopCode { get; set; }
        public GridColumn colCboShopName { get; set; }
        public GridColumn colCboShopAddress { get; set; }
        public GridColumn colCboShopTel { get; set; }
        #endregion

        #region cboStalls
        public GridView grvCboStalls { get; set; }
        public GridColumn colCboStallsID { get; set; }
        public GridColumn colCboStallsCode { get; set; }
        public GridColumn colCboStallsName { get; set; }
        #endregion

        #region Gridview
        public GridColumn colTrnID { get; set; }
        public GridColumn colProductCode { get; set; }
        public GridColumn colProductDesc { get; set; }
        public GridColumn colProductTypeID { get; set; }
        public GridColumn colProductTypeCode { get; set; }
        public GridColumn colProductTypeName { get; set; }
        public GridColumn colProductGroupID { get; set; }
        public GridColumn colProductGroupCode { get; set; }
        public GridColumn colProductGroupName { get; set; }
        public GridColumn colDescriptions { get; set; }
        public GridColumn colProductWeight { get; set; }
        public GridColumn colQuantity { get; set; }
        public GridColumn colUnitWeightID { get; set; }
        public GridColumn colUnitWeightCode { get; set; }
        public GridColumn colUnitWeightDesc { get; set; }
        public GridColumn colUnitInID { get; set; }
        public GridColumn colUnitInCode { get; set; }
        public GridColumn colUnitInDesc { get; set; }
        public GridColumn colUnitSellID { get; set; }
        public GridColumn colUnitSellCode { get; set; }
        public GridColumn colUnitSellDesc { get; set; }
        public GridColumn colRateIn { get; set; }
        public GridColumn colRateSell { get; set; }
        public GridColumn colSupplierID { get; set; }
        public GridColumn colSupplierCode { get; set; }
        public GridColumn colSupplierName { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Nhập hàng";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmProductIn_Load);
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

            #region cboStalls
            //
            // colCboStallsID
            //
            this.colCboStallsID = new GridColumn();
            this.colCboStallsID.Caption = "ID quầy/kho";
            this.colCboStallsID.FieldName = "StallsID";
            this.colCboStallsID.Name = "colCboStallsID";
            this.colCboStallsID.Visible = false;
            //this.colCboStallsID.VisibleIndex = -1;
            //
            // colCboStallsCode
            //
            this.colCboStallsCode = new GridColumn();
            this.colCboStallsCode.Caption = "Mã quầy/kho";
            this.colCboStallsCode.FieldName = "StallsCode";
            this.colCboStallsCode.Name = "colCboStallsCode";
            this.colCboStallsCode.Visible = true;
            this.colCboStallsCode.VisibleIndex = 0;
            //
            // colCboStallsName
            //
            this.colCboStallsName = new GridColumn();
            this.colCboStallsName.Caption = "Tên quầy/kho";
            this.colCboStallsName.FieldName = "StallsName";
            this.colCboStallsName.Name = "colCboStallsName";
            this.colCboStallsName.Visible = true;
            this.colCboStallsName.VisibleIndex = 1;
            // 
            // grvCboStalls
            // 
            this.grvCboStalls = new GridView();
            this.grvCboStalls.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboStallsID,
                this.colCboStallsCode,
                this.colCboStallsName});
            this.grvCboStalls.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboStalls.Name = "grvCboStalls";
            this.grvCboStalls.OptionsBehavior.Editable = false;
            this.grvCboStalls.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboStalls.OptionsView.ShowAutoFilterRow = true;
            this.grvCboStalls.OptionsView.ShowGroupPanel = false;
            this.grvCboStalls.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStalls.Appearance.Row.Options.UseFont = true;
            this.grvCboStalls.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboStalls.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboStalls.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboStalls.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboStalls.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboStalls
            // 
            this.cboStalls.Name = "cboStalls";
            this.cboStalls.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStalls.Properties.Appearance.Options.UseFont = true;
            this.cboStalls.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStalls.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboStalls.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStalls.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboStalls.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStalls.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboStalls.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboStalls.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboStalls.Properties.NullText = "";
            this.cboStalls.Properties.ShowFooter = false;
            this.cboStalls.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboStalls.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboStalls.Properties.View = this.grvCboStalls;
            //this.cboStalls.EditValueChanged += new System.EventHandler(this.cboStalls_EditValueChanged);
            #endregion

            #region cboShop
            //
            // colCboShopID
            //
            this.colCboShopID = new GridColumn();
            this.colCboShopID.Caption = "ID cửa hàng";
            this.colCboShopID.FieldName = "ShopID";
            this.colCboShopID.Name = "colCboShopID";
            this.colCboShopID.Visible = false;
            //this.colCboShopID.VisibleIndex = -1;
            //
            // colCboShopCode
            //
            this.colCboShopCode = new GridColumn();
            this.colCboShopCode.Caption = "Mã cửa hàng";
            this.colCboShopCode.FieldName = "ShopCode";
            this.colCboShopCode.Name = "colCboShopCode";
            this.colCboShopCode.Visible = true;
            this.colCboShopCode.VisibleIndex = 0;
            //
            // colCboShopName
            //
            this.colCboShopName = new GridColumn();
            this.colCboShopName.Caption = "Tên cửa hàng";
            this.colCboShopName.FieldName = "ShopName";
            this.colCboShopName.Name = "colCboShopName";
            this.colCboShopName.Visible = true;
            this.colCboShopName.VisibleIndex = 1;
            // 
            // grvCboShop
            // 
            this.grvCboShop = new GridView();
            this.grvCboShop.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboShopID,
                this.colCboShopCode,
                this.colCboShopName});
            this.grvCboShop.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboShop.Name = "grvCboShop";
            this.grvCboShop.OptionsBehavior.Editable = false;
            this.grvCboShop.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboShop.OptionsView.ShowAutoFilterRow = true;
            this.grvCboShop.OptionsView.ShowGroupPanel = false;
            this.grvCboShop.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboShop.Appearance.Row.Options.UseFont = true;
            this.grvCboShop.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboShop.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboShop.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboShop.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboShop.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboShop
            // 
            this.cboShop.Name = "cboShop";
            this.cboShop.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShop.Properties.Appearance.Options.UseFont = true;
            this.cboShop.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShop.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboShop.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShop.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboShop.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShop.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboShop.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboShop.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboShop.Properties.NullText = "";
            this.cboShop.Properties.ShowFooter = false;
            this.cboShop.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboShop.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboShop.Properties.View = this.grvCboShop;
            this.cboShop.EditValueChanged += new System.EventHandler(this.cboShop_EditValueChanged);
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

            #region colProductCode
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductCode.AppearanceCell.Options.UseFont = true;
            colProductCode.Caption = "Mã hàng";
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 0;
            colProductCode.Width = 150;
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
            colProductDesc.Width = 200;
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
            #endregion

            #region colProductTypeName
            colProductTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductTypeName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductTypeName.AppearanceCell.Options.UseFont = true;
            colProductTypeName.Caption = "Loại hàng";
            colProductTypeName.FieldName = "ProductTypeName";
            colProductTypeName.Name = "colProductTypeName";
            colProductTypeName.Visible = true;
            colProductTypeName.VisibleIndex = 2;
            colProductTypeName.Width = 150;
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
            #endregion

            #region colProductGroupName
            colProductGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductGroupName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductGroupName.AppearanceCell.Options.UseFont = true;
            colProductGroupName.Caption = "Nhóm hàng";
            colProductGroupName.FieldName = "ProductGroupName";
            colProductGroupName.Name = "colProductGroupName";
            colProductGroupName.Visible = true;
            colProductGroupName.VisibleIndex = 3;
            colProductGroupName.Width = 150;
            #endregion

            #region colDescriptions
            colDescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescriptions.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDescriptions.AppearanceCell.Options.UseFont = true;
            colDescriptions.Caption = "Mô tả";
            colDescriptions.FieldName = "Descriptions";
            colDescriptions.Name = "colDescriptions";
            colDescriptions.Visible = true;
            colDescriptions.VisibleIndex = 4;
            colDescriptions.Width = 250;
            #endregion

            #region colProductWeight
            colProductWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductWeight.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductWeight.AppearanceCell.Options.UseFont = true;
            colProductWeight.DisplayFormat.FormatString = "{0:#,##0}";
            colProductWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colProductWeight.Caption = "Trọng lượng";
            colProductWeight.FieldName = "ProductWeight";
            colProductWeight.Name = "colProductWeight";
            colProductWeight.Visible = true;
            colProductWeight.VisibleIndex = 5;
            colProductWeight.Width = 100;
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
            colQuantity.VisibleIndex = 6;
            colQuantity.Width = 100;
            #endregion

            #region colUnitWeightID
            colUnitWeightID = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitWeightID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitWeightID.AppearanceCell.Options.UseFont = true;
            colUnitWeightID.Caption = "ID Đơn vị cân";
            colUnitWeightID.FieldName = "UnitWeightID";
            colUnitWeightID.Name = "colUnitWeightID";
            colUnitWeightID.Visible = false;
            //colUnitWeightID.VisibleIndex = -1;
            colUnitWeightID.Width = 80;
            #endregion

            #region colUnitWeightCode
            colUnitWeightCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitWeightCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitWeightCode.AppearanceCell.Options.UseFont = true;
            colUnitWeightCode.Caption = "Mã Đơn vị cân";
            colUnitWeightCode.FieldName = "CustCode";
            colUnitWeightCode.Name = "colUnitWeightCode";
            colUnitWeightCode.Visible = false;
            //colUnitWeightCode.VisibleIndex = -1;
            colUnitWeightCode.Width = 120;
            #endregion

            #region colUnitWeightDesc
            colUnitWeightDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitWeightDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitWeightDesc.AppearanceCell.Options.UseFont = true;
            colUnitWeightDesc.Caption = "Đơn vị cân";
            colUnitWeightDesc.FieldName = "UnitWeightDesc";
            colUnitWeightDesc.Name = "colUnitWeightDesc";
            colUnitWeightDesc.Visible = true;
            colUnitWeightDesc.VisibleIndex = 7;
            colUnitWeightDesc.Width = 150;
            #endregion

            #region colUnitInID
            colUnitInID = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitInID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitInID.AppearanceCell.Options.UseFont = true;
            colUnitInID.Caption = "ID Đơn vị nhập";
            colUnitInID.FieldName = "UnitInID";
            colUnitInID.Name = "colUnitInID";
            colUnitInID.Visible = false;
            //colUnitInID.VisibleIndex = -1;
            colUnitInID.Width = 80;
            #endregion

            #region colUnitInCode
            colUnitInCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitInCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitInCode.AppearanceCell.Options.UseFont = true;
            colUnitInCode.Caption = "Mã Đơn vị nhập";
            colUnitInCode.FieldName = "CustCode";
            colUnitInCode.Name = "colUnitInCode";
            colUnitInCode.Visible = false;
            //colUnitInCode.VisibleIndex = -1;
            colUnitInCode.Width = 120;
            #endregion

            #region colUnitInDesc
            colUnitInDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitInDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitInDesc.AppearanceCell.Options.UseFont = true;
            colUnitInDesc.Caption = "Đơn vị nhập";
            colUnitInDesc.FieldName = "UnitInDesc";
            colUnitInDesc.Name = "colUnitInDesc";
            colUnitInDesc.Visible = true;
            colUnitInDesc.VisibleIndex = 8;
            colUnitInDesc.Width = 150;
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
            #endregion

            #region colUnitSellCode
            colUnitSellCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitSellCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitSellCode.AppearanceCell.Options.UseFont = true;
            colUnitSellCode.Caption = "Mã Đơn vị bán";
            colUnitSellCode.FieldName = "CustCode";
            colUnitSellCode.Name = "colUnitSellCode";
            colUnitSellCode.Visible = false;
            //colUnitSellCode.VisibleIndex = -1;
            colUnitSellCode.Width = 120;
            #endregion

            #region colUnitSellDesc
            colUnitSellDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitSellDesc.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUnitSellDesc.AppearanceCell.Options.UseFont = true;
            colUnitSellDesc.Caption = "Đơn vị bán";
            colUnitSellDesc.FieldName = "UnitSellDesc";
            colUnitSellDesc.Name = "colUnitSellDesc";
            colUnitSellDesc.Visible = true;
            colUnitSellDesc.VisibleIndex = 9;
            colUnitSellDesc.Width = 150;
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
            colRateIn.Visible = true;
            colRateIn.VisibleIndex = 10;
            colRateIn.Width = 100;
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
            colRateSell.VisibleIndex = 11;
            colRateSell.Width = 100;
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
            #endregion

            #region colSupplierCode
            colSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colSupplierCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colSupplierCode.AppearanceCell.Options.UseFont = true;
            colSupplierCode.Caption = "Mã Nhà cung cấp";
            colSupplierCode.FieldName = "CustCode";
            colSupplierCode.Name = "colSupplierCode";
            colSupplierCode.Visible = false;
            //colSupplierCode.VisibleIndex = -1;
            colSupplierCode.Width = 120;
            #endregion

            #region colSupplierName
            colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            colSupplierName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colSupplierName.AppearanceCell.Options.UseFont = true;
            colSupplierName.Caption = "Nhà cung cấp";
            colSupplierName.FieldName = "SupplierName";
            colSupplierName.Name = "colSupplierName";
            colSupplierName.Visible = true;
            colSupplierName.VisibleIndex = 12;
            colSupplierName.Width = 150;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = true;
            layoutControlItemGridView.Text = "   Thông tin hàng nhập";
            grvProductIn.OptionsView.ShowGroupPanel = false;
            grvProductIn.OptionsBehavior.Editable = false;
            // Định dạng chữ dòng dữ liệu
            grvProductIn.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductIn.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductIn.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductIn.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductIn.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductIn.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductIn.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            grvProductIn.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colTrnID,
            colProductCode,
            colProductDesc,
            colProductTypeID,
            colProductTypeCode,
            colProductTypeName,
            colProductGroupID,
            colProductGroupCode,
            colProductGroupName,
            colDescriptions,
            colProductWeight,
            colQuantity,
            colUnitWeightID,
            colUnitWeightCode,
            colUnitWeightDesc,
            colUnitInID,
            colUnitInCode,
            colUnitInDesc,
            colUnitSellID,
            colUnitSellCode,
            colUnitSellDesc,
            colRateIn,
            colRateSell,
            colSupplierID,
            colSupplierCode,
            colSupplierName,
            });
            grvProductIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvProductIn_KeyDown);
            grvProductIn.DoubleClick += new System.EventHandler(this.grvProductIn_DoubleClick);
            #endregion
        }
        #endregion

        #region Function
        /// <summary>
        /// Khởi tạo datasource trên lưới
        /// </summary>
        /// <returns></returns>
        public DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("TrnID", typeof(long));
            tblInit.Columns.Add("ProductCode", typeof(string));
            tblInit.Columns.Add("ProductDesc", typeof(string));
            tblInit.Columns.Add("ProductTypeID", typeof(long));
            tblInit.Columns.Add("ProductTypeCode", typeof(string));
            tblInit.Columns.Add("ProductTypeName", typeof(string));
            tblInit.Columns.Add("ProductGroupID", typeof(long));
            tblInit.Columns.Add("ProductGroupCode", typeof(string));
            tblInit.Columns.Add("ProductGroupName", typeof(string));
            tblInit.Columns.Add("Descriptions", typeof(string));
            tblInit.Columns.Add("ProductWeight", typeof(decimal));
            tblInit.Columns.Add("Quantity", typeof(int));
            tblInit.Columns.Add("UnitWeightID", typeof(long));
            tblInit.Columns.Add("UnitWeightCode", typeof(string));
            tblInit.Columns.Add("UnitWeightDesc", typeof(string));
            tblInit.Columns.Add("UnitInID", typeof(long));
            tblInit.Columns.Add("UnitInCode", typeof(string));
            tblInit.Columns.Add("UnitInDesc", typeof(string));
            tblInit.Columns.Add("UnitSellID", typeof(long));
            tblInit.Columns.Add("UnitSellCode", typeof(string));
            tblInit.Columns.Add("UnitSellDesc", typeof(string));
            tblInit.Columns.Add("RateIn", typeof(decimal));
            tblInit.Columns.Add("RateSell", typeof(decimal));
            tblInit.Columns.Add("SupplierID", typeof(long));
            tblInit.Columns.Add("SupplierCode", typeof(string));
            tblInit.Columns.Add("SupplierName", typeof(string));
            return tblInit;
        }

        /// <summary>
        /// Cập nhật lưới dữ liệu thông tin các món hàng
        /// </summary>
        /// <param name="_Row"></param>
        /// <returns></returns>
        public bool AddItemDataSourceGrid(DTOTrnProductInDT _TrnProductInDT)
        {
            bool bResult = false;
            try
            {
                DataTable dtDtl = grcProductIn.DataSource as DataTable;
                DataRow drDtl = dtDtl.NewRow();
                drDtl["TrnID"] = _TrnProductInDT.TrnID;
                drDtl["ProductCode"] = _TrnProductInDT.Product.ProductCode;
                drDtl["ProductDesc"] = _TrnProductInDT.Product.ProductDesc;
                drDtl["ProductTypeID"] = _TrnProductInDT.Product.ProductType.ID;
                drDtl["ProductTypeCode"] = _TrnProductInDT.Product.ProductType.ProductTypeCode;
                drDtl["ProductTypeName"] = _TrnProductInDT.Product.ProductType.ProductTypeName;
                drDtl["ProductGroupID"] = _TrnProductInDT.Product.ProductGroup.ID;
                drDtl["ProductGroupCode"] = _TrnProductInDT.Product.ProductGroup.ProductGroupCode;
                drDtl["ProductGroupName"] = _TrnProductInDT.Product.ProductGroup.ProductGroupName;
                drDtl["Descriptions"] = _TrnProductInDT.Product.Descriptions;
                drDtl["ProductWeight"] = _TrnProductInDT.ProductWeight;
                drDtl["Quantity"] = _TrnProductInDT.Quantity;
                drDtl["UnitWeightID"] = _TrnProductInDT.UnitWeight.ID;
                drDtl["UnitWeightCode"] = _TrnProductInDT.UnitWeight.UnitWeightCode;
                drDtl["UnitWeightDesc"] = _TrnProductInDT.UnitWeight.UnitWeightDesc;
                drDtl["UnitInID"] = _TrnProductInDT.UnitIn.ID;
                drDtl["UnitInCode"] = _TrnProductInDT.UnitIn.UnitInCode;
                drDtl["UnitInDesc"] = _TrnProductInDT.UnitIn.UnitInDesc;
                drDtl["UnitSellID"] = _TrnProductInDT.UnitSell.ID;
                drDtl["UnitSellCode"] = _TrnProductInDT.UnitSell.UnitSellCode;
                drDtl["UnitSellDesc"] = _TrnProductInDT.UnitSell.UnitSellDesc;
                drDtl["RateIn"] = _TrnProductInDT.RateIn;
                drDtl["RateSell"] = _TrnProductInDT.RateSell;
                drDtl["SupplierID"] = _TrnProductInDT.Supplier.ID;
                drDtl["SupplierCode"] = _TrnProductInDT.Supplier.SupplierCode;
                drDtl["SupplierName"] = _TrnProductInDT.Supplier.SupplierName;
                dtDtl.Rows.Add(drDtl);
                grcProductIn.DataSource = dtDtl;
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
                ds = BLLSysStatus.LoadDataCombobox("STATUS_TRN_PRODUCT_IN", out sMessages);
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
                ds = BLLCatShop.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboShop.Properties.DataSource = ds.Tables[0].Copy();
                    cboShop.Properties.DisplayMember = "ShopName";
                    cboShop.Properties.ValueMember = "ShopID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatStalls.LoadDataCombobox(DTOAttributeSystem.CurrentShop.ID, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboStalls.Properties.DataSource = ds.Tables[0].Copy();
                    cboStalls.Properties.DisplayMember = "StallsName";
                    cboStalls.Properties.ValueMember = "StallsID";
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
                ds = BLLTrnProductIn.TrnProductIn_GetWithID(_TrnID, out sMessage);
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                    return;
                }
                txtTrnCode.EditValue = ds.Tables[0].Rows[0]["TrnCode"] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[0]["TrnCode"];
                txtNotes.EditValue = ds.Tables[0].Rows[0]["Notes"] == DBNull.Value ? string.Empty : ds.Tables[0].Rows[0]["Notes"];
                cboEmployee.EditValue = ds.Tables[0].Rows[0]["EmpID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["EmpID"];
                cboShop.EditValue = ds.Tables[0].Rows[0]["ShopID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["ShopID"];
                cboStalls.EditValue = ds.Tables[0].Rows[0]["StallsID"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["StallsID"];                
                dtpTrnDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["TrnDate"];
                grcProductIn.DataSource = ds.Tables[1].Copy();

                string sStatus = ds.Tables[0].Rows[0]["StatusCode"] == DBNull.Value ? "" : Convert.ToString(ds.Tables[0].Rows[0]["StatusCode"]);
                cboStatus.EditValue = sStatus;
                DisableControls(sStatus);
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
                grcProductIn.DataSource = InitDataSourceGrid();
                txtTrnCode.Text = "Tự động";
                txtNotes.Text = string.Empty;                
                dtpTrnDate.EditValue = DateTime.Now;
                cboEmployee.EditValue = DTOAttributeSystem.CurrentEmployee.ID;
                cboShop.EditValue = DTOAttributeSystem.CurrentShop.ID;
                cboStalls.EditValue = -1;
                cboStatus.EditValue = "";
                DisableControls("");
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Disable/Enable Controls
        /// </summary>
        /// <param name="_StatusCode">Tình trạng</param>
        private void DisableControls(string _StatusCode)
        {
            if(_StatusCode == string.Empty)
            {
                cboEmployee.Enabled = true;
                cboStalls.Enabled = true;
                txtNotes.Enabled = true;

                btnAddDtl.Enabled = true;
                btnEditDtl.Enabled = true;
                btnDeleteDtl.Enabled = true;
                btnReset.Enabled = true;
                btnSave.Enabled = true;
                btnComplete.Enabled = false;
                btnDelete.Enabled = false;
                btnList.Enabled = true;
            }
            else if(_StatusCode == "S")
            {
                cboEmployee.Enabled = true;
                cboStalls.Enabled = true;
                txtNotes.Enabled = true;

                btnAddDtl.Enabled = true;
                btnEditDtl.Enabled = true;
                btnDeleteDtl.Enabled = true;
                btnReset.Enabled = true;
                btnSave.Enabled = true;
                btnComplete.Enabled = true;
                btnDelete.Enabled = true;
                btnList.Enabled = true;
            }
            else if (_StatusCode == "C")
            {
                cboEmployee.Enabled = false;
                cboStalls.Enabled = false;
                txtNotes.Enabled = false;

                btnAddDtl.Enabled = false;
                btnEditDtl.Enabled = false;
                btnDeleteDtl.Enabled = false;
                btnReset.Enabled = true;
                btnSave.Enabled = false;
                btnComplete.Enabled = false;
                btnDelete.Enabled = false;
                btnList.Enabled = true;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu hợp lệ trước khi lưu
        /// </summary>
        /// <returns>true: Hợp lệ | false: Không hợp lệ</returns>
        private bool IsValidSave()
        {
            long lStallsID = cboStalls.EditValue == null ? -1 : Convert.ToInt64(cboStalls.EditValue);
            if (lStallsID == -1)
            {
                VMHMessages.ShowWarning("Vui lòng chọn quầy/kho");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật chi tiết
        /// </summary>
        private void EditDtlClick()
        {
            int idxFocused = grvProductIn.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                VMHMessages.ShowWarning("Vui lòng chọn một dòng dữ liệu");
                return;
            }
            DTOTrnProductInDT objTrnProductInDT = new DTOTrnProductInDT();
            objTrnProductInDT.TrnID = grvProductIn.GetFocusedRowCellValue(colTrnID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductIn.GetFocusedRowCellValue(colTrnID));
            DTOProduct objProduct = new DTOProduct();
            objProduct.ProductCode = grvProductIn.GetFocusedRowCellValue(colProductCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colProductCode));
            objProduct.ProductDesc = grvProductIn.GetFocusedRowCellValue(colProductDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colProductDesc));
            objProduct.Descriptions = grvProductIn.GetFocusedRowCellValue(colDescriptions) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colDescriptions));
            DTOCatProductType objCatProductType = new DTOCatProductType();
            objCatProductType.ID = grvProductIn.GetFocusedRowCellValue(colProductTypeID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductIn.GetFocusedRowCellValue(colProductTypeID));
            objCatProductType.ProductTypeCode = grvProductIn.GetFocusedRowCellValue(colProductTypeCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colProductTypeCode));
            objCatProductType.ProductTypeName = grvProductIn.GetFocusedRowCellValue(colProductTypeName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colProductTypeName));
            objProduct.ProductType = objCatProductType;
            DTOCatProductGroup objCatProductGroup = new DTOCatProductGroup();
            objCatProductGroup.ID = grvProductIn.GetFocusedRowCellValue(colProductGroupID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductIn.GetFocusedRowCellValue(colProductGroupID));
            objCatProductGroup.ProductGroupCode = grvProductIn.GetFocusedRowCellValue(colProductGroupCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colProductGroupCode));
            objCatProductGroup.ProductGroupName = grvProductIn.GetFocusedRowCellValue(colProductGroupName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colProductGroupName));
            objProduct.ProductGroup = objCatProductGroup;
            objTrnProductInDT.Product = objProduct;
            objTrnProductInDT.ProductWeight = grvProductIn.GetFocusedRowCellValue(colProductWeight) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductIn.GetFocusedRowCellValue(colProductWeight));
            objTrnProductInDT.Quantity = grvProductIn.GetFocusedRowCellValue(colQuantity) == DBNull.Value ? 0 : Convert.ToInt32(grvProductIn.GetFocusedRowCellValue(colQuantity));
            DTOCatUnitWeight objCatUnitWeight = new DTOCatUnitWeight();
            objCatUnitWeight.ID = grvProductIn.GetFocusedRowCellValue(colUnitWeightID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductIn.GetFocusedRowCellValue(colUnitWeightID));
            objCatUnitWeight.UnitWeightCode = grvProductIn.GetFocusedRowCellValue(colUnitWeightCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colUnitWeightCode));
            objCatUnitWeight.UnitWeightDesc = grvProductIn.GetFocusedRowCellValue(colUnitWeightDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colUnitWeightDesc));
            objTrnProductInDT.UnitWeight = objCatUnitWeight;
            DTOCatUnitIn objCatUnitIn = new DTOCatUnitIn();
            objCatUnitIn.ID = grvProductIn.GetFocusedRowCellValue(colUnitInID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductIn.GetFocusedRowCellValue(colUnitInID));
            objCatUnitIn.UnitInCode = grvProductIn.GetFocusedRowCellValue(colUnitInCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colUnitInCode));
            objCatUnitIn.UnitInDesc = grvProductIn.GetFocusedRowCellValue(colUnitInDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colUnitInDesc));
            objTrnProductInDT.UnitIn = objCatUnitIn;
            DTOCatUnitSell objCatUnitSell = new DTOCatUnitSell();
            objCatUnitSell.ID = grvProductIn.GetFocusedRowCellValue(colUnitSellID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductIn.GetFocusedRowCellValue(colUnitSellID));
            objCatUnitSell.UnitSellCode = grvProductIn.GetFocusedRowCellValue(colUnitSellCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colUnitSellCode));
            objCatUnitSell.UnitSellDesc = grvProductIn.GetFocusedRowCellValue(colUnitSellDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colUnitSellDesc));
            objTrnProductInDT.UnitSell = objCatUnitSell;
            objTrnProductInDT.RateIn = grvProductIn.GetFocusedRowCellValue(colRateIn) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductIn.GetFocusedRowCellValue(colRateIn));
            objTrnProductInDT.RateSell = grvProductIn.GetFocusedRowCellValue(colRateSell) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductIn.GetFocusedRowCellValue(colRateSell));
            DTOCatSupplier objCatSupplier = new DTOCatSupplier();
            objCatSupplier.ID = grvProductIn.GetFocusedRowCellValue(colSupplierID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductIn.GetFocusedRowCellValue(colSupplierID));
            objCatSupplier.SupplierCode = grvProductIn.GetFocusedRowCellValue(colSupplierCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colSupplierCode));
            objCatSupplier.SupplierName = grvProductIn.GetFocusedRowCellValue(colSupplierName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductIn.GetFocusedRowCellValue(colSupplierName));
            objTrnProductInDT.Supplier = objCatSupplier;
            frmProductInDtl frm = new frmProductInDtl(this, objTrnProductInDT);
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
                if (grvProductIn.OptionsBehavior.Editable == true)
                {
                    if (VMHMessages.ShowConfirm("Bạn có muốn xóa dòng dữ liệu này không?") == DialogResult.OK)
                    {
                        int i = grvProductIn.FocusedRowHandle;
                        grvProductIn.DeleteRow(i);
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
                if (!IsValidSave())
                {
                    return false;
                }

                long lCurrentID = FuncGeneral.GetCurrentID("TRN_PRODUCT_IN");
                _TrnCodeUdp = _TrnID == -1 ? FuncGeneral.GenTransactionCode("TRN_PRODUCT_IN", lCurrentID) : _TrnCode;

                DTOTrnProductIn objTrnProductIn = new DTOTrnProductIn();
                objTrnProductIn.TrnID = _TrnID;
                objTrnProductIn.TrnCode = _TrnCodeUdp;
                objTrnProductIn.TrnDate = DateTime.Now;
                objTrnProductIn.TrnTime = TimeSpan.FromTicks(DateTime.Now.ToLocalTime().Ticks);
                DTOCatStalls objCatStalls = new DTOCatStalls();
                objCatStalls.ID = cboStalls.EditValue == null ? -1 : Convert.ToInt64(cboStalls.EditValue);
                objTrnProductIn.Stalls = objCatStalls;
                objTrnProductIn.Notes = txtNotes.Text;
                DTOCatEmployee objCatEmployee = new DTOCatEmployee();
                objCatEmployee.ID = cboEmployee.EditValue == null ? -1 : Convert.ToInt64(cboEmployee.EditValue);
                objTrnProductIn.Employee = objCatEmployee;
                objTrnProductIn.StatusCode = "S";
                objTrnProductIn.UpdateDate = DateTime.Now;
                objTrnProductIn.UpdateBy = DTOAttributeSystem.CurrentUser.ID;
                objTrnProductIn.IsDelete = false;

                DataTable dtDtl = new DataTable("Transaction");
                dtDtl = ((DataView)grvProductIn.DataSource).ToTable("Transaction");
                lCurrentID = FuncGeneral.GetCurrentID("OBJ_PRODUCT");
                foreach (DataRow drDtl in dtDtl.Rows)
                {
                    string sProductCodeExist = drDtl["ProductCode"] == DBNull.Value ? string.Empty : Convert.ToString(drDtl["ProductCode"]);
                    if(string.IsNullOrWhiteSpace(sProductCodeExist))
                    {
                        long lProductTypeID = drDtl["ProductTypeID"] == DBNull.Value ? -1 : Convert.ToInt64(drDtl["ProductTypeID"]);
                        long lProductGroupID = drDtl["ProductGroupID"] == DBNull.Value ? -1 : Convert.ToInt64(drDtl["ProductGroupID"]);
                        string sProductCode = FuncGeneral.GenProductCode("OBJ_PRODUCT", lCurrentID, lProductTypeID, lProductGroupID);
                        drDtl["ProductCode"] = sProductCode;
                        lCurrentID++;
                    }
                }
                grcProductIn.DataSource = dtDtl.Copy();
                dtDtl.DefaultView.Sort = "ProductCode DESC";
                ds.Tables.Add(dtDtl);
                string xmlDtl = ds.GetXml();
                bResult = BLLTrnProductIn.TrnProductIn_InsUpd(objTrnProductIn, xmlDtl, out _TrnIDUdp, out _Message);
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
        /// <param name="_TrnIn">ID giao dịch</param>
        /// <param name="_UserUpdate">ID User</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool CompleteClick(long _TrnIn, long _UserUpdate, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                bResult = BLLTrnProductIn.TrnProductIn_Complete(_TrnIn, _UserUpdate, out _Message);
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
                    bResult = BLLTrnProductIn.TrnProductIn_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
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
            frmProductInDtl frm = new frmProductInDtl(this);
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
            string sMessage = string.Empty;
            string sTrnCodeUdp = string.Empty;
            string sTrnCode = txtTrnCode.Text.Trim();
            long lTrnID = -1;
            if (SaveClick(gbTrnID, sTrnCode, out lTrnID, out sTrnCodeUdp, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.HandlerSuccess("Lưu"));
                txtTrnCode.EditValue = sTrnCodeUdp;
                gbTrnID = lTrnID;
                cboStatus.EditValue = "S";
                DisableControls("S");
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
            if (CompleteClick(gbTrnID, DTOAttributeSystem.CurrentUser.ID, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
                cboStatus.EditValue = "C";
                DisableControls("C");
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
            frmProductInLst frm = new frmProductInLst(this);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Combobox
        private void cboShop_EditValueChanged(object sender, EventArgs e)
        {
            long lShopID = cboShop.EditValue == null ? -1 : Convert.ToInt64(cboShop.EditValue);
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatStalls.LoadDataCombobox(lShopID, out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboStalls.Properties.DataSource = ds.Tables[0].Copy();
                    cboStalls.Properties.DisplayMember = "StallsName";
                    cboStalls.Properties.ValueMember = "StallsID";
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
        private void grvProductIn_KeyDown(object sender, KeyEventArgs e)
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

        private void grvProductIn_DoubleClick(object sender, EventArgs e)
        {
            EditDtlClick();
        }
        #endregion
    }
}