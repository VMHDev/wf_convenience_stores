using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductSellDT
    {
        public long TrnID { get; set; }
        public DTOProduct Product { get; set; }
        public DTOCatStalls Stalls { get; set; }
        public decimal ProductWeight { get; set; }
        public int Quantity { get; set; }
        public DTOCatUnitSell UnitSell { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public DTOTrnProductSellDT()
        {
            this.TrnID = -1;
            this.Product = null;
            this.Stalls = null;
            this.ProductWeight = 0M;
            this.Quantity = 0;
            this.UnitSell = null;
            this.Rate = 0M;
            this.Discount = 0M;
            this.Amount = 0M;
            this.Notes = string.Empty;
        }

        public DTOTrnProductSellDT(DTOTrnProductSellDT _TrnProductSellDT)
        {
            this.TrnID = _TrnProductSellDT.TrnID;
            this.Product = _TrnProductSellDT.Product;
            this.Stalls = _TrnProductSellDT.Stalls;
            this.ProductWeight = _TrnProductSellDT.ProductWeight;
            this.Quantity = _TrnProductSellDT.Quantity;
            this.UnitSell = _TrnProductSellDT.UnitSell;
            this.Rate = _TrnProductSellDT.Rate;
            this.Discount = _TrnProductSellDT.Discount;
            this.Amount = _TrnProductSellDT.Amount;
            this.Notes = _TrnProductSellDT.Notes;
        }

        public DTOTrnProductSellDT(long _TrnID, DTOProduct _Product, DTOCatStalls _Stalls, decimal _ProductWeight, int _Quantity, DTOCatUnitSell _UnitSell, decimal _Rate, decimal _Discount, decimal _Amount, string _Notes)
        {
            this.TrnID = _TrnID;
            this.Product = _Product;
            this.Stalls = _Stalls;
            this.ProductWeight = _ProductWeight;
            this.Quantity = _Quantity;
            this.UnitSell = _UnitSell;
            this.Rate = _Rate;
            this.Discount = _Discount;
            this.Amount = _Amount;
            this.Notes = _Notes;
        }
    }
}
