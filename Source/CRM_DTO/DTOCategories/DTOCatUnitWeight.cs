using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatUnitWeight
    {
        public long ID { get; set; }
        public string UnitWeightCode { get; set; }
        public string UnitWeightDesc { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatUnitWeight()
        {
            this.ID = -1;
            this.UnitWeightCode = string.Empty;
            this.UnitWeightDesc = string.Empty;
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatUnitWeight(DTOCatUnitWeight _CatUnitWeight)
        {
            this.ID = _CatUnitWeight.ID;
            this.UnitWeightCode = _CatUnitWeight.UnitWeightCode;
            this.UnitWeightDesc = _CatUnitWeight.UnitWeightDesc;
            this.OrderBy = _CatUnitWeight.OrderBy;
            this.IsActive = _CatUnitWeight.IsActive;
            this.UpdateDate = _CatUnitWeight.UpdateDate;
            this.UpdateBy = _CatUnitWeight.UpdateBy;
            this.IsDelete = _CatUnitWeight.IsDelete;
        }

        public DTOCatUnitWeight(long _ID, string _UnitWeightCode, string _UnitWeightDesc, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.UnitWeightCode = _UnitWeightCode;
            this.UnitWeightDesc = _UnitWeightDesc;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
