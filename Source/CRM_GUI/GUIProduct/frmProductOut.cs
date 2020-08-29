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
using CRM_DTO.DTOSystem;
using CRM_DTO.CRMUtility;
using CRM_BLL.BLLProduct;
using CRM_DTO.DTOProduct;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductOut : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public long gbTrnID = -1;
        #endregion

        #region Form
        public frmProductOut()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmProductOut_Load(object sender, EventArgs e)
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
        public GridColumn colProductID { get; set; }
        public GridColumn colProductCode { get; set; }
        public GridColumn colProductDesc { get; set; }
        public GridColumn colDescriptions { get; set; }
        public GridColumn colStallsID { get; set; }
        public GridColumn colStallsCode { get; set; }
        public GridColumn colStallsName { get; set; }
        public GridColumn colSupplierID { get; set; }
        public GridColumn colSupplierCode { get; set; }
        public GridColumn colSupplierName { get; set; }
        public GridColumn colWeightsOut { get; set; }
        public GridColumn colWeightsStock { get; set; }
        public GridColumn colWeightsStockReal { get; set; }
        public GridColumn colQuantityOut { get; set; }
        public GridColumn colQuantityStock { get; set; }
        public GridColumn colQuantityStockReal { get; set; }
        public GridColumn colNotes { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Xuất hàng";
            this.Load += new System.EventHandler(this.frmProductOut_Load);
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
            this.cboShop.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboShop.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboShop.Properties.View = this.grvCboShop;
            //this.cboShop.EditValueChanged += new System.EventHandler(this.cboShop_EditValueChanged);
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
            this.cboStalls.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboStalls.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboStalls.Properties.View = this.grvCboStalls;
            //this.cboStalls.EditValueChanged += new System.EventHandler(this.cboStalls_EditValueChanged);
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

            #region colProductID
            colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductID.AppearanceCell.Options.UseFont = true;
            colProductID.Caption = "ID hàng";
            colProductID.FieldName = "ProductID";
            colProductID.Name = "colProductID";
            colProductID.Visible = false;
            //colProductID.VisibleIndex = -1;
            colProductID.Width = 80;
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
            colProductCode.Width = 80;
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

            #region colDescriptions
            colDescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescriptions.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colDescriptions.AppearanceCell.Options.UseFont = true;
            colDescriptions.Caption = "Mô tả";
            colDescriptions.FieldName = "Descriptions";
            colDescriptions.Name = "colDescriptions";
            colDescriptions.Visible = true;
            colDescriptions.VisibleIndex = 2;
            colDescriptions.Width = 200;
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
            colStallsCode.FieldName = "CustCode";
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
            colStallsCode.Visible = false;
            //colStallsCode.VisibleIndex = -1;
            colStallsCode.Width = 120;
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
            colSupplierName.VisibleIndex = 3;
            colSupplierName.Width = 150;
            #endregion

            #region colWeightsOut
            colWeightsOut = new DevExpress.XtraGrid.Columns.GridColumn();
            colWeightsOut.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colWeightsOut.AppearanceCell.Options.UseFont = true;
            colWeightsOut.DisplayFormat.FormatString = "{0:#,##0}";
            colWeightsOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colWeightsOut.Caption = "Trọng lượng xuất";
            colWeightsOut.FieldName = "WeightsOut";
            colWeightsOut.Name = "colWeightsOut";
            colWeightsOut.Visible = true;
            colWeightsOut.VisibleIndex = 4;
            colWeightsOut.Width = 100;
            #endregion

            #region colWeightsStock
            colWeightsStock = new DevExpress.XtraGrid.Columns.GridColumn();
            colWeightsStock.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colWeightsStock.AppearanceCell.Options.UseFont = true;
            colWeightsStock.DisplayFormat.FormatString = "{0:#,##0}";
            colWeightsStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colWeightsStock.Caption = "Trọng lượng tồn";
            colWeightsStock.FieldName = "WeightsStock";
            colWeightsStock.Name = "colWeightsStock";
            colWeightsStock.Visible = true;
            colWeightsStock.VisibleIndex = 5;
            colWeightsStock.Width = 100;
            #endregion

            #region colWeightsStockReal
            colWeightsStockReal = new DevExpress.XtraGrid.Columns.GridColumn();
            colWeightsStockReal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colWeightsStockReal.AppearanceCell.Options.UseFont = true;
            colWeightsStockReal.DisplayFormat.FormatString = "{0:#,##0}";
            colWeightsStockReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colWeightsStockReal.Caption = "Trọng lượng tồn thực";
            colWeightsStockReal.FieldName = "WeightsStockReal";
            colWeightsStockReal.Name = "colWeightsStockReal";
            colWeightsStockReal.Visible = true;
            colWeightsStockReal.VisibleIndex = 5;
            colWeightsStockReal.Width = 100;
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
            colQuantityOut.VisibleIndex = 6;
            colQuantityOut.Width = 100;
            #endregion

            #region colQuantityStock
            colQuantityStock = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantityStock.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colQuantityStock.AppearanceCell.Options.UseFont = true;
            colQuantityStock.DisplayFormat.FormatString = "{0:#,##0}";
            colQuantityStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQuantityStock.Caption = "Số lượng tồn";
            colQuantityStock.FieldName = "QuantityStock";
            colQuantityStock.Name = "colQuantityStock";
            colQuantityStock.Visible = true;
            colQuantityStock.VisibleIndex = 7;
            colQuantityStock.Width = 130;
            #endregion

            #region colQuantityStockReal
            colQuantityStockReal = new DevExpress.XtraGrid.Columns.GridColumn();
            colQuantityStockReal.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colQuantityStockReal.AppearanceCell.Options.UseFont = true;
            colQuantityStockReal.DisplayFormat.FormatString = "{0:#,##0}";
            colQuantityStockReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQuantityStockReal.Caption = "Số lượng tồn thực";
            colQuantityStockReal.FieldName = "QuantityStockReal";
            colQuantityStockReal.Name = "colQuantityStockReal";
            colQuantityStockReal.Visible = true;
            colQuantityStockReal.VisibleIndex = 8;
            colQuantityStockReal.Width = 130;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 9;
            colNotes.Width = 250;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = true;
            layoutControlItemGridView.Text = "   Thông tin hàng xuất";
            grvProductOut.OptionsView.ShowGroupPanel = false;
            grvProductOut.OptionsBehavior.Editable = false;
            // Định dạng chữ dòng dữ liệu
            grvProductOut.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductOut.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductOut.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductOut.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductOut.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductOut.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductOut.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvProductOut.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colTrnID,
                colProductID,
                colProductCode,
                colProductDesc,
                colDescriptions,
                colStallsID,
                colStallsCode,
                colStallsName,
                colSupplierID,
                colSupplierCode,
                colSupplierName,
                colWeightsOut,
                colWeightsStock,
                colWeightsStockReal,
                colQuantityOut,
                colQuantityStock,
                colQuantityStockReal,
                colNotes,
            });
            grvProductOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvProductOut_KeyDown);
            grvProductOut.DoubleClick += new System.EventHandler(this.grvProductOut_DoubleClick);
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
            tblInit.Columns.Add("ProductID", typeof(long));
            tblInit.Columns.Add("ProductCode", typeof(string));
            tblInit.Columns.Add("ProductDesc", typeof(string));
            tblInit.Columns.Add("Descriptions", typeof(string));
            tblInit.Columns.Add("StallsID", typeof(long));
            tblInit.Columns.Add("StallsCode", typeof(string));
            tblInit.Columns.Add("StallsName", typeof(string));
            tblInit.Columns.Add("SupplierID", typeof(long));
            tblInit.Columns.Add("SupplierCode", typeof(string));
            tblInit.Columns.Add("SupplierName", typeof(string));
            tblInit.Columns.Add("WeightsOut", typeof(decimal));
            tblInit.Columns.Add("WeightsStock", typeof(decimal));
            tblInit.Columns.Add("WeightsStockReal", typeof(decimal));
            tblInit.Columns.Add("QuantityOut", typeof(int));
            tblInit.Columns.Add("QuantityStock", typeof(int));
            tblInit.Columns.Add("QuantityStockReal", typeof(int));
            tblInit.Columns.Add("Notes", typeof(string));
            return tblInit;
        }

        /// <summary>
        /// Cập nhật lưới dữ liệu thông tin các món hàng
        /// </summary>
        /// <param name="_Row"></param>
        /// <returns></returns>
        public bool AddItemDataSourceGrid(DTOTrnProductOutDT _TrnProductOutDT)
        {
            bool bResult = false;
            try
            {
                DataTable dtDtl = grcProductOut.DataSource as DataTable;
                DataRow drDtl = dtDtl.NewRow();
                drDtl["TrnID"] = _TrnProductOutDT.TrnID;
                drDtl["ProductID"] = _TrnProductOutDT.Product.ID;
                drDtl["ProductCode"] = _TrnProductOutDT.Product.ProductCode;
                drDtl["ProductDesc"] = _TrnProductOutDT.Product.ProductDesc;
                drDtl["Descriptions"] = _TrnProductOutDT.Product.Descriptions;
                drDtl["StallsID"] = _TrnProductOutDT.Stalls.ID;
                drDtl["StallsCode"] = _TrnProductOutDT.Stalls.StallsCode;
                drDtl["StallsName"] = _TrnProductOutDT.Stalls.StallsName;
                drDtl["SupplierID"] = _TrnProductOutDT.Supplier.ID;
                drDtl["SupplierCode"] = _TrnProductOutDT.Supplier.SupplierCode;
                drDtl["SupplierName"] = _TrnProductOutDT.Supplier.SupplierName;
                drDtl["WeightsOut"] = _TrnProductOutDT.WeightsOut;
                drDtl["WeightsStock"] = _TrnProductOutDT.WeightsStock;
                drDtl["WeightsStockReal"] = _TrnProductOutDT.WeightsStockReal;
                drDtl["QuantityOut"] = _TrnProductOutDT.QuantityOut;
                drDtl["QuantityStock"] = _TrnProductOutDT.QuantityStock;
                drDtl["QuantityStockReal"] = _TrnProductOutDT.QuantityStockReal;
                drDtl["Notes"] = _TrnProductOutDT.Notes;
                dtDtl.Rows.Add(drDtl);
                grcProductOut.DataSource = dtDtl;
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
                ds = BLLTrnProductOut.TrnProductOut_GetWithID(_TrnID, out sMessage);
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
                cboStatus.EditValue = ds.Tables[0].Rows[0]["StatusCode"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["StatusCode"];
                dtpTrnDate.EditValue = ds.Tables[0].Rows[0]["TrnDate"] == DBNull.Value ? -1 : ds.Tables[0].Rows[0]["TrnDate"];
                grcProductOut.DataSource = ds.Tables[1].Copy();
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
                grcProductOut.DataSource = InitDataSourceGrid();
                txtTrnCode.Text = "Tự động";
                txtNotes.Text = string.Empty;
                dtpTrnDate.EditValue = DateTime.Now;
                cboEmployee.EditValue = DTOAttributeSystem.CurrentEmployee.ID;
                cboShop.EditValue = DTOAttributeSystem.CurrentShop.ID;
                cboStalls.EditValue = null;
                cboStatus.EditValue = null;
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Cập nhật chi tiết
        /// </summary>
        private void EditDtlClick()
        {
            int idxFocused = grvProductOut.GetFocusedDataSourceRowIndex();
            if (idxFocused < 0)
            {
                VMHMessages.ShowWarning("Vui lòng chọn một dòng dữ liệu");
                return;
            }
            DTOTrnProductOutDT objTrnProductOutDT = new DTOTrnProductOutDT();
            objTrnProductOutDT.TrnID = grvProductOut.GetFocusedRowCellValue(colTrnID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductOut.GetFocusedRowCellValue(colTrnID));
            DTOProduct objProduct = new DTOProduct();
            objProduct.ID = grvProductOut.GetFocusedRowCellValue(colProductID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductOut.GetFocusedRowCellValue(colProductID));
            objProduct.ProductCode = grvProductOut.GetFocusedRowCellValue(colProductCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colProductCode));
            objProduct.ProductDesc = grvProductOut.GetFocusedRowCellValue(colProductDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colProductDesc));
            objProduct.Descriptions = grvProductOut.GetFocusedRowCellValue(colDescriptions) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colDescriptions));
            objTrnProductOutDT.Product = objProduct;
            DTOCatStalls objStalls = new DTOCatStalls();
            objStalls.ID = grvProductOut.GetFocusedRowCellValue(colStallsID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductOut.GetFocusedRowCellValue(colStallsID));
            objStalls.StallsCode = grvProductOut.GetFocusedRowCellValue(colStallsCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colStallsCode));
            objStalls.StallsName = grvProductOut.GetFocusedRowCellValue(colStallsName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colStallsName));
            objTrnProductOutDT.Stalls = objStalls;
            DTOCatSupplier objSupplier = new DTOCatSupplier();
            objSupplier.ID = grvProductOut.GetFocusedRowCellValue(colSupplierID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductOut.GetFocusedRowCellValue(colSupplierID));
            objSupplier.SupplierCode = grvProductOut.GetFocusedRowCellValue(colSupplierCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colSupplierCode));
            objSupplier.SupplierName = grvProductOut.GetFocusedRowCellValue(colSupplierName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colSupplierName));
            objTrnProductOutDT.Supplier = objSupplier;
            objTrnProductOutDT.WeightsOut = grvProductOut.GetFocusedRowCellValue(colWeightsOut) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductOut.GetFocusedRowCellValue(colWeightsOut));
            objTrnProductOutDT.WeightsStock = grvProductOut.GetFocusedRowCellValue(colWeightsStock) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductOut.GetFocusedRowCellValue(colWeightsStock));
            objTrnProductOutDT.WeightsStockReal = grvProductOut.GetFocusedRowCellValue(colWeightsStockReal) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductOut.GetFocusedRowCellValue(colWeightsStockReal));
            objTrnProductOutDT.QuantityOut = grvProductOut.GetFocusedRowCellValue(colQuantityOut) == DBNull.Value ? 0 : Convert.ToInt32(grvProductOut.GetFocusedRowCellValue(colQuantityOut));
            objTrnProductOutDT.QuantityStock = grvProductOut.GetFocusedRowCellValue(colQuantityStock) == DBNull.Value ? 0 : Convert.ToInt32(grvProductOut.GetFocusedRowCellValue(colQuantityStock));
            objTrnProductOutDT.QuantityStockReal = grvProductOut.GetFocusedRowCellValue(colQuantityStockReal) == DBNull.Value ? 0 : Convert.ToInt32(grvProductOut.GetFocusedRowCellValue(colQuantityStockReal));
            objTrnProductOutDT.Notes = grvProductOut.GetFocusedRowCellValue(colNotes) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOut.GetFocusedRowCellValue(colNotes)); 
            frmProductOutDtl frm = new frmProductOutDtl(this, objTrnProductOutDT.Stalls.ID, objTrnProductOutDT);
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
                if (grvProductOut.OptionsBehavior.Editable == true)
                {
                    if (VMHMessages.ShowConfirm("Bạn có muốn xóa dòng dữ liệu này không?") == DialogResult.OK)
                    {
                        int i = grvProductOut.FocusedRowHandle;
                        grvProductOut.DeleteRow(i);
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
                    bResult = BLLTrnProductOut.TrnProductOut_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
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
                    bResult = BLLTrnProductOut.TrnProductOut_Complete(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
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
            long lStallsID = cboStalls.EditValue == null ? -1 : Convert.ToInt64(cboStalls.EditValue);
            if(lStallsID == -1)
            {
                VMHMessages.ShowInformation("Vui lòng chọn quầy/kho!");
                return;
            }
            frmProductOutDtl frm = new frmProductOutDtl(this, lStallsID);
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
            frmProductOutLst frm = new frmProductOutLst(this);
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
        private void grvProductOut_KeyDown(object sender, KeyEventArgs e)
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

        private void grvProductOut_DoubleClick(object sender, EventArgs e)
        {
            EditDtlClick();
        }
        #endregion
    }
}