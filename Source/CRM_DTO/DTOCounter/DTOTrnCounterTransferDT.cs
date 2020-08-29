using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCounter
{
    public class DTOTrnCounterTransferDT
    {
        public long TrnID { get; set; }
        public DTOCatCurrency Currency { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public DTOTrnCounterTransferDT()
        {
            this.TrnID = -1;
            this.Currency = new DTOCatCurrency();
            this.Amount = 0M;
            this.Notes = string.Empty;
        }

        public DTOTrnCounterTransferDT(DTOTrnCounterTransferDT _TrnCounterTransferDT)
        {
            this.TrnID = _TrnCounterTransferDT.TrnID;

            this.Currency = _TrnCounterTransferDT.Currency;
            this.Amount = _TrnCounterTransferDT.Amount;
            this.Notes = _TrnCounterTransferDT.Notes;
        }

        public DTOTrnCounterTransferDT(long _TrnID, DTOCatCurrency _Currency, decimal _Amount, string _Notes)
        {
            this.TrnID = _TrnID;
            this.Currency = _Currency;
            this.Amount = _Amount;
            this.Notes = _Notes;
        }
    }
}
