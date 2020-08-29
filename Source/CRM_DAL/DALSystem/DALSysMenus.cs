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
    public class DALSysMenus
    {
 
        /// <summary>
        /// Lấy danh sách menu
        /// </summary>
        /// <param name="_GroupID">ID Nhóm khách hàng</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet SYS_MENUS_GetAccessRights(long _GroupID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_MENUS_GetAccessRights", _GroupID);
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
