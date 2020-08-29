using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCounter
{
    public class DTOTrnCounterInOutDT
    {
        public long TrnID { get; set; }
        public bool TrnTypeID { get; set; }
        public string TrnTypeName { get; set; }
        public DTOCatCurrency Currency { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public DTOTrnCounterInOutDT()
        {
            this.TrnID = -1;
            this.TrnTypeID = true;
            this.TrnTypeName = "Mua";
            this.Currency = new DTOCatCurrency();
            this.Amount = 0M;
            this.Notes = string.Empty;
        }

        public DTOTrnCounterInOutDT(DTOTrnCounterInOutDT _TrnCounterInOutDT)
        {
            this.TrnID = _TrnCounterInOutDT.TrnID;
            this.TrnTypeID = _TrnCounterInOutDT.TrnTypeID;
            this.TrnTypeName = _TrnCounterInOutDT.TrnTypeName;
            this.Currency = _TrnCounterInOutDT.Currency;
            this.Amount = _TrnCounterInOutDT.Amount;
            this.Notes = _TrnCounterInOutDT.Notes;
        }

        public DTOTrnCounterInOutDT(long _TrnID, bool _TrnTypeID, string _TrnTypeName, DTOCatCurrency _Currency, decimal _Amount, string _Notes)
        {
            this.TrnID = _TrnID;
            this.TrnTypeID = _TrnTypeID;
            this.TrnTypeName = _TrnTypeName;
            this.Currency = _Currency;
            this.Amount = _Amount;
            this.Notes = _Notes;
        }
    }
}
