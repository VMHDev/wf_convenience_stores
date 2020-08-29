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
using CRM_BLL.BLLCategories;
using CRM_DTO.DTOCategories;
using CRM_DTO.CRMUtility;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_DTO.DTOSystem;

namespace CRM_GUI.GUICategories
{
    public partial class frmCounterUdp : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private DTOCatCounter ObjCounter = null;
        private long OrderBy = -1;
        public bool ResultHandler = false;
        #endregion

        #region Form
        public frmCounterUdp()
        {
            InitializeComponent();
        }

        public frmCounterUdp(long _OrderBy)
        {
            InitializeComponent();
            DesignControls();
            OrderBy = _OrderBy + 1;
            LoadDefault();        
        }

        public frmCounterUdp(DTOCatCounter _obj)
        {
            InitializeComponent();
            DesignControls();
            ObjCounter = _obj;
            LoadDefault();
        }

        private void frmCounterUdp_Load(object sender, EventArgs e)
        {            
            LoadDataToDropDownList();
            if(ObjCounter != null)
            {
                LoadDataToForm();
            }
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboShop
        public GridView grvCboShop { get; set; }
        public GridColumn colCboShopCode { get; set; }
        public GridColumn colCboShopName { get; set; }
        public GridColumn colCboShopAddress { get; set; }
        public GridColumn colCboShopTel { get; set; }
        #endregion
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Quầy thu ngân";
            this.Load += new System.EventHandler(this.frmCounterUdp_Load);
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
            #region cboShop
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
                ds = BLLCatShop.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboShop.Properties.DataSource = ds.Tables[0].Copy();
                    cboShop.Properties.DisplayMember = "ShopName";
                    cboShop.Properties.ValueMember = "ID";
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
            txtCounterCode.EditValue = ObjCounter.CounterCode;
            txtCounterName.EditValue = ObjCounter.CounterName;
            txtOrderBy.EditValue = ObjCounter.OrderBy;
            cboShop.EditValue = ObjCounter.Shop;
            chkActive.Checked = ObjCounter.IsActive;
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
                string sCounterCode = txtCounterCode.Text.Trim();
                string sCounterName = txtCounterName.Text.Trim();
                long lOrderBy = Convert.ToInt64(txtOrderBy.EditValue);
                bool bIsActive = chkActive.Checked;
                DTOCatShop objShop = new DTOCatShop();
                objShop.ID = cboShop.EditValue == null ? -1 : Convert.ToInt64(cboShop.EditValue);
                DTOCatCounter objCounter = new DTOCatCounter(_ID, sCounterCode, sCounterName, "C", objShop, lOrderBy, bIsActive, DateTime.Now, DTOAttributeSystem.CurrentUser.ID, false);
                bResult = BLLCatCounter.CatCounter_InsUpd(objCounter, out _Message);
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
            long lID = ObjCounter == null ? -1 : ObjCounter.ID;
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

        #region Combobox
        private void cboShop_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}