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
    public class BLLSysRights
    {
        /// <summary>
        /// Cập nhật phân quyền
        /// </summary>
        /// <param name="_AccessRights">Phân quyền</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static bool SYS_RIGHTS_UpdAccessRights(string _AccessRights, out string _Message)
        {
            _Message = string.Empty;
            bool bResult = false;
            DataSet ds = new DataSet();
            try
            {
                ds = DALSysRights.SYS_RIGHTS_UpdAccessRights(_AccessRights);
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

        /// <summary>
        /// Lấy danh sách menu
        /// </summary>
        /// <param name="_UserID">ID Nhóm khách hàng</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | flase: Thất bại</returns>
        public static DataSet SYS_RIGHTS_GetAccessRights(long _UserID, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALSysRights.SYS_RIGHTS_GetAccessRights(_UserID);
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
