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
    public class DALTrnProductSell
    {
        /// <summary>
        /// Lấy danh sách danh mục hàng để bán
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet TrnProductSell_GetCatProduct()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_GetCatProduct");
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
        /// Lấy thông tin hàng
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet TrnProductSell_GetByCodeForSell(string _ProductCode)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("OBJ_PRODUCT_GetByCodeForSell", _ProductCode);
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
        /// Danh sách giao dịch
        /// </summary>
        /// <param name="_TrnProductSell">Dữ liệu giao dịch</param>
        /// <param name="_TrnDateFrom">Từ ngày</param>
        /// <param name="_TrnDateTo">Đến ngày</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnProductSell_Lst(DTOTrnProductSell _TrnProductSell, string _TrnDateFrom, string _TrnDateTo)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_Lst", _TrnProductSell.TrnCode, _TrnDateFrom, _TrnDateTo, _TrnProductSell.Customer.ID, _TrnProductSell.Notes, _TrnProductSell.Employee.ID, _TrnProductSell.StatusCode);
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
        public static DataSet TrnProductSell_GetWithID(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_GetWithID", _TrnID);
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
        public static DataSet TrnProductSell_GetDtl(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_GetDtl", _TrnID);
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
        /// <param name="_TrnProductSell">Dữ liệu giao dịch</param>
        /// <param name="_XMLDT">XML chứa chi tiết giao dịch</param>
        /// <returns>Dataset chứa kết quả trả về</returns>
        public static DataSet TrnProductSell_InsUpd(DTOTrnProductSell _TrnProductSell, string _XMLDT)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_InsUpd", _TrnProductSell.TrnID, _TrnProductSell.TrnCode, _TrnProductSell.Customer.ID, _TrnProductSell.Counter.ID, _TrnProductSell.DiscountTrn, _TrnProductSell.DiscountTotal, _TrnProductSell.AmountTotal, _TrnProductSell.AmountPay, _TrnProductSell.UnitPayment.ID, _TrnProductSell.Notes, _TrnProductSell.Employee.ID, _TrnProductSell.StatusCode, _TrnProductSell.UpdateBy, _XMLDT);
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
        public static DataSet TrnProductSell_Complete(long _TrnIn, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_Complete", _TrnIn, _UserUpdate);
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
        public static DataSet TrnProductSell_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_Del", _ID, _UserUpdate);
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
        /// Lấy dữ liệu In bill
        /// </summary>
        /// <param name="_TrnID">ID Giao dịch</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnProductSell_PrintBill(long _TrnID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("TRN_PRODUCT_SELL_PrintBill", _TrnID);
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
