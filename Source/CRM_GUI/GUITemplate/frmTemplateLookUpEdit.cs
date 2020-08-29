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

namespace CRM_GUI.GUITemplate
{
    public partial class frmTemplateLookUpEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmTemplateLookUpEdit()
        {
            InitializeComponent();
            DesignControls();

            LoadDataToDropDownList();
        }

        private void frmTemplateLookUpEdit_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
        }

        #region DesignControls
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

        #region cboUserGroup
        public GridView grvCboUserGroup { get; set; }
        public GridColumn colCboGroupID { get; set; }
        public GridColumn colCboGroupCode { get; set; }
        public GridColumn colCboGroupName { get; set; }
        #endregion

        #region cboUnitWeight
        public GridView grvCboUnitWeight { get; set; }
        public GridColumn colCboUnitWeightID { get; set; }
        public GridColumn colCboUnitWeightCode { get; set; }
        public GridColumn colCboUnitWeightDesc { get; set; }
        #endregion

        #region cboUnitSell
        public GridView grvCboUnitSell { get; set; }
        public GridColumn colCboUnitSellID { get; set; }
        public GridColumn colCboUnitSellCode { get; set; }
        public GridColumn colCboUnitSellDesc { get; set; }
        #endregion

        #region cboUnitIn
        public GridView grvCboUnitIn { get; set; }
        public GridColumn colCboUnitInID { get; set; }
        public GridColumn colCboUnitInCode { get; set; }
        public GridColumn colCboUnitInDesc { get; set; }
        #endregion

        #region cboSupplier
        public GridView grvCboSupplier { get; set; }
        public GridColumn colCboSupplierID { get; set; }
        public GridColumn colCboSupplierCode { get; set; }
        public GridColumn colCboSupplierName { get; set; }
        public GridColumn colCboSupplierAddress { get; set; }
        public GridColumn colCboSupplierPhone { get; set; }

        #endregion

        #region cboStalls
        public GridView grvCboStalls { get; set; }
        public GridColumn colCboStallsID { get; set; }
        public GridColumn colCboStallsCode { get; set; }
        public GridColumn colCboStallsName { get; set; }
        #endregion

        #region cboShop
        public GridView grvCboShop { get; set; }
        public GridColumn colCboShopID { get; set; }
        public GridColumn colCboShopCode { get; set; }
        public GridColumn colCboShopName { get; set; }
        public GridColumn colCboShopAddress { get; set; }
        public GridColumn colCboShopTel { get; set; }
        #endregion

        #region cboProductCat
        public GridView grvCboProductCat { get; set; }
        public GridColumn colCboProductCatID { get; set; }
        public GridColumn colCboProductCatCode { get; set; }
        public GridColumn colCboProductCatName { get; set; }
        #endregion

        #region cboProductType
        public GridView grvCboProductType { get; set; }
        public GridColumn colCboProductTypeID { get; set; }
        public GridColumn colCboProductTypeCode { get; set; }
        public GridColumn colCboProductTypeName { get; set; }
        #endregion

        #region cboProductGroup
        public GridView grvCboProductGroup { get; set; }
        public GridColumn colCboProductGroupID { get; set; }
        public GridColumn colCboProductGroupCode { get; set; }
        public GridColumn colCboProductGroupName { get; set; }
        #endregion

        #region cboCustomerType
        public GridView grvCboCustType { get; set; }
        public GridColumn colCboCustTypeID { get; set; }
        public GridColumn colCboCustTypeCode { get; set; }
        public GridColumn colCboCustTypeName { get; set; }
        #endregion

        #region cboCustomerGroup
        public GridView grvCboCustGroup { get; set; }
        public GridColumn colCboCustGroupID { get; set; }
        public GridColumn colCboCustGroupCode { get; set; }
        public GridColumn colCboCustGroupName { get; set; }
        #endregion

        #region cboCounter
        public GridView grvCboCounter { get; set; }
        public GridColumn colCboCounterID { get; set; }
        public GridColumn colCboCounterCode { get; set; }
        public GridColumn colCboCounterName { get; set; }
        public GridColumn colCboCounterShopName { get; set; }
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

        #region cboCurrency
        public GridView grvCboCurrency { get; set; }
        public GridColumn colCboCurrencyID { get; set; }
        public GridColumn colCboCurrencyCode { get; set; }
        public GridColumn colCboCurrencyDesc { get; set; }
        #endregion
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Test LookUpEdit";
            this.Load += new System.EventHandler(this.frmTemplateLookUpEdit_Load);
            #endregion

            DesignGridLookUpEdit();
        }

        private void DesignGridLookUpEdit()
        {
            #region cboCustomer
            //
            // colCboCustID
            //
            this.colCboCustID = new GridColumn();
            this.colCboCustID.Caption = "ID KH";
            this.colCboCustID.FieldName = "CustID";
            this.colCboCustID.Name = "colCboCustID";
            this.colCboCustID.Visible = false;
            //this.colCboCustID.VisibleIndex = -1;
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
                this.colCboCustID,
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
            this.grvCboCustomer.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCustomer.Appearance.Row.Options.UseFont = true;
            this.grvCboCustomer.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCustomer.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboCustomer.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboCustomer.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboCustomer.Appearance.HeaderPanel.Options.UseTextOptions = true;
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
            this.cboCustomer.Properties.PopupFormSize = new System.Drawing.Size(800, 0);
            this.cboCustomer.Properties.View = this.grvCboCustomer;
            this.cboCustomer.EditValueChanged += new System.EventHandler(this.cboCustomer_EditValueChanged);
            #endregion

            #region cboUserGroup
            //
            // colCboGroupID
            //
            this.colCboGroupID = new GridColumn();
            this.colCboGroupID.Caption = "ID nhóm";
            this.colCboGroupID.FieldName = "GroupID";
            this.colCboGroupID.Name = "colCboGroupID";
            this.colCboGroupID.Visible = false;
            //this.colCboGroupID.VisibleIndex = -1;
            //
            // colCboGroupCode
            //
            this.colCboGroupCode = new GridColumn();
            this.colCboGroupCode.Caption = "Mã nhóm";
            this.colCboGroupCode.FieldName = "GroupCode";
            this.colCboGroupCode.Name = "colCboGroupCode";
            this.colCboGroupCode.Visible = true;
            this.colCboGroupCode.VisibleIndex = 0;
            //
            // colCboGroupName
            //
            this.colCboGroupName = new GridColumn();
            this.colCboGroupName.Caption = "Tên nhóm";
            this.colCboGroupName.FieldName = "GroupName";
            this.colCboGroupName.Name = "colCboGroupName";
            this.colCboGroupName.Visible = true;
            this.colCboGroupName.VisibleIndex = 1;
            // 
            // grvCboUserGroup
            // 
            this.grvCboUserGroup = new GridView();
            this.grvCboUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboGroupID,
                this.colCboGroupCode,
                this.colCboGroupName});
            this.grvCboUserGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUserGroup.Name = "grvCboUserGroup";
            this.grvCboUserGroup.OptionsBehavior.Editable = false;
            this.grvCboUserGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUserGroup.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUserGroup.OptionsView.ShowGroupPanel = false;
            this.grvCboUserGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUserGroup.Appearance.Row.Options.UseFont = true;
            this.grvCboUserGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUserGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUserGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUserGroup.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUserGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUserGroup
            // 
            this.cboUserGroup.Name = "cboUserGroup";
            this.cboUserGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.Appearance.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUserGroup.Properties.NullText = "";
            this.cboUserGroup.Properties.ShowFooter = false;
            this.cboUserGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUserGroup.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUserGroup.Properties.View = this.grvCboUserGroup;
            this.cboUserGroup.EditValueChanged += new System.EventHandler(this.cboUserGroup_EditValueChanged);
            #endregion

            #region cboUnitWeight
            //
            // colCboUnitWeightID
            //
            this.colCboUnitWeightID = new GridColumn();
            this.colCboUnitWeightID.Caption = "ID đơn vị";
            this.colCboUnitWeightID.FieldName = "UnitWeightID";
            this.colCboUnitWeightID.Name = "colCboUnitWeightID";
            this.colCboUnitWeightID.Visible = false;
            //this.colCboUnitWeightID.VisibleIndex = -1;
            //
            // colCboUnitWeightCode
            //
            this.colCboUnitWeightCode = new GridColumn();
            this.colCboUnitWeightCode.Caption = "Mã đơn vị";
            this.colCboUnitWeightCode.FieldName = "UnitWeightCode";
            this.colCboUnitWeightCode.Name = "colCboUnitWeightCode";
            this.colCboUnitWeightCode.Visible = true;
            this.colCboUnitWeightCode.VisibleIndex = 0;
            //
            // colCboUnitWeightDesc
            //
            this.colCboUnitWeightDesc = new GridColumn();
            this.colCboUnitWeightDesc.Caption = "Tên đơn vị";
            this.colCboUnitWeightDesc.FieldName = "UnitWeightDesc";
            this.colCboUnitWeightDesc.Name = "colCboUnitWeightDesc";
            this.colCboUnitWeightDesc.Visible = true;
            this.colCboUnitWeightDesc.VisibleIndex = 1;
            // 
            // grvCboUnitWeight
            // 
            this.grvCboUnitWeight = new GridView();
            this.grvCboUnitWeight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboUnitWeightID,
                this.colCboUnitWeightCode,
                this.colCboUnitWeightDesc});
            this.grvCboUnitWeight.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUnitWeight.Name = "grvCboUnitWeight";
            this.grvCboUnitWeight.OptionsBehavior.Editable = false;
            this.grvCboUnitWeight.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUnitWeight.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUnitWeight.OptionsView.ShowGroupPanel = false;
            this.grvCboUnitWeight.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitWeight.Appearance.Row.Options.UseFont = true;
            this.grvCboUnitWeight.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitWeight.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUnitWeight.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUnitWeight.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUnitWeight.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUnitWeight
            // 
            this.cboUnitWeight.Name = "cboUnitWeight";
            this.cboUnitWeight.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.Appearance.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUnitWeight.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitWeight.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUnitWeight.Properties.NullText = "";
            this.cboUnitWeight.Properties.ShowFooter = false;
            this.cboUnitWeight.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUnitWeight.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUnitWeight.Properties.View = this.grvCboUnitWeight;
            this.cboUnitWeight.EditValueChanged += new System.EventHandler(this.cboUnitWeight_EditValueChanged);
            #endregion

            #region cboUnitSell
            //
            // colCboUnitSellID
            //
            this.colCboUnitSellID = new GridColumn();
            this.colCboUnitSellID.Caption = "ID đơn vị";
            this.colCboUnitSellID.FieldName = "UnitSellID";
            this.colCboUnitSellID.Name = "colCboUnitSellID";
            this.colCboUnitSellID.Visible = false;
            //this.colCboUnitSellID.VisibleIndex = -1;
            //
            // colCboUnitSellCode
            //
            this.colCboUnitSellCode = new GridColumn();
            this.colCboUnitSellCode.Caption = "Mã đơn vị";
            this.colCboUnitSellCode.FieldName = "UnitSellCode";
            this.colCboUnitSellCode.Name = "colCboUnitSellCode";
            this.colCboUnitSellCode.Visible = true;
            this.colCboUnitSellCode.VisibleIndex = 0;
            //
            // colCboUnitSellDesc
            //
            this.colCboUnitSellDesc = new GridColumn();
            this.colCboUnitSellDesc.Caption = "Tên đơn vị";
            this.colCboUnitSellDesc.FieldName = "UnitSellDesc";
            this.colCboUnitSellDesc.Name = "colCboUnitSellDesc";
            this.colCboUnitSellDesc.Visible = true;
            this.colCboUnitSellDesc.VisibleIndex = 1;
            // 
            // grvCboUnitSell
            // 
            this.grvCboUnitSell = new GridView();
            this.grvCboUnitSell.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboUnitSellID,
                this.colCboUnitSellCode,
                this.colCboUnitSellDesc});
            this.grvCboUnitSell.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUnitSell.Name = "grvCboUnitSell";
            this.grvCboUnitSell.OptionsBehavior.Editable = false;
            this.grvCboUnitSell.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUnitSell.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUnitSell.OptionsView.ShowGroupPanel = false;
            this.grvCboUnitSell.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitSell.Appearance.Row.Options.UseFont = true;
            this.grvCboUnitSell.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitSell.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUnitSell.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUnitSell.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUnitSell.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUnitSell
            // 
            this.cboUnitSell.Name = "cboUnitSell";
            this.cboUnitSell.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.Appearance.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUnitSell.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitSell.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUnitSell.Properties.NullText = "";
            this.cboUnitSell.Properties.ShowFooter = false;
            this.cboUnitSell.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUnitSell.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUnitSell.Properties.View = this.grvCboUnitSell;
            this.cboUnitSell.EditValueChanged += new System.EventHandler(this.cboUnitSell_EditValueChanged);
            #endregion

            #region cboUnitIn
            //
            // colCboUnitInID
            //
            this.colCboUnitInID = new GridColumn();
            this.colCboUnitInID.Caption = "ID đơn vị";
            this.colCboUnitInID.FieldName = "UnitInID";
            this.colCboUnitInID.Name = "colCboUnitInID";
            this.colCboUnitInID.Visible = false;
            //this.colCboUnitInID.VisibleIndex = -1;
            //
            // colCboUnitInCode
            //
            this.colCboUnitInCode = new GridColumn();
            this.colCboUnitInCode.Caption = "Mã đơn vị";
            this.colCboUnitInCode.FieldName = "UnitInCode";
            this.colCboUnitInCode.Name = "colCboUnitInCode";
            this.colCboUnitInCode.Visible = true;
            this.colCboUnitInCode.VisibleIndex = 0;
            //
            // colCboUnitInDesc
            //
            this.colCboUnitInDesc = new GridColumn();
            this.colCboUnitInDesc.Caption = "Tên đơn vị";
            this.colCboUnitInDesc.FieldName = "UnitInDesc";
            this.colCboUnitInDesc.Name = "colCboUnitInDesc";
            this.colCboUnitInDesc.Visible = true;
            this.colCboUnitInDesc.VisibleIndex = 1;
            // 
            // grvCboUnitIn
            // 
            this.grvCboUnitIn = new GridView();
            this.grvCboUnitIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboUnitInID,
                this.colCboUnitInCode,
                this.colCboUnitInDesc});
            this.grvCboUnitIn.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUnitIn.Name = "grvCboUnitIn";
            this.grvCboUnitIn.OptionsBehavior.Editable = false;
            this.grvCboUnitIn.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUnitIn.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUnitIn.OptionsView.ShowGroupPanel = false;
            this.grvCboUnitIn.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitIn.Appearance.Row.Options.UseFont = true;
            this.grvCboUnitIn.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUnitIn.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUnitIn.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUnitIn.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUnitIn.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUnitIn
            // 
            this.cboUnitIn.Name = "cboUnitIn";
            this.cboUnitIn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.Appearance.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUnitIn.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUnitIn.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUnitIn.Properties.NullText = "";
            this.cboUnitIn.Properties.ShowFooter = false;
            this.cboUnitIn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUnitIn.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUnitIn.Properties.View = this.grvCboUnitIn;
            this.cboUnitIn.EditValueChanged += new System.EventHandler(this.cboUnitIn_EditValueChanged);
            #endregion

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
            this.cboSupplier.EditValueChanged += new System.EventHandler(this.cboSupplier_EditValueChanged);
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
            this.cboStalls.EditValueChanged += new System.EventHandler(this.cboStalls_EditValueChanged);
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
            this.cboShop.EditValueChanged += new System.EventHandler(this.cboShop_EditValueChanged);
            #endregion

            #region cboProductCat
            //
            // colCboProductCatID
            //
            this.colCboProductCatID = new GridColumn();
            this.colCboProductCatID.Caption = "ID nhóm hàng";
            this.colCboProductCatID.FieldName = "ProductCatID";
            this.colCboProductCatID.Name = "colCboProductCatID";
            this.colCboProductCatID.Visible = false;
            //this.colCboProductCatID.VisibleIndex = -1;
            //
            // colCboProductCatCode
            //
            this.colCboProductCatCode = new GridColumn();
            this.colCboProductCatCode.Caption = "Mã nhóm hàng";
            this.colCboProductCatCode.FieldName = "ProductCatCode";
            this.colCboProductCatCode.Name = "colCboProductCatCode";
            this.colCboProductCatCode.Visible = true;
            this.colCboProductCatCode.VisibleIndex = 0;
            //
            // colCboProductCatName
            //
            this.colCboProductCatName = new GridColumn();
            this.colCboProductCatName.Caption = "Tên nhóm hàng";
            this.colCboProductCatName.FieldName = "ProductCatName";
            this.colCboProductCatName.Name = "colCboProductCatName";
            this.colCboProductCatName.Visible = true;
            this.colCboProductCatName.VisibleIndex = 1;
            // 
            // grvCboProductCat
            // 
            this.grvCboProductCat = new GridView();
            this.grvCboProductCat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboProductCatID,
                this.colCboProductCatCode,
                this.colCboProductCatName});
            this.grvCboProductCat.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboProductCat.Name = "grvCboProductCat";
            this.grvCboProductCat.OptionsBehavior.Editable = false;
            this.grvCboProductCat.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboProductCat.OptionsView.ShowAutoFilterRow = true;
            this.grvCboProductCat.OptionsView.ShowGroupPanel = false;
            this.grvCboProductCat.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductCat.Appearance.Row.Options.UseFont = true;
            this.grvCboProductCat.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductCat.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboProductCat.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboProductCat.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboProductCat.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboProductCat
            // 
            this.cboProductCat.Name = "cboProductCat";
            this.cboProductCat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductCat.Properties.Appearance.Options.UseFont = true;
            this.cboProductCat.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductCat.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboProductCat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductCat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboProductCat.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductCat.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboProductCat.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductCat.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboProductCat.Properties.NullText = "";
            this.cboProductCat.Properties.ShowFooter = false;
            this.cboProductCat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboProductCat.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboProductCat.Properties.View = this.grvCboProductCat;
            this.cboProductCat.EditValueChanged += new System.EventHandler(this.cboProductCat_EditValueChanged);
            #endregion

            #region cboProductType
            //
            // colCboProductTypeID
            //
            this.colCboProductTypeID = new GridColumn();
            this.colCboProductTypeID.Caption = "ID loại hàng";
            this.colCboProductTypeID.FieldName = "ProductTypeID";
            this.colCboProductTypeID.Name = "colCboProductTypeID";
            this.colCboProductTypeID.Visible = false;
            //this.colCboProductTypeID.VisibleIndex = -1;
            //
            // colCboProductTypeCode
            //
            this.colCboProductTypeCode = new GridColumn();
            this.colCboProductTypeCode.Caption = "Mã loại hàng";
            this.colCboProductTypeCode.FieldName = "ProductTypeCode";
            this.colCboProductTypeCode.Name = "colCboProductTypeCode";
            this.colCboProductTypeCode.Visible = true;
            this.colCboProductTypeCode.VisibleIndex = 0;
            //
            // colCboProductTypeName
            //
            this.colCboProductTypeName = new GridColumn();
            this.colCboProductTypeName.Caption = "Tên loại hàng";
            this.colCboProductTypeName.FieldName = "ProductTypeName";
            this.colCboProductTypeName.Name = "colCboProductTypeName";
            this.colCboProductTypeName.Visible = true;
            this.colCboProductTypeName.VisibleIndex = 1;
            // 
            // grvCboProductType
            // 
            this.grvCboProductType = new GridView();
            this.grvCboProductType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboProductTypeID,
                this.colCboProductTypeCode,
                this.colCboProductTypeName});
            this.grvCboProductType.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboProductType.Name = "grvCboProductType";
            this.grvCboProductType.OptionsBehavior.Editable = false;
            this.grvCboProductType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboProductType.OptionsView.ShowAutoFilterRow = true;
            this.grvCboProductType.OptionsView.ShowGroupPanel = false;
            this.grvCboProductType.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductType.Appearance.Row.Options.UseFont = true;
            this.grvCboProductType.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductType.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboProductType.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboProductType.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboProductType.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboProductType
            // 
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.Appearance.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboProductType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboProductType.Properties.NullText = "";
            this.cboProductType.Properties.ShowFooter = false;
            this.cboProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboProductType.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboProductType.Properties.View = this.grvCboProductType;
            this.cboProductType.EditValueChanged += new System.EventHandler(this.cboProductType_EditValueChanged);
            #endregion

            #region cboProductGroup
            //
            // colCboProductGroupID
            //
            this.colCboProductGroupID = new GridColumn();
            this.colCboProductGroupID.Caption = "ID nhóm hàng";
            this.colCboProductGroupID.FieldName = "ProductGroupID";
            this.colCboProductGroupID.Name = "colCboProductGroupID";
            this.colCboProductGroupID.Visible = false;
            //this.colCboProductGroupID.VisibleIndex = -1;
            //
            // colCboProductGroupCode
            //
            this.colCboProductGroupCode = new GridColumn();
            this.colCboProductGroupCode.Caption = "Mã nhóm hàng";
            this.colCboProductGroupCode.FieldName = "ProductGroupCode";
            this.colCboProductGroupCode.Name = "colCboProductGroupCode";
            this.colCboProductGroupCode.Visible = true;
            this.colCboProductGroupCode.VisibleIndex = 0;
            //
            // colCboProductGroupName
            //
            this.colCboProductGroupName = new GridColumn();
            this.colCboProductGroupName.Caption = "Tên nhóm hàng";
            this.colCboProductGroupName.FieldName = "ProductGroupName";
            this.colCboProductGroupName.Name = "colCboProductGroupName";
            this.colCboProductGroupName.Visible = true;
            this.colCboProductGroupName.VisibleIndex = 1;
            // 
            // grvCboProductGroup
            // 
            this.grvCboProductGroup = new GridView();
            this.grvCboProductGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboProductGroupID,
                this.colCboProductGroupCode,
                this.colCboProductGroupName});
            this.grvCboProductGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboProductGroup.Name = "grvCboProductGroup";
            this.grvCboProductGroup.OptionsBehavior.Editable = false;
            this.grvCboProductGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboProductGroup.OptionsView.ShowAutoFilterRow = true;
            this.grvCboProductGroup.OptionsView.ShowGroupPanel = false;
            this.grvCboProductGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductGroup.Appearance.Row.Options.UseFont = true;
            this.grvCboProductGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboProductGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboProductGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboProductGroup.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboProductGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboProductGroup
            // 
            this.cboProductGroup.Name = "cboProductGroup";
            this.cboProductGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.Appearance.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboProductGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboProductGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboProductGroup.Properties.NullText = "";
            this.cboProductGroup.Properties.ShowFooter = false;
            this.cboProductGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboProductGroup.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboProductGroup.Properties.View = this.grvCboProductGroup;
            this.cboProductGroup.EditValueChanged += new System.EventHandler(this.cboProductGroup_EditValueChanged);
            #endregion

            #region cboCustomerType
            //
            // colCboCustTypeID
            //
            this.colCboCustTypeID = new GridColumn();
            this.colCboCustTypeID.Caption = "ID loại khách hàng";
            this.colCboCustTypeID.FieldName = "CustTypeID";
            this.colCboCustTypeID.Name = "colCboCustTypeID";
            this.colCboCustTypeID.Visible = false;
            //this.colCboCustTypeID.VisibleIndex = -1;
            //
            // colCboCustTypeCode
            //
            this.colCboCustTypeCode = new GridColumn();
            this.colCboCustTypeCode.Caption = "Mã loại khách hàng";
            this.colCboCustTypeCode.FieldName = "CustTypeCode";
            this.colCboCustTypeCode.Name = "colCboCustTypeCode";
            this.colCboCustTypeCode.Visible = true;
            this.colCboCustTypeCode.VisibleIndex = 0;
            //
            // colCboCustTypeName
            //
            this.colCboCustTypeName = new GridColumn();
            this.colCboCustTypeName.Caption = "Tên loại khách hàng";
            this.colCboCustTypeName.FieldName = "CustTypeName";
            this.colCboCustTypeName.Name = "colCboCustTypeName";
            this.colCboCustTypeName.Visible = true;
            this.colCboCustTypeName.VisibleIndex = 1;
            // 
            // grvCboCustType
            // 
            this.grvCboCustType = new GridView();
            this.grvCboCustType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboCustTypeID,
                this.colCboCustTypeCode,
                this.colCboCustTypeName});
            this.grvCboCustType.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCustType.Name = "grvCboCustType";
            this.grvCboCustType.OptionsBehavior.Editable = false;
            this.grvCboCustType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCustType.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCustType.OptionsView.ShowGroupPanel = false;
            this.grvCboCustType.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCustType.Appearance.Row.Options.UseFont = true;
            this.grvCboCustType.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCustType.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboCustType.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboCustType.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboCustType.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboCustType
            // 
            this.cboCustType.Name = "cboCustType";
            this.cboCustType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustType.Properties.Appearance.Options.UseFont = true;
            this.cboCustType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCustType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCustType.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCustType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCustType.Properties.NullText = "";
            this.cboCustType.Properties.ShowFooter = false;
            this.cboCustType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCustType.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCustType.Properties.View = this.grvCboCustType;
            this.cboCustType.EditValueChanged += new System.EventHandler(this.cboCustType_EditValueChanged);
            #endregion

            #region cboCustomerGroup
            //
            // colCboCustGroupID
            //
            this.colCboCustGroupID = new GridColumn();
            this.colCboCustGroupID.Caption = "ID nhóm khách hàng";
            this.colCboCustGroupID.FieldName = "CustGroupID";
            this.colCboCustGroupID.Name = "colCboCustGroupID";
            this.colCboCustGroupID.Visible = false;
            //this.colCboCustGroupID.VisibleIndex = -1;
            //
            // colCboCustGroupCode
            //
            this.colCboCustGroupCode = new GridColumn();
            this.colCboCustGroupCode.Caption = "Mã nhóm khách hàng";
            this.colCboCustGroupCode.FieldName = "CustGroupCode";
            this.colCboCustGroupCode.Name = "colCboCustGroupCode";
            this.colCboCustGroupCode.Visible = true;
            this.colCboCustGroupCode.VisibleIndex = 0;
            //
            // colCboCustGroupName
            //
            this.colCboCustGroupName = new GridColumn();
            this.colCboCustGroupName.Caption = "Tên nhóm khách hàng";
            this.colCboCustGroupName.FieldName = "CustGroupName";
            this.colCboCustGroupName.Name = "colCboCustGroupName";
            this.colCboCustGroupName.Visible = true;
            this.colCboCustGroupName.VisibleIndex = 1;
            // 
            // grvCboCustGroup
            // 
            this.grvCboCustGroup = new GridView();
            this.grvCboCustGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboCustGroupID,
                this.colCboCustGroupCode,
                this.colCboCustGroupName});
            this.grvCboCustGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCustGroup.Name = "grvCboCustGroup";
            this.grvCboCustGroup.OptionsBehavior.Editable = false;
            this.grvCboCustGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCustGroup.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCustGroup.OptionsView.ShowGroupPanel = false;
            this.grvCboCustGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCustGroup.Appearance.Row.Options.UseFont = true;
            this.grvCboCustGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCustGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboCustGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboCustGroup.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboCustGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboCustGroup
            // 
            this.cboCustGroup.Name = "cboCustGroup";
            this.cboCustGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustGroup.Properties.Appearance.Options.UseFont = true;
            this.cboCustGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCustGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCustGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCustGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCustGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCustGroup.Properties.NullText = "";
            this.cboCustGroup.Properties.ShowFooter = false;
            this.cboCustGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCustGroup.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCustGroup.Properties.View = this.grvCboCustGroup;
            this.cboCustGroup.EditValueChanged += new System.EventHandler(this.cboCustGroup_EditValueChanged);
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
            this.cboCounter.EditValueChanged += new System.EventHandler(this.cboCounter_EditValueChanged);
            #endregion

            #region cboCurrency
            //
            // colCboCurrencyID
            //
            this.colCboCurrencyID = new GridColumn();
            this.colCboCurrencyID.Caption = "ID Tiền tệ";
            this.colCboCurrencyID.FieldName = "CurrencyID";
            this.colCboCurrencyID.Name = "colCboCurrencyID";
            this.colCboCurrencyID.Visible = false;
            //this.colCboCurrencyID.VisibleIndex = -1;
            //
            // colCboCurrencyCode
            //
            this.colCboCurrencyCode = new GridColumn();
            this.colCboCurrencyCode.Caption = "Mã tiền tệ";
            this.colCboCurrencyCode.FieldName = "CurrencyCode";
            this.colCboCurrencyCode.Name = "colCboCurrencyCode";
            this.colCboCurrencyCode.Visible = true;
            this.colCboCurrencyCode.VisibleIndex = 0;
            //
            // colCboCurrencyDesc
            //
            this.colCboCurrencyDesc = new GridColumn();
            this.colCboCurrencyDesc.Caption = "Tên tiền tệ";
            this.colCboCurrencyDesc.FieldName = "CurrencyDesc";
            this.colCboCurrencyDesc.Name = "colCboCurrencyDesc";
            this.colCboCurrencyDesc.Visible = true;
            this.colCboCurrencyDesc.VisibleIndex = 1;
            // 
            // grvCboCurrency
            // 
            this.grvCboCurrency = new GridView();
            this.grvCboCurrency.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboCurrencyID,
                this.colCboCurrencyCode,
                this.colCboCurrencyDesc});
            this.grvCboCurrency.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboCurrency.Name = "grvCboCurrency";
            this.grvCboCurrency.OptionsBehavior.Editable = false;
            this.grvCboCurrency.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboCurrency.OptionsView.ShowAutoFilterRow = true;
            this.grvCboCurrency.OptionsView.ShowGroupPanel = false;
            this.grvCboCurrency.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCurrency.Appearance.Row.Options.UseFont = true;
            this.grvCboCurrency.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboCurrency.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboCurrency.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboCurrency.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboCurrency.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboCurrency
            // 
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCurrency.Properties.Appearance.Options.UseFont = true;
            this.cboCurrency.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCurrency.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCurrency.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCurrency.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCurrency.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCurrency.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCurrency.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboCurrency.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCurrency.Properties.NullText = "";
            this.cboCurrency.Properties.ShowFooter = false;
            this.cboCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboCurrency.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCurrency.Properties.View = this.grvCboCurrency;
            //this.cboCurrency.EditValueChanged += new System.EventHandler(this.cboCurrency_EditValueChanged);
            #endregion

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
            this.cboStatus.ReadOnly = true;
            this.cboStatus.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.cboStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Bold);
            this.cboStatus.Properties.Appearance.Options.UseFont = true;
            this.cboStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboStatus.Properties.Appearance.Options.UseForeColor = true;
            this.cboStatus.TabStop = false;
            #endregion      
        }
        #endregion

        #region Function
        /// <summary>
        /// Load dữ liêu lên DropDownList
        /// </summary>
        private void LoadDataToDropDownList()
        {
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatUnitIn.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboUnitIn.Properties.DataSource = ds.Tables[0].Copy();
                    cboUnitIn.Properties.DisplayMember = "UnitInDesc";
                    cboUnitIn.Properties.ValueMember = "UnitInID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatUnitSell.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboUnitSell.Properties.DataSource = ds.Tables[0].Copy();
                    cboUnitSell.Properties.DisplayMember = "UnitSellDesc";
                    cboUnitSell.Properties.ValueMember = "UnitSellID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatUnitWeight.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboUnitWeight.Properties.DataSource = ds.Tables[0].Copy();
                    cboUnitWeight.Properties.DisplayMember = "UnitWeightDesc";
                    cboUnitWeight.Properties.ValueMember = "UnitWeightID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
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
                ds = BLLCatCustomerGroup.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboCustGroup.Properties.DataSource = ds.Tables[0].Copy();
                    cboCustGroup.Properties.DisplayMember = "CustGroupName";
                    cboCustGroup.Properties.ValueMember = "CustGroupID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatCustomerType.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboCustType.Properties.DataSource = ds.Tables[0].Copy();
                    cboCustType.Properties.DisplayMember = "CustTypeName";
                    cboCustType.Properties.ValueMember = "CustTypeID";
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
                ds = BLLCatProductGroup.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboProductGroup.Properties.DataSource = ds.Tables[0].Copy();
                    cboProductGroup.Properties.DisplayMember = "ProductGroupName";
                    cboProductGroup.Properties.ValueMember = "ProductGroupID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatProductType.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboProductType.Properties.DataSource = ds.Tables[0].Copy();
                    cboProductType.Properties.DisplayMember = "ProductTypeName";
                    cboProductType.Properties.ValueMember = "ProductTypeID";
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
                ds = BLLSysStatus.LoadDataCombobox("STATUS_CAT_COUNTER", out sMessages);
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
                ds = BLLCatProduct.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboProductCat.Properties.DataSource = ds.Tables[0].Copy();
                    cboProductCat.Properties.DisplayMember = "ProductCatName";
                    cboProductCat.Properties.ValueMember = "ProductCatID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();
                ds = BLLCatCurrency.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboCurrency.Properties.DataSource = ds.Tables[0].Copy();
                    cboCurrency.Properties.DisplayMember = "CurrencyDesc";
                    cboCurrency.Properties.ValueMember = "CurrencyID";
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

        #region Combobox
        private void cboCustomer_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboUserGroup_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboUnitWeight_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboUnitSell_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboUnitIn_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboStalls_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboShop_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboProductCat_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboProductType_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboProductGroup_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboEmployee_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboCustType_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboCustGroup_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboCounter_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}