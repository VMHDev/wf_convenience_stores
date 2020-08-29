using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductInDT
    {
        public long TrnID { get; set; }
        public DTOProduct Product { get; set; }
        public decimal ProductWeight { get; set; }
        public int Quantity { get; set; }
        public DTOCatUnitWeight UnitWeight { get; set; }
        public DTOCatUnitIn UnitIn { get; set; }
        public DTOCatUnitSell UnitSell { get; set; }
        public decimal RateIn { get; set; }
        public decimal RateSell { get; set; }
        public DTOCatSupplier Supplier { get; set; }

        public DTOTrnProductInDT()
        {
            this.TrnID = -1;
            this.Product = new DTOProduct();         
            this.ProductWeight = 0M;
            this.Quantity = 0;
            this.UnitWeight = new DTOCatUnitWeight();
            this.UnitIn = new DTOCatUnitIn();
            this.UnitSell = new DTOCatUnitSell();
            this.RateIn = 0M;
            this.RateSell = 0M;
            this.Supplier = new DTOCatSupplier();
        }

        public DTOTrnProductInDT(DTOTrnProductInDT _TrnProductInDT)
        {
            this.TrnID = _TrnProductInDT.TrnID;
            this.Product = _TrnProductInDT.Product;
            this.ProductWeight = _TrnProductInDT.ProductWeight;
            this.Quantity = _TrnProductInDT.Quantity;
            this.UnitWeight = _TrnProductInDT.UnitWeight;
            this.UnitIn = _TrnProductInDT.UnitIn;
            this.UnitSell = _TrnProductInDT.UnitSell;
            this.RateIn = _TrnProductInDT.RateIn;
            this.RateSell = _TrnProductInDT.RateSell;
            this.Supplier = _TrnProductInDT.Supplier;
        }

        public DTOTrnProductInDT(long _TrnID, DTOProduct _Product, decimal _ProductWeight, int _Quantity, DTOCatUnitWeight _UnitWeight, DTOCatUnitIn _UnitIn, DTOCatUnitSell _UnitSell, decimal _RateIn, decimal _RateSell, DTOCatSupplier _Supplier)
        {
            this.TrnID = _TrnID;
            this.Product = _Product;
            this.ProductWeight = _ProductWeight;
            this.Quantity = _Quantity;
            this.UnitWeight = _UnitWeight;
            this.UnitIn = _UnitIn;
            this.UnitSell = _UnitSell;
            this.RateIn = _RateIn;
            this.RateSell = _RateSell;
            this.Supplier = _Supplier;
        }
    }
}
