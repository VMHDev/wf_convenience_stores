using CRM_DAL.DALCategories;
using CRM_DTO.CRMFunctions;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BLL.BLLCategories
{
    public class BLLCatUnitSell
    {
        /// <summary>
        /// Load dữ liệu combobox
        /// </summary>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet LoadDataCombobox(out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALCatUnitSell.LoadDataCombobox();
                if (dsResult == null || dsResult.Tables.Count <= 0 || dsResult.Tables[0].Rows.Count <= 0)
                {
                    _Message = MessagesText.TextNoData;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return dsResult;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet CatUnitSell_GetAll(out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALCatUnitSell.CatUnitSell_GetAll();
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
        /// Lấy dữ liệu theo mã
        /// </summary>
        /// <param name="_Code">Mã</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static DataSet CatUnitSell_GetWithCode(string _Code, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALCatUnitSell.CatUnitSell_GetWithCode(_Code);
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
        /// Tìm kiếm
        /// </summary>
        /// <param name="_CatUnitSell">Object</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dữ liệu tìm được</returns>
        public static DataSet CatUnitSell_Search(DTOCatUnitSell _CatUnitSell, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALCatUnitSell.CatUnitSell_Search(_CatUnitSell);
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
        /// <param name="_CatUnitSell">Object</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool CatUnitSell_InsUpd(DTOCatUnitSell _CatUnitSell, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = true;
            try
            {
                ds = DALCatUnitSell.CatUnitSell_InsUpd(_CatUnitSell);
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

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="_ID">ID</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool CatUnitSell_Del(long _ID, long _UserUpdate, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = true;
            try
            {
                ds = DALCatUnitSell.CatUnitSell_Del(_ID, _UserUpdate);
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
