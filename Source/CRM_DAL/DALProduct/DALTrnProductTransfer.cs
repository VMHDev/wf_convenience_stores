using CRM_DAL.CRMFunctions.Database;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOProduct;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DAL.DALProduct
{
    public class DALTrnProductTransfer
    {
        /// <summary>
        /// Danh sách giao dịch
        /// </summary>
        /// <param name="_TrnProductTransfer">Dữ liệu giao dịch</param>
        /// <param name="_TrnDateFrom">Từ ngày</param>
        /// <param name="_TrnDateTo">Đến ngày</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnProductTransfer_Lst(DTOTrnProductTransfer _TrnProductTransfer, string _TrnDateFrom, string _TrnDateTo)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_TRANSFER_Lst", _TrnProductTransfer.TrnCode, _TrnDateFrom, _TrnDateTo, _TrnProductTransfer.StallsFrom.ID, _TrnProductTransfer.StallsTo.ID, _TrnProductTransfer.Notes, _TrnProductTransfer.Employee.ID, _TrnProductTransfer.StatusCode);
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
        public static DataSet TrnProductTransfer_GetWithID(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_TRANSFER_GetWithID", _TrnID);
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
        public static DataSet TrnProductTransfer_GetDtl(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_TRANSFER_GetDtl", _TrnID);
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
        /// <param name="_TrnProductTransfer">Dữ liệu giao dịch</param>
        /// <param name="_XMLDT">XML chứa chi tiết giao dịch</param>
        /// <returns>Dataset chứa kết quả trả về</returns>
        public static DataSet TrnProductTransfer_InsUpd(DTOTrnProductTransfer _TrnProductTransfer, string _XMLDT)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_TRANSFER_InsUpd", _TrnProductTransfer.TrnID, _TrnProductTransfer.TrnCode, _TrnProductTransfer.StallsFrom.ID, _TrnProductTransfer.StallsTo.ID, _TrnProductTransfer.Notes, _TrnProductTransfer.Employee.ID, _TrnProductTransfer.StatusCode, _TrnProductTransfer.UpdateBy, _XMLDT);
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
        public static DataSet TrnProductTransfer_Complete(long _TrnIn, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_TRANSFER_Complete", _TrnIn, _UserUpdate);
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
        public static DataSet TrnProductTransfer_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_TRANSFER_Del", _ID, _UserUpdate);
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
