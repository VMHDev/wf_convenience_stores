using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatProductGroup
    {
        public long ID { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public string Descriptions { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatProductGroup()
        {
            this.ID = -1;
            this.ProductGroupCode = string.Empty;
            this.ProductGroupName = string.Empty;
            this.Descriptions = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatProductGroup(DTOCatProductGroup _CatProductGroup)
        {
            this.ID = _CatProductGroup.ID;
            this.ProductGroupCode = _CatProductGroup.ProductGroupCode;
            this.ProductGroupName = _CatProductGroup.ProductGroupName;
            this.Descriptions = _CatProductGroup.Descriptions;
            this.OrderBy = _CatProductGroup.OrderBy;
            this.IsActive = _CatProductGroup.IsActive;
            this.UpdateDate = _CatProductGroup.UpdateDate;
            this.UpdateBy = _CatProductGroup.UpdateBy;
            this.IsDelete = _CatProductGroup.IsDelete;
        }

        public DTOCatProductGroup(long _ID, string _ProductGroupCode, string _ProductGroupName, string _Descriptions, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.ProductGroupCode = _ProductGroupCode;
            this.ProductGroupName = _ProductGroupName;
            this.Descriptions = _Descriptions;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
