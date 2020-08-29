using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatProduct
    {
        public long ProductID { get; set; }
        public long ProductCatID { get; set; }
        public string ProductCatCode { get; set; }
        public string ProductCatName { get; set; }
        public string Descriptions { get; set; }
        public DTOCatProductType ProductType { get; set; }
        public DTOCatProductGroup ProductGroup { get; set; }
        public DTOCatSupplier Supplier { get; set; }
        public DTOCatStalls Stalls { get; set; }
        public byte[] ProductCatImage { get; set; }
        public DTOCatUnitSell UnitSell { get; set; }
        public DTOCatUnitWeight UnitWeight { get; set; }
        public DTOSysProductRate Rate { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public string UserUpdate { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatProduct()
        {
            this.ProductID = -1;
            this.ProductCatID = -1;
            this.ProductCatCode = string.Empty;
            this.ProductCatName = string.Empty;
            this.Descriptions = string.Empty;
            this.ProductType = new DTOCatProductType();
            this.ProductGroup = new DTOCatProductGroup();
            this.Supplier = new DTOCatSupplier();
            this.Stalls = new DTOCatStalls();
            this.ProductCatImage = null;
            this.UnitSell = new DTOCatUnitSell();
            this.UnitWeight = new DTOCatUnitWeight();
            this.Rate = new DTOSysProductRate();
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.UserUpdate = string.Empty;
            this.IsDelete = false;
        }

        public DTOCatProduct(DTOCatProduct _CatProduct)
        {
            this.ProductID = _CatProduct.ProductID;
            this.ProductCatID = _CatProduct.ProductCatID;
            this.ProductCatCode = _CatProduct.ProductCatCode;
            this.ProductCatName = _CatProduct.ProductCatName;
            this.Descriptions = _CatProduct.Descriptions;
            this.ProductType = _CatProduct.ProductType;
            this.ProductGroup = _CatProduct.ProductGroup;
            this.Supplier = _CatProduct.Supplier;
            this.Stalls = _CatProduct.Stalls;
            this.ProductCatImage = _CatProduct.ProductCatImage;
            this.UnitSell = _CatProduct.UnitSell;
            this.UnitWeight = _CatProduct.UnitWeight;
            this.Rate = _CatProduct.Rate;
            this.OrderBy = _CatProduct.OrderBy;
            this.IsActive = _CatProduct.IsActive;
            this.UpdateDate = _CatProduct.UpdateDate;
            this.UpdateBy = _CatProduct.UpdateBy;
            this.UserUpdate = _CatProduct.UserUpdate;
            this.IsDelete = _CatProduct.IsDelete;
        }

        public DTOCatProduct(long _ProductID, long _ProductCatID, string _ProductCatCode, string _ProductCatName, string _Descriptions,
                             DTOCatProductType _ProductType, DTOCatProductGroup _ProductGroup, DTOCatSupplier _Supplier, 
                             DTOCatStalls _Stalls, DTOCatUnitSell _UnitSell, DTOCatUnitWeight _UnitWeight, DTOSysProductRate _Rate,
                             byte[] _ProductCatImage, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, string _UserUpdate, bool _IsDelete)
        {
            this.ProductID = _ProductID;
            this.ProductCatID = _ProductCatID;
            this.ProductCatCode = _ProductCatCode;
            this.ProductCatName = _ProductCatName;
            this.Descriptions = _Descriptions;
            this.ProductType = _ProductType;
            this.ProductGroup = _ProductGroup;
            this.Supplier = _Supplier;
            this.ProductCatImage = _ProductCatImage;
            this.UnitSell = _UnitSell;
            this.UnitWeight = _UnitWeight;
            this.Rate = _Rate;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.UserUpdate = _UserUpdate;
            this.IsDelete = _IsDelete;
        }
    }
}
