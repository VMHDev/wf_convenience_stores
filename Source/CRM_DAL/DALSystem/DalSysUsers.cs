using CRM_DAL.CRMFunctions.Database;
using CRM_DTO.CRMFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DAL.DALSystem
{
    public class DALSysUsers
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="_UserName">Tên đăng nhập</param>
        /// <param name="_Password">Mật khẩu</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet SysUsers_Login(string _UserName, string _Password)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_USERS_Login", _UserName, _Password);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        /// <summary>
        /// Thay đổi mật khẩu
        /// </summary>
        /// <param name="_UserName">Tên đăng nhập</param>
        /// <param name="_OldPass">Mật khẩu cũ</param>
        /// <param name="_NewPass">Mật khẩu mới</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet SysUsers_ChangePassword(string _UserName, string _OldPass, string _NewPass)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_USERS_ChangePassword", _UserName, _OldPass, _NewPass);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
    }
}
