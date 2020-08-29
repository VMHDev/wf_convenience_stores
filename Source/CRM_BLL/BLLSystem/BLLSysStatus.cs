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
    public class BLLSysStatus
    {
        /// <summary>
        /// Load dữ liệu combobox
        /// </summary>
        /// <param name="_StatusObject">Đối tượng/Giao dịch muốn lấy tình trạng</param>
        /// <param name="_Message">Thông báo trả về</param>
        /// <returns>Dữ liệu</returns>
        public static DataSet LoadDataCombobox(string _StatusObject, out string _Message)
        {
            _Message = string.Empty;
            DataSet dsResult = new DataSet();
            try
            {
                dsResult = DALSysStatus.LoadDataCombobox(_StatusObject);
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
