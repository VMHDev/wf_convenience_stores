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
    public class DALTrnCounterTransfer
    {
        /// <summary>
        /// Danh sách giao dịch
        /// </summary>
        /// <param name="_TrnProductOut">Dữ liệu giao dịch</param>
        /// <param name="_TrnDateFrom">Từ ngày</param>
        /// <param name="_TrnDateTo">Đến ngày</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnCounterTransfer_Lst(DTOTrnCounterTransfer _TrnCounterTransfer, string _TrnDateFrom, string _TrnDateTo)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_TRANSFER_Lst", _TrnCounterTransfer.TrnCode, _TrnDateFrom, _TrnDateTo, _TrnCounterTransfer.CounterFrom.ID, _TrnCounterTransfer.CounterTo.ID, _TrnCounterTransfer.Notes, _TrnCounterTransfer.Employee.ID, _TrnCounterTransfer.StatusCode);
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
        public static DataSet TrnCounterTransfer_GetWithID(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_TRANSFER_GetWithID", _TrnID);
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
        public static DataSet TrnCounterTransfer_GetDtl(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_TRANSFER_GetDtl", _TrnID);
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
        public static DataSet TrnCounterTransfer_InsUpd(DTOTrnCounterTransfer _TrnCounterTransfer, string _XMLDT)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_TRANSFER_InsUpd", _TrnCounterTransfer.TrnID, _TrnCounterTransfer.TrnCode, _TrnCounterTransfer.CounterFrom.ID, _TrnCounterTransfer.CounterTo.ID, _TrnCounterTransfer.Notes, _TrnCounterTransfer.Employee.ID, _TrnCounterTransfer.StatusCode, _TrnCounterTransfer.UpdateBy, _XMLDT);
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
        public static DataSet TrnCounterTransfer_Complete(long _TrnIn, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_TRANSFER_Complete", _TrnIn, _UserUpdate);
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
        public static DataSet TrnCounterTransfer_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_COUNTER_TRANSFER_Del", _ID, _UserUpdate);
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
