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
using DevExpress.XtraGrid.Columns;
using CRM_GUI.CRMUtility.Messages;
using CRM_DTO.CRMUtility;
using CRM_BLL.BLLCategories;
using CRM_DTO.DTOCategories;
using CRM_DTO.DTOSystem;

namespace CRM_GUI.GUICategories
{
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmCustomer()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadDefault();
            LoadDataToGrid();
        }
        #endregion

        #region Functions
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("ID", typeof(Int64));
            tblInit.Columns.Add("CustCode", typeof(string));
            tblInit.Columns.Add("CustName", typeof(string));
            tblInit.Columns.Add("CustAddress", typeof(string));
            tblInit.Columns.Add("Phone", typeof(string));
            tblInit.Columns.Add("Notes", typeof(string));
            tblInit.Columns.Add("IdentificationCard", typeof(string));
            tblInit.Columns.Add("BirthDate", typeof(DateTime));
            tblInit.Columns.Add("Gender", typeof(bool));
            tblInit.Columns.Add("Email", typeof(string));
            tblInit.Columns.Add("CustGroupID", typeof(Int64));
            tblInit.Columns.Add("CustGroupName", typeof(string));
            tblInit.Columns.Add("CustTypeID", typeof(Int64));
            tblInit.Columns.Add("CustTypeName", typeof(string));
            tblInit.Columns.Add("OrderBy", typeof(Int64));
            tblInit.Columns.Add("IsActive", typeof(bool));
            tblInit.Columns.Add("UpdateDate", typeof(DateTime));
            tblInit.Columns.Add("UpdateBy", typeof(Int64));
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
                ds = BLLCatCustomer.CatCustomer_GetAll(out sMessage);
                grcCustomer.DataSource = ds.Tables[0].Copy();
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
                grcCustomer.DataSource = InitDataSourceGrid();
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
            DataTable dtSource = ((DataView)grvCustomer.DataSource).ToTable("DataSourceCustomer");
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
                frmCustomerUdp frm = new frmCustomerUdp(_OrderBy);
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
                bResult = BLLCatCustomer.CatCustomer_Del(_ID, DTOAttributeSystem.CurrentUser.ID, out _Message);
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
                long lID = grvCustomer.GetFocusedRowCellValue(colID) == DBNull.Value ? -1 : Convert.ToInt64(grvCustomer.GetFocusedRowCellValue(colID));
                string sCustCode = grvCustomer.GetFocusedRowCellValue(colCustCode) == DBNull.Value ? string.Empty : Convert.ToString(grvCustomer.GetFocusedRowCellValue(colCustCode));
                string sCustName = grvCustomer.GetFocusedRowCellValue(colCustName) == DBNull.Value ? string.Empty : Convert.ToString(grvCustomer.GetFocusedRowCellValue(colCustName));
                string sCustAddress = grvCustomer.GetFocusedRowCellValue(colCustAddress) == DBNull.Value ? string.Empty : Convert.ToString(grvCustomer.GetFocusedRowCellValue(colCustAddress));
                string sPhone = grvCustomer.GetFocusedRowCellValue(colPhone) == DBNull.Value ? string.Empty : Convert.ToString(grvCustomer.GetFocusedRowCellValue(colPhone));
                string sNotes = grvCustomer.GetFocusedRowCellValue(colNotes) == DBNull.Value ? string.Empty : Convert.ToString(grvCustomer.GetFocusedRowCellValue(colNotes));
                string sIdentificationCard = grvCustomer.GetFocusedRowCellValue(colIdentificationCard) == DBNull.Value ? string.Empty : Convert.ToString(grvCustomer.GetFocusedRowCellValue(colIdentificationCard));
                DateTime dtmBirthDate = grvCustomer.GetFocusedRowCellValue(colBirthDate) == DBNull.Value ? Convert.ToDateTime("01/01/1990") : Convert.ToDateTime(grvCustomer.GetFocusedRowCellValue(colBirthDate));
                bool bGender = grvCustomer.GetFocusedRowCellValue(colGender) == DBNull.Value ? true : Convert.ToBoolean(grvCustomer.GetFocusedRowCellValue(colGender));
                string sEmail = grvCustomer.GetFocusedRowCellValue(colEmail) == DBNull.Value ? string.Empty : Convert.ToString(grvCustomer.GetFocusedRowCellValue(colEmail));
                long lOrderBy = grvCustomer.GetFocusedRowCellValue(colOrderBy) == DBNull.Value ? -1 : Convert.ToInt64(grvCustomer.GetFocusedRowCellValue(colOrderBy));
                bool bIsActive = grvCustomer.GetFocusedRowCellValue(colIsActive) == DBNull.Value ? true : Convert.ToBoolean(grvCustomer.GetFocusedRowCellValue(colIsActive));
                DateTime dtmUpdateDate = grvCustomer.GetFocusedRowCellValue(colUpdateDate) == DBNull.Value ? Convert.ToDateTime("01/01/1990") : Convert.ToDateTime(grvCustomer.GetFocusedRowCellValue(colUpdateDate));
                long lUpdateBy = grvCustomer.GetFocusedRowCellValue(colUpdateBy) == DBNull.Value ? -1 : Convert.ToInt64(grvCustomer.GetFocusedRowCellValue(colUpdateBy));
                bool bIsDelete = false;

                DTOCatCustomerGroup objCustGroup = new DTOCatCustomerGroup();
                objCustGroup.ID = grvCustomer.GetFocusedRowCellValue(colCustGroupID) == DBNull.Value ? -1 : Convert.ToInt64(grvCustomer.GetFocusedRowCellValue(colCustGroupID));
                DTOCatCustomerType objCustType = new DTOCatCustomerType();
                objCustType.ID = grvCustomer.GetFocusedRowCellValue(colCustTypeID) == DBNull.Value ? -1 : Convert.ToInt64(grvCustomer.GetFocusedRowCellValue(colCustTypeID));
                DTOCatCustomer objCustomer = new DTOCatCustomer(lID, sCustCode, sCustName, 
                                                                sCustAddress, sPhone, sNotes,
                                                                sIdentificationCard, dtmBirthDate, bGender,
                                                                sEmail, objCustGroup, objCustType,
                                                                lOrderBy, bIsActive, dtmUpdateDate,
                                                                lUpdateBy, bIsDelete);

                frmCustomerUdp frm = new frmCustomerUdp(objCustomer);
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
        #endregion

        #region Design
        #region Declare Controls
        public GridColumn colID { get; set; }
        public GridColumn colCustCode { get; set; }
        public GridColumn colCustName { get; set; }
        public GridColumn colCustAddress { get; set; }
        public GridColumn colPhone { get; set; }
        public GridColumn colNotes { get; set; }
        public GridColumn colIdentificationCard { get; set; }
        public GridColumn colBirthDate { get; set; }
        public GridColumn colGender { get; set; }
        public GridColumn colEmail { get; set; }
        public GridColumn colCustGroupID { get; set; }
        public GridColumn colCustGroupName { get; set; }
        public GridColumn colCustTypeID { get; set; }
        public GridColumn colCustTypeName { get; set; }
        public GridColumn colOrderBy { get; set; }
        public GridColumn colIsActive { get; set; }
        public GridColumn colUpdateDate { get; set; }
        public GridColumn colUpdateBy { get; set; }
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
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

            #region colCustCode
            colCustCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustCode.AppearanceCell.Options.UseFont = true;
            colCustCode.Caption = "Mã khách hàng";
            colCustCode.FieldName = "CustCode";
            colCustCode.Name = "colCustCode";
            colCustCode.Visible = true;
            colCustCode.VisibleIndex = 0;
            colCustCode.Width = 120;
            #endregion

            #region colCustName
            colCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustName.AppearanceCell.Options.UseFont = true;
            colCustName.Caption = "Khách hàng";
            colCustName.FieldName = "CustName";
            colCustName.Name = "colCustName";
            colCustName.Visible = true;
            colCustName.VisibleIndex = 1;
            colCustName.Width = 150;
            #endregion

            #region colCustAddress
            colCustAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustAddress.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustAddress.AppearanceCell.Options.UseFont = true;
            colCustAddress.Caption = "Địa chỉ";
            colCustAddress.FieldName = "CustAddress";
            colCustAddress.Name = "colCustAddress";
            colCustAddress.Visible = true;
            colCustAddress.VisibleIndex = 2;
            colCustAddress.Width = 200;
            #endregion

            #region colPhone
            colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhone.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colPhone.AppearanceCell.Options.UseFont = true;
            colPhone.Caption = "SĐT";
            colPhone.FieldName = "Phone";
            colPhone.Name = "colPhone";
            colPhone.Visible = true;
            colPhone.VisibleIndex = 3;
            colPhone.Width = 100;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 4;
            colNotes.Width = 180;
            #endregion

            #region colIdentificationCard
            colIdentificationCard = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdentificationCard.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colIdentificationCard.AppearanceCell.Options.UseFont = true;
            colIdentificationCard.Caption = "CMND";
            colIdentificationCard.FieldName = "IdentificationCard";
            colIdentificationCard.Name = "colIdentificationCard";
            colIdentificationCard.Visible = true;
            colIdentificationCard.VisibleIndex = 5;
            colIdentificationCard.Width = 100;
            #endregion

            #region colBirthDate
            colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colBirthDate.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colBirthDate.AppearanceCell.Options.UseFont = true;
            colBirthDate.Caption = "Ngày sinh";
            colBirthDate.FieldName = "BirthDate";
            colBirthDate.Name = "colBirthDate";
            colBirthDate.Visible = true;
            colBirthDate.VisibleIndex = 6;
            colBirthDate.Width = 100;
            #endregion

            #region colGender
            colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            colGender.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colGender.AppearanceCell.Options.UseFont = true;
            colGender.Caption = "Giới tính";
            colGender.FieldName = "Gender";
            colGender.Name = "colGender";
            colGender.Visible = true;
            colGender.VisibleIndex = 7;
            colGender.Width = 100;
            #endregion

            #region colEmail
            colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmail.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colEmail.AppearanceCell.Options.UseFont = true;
            colEmail.Caption = "Địa chỉ";
            colEmail.FieldName = "Email";
            colEmail.Name = "colEmail";
            colEmail.Visible = true;
            colEmail.VisibleIndex = 8;
            colEmail.Width = 120;
            #endregion

            #region colCustGroupID
            colCustGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustGroupID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustGroupID.AppearanceCell.Options.UseFont = true;
            colCustGroupID.Caption = "Mã nhóm khách hàng";
            colCustGroupID.FieldName = "CustGroupID";
            colCustGroupID.Name = "colCustGroupID";
            colCustGroupID.Visible = false;
            //colCustGroupID.VisibleIndex = -1;
            colCustGroupID.Width = 180;
            #endregion

            #region colCustGroupName
            colCustGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustGroupName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustGroupName.AppearanceCell.Options.UseFont = true;
            colCustGroupName.Caption = "Tên nhóm khách hàng";
            colCustGroupName.FieldName = "CustGroupName";
            colCustGroupName.Name = "colCustGroupName";
            colCustGroupName.Visible = true;
            colCustGroupName.VisibleIndex = 9;
            colCustGroupName.Width = 150;
            #endregion

            #region colCustTypeID
            colCustTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustTypeID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustTypeID.AppearanceCell.Options.UseFont = true;
            colCustTypeID.Caption = "Mã nhóm khách hàng";
            colCustTypeID.FieldName = "CustTypeID";
            colCustTypeID.Name = "colCustTypeID";
            colCustTypeID.Visible = false;
            //colCustTypeID.VisibleIndex = -1;
            colCustTypeID.Width = 180;
            #endregion

            #region colCustTypeName
            colCustTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustTypeName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustTypeName.AppearanceCell.Options.UseFont = true;
            colCustTypeName.Caption = "Tên loại khách hàng";
            colCustTypeName.FieldName = "CustTypeName";
            colCustTypeName.Name = "colCustTypeName";
            colCustTypeName.Visible = true;
            colCustTypeName.VisibleIndex = 10;
            colCustTypeName.Width = 200;
            #endregion

            #region colOrderBy
            colOrderBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderBy.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colOrderBy.AppearanceCell.Options.UseFont = true;
            colOrderBy.Caption = "Thứ tự";
            colOrderBy.FieldName = "OrderBy";
            colOrderBy.Name = "colOrderBy";
            colOrderBy.Visible = true;
            colOrderBy.VisibleIndex = 11;
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
            colIsActive.VisibleIndex = 12;
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

            #region Gridview
            layoutControlItemGridView.TextVisible = false;
            grvCustomer.OptionsView.ShowGroupPanel = false;
            // Không cho phép chỉnh sửa
            grvCustomer.OptionsBehavior.Editable = false;
            // Hiển thị filter
            grvCustomer.OptionsView.ShowAutoFilterRow = true;
            // Định dạng chữ dòng dữ liệu
            grvCustomer.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCustomer.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCustomer.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCustomer.Appearance.HeaderPanel.Options.UseFont = true;
            grvCustomer.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCustomer.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCustomer.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCounter.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colID,
            colCustCode,
            colCustName,
            colCustAddress,
            colPhone,
            colNotes,
            colIdentificationCard,
            colBirthDate,
            colGender,
            colEmail,
            colCustGroupID,
            colCustTypeID,
            colOrderBy,
            colIsActive,
            colUpdateDate,
            colUpdateBy,
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
            long lID = grvCustomer.GetFocusedRowCellValue(colID) == DBNull.Value ? -1 : Convert.ToInt64(grvCustomer.GetFocusedRowCellValue(colID));
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