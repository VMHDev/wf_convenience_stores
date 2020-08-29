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
using CRM_BLL.BLLCategories;
using CRM_GUI.CRMUtility.Messages;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_GUI.GUICounter;
using CRM_DTO.DTOSystem;
using CRM_BLL.BLLSystem;

namespace CRM_GUI.GUIQuery
{
    public partial class frmQueryInStockCounter : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmQueryInStockCounter()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmQueryInStockCounter_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDefault();
            LoadDataToGrid(DTOAttributeSystem.CurrentCounter.ID);
        }
        #endregion

        #region DesignControls
        #region Declare Controls
        #region cboCounter
        public GridView grvCboCounter { get; set; }
        public GridColumn colCboCounterCode { get; set; }
        public GridColumn colCboCounterName { get; set; }
        public GridColumn colCboCounterShopName { get; set; }
        #endregion

        #region Gridview
        public GridColumn colCounterID { get; set; }
        public GridColumn colCounterCode { get; set; }
        public GridColumn colCounterName { get; set; }
        public GridColumn colCurrencyID { get; set; }
        public GridColumn colCurrencyCode { get; set; }
        public GridColumn colCurrencyDesc { get; set; }
        public GridColumn colInStock { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Design Controls
        /// </summary>
        private void DesignControls()
        {
            try
            {
                #region Form
                this.Text = "Tra cứu số dư quầy thu ngân";
                this.StartPosition = FormStartPosition.CenterParent;
                this.Load += new System.EventHandler(this.frmQueryInStockCounter_Load);
                #endregion

                DesignGridLookUpEdit();
                DesignGridview();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Design GridLookUpEdit
        /// </summary>
        private void DesignGridLookUpEdit()
        {
            #region cboCounter
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
        }
       
        /// <summary>
        /// Design lưới dữ liệu
        /// </summary>
        private void DesignGridview()
        {
            #region colCounterID
            colCounterID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterID.AppearanceCell.Options.UseFont = true;
            colCounterID.Caption = "ID Quầy thu ngân";
            colCounterID.FieldName = "CounterID";
            colCounterID.Name = "colCounterID";
            colCounterID.Visible = false;
            //colCounterID.VisibleIndex = -1;
            colCounterID.Width = 80;
            #endregion

            #region colCounterCode
            colCounterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterCode.AppearanceCell.Options.UseFont = true;
            colCounterCode.Caption = "Mã quầy";
            colCounterCode.FieldName = "CounterCode";
            colCounterCode.Name = "colCounterCode";
            colCounterCode.Visible = true;
            colCounterCode.VisibleIndex = 0;
            colCounterCode.Width = 120;
            #endregion

            #region colCounterName
            colCounterName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterName.AppearanceCell.Options.UseFont = true;
            colCounterName.Caption = "Quầy thu ngân";
            colCounterName.FieldName = "CounterName";
            colCounterName.Name = "colCounterName";
            colCounterName.Visible = true;
            colCounterName.VisibleIndex = 0;
            colCounterName.Width = 120;
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
            colCurrencyDesc.Visible = false;
            //colCurrencyCode.VisibleIndex = -1;
            colCurrencyDesc.Width = 120;
            #endregion

            #region colInStock
            colInStock = new DevExpress.XtraGrid.Columns.GridColumn();
            colInStock.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colInStock.AppearanceCell.Options.UseFont = true;
            colInStock.DisplayFormat.FormatString = "{0:#,##0}";
            colInStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colInStock.Caption = "Số lượng";
            colInStock.FieldName = "InStock";
            colInStock.Name = "colInStock";
            colInStock.Visible = true;
            colInStock.VisibleIndex = 2;
            colInStock.Width = 100;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvInStockCounter.OptionsView.ShowGroupPanel = false;
            grvInStockCounter.OptionsBehavior.Editable = false;
            // Định dạng chữ dòng dữ liệu
            grvInStockCounter.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvInStockCounter.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvInStockCounter.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvInStockCounter.Appearance.HeaderPanel.Options.UseFont = true;
            grvInStockCounter.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvInStockCounter.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvInStockCounter.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            // grvInStockCounter.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvInStockCounter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colCounterID,
                colCounterCode,
                colCounterName,
                colCurrencyID,
                colCurrencyCode,
                colCurrencyDesc,
                colInStock
            });           
            #endregion
        }
        #endregion

        #region Function
        /// <summary>
        /// Khởi tạo datasource cho lưới dữ liệu
        /// </summary>
        /// <returns></returns>
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("CounterID", typeof(long));
            tblInit.Columns.Add("CounterCode", typeof(string));
            tblInit.Columns.Add("CounterName", typeof(string));
            tblInit.Columns.Add("CurrencyID", typeof(long));
            tblInit.Columns.Add("CurrencyCode", typeof(string));
            tblInit.Columns.Add("CurrencyDesc", typeof(string));
            tblInit.Columns.Add("InStock", typeof(decimal));
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
        private void LoadDataToGrid(long _CounterID)
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                ds = BLLSysCounterStock.SysCounterStock_GetWithCounter(_CounterID, out sMessage);
                grcInStockCounter.DataSource = ds.Tables[0].Copy();
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
        /// Load dữ liệu mặc định cho form
        /// </summary>
        private void LoadDefault()
        {
            cboCounter.EditValue = DTOAttributeSystem.CurrentCounter.ID;
            grcInStockCounter.DataSource = InitDataSourceGrid().Clone();
        }
        #endregion

        #region Combobox
        private void cboCounter_EditValueChanged(object sender, EventArgs e)
        {
            long lCounterID = cboCounter.EditValue == null ? -1 : Convert.ToInt64(cboCounter.EditValue);
            LoadDataToGrid(lCounterID);
        }
        #endregion

        #region Button
        private void btnOpenCloseCounter_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCounterOpenClose frm = new frmCounterOpenClose();
            frm.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}