using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMFunctions
{
    public static class FuncException
    {
        public static string GetDetailsException(Exception _Ex, bool _IsWriteLog = false)
        {
            string sException = string.Empty;
            try
            {
                StackTrace stackTrace = new StackTrace();
                string sNameMethod = stackTrace.GetFrame(1).GetMethod().Name;
                string sNameFile = stackTrace.GetFrame(1).GetMethod().ReflectedType.Name;
                sException = "Lỗi hàm " + sNameFile + "." + sNameMethod + ": " + _Ex.Message + "\n";
            }
            catch (Exception exc)
            {
                sException = "Lỗi hàm CRM_BLL.CRMFunctions.FuncException.GetDetailsException().\nChi tiết: " + exc.Message;
            }
            return sException;
        }
    }
}
