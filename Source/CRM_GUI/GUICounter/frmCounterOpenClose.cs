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
using CRM_GUI.CRMUtility.Messages;
using CRM_BLL.BLLCategories;
using CRM_GUI.GUIQuery;
using CRM_BLL.BLLCounter;
using CRM_BLL.BLLSystem;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCounter;
using CRM_DTO.DTOSystem;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUICounter
{
    public partial class frmCounterOpenClose : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmCounterOpenClose()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmCounterOpenClose_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
        }
        #endregion

        #region DesignControls
        #region Declare Controls
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
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Đóng/Mở quầy thu ngân";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmCounterOpenClose_Load);
            #endregion

            DesignGridLookUpEdit();

            cboCounter.TabStop = false;
            cboEmployee.TabStop = false;
            cboStatus.TabStop = false;
            btnOpenClose.TabIndex = 0;
            btnQueryInStockCounter.TabIndex = 1;
            btnClose.TabIndex = 2;
        }

        private void DesignGridLookUpEdit()
        {
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
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadDefault()
        {
            cboEmployee.EditValue = DTOAttributeSystem.CurrentEmployee.ID;
            if (DTOAttributeSystem.CurrentCounter.ID.Equals(-1))
            {
                cboCounter.EditValue = null;
                cboStatus.EditValue = null;
            }
            else 
            {
                cboCounter.EditValue = DTOAttributeSystem.CurrentCounter.ID;
            }
        }

        /// <summary>
        /// Load dữ liệu cho form
        /// </summary>
        private void LoadDataToForm()
        {
            long lCounterID = cboCounter.EditValue == null ? -1 : Convert.ToInt64(cboCounter.EditValue);
            if (lCounterID < 0)
            {
                return;
            }
            DTOCatCounterLog obj = GetCounterLog(lCounterID);
            if (obj == null)
            {
                cboStatus.EditValue = "C";
                cboEmployee.EditValue = null;
            }
            else
            {
                cboStatus.EditValue = obj.StatusCode;
                cboEmployee.EditValue = obj.Employee;
            }
            EnabledControls(cboStatus.EditValue.ToString());
        }

        /// <summary>
        /// Enable/Disable các control
        /// </summary>
        /// <param name="_StatusCode"></param>
        private void EnabledControls(string _StatusCode)
        {
            if(_StatusCode == "O")
            {
                cboCounter.ReadOnly = true;
            }
            else
            {
                cboCounter.ReadOnly = false;
            }
        }

        /// <summary>
        /// Lấy lịch sử đóng mở quầy
        /// </summary>
        /// <param name="_CounterID"></param>
        /// <returns></returns>
        private DTOCatCounterLog GetCounterLog(long _CounterID)
        {
            DTOCatCounterLog objResult = new DTOCatCounterLog();
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                ds = BLLCounterOpenClose.CatCounterLog_GetWithCounter(_CounterID, out sMessage);
                if (string.IsNullOrWhiteSpace(sMessage))
                {
                    DTOCatCounter objCounter= new DTOCatCounter();
                    objCounter.ID = _CounterID;
                    objResult.Counter = objCounter;
                    DTOCatEmployee objEmployee = new DTOCatEmployee();
                    objEmployee.ID = ds.Tables[0].Rows[0]["EmpID"] == null ? -1 : Convert.ToInt64(ds.Tables[0].Rows[0]["EmpID"]);
                    objResult.Employee = objEmployee;
                    objResult.StatusCode = ds.Tables[0].Rows[0]["StatusCode"] == null ? string.Empty : Convert.ToString(ds.Tables[0].Rows[0]["StatusCode"]);
                }
                else
                {
                    objResult = null;
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return objResult;
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
        /// Đóng/Mở quầy thu ngân
        /// </summary>
        /// <param name="_Types">Trả về tình trạng</param>
        /// <param name="_Message">Trả về thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool OpenCloseClick(out bool _Types, out string _Message)
        {
            _Message = string.Empty;
            _Types = false;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                long lCounterID = cboCounter.EditValue == null ? -1 : Convert.ToInt64(cboCounter.EditValue);
                long lEmpID = DTOAttributeSystem.CurrentEmployee.ID;
                string sStatus = cboStatus.EditValue == null ? string.Empty : Convert.ToString(cboStatus.EditValue);
                _Types = sStatus == "O" ? false : true; // 1: Đang đóng => Mở | 0: Đang mở => Đóng
                bResult = BLLCounterOpenClose.CatCounter_OpenClose(lCounterID, lEmpID, _Types, out _Message);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            bool bTypes = false;
            if (OpenCloseClick(out bTypes, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
                DTOAttributeSystem.CurrentCounter.ID = bTypes ? Convert.ToInt64(cboCounter.EditValue) : -1;
                LoadDataToForm();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }
        }

        private void btnQueryInStockCounter_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQueryInStockCounter frm = new frmQueryInStockCounter();
            frm.ShowDialog();
            this.Close();
        }
        #endregion

        #region DropDownList
        private void cboCounter_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataToForm();
        }
        #endregion
    }
}