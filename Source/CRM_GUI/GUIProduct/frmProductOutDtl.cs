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
using CRM_DTO.CRMUtility;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_BLL.BLLCategories;
using CRM_DTO.DTOProduct;
using CRM_BLL.BLLSystem;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUIProduct
{
    public partial class frmProductOutDtl : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private DTOTrnProductOutDT ObjTrnProductOutDT = null;
        private frmProductOut FrmProductOut = null;
        private long gbStallsID = -1;
        #endregion

        #region Form
        public frmProductOutDtl()
        {
            InitializeComponent();
            DesignControls();
            ObjTrnProductOutDT = null;
            FrmProductOut = null;
        }

        public frmProductOutDtl(frmProductOut _Frm, long _StallsID)
        {
            InitializeComponent();
            DesignControls();
            FrmProductOut = _Frm;
            gbStallsID = _StallsID;
            ObjTrnProductOutDT = null;
        }

        public frmProductOutDtl(frmProductOut _Frm, long _StallsID, DTOTrnProductOutDT _TrnProductOutDT)
        {
            InitializeComponent();
            DesignControls();
            FrmProductOut = _Frm;
            gbStallsID = _StallsID;
            ObjTrnProductOutDT = new DTOTrnProductOutDT(_TrnProductOutDT);
        }

        private void frmProductOutDtl_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            grcProductOutDtl.DataSource = InitDataSourceGrid().Clone();
            LoadDefault();
            LoadDataToGrid(gbStallsID);
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboSupplier
        public GridView grvCboSupplier { get; set; }
        public GridColumn colCboSupplierID { get; set; }
        public GridColumn colCboSupplierCode { get; set; }
        public GridColumn colCboSupplierName { get; set; }
        public GridColumn colCboSupplierAddress { get; set; }
        public GridColumn colCboSupplierPhone { get; set; }
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
        /// Design giao diện
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Thông tin xuất hàng";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmProductOutDtl_Load);
            #endregion

            DesignTextSpinEdit();
            DesignGridLookUpEdit();
            DesignGridview();
        }

        /// <summary>
        /// Design TextSpinEdit
        /// </summary>
        private void DesignTextSpinEdit()
        {
            txtProductDesc.ReadOnly = true;
            txtProductDesc.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtProductDesc.Properties.Appearance.Options.UseBackColor = true;
            txtProductDesc.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            txtProductDesc.Properties.Appearance.Options.UseFont = true;
            txtProductDesc.TabStop = false;

            txtDescriptions.ReadOnly = true;
            txtDescriptions.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtDescriptions.Properties.Appearance.Options.UseBackColor = true;
            txtDescriptions.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            txtDescriptions.Properties.Appearance.Options.UseFont = true;
            txtDescriptions.TabStop = false;

            txtQuantityStock.Properties.DisplayFormat.FormatString = "#,###";
            txtQuantityStock.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityStock.Properties.EditFormat.FormatString = "#,###";
            txtQuantityStock.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityStock.Properties.Mask.EditMask = "n0";
            txtQuantityStock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtQuantityStock.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtQuantityStock.Properties.ReadOnly = true;
            txtQuantityStock.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtQuantityStock.Properties.Appearance.Options.UseBackColor = true;
            txtQuantityStock.TabStop = false;

            txtQuantityOut.Properties.DisplayFormat.FormatString = "#,###";
            txtQuantityOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityOut.Properties.EditFormat.FormatString = "#,###";
            txtQuantityOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityOut.Properties.Mask.EditMask = "n0";
            txtQuantityOut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtQuantityOut.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtWeightStock.Properties.DisplayFormat.FormatString = "#,###.##";
            txtWeightStock.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeightStock.Properties.EditFormat.FormatString = "#,###.##";
            txtWeightStock.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeightStock.Properties.Mask.EditMask = "n2";
            txtWeightStock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtWeightStock.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtWeightStock.Properties.ReadOnly = true;
            txtWeightStock.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtWeightStock.Properties.Appearance.Options.UseBackColor = true;
            txtWeightStock.TabStop = false;

            txtWeightOut.Properties.DisplayFormat.FormatString = "#,###.##";
            txtWeightOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeightOut.Properties.EditFormat.FormatString = "#,###.##";
            txtWeightOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeightOut.Properties.Mask.EditMask = "n2";
            txtWeightOut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtWeightOut.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtQuantityStockReal.Properties.DisplayFormat.FormatString = "#,###";
            txtQuantityStockReal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityStockReal.Properties.EditFormat.FormatString = "#,###";
            txtQuantityStockReal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtQuantityStockReal.Properties.Mask.EditMask = "n0";
            txtQuantityStockReal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtQuantityStockReal.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtQuantityStockReal.Properties.ReadOnly = true;
            txtQuantityStockReal.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtQuantityStockReal.Properties.Appearance.Options.UseBackColor = true;
            txtQuantityStockReal.TabStop = false;

            txtWeightStockReal.Properties.DisplayFormat.FormatString = "#,###.##";
            txtWeightStockReal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeightStockReal.Properties.EditFormat.FormatString = "#,###.##";
            txtWeightStockReal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtWeightStockReal.Properties.Mask.EditMask = "n2";
            txtWeightStockReal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtWeightStockReal.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtWeightStockReal.Properties.ReadOnly = true;
            txtWeightStockReal.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            txtWeightStockReal.Properties.Appearance.Options.UseBackColor = true;
            txtWeightStockReal.TabStop = false;
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
            #region cboSupplier
            //
            // colCboSupplierID
            //
            this.colCboSupplierID = new GridColumn();
            this.colCboSupplierID.Caption = "ID nhà cung cấp";
            this.colCboSupplierID.FieldName = "SupplierID";
            this.colCboSupplierID.Name = "colCboSupplierID";
            this.colCboSupplierID.Visible = false;
            //this.colCboSupplierID.VisibleIndex = -1;
            //
            // colCboSupplierCode
            //
            this.colCboSupplierCode = new GridColumn();
            this.colCboSupplierCode.Caption = "Mã nhà cung cấp";
            this.colCboSupplierCode.FieldName = "SupplierCode";
            this.colCboSupplierCode.Name = "colCboSupplierCode";
            this.colCboSupplierCode.Visible = true;
            this.colCboSupplierCode.VisibleIndex = 0;
            //
            // colCboSupplierName
            //
            this.colCboSupplierName = new GridColumn();
            this.colCboSupplierName.Caption = "Tên nhà cung cấp";
            this.colCboSupplierName.FieldName = "SupplierName";
            this.colCboSupplierName.Name = "colCboSupplierName";
            this.colCboSupplierName.Visible = true;
            this.colCboSupplierName.VisibleIndex = 1;
            // 
            // grvCboSupplier
            // 
            this.grvCboSupplier = new GridView();
            this.grvCboSupplier.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboSupplierID,
                this.colCboSupplierCode,
                this.colCboSupplierName});
            this.grvCboSupplier.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboSupplier.Name = "grvCboSupplier";
            this.grvCboSupplier.OptionsBehavior.Editable = false;
            this.grvCboSupplier.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboSupplier.OptionsView.ShowAutoFilterRow = true;
            this.grvCboSupplier.OptionsView.ShowGroupPanel = false;
            this.grvCboSupplier.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboSupplier.Appearance.Row.Options.UseFont = true;
            this.grvCboSupplier.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboSupplier.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboSupplier.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboSupplier.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboSupplier.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboSupplier
            // 
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.Appearance.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboSupplier.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboSupplier.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboSupplier.Properties.NullText = "";
            this.cboSupplier.Properties.ShowFooter = false;
            this.cboSupplier.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboSupplier.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboSupplier.Properties.View = this.grvCboSupplier;
            //this.cboSupplier.EditValueChanged += new System.EventHandler(this.cboSupplier_EditValueChanged);
            this.cboSupplier.ReadOnly = true;
            this.cboSupplier.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboSupplier.Properties.Appearance.Options.UseBackColor = true;
            this.cboSupplier.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboSupplier.Properties.Appearance.Options.UseFont = true;
            this.cboSupplier.TabStop = false;
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
            colProductCode.Width = 180;
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
            colStallsID.Visible = false;
            //colStallsID.VisibleIndex = -1;
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
            colWeightsStockReal.Width = 160;
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
            colStallsID.Visible = false;
            //colStallsID.VisibleIndex = -1;
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
            colQuantityStockReal.Width = 160;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colStallsID.Visible = false;
            //colStallsID.VisibleIndex = -1;
            colNotes.Width = 250;
            #endregion

            #region Gridview
            grvProductOutDtl.OptionsView.ShowGroupPanel = false;
            grvProductOutDtl.OptionsBehavior.Editable = false;
            // Hiển thị filter
            grvProductOutDtl.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvProductOutDtl.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductOutDtl.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductOutDtl.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductOutDtl.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductOutDtl.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductOutDtl.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductOutDtl.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            grvProductOutDtl.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductOutDtl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            grvProductOutDtl.DoubleClick += new System.EventHandler(this.grvProductOutDtl_DoubleClick);
            grvProductOutDtl.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvProductOutDtl_FocusedRowChanged);
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
        /// Load dữ liêu lên DropDownList
        /// </summary>
        private void LoadDataToDropDownList()
        {
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatSupplier.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboSupplier.Properties.DataSource = ds.Tables[0].Copy();
                    cboSupplier.Properties.DisplayMember = "SupplierName";
                    cboSupplier.Properties.ValueMember = "SupplierID";
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
        public void LoadDataToGrid(long _StallsID)
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                ds = BLLSysProductStock.SysProductStock_GetWithStalls(_StallsID, out sMessage);
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                    return;
                }
                grcProductOutDtl.DataSource = ds.Tables[0].Copy();
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
                txtProductCode.Properties.ReadOnly = ObjTrnProductOutDT != null ? true : false;

                txtProductCode.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.Product.ProductCode : string.Empty;
                txtProductDesc.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.Product.ProductDesc : string.Empty;
                txtDescriptions.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.Product.Descriptions : string.Empty;
                cboSupplier.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.Supplier.ID : -1;
                txtQuantityStock.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.QuantityStock : 0M;
                txtQuantityStockReal.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.QuantityStockReal : 0M;
                txtWeightStock.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.WeightsStock : 0M;
                txtWeightStockReal.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.WeightsStockReal : 0M;

                txtQuantityOut.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.QuantityOut : 0M;
                txtWeightOut.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.WeightsOut : 0M;
                txtNotes.EditValue = ObjTrnProductOutDT != null ? ObjTrnProductOutDT.Notes : string.Empty;

                //LoadDataToGrid(ObjTrnProductOutDT != null ? ObjTrnProductOutDT.StallsID : -1);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Xong
        /// </summary>
        /// <param name="_TrnID"></param>
        /// <param name="_Message"></param>
        /// <returns></returns>
        private bool OKClick(out string _Message)
        {
            _Message = string.Empty;
            bool bResult = false;
            try
            {
                DTOTrnProductOutDT objTrnProductOutDT = new DTOTrnProductOutDT();
                objTrnProductOutDT.TrnID = -1;
                DTOProduct objProduct = new DTOProduct();
                objProduct.ID = grvProductOutDtl.GetFocusedRowCellValue(colProductID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductOutDtl.GetFocusedRowCellValue(colProductID));
                objProduct.ProductCode = grvProductOutDtl.GetFocusedRowCellValue(colProductCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colProductCode));
                objProduct.ProductDesc = grvProductOutDtl.GetFocusedRowCellValue(colProductDesc) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colProductDesc));
                objProduct.Descriptions = grvProductOutDtl.GetFocusedRowCellValue(colDescriptions) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colDescriptions));
                objTrnProductOutDT.Product = objProduct;
                DTOCatStalls objCatStalls = new DTOCatStalls();
                objCatStalls.ID = grvProductOutDtl.GetFocusedRowCellValue(colStallsID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductOutDtl.GetFocusedRowCellValue(colStallsID));
                objCatStalls.StallsCode = grvProductOutDtl.GetFocusedRowCellValue(colStallsCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colStallsCode));
                objCatStalls.StallsName = grvProductOutDtl.GetFocusedRowCellValue(colStallsName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colStallsName));
                objTrnProductOutDT.Stalls = objCatStalls;
                DTOCatSupplier objCatSupplier = new DTOCatSupplier();
                objCatSupplier.ID = grvProductOutDtl.GetFocusedRowCellValue(colSupplierID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductOutDtl.GetFocusedRowCellValue(colSupplierID));
                objCatSupplier.SupplierCode = grvProductOutDtl.GetFocusedRowCellValue(colSupplierCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colSupplierCode));
                objCatSupplier.SupplierName = grvProductOutDtl.GetFocusedRowCellValue(colSupplierName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colSupplierName));
                objTrnProductOutDT.Supplier = objCatSupplier;
                objTrnProductOutDT.WeightsOut = txtWeightOut.EditValue == null ? 0M : Convert.ToDecimal(txtWeightOut.EditValue);
                objTrnProductOutDT.WeightsStock = grvProductOutDtl.GetFocusedRowCellValue(colWeightsStock) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductOutDtl.GetFocusedRowCellValue(colWeightsStock));
                objTrnProductOutDT.WeightsStockReal = grvProductOutDtl.GetFocusedRowCellValue(colWeightsStockReal) == DBNull.Value ? 0M : Convert.ToDecimal(grvProductOutDtl.GetFocusedRowCellValue(colWeightsStockReal));
                objTrnProductOutDT.QuantityOut = txtQuantityOut.EditValue == null ? 0 : Convert.ToInt32(txtQuantityOut.EditValue);
                objTrnProductOutDT.QuantityStock = grvProductOutDtl.GetFocusedRowCellValue(colQuantityStock) == DBNull.Value ? 0 : Convert.ToInt32(grvProductOutDtl.GetFocusedRowCellValue(colQuantityStock));
                objTrnProductOutDT.QuantityStockReal = grvProductOutDtl.GetFocusedRowCellValue(colQuantityStockReal) == DBNull.Value ? 0 : Convert.ToInt32(grvProductOutDtl.GetFocusedRowCellValue(colQuantityStockReal));
                objTrnProductOutDT.Notes = txtNotes.Text;
                bResult = FrmProductOut.AddItemDataSourceGrid(objTrnProductOutDT);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Button
        private void btnOK_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (OKClick(out sMessage))
            {
                VMHMessages.ShowPopup(MessagesText.TextHandlerSuccess, 1000);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDefault();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Gridview
        private void grvProductOutDtl_DoubleClick(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (OKClick(out sMessage))
            {
                VMHMessages.ShowPopup(MessagesText.TextHandlerSuccess, 1000);
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

        private void grvProductOutDtl_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtProductCode.Properties.ReadOnly = true;
            txtProductCode.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colProductCode) == null ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colProductCode));
            txtProductDesc.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colProductDesc) == null ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colProductDesc));
            txtDescriptions.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colDescriptions) == null ? string.Empty : Convert.ToString(grvProductOutDtl.GetFocusedRowCellValue(colDescriptions));
            cboSupplier.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colSupplierID) == null ? -1 : Convert.ToInt64(grvProductOutDtl.GetFocusedRowCellValue(colSupplierID));
            txtQuantityStock.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colQuantityStock) == null ? 0M : Convert.ToDecimal(grvProductOutDtl.GetFocusedRowCellValue(colQuantityStock));
            txtQuantityStockReal.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colQuantityStockReal) == null ? 0M : Convert.ToDecimal(grvProductOutDtl.GetFocusedRowCellValue(colQuantityStockReal));
            txtWeightStock.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colWeightsStock) == null ? 0M : Convert.ToDecimal(grvProductOutDtl.GetFocusedRowCellValue(colWeightsStock));
            txtWeightStockReal.EditValue = grvProductOutDtl.GetFocusedRowCellValue(colWeightsStockReal) == null ? 0M : Convert.ToDecimal(grvProductOutDtl.GetFocusedRowCellValue(colWeightsStockReal));
        }
        #endregion
    }
}