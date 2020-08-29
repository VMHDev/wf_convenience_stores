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
    public partial class frmEmployee : DevExpress.XtraEditors.XtraForm
    {
        #region Functions
        private DataTable InitDataSourceGrid()
        {
            DataTable tblInit = new DataTable("Init");
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

        }
        #endregion

        #region Design
        public GridColumn colID { get; set; }
        public GridColumn colEmpCode { get; set; }
        public GridColumn colEmpName { get; set; }
        public GridColumn colUserID { get; set; }
        public GridColumn colShopID { get; set; }
        public GridColumn colOrderBy { get; set; }
        public GridColumn colIsActive { get; set; }
        public GridColumn colUpdateDate { get; set; }
        public GridColumn colUpdateBy { get; set; }
        public GridColumn colIsDelete { get; set; }

        #region DesignControls
        
        #endregion

        #region DesignGridview
        private void InitColumnGridView()
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

            #region colEmpCode
            colEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmpCode.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colEmpCode.AppearanceCell.Options.UseFont = true;
            colEmpCode.Caption = "Mã nhân viên";
            colEmpCode.FieldName = "EmpCode";
            colEmpCode.Name = "colEmpCode";
            colEmpCode.Visible = true;
            colEmpCode.VisibleIndex = 0;
            colEmpCode.Width = 120;
            #endregion

            #region colEmpName
            colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmpName.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colEmpName.AppearanceCell.Options.UseFont = true;
            colEmpName.Caption = "Nhân viên";
            colEmpName.FieldName = "EmpName";
            colEmpName.Name = "colEmpName";
            colEmpName.Visible = true;
            colEmpName.VisibleIndex = 1;
            colEmpName.Width = 150;
            #endregion

            #region colUserID
            colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            colUserID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F);
            colUserID.AppearanceCell.Options.UseFont = true;
            colUserID.Caption = "ID khách hàng";
            colUserID.FieldName = "ID";
            colUserID.Name = "colUserID";
            colUserID.Visible = false;
            //colUserID.VisibleIndex = -1;
            colUserID.Width = 80;
            #endregion
        }
        #endregion
        #endregion

        #region Form
        public frmEmployee()
        {
            InitializeComponent();            
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
            LoadDataToCombobox();
            LoadDefault();
        }
        #endregion

        #region Button

        #endregion
    }
}