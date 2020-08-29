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
    public class DALTrnCounterInOut
    {
        /// <summary>
        /// Danh sách giao dịch
        /// </summary>
        /// <param name="_TrnProductOut">Dữ liệu giao dịch</param>
        /// <param name="_TrnDateFrom">Từ ngày</param>
        /// <param name="_TrnDateTo">Đến ngày</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnCounterInOut_Lst(DTOTrnCounterInOut _TrnCounterInOut, string _TrnDateFrom, string _TrnDateTo)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_INOUT_Lst", _TrnCounterInOut.TrnCode, _TrnDateFrom, _TrnDateTo, _TrnCounterInOut.Notes, _TrnCounterInOut.Employee.ID, _TrnCounterInOut.StatusCode);
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
        /// Lấy dữ liệu giao dịch theo ID
        /// </summary>
        /// <param name="_TrnID">ID Giao dịch</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnCounterInOut_GetWithID(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_INOUT_GetWithID", _TrnID);
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
        /// Lấy thông tin chi tiết giao dịch
        /// </summary>
        /// <param name="_TrnID">ID Giao dịch</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnCounterInOut_GetDtl(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_INOUT_GetDtl", _TrnID);
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
        /// Cập nhật giao dịch
        /// </summary>
        /// <param name="_TrnProductOut">Dữ liệu giao dịch</param>
        /// <param name="_XMLDT">XML chứa chi tiết giao dịch</param>
        /// <returns>Dataset chứa kết quả trả về</returns>
        public static DataSet TrnCounterInOut_InsUpd(DTOTrnCounterInOut _TrnCounterInOut, string _XMLDT)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_INOUT_InsUpd", _TrnCounterInOut.TrnID, _TrnCounterInOut.TrnCode, _TrnCounterInOut.Counter.ID, _TrnCounterInOut.Notes, _TrnCounterInOut.Employee.ID, _TrnCounterInOut.StatusCode, _TrnCounterInOut.UpdateBy, _XMLDT);
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
        /// Hoàn tất giao dịch
        /// </summary>
        /// <param name="_TrnIn">ID giao dịch</param>
        /// <param name="_UserUpdate">User thực hiện</param>
        /// <returns>Dataset chứa kết quả trả về</returns>
        public static DataSet TrnCounterInOut_Complete(long _TrnIn, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_INOUT_Complete", _TrnIn, _UserUpdate);
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
        /// Xóa
        /// </summary>
        /// <param name="_ID">ID</param>
        /// <param name="_UserUpdate">User thực hiện</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet TrnCounterInOut_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_INOUT_Del", _ID, _UserUpdate);
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
