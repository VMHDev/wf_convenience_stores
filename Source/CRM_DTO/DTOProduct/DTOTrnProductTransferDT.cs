using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductTransferDT
    {
        public long TrnID { get; set; }
        public DTOProduct Product { get; set; }
        public decimal ProductWeight { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public DTOTrnProductTransferDT()
        {
            this.TrnID = -1;
            this.Product = new DTOProduct();
            this.ProductWeight = 0M;
            this.Quantity = 0;
            this.Notes = string.Empty;
        }

        public DTOTrnProductTransferDT(DTOTrnProductTransferDT _TrnProductTransferDT)
        {
            this.TrnID = _TrnProductTransferDT.TrnID;
            this.Product = _TrnProductTransferDT.Product;
            this.ProductWeight = _TrnProductTransferDT.ProductWeight;
            this.Quantity = _TrnProductTransferDT.Quantity;
            this.Notes = _TrnProductTransferDT.Notes;
        }

        public DTOTrnProductTransferDT(long _TrnID, DTOProduct _Product, decimal _ProductWeight, int _Quantity, string _Notes)
        {
            this.TrnID = _TrnID;
            this.Product = _Product;
            this.ProductWeight = _ProductWeight;
            this.Quantity = _Quantity;
            this.Notes = _Notes;
        }
    }
}
