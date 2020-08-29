using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCounter
{
    public class DTOTrnCounterTransfer
    {
        public long TrnID { get; set; }
        public string TrnCode { get; set; }
        public DateTime TrnDate { get; set; }
        public TimeSpan TrnTime { get; set; }
        public DTOCatCounter CounterFrom { get; set; }
        public DTOCatCounter CounterTo { get; set; }
        public string Notes { get; set; }
        public DTOCatEmployee Employee { get; set; }
        public string StatusCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public List<DTOTrnCounterTransferDT> LstTrnCounterTransferDT { get; set; }

        public DTOTrnCounterTransfer()
        {
            this.TrnID = -1;
            this.TrnCode = "{Tự động}";
            this.TrnDate = DateTime.MinValue;
            this.TrnTime = TimeSpan.MinValue;
            this.CounterFrom = new DTOCatCounter();
            this.CounterTo = new DTOCatCounter();
            this.Notes = string.Empty;
            this.Employee = new DTOCatEmployee();
            this.StatusCode = string.Empty;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
            this.LstTrnCounterTransferDT = new List<DTOTrnCounterTransferDT>();
        }

        public DTOTrnCounterTransfer(DTOTrnCounterTransfer _TrnCounterTransfer)
        {
            this.TrnID = _TrnCounterTransfer.TrnID;
            this.TrnCode = _TrnCounterTransfer.TrnCode;
            this.TrnDate = _TrnCounterTransfer.TrnDate;
            this.TrnTime = _TrnCounterTransfer.TrnTime;
            this.CounterFrom = _TrnCounterTransfer.CounterFrom;
            this.CounterTo = _TrnCounterTransfer.CounterTo;
            this.Notes = _TrnCounterTransfer.Notes;
            this.Employee = _TrnCounterTransfer.Employee;
            this.StatusCode = _TrnCounterTransfer.StatusCode;
            this.UpdateDate = _TrnCounterTransfer.UpdateDate;
            this.UpdateBy = _TrnCounterTransfer.UpdateBy;
            this.IsDelete = _TrnCounterTransfer.IsDelete;
            this.LstTrnCounterTransferDT = _TrnCounterTransfer.LstTrnCounterTransferDT;
        }

        public DTOTrnCounterTransfer(long _TrnID, string _TrnCode, DateTime _TrnDate, TimeSpan _TrnTime, DTOCatCounter _CounterFrom, DTOCatCounter _CounterTo, string _Notes, DTOCatEmployee _Employee, string _StatusCode, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete, List<DTOTrnCounterTransferDT> _LstTrnCounterTransferDT)
        {
            this.TrnID = _TrnID;
            this.TrnCode = _TrnCode;
            this.TrnDate = _TrnDate;
            this.TrnTime = _TrnTime;
            this.CounterFrom = _CounterFrom;
            this.CounterTo = _CounterTo;
            this.Notes = _Notes;
            this.Employee = _Employee;
            this.StatusCode = _StatusCode;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
            this.LstTrnCounterTransferDT = _LstTrnCounterTransferDT;
        }
    }
}
