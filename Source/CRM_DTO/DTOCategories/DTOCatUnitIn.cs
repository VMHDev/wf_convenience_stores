using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatUnitIn
    {
        public long ID { get; set; }
        public string UnitInCode { get; set; }
        public string UnitInDesc { get; set; }
        public decimal ScaleChange { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatUnitIn()
        {
            this.ID = -1;
            this.UnitInCode = string.Empty;
            this.UnitInDesc = string.Empty;
            this.ScaleChange = 0M;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatUnitIn(DTOCatUnitIn _CatUnitIn)
        {
            this.ID = _CatUnitIn.ID;
            this.UnitInCode = _CatUnitIn.UnitInCode;
            this.UnitInDesc = _CatUnitIn.UnitInDesc;
            this.ScaleChange = _CatUnitIn.ScaleChange;
            this.OrderBy = _CatUnitIn.OrderBy;
            this.IsActive = _CatUnitIn.IsActive;
            this.UpdateDate = _CatUnitIn.UpdateDate;
            this.UpdateBy = _CatUnitIn.UpdateBy;
            this.IsDelete = _CatUnitIn.IsDelete;
        }

        public DTOCatUnitIn(long _ID, string _UnitInCode, string _UnitInDesc, decimal _ScaleChange, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.UnitInCode = _UnitInCode;
            this.UnitInDesc = _UnitInDesc;
            this.ScaleChange = _ScaleChange;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
