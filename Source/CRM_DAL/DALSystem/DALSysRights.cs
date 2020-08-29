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
    public class DALSysRights
    {
        /// <summary>
        /// Cập nhật phân quyền
        /// </summary>
        /// <param name="_AccessRights">Phân quyền</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet SYS_RIGHTS_UpdAccessRights(string _AccessRights)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_RIGHTS_UpdAccessRights", _AccessRights);
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
        /// Lấy danh sách menu
        /// </summary>
        /// <param name="_GroupID">ID Nhóm khách hàng</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet SYS_RIGHTS_GetAccessRights(long _UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_RIGHTS_GetAccessRights", _UserID);
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
