using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductOut
    {
        public long TrnID { get; set; }
        public string TrnCode { get; set; }
        public DateTime TrnDate { get; set; }
        public TimeSpan TrnTime { get; set; }
        public DTOCatStalls Stalls { get; set; }
        public string Notes { get; set; }
        public DTOCatEmployee Employee { get; set; }
        public string StatusCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public List<DTOTrnProductOutDT> LstTrnProductOutDT { get; set; }

        public DTOTrnProductOut()
        {
            this.TrnID = -1;
            this.TrnCode = "{Tự động}";
            this.TrnDate = DateTime.MinValue;
            this.TrnTime = TimeSpan.MinValue;
            this.Stalls = new DTOCatStalls();
            this.Notes = string.Empty;
            this.Employee = new DTOCatEmployee();
            this.StatusCode = string.Empty;
            this.UpdateDate = DateTime.MinValue; ;
            this.UpdateBy = -1;
            this.IsDelete = false;
            this.LstTrnProductOutDT = new List<DTOTrnProductOutDT>();
        }

        public DTOTrnProductOut(DTOTrnProductOut _TrnProductOut)
        {
            this.TrnID = _TrnProductOut.TrnID;
            this.TrnCode = _TrnProductOut.TrnCode;
            this.TrnDate = _TrnProductOut.TrnDate;
            this.TrnTime = _TrnProductOut.TrnTime;
            this.Stalls = _TrnProductOut.Stalls;
            this.Notes = _TrnProductOut.Notes;
            this.Employee = _TrnProductOut.Employee;
            this.StatusCode = _TrnProductOut.StatusCode;
            this.UpdateDate = _TrnProductOut.UpdateDate;
            this.UpdateBy = _TrnProductOut.UpdateBy;
            this.IsDelete = _TrnProductOut.IsDelete;
            this.LstTrnProductOutDT = _TrnProductOut.LstTrnProductOutDT;
        }

        public DTOTrnProductOut(long _TrnID, string _TrnCode, DateTime _TrnDate, TimeSpan _TrnTime, DTOCatStalls _Stalls, string _Notes, DTOCatEmployee _Employee, string _StatusCode, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete, List<DTOTrnProductOutDT> _LstTrnProductOutDT)
        {
            this.TrnID = _TrnID;
            this.TrnCode = _TrnCode;
            this.TrnDate = _TrnDate;
            this.TrnTime = _TrnTime;
            this.Stalls = _Stalls;
            this.Notes = _Notes;
            this.Employee = _Employee;
            this.StatusCode = _StatusCode;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
            this.LstTrnProductOutDT = _LstTrnProductOutDT;
        }
    }
}
