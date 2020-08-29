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
using DevExpress.XtraGrid.Columns;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;
using CRM_DTO.DTOSystem;

namespace CRM_GUI.GUICategories
{
    public partial class frmCounter : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmCounter()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmCounter_Load(object sender, EventArgs e)
        {
            LoadDefault();
            LoadDataToGrid();            
        }
        #endregion

        #region Functions
        /// <summary>
        /// Khởi tạo datasource trên lưới
        /// </summary>
        /// <returns></returns>
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("ID", typeof(long));
            tblInit.Columns.Add("CounterCode", typeof(string));
            tblInit.Columns.Add("CounterName", typeof(string));
            tblInit.Columns.Add("StatusCode", typeof(string));
            tblInit.Columns.Add("StatusName", typeof(string));
            tblInit.Columns.Add("ShopID", typeof(long));
            tblInit.Columns.Add("ShopName", typeof(string));
            tblInit.Columns.Add("OrderBy", typeof(long));
            tblInit.Columns.Add("IsActive", typeof(bool));
            tblInit.Columns.Add("UpdateDate", typeof(DateTime));
            tblInit.Columns.Add("UpdateBy", typeof(long));
            tblInit.Columns.Add("UserUpdate", typeof(string));
            return tblInit;
        }

        /// <summary>
        /// Load dữ liệu lên lưới
        /// </summary>
        private void LoadDataToGrid()
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            try
            {
                ds = BLLCatCounter.CatCounter_GetAll(out sMessage);
                grcCounter.DataSource = ds.Tables[0].Copy();
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
                grcCounter.DataSource = InitDataSourceGrid();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Lấy số thứ tự lớn nhất
        /// </summary>
        /// <returns>Số thứ tự lớn nhất</returns>
        private long GetMaxOrderBy()
        {            
            DataTable dtSource = ((DataView)grvCounter.DataSource).ToTable("DataSourceCounter");
            var vMaxOrderBy = dtSource.AsEnumerable().Max(row => row["OrderBy"]);
            return Convert.ToInt64(vMaxOrderBy);
        }

        /// <summary>
        /// Thêm
        /// </summary>
        /// <param name="_OrderBy">Số thứ tự lớn nhất</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool AddClick(long _OrderBy)
        {
            bool bResult = false;
            try
            {
                frmCounterUdp frm = new frmCounterUdp(_OrderBy);
                frm.ShowDialog();
                if (frm.ResultHandler)
                {
                    LoadDataToGrid();
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
                bResult = BLLCatCounter.CatCounter_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }

        /// <summary>
        /// Sửa
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool EditClick()
        {
            bool bResult = false;
            try
            {
                long lID = grvCounter.GetFocusedRowCellValue(colID) == DBNull.Value ? -1 : Convert.ToInt64(grvCounter.GetFocusedRowCellValue(colID));
                string sCounterCode = grvCounter.GetFocusedRowCellValue(colCounterCode) == DBNull.Value ? string.Empty : grvCounter.GetFocusedRowCellValue(colCounterCode).ToString();
                string sCounterName = grvCounter.GetFocusedRowCellValue(colCounterName) == DBNull.Value ? string.Empty : grvCounter.GetFocusedRowCellValue(colCounterName).ToString();
                long lOrderBy = grvCounter.GetFocusedRowCellValue(colOrderBy) == DBNull.Value ? -1 : Convert.ToInt64(grvCounter.GetFocusedRowCellValue(colOrderBy));
                bool bIsActive = grvCounter.GetFocusedRowCellValue(colIsActive) == DBNull.Value ? true : Convert.ToBoolean(grvCounter.GetFocusedRowCellValue(colIsActive));
                DTOCatShop objShop = new DTOCatShop();
                objShop.ID = grvCounter.GetFocusedRowCellValue(colShopID) == DBNull.Value ? -1 : Convert.ToInt64(grvCounter.GetFocusedRowCellValue(colShopID));
                DTOCatCounter objCounter = new DTOCatCounter(lID, sCounterCode, sCounterName, "C", objShop, lOrderBy, bIsActive, DateTime.Now, DTOAttributeSystem.CurrentUser.ID, false);

                frmCounterUdp frm = new frmCounterUdp(objCounter);
                frm.ShowDialog();
                if(frm.ResultHandler)
                {
                    LoadDataToGrid();
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        #endregion

        #region Design
        #region Declare Controls
        public GridColumn colID { get; set; }
        public GridColumn colCounterCode { get; set; }
        public GridColumn colCounterName { get; set; }
        public GridColumn colStatusCode { get; set; }
        public GridColumn colStatusName { get; set; }
        public GridColumn colShopID { get; set; }
        public GridColumn colShopName { get; set; }
        public GridColumn colOrderBy { get; set; }
        public GridColumn colIsActive { get; set; }
        public GridColumn colUpdateDate { get; set; }
        public GridColumn colUpdateBy { get; set; }
        public GridColumn colUserUpdate { get; set; }
        #endregion

        /// <summary>
        /// Design controls
        /// </summary>
        private void DesignControls()
        {
            #region Form
            this.Text = "Quầy thu ngân";
            this.Load += new System.EventHandler(this.frmCounter_Load);
            #endregion

            DesignGridview();
        }

        /// <summary>
        /// Design lưới dữ liệu
        /// </summary>
        private void DesignGridview()
        {
            #region colID
            colID = new DevExpress.XtraGrid.Columns.GridColumn();
            colID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colID.AppearanceCell.Options.UseFont = true;
            colID.Caption = "ID Quầy/kho";
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = false;
            //colID.VisibleIndex = -1;
            colID.Width = 80;
            #endregion

            #region colCounterCode
            colCounterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCounterCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCounterCode.AppearanceCell.Options.UseFont = true;
            colCounterCode.Caption = "Mã quầy thu ngân";
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
            colCounterName.Caption = "Tên quầy thu ngân";
            colCounterName.FieldName = "CounterName";
            colCounterName.Name = "colCounterName";
            colCounterName.Visible = true;
            colCounterName.VisibleIndex = 1;
            colCounterName.Width = 150;
            #endregion

            #region colShopID
            colShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            colShopID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colShopID.AppearanceCell.Options.UseFont = true;
            colShopID.Caption = "ID Cửa hàng";
            colShopID.FieldName = "ShopID";
            colShopID.Name = "colShopID";
            colShopID.Visible = false;
            //colShopID.VisibleIndex = -1;
            colShopID.Width = 80;
            #endregion

            #region colShopName
            colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            colShopName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colShopName.AppearanceCell.Options.UseFont = true;
            colShopName.Caption = "Mã Cửa hàng";
            colShopName.FieldName = "ShopName";
            colShopName.Name = "colShopName";
            colShopName.Visible = true;
            colShopName.VisibleIndex = 2;
            colShopName.Width = 120;
            #endregion

            #region colOrderBy
            colOrderBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderBy.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colOrderBy.AppearanceCell.Options.UseFont = true;
            colOrderBy.AppearanceCell.Options.UseTextOptions = true;
            colOrderBy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colOrderBy.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colOrderBy.Caption = "Thứ tự";
            colOrderBy.FieldName = "OrderBy";
            colOrderBy.Name = "colOrderBy";
            colOrderBy.Visible = true;
            colOrderBy.VisibleIndex = 3;
            colOrderBy.Width = 100;
            #endregion

            #region colIsActive
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colIsActive.AppearanceCell.Options.UseFont = true;
            colIsActive.Caption = "Hoạt động";
            colIsActive.FieldName = "IsActive";
            colIsActive.Name = "colIsActive";
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 4;
            colIsActive.Width = 100;
            #endregion

            #region colUpdateDate
            colUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateDate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUpdateDate.AppearanceCell.Options.UseFont = true;
            colUpdateDate.Caption = "Ngày cập nhật";
            colUpdateDate.FieldName = "UpdateDate";
            colUpdateDate.Name = "colUpdateDate";
            colUpdateDate.Visible = false;
            //colUpdateDate.VisibleIndex = -1;
            colUpdateDate.Width = 100;
            #endregion

            #region colUpdateBy
            colUpdateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdateBy.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUpdateBy.AppearanceCell.Options.UseFont = true;
            colUpdateBy.Caption = "User cập nhật";
            colUpdateBy.FieldName = "UpdateBy";
            colUpdateBy.Name = "colUpdateBy";
            colUpdateDate.Visible = false;
            //colUpdateDate.VisibleIndex = -1;
            colUpdateDate.Width = 100;
            #endregion

            #region colUserUpdate
            colUserUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            colUserUpdate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUserUpdate.AppearanceCell.Options.UseFont = true;
            colUserUpdate.Caption = "Mã Cửa hàng";
            colUserUpdate.FieldName = "UserUpdate";
            colUserUpdate.Name = "colUserUpdate";
            colUserUpdate.Visible = false;
            //colUserUpdate.VisibleIndex = -1;
            colUserUpdate.Width = 120;
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvCounter.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvCounter.OptionsBehavior.Editable = false;
            // Hiển thị filter
            grvCounter.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvCounter.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCounter.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCounter.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCounter.Appearance.HeaderPanel.Options.UseFont = true;
            grvCounter.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCounter.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCounter.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCounter.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCounter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colID,
            colCounterCode,
            colCounterName,
            colOrderBy,
            colIsActive,
            colUpdateDate,
            colUpdateBy
            });
            #endregion
        }
        #endregion

        #region Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            long lMaxOrderBy = GetMaxOrderBy();
            AddClick(lMaxOrderBy);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            long lID = grvCounter.GetFocusedRowCellValue(colID) == DBNull.Value ? -1 : Convert.ToInt64(grvCounter.GetFocusedRowCellValue(colID));
            if (DeleteClick(lID, out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.TextHandlerSuccess);
                LoadDataToGrid();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}