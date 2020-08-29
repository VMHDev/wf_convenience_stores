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

namespace CRM_GUI.GUICategories
{
    public partial class frmCustomerType : DevExpress.XtraEditors.XtraForm
    {
        #region Functions
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("ID", typeof(Int64));
            tblInit.Columns.Add("CustTypeCode", typeof(string));
            tblInit.Columns.Add("CustTypeName", typeof(string));
            tblInit.Columns.Add("Notes", typeof(string));
            tblInit.Columns.Add("OrderBy", typeof(Int64));
            tblInit.Columns.Add("IsActive", typeof(bool));
            tblInit.Columns.Add("UpdateDate", typeof(DateTime));
            tblInit.Columns.Add("UpdateBy", typeof(Int64));
            return tblInit;
        }

        private void LoadDataToGrid()
        {

        }

        private void LoadDataToCombobox()
        {

        }

        private void LoadDefault()
        {
            grcCustomerType.DataSource = InitDataSourceGrid();
        }
        #endregion

        #region Design
        #region DesignControls

        #endregion

        #region DesignGridview
        public GridColumn colID { get; set; }
        public GridColumn colCustTypeCode { get; set; }
        public GridColumn colCustTypeName { get; set; }
        public GridColumn colNotes { get; set; }
        public GridColumn colOrderBy { get; set; }
        public GridColumn colIsActive { get; set; }
        public GridColumn colUpdateDate { get; set; }
        public GridColumn colUpdateBy { get; set; }

        private void InitColumnGridView()
        {
            #region colID
            colID = new DevExpress.XtraGrid.Columns.GridColumn();
            colID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colID.AppearanceCell.Options.UseFont = true;
            colID.Caption = "ID Loại khách hàng";
            colID.FieldName = "ID";
            colID.Name = "colID";
            colID.Visible = false;
            //colID.VisibleIndex = -1;
            colID.Width = 80;
            #endregion

            #region colCustTypeCode
            colCustTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustTypeCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustTypeCode.AppearanceCell.Options.UseFont = true;
            colCustTypeCode.Caption = "Mã loại khách hàng";
            colCustTypeCode.FieldName = "CustTypeCode";
            colCustTypeCode.Name = "colCustTypeCode";
            colCustTypeCode.Visible = true;
            colCustTypeCode.VisibleIndex = 0;
            colCustTypeCode.Width = 160;
            #endregion

            #region colCustTypeName
            colCustTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustTypeName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustTypeName.AppearanceCell.Options.UseFont = true;
            colCustTypeName.Caption = "Tên loại khách hàng";
            colCustTypeName.FieldName = "CustTypeName";
            colCustTypeName.Name = "colCustTypeName";
            colCustTypeName.Visible = true;
            colCustTypeName.VisibleIndex = 1;
            colCustTypeName.Width = 200;
            #endregion

            #region colNotes
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colNotes.AppearanceCell.Options.UseFont = true;
            colNotes.Caption = "Ghi chú";
            colNotes.FieldName = "Notes";
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 2;
            colNotes.Width = 700;
            #endregion

            #region colOrderBy
            colOrderBy = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrderBy.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colOrderBy.AppearanceCell.Options.UseFont = true;
            colOrderBy.Caption = "Thứ tự";
            colOrderBy.FieldName = "OrderBy";
            colOrderBy.Name = "colOrderBy";
            colOrderBy.Visible = true;
            colOrderBy.VisibleIndex = 3;
            colOrderBy.Width = 120;
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
            colIsActive.Width = 160;
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
            grvCustomerType.OptionsView.ShowGroupPanel = false;
            // Định dạng chữ dòng dữ liệu
            grvCustomerType.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCustomerType.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCustomerType.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCustomerType.Appearance.HeaderPanel.Options.UseFont = true;
            grvCustomerType.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCustomerType.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCustomerType.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCustomerType.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCustomerType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colID,
            colCustTypeCode,
            colCustTypeName,
            colNotes,
            colOrderBy,
            colIsActive,
            colUpdateDate,
            colUpdateBy,
            });
            #endregion
        }
        #endregion
        #endregion

        #region Form
        public frmCustomerType()
        {
            InitializeComponent();
            InitColumnGridView();
        }

        private void frmCustomerType_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
            LoadDataToCombobox();
            LoadDefault();
        }
        #endregion

        #region Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerTypeUdp frm = new frmCustomerTypeUdp();
            frm.ShowDialog();
        }
        #endregion
    }
}