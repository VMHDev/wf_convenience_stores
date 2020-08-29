using CRM_DAL.CRMFunctions.Database;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOProduct;
using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DAL.DALProduct
{
    public class DALProduct
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet Product_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("OBJ_PRODUCT_GetAll");
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
        /// Lấy dữ liệu tồn kho
        /// </summary>
        /// <param name="_StallsID">ID Quầy/kho</param>
        /// <param name="_StatusCode">Mã tình trạng</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet Product_GetStock(long _StallsID, string _StatusCode)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("OBJ_PRODUCT_GetStock", _StallsID, _StatusCode);
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
        /// <param name="_TrnCode">Mã giao dịch</param>
        /// <param name="_TrnDateFrom">Từ ngày</param>
        /// <param name="_TrnDateTo">Đến ngày</param>
        /// <param name="_CustID">Mã khách hàng</param>
        /// <param name="_EmpID">Mã nhân viên</param>
        /// <param name="_StatusCode">Tình trạng</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet Product_QueryTransaction(string _TrnCode, string _TrnDateFrom, string _TrnDateTo, long _CustID, long _EmpID, string _StatusCode)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("OBJ_PRODUCT_QueryTransaction", _TrnCode, _TrnDateFrom, _TrnDateTo, _CustID, _EmpID, _StatusCode);
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
        /// Cập nhật giá
        /// </summary>
        /// <param name="_SysProductRate">Object</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet Product_UpdateRate(DTOSysProductRate _SysProductRate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("OBJ_PRODUCT_UpdateRate", _SysProductRate.ProductID, _SysProductRate.RateEstimate, _SysProductRate.DiscountPercent,
                                                                                    _SysProductRate.Discount, _SysProductRate.DiscountTotal, _SysProductRate.RateSell);
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
