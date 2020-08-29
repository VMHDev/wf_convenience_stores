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
    public class DALCatCustomerGroup
    {
        /// <summary>
        /// Load dữ liệu combobox
        /// </summary>
        /// <returns>Dữ liệu</returns>
        public static DataSet LoadDataCombobox()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "CUSG", -1);
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
        public static DataSet CatCustomerGroup_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatCustomerGroup_GetAll");
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
        public static DataSet CatCustomerGroup_Search(DTOCatCustomerGroup _CatCustomerGroup)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatCustomerGroup_Search", _CatCustomerGroup.ID, _CatCustomerGroup.CustGroupCode, _CatCustomerGroup.CustGroupName);
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
        public static DataSet CatCustomerGroup_InsUpd(DTOCatCustomerGroup _CatCustomerGroup)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatCustomerGroup_InsUpd", _CatCustomerGroup.ID, _CatCustomerGroup.CustGroupCode, _CatCustomerGroup.CustGroupName);
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
        public static DataSet CatCustomerGroup_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatCustomerGroup_Del", _ID, _UserUpdate);
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
