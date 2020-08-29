using CRM_DTO.CRMConfig;
using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOSystem
{
    public static class DTOAttributeSystem
    {
        #region Attribute Config
        /// <summary> Tên file cấu hình </summary>
        public static string FileConfigName { get; set; }

        /// <summary> UserName login lần trước</summary>
        public static string UserNameCache { get; set; }

        /// <summary> Thông tin cấu hình skin giao diện </summary>
        public static string SkinPaintStyle { get; set; }

        /// <summary> Tên skin giao diện </summary>
        public static string SkinName { get; set; }

        #endregion

        #region Attribute Default (Get From XML)
        /// <summary>Thuộc tính lưu trữ thông tin kết nối database</summary>
        public static clsDatabase objDatabase { get; set; }
        public static long DefaultEmpID { get; set; }
        public static long DefaultCustID { get; set; }
        #endregion

        #region Attribute Current (Get When Login)
        public static DTOCatEmployee CurrentEmployee { get; set; }
        public static DTOCatCounter CurrentCounter { get; set; }
        public static DTOSysUsers CurrentUser { get; set; }
        public static DTOCatShop CurrentShop { get; set; }
        #endregion
    }
}
