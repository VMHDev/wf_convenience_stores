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
    public class DALCatEmployee
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
                ds = FuncDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "EMP", _ShopID);
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
        public static DataSet CatEmployee_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatEmployee_GetAll");
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
        public static DataSet CatEmployee_Search(DTOCatEmployee _CatEmployee)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatEmployee_Search", _CatEmployee.ID, _CatEmployee.EmpCode, _CatEmployee.EmpName);
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
        public static DataSet CatEmployee_InsUpd(DTOCatEmployee _CatEmployee)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatEmployee_InsUpd", _CatEmployee.ID, _CatEmployee.EmpCode, _CatEmployee.EmpName);
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
        public static DataSet CatEmployee_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatEmployee_Del", _ID, _UserUpdate);
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
