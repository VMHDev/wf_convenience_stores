using System;
using System.Data;
using CRM_GUI.CRMUtility.Messages;
using CRM_DTO.CRMFunctions;
using CRM_BLL.BLLSystem;
using CRM_GUI.CRMFunctions;
using CRM_DTO.DTOSystem;

namespace CRM_GUI.GUISystem.User
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public bool LoginSuccess { get; set; }

        #region Form
        public frmLogin()
        {
            InitializeComponent();
            LoginSuccess = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FuncSkin.LoadSkins(DTOAttributeSystem.SkinName, DTOAttributeSystem.SkinPaintStyle);
        }
        #endregion

        #region Functions
        private bool Login(out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                string sUserName = txtUserName.Text.Trim();
                string sPassword = txtPassword.Text.Trim();
                bResult = BLLSysUsers.SysUsers_Login(sUserName, sPassword, out _Message);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return bResult;
        }
        #endregion

        #region Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (Login(out sMessage))
            {
                LoginSuccess = true;
                this.Close();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
                LoginSuccess = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}