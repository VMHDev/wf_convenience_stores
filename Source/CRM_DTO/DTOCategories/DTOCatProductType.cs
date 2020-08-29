using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatProductType
    {
        public long ID { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductTypeName { get; set; }
        public string Descriptions { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatProductType()
        {
            this.ID = -1;
            this.ProductTypeCode = string.Empty;
            this.ProductTypeName = string.Empty;
            this.Descriptions = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatProductType(DTOCatProductType _CatProductType)
        {
            this.ID = _CatProductType.ID;
            this.ProductTypeCode = _CatProductType.ProductTypeCode;
            this.ProductTypeName = _CatProductType.ProductTypeName;
            this.Descriptions = _CatProductType.Descriptions;
            this.OrderBy = _CatProductType.OrderBy;
            this.IsActive = _CatProductType.IsActive;
            this.UpdateDate = _CatProductType.UpdateDate;
            this.UpdateBy = _CatProductType.UpdateBy;
            this.IsDelete = _CatProductType.IsDelete;
        }

        public DTOCatProductType(long _ID, string _ProductTypeCode, string _ProductTypeName, string _Descriptions, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.ProductTypeCode = _ProductTypeCode;
            this.ProductTypeName = _ProductTypeName;
            this.Descriptions = _Descriptions;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
