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

namespace CRM_GUI.GUICategories
{
    public partial class frmCurrency : DevExpress.XtraEditors.XtraForm
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
        #region DesignControls
        
        #endregion

        #region DesignGridview
        private void InitColumnGridView()
        {

        }
        #endregion
        #endregion

        #region Form
        public frmCurrency()
        {
            InitializeComponent();            
        }

        private void frmCurrency_Load(object sender, EventArgs e)
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