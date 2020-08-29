using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatCounter
    {
        public long ID { get; set; }
        public string CounterCode { get; set; }
        public string CounterName { get; set; }
        public string StatusCode { get; set; }
        public DTOCatShop Shop { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatCounter()
        {
            this.ID = -1;
            this.CounterCode = string.Empty;
            this.CounterName = string.Empty;
            this.StatusCode = string.Empty;
            this.Shop = new DTOCatShop();
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatCounter(DTOCatCounter _CatCounter)
        {
            this.ID = _CatCounter.ID;
            this.CounterCode = _CatCounter.CounterCode;
            this.CounterName = _CatCounter.CounterName;
            this.StatusCode = _CatCounter.StatusCode;
            this.Shop = _CatCounter.Shop;
            this.OrderBy = _CatCounter.OrderBy;
            this.IsActive = _CatCounter.IsActive;
            this.UpdateDate = _CatCounter.UpdateDate;
            this.UpdateBy = _CatCounter.UpdateBy;
            this.IsDelete = _CatCounter.IsDelete;
        }

        public DTOCatCounter(long _ID, string _CounterCode, string _CounterName)
        {
            this.ID = _ID;
            this.CounterCode = _CounterCode;
            this.CounterName = _CounterName;
            this.StatusCode = string.Empty;
            this.Shop = new DTOCatShop();
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatCounter(long _ID, string _CounterCode, string _CounterName, string _StatusCode, DTOCatShop _ShopID, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.CounterCode = _CounterCode;
            this.CounterName = _CounterName;
            this.StatusCode = _StatusCode;
            this.Shop = _ShopID;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
