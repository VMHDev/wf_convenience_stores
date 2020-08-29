using CRM_DAL.CRMFunctions.Database;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOCounter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DAL.DALCounter
{
    public class DALCounterOpenClose
    {
        /// <summary>
        /// Đóng mở quầy
        /// </summary>
        /// <param name="_IDCounter"></param>
        /// <param name="_IDEmpID"></param>
        /// <param name="_Types"></param>
        /// <returns></returns>
        public static DataSet CatCounter_OpenClose(long _IDCounter, long _IDEmpID, bool _Types)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_COUNTER_OpenClose", _IDCounter, _IDEmpID, _Types);
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
        /// Truy vấn lịch sử đóng mở quầy
        /// </summary>
        /// <param name="_CatCounter">Object</param>
        /// <returns>Dữ liệu tìm được</returns>
        public static DataSet CatCounterLog_Search(DTOCatCounterLog _CatCounterLog)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_COUNTER_LOG_Search", _CatCounterLog.Counter, _CatCounterLog.Employee, _CatCounterLog.StatusCode);
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
        /// Lấy thông tin trạng thái quầy thu ngân
        /// </summary>
        /// <param name="_CounterID"></param>
        /// <returns></returns>
        public static DataSet CatCounterLog_GetWithCounter(long _CounterID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_COUNTER_LOG_GetWithCounter", _CounterID);
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
