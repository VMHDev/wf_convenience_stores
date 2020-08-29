using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatUnitSell
    {
        public long ID { get; set; }
        public string UnitSellCode { get; set; }
        public string UnitSellDesc { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatUnitSell()
        {
            this.ID = -1;
            this.UnitSellCode = string.Empty;
            this.UnitSellDesc = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatUnitSell(DTOCatUnitSell _CatUnitSell)
        {
            this.ID = _CatUnitSell.ID;
            this.UnitSellCode = _CatUnitSell.UnitSellCode;
            this.UnitSellDesc = _CatUnitSell.UnitSellDesc;
            this.OrderBy = _CatUnitSell.OrderBy;
            this.IsActive = _CatUnitSell.IsActive;
            this.UpdateDate = _CatUnitSell.UpdateDate;
            this.UpdateBy = _CatUnitSell.UpdateBy;
            this.IsDelete = _CatUnitSell.IsDelete;
        }

        public DTOCatUnitSell(long _ID, string _UnitSellCode, string _UnitSellDesc, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.UnitSellCode = _UnitSellCode;
            this.UnitSellDesc = _UnitSellDesc;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
