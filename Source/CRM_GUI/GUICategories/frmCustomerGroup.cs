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
    public partial class frmCustomerGroup : DevExpress.XtraEditors.XtraForm
    {
        #region Functions
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
            tblInit.Columns.Add("ID", typeof(Int64));
            tblInit.Columns.Add("CustGroupCode", typeof(string));
            tblInit.Columns.Add("CustGroupName", typeof(string));
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
            grcCustomerGroup.DataSource = InitDataSourceGrid();
        }
        #endregion

        #region Design
        #region DesignControls

        #endregion

        #region DesignGridview
        public GridColumn colID { get; set; }
        public GridColumn colCustGroupCode { get; set; }
        public GridColumn colCustGroupName { get; set; }
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

            #region colCustGroupCode
            colCustGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustGroupCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustGroupCode.AppearanceCell.Options.UseFont = true;
            colCustGroupCode.Caption = "Mã nhóm khách hàng";
            colCustGroupCode.FieldName = "CustGroupCode";
            colCustGroupCode.Name = "colCustGroupCode";
            colCustGroupCode.Visible = true;
            colCustGroupCode.VisibleIndex = 0;
            colCustGroupCode.Width = 180;
            #endregion

            #region colCustGroupName
            colCustGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustGroupName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colCustGroupName.AppearanceCell.Options.UseFont = true;
            colCustGroupName.Caption = "Tên nhóm khách hàng";
            colCustGroupName.FieldName = "CustGroupName";
            colCustGroupName.Name = "colCustGroupName";
            colCustGroupName.Visible = true;
            colCustGroupName.VisibleIndex = 1;
            colCustGroupName.Width = 200;
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
            grvCustomerGroup.OptionsView.ShowGroupPanel = false;
            // Định dạng chữ dòng dữ liệu
            grvCustomerGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            grvCustomerGroup.Appearance.Row.Options.UseFont = true;
            // Định dạng chữ tiêu đề cột
            grvCustomerGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            grvCustomerGroup.Appearance.HeaderPanel.Options.UseFont = true;
            grvCustomerGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvCustomerGroup.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCustomerGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // Kích thước của các cột được xác định theo thông số .Width của từng cột. Nếu tổng kích thước cột vượt quá kích thước lưới thì sẽ xuất hiện thanh cuộn scrollbar
            //grvCustomerGroup.OptionsView.ColumnAutoWidth = false;
            // Thêm các cột vào gridview
            grvCustomerGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colID,
            colCustGroupCode,
            colCustGroupName,
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
        public frmCustomerGroup()
        {
            InitializeComponent();
            InitColumnGridView();
        }

        private void frmCustomerGroup_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
            LoadDataToCombobox();
            LoadDefault();
        }
        #endregion

        #region Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerGroupUdp frm = new frmCustomerGroupUdp();
            frm.ShowDialog();
        }
        #endregion
    }
}