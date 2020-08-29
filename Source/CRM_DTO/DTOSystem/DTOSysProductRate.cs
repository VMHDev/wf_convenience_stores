using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOSystem
{
    public class DTOSysProductRate
    {
        public long ProductID { get; set; }
        public DateTime RateDate { get; set; }
        public decimal RateIn { get; set; }
        public decimal RateEstimate { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal RateSell { get; set; }
        public bool IsSellCurrent { get; set; }

        public DTOSysProductRate()
        {
            this.ProductID = -1;
            this.RateDate = DateTime.Now;
            this.RateIn = 0;
            this.RateEstimate = 0;
            this.DiscountPercent = 0;
            this.Discount = 0;
            this.DiscountTotal = 0;
            this.RateSell = 0;
            this.IsSellCurrent = true;
        }

        public DTOSysProductRate(DTOSysProductRate _ObjSysProductRate)
        {
            this.ProductID = _ObjSysProductRate.ProductID;
            this.RateDate = _ObjSysProductRate.RateDate;
            this.RateIn = _ObjSysProductRate.RateIn;
            this.RateEstimate = _ObjSysProductRate.RateEstimate;
            this.DiscountPercent = _ObjSysProductRate.DiscountPercent;
            this.Discount = _ObjSysProductRate.Discount;
            this.DiscountTotal = _ObjSysProductRate.DiscountTotal;
            this.RateSell = _ObjSysProductRate.RateSell;
            this.IsSellCurrent = _ObjSysProductRate.IsSellCurrent;
        }

        public DTOSysProductRate(long _ProductID, DateTime _RateDate, decimal _RateIn, decimal _RateEstimate, decimal _DiscountPercent, decimal _Discount, decimal _DiscountTotal, decimal _RateSell, bool _IsSellCurrent)
        {
            this.ProductID = _ProductID;
            this.RateDate = _RateDate;
            this.RateIn = _RateIn;
            this.RateEstimate = _RateEstimate;
            this.DiscountPercent = _DiscountPercent;
            this.Discount = _Discount;
            this.DiscountTotal = _DiscountTotal;
            this.RateSell = _RateSell;
            this.IsSellCurrent = _IsSellCurrent;
        }
    }
}
