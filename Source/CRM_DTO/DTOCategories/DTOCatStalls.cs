using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatStalls
    {
        public long ID { get; set; }
        public string StallsCode { get; set; }
        public string StallsName { get; set; }
        public DTOCatShop Shop { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatStalls()
        {
            this.ID = -1;
            this.StallsCode = string.Empty;
            this.StallsName = string.Empty;
            this.Shop = new DTOCatShop();
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatStalls(DTOCatStalls _CatStalls)
        {
            this.ID = _CatStalls.ID;
            this.StallsCode = _CatStalls.StallsCode;
            this.StallsName = _CatStalls.StallsName;
            this.Shop = _CatStalls.Shop;
            this.OrderBy = _CatStalls.OrderBy;
            this.IsActive = _CatStalls.IsActive;
            this.UpdateDate = _CatStalls.UpdateDate;
            this.UpdateBy = _CatStalls.UpdateBy;
            this.IsDelete = _CatStalls.IsDelete;
        }

        public DTOCatStalls(long _ID, long _OrderBy, bool _IsActive, string _StallsCode, string _StallsName, DTOCatShop _Shop, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.StallsCode = _StallsCode;
            this.StallsName = _StallsName;
            this.Shop = _Shop;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
