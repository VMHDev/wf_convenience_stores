using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatEmployee
    {
        public long ID { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public DTOSysUsers User { get; set; }
        public DTOCatShop Shop { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatEmployee()
        {
            this.ID = -1;
            this.EmpCode = string.Empty;
            this.EmpName = string.Empty;
            this.User = new DTOSysUsers();
            this.Shop = new DTOCatShop();
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatEmployee(DTOCatEmployee _CatEmployee)
        {
            this.ID = _CatEmployee.ID;
            this.EmpCode = _CatEmployee.EmpCode;
            this.EmpName = _CatEmployee.EmpName;
            this.User = _CatEmployee.User;
            this.Shop = _CatEmployee.Shop;
            this.OrderBy = _CatEmployee.OrderBy;
            this.IsActive = _CatEmployee.IsActive;
            this.UpdateDate = _CatEmployee.UpdateDate;
            this.UpdateBy = _CatEmployee.UpdateBy;
            this.IsDelete = _CatEmployee.IsDelete;
        }

        public DTOCatEmployee(long _ID, string _EmpCode, string _EmpName)
        {
            this.ID = _ID;
            this.EmpCode = _EmpCode;
            this.EmpName = _EmpName;
            this.User = new DTOSysUsers();
            this.Shop = new DTOCatShop();
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatEmployee(long _ID, string _EmpCode, string _EmpName, DTOSysUsers _User, DTOCatShop _Shop, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.EmpCode = _EmpCode;
            this.EmpName = _EmpName;
            this.User = _User;
            this.Shop = _Shop;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
