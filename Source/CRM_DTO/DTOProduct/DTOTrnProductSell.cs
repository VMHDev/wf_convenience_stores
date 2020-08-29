using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductSell
    {
        public long TrnID { get; set; }
        public string TrnCode { get; set; }
        public DateTime TrnDate { get; set; }
        public TimeSpan TrnTime { get; set; }
        public DTOCatCustomer Customer { get; set; }
        public DTOCatCounter Counter { get; set; }
        public decimal DiscountTrn { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal AmountTotal { get; set; }
        public decimal AmountPay { get; set; }
        public DTOCatCurrency UnitPayment { get; set; }
        public string Notes { get; set; }
        public DTOCatEmployee Employee { get; set; }
        public string StatusCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public List<DTOTrnProductSellDT> LstTrnProductSellDT { get; set; }

        public DTOTrnProductSell()
        {
            this.TrnID = -1;
            this.TrnCode = "{Tự động}";
            this.TrnDate = DateTime.MinValue;
            this.TrnTime = TimeSpan.MinValue;
            this.Customer = new DTOCatCustomer();
            this.Counter = new DTOCatCounter();
            this.DiscountTrn = 0M;
            this.DiscountTotal = 0M;
            this.AmountTotal = 0M;
            this.AmountPay = 0M;
            this.UnitPayment = new DTOCatCurrency();
            this.Notes = string.Empty;
            this.Employee = new DTOCatEmployee();
            this.StatusCode = string.Empty;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
            this.LstTrnProductSellDT = null;
        }

        public DTOTrnProductSell(DTOTrnProductSell _TrnProductSell)
        {
            this.TrnID = _TrnProductSell.TrnID;
            this.TrnCode = _TrnProductSell.TrnCode;
            this.TrnDate = _TrnProductSell.TrnDate;
            this.TrnTime = _TrnProductSell.TrnTime;
            this.Customer = _TrnProductSell.Customer;
            this.Counter = _TrnProductSell.Counter;
            this.DiscountTrn = _TrnProductSell.DiscountTrn;
            this.DiscountTotal = _TrnProductSell.DiscountTotal;
            this.AmountTotal = _TrnProductSell.AmountTotal;
            this.AmountPay = _TrnProductSell.AmountPay;
            this.UnitPayment = _TrnProductSell.UnitPayment;
            this.Notes = _TrnProductSell.Notes;
            this.Employee = _TrnProductSell.Employee;
            this.StatusCode = _TrnProductSell.StatusCode;
            this.UpdateDate = _TrnProductSell.UpdateDate;
            this.UpdateBy = _TrnProductSell.UpdateBy;
            this.IsDelete = _TrnProductSell.IsDelete;
            this.LstTrnProductSellDT = _TrnProductSell.LstTrnProductSellDT;
        }

        public DTOTrnProductSell(long _TrnID, string _TrnCode, DateTime _TrnDate, TimeSpan _TrnTime,
                                 DTOCatCustomer _Customer, DTOCatCounter _Counter, decimal _DiscountTrn, decimal _DiscountTotal, decimal _AmountTotal, decimal _AmountPay, DTOCatCurrency _UnitPayment,
                                 string _Notes, DTOCatEmployee _Employee, string _StatusCode, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete, List<DTOTrnProductSellDT> _TrnProductSellDT)
        {
            this.TrnID = _TrnID;
            this.TrnCode = _TrnCode;
            this.TrnDate = _TrnDate;
            this.TrnTime = _TrnTime;
            this.Customer = _Customer;
            this.Counter = _Counter;
            this.DiscountTrn = _DiscountTrn;
            this.DiscountTotal = _DiscountTotal;
            this.AmountTotal = _AmountTotal;
            this.AmountPay = _AmountPay;
            this.UnitPayment = _UnitPayment;
            this.Notes = _Notes;
            this.Employee = _Employee;
            this.StatusCode = _StatusCode;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
            this.LstTrnProductSellDT = _TrnProductSellDT;
        }
    }
}
