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
    public class DALSysStatus
    {
        /// <summary>
        /// Load dữ liệu combobox
        /// </summary>
        /// <param name="_StatusObject">Đối tượng/Giao dịch muốn lấy tình trạng</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet LoadDataCombobox(string _StatusObject)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = FuncDatabaseExecute.ExecuteDatasetSP("LoadDataCombobox", _StatusObject, -1);
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
