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
using System.Xml;
using CRM_DTO.CRMFunctions;
using CRM_DTO.CRMConfig;
using CRM_DTO.DTOSystem;
using CRM_BLL.BLLSystem;
using CRM_GUI.CRMFunctions;

namespace CRM_GUI.GUISystem.Database
{
    public partial class frmConfigDatabase : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmConfigDatabase()
        {
            InitializeComponent();
        }

        private void frmConfigDatabase_Load(object sender, EventArgs e)
        {
            FuncSkin.LoadSkins(DTOAttributeSystem.SkinName, DTOAttributeSystem.SkinPaintStyle);
            LoadConfigDatabase();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Load thông tin cấu hình database lên form
        /// </summary>
        private void LoadConfigDatabase()
        {
            string[] sarrInfoDatabase = new string[0];
            try
            {
                sarrInfoDatabase = BLLAttributeSystem.AttributeSystem_GetInfoDatabase();
                txtServer.Text = sarrInfoDatabase[0];
                txtDatabase.Text = sarrInfoDatabase[1];
                txtUser.Text = sarrInfoDatabase[2];
                txtPassword.Text = sarrInfoDatabase[3];
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
                return;
            }
        }
        #endregion

        #region Button
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            clsDatabase objDatabase = new clsDatabase(txtServer.Text.Trim(), txtDatabase.Text.Trim(), txtUser.Text.Trim(), txtPassword.Text.Trim(), null);
            bool bSate = BLLAttributeSystem.AttributeSystem_TestConnect(objDatabase);
            if (!bSate)
            {
                VMHMessages.ShowInformation("Không kết nối được với cơ sở dữ liệu");
            }
            else
            {
                VMHMessages.ShowInformation("Kết nối thành công với cơ sở dữ liệu");                
            }
            this.Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsDatabase objDatabase = new clsDatabase(txtServer.Text.Trim(), txtDatabase.Text.Trim(), txtUser.Text.Trim(), txtPassword.Text.Trim(), null);
                bool bSate = BLLAttributeSystem.AttributeSystem_TestConnect(objDatabase);
                if (!bSate)
                {
                    VMHMessages.ShowInformation("Không kết nối được với cơ sở dữ liệu");
                    return;
                }
                if (BLLAttributeSystem.AttributeSystem_ConnectionSave(objDatabase))
                {
                    VMHMessages.ShowInformation("Lưu thông tin cấu hình thành công!");
                    this.Close();
                }
                else
                {
                    VMHMessages.ShowInformation("Lưu thông tin cấu hình thất bại!");
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}