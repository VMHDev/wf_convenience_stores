using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using CRM_GUI.GUISystem.User;
using CRM_BLL.BLLSystem;
using CRM_GUI.GUISystem.Database;
using CRM_GUI.CRMUtility.Messages;
using CRM_DTO.DTOSystem;
using CRM_GUI.GUIProduct;

namespace CRM_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                BonusSkins.Register();
                SkinManager.EnableFormSkins();

                InitAttributeSystem();
                StartProject();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);                
            }
            finally
            {
                #region Đóng kết nối CSDL
                if (DTOAttributeSystem.objDatabase != null)
                {
                    Exception exException;
                    DTOAttributeSystem.objDatabase.DisconnectDatabase(out exException);
                }
                #endregion
                Application.Exit();
            }
        }

        #region Function
        private static void InitAttributeSystem()
        {
            DTOAttributeSystem.FileConfigName = "config.xml"; // File config.xml phải được đặt trong bin/Release hay bin/Debug
            string[] sarrConfigUser = BLLAttributeSystem.AttributeSystem_ConfigUserGetInfo();  // Hàm này gọi sau khi DTOAttributeSystem.FileConfigName có giá trị
            DTOAttributeSystem.UserNameCache = sarrConfigUser[0] == null ? string.Empty : sarrConfigUser[0].ToString();
            DTOAttributeSystem.SkinPaintStyle = sarrConfigUser[1] == null ? string.Empty: sarrConfigUser[1].ToString();
            DTOAttributeSystem.SkinName = sarrConfigUser[2] == null ? string.Empty : sarrConfigUser[2].ToString();
            string[] sarrConfigAttributeSystem = BLLAttributeSystem.AttributeSystem_ConfigAttributeSystemGetInfo();  // Hàm này gọi sau khi DTOAttributeSystem.FileConfigName có giá trị
            DTOAttributeSystem.DefaultEmpID = sarrConfigAttributeSystem[0] == null ? -1 : Convert.ToInt64(sarrConfigAttributeSystem[0]);
            DTOAttributeSystem.DefaultCustID = sarrConfigAttributeSystem[1] == null ? -1 : Convert.ToInt64(sarrConfigAttributeSystem[1]);
        }
        private static bool IsConnectDatabaseSuccess()
        {
            bool bResult = false;
            try
            {
                BLLAttributeSystem.AttributeSystem_DatabaseConnect();
                if (DTOAttributeSystem.objDatabase == null)
                {
                    if (VMHMessages.ShowConfirm("Không kết nối được cơ sở dữ liệu! Vui lòng thiết lập!") == DialogResult.OK)
                    {
                        frmConfigDatabase frm = new frmConfigDatabase();
                        DialogResult dlResult = frm.ShowDialog();
                    }
                    else
                    {
                        bResult = false;
                    }
                }
            }
            catch (Exception ex)
            {
                bResult = false;
                VMHMessages.ShowErrorException(ex);
            }
            return bResult;
        }
        private static void StartProject()
        {
            try
            {
                BLLAttributeSystem.AttributeSystem_DatabaseConnect();
                if (DTOAttributeSystem.objDatabase == null)
                {
                    if(VMHMessages.ShowConfirm("Không kết nối được cơ sở dữ liệu! Vui lòng thiết lập!") == DialogResult.OK)
                    {
                        frmConfigDatabase frm = new frmConfigDatabase();
                        frm.ShowDialog();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.ShowDialog();
                    if (frmLogin.LoginSuccess)
                    {
                        Application.Run(new frmProductSell());
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);                
            }
        }
        #endregion
    }
}
