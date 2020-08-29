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
    public class BLLSysCounterStock
    {
        /// <summary>
        /// Thông tin tồn kho của quầy
        /// </summary>
        /// <param name="_StallsID">ID quầy/kho</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dữ liệu tìm được</returns>
        public static DataSet SysCounterStock_GetWithCounter(long _StallsID, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALSysCounterStock.SysCounterStock_GetWithCounter(_StallsID);
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
