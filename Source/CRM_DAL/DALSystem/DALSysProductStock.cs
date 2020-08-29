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
    public class DALSysProductStock
    {
        /// <summary>
        /// Thông tin tồn kho của quầy
        /// </summary>
        /// <param name="_StallsID">ID quầy/kho</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet SysProductStock_GetWithStalls(long _StallsID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_PRODUCT_STOCK_GetWithStalls", _StallsID);
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
