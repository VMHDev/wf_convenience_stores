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
using DevExpress.XtraGrid.Columns;
using CRM_BLL.BLLCategories;
using DevExpress.XtraEditors.Repository;
using CRM_DTO.DTOSystem;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;

namespace CRM_GUI.GUICategories
{
    public partial class frmProductCat : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        private const int gbSizeImage = 160;
        #endregion

        #region Form
        public frmProductCat()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmProductCat_Load(object sender, EventArgs e)
        {
            LoadDefault();
            LoadDataToGrid();
            LoadDataToCombobox();
        }
        #endregion

        #region Design
        #region Declare Controls
        public GridColumn colID { get; set; }
        public GridColumn colProductCatCode { get; set; }
        public GridColumn colProductCatName { get; set; }
        public GridColumn colDescriptions { get; set; }
        public GridColumn colProductTypeID { get; set; }
        public GridColumn colProductTypeCode { get; set; }
        public GridColumn colProductTypeName { get; set; }
        public GridColumn colProductGroupID { get; set; }
        public GridColumn colProductGroupCode { get; set; }
        public GridColumn colProductGroupName { get; set; }
        public GridColumn colSupplierID { get; set; }
        public GridColumn colSupplierCode { get; set; }
        public GridColumn colSupplierName { get; set; }
        public GridColumn colProductCatImage { get; set; }
        public GridColumn colOrderBy { get; set; }
        public GridColumn colIsActive { get; set; }
        public GridColumn colUpdateDate { get; set; }
        public GridColumn colUpdateBy { get; set; }
        public GridColumn colUserUpdate { get; set; }

        public RepositoryItemPictureEdit rpicProductWorker { get; set; }
        public RepositoryItemMemoEdit rtxtDescriptions { get; set; }
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Danh mục hàng hóa";
            this.Load += new System.EventHandler(this.frmProductCat_Load);
            #endregion

            DesignGridview();
        }

        private void DesignGridview()
        {
            #region colID
            colID = new DevExpress.XtraGrid.Columns.GridColumn();
            colID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colID.AppearanceCell.Options.UseFont = true;
            colID.Caption = "ID khách hàng";
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = false;
            //colID.VisibleIndex = -1;
            colID.Width = 80;
            #endregion

            #region colProductCatCode
            colProductCatCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCatCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductCatCode.AppearanceCell.Options.UseFont = true;
            colProductCatCode.Caption = "Mã danh mục";
            colProductCatCode.FieldName = "ProductCatCode";
            colProductCatCode.Name = "colProductCatCode";
            colProductCatCode.Visible = true;
            colProductCatCode.VisibleIndex = 0;
            colProductCatCode.Width = 150;
            #endregion

            #region colProductCatName
            colProductCatName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCatName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductCatName.AppearanceCell.Options.UseFont = true;
            colProductCatName.Caption = "Tên danh mục";
            colProductCatName.FieldName = "ProductCatName";
            colProductCatName.Name = "colProductCatName";
            colProductCatName.Visible = true;
            colProductCatName.VisibleIndex = 1;
            colProductCatName.Width = 200;
            #endregion

            #region rtxtDescriptions
            rtxtDescriptions = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            rtxtDescriptions.Name = "rtxtDescriptions";
            rtxtDescriptions.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            rtxtDescriptions.Appearance.Options.UseFont = true;
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
            colDescriptions.MaxWidth = 200;
            colDescriptions.MinWidth = 200;
            colDescriptions.ColumnEdit = rtxtDescriptions;
            colDescriptions.AppearanceCell.Options.UseTextOptions = true;
            colDescriptions.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            colProductTypeCode.FieldName = "ProductTypeCode";
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
            colProductTypeName.VisibleIndex = 3;
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
            colProductGroupCode.FieldName = "ProductGroupCode";
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
            colProductGroupName.VisibleIndex = 4;
            colProductGroupName.Width = 150;
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
            colSupplierCode.FieldName = "SupplierCode";
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
            colSupplierName.VisibleIndex = 5;
            colSupplierName.Width = 150;
            #endregion

            #region rpicProductWorker
            rpicProductWorker = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            rpicProductWorker.Name = "rpicProductWorker";
            rpicProductWorker.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            rpicProductWorker.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Always;
            rpicProductWorker.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            #endregion

            #region colProductCatImage
            colProductCatImage = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCatImage.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colProductCatImage.AppearanceCell.Options.UseFont = true;
            colProductCatImage.Caption = "Hình ảnh";
            colProductCatImage.FieldName = "ProductCatImage";
            colProductCatImage.Name = "colProductCatImage";
            colProductCatImage.Visible = true;
            colProductCatImage.VisibleIndex = 6;
            colProductCatImage.MaxWidth = gbSizeImage;
            colProductCatImage.MinWidth = gbSizeImage;
            colProductCatImage.Width = gbSizeImage;
            colProductCatImage.ColumnEdit = rpicProductWorker;
            #endregion
            
            #region colOrderBy
            colOrderBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderBy.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colOrderBy.AppearanceCell.Options.UseFont = true;
            colOrderBy.Caption = "Thứ tự";
            colOrderBy.FieldName = "OrderBy";
            colOrderBy.Name = "colOrderBy";
            colOrderBy.Visible = true;
            colOrderBy.VisibleIndex = 7;
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
            colIsActive.VisibleIndex = 8;
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
            colUserUpdate.Caption = "User cập nhật";
            colUserUpdate.FieldName = "UserUpdate";
            colUserUpdate.Name = "colUserUpdate";
            colUpdateDate.Visible = false;
            //colUpdateDate.VisibleIndex = -1;
            colUpdateDate.Width = 100;
            #endregion

            #region GridControl
            this.grcProductCat.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                rpicProductWorker,
                rtxtDescriptions});
            #endregion

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvProductCat.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvProductCat.OptionsBehavior.Editable = false;
            // Hiển thị filter
            grvProductCat.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvProductCat.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvProductCat.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvProductCat.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvProductCat.Appearance.HeaderPanel.Options.UseFont = true;
            grvProductCat.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvProductCat.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvProductCat.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCounter.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvProductCat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colID,
                colProductCatCode,
                colProductCatName,
                colDescriptions,
                colProductTypeID,
                colProductTypeCode,
                colProductTypeName,
                colProductGroupID,
                colProductGroupCode,
                colProductGroupName,
                colSupplierID,
                colSupplierCode,
                colSupplierName,
                colProductCatImage,
                colOrderBy,
                colIsActive,
                colUpdateDate,
                colUpdateBy,
                colUserUpdate,
            });
            // Tăng kích thước chiều cao dòng
            grvProductCat.RowHeight = gbSizeImage;
            grvProductCat.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.grvProductCat_CalcRowHeight);            
            #endregion
        }
        #endregion

        #region Functions
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("DataSource");
            tblInit.Columns.Add("ID", typeof(Int64));
            tblInit.Columns.Add("ProductCatCode", typeof(string));
            tblInit.Columns.Add("ProductCatName", typeof(string));
            tblInit.Columns.Add("Descriptions", typeof(string));
            tblInit.Columns.Add("ProductTypeID", typeof(Int64));
            tblInit.Columns.Add("ProductTypeCode", typeof(string));
            tblInit.Columns.Add("ProductTypeName", typeof(string));
            tblInit.Columns.Add("ProductGroupID", typeof(Int64));
            tblInit.Columns.Add("ProductGroupCode", typeof(string));
            tblInit.Columns.Add("ProductGroupName", typeof(string));
            tblInit.Columns.Add("SupplierID", typeof(Int64));
            tblInit.Columns.Add("SupplierCode", typeof(string));
            tblInit.Columns.Add("SupplierName", typeof(string));
            tblInit.Columns.Add("ProductCatImage", typeof(byte[]));
            tblInit.Columns.Add("IsActive", typeof(bool));
            tblInit.Columns.Add("UpdateDate", typeof(DateTime));
            tblInit.Columns.Add("UpdateBy", typeof(Int64));
            tblInit.Columns.Add("UserUpdate", typeof(string));
            tblInit.Columns.Add("OrderBy", typeof(Int64));
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
                ds = BLLCatProduct.CatProduct_GetAll(out sMessage);
                grcProductCat.DataSource = ds.Tables[0].Copy();
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

        private void LoadDataToCombobox()
        {

        }

        private void LoadDefault()
        {
            try
            {
                grcProductCat.DataSource = InitDataSourceGrid();
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
            DataTable dtSource = ((DataView)grvProductCat.DataSource).ToTable("DataSource");
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
                frmProductCatUdp frm = new frmProductCatUdp(_OrderBy);
                frm.ShowDialog();
                if (frm.gbResultHandler)
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
                bResult = BLLCatProduct.CatProduct_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
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
                DTOCatProduct objCatProduct = new DTOCatProduct();
                objCatProduct.ProductCatID = grvProductCat.GetFocusedRowCellValue(colID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductCat.GetFocusedRowCellValue(colID));
                objCatProduct.ProductCatCode = grvProductCat.GetFocusedRowCellValue(colProductCatCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colProductCatCode));
                objCatProduct.ProductCatName = grvProductCat.GetFocusedRowCellValue(colProductCatName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colProductCatName));
                objCatProduct.Descriptions = grvProductCat.GetFocusedRowCellValue(colDescriptions) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colDescriptions));
                objCatProduct.ProductType.ID = grvProductCat.GetFocusedRowCellValue(colProductTypeID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductCat.GetFocusedRowCellValue(colProductTypeID));
                objCatProduct.ProductType.ProductTypeCode = grvProductCat.GetFocusedRowCellValue(colProductTypeCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colProductTypeCode));
                objCatProduct.ProductType.ProductTypeName = grvProductCat.GetFocusedRowCellValue(colProductTypeName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colProductTypeName));
                objCatProduct.ProductGroup.ID = grvProductCat.GetFocusedRowCellValue(colProductGroupID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductCat.GetFocusedRowCellValue(colProductGroupID));
                objCatProduct.ProductGroup.ProductGroupCode = grvProductCat.GetFocusedRowCellValue(colProductGroupCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colProductGroupCode));
                objCatProduct.ProductGroup.ProductGroupName = grvProductCat.GetFocusedRowCellValue(colProductGroupName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colProductGroupName));
                objCatProduct.Supplier.ID = grvProductCat.GetFocusedRowCellValue(colSupplierID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductCat.GetFocusedRowCellValue(colSupplierID));
                objCatProduct.Supplier.SupplierCode = grvProductCat.GetFocusedRowCellValue(colSupplierCode) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colSupplierCode));
                objCatProduct.Supplier.SupplierName = grvProductCat.GetFocusedRowCellValue(colSupplierName) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colSupplierName));
                objCatProduct.ProductCatImage = grvProductCat.GetFocusedRowCellValue(colProductCatImage) == DBNull.Value ? null : (byte[])grvProductCat.GetFocusedRowCellValue(colProductCatImage);
                objCatProduct.OrderBy = grvProductCat.GetFocusedRowCellValue(colOrderBy) == DBNull.Value ? -1 : Convert.ToInt64(grvProductCat.GetFocusedRowCellValue(colOrderBy));
                objCatProduct.IsActive = grvProductCat.GetFocusedRowCellValue(colIsActive) == DBNull.Value ? true : Convert.ToBoolean(grvProductCat.GetFocusedRowCellValue(colIsActive));
                objCatProduct.UpdateDate = grvProductCat.GetFocusedRowCellValue(colUpdateDate) == DBNull.Value ? Convert.ToDateTime("01/01/1990") : Convert.ToDateTime(grvProductCat.GetFocusedRowCellValue(colUpdateDate));
                objCatProduct.UpdateBy = grvProductCat.GetFocusedRowCellValue(colUpdateBy) == DBNull.Value ? -1 : Convert.ToInt64(grvProductCat.GetFocusedRowCellValue(colUpdateBy));
                objCatProduct.UserUpdate = grvProductCat.GetFocusedRowCellValue(colUserUpdate) == DBNull.Value ? string.Empty : Convert.ToString(grvProductCat.GetFocusedRowCellValue(colUserUpdate));
                objCatProduct.IsDelete = false;

                frmProductCatUdp frm = new frmProductCatUdp(objCatProduct);
                frm.ShowDialog();
                if (frm.gbResultHandler)
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

        #region Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            long lMaxOrderBy = GetMaxOrderBy();
            AddClick(lMaxOrderBy);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            long lID = grvProductCat.GetFocusedRowCellValue(colID) == DBNull.Value ? -1 : Convert.ToInt64(grvProductCat.GetFocusedRowCellValue(colID));
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Gridview
        private void grvProductCat_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            if (grvProductCat.IsFilterRow(e.RowHandle))
            {
                e.RowHeight = -1;
            }
        }
        #endregion
    }
}