using CRM_DTO.CRMUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMFunctions
{
    public class FuncDataset
    {
        public static bool IsExcuteStoredProcedureSuccess(DataSet _DsResult, out string _Message)
        {
            bool bResult = false;
            _Message = string.Empty;
            if (_DsResult != null && _DsResult.Tables.Count > 0 && _DsResult.Tables[0].Rows.Count > 0 && _DsResult.Tables[0].Rows[0]["Result"] != null && _DsResult.Tables[0].Rows[0]["MsgProcedure"] != null)
            {
                if(_DsResult.Tables[0].Rows[0]["Result"].Equals(1))
                {
                    _Message = _DsResult.Tables[0].Rows[0]["MsgProcedure"].ToString();
                    bResult = true;
                }
                else
                {
                    _Message = _DsResult.Tables[0].Rows[0]["MsgProcedure"].ToString();
                    bResult = false;
                }
            }
            else
            {
                _Message = MessagesText.TextExcuteProcedureFailure;
            }
            return bResult;
        }
    }
}
