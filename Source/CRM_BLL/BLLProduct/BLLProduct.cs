using CRM_DAL.DALProduct;
using CRM_DTO.CRMFunctions;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BLL.BLLProduct
{
    public class BLLProduct
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet Product_GetAll(out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALProduct.Product_GetAll();
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

        /// <summary>
        /// Lấy dữ liệu tồn kho
        /// </summary>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet Product_GetStock(long _StallsID, string _StatusCode, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALProduct.Product_GetStock(_StallsID, _StatusCode);
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

        /// <summary>
        /// Danh sách giao dịch
        /// </summary>
        /// <param name="_TrnCode">Mã giao dịch</param>
        /// <param name="_TrnDateFrom">Từ ngày</param>
        /// <param name="_TrnDateTo">Đến ngày</param>
        /// <param name="_CustID">Mã khách hàng</param>
        /// <param name="_EmpID">Mã nhân viên</param>
        /// <param name="_StatusCode">Tình trạng</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet Product_QueryTransaction(string _TrnCode, string _TrnDateFrom, string _TrnDateTo, long _CustID, long _EmpID, string _StatusCode, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALProduct.Product_QueryTransaction(_TrnCode, _TrnDateFrom, _TrnDateTo, _CustID, _EmpID, _StatusCode);
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

        /// <summary>
        /// Thêm/Sửa
        /// </summary>
        /// <param name="_SysProductRate">Object</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool Product_UpdateRate(DTOSysProductRate _SysProductRate, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = true;
            try
            {
                ds = DALProduct.Product_UpdateRate(_SysProductRate);
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
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            finally
            {
                ds.Dispose();
            }
            return bResult;
        }
    }
}
