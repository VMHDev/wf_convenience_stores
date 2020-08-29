using CRM_DAL.CRMFunctions.Database;
using CRM_DTO.CRMFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DAL.DALSystem
{
    public class DALSysGenCode
    {
        /// <summary>
        /// Lấy ID hiện tại của table
        /// </summary>
        /// <param name="_TableName">Tên bảng trong database</param>
        /// <returns>ID hiện tại</returns>
        public static DataSet SysGenCode_GetCurrentID(string _TableName)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_GENCODE_GetCurrentID", _TableName);
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
        /// Phát sinh mã
        /// </summary>
        /// <param name="_TableName">Tên bảng trong database</param>
        /// <param name="__CurrentID">ID Hiện tại của table</param>
        /// <param name="_ProductTypeID">ID Loại hàng</param>
        /// <param name="_ProductGroupID">ID Nhóm hàng</param>
        /// <returns>Mã phát sinh</returns>
        public static DataSet SysGenCode_Get(string _TableName, long _CurrentID, long _ProductTypeID, long _ProductGroupID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("SYS_GENCODE_Get", _TableName, _CurrentID, _ProductTypeID, _ProductGroupID);
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

