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
    public partial class frmProductTypeUdp : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmProductTypeUdp()
        {
            InitializeComponent();
        }
        #endregion

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}