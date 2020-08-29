using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatUserGroup
    {
        public long ID { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string Descriptions { get; set; }
        public bool IsAdmin { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatUserGroup()
        {
            this.ID = -1;
            this.GroupCode = string.Empty;
            this.GroupName = string.Empty;
            this.Descriptions = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatUserGroup(DTOCatUserGroup _CatUserGroup)
        {
            this.ID = _CatUserGroup.ID;
            this.GroupCode = _CatUserGroup.GroupCode;
            this.GroupName = _CatUserGroup.GroupName;
            this.Descriptions = _CatUserGroup.Descriptions;
            this.IsAdmin = _CatUserGroup.IsAdmin;
            this.OrderBy = _CatUserGroup.OrderBy;
            this.IsActive = _CatUserGroup.IsActive;
            this.UpdateDate = _CatUserGroup.UpdateDate;
            this.UpdateBy = _CatUserGroup.UpdateBy;
            this.IsDelete = _CatUserGroup.IsDelete;
        }

        public DTOCatUserGroup(long _ID, string _GroupCode, string _GroupName, string _Descriptions, bool _IsAdmin, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.GroupCode = _GroupCode;
            this.GroupName = _GroupName;
            this.Descriptions = _Descriptions;
            this.IsAdmin = _IsAdmin;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
