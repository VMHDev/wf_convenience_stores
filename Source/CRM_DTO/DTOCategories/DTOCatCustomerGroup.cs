using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatCustomerGroup
    {
        public long ID { get; set; }
        public string CustGroupCode { get; set; }
        public string CustGroupName { get; set; }
        public string Notes { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatCustomerGroup()
        {
            this.ID = -1;
            this.CustGroupCode = string.Empty;
            this.CustGroupName = string.Empty;
            this.Notes = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }
        public DTOCatCustomerGroup(DTOCatCustomerGroup _CatCustomerGroup)
        {
            this.ID = _CatCustomerGroup.ID;
            this.CustGroupCode = _CatCustomerGroup.CustGroupCode;
            this.CustGroupName = _CatCustomerGroup.CustGroupName;
            this.Notes = _CatCustomerGroup.Notes;
            this.OrderBy = _CatCustomerGroup.OrderBy;
            this.IsActive = _CatCustomerGroup.IsActive;
            this.UpdateDate = _CatCustomerGroup.UpdateDate;
            this.UpdateBy = _CatCustomerGroup.UpdateBy;
            this.IsDelete = _CatCustomerGroup.IsDelete;
        }

        public DTOCatCustomerGroup(long _ID, string _CustGroupCode, string _CustGroupName, string _Notes, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.CustGroupCode = _CustGroupCode;
            this.CustGroupName = _CustGroupName;
            this.Notes = _Notes;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
