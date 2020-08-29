using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMConfig
{
    public static class clsAttributeSystem
    {
        #region Attribute System
        /// <summary>Phiên bản build phần mềm</summary>
        public static string AssemblyVersion { get; set; }

        /// <summary>Tên phần mềm</summary>
        public static string AssemblyTitle { get; set; }
        #endregion

        #region Attribute Config
        /// <summary> Tên file cấu hình </summary>
        public static string FileConfigName { get; set; }
        /// <summary>Thuộc tính lưu trữ thông tin kết nối database</summary>
        public static clsDatabase objDatabase;

        public static string OptionRounding { get; set; }

        /// <summary>Đường dẫn xuất file Excel</summary>
        public static string PathExcelExport { get; set; }
        #endregion

        #region Attribute Default (Get From XML)
        public static string DefaultEmpID { get; set; }

        public static string DefaultCustID { get; set; }
        #endregion

        #region Attribute Current (Get When Login)
        public static string CurrentEmpID { get; set; }

        public static string CurrentTillID { get; set; }

        public static DTOSysUsers CurrentUserID { get; set; }

        public static string CurrentShopID { get; set; }        
        #endregion

        #region Attribute (Get From Database)
        public static DateTime TimeServer { get; set; }

        public static DataSet XRate { get; set; }
        #endregion
    }
}
