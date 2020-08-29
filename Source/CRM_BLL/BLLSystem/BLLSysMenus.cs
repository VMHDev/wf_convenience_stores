using CRM_DAL.DALSystem;
using CRM_DTO.CRMFunctions;
using CRM_DTO.CRMUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BLL.BLLSystem
{
    public class BLLSysMenus
    {
        /// <summary>
        /// Lấy danh sách menu
        /// </summary>
        /// <param name="_GroupID">ID Nhóm khách hàng</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet SYS_MENUS_GetAccessRights(long _GroupID, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALSysMenus.SYS_MENUS_GetAccessRights(_GroupID);
                if (dsResult == null || dsResult.Tables.Count <= 0 || dsResult.Tables[0].Rows.Count <= 0)
                {
                    _Message = MessagesText.TextNoData;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            finally
            {
                dsResult.Dispose();
            }
            return dsResult;
        }
    }
}
