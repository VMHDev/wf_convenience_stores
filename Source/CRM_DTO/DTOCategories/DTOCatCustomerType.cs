using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatCustomerType
    {
        public long ID { get; set; }
        public string CustTypeCode { get; set; }
        public string CustTypeName { get; set; }
        public string Notes { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatCustomerType()
        {
            this.ID = -1;
            this.CustTypeCode = string.Empty;
            this.CustTypeName = string.Empty;
            this.Notes = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }
        public DTOCatCustomerType(DTOCatCustomerType _CatCustomerType)
        {
            this.ID = _CatCustomerType.ID;
            this.CustTypeCode = _CatCustomerType.CustTypeCode;
            this.CustTypeName = _CatCustomerType.CustTypeName;
            this.Notes = _CatCustomerType.Notes;
            this.OrderBy = _CatCustomerType.OrderBy;
            this.IsActive = _CatCustomerType.IsActive;
            this.UpdateDate = _CatCustomerType.UpdateDate;
            this.UpdateBy = _CatCustomerType.UpdateBy;
            this.IsDelete = _CatCustomerType.IsDelete;
        }

        public DTOCatCustomerType(long _ID, string _CustTypeCode, string _CustTypeName, string _Notes, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.CustTypeCode = _CustTypeCode;
            this.CustTypeName = _CustTypeName;
            this.Notes = _Notes;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
