using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductOutDT
    {
        public long TrnID { get; set; }
        public DTOProduct Product { get; set; }
        public DTOCatStalls Stalls { get; set; }
        public DTOCatSupplier Supplier { get; set; }
        public decimal WeightsOut { get; set; }
        public decimal WeightsStock { get; set; }
        public decimal WeightsStockReal { get; set; }
        public int QuantityOut { get; set; }
        public int QuantityStock { get; set; }
        public int QuantityStockReal { get; set; }
        public string Notes { get; set; }

        public DTOTrnProductOutDT()
        {
            this.TrnID = -1;
            this.Product = new DTOProduct();
            this.Stalls = new DTOCatStalls();
            this.Supplier = new DTOCatSupplier();
            this.WeightsOut = 0M;
            this.WeightsStock = 0M;
            this.WeightsStockReal = 0M;
            this.QuantityOut = 0;
            this.QuantityStock = 0;
            this.QuantityStockReal = 0;
            this.Notes = string.Empty;
        }

        public DTOTrnProductOutDT(DTOTrnProductOutDT _TrnProductOutDT)
        {
            this.TrnID = _TrnProductOutDT.TrnID;
            this.Product = _TrnProductOutDT.Product;
            this.Stalls = _TrnProductOutDT.Stalls;
            this.Supplier = _TrnProductOutDT.Supplier;
            this.WeightsOut = _TrnProductOutDT.WeightsOut;
            this.WeightsStock = _TrnProductOutDT.WeightsStock;
            this.WeightsStockReal = _TrnProductOutDT.WeightsStockReal;
            this.QuantityOut = _TrnProductOutDT.QuantityOut;
            this.QuantityStock = _TrnProductOutDT.QuantityStock;
            this.QuantityStockReal = _TrnProductOutDT.QuantityStockReal;
            this.Notes = _TrnProductOutDT.Notes;
        }

        public DTOTrnProductOutDT(long _TrnID, DTOProduct _Product, DTOCatStalls _Stalls, DTOCatSupplier _Supplier, decimal _WeightsOut, decimal _WeightsStock, decimal _WeightsStockReal, int _QuantityOut, int _QuantityStock, int _QuantityStockReal, string _Notes)
        {
            this.TrnID = _TrnID;
            this.Product = _Product;
            this.Stalls = _Stalls;
            this.Supplier = _Supplier;
            this.WeightsOut = _WeightsOut;
            this.WeightsStock = _WeightsStock;
            this.WeightsStockReal = _WeightsStockReal;
            this.QuantityOut = _QuantityOut;
            this.QuantityStock = _QuantityStock;
            this.QuantityStockReal = _QuantityStockReal;
            this.Notes = _Notes;
        }
    }
}
