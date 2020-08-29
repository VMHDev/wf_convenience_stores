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
using CRM_DTO.DTOCounter;
using CRM_GUI.CRMUtility.Messages;
using CRM_DTO.CRMUtility;
using CRM_BLL.BLLCategories;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUICounter
{
    public partial class frmCounterInOutDtl : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private DTOTrnCounterInOutDT ObjTrnCounterInOutDT = null;
        private frmCounterInOut FrmCounterInOut = null;
        #endregion

        #region Form
        public frmCounterInOutDtl()
        {
            InitializeComponent();
            DesignControls();
            ObjTrnCounterInOutDT = null;
            FrmCounterInOut = null;
        }

        public frmCounterInOutDtl(frmCounterInOut _Frm)
        {
            InitializeComponent();
            DesignControls();
            FrmCounterInOut = _Frm;
            ObjTrnCounterInOutDT = null;            
        }

        public frmCounterInOutDtl(frmCounterInOut _Frm, DTOTrnCounterInOutDT _TrnCounterInOutDT)
        {
            InitializeComponent();
            DesignControls();
            FrmCounterInOut = _Frm;
            ObjTrnCounterInOutDT = new DTOTrnCounterInOutDT(_TrnCounterInOutDT);
        }

        private void frmCounterInOutDtl_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
        }
        #endregion

        #region Design
        #region Declare Controls
        #region cboCurrency
        public GridView grvCboCurrency { get; set; }
        public GridColumn colCboCurrencyID { get; set; }
        public GridColumn colCboCurrencyCode { get; set; }
        public GridColumn colCboCurrencyDesc { get; set; }
        #endregion

        #region cboTrnType
        public GridView grvCboTrnType { get; set; }
        public GridColumn colCboTrnTypeID { get; set; }
        public GridColumn colCboTrnTypeName { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design giao diện
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Thông tin thu chi tại quầy";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmCounterInOutDtl_Load);
            #endregion

            DesignTextSpinEdit();
            DesignGridLookUpEdit();
        }

        /// <summary>
        /// Design TextSpinEdit
        /// </summary>
        private void DesignTextSpinEdit()
        {
            txtAmount.Properties.DisplayFormat.FormatString = "#,##0";
            txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtAmount.Properties.EditFormat.FormatString = "#,##0";
            txtAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;            
            txtAmount.Properties.Mask.EditMask = "n0";
            txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
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
            this.cboCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCurrency.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboCurrency.Properties.View = this.grvCboCurrency;
            //this.cboCurrency.EditValueChanged += new System.EventHandler(this.cboCurrency_EditValueChanged);
            #endregion

            #region cboTrnType
            //
            // colCboTrnTypeID
            //
            this.colCboTrnTypeID = new GridColumn();
            this.colCboTrnTypeID.Caption = "ID Loại giao dịch";
            this.colCboTrnTypeID.FieldName = "TrnTypeID";
            this.colCboTrnTypeID.Name = "colCboTrnTypeID";
            this.colCboTrnTypeID.Visible = false;
            //this.colCboTrnTypeCode.VisibleIndex = -1;
            //
            // colCboTrnTypeName
            //
            this.colCboTrnTypeName = new GridColumn();
            this.colCboTrnTypeName.Caption = "Loại giao dịch";
            this.colCboTrnTypeName.FieldName = "TrnTypeName";
            this.colCboTrnTypeName.Name = "colCboTrnTypeName";
            this.colCboTrnTypeName.Visible = true;
            this.colCboTrnTypeName.VisibleIndex = 0;

            // 
            // grvCboTrnType
            // 
            this.grvCboTrnType = new GridView();
            this.grvCboTrnType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboTrnTypeID,
            this.colCboTrnTypeName});
            this.grvCboTrnType.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboTrnType.Name = "grvCboTrnType";
            this.grvCboTrnType.OptionsBehavior.Editable = false;
            this.grvCboTrnType.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboTrnType.OptionsView.ShowAutoFilterRow = false;
            this.grvCboTrnType.OptionsView.ShowGroupPanel = false;
            this.grvCboTrnType.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboTrnType.Appearance.Row.Options.UseFont = true;
            this.grvCboTrnType.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboTrnType.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboTrnType.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboTrnType.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboTrnType.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboTrnType
            // 
            this.cboTrnType.Name = "cboTrnType";
            this.cboTrnType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTrnType.Properties.Appearance.Options.UseFont = true;
            this.cboTrnType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTrnType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboTrnType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTrnType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboTrnType.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTrnType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboTrnType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboTrnType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboTrnType.Properties.NullText = "";
            this.cboTrnType.Properties.ShowFooter = false;
            this.cboTrnType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTrnType.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboTrnType.Properties.View = this.grvCboTrnType;
            //this.cboTrnType.EditValueChanged += new System.EventHandler(this.cboTrnType_EditValueChanged);   
            this.cboTrnType.Properties.View.OptionsView.ShowColumnHeaders = false;
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
            DataTable dt = new DataTable();
            string sMessages;
            try
            {
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

                dt.Columns.Add("TrnTypeID", typeof(bool));
                dt.Columns.Add("TrnTypeName", typeof(string));
                dt.Rows.Add(true, "Thu");
                dt.Rows.Add(false, "Chi");
                cboTrnType.Properties.DataSource = dt.Copy();
                cboTrnType.Properties.DisplayMember = "TrnTypeName";
                cboTrnType.Properties.ValueMember = "TrnTypeID";
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
                dt.Dispose();
            }
        }

        /// <summary>
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadDefault()
        {
            try
            {
                txtAmount.EditValue = ObjTrnCounterInOutDT != null ? ObjTrnCounterInOutDT.Amount : 0;
                txtNotes.EditValue = ObjTrnCounterInOutDT != null ? ObjTrnCounterInOutDT.Notes : string.Empty;
                cboCurrency.EditValue = ObjTrnCounterInOutDT != null ? ObjTrnCounterInOutDT.Currency : cboCurrency.Properties.GetKeyValue(0);
                cboTrnType.EditValue = ObjTrnCounterInOutDT != null ? ObjTrnCounterInOutDT.TrnTypeID : cboTrnType.Properties.GetKeyValue(0);
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
                DataTable dtTrnType = cboTrnType.Properties.DataSource as DataTable;
                bool bTrnTypeID = cboTrnType.EditValue == null ? true : Convert.ToBoolean(cboTrnType.EditValue);
                DataTable dtCurrency = cboCurrency.Properties.DataSource as DataTable;
                long lCurrencyID = cboCurrency.EditValue == null ? -1 : Convert.ToInt64(cboCurrency.EditValue);

                DTOTrnCounterInOutDT objectTrnCounterInOutDT = new DTOTrnCounterInOutDT();
                objectTrnCounterInOutDT.TrnID = -1;
                objectTrnCounterInOutDT.Amount = txtAmount.EditValue == null ? 0M : Convert.ToDecimal(txtAmount.EditValue);
                objectTrnCounterInOutDT.Notes = txtNotes.Text;
                objectTrnCounterInOutDT.TrnTypeID = bTrnTypeID;
                objectTrnCounterInOutDT.TrnTypeName = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtTrnType, "TrnTypeID", bTrnTypeID, "TrnTypeName"));
                DTOCatCurrency objCurrency = new DTOCatCurrency();
                objCurrency.ID = lCurrencyID;
                objCurrency.CurrencyCode = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtCurrency, "CurrencyID", lCurrencyID, "CurrencyCode"));
                objCurrency.CurrencyDesc = Convert.ToString(FuncDropDownList.GetItemGridLookUp(dtCurrency, "CurrencyID", lCurrencyID, "CurrencyDesc"));
                objectTrnCounterInOutDT.Currency = objCurrency;

                bResult = FrmCounterInOut.AddItemDataSourceGrid(objectTrnCounterInOutDT);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}