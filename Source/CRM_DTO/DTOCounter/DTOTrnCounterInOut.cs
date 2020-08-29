using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCounter
{
    public class DTOTrnCounterInOut
    {
        public long TrnID { get; set; }
        public string TrnCode { get; set; }
        public DateTime TrnDate { get; set; }
        public TimeSpan TrnTime { get; set; }
        public DTOCatCounter Counter { get; set; }
        public string Notes { get; set; }
        public DTOCatEmployee Employee { get; set; }
        public string StatusCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public List<DTOTrnCounterInOutDT> LstTrnCounterInOutDT { get; set; }

        public DTOTrnCounterInOut()
        {
            this.TrnID = -1;
            this.TrnCode = "{Tự động}";
            this.TrnDate = DateTime.MinValue;
            this.TrnTime = TimeSpan.MinValue;
            this.Counter = new DTOCatCounter();
            this.Notes = string.Empty;
            this.Employee = new DTOCatEmployee();
            this.StatusCode = string.Empty;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOTrnCounterInOut(DTOTrnCounterInOut _TrnCounterInOut)
        {
            this.TrnID = _TrnCounterInOut.TrnID;
            this.TrnCode = _TrnCounterInOut.TrnCode;
            this.TrnDate = _TrnCounterInOut.TrnDate;
            this.TrnTime = _TrnCounterInOut.TrnTime;
            this.Counter = _TrnCounterInOut.Counter;
            this.Notes = _TrnCounterInOut.Notes;
            this.Employee = _TrnCounterInOut.Employee;
            this.StatusCode = _TrnCounterInOut.StatusCode;
            this.UpdateDate = _TrnCounterInOut.UpdateDate;
            this.UpdateBy = _TrnCounterInOut.UpdateBy;
            this.IsDelete = _TrnCounterInOut.IsDelete;
        }

        public DTOTrnCounterInOut(long _TrnID, string _TrnCode, DateTime _TrnDate, TimeSpan _TrnTime, DTOCatCounter _Counter, string _Notes, DTOCatEmployee _Employee, string _StatusCode, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.TrnID = _TrnID;
            this.TrnCode = _TrnCode;
            this.TrnDate = _TrnDate;
            this.TrnTime = _TrnTime;
            this.Counter = _Counter;
            this.Notes = _Notes;
            this.Employee = _Employee;
            this.StatusCode = _StatusCode;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
