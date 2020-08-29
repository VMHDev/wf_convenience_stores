using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatCurrency
    {
        public long ID { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDesc { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }
    
        public DTOCatCurrency()
        {
            this.ID = -1;
            this.CurrencyCode = string.Empty;
            this.CurrencyDesc = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatCurrency(DTOCatCurrency _CatCurrency)
        {
            this.ID = _CatCurrency.ID;
            this.CurrencyCode = _CatCurrency.CurrencyCode;
            this.CurrencyDesc = _CatCurrency.CurrencyDesc;
            this.OrderBy = _CatCurrency.OrderBy;
            this.IsActive = _CatCurrency.IsActive;
            this.UpdateDate = _CatCurrency.UpdateDate;
            this.UpdateBy = _CatCurrency.UpdateBy;
            this.IsDelete = _CatCurrency.IsDelete;
        }

        public DTOCatCurrency(long _ID, string _CurrencyCode, string _CurrencyDesc, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.CurrencyCode = _CurrencyCode;
            this.CurrencyDesc = _CurrencyDesc;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
