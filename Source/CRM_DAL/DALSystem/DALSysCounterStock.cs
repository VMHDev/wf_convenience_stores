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
    public class DALSysCounterStock
    {
        /// <summary>
        /// Thông tin tồn kho của quầy thu ngân
        /// </summary>
        /// <param name="_StallsID">ID quầy thu ngân</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet SysCounterStock_GetWithCounter(long _CounterID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_COUNTER_STOCK_GetWithCounter", _CounterID);
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
