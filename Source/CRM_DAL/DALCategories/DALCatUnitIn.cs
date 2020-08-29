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
    public class DALCatUnitIn
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
                ds = FuncDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "UNTI", -1);
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
        public static DataSet CatUnitIn_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatUnitIn_GetAll");
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
        public static DataSet CatUnitIn_Search(DTOCatUnitIn _CatUnitIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatUnitIn_Search", _CatUnitIn.ID, _CatUnitIn.UnitInCode, _CatUnitIn.UnitInDesc);
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
        public static DataSet CatUnitIn_InsUpd(DTOCatUnitIn _CatUnitIn)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatUnitIn_InsUpd", _CatUnitIn.ID, _CatUnitIn.UnitInCode, _CatUnitIn.UnitInDesc);
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
        public static DataSet CatUnitIn_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CatUnitIn_Del", _ID, _UserUpdate);
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
