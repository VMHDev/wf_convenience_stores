using CRM_DTO.DTOCategories;
using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOProduct
    {
        public long ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductDesc { get; set; }
        public string Descriptions { get; set; }
        public DTOCatProductType ProductType { get; set; }
        public DTOCatProductGroup ProductGroup { get; set; }
        public DTOCatUnitWeight UnitWeight { get; set; }
        public DTOCatUnitSell UnitSell { get; set; }
        public DTOCatSupplier Supplier { get; set; }
        public DTOCatStalls Stalls { get; set; }
        public DTOSysProductRate Rate { get; set; }
        public string StatusCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public string UserUpdate { get; set; }
        public bool IsDelete { get; set; }

        public DTOProduct()
        {
            this.ID = -1;
            this.ProductCode = string.Empty;
            this.ProductDesc = string.Empty;
            this.Descriptions = string.Empty;
            this.ProductType = new DTOCatProductType();
            this.ProductGroup = new DTOCatProductGroup();
            this.UnitWeight = new DTOCatUnitWeight();
            this.UnitSell = new DTOCatUnitSell();
            this.Supplier = new DTOCatSupplier();
            this.Stalls = new DTOCatStalls();
            this.Rate = new DTOSysProductRate();
            this.StatusCode = string.Empty;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOProduct(DTOProduct _Product)
        {
            this.ID = _Product.ID;
            this.ProductCode = _Product.ProductCode;
            this.ProductDesc = _Product.ProductDesc;
            this.Descriptions = _Product.Descriptions;
            this.ProductType = _Product.ProductType;
            this.ProductGroup = _Product.ProductGroup;
            this.UnitWeight = _Product.UnitWeight;
            this.UnitSell = _Product.UnitSell;
            this.Supplier = _Product.Supplier;
            this.Stalls = _Product.Stalls;
            this.Rate = _Product.Rate;
            this.StatusCode = _Product.StatusCode;
            this.UpdateDate = _Product.UpdateDate;
            this.UpdateBy = _Product.UpdateBy;
            this.IsDelete = _Product.IsDelete;
        }

        public DTOProduct(long _ID, string _ProductCode, string _ProductDesc,
                          string _Descriptions, DTOCatProductType _ProductType,
                          DTOCatProductGroup _ProductGroup, DTOCatUnitWeight _UnitWeight,
                          DTOCatUnitSell _UnitSell, DTOCatSupplier _Supplier, DTOCatStalls _Stalls, DTOSysProductRate _Rate, string _StatusCode, 
                          DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)            
        {
            this.ID = _ID;
            this.ProductCode = _ProductCode;
            this.ProductDesc = _ProductDesc;
            this.Descriptions = _Descriptions;
            this.ProductType = _ProductType;
            this.ProductGroup = _ProductGroup;
            this.UnitWeight = _UnitWeight;
            this.UnitSell = _UnitSell;
            this.Supplier = _Supplier;
            this.Stalls = _Stalls;
            this.Rate = _Rate;
            this.StatusCode = _StatusCode;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
