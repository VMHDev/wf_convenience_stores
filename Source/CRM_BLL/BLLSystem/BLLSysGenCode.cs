using CRM_DAL.DALSystem;
using CRM_DTO.CRMFunctions;
using CRM_DTO.CRMUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BLL.BLLSystem
{
    public class BLLSysGenCode
    {

        public static DataSet SysGenCode_GetCurrentID(string _TableName, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALSysGenCode.SysGenCode_GetCurrentID(_TableName);
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
        /// Phát sinh mã
        /// </summary>
        /// <param name="_TableName">Tên bảng trong database</param>
        /// <param name="_ProductTypeID">ID Loại hàng</param>
        /// <param name="_ProductGroupID">ID Nhóm hàng</param>
        /// <returns>Mã phát sinh</returns>
        public static DataSet SysGenCode_Get(string _TableName, long _CurrentID, long _ProductTypeID, long _ProductGroupID, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALSysGenCode.SysGenCode_Get(_TableName, _CurrentID, _ProductTypeID, _ProductGroupID);
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
    }
}
