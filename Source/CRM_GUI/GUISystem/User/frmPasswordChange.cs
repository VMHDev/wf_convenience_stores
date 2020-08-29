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
using CRM_DTO.DTOSystem;
using CRM_BLL.BLLSystem;
using CRM_DTO.CRMFunctions;
using CRM_GUI.CRMUtility.Messages;
using CRM_DTO.CRMUtility;

namespace CRM_GUI.GUISystem.User
{
    public partial class frmPasswordChange : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmPasswordChange()
        {
            InitializeComponent();
            DesignControls();
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LoadDataToForm();
        }
        #endregion

        #region Design
        #region DesignControls
        private void DesignControls()
        {
            #region Form
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            #endregion

            #region Other Control
            txtPasswordOld.Properties.PasswordChar = '*';
            txtPasswordNew.Properties.PasswordChar = '*';
            txtPasswordReenter.Properties.PasswordChar = '*';

            txtUserName.TabStop = false;
            txtPasswordOld.TabIndex = 0;
            txtPasswordNew.TabIndex = 1;
            txtPasswordReenter.TabIndex = 2;
            btnSave.TabIndex = 3;

            txtUserName.ReadOnly = true;
            #endregion
        }
        #endregion

        #region Function
        private void LoadDataToForm()
        {
            txtUserName.Text = DTOAttributeSystem.CurrentUser.UserName;
        }

        private bool ChangePasswordClick(out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                string sUserName = txtUserName.Text.Trim();
                string sPasswordOld = txtPasswordOld.Text.Trim();
                string sPasswordNew = txtPasswordNew.Text.Trim();
                string sPasswordRe = txtPasswordReenter.Text.Trim();
                bResult = BLLSysUsers.SysUsers_ChangePassword(sUserName, sPasswordOld, sPasswordNew, sPasswordRe, out _Message);
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
        #endregion

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (ChangePasswordClick(out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.HandlerSuccess(this.Text));
                this.Close();
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
    }
}