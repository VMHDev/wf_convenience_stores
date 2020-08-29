using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatShop
    {
        public long ID { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopTel { get; set; }
        public string ShopFax { get; set; }
        public string ShopTax { get; set; }
        public string ShopWebsite { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatShop()
        {
            this.ID = -1;
            this.ShopCode = string.Empty;
            this.ShopName = string.Empty;
            this.ShopAddress = string.Empty;
            this.ShopTel = string.Empty;
            this.ShopFax = string.Empty;
            this.ShopTax = string.Empty;
            this.ShopWebsite = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatShop(DTOCatShop _CatShop)
        {
            this.ID = _CatShop.ID;
            this.ShopCode = _CatShop.ShopCode;
            this.ShopName = _CatShop.ShopName;
            this.ShopAddress = _CatShop.ShopAddress;
            this.ShopTel = _CatShop.ShopTel;
            this.ShopFax = _CatShop.ShopFax;
            this.ShopTax = _CatShop.ShopTax;
            this.ShopWebsite = _CatShop.ShopWebsite;
            this.OrderBy = _CatShop.OrderBy;
            this.IsActive = _CatShop.IsActive;
            this.UpdateDate = _CatShop.UpdateDate;
            this.UpdateBy = _CatShop.UpdateBy;
            this.IsDelete = _CatShop.IsDelete;
        }

        public DTOCatShop(long _ID, string _ShopCode, string _ShopName)
        {
            this.ID = _ID;
            this.ShopCode = _ShopCode;
            this.ShopName = _ShopName;
            this.ShopAddress = string.Empty;
            this.ShopTel = string.Empty;
            this.ShopFax = string.Empty;
            this.ShopTax = string.Empty;
            this.ShopWebsite = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatShop(long _ID, string _ShopCode, string _ShopName, string _ShopAddress, string _ShopTel, string _ShopFax, string _ShopTax, string _ShopWebsite, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.ShopCode = _ShopCode;
            this.ShopName = _ShopName;
            this.ShopAddress = _ShopAddress;
            this.ShopTel = _ShopTel;
            this.ShopFax = _ShopFax;
            this.ShopTax = _ShopTax;
            this.ShopWebsite = _ShopWebsite;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
