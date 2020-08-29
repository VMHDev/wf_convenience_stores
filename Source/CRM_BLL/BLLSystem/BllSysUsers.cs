using CRM_DTO.CRMConfig;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOSystem;
using CRM_DAL.DALSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;

namespace CRM_BLL.BLLSystem
{
    public class BLLSysUsers
    {
        /// <summary>
        /// Kiểm tra dữ liệu hợp lệ
        /// </summary>
        /// <param name="_UserName">Tên đăng nhập</param>
        /// <param name="_OldPass">Mật khẩu cũ</param>
        /// <param name="_NewPass">Mật khẩu mới</param>
        /// <param name="_RePass">Nhập lại mật khẩu</param>
        /// <returns>true: Hợp lệ | flase: Không hợp lệ</returns>
        private static string IsValidChangePassword(string _UserName, string _OldPass, string _NewPass, string _RePass)
        {
            if (string.IsNullOrWhiteSpace(_UserName))
            {
                return MessagesText.FieldIsEmpty("Tên đăng nhập");
            }
            if (string.IsNullOrWhiteSpace(_OldPass))
            {
                return MessagesText.FieldIsEmpty("Mật khẩu mới");
            }
            if (string.IsNullOrWhiteSpace(_NewPass))
            {
                return MessagesText.FieldIsEmpty("Mật khẩu cũ");
            }
            if (string.IsNullOrWhiteSpace(_RePass))
            {
                return MessagesText.FieldIsEmpty("Nhập lại mật khẩu");
            }
            if (!_RePass.Equals(_NewPass))
            {
                return MessagesText.TextPasswordReenterNoneMatch;
            }
            return string.Empty;
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="_UserName">Tên đăng nhập</param>
        /// <param name="_Password">Mật khẩu</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static bool SysUsers_Login(string _UserName, string _Password, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                string sUserName = _UserName;
                string sPassword = FuncEncryption.MD5Hash(_Password);
                ds = DALSysUsers.SysUsers_Login(sUserName, sPassword);
                if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                {
                    _Message = MessagesText.TextNoData;
                    bResult = false;
                }
                else
                {
                    bResult = FuncDataset.IsExcuteStoredProcedureSuccess(ds, out _Message);
                    if(bResult)
                    {
                        long lID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                        string sUserLogin = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                        bool bIsAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAdmin"]);
                        bool bIsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                        DTOAttributeSystem.CurrentUser = new DTOSysUsers(lID, sUserLogin, string.Empty, bIsAdmin, bIsActive);
                        long lEmpID = Convert.ToInt64(ds.Tables[0].Rows[0]["EmpID"]);
                        string sEmpCode = Convert.ToString(ds.Tables[0].Rows[0]["EmpCode"]);
                        string sEmpName = Convert.ToString(ds.Tables[0].Rows[0]["EmpName"]);
                        DTOAttributeSystem.CurrentEmployee = new DTOCatEmployee(lEmpID, sEmpCode, sEmpName);
                        long lCounterID = Convert.ToInt64(ds.Tables[0].Rows[0]["CounterID"]);
                        string sCounterCode = Convert.ToString(ds.Tables[0].Rows[0]["CounterCode"]);
                        string sCounterName = Convert.ToString(ds.Tables[0].Rows[0]["CounterName"]);
                        DTOAttributeSystem.CurrentCounter = new DTOCatCounter(lCounterID, sCounterCode, sCounterName);
                        long lShopID = Convert.ToInt64(ds.Tables[0].Rows[0]["ShopID"]);
                        string sShopCode = Convert.ToString(ds.Tables[0].Rows[0]["ShopCode"]);
                        string sShopName = Convert.ToString(ds.Tables[0].Rows[0]["ShopName"]);
                        DTOAttributeSystem.CurrentShop = new DTOCatShop(lShopID, sShopCode, sShopName);
                    }
                } 
            }
            catch (Exception ex)
            {
                bResult = false;
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bResult;
        }

        /// <summary>
        /// Thay đổi mật khẩu
        /// </summary>
        /// <param name="_UserName">Tên đăng nhập</param>
        /// <param name="_OldPass">Mật khẩu cũ</param>
        /// <param name="_NewPass">Mật khẩu mới</param>
        /// <param name="_RePass">Nhập lại mật khẩu</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static bool SysUsers_ChangePassword(string _UserName, string _OldPass, string _NewPass, string _RePass, out string _Message)
        {
            _Message = string.Empty;
            bool bResult = false;
            DataSet ds = new DataSet();
            try
            {
                string sMessage = IsValidChangePassword(_UserName, _OldPass, _NewPass, _RePass);
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    _Message = sMessage;
                    return bResult;
                }
                ds = DALSysUsers.SysUsers_ChangePassword(_UserName, FuncEncryption.MD5Hash(_OldPass), FuncEncryption.MD5Hash(_NewPass));
                if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                {
                    _Message = MessagesText.TextNoData;
                    bResult = false;
                }
                else
                {
                    bResult = FuncDataset.IsExcuteStoredProcedureSuccess(ds, out _Message);
                } 
            }
            catch (Exception ex)
            {
                bResult = false;
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            finally
            {
                ds.Dispose();
            }
            return bResult;
        }
    }
}
