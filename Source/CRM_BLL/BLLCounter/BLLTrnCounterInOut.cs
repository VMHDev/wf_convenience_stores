﻿using CRM_DAL.DALCounter;
using CRM_DTO.CRMFunctions;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOCounter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BLL.BLLCounter
{
    public class BLLTrnCounterInOut
    {
        /// <summary>
        /// Danh sách giao dịch
        /// </summary>
        /// <param name="_TrnProductOut">Dữ liệu giao dịch</param>
        /// <param name="_TrnDateFrom">Từ ngày</param>
        /// <param name="_TrnDateTo">Đến ngày</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dữ liệu tìm được</returns>
        public static DataSet TrnCounterInOut_Lst(DTOTrnCounterInOut _TrnCounterInOut, string _TrnDateFrom, string _TrnDateTo, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALTrnCounterInOut.TrnCounterInOut_Lst(_TrnCounterInOut, _TrnDateFrom, _TrnDateTo);
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
        /// Lấy dữ liệu giao dịch theo ID
        /// </summary>
        /// <param name="_TrnID">ID Giao dịch</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnCounterInOut_GetWithID(long _TrnID, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALTrnCounterInOut.TrnCounterInOut_GetWithID(_TrnID);
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
        /// Lấy thông tin chi tiết giao dịch
        /// </summary>
        /// <param name="_TrnID">ID Giao dịch</param>
        /// <param name="_Message">Thông báo trả về</param> 
        /// <returns>Dữ liệu</returns>
        public static DataSet TrnCounterInOut_GetDtl(long _TrnID, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALTrnCounterInOut.TrnCounterInOut_GetDtl(_TrnID);
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
        /// <param name="_TrnCounterInOut">Object</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool TrnCounterInOut_InsUpd(DTOTrnCounterInOut _TrnCounterInOut, string _XMLDT, out long _TrnID, out string _Message)
        {
            _Message = string.Empty;
            _TrnID = -1;
            DataSet ds = new DataSet();
            bool bResult = true;
            try
            {
                ds = DALTrnCounterInOut.TrnCounterInOut_InsUpd(_TrnCounterInOut, _XMLDT);
                if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                {
                    _Message = MessagesText.TextNoData;
                    bResult = false;
                }
                else
                {
                    bResult = FuncDataset.IsExcuteStoredProcedureSuccess(ds, out _Message);
                    _TrnID = Convert.ToInt64(ds.Tables[0].Rows[0]["TrnID"]);
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
        /// Hoàn tất giao dịch
        /// </summary>
        /// <param name="_TrnIn">ID giao dịch</param>
        /// <param name="_UserUpdate">User thực hiện</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dataset chứa kết quả trả về</returns>
        public static bool TrnCounterInOut_Complete(long _TrnIn, long _UserUpdate, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = true;
            try
            {
                ds = DALTrnCounterInOut.TrnCounterInOut_Complete(_TrnIn, _UserUpdate);
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
        /// <param name="_UserUpdate">User thực hiện</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool TrnCounterInOut_Del(long _ID, long _UserUpdate, out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = true;
            try
            {
                ds = DALTrnCounterInOut.TrnCounterInOut_Del(_ID, _UserUpdate);
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
