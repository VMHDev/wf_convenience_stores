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
using CRM_DTO.DTOCategories;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_GUI.CRMUtility.Messages;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOSystem;
using CRM_BLL.BLLCategories;

namespace CRM_GUI.GUICategories
{
    public partial class frmCustomerUdp : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private DTOCatCustomer ObjCustomer = null;
        private long OrderBy = -1;
        public bool ResultHandler = false;
        #endregion

        #region Form
        public frmCustomerUdp()
        {
            InitializeComponent();
        }

        public frmCustomerUdp(long _OrderBy)
        {
            InitializeComponent();
            DesignControls();
            OrderBy = _OrderBy + 1;
            LoadDefault();        
        }

        public frmCustomerUdp(DTOCatCustomer _obj)
        {
            InitializeComponent();
            DesignControls();
            ObjCustomer = _obj;
            LoadDefault();
        }

        private void frmCustomerUdp_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            if (ObjCustomer != null)
            {
                LoadDataToForm();
            }
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboCustomerType
        public GridView grvCboCustType { get; set; }
        public GridColumn colCboCustTypeCode { get; set; }
        public GridColumn colCboCustTypeName { get; set; }
        #endregion

        #region cboCustomerGroup
        public GridView grvCboCustGroup { get; set; }
        public GridColumn colCboCustGroupCode { get; set; }
        public GridColumn colCboCustGroupName { get; set; }
        #endregion
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.frmCustomerUdp_Load);
            #endregion
            DesignGridLookUpEdit();
            DesignTextSpinEdit();
        }

        private void DesignTextSpinEdit()
        {
            txtOrderBy.Properties.DisplayFormat.FormatString = "#,##0";
            txtOrderBy.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOrderBy.Properties.EditFormat.FormatString = "#,##0";
            txtOrderBy.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOrderBy.Properties.Mask.EditMask = "n0";
            txtOrderBy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtOrderBy.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void DesignGridLookUpEdit()
        {
            #region cboCustomerType
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
            //this.cboCustType.EditValueChanged += new System.EventHandler(this.cboCustType_EditValueChanged);
            #endregion

            #region cboCustomerGroup
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
            //this.cboCustGroup.EditValueChanged += new System.EventHandler(this.cboCustGroup_EditValueChanged);
            #endregion
        }
        #endregion

        #region Functions
        /// <summary>
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadDefault()
        {
            txtOrderBy.EditValue = OrderBy;
            chkActive.Checked = true;
        }

        /// <summary>
        /// Load dữ liệu DropDownList
        /// </summary>
        private void LoadDataToDropDownList()
        {
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatCustomerGroup.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboCustGroup.Properties.DataSource = ds.Tables[0].Copy();
                    cboCustGroup.Properties.DisplayMember = "CustGroupName";
                    cboCustGroup.Properties.ValueMember = "ID";
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
                    cboCustType.Properties.ValueMember = "ID";
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
        /// Load dữ liệu cho form
        /// </summary>
        private void LoadDataToForm()
        {
            txtCustAddress.EditValue = ObjCustomer.CustAddress;
            txtCustCode.EditValue = ObjCustomer.CustCode;
            txtCustName.EditValue = ObjCustomer.CustName;
            txtEmail.EditValue = ObjCustomer.Email;
            txtIdentificationCard.EditValue = ObjCustomer.IdentificationCard;
            txtNotes.EditValue = ObjCustomer.Notes;
            txtOrderBy.EditValue = ObjCustomer.OrderBy;
            txtPhone.EditValue = ObjCustomer.Phone;
            cboCustGroup.EditValue = ObjCustomer.CustGroup;
            cboCustType.EditValue = ObjCustomer.CustType;
            chkActive.Checked = ObjCustomer.IsActive;
            rdoGrpGender.EditValue = ObjCustomer.Gender;
            dtpBirthDate.EditValue = ObjCustomer.BirthDate;
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        /// <param name="_ID">ID quầy thu ngân</param>
        /// <param name="_Message">Thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SaveClick(long _ID, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                string sCustCode = Convert.ToString(txtCustCode.EditValue);
                string sCustName = Convert.ToString(txtCustName.EditValue);
                string sCustAddress = Convert.ToString(txtCustAddress.EditValue);
                string sPhone = Convert.ToString(txtPhone.EditValue);
                string sNotes = Convert.ToString(txtNotes.EditValue);
                string sIdentificationCard = Convert.ToString(txtIdentificationCard.EditValue);
                DateTime dtmBirthDate = Convert.ToDateTime(dtpBirthDate.EditValue);
                bool bGender = Convert.ToBoolean(rdoGrpGender.EditValue);
                string sEmail = Convert.ToString(txtEmail.EditValue);
                long lOrderBy = Convert.ToInt64(txtOrderBy.EditValue);
                bool bIsActive = chkActive.Checked;
                DateTime dtmUpdateDate = DateTime.Now;
                long lUpdateBy = DTOAttributeSystem.CurrentUser.ID;
                bool bIsDelete = false;

                DTOCatCustomerGroup objCustGroup = new DTOCatCustomerGroup();
                objCustGroup.ID = cboCustGroup.EditValue == null ? -1 : Convert.ToInt64(cboCustGroup.EditValue);
                DTOCatCustomerType objCustType = new DTOCatCustomerType();
                objCustType.ID = cboCustType.EditValue == null ? -1 : Convert.ToInt64(cboCustType.EditValue);
                
                DTOCatCustomer objCustomer = new DTOCatCustomer(_ID, sCustCode, sCustName,
                                                                sCustAddress, sPhone, sNotes,
                                                                sIdentificationCard, dtmBirthDate, bGender,
                                                                sEmail, objCustGroup, objCustType,
                                                                lOrderBy, bIsActive, dtmUpdateDate,
                                                                lUpdateBy, bIsDelete);
                bResult = BLLCatCustomer.CatCustomer_InsUpd(objCustomer, out _Message);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            long lID = ObjCustomer == null ? -1 : ObjCustomer.ID;
            if (SaveClick(lID, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
                ResultHandler = true;
                this.Close();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}