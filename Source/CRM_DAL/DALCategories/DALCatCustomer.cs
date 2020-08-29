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
    public class DALCatCustomer
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
                ds = FuncDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", "CUS", -1);
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
        public static DataSet CatCustomer_GetAll()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_CUSTOMER_GetAll");
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
        public static DataSet CatCustomer_Search(DTOCatCustomer _CatCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_CUSTOMER_Search", _CatCustomer.ID, _CatCustomer.CustCode, _CatCustomer.CustName,
                                                                                _CatCustomer.CustAddress, _CatCustomer.Phone, _CatCustomer.Notes,
                                                                                _CatCustomer.IdentificationCard, _CatCustomer.BirthDate, _CatCustomer.Gender,
                                                                                _CatCustomer.Email, _CatCustomer.CustGroup, _CatCustomer.CustType,
                                                                                _CatCustomer.OrderBy, _CatCustomer.IsActive);
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
        public static DataSet CatCustomer_InsUpd(DTOCatCustomer _CatCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_CUSTOMER_InsUpd", _CatCustomer.ID, _CatCustomer.CustCode, _CatCustomer.CustName, 
                                                                                _CatCustomer.CustAddress, _CatCustomer.Phone, _CatCustomer.Notes, 
                                                                                _CatCustomer.IdentificationCard, _CatCustomer.BirthDate, _CatCustomer.Gender, 
                                                                                _CatCustomer.Email, _CatCustomer.CustGroup, _CatCustomer.CustType, 
                                                                                _CatCustomer.OrderBy, _CatCustomer.IsActive, _CatCustomer.UpdateBy);
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
        public static DataSet CatCustomer_Del(long _ID, long _UserUpdate)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("CAT_CUSTOMER_Del", _ID, _UserUpdate);
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
