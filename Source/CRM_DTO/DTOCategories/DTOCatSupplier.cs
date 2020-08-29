using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatSupplier
    {
        public long ID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string Phone { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatSupplier()
        {
            this.ID = -1;
            this.SupplierCode = string.Empty;
            this.SupplierName = string.Empty;
            this.SupplierAddress = string.Empty;
            this.Phone = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatSupplier(DTOCatSupplier _CatSupplier)
        {
            this.ID = _CatSupplier.ID;
            this.SupplierCode = _CatSupplier.SupplierCode;
            this.SupplierName = _CatSupplier.SupplierName;
            this.SupplierAddress = _CatSupplier.SupplierAddress;
            this.Phone = _CatSupplier.Phone;
            this.OrderBy = _CatSupplier.OrderBy;
            this.IsActive = _CatSupplier.IsActive;
            this.UpdateDate = _CatSupplier.UpdateDate;
            this.UpdateBy = _CatSupplier.UpdateBy;
            this.IsDelete = _CatSupplier.IsDelete;
        }

        public DTOCatSupplier(long _ID, string _SupplierCode, string _SupplierName, string _SupplierAddress, string _Phone, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.SupplierCode = _SupplierCode;
            this.SupplierName = _SupplierName;
            this.SupplierAddress = _SupplierAddress;
            this.Phone = _Phone;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
