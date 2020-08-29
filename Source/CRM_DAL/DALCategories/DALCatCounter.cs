using CRM_DAL.CRMFunctions.Database;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DAL.DALCategories
{
    public class DALCatCounter
    {
        /// <summary>
        /// Load dữ liệu combobox
        /// </summary>
        /// <returns>Dữ liệu</returns>
        public static DataSet LoadDataCombobox(long _ShopID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "CNT", _ShopID);
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
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet CatCounter_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_COUNTER_GetAll");
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
        /// Tìm kiếm
        /// </summary>
        /// <param name="_CatCounter">Object</param>
        /// <returns>Dữ liệu tìm được</returns>
        public static DataSet CatCounter_Search(DTOCatCounter _CatCounter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_COUNTER_Search", _CatCounter.ID, _CatCounter.CounterCode, _CatCounter.CounterName, _CatCounter.Shop, _CatCounter.OrderBy);
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
        /// Thêm/Sửa
        /// </summary>
        /// <param name="_CatCounter">Object</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet CatCounter_InsUpd(DTOCatCounter _CatCounter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_COUNTER_InsUpd", _CatCounter.ID, _CatCounter.CounterCode, _CatCounter.CounterName, _CatCounter.StatusCode, _CatCounter.Shop, _CatCounter.OrderBy, _CatCounter.IsActive, _CatCounter.UpdateBy);
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
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet CatCounter_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_COUNTER_Del", _ID, _UserUpdate);
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
