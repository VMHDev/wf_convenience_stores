using CRM_BLL.BLLSystem;
using CRM_DTO.CRMUtility;
using CRM_DTO.DTOSystem;
using CRM_GUI.CRMUtility.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_GUI.CRMFunctions
{
    public class FuncGeneral
    {
        /// <summary>
        /// Lấy ID hiện tại
        /// </summary>
        /// <param name="_Table">Tên table database</param>
        /// <returns>ID hiện tại</returns>
        public static long GetCurrentID(string _Table)
        {
            long lResult = -1;
            string sMessage = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                ds = BLLSysGenCode.SysGenCode_GetCurrentID(_Table, out sMessage);
                if (string.IsNullOrWhiteSpace(sMessage))
                {
                    lResult = Convert.ToInt64(ds.Tables[0].Rows[0]["CurrentID"]);
                }
                else
                {
                    VMHMessages.ShowWarning(MessagesText.TextGenCodeFailure);
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return lResult;
        }

        /// <summary>
        /// Phát sinh mã giao dịch
        /// </summary>
        /// <param name="_Table">Tên table database</param>
        /// <param name="_CurrentID">ID hiện tại</param>
        /// <returns>Mã giao dịch</returns>
        public static string GenTransactionCode(string _Table, long _CurrentID)
        {
            string sResult = string.Empty;
            string sMessage = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                ds = BLLSysGenCode.SysGenCode_Get(_Table, _CurrentID, -1, -1, out sMessage);
                if (string.IsNullOrWhiteSpace(sMessage))
                {
                    sResult = ds.Tables[0].Rows[0]["CodeGen"].ToString();
                }
                else
                {
                    VMHMessages.ShowWarning(MessagesText.TextGenCodeFailure);
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return sResult;
        }

        /// <summary>
        /// Phát sinh mã hàng
        /// </summary>
        /// <param name="_Table">Tên table database</param>
        /// <param name="_CurrentID">ID hiện tại</param>
        /// <param name="_ProductTypeID">Loại hàng</param>
        /// <param name="_ProductGroupID">Nhóm hàng</param>
        /// <returns>Mã hàng</returns>
        public static string GenProductCode(string _Table, long _CurrentID, long _ProductTypeID, long _ProductGroupID)
        {
            string sResult = string.Empty;
            string sMessage = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                ds = BLLSysGenCode.SysGenCode_Get(_Table, _CurrentID, _ProductTypeID, _ProductGroupID, out sMessage);
                if (string.IsNullOrWhiteSpace(sMessage))
                {
                    sResult = ds.Tables[0].Rows[0]["CodeGen"].ToString();
                }
                else
                {
                    VMHMessages.ShowWarning(MessagesText.TextGenCodeFailure);
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return sResult;
        }
    }
}
